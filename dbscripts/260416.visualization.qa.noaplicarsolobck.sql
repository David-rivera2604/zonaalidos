SELECT *
FROM VISUALIZATIONS v WHERE ID IN (400,402,11,121,305,320,322,333,333,395,412,6000,111,300,301,304,310,317,318,396,410,411,113,18,360,9105, 17, 302, 303, 309, 311, 316, 321, 401)
ORDER BY ID, SEQUENCE

INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (11,1,1,'Auditoria de acceso','Listado con la información de acceso de los usuarios del sistema',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-04-08 19:56:10',TO_CLOB('{
    "title": "@Title@",
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
                "field": "Cuando",
                "title": "Cuando",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateAndTimeFormatter"
            },
            {
                "field": "Origen",
                "title": "Origen",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "class": "d-none d-none d-none d-lg-table-cell d-xl-table-cell"
            },
            {
                "field": "Usuario",
                "title": "Usuario",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Correo",
                "title": "Correo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "function (value, row, index, field) { return ''<a href=?id=17&UserId='' + row.UserId + ''>'' + value + ''</a>'';}"
            },
            {
                "field": "Nombre",
                "title": "Nombre",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Apellido",
                "title": "Apellido",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
     ')||TO_CLOB('           "field": "Sucursal",
                "title": "Sucursal",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Resultado",
                "title": "Resultado",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Razón",
                "title": "Razón",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "class": "d-none d-sm-table-cell d-md-table-cell d-lg-table-cell d-xl-table-cell",
                "visible": false
            }
        ]
    }
}'),'Research',1,'|título
|zona|4
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 11, @_@_)',NULL,NULL,NULL,TO_CLOB('SELECT A.EFFECTDATE "Cuando", A.IPADDRESS "Origen", A.USERNAME "Usuario",U.UserId "UserId", U.EMAIL "Correo", U.FIRSTNAME "Nombre", U.LASTNAME "Apellido", BO.DESCRIPTION "Sucursal", L.DESCRIPTION "Resultado", A.REASON "Razón"
  FROM AUTHENTICATIONTRACE A 
  LEFT JOIN LOOKUP L ON L.LOOKUPID=3 AND L.LANGUAGE=1 AND L.CODE = A.TRACETYPE
  LEFT JOIN USERMEMBER U ON U.COMPANYID=A.COMPANYID AND LOWER(U.USERNAME)=LOWER(A.USERNAME)
  LEFT JOIN LOOKUP BO ON BO.LOOKUPID=1100 AND BO.LANGUAGE=1 AND BO.COMPANYID=U.COMPANYID AND BO.CODE = U.BRANCHOFFICE
 WHERE A.COMPANYID={app.companyid} AND TRUNC(EFFECTDATE)>={desde:date} AND TRUNC(EFFECTDATE)<={hasta:date}  
  ORDER BY A.ID DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (17,1,1,'Detalle de actividades por usuario','Listado con las actividades realizadas por un usuario',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-08 19:09:32',TO_CLOB('{
    "title": "Listado con las actividades realizadas por un usuario",
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
                "field": "Id",
                "title": "Id",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.IntegerFormatter",
                "visible": false
            },
            {
                "field": "Usuario",
                "title": "Usuario",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Fecha",
                "title": "Fecha",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateAndTimeFormatter",
                "visible": true
            },
            {
                "field": "Entidad",
                "title": "Entidad",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Referencia",
                "title": "Referencia",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.IntegerFormatter",
                "visible": true
            },
            {
                "field": "Acción",
                "title": "Acción",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.Strin')||TO_CLOB('gFormatter",
                "visible": true
            },
            {
                "field": "Descripción",
                "title": "Descripción",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            }
        ]
    }
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT C.UPDATEUSERCODE "Id", U.USERNAME "Usuario", C.UPDATEDATE "Fecha", L.DESCRIPTION "Entidad", C.ENTITYID "Referencia", C.ACTION "Acción", C.SUMMARY "Descripción" FROM CHANGESET C
LEFT JOIN LOOKUP L ON L.LOOKUPID=50 AND L.LANGUAGE=1 AND L.CODE = C.ENTITYTYPE
LEFT JOIN USERMEMBER U ON U.COMPANYID=1 AND U.USERID=C.UPDATEUSERCODE
WHERE C.COMPANYID={app.companyid} AND ((0={UserId}) OR (C.UPDATEUSERCODE={UserId}))
ORDER BY C.UPDATEDATE DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (18,1,1,'Usuarios por rol','Listado de usuarios agrupado por rol',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-09 14:03:25',NULL,'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT rm.ROLEID "RolId|h", rm.ROLENAME "Rol", rm.DESCRIPTION "Descripción", rm.SECURITYLEVEL "Nivel|h",  lrs2.DESCRIPTION "Estado del rol", urm.USERID "UserId|h", um.USERNAME "Usuario", um.EMAIL "Correo", um.FIRSTNAME "Nombre", um.LASTNAME "Apellido", LSU.DESCRIPTION "Sucursal", lrs.DESCRIPTION "Estado del usuario"
FROM ROLEMEMBER rm 
LEFT JOIN USERROLEMEMBER urm ON urm.COMPANYID=rm.COMPANYID AND URM.ROLEID=rm.ROLEID
LEFT JOIN USERMEMBER um ON um.COMPANYID=rm.COMPANYID AND um.USERID=urm.USERID
LEFT JOIN LOOKUP LSU ON LSU.LOOKUPID = 1100 AND LSU.COMPANYID=um.COMPANYID AND LSU.LANGUAGE=1 AND LSU.CODE=um.BRANCHOFFICE
LEFT JOIN LOOKUP lrs ON lrs.LOOKUPID = 1 AND lrs.LANGUAGE=1 AND lrs.CODE=um.RECORDSTATUS
LEFT JOIN LOOKUP lrs2 ON lrs2.LOOKUPID = 1 AND lrs2.LANGUAGE=1 AND lrs2.CODE=rm.RECORDSTATUS
WHERE rm.COMPANYID={app.companyid}
ORDER BY rm.ROLENAME'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (111,1,1,'Resultado Cobros Sinpe Móvil','Resultado Cobros Sinpe Móvil',NULL,NULL,NULL,NULL,1,1,111,TIMESTAMP'2025-08-27 00:00:00',TO_CLOB('{
  "title": "Cobros por Sinpe Móvil",
  "table": {
    "pagination": true,
    "search": true,
    "showRefresh": true,
    "showExport": true,
    "exportTypes": [
      "csv",
      "excel"
    ],
    "detailId": 309,
    "detailParameters": "num_sini=NUM_SINI:tip_est_exp=const.T",
    "columns": [
    {
"field": "ENTIDAD_BANCARIA",
"title": "Entidad Bancaria",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.StringFormatter"
},
{
"field": "IDENTIFICACION_CLIENTE",
"title": "Identificacion",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOMBRE_CLIENTE",
"title": "Nombre",
"sortable": true,
"halign": "center",
"align": "left"
},
{
"field": "FECHA",
"title": "Ramo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.DateFormatter"
},
{
"field": "NUMERO_COMPROBANTE",
"title": "Comprobante",
"sortable": true,
"halign": "center",
"align": "left"
},
{
"field": "MONTO",
"title": "Monto",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.DecimalFormatter"
},
{
"field": "APLICADO_A_LA_POLIZA",
"title": "Detalle",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "ESTADO",
"title": "Estado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "RESULTADO",
"title": "Resultado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NUM_POLIZA",
"title": "Póliza",
"sortable": true,
"halign": "center",
"align": "left"
},
{
"field": "CODIGO_AGENTE",
"title": "Codigo Intermediario",
"sortable": true,
"halign": "center",
"align": "left"
},
{
"field": "AGENTE",
"title": "Intermediario",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatt')||TO_CLOB('er"
}
    ]
  }
}'),'Tron',2,'|título
|zona|4
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 11, @_@_)',NULL,'ReporteCobroSinpe',NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_Reporte_Cobro_Sinpe {desde:date} {hasta:date}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (113,1,1,'Cobros rechazados','Cobros rechazados',NULL,NULL,NULL,NULL,1,1,111,TIMESTAMP'2025-08-31 00:00:00',TO_CLOB('{
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
}'),'tron',1,'|título
|zona|4
 Agente+|lista|name=cod_agt;lookup=Agents
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 113, @_@_)',NULL,'CobrosRechazados','Extend.CobrosRechazados.js',TO_CLOB('WITH NOTAPPROVED AS (
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
                            AND')||TO_CLOB(' R.TIP_GESTOR IN (''TA'')
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
   			 C.NUM_RECIBO, C.FEC_EFEC_RECIBO, C.COD_MON '));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (121,1,1,'Ejecuciones de cobros recurrentes','Ejecuciones de cobros recurrentes',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2025-05-28 19:56:10',TO_CLOB('{
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
')||TO_CLOB('
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
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT MIN(ISSUEDATE) STARTDATE, MAX(STATUSDATE) FINISHDATE, PROCESSID, COUNT(POLICYID) POLICYCOUNT, COUNT(BILLNUMBER) BILLCOUNT, MIN(POLICYID) FIRSTPOLICY, MIN(BILLNUMBER) FIRSTBILL
FROM ONLINEPAYMENT
WHERE "SOURCE" = ''Recurring''
GROUP BY PROCESSID ORDER BY STARTDATE DESC
FETCH FIRST 1000 ROWS ONLY'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (300,1,1,'Polizas activas','Mis clientes - Agente conectado',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 21:49:26',TO_CLOB('{
"title": "Polizas activas",
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
"title": "Acciones",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "function (value, row, index, field) { return ''<span class=\"columnBtn\"><button type=\"button\" name=\"print\" class=\"btn btn-sm btn-white event\" title=\"Permite imprimir la poliza\"><i class=\"fa fa-print\"></i></button>'' + ''<button type=\"button\" name=\"printCreditor\" class=\"btn btn-sm btn-white event\" title=\"Permite imprimir Anexo de acreedor de la p?liza\"><i class=\"fa fa-print\"></i></button>'' + ''<button type=\"button\" name=\"sendemail\" class=\"btn btn-sm btn-white event\" title=\"Permite enviar el certificado por correo\"><i class=\"fa fa-envelope-o\"></i></button>'' + ''<button type=\"button\" name=\"updatepol\" class=\"btn btn-sm btn-white event\" title=\"Permite realizar variaciones sobre la poliza\"><i class=\"fa fa-pencil\"></i></button>''+''<button type=\"button\" name=\"cancelpol\" class=\"btn btn-sm btn-white event\" title=\"Permite cancelar la p?liza\"><i class=\"fa fa-close\"></i></button>''+''</span>'' ;}",
"visible": true,
"events": true,
"action_sendemail": "app.ui.ShowSideBar({ title: ''Enviar certificado por correo'', subtitle: ''Poliza #{NUM_POLIZA}'', id: 9000, data: row})",
"action_updatepol": "app.ui.ShowSideBar({ isExternal: true, url: ''/Aliados/variaciones/mapfremas'', title: ''Solicitud de variaciones'', width: ''600px'', data: row})",
"action_cancelpol":  "app.ui.ShowSideBar({ title: ''Cancelar la poliza #{NUM_POLIZA}'', id: 9003, data: row})"
},
{
"field": "NUM_POLIZA_GRUPO",
"title": "Poliza Grupo",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NUM_CONTRATO",
"title": "Contrato",
"sortable": true,
"halign": "center')||TO_CLOB('",
"align": "center",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NUM_POLIZA",
"title": "No. Poliza",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "function (value, row, index, field) { return ''<a href=tabrender?id=302&P_NUM_POLIZA='' + row.NUM_POLIZA + '' onclick=app.ViewerQuery.TabRender(this); return false;>'' + value + ''</a>''; }"
},
{
"field": "ABR_RAMO",
"title": "Ramo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeFormatter"
},
{
"field": "COD_DOCUM",
"title": "Cedula Tomador",
"sortable": true,
"halign": "center",
"align": "left",
"format": "{TIP_DOCUM} {COD_DOCUM}"
},
{
"field": "NOM_TOMADOR",
"title": "Tomador",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeEachWordFormatter"
},
{
"field": "TLF_NUMERO",
"title": "Telefono",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "EMAIL",
"title": "Correo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "IDENTIFICACION",
"title": "Cedula Asegurado",
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
"formatter": "app.ui.StringCapitalizeEachWordFormatter"
},
{
"field": "TLF_NUMERO_ASEG",
"title": "Telefono Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "EMAIL_ASEG",
"title": "Correo Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_ACREEDOR",
"title": "Acreedor",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_RIESGO",
"title": "Riesgo"')||TO_CLOB(',
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_FRACC_PAGO",
"title": "Fraccionamiento",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeFormatter"
},
{
"field": "FEC_EFEC_POLIZA",
"title": "Inicio de vigencia",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.DateFormatter"
},
{
"field": "FEC_VCTO_POLIZA",
"title": "Fin de vigencia",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.DateFormatter"
}
]
}
}'),'Tron',2,NULL,NULL,NULL,'Extend.Policy.js',TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_policy_by_agent_tomador {app.P_COD_CIA} {app.P_COD_AGT}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (300,2,1,'Pólizas canceladas','Mis clientes - Agente conectado',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
    "title": "Pólizas canceladas",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
        "columns": [
            {
                "field": "NUM_POLIZA",
                "title": "No. Póliza",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "function (value, row, index, field) { return ''<a href=tabrender?id=302&P_NUM_POLIZA='' + row.NUM_POLIZA + '' onclick=app.ViewerQuery.TabRender(this); return false;>'' + value + ''</a>''; }"
            },
            {
                "field": "ABR_RAMO",
                "title": "Ramo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringCapitalizeFormatter"
            },
            {
                "field": "COD_DOCUM",
                "title": "Cédula",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "format": "{TIP_DOCUM} {COD_DOCUM}"
            },
            {
                "field": "NOM_COMPLETO",
                "title": "Contratante",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringCapitalizeEachWordFormatter"
            },
            {
                "field": "FEC_EFEC_SPTO",
                "title": "Fecha Anulación",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter"
            }
        ]
    }
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_policies_cancelled {app.P_COD_CIA} {app.P_COD_AGT}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (300,3,1,'Siniestros activos','Mis clientes - Agente conectado',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
    "title": "Siniestros Activos",
    "table": {
        "pagination": true,
        "search": true,
        "showRefresh": true,
        "showExport": true,
        "exportTypes": ["csv", "excel"],
        "detailId": 309,
        "detailParameters": "num_sini=NUM_SINI:tip_est_exp=const.P",
        "columns": [
            {
                "field": "NUM_POLIZA_GRUPO",
                "title": "Poliza Grupo",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NUM_POLIZA",
                "title": "No. Poliza",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "COD_MON",
                "title": "Moneda",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.IntegerFormatter",
                "visible": true
            },
            {
                "field": "NOM_RIESGO",
                "title": "Nombre del Riesgo",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NOM_EXP",
                "title": "Expediente",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NUM_SINI",
                "title": "No. Siniestro",
                "sortable": true,
                "halign": "center",
                "visible": true
            },
            {
                "field": "COD_DOCUM",
                "title": "Cedula",
                "sortable": true,
                "halign": ')||TO_CLOB('"center",
                "format": "{TIP_DOCUM} {COD_DOCUM}",
                "visible": true
            },
            {
                "field": "NOM_COMPLETO",
                "title": "Contratante",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.StringCapitalizeEachWordFormatter",
                "visible": true
            },
            {
                "field": "FEC_SINI",
                "title": "Fecha Ocurrencia",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
             {
                "field": "IMP_VAL_INICIAL",
                "title": "Imp. Reserva",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.DecimalFormatter",
                "visible": true
            },
            {
                "field": "IMP_VAL",
                "title": "Imp. Estimado",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.DecimalFormatter",
                "visible": true
            }
        ]
    }
}
'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_claims {app.P_COD_CIA} {app.P_COD_AGT} {const.P}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (300,4,1,'Siniestros pagados','Mis clientes - Agente conectado',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
    "title": "Siniestros Terminados",
    "table": {
        "pagination": true,
        "search": true,
        "showRefresh": true,
        "showExport": true,
        "exportTypes": ["csv", "excel"],
        "detailId": 309,
        "detailParameters": "num_sini=NUM_SINI:tip_est_exp=const.T",
        "columns": [
            {
                "field": "NUM_POLIZA_GRUPO",
                "title": "Poliza Grupo",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NUM_POLIZA",
                "title": "No. Poliza",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "COD_MON",
                "title": "Moneda",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.IntegerFormatter",
                "visible": true
            },
            {
                "field": "NOM_RIESGO",
                "title": "Nombre del Riesgo",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NOM_EXP",
                "title": "Expediente",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NUM_SINI",
                "title": "No. Siniestro",
                "sortable": true,
                "halign": "center",
                "visible": true
            },
            {
                "field": "COD_DOCUM",
                "title": "Cedula",
                "sortable": true,
                "halign')||TO_CLOB('": "center",
                "format": "{TIP_DOCUM} {COD_DOCUM}",
                "visible": true
            },
            {
                "field": "NOM_COMPLETO",
                "title": "Contratante",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.StringCapitalizeEachWordFormatter",
                "visible": true
            },
            {
                "field": "FEC_SINI",
                "title": "Fecha Ocurrencia",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "IMP_PAG",
                "title": "Imp. Pagado",
                "sortable": true,
                "halign": "center",
                "formatter": "app.ui.DecimalFormatter",
                "visible": true
            }
        ]
    }
}
'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_claims {app.P_COD_CIA} {app.P_COD_AGT} {const.T}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (300,99,1,'Pólizas activas','Mis clientes - Agente conectado',NULL,NULL,NULL,NULL,2,1,6329,TIMESTAMP'2021-06-23 21:49:26',TO_CLOB('{
"field": "NUM_POLIZA_GRUPO",
"title": "Poliza Grupo",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NUM_CONTRATO",
"title": "Contrato",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NUM_POLIZA",
"title": "No. Poliza",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "function (value, row, index, field) { return ''<a href=tabrender?id=302&P_NUM_POLIZA='' + row.NUM_POLIZA + '' onclick=app.ViewerQuery.TabRender(this); return false;>'' + value + ''</a>''; }"
},
{
"field": "ABR_RAMO",
"title": "Ramo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeFormatter"
},
{
"field": "COD_DOCUM",
"title": "Cedula Tomador",
"sortable": true,
"halign": "center",
"align": "left",
"format": "{TIP_DOCUM} {COD_DOCUM}"
},
{
"field": "NOM_TOMADOR",
"title": "Tomador",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeEachWordFormatter"
},
{
"field": "TLF_NUMERO",
"title": "Telefono",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "EMAIL",
"title": "Correo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "IDENTIFICACION",
"title": "Cedula Asegurado",
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
"formatter": "app.ui.StringCapitalizeEachWordFormatter"
},
{
"field": "TLF_NUMERO_ASEG",
"title": "Telefono Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "EMAIL_ASEG",
"title": "Correo Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_ACREEDOR",
"title": "Acreed')||TO_CLOB('or",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_RIESGO",
"title": "Riesgo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_FRACC_PAGO",
"title": "Fraccionamiento",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeFormatter"
},
{
"field": "FEC_EFEC_POLIZA",
"title": "Inicio de vigencia",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.DateFormatter"
},
{
"field": "FEC_VCTO_POLIZA",
"title": "Fin de vigencia",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.DateFormatter"
},
   {
      "title": "Acciones",
      "sortable": true,
      "halign": "center",
      "align": "center",
      "formatter": "function (value, row, index, field) { return ''<button type=\"button\" name=\"print\" class=\"btn btn-sm btn-white event\" title=\"Permite imprimir la poliza\"><i class=\"fa fa-print\"></i></button>'' + ''<button type=\"button\" name=\"sendemail\" class=\"btn btn-sm btn-white event\" title=\"Permite eviar el certificado por correo\"><i class=\"fa fa-envelope-o\"></i></button>'' ;}",
      "visible": true,
      "events": true,
      "action_sendemail": "app.ui.ShowSideBar({ title: ''Enviar certificado por correo'', subtitle: ''Poliza #{NUM_POLIZA}'', id: 9000, data: row})"
   }
]
}
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('EM_K_MAPFRE_QUERY_CONTRACT_MCR.P_POLICY_BY_AGENT {app.P_COD_CIA} {app.P_COD_AGT}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (301,1,1,'Pólizas activas por agente','Filtro',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-03-18 10:55:28',TO_CLOB('{
    "title": "Pólizas activas",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
        "columns": [
            {
                "field": "NUM_POLIZA",
                "title": "No. Póliza",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "function (value, row, index, field) { return ''<a href=tabrender?id=302&P_NUM_POLIZA='' + row.NUM_POLIZA + '' onclick=app.ViewerQuery.TabRender(this); return false;>'' + value + ''</a>''; }"
            },
            {
                "field": "ABR_RAMO",
                "title": "Ramo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringCapitalizeFormatter"
            },
            {
                "field": "COD_DOCUM",
                "title": "Cédula",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "format": "{TIP_DOCUM} {COD_DOCUM}"
            },
            {
                "field": "NOM_COMPLETO",
                "title": "Contratante",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringCapitalizeEachWordFormatter"
            },
            {
                "field": "FEC_EFEC_POLIZA",
                "title": "Inicio de vigencia",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter"
            },
            {
                "field": "FEC_VCTO_POLIZA",
                "title": "Fin de vigencia",
                "sortable": true,
                "halign": "center",
')||TO_CLOB('                "align": "center",
                "formatter": "app.ui.DateFormatter"
            },
            {
                "title": "Acciones",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "function (value, row, index, field) { return ''<button type=\"button\" name=\"print\" class=\"btn btn-sm btn-white event\" title=\"Permite imprimir la póliza\"><i class=\"fa fa-print\"></i></button>'' + ''<button type=\"button\" name=\"sendemail\" class=\"btn btn-sm btn-white event\" title=\"Permite eviar el certificado por correo\"><i class=\"fa fa-envelope-o\"></i></button>'' ;}",
                "visible": true,
                "events":  true,
                "action_sendemail": "app.ui.ShowSideBar({ title: ''Enviar certificado por correo'', subtitle: ''Póliza #{NUM_POLIZA}'', id: 9000, data: row})"
            }                
        ]
    }
}'),'Tron',2,'|título
|zona|4
 Agente+|lista|name=cod_agt;lookup=Agents
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 301, @_@_)',NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_policy_by_agent_tomador {app.P_COD_CIA} {cod_agt}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (302,1,1,'Detalle de la p??liza - Datos generales','Detalle...',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
    "title": "Datos generales",
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
                "field": "NUM_POLIZA",
                "title": "No. de p??liza",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "COD_MON",
                "title": "Moneda",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "visible": true
            },
            {
                "field": "COD_FRACC_PAGO",
                "title": "Fraccionamiento de pago",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.IntegerFormatter",
                "visible": true
            },
            {
                "field": "FEC_EFEC_POLIZA",
                "title": "Inicio de vigencia",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "FEC_VCTO_POLIZA",
                "title": "Fin de vigencia",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "NOM_COMPLETO",
                "title": "Pagador",
                "sortable": true,
                "halign": "center",
                ')||TO_CLOB('"align": "left",
                "formatter": "app.ui.StringCapitalizeEachWordFormatter",
                "visible": true
            },
            {
                "field": "TXT_MOTIVO_SPTO",
                "title": "Motivo del suplemento",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringCapitalizeFormatter",
                "visible": true
            }
        ]
    }
}'),'Tron',1,NULL,NULL,NULL,'Extend.Policy.js',TO_CLOB('SELECT A30.COD_CIA,
       A30.COD_SECTOR,
       A30.COD_RAMO,
       A30.NUM_POLIZA,
       A30.NUM_SPTO,
       A30.NUM_APLI,
       A30.NUM_SPTO_APLI,
       A30.FEC_VALIDEZ,
       A30.FEC_EMISION,
       A30.FEC_EMISION_SPTO,
       A30.FEC_EFEC_POLIZA,
       A30.FEC_VCTO_POLIZA,
       A30.FEC_EFEC_SPTO,
       A30.FEC_VCTO_SPTO,
       A30.TIP_DURACION,
       A30.NUM_RIESGOS,
       A30.COD_MON,
       A30.COD_FRACC_PAGO,
       A30.CANT_RENOVACIONES,
       A30.NUM_RENOVACIONES,
       A30.TIP_COASEGURO,
       A30.NUM_PRESUPUESTO,
       A30.NUM_POLIZA_ANTERIOR,
       A30.NUM_POLIZA_CLIENTE,
       A30.NUM_CONTRATO,
       A30.NUM_POLIZA_GRUPO,
       A30.NUM_SECU_GRUPO,
       A30.COD_SPTO,
       A30.SUB_COD_SPTO,
       A30.COD_TIP_SPTO,
       G31.NOM_VALOR,
       A30.TXT_MOTIVO_SPTO,
       A30.TIP_DOCUM,
       A30.COD_DOCUM,
       A30.COD_CUADRO_COM,
       A30.COD_AGT,
       A30.PCT_AGT,
       A30.COD_ORG,
       A30.COD_ASESOR,
       A30.COD_NIVEL1,
       A30.COD_NIVEL2,
       A30.COD_NIVEL3,
       A30.COD_COMPENSACION,
       A30.TIP_GESTOR,
       A30.COD_GESTOR,
       A30.MCA_REGULARIZA,
       A30.TIP_REGULARIZA,
       A30.PCT_REGULARIZA,
       A30.COD_INDICE,
       A30.ANIOS_MAX_DURACION,
       A30.MESES_MAX_DURACION,
       A30.DIAS_MAX_DURACION,
       A30.COD_AGT2,
       A30.PCT_AGT2,
       A30.COD_AGT3,
       A30.PCT_AGT3,
       A30.COD_AGT4,
       A30.PCT_AGT4,
       A30.DURACION_PAGO_PRIMA,
       A30.COD_ENVIO,
       A30.COD_EJECUTIVO,
       A30.MCA_TOMADORES_ALT,
       A30.MCA_REASEGURO_MANUAL,
       A30.MCA_PRORRATA,
       A30.MCA_PRIMA_MANUAL,
       A30.MCA_PROVISIONAL,
       A30.FEC_AUTORIZACION,
       A30.MCA_POLIZA_ANULADA,
       A30.MCA_SPTO_ANULADO,
       A30.NUM_SPTO_ANULADO,
       A30.FEC_SPTO_ANULADO,
       A30.MCA_SPTO_TMP,
       A30.MCA_DATOS_MINIMOS,
       A30.MCA_IMPRESION,
       A30.MCA_EXCLUSIVO,
       A30.COD_USR,
       A30.COD_NIVEL3_CAPTURA,
       A30.FEC_ACTU,
       A30.MCA_')||TO_CLOB('REASEGURO_MARCO,
       A30.TIP_POLIZA_TR,
       A30.NUM_POLIZA_SIGUIENTE,
       A30.COD_DST_AGT,
       A30.COD_CUADRO_COA,
       A30.TIP_REA,
       A30.NUM_SPTO_PUBLICO,
       A30.VAL_MCA_INT,
       A30.HORA_DESDE,
       A30.NUM_SUBCONTRATO,
       A30.COD_NEGOCIO,
       A30.NUM_SECU_CTA_TAR,
       V90.NOM_COMPLETO,
       A99.NOM_TERCERO || '' '' || A99.APE1_TERCERO || '' '' || A99.APE2_TERCERO AS "nom_agt"
  FROM A2000030 A30
  LEFT JOIN V1001390 V90
    ON V90.TIP_DOCUM = A30.TIP_DOCUM
   AND V90.COD_DOCUM = A30.COD_DOCUM
 LEFT JOIN G1010031 G31
    ON G31.COD_CAMPO=''TIP_SPTO'' AND G31.COD_RAMO=999  AND G31.COD_VALOR = A30.TIP_SPTO AND G31.COD_IDIOMA=''ES''
 RIGHT JOIN A1001399 A99
    ON A99.COD_CIA = A30.COD_CIA
 RIGHT JOIN A1001332 A32
    ON A99.COD_CIA = A32.COD_CIA
   AND A99.COD_DOCUM = A32.COD_DOCUM
   AND A99.TIP_DOCUM = A32.TIP_DOCUM
   AND A32.COD_AGT = A30.COD_AGT
 WHERE A30.COD_CIA = {app.p_cod_cia}
   AND A30.NUM_POLIZA = {P_NUM_POLIZA:varchar}
   AND A30.NUM_SPTO IN (SELECT MAX (num_spto) FROM a2000030 a20
                          WHERE     a20.cod_cia = A30.cod_cia
                       AND a20.num_poliza = A30.num_poliza
				       AND a20.cod_agt = A30.COD_AGT
                       AND a20.mca_poliza_anulada = ''N''
                       AND a20.mca_spto_anulado = ''N'')
   AND A30.NUM_APLI = 0
   AND A30.NUM_SPTO_APLI = 0
   AND ROWNUM =1'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (302,2,1,'Detalle de la póliza - Terceros','Detalle...',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
    "title": "Terceros",
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
                "field": "TIP_DOCUM",
                "title": "Tipo de docum.",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "COD_DOCUM",
                "title": "Documento",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NOM_COMPLETO",
                "title": "Nombre",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringCapitalizeEachWordFormatter",
                "visible": true
            },
            {
                "field": "NOM_BENEF",
                "title": "Tipo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringCapitalizeFormatter",
                "visible": true
            }
        ]
    }
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Batch_Contract_mcr.pp_lee_a2000060 {app.p_cod_cia} {P_NUM_POLIZA:varchar} {P_NUM_SPTO} {P_NUM_APLI} {P_NUM_SPTO_APLI}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (302,3,1,'Detalle de la póliza - Información del riesgo','Detalle...',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
    "title": "Información del riesgo",
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
                "field": "NOM_CAMPO",
                "title": "Nombre",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "VAL_CAMPO",
                "title": "Valor",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "TXT_CAMPO",
                "title": "Descripción",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            }
        ]
    }
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Batch_Contract_mcr.pp_lee_a2000020 {app.p_cod_cia} {P_NUM_POLIZA:varchar} {P_NUM_SPTO} {P_NUM_APLI} {P_NUM_SPTO_APLI}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (302,4,1,'Detalle de la póliza - Coberturas','Detalle...',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
    "title": "Coberturas",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
        "columns": [
            {
                "field": "NUM_POLIZA",
                "title": "NUM_POLIZA",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": false
            },
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
                "title": "Nombre",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "SUMA_ASEG",
                "title": "Capital",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.DecimalFormatter",
                "visible": true
            },
            {
                "field": "IMP_ANUAL",
                "title": "IMP_ANUAL",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.DecimalFormatter",
                "visible": false
            },
            {
                "field": "IMP_IVA",
                "title": "IMP_IVA",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.DecimalFormatter",
                "visibl')||TO_CLOB('e": false
            },
            {
                "field": "IMP_FRACC",
                "title": "IMP_FRACC",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.DecimalFormatter",
                "visible": false
            },
            {
                "field": "IMP_TOTAL",
                "title": "Prima total",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.DecimalFormatter",
                "visible": true
            },
            {
                "field": "COD_FRANQUICIA",
                "title": "COD_FRANQUICIA",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "visible": false
            },
            {
                "field": "NOM_FRANQUICIA",
                "title": "Deducible",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "TXT_ERROR",
                "title": "TXT_ERROR",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": false
            }
        ]
    }
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Batch_Contract_mcr.pp_lee_a2000040_result {app.p_cod_cia} {P_NUM_POLIZA:varchar} {P_NUM_SPTO} {P_NUM_APLI} {P_NUM_SPTO_APLI}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (302,5,1,'Detalle de la póliza - Plan de pagos','Detalle...',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
  "title": "Plan de pagos",
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
        "field": "FEC_EFEC_RECIBO",
        "title": "Fecha desde",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      },
      {
        "field": "FEC_VCTO_RECIBO",
        "title": "Fecha hasta",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      },
      {
        "field": "FEC_VALOR",
        "title": "Fecha Cobrado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      },
      {
        "field": "TIP_SITUACION",
        "title": "Estado del recibo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "IMP_NETA",
        "title": "Prima neta",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalFormatter",
        "visible": true
      },
      {
        "field": "IMP_IMPTOS",
        "title": "IVA",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalFormatter",
        "visible": true
      },
      {
        "field": "IMP_INTERES",
        "title": "Recargo por fracc.",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalFormatter",
        "visible": true
      },
      {
        "field": "IMP_RECIBO",
        "title": "Importe total",
')||TO_CLOB('        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalFormatter",
        "visible": true
      },
      {
        "field": "IMP_INTERES",
        "title": "IMP_INTERES",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalFormatter",
        "visible": false
      }
    ]
  }
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Batch_Contract_mcr.pp_lee_a2990700_result {app.p_cod_cia} {P_NUM_POLIZA:varchar} {P_NUM_SPTO} {P_NUM_APLI} {P_NUM_SPTO_APLI}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (302,6,1,'Detalle de la póliza - Documentos requeridos','Detalle...',NULL,NULL,NULL,NULL,1,1,77,TIMESTAMP'2021-12-21 10:19:24',TO_CLOB('{
  "title": "Documentos cargados",
  "class": "role-Callcenter-notvisible",
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
        "field": "DESCRIPTION",
        "title": "Tipo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "format": "<button name=''download'' type=''button'' class=''btn btn-sm btn-link event'' title=''Permite descargar el archivo'' style=''font-size: 11px;''><i class=''fa fa-download''></i> {DESCRIPTION}</button>",
        "events": true,
        "action_download": "app.ui.Download(''{FILENAME}'', {ID})"
      },
      {
        "field": "FILENAME",
        "title": "Archivo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "FILESIZE",
        "title": "Peso",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "function (value, row, index, field) { if (value === null || value === 0) return ''''; else return parseInt(value / 1024) + ''kb'';}"
      },
      {
        "field": "UPDATEDATE",
        "title": "Fecha",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
    ]
  }
}'),'Research',1,'|titulo
|zona|12
 Cargar un documento nuevo|Boton|class=btn btn-primary float-right;click=app.ui.ShowModal({ title: @_Cargar de documento@_, subtitle: @_@_, id: 9002, data: { NUM_POLIZA: app.core.URLStringValue(@_P_NUM_POLIZA@_) } })',NULL,NULL,NULL,TO_CLOB('SELECT ID, DOCUMENTTYPE, DESCRIPTION, FILENAME, FILESIZE, UPDATEDATE FROM ATTACHMENTS WHERE COMPANYID={app.companyid} AND ENTITYTYPE=3000 AND ENTITYID={P_NUM_POLIZA}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (302,7,1,'Detalle de la poliza - Certificados por vigencia','Detalle...',NULL,NULL,NULL,NULL,1,1,888,TIMESTAMP'2023-03-31 00:00:00',TO_CLOB('{
    "title": "Detalle de la poliza - Certificados por vigencia",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": false,
        "showPaginationSwitch": false,
        "exportTypes": [
            "csv",
            "excel"
        ],
        "columns": [
            {
                "field": "NRO_REGISTRO",
                "title": "#",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.IntegerFormatter",
                "visible": true
            },
            {
                "field": "NUM_POLIZA",
                "title": "No. P?liza",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": false
            },
            {
                "field": "NUM_RIESGO",
                "title": "No. Riesgo",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "visible": true
            },
            {
                "field": "NUM_SPTO",
                "title": "No. Suplemento",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "visible": true
            },
            {
                "field": "TIP_SPTO",
                "title": "Tipo de Suplemento",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.LookUpListFormatter",
                "lookupList": "[{''code'':''XX'',''desc'':''XX''},{''code'':''RF'',''desc'':''Renovaci?n manual''}]",
                "visible": true
            },
            {
                "field": "FEC_EMISION",
                "title": "Emisi?n",
                "sortable": true')||TO_CLOB(',
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "FEC_EFEC_POLIZA",
                "title": "Inicio de vigencia",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "FEC_VCTO_POLIZA",
                "title": "Fin de vigencia",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "ID_REPORTE",
                "title": "ID_REPORTE",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.DecimalFormatter",
                "visible": false
            },
{
"title": "Acciones",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "",
"visible": false,
"events": true
}
        ]
    }
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_jrp_cuadro_poliza_302_mcr.p_lista_certificado_historico {app.p_cod_cia} {P_NUM_POLIZA:varchar}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (302,8,1,'Detalle de la poliza - Certificado Actual','Detalle...',NULL,NULL,NULL,NULL,1,1,888,TIMESTAMP'2023-03-31 00:00:00',TO_CLOB('{
  "title": "Certificado",
  "table": {
    "pagination": true,
    "search": true,
    "showToggle": false,
    "showRefresh": true,
    "showColumns": false,
    "showExport": false,
    "showPaginationSwitch": false,
    "exportTypes": [
      "csv",
      "excel"
    ],
    "columns": [
      {
        "title": "Acciones",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "function (value, row, index, field) { return ''<span class=\"columnBtn\"><button type=\"button\" name=\"sendemail\" class=\"btn btn-sm btn-white event\" title=\"Permite enviar el certificado por correo\"><i class=\"fa fa-envelope-o\"></i></button>'' + ''</span>'' ;}",
        "visible": true,
        "events": true,
        "action_sendemail": "app.ui.ShowModal({ id: 9000, title: ''Enviar certificado por correo'', width: 60, height: 0, data: row})"
      },
      {
        "field": "NUM_POLIZA",
        "title": "No. P?liza",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "NUM_RIESGO",
        "title": "No. Riesgo",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "visible": true
      },
      {
        "field": "NUM_SPTO",
        "title": "No. Suplemento",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "visible": true
      },
      {
        "field": "TIP_SPTO",
        "title": "Tipo de Suplemento",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.LookUpListFormatter",
        "lookupList": "[{''code'':''XX'',''desc'':''Emisi?n''},{''code'':''RF'',''desc'':''Renovaci?n manual''}]",
        "visible": true
      },
      {
        "field": "FEC_EMISION",
        "title": "Emisi?n",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "a')||TO_CLOB('pp.ui.DateFormatter",
        "visible": true
      },
      {
        "field": "FEC_EFEC_POLIZA",
        "title": "Inicio de vigencia",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      },
      {
        "field": "FEC_VCTO_POLIZA",
        "title": "Fin de vigencia",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      }
    ]
  }
}'),'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT A30.COD_CIA,
       A30.COD_SECTOR,
       A30.COD_RAMO,
       A30.NUM_POLIZA,
       A30.NUM_SPTO,
       A30.NUM_APLI,
       A30.NUM_SPTO_APLI,
       A30.FEC_VALIDEZ,
       A30.FEC_EMISION,
       A30.FEC_EMISION_SPTO,
       A30.FEC_EFEC_POLIZA,
       A30.FEC_VCTO_POLIZA,
       A30.FEC_EFEC_SPTO,
       A30.FEC_VCTO_SPTO,
       A30.TIP_DURACION,
       A30.NUM_RIESGOS NUM_RIESGO,
       A30.COD_MON,
       A30.COD_FRACC_PAGO,
       A30.CANT_RENOVACIONES,
       A30.NUM_RENOVACIONES,
       A30.TIP_COASEGURO,
       A30.NUM_PRESUPUESTO,
       A30.NUM_POLIZA_ANTERIOR,
       A30.NUM_POLIZA_CLIENTE,
       A30.NUM_CONTRATO,
       A30.NUM_POLIZA_GRUPO,
       A30.NUM_SECU_GRUPO,
       A30.COD_SPTO,
       A30.SUB_COD_SPTO,
       A30.COD_TIP_SPTO,
       G31.NOM_VALOR,
       A30.TXT_MOTIVO_SPTO,
       A30.TIP_DOCUM,
       A30.COD_DOCUM,
       A30.COD_CUADRO_COM,
       A30.COD_AGT,
       A30.PCT_AGT,
       A30.COD_ORG,
       A30.COD_ASESOR,
       A30.COD_NIVEL1,
       A30.COD_NIVEL2,
       A30.COD_NIVEL3,
       A30.COD_COMPENSACION,
       A30.TIP_GESTOR,
       A30.COD_GESTOR,
       A30.MCA_REGULARIZA,
       A30.TIP_REGULARIZA,
       A30.PCT_REGULARIZA,
       A30.COD_INDICE,
       A30.ANIOS_MAX_DURACION,
       A30.MESES_MAX_DURACION,
       A30.DIAS_MAX_DURACION,
       A30.COD_AGT2,
       A30.PCT_AGT2,
       A30.COD_AGT3,
       A30.PCT_AGT3,
       A30.COD_AGT4,
       A30.PCT_AGT4,
       A30.DURACION_PAGO_PRIMA,
       A30.COD_ENVIO,
       A30.COD_EJECUTIVO,
       A30.MCA_TOMADORES_ALT,
       A30.MCA_REASEGURO_MANUAL,
       A30.MCA_PRORRATA,
       A30.MCA_PRIMA_MANUAL,
       A30.MCA_PROVISIONAL,
       A30.FEC_AUTORIZACION,
       A30.MCA_POLIZA_ANULADA,
       A30.MCA_SPTO_ANULADO,
       A30.NUM_SPTO_ANULADO,
       A30.FEC_SPTO_ANULADO,
       A30.MCA_SPTO_TMP,
       A30.MCA_DATOS_MINIMOS,
       A30.MCA_IMPRESION,
       A30.MCA_EXCLUSIVO,
       A30.COD_USR,
       A30.COD_NIVEL3_CAPTURA,
       A30.FEC_ACTU,
    ')||TO_CLOB('   A30.MCA_REASEGURO_MARCO,
       A30.TIP_POLIZA_TR,
       A30.NUM_POLIZA_SIGUIENTE,
       A30.COD_DST_AGT,
       A30.COD_CUADRO_COA,
       A30.TIP_REA,
       A30.NUM_SPTO_PUBLICO,
       A30.VAL_MCA_INT,
       A30.HORA_DESDE,
       A30.NUM_SUBCONTRATO,
       A30.COD_NEGOCIO,
       A30.NUM_SECU_CTA_TAR,
       V90.NOM_COMPLETO,
       A99.NOM_TERCERO || '' '' || A99.APE1_TERCERO || '' '' || A99.APE2_TERCERO AS "nom_agt"
  FROM A2000030 A30
  LEFT JOIN V1001390 V90
    ON V90.TIP_DOCUM = A30.TIP_DOCUM
   AND V90.COD_DOCUM = A30.COD_DOCUM
 LEFT JOIN G1010031 G31
    ON G31.COD_CAMPO=''TIP_SPTO'' AND G31.COD_RAMO=999  AND G31.COD_VALOR = A30.TIP_SPTO AND G31.COD_IDIOMA=''ES''
 RIGHT JOIN A1001399 A99
    ON A99.COD_CIA = A30.COD_CIA
 RIGHT JOIN A1001332 A32
    ON A99.COD_CIA = A32.COD_CIA
   AND A99.COD_DOCUM = A32.COD_DOCUM
   AND A99.TIP_DOCUM = A32.TIP_DOCUM
   AND A32.COD_AGT = A30.COD_AGT
 WHERE A30.COD_CIA = {app.p_cod_cia}
   AND A30.NUM_POLIZA = {P_NUM_POLIZA:varchar}
   AND A30.NUM_SPTO IN (SELECT MAX (num_spto) FROM a2000030 a20
                          WHERE     a20.cod_cia = A30.cod_cia
                       AND a20.num_poliza = A30.num_poliza
				      AND a20.cod_agt = A30.COD_AGT
                       AND a20.mca_poliza_anulada = ''N''
                       AND a20.mca_spto_anulado = ''N'')
   AND A30.NUM_APLI = 0
   AND A30.NUM_SPTO_APLI = 0
   AND ROWNUM =1'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (303,1,1,'Asignaciones','Detalle...',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
"title": "Asignaciones",
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
            "field": "NUM_POLIZA",
            "title": "No. de póliza",
            "titleTooltip": "Número de póliza",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "visible": true
        },
        {
            "field": "COD_NIVEL3_AGT",
            "title": "Com.",
            "titleTooltip": "Agencia donde se realiza la venta",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "visible": true
        },
        {
            "field": "COD_RAMO",
            "title": "Cod. ramo",
            "titleTooltip": "Código del ramo al que pertenece la póliza",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "visible": true
        },
        {
            "field": "ABR_RAMO",
            "title": "Nom. ramo",
            "titleTooltip": "Descripción del ramo",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringCapitalizeFormatter",
            "visible": true
        },
        {
            "field": "NUM_RECIBO",
            "title": "Num. recibo",
            "titleTooltip": "Número de recibo",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "visible": true
        },
        {
            "field": "TIP_SITUACION",
            "title": "Situación",
            "titleTooltip": "Situación del recibo. CT=Cobrado, AC=Anulado de cobro",
            "sortable": true,
            "halign": "center",
            "align": "left"')||TO_CLOB(',
            "formatter": "app.ui.StringFormatter",
            "visible": true
        },
        {
            "field": "FEC_MVTO",
            "title": "Fec. Mvto.",
            "titleTooltip": "Fecha del movimiento",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.DateFormatter",
            "visible": true
        },
        {
            "field": "NOM_COMPLETO",
            "title": "Contratante",
            "titleTooltip": "Nombre del contratante de la póliza",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringCapitalizeEachWordFormatter",
            "visible": true
        },
        {
            "field": "IMP_RECIBO",
            "title": "Total recibo",
            "titleTooltip": "Monto de prima total del recibo pagado",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalFormatter",
            "visible": true
        },
        {
            "field": "IMP_MVTO",
            "title": "Importe comisión",
            "titleTooltip": "Monto de la comisión del recibo",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalFormatter",
            "visible": true
        }
    ]
}
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_paid_commissionDet {app.P_COD_CIA} {app.P_COD_AGT} {p_cod_mon} {p_fec_proceso:date}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (303,2,1,'Deducciones','Detalle...',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
    "title": "Deducciones",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
        "columns": [
            {
                "field": "COD_CIA",
                "title": "COD_CIA",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "visible": false
            },
            {
                "field": "COD_AGT",
                "title": "COD_AGT",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.IntegerFormatter",
                "visible": false
            },
            {
                "field": "TIP_DOCUM_AGT",
                "title": "TIP_DOCUM_AGT",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": false
            },
            {
                "field": "COD_DOCUM_AGT",
                "title": "COD_DOCUM_AGT",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": false
            },
            {
                "field": "COD_MON",
                "title": "COD_MON",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "visible": false
            },
            {
                "field": "FEC_PROCESO",
                "title": "FEC_PROCESO",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": false
            },
      ')||TO_CLOB('      {
                "field": "TIP_ANTICIPO",
                "title": "TIP_ANTICIPO",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": false
            },
            {
                "field": "NOM_ANTICIPO",
                "title": "Descripción",
                "titleTooltip": "Descripción del movimiento",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "FEC_MVTO",
                "title": "Fec. Mvto.",
                "titleTooltip": "Fecha del movimiento",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },       
            {
                "field": "IMP_MVTO",
                "title": "Imp. del mvto",
                "titleTooltip": "Importe del movimiento",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.DecimalFormatter",
                "visible": true
            },                 
            {
                "field": "COD_MVTO",
                "title": "COD_MVTO",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": false
            }
        ]
    }
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_paid_commissionDetDeduc {app.P_COD_CIA} {app.P_COD_AGT} {p_cod_mon} {p_fec_proceso:date}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (304,1,1,'Polizas Canceladas por agente','Filtro',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2024-02-23 00:00:00',TO_CLOB('{
    "title": "Polizas canceladas",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
        "columns": [
            {
                "field": "NUM_POLIZA",
                "title": "No. Poliza",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "function (value, row, index, field) { return ''<a href=tabrender?id=302&P_NUM_POLIZA='' + row.NUM_POLIZA + '' onclick=app.ViewerQuery.TabRender(this); return false;>'' + value + ''</a>''; }"
            },
            {
                "field": "ABR_RAMO",
                "title": "Ramo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringCapitalizeFormatter"
            },
            {
                "field": "COD_DOCUM",
                "title": "Cedula",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "format": "{TIP_DOCUM} {COD_DOCUM}"
            },
            {
                "field": "NOM_COMPLETO",
                "title": "Contratante",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringCapitalizeEachWordFormatter"
            },
            {
                "field": "FEC_EFEC_SPTO",
                "title": "Fecha Anulacion",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter"
            }
        ]
    }
}'),'Tron',2,'|titulo
|zona|4
 Agente+|lista|name=cod_agt;lookup=Agents
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 301, @_@_)',NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_policies_cancelled {app.P_COD_CIA} {cod_agt}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (305,1,1,'Polizas de Caución','Consultas MAPFRE - Caución',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 21:49:26',TO_CLOB('{
"title": "Pólizas de Caución",
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
"title": "Acciones",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button type=\"button\" name=\"print\" class=\"btn btn-sm btn-white event\" title=\"Permite imprimir la poliza\"><i class=\"fa fa-print\"></i></button>'' + ''<button type=\"button\" name=\"sendemail\" class=\"btn btn-sm btn-white event\" title=\"Permite enviar el certificado por correo\"><i class=\"fa fa-envelope-o\"></i></button>'' + ''<button type=\"button\" name=\"updatepol\" class=\"btn btn-sm btn-white event\" title=\"Permite realizar variaciones sobre la poliza\"><i class=\"fa fa-pencil\"></i></button>''+''<button type=\"button\" name=\"cancelpol\" class=\"btn btn-sm btn-white event\" title=\"Permite cancelar la p?liza\"><i class=\"fa fa-close\"></i></button>''+''</span>'' ;}",
"visible": true,
"events": true,
"action_sendemail": "app.ui.ShowSideBar({ title: ''Enviar certificado por correo'', subtitle: ''Poliza #{NUM_POLIZA}'', id: 9000, data: row})",
"action_updatepol": "app.ui.ShowSideBar({ isExternal: true, url: ''/Aliados/variaciones/mapfremas'', title: ''Solicitud de variaciones'', width: ''600px'', data: row})",
"action_cancelpol":  "app.ui.ShowSideBar({ title: ''Cancelar la poliza #{NUM_POLIZA}'', id: 9003, data: row})"
},
{
"field": "NUM_POLIZA_GRUPO",
"title": "Poliza Grupo",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NUM_CONTRATO",
"title": "Contrato",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NUM_POLIZA",
"title": "No. Poliza",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "function (value, row, index, field) { return ')||TO_CLOB('''<a href=tabrender?id=302&P_NUM_POLIZA='' + row.NUM_POLIZA + ''&P_NUM_SPTO='' + row.NUM_SPTO +'' onclick=app.ViewerQuery.TabRender(this); return false;>'' + value + ''</a>''; }"
},
{
"field": "ABR_RAMO",
"title": "Ramo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeFormatter"
},
{
"field": "COD_DOCUM",
"title": "Cedula Tomador",
"sortable": true,
"halign": "center",
"align": "left",
"format": "{TIP_DOCUM} {COD_DOCUM}"
},
{
"field": "NOM_TOMADOR",
"title": "Tomador",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeEachWordFormatter"
},
{
"field": "TLF_NUMERO",
"title": "Telefono",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "EMAIL",
"title": "Correo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "IDENTIFICACION",
"title": "Cedula Asegurado",
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
"formatter": "app.ui.StringCapitalizeEachWordFormatter"
},
{
"field": "TLF_NUMERO_ASEG",
"title": "Telefono Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "EMAIL_ASEG",
"title": "Correo Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_ACREEDOR",
"title": "Acreedor",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_RIESGO",
"title": "Riesgo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "FEC_EFEC_POLIZA",
"title": "Inicio de vigencia",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.DateFormatter"
},
{
"field": "FEC_VCTO_POLIZA",
"ti')||TO_CLOB('tle": "Fin de vigencia",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.DateFormatter"
}
]
}
}'),'Tron',1,NULL,NULL,NULL,'Extend.Policy.js',TO_CLOB('SELECT DISTINCT 
    a.cod_cia,
    a.num_poliza,
    a.num_poliza_anterior,
    a.num_poliza_cliente,
    a.num_poliza_grupo,
    a.num_contrato,
    a.num_subcontrato,
    a.fec_efec_poliza,
    a.fec_vcto_poliza,
    a.num_presupuesto,
    b.nom_certificado,
    a.tip_docum,
    a.cod_docum,
    em_k_Mapfre_Query_Contract_mcr.f_search_name_client(a.tip_docum, a.cod_docum) AS nom_tomador,
    em_k_Mapfre_Query_Contract_mcr.f_search_email_client(a.tip_docum, a.cod_docum) AS email,
    em_k_Mapfre_Query_Contract_mcr.f_search_phone_client(a.tip_docum, a.cod_docum) AS tlf_numero,
    a.num_spto,
    a60.tip_docum || '' '' || a60.cod_docum AS identificacion,
    em_k_Mapfre_Query_Contract_mcr.f_search_name_client(a60.tip_docum, a60.cod_docum) AS nom_completo,
    em_k_Mapfre_Query_Contract_mcr.f_search_email_client(a60.tip_docum, a60.cod_docum) AS email_aseg,
    em_k_Mapfre_Query_Contract_mcr.f_search_phone_client(a60.tip_docum, a60.cod_docum) AS tlf_numero_aseg,
    b.nom_riesgo,
    --a1402.nom_fracc_pago,
    a60.tip_benef,
    F_PRIMA_TOTAL_MCR(a.num_poliza) AS prima_total,
    em_k_Mapfre_Query_Contract_mcr.f_search_name_client_tip_benef(a.num_poliza, ''8'') AS nom_acreedor
