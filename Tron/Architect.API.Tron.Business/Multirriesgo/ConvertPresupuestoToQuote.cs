using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Tron.Business.Multirriesgo
{
    internal static class ConvertPresupuestoToQuote
    {

        internal static Contracts.Cotizacion.Multirriesgo Quote(Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            //Contracts.Cotizacion.Multirriesgo result = DatosFijos(tronQuoteInfo);

            Contracts.Cotizacion.Multirriesgo quoteInfo = new Contracts.Cotizacion.Multirriesgo()
            {
                cod_fracc_pago = tronQuoteInfo.cod_fracc_pago,
                cod_mon = tronQuoteInfo.cod_mon,
                fec_efec_poliza = tronQuoteInfo.fec_efec_poliza,
                fec_vcto_poliza = tronQuoteInfo.fec_vcto_poliza,
                coberturas = new List<Contracts.Comun.Cobertura>()
            };

            quoteInfo = DatosVariable(quoteInfo, tronQuoteInfo);

            foreach (Contracts.Presupuesto.Cobertura item in tronQuoteInfo.Coberturas)
            {
                quoteInfo.coberturas.Add(new Contracts.Comun.Cobertura()
                {
                    seleccionado = true,
                    requerida = true,
                    codigo = item.cod_cob,
                    nombre = item.nom_cob,
                    capital = item.suma_aseg,
                    primatotal = item.imp_total,
                    deducible = item.nom_franquicia
                });

            }
            return quoteInfo;
        }


        private static Contracts.Cotizacion.Multirriesgo DatosVariable(Contracts.Cotizacion.Multirriesgo quoteInfo, Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            foreach (Contracts.Presupuesto.DatoVariable item in tronQuoteInfo.DatosVariables)
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
                        quoteInfo.MCA_EXTIN_INC = Convert.ToInt32(item.val_campo);
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
                            foreach (Contracts.Presupuesto.Ocurrencia ocurrencia in from t in tronQuoteInfo.Ocurrencias where t.cod_campo == "COD_TIP_MED_INC" orderby t.num_ocurrencia select t)
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
                            foreach (Contracts.Presupuesto.Ocurrencia ocurrencia in from t in tronQuoteInfo.Ocurrencias where t.cod_campo == "COD_TIP_MED_ROB" orderby t.num_ocurrencia select t)
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
                            foreach (Contracts.Presupuesto.Ocurrencia ocurrencia in from t in tronQuoteInfo.Ocurrencias where t.cod_campo == "COD_TIP_MED_BR" orderby t.num_ocurrencia select t)
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
                            foreach (Contracts.Presupuesto.Ocurrencia ocurrencia in from t in tronQuoteInfo.Ocurrencias where t.cod_campo == "COD_TIP_MED_RDM" orderby t.num_ocurrencia select t)
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
                    case "IMP_BIE_REF": // S.A. BIENES REFRIG. O CONG.
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

        internal static Contracts.Cotizacion.Multirriesgo Quote(Contracts.Cotizacion.Multirriesgo quoteInfo, Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {

            if (tronQuoteInfo.Coberturas != null)
            {
                if (tronQuoteInfo.Coberturas?.Count == 1)
                {
                    quoteInfo.Error = tronQuoteInfo.Coberturas[0].txt_error;
                }

                foreach (Contracts.Presupuesto.Cobertura item in tronQuoteInfo.Coberturas)
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

                if (quoteInfo.cod_fracc_pago == 1)
                {
                    double amount = 0;
                    quoteInfo.plandepagoporfrecuencia = new List<Contracts.Cotizacion.plandepagoporfrecuencia>();
                    foreach (Contracts.Ramo.A1001403 item in Architect.API.Tron.DataAccess.PorRamo.FrecuenciaDePago(tronQuoteInfo.cod_cia, tronQuoteInfo.cod_ramo, tronQuoteInfo.cod_mon))
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
                    //if (quoteInfo.Mensaje.IndexOf(']') > 0)
                    //{
                    //    quoteInfo.Mensaje = quoteInfo.Mensaje.Substring(quoteInfo.Mensaje.IndexOf(']') + 1).Trim();
                    //}
                    //if (quoteInfo.Mensaje.IndexOf('<') > 0)
                    //{
                    //    quoteInfo.Mensaje = quoteInfo.Mensaje.Substring(0, quoteInfo.Mensaje.IndexOf('<')).Trim();
                    //}
                    quoteInfo.Mensaje = quoteInfo.Mensaje.Substring(0, 1).ToUpper() + quoteInfo.Mensaje.Substring(1).ToLower();
                }
            }
            return quoteInfo;
        }
    }
}
