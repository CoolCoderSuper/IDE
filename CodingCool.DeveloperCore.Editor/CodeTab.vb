Imports System.ComponentModel
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports CodingCool.DeveloperCore.Core
Imports FarsiLibrary.Win
Imports FastColoredTextBoxNS
'TODO: Reference list of Assemblies instead of reading project file
Public Class CodeTab
    Inherits FATabStripItem

#Region "Components"
    Friend WithEvents docMap As DocumentMap
    Public WithEvents txtEditor As FastColoredTextBox
    Private components As System.ComponentModel.IContainer
    Friend WithEvents popupMenu As AutocompleteMenu
    Dim items As List(Of AutocompleteItem)
    Dim strRoot As String

#End Region

#Region "Styles"

    Dim BlueStyle As TextStyle = New TextStyle(Brushes.Blue, Nothing, FontStyle.Regular)
    Dim BoldStyle As TextStyle = New TextStyle(Nothing, Nothing, FontStyle.Bold Or FontStyle.Underline)
    Dim BrownStyle As TextStyle = New TextStyle(Brushes.Brown, Nothing, FontStyle.Italic)
    Dim GrayStyle As TextStyle = New TextStyle(Brushes.Gray, Nothing, FontStyle.Regular)
    Dim GreenStyle As TextStyle = New TextStyle(Brushes.Green, Nothing, FontStyle.Italic)
    Dim MagentaStyle As TextStyle = New TextStyle(Brushes.Magenta, Nothing, FontStyle.Regular)
    Dim MaroonStyle As TextStyle = New TextStyle(Brushes.Maroon, Nothing, FontStyle.Regular)
    Dim ObjectStyle As TextStyle = New TextStyle(Brushes.DarkGreen, Nothing, FontStyle.Regular)
    Dim MethodStyle As TextStyle = New TextStyle(Brushes.BurlyWood, Nothing, FontStyle.Regular)
    Dim HyperLinkStyle As TextStyle = New TextStyle(Brushes.Blue, Nothing, FontStyle.Underline)
    Dim SameWordsStyle As MarkerStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(40, Color.Gray)))

#End Region

#Region "Autocomplete items"

    Private WithEvents autocompleteImg As ImageList

    Private CSdeclarationSnippets As String() = {"public class ^" & vbLf & "{" & vbLf & "}", "private class ^" & vbLf & "{" & vbLf & "}", "internal class ^" & vbLf & "{" & vbLf & "}", "public struct ^" & vbLf & "{" & vbLf & ";" & vbLf & "}", "private struct ^" & vbLf & "{" & vbLf & ";" & vbLf & "}", "internal struct ^" & vbLf & "{" & vbLf & ";" & vbLf & "}",
     "public void ^()" & vbLf & "{" & vbLf & ";" & vbLf & "}", "private void ^()" & vbLf & "{" & vbLf & ";" & vbLf & "}", "internal void ^()" & vbLf & "{" & vbLf & ";" & vbLf & "}", "protected void ^()" & vbLf & "{" & vbLf & ";" & vbLf & "}", "public ^{ get; set; }", "private ^{ get; set; }",
     "internal ^{ get; set; }", "protected ^{ get; set; }"}

    Private CSKeyWords As String() = {"abstract", "as", "base", "bool", "break", "byte",
             "case", "catch", "char", "checked", "class", "const",
     "continue", "decimal", "default", "delegate", "do", "double",
     "else", "enum", "event", "explicit", "extern", "false",
     "finally", "fixed", "float", "for", "foreach", "goto",
     "if", "implicit", "in", "int", "interface", "internal",
     "is", "lock", "long", "namespace", "new", "null",
     "object", "operator", "out", "override", "params", "private",
     "protected", "public", "readonly", "ref", "return", "sbyte",
     "sealed", "short", "sizeof", "stackalloc", "static", "string",
     "struct", "switch", "this", "throw", "true", "try",
     "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort",
     "using", "virtual", "void", "volatile", "while", "add",
     "alias", "ascending", "descending", "dynamic", "from", "get",
     "global", "group", "into", "join", "let", "orderby",
     "partial", "remove", "select", "set", "value", "var",
     "where", "yield"}

    Private CSSnippets As String() = {"if(^)" & vbLf & "{" & vbLf & ";" & vbLf & "}", "if(^)" & vbLf & "{" & vbLf & ";" & vbLf & "}" & vbLf & "else" & vbLf & "{" & vbLf & ";" & vbLf & "}", "for(^;;)" & vbLf & "{" & vbLf & ";" & vbLf & "}", "while(^)" & vbLf & "{" & vbLf & ";" & vbLf & "}", "do${" & vbLf & "^;" & vbLf & "}while();", "switch(^)" & vbLf & "{" & vbLf & "case : break;" & vbLf & "}"}
    Private Methods As String() = {"Equals()", "GetHashCode()", "GetType()", "ToString()"}
    Private VBDecSnippets As String() = {$"Public Class ^{vbLf}{vbLf}End Class", $"Private Class ^{vbLf}{vbLf}End Class", $"Module ^{vbLf}{vbLf}End Module", $"Public Structure ^{vbLf}{vbLf}End Structure", $"Private Structure ^{vbLf}{vbLf}End Structure", $"Namespace ^{vbLf}{vbLf}End Namespace", $"Public Function ^() As Object{vbLf}{vbLf}End Function", $"Private Function ^() As Object{vbLf}{vbLf}End Function", $"Public Sub ^(){vbLf}{vbLf}End Sub", $"Private Sub ^(){vbLf}{vbLf}End Sub", "Public Property ^", "Private Property ^", $"Private Enum ^{vbLf}{vbLf}End Enum", $"Public Enum ^{vbLf}{vbLf}End Enum"}
    Private VBKeyWords As String() = {"AddHandler", "AddressOf", "Alias", "AndAlso", "And", "As", "Boolean", "ByRef", "Byte", "ByVal", "Call", "Case", "Catch", "CBool", "CByte", "CChar", "CDate", "CDbl", "CDec", "Char", "CInt", "Class", "CLng", "CObj", "Const", "Continue", "CSByte", "CUInt", "CULng", "CUShort", "Date", "Decimal", "Declare", "Default", "Delegate", "Dim", "DirectCast", "Do", "Double", "Each", "Else", "ElseIf", "End", "Enum", "Erase", "Error", "Event", "Exit", "False", "Finally", "Friend", "Function", "Function", "Get", "GetType", "GetXMLNamespace", "Global", "GoTo", "Handles", "If", "Implements", "Imports", "In", "Inherits", "Integer", "Interface", "Is", "IsNot", "Let", "Lib", "Like", "Long", "Loop", "Me", "Mod", "Module", "MustInherit", "MustOveride", "MyBase", "MyClass", "NameOf", "Namespace", "Narrowing", "Next", "Not", "Nothing", "NotInheritable", "NotOverridable", "Object", "Of", "On", "Operator", "Option", "Optional", "Or", "OrElse", "Overloads", "Overridable", "Overrides", "ParamArray", "Partial", "Private", "Property", "Protected", "Public", "RaiseEvent", "ReadOnly", "ReDim", "RemoveHandler", "Resume", "Return", "SByte", "Select", "Set", "Shadows", "Shared", "Short", "Single", "Static", "Step", "Stop", "String", "Sub", "SyncLock", "Then", "Throw", "To", "True", "Try", "TryCast", "UInteger", "ULong", "UShort", "Using", "When", "While", "Widening", "With", "WithEvents", "WriteOnly", "Xor", "For", "Aggregate", "Ansi", "Assembly", "Async", "Auto", "Await", "Binary", "Compare", "Custom", "Distinct", "Equals", "Explicit", "From", "Into", "IsFalse", "IsTrue", "Iterator", "Join", "Key", "Mid", "Off", "Preserve", "Skip", "Strict", "Take", "Text", "Unicode", "Until", "Where", "Yield"}

    Private VBSnippets As String() = {$"If ^{vbLf}{vbLf}End If", $"If ^{vbLf}{vbLf}Else{vbLf}{vbLf}End If", $"For i As Integer To ^ Step 1{vbLf}{vbLf}Next", $"For Each item As Object In ^{vbLf}{vbLf}Next", $"With ^{vbLf}{vbLf}End With", $"While ^{vbLf}{vbLf}End While", "Public Event ^", $"Public Shared Operator ^{vbLf}{vbLf}End Operator", "Private Event ^"}

