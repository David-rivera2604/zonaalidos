Imports System.Runtime.Serialization

Namespace Exceptions

    <Serializable()>
    Public Class WorksheetCellException
        Inherits Exception
        Implements ISerializable

        Private _rowNumber As Integer
        Private _column As String

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(rowNumber As Integer, column As String, inner As Exception)
            MyBase.New(String.Format("Failed to process row {0} column {1}", rowNumber, column), inner)
            _rowNumber = rowNumber
            _column = column
        End Sub

        Public ReadOnly Property RowNumber() As Integer
            Get
                Return _rowNumber
            End Get
        End Property

        Public ReadOnly Property Column() As String
            Get
                Return _column
            End Get
        End Property

    End Class

End Namespace
