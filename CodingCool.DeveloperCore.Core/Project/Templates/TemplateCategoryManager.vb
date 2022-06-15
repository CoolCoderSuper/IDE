''' <summary>
''' Manages template categories.
''' </summary>
Public Class TemplateCategoryManager

    Public Sub New()
        Categories = New List(Of TemplateCategory)
    End Sub

    ''' <summary>
    ''' The location of the category settings file.
    ''' </summary>
    ''' <returns></returns>
    Public Property CategorySettings As String

    ''' <summary>
    ''' The list of available templates.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Categories As List(Of TemplateCategory)

    ''' <summary>
    ''' Loads all the categories.
    ''' </summary>
    Public Sub Load()
        Dim objDoc As XDocument = XDocument.Load(CategorySettings)
        For Each el As XElement In objDoc.Element("Categories").Elements("Category")
            Dim objCategory As New TemplateCategory
            objCategory.Id = el.Element("Id").Value
            objCategory.Name = el.Element("Name").Value
            objCategory.ParentId = el.Element("ParentId").Value
            Categories.Add(objCategory)
        Next
    End Sub

End Class