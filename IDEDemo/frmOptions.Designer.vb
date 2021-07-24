<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOptions
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Documents")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Font and colour")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tabs")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Task list")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Environment", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("General")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Font")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Scroll bar")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Editor", New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode7, TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Keywords")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Snippets")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("VB.NET", New System.Windows.Forms.TreeNode() {TreeNode10, TreeNode11})
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Keywords")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Snippets")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("C#", New System.Windows.Forms.TreeNode() {TreeNode13, TreeNode14})
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Languages", New System.Windows.Forms.TreeNode() {TreeNode12, TreeNode15})
        Me.tvSetting = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'tvSetting
        '
        Me.tvSetting.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvSetting.Location = New System.Drawing.Point(0, 0)
        Me.tvSetting.Name = "tvSetting"
        TreeNode1.Name = "Documents"
        TreeNode1.Text = "Documents"
        TreeNode2.Name = "MainFont"
        TreeNode2.Text = "Font and colour"
        TreeNode3.Name = "Tabs"
        TreeNode3.Text = "Tabs"
        TreeNode4.Name = "TaskList"
        TreeNode4.Text = "Task list"
        TreeNode5.Name = "Environment"
        TreeNode5.Text = "Environment"
        TreeNode6.Name = "EditorGeneral"
        TreeNode6.Text = "General"
        TreeNode7.Name = "EditorFont"
        TreeNode7.Text = "Font"
        TreeNode8.Name = "EditorScroll"
        TreeNode8.Text = "Scroll bar"
        TreeNode9.Name = "Editor"
        TreeNode9.Text = "Editor"
        TreeNode10.Name = "VBKeywords"
        TreeNode10.Text = "Keywords"
        TreeNode11.Name = "VBSnippets"
        TreeNode11.Text = "Snippets"
        TreeNode12.Name = "VB.NET"
        TreeNode12.Text = "VB.NET"
        TreeNode13.Name = "CSKeywords"
        TreeNode13.Text = "Keywords"
        TreeNode14.Name = "CSSnippets"
        TreeNode14.Text = "Snippets"
        TreeNode15.Name = "C#"
        TreeNode15.Text = "C#"
        TreeNode16.Name = "Languages"
        TreeNode16.Text = "Languages"
        Me.tvSetting.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode9, TreeNode16})
        Me.tvSetting.Size = New System.Drawing.Size(175, 448)
        Me.tvSetting.TabIndex = 0
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 448)
        Me.Controls.Add(Me.tvSetting)
        Me.Name = "frmOptions"
        Me.Text = "Options"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tvSetting As TreeView
End Class
