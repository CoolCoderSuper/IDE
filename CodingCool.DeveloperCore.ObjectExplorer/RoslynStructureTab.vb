Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports CodingCool.DeveloperCore.Core
Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.VisualBasic
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

'TODO: Regions; reorganize members
Public Class RoslynStructureTab
    Inherits TabPage

#Region "Components"

    Private WithEvents ilImages As ImageList
    Private WithEvents tvStructure As TreeView
    Dim lResults As List(Of StructureItem)

#End Region

#Region "Common"

    Public Property ExplorerList As New List(Of StructureItem_Old)

    Public Sub New()
        Text = "Structure"
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        tvStructure = New TreeView
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
        '
        'tvObjectExplorer
        '
        tvStructure.Dock = System.Windows.Forms.DockStyle.Fill
        tvStructure.LineColor = System.Drawing.Color.Empty
        tvStructure.Location = New System.Drawing.Point(0, 0)
        tvStructure.Name = "tvStructure"
        tvStructure.Size = New System.Drawing.Size(200, 100)
        tvStructure.TabIndex = 0
        tvStructure.BackColor = ColorTranslator.FromHtml("#8a8a88")
        tvStructure.ForeColor = Color.White
        tvStructure.ImageList = ilImages
        '
        'ObjectExplorerTab
        '
        Controls.Add(tvStructure)
        ResumeLayout(False)

    End Sub

    Private Sub tvObjectExplorer_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvStructure.AfterSelect
        If e.Action = TreeViewAction.ByMouse Then
            RaiseEvent Naviagte(Me, e.Node.Tag.Position)
        End If
    End Sub

    Public Event Naviagte(sender As Object, e As Integer)

#End Region

