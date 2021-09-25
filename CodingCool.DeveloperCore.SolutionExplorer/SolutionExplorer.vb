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
        Dim r1 As New Reference
        r1.Path = "/Test"
        Dim r2 As New Reference
        r2.Path = "/Test1"
        proj.Name = "Test"
        proj.References = New List(Of Reference)
        proj.References.Add(r1)
        proj.References.Add(r2)
        LabelEdit = True
        il.Images.Add(Icons.SolutionExplorer.My.Resources.Solution)
        il.Images.Add(Icons.SolutionExplorer.My.Resources.ReferenceFolder_Closed)
        il.Images.Add(Icons.SolutionExplorer.My.Resources.ReferenceFolder_Open)
        il.Images.Add(Icons.SolutionExplorer.My.Resources.Reference)
        il.Images.Add(Icons.SolutionExplorer.VB.Projects.My.Resources.FullProject)
        ImageList = il
    End Sub

    Public Shadows Sub Load()
        Dim nProject As TreeNode = Nodes.Add(proj.Name, proj.Name, 4, 4)
        Dim nReferences As TreeNode
        nProject.Nodes.Add($"{proj.Name}_ProjectSettings", "My Project")
        nReferences = nProject.Nodes.Add($"{proj.Name}_References", "References", 1, 1)
        For Each r As Reference In proj.References
            nReferences.Nodes.Add($"{proj.Name}_References_{r.Path}", r.Path, 3, 3).Tag = r
        Next
    End Sub

    Private Sub SolutionExplorer_BeforeLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles Me.BeforeLabelEdit
        If TypeOf e.Node.Tag Is Reference OrElse e.Node.Name = $"{proj.Name}_References" OrElse e.Node.Name = $"{proj.Name}_ProjectSettings" Then
            e.CancelEdit = True
        End If
    End Sub
End Class
