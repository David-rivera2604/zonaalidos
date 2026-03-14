using Architect.API.Core.Business;
using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Permite realizar cotizaciones de pólizas por medio de TRON.
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// Descarga el detalle de un aviso de cobro de tron.
        /// </summary>
        public static async Task<byte[]> ImprimirAvisoDetalle(int num_aviso)
        {
            byte[] result = null;

            string reportId = await Architect.API.Tron.DataAccess.Impresion.AvisoDeCobroDetalle(num_aviso);

            string id = string.Format("{0}/servlet/mapfre.srv.SVJspool?otxtAccion=11&id={1}&format=pdf",
            ConfigurationManager.AppSettings["Mapfre.Tron.RutaImpresion"],
            reportId);

            using (WebClient client = new WebClient())
            {
                result = client.DownloadData(id);
            }
            if (result.Length < 200)
            {
                string failDetail = System.Text.Encoding.Default.GetString(result);
                throw new Architect.Utilities.Exceptions.CustomException(failDetail);
            }
            return result;
        }
        /// <summary>
        /// Descarga el aviso de cobro de tron.
        /// </summary>
        public static async Task<byte[]> ImprimirAviso(int num_aviso)
        {
            byte[] result = null;

            string reportId = await Architect.API.Tron.DataAccess.Impresion.AvisoDeCobro(1, num_aviso);

            string id = string.Format("{0}/servlet/mapfre.srv.SVJspool?otxtAccion=11&id={1}&format=pdf",
            ConfigurationManager.AppSettings["Mapfre.Tron.RutaImpresion"],
            reportId);

            using (WebClient client = new WebClient())
            {
                result = client.DownloadData(id);
            }
            if (result.Length < 200)
            {
                string failDetail = System.Text.Encoding.Default.GetString(result);
                throw new Architect.Utilities.Exceptions.CustomException(failDetail);
            }
            return result;
        }


        /// <summary>
        /// Recupera la información de un presupuesto
        /// </summary>
        public static Contracts.Presupuesto.DatoFijo InformacionDePresupuesto(string num_poliza)
        {
            Contracts.Presupuesto.DatoFijo data = null;
            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                data = DataAccess.LeerPresupuesto.Presupuesto(Int32.Parse(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]), num_poliza, 0, 0, 0, currentConnection, true);
                currentConnection.Close();
            }
            return data;
        }

        /// <summary>
        /// Recupera la información de una póliza
        /// </summary>
        public static Contracts.Poliza.DatoFijo InformacionDePoliza(string num_poliza)
        {
            Contracts.Poliza.DatoFijo data = null;
            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                data = DataAccess.LeerPoliza.Poliza(Int32.Parse(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]), num_poliza, 0, 0, 0, currentConnection, true);

                if (data?.Calculado != null)
                {
                    data.Calculado = null;
                }
                currentConnection.Close();
            }
            return data;
        }

        /// <summary>
        /// Permite el envió de un certificado por correo
        /// </summary>
        public static async Task<string> EnviarCertificado(string num_poliza, int num_riesgo, string correoprincipal, string correocopia1, string correocopia2, Core.Contracts.Security.Token tokenInfo)
        {
            string result = String.Empty;
            string verb = String.Empty;

            Dictionary<string, string> toAddressList = new Dictionary<string, string>();

            if (correoprincipal.IsNotEmpty())
            {
                toAddressList.Add(correoprincipal, correoprincipal);
                verb += correoprincipal;
            }
            if (correocopia1.IsNotEmpty() && !toAddressList.ContainsKey(correocopia1))
            {
                toAddressList.Add(correocopia1, correocopia1);
                verb += ", " + correocopia1;
            }
            if (correocopia2.IsNotEmpty() && !toAddressList.ContainsKey(correocopia2))
            {
                toAddressList.Add(correocopia2, correocopia2);
                verb += ", " + correocopia2;
            }
            if (num_riesgo == 0)
            {
                num_riesgo = 1;
            }
            if (toAddressList.Count > 0)
            {
                int initRiesgo = num_riesgo;
                int endRiesgo = num_riesgo;
                if (num_riesgo < 0)
                {
                    initRiesgo = 1;
                    endRiesgo = num_riesgo * -1;
                }
                for (int index = initRiesgo; index <= endRiesgo; index++)
                {
                    string certificado = await ImprimirPoliza_PDF(num_poliza, index);
                    string key = string.Format("Mapfre.Tron.302.Certificado.Complemento", num_poliza.Substring(0, 3));
                    string path = ConfigurationManager.AppSettings["Attachments.Path"] + @"..\documents\CertificadoComplemento\" + num_poliza.Substring(0, 3) + @"\";
                    string fileList = ConfigurationManager.AppSettings[key];
                    List<string> attachments = new List<string>() { certificado };
                    if (fileList.IsNotEmpty())
                    {
                        foreach (string filename in fileList.Split(','))
                        {
                            if (System.IO.File.Exists(path + filename))
                            {
                                attachments.Add(path + filename);
                            }
                        }
                    }
                    Core.Business.General.Mail.SendByTemplate("Send_Certificate", tokenInfo.CompanyId, new { num_poliza = num_poliza }, toAddressList, attachments.ToArray());
                }

                result = "El certificado fue enviado a las cuentas de correo: " + verb;
            }
            return result;
        }

        /// <summary>
        /// Retorna un PDF en disco que representa un certificado de tron.
        /// </summary>
        public static async Task<string> ImprimirPoliza_PDF(string num_poliza, int num_riesgo = 1)
        {
            string filename = string.Format("{0}Mapfre_Certificado_{1}_{2}.pdf", ConfigurationManager.AppSettings["Attachments.Path"], num_poliza, num_riesgo);
            byte[] bytes = await ImprimirPoliza(num_poliza, num_riesgo);
            using (var stream = new FileStream(filename, FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
            }

            return filename;
        }

        /// <summary>
        /// Descarga el certificado de tron.
        /// </summary>
        public static async Task<byte[]> ImprimirPoliza(string num_poliza, int num_riesgo = 1)
        {
            string procedureName = string.Empty;
            string reportId = string.Empty;
            byte[] report = null;  

            try
            {
                string ramo = num_poliza.Substring(0, 3);

                procedureName = $"tron.prog.certificado.{ramo}".StringValue(0).ToLower();

                if (procedureName.IsEmpty())
                {
                    throw new Utilities.Exceptions.ApplicationException(string.Format("No se puede imprimir la póliza {0} del ramo {1}", num_poliza, num_poliza.Substring(0, 3)));
                }
                reportId = await DataAccess.Impresion.Poliza(1, num_poliza, procedureName, num_riesgo);

                report = DownloadReport(reportId, String.Format("Póliza {0}, Riesgo {1}, ReportId {2} ", num_poliza, num_riesgo, reportId), "ImprimirPoliza");               
            }
            catch (Exception ex)
            {
                string message = "Ha ocurrido un error al tratar de imprimir el certificado";    

                if (reportId.IsNotEmpty())
                {
                    message += string.Format(", ReportIdentify #{0}", reportId);
                }

                throw new Architect.Utilities.Exceptions.CustomException(message, ex);
            }
            return report;
        }

        /// <summary>
        /// Descarga un certificado de un acreedor
        /// </summary>
        /// <param name="num_poliza"></param>
        /// <returns></returns>
        public static async Task<byte[]> ImprimirAcreedor(string num_poliza)
        {
            
            string reportId = await DataAccess.Impresion.Acreedor(1, num_poliza);
            return DownloadReport(reportId, String.Format("Póliza {0}, ReportId {1} ", num_poliza, reportId), "ImprimirAcreedor");

        }

        /// <summary>
        /// Descarga un reporte en PDF
        /// </summary>
        /// <param name="reportId"></param>
        /// <param name="verb"></param>
        /// <param name="typeReport"></param>
        /// <returns></returns>
        public static byte[] DownloadReport(string reportId,string verb, string typeReport)
        {
            byte[] result = null;
            string id = string.Format("{0}/servlet/mapfre.srv.SVJspool?otxtAccion=11&id={1}&format=pdf",
                           ConfigurationManager.AppSettings["Mapfre.Tron.RutaImpresion"], reportId);
            using (WebClient client = new WebClient())
            {
                result = client.DownloadData(id);
            }
            if (result.Length < 200)
            {
                string failDetail = System.Text.Encoding.Default.GetString(result);
                throw new Architect.Utilities.Exceptions.CustomException(failDetail);
            }
            return result;
        }

        /// <summary>
        /// Retorna un PDF en disco que representa un recibo de tron.
        /// </summary>
        public static async Task<string> ImprimirRecibo_PDF(int num_recibo)
        {
            string fileName = "Mapfre_Recibo_" + num_recibo.ToString() + ".pdf";

            string result = ConfigurationManager.AppSettings["Attachments.Path"] + fileName;
            byte[] bytes = await ImprimirRecibo(num_recibo);
            using (var stream = new FileStream(result, FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
            }

            return fileName;
        }

        /// <summary>
        /// Descarga el recibo de tron.
        /// </summary>
        public static async Task<byte[]> ImprimirRecibo(int num_recibo)
        {
            byte[] result = null;


            string reportId = await Architect.API.Tron.DataAccess.Impresion.Recibo(1, num_recibo);
            string id = string.Format("{0}/servlet/mapfre.srv.SVJspool?otxtAccion=11&id={1}&format=pdf",
                                        ConfigurationManager.AppSettings["Mapfre.Tron.RutaImpresion"],
                                        reportId);

            using (WebClient client = new WebClient())
            {
                result = client.DownloadData(id);
            }
            if (result.Length < 200)
            {
                string failDetail = System.Text.Encoding.Default.GetString(result);
                throw new Architect.Utilities.Exceptions.CustomException(failDetail);
            }
            return result;
        }

        /// <summary>
        /// Descarga el Deposito De Prima de tron.
        /// </summary>
        public static async Task<byte[]> DepositoDePrima(int num_recibo, bool cobradosHoy = true)
        {
            byte[] result = null;

            string reportId = await Architect.API.Tron.DataAccess.Impresion.DepositoDePrima(1, num_recibo, cobradosHoy);

            string id = string.Format("{0}/servlet/mapfre.srv.SVJspool?otxtAccion=11&id={1}&format=pdf",
                                        ConfigurationManager.AppSettings["Mapfre.Tron.RutaImpresion"],
                                        reportId);

            using (WebClient client = new WebClient())
            {
                result = client.DownloadData(id);
            }
            if (result.Length < 200)
            {
                string failDetail = System.Text.Encoding.Default.GetString(result);
                throw new Architect.Utilities.Exceptions.CustomException(failDetail);
            }
            return result;
        }

    }
}