using Aliados.Monge.Domain.Poliza.Emision;
using Architect.API.Tron.Business.Cotizacion;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Application.Poliza.Ramos
{
    internal class Viajero
    {

        internal static async Task<Domain.Poliza.Emision.Respuesta> Handler(Domain.Poliza.Emision.Poliza risk, Architect.API.Core.Contracts.Security.Token tokenInfo)
        {
            Domain.Poliza.Emision.Respuesta result;
            int trackingId = Traza.TrackRequest.Add(tokenInfo.CompanyId, tokenInfo.UserId,
                                         new Domain.Traza.TrackRequest()
                                         {
                                             DocumentId = risk.document_id,
                                             RequestType = "Emision",
                                             RequestBody = Newtonsoft.Json.JsonConvert.SerializeObject(risk),
                                             RequestTimeStamp = DateTime.Now
                                         }).Id;

            try
            {

                string cod_producto = risk.Datos_Generales.cod_producto;
                int cod_ramo = Convert.ToInt32(cod_producto.Substring(0, cod_producto.IndexOf("-")));

                Architect.API.Tron.Contracts.Cotizacion.Viajero quote = MapperBase(risk);

                Architect.API.Tron.Contracts.Presupuesto.DatoFijo result2 = ViajeroConvert.ToTron(quote, cod_ramo, tokenInfo.AgentCode, tokenInfo.UserName, tokenInfo.CompanyId);
                result2 = MapperTerceros(risk, result2);

                result2.tip_docum = result2.Terceros.FirstOrDefault().tip_docum;
                result2.cod_docum = result2.Terceros.FirstOrDefault().cod_docum;

                result2 = Architect.API.Tron.Business.Backoffice.Cotizacion.Generico.Calcular(result2, 3, "Riesgo emitido desde ZA Web");
                if (result2.DatosDelProceso.txt_error == "")
                {

                    Architect.API.Tron.Contracts.Poliza.DatoFijo polizaEmitida = null;
                    polizaEmitida = Architect.API.Tron.Business.Backoffice.Common.InformacionDePoliza(result2.DatosDelProceso.num_poliza_definitivo);

                    ///Conviert el objeto risk del request a un objeto de la emisión
                    Architect.API.Tron.Contracts.Emision.Viajero viajeroAliadosEmision = Newtonsoft.Json.JsonConvert.DeserializeObject<Architect.API.Tron.Contracts.Emision.Viajero>(Newtonsoft.Json.JsonConvert.SerializeObject(quote));

                    viajeroAliadosEmision = Architect.API.Tron.Business.Emision.ViajeroConvertFrom.Quote(viajeroAliadosEmision, polizaEmitida);
                    ConvertEmisionTercerto_ComunTercero(risk, viajeroAliadosEmision);

                    Architect.API.Tron.Business.Emision.Viajero.Asistencia_Panama(viajeroAliadosEmision, viajeroAliadosEmision, tokenInfo.Roles);

                    result = new Domain.Poliza.Emision.Respuesta()
                    {
                        message_status = 200,
                        message_text = "Emisión exitosa",
                        message_id = Guid.NewGuid().ToString(),
                        document_id = risk.document_id,
                        message_body = new Domain.Poliza.Emision.RespuestaDetalle()
                        {
                            num_poliza = result2.DatosDelProceso.num_poliza_definitivo,
                            num_certificado_phx = "",
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

            Traza.TrackRequest.Update(tokenInfo.CompanyId, tokenInfo.UserId, trackingId,
                                      new Domain.Traza.TrackRequest()
                                      {
                                          MessageId = result.message_id,
                                          ResponseStatus = result.message_status,
                                          ResponseText = result.message_text,
                                          ResponseBody = Newtonsoft.Json.JsonConvert.SerializeObject(result),
                                          ResponseTimeStamp = DateTime.Now
                                      });
            return result;
        }

        private static Architect.API.Tron.Contracts.Cotizacion.Viajero MapperBase(Domain.Poliza.Emision.Poliza risk)
        {
            List<Domain.Poliza.Emision.DatosVariables> datosvariables = risk.Datos_Variables;

            string cod_producto = risk.Datos_Generales.cod_producto;
            string tip_viaje = cod_producto.Substring(cod_producto.IndexOf("-") + 1, 1);
            string tip_plan = cod_producto.Substring(cod_producto.IndexOf("-") + 2, 1);
            int cantidadRiesgos = risk.Terceros.Where(c => c.tipodetercero == 2).Max(r => r.numeroderiesgo);

            Architect.API.Tron.Contracts.Cotizacion.Viajero quote = new Architect.API.Tron.Contracts.Cotizacion.Viajero()
            {
                cod_mon = risk.Datos_Generales.moneda,
                cod_fracc_pago = risk.Datos_Generales.cod_fracc_pago,
                fec_efec_poliza = risk.Datos_Generales.fec_efec_poliza,
                fec_vcto_poliza = risk.Datos_Generales.fec_vcto_poliza,
                TIP_PLAN = tip_plan,
                TIP_VIAJE = tip_viaje,
                FEC_VIAJE = risk.Datos_Generales.fec_efec_poliza,
                DES_DESTINO = Util.StringValue(datosvariables, "DES_DESTINO"),
                COD_PAIS_ORIGEN = Util.StringValue(datosvariables, "ORI_ORIGEN", "CRI"),
                COD_MODALIDAD = risk.Datos_Generales.cod_modalidad,
                cantidad_riesgos = cantidadRiesgos,
                coberturas = new List<Architect.API.Tron.Contracts.Comun.Cobertura>()
            };

            MapperFechaDeNacimientoAsegurados(risk, quote);

            MapperCoberturas(risk, quote);

            return quote;
        }
        private static Architect.API.Tron.Contracts.Presupuesto.DatoFijo MapperTerceros(Domain.Poliza.Emision.Poliza risk, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datoFijo)
        {
            datoFijo.Terceros = new List<Architect.API.Tron.Contracts.Presupuesto.Tercero>();
            datoFijo.DetalleDeTerceros = new List<Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero>();
            Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero detalle;
            List<Domicilio> detalleDomicilio;

            foreach (Domain.Poliza.Emision.Tercero riskThirdParty in risk.Terceros)
            {
                detalleDomicilio = riskThirdParty.domicilio;
                datoFijo.Terceros.Add(
                    Architect.API.Tron.Business.Util.Tercero(datoFijo,
                                                             riskThirdParty.tipoDocumentacion.ToString().IdentificationType(),
                                                             riskThirdParty.numeroDocumentacion.DocumentNumber(riskThirdParty.tipoDocumentacion.ToString()),
                                                             Convert.ToInt32(riskThirdParty.tipodetercero), riskThirdParty.numeroderiesgo, riskThirdParty.porcentaje, riskThirdParty.vencimientodecesion, riskThirdParty.importedecesion, riskThirdParty.numerodeprestamo, riskThirdParty.parentesco));

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

        private static void ConvertEmisionTercerto_ComunTercero(Domain.Poliza.Emision.Poliza risk, Architect.API.Tron.Contracts.Emision.Viajero data2)
        {
            data2.terceros = new List<Architect.API.Tron.Contracts.Comun.tercero>();
            List<Domicilio> detalleDomicilio;
            foreach (Domain.Poliza.Emision.Tercero riskThirdParty in risk.Terceros)
            {
                detalleDomicilio = riskThirdParty.domicilio;
                data2.terceros.Add(new Architect.API.Tron.Contracts.Comun.tercero()
                {
                    tercerosId = 0,
                    tipodetercero = riskThirdParty.tipodetercero,
                    tipodeterceroDesc = "",
                    DocumentNumberType = riskThirdParty.tipoDocumentacion,
                    DocumentNumber = riskThirdParty.numeroDocumentacion,
                    nombre = riskThirdParty.nombre,
                    apellido1 = riskThirdParty.apellido1,
                    apellido2 = riskThirdParty.apellido2,
                    fechadenacimiento = riskThirdParty.fechadenacimiento,
                    tercerosMca_sexo = Convert.ToInt32(riskThirdParty.tercerosMca_sexo),
                    tercerosMca_sexoDesc = "",
                    estadoCivil = riskThirdParty.estadoCivil,
                    estadoCivilDesc = "",
                    numerodetelefono = riskThirdParty.numerodetelefono,
                    correoelectronico = riskThirdParty.correoelectronico,
                    cod_pais = Util.StringValue(detalleDomicilio, 1),
                    TProvincia = Util.IntegerValue(detalleDomicilio, 2),
                    TProvinciaDesc = "",
                    TCanton = Util.IntegerValue(detalleDomicilio, 3),
                    TCantonDesc = "",
                    TDistrito = Util.IntegerValue(detalleDomicilio, 4),
                    TDistritoDesc = "",
                    otrasenas = Util.StringValue(detalleDomicilio, 5),
                    eltomadoreselmismoasegurado = 2,
                    elaseguradoeselmismotomador = 2,
                    elaseguradoeselconductorhabitual = 2,
                    numerodeprestamo = riskThirdParty.numerodeprestamo,
                    importedecesion = riskThirdParty.importedecesion,
                    vencimientodecesion = riskThirdParty.vencimientodecesion,
                    porcentajeacredor = riskThirdParty.porcentajeacredor,
                    parentesco = Convert.ToInt32(riskThirdParty.parentesco),
                    parentescoDesc = "",
                    porcentaje = riskThirdParty.porcentaje,
                    NoEditable = false,
                    numeroderiesgo = riskThirdParty.numeroderiesgo,
                    elbeneficiarioeselmismotodoslosriesgos = 2,
                    reutilizarestadireccion = false
                });
            }
        }

        private static void MapperCoberturas(Domain.Poliza.Emision.Poliza risk, Architect.API.Tron.Contracts.Cotizacion.Viajero quote)
        {
            if (risk.Coberturas == null || risk.Coberturas.Count == 0)
            {
                quote.coberturas.Add(new Architect.API.Tron.Contracts.Comun.Cobertura() { codigo = 4457 });
                quote.coberturas.Add(new Architect.API.Tron.Contracts.Comun.Cobertura() { codigo = 4460 });
            }
            else
            {
                foreach (Domain.Poliza.Emision.Cobertura riskCover in risk.Coberturas)
                {
                    quote.coberturas.Add(new Architect.API.Tron.Contracts.Comun.Cobertura() { codigo = riskCover.codigo });
                }
            }
        }

        private static void MapperFechaDeNacimientoAsegurados(Domain.Poliza.Emision.Poliza risk, Architect.API.Tron.Contracts.Cotizacion.Viajero quote)
        {
            foreach (Tercero item in risk.Terceros?.Where(c => c.tipodetercero == 2))
            {
                switch (item.numeroderiesgo)
                {
                    case 1:
                        quote.FEC_NACIMIENTO = item.fechadenacimiento;
                        break;
                    case 2:
                        quote.FEC_NACIMIENTO2 = item.fechadenacimiento;
                        break;
                    case 3:
                        quote.FEC_NACIMIENTO3 = item.fechadenacimiento;
                        break;
                    case 4:
                        quote.FEC_NACIMIENTO4 = item.fechadenacimiento;
                        break;
                    case 5:
                        quote.FEC_NACIMIENTO5 = item.fechadenacimiento;
                        break;
                    case 6:
                        quote.FEC_NACIMIENTO6 = item.fechadenacimiento;
                        break;
                    case 7:
                        quote.FEC_NACIMIENTO7 = item.fechadenacimiento;
                        break;
                    case 8:
                        quote.FEC_NACIMIENTO8 = item.fechadenacimiento;
                        break;
                    case 9:
                        quote.FEC_NACIMIENTO9 = item.fechadenacimiento;
                        break;
                    case 10:
                        quote.FEC_NACIMIENTO10 = item.fechadenacimiento;
                        break;
                }

            }
        }


    }
}
