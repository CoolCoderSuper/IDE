Imports Microsoft.CSharp
Imports System.CodeDom.Compiler

Public Class ErrorHelper

    Public Function GetErrors(strLanguage As String, lFiles As String(), lReferences As String()) As List(Of ErrorItem)
        Dim lErrors As New List(Of ErrorItem)
        Dim l As New List(Of CompilerError)
        If strLanguage = "cs" Then
            l = CSharpCompile(lFiles, lReferences)
        Else
            l = VBCompile(lFiles, lReferences)
        End If
        For Each objError As CompilerError In l
            Dim objItem As New ErrorItem
            objItem.Description = objError.ErrorText
            objItem.File = objError.FileName
            objItem.Line = objItem.Line
            If objError.IsWarning Then
                objItem.ErrorType = ErrorTypes.Warning
            Else
                objItem.ErrorType = ErrorTypes.Error
            End If
            objItem.ErrorNumber = New ErrorNumber
            objItem.ErrorNumber.ErrorNumber = objError.ErrorNumber
            lErrors.Add(objItem)
        Next
        Return lErrors
    End Function

    ReadOnly references As String() = {"mscorlib.dll", "System.Core.dll", "System.Windows.dll", "System.Windows.Forms.dll", "System.dll", "System.Drawing.dll", "System.Data.dll", "System.Xml.dll", "System.Xml.Linq.dll", "System.Deployment.dll"}

    Private Function CSharpCompile(files As String(), lReferences As String()) As List(Of CompilerError)
        Dim CSCode As New CSharpCodeProvider(New Dictionary(Of String, String)() From {
                 {"ComplilerVersion", "4.8"}
    })
        Dim compilerParameters As New CompilerParameters(references.Concat(lReferences.ToList).ToArray, "", True)
        compilerParameters.GenerateExecutable = False
        Dim results As CompilerResults = CSCode.CompileAssemblyFromFile(compilerParameters, files)

        If results.Errors.HasErrors Then
            Return results.Errors.Cast(Of CompilerError)().ToList()
        End If
        Return New List(Of CompilerError)
    End Function

    Private Function VBCompile(files As String(), lReferences As String()) As List(Of CompilerError)
        Dim VBCode As New VBCodeProvider(New Dictionary(Of String, String)() From {
                 {"ComplilerVersion", "4.8"}
    })
        Dim compilerParameters As New CompilerParameters(references.Concat(lReferences.ToList).ToArray, "", True)
        compilerParameters.GenerateExecutable = False
        Dim results As CompilerResults = VBCode.CompileAssemblyFromFile(compilerParameters, files)

        If results.Errors.HasErrors Then
            Return results.Errors.Cast(Of CompilerError)().ToList()
        End If
        Return New List(Of CompilerError)
    End Function
End Class