FROM 
    a2000030 a
    JOIN a2000031 b ON b.cod_cia = a.cod_cia 
                   AND b.num_poliza = a.num_poliza
                   AND b.mca_vigente = ''S''
                   AND b.mca_baja_riesgo = ''N''
                   AND b.num_spto = (
                       SELECT MAX(a31.num_spto)
                       FROM a2000031 a31
                       WHERE a31.cod_cia = b.cod_cia
                         AND a31.num_poliza = b.num_poliza
                         AND a31.mca_vigente = ''S''
                   )
    JOIN a2000060 a60 ON a60.cod_cia = a.cod_cia
                     AND a60.num_poliza = a.num_poliza
                     AND a60.num_riesgo = b.num_riesgo
                     AND a60.mca_baja = ''N''
                     AND a60.mca_vigente =')||TO_CLOB(' ''S''
                     AND a60.tip_benef = 2
    JOIN v1001390 c ON c.tip_docum = a60.tip_docum
                   AND c.cod_docum = a60.cod_docum
    /*JOIN a1001403 a1403 ON a1403.cod_cia = a.cod_cia
                       AND a1403.cod_mon = a.cod_mon
                       AND a1403.cod_ramo = a.cod_ramo
                       AND a1403.cod_fracc_pago = a.cod_fracc_pago
    JOIN a1001402 a1402 ON a1402.cod_cia = a1403.cod_cia
                       AND a1402.cod_fracc_pago = a1403.cod_fracc_pago*/
