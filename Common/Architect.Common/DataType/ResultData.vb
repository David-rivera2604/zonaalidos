Imports System.Runtime.Serialization

Namespace DataType

    <DataContract()>
    <Serializable()>
    Public Class ResultData
        Inherits Result

        Sub New()
            MyBase.New
            Count = 0
            Data = Nothing
        End Sub

        <DataMember()> Public Property Count As Long
        <DataMember()> Public Property Data As Object

    End Class

End Namespace