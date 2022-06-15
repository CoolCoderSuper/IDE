Imports CodingCool.DeveloperCore.Editor
Imports CodingCool.DeveloperCore.ObjectExplorer
Imports CodingCool.DeveloperCore.Views
Imports System.IO

Public Class frmMain

#Region "Properties"

    Public Property Language As String = "vb"
    Public Property ProjectRoot As String = "C:\Users\User\Documents\Test\Test.proj"
    Public Property ProjectDir As String = "C:\Users\User\Documents\Test\"
    Public Property Output As Boolean = True

#End Region

#Region "Variables"

    Private WithEvents CurrentTB As FastColoredTextBoxNS.FastColoredTextBox
    Private WithEvents tbOutput As OutputTab
    Private WithEvents tbTaskList As TaskListTab
    Private WithEvents tbErrorList As ErrorListTab
    Private WithEvents tbObjectExplorer As ObjectExplorerTab

#End Region

#Region "Events"

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnComment.Image = Icons.Commands.My.Resources.Icons_16x16_CommentRegion
        btnComment.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnRedo.Image = Icons.Commands.My.Resources.Icons_16x16_RedoIcon
        btnRedo.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnUndo.Image = Icons.Commands.My.Resources.Icons_16x16_UndoIcon
        btnUndo.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnSave.Image = Icons.Commands.My.Resources.Icons_16x16_SaveIcon
        btnSave.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnSaveAll.Image = Icons.Commands.My.Resources.Icons_16x16_SaveAllIcon
        btnSaveAll.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnStart.Image = Icons.Commands.My.Resources.Icons_16x16_RunProgramIcon
        btnStart.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnBuild.Image = Icons.Commands.My.Resources.Icons_16x16_BuildCurrentSelectedProject
        btnBuild.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnCut.Image = Icons.Commands.My.Resources.Icons_16x16_CutIcon
        btnCut.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnCopy.Image = Icons.Commands.My.Resources.Icons_16x16_CopyIcon
        btnCopy.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnPaste.Image = Icons.Commands.My.Resources.Icons_16x16_PasteIcon
        btnPaste.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnDeleteText.Image = Icons.Commands.My.Resources.Icons_16x16_DeleteIcon
        btnDeleteText.DisplayStyle = ToolStripItemDisplayStyle.Image
        tbSolution.BackColor = ColorTranslator.FromHtml("#8a8a88")
        lstFiles.BackColor = ColorTranslator.FromHtml("#8a8a88")
        lstFiles.ForeColor = Color.White
        tcTools.BackColor = ColorTranslator.FromHtml("#8a8a88")
        tcMain.BackColor = ColorTranslator.FromHtml("#8a8a88")
        BackColor = ColorTranslator.FromHtml("#888888")
        LoadProjectFiles()
        ConfigureErrorList()
        tcTools.Items.Add(tbErrorList)
        ConfigueTaskList()
        tcTools.Items.Add(tbTaskList)
        tbOutput = New OutputTab
        tcTools.Items.Add(tbOutput)
        tbObjectExplorer = New ObjectExplorerTab
        tcViews.TabPages.Add(tbObjectExplorer)
        tmrObjectExplorer.Start()
        SolutionExplorer1.Load()
        'Test
    End Sub

    Private Sub ConfigueTaskList()
        Try
            Dim l As New List(Of String)
            Dim objDoc As XDocument = XDocument.Load(ProjectRoot)
            Dim objRoot As XElement = objDoc.Element("Project")
            Dim objFiles As XElement = objRoot.Element("Files")
            For Each objEl As XElement In objFiles.Elements("File")
                l.Add(objEl.Value)
            Next
            tbTaskList = New TaskListTab(String.Empty, l.ToArray())
        Catch ex As Exception
            tbTaskList = New TaskListTab(String.Empty, {})
        End Try
        If Language = "cs" Then
            tbTaskList.CommentPrefix = "//"
        Else
            tbTaskList.CommentPrefix = "'"
        End If
    End Sub

    Private Sub ConfigureErrorList()
        tbErrorList = New ErrorListTab
        Try
            Dim l As New List(Of String)
            Dim objDoc As XDocument = XDocument.Load(ProjectRoot)
            Dim objRoot As XElement = objDoc.Element("Project")
            Dim objFiles As XElement = objRoot.Element("Files")
            For Each objEl As XElement In objFiles.Elements("File")
                l.Add(objEl.Value)
            Next
            tbErrorList.Files = l.ToArray()
        Catch ex As Exception
            tbErrorList.Files = {}
        End Try
        Try
            Dim l As New List(Of String)
            Dim objDoc As XDocument = XDocument.Load(ProjectRoot)
            Dim objRoot As XElement = objDoc.Element("Project")
            Dim objFiles As XElement = objRoot.Element("References")
            For Each objEl As XElement In objFiles.Elements("Reference")
                l.Add(objEl.Value)
            Next
            tbErrorList.References = l.ToArray()
        Catch ex As Exception
            tbErrorList.References = {}
        End Try
        tbErrorList.Language = Language
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dispose()
    End Sub

    Private Sub tmrObjectExplorer_Tick(sender As Object, e As EventArgs) Handles tmrObjectExplorer.Tick
        If CurrentTB IsNot Nothing Then
            If Language = "cs" Then
                tbObjectExplorer.ReCSharpBuildObjectExplorer(CurrentTB.Text)
            Else
                tbObjectExplorer.ReBuildVBObjectExplorer(CurrentTB.Text)
            End If
        End If
    End Sub

    Private Sub tcMain_TabStripItemSelectionChanged(e As FarsiLibrary.Win.TabStripItemChangedEventArgs) Handles tcMain.TabStripItemSelectionChanged
        CurrentTB = CType(e.Item, CodeTab).TxtEditor
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        ElseIf e.KeyCode = Keys.S And e.Shift Then
            btnSaveAll.PerformClick()
        End If
    End Sub

    Private Sub btnOptions_Click(sender As Object, e As EventArgs) Handles btnOptions.Click
        frmOptions.ShowDialog()
    End Sub

