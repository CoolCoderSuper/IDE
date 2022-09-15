Imports Microsoft.Build.Locator
Imports Microsoft.CodeAnalysis.MSBuild

Namespace Roslyn

    Public Class SolutionParser

        Public Function LoadSolution(strFile As String) As Microsoft.CodeAnalysis.Solution
            If Not MSBuildLocator.IsRegistered Then MSBuildLocator.RegisterDefaults
            Dim workspace As MSBuildWorkspace = MSBuildWorkspace.Create
            Return AsyncHelper.RunSync(Function() workspace.OpenSolutionAsync(strFile))
        End Function

    End Class

End Namespace