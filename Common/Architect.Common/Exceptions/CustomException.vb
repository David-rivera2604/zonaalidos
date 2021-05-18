Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Security.Permissions


#Region "Copyright (c) 2007, Global Insurance Technology, Inc."
#End Region

Namespace Exceptions
    <Serializable()>
    Public Class CustomException
        Inherits Exception
        Implements ISerializable

        Private _InvalidFields As Collection

        Protected Sub New(ByVal serializationInfo As SerializationInfo, ByVal streamingContext As StreamingContext)
            MyBase.New(serializationInfo, streamingContext)
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal message As String)
            MyBase.New(message)
            Helpers.LogHandler.ErrorLog("CustomException", message)
        End Sub

        Public Sub New(ByVal message As String, ByVal inner As Exception)
            MyBase.New(message, inner)
            Helpers.LogHandler.ErrorLog("CustomException", message, inner)
        End Sub

        Public ReadOnly Property InvalidFields() As Collection
            Get
                InvalidFields = _InvalidFields
            End Get
        End Property

        Public Shared Function ShowError(ByVal ex As Exception) As String

            Select Case ex.GetType.Name
                Case "InvalidCastException"
                    Return "Error: Input string was not in a correct format."
                Case "NullReferenceException"
                    Return "Error: Object reference not set to an instance of an object."
                Case Else
                    Return "Unexpected error in the system. Verify with your administrator"
            End Select
        End Function

        <SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.SerializationFormatter)>
        Public Overrides Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) _
            'Implements ISerializable.GetObjectData
            MyBase.GetObjectData(info, context)
            Throw New ArgumentNullException("info")


        End Sub

    End Class

End Namespace