#End Region

#Region "Build"

    Private Sub btnBuild_Click(sender As Object, e As EventArgs) Handles btnBuild.Click
        Build()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Build()
        If IO.File.Exists(ProjectDir & "bin\" & Path.GetFileNameWithoutExtension(ProjectRoot) & ".exe") Then
            Process.Start(ProjectDir & "bin\" & Path.GetFileNameWithoutExtension(ProjectRoot) & ".exe")
        End If
    End Sub

    Private Sub Build()
        btnSaveAll.PerformClick()
        Dim objCompiler As New Compile
        Dim objDoc As XDocument = XDocument.Load(ProjectRoot)
        Dim objRoot As XElement = objDoc.Element("Project")
        Dim objFiles As XElement = objRoot.Element("Files")
        Dim objReferences As XElement = objRoot.Element("References")
        Dim objOutput As XElement = objRoot.Element("Settings").Element("Output")
        Dim files As New List(Of String)
        objFiles.Elements("File").ToList().ForEach(Sub(x) files.Add(x.Value))
        Dim b As Boolean = Boolean.Parse(objOutput.Value)
        Dim l As New List(Of String)
        objReferences.Elements("Reference").ToList().ForEach(Sub(x) l.Add(x.Value))
        If Language = "cs" Then
            If b Then
                tbOutput.Print(objCompiler.CSharpCompile(ProjectDir & "bin\" & Path.GetFileNameWithoutExtension(ProjectRoot) & ".exe", files.ToArray(), b, l))
            Else
                tbOutput.Print(objCompiler.CSharpCompile(ProjectDir & "bin\" & Path.GetFileNameWithoutExtension(ProjectRoot) & ".dll", files.ToArray(), b, l))
            End If
        Else
            If b Then
                tbOutput.Print(objCompiler.VBCompile(ProjectDir & "bin\" & Path.GetFileNameWithoutExtension(ProjectRoot) & ".exe", files.ToArray(), b, l))
            Else
                tbOutput.Print(objCompiler.VBCompile(ProjectDir & "bin\" & Path.GetFileNameWithoutExtension(ProjectRoot) & ".dll", files.ToArray(), b, l))
            End If
        End If
    End Sub

#End Region

#Region "Files"

    Private Sub btnNewFile_Click(sender As Object, e As EventArgs) Handles btnNewFile.Click, btnNewContext.Click
        frmNewFile.ShowDialog()
        lstFiles.Items.Clear()
        LoadProjectFiles()
    End Sub

    Private Sub btnReferences_Click(sender As Object, e As EventArgs) Handles btnReferences.Click
        frmReferences_OLD.ShowDialog()
    End Sub

    Private Sub btnNewExisting_Click(sender As Object, e As EventArgs) Handles btnNewExisting.Click, btnExistingContext.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Code files (*." & Language & ")|*." & Language
        If ofd.ShowDialog() = DialogResult.OK Then

        End If
    End Sub

    Private Sub btnDeleteContext_Click(sender As Object, e As EventArgs) Handles btnDeleteContext.Click

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim objTab As Object = tcMain.SelectedItem
        objTab.Save()
    End Sub

    Private Sub btnSaveAll_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click
        For Each objTab As Object In tcMain.Items
            objTab.Save()
        Next
    End Sub

    Private Sub LoadProjectFiles()
        lstFiles.Clear()
        Try
            Dim objDoc As XDocument = XDocument.Load(ProjectRoot)
            Dim objRoot As XElement = objDoc.Element("Project")
            Dim objFiles As XElement = objRoot.Element("Files")
            For Each objEl As XElement In objFiles.Elements("File")
                Dim objItem As New ListViewItem
                objItem.Tag = objEl.Value
                objItem.Text = IO.Path.GetFileName(objEl.Value)
                objItem.ToolTipText = objItem.Tag
                lstFiles.Items.Add(objItem)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstFiles_DoubleClick(sender As Object, e As EventArgs) Handles lstFiles.SelectedIndexChanged
        If Not lstFiles.SelectedItems.Count = 0 Then
            Dim objItem As ListViewItem = lstFiles.SelectedItems(0)
            Dim objTab As CodeTab
            If Language.ToLower() = "cs" Then
                objTab = New CodeTab(FastColoredTextBoxNS.Language.CSharp, ProjectRoot)
            Else
                objTab = New CodeTab(FastColoredTextBoxNS.Language.VB, ProjectRoot)
            End If
            objTab.FilePath = objItem.Tag
            objTab.Init()
            tcMain.Items.Add(objTab)
            tcMain.SelectedItem = objTab
            CurrentTB.ClearUndo()
        End If
    End Sub

#End Region

#Region "Project"

    Private Sub btnNewProject_Click(sender As Object, e As EventArgs) Handles btnNewProject.Click
        frmNewProject.ShowDialog()
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim ofd As New OpenFileDialog
        ofd.Multiselect = False
        ofd.Filter = "Project files (*.proj)|*.proj"
        If ofd.ShowDialog() = DialogResult.OK Then
            ProjectDir = ofd.FileName.Substring(0, ofd.FileName.LastIndexOf("\")) & "\"
            ProjectRoot = ofd.FileName
            Dim objDoc As XDocument = XDocument.Load(ProjectRoot)
            Language = objDoc.Root.Element("Settings").Element("Language").Value
            LoadProjectFiles()
        End If
    End Sub

#End Region

#Region "CommandButtons"

    Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        CurrentTB.Undo()
    End Sub

    Private Sub btnRedo_Click(sender As Object, e As EventArgs) Handles btnRedo.Click
        CurrentTB.Redo()
    End Sub

    Private Sub btnComment_Click(sender As Object, e As EventArgs) Handles btnComment.Click
        CurrentTB.CommentSelected()
    End Sub

    Private Sub btnCut_Click(sender As Object, e As EventArgs) Handles btnCut.Click
        CurrentTB.Cut()
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        CurrentTB.Copy()
    End Sub

    Private Sub btnPaste_Click(sender As Object, e As EventArgs) Handles btnPaste.Click
        CurrentTB.Paste()
    End Sub

    Private Sub btnDeleteText_Click(sender As Object, e As EventArgs) Handles btnDeleteText.Click
        CurrentTB.Text.Remove(CurrentTB.SelectionStart, CurrentTB.SelectionLength)
    End Sub

#End Region

#Region "Views"

    Private Sub btnViewOutput_Click(sender As Object, e As EventArgs) Handles btnViewOutput.Click
        If Not tcTools.Items.Contains(tbOutput) Then
            tcTools.Items.Add(tbOutput)
        End If
    End Sub

    Private Sub btnTaskList_Click(sender As Object, e As EventArgs) Handles btnTaskList.Click
        If Not tcTools.Items.Contains(tbTaskList) Then
            tcTools.Items.Add(tbTaskList)
        End If
    End Sub

    Private Sub btnErrorList_Click(sender As Object, e As EventArgs) Handles btnErrorList.Click
        If Not tcTools.Items.Contains(tbErrorList) Then
            tcTools.Items.Add(tbErrorList)
        End If
    End Sub

#End Region

End Class