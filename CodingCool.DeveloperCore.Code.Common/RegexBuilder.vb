Imports System.Text.RegularExpressions

Public Class RegexBuilder

    Public Shared Function BuildWordRegex(word As String, settings As Search.WordSearchSetting) As Regex
        Dim strRegex As String = String.Empty
        If Not settings.CaseSensitive Then strRegex &= "(?i)"
        If settings.IsWord Then
            strRegex &= $"\b({Regex.Escape(word)})\b"
        Else
            strRegex &= $"({Regex.Escape(word)})"
        End If
        Return New Regex(strRegex)
    End Function

    Public Shared Function BuildChunkRegex(settings As Search.ChunkSearchSetting) As Regex
        Dim strRegex As String = String.Empty
        If Not settings.CaseSensitive Then strRegex &= "(?i)"
        If settings.IsWord Then
            strRegex &= $"(\b{Regex.Escape(settings.ChuckStart)}\b(.*?)\b{Regex.Escape(settings.ChunkEnd)}\b)"
        Else
            strRegex &= $"{Regex.Escape(settings.ChuckStart)}(.*?){Regex.Escape(settings.ChunkEnd)}"
        End If
        Return New Regex(strRegex, RegexOptions.Singleline)
    End Function

End Class