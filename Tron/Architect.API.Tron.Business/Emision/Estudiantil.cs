using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Architect.API.Tron.Business.Emision
{
    /// <summary>
    /// Emision de Poliza Viajero en TRON
    /// </summary>
    public static class Estudiantil
    {

        public static Contracts.Emision.Estudiantil Setup(string presupuesto, string mode, Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Emision.Estudiantil result = null;
            string key = string.Format("estudiantil.{0}", presupuesto);

            if (mode == "resume")
            {
                //Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(presupuesto, tokenInfo.CompanyId);

                Contracts.Presupuesto.DatoFijo P30Instance = DataAccess.LeerPresupuesto.Presupuesto(1, presupuesto, 0, 0, 0, null, true);
                Contracts.Cotizacion.Estudiantil resultInfo2 = Cotizacion.EstudiantilConvert.FromTron_Full(P30Instance);

                resultInfo2.coberturas.Remove(resultInfo2.coberturas.Find(r => r.codigo == 9998));

                Utilities.Cache.SetItem(key, Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo2), -1);
            }

            if (Architect.Utilities.Cache.Exist(key))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.Estudiantil>(Architect.Utilities.Cache.GetItem(key).ToString());

                //result.terceros = Default_Terceros(result);

                result.terceros = Reglas.research.Apply_Terceros("Estudiantil", result.terceros, string.Empty, tokenInfo);

                result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos("Estudiantil", null, 0, tokenInfo);

            }

            return result;
        }
        private static List<Contracts.Comun.tercero> Default_Terceros(Contracts.Emision.Estudiantil quoteInfo)
        {
            List<Contracts.Comun.tercero> result = new List<Contracts.Comun.tercero>();
            DateTime[] values = { DateTime.MinValue, quoteInfo.FEC_NACIMIENTO};
            
                result.Add(new Contracts.Comun.tercero()
                {
                    tercerosId = 1,
                    tipodetercero = 2, //Asegurado
                    tipodeterceroDesc = Reglas.research.tip_benef_lookup(2),
                    DocumentNumberType = 0,
                    DocumentNumber = string.Empty,
                    nombre = string.Empty,
                    apellido1 = null,
                    apellido2 = null,
                    fechadenacimiento = values[1],
                    tercerosMca_sexo = 0,
                    tercerosMca_sexoDesc = string.Empty,
                    estadoCivil = string.Empty,
                    estadoCivilDesc = string.Empty,
                    numerodetelefono = string.Empty,
                    correoelectronico = string.Empty,
                    cod_pais = "CRI",
                    TProvincia = 0,
                    TProvinciaDesc = string.Empty,
                    TCanton = 0,
                    TCantonDesc = string.Empty,
                    TDistrito = 0,
                    TDistritoDesc = string.Empty,
                    otrasenas = string.Empty,
                    eltomadoreselmismoasegurado = 2,
                    elaseguradoeselconductorhabitual = 0,
                    numerodeprestamo = null,
                    importedecesion = 0,
                    vencimientodecesion = DateTime.MinValue,
                    porcentajeacredor = 0,
                    parentesco = 0,
                    porcentaje = 0,
                    NoEditable = false,
                });
            

            return result;
        }

        public static Contracts.Emision.Estudiantil Issue(Contracts.Emision.Estudiantil quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {

            Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = EstudiantilConvertTo.Tron(quoteInfo);

            Architect.API.Tron.Contracts.Poliza.DatoFijo result2 = Backoffice.Emision.Generico.Emitir(result, tokenInfo);

            Contracts.Emision.Estudiantil resultQuoteInfo = EstudiantilConvertFrom.Quote(quoteInfo, result2);

            resultQuoteInfo.num_poliza = result2.num_poliza;

            if (resultQuoteInfo.num_poliza.IsNotEmpty())
            {
                Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultQuoteInfo.num_poliza.Substring(4)), tokenInfo.CompanyId, "Emisión Seguro de Estudiantil", "Póliza #" + resultQuoteInfo.num_poliza, tokenInfo.UserId, resultQuoteInfo);

                //Se cambian los adjuntos creados al número de presupuesto al número de póliza generado
                Core.Business.General.Attachment.ChangeEntityId(tokenInfo.CompanyId, 3000, Convert.ToInt64(resultQuoteInfo.presupuesto), 3000, Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.UserId);
            }
            return resultQuoteInfo;
        }

    }
}
