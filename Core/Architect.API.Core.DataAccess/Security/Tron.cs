using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.Security
{
    public sealed partial class Tron
    {
        public static Contracts.Security.AgentInformation RetrieveAgentInformationByEmail(int companyId, string email)
        {
            string l_fec_validez = string.Format("{0}{1}{2}", DateTime.Today.Year, DateTime.Today.Month.ToString().PadLeft(2, '0'), DateTime.Today.Day.ToString().PadLeft(2, '0'));
            Contracts.Security.AgentInformation result = null;

            Database.Procedure(@"em_k_Tables_Contract_mcr.em_p_retrieve_by_email_com")
                .AddParameter("P_COD_CIA", DbType.Decimal, 5, companyId)
                .AddParameter("P_FEC_VALIDEZ", DbType.String, 15, l_fec_validez)
                .AddParameter("P_EMAIL_COM", DbType.String, 60, email)
                .AddParameter("RC1", DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                .Query(null, "Tron", new Action<IDataReader>((reader) =>
                {
                    result = new Contracts.Security.AgentInformation()
                    {
                        cod_agt = reader.IntegerValue("cod_agt"),
                        cod_sub_agt = reader.IntegerValue("sub_agt"),
                        info_agt = reader.StringValue("info_agt"),
                        tip_docum = reader.StringValue("tip_docum"),
                        cod_docum = reader.StringValue("cod_docum")
                    };
                }));

            return result;
        }

        public static Contracts.Security.ClientInformation RetrieveClientInformationByDocument(string tip_docum, string cod_docum)
        {
            Contracts.Security.ClientInformation result = null;
            Database.Select(@"SELECT EMAIL
                               FROM A1001331
                              WHERE TIP_DOCUM=:TIP_DOCUM AND COD_DOCUM=:COD_DOCUM")
                         .AddParameter("TIP_DOCUM", DbType.String, 3, tip_docum)
                         .AddParameter("COD_DOCUM", DbType.String, 20, cod_docum)
                         .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                         {
                             result = new Contracts.Security.ClientInformation()
                             {
                                 tip_docum = tip_docum,
                                 cod_docum = cod_docum,
                                 email = reader.StringValue("EMAIL")
                             };
                         }));

            return result;
        }
    }
}