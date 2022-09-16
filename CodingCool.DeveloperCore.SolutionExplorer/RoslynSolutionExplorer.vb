Imports System.IO
Imports System.Windows.Forms
Imports CodingCool.DeveloperCore.Core
Imports Microsoft.CodeAnalysis

'TODO: .NET Core
'TODO: Nested files
'TODO: Add web projects and shared projects
'TODO: Check GAC for references
Public Class RoslynSolutionExplorer
    Inherits TreeView

    Private sln As Solution
    Private MSBuildSLN As Microsoft.Build.Construction.SolutionFile
    Private il As ImageList

    Public Sub New()
        il = New ImageList
        LabelEdit = True
        il.Images.Add("Solution", Icons.SolutionExplorer.My.Resources.Solution)
        il.Images.Add("Reference", Icons.SolutionExplorer.My.Resources.Reference)
        il.Images.Add("ReferenceFolder", Icons.SolutionExplorer.My.Resources.ReferenceFolder_Closed)
        il.Images.Add("VBProject", Icons.SolutionExplorer.VB.Projects.My.Resources.FullProject)
        il.Images.Add("VBFile", Icons.SolutionExplorer.VB.My.Resources.EmptyFile)
        il.Images.Add("Folder", Icons.SolutionExplorer.My.Resources.Folder_Closed)
        il.Images.Add("SolutionFolder", Icons.SolutionExplorer.My.Resources.Folder_Closed)
        il.Images.Add("Properties", Icons.SolutionExplorer.My.Resources.PropertyFolder_Closed)
        il.Images.Add("Settings", Icons.SolutionExplorer.My.Resources.Settings)
        il.Images.Add("Config", Icons.SolutionExplorer.My.Resources.ConfigFile)
        il.Images.Add("Json", Icons.SolutionExplorer.My.Resources.JsonFile)
        il.Images.Add("CSProject", Icons.SolutionExplorer.My.Resources.CSProject)
        il.Images.Add("CSFile", Icons.SolutionExplorer.My.Resources.CSFile)
        ImageList = il
    End Sub

