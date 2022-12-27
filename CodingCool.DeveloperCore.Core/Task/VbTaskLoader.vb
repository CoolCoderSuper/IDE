Imports System.IO
Imports System.Text.RegularExpressions
Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.VisualBasic
'TODO: Finish vb and add c#
Public Class VbTaskLoader
    Implements ITaskLoader

    Public Property Prefixes As List(Of String) Implements ITaskLoader.Prefixes

    Public Async Function Load(sln As Solution) As Task(Of List(Of TaskItem)) Implements ITaskLoader.Load
        Dim results As New List(Of TaskItem)
        For Each doc As Document In sln.Projects.Where(Function(p) p.Language = "vb").Select(Function(x) x.Documents.Where(Function(d) Path.GetExtension(d.FilePath) = ".vb")).SelectMany(Function(y) y)
            results.AddRange(Load((Await doc.GetTextAsync).ToString))
        Next
        Return results
    End Function

    Public Function Load(code As String) As List(Of TaskItem) Implements ITaskLoader.Load
        Dim query As New Regex($"(?i)({String.Join("|", Prefixes.Select(Function(x) Regex.Escape(x)))}).*")
        Dim results As New List(Of TaskItem)
        Dim root As VisualBasicSyntaxNode = SyntaxFactory.ParseSyntaxTree(code).GetRoot
        Dim comments As IEnumerable(Of SyntaxTrivia) = root.DescendantTrivia.Where(Function(x) x.IsKind(SyntaxKind.CommentTrivia))
        For Each comment As SyntaxTrivia In comments
            Dim match As Match = query.Match(comment.ToString)
            Dim item As New TaskItem
        Next
        Return results
    End Function

End Class