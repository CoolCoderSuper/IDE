''' <summary>
''' Represents the framework which to compile the project to.
''' </summary>
Public Class Framework

    ''' <summary>
    ''' The framework type. Mono,.NET, ect.
    ''' </summary>
    ''' <returns></returns>
    Public Property FrameworkType As FrameworkTypes

    ''' <summary>
    ''' The version of the framework.
    ''' </summary>
    ''' <returns></returns>
    Public Property Version As String

End Class