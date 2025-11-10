Imports System.ComponentModel
Imports System.Runtime.Serialization
Imports System.Xml.Serialization

<DataContract()>
<Serializable()>
Public Class Result

    Sub New()
        Success = False
        Code = 0
        Reason = String.Empty
        Detail = String.Empty
    End Sub

    <DataMember(EmitDefaultValue:=False)>
    <XmlAttribute(), DefaultValue(GetType(Boolean), "False")>
    Public Property Success As Boolean


    <DataMember(EmitDefaultValue:=False)>
    <XmlAttribute(), DefaultValue(GetType(Integer), "0")>
    Public Property Code As Integer

    <DataMember(EmitDefaultValue:=False)>
    <XmlAttribute(), DefaultValue(GetType(String), "")>
    Public Property Reason As String

    <DataMember(EmitDefaultValue:=False)>
    <XmlAttribute(), DefaultValue(GetType(String), "")>
    Public Property Detail As String

End Class