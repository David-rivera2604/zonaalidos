Imports Architect.Common.Exceptions
Imports Architect.Common.Helpers

Namespace Mail

    Friend NotInheritable Class NetMail

        Friend Shared Sub Send(host As String, credentialUserName As String, credentialPassword As String, port As Integer, enableSSL As Boolean,
                                    [to] As String, cc As String, bcc As String, subject As String, body As String)

            LogHandler.TraceLog("Trace de NetMail", "Start")
            Dim message As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage(New System.Net.Mail.MailAddress(credentialUserName), New System.Net.Mail.MailAddress([to]))
            Dim smtp As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient(host, port)

            Try
                If Not String.IsNullOrEmpty(cc) Then
                    For Each ccItem As String In cc.Split(";")
                        If Not String.IsNullOrEmpty(ccItem) Then
                            message.CC.Add(New System.Net.Mail.MailAddress(ccItem.Trim))
                        End If
                    Next
                End If

                If Not String.IsNullOrEmpty(bcc) Then
                    For Each bccItem As String In bcc.Split(";")
                        If Not String.IsNullOrEmpty(bccItem) Then
                            message.Bcc.Add(New System.Net.Mail.MailAddress(bccItem.Trim))
                        End If
                    Next
                End If

                message.Subject = subject
                message.IsBodyHtml = True
                message.Body = body

                smtp.EnableSsl = enableSSL
                smtp.UseDefaultCredentials = False

                Dim temporalCredential = Nothing

                If Not credentialUserName.Contains("/") Then
                    temporalCredential = New System.Net.NetworkCredential(credentialUserName, credentialPassword)
                Else
                    Dim user As String = credentialUserName.Split("/")(1)
                    Dim domain As String = credentialUserName.Split("/")(0)
                    temporalCredential = New System.Net.NetworkCredential(user, credentialPassword, domain)
                End If

                smtp.Credentials = temporalCredential
                smtp.Send(message)

            Catch smptEx As System.Net.Mail.SmtpException
                Dim errMessage As String = smptEx.Message

                If errMessage.IndexOf("The server response was: 5.3.4", StringComparison.CurrentCultureIgnoreCase) > -1 AndAlso
                   errMessage.IndexOf("To continue sending messages, please sign in to your account.", StringComparison.CurrentCultureIgnoreCase) > -1 Then

                    Throw New CustomException("The account used for sending mail is disabled, please access your mail account to enable it manually.", smptEx)

                ElseIf errMessage.IndexOf("Failure sending mail.", StringComparison.CurrentCultureIgnoreCase) > -1 Then

                    If Not IsNothing(smptEx.InnerException) AndAlso
                       smptEx.InnerException.Message.IndexOf("The remote name could not be resolved:", StringComparison.CurrentCultureIgnoreCase) > -1 Then
                        errMessage = String.Format("Unable to connect to the mail server '{0}:{1}', please check the configuration file.", host, port)
                        Throw New CustomException(errMessage, smptEx)

                    ElseIf Not IsNothing(smptEx.InnerException) AndAlso
                       smptEx.InnerException.Message.IndexOf("Unable to connect to the remote server", StringComparison.CurrentCultureIgnoreCase) > -1 Then
                        errMessage = String.Format("Unable to connect to the mail server '{0}' through the port {1}, please check the configuration file', please check the configuration file.", host, port)
                        Throw New CustomException(errMessage, smptEx)
                    End If

                ElseIf errMessage.IndexOf("user not authenticated", StringComparison.CurrentCultureIgnoreCase) > -1 OrElse
                       errMessage.IndexOf("5.5.1 Authentication Required", StringComparison.CurrentCultureIgnoreCase) > -1 Then
                    errMessage = String.Format("Mail account or password invalid, please check the configuration file.", host, port)
                    Throw New CustomException(errMessage, smptEx)
                End If

                Throw smptEx
            Finally

                message.Dispose()
                message = Nothing
                smtp = Nothing
            End Try

        End Sub

    End Class

End Namespace