INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (3001,1,1,'Recibos','Recibos de una poliza - Cliente conectado',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-11-24 12:33:30',TO_CLOB('{
  "title": "Recibos",
  "table": {
    "pagination": true,
    "search": true,
    "showToggle": true,
    "showRefresh": true,
    "showColumns": true,
    "showExport": true,
    "showPaginationSwitch": true,
    "columns": [
      {
        "field": "NUM_RECIBO",
        "title": "No. Recibo",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "visible": true
      },
      {
        "field": "TIP_SITUACION_DESC",
        "title": "Estado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.BadgeColorFormatter",
        "colorstate": {
          "VIGENTE": "primary",
          "_": "danger",
          "Cobrado": "success",
          "Pendiente": "warning"
        }
      },
      {
        "field": "IMP_RECIBO",
        "title": "Monto",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.CurrencyAmountFormatter",
        "visible": true
      },
      {
        "field": "FEC_EFEC_RECIBO",
        "title": "Inicio de vigencia",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      },
      {
        "field": "FEC_VCTO_RECIBO",
        "title": "Fin  de vigencia",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      },
      {
        "field": "FEC_VCTO_PAGO",
        "title": "Vencimiento",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      },
      {
        "field": "CARD",
        "title": "Tarjeta Asociada",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "visible": true
      },
      {
        "title": "Acciones",
        "sortable": true,
        "halign": "c')||TO_CLOB('enter",
        "align": "center",
        "formatter": "app.Extend.AccionesClienteFormatter",        
        "visible": true,
        "events": true,
        "action_payment": "app.core.LoadScriptFile(''Payment.js'').then(d => {app.Payment.Recibo(row, 3001, 1)})"
      }
    ]
  }
}'),'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT row_number() OVER (ORDER BY a.num_recibo ASC) AS pos_recibo, a.num_poliza, a.num_recibo, a.fec_efec_recibo, a.fec_vcto_recibo,a.fec_vcto_pago, a.cod_mon, a.imp_recibo,
     a.tip_situacion, b.nom_situacion situacion_recibo, decode(a.tip_situacion, ''CT'', ''Cobrado'', ''Pendiente'') tip_situacion_desc, bo.card
  FROM a2990700 a
  LEFT JOIN a5020500 b ON b.tip_situacion = a.tip_situacion
    LEFT JOIN ALIADOS.BOVEDA bo ON a.num_poliza = bo.num_poliza 
 WHERE a.cod_cia = {app.P_COD_CIA}
   AND a.num_poliza = {NUM_POLIZA:varchar}
   AND a.num_spto IN (SELECT DISTINCT d.num_spto FROM a2000030 d WHERE d.cod_cia = a.cod_cia AND d.num_poliza = a.num_poliza  and trunc(SYSDATE) BETWEEN d.fec_efec_spto and d.fec_vcto_spto)
   AND a.num_recibo > 0
 ORDER BY a.num_recibo ASC'));
