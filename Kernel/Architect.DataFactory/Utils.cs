using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Architect.DataFactory
{
    public static class Utils
    {

        public static System.Data.DataTable StatementExecute(string statement, int statementType, string connectionName, Dictionary<string, string> values, bool withCache, string prefix= null)
        {
            System.Data.DataTable records = null;
            MatchCollection parameterMatches = Regex.Matches(statement, @"{(.+?)}"); // ([^)]*)

            if(Utilities.Helpers.Settings.StringValue("Working.Mode") == "Development")
            {
                withCache = false;
            }

            if (statementType == 2) //Procedure
            {
                foreach (Match paremeter in parameterMatches)
                {
                    statement = statement.Replace(paremeter.Value, string.Empty).Trim();
                }
                using (DataFactory.Database db = Architect.DataFactory.Database.Procedure(statement).Cache(withCache, prefix))
                {
                    ProcessParameters(parameterMatches, values, db);
                    records = db.Query(null, connectionName);
                }
            }
            else
            {
                string name = string.Empty;
                foreach (Match paremeter in parameterMatches)
                {
                    name = paremeter.Value;
                    name = name.Replace(":date", string.Empty);
                    name = name.Replace(":varchar", string.Empty);
                    name = name.Replace(".", "_");
                    name = name.Replace("{", ":").Replace("}", "");
                    statement = statement.Replace(paremeter.Value, name);
                }
                using (DataFactory.Database db = Architect.DataFactory.Database.Select(statement).Cache(withCache, prefix))
                {
                    ProcessParameters(parameterMatches, values, db);
                    records = db.Query(null, connectionName);
                }
            }
            return records;
        }
        internal static void ProcessParameters(MatchCollection parameterMatches, Dictionary<string, string> values, DataFactory.Database dataManager)
        {
            string name = string.Empty;
            string rawValue = string.Empty;
            bool isDate = false;
            bool isVarChar = false;
            bool isCursor = false;
            bool isInput = true;
            object value = null;
            System.Data.ParameterDirection direction;

            if (parameterMatches.Count > 0)
            {

                foreach (Match paremeter in parameterMatches)
                {
                    if (paremeter.Groups[1].Value.StartsWith("app.", StringComparison.CurrentCultureIgnoreCase))
                    {
                        switch (paremeter.Groups[1].Value.ToLower())
                        {
                            case "app.companyid":
                                dataManager.AddParameter(paremeter.Groups[1].Value, Architect.DataFactory.Enumerations.DbType.Int32, 0, values["Token.CompanyId"]);
                                break;

                            case "app.userid":
                                dataManager.AddParameter(paremeter.Groups[1].Value, Architect.DataFactory.Enumerations.DbType.Int32, 0, values["Token.UserId"]);
                                break;

                            case "app.p_cod_cia":
                                dataManager.AddParameter(paremeter.Groups[1].Value, Architect.DataFactory.Enumerations.DbType.Int32, 0, Int32.Parse(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]));
                                break;

                            case "app.agentcode":
                            case "app.p_cod_agt":
                                dataManager.AddParameter(paremeter.Groups[1].Value, Architect.DataFactory.Enumerations.DbType.Int32, 0, values["Token.AgentCode"]);
                                break;

                            case "app.subagentcode":
                            case "app.p_cod_sub_agt":
                                dataManager.AddParameter(paremeter.Groups[1].Value, Architect.DataFactory.Enumerations.DbType.Int32, 0, values["Token.SubAgentCode"]);
                                break;

                            case "app.tip_docum":
                                dataManager.AddParameter(paremeter.Groups[1].Value, Architect.DataFactory.Enumerations.DbType.String, 0, values["Token.IdentificationType"]);
                                break;

                            case "app.cod_docum":
                                dataManager.AddParameter(paremeter.Groups[1].Value, Architect.DataFactory.Enumerations.DbType.String, 0, values["Token.Identification"]);
                                break;

                        }
                    }
                    else if (paremeter.Groups[1].Value.StartsWith("const.", StringComparison.CurrentCultureIgnoreCase))
                    {
                        rawValue = paremeter.Groups[1].Value.Substring(6);

                        if (rawValue.StartsWith("date.today", StringComparison.CurrentCultureIgnoreCase))
                        {
                            dataManager.AddParameter(name, Architect.DataFactory.Enumerations.DbType.Date, 0, DateTime.Today);
                        }
                        else if (rawValue.StartsWith("date.", StringComparison.CurrentCultureIgnoreCase))
                        {
                            value = DateTime.ParseExact(rawValue.Substring(5), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                            dataManager.AddParameter(paremeter.Groups[1].Value, Architect.DataFactory.Enumerations.DbType.Date, 0, value);
                        }
                        else if (rawValue.StartsWith("numeric.", StringComparison.CurrentCultureIgnoreCase))
                        {
                            value = Convert.ToInt32(rawValue.Substring(8));
                            dataManager.AddParameter(name, Architect.DataFactory.Enumerations.DbType.Int32, 0, value);
                        }
                        else
                        {
                            dataManager.AddParameter(paremeter.Groups[1].Value, Architect.DataFactory.Enumerations.DbType.String, 0, rawValue);
                        }
                    }
                    else
                    {
                        name = paremeter.Groups[1].Value;
                        isDate = false;
                        isVarChar = false;
                        isCursor = false;
                        isInput = true;
                        if (name.EndsWith(":date"))
                        {
                            name = name.Substring(0, name.Length - 5);
                            isDate = true;
                        }
                        else if (name.EndsWith(":varchar"))
                        {
                            name = name.Substring(0, name.Length - 8);
                            isVarChar = true;
                        }
                        else if (name.EndsWith(":varcharout"))
                        {
                            name = name.Substring(0, name.Length - 11);
                            isVarChar = true;
                            isInput = false;
                        }
                        else if (name.EndsWith(":numericout"))
                        {
                            name = name.Substring(0, name.Length - 11);
                            isInput = false;
                        }
                        else if (name.EndsWith(":cursor"))
                        {
                            name = name.Substring(0, name.Length - 7);
                            isCursor = true;
                        }
                        if (values.ContainsKey(name))
                        {
                            if (isVarChar)
                            {
                                if (values[name] == "null")
                                {
                                    dataManager.AddParameter(name, Architect.DataFactory.Enumerations.DbType.String, 0, null);
                                }
                                else
                                {
                                    dataManager.AddParameter(name, Architect.DataFactory.Enumerations.DbType.String, 0, values[name]);
                                }
                            }
                            else if (isDate)
                            {
                                if (values[name] == "null")
                                {
                                    dataManager.AddParameter(name, Architect.DataFactory.Enumerations.DbType.Date, 0, null);
                                }
                                else if (values[name] == "const.today")
                                {
                                    dataManager.AddParameter(name, Architect.DataFactory.Enumerations.DbType.Date, 0, DateTime.Today);
                                }
                                else
                                {
                                    value = DateTime.ParseExact(values[name], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                                    dataManager.AddParameter(name, Architect.DataFactory.Enumerations.DbType.Date, 0, value);
                                }
                            }
                            else
                            {
                                if (values[name] == "null")
                                {
                                    dataManager.AddParameter(name, Architect.DataFactory.Enumerations.DbType.Int32, 0, null);
                                }
                                else
                                {
                                    dataManager.AddParameter(name, Architect.DataFactory.Enumerations.DbType.Int32, 0, values[name]);
                                }
                            }
                        }
                        else
                        {
                            if (isInput)
                            {
                                direction = System.Data.ParameterDirection.Input;
                            }
                            else
                            {
                                direction = System.Data.ParameterDirection.Output;
                            }
                            if (isVarChar)
                            {
                                dataManager.AddParameter(name, Architect.DataFactory.Enumerations.DbType.String, (direction == System.Data.ParameterDirection.Input ? 0 : 256), null, direction);
                            }
                            else if (isDate)
                            {
                                dataManager.AddParameter(name, Architect.DataFactory.Enumerations.DbType.Date, 0, null, direction);
                            }
                            else if (isCursor)
                            {
                                dataManager.AddParameter(name, Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, System.Data.ParameterDirection.InputOutput);
                            }
                            else
                            {
                                dataManager.AddParameter(name, Architect.DataFactory.Enumerations.DbType.Int32, 0, null, direction);
                            }
                        }
                    }
                }
            }
        }

    }
}
