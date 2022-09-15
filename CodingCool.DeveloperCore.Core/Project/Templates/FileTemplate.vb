Imports System.Drawing

''' <summary>
''' Represents a template for creating a file.
''' </summary>
Public Class FileTemplate

    Public Sub New()
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
    ''' The icon for the template.
    ''' </summary>
    ''' <returns></returns>
    Public Property Icon As Image

    ''' <summary>
    ''' The bare-bones file entity the template creates.
    ''' </summary>
    ''' <returns></returns>
    Public Property File As Object'File

    ''' <summary>
    ''' The files which to create.
    ''' </summary>
    ''' <returns></returns>
    Public Property Files As Dictionary(Of String, Byte())

    ''' <summary>
    ''' Creates the file.
    ''' </summary>
    ''' <param name="pr">The project to add the file to.</param>
    ''' <returns>The updated project.</returns>
    Public Function Create(pr As Object) As Object'Project) As Project
        For Each f As KeyValuePair(Of String, Byte()) In Files
            IO.File.WriteAllBytes(f.Key, f.Value)
        Next
        pr.Files.Add(File)
        Return pr
    End Function

End Class