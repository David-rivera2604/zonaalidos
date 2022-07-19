using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Threading.Tasks;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.Extend.Integrations.My
{
    /// <summary>
    /// Consultas de integración por parte del Instituto Nacional de Seguros.
    /// </summary>
    public static class Consultas
    {
        /// <summary>
        /// Permite recuperar la información de una personal en el padron por medio de su identificación.
        /// </summary>
        public async static Task<Architect.API.Insurance.Contracts.Policy.Insured> PersonaPorIdentificacion(string identificacion)
        {
            Architect.API.Insurance.Contracts.Policy.Insured result = null;


            try
            {
                identificacion = identificacion.OnlyNumbers();
                Database.Select("SELECT CEDULA, INITCAP(RTRIM (NOMBRE)) NOMBRE, INITCAP(RTRIM(APELLIDO1)) APELLIDO1, INITCAP(RTRIM(APELLIDO2)) APELLIDO2, SEXO, CASE WHEN SEXO=1 THEN 'Masculino' ELSE 'Femenino' END SEXODESC, TO_DATE (FECHACADUC, 'yyyymmdd') FECHACADUC, " +
                                        "PROVINCIA.CODE PROVINCIA_CODE, PROVINCIA.DESCRIPTION PROVINCIA, CANTON.CODE CANTON_CODE, CANTON.DESCRIPTION CANTON, DISTRITO.CODE DISTRITO_CODE, DISTRITO.DESCRIPTION DISTRITO, INITCAP(RTRIM(CR_DISTELEC.DISTRITO)) DISTRITO_ELEC " +
                                  "FROM CR_PADRON " +
                                  "LEFT JOIN LOOKUP PROVINCIA ON PROVINCIA.LOOKUPID = 1001 AND PROVINCIA.CODE = SUBSTR (CODELEC, 1, 1) " +
                                  "LEFT JOIN LOOKUP CANTON    ON CANTON.LOOKUPID = 1002 AND CANTON.CODE = SUBSTR (CODELEC, 1, 3) " +
                                  "LEFT JOIN LOOKUP DISTRITO  ON DISTRITO.LOOKUPID = 1003 AND DISTRITO.CODE = SUBSTR (CODELEC, 1, 3) || SUBSTR (CODELEC, 5, 2) " +
                                  "LEFT JOIN CR_DISTELEC ON CR_DISTELEC.CODELE = CR_PADRON.CODELEC " +
                                 "WHERE CR_PADRON.CEDULA=:CEDULA")
                        .AddParameter("CEDULA", DbType.Decimal, 9, identificacion)
                        .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = new Architect.API.Insurance.Contracts.Policy.Insured()
                            {
                                DocumentType = 1,
                                DocumentNumber = reader.StringValue("CEDULA"),
                                FirstName = reader.StringValue("NOMBRE").Capitalize(),
                                MiddleName = string.Empty,
                                LastName = reader.StringValue("APELLIDO1").Capitalize(),
                                SecondLastName = reader.StringValue("APELLIDO2").Capitalize(),
                                BirthDate = DateTime.MinValue,
                                Gender = reader.IntegerValue("SEXO"),
                                CivilStatus = 0,
                                PrimaryEmailAddress = string.Empty,
                                Province = reader.IntegerValue("PROVINCIA_CODE"),
                                Canton = reader.IntegerValue("CANTON_CODE"),
                                District = reader.IntegerValue("DISTRITO_CODE"),
                                AddressDetail = string.Empty,
                                PhoneType = 0,
                                PhoneNumber = string.Empty,
                                Source = "Padron"
                            };

                        }));
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("My.PersonaPorIdentificacion",
                                                         string.Format("Falla al tratar de consultar a identificación '{0}'", identificacion),
                                                         ex, "integrations");
            }
            return result;
        }
    }
}