WHERE 
    a.cod_cia = 1
    AND a.cod_ramo in (280,281)
    AND a.mca_spto_anulado = ''N''
    AND a.mca_poliza_anulada = ''N''
    AND a.mca_provisional = ''N''
    AND a.num_spto = (
        SELECT MAX(a20.num_spto)
        FROM a2000030 a20
        WHERE a20.cod_cia = a.cod_cia
          AND a20.num_poliza = a.num_poliza
          AND a20.mca_spto_anulado = ''N''
    )
ORDER BY 
    a.num_poliza'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (309,1,1,'Detalle del siniestro (Expedientes)','Detalle...',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
"title": "Detalle del siniestro (Expedientes)",
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
        "field": "NUM_POLIZA",
        "title": "No. Póliza",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
    },
    {
        "field": "NUM_RIESGO",
        "title": "No. de riesgo",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.IntegerFormatter",
        "visible": true
    },
    {
        "field": "NOM_RIESGO",
        "title": "Nombre del riesgo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
    },
    {
        "field": "NOM_COMPLETO",
        "title": "Contratante",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "function (value, row, index, field) { return row.COD_DOCUM_TOMADOR + '' '' + value ;}",
        "visible": true
    },
    {
        "field": "NUM_SINI",
        "title": "No. Siniestro",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "visible": true
    },
    {
        "field": "FEC_SINI",
        "title": "Fecha Ocurrencia",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
    },
    {
        "field": "FEC_TERM_SINI",
        "title": "Fec. Terminación sini.",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
    },
    {
        "field": "TIP_EXP",
        "title": "Tipo de expediente",
        "sortable": true,
        "halign": "center",
        "align": "left",
')||TO_CLOB('        "formatter": "app.ui.StringFormatter",
        "visible": true
    },
    {
        "field": "NOM_EXP",
        "title": "Nom. del expediente",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
    },
    {
        "field": "IMP_RESERVA",
        "title": "Imp. Reserva",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalFormatter",
        "visible": true
    },
    {
        "field": "IMP_ESTIMADO",
        "title": "Imp. Estimado",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalFormatter",
        "visible": true
    },
    {
        "field": "IMP_LIQUIDADO",
        "title": "Imp. Liquidado",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalFormatter",
        "visible": true
    },
    {
        "field": "IMP_PAGADO",
        "title": "Imp. Pagado",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalFormatter",
        "visible": true
    }
]
}
}'),'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT a90.num_poliza, a31.num_riesgo, a31.nom_riesgo nom_riesgo, a90.tip_docum_tomador,
       a90.cod_docum_tomador, v90.nom_completo, a10.num_sini, a90.fec_sini,       
       a90.fec_term_sini, a10.tip_exp, g90.nom_exp, nvl(a10.imp_val_inicial,0) IMP_RESERVA,
       nvl(a10.imp_val,0) IMP_ESTIMADO, nvl(a10.imp_liq,0) IMP_LIQUIDADO, nvl(a10.imp_pag,0) IMP_PAGADO
  FROM a7000900 a90, a7001000 a10, a2000031 a31, G7000090 g90, v1001390 v90
 WHERE a90.cod_cia     = {app.p_cod_cia}
   AND a90.num_sini    = {num_sini}
   AND a10.cod_cia     = a90.cod_cia
   AND a10.num_sini    = a90.num_sini
   AND a10.tip_est_exp = {tip_est_exp:varchar}
   AND a31.cod_cia     = a90.cod_cia
   AND a31.num_poliza  = a90.num_poliza
   AND a31.num_riesgo  = a90.num_riesgo
   AND a31.num_spto    = a90.num_spto
   AND g90.cod_cia     = a10.cod_cia
   AND g90.tip_exp     = a10.tip_exp
   AND g90.mca_inh     = ''N''
   AND v90.cod_cia     = a90.cod_cia
   AND v90.tip_docum   = a90.tip_docum_tomador
   AND v90.cod_docum   = a90.cod_docum_tomador
   AND v90.cod_act_tercero = 1
 ORDER BY fec_sini, num_poliza, tip_exp'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (310,1,1,'Pólizas emitidas','Mi cuenta - Agente conectado',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-01-04 21:35:45',TO_CLOB('{
    "Ondemand" : true,
    "title": "@Title@",
    "table": null,
    "chart": {
        "type": "area",
        "series": "YEAR",
        "labels": "MONTH",
        "values": "COUNT",
        "normalize": "Months by years",
        "options": {
            "chart": {
                "width": "100%",
                "height": 380,
                "type": null,
                "dropShadow": {
                    "enabled": true,
                    "color": "#000",
                    "top": 18,
                    "left": 7,
                    "blur": 10,
                    "opacity": 0.2
                },
                "toolbar": {
                    "show": true,
                    "offsetX": 0,
                    "offsetY": 0,
                    "tools": {
                        "download": true,
                        "selection": false,
                        "zoom": false,
                        "zoomin": false,
                        "zoomout": false,
                        "pan": false,
                        "reset": false,
                        "customIcons": []
                    },
                    "autoSelected": "zoom"
                }
            },
            "dataLabels": {
                "enabled": true
            },
            "legend": {
                "position": "top",
                "horizontalAlign": "left"
            },
            "xaxis": {
                "categories": "categories",
                "title": {
                    "text": "Mes"
                }
            },
            "yaxis": {
                "title": {
                    "text": "Cantidad de pólizas emitidas"
                }
            }
        }
    }
}'),'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT EXTRACT (MONTH FROM FEC_EMISION_SPTO) Month,
       EXTRACT (YEAR FROM FEC_EMISION_SPTO) Year,
       count(*) Count
