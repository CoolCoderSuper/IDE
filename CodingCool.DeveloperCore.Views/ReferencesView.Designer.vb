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
        Dim cName As System.Windows.Forms.ColumnHeader
        Dim cVersion As System.Windows.Forms.ColumnHeader
        Dim ColumnHeader1 As System.Windows.Forms.ColumnHeader
        Dim ColumnHeader2 As System.Windows.Forms.ColumnHeader
        Dim ColumnHeader3 As System.Windows.Forms.ColumnHeader
        Dim ColumnHeader4 As System.Windows.Forms.ColumnHeader
        Dim ColumnHeader5 As System.Windows.Forms.ColumnHeader
        Dim ColumnHeader6 As System.Windows.Forms.ColumnHeader
        Dim ColumnHeader7 As System.Windows.Forms.ColumnHeader
        Dim ColumnHeader8 As System.Windows.Forms.ColumnHeader
        Dim ColumnHeader9 As System.Windows.Forms.ColumnHeader
        Me.tcReferences = New System.Windows.Forms.TabControl()
        Me.tpGAC = New System.Windows.Forms.TabPage()
        Me.lvGAC = New System.Windows.Forms.ListView()
        Me.cbSpecificVersion = New System.Windows.Forms.CheckBox()
        Me.txtGACSearch = New System.Windows.Forms.TextBox()
        Me.tpCOM = New System.Windows.Forms.TabPage()
        Me.lvCOM = New System.Windows.Forms.ListView()
        Me.txtCOMSearch = New System.Windows.Forms.TextBox()
        Me.tpBrowse = New System.Windows.Forms.TabPage()
        Me.lvBrowse = New System.Windows.Forms.ListView()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.lvSelected = New System.Windows.Forms.ListView()
        Me.tpProjects = New System.Windows.Forms.TabPage()
        Me.lvProjects = New System.Windows.Forms.ListView()
        cName = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        cVersion = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.tcReferences.SuspendLayout
        Me.tpGAC.SuspendLayout
        Me.tpCOM.SuspendLayout
        Me.tpBrowse.SuspendLayout
        Me.tpProjects.SuspendLayout
        Me.SuspendLayout
        '
        'cName
        '
        cName.Text = "Name"
        cName.Width = 232
        '
        'cVersion
        '
        cVersion.Text = "Version"
        cVersion.Width = 99
        '
        'ColumnHeader1
        '
        ColumnHeader1.Text = "Name"
        ColumnHeader1.Width = 232
        '
        'ColumnHeader2
        '
        ColumnHeader2.Text = "Path"
        ColumnHeader2.Width = 214
        '
        'ColumnHeader3
        '
        ColumnHeader3.Text = "Name"
        ColumnHeader3.Width = 232
        '
        'ColumnHeader4
        '
        ColumnHeader4.Text = "Path"
        ColumnHeader4.Width = 213
        '
        'ColumnHeader5
        '
        ColumnHeader5.Text = "Reference Name"
        ColumnHeader5.Width = 114
        '
        'ColumnHeader6
        '
        ColumnHeader6.Text = "Type"
        '
        'ColumnHeader7
        '
        ColumnHeader7.Text = "Location"
        ColumnHeader7.Width = 235
        '
        'tcReferences
        '
        Me.tcReferences.Controls.Add(Me.tpGAC)
        Me.tcReferences.Controls.Add(Me.tpCOM)
        Me.tcReferences.Controls.Add(Me.tpProjects)
        Me.tcReferences.Controls.Add(Me.tpBrowse)
        Me.tcReferences.Location = New System.Drawing.Point(3, 3)
        Me.tcReferences.Multiline = true
        Me.tcReferences.Name = "tcReferences"
        Me.tcReferences.SelectedIndex = 0
        Me.tcReferences.Size = New System.Drawing.Size(468, 224)
        Me.tcReferences.TabIndex = 0
        '
        'tpGAC
        '
        Me.tpGAC.Controls.Add(Me.lvGAC)
        Me.tpGAC.Controls.Add(Me.cbSpecificVersion)
        Me.tpGAC.Controls.Add(Me.txtGACSearch)
        Me.tpGAC.Location = New System.Drawing.Point(4, 22)
        Me.tpGAC.Name = "tpGAC"
        Me.tpGAC.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGAC.Size = New System.Drawing.Size(460, 198)
        Me.tpGAC.TabIndex = 0
        Me.tpGAC.Text = "GAC"
        Me.tpGAC.UseVisualStyleBackColor = true
        '
        'lvGAC
        '
        Me.lvGAC.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {cName, cVersion})
        Me.lvGAC.FullRowSelect = true
        Me.lvGAC.HideSelection = false
        Me.lvGAC.Location = New System.Drawing.Point(3, 33)
        Me.lvGAC.MultiSelect = false
        Me.lvGAC.Name = "lvGAC"
        Me.lvGAC.Size = New System.Drawing.Size(454, 162)
        Me.lvGAC.TabIndex = 4
        Me.lvGAC.UseCompatibleStateImageBehavior = false
        Me.lvGAC.View = System.Windows.Forms.View.Details
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
        'tpCOM
        '
        Me.tpCOM.Controls.Add(Me.lvCOM)
        Me.tpCOM.Controls.Add(Me.txtCOMSearch)
        Me.tpCOM.Location = New System.Drawing.Point(4, 22)
        Me.tpCOM.Name = "tpCOM"
        Me.tpCOM.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCOM.Size = New System.Drawing.Size(460, 198)
        Me.tpCOM.TabIndex = 3
        Me.tpCOM.Text = "COM"
        Me.tpCOM.UseVisualStyleBackColor = true
        '
        'lvCOM
        '
        Me.lvCOM.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {ColumnHeader3, ColumnHeader4})
        Me.lvCOM.FullRowSelect = true
        Me.lvCOM.HideSelection = false
        Me.lvCOM.Location = New System.Drawing.Point(3, 31)
        Me.lvCOM.MultiSelect = false
        Me.lvCOM.Name = "lvCOM"
        Me.lvCOM.Size = New System.Drawing.Size(454, 162)
        Me.lvCOM.TabIndex = 6
        Me.lvCOM.UseCompatibleStateImageBehavior = false
        Me.lvCOM.View = System.Windows.Forms.View.Details
        '
        'txtCOMSearch
        '
        Me.txtCOMSearch.Location = New System.Drawing.Point(6, 5)
        Me.txtCOMSearch.Name = "txtCOMSearch"
        Me.txtCOMSearch.Size = New System.Drawing.Size(212, 20)
        Me.txtCOMSearch.TabIndex = 5
        '
        'tpBrowse
        '
        Me.tpBrowse.Controls.Add(Me.lvBrowse)
        Me.tpBrowse.Controls.Add(Me.btnBrowse)
        Me.tpBrowse.Location = New System.Drawing.Point(4, 22)
        Me.tpBrowse.Name = "tpBrowse"
        Me.tpBrowse.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBrowse.Size = New System.Drawing.Size(460, 198)
        Me.tpBrowse.TabIndex = 2
        Me.tpBrowse.Text = "Browse"
        Me.tpBrowse.UseVisualStyleBackColor = true
        '
        'lvBrowse
        '
        Me.lvBrowse.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {ColumnHeader1, ColumnHeader2})
        Me.lvBrowse.FullRowSelect = true
        Me.lvBrowse.HideSelection = false
        Me.lvBrowse.Location = New System.Drawing.Point(3, 33)
        Me.lvBrowse.MultiSelect = false
        Me.lvBrowse.Name = "lvBrowse"
        Me.lvBrowse.Size = New System.Drawing.Size(454, 162)
        Me.lvBrowse.TabIndex = 5
        Me.lvBrowse.UseCompatibleStateImageBehavior = false
        Me.lvBrowse.View = System.Windows.Forms.View.Details
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
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(473, 26)
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
        'lvSelected
        '
        Me.lvSelected.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {ColumnHeader5, ColumnHeader6, ColumnHeader7})
        Me.lvSelected.FullRowSelect = true
        Me.lvSelected.HideSelection = false
        Me.lvSelected.Location = New System.Drawing.Point(10, 246)
        Me.lvSelected.MultiSelect = false
        Me.lvSelected.Name = "lvSelected"
        Me.lvSelected.Size = New System.Drawing.Size(454, 151)
        Me.lvSelected.TabIndex = 4
        Me.lvSelected.UseCompatibleStateImageBehavior = false
        Me.lvSelected.View = System.Windows.Forms.View.Details
        '
        'tpProjects
        '
        Me.tpProjects.Controls.Add(Me.lvProjects)
        Me.tpProjects.Location = New System.Drawing.Point(4, 22)
        Me.tpProjects.Name = "tpProjects"
        Me.tpProjects.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProjects.Size = New System.Drawing.Size(460, 198)
        Me.tpProjects.TabIndex = 4
        Me.tpProjects.Text = "Projects"
        Me.tpProjects.UseVisualStyleBackColor = true
        '
        'lvProjects
        '
        Me.lvProjects.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {ColumnHeader8, ColumnHeader9})
        Me.lvProjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvProjects.FullRowSelect = true
        Me.lvProjects.HideSelection = false
        Me.lvProjects.Location = New System.Drawing.Point(3, 3)
        Me.lvProjects.MultiSelect = false
        Me.lvProjects.Name = "lvProjects"
        Me.lvProjects.Size = New System.Drawing.Size(454, 192)
        Me.lvProjects.TabIndex = 6
        Me.lvProjects.UseCompatibleStateImageBehavior = false
        Me.lvProjects.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        ColumnHeader8.Text = "Name"
        ColumnHeader8.Width = 232
        '
        'ColumnHeader9
        '
        ColumnHeader9.Text = "Path"
        ColumnHeader9.Width = 214
        '
        'ReferencesView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lvSelected)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.tcReferences)
        Me.Name = "ReferencesView"
        Me.Size = New System.Drawing.Size(555, 400)
        Me.tcReferences.ResumeLayout(false)
        Me.tpGAC.ResumeLayout(false)
        Me.tpGAC.PerformLayout
        Me.tpCOM.ResumeLayout(false)
        Me.tpCOM.PerformLayout
        Me.tpBrowse.ResumeLayout(false)
        Me.tpProjects.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents tcReferences As Windows.Forms.TabControl
    Friend WithEvents tpGAC As Windows.Forms.TabPage
    Friend WithEvents tpBrowse As Windows.Forms.TabPage
    Friend WithEvents btnSelect As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btnRemove As Windows.Forms.Button
    Friend WithEvents txtGACSearch As Windows.Forms.TextBox
    Friend WithEvents cbSpecificVersion As Windows.Forms.CheckBox
    Friend WithEvents btnBrowse As Windows.Forms.Button
    Friend WithEvents lvGAC As Windows.Forms.ListView
    Friend WithEvents lvBrowse As Windows.Forms.ListView
    Friend WithEvents tpCOM As Windows.Forms.TabPage
    Friend WithEvents lvCOM As Windows.Forms.ListView
    Friend WithEvents txtCOMSearch As Windows.Forms.TextBox
    Friend WithEvents lvSelected As Windows.Forms.ListView
    Friend WithEvents tpProjects As Windows.Forms.TabPage
    Friend WithEvents lvProjects As Windows.Forms.ListView
End Class
