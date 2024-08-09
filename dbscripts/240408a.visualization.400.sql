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
        "formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button name=\"eliminaaviso\" type=\"button\" class=\"btn btn-sm btn-white event\" title=\"Permite eliminar el aviso\"><i class=\"fa fa-trash\"></i></button><button name=\"imprimeaviso\" type=\"button\" class=\"btn btn-sm btn-white event\" title=\"Permite generar el PDF del aviso\"><i class=\"fa fa-print\"></i></button><button type=\"button\" name=\"detalleaviso\" class=\"btn btn-sm btn-white event\" title=\"Permite generar el PDF del detalle del aviso\"><i class=\"fa fa-asterisk\"></i></button></span>'' ;}",
        "events": true,
        "action_eliminaaviso": "app.Ex_AvisosCobro.Eliminar(row)",
        "action_imprimeaviso": "app.Ex_AvisosCobro.Imprimir(row)",
        "action_detalleaviso": "app.Ex_AvisosCobro.ImprimirDetalle(row)"
      }
    ]
  }
}
', CONNECTIONNAME='Tron', STATEMENTTYPE=1, DIALOG=NULL, STATEMENTEXTEND=NULL, "KEY"=NULL, JAVASCRIPTTOINCLUDE='Extend.AvisosCobro.js' WHERE ID=400 AND "SEQUENCE"=1;