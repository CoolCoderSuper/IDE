Imports FarsiLibrary.Win
Imports FastColoredTextBoxNS
Imports System.Drawing

Public Class OutputTab
    Inherits FATabStripItem

#Region "Components"

    Private components As System.ComponentModel.IContainer
    Friend WithEvents txtOutput As FastColoredTextBox

#End Region

#Region "Intialization"

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
        txtOutput = New FastColoredTextBoxNS.FastColoredTextBox
        CType(txtOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'txtOutput
        '
        txtOutput.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        txtOutput.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        txtOutput.BackBrush = Nothing
        txtOutput.CharHeight = 14
        txtOutput.CharWidth = 8
        txtOutput.BackColor = ColorTranslator.FromHtml("#8a8a88")
        txtOutput.ForeColor = Color.White
        txtOutput.Cursor = System.Windows.Forms.Cursors.IBeam
        txtOutput.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        txtOutput.Dock = System.Windows.Forms.DockStyle.Fill
        txtOutput.Font = New System.Drawing.Font("Tahoma", 8)
        txtOutput.IsReplaceMode = False
        txtOutput.Location = New System.Drawing.Point(1, 20)
        txtOutput.Name = "txtOutput"
        txtOutput.Paddings = New System.Windows.Forms.Padding(0)
        txtOutput.ReadOnly = True
        txtOutput.ShowLineNumbers = False
        txtOutput.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        txtOutput.Size = New System.Drawing.Size(348, 179)
        txtOutput.TabIndex = 0
        txtOutput.Zoom = 100
        Controls.Add(txtOutput)
        CType(txtOutput, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        Title = "Output"
    End Sub

#End Region

#Region "Methods"

    Public Sub Print(str As String)
        txtOutput.Text &= str
    End Sub

    Public Sub PrintLine(str As String)
        Print($"{str}{vbCrLf}")
    End Sub

#End Region

End Class