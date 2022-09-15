''' <summary>
''' An error's type.
''' </summary>
Public Enum ErrorTypes
    [Error]
    Warning
    Suggestion
    Hidden
End Enum

Public Enum ExplorerItemTypes
    [Class]
    Method
    [Property]
    [Event]
    [Operator]
    Variable
    [Interface]
    Struct
    [Namespace]
    [Enum]
    [Module]
End Enum

''' <summary>
''' Represents a projects athentication mode.
''' </summary>
Public Enum AuthenticationModes
    Windows
    ApplicationDefined
End Enum

''' <summary>
''' Represents a objects copy to output rules.
''' </summary>
Public Enum CopyToOutputOptions
    DoNotCopy
    CopyAlways
    CopyIfNewer
End Enum

''' <summary>
''' Represents a framework type. Mono, .NET, act.
''' </summary>
Public Enum FrameworkTypes
    DotNetFramework
    DotNetCore
    Mono
End Enum

''' <summary>
''' Represents supported languages.
''' </summary>
Public Enum Language
    VBDotNet
    CSharp
End Enum

''' <summary>
''' Represents actions that can be done in the solution explorer.
''' </summary>
Public Enum ActionTypes
    Create
    Delete
    ViewCode
    Exclude
    Cut
    Paste
    CopyFullPath
    OpenInFileExplorer
    Open
    OpenWith
End Enum

''' <summary>
''' Represents different ways to copy files.
''' </summary>
Public Enum CopyTypes
    Copy
    Cut
End Enum