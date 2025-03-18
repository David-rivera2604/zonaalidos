using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Architect.API.Core.Business.General;
using Architect.API.Insurance.Contracts.Bayer;
using Architect.API.Tron.Contracts.Pagos;
using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.Payment.Integrations.Contracts;
using Architect.Payment.Integrations.Providers.Placetopay.Contracts;
using Architect.Utilities.Extensions;
using iTextSharp.text;
using Newtonsoft.Json;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// 
    /// </summary>
    public class SINPEMovil
    {
        public async static Task<Contracts.SINPEMovil.Response.AplicarPago> Create(Contracts.SINPEMovil.Request.AplicarPago aplicarPagoRequest)
        {

            /// Código que identifica el resultado del proceso.
            /// 0: Pago realizado exitosamente.
            /// 1: Pago no registrado.
            /// 2: Pago parcial.
            /// 99: Error en el proceso.
            int id = 0;
            Contracts.SINPEMovil.Response.AplicarPago result = new Contracts.SINPEMovil.Response.AplicarPago()
            {
                Codigo = 98,
                Mensaje = "Registrado pero no procesado."
            };

            using (DataFactory.Session session = new DataFactory.Session("Research"))
            {
                try
                {
                    Contracts.SINPEMovil.Request.AplicarPago current = DataAccess.Pagos.SINPEMovil.RetrieveByCodReferencia(aplicarPagoRequest.CodReferencia, session);
                    id = current.Id;
                    if (id == 0)
                    {
                        aplicarPagoRequest.Estado = result.Codigo;
                        id = DataAccess.Pagos.SINPEMovil.Create(aplicarPagoRequest, JsonConvert.SerializeObject(aplicarPagoRequest.DatosAdicionales), session);
                        if (id > 0)
                        {
                            Core.Business.General.ChangeSet.Create(3001, id, 1, "Creación", string.Format("Se registro el SINPE Movil '{0}' de {1} - {2} ({3})", aplicarPagoRequest.TelefonoDestino, aplicarPagoRequest.IdentificacionCliente, aplicarPagoRequest.NombreCliente, aplicarPagoRequest.CodReferencia), 1, aplicarPagoRequest);
                        }
                    }
                    else
                    {
                        if (current.Estado != 0)
                        {
                            int rows = DataAccess.Pagos.SINPEMovil.Update(id, aplicarPagoRequest, JsonConvert.SerializeObject(aplicarPagoRequest.DatosAdicionales), session);
                            if (rows > 0)
                            {
                                Core.Business.General.ChangeSet.Create(3001, id, 1, "Modificación", string.Format("Se actualizo el SINPE Movil '{0}' de {1} - {2} ({3})", aplicarPagoRequest.TelefonoDestino, aplicarPagoRequest.IdentificacionCliente, aplicarPagoRequest.NombreCliente, aplicarPagoRequest.CodReferencia), 1, aplicarPagoRequest);
                            }
                        }
                        else
                        {
                            Core.Business.General.ChangeSet.Create(3001, id, 1, "Modificación", string.Format("Se ignoró el SINPE Movil '{0}', ya fue aplicado de forma exitosa ({3})", aplicarPagoRequest.TelefonoDestino, aplicarPagoRequest.IdentificacionCliente, aplicarPagoRequest.NombreCliente, aplicarPagoRequest.CodReferencia), 1, aplicarPagoRequest);

                            //Notificación que el pago ya fue realizado.

                        }
                    }
                    session.CommitAndClose();
                }
                catch (Exception ex)
                {
                    session.RollbackAndClose();
                    throw ex;
                }
            }

            //Se trata de aplicar el pago
            if (id > 0 && result.Codigo == 98)
            {
                Contracts.Pagos.Recibo recibo = null;
                string policyNumber = aplicarPagoRequest.Descripcion.OnlyNumbers();

                if (policyNumber.Length != 13)
                {
                    result.Codigo = 99;
                    result.Mensaje = "Error en el proceso. No se puede identificar el número de la póliza.";
                }
                else
                {
                    recibo = DataAccess.Pagos.Recibos.PrimerReciboAlCobroPorPoliza(policyNumber);
                }
                if (result.Codigo == 98 && recibo == null)
                {
                    result.Codigo = 99;
                    result.Mensaje = "Error en el proceso. No existen recibos pendiente para la póliza.";
                }
                if (result.Codigo == 98 && aplicarPagoRequest.Monto != recibo.IMP_RECIBO)
                {
                    result.Codigo = 99;
                    result.Mensaje = "Error en el proceso. El monto del recibo no coinciden con el pago.";
                }
                if (result.Codigo == 98 && (aplicarPagoRequest.Moneda != 1 || recibo.NOM_MON != "CRC"))
                {
                    result.Codigo = 99;
                    result.Mensaje = "Error en el proceso. La moneda del recibo no coinciden con la del pago.";
                }
                if (result.Codigo == 98)
                {


                    OnlinePayment payment = new OnlinePayment()
                    {
                        CompanyId = 2,
                        DocumentType = Architect.Payment.Integrations.Payment.IdentificationTypeConvert(recibo.TIP_DOCUM),
                        DocumentNumber = recibo.COD_DOCUM,
                        FirstName = recibo.NOM_TERCERO,
                        LastName = recibo.APE1_TERCERO,
                        PrimaryEmailAddress = recibo.EMAIL,
                        PhoneNumberMobile = recibo.TLF_NUMERO,
                        AgentCode = recibo.COD_AGT,
                        PolicyId = recibo.NUM_POLIZA,
                        BillNumber = recibo.NUM_RECIBO,
                        Currency = Architect.Payment.Integrations.Payment.CurrencyConvert(recibo.NOM_MON),
                        Amount = recibo.IMP_RECIBO,
                        Reference = string.Format("{0}-{1}", recibo.NUM_POLIZA, recibo.NUM_RECIBO),
                        Description = string.Format("MAPFRE: {3}. {0}. POLIZA #{1} RECIBO #{2}", recibo.NOM_RAMO, recibo.NUM_POLIZA, recibo.NUM_RECIBO, recibo.NOM_SECTOR),
                        IssueDate = DateTime.Now,
                        StatusDate = DateTime.Now,
                        Status = 3,
                        ProviderStatus = "PENDING",
                        RecurringReceipt = true,
                        ProcessId = id.ToString(),
                        RequestID = recibo.NUM_RECIBO
                    };

                    OnlinePayment track = Payment.Integrations.Business.OnlinePayment.Create(2, 1, payment);

                    InformationRequest infoReq = new InformationRequest()
                    {
                        status = "PENDING",
                        reason = "Pending approval",
                        description = track.Description,
                        reference = track.Reference,
                        currency = recibo.NOM_MON,
                        total = track.Amount,
                        message = "Payment is pending",
                        payerName = track.FirstName,
                        payerSurname = track.LastName,
                        paymentMethodName = "SINPE",
                        lastDigits = "0000",
                        authorization = aplicarPagoRequest.CodReferencia,
                        receipt = aplicarPagoRequest.CodReferencia,
                        subscribe = false,
                        date = payment.IssueDate.ToString("yyyy-MM-dd HH:mm:ss"),
                        OnlinePayment = payment
                    };
                    string pagador = recibo.TIP_DOCUM + "-" + recibo.COD_DOCUM.DocumentNumber(recibo.TIP_DOCUM);
                    bool paymentApplayed = await Pagos.TronPayment(infoReq, infoReq.OnlinePayment.AgentCode, "Placetopay", string.Empty, pagador);

                    if (paymentApplayed)
                    {
                        result.Codigo = 0;
                        result.Mensaje = "Pago realizado exitosamente.";
                    } else
                    {
                        result.Codigo = 1;
                        result.Mensaje = "Pago no registrado.";
                    }

                }


            }
            if (id > 0)
            {
                //result.Codigo = 0;
                //result.Mensaje = "Pago realizado exitosamente.";
                using (DataFactory.Session session = new DataFactory.Session("Research"))
                {
                    try
                    {
                        DataAccess.Pagos.SINPEMovil.UpdateEstado(id, result.Codigo, result.Mensaje, session);
                        session.CommitAndClose();
                    }
                    catch (Exception ex)
                    {
                        session.RollbackAndClose();
                        throw ex;
                    }

                }
            }

            return result;
        }
    }
}
