using Architect.API.Core.Business;
using Architect.GTI.Integrations.Domain.CargarDocumento;
using Architect.GTI.Integrations.Domain.CargarDocumento.Request;
using Architect.GTI.Integrations.Domain.Factura;
using Architect.Utilities;
using Newtonsoft.Json;
using System;

namespace Architect.GTI.Integrations.Application
{
    /// <summary>
    /// Constructor para crear instancias de DocumentoRequest con datos de ejemplo.
    /// </summary>
    public class DocumentoRequestHandler
    {
        /// <summary>
        /// Envia un comprobante electrónico a Hacienda.
        /// </summary>
        public static DocumentoResponse CargarDocumento(int companyId, FacturaRequest fact)
        {
            DocumentoRequest request = Convert_FacturaRequest_to_DocumentoRequest(fact);

            var session = API.Core.Business.Traza.TrackRequest.NewSession(new API.Core.Contracts.Security.Token() { CompanyId = companyId }, "ApiCargaFactura/api/Documentos/CargarDocumento", request);
            DocumentoResponse response = null;
            try
            {
                RestClient client = new RestClient("Integration.GTI.ApiCargaFactura.BaseURL".StringValue(0, "https://pruebas.gticr.com/AplicacionFEPruebas/ApiCargaFactura/api"),
                   $"CargarDocumento", true, TimeSpan.FromSeconds(200));
                response = client.PostAsync<DocumentoRequest, DocumentoResponse>(
                                  $"Documentos/CargarDocumento?pNumCuenta={"Integration.GTI.ApiCargaFactura.NumCuenta".StringValue(0, "3115")}&pUsuario={"Integration.GTI.ApiCargaFactura.Usuario".StringValue(0, "royner.acosta@mapfrecr.com")}&pClave={"Integration.GTI.ApiCargaFactura.Clave".StringValue(0, "Mapfre2024!")}",
                                  request).Result;
            }
            catch (Exception ex)
            {
                string code = Architect.Utilities.Log.ErrorLog(ex, session.MessageId);

                session.ResponseStatus = 400;
                session.ResponseText = $"{ex.Message} ({code})";
            }

            API.Core.Business.Traza.TrackRequest.CloseSession(session, response);

            return response;
        }

        /// <summary>
        /// Convierte un objeto FacturaRequest en un DocumentoRequest para el envío a GTI.
        /// </summary>
        /// <param name="fact">Objeto FacturaRequest con los datos de la factura a procesar.</param>
        /// <returns>DocumentoRequest con la estructura completa requerida por el API de GTI.</returns>
        /// <remarks>
        /// Este método toma una plantilla base de DocumentoRequest y actualiza sus propiedades con los valores
        /// proporcionados en el FacturaRequest. Se actualizan los siguientes elementos:
        /// - Encabezado: Tipo de cambio, moneda, número de factura, fechas
        /// - Receptor: Identificación, nombre y correo del cliente
        /// - Líneas: Detalles del producto/servicio, código, descripción, precio e impuestos
        /// - Totales: Cálculo de montos gravados, impuestos y total del comprobante
        /// - Medio de pago: Tipo y total del medio de pago
        /// Los cálculos de precio unitario se realizan restando el impuesto del precio total.
        /// </remarks>
        private static DocumentoRequest Convert_FacturaRequest_to_DocumentoRequest(FacturaRequest fact)
        {
            DocumentoRequest request = CrearBase();

            // Mapeo de propiedades de FacturaRequest a DocumentoRequest
            // Actualizar información del receptor
            var encabezado = request.Documentos[0].Encabezado;
            encabezado.TipoCambio = fact.TipoCambio;
            encabezado.Moneda = fact.Moneda;
            encabezado.NumeroFactura = fact.NumeroFactura;
            encabezado.FechaFactura = fact.FechaFactura;
            encabezado.FechaVencimiento = fact.FechaVencimiento;

            var receptor = encabezado.receptor;
            receptor.TipoIdent = fact.TipoIdent;
            receptor.Identificacion = fact.Identificacion;
            receptor.Nombre = fact.Nombre;
            receptor.Correo = fact.Correo;

            // Recalcular totales basados en la nueva información
            //double totalComprobante = fact.PrecioTotal;
            //double impuesto = fact.Impuesto;
            //double precioUnitario = Math.Round(fact.PrecioTotal - fact.Impuesto, 2);
            double precioUnitario = Math.Round(fact.PrecioUnitario, 3);
            double impuesto = Math.Round(precioUnitario * (request.Documentos[0].Lineas[0].Impuestos[0].PorcentajeImp / 100.0), 3);
            double totalComprobante = Math.Round(precioUnitario + impuesto, 3);



            // Actualizar la primera línea del documento
            var linea = request.Documentos[0].Lineas[0];
            linea.Codigo = fact.Codigo;
            linea.CodProdServ[0] = fact.CodigoServicio;
            linea.Cantidad = fact.Cantidad;
            linea.PrecioUnitario = precioUnitario;
            linea.Descripcion = fact.Descripcion;

            var totales = request.Documentos[0].Totales;
            totales.TotalServGravado = precioUnitario;
            totales.TotalGravado = precioUnitario;
            totales.TotalVenta = precioUnitario;
            totales.TotalVentaNeta = precioUnitario;
            totales.TotalImpuesto = impuesto;
            totales.TotalComprobante = totalComprobante;

            // Actualizar medio de pago con el total del comprobante
            encabezado.MedioPagos[0].TotalMedioPago = totalComprobante;
            encabezado.MedioPagos[0].TipoMedioPago = fact.TipoMedioPago;

            // Actualizar el impuesto de la línea
            linea.Impuestos[0].MontoImp = impuesto;

            var json = JsonConvert.SerializeObject(request);
            return request;
        }

