DELETE FROM VISUALIZATIONS WHERE id = 7000 AND SEQUENCE=4;

INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES
	 (7000,4,7,'Recibos pendientes','Card','SELECT COUNT(c.num_recibo) recibos 
    FROM a2000030 a
    JOIN a2990700 c 
      ON c.cod_cia = a.cod_cia
     AND c.num_spto = a.num_spto
     AND c.num_apli = a.num_apli
     AND c.num_poliza = a.num_poliza
     AND c.num_spto_apli = a.num_spto_apli
     AND c.tip_situacion in (''RE'',''EP'')
     AND trunc(c.fec_efec_recibo) <= trunc(sysdate) + 10
   WHERE a.cod_cia             = {app.P_COD_CIA}
     AND a.cod_agt             = {app.P_COD_AGT}
     AND a.mca_spto_anulado    = ''N''
     AND a.mca_poliza_anulada  = ''N''',NULL,NULL,NULL,NULL,1,1,111,TIMESTAMP'2021-10-27 21:25:42.0',NULL,'Tron',1,NULL,NULL,NULL,NULL);
