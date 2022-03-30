Imports Microsoft.CSharp
Imports System.CodeDom.Compiler

Public Class Compile
    Private ReadOnly references As String() = {"mscorlib.dll", "System.Core.dll", "System.Windows.dll", "System.Windows.Forms.dll", "System.dll", "System.Drawing.dll", "System.Data.dll", "System.Xml.dll", "System.Xml.Linq.dll", "System.Deployment.dll"}

    Public Function CSharpCompile(strProjectName As String, files As String(), bGenrateExecutable As Boolean, lReferences As List(Of String)) As String
        Dim strOutput As String = String.Empty
        Dim cSharpCode As New CSharpCodeProvider(New Dictionary(Of String, String) From {
            {"ComplilerVersion", "4.8"}
        })
        Dim parameters As New CompilerParameters(references.Concat(lReferences).ToArray(), strProjectName, True)
        parameters.GenerateExecutable = bGenrateExecutable
        Dim results As CompilerResults = cSharpCode.CompileAssemblyFromFile(parameters, files)

        If results.Errors.HasErrors Then
            results.Errors.Cast(Of CompilerError)().ToList().ForEach(Sub([error])
                                                                         strOutput &= $"{[error].ErrorNumber}: '{[error].ErrorText}' at line {[error].Line} in {[error].FileName}{vbCrLf}"
                                                                     End Sub)
        Else
            strOutput += $"----Build succeeded----{Environment.NewLine}"
        End If
        Return strOutput
    End Function

    Public Function VBCompile(strProjectName As String, files As String(), bGenrateExecutable As Boolean, lReferences As List(Of String)) As String
        Dim strOutput As String = String.Empty
        Dim VBCode As New VBCodeProvider(New Dictionary(Of String, String) From {
                 {"ComplilerVersion", "4.8"}
    })
        Dim compilerParameters As New CompilerParameters(references.Concat(lReferences).ToArray(), strProjectName, True)
        compilerParameters.GenerateExecutable = bGenrateExecutable
        Dim results As CompilerResults = VBCode.CompileAssemblyFromFile(compilerParameters, files)

        If results.Errors.HasErrors Then
            results.Errors.Cast(Of CompilerError)().ToList().ForEach(Sub([error])
                                                                         strOutput &= $"{[error].ErrorNumber}: '{[error].ErrorText}' at line {[error].Line} in {[error].FileName}{vbCrLf}"
                                                                     End Sub)
        Else
            strOutput += $"----Build succeeded----{Environment.NewLine}"
        End If
        Return strOutput
    End Function

End Class