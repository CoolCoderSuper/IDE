Imports CodingCool.DeveloperCore.Code.Language

Public Class VBCodeGroup
    Implements ICodeBlockRule

    Public Sub New(start As String, [end] As String, isElement As Boolean, isNameStart As Boolean, Optional symbol As VBSymbolType = VBSymbolType.None)
        Me.Start = start
        Me.End = [end]
        Me.IsElement = isElement
        Me.IsNameStart = isNameStart
        Me.Symbol = symbol
    End Sub

    Public ReadOnly Property Start As String Implements ICodeBlockRule.Start

    Public ReadOnly Property [End] As String Implements ICodeBlockRule.End

    Public ReadOnly Property IsElement As Boolean Implements ICodeBlockRule.IsElement

    Public ReadOnly Property IsNameStart As Boolean Implements ICodeBlockRule.IsNameStart

    Public Property Symbol As VBSymbolType

End Class