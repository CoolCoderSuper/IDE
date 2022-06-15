''' <summary>
''' Represents a category for organizing project or file templates.
''' </summary>
Public Class TemplateCategory

    ''' <summary>
    ''' The unique id of the category.
    ''' </summary>
    ''' <returns></returns>
    Public Property Id As String

    ''' <summary>
    ''' The name of the category.
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String

    ''' <summary>
    ''' The id of the parent category. Blank if it is top-level.
    ''' </summary>
    ''' <returns></returns>
    Public Property ParentId As String

End Class