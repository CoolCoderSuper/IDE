Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports CodingCool.DeveloperCore.Core

'TODO: Get assembly name and show that instead
Public Class SolutionExplorer
    Inherits TreeView
    Dim proj As Project
    Dim il As ImageList

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
        r1.Path = "/Test"
        Dim r2 As New Reference
        r2.Path = "/Test1"
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

    Public Shadows Sub Load()
        Dim nProject As TreeNode = Nodes.Add(proj.Name, proj.Name, "VBProject", "VBProject")
        Dim nReferences As TreeNode
        nProject.Nodes.Add($"{proj.Name}_ProjectSettings", "My Project")
        nReferences = nProject.Nodes.Add($"{proj.Name}_References", "References", "RefFolderClosed", "RefFolderClosed")
        For Each r As Reference In proj.References
            nReferences.Nodes.Add($"{proj.Name}_References_{r.Path}", r.Path, "Reference", "Reference")
        Next
        For Each f As String In proj.Folders
            Dim lFolders As String() = f.Split("\")
            Dim nLastFolder As TreeNode = Nothing
            For Each sf As String In lFolders
                If nLastFolder Is Nothing Then
                    Dim strName As String = $"Folder_{sf}"
                    If Not NodeExists(nProject, strName) Then
                        nLastFolder = nProject.Nodes.Add(strName, sf, "FolderClosed", "FolderClosed")
                    Else
                        nLastFolder = GetNode(nProject, strName)
                    End If
                Else
                    Dim strName As String = $"{nLastFolder.Name}\{sf}"
                    If Not NodeExists(nProject, strName) Then
                        nLastFolder = nLastFolder.Nodes.Add(strName, sf, "FolderClosed", "FolderClosed")
                    End If
                End If
            Next
        Next
        For Each f As File In proj.Files
            If f.Path.Split("\").Length = 1 Then
                nProject.Nodes.Add($"File_{f.Path}", IO.Path.GetFileName(f.Path), "VBFile", "VBFile")
            Else
                Dim nFolder As TreeNode = GetNode(nProject, GetDirNodeName(f.Path))
                nFolder.Nodes.Add($"File_{f.Path}", IO.Path.GetFileName(f.Path), "VBFile", "VBFile")
            End If
        Next
    End Sub

    Private Function GetDirNodeName(strPath As String) As String
        Return "Folder_" & strPath.Split("\").GetDirName
    End Function

    Private Function GetNode(node As TreeNode, strKey As String) As TreeNode
        Return GetAllNodes(node).Where(Function(x) x.Name = strKey).FirstOrDefault
    End Function

    Private Function NodeExists(node As TreeNode, strKey As String) As Boolean
        Return GetAllNodes(node).Where(Function(x) x.Name = strKey).Count > 0
    End Function

    Private Function GetAllNodes(node As TreeNode) As IEnumerable(Of TreeNode)
        Return node.Nodes.Cast(Of TreeNode)().SelectMany(New Func(Of TreeNode, IEnumerable(Of TreeNode))(AddressOf Me.GetNodeBranch))
    End Function

    Private Iterator Function GetNodeBranch(ByVal node As TreeNode) As IEnumerable(Of TreeNode)
        Yield node
        For Each child As TreeNode In node.Nodes

            For Each childChild In Me.GetNodeBranch(child)
                Yield childChild
            Next
        Next
    End Function

    Private Sub SolutionExplorer_BeforeLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles Me.BeforeLabelEdit
        If TypeOf e.Node.Tag Is Reference OrElse e.Node.Name = $"{proj.Name}_References" OrElse e.Node.Name = $"{proj.Name}_ProjectSettings" Then
            e.CancelEdit = True
        End If
    End Sub

End Class

Module Ext

    <Extension()>
    Public Function GetDirName(obj As String()) As String
        Dim strResult As String = ""
        For i As Integer = 0 To obj.Length - 2
            strResult &= If(i = 0, obj(i), $"\{obj(i)}")
        Next
        Return strResult
    End Function

End Module