Imports System.IO
Imports CodingCool.DeveloperCore.Core
Imports CodingCool.DeveloperCore.Editor
Imports CodingCool.DeveloperCore.Structure
Imports CodingCool.DeveloperCore.Views
Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.Emit

Public Class frmMain

#Region "Properties"

    Public Property CurrentSolution As Solution
    Public Property Projects As List(Of Microsoft.Build.Evaluation.Project)

#End Region

#Region "Variables"

    Private WithEvents CurrentTB As FastColoredTextBoxNS.FastColoredTextBox
    Private WithEvents tbOutput As OutputTab
    Private WithEvents tbTaskList As TaskListTab
    Private WithEvents tbErrorList As ErrorListTab
    Private WithEvents tbStructure As RoslynStructureTab

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
        ConfigureErrorList()
        tcTools.Items.Add(tbErrorList)
        'ConfigueTaskList()
        'tcTools.Items.Add(tbTaskList)
        tbOutput = New OutputTab
        tcTools.Items.Add(tbOutput)
        tbStructure = New RoslynStructureTab
        tcViews.TabPages.Add(tbStructure)
        tmrObjectExplorer.Start()
    End Sub

    Private Sub ConfigueTaskList()
        'Try
        '    Dim l As New List(Of String)
        '    Dim objDoc As XDocument = XDocument.Load(ProjectRoot)
        '    Dim objRoot As XElement = objDoc.Element("Project")
        '    Dim objFiles As XElement = objRoot.Element("Files")
        '    For Each objEl As XElement In objFiles.Elements("File")
        '        l.Add(objEl.Value)
        '    Next
        '    tbTaskList = New TaskListTab(String.Empty, l.ToArray())
        'Catch ex As Exception
        '    tbTaskList = New TaskListTab(String.Empty, {})
        'End Try
        'If Language = "cs" Then
        '    tbTaskList.CommentPrefix = "//"
        'Else
        '    tbTaskList.CommentPrefix = "'"
        'End If
    End Sub

    Private Sub ConfigureErrorList()
        tbErrorList = New ErrorListTab
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dispose()
    End Sub

    Private Sub tmrObjectExplorer_Tick(sender As Object, e As EventArgs) Handles tmrObjectExplorer.Tick
        If CurrentTB IsNot Nothing Then
            tbStructure.LoadVb(CurrentTB.Text)
        End If
    End Sub

    Private Sub tcMain_TabStripItemSelectionChanged(e As FarsiLibrary.Win.TabStripItemChangedEventArgs) Handles tcMain.TabStripItemSelectionChanged
        CurrentTB = CType(e.Item, CodeTab).TxtEditor
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        ElseIf e.KeyCode = Keys.S AndAlso e.Shift Then
            btnSaveAll.PerformClick()
        End If
    End Sub

    Private Sub btnOptions_Click(sender As Object, e As EventArgs) Handles btnOptions.Click
        frmOptions.ShowDialog()
    End Sub

#End Region

#Region "Build"

    Private Async Sub btnBuild_Click(sender As Object, e As EventArgs) Handles btnBuild.Click
        If Not Await Build() Then
            MessageBox.Show("Build failed!")
        End If
    End Sub

    Private Async Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If Not Await Build() Then
            MessageBox.Show("Build failed!")
        End If
        'TODO: Start the program
    End Sub

    Private Async Function Build() As Task(Of Boolean)
        btnSaveAll.PerformClick()
        Dim lResults As List(Of EmitResult) = (Await SolutionBuild.Build(CurrentSolution)).ToList
        tbErrorList.Errors.Clear()
        For Each res As EmitResult In lResults
            tbErrorList.LoadErrors(ErrorHelper.ConvertDiagnostic(res.Diagnostics.ToList))
        Next
        tbErrorList.Reload()
        Return lResults.All(Function(x) x.Success)
    End Function

#End Region

#Region "Files"

    Private Sub tbObjectExplorer_Naviagte(sender As Object, e As Integer) Handles tbStructure.Naviagte
        CurrentTB.SelectionStart = e
        CurrentTB.OnSelectionChanged()
    End Sub

    Private Sub btnNewFile_Click(sender As Object, e As EventArgs) Handles btnNewFile.Click, btnNewContext.Click
        frmNewFile.ShowDialog()
        lstFiles.Items.Clear()
    End Sub

    Private Sub btnReferences_Click(sender As Object, e As EventArgs) Handles btnReferences.Click
        frmReferences_OLD.ShowDialog()
    End Sub

    Private Sub btnNewExisting_Click(sender As Object, e As EventArgs) Handles btnNewExisting.Click, btnExistingContext.Click
        'Dim ofd As New OpenFileDialog
        'ofd.Filter = $"Code files (*.{Language})|*.{Language}"
        'If ofd.ShowDialog() = DialogResult.OK Then

        'End If
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

    Private Sub seExplorer_Open(sender As Object, e As String) Handles seExplorer.Open
        Dim objTab As CodeTab
        Dim strExt As String = Path.GetExtension(e)
        If strExt = ".cs" Then
            objTab = New CodeTab(FastColoredTextBoxNS.Language.CSharp, "")
        ElseIf strExt = ".vb" Then
            objTab = New CodeTab(FastColoredTextBoxNS.Language.VB, "")
        Else
            objTab = New CodeTab(FastColoredTextBoxNS.Language.Custom, "")
        End If
        objTab.FilePath = e
        objTab.Init()
        tcMain.Items.Add(objTab)
        tcMain.SelectedItem = objTab
        CurrentTB.ClearUndo()
    End Sub

#End Region

#Region "Project"

    Private Sub btnNewProject_Click(sender As Object, e As EventArgs) Handles btnNewProject.Click
        frmNewProject.ShowDialog()
    End Sub

    Private Async Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim ofd As New OpenFileDialog
        ofd.Multiselect = False
        ofd.Filter = "Solution files (*.sln)|*.sln"
        If ofd.ShowDialog() = DialogResult.OK Then
            CurrentSolution = Await SolutionParser.LoadSolution(ofd.FileName)
            seExplorer.LoadMSBuild(CurrentSolution.FilePath)
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