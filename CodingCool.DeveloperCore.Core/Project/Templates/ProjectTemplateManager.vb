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
    Public ReadOnly Property Templates As List(Of ProjectTemplate)

    ''' <summary>
    ''' Loads all the templates.
    ''' </summary>
    Public Sub Load()
        Dim objDoc As XDocument = XDocument.Load(TemplateSettings)
        For Each el As XElement In objDoc.Element("Templates").Elements("Template")
            Dim objTemplate As New ProjectTemplate
            Templates.Add(objTemplate)
        Next
    End Sub

End Class