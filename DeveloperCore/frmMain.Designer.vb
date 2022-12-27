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
        Me.mainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNewProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNewFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExistingFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSaveAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDeleteText = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRedo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnComment = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuild = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnErrorList = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnTaskList = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnViewOutput = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.tcTools = New FarsiLibrary.Win.FATabStrip()
        Me.tcViews = New System.Windows.Forms.TabControl()
        Me.tbSolution = New System.Windows.Forms.TabPage()
        Me.seExplorer = New CodingCool.DeveloperCore.SolutionExplorer.MSBuildSolutionExplorer()
        Me.tpStructure = New System.Windows.Forms.TabPage()
        Me.rsvStructure = New CodingCool.DeveloperCore.Views.RoslynStructureView()
        Me.tcMain = New FarsiLibrary.Win.FATabStrip()
        Me.splitterMain = New System.Windows.Forms.SplitContainer()
        Me.splitterEdit = New System.Windows.Forms.SplitContainer()
        Me.tmrObjectExplorer = New System.Windows.Forms.Timer(Me.components)
        Me.mainMenu.SuspendLayout
        CType(Me.tcTools,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tcViews.SuspendLayout
        Me.tbSolution.SuspendLayout
        Me.tpStructure.SuspendLayout
        CType(Me.tcMain,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.splitterMain,System.ComponentModel.ISupportInitialize).BeginInit
        Me.splitterMain.Panel1.SuspendLayout
        Me.splitterMain.Panel2.SuspendLayout
        Me.splitterMain.SuspendLayout
        CType(Me.splitterEdit,System.ComponentModel.ISupportInitialize).BeginInit
        Me.splitterEdit.Panel1.SuspendLayout
        Me.splitterEdit.Panel2.SuspendLayout
        Me.splitterEdit.SuspendLayout
        Me.SuspendLayout
        '
        'mainMenu
        '
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.btnSave, Me.btnSaveAll, Me.btnCut, Me.btnCopy, Me.btnPaste, Me.btnDeleteText, Me.btnUndo, Me.btnRedo, Me.btnComment, Me.btnStart, Me.btnBuild, Me.ViewToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.mainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mainMenu.Name = "mainMenu"
        Me.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.mainMenu.ShowItemToolTips = true
        Me.mainMenu.Size = New System.Drawing.Size(1090, 24)
        Me.mainMenu.TabIndex = 2
        Me.mainMenu.Text = "MenuStrip1"
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
        Me.ItemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNewFile, Me.btnExistingFile})
        Me.ItemToolStripMenuItem.Name = "ItemToolStripMenuItem"
        Me.ItemToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.ItemToolStripMenuItem.Text = "File"
        '
        'btnNewFile
        '
        Me.btnNewFile.Name = "btnNewFile"
        Me.btnNewFile.Size = New System.Drawing.Size(115, 22)
        Me.btnNewFile.Text = "New"
        '
        'btnExistingFile
        '
        Me.btnExistingFile.Name = "btnExistingFile"
        Me.btnExistingFile.Size = New System.Drawing.Size(115, 22)
        Me.btnExistingFile.Text = "Existing"
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
        Me.btnSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S),System.Windows.Forms.Keys)
        Me.btnSave.Size = New System.Drawing.Size(43, 20)
        Me.btnSave.Text = "Save"
        '
        'btnSaveAll
        '
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift)  _
            Or System.Windows.Forms.Keys.S),System.Windows.Forms.Keys)
        Me.btnSaveAll.Size = New System.Drawing.Size(57, 20)
        Me.btnSaveAll.Text = "SaveAll"
        '
        'btnCut
        '
        Me.btnCut.Name = "btnCut"
        Me.btnCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X),System.Windows.Forms.Keys)
        Me.btnCut.Size = New System.Drawing.Size(38, 20)
        Me.btnCut.Text = "Cut"
        '
        'btnCopy
        '
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C),System.Windows.Forms.Keys)
        Me.btnCopy.Size = New System.Drawing.Size(47, 20)
        Me.btnCopy.Text = "Copy"
        '
        'btnPaste
        '
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V),System.Windows.Forms.Keys)
        Me.btnPaste.Size = New System.Drawing.Size(47, 20)
        Me.btnPaste.Text = "Paste"
        '
        'btnDeleteText
        '
        Me.btnDeleteText.Name = "btnDeleteText"
        Me.btnDeleteText.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.btnDeleteText.Size = New System.Drawing.Size(52, 20)
        Me.btnDeleteText.Text = "Delete"
        '
        'btnUndo
        '
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z),System.Windows.Forms.Keys)
        Me.btnUndo.Size = New System.Drawing.Size(48, 20)
        Me.btnUndo.Text = "Undo"
        '
        'btnRedo
        '
        Me.btnRedo.Name = "btnRedo"
        Me.btnRedo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y),System.Windows.Forms.Keys)
        Me.btnRedo.Size = New System.Drawing.Size(46, 20)
        Me.btnRedo.Text = "Redo"
        '
        'btnComment
        '
        Me.btnComment.Name = "btnComment"
        Me.btnComment.Size = New System.Drawing.Size(145, 20)
        Me.btnComment.Text = "Comment\Uncomment"
        '
        'btnStart
        '
        Me.btnStart.Name = "btnStart"
        Me.btnStart.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.btnStart.Size = New System.Drawing.Size(43, 20)
        Me.btnStart.Text = "Start"
        '
        'btnBuild
        '
        Me.btnBuild.Name = "btnBuild"
        Me.btnBuild.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift)  _
            Or System.Windows.Forms.Keys.B),System.Windows.Forms.Keys)
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
        'btnErrorList
        '
        Me.btnErrorList.Name = "btnErrorList"
        Me.btnErrorList.Size = New System.Drawing.Size(120, 22)
        Me.btnErrorList.Text = "Error List"
        '
        'btnTaskList
        '
        Me.btnTaskList.Name = "btnTaskList"
        Me.btnTaskList.Size = New System.Drawing.Size(120, 22)
        Me.btnTaskList.Text = "Task List"
        '
        'btnViewOutput
        '
        Me.btnViewOutput.Name = "btnViewOutput"
        Me.btnViewOutput.Size = New System.Drawing.Size(120, 22)
        Me.btnViewOutput.Text = "Output"
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
        Me.btnOptions.Size = New System.Drawing.Size(116, 22)
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
        Me.tcViews.Controls.Add(Me.tpStructure)
        Me.tcViews.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcViews.Location = New System.Drawing.Point(0, 0)
        Me.tcViews.Name = "tcViews"
        Me.tcViews.SelectedIndex = 0
        Me.tcViews.Size = New System.Drawing.Size(271, 602)
        Me.tcViews.TabIndex = 4
        '
        'tbSolution
        '
        Me.tbSolution.Controls.Add(Me.seExplorer)
        Me.tbSolution.Location = New System.Drawing.Point(4, 22)
        Me.tbSolution.Name = "tbSolution"
        Me.tbSolution.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSolution.Size = New System.Drawing.Size(263, 576)
        Me.tbSolution.TabIndex = 0
        Me.tbSolution.Text = "Solution Explorer"
        Me.tbSolution.UseVisualStyleBackColor = true
        '
        'seExplorer
        '
        Me.seExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.seExplorer.ImageIndex = 0
        Me.seExplorer.LabelEdit = true
        Me.seExplorer.Location = New System.Drawing.Point(3, 3)
        Me.seExplorer.MSBuildSLN = Nothing
        Me.seExplorer.Name = "seExplorer"
        Me.seExplorer.SelectedImageIndex = 0
        Me.seExplorer.Size = New System.Drawing.Size(257, 570)
        Me.seExplorer.TabIndex = 1
        '
        'tpStructure
        '
        Me.tpStructure.Controls.Add(Me.rsvStructure)
        Me.tpStructure.Location = New System.Drawing.Point(4, 22)
        Me.tpStructure.Name = "tpStructure"
        Me.tpStructure.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStructure.Size = New System.Drawing.Size(263, 576)
        Me.tpStructure.TabIndex = 1
        Me.tpStructure.Text = "Structure"
        Me.tpStructure.UseVisualStyleBackColor = true
        '
        'rsvStructure
        '
        Me.rsvStructure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rsvStructure.ForeColor = System.Drawing.Color.Black
        Me.rsvStructure.ImageIndex = 0
        Me.rsvStructure.Loader = Nothing
        Me.rsvStructure.Location = New System.Drawing.Point(3, 3)
        Me.rsvStructure.Name = "rsvStructure"
        Me.rsvStructure.SelectedImageIndex = 0
        Me.rsvStructure.Size = New System.Drawing.Size(257, 570)
        Me.rsvStructure.TabIndex = 0
        Me.rsvStructure.Text = "Structure"
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
        'tmrObjectExplorer
        '
        Me.tmrObjectExplorer.Interval = 1000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 626)
        Me.Controls.Add(Me.splitterMain)
        Me.Controls.Add(Me.mainMenu)
        Me.MainMenuStrip = Me.mainMenu
        Me.Name = "frmMain"
        Me.Text = "DeveloperCore"
        Me.mainMenu.ResumeLayout(false)
        Me.mainMenu.PerformLayout
        CType(Me.tcTools,System.ComponentModel.ISupportInitialize).EndInit
        Me.tcViews.ResumeLayout(false)
        Me.tbSolution.ResumeLayout(false)
        Me.tpStructure.ResumeLayout(false)
        CType(Me.tcMain,System.ComponentModel.ISupportInitialize).EndInit
        Me.splitterMain.Panel1.ResumeLayout(false)
        Me.splitterMain.Panel2.ResumeLayout(false)
        CType(Me.splitterMain,System.ComponentModel.ISupportInitialize).EndInit
        Me.splitterMain.ResumeLayout(false)
        Me.splitterEdit.Panel1.ResumeLayout(false)
        Me.splitterEdit.Panel2.ResumeLayout(false)
        CType(Me.splitterEdit,System.ComponentModel.ISupportInitialize).EndInit
        Me.splitterEdit.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents mainMenu As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnNewProject As ToolStripMenuItem
    Friend WithEvents ItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnExistingFile As ToolStripMenuItem
    Friend WithEvents btnOpen As ToolStripMenuItem
    Friend WithEvents btnExit As ToolStripMenuItem
    Friend WithEvents btnStart As ToolStripMenuItem
    Friend WithEvents btnSave As ToolStripMenuItem
    Friend WithEvents btnSaveAll As ToolStripMenuItem
    Friend WithEvents btnBuild As ToolStripMenuItem
    Friend WithEvents tcViews As TabControl
    Friend WithEvents tbSolution As TabPage
    Friend WithEvents tcMain As FATabStrip
    Friend WithEvents tcTools As FATabStrip
    Friend WithEvents btnOptions As ToolStripMenuItem
    Friend WithEvents btnUndo As ToolStripMenuItem
    Friend WithEvents btnRedo As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnViewOutput As ToolStripMenuItem
    Friend WithEvents splitterMain As SplitContainer
    Friend WithEvents splitterEdit As SplitContainer
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnTaskList As ToolStripMenuItem
    Friend WithEvents btnErrorList As ToolStripMenuItem
    Friend WithEvents btnComment As ToolStripMenuItem
    Friend WithEvents tmrObjectExplorer As Timer
    Friend WithEvents btnCut As ToolStripMenuItem
    Friend WithEvents btnCopy As ToolStripMenuItem
    Friend WithEvents btnDeleteText As ToolStripMenuItem
    Friend WithEvents btnPaste As ToolStripMenuItem
    Friend WithEvents seExplorer As SolutionExplorer.MSBuildSolutionExplorer
    Friend WithEvents btnNewFile As ToolStripMenuItem
    Friend WithEvents tpStructure As TabPage
    Friend WithEvents rsvStructure As Views.RoslynStructureView
End Class
