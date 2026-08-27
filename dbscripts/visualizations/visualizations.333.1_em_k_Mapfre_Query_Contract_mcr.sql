CREATE OR REPLACE PACKAGE TRON2000.em_k_Mapfre_Query_Contract_mcr AS
 /**
 ||
 || Procedimientos y funciones del servicio de consulta
 ||
 */
 --
 /* -------------------- VERSION = 1.05 -------------------- */
 --
 /* -------------------- MODIFICACIONES --------------------
 ||  27-NOV-2012: MANUEL.A.ROJAS.H (MCR)
 ||    CREACION DEL PROGRAMA
 ||
 */ -----------------------------------------------------------------
--
 --
 /* -------------------- VERSION = 1.01 -------------------- */
/*
||
|| Cambios 13-7-2021 Royner Acosta
|| Se agregan las funciones: f_search_province_client, f_search_state_client, f_search_location_client
|| Se agrega el procedimiento: p_search_information_client
|| Por solicitud  para que desde la web se visualice la informacion del cliente.

*/
/* -------------------- VERSION = 1.02 -------------------- */
/*
||
|| Cambios 18-8-2022 Royner Acosta
|| Se agregan las funciones: f_obtener_total_recibo, , f_obtener_total_comision
*/
--
/* -------------------- VERSION = 1.03 -------------------- */
/*
||
|| Cambios 15/11/2022 Royner Acosta
|| Se agregan las funcion: f_search_name_client (FUNCION QUE BUSCA EL NOMBRE COMPLETO DE UN TERCERO)
*/
--
/* -------------------- VERSION = 1.04 -------------------- */
/*
||
|| Cambios 11/4/2023 Royner Acosta
|| Se agrega funcionf_obtener_dato_variable Tiquete de Referencia RF01493992
*/
/* -------------------- VERSION = 1.05 -------------------- */
/*
||
|| Cambios 30/10/2024 INDRA - Fernando Rache
|| Creaci?n de procedimiento p_policy_by_agent_tomador_za.
||
*/---------------------------------------------------------
--
/* --------------------------------------------------------
|| p_policy_by_agent :
||
|| Lee las polizas activas de un agente
||
*/ --------------------------------------------------------
--
PROCEDURE p_policy_by_agent (p_cod_cia          a2000030.cod_cia%TYPE,
                             p_cod_agt          a2000030.cod_agt%TYPE,
                             RC1         IN OUT SYS_REFCURSOR);
--
/* --------------------------------------------------------
|| p_pending_receipts :
||
|| Lee los recibos pendientes de las polizas de un agente
||
*/ --------------------------------------------------------
--
PROCEDURE p_pending_receipts (p_cod_cia          a2000030.cod_cia%TYPE,
                              p_cod_agt          a2000030.cod_agt%TYPE,
                              p_cant_dias        NUMBER,
                              RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpending_receipts);
--
/* --------------------------------------------------------
|| p_pending_receipts :
||
|| Lee los recibos pendientes de las polizas de un agente
||
*/ --------------------------------------------------------
--
PROCEDURE p_pending_receipts (p_cod_cia          a2000030.cod_cia%TYPE,
                              p_cod_agt          a2000030.cod_agt%TYPE,
                              p_fec_efec_recibo  a2990700.fec_efec_recibo %TYPE,
                              p_fec_vcto_recibo  a2990700.fec_vcto_recibo %TYPE,
                              RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpending_receipts);
--
/* --------------------------------------------------------
|| p_claims :
||
|| Lee los siniestors pendientes de las polizas de un agente
||
*/ --------------------------------------------------------
--
PROCEDURE p_claims (p_cod_cia          a2000030.cod_cia%TYPE,
                    p_cod_agt          a2000030.cod_agt%TYPE,
                    p_tip_est_exp      a7001000.tip_est_exp%TYPE, -- P: pendiente, T: completo
                    RC1         IN OUT SYS_REFCURSOR);
--
/* --------------------------------------------------------
|| p_pending_receipts :
||
|| Lee los recibos pendientes de las polizas de un agente
||
*/ --------------------------------------------------------
--
PROCEDURE p_pending_commission (p_cod_cia          a2000030.cod_cia%TYPE,
                                p_cod_agt          a2000030.cod_agt%TYPE,
                                RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpending_commission);
--
/* --------------------------------------------------------
|| p_paid_commissionDet :
||
|| Lee el detalle de las comisiones pagadas a un agente en un periodo
||
*/ --------------------------------------------------------
--
PROCEDURE p_pending_commissionDet (p_cod_cia          a5020054.cod_cia%TYPE,
                                   p_cod_agt          a5020054.cod_agt%TYPE,
                                   p_cod_mon          a5020054.cod_mon%TYPE,
                                   RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpending_commissionDet);
--
/* --------------------------------------------------------
|| p_paid_commission :
||
|| Lee las comisiones pagadas a un agente
||
*/ --------------------------------------------------------
--
PROCEDURE p_paid_commission (p_cod_cia          a2000030.cod_cia%TYPE,
                             p_cod_agt          a2000030.cod_agt%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpaid_commission);
--
/* --------------------------------------------------------
|| p_paid_commissionDet :
||
|| Lee el detalle de las comisiones pagadas a un agente en un periodo
||
*/ --------------------------------------------------------
--
PROCEDURE p_paid_commissionDet (p_cod_cia          a5020054.cod_cia%TYPE,
                                p_cod_agt          a5020054.cod_agt%TYPE,
                                p_cod_mon          a5020054.cod_mon%TYPE,
                                p_fec_proceso      a5020054.fec_proceso%TYPE,
                                RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpaid_commissionDet);
/* --------------------------------------------------------
|| p_paid_commission :
||
|| Lee el detalle de las deducciones realizadas a un agente en un periodo
||
*/ --------------------------------------------------------
--
PROCEDURE p_paid_commissionDetDeduc (p_cod_cia          a5020054.cod_cia%TYPE,
                                     p_cod_agt          a5020054.cod_agt%TYPE,
                                     p_cod_mon          a5020054.cod_mon%TYPE,
                                     p_fec_proceso      a5020054.fec_proceso%TYPE,
                                     RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpaid_commissionDetDeduc);
--
/* --------------------------------------------------------
|| p_policies_cancelled :
||
|| Lee las polizas canceladas de un agente
||
*/ --------------------------------------------------------
--
PROCEDURE p_policies_cancelled (p_cod_cia          a2000030.cod_cia%TYPE,
                             p_cod_agt          a2000030.cod_agt%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolies_canceled);
--
/* --------------------------------------------------------
|| p_premium_collection :
||
|| Lee los recibos cobrados de las polizas de un agente en un mes
||
*/ --------------------------------------------------------
--
PROCEDURE p_premium_collection (p_cod_cia          a2000030.cod_cia%TYPE,
                                p_cod_agt          a2000030.cod_agt%TYPE,
                                p_mes_proceso      NUMBER,
                                p_anio_proceso     NUMBER,
                                RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTPREMIUMCOLLECTION);
--
/* --------------------------------------------------------
|| p_claims :
||
|| Lee los siniestors pendientes de las polizas de un agente
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--
PROCEDURE p_claims_by_policy (p_cod_cia          a2000030.cod_cia%TYPE,
                    p_tip_est_exp      a7001000.tip_est_exp%TYPE, -- P: pendiente, T: completo
                    p_fec_sini_ini     a7000900.fec_sini%TYPE,
                    p_fec_sini_fin     a7000900.fec_sini%TYPE,
                    p_num_poliza       a2000030.num_poliza%TYPE,
                    RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTp_claims_by_policy);
--
/* --------------------------------------------------------
|| p_group_polcy_by_document :
||
|| Lee las polizas grupo
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--
PROCEDURE p_group_polcy_by_document (p_cod_cia          a2000030.cod_cia%TYPE,
         p_cod_docum          a2000030.cod_docum%TYPE,
         RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTp_group_polcy_by_document);
--
/* --------------------------------------------------------
|| p_policies_by_group_policy :
||
|| Obtiene las polizas por numero de poliza grupo
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--
PROCEDURE p_policies_by_group_policy(p_cod_cia          a2000030.cod_cia%TYPE,
                        p_num_poliza_grupo            a2000030.num_poliza_grupo%TYPE,
                        p_cod_ramo                  a2000030.cod_ramo%TYPE,
                        p_num_poliza               a2000030.num_poliza%TYPE,
                        p_val_campo                a2000020.val_campo%TYPE,
                        p_nom_completo             v1001390.NOM_COMPLETO%TYPE,
                        p_tip_docum                a2000030.tip_docum%TYPE,
                        p_cod_docum                a2000030.cod_docum%TYPE,
                        p_fec_efec_poliza          a2000030.fec_efec_poliza%TYPE,
                        p_fec_vcto_poliza          a2000030.fec_vcto_poliza%TYPE,
                        RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolicy_by_agent);

--
/* --------------------------------------------------------
|| p_policies_agent :
||
|| Obtiene las polizas por agente
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--

PROCEDURE p_policies_agent(p_cod_cia          a2000030.cod_cia%TYPE,
                             p_cod_agt          a2000030.cod_agt%TYPE,
                             p_val_campo                a2000020.val_campo%TYPE,
                             p_cod_ramo                  a2000030.cod_ramo%TYPE,
                             p_num_poliza               a2000030.num_poliza%TYPE,
                             p_nom_completo             v1001390.NOM_COMPLETO%TYPE,
                             p_tip_docum                a2000030.tip_docum%TYPE,
                             p_cod_docum                a2000030.cod_docum%TYPE,
                             p_fec_efec_poliza          a2000030.fec_efec_poliza%TYPE,
                             p_fec_vcto_poliza          a2000030.fec_vcto_poliza%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolicy_by_agent);
--
/* --------------------------------------------------------
|| p_policy_by_agent :
||
|| Lee las polizas canceladas de un grupo de polizas
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--

PROCEDURE p_policy_cancel_by_group_pol (p_cod_cia          a2000030.cod_cia%TYPE,
                             p_num_poliza_grupo            a2000030.num_poliza_grupo%TYPE,
                             p_val_campo                a2000020.val_campo%TYPE,
                             p_cod_ramo                  a2000030.cod_ramo%TYPE,
                             p_num_poliza               a2000030.num_poliza%TYPE,
                             p_nom_completo             v1001390.NOM_COMPLETO%TYPE,
                             p_tip_docum                a2000030.tip_docum%TYPE,
                             p_cod_docum                a2000030.cod_docum%TYPE,
                             p_fec_efec_poliza          a2000030.fec_efec_poliza%TYPE,
                             p_fec_vcto_poliza          a2000030.fec_vcto_poliza%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolies_canceled);

--
/* --------------------------------------------------------
|| p_policy_by_agent :
||
|| Lee las polizas canceladas de un agente
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--

PROCEDURE p_policies_cancelled_agent (p_cod_cia          a2000030.cod_cia%TYPE,
                             p_cod_agt          a2000030.cod_agt%TYPE,
                             p_val_campo                a2000020.val_campo%TYPE,
                             p_cod_ramo                  a2000030.cod_ramo%TYPE,
                             p_num_poliza               a2000030.num_poliza%TYPE,
                             p_nom_completo             v1001390.NOM_COMPLETO%TYPE,
                             p_tip_docum                a2000030.tip_docum%TYPE,
                             p_cod_docum                a2000030.cod_docum%TYPE,
                             p_fec_efec_poliza          a2000030.fec_efec_poliza%TYPE,
                             p_fec_vcto_poliza          a2000030.fec_vcto_poliza%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolies_canceled);

--
/* --------------------------------------------------------
|| p_info_extra :
||
|| Obtiene informacion extra sobre datos del tomador o agente
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--

PROCEDURE p_info_extra      (p_cod_cia          a1001300.cod_cia%TYPE,
                             p_tip_docum                   a1001300.tip_docum%TYPE,
                             p_cod_docum                  a1001300.cod_docum%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpinfoextra);

--
/* --------------------------------------------------------
|| p_cc_policies :
||
|| Obtiene todas las polizas para el callcenter
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--

PROCEDURE p_cc_policies(p_cod_cia          a2000030.cod_cia%TYPE,
                        p_cod_ramo                  a2000030.cod_ramo%TYPE,
                        p_num_poliza               a2000030.num_poliza%TYPE,
                        p_val_campo                a2000020.val_campo%TYPE,
                        p_nom_completo             v1001390.NOM_COMPLETO%TYPE,
                        p_tip_docum                a2000030.tip_docum%TYPE,
                        p_cod_docum                a2000030.cod_docum%TYPE,
                        p_fec_efec_poliza          a2000030.fec_efec_poliza%TYPE,
                        p_fec_vcto_poliza          a2000030.fec_vcto_poliza%TYPE,
                        RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolicy_by_agent);

--
/* --------------------------------------------------------
|| p_cc_policies_canceled :
||
|| Obtiene todas las polizas canceladas para el callcenter
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--


PROCEDURE p_cc_policies_canceled (p_cod_cia          a2000030.cod_cia%TYPE,
                             p_val_campo                a2000020.val_campo%TYPE,
                             p_cod_ramo                  a2000030.cod_ramo%TYPE,
                             p_num_poliza               a2000030.num_poliza%TYPE,
                             p_nom_completo             v1001390.NOM_COMPLETO%TYPE,
                             p_tip_docum                a2000030.tip_docum%TYPE,
                             p_cod_docum                a2000030.cod_docum%TYPE,
                             p_fec_efec_poliza          a2000030.fec_efec_poliza%TYPE,
                             p_fec_vcto_poliza          a2000030.fec_vcto_poliza%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolies_canceled);

---Procedimiento para consulta de Polizas por agente
-- Se agrega para quitar filtro de mca_provisional = N
--Funcionalidades Purdy (Consulta de documentos polizas)
--Royner Acosta Guevara

PROCEDURE p_policy_by_agent_documents (p_cod_cia          a2000030.cod_cia%TYPE,
                                       p_cod_agt          a2000030.cod_agt%TYPE,
                                       RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolicy_by_agent);

---Procedimiento para consulta de Polizas por agente
--Se crea dado que los agentes requieren que la consulta se realice por tomador
-- y no por asegurado
--Royner Acosta Guevara 12-4-2021

PROCEDURE p_policy_by_agent_tomador (p_cod_cia          a2000030.cod_cia%TYPE,
                                     p_cod_agt          a2000030.cod_agt%TYPE,
                                     RC1         IN OUT SYS_REFCURSOR
                                    );
--
--Procedimiento para consulta de Polizas por agente
--Trae informacion del tomador y asegurado ?nicamente para ramos de Zona Aliados
PROCEDURE p_policy_by_agent_tomador_za(p_cod_cia  IN     a2000030.cod_cia%TYPE,
                                       p_cod_agt  IN     a2000030.cod_agt%TYPE,
                                       RC1        IN OUT SYS_REFCURSOR
                                      );
/* --------------------------------------------------------
|| p_premium_collection :
||
|| Lee los recibos cobrados de las polizas de un agente en un rango de fechas
|| Royner Acosta Guevara 06-7-2021
*/ --------------------------------------------------------
--
PROCEDURE p_premium_collection_date_range (p_cod_cia          a2000030.cod_cia%TYPE,
                                           p_cod_agt          a2000030.cod_agt%TYPE,
                                           p_fec_ini          Date,
                                           p_fec_fin          Date,
                                           RC1         IN OUT SYS_REFCURSOR);

