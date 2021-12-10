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
            objProject.DesignableObjects = nProject.Element("DesignableObjects").ToDesignableObjects
            objSolution.Projects.Add(objProject)
        Next
        Return objSolution
    End Function

    ''' <summary>
    ''' Saves solution object to file.
    ''' </summary>
    ''' <param name="obj">The object to save.</param>
    Public Shared Sub Save(obj As Solution)
        Dim objDoc As New XDocument
        objDoc.Root.Name = "Solution"
        objDoc.Root.Add(New XElement("NugetCache", obj.NugetCache))
        For Each objProject As Project In obj.Projects
            Dim nProject As New XElement("Project")
            Dim nSettings As New XElement("Settings")
            nSettings.Add(New XElement("Name", objProject.Name))
            nSettings.Add(New XElement("AssemblyName", objProject.AssemblyName))
            nSettings.Add(New XElement("OutputExe", objProject.OutputEXE.ToString))
            nSettings.Add(New XElement("EnableApplicationFramework", objProject.EnableApplicationFramework.ToString))
            nSettings.Add(New XElement("StartUpObject", objProject.StartUpObject))
            nSettings.Add(New XElement("Language", objProject.Language.GetString))
            nSettings.Add(objProject.AssemblyInfo.ToXML)
            nSettings.Add(objProject.TargetFramework.ToXML)
            nProject.Add(nSettings)
            nProject.Add(objProject.References.ToXML)
            nProject.Add(objProject.Files.ToXML)
            nProject.Add(objProject.DesignableObjects.ToXML)
            objDoc.Root.Add(nProject)
        Next
        objDoc.Save(obj.Path)
    End Sub

End Class