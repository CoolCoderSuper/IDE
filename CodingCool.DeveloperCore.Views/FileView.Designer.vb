<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tvCategories = New System.Windows.Forms.TreeView()
        Me.lvTemplates = New System.Windows.Forms.ListView()
        Me.ilItems = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        Me.SuspendLayout
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(32, 373)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Name: "
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(161, 370)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(429, 20)
        Me.txtName.TabIndex = 20
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDescription.Location = New System.Drawing.Point(11, 335)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(579, 23)
        Me.lblDescription.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(150, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Templates: "
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(8, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Categories: "
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(11, 35)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvCategories)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvTemplates)
        Me.SplitContainer1.Size = New System.Drawing.Size(578, 296)
        Me.SplitContainer1.SplitterDistance = 138
        Me.SplitContainer1.TabIndex = 14
        '
        'tvCategories
        '
        Me.tvCategories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvCategories.Location = New System.Drawing.Point(0, 0)
        Me.tvCategories.Name = "tvCategories"
        Me.tvCategories.Size = New System.Drawing.Size(138, 296)
        Me.tvCategories.TabIndex = 0
        '
        'lvTemplates
        '
        Me.lvTemplates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvTemplates.HideSelection = false
        Me.lvTemplates.LargeImageList = Me.ilItems
        Me.lvTemplates.Location = New System.Drawing.Point(0, 0)
        Me.lvTemplates.MultiSelect = false
        Me.lvTemplates.Name = "lvTemplates"
        Me.lvTemplates.Size = New System.Drawing.Size(436, 296)
        Me.lvTemplates.SmallImageList = Me.ilItems
        Me.lvTemplates.TabIndex = 0
        Me.lvTemplates.UseCompatibleStateImageBehavior = false
        '
        'ilItems
        '
        Me.ilItems.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ilItems.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilItems.TransparentColor = System.Drawing.Color.Transparent
        '
        'FileView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FileView"
        Me.Size = New System.Drawing.Size(598, 397)
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txtName As Windows.Forms.TextBox
    Friend WithEvents lblDescription As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
    Friend WithEvents tvCategories As Windows.Forms.TreeView
    Friend WithEvents lvTemplates As Windows.Forms.ListView
    Friend WithEvents ilItems As Windows.Forms.ImageList
End Class
