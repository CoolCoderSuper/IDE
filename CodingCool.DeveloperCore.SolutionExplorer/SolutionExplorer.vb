Imports CodingCool.DeveloperCore.Core
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
'TODO: Add solution loop to load
Public Class SolutionExplorer
    Inherits TreeView
    Private proj As Project
    Private il As ImageList

    Public Sub New()
        il = New ImageList
        proj = New Project
        proj.Folders = New List(Of String) From {
           "Test1\Hello",
           "Test2\Test\Test",
           "Test1\Test"
        }
        Dim f1 As New File
        f1.Path = "Test1\Sample.vb"
        Dim f2 As New File
        f2.Path = "Test1\Hello\Sample.vb"
        Dim f3 As New File
        f3.Path = "Test1\Test\Sample.vb"
        Dim f4 As New File
        f4.Path = "Test2\Sample.vb"
        Dim f5 As New File
        f5.Path = "Test2\Test\Sample.vb"
        Dim f6 As New File
        f6.Path = "Test2\Test\Test\Sample.vb"
        Dim f7 As New File
        f7.Path = "Sample.vb"
        proj.Files.Add(f1)
        proj.Files.Add(f2)
        proj.Files.Add(f3)
        proj.Files.Add(f4)
        proj.Files.Add(f5)
        proj.Files.Add(f6)
        proj.Files.Add(f7)
        Dim r1 As New Reference
        r1.Path = "C:\CodingCool\Code\Projects\DeveloperCore\DeveloperCore\bin\Debug\CodingCool.DeveloperCore.Core.dll"
        Dim r2 As New Reference
        r2.Path = "C:\CodingCool\Code\Projects\DeveloperCore\DeveloperCore\bin\Debug\CodingCool.Developer.WinForms.Designer.dll"
        proj.Name = "Test"
        proj.References.Add(r1)
        proj.References.Add(r2)
        LabelEdit = True
        il.Images.Add("Solution", Icons.SolutionExplorer.My.Resources.Solution)
        il.Images.Add("RefFolderClosed", Icons.SolutionExplorer.My.Resources.ReferenceFolder_Closed)
        il.Images.Add("Reference", Icons.SolutionExplorer.My.Resources.Reference)
        il.Images.Add("VBProject", Icons.SolutionExplorer.VB.Projects.My.Resources.FullProject)
        il.Images.Add("FolderClosed", Icons.SolutionExplorer.My.Resources.Folder_Closed)
        il.Images.Add("VBFile", Icons.SolutionExplorer.VB.My.Resources.EmptyFile)
        ImageList = il
    End Sub

