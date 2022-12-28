Imports System.IO
Imports System.Windows.Forms
Imports CodingCool.DeveloperCore.Core

'TODO: Add shared projects
'TODO: Assembly metadata, InternalsVisibleTo, BaseApplicationManifest, CodeAnalysisImport, Import, NativeReference, conditions, custom tools
'TODO: Hide unsupported buttons
'TODO: Manage project and solution folders
'TODO: Project menu
'TODO: Solution menu
'TODO: Solution items
'TODO: Package references
Public Class MSBuildSolutionExplorer
    Inherits TreeView

    'Private sln As Solution
    Public Property MSBuildSLN As Microsoft.Build.Construction.SolutionFile

    Public Property Projects As Microsoft.Build.Evaluation.ProjectCollection

#Region "Components"

    Private il As ImageList
    Private menu As ContextMenuStrip
    Private WithEvents btnNewFile As New ToolStripMenuItem
    Private WithEvents btnExistingFile As New ToolStripMenuItem
    Private WithEvents btnNewFolder As New ToolStripMenuItem
    Private WithEvents btnDelete As New ToolStripMenuItem
    Private WithEvents btnExclude As New ToolStripMenuItem
    Private WithEvents btnCopy As New ToolStripMenuItem
    Private WithEvents btnCut As New ToolStripMenuItem
    Private WithEvents btnPaste As New ToolStripMenuItem
    Private WithEvents btnCopyPath As New ToolStripMenuItem
    Private WithEvents btnOpenInExplorer As New ToolStripMenuItem
    Private WithEvents btnOpen As New ToolStripMenuItem
    Private WithEvents btnOpenWith As New ToolStripMenuItem
    Private WithEvents btnRename As New ToolStripMenuItem

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
        menu = New ContextMenuStrip
        ContextMenuStrip = menu
        btnNewFile = New ToolStripMenuItem("Add File")
        btnExistingFile = New ToolStripMenuItem("Add Existing File")
        btnNewFolder = New ToolStripMenuItem("Add Folder")
        btnDelete = New ToolStripMenuItem("Delete")
        btnExclude = New ToolStripMenuItem("Exclude")
        btnCopy = New ToolStripMenuItem("Copy")
        btnCut = New ToolStripMenuItem("Cut")
        btnPaste = New ToolStripMenuItem("Paste")
        btnCopyPath = New ToolStripMenuItem("Copy Path")
        btnOpenInExplorer = New ToolStripMenuItem("Open In File Explorer")
        btnOpen = New ToolStripMenuItem("Open")
        btnOpenWith = New ToolStripMenuItem("Open With")
        btnRename = New ToolStripMenuItem("Rename")
        menu.Items.Add(btnOpen)
        menu.Items.Add(btnOpenWith)
        menu.Items.Add(btnOpenInExplorer)
        menu.Items.Add(New ToolStripSeparator)
        menu.Items.Add(btnNewFile)
        menu.Items.Add(btnExistingFile)
        menu.Items.Add(btnNewFolder)
        menu.Items.Add(New ToolStripSeparator)
        menu.Items.Add(btnCopy)
        menu.Items.Add(btnPaste)
        menu.Items.Add(btnCut)
        menu.Items.Add(btnDelete)
        menu.Items.Add(btnExclude)
        menu.Items.Add(btnRename)
        menu.Items.Add(btnCopyPath)
    End Sub

#End Region

