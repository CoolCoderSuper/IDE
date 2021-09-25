Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports CodingCool.DeveloperCore.Core

Public Class ObjectExplorerTab
    Inherits TabPage

#Region "Components"
    WithEvents ilImages As ImageList
    WithEvents tvObjectExplorer As TreeView
#End Region

    Public Property ExplorerList As New List(Of ExplorerItem)

#Region "Initialization"
    Public Sub New()
        ilImages = New ImageList
        ilImages.Images.Add("Class", My.Resources.Icons_16x16_Class)
        ilImages.Images.Add("Event", My.Resources.Icons_16x16_Event)
        ilImages.Images.Add("Method", My.Resources.Icons_16x16_Method)
        ilImages.Images.Add("Property", My.Resources.Icons_16x16_Property)
        Text = "Object Explorer"
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.tvObjectExplorer = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'tvObjectExplorer
        '
        Me.tvObjectExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvObjectExplorer.LineColor = System.Drawing.Color.Empty
        Me.tvObjectExplorer.Location = New System.Drawing.Point(0, 0)
        Me.tvObjectExplorer.Name = "tvObjectExplorer"
        Me.tvObjectExplorer.Size = New System.Drawing.Size(200, 100)
        Me.tvObjectExplorer.TabIndex = 0
        tvObjectExplorer.BackColor = ColorTranslator.FromHtml("#8a8a88")
        tvObjectExplorer.ForeColor = Color.White
        tvObjectExplorer.ImageList = ilImages
        '
        'ObjectExplorerTab
        '
        Me.Controls.Add(Me.tvObjectExplorer)
        Me.ResumeLayout(False)

    End Sub
#End Region

#Region "C#"
    Public Sub ReCSharpBuildObjectExplorer(text As String)
        Try
            Dim list As List(Of ExplorerItem) = New List(Of ExplorerItem)()
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
                    Dim item As ExplorerItem = New ExplorerItem() With {.title = s, .position = r.Index}
                    If Regex.IsMatch(item.title, "\b(class|struct|enum|interface)\b") Then
                        item.title = item.title.Substring(item.title.LastIndexOf(" ")).Trim()
                        item.type = ExplorerItemTypes.[Class]
                        list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ExplorerItemComparer())
                        lastClassIndex = list.Count
                    Else
                        If item.title.Contains(" event ") Then
                            Dim ii As Integer = item.title.LastIndexOf(" ")
                            item.title = item.title.Substring(ii).Trim()
                            item.type = ExplorerItemTypes.[Event]
                        Else
                            If item.title.Contains("(") Then
                                Dim parts As String() = item.title.Split(New Char() {"("})
                                item.title = parts(0).Substring(parts(0).LastIndexOf(" ")).Trim() + "(" + parts(1)
                                item.type = ExplorerItemTypes.Method
                            Else
                                If item.title.EndsWith("]") Then
                                    Dim parts As String() = item.title.Split(New Char() {"["})
                                    If parts.Length < 2 Then
                                        Continue For
                                    End If
                                    item.title = parts(0).Substring(parts(0).LastIndexOf(" ")).Trim() + "[" + parts(1)
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
            list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ExplorerItemComparer())
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
#End Region

