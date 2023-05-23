using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Operaciones relacionadas a las pólizas de TRON.
    /// </summary>
    public static class Poliza
    {
        public static Contracts.Poliza.DatoFijo Leer(int cod_cia, string numPoliza, bool loadChilds)
        {
            return DataAccess.LeerPoliza.Poliza(cod_cia, numPoliza, 0, 0, 0, null, loadChilds);
        }

        public static string Cancelacion(int cod_cia, string alias, string numPoliza, DateTime fecAnulacion, string motSpto)
        {
            string result = String.Empty;
            Contracts.Batch.Proceso g2000510Instance = new Contracts.Batch.Proceso
            {
                fec_tratamiento = DateTime.Today,
                num_orden = 0,
                tip_mvto_batch = 4.ToString(),
                cod_cia = cod_cia,
                txt_alias = alias,
                tip_situ_filtro = 3.ToString(),
                nom_prg_excepcion = string.Empty,
                mca_recalcula_fecha = "N",
                tip_fecha_base = string.Empty,
                cod_usr = "COTIZWEB"
            };

            using (IDbConnection connection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {

                DataAccess.Batch.G2000510.Create(g2000510Instance, connection);

                Contracts.Poliza.DatoFijo a2000030Instance = Leer(g2000510Instance.cod_cia, numPoliza, false);

                Contracts.Batch.a2000500 a2000500 = new Contracts.Batch.a2000500()
                {
                    Fec_Tratamiento = g2000510Instance.fec_tratamiento,
                    Num_Orden = g2000510Instance.num_orden,
                    Tip_Mvto_Batch = g2000510Instance.tip_mvto_batch,
                    Cod_Cia = a2000030Instance.cod_cia,
                    Cod_Sector = a2000030Instance.cod_sector,
                    Cod_Ramo = a2000030Instance.cod_ramo,
                    Cod_Nivel1 = a2000030Instance.cod_nivel1,
                    Cod_Nivel2 = a2000030Instance.cod_nivel2,
                    Cod_Nivel3 = a2000030Instance.cod_nivel3,
                    Cod_Agt = a2000030Instance.cod_agt,
                    Cod_Mon = a2000030Instance.cod_mon,
                    Num_Poliza_Grupo = a2000030Instance.num_poliza_grupo,
                    Num_Contrato = a2000030Instance.num_contrato,
                    Num_Poliza_Cliente = a2000030Instance.num_poliza_cliente,
                    Num_Poliza = a2000030Instance.num_poliza,
                    Num_Poliza_Tronador = String.Empty,
                    Num_Poliza_Definitivo = String.Empty,
                    Num_Spto = a2000030Instance.num_spto,
                    Num_Apli = a2000030Instance.num_apli,
                    Num_Spto_Apli = a2000030Instance.num_spto_apli,
                    Tip_Poliza_Tr = a2000030Instance.tip_poliza_tr,
                    Fec_Efec_Spto = fecAnulacion,
                    Fec_Vcto_Spto = a2000030Instance.fec_vcto_poliza,
                    Num_Recibo = int.MinValue,
                    Num_Riesgos = a2000030Instance.num_riesgos,
                    Mca_Prima_Manual = "N",
                    Cod_Spto = 999,
                    Sub_Cod_Spto = 1,
                    Cod_Tip_Spto = "4",
                    Txt_Motivo_Spto = motSpto,
                    Tip_Spto_Accion = "4",
                    Mca_Renueva = String.Empty, //a2000030Instance.;
                    Mca_Renueva_Tmp = String.Empty, // a2000030Instance.;
                    Mca_Periodicidad = String.Empty, // a2000030Instance.
                    Cant_Renovaciones = a2000030Instance.cant_renovaciones,
                    Mca_Prorrata = a2000030Instance.mca_prorrata,
                    Mca_Devuelve_Todo = "S",
                    //a2000500Result.tip_spto_accion =a2000030Instance.
                    Tip_Autoriza_Ct = String.Empty,
                    Tip_Situ = "1",
                    Cod_Excepcion = int.MinValue,
                    Nom_Excepcion = String.Empty,
                    Mca_Pre_Renovacion = "N",
                    Mca_Anulacion_Por_Deuda = "N",
                    Max_Spto_Vigente = a2000030Instance.num_spto,
                    Cod_Usr = a2000030Instance.cod_usr,
                    Cod_Usr_Captura = a2000030Instance.cod_usr,
                    Fec_Actu = DateTime.Today,
                    Num_Subcontrato = int.MinValue,
                    Hora_Desde = String.Empty,
                    Cod_Negocio = int.MinValue.ToString(),
                    Num_Spto_Anulado = int.MinValue
                };

                DataAccess.Batch.A2000500.Create(a2000500, connection);



                Contracts.Batch.Proceso procesoResult = DataAccess.Batch.G2000510.Execute(g2000510Instance, connection);
                if (procesoResult.txt_error.IsEmpty())
                {
                    result = procesoResult.txt_error;
                }
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera los datos variables de una póliza
        /// </summary>
        public static List<Contracts.Poliza.DatoVariacion> DatosVariables(string num_poliza)
        {
            List<Contracts.Poliza.DatoVariable> data = DataAccess.DatosVariables.RetrieveByPolicy(Int32.Parse(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]), num_poliza);
            List<Contracts.Poliza.DatoVariacion> result = new List<Contracts.Poliza.DatoVariacion>();

            foreach (Contracts.Poliza.DatoVariable item in data)
            {
                result.Add(new Contracts.Poliza.DatoVariacion() { cod_campo = item.cod_campo, val_campo_act = item.val_campo });
            }
            return result;
        }

        /// <summary>
        /// Aplica variaciones a una póliza
        /// </summary>
        public static bool Variaciones(string num_poliza, Contracts.Poliza.Variacion variacion)
        {
            bool result = false;
            IDbConnection currentConnection = DataFactory.Database.OpenConnection("Tron");
            try
            {
                foreach (Contracts.Poliza.DatoVariacion item in variacion.Detalle)
                {
                    if (item.val_campo_ant != item.val_campo_act)
                    {
                        DataAccess.DatosVariables.AplicarVariacion(variacion.cod_ramo, num_poliza, variacion.num_riesgo,
                            item.cod_campo, item.val_campo_ant, item.val_campo_act, variacion.fec_validez, "ZA: " + variacion.txt_obs, currentConnection);
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Falla al tratar de procesar las variaciones", "Póliza " + num_poliza, ex);
            }

            currentConnection.Close();
            return result;
        }

        /// <summary>
        /// Aplica variaciones a una póliza
        /// </summary>
        public static bool Cancelacion(string num_poliza, Contracts.Poliza.Variacion variacion)
        {
            bool result = false;
            IDbConnection currentConnection = DataFactory.Database.OpenConnection("Tron");
            try
            {
                foreach (Contracts.Poliza.DatoVariacion item in variacion.Detalle)
                {
                    if (item.val_campo_ant != item.val_campo_act)
                    {
                        DataAccess.DatosVariables.AplicarVariacion(variacion.cod_ramo, num_poliza, variacion.num_riesgo,
                            item.cod_campo, item.val_campo_ant, item.val_campo_act, variacion.fec_validez, "ZA: " + variacion.txt_obs, currentConnection);
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Falla al tratar de procesar las variaciones", "Póliza " + num_poliza, ex);
            }

            currentConnection.Close();
            return result;
        }

        /// <summary>
        /// Control técnico de una póliza, permite su aprobación o rechazo
        /// </summary>
        public static string ControlTecnico(string num_poliza, Contracts.Poliza.Parameters.ControlTecnicoParametros controlTecnico, Core.Contracts.Security.Token tokenInfo)
        {
            string result = "Control técnico procesado correctamente";
            //En caso de que se este autorizando (1) o rechazando (2)
            if (controlTecnico.tip_autoriza == "1" || controlTecnico.tip_autoriza == "2")
            {
                Contracts.Poliza.DatoFijo policy = DataAccess.ControlesTecnicos.Autorizar(num_poliza, controlTecnico);
                if (controlTecnico.tip_autoriza == "1")
                {
                    string certificado = Common.ImprimirPoliza_PDF(num_poliza);
                    if (controlTecnico.correo1.IsNotEmpty())
                    {
                        Dictionary<string, string> emailTmpl = Core.Business.General.Mail.GetTemplate("Send_Certificate", tokenInfo.CompanyId, tokenInfo.UserId, 0, policy);
                        string id = DocuSign.Integrations.DocuSign.EviMail(num_poliza,
                                                                           "Envío Certificado " + num_poliza,
                                                                           emailTmpl["Body"],
                                                                           "Certificado póliza",
                                                                           "Cliente",
                                                                           controlTecnico.correo1,
                                                                           certificado,
                                                                           num_poliza,
                                                                           "Certificado póliza " + num_poliza + ".pdf").Result;
                    }
                }
            }
            else
            {
                //En caso de que se este dejando como pendiente (3)
                Dictionary<string, string> emailList = new Dictionary<string, string>();
                if (controlTecnico.correo1.IsNotEmpty())
                {
                    emailList.Add(controlTecnico.correo1, controlTecnico.correo1);
                }
                if (controlTecnico.correo2.IsNotEmpty() && !emailList.ContainsKey(controlTecnico.correo2))
                {
                    emailList.Add(controlTecnico.correo2, controlTecnico.correo2);
                }
                if (emailList.Count > 0)
                {
                    Core.Business.General.Mail.SendByTemplate("Control_Tecnico", tokenInfo.CompanyId,
                        new { num_poliza = num_poliza, observacion = controlTecnico.observacion }, emailList);
                    result = "El control técnico fue notificado de forma exitosa";
                }
            }

            return result;
        }

        /// <summary>
        /// Permite renovar una póliza
        /// </summary>
        public static string Renovar(string num_poliza)
        {
            string result = DataAccess.Poliza.Renovar(num_poliza);
            if (result.IndexOf("TRN-") > -1)
            {
                result = result.Substring(result.IndexOf("TRN-"));
                result = result.Substring(result.IndexOf(":") + 1).Trim().Capitalize();
            }
            return result.IsEmpty() || result == "null" ? "Póliza renovada correctamente." : result;
        }

    }
}