#Region "Load"

    Public Sub LoadMSBuild(strSln As String)
        MSBuildSLN = Microsoft.Build.Construction.SolutionFile.Parse(strSln)
        Nodes.Clear()
        Dim nSolution As TreeNode = Nodes.Add(strSln, Path.GetFileNameWithoutExtension(strSln), "Solution", "Solution")
        For Each f As Microsoft.Build.Construction.ProjectInSolution In MSBuildSLN.ProjectsInOrder.Where(Function(x) x.ProjectType = Microsoft.Build.Construction.SolutionProjectType.SolutionFolder)
            Dim nParent As TreeNode
            If f.ParentProjectGuid = Nothing Then
                nParent = nSolution
            Else
                nParent = AddParent(f, nSolution)
            End If
            If Not Nodes.Find($"SLNFolder_{f.ProjectGuid}", True).Any Then nParent.Nodes.Add($"SLNFolder_{f.ProjectGuid}", f.ProjectName, "SolutionFolder", "SolutionFolder")
        Next
        For Each msproj In MSBuildSLN.ProjectsInOrder.Where(Function(x) x.ProjectType = Microsoft.Build.Construction.SolutionProjectType.KnownToBeMSBuildFormat).Select(Function(x) New With {.Project = Microsoft.Build.Evaluation.Project.FromFile(x.AbsolutePath, New Microsoft.Build.Definition.ProjectOptions), .ProjectInSLN = x})
            Dim proj As Microsoft.Build.Evaluation.Project = msproj.Project
            Dim nProject As TreeNode = If(Nodes.Find($"SLNFolder_{msproj.ProjectInSLN.ParentProjectGuid}", True).FirstOrDefault, nSolution).Nodes.Add($"Project_{proj.FullPath}", msproj.ProjectInSLN.ProjectName, GetIconName(Path.GetExtension(proj.FullPath)), GetIconName(Path.GetExtension(proj.FullPath)))
            nProject.Tag = proj
            Dim nProperties As TreeNode = nProject.Nodes.Add($"Properties_{proj.FullPath}", "Properties", "Properties", "Properties")
            Dim nReferences As TreeNode = nProject.Nodes.Add($"References_{proj.FullPath}", "References", "ReferenceFolder", "ReferenceFolder")
            Dim nAnalyzers As TreeNode = nReferences.Nodes.Add($"Analyzers_{proj.FullPath}", "Analyzers", "ReferenceFolder", "ReferenceFolder")
            For Each item As Microsoft.Build.Evaluation.ProjectItem In proj.Items
                If item.ItemType = "Reference" Then
                    Dim path As String = item.Metadata.FirstOrDefault(Function(x) x.Name = "HintPath")?.UnevaluatedValue
                    If path <> Nothing AndAlso File.Exists(path) Then
                        nReferences.Nodes.Add($"Reference_{proj.FullPath}_{path}", Reflection.Assembly.LoadFrom($"{proj.DirectoryPath}\{path}").GetName().Name, "Reference", "Reference")
                    Else
                        nReferences.Nodes.Add($"Reference_{proj.FullPath}_{item.EvaluatedInclude}", item.EvaluatedInclude, "Reference", "Reference")
                    End If
                ElseIf item.ItemType = "Compile" OrElse item.ItemType = "EmbeddedResource" OrElse item.ItemType = "None" Then
                    Dim lFolders As List(Of String) = item.UnevaluatedInclude.Replace("/", "\").Split("\").ToList
                    Dim strFile As String = lFolders(lFolders.Count - 1)
                    lFolders.RemoveAt(lFolders.Count - 1)
                    Dim nLastNode As TreeNode = nProject
                    Dim strPathId As String
                    If lFolders.Any AndAlso lFolders(0) = "My Project" Then
                        nLastNode = nProperties
                    Else
                        For Each f As String In lFolders
                            strPathId = $"{f}\"
                            Dim strKey As String = $"Folder_{proj.FullPath}_{strPathId}"
                            If Nodes.Find(strKey, True).Any Then
                                nLastNode = Nodes.Find(strKey, True).First
                            Else
                                nLastNode = nLastNode.Nodes.Add(strKey, f, "Folder", "Folder")
                            End If
                        Next
                    End If
                    nLastNode.Nodes.Add($"File_{proj.FullPath}_{item.UnevaluatedInclude}", strFile, GetIconName(Path.GetExtension($"{proj.DirectoryPath}{item.UnevaluatedInclude}")), GetIconName(Path.GetExtension($"{proj.DirectoryPath}{item.UnevaluatedInclude}"))).Tag = item
                ElseIf item.ItemType = "Folder" Then
                    Dim lFolders As List(Of String) = item.UnevaluatedInclude.Replace("/", "\").Split("\").ToList
                    lFolders.RemoveAt(lFolders.Count - 1)
                    Dim nLastNode As TreeNode = nProject
                    Dim strPathId As String
                    For Each f As String In lFolders
                        strPathId = $"{f}\"
                        Dim strKey As String = $"Folder_{proj.FullPath}_{strPathId}"
                        If Nodes.Find(strKey, True).Any Then
                            nLastNode = Nodes.Find(strKey, True).First
                        Else
                            nLastNode = nLastNode.Nodes.Add(strKey, f, "Folder", "Folder")
                        End If
                    Next
                ElseIf item.ItemType = "ProjectReference" Then
                    'Nodes.Add(item.UnevaluatedInclude)
                ElseIf item.ItemType = "Analyzer" Then
                    Dim path As String = item.UnevaluatedInclude
                    nAnalyzers.Nodes.Add($"Analyzer_{proj.FullPath}_{path}", Reflection.Assembly.LoadFrom($"{proj.DirectoryPath}\{path}").GetName().Name, "Reference", "Reference")
                End If
            Next
        Next
    End Sub

    Private Function AddParent(proj As Microsoft.Build.Construction.ProjectInSolution, nSolution As TreeNode) As TreeNode
        Dim nParent As TreeNode
        If proj.ParentProjectGuid = Nothing Then
            nParent = nSolution
        Else
            nParent = If(Nodes.Find($"SLNFolder_{proj.ParentProjectGuid}", True).FirstOrDefault, AddParent(MSBuildSLN.ProjectsInOrder.Where(Function(x) x.ProjectGuid = proj.ParentProjectGuid).First, nSolution))
        End If
        Return nParent.Nodes.Add($"SLNFolder_{proj.ProjectGuid}", proj.ProjectName, "SolutionFolder", "SolutionFolder")
    End Function

    Public Function GetIconName(ext As String) As String
        Select Case ext.ToLower
            Case ".vbproj"
                Return "VBProject"
            Case ".vb"
                Return "VBFile"
            Case ".myapp"
                Return "VBFile"
            Case ".config"
                Return "Config"
            Case ".json"
                Return "Json"
            Case ".csproj"
                Return "CSProject"
            Case ".cs"
                Return "CSFile"
            Case Else
                Return "Other"
        End Select
    End Function

    <Obsolete("Use MSBuild instead")>
    Public Shadows Sub LoadRoslyn(sln As Solution)
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
            Dim nSettings As TreeNode = nProject.Nodes.Add($"PRProperties_{proj.Id.Id}", "Properties", "Properties", "Properties")
            nSettings.Tag = SolutionItemType.Properties
            Dim nReferences As TreeNode = nProject.Nodes.Add($"Reference_{proj.Id.Id}", "References", "ReferenceFolder", "ReferenceFolder")
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
                    ElseIf f = "My Project" Then
                        nLastFolder = nSettings
                    Else
                        nLastFolder = nLastFolder.Nodes.Add(strKey, f, "Folder", "Folder")
                        nLastFolder.Tag = SolutionItemType.Folder
                    End If
                Next
                nLastFolder.Nodes.Add($"PRFile_{proj.Id.Id}_{doc.Id.Id}", doc.Name, "VBFile", "VBFile").Tag = SolutionItemType.File
            Next
            For Each doc As TextDocument In proj.AdditionalDocuments
                Dim nLastFolder As TreeNode = nProject
                For Each f As String In doc.Folders
                    Dim strKey As String = $"PRFolder_{proj.Id.Id}_{f}"
                    If Nodes.Find(strKey, True).Any Then
                        nLastFolder = Nodes.Find(strKey, True).First
                    ElseIf f = "My Project" Then
                        nLastFolder = nSettings
                    Else
                        nLastFolder = nLastFolder.Nodes.Add(strKey, f, "Folder", "Folder")
                        nLastFolder.Tag = SolutionItemType.Folder
                    End If
                Next
                nLastFolder.Nodes.Add($"PRFile_{proj.Id.Id}_{doc.Id.Id}", doc.Name).Tag = SolutionItemType.File
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
        If TypeOf e.Node.Tag Is Microsoft.Build.Evaluation.ProjectItem Then
            Dim item As Microsoft.Build.Evaluation.ProjectItem = e.Node.Tag
            RaiseEvent Open(Me, $"{item.Project.DirectoryPath}\{item.UnevaluatedInclude}")
        End If
    End Sub

    Public Event Open(sender As Object, e As String)

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