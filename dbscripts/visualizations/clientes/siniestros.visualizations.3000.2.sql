INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (3000,2,1,'Mis siniestros','Cliente conectado',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-11-24 16:36:23',TO_CLOB('{
    "title": "Siniestros",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": [
            "csv",
            "excel"
        ],
        "columns": [
            {
                "field": "NUM_SINI",
                "title": "No. Siniestro",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "visible": true
            },
            {
                "field": "NUM_RIESGO",
                "title": "NUM_RIESGO",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.IntegerFormatter",
                "visible": false
            },
            {
                "field": "FEC_DENU_SINI",
                "title": "Fecha ocurrencia",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "NOM_VALOR",
                "title": "Estatus",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringCapitalizeFormatter",
                "visible": true
            },
            {
                "field": "NUM_POLIZA",
                "title": "No. Póliza",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NOM_RAMO",
                "title": "Ramo",
                "sortable": true,
                "ha')||TO_CLOB('lign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NOM_RIESGO",
                "title": "Riesgo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            }
        ]
    }
}'),'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('WITH EXCLUIDOS AS (
SELECT  jt.NUM_POLIZA, jt.NUM_CONTRATO
FROM    aliados.customdata cd
       CROSS APPLY JSON_TABLE( cd.data, ''$.polizasexcluidas[*]'' COLUMNS ( NUM_POLIZA VARCHAR2(13) PATH ''$.NUM_POLIZA'', NUM_CONTRATO NUMBER(5) PATH ''$.NUM_CONTRATO'')) jt
WHERE  cd.key1 = ''ExcludedPolicies'')
SELECT s.num_sini, s.num_poliza, s.num_riesgo, s.fec_denu_sini, a.nom_ramo, em_f_nom_riesgo_web (s.cod_cia, s.num_poliza, s.num_spto, s.num_riesgo) nom_riesgo, c.nom_valor
  FROM a7000900 s, a1001800 a, a2000031 b, g1010031 c
 WHERE s.cod_cia = {app.P_COD_CIA}
   AND s.num_poliza IN (SELECT a.NUM_POLIZA FROM a2000030 a WHERE  a.tip_docum = {app.tip_docum} AND a.cod_docum = {app.cod_docum} UNION
                        SELECT a60.NUM_POLIZA FROM A2000060 a60 WHERE  a60.TIP_DOCUM = {app.tip_docum} AND a60.COD_DOCUM = {app.cod_docum} AND a60.TIP_BENEF IN (0, 2, 21))
   AND a.cod_cia = s.cod_cia
   AND a.cod_ramo = s.cod_ramo
   AND b.cod_cia = a.cod_cia
   AND b.num_poliza = s.num_poliza
   AND b.num_spto = s.num_spto_riesgo
   AND b.num_riesgo = s.num_riesgo
   AND c.cod_campo = ''TIP_EST_SINI''
   AND c.cod_idioma = ''ES''
   AND c.cod_valor = s.tip_est_sini
   AND NOT EXISTS(SELECT 1 FROM EXCLUIDOS x WHERE x.NUM_POLIZA = s.NUM_POLIZA_GRUPO AND ((x.NUM_CONTRATO =0) OR (x.NUM_CONTRATO >0 AND x.NUM_CONTRATO = s.NUM_CONTRATO )))
 ORDER BY s.fec_denu_sini'));