#Region "C#"

    Public Sub ReCSharpBuildObjectExplorer(text As String)
        Try
            Dim list As List(Of StructureItem_Old) = New List(Of StructureItem_Old)
            Dim lastClassIndex As Integer = -1
            Dim regex As Regex = New Regex("^(?<range>[\w\s]+\b(class|struct|enum|interface)\s+[\w<>,\s]+)|^\s*(public|private|internal|protected)[^\n]+(\n?\s*{|;)?", RegexOptions.Multiline)
            For Each r As Match In regex.Matches(text)
                Try
                    Dim s As String = r.Value
                    Dim i As Integer = s.IndexOfAny(New Char() {"=", "{", ";"})
                    If i >= 0 Then
                        s = s.Substring(0, i)
                    End If
                    s = s.Trim()
                    Dim item As StructureItem_Old = New StructureItem_Old With {.title = s, .position = r.Index}
                    If Regex.IsMatch(item.title, "\b(class|struct|enum|interface)\b") Then
                        item.title = item.title.Substring(item.title.LastIndexOf(" ")).Trim()
                        item.type = ExplorerItemTypes.[Class]
                        list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New StructureItemComparer)
                        lastClassIndex = list.Count
                    Else
                        If item.title.Contains(" event ") Then
                            Dim ii As Integer = item.title.LastIndexOf(" ")
                            item.title = item.title.Substring(ii).Trim()
                            item.type = ExplorerItemTypes.[Event]
                        Else
                            If item.title.Contains("(") Then
                                Dim parts As String() = item.title.Split(New Char() {"("})
                                item.title = $"{parts(0).Substring(parts(0).LastIndexOf(" ")).Trim()}({parts(1)}"
                                item.type = ExplorerItemTypes.Method
                            Else
                                If item.title.EndsWith("]") Then
                                    Dim parts As String() = item.title.Split(New Char() {"["})
                                    If parts.Length < 2 Then
                                        Continue For
                                    End If
                                    item.title = $"{parts(0).Substring(parts(0).LastIndexOf(" ")).Trim()}[{parts(1)}"
                                    item.type = ExplorerItemTypes.Method
                                Else
                                    Dim ii As Integer = item.title.LastIndexOf(" ")
                                    item.title = item.title.Substring(ii).Trim()
                                    item.type = ExplorerItemTypes.[Property]
                                End If
                            End If
                        End If
                    End If
                    list.Add(item)
                Catch ex_2BF As Exception
                    Console.WriteLine(ex_2BF)
                End Try
            Next
            list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New StructureItemComparer)
            If list IsNot ExplorerList Then
                MyBase.BeginInvoke(Sub()
                                       ExplorerList = list
                                   End Sub)
                LoadObject()
            End If
        Catch ex_332 As Exception
            Console.WriteLine(ex_332)
        End Try
    End Sub

    Private Sub LoadObject()
        tvStructure.Nodes.Clear()
        Dim lastNode As New TreeNode
        For Each item As StructureItem_Old In ExplorerList
            Select Case item.type
                Case ExplorerItemTypes.Class
                    Dim node As New TreeNode
                    node.Text = item.title
                    node.ImageKey = "Class"
                    node.SelectedImageKey = "Class"
                    tvStructure.Nodes.Add(node)
                    lastNode = node
                Case ExplorerItemTypes.Variable
                    Dim node As New TreeNode
                    node.Text = item.title
                    node.ImageKey = "Property"
                    node.SelectedImageKey = "Property"
                    lastNode.Nodes.Add(node)
                Case ExplorerItemTypes.Property
                    Dim node As New TreeNode
                    node.Text = item.title
                    node.ImageKey = "Property"
                    node.SelectedImageKey = "Property"
                    lastNode.Nodes.Add(node)
                Case ExplorerItemTypes.Method
                    Dim node As New TreeNode
                    node.Text = item.title
                    node.ImageKey = "Method"
                    node.SelectedImageKey = "Method"
                    lastNode.Nodes.Add(node)
                Case ExplorerItemTypes.Event
                    Dim node As New TreeNode
                    node.Text = item.title
                    node.ImageKey = "Event"
                    node.SelectedImageKey = "Event"
                    lastNode.Nodes.Add(node)
                Case ExplorerItemTypes.Operator
                    Dim node As New TreeNode
                    node.Text = item.title
                    node.ImageKey = "Property"
                    node.SelectedImageKey = "Property"
                    lastNode.Nodes.Add(node)
            End Select
        Next
    End Sub

#End Region

