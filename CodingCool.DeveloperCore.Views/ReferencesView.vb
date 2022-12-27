Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports CodingCool.DeveloperCore.Core

'TODO: Save the browse list
Public Class ReferencesView
    Private lGacResults As List(Of AssemblyName)
    Private lComResults As List(Of TypeLibrary)

    Public ReadOnly Property Results As IEnumerable(Of Object)
        Get
            Return lvSelected.Items.OfType(Of ListViewItem).Select(Function(x) x.Tag).AsEnumerable
        End Get
    End Property

    Public WriteOnly Property Projects As Dictionary(Of String, String)
        Set(value As Dictionary(Of String, String))

        End Set
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ReferencesView_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadGAC()
        LoadGACData(FilterGAC)
        LoadCOM()
        LoadCOMData(FilterCOM)
        AddHandler txtGACSearch.TextChanged, AddressOf GACFilter_Changed
        AddHandler cbSpecificVersion.CheckedChanged, AddressOf GACFilter_Changed
        AddHandler txtCOMSearch.TextChanged, AddressOf COMFilterChanged
    End Sub

    Private Sub LoadGAC()
        lGacResults = Fusion.GetGacAsAssembly.ToList
        lGacResults.RemoveAll(Function(x) x.Name.EndsWith(".resources", StringComparison.OrdinalIgnoreCase))
    End Sub

    Private Function FilterGAC() As List(Of AssemblyName)
        Dim lVRes As New List(Of AssemblyName)
        For Each name As String In lGacResults.Select(Function(x) x.Name).Distinct
            lVRes.Add(lGacResults.Where(Function(x) x.Name = name).OrderByDescending(Function(y) y.Version).First)
        Next
        Return If(cbSpecificVersion.Checked, lGacResults, lVRes).Where(Function(x) x.Name.ToLower.Contains(txtGACSearch.Text.ToLower)).OrderBy(Function(x) x.Name).ToList
    End Function

    Private Sub GACFilter_Changed(sender As Object, e As EventArgs)
        LoadGACData(FilterGAC())
    End Sub

    Private Sub LoadGACData(lRes As List(Of AssemblyName))
        lvGAC.Items.Clear()
        For Each a As AssemblyName In lRes
            lvGAC.Items.Add(New ListViewItem({a.Name, If(a.Version Is Nothing, "", a.Version.ToString)}) With {.Tag = a})
        Next
    End Sub

    Private Sub LoadCOM()
        lComResults = TypeLibrary.Libraries.ToList
    End Sub

    Private Sub LoadCOMData(lRes As List(Of TypeLibrary))
        lvCOM.Items.Clear()
        For Each tLib As TypeLibrary In lRes
            lvCOM.Items.Add(New ListViewItem({tLib.Description, tLib.Path}) With {.Tag = tLib})
        Next
    End Sub

    Private Function FilterCOM() As List(Of TypeLibrary)
        Return lComResults.Where(Function(x) x.Description.ToLower.Contains(txtCOMSearch.Text.ToLower)).OrderBy(Function(x) x.Description).ToList
    End Function

    Private Sub COMFilterChanged(sender As Object, e As EventArgs)
        LoadCOMData(FilterCOM)
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'TODO: Automatically add to the selected list
        Dim ofd As New OpenFileDialog With {
            .RestoreDirectory = True,
            .Multiselect = True,
            .Filter = "Assembly files (*.exe;*.dll)|*.dll;*.exe|All files (*.*)|*.*"
        }
        If ofd.ShowDialog = DialogResult.OK Then
            For Each f As String In ofd.FileNames
                lvBrowse.Items.Add(New ListViewItem({Path.GetFileNameWithoutExtension(f), f}) With {.Tag = f})
            Next
        End If
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If tcReferences.SelectedTab Is tpGAC AndAlso lvGAC.SelectedItems.Count > 0 Then
            Dim aName As AssemblyName = lvGAC.SelectedItems.Item(0).Tag
            lvSelected.Items.Add(New ListViewItem({aName.Name, "GAC", aName.Name}) With {.Tag = aName})
        ElseIf tcReferences.SelectedTab Is tpCOM AndAlso lvCOM.SelectedItems.Count > 0 Then
            Dim tLib As TypeLibrary = lvCOM.SelectedItems.Item(0).Tag
            lvSelected.Items.Add(New ListViewItem({tLib.Description, "Type Library", tLib.Path}) With {.Tag = tLib})
        ElseIf tcReferences.SelectedTab Is tpBrowse AndAlso lvBrowse.SelectedItems.Count > 0 Then
            Dim strPath As String = lvBrowse.SelectedItems.Item(0).Tag
            lvSelected.Items.Add(New ListViewItem({Path.GetFileName(strPath), "Assembly", strPath}) With {.Tag = strPath})
        End If
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If lvSelected.SelectedItems.Count > 0 Then
            lvSelected.Items.Remove(lvSelected.SelectedItems.Item(0))
        End If
    End Sub

End Class