using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
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
        public async static Task<Architect.API.Insurance.Contracts.Policy.Insured> TerceroPorIdentificacion(string identificacion, int docType)
        {
            Architect.API.Insurance.Contracts.Policy.Insured result = null;
            try
            {
                if (docType == 1 && identificacion[0] == '0')
                {
                    identificacion = identificacion.Substring(1);
                }			 
                Database.Select("SELECT A99.COD_DOCUM, A99.NOM_TERCERO, A99.NOM2_TERCERO, A99.APE1_TERCERO, A99.APE2_TERCERO,  A31.FEC_NACIMIENTO, NVL(A31.EMAIL, A31.EMAIL_COM) EMAIL, NVL(A31.COD_ESTADO, A31.COD_ESTADO_COM) COD_ESTADO, NVL(A31.COD_PROV, A31.COD_PROV_COM) COD_PROV, NVL(A31.COD_LOCALIDAD, A31.COD_LOCALIDAD_COM) COD_LOCALIDAD, NVL(A31.NOM_DOMICILIO1, A31.NOM_DOMICILIO1_COM) NOM_DOMICILIO1, NVL(A31.NOM_DOMICILIO2, A31.NOM_DOMICILIO2_COM) NOM_DOMICILIO2, NVL(A31.NOM_DOMICILIO3, A31.NOM_DOMICILIO3_COM) NOM_DOMICILIO3, NVL(A31.TLF_NUMERO, A31.TLF_NUMERO_COM) TLF_NUMERO,  A31.MCA_SEXO,  A31.COD_EST_CIVIL " +
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
                                case "C":
                                    result.CivilStatus = 1;  // Casado(a)
                                    break;
                                case "D":
                                    result.CivilStatus = 2;  // Divorciado(a)
                                    break;
                                case "S":
                                    result.CivilStatus = 3;  // Soltero(a)
                                    break;
                                case "V":
                                    result.CivilStatus = 4;  // Viudo(a)
                                    break;
                                case "A":
                                    result.CivilStatus = 6;  // Acompañado(a)
                                    break;
                                default:
                                    result.CivilStatus = 5; //5 Otro
                                    break;
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
