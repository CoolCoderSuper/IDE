Imports System.Text.RegularExpressions

Namespace Search

    Public Class Searcher

        Public Function FindWord(word As String, settings As WordSearchSetting, input As String) As WordMatch()
            Dim lWords As New List(Of WordMatch)
            For Each m As Match In RegexBuilder.BuildWordRegex(word, settings).Matches(input)
                If settings.ContainsOnIgnoreWrap Then
                    If input.Select(Function(x, i) New With {x, i}).Where(Function(r) r.x = settings.IgnoreWrapBeginChar AndAlso r.i < m.Index).Select(Function(t) t.i).Count <> 0 AndAlso input.Select(Function(x, i) New With {x, i}).Where(Function(r) r.x = settings.IgnoreWrapEndChar AndAlso r.i > m.Length + m.Index - 1).Select(Function(t) t.i).Count Then
                        Continue For
                    End If
                Else
                    If m.Index - 1 > 0 AndAlso input(m.Index - 1) = settings.IgnoreWrapBeginChar AndAlso m.Length + m.Index < input.Length AndAlso input(m.Length + m.Index) = settings.IgnoreWrapEndChar Then
                        Continue For
                    End If
                End If
                Dim w As New WordMatch With {
                    .Word = m.Value,
                    .StartPos = m.Index,
                    .EndPos = m.Length + m.Index - 1,
                    .Length = m.Length,
                    .Input = input
                }
                lWords.Add(w)
            Next
            Return lWords.ToArray
        End Function

        Public Function FindChunk(input As String, settings As ChunkSearchSetting) As ChunkMatch()
            Dim lChunks As New List(Of ChunkMatch)
            For Each m As Match In RegexBuilder.BuildChunkRegex(settings).Matches(input)
                Dim c As New ChunkMatch With {
                    .Chunk = m.Value,
                    .StartPos = m.Index,
                    .EndPos = m.Length + m.Index - 1,
                    .Length = m.Length,
                    .Input = input
                }
                lChunks.Add(c)
            Next
            Return lChunks.ToArray
        End Function

    End Class

End Namespace