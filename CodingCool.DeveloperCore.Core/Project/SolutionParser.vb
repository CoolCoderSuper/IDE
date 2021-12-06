''' <summary>
''' Methods to parse a solution file.
''' </summary>
Public Class SolutionParser

    'Load solution settings
    ''' <summary>
    ''' Parses a file a returns the parsed object.
    ''' </summary>
    ''' <param name="strPath">The file to parse.</param>
    ''' <returns></returns>
    Public Shared Function Parse(strPath As String) As Solution
        Dim objDoc As XDocument = XDocument.Load(strPath)
        Dim nSolution As XElement = objDoc.Element("Solution")
        Dim objSolution As New Solution
        objSolution.Path = strPath
        objSolution.NugetCache = nSolution.Element("NugetCache").Value
        For Each nProject As XElement In nSolution.Elements("Project")
            Dim nSettings As XElement = nProject.Element("Settings")
            Dim objProject As New Project
            objProject.Name = nSettings.Element("Name").Value
            objProject.AssemblyName = nSettings.Element("AssemblyName").Value
            objProject.RootNamespace = nSettings.Element("RootNamespace").Value
            objProject.OutputEXE = Boolean.Parse(nSettings.Element("OutputExe").Value)
            objProject.EnableApplicationFramework = Boolean.Parse(nSettings.Element("EnableApplicationFramework").Value)
            objProject.StartUpObject = nSettings.Element("StartUpObject").Value
            objProject.Language = nSettings.Element("Language").Value.ToLanguage
            objProject.AssemblyInfo = nSettings.Element("AssemblyInfo").ToAssemblyInfo
            objProject.TargetFramework = nSettings.Element("TargetFramework").ToTargetFramework
            objProject.References = nProject.Element("References").ToReferences
            objProject.Files = nProject.Element("Files").ToFiles
            objSolution.Projects.Add(objProject)
        Next
        Return objSolution
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
        nSettings.Add(New XElement("Language", obj.Language.GetValue))
        nSettings.Add(obj.AssemblyInfo.ToXML)
        objDoc.Save(strPath)
    End Sub

End Class