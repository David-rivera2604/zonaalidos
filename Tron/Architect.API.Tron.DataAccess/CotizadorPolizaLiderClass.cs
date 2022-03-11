using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Data;
using System.Collections.Generic;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    /// EM_K_COTIZADOR_WEB_300_MCR
    /// </summary>
    public static class CotizadorPolizaLiderClass
    {
        public static Architect.API.Tron.Contracts.Presupuesto.DatoFijo P_Cotiza(Architect.API.Tron.Contracts.Batch.CotizadorPolizaLiderClass p2000030Instance, IDbConnection currentConnection)
        {
            Contracts.Presupuesto.DatoFijo result = new Contracts.Presupuesto.DatoFijo()
            {
                Coberturas = new List<Contracts.Presupuesto.Cobertura>()
            };
            Database.Procedure("EM_K_COTIZADOR_WEB_300_MCR.P_COTIZA")
                .AddParameter("P_TIP_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 3, p2000030Instance.tip_docum)
                .AddParameter("P_COD_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 20, p2000030Instance.cod_docum)
                .AddParameter("P_NOM_TERCERO", Architect.DataFactory.Enumerations.DbType.String, 180, p2000030Instance.nom_tercero)
                .AddParameter("P_APE1_TERCERO", Architect.DataFactory.Enumerations.DbType.String, 30, p2000030Instance.ape1_tercero)
                .AddParameter("P_FEC_NACIMIENTO", Architect.DataFactory.Enumerations.DbType.Date, 0, p2000030Instance.fec_nacimiento)
                .AddParameter("P_MCA_SEXO", Architect.DataFactory.Enumerations.DbType.String, 1, p2000030Instance.mca_sexo)
                .AddParameter("P_COD_AGT", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_agt)
                .AddParameter("P_COD_MON", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_mon)
                .AddParameter("P_COD_FRACC_PAGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_fracc_pago)
                .AddParameter("P_FEC_EFEC_POLIZA", Architect.DataFactory.Enumerations.DbType.Date, 0, p2000030Instance.fec_efec_poliza)
                .AddParameter("P_FEC_VCTO_POLIZA", Architect.DataFactory.Enumerations.DbType.Date, 0, p2000030Instance.fec_vcto_poliza)
                .AddParameter("P_COD_PLAN", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_plan)
                .AddParameter("P_COD_MARCA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_marca)
                .AddParameter("P_COD_TIP_VEHI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_tip_vehi)
                .AddParameter("P_COD_USO_VEHI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_uso_vehi)
                .AddParameter("P_ANIO_VEH", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.anio_Veh)
                .AddParameter("P_TIP_VALORACION", Architect.DataFactory.Enumerations.DbType.String, 3, p2000030Instance.Tip_Valoracion)
                .AddParameter("P_MCA_DESC_CLIENT_NUEVO", Architect.DataFactory.Enumerations.DbType.String, 1, p2000030Instance.mca_desc_client_nuevo)
                .AddParameter("P_GPS", Architect.DataFactory.Enumerations.DbType.String, 2, p2000030Instance.GPS)
                .AddParameter("P_RESP_CIVILSA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Resp_civilSA)
                .AddParameter("P_GAST_MEDICSA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Gast_medicSA)
                .AddParameter("P_ACC_CONDUCSA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Acc_ConducSA)
                .AddParameter("P_VALOR_VEHISA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Valor_VehiSA)
                .AddParameter("P_EQUI_ESPESA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Equi_EspeSA)
                .AddParameter("P_ROTU_CRISTSA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Rotu_CristSA)
                .AddParameter("P_COBERTURAS", Architect.DataFactory.Enumerations.DbType.String, 180, p2000030Instance.coberturas)
                .AddParameter("P_MCA_CERO_KM", Architect.DataFactory.Enumerations.DbType.String, 1, p2000030Instance.mca_cero_km)
                .AddParameter("P_MODELO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_modelo)
                .AddParameter("P_PCT_DCTO_AUTO_PAR", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.pct_dcto_auto_par)
                .AddParameter("P_PCT_DCTO_HOGAR_TOTAL", Architect.DataFactory.Enumerations.DbType.Double, 22, p2000030Instance.pct_dcto_HogarTotal)
                .AddParameter("P_NUM_POLIZA_GRUPO", Architect.DataFactory.Enumerations.DbType.String, 13, p2000030Instance.num_poliza_grupo)
                .AddParameter("P_NUM_CONTRATO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.num_contrato)
                .AddParameter("P_NUM_SUBCONTRATO", Architect.DataFactory.Enumerations.DbType.Int32, 22, 0)

                .AddParameter("P_TXT_MOTIVO", Architect.DataFactory.Enumerations.DbType.String, 400, p2000030Instance.txt_motivo)
                .AddParameter("p_tip_gestor", Architect.DataFactory.Enumerations.DbType.String, 2, p2000030Instance.tip_gestor)
                .AddParameter("p_cod_gestor", Architect.DataFactory.Enumerations.DbType.String, 13, p2000030Instance.cod_gestor)


                .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                {
                    result.Coberturas.Add(new Contracts.Presupuesto.Cobertura()
                    {
                        num_poliza = reader.StringValue("num_poliza"),
                        cod_cob = reader.IntegerValue("cod_cob"),
                        nom_cob = reader.StringValue("nom_cob"),
                        suma_aseg = reader.IntegerValue("suma_aseg"),
                        imp_anual = reader.IntegerValue("imp_anual"),
                        imp_iva = reader.IntegerValue("imp_iva"),
                        imp_fracc = reader.IntegerValue("imp_fracc"),
                        imp_total = reader.IntegerValue("imp_total"),
                        cod_franquicia = reader.IntegerValue("cod_franquicia"),
                        nom_franquicia = reader.StringValue("nom_franquicia"),
                        txt_error = reader.StringValue("txt_error")
                    });
                }));

            return result;
        }
    }
}