using System.Collections.Generic;
using System.Data;
using System.Linq;
using Architect.Common.Extensions;
using Architect.Common.Proxy;

namespace Architect.API.Core.DataAccess.Security
{

    /// <summary>
    /// Administrador de IPs autorizadas a consumo de sistema
    /// </summary>
    public sealed partial class WhiteList
    {

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla WhiteList por medio de su host.
        /// </summary>
        /// <param name="host">Host.</param> 
        /// <returns>Cantidad de registros encontrados.</returns>
        public static bool Find(string host)
        {
            bool result = true;
            string key = "WhiteList";
            var items = new List<string>();
            if (Utilities.Cache.Exist(key))
            {
                items = (List<string>)Utilities.Cache.GetItem(key);
            }

            if (!items.Any(c => c.EqualIgnoringCase(host)))
            {
                int rows = 0;
                {
                    var withBlock = new DataManagerFactory("SELECT COUNT(ID) " + "FROM WHITELIST " + "WHERE WHITELIST.IPADDRESS = @:IPADDRESS", "WHITELIST", "Research");
                    withBlock.AddParameter("IPADDRESS", DbType.String, 20, false, host);
                    rows = withBlock.QueryExecuteScalarToInteger();
                    if (rows > 0)
                    {
                        result = true;
                    }
                }

                if (result)
                {
                    items.Add(host);
                    Utilities.Cache.SetItem(key, items);
                }
            }
            else
            {
                result = true;
            }

            return result;
        }
    }
}