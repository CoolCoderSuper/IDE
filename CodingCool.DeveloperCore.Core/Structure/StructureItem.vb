Public Class StructureItem
    Public Property Id As Integer
    Public Property Title As String
    Public Property Type As StructureType
    Public Property ParentId As Integer
    Public Property Position As Integer
End Class

Public Enum StructureType
    [Class]
    [Interface]
    [Enum]
    [Structure]
    [Namespace]
    Method
    [Property]
    Variable
    [Event]
    [Operator]
    Region
End Enum