FROM a2000030 a          
WHERE a.cod_cia           = {app.P_COD_CIA} 
 AND a.cod_agt            = {app.P_COD_AGT}         
 AND a.mca_spto_anulado   = ''N''
 AND a.mca_poliza_anulada = ''N''
 AND a.tip_spto = ''XX''                  
 AND a.num_spto  in (select max(num_spto) 
                       from a2000030 a20
                      where a20.cod_cia  = a.cod_cia   
                        and a20.num_poliza = a.num_poliza
                        AND a20.mca_spto_anulado = ''N'')                        
group by EXTRACT (YEAR FROM FEC_EMISION_SPTO), EXTRACT (MONTH FROM a.FEC_EMISION_SPTO)
order by EXTRACT (YEAR FROM FEC_EMISION_SPTO), EXTRACT (MONTH FROM a.FEC_EMISION_SPTO)'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (310,2,1,'Recibos pendientes','Mi cuenta - Agente conectado',NULL,NULL,NULL,NULL,1,1,2025,TIMESTAMP'2025-01-15 00:00:00',TO_CLOB('{
"title": "Recibos pendientes",
"maintitle": "Mi cuenta",
"table": {
	"pagination": true,
	"search": true,
	"showToggle": false,
	"showRefresh": true,
	"showColumns": false,
	"showExport": true,
	"showPaginationSwitch": false,
	"exportTypes": ["csv", "excel"],
	"detailId": 311,
	"detailParameters": "tip_docum=TIP_DOCUM:cod_docum=COD_DOCUM",
	"columns": [
		{
			"field": "NUM_POLIZA",
			"title": "No. Poliza",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringFormatter"
		},
		{
			"field": "NOM_COMPLETO",
			"title": "Contratante",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringCapitalizeFormatter"
		},
		{
			"field": "TIP_GESTOR_DESC",
			"title": "Gestor",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringFormatter"
		},
		{
			"field": "NUM_TARJETA",
			"title": "Tarjeta",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringFormatter"
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
			"field": "NUM_RECIBO",
			"title": "No. Recibo",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringFormatter"
		},
		{
			"field": "IMP_RECIBO",
			"title": "Monto",
			"sortable": true,
			"halign": "center",
			"align": "right",
			"formatter": "app.ui.CurrencyAmountFormatter"
		},
		{
			"field": "IMP_COMIS",
			"title": "Comision",
			"sortable": true,
			"halign": "center",
			"align": "right",
			"formatter": "app.ui.CurrencyAmountFormatter"
		},
		{
			"field": "FEC_VCTO_RECIBO",
			"title": "Vencimiento",
			"sortable": true,
			"halign": "center",
			"align": "center",
			"formatter": "app.ui.DateFormatter"
		},
		{
			"field": "TIP_DOCUM",
			')||TO_CLOB('"title": "Tipo de cedula",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringFormatter"
		},
		{
			"field": "COD_DOCUM",
			"title": "Cedula",
			"sortable": true,
			"halign": "center",
			"align": "left",
			"formatter": "app.ui.StringFormatter"
		},
		{
			"title": "Acciones",
			"sortable": true,
			"halign": "center",
			"align": "center",
	  "formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button name=\"printr\" type=\"button\"class=\"btn btn-sm btn-white event\" title=\"Permite imprimir el recibo\"><i class=\"fa fa-print\"></i></button><button type=\"button\" name=\"payment\" class=\"btn btn-sm btn-white d-none role-Pago-visible event\" title=\"Permite pagar el recibo actual\"><i class=\"fa fa-shopping-cart\"></i></button></span>'' ;}",
			"events":  true,
			"action_payment": "app.core.LoadScriptFile(''Payment.js'').then(d => {app.Payment.Recibo(row, 310, 2)})"
		}
	]
}
}'),'Tron',1,NULL,NULL,NULL,'Extend.js',TO_CLOB('SELECT   a.num_poliza, a.fec_efec_poliza, a.fec_vcto_poliza, a.tip_docum, a.cod_docum, 1 num_spto,
         a.cod_agt, d.NOM_COMPLETO, em_k_Mapfre_Query_Contract_mcr.f_obtener_total_recibo(a.cod_cia,c.num_recibo) imp_recibo, em_k_Mapfre_Query_Contract_mcr.f_obtener_total_comision(a.cod_cia,c.num_recibo)  imp_comis,
         a.tip_gestor, em_k_Mapfre_Query_Contract_mcr.f_obtener_num_tarjeta(a.cod_cia, a.num_poliza) num_tarjeta, c.fec_efec_recibo fec_vcto_recibo, c.tip_situacion, c.num_recibo, c.fec_valor,a.tip_docum || ''-'' || a.cod_docum key, d.NOM_COMPLETO NOM_COMPLETO2,
         DECODE(c.tip_situacion, ''RE'', ''REMESADO'', ''EP'', ''PENDIENTE'') tip_situacion_desc,
         DECODE(a.tip_gestor, ''AG'', ''VENTANILLA'', ''BA'', ''CUENTA'', ''TA'', ''TARJETA'') tip_gestor_desc,
         a1331.tlf_numero, a1331.tlf_numero_com, a1331.fax_numero, a1331.fax_numero_com,
         nvl(upper(a1331.email),''***'') email, nom_domicilio1, nom_domicilio2, nom_domicilio3, a400.cod_mon_iso nom_mon
    FROM a2000030 a,
         a2990700 c,
         v1001390 d,
         a1001331 a1331,
         a1000400 a400
   WHERE a.cod_cia  = {app.P_COD_CIA}
     AND a.cod_agt  = {app.P_COD_AGT}
     AND a.cod_ramo not in (230)
     AND a.mca_spto_anulado = ''N''
     AND a.mca_poliza_anulada = ''N''
     AND a.mca_provisional = ''N''
     AND a.num_spto  in (select num_spto--max(num_spto)
                               from a2990700 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza
                                and a20.tip_situacion = ''EP'')
     AND a.cod_cia   = d.cod_cia
     AND a.tip_docum = d.tip_docum
     AND a.cod_docum = d.cod_docum
     AND d.COD_ACT_TERCERO = 1
     --
     AND a1331.tip_docum = d.tip_DOCUM
     AND a1331.cod_docum = d.COD_DOCUM
     --
     AND c.cod_mon = a400.cod_mon
     --
     AND c.cod_cia  = a.cod_cia
     AND c.num_spto  = a.num_spto
     AND c.num_apli   = a.num_apli
