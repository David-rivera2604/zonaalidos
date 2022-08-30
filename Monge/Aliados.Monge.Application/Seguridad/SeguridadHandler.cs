using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace Aliados.Monge.Application.Seguridad
{
    public sealed class SeguridadHandler
    {

        /// <summary>
        /// Permite autenticar un usuario por medio de sus credenciales.
        /// </summary>
        /// <param name="clienteID"></param>
        /// <param name="secretID"></param>
        /// <returns></returns>
        public static async Task<Domain.Seguridad.RespuestaSeguridad> Autorizacion(string clienteID, string secretID)
        {
            Domain.Seguridad.RespuestaSeguridad result = null;
            if (string.IsNullOrEmpty(clienteID) || string.IsNullOrEmpty(secretID))
            {
                return result;
            }
            if (clienteID.Equals("MG20220831") && secretID.Equals("MPF202220831"))
            {
                return new Domain.Seguridad.RespuestaSeguridad()
                {
                    access_token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJSb3luZXIgQWNvc3RhIiwiVXNlcklkIjoiMjU0IiwiQm9keSI6IjUxNTc0MzVCN0QyM0Y2NEQ1ODdEOTNENjc0NUM2MkY0NUI4Q0FFMkJEQ0IwNTQxRTRDMjg3RUYzODBDOTc4QkVDMkUyRUI2RENENTAyNzFBNDkxRUNGNDEzRjZDOTEwRDAzMjQzQjE1MkM2MTI1NDFFQjBCNzhDRjlCQzAwMEFCQjMxRjQ4NDQxQUY3NjE5M0Y3OUI2NUNCRUZBNTM1MzQ5RDM0MEE2MTBGRjUxRThDNEY1MDQyQThERUJFOEZEMEVBMTc1Nzg3N0JBMTdGQjM0OTEyNEY3MDY4QTFCMTU4NDg3MTlCNDIwNDQ2M0U2RDMzMzA0NTYwMjE2MTk0NTA5NUFDM0E1MUZBMjI4MTk1RjI3Mzk3MDBFOTVCNjc1Q0UwODgxOEREOTVFMEFCRDQwMkU1NDg0RDM5RTNCNDk2ODdGREVBQzBDOTg0QTE4Q0M1RjUxOUUxQzgyNkVDNDhBNzRDQzk0NDY0NDIwRDU0Q0FGM0Y2MEYyMzdFNUE1ODgyRjY5NTlGNUE4NDY1NDNCREREMEZFMTI2NzNCMDYxODAyRjExNURBNTJCRDIxNTczNjI2MTA0QTdDMTNCQUU3RjUyQUVGQUZENzQ4OThBN0VBNDBERTBFRjMyODVFNjg0Q0VGRjQxMTNFMjg3QTk3NUI3QUVGMzcxRDJBNTQ3MzAwRkRERTc1MjY1MjlBNjYwQkMyM0QyNUE2QUM1RUExODgxNzgyQkVDRDE2MDM3QzE1QjAwQzQ2MDA3RTk5RTQyODdFNDAzRkZFRDA3NjgxREMzRjNFQzBFRUI0NTExRTIwRTc1RUIyNTZDRDJCM0JFRUZEMUNGMDE4RkNENDdCNDU2MDhFMzBDODUwMTE0RjZGNEVCNjE1MjY0RDk2M0JBM0U3OUY2MzcwNkE4NjlFRENGNzdFMjczRTgyQTBEMTFDODU1MTAzNDVCQzkxNjk2RjRBNTZCNzU2QzRFRTJFQjhCNzM0MTc2MjZCQzg1OTk0MUU4MEY4NUZGNjk3OTMzOTIwNzUxMjNENTI3NUU5QTQ3MjQ1OUMwMTIyMDY2OTc3MDYxNzU4QjUzRUQ4MjUyMjlBMDA1MzE4NUQ0NzY3NkQ1Qjg4MzJFMjVDQjJEOTQ0MzU5OTQ5QzQ1OEQ1RDVCNTJBODNEOTc1QjgzQkE0QjFEMjM0NjE4RDREMzlFNzlDMUJDOUQyREUwNDJGMjdCQTYzMjU3RjExQTNCOTdBQUM2MDA4MDZENThCQjQ3QkM0MkFCMEU0QzlEQTlFQUQ5MTZGREQ2QkMyODUyNEI5M0IxRUIxNTEzNDU3QTRBOTYzOTdFMzc0QkUyMjQyODIwODYwQTA0QUNENDNDNjgiLCJqdGkiOiI0YWZiNGJmNy04NmU4LTRlMDAtODk0OS03MTg4ZTVlNTgxOGQiLCJleHAiOjE2NjA4ODI1NzMsImlzcyI6Iklzc3VlciIsImF1ZCI6IkF1ZGllbmNlIn0.EoqkR3dCCW0_JMG-LThzl3gZlWmYYfZhwU4qoA2b1n4",
                    token_type = "Bearer",
                    expires_in = 3600
                };
            }
            return result;
        }

    }
}
