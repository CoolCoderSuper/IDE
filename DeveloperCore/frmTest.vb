Imports CodingCool.DeveloperCore.Code.Search

Public Class frmTest
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim search As New Searcher
        Dim settings As New ChunkSearchSetting
        settings.IsWord = True
        settings.CaseSensitive = False
        settings.ChuckStart = "class"
        settings.ChunkEnd = "end class"
        Dim lResults As ChunkMatch() = search.FindChunk(TextBox1.Text, settings)
    End Sub
End Class