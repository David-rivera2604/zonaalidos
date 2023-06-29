UPDATE VISUALIZATIONS SET "TYPE"=1, CAPTION='Avisos de cobro de un agente', DESCRIPTION=NULL, "STATEMENT"='SELECT a.cod_docum_pago,a.FEC_VCTO_PAGO, a.tip_situacion estatus, COUNT(distinct a.num_recibo) cant_recibos, a.cod_mon, SUM(a.imp_recibo) total_recibos
  FROM a2990700 a
 WHERE a.cod_cia = 1
   AND a.cod_agt = {app.agentcode}
   AND a.cod_docum_pago || '''' IS NOT NULL
   AND a.num_recibo  <> -1
 GROUP BY a.cod_docum_pago, a.FEC_VCTO_PAGO, a.tip_situacion, a.cod_mon
 order by a.cod_docum_pago desc
', ICON=NULL, ICONCLASS=NULL, VALUEFORMAT=NULL, ENTITYTYPE=NULL, RECORDSTATUS=1, COMPANYID=1, UPDATEUSERCODE=1, UPDATEDATE=TIMESTAMP '2022-06-02 00:00:00.000000', SPECIFICATION='{
  "title": "Avisos de cobro de un agente",
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
    "detailId": 401,
    "detailParameters": "cod_docum_pago=COD_DOCUM_PAGO",
    "columns": [
      {
        "field": "COD_DOCUM_PAGO",
        "title": "No. Aviso",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "FEC_VCTO_PAGO",
        "title": "Fecha de Vencimiento",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter"
      },
      {
        "field": "ESTATUS",
        "title": "Estado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "CANT_RECIBOS",
        "title": "Recibos",
        "titleTooltip": "Cantidad de recibos",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.IntegerFormatter"
      },
      {
        "field": "TOTAL_RECIBOS",
        "title": "Monto",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.CurrencyAmountFormatter"
      },
      {
        "title": "Acciones",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button name=\"editaraviso\" type=\"button\" class=\"btn btn-sm btn-white event\" title=\"Permite editar el aviso\"><i class=\"fa fa-pencil\"></i></button><button name=\"eliminaaviso\" type=\"button\" class=\"btn btn-sm btn-white event\" title=\"Permite eliminar el aviso\"><i class=\"fa fa-trash\"></i></button><button name=\"imprimeaviso\" type=\"button\" class=\"btn btn-sm btn-white event\" title=\"Permite generar el PDF del aviso\"><i class=\"fa fa-print\"></i></button><button type=\"button\" name=\"detalleaviso\" class=\"btn btn-sm btn-white event\" title=\"Permite generar el PDF del detalle del aviso\"><i class=\"fa fa-asterisk\"></i></button></span>'' ;}",
        "events": true,
        "action_payment": "app.core.LoadScriptFile(''Payment.js'').then(d => {app.Payment.Recibo(row, 3001, 1)})"
      }
    ]
  }
}
', CONNECTIONNAME='Tron', STATEMENTTYPE=1, DIALOG=NULL, STATEMENTEXTEND=NULL, "KEY"=NULL, JAVASCRIPTTOINCLUDE='Extend.AvisosCobro.js' WHERE ID=400 AND "SEQUENCE"=1;
UPDATE VISUALIZATIONS SET "TYPE"=1, CAPTION='Recibos de un aviso de cobro', DESCRIPTION=NULL, "STATEMENT"='SELECT null Sel, {cod_docum_pago:varchar} cod_docum_pago, num_poliza, num_recibo, FEC_EFEC_RECIBO, tip_situacion, cod_mon, tip_docum, cod_docum, NOM_COMPLETO, nom_riesgo, sum(imp_recibo)
  FROM ( SELECT a.num_poliza, a.num_recibo, a.FEC_EFEC_RECIBO, a.tip_situacion, a.cod_mon, c.tip_docum, c.cod_docum, V90.NOM_COMPLETO, em_f_nom_riesgo_web(a.cod_cia, a.num_poliza, a.num_spto, 1) nom_riesgo, a.imp_recibo
  FROM a2990700 a
  LEFT JOIN a2000060 c ON c.cod_cia = a.cod_cia and c.num_poliza = a.num_poliza and c.tip_benef = 2
  LEFT JOIN V1001390 V90 ON v90.COD_ACT_TERCERO = 1 AND V90.TIP_DOCUM = c.tip_docum AND V90.COD_DOCUM = c.cod_docum
 WHERE a.cod_cia = 1
   AND a.cod_docum_pago = {cod_docum_pago:varchar}
   AND a.num_recibo  <> -1)
 group by num_poliza, num_recibo, FEC_EFEC_RECIBO, tip_situacion, cod_mon, tip_docum, cod_docum, NOM_COMPLETO, nom_riesgo
 order by num_recibo, num_poliza', ICON=NULL, ICONCLASS=NULL, VALUEFORMAT=NULL, ENTITYTYPE=NULL, RECORDSTATUS=1, COMPANYID=1, UPDATEUSERCODE=1, UPDATEDATE=TIMESTAMP '2022-06-02 00:00:00.000000', SPECIFICATION='{
  "title": "Recibos de un aviso de cobro",
  "table": {
    "pagination": true,
    "search": true,
    "showToggle": true,
    "showRefresh": true,
    "showColumns": true,
    "showExport": true,
    "exportTypes": [
      "csv",
      "excel"
    ],
    "showPaginationSwitch": true,
    "buttons": "app.Ex_AvisosCobro.Boton",
    "onAll": "app.Ex_AvisosCobro.Eventos",
    "showButtonText": true,
    "columns": [
      {
        "field": "SEL",
        "align": "center",
        "titleTooltip": "Permite seleccionar los recibos para ser excluido del aviso de cobro",
        "checkbox": true
      },
      {
        "field": "NUM_RECIBO",
        "title": "No. Recibo",
        "sortable": true,
        "halign": "center",
        "align": "center"
      },
      {
        "field": "SUM(IMP_RECIBO)",
        "title": "Monto",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": ""
      },
      {
        "field": "FEC_EFEC_RECIBO",
        "title": "Fecha de efecto",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter"
      },
      {
        "field": "TIP_SITUACION",
        "title": "Estado",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "NUM_POLIZA",
        "title": "Poliza",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "NOM_RIESGO",
        "title": "Nombre del riesgo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "NOM_COMPLETO",
        "title": "Asegurado",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "format": "{TIP_DOCUM} {COD_DOCUM} {NOM_COMPLETO}"
      }
    ]
  }
}', CONNECTIONNAME='Tron', STATEMENTTYPE=1, DIALOG=NULL, STATEMENTEXTEND=NULL, "KEY"=NULL, JAVASCRIPTTOINCLUDE=NULL WHERE ID=401 AND "SEQUENCE"=1;
