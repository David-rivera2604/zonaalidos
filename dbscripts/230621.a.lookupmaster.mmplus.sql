INSERT INTO LOOKUPMASTER (LOOKUPID, DESCRIPTION, "KEY", TENANT, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE, "STATEMENT", CONNECTIONNAME, "TYPE", INCLUDEBYROLE, EXCLUDEBYROLE, ISCACHED, STATEMENTTYPE, FIELDS) VALUES(3109, 'TRON. Sumas aseguradas para automovil.', 'TRON_TA301001EX', 2, 1, 777, TIMESTAMP '2023-02-21 00:00:00.000000', 'SELECT DISTINCT a.suma_aseg, a.suma_aseg
FROM   ta301001 a
WHERE  a.cod_cia = {app.p_cod_cia}
AND    a.num_poliza_grupo = NVL({num_poliza_grupo:varchar}, ''9999999999999'')
AND    a.num_contrato IN ({num_contrato}, ''99999'')
AND    a.num_subcontrato IN ({num_subcontrato}, ''99999'')
AND    a.cod_marca IN ({cod_marca}, ''999'')
AND    a.cod_modelo IN ({cod_modelo}, ''999'')
AND    a.cod_sub_modelo IN ({cod_sub_modelo}, ''999'')
AND    a.cod_tip_vehi IN ({cod_tip_vehi}, ''999'')
AND    a.cod_ramo = {cod_ramo}
AND    a.cod_cob = {extend:varchar}
AND    a.cod_mon = {cod_mon}
AND    a.mca_inh = ''N''
AND    a.fec_validez <= {const.date.today}
ORDER  BY a.suma_aseg', 'tron', 2, NULL, NULL, 1, 1, NULL);
INSERT INTO LOOKUPMASTER (LOOKUPID, DESCRIPTION, "KEY", TENANT, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE, "STATEMENT", CONNECTIONNAME, "TYPE", INCLUDEBYROLE, EXCLUDEBYROLE, ISCACHED, STATEMENTTYPE, FIELDS) VALUES(3110, 'TRON. Deducible por contrato', 'TRON_DEDU_CONTR', 2, 1, 6329, TIMESTAMP '2021-06-08 22:43:16.000000', 'EM_K_TABLES_CONTRACT_MCR.P_LEE_DEDUCIBLES_BY_CONTRATO {app.p_cod_cia} {cod_ramo} {num_contrato} {extend:varchar}', 'tron', 2, NULL, NULL, 1, 2, 'cod_valor,nom_valor');
INSERT INTO LOOKUPMASTER (LOOKUPID, DESCRIPTION, "KEY", TENANT, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE, "STATEMENT", CONNECTIONNAME, "TYPE", INCLUDEBYROLE, EXCLUDEBYROLE, ISCACHED, STATEMENTTYPE, FIELDS) VALUES(3111, 'TRON. Capital', 'TRON_G2990019', 2, 1, 6329, TIMESTAMP '2021-06-08 22:43:16.000000', ' select NVL(g23.VAL_CAMPO, g19.VAL_CAMPO), NVL(g23.VAL_CAMPO, g19.VAL_CAMPO)
   from G2990019 g19
   left join g2990023 g23
     on g19.cod_cia         = g23.cod_cia
    and g19.cod_ramo        = g23.cod_ramo 
    and g19.num_contrato    = g23.num_contrato
    and g19.cod_modalidad   = g23.cod_modalidad
    and g19.cod_cob         = g23.cod_cob
    and g19.cod_agr         = g23.cod_agr
    and g19.tip_nivel       = g23.tip_nivel
    and g23.num_subcontrato = {num_subcontrato}
  where g19.cod_cia         = {app.p_cod_cia}
    and g19.cod_ramo        = {cod_ramo}
    and g19.num_contrato    = {num_contrato}
    and g19.cod_campo       = {extend:varchar}', 'tron', 2, NULL, NULL, 1, 1, 'cod_valor,nom_valor');
