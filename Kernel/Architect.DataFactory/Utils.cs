using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Architect.DataFactory
{
    public static class Utils
    {

<<<<<<< HEAD
        public static System.Data.DataTable StatementExecute(string statement, int statementType, string connectionName, Dictionary<string, string> values, bool withCache, string prefix = null, string roleList = "")
=======
        public static string StatementExecute_v2(string statement, int statementType, string connectionName, Dictionary<string, string> values, bool withCache, string prefix = null, string roleList = "")
>>>>>>> 2603d8692335166cf5801e413f5bc98d7a338de7
        {
            string result = string.Empty;
            bool multiQuery = false;
            string subQuery = string.Empty;

            MatchCollection parameterMatches = Regex.Matches(statement, @"{(.+?)}"); // ([^)]*)
            List<string> parameterCursor = new List<string>();
            if (statement.StartsWith("MultiQuery.", StringComparison.CurrentCultureIgnoreCase) ||
                statement.StartsWith("MultiQuery(", StringComparison.CurrentCultureIgnoreCase))
            {
                if (statement.StartsWith("MultiQuery(", StringComparison.CurrentCultureIgnoreCase))
                {
                    subQuery = statement.Substring(11, statement.IndexOf(")", 11) - 11);
                    statement = statement.Substring(statement.IndexOf(").") + 2);
                }
                else
                {
                    statement = statement.Substring(11);
                }
                multiQuery = true;
                withCache = true;
            }
            if (Utilities.Helpers.Settings.StringValue("Working.Mode") == "Development")
            {
                withCache = false;
            }

            if (statementType == 2) //Procedure
            {
                foreach (Match paremeter in parameterMatches)
                {
                    statement = statement.Replace(paremeter.Value, string.Empty).Trim();
                    if (paremeter.Value.EndsWith(":cursor}", StringComparison.CurrentCultureIgnoreCase))
                    {
                        parameterCursor.Add(paremeter.Value.Replace("{", "").Replace(":cursor}", ""));
                    }
                }
                using (Database db = Database.Procedure(statement).Cache(withCache, prefix))
                {
                    ProcessParameters(parameterMatches, values, db);
                    if (multiQuery)
                    {
                        DataSet ds = db.MultiQuery(null, connectionName);

                        int top = parameterCursor.Count - 1;
                        for (int i = ds.Tables.Count - 1; i >= 0; i--)
                        {
                            ds.Tables[i].TableName = parameterCursor[top];
                            top--;
                        }
                        if (subQuery.IsNotEmpty())
                        {
                            result = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[subQuery]);
                        }
                        else
                        {
                            result = Newtonsoft.Json.JsonConvert.SerializeObject(ds);
                        }
                    }
                    else
                    {
                        result = Newtonsoft.Json.JsonConvert.SerializeObject(db.Query(null, connectionName));
                    }
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
<<<<<<< HEAD
                    
=======
                    name = name.Replace(":cursor}", "");
>>>>>>> 2603d8692335166cf5801e413f5bc98d7a338de7
                    if (name.StartsWith(":app_", StringComparison.CurrentCultureIgnoreCase))
                    {
                        switch (name.ToLower())
                        {
                            case ":app_userrolenamelist":
                                statement = statement.Replace(paremeter.Value, ("'" + string.Join("','", roleList.Split(',')) + "'").ToLower());
                                break;
                        }
                    }
                    statement = statement.Replace(paremeter.Value, name);
                    if (paremeter.Value.EndsWith(":cursor}", StringComparison.CurrentCultureIgnoreCase))
                    {
                        parameterCursor.Add(paremeter.Value.Replace("{", "").Replace(":cursor}", ""));
                    }
                }
                using (Database db = Database.Select(statement).Cache(withCache, prefix))
                {
                    ProcessParameters(parameterMatches, values, db);
                    if (multiQuery)
                    {
                        DataSet ds = db.MultiQuery(null, connectionName);
                        int top = parameterCursor.Count - 1;
                        for (int i = ds.Tables.Count - 1; i >= 0; i--)
                        {
                            ds.Tables[i].TableName = parameterCursor[top];
                            top--;
                        }
                        if (subQuery.IsNotEmpty())
                        {
                            result = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[subQuery]);
                        }
                        else
                        {
                            result = Newtonsoft.Json.JsonConvert.SerializeObject(ds);
                        }
                    }
                    else
                    {
                        result = Newtonsoft.Json.JsonConvert.SerializeObject(db.Query(null, connectionName));
                    }
                }
            }
            return result;
        }

        public static System.Data.DataTable StatementExecute(string statement, int statementType, string connectionName, Dictionary<string, string> values, bool withCache, string prefix = null, string roleList = "")
        {
            System.Data.DataTable records = null;
            bool multiQuery = false;
            string subQuery = string.Empty;
            MatchCollection parameterMatches = Regex.Matches(statement, @"{(.+?)}"); // ([^)]*)
            List<string> parameterCursor = new List<string>();

            if (statement.StartsWith("MultiQuery.", StringComparison.CurrentCultureIgnoreCase) ||
                statement.StartsWith("MultiQuery(", StringComparison.CurrentCultureIgnoreCase))
            {
                if (statement.StartsWith("MultiQuery(", StringComparison.CurrentCultureIgnoreCase))
                {
                    subQuery = statement.Substring(11, statement.IndexOf(")", 11) - 11);
                    statement = statement.Substring(statement.IndexOf(").") + 2);
                }
                else
                {
                    statement = statement.Substring(11);
                }
                multiQuery = true;
                withCache = true;
            }
            if (Utilities.Helpers.Settings.StringValue("Working.Mode") == "Development")
            {
                withCache = false;
            }

            if (statementType == 2) //Procedure
            {
                foreach (Match paremeter in parameterMatches)
                {
                    statement = statement.Replace(paremeter.Value, string.Empty).Trim();
                    if (paremeter.Value.EndsWith(":cursor}", StringComparison.CurrentCultureIgnoreCase))
                    {
                        parameterCursor.Add(paremeter.Value.Replace("{", "").Replace(":cursor}", ""));
                    }
                }
                using (Database db = Database.Procedure(statement).Cache(withCache, prefix))
                {
                    ProcessParameters(parameterMatches, values, db);

                    if (multiQuery && subQuery.IsNotEmpty())
                    {
                        DataSet ds = db.MultiQuery(null, connectionName);

                        int top = parameterCursor.Count - 1;
                        for (int i = ds.Tables.Count - 1; i >= 0; i--)
                        {
                            ds.Tables[i].TableName = parameterCursor[top];
                            top--;
                        }
                        records = ds.Tables[subQuery];
                    }
                    else
                    {
                        records = db.Query(null, connectionName);
                    }
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
                    name = name.Replace(":cursor}", "");
                    if (name.StartsWith(":app_", StringComparison.CurrentCultureIgnoreCase))
                    {
                        switch (name.ToLower())
                        {
                            case ":app_userrolenamelist":
                                statement = statement.Replace(paremeter.Value, ("'" + string.Join("','", roleList.Split(',')) + "'").ToLower());
                                break;
                        }
                    }
                    statement = statement.Replace(paremeter.Value, name);
                    if (paremeter.Value.EndsWith(":cursor}", StringComparison.CurrentCultureIgnoreCase))
                    {
                        parameterCursor.Add(paremeter.Value.Replace("{", "").Replace(":cursor}", ""));
                    }
                }
                using (Database db = Database.Select(statement).Cache(withCache, prefix))
                {
                    ProcessParameters(parameterMatches, values, db);
                    if (multiQuery && subQuery.IsNotEmpty())
                    {
                        DataSet ds = db.MultiQuery(null, connectionName);

                        int top = parameterCursor.Count - 1;
                        for (int i = ds.Tables.Count - 1; i >= 0; i--)
                        {
                            ds.Tables[i].TableName = parameterCursor[top];
                            top--;
                        }
                        records = ds.Tables[subQuery];
                    }
                    else
                    {
                        records = db.Query(null, connectionName);
                    }
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
                            case "app.roles":
                                dataManager.AddParameter(paremeter.Groups[1].Value, Architect.DataFactory.Enumerations.DbType.String, 0, "," + values["Token.Roles"] + ",");
                                break;
                            case "app.userrolenamelist":
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
                        if (name.EndsWith(":date", StringComparison.CurrentCultureIgnoreCase))
                        {
                            name = name.Substring(0, name.Length - 5);
                            isDate = true;
                        }
                        else if (name.EndsWith(":varchar", StringComparison.CurrentCultureIgnoreCase))
                        {
                            name = name.Substring(0, name.Length - 8);
                            isVarChar = true;
                        }
                        else if (name.EndsWith(":varcharout", StringComparison.CurrentCultureIgnoreCase))
                        {
                            name = name.Substring(0, name.Length - 11);
                            isVarChar = true;
                            isInput = false;
                        }
                        else if (name.EndsWith(":numericout", StringComparison.CurrentCultureIgnoreCase))
                        {
                            name = name.Substring(0, name.Length - 11);
                            isInput = false;
                        }
                        else if (name.EndsWith(":cursor", StringComparison.CurrentCultureIgnoreCase))
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
