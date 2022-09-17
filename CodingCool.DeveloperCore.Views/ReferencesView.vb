Imports Microsoft.Win32

Public Class ReferencesView

    Private Sub LoadGAC()
        Dim p As New Process
        p.StartInfo.CreateNoWindow = True
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.UseShellExecute = False
        p.StartInfo.FileName = "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\gacutil.exe"
        p.StartInfo.Arguments = "-l"
        p.Start()
        Dim output As IO.StreamReader = p.StandardOutput
        Dim lResult As New List(Of GridGACRef)
        While Not output.EndOfStream
            Try
                Dim aName As Reflection.AssemblyName = New Reflection.AssemblyName(output.ReadLine)
                lResult.Add(New GridGACRef With {.Name = aName.Name, .Version = If(aName.Version Is Nothing, "", aName.Version.ToString)})
            Catch ex As Exception

            End Try
        End While
        lResult.RemoveRange(0, 2)
        dgvGAC.DataSource = lResult
        dgvGAC.Columns(0).Width = 200
    End Sub

    Private Sub LoadCOM()
        Dim lCLSID As String() = CType(Registry.ClassesRoot.GetValue("CLSID"), RegistryKey).GetSubKeyNames
        Dim lResult As New List(Of GridCOMRef)
        For Each clsid As String In lCLSID
            lResult.Add(New GridCOMRef() With {.Name = Registry.ClassesRoot.GetValue(clsid).GetValue})
        Next
        dgvCOM.DataSource = lResult
    End Sub

    Private Sub ReferencesView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGAC()
        'LoadCOM()
    End Sub

    Public Class GridGACRef
        Public Property Name As String
        Public Property Version As String
    End Class

    Public Class GridCOMRef
        Public Property Name As String
        Public Property Path As String
    End Class

End Class