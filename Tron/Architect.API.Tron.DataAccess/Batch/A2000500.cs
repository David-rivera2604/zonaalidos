using Architect.DataFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Batch
{
    /// <summary>
    ///  Pólizas a tratar en los procesos masivos (a2000500)
    /// </summary>
    public static class A2000500
    {
        public static bool Create(Architect.API.Tron.Contracts.Batch.a2000500 a2000500Instance, IDbConnection currentConnection)
        {
            bool result = false;
            int affected = Database.Procedure("EM_K_LLENAR_BUZONES_MCR.P_INSERT_A2000500")
                                .AddParameter("P_FEC_TRATAMIENTO", DbType.Date, 0, a2000500Instance.Fec_Tratamiento)
                                .AddParameter("P_NUM_ORDEN", DbType.Int32, 22, a2000500Instance.Num_Orden)
                                .AddParameter("P_TIP_MVTO_BATCH", DbType.String, 2, a2000500Instance.Tip_Mvto_Batch)
                                .AddParameter("P_COD_CIA", DbType.Int32, 22, a2000500Instance.Cod_Cia)
                                .AddParameter("P_COD_SECTOR", DbType.Int32, 22, a2000500Instance.Cod_Sector)
                                .AddParameter("P_COD_RAMO", DbType.Int32, 22, a2000500Instance.Cod_Ramo)
                                .AddParameter("P_COD_NIVEL1", DbType.Int32, 22, a2000500Instance.Cod_Nivel1)
                                .AddParameter("P_COD_NIVEL2", DbType.Int32, 22, a2000500Instance.Cod_Nivel2)
                                .AddParameter("P_COD_NIVEL3", DbType.Int32, 22, a2000500Instance.Cod_Nivel3)
                                .AddParameter("P_COD_AGT", DbType.Int32, 22, a2000500Instance.Cod_Agt)
                                .AddParameter("P_COD_MON", DbType.Int32, 22, a2000500Instance.Cod_Mon)
                                .AddParameter("P_NUM_POLIZA_GRUPO", DbType.String, 13, a2000500Instance.Num_Poliza_Grupo)
                                .AddParameter("P_NUM_CONTRATO", DbType.Int32, 22, a2000500Instance.Num_Contrato)
                                .AddParameter("P_NUM_POLIZA_CLIENTE", DbType.String, 13, a2000500Instance.Num_Poliza_Cliente)
                                .AddParameter("P_NUM_POLIZA", DbType.String, 13, a2000500Instance.Num_Poliza)
                                .AddParameter("P_NUM_POLIZA_TRONADOR", DbType.String, 13, a2000500Instance.Num_Poliza_Tronador)
                                .AddParameter("P_NUM_POLIZA_DEFINITIVO", DbType.String, 13, a2000500Instance.Num_Poliza_Definitivo)
                                .AddParameter("P_NUM_SPTO", DbType.Int32, 22, a2000500Instance.Num_Spto)
                                .AddParameter("P_NUM_APLI", DbType.Int32, 22, a2000500Instance.Num_Apli)
                                .AddParameter("P_NUM_SPTO_APLI", DbType.Int32, 22, a2000500Instance.Num_Spto_Apli)
                                .AddParameter("P_TIP_POLIZA_TR", DbType.String, 1, a2000500Instance.Tip_Poliza_Tr)
                                .AddParameter("P_FEC_EFEC_SPTO", DbType.Date, 0, a2000500Instance.Fec_Efec_Spto)
                                .AddParameter("P_FEC_VCTO_SPTO", DbType.Date, 0, a2000500Instance.Fec_Vcto_Spto)
                                .AddParameter("P_NUM_RECIBO", DbType.Int32, 22, a2000500Instance.Num_Recibo)
                                .AddParameter("P_NUM_RIESGOS", DbType.Int32, 22, a2000500Instance.Num_Riesgos)
                                .AddParameter("P_MCA_PRIMA_MANUAL", DbType.String, 1, a2000500Instance.Mca_Prima_Manual)
                                .AddParameter("P_COD_SPTO", DbType.Int32, 22, a2000500Instance.Cod_Spto)
                                .AddParameter("P_SUB_COD_SPTO", DbType.Int32, 22, a2000500Instance.Sub_Cod_Spto)
                                .AddParameter("P_COD_TIP_SPTO", DbType.String, 2, a2000500Instance.Cod_Tip_Spto)
                                .AddParameter("P_TXT_MOTIVO_SPTO", DbType.String, 320, a2000500Instance.Txt_Motivo_Spto)
                                .AddParameter("P_MCA_RENUEVA", DbType.String, 1, a2000500Instance.Mca_Renueva)
                                .AddParameter("P_MCA_RENUEVA_TMP", DbType.String, 1, a2000500Instance.Mca_Renueva_Tmp)
                                .AddParameter("P_MCA_PERIODICIDAD", DbType.String, 1, a2000500Instance.Mca_Periodicidad)
                                .AddParameter("P_CANT_RENOVACIONES", DbType.Int32, 22, a2000500Instance.Cant_Renovaciones)
                                .AddParameter("P_MCA_PRORRATA", DbType.String, 1, a2000500Instance.Mca_Prorrata)
                                .AddParameter("P_MCA_DEVUELVE_TODO", DbType.String, 1, a2000500Instance.Mca_Devuelve_Todo)
                                .AddParameter("P_TIP_SPTO_ACCION", DbType.String, 2, a2000500Instance.Tip_Spto_Accion)
                                .AddParameter("P_TIP_AUTORIZA_CT", DbType.String, 1, a2000500Instance.Tip_Autoriza_Ct)
                                .AddParameter("P_TIP_SITU", DbType.String, 1, a2000500Instance.Tip_Situ)
                                .AddParameter("P_COD_EXCEPCION", DbType.Int32, 22, a2000500Instance.Cod_Excepcion)
                                .AddParameter("P_NOM_EXCEPCION", DbType.String, 30, a2000500Instance.Nom_Excepcion)
                                .AddParameter("P_MCA_PRE_RENOVACION", DbType.String, 1, a2000500Instance.Mca_Pre_Renovacion)
                                .AddParameter("P_MCA_ANULACION_POR_DEUDA", DbType.String, 1, a2000500Instance.Mca_Anulacion_Por_Deuda)
                                .AddParameter("P_MAX_SPTO_VIGENTE", DbType.Int32, 22, a2000500Instance.Max_Spto_Vigente)
                                .AddParameter("P_COD_USR", DbType.String, 8, a2000500Instance.Cod_Usr)
                                .AddParameter("P_COD_USR_CAPTURA", DbType.String, 8, a2000500Instance.Cod_Usr_Captura)
                                .AddParameter("P_FEC_ACTU", DbType.Date, 0, a2000500Instance.Fec_Actu)
                                .AddParameter("P_NUM_SUBCONTRATO", DbType.Int32, 22, a2000500Instance.Num_Subcontrato)
                                .AddParameter("P_HORA_DESDE", DbType.String, 5, a2000500Instance.Hora_Desde)
                                .AddParameter("P_COD_NEGOCIO", DbType.String, 30, a2000500Instance.Cod_Negocio)
                                .AddParameter("P_NUM_SPTO_ANULADO", DbType.Int32, 22, a2000500Instance.Num_Spto_Anulado)
                              .Execute(currentConnection, "Tron");
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }

    }
}
