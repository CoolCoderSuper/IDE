Imports System.Drawing

''' <summary>
''' Manages project templates.
''' </summary>
Public Class ProjectTemplateManager

    Public Sub New()
        Templates = New List(Of ProjectTemplate)
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
    Public Property Templates As List(Of ProjectTemplate)

    ''' <summary>
    ''' Loads all the templates.
    ''' </summary>
    Public Sub Load()
        Dim objDoc As XDocument = XDocument.Load(TemplateSettings)
        For Each el As XElement In objDoc.Element("Templates").Elements("Template")
            Dim objTemplate As New ProjectTemplate
            objTemplate.Id = el.Element("Id").Value
            objTemplate.Name = el.Element("Name").Value
            objTemplate.Icon = Image.FromFile(el.Element("Icon").Value)
            objTemplate.Project = SolutionParser.ParseProject(el.Element("Project"))
            objTemplate.Folders = el.Element("Folders").ToFolders
            objTemplate.Files = el.Element("Files").ToFileValueSet
            Templates.Add(objTemplate)
        Next
    End Sub

End Class