Imports CodingCool.DeveloperCore.Core
Imports FarsiLibrary.Win
Imports System.Windows.Forms

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
        components = New System.ComponentModel.Container
        tmrLoad = New System.Windows.Forms.Timer(components)
        dgvTasks = New System.Windows.Forms.DataGridView
        CType(dgvTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'tmrLoad
        '
        tmrLoad.Interval = 5000
        '
        'dgvTasks
        '
        dgvTasks.AllowUserToAddRows = False
        dgvTasks.AllowUserToDeleteRows = False
        dgvTasks.AllowUserToResizeRows = False
        dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTasks.Dock = System.Windows.Forms.DockStyle.Fill
        dgvTasks.Location = New System.Drawing.Point(0, 0)
        dgvTasks.MultiSelect = False
        dgvTasks.Name = "dgvTasks"
        dgvTasks.ReadOnly = True
        dgvTasks.Size = New System.Drawing.Size(240, 150)
        dgvTasks.TabIndex = 0
        CType(dgvTasks, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

#End Region

#Region "Data"

    Private Sub tmrLoad_Tick(sender As Object, e As EventArgs) Handles tmrLoad.Tick
        Load()
    End Sub

    Public Sub Load()
        Dim objHelper As New TaskHelper
        Dim dtResults As DataTable = Helpers.QueryableToDataTable(objHelper.GetTasks(Files, CommentPrefix).AsQueryable())
        If dgvTasks.DataSource IsNot dtResults Then
            dgvTasks.DataSource = dtResults
        End If
    End Sub

#End Region

End Class