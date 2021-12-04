''' <summary>
''' Represents a reference for a project.
''' </summary>
Public Class Reference

    ''' <summary>
    ''' Path to the refernece file.
    ''' </summary>
    ''' <returns></returns>
    Public Property Path As String

    ''' <summary>
    ''' States whether or not to copy the references files to the output folder.
    ''' </summary>
    ''' <returns></returns>
    Public Property CopyLocal As Boolean

    ''' <summary>
    ''' Whether the references is a specific version.
    ''' </summary>
    ''' <returns></returns>
    Public Property SpecificVersion As Boolean

    ''' <summary>
    ''' States whether or not the types will be embedded in the current assembly.
    ''' </summary>
    ''' <returns></returns>
    Public Property EmbedInteropTypes As Boolean

End Class