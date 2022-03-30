Public Class frmNewFile

    Private Sub frmNewFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmMain.Language.ToLower() = "cs" Then
            lstTemplates.Items.Add("Class")
            lstTemplates.Items.Add("Form")
        Else
            lstTemplates.Items.Add("Class")
            lstTemplates.Items.Add("Module")
            lstTemplates.Items.Add("Form")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dispose()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If txtName.Text.Trim() = String.Empty Then
            MsgBox("Enter a valid name!", MessageBoxIcon.Error, "INPUT ERROR")
        End If
        Try
            Dim objDoc As XDocument = XDocument.Load(frmMain.ProjectRoot)
            Dim objRoot As XElement = objDoc.Element("Project")
            Dim objFiles As XElement = objRoot.Element("Files")
            Dim objFile As XElement = New XElement("File", $"{frmMain.ProjectDir}{txtName.Text}.{frmMain.Language.ToLower()}")
            objFiles.Add(objFile)
            objDoc.Save(frmMain.ProjectRoot)
        Catch ex As Exception

        End Try
        If frmMain.Language.ToLower() = "cs" Then
            If lstTemplates.SelectedItem.ToString() = "Class" Then
                IO.File.WriteAllText($"{frmMain.ProjectDir}{txtName.Text}.{frmMain.Language.ToLower()}", $"public class {txtName.Text}
{{

}}")
            ElseIf lstTemplates.SelectedItem.ToString() = "Form" Then
                IO.File.WriteAllText($"{frmMain.ProjectDir}{txtName.Text}.{frmMain.Language.ToLower()}", $"public class {txtName.Text} : System.Windows.Forms.Form
{{

}}")
            End If
        Else
            If lstTemplates.SelectedItem.ToString() = "Module" Then
                IO.File.WriteAllText($"{frmMain.ProjectDir}{txtName.Text}.{frmMain.Language.ToLower()}", $"Module {txtName.Text}

    Sub Main()

    End Sub

End Module")
            ElseIf lstTemplates.SelectedItem.ToString() = "Class" Then
                IO.File.WriteAllText($"{frmMain.ProjectDir}{txtName.Text}.{frmMain.Language.ToLower()}", $"Public Class {txtName.Text}

End Class")
            ElseIf lstTemplates.SelectedItem.ToString() = "Form" Then
                IO.File.WriteAllText($"{frmMain.ProjectDir}{txtName.Text}.{frmMain.Language.ToLower()}", $"Public Class {txtName.Text}
    Inherits System.Windows.Forms.Form

End Class")

            End If
        End If
        Dispose()
    End Sub

End Class