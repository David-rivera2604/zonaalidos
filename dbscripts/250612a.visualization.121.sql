INSERT INTO VISUALIZATIONS (ID, "SEQUENCE", "TYPE", CAPTION, DESCRIPTION, ICON, ICONCLASS, VALUEFORMAT, ENTITYTYPE, RECORDSTATUS, COMPANYID, UPDATEUSERCODE, UPDATEDATE, SPECIFICATION, CONNECTIONNAME, STATEMENTTYPE, DIALOG, STATEMENTEXTEND, "KEY", JAVASCRIPTTOINCLUDE, "STATEMENT") VALUES(121, 1, 1, 'Ejecuciones de cobros recurrentes', 'Ejecuciones de cobros recurrentes', NULL, NULL, NULL, NULL, 1, 1, 1, TIMESTAMP '2025-05-28 19:56:10.000000', '{
  "title": "Ejecuciones de cobros recurrentes",
  "table": {
    "pagination": true,
    "search": true,
    "showToggle": false,
    "showRefresh": false,
    "showColumns": false,
    "showExport": true,
    "showPaginationSwitch": false,
    "exportTypes": [
      "csv",
      "excel"
    ],
    "columns": [
      {
        "field": "PROCESSID",
        "title": "Acción",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "format": "<button name=''download'' type=''button'' class=''btn btn-sm btn-link event'' title=''Permite descargar el reporte domiciliación'' style=''font-size: 11px;''><i class=''fa fa-download''></i></button>",
        "events": true,
        "action_download": "app.core.GetXLSX(''110'', ''Reporte Domiciliación.xlsx'', false, ''processid={PROCESSID}'')"
      },
      {
        "field": "STARTDATE",
        "title": "Inicio",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateAndTimeFormatter"
      },
      {
        "field": "FINISHDATE",
        "title": "Fin",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateAndTimeFormatter"
      },
      {
        "field": "POLICYCOUNT",
        "title": "Cantidad de pólizas procesadas",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.IntegerFormatter"
      },
      {
        "field": "BILLCOUNT",
        "title": "Cantidad de recibos procesados",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.IntegerFormatter"
      },
      {
        "field": "FIRSTPOLICY",
        "title": "Primera póliza",
        "titleTooltip": "Primera póliza procesada",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "FIRSTBILL",
        "title": "Primer recibo",
        "titleTooltip": "rimer recibo procesado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.IntegerFormatter"
      }
    ]
  }
}', 'Research', 1, NULL, NULL, NULL, NULL, 'SELECT MIN(ISSUEDATE) STARTDATE, MAX(STATUSDATE) FINISHDATE, PROCESSID, COUNT(POLICYID) POLICYCOUNT, COUNT(BILLNUMBER) BILLCOUNT, MIN(POLICYID) FIRSTPOLICY, MIN(BILLNUMBER) FIRSTBILL
FROM ONLINEPAYMENT
WHERE "SOURCE" = ''Recurring''
GROUP BY PROCESSID ORDER BY STARTDATE DESC
FETCH FIRST 1000 ROWS ONLY');