--FUNCION QUE BUSCA LA UBICACION DE LA PROVINCIA REGISTRADA DE UN TERCERO
 FUNCTION f_search_province_client(p_cod_estado VARCHAR) return varchar2;

--FUNCION QUE BUSCA LA UBICACION DEL CANTON REGISTRADO DE UN TERCERO
 FUNCTION f_search_state_client(p_cod_estado VARCHAR,p_cod_prov VARCHAR) return varchar2;

--FUNCION QUE BUSCA LA UBICACION DE LA LOCALIDAD REGISTRADA DE UN TERCERO
 FUNCTION f_search_location_client(p_cod_prov VARCHAR, p_cod_localidad VARCHAR) return varchar2;

--FUNCION QUE BUSCA EL NOMBRE COMPLETO DE UN TERCERO
FUNCTION f_search_name_client(p_tip_docum varchar,p_cod_docum varchar) return varchar2;

--FUNCION QUE BUSCA EL NOMBRE COMPLETO DE UN TIP_BENEF
FUNCTION f_search_name_client_tip_benef(p_num_poliza varchar, p_tip_benef varchar) return varchar2;
--FUNCION QUE BUSCA EL email DE UN TERCERO
FUNCTION f_search_email_client(p_tip_docum varchar,p_cod_docum varchar) return varchar2;

--FUNCION QUE BUSCA EL telefono DE UN TERCERO
FUNCTION f_search_phone_client(p_tip_docum varchar,p_cod_docum varchar) return varchar2;

--PROCEDIMIENTO QUE BUSCA LA INFORMACION PERSONAL DE UN TERCERO
PROCEDURE p_search_information_client(p_tip_docum varchar,
                                      p_cod_docum varchar,
                                      RC1 IN OUT SYS_REFCURSOR);

-----Funcion que trae el total monto total de un recibo
function f_obtener_total_recibo(cod_cia varchar, num_recibo number) return number;
-----Funcion que trae el total monto total de comision
function f_obtener_total_comision(cod_cia varchar, num_recibo number) return number;
--Funcion que trae valores de datos Variables
function f_obtener_dato_variable(p_num_poliza varchar, p_cod_campo varchar) return varchar;
--
--Funcion para buscar la tarjeta ligada a un tipo de tercero en la poliza
--
function f_obtener_num_tarjeta(p_cod_cia number, p_num_poliza varchar) return varchar;



-- procedimiento para tokenizar tarjetas
PROCEDURE p_tokeniza_tarjeta (RC1         IN OUT SYS_REFCURSOR);
--
PROCEDURE p_Reporte_Cobro_Sinpe(Desde a2000030.Fec_Validez%TYPE,
                                Hasta a2000030.Fec_Validez%TYPE,
                                RC1   IN OUT SYS_REFCURSOR);


END em_k_Mapfre_Query_Contract_mcr;

CREATE OR REPLACE PACKAGE BODY TRON2000.em_k_Mapfre_Query_Contract_mcr AS
 /**
 ||
 || Procedimientos y funciones del servicio de consulta
 ||
 */
 --
 /* -------------------- VERSION = 1.05 -------------------- */
 --
 /* -------------------- MODIFICACIONES --------------------
 ||  27-NOV-2012: MANUEL.A.ROJAS.H (MCR)
 ||    CREACION DEL PROGRAMA
 ||
 */ -----------------------------------------------------------------
/*
||
|| Cambios 18-8-2022 Royner Acosta
|| Se agregan las funciones: f_obtener_total_recibo, , f_obtener_total_comision
*/
--
/* --------------------------------------------------------
|| p_policy_by_agent :
||
|| Lee las polizas activas de un agente
||
*/ --------------------------------------------------------
--
/* --------------------------------------------------------
|| p_policy_by_agent :
||
|| Royner Acosta 26-1-2021
|| Se agrega filtro para que solo traiga las polizas vigentes
|| AND a.mca_provisional    = 'N'
||
*/ --------------------------------------------------------
--
/* --------------------------------------------------------
|| p_policy_by_agent :
||
|| Royner Acosta 10-3-2021
|| Se agrega a la consulta informacion de asegurado, correo , telefono , se agrega fraccionamiento de pago
|| se cambia la el cursor RC1 a SYS_REFCURSOR
||
*/ --------------------------------------------------------
--

/* --------------------------------------------------------
|| p_claims :
||
|| Royner Acosta 10-3-2021
|| Se documenta lo siguiente de la consulta
       ** and v100.tip_docum  = a30.tip_docum
      ** and v100.cod_docum = a30.cod_docum

   Se agrega para traer  informacion de asegurado, correo , telefono
    --Informacion Asegurado
       and a60.num_poliza = a30.num_poliza
       and v100.tip_docum =  a60.tip_docum
       and v100.cod_docum =  a60.cod_docum
       and a60.tip_benef = 2
       and a100.tip_docum = v100.TIP_DOCUM
       and a100.cod_docum = v100.COD_DOCUM
||
|| se cambia la el cursor RC1 a SYS_REFCURSOR
||
*/ --------------------------------------------------------
--
 --
/* -------------------- VERSION = 1.01 -------------------- */
/*
||
|| Cambios 13-7-2021 Royner Acosta
|| Se agregan las funciones: f_search_province_client, f_search_state_client, f_search_location_client
|| Se agrega el procedimiento: p_search_information_client
|| Por solicitud  para que desde la web se visualice la informacion del cliente.

*/
/* -------------------- VERSION = 1.02 -------------------- */
/*
||
|| Cambios 18-8-2022 Royner Acosta
|| Se agregan las funciones: f_obtener_total_recibo, , f_obtener_total_comision
*/
--
/* -------------------- VERSION = 1.03 -------------------- */
/*
||
|| Cambios 15/11/2022 Royner Acosta
|| Se agrega la funcion: f_search_name_client (FUNCION QUE BUSCA EL NOMBRE COMPLETO DE UN TERCERO)
*/
/* -------------------- VERSION = 1.04 -------------------- */
/*
||
|| Cambios 11/4/2023 Royner Acosta
|| Se agrega funcionf_obtener_dato_variable Tiquete de Referencia RF01493992
*/
/* -------------------- VERSION = 1.05 -------------------- */
/*
||
|| Cambios 22/10/2024 INDRA - Fernando Rache
|| Creaci?n de procedimiento p_policy_by_agent_tomador_za
||
*/---------------------------------------------------------



--Variables
v_matricula_estado                         NUMBER;
v_numero_spto_max                          NUMBER;
--
PROCEDURE p_policy_by_agent (p_cod_cia          a2000030.cod_cia%TYPE,
                             p_cod_agt          a2000030.cod_agt%TYPE,
                             RC1         IN OUT SYS_REFCURSOR) IS
--
BEGIN
  OPEN rc1 FOR
      SELECT distinct      a.cod_cia,            a.num_poliza,       b.num_riesgo,      a.num_poliza_anterior,
             a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,    a.num_subcontrato,
             a.fec_efec_poliza,    a.fec_vcto_poliza,  a.num_presupuesto, b.nom_certificado,
             a.tip_docum,          a.cod_docum,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client(a.tip_docum, a.cod_docum) NOM_TOMADOR,
             em_k_Mapfre_Query_Contract_mcr.f_search_email_client(a.tip_docum, a.cod_docum) email,
             em_k_Mapfre_Query_Contract_mcr.f_search_phone_client(a.tip_docum, a.cod_docum) tlf_numero,
             a.num_spto,        a.num_apli, a.num_spto_apli,      a.cod_ramo,         a.cod_agt,
             a60.tip_docum || ' ' || a60.cod_docum IDENTIFICACION,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client( a60.tip_docum,a60.cod_docum)  NOM_COMPLETO,
             em_k_Mapfre_Query_Contract_mcr.f_search_email_client(a60.tip_docum, a60.cod_docum) email_aseg,
             em_k_Mapfre_Query_Contract_mcr.f_search_phone_client(a60.tip_docum, a60.cod_docum) tlf_numero_aseg,
             d.abr_ramo,
             b.nom_riesgo || '  ' ||  em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a.num_poliza,'COD_CHASSIS') nom_riesgo,
             a1402.nom_fracc_pago,
             a60.tip_benef,
             F_PRIMA_TOTAL_MCR(a.num_poliza) prima_total,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client_tip_benef(a.num_poliza,'8') nom_acreedor
        FROM a2000030 a,
             a2000031 b,
             v1001390 c,
             a1001800 d,
             a2000060 a60,
             a1001403 a1403,
             a1001402 a1402
       WHERE a.cod_cia            = p_cod_cia
         AND a.cod_agt            = p_cod_agt
         AND a.mca_spto_anulado   = 'N'
         AND a.mca_poliza_anulada = 'N'
         AND a.mca_provisional    = 'N'
         AND a.num_spto  in (select max(num_spto)
                               from a2000030 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza
                                AND a20.mca_spto_anulado = 'N')
         ---Riesgo
         AND b.cod_cia          = a.cod_cia
         AND b.num_poliza       = a.num_poliza
         AND b.mca_vigente      = 'S'
         AND b.mca_baja_riesgo  = 'N'
         AND b.num_spto  in (SELECT MAX(num_spto)
                               FROM a2000031 a31
                              WHERE a31.cod_cia          = b.cod_cia
                                AND a31.num_poliza       = b.num_poliza
                                AND a31.mca_vigente      = 'S')

         ---
         --
         AND a.cod_cia = d.cod_cia
         AND a.cod_ramo = d.cod_ramo
         --Informacion tercero Asegurado
         and a60.cod_cia = a.cod_cia
         and a60.num_poliza = a.num_poliza
         and a60.num_poliza = b.num_poliza
         and a60.num_riesgo = b.num_riesgo
         and a60.mca_baja = 'N'
         and a60.mca_vigente = 'S'
         and a60.tip_benef = 2
         and c.tip_docum =  a60.tip_docum
         and c.cod_docum =  a60.cod_docum
         --
         ---Fraccionamiento de Pago
          and a.cod_cia = a1403.cod_cia
          and a.cod_mon = a1403.cod_mon
          and a.cod_ramo = a1403.cod_ramo
          and a.cod_fracc_pago = a1403.cod_fracc_pago
          and a1403.cod_cia = a1402.cod_cia
          and a1403.cod_fracc_pago = a1402.cod_fracc_pago

       ORDER BY a.num_poliza;

END p_policy_by_agent;

--
/* --------------------------------------------------------
|| p_pending_receipts :
||
|| Lee los recibos pendientes de un agente
||
*/ --------------------------------------------------------
--
PROCEDURE p_pending_receipts (p_cod_cia          a2000030.cod_cia%TYPE,
                              p_cod_agt          a2000030.cod_agt%TYPE,
                              p_cant_dias        NUMBER,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpending_receipts) IS
--
  l_cant_dias   NUMBER;
--
BEGIN

  IF NVL(p_cant_dias, 0) != 0
  THEN
    l_cant_dias := p_cant_dias;
  ELSE
    l_cant_dias := 10;
  END IF;

  OPEN rc1 FOR
      SELECT a.cod_cia,
             a.num_poliza,
             a.num_poliza_anterior,
             a.num_poliza_cliente,
             a.num_poliza_grupo,
             a.num_contrato,
             a.num_subcontrato,
             a.fec_efec_poliza,
             a.fec_vcto_poliza,
             a.num_presupuesto,
             a.tip_docum,
             a.cod_docum,
             1 num_spto,--a.num_spto,
             a.num_apli,
             a.num_spto_apli,
             a.cod_ramo,
             a.cod_agt,
             substr(d.NOM_COMPLETO, 0, 8) NOM_COMPLETO,
             SUM(c.imp_recibo) imp_recibo,
             SUM(c.imp_comis)  imp_comis,
             a.tip_gestor,
             c.fec_efec_recibo fec_vcto_recibo,
             c.tip_situacion,
             c.num_recibo,
             c.fec_valor,
             a.tip_docum || '-' || a.cod_docum key,
             d.NOM_COMPLETO NOM_COMPLETO2,
             c.fec_efec_recibo fec_efec_recibo2,
             c.fec_vcto_recibo fec_vcto_recibo2,
             DECODE(c.tip_situacion,
                            'RE', 'REMESADO',
                            'EP', 'PENDIENTE') tip_situacion_desc,
             DECODE(c.tip_gestor,
                            'AG', 'VENTANILLA',
                            'BA', 'CUENTA',
                            'TA', 'TARJETA') tip_gestor_desc,
             a1331.tlf_numero,
             a1331.tlf_numero_com,
             a1331.fax_numero,
             a1331.fax_numero_com,
             nvl(upper(a1331.email),'***') email,
             nom_domicilio1,
             nom_domicilio2,
             nom_domicilio3,
             a400.cod_mon_iso nom_mon,
             c.tip_gestor  tip_gestor_recibo
        FROM a2000030 a,
             a2990700 c,
             v1001390 d,
             a1001331 a1331,
             a1000400 a400
       WHERE a.cod_cia             = p_cod_cia
         AND a.cod_agt             = p_cod_agt
        -- AND a.mca_spto_anulado    = 'N'
         AND a.mca_poliza_anulada  = 'N'
         AND a.num_spto = ( select max(a230.num_spto)
                    from a2000030 a230
                   where a230.cod_cia    = a.cod_cia
                     and a230.num_poliza = a.num_poliza )
         ---
         AND a.cod_cia   = d.cod_cia
         AND a.tip_docum = d.tip_docum
         AND a.cod_docum = d.cod_docum
         AND d.COD_ACT_TERCERO = 1
         --
         AND a1331.tip_docum = d.tip_DOCUM
         AND a1331.cod_docum = d.COD_DOCUM
         --
         AND c.cod_mon = a400.cod_mon
         --
         AND c.cod_cia  = a.cod_cia
         --AND c.num_spto  = a.num_spto
         AND c.num_spto  <= a.num_spto
         AND c.num_apli   = a.num_apli
         AND c.num_poliza  = a.num_poliza
         AND c.num_spto_apli = a.num_spto_apli
         AND c.tip_situacion  in ('RE','EP')
         AND trunc(c.fec_efec_recibo) <= trunc(sysdate) + l_cant_dias

       GROUP BY a.cod_cia,            a.num_poliza,       a.num_poliza_anterior,
             a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,
             a.num_subcontrato,    a.fec_efec_poliza,  a.fec_vcto_poliza,
             a.num_presupuesto,    a.tip_docum,        a.cod_docum,
             1,           a.num_apli,         a.num_spto_apli,
             a.cod_ramo,           a.cod_agt,
             substr(d.NOM_COMPLETO, 0, 8) ,
             a.tip_gestor,
             c.fec_efec_recibo ,
             c.tip_situacion,
             c.num_recibo,
             c.fec_valor,
             a.tip_docum || '-' || a.cod_docum,
             d.NOM_COMPLETO,
             c.fec_efec_recibo ,
             c.fec_vcto_recibo ,
             DECODE(c.tip_situacion,
                            'RE', 'REMESADO',
                            'EP', 'PENDIENTE') ,
             DECODE(c.tip_gestor,
                            'AG', 'VENTANILLA',
                            'BA', 'CUENTA',
                            'TA', 'TARJETA') ,
             a1331.tlf_numero,
             a1331.tlf_numero_com,
             a1331.fax_numero,
             a1331.fax_numero_com,
             nvl(upper(a1331.email),'***') ,
             nom_domicilio1,
             nom_domicilio2,
             nom_domicilio3,
             a400.cod_mon_iso,
             c.tip_gestor
       ORDER BY c.fec_efec_recibo;

