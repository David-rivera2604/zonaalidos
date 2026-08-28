using Architect.API.Insurance.Contracts.Policy;
using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Threading.Tasks;
using DbType = Architect.DataFactory.Enumerations.DbType;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace Architect.Extend.Integrations.Tron
{
    /// <summary>
    /// Consultas de integración por parte de Tron.
    /// </summary>
    public sealed partial class UpdateCliente
    {
        public static int UpdateDatosCliente(Insured DatosClientesItem, IDbConnection connection = null)
        {
            if (DatosClientesItem.DocumentType == 1)
            {
                var removeLine = DatosClientesItem.DocumentNumber.Replace("-", string.Empty);
                var numberChanged = removeLine.Remove(0, 1);
                DatosClientesItem.DocumentNumber = numberChanged;
            }
            else if (DatosClientesItem.DocumentType == 2)
            {
                var removeLine = DatosClientesItem.DocumentNumber.Replace("-", string.Empty);
                DatosClientesItem.DocumentNumber = removeLine;
            }

            return Database.Update("UPDATE A1001399 A99 " +
                 "SET A99.COD_DOCUM=:DocumentNumber, A99.NOM_TERCERO=:FirstName, A99.APE1_TERCERO=:LastName, A99.APE2_TERCERO=:SecondLastName " +
                 "WHERE A99.COD_CIA=1 AND A99.COD_DOCUM=:DocumentNumberWhere")
            .AddParameter("COD_DOCUM", DbType.String, 20, DatosClientesItem.DocumentNumber)
            .AddParameter("NOM_TERCERO", DbType.String, 180, DatosClientesItem.FirstName)
            .AddParameter("APE1_TERCERO", DbType.String, 30, DatosClientesItem.LastName)
            .AddParameter("APE2_TERCERO", DbType.String, 30, DatosClientesItem.SecondLastName)
            .AddParameter("DocumentNumberWhere", DbType.String, 20, DatosClientesItem.DocumentNumber)
            .Execute(connection, "Research");

        }

        public static int UpdateClienteContacto(Insured DatosClientesItem, IDbConnection connection = null)
        {
            string civilStatus = "0";
            DatosClientesItem.BirthDate = DateTime.ParseExact(Convert.ToString(DatosClientesItem.BirthDate), "M/d/yyyy H:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            switch (DatosClientesItem.CivilStatus.ToString())
            {
                case "1":
                    civilStatus = "C";  // Casado(a)
                    break;
                case "2":
                    civilStatus = "D";  // Divorciado(a)
                    break;
                case "3":
                    civilStatus = "S";  // Soltero(a)
                    break;
                case "4":
                    civilStatus = "V";  // Viudo(a)
                    break;
                case "6":
                    civilStatus = "A";  // Acompañado(a)
                    break;
                default:
                    civilStatus = "5"; //5 Otro
                    break;
            }

            return Database.Update("UPDATE A1001331 A31 " +
                 "SET A31.COD_DOCUM=:DocumentNumber, A31.FEC_NACIMIENTO=:BirthDate, A31.MCA_SEXO=:Gender, A31.COD_EST_CIVIL=:CivilStatus, A31.TLF_NUMERO=:PhoneNumber, A31.EMAIL=:PrimaryEmailAddress, " +
                 "A31.COD_PAIS='CRI', A31.COD_ESTADO=:Province, A31.COD_PROV=:Canton, A31.COD_LOCALIDAD=:District, A31.NOM_DOMICILIO1=:AddressDetail " +
                 "WHERE A31.COD_CIA=1 AND A31.COD_DOCUM=:DocumentNumberWhere")
            .AddParameter("COD_DOCUM", DbType.String, 20, DatosClientesItem.DocumentNumber)
            .AddParameter("FEC_NACIMIENTO", DbType.Date, 0, DatosClientesItem.BirthDate)
            .AddParameter("MCA_SEXO", DbType.String, 1, DatosClientesItem.Gender)
            .AddParameter("COD_EST_CIVIL", DbType.String, 1, civilStatus)
            .AddParameter("TLF_NUMERO", DbType.String, 10, DatosClientesItem.PhoneNumber)
            .AddParameter("EMAIL", DbType.String, 95, DatosClientesItem.PrimaryEmailAddress)
            .AddParameter("COD_ESTADO", DbType.Decimal, 3, DatosClientesItem.Province)
            .AddParameter("COD_PROV", DbType.Decimal, 6, DatosClientesItem.Canton)
            .AddParameter("COD_LOCALIDAD", DbType.Decimal, 6, DatosClientesItem.District)
            .AddParameter("NOM_DOMICILIO1", DbType.String, 40, DatosClientesItem.AddressDetail)
            .AddParameter("DocumentNumberWhere", DbType.String, 20, DatosClientesItem.DocumentNumber)
            .Execute(connection, "Research");
        }
    }

}