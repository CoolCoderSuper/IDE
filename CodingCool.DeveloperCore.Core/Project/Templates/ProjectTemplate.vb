Imports System.Drawing

''' <summary>
''' Represents a template for creating a project.
''' </summary>
Public Class ProjectTemplate

    Public Sub New()
        Folders = New List(Of String)
        Files = New Dictionary(Of String, Byte())
    End Sub

    ''' <summary>
    ''' The unique id of the template.
    ''' </summary>
    ''' <returns></returns>
    Public Property Id As String

    ''' <summary>
    ''' The name of the template.
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String

    ''' <summary>
    ''' The category for this template.
    ''' </summary>
    ''' <returns></returns>
    Public Property Category As String

    ''' <summary>
    ''' The icon for the template
    ''' </summary>
    ''' <returns></returns>
    Public Property Icon As Image

    ''' <summary>
    ''' The bare-bones project entity the template creates.
    ''' </summary>
    ''' <returns></returns>
    Public Property Project As Project

    ''' <summary>
    ''' The folders which to create. Not necessarily part of the project.
    ''' </summary>
    ''' <returns></returns>
    Public Property Folders As List(Of String)

    ''' <summary>
    ''' The files which to create. Not necessarily part of the project.
    ''' </summary>
    ''' <returns></returns>
    Public Property Files As Dictionary(Of String, Byte())

    ''' <summary>
    ''' Creates the project.
    ''' </summary>
    ''' <param name="path">The projects root path.</param>
    ''' <param name="sln">The solution which to add the project to.</param>
    ''' <returns>The updated solution.</returns>
    Public Function Create(path As String, sln As Solution) As Solution
        IO.Directory.CreateDirectory(path)
        For Each dir As String In Folders
            IO.Directory.CreateDirectory(dir)
        Next
        For Each f As KeyValuePair(Of String, Byte()) In Files
            IO.File.WriteAllBytes(f.Key, f.Value)
        Next
        sln.Projects.Add(Project)
        SolutionParser.Save(sln)
        Return sln
    End Function

End Class