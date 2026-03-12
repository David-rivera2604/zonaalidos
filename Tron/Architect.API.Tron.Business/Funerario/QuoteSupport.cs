using Architect.API.Tron.Contracts.Comun;
using Architect.API.Tron.Contracts.Presupuesto;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Tron.Business.Funerario
{
    internal class QuoteSupport
    {

        /// <summary>
        /// Recupera la configuración de coberturas por defecto.
        /// </summary>
        internal static List<Contracts.Comun.Cobertura> CoverageByDefault(int cod_cia, int cod_ramo, DateTime fec_validez)
        {
            string exclude = $"{Architect.Utilities.Helpers.Settings.StringValue("Mapfre.Tron.ramo.196.coberturas.seleccionadas", string.Empty)}";
            string selected = $",{Architect.Utilities.Helpers.Settings.StringValue("Mapfre.Tron.ramo.196.coberturas.seleccionadas", "1001,1012")},";
            int cod_modalidad = Architect.Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.ramo.196.cod_modalidad", 19601);
            List<Contracts.Comun.Cobertura> coberturas = new List<Contracts.Comun.Cobertura>();

            foreach (Architect.API.Tron.Contracts.Ramo.a1002150 item in Architect.API.Tron.DataAccess.PorRamo.Coberturas(cod_cia, cod_ramo, cod_modalidad, fec_validez, exclude, string.Empty))
            {
                coberturas.Add(new Contracts.Comun.Cobertura()
                {
                    seleccionado = selected.Contains(item.COD_COB.ToString()),
                    codigo = item.COD_COB,
                    nombre = item.NOM_COB,
                    capital = item.SUMA_ASEG,
                    primatotal = item.IMP_TOTAL
                });
            }
            return coberturas;
        }

        internal static Tercero Tercero(DatoFijo datosFijos, tercero item, int tipodetercero)
        {
            Contracts.Presupuesto.Tercero newItem = Util.Tercero(datosFijos, item.DocumentNumberType.DocumentType(), item.DocumentNumber.DocumentNumber(item.DocumentNumberType.DocumentType()), System.Convert.ToInt32(tipodetercero));
            newItem.tip_relac = item.parentesco == 0 ? string.Empty : item.parentesco.ToString();
            newItem.pct_participacion = item.porcentaje;
            return newItem;
        }

        internal static Contracts.Comun.tercero Asegurado(List<Contracts.Comun.tercero> terceros)
        {
            Contracts.Comun.tercero asegurado = terceros.FirstOrDefault(r => r.tipodetercero == Contracts.Comun.tercero.ASEGURADO);
            if (asegurado == null)
            {
                Contracts.Comun.tercero contratante = terceros.FirstOrDefault(r => r.tipodetercero == Contracts.Comun.tercero.TOMADOR);
                if (contratante != null && contratante.eltomadoreselmismoasegurado == 1)
                {
                    asegurado = contratante;
                }
            }
            return asegurado;
        }

        internal static Contracts.Comun.tercero Contratante(List<Contracts.Comun.tercero> terceros)
        {
            Contracts.Comun.tercero contratante = terceros.FirstOrDefault(r => r.tipodetercero == Contracts.Comun.tercero.TOMADOR);
            if (contratante == null)
            {
                Contracts.Comun.tercero asegurado = terceros.FirstOrDefault(r => r.tipodetercero == Contracts.Comun.tercero.ASEGURADO);
                if (asegurado != null && asegurado.elaseguradoeselmismotomador == 1)
                {
                    contratante = asegurado;
                }
            }
            return contratante;
        }

        internal static List<Contracts.Presupuesto.DatoVariable> DatosVariable_ToTron(Contracts.Cotizacion.Funerario quoteInfo, Contracts.Presupuesto.DatoFijo datosFijos)
        {
            List<Contracts.Presupuesto.DatoVariable> datosVariables = new List<Contracts.Presupuesto.DatoVariable>();

            int edad = DateTime.Today.AddTicks(-quoteInfo.FEC_NACIMIENTO.Ticks).Year - 1;

            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "COD_PLAN_AP", quoteInfo.COD_PLAN_AP, 1, 8, quoteInfo.NOM_PLAN_AP));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "MCA_COLECTIVO", "N", 1, 900, "INDIVIDUAL"));

            datosVariables.Add(Util.DatoVariable(datosFijos, 1, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO.ToString("ddMMyyyy"), 2, 4, quoteInfo.FEC_NACIMIENTO.ToString("dd/MM/yyyy")));
            datosVariables.Add(Util.DatoVariable(datosFijos, 1, "VAL_EDAD_ACTUARIAL", edad.ToString(), 2, 5, $"{edad} años"));
            datosVariables.Add(Util.DatoVariable(datosFijos, 1, "MCA_SEXO", quoteInfo.MCA_SEXO, 2, 6, quoteInfo.MCA_SEXO == "1" ? "MASCULINO" : "FEMININO"));

            datosVariables.Add(Util.DatoVariable(datosFijos, 1, "COD_MODALIDAD", "19601", 2, 99, "AUTOEXPEDIBLE FUNERARIO"));

            return datosVariables;
        }

    }
}
