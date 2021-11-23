using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// .
    /// </summary>
    public static partial class WhiteList
    {

        /// <summary>
        /// Verifica si una dirección IP existe en la WhiteList.
        /// </summary>
        /// <param name="host">Dirección IP/Nombre de la maquina donde se hizo la solicitud.</param>
        /// <returns>Verdadero en caso de encontrar el host, falso en caso contrario</returns>
        public static bool Find(string host)
        {
            bool result = true;
            string key = "WhiteList";
            List<string> items = new List<string>();

            if (Utilities.Cache.Exist(key))
            {
                items = (List<string>)Utilities.Cache.GetItem(key);
            }
            if (!items.Any(c => c.EqualIgnoringCase(host)))
            {
                result = Architect.API.Core.DataAccess.General.WhiteList.CountByIPAddress(host) > 0;
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
