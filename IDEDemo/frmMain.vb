Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmMain

#Region "Properties"
    Public Property Language As String = "vb"
    Public Property ProjectRoot As String = "C:\Users\User\Documents\Test\Test.proj"
    Public Property ProjectDir As String = "C:\Users\User\Documents\Test\"
    Public Property Output As Boolean = True
    Public Property ExplorerList As New List(Of ExplorerItem)
#End Region

#Region "Variables"
    WithEvents CurrentTB As FastColoredTextBoxNS.FastColoredTextBox
    WithEvents tbOutput As OutputTab
    Dim ilImages As ImageList
#End Region

#Region "Events"
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbSolution.BackColor = ColorTranslator.FromHtml("#8a8a88")
        lstFiles.BackColor = ColorTranslator.FromHtml("#8a8a88")
        lstFiles.ForeColor = Color.White
        tcTools.BackColor = ColorTranslator.FromHtml("#8a8a88")
        tcMain.BackColor = ColorTranslator.FromHtml("#8a8a88")
        tvObjectExplorer.BackColor = ColorTranslator.FromHtml("#8a8a88")
        tvObjectExplorer.ForeColor = Color.White
        BackColor = ColorTranslator.FromHtml("#888888")
        LoadProjectFiles()
        ilImages = New ImageList
        ilImages.Images.Add("Class", My.Resources.class_new)
        ilImages.Images.Add("Event", My.Resources.event_new)
        ilImages.Images.Add("Method", My.Resources.method_new)
        ilImages.Images.Add("Property", My.Resources.property_new)
        tvObjectExplorer.ImageList = ilImages
        tbOutput = New OutputTab
        tcTools.Items.Add(tbOutput)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dispose()
    End Sub

    Private Sub Code_Changed(sender As Object, e As FastColoredTextBoxNS.TextChangedEventArgs) Handles CurrentTB.TextChanged
        If Language = "cs" Then
            ReCSharpBuildObjectExplorer(CurrentTB.Text)
        Else
            ReBuildVBObjectExplorer(CurrentTB.Text)
        End If
    End Sub

    Private Sub tcMain_TabStripItemSelectionChanged(e As FarsiLibrary.Win.TabStripItemChangedEventArgs) Handles tcMain.TabStripItemSelectionChanged
        CurrentTB = CType(e.Item, CodeTab).txtEditor
        If Language = "cs" Then
            ReCSharpBuildObjectExplorer(CurrentTB.Text)
        Else
            ReBuildVBObjectExplorer(CurrentTB.Text)
        End If
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        ElseIf e.KeyCode = Keys.S And e.Shift Then
            btnSaveAll.PerformClick()
        End If
    End Sub
#End Region

