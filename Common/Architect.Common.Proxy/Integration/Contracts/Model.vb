Namespace Integration.Contracts

    Public Class Model

        Public Property Title As String
        Public Property TableName As String
        Public Property Worksheet As Integer = 1
        Public Property FirstDataRow As Integer = 2
        Public Property Columns As New List(Of Column)
        Public Property LastSequenceNumber As Integer = 0
        Public Property ConnectionStringName As String
        Public Property Sequence As New SequenceSetting

        Public ReadOnly Property RealTitle As String
            Get
                If Title.IsNotEmpty Then
                    Return Title
                Else
                    Return TableName
                End If
            End Get
        End Property

        Public Sub New(table As String)
            TableName = table
        End Sub

        Public ReadOnly Property RealDataColumnCount As Integer
            Get
                Return Columns.Count
            End Get
        End Property

        Public Function AddColumn(excelColumnNumber As Integer, columnName As String, type As System.Data.DbType, size As Integer, title As String, comment As String, lookup As String) As Column
            Dim item As Column = AddColumn(excelColumnNumber, columnName, type, size)
            With item
                .Title = title
                .Comment = comment
                .LookUpStatement = lookup
            End With
            Return item
        End Function

        Public Function AddColumn(excelColumnNumber As Integer, columnName As String, type As System.Data.DbType) As Column
            Return AddColumn(excelColumnNumber, columnName, type, 0)
        End Function

        Public Function AddColumn(excelColumnNumber As Integer, columnName As String, type As System.Data.DbType, Size As Integer) As Column
            Dim item As New Column With {.ExcelColumnNumber = excelColumnNumber,
                                         .Name = columnName,
                                         .Type = type,
                                         .Size = Size}
            Columns.Add(item)

            Return item
        End Function

        Public Class Column

            Public Property Name As String
            Public Property Title As String
            Public Property Comment As String
            Public Property Size As Integer
            Public Property Type As System.Data.DbType
            Public Property ExcelColumnNumber As Integer
            Public Property Visible As Boolean = True
            Public Property IsNullable As Boolean = True
            Public Property Scale As Integer = 2
            Public Property Sequence As Boolean
            Public Property Constant As String
            Public Property Value As Object

            Public Property LookUpStatement As String
            Public Property LookUpData As DataTable
            Public Property Audit As Boolean

            Public ReadOnly Property RealTitle As String
                Get
                    If Title.IsNotEmpty Then
                        Return Title
                    Else
                        Return Name
                    End If
                End Get
            End Property

        End Class

        Public Class SequenceSetting

            Public Property TableName As String
            Public Property ColumnName As String

        End Class

    End Class

End Namespace