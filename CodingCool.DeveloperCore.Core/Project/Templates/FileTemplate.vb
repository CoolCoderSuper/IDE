Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports Nustache.Core

''' <summary>
''' Represents a template for creating a file.
''' </summary>
Public Class FileTemplate

    Public Sub New()
        Variables = New Dictionary(Of String, String)
    End Sub

    ''' <summary>
    ''' The unique id of the template.
    ''' </summary>
    ''' <returns></returns>
    Public Property Id As String

    ''' <summary>
    ''' The id of the category.
    ''' </summary>
    ''' <returns></returns>
    Public Property Category As String

    ''' <summary>
    ''' The icon for this template.
    ''' </summary>
    ''' <returns></returns>
    Public Property Icon As Icon

    ''' <summary>
    ''' The name of the file.
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String

    ''' <summary>
    ''' Additional variables stored
    ''' </summary>
    ''' <returns></returns>
    Public Property Variables As Dictionary(Of String, String)

    ''' <summary>
    ''' The template of the file.
    ''' </summary>
    ''' <returns></returns>
    Public Property Template As String

    ''' <summary>
    ''' The assembly run the action from.
    ''' </summary>
    ''' <returns></returns>
    Public Property AssemblyPath As String

    ''' <summary>
    ''' The type where the action is.
    ''' </summary>
    ''' <returns></returns>
    Public Property Type As String

    ''' <summary>
    ''' The name of the static method to call.
    ''' </summary>
    ''' <returns></returns>
    Public Property Action As String

    ''' <summary>
    ''' The extension if the file.
    ''' </summary>
    ''' <returns></returns>
    Public Property Extension As String

    ''' <summary>
    ''' Creates the file, applying the template, and runs the specified action.
    ''' </summary>
    ''' <param name="strPath">The path to save the file to.</param>
    ''' <returns>The contents of the file.</returns>
    Public Function Create(strPath As String) As String
        Variables.Add("name", Name)
        Dim res As Object = Assembly.LoadFile(AssemblyPath).GetType(Type).GetMethod(Action, BindingFlags.Static).Invoke(Nothing, {})
        Template = res.Template
        For Each val As KeyValuePair(Of String, String) In res.Variables
            Variables.Add(val.Key, val.Value)
        Next
        Dim strContent As String = Render.StringToString(Template, Variables)
        If Path.GetExtension(strPath) = "" Then
            strPath &= Extension
        End If
        File.WriteAllText(strPath, strContent)
        Return strContent
    End Function

End Class