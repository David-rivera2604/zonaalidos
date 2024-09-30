using Architect.API.Tron.Contracts.Cotizacion;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace Architect.API.Tron.Business.Cotizacion
{
    /// <summary>
    /// Cotización de póliza de saldo deudor en tron.
    /// </summary>
    public sealed class SaldoDeudor
    {
        public const int COD_RAMO = 401;
        public const string NOM_PROD = "SaldoDeudor";

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo saldo deudor.
        /// </summary>
        public static Contracts.Cotizacion.SaldoDeudor Setup(Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.SaldoDeudor result = (Contracts.Cotizacion.SaldoDeudor)Generico.ValoresIniciales(new Contracts.Cotizacion.SaldoDeudor(), COD_RAMO, NOM_PROD, tokenInfo);
            if (result.coberturas.Where(r => r.codigo == 4001) != null)
            {
                result.coberturas.Where(r => r.codigo == 4001).First().edtCapital = true;
            }
            if (result.coberturas.Where(r => r.codigo == 4002) != null)
            {
                result.coberturas.Where(r => r.codigo == 4002).First().edtCapital = true;
            }
            if (result.coberturas.Where(r => r.codigo == 4005) != null)
            {
                result.coberturas.Where(r => r.codigo == 4005).First().edtCapital = true;
            }
            if (result.coberturas.Where(r => r.codigo == 4006) != null)
            {
                result.coberturas.Where(r => r.codigo == 4006).First().edtCapital = true;
            }
            if (result.coberturas.Where(r => r.codigo == 4007) != null)
            {
                result.coberturas.Where(r => r.codigo == 4007).First().edtCapital = true;
            }
            result.MCA_NEGOCIO_MIGRADO = "N";
            return result;
        }

        /// <summary>
        /// Recupera lista de valores para sumas aseguradas de coberturas o valores variables según el contrato
        /// </summary>
        public static Tron.Contracts.Cotizacion.SaldoDeudorSettings Settings(int cod_ramo, int num_contrato, int num_subcontrato, string num_poliza_grupo, int cod_mon, int cod_agt, Core.Contracts.Security.Token tokenInfo)
        {
            Tron.Contracts.Cotizacion.SaldoDeudorSettings result = new Contracts.Cotizacion.SaldoDeudorSettings();
            List<string> keys = new List<string> { };
            if (tokenInfo.Roles.Contain("PolizaGrupo"))
            {
                keys.AddRange(new List<string> { "MM_POLIZA_GRUPO", "MODALIDAD_401_CONTRATO", "TIPO_NEGOCIO_401_CONTRATO" });
            }

            string url = $"cod_ramo={cod_ramo}:num_contrato={num_contrato}:num_subcontrato={num_subcontrato}:num_poliza_grupo={num_poliza_grupo}:cod_mon={cod_mon}:cod_agt={cod_agt}";
            List<Core.Contracts.General.LookupValues> values = Core.Business.Common.Lkps(string.Join(",", keys), url, tokenInfo);

            result.fec_vcto_poliza = DateTime.Today.AddYears(1);

            if (tokenInfo.Roles.Contain("PolizaGrupo"))
            {

                Core.Contracts.General.LookupValues contratosMaster = values.Find(x => x.Key == "MM_POLIZA_GRUPO");
                if (contratosMaster != null)
                {
                    Core.Contracts.General.LookupValue contrato = contratosMaster.Lkp.Find(y => y.Code == num_contrato.ToString());
                    if (contrato != null)
                    {
                        //FechaVencimiento
                        string vcto_poliza = (string)contrato["FEC_VCTO_POLIZA"];
                        if (vcto_poliza.IsNotEmpty())
                        {
                            result.fec_vcto_poliza = DateTime.Parse(vcto_poliza, CultureInfo.CreateSpecificCulture("es-CR"));
                        }
                    }
                }

                //fraccionamiento
                result.cod_fracc_pago = Architect.API.Tron.DataAccess.PorRamo.FrecuenciaDePagoPorContrato(1, cod_ramo, num_contrato, cod_agt);

                //Coberturas
                if (num_contrato > 0)
                {
                    List<Contracts.Ramo.G2990026> coberturaGrupo = DataAccess.PorRamo.Coberturas_por_contrato2(COD_RAMO, num_contrato);
                    string cod_cobIncludeFilter = Util.Convert_CoverageListToString(coberturaGrupo);
                    result.coberturas = CoverageByDefault(num_contrato, num_subcontrato, num_poliza_grupo, tokenInfo);
                }

                //Modalidad
                result.COD_MODALIDAD_RIESGO = values.Find(x => x.Key == "MODALIDAD_401_CONTRATO").Lkp;

                //Tipo Negocio
                result.TIP_NEGOCIO = values.Find(x => x.Key == "TIPO_NEGOCIO_401_CONTRATO").Lkp;
            }

            return result;
        }


        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de tipo saldo deudor.
        /// </summary>
        public static Contracts.Cotizacion.SaldoDeudor Quote(Contracts.Cotizacion.SaldoDeudor quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.SaldoDeudor resultInfo = quoteInfo;

            resultInfo.Errors = Reglas.research.Apply_Reglas(NOM_PROD, quoteInfo, tokenInfo);
            if (resultInfo.Errors.Count == 0)
            {
                quoteInfo.presupuesto = string.Empty;
                quoteInfo.resumen = null;

                Contracts.Presupuesto.DatoFijo result = SaldoDeudorConvert.ToTron(quoteInfo, COD_RAMO, quoteInfo.cod_agt, tokenInfo.UserName);
                result = Backoffice.Cotizacion.Generico.Calcular(result);

                resultInfo = LookupComplements((Contracts.Cotizacion.SaldoDeudor)Util.FromTron_CoberturasResult(quoteInfo, result, 11), tokenInfo);
                resultInfo.cod_ramo = COD_RAMO;
                Architect.Utilities.Cache.SetItem(string.Format("{0}.{1}", NOM_PROD, quoteInfo.presupuesto), Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo), -1);

                if (resultInfo.presupuesto.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultInfo.presupuesto.Substring(4)), tokenInfo.CompanyId, "Cotización Saldo Deudor", "Presupuesto #" + resultInfo.presupuesto, tokenInfo.UserId, resultInfo);
                }
            }

            return resultInfo;
        }

        /// <summary>
        /// Prepara las descripciones de campos relacionados a listas de valores.
        /// </summary>
        private static Contracts.Cotizacion.SaldoDeudor LookupComplements(Contracts.Cotizacion.SaldoDeudor quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {

            return quoteInfo;
        }

        /// <summary>
        /// Recupera la configuración de coberturas por defecto.
        /// </summary>
        public static List<Contracts.Comun.Cobertura> CoverageByDefault(int num_contrato, int num_subcontrato, string num_poliza_grupo, Core.Contracts.Security.Token tokenInfo)
        {
            List<Contracts.Comun.Cobertura> coberturas = new List<Contracts.Comun.Cobertura>();
            string cod_cobExcludeFilter = string.Empty;
            string cod_cobIncludeFilter = string.Empty;
            int cod_modalidad = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_modalidad"]);
            int cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
            DateTime fec_validez = DateTime.Today;

            if (tokenInfo.Roles.Contain("PolizaGrupo"))
            {
                if (num_contrato > 0)
                {
                    List<Contracts.Ramo.G2990026> coberturaGrupo = DataAccess.PorRamo.Coberturas_por_contrato2(COD_RAMO, num_contrato);
                    cod_cobIncludeFilter = Util.Convert_CoverageListToString(coberturaGrupo);

                    if (cod_cobIncludeFilter.IsNotEmpty())
                    {
                        foreach (Contracts.Ramo.a1002150 item in DataAccess.PorRamo.Coberturas(cod_cia, COD_RAMO, cod_modalidad, fec_validez, cod_cobExcludeFilter, cod_cobIncludeFilter))
                        {
                            coberturas.Add(new Contracts.Comun.Cobertura()
                            {
                                seleccionado = false,
                                requerida = coberturaGrupo.Any(r => r.COD_COB == item.COD_COB && r.MCA_OBLIGATORIO == "S"),
                                codigo = item.COD_COB,
                                nombre = item.NOM_COB,
                                capital = item.SUMA_ASEG,
                                primatotal = item.IMP_TOTAL,
                                deducible = item.NOM_FRANQUICIA


                            });
                            if (coberturas.Last().requerida)
                            {
                                coberturas.Last().seleccionado = true;
                                coberturas.Last().edtCapital = true;

                            }
                            coberturas.Last().edtCapital = true;
                        }
                    }

                }
            }

            if (cod_cobIncludeFilter.IsEmpty())
            {
                Contracts.Cotizacion.SaldoDeudor result_ = Setup(tokenInfo);
                coberturas = result_.coberturas;
            }
            return coberturas;
        }

        /// <summary>
        /// Recupera Calculo de IMC
        /// </summary>
        public static Tron.Contracts.Cotizacion.SaldoDeudor calcula_imc(string estatura, string peso, Core.Contracts.Security.Token tokenInfo)
        {
            List<Architect.API.Core.Contracts.General.LookupValue> imc_obj;
            Tron.Contracts.Cotizacion.SaldoDeudor result = new Contracts.Cotizacion.SaldoDeudor();

            estatura = estatura.Replace(".", ",");
            peso = peso.Replace(".", ",");

            List<string> keys = new List<string> { "PRE_IMC_401" };
            string url = $"estatura={estatura}:peso={peso}";
            List<Core.Contracts.General.LookupValues> values = Core.Business.Common.Lkps(string.Join(",", keys), url, tokenInfo);

            imc_obj = values.Find(x => x.Key == "PRE_IMC_401").Lkp;

            foreach (Architect.API.Core.Contracts.General.LookupValue item in imc_obj)
            {
                result.NUM_IMC = Convert.ToDouble(item.Code);

            }

            return result;

        }
    }
}
