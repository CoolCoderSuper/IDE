Imports CodingCool.DeveloperCore.Core
Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.VisualBasic
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

Public Class VbLoader
    Implements ILoader

    Public Function Load(code As String) As List(Of StructureItem) Implements ILoader.Load
        Dim tree As VisualBasicSyntaxTree = SyntaxFactory.ParseSyntaxTree(code)
        Dim root As VisualBasicSyntaxNode = tree.GetRoot()
        Dim list As New List(Of StructureItem)
        Dim i As Integer = 1
        WalkTree(root.ChildNodes(), Nothing, i, list)
        Return list
    End Function

    Private Sub WalkTree(nodes As IEnumerable(Of SyntaxNode), parentId As Integer, ByRef i As Integer, ByRef list As List(Of StructureItem))
        For Each n As VisualBasicSyntaxNode In nodes
            Dim objItem As New StructureItem
            If TypeOf n Is ClassBlockSyntax Then
                Dim nC As ClassBlockSyntax = n
                objItem.Id = i
                objItem.Title = nC.ClassStatement.Identifier.ValueText
                objItem.Type = StructureType.Class
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                WalkTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is InterfaceBlockSyntax Then
                Dim nI As InterfaceBlockSyntax = n
                objItem.Id = i
                objItem.Title = nI.InterfaceStatement.Identifier.ValueText
                objItem.Type = StructureType.Interface
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                WalkTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is StructureBlockSyntax Then
                Dim nS As StructureBlockSyntax = n
                objItem.Id = i
                objItem.Title = nS.StructureStatement.Identifier.ValueText
                objItem.Type = StructureType.Structure
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                WalkTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is EnumBlockSyntax Then
                Dim nE As EnumBlockSyntax = n
                Dim eParent As Integer = i
                objItem.Id = i
                objItem.Title = nE.EnumStatement.Identifier.ValueText
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
            ElseIf TypeOf n Is NamespaceBlockSyntax Then
                Dim nN As NamespaceBlockSyntax = n
                objItem.Id = i
                objItem.Title = nN.NamespaceStatement.Name.ToFullString
                objItem.Type = StructureType.Namespace
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                WalkTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is RegionDirectiveTriviaSyntax Then
                Dim nR As RegionDirectiveTriviaSyntax = n
                objItem.Id = i
                objItem.Title = nR.Name.ValueText
                objItem.Type = StructureType.Region
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
                WalkTree(n.ChildNodes, objItem.Id, i, list)
            ElseIf TypeOf n Is MethodBlockSyntax Then
                Dim nM As MethodStatementSyntax = CType(n, MethodBlockSyntax).SubOrFunctionStatement
                objItem.Id = i
                objItem.Title = $"{nM.Identifier.ValueText}{FormatParameters(nM.ParameterList)}"
                If nM.AsClause IsNot Nothing Then objItem.Title &= $" As {nM.AsClause.Type}"
                objItem.Type = StructureType.Method
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is MethodStatementSyntax Then
                Dim nM As MethodStatementSyntax = n
                objItem.Id = i
                objItem.Title = $"{nM.Identifier.ValueText}{FormatParameters(nM.ParameterList)}"
                If nM.AsClause IsNot Nothing Then objItem.Title &= $" As {nM.AsClause.Type}"
                objItem.Type = StructureType.Method
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is ConstructorBlockSyntax Then
                Dim nM As SubNewStatementSyntax = CType(n, ConstructorBlockSyntax).SubNewStatement
                objItem.Id = i
                objItem.Title = $"New{FormatParameters(nM.ParameterList)}"
                objItem.Type = StructureType.Method
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is PropertyBlockSyntax Then
                Dim nP As PropertyStatementSyntax = CType(n, PropertyBlockSyntax).PropertyStatement
                objItem.Id = i
                objItem.Title = $"{nP.Identifier.ValueText}{FormatParameters(nP.ParameterList)}"
                If nP.AsClause IsNot Nothing Then objItem.Title &= $" As {nP.AsClause.Type}"
                objItem.Type = StructureType.Property
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is PropertyStatementSyntax Then
                Dim nP As PropertyStatementSyntax = n
                objItem.Id = i
                objItem.Title = $"{nP.Identifier.ValueText}{FormatParameters(nP.ParameterList)}"
                If nP.AsClause IsNot Nothing Then objItem.Title &= $" As {nP.AsClause.Type}"
                objItem.Type = StructureType.Property
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is EventBlockSyntax Then
                Dim nE As EventStatementSyntax = CType(n, EventBlockSyntax).EventStatement
                objItem.Id = i
                objItem.Title = $"{nE.Identifier.ValueText}{FormatParameters(nE.ParameterList)}"
                If nE.AsClause IsNot Nothing Then objItem.Title &= $" As {nE.AsClause.Type}"
                objItem.Type = StructureType.Event
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is EventStatementSyntax Then
                Dim nE As EventStatementSyntax = n
                objItem.Id = i
                objItem.Title = $"{nE.Identifier.ValueText}{FormatParameters(nE.ParameterList)}"
                If nE.AsClause IsNot Nothing Then objItem.Title &= $" As {nE.AsClause.Type}"
                objItem.Type = StructureType.Event
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is OperatorBlockSyntax Then
                Dim nO As OperatorStatementSyntax = CType(n, OperatorBlockSyntax).OperatorStatement
                objItem.Id = i
                objItem.Title = $"{nO.OperatorToken.ValueText}{FormatParameters(nO.ParameterList)}"
                If nO.AsClause IsNot Nothing Then objItem.Title &= $" As {nO.AsClause.Type}"
                objItem.Type = StructureType.Operator
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is OperatorStatementSyntax Then
                Dim nO As OperatorStatementSyntax = n
                objItem.Id = i
                objItem.Title = $"{nO.OperatorToken.ValueText}{FormatParameters(nO.ParameterList)}"
                If nO.AsClause IsNot Nothing Then objItem.Title &= $" As {nO.AsClause.Type}"
                objItem.Type = StructureType.Operator
                objItem.ParentId = parentId
                objItem.Position = n.SpanStart
                list.Add(objItem)
            ElseIf TypeOf n Is FieldDeclarationSyntax Then
                Dim nF As FieldDeclarationSyntax = n
                For Each dec As VariableDeclaratorSyntax In nF.Declarators
                    objItem.Id = i
                    objItem.Title = dec.Names.First.ToString
                    If dec.AsClause IsNot Nothing Then objItem.Title &= $" As {dec.AsClause.Type}"
                    objItem.Type = StructureType.Variable
                    objItem.ParentId = parentId
                    objItem.Position = n.SpanStart
                    list.Add(objItem)
                    objItem = New StructureItem
                    i += 1
                Next
            End If
            i += 1
        Next
    End Sub

    Private Function FormatParameters(params As ParameterListSyntax) As String
        If params Is Nothing Then Return String.Empty
        Dim strResult As String = "("
        If params.Parameters.Any Then
            For Each p As ParameterSyntax In params.Parameters
                strResult &= p.Identifier.Identifier.ValueText
                Dim nA As SimpleAsClauseSyntax = p.AsClause
                If nA IsNot Nothing Then
                    strResult &= $" As {nA.Type}"
                End If
                strResult &= ", "
            Next
            strResult = strResult.Remove(strResult.Length - 2)
        End If
        strResult &= ")"
        Return strResult
    End Function

End Class