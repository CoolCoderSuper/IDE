Public Class frmOptions

    Private Sub tvSetting_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvSetting.AfterSelect
        If e.Node.Name = "MainFont" Then
            pnlMainFont.BringToFront()
        End If
    End Sub

    Private Sub frmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cbxMainFont_FontChanged(sender As Object, e As EventArgs) Handles cbxMainFont.FontChanged
        txtMainFontDisplay.Font = cbxMainFont.Font
    End Sub

End Class