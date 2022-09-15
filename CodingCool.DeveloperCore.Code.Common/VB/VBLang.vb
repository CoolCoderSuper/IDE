Imports CodingCool.DeveloperCore.Code.Language

Namespace VB

    Public Class VBLang
        Implements ILanguage

        Public ReadOnly Property Name As String Implements ILanguage.Name
            Get
                Return "VB"
            End Get
        End Property

        Public ReadOnly Property Keywords As List(Of IKeyword) Implements ILanguage.Keywords
            Get
                Return VBInfoList.GetKeywords
            End Get
        End Property

        Public ReadOnly Property BlockRules As List(Of ICodeBlockRule) Implements ILanguage.BlockRules
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public ReadOnly Property CommentPrefix As String Implements ILanguage.CommentPrefix
            Get
                Return "'"
            End Get
        End Property

        Public ReadOnly Property CaseSensitive As String Implements ILanguage.CaseSensitive
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property LineEndMarker As String Implements ILanguage.LineEndMarker
            Get
                Return String.Empty
            End Get
        End Property

    End Class

End Namespace