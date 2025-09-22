using Architect.API.Tron.Contracts.Comun;
using Architect.API.Tron.Contracts.Ramo;
using Architect.API.Tron.Contracts.Variaciones;
using Architect.API.Tron.DataAccess.Variaciones;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Tron.Business.Variaciones
{
    internal static class MultirriesgoConvertFrom
    {
        internal static Contracts.Variaciones.Multirriesgo Quote(Contracts.Poliza.DatoFijo tronQuoteInfo)
        {
            Contracts.Variaciones.Multirriesgo quoteInfo = new Contracts.Variaciones.Multirriesgo()
            {
                cod_cia = tronQuoteInfo.cod_cia,
                cod_ramo = tronQuoteInfo.cod_ramo,
                num_poliza = tronQuoteInfo.num_poliza,
                cod_mon = tronQuoteInfo.cod_mon,
                cod_fracc_pago = tronQuoteInfo.cod_fracc_pago,
                fec_efec_poliza = tronQuoteInfo.fec_efec_poliza,
                fec_vcto_poliza = tronQuoteInfo.fec_vcto_poliza,
                contrato = tronQuoteInfo.num_contrato,
                subcontrato = tronQuoteInfo.num_subcontrato,
                polizagrupo = tronQuoteInfo.num_poliza_grupo,
                MCA_FEC_EFEC_SYS = "N",
                cod_agt = tronQuoteInfo.cod_agt,
                cod_cuadro_com = tronQuoteInfo.cod_cuadro_com,
                coberturas = new List<Contracts.Comun.Cobertura>(),
                Riesgos = tronQuoteInfo.Riesgos,
                Ocurrencias = tronQuoteInfo.Ocurrencias
            };

            quoteInfo = DatosVariables(quoteInfo, tronQuoteInfo);

            foreach (Contracts.Poliza.Cobertura item in tronQuoteInfo.Coberturas)
            {
                quoteInfo.coberturas.Add(new Contracts.Comun.Cobertura()
                {
                    seleccionado = true,
                    requerida = false,
                    codigo = item.cod_cob,
                    nombre = item.nom_cob,
                    capital = item.suma_aseg,
                    primatotal = item.imp_total,
                    deducible = item.deducible,
                    riesgo = item.num_riesgo
                });
                //switch (item.cod_cob)
                //{
                //    case 3005:
                //        if (quoteInfo.IMP_AUTO_RAD.IsEmpty())
                //        {
                //            quoteInfo.IMP_AUTO_RAD = item.suma_aseg;
                //        }
                //        break;
                //    case 3006:
                //        if (quoteInfo.IMP_AUTO_ROB.IsEmpty())
                //        {
                //            quoteInfo.IMP_AUTO_ROB = item.suma_aseg;
                //        }
                //        break;
                //    case 3009:
                //        if (quoteInfo.IMP_AUTO_CRI.IsEmpty())
                //        {
                //            quoteInfo.IMP_AUTO_CRI = Convert.ToInt32(item.suma_aseg);
                //        }
                //        break;
                //    case 3007:
                //        if (quoteInfo.IMP_AUTO_EQESP.IsEmpty())
                //        {
                //            quoteInfo.IMP_AUTO_EQESP = Convert.ToInt32(item.suma_aseg);
                //        }
                //        break;
                //}
            }


            return DatosVariables(quoteInfo, tronQuoteInfo);
        }

        private static Contracts.Variaciones.Multirriesgo DatosVariables(Contracts.Variaciones.Multirriesgo quoteInfo, Architect.API.Tron.Contracts.Poliza.DatoFijo tronQuoteInfo)
        {
            foreach (Contracts.Poliza.DatoVariable item in tronQuoteInfo.DatosVariables)
            {
                switch (item.cod_campo)
                {
                    case "COD_PAIS": //	PAÍS
                        quoteInfo.cod_pais = item.val_campo;
                        break;
                    case "COD_ESTADO": // PROVINCIA
                        quoteInfo.cod_estado = Convert.ToInt32(item.val_campo);
                        break;
                    case "COD_PROV": // CANTÓN
                        quoteInfo.cod_prov = Convert.ToInt32(item.val_campo);
                        break;
                    case "COD_LOCALIDAD": // DISTRITO
                        quoteInfo.cod_localidad = Convert.ToInt32(item.val_campo);
                        break;
                    case "NUM_PISOS_EDIF": // NÚMERO DE PISOS EDIFICACIÓN
                        quoteInfo.num_pisos_edif = Convert.ToInt32(item.val_campo);
                        break;
                    case "COD_TIPO_ESTRUC": // TIPO DE ESTRUC DE LA EDIFICACI
                        quoteInfo.cod_tipo_estruc = Convert.ToInt32(item.val_campo);
                        break;
                    case "COD_TIPO_TECHO": // TIPO DE TECHO DE EDIFICACIÓN
                        quoteInfo.cod_tipo_techo = Convert.ToInt32(item.val_campo);
                        break;
                    case "COD_TIPO_PARED": // TIPO DE PARED DE EDIFICACIÓN
                        quoteInfo.cod_tipo_pared = Convert.ToInt32(item.val_campo);
                        break;
                    case "OTRA_SENAS_RGO1": // OTRAS SEÑAS DEL RIESGO
                        quoteInfo.otrassenasdelriesgo = item.val_campo;
                        break;
                    case "COD_TIP_EDIF": // TIPO DE EDIFICACIÓN
                        quoteInfo.cod_tip_edit = Convert.ToInt32(item.val_campo);
                        break;
                    case "MCA_EXTIN_INC": // ¿POSEE EXTINTORES DE INCENDIO?
                        quoteInfo.MCA_EXTIN_INC = item.val_campo == "S" ? 1 : 2;
                        break;
                    case "NUM_EXTIN_INC": // CUANTOS EXTINTORES DE INCENDIO
                        quoteInfo.NUM_EXTIN_INC = Convert.ToInt32(item.val_campo);
                        break;
                    case "COD_TIP_RGO_IDN": // TIP DE RIESG POR INTER DE NEG
                        quoteInfo.cod_tip_rgo_idn = Convert.ToInt32(item.val_campo);
                        break;
                    case "COD_TIPO_OCUP_RGO": // OCUPACIÓN DEL RIESGO
                        quoteInfo.cod_tip_ocup = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_EDIFICIO": // S.A. EDIFICIO
                        quoteInfo.IMP_EDIFICIO = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_MOBILIARIO": // S.A. MOBILIARIO
                        quoteInfo.IMP_MOBILIARIO = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_MERCADERIA": // S.A. MERCADERÍA
                        quoteInfo.IMP_MERCADERIA = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_BIE_TEM_DES": // S.A. BIENES TEMPO. DESP.
                        quoteInfo.IMP_BIE_TEM_DES = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_BIE_INT": // S.A. BIENES A LA INTERPERIE
                        quoteInfo.IMP_BIE_INT = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_OBJ_ESP_VAL": // S.A. OBJETOS DE ESPECIAL VALOR
                        quoteInfo.IMP_OBJ_ESP_VAL = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_MAQUINARIA": // S.A. MAQUINARIA
                        quoteInfo.IMP_MAQUINARIA = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_EQUIP_ELEC": // S.A. EQUIPOS ELECT. (NO MÓVIL)
                        quoteInfo.IMP_EQUIP_ELEC = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_EQUIP_ELEC_M": // S.A. EQUIPOS ELECT. (MÓVIL)
                        quoteInfo.IMP_EQUIP_ELEC_M = Convert.ToInt32(item.val_campo);
                        break;
                    case "NUM_MED_INC": // ¿# MEDIDAS CONTRA INCENDIOS?
                        if (Convert.ToInt32(item.val_campo) > 0 && tronQuoteInfo.Ocurrencias?.Count > 0)
                        {
                            foreach (Contracts.Poliza.Ocurrencia ocurrencia in from t in tronQuoteInfo.Ocurrencias where t.cod_campo == "COD_TIP_MED_INC" orderby t.num_ocurrencia select t)
                            {
                                if (quoteInfo.cod_tip_med_inc.IsNotEmpty())
                                {
                                    quoteInfo.cod_tip_med_inc += ",";
                                }
                                quoteInfo.cod_tip_med_inc += ocurrencia.val_campo;
                            }
                        }
                        break;
                    case "NUM_MED_ROB": // ¿# MEDIDAS SEGURIDAD ROBO?
                        if (Convert.ToInt32(item.val_campo) > 0 && tronQuoteInfo.Ocurrencias?.Count > 0)
                        {
                            quoteInfo.cod_tip_med_rob = string.Empty;
                            foreach (Contracts.Poliza.Ocurrencia ocurrencia in from t in tronQuoteInfo.Ocurrencias where t.cod_campo == "COD_TIP_MED_ROB" orderby t.num_ocurrencia select t)
                            {
                                if (quoteInfo.cod_tip_med_rob.IsNotEmpty())
                                {
                                    quoteInfo.cod_tip_med_rob += ",";
                                }
                                quoteInfo.cod_tip_med_rob += ocurrencia.val_campo;
                            }
                        }
                        break;
                    case "IMP_DOMOS_TOTAL": // S.A. DOMO,CRISTAL,MÁRMOL,GRAN.
                        quoteInfo.IMP_DOMOS_TOTAL = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_GAS_ALQ": // S.A. GASTOS DE ALQUILER
                        quoteInfo.IMP_GAS_ALQ = Convert.ToInt32(item.val_campo);
                        break;
                    case "COB_PDR_MESES": // MESES A AMPARAR POR PERD RENTA
                        quoteInfo.COB_PDR_MESES = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_PER_REN": // S.A. PÉRDIDA DE RENTAS
                        quoteInfo.IMP_PER_REN = Convert.ToInt32(item.val_campo);
                        break;
                    case "NUM_MED_BR": // ¿# MEDIDAS PARA BIENES REFRI.?
                        if (Convert.ToInt32(item.val_campo) > 0 && tronQuoteInfo.Ocurrencias?.Count > 0)
                        {
                            quoteInfo.cod_tip_med_rob = string.Empty;
                            foreach (Contracts.Poliza.Ocurrencia ocurrencia in from t in tronQuoteInfo.Ocurrencias where t.cod_campo == "COD_TIP_MED_BR" orderby t.num_ocurrencia select t)
                            {
                                if (quoteInfo.cod_tip_med_rob.IsNotEmpty())
                                {
                                    quoteInfo.cod_tip_med_rob += ",";
                                }
                                quoteInfo.cod_tip_med_rob += ocurrencia.val_campo;
                            }
                        }
                        break;
                    case "IMP_MER_TRA": // S.A. MERCANCÍA EN TRÁNSITO
                        quoteInfo.IMP_MER_TRA = Convert.ToInt32(item.val_campo);
                        break;
                    case "NUM_MED_RDM": // ¿# MEDIDAS PARA ROT. DE MAQ.?
                        if (Convert.ToInt32(item.val_campo) > 0 && tronQuoteInfo.Ocurrencias?.Count > 0)
                        {
                            quoteInfo.cod_tip_med_rdm = string.Empty;
                            foreach (Contracts.Poliza.Ocurrencia ocurrencia in from t in tronQuoteInfo.Ocurrencias where t.cod_campo == "COD_TIP_MED_RDM" orderby t.num_ocurrencia select t)
                            {
                                if (quoteInfo.cod_tip_med_rdm.IsNotEmpty())
                                {
                                    quoteInfo.cod_tip_med_rdm += ",";
                                }
                                quoteInfo.cod_tip_med_rdm += ocurrencia.val_campo;
                            }
                        }
                        break;
                    case "COB_IDN_MESES": // MESES A AMPARAR X INTE DE NEG
                        quoteInfo.COB_IDN_MESES = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_INT_NEG": // S.A. INTERRUPCIÓN DE NEGOCIOS
                        quoteInfo.IMP_INT_NEG = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_BIE_REF": // S.A. BIENES REFRIG. O CONG.
                        quoteInfo.IMP_BIE_REF = Convert.ToInt32(item.val_campo);
                        break;


                    case "MCA_COB_INCENDIO": // ¿COB, A-INCENDIO?
                    case "NUM_SOLICITUD": // SOLICITUD / CRUCE COBRANZAS
                    case "MCA_SUBLIM_ROBO2056": // SUBLIM. DE ROBO (%) S/PERDIDA 
                    case "MCA_SUBLIM_ROBO2055": // SUBLIM. DE ROBO (%) S/PERDIDA 
                    case "MCA_SUBLIM_ROBO2057": // SUBLIM. DE ROBO (%) S/PERDIDA 
                    case "DEDUCIBLE2055": // MÍNIMO POR EVENTO
                    case "COD_TIPO_OCUP_POL": // OCUPACIÓN DEL ASEGURADO
                    case "DEDUCIBLE2056": // MÍNIMO POR EVENTO
                    case "MCA_COB_TERR": // ¿COB. TERREMOTO (S/N)?
                    case "DEDUCIBLE2057": // MÍNIMO POR EVENTO
                    case "MCA_COB_INUN": // ¿COB. INUNDACIÓN (S/N)?
                    case "MCA_COB_DESL": // ¿COB. DESLIZAMIENTO (S/N)?
                    case "MCA_COB_DPA": // ¿COB. C-DAÑOS POR AGUA?
                    case "MCA_COB_DCMG": // ¿COB. D-DOMO,CRIST,MÁRM,GRAN.?
                    case "MCA_COB_ROB": // ¿COB. E-ROBO?
                    case "MCA_COB_GPA": // ¿COB. F-GASTOS DE ALQUILER?
                    case "MCA_COB_PDR": // ¿COB, G-PÉRDIDA DE RENTAS?                    
                    case "MCA_COB_BR": // ¿COB. BIENES REF. O CONG.?
                    case "NUM_TIP_BR": // ¿# PERÍODOS DE CARENCIA?
                    case "MCA_COB_MET": // ¿COB. MERCANCÍA EN TRÁNSIT.?
                    case "MCA_COB_RDM": // ¿COB. ROTURA DE MAQUINARIA?
                    case "MCA_COB_EE": // ¿COB. EQUIPO ELECTRÓNICO?
                    case "MCA_COB_IDN": // ¿COB. INTERR, DE NEGOCIO?
                    case "MCA_COB_AE": // ¿COB. ASIST. EN LA EMPRESA?
                    case "COD_TIP_BR": // ¿TIPO DE PERÍODO DE CARENCIA?
                    case "COD_TIP_MED_INC": // SELEC TIPO DE MED CONTRA INCEN
                    case "COD_TIP_MED_BR": // SELEC TIPO DE MED BIENES REFRI
                    case "IMP_CONTENIDO": // S.A. CONTENIDO
                    case "COD_TIP_MED_ROB": // SELEC TIPO DE MED POR ROBO
                    case "COD_TIP_MED_RDM": // SELEC TIP DE MED ROTURA DE MAQ
                    case "FOLIO_RGO1": // N° DE FOLIO REAL
                    case "FOLIO_RGO2": // N° DE FINCA MADRE
                    case "MCA_OCU_POLIZA": // ¿OCUP.POLIZA = OCUP.RIESG?
                    case "COD_CLASE_RGO_INC": // CLASE DE RIESGO DE INCENDIO
                    case "COD_CLASE_RGO_ROB": // CLASE DE RIESGO ROBO
                    case "COD_ZONA_TER": // ZONA DE RIESGO
                    case "COD_TIP_INUNDA": // COLINDANCIA POR INUNDACIÓN
                    case "COD_TIP_DESLIZ": // TIPO DE RIESGO PARA DESLIZAMIE
                    case "ANO_CONST": // AÑO DE CONSTRUCCIÓN
                    case "ALTURA_EDIF": // ÁLTURA APRÓXIMADA EN METROS
                    case "TIP_EXTIN_INC": // TIPO DE EXTINTORES DE INCENDIO
                    case "PCT_AJUSTE_GEN": // PORCENTAJE AJUSTE COMERCIAL
                    case "MCA_SUB_ROB": // ¿SUB-LIMITE DE ROBO (S/N)?
                    case "CLASE_CONST1": // HASTA 20% MATE COMBU PARED INT
                    case "CLASE_CONST2": // MÁS 20% MAT COMB PAREDES INT
                    case "CLASE_CONST3": // PARED INT Y EXT DE MAT COMBUST
                    case "VOLT_INSTA": // VOLTAJE INSTALACIÓN ELÉCTRICA
                    case "CAJA_BREAKERS": // POSEE CAJA BREAKERS
                    case "INTERRUPTORES": // TIENE INTERRUPTORES CUCHILLA
                    case "FUSIBLE_ALAMBRE": // ¿HAY CUCHILLA?FUSIBLE/ALAMBRE
                    case "PRO_INUNDACION": // HA TENIDO PROBLEMAS INUNDACIÓN
                    case "PRO_VIENTOS_HU": // PROBLEMAS VIENTOS HURACANADOS
                    case "PRO_DESLIZAMIENTO": // TENIDO PROBLEMAS DESLIZAMIENTO
                    case "UBI_RIO": // UBICACION CERCA DE UN RÍO
                    case "UBI_PENDIENTE": // UBI CERCA DE UNA PENDIENTE
                    case "UBI_PIE_TALUD": // UBI CERCA AL PIE DE TALUD
                    case "UBI_BORDE_TALUD": // UBI CERCA BORDE UN TALUD
                    case "SIS_ALCAN_PLUVIAL": // BUEN FUNC ALCANT PLUVIAL
                    case "LAM_TORINILLO": // LAMINA DE TECHO CON TORINILLO
                    case "LAM_CLAVOS": // LAMINA DE TECHO CON CLAVOS
                    case "LAM_ZINC_SUELTAS": // LÁMINAS DE ZINC SUELTAS
                    case "LAM_ZINC_FLOJAS": // LÁMINAS DE ZINC FLOJAS
                    case "LAM_ZINC_OXIDADAS": // LÁMINAS DE ZINC OXIDADAS
                    case "TIP_BENEFICIO": // TIPO DE BENEFICIO
                    case "MCA_COLECTIVO": // ¿COLECTIVO?
                        break;
                }
            }
            return quoteInfo;
        }

        internal static Contracts.Variaciones.Multirriesgo Quote(Contracts.Variaciones.Multirriesgo quoteInfo, Architect.API.Tron.Contracts.Poliza.DatoFijo tronQuoteInfo)
        {
            int riesgo = 0;
            if (tronQuoteInfo.Coberturas != null)
            {
                if (tronQuoteInfo.Coberturas?.Count == 1)
                {
                    quoteInfo.Error = tronQuoteInfo.Coberturas[0].txt_error;
                }
                foreach (Architect.API.Tron.Contracts.Poliza.Cobertura item in tronQuoteInfo.Coberturas)
                {
                    foreach (Contracts.Comun.Cobertura itemQuote in quoteInfo.coberturas)
                    {
                        if (item.cod_cob == itemQuote.codigo)
                        {
                            itemQuote.seleccionado = true;

                            itemQuote.codigo = item.cod_cob;
                            itemQuote.nombre = item.nom_cob;
                            itemQuote.capital = item.suma_aseg;
                            itemQuote.primatotal = item.imp_total;
                            itemQuote.deducible = item.deducible;
                            itemQuote.riesgo = item.num_riesgo;
                            itemQuote.error = item.txt_error;
                            if (quoteInfo.presupuesto.IsEmpty())
                            {
                                quoteInfo.presupuesto = item.num_poliza;
                            }

                            riesgo = item.num_riesgo;
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

            if (tronQuoteInfo.Calculado?.Recibos != null)
            {
                double importeAnual = 0;
                bool setvalues = true;
                quoteInfo.plandepago = new List<Contracts.Comun.PlanDePago>();
                foreach (Architect.API.Tron.Contracts.Poliza.ReciboCalculado item in tronQuoteInfo.Calculado.Recibos)
                {
                    importeAnual = item.IMP_RECIBO;
                    quoteInfo.plandepago.Add(new Contracts.Comun.PlanDePago()
                    {
                        recibo = item.NUM_RECIBO,
                        cuota = item.NUM_CUOTA,
                        numspto = item.NUM_SPTO,
                        tipsituacion = item.TIP_SITUACION,
                        fechadesde = item.FEC_EFEC_RECIBO,
                        fechahasta = item.FEC_VCTO_RECIBO,
                        primaneta = item.IMP_NETA,
                        iVA = item.IMP_IMPTOS,
                        recargoporfraccionamiento = item.IMP_INTERES,
                        importetotal = item.IMP_RECIBO
                    });
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

            if (tronQuoteInfo.Terceros != null)
            {
                Terceros(quoteInfo, tronQuoteInfo);
            }

            quoteInfo.AvailableCoverages = getAvailableCoverages(quoteInfo.cod_cia, quoteInfo.cod_ramo, riesgo);
            quoteInfo.SumAseguradaRamo = Architect.API.Tron.DataAccess.Variaciones.VariacionIssue.GetSumaAseguradaPorRamo(quoteInfo.cod_cia, quoteInfo.cod_ramo);

            foreach (var item in quoteInfo.coberturas)
            {
                var obj = quoteInfo.AvailableCoverages.FirstOrDefault(c => c.codigo == item.codigo);
                if(obj != null)
                {
                    item.requerida = obj.mcaObligatorio == "S";
                    item.seleccionado = obj.seleccionado;

                    if (item.codigo != 1060 && item.codigo != 3010 && item.codigo != 3016)
                    {
                        quoteInfo.AvailableCoverages.RemoveAll(c => c.codigo == item.codigo);
                    }
                }
            }

            quoteInfo.plandepagoresumen = Architect.API.Tron.DataAccess.Variaciones.VariacionIssue.GetPlanPagosResumen(quoteInfo.cod_cia, quoteInfo.num_poliza, null, null, null);

            return quoteInfo;
        }

        public static Contracts.Variaciones.MapfreMas GetEnableSumaAsegurada(Contracts.Variaciones.MapfreMas quoteInfo)
        {
            List<g1010031> SumAseguradaTotales = Architect.API.Tron.DataAccess.Variaciones.VariacionIssue.GetSumaAseguradaPorRamo(quoteInfo.cod_cia, quoteInfo.cod_ramo);
            List<g1010031> SumAseguradaPoliza = new List<g1010031>();

            foreach (var item in quoteInfo.coberturas)
            {
                var find = SumAseguradaTotales.Where(s => s.cod_cob == item.codigo);

                if (find.Any())
                {
                    SumAseguradaPoliza.AddRange(find);
                }
            }

            foreach (var item in SumAseguradaPoliza)
            {
                switch (item.cod_campo)
                {
                    case "IMP_AUTO_RC":
                        quoteInfo.AUTO_RC = true;
                        break;
                    case "IMP_AUTO_CYV":
                        quoteInfo.AUTO_CYV = true;
                        break;
                    case "IMP_AUTO_ROB":
                        quoteInfo.AUTO_ROB = true;
                        break;
                    case "IMP_AUTO_GMO":
                        quoteInfo.AUTO_GMO = true;
                        break;
                    case "IMP_AUTO_ACO":
                        quoteInfo.AUTO_ACO = true;
                        break;
                    case "IMP_AUTO_RAD":
                        quoteInfo.AUTO_RAD = true;
                        break;
                    case "IMP_AUTO_EQESP":
                        quoteInfo.AUTO_EQESP = true;
                        break;
                    case "IMP_AUTO_CRI":
                        quoteInfo.AUTO_CRI = true;
                        break;
                    case "IMP_AUTO_NEUM":
                        quoteInfo.AUTO_NEUM = true;
                        break;
                    case "IMP_AUTO_MECA":
                        quoteInfo.AUTO_MECA = true;
                        break;
                }
            }

            quoteInfo.SumAseguradaRamo = SumAseguradaTotales;

            return quoteInfo;
        }

        public static List<CoberturaVariacion> getAvailableCoverages(int cod_cia, int cod_ramo, int riesgo)
        {
            List<CoberturaVariacion> coberturas = new List<CoberturaVariacion>();
            List<a1002150> coberturasDisponibles = VariacionIssue.getAllCoveragesByRamo(cod_cia, cod_ramo);

            foreach (var item in coberturasDisponibles)
            {
                coberturas.Add(new CoberturaVariacion
                {
                    codigo = item.COD_COB,
                    nombre = item.NOM_COB,
                    capital = 0,
                    primatotal = 0,
                    deducible = "",
                    riesgo = riesgo,
                    requerida = false,
                    seleccionado = (item.COD_COB == 1060 || item.COD_COB == 3010 || item.COD_COB == 3016),
                    mcaObligatorio = item.MCA_OBLIGATORIO,
                });
            }

            if (!coberturas.Any(c => c.codigo == 1060))
            {
                coberturas.Add(new CoberturaVariacion
                {
                    codigo = 1060,
                    nombre = "ASISTENCIAS",
                    capital = 0,
                    primatotal = 0,
                    deducible = "",
                    riesgo = riesgo,
                    requerida = false,
                    seleccionado = true,
                    mcaObligatorio = "N"
                });
            }

            if (!coberturas.Any(c => c.codigo == 3010))
            {
                coberturas.Add(new CoberturaVariacion
                {
                    codigo = 3010,
                    nombre = "COBL - AYUDA EN CAMINO",
                    capital = 0,
                    primatotal = 0,
                    deducible = "",
                    riesgo = riesgo,
                    requerida = false,
                    seleccionado = true,
                    mcaObligatorio = "N"
                });
            }

            if (!coberturas.Any(c => c.codigo == 3016))
            {
                coberturas.Add(new CoberturaVariacion
                {
                    codigo = 3016,
                    nombre = "TRASLADO AL AEROPUERTO",
                    capital = 0,
                    primatotal = 0,
                    deducible = "",
                    riesgo = riesgo,
                    requerida = false,
                    seleccionado = true,
                    mcaObligatorio = "N"
                });
            }

            //coberturas.Add(new CoberturaVariacion
            //{
            //    codigo = 3002,
            //    nombre = "COBB - GASTOS MÉD. OCUP.",
            //    capital = 0,
            //    primatotal = 0,
            //    deducible = "",
            //    riesgo = riesgo,
            //    requerida = false,
            //    seleccionado = true
            //});

            //coberturas.Add(new CoberturaVariacion
            //{
            //    codigo = 3003,
            //    nombre = "TRASLADO AL AEROPUERTO",
            //    capital = 0,
            //    primatotal = 0,
            //    deducible = "",
            //    riesgo = riesgo,
            //    requerida = false,
            //    seleccionado = true
            //});

            return coberturas;
        }

        internal static List<Contracts.Comun.tercero> Terceros(Contracts.Variaciones.Multirriesgo quoteInfo, Contracts.Poliza.DatoFijo datosFijos)
        {
            quoteInfo.terceros = new List<Contracts.Comun.tercero>();

            foreach (Contracts.Poliza.Tercero item in datosFijos.Terceros)
            {

                Contracts.Comun.tercero tercero = new Contracts.Comun.tercero()
                {
                    numeroderiesgo = item.num_riesgo,
                    tipodetercero = int.Parse(item.tip_benef),
                    tipodeterceroDesc = item.nom_benef,
                    DocumentNumber = item.tip_docum + "-" + item.cod_docum,
                    vencimientodecesion = item.fec_vcto_cesion,
                    importedecesion = item.imp_cesion,
                    numerodeprestamo = item.num_prestamo,
                    nombre = item.nom_completo,
                    numerodetelefono = item.tlf_numero,
                    correoelectronico = item.email,
                    fechadenacimiento = (!string.IsNullOrEmpty(item.fec_nacimiento) && item.fec_nacimiento.Length >= 10) ? Convert.ToDateTime(item.fec_nacimiento) : DateTime.MinValue
                };

                quoteInfo.terceros.Add(tercero);

            }


            return quoteInfo.terceros;
        }
    }
}
