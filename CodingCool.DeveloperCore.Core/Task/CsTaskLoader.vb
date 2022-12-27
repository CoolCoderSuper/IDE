Imports Microsoft.CodeAnalysis

Public Class CsTaskLoader
    Implements ITaskLoader

    Public Property Prefixes As List(Of String) Implements ITaskLoader.Prefixes
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As List(Of String))
            Throw New NotImplementedException()
        End Set
    End Property

    Public Function Load(sln As Solution) As Task(Of List(Of TaskItem)) Implements ITaskLoader.Load
        Throw New NotImplementedException()
    End Function

    Public Function Load(code As String) As List(Of TaskItem) Implements ITaskLoader.Load
        Throw New NotImplementedException()
    End Function
End Class
