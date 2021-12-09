Imports System.Runtime.CompilerServices

Module ParserExtensions

    <Extension()>
    Public Function ToCopyToOutput(str As String) As CopyToOutputOptions
        Select Case str.ToLower.Trim
            Case "DoNotCopy"
                Return CopyToOutputOptions.DoNotCopy
            Case "CopyAlways"
                Return CopyToOutputOptions.CopyAlways
            Case "CopyIfNewer"
                Return CopyToOutputOptions.CopyIfNewer
            Case Else
                Return Nothing
        End Select
    End Function

    <Extension()>
    Public Function ToFramework(str As String) As FrameworkTypes
        Select Case str.ToLower.Trim
            Case ".net framework"
                Return FrameworkTypes.DotNetFramework
            Case ".net core" Or ".net"
                Return FrameworkTypes.DotNetCore
            Case "mono"
                Return FrameworkTypes.Mono
            Case Else
                Return Nothing
        End Select
    End Function

    <Extension()>
    Public Function ToLanguage(str As String) As Language
        Select Case str.ToLower.Trim
            Case "VB.NET"
                Return Language.VBDotNet
            Case "C#"
                Return Language.CSharp
            Case Else
                Return Nothing
        End Select
    End Function

    <Extension()>
    Public Function ToDesignableObjects(el As XElement) As List(Of DesignableObject)
        Dim lObjects As New List(Of DesignableObject)
        For Each nObject As XElement In el.Elements("DesignableObject")
            Dim objInfo As New DesignableObject
            objInfo.Name = nObject.Element("Name").Value
            objInfo.Files = nObject.Element("Files").ToFiles
            lObjects.Add(objInfo)
        Next
        Return lObjects
    End Function

    <Extension()>
    Public Function ToFiles(el As XElement) As List(Of File)
        Dim lFiles As New List(Of File)
        For Each nFile As XElement In el.Elements("File")
            Dim objFile As New File
            objFile.Path = nFile.Element("Path").Value
            objFile.CopyToOutput = nFile.Element("CopyToOutput").Value.ToCopyToOutput
            lFiles.Add(objFile)
        Next
        Return lFiles
    End Function

    <Extension()>
    Public Function ToReferences(el As XElement) As List(Of Reference)
        Dim lRefs As New List(Of Reference)
        For Each nRef As XElement In el.Elements("Reference")
            Dim objRef As New Reference
            objRef.Path = nRef.Element("Path").Value
            objRef.CopyLocal = Boolean.Parse(nRef.Element("CopyLocal").Value)
            objRef.EmbedInteropTypes = Boolean.Parse(nRef.Element("EmbedInteropTypes").Value)
            objRef.SpecificVersion = Boolean.Parse(nRef.Element("SpecificVersion").Value)
            lRefs.Add(objRef)
        Next
        Return lRefs
    End Function

    <Extension()>
    Public Function ToTargetFramework(el As XElement) As Framework
        Dim objInfo As New Framework
        objInfo.FrameworkType = el.Element("Type").Value.ToFramework
        objInfo.Version = Version.Parse(el.Element("Verson").Value)
        Return objInfo
    End Function

    <Extension()>
    Public Function ToAssemblyInfo(el As XElement) As AssemblyInfo
        Dim objInfo As New AssemblyInfo
        objInfo.Title = el.Element("Title").Value
        objInfo.Description = el.Element("Description").Value
        objInfo.Company = el.Element("Company").Value
        objInfo.Product = el.Element("Product").Value
        objInfo.Copyright = el.Element("Copyright").Value
        objInfo.Trademark = el.Element("Trademark").Value
        objInfo.AssemblyVersion = Version.Parse(el.Element("AssemblyInfo").Value)
        objInfo.FileVersion = Version.Parse(el.Element("FileVersion").Value)
        objInfo.COMVisible = Boolean.Parse(el.Element("COMVisible").Value)
        Return objInfo
    End Function

    <Extension()>
    Public Function ToXML(obj As AssemblyInfo) As XElement
        Dim nInfo As New XElement("AssemblyInfo")
        nInfo.Add(New XElement("AssemblyVersion", obj.AssemblyVersion.ToString))
        nInfo.Add(New XElement("Company", obj.Company))
        nInfo.Add(New XElement("COMVisible", obj.COMVisible.ToString))
        nInfo.Add(New XElement("Copyright", obj.Copyright))
        nInfo.Add(New XElement("Description", obj.Description))
        nInfo.Add(New XElement("FileVersion", obj.FileVersion.ToString))
        nInfo.Add(New XElement("GUID", obj.GUID))
        nInfo.Add(New XElement("Product", obj.Product))
        nInfo.Add(New XElement("Title", obj.Title))
        nInfo.Add(New XElement("Trademark", obj.Trademark))
        Return nInfo
    End Function

    <Extension()>
    Public Function ToXML(obj As List(Of File)) As XElement
        Dim nInfo As New XElement("Files")

        Return nInfo
    End Function

End Module