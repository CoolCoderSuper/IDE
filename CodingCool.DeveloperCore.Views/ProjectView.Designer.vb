<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProjectView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim TreeNode61 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Windows application")
        Dim TreeNode62 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("WPF")
        Dim TreeNode63 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("VB", New System.Windows.Forms.TreeNode() {TreeNode61, TreeNode62})
        Dim TreeNode64 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Windows application")
        Dim TreeNode65 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("WPF")
        Dim TreeNode66 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("C#", New System.Windows.Forms.TreeNode() {TreeNode64, TreeNode65})
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tvCategories = New System.Windows.Forms.TreeView()
        Me.lvTemplates = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxType = New System.Windows.Forms.ComboBox()
        Me.cbxVersion = New System.Windows.Forms.ComboBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtProjectName = New System.Windows.Forms.TextBox()
        Me.txtSolutionName = New System.Windows.Forms.TextBox()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.cbCreateDir = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(6, 32)
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
        Me.SplitContainer1.SplitterDistance = 188
        Me.SplitContainer1.TabIndex = 0
        '
        'tvCategories
        '
        Me.tvCategories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvCategories.Location = New System.Drawing.Point(0, 0)
        Me.tvCategories.Name = "tvCategories"
        TreeNode61.Name = "NVWIN"
        TreeNode61.Text = "Windows application"
        TreeNode62.Name = "NVBWPF"
        TreeNode62.Text = "WPF"
        TreeNode63.Name = "NVB"
        TreeNode63.Text = "VB"
        TreeNode64.Name = "NCWIN"
        TreeNode64.Text = "Windows application"
        TreeNode65.Name = "NCWPF"
        TreeNode65.Text = "WPF"
        TreeNode66.Name = "NCS"
        TreeNode66.Text = "C#"
        Me.tvCategories.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode63, TreeNode66})
        Me.tvCategories.Size = New System.Drawing.Size(188, 296)
        Me.tvCategories.TabIndex = 0
        '
        'lvTemplates
        '
        Me.lvTemplates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvTemplates.HideSelection = False
        Me.lvTemplates.Location = New System.Drawing.Point(0, 0)
        Me.lvTemplates.Name = "lvTemplates"
        Me.lvTemplates.Size = New System.Drawing.Size(386, 296)
        Me.lvTemplates.TabIndex = 0
        Me.lvTemplates.UseCompatibleStateImageBehavior = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Categories: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Templates: "
        '
        'cbxType
        '
        Me.cbxType.FormattingEnabled = True
        Me.cbxType.Items.AddRange(New Object() {".NET", ".NET Framework", "Mono"})
        Me.cbxType.Location = New System.Drawing.Point(293, 5)
        Me.cbxType.Name = "cbxType"
        Me.cbxType.Size = New System.Drawing.Size(101, 21)
        Me.cbxType.TabIndex = 3
        '
        'cbxVersion
        '
        Me.cbxVersion.FormattingEnabled = True
        Me.cbxVersion.Location = New System.Drawing.Point(401, 5)
        Me.cbxVersion.Name = "cbxVersion"
        Me.cbxVersion.Size = New System.Drawing.Size(183, 21)
        Me.cbxVersion.TabIndex = 4
        '
        'lblDescription
        '
        Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDescription.Location = New System.Drawing.Point(6, 331)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(578, 23)
        Me.lblDescription.TabIndex = 5
        '
        'txtProjectName
        '
        Me.txtProjectName.Location = New System.Drawing.Point(156, 366)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(428, 20)
        Me.txtProjectName.TabIndex = 6
        '
        'txtSolutionName
        '
        Me.txtSolutionName.Location = New System.Drawing.Point(156, 418)
        Me.txtSolutionName.Name = "txtSolutionName"
        Me.txtSolutionName.Size = New System.Drawing.Size(283, 20)
        Me.txtSolutionName.TabIndex = 7
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(156, 392)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(386, 20)
        Me.txtLocation.TabIndex = 8
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(549, 392)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(35, 23)
        Me.btnBrowse.TabIndex = 9
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'cbCreateDir
        '
        Me.cbCreateDir.AutoSize = True
        Me.cbCreateDir.Location = New System.Drawing.Point(445, 420)
        Me.cbCreateDir.Name = "cbCreateDir"
        Me.cbCreateDir.Size = New System.Drawing.Size(139, 17)
        Me.cbCreateDir.TabIndex = 10
        Me.cbCreateDir.Text = "Create solution directory"
        Me.cbCreateDir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 369)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Project name: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 395)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Location: "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 424)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Solution name: "
        '
        'ProjectView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbCreateDir)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.txtSolutionName)
        Me.Controls.Add(Me.txtProjectName)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.cbxVersion)
        Me.Controls.Add(Me.cbxType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ProjectView"
        Me.Size = New System.Drawing.Size(597, 449)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
    Friend WithEvents tvCategories As Windows.Forms.TreeView
    Friend WithEvents lvTemplates As Windows.Forms.ListView
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents cbxType As Windows.Forms.ComboBox
    Friend WithEvents cbxVersion As Windows.Forms.ComboBox
    Friend WithEvents lblDescription As Windows.Forms.Label
    Friend WithEvents txtProjectName As Windows.Forms.TextBox
    Friend WithEvents txtSolutionName As Windows.Forms.TextBox
    Friend WithEvents txtLocation As Windows.Forms.TextBox
    Friend WithEvents btnBrowse As Windows.Forms.Button
    Friend WithEvents cbCreateDir As Windows.Forms.CheckBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
End Class