#End Region

    Public Property FilePath As String
    Public Property Language As Language = Language.Custom

    Public Sub Save()
        Try
            IO.File.WriteAllText(FilePath, txtEditor.Text)
            Title = IO.Path.GetFileName(FilePath)
        Catch ex As Exception

        End Try
    End Sub

#Region "Intialization"

    Public Sub New(l As Language, strPR As String)
        items = New List(Of AutocompleteItem)
        InitializeComponent()
        InitStylesPriority()
        Language = l
        strRoot = strPR
        If Language = Language.CSharp Then
            BuildCSAutocompleteMenu()
            Me.txtEditor.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        ElseIf Language = Language.VB Then
            BuildVBAutocompleteMenu()
            Me.txtEditor.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34)}
        End If
    End Sub

    Public Sub Init()
        txtEditor.Text = IO.File.ReadAllText(FilePath)
        Title = IO.Path.GetFileName(FilePath)
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CodeTab))
        Me.txtEditor = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.docMap = New FastColoredTextBoxNS.DocumentMap()
        Me.autocompleteImg = New System.Windows.Forms.ImageList(Me.components)
        Me.popupMenu = New AutocompleteMenu(txtEditor)
        CType(Me.txtEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtEditor
        '
        Me.txtEditor.AutoCompleteBrackets = True
        Me.txtEditor.AutoScrollMinSize = New System.Drawing.Size(2, 18)
        Me.txtEditor.BackBrush = Nothing
        Me.txtEditor.BackColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.txtEditor.CharHeight = 18
        Me.txtEditor.CharWidth = 9
        Me.txtEditor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEditor.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEditor.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.txtEditor.ForeColor = System.Drawing.Color.White
        Me.txtEditor.IsReplaceMode = False
        Me.txtEditor.Location = New System.Drawing.Point(0, 0)
        Me.txtEditor.Name = "txtEditor"
        Me.txtEditor.Paddings = New System.Windows.Forms.Padding(0)
        Me.txtEditor.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEditor.ShowFoldingLines = True
        Me.txtEditor.Size = New System.Drawing.Size(16, 100)
        Me.txtEditor.TabIndex = 1
        Me.txtEditor.ToolTipDelay = 250
        Me.txtEditor.Zoom = 100
        '
        'docMap
        '
        Me.docMap.BackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.docMap.Dock = System.Windows.Forms.DockStyle.Right
        Me.docMap.ForeColor = System.Drawing.Color.Maroon
        Me.docMap.Location = New System.Drawing.Point(16, 0)
        Me.docMap.Name = "docMap"
        Me.docMap.Size = New System.Drawing.Size(184, 100)
        Me.docMap.TabIndex = 1
        Me.docMap.Target = Me.txtEditor
        Me.docMap.Text = "Document Map"
        '
        'autocompleteImg
        '
        Me.autocompleteImg.ImageStream = CType(resources.GetObject("autocompleteImg.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.autocompleteImg.TransparentColor = System.Drawing.Color.Transparent
        Me.autocompleteImg.Images.SetKeyName(0, "script_16x16.png")
        Me.autocompleteImg.Images.SetKeyName(1, "app_16x16.png")
        Me.autocompleteImg.Images.Add("Method", My.Resources.method_new)
        Me.autocompleteImg.Images.Add("Keyword", My.Resources.keyword)
        Me.autocompleteImg.Images.Add("Property", My.Resources.property_new)
        Me.autocompleteImg.Images.Add("Class", My.Resources.class_new)
        popupMenu.Items.ImageList = autocompleteImg
        popupMenu.SearchPattern = "[\w\.:=!<>]"
        popupMenu.AllowTabKey = True
        '
        'CodeTab
        '
        Me.Controls.Add(Me.txtEditor)
        Me.Controls.Add(Me.docMap)
        CType(Me.txtEditor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub



    Private Sub InitStylesPriority()
        txtEditor.ClearStylesBuffer()
        txtEditor.AddStyle(SameWordsStyle)
    End Sub

#End Region

#Region "Syntax"

    Private Sub CSharpSyntaxHighlight(ByVal e As TextChangedEventArgs)
        txtEditor.LeftBracket = "("
        txtEditor.RightBracket = ")"
        txtEditor.LeftBracket2 = "\x0"
        txtEditor.RightBracket2 = "\x0"
        txtEditor.CommentPrefix = "//"
        e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle)
        e.ChangedRange.SetStyle(BrownStyle, """.*?""|'.+?'")
        e.ChangedRange.SetStyle(GreenStyle, "//.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(GreenStyle, "(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline)
        e.ChangedRange.SetStyle(GreenStyle, "(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline Or RegexOptions.RightToLeft)
        e.ChangedRange.SetStyle(MagentaStyle, "\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b")
        e.ChangedRange.SetStyle(GrayStyle, "^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline)
        'e.ChangedRange.SetStyle(BoldStyle, "\b(class|struct|enum|interface|namespace)\s+(?<range>\w+?)\b")
        e.ChangedRange.SetStyle(BlueStyle, "\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b")
        e.ChangedRange.ClearFoldingMarkers()
        e.ChangedRange.SetFoldingMarkers("{", "}")
        e.ChangedRange.SetFoldingMarkers("#region\b", "#endregion\b")
        e.ChangedRange.SetFoldingMarkers("/\*", "\*/")
    End Sub

    Private Sub VBSyntaxHighlight(ByVal e As TextChangedEventArgs)
        txtEditor.LeftBracket = "("
        txtEditor.RightBracket = ")"
        txtEditor.LeftBracket2 = "{"
        txtEditor.RightBracket2 = "}"
        txtEditor.CommentPrefix = "'"
        e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle)
        e.ChangedRange.SetStyle(BrownStyle, """.*?""|'.+?'")
        e.ChangedRange.SetStyle(GreenStyle, "'.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(MagentaStyle, "([0-9.*/+\-\^\&\<\>])+")
        e.ChangedRange.SetStyle(GrayStyle, "'''.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(BlueStyle, "(?i)\b(addhandler|andalso|addressof|alias|and|as|boolean|byref|byte|byval|call|case|catch|cbool|cbyte|cchar|cdate|cdbl|cdec|char|cint|class|clng|cobj|const|continue|csbyte|cuint|culng|cushort|date|decimal|declare|default|delegate|dim|directcast|do|double|each|else|elseif|end|enum|erase|error|event|exit|false|finally|friend|function|get|gettype|getxmlnamespace|global|goto|handles|if|implements|imports|in|inherits|integer|interface|is|isnot|let|lib|like|long|loop|me|mod|module|mustinherit|mustoverride|mybase|myclass|nameof|namespace|narrowing|new|next|not|nothing|notinheritable|notoverridable|object|of|on|operator|option|optional|or|overrides|paramarray|partial|private|property|protected|public|raiseevent|readonly|redim|removehandler|resume|return|sbyte|select|set|shadows|shared|short|single|static|step|stop|string|structure|sub|synclock|then|throw|to|true|try|trycast|typeof|uinteger|ulong|ushort|using|when|while|widening|with|withevents|writeonly|xor|for|aggregate|ansi|assembly|async|auto|await|binary|compare|custom|distinct|equals|explicit|from|into|isfalse|istrue|iterator|join|key|mid|off|preserve|skip|strict|take|text|unicode|until|where|yield)\b")
        e.ChangedRange.ClearFoldingMarkers()
    End Sub

#End Region

#Region "Autocomplete menu"

    Private Sub BuildCSAutocompleteMenu()
        For Each item As String In CSSnippets
            items.Add(New SnippetAutocompleteItem(item) With {.ImageIndex = 1})
        Next
        For Each item As String In CSdeclarationSnippets
            items.Add(New DeclarationSnippet(item) With {.ImageIndex = 0})
        Next
        'For Each item As String In Methods
        '    items.Add(New MethodAutocompleteItem(item) With {.ImageIndex = 2})
        'Next
        For Each item As String In CSKeyWords
            items.Add(New AutocompleteItem(item) With {.ImageIndex = 3})
        Next
        items.Add(New InsertSpaceSnippet())
        items.Add(New InsertSpaceSnippet("^(\w+)([=<>!:]+)(\w+)$"))
        items.Add(New InsertEnterSnippet())
        popupMenu.Items.SetAutocompleteItems(items)
    End Sub

    Private Sub BuildVBAutocompleteMenu()
        For Each item As String In VBSnippets
            items.Add(New SnippetAutocompleteItem(item) With {.ImageIndex = 1})
        Next
        For Each item As String In VBDecSnippets
            items.Add(New DeclarationSnippet(item) With {.ImageIndex = 0})
        Next
        'For Each item As String In Methods
        '    items.Add(New MethodAutocompleteItem(item) With {.ImageIndex = 2})
        'Next
        For Each item As String In VBKeyWords
            items.Add(New AutocompleteItem(item) With {.ImageIndex = 3})
        Next
        items.Add(New InsertSpaceSnippet())
        items.Add(New InsertSpaceSnippet("^(\w+)([=<>!:]+)(\w+)$"))
        popupMenu.Items.SetAutocompleteItems(items)
    End Sub

#End Region

#Region "Tooltips"

    Private Sub VBToolTip(e As ToolTipNeededEventArgs)
        If e.HoveredWord.ToLower = "AddHandler".ToLower Then
            e.ToolTipTitle = "AddHandler"
            e.ToolTipText = "Associates an event with an event handler at run time."
        End If
        If e.HoveredWord.ToLower = "AddressOf".ToLower Then
            e.ToolTipTitle = "AddressOf"
            e.ToolTipText = "Creates a delegate instance that references the specific procedure."
        End If
        If e.HoveredWord.ToLower = "Alias".ToLower Then
            e.ToolTipTitle = "Alias"
            e.ToolTipText = "Indicates that an external procedure has another name in its DLL."
        End If
        If e.HoveredWord.ToLower = "And".ToLower Then
            e.ToolTipTitle = "And"
            e.ToolTipText = "Performs a logical conjunction on two Boolean expressions, or a bitwise conjunction on two numeric expressions."
        End If
        If e.HoveredWord.ToLower = "AndAlso".ToLower Then
            e.ToolTipTitle = "AndAlso"
            e.ToolTipText = "Performs short-circuiting logical conjunction on two expressions."
        End If
        If e.HoveredWord.ToLower = "As".ToLower Then
            e.ToolTipTitle = "As"
            e.ToolTipText = "Introduces an As clause, which identifies a data type in a declaration statement or a constraint list on a generic type parameter."
        End If
        If e.HoveredWord.ToLower = "Boolean".ToLower Then
            e.ToolTipTitle = "Boolean"
            e.ToolTipText = "Holds values that can be only True or False. The keywords True and False correspond to the two states of Boolean variables."
        End If
        If e.HoveredWord.ToLower = "ByRef".ToLower Then
            e.ToolTipTitle = "ByRef"
            e.ToolTipText = "Specifies that an argument is passed in such a way that the called procedure can change the value of a variable underlying the argument in the calling code."
        End If
        If e.HoveredWord.ToLower = "ByRef".ToLower Then
            e.ToolTipTitle = "ByRef"
            e.ToolTipText = "Specifies that an argument is passed in such a way that the called procedure can change the value of a variable underlying the argument in the calling code."
        End If
        If e.HoveredWord.ToLower = "ByVal".ToLower Then
            e.ToolTipTitle = "ByVal"
            e.ToolTipText = "Specifies that an argument is passed by value, so that the called procedure or property cannot change the value of a variable underlying the argument in the calling code. If no modifier is specified, ByVal is the default."
        End If
        If e.HoveredWord.ToLower = "Call".ToLower Then
            e.ToolTipTitle = "Call"
            e.ToolTipText = "Transfers control to a Function, Sub, or dynamic-link library (DLL) procedure."
        End If
        If e.HoveredWord.ToLower = "Case".ToLower Then
            e.ToolTipTitle = "Case"
            e.ToolTipText = "Runs one of several groups of statements, depending on the value of an expression."
        End If
        If e.HoveredWord.ToLower = "Catch".ToLower Then
            e.ToolTipTitle = "Catch"
            e.ToolTipText = "Provides a way to handle some or all possible errors that may occur in a given block of code, while still running code."
        End If
        If e.HoveredWord.ToLower = "Char".ToLower Then
            e.ToolTipTitle = "Char"
            e.ToolTipText = "Holds unsigned 16-bit (2-byte) code points ranging in value from 0 through 65535. Each code point, or character code, represents a single Unicode character."
        End If
        If e.HoveredWord.ToLower = "Const".ToLower Then
            e.ToolTipTitle = "Const"
            e.ToolTipText = "Declares and defines one or more constants."
        End If
        If e.HoveredWord.ToLower = "Continue".ToLower Then
            e.ToolTipTitle = "Continue"
            e.ToolTipText = "Transfers control immediately to the next iteration of a loop."
        End If
        If e.HoveredWord.ToLower = "Date".ToLower Then
            e.ToolTipTitle = "Date"
            e.ToolTipText = "Holds IEEE 64-bit (8-byte) values that represent dates ranging from January 1 of the year 0001 through December 31 of the year 9999, and times from 12:00:00 AM (midnight) through 11:59:59.9999999 PM. Each increment represents 100 nanoseconds of elapsed time since the beginning of January 1 of the year 1 in the Gregorian calendar. The maximum value represents 100 nanoseconds before the beginning of January 1 of the year 10000."
        End If
        If e.HoveredWord.ToLower = "Decimal".ToLower Then
            e.ToolTipTitle = "Decimal"
            e.ToolTipText = "Holds signed 128-bit (16-byte) values representing 96-bit (12-byte) integer numbers scaled by a variable power of 10. The scaling factor specifies the number of digits to the right of the decimal point; it ranges from 0 through 28. With a scale of 0 (no decimal places), the largest possible value is +/-79,228,162,514,264,337,593,543,950,335 (+/-7.9228162514264337593543950335E+28). With 28 decimal places, the largest value is +/-7.9228162514264337593543950335, and the smallest nonzero value is +/-0.0000000000000000000000000001 (+/-1E-28)."
        End If
        If e.HoveredWord.ToLower = "Declare".ToLower Then
            e.ToolTipTitle = "Declare"
            e.ToolTipText = "Declares a reference to a procedure implemented in an external file."
        End If
        If e.HoveredWord.ToLower = "Default".ToLower Then
            e.ToolTipTitle = "Default"
            e.ToolTipText = "Identifies a property as the default property of its class, structure, or interface."
        End If
        If e.HoveredWord.ToLower = "Delegate".ToLower Then
            e.ToolTipTitle = "Delegate"
            e.ToolTipText = "Used to declare a delegate. A delegate is a reference type that refers to a Shared method of a type or to an instance method of an object. Any procedure with matching parameter and return types can be used to create an instance of this delegate class. The procedure can then later be invoked by means of the delegate instance."
        End If
        If e.HoveredWord.ToLower = "Dim".ToLower Then
            e.ToolTipTitle = "Dim"
            e.ToolTipText = "Declares and allocates storage space for one or more variables."
        End If
        If e.HoveredWord.ToLower = "DirectCast".ToLower Then
            e.ToolTipTitle = "DirectCast"
            e.ToolTipText = "Introduces a type conversion operation based on inheritance or implementation."
        End If
        If e.HoveredWord.ToLower = "Do".ToLower Then
            e.ToolTipTitle = "Do"
            e.ToolTipText = "Repeats a block of statements while a Boolean condition is True or until the condition becomes True."
        End If
        If e.HoveredWord.ToLower = "Double".ToLower Then
            e.ToolTipTitle = "Double"
            e.ToolTipText = "Holds signed IEEE 64-bit (8-byte) double-precision floating-point numbers that range in value from -1.79769313486231570E+308 through -4.94065645841246544E-324 for negative values and from 4.94065645841246544E-324 through 1.79769313486231570E+308 for positive values. Double-precision numbers store an approximation of a real number."
        End If
        If e.HoveredWord.ToLower = "Each".ToLower Then
            e.ToolTipTitle = "Each"
            e.ToolTipText = "Repeats a group of statements for each element in a collection."
        End If
        If e.HoveredWord.ToLower = "Else".ToLower Then
            e.ToolTipTitle = "Else"
            e.ToolTipText = "Introduces a group of statements to be run or compiled if no other conditional group of statements has been run or compiled."
        End If
        If e.HoveredWord.ToLower = "ElseIf".ToLower Then
            e.ToolTipTitle = "ElseIf"
            e.ToolTipText = "Conditionally executes a group of statements, depending on the value of an expression."
        End If
        If e.HoveredWord.ToLower = "Enum".ToLower Then
            e.ToolTipTitle = "Enum"
            e.ToolTipText = "Declares an enumeration and defines the values of its members."
        End If
        If e.HoveredWord.ToLower = "Erase".ToLower Then
            e.ToolTipTitle = "Erase"
            e.ToolTipText = "Used to release array variables and deallocate the memory used for their elements."
        End If
        If e.HoveredWord.ToLower = "Error".ToLower Then
            e.ToolTipTitle = "Error"
            e.ToolTipText = "Enables an error-handling routine and specifies the location of the routine within a procedure; can also be used to disable an error-handling routine. The On Error statement is used in unstructured error handling and can be used instead of structured exception handling. Structured exception handling is built into .NET, is generally more efficient, and so is recommended when handling runtime errors in your application."
        End If
        If e.HoveredWord.ToLower = "Event".ToLower Then
            e.ToolTipTitle = "Event"
            e.ToolTipText = "Declares a user-defined event."
        End If
        If e.HoveredWord.ToLower = "Exit".ToLower Then
            e.ToolTipTitle = "Exit"
            e.ToolTipText = "Exits a procedure or block and transfers control immediately to the statement following the procedure call or the block definition."
        End If
        If e.HoveredWord.ToLower = "Friend".ToLower Then
            e.ToolTipTitle = "Friend"
            e.ToolTipText = "Specifies that one or more declared programming elements are accessible only from within the assembly that contains their declaration."
        End If
        If e.HoveredWord.ToLower = "Function".ToLower Then
            e.ToolTipTitle = "Function"
            e.ToolTipText = "Declares the name, parameters, and code that define a Function procedure."
        End If
        If e.HoveredWord.ToLower = "Get".ToLower Then
            e.ToolTipTitle = "Get"
            e.ToolTipText = "Declares a Get property procedure used to retrieve the value of a property."
        End If
        If e.HoveredWord.ToLower = "GetType".ToLower Then
            e.ToolTipTitle = "GetType"
            e.ToolTipText = "Returns a Type object for the specified type. The Type object provides information about the type such as its properties, methods, and events."
        End If
        If e.HoveredWord.ToLower = "GetXMLNamespace".ToLower Then
            e.ToolTipTitle = "GetXMLNamespace"
            e.ToolTipText = "Gets the XNamespace object that corresponds to the specified XML namespace prefix."
        End If
        If e.HoveredWord.ToLower = "GoTo".ToLower Then
            e.ToolTipTitle = "GoTo"
            e.ToolTipText = "Branches unconditionally to a specified line in a procedure."
        End If
        If e.HoveredWord.ToLower = "Handles".ToLower Then
            e.ToolTipTitle = "Handles"
            e.ToolTipText = "Declares that a procedure handles a specified event."
        End If
        If e.HoveredWord.ToLower = "If".ToLower Then
            e.ToolTipTitle = "If"
            e.ToolTipText = "Conditionally executes a group of statements, depending on the value of an expression."
        End If
        If e.HoveredWord.ToLower = "Implements".ToLower Then
            e.ToolTipTitle = "Implements"
            e.ToolTipText = "Indicates that a class or structure member is providing the implementation for a member defined in an interface."
        End If
        If e.HoveredWord.ToLower = "Imports.ToLower" Then
            e.ToolTipTitle = "Imports"
            e.ToolTipText = $".NET: Enables type names to be referenced without namespace qualification.{vbLf}XML: Imports XML namespace prefixes for use in XML literals and XML axis properties."
        End If
        If e.HoveredWord.ToLower = "In".ToLower Then
            e.ToolTipTitle = "In"
            e.ToolTipText = "Specifies the group that the loop variable is to traverse in a For Each loop, or specifies the collection to query in a From, Join, or Group Join clause."
        End If
        If e.HoveredWord.ToLower = "Inherits".ToLower Then
            e.ToolTipTitle = "Inherits"
            e.ToolTipText = "Causes the current class or interface to inherit the attributes, variables, properties, procedures, and events from another class or set of interfaces."
        End If
        If e.HoveredWord.ToLower = "Integer".ToLower Then
            e.ToolTipTitle = "Integer"
            e.ToolTipText = "Holds signed 32-bit (4-byte) integers that range in value from -2,147,483,648 through 2,147,483,647."
        End If
        If e.HoveredWord.ToLower = "Interface".ToLower Then
            e.ToolTipTitle = "Interface"
            e.ToolTipText = "Declares the name of an interface and introduces the definitions of the members that the interface comprises."
        End If
        If e.HoveredWord.ToLower = "Is".ToLower Then
            e.ToolTipTitle = "Is"
            e.ToolTipText = "Compares two object reference variables."
        End If
        If e.HoveredWord.ToLower = "IsNot".ToLower Then
            e.ToolTipTitle = "IsNot"
            e.ToolTipText = "Compares two object reference variables."
        End If
        If e.HoveredWord.ToLower = "Let".ToLower Then
            e.ToolTipTitle = "Let"
            e.ToolTipText = "Computes a value and assigns it to a new variable within the query."
        End If
        If e.HoveredWord.ToLower = "Like".ToLower Then
            e.ToolTipTitle = "Like"
            e.ToolTipText = "Compares a string against a pattern."
        End If
        If e.HoveredWord.ToLower = "Lib".ToLower Then
            e.ToolTipTitle = "Lib"
            e.ToolTipText = "Declares a reference to a procedure implemented in an external file."
        End If
        If e.HoveredWord.ToLower = "Long".ToLower Then
            e.ToolTipTitle = "Long"
            e.ToolTipText = "Holds signed 64-bit (8-byte) integers ranging in value from -9,223,372,036,854,775,808 through 9,223,372,036,854,775,807 (9.2...E+18)."
        End If
        If e.HoveredWord.ToLower = "Loop".ToLower Then
            e.ToolTipTitle = "Loop"
            e.ToolTipText = "Repeats a block of statements while a Boolean condition is True or until the condition becomes True."
        End If
        If e.HoveredWord.ToLower = "Mod".ToLower Then
            e.ToolTipTitle = "Mod"
            e.ToolTipText = "Divides two numbers and returns only the remainder."
        End If
        If e.HoveredWord.ToLower = "Module".ToLower Then
            e.ToolTipTitle = "Module"
            e.ToolTipText = "Declares the name of a module and introduces the definition of the variables, properties, events, and procedures that the module comprises."
        End If
        If e.HoveredWord.ToLower = "MustInherit".ToLower Then
            e.ToolTipTitle = "MustInherit"
            e.ToolTipText = "Specifies that a class can be used only as a base class and that you cannot create an object directly from it."
        End If
        If e.HoveredWord.ToLower = "MustOverride".ToLower Then
            e.ToolTipTitle = "MustOverride"
            e.ToolTipText = "Specifies that a property or procedure is not implemented in this class and must be overridden in a derived class before it can be used."
        End If
        If e.HoveredWord.ToLower = "Namespace".ToLower Then
            e.ToolTipTitle = "Namespace"
            e.ToolTipText = "Declares the name of a namespace and causes the source code that follows the declaration to be compiled within that namespace."
        End If
        If e.HoveredWord.ToLower = "Narrowing".ToLower Then
            e.ToolTipTitle = "Narrowing"
            e.ToolTipText = "Indicates that a conversion operator (CType) converts a class or structure to a type that might not be able to hold some of the possible values of the original class or structure."
        End If
        If e.HoveredWord.ToLower = "Next".ToLower Then
            e.ToolTipTitle = "Next"
            e.ToolTipText = "Repeats a group of statements a specified number of times."
        End If
        If e.HoveredWord.ToLower = "Not".ToLower Then
            e.ToolTipTitle = "Not"
            e.ToolTipText = "Performs logical negation on a Boolean expression, or bitwise negation on a numeric expression."
        End If
        If e.HoveredWord.ToLower = "Nothing".ToLower Then
            e.ToolTipTitle = "Nothing"
            e.ToolTipText = "Represents the default value of any data type. For reference types, the default value is the null reference. For value types, the default value depends on whether the value type is nullable."
        End If
        If e.HoveredWord.ToLower = "NotInheritable".ToLower Then
            e.ToolTipTitle = "NotInheritable"
            e.ToolTipText = "Specifies that a class cannot be used as a base class."
        End If
        If e.HoveredWord.ToLower = "NotOverridable".ToLower Then
            e.ToolTipTitle = "NotOverridable"
            e.ToolTipText = "Specifies that a property or procedure cannot be overridden in a derived class."
        End If
        If e.HoveredWord.ToLower = "Object".ToLower Then
            e.ToolTipTitle = "Object"
            e.ToolTipText = "Holds addresses that refer to objects. You can assign any reference type (string, array, class, or interface) to an Object variable. An Object variable can also refer to data of any value type (numeric, Boolean, Char, Date, structure, or enumeration)."
        End If
        If e.HoveredWord.ToLower = "Of".ToLower Then
            e.ToolTipTitle = "Of"
            e.ToolTipText = "Introduces an Of clause, which identifies a type parameter on a generic class, structure, interface, delegate, or procedure. For information on generic types."
        End If
        If e.HoveredWord.ToLower = "On".ToLower Then
            e.ToolTipTitle = "On"
            e.ToolTipText = "Introduces a response to a run-time error or turns a compiler option on."
        End If
        If e.HoveredWord.ToLower = "Operator".ToLower Then
            e.ToolTipTitle = "Operator"
            e.ToolTipText = "Declares the operator symbol, operands, and code that define an operator procedure on a class or structure."
        End If
        If e.HoveredWord.ToLower = "Option".ToLower Then
            e.ToolTipTitle = "Option"
            e.ToolTipText = "Introduces a statement that specifies a compiler option that applies to the entire source file."
        End If
        If e.HoveredWord.ToLower = "Optional".ToLower Then
            e.ToolTipTitle = "Optional"
            e.ToolTipText = "Specifies that a procedure argument can be omitted when the procedure is called."
        End If
        If e.HoveredWord.ToLower = "Or".ToLower Then
            e.ToolTipTitle = "Or"
            e.ToolTipText = "Performs a logical disjunction on two Boolean expressions, or a bitwise disjunction on two numeric expressions."
        End If
        If e.HoveredWord.ToLower = "OrElse".ToLower Then
            e.ToolTipTitle = "OrElse"
            e.ToolTipText = "Performs short-circuiting inclusive logical disjunction on two expressions."
        End If
        If e.HoveredWord.ToLower = "Out".ToLower Then
            e.ToolTipTitle = "Out"
            e.ToolTipText = "For generic type parameters, the Out keyword specifies that the type is covariant."
        End If
        If e.HoveredWord.ToLower = "Overloads".ToLower Then
            e.ToolTipTitle = "Overloads"
            e.ToolTipText = "Specifies that a property or procedure redeclares one or more existing properties or procedures with the same name."
        End If
        If e.HoveredWord.ToLower = "Overridable".ToLower Then
            e.ToolTipTitle = "Overridable"
            e.ToolTipText = "Specifies that a property or procedure can be overridden by an identically named property or procedure in a derived class."
        End If
        If e.HoveredWord.ToLower = "Overrides".ToLower Then
            e.ToolTipTitle = "Overrides"
            e.ToolTipText = "Specifies that a property or procedure overrides an identically named property or procedure inherited from a base class."
        End If
        If e.HoveredWord.ToLower = "ParamArray".ToLower Then
            e.ToolTipTitle = "ParamArray"
            e.ToolTipText = "Specifies that a procedure parameter takes an optional array of elements of the specified type. ParamArray can be used only on the last parameter of a parameter list."
        End If
        If e.HoveredWord.ToLower = "Partial".ToLower Then
            e.ToolTipTitle = "Partial"
            e.ToolTipText = "Indicates that a type declaration is a partial definition of the type."
        End If
        If e.HoveredWord.ToLower = "Private".ToLower Then
            e.ToolTipTitle = "Private"
            e.ToolTipText = "Specifies that one or more declared programming elements are accessible only from within their declaration context, including from within any contained types."
        End If
        If e.HoveredWord.ToLower = "Property".ToLower Then
            e.ToolTipTitle = "Property"
            e.ToolTipText = "Declares the name of a property, and the property procedures used to store and retrieve the value of the property."
        End If
        If e.HoveredWord.ToLower = "Protected".ToLower Then
            e.ToolTipTitle = "Protected"
            e.ToolTipText = "A member access modifier that specifies that one or more declared programming elements are accessible only from within their own class or from a derived class."
        End If
        If e.HoveredWord.ToLower = "Public".ToLower Then
            e.ToolTipTitle = "Public"
            e.ToolTipText = "Specifies that one or more declared programming elements have no access restrictions."
        End If
        If e.HoveredWord.ToLower = "RaiseEvent".ToLower Then
            e.ToolTipTitle = "RaiseEvent"
            e.ToolTipText = "Triggers an event declared at module level within a class, form, or document."
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub txtEditor_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtEditor.TextChanged
        e.ChangedRange.ClearStyle(HyperLinkStyle)
        e.ChangedRange.SetStyle(HyperLinkStyle, "(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?")
        If Language = Language.CSharp Then
            CSharpSyntaxHighlight(e)
        ElseIf Language = Language.VB Then
            VBSyntaxHighlight(e)
        End If
        Title = IO.Path.GetFileName(FilePath) & " *"
        'Dim strLine As String = txtEditor.Lines.ElementAt(e.ChangedRange.ToLine)
        'items.Clear()
        'If Language = Language.CSharp Then
        '    BuildCSAutocompleteMenu()
        'Else
        '    BuildVBAutocompleteMenu()
        'End If
        'If strLine.Count > 0 AndAlso strLine.Last = "." Then
        '    Dim strType As String = strLine.Substring(0, strLine.LastIndexOf("."))
        '    Dim objType As Type = Type.GetType(strType)
        '    If objType IsNot Nothing Then
        '        objType.GetProperties().ToList.ForEach(Sub(x)
        '                                                   items.Add(New MethodAutocompleteItem(x.Name) With {.ImageIndex = 4})
        '                                               End Sub)
        '        objType.GetMethods().ToList.ForEach(Sub(x)
        '                                                items.Add(New MethodAutocompleteItem(x.Name) With {.ImageIndex = 2})
        '                                            End Sub)
        '        objType.GetNestedTypes.ToList.ForEach(Sub(x)
        '                                                  items.Add(New MethodAutocompleteItem(x.Name) With {.ImageIndex = 5})
        '                                              End Sub)
        '        objType.GetFields.ToList.ForEach(Sub(x)
        '                                             items.Add(New MethodAutocompleteItem(x.Name) With {.ImageIndex = 4})
        '                                         End Sub)
        '    Else
        '        Dim lAssemblies As New List(Of Reflection.Assembly)
        '        Dim objDoc As XDocument = XDocument.Load(strRoot)
        '        Dim objRoot As XElement = objDoc.Element("Project")
        '        Dim objReferences As XElement = objRoot.Element("References")
        '        objReferences.Elements("Reference").ToList.ForEach(Sub(x)
        '                                                               lAssemblies.Add(Reflection.Assembly.LoadFrom(x.Value))
        '                                                           End Sub)
        '        For Each objAssembly As Reflection.Assembly In lAssemblies
        '            Dim objAssemblyType As Type = objAssembly.GetType(strType)
        '            If objAssemblyType IsNot Nothing Then
        '                objAssemblyType.GetProperties().ToList.ForEach(Sub(x)
        '                                                                   items.Add(New MethodAutocompleteItem(x.Name) With {.ImageIndex = 4})
        '                                                               End Sub)
        '                objAssemblyType.GetMethods().ToList.ForEach(Sub(x)
        '                                                                items.Add(New MethodAutocompleteItem(x.Name) With {.ImageIndex = 2})
        '                                                            End Sub)
        '                objAssemblyType.GetNestedTypes.ToList.ForEach(Sub(x)
        '                                                                  items.Add(New MethodAutocompleteItem(x.Name) With {.ImageIndex = 5})
        '                                                              End Sub)
        '                objAssemblyType.GetFields.ToList.ForEach(Sub(x)
        '                                                             items.Add(New MethodAutocompleteItem(x.Name) With {.ImageIndex = 4})
        '                                                         End Sub)
        '                Exit For
        '            End If
        '        Next
        '    End If
        'popupMenu.Items.SetAutocompleteItems(items)
        'End If
    End Sub

    Private Sub txtEditor_ToolTipNeeded(sender As Object, e As ToolTipNeededEventArgs) Handles txtEditor.ToolTipNeeded
        If Not String.IsNullOrEmpty(e.HoveredWord) Then
            If Language = Language.CSharp Then

            Else
                VBToolTip(e)
            End If
        End If
    End Sub

    Private Sub popupMenu_Opening(sender As Object, e As CancelEventArgs) Handles popupMenu.Opening
        Dim iGreenStyle = txtEditor.GetStyleIndex(GreenStyle)
        If iGreenStyle >= 0 Then

            If txtEditor.Selection.Start.iChar > 0 Then
                Dim c As [Char] = txtEditor(txtEditor.Selection.Start.iLine)(txtEditor.Selection.Start.iChar - 1)
                Dim greenStyleIndex = Range.ToStyleIndex(iGreenStyle)
                If (c.style And greenStyleIndex) <> 0 Then e.Cancel = True
            End If
        End If
        Dim iRegStyle = txtEditor.GetStyleIndex(BrownStyle)
        If iRegStyle >= 0 Then

            If txtEditor.Selection.Start.iChar > 0 Then
                Dim c As [Char] = txtEditor(txtEditor.Selection.Start.iLine)(txtEditor.Selection.Start.iChar - 1)
                Dim regStyleIndex = Range.ToStyleIndex(iRegStyle)
                If (c.style And regStyleIndex) <> 0 Then e.Cancel = True
            End If
        End If
    End Sub

    Private Function CharIsHyperlink(ByVal place As Place) As Boolean
        Dim mask = txtEditor.GetStyleIndexMask(New Style() {HyperLinkStyle})

        If place.iChar < txtEditor.GetLineLength(place.iLine) Then
            If (txtEditor(place).style And mask) <> 0 Then Return True
        End If

        Return False
    End Function

    Private Sub txtEditor_MouseMove(sender As Object, e As MouseEventArgs) Handles txtEditor.MouseMove
        Dim p = txtEditor.PointToPlace(e.Location)

        If CharIsHyperlink(p) Then
            txtEditor.Cursor = Cursors.Hand
        Else
            txtEditor.Cursor = Cursors.IBeam
        End If
    End Sub

    Private Sub txtEditor_MousDoubleClick(sender As Object, e As MouseEventArgs) Handles txtEditor.MouseDoubleClick
        Dim p = txtEditor.PointToPlace(e.Location)

        If e.Button = MouseButtons.Left Then
            If CharIsHyperlink(p) Then
                Dim url = txtEditor.GetRange(p, p).GetFragment("[\S]").Text
                Process.Start(url)
            End If
        End If
    End Sub

#End Region

End Class