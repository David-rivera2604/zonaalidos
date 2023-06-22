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
