using Architect.Sugese.Domain;
using Architect.Sugese.Manager.EnviarArchivoXML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Sugese.Manager
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Model : IModel
    {
        public string Enviar(string archivo, string nombreModelo, int anno, int periodo)
        {
            string result = string.Empty;
            byte[] datosArchivo = null;

            using (FileStream file = new FileStream(archivo, FileMode.Open, FileAccess.Read))
            {
                datosArchivo = new byte[file.Length];
                file.Read(datosArchivo, 0, (int)file.Length);
            }

            using (EnviarArchivoXMLClient client = new EnviarArchivoXMLClient())
            {
                OverrideCertificateValidation();

                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Tls |
                    SecurityProtocolType.Tls11 |
                    SecurityProtocolType.Tls12;

                if (nombreModelo == "ModeloPolizas")
                {
                    result = client.EnviarArchivos(datosArchivo);
                }
                else
                {
                    result = client.Enviar(datosArchivo, nombreModelo, anno, periodo);
                }
            }

            return result;
        }

        public static void OverrideCertificateValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(RemoteCertValidate);
        }

        private static bool RemoteCertValidate(
            object sender,
            X509Certificate cert,
            X509Chain chain,
            System.Net.Security.SslPolicyErrors error)
        {
            return true;
        }
    }
}