END p_pending_receipts;
--
/* --------------------------------------------------------
|| p_pending_receipts :
||
|| Lee los recibos pendientes de un agente
||
*/ --------------------------------------------------------
--
PROCEDURE p_pending_receipts (p_cod_cia          a2000030.cod_cia%TYPE,
                              p_cod_agt          a2000030.cod_agt%TYPE,
                              p_fec_efec_recibo  a2990700.fec_efec_recibo %TYPE,
                              p_fec_vcto_recibo  a2990700.fec_vcto_recibo %TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpending_receipts) IS
--
--
BEGIN

  OPEN rc1 FOR
      SELECT a.cod_cia,            a.num_poliza,       a.num_poliza_anterior,
             a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,
             a.num_subcontrato,    a.fec_efec_poliza,  a.fec_vcto_poliza,
             a.num_presupuesto,    a.tip_docum,        a.cod_docum,
             1 num_spto,--a.num_spto,
             a.num_apli,         a.num_spto_apli,
             a.cod_ramo,           a.cod_agt,
             substr(d.NOM_COMPLETO, 0, 8) NOM_COMPLETO,
             sum(c.imp_recibo) imp_recibo,
             sum(c.imp_comis) imp_comis,
             a.tip_gestor,
             c.fec_efec_recibo fec_vcto_recibo,
             c.tip_situacion,
             c.num_recibo,
             c.fec_valor, a.tip_docum || '-' || a.cod_docum key,
             d.NOM_COMPLETO NOM_COMPLETO2,
             c.fec_efec_recibo fec_efec_recibo2,
             c.fec_vcto_recibo fec_vcto_recibo2,
             DECODE(c.tip_situacion,
                            'RE', 'REMESADO',
                            'EP', 'PENDIENTE') tip_situacion_desc,
             DECODE(c.tip_gestor,
                            'AG', 'VENTANILLA',
                            'BA', 'CUENTA',
                            'TA', 'TARJETA') tip_gestor_desc,
             a1331.tlf_numero,
             a1331.tlf_numero_com,
             a1331.fax_numero,
             a1331.fax_numero_com,
             nvl(upper(a1331.email),'***') email,
             nom_domicilio1,
             nom_domicilio2,
             nom_domicilio3,
             a400.cod_mon_iso nom_mon,
             c.tip_gestor tip_gestor_recibo
        FROM a2000030 a,
             a2990700 c,
             v1001390 d,
             a1001331 a1331,
             a1000400 a400
       WHERE a.cod_cia             = p_cod_cia
         AND a.cod_agt             = p_cod_agt
        -- AND a.mca_spto_anulado    = 'N'
         AND a.mca_poliza_anulada  = 'N'
         AND a.num_spto = ( select max(a230.num_spto)
                              from a2000030 a230
                             where a230.cod_cia    = a.cod_cia
                               and a230.num_poliza = a.num_poliza )
         --
         AND a.cod_cia   = d.cod_cia
         AND a.tip_docum = d.tip_docum
         AND a.cod_docum = d.cod_docum
         AND d.COD_ACT_TERCERO = 1
         --
         AND a1331.tip_docum = d.tip_DOCUM
         AND a1331.cod_docum = d.COD_DOCUM
         --
         AND c.cod_mon = a400.cod_mon
         --
         AND c.cod_cia  = a.cod_cia
         --AND c.num_spto  = a.num_spto
         AND c.num_spto  <= a.num_spto
         AND c.num_apli   = a.num_apli
         AND c.num_poliza  = a.num_poliza
         AND c.num_spto_apli = a.num_spto_apli
         AND c.tip_situacion  in ('RE','EP')
         AND trunc(c.fec_efec_recibo) BETWEEN p_fec_efec_recibo AND p_fec_vcto_recibo
--         AND c.imp_recibo > 0
         ---
       GROUP BY
             a.cod_cia,            a.num_poliza,       a.num_poliza_anterior,
             a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,
             a.num_subcontrato,    a.fec_efec_poliza,  a.fec_vcto_poliza,
             a.num_presupuesto,    a.tip_docum,        a.cod_docum,
             1,
             a.num_apli,         a.num_spto_apli,
             a.cod_ramo,
             a.cod_agt,
             substr(d.NOM_COMPLETO, 0, 8) ,
             a.tip_gestor,
             c.fec_efec_recibo ,
             c.tip_situacion,
             c.num_recibo,
             c.fec_valor, a.tip_docum || '-' || a.cod_docum,
             d.NOM_COMPLETO ,
             c.fec_efec_recibo,
             c.fec_vcto_recibo,
             DECODE(c.tip_situacion,
                            'RE', 'REMESADO',
                            'EP', 'PENDIENTE') ,
             DECODE(c.tip_gestor,
                            'AG', 'VENTANILLA',
                            'BA', 'CUENTA',
                            'TA', 'TARJETA') ,
             a1331.tlf_numero,
             a1331.tlf_numero_com,
             a1331.fax_numero,
             a1331.fax_numero_com,
             nvl(upper(a1331.email),'***') ,
             nom_domicilio1,
             nom_domicilio2,
             nom_domicilio3,
             a400.cod_mon_iso,
             c.tip_gestor
       ORDER BY c.fec_efec_recibo;

END p_pending_receipts;

--
/* --------------------------------------------------------
|| p_claims :
||
|| Lee los siniestors pendientes de las polizas de un agente
||
*/ --------------------------------------------------------
--
PROCEDURE p_claims (p_cod_cia          a2000030.cod_cia%TYPE,
                    p_cod_agt          a2000030.cod_agt%TYPE,
                    p_tip_est_exp      a7001000.tip_est_exp%TYPE, -- P: pendiente, T: completo
                    RC1                IN OUT SYS_REFCURSOR) IS
--
BEGIN
  OPEN rc1 FOR
    SELECT A31.COD_CIA,
		   a30.cod_mon,
           a30.num_poliza_grupo,
           a30.num_poliza,
           g700.nom_exp,
           a31.nom_riesgo,
           a31.num_riesgo,
           a90.fec_sini,
           a10.num_sini,
           a90.fec_term_sini,
           nvl(a10.imp_val_inicial,0) imp_val_inicial, --reserva,
           sum(nvl(a10.imp_val,0))    imp_val, --estimacion,
           sum(nvl(a10.imp_liq,0))    imp_liq, --liquidado,
           sum(nvl(a10.imp_pag,0))    imp_pag, --pagado
           v100.TIP_DOCUM,
           v100.COD_DOCUM,
           v100.NOM_COMPLETO,
           a100.tlf_numero,
           a100.email

      from a7000900 a90,
           a7001000 a10,
           a2000031 a31,
           v1001390 v100,
           a2000030 a30,
           a2000060 a60,
           a1001331 a100,
           g7000090 g700

     where a90.cod_cia     = p_cod_cia
       and a90.cod_agt     = p_cod_agt
       ---
       and a10.cod_cia     = a90.cod_cia
       and a10.num_sini    = a90.num_sini
       and a10.tip_est_exp = p_tip_est_exp
       ---
       and a31.cod_cia     = a90.cod_cia
       and a31.num_poliza  = a90.num_poliza
       and a31.num_riesgo  = a90.num_riesgo
       and a31.num_spto    = a90.num_spto
        --Royner acosta,  se agrega para capturar tomador
       and a31.num_poliza = a30.num_poliza
       and a31.cod_cia = a30.cod_cia
       and a31.num_spto = a30.num_spto
       -- Tipo de Expediente
       and g700.cod_cia = a90.cod_cia
       and g700.tip_exp = a10.tip_exp

       --Informacion Asegurado
       and a60.num_poliza = a30.num_poliza
       and v100.tip_docum =  a60.tip_docum
       and v100.cod_docum =  a60.cod_docum
       and a60.tip_benef = 2
       and a100.tip_docum = v100.TIP_DOCUM
       and a100.cod_docum = v100.COD_DOCUM

    group by A31.COD_CIA, a30.cod_mon, a30.num_poliza_grupo, a30.num_poliza, g700.nom_exp, a31.num_riesgo, a31.nom_riesgo, a10.num_sini,
              a90.fec_sini,   a90.fec_term_sini, a10.imp_val_inicial, v100.TIP_DOCUM,
              v100.COD_DOCUM, v100.NOM_COMPLETO, a100.tlf_numero, a100.email;

END p_claims;
--
/* --------------------------------------------------------
|| p_pending_commission :
||
|| Lee las comisiones pendientes de un agente
||
*/ --------------------------------------------------------
--
PROCEDURE p_pending_commission (p_cod_cia          a2000030.cod_cia%TYPE,
                                p_cod_agt          a2000030.cod_agt%TYPE,
                                RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpending_commission) IS
--
BEGIN

  OPEN rc1 FOR
    SELECT a58.cod_cia                   , a58.cod_agt               , a58.tip_docum_agt,
           a58.cod_docum_agt             , a58.cod_mon               , a400.nom_mon,
           SUM(a58.imp_recibo) imp_recibo, SUM(a58.imp_mvto) imp_mvto,
           a58.cod_cia || '-' || a58.cod_agt || '-' || a58.cod_mon key
      FROM a5020058 a58
     INNER JOIN a1000400 a400
        ON a58.cod_mon = a400.cod_mon
     WHERE a58.fec_proceso is null
       AND a58.cod_cia     = p_cod_cia
       AND a58.cod_agt     = p_cod_agt
       AND a58.cod_mvto    = 'DC'
       AND NVL(a58.for_actuacion,'P') = 'P'
     GROUP BY a58.cod_cia, a58.cod_agt, a58.tip_docum_agt,
              a58.cod_docum_agt, a58.cod_mon, a400.nom_mon,
              a58.cod_cia || '-' || a58.cod_agt || '-' || a58.cod_mon ;

END p_pending_commission;
--
/* --------------------------------------------------------
|| p_paid_commissionDet :
||
|| Lee el detalle de las comisiones pagadas a un agente en un periodo
||
*/ --------------------------------------------------------
--
PROCEDURE p_pending_commissionDet (p_cod_cia          a5020054.cod_cia%TYPE,
                                   p_cod_agt          a5020054.cod_agt%TYPE,
                                   p_cod_mon          a5020054.cod_mon%TYPE,
                                   RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpending_commissionDet) IS
BEGIN

  OPEN RC1 FOR
    SELECT a58.cod_cia       , a58.cod_agt      , a58.num_poliza,
           a58.cod_nivel3    , a58.cod_ramo     , a1800.abr_ramo,
           a58.num_recibo    , a58.tip_situacion, a58.fec_mvto,
           v1390.NOM_COMPLETO,
           SUM(NVl(a58.imp_recibo,0)) imp_recibo,
           SUM(nvl(imp_mvto, 0)) imp_mvto
        FROM a5020058 a58
       INNER JOIN a2000030 a30
          ON a30.cod_cia        = a58.cod_cia
         AND a30.num_poliza     = a58.num_poliza
         AND a30.num_spto       = a58.num_spto
         AND a30.num_apli       = a58.num_apli
         AND a30.num_spto_apli  = a58.num_spto_apli
       INNER JOIN v1001390 v1390
          ON v1390.cod_cia      = a30.cod_cia
         AND v1390.cod_docum    = a30.cod_docum
         AND v1390.tip_docum    = a30.tip_docum
         AND v1390.cod_act_tercero = 1
       INNER JOIN a1001800 a1800
          ON a1800.cod_cia  = a30.cod_cia
         AND a1800.cod_ramo = a30.cod_ramo
       WHERE a58.fec_proceso IS NULL --p_fec_proceso
         AND a58.cod_cia     = p_cod_cia
         AND a58.cod_agt     = p_cod_agt
         AND a58.cod_mon     = p_cod_mon
         AND a58.cod_mvto    = 'DC'
         AND NVL(a58.for_actuacion,'P') = 'P'
       GROUP BY a58.cod_cia       , a58.cod_agt      , a58.num_poliza,
                a58.cod_nivel3    , a58.cod_ramo     , a1800.abr_ramo,
                a58.num_recibo    , a58.tip_situacion, a58.fec_mvto,
                v1390.NOM_COMPLETO
       ORDER BY a58.num_poliza   ;
--
END p_pending_commissionDet;
--
/* --------------------------------------------------------
|| p_paid_commission :
||
|| Lee las comisiones pagadas a un agente
||
*/ --------------------------------------------------------
--
PROCEDURE p_paid_commission (p_cod_cia          a2000030.cod_cia%TYPE,
                             p_cod_agt          a2000030.cod_agt%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpaid_commission) IS
--
BEGIN

  OPEN RC1 FOR
   SELECT resu.cod_cia,
          resu.cod_agt,
          resu.fec_proceso,
          resu.cod_mon,
          a400.nom_mon,
          sum(imp_comis)                 imp_comis,                   --Liquidacion comisiones
          sum(imp_reten)                 + -- imp_reten                   --Retenciones
          sum(imp_descuento_cobro)       + -- imp_descuento_cobro         --Descuento en cobro
          --sum(imp_saldo_anterior)      + --   imp_saldo_anterior          --Saldo anterior
          sum(imp_ajustes)               + -- imp_ajustes                 --Ajustes
          sum(imp_anticipos)             + -- imp_anticipos               --Anticipos
          --sum(imp_saldo_actual)        + --   imp_saldo_actual            --Saldo actual
          --sum(imp_saldo_ant_imptos)    + --   imp_saldo_ant_imptos        --Saldo anterior de impuestos
          --sum(imp_saldo_actual_imptos) + --   imp_saldo_actual_imptos     --Saldo actual de impuestos
          sum(imp_imptos)                /*imp_imptos*/ imp_deduc,                 --Importe de impuestos
          sum(imp_pagado)                imp_pagado,                  --TOTAL A PAGAR
          resu.cod_cia || '-' || resu.cod_agt || '-' || resu.cod_mon || '-' || to_char(resu.fec_proceso, 'YYYYMMDD') key
    FROM  a5020059 resu
   INNER JOIN a1000400 a400
      ON resu.cod_mon  = a400.cod_mon
   WHERE resu.cod_cia       = p_cod_cia
     AND resu.cod_agt       = p_cod_agt
   GROUP by resu.cod_cia,
            cod_agt,
            resu.fec_proceso,
            resu.cod_mon,
            a400.nom_mon,
            resu.cod_cia || '-' || resu.cod_agt || '-' || resu.cod_mon || '-' || to_char(resu.fec_proceso, 'YYYYMMDD')
   ORDER by resu.fec_proceso DESC;
