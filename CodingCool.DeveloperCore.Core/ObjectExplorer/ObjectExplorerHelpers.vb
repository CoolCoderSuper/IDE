Public Class ExplorerItem
    Public type As ExplorerItemTypes

    Public title As String

    Public position As Integer
End Class

Public Class ExplorerItemComparer
    Implements IComparer(Of ExplorerItem)

    Public Function Compare(x As ExplorerItem, y As ExplorerItem) As Integer Implements IComparer(Of ExplorerItem).Compare
        Return x.title.CompareTo(y.title)
    End Function

End Class