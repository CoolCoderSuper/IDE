Public Class MoveItemEventArgs
    Inherits EventArgs

    Public Property OldLocation As String

    Public Property NewLocation As String

    Public Property CrossProject As Boolean

    Public Property NewProject As String

    Public Property OldProject As String
End Class