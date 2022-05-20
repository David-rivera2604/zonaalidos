using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Permite realizar cotizaciones de pólizas por medio de TRON.
    /// </summary>
    public static class Common
    {
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
        public static string EnviarCertificado(string num_poliza, int num_riesgo, string correoprincipal, string correocopia1, string correocopia2, Core.Contracts.Security.Token tokenInfo)
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
                    string certificado = ImprimirPoliza_PDF(num_poliza, index);
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
        public static string ImprimirPoliza_PDF(string num_poliza, int num_riesgo = 1)
        {
            string filename = string.Format("{0}Mapfre_Certificado_{1}_{2}.pdf", ConfigurationManager.AppSettings["Attachments.Path"], num_poliza, num_riesgo);
            byte[] bytes = ImprimirPoliza(num_poliza, num_riesgo);
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
        public static byte[] ImprimirPoliza(string num_poliza, int num_riesgo = 1)
        {
            string procedureName = string.Empty;
            byte[] result = null;
            switch (num_poliza.Substring(0, 3))
            {
                case "201":
                    procedureName = "em_k_jrp_cuadropoliza201_mcr.p_lista";
                    break;
                case "202":
                    procedureName = "em_k_jrp_cuadropoliza202_mcr.p_lista";
                    break;
                case "288":
                    procedureName = "em_k_jrp_condiciones_288_mcr.p_lista";
                    break;
                case "300":
                case "302":
                    procedureName = "em_k_jrp_cuadro_poliza_301_mcr.p_lista";
                    break;
                case "441":
                    procedureName = "em_k_jrp_condiciones_441_mcr.p_lista";
                    break;
            }
            if (procedureName.IsEmpty())
            {
                throw new Utilities.Exceptions.ApplicationException(string.Format("No se puede imprimir la póliza {0} del ramo {0}", num_poliza, num_poliza.Substring(0, 3)));
            }
            string id = string.Format("{0}/prd/servlet/mapfre.srv.SVJspool?otxtAccion=11&id={1}&format=pdf",
                                        ConfigurationManager.AppSettings["Mapfre.Tron.RutaImpresion"],
                                        DataAccess.Impresion.Poliza(1, num_poliza, procedureName, num_riesgo));
            using (WebClient client = new WebClient())
            {
                result = client.DownloadData(id);
            }
            if (result.Length < 200)
            {
                string failDetail = System.Text.Encoding.Default.GetString(result);
                Architect.Utilities.Log.ErrorLog("ImprimirPoliza", failDetail);
                throw new Exception(failDetail);
            }
            return result;
        }

        /// <summary>
        /// Retorna un PDF en disco que representa un recibo de tron.
        /// </summary>
        public static string ImprimirRecibo_PDF(int num_recibo)
        {
            string fileName = "Mapfre_Recibo_" + num_recibo.ToString() + ".pdf";

            string result = ConfigurationManager.AppSettings["Attachments.Path"] + fileName;
            byte[] bytes = ImprimirRecibo(num_recibo);
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
        public static byte[] ImprimirRecibo(int num_recibo)
        {
            byte[] result = null;

            string id = string.Format("{0}/prd/servlet/mapfre.srv.SVJspool?otxtAccion=11&id={1}&format=pdf",
                                        ConfigurationManager.AppSettings["Mapfre.Tron.RutaImpresion"],
                                        Architect.API.Tron.DataAccess.Impresion.Recibo(1, num_recibo));
            using (WebClient client = new WebClient())
            {
                result = client.DownloadData(id);
            }
            if (result.Length < 200)
            {
                string failDetail = System.Text.Encoding.Default.GetString(result);
                Architect.Utilities.Log.ErrorLog("ImprimirRecibo", failDetail);
                throw new Exception(failDetail);
            }
            return result;
        }

    }
}