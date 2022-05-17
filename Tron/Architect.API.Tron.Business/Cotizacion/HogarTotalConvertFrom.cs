using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Architect.API.Tron.Business.Cotizacion
{
    internal class HogarTotalConvertFrom
    {
        internal static Contracts.Cotizacion.HogarTotal Quote(Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            Contracts.Cotizacion.HogarTotal data = DatosFijos(tronQuoteInfo);
            data = DatosVariables(data, tronQuoteInfo);
            return data;
        }

        private static Contracts.Cotizacion.HogarTotal DatosFijos(Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {

            return new Contracts.Cotizacion.HogarTotal()
            {
                iniciodevigencia = tronQuoteInfo.fec_efec_poliza,
                findevigencia = tronQuoteInfo.fec_vcto_poliza,
                moneda = tronQuoteInfo.cod_mon,
                fraccionamientodepago = tronQuoteInfo.cod_fracc_pago
            };
        }

        private static Contracts.Cotizacion.HogarTotal DatosVariables(Contracts.Cotizacion.HogarTotal quoteInfo, Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            foreach (Contracts.Presupuesto.DatoVariable item in tronQuoteInfo.DatosVariables)
            {
                switch (item.cod_campo)
                {
                    case "COD_PAIS": //	PAÍS
                        quoteInfo.pais = item.val_campo;
                        quoteInfo.paisDesc = item.txt_campo;
                        break;
                    case "COD_ESTADO": // PROVINCIA
                        quoteInfo.provincia = Convert.ToInt32(item.val_campo);
                        quoteInfo.provinciaDesc = item.txt_campo;
                        break;
                    case "COD_PROV": // CANTÓN
                        quoteInfo.canton = Convert.ToInt32(item.val_campo);
                        quoteInfo.cantonDesc = item.txt_campo;
                        break;
                    case "COD_LOCALIDAD": // DISTRITO
                        quoteInfo.distrito = Convert.ToInt32(item.val_campo);
                        quoteInfo.distritoDesc = item.txt_campo;
                        break;
                    case "COD_TIPO_OCUP_RGO": // OCUPACIÓN DEL RIESGO
                        quoteInfo.ocupaciondelriesgo = Convert.ToInt32(item.val_campo);
                        quoteInfo.ocupaciondelriesgoDesc = item.txt_campo;
                        break;
                    case "TIP_SUSCRIPCION": // TIPO DE SUSCRIPCION
                        quoteInfo.tipodesuscripcion = Convert.ToInt32(item.val_campo);
                        quoteInfo.tipodesuscripcionDesc = item.txt_campo;
                        break;
                    case "NUM_PISOS_EDIF": // NÚMERO DE PISOS EDIFICACIÓN
                        quoteInfo.numerodepisosedificacion = Convert.ToInt32(item.val_campo);
                        break;
                    case "COB_PDR_MESES": // MESES A AMPARAR POR PERD RENTA
                        quoteInfo.mesesaampararporperdrentas = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_EDIFICIO": // S.A. EDIFICIO
                        quoteInfo.sAEdificio = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_MOBILIARIO": // S.A. MOBILIARIO
                        quoteInfo.sAMobiliario = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_OBJ_VALIOSO": // S.A. OBJETOS VALIOSOS
                        quoteInfo.sAObjetosvaliosos = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_DOMOS_TOTAL": // S.A. DOMO,CRISTAL,MÁRMOL,GRAN.
                        quoteInfo.sADomocristalmarmolgranito = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_GAS_ALQ": // S.A. GASTOS DE ALQUILER
                        quoteInfo.sAGastosalquiler = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_PER_REN": // S.A. PÉRDIDA DE RENTAS
                        quoteInfo.sAPerdidaderentas = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_SA_RC	S.A.": // RESP. CIVIL
                        quoteInfo.sARespcivil = Convert.ToInt32(item.val_campo);
                        break;
                    case "PCT_AJUSTE_GEN": // PORCENTAJE AJUSTE COMERCIAL
                        quoteInfo.descuento = Convert.ToInt32(item.val_campo);
                        quoteInfo.descuentoDesc = item.txt_campo;
                        break;
                    case "NUM_MED_ROB": // ¿# MEDIDAS SEGURIDAD ROBO?
                        if (Convert.ToInt32(item.val_campo) > 0 && tronQuoteInfo.Ocurrencias?.Count > 0)
                        {
                            foreach (Contracts.Presupuesto.Ocurrencia ocurrencia in from t in tronQuoteInfo.Ocurrencias where t.cod_campo == "COD_TIP_MED_ROB" orderby t.num_ocurrencia select t)
                            {
                                if (quoteInfo.medidasdeseguridad.IsNotEmpty())
                                {
                                    quoteInfo.medidasdeseguridad += ",";
                                }
                                quoteInfo.medidasdeseguridad += ocurrencia.val_campo;
                            }
                        }
                        break;


                    case "COD_TIP_EDIF": // No existe en la configuración de TRON en QA
                        quoteInfo.tipodeestrucdelaedificacion = Convert.ToInt32(item.val_campo);
                        quoteInfo.tipodeestrucdelaedificacionDesc = item.txt_campo;
                        break;


                    case "MCA_SUBLIM_ROBO2056": // SUBLIM. DE ROBO (%) S/PERDIDA 
                    case "MCA_SUBLIM_ROBO2057": // SUBLIM. DE ROBO (%) S/PERDIDA 
                    case "MCA_SUBLIM_ROBO2055": // SUBLIM. DE ROBO (%) S/PERDIDA 
                    case "NUM_SOLICITUD": // SOLICITUD / CRUCE COBRANZAS
                    case "DEDUCIBLE2056": // MÍNIMO POR EVENTO
                    case "DEDUCIBLE2057": // MÍNIMO POR EVENTO
                    case "PCT_DCTO_COL": // % DCTO. COLABORADOR
                    case "DEDUCIBLE2055": // MÍNIMO POR EVENTO
                    case "OTRA_SENAS_RGO1": // OTRAS SEÑAS DEL RIESGO
                    case "FOLIO_RGO1": // N° DE FOLIO REAL
                    case "FOLIO_RGO2": // N° DE FINCA MADRE
                    case "NUM_PISO": // PISO EN QUE ESTÁ UBICADO
                    case "MCA_ACTUALIZA_VAL_REN": // ¿ACTUALIZA VALORES A LA RENOV?
                    case "NUM_DES_BIEN": // ¿# ESTRUCTURAS ESPECIALES?
                    case "ANO_CONST": // AÑO DE CONSTRUCCIÓN

                    case "NUM_METROS_CONSTRUIDOS": // METROS CONSTRUIDOS
                    case "ALTURA_EDIF": // ÁLTURA APRÓXIMADA EN METROS
                    case "COD_TIPO_ESTRUC": // TIPO DE ESTRUC DE LA EDIFICACI
                    case "MCA_COB_INCENDIO": // ¿COB, A-INCENDIO?
                    case "MCA_COB_TERR": // ¿COB. TERREMOTO (S/N)?
                    case "MCA_COB_INUN": // ¿COB. INUNDACIÓN (S/N)?
                    case "MCA_COB_DESL": // ¿COB. DESLIZAMIENTO (S/N)?
                    case "MCA_COB_DPA": // ¿COB. C-DAÑOS POR AGUA?
                    case "MCA_COB_DCMG": // ¿COB. D-DOMO,CRIST,MÁRM,GRAN.?
                    case "MCA_COB_ROB": // ¿COB. E-ROBO?

                    case "MCA_COB_GPA": // ¿COB. F-GASTOS DE ALQUILER?
                    case "MCA_COB_PDR": // ¿COB, G-PÉRDIDA DE RENTAS?

                    case "MCA_RESP_CIVIL": // ¿COB. H-RESPONSABILIDAD CIVIL?
                    case "MCA_COB_AV": // ¿COB. Q-ASIST. EN LA VIVIENDA?

                    case "COD_TIP_MED_ROB": // SELEC TIPO DE MED POR ROBO
                    case "COD_DES_BIEN": // SELEC TIPO DE ESTRUC.ESPECIAL                    
                    case "MCA_SUB_ROB": // ¿SUB-LIMITE DE ROBO (S/N)?
                    case "COD_POSTAL": // CODIGO POSTAL
                    case "GEO_LATITUD": // LATITUD
                    case "GEO_LONGITUD": // LONGITUD
                    case "COLINDANTE_NORTE": // COLINDANTE EN EL NORTE
                    case "COLINDANTE_SUR": // COLINDANTE AL SUR
                    case "COLINDANTE_ESTE": // COLINDANTE AL ESTE
                    case "COLINDANTE_OESTE": // COLINDANTE AL OESTE
                    case "CERCA_RI_MAR_LAG_TA_CI": // CERCA DE UN RÍO, MAR, LAGO,CIM
                    case "DISTANCIA_MTS": // DISTANCIA METROS
                    case "MATERIAL_ESTRUCTURA": // QUE MATERIAL ES LA ESTRUCTURA
                    case "TIP_MAMPOSTERIA": // TIPO MAMPOSTERIA
                    case "MATERIAL_PARED_INTERNAS": // MATERIAL PAREDES INTERNAS
                    case "MATERIAL_TECHO": // MATERIAL DEL TECHO
                    case "MATERIAL_ENTREPISOS": // MATERIAL DE ENTREPISOS
                    case "MATERIAL_PISO": // MATERIAL DEL PISO
                    case "SOBREPESO_EXTRUCTURAS": // EXISTE SOBREPESO ESTRUCTURAS
                    case "BIEN_ESQ_INTER_VEHI": // BIEN SE ENCUENTRA EN ESQUINA
                    case "DANOS_PREVIOS_REPARACION": // DAÑOS PREV AL BIEN, SE REPARÓ
                    case "INS_ELECT_ENTUB": // INSTALACIÓN ELECTRICA ENTUBADA
                    case "VULNERABILIDAD_CONTENIDO": //	VULNERABILIDAD DEL CONTENIDO
                    case "OBJ_ESPE_DES1": // OBJETO ESPECIAL DESCRIPCION1
                    case "OBJ_ESPE_DES2": // OBJ ESPECIALES DESCRIPCION2
                    case "OBJ_ESPE_DES3": // OBJ ESPECIALES DESCRIPCION3
                    case "OBJ_ESPE_MAR_MOD1": // OBJ ESPECIALES MARCA/MODELO1
                    case "OBJ_ESPE_MAR_MOD2": // OBJ ESPECIALES MARCA/MODELO2
                    case "OBJ_ESPE_MAR_MOD3": // OBJ ESPECIALES MARCA/MODELO3
                    case "OBJ_ESPE_ANO1": // OBJ ESPECIALES AÑO1
                    case "OBJ_ESPE_ANO2": // OBJ ESPECIALES AÑO2
                    case "OBJ_ESPE_ANO3": // OBJ ESPECIALES AÑO3
                    case "OBJ_VALOR1": // OBJ ESPECIALES VALOR1
                    case "TIP_PLAN_ASIST": // TIPO PLAN ASISTENCIA
                    case "OBJ_VALOR2": // OBJ ESPECIALES VALOR2
                    case "OBJ_VALOR3": // OBJ ESPECIALES VALOR3
                    case "POSEE_POLIZA_HOG": // POSEE PÓLIZA
                    case "NOM_ASEG_SEGU": // ASEGURADORA QUE BRINDA SEGURO
                    case "NO_POLIZA_SEGUG": // PÓLIZA DEL SEGURO DE HOGAR
                    case "SUM_ASEG_ASEG": // SUMA ASEGURADA PÓLIZA HOGAR
                    case "SINIESTRO_ANTERIORES": // HUBO SINIESTRO  BIEN ASEGURAR
                    case "FEC_SINI_ASEG": // FECHA EN QUE OCURRIÓ SINIESTRO
                    case "NOM_ASEG_SINI": // NOMBRE ASEGURADORA  SINIESTRO
                    case "NO_POLIZA_SINI": // NÚMERO PÓLIZA DEL SINIESTRO
                    case "MONTO_SINI_ASEG": // MONTO SINIESTRO ANTERIOR
                    case "TIP_BENEFICIO": // TIPO DE BENEFICIO
                    case "MCA_COLECTIVO": // ¿COLECTIVO?
                        break;
                }
            }
            return quoteInfo;
        }

        internal static Contracts.Cotizacion.HogarTotal Quote(Contracts.Cotizacion.HogarTotal quoteInfo, Architect.API.Tron.Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {

            if (tronQuoteInfo.Coberturas != null)
            {
                if (tronQuoteInfo.Coberturas?.Count == 1)
                {
                    quoteInfo.Error = tronQuoteInfo.Coberturas[0].txt_error;
                }
                foreach (Architect.API.Tron.Contracts.Presupuesto.Cobertura item in tronQuoteInfo.Coberturas)
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
                foreach (Architect.API.Tron.Contracts.Presupuesto.Recibo item in tronQuoteInfo.Recibos)
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

                if (quoteInfo.fraccionamientodepago == 1)
                {
                    double amount = 0;
                    quoteInfo.plandepagoporfrecuencia = new List<Contracts.Cotizacion.plandepagoporfrecuencia>();
                    foreach (Architect.API.Tron.Contracts.Ramo.A1001403 item in Architect.API.Tron.DataAccess.PorRamo.FrecuenciaDePago(tronQuoteInfo.cod_cia, tronQuoteInfo.cod_ramo, tronQuoteInfo.cod_mon))
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
