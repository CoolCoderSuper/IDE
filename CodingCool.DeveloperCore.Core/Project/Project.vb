''' <summary>
''' Represents a project.
''' </summary>
Public Class Project

    Public Sub New()
        References = New List(Of Reference)
        Files = New List(Of File)
        DesignableObjects = New List(Of DesignableObject)
        Folders = New List(Of String)
    End Sub

    ''' <summary>
    ''' The name of the project.
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String

    ''' <summary>
    ''' The assembly's name.
    ''' </summary>
    ''' <returns></returns>
    Public Property AssemblyName As String

    ''' <summary>
    ''' Th relative path of the projects data folder.
    ''' </summary>
    ''' <returns></returns>
    Public Property RootFolder As String

    ''' <summary>
    ''' The root namespace.
    ''' </summary>
    ''' <returns></returns>
    Public Property RootNamespace As String

    ''' <summary>
    ''' States whether to generate an EXE on build. If false a DLL is built instead.
    ''' </summary>
    ''' <returns></returns>
    Public Property OutputEXE As Boolean

    ''' <summary>
    ''' The path to the icon for the app.
    ''' </summary>
    ''' <returns></returns>
    Public Property AppIcon As String

    ''' <summary>
    ''' Information about the target framework.
    ''' </summary>
    ''' <returns></returns>
    Public Property TargetFramework As Framework

    ''' <summary>
    ''' Informatio about this assembly.
    ''' </summary>
    ''' <returns></returns>
    Public Property AssemblyInfo As AssemblyInfo

    ''' <summary>
    ''' States wheher Application Framework is enabled.
    ''' </summary>
    ''' <returns></returns>
    Public Property EnableApplicationFramework As Boolean

    ''' <summary>
    ''' The startup object for app.
    ''' </summary>
    ''' <returns></returns>
    Public Property StartUpObject As String

    ''' <summary>
    ''' A list of references of the project.
    ''' </summary>
    ''' <returns></returns>
    Public Property References As List(Of Reference)

    ''' <summary>
    ''' A list of the projects files.
    ''' </summary>
    ''' <returns></returns>
    Public Property Files As List(Of File)

    ''' <summary>
    ''' A list of the application designable objects.
    ''' </summary>
    ''' <returns></returns>
    Public Property DesignableObjects As List(Of DesignableObject)

    ''' <summary>
    ''' A list of folders in the project.
    ''' </summary>
    ''' <returns></returns>
    Public Property Folders As List(Of String)

End Class