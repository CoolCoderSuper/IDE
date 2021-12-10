Imports System.Runtime.CompilerServices

Module Extensions

    <Extension()>
    Public Function GetString(obj As Language) As String
        Select Case obj
            Case Language.VBDotNet
                Return "vb.net"
            Case Language.CSharp
                Return "c#"
            Case Else
                Return Nothing
        End Select
    End Function

    <Extension()>
    Public Function GetString(obj As CopyToOutputOptions) As String
        Select Case obj
            Case CopyToOutputOptions.CopyAlways
                Return "CopyAlways"
            Case CopyToOutputOptions.CopyIfNewer
                Return "CopyIfNewer"
            Case CopyToOutputOptions.DoNotCopy
                Return "DoNotCopy"
            Case Else
                Return Nothing
        End Select
    End Function

    <Extension()>
    Public Function GetString(obj As FrameworkTypes) As String
        Select Case obj
            Case FrameworkTypes.DotNetCore
                Return ".net"
            Case FrameworkTypes.DotNetFramework
                Return ".net framework"
            Case FrameworkTypes.Mono
                Return "mono"
            Case Else
                Return Nothing
        End Select
    End Function

End Module