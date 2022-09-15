Public Class StructureItem_Old
    Public type As ExplorerItemTypes

    Public title As String

    Public position As Integer
End Class

Public Class StructureItemComparer
    Implements IComparer(Of StructureItem_Old)

    Public Function Compare(x As StructureItem_Old, y As StructureItem_Old) As Integer Implements IComparer(Of StructureItem_Old).Compare
        Return x.title.CompareTo(y.title)
    End Function

End Class