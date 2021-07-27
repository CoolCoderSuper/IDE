Imports System.Windows.Forms
Imports FarsiLibrary.Win
Public Class ErrorListTab
    Inherits FATabStripItem

#Region "Components"
    Friend WithEvents cImage As DataGridViewImageColumn
    Friend WithEvents cCode As DataGridViewLinkColumn
    Friend WithEvents cDescription As DataGridViewTextBoxColumn
    Friend WithEvents cFile As DataGridViewTextBoxColumn
    Friend WithEvents cLine As DataGridViewTextBoxColumn
    Friend WithEvents dgvErrors As DataGridView
#End Region

#Region "Intialization"
    Private Sub InitializeComponent()
        Me.dgvErrors = New System.Windows.Forms.DataGridView()
        Me.cImage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.cCode = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.cDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvErrors
        '
        Me.dgvErrors.AllowUserToAddRows = False
        Me.dgvErrors.AllowUserToDeleteRows = False
        Me.dgvErrors.AllowUserToResizeRows = False
        Me.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvErrors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cImage, Me.cCode, Me.cDescription, Me.cFile, Me.cLine})
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
        '
        'cImage
        '
        Me.cImage.HeaderText = ""
        Me.cImage.Name = "cImage"
        Me.cImage.ReadOnly = True
        '
        'cCode
        '
        Me.cCode.HeaderText = "Code"
        Me.cCode.Name = "cCode"
        Me.cCode.ReadOnly = True
        Me.cCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'cDescription
        '
        Me.cDescription.HeaderText = "Description"
        Me.cDescription.Name = "cDescription"
        Me.cDescription.ReadOnly = True
        '
        'cFile
        '
        Me.cFile.HeaderText = "File"
        Me.cFile.Name = "cFile"
        Me.cFile.ReadOnly = True
        '
        'cLine
        '
        Me.cLine.HeaderText = "Line"
        Me.cLine.Name = "cLine"
        Me.cLine.ReadOnly = True
        '
        'ErrorListTab
        '
        Me.Title = "Error List"
        CType(Me.dgvErrors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

End Class
