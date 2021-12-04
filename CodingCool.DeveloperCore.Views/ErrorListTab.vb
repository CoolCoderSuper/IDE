Imports System.Windows.Forms
Imports FarsiLibrary.Win

Public Class ErrorListTab
    Inherits FATabStripItem

#Region "Components"

    Friend WithEvents tmrLoad As Timer
    Friend WithEvents dgvErrors As DataGridView
    Private components As System.ComponentModel.IContainer

#End Region

    Public Property Language As String

    Public Property Files As String()

    Public Property References As String()

#Region "Intialization"

    Public Sub New()
        InitializeComponent()
        tmrLoad.Start()
    End Sub

    Public Sub New(strLanguage As String, lFiles As String(), lReferences As String())
        InitializeComponent()
        Files = lFiles
        References = lReferences
        Language = strLanguage
        tmrLoad.Start()
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmrLoad = New System.Windows.Forms.Timer(Me.components)
        Me.dgvErrors = New System.Windows.Forms.DataGridView()
        CType(Me.dgvErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrLoad
        '
        Me.tmrLoad.Interval = 3000
        '
        'dgvErrors
        '
        Me.dgvErrors.AllowUserToAddRows = False
        Me.dgvErrors.AllowUserToDeleteRows = False
        Me.dgvErrors.AllowUserToResizeRows = False
        Me.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvErrors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvErrors.Location = New System.Drawing.Point(0, 0)
        Me.dgvErrors.MultiSelect = False
        Me.dgvErrors.Name = "dgvErrors"
        Me.dgvErrors.ReadOnly = True
        Me.dgvErrors.Size = New System.Drawing.Size(240, 150)
        Me.dgvErrors.TabIndex = 0
        '
        'ErrorListTab
        '
        Me.Title = "Error List"
        CType(Me.dgvErrors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.Controls.Add(dgvErrors)

    End Sub

#End Region

#Region "Data"

    Private Sub tmrLoad_Tick(sender As Object, e As EventArgs) Handles tmrLoad.Tick
        Load()
    End Sub

    Private Sub Load()
        Dim objHelper As New Core.ErrorHelper
        Dim dtResults As DataTable = Core.Helpers.QueryableToDataTable(objHelper.GetErrors(Language, Files, References))
        If dgvErrors.DataSource IsNot dtResults Then
            dgvErrors.DataSource = dtResults
        End If
    End Sub

#End Region

End Class