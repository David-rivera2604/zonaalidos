INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (3002,1,1,'Coberturas','Coberturas de una póliza - Cliente conectado',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'1970-02-07 00:00:00',TO_CLOB('{
    "title": "Coberturas",
    "table": {
        "pagination": false,
        "search": false,
        "showToggle": false,
        "showRefresh": false,
        "showColumns": false,
        "showExport": false,
        "showPaginationSwitch": false,
        "columns": [
            {
                "field": "COD_COB",
                "title": "Código",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "visible": true
            },
            {
                "field": "NOM_COB",
                "title": "Cobertura",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NOM_MON",
                "title": "Moneda",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "SUM_ASEG_RIESGO",
                "title": "Capital",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.DecimalWithZeroFormatter",
                "visible": true
            },
            {
                "field": "PRIMA_RIESGO",
                "title": "Prima",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.DecimalWithZeroFormatter",
                "visible": true
            },
            {
                "field": "NUM_SECU",
                "title": "NUM_SECU",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "visible": false
            }
        ]
    }
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('DC_K_CONSULTA_WEB.P_DEVUELVE_DETALLE_RIESGO {app.P_COD_CIA} {const.9999999} {P_COD_USR:varchar} {NUM_POLIZA:varchar} {P_NUM_RIESGO} {P_NUM_SPTO} {P_NUM_APLI} {p_num_riesgo_out:numericout} {p_nom_tomador:varcharout} {p_nom_riesgo:varcharout} {p_mca_baja_riesgo:varcharout} {p_mca_vigente:varcharout} {p_cursor_cobertura:cursor} {p_errores:cursor}'));
