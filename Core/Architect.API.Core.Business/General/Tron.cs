using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Business.General
{
    public static class Tron
    {

        public static string RetrieveAgentEMailByDocument(string tip_docum, string cod_docum)
        {
            return Architect.API.Core.DataAccess.Security.Tron.RetrieveAgentEMailByDocument(tip_docum, cod_docum);
        }
    }
}