#Region "VB.NET"

    Public Sub LoadVb(code As String)
        Dim tree As VisualBasicSyntaxTree = SyntaxFactory.ParseSyntaxTree(code)
        Dim root As VisualBasicSyntaxNode = tree.GetRoot()
        Dim list As New List(Of StructureItem)
        Dim i As Integer = 1
        WalkVbTree(root.ChildNodes(), Nothing, i, list)
        LoadResults(list)
        Dim lRegions As List(Of RegionDirectiveTriviaSyntax) = root.DescendantNodes(descendIntoTrivia:=True).OfType(Of RegionDirectiveTriviaSyntax).ToList()
        For Each reg As RegionDirectiveTriviaSyntax In lRegions
            Console.WriteLine(reg.Name)
        Next
    End Sub

    Private Sub WalkVbTree(nodes As IEnumerable(Of SyntaxNode), parentId As Integer, ByRef i As Integer, ByRef list As List(Of StructureItem))
        For Each n As VisualBasicSyntaxNode In nodes
            Dim objItem As New StructureItem
            If TypeOf n Is ClassBlockSyntax Then
                Dim nC As ClassBlockSyntax = n
                objItem.Id = i
                objItem.Title = nC.ClassStatement.Identifier.ValueText
                objItem.Type = StructureType.Class
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                WalkVbTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is InterfaceBlockSyntax Then
                Dim nI As InterfaceBlockSyntax = n
                objItem.Id = i
                objItem.Title = nI.InterfaceStatement.Identifier.ValueText
                objItem.Type = StructureType.Interface
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                WalkVbTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is StructureBlockSyntax Then
                Dim nS As StructureBlockSyntax = n
                objItem.Id = i
                objItem.Title = nS.StructureStatement.Identifier.ValueText
                objItem.Type = StructureType.Structure
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                WalkVbTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is EnumBlockSyntax Then
                Dim nE As EnumBlockSyntax = n
                Dim eParent As Integer = i
                objItem.Id = i
                objItem.Title = nE.EnumStatement.Identifier.ValueText
                objItem.Type = StructureType.Enum
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                objItem = New StructureItem
                i += 1
                For Each e As EnumMemberDeclarationSyntax In nE.Members.OfType(Of EnumMemberDeclarationSyntax)
                    objItem.Id = i
                    objItem.Title = e.Identifier.ValueText
                    objItem.Type = StructureType.Enum
                    objItem.ParentId = eParent
                    list.Add(objItem)
                    objItem.Position = n.SpanStart
                    objItem = New StructureItem
                    i += 1
                Next
            ElseIf TypeOf n Is NamespaceBlockSyntax Then
                Dim nN As NamespaceBlockSyntax = n
                objItem.Id = i
                objItem.Title = nN.NamespaceStatement.Name.ToFullString
                objItem.Type = StructureType.Namespace
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                WalkVbTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is RegionDirectiveTriviaSyntax Then
                Dim nR As RegionDirectiveTriviaSyntax = n
                objItem.Id = i
                objItem.Title = nR.Name.ValueText
                objItem.Type = StructureType.Region
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                WalkVbTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is MethodBlockSyntax Then
                Dim nM As MethodStatementSyntax = CType(n, MethodBlockSyntax).SubOrFunctionStatement
                objItem.Id = i
                objItem.Title = $"{nM.Identifier.ValueText}{FormatParameters(nM.ParameterList)}"
                If nM.AsClause IsNot Nothing Then objItem.Title &= $" As {nM.AsClause.Type}"
                objItem.Type = StructureType.Method
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is MethodStatementSyntax Then
                Dim nM As MethodStatementSyntax = n
                objItem.Id = i
                objItem.Title = $"{nM.Identifier.ValueText}{FormatParameters(nM.ParameterList)}"
                If nM.AsClause IsNot Nothing Then objItem.Title &= $" As {nM.AsClause.Type}"
                objItem.Type = StructureType.Method
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is ConstructorBlockSyntax Then
                Dim nM As SubNewStatementSyntax = CType(n, ConstructorBlockSyntax).SubNewStatement
                objItem.Id = i
                objItem.Title = $"New{FormatParameters(nM.ParameterList)}"
                objItem.Type = StructureType.Method
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is PropertyBlockSyntax Then
                Dim nP As PropertyStatementSyntax = CType(n, PropertyBlockSyntax).PropertyStatement
                objItem.Id = i
                objItem.Title = $"{nP.Identifier.ValueText}{FormatParameters(nP.ParameterList)}"
                If nP.AsClause IsNot Nothing Then objItem.Title &= $" As {nP.AsClause.Type}"
                objItem.Type = StructureType.Property
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is PropertyStatementSyntax Then
                Dim nP As PropertyStatementSyntax = n
                objItem.Id = i
                objItem.Title = $"{nP.Identifier.ValueText}{FormatParameters(nP.ParameterList)}"
                If nP.AsClause IsNot Nothing Then objItem.Title &= $" As {nP.AsClause.Type}"
                objItem.Type = StructureType.Property
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is EventBlockSyntax Then
                Dim nE As EventStatementSyntax = CType(n, EventBlockSyntax).EventStatement
                objItem.Id = i
                objItem.Title = $"{nE.Identifier.ValueText}{FormatParameters(nE.ParameterList)}"
                If nE.AsClause IsNot Nothing Then objItem.Title &= $" As {nE.AsClause.Type}"
                objItem.Type = StructureType.Event
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is EventStatementSyntax Then
                Dim nE As EventStatementSyntax = n
                objItem.Id = i
                objItem.Title = $"{nE.Identifier.ValueText}{FormatParameters(nE.ParameterList)}"
                If nE.AsClause IsNot Nothing Then objItem.Title &= $" As {nE.AsClause.Type}"
                objItem.Type = StructureType.Event
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is OperatorBlockSyntax Then
                Dim nO As OperatorStatementSyntax = CType(n, OperatorBlockSyntax).OperatorStatement
                objItem.Id = i
                objItem.Title = $"{nO.OperatorToken.ValueText}{FormatParameters(nO.ParameterList)}"
                If nO.AsClause IsNot Nothing Then objItem.Title &= $" As {nO.AsClause.Type}"
                objItem.Type = StructureType.Operator
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is OperatorStatementSyntax Then
                Dim nO As OperatorStatementSyntax = n
                objItem.Id = i
                objItem.Title = $"{nO.OperatorToken.ValueText}{FormatParameters(nO.ParameterList)}"
                If nO.AsClause IsNot Nothing Then objItem.Title &= $" As {nO.AsClause.Type}"
                objItem.Type = StructureType.Operator
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is FieldDeclarationSyntax Then
                Dim nF As FieldDeclarationSyntax = n
                For Each dec As VariableDeclaratorSyntax In nF.Declarators
                    objItem.Id = i
                    objItem.Title = dec.Names.First.ToString
                    If dec.AsClause IsNot Nothing Then objItem.Title &= $" As {dec.AsClause.Type}"
                    objItem.Type = StructureType.Variable
                    objItem.ParentId = parentId
                    objItem.Position = n.SpanStart
                    list.Add(objItem)
                    objItem = New StructureItem
                    i += 1
                Next
            End If
            i += 1
        Next
    End Sub

    Private Function FormatParameters(params As ParameterListSyntax) As String
        If params Is Nothing Then Return String.Empty
        Dim strResult As String = "("
        If params.Parameters.Any Then
            For Each p As ParameterSyntax In params.Parameters
                strResult &= p.Identifier.Identifier.ValueText
                Dim nA As SimpleAsClauseSyntax = p.AsClause
                If nA IsNot Nothing Then
                    strResult &= $" As {nA.Type}"
                End If
                strResult &= ", "
            Next
            strResult = strResult.Remove(strResult.Length - 2)
        End If
        strResult &= ")"
        Return strResult
    End Function