')||TO_CLOB('     AND c.num_poliza  = a.num_poliza
     AND c.num_spto_apli = a.num_spto_apli
     AND trunc(c.fec_efec_recibo) <= trunc(sysdate) + 365
     AND c.tip_situacion  in (''EP'')
     AND c.num_recibo > 0
     and c.num_recibo = (select min(t.num_recibo)
                            from a2990700 t
                            where cod_cia = 1
                            and t.num_poliza = a.num_poliza
                            and t.num_spto = a.num_spto
                            and t.num_apli = a.num_apli
                            and t.num_spto_apli = a.num_spto_apli
                            and t.tip_situacion = ''EP'')
     GROUP BY a.cod_cia,            a.num_poliza,       a.num_poliza_anterior,
         a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,
         a.num_subcontrato,    a.fec_efec_poliza,  a.fec_vcto_poliza,
         a.num_presupuesto,    a.tip_docum,        a.cod_docum,
         1,           a.num_apli,         a.num_spto_apli,
         a.cod_ramo,           a.cod_agt,
         substr(d.NOM_COMPLETO, 0, 8) ,
         a.tip_gestor,
         a1331.num_tarjeta,
         c.fec_efec_recibo ,
         c.tip_situacion,
         c.num_recibo,
         c.fec_valor,
         a.tip_docum || ''-'' || a.cod_docum,
         d.NOM_COMPLETO,
         c.fec_efec_recibo ,
         c.fec_vcto_recibo ,
         DECODE(c.tip_situacion,
                        ''RE'', ''REMESADO'',
                        ''EP'', ''PENDIENTE'') ,
         DECODE(a.tip_gestor,
                        ''AG'', ''VENTANILLA'',
                        ''BA'', ''CUENTA'',
                        ''TA'', ''TARJETA'') ,
         a1331.tlf_numero,
         a1331.tlf_numero_com,
         a1331.fax_numero,
         a1331.fax_numero_com,
         nvl(upper(a1331.email),''***'') ,
         nom_domicilio1,
         nom_domicilio2,
         nom_domicilio3,
         a400.cod_mon_iso
   ORDER BY c.fec_efec_recibo'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (310,3,1,'Comisiones pagadas','Mi cuenta - Agente conectado',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
    "title": "Comisiones pagadas",
    "class": "d-none role-Intermediario_admi-visible",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
        "columns": [
            {
                "field": "FEC_PROCESO",
                "title": "Fecha de pago",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "NOM_MON",
                "title": "Moneda",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "visible": true,
                "formatter": "function (value, row, index, field) { return ''<a href=viewer?ViewType=true&id=303&p_cod_mon='' + row.COD_MON + '':p_fec_proceso='' + moment(row.FEC_PROCESO).format(''YYYY-MM-DD'') + '' onclick=app.ViewerQuery.TabRender(this); return false;>'' + value + ''</a>''; }"
            },
            {
                "field": "IMP_COMIS",
                "title": "Asignaciones",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.DecimalFormatter",
                "visible": true
            },
            {
                "field": "IMP_DEDUC",
                "title": "Deducciones",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.DecimalFormatter",
                "visible": true
            },
            {
                "field": "IMP_PAGADO",
                "title": "Pagado",
                "sortable": true,
                "halign": "center",
                "align": "right",
         ')||TO_CLOB('       "formatter": "app.ui.DecimalFormatter",
                "visible": true
            }
        ]
    }
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_paid_commission {app.P_COD_CIA} {app.P_COD_AGT}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (310,4,1,'Comisiones estimadas por pagar','Mi cuenta - Agente conectado',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
    "title": "Comisiones estimadas por pagar",
    "class": "d-none role-Intermediario_admi-visible",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
"detailId": 316,
"detailParameters": "p_cod_mon=COD_MON",        
        "columns": [
            {
                "field": "COD_CIA",
                "title": "COD_CIA",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "visible": false
            },
            {
                "field": "COD_AGT",
                "title": "COD_AGT",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.IntegerFormatter",
                "visible": false
            },
            {
                "field": "TIP_DOCUM_AGT",
                "title": "TIP_DOCUM_AGT",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": false
            },
            {
                "field": "COD_DOCUM_AGT",
                "title": "COD_DOCUM_AGT",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": false
            },
            {
                "field": "COD_MON",
                "title": "COD_MON",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "visible": false
            },
            {
                "field": "NOM_MON",
                "title": "Moneda",
                "sortable": true,
                "halign": "center",
           ')||TO_CLOB('     "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "IMP_RECIBO",
                "title": "IMP_RECIBO",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.DecimalFormatter",
                "visible": false
            },
            {
                "field": "IMP_MVTO",
                "title": "Comisión",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.DecimalFormatter",
                "visible": true
            },
            {
                "field": "KEY",
                "title": "KEY",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": false
            }
        ]
    }
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_pending_commission {app.P_COD_CIA} {app.P_COD_AGT}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (311,1,1,'Información del cliente','Detalle...',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
    "title": "Información del cliente",
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
                "field": "COD_DOCUM",
                "title": "Cod. Documento",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "format": "{TIP_DOCUM} {COD_DOCUM}",
                "visible": true
            },
            {
                "field": "NOM_COMPLETO",
                "title": "Nombre",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringCapitalizeEachWordFormatter",
                "visible": true
            },
            {
                "field": "TLF_NUMERO",
                "title": "Telf. 1",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "TLF_NUMERO_COM",
                "title": "Telf. 2",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "FAX_NUMERO",
                "title": "Fax 1",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "FAX_NUMERO_COM",
                "title": "Fax 2",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": ')||TO_CLOB('"app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "EMAIL",
                "title": "Email",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NOM_DOMICILIO1",
                "title": "Dirección 1",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NOM_DOMICILIO2",
                "title": "Dirección 2",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NOM_DOMICILIO3",
                "title": "Dirección 3",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            }
        ]
    }
}'),'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT a1331.cod_docum, a1331.tip_docum, v1390.nom_completo, a1331.tlf_numero, a1331.tlf_numero_com, a1331.fax_numero, a1331.fax_numero_com, NVL (a1331.email, ''***'') email, NOM_DOMICILIO1, noM_DOMICILIO2, noM_DOMICILIO3, a1331.cod_docum || ''-'' || a1331.tip_docum key
  FROM a1001331 a1331
 INNER JOIN v1001390 v1390
         ON a1331.tip_docum = v1390.tip_DOCUM AND a1331.cod_docum = v1390.COD_DOCUM
 WHERE v1390.tip_docum = {tip_docum:varchar} AND v1390.cod_docum = {cod_docum:varchar}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (316,1,1,'Asignaciones','Detalle...',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
"title": "Asignaciones",
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
        "field": "COD_CIA",
        "title": "COD_CIA",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "visible": false
    },
    {
        "field": "COD_AGT",
        "title": "COD_AGT",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.IntegerFormatter",
        "visible": false
    },
    {
        "field": "NUM_POLIZA",
        "title": "No. de póliza",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
    },
    {
        "field": "COD_NIVEL3",
        "title": "Com.",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "visible": true
    },
    {
        "field": "COD_RAMO",
        "title": "Cod. ramo",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "visible": true
    },
    {
        "field": "ABR_RAMO",
        "title": "Nom. ramo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringCapitalizeFormatter",
        "visible": true
    },
    {
        "field": "NUM_RECIBO",
        "title": "Núm. recibo",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "visible": true
    },
    {
        "field": "TIP_SITUACION",
        "title": "St",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
    },
    {
        "field": "FEC_MVTO",
        "title": "Fec. mvto.",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
')||TO_CLOB('        "visible": true
    },
    {
        "field": "NOM_COMPLETO",
        "title": "Contratante",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter",
        "visible": true
    },
    {
        "field": "IMP_RECIBO",
        "title": "Total recibo",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalFormatter",
        "visible": true
    },
    {
        "field": "IMP_MVTO",
        "title": "Importe comisión",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalFormatter",
        "visible": true
    }
]
}
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_pending_commissionDet {app.P_COD_CIA} {app.P_COD_AGT} {p_cod_mon}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (317,1,1,'Recibos pendientes de cobro','Para el agente conectado',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'2021-06-15 14:14:20',TO_CLOB('{
"title": "Recibos pendientes de cobro",
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
      "field": "NUM_POLIZA",
      "title": "No. Póliza",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "NOM_COMPLETO2",
      "title": "Contratante",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "NUM_RECIBO",
      "title": "Recibo",
      "sortable": true,
      "halign": "center",
      "align": "center"
   },
   {
      "field": "TIP_GESTOR_DESC",
      "title": "Gestor",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "TIP_SITUACION_DESC",
      "title": "Estado",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "NOM_MON",
      "title": "Moneda",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "IMP_RECIBO",
      "title": "Monto",
      "sortable": true,
      "halign": "center",
      "align": "right",
      "formatter": "app.ui.DecimalFormatter"
   },
   {
      "field": "IMP_COMIS",
      "title": "Comisión",
      "sortable": true,
      "halign": "center",
      "align": "right",
      "formatter": "app.ui.DecimalFormatter"
   },
   {
      "field": "FEC_VCTO_RECIBO",
      "title": "Fecha de Vencimiento",
      "sortable": true,
      "halign": "center",
      "align": "center",
      "formatter": "app.ui.DateFormatter"
   },
   {
      "field": "EMAIL",
      "title": "Email",
      "sortable"')||TO_CLOB(': true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "TLF_NUMERO",
      "title": "Telf. 1",
      "titleTooltip": "Número de teléfono 1",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "TLF_NUMERO_COM",
      "title": "Telf. 2",
      "titleTooltip": "Número de teléfono 2",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "NOM_DOMICILIO1",
      "title": "Dirección",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "format": "{NOM_DOMICILIO1} {NOM_DOMICILIO2} {NOM_DOMICILIO3}"
   }                 
]
}
}'),'Tron',2,'|título
|zona|4
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 11, @_@_)',NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_pending_receipts {app.P_COD_CIA} {app.P_COD_AGT} {desde:date} {hasta:date}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (318,1,1,'Recibos cobrados','Para el agente conectado',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'2021-06-15 14:14:20',TO_CLOB('{
  "title": "Recibos cobrados",
  "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
    "columns": [
      {
        "field": "NUM_POLIZA",
        "title": "No. p?liza",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "NOM_COMPLETO",
        "title": "Contratante",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "NUM_RECIBO",
        "title": "Recibo",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "visible": true
      },
      {
        "field": "FEC_EFEC_RECIBO",
        "title": "Inicio vig. recibo",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      },
      {
        "field": "FEC_VCTO_RECIBO",
        "title": "Fin vig. recibo",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      },
      {
        "field": "COD_MON_ISO",
        "title": "Moneda",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "IMP_RECIBO",
        "title": "Monto",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalFormatter",
        "visible": true
      },
      {
        "field": "FEC_SITUACION",
        "title": "Fecha de pago",
        "sortable": true,
        "hali')||TO_CLOB('gn": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      },
            {
                "title": "Acciones",
                "sortable": true,
                "halign": "center",
                "align": "center",
          "formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button name=\"printr\" type=\"button\"class=\"btn btn-sm btn-white event\" title=\"Permite imprimir el recibo\"><i class=\"fa fa-print\"></i></button></span>'' ;}",
                "events":  true
            }
    ]
  }
}'),'Tron',2,'|titulo
|zona|4
 Mes+|lista|values=1->Enero,2->Febrero,3->Marzo,4->Abril,5->Mayo,6->Junio,7->Julio,8->Agosto,9->Septiembre,10->Octubre,11->Noviembre,12->Diciembre;default=today.month
 A?o+|entero(4)|name=anio;default=today.year
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 318, @_@_)',NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_premium_collection {app.P_COD_CIA} {app.P_COD_AGT} {mes} {anio}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (320,1,1,'Cotizaciones','Para el agente conectado',NULL,NULL,NULL,NULL,1,1,10509,TIMESTAMP'2022-05-31 00:00:00',TO_CLOB('{
    "title": "Cotizaciones",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
        "detailId": 321,
        "detailParameters": "P_NUM_POLIZA=NUM_PRESUPUESTO",
        "columns": [
               {
                "field": "NOM_RAMO",
                "title": "Ramo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "NUM_PRESUPUESTO",
                "title": "No. Presupuesto",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.Extend.EmisionFormatter"
            },
            {
                "field": "FEC_ACTU",
                "title": "Fecha",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateAndTimeFormatter"
            },
            {
                "field": "DETALLE",
                "title": "Detalle",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "FRACCIONAMIENTO DE PAGO",
                "title": "Frecuencia de pago",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringCapitalizeFormatter"
            }
        ]
    }
 }'),'Tron',1,NULL,NULL,NULL,'Extend.js',TO_CLOB('SELECT p30.cod_ramo, a1800.NOM_RAMO, p30.num_poliza "NUM_PRESUPUESTO", p30.fec_actu,
  LISTAGG(p20.txt_campo, '' - '') WITHIN GROUP (ORDER BY p20.num_secu) "DETALLE" , a1402.nom_fracc_pago "FRACCIONAMIENTO DE PAGO",
  CASE
  WHEN SYSDATE-p30.fec_actu<30 THEN ''Pendiente''
  ELSE ''Vencido''
