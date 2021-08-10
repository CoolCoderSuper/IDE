Imports System.Reflection

Public Class Helpers
    Public Shared Function QueryableToDataTable(Of T)(ByVal varlist As IEnumerable(Of T)) As DataTable
        Dim dtReturn As DataTable = New DataTable()

        ' column names 
        Dim oProps As PropertyInfo() = Nothing
        If varlist Is Nothing Then Return dtReturn

        For Each rec As T In varlist
            ' Use reflection to get property names, to create table, Only first time, others 
            If oProps Is Nothing Then
                oProps = CType(rec.GetType(), Type).GetProperties()

                For Each pi As PropertyInfo In oProps
                    Dim colType As Type = pi.PropertyType

                    If colType.IsGenericType AndAlso (colType.GetGenericTypeDefinition() Is GetType(Nullable(Of))) Then
                        colType = colType.GetGenericArguments()(0)
                    End If

                    dtReturn.Columns.Add(New DataColumn(pi.Name, colType))
                Next
            End If

            Dim dr As DataRow = dtReturn.NewRow()

            For Each pi As PropertyInfo In oProps
                dr(pi.Name) = If(pi.GetValue(rec, Nothing) Is Nothing, DBNull.Value, pi.GetValue(rec, Nothing))
            Next

            dtReturn.Rows.Add(dr)
        Next

        Return dtReturn
    End Function

End Class
