Public Class ObjectExplorerItem
    Public Property Id As Integer
    Public Property Title As String
    Public Property Type As ObjectExplorerType
    Public Property ParentId As Integer
    Public Property Position As Integer
End Class

Public Enum ObjectExplorerType
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