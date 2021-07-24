Imports FarsiLibrary.Win

Public Class TaskListTab
    Inherits FATabStripItem

    Friend WithEvents dgvTasks As DataGridView

    Private Sub InitializeComponent()
        Me.dgvTasks = New System.Windows.Forms.DataGridView()
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvTasks
        '
        Me.dgvTasks.AllowUserToAddRows = False
        Me.dgvTasks.AllowUserToDeleteRows = False
        Me.dgvTasks.AllowUserToResizeRows = False
        Me.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTasks.Location = New System.Drawing.Point(0, 0)
        Me.dgvTasks.Name = "dgvTasks"
        Me.dgvTasks.ReadOnly = True
        Me.dgvTasks.RowHeadersVisible = False
        Me.dgvTasks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTasks.ShowCellErrors = False
        Me.dgvTasks.ShowCellToolTips = False
        Me.dgvTasks.ShowEditingIcon = False
        Me.dgvTasks.ShowRowErrors = False
        Me.dgvTasks.Size = New System.Drawing.Size(240, 150)
        Me.dgvTasks.TabIndex = 0
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class
