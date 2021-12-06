﻿''' <summary>
''' Represents a solution.
''' </summary>
Public Class Solution

    Public Sub New()
        Projects = New List(Of Project)
        Folders = New List(Of String)
    End Sub

    ''' <summary>
    ''' The aboslute path of the solution.
    ''' </summary>
    ''' <returns></returns>
    Public Property Path As String

    ''' <summary>
    ''' A list of the projects for this solution.
    ''' </summary>
    ''' <returns></returns>
    Public Property Projects As List(Of Project)

    ''' <summary>
    ''' A list of the folders in the solution.
    ''' </summary>
    ''' <returns></returns>
    Public Property Folders As List(Of String)

    ''' <summary>
    ''' Relative path to the nuget cache for this solution.
    ''' </summary>
    ''' <returns></returns>
    Public Property NugetCache As String

End Class