END p_paid_commission;
--
/* --------------------------------------------------------
|| p_paid_commissionDet :
||
|| Lee el detalle de las comisiones pagadas a un agente en un periodo
||
*/ --------------------------------------------------------
--
PROCEDURE p_paid_commissionDet (p_cod_cia          a5020054.cod_cia%TYPE,
                                p_cod_agt          a5020054.cod_agt%TYPE,
                                p_cod_mon          a5020054.cod_mon%TYPE,
                                p_fec_proceso      a5020054.fec_proceso%TYPE,
                                RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpaid_commissionDet) IS
BEGIN

 --ptraza('p_paid_commissionDet' || p_cod_agt,'w', 'p_fec_proceso - ' || p_fec_proceso);
 --ptraza('p_paid_commissionDet' || p_cod_agt,'a', 'p_cod_agt - ' || p_cod_agt);

/* --ptraza('em_p_prima_300_mcr' || l_cod_cob,'w', 'l_cod_cia - ' || l_cod_cia);
 --ptraza('em_p_prima_300_mcr' || l_cod_cob,'a', 'l_num_poliza_grupo - ' || l_num_poliza_grupo);
  */
  OPEN RC1 FOR
    SELECT a54.cod_cia, a54.cod_agt, a54.num_poliza,
           a54.cod_nivel3_agt, a54.cod_ramo, a1800.abr_ramo,
           a54.num_recibo, a54.tip_situacion, a54.fec_mvto,
           v1390.NOM_COMPLETO, NVl(a54.imp_recibo,0) imp_recibo, imp_mvto
        FROM a5020054 a54
       INNER JOIN a2000030 a30
          ON a30.cod_cia        = a54.cod_cia
         AND a30.num_poliza     = a54.num_poliza
         AND a30.num_spto       = a54.num_spto
         AND a30.num_apli       = a54.num_apli
         AND a30.num_spto_apli  = a54.num_spto_apli
       INNER JOIN v1001390 v1390
          ON v1390.cod_cia      = a30.cod_cia
         AND v1390.cod_docum    = a30.cod_docum
         AND v1390.tip_docum    = a30.tip_docum
         AND v1390.cod_act_tercero = 1
       INNER JOIN a1001800 a1800
          ON a1800.cod_cia  = a30.cod_cia
         AND a1800.cod_ramo = a30.cod_ramo
       WHERE a54.fec_proceso = p_fec_proceso
         AND a54.cod_cia     = p_cod_cia
         AND a54.cod_agt     = p_cod_agt
         AND a54.cod_mon     = p_cod_mon
         AND a54.cod_mvto    = 'DC'
         AND NVL(a54.for_actuacion,'P') = 'P'
       ORDER BY a54.num_poliza   ;
--
END p_paid_commissionDet;
/* --------------------------------------------------------
|| p_paid_commission :
||
|| Lee el detalle de las deducciones realizadas a un agente en un periodo
||
*/ --------------------------------------------------------
--
PROCEDURE p_paid_commissionDetDeduc (p_cod_cia          a5020054.cod_cia%TYPE,
                                     p_cod_agt          a5020054.cod_agt%TYPE,
                                     p_cod_mon          a5020054.cod_mon%TYPE,
                                     p_fec_proceso      a5020054.fec_proceso%TYPE,
                                     RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpaid_commissionDetDeduc) IS
--
BEGIN
    OPEN RC1 FOR
      SELECT cod_cia,
             cod_agt,
             tip_docum_agt,
             cod_docum_agt,
             cod_mon,
             fec_mvto,
             NVL(imp_mvto,0) imp_mvto,
             fec_proceso,
             tip_anticipo,
             ss_f_nom_valor ('TIP_ANTICIPO_COMIS', '999', tip_anticipo, 'ES') nom_anticipo,
             cod_mvto
        FROM a5020054
       WHERE fec_proceso = p_fec_proceso
         AND cod_cia     = p_cod_cia
         AND cod_agt     = p_cod_agt
         AND cod_mon     = p_cod_mon
         AND cod_mvto    = 'PC'
         AND NVL(for_actuacion,'P') = 'P'
      ORDER BY cod_mvto, fec_mvto, num_recibo;
END p_paid_commissionDetDeduc;
--
/* --------------------------------------------------------
|| p_policy_by_agent :
||
|| Lee las polizas activas de un agente
||
*/ --------------------------------------------------------
--
PROCEDURE p_policies_cancelled (p_cod_cia          a2000030.cod_cia%TYPE,
                             p_cod_agt          a2000030.cod_agt%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolies_canceled) IS
--
BEGIN
  OPEN rc1 FOR
      SELECT c.cod_cia,
             a.num_poliza  ,
             a.fec_efec_spto,
             --c.APE1_TERCERO, d.abr_ramo
             c.TIP_DOCUM,
             c.COD_DOCUM,
             c.NOM_COMPLETO,       d.abr_ramo
        FROM a2000030 a,
            -- a2000031 b,
             v1001390 c,
             a1001800 d
       WHERE a.cod_cia            = p_cod_cia
         AND a.cod_agt            = p_cod_agt
         AND a.mca_spto_anulado   = 'N'
         AND a.mca_poliza_anulada = 'S'
         AND a.num_spto  in (select max(num_spto)
                               from a2000030 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza)
         --and    lower(txt_motivo_spto) not like ('%migraci%')
         and    lower(txt_motivo_spto) not like ('%anulacion cover col 2 indiv%')
         ---
         AND a.cod_cia    = c.cod_cia
         AND a.tip_docum  = c.tip_docum
         AND a.cod_docum  = c.cod_docum
         AND c.cod_act_tercero = 1
         --
         AND a.cod_cia  = d.cod_cia
         AND a.cod_ramo = d.cod_ramo
       ORDER BY a.fec_efec_spto DESC;

END p_policies_cancelled;
--
/* --------------------------------------------------------
|| p_premium_collection :
||
|| Lee los recibos cobrados de las polizas de un agente en un mes
||
*/ --------------------------------------------------------
--
PROCEDURE p_premium_collection (p_cod_cia          a2000030.cod_cia%TYPE,
                                p_cod_agt          a2000030.cod_agt%TYPE,
                                p_mes_proceso      NUMBER,
                                p_anio_proceso     NUMBER,
                                RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTPREMIUMCOLLECTION) IS
--
  l_fec_ini    DATE;
  l_fec_fin    DATE;
--
BEGIN
  --
  l_fec_ini := to_date(p_anio_proceso || lpad(p_mes_proceso, 2, '0') || '01', 'YYYYMMDD'); -- Primer dia del mes
  l_fec_fin := last_day(l_fec_ini); -- Ultimo dia del mes
  --
  OPEN rc1 FOR
   SELECT a30.cod_cia,
          a30.num_poliza,
          a30.fec_efec_poliza,
          a30.fec_vcto_poliza,
          a30.tip_gestor,
          a301.cod_mon,
          a1400.nom_mon,
          a1400.cod_mon_iso,
          a30.cod_ramo,
          a1800.nom_ramo,
          a1800.abr_ramo,
          v1390.nom_tercero,
          v1390.ape1_tercero,
          v1390.ape2_tercero,
          v1390.nom_completo,
          a301.num_recibo,
          a301.fec_efec_recibo,
          a301.fec_vcto_recibo,
          a301.tip_situacion,
          a301.fec_situacion,
          a301.cod_usr,
          a301.fec_actu,
          a301.num_bloque_tes,
          a301.tip_cobro,
          g0031.nom_valor nom_tip_cobro,
          a301.cod_agt,
          v13902.NOM_COMPLETO nom_agente,
          a301.val_cambio,
          SUM(a301.imp_recibo)   imp_recibo,
          SUM(a301.imp_neta)   + SUM(imp_recargo)  imp_neta, -- se suma la prima neta mas el impuesto de bomberos
          SUM(a301.imp_recargo) imp_recargo,
          SUM(a301.imp_imptos)   imp_imptos,
          SUM(a301.imp_interes) imp_interes
     FROM a5020301 a301--WHERE num_recibo = 47847; -- COD_USR, FEC_SITUACION, NUM_BLOQUE_TES, TIP_COBRO
    LEFT JOIN a2000030 a30
       ON a301.cod_cia       = a30.cod_cia
      AND a301.num_spto      = a30.num_spto
      AND a301.num_apli      = a30.num_apli
      AND a301.num_poliza    = a30.num_poliza
      AND a301.num_spto_apli = a30.num_spto_apli
     LEFT JOIN v1001390 v1390
       ON v1390.cod_cia         = a30.cod_cia
      AND v1390.tip_docum       = a30.tip_docum
      AND v1390.cod_docum       = a30.cod_docum
      AND v1390.COD_ACT_TERCERO = 1
     LEFT JOIN v1001390 v13902
       ON v13902.cod_cia         = a30.cod_cia
      AND v13902.cod_tercero     = a30.cod_agt
      AND v13902.COD_ACT_TERCERO = 2
     LEFT JOIN a1001800 a1800
       ON a1800.cod_cia  = a30.cod_cia
      AND a1800.cod_ramo = a30.cod_ramo
     LEFT JOIN a1000400 a1400
       ON a301.cod_mon = a1400.cod_mon
    LEFT JOIN g1010031 g0031
        ON  a301.tip_cobro = g0031.cod_valor
        AND g0031.cod_campo = 'TIP_COBRO'
        AND g0031.cod_idioma = 'ES'
    WHERE a301.cod_cia       = p_cod_cia
      AND a301.cod_agt       = p_cod_agt
      AND a301.fec_situacion BETWEEN l_fec_ini AND l_fec_fin
      --AND a301.num_poliza = 3001210102489
      AND a301.tip_situacion = 'CT'
      AND nvl(a301.tip_cobro,1) NOT IN (6, 7) -- COBROS POSITIVOS Y NEGATIVOS, COBRO AUTOMATICO IMPOTE CERO
      AND a301.num_mvto      = (SELECT MAX(z.num_mvto)
                                   FROM   a5020301 z
                                   WHERE  z.cod_cia       = a301.cod_cia
                                   AND    z.num_poliza    = a301.num_poliza
                                   AND    z.num_recibo    = a301.num_recibo)
    GROUP BY a30.cod_cia,
             a30.num_poliza,
             a30.fec_efec_poliza,
             a30.fec_vcto_poliza,
             a30.tip_gestor,
             a301.cod_mon,
             a1400.nom_mon,
             a1400.cod_mon_iso,
             a30.cod_ramo,
             a1800.nom_ramo,
             a1800.abr_ramo,
             v1390.nom_tercero,
             v1390.ape1_tercero,
             v1390.ape2_tercero,
             v1390.nom_completo,
             a301.num_recibo,
             a301.fec_efec_recibo,
             a301.fec_vcto_recibo,
             a301.tip_situacion,
             a301.fec_situacion,
             a301.cod_usr,
             a301.fec_actu,
             a301.num_bloque_tes,
             a301.tip_cobro,
             g0031.nom_valor,
             a301.cod_agt,
             v13902.NOM_COMPLETO,
             a301.val_cambio
    HAVING SUM(a301.imp_recibo) > 0;
   -- ORDER BY a301.fec_situacion, a30.num_poliza;
  --
