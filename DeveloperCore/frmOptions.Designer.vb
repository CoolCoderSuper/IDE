Imports CodingCool.DeveloperCore.Core

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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Font")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Task list")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Output")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Environment", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("General")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Font")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Scroll bar")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Editor", New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6, TreeNode7})
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Keywords")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Snippets")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("VB.NET", New System.Windows.Forms.TreeNode() {TreeNode9, TreeNode10})
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Keywords")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Snippets")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("C#", New System.Windows.Forms.TreeNode() {TreeNode12, TreeNode13})
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Languages", New System.Windows.Forms.TreeNode() {TreeNode11, TreeNode14})
        Me.splitterMain = New System.Windows.Forms.SplitContainer()
        Me.tvSetting = New System.Windows.Forms.TreeView()
        Me.pnlMainFont = New System.Windows.Forms.Panel()
        Me.gbFont = New System.Windows.Forms.GroupBox()
        Me.cbxMainFont = New FontComboBox()
        Me.txtMainFontDisplay = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxMainFontSize = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.splitterMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitterMain.Panel1.SuspendLayout()
        Me.splitterMain.Panel2.SuspendLayout()
        Me.splitterMain.SuspendLayout()
        Me.pnlMainFont.SuspendLayout()
        Me.gbFont.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitterMain
        '
        Me.splitterMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitterMain.Location = New System.Drawing.Point(0, 0)
        Me.splitterMain.Name = "splitterMain"
        '
        'splitterMain.Panel1
        '
        Me.splitterMain.Panel1.Controls.Add(Me.tvSetting)
        '
        'splitterMain.Panel2
        '
        Me.splitterMain.Panel2.Controls.Add(Me.pnlMainFont)
        Me.splitterMain.Size = New System.Drawing.Size(783, 448)
        Me.splitterMain.SplitterDistance = 139
        Me.splitterMain.TabIndex = 1
        '
        'tvSetting
        '
        Me.tvSetting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvSetting.Location = New System.Drawing.Point(0, 0)
        Me.tvSetting.Name = "tvSetting"
        TreeNode1.Name = "MainFont"
        TreeNode1.Text = "Font"
        TreeNode2.Name = "TaskList"
        TreeNode2.Text = "Task list"
        TreeNode3.Name = "Output"
        TreeNode3.Text = "Output"
        TreeNode4.Name = "Environment"
        TreeNode4.Text = "Environment"
        TreeNode5.Name = "EditorGeneral"
        TreeNode5.Text = "General"
        TreeNode6.Name = "EditorFont"
        TreeNode6.Text = "Font"
        TreeNode7.Name = "EditorScroll"
        TreeNode7.Text = "Scroll bar"
        TreeNode8.Name = "Editor"
        TreeNode8.Text = "Editor"
        TreeNode9.Name = "VBKeywords"
        TreeNode9.Text = "Keywords"
        TreeNode10.Name = "VBSnippets"
        TreeNode10.Text = "Snippets"
        TreeNode11.Name = "VB.NET"
        TreeNode11.Text = "VB.NET"
        TreeNode12.Name = "CSKeywords"
        TreeNode12.Text = "Keywords"
        TreeNode13.Name = "CSSnippets"
        TreeNode13.Text = "Snippets"
        TreeNode14.Name = "C#"
        TreeNode14.Text = "C#"
        TreeNode15.Name = "Languages"
        TreeNode15.Text = "Languages"
        Me.tvSetting.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode8, TreeNode15})
        Me.tvSetting.Size = New System.Drawing.Size(139, 448)
        Me.tvSetting.TabIndex = 1
        '
        'pnlMainFont
        '
        Me.pnlMainFont.Controls.Add(Me.gbFont)
        Me.pnlMainFont.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMainFont.Location = New System.Drawing.Point(0, 0)
        Me.pnlMainFont.Name = "pnlMainFont"
        Me.pnlMainFont.Size = New System.Drawing.Size(640, 448)
        Me.pnlMainFont.TabIndex = 0
        '
        'gbFont
        '
        Me.gbFont.Controls.Add(Me.cbxMainFont)
        Me.gbFont.Controls.Add(Me.txtMainFontDisplay)
        Me.gbFont.Controls.Add(Me.Label2)
        Me.gbFont.Controls.Add(Me.cbxMainFontSize)
        Me.gbFont.Controls.Add(Me.Label1)
        Me.gbFont.Location = New System.Drawing.Point(3, 3)
        Me.gbFont.Name = "gbFont"
        Me.gbFont.Size = New System.Drawing.Size(278, 115)
        Me.gbFont.TabIndex = 6
        Me.gbFont.TabStop = False
        Me.gbFont.Text = "Font"
        '
        'cbxMainFont
        '
        Me.cbxMainFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMainFont.FormattingEnabled = True
        Me.cbxMainFont.Items.AddRange(New Object() {"Agency FB", "Algerian", "Arial", "Arial Black", "Arial Narrow", "Arial Rounded MT Bold", "Bahnschrift", "Bahnschrift Condensed", "Bahnschrift Light", "Bahnschrift Light Condensed", "Bahnschrift Light SemiCondensed", "Bahnschrift SemiBold", "Bahnschrift SemiBold Condensed", "Bahnschrift SemiBold SemiConden", "Bahnschrift SemiCondensed", "Bahnschrift SemiLight", "Bahnschrift SemiLight Condensed", "Bahnschrift SemiLight SemiConde", "Baskerville Old Face", "Bauhaus 93", "Bell MT", "Berlin Sans FB", "Berlin Sans FB Demi", "Bernard MT Condensed", "Blackadder ITC", "Bodoni MT", "Bodoni MT Black", "Bodoni MT Condensed", "Bodoni MT Poster Compressed", "Book Antiqua", "Bookman Old Style", "Bookshelf Symbol 7", "Bradley Hand ITC", "Britannic Bold", "Broadway", "Brush Script MT", "Calibri", "Calibri Light", "Californian FB", "Calisto MT", "Cambria", "Cambria Math", "Candara", "Candara Light", "Cascadia Code", "Cascadia Code ExtraLight", "Cascadia Code Light", "Cascadia Code SemiBold", "Cascadia Code SemiLight", "Cascadia Mono", "Cascadia Mono ExtraLight", "Cascadia Mono Light", "Cascadia Mono SemiBold", "Cascadia Mono SemiLight", "Castellar", "Centaur", "Century", "Century Gothic", "Century Schoolbook", "Chiller", "Colonna MT", "Comic Sans MS", "Consolas", "Constantia", "Cooper Black", "Copperplate Gothic Bold", "Copperplate Gothic Light", "Corbel", "Corbel Light", "Courier New", "Curlz MT", "Dubai", "Dubai Light", "Dubai Medium", "Ebrima", "Edwardian Script ITC", "Elephant", "Engravers MT", "Eras Bold ITC", "Eras Demi ITC", "Eras Light ITC", "Eras Medium ITC", "Felix Titling", "Footlight MT Light", "Forte", "Franklin Gothic Book", "Franklin Gothic Demi", "Franklin Gothic Demi Cond", "Franklin Gothic Heavy", "Franklin Gothic Medium", "Franklin Gothic Medium Cond", "Freestyle Script", "French Script MT", "Gabriola", "Gadugi", "Garamond", "Georgia", "Gigi", "Gill Sans MT", "Gill Sans MT Condensed", "Gill Sans MT Ext Condensed Bold", "Gill Sans Ultra Bold", "Gill Sans Ultra Bold Condensed", "Gloucester MT Extra Condensed", "Goudy Old Style", "Goudy Stout", "Haettenschweiler", "Harlow Solid Italic", "Harrington", "High Tower Text", "HoloLens MDL2 Assets", "Impact", "Imprint MT Shadow", "Informal Roman", "Ink Free", "Javanese Text", "Jokerman", "Juice ITC", "Kristen ITC", "Kunstler Script", "Leelawadee", "Leelawadee UI", "Leelawadee UI Semilight", "Lucida Bright", "Lucida Calligraphy", "Lucida Console", "Lucida Fax", "Lucida Handwriting", "Lucida Sans", "Lucida Sans Typewriter", "Lucida Sans Unicode", "Magneto", "Maiandra GD", "Malgun Gothic", "Malgun Gothic Semilight", "Marlett", "Matura MT Script Capitals", "Microsoft Himalaya", "Microsoft JhengHei", "Microsoft JhengHei Light", "Microsoft JhengHei UI", "Microsoft JhengHei UI Light", "Microsoft New Tai Lue", "Microsoft PhagsPa", "Microsoft Sans Serif", "Microsoft Tai Le", "Microsoft Uighur", "Microsoft YaHei", "Microsoft YaHei Light", "Microsoft YaHei UI", "Microsoft YaHei UI Light", "Microsoft Yi Baiti", "MingLiU-ExtB", "MingLiU_HKSCS-ExtB", "Mistral", "Modern No. 20", "Mongolian Baiti", "Monotype Corsiva", "MS Gothic", "MS Outlook", "MS PGothic", "MS Reference Sans Serif", "MS Reference Specialty", "MS UI Gothic", "MT Extra", "MV Boli", "Myanmar Text", "Niagara Engraved", "Niagara Solid", "Nirmala UI", "Nirmala UI Semilight", "NSimSun", "OCR-A II", "OCR A Extended", "OCR B MT", "Old English Text MT", "Onyx", "Palace Script MT", "Palatino Linotype", "Papyrus", "Parchment", "Perpetua", "Perpetua Titling MT", "Playbill", "PMingLiU-ExtB", "Poor Richard", "Pristina", "QuickType", "QuickType Condensed", "QuickType II", "QuickType II Condensed", "QuickType II Mono", "QuickType II Pi", "QuickType Mono", "QuickType Pi", "Rage Italic", "Ravie", "Rockwell", "Rockwell Condensed", "Rockwell Extra Bold", "Script MT Bold", "Segoe MDL2 Assets", "Segoe Print", "Segoe Script", "Segoe UI", "Segoe UI Black", "Segoe UI Emoji", "Segoe UI Historic", "Segoe UI Light", "Segoe UI Semibold", "Segoe UI Semilight", "Segoe UI Symbol", "Showcard Gothic", "SimSun", "SimSun-ExtB", "Sitka Banner", "Sitka Display", "Sitka Heading", "Sitka Small", "Sitka Subheading", "Sitka Text", "Snap ITC", "Stencil", "Sylfaen", "Symbol", "Tahoma", "TeamViewer15", "Tempus Sans ITC", "Times New Roman", "Trebuchet MS", "Tw Cen MT", "Tw Cen MT Condensed", "Tw Cen MT Condensed Extra Bold", "Verdana", "Viner Hand ITC", "Vivaldi", "Vladimir Script", "Webdings", "Wide Latin", "Wingdings", "Wingdings 2", "Wingdings 3", "Yu Gothic", "Yu Gothic Light", "Yu Gothic Medium", "Yu Gothic UI", "Yu Gothic UI Light", "Yu Gothic UI Semibold", "Yu Gothic UI Semilight"})
        Me.cbxMainFont.Location = New System.Drawing.Point(9, 31)
        Me.cbxMainFont.Name = "cbxMainFont"
        Me.cbxMainFont.Size = New System.Drawing.Size(190, 21)
        Me.cbxMainFont.TabIndex = 6
        '
        'txtMainFontDisplay
        '
        Me.txtMainFontDisplay.Location = New System.Drawing.Point(9, 59)
        Me.txtMainFontDisplay.Multiline = False
        Me.txtMainFontDisplay.Name = "txtMainFontDisplay"
        Me.txtMainFontDisplay.ReadOnly = True
        Me.txtMainFontDisplay.Size = New System.Drawing.Size(262, 50)
        Me.txtMainFontDisplay.TabIndex = 5
        Me.txtMainFontDisplay.Text = "AdfHtdTkkfuUKD"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(202, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Size:"
        '
        'cbxMainFontSize
        '
        Me.cbxMainFontSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cbxMainFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMainFontSize.FormattingEnabled = True
        Me.cbxMainFontSize.Items.AddRange(New Object() {"6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cbxMainFontSize.Location = New System.Drawing.Point(205, 31)
        Me.cbxMainFontSize.Name = "cbxMainFontSize"
        Me.cbxMainFontSize.Size = New System.Drawing.Size(66, 21)
        Me.cbxMainFontSize.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Text Font:"
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 448)
        Me.Controls.Add(Me.splitterMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Options"
        Me.splitterMain.Panel1.ResumeLayout(False)
        Me.splitterMain.Panel2.ResumeLayout(False)
        CType(Me.splitterMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitterMain.ResumeLayout(False)
        Me.pnlMainFont.ResumeLayout(False)
        Me.gbFont.ResumeLayout(False)
        Me.gbFont.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents splitterMain As SplitContainer
    Friend WithEvents tvSetting As TreeView
    Friend WithEvents pnlMainFont As Panel
    Friend WithEvents cbxMainFontSize As ComboBox
    Friend WithEvents txtMainFontDisplay As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents gbFont As GroupBox
    Friend WithEvents cbxMainFont As FontComboBox
End Class
