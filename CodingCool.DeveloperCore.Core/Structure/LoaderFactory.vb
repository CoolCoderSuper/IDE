Imports System.IO

Public Class LoaderFactory

    Public Shared Function GetLoaderFromFile(f As String) As ILoader
        Select Case Path.GetExtension(f)
            Case ".vb"
                Return New VbLoader
            Case ".cs"
                Return New CsLoader
            Case Else
                Return New DefaultLoader
        End Select
    End Function

End Class