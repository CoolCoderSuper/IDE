Public Class SolutionParser

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
        objProject.AssemblyInfo = GetAssemblyInfo(nSettings.Element("AssemblyInfo"))
    End Function

    Private Shared Function GetTargetFramework(el As XElement) As Framework
        Dim objInfo As New Framework

    End Function

    Private Shared Function GetAssemblyInfo(el As XElement) As AssemblyInfo
        Dim objInfo As New AssemblyInfo
        objInfo.Title = el.Element("Title").Value
        objInfo.Description = el.Element("Description").Value
        objInfo.Company = el.Element("Company").Value
        objInfo.Product = el.Element("Product").Value
        objInfo.Copyright = el.Element("Copyright").Value
        objInfo.Trademark = el.Element("Trademark").Value
        objInfo.AssemblyVersion = el.Element("AssemblyInfo").Value
        objInfo.COMVisible = Boolean.Parse(el.Element("COMVisible").Value)
        Return objInfo
    End Function

End Class