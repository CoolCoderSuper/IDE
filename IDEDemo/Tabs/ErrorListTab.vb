Imports FarsiLibrary.Win
Public Class ErrorListTab
    Inherits FATabStripItem

    Friend WithEvents dgvErrors As DataGridView

    Private Sub InitializeComponent()
        Me.dgvErrors = New System.Windows.Forms.DataGridView()
        CType(Me.dgvErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvErrors
        '
        Me.dgvErrors.AllowUserToAddRows = False
        Me.dgvErrors.AllowUserToDeleteRows = False
        Me.dgvErrors.AllowUserToResizeRows = False
        Me.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvErrors.Location = New System.Drawing.Point(0, 0)
        Me.dgvErrors.Name = "dgvErrors"
        Me.dgvErrors.ReadOnly = True
        Me.dgvErrors.RowHeadersVisible = False
        Me.dgvErrors.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvErrors.ShowCellErrors = False
        Me.dgvErrors.ShowCellToolTips = False
        Me.dgvErrors.ShowEditingIcon = False
        Me.dgvErrors.ShowRowErrors = False
        Me.dgvErrors.Size = New System.Drawing.Size(240, 150)
        Me.dgvErrors.TabIndex = 0
        CType(Me.dgvErrors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class
