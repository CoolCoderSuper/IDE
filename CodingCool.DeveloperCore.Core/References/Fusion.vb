' .NET Fusion COM interfaces
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Text

'stolen from SD
<ComImport, Guid("CD193BC0-B4BC-11D2-9833-00C04FC31D2E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
Public Interface IAssemblyName

    <PreserveSig>
    Function SetProperty(ByVal PropertyId As UInteger, ByVal pvProperty As IntPtr, ByVal cbProperty As UInteger) As Integer

    <PreserveSig>
    Function GetProperty(ByVal PropertyId As UInteger, ByVal pvProperty As IntPtr, ByRef pcbProperty As UInteger) As Integer

    <PreserveSig>
    Function Finalize() As Integer

    <PreserveSig>
    Function GetDisplayName(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal szDisplayName As StringBuilder, ByRef pccDisplayName As UInteger, ByVal dwDisplayFlags As UInteger) As Integer

    <PreserveSig>
    Function BindToObject(ByVal refIID As Object, ByVal pAsmBindSink As Object, ByVal pApplicationContext As IApplicationContext, <MarshalAs(UnmanagedType.LPWStr)> ByVal szCodeBase As String, ByVal llFlags As Long, ByVal pvReserved As Integer, ByVal cbReserved As UInteger, <Out> ByRef ppv As Integer) As Integer

    <PreserveSig>
    Function GetName(ByRef lpcwBuffer As UInteger,
                <Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pwzName As StringBuilder) As Integer

    <PreserveSig>
    Function GetVersion(<Out> ByRef pdwVersionHi As UInteger, <Out> ByRef pdwVersionLow As UInteger) As Integer

    <PreserveSig>
    Function IsEqual(ByVal pName As IAssemblyName, ByVal dwCmpFlags As UInteger) As Integer

    <PreserveSig>
    Function Clone(<Out> ByRef pName As IAssemblyName) As Integer

End Interface

<ComImport(), Guid("7C23FF90-33AF-11D3-95DA-00A024A85B51"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
Public Interface IApplicationContext

    Sub SetContextNameObject(ByVal pName As IAssemblyName)

    Sub GetContextNameObject(<Out> ByRef ppName As IAssemblyName)

    Sub [Set](<MarshalAs(UnmanagedType.LPWStr)> ByVal szName As String, ByVal pvValue As Integer, ByVal cbValue As UInteger, ByVal dwFlags As UInteger)

    Sub [Get](<MarshalAs(UnmanagedType.LPWStr)> ByVal szName As String, <Out> ByRef pvValue As Integer, ByRef pcbValue As UInteger, ByVal dwFlags As UInteger)

    Sub GetDynamicDirectory(<Out> ByRef wzDynamicDir As Integer, ByRef pdwSize As UInteger)

End Interface

<ComImport(), Guid("21B8916C-F28E-11D2-A473-00C04F8EF448"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
Public Interface IAssemblyEnum

    <PreserveSig>
    Function GetNextAssembly(<Out> ByRef ppAppCtx As IApplicationContext, <Out> ByRef ppName As IAssemblyName, ByVal dwFlags As UInteger) As Integer

    <PreserveSig>
    Function Reset() As Integer

    <PreserveSig>
    Function Clone(<Out> ByRef ppEnum As IAssemblyEnum) As Integer

End Interface

Public Class Fusion

    ' dwFlags: 1 = Enumerate native image (NGEN) assemblies
    '          2 = Enumerate GAC assemblies
    '          4 = Enumerate Downloaded assemblies
    '
    <DllImport("fusion.dll", CharSet:=CharSet.Auto)>
    Public Shared Function CreateAssemblyEnum(<Out> ByRef ppEnum As IAssemblyEnum, ByVal pAppCtx As IApplicationContext, ByVal pName As IAssemblyName, ByVal dwFlags As UInteger, ByVal pvReserved As Integer) As Integer
    End Function

    Public Shared Iterator Function GetGacAsAssembly() As IEnumerable(Of AssemblyName)
        Dim applicationContext As IApplicationContext
        Dim assemblyEnum As IAssemblyEnum
        Dim assemblyName As IAssemblyName
        CreateAssemblyEnum(assemblyEnum, Nothing, Nothing, 2, 0)
        While assemblyEnum.GetNextAssembly(applicationContext, assemblyName, 0) = 0
            Dim nChars As UInteger = 0
            assemblyName.GetDisplayName(Nothing, nChars, 0)
            Dim name As New StringBuilder(CInt(nChars))
            assemblyName.GetDisplayName(name, nChars, 0)
            Dim a As AssemblyName = Nothing
            Try
                a = New AssemblyName(name.ToString())
            Catch ex As Exception
            End Try
            If a IsNot Nothing Then
                Yield a
            End If
        End While
    End Function

End Class