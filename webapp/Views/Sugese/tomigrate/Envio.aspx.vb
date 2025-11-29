Imports System.Data
Imports System.Web.Services
Imports Architect.Common.Extensions
Imports Architect.Common.Helpers

Partial Class sugese_Envio
    Inherits System.Web.UI.Page

    Private Sub sugese_Envio_Load(sender As Object, e As EventArgs) Handles Me.Load
        'MailTest()
        If Not Helpers.Security.Allowed("Sugese") Then
            ' Server.Transfer("../Default.aspx")
        Else
            Architect.Core.DataAccess.NavigationTrace.Track("Ver modelos de supervisión - Envio")
        End If

    End Sub

    <WebMethod()>
    Public Shared Function ProcesaArchivo(modelo As String, pediodoMensual As Integer, ano As Integer, excelFileName As String, internalFileName As String) As Architect.Common.DataType.Result
        Dim result As New Architect.Common.DataType.Result With {.Success = False,
                                                                .Code = 0,
                                                                .Reason = String.Empty}
        Dim serverPath As String = HttpContext.Current.Server.MapPath("../uploads")
        Dim xmlFileName As String = String.Format("{0}\{1}", serverPath, internalFileName)

        Try
            result.Reason = (New Mapfre.common.sugese.Model).Enviar(xmlFileName, modelo, ano, pediodoMensual)
            result.Success = (result.Reason.IfEmpty(String.Empty).ToUpper.Contains("<CODIGO>0</CODIGO>"))

            Architect.Core.DataAccess.NavigationTrace.Track("  Se proceso " & IIf(result.Success, " de forma exitosa ", "con errores ") & " el archivo " & excelFileName & " para el modelo " & modelo)

        Catch ex As Exception
            result = ExceptionHandlers.Factory("Ha ocurrido un error al tratar de procesar el archivo excel", ex)
            Architect.Core.DataAccess.NavigationTrace.Track("  " & result.Reason)
        End Try

        Architect.Common.Helpers.LogHandler.TraceLog("ProcesaArchivo result", result.Reason)
        Return result
    End Function

    Private Shared Sub MailTest()

        Try
            Dim message As New Net.Mail.MailMessage
            With message
                .Sender = New Net.Mail.MailAddress("ZonaAliados@mapfrecr.com", "Zona de aliados")
                .From = New Net.Mail.MailAddress("ZonaAliados@mapfrecr.com", "Zona de aliados")

                .To.Add(New Net.Mail.MailAddress("solernelson@hotmail.com", "Nelson Soler (H)"))
                .To.Add(New Net.Mail.MailAddress("solernelson@gmail.com", "Nelson Soler (G)"))
                '.CC.Add(New Net.Mail.MailAddress("accaddress@example.com", "A CC Person"))
                '.Bcc.Add(New Net.Mail.MailAddress("abccperson@example.com", "A BCC Person"))
                .Subject = "My HTML Formatted Email"
                .Body = "<h1>HTML Formatted EMail</h1>
                    <p>DO you like this <strong>EMail</strong>
                    with HTML formatting contained in its body.</p>"

                'Attachment attachment = New Attachment("mypdffile.pdf", MediaTypeNames.Application.Pdf);
                'message.Attachments.Add(attachment);
                'For Each ItemAttachmenFile As FrontOffice.Contracts.AttachmentFile In attachmentFiles
                '    Dim Data As New System.Net.Mail.Attachment(New MemoryStream(ItemAttachmenFile.FileRaw), ItemAttachmenFile.Name)

                '    'Add time stamp information for the file.
                '    Dim disposition As ContentDisposition = Data.ContentDisposition

                '    disposition.CreationDate = ItemAttachmenFile.CreationDate
                '    disposition.ModificationDate = ItemAttachmenFile.ModificationDate
                '    disposition.ReadDate = ItemAttachmenFile.ReadDate

                '    'Add the file attachment to this e-mail message.
                '    .Attachments.Add(Data)
                'Next

                .IsBodyHtml = True
            End With
            Dim smtp As New Net.Mail.SmtpClient("196.40.59.186") With {.Port = 25, .EnableSsl = False, .UseDefaultCredentials = False}
            'If Not credentialUserName.Contains("/") Then
            '    temporalCredential = New System.Net.NetworkCredential(credentialUserName, credentialPassword)
            'Else
            '    Dim user As String = credentialUserName.Split("/")(1)
            '    Dim domain As String = credentialUserName.Split("/")(0)
            '    temporalCredential = New System.Net.NetworkCredential(user, credentialPassword, domain)
            'End If
            'smtp.Credentials = temporalCredential
            smtp.Send(message)
            'Dim state As String = "hello"
            'smtp.SendAsync(message, state)
        Catch ex As Exception
            ExceptionHandlers.Factory("MailTest", ex)
        End Try
    End Sub

End Class
