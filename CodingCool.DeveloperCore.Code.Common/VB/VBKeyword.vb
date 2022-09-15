Imports CodingCool.DeveloperCore.Code.Language

Namespace VB

    Public Class VBKeyword
        Implements IKeyword

        Public Sub New(value As String)
            Me.Value = value
        End Sub

        Public Property Value As String Implements IKeyword.Value

    End Class

End Namespace