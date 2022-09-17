<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReferencesView
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpGAC = New System.Windows.Forms.TabPage()
        Me.cbSpecificVersion = New System.Windows.Forms.CheckBox()
        Me.txtGACSearch = New System.Windows.Forms.TextBox()
        Me.dgvGAC = New System.Windows.Forms.DataGridView()
        Me.tpCOM = New System.Windows.Forms.TabPage()
        Me.txtCOMSearch = New System.Windows.Forms.TextBox()
        Me.dgvCOM = New System.Windows.Forms.DataGridView()
        Me.tpBrowse = New System.Windows.Forms.TabPage()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.dgvBrowse = New System.Windows.Forms.DataGridView()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.dgvSelected = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout
        Me.tpGAC.SuspendLayout
        CType(Me.dgvGAC,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tpCOM.SuspendLayout
        CType(Me.dgvCOM,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tpBrowse.SuspendLayout
        CType(Me.dgvBrowse,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dgvSelected,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpGAC)
        Me.TabControl1.Controls.Add(Me.tpCOM)
        Me.TabControl1.Controls.Add(Me.tpBrowse)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Multiline = true
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(468, 224)
        Me.TabControl1.TabIndex = 0
        '
        'tpGAC
        '
        Me.tpGAC.Controls.Add(Me.cbSpecificVersion)
        Me.tpGAC.Controls.Add(Me.txtGACSearch)
        Me.tpGAC.Controls.Add(Me.dgvGAC)
        Me.tpGAC.Location = New System.Drawing.Point(4, 22)
        Me.tpGAC.Name = "tpGAC"
        Me.tpGAC.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGAC.Size = New System.Drawing.Size(460, 198)
        Me.tpGAC.TabIndex = 0
        Me.tpGAC.Text = "GAC"
        Me.tpGAC.UseVisualStyleBackColor = true
        '
        'cbSpecificVersion
        '
        Me.cbSpecificVersion.AutoSize = true
        Me.cbSpecificVersion.Location = New System.Drawing.Point(224, 9)
        Me.cbSpecificVersion.Name = "cbSpecificVersion"
        Me.cbSpecificVersion.Size = New System.Drawing.Size(101, 17)
        Me.cbSpecificVersion.TabIndex = 3
        Me.cbSpecificVersion.Text = "Specific version"
        Me.cbSpecificVersion.UseVisualStyleBackColor = true
        '
        'txtGACSearch
        '
        Me.txtGACSearch.Location = New System.Drawing.Point(6, 7)
        Me.txtGACSearch.Name = "txtGACSearch"
        Me.txtGACSearch.Size = New System.Drawing.Size(212, 20)
        Me.txtGACSearch.TabIndex = 2
        '
        'dgvGAC
        '
        Me.dgvGAC.AllowUserToAddRows = false
        Me.dgvGAC.AllowUserToDeleteRows = false
        Me.dgvGAC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGAC.Location = New System.Drawing.Point(0, 33)
        Me.dgvGAC.Name = "dgvGAC"
        Me.dgvGAC.ReadOnly = true
        Me.dgvGAC.Size = New System.Drawing.Size(460, 165)
        Me.dgvGAC.TabIndex = 1
        '
        'tpCOM
        '
        Me.tpCOM.Controls.Add(Me.txtCOMSearch)
        Me.tpCOM.Controls.Add(Me.dgvCOM)
        Me.tpCOM.Location = New System.Drawing.Point(4, 22)
        Me.tpCOM.Name = "tpCOM"
        Me.tpCOM.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCOM.Size = New System.Drawing.Size(460, 198)
        Me.tpCOM.TabIndex = 1
        Me.tpCOM.Text = "COM"
        Me.tpCOM.UseVisualStyleBackColor = true
        '
        'txtCOMSearch
        '
        Me.txtCOMSearch.Location = New System.Drawing.Point(7, 7)
        Me.txtCOMSearch.Name = "txtCOMSearch"
        Me.txtCOMSearch.Size = New System.Drawing.Size(212, 20)
        Me.txtCOMSearch.TabIndex = 1
        '
        'dgvCOM
        '
        Me.dgvCOM.AllowUserToAddRows = false
        Me.dgvCOM.AllowUserToDeleteRows = false
        Me.dgvCOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCOM.Location = New System.Drawing.Point(0, 33)
        Me.dgvCOM.Name = "dgvCOM"
        Me.dgvCOM.ReadOnly = true
        Me.dgvCOM.Size = New System.Drawing.Size(460, 165)
        Me.dgvCOM.TabIndex = 0
        '
        'tpBrowse
        '
        Me.tpBrowse.Controls.Add(Me.btnBrowse)
        Me.tpBrowse.Controls.Add(Me.dgvBrowse)
        Me.tpBrowse.Location = New System.Drawing.Point(4, 22)
        Me.tpBrowse.Name = "tpBrowse"
        Me.tpBrowse.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBrowse.Size = New System.Drawing.Size(460, 198)
        Me.tpBrowse.TabIndex = 2
        Me.tpBrowse.Text = "Browse"
        Me.tpBrowse.UseVisualStyleBackColor = true
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(6, 7)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(448, 23)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = true
        '
        'dgvBrowse
        '
        Me.dgvBrowse.AllowUserToAddRows = false
        Me.dgvBrowse.AllowUserToDeleteRows = false
        Me.dgvBrowse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBrowse.Location = New System.Drawing.Point(3, 36)
        Me.dgvBrowse.Name = "dgvBrowse"
        Me.dgvBrowse.ReadOnly = true
        Me.dgvBrowse.Size = New System.Drawing.Size(454, 159)
        Me.dgvBrowse.TabIndex = 0
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(473, 25)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 1
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = true
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(4, 230)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Selected assemblies: "
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(473, 246)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = true
        '
        'dgvSelected
        '
        Me.dgvSelected.AllowUserToAddRows = false
        Me.dgvSelected.AllowUserToDeleteRows = false
        Me.dgvSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSelected.Location = New System.Drawing.Point(7, 246)
        Me.dgvSelected.Name = "dgvSelected"
        Me.dgvSelected.ReadOnly = true
        Me.dgvSelected.Size = New System.Drawing.Size(460, 151)
        Me.dgvSelected.TabIndex = 4
        '
        'ReferencesView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgvSelected)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ReferencesView"
        Me.Size = New System.Drawing.Size(555, 400)
        Me.TabControl1.ResumeLayout(false)
        Me.tpGAC.ResumeLayout(false)
        Me.tpGAC.PerformLayout
        CType(Me.dgvGAC,System.ComponentModel.ISupportInitialize).EndInit
        Me.tpCOM.ResumeLayout(false)
        Me.tpCOM.PerformLayout
        CType(Me.dgvCOM,System.ComponentModel.ISupportInitialize).EndInit
        Me.tpBrowse.ResumeLayout(false)
        CType(Me.dgvBrowse,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dgvSelected,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents tpGAC As Windows.Forms.TabPage
    Friend WithEvents tpCOM As Windows.Forms.TabPage
    Friend WithEvents tpBrowse As Windows.Forms.TabPage
    Friend WithEvents btnSelect As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btnRemove As Windows.Forms.Button
    Friend WithEvents dgvSelected As Windows.Forms.DataGridView
    Friend WithEvents dgvBrowse As Windows.Forms.DataGridView
    Friend WithEvents dgvCOM As Windows.Forms.DataGridView
    Friend WithEvents txtCOMSearch As Windows.Forms.TextBox
    Friend WithEvents dgvGAC As Windows.Forms.DataGridView
    Friend WithEvents txtGACSearch As Windows.Forms.TextBox
    Friend WithEvents cbSpecificVersion As Windows.Forms.CheckBox
    Friend WithEvents btnBrowse As Windows.Forms.Button
End Class
