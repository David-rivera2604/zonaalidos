using Architect.Utilities.Extensions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;

namespace Architect.DataFactory.Handlers
{
    public static class UtilityHandler
    {

        internal static string MakeCommandSummary(DbCommand command)
        {
            if (command.IsEmpty())
            {
                return string.Empty;
            }

            string extra = string.Empty;
            if (command.Parameters.IsNotEmpty())
            {
                string parameterValue;
                foreach (DbParameter item in command.Parameters)
                {
                    if (Microsoft.VisualBasic.Information.IsDBNull(item.Value))
                    {
                        parameterValue = "Null";
                    }
                    else
                    {
                        if (item.DbType == DbType.StringFixedLength)
                            parameterValue = string.Format("'{0}'", item.Value);
                        else if (item.DbType == DbType.Date)
                            parameterValue =  ((DateTime)item.Value).ToString("yyyy-MM-dd HH:mm:ss");
                        else
                            parameterValue = string.Format("{0}", item.Value);
                    }
                    if (extra.Length > 0)
                    {
                        extra += ", ";
                    }
                    extra += string.Format("{0}={1}", item.ParameterName, parameterValue);
                }
            }
            if (extra.Length > 0)
            {
                extra = "  Parameters=" + extra + Constants.vbCrLf;
            }
            return Constants.vbCrLf + Utilities.Helpers.Assembly.GetMethodDetalleCall(typeof(Database).Assembly.GetName().Name).Replace("<<I>>", "  ") +
                   "  Command=" + command.CommandText + Constants.vbCrLf + extra;
        }

        internal static bool AppSettingsCheck(string key)
        {
            bool result = false;
            if (ConfigurationManager.AppSettings[key].IsNotEmpty() && ConfigurationManager.AppSettings[key].Equals("True", StringComparison.CurrentCultureIgnoreCase))
            {
                result = true;
            }
            return result;
        }

        public static string GetMd5Hash(string ConnectionStringName, string command, List<Contracts.Parameter> parameters)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(ConnectionStringName + command + Architect.Utilities.SerializeHandler<List<Contracts.Parameter>>.Serialize(parameters)));
                StringBuilder sBuilder = new StringBuilder();
                int i;
                for (i = 0; i <= data.Length - 1; i++)
                    sBuilder.Append(data[i].ToString("x2"));
                return sBuilder.ToString();
            }
        }

        //private static bool VerifyMd5Hash(string input, string hash)
        //{
        //    string hashOfInput = GetMd5Hash(input);
        //    StringComparer comparer = StringComparer.OrdinalIgnoreCase;
        //    if (0 == comparer.Compare(hashOfInput, hash))
        //        return true;
        //    else
        //        return false;
        //}

        ///// <summary>
        /////     ''' MD5 generator to run the query
        /////     ''' </summary>
        /////     ''' <param name="command">Query</param>
        /////     ''' <returns></returns>
        /////     ''' <remarks></remarks>
        //public static string GetMd5Hash(Object command)
        //{
        //    using (MD5 md5Hash = MD5.Create())
        //    {
        //        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(Architect.DataFactory.Handlers.SerializeHandler<Object>.Serialize(command)));
        //        StringBuilder sBuilder = new StringBuilder();
        //        int i;
        //        for (i = 0; i <= data.Length - 1; i++)
        //            sBuilder.Append(data[i].ToString("x2"));
        //        return sBuilder.ToString();
        //    }
        //}
    }
}