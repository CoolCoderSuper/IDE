''' <summary>
''' Represents an error in code.
''' </summary>
Public Class ErrorItem
    ''' <summary>
    ''' The error's type: Error, Warning, ect.
    ''' </summary>
    ''' <returns></returns>
    Public Property ErrorType As ErrorType

    ''' <summary>
    ''' The error number: BC323, CS232, ect. and the error's help link.
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
    ''' The file the error is in.
    ''' </summary>
    ''' <returns></returns>
    Public Property File As String

End Class
