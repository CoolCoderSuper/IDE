Imports System.IO
Imports FarsiLibrary.Win

Public Class EditorCodeTab
    Inherits FATabStripItem
    Public WithEvents txtEditor As ICSharpCode.TextEditor.TextEditorControl
    Public Property FilePath As String

    Public Sub New(strFile As String)
        txtEditor = New ICSharpCode.TextEditor.TextEditorControl
        txtEditor.Dock = Windows.Forms.DockStyle.Fill
        txtEditor.LoadFile(strFile)
        Controls.Add(txtEditor)
        FilePath = strFile
        Title = Path.GetFileName(FilePath)
    End Sub

    Public Sub Save()
        txtEditor.SaveFile(FilePath)
        Title = Path.GetFileName(FilePath)
    End Sub

    Private Sub txtEditor_TextChanged(sender As Object, e As EventArgs) Handles txtEditor.TextChanged
        Title = $"{Path.GetFileName(FilePath)} *"
    End Sub
End Class