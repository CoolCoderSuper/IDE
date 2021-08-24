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

Public Enum FrameworkTypes
    DotNetFramework
    DotNetCore
End Enum