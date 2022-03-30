Public Class frmReferences

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim ofd As New OpenFileDialog
        ofd.Multiselect = False
        ofd.Filter = "DLL files (*.dll)|*.dll"
        If ofd.ShowDialog = DialogResult.OK Then
            lstReferences.Items.Add(ofd.FileName)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            lstReferences.Items.Remove(lstReferences.SelectedItem)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim objDoc As XDocument = XDocument.Load(frmMain.ProjectRoot)
        Dim objRoot As XElement = objDoc.Element("Project")
        Dim objReferences As XElement = objRoot.Element("References")
        objReferences.RemoveAll()
        For Each strReference As String In lstReferences.Items
            Try
                Dim objReference As XElement = New XElement("Reference", strReference)
                objReferences.Add(objReference)
            Catch ex As Exception

            End Try
        Next
        objDoc.Save(frmMain.ProjectRoot)
        Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dispose()
    End Sub

    Private Sub frmReferences_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim objDoc As XDocument = XDocument.Load(frmMain.ProjectRoot)
            Dim objRoot As XElement = objDoc.Element("Project")
            Dim objReferences As XElement = objRoot.Element("References")
            For Each objReference As XElement In objReferences.Elements("Reference")
                lstReferences.Items.Add(objReference.Value)
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class