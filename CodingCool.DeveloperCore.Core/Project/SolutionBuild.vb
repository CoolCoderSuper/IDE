Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.Emit

Public Class SolutionBuild

    Public Shared Async Function Build(sln As Solution) As Task(Of EmitResult())
        Dim graph As ProjectDependencyGraph = sln.GetProjectDependencyGraph
        Dim lResults As New List(Of EmitResult)
        For Each prId As ProjectId In graph.GetTopologicallySortedProjects
            Dim proj As Project = sln.GetProject(prId)
            Dim comp As Compilation = Await proj.GetCompilationAsync()
            lResults.Add(comp.Emit(proj.OutputFilePath))
        Next
        Return lResults.ToArray
    End Function

End Class