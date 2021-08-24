Public Class NugetGalleryItem
    Public Property Title As String

    Public Property Description As String

    Public Property Version As String

    Public Property CommandText As String

    Public Event CommandClicked(sender As NugetGalleryItem)

    Public Sub New()
        InitializeComponent()
        lblName.DataBindings.Add(New Windows.Forms.Binding("Text", Me, "Title"))
        lblDescription.DataBindings.Add(New Windows.Forms.Binding("Text", Me, "Description"))
        lblVersion.DataBindings.Add(New Windows.Forms.Binding("Text", Me, "Version"))
        btnCMD.DataBindings.Add(New Windows.Forms.Binding("Text", Me, "CommandText"))
    End Sub

    Private Sub btnCMD_Click(sender As Object, e As EventArgs) Handles btnCMD.Click
        RaiseEvent CommandClicked(Me)
    End Sub
End Class
