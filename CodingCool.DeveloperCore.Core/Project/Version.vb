''' <summary>
''' Represents a version number.
''' </summary>
Public Class Version

    Public Property Major As Integer

    Public Property Minor As Integer

    Public Property Patch As Integer

    Public Property BuildNumber As Integer

    Public Overrides Function ToString() As String
        Return $"{Major}.{Minor}.{Patch}.{BuildNumber}"
    End Function

    Public Shared Function Parse(str As String) As Version
        Dim lValues As String() = str.Split("."c)
        Dim objInfo As New Version
        If lValues.Count = 4 Then
            For i As Integer = 0 To lValues.Length Step 1
                Dim strItem As String = lValues(i)
                Dim intNum As Integer
                Integer.TryParse(strItem, intNum)
                If intNum = Nothing Then
                    Throw New ArgumentException("Invalid version string.", "str")
                Else
                    Select Case i
                        Case 0
                            objInfo.Major = intNum
                        Case 1
                            objInfo.Minor = intNum
                        Case 2
                            objInfo.Patch = intNum
                        Case 3
                            objInfo.BuildNumber = intNum
                    End Select
                End If
            Next
        Else
            Throw New ArgumentException("Invalid version string.", "str")
        End If
        Return objInfo
    End Function

End Class