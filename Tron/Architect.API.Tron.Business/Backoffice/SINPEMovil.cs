using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architect.Payment.Integrations.Contracts;
using Architect.Utilities;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Clase para manejar las operaciones relacionadas con SINPE Movil.
    /// </summary>
    public class SINPEMovil
    {
        private const int PaymentSuccessful = 0;
        private const int PaymentNotRegistered = 1;
        private const int PaymentPartial = 2;
        private const int ErrorInProcess = 99;
        private const int RegisteredButNotProcessed = 98;

        /// <summary>
        /// Crea una nueva solicitud de pago SINPE Movil.
        /// </summary>
        /// <param name="aplicarPagoRequest">La solicitud de pago a aplicar.</param>
        /// <returns>El resultado de la aplicación del pago.</returns>
        public async static Task<Contracts.SINPEMovil.Response.AplicarPago> Create(Contracts.SINPEMovil.Request.AplicarPago aplicarPagoRequest)
        {
            int id = 0;
            var result = new Contracts.SINPEMovil.Response.AplicarPago
            {
                Codigo = RegisteredButNotProcessed,
                Mensaje = "Registrado pero no procesado."
            };

            using (var session = new DataFactory.Session("Research"))
            {
                try
                {
                    id = await ProcessPaymentRequest(aplicarPagoRequest, result, session);
                    session.CommitAndClose();
                }
                catch (Exception ex)
                {
                    session.RollbackAndClose();
                    // Log the exception
                    throw;
                }
            }

            if (id > 0 && result.Codigo == RegisteredButNotProcessed)
            {
                await ApplyPayment(aplicarPagoRequest, result, id);
            }

            if (id > 0)
            {
                UpdatePaymentStatus(id, result);
            }

            return result;
        }

        /// <summary>
        /// Consulta los datos de una transacción.
        /// </summary>
        /// <param name="id">El identificador de la consulta.</param>
        /// <param name="consultaRequest">La solicitud de consulta de datos.</param>
        /// <returns>El resultado de la consulta de datos.</returns>
        public async static Task<Contracts.SINPEMovil.Response.ConsultaDatos> Consulta(string id, Contracts.SINPEMovil.Request.ConsultaDatos consultaRequest)
        {
            Contracts.SINPEMovil.Response.ConsultaDatos result = new Contracts.SINPEMovil.Response.ConsultaDatos
            {
                Codigo = 1,
                Mensaje = "Consulta no encontrada.",
                Facturas = new List<Contracts.SINPEMovil.Response.Factura>()
            };
            try
            {
                Contracts.Pagos.Recibo recibo = null;
                string policyNumber = id.OnlyNumbers();

                if (policyNumber.Length != 13)
                {
                    policyNumber = consultaRequest.Descripcion.OnlyNumbers();
                }
                if (policyNumber.Length != 13)
                {
                    result.Codigo = ErrorInProcess;
                    result.Mensaje = "Error al ejecutar el proceso, favor intentarlo más tarde. No se puede identificar el número de la póliza.";
                }
                else
                {
                    recibo = DataAccess.Pagos.Recibos.PrimerReciboAlCobroPorPoliza(policyNumber);
                }

                if (recibo != null)
                {
                    result.Codigo = 0;
                    result.Mensaje = "Consulta realizada correctamente";
                    result.CantidadFacturas = 1;
                    result.Facturas = new List<Contracts.SINPEMovil.Response.Factura>() {
                    new Contracts.SINPEMovil.Response.Factura {
                        Codigo = recibo.NUM_RECIBO.ToString(),
                        Identificacion = recibo.COD_DOCUM,
                        Nombre = recibo.NOM_TERCERO,
                        Apellido = recibo.APE1_TERCERO,
                        Telefono = recibo.TLF_NUMERO,
                        Vencimiento = recibo.FEC_VCTO_RECIBO.ToString("dd/MM/yyyy"),
                        Saldo = Convert.ToDecimal(recibo.IMP_RECIBO),
                        SaldoMinimo = Convert.ToDecimal(recibo.IMP_RECIBO),
                        FacturasImpagas = 1
                    }
                };
                }
            }
            catch (Exception ex)
            {
                Log.ErrorLog(ex);
                result.Codigo = ErrorInProcess;
                result.Mensaje = "Error al ejecutar el proceso, favor intentarlo más tarde.";
            }


            return result;
        }

        /// <summary>
        /// Procesa la solicitud de pago.
        /// </summary>
        /// <param name="aplicarPagoRequest">La solicitud de pago a aplicar.</param>
        /// <param name="result">El resultado de la aplicación del pago.</param>
        /// <param name="session">La sesión de base de datos.</param>
        /// <returns>El ID del pago procesado.</returns>
        private static async Task<int> ProcessPaymentRequest(Contracts.SINPEMovil.Request.AplicarPago aplicarPagoRequest, Contracts.SINPEMovil.Response.AplicarPago result, DataFactory.Session session)
        {
            int id;
            var current = DataAccess.Pagos.SINPEMovil.RetrieveByCodReferencia(aplicarPagoRequest.CodReferencia, session);
            id = current.Id;
            if (id == 0)
            {
                aplicarPagoRequest.Estado = result.Codigo;
                id = DataAccess.Pagos.SINPEMovil.Create(aplicarPagoRequest, JsonConvert.SerializeObject(aplicarPagoRequest.DatosAdicionales), session);
                if (id > 0)
                {
                    Core.Business.General.ChangeSet.Create(3001, id, 1, "Creación", $"Se registro el SINPE Movil '{aplicarPagoRequest.TelefonoDestino}' de {aplicarPagoRequest.IdentificacionCliente} - {aplicarPagoRequest.NombreCliente} ({aplicarPagoRequest.CodReferencia})", 1, aplicarPagoRequest);
                }
            }
            else
            {
                await HandleExistingPaymentRequest(aplicarPagoRequest, result, session, current, id);
            }

            return id;
        }

        /// <summary>
        /// Maneja una solicitud de pago existente.
        /// </summary>
        /// <param name="aplicarPagoRequest">La solicitud de pago a aplicar.</param>
        /// <param name="result">El resultado de la aplicación del pago.</param>
        /// <param name="session">La sesión de base de datos.</param>
        /// <param name="current">La solicitud de pago actual.</param>
        /// <param name="id">El ID del pago procesado.</param>
        private static async Task HandleExistingPaymentRequest(Contracts.SINPEMovil.Request.AplicarPago aplicarPagoRequest, Contracts.SINPEMovil.Response.AplicarPago result, DataFactory.Session session, Contracts.SINPEMovil.Request.AplicarPago current, int id)
        {
            if (current.Estado != PaymentSuccessful)
            {
                int rows = DataAccess.Pagos.SINPEMovil.Update(id, aplicarPagoRequest, JsonConvert.SerializeObject(aplicarPagoRequest.DatosAdicionales), session);
                if (rows > 0)
                {
                    Core.Business.General.ChangeSet.Create(3001, id, 1, "Modificación", $"Se actualizo el SINPE Movil '{aplicarPagoRequest.TelefonoDestino}' de {aplicarPagoRequest.IdentificacionCliente} - {aplicarPagoRequest.NombreCliente} ({aplicarPagoRequest.CodReferencia})", 1, aplicarPagoRequest);
                }
            }
            else
            {
                Core.Business.General.ChangeSet.Create(3001, id, 1, "Modificación", $"Se ignoró el SINPE Movil '{aplicarPagoRequest.TelefonoDestino}', ya fue aplicado de forma exitosa ({aplicarPagoRequest.CodReferencia})", 1, aplicarPagoRequest);
                // Notificación que el pago ya fue realizado.
            }
        }

        /// <summary>
        /// Aplica el pago a la solicitud.
        /// </summary>
        /// <param name="aplicarPagoRequest">La solicitud de pago a aplicar.</param>
        /// <param name="result">El resultado de la aplicación del pago.</param>
        /// <param name="id">El ID del pago procesado.</param>
        private static async Task ApplyPayment(Contracts.SINPEMovil.Request.AplicarPago aplicarPagoRequest, Contracts.SINPEMovil.Response.AplicarPago result, int id)
        {
            Contracts.Pagos.Recibo recibo = null;
            string policyNumber = aplicarPagoRequest.Descripcion.OnlyNumbers();

            if (policyNumber.Length != 13)
            {
                result.Codigo = ErrorInProcess;
                result.Mensaje = "Error en el proceso. No se puede identificar el número de la póliza.";
            }
            else
            {
                recibo = DataAccess.Pagos.Recibos.PrimerReciboAlCobroPorPoliza(policyNumber);
            }

            if (result.Codigo == RegisteredButNotProcessed && recibo == null)
            {
                result.Codigo = ErrorInProcess;
                result.Mensaje = "Error en el proceso. No existen recibos pendiente para la póliza.";
            }

            if (result.Codigo == RegisteredButNotProcessed && aplicarPagoRequest.Monto != recibo.IMP_RECIBO)
            {
                result.Codigo = ErrorInProcess;
                result.Mensaje = "Error en el proceso. El monto del recibo no coinciden con el pago.";
            }

            if (result.Codigo == RegisteredButNotProcessed && (aplicarPagoRequest.Moneda != 1 || recibo.NOM_MON != "CRC"))
            {
                result.Codigo = ErrorInProcess;
                result.Mensaje = "Error en el proceso. La moneda del recibo no coinciden con la del pago.";
            }

            if (result.Codigo == RegisteredButNotProcessed)
            {
                await ProcessOnlinePayment(aplicarPagoRequest, result, id, recibo);
            }
        }

        /// <summary>
        /// Procesa el pago en línea.
        /// </summary>
        /// <param name="aplicarPagoRequest">La solicitud de pago a aplicar.</param>
        /// <param name="result">El resultado de la aplicación del pago.</param>
        /// <param name="id">El ID del pago procesado.</param>
        /// <param name="recibo">El recibo del pago.</param>
        private static async Task ProcessOnlinePayment(Contracts.SINPEMovil.Request.AplicarPago aplicarPagoRequest, Contracts.SINPEMovil.Response.AplicarPago result, int id, Contracts.Pagos.Recibo recibo)
        {
            var payment = new OnlinePayment
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
                Reference = $"{recibo.NUM_POLIZA}-{recibo.NUM_RECIBO}",
                Description = $"MAPFRE: {recibo.NOM_SECTOR}. {recibo.NOM_RAMO}. POLIZA #{recibo.NUM_POLIZA} RECIBO #{recibo.NUM_RECIBO}",
                IssueDate = DateTime.Now,
                StatusDate = DateTime.Now,
                Status = 3,
                ProviderStatus = "PENDING",
                RecurringReceipt = false,
                ProcessId = id.ToString(),
                RequestID = recibo.NUM_RECIBO,
                Source = "SINPEMovil"
            };

            var track = Payment.Integrations.Business.OnlinePayment.Create(2, 1, payment);

            var infoReq = new InformationRequest
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

            string pagador = $"{recibo.TIP_DOCUM}-{recibo.COD_DOCUM.DocumentNumber(recibo.TIP_DOCUM)}";
            bool paymentApplied = await Pagos.TronPayment(infoReq, infoReq.OnlinePayment.AgentCode, "Placetopay", string.Empty, pagador);

            if (paymentApplied)
            {
                result.Codigo = PaymentSuccessful;
                result.Mensaje = "Pago realizado exitosamente.";
            }
            else
            {
                result.Codigo = PaymentNotRegistered;
                result.Mensaje = "Pago no registrado.";
            }
        }

        /// <summary>
        /// Actualiza el estado del pago en la base de datos.
        /// </summary>
        /// <param name="id">El ID del pago procesado.</param>
        /// <param name="result">El resultado de la aplicación del pago.</param>
        private static void UpdatePaymentStatus(int id, Contracts.SINPEMovil.Response.AplicarPago result)
        {
            using (var session = new DataFactory.Session("Research"))
            {
                try
                {
                    DataAccess.Pagos.SINPEMovil.UpdateEstado(id, result.Codigo, result.Mensaje, session);
                    session.CommitAndClose();
                }
                catch (Exception ex)
                {
                    session.RollbackAndClose();
                    // Log the exception
                    throw;
                }
            }
        }

    }
}
