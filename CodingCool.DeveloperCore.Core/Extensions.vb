Imports System.Runtime.CompilerServices

Module LanguageExtensions

    <Extension()>
    Public Function GetValue(obj As Language) As String
        Select Case obj
            Case Language.VBDotNet
                Return "VB.NET"
            Case Language.CSharp
                Return "C#"
        End Select
    End Function

End Module