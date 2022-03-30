Imports FarsiLibrary.Win

Public Class WinFormsPage
    Inherits FATabStripItem

#Region "Components"

    Friend WithEvents lstToolBox As ListView
    Friend WithEvents splitterMain As SplitContainer

#End Region

#Region "Properties"

    Public Property Lanuage As FastColoredTextBoxNS.Language

    Public Property SelectedItem As Control

    Public Property ParentItem As Control

#End Region

#Region "Events"

    Public Event ControlSelected(sender As Object)

#End Region

#Region "Variables"

    Private bInMove As Boolean = False
    Private bInAdd As Boolean = False
    Private bIsAddValid As Boolean = False
    Private curMoveCursor As Cursor = Cursors.SizeAll
    Private curInvalidLocation As Cursor = Cursors.No
    Private MouseDownMoveLocation As Drawing.Point

#End Region

#Region "Initialization"

    Public Sub New(l As FastColoredTextBoxNS.Language)
        Lanuage = l
        InitializeComponent()
        Dim frm As Form = New Form With {
        .TopLevel = False,
        .TopMost = True
        }
        SelectedItem = frm
        ParentItem = frm
        splitterMain.Panel1.Controls.Add(frm)
        For Each ctrl As Control In ParentItem.Controls
            AddHandler ctrl.MouseDown, AddressOf Control_MouseDown
            AddHandler ctrl.MouseMove, AddressOf Control_MouseMove
            AddHandler ctrl.MouseUp, AddressOf Control_MouseUp
        Next
        AddHandler frm.MouseDown, AddressOf Control_MouseDown
        frm.Show()
        lstToolBox.Items(0).Tag = New Button
    End Sub

    Private Sub InitializeComponent()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Button")
        splitterMain = New System.Windows.Forms.SplitContainer
        lstToolBox = New System.Windows.Forms.ListView
        CType(splitterMain, System.ComponentModel.ISupportInitialize).BeginInit()
        splitterMain.Panel2.SuspendLayout()
        splitterMain.SuspendLayout()
        SuspendLayout()
        '
        'splitterMain
        '
        splitterMain.Dock = System.Windows.Forms.DockStyle.Fill
        splitterMain.Location = New System.Drawing.Point(0, 0)
        splitterMain.Name = "splitterMain"
        '
        'splitterMain.Panel2
        '
        splitterMain.Panel2.Controls.Add(lstToolBox)
        splitterMain.Size = New System.Drawing.Size(200, 100)
        splitterMain.SplitterDistance = 66
        splitterMain.TabIndex = 0
        '
        'lstToolBox
        '
        lstToolBox.Dock = System.Windows.Forms.DockStyle.Fill
        lstToolBox.HideSelection = False
        lstToolBox.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        lstToolBox.Location = New System.Drawing.Point(0, 0)
        lstToolBox.Name = "lstToolBox"
        lstToolBox.Size = New System.Drawing.Size(130, 100)
        lstToolBox.TabIndex = 0
        lstToolBox.UseCompatibleStateImageBehavior = False
        '
        'WinFormsPage
        '
        Controls.Add(splitterMain)
        splitterMain.Panel2.ResumeLayout(False)
        CType(splitterMain, System.ComponentModel.ISupportInitialize).EndInit()
        splitterMain.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

#End Region

#Region "ControlMoveSelection"

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            SelectedItem = CType(sender, Control)
            RaiseEvent ControlSelected(Me)
            MouseDownMoveLocation = e.Location
        End If
        If TypeOf SelectedItem IsNot Form Then
            bInMove = True
        End If
    End Sub

    Private Sub Control_MouseMove(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left And bInMove Then
            For Each ctrl As Control In ParentItem.Controls
                ctrl.Cursor = curMoveCursor
            Next
            ParentItem.Cursor = curMoveCursor
            SelectedItem.Left = e.X + SelectedItem.Left - MouseDownMoveLocation.X
            SelectedItem.Top = e.Y + SelectedItem.Top - MouseDownMoveLocation.Y
        End If
    End Sub

    Private Sub Control_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left And bInMove Then
            For Each ctrl As Control In ParentItem.Controls
                ctrl.Cursor = Cursors.Default
            Next
            ParentItem.Cursor = Cursors.Default
            bInMove = False
        End If
    End Sub

#End Region

#Region "ControlAdd"

    'Private Sub lstToolBox_MouseDown(sender As Object, e As MouseEventArgs) Handles lstToolBox.MouseDown
    '    If e.Button = MouseButtons.Left Then
    '        bInAdd = True
    '    End If
    'End Sub

    'Private Sub lstToolBox_MouseMove(sender As Object, e As MouseEventArgs) Handles lstToolBox.MouseMove
    '    If e.Button = MouseButtons.Left And bInAdd = True Then
    '        If ParentItem.Bounds.Contains(e.Location) Then
    '            ParentItem.Cursor = Cursors.Default
    '            bIsAddValid = True
    '        Else
    '            ParentItem.Cursor = curInvalidLocation
    '            bIsAddValid = False
    '        End If
    '    End If
    'End Sub

    'Private Sub lstToolBox_MouseUp(sender As Object, e As MouseEventArgs) Handles lstToolBox.MouseUp
    '    If bIsAddValid Then
    '        AddItem()
    '    End If
    '    bInAdd = False
    'End Sub

    Private Sub lstToolBox_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstToolBox.MouseDoubleClick
        AddItem()
    End Sub

    Private Sub AddItem()
        If lstToolBox.SelectedItems.Count > 0 Then
            Dim ctrl As Control = lstToolBox.SelectedItems(0).Tag
            If ctrl IsNot Nothing Then
                ParentItem.Controls.Add(ctrl)
                AddHandler ctrl.MouseDown, AddressOf Control_MouseDown
                AddHandler ctrl.MouseMove, AddressOf Control_MouseMove
                AddHandler ctrl.MouseUp, AddressOf Control_MouseUp
            End If
            lstToolBox.SelectedItems(0).Tag = New Button
        End If
    End Sub

#End Region

End Class