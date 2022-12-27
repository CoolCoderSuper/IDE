Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.CSharp
Imports Microsoft.CodeAnalysis.CSharp.Syntax

'TODO: Finish C# loader
Public Class CsLoader
    Implements ILoader

    Public Function Load(code As String) As List(Of StructureItem) Implements ILoader.Load
        Dim tree As CSharpSyntaxTree = SyntaxFactory.ParseSyntaxTree(code)
        Dim root As CSharpSyntaxNode = tree.GetRoot
        Dim list As New List(Of StructureItem)
        Dim i As Integer = 1
        WalkTree(root.ChildNodes, Nothing, i, list)
        Return list
    End Function

    Private Sub WalkTree(nodes As IEnumerable(Of SyntaxNode), parentId As Integer, ByRef i As Integer, ByRef list As List(Of StructureItem))
        For Each n As CSharpSyntaxNode In nodes
            Dim objItem As New StructureItem
            If TypeOf n Is ClassDeclarationSyntax Then
                objItem.Id = i
                objItem.Title = DirectCast(n, ClassDeclarationSyntax).Identifier.ValueText
                objItem.Type = StructureType.Class
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                i += 1
                WalkTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is InterfaceDeclarationSyntax Then
                Dim nI As InterfaceDeclarationSyntax = n
                objItem.Id = i
                objItem.Title = nI.Identifier.ValueText
                objItem.Type = StructureType.Interface
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                i += 1
                WalkTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is StructDeclarationSyntax Then
                Dim nS As StructDeclarationSyntax = n
                objItem.Id = i
                objItem.Title = nS.Identifier.ValueText
                objItem.Type = StructureType.Structure
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                i += 1
                WalkTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is EnumDeclarationSyntax Then
                Dim nE As EnumDeclarationSyntax = n
                Dim eParent As Integer = i
                objItem.Id = i
                objItem.Title = nE.Identifier.ValueText
                objItem.Type = StructureType.Enum
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                objItem = New StructureItem
                i += 1
                For Each e As EnumMemberDeclarationSyntax In nE.Members.OfType(Of EnumMemberDeclarationSyntax)
                    objItem.Id = i
                    objItem.Title = e.Identifier.ValueText
                    objItem.Type = StructureType.Enum
                    objItem.ParentId = eParent
                    list.Add(objItem)
                    objItem.Position = n.SpanStart
                    objItem = New StructureItem
                    i += 1
                Next
            ElseIf TypeOf n Is NamespaceDeclarationSyntax Then
                Dim nN As NamespaceDeclarationSyntax = n
                objItem.Id = i
                objItem.Title = nN.Name.ToString
                objItem.Type = StructureType.Namespace
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                i += 1
                WalkTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is MethodDeclarationSyntax Then
                Dim nM As MethodDeclarationSyntax = n
                objItem.Id = i
                objItem.Title = $"{nM.ReturnType} {nM.Identifier.ValueText}{FormatParameters(nM.ParameterList)}"
                objItem.Type = StructureType.Method
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                i += 1
                list.Add(objItem)
            ElseIf TypeOf n Is ConstructorDeclarationSyntax Then
                Dim nM As ConstructorDeclarationSyntax = n
                objItem.Id = i
                objItem.Title = $"New{FormatParameters(nM.ParameterList)}"
                objItem.Type = StructureType.Method
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                i += 1
                list.Add(objItem)
            ElseIf TypeOf n Is PropertyDeclarationSyntax Then
                Dim nP As PropertyDeclarationSyntax = n
                objItem.Id = i
                objItem.Title = $"{nP.Type} {nP.Identifier.ValueText}"
                objItem.Type = StructureType.Property
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                i += 1
                list.Add(objItem)
                'ElseIf TypeOf n Is EventStatementSyntax Then
                '    Dim nE As EventStatementSyntax = n
                '    objItem.Id = i
                '    objItem.Title = $"{nE.Identifier.ValueText}{FormatParameters(nE.ParameterList)}"
                '    If nE.AsClause IsNot Nothing Then objItem.Title &= $" As {nE.AsClause.Type}"
                '    objItem.Type = StructureType.Event
                '    objItem.ParentId = parentId
                '    objItem.Position = n.SpanStart
                '    list.Add(objItem)
                'ElseIf TypeOf n Is OperatorStatementSyntax Then
                '    Dim nO As OperatorStatementSyntax = n
                '    objItem.Id = i
                '    objItem.Title = $"{nO.OperatorToken.ValueText}{FormatParameters(nO.ParameterList)}"
                '    If nO.AsClause IsNot Nothing Then objItem.Title &= $" As {nO.AsClause.Type}"
                '    objItem.Type = StructureType.Operator
                '    objItem.ParentId = parentId
                '    objItem.Position = n.SpanStart
                '    list.Add(objItem)
                'ElseIf TypeOf n Is FieldDeclarationSyntax Then
                '    Dim nF As FieldDeclarationSyntax = n
                '    For Each dec As VariableDeclaratorSyntax In nF.Declarators
                '        objItem.Id = i
                '        objItem.Title = dec.Names.First.ToString
                '        If dec.AsClause IsNot Nothing Then objItem.Title &= $" As {dec.AsClause.Type}"
                '        objItem.Type = StructureType.Variable
                '        objItem.ParentId = parentId
                '        objItem.Position = n.SpanStart
                '        list.Add(objItem)
                '        objItem = New StructureItem
                '        i += 1
                '    Next
            End If
        Next
    End Sub

    Private Function FormatParameters(params As ParameterListSyntax) As String
        If params Is Nothing Then Return String.Empty
        Dim strResult As String = "("
        If params.Parameters.Any Then
            For Each p As ParameterSyntax In params.Parameters
                strResult &= $"{p.Type} {p.Identifier.ValueText}, "
            Next
            strResult = strResult.Remove(strResult.Length - 2)
        End If
        strResult &= ")"
        Return strResult
    End Function

End Class