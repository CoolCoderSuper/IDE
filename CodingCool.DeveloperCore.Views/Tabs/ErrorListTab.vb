Imports CodingCool.DeveloperCore.Core
Imports FarsiLibrary.Win
Imports System.Windows.Forms

Public Class ErrorListTab
    Inherits FATabStripItem

#Region "Components"

    Friend WithEvents tmrLoad As Timer
    Friend WithEvents dgvErrors As DataGridView
    Private components As System.ComponentModel.IContainer

#End Region

    Public Property Language As String
    Public Property Errors As New List(Of ErrorItem)

#Region "Intialization"

    Public Sub New()
        InitializeComponent()
        tmrLoad.Start()
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmrLoad = New System.Windows.Forms.Timer(Me.components)
        Me.dgvErrors = New System.Windows.Forms.DataGridView()
        CType(Me.dgvErrors,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'tmrLoad
        '
        Me.tmrLoad.Interval = 3000
        '
        'dgvErrors
        '
        Me.dgvErrors.AllowUserToAddRows = false
        Me.dgvErrors.AllowUserToDeleteRows = false
        Me.dgvErrors.AllowUserToResizeRows = false
        Me.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvErrors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvErrors.Location = New System.Drawing.Point(0, 0)
        Me.dgvErrors.MultiSelect = false
        Me.dgvErrors.Name = "dgvErrors"
        Me.dgvErrors.ReadOnly = true
        Me.dgvErrors.Size = New System.Drawing.Size(200, 100)
        Me.dgvErrors.TabIndex = 0
        '
        'ErrorListTab
        '
        Me.Controls.Add(Me.dgvErrors)
        Me.Title = "Error List"
        CType(Me.dgvErrors,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

#End Region

#Region "Data"

    Public Sub LoadErrors(lErrors As List(Of ErrorItem))
        Errors = lErrors.Concat(Errors).ToList
    End Sub

    Public Sub Reload
        dgvErrors.DataSource = Helpers.QueryableToDataTable(Errors)
    End Sub

    Private Sub tmrLoad_Tick(sender As Object, e As EventArgs) Handles tmrLoad.Tick
        Load()
    End Sub

    Private Sub Load()
        'Dim objHelper As New Core.ErrorHelper
        '
        'If dgvErrors.DataSource IsNot dtResults Then
        '    dgvErrors.DataSource = dtResults
        'End If
    End Sub

#End Region

End Class