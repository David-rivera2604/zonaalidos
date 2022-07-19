using Architect.API.Tron.Contracts.Cotizacion;
using Architect.API.Tron.Contracts.Presupuesto;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;

namespace Architect.API.Tron.Business
{
    internal static class Util
    {

        internal static Contracts.Presupuesto.DatoFijo DatosFijos(Contracts.Cotizacion.GenericQuote quoteInfo, int branch, int agentCode, string userName, int cod_sector)
        {

            //Datos fijos del presupuesto
            Contracts.Presupuesto.DatoFijo datosFijos = new Contracts.Presupuesto.DatoFijo()
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
                fec_efec_poliza = quoteInfo.fec_efec_poliza,
                fec_vcto_poliza = quoteInfo.fec_vcto_poliza,
                fec_efec_spto = DateTime.MinValue,
                fec_vcto_spto = DateTime.MinValue,
                tip_duracion = 0,
                num_riesgos = 0,
                cod_mon = quoteInfo.cod_mon,
                cod_fracc_pago = quoteInfo.cod_fracc_pago,
                cant_renovaciones = 0,
                num_renovaciones = 0,
                tip_coaseguro = 0,
                num_contrato = quoteInfo.num_contrato,
                num_subcontrato = quoteInfo.num_subcontrato,
                num_poliza_grupo = quoteInfo.num_poliza_grupo,
                num_secu_grupo = 0,
                cod_spto = 0,
                sub_cod_spto = 0,
                txt_motivo_spto = string.Empty,
                cod_cuadro_com = 0,
                cod_agt = 0,
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

            if (quoteInfo.num_poliza_grupo.IsNotEmpty())
            {
                datosFijos.num_contrato = quoteInfo.num_contrato;
                datosFijos.num_subcontrato = quoteInfo.num_subcontrato;
                datosFijos.num_poliza_grupo = quoteInfo.num_poliza_grupo;
            }
            else
            {
                datosFijos.num_poliza_grupo = String.Empty;
                datosFijos.num_contrato = int.MinValue;
                datosFijos.num_subcontrato = int.MinValue;
            }


            datosFijos.cod_cuadro_com = 100;
            datosFijos.cod_agt = agentCode;

            datosFijos.txt_motivo_spto = "Cotización realizada desde la zona de aliados, por: " + userName;

            return datosFijos;
        }

        internal static List<Contracts.Presupuesto.Cobertura> Coberturas(Contracts.Cotizacion.GenericQuote quoteInfo, Contracts.Presupuesto.DatoFijo datosFijos, bool includeCapital = false, int num_riesgo = 1)
        {

            List<Contracts.Presupuesto.Cobertura> coberturas = new List<Contracts.Presupuesto.Cobertura>();
            Contracts.Presupuesto.Cobertura currentItem;
            foreach (Contracts.Comun.Cobertura item in from c in quoteInfo.coberturas where c.seleccionado && c.riesgo == 1 select c)
            {
                for (int riesgo = 1; riesgo <= num_riesgo; riesgo++)
                {
                    currentItem = Util.Cobertura(datosFijos, item.codigo, riesgo);
                    if (includeCapital)
                    {
                        currentItem.suma_aseg = item.capital;
                    }
                    coberturas.Add(currentItem);
                }
            }
            return coberturas;
        }

        internal static string Convert_CoverageListToString(List<Contracts.Ramo.G2990026> coverages)
        {
            string result = string.Empty;
            foreach (Contracts.Ramo.G2990026 item in coverages)
            {
                if (result.IsNotEmpty())
                {
                    result += ",";
                }
                result += item.COD_COB;
            }
            return result;
        }

