Imports System.Runtime.Serialization

Namespace Services.Contracts

    <DataContract()>
    Public Class QueryResult

        <DataMember()>
        Public Property QueryCountResult As Integer

        <DataMember()>
        Public Property Table As DataTable
    End Class

End Namespace