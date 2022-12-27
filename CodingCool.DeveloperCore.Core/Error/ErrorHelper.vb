Imports Microsoft.CodeAnalysis

''' <summary>
''' Get's errors from a solution.
''' </summary>
Public Class ErrorHelper

    ''' <summary>
    ''' Loads the errors.
    ''' </summary>
    ''' <param name="sln">The solution to check.</param>
    ''' <returns></returns>
    Public Async Function GetErrors(sln As Solution) As Task(Of List(Of ErrorItem))
        Dim lDiagnostics As New List(Of Diagnostic)
        For Each proj As Project In sln.Projects
           Dim comp As Compilation = Await proj.GetCompilationAsync
           lDiagnostics.AddRange(comp.GetDiagnostics.ToArray)
        Next
        Return ConvertDiagnostic(lDiagnostics)
    End Function

    Public Shared Function ConvertDiagnostic(lDiagnostics As List(Of Diagnostic)) As List(Of ErrorItem)
        Dim lErrors As New List(Of ErrorItem)
        For Each objError As Diagnostic In lDiagnostics
            Dim objItem As New ErrorItem With {
                .Description = objError.GetMessage,
                .File = objError.Location.GetLineSpan.Path,
                .Line = objError.Location.GetLineSpan.StartLinePosition.Line,
                .Column = objError.Location.GetLineSpan.StartLinePosition.Character
            }
            Select Case objError.Descriptor.DefaultSeverity
                Case DiagnosticSeverity.Error
                    objItem.ErrorType = ErrorTypes.Error
                Case DiagnosticSeverity.Warning
                    objItem.ErrorType = ErrorTypes.Warning
                Case DiagnosticSeverity.Info
                    objItem.ErrorType = ErrorTypes.Suggestion
                Case DiagnosticSeverity.Hidden
                    objItem.ErrorType = ErrorTypes.Hidden
            End Select
            objItem.ErrorNumber = New ErrorNumber With {
                .ErrorLink = objError.Descriptor.HelpLinkUri,
                .ErrorNumber = objError.Descriptor.Id
            }
            lErrors.Add(objItem)
        Next
        Return lErrors
    End Function

End Class