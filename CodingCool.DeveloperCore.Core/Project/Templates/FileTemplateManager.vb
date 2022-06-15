Imports System.Drawing

''' <summary>
''' Manages file templates.
''' </summary>
Public Class FileTemplateManager

    Public Sub New()
        Templates = New List(Of FileTemplate)
    End Sub

    ''' <summary>
    ''' The location of the template settings file.
    ''' </summary>
    ''' <returns></returns>
    Public Property TemplateSettings As String

    ''' <summary>
    ''' The list of available templates.
    ''' </summary>
    ''' <returns></returns>
    Public Property Templates As List(Of FileTemplate)

    ''' <summary>
    ''' Loads all the templates.
    ''' </summary>
    Public Sub Load()
        Dim objDoc As XDocument = XDocument.Load(TemplateSettings)
        For Each el As XElement In objDoc.Element("Templates").Elements("Template")
            Dim objTemplate As New FileTemplate
            objTemplate.Id = el.Element("Id").Value
            objTemplate.Name = el.Element("Name").Value
            objTemplate.Icon = Image.FromFile(el.Element("Icon").Value)
            objTemplate.Files = el.Element("Files").ToFileValueSet
            Templates.Add(objTemplate)
        Next
    End Sub

End Class