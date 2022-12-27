Imports System.Windows.Forms
Imports CodingCool.DeveloperCore.Core

'TODO: Switch template to fluid
Public Class FileView
    Dim objFileMngr As FileTemplateManager
    Public Property Template As FileTemplate

    Private Sub FileView_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not DesignMode Then
            LoadCategories()
            objFileMngr = New FileTemplateManager
            objFileMngr.Load()
        End If
    End Sub

    Private Sub LoadCategories()
        tvCategories.Nodes.Clear()
        Dim objCategoryMngr As New TemplateCategoryManager
        objCategoryMngr.Load()
        For Each cat As TemplateCategory In objCategoryMngr.Categories.Where(Function(x) x.ParentId = Nothing)
            Dim nParent As TreeNode = tvCategories.Nodes.Add(cat.Id, cat.Name)
            WalkCategory(cat.Id, nParent, objCategoryMngr.Categories)
        Next
    End Sub

    Private Sub WalkCategory(id As String, nParent As TreeNode, lCategories As List(Of TemplateCategory))
        For Each cat As TemplateCategory In lCategories.Where(Function(x) x.ParentId = id)
            Dim nNParent As TreeNode = nParent.Nodes.Add(cat.Id, cat.Name)
            WalkCategory(cat.Id, nNParent, lCategories)
        Next
    End Sub

    Private Sub tvCategories_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvCategories.AfterSelect
        LoadFiles(e.Node.Name)
    End Sub

    Private Sub LoadFiles(id As String)
        lvTemplates.Items.Clear()
        ilItems.Images.Clear()
        For Each f As FileTemplate In objFileMngr.Templates.Where(Function(x) x.Category = id)
            If f.Icon IsNot Nothing Then ilItems.Images.Add(f.Id, f.Icon)
            lvTemplates.Items.Add(f.Id, f.Name, f.Id).Tag = f
        Next
    End Sub

    Private Sub lvTemplates_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvTemplates.ItemSelectionChanged
        Try
            Template = lvTemplates.SelectedItems(0).Tag
        Catch ex As Exception

        End Try
    End Sub

End Class