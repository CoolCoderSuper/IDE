Imports System.Drawing
Imports System.IO

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
    Public ReadOnly Property Templates As List(Of FileTemplate)

    ''' <summary>
    ''' Loads all the templates.
    ''' </summary>
    Public Sub Load()
        Dim objDoc As XDocument = XDocument.Load(TemplateSettings)
        For Each el As XElement In objDoc.Element("Templates").Elements("Template")
            Dim objTemplate As New FileTemplate
            With objTemplate
                .Id = el.Element("Id").Value
                .Name = el.Element("Name").Value
                .Category = el.Element("Category").Value
                .Action = el.Element("Action").Value
                .AssemblyPath = el.Element("AssemblyPath").Value
                .Template = el.Element("Template").Value
                .Type = el.Element("Type").Value
                .Type = el.Element("Extension").Value
                .Icon = New Icon(New MemoryStream(Convert.FromBase64String(el.Element("Icon").Value)))
            End With
            Templates.Add(objTemplate)
        Next
    End Sub

    ''' <summary>
    ''' Saves all the template.
    ''' </summary>
    Public Sub Save()
        Dim objDoc As New XDocument
        Dim objRoot As New XElement("Templates")
        For Each objTemplate As FileTemplate In Templates
            Dim objTemplateEl As New XElement("Template")
            With objTemplate
                objTemplateEl.Add(New XElement("Id", .Id))
                objTemplateEl.Add(New XElement("Name", .Name))
                objTemplateEl.Add(New XElement("Category", .Category))
                objTemplateEl.Add(New XElement("Action", .Action))
                objTemplateEl.Add(New XElement("AssemblyPath", .AssemblyPath))
                objTemplateEl.Add(New XElement("Template", .Template))
                objTemplateEl.Add(New XElement("Type", .Type))
                objTemplateEl.Add(New XElement("Extension", .Extension))
            End With
            objRoot.Add(objTemplateEl)
        Next
        objDoc.Add(objRoot)
        objDoc.Save(TemplateSettings)
    End Sub

End Class