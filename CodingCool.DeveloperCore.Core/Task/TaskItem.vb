''' <summary>
''' Represents a task.
''' </summary>
Public Class TaskItem

    ''' <summary>
    ''' Represents the prefix of the task TODO, ect.
    ''' </summary>
    ''' <returns></returns>
    Public Property Prefix As String

    ''' <summary>
    ''' Task details.
    ''' </summary>
    ''' <returns></returns>
    Public Property Description As String

    ''' <summary>
    ''' The file in which the task is located.
    ''' </summary>
    ''' <returns></returns>
    Public Property File As String

    ''' <summary>
    ''' The line number on which the task is.
    ''' </summary>
    ''' <returns></returns>
    Public Property Line As Integer

End Class