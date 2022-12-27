''' <summary>
''' Represents an error in code.
''' </summary>
Public Class ErrorItem

    ''' <summary>
    ''' The error's type: Error, Warning, etc.
    ''' </summary>
    ''' <returns></returns>
    Public Property ErrorType As ErrorTypes

    ''' <summary>
    ''' The error number: BC323, CS232, etc. and the error's help link.
    ''' </summary>
    ''' <returns></returns>
    Public Property ErrorNumber As ErrorNumber

    ''' <summary>
    ''' The description of the error.
    ''' </summary>
    ''' <returns></returns>
    Public Property Description As String

    ''' <summary>
    ''' The line the error is on.
    ''' </summary>
    ''' <returns></returns>
    Public Property Line As Integer

    ''' <summary>
    ''' The column in the line.
    ''' </summary>
    ''' <returns></returns>
    Public Property Column As Integer

    ''' <summary>
    ''' The file the error is in.
    ''' </summary>
    ''' <returns></returns>
    Public Property File As String

End Class

''' <summary>
''' Represents an error's number.
''' </summary>
Public Class ErrorNumber

    ''' <summary>
    ''' The error's number.
    ''' </summary>
    ''' <returns></returns>
    Public Property ErrorNumber As String

    ''' <summary>
    ''' The error's help link.
    ''' </summary>
    ''' <returns></returns>
    Public Property ErrorLink As String

End Class