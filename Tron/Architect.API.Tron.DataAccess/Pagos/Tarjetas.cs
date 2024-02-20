using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Pagos
{
    public static class Tarjetas
    {

        /// <summary>
        /// Extrae la información de tarjetas a ser tokenizadas.
        /// </summary>
        public static List<Contracts.Pagos.Tarjeta> PendientesPorTokenizar(int cod_cia, int fetchRows)
        {
            List<Contracts.Pagos.Tarjeta> result = new List<Contracts.Pagos.Tarjeta>();
            string filter = string.Empty;

            //TODO: Falta definir condición para saber que la tarjeta ya fue tokenizada
            Database.Select(@"SELECT A99.MCA_FISICO, A99.TIP_DOCUM, A99.COD_DOCUM, A99.NOM_TERCERO, A99.NOM2_TERCERO, A99.APE1_TERCERO, A99.APE2_TERCERO, 
                                   A99.TLF_MOVIL, A31.TLF_NUMERO, A31.FAX_NUMERO,A31.EMAIL, A31.EMAIL_COM, A31.TXT_EMAIL,
                                   A31.TIP_TARJETA, A21.NOM_TIP_TARJETA, A31.COD_TARJETA, A22.NOM_TARJETA, A31.NUM_TARJETA, A31.FEC_VCTO_TARJETA 
                              FROM A1001399 A99
                              LEFT JOIN A1001331 A31 ON A31.COD_CIA=A99.COD_CIA AND A31.TIP_DOCUM=A99.TIP_DOCUM AND A31.COD_DOCUM=A99.COD_DOCUM
                              LEFT JOIN A5020021 A21 ON A21.TIP_TARJETA=A31.TIP_TARJETA
                              LEFT JOIN A5020022 A22 ON A22.COD_CIA=A99.COD_CIA AND A22.TIP_TARJETA=A31.TIP_TARJETA AND A22.COD_TARJETA=A31.COD_TARJETA
                             WHERE A99.COD_CIA=:cod_cia AND NOT A31.NUM_TARJETA IS NULL AND INSTR(A31.NUM_TARJETA, '*')=0 FETCH FIRST :fetchRows ROWS ONLY")
                    .AddParameter("cod_cia", DbType.Int32, 22, cod_cia)
                    .AddParameter("fetchRows", DbType.Int32, 22, fetchRows)
                    .Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result.Add(new Architect.API.Tron.Contracts.Pagos.Tarjeta()
                        {
                            MCA_FISICO = reader.StringValue("MCA_FISICO") == "S",
                            TIP_DOCUM = reader.StringValue("TIP_DOCUM"),
                            COD_DOCUM = reader.StringValue("COD_DOCUM"),
                            NOM_TERCERO = reader.StringValue("NOM_TERCERO"),
                            NOM2_TERCERO = reader.StringValue("NOM2_TERCERO"),
                            APE1_TERCERO = reader.StringValue("APE1_TERCERO"),
                            APE2_TERCERO = reader.StringValue("APE2_TERCERO"),
                            TLF_MOVIL = reader.StringValue("TLF_MOVIL"),
                            TLF_NUMERO = reader.StringValue("TLF_NUMERO"),
                            FAX_NUMERO = reader.StringValue("FAX_NUMERO"),
                            EMAIL = reader.StringValue("EMAIL"),
                            EMAIL_COM = reader.StringValue("EMAIL_COM"),
                            TXT_EMAIL = reader.StringValue("TXT_EMAIL"),
                            TIP_TARJETA = reader.IntegerValue("TIP_TARJETA"),
                            NOM_TIP_TARJETA = reader.StringValue("NOM_TIP_TARJETA"),
                            COD_TARJETA = reader.IntegerValue("COD_TARJETA"),
                            NOM_TARJETA = reader.StringValue("NOM_TARJETA"),
                            NUM_TARJETA = reader.StringValue("NUM_TARJETA"),
                            FEC_VCTO_TARJETA = reader.DateTimeValue("FEC_VCTO_TARJETA")
                        });
                    }));

            return result;
        }

    }
}