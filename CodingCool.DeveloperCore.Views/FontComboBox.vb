Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Windows.Forms

''' <summary>
''' A font combo box control.
''' </summary>
Public Class FontComboBox
    Inherits ComboBox

    Private _fontCache As Dictionary(Of String, Font)
    Private _itemHeight As Integer
    Private _previewFontSize As Integer
    Private _stringFormat As StringFormat

    Public Sub New()
        _fontCache = New Dictionary(Of String, Font)
        DrawMode = DrawMode.OwnerDrawVariable
        Sorted = True
        PreviewFontSize = 12
        DropDownStyle = ComboBoxStyle.DropDownList
        CalculateLayout()
        CreateStringFormat()
    End Sub

    Public Event PreviewFontSizeChanged As EventHandler

    Protected Overrides Sub Dispose(disposing As Boolean)
        ClearFontCache()
        If _stringFormat IsNot Nothing Then _stringFormat.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        MyBase.OnDrawItem(e)

        If e.Index > -1 AndAlso e.Index < Items.Count Then
            e.DrawBackground()
            If (e.State And DrawItemState.Focus) = DrawItemState.Focus Then e.DrawFocusRectangle()

            Using textBrush As SolidBrush = New SolidBrush(e.ForeColor)
                Dim fontFamilyName As String
                fontFamilyName = Items(e.Index).ToString()
                e.Graphics.DrawString(fontFamilyName, GetFont(fontFamilyName), textBrush, e.Bounds, _stringFormat)
            End Using
        End If
    End Sub

    Protected Overrides Sub OnFontChanged(e As EventArgs)
        MyBase.OnFontChanged(e)
        CalculateLayout()
    End Sub

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        LoadFontFamilies()
        MyBase.OnGotFocus(e)
    End Sub

    Protected Overrides Sub OnMeasureItem(e As MeasureItemEventArgs)
        MyBase.OnMeasureItem(e)

        If e.Index > -1 AndAlso e.Index < Items.Count Then
            e.ItemHeight = _itemHeight
        End If
    End Sub

    Protected Overrides Sub OnRightToLeftChanged(e As EventArgs)
        MyBase.OnRightToLeftChanged(e)
        CreateStringFormat()
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)

        If Items.Count = 0 Then
            Dim selectedIndex As Integer
            LoadFontFamilies()
            selectedIndex = FindStringExact(Text)
            If selectedIndex <> -1 Then Me.SelectedIndex = selectedIndex
        End If
    End Sub

    Public Overridable Sub LoadFontFamilies()
        If Items.Count = 0 Then
            Cursor.Current = Cursors.WaitCursor

            For Each fontFamily As FontFamily In FontFamily.Families
                Items.Add(fontFamily.Name)
            Next

            Cursor.Current = Cursors.Default
        End If
    End Sub

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Overloads Property DrawMode As DrawMode
        Get
            Return MyBase.DrawMode
        End Get
        Set(value As DrawMode)
            MyBase.DrawMode = value
        End Set
    End Property

    <Category("Appearance")>
    <DefaultValue(12)>
    Public Property PreviewFontSize As Integer
        Get
            Return _previewFontSize
        End Get
        Set(value As Integer)
            _previewFontSize = value
            OnPreviewFontSizeChanged(EventArgs.Empty)
        End Set
    End Property

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Overloads Property Sorted As Boolean
        Get
            Return MyBase.Sorted
        End Get
        Set(value As Boolean)
            MyBase.Sorted = value
        End Set
    End Property

    Private Sub CalculateLayout()
        ClearFontCache()

        Using font As Font = New Font(Me.Font.FontFamily, PreviewFontSize)
            Dim textSize As Size
            textSize = TextRenderer.MeasureText("yY", font)
            _itemHeight = textSize.Height + 2
        End Using
    End Sub

    Private Function IsUsingRTL(control As Control) As Boolean
        Dim result As Boolean

        If control.RightToLeft = RightToLeft.Yes Then
            result = True
        ElseIf control.RightToLeft = RightToLeft.Inherit AndAlso control.Parent IsNot Nothing Then
            result = IsUsingRTL(control.Parent)
        Else
            result = False
        End If

        Return result
    End Function

    Protected Overridable Sub ClearFontCache()
        If _fontCache IsNot Nothing Then

            For Each key As String In _fontCache.Keys
                _fontCache(key).Dispose()
            Next

            _fontCache.Clear()
        End If
    End Sub

    Protected Overridable Sub CreateStringFormat()
        If _stringFormat IsNot Nothing Then _stringFormat.Dispose()
        _stringFormat = New StringFormat(StringFormatFlags.NoWrap) With {
            .Trimming = StringTrimming.EllipsisCharacter,
            .HotkeyPrefix = HotkeyPrefix.None,
            .Alignment = StringAlignment.Near,
            .LineAlignment = StringAlignment.Center
        }
        If IsUsingRTL(Me) Then _stringFormat.FormatFlags = _stringFormat.FormatFlags Or StringFormatFlags.DirectionRightToLeft
    End Sub

    Protected Overridable Function GetFont(fontFamilyName As String) As Font
        SyncLock _fontCache

            If Not _fontCache.ContainsKey(fontFamilyName) Then
                Dim font As Font
                font = GetFont(fontFamilyName, FontStyle.Regular)
                If font Is Nothing Then font = GetFont(fontFamilyName, FontStyle.Bold)
                If font Is Nothing Then font = GetFont(fontFamilyName, FontStyle.Italic)
                If font Is Nothing Then font = GetFont(fontFamilyName, FontStyle.Bold Or FontStyle.Italic)
                If font Is Nothing Then font = CType(Me.Font.Clone(), Font)
                _fontCache.Add(fontFamilyName, font)
            End If
        End SyncLock

        Return _fontCache(fontFamilyName)
    End Function

    Protected Overridable Function GetFont(fontFamilyName As String, fontStyle As FontStyle) As Font
        Dim font As Font

        Try
            font = New Font(fontFamilyName, PreviewFontSize, fontStyle)
        Catch
            font = Nothing
        End Try

        Return font
    End Function

    Protected Overridable Sub OnPreviewFontSizeChanged(e As EventArgs)
        RaiseEvent PreviewFontSizeChanged(Me, e)
        CalculateLayout()
    End Sub

End Class