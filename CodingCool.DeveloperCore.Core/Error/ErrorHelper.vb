Imports System.IO
Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.Emit

''' <summary>
''' Get's errors from a list of files and references.
''' </summary>
Public Class ErrorHelper

    Private ReadOnly references As String() = {"mscorlib.dll", "System.Core.dll", "System.Windows.dll", "System.Windows.Forms.dll", "System.dll", "System.Drawing.dll", "System.Data.dll", "System.Xml.dll", "System.Xml.Linq.dll", "System.Deployment.dll"}

    ''' <summary>
    ''' Loads the errors.
    ''' </summary>
    ''' <param name="strLanguage">The language of the files.</param>
    ''' <param name="lFiles">The files.</param>
    ''' <param name="lReferences">The references.</param>
    ''' <returns></returns>
    Public Function GetErrors(strLanguage As String, lFiles As String(), lReferences As String()) As List(Of ErrorItem)
        Dim lErrors As New List(Of ErrorItem)
        Dim l As New List(Of Diagnostic)
        If strLanguage = "cs" Then
            l = GetCSErrors(lFiles.Select(Function(x) IO.File.ReadAllText(x)).ToArray, lReferences)
        Else
            l = GetVBErrors(lFiles, lReferences)
        End If
        For Each objError As Diagnostic In l
            Dim objItem As New ErrorItem
            objItem.Description = objError.Descriptor.Description.ToString
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
            objItem.ErrorNumber.ErrorNumber = objError.Descriptor.Title.ToString
            lErrors.Add(objItem)
        Next
        Return lErrors
    End Function

    Private Function GetCSErrors(code As String(), refs As String()) As List(Of Diagnostic)
        Dim compiler As CSharp.CSharpCompilation = CSharp.CSharpCompilation.Create("DeveloperCoreErrors.dll", {}, refs.Concat(references.ToList).Select(Function(x) MetadataReference.CreateFromFile(x)))
        For Each c As String In code
            compiler.AddSyntaxTrees({CSharp.SyntaxFactory.ParseSyntaxTree(c)})
        Next
        Dim res As EmitResult = compiler.Emit(New MemoryStream)
        Return res.Diagnostics.ToList
    End Function

    Private Function GetVBErrors(code As String(), refs As String()) As List(Of Diagnostic)
        Dim compiler As VisualBasic.VisualBasicCompilation = VisualBasic.VisualBasicCompilation.Create("DeveloperCoreErrors.dll", {}, refs.Concat(references.ToList).Select(Function(x) MetadataReference.CreateFromFile(x)))
        For Each c As String In code
            compiler.AddSyntaxTrees({VisualBasic.SyntaxFactory.ParseSyntaxTree(c)})
        Next
        Dim res As EmitResult = compiler.Emit(New MemoryStream)
        Return res.Diagnostics.ToList
    End Function

End Class