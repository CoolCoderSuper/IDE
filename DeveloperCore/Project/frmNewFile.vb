Imports CodingCool.DeveloperCore.Core

Public Class frmNewFile

    Public ReadOnly Property Template As FileTemplate
        Get
            Return fvFiles.Template
        End Get
    End Property

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        DialogResult = DialogResult.OK
        Close
    End Sub

End Class