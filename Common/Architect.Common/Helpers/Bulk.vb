Imports System.Configuration

Namespace Helpers

    Public NotInheritable Class Bulk

        Public Shared Sub test(data As DataTable, tableName As String, connectionStringName As String)
            Using bulkcopy As New Oracle.DataAccess.Client.OracleBulkCopy(ConfigurationManager.ConnectionStrings(connectionStringName).ConnectionString)
                bulkcopy.DestinationTableName = tableName
                bulkcopy.WriteToServer(data)
                bulkcopy.Close()
            End Using
        End Sub

    End Class

End Namespace