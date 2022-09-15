''' <summary>
''' Represents a file in a project.
''' </summary>
Public Class File

    ''' <summary>
    ''' The relative path of the file.
    ''' </summary>
    ''' <returns></returns>
    Public Property Path As String

    ''' <summary>
    ''' Options on what happens to the file on build.
    ''' </summary>
    ''' <returns></returns>
    Public Property CopyToOutput As CopyToOutputOptions

End Class