        internal static void ChangeEffectiveDate(Contracts.Presupuesto.DatoFijo quoteTron, Core.Contracts.Security.Token tokenInfo, IDbConnection currentConnection)
        {
            DateTime fecha_efec = quoteTron.fec_efec_poliza;
            DateTime fecha_vec = quoteTron.fec_vcto_poliza;

            if (tokenInfo.Roles.Contain("PolizaGrupo"))
            {
                List<Core.Contracts.General.LookupValues> values = Core.Business.Common.Lkps("MM_POLIZA_GRUPO", $"cod_ramo={quoteTron.cod_ramo}:cod_mon={quoteTron.cod_mon}", tokenInfo);
                Core.Contracts.General.LookupValues contratosMaster = values.Find(x => x.Key == "MM_POLIZA_GRUPO");
                if (contratosMaster != null)
                {
                    Core.Contracts.General.LookupValue contrato = contratosMaster.Lkp.Find(y => y.Code == quoteTron.num_contrato.ToString());
                    if (contrato != null)
                    {
                        string vcto_poliza = (string)contrato["FEC_VCTO_POLIZA"];
                        if (vcto_poliza.IsNotEmpty())
                        {
                            fecha_vec = DateTime.Parse(vcto_poliza, CultureInfo.CreateSpecificCulture("es-CR"));
                        }
                    }
                }
            }

            DataAccess.Batch.P2000030.UpdateEffectiveDate(fecha_efec, fecha_vec, quoteTron.num_poliza, currentConnection);
            DataAccess.Batch.P2000031.UpdateEffectiveDate(fecha_efec, fecha_vec, quoteTron.num_poliza, currentConnection);
        }

