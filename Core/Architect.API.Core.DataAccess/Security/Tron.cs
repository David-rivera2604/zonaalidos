using Architect.API.Core.Contracts.Security;
using Architect.DataFactory;
using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using System;
using System.ComponentModel.Design;
using System.Data;
using System.Text.Json;
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
                         .Query(null, "Tron", new Action<System.Data.IDataReader>((reader) =>
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
        public static string RetrieveAgentEMailByDocument(string tip_docum, string cod_docum)
        {
            string result = string.Empty;
            Database.Select(
@"SELECT a32.EMAIL_COM FROM A1001332 a32 WHERE a32.TIP_DOCUM = :TIP_DOCUM1 AND a32.COD_DOCUM=:COD_DOCUM1
UNION
SELECT a37.EMAIL_COM FROM A1001337 a37 WHERE a37.TIP_DOCUM = :TIP_DOCUM2 AND a37.COD_DOCUM=:COD_DOCUM2
FETCH FIRST 1 ROWS ONLY")
                         .AddParameter("TIP_DOCUM1", DbType.String, 3, tip_docum)
                         .AddParameter("COD_DOCUM1", DbType.String, 20, cod_docum)
                         .AddParameter("TIP_DOCUM2", DbType.String, 3, tip_docum)
                         .AddParameter("COD_DOCUM3", DbType.String, 20, cod_docum)
                         .Query(null, "Tron", new Action<System.Data.IDataReader>((reader) =>
                         {
                             result = reader.StringValue("EMAIL_COM");
                         }));

            return result;
        }

        /// <summary>
        /// Crea un subagente en TRON.
        /// </summary>
        /// <returns>Cantidad de registros creados.</returns>
        public static bool Create_subAgent(Contracts.Security.SubAgent subagentItem, IDbConnection connection = null)
        {

            string json_tercero = "";
            try
            {
                if (subagentItem.cod_agt != 999999)
                {
                    subagentItem.cod_emp_agt = cod_SubAgent(subagentItem.tip_docum, subagentItem.cod_docum, subagentItem.cod_agt);
                    json_tercero = JsonSerializer.Serialize(subagentItem);

                    return Database.Procedure(@"em_k_mapfre_batch_contract_mcr.em_p_crea_terceros")
                    .AddParameter("p_dat_asegurado", DbType.String, 8000, json_tercero)
                    .AddParameter("p_errores", DbType.RefCursor, 0, null, ParameterDirection.Output)
                    .Execute(connection, "Tron") != 0;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public static int cod_SubAgent(string tip_docum, string cod_docum, int cod_agt)
        {
            int resultado = 0;
            Database.Select(@"select 
                                nvl(em_k_tables_contract_mcr.fc_cod_subagente(p_tip_docum => :tip_docum,
                                                                          p_cod_docum => :p_cod_docum,
                                                                          p_cod_agt => :p_cod_agt),0) cod_sub_agt
                            from dual")
                         .AddParameter("p_tip_docum", DbType.String, 50, tip_docum)
                         .AddParameter("p_cod_docum", DbType.String, 50, cod_docum)
                         .AddParameter("p_cod_agt", DbType.Int32, 50, cod_agt)
                         .Query(null, "Tron", new Action<System.Data.IDataReader>((reader) =>
                         {
                             resultado = Convert.ToInt32(reader.StringValue("cod_sub_agt"));
                         }));

            return resultado;
        }

    }
}