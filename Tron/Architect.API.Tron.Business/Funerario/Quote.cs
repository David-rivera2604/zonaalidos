using Architect.Utilities.Extensions;
using Architect.API.Tron.Contracts.Presupuesto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Tron.Business.Funerario
{
    /// <summary>
    /// Contiene la lógica de negocio para preparar, cotizar y emitir pólizas del producto autoexpedible funerario (ramo 196).
    /// </summary>
    public static class Quote
    {
        /// <summary>
        /// Código del ramo de funerario.
        /// </summary>
        const int COD_RAMO = 196;

        /// <summary>
        /// Define el tipo de operación a ejecutar sobre la solicitud.
        /// </summary>
        public enum ApplyType
        {
            /// <summary>
            /// Ejecuta el flujo de cotización.
            /// </summary>
            Cotizar,

            /// <summary>
            /// Ejecuta el flujo de emisión de póliza.
            /// </summary>
            Emitir
        }

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo autoexpedible funerario.
        /// </summary>
        /// <param name="cod_ramo">Código de ramo a inicializar.</param>
        /// <param name="tokenInfo">Información de seguridad del usuario autenticado.</param>
        /// <returns>Modelo de cotización inicializado con valores por defecto.</returns>
        public static Contracts.Cotizacion.Funerario Setup(int cod_ramo, Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Cotizacion.Funerario result = new Contracts.Cotizacion.Funerario()
            {
                cod_ramo = cod_ramo,
                cod_mon = 1,
                cod_fracc_pago = 1,
                fec_efec_poliza = DateTime.Today,
                fec_vcto_poliza = DateTime.Today.AddYears(1),
                Agente = tokenInfo.UserName,
                cod_agt = tokenInfo.AgentCode
            };
            return result;
        }

        /// <summary>
        /// Realiza la validación, transformación y cálculo necesarios para obtener una cotización o emitir una póliza del producto autoexpedible funerario.
        /// </summary>
        /// <param name="quoteInfo">Datos de entrada de la cotización.</param>
        /// <param name="tokenInfo">Información de seguridad del usuario autenticado.</param>
        /// <param name="multiPlan">Indica si se deben evaluar múltiples planes de cotización.</param>
        /// <param name="applyType">Tipo de proceso a ejecutar: cotizar o emitir.</param>
        /// <returns>Resultado del proceso con errores, presupuestos o póliza emitida según corresponda.</returns>
        public static Contracts.Cotizacion.Funerario Apply(Contracts.Cotizacion.Funerario quoteInfo, Core.Contracts.Security.Token tokenInfo, bool multiPlan, ApplyType applyType)
        {
            if (applyType == ApplyType.Cotizar)
            {
                quoteInfo = PrepareQuoteRequest(quoteInfo);
            }

            //quoteInfo = Utilities.SerializeHandler.DeserializeJSONFromFile<Architect.API.Tron.Contracts.Cotizacion.Funerario>(@"C:\bitbucket\aliados\webapp\temp\ramo.196.proposal.json");

            Contracts.Cotizacion.Funerario resultInfo = quoteInfo;
            List<Architect.API.Tron.Contracts.Cotizacion.presupuesto> presupuestos = new List<Contracts.Cotizacion.presupuesto>();
            resultInfo.Errors = Reglas.research.Apply_Reglas("Funerario", quoteInfo, tokenInfo);
            if (resultInfo.Errors.Count == 0)
            {
                string[] planes = { "1001", "1002", "1003" };
                if (applyType == ApplyType.Emitir || !multiPlan)
                {
                    planes = new string[] { quoteInfo.COD_PLAN_AP };
                }

                foreach (string plan in planes)
                {

                    quoteInfo.COD_PLAN_AP = plan;
                    quoteInfo.presupuesto = string.Empty;
                    quoteInfo.resumen = null;

                    DatoFijo result = QuoteToPresupuestoRequest(quoteInfo, quoteInfo.cod_ramo, quoteInfo.cod_agt, tokenInfo.UserName);

                    result = Backoffice.Cotizacion.Generico.Calcular(result, applyType == ApplyType.Emitir ? Backoffice.Cotizacion.Generico.Tipo_Mvto_Batch.Emitir : Backoffice.Cotizacion.Generico.Tipo_Mvto_Batch.Cotizar);

                    if (result.DatosDelProceso.txt_error.IsEmpty() && result.DatosDelProceso.num_presupuesto.IsNotEmpty())
                    {
                        resultInfo = (Contracts.Cotizacion.Funerario)Util.FromTron_CoberturasResult(quoteInfo, result, 1, true);
                        if (applyType == ApplyType.Cotizar)
                        {
                            Core.Business.General.ChangeSet.Create(3000, System.Convert.ToInt64(result.DatosDelProceso.num_presupuesto), tokenInfo.CompanyId,
                                "Cotización Autoexpedible Funerario",
                                result.DatosDelProceso.txt_error.IsEmpty() ? "Presupuesto #" + result.DatosDelProceso.num_presupuesto : result.DatosDelProceso.txt_error,
                                tokenInfo.UserId, resultInfo);

                            presupuestos.Add(new Contracts.Cotizacion.presupuesto()
                            {
                                ID = result.DatosDelProceso.num_presupuesto,
                                Key = plan,
                                primaneta = resultInfo.resumen.primaneta,
                                iVA = resultInfo.resumen.iVA,
                                recargoporfraccionamiento = resultInfo.resumen.recargoporfraccionamiento,
                                importetotal = resultInfo.resumen.importetotal,
                                cuotas = resultInfo.resumen.cuotas,
                                coberturas = resultInfo.coberturas,
                                plandepago = resultInfo.plandepago
                            });

                            resultInfo.plandepago = null;
                            resultInfo.plandepagoporfrecuencia = null;
                            resultInfo.resumen = null;
                            resultInfo.coberturas = null;
                            resultInfo.presupuestos = presupuestos;
                        }
                        else
                        {
                            Core.Business.General.ChangeSet.Create(3000, System.Convert.ToInt64(result.DatosDelProceso.num_poliza_definitivo), tokenInfo.CompanyId,
                                "Emisión Autoexpedible Funerario",
                                $"Póliza #{result.DatosDelProceso.num_poliza_definitivo}, desde el presupuesto #{result.DatosDelProceso.num_presupuesto}",
                                tokenInfo.UserId, resultInfo);
                            
                            Contracts.Poliza.DatoFijo poliza = DataAccess.LeerPoliza.Poliza(1, result.DatosDelProceso.num_poliza_definitivo, 0, 0, 0, null, true, "onlyresult");
                            resultInfo = (Contracts.Cotizacion.Funerario)Util.FromTron_CoberturasResult(quoteInfo, poliza, 1, true);
                            resultInfo.num_poliza = result.DatosDelProceso.num_poliza_definitivo;

                            //Utilities.SerializeHandler.SerializeJSONToFile<Contracts.Poliza.DatoFijo>(poliza,
                            //    string.Format($"C:\\bitbucket\\aliados\\webapp\\temp\\ramo.196.poliza.{result.DatosDelProceso.num_poliza_definitivo}.json"), true, false, false);

                            break;
                        }
                        
                    }
                    else
                    {
                        if (result.DatosDelProceso.txt_error.IsNotEmpty())
                        {
                            quoteInfo.Error = result.DatosDelProceso.txt_error;
                        }
                        else
                        {
                            quoteInfo.Error = "Ha ocurrido un error no manejado";
                        }
                        break;
                    }
                }

                //Utilities.SerializeHandler.SerializeJSONToFile<Contracts.Cotizacion.Funerario>(resultInfo,
                //    string.Format($"C:\\bitbucket\\aliados\\webapp\\temp\\ramo.196.output.{quoteInfo.num_dependientes}.json"), true, false, false);
            }

            return resultInfo;
        }

        /// <summary>
        /// Completa la solicitud de cotización con datos base de terceros para pruebas o flujo inicial.
        /// </summary>
        /// <param name="quoteInfo">Cotización a preparar.</param>
        /// <returns>Cotización con la lista de terceros inicializada.</returns>
        private static Contracts.Cotizacion.Funerario PrepareQuoteRequest(Contracts.Cotizacion.Funerario quoteInfo)
        {
            quoteInfo.terceros = new List<Contracts.Comun.tercero>();

            //Asegurado
            quoteInfo.terceros.Add(new Contracts.Comun.tercero()
            {
                tercerosId = 1,
                tipodetercero = 2,
                elaseguradoeselmismotomador = 1,
                DocumentNumberType = 1,
                DocumentNumber = "983776766", // 116020611
                nombre = string.Empty,
                apellido1 = string.Empty,
                apellido2 = string.Empty,
                fechadenacimiento = DateTime.Today.AddYears(-30),
                tercerosMca_sexo = 1,
                numerodetelefono = string.Empty,
                correoelectronico = string.Empty,
                cod_pais = "CRI"
            });
            if (quoteInfo.num_dependientes >= 1)
            {
                quoteInfo.terceros.Add(new Contracts.Comun.tercero()
                {
                    tercerosId = 2,
                    tipodetercero = 16,
                    parentesco = 9,
                    elaseguradoeselmismotomador = 0,
                    DocumentNumberType = 1,
                    DocumentNumber = "801540055", //116050862
                    nombre = string.Empty,
                    apellido1 = string.Empty,
                    apellido2 = string.Empty,
                    fechadenacimiento = DateTime.Today.AddYears(-30),
                    tercerosMca_sexo = 1,
                    numerodetelefono = string.Empty,
                    correoelectronico = string.Empty,
                    cod_pais = "CRI"
                });
            }
            if (quoteInfo.num_dependientes >= 2)
            {
                quoteInfo.terceros.Add(new Contracts.Comun.tercero()
                {
                    tercerosId = 3,
                    tipodetercero = 16,
                    parentesco = 3,
                    elaseguradoeselmismotomador = 0,
                    DocumentNumberType = 1,
                    DocumentNumber = "109630981",//121830755
                    nombre = string.Empty,
                    apellido1 = string.Empty,
                    apellido2 = string.Empty,
                    fechadenacimiento = DateTime.Today.AddYears(-12),
                    tercerosMca_sexo = 1,
                    numerodetelefono = string.Empty,
                    correoelectronico = string.Empty,
                    cod_pais = "CRI"
                });
            }

            return quoteInfo;
        }

        /// <summary>
        /// Convierte el modelo de cotización funerario al formato de presupuesto requerido por Tron.
        /// </summary>
        /// <param name="quoteInfo">Información de la cotización origen.</param>
        /// <param name="branch">Código del ramo.</param>
        /// <param name="agentCode">Código de agente.</param>
        /// <param name="userName">Usuario que ejecuta el proceso.</param>
        /// <returns>Objeto de presupuesto listo para cálculo en backoffice.</returns>
        private static Contracts.Presupuesto.DatoFijo QuoteToPresupuestoRequest(Contracts.Cotizacion.Funerario quoteInfo, int branch, int agentCode, string userName)
        {

            if (quoteInfo.coberturas == null || quoteInfo.coberturas.Count == 0)
            {
                int cod_cia = Architect.Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia", 1);

                DateTime fec_validez = DateTime.Today;
                quoteInfo.coberturas = Funerario.QuoteSupport.CoverageByDefault(cod_cia, quoteInfo.cod_ramo, fec_validez);
            }
            Contracts.Presupuesto.DatoFijo datosFijos = Util.Tron(quoteInfo, branch, agentCode, userName, "Cotizador autoexpedible funerario");

            datosFijos.Riesgos.First().cod_modalidad = 19601;

            if (quoteInfo.terceros?.Count > 0)
            {
                datosFijos.Terceros = new List<Contracts.Presupuesto.Tercero>();
                datosFijos.DetalleDeTerceros = new List<DetalleDeTercero>();
                foreach (Architect.API.Tron.Contracts.Comun.tercero item in quoteInfo.terceros)
                {
                    if (item.tipodetercero == Contracts.Comun.tercero.TOMADOR && item.eltomadoreselmismoasegurado == 1)
                    {
                        datosFijos.Terceros.Add(QuoteSupport.Tercero(datosFijos, item, Contracts.Comun.tercero.ASEGURADO));
                    }
                    else if (item.tipodetercero == Contracts.Comun.tercero.ASEGURADO && item.elaseguradoeselmismotomador == 1)
                    {
                        datosFijos.Terceros.Add(QuoteSupport.Tercero(datosFijos, item, Contracts.Comun.tercero.TOMADOR));
                    }
                    datosFijos.Terceros.Add(QuoteSupport.Tercero(datosFijos, item, item.tipodetercero));
                    datosFijos.DetalleDeTerceros.Add(Util.CambioTerceroPresupuesto(datosFijos, item));
                }
                Contracts.Comun.tercero contratante = QuoteSupport.Contratante(quoteInfo.terceros);
                if (contratante != null)
                {
                    datosFijos.tip_docum = contratante.DocumentNumberType.DocumentType();
                    datosFijos.cod_docum = contratante.DocumentNumber.DocumentNumber(datosFijos.tip_docum);
                }
                Contracts.Comun.tercero asegurado = QuoteSupport.Asegurado(quoteInfo.terceros);
                if (asegurado != null)
                {
                    quoteInfo.FEC_NACIMIENTO = asegurado.fechadenacimiento;
                    quoteInfo.MCA_SEXO = asegurado.tercerosMca_sexo.ToString();
                }
            }

            datosFijos.DatosVariables = QuoteSupport.DatosVariable_ToTron(quoteInfo, datosFijos);
            return datosFijos;
        }

    }
}