END p_premium_collection;
--
/* --------------------------------------------------------
|| p_claims_by_policy :
||
|| Lee los siniestors pendientes en una poliza
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--

PROCEDURE p_claims_by_policy (p_cod_cia          a2000030.cod_cia%TYPE,
                    p_tip_est_exp      a7001000.tip_est_exp%TYPE, -- P: pendiente, T: completo
                    p_fec_sini_ini     a7000900.fec_sini%TYPE,
                    p_fec_sini_fin     a7000900.fec_sini%TYPE,
                    p_num_poliza       a2000030.num_poliza%TYPE,
                    RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTp_claims_by_policy) IS
--
BEGIN
  OPEN rc1 FOR
      SELECT A31.COD_CIA,
           a90.num_poliza,
           a31.nom_riesgo,
           a31.num_riesgo,
           a90.fec_sini,
           a10.num_sini,
           a90.fec_term_sini,
           nvl(a10.imp_val_inicial,0) imp_val_inicial, --reserva,
           sum(nvl(a10.imp_val,0))    imp_val, --estimacion,
           sum(nvl(a10.imp_liq,0))    imp_liq, --liquidado,
           sum(nvl(a10.imp_pag,0))    imp_pag, --pagado
           a10.num_exp
      from a7000900 a90,
           a7001000 a10,
           a2000031 a31
     where a90.cod_cia     = p_cod_cia
       --and a90.cod_agt     = p_cod_agt
       and a90.num_poliza  = p_num_poliza
       and a90.fec_sini BETWEEN nvl(p_fec_sini_ini,a90.fec_sini) AND nvl(p_fec_sini_fin,a90.fec_sini)
       --and a90.fec_term_sini = '01/06/15'
       ---
       and a10.cod_cia     = a90.cod_cia
       and a10.num_sini    = a90.num_sini
       and a10.tip_est_exp = p_tip_est_exp
       ---
       and a31.cod_cia     = a90.cod_cia
       and a31.num_poliza  = a90.num_poliza
       and a31.num_riesgo  = a90.num_riesgo
       and a31.num_spto    = a90.num_spto
    group by A31.COD_CIA, a90.num_poliza, a31.num_riesgo,    a31.nom_riesgo, a10.num_sini,
              a90.fec_sini,   a90.fec_term_sini, a10.imp_val_inicial,a10.num_exp;
  END p_claims_by_policy;

  --
/* --------------------------------------------------------
|| p_group_polcy_by_document :
||
|| Lee las polizas grupo
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--
PROCEDURE p_group_polcy_by_document (p_cod_cia          a2000030.cod_cia%TYPE,
                             p_cod_docum          a2000030.cod_docum%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTp_group_polcy_by_document) IS
--
BEGIN
  OPEN rc1 FOR
      SELECT DISTINCT a.num_poliza_grupo
        FROM a2000030 a,
             a2000031 b,
             v1001390 c,
             a1001800 d
       WHERE a.cod_cia            = p_cod_cia
         AND a.cod_docum          = p_cod_docum
         AND a.mca_spto_anulado   = 'N'
         AND a.mca_poliza_anulada = 'N'
         AND a.num_spto  in (select max(num_spto)
                               from a2000030 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza
                                AND a20.mca_spto_anulado = 'N')
         ---
         AND b.cod_cia          = a.cod_cia
         AND b.num_poliza       = a.num_poliza
         AND b.mca_vigente      = 'S'
         AND b.mca_baja_riesgo  = 'N'
         AND b.num_spto  in (SELECT MAX(num_spto)
                               FROM a2000031 a31
                              WHERE a31.cod_cia          = b.cod_cia
                                AND a31.num_poliza       = b.num_poliza
                                AND a31.mca_vigente      = 'S')
         ---
         AND a.cod_cia   = c.cod_cia
         AND a.tip_docum = c.tip_docum
         AND a.cod_docum = c.cod_docum
         AND c.COD_ACT_TERCERO = 1
         --
         AND a.cod_cia = d.cod_cia
         AND a.cod_ramo = d.cod_ramo;

END p_group_polcy_by_document;

  --
/* --------------------------------------------------------
|| p_policies_by_group_policy :
||
|| Obtiene las polizas por numero de poliza grupo
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--
PROCEDURE p_policies_by_group_policy(p_cod_cia          a2000030.cod_cia%TYPE,
                        p_num_poliza_grupo            a2000030.num_poliza_grupo%TYPE,
                        p_cod_ramo                  a2000030.cod_ramo%TYPE,
                        p_num_poliza               a2000030.num_poliza%TYPE,
                        p_val_campo                a2000020.val_campo%TYPE,
                        p_nom_completo             v1001390.NOM_COMPLETO%TYPE,
                        p_tip_docum                a2000030.tip_docum%TYPE,
                        p_cod_docum                a2000030.cod_docum%TYPE,
                        p_fec_efec_poliza          a2000030.fec_efec_poliza%TYPE,
                        p_fec_vcto_poliza          a2000030.fec_vcto_poliza%TYPE,
                        RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolicy_by_agent) IS
--
BEGIN
v_matricula_estado := 0;
    IF (p_val_campo is not NULL And length(p_val_campo) > 0) THEN
        v_matricula_estado := 0;
      else
      v_matricula_estado := 1;

    END IF;
  OPEN rc1 FOR
    SELECT DISTINCT a.cod_cia,            a.num_poliza,       b.num_riesgo,      a.num_poliza_anterior,
                   a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,    a.num_subcontrato,
                   a.fec_efec_poliza,    a.fec_vcto_poliza,  a.num_presupuesto, b.nom_certificado,
                   a.tip_docum,          a.cod_docum,        a.num_spto,        a.num_apli,
                   a.num_spto_apli,      a.cod_ramo,         a.cod_agt,
                   c.NOM_COMPLETO ,      d.abr_ramo,          b.nom_riesgo
        FROM a2000030 a
      INNER JOIN a2000031 b
        ON b.cod_cia          = a.cod_cia
       AND b.num_poliza       = a.num_poliza
       AND b.mca_vigente      = 'S'
       AND b.mca_baja_riesgo  = 'N'
       AND b.num_spto  in (SELECT MAX(num_spto)
                            FROM a2000031 a31
                           WHERE a31.cod_cia          = b.cod_cia
                             AND a31.num_poliza       = b.num_poliza
                             AND a31.mca_vigente      = 'S')

      LEFT JOIN v1001390 c
              ON a.cod_cia   = c.cod_cia
             AND a.tip_docum = c.tip_docum
             AND a.cod_docum = c.cod_docum
             AND c.COD_ACT_TERCERO = 1

      LEFT JOIN a1001800 d
             ON a.cod_cia = d.cod_cia
             AND a.cod_ramo = d.cod_ramo

      LEFT JOIN a2000020 e
       ON a.cod_cia = e.cod_cia
      and a.num_poliza = e.num_poliza
      --AND e.mca_vigente      = 'S'
      --AND e.mca_baja_riesgo  = 'N'
      AND e.COD_CAMPO = 'NUM_MATRICULA'
     -- and e.COD_CAMPO = 'NUM_MATRICULA'

      WHERE a.cod_cia  = p_cod_cia
               AND a.num_poliza_grupo            = p_num_poliza_grupo
               AND a.num_poliza = nvl(p_num_poliza,a.num_poliza)
               AND a.cod_ramo = nvl(p_cod_ramo,a.cod_ramo)
               AND c.NOM_COMPLETO LIKE trim(upper('%' || p_nom_completo || '%'))
               AND a.fec_efec_poliza = nvl(p_fec_efec_poliza,a.fec_efec_poliza)
               AND a.fec_vcto_poliza = nvl(p_fec_vcto_poliza,a.fec_vcto_poliza)

               AND a.tip_docum = nvl(p_tip_docum,a.tip_docum)
               AND a.cod_docum = nvl(p_cod_docum,a.cod_docum)
               AND (e.VAL_CAMPO = p_val_campo OR 1  = v_matricula_estado)
               -------------------------------FILTROS END-----------------------
               AND a.mca_spto_anulado   = 'N'
               AND a.mca_poliza_anulada = 'N'
               AND a.num_spto  in (select max(num_spto)
                                     from a2000030 a20
                                    where a20.cod_cia  = a.cod_cia
                                      and a20.num_poliza = a.num_poliza
                                      AND a20.mca_spto_anulado = 'N')

             ORDER BY a.num_poliza;

END p_policies_by_group_policy;

  --
/* --------------------------------------------------------
|| p_policies_agent :
||
|| Obtiene las polizas por agente
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--

PROCEDURE p_policies_agent(p_cod_cia          a2000030.cod_cia%TYPE,
                             p_cod_agt          a2000030.cod_agt%TYPE,
                             p_val_campo                a2000020.val_campo%TYPE,
                             p_cod_ramo                  a2000030.cod_ramo%TYPE,
                             p_num_poliza               a2000030.num_poliza%TYPE,
                             p_nom_completo             v1001390.NOM_COMPLETO%TYPE,
                             p_tip_docum                a2000030.tip_docum%TYPE,
                             p_cod_docum                a2000030.cod_docum%TYPE,
                             p_fec_efec_poliza          a2000030.fec_efec_poliza%TYPE,
                             p_fec_vcto_poliza          a2000030.fec_vcto_poliza%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolicy_by_agent) IS
--
BEGIN
v_matricula_estado := 0;
    IF (p_val_campo is not NULL And length(p_val_campo) > 0) THEN
        v_matricula_estado := 0;
      else
      v_matricula_estado := 1;

    END IF;
  OPEN rc1 FOR
    SELECT DISTINCT a.cod_cia,            a.num_poliza,       b.num_riesgo,      a.num_poliza_anterior,
                   a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,    a.num_subcontrato,
                   a.fec_efec_poliza,    a.fec_vcto_poliza,  a.num_presupuesto, b.nom_certificado,
                   a.tip_docum,          a.cod_docum,        a.num_spto,        a.num_apli,
                   a.num_spto_apli,      a.cod_ramo,         a.cod_agt,
                   c.NOM_COMPLETO,       d.abr_ramo,         b.nom_riesgo
        FROM a2000030 a
      INNER JOIN a2000031 b
        ON b.cod_cia          = a.cod_cia
       AND b.num_poliza       = a.num_poliza
       AND b.mca_vigente      = 'S'
       AND b.mca_baja_riesgo  = 'N'
       AND b.num_spto  in (SELECT MAX(num_spto)
                            FROM a2000031 a31
                           WHERE a31.cod_cia          = b.cod_cia
                             AND a31.num_poliza       = b.num_poliza
                             AND a31.mca_vigente      = 'S')

      LEFT JOIN v1001390 c
              ON a.cod_cia   = c.cod_cia
             AND a.tip_docum = c.tip_docum
             AND a.cod_docum = c.cod_docum
             AND c.COD_ACT_TERCERO = 1

      LEFT JOIN a1001800 d
             ON a.cod_cia = d.cod_cia
             AND a.cod_ramo = d.cod_ramo

      LEFT JOIN a2000020 e
       ON a.cod_cia = e.cod_cia
      and a.num_poliza = e.num_poliza
      AND e.COD_CAMPO = 'NUM_MATRICULA'

      WHERE a.cod_cia  = p_cod_cia
               AND a.cod_agt            = p_cod_agt
               AND a.num_poliza = nvl(p_num_poliza,a.num_poliza)
               AND a.cod_ramo = nvl(p_cod_ramo,a.cod_ramo)
               AND c.NOM_COMPLETO LIKE trim(upper('%' || p_nom_completo || '%'))
               AND a.fec_efec_poliza = nvl(p_fec_efec_poliza,a.fec_efec_poliza)
               AND a.fec_vcto_poliza = nvl(p_fec_vcto_poliza,a.fec_vcto_poliza)
               AND a.tip_docum = nvl(p_tip_docum,a.tip_docum)
               AND a.cod_docum = nvl(p_cod_docum,a.cod_docum)
               AND (e.VAL_CAMPO = p_val_campo OR 1  = v_matricula_estado)
               -------------------------------FILTROS END-----------------------
               AND a.mca_spto_anulado   = 'N'
               AND a.mca_poliza_anulada = 'N'
               AND a.num_spto  in (select max(num_spto)
                                     from a2000030 a20
                                    where a20.cod_cia  = a.cod_cia
                                      and a20.num_poliza = a.num_poliza
                                      AND a20.mca_spto_anulado = 'N')

             ORDER BY a.num_poliza;

END p_policies_agent;

--
/* --------------------------------------------------------
|| p_policy_by_agent :
||
|| Lee las polizas canceladas de un grupo de polizas
||
*/ --------------------------------------------------------
--
PROCEDURE p_policy_cancel_by_group_pol (p_cod_cia          a2000030.cod_cia%TYPE,
                             p_num_poliza_grupo            a2000030.num_poliza_grupo%TYPE,
                             p_val_campo                a2000020.val_campo%TYPE,
                             p_cod_ramo                  a2000030.cod_ramo%TYPE,
                             p_num_poliza               a2000030.num_poliza%TYPE,
                             p_nom_completo             v1001390.NOM_COMPLETO%TYPE,
                             p_tip_docum                a2000030.tip_docum%TYPE,
                             p_cod_docum                a2000030.cod_docum%TYPE,
                             p_fec_efec_poliza          a2000030.fec_efec_poliza%TYPE,
                             p_fec_vcto_poliza          a2000030.fec_vcto_poliza%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolies_canceled) IS
--
BEGIN
v_matricula_estado := 0;
      IF (p_val_campo is not NULL And length(p_val_campo) > 0) THEN
          v_matricula_estado := 0;
        else
        v_matricula_estado := 1;

END IF;
  OPEN rc1 FOR
      SELECT DISTINCT c.cod_cia,
             a.num_poliza,
             a.fec_efec_spto,
             --c.APE1_TERCERO, d.abr_ramo
             c.TIP_DOCUM,
             c.COD_DOCUM,
             c.NOM_COMPLETO APE1_TERCERO, d.abr_ramo
        FROM a2000030 a
        LEFT JOIN  v1001390 c
           ON a.cod_cia   = c.cod_cia
             AND a.tip_docum = c.tip_docum
             AND a.cod_docum = c.cod_docum
             AND c.COD_ACT_TERCERO = 1
        LEFT JOIN     a1001800 d
          ON a.cod_cia  = d.cod_cia
          AND a.cod_ramo = d.cod_ramo
        LEFT JOIN a2000020 e
          ON  a.cod_cia = e.cod_cia
          AND a.num_poliza = e.num_poliza
          and e.COD_CAMPO = 'NUM_MATRICULA'
          --and (e.VAL_CAMPO = p_val_campo OR 1  = v_matricula_estado)
       WHERE a.cod_cia = p_cod_cia
       AND a.num_poliza_grupo = p_num_poliza_grupo
         AND a.num_poliza = nvl(p_num_poliza,a.num_poliza)
         AND a.cod_ramo = nvl(p_cod_ramo,a.cod_ramo)
         AND c.NOM_COMPLETO LIKE trim(upper('%' || p_nom_completo || '%'))
         AND a.fec_efec_poliza = nvl(p_fec_efec_poliza,a.fec_efec_poliza)
         AND a.fec_vcto_poliza = nvl(p_fec_vcto_poliza,a.fec_vcto_poliza)
         AND a.tip_docum = nvl(p_tip_docum,a.tip_docum)
         AND a.cod_docum = nvl(p_cod_docum,a.cod_docum)
         and (e.VAL_CAMPO = p_val_campo OR 1  = v_matricula_estado)
         AND a.mca_spto_anulado   = 'N'
         AND a.mca_poliza_anulada = 'S'
         AND a.num_spto  in (select max(num_spto)
                               from a2000030 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza)
         and    lower(txt_motivo_spto) not like ('%migraci%')
         and    lower(txt_motivo_spto) not like ('%anulacion cover col 2 indiv%')
       ORDER BY a.fec_efec_spto DESC;
END p_policy_cancel_by_group_pol;