#Region "Build"
    Private Sub btnBuild_Click(sender As Object, e As EventArgs) Handles btnBuild.Click
        Build()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Build()
        Process.Start(ProjectDir & "bin\" & Path.GetFileNameWithoutExtension(ProjectRoot) & ".exe")
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
        objFiles.Elements("File").ToList.ForEach(Sub(x) files.Add(x.Value))
        Dim b As Boolean = Boolean.Parse(objOutput.Value)
        Dim l As New List(Of String)
        objReferences.Elements("Reference").ToList.ForEach(Sub(x) files.Add(x.Value))
        If Language = "cs" Then
            If b Then
                tbOutput.Print(objCompiler.CSharpCompile(ProjectDir & "bin\" & Path.GetFileNameWithoutExtension(ProjectRoot) & ".exe", files.ToArray, b, l))
            Else
                tbOutput.Print(objCompiler.CSharpCompile(ProjectDir & "bin\" & Path.GetFileNameWithoutExtension(ProjectRoot) & ".dll", files.ToArray, b, l))
            End If
        Else
            If b Then
                tbOutput.Print(objCompiler.VBCompile(ProjectDir & "bin\" & Path.GetFileNameWithoutExtension(ProjectRoot) & ".exe", files.ToArray, b, l))
            Else
                tbOutput.Print(objCompiler.VBCompile(ProjectDir & "bin\" & Path.GetFileNameWithoutExtension(ProjectRoot) & ".dll", files.ToArray, b, l))
            End If
        End If
    End Sub
#End Region

#Region "Object Explorer"
    Private Sub ReCSharpBuildObjectExplorer(text As String)
        Try
            Dim list As List(Of ExplorerItem) = New List(Of ExplorerItem)()
            Dim lastClassIndex As Integer = -1
            Dim regex As Regex = New Regex("^(?<range>[\w\s]+\b(class|struct|enum|interface)\s+[\w<>,\s]+)|^\s*(public|private|internal|protected)[^\n]+(\n?\s*{|;)?", RegexOptions.Multiline)
            For Each r As Match In regex.Matches(text)
                Try
                    Dim s As String = r.Value
                    Dim i As Integer = s.IndexOfAny(New Char() {"=", "{", ";"})
                    If i >= 0 Then
                        s = s.Substring(0, i)
                    End If
                    s = s.Trim()
                    Dim item As ExplorerItem = New ExplorerItem() With {.title = s, .position = r.Index}
                    If Regex.IsMatch(item.title, "\b(class|struct|enum|interface)\b") Then
                        item.title = item.title.Substring(item.title.LastIndexOf(" ")).Trim()
                        item.type = ExplorerItemType.[Class]
                        list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ExplorerItemComparer())
                        lastClassIndex = list.Count
                    Else
                        If item.title.Contains(" event ") Then
                            Dim ii As Integer = item.title.LastIndexOf(" ")
                            item.title = item.title.Substring(ii).Trim()
                            item.type = ExplorerItemType.[Event]
                        Else
                            If item.title.Contains("(") Then
                                Dim parts As String() = item.title.Split(New Char() {"("})
                                item.title = parts(0).Substring(parts(0).LastIndexOf(" ")).Trim() + "(" + parts(1)
                                item.type = ExplorerItemType.Method
                            Else
                                If item.title.EndsWith("]") Then
                                    Dim parts As String() = item.title.Split(New Char() {"["})
                                    If parts.Length < 2 Then
                                        Continue For
                                    End If
                                    item.title = parts(0).Substring(parts(0).LastIndexOf(" ")).Trim() + "[" + parts(1)
                                    item.type = ExplorerItemType.Method
                                Else
                                    Dim ii As Integer = item.title.LastIndexOf(" ")
                                    item.title = item.title.Substring(ii).Trim()
                                    item.type = ExplorerItemType.[Property]
                                End If
                            End If
                        End If
                    End If
                    list.Add(item)
                Catch ex_2BF As Exception
                    Console.WriteLine(ex_2BF)
                End Try
            Next
            list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ExplorerItemComparer())
            MyBase.BeginInvoke(Sub()
                                   ExplorerList = list
                               End Sub)
            LoadObject()
        Catch ex_332 As Exception
            Console.WriteLine(ex_332)
        End Try
    End Sub

    Private Sub ReBuildVBObjectExplorer(text As String)
        Try
            Dim list As List(Of ExplorerItem) = New List(Of ExplorerItem)()
            Dim lastClassIndex As Integer = -1
            Dim lLines As List(Of String) = text.Split(vbCrLf).ToList
            Dim bDead As Boolean
            For j As Integer = 0 To lLines.Count - 1 Step 1
                Try
                    Dim bSkip As Boolean = False
                    Dim s As String = lLines(j)
                    Dim i As Integer = s.IndexOfAny(New Char() {"=", vbCrLf, vbCrLf})
                    If i >= 0 Then
                        s = s.Substring(0, i)
                    End If
                    s = s.Trim()
                    ' Make sure that it is not private to method or end statement or a comment or a none supported line
                    If Not s.Length = 0 AndAlso s(0) = "'" Then
                        Continue For
                    End If
                    If Not Regex.IsMatch(s, "(?i)\b(class|structure|enum|interface|module|sub|function|property|event|operator|private|public|shadows|shared|dim|const|friend|protected|readonly)\b") Then
                        Continue For
                    End If
                    If bDead = False AndAlso Regex.IsMatch(s, "(?i)\b(sub|function|operator|custom\sevent)\b") Then
                        bSkip = True
                        bDead = True
                    End If
                    If bSkip = False AndAlso bDead = True Then
                        If Regex.IsMatch(s, "(?i)\b(end\ssub|end\sfunction|end\soperator|end\sevent)\b") Then
                            bDead = False
                        End If
                        Continue For
                    End If
                    If Regex.IsMatch(s, "(?i)\b(end\sclass|end\sstructure|end\sinterface|end\senum|end\smodule)\b") Then
                        Continue For
                    End If
                    ' Load the item
                    Dim item As ExplorerItem = New ExplorerItem() With {.title = s, .position = j}
                    If Regex.IsMatch(item.title, "(?i)\b(class|structure|enum|interface|module)\b") Then
                        item.title = item.title.Substring(item.title.LastIndexOf(" ")).Trim()
                        item.type = ExplorerItemType.[Class]
                        list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ExplorerItemComparer())
                        lastClassIndex = list.Count
                    Else
                        If Regex.IsMatch(item.title, "(?i)\b(operator|property|function|event|private|public|shadows|shared|dim|const|friend|protected|readonly)\b") Then
                            If Regex.IsMatch(item.title, "(?i)\b(\sproperty\s|property\s)\b") Then
                                item.type = ExplorerItemType.Property
                                Dim ii As Integer = item.title.ToLower.LastIndexOf(" property ")
                                If ii < 0 Then
                                    ii = item.title.ToLower.LastIndexOf("property ")
                                End If
                                item.title = item.title.Substring(ii).Trim()
                            ElseIf Regex.IsMatch(item.title, "(?i)\b(\sfunction\s|function\s)\b") Then
                                item.type = ExplorerItemType.Method
                                Dim ii As Integer = item.title.ToLower.LastIndexOf(" function ")
                                If ii < 0 Then
                                    ii = item.title.ToLower.LastIndexOf("function ")
                                End If
                                item.title = item.title.Substring(ii).Trim()
                            ElseIf Regex.IsMatch(item.title, "(?i)\b(\sevent\s|event\s)\b") Then
                                item.type = ExplorerItemType.Event
                                Dim ii As Integer = item.title.ToLower.LastIndexOf(" event ")
                                If ii < 0 Then
                                    ii = item.title.ToLower.LastIndexOf("event ")
                                End If
                                item.title = item.title.Substring(ii).Trim()
                            ElseIf Regex.IsMatch(item.title, "(?i)\b(\soperator\s)\b") Then
                                item.type = ExplorerItemType.Operator
                                Dim ii As Integer = item.title.ToLower.LastIndexOf(" operator ")
                                If ii < 0 Then
                                    ii = item.title.ToLower.LastIndexOf("operator ")
                                End If
                                item.title = item.title.Substring(ii).Trim()
                            ElseIf Regex.IsMatch(item.title, "(?i)\b(private|public|shadows|shared|dim|const|friend|protected|readonly)\b") Then
                                item.type = ExplorerItemType.Variable
                                item.title = item.title.Trim
                            End If
                        End If
                        If Regex.IsMatch(item.title, "(?i)\b(\ssub\s|sub\s)\b") Then
                            item.type = ExplorerItemType.Method
                            Dim ii As Integer = item.title.ToLower.LastIndexOf(" sub ")
                            If ii < 0 Then
                                ii = item.title.ToLower.LastIndexOf("sub ")
                            End If
                            item.title = item.title.Substring(ii).Trim()
                        End If
                    End If
                    ' Make sure it is not blank
                    If item.title.Trim = "" Then
                        Continue For
                    End If
                    list.Add(item)
                Catch ex_2BF As Exception

                End Try
            Next
            list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ExplorerItemComparer())
            MyBase.BeginInvoke(Sub()
                                   ExplorerList = list
                               End Sub)
            LoadObject()
        Catch ex_332 As Exception

        End Try
    End Sub

    Private Sub LoadObject()
        tvObjectExplorer.Nodes.Clear()
        Dim lastNode As New TreeNode
        For Each item As ExplorerItem In ExplorerList
            Select Case item.type
                Case ExplorerItemType.Class
                    Dim node As New TreeNode
                    node.Text = item.title
                    node.ImageKey = "Class"
                    node.SelectedImageKey = "Class"
                    tvObjectExplorer.Nodes.Add(node)
                    lastNode = node
                Case ExplorerItemType.Variable
                    Dim node As New TreeNode
                    node.Text = item.title
                    node.ImageKey = "Property"
                    node.SelectedImageKey = "Property"
                    lastNode.Nodes.Add(node)
                Case ExplorerItemType.Property
                    Dim node As New TreeNode
                    node.Text = item.title
                    node.ImageKey = "Property"
                    node.SelectedImageKey = "Property"
                    lastNode.Nodes.Add(node)
                Case ExplorerItemType.Method
                    Dim node As New TreeNode
                    node.Text = item.title
                    node.ImageKey = "Method"
                    node.SelectedImageKey = "Method"
                    lastNode.Nodes.Add(node)
                Case ExplorerItemType.Event
                    Dim node As New TreeNode
                    node.Text = item.title
                    node.ImageKey = "Event"
                    node.SelectedImageKey = "Event"
                    lastNode.Nodes.Add(node)
                Case ExplorerItemType.Operator
                    Dim node As New TreeNode
                    node.Text = item.title
                    node.ImageKey = "Property"
                    node.SelectedImageKey = "Property"
                    lastNode.Nodes.Add(node)
            End Select
        Next
    End Sub
#End Region

#Region "Files"
    Private Sub btnNewFile_Click(sender As Object, e As EventArgs) Handles btnNewFile.Click, btnNewContext.Click
        frmNewFile.ShowDialog()
        lstFiles.Items.Clear()
        LoadProjectFiles()
    End Sub

    Private Sub btnReferences_Click(sender As Object, e As EventArgs) Handles btnReferences.Click
        frmReferences.ShowDialog()
    End Sub

    Private Sub btnNewExisting_Click(sender As Object, e As EventArgs) Handles btnNewExisting.Click, btnExistingContext.Click

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
            If Language.ToLower = "cs" Then
                objTab = New CodeTab(FastColoredTextBoxNS.Language.CSharp)
            Else
                objTab = New CodeTab(FastColoredTextBoxNS.Language.VB)
            End If
            objTab.FilePath = objItem.Tag
            objTab.Init()
            tcMain.Items.Add(objTab)
            tcMain.SelectedItem = objTab
            If Language = "cs" Then
                ReCSharpBuildObjectExplorer(CurrentTB.Text)
            Else
                ReBuildVBObjectExplorer(CurrentTB.Text)
            End If
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
        If ofd.ShowDialog = DialogResult.OK Then
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

#End Region

#Region "Views"
    Private Sub btnViewOutput_Click(sender As Object, e As EventArgs) Handles btnViewOutput.Click
        If Not tcTools.Items.Contains(tbOutput) Then
            tcTools.Items.Add(tbOutput)
        End If
    End Sub

    Private Sub tcTools_TabStripItemSelectionChanged(e As FarsiLibrary.Win.TabStripItemChangedEventArgs) Handles tcTools.TabStripItemSelectionChanged

    End Sub

    Private Sub tcViews_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcViews.SelectedIndexChanged

    End Sub
#End Region

End Class