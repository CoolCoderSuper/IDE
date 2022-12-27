Imports Microsoft.CodeAnalysis.MSBuild

Public Class SolutionParser
    Public Shared Property Workspace As MSBuildWorkspace

    Public Shared Async Function LoadSolution(strFile As String) As Task(Of Microsoft.CodeAnalysis.Solution)
        Workspace = MSBuildWorkspace.Create
        Return Await Workspace.OpenSolutionAsync(strFile)
    End Function

End Class