Public Class ProjectView
    Public PRTemplates As Core.ProjectTemplateManager
    Public TemplateCategories As Core.TemplateCategoryManager

    Public Function GetProject() As Core.Project
        Dim objProject As New Core.Project
    End Function

    Private Sub tvCategories_AfterSelect(sender As Object, e As Windows.Forms.TreeViewEventArgs) Handles tvCategories.AfterSelect
        If e.Node.Name = String.Empty Then

        End If
    End Sub

    Private Sub ProjectView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PRTemplates = New Core.ProjectTemplateManager : PRTemplates.Load()
        TemplateCategories = New Core.TemplateCategoryManager : TemplateCategories.Load()
        cbxType.Items.AddRange({".NET Framework", ".NET", "Mono"})
    End Sub

End Class