UPDATE ALIADOS.VISUALIZATIONS SET "TYPE"=1, CAPTION='Cobros rechazados', DESCRIPTION='Cobros rechazados', ICON=NULL, ICONCLASS=NULL, VALUEFORMAT=NULL, ENTITYTYPE=NULL, RECORDSTATUS=1, COMPANYID=1, UPDATEUSERCODE=111, UPDATEDATE=TIMESTAMP '2025-08-31 00:00:00.000000', SPECIFICATION='{
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
        "field": "FUENTE",
        "title": "Origen",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.StringFormatter"
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
}', CONNECTIONNAME='tron', STATEMENTTYPE=1, DIALOG='|título
|zona|4
 Agente+|lista|name=cod_agt;lookup=Agents
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 113, @_@_)', STATEMENTEXTEND=NULL, "KEY"='CobrosRechazados', JAVASCRIPTTOINCLUDE='Extend.CobrosRechazados.js', "STATEMENT"='WITH NOTAPPROVED AS (
SELECT DISTINCT null Sel, OP.POLICYID, OP.BILLNUMBER, OP.AMOUNT, OP.CURRENCY Cod_Mon, ''Rechazado'' Fuente, OP.STATUSDATE, OP.REASON
  FROM ALIADOS.ONLINEPAYMENT OP
  JOIN ALIADOS.BOVEDA B ON DECODE(B.TIP_DOCUM, ''CNA'', 1, ''CRE'', 2, ''PAS'', 3, ''CJU'', 4, NULL)=OP.DOCUMENTTYPE AND B.COD_DOCUM=OP.DOCUMENTNUMBER AND  B.NUM_POLIZA=OP.POLICYID
  JOIN A2990700 a700 ON a700.NUM_RECIBO  = OP.BILLNUMBER AND a700.TIP_SITUACION IN (''RE'',''EP'') AND a700.TIP_GESTOR =''TA'' AND a700.COD_AGT = {cod_agt}
 WHERE  OP.STATUSDATE = (SELECT MAX(STATUSDATE) FROM ALIADOS.ONLINEPAYMENT OPM WHERE OPM.BILLNUMBER=OP.BILLNUMBER) AND OP.PROVIDERSTATUS <> ''APPROVED'' AND OP.Source=''Recurring'' 
)
SELECT Sel, POLICYID, BILLNUMBER, AMOUNT, Cod_Mon, Fuente, STATUSDATE, REASON FROM NOTAPPROVED
UNION
SELECT null Sel, A.NUM_POLIZA POLICYID, C.NUM_RECIBO BILLNUMBER, SUM(C.IMP_RECIBO) AMOUNT, C.COD_MON, ''Pendiente'' Fuente, NULL STATUSDATE, NULL REASON
    FROM A2000030 A
    LEFT JOIN (
        SELECT DISTINCT a60.TIP_DOCUM, a60.COD_DOCUM, a60.NUM_POLIZA 
        FROM A2000060 a60  JOIN ALIADOS.BOVEDA B ON  B.NUM_POLIZA=a60.NUM_POLIZA WHERE COD_CIA =1 AND a60.NUM_POLIZA = B.NUM_POLIZA AND TIP_BENEF = 21                                 
    ) a60 ON A.NUM_POLIZA = a60.NUM_POLIZA
    JOIN ALIADOS.BOVEDA B ON B.TIP_DOCUM=COALESCE(a60.TIP_DOCUM, A.TIP_DOCUM) AND B.COD_DOCUM=COALESCE(a60.COD_DOCUM, A.COD_DOCUM) AND B.NUM_POLIZA=A.NUM_POLIZA AND B.NUM_SPTO<=A.NUM_SPTO AND B.STATUS>0 --AND B.NextCollectAttempt<=TRUNC(:fec_efect_recibo2) 
    JOIN A2990700 C 
        ON C.NUM_RECIBO = (SELECT MIN(R.NUM_RECIBO)
                            FROM A2990700 R
                            WHERE R.COD_CIA = A.COD_CIA
                            AND R.NUM_POLIZA = A.NUM_POLIZA
                            AND R.NUM_SPTO <= A.NUM_SPTO
                            AND R.NUM_APLI = A.NUM_APLI
                            AND R.NUM_SPTO_APLI = A.NUM_SPTO_APLI
                            AND R.TIP_SITUACION IN (''RE'',''EP'')
                            AND R.TIP_GESTOR IN (''TA'')
                            AND R.IMP_RECIBO > 0)
       AND NOT C.NUM_RECIBO IN (SELECT BILLNUMBER FROM NOTAPPROVED)
    WHERE A.COD_CIA = 1
	    AND A.COD_AGT = {cod_agt}
        AND A.MCA_POLIZA_ANULADA  = ''N''
        AND A.NUM_SPTO = ( SELECT MAX(A230.NUM_SPTO)
                            FROM A2000030 A230
                            WHERE A230.COD_CIA    = A.COD_CIA
                            AND A230.NUM_POLIZA = A.NUM_POLIZA )
    GROUP BY A.NUM_POLIZA, A.COD_AGT, COALESCE(a60.TIP_DOCUM, A.TIP_DOCUM), COALESCE(a60.COD_DOCUM, A.COD_DOCUM),
   			 C.NUM_RECIBO, C.FEC_EFEC_RECIBO, C.COD_MON ' WHERE ID=113 AND "SEQUENCE"=1;