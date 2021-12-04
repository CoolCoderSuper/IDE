Imports System.Windows.Forms
Imports CodingCool.DeveloperCore.Core
Imports FarsiLibrary.Win

Public Class TaskListTab
    Inherits FATabStripItem

#Region "Components"

    Friend WithEvents tmrLoad As Timer
    Friend WithEvents dgvTasks As DataGridView
    Private components As System.ComponentModel.IContainer

#End Region

    Public Property CommentPrefix As String

    Public Property Files As String()

#Region "Initialization"

    Public Sub New(strCommentPrefix As String, lFiles As String())
        CommentPrefix = strCommentPrefix
        Files = lFiles
        InitializeComponent()
        Title = "Task List"
        Controls.Add(dgvTasks)
        Load()
        tmrLoad.Start()
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmrLoad = New System.Windows.Forms.Timer(Me.components)
        Me.dgvTasks = New System.Windows.Forms.DataGridView()
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrLoad
        '
        Me.tmrLoad.Interval = 5000
        '
        'dgvTasks
        '
        Me.dgvTasks.AllowUserToAddRows = False
        Me.dgvTasks.AllowUserToDeleteRows = False
        Me.dgvTasks.AllowUserToResizeRows = False
        Me.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTasks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTasks.Location = New System.Drawing.Point(0, 0)
        Me.dgvTasks.MultiSelect = False
        Me.dgvTasks.Name = "dgvTasks"
        Me.dgvTasks.ReadOnly = True
        Me.dgvTasks.Size = New System.Drawing.Size(240, 150)
        Me.dgvTasks.TabIndex = 0
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Data"

    Private Sub tmrLoad_Tick(sender As Object, e As EventArgs) Handles tmrLoad.Tick
        Load()
    End Sub

    Public Sub Load()
        Dim objHelper As New TaskHelper
        Dim dtResults As DataTable = Helpers.QueryableToDataTable(objHelper.GetTasks(Files, CommentPrefix).AsQueryable)
        If dgvTasks.DataSource IsNot dtResults Then
            dgvTasks.DataSource = dtResults
        End If
    End Sub

#End Region

End Class