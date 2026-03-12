using Aliados.Monge.Domain.Poliza.Emision;
using Architect.API.Tron.Business.Cotizacion;
using Architect.API.Tron.Contracts.Cotizacion;
using Architect.API.Tron.Contracts.Presupuesto.API;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Application.Poliza.Ramos
{
    internal class Tarjetas
    {

        internal static async Task<Domain.Poliza.Emision.Respuesta> Handler(Domain.Poliza.Emision.Poliza risk, Architect.API.Core.Contracts.Security.Token tokenInfo)
        {
            Domain.Poliza.Emision.Respuesta result = null;
            int trackingId = Architect.API.Tron.Business.Traza.TrackRequest.Add(tokenInfo.CompanyId, tokenInfo.UserId,
                                         new Architect.API.Tron.Contracts.Traza.TrackRequest()
                                         {
                                             DocumentId = risk.document_id,
                                             RequestType = "Emision",
                                             RequestBody = Newtonsoft.Json.JsonConvert.SerializeObject(risk),
                                             RequestTimeStamp = DateTime.Now
                                         }).Id;

            try
            {
                int cod_ramo = Convert.ToInt32(risk.Datos_Generales.cod_producto);
                Architect.API.Tron.Contracts.Ramo.A1001800 ramo = Architect.API.Tron.Business.Ramo.Configuracion.Retrieve(cod_ramo);

                TRON_Validate(risk, ramo);

                Architect.API.Tron.Contracts.Presupuesto.DatoFijo result2 = DatosFijos(risk, cod_ramo, tokenInfo, ramo.COD_SECTOR);
                result2.Riesgos = Architect.API.Tron.Business.Util.DatosDelRiesgo(result2, "Cotizador Seguro de tarjeta de crédito");
                result2.Coberturas = Coberturas(risk, result2);
                result2.DatosVariables = DatosVariables(risk, result2, ramo);
                result2 = MapperTerceros(risk, result2);

                result2.tip_docum = result2.Terceros.FirstOrDefault().tip_docum;
                result2.cod_docum = result2.Terceros.FirstOrDefault().cod_docum;

                result2 = Architect.API.Tron.Business.Backoffice.Cotizacion.Generico.Calcular(result2, Architect.API.Tron.Business.Backoffice.Cotizacion.Generico.Tipo_Mvto_Batch.Emitir, "Riesgo emitido desde ZA Web");
                if (result2.DatosDelProceso.txt_error.IsEmpty())
                {

                    Architect.API.Tron.Contracts.Poliza.DatoFijo polizaEmitida = null;
                    polizaEmitida = Architect.API.Tron.Business.Backoffice.Common.InformacionDePoliza(result2.DatosDelProceso.num_poliza_definitivo);


                    result = new Domain.Poliza.Emision.Respuesta()
                    {
                        message_status = 200,
                        message_text = "Emisión exitosa",
                        message_id = Guid.NewGuid().ToString(),
                        document_id = risk.document_id,
                        message_body = new Domain.Poliza.Emision.RespuestaDetalle()
                        {
                            num_poliza = result2.DatosDelProceso.num_poliza_definitivo,
                            num_certificado_phx = string.Empty,
                            resumen = new Domain.Poliza.Emision.Resumen()
                            {
                                            primaneta = polizaEmitida.Recibos.Sum(p => p.imp_neta) + polizaEmitida.Recibos.Sum(p => p.imp_recargo),
                                            iVA = polizaEmitida.Recibos.Sum(p => p.imp_imptos),
                                            recargoporfraccionamiento = polizaEmitida.Recibos.Sum(p => p.imp_interes),
                                            importetotal = polizaEmitida.Recibos.Sum(p => p.imp_recibo),
                                            cuotas = polizaEmitida.Recibos.Count
                            },
                            plandepago = new List<Domain.Poliza.Emision.Plandepago>()
                        }
                    };
                    foreach (Architect.API.Tron.Contracts.Poliza.Recibo item in polizaEmitida.Recibos)
                    {
                        result.message_body.plandepago.Add(new Domain.Poliza.Emision.Plandepago()
                        {
                            cuota = item.num_cuota,
                            fechadesde = item.fec_efec_recibo,
                            fechahasta = item.fec_vcto_recibo,
                            primaneta = item.imp_neta + item.imp_recargo,
                            iVA = item.imp_imptos,
                            recargoporfraccionamiento = item.imp_interes,
                            importetotal = item.imp_recibo
                        });
                    }
                }
                else
                {
                    result = new Domain.Poliza.Emision.Respuesta()
                    {
                        message_status = 400,
                        message_text = result2.DatosDelProceso.txt_error,
                        message_id = Guid.NewGuid().ToString(),
                        document_id = risk.document_id
                    };
                }
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex);

                result = new Domain.Poliza.Emision.Respuesta()
                {
                    message_status = 400,
                    message_text = ex.Message,
                    message_id = Guid.NewGuid().ToString(),
                    document_id = risk.document_id
                };
            }

            Architect.API.Tron.Business.Traza.TrackRequest.Update(tokenInfo.CompanyId, tokenInfo.UserId, trackingId,
                                      new Architect.API.Tron.Contracts.Traza.TrackRequest()
                                      {
                                          MessageId = result.message_id,
                                          ResponseStatus = result.message_status,
                                          ResponseText = result.message_text,
                                          ResponseBody = Newtonsoft.Json.JsonConvert.SerializeObject(result),
                                          ResponseTimeStamp = DateTime.Now
                                      });
            return result;
        }

        private static Architect.API.Tron.Contracts.Presupuesto.DatoFijo DatosFijos(Domain.Poliza.Emision.Poliza risk, int branch, Architect.API.Core.Contracts.Security.Token tokenInfo, int cod_sector)
        {
            int num_contrato = int.MinValue;
            int num_subcontrato = int.MinValue;
            string num_poliza_grupo = string.Empty;
            DateTime fec_vcto_poliza = risk.Datos_Generales.fec_vcto_poliza;

            if (risk.Datos_Variables != null)
            {
                DatosVariables dato = risk.Datos_Variables.Where(r => r.nombre.Equals("NUM_CONTRATO", StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                if (dato != null)
                {
                    risk.Datos_Variables.Remove(dato);
                    num_contrato = Convert.ToInt32(dato.valor);
                    if (num_contrato == 0)
                    {
                        num_contrato = int.MinValue;
                    }
                    dato = risk.Datos_Variables.Where(r => r.nombre.Equals("NUM_SUBCONTRATO", StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                    if (dato != null)
                    {
                        risk.Datos_Variables.Remove(dato);
                        num_subcontrato = Convert.ToInt32(dato.valor);
                        if (num_subcontrato == 0)
                        {
                            num_subcontrato = int.MinValue;
                        }
                    }
                }
                if (num_contrato != int.MinValue)
                {
                    string url = $"cod_ramo=230:cod_mon={risk.Datos_Generales.moneda}:num_contrato={num_contrato}:num_subcontrato={num_subcontrato}";
                    List<Architect.API.Core.Contracts.General.LookupValues> values = Architect.API.Core.Business.Common.Lkps("MM_POLIZA_GRUPO", url, tokenInfo);


                    Architect.API.Core.Contracts.General.LookupValues contratosMaster = values.Find(x => x.Key == "MM_POLIZA_GRUPO");
                    if (contratosMaster != null)
                    {
                        Architect.API.Core.Contracts.General.LookupValue contrato = contratosMaster.Lkp.Find(y => y.Code == num_contrato.ToString());
                        if (contrato != null)
                        {
                            string num_policy = (string)contrato["NUM_POLIZA"];
                            if (num_policy.IsNotEmpty())
                            {
                                num_poliza_grupo = num_policy;
                            }
                            string vcto_poliza = (string)contrato["FEC_VCTO_POLIZA"];
                            if (vcto_poliza.IsNotEmpty())
                            {
                                fec_vcto_poliza = DateTime.Parse(vcto_poliza, CultureInfo.CreateSpecificCulture("es-CR"));
                            }
                        }
                    }
                }
            }
            return new Architect.API.Tron.Contracts.Presupuesto.DatoFijo()
            {
                cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]),
                num_poliza = string.Empty,
                num_spto = 0,
                num_apli = 0,
                num_spto_apli = 0,
                cod_sector = cod_sector,
                cod_ramo = branch,
                fec_validez = DateTime.MinValue,
                fec_emision = DateTime.MinValue,
                fec_emision_spto = DateTime.MinValue,
                fec_efec_poliza = risk.Datos_Generales.fec_efec_poliza,
                fec_vcto_poliza = fec_vcto_poliza,
                fec_efec_spto = DateTime.MinValue,
                fec_vcto_spto = DateTime.MinValue,
                tip_duracion = 0,
                num_riesgos = 0,
                cod_mon = risk.Datos_Generales.moneda,
                cod_fracc_pago = risk.Datos_Generales.cod_fracc_pago,
                cant_renovaciones = 0,
                num_renovaciones = 0,
                tip_coaseguro = 0,
                num_contrato = num_contrato,
                num_subcontrato = num_subcontrato,
                num_poliza_grupo = num_poliza_grupo,
                num_secu_grupo = 0,
                cod_spto = 0,
                sub_cod_spto = 0,
                txt_motivo_spto = "Cotización realizada desde la zona de aliados, por: " + tokenInfo.UserName,
                cod_cuadro_com = 100,
                cod_agt = tokenInfo.AgentCode,
                pct_agt = 0,
                cod_org = 0,
                cod_asesor = 0,
                cod_nivel1 = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_nivel1"]),
                cod_nivel2 = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_nivel2"]),
                cod_nivel3 = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_nivel3"]),
                cod_compensacion = 0,
                pct_regulariza = 0,
                cod_indice = 0,
                anios_max_duracion = 0,
                meses_max_duracion = 0,
                dias_max_duracion = 0,
                cod_agt2 = 0,
                pct_agt2 = 0,
                cod_agt3 = 0,
                pct_agt3 = 0,
                cod_agt4 = 0,
                pct_agt4 = 0,
                duracion_pago_prima = 0,
                cod_ejecutivo = 0,
                fec_autorizacion = DateTime.MinValue,
                num_spto_anulado = 0,
                fec_spto_anulado = DateTime.MinValue,
                cod_nivel3_captura = 0,
                fec_actu = DateTime.MinValue,
                cod_dst_agt = 0,
                num_spto_publico = 0,
                fec_tratamiento = DateTime.MinValue,
                num_orden = 0,
                hora_desde = Convert.ToString(DateTime.Today.Hour)
            };
        }

        private static List<Architect.API.Tron.Contracts.Presupuesto.Cobertura> Coberturas(Domain.Poliza.Emision.Poliza risk, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, int num_riesgo = 1)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.Cobertura> coberturas = new List<Architect.API.Tron.Contracts.Presupuesto.Cobertura>();
            Architect.API.Tron.Contracts.Presupuesto.Cobertura currentItem;

            foreach (Domain.Poliza.Emision.Cobertura item in risk.Coberturas)
            {
                for (int riesgo = 1; riesgo <= num_riesgo; riesgo++)
                {
                    currentItem = new Architect.API.Tron.Contracts.Presupuesto.Cobertura()
                    {
                        cod_cia = datosFijos.cod_cia,
                        num_poliza = datosFijos.num_poliza,
                        num_spto = datosFijos.num_spto,
                        num_apli = datosFijos.num_apli,
                        num_spto_apli = datosFijos.num_spto_apli,
                        num_riesgo = riesgo,
                        num_periodo = 1,
                        cod_cob = item.codigo,
                        cod_ramo = datosFijos.cod_ramo,
                        num_secu = 1,
                        suma_aseg = item.sumaasegurada,
                        imp_prima = 0
                    };

                    coberturas.Add(currentItem);
                }
            }
            return coberturas;
        }

        private static Architect.API.Tron.Contracts.Presupuesto.DatoFijo MapperTerceros(Domain.Poliza.Emision.Poliza risk, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datoFijo)
        {
            datoFijo.Terceros = new List<Architect.API.Tron.Contracts.Presupuesto.Tercero>();
            datoFijo.DetalleDeTerceros = new List<Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero>();
            Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero detalle;
            List<Domicilio> detalleDomicilio;
            Architect.API.Tron.Contracts.Presupuesto.Tercero tercero;

            foreach (Domain.Poliza.Emision.Tercero riskThirdParty in risk.Terceros)
            {
                detalleDomicilio = riskThirdParty.domicilio;
                tercero = Architect.API.Tron.Business.Util.Tercero(datoFijo,
                                                             riskThirdParty.tipoDocumentacion.ToString().IdentificationType(),
                                                             riskThirdParty.numeroDocumentacion.DocumentNumber(riskThirdParty.tipoDocumentacion.ToString()),
                                                             Convert.ToInt32(riskThirdParty.tipodetercero), riskThirdParty.numeroderiesgo, riskThirdParty.porcentaje, riskThirdParty.vencimientodecesion, riskThirdParty.importedecesion, riskThirdParty.numerodeprestamo, riskThirdParty.parentesco);
                tercero.num_secu = datoFijo.Terceros.Count() + 1;
                datoFijo.Terceros.Add(tercero);

                detalle = new Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero()
                {
                    cod_cia = datoFijo.cod_cia,
                    fec_tratamiento = DateTime.Today,
                    tip_mvto_batch = "3",
                    tip_docum = riskThirdParty.tipoDocumentacion.ToString().IdentificationType(),
                    cod_docum = riskThirdParty.numeroDocumentacion.DocumentNumber(riskThirdParty.numeroDocumentacion.ToString()),
                    nom_tercero = riskThirdParty.nombre,
                    ape1_tercero = riskThirdParty.apellido1,
                    ape2_tercero = riskThirdParty.apellido2,
                    fec_nacimiento = riskThirdParty.fechadenacimiento,
                    mca_sexo = riskThirdParty.tercerosMca_sexo.ToString(),
                    cod_est_civil = riskThirdParty.estadoCivil,
                    tlf_numero = riskThirdParty.numerodetelefono,
                    cod_pais = Util.StringValue(detalleDomicilio, 1),
                    cod_estado = Util.IntegerValue(detalleDomicilio, 2),
                    cod_prov = Util.IntegerValue(detalleDomicilio, 3),
                    cod_localidad = Util.IntegerValue(detalleDomicilio, 4),
                    nom_domicilio1 = Util.StringValue(detalleDomicilio, 5),
                    titular = (riskThirdParty.tipodetercero == 0),
                    email = riskThirdParty.correoelectronico,
                    cod_act_tercero = int.MinValue,
                    mca_fisico = "S",
                    tip_domicilio = int.MinValue,
                    tip_domicilio_com = int.MinValue,
                    cod_prov_com = int.MinValue,
                    tip_cargo = int.MinValue,
                    tip_act_economica = int.MinValue,
                    cod_ocupacion = int.MinValue,
                    cod_profesion = int.MinValue,
                    tip_etiqueta = int.MinValue,
                    cod_estado_com = int.MinValue,
                    cod_estado_etiqueta = int.MinValue,
                    cod_prov_etiqueta = int.MinValue,
                    tip_tarjeta = int.MinValue,
                    cod_tarjeta = int.MinValue,
                    cod_localidad_com = int.MinValue,
                    cod_localidad_etiqueta = int.MinValue,
                    cod_compensacion = int.MinValue,
                    cod_causa_inh_trc = int.MinValue,
                    cod_exp_carnet_con = int.MinValue
                };
                //Si es tipo de documento es cédula jurídica
                if (detalle.tip_docum == "CJU")
                {
                    detalle.mca_fisico = "N";
                }

                datoFijo.DetalleDeTerceros.Add(detalle);

            }

            return datoFijo;
        }

        private static List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> DatosVariables(Domain.Poliza.Emision.Poliza risk, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datoFijo, Architect.API.Tron.Contracts.Ramo.A1001800 ramo)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> datosVariables = new List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable>();
            Architect.API.Tron.Contracts.Presupuesto.DatoVariable dato;
            foreach (DatosVariables item in risk.Datos_Variables)
            {

                var dv = (from c in ramo.DatosVariables where c.COD_CAMPO == item.nombre select c).FirstOrDefault();

                dato = Architect.API.Tron.Business.Util.DatoVariable(datoFijo, 1, item.nombre, item.valor, dv.TIP_NIVEL, dv.NUM_SECU);

                dato.num_secu = datosVariables.Count() + 1;
                datosVariables.Add(dato);
            }
            return datosVariables;
        }

        private static string TRON_Validate(Domain.Poliza.Emision.Poliza risk, Architect.API.Tron.Contracts.Ramo.A1001800 ramo)
        {
            string result = string.Empty;

            if (risk.Datos_Variables != null)
            {
                Architect.API.Tron.Contracts.Ramo.G2000020 dataVariableDef;

                //Se verifica que los datos variable indicados sean los permitidos por el producto.
                foreach (DatosVariables dato in risk.Datos_Variables)
                {
                    dataVariableDef = (from r in ramo.DatosVariables where r.COD_CAMPO.Equals(dato.nombre, StringComparison.CurrentCultureIgnoreCase) select r).OrderByDescending(x => x.FEC_VALIDEZ).FirstOrDefault();
                    if (dataVariableDef == null)
                    {
                        result += $"El dato variable '{dato.nombre}' no es valido\n";
                    }
                }

                // Se verifica que esten lo datos variables requeridos.
                foreach (Architect.API.Tron.Contracts.Ramo.G2000020 dato in ramo.DatosVariables.Where(r => r.MCA_OBLIGATORIO == "S"))
                {
                    if (!risk.Datos_Variables.Any(r => r.nombre.Equals(dato.COD_CAMPO, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        result += $"El dato variable '{dato.COD_CAMPO}' es requrido\n";
                    }
                }
            }
            if (risk.Coberturas != null)
            {
                Architect.API.Tron.Contracts.Ramo.A1002150 coberturaTron;
                //Se verifica que las coberturas indicadas sean las permitidas por el producto.
                foreach (Domain.Poliza.Emision.Cobertura cobertura in risk.Coberturas)
                {
                    coberturaTron = (from c in ramo.Coberturas where c.COD_COB == cobertura.codigo select c).FirstOrDefault();
                    if (coberturaTron == null)
                    {
                        result += $"La cobertura '{cobertura.codigo}' no es valida\n";
                    }

                }
                // Se verifica que esten las coberturas requeridas.
                foreach (Architect.API.Tron.Contracts.Ramo.A1002150 cobertura in ramo.Coberturas.Where(r => r.MCA_OBLIGATORIO == "S"))
                {
                    if (!risk.Coberturas.Any(r => r.codigo == cobertura.COD_COB))
                    {
                        result += $"La cobertura '{cobertura.COD_COB}' es requrida\n";
                    }
                }
            }

            return result;
        }

    }
}
