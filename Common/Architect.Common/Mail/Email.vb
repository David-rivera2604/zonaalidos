Imports System.Configuration
Imports System.Globalization
Imports System.Reflection
Imports Architect.Common.Exceptions
Imports Architect.Common.Helpers


Imports System.Threading.Tasks
Imports System.Threading

Namespace Mail

    Public Class Email

        Public Shared Sub Send([to] As String, cc As String, bcc As String, subject As String, body As String)
            Dim Host As String = ConfigurationManager.AppSettings("Mail.Host")
            Dim Port As Integer = ConfigurationManager.AppSettings("Mail.Port")
            Dim CredentialUserName As String = ConfigurationManager.AppSettings("Mail.UserName")
            Dim CredentialPassword As String = ConfigurationManager.AppSettings("Mail.Password")
            Dim EnableSSL As Boolean = (ConfigurationManager.AppSettings("Mail.EnableSSL") = "True")
            Dim mode As String = ConfigurationManager.AppSettings("Mail.Mode")

            Send(Host, Port, CredentialUserName, CredentialPassword, EnableSSL, mode, [to], cc, bcc, subject, body)
        End Sub

        Public Shared Sub Send(host As String, port As Integer, credentialUserName As String, credentialPassword As String, enableSSL As Boolean, mode As String,
                                         [to] As String, cc As String, bcc As String, subject As String, body As String)



            If String.IsNullOrEmpty(host) Then
                Throw New ArgumentException("The 'Host' app setting is required")
            End If

            If mode = "NetMail" Then
                If port <= 0 Then
                    Throw New ArgumentException("The 'Port' app setting is required")
                End If
            End If

            If String.IsNullOrEmpty(credentialUserName) Then
                Throw New ArgumentException("The 'CredentialUserName' app setting is required")
            End If

            If String.IsNullOrEmpty(credentialPassword) Then
                Throw New ArgumentException("The 'CredentialPassword' app setting is required")
            End If

            If String.IsNullOrEmpty([to]) Then
                Throw New CustomException("There are no recipients specified in Mail Address 'To'")
            End If

            If String.IsNullOrEmpty(subject) Then
                Throw New CustomException("There are no subject specified in Mail")
            End If

            If String.IsNullOrEmpty(body) Then
                Throw New CustomException("There are no body specified in Mail")
            End If

            Try
                Select Case mode
                    Case "NetMail"
                        NetMail.Send(host, credentialUserName, credentialPassword, port, enableSSL, [to], cc, bcc, subject, body)
                End Select

            Catch ex As Exception
                LogHandler.ErrorLog("Error SendEmail", ex.Message, ex)
            End Try
        End Sub

    End Class

End Namespace