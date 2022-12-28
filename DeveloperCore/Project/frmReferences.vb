Imports System.IO
Imports System.Reflection
Imports CodingCool.DeveloperCore.Core
Imports Microsoft.Build.Evaluation

Public Class frmReferences

    Public Sub New(pr As Project, projects As List(Of Project))
        InitializeComponent()
        Project = pr
        rvReferences.Projects = projects.Select(Function(x) (Path.GetFileNameWithoutExtension(x.ProjectFileLocation.LocationString), x.ProjectFileLocation.LocationString)).ToList
    End Sub

    Public ReadOnly Property Project As Project

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        For Each ref As Object In rvReferences.Results
            Dim aName As AssemblyName = TryCast(ref, AssemblyName)
            If aName IsNot Nothing Then
                Project.AddItem("Reference", aName.FullName)
            End If
            Dim strFile As String = TryCast(ref, String)
            If strFile IsNot Nothing Then
                Dim refItem As ProjectItem = Project.AddItem("Reference", AssemblyName.GetAssemblyName(strFile).Name).First
                refItem.SetMetadataValue("HintPath", Helpers.AbsolutePathToRelativePath(Project.DirectoryPath, strFile))
            End If
            Dim tLib As TypeLibrary = TryCast(ref, TypeLibrary)
            If tLib IsNot Nothing Then
                Dim refItem As ProjectItem = Project.AddItem("COMReference", tLib.Description).First
                refItem.SetMetadataValue("Guid", tLib.Guid)
                refItem.SetMetadataValue("VersionMajor", tLib.VersionMajor)
                refItem.SetMetadataValue("VersionMinor", tLib.VersionMinor)
                refItem.SetMetadataValue("Lcid", tLib.Lcid)
                refItem.SetMetadataValue("WrapperTool", tLib.WrapperTool)
                refItem.SetMetadataValue("Isolated", tLib.Isolated)
                refItem.SetMetadataValue("EmbedInteropTypes", True)
            End If
            Dim pr As (String, String) = If(TypeOf ref Is (String, String), ref, Nothing)
            If Not pr.Equals(Nothing) Then
                Dim refItem As ProjectItem = Project.AddItem("ProjectReference", Helpers.AbsolutePathToRelativePath(Project.DirectoryPath, pr.Item2)).First
                refItem.SetMetadataValue("Name", pr.Item1)
            End If
        Next
        Project.ReevaluateIfNecessary()
        Project.Save()
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

End Class