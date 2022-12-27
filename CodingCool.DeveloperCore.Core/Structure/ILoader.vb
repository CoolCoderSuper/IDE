Public Interface ILoader
    Function Load(code As String) As List(Of StructureItem)
End Interface

Public Class DefaultLoader
    Implements ILoader

    Public Function Load(code As String) As List(Of StructureItem) Implements ILoader.Load
        Return New List(Of StructureItem)
    End Function
End Class
