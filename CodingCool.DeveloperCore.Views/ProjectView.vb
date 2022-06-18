Imports System.Windows.Forms

Public Class ProjectView
    Public PRTemplates As Core.ProjectTemplateManager
    Public TemplateCategories As Core.TemplateCategoryManager

    Public Function GetProject() As Core.Project
        Dim objProject As New Core.Project
    End Function

    Private Sub ProjectView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PRTemplates = New Core.ProjectTemplateManager : PRTemplates.Load()
        TemplateCategories = New Core.TemplateCategoryManager : TemplateCategories.Load()
        LoadImages()
        LoadChildren(String.Empty)
        cbxType.Items.AddRange({".NET Framework", ".NET", "Mono"})
    End Sub

    Private Sub LoadChildren(id As String)
        For Each cat As Core.TemplateCategory In TemplateCategories.Categories.Where(Function(x) x.ParentId = id)
            tvCategories.Nodes.Add(cat.Id, cat.Name).Tag = cat
            LoadChildren(cat.Id)
        Next
    End Sub

    Private Sub LoadImages()
        For Each t As Core.ProjectTemplate In PRTemplates.Templates
            ilTemplates.Images.Add(t.Id, t.Icon)
        Next
    End Sub

    Private Sub tvCategories_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvCategories.AfterSelect
        lvTemplates.Items.Clear()
        For Each t As Core.ProjectTemplate In PRTemplates.Templates.Where(Function(x) x.Category = e.Node.Name)
            Dim item As New ListViewItem
            item.Text = t.Name
            item.Name = t.Id
            item.Tag = t
            item.ImageKey = t.Id
            lvTemplates.Items.Add(item)
        Next
    End Sub

End Class