#End Region

#Region "Load"

    Private Sub LoadResults(list As List(Of StructureItem))
        If lResults Is Nothing OrElse Not IsListEqual(list, lResults) Then
            Dim dState As Dictionary(Of String, Boolean) = GetExpandState()
            tvStructure.Nodes.Clear()
            For Each item As StructureItem In list.Where(Function(x) x.ParentId = Nothing)
                Dim nItem As TreeNode = tvStructure.Nodes.Add(item.Id.ToString, item.Title, GetImageKey(item.Type), GetImageKey(item.Type))
                nItem.Tag = item
                WalkExplorerItem(nItem, list.Where(Function(x) x.ParentId = item.Id).ToList, list)
            Next
            lResults = list
            RestoreState(dState)
        End If
    End Sub

    Private Function GetExpandState() As Dictionary(Of String, Boolean)
        Dim dResults As New Dictionary(Of String, Boolean)
        WalkTreeViewGet(tvStructure.Nodes, dResults)
        Return dResults
    End Function

    Private Sub WalkTreeViewGet(nodes As TreeNodeCollection, ByRef dResults As Dictionary(Of String, Boolean))
        For Each node As TreeNode In nodes
            dResults.Add(node.Text, node.IsExpanded)
            WalkTreeViewGet(node.Nodes, dResults)
        Next
    End Sub

    Private Sub RestoreState(dState As Dictionary(Of String, Boolean))
        WalkTreeViewSet(tvStructure.Nodes, dState)
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