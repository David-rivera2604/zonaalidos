using Architect.API.Core.Business;
using Architect.API.Core.Contracts.General;
using Architect.GTI.Integrations.Domain.CargarDocumento;
using Architect.GTI.Integrations.Domain.CargarDocumento.Request;
using Architect.GTI.Integrations.Domain.Factura;
using Architect.Utilities;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Architect.GTI.Integrations.Application
{
    /// <summary>
    /// Constructor para crear instancias de DocumentoRequest con datos de ejemplo.
    /// </summary>
    public class DocumentoRequestBuilder
    {

        public static DocumentoRequest CrearEjemplo2()
        {
            // "Encabezado"."NumeroFactura": "18906329"

            // "Encabezado"."CodigoActividad": "660303"
            // "Encabezado"."Sucursal": 1
            // "Encabezado"."receptor"."CodInterno": "8002203"
            // "Lineas"."Tipo": "S"
            // "Lineas"."Codigo": "7132200000000"
            // "Lineas"."CodTipo": [ 4 ]
            // "Lineas"."CodProdServ": ["8"]
            // "Lineas"."UnidadMedida": 24


            FacturaRequest fact = new FacturaRequest
            {
                TipoIdent = 2,
                Identificacion = "4000000019",
                Nombre = "BANCO DE COSTA RICA",
                Correo = "royner.acosta@mapfrecr.com",
                Cantidad = 1,
                PrecioUnitario = 25259.28,
                Moneda = 2,
                TipoCambio = 504.44,
                TipoMedioPago = "2",
                Descripcion = "Servicios de Salud comprendido en el Periodo 01/10/2025 - 31/10/2025, Poliza No. 1410100147",
                NumeroFactura = "18906329",
                FechaFactura = new DateTime(2025, 10, 31, 23, 50, 0),
                FechaVencimiento = new DateTime(2025, 10, 1, 0, 0, 0)
            };


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

            // Actualizar la primera línea del documento
            var linea = request.Documentos[0].Lineas[0];
            linea.Cantidad = fact.Cantidad;
            linea.PrecioUnitario = (int)fact.PrecioUnitario;
            linea.Descripcion = fact.Descripcion;

            // Recalcular totales basados en la nueva información
            int totalVenta = fact.Cantidad * (int)fact.PrecioUnitario;
            float impuesto = totalVenta * 0.02f; // 2% de impuesto según el ejemplo
            float totalComprobante = totalVenta + impuesto;

            var totales = request.Documentos[0].Totales;
            totales.TotalServGravado = totalVenta;
            totales.TotalGravado = totalVenta;
            totales.TotalVenta = totalVenta;
            totales.TotalVentaNeta = totalVenta;
            totales.TotalImpuesto = impuesto;
            totales.TotalComprobante = totalComprobante;

            // Actualizar medio de pago con el total del comprobante
            encabezado.MedioPagos[0].TotalMedioPago = totalComprobante;
            encabezado.MedioPagos[0].TipoMedioPago = fact.TipoMedioPago;

            // Actualizar el impuesto de la línea
            linea.Impuestos[0].MontoImp = impuesto;


            var json = JsonConvert.SerializeObject(request);



            var session = API.Core.Business.Traza.TrackRequest.NewSession(new API.Core.Contracts.Security.Token(), "ApiCargaFactura/api/Documentos/CargarDocumento", request);
            DocumentoResponse response = null;
            try
            {
                RestClient client = new RestClient(Settings.StringValue(0, "Integration.GTI.ApiCargaFactura.BaseURL", "https://pruebas.gticr.com/AplicacionFEPruebas/ApiCargaFactura/api"),
                   $"CargarDocumento", true);
                response = client.PostAsync<DocumentoRequest, DocumentoResponse>(
                                  $"Documentos/CargarDocumento?pNumCuenta={Settings.StringValue(0, "Integration.GTI.ApiCargaFactura.NumCuenta", "3115")}&pUsuario={Settings.StringValue(0, "Integration.GTI.ApiCargaFactura.Usuario", "royner.acosta@mapfrecr.com")}&pClave={Settings.StringValue(0, "Integration.GTI.ApiCargaFactura.Clave", "Mapfre2024!")}",
                                  request).Result;
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex, session.MessageId);

                session.ResponseStatus = 400;
                session.ResponseText = ex.Message;
            }

            API.Core.Business.Traza.TrackRequest.CloseSession(session, response);

            return request;
        }


        /// <summary>
        /// Crea una instancia de DocumentoRequest con datos de ejemplo basados en MAPFRE Seguros Costa Rica S.A.
        /// </summary>
        /// <returns>Una instancia completa de DocumentoRequest.</returns>
        public static DocumentoRequest CrearBase()
        {
            return new DocumentoRequest
            {
                NumCuenta = 3115,
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
                            CantDeci = 4,
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
                                Copia = "",
                                Destinatario = "",
                                CodInterno = "8002203"
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
                                UnidadComercial = "",
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

        /// <summary>
        /// Crea una instancia de DocumentoRequest personalizada.
        /// </summary>
        /// <param name="numCuenta">Número de cuenta GTI.</param>
        /// <param name="documentos">Array de documentos a cargar.</param>
        /// <returns>Una instancia de DocumentoRequest.</returns>
        public static DocumentoRequest Crear(int numCuenta, Documento[] documentos)
        {
            return new DocumentoRequest
            {
                NumCuenta = numCuenta,
                Documentos = documentos
            };
        }
    }
}