#Region "Load"

    Public Sub LoadMSBuild(strSln As String)
        Projects?.UnloadAllProjects()
        MSBuildSLN = Microsoft.Build.Construction.SolutionFile.Parse(strSln)
        Projects = Nothing
        Nodes.Clear()
        Dim nSolution As TreeNode = Nodes.Add(strSln, Path.GetFileNameWithoutExtension(strSln), "Solution", "Solution")
        For Each f As Microsoft.Build.Construction.ProjectInSolution In MSBuildSLN.ProjectsInOrder.Where(Function(x) x.ProjectType = Microsoft.Build.Construction.SolutionProjectType.SolutionFolder)
            Dim nParent As TreeNode = If(f.ParentProjectGuid = Nothing, nSolution, AddParent(f, nSolution))
            If Not Nodes.Find($"SLNFolder_{f.ProjectGuid}", True).Any Then nParent.Nodes.Add($"SLNFolder_{f.ProjectGuid}", f.ProjectName, "SolutionFolder", "SolutionFolder")
        Next
        For Each msproj In MSBuildSLN.ProjectsInOrder.Where(Function(x) x.ProjectType = Microsoft.Build.Construction.SolutionProjectType.KnownToBeMSBuildFormat).Select(Function(x) New With {.Project = Microsoft.Build.Evaluation.Project.FromFile(x.AbsolutePath, New Microsoft.Build.Definition.ProjectOptions), .ProjectInSLN = x})
            Dim proj As Microsoft.Build.Evaluation.Project = msproj.Project
            If Projects Is Nothing Then Projects = proj.ProjectCollection
            Dim nProject As TreeNode = If(Nodes.Find($"SLNFolder_{msproj.ProjectInSLN.ParentProjectGuid}", True).FirstOrDefault, nSolution).Nodes.Add($"Project_{proj.FullPath}", msproj.ProjectInSLN.ProjectName, GetIconName(Path.GetExtension(proj.FullPath)), GetIconName(Path.GetExtension(proj.FullPath)))
            nProject.Tag = proj
            Dim nProperties As TreeNode = nProject.Nodes.Add($"Properties_{proj.FullPath}", "Properties", "Properties", "Properties")
            Dim nReferences As TreeNode = nProject.Nodes.Add($"References_{proj.FullPath}", "References", "ReferenceFolder", "ReferenceFolder")
            Dim nAnalyzers As TreeNode = nReferences.Nodes.Add($"Analyzers_{proj.FullPath}", "Analyzers", "ReferenceFolder", "ReferenceFolder")
            For Each item As Microsoft.Build.Evaluation.ProjectItem In proj.Items.Where(Function(x) Not x.Metadata.Any(Function(y) y.Name = "DependentUpon"))
                If item.ItemType = "Reference" Then
                    Dim path As String = item.GetMetadataValue("HintPath")
                    If path <> "" AndAlso File.Exists(path) Then
                        nReferences.Nodes.Add($"Reference_{proj.FullPath}_{path}", Reflection.AssemblyName.GetAssemblyName(If(IO.Path.IsPathRooted(path), path, $"{proj.DirectoryPath}\{path}")).Name, "Reference", "Reference").Tag = item
                    Else
                        nReferences.Nodes.Add($"Reference_{proj.FullPath}_{item.EvaluatedInclude}", New Reflection.AssemblyName(item.EvaluatedInclude).Name, "Reference", "Reference").Tag = item
                    End If
                ElseIf item.ItemType = "COMReference" Then
                    nReferences.Nodes.Add($"Reference_{proj.FullPath}_{item.EvaluatedInclude}", item.EvaluatedInclude, "Reference", "Reference")
                ElseIf item.ItemType = "Compile" OrElse item.ItemType = "EmbeddedResource" OrElse item.ItemType = "None" OrElse item.ItemType = "Content" Then
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
                        nLastNode = If(Nodes.Find(strKey, True).Any, Nodes.Find(strKey, True).First, nLastNode.Nodes.Add(strKey, f, "Folder", "Folder"))
                        If nLastNode.Tag IsNot Nothing Then nLastNode.Tag = item
                    Next
                ElseIf item.ItemType = "ProjectReference" Then
                    nReferences.Nodes.Add($"Reference_{proj.FullPath}_{item.UnevaluatedInclude}", Path.GetFileNameWithoutExtension(If(Path.IsPathRooted(item.UnevaluatedInclude), item.UnevaluatedInclude, $"{proj.DirectoryPath}\{item.UnevaluatedInclude}")), "Reference", "Reference").Tag = item
                ElseIf item.ItemType = "Analyzer" Then
                    Dim path As String = item.UnevaluatedInclude
                    nAnalyzers.Nodes.Add($"Analyzer_{proj.FullPath}_{path}", Reflection.AssemblyName.GetAssemblyName(If(IO.Path.IsPathRooted(path), path, $"{proj.DirectoryPath}\{path}")).Name, "Reference", "Reference").Tag = item
                End If
            Next
            For Each item As Microsoft.Build.Evaluation.ProjectItem In proj.Items.Where(Function(x) x.Metadata.Any(Function(y) y.Name = "DependentUpon"))
                Try
                    Dim lFolders As List(Of String) = item.UnevaluatedInclude.Replace("/", "\").Split("\").ToList
                    Dim strFile As String = lFolders(lFolders.Count - 1)
                    Dim data As Microsoft.Build.Evaluation.ProjectMetadata = item.Metadata.First(Function(x) x.Name = "DependentUpon")
                    Dim strKey As String = $"File_{proj.FullPath}_{Path.GetDirectoryName(item.UnevaluatedInclude)}\{data.UnevaluatedValue}"
                    Dim nLastNode As TreeNode = Nodes.Find(strKey, True).First
                    nLastNode.Nodes.Add($"File_{proj.FullPath}_{item.UnevaluatedInclude}", strFile, GetIconName(Path.GetExtension($"{proj.DirectoryPath}{item.UnevaluatedInclude}")), GetIconName(Path.GetExtension($"{proj.DirectoryPath}{item.UnevaluatedInclude}"))).Tag = item
                Catch ex As Exception

                End Try
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

    Private Function GetIconName(ext As String) As String
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

    '<Obsolete("Use MSBuild instead")>
    'Public Shadows Sub LoadRoslyn(sln As Solution)
    '    Nodes.Clear()
    '    Me.sln = sln
    '    Dim nSolution As TreeNode = Nodes.Add("Solution", IO.Path.GetFileNameWithoutExtension(sln.FilePath), "Solution", "Solution")
    '    nSolution.Tag = SolutionItemType.Solution
    '    For Each proj As Project In sln.Projects
    '        Dim nProject As TreeNode
    '        If proj.Language = "Visual Basic" Then
    '            nProject = nSolution.Nodes.Add($"Project_{proj.Name}", proj.Name, "VBProject", "VBProject")
    '        ElseIf proj.Language = "C#" Then
    '            Continue For
    '        Else
    '            Continue For
    '        End If
    '        nProject.Tag = SolutionItemType.Project
    '        Dim nSettings As TreeNode = nProject.Nodes.Add($"PRProperties_{proj.Id.Id}", "Properties", "Properties", "Properties")
    '        nSettings.Tag = SolutionItemType.Properties
    '        Dim nReferences As TreeNode = nProject.Nodes.Add($"Reference_{proj.Id.Id}", "References", "ReferenceFolder", "ReferenceFolder")
    '        For Each ref As ProjectReference In proj.ProjectReferences
    '            nReferences.Nodes.Add($"PRReference_{proj.Id.Id}_{ref.ProjectId.Id}", sln.GetProject(ref.ProjectId).Name, "Reference", "Reference").Tag = SolutionItemType.Reference
    '        Next
    '        For Each ref As MetadataReference In proj.MetadataReferences
    '            nReferences.Nodes.Add($"PRReference_{proj.Id.Id}_{ref.Display}", Reflection.Assembly.LoadFrom(ref.Display).GetName().Name, "Reference", "Reference").Tag = SolutionItemType.Reference
    '        Next
    '        For Each doc As Document In proj.Documents
    '            Dim nLastFolder As TreeNode = nProject
    '            For Each f As String In doc.Folders
    '                Dim strKey As String = $"PRFolder_{proj.Id.Id}_{f}"
    '                If Nodes.Find(strKey, True).Any Then
    '                    nLastFolder = Nodes.Find(strKey, True).First
    '                ElseIf f = "My Project" Then
    '                    nLastFolder = nSettings
    '                Else
    '                    nLastFolder = nLastFolder.Nodes.Add(strKey, f, "Folder", "Folder")
    '                    nLastFolder.Tag = SolutionItemType.Folder
    '                End If
    '            Next
    '            nLastFolder.Nodes.Add($"PRFile_{proj.Id.Id}_{doc.Id.Id}", doc.Name, "VBFile", "VBFile").Tag = SolutionItemType.File
    '        Next
    '        For Each doc As TextDocument In proj.AdditionalDocuments
    '            Dim nLastFolder As TreeNode = nProject
    '            For Each f As String In doc.Folders
    '                Dim strKey As String = $"PRFolder_{proj.Id.Id}_{f}"
    '                If Nodes.Find(strKey, True).Any Then
    '                    nLastFolder = Nodes.Find(strKey, True).First
    '                ElseIf f = "My Project" Then
    '                    nLastFolder = nSettings
    '                Else
    '                    nLastFolder = nLastFolder.Nodes.Add(strKey, f, "Folder", "Folder")
    '                    nLastFolder.Tag = SolutionItemType.Folder
    '                End If
    '            Next
    '            nLastFolder.Nodes.Add($"PRFile_{proj.Id.Id}_{doc.Id.Id}", doc.Name).Tag = SolutionItemType.File
    '        Next
    '    Next
    'End Sub

#End Region

    Private Sub RoslynSolutionExplorer_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Me.NodeMouseDoubleClick
        If TypeOf e.Node.Tag Is Microsoft.Build.Evaluation.ProjectItem Then
            Dim item As Microsoft.Build.Evaluation.ProjectItem = e.Node.Tag
            If item.ItemType = "Compile" OrElse item.ItemType = "EmbeddedResource" OrElse item.ItemType = "None" OrElse item.ItemType = "Content" Then
                RaiseEvent Open(Me, $"{item.Project.DirectoryPath}\{item.UnevaluatedInclude}")
            End If
        End If
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        If SelectedNode IsNot Nothing AndAlso TypeOf SelectedNode.Tag Is Microsoft.Build.Evaluation.ProjectItem Then
            Dim item As Microsoft.Build.Evaluation.ProjectItem = SelectedNode.Tag
            If item.ItemType = "Compile" OrElse item.ItemType = "EmbeddedResource" OrElse item.ItemType = "None" OrElse item.ItemType = "Content" Then
                RaiseEvent Open(Me, $"{item.Project.DirectoryPath}\{item.UnevaluatedInclude}")
            End If
        End If
    End Sub

    Private Sub btnOpenInExplorer_Click(sender As Object, e As EventArgs) Handles btnOpenInExplorer.Click
        If SelectedNode IsNot Nothing AndAlso TypeOf SelectedNode.Tag Is Microsoft.Build.Evaluation.ProjectItem Then
            Dim item As Microsoft.Build.Evaluation.ProjectItem = SelectedNode.Tag
            If item.ItemType = "Compile" OrElse item.ItemType = "EmbeddedResource" OrElse item.ItemType = "None" OrElse item.ItemType = "Content" Then
                RaiseEvent Open(Me, Path.GetDirectoryName($"{item.Project.DirectoryPath}\{item.UnevaluatedInclude}"))
            End If
        End If
    End Sub

    Private Sub btnCopyPath_Click(sender As Object, e As EventArgs) Handles btnCopyPath.Click
        If SelectedNode IsNot Nothing AndAlso TypeOf SelectedNode.Tag Is Microsoft.Build.Evaluation.ProjectItem Then
            Dim item As Microsoft.Build.Evaluation.ProjectItem = SelectedNode.Tag
            If item.ItemType = "Compile" OrElse item.ItemType = "EmbeddedResource" OrElse item.ItemType = "None" OrElse item.ItemType = "Content" Then
                Clipboard.SetText($"{item.Project.DirectoryPath}\{item.UnevaluatedInclude}")
            End If
        End If
    End Sub

    Private Sub btnExclude_Click(sender As Object, e As EventArgs) Handles btnExclude.Click
        If SelectedNode IsNot Nothing AndAlso TypeOf SelectedNode.Tag Is Microsoft.Build.Evaluation.ProjectItem Then
            Dim item As Microsoft.Build.Evaluation.ProjectItem = SelectedNode.Tag
            If item.ItemType = "Compile" OrElse item.ItemType = "EmbeddedResource" OrElse item.ItemType = "None" OrElse item.ItemType = "Content" OrElse item.ItemType = "Reference" OrElse item.ItemType = "COMReference" OrElse item.ItemType = "ProjectReference" OrElse item.ItemType = "Analyzer" Then
                RaiseEvent Action(Me, New ActionEventArgs() With {.Action = ActionTypes.Exclude, .Data = item})
                Exclude(item)
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If SelectedNode IsNot Nothing AndAlso TypeOf SelectedNode.Tag Is Microsoft.Build.Evaluation.ProjectItem Then
            Dim item As Microsoft.Build.Evaluation.ProjectItem = SelectedNode.Tag
            If item.ItemType = "Compile" OrElse item.ItemType = "EmbeddedResource" OrElse item.ItemType = "None" OrElse item.ItemType = "Content" OrElse item.ItemType = "Reference" OrElse item.ItemType = "COMReference" OrElse item.ItemType = "ProjectReference" OrElse item.ItemType = "Analyzer" Then
                RaiseEvent Action(Me, New ActionEventArgs() With {.Action = ActionTypes.Delete, .Data = item})
                Delete(item)
            End If
        End If
    End Sub

#Region "TODO"

    Private Sub btnPaste_Click(sender As Object, e As EventArgs) Handles btnPaste.Click
        Dim item As Microsoft.Build.Evaluation.ProjectItem = Clipboard.GetData(Constants.ClipboardDataFormat)
    End Sub

    Private Sub btnCut_Click(sender As Object, e As EventArgs) Handles btnCut.Click
        If SelectedNode IsNot Nothing AndAlso TypeOf SelectedNode.Tag Is Microsoft.Build.Evaluation.ProjectItem Then
            Dim item As Microsoft.Build.Evaluation.ProjectItem = SelectedNode.Tag
            Exclude(item)
            Clipboard.SetData(Constants.ClipboardDataFormat, item)
        End If
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        If SelectedNode IsNot Nothing AndAlso TypeOf SelectedNode.Tag Is Microsoft.Build.Evaluation.ProjectItem Then
            Dim item As Microsoft.Build.Evaluation.ProjectItem = SelectedNode.Tag
            Clipboard.SetData(Constants.ClipboardDataFormat, item)
        End If
    End Sub

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

#End Region

    Public Event Open(sender As Object, e As String)

    Public Event Rename(sender As Object, e As RenameItemEventArgs)

    Public Shadows Event Move(sender As Object, e As MoveItemEventArgs)

    Public Event Action(sender As Object, e As ActionEventArgs)

#Region "API"

    Public Sub Exclude(item As Microsoft.Build.Evaluation.ProjectItem)
        item.Project.RemoveItem(item)
        item.Project.ReevaluateIfNecessary()
        item.Project.Save()
    End Sub

    Public Sub Delete(item As Microsoft.Build.Evaluation.ProjectItem)
        Dim strPath As String = If(Path.IsPathRooted(item.UnevaluatedInclude), item.UnevaluatedInclude, $"{item.Project.DirectoryPath}\{item.UnevaluatedInclude}")
        If File.Exists(strPath) Then File.Delete(strPath)
        Exclude(item)
    End Sub

#End Region

End Class

Public Enum SolutionItemType
    Solution
    Project
    Folder
    File
    Reference
    Properties
End Enum

Public Class Constants
    Public Const ClipboardDataFormat As String = "MSBuildProjectItem"
End Class