        internal static void Ocurrencias(List<Contracts.Presupuesto.DatoVariable> datosVariables, int num_riesgo, string cod_campo_count, Contracts.Presupuesto.DatoFijo datosFijos, string cod_campo, string val_campo)
        {
            if (val_campo.IsNotEmpty())
            {
                datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, cod_campo_count, val_campo.Split(',').Count().ToString()));
                if (datosFijos.Ocurrencias.IsEmpty())
                {
                    datosFijos.Ocurrencias = new List<Contracts.Presupuesto.Ocurrencia>();
                }
                int index = 1;
                foreach (string item in val_campo.Split(','))
                {
                    datosFijos.Ocurrencias.Add(Ocurrencia(datosFijos, index, cod_campo, item));
                    index++;
                }
            }
            else
            {
                datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, cod_campo_count, "0"));
            }
        }

        internal static Contracts.Presupuesto.Ocurrencia Ocurrencia(Contracts.Presupuesto.DatoFijo datosFijos, int num_ocurrencia, string cod_campo, string val_campo, int num_secu = 1, string txt_campo = "")
        {
            Contracts.Presupuesto.Ocurrencia result = new Contracts.Presupuesto.Ocurrencia()
            {
                cod_cia = datosFijos.cod_cia,
                num_poliza = datosFijos.num_poliza,
                num_spto = datosFijos.num_spto,
                num_apli = datosFijos.num_apli,
                num_spto_apli = datosFijos.num_spto_apli,
                num_riesgo = 1,
                num_periodo = 1,
                cod_lista = 0,
                num_ocurrencia = num_ocurrencia,
                num_secu = num_secu,
                cod_campo = cod_campo,
                val_campo = val_campo,
                txt_campo = txt_campo,
                mca_baja_riesgo = "N",
                mca_vigente = "S",
                mca_vigente_apli = "S",
                mca_baja_ocurrencia = "N",
                imp_ocurrencia = 0
            };

            switch (cod_campo)
            {
                case "COD_TIP_BR":
                    result.cod_lista = 206;
                    break;
                case "COD_TIP_MED_INC":
                    result.cod_lista = 200;
                    break;
                case "COD_TIP_MED_BR":
                    result.cod_lista = 201;
                    break;
                case "COD_TIP_MED_ROB":
                    result.cod_lista = 202;
                    break;
                case "COD_TIP_MED_RDM":
                    result.cod_lista = 203;
                    break;

            };

            return result;
        }

        internal static Contracts.Presupuesto.Cobertura Cobertura(Contracts.Presupuesto.DatoFijo datosFijos, int cod_cob, int num_riesgo = 1)
        {
            return new Contracts.Presupuesto.Cobertura()
            {
                cod_cia = datosFijos.cod_cia,
                num_poliza = datosFijos.num_poliza,
                num_spto = datosFijos.num_spto,
                num_apli = datosFijos.num_apli,
                num_spto_apli = datosFijos.num_spto_apli,
                num_riesgo = num_riesgo,
                num_periodo = 1,
                cod_cob = cod_cob,
                cod_ramo = datosFijos.cod_ramo,
                num_secu = 1,
                suma_aseg = 0,
                imp_prima = 0
            };
        }

        internal static Architect.API.Tron.Contracts.Presupuesto.DatoVariable DatoVariable(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, int num_riesgo, string cod_campo, string val_campo, int tip_nivel = 2, int num_secu = 1, string txt_campo = "")
        {
            string val_cor_campo = val_campo;

            if (val_campo.IsNotEmpty() && val_campo.Length > 10)
            {
                val_cor_campo = val_campo.Substring(0, 10);
            }
            return new Contracts.Presupuesto.DatoVariable()
            {
                cod_cia = datosFijos.cod_cia,
                num_poliza = datosFijos.num_poliza,
                num_spto = datosFijos.num_spto,
                num_spto_apli = datosFijos.num_spto_apli,
                num_riesgo = num_riesgo,
                num_periodo = 1,
                tip_nivel = tip_nivel,
                cod_campo = cod_campo.ToUpper(),
                val_campo = val_campo,
                txt_campo = txt_campo,
                val_cor_campo = val_cor_campo,
                num_secu = num_secu,
                cod_ramo = datosFijos.cod_ramo
            };
        }

        internal static List<Contracts.Presupuesto.Riesgo> DatosDelRiesgo(Contracts.Presupuesto.DatoFijo datosFijos, string nom_riesgo, int num_riesgo = 1)
        {
            List<Contracts.Presupuesto.Riesgo> riesgos = new List<Contracts.Presupuesto.Riesgo>();

            for (int i = 1; i <= num_riesgo; i++)
            {
                riesgos.Add(new Contracts.Presupuesto.Riesgo()
                {
                    cod_cia = datosFijos.cod_cia,
                    num_poliza = datosFijos.num_poliza,
                    num_spto = datosFijos.num_spto,
                    num_apli = datosFijos.num_apli,
                    num_spto_apli = datosFijos.num_spto_apli,
                    fec_efec_riesgo = datosFijos.fec_efec_poliza,
                    fec_vcto_riesgo = datosFijos.fec_vcto_poliza,
                    mca_baja_riesgo = "N",
                    mca_vigente = "S",
                    mca_exclusivo = "N",
                    num_riesgo = i,
                    nom_riesgo = nom_riesgo,
                    tip_spto = "XX",
                    cod_modalidad = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_modalidad"])
                });
            }

            return riesgos;
        }

        internal static List<Contracts.Presupuesto.Tercero> Terceros(Contracts.Presupuesto.DatoFijo datosFijos)
        {

            List<Contracts.Presupuesto.Tercero> terceros = new List<Contracts.Presupuesto.Tercero>();
            terceros.Add(Tercero(datosFijos, "CNA", "999999999", 2));
            return terceros;
        }

        internal static Contracts.Presupuesto.Tercero Tercero(Contracts.Presupuesto.DatoFijo datosFijos, string tip_docum, string cod_docum, int tip_benef)
        {
            return new Contracts.Presupuesto.Tercero()
            {
                cod_cia = datosFijos.cod_cia,
                num_poliza = datosFijos.num_poliza,
                num_spto = datosFijos.num_spto,
                num_apli = datosFijos.num_apli,
                num_spto_apli = datosFijos.num_spto_apli,
                num_riesgo = 1,
                tip_benef = tip_benef.ToString(),
                num_secu = 1,
                tip_docum = tip_docum,
                cod_docum = cod_docum,
                mca_principal = "N",
                mca_calculo = "N",
                mca_baja = "N",
                mca_vigente = "S"
            };
        }

        internal static int IdentificationTypeConvert(string identificationType)
        {
            int type = 0;

            switch (identificationType)
            {
                case "CNA": //Cédula
                    type = 1;
                    break;
                case "CRE": //Residencia
                    type = 2;
                    break;
                case "PAS": //Pasaporte
                    type = 3;
                    break;
                case "CJU": //Cédula jurídica
                    type = 4;
                    break;
                    //CIN
                    //EEX
            }

            return type;
        }

        internal static string IdentificationFormat(int identificationType, string documentNumber)
        {
            string result = documentNumber.OnlyNumbers();

            switch (identificationType)
            {
                case 1: //Cédula
                    result = result.Substring(1);
                    break;
                case 2: //Residencia
                    result = result.Substring(1);
                    break;
                case 3: //Pasaporte
                    result = result.Substring(1);
                    break;
                case 4: //Cédula jurídica
                    result = result;
                    break;
                    //CIN
                    //EEX
            }

            return result;
        }


        internal static Contracts.Cotizacion.GenericQuote GenericInfo_FromTron(Contracts.Presupuesto.DatoFijo tronQuoteInfo, Contracts.Cotizacion.GenericQuote quote)
        {
            quote.cod_ramo = tronQuoteInfo.cod_ramo;
            quote.presupuesto = tronQuoteInfo.num_poliza;
            quote.cod_mon = tronQuoteInfo.cod_mon;
            quote.cod_fracc_pago = tronQuoteInfo.cod_fracc_pago;
            quote.fec_efec_poliza = tronQuoteInfo.fec_efec_poliza;
            quote.fec_vcto_poliza = tronQuoteInfo.fec_vcto_poliza;
            quote.coberturas = Coberturas_FromTron(tronQuoteInfo);
            quote.plandepago = Recibo_FromTron(tronQuoteInfo);
            quote.resumen = Resumen_FromTron(tronQuoteInfo);

            return quote;
        }

        internal static List<Contracts.Comun.PlanDePago> Recibo_FromTron(DatoFijo tronQuoteInfo)
        {
            double importeAnual;
            List<Contracts.Comun.PlanDePago> plandepago = new List<Contracts.Comun.PlanDePago>();

            foreach (Contracts.Presupuesto.Recibo item in tronQuoteInfo.Recibos)
            {
                importeAnual = item.imp_recibo;
                plandepago.Add(new Contracts.Comun.PlanDePago()
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
            return plandepago;
        }

        internal static Contracts.Cotizacion.resumen Resumen_FromTron(DatoFijo tronQuoteInfo)
        {
            bool setvalues = true;
            Contracts.Cotizacion.resumen resumen = new Contracts.Cotizacion.resumen();

            foreach (Contracts.Presupuesto.Recibo item in tronQuoteInfo.Recibos)
            {
                if (setvalues)
                {
                    resumen = new Contracts.Cotizacion.resumen()
                    {
                        cuotas = tronQuoteInfo.Recibos.Count,
                        primaneta = item.imp_neta + item.imp_recargo,
                        iVA = item.imp_imptos,
                        recargoporfraccionamiento = item.imp_interes,
                        importetotal = item.imp_recibo
                    };
                    setvalues = false;
                }
            }
            return resumen;
        }

        internal static List<Contracts.Comun.Cobertura> Coberturas_FromTron(Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            List<Contracts.Comun.Cobertura> result = new List<Contracts.Comun.Cobertura>();
            foreach (Contracts.Presupuesto.Cobertura item in tronQuoteInfo.Coberturas.OrderBy(r => r.num_riesgo).ThenBy(p => p.cod_cob))
            {
                result.Add(new Contracts.Comun.Cobertura()
                {
                    seleccionado = true,
                    requerida = true,
                    riesgo = item.num_riesgo,
                    codigo = item.cod_cob,
                    nombre = item.nom_cob,
                    capital = item.suma_aseg,
                    primatotal = item.imp_total,
                    deducible = item.nom_franquicia
                });
            }
            return result;
        }

        internal static Contracts.Cotizacion.GenericQuote FromTron_CoberturasResult(Contracts.Cotizacion.GenericQuote quoteInfo, Contracts.Presupuesto.DatoFijo tronQuoteInfo, int cod_fracc_pago_anual, bool multiRiesgo = false)
        {

            if (tronQuoteInfo.Coberturas != null)
            {
                if (tronQuoteInfo.Coberturas?.Count == 1)
                {
                    quoteInfo.Error = tronQuoteInfo.Coberturas[0].txt_error;
                }
                if (multiRiesgo)
                {
                    quoteInfo.coberturas = new List<Contracts.Comun.Cobertura>();
                    foreach (Contracts.Presupuesto.Cobertura item in tronQuoteInfo.Coberturas.OrderBy(r => r.num_riesgo).ThenBy(p => p.cod_cob))
                    {
                        quoteInfo.coberturas.Add(new Contracts.Comun.Cobertura()
                        {
                            seleccionado = true,
                            riesgo = item.num_riesgo,
                            codigo = item.cod_cob,
                            nombre = item.nom_cob,
                            capital = item.suma_aseg,
                            primatotal = item.imp_total,
                            deducible = item.nom_franquicia,
                            error = item.txt_error
                        });
                        if (quoteInfo.presupuesto.IsEmpty())
                        {
                            quoteInfo.presupuesto = item.num_poliza;
                        }
                    }
                }
                else
                {
                    foreach (Contracts.Presupuesto.Cobertura item in tronQuoteInfo.Coberturas.OrderBy(r => r.num_riesgo).ThenBy(p => p.cod_cob))
                    {
                        foreach (Contracts.Comun.Cobertura itemQuote in quoteInfo.coberturas)
                        {
                            if (item.cod_cob == itemQuote.codigo)
                            {
                                itemQuote.seleccionado = true;

                                itemQuote.riesgo = item.num_riesgo;
                                itemQuote.codigo = item.cod_cob;
                                itemQuote.nombre = item.nom_cob;
                                itemQuote.capital = item.suma_aseg;
                                itemQuote.primatotal = item.imp_total;
                                itemQuote.deducible = item.nom_franquicia;
                                itemQuote.error = item.txt_error;
                                if (quoteInfo.presupuesto.IsEmpty())
                                {
                                    quoteInfo.presupuesto = item.num_poliza;
                                }
                                break;
                            }
                            else if (!itemQuote.seleccionado)
                            {
                                itemQuote.capital = 0;
                                itemQuote.primatotal = 0;
                                itemQuote.deducible = string.Empty;
                                itemQuote.error = string.Empty;
                            }
                        }
                    }
                }
            }

            if (tronQuoteInfo.Recibos != null)
            {
                double importeAnual = 0;
                bool setvalues = true;
                quoteInfo.plandepago = new List<Contracts.Comun.PlanDePago>();
                foreach (Contracts.Presupuesto.Recibo item in tronQuoteInfo.Recibos)
                {
                    importeAnual = item.imp_recibo;
                    quoteInfo.plandepago.Add(new Contracts.Comun.PlanDePago()
                    {
                        cuota = item.num_cuota,
                        fechadesde = item.fec_efec_recibo,
                        fechahasta = item.fec_vcto_recibo,
                        primaneta = item.imp_neta + item.imp_recargo,
                        iVA = item.imp_imptos,
                        recargoporfraccionamiento = item.imp_interes,
                        importetotal = item.imp_recibo
                    });
                    if (setvalues)
                    {
                        quoteInfo.resumen = new Contracts.Cotizacion.resumen()
                        {
                            cuotas = tronQuoteInfo.Recibos.Count,
                            primaneta = item.imp_neta + item.imp_recargo,
                            iVA = item.imp_imptos,
                            recargoporfraccionamiento = item.imp_interes,
                            importetotal = item.imp_recibo
                        };
                        setvalues = false;
                    }
                }

                if (quoteInfo.cod_fracc_pago == cod_fracc_pago_anual)
                {
                    double amount;
                    quoteInfo.plandepagoporfrecuencia = new List<Contracts.Cotizacion.plandepagoporfrecuencia>();
                    foreach (Contracts.Ramo.A1001403 item in DataAccess.PorRamo.FrecuenciaDePago(tronQuoteInfo.cod_cia, tronQuoteInfo.cod_ramo, tronQuoteInfo.cod_mon))
                    {
                        amount = (importeAnual / item.cod_fracc_pago) + ((importeAnual / item.cod_fracc_pago) * (item.pct_fracc_pago / 100));
                        quoteInfo.plandepagoporfrecuencia.Add(new Contracts.Cotizacion.plandepagoporfrecuencia()
                        {
                            codigo = item.cod_fracc_pago,
                            frecuencia = item.nom_fracc_pago,
                            recardoporfraccionamiento = item.pct_fracc_pago,
                            importetotal = amount
                        });
                    }
                }

            }

            // RANGO DE MESES DEBE ESTAR ENTRE 1 Y 12 MESES &lt;COB_PDR_MESES&gt;</txt_error>
            if (tronQuoteInfo.DatosDelProceso != null && tronQuoteInfo.DatosDelProceso.txt_error.IsNotEmpty())
            {
                quoteInfo.Error = tronQuoteInfo.DatosDelProceso.txt_error;
            }
            if (quoteInfo.Error != null)
            {
                quoteInfo.Mensaje = quoteInfo.Error;
                if (quoteInfo.Mensaje.StartsWith("ORA-", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (quoteInfo.Mensaje.IndexOf(':') > 0)
                    {
                        quoteInfo.Mensaje = quoteInfo.Mensaje.Substring(quoteInfo.Mensaje.IndexOf(':') + 1).Trim();
                    }
                    quoteInfo.Mensaje = quoteInfo.Mensaje.Substring(0, 1).ToUpper() + quoteInfo.Mensaje.Substring(1).ToLower();
                }
            }

            return quoteInfo;
        }


        internal static List<Contracts.Presupuesto.Tercero> Terceros_ToTron(List<Contracts.Comun.tercero> terceros, Contracts.Presupuesto.DatoFijo datosFijos, bool expanded)
        {
            datosFijos.Terceros = new List<Contracts.Presupuesto.Tercero>();
            datosFijos.DetalleDeTerceros = new List<Contracts.Presupuesto.DetalleDeTercero>();

            foreach (Contracts.Comun.tercero item in terceros)
            {
                if (item.tipodetercero != 0)
                {
                    datosFijos.Terceros.Add(TerceroPresupuesto(datosFijos, item, item.tipodetercero));
                }
                else
                {
                    if (!expanded && item.eltomadoreselmismoasegurado == 1)
                    {
                        datosFijos.Terceros.Add(TerceroPresupuesto(datosFijos, item, 2));
                    }
                    if (!expanded && item.elaseguradoeselconductorhabitual == 1)
                    {
                        datosFijos.Terceros.Add(TerceroPresupuesto(datosFijos, item, 3));
                    }
                }


                datosFijos.DetalleDeTerceros.Add(CambioTerceroPresupuesto(datosFijos, item));
            }


            return datosFijos.Terceros;
        }

        internal static Contracts.Presupuesto.Tercero TerceroPresupuesto(Contracts.Presupuesto.DatoFijo datosFijos, Contracts.Comun.tercero item, int tipodetercero)
        {
            Contracts.Presupuesto.Tercero result = new Contracts.Presupuesto.Tercero()
            {
                cod_cia = datosFijos.cod_cia,
                num_poliza = datosFijos.num_poliza,
                num_spto = datosFijos.num_spto,
                num_apli = datosFijos.num_apli,
                num_spto_apli = datosFijos.num_spto_apli,
                num_riesgo = 1,
                tip_benef = tipodetercero.ToString(),
                num_secu = 1,
                tip_docum = item.DocumentNumberType.ToString().IdentificationType(),
                cod_docum = Util.IdentificationFormat(item.DocumentNumberType, item.DocumentNumber),
                mca_principal = "N",
                mca_calculo = "N",
                mca_baja = "N",
                mca_vigente = "S",
                pct_participacion = 0,
                imp_cesion = 0
            };

            switch (tipodetercero)

            {
                case 0: //Titular.
                    result.tip_benef = "2"; //Asegurado
                    break;
                case 3: //Conductor Habitual.
                    result.mca_principal = "S";
                    break;
                case 6: //Beneficiario pero esta opción no esta disponible al día de hoy.
                    result.tip_relac = item.parentesco.ToString();
                    result.pct_participacion = item.porcentaje;
                    break;
                case 8: //Acredor.
                    result.fec_vcto_cesion = item.vencimientodecesion;
                    result.imp_cesion = item.importedecesion;
                    result.num_prestamo = item.numerodeprestamo;
                    result.pct_participacion = item.porcentajeacredor;
                    break;

            }

            return result;
        }

        internal static Contracts.Presupuesto.DetalleDeTercero CambioTerceroPresupuesto(Contracts.Presupuesto.DatoFijo datosFijos, Contracts.Comun.tercero item)
        {
            Contracts.Presupuesto.DetalleDeTercero result = new Contracts.Presupuesto.DetalleDeTercero()
            {
                cod_cia = datosFijos.cod_cia,
                fec_tratamiento = DateTime.Today,
                tip_mvto_batch = "3",
                tip_docum = item.DocumentNumberType.ToString().IdentificationType(),
                cod_docum = Util.IdentificationFormat(item.DocumentNumberType, item.DocumentNumber),
                nom_tercero = item.nombre,
                ape1_tercero = item.apellido1,
                ape2_tercero = item.apellido2,
                fec_nacimiento = item.fechadenacimiento,
                mca_sexo = item.tercerosMca_sexo.ToString(),
                cod_est_civil = item.estadoCivil,
                tlf_numero = item.numerodetelefono,
                cod_pais = item.cod_pais,
                cod_estado = item.TProvincia,
                cod_prov = item.TCanton,
                cod_localidad = item.TDistrito,
                nom_domicilio1 = item.otrasenas,
                titular = (item.tipodetercero == 0),
                email = item.correoelectronico,

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
            //Si es tipo de documento es cedula jurida
            if (result.tip_docum == "CJU")
            {
                result.mca_fisico = "N";
            }
            return result;
        }

    }
}
