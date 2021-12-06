''' <summary>
''' Represents a file that can be designed.
''' </summary>
Public Class DesignableObject

    Public Sub New()
        Files = New List(Of File)
    End Sub

    ''' <summary>
    ''' The name of the file.
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String

    ''' <summary>
    ''' List of child files for the object.
    ''' </summary>
    ''' <returns></returns>
    Public Property Files As List(Of File)

End Class