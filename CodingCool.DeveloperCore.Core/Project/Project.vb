Public Class Project

    Public Property Name As String

    Public Property AssemblyName As String

    Public Property RootNamespace As String

    Public Property OutputEXE As Boolean

    Public Property AppIcon As String

    Public Property TargetFramework As Framework

    Public Property AssemblyInfo As AssemblyInfo

    Public Property EnableApplicationFramework As Boolean

    Public Property StartUpObject As String

    Public Property References As List(Of Reference)

    Public Property Files As List(Of File)

    Public Property DesignableObjects As List(Of DesignableObject)

    Public Property Folders As List(Of String)
End Class
