Public Class frmNewProject

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If txtName.Text.Trim = "" Then
            MsgBox("Enter a name!", MessageBoxIcon.Error, "INPUT ERROR") : Exit Sub
        End If
        If Not IO.Directory.Exists(txtPath.Text) Then
            MsgBox("Invalid path!", MessageBoxIcon.Error, "INPUT ERROR") : Exit Sub
        End If
        Dim strLanguage As String
        Dim bOutput As Boolean
        If lstTemplates.SelectedItem.ToString.Contains("C#") Then
            strLanguage = "cs"
        Else
            strLanguage = "vb"
        End If
        If lstTemplates.SelectedItem.ToString.Contains("ClassLibrary") Then
            bOutput = False
        Else
            bOutput = True
        End If
        Dim strPath As String = txtPath.Text
        If strPath.Last = "\" Or strPath.Last = "/" Then
            strPath = strPath.Remove(strPath.Count - 1, 1) & "\"
        Else
            strPath &= "\"
        End If
        Try
            Dim objXMLDoc As New XDocument
            Dim objProject As XElement = New XElement("Project")
            Dim objSettings As XElement = New XElement("Settings")
            Dim objReferences As XElement = New XElement("References")
            Dim objFiles As XElement = New XElement("Files")
            Dim objLanguage As XElement = New XElement("Language", strLanguage)
            Dim objOutput As XElement = New XElement("Output", bOutput)
            objProject.Add(objSettings)
            objProject.Add(objReferences)
            objProject.Add(objFiles)
            objSettings.Add(objLanguage)
            objSettings.Add(objOutput)
            If bOutput Then
                objFiles.Add(New XElement("File", strPath & "Program." & strLanguage))
            End If
            objXMLDoc.Add(objProject)
            objXMLDoc.Save(strPath & txtName.Text & ".proj")
            If bOutput Then
                If strLanguage = "cs" Then
                    If lstTemplates.SelectedItem.ToString.Contains("Console") Then
                        IO.File.WriteAllText(strPath & "Program." & strLanguage, "using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
")
                    ElseIf lstTemplates.SelectedItem.ToString.Contains("WinForms") Then
                        IO.File.WriteAllText(strPath & "Program." & strLanguage, "using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run();
        }
    }
}
")
                    End If
                Else
                    If lstTemplates.SelectedItem.ToString.Contains("Console") Then
                        IO.File.WriteAllText(strPath & "Program." & strLanguage, "Module Module1

    Sub Main()

    End Sub

End Module
")
                    ElseIf lstTemplates.SelectedItem.ToString.Contains("WinForms") Then
                        IO.File.WriteAllText(strPath & "Program." & strLanguage, "
Public Class Program
    Public Sub New()
        MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
        Me.IsSingleInstance = false
        Me.EnableVisualStyles = true
        Me.SaveMySettingsOnExit = true
        Me.ShutDownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
    End Sub

    Protected Overrides Sub OnCreateMainForm()
        Me.MainForm =
    End Sub
End Class")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
        Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dispose()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim fbd As New FolderBrowserDialog
        If fbd.ShowDialog = DialogResult.OK Then
            txtPath.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub frmNewProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstTemplates.SelectedIndex = 0
    End Sub

End Class