Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Security
Imports Microsoft.Win32

'stolen from SD
Public Class TypeLibrary
    Private nameField As String
    Private descriptionField As String
    Private pathField As String
    Private guidField As String
    Private versionField As String
    Private lcidField As String
    Private isolatedField As Boolean

    Public ReadOnly Property Guid As String
        Get
            Return guidField
        End Get
    End Property

    Public ReadOnly Property Isolated As Boolean
        Get
            Return isolatedField
        End Get
    End Property

    Public ReadOnly Property Lcid As String
        Get
            Return lcidField
        End Get
    End Property

    Public ReadOnly Property Name As String
        Get
            If nameField = Nothing Then GetTypeLibName()
            Return nameField
        End Get
    End Property

    Public ReadOnly Property Description As String
        Get
            Return descriptionField
        End Get
    End Property

    Public ReadOnly Property Path As String
        Get
            Return pathField
        End Get
    End Property

    Public ReadOnly Property Version As String
        Get
            Return versionField
        End Get
    End Property

    Public ReadOnly Property VersionMajor As Integer
        Get
            If versionField = Nothing Then Return -1
            Dim strArray As String() = versionField.Split("."c)
            Return If(strArray.Length <> 0, GetVersion(strArray(0)), -1)
        End Get
    End Property

    Public ReadOnly Property VersionMinor As Integer
        Get
            If versionField = Nothing Then Return -1
            Dim strArray As String() = versionField.Split("."c)
            Return If(strArray.Length >= 2, GetVersion(strArray(1)), -1)
        End Get
    End Property

    Public ReadOnly Property WrapperTool As String
        Get
            Return "tlbimp"
        End Get
    End Property

    Public Shared ReadOnly Iterator Property Libraries As IEnumerable(Of TypeLibrary)
        Get
            Dim typeLibsKey As RegistryKey = Registry.ClassesRoot.OpenSubKey("TypeLib")
            For Each subKeyName As String In typeLibsKey.GetSubKeyNames()
                Dim typeLibKey As RegistryKey = Nothing
                Try
                    typeLibKey = typeLibsKey.OpenSubKey(subKeyName)
                Catch ex As SecurityException
                End Try
                If typeLibKey IsNot Nothing Then
                    Dim [lib] As TypeLibrary = Create(typeLibKey)
                    If [lib] IsNot Nothing AndAlso [lib].Description <> Nothing AndAlso [lib].Path <> Nothing AndAlso [lib].Description.Length > 0 AndAlso [lib].Path.Length > 0 Then Yield [lib]
                End If
            Next
        End Get
    End Property

    Private Shared Function Create(typeLibKey As RegistryKey) As TypeLibrary
        Dim subKeyNames As String() = typeLibKey.GetSubKeyNames()
        If subKeyNames.Length <= 0 Then Return Nothing
        Dim typeLibrary As TypeLibrary = New TypeLibrary()
        typeLibrary.versionField = subKeyNames(subKeyNames.Length - 1)
        Dim versionKey As RegistryKey = typeLibKey.OpenSubKey(typeLibrary.versionField)
        typeLibrary.descriptionField = CStr(versionKey.GetValue(Nothing))
        typeLibrary.pathField = TypeLibrary.GetTypeLibPath(versionKey, typeLibrary.lcidField)
        typeLibrary.guidField = System.IO.Path.GetFileName(typeLibKey.Name)
        Return typeLibrary
    End Function

    Private Shared Function GetTypeLibPath(versionKey As RegistryKey, ByRef lcid As String) As String
        Dim subKeyNames As String() = versionKey.GetSubKeyNames()
        If subKeyNames Is Nothing OrElse subKeyNames.Length = 0 Then Return Nothing
        Dim __ As Integer = Nothing
        Dim index As Integer = 0

        While index < subKeyNames.Length

            If Integer.TryParse(subKeyNames(index), __) Then
                lcid = subKeyNames(index)
                Dim registryKey1 As RegistryKey = versionKey.OpenSubKey(subKeyNames(index))
                registryKey1.GetSubKeyNames()
                Dim registryKey2 As RegistryKey = registryKey1.OpenSubKey("win32")
                Return If(registryKey2 IsNot Nothing AndAlso registryKey2.GetValue(Nothing) IsNot Nothing, TypeLibrary.GetTypeLibPath(registryKey2.GetValue(Nothing).ToString()), Nothing)
            End If

            Threading.Interlocked.Increment(index)
        End While
        Return Nothing
    End Function

    Private Shared Function GetVersion(s As String) As Integer
        Dim num As Integer
        Return If(Integer.TryParse(s, num) OrElse TypeLibrary.TryParseHexNumber(s, num), num, -1)
    End Function

    Private Shared Function TryParseHexNumber(s As String, <Out> ByRef number As Integer) As Boolean
        Return Integer.TryParse(s, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, number)
    End Function

    Private Function GetTypeLibName() As String
        Dim str As String = Nothing
        Dim result As Integer
        If guidField <> Nothing AndAlso lcidField <> Nothing AndAlso Integer.TryParse(lcidField, result) Then
            str = TypeLibrary.GetTypeLibNameFromGuid(New Guid(guidField), VersionMajor, VersionMinor, result)
        End If
        If str = Nothing Then str = GetTypeLibNameFromFile(pathField)
        Return If(str, descriptionField)
    End Function

    Private Shared Function GetTypeLibPath(fileName As String) As String
        If fileName <> Nothing Then
            Dim length As Integer = fileName.LastIndexOf("\"c)
            If length > 0 AndAlso length + 1 < fileName.Length AndAlso Char.IsDigit(fileName(length + 1)) Then Return fileName.Substring(0, length)
        End If
        Return fileName
    End Function

    Private Shared Function GetTypeLibNameFromFile(fileName As String) As String
        If fileName <> Nothing AndAlso fileName.Length > 0 AndAlso IO.File.Exists(fileName) Then
            Dim pptlib As ITypeLib
            If LoadTypeLibEx(fileName, RegKind.None, pptlib) Then
                Try
                    Return Marshal.GetTypeLibName(pptlib)
                Finally
                    Marshal.ReleaseComObject(pptlib)
                End Try
            End If
        End If
        Return Nothing
    End Function

    Private Shared Function GetTypeLibNameFromGuid(ByRef guid As System.Guid, versionMajor As Short, versionMinor As Short, lcid As Integer) As String
        Dim pptlib As ITypeLib
        If LoadRegTypeLib(guid, versionMajor, versionMinor, lcid, pptlib) <> 0 Then Return Nothing
        Try
            Return Marshal.GetTypeLibName(pptlib)
        Finally
            Marshal.ReleaseComObject(pptlib)
        End Try
    End Function

    <DllImport("oleaut32.dll")>
    Private Shared Function LoadTypeLibEx(
                  <MarshalAs(UnmanagedType.BStr)> szFile As String, regkind As RegKind, <Out> ByRef pptlib As ITypeLib) As Integer
    End Function

    <DllImport("oleaut32.dll")>
    Private Shared Function LoadRegTypeLib(ByRef rguid As System.Guid, wVerMajor As Short, wVerMinor As Short, lcid As Integer, <Out> ByRef pptlib As ITypeLib) As Integer
    End Function

    Private Enum RegKind
        [Default]
        Register
        None
    End Enum

End Class