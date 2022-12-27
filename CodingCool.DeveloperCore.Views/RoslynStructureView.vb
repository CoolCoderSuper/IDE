Imports System.Drawing
Imports System.Windows.Forms
Imports CodingCool.DeveloperCore.Core
Imports Microsoft.CodeAnalysis

'TODO: Regions; reorganize members
Public Class RoslynStructureView
    Inherits TreeView

#Region "Components"

    Private WithEvents ilImages As ImageList
    Dim lResults As List(Of StructureItem)

#End Region

#Region "Common"

    Public Property Loader As ILoader

    Public Sub New()
        Text = "Structure"
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        ilImages = New ImageList
        SuspendLayout()
        ilImages.Images.Add("Class", My.Resources.Icons_16x16_Class)
        ilImages.Images.Add("Event", My.Resources.Icons_16x16_Event)
        ilImages.Images.Add("Method", My.Resources.Icons_16x16_Method)
        ilImages.Images.Add("Property", My.Resources.Icons_16x16_Property)
        ilImages.Images.Add("Enum", My.Resources.Icons_16x16_Enum)
        ilImages.Images.Add("Variable", My.Resources.Icons_16x16_Field)
        ilImages.Images.Add("Interface", My.Resources.Icons_16x16_Interface)
        ilImages.Images.Add("Namespace", My.Resources.Icons_16x16_NameSpace)
        ilImages.Images.Add("Operator", My.Resources.Icons_16x16_Operator)
        ilImages.Images.Add("Structure", My.Resources.Icons_16x16_Struct)
        Dock = DockStyle.Fill
        LineColor = Color.Empty
        Location = New Point(0, 0)
        Name = "tvStructure"
        Size = New Size(200, 100)
        TabIndex = 0
        ForeColor = Color.Black
        ImageList = ilImages
        ResumeLayout(False)
    End Sub

    Private Sub RoslynStructureView_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Me.AfterSelect
        If e.Action = TreeViewAction.ByMouse Then
            RaiseEvent Navigate(Me, e.Node.Tag.Position)
        End If
    End Sub

    Public Event Navigate(sender As Object, e As Integer)

#End Region

    Public Sub LoadStructure(code As String)
        LoadResults(Loader.Load(code))
    End Sub

#Region "Load"

    Private Sub LoadResults(list As List(Of StructureItem))
        If lResults Is Nothing OrElse Not IsListEqual(list, lResults) Then
            Dim dState As Dictionary(Of String, Boolean) = GetExpandState()
            Nodes.Clear()
            For Each item As StructureItem In list.Where(Function(x) x.ParentId = Nothing)
                Dim nItem As TreeNode = Nodes.Add(item.Id.ToString, item.Title, GetImageKey(item.Type), GetImageKey(item.Type))
                nItem.Tag = item
                WalkExplorerItem(nItem, list.Where(Function(x) x.ParentId = item.Id).ToList, list)
            Next
            lResults = list
            RestoreState(dState)
        End If
    End Sub

    Private Function GetExpandState() As Dictionary(Of String, Boolean)
        Dim dResults As New Dictionary(Of String, Boolean)
        WalkTreeViewGet(Nodes, dResults)
        Return dResults
    End Function

    Private Sub WalkTreeViewGet(nodes As TreeNodeCollection, ByRef dResults As Dictionary(Of String, Boolean))
        For Each node As TreeNode In nodes
            If Not dResults.ContainsKey(node.Text) Then dResults.Add(node.Text, node.IsExpanded)
            WalkTreeViewGet(node.Nodes, dResults)
        Next
    End Sub

    Private Sub RestoreState(dState As Dictionary(Of String, Boolean))
        WalkTreeViewSet(Nodes, dState)
    End Sub

    Private Sub WalkTreeViewSet(nodes As TreeNodeCollection, dState As Dictionary(Of String, Boolean))
        For Each node As TreeNode In nodes
            If dState.ContainsKey(node.Text) AndAlso dState(node.Text) Then node.Expand()
            WalkTreeViewSet(node.Nodes, dState)
        Next
    End Sub

    Private Function IsListEqual(list1 As List(Of StructureItem), list2 As List(Of StructureItem))
        Return list1.All(Function(item) list2.Any(Function(x) x.Id = item.Id AndAlso x.Title = item.Title AndAlso x.Type = item.Type)) AndAlso list2.All(Function(item) list1.Any(Function(x) x.Id = item.Id AndAlso x.Title = item.Title AndAlso x.Type = item.Type))
    End Function

    Private Sub WalkExplorerItem(n As TreeNode, items As List(Of StructureItem), mainList As List(Of StructureItem))
        For Each item As StructureItem In items
            Dim nItem As TreeNode = n.Nodes.Add(item.Id.ToString, item.Title, GetImageKey(item.Type), GetImageKey(item.Type))
            nItem.Tag = item
            WalkExplorerItem(nItem, mainList.Where(Function(x) x.ParentId = item.Id).ToList, mainList)
        Next
    End Sub

    Private Function GetImageKey(type As StructureType) As String
        Select Case type
            Case StructureType.Class
                Return "Class"
            Case StructureType.Enum
                Return "Enum"
            Case StructureType.Event
                Return "Event"
            Case StructureType.Interface
                Return "Interface"
            Case StructureType.Method
                Return "Method"
            Case StructureType.Namespace
                Return "Namespace"
            Case StructureType.Operator
                Return "Operator"
            Case StructureType.Property
                Return "Property"
            Case StructureType.Structure
                Return "Structure"
            Case StructureType.Variable
                Return "Variable"
            Case Else
                Return String.Empty
        End Select
    End Function

#End Region

End Class