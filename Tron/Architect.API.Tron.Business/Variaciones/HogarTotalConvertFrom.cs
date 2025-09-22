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
    internal static class HogarTotalConvertFrom
    {
        internal static Contracts.Variaciones.HogarTotal Quote(Contracts.Poliza.DatoFijo tronQuoteInfo)
        {
            Contracts.Variaciones.HogarTotal quoteInfo = new Contracts.Variaciones.HogarTotal()
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
                coberturas = new List<Contracts.Comun.Cobertura>()
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

        private static Contracts.Variaciones.HogarTotal DatosVariables(Contracts.Variaciones.HogarTotal quoteInfo, Architect.API.Tron.Contracts.Poliza.DatoFijo tronQuoteInfo)
        {
            foreach (Contracts.Poliza.DatoVariable item in tronQuoteInfo.DatosVariables)
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
                    case "COD_TIPO_ESTRUC": // TIPO DE ESTRUC DE LA EDIFICACI
                        quoteInfo.tipodeestrucdelaedificacion = Convert.ToInt32(item.val_campo);
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
                            quoteInfo.medidasdeseguridad = string.Empty;
                            foreach (Contracts.Poliza.Ocurrencia ocurrencia in from t in tronQuoteInfo.Ocurrencias where t.cod_campo == "COD_TIP_MED_ROB" orderby t.num_ocurrencia select t)
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

        internal static Contracts.Variaciones.HogarTotal Quote(Contracts.Variaciones.HogarTotal quoteInfo, Architect.API.Tron.Contracts.Poliza.DatoFijo tronQuoteInfo)
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
                if (obj != null)
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

        internal static List<Contracts.Comun.tercero> Terceros(Contracts.Variaciones.HogarTotal quoteInfo, Contracts.Poliza.DatoFijo datosFijos)
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