END AS Vigencia
  FROM P2000030 p30
  LEFT JOIN  p2000020 p20 ON  p30.num_poliza = p20.num_poliza  and p30.cod_cia = p20.cod_cia  and p30.num_spto = p20.num_spto  and p30.num_apli = p20.num_apli  and p30.num_spto_apli = p20.num_spto_apli  and p30.cod_ramo = p20.cod_ramo
  and p20.cod_campo in (''COD_MARCA'',''COD_MODELO'',''ANIO_SUB_MODELO'',''COD_TIP_VEHI'',''COD_PLAN_AUTO'',''IMP_VR'',''DED_AUTO_CYV'', ''TIP_PLAN'',''TIP_VIAJE'',''DES_DESTINO'',''IMP_MONTO_ORI'',''NUM_PRESTAMO'',''FEC_NACIMIENT'',''NUM_PISOS_EDIF'', ''ANO_CONST'',''TXT_CRED_ESTUD'',''FEC_NACIMIENTO'')
  LEFT JOIN a1001403 a1403 ON p30.cod_cia = a1403.cod_cia  and p30.cod_mon = a1403.cod_mon  and p30.cod_ramo = a1403.cod_ramo AND p30.cod_fracc_pago = a1403.cod_fracc_pago
  LEFT JOIN a1001402 a1402 ON   a1403.cod_cia = a1402.cod_cia  and a1403.cod_fracc_pago = a1402.cod_fracc_pago
  LEFT JOIN a1001800 a1800 ON a1800.COD_CIA=p30.COD_CIA AND a1800.COD_RAMO = p30.COD_RAMO
  WHERE p30.fec_efec_poliza >= SYSDATE-{const.30}
  and p30.cod_ramo in (194, 201, 202, 302, 401, 441,303)
  and p30.tip_spto = ''XX''
  and p30.num_poliza  not in  (
                               select a.num_presupuesto
                               from a2000030 a, p2000030 p
                               where a.num_presupuesto = p.num_poliza
                               and a.fec_efec_poliza>= SYSDATE-{const.30}
                               and p30.cod_agt = {app.P_COD_AGT}
                               )
  and p30.cod_agt = {app.P_COD_AGT}
  group by p30.cod_ramo, a1800.NOM_RAMO, p30.num_poliza, p30.fec_actu,  a1402.nom_fracc_pago
  order by p30.fec_actu desc, p30.num_poliza,  a1402.nom_fracc_pago'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (321,1,1,'Detalle de la p?liza - Documentos requeridos','Detalle...',NULL,NULL,NULL,NULL,1,1,77,TIMESTAMP'2021-12-21 10:19:24',TO_CLOB('{
  "title": "Documentos asociados al presupuesto",
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
        "field": "DESCRIPTION",
        "title": "Tipo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "format": "<button name=''download'' type=''button'' class=''btn btn-sm btn-link event'' title=''Permite descargar el archivo'' style=''font-size: 11px;''><i class=''fa fa-download''></i> {DESCRIPTION}</button>",
        "events": true,
        "action_download": "app.ui.Download(''{FILENAME}'', {ID})"
      },
      {
        "field": "FILENAME",
        "title": "Archivo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "FILESIZE",
        "title": "Tama?o",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "function (value, row, index, field) { if (value === null || value === 0) return ''''; else return parseInt(value / 1024) + ''kb'';}"
      }
    ]
  }
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT ID, DOCUMENTTYPE, DESCRIPTION, FILENAME, FILESIZE
 FROM ATTACHMENTS
WHERE COMPANYID={app.companyid} AND ENTITYTYPE=3000 AND ENTITYID={P_NUM_POLIZA}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (322,1,1,'Cotizaciones por agente','Cotizaciones por agente',NULL,NULL,NULL,NULL,1,1,10509,TIMESTAMP'2022-05-31 00:00:00',TO_CLOB('{
    "title": "Cotizaciones por agente",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
        "detailId": 321,
        "detailParameters": "num_poliza=NUM_POLIZA",
        "columns": [
               {
                "field": "NOM_RAMO",
                "title": "Ramo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "NUM_PRESUPUESTO",
                "title": "No. Presupuesto",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.Extend.EmisionFormatter"
            },
            {
                "field": "FEC_ACTU",
                "title": "Fecha",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateAndTimeFormatter"
            },
            {
                "field": "DETALLE",
                "title": "Detalle",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "FRACCIONAMIENTO DE PAGO",
                "title": "Frecuencia de pago",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringCapitalizeFormatter"
            }
        ]
    }
 }'),'Tron',1,'|título
|zona|4
 Agente+|lista|name=cod_agt;lookup=Agents
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 402, @_@_)',NULL,NULL,'Extend.js',TO_CLOB('SELECT p30.cod_ramo, a1800.NOM_RAMO, p30.num_poliza "NUM_PRESUPUESTO",  p30.fec_actu,
  LISTAGG(p20.txt_campo, '' - '') WITHIN GROUP (ORDER BY p20.num_secu) "DETALLE" , a1402.nom_fracc_pago "FRACCIONAMIENTO DE PAGO",
  CASE
  WHEN SYSDATE-p30.fec_actu<30 THEN ''Pendiente''
  ELSE ''Vencido''
