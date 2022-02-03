Public Class RenameItemEventArgs
    Inherits EventArgs

    Public Sub New(strPath As String, strNewName As String, bIsFolder As Boolean)
        Path = strPath
        NewName = strNewName
        IsFolder = bIsFolder
    End Sub

    Public ReadOnly Property Path As String

    Public ReadOnly Property NewName As String

    Public ReadOnly Property IsFolder As Boolean

End Class