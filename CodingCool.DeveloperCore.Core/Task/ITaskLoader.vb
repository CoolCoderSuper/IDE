Imports Microsoft.CodeAnalysis

Public Interface ITaskLoader
    Property Prefixes As List(Of String)
    Function Load(sln As Solution) As Task(Of List(Of TaskItem))
    Function Load(code As String) As List(Of TaskItem)

End Interface