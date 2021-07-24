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
        Me.btnOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.tcTools = New FarsiLibrary.Win.FATabStrip()
        Me.tcViews = New System.Windows.Forms.TabControl()
        Me.tbSolution = New System.Windows.Forms.TabPage()
        Me.lstFiles = New System.Windows.Forms.ListView()
        Me.menuFiles = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnNewContext = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDeleteContext = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExistingContext = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbObject = New System.Windows.Forms.TabPage()
        Me.tvObjectExplorer = New System.Windows.Forms.TreeView()
        Me.tcMain = New FarsiLibrary.Win.FATabStrip()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.tcTools, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcViews.SuspendLayout()
        Me.tbSolution.SuspendLayout()
        Me.menuFiles.SuspendLayout()
        Me.tbObject.SuspendLayout()
        CType(Me.tcMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.btnSave, Me.btnSaveAll, Me.btnUndo, Me.btnRedo, Me.btnStart, Me.btnBuild, Me.ViewToolStripMenuItem})
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
        Me.btnSave.Size = New System.Drawing.Size(43, 20)
        Me.btnSave.Text = "Save"
        '
        'btnSaveAll
        '
        Me.btnSaveAll.Name = "btnSaveAll"
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
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnViewOutput})
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
        'btnOptions
        '
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Size = New System.Drawing.Size(61, 20)
        Me.btnOptions.Text = "Options"
        '
        'tcTools
        '
        Me.tcTools.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcTools.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.tcTools.Location = New System.Drawing.Point(218, 505)
        Me.tcTools.Name = "tcTools"
        Me.tcTools.Size = New System.Drawing.Size(872, 121)
        Me.tcTools.TabIndex = 6
        '
        'tcViews
        '
        Me.tcViews.Controls.Add(Me.tbSolution)
        Me.tcViews.Controls.Add(Me.tbObject)
        Me.tcViews.Dock = System.Windows.Forms.DockStyle.Left
        Me.tcViews.Location = New System.Drawing.Point(0, 24)
        Me.tcViews.Name = "tcViews"
        Me.tcViews.SelectedIndex = 0
        Me.tcViews.Size = New System.Drawing.Size(216, 602)
        Me.tcViews.TabIndex = 4
        '
        'tbSolution
        '
        Me.tbSolution.Controls.Add(Me.lstFiles)
        Me.tbSolution.Location = New System.Drawing.Point(4, 22)
        Me.tbSolution.Name = "tbSolution"
        Me.tbSolution.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSolution.Size = New System.Drawing.Size(208, 576)
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
        Me.lstFiles.Size = New System.Drawing.Size(202, 570)
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
        'tbObject
        '
        Me.tbObject.Controls.Add(Me.tvObjectExplorer)
        Me.tbObject.Location = New System.Drawing.Point(4, 22)
        Me.tbObject.Name = "tbObject"
        Me.tbObject.Padding = New System.Windows.Forms.Padding(3)
        Me.tbObject.Size = New System.Drawing.Size(208, 576)
        Me.tbObject.TabIndex = 1
        Me.tbObject.Text = "Object Explorer"
        Me.tbObject.UseVisualStyleBackColor = True
        '
        'tvObjectExplorer
        '
        Me.tvObjectExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvObjectExplorer.Location = New System.Drawing.Point(3, 3)
        Me.tvObjectExplorer.Name = "tvObjectExplorer"
        Me.tvObjectExplorer.Size = New System.Drawing.Size(202, 570)
        Me.tvObjectExplorer.TabIndex = 1
        '
        'tcMain
        '
        Me.tcMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcMain.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.tcMain.Location = New System.Drawing.Point(218, 24)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.Size = New System.Drawing.Size(872, 475)
        Me.tcMain.TabIndex = 5
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 626)
        Me.Controls.Add(Me.tcViews)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.tcMain)
        Me.Controls.Add(Me.tcTools)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "IDEDemo"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.tcTools, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcViews.ResumeLayout(False)
        Me.tbSolution.ResumeLayout(False)
        Me.menuFiles.ResumeLayout(False)
        Me.tbObject.ResumeLayout(False)
        CType(Me.tcMain, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents tbObject As TabPage
    Friend WithEvents tcMain As FATabStrip
    Friend WithEvents tcTools As FATabStrip
    Friend WithEvents menuFiles As ContextMenuStrip
    Friend WithEvents btnNewContext As ToolStripMenuItem
    Friend WithEvents btnDeleteContext As ToolStripMenuItem
    Friend WithEvents btnExistingContext As ToolStripMenuItem
    Friend WithEvents btnOptions As ToolStripMenuItem
    Friend WithEvents tvObjectExplorer As TreeView
    Friend WithEvents btnUndo As ToolStripMenuItem
    Friend WithEvents btnRedo As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnViewOutput As ToolStripMenuItem
End Class
