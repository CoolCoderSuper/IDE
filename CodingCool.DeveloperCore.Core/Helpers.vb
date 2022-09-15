Imports System.Reflection
Imports System.Threading
Imports System.Threading.Tasks

''' <summary>
''' Some random helper methods I find useful.
''' </summary>
Public Class Helpers

    ''' <summary>
    ''' Converts a enumerable to a data table.
    ''' </summary>
    ''' <typeparam name="T">The type of the enumerable object.</typeparam>
    ''' <param name="varlist">The data to convert.</param>
    ''' <returns></returns>
    Public Shared Function QueryableToDataTable(Of T)(ByVal varlist As IEnumerable(Of T)) As DataTable
        Dim dtReturn As DataTable = New DataTable

        ' column names
        Dim oProps As PropertyInfo() = Nothing
        If varlist Is Nothing Then Return dtReturn

        For Each rec As T In varlist
            ' Use reflection to get property names, to create table, Only first time, others
            If oProps Is Nothing Then
                oProps = rec.GetType().GetProperties()

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

    ''' <summary>
    ''' Compares the elements of a list for equality.
    ''' </summary>
    ''' <typeparam name="T">The type of list.</typeparam>
    ''' <param name="list1">One of the lists to compare.</param>
    ''' <param name="list2">The other list to compare.</param>
    ''' <returns></returns>
    Public Shared Function CompareLists(Of T)(ByVal list1 As List(Of T), ByVal list2 As List(Of T)) As Boolean
        If list1 Is Nothing OrElse list2 Is Nothing Then Return list1 Is list2
        If Not list1.Count = list2.Count Then Return False
        Dim hash As Dictionary(Of T, Integer) = New Dictionary(Of T, Integer)

        For Each employee As Object In list1

            If hash.ContainsKey(employee) Then
                hash(employee) += 1
            Else
                hash.Add(employee, 1)
            End If
        Next

        For Each employee As Object In list2

            If Not hash.ContainsKey(employee) OrElse hash(employee) = 0 Then
                Return False
            End If

            hash(employee) -= 1
        Next

        Return True
    End Function

End Class



Public Class AsyncHelper
    Private Shared ReadOnly _myTaskFactory As TaskFactory = New TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.[Default])

    Public Shared Function RunSync(Of TResult)(ByVal func As Func(Of Task(Of TResult))) As TResult
        Return _myTaskFactory.StartNew(func).Unwrap().GetAwaiter().GetResult()
    End Function

    Public Shared Sub RunSync(ByVal func As Func(Of Task))
        _myTaskFactory.StartNew(func).Unwrap().GetAwaiter().GetResult()
    End Sub

End Class