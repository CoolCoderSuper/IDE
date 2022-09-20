Imports System.Windows.Forms
Imports CodingCool.DeveloperCore.Core
Imports FarsiLibrary.Win
Imports Microsoft.CodeAnalysis

Public Class ErrorListTab
    Inherits FATabStripItem

#Region "Components"

    Friend WithEvents tmrLoad As Timer
    Friend WithEvents dgvErrors As DataGridView
    Private components As System.ComponentModel.IContainer

#End Region

    Public Property Language As String
    Public Property Errors As New List(Of ErrorItem)
    Public Property Solution As Solution

#Region "Intialization"

    Public Sub New()
        InitializeComponent()
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
        Me.dgvErrors.Size = New System.Drawing.Size(200, 100)
        Me.dgvErrors.TabIndex = 0
        '
        'ErrorListTab
        '
        Me.Controls.Add(Me.dgvErrors)
        Me.Title = "Error List"
        CType(Me.dgvErrors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Data"

    Public Sub LoadErrors(lErrors As List(Of ErrorItem))
        Errors = lErrors.Concat(Errors).ToList
    End Sub

    Public Sub Reload()
        dgvErrors.DataSource = Helpers.QueryableToDataTable(Errors)
    End Sub

    Public sub Start
        tmrLoad.Start
    End sub

    Public sub [Stop]
        tmrLoad.Stop
    End sub

    Private Async Sub tmrLoad_Tick(sender As Object, e As EventArgs) Handles tmrLoad.Tick
        tmrLoad.Stop
        Await Load()
        tmrLoad.Start
    End Sub

    Private Async Function Load() As Task
        Dim objHelper As New ErrorHelper
        Errors = Await objHelper.GetErrors(Solution)
        Reload()
    End Function

#End Region

End Class