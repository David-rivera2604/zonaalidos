using Aliados.Monge.Domain.Poliza.Emision;
using Architect.API.Tron.Business.Cotizacion;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Application.Poliza
{
    internal sealed class Viajero
    {

        public static async Task<Domain.Poliza.Emision.Respuesta> Emision(Domain.Poliza.Emision.Poliza risk, int agentCode, string userName)
        {
            Domain.Poliza.Emision.Respuesta result = new Domain.Poliza.Emision.Respuesta();
            string cod_producto = risk.Datos_Generales.cod_producto;
            int cod_ramo = Convert.ToInt32(cod_producto.Substring(0, cod_producto.IndexOf("-")));

            Architect.API.Tron.Contracts.Cotizacion.Viajero quote = MapperBase(risk);

            Architect.API.Tron.Contracts.Presupuesto.DatoFijo result2 = ViajeroConvert.ToTron(quote, cod_ramo, agentCode, userName);
            result2 = MapperTerceros(risk, result2);


            result2 = Architect.API.Tron.Business.Backoffice.Cotizacion.Generico.Calcular(result2, 3, "Riesgo emitido desde ZA Web");

            return result;
        }

        internal static Architect.API.Tron.Contracts.Presupuesto.DatoFijo MapperTerceros(Domain.Poliza.Emision.Poliza risk, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datoFijo)
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
                                                             Convert.ToInt32(riskThirdParty.tipodetercero), riskThirdParty.numeroderiesgo));

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
                    cod_pais = StringValue(detalleDomicilio, 1),
                    cod_estado = IntegerValue(detalleDomicilio, 2),
                    cod_prov = IntegerValue(detalleDomicilio, 3),
                    cod_localidad = IntegerValue(detalleDomicilio, 4),
                    nom_domicilio1 = StringValue(detalleDomicilio, 5),
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
                //Si es tipo de documento es cédula jurida
                if (detalle.tip_docum == "CJU")
                {
                    detalle.mca_fisico = "N";
                }

                datoFijo.DetalleDeTerceros.Add(detalle);

            }

            return datoFijo;
        }

        internal static Architect.API.Tron.Contracts.Cotizacion.Viajero MapperBase(Domain.Poliza.Emision.Poliza risk)
        {
            List<Domain.Poliza.Emision.DatosVariables> datosvariables = risk.Datos_Variables;

            string cod_producto = risk.Datos_Generales.cod_producto;
            string tip_plan = cod_producto.Substring(cod_producto.IndexOf("-") + 1, 1);
            string tip_viaje = cod_producto.Substring(cod_producto.IndexOf("-") + 2, 1);


            Architect.API.Tron.Contracts.Cotizacion.Viajero quote = new Architect.API.Tron.Contracts.Cotizacion.Viajero()
            {
                cod_mon = risk.Datos_Generales.moneda,
                cod_fracc_pago = risk.Datos_Generales.cod_fracc_pago,
                fec_efec_poliza = risk.Datos_Generales.fec_efec_poliza,
                fec_vcto_poliza = risk.Datos_Generales.fec_vcto_poliza,
                TIP_PLAN = tip_plan,
                TIP_VIAJE = tip_viaje,
                FEC_VIAJE = DateTimeValue(datosvariables, "FEC_VIAJE"),
                DES_DESTINO = StringValue(datosvariables, "DES_DESTINO"),
                FEC_NACIMIENTO = DateTimeValue(datosvariables, "FEC_NACIMIENTO"),
                FEC_NACIMIENTO2 = DateTimeValue(datosvariables, "FEC_NACIMIENTO2"),
                FEC_NACIMIENTO3 = DateTimeValue(datosvariables, "FEC_NACIMIENTO3"),
                FEC_NACIMIENTO4 = DateTimeValue(datosvariables, "FEC_NACIMIENTO4"),
                FEC_NACIMIENTO5 = DateTimeValue(datosvariables, "FEC_NACIMIENTO5"),
                FEC_NACIMIENTO6 = DateTimeValue(datosvariables, "FEC_NACIMIENTO6"),
                FEC_NACIMIENTO7 = DateTimeValue(datosvariables, "FEC_NACIMIENTO7"),
                FEC_NACIMIENTO8 = DateTimeValue(datosvariables, "FEC_NACIMIENTO8"),
                FEC_NACIMIENTO9 = DateTimeValue(datosvariables, "FEC_NACIMIENTO9"),
                FEC_NACIMIENTO10 = DateTimeValue(datosvariables, "FEC_NACIMIENTO10"),
                COD_MODALIDAD = risk.Datos_Generales.cod_modalidad,
                cantidad_riesgos = IntegerValue(datosvariables, "CANTIDAD_RIEGOS"),
                coberturas = new List<Architect.API.Tron.Contracts.Comun.Cobertura>()
            };

            foreach (Domain.Poliza.Emision.Cobertura riskCover in risk.Coberturas)
            {
                quote.coberturas.Add(new Architect.API.Tron.Contracts.Comun.Cobertura() { codigo = riskCover.codigo });
            }

            return quote;
        }

        internal static int IntegerValue(List<Domain.Poliza.Emision.DatosVariables> datosvariables, string name)
        {
            int result = Convert.ToInt32(datosvariables.Find(r => r.nombre == name).valor);

            return result;

        }
        internal static string StringValue(List<Domain.Poliza.Emision.DatosVariables> datosvariables, string name)
        {
            string result = datosvariables.Find(r => r.nombre == name).valor;

            return result;

        }
        internal static DateTime DateTimeValue(List<Domain.Poliza.Emision.DatosVariables> datosvariables, string name)
        {
            DateTime result = Convert.ToDateTime(datosvariables.Find(r => r.nombre == name).valor);

            return result;

        }

        internal static int IntegerValue(List<Domicilio> detalleDomicilio, int nivel)
        {
            int result = Convert.ToInt32(detalleDomicilio.Find(r => r.nivel == nivel).valor);

            return result;

        }
        internal static string StringValue(List<Domicilio> detalleDomicilio, int nivel)
        {
            string result = detalleDomicilio.Find(r => r.nivel == nivel).valor;

            return result;

        }

    }

}
