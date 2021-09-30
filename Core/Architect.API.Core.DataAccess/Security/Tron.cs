using System;
using System.Data;
using Architect.Common.Extensions;
using Architect.Common.Proxy;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Architect.API.Core.DataAccess.Security
{
    public sealed partial class Tron
    {
        public static Contracts.Security.AgentInformation RetrieveAgentInformationByEmail(int companyId, string email)
        {
            string l_fec_validez = string.Format("{0}{1}{2}", DateAndTime.Today.Year, DateAndTime.Today.Month.ToString().PadLeft(2, '0'), DateAndTime.Today.Day.ToString().PadLeft(2, '0'));
            DataTable rows = null;
            Contracts.Security.AgentInformation result = null;
            {
                var withBlock = new DataManagerFactory(true, "em_k_Tables_Contract_mcr.em_p_retrieve_by_email_com", "Tron");
                withBlock.AddParameter("P_COD_CIA", DbType.Decimal, 5, false, companyId);
                withBlock.AddParameter("P_FEC_VALIDEZ", DbType.String, 15, false, l_fec_validez);
                withBlock.AddParameter("P_EMAIL_COM", DbType.String, 60, false, email);
                rows = withBlock.ProcedureExecuteToTable(true);
                if (rows.IsNotEmpty() && rows.Rows.Count != 0)
                {
                    result = new Contracts.Security.AgentInformation()
                    {
                        cod_agt = (int)Math.Round(rows.FirstRow().NumericValue("cod_agt")),
                        cod_sub_agt = Conversions.ToInteger(rows.FirstRow().StringValue("sub_agt")),
                        info_agt = rows.FirstRow().StringValue("info_agt"),
                        tip_docum = rows.FirstRow().StringValue("tip_docum"),
                        cod_docum = rows.FirstRow().StringValue("cod_docum")
                    };
                }
            }

            return result;
        }

        public static Contracts.Security.ClientInformation RetrieveClientInformationByDocument(string tip_docum, string cod_docum)
        {
            DataTable rows = null;
            Contracts.Security.ClientInformation result = null;
            cod_docum = Convert.ToInt64(cod_docum.OnlyNumbers()).ToString();
            {
                var withBlock = new DataManagerFactory("SELECT EMAIL" + "  FROM A1001331 " + " WHERE TIP_DOCUM=@:TIP_DOCUM AND COD_DOCUM=@:COD_DOCUM", "Tron");
                withBlock.AddParameter("TIP_DOCUM", DbType.String, 3, false, tip_docum);
                withBlock.AddParameter("COD_DOCUM", DbType.String, 20, false, cod_docum);
                rows = withBlock.QueryExecuteToTable(true);
                if (rows.IsNotEmpty() && rows.Rows.Count != 0)
                {
                    result = new Contracts.Security.ClientInformation()
                    {
                        tip_docum = tip_docum,
                        cod_docum = cod_docum,
                        email = rows.FirstRow().StringValue("EMAIL")
                    };
                }
            }

            return result;
        }
    }
}