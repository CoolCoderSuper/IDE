﻿Imports Microsoft.CodeAnalysis

''' <summary>
''' A class to load tasks from code.
''' </summary>
Public Class TaskHelper

    'UNDONE: Parse the trivia lists
    ''' <summary>
    ''' Loads the tasks.
    ''' </summary>
    ''' <param name="lFiles">The files to parse.</param>
    ''' <param name="strLanguage">The language of the files.</param>
    ''' <returns></returns>
    Public Function GetTasks(lFiles As String(), strLanguage As String) As List(Of TaskItem)
        Dim lTasks As New List(Of TaskItem)
        
        Return lTasks
    End Function

    ''' <summary>
    ''' Loads the tasks.
    ''' </summary>
    ''' <param name="lFiles">The files to parse.</param>
    ''' <param name="strCommentPrefix">The comment prefix.</param>
    ''' <returns></returns>
    <Obsolete("This method does not use roslyn and should not be used")>
    Public Function GetTasks_OLD(lFiles As String(), strCommentPrefix As String) As List(Of TaskItem)
        Dim lTasks As New List(Of TaskItem)
        For i As Integer = 0 To lFiles.Count() - 1
            If Not IO.File.Exists(lFiles(i)) Then
                Continue For
            End If
            Dim lLines As String() = IO.File.ReadAllLines(lFiles(i))
            For y As Integer = 0 To lLines.Length - 1
                Dim s As String = lLines(y).Trim()
                If s = String.Empty OrElse s.First() <> strCommentPrefix Then
                    Continue For
                End If
                s = s.Remove(0, 1).Trim()
                Dim lSplits As String() = s.Split(":")
                Dim strPrefix As String = lSplits.FirstOrDefault()
                Dim strDescription As String = String.Empty
                For j As Integer = 1 To lSplits.Length - 1
                    strDescription &= lSplits(j)
                Next
                If strPrefix Is Nothing OrElse strPrefix = String.Empty Then
                    Continue For
                End If
                Dim objTask As New TaskItem
                objTask.Prefix = strPrefix.Trim()
                objTask.Description = strDescription.Trim()
                objTask.File = lFiles(i)
                objTask.Line = y
                lTasks.Add(objTask)
            Next
        Next
        Return lTasks
    End Function

End Class
