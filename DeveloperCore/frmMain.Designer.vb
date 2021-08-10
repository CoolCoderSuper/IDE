Imports FarsiLibrary.Win

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNewProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNewFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnReferences = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNewExisting = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSaveAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRedo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuild = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnViewOutput = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnTaskList = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.tcTools = New FarsiLibrary.Win.FATabStrip()
        Me.tcViews = New System.Windows.Forms.TabControl()
        Me.tbSolution = New System.Windows.Forms.TabPage()
        Me.lstFiles = New System.Windows.Forms.ListView()
        Me.menuFiles = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnNewContext = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDeleteContext = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExistingContext = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpProperties = New System.Windows.Forms.TabPage()
        Me.props = New System.Windows.Forms.PropertyGrid()
        Me.tcMain = New FarsiLibrary.Win.FATabStrip()
        Me.splitterMain = New System.Windows.Forms.SplitContainer()
        Me.splitterEdit = New System.Windows.Forms.SplitContainer()
        Me.btnErrorList = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.tcTools, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcViews.SuspendLayout()
        Me.tbSolution.SuspendLayout()
        Me.menuFiles.SuspendLayout()
        Me.tpProperties.SuspendLayout()
        CType(Me.tcMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splitterMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitterMain.Panel1.SuspendLayout()
        Me.splitterMain.Panel2.SuspendLayout()
        Me.splitterMain.SuspendLayout()
        CType(Me.splitterEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitterEdit.Panel1.SuspendLayout()
        Me.splitterEdit.Panel2.SuspendLayout()
        Me.splitterEdit.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.btnSave, Me.btnSaveAll, Me.btnUndo, Me.btnRedo, Me.btnStart, Me.btnBuild, Me.ViewToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(1090, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.btnOpen, Me.btnExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNewProject, Me.ItemToolStripMenuItem})
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "New"
        '
        'btnNewProject
        '
        Me.btnNewProject.Name = "btnNewProject"
        Me.btnNewProject.Size = New System.Drawing.Size(111, 22)
        Me.btnNewProject.Text = "Project"
        '
        'ItemToolStripMenuItem
        '
        Me.ItemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnNewExisting})
        Me.ItemToolStripMenuItem.Name = "ItemToolStripMenuItem"
        Me.ItemToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.ItemToolStripMenuItem.Text = "Item"
        '
        'btnNew
        '
        Me.btnNew.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNewFile, Me.btnReferences})
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(115, 22)
        Me.btnNew.Text = "New"
        '
        'btnNewFile
        '
        Me.btnNewFile.Name = "btnNewFile"
        Me.btnNewFile.Size = New System.Drawing.Size(126, 22)
        Me.btnNewFile.Text = "File"
        '
        'btnReferences
        '
        Me.btnReferences.Name = "btnReferences"
        Me.btnReferences.Size = New System.Drawing.Size(126, 22)
        Me.btnReferences.Text = "Reference"
        '
        'btnNewExisting
        '
        Me.btnNewExisting.Name = "btnNewExisting"
        Me.btnNewExisting.Size = New System.Drawing.Size(115, 22)
        Me.btnNewExisting.Text = "Existing"
        '
        'btnOpen
        '
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(103, 22)
        Me.btnOpen.Text = "Open"
        '
        'btnExit
        '
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(103, 22)
        Me.btnExit.Text = "Exit"
        '
        'btnSave
        '
        Me.btnSave.Name = "btnSave"
        Me.btnSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.btnSave.Size = New System.Drawing.Size(43, 20)
        Me.btnSave.Text = "Save"
        '
        'btnSaveAll
        '
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.btnSaveAll.Size = New System.Drawing.Size(57, 20)
        Me.btnSaveAll.Text = "SaveAll"
        '
        'btnUndo
        '
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(48, 20)
        Me.btnUndo.Text = "Undo"
        '
        'btnRedo
        '
        Me.btnRedo.Name = "btnRedo"
        Me.btnRedo.Size = New System.Drawing.Size(46, 20)
        Me.btnRedo.Text = "Redo"
        '
        'btnStart
        '
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(43, 20)
        Me.btnStart.Text = "Start"
        '
        'btnBuild
        '
        Me.btnBuild.Name = "btnBuild"
        Me.btnBuild.Size = New System.Drawing.Size(46, 20)
        Me.btnBuild.Text = "Build"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnErrorList, Me.btnTaskList, Me.btnViewOutput})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'btnViewOutput
        '
        Me.btnViewOutput.Name = "btnViewOutput"
        Me.btnViewOutput.Size = New System.Drawing.Size(180, 22)
        Me.btnViewOutput.Text = "Output"
        '
        'btnTaskList
        '
        Me.btnTaskList.Name = "btnTaskList"
        Me.btnTaskList.Size = New System.Drawing.Size(180, 22)
        Me.btnTaskList.Text = "Task List"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOptions})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'btnOptions
        '
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Size = New System.Drawing.Size(180, 22)
        Me.btnOptions.Text = "Options"
        '
        'tcTools
        '
        Me.tcTools.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcTools.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.tcTools.Location = New System.Drawing.Point(0, 0)
        Me.tcTools.Name = "tcTools"
        Me.tcTools.Size = New System.Drawing.Size(815, 102)
        Me.tcTools.TabIndex = 6
        '
        'tcViews
        '
        Me.tcViews.Controls.Add(Me.tbSolution)
        Me.tcViews.Controls.Add(Me.tpProperties)
        Me.tcViews.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcViews.Location = New System.Drawing.Point(0, 0)
        Me.tcViews.Name = "tcViews"
        Me.tcViews.SelectedIndex = 0
        Me.tcViews.Size = New System.Drawing.Size(271, 602)
        Me.tcViews.TabIndex = 4
        '
        'tbSolution
        '
        Me.tbSolution.Controls.Add(Me.lstFiles)
        Me.tbSolution.Location = New System.Drawing.Point(4, 22)
        Me.tbSolution.Name = "tbSolution"
        Me.tbSolution.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSolution.Size = New System.Drawing.Size(263, 576)
        Me.tbSolution.TabIndex = 0
        Me.tbSolution.Text = "Solution Explorer"
        Me.tbSolution.UseVisualStyleBackColor = True
        '
        'lstFiles
        '
        Me.lstFiles.ContextMenuStrip = Me.menuFiles
        Me.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFiles.HideSelection = False
        Me.lstFiles.Location = New System.Drawing.Point(3, 3)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.Size = New System.Drawing.Size(257, 570)
        Me.lstFiles.TabIndex = 4
        Me.lstFiles.UseCompatibleStateImageBehavior = False
        Me.lstFiles.View = System.Windows.Forms.View.List
        '
        'menuFiles
        '
        Me.menuFiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNewContext, Me.btnDeleteContext, Me.btnExistingContext})
        Me.menuFiles.Name = "menuFiles"
        Me.menuFiles.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.menuFiles.Size = New System.Drawing.Size(116, 70)
        '
        'btnNewContext
        '
        Me.btnNewContext.Name = "btnNewContext"
        Me.btnNewContext.Size = New System.Drawing.Size(115, 22)
        Me.btnNewContext.Text = "New"
        '
        'btnDeleteContext
        '
        Me.btnDeleteContext.Name = "btnDeleteContext"
        Me.btnDeleteContext.Size = New System.Drawing.Size(115, 22)
        Me.btnDeleteContext.Text = "Delete"
        '
        'btnExistingContext
        '
        Me.btnExistingContext.Name = "btnExistingContext"
        Me.btnExistingContext.Size = New System.Drawing.Size(115, 22)
        Me.btnExistingContext.Text = "Existing"
        '
        'tpProperties
        '
        Me.tpProperties.Controls.Add(Me.props)
        Me.tpProperties.Location = New System.Drawing.Point(4, 22)
        Me.tpProperties.Name = "tpProperties"
        Me.tpProperties.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProperties.Size = New System.Drawing.Size(263, 576)
        Me.tpProperties.TabIndex = 2
        Me.tpProperties.Text = "Properties"
        Me.tpProperties.UseVisualStyleBackColor = True
        '
        'props
        '
        Me.props.Dock = System.Windows.Forms.DockStyle.Fill
        Me.props.Location = New System.Drawing.Point(3, 3)
        Me.props.Name = "props"
        Me.props.Size = New System.Drawing.Size(257, 570)
        Me.props.TabIndex = 0
        '
        'tcMain
        '
        Me.tcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMain.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.tcMain.Location = New System.Drawing.Point(0, 0)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.Size = New System.Drawing.Size(815, 496)
        Me.tcMain.TabIndex = 5
        '
        'splitterMain
        '
        Me.splitterMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitterMain.Location = New System.Drawing.Point(0, 24)
        Me.splitterMain.Name = "splitterMain"
        '
        'splitterMain.Panel1
        '
        Me.splitterMain.Panel1.Controls.Add(Me.tcViews)
        '
        'splitterMain.Panel2
        '
        Me.splitterMain.Panel2.Controls.Add(Me.splitterEdit)
        Me.splitterMain.Size = New System.Drawing.Size(1090, 602)
        Me.splitterMain.SplitterDistance = 271
        Me.splitterMain.TabIndex = 7
        '
        'splitterEdit
        '
        Me.splitterEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitterEdit.Location = New System.Drawing.Point(0, 0)
        Me.splitterEdit.Name = "splitterEdit"
        Me.splitterEdit.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitterEdit.Panel1
        '
        Me.splitterEdit.Panel1.Controls.Add(Me.tcMain)
        '
        'splitterEdit.Panel2
        '
        Me.splitterEdit.Panel2.Controls.Add(Me.tcTools)
        Me.splitterEdit.Size = New System.Drawing.Size(815, 602)
        Me.splitterEdit.SplitterDistance = 496
        Me.splitterEdit.TabIndex = 0
        '
        'btnErrorList
        '
        Me.btnErrorList.Name = "btnErrorList"
        Me.btnErrorList.Size = New System.Drawing.Size(180, 22)
        Me.btnErrorList.Text = "Error List"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 626)
        Me.Controls.Add(Me.splitterMain)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "DeveloperCore"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.tcTools, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcViews.ResumeLayout(False)
        Me.tbSolution.ResumeLayout(False)
        Me.menuFiles.ResumeLayout(False)
        Me.tpProperties.ResumeLayout(False)
        CType(Me.tcMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitterMain.Panel1.ResumeLayout(False)
        Me.splitterMain.Panel2.ResumeLayout(False)
        CType(Me.splitterMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitterMain.ResumeLayout(False)
        Me.splitterEdit.Panel1.ResumeLayout(False)
        Me.splitterEdit.Panel2.ResumeLayout(False)
        CType(Me.splitterEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitterEdit.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnNewProject As ToolStripMenuItem
    Friend WithEvents ItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnNew As ToolStripMenuItem
    Friend WithEvents btnNewExisting As ToolStripMenuItem
    Friend WithEvents btnOpen As ToolStripMenuItem
    Friend WithEvents btnExit As ToolStripMenuItem
    Friend WithEvents btnStart As ToolStripMenuItem
    Friend WithEvents btnNewFile As ToolStripMenuItem
    Friend WithEvents btnReferences As ToolStripMenuItem
    Friend WithEvents btnSave As ToolStripMenuItem
    Friend WithEvents btnSaveAll As ToolStripMenuItem
    Friend WithEvents btnBuild As ToolStripMenuItem
    Friend WithEvents tcViews As TabControl
    Friend WithEvents tbSolution As TabPage
    Friend WithEvents lstFiles As ListView
    Friend WithEvents tcMain As FATabStrip
    Friend WithEvents tcTools As FATabStrip
    Friend WithEvents menuFiles As ContextMenuStrip
    Friend WithEvents btnNewContext As ToolStripMenuItem
    Friend WithEvents btnDeleteContext As ToolStripMenuItem
    Friend WithEvents btnExistingContext As ToolStripMenuItem
    Friend WithEvents btnOptions As ToolStripMenuItem
    Friend WithEvents btnUndo As ToolStripMenuItem
    Friend WithEvents btnRedo As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnViewOutput As ToolStripMenuItem
    Friend WithEvents splitterMain As SplitContainer
    Friend WithEvents splitterEdit As SplitContainer
    Friend WithEvents tpProperties As TabPage
    Friend WithEvents props As PropertyGrid
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnTaskList As ToolStripMenuItem
    Friend WithEvents btnErrorList As ToolStripMenuItem
End Class
