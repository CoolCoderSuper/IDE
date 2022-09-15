Imports System.Windows.Forms
Imports CodingCool.DeveloperCore.Core
Imports Microsoft.CodeAnalysis

'TODO: .NET Core
'TODO: My project stuff
'TODO: None code documents
'TODO: Nested files
Public Class RoslynSolutionExplorer
    Inherits TreeView

    Private sln As Solution
    Private il As ImageList

    Public Sub New()
        il = New ImageList
        LabelEdit = True
        il.Images.Add("Solution", Icons.SolutionExplorer.My.Resources.Solution)
        il.Images.Add("Reference", Icons.SolutionExplorer.My.Resources.Reference)
        il.Images.Add("VBProject", Icons.SolutionExplorer.VB.Projects.My.Resources.FullProject)
        il.Images.Add("VBFile", Icons.SolutionExplorer.VB.My.Resources.EmptyFile)
        il.Images.Add("Folder", Icons.SolutionExplorer.My.Resources.Folder_Closed)
        ImageList = il
    End Sub

#Region "Load"

    Public Shadows Sub Load(sln As Solution)
        Nodes.Clear()
        Me.sln = sln
        Dim nSolution As TreeNode = Nodes.Add("Solution", IO.Path.GetFileNameWithoutExtension(sln.FilePath), "Solution", "Solution")
        nSolution.Tag = SolutionItemType.Solution
        For Each proj As Project In sln.Projects
            Dim nProject As TreeNode
            If proj.Language = "Visual Basic" Then
                nProject = nSolution.Nodes.Add($"Project_{proj.Name}", proj.Name, "VBProject", "VBProject")
            ElseIf proj.Language = "C#" Then
                Continue For
            Else
                Continue For
            End If
            nProject.Tag = SolutionItemType.Project
            Dim nSettings As TreeNode = nProject.Nodes.Add($"PRSettings_{proj.Id.Id}_Settings", "My Project")
            nSettings.Tag = SolutionItemType.Properties
            Dim nReferences As TreeNode = nProject.Nodes.Add($"Reference_{proj.Id.Id}", "References", "Reference", "Reference")
            For Each ref As ProjectReference In proj.ProjectReferences
                nReferences.Nodes.Add($"PRReference_{proj.Id.Id}_{ref.ProjectId.Id}", sln.GetProject(ref.ProjectId).Name, "Reference", "Reference").Tag = SolutionItemType.Reference
            Next
            For Each ref As MetadataReference In proj.MetadataReferences
                nReferences.Nodes.Add($"PRReference_{proj.Id.Id}_{ref.Display}", Reflection.Assembly.LoadFrom(ref.Display).GetName().Name, "Reference", "Reference").Tag = SolutionItemType.Reference
            Next
            For Each doc As Document In proj.Documents
                Dim nLastFolder As TreeNode = nProject
                For Each f As String In doc.Folders
                    Dim strKey As String = $"PRFolder_{proj.Id.Id}_{f}"
                    If Nodes.Find(strKey, True).Any Then
                        nLastFolder = Nodes.Find(strKey, True).First
                    Else
                        nLastFolder = nLastFolder.Nodes.Add(strKey, f, "Folder", "Folder")
                        nLastFolder.Tag = SolutionItemType.Folder
                    End If
                Next
                nLastFolder.Nodes.Add($"PRFile_{proj.Id.Id}_{doc.Id.Id}", doc.Name, "VBFile", "VBFile").Tag = SolutionItemType.File
            Next
        Next
    End Sub

#End Region

#Region "Rename"

    Private Sub SolutionExplorer_BeforeLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles Me.BeforeLabelEdit
        'If TypeOf e.Node.Tag Is Reference OrElse e.Node.Name = $"{proj.Name}_References" OrElse e.Node.Name = $"{proj.Name}_ProjectSettings" Then
        '    e.CancelEdit = True
        'End If
    End Sub

    Private Sub SolutionExplorer_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles Me.AfterLabelEdit
        'Dim args As RenameItemEventArgs
        'If TypeOf e.Node.Tag Is File Then
        '    args = New RenameItemEventArgs(CType(e.Node.Tag, File).Path, e.Label, False)
        'ElseIf TypeOf e.Node.Tag Is Array Then
        '    args = New RenameItemEventArgs(CType(e.Node.Tag, Array)(1), e.Label, False)
        'Else
        '    args = New RenameItemEventArgs(e.Node.Tag.ToString(), e.Label, False)
        'End If
        'RaiseEvent Rename(Me, args)
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

    Private Sub RoslynSolutionExplorer_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Me.NodeMouseDoubleClick
        If e.Node.Tag = SolutionItemType.File Then
            Dim prId As ProjectId = ProjectId.CreateFromSerialized(Guid.Parse(e.Node.Name.Substring(e.Node.Name.IndexOf("_") + 1, e.Node.Name.Length - e.Node.Name.LastIndexOf("_") - 1)))
            RaiseEvent Open(Me, sln.GetDocument(DocumentId.CreateFromSerialized(prId, Guid.Parse(e.Node.Name.Substring(e.Node.Name.LastIndexOf("_") + 1)))))
        End If
    End Sub

    Public Event Open(sender As Object, e As Document)

    Public Event Rename(sender As Object, e As RenameItemEventArgs)

    Public Shadows Event Move(sender As Object, e As MoveItemEventArgs)

End Class

Public Enum SolutionItemType
    Solution
    Project
    Folder
    File
    Reference
    Properties
End Enum