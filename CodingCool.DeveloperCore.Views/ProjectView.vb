Public Class ProjectView

    Public Function GetProject() As Core.Project
        Dim objProject As New Core.Project
    End Function

    Private Sub tvCategories_AfterSelect(sender As Object, e As Windows.Forms.TreeViewEventArgs) Handles tvCategories.AfterSelect
        If e.Node.Name = String.Empty Then

        End If
    End Sub

End Class