using Architect.API.Tron.Contracts.Cotizacion;
using Architect.API.Tron.Contracts.Presupuesto;
using Architect.API.Tron.DataAccess;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Architect.API.Tron.Business
{
    public static class ErrorHandler
    {

        public struct ErrorDetail
        {
            public int code;
            public string message;
            public bool tron;

            public string raw;

        }

        public static ErrorDetail Parser(string error)
        {
            string mensaje = error;
            if (mensaje != null)
            {
                if (mensaje.StartsWith("ORA-", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (mensaje.IndexOf(':') > 0)
                    {
                        mensaje = mensaje.Substring(mensaje.IndexOf(':') + 1).Trim();
                    }
                    mensaje = mensaje.Substring(0, 1).ToUpper() + mensaje.Substring(1).ToLower();
                    if (mensaje.StartsWith("O obligatorio", StringComparison.CurrentCultureIgnoreCase))
                    {
                        mensaje = mensaje.Replace("O obligatorio", string.Empty).Trim() + " es obligatorio";
                    }

                }
            }

            int codigoError = ExtraerCodigoError(mensaje);
            if (codigoError > 0)
            {
                string dbmensaje = DataAccess.G2000211.DescripcionPorCodigo(1, codigoError);
                if (dbmensaje.IsNotEmpty())
                {
                    mensaje = dbmensaje;
                }
            }
            bool tron = mensaje.ToUpper().StartsWith("TRN-");
            if (!tron)
            {
                tron = error.StartsWith("ORA-20003:  O OBLIGATORIO <", StringComparison.CurrentCultureIgnoreCase);
            }
            if (!tron)
            {
                tron = error.StartsWith("ORA-01400: no se puede realizar una inserción NULL en (\"TRON2000\".", StringComparison.CurrentCultureIgnoreCase);
            }
            if (!tron)
            {
                tron = error.StartsWith("ORA-20001:", StringComparison.CurrentCultureIgnoreCase)
                       || error.StartsWith("ORA-20501:", StringComparison.CurrentCultureIgnoreCase);
            }
            if (!tron)
            {
                tron = error.StartsWith("ORA-20005:   TRN", StringComparison.CurrentCultureIgnoreCase);
            }


            return new ErrorDetail() { code = codigoError, message = mensaje, raw = error, tron = tron };
        }

        internal static int ExtraerCodigoError(string texto)
        {
            var match = Regex.Match(texto, @"\[(\d+)\]");
            if (match.Success && int.TryParse(match.Groups[1].Value, out int codigo))
            {
                return codigo;
            }
            return 0;
        }

    }
}