        /// <summary>
        /// Crea una instancia de DocumentoRequest con datos de ejemplo basados en MAPFRE Seguros Costa Rica S.A.
        /// </summary>
        /// <returns>Una instancia completa de DocumentoRequest.</returns>
        private static DocumentoRequest CrearBase()
        {
            return new DocumentoRequest
            {
                NumCuenta = Convert.ToInt32("Integration.GTI.ApiCargaFactura.NumCuenta".StringValue(0, "3115")),
                Documentos = new[]
                {
                    new Documento
                    {
                        Emisor = new Emisor
                        {
                            TipoIdent = 2,
                            Identificacion = "3101560179",
                            Nombre = "MAPFRE Seguros Costa Rica S.A.",
                            NombComercial = "MAPFRE Seguros Costa Rica S.A.",
                            Provincia = 1,
                            Canton = 15,
                            Distrito = 1,
                            Direccion = "San José Montes de Oca San Pedro (SJ) Oficentro Condal, Piso 1 y 7",
                            AreaTelefono = 506,
                            NumTelefono = 41040200,
                            AreaFax = 506,
                            NumFax = 41040200,
                            Correo = "facturacionelectronica@mapfrecr.com"
                        },
                        Encabezado = new Encabezado
                        {
                            CodigoActividad = "660303",
                            ImpRenta = 1,
                            NombComercial = "BANCO DE COSTA RICA",
                            CantDeci = 3,
                            TipoDoc = 1,
                            SituacionEnvio = 1,
                            Sucursal = 1,
                            Terminal = 1,
                            Moneda = 2,
                            TipoCambio = 504.44f,
                            MedioPagos = new[]
                            {
                                new Mediopago
                                {
                                    TipoMedioPago = "4",
                                    TotalMedioPago = 25259.28f
                                }
                            },
                            CondicionVenta = 1,
                            NumeroFactura = "18906329",
                            FechaFactura = new DateTime(2025, 10, 31, 23, 50, 0),
                            NumOrdenCompra = null,
                            FechaVencimiento = new DateTime(2025, 10, 1, 0, 0, 0),
                            receptor = new Receptor
                            {
                                TipoIdent = 2,
                                Identificacion = "4000000019",
                                Nombre = "BANCO DE COSTA RICA",
                                Correo = "royner.acosta@mapfrecr.com",
                                Copia = string.Empty,
                                Destinatario =string.Empty
                            }
                        },
                        Lineas = new[]
                        {
                            new Linea
                            {
                                Tipo = "S",
                                Codigo = "7132200000000",
                                CodTipo = new[] { 4 },
                                CodProdServ = new[] { "8" },
                                UnidadMedida = 24,
                                UnidadComercial =string.Empty,
                                Cantidad = 1,
                                PrecioUnitario = 24764,
                                Descripcion = "Servicios de Salud comprendido en el Periodo 01/10/2025 - 31/10/2025, Poliza No. 1410100147",
                                Impuestos = new[]
                                {
                                    new Impuesto
                                    {
                                        CodigoTarifa = 3,
                                        CodigoImp = 1,
                                        PorcentajeImp = 2,
                                        MontoImp = 495.28f
                                    }
                                }
                            }
                        },
                        OtrosCargos = new object[] { },
                        referencia = null,
                        Totales = new Totales
                        {
                            TotalServGravado = 24764,
                            TotalServExento = 0,
                            TotalServExonerado = 0,
                            TotalMercaGravada = 0,
                            TotalMercaExenta = 0,
                            TotalMercaExonerada = 0,
                            TotalGravado = 24764,
                            TotalExento = 0,
                            TotalExonerado = 0,
                            TotalIVADevuelto = 0,
                            TotalVenta = 24764,
                            TotalDescuento = 0,
                            TotalVentaNeta = 24764,
                            TotalImpuesto = 495.28f,
                            TotalComprobante = 25259.28f
                        },
                        Extra = new Extra
                        {
                            EsVersion_4_4 = true
                        }
                    }
                }
            };
        }
    }
}