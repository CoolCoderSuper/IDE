Imports System.Drawing
Imports FarsiLibrary.Win
Imports FastColoredTextBoxNS

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
        Me.components = New System.ComponentModel.Container()
        Me.txtOutput = New FastColoredTextBoxNS.FastColoredTextBox()
        CType(Me.txtOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtOutput
        '
        Me.txtOutput.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.txtOutput.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtOutput.BackBrush = Nothing
        Me.txtOutput.CharHeight = 14
        Me.txtOutput.CharWidth = 8
        Me.txtOutput.BackColor = ColorTranslator.FromHtml("#8a8a88")
        Me.txtOutput.ForeColor = Color.White
        Me.txtOutput.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOutput.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOutput.Font = New System.Drawing.Font("Tahoma", 8)
        Me.txtOutput.IsReplaceMode = False
        Me.txtOutput.Location = New System.Drawing.Point(1, 20)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Paddings = New System.Windows.Forms.Padding(0)
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ShowLineNumbers = False
        Me.txtOutput.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtOutput.Size = New System.Drawing.Size(348, 179)
        Me.txtOutput.TabIndex = 0
        Me.txtOutput.Zoom = 100
        Me.Controls.Add(txtOutput)
        CType(Me.txtOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.Title = "Output"
    End Sub

#End Region

#Region "Methods"

    Public Sub Print(str As String)
        txtOutput.Text &= str
    End Sub

    Public Sub PrintLine(str As String)
        Print(str & vbCrLf)
    End Sub

#End Region

End Class