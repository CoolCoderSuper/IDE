Imports FastColoredTextBoxNS
Imports System.Text.RegularExpressions

''' <summary>
''' This item appears when any part of snippet text is typed
''' </summary>
Public Class DeclarationSnippet
    Inherits SnippetAutocompleteItem

    Public Sub New(ByVal snippet As String)
        MyBase.New(snippet)
    End Sub

    Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
        Dim pattern = Regex.Escape(fragmentText)
        If Regex.IsMatch(Text, $"\b{pattern}", RegexOptions.IgnoreCase) Then
            Return CompareResult.Visible
        End If
        Return CompareResult.Hidden
    End Function

End Class

''' <summary>
''' Inerts line break after '}'
''' </summary>
Public Class InsertEnterSnippet
    Inherits AutocompleteItem
    Private enterPlace As Place = Place.Empty

    Public Sub New()
        MyBase.New("[Line break]")
    End Sub

    Public Overrides Property ToolTipTitle() As String
        Get
            Return "Insert line break after '}'"
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
        Dim r = Parent.Fragment.Clone()
        While r.Start.iChar > 0
            If r.CharBeforeStart = "}"c Then
                enterPlace = r.Start
                Return CompareResult.Visible
            End If

            r.GoLeftThroughFolded()
        End While

        Return CompareResult.Hidden
    End Function

    Public Overrides Function GetTextForReplace() As String
        'extend range
        Dim r As Range = Parent.Fragment
        Dim [end] As Place = r.[End]
        r.Start = enterPlace
        r.[End] = r.[End]
        'insert line break
        Return $"{Environment.NewLine}{r.Text}"
    End Function

    Public Overrides Sub OnSelected(ByVal popupMenu As AutocompleteMenu, ByVal e As SelectedEventArgs)
        MyBase.OnSelected(popupMenu, e)
        If Parent.Fragment.tb.AutoIndent Then
            Parent.Fragment.tb.DoAutoIndent()
        End If
    End Sub

End Class

''' <summary>
''' Divides numbers and words: "123AND456" -> "123 AND 456"
''' Or "i=2" -> "i = 2"
''' </summary>
Public Class InsertSpaceSnippet
    Inherits AutocompleteItem
    Private pattern As String

    Public Sub New(ByVal pattern As String)
        MyBase.New(String.Empty)
        Me.pattern = pattern
    End Sub

    Public Sub New()
        Me.New("^(\d+)([a-zA-Z_]+)(\d*)$")
    End Sub

    Public Overrides Property ToolTipTitle() As String
        Get
            Return Text
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
        If Regex.IsMatch(fragmentText, pattern) Then
            Text = InsertSpaces(fragmentText)
            If Text <> fragmentText Then
                Return CompareResult.Visible
            End If
        End If
        Return CompareResult.Hidden
    End Function

    Public Function InsertSpaces(ByVal fragment As String) As String
        Dim m = Regex.Match(fragment, pattern)
        If m Is Nothing Then
            Return fragment
        End If
        If m.Groups(1).Value = String.Empty AndAlso m.Groups(3).Value = String.Empty Then
            Return fragment
        End If
        Return ($"{m.Groups(1).Value} {m.Groups(2).Value} {m.Groups(3).Value}").Trim()
    End Function

End Class