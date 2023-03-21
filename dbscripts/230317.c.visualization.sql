SET DEFINE OFF;
MERGE INTO VISUALIZATIONS A USING
 (SELECT
  400 as ID,
  1 as SEQUENCE,
  NULL as KEY,
  1 as COMPANYID,
  NULL as ENTITYTYPE,
  1 as TYPE,
  'Avisos de cobro de un agente' as CAPTION,
  NULL as DESCRIPTION,
  1 as STATEMENTTYPE,
  'SELECT a.cod_docum_pago,a.FEC_VCTO_PAGO, a.tip_situacion estatus, COUNT(distinct a.num_recibo) cant_recibos, a.cod_mon, SUM(a.imp_recibo) total_recibos
  FROM a2990700 a
 WHERE a.cod_cia = 1
   AND a.cod_agt = {app.agentcode}
   AND a.cod_docum_pago || '''' IS NOT NULL
   AND a.num_recibo  <> -1
 GROUP BY a.cod_docum_pago, a.FEC_VCTO_PAGO, a.tip_situacion, a.cod_mon
 order by a.cod_docum_pago desc
' as STATEMENT,
  '{
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
' as SPECIFICATION,
  NULL as DIALOG,
  NULL as ICON,
  NULL as ICONCLASS,
  NULL as VALUEFORMAT,
  'Tron' as CONNECTIONNAME,
  'Extend.AvisosCobro.js' as JAVASCRIPTTOINCLUDE,
  1 as RECORDSTATUS,
  1 as UPDATEUSERCODE,
  TO_DATE('06/02/2022 00:00:00', 'MM/DD/YYYY HH24:MI:SS') as UPDATEDATE
  FROM DUAL) B
ON (A.ID = B.ID and A.SEQUENCE = B.SEQUENCE)
WHEN NOT MATCHED THEN 
INSERT (
  ID, SEQUENCE, KEY, COMPANYID, ENTITYTYPE, 
  TYPE, CAPTION, DESCRIPTION, STATEMENTTYPE, STATEMENT, 
  SPECIFICATION, DIALOG, ICON, ICONCLASS, VALUEFORMAT, 
  CONNECTIONNAME, JAVASCRIPTTOINCLUDE, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE)
VALUES (
  B.ID, B.SEQUENCE, B.KEY, B.COMPANYID, B.ENTITYTYPE, 
  B.TYPE, B.CAPTION, B.DESCRIPTION, B.STATEMENTTYPE, B.STATEMENT, 
  B.SPECIFICATION, B.DIALOG, B.ICON, B.ICONCLASS, B.VALUEFORMAT, 
  B.CONNECTIONNAME, B.JAVASCRIPTTOINCLUDE, B.RECORDSTATUS, B.UPDATEUSERCODE, B.UPDATEDATE)
WHEN MATCHED THEN
UPDATE SET 
  A.KEY = B.KEY,
  A.COMPANYID = B.COMPANYID,
  A.ENTITYTYPE = B.ENTITYTYPE,
  A.TYPE = B.TYPE,
  A.CAPTION = B.CAPTION,
  A.DESCRIPTION = B.DESCRIPTION,
  A.STATEMENTTYPE = B.STATEMENTTYPE,
  A.STATEMENT = B.STATEMENT,
  A.SPECIFICATION = B.SPECIFICATION,
  A.DIALOG = B.DIALOG,
  A.ICON = B.ICON,
  A.ICONCLASS = B.ICONCLASS,
  A.VALUEFORMAT = B.VALUEFORMAT,
  A.CONNECTIONNAME = B.CONNECTIONNAME,
  A.JAVASCRIPTTOINCLUDE = B.JAVASCRIPTTOINCLUDE,
  A.RECORDSTATUS = B.RECORDSTATUS,
  A.UPDATEUSERCODE = B.UPDATEUSERCODE,
  A.UPDATEDATE = B.UPDATEDATE;

COMMIT;
