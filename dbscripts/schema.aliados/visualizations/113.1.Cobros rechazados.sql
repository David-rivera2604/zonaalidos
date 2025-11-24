3032510117525INSERT INTO ALIADOS.VISUALIZATIONS (ID, "SEQUENCE", "TYPE", CAPTION, DESCRIPTION, ICON, ICONCLASS, VALUEFORMAT, ENTITYTYPE, RECORDSTATUS, COMPANYID, UPDATEUSERCODE, UPDATEDATE, SPECIFICATION, CONNECTIONNAME, STATEMENTTYPE, DIALOG, STATEMENTEXTEND, "KEY", JAVASCRIPTTOINCLUDE, "STATEMENT") VALUES(113, 1, 1, 'Cobros rechazados', 'Cobros rechazados', NULL, NULL, NULL, NULL, 1, 1, 111, TIMESTAMP '2025-08-31 00:00:00.000000', '{
  "title": "Cobros rechazados",
  "table": {
    "skipload": false,
    "pagination": true,
    "search": true,
    "showToggle": false,
    "showRefresh": false,
    "showColumns": false,
    "showExport": false,
    "showPaginationSwitch": false,
    "exportTypes": [
      "csv",
      "excel"
    ],
    "buttons": "app.CobrosRechazados.Boton",
    "onAll": "app.CobrosRechazados.Eventos",
    "showButtonText": true,
    "columns": [
      {
        "field": "SEL",
        "align": "center",
        "titleTooltip": "Permite seleccionar los recibos para ser excluido del aviso de cobro",
        "checkbox": true
      },
      {
        "field": "POLICYID",
        "title": "Póliza",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "BILLNUMBER",
        "title": "Recibo",
        "sortable": true,
        "halign": "center",
        "align": "center"
      },
      {
        "field": "AMOUNT",
        "title": "Monto",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.CurrencyAmountFormatter"
      },
      {
        "field": "STATUSDATE",
        "title": "Último intento de cobro",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateAndTimeFormatter"
      },
      {
        "field": "REASON",
        "title": "Razón del rechazo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      }
    ]
  }
}', 'tron', 1, '|título
|zona|4
 Agente+|lista|name=cod_agt;lookup=Agents
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 113, @_@_)', NULL, 'CobrosRechazados', 'Extend.CobrosRechazados.js', 'SELECT DISTINCT null Sel, OP.POLICYID, OP.BILLNUMBER, OP.AMOUNT, OP.CURRENCY Cod_Mon, OP.STATUSDATE, OP.REASON
  FROM ALIADOS.ONLINEPAYMENT OP
  JOIN ALIADOS.BOVEDA B ON DECODE(B.TIP_DOCUM, ''CNA'', 1, ''CRE'', 2, ''PAS'', 3, ''CJU'', 4, NULL)=OP.DOCUMENTTYPE AND B.COD_DOCUM=OP.DOCUMENTNUMBER AND  B.NUM_POLIZA=OP.POLICYID
  JOIN A2990700 a700 ON a700.NUM_RECIBO  = OP.BILLNUMBER AND a700.TIP_SITUACION IN (''RE'',''EP'') AND a700.TIP_GESTOR =''TA'' AND a700.COD_AGT = {cod_agt} 
 WHERE  OP.STATUSDATE = (SELECT MAX(STATUSDATE) FROM ALIADOS.ONLINEPAYMENT OPM WHERE OPM.BILLNUMBER=OP.BILLNUMBER) AND OP.PROVIDERSTATUS <> ''APPROVED'' AND OP.Source=''Recurring''');