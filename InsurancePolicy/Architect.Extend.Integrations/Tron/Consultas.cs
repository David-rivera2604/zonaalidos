using Architect.DataFactory;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.Extend.Integrations.Tron
{
    /// <summary>
    /// Consultas de integración por parte de Tron.
    /// </summary>
    public static class Consultas
    {
        /// <summary>
        /// Permite recuperar la información de una persona en la tabla de tercero de tron por medio de su identificación.
        /// </summary>
        public async static Task<Architect.API.Insurance.Contracts.Policy.Insured> TerceroPorIdentificacion(string identificacion)
        {
            Architect.API.Insurance.Contracts.Policy.Insured result = null;
            try
            {
                Database.Select("SELECT A99.*, A31.* " +
                              "FROM A1001399 A99 " +
                              "LEFT JOIN A1001331 A31 ON A31.COD_CIA=A99.COD_CIA AND A31.TIP_DOCUM=A99.TIP_DOCUM AND A31.COD_DOCUM=A99.COD_DOCUM " +
                             "WHERE A99.COD_CIA=1 AND A99.COD_DOCUM=:COD_DOCUM")
                        .AddParameter("COD_DOCUM", DbType.AnsiString, 20, identificacion)
                        .Query(null, "Tron", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = new Architect.API.Insurance.Contracts.Policy.Insured()
                            {
                                DocumentType = 1,
                                DocumentNumber = reader.StringValue("COD_DOCUM"),
                                FirstName = reader.StringValue("NOM_TERCERO").Capitalize(),
                                MiddleName = reader.StringValue("NOM2_TERCERO").Capitalize(),
                                LastName = reader.StringValue("APE1_TERCERO").Capitalize(),
                                SecondLastName = reader.StringValue("APE2_TERCERO").Capitalize(),
                                BirthDate = reader.DateTimeValue("FEC_NACIMIENTO"),
                                Gender = 0,
                                CivilStatus = 0,
                                PrimaryEmailAddress = reader.StringValue("EMAIL"),
                                Province = reader.IntegerValue("COD_ESTADO"),
                                Canton = reader.IntegerValue("COD_PROV"),
                                District = reader.IntegerValue("COD_LOCALIDAD"),
                                AddressDetail = reader.StringValue("NOM_DOMICILIO1").Capitalize(),
                                PhoneType = 1,
                                PhoneNumber = reader.StringValue("TLF_NUMERO"),
                                Source = "Tron"
                            };
                            if (reader.StringValue("NOM_DOMICILIO2").IsNotEmpty())
                            {
                                result.AddressDetail = result.AddressDetail + " " + reader.StringValue("NOM_DOMICILIO2").Capitalize();
                            }
                            if (reader.StringValue("NOM_DOMICILIO3").IsNotEmpty())
                            {
                                result.AddressDetail = result.AddressDetail + " " + reader.StringValue("NOM_DOMICILIO3").Capitalize();
                            }
                            switch (reader.StringValue("MCA_SEXO"))
                            {
                                case "F":
                                case "1":
                                    result.Gender = 2;
                                    break;
                                case "M":
                                case "0":
                                    result.Gender = 1;
                                    break;
                            }
                            switch (reader.StringValue("COD_EST_CIVIL"))
                            {
                                case "S":
                                    result.CivilStatus = 3;  // Soltero(a)
                                    break;
                                case "C":
                                    result.CivilStatus = 1;  // Casado(a)
                                    break;
                                default:
                                    result.CivilStatus = 5; //5 Otro
                                    break;
                                    //2 Divorciado(a)
                                    //4 Viudo(a)
                                    //6 Acompañado(a)
                            }

                        }));
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog("Tron.TerceroPorIdentificacion",
                                                         string.Format("Falla al tratar de consultar a identificación '{0}'", identificacion),
                                                         ex, "integrations");
            }
            return result;
        }
    }
}
