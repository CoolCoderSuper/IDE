''' <summary>
''' An error's type.
''' </summary>
Public Enum ErrorTypes
    [Error]
    Warning
    Info
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
End Enum

Public Enum AuthenticationModes
    Windows
    ApplicationDefined
End Enum

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

Public Enum Language
    VBDotNet
    CSharp
End Enum

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

Public Enum CopyTypes
    Copy
    Cut
End Enum