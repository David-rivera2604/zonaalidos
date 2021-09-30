using Architect.DataFactory;
using System;
using System.Data;
using System.Data.Common;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    /// Funciones para el cotizador web para la lectura de polizas (EM_K_MAPFRE_BATCH_CONTRACT_MCR).
    /// </summary>
    public static class CrearPresupuesto
    {

        /// <summary>
        ///  Modificaciones de un tercero para un presupuesto
        /// </summary>
        public static bool PP_Insert_P1001331(Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero p1001331Instance, IDbConnection currentConnection)
        {
            bool result = false;
            int affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_P1001331")
                                           .AddParameter("P_FEC_TRATAMIENTO", Architect.DataFactory.Enumerations.DbType.Date, 0, p1001331Instance.fec_tratamiento)
                                           .AddParameter("P_TIP_MVTO_BATCH", Architect.DataFactory.Enumerations.DbType.String, 2, p1001331Instance.tip_mvto_batch)
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_cia)
                                           .AddParameter("P_TIP_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 3, p1001331Instance.tip_docum)
                                           .AddParameter("P_COD_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 20, p1001331Instance.cod_docum)
                                           .AddParameter("P_COD_ACT_TERCERO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_act_tercero)
                                           .AddParameter("P_MCA_FISICO", Architect.DataFactory.Enumerations.DbType.String, 1, p1001331Instance.mca_fisico)
                                           .AddParameter("P_APE1_TERCERO", Architect.DataFactory.Enumerations.DbType.String, 30, p1001331Instance.ape1_tercero)
                                           .AddParameter("P_APE2_TERCERO", Architect.DataFactory.Enumerations.DbType.String, 30, p1001331Instance.ape2_tercero)
                                           .AddParameter("P_NOM_TERCERO", Architect.DataFactory.Enumerations.DbType.String, 180, p1001331Instance.nom_tercero)
                                           .AddParameter("P_COD_TERCERO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_tercero)
                                           .AddParameter("P_TIP_DOCUM_PADRE", Architect.DataFactory.Enumerations.DbType.String, 3, p1001331Instance.tip_docum_padre)
                                           .AddParameter("P_COD_DOCUM_PADRE", Architect.DataFactory.Enumerations.DbType.String, 20, p1001331Instance.cod_docum_padre)
                                           .AddParameter("P_TIP_NACIONALIDAD", Architect.DataFactory.Enumerations.DbType.String, 1, p1001331Instance.tip_nacionalidad)
                                           .AddParameter("P_COD_NACIONALIDAD", Architect.DataFactory.Enumerations.DbType.String, 3, p1001331Instance.cod_nacionalidad)
                                           .AddParameter("P_TIP_DOMICILIO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.tip_domicilio)
                                           .AddParameter("P_NOM_DOMICILIO1", Architect.DataFactory.Enumerations.DbType.String, 40, p1001331Instance.nom_domicilio1)
                                           .AddParameter("P_NOM_DOMICILIO2", Architect.DataFactory.Enumerations.DbType.String, 40, p1001331Instance.nom_domicilio2)
                                           .AddParameter("P_NOM_DOMICILIO3", Architect.DataFactory.Enumerations.DbType.String, 40, p1001331Instance.nom_domicilio3)
                                           .AddParameter("P_NOM_LOCALIDAD", Architect.DataFactory.Enumerations.DbType.String, 30, p1001331Instance.nom_localidad)
                                           .AddParameter("P_COD_PAIS", Architect.DataFactory.Enumerations.DbType.String, 3, p1001331Instance.cod_pais)
                                           .AddParameter("P_COD_PROV", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_prov)
                                           .AddParameter("P_COD_POSTAL", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.cod_postal)
                                           .AddParameter("P_NUM_APARTADO", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.num_apartado)
                                           .AddParameter("P_TLF_PAIS", Architect.DataFactory.Enumerations.DbType.String, 3, p1001331Instance.tlf_pais)
                                           .AddParameter("P_TLF_ZONA", Architect.DataFactory.Enumerations.DbType.String, 5, p1001331Instance.tlf_zona)
                                           .AddParameter("P_TLF_NUMERO", Architect.DataFactory.Enumerations.DbType.String, 10, p1001331Instance.tlf_numero)
                                           .AddParameter("P_FAX_NUMERO", Architect.DataFactory.Enumerations.DbType.String, 10, p1001331Instance.fax_numero)
                                           .AddParameter("P_EMAIL", Architect.DataFactory.Enumerations.DbType.String, 60, p1001331Instance.email)
                                           .AddParameter("P_TIP_DOMICILIO_COM", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.tip_domicilio_com)
                                           .AddParameter("P_NOM_DOMICILIO1_COM", Architect.DataFactory.Enumerations.DbType.String, 40, p1001331Instance.nom_domicilio1_com)
                                           .AddParameter("P_NOM_DOMICILIO2_COM", Architect.DataFactory.Enumerations.DbType.String, 40, p1001331Instance.nom_domicilio2_com)
                                           .AddParameter("P_NOM_DOMICILIO3_COM", Architect.DataFactory.Enumerations.DbType.String, 40, p1001331Instance.nom_domicilio3_com)
                                           .AddParameter("P_NOM_LOCALIDAD_COM", Architect.DataFactory.Enumerations.DbType.String, 30, p1001331Instance.nom_localidad_com)
                                           .AddParameter("P_COD_PAIS_COM", Architect.DataFactory.Enumerations.DbType.String, 3, p1001331Instance.cod_pais_com)
                                           .AddParameter("P_COD_PROV_COM", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_prov_com)
                                           .AddParameter("P_COD_POSTAL_COM", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.cod_postal_com)
                                           .AddParameter("P_TLF_PAIS_COM", Architect.DataFactory.Enumerations.DbType.String, 3, p1001331Instance.tlf_pais_com)
                                           .AddParameter("P_TLF_ZONA_COM", Architect.DataFactory.Enumerations.DbType.String, 5, p1001331Instance.tlf_zona_com)
                                           .AddParameter("P_TLF_NUMERO_COM", Architect.DataFactory.Enumerations.DbType.String, 10, p1001331Instance.tlf_numero_com)
                                           .AddParameter("P_FAX_NUMERO_COM", Architect.DataFactory.Enumerations.DbType.String, 10, p1001331Instance.fax_numero_com)
                                           .AddParameter("P_EMAIL_COM", Architect.DataFactory.Enumerations.DbType.String, 60, p1001331Instance.email_com)
                                           .AddParameter("P_TXT_ETIQUETA1", Architect.DataFactory.Enumerations.DbType.String, 55, p1001331Instance.txt_etiqueta1)
                                           .AddParameter("P_TXT_ETIQUETA2", Architect.DataFactory.Enumerations.DbType.String, 55, p1001331Instance.txt_etiqueta2)
                                           .AddParameter("P_TXT_ETIQUETA3", Architect.DataFactory.Enumerations.DbType.String, 55, p1001331Instance.txt_etiqueta3)
                                           .AddParameter("P_TXT_ETIQUETA4", Architect.DataFactory.Enumerations.DbType.String, 55, p1001331Instance.txt_etiqueta4)
                                           .AddParameter("P_TXT_ETIQUETA5", Architect.DataFactory.Enumerations.DbType.String, 55, p1001331Instance.txt_etiqueta5)
                                           .AddParameter("P_NOM_CONTACTO", Architect.DataFactory.Enumerations.DbType.String, 60, p1001331Instance.nom_contacto)
                                           .AddParameter("P_TIP_CARGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.tip_cargo)
                                           .AddParameter("P_TIP_ACT_ECONOMICA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.tip_act_economica)
                                           .AddParameter("P_COD_ENTIDAD", Architect.DataFactory.Enumerations.DbType.String, 4, p1001331Instance.cod_entidad)
                                           .AddParameter("P_COD_OFICINA", Architect.DataFactory.Enumerations.DbType.String, 4, p1001331Instance.cod_oficina)
                                           .AddParameter("P_CTA_CTE", Architect.DataFactory.Enumerations.DbType.String, 30, p1001331Instance.cta_cte)
                                           .AddParameter("P_CTA_DC", Architect.DataFactory.Enumerations.DbType.String, 2, p1001331Instance.cta_dc)
                                           .AddParameter("P_FEC_NACIMIENTO", Architect.DataFactory.Enumerations.DbType.Date, 0, p1001331Instance.fec_nacimiento)
                                           .AddParameter("P_FEC_CARNET_CON", Architect.DataFactory.Enumerations.DbType.Date, 0, p1001331Instance.fec_carnet_con)
                                           .AddParameter("P_COD_OCUPACION", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_ocupacion)
                                           .AddParameter("P_COD_EST_CIVIL", Architect.DataFactory.Enumerations.DbType.String, 1, p1001331Instance.cod_est_civil)
                                           .AddParameter("P_COD_PROFESION", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_profesion)
                                           .AddParameter("P_MCA_SEXO", Architect.DataFactory.Enumerations.DbType.String, 1, p1001331Instance.mca_sexo)
                                           .AddParameter("P_COD_CALIDAD", Architect.DataFactory.Enumerations.DbType.String, 2, p1001331Instance.cod_calidad)
                                           .AddParameter("P_COD_IDIOMA", Architect.DataFactory.Enumerations.DbType.String, 3, p1001331Instance.cod_idioma)
                                           .AddParameter("P_OBS_ASEGURADO", Architect.DataFactory.Enumerations.DbType.String, 60, p1001331Instance.obs_asegurado)
                                           .AddParameter("P_COD_GRP_TERCERO", Architect.DataFactory.Enumerations.DbType.String, 10, p1001331Instance.cod_grp_tercero)
                                           .AddParameter("P_TXT_AUX1", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.txt_aux1)
                                           .AddParameter("P_TXT_AUX2", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.txt_aux2)
                                           .AddParameter("P_TXT_AUX3", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.txt_aux3)
                                           .AddParameter("P_TXT_AUX4", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.txt_aux4)
                                           .AddParameter("P_TXT_AUX5", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.txt_aux5)
                                           .AddParameter("P_TXT_AUX6", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.txt_aux6)
                                           .AddParameter("P_TXT_AUX7", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.txt_aux7)
                                           .AddParameter("P_TXT_AUX8", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.txt_aux8)
                                           .AddParameter("P_TXT_AUX9", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.txt_aux9)
                                           .AddParameter("P_COD_USR", Architect.DataFactory.Enumerations.DbType.String, 8, p1001331Instance.cod_usr)
                                           .AddParameter("P_FEC_ACTU", Architect.DataFactory.Enumerations.DbType.Date, 0, p1001331Instance.fec_actu)
                                           .AddParameter("P_TLF_MOVIL", Architect.DataFactory.Enumerations.DbType.String, 12, p1001331Instance.tlf_movil)
                                           .AddParameter("P_NUM_BUSCA", Architect.DataFactory.Enumerations.DbType.String, 10, p1001331Instance.num_busca)
                                           .AddParameter("P_TIP_ETIQUETA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.tip_etiqueta)
                                           .AddParameter("P_COD_ESTADO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_estado)
                                           .AddParameter("P_COD_ESTADO_COM", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_estado_com)
                                           .AddParameter("P_TXT_EMAIL", Architect.DataFactory.Enumerations.DbType.String, 60, p1001331Instance.txt_email)
                                           .AddParameter("P_NUM_APARTADO_COM", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.num_apartado_com)
                                           .AddParameter("P_COD_PAIS_ETIQUETA", Architect.DataFactory.Enumerations.DbType.String, 3, p1001331Instance.cod_pais_etiqueta)
                                           .AddParameter("P_COD_ESTADO_ETIQUETA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_estado_etiqueta)
                                           .AddParameter("P_COD_PROV_ETIQUETA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_prov_etiqueta)
                                           .AddParameter("P_COD_POSTAL_ETIQUETA", Architect.DataFactory.Enumerations.DbType.String, 10, p1001331Instance.cod_postal_etiqueta)
                                           .AddParameter("P_NUM_APARTADO_ETIQUETA", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.num_apartado_etiqueta)
                                           .AddParameter("P_COD_LOCALIDAD", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_localidad)
                                           .AddParameter("P_TIP_TARJETA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.tip_tarjeta)
                                           .AddParameter("P_COD_TARJETA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_tarjeta)
                                           .AddParameter("P_NUM_TARJETA", Architect.DataFactory.Enumerations.DbType.String, 30, p1001331Instance.num_tarjeta)
                                           .AddParameter("P_COD_LOCALIDAD_COM", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_localidad_com)
                                           .AddParameter("P_COD_LOCALIDAD_ETIQUETA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_localidad_etiqueta)
                                           .AddParameter("P_NOM_LOCALIDAD_ETIQUETA", Architect.DataFactory.Enumerations.DbType.String, 30, p1001331Instance.nom_localidad_etiqueta)
                                           .AddParameter("P_FEC_VCTO_TARJETA", Architect.DataFactory.Enumerations.DbType.Date, 0, p1001331Instance.fec_vcto_tarjeta)
                                           .AddParameter("P_COD_COMPENSACION", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_compensacion)
                                           .AddParameter("P_COD_SOC_GL", Architect.DataFactory.Enumerations.DbType.String, 6, p1001331Instance.cod_soc_gl)
                                           .AddParameter("P_NOM_ALIAS", Architect.DataFactory.Enumerations.DbType.String, 180, p1001331Instance.nom_alias)
                                           .AddParameter("P_NOM2_TERCERO", Architect.DataFactory.Enumerations.DbType.String, 180, p1001331Instance.nom2_tercero)
                                           .AddParameter("P_TIP_SUFIJO_NOMBRE", Architect.DataFactory.Enumerations.DbType.String, 3, p1001331Instance.tip_sufijo_nombre)
                                           .AddParameter("P_COD_CLASE_BENEF", Architect.DataFactory.Enumerations.DbType.String, 5, p1001331Instance.cod_clase_benef)
                                           .AddParameter("P_COD_CAUSA_INH_TRC", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_causa_inh_trc)
                                           .AddParameter("P_MCA_INH", Architect.DataFactory.Enumerations.DbType.String, 1, p1001331Instance.mca_inh)
                                           .AddParameter("P_NUM_CARNET_CON", Architect.DataFactory.Enumerations.DbType.String, 25, p1001331Instance.num_carnet_con)
                                           .AddParameter("P_COD_SITU_CARNET_CON", Architect.DataFactory.Enumerations.DbType.String, 3, p1001331Instance.cod_situ_carnet_con)
                                           .AddParameter("P_ATR_DOMICILIO1", Architect.DataFactory.Enumerations.DbType.String, 30, p1001331Instance.atr_domicilio1)
                                           .AddParameter("P_ATR_DOMICILIO2", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.atr_domicilio2)
                                           .AddParameter("P_ATR_DOMICILIO3", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.atr_domicilio3)
                                           .AddParameter("P_ATR_DOMICILIO4", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.atr_domicilio4)
                                           .AddParameter("P_ATR_DOMICILIO5", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.atr_domicilio5)
                                           .AddParameter("P_ANX_DOMICILIO", Architect.DataFactory.Enumerations.DbType.String, 150, p1001331Instance.anx_domicilio)
                                           .AddParameter("P_EXT_COD_POSTAL", Architect.DataFactory.Enumerations.DbType.String, 10, p1001331Instance.ext_cod_postal)
                                           .AddParameter("P_TLF_EXTENSION", Architect.DataFactory.Enumerations.DbType.String, 10, p1001331Instance.tlf_extension)
                                           .AddParameter("P_NOM_EMPRESA_COM", Architect.DataFactory.Enumerations.DbType.String, 180, p1001331Instance.nom_empresa_com)
                                           .AddParameter("P_ATR_DOMICILIO1_COM", Architect.DataFactory.Enumerations.DbType.String, 30, p1001331Instance.atr_domicilio1_com)
                                           .AddParameter("P_ATR_DOMICILIO2_COM", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.atr_domicilio2_com)
                                           .AddParameter("P_ATR_DOMICILIO3_COM", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.atr_domicilio3_com)
                                           .AddParameter("P_ATR_DOMICILIO4_COM", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.atr_domicilio4_com)
                                           .AddParameter("P_ATR_DOMICILIO5_COM", Architect.DataFactory.Enumerations.DbType.String, 15, p1001331Instance.atr_domicilio5_com)
                                           .AddParameter("P_ANX_DOMICILIO_COM", Architect.DataFactory.Enumerations.DbType.String, 150, p1001331Instance.anx_domicilio_com)
                                           .AddParameter("P_TLF_EXTENSION_COM", Architect.DataFactory.Enumerations.DbType.String, 10, p1001331Instance.tlf_extension_com)
                                           .AddParameter("P_EXT_COD_POSTAL_COM", Architect.DataFactory.Enumerations.DbType.String, 10, p1001331Instance.ext_cod_postal_com)
                                           .AddParameter("P_EXT_COD_POSTAL_ETIQUETA", Architect.DataFactory.Enumerations.DbType.String, 10, p1001331Instance.ext_cod_postal_etiqueta)
                                           .AddParameter("P_COD_EXP_CARNET_CON", Architect.DataFactory.Enumerations.DbType.Int32, 22, p1001331Instance.cod_exp_carnet_con)
                                           .Execute(currentConnection);
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }


        /// <summary>
        ///  Datos fijos del presupuesto
        /// </summary>
        public static bool PP_Insert_P2000030(Architect.API.Tron.Contracts.Presupuesto.DatoFijo p2000030Instance, IDbConnection currentConnection)
        {
            bool result = false;
            int affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_P2000030")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_cia)
                                           .AddParameter("P_COD_SECTOR", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_sector)
                                           .AddParameter("P_COD_RAMO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_ramo)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, p2000030Instance.num_poliza, ParameterDirection.InputOutput)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.num_spto_apli)
                                           .AddParameter("P_COD_NIVEL1", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_nivel1)
                                           .AddParameter("P_COD_NIVEL2", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_nivel2)
                                           .AddParameter("P_COD_NIVEL3", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_nivel3)
                                           .AddParameter("P_COD_AGT", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_agt)
                                           .AddParameter("P_COD_CUADRO_COM", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_cuadro_com)
                                           .AddParameter("P_COD_FRACC_PAGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_fracc_pago)
                                           .AddParameter("P_COD_MON", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_mon)
                                           .AddParameter("P_FEC_EFEC_POLIZA", Architect.DataFactory.Enumerations.DbType.Date, 0, p2000030Instance.fec_efec_poliza)
                                           .AddParameter("P_FEC_VCTO_POLIZA", Architect.DataFactory.Enumerations.DbType.Date, 0, p2000030Instance.fec_vcto_poliza)
                                           .AddParameter("P_TIP_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 3, p2000030Instance.tip_docum)
                                           .AddParameter("P_COD_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 20, p2000030Instance.cod_docum)
                                           .AddParameter("P_FEC_TRATAMIENTO", Architect.DataFactory.Enumerations.DbType.Date, 0, p2000030Instance.fec_tratamiento)
                                           .AddParameter("P_NUM_ORDEN", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.num_orden)
                                           .AddParameter("P_TIP_MVTO_BATCH", Architect.DataFactory.Enumerations.DbType.String, 2, p2000030Instance.tip_mvto_batch)
                                           .AddParameter("P_NUM_POLIZA_GRUPO", Architect.DataFactory.Enumerations.DbType.String, 13, p2000030Instance.num_poliza_grupo)
                                           .AddParameter("P_NUM_CONTRATO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.num_contrato)
                                           .AddParameter("P_NUM_POLIZA_ANTERIOR", Architect.DataFactory.Enumerations.DbType.String, 13, p2000030Instance.num_poliza_anterior)
                                           .AddParameter("P_TIP_GESTOR", Architect.DataFactory.Enumerations.DbType.String, 2, p2000030Instance.tip_gestor)
                                           .AddParameter("P_COD_GESTOR", Architect.DataFactory.Enumerations.DbType.String, 13, p2000030Instance.cod_gestor)
                                           .AddParameter("P_TXT_MOTIVO", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.txt_motivo)
                                           .AddParameter("P_HORA_DESDE", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.hora_desde)
                                           .AddParameter("P_MCA_REASEGURO_MANUAL", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.mca_reaseguro_manual)
                                           .AddParameter("P_MCA_PRIMA_MANUAL", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.mca_prima_manual)
                                           .Execute(currentConnection, new Action<DbCommand>((command) =>
                                           {
                                               p2000030Instance.num_poliza = (command.Parameters["P_NUM_POLIZA"].Value.ToString());
                                           }));
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        ///  Riesgos del presupuesto
        /// </summary>
        public static bool PP_Insert_P2000031(Architect.API.Tron.Contracts.Presupuesto.Riesgo p2000031Instance, IDbConnection currentConnection)
        {
            bool result = false;
            int affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_P2000031")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000031Instance.cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, p2000031Instance.num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000031Instance.num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000031Instance.num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000031Instance.num_spto_apli)
                                           .AddParameter("P_FEC_EFEC_RIESGO", Architect.DataFactory.Enumerations.DbType.Date, 0, p2000031Instance.fec_efec_riesgo)
                                           .AddParameter("P_FEC_VCTO_RIESGO", Architect.DataFactory.Enumerations.DbType.Date, 0, p2000031Instance.fec_vcto_riesgo)
                                           .AddParameter("P_MCA_BAJA_RIESGO", Architect.DataFactory.Enumerations.DbType.String, 1, p2000031Instance.mca_baja_riesgo)
                                           .AddParameter("P_MCA_VIGENTE", Architect.DataFactory.Enumerations.DbType.String, 1, p2000031Instance.mca_vigente)
                                           .AddParameter("P_MCA_EXCLUSIVO", Architect.DataFactory.Enumerations.DbType.String, 1, p2000031Instance.mca_exclusivo)
                                           .AddParameter("P_NUM_RIESGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000031Instance.num_riesgo)
                                           .AddParameter("P_NOM_RIESGO", Architect.DataFactory.Enumerations.DbType.String, 80, p2000031Instance.nom_riesgo)
                                           .AddParameter("P_TIP_SPTO", Architect.DataFactory.Enumerations.DbType.String, 2, p2000031Instance.tip_spto)
                                           .AddParameter("P_COD_MODALIDAD", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000031Instance.cod_modalidad)
                                           .Execute(currentConnection);
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        ///  Datos variables del presupuesto
        /// </summary>
        public static bool PP_Insert_P2000020(Architect.API.Tron.Contracts.Presupuesto.DatoVariable p2000020Instance, IDbConnection currentConnection)
        {
            bool result = false;
            int affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_P2000020")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, p2000020Instance.num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_spto_apli)
                                           .AddParameter("P_NUM_RIESGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_riesgo)
                                           .AddParameter("P_NUM_PERIODO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_periodo)
                                           .AddParameter("P_TIP_NIVEL", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.tip_nivel)
                                           .AddParameter("P_COD_CAMPO", Architect.DataFactory.Enumerations.DbType.String, 30, p2000020Instance.cod_campo)
                                           .AddParameter("P_VAL_CAMPO", Architect.DataFactory.Enumerations.DbType.String, 80, p2000020Instance.val_campo)
                                           .AddParameter("P_VAL_COR_CAMPO", Architect.DataFactory.Enumerations.DbType.String, 10, p2000020Instance.val_cor_campo)
                                           .AddParameter("P_NUM_SECU", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_secu)
                                           .AddParameter("P_COD_RAMO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.cod_ramo)
                                           .Execute( currentConnection, "Tron");
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        ///  Ocurrencias del presupuesto
        /// </summary>
        public static bool PP_Insert_P2000025(Architect.API.Tron.Contracts.Presupuesto.Ocurrencia p2000025Instance, IDbConnection currentConnection)
        {
            bool result = false;
            int affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_P2000025")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000025Instance.cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, p2000025Instance.num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000025Instance.num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000025Instance.num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000025Instance.num_spto_apli)
                                           .AddParameter("P_NUM_RIESGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000025Instance.num_riesgo)
                                           .AddParameter("P_NUM_PERIODO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000025Instance.num_periodo)
                                           .AddParameter("P_COD_LISTA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000025Instance.cod_lista)
                                           .AddParameter("P_NUM_OCURRENCIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000025Instance.num_ocurrencia)
                                           .AddParameter("P_NUM_SECU", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000025Instance.num_secu)
                                           .AddParameter("P_COD_CAMPO", Architect.DataFactory.Enumerations.DbType.String, 30, p2000025Instance.cod_campo)
                                           .AddParameter("P_VAL_CAMPO", Architect.DataFactory.Enumerations.DbType.String, 80, p2000025Instance.val_campo)
                                           .AddParameter("P_TXT_CAMPO", Architect.DataFactory.Enumerations.DbType.String, 80, p2000025Instance.txt_campo)
                                           .AddParameter("P_MCA_BAJA_RIESGO", Architect.DataFactory.Enumerations.DbType.String, 1, p2000025Instance.mca_baja_riesgo)
                                           .AddParameter("P_MCA_VIGENTE", Architect.DataFactory.Enumerations.DbType.String, 1, p2000025Instance.mca_vigente)
                                           .AddParameter("P_MCA_VIGENTE_APLI", Architect.DataFactory.Enumerations.DbType.String, 1, p2000025Instance.mca_vigente_apli)
                                           .AddParameter("P_MCA_BAJA_OCURRENCIA", Architect.DataFactory.Enumerations.DbType.String, 1, p2000025Instance.mca_baja_ocurrencia)
                                           .AddParameter("P_IMP_OCURRENCIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000025Instance.imp_ocurrencia)
                                           .Execute(currentConnection);
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        ///  Terceros del presupuesto
        /// </summary>
        public static bool PP_Insert_P2000060(Architect.API.Tron.Contracts.Presupuesto.Tercero p2000060Instance, IDbConnection currentConnection)
        {
            bool result = false;
            int affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_P2000060")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000060Instance.cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, p2000060Instance.num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000060Instance.num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000060Instance.num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000060Instance.num_spto_apli)
                                           .AddParameter("P_NUM_RIESGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000060Instance.num_riesgo)
                                           .AddParameter("P_MCA_PRINCIPAL", Architect.DataFactory.Enumerations.DbType.String, 1, p2000060Instance.mca_principal)
                                           .AddParameter("P_MCA_CALCULO", Architect.DataFactory.Enumerations.DbType.String, 1, p2000060Instance.mca_calculo)
                                           .AddParameter("P_MCA_BAJA", Architect.DataFactory.Enumerations.DbType.String, 1, p2000060Instance.mca_baja)
                                           .AddParameter("P_MCA_VIGENTE", Architect.DataFactory.Enumerations.DbType.String, 1, p2000060Instance.mca_vigente)
                                           .AddParameter("P_TIP_BENEF", Architect.DataFactory.Enumerations.DbType.String, 2, p2000060Instance.tip_benef)
                                           .AddParameter("P_NUM_SECU", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000060Instance.num_secu)
                                           .AddParameter("P_TIP_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 3, p2000060Instance.tip_docum)
                                           .AddParameter("P_COD_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 20, p2000060Instance.cod_docum)
                                           .AddParameter("P_PCT_PARTICIPACION", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000060Instance.pct_participacion)
                                           .AddParameter("P_FEC_VCTO_CESION", Architect.DataFactory.Enumerations.DbType.Date, 0, p2000060Instance.fec_vcto_cesion)
                                           .AddParameter("P_IMP_CESION", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000060Instance.imp_cesion)
                                           .AddParameter("P_NUM_PRESTAMO", Architect.DataFactory.Enumerations.DbType.String, 20, p2000060Instance.num_prestamo)
                                           .AddParameter("P_TIP_RELAC", Architect.DataFactory.Enumerations.DbType.String, 2, p2000060Instance.tip_relac)
                                           .Execute(currentConnection);
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        ///  Coberturas del presupuesto
        /// </summary>
        public static bool PP_Insert_P2000040(Architect.API.Tron.Contracts.Presupuesto.Cobertura p2000040Instance, IDbConnection currentConnection)
        {
            bool result = false;
            int affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_P2000040")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000040Instance.cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, p2000040Instance.num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000040Instance.num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000040Instance.num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000040Instance.num_spto_apli)
                                           .AddParameter("P_NUM_RIESGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000040Instance.num_riesgo)
                                           .AddParameter("P_NUM_PERIODO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000040Instance.num_periodo)
                                           .AddParameter("P_COD_COB", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000040Instance.cod_cob)
                                           .AddParameter("P_COD_RAMO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000040Instance.cod_ramo)
                                           .AddParameter("P_NUM_SECU", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000040Instance.num_secu)
                                           .AddParameter("P_SUMA_ASEG", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000040Instance.suma_aseg)
                                           .AddParameter("P_IMP_PRIMA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000040Instance.imp_prima)
                                           .AddParameter("P_COD_SECC_REAS", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000040Instance.cod_secc_reas)
                                           .AddParameter("P_SUM_ASEG_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000040Instance.sum_aseg_spto)
                                           .Execute(currentConnection);
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }

    }
}