#Region "Load"

    Public Shadows Sub Load()
        Dim strPRPath As String = String.Empty
        Dim nProject As TreeNode = Nodes.Add(proj.Name, proj.Name, "VBProject", "VBProject")
        nProject.Tag = {proj, strPRPath}
        Dim nReferences As TreeNode
        nProject.Nodes.Add($"{proj.Name}_ProjectSettings", "My Project")
        nReferences = nProject.Nodes.Add($"{proj.Name}_References", "References", "RefFolderClosed", "RefFolderClosed")
        For Each r As Reference In proj.References
            nReferences.Nodes.Add($"{proj.Name}_References_{r.Path}", r.GetName(), "Reference", "Reference").Tag = r
        Next
        For Each f As String In proj.Folders
            Dim lFolders As String() = f.Split("\")
            Dim nLastFolder As TreeNode = Nothing
            For Each sf As String In lFolders
                If nLastFolder Is Nothing Then
                    Dim strName As String = $"Folder_{sf}"
                    If Not NodeExists(nProject, strName) Then
                        nLastFolder = nProject.Nodes.Add(strName, sf, "FolderClosed", "FolderClosed")
                        nLastFolder.Tag = f
                    Else
                        nLastFolder = GetNode(nProject, strName)
                    End If
                Else
                    Dim strName As String = $"{nLastFolder.Name}\{sf}"
                    If Not NodeExists(nProject, strName) Then
                        nLastFolder = nLastFolder.Nodes.Add(strName, sf, "FolderClosed", "FolderClosed")
                        nLastFolder.Tag = f
                    End If
                End If
            Next
        Next
        For Each f As File In proj.Files
            If f.Path.Split("\").Length = 1 Then
                nProject.Nodes.Add($"File_{f.Path}", IO.Path.GetFileName(f.Path), "VBFile", "VBFile").Tag = f
            Else
                Dim nFolder As TreeNode = GetNode(nProject, GetDirNodeName(f.Path))
                nFolder.Nodes.Add($"File_{f.Path}", IO.Path.GetFileName(f.Path), "VBFile", "VBFile").Tag = f
            End If
        Next
    End Sub

#End Region

#Region "Rename"

    Private Sub SolutionExplorer_BeforeLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles Me.BeforeLabelEdit
        If TypeOf e.Node.Tag Is Reference OrElse e.Node.Name = $"{proj.Name}_References" OrElse e.Node.Name = $"{proj.Name}_ProjectSettings" Then
            e.CancelEdit = True
        End If
    End Sub

    Private Sub SolutionExplorer_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles Me.AfterLabelEdit
        Dim args As RenameItemEventArgs
        If TypeOf e.Node.Tag Is File Then
            args = New RenameItemEventArgs(CType(e.Node.Tag, File).Path, e.Label, False)
        ElseIf TypeOf e.Node.Tag Is Array Then
            args = New RenameItemEventArgs(CType(e.Node.Tag, Array)(1), e.Label, False)
        Else
            args = New RenameItemEventArgs(e.Node.Tag.ToString(), e.Label, False)
        End If
        RaiseEvent Rename(Me, args)
    End Sub

#End Region

#Region "Move"

    Private Sub SolutionExplorer_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles Me.ItemDrag
        If e.Button = MouseButtons.Left Then
            DoDragDrop(e.Item, DragDropEffects.Move)
        End If
    End Sub

    Private Sub SolutionExplorer_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub SolutionExplorer_DragOver(sender As Object, e As DragEventArgs) Handles Me.DragOver
        SelectedNode = GetNodeAt(PointToClient(New Drawing.Point(e.X, e.Y)))
    End Sub

#End Region

#Region "Nodes"

    Private Function GetNode(node As TreeNode, strKey As String) As TreeNode
        Return GetAllNodes(node).Where(Function(x) x.Name = strKey).FirstOrDefault()
    End Function

    Private Function NodeExists(node As TreeNode, strKey As String) As Boolean
        Return GetAllNodes(node).Where(Function(x) x.Name = strKey).Count() > 0
    End Function

    Private Function GetAllNodes(node As TreeNode) As IEnumerable(Of TreeNode)
        Return node.Nodes.Cast(Of TreeNode)().SelectMany(New Func(Of TreeNode, IEnumerable(Of TreeNode))(AddressOf GetNodeBranch))
    End Function

    Private Iterator Function GetNodeBranch(ByVal node As TreeNode) As IEnumerable(Of TreeNode)
        Yield node
        For Each child As TreeNode In node.Nodes

            For Each childChild In Me.GetNodeBranch(child)
                Yield childChild
            Next
        Next
    End Function

#End Region

#Region "Misc"

    Private Function GetDirNodeName(strPath As String) As String
        Return $"Folder_{strPath.Split("\").GetDirName()}"
    End Function

#End Region

    Public Event Rename(sender As Object, e As RenameItemEventArgs)

    Public Shadows Event Move(sender As Object, e As MoveItemEventArgs)

End Class

Friend Module Ext

    <Extension>
    Public Function GetDirName(obj As String()) As String
        Dim strResult As String = String.Empty
        For i As Integer = 0 To obj.Length - 2
            strResult &= If(i = 0, obj(i), $"\{obj(i)}")
        Next
        Return strResult
    End Function

    <Extension>
    Public Function GetName(obj As Reference) As String
        Return Reflection.Assembly.LoadFrom(obj.Path).GetName().Name
    End Function

End Module