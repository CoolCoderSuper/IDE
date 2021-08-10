Imports System.IO

Public Class CursorHelper

    Public Function FromByteArray(ByVal array As Byte()) As Cursor
        Using memoryStream As MemoryStream = New MemoryStream(array)
            Return New Cursor(memoryStream)
        End Using
    End Function

End Class