END AS Vigencia
  FROM P2000030 p30
  LEFT JOIN  p2000020 p20 ON  p30.num_poliza = p20.num_poliza  and p30.cod_cia = p20.cod_cia  and p30.num_spto = p20.num_spto  and p30.num_apli = p20.num_apli  and p30.num_spto_apli = p20.num_spto_apli  and p30.cod_ramo = p20.cod_ramo
  and p20.cod_campo in (''COD_MARCA'',''COD_MODELO'',''ANIO_SUB_MODELO'',''COD_TIP_VEHI'',''COD_PLAN_AUTO'',''IMP_VR'',''DED_AUTO_CYV'', ''TIP_PLAN'',''TIP_VIAJE'',''DES_DESTINO'',''IMP_MONTO_ORI'',''NUM_PRESTAMO'',''FEC_NACIMIENTO'')
  LEFT JOIN a1001403 a1403 ON p30.cod_cia = a1403.cod_cia  and p30.cod_mon = a1403.cod_mon  and p30.cod_ramo = a1403.cod_ramo AND p30.cod_fracc_pago = a1403.cod_fracc_pago
  LEFT JOIN a1001402 a1402 ON   a1403.cod_cia = a1402.cod_cia  and a1403.cod_fracc_pago = a1402.cod_fracc_pago
  LEFT JOIN a1001800 a1800 ON a1800.COD_CIA=p30.COD_CIA AND a1800.COD_RAMO = p30.COD_RAMO
  WHERE p30.fec_efec_poliza >= SYSDATE-{const.30}
  and p30.cod_ramo in ( 302, 401, 441)
  and p30.tip_spto = ''XX''
  and p30.num_poliza  not in  (
                               select a.num_presupuesto
                               from a2000030 a, p2000030 p
                               where a.num_presupuesto = p.num_poliza
                               and a.fec_efec_poliza>= SYSDATE-{const.30}
                               and p30.cod_agt = {cod_agt}
                               )
  and p30.cod_agt = {cod_agt}
  group by p30.cod_ramo, a1800.NOM_RAMO, p30.num_poliza, p30.fec_actu,  a1402.nom_fracc_pago
  order by p30.fec_actu desc, p30.num_poliza,  a1402.nom_fracc_pago'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (333,1,1,'Presupuestos pendientes de emitir','Presupuestos pendientes de emitir por agente',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-07-10 19:57:22',TO_CLOB('{
   "title": "Presupuestos pendientes de emitir",
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
        "detailId": 321,
        "detailParameters": "P_NUM_POLIZA=PROPOSALID",
      "columns": [
         {
            "field": "ISSUEDATE",
            "title": "Creacion",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.DateAndTimeFormatter"
         },
         {
            "field": "PROPOSALID",
            "title": "Presupuesto",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "function (value, row, index, field){ var ramo = row.PROPOSALID.substring(0, 3); var producto = ''''; if(ramo == 302){producto=''mapfremas'';} if(ramo == 201){producto=''hogartotal'';} if(ramo == 202){producto=''multirriesgo'';} if(ramo == 401){producto=''SaldoDeudor'';} return row.STATUS===33?''<a href='' + app.setting.basepath + ''emision/''+ producto + ''?mode=continue&presupuesto='' + row.PROPOSALID + ''>'' + value + ''</a>'': ''<span>''+ value + ''</span>'';}"
         },
         {
            "field": "STATUSDESC",
            "title": "Estado",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "function (value, row, index, field) { return ''<span class=@_label '' + (row.STATUS===33?''label-primary'': '' '') + ''@_>'' + value + ''</span>'';}"
         },
         {
            "field": "INSUREDID",
            "visible": false
         },
         {
            "field": "INSUREDIDCLEAR",
            "visible": false
         },
         {
            "field": "INSUREDNAME",
            "title": "Asegurado",
            "sortable": ')||TO_CLOB('true,
            "halign": "center",
            "align": "left",
            "format": "{INSUREDID} {INSUREDNAME}"
         },
         {
            "field": "SUMMARY",
            "title": "Detalles",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter"
         },
         {
            "title": "Acciones",
            "titleTooltip": "Acciones disponibles para un presupuesto",
            "sortable": false,
            "halign": "left",
            "align": "left",
            "formatter": "function (value, row, index, field) { var producto = ''mapfremas''; var ramo = row.PROPOSALID.substring(0, 3); if(ramo == 302){producto=''mapfremas'';}if(ramo == 201){producto=''hogartotal'';} if(ramo == 202){producto=''multirriesgo'';} if(ramo == 401){producto=''SaldoDeudor'';} return (row.STATUS===33?''<a class=@_btn btn-sm btn-outline btn-primary@_ href='' + app.setting.basepath + ''emision/''+ producto + ''?mode=continue&presupuesto='' + row.PROPOSALID + ''>Emitir</a>'': '''') +'' '' +  (row.STATUS === 4 || row.STATUS===31 || row.STATUS===32 || row.SIGNINGTYPE===''M''?''<button type=\"button\" name=\"enviarsolicitud\" class=\"btn btn-sm btn-outline btn-warning event\">Reenvia solicitud</button>'': '''');}",
            "events": true,
            "action_enviarsolicitud": "app.ui.ShowSideBar({ title: ''Enviar solicitud'', subtitle: ''Presupuesto #{PROPOSALID}'', id: 9001, data: row})"
         }
      ]
   }
   }'),'Research',1,NULL,NULL,NULL,'Extend.js',TO_CLOB('SELECT ID, PROPOSALID, INSUREDID, REPLACE(INSUREDID, ''-'', '''') INSUREDIDCLEAR, INSUREDNAME, SUMMARY, ISSUEDATE, SIGNINGREQUESTID, STATUS, LKS.DESCRIPTION STATUSDESC, SigningType, PrimaryEmailAddress
  FROM POLICYPROPOSAL
  LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 2050 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE = POLICYPROPOSAL.STATUS
 WHERE POLICYPROPOSAL.COMPANYID={app.companyid} AND AGENTCODE={app.agentcode} AND STATUS <> 10 ORDER BY ISSUEDATE DESC, POLICYPROPOSAL.UPDATEDATE DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (360,1,1,'Polizas activas','Polizas activas version 2',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 21:49:26',TO_CLOB('{
"title": "Polizas activas",
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
"title": "Acciones",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "function (value, row, index, field) { return ''<span class=columnBtn>''+''<button type=\"button\" name=\"cancelpol\" class=\"btn btn-sm btn-white event\" title=\"Permite cancelar la p?liza\"><i class=\"fa fa-close\"></i></button>''+''</span>'' ;}",
"visible": true,
"events": true,
"action_cancelpol": "app.ui.Redirect(''../viewer/Form?id=AnularPoliza&poliza={NUM_POLIZA}'')",
},
{
"field": "NUM_POLIZA_GRUPO",
"title": "Poliza Grupo",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NUM_CONTRATO",
"title": "Contrato",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NUM_POLIZA",
"title": "No. Poliza",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "function (value, row, index, field) { return ''<a href=tabrender?id=302&P_NUM_POLIZA='' + row.NUM_POLIZA + '' onclick=app.ViewerQuery.TabRender(this); return false;>'' + value + ''</a>''; }"
},
{
"field": "ABR_RAMO",
"title": "Ramo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeFormatter"
},
{
"field": "COD_DOCUM",
"title": "Cedula Tomador",
"sortable": true,
"halign": "center",
"align": "left",
"format": "{TIP_DOCUM} {COD_DOCUM}"
},
{
"field": "NOM_TOMADOR",
"title": "Tomador",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeEachWordFormatter"
},
{
"field": "TLF_NUMERO",
"title": "Telefono",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "EM')||TO_CLOB('AIL",
"title": "Correo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "IDENTIFICACION",
"title": "Cedula Asegurado",
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
"formatter": "app.ui.StringCapitalizeEachWordFormatter"
},
{
"field": "TLF_NUMERO_ASEG",
"title": "Telefono Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "EMAIL_ASEG",
"title": "Correo Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_ACREEDOR",
"title": "Acreedor",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_RIESGO",
"title": "Riesgo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_FRACC_PAGO",
"title": "Fraccionamiento",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeFormatter"
},
{
"field": "FEC_EFEC_POLIZA",
"title": "Inicio de vigencia",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.DateFormatter"
},
{
"field": "FEC_VCTO_POLIZA",
"title": "Fin de vigencia",
"sortable": true,
"halign": "center",
"align": "center",
"formatter": "app.ui.DateFormatter"
}
]
}
}'),'Tron',1,NULL,NULL,NULL,'Extend.Policy.js',TO_CLOB('SELECT distinct      a.cod_cia,            a.num_poliza,       b.num_riesgo,      a.num_poliza_anterior,
             a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,    a.num_subcontrato,
             a.fec_efec_poliza,    a.fec_vcto_poliza,  a.num_presupuesto, b.nom_certificado,
             a.tip_docum,          a.cod_docum,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client(a.tip_docum, a.cod_docum) NOM_TOMADOR,
             em_k_Mapfre_Query_Contract_mcr.f_search_email_client(a.tip_docum, a.cod_docum) email,
             em_k_Mapfre_Query_Contract_mcr.f_search_phone_client(a.tip_docum, a.cod_docum) tlf_numero,
             a.num_spto,        a.num_apli, a.num_spto_apli,      a.cod_ramo,         a.cod_agt,
             a60.tip_docum || '' '' || a60.cod_docum IDENTIFICACION,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client( a60.tip_docum,a60.cod_docum)  NOM_COMPLETO,
             em_k_Mapfre_Query_Contract_mcr.f_search_email_client(a60.tip_docum, a60.cod_docum) email_aseg,
             em_k_Mapfre_Query_Contract_mcr.f_search_phone_client(a60.tip_docum, a60.cod_docum) tlf_numero_aseg,
             d.abr_ramo,
             b.nom_riesgo || ''  '' ||  em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a.num_poliza,''COD_CHASSIS'') nom_riesgo,
             a1402.nom_fracc_pago,
             a60.tip_benef,
             F_PRIMA_TOTAL_MCR(a.num_poliza) prima_total,
             em_k_Mapfre_Query_Contract_mcr.f_search_name_client_tip_benef(a.num_poliza,''8'') nom_acreedor
        FROM a2000030 a,
             a2000031 b,
             v1001390 c,
             a1001800 d,
             a2000060 a60,
             a1001403 a1403,
             a1001402 a1402
       WHERE a.cod_cia            = {app.P_COD_CIA}
         AND a.cod_agt            = {app.P_COD_AGT}
         AND a.cod_ramo           in (194, 401, 117)
         AND a.mca_spto_anulado   = ''N''
         AND a.mca_poliza_anulada = ''N''
         AND a.mca_prov')||TO_CLOB('isional    = ''N''
         AND a.num_spto  in (select max(num_spto)
                               from a2000030 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza
                                AND a20.mca_spto_anulado = ''N'')
         ---Riesgo
         AND b.cod_cia          = a.cod_cia
         AND b.num_poliza       = a.num_poliza
         AND b.mca_vigente      = ''S''
         AND b.mca_baja_riesgo  = ''N''
         AND b.num_spto  in (SELECT MAX(num_spto)
                               FROM a2000031 a31
                              WHERE a31.cod_cia          = b.cod_cia
                                AND a31.num_poliza       = b.num_poliza
                                AND a31.mca_vigente      = ''S'')

         ---
         --
         AND a.cod_cia = d.cod_cia
         AND a.cod_ramo = d.cod_ramo
         --Informacion tercero Asegurado
         and a60.cod_cia = a.cod_cia
         and a60.num_poliza = a.num_poliza
         and a60.num_poliza = b.num_poliza
         and a60.num_riesgo = b.num_riesgo
         and a60.mca_baja = ''N''
         and a60.mca_vigente = ''S''
         and a60.tip_benef = 2
         and c.tip_docum =  a60.tip_docum
         and c.cod_docum =  a60.cod_docum
         --
         ---Fraccionamiento de Pago
          and a.cod_cia = a1403.cod_cia
          and a.cod_mon = a1403.cod_mon
          and a.cod_ramo = a1403.cod_ramo
          and a.cod_fracc_pago = a1403.cod_fracc_pago
          and a1403.cod_cia = a1402.cod_cia
          and a1403.cod_fracc_pago = a1402.cod_fracc_pago

       ORDER BY a.num_poliza'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (395,1,1,'Estado transacciones',NULL,NULL,NULL,NULL,NULL,1,1,10509,TIMESTAMP'2022-05-31 00:00:00',TO_CLOB('{
    "title": "Estado transacciones",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
        "columns": [
            {
                "field": "UPDATEDATE",
                "title": "Fecha y hora",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateAndTimeFormatter"
            },
            {
                "field": "REFERENCE",
                "title": "Referencia",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "AUTHORIZATION",
                "title": "Autorizaci?n/CUS",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "DESCRIPTION",
                "title": "Estado",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "AMOUNT",
                "title": "Valor",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.CurrencyAmountFormatter"
            },
            {
                "field": "POLICYID",
                "title": "P?liza",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "BILLNUMBER",
                "title":')||TO_CLOB(' "Recibo",
                "sortable": true,
                "halign": "center",
                "align": "center"
            }
        ]
    }
}'),'Research',1,NULL,NULL,'transacciones',NULL,TO_CLOB('SELECT OLP.UPDATEDATE,OLP.REFERENCE,OLP.AUTHORIZATION, OLP.STATUSDATE, OLP.PROVIDERSTATUS, OLP.STATUS, S.DESCRIPTION, OLP.CURRENCY,C.EXTENDSTRINGVALUE1 NOM_MON, OLP.AMOUNT, OLP.POLICYID, OLP.BILLNUMBER
FROM ONLINEPAYMENT OLP
  LEFT JOIN LOOKUP     C ON C.LOOKUPID=101 AND C.LANGUAGE=1 AND C.CODE = OLP.CURRENCY
  LEFT JOIN LOOKUP     S ON S.LOOKUPID=103 AND S.LANGUAGE=1 AND S.CODE = OLP.STATUS
WHERE OLP.UPDATEUSERCODE = {app.userid} AND NOT OLP.AUTHORIZATION IS NULL
ORDER BY OLP.STATUSDATE DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (396,1,1,'P?lizas para Variaciones','Mis clientes - Agente conectado',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2024-10-22 21:49:26',TO_CLOB('{
  "title": "Polizas para Variaciones",
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
        "title": "Acciones",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "function (value, row, index, field) { var url = '''';switch (row.COD_RAMO){case 302: url = ''/Aliados/Variaciones/MapfreMasOld?poliza=''+row.NUM_POLIZA+''&spto=''+row.NUM_SPTO+''&mca_provisional=''+row.MCA_PROVISIONAL;break;case 303: url = ''/Aliados/Variaciones/MapfreMasPlus?poliza=''+row.NUM_POLIZA+''&spto=''+row.NUM_SPTO+''&mca_provisional=''+row.MCA_PROVISIONAL;break;}return ''<a href=\"'' + url + ''\" target=\"_blank\"><span class=columnBtn><button type=\"button\" name=\"search\" class=\"btn btn-sm btn-white event\" title=\"Permite consultar la poliza\"><i class=\"fa fa-pencil\"></i></button></span></a>'' ;}",
        "visible": true
      },
      {
        "field": "MCA_PROVISIONAL",
        "title": "Mca Provisional",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "function (value, row, index, field) {if(row.MCA_PROVISIONAL === ''S''){return ''<input type=\"checkbox\" checked disabled>'';}else{return ''<input type=\"checkbox\" disabled>'';}}",
        "visible": true
      },
      {
        "field": "NUM_POLIZA_GRUPO",
        "title": "Poliza Grupo",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "NUM_CONTRATO",
        "title": "Contrato",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "NUM_POLIZA",
        "title": "No. Poliza",
        "sortable": true,
        "')||TO_CLOB('halign": "center",
        "align": "left"
      },
      {
        "field": "COD_RAMO",
        "title": "Cod. Ramo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "ABR_RAMO",
        "title": "Ramo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringCapitalizeFormatter"
      },
      {
        "field": "COD_DOCUM",
        "title": "Cedula Tomador",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "format": "{TIP_DOCUM} {COD_DOCUM}"
      },
      {
        "field": "NOM_TOMADOR",
        "title": "Tomador",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter"
      },
      {
        "field": "TLF_NUMERO",
        "title": "Telefono",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "EMAIL",
        "title": "Correo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "IDENTIFICACION",
        "title": "Cedula Asegurado",
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
        "formatter": "app.ui.StringCapitalizeEachWordFormatter"
      },
      {
        "field": "TLF_NUMERO_ASEG",
        "title": "Telefono Asegurado",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "EMAIL_ASEG",
        "title": "Correo A')||TO_CLOB('segurado",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "NOM_ACREEDOR",
        "title": "Acreedor",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "NOM_RIESGO",
        "title": "Riesgo",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "NOM_FRACC_PAGO",
        "title": "Fraccionamiento",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringCapitalizeFormatter"
      },
      {
        "field": "FEC_EFEC_POLIZA",
        "title": "Inicio de vigencia",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter"
      },
      {
        "field": "FEC_VCTO_POLIZA",
        "title": "Fin de vigencia",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter"
      }
    ]
  }
}'),'Tron',2,NULL,NULL,NULL,'Extend.Policy.js',TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_policy_by_agent_tomador_za {app.P_COD_CIA} {app.P_COD_AGT}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (400,1,1,'Avisos de cobro de un agente',NULL,NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2022-06-02 00:00:00',TO_CLOB('{
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
        "formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button name=\"eliminaaviso\" type=\"button\" class=\"btn btn-sm btn-white event\" title=\"Permite eliminar el aviso\"><i class=\"fa fa-trash\"></i></button><button name=\"imprimeaviso\" type=\"button\" class=\"btn btn-sm btn-white event\" title=\"Permite generar el PDF del aviso\"><i class=\"fa fa-print\"></i></bu')||TO_CLOB('tton><button type=\"button\" name=\"detalleaviso\" class=\"btn btn-sm btn-white event\" title=\"Permite generar el PDF del detalle del aviso\"><i class=\"fa fa-asterisk\"></i></button></span>'' ;}",
        "events": true,
        "action_eliminaaviso": "app.Ex_AvisosCobro.Eliminar(row)",
        "action_imprimeaviso": "app.Ex_AvisosCobro.Imprimir(row)",
        "action_detalleaviso": "app.Ex_AvisosCobro.ImprimirDetalle(row)"
      }
    ]
  }
}
'),'Tron',1,NULL,NULL,NULL,'Extend.AvisosCobro.js',TO_CLOB('SELECT a.cod_docum_pago,a.FEC_VCTO_PAGO, a.tip_situacion estatus, COUNT(distinct a.num_recibo) cant_recibos, a.cod_mon, SUM(a.imp_recibo) total_recibos
  FROM a2990700 a
 WHERE a.cod_cia = 1
   AND a.cod_agt = {app.agentcode}
   AND a.cod_docum_pago || '''' IS NOT NULL
   AND a.num_recibo  <> -1
 GROUP BY a.cod_docum_pago, a.FEC_VCTO_PAGO, a.tip_situacion, a.cod_mon
 order by a.cod_docum_pago desc
'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (401,1,1,'Recibos de un aviso de cobro',NULL,NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2022-06-02 00:00:00',TO_CLOB('{
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
        "field": "SUM(IMP_RECIBO)",
        "title": "Monto",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": ""
      },
      {
        "field": "NUM_RECIBO",
        "title": "No. Recibo",
        "sortable": true,
        "halign": "center",
        "align": "center"
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
        "field": "COD_MON",
        "title": "Moneda",
        "sortable": true,
        "halign": "center",
        "align": "center"
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
        "field": "TIP_DOCUM",
        "title": "Tipo Identifi')||TO_CLOB('cacion Asegurado",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "format": "{TIP_DOCUM}"
      },
      {
        "field": "COD_DOCUM",
        "title": "Identificacion Asegurado",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "format": "{COD_DOCUM}"
      },
      {
        "field": "NOM_COMPLETO",
        "title": "Nombre Asegurado",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "format": "{NOM_COMPLETO}"
      },
      {
        "field": "COD_DOCUM_PAGO",
        "title": "Aviso",
        "sortable": true,
        "halign": "center",
        "align": "left"
      }
    ]
  }
}'),'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT null Sel, {cod_docum_pago:varchar} cod_docum_pago, num_poliza, num_recibo, FEC_EFEC_RECIBO, tip_situacion, cod_mon, tip_docum, cod_docum, NOM_COMPLETO, nom_riesgo, sum(imp_recibo)
  FROM ( SELECT a.num_poliza, a.num_recibo, a.FEC_EFEC_RECIBO, a.tip_situacion, a.cod_mon, c.tip_docum, c.cod_docum, V90.NOM_COMPLETO, em_f_nom_riesgo_web(a.cod_cia, a.num_poliza, a.num_spto, 1) nom_riesgo, a.imp_recibo
  FROM a2990700 a
  LEFT JOIN a2000060 c ON c.cod_cia = a.cod_cia and c.num_poliza = a.num_poliza and c.tip_benef = 2 and c.mca_vigente = ''S'' and mca_baja = ''N''
  LEFT JOIN V1001390 V90 ON v90.COD_ACT_TERCERO = 1 AND V90.TIP_DOCUM = c.tip_docum AND V90.COD_DOCUM = c.cod_docum
 WHERE a.cod_cia = 1
   AND a.cod_docum_pago = {cod_docum_pago:varchar}
   AND a.num_recibo  <> -1)
 group by num_poliza, num_recibo, FEC_EFEC_RECIBO, tip_situacion, cod_mon, tip_docum, cod_docum, NOM_COMPLETO, nom_riesgo
 order by num_recibo, num_poliza'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (402,1,1,'Avisos de cobro por agente',NULL,NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2022-06-02 00:00:00',TO_CLOB('{
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
        "events": t')||TO_CLOB('rue,
        "action_eliminaaviso": "app.Ex_AvisosCobro.Eliminar(row)",
        "action_imprimeaviso": "app.Ex_AvisosCobro.Imprimir(row)",
        "action_detalleaviso": "app.Ex_AvisosCobro.ImprimirDetalle(row)"
      }
    ]
  }
}'),'Tron',1,'|título
|zona|4
 Agente+|lista|name=cod_agt;lookup=Agents
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 402, @_@_)',NULL,NULL,'Extend.AvisosCobro.js',TO_CLOB('SELECT a.cod_docum_pago, a.tip_situacion estatus, COUNT(distinct a.num_recibo) cant_recibos, a.cod_mon, SUM(a.imp_recibo) total_recibos
  FROM a2990700 a
 WHERE a.cod_cia = 1
   AND a.cod_agt = {cod_agt}
   AND a.cod_docum_pago || '''' IS NOT NULL
   AND a.num_recibo  <> -1
 GROUP BY a.cod_docum_pago, a.tip_situacion, a.cod_mon
 order by a.cod_docum_pago desc'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (410,1,1,'Recibos pendientes de cobro por agente','Filtro',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2023-01-30 08:00:20',TO_CLOB('{
    "title": "Recibos pendientes",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
        "detailId": 311,
        "detailParameters": "tip_docum=TIP_DOCUM:cod_docum=COD_DOCUM",
        "columns": [
            {
                "field": "NUM_POLIZA",
                "title": "No. Poliza",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "NOM_COMPLETO",
                "title": "Contratante",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringCapitalizeFormatter"
            },
            {
                "field": "TIP_GESTOR",
                "title": "Gestor",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
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
                "field": "NUM_RECIBO",
                "title": "No. Recibo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "IMP_RECIBO",
                "title": "Monto",
                "sortable": true,
                "halign": "center",
                "align": "right",
    ')||TO_CLOB('            "formatter": "app.ui.CurrencyAmountFormatter"
            },
            {
                "field": "IMP_COMIS",
                "title": "Comision",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.CurrencyAmountFormatter"
            },
            {
                "field": "FEC_VCTO_RECIBO",
                "title": "Vencimiento",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter"
            },
            {
                "field": "TIP_DOCUM",
                "title": "Tipo de cedula",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "COD_DOCUM",
                "title": "Cedula",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "title": "Acciones",
                "sortable": true,
                "halign": "center",
                "align": "center",
          "formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button name=\"printr\" type=\"button\"class=\"btn btn-sm btn-white event\" title=\"Permite imprimir el recibo\"><i class=\"fa fa-print\"></i></button><button type=\"button\" name=\"payment\" class=\"btn btn-sm btn-white d-none role-Pago-visible event\" title=\"Permite pagar el recibo actual\"><i class=\"fa fa-shopping-cart\"></i></button></span>'' ;}",
                "events":  true,
                "action_payment": "app.core.LoadScriptFile(''Payment.js'').then(d => {app.Payment.Recibo(row, 410, 1)})"
            }
        ]
    }
}'),'Tron',1,'|titulo
|zona|4
 Agente+|lista|name=cod_agt;lookup=Agents
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Filtrar|Boton|class=btn-form btn-primary btn-QueryFilter;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 11, @_@_)',NULL,NULL,'Extend.js
',TO_CLOB('SELECT   a.num_poliza, a.fec_efec_poliza, a.fec_vcto_poliza, a.tip_docum, a.cod_docum, 1 num_spto,a.cod_agt, d.NOM_COMPLETO, em_k_Mapfre_Query_Contract_mcr.f_obtener_total_recibo(a.cod_cia,c.num_recibo) imp_recibo, em_k_Mapfre_Query_Contract_mcr.f_obtener_total_comision(a.cod_cia,c.num_recibo)  imp_comis,a.tip_gestor, c.fec_efec_recibo fec_vcto_recibo, c.tip_situacion, c.num_recibo, c.fec_valor,a.tip_docum || ''-'' || a.cod_docum key, d.NOM_COMPLETO NOM_COMPLETO2,
         DECODE(c.tip_situacion,
                        ''RE'', ''REMESADO'',
                        ''EP'', ''PENDIENTE'') tip_situacion_desc,
         DECODE(a.tip_gestor,
                        ''AG'', ''VENTANILLA'',
                        ''BA'', ''CUENTA'',
                        ''TA'', ''TARJETA'') tip_gestor_desc,
         a1331.tlf_numero, a1331.tlf_numero_com,
         a1331.fax_numero, a1331.fax_numero_com,
         nvl(upper(a1331.email),''***'') email, nom_domicilio1, nom_domicilio2, nom_domicilio3,
         a400.cod_mon_iso nom_mon
    FROM a2000030 a,
         a2990700 c,
         v1001390 d,
         a1001331 a1331,
         a1000400 a400
   WHERE a.cod_cia             = {app.P_COD_CIA} 
     AND a.cod_agt             = {cod_agt}
     and a.cod_ramo not in (230)
     AND a.mca_spto_anulado    = ''N''
     AND a.mca_poliza_anulada  = ''N''
     AND a.mca_provisional    = ''N''
     AND a.num_spto  in (select num_spto --max(num_spto)
                               from a2000030 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza
                                AND a20.mca_spto_anulado = ''N'')
     ---
     AND a.cod_cia   = d.cod_cia
     AND a.tip_docum = d.tip_docum
     AND a.cod_docum = d.cod_docum
     AND d.COD_ACT_TERCERO = 1
     --
     AND a1331.tip_docum = d.tip_DOCUM
     AND a1331.cod_docum = d.COD_DOCUM
     --
     AND c.cod_mon = a400.cod_mon
     --
     AND c.cod_cia  = a.cod_cia
  ')||TO_CLOB('   AND c.num_spto  = a.num_spto
     AND c.num_apli   = a.num_apli
     AND c.num_poliza  = a.num_poliza
     AND c.num_spto_apli = a.num_spto_apli
     AND trunc(c.fec_efec_recibo) BETWEEN {desde:date} AND {hasta:date}
     AND c.tip_situacion  in (''EP'')
     AND c.num_recibo > 0
     and c.num_recibo = (select min(t.num_recibo)
                            from a2990700 t
                            where cod_cia = 1
                            and t.num_poliza = a.num_poliza
                            and t.num_spto = a.num_spto
                            and t.num_apli = a.num_apli
                            and t.num_spto_apli = a.num_spto_apli
                            and t.tip_situacion = ''EP'')                      
     GROUP BY a.cod_cia,            a.num_poliza,       a.num_poliza_anterior,
         a.num_poliza_cliente, a.num_poliza_grupo, a.num_contrato,
         a.num_subcontrato,    a.fec_efec_poliza,  a.fec_vcto_poliza,
         a.num_presupuesto,    a.tip_docum,        a.cod_docum,
         1,           a.num_apli,         a.num_spto_apli,
         a.cod_ramo,           a.cod_agt,
         substr(d.NOM_COMPLETO, 0, 8) ,
         a.tip_gestor,
         c.fec_efec_recibo ,
         c.tip_situacion,
         c.num_recibo,
         c.fec_valor,
         a.tip_docum || ''-'' || a.cod_docum,
         d.NOM_COMPLETO,
         c.fec_efec_recibo ,
         c.fec_vcto_recibo ,
         DECODE(c.tip_situacion,
                        ''RE'', ''REMESADO'',
                        ''EP'', ''PENDIENTE'') ,
         DECODE(a.tip_gestor,
                        ''AG'', ''VENTANILLA'',
                        ''BA'', ''CUENTA'',
                        ''TA'', ''TARJETA'') ,
         a1331.tlf_numero,
         a1331.tlf_numero_com,
         a1331.fax_numero,
         a1331.fax_numero_com,
         nvl(upper(a1331.email),''***'') ,
         nom_domicilio1,
         nom_domicilio2,
         nom_domicilio3,
         a400.cod_mon_iso
   ORDER ')||TO_CLOB('BY c.fec_efec_recibo'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (411,1,1,'Recibos cobrados por agente','Filtro',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-08-23 12:14:20',TO_CLOB('{
  "title": "Recibos cobrados",
  "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": true,
        "showPaginationSwitch": false,
        "exportTypes": ["csv", "excel"],
    "columns": [
      {
        "field": "NUM_POLIZA",
        "title": "No. p?liza",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "NOM_COMPLETO",
        "title": "Contratante",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "NUM_RECIBO",
        "title": "Recibo",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "visible": true
      },
      {
        "field": "FEC_EFEC_RECIBO",
        "title": "Inicio vig. recibo",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      },
      {
        "field": "FEC_VCTO_RECIBO",
        "title": "Fin vig. recibo",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      },
      {
        "field": "COD_MON_ISO",
        "title": "Moneda",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "IMP_RECIBO",
        "title": "Monto",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalFormatter",
        "visible": true
      },
      {
        "field": "FEC_SITUACION",
        "title": "Fecha de pago",
        "sortable": true,
        "hali')||TO_CLOB('gn": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter",
        "visible": true
      },
            {
                "title": "Acciones",
                "sortable": true,
                "halign": "center",
                "align": "center",
          "formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button name=\"printr\" type=\"button\"class=\"btn btn-sm btn-white event\" title=\"Permite imprimir el recibo\"><i class=\"fa fa-print\"></i></button></span>'' ;}",
                "events":  true
            }
    ]
  }
}'),'Tron',2,'|titulo
|zona|4
 Agente+|lista|name=cod_agt;lookup=Agents
 Mes+|lista|values=1->Enero,2->Febrero,3->Marzo,4->Abril,5->Mayo,6->Junio,7->Julio,8->Agosto,9->Septiembre,10->Octubre,11->Noviembre,12->Diciembre;default=today.month
 A?o+|entero(5)|name=anio;default=today.year
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 318, @_@_)',NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_premium_collection {app.P_COD_CIA} {cod_agt} {mes} {anio}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (412,1,1,'Polizas Activas MAPFRE Mas','Filtro',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2023-04-03 08:00:20',TO_CLOB('{
"title": "Polizas MAPFRE Mas",
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
      "field": "NUM_POLIZA_GRUPO",
      "title": "Poliza Grupo",
      "sortable": true,
      "halign": "center",
      "align": "center",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "NUM_CONTRATO",
      "title": "Contrato",
      "sortable": true,
      "halign": "center",
      "align": "center",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "NUM_POLIZA",
      "title": "No. Poliza",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "function (value, row, index, field) { return ''<a href=tabrender?id=302&P_NUM_POLIZA='' + row.NUM_POLIZA + '' onclick=app.ViewerQuery.TabRender(this); return false;>'' + value + ''</a>''; }"
   },
   {
      "field": "COD_DOCUM",
      "title": "Cedula",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "format": "{TIP_DOCUM} {COD_DOCUM}"
   },
   {
      "field": "NOM_COMPLETO",
      "title": "Contratante",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringCapitalizeEachWordFormatter"
   },
   {
      "field": "TLF_NUMERO",
      "title": "Telefono",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "EMAIL",
      "title": "Correo",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "NOM_RIESGO",
      "title": "Riesgo",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "NOM_FRACC_PAGO",
      "title": "Frac')||TO_CLOB('cionamiento",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringCapitalizeFormatter"
   },
   {
      "field": "FEC_EFEC_POLIZA",
      "title": "Inicio de vigencia",
      "sortable": true,
      "halign": "center",
      "align": "center",
      "formatter": "app.ui.DateFormatter"
   },
   {
      "field": "FEC_VCTO_POLIZA",
      "title": "Fin de vigencia",
      "sortable": true,
      "halign": "center",
      "align": "center",
      "formatter": "app.ui.DateFormatter"
   },
   {
      "field": "MARCA",
      "title": "Marca",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "MODELO",
      "title": "Modelo",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "VALOR_VEHICULO",
      "title": "Valor del Vehiculo",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": ""
   },
   {
      "field": "MOTOR",
      "title": "Motor",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "CHASIS",
      "title": "Chais",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "ANIO",
      "title": "Anio",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   }
]
}
}'),'Tron',1,'|titulo
|zona|4
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 11, @_@_)',NULL,NULL,'Extend.js',TO_CLOB('SELECT distinct a.cod_cia, a.num_poliza, a.num_poliza_grupo, a.num_contrato,    a.num_subcontrato,
                a.fec_efec_poliza,    a.fec_vcto_poliza, a.tip_docum, a.cod_docum, NOM_COMPLETO,
                a60.tip_docum tip_docum_aseg, a60.cod_docum cod_docum_aseg, em_k_Mapfre_Query_Contract_mcr.f_search_name_client(a60.tip_docum, a60.cod_docum) nom_asegurado,
                b.nom_riesgo ,     e.tlf_numero, e.email, a1402.nom_fracc_pago,
                em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a.num_poliza, ''COD_MARCA'') MARCA,
                em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a.num_poliza, ''COD_MODELO'') MODELO,
                em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a.num_poliza, ''IMP_VR'') VALOR_VEHICULO,
                em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a.num_poliza, ''NUM_MOTOR'') MOTOR,
                em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a.num_poliza, ''COD_CHASSIS'') CHASIS,
                em_k_Mapfre_Query_Contract_mcr.f_obtener_dato_variable(a.num_poliza, ''ANIO_SUB_MODELO'') ANIO
        FROM a2000030 a,
             a2000031 b,
             v1001390 c,
             a1001800 d,
             a1001331 e,
             a1001403 a1403,
             a1001402 a1402,
             a2000060 a60
       WHERE a.cod_cia            = {app.P_COD_CIA}
         AND a.cod_agt            = {app.P_COD_AGT}
         AND a.cod_ramo = 302
         AND a.mca_spto_anulado   = ''N''
         AND a.mca_poliza_anulada = ''N''
         AND a.mca_provisional    = ''N''
         AND a.num_spto  in (select max(num_spto)
                               from a2000030 a20
                              where a20.cod_cia  = a.cod_cia
                                and a20.num_poliza = a.num_poliza
                                AND a20.mca_spto_anulado = ''N'')
         AND trunc(a.fec_efec_poliza) BETWEEN {desde:date}  AND {hasta:date}
         ---
         AND b.cod_cia          = a.cod_cia
         AND b.num_')||TO_CLOB('poliza       = a.num_poliza
         AND b.mca_vigente      = ''S''
         AND b.mca_baja_riesgo  = ''N''
         AND b.num_spto  in (SELECT MAX(num_spto)
                               FROM a2000031 a31
                              WHERE a31.cod_cia          = b.cod_cia
                                AND a31.num_poliza       = b.num_poliza
                                AND a31.mca_vigente      = ''S'')
         --Tomador--
         AND a.cod_cia   = c.cod_cia
         AND c.tip_docum = a.tip_docum
         AND c.cod_docum = a.cod_docum
         AND c.COD_ACT_TERCERO = 1
         and e.tip_docum = c.TIP_DOCUM
         and e.cod_docum = c.COD_DOCUM
         --Informacion tercero Asegurado
         and a60.num_poliza = a.num_poliza
         and a60.tip_benef = 2
         and a60.mca_baja = ''N''
         and a60.mca_vigente = ''S''
         and a60.num_riesgo = b.num_riesgo
         --
         AND a.cod_cia = d.cod_cia
         AND a.cod_ramo = d.cod_ramo
         ---Fraccionamiento de Pago
          and a.cod_cia = a1403.cod_cia
          and a.cod_mon = a1403.cod_mon
          and a.cod_ramo = a1403.cod_ramo
          and a.cod_fracc_pago = a1403.cod_fracc_pago
          and a1403.cod_cia = a1402.cod_cia
          and a1403.cod_fracc_pago = a1402.cod_fracc_pago
          --Prima
       ORDER BY a.num_poliza'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (6000,1,1,'Polizas','Polizas',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-12-30 15:40:46',TO_CLOB('{
"title": "Polizas",
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
"skipload": true,
"columns": [
    [
        {
            "field": "NOM_RAMO",
            "title": "Ramo",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringCapitalizeFormatter",
            "visible": true,
            "rowspan": 2
        },
        {
            "field": "NUM_POLIZA",
            "title": "Poliza",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "format": "<a href=''tabrender?id=302&P_NUM_POLIZA={NUM_POLIZA}'' onclick=''app.ViewerQuery.TabRender(this); return false;'' title=''Ver detalle de la poliza''>{NUM_POLIZA} <button type=''button'' class=''btn btn-slim btn-sm btn-link''><i class=''fa fa-plus-square-o''></i></button></a>",
            "visible": true,
            "rowspan": 2
        },
        {
            "field": "NOM_TOMADOR",
            "title": "Tomador",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "visible": true,
            "rowspan": 2
        },
        {
            "field": "NOM_RIESGO",
            "title": "Riesgo",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "visible": true,
            "rowspan": 2
        },
        {
            "field": "VALOR_STATUS",
            "title": "Estatus",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringCapitalizeFormatter",
            "visible": true,
            "rowspan": 2
        },
        {
           ')||TO_CLOB(' "title": "Vigencia",
            "halign": "center",
            "colspan": 2
        },
        {
            "title": "Suplemento",
            "halign": "center",
            "colspan": 2
        },
        {
            "title": "Agente",
            "halign": "center",
            "colspan": 2
        }
    ],
    [
        {
            "field": "DESDE",
            "title": "Inicio",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.StringFormatter",
            "visible": true
        },
        {
            "field": "HASTA",
            "title": "Vencimiento",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.StringFormatter",
            "visible": true
        },
        {
            "field": "FEC_EFEC_SPTO",
            "title": "Inicio",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.DateFormatter",
            "visible": true
        },
        {
            "field": "FEC_VCTO_SPTO",
            "title": "Vencimiento",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.DateFormatter",
            "visible": true
        },
        {
            "field": "TIP_DOCUM",
            "title": "Identificacion",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "visible": true,
            "format": "<span>{TIP_DOCUM} {COD_DOCUM}</span>"
        },
        {
            "field": "AGENTE",
            "title": "Nombres",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "visible": true
        }
    ]
]
}
}'),'Tron',2,'|titulo
|zona|3
 Buscar por+|lista|name=tipo;datatype=string;values=D->Numero de documento de identificacion,P->Poliza,M->Matricula,C->Chasis,T->Motor
 Tipo de documento+|lista|name=tip_docum;datatype=string;values=CNA->Cedula nacional,CJU->Cedula juridica,CRE->Cedula de residencia,EEX->Empresa extrajera,PAS->Pasaporte 
 Valor+|Texto(120)
 Filtrar|Boton|class=btn-primary btn-QueryFilter;click=app.Extend.Query()',NULL,NULL,'Extend.CallCenter.js',TO_CLOB('DC_K_CONSULTA_WEB.P_DEVUELVE_CONSULTA {app.P_COD_CIA} {const.9999999} {P_COD_USR:varchar} {tipo:varchar} {tip_docum:varchar} {valor:varchar} {p_rol_usr_web:varchar} {p_grupo_cliente:varchar} {p_dev_consulta:cursor} {p_errores:cursor}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9105,1,9,'Emitir una póliza','Form',NULL,NULL,NULL,NULL,1,1,10509,TIMESTAMP'2025-04-15 00:00:00',NULL,NULL,NULL,'Emisión de una pólizas|título
Datos generales|zona|columns=4|width=6
 Ramo+|lista|name=RAMO|values=194->Accidentes personales,401->Saldo deudor declarativo,117->Seguro vida colectivo
 Contrato+|lista|name=NUM_CONTRATO|disabled=true
 Póliza Grupo|texto(13)|name=NUM_POLIZA_GRUPO|disabled=true
 Moneda|texto|name=MONEDA|disabled=true
 Inicio de vigencia+|fechainicio|name=EFEC_SPTO
 Fin de vigencia+|fechafin|name=VCTO_SPTO
Datos del asegurado|zona|columns=4|width=6
 Identificación+|cedula|name=COD_DOCUM_ASEG
 Nombre+|texto(20)|name=NOM_TERCERO_ASEG
 Apellido+|texto(20)|name=APE_TERCERO_ASEG
 Fecha de nacimiento|Nacimiento|name=NAC_ASEG
 Sexo|radio|name=MCA_SEXO_ASEG|values=0->Femenino,1->Masculino
 Nacionalidad|tron.País|name=NACIONALIDAD_ASEG
 Provincia|tron.Provincia|name=COD_ESTADO
 Cantón|tron.Cantón|name=COD_PROVINCIA
 Distrito|tron.Distrito|name=COD_LOCALIDAD
 Otra señas|nota(180)|name=DOMICILIO|filas=2|column=12
Datos del riesgo|zona|columns=4|visible=entry.RAMO.neq.0
 Número del préstamo+|texto(30)|name=NUM_PRESTAMO|visible=entry.RAMO.eq.401
 Inicio del préstamo+|fecha|name=INI_PRESTAMO|visible=entry.RAMO.eq.401
 Fin del préstamo+|fecha|name=VCTO_PRESTAMO|visible=entry.RAMO.eq.401
 Sueldo del asegurado+|decimal(18,3)|name=IMP_SUM_ASEG_VC|visible=entry.RAMO.eq.117
 Suma asegurada+|decimal(18,3)|name=IMP_SUMA_ASEG|visible=entry.RAMO.eq.401 
 Prima a facturar+|decimal(18,3)|name=IMP_PRIMA_FACT|visible=entry.RAMO.eq.117
 Prima informada+|decimal(18,3)|name=IMP_PRIMA_INFORMADA|visible=entry.RAMO.eq.117.or.entry.RAMO.eq.401
 Identificación del estudiante+|texto(15)|name=ID_CRED_ESTUDIANTE|visible=entry.RAMO.eq.194
 ¿Asistencia?|radio|name=MCA_ASISTENCIA|values=1->Si,2->No
 Suma asegurada por muerte|decimal(18,3)|name=IMP_SUMA_MUERTE|visible=entry.RAMO.eq.194
 Plan+|lista|name=COD_PLAN_AP|lookup=TRON_TAVID000|datatype=string|visible=entry.RAMO.eq.194
 Emitir|button|name=btnIssue|class=btn-on-primary',NULL,'EmitirPoliza','Form.Ext.Altas.js',NULL);
