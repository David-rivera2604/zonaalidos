Imports System.Runtime.Serialization

Namespace Services.Contracts

    <DataContract()>
    Public Class DataCommand

        <DataMember()>
        Public ConnectionStringName As String

        <DataMember()>
        Public Property TableName As String

        <DataMember()>
        Public Property Statement As String

        <DataMember()>
        Public Property Operation As String

        <DataMember()>
        Public Property Parameters As List(Of DataParameter)

        <DataMember()>
        Public Property Owner As String

        <DataMember()>
        Public Property ObjectType As String

        <DataMember()>
        Public Property CompanyId As Integer

        <DataMember()>
        Public Property ConnectionStringsRaw As Services.Contracts.ConnectionString

        <DataMember()>
        Public Property MaxNumberOfRecord As Integer

        <DataMember()>
        Public Property IgnoreMaxNumberOfRecords As Boolean

        <DataMember()>
        Public Property QueryCount As String

        <DataMember()>
        Public Property QueryCountResult As Integer

    End Class

End Namespace

