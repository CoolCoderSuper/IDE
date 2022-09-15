Namespace Language

    Public Interface ILanguage
        ReadOnly Property Name As String
        ReadOnly Property Keywords As List(Of IKeyword)
        ReadOnly Property BlockRules As List(Of ICodeBlockRule)
        ReadOnly Property CommentPrefix As String
        ReadOnly Property CaseSensitive As String
        ReadOnly Property LineEndMarker As String
    End Interface

End Namespace