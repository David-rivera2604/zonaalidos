using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Architect.API.Insurance.Business.Helpers
{
    internal static class DocumentManager
    {
        public static Dictionary<string, string> Information(byte[] body)
        {

            return Information(new PdfReader(new MemoryStream(body)));

        }

        public static Dictionary<string, string> Information(string pathFile)
        {
            if (System.IO.File.Exists(pathFile))
            {
                return Information(new PdfReader(pathFile));
            }
            else
            {
                throw new FileNotFoundException(string.Format("El archivo '{0}' no existe.", pathFile));
            }
        }

        private static Dictionary<string, string> Information(PdfReader reader)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            AcroFields af = reader.AcroFields;
            foreach (var name in af.GetSignatureNames())
            {
                if (!af.SignatureCoversWholeDocument(name))
                {
                    throw new InvalidOperationException(string.Format("La firma: {0} no cubre todo el documento.", name));
                }
                PdfPKCS7 pk = af.VerifySignature(name);
                var values = pk.SigningCertificate.SubjectDN.ToString().Split(',');
                foreach (var item in values)
                {
                    var itemraw = item.Split('=');
                    result.Add(itemraw[0], itemraw[1]);
                }
            }
            return result;
        }

        public static bool Check(string fileName, string Id)
        {
            bool result = false;
            var filePath = System.IO.Path.Combine(ConfigurationManager.AppSettings["Path.Documents"].ToString(), fileName);
            var information = Information(filePath);
            if (information.ContainsKey("SERIALNUMBER"))
            {
                var value = information["SERIALNUMBER"].Replace("NUP-", string.Empty);
                if (value.Equals(Id))
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
