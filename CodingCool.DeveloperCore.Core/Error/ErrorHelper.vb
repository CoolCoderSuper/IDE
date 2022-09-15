Imports Microsoft.CodeAnalysis

''' <summary>
''' Get's errors from a list of files and references.
''' </summary>
Public Class ErrorHelper

    ''' <summary>
    ''' Loads the errors.
    ''' </summary>
    ''' <param name="sln">The solution to check.</param>
    ''' <returns></returns>
    Public Function GetErrors(sln As Solution) As List(Of ErrorItem)
        Dim lDiagnostics As New List(Of Diagnostic)
        Return ConvertDiagnostic(lDiagnostics)
    End Function

    Public Shared Function ConvertDiagnostic(lDiagnostics As List(Of Diagnostic)) As List(Of ErrorItem)
        Dim lErrors As New List(Of ErrorItem)
        For Each objError As Diagnostic In lDiagnostics
            Dim objItem As New ErrorItem
            objItem.Description = objError.GetMessage
            objItem.File = objError.Location.GetLineSpan.Path
            objItem.Line = objError.Location.GetLineSpan.StartLinePosition.Line
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
            objItem.ErrorNumber = New ErrorNumber
            objItem.ErrorNumber.ErrorLink = objError.Descriptor.HelpLinkUri
            objItem.ErrorNumber.ErrorNumber = objError.Descriptor.Id
            lErrors.Add(objItem)
        Next
        Return lErrors
    End Function

End Class