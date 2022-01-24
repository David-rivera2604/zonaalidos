using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace Architect.API.Tron.Business.Cotizacion
{
    public static class API
    {

        public static Contracts.Poliza.API.Poliza Issue(Contracts.Presupuesto.API.Presupuesto presupuesto, Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Poliza.API.Poliza dataResult = null;
            Architect.API.Tron.Contracts.Ramo.A1001800 ramo = Ramo.Configuracion.Retrieve(presupuesto.cod_ramo);

            if (ramo == null)
            {
                return new Contracts.Poliza.API.Poliza()
                {
                    error = true,
                    razon = "El ramo no esta registrado"
                };
            }
            else
            {
                string validResult = TRON_Validate(presupuesto, ramo);
                if (validResult.IsNotEmpty())
                {
                    return new Contracts.Poliza.API.Poliza()
                    {
                        error = true,
                        razon = validResult
                    };
                }
            }

            Architect.API.Tron.Contracts.Presupuesto.DatoFijo tron = APIConvertTo.Tron(presupuesto, tokenInfo.AgentCode, tokenInfo.UserName);


            if (ramo.TIP_PRIMAS_MANUALES == "2")
            {
                tron.cod_sector = ramo.COD_SECTOR;
                tron.mca_prorrata = ramo.MCA_PRORRATA;

                tron.mca_prima_manual = "S";
                tron.mca_reaseguro_manual = "N";
                tron.tip_poliza_tr = "F";
                tron.val_mca_int = "";
                tron.mca_exclusivo = "S";
                tron.Riesgos.First().mca_exclusivo = "";
            }

            Architect.API.Tron.Contracts.Presupuesto.DatoFijo presupuestoResult = Backoffice.Cotizacion.Generico.Calcular(tron, 3, "Riesgo emitido desde ZA Web");

            Contracts.Poliza.DatoFijo data = null;

            if (presupuestoResult.DatosDelProceso.txt_error.IsEmpty())
            {
                using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
                {
                    data = DataAccess.LeerPoliza.Poliza(Int32.Parse(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]), presupuestoResult.DatosDelProceso.num_poliza_definitivo, 0, 0, 0, currentConnection, true);

                    currentConnection.Close();
                }
                if (data != null)
                {
                    dataResult = new Contracts.Poliza.API.Poliza()
                    {
                        fec_emision = data.fec_emision,
                        num_poliza = data.num_poliza,
                        num_presupuesto = data.num_presupuesto,
                        error = false,
                        Coberturas = new List<Contracts.Poliza.API.Cobertura>(),
                        Recibos = new List<Contracts.Poliza.API.Recibo>(),
                    };
                    foreach (Tron.Contracts.Poliza.CoberturaCalculada cobertura in data.Calculado.Coberturas.OrderBy(r => r.COD_COB))
                    {
                        dataResult.Coberturas.Add(new Contracts.Poliza.API.Cobertura()
                        {
                            cod_cob = cobertura.COD_COB,
                            nom_cob = cobertura.NOM_COB.Capitalize(),
                            suma_aseg = cobertura.SUMA_ASEG,
                            imp_total = cobertura.IMP_TOTAL,
                            imp_anual = cobertura.IMP_ANUAL,
                            imp_iva = cobertura.IMP_IVA,
                            imp_fracc = cobertura.IMP_FRACC,
                            cod_franquicia = cobertura.COD_FRANQUICIA,
                            nom_franquicia = cobertura.NOM_FRANQUICIA.Capitalize()
                        });
                    }
                    foreach (Tron.Contracts.Poliza.ReciboCalculado recibo in data.Calculado.Recibos)
                    {
                        dataResult.Recibos.Add(new Contracts.Poliza.API.Recibo()
                        {
                            num_cuota = recibo.NUM_CUOTA,
                            num_recibo = recibo.NUM_RECIBO == -1 ? 0 : recibo.NUM_RECIBO,
                            fec_efec_recibo = recibo.FEC_EFEC_RECIBO,
                            fec_vcto_recibo = recibo.FEC_VCTO_RECIBO,
                            imp_recibo = recibo.IMP_RECIBO,
                            imp_neta = recibo.IMP_NETA,
                            imp_recargo = recibo.IMP_RECARGO,
                            imp_imptos = recibo.IMP_IMPTOS,
                            imp_interes = recibo.IMP_INTERES
                        });
                    }
                }
                else
                {
                    dataResult = new Contracts.Poliza.API.Poliza()
                    {
                        error = true,
                        razon = "Falla al tratar de recuperar los datos de la póliza " + presupuestoResult.DatosDelProceso.num_poliza_definitivo
                    };
                }
            }
            else
            {
                dataResult = new Contracts.Poliza.API.Poliza()
                {
                    error = true,
                    razon = presupuestoResult.DatosDelProceso.txt_error
                };
            }

            return dataResult;
        }

        private static string TRON_Validate(Contracts.Presupuesto.API.Presupuesto presupuesto, Architect.API.Tron.Contracts.Ramo.A1001800 ramo)
        {
            string result = string.Empty;

            foreach (Contracts.Presupuesto.API.Riesgo riesgo in presupuesto.Riesgos)
            {
                if (riesgo.DatosVariables != null)
                {
                    foreach (Contracts.Presupuesto.API.DatoVariable dato in riesgo.DatosVariables)
                    {
                        if (!ramo.DatosVariables.Any(r => r.COD_CAMPO.Equals(dato.cod_campo, StringComparison.CurrentCultureIgnoreCase)))
                        {
                            result += $"El dato variable '{dato.cod_campo}' no es valido\n";
                        }
                    }
                }
                if (riesgo.Coberturas != null)
                {
                    Contracts.Ramo.A1002150 coberturaTron;
                    foreach (Contracts.Presupuesto.API.Cobertura cobertura in riesgo.Coberturas)
                    {
                        coberturaTron = (from c in ramo.Coberturas where c.COD_COB == cobertura.cod_cob select c).FirstOrDefault();
                        if (coberturaTron == null)
                        {
                            result += $"La cobertura '{cobertura.cod_cob}' no es valida\n";
                        }
                        if (cobertura.DesgloseEconomico != null && coberturaTron != null)
                        {
                            foreach (Contracts.Presupuesto.API.DesgloseEconomico desgloseEconomico in cobertura.DesgloseEconomico)
                            {
                                if (!ramo.DesglosePorCobertura.Any(r => r.COD_COB == cobertura.cod_cob && r.COD_DESGLOSE == desgloseEconomico.cod_desglose ))
                                {
                                    result += $"El desglose económico '{desgloseEconomico.cod_desglose}' para la cobertura '{cobertura.cod_cob}' no es valido\n";
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
