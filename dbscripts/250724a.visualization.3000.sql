DELETE FROM VISUALIZATIONS v WHERE id IN (3000);

INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,UPDATEUSERCODE,UPDATEDATE) VALUES (3000,1,1,'Mis pólizas','Cliente conectado',TO_CLOB('WITH EXCLUIDOS AS (
SELECT  jt.NUM_POLIZA, jt.NUM_CONTRATO
FROM    aliados.customdata cd
       CROSS APPLY JSON_TABLE( cd.data, ''$.polizasexcluidas[*]'' COLUMNS ( NUM_POLIZA VARCHAR2(13) PATH ''$.NUM_POLIZA'', NUM_CONTRATO NUMBER(5) PATH ''$.NUM_CONTRATO'')) jt
WHERE  cd.key1 = ''ExcludedPolicies'')
SELECT DISTINCT y.nom_ramo, a.cod_ramo, a.num_poliza num_poliza, a.num_poliza_grupo, d.nom_tercero || '' '' || d.ape1_tercero nom_tomador, c.num_riesgo num_riesgo, a.num_spto, a.fec_efec_spto, a.fec_vcto_spto,
       em_f_nom_riesgo_web(a.cod_cia, a.num_poliza, a.num_spto, c.num_riesgo) nom_riesgo,
       dc_k_consulta_web.f_situacion_pol(a.mca_provisional, a.mca_spto_tmp, a.mca_poliza_anulada, a.mca_spto_anulado, a.tip_spto, a.fec_vcto_poliza) valor_status,
       decode(dc_k_consulta_web.f_situacion_pol(a.mca_provisional, a.mca_spto_tmp, a.mca_poliza_anulada, a.mca_spto_anulado, a.tip_spto, a.fec_vcto_poliza),
        ''VIGENTE'', 1,
        ''ANULADA'', 2,
        ''PROVISIONAL/VIG'', 1, 3) num_estatus
  FROM a2000030 a
  JOIN a2000031 c ON  c.cod_cia = a.cod_cia AND c.num_poliza = a.num_poliza AND c.mca_baja_riesgo = ''N'' AND c.mca_vigente = ''S''
  JOIN a1001399 d ON d.cod_cia = a.cod_cia AND d.tip_docum = a.tip_docum AND d.cod_docum = a.cod_docum
  JOIN a1001800 y ON y.cod_cia = a.cod_cia AND y.cod_ramo = a.cod_ramo
 WHERE a.num_poliza IN (SELECT a.NUM_POLIZA FROM a2000030 a WHERE  a.tip_docum = {app.tip_docum} AND a.cod_docum = {app.cod_docum} UNION
                        SELECT a60.NUM_POLIZA FROM A2000060 a60 WHERE  a60.TIP_DOCUM = {app.tip_docum} AND a60.COD_DOCUM = {app.cod_docum} AND a60.TIP_BENEF IN (0, 2, 21))
   AND a.num_spto = (SELECT MAX(num_spto) FROM a2000030 WHERE cod_cia = a.cod_cia AND num_poliza = a.num_poliza AND mca_spto_anulado = ''N'')
   AND a.num_apli = (SELECT MAX(num_apli) FROM a2000030 WHERE cod_cia = a.cod_cia AND num_poliza = a.num_poliza AND num_spto = a.num_spto)
   AND a.num_spto_apli = em_f_max_spto_apli_1_web(a.cod_cia, a.num_poliza, a.num_spto, a.n')||TO_CLOB('um_apli, NULL)
   AND NOT EXISTS (SELECT 1 FROM EXCLUIDOS x WHERE x.NUM_POLIZA = a.NUM_POLIZA_GRUPO AND ((x.NUM_CONTRATO =0) OR (x.NUM_CONTRATO >0 AND x.NUM_CONTRATO = a.NUM_CONTRATO )))   
ORDER BY fec_efec_spto desc'),NULL,NULL,NULL,NULL,1,1,TO_CLOB('{
"title": "Mis pólizas",
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
    "detailId": "3002,3001",
    "detailParameters": "NUM_POLIZA=NUM_POLIZA:P_NUM_RIESGO=NUM_RIESGO",
    "columns": [
        {
            "field": "NOM_RAMO",
            "title": "Ramo",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringCapitalizeFormatter",
            "visible": true
        },
        {
            "field": "NUM_POLIZA",
            "title": "Póliza",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "visible": true
        },
        {
            "field": "NOM_TOMADOR",
            "title": "Tomador",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "visible": false
        },
        {
            "field": "NOM_RIESGO",
            "title": "Riesgo",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "visible": true
        },
        {
            "field": "VALOR_STATUS",
            "title": "Estatus",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.StringCapitalizeFormatter",
            "visible": true
        },
        {
            "field": "FEC_EFEC_SPTO",
            "title": "Inicio de vigencia",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.DateFormatter",
            "visible": true
        },
        {
            "fi')||TO_CLOB('eld": "FEC_VCTO_SPTO",
            "title": "Fin  de vigencia",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.DateFormatter",
            "visible": true
        },
        {
            "title": "Acciones",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "function (value, row, index, field) { return ''<button type=\"button\" name=\"print\" class=\"btn btn-sm btn-white event\" title=\"Permite imprimir la póliza\"><i class=\"fa fa-print\"></i></button>'' ;}",
            "visible": true,
            "events": true
        }
    ]
}
}'),'Tron',1,NULL,NULL,NULL,'Extend.js',10509,TIMESTAMP'2022-05-31 00:00:00');

INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,UPDATEUSERCODE,UPDATEDATE) VALUES (3000,2,1,'Mis siniestros','Cliente conectado',TO_CLOB('WITH EXCLUIDOS AS (
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
 ORDER BY s.fec_denu_sini'),NULL,NULL,NULL,NULL,1,1,TO_CLOB('{
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
                "halign": "center",
                "align": "left",
             ')||TO_CLOB('   "formatter": "app.ui.StringFormatter",
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
}'),'Tron',1,NULL,NULL,NULL,NULL,1,TIMESTAMP'2020-11-24 16:36:23');