#Region "VB.NET"
    Public Sub ReBuildVBObjectExplorer(text As String)
        Try
            Dim list As List(Of ExplorerItem) = New List(Of ExplorerItem)()
            Dim lastClassIndex As Integer = -1
            Dim lLines As List(Of String) = text.Split(vbCrLf).ToList
            Dim bDead As Boolean
            For j As Integer = 0 To lLines.Count - 1 Step 1
                Try
                    Dim bSkip As Boolean = False
                    Dim s As String = lLines(j)
                    Dim i As Integer = s.IndexOfAny(New Char() {"=", vbCrLf, vbCrLf})
                    If i >= 0 Then
                        s = s.Substring(0, i)
                    End If
                    s = s.Trim()
                    ' Make sure that it is not private to method or end statement or a comment or a none supported line
                    If Not s.Length = 0 AndAlso s(0) = "'" Then
                        Continue For
                    End If
                    If Not Regex.IsMatch(s, "(?i)\b(class|structure|enum|interface|module|sub|function|property|event|operator|private|public|shadows|shared|dim|const|friend|protected|readonly)\b") Then
                        Continue For
                    End If
                    If bDead = False AndAlso Regex.IsMatch(s, "(?i)\b(sub|function|operator|custom\sevent)\b") Then
                        bSkip = True
                        bDead = True
                    End If
                    If bSkip = False AndAlso bDead = True Then
                        If Regex.IsMatch(s, "(?i)\b(end\ssub|end\sfunction|end\soperator|end\sevent)\b") Then
                            bDead = False
                        End If
                        Continue For
                    End If
                    If Regex.IsMatch(s, "(?i)\b(end\sclass|end\sstructure|end\sinterface|end\senum|end\smodule)\b") Then
                        Continue For
                    End If
                    ' Load the item
                    Dim item As ExplorerItem = New ExplorerItem() With {.title = s, .position = j}
                    If Regex.IsMatch(item.title, "(?i)\b(class|structure|enum|interface|module)\b") Then
                        item.title = item.title.Substring(item.title.LastIndexOf(" ")).Trim()
                        item.type = ExplorerItemTypes.[Class]
                        list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ExplorerItemComparer())
                        lastClassIndex = list.Count
                    Else
                        If Regex.IsMatch(item.title, "(?i)\b(operator|property|function|event|private|public|shadows|shared|dim|const|friend|protected|readonly)\b") Then
                            If Regex.IsMatch(item.title, "(?i)\b(\sproperty\s|property\s)\b") Then
                                item.type = ExplorerItemTypes.Property
                                Dim ii As Integer = item.title.ToLower.LastIndexOf(" property ")
                                If ii < 0 Then
                                    ii = item.title.ToLower.LastIndexOf("property ")
                                End If
                                item.title = item.title.Substring(ii).Trim()
                            ElseIf Regex.IsMatch(item.title, "(?i)\b(\sfunction\s|function\s)\b") Then
                                item.type = ExplorerItemTypes.Method
                                Dim ii As Integer = item.title.ToLower.LastIndexOf(" function ")
                                If ii < 0 Then
                                    ii = item.title.ToLower.LastIndexOf("function ")
                                End If
                                item.title = item.title.Substring(ii).Trim()
                            ElseIf Regex.IsMatch(item.title, "(?i)\b(\sevent\s|event\s)\b") Then
                                item.type = ExplorerItemTypes.Event
                                Dim ii As Integer = item.title.ToLower.LastIndexOf(" event ")
                                If ii < 0 Then
                                    ii = item.title.ToLower.LastIndexOf("event ")
                                End If
                                item.title = item.title.Substring(ii).Trim()
                            ElseIf Regex.IsMatch(item.title, "(?i)\b(\soperator\s)\b") Then
                                item.type = ExplorerItemTypes.Operator
                                Dim ii As Integer = item.title.ToLower.LastIndexOf(" operator ")
                                If ii < 0 Then
                                    ii = item.title.ToLower.LastIndexOf("operator ")
                                End If
                                item.title = item.title.Substring(ii).Trim()
                            ElseIf Regex.IsMatch(item.title, "(?i)\b(private|public|shadows|shared|dim|const|friend|protected|readonly)\b") Then
                                item.type = ExplorerItemTypes.Variable
                                item.title = item.title.Trim
                            End If
                        End If
                        If Regex.IsMatch(item.title, "(?i)\b(\ssub\s|sub\s)\b") Then
                            item.type = ExplorerItemTypes.Method
                            Dim ii As Integer = item.title.ToLower.LastIndexOf(" sub ")
                            If ii < 0 Then
                                ii = item.title.ToLower.LastIndexOf("sub ")
                            End If
                            item.title = item.title.Substring(ii).Trim()
                        End If
                    End If
                    ' Make sure it is not blank
                    If item.title.Trim = "" Then
                        Continue For
                    End If
                    list.Add(item)
                Catch ex_2BF As Exception

                End Try
            Next
            list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ExplorerItemComparer())
            If Helpers.CompareLists(list, ExplorerList) Then
                MyBase.BeginInvoke(Sub()
                                       ExplorerList = list
                                   End Sub)
                LoadObject()
            End If
        Catch ex_332 As Exception

        End Try
    End Sub

    Public Sub LoadVB(text As String)

    End Sub

#End Region

#Region "Load"
    Private Sub LoadObject()
        tvObjectExplorer.Nodes.Clear()
        Dim lastNode As New TreeNode
        For Each item As ExplorerItem In ExplorerList
            Select Case item.type
                Case ExplorerItemTypes.Class
                    Dim node As New TreeNode
                    node.Text = item.title
                    node.ImageKey = "Class"
                    node.SelectedImageKey = "Class"
                    tvObjectExplorer.Nodes.Add(node)
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

End Class