--
/* --------------------------------------------------------
|| p_policy_by_agent :
||
|| Lee las polizas canceladas de un agente
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--

PROCEDURE p_policies_cancelled_agent (p_cod_cia          a2000030.cod_cia%TYPE,
                             p_cod_agt          a2000030.cod_agt%TYPE,
                             p_val_campo                a2000020.val_campo%TYPE,
                             p_cod_ramo                  a2000030.cod_ramo%TYPE,
                             p_num_poliza               a2000030.num_poliza%TYPE,
                             p_nom_completo             v1001390.NOM_COMPLETO%TYPE,
                             p_tip_docum                a2000030.tip_docum%TYPE,
                             p_cod_docum                a2000030.cod_docum%TYPE,
                             p_fec_efec_poliza          a2000030.fec_efec_poliza%TYPE,
                             p_fec_vcto_poliza          a2000030.fec_vcto_poliza%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolies_canceled) IS
--
BEGIN
  v_matricula_estado := 0;
      IF (p_val_campo is not NULL And length(p_val_campo) > 0) THEN
          v_matricula_estado := 0;
        else
        v_matricula_estado := 1;

      END IF;
  OPEN rc1 FOR
      SELECT DISTINCT c.cod_cia,
             a.num_poliza,
             a.fec_efec_spto,
             --c.APE1_TERCERO, d.abr_ramo
             c.TIP_DOCUM,
             c.COD_DOCUM,
             c.NOM_COMPLETO APE1_TERCERO, d.abr_ramo
        FROM a2000030 a
        LEFT JOIN  v1001390 c
           ON a.cod_cia   = c.cod_cia
             AND a.tip_docum = c.tip_docum
             AND a.cod_docum = c.cod_docum
             AND c.COD_ACT_TERCERO = 1
        LEFT JOIN     a1001800 d
          ON a.cod_cia  = d.cod_cia
          AND a.cod_ramo = d.cod_ramo
        LEFT JOIN a2000020 e
          ON  a.cod_cia = e.cod_cia
          AND a.num_poliza = e.num_poliza
          and e.COD_CAMPO = 'NUM_MATRICULA'

       WHERE a.cod_cia = p_cod_cia
         AND a.cod_agt = p_cod_agt
         AND a.num_poliza = nvl(p_num_poliza,a.num_poliza)
         AND a.cod_ramo = nvl(p_cod_ramo,a.cod_ramo)
         AND c.NOM_COMPLETO LIKE trim(upper('%' || p_nom_completo || '%'))
         AND a.fec_efec_poliza = nvl(p_fec_efec_poliza,a.fec_efec_poliza)
         AND a.fec_vcto_poliza = nvl(p_fec_vcto_poliza,a.fec_vcto_poliza)

         AND a.tip_docum = nvl(p_tip_docum,a.tip_docum)
         AND a.cod_docum = nvl(p_cod_docum,a.cod_docum)
         and (e.VAL_CAMPO = p_val_campo OR 1  = v_matricula_estado)
         AND a.mca_spto_anulado   = 'N'
         AND a.mca_poliza_anulada = 'S'
         AND a.num_spto  in (select max(num_spto)
                               from a2000030 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza)
         and    lower(txt_motivo_spto) not like ('%migraci%')
         and    lower(txt_motivo_spto) not like ('%anulacion cover col 2 indiv%')
       ORDER BY a.fec_efec_spto DESC;

END p_policies_cancelled_agent;

--
/* --------------------------------------------------------
|| p_info_extra :
||
|| Obtiene informacion extra sobre datos del tomador o agente
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--

PROCEDURE p_info_extra (p_cod_cia                    a1001300.cod_cia%TYPE,
                        p_tip_docum                  a1001300.tip_docum%TYPE,
                        p_cod_docum                  a1001300.cod_docum%TYPE,
                        RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpinfoextra) IS

--
BEGIN
OPEN rc1 FOR
    SELECT email
       FROM a1001300
      WHERE cod_cia = p_cod_cia
        AND tip_docum = p_tip_docum
        AND cod_docum = p_cod_docum
        AND email IS NOT NULL
    UNION
     SELECT email
       FROM a1001331
      WHERE cod_cia = p_cod_cia
        AND tip_docum = p_tip_docum
        AND cod_docum = p_cod_docum
        AND email IS NOT NULL;

END p_info_extra;

--
/* --------------------------------------------------------
|| p_cc_policies :
||
|| Obtiene todas las polizas para el callcenter
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--


PROCEDURE p_cc_policies(p_cod_cia          a2000030.cod_cia%TYPE,
                        p_cod_ramo                  a2000030.cod_ramo%TYPE,
                        p_num_poliza               a2000030.num_poliza%TYPE,
                        p_val_campo                a2000020.val_campo%TYPE,
                        p_nom_completo             v1001390.NOM_COMPLETO%TYPE,
                        p_tip_docum                a2000030.tip_docum%TYPE,
                        p_cod_docum                a2000030.cod_docum%TYPE,
                        p_fec_efec_poliza          a2000030.fec_efec_poliza%TYPE,
                        p_fec_vcto_poliza          a2000030.fec_vcto_poliza%TYPE,
                        RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolicy_by_agent) IS
l_nom_completo varchar2(100);
BEGIN

l_nom_completo:= '%' || replace(UPPER(rtrim(ltrim(p_nom_completo))), ' ', '%') || '%' ;
OPEN rc1 FOR
select a.cod_cia,          a.num_poliza,       b.num_riesgo,      a.num_poliza_anterior, a.num_poliza_cliente,
       a.num_poliza_grupo, a.num_contrato,     a.num_subcontrato, a.fec_efec_poliza,     a.fec_vcto_poliza,
       a.num_presupuesto,  b.nom_certificado,  a.tip_docum,       a.cod_docum,           a.num_spto,
       a.num_apli,         a.num_spto_apli,    a.cod_ramo,        a.cod_agt,             d.NOM_COMPLETO ,
       e.nom_ramo,         b.nom_riesgo
  FROM a2000030 a
 inner join a2000031 b
    on a.cod_cia            = b.cod_cia
   and a.num_poliza         = b.num_poliza
   and a.num_spto           = b.num_spto
   AND b.num_spto           = (SELECT max(z.num_spto)
                                  FROM a2000031 z
                                 WHERE z.cod_cia = a.cod_cia
                                   AND z.num_poliza = a.num_poliza
                                   AND SYSDATE BETWEEN z.fec_efec_riesgo AND z.fec_vcto_riesgo
                                   AND z.mca_baja_riesgo = 'N')
  left join a2000020 c
    on c.cod_cia            = a.cod_cia
   AND c.num_poliza         = a.num_poliza
   AND c.num_apli           = a.num_apli
   AND c.num_riesgo         = b.num_riesgo
   AND c.num_periodo        = 1 --b.num_periodo
   AND c.cod_campo          = 'NUM_MATRICULA'
   AND c.cod_ramo           = a.cod_ramo
   AND c.mca_vigente        = 'S'
   AND c.mca_vigente_apli   = 'S'
 inner join v1001390 d
    on d.cod_cia            = a.cod_cia
   and d.TIP_DOCUM          = a.tip_docum
   and d.cod_docum          = a.cod_docum
   AND d.cod_act_tercero    = 1
 inner join a1001800  e
    on e.cod_cia            = a.cod_cia
   and e.cod_sector         = a.cod_sector
   and e.cod_ramo           = a.cod_ramo
  LEFT join  a2000060 f
    on f.cod_cia            = a.cod_cia
   AND f.num_poliza         = a.num_poliza
   AND f.tip_benef          = 2
   AND f.num_riesgo         = b.num_riesgo
   and f.mca_baja           = 'N'
   AND F.MCA_VIGENTE        = 'S'
 left join v1001390 g
    on g.cod_cia            = f.cod_cia
   and g.TIP_DOCUM          = f.tip_docum
   and g.cod_docum          = f.cod_docum
   AND g.cod_act_tercero    = 1
 WHERE a.cod_cia            = p_cod_cia
   AND a.mca_provisional    = 'N'
   AND a.mca_spto_anulado   = 'N'
   and a.mca_poliza_anulada = 'N'
   AND a.num_poliza         = NVL(p_num_poliza,a.num_poliza)
   AND a.cod_ramo           = NVL(p_cod_ramo,a.cod_ramo)
   AND a.fec_efec_poliza    = NVL(p_fec_efec_poliza,a.fec_efec_poliza)
   AND a.fec_vcto_poliza    = NVL(p_fec_vcto_poliza,a.fec_vcto_poliza)
   AND (( a.tip_docum       = NVL(p_tip_docum,a.tip_docum)
   AND    a.cod_docum       = NVL(p_cod_docum,a.cod_docum))
    or  (g.tip_docum        = NVL(p_tip_docum,g.tip_docum)
   AND   g.cod_docum        = NVL(p_cod_docum,g.cod_docum)))

   AND c.val_campo          = NVL(UPPER(p_val_campo),c.val_campo)    -- .846278
   AND (d.nom_completo    LIKE  nvl(l_nom_completo , d.nom_completo)
    OR  g.nom_completo    LIKE  nvl(l_nom_completo , g.nom_completo)    )
order by a.num_poliza
;

/*
   SELECT DISTINCT
      a.cod_cia,
      a.num_poliza,
      b.num_riesgo,
      a.num_poliza_anterior,
      a.num_poliza_cliente,
      a.num_poliza_grupo,
      a.num_contrato,
      a.num_subcontrato,
      a.fec_efec_poliza,
      a.fec_vcto_poliza,
      a.num_presupuesto,
      b.nom_certificado,
      a.tip_docum,
      a.cod_docum,
      a.num_spto,
      a.num_apli,
      a.num_spto_apli,
      a.cod_ramo,
      a.cod_agt,
      --c.APE1_TERCERO NOM_COMPLETO,       d.abr_ramo
      c.NOM_COMPLETO NOM_COMPLETO,
      d.abr_ramo
    FROM
      a2000030 a
    INNER JOIN a2000031 b
    ON
      b.cod_cia           = a.cod_cia
    AND b.num_poliza      = a.num_poliza
    AND b.mca_vigente     = 'S'
    AND b.mca_baja_riesgo = 'N'
    AND b.num_spto       IN
      (
        SELECT
          MAX(num_spto)
        FROM
          a2000031 a31
        WHERE
          a31.cod_cia       = b.cod_cia
        AND a31.num_poliza  = b.num_poliza
        AND a31.mca_vigente = 'S'
      )
    LEFT JOIN v1001390 c
    ON
      a.cod_cia           = c.cod_cia
    AND a.tip_docum       = c.tip_docum
    AND a.cod_docum       = c.cod_docum
    AND c.COD_ACT_TERCERO = 1
    LEFT JOIN a1001800 d
    ON
      a.cod_cia    = d.cod_cia
    AND a.cod_ramo = d.cod_ramo
    LEFT JOIN a2000020 e
    ON
      a.cod_cia      = e.cod_cia
    AND a.num_poliza = e.num_poliza
    AND e.COD_CAMPO  = 'NUM_MATRICULA'
    WHERE
      a.cod_cia = p_cod_cia
      --AND a.cod_agt            = p_cod_agt
    AND a.num_poliza = NVL(p_num_poliza,a.num_poliza)
    AND a.cod_ramo   = NVL(p_cod_ramo,a.cod_ramo)
    AND c.NOM_COMPLETO LIKE trim(upper('%'
      || p_nom_completo
      || '%'))
    AND a.fec_efec_poliza = NVL(p_fec_efec_poliza,a.fec_efec_poliza)
    AND a.fec_vcto_poliza = NVL(p_fec_vcto_poliza,a.fec_vcto_poliza)
    AND a.tip_docum       = NVL(p_tip_docum,a.tip_docum)
    AND a.cod_docum       = NVL(p_cod_docum,a.cod_docum)
    AND
      (
        e.VAL_CAMPO = p_val_campo
      OR 1          = v_matricula_estado
      )
      -------------------------------FILTROS END-----------------------
    AND a.mca_spto_anulado   = 'N'
    AND a.mca_poliza_anulada = 'N'
    AND a.num_spto          IN
      (
        SELECT
          MAX(num_spto)
        FROM
          a2000030 a20
        WHERE
          a20.cod_cia            = a.cod_cia
        AND a20.num_poliza       = a.num_poliza
        AND a20.mca_spto_anulado = 'N'
      )
    ORDER BY
      a.num_poliza;
  */
END p_cc_policies;

--
/* --------------------------------------------------------
|| p_cc_policies_canceled :
||
|| Obtiene todas las polizas canceladas para el callcenter
|| Hecho Por: Eduardo Antonio Mendoza
*/ --------------------------------------------------------
--


PROCEDURE p_cc_policies_canceled (p_cod_cia          a2000030.cod_cia%TYPE,
                             p_val_campo                a2000020.val_campo%TYPE,
                             p_cod_ramo                  a2000030.cod_ramo%TYPE,
                             p_num_poliza               a2000030.num_poliza%TYPE,
                             p_nom_completo             v1001390.NOM_COMPLETO%TYPE,
                             p_tip_docum                a2000030.tip_docum%TYPE,
                             p_cod_docum                a2000030.cod_docum%TYPE,
                             p_fec_efec_poliza          a2000030.fec_efec_poliza%TYPE,
                             p_fec_vcto_poliza          a2000030.fec_vcto_poliza%TYPE,
                             RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolies_canceled) IS
BEGIN
v_matricula_estado := 0;
    IF (p_val_campo is not NULL And length(p_val_campo) > 0) THEN
        v_matricula_estado := 0;
      else
      v_matricula_estado := 1;

    END IF;
OPEN rc1 FOR

SELECT DISTINCT c.cod_cia,
             a.num_poliza,
             a.fec_efec_spto,
             --c.APE1_TERCERO, d.abr_ramo
             c.TIP_DOCUM,
             c.COD_DOCUM,
             c.NOM_COMPLETO APE1_TERCERO, d.abr_ramo
        FROM a2000030 a
        LEFT JOIN  v1001390 c
           ON a.cod_cia   = c.cod_cia
             AND a.tip_docum = c.tip_docum
             AND a.cod_docum = c.cod_docum
             AND c.COD_ACT_TERCERO = 1
        LEFT JOIN     a1001800 d
          ON a.cod_cia  = d.cod_cia
          AND a.cod_ramo = d.cod_ramo
        LEFT JOIN a2000020 e
          ON  a.cod_cia = e.cod_cia
          AND a.num_poliza = e.num_poliza
          and e.COD_CAMPO = 'NUM_MATRICULA'
       WHERE a.cod_cia = p_cod_cia
         AND a.num_poliza = nvl(p_num_poliza,a.num_poliza)
         AND a.cod_ramo = nvl(p_cod_ramo,a.cod_ramo)
         AND c.NOM_COMPLETO LIKE trim(upper('%' || p_nom_completo || '%'))
         AND a.fec_efec_poliza = nvl(p_fec_efec_poliza,a.fec_efec_poliza)
         AND a.fec_vcto_poliza = nvl(p_fec_vcto_poliza,a.fec_vcto_poliza)
         AND a.tip_docum = nvl(p_tip_docum,a.tip_docum)
         AND a.cod_docum = nvl(p_cod_docum,a.cod_docum)
         AND (e.VAL_CAMPO = p_val_campo OR 1  = v_matricula_estado)

         AND a.mca_spto_anulado   = 'N'
         AND a.mca_poliza_anulada = 'S'
         AND a.num_spto  in (select max(num_spto)
                               from a2000030 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza)
         and    lower(txt_motivo_spto) not like ('%migraci%')
         and    lower(txt_motivo_spto) not like ('%anulacion cover col 2 indiv%')
       ORDER BY a.fec_efec_spto DESC;
END p_cc_policies_canceled;


---Procedimiento para consulta de Polizas por agente
-- Se agrega para quitar filtro de mca_provisional = N
--Funcionalidades Purdy (Consulta de documentos polizas)
--Royner Acosta Guevara

PROCEDURE p_policy_by_agent_documents (p_cod_cia          a2000030.cod_cia%TYPE,
                                       p_cod_agt          a2000030.cod_agt%TYPE,
                                       RC1         IN OUT em_k_Mapfre_Query_Retrieve_mcr.RCTpolicy_by_agent) IS
--
BEGIN
  OPEN rc1 FOR
      SELECT a.cod_cia,            a.num_poliza,       b.num_riesgo,      a.num_poliza_anterior,
             a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,    a.num_subcontrato,
             a.fec_efec_poliza,    a.fec_vcto_poliza,  a.num_presupuesto, b.nom_certificado,
             a.tip_docum,          a.cod_docum,        a.num_spto,        a.num_apli,
             a.num_spto_apli,      a.cod_ramo,         a.cod_agt,
             NOM_COMPLETO,         d.abr_ramo,         b.nom_riesgo
        FROM a2000030 a,
             a2000031 b,
             v1001390 c,
             a1001800 d
       WHERE a.cod_cia            = p_cod_cia
         AND a.cod_agt            = p_cod_agt
         AND a.mca_spto_anulado   = 'N'
         AND a.mca_poliza_anulada = 'N'
        -- AND a.mca_provisional    = 'N'
         AND a.num_spto  in (select max(num_spto)
                               from a2000030 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza
                                AND a20.mca_spto_anulado = 'N')
         ---
         AND b.cod_cia          = a.cod_cia
         AND b.num_poliza       = a.num_poliza
         AND b.mca_vigente      = 'S'
         AND b.mca_baja_riesgo  = 'N'
         AND b.num_spto  in (SELECT MAX(num_spto)
                               FROM a2000031 a31
                              WHERE a31.cod_cia          = b.cod_cia
                                AND a31.num_poliza       = b.num_poliza
                                AND a31.mca_vigente      = 'S')
         ---
         AND a.cod_cia   = c.cod_cia
         AND a.tip_docum = c.tip_docum
         AND a.cod_docum = c.cod_docum
         AND c.COD_ACT_TERCERO = 1
         --
         AND a.cod_cia = d.cod_cia
         AND a.cod_ramo = d.cod_ramo
       ORDER BY a.num_poliza;

END p_policy_by_agent_documents;
--
--Procedimiento para consulta de Polizas por agente
--Trae informacion del tomador y asegurado
PROCEDURE p_policy_by_agent_tomador (p_cod_cia  IN     a2000030.cod_cia%TYPE,
                                     p_cod_agt  IN     a2000030.cod_agt%TYPE,
                                     RC1        IN OUT SYS_REFCURSOR
                                    )
IS
--
BEGIN
  OPEN rc1 FOR
      SELECT distinct      a.cod_cia,            a.num_poliza,       b.num_riesgo,      a.num_poliza_anterior,
             a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,    a.num_subcontrato,
             a.fec_efec_poliza,    a.fec_vcto_poliza,  a.num_presupuesto, b.nom_certificado,
             a.tip_docum,          a.cod_docum,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client(a.tip_docum, a.cod_docum) NOM_TOMADOR,
             em_k_Mapfre_Query_Contract_mcr.f_search_email_client(a.tip_docum, a.cod_docum) email,
             em_k_Mapfre_Query_Contract_mcr.f_search_phone_client(a.tip_docum, a.cod_docum) tlf_numero,
             a.num_spto,        a.num_apli, a.num_spto_apli,      a.cod_ramo,         a.cod_agt,
             a60.tip_docum || ' ' || a60.cod_docum IDENTIFICACION,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client( a60.tip_docum,a60.cod_docum)  NOM_COMPLETO,
             em_k_Mapfre_Query_Contract_mcr.f_search_email_client(a60.tip_docum, a60.cod_docum) email_aseg,
             em_k_Mapfre_Query_Contract_mcr.f_search_phone_client(a60.tip_docum, a60.cod_docum) tlf_numero_aseg,
             d.abr_ramo,
             b.nom_riesgo || '  ' ||  em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a.num_poliza,'COD_CHASSIS') nom_riesgo,
             a1402.nom_fracc_pago,
             a60.tip_benef,
             F_PRIMA_TOTAL_MCR(a.num_poliza) prima_total,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client_tip_benef(a.num_poliza,'8') nom_acreedor
        FROM a2000030 a,
             a2000031 b,
             v1001390 c,
             a1001800 d,
             a2000060 a60,
             a1001403 a1403,
             a1001402 a1402
       WHERE a.cod_cia            = p_cod_cia
         AND a.cod_agt            = p_cod_agt
         AND a.mca_spto_anulado   = 'N'
         AND a.mca_poliza_anulada = 'N'
         AND a.mca_provisional    = 'N'
         AND A.COD_RAMO != 401   -- ajustar consulta
         AND a.num_spto  in (select max(num_spto)
                               from a2000030 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza
                                AND a20.mca_spto_anulado = 'N')
         ---Riesgo
         AND b.cod_cia          = a.cod_cia
         AND b.num_poliza       = a.num_poliza
         AND b.mca_vigente      = 'S'
         AND b.mca_baja_riesgo  = 'N'
         AND b.num_spto  in (SELECT MAX(num_spto)
                               FROM a2000031 a31
                              WHERE a31.cod_cia          = b.cod_cia
                                AND a31.num_poliza       = b.num_poliza
                                AND a31.mca_vigente      = 'S')

         ---
         --
         AND a.cod_cia = d.cod_cia
         AND a.cod_ramo = d.cod_ramo
         --Informacion tercero Asegurado
         and a60.cod_cia = a.cod_cia
         and a60.num_poliza = a.num_poliza
         and a60.num_poliza = b.num_poliza
         and a60.num_riesgo = b.num_riesgo
         and a60.mca_baja = 'N'
         and a60.mca_vigente = 'S'
         and a60.tip_benef = 2
         and c.tip_docum =  a60.tip_docum
         and c.cod_docum =  a60.cod_docum
         --
         ---Fraccionamiento de Pago
          and a.cod_cia = a1403.cod_cia
          and a.cod_mon = a1403.cod_mon
          and a.cod_ramo = a1403.cod_ramo
          and a.cod_fracc_pago = a1403.cod_fracc_pago
          and a1403.cod_cia = a1402.cod_cia
          and a1403.cod_fracc_pago = a1402.cod_fracc_pago

       ORDER BY a.num_poliza;

END p_policy_by_agent_tomador;
--
--Procedimiento copia de p_policy_by_agent_tomador
--La diferencia es que ?nicamente devuelve registros
--para ramos de Zona Aliados. Lista 'COD_RAMO_ZA'.
--Adem?s incluye columna MCA_PROVISIONAL.
PROCEDURE p_policy_by_agent_tomador_za(p_cod_cia  IN     a2000030.cod_cia%TYPE,
                                       p_cod_agt  IN     a2000030.cod_agt%TYPE,
                                       RC1        IN OUT SYS_REFCURSOR
                                      )
IS
BEGIN
   --
   OPEN rc1 FOR
      SELECT distinct      a.cod_cia,            a.num_poliza,       b.num_riesgo,      a.num_poliza_anterior,
             a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,    a.num_subcontrato,
             a.fec_efec_poliza,    a.fec_vcto_poliza,  a.num_presupuesto, b.nom_certificado,
             a.tip_docum,          a.cod_docum,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client(a.tip_docum, a.cod_docum) NOM_TOMADOR,
             em_k_Mapfre_Query_Contract_mcr.f_search_email_client(a.tip_docum, a.cod_docum) email,
             em_k_Mapfre_Query_Contract_mcr.f_search_phone_client(a.tip_docum, a.cod_docum) tlf_numero,
             a.num_spto,        a.num_apli, a.num_spto_apli,      a.cod_ramo,         a.cod_agt,
             a60.tip_docum || ' ' || a60.cod_docum IDENTIFICACION,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client( a60.tip_docum,a60.cod_docum)  NOM_COMPLETO,
             em_k_Mapfre_Query_Contract_mcr.f_search_email_client(a60.tip_docum, a60.cod_docum) email_aseg,
             em_k_Mapfre_Query_Contract_mcr.f_search_phone_client(a60.tip_docum, a60.cod_docum) tlf_numero_aseg,
             d.abr_ramo,
             b.nom_riesgo || '  ' ||  em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a.num_poliza,'COD_CHASSIS') nom_riesgo,
             a1402.nom_fracc_pago,
             a60.tip_benef,
             F_PRIMA_TOTAL_MCR(a.num_poliza) prima_total,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client_tip_benef(a.num_poliza,'8') nom_acreedor,
             a.mca_provisional --diferencia vs p_policy_by_agent_tomador
        FROM g1010031 g,
             a2000030 a,
             a2000031 b,
             v1001390 c,
             a1001800 d,
             a2000060 a60,
             a1001403 a1403,
             a1001402 a1402
       WHERE g.cod_cia            = a.cod_cia
         AND g.cod_campo          = 'COD_RAMO_ZA'
         AND a.cod_ramo           = TO_NUMBER(g.cod_valor) --diferencia vs p_policy_by_agent_tomador
         AND a.cod_cia            = p_cod_cia
         AND a.cod_agt            = p_cod_agt
         AND a.mca_spto_anulado   = 'N'
         AND a.mca_poliza_anulada = 'N'
         AND a.num_spto  in (select max(num_spto)
                               from a2000030 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza
                                AND a20.mca_spto_anulado = 'N')
         ---Riesgo
         AND b.cod_cia          = a.cod_cia
         AND b.num_poliza       = a.num_poliza
         AND b.mca_vigente      = 'S'
         AND b.mca_baja_riesgo  = 'N'
         AND b.num_spto  in (SELECT MAX(num_spto)
                               FROM a2000031 a31
                              WHERE a31.cod_cia          = b.cod_cia
                                AND a31.num_poliza       = b.num_poliza
                                AND a31.mca_vigente      = 'S')
         ---
         --
         AND a.cod_cia = d.cod_cia
         AND a.cod_ramo = d.cod_ramo
         --Informacion tercero Asegurado
         and a60.cod_cia = a.cod_cia
         and a60.num_poliza = a.num_poliza
         and a60.num_poliza = b.num_poliza
         and a60.num_riesgo = b.num_riesgo
         and a60.mca_baja = 'N'
         and a60.mca_vigente = 'S'
         and a60.tip_benef = 2
         and c.tip_docum =  a60.tip_docum
         and c.cod_docum =  a60.cod_docum
         --
         ---Fraccionamiento de Pago
          and a.cod_cia = a1403.cod_cia
          and a.cod_mon = a1403.cod_mon
          and a.cod_ramo = a1403.cod_ramo
          and a.cod_fracc_pago = a1403.cod_fracc_pago
          and a1403.cod_cia = a1402.cod_cia
          and a1403.cod_fracc_pago = a1402.cod_fracc_pago
       ORDER BY a.num_poliza;
   --
END p_policy_by_agent_tomador_za;
--
/* --------------------------------------------------------
|| p_premium_collection :
||
|| Lee los recibos cobrados de las polizas de un agente en un rango de fechas
|| Royner Acosta Guevara 06-7-2021
*/ --------------------------------------------------------
--
PROCEDURE p_premium_collection_date_range (p_cod_cia          a2000030.cod_cia%TYPE,
                                           p_cod_agt          a2000030.cod_agt%TYPE,
                                           p_fec_ini          Date,
                                           p_fec_fin          Date,
                                           RC1         IN OUT SYS_REFCURSOR) IS
--
  --l_fec_ini    DATE;
  --l_fec_fin    DATE;
--
BEGIN
  --
  --l_fec_ini := to_date(p_anio_proceso || lpad(p_mes_proceso, 2, '0') || '01', 'YYYYMMDD'); -- Primer dia del mes
  --l_fec_fin := last_day(l_fec_ini); -- Ultimo dia del mes
  --
  OPEN rc1 FOR
   SELECT a30.cod_cia,
          a30.num_poliza,
          a30.fec_efec_poliza,
          a30.fec_vcto_poliza,
          a30.tip_gestor,
          a301.cod_mon,
          a1400.nom_mon,
          a1400.cod_mon_iso,
          a30.cod_ramo,
          a1800.nom_ramo,
          a1800.abr_ramo,
          v1390.nom_tercero,
          v1390.ape1_tercero,
          v1390.ape2_tercero,
          v1390.nom_completo,
          a301.num_recibo,
          a301.fec_efec_recibo,
          a301.fec_vcto_recibo,
          a301.tip_situacion,
          a301.fec_situacion,
          a301.cod_usr,
          a301.fec_actu,
          a301.num_bloque_tes,
          a301.tip_cobro,
          g0031.nom_valor nom_tip_cobro,
          a301.cod_agt,
          v13902.NOM_COMPLETO nom_agente,
          a301.val_cambio,
          SUM(a301.imp_recibo)   imp_recibo,
          SUM(a301.imp_neta)   + SUM(imp_recargo)  imp_neta, -- se suma la prima neta mas el impuesto de bomberos
          SUM(a301.imp_recargo) imp_recargo,
          SUM(a301.imp_imptos)   imp_imptos,
          SUM(a301.imp_interes) imp_interes
     FROM a5020301 a301--WHERE num_recibo = 47847; -- COD_USR, FEC_SITUACION, NUM_BLOQUE_TES, TIP_COBRO
    LEFT JOIN a2000030 a30
       ON a301.cod_cia       = a30.cod_cia
      AND a301.num_spto      = a30.num_spto
      AND a301.num_apli      = a30.num_apli
      AND a301.num_poliza    = a30.num_poliza
      AND a301.num_spto_apli = a30.num_spto_apli
     LEFT JOIN v1001390 v1390
       ON v1390.cod_cia         = a30.cod_cia
      AND v1390.tip_docum       = a30.tip_docum
      AND v1390.cod_docum       = a30.cod_docum
      AND v1390.COD_ACT_TERCERO = 1
     LEFT JOIN v1001390 v13902
       ON v13902.cod_cia         = a30.cod_cia
      AND v13902.cod_tercero     = a30.cod_agt
      AND v13902.COD_ACT_TERCERO = 2
     LEFT JOIN a1001800 a1800
       ON a1800.cod_cia  = a30.cod_cia
      AND a1800.cod_ramo = a30.cod_ramo
     LEFT JOIN a1000400 a1400
       ON a301.cod_mon = a1400.cod_mon
    LEFT JOIN g1010031 g0031
        ON  a301.tip_cobro = g0031.cod_valor
        AND g0031.cod_campo = 'TIP_COBRO'
        AND g0031.cod_idioma = 'ES'
    WHERE a301.cod_cia       = p_cod_cia
      AND a301.cod_agt       = p_cod_agt
      AND a301.fec_situacion BETWEEN p_fec_ini AND p_fec_fin
      --AND a301.num_poliza = 3001210102489
      AND a301.tip_situacion = 'CT'
      AND a301.tip_cobro NOT IN (6, 7) -- COBROS POSITIVOS Y NEGATIVOS, COBRO AUTOMATICO IMPOTE CERO
      AND a301.num_mvto      = (SELECT MAX(z.num_mvto)
                                   FROM   a5020301 z
                                   WHERE  z.cod_cia       = a301.cod_cia
                                   AND    z.num_poliza    = a301.num_poliza
                                   AND    z.num_recibo    = a301.num_recibo)
    GROUP BY a30.cod_cia,
             a30.num_poliza,
             a30.fec_efec_poliza,
             a30.fec_vcto_poliza,
             a30.tip_gestor,
             a301.cod_mon,
             a1400.nom_mon,
             a1400.cod_mon_iso,
             a30.cod_ramo,
             a1800.nom_ramo,
             a1800.abr_ramo,
             v1390.nom_tercero,
             v1390.ape1_tercero,
             v1390.ape2_tercero,
             v1390.nom_completo,
             a301.num_recibo,
             a301.fec_efec_recibo,
             a301.fec_vcto_recibo,
             a301.tip_situacion,
             a301.fec_situacion,
             a301.cod_usr,
             a301.fec_actu,
             a301.num_bloque_tes,
             a301.tip_cobro,
             g0031.nom_valor,
             a301.cod_agt,
             v13902.NOM_COMPLETO,
             a301.val_cambio
    HAVING SUM(a301.imp_recibo) > 0;
   -- ORDER BY a301.fec_situacion, a30.num_poliza;
  --
END p_premium_collection_date_range;
--


--FUNCION QUE BUSCA LA UBICACION DE LA PROVINCIA REGISTRADA DE UN TERCERO
 FUNCTION f_search_province_client(p_cod_estado VARCHAR) return varchar2 is
   --
    l_nom_estado VARCHAR2(100);
    --
  BEGIN
    --
       SELECT nom_estado
        INTO l_nom_estado
        FROM a1000104
        WHERE cod_estado = p_cod_estado;

    --
   RETURN  nvl(l_nom_estado,'SIN INFORMACION') ;

END f_search_province_client;


--FUNCION QUE BUSCA LA UBICACION DEL CANTON REGISTRADO DE UN TERCERO
 FUNCTION f_search_state_client(p_cod_estado VARCHAR,p_cod_prov VARCHAR) return varchar2 is
   --
    l_nom_prov VARCHAR2(100);
    --
  BEGIN
    --
       SELECT nom_prov
       INTO l_nom_prov
        FROM a1000100
        WHERE cod_estado = p_cod_estado
        AND cod_prov = p_cod_prov;

    --
   RETURN  nvl(l_nom_prov,'SIN INFORMACION') ;

END f_search_state_client;

--FUNCION QUE BUSCA LA UBICACION DE LA LOCALIDAD REGISTRADA DE UN TERCERO
 FUNCTION f_search_location_client(p_cod_prov VARCHAR, p_cod_localidad VARCHAR) return varchar2 is
   --
    l_nom_localidad VARCHAR2(100);
    --
  BEGIN
    --
      SELECT nom_localidad
      INTO l_nom_localidad
        FROM a1000102
        WHERE cod_prov = p_cod_prov
        AND cod_localidad = p_cod_localidad;

    --
   RETURN  nvl(l_nom_localidad,'SIN INFORMACION') ;

END f_search_location_client;

--FUNCION QUE BUSCA EL NOMBRE COMPLETO DE UN TERCERO
FUNCTION f_search_name_client(p_tip_docum varchar,p_cod_docum varchar) return varchar2 is
   --
    l_nom_completo VARCHAR2(150);
    --
  BEGIN
    --
      select b.nom_tercero || ' ' || b.ape1_tercero || ' ' || b.ape2_tercero
      into l_nom_completo
        from a1001331 a, a1001399 b
        where a.cod_cia = 1
        and a.tip_docum = p_tip_docum
        and a.cod_docum = p_cod_docum
        and a.tip_docum = b.tip_docum
        and a.cod_docum = b.cod_docum
        and b.cod_cia = a.cod_cia;
    --
   RETURN  nvl(l_nom_completo,'SIN INFORMACION') ;

END f_search_name_client;

--FUNCION QUE BUSCA EL NOMBRE COMPLETO DE UN TIP_BENEF
FUNCTION f_search_name_client_tip_benef(p_num_poliza varchar, p_tip_benef varchar) return varchar2 is
   --
    l_nom_completo VARCHAR2(150);
    --
  BEGIN
    --
      select distinct b.nom_tercero || ' ' || b.ape1_tercero || ' ' || b.ape2_tercero
       into l_nom_completo
        from A2000060 a, a1001399 b
        where a.cod_cia = 1
        and  a.num_poliza = p_num_poliza
        and a.tip_benef = p_tip_benef
        and a.mca_vigente   = 'S'
        and a.mca_baja  = 'N'
        and a.num_spto = (select max(c.num_spto)
                          from a2000060 c
                          where c.num_poliza = a.num_poliza
                          and c.tip_benef = p_tip_benef)
        and b.cod_cia = a.cod_cia
        and b.tip_docum = a.tip_docum
        and b.cod_docum = a.cod_docum
        AND rownum = 1;
    --
   RETURN  nvl(l_nom_completo,'SIN INFORMACION') ;

END f_search_name_client_tip_benef;

--FUNCION QUE BUSCA EL email DE UN TERCERO
FUNCTION f_search_email_client(p_tip_docum varchar,p_cod_docum varchar) return varchar2 is
   --
    l_email VARCHAR2(150);
    --
  BEGIN
    --
      select email
      into l_email
        from a1001331 a
        where a.cod_cia = 1
        and a.tip_docum = p_tip_docum
        and a.cod_docum = p_cod_docum;
    --
   RETURN  nvl(l_email,'SIN INFORMACION');

END f_search_email_client;
--
--FUNCION QUE BUSCA EL telefono DE UN TERCERO
FUNCTION f_search_phone_client(p_tip_docum varchar,p_cod_docum varchar) return varchar2 is
   --
    l_tlf_numero VARCHAR2(150);
    --
  BEGIN
    --
      select tlf_numero
      into l_tlf_numero
        from a1001331 a
        where a.cod_cia = 1
        and a.tip_docum = p_tip_docum
        and a.cod_docum = p_cod_docum;
    --
   RETURN  nvl(l_tlf_numero,'SIN INFORMACION');

END f_search_phone_client;
--
--PROCEDIMIENTO QUE BUSCA LA INFORMACION PERSONAL DE UN TERCERO
PROCEDURE p_search_information_client(p_tip_docum varchar,
                                      p_cod_docum varchar,
                                      RC1 IN OUT SYS_REFCURSOR) is

BEGIN

OPEN RC1 FOR

   select b.nom_tercero || ' ' || b.ape1_tercero || ' ' || b.ape2_tercero nom_completo,
       a.tip_docum, a.cod_docum,
       f_search_province_client(a.cod_estado) provincia,
       f_search_state_client(a.cod_estado, a.cod_prov) canton ,
       f_search_location_client(a.cod_prov, a.cod_localidad) localidad,
       a.nom_domicilio1, a.tlf_numero,
       a.email, to_char(a.fec_nacimiento, 'dd/mm/yyyy'), to_char(a.fec_actu,'dd/mm/yyyy')

    from a1001331 a, a1001399 b
    where a.tip_docum = p_tip_docum
    and a.cod_docum = p_cod_docum
    and a.tip_docum = b.tip_docum
    and a.cod_docum = b.cod_docum;


END  p_search_information_client;


---Funcion que trae el total monto total de un recibo
--Royner Acosta 17-8-2022
function f_obtener_total_recibo(cod_cia varchar, num_recibo number)
  return number is

  total_recibo a2990700.imp_recibo%type;

begin

  gc_k_a2990700.p_lee_rec(p_cod_cia => cod_cia, p_num_recibo => num_recibo);

  total_recibo := gc_k_a2990700.f_tot_recibo;

  return(total_recibo);

end f_obtener_total_recibo;

---Funcion que trae el total monto total de comision
--Royner Acosta 17-8-2022
function f_obtener_total_comision(cod_cia varchar, num_recibo number)
  return number is

  total_comision a2990700.imp_comis%type;

begin

  gc_k_a2990700.p_lee_rec(p_cod_cia => cod_cia, p_num_recibo => num_recibo);

  total_comision := gc_k_a2990700.f_tot_comis;

  return(total_comision);

end f_obtener_total_comision;

--Funcion que trae valores de datos Variables
function f_obtener_dato_variable(p_num_poliza varchar, p_cod_campo varchar )
  return varchar is

  txt_campo a2000020.txt_campo%type;

begin

       select nvl(txt_campo, 'NO ENCONTRADO') as txt_campo
       into txt_campo
        from (
          select a.txt_campo
          from a2000020 a
         where a.cod_cia = 1
           and a.num_poliza = p_num_poliza
           and a.cod_campo = p_cod_campo
         order by num_spto desc
         )
         WHERE ROWNUM = 1;

  

  If txt_campo = 'NO ENCONTRADO' then
     
       select nvl(val_campo, 'NO ENCONTRADO') as val_campo
       into txt_campo
        from (
          select a.val_campo
          from a2000020 a
         where a.cod_cia = 1
           and a.num_poliza = p_num_poliza
           and a.cod_campo = p_cod_campo
         order by num_spto desc
         )
         WHERE ROWNUM = 1;
   
  end if;
--
  return(txt_campo);
--
end f_obtener_dato_variable;
--
--Funcion para buscar la tarjeta ligada a un tipo de tercero en la poliza
--
FUNCTION f_obtener_num_tarjeta(p_cod_cia number, p_num_poliza varchar)
  RETURN VARCHAR IS
  --
  v_num_tarjeta VARCHAR2(50);
  --
BEGIN
  SELECT SUBSTR(a.num_tarjeta, LENGTH(a.num_tarjeta) - 3)
    INTO v_num_tarjeta
    FROM a1001331 a
   WHERE a.cod_cia = p_cod_cia
     AND EXISTS
   (SELECT 1
            FROM a2000030
           WHERE a2000030.cod_cia = p_cod_cia
             AND a2000030.num_poliza = p_num_poliza
             AND a2000030.num_spto =
                 (SELECT MAX(num_spto)
                    FROM a2000030 x
                   WHERE x.cod_cia = p_cod_cia
                     AND x.num_poliza = a2000030.num_poliza)
             AND a.cod_cia = a2000030.cod_cia
             AND a.tip_docum = a2000030.tip_docum
             AND a.cod_docum = a2000030.cod_docum
             AND a.num_tarjeta IS NOT NULL);

  RETURN 'TOMADOR ' || v_num_tarjeta;

EXCEPTION
  WHEN NO_DATA_FOUND THEN
    -- Si la primera consulta no devuelve resultados, intenta la segunda
    BEGIN
      SELECT SUBSTR(b.num_tarjeta, LENGTH(b.num_tarjeta) - 3)
        INTO v_num_tarjeta
        FROM a1001331 b
       WHERE b.cod_cia = p_cod_cia
         AND EXISTS
       (SELECT 1
                FROM a2000060
               WHERE a2000060.cod_cia = p_cod_cia
                 and substr(a2000060.num_poliza,1,3) != 441
                 AND a2000060.num_poliza = p_num_poliza
                 AND a2000060.tip_benef = 2
                 AND a2000060.num_spto =
                     (SELECT MAX(num_spto)
                        FROM a2000060 y
                       WHERE y.cod_cia = p_cod_cia
                         AND y.num_poliza = a2000060.num_poliza
                         AND y.tip_benef = 2)
                 AND a2000060.mca_baja = 'N'
                 AND a2000060.mca_Vigente = 'S'
                 AND b.cod_cia = a2000060.cod_cia
                 AND b.tip_docum = a2000060.tip_docum
                 AND b.cod_docum = a2000060.cod_docum
                 AND b.num_tarjeta IS NOT NULL);

      RETURN 'ASEGURADO ' || v_num_tarjeta;
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        -- Si ambas consultas no devuelven resultados
        RETURN 'SIN TARJETA';
       WHEN OTHERS THEN
        -- Si ambas consultas no devuelven resultados
        RETURN 'SIN TARJETAS';

    END;
    --
END f_obtener_num_tarjeta;
--


--
-- PROCEDIMIENTO PARA TOKENIZAR LAS POLIZAS
PROCEDURE p_tokeniza_tarjeta(RC1         IN OUT SYS_REFCURSOR) IS
--
BEGIN
  OPEN rc1 FOR
SELECT
        A99.MCA_FISICO,
        'CNA' tip_docum ,  --A99.TIP_DOCUM,
        TT.Cod_Docum_Tom  cod_docum, -- A99.COD_DOCUM,
        A99.NOM_TERCERO,
        A99.NOM2_TERCERO,
        A99.APE1_TERCERO,
        A99.APE2_TERCERO,
        A99.TLF_MOVIL,
        A31.TLF_NUMERO,
        A31.FAX_NUMERO,
        tt.email EMAIL,  -- A31.EMAIL,
        tt.email EMAIL_COM,  --A31.EMAIL_COM,
        tt.email TXT_EMAIL,   --A31.TXT_EMAIL,
        NVL(NVL( TT.TIP_TARJETA_A1001331_RGO1P, TT.TIP_TARJETA_A1000802_RGO0P), TT.TIP_TARJETA_A1001331P) TIP_TARJETA ,
        '' nom_tip_tarjeta,
        '' COD_TARJETA,
        '' NOM_TARJETA,
        TT.NUM_TARJETA_TOKE  num_tarjeta,
        TT.VEN_TARJETA_TOKEN fec_vcto_tarjeta,
        TT.NUM_POLIZA,
        0   num_spto
        --TT.*
  FROM tokenizar_tarjetas2 TT
 LEFT  JOIN A1001399 A99
    ON A99.COD_CIA    = 1
   AND A99.TIP_DOCUM  = TT.TIP_DOCUM_TOM
   AND A99.COD_DOCUM  = TT.COD_DOCUM_TOM
 LEFT JOIN A1001331 A31
      ON A31.COD_CIA   = 1
     AND A31.TIP_DOCUM = TT.TIP_DOCUM_TOM
     AND A31.COD_DOCUM = TT.COD_DOCUM_TOM
  LEFT JOIN A5020021 A21
    ON A21.TIP_TARJETA = NVL(NVL( TT.TIP_TARJETA_A1001331_RGO1P, TT.TIP_TARJETA_A1000802_RGO0P), TT.TIP_TARJETA_A1001331P)
where tt.num_poliza not in ( select num_poliza from aliados.boveda where status = 1)

--WHERE NUM_POLIZA = 3022210119008
--TT.COD_AGT = 699 --TT.num_poliza = 3022310103024
--and num_poliza NOT in ( 3032510117870)



;
END p_tokeniza_tarjeta;


PROCEDURE p_Reporte_Cobro_Sinpe(Desde a2000030.Fec_Validez%TYPE,
                                Hasta a2000030.Fec_Validez%TYPE,
                                RC1   IN OUT SYS_REFCURSOR) IS
  --
BEGIN
  OPEN rc1 FOR
    WITH sm AS
     (SELECT s.*,
             -- Valida que el bloque de 13 d?gitos est? delimitado por no-d?gitos o inicio/fin
             REGEXP_SUBSTR(s.DESCRIPCION,
                           '(^|[^0-9])([0-9]{13})([^0-9]|$)', -- grupo 2 = los 13 d?gitos
                           1,
                           1,
                           'i',
                           2) AS num_poliza_extraido
        FROM ALIADOS.SINPEMOVIL s
       WHERE TRUNC(s.FECHA) BETWEEN Desde AND Hasta)
    SELECT CASE
             WHEN sm.MONEDA = 1 THEN
              'HSBC1'
             ELSE
              'HSBC2'
           END AS ENTIDAD_BANCARIA,
           sm.IDENTIFICACIONCLIENTE AS IDENTIFICACION_CLIENTE,
           sm.NOMBRECLIENTE AS NOMBRE_CLIENTE,
           sm.FECHA,
           sm.CODREFERENCIABANCO AS NUMERO_COMPROBANTE,
           sm.MONTO,
           sm.DESCRIPCION AS APLICADO_A_LA_POLIZA,
           CASE
             WHEN sm.RAZON LIKE '%Pago realizado exitosamente%' THEN
              'APROBADO'
             ELSE
              'RECHAZADO'
           END AS ESTADO,
           sm.RAZON AS RESULTADO,
           sm.num_poliza_extraido AS NUM_POLIZA,
           a.cod_agt AS CODIGO_AGENTE,
           ng.nom_tercero || ' ' || ng.ape1_tercero || ' ' ||
           ng.ape2_tercero AS AGENTE
      FROM sm
     INNER JOIN A2000030 a
        ON a.cod_cia = 1
       AND a.num_poliza = sm.num_poliza_extraido
       AND a.num_spto = (select max(num_spto)
                           from a2000030 ax
                          where a.cod_cia = ax.cod_cia
                            and a.num_poliza = ax.num_poliza)
      LEFT JOIN A1001332 ag
        ON ag.cod_cia = a.cod_cia
       and ag.cod_agt = a.cod_agt
      LEFT JOIN A1001399 ng
        ON ng.cod_cia = ag.cod_cia
       and ng.tip_docum = ag.tip_docum
       and ng.cod_docum = ag.cod_docum;

END p_Reporte_Cobro_Sinpe;

END em_k_Mapfre_Query_Contract_mcr;