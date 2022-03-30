Public Class ReferencesView

    Private Sub LoadGAC()
        'Process.Start("gacutil", "-l >C:\yourassemblies.txt")
    End Sub

    Private Sub ReferencesView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGAC()
    End Sub
End Class