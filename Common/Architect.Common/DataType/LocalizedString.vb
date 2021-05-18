Imports System.Runtime.Serialization
Imports System.Xml.Serialization
Imports System.ComponentModel

Namespace DataType

    <DataContract(Namespace:="urn:Architect.Common.DataType")>
    <Serializable()>
    <XmlType(Namespace:="urn:Architect.Common.DataType")> _
    <XmlRoot(Namespace:="urn:Architect.Common.DataType")> _
    Public Class LocalizedString

        <DataMember()>
        <XmlAttribute()>
        Public Property Language As Integer

        <DataMember()>
        <XmlAttribute(), DefaultValue("")>
        Public Property Value As String

        Public Sub New()
            MyBase.new()
        End Sub

        Public Sub New(language As Integer, value As String)
            Me.Language = language
            Me.Value = value
        End Sub

        Public Function Clone() As LocalizedString
            Return New LocalizedString() _
                                      With {.Language = Language,
                                            .Value = Value}
        End Function

    End Class

End Namespace
