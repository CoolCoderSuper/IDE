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
        components = New System.ComponentModel.Container
        tmrLoad = New System.Windows.Forms.Timer(components)
        dgvErrors = New System.Windows.Forms.DataGridView
        CType(dgvErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'tmrLoad
        '
        tmrLoad.Interval = 3000
        '
        'dgvErrors
        '
        dgvErrors.AllowUserToAddRows = False
        dgvErrors.AllowUserToDeleteRows = False
        dgvErrors.AllowUserToResizeRows = False
        dgvErrors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvErrors.Dock = DockStyle.Fill
        dgvErrors.Location = New System.Drawing.Point(0, 0)
        dgvErrors.MultiSelect = False
        dgvErrors.Name = "dgvErrors"
        dgvErrors.ReadOnly = True
        dgvErrors.Size = New System.Drawing.Size(240, 150)
        dgvErrors.TabIndex = 0
        '
        'ErrorListTab
        '
        Title = "Error List"
        CType(dgvErrors, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        Controls.Add(dgvErrors)

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