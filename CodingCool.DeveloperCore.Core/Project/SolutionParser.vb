''' <summary>
''' Methods to parse a solution file.
''' </summary>
Public Class SolutionParser

    ''' <summary>
    ''' Parses a file a returns the parsed object.
    ''' </summary>
    ''' <param name="strPath">The file to parse.</param>
    ''' <returns></returns>
    Public Shared Function Parse(strPath As String) As Project
        Dim objDoc As XDocument = XDocument.Load(strPath)
        Dim nProject As XElement = objDoc.Element("Project")
        Dim nSettings As XElement = nProject.Element("Settings")
        Dim objProject As New Project
        objProject.Name = nSettings.Element("Name").Value
        objProject.AssemblyName = nSettings.Element("AssemblyName").Value
        objProject.RootNamespace = nSettings.Element("RootNamespace").Value
        objProject.OutputEXE = Boolean.Parse(nSettings.Element("OutputExe").Value)
        objProject.EnableApplicationFramework = Boolean.Parse(nSettings.Element("EnableApplicationFramework").Value)
        objProject.StartUpObject = nSettings.Element("StartUpObject").Value
        objProject.Language = ParseLanguage(nSettings.Element("Language").Value)
        objProject.AssemblyInfo = GetAssemblyInfo(nSettings.Element("AssemblyInfo"))
        objProject.TargetFramework = GetTargetFramework(nSettings.Element("TargetFramework"))
        objProject.References = GetReferences(nProject.Element("References"))
        objProject.Files = GetFiles(nProject.Element("Files"))
        Return objProject
    End Function

    ''' <summary>
    ''' Saves solution object to file.
    ''' </summary>
    ''' <param name="strPath">The location to save to.</param>
    ''' <param name="obj">The object to save.</param>
    Public Shared Sub Save(strPath As String, obj As Project)
        Dim objDoc As New XDocument
        objDoc.Root.Name = "Project"
        Dim nSettings As New XElement("Settings")
        nSettings.Add(New XElement("Name", obj.Name))
        nSettings.Add(New XElement("AssemblyName", obj.AssemblyName))
        nSettings.Add(New XElement("OutputExe", obj.OutputEXE.ToString))
        nSettings.Add(New XElement("EnableApplicationFramework", obj.EnableApplicationFramework.ToString))
        nSettings.Add(New XElement("StartUpObject", obj.StartUpObject))
        nSettings.Add(SaveAssemblyInfo(obj.AssemblyInfo))
        objDoc.Save(strPath)
    End Sub

    Private Shared Function SaveAssemblyInfo(obj As AssemblyInfo) As XElement

    End Function

#Region "Helpers"

#Region "Parser"

    Private Shared Function GetDesignableObjects(el As XElement) As List(Of DesignableObject)
        Dim lObjects As New List(Of DesignableObject)
        For Each nObject As XElement In el.Elements("DesignableObject")
            Dim objInfo As New DesignableObject
            objInfo.Name = nObject.Element("Name").Value
            objInfo.Files = GetFiles(nObject.Element("Files"))
            lObjects.Add(objInfo)
        Next
        Return lObjects
    End Function

    Private Shared Function GetFiles(el As XElement) As List(Of File)
        Dim lFiles As New List(Of File)
        For Each nFile As XElement In el.Elements("File")
            Dim objFile As New File
            objFile.Path = nFile.Element("Path").Value
            objFile.CopyToOutput = ParseCopyToOutput(nFile.Element("CopyToOutput").Value)
            lFiles.Add(objFile)
        Next
        Return lFiles
    End Function

    Private Shared Function GetReferences(el As XElement) As List(Of Reference)
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

    Private Shared Function GetTargetFramework(el As XElement) As Framework
        Dim objInfo As New Framework
        objInfo.FrameworkType = ParseFramework(el.Element("Type").Value)
        objInfo.Version = Version.Parse(el.Element("Verson").Value)
        Return objInfo
    End Function

    Private Shared Function GetAssemblyInfo(el As XElement) As AssemblyInfo
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

#End Region

    Private Shared Function ParseCopyToOutput(str As String) As CopyToOutputOptions
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

    Private Shared Function ParseFramework(str As String) As FrameworkTypes
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

    Private Shared Function ParseLanguage(str As String) As Language
        Select Case str.ToLower.Trim
            Case "VB.NET"
                Return Language.VBDotNet
            Case "C#"
                Return Language.CSharp
            Case Else
                Return Nothing
        End Select
    End Function

#End Region

End Class