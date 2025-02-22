INSERT INTO RESTENDPOINTS (ID, "SEQUENCE", "PATH", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", ALIAS, AUTHORIZATIONREQUIRED, ROLES, CONTROLLERNAME, APPNAME, TRACED, PRECONDITION, VALIDATIONS, PRECALL, POSTCALL, RECORDSTATUS, COMPANYID, UPDATEUSERCODE, UPDATEDATE) VALUES(111, 1, 'PolicyToCancel/{id}', 'GET', 'Policy a cancelar', NULL, 'SELECT', 2, 'SELECT  DISTINCT a30.cod_ramo, a30.num_contrato, a30.num_poliza_grupo, a30.cod_mon,
        a30.fec_efec_poliza, a30.fec_vcto_poliza, a60.TIP_DOCUM, a60.COD_DOCUM, a1399.NOM_TERCERO, a1399.APE1_TERCERO,
        A1331.MCA_SEXO, A1331.FEC_NACIMIENTO,  A1331.COD_NACIONALIDAD, A1331.COD_ESTADO, A1331.COD_PROV, A1331.COD_LOCALIDAD, A1331.NOM_DOMICILIO1,
         F_PRIMA_TOTAL_MCR(a30.num_poliza) prima_total,
         em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a30.num_poliza,''COD_PLAN_AP'') COD_PLAN_AP,
         em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a30.num_poliza,''NUM_PRESTAMO'') NUM_PRESTAMO,
         em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a30.num_poliza,''IMP_PRIMA_INFORMADA'') IMP_PRIMA_INFORMADA,
         em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a30.num_poliza,''FEC_VCTO_PRESTAMO'') FEC_VCTO_PRESTAMO,
         em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a30.num_poliza,''MCA_COBRA_ASISTENCIA'') MCA_COBRA_ASISTENCIA
  FROM a2000030 a30
  LEFT JOIN a2000060 a60 ON a60.cod_cia = a30.cod_cia and a60.num_poliza = a30.num_poliza and a60.NUM_APLI = a30.NUM_APLI and a60.tip_benef = 2 and a60.mca_baja = ''N'' and a60.mca_vigente = ''S''
  LEFT JOIN A1001399 a1399 ON  a1399.COD_CIA =a60.COD_CIA AND a1399.TIP_DOCUM=a60.TIP_DOCUM  AND a1399.COD_DOCUM=a60.COD_DOCUM
  LEFT JOIN A1001331 a1331 ON  a1331.COD_CIA =a60.COD_CIA AND a1331.TIP_DOCUM=a60.TIP_DOCUM  AND a1331.COD_DOCUM=a60.COD_DOCUM
  WHERE a30.cod_cia    = 1
    AND a30.num_poliza = {ID:VARCHAR2.13:Required}
    AND a30.num_spto   in (select max(a30last.num_spto) from a2000030 a30last where a30last.cod_cia  = a30.cod_cia and a30last.num_poliza = a30.num_poliza AND a30last.mca_spto_anulado = ''N'')', 1, 'Custom', 'General', 1, NULL, 'Clentes', 'TRON', 0, NULL, NULL, NULL, NULL, 1, 0, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');