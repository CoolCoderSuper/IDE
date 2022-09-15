Imports Microsoft.CodeAnalysis

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
        For Each file As String In lFiles
            If strLanguage = "cs" Then
                Dim tree As CSharp.CSharpSyntaxTree = CSharp.SyntaxFactory.ParseSyntaxTree(IO.File.ReadAllText(file))
                Dim walker As New CSCommentsWalker
                walker.Visit(tree.GetRoot)
            Else
                Dim tree As VisualBasic.VisualBasicSyntaxTree = VisualBasic.SyntaxFactory.ParseSyntaxTree(IO.File.ReadAllText(file))
                Dim walker As New VBCommentsWalker
                walker.Visit(tree.GetRoot)
            End If
        Next
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

Public Class CSCommentsWalker
    Inherits CSharp.CSharpSyntaxWalker
    Private lComments As New List(Of SyntaxTrivia)

    Public Sub New()
        MyBase.New(SyntaxWalkerDepth.StructuredTrivia)
    End Sub

    Public Overrides Sub VisitTrivia(trivia As SyntaxTrivia)
        If trivia.RawKind = CSharp.SyntaxKind.SingleLineCommentTrivia OrElse trivia.RawKind = CSharp.SyntaxKind.MultiLineCommentTrivia Then
            lComments.Add(trivia)
        End If
        MyBase.VisitTrivia(trivia)
    End Sub

    Public Overrides Sub VisitDocumentationCommentTrivia(node As CSharp.Syntax.DocumentationCommentTriviaSyntax)
        lComments.Add(node.ParentTrivia)
        MyBase.VisitDocumentationCommentTrivia(node)
    End Sub

    Public Function GetComments() As List(Of SyntaxTrivia)
        Return lComments
    End Function

End Class

Public Class VBCommentsWalker
    Inherits VisualBasic.VisualBasicSyntaxWalker
    Private lComments As New List(Of SyntaxTrivia)

    Public Sub New()
        MyBase.New(SyntaxWalkerDepth.StructuredTrivia)
    End Sub

    Public Overrides Sub VisitTrivia(trivia As SyntaxTrivia)
        If trivia.RawKind = VisualBasic.SyntaxKind.CommentTrivia Then
            lComments.Add(trivia)
        End If
        MyBase.VisitTrivia(trivia)
    End Sub

    Public Overrides Sub VisitDocumentationCommentTrivia(node As VisualBasic.Syntax.DocumentationCommentTriviaSyntax)
        lComments.Add(node.ParentTrivia)
        MyBase.VisitDocumentationCommentTrivia(node)
    End Sub

    Public Function GetComments() As List(Of SyntaxTrivia)
        Return lComments
    End Function

End Class