INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (1,1,1,'Reportes disponibles',NULL,NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-10 11:45:02',TO_CLOB('{
    "title": "@Title@",
    "table": {
        "classes": "table table-bordered table-hover table-index col-md-4 offset-md-4",
        "pagination": false,
        "search": false,
        "showToggle": false,
        "showRefresh": false,
        "showColumns": false,
        "showExport": false,
        "showPaginationSwitch": false,
        "columns": [
            {
                "field": "Id|h",
                "title": "Id",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "visible": false
            },
            {
                "field": "Seq|h",
                "title": "Seq",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "visible": false
            },
            {
                "field": "Nombre",
                "title": "Reporte",
                "sortable": false,
                "halign": "center",
                "align": "left",
                "formatter": "function (value, row, index, field) { return ''<a href=?id='' + row.Id + ''>'' + value + ''</a><br><small class=text-muted>'' + (row.Descripción == null? '''': row.Descripción) + ''</small>'' ;}",
                "visible": true
            },
            {
                "field": "Descripción",
                "title": "Descripción",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": false
            }
        ]
    }
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT ID "Id", SEQUENCE "Seq", CAPTION "Nombre", DESCRIPTION "Descripción"
  FROM VISUALIZATIONS
WHERE RECORDSTATUS=1 AND ID > 1
ORDER BY CAPTION'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (2,1,1,'Auditoria de acceso - Aliados',NULL,NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-10 11:45:02',TO_CLOB('{
"title": "Auditoria de acceso - Aliados",
"table": {
"pagination": true,
"search": true,
"showToggle": true,
"showRefresh": true,
"showColumns": true,
"showExport": true,
"exportTypes": ["json", "xml", "csv", "excel"],
"showPaginationSwitch": true,
"detailId": 3,
"detailParameters": "CompanyId=CompanyId:UserId=UserId",
"columns": [
{
    "field": "ALEADO",
    "title": "Aliado",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": true
},
{
    "field": "Cuando",
    "title": "Cuando",
    "sortable": true,
    "halign": "center",
    "align": "center",
    "formatter": "app.ui.DateAndTimeFormatter",
    "visible": true
},
{
    "field": "Origen",
    "title": "Origen",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": true
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
    "field": "UserId",
    "title": "UserId",
    "sortable": true,
    "halign": "center",
    "align": "right",
    "formatter": "app.ui.IntegerFormatter",
    "visible": false
},
{
    "field": "Correo",
    "title": "Correo",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "function (value, row, index, field) { return ''<a href=?id=3&CompanyId='' + row.CompanyId + ''&UserId='' + row.UserId + ''>'' + value + ''</a>'';}",
    "visible": true
},
{
    "field": "Nombre",
    "title": "Nombre",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": true
},
{
    "field": "Apellido",
    "title": "Apellido",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": true
},
{
    "field": "Sucursal",
    "title": "Sucursal",
    "sortable": true,
    "halig')||TO_CLOB('n": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": true
},
{
    "field": "Resultado",
    "title": "Resultado",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": true
},
{
    "field": "Razón",
    "title": "Razón",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": true
},
{
    "field": "USERAGENT",
    "title": "Browser",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": false
}
]
}
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT A.COMPANYID "CompanyId", C.DESCRIPTION Aleado, A.EFFECTDATE "Cuando", A.IPADDRESS "Origen", A.USERNAME "Usuario",U.UserId "UserId", U.EMAIL "Correo", U.FIRSTNAME "Nombre", U.LASTNAME "Apellido", BO.DESCRIPTION "Sucursal", L.DESCRIPTION "Resultado", A.REASON "Razón", A.USERAGENT
  FROM AUTHENTICATIONTRACE A
  LEFT JOIN LOOKUP     C ON C.LOOKUPID=4 AND C.LANGUAGE=1 AND C.CODE = A.COMPANYID 
  LEFT JOIN LOOKUP     L ON L.LOOKUPID=3 AND L.LANGUAGE=1 AND L.CODE = A.TRACETYPE
  LEFT JOIN USERMEMBER U ON U.COMPANYID=A.COMPANYID AND LOWER(U.USERNAME)=LOWER(A.USERNAME)
  LEFT JOIN LOOKUP     BO ON BO.LOOKUPID=1100 AND BO.LANGUAGE=1 AND BO.COMPANYID=U.COMPANYID AND BO.CODE = U.BRANCHOFFICE
  ORDER BY A.ID DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (3,1,1,'Actividad por usuario',NULL,NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-10 11:45:02',TO_CLOB('{
    "title": "Actividad por usuario",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": true,
        "showRefresh": true,
        "showColumns": true,
        "showExport": true,
        "exportTypes": ["json", "xml", "csv", "excel"],
        "showPaginationSwitch": true,
        "columns": [
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
                "formatter": "app.ui.StringFormatter",
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
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT C.UPDATEDATE "Fecha", L.EXTENDSTRINGVALUE1 "Entidad", C.ENTITYID "Referencia", C.ACTION "Acción", C.SUMMARY "Descripción" 
FROM CHANGESET C
LEFT JOIN LOOKUP L ON L.LOOKUPID=50 AND L.LANGUAGE=1 AND L.CODE = C.ENTITYTYPE
WHERE C.COMPANYID={CompanyId} AND C.UPDATEUSERCODE={UserId}
ORDER BY C.UPDATEDATE DESC'));
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
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (13,1,1,'Dashboard: Pólizas emitidas mensual por sucursal','research',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-06-07 17:59:59',TO_CLOB('{
    "title": "@Title@",
    "table": null,
    "chart": {
        "type": "line",
        "series": "BRANCHOFFICE",
        "labels": "MONTH",
        "values": "POLICYCOUNT"
    }
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('WITH all_the_months
     AS (    SELECT EXTRACT ( YEAR FROM ADD_MONTHS (DATE ''2020-01-01'', ROWNUM - 1)) currentYear,
                    EXTRACT ( MONTH FROM ADD_MONTHS (DATE ''2020-01-01'', ROWNUM - 1)) currentMonth
               FROM DUAL
         CONNECT BY LEVEL <= 12)
  SELECT DECODE(currentMonth, 1, ''Ene'', 2,''Feb'', 3, ''Mar'', 4, ''Abr'', 5, ''May'', 6, ''Jun'', 7, ''Jul'', 8, ''Ago'', 9, ''Sep'', 10, ''Oct'', 11, ''Nov'', 12, ''Dic'') Month, L.DESCRIPTION BranchOffice, COUNT (BranchOffice) PolicyCount
    FROM (SELECT currentYear, currentMonth, L.CODE, L.COMPANYID
            FROM all_the_months
                 CROSS JOIN (SELECT DISTINCT COMPANYID, L.BranchOffice CODE
                               FROM RISK L
                              WHERE L.COMPANYID = {app.companyid} AND L.STATUS = 10 AND L.BranchOffice <> 9999) L) a
         LEFT JOIN RISK
            ON     RISK.COMPANYID = a.COMPANYID
               AND STATUS = 10
               AND BranchOffice <> 9999
               AND EXTRACT (YEAR FROM ISSUEDATE) = a.currentYear
               AND EXTRACT (MONTH FROM ISSUEDATE) = a.currentMonth
               AND BranchOffice = a.CODE
               LEFT JOIN LOOKUP L ON L.LOOKUPID=1100 AND L.LANGUAGE=1 AND L.COMPANYID=a.COMPANYID AND L.CODE = a.CODE
   WHERE currentMonth <= EXTRACT (MONTH FROM SYSDATE)
GROUP BY currentMonth, L.DESCRIPTION
ORDER BY currentMonth'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (15,1,1,'Dashboard: Total de pólizas en vigor','research',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-06-26 20:03:19',NULL,'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT Count(*) TotalPolizas 
  FROM Risk 
 WHERE CompanyId={app.companyid} AND STATUS=10 AND BranchOffice <> 9999'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (16,1,1,'Dashboard: Total de pólizas en vigor por sucursal','research',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-06-26 20:03:01',NULL,'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT L.DESCRIPTION Sucursal, Count(*) Cantidad, round(100*(count(*) / sum(count(*)) over ()),0) Porcentaje
  FROM Risk 
  LEFT JOIN LOOKUP L ON L.LOOKUPID=1100 AND L.LANGUAGE=1 AND L.CODE = BranchOffice
 WHERE Risk.CompanyId={app.companyid} AND STATUS=10 AND BranchOffice <> 9999
 GROUP BY L.DESCRIPTION
 ORDER BY L.DESCRIPTION'));
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
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (40,1,1,'Mis Solicitudes','Solicitudes registras de un empleado',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-10-12 17:47:31',TO_CLOB('{
    "title": "Mis Solicitudes",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": false,
        "showPaginationSwitch": false,
        "detailView": false,
        "columns": [
            {
                "field": "Inclusión",
                "title": "Inclusión",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "Ramo",
                "title": "Tipo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Póliza",
                "title": "Solicitud",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "function (value, row, index, field) { return ''<a href=../Bayer/Inclusion?id='' + row.Id + ''>'' + value + ''</a>'';}",
                "visible": true
            },
            {
                "field": "Identificación",
                "title": "Identificación",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Asegurado",
                "title": "Asegurado",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Estado",
                "title": "Estado",
                "sortable": true,
              ')||TO_CLOB('  "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            }
        ]
    }
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT P.ISSUEDATE "Inclusión", LKR.DESCRIPTION "Ramo", P.ID "Id", DECODE(P.POLICYID, 0,''I-''|| P.ID, P.POLICYID) "Póliza",
        A.DOCUMENTNUMBER "Identificación", TRIM(A.FIRSTNAME) || '' ''  ||  TRIM(A.MIDDLENAME) || '' ''  || TRIM(A.LASTNAME) || '' ''  || TRIM(A.SECONDLASTNAME) "Asegurado", LKS.DESCRIPTION "Estado"
  FROM Risk P
  LEFT JOIN RiskRoles A ON A.POLICYID = P.ID AND A.TYPE=2
  LEFT JOIN LOOKUP LKR ON LKR.LOOKUPID = 2000 AND LKR.COMPANYID=P.COMPANYID AND LKR.LANGUAGE=1 AND LKR.CODE = P.LINEOFBUSINESSCODE
  LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 2050 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE = P.STATUS
 WHERE P.CompanyId={app.companyid} AND P.STATUS > 0 AND P.ExecutiveUserCode={app.userid}
 ORDER BY P.ISSUEDATE DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (41,1,1,'Solicitudes en revisión','Solicitudes en revisión',NULL,NULL,NULL,NULL,1,1,77,TIMESTAMP'2022-01-20 21:13:46',TO_CLOB('{
    "title": "Solicitudes en revisión",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": false,
        "showPaginationSwitch": false,
        "detailView": false,
        "columns": [
            {
                "field": "Inclusión",
                "title": "Inclusión",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "Ramo",
                "title": "Tipo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Póliza",
                "title": "Solicitud",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "function (value, row, index, field) { return ''<a href=../Bayer/Inclusion?id='' + row.Id + ''>'' + value + ''</a>'';}",
                "visible": true
            },
            {
                "field": "Identificación",
                "title": "Identificación",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Asegurado",
                "title": "Asegurado",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Filial",
                "title": "Filial",
                "sortable": true,
      ')||TO_CLOB('          "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "PolizaTron",
                "title": "N° de póliza",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            }
        ]
    }
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT P.ISSUEDATE "Inclusión", LKR.DESCRIPTION "Ramo", P.ID "Id", DECODE(P.POLICYID, 0,''I-''|| P.ID, P.POLICYID) "Póliza",
        A.DOCUMENTNUMBER "Identificación", TRIM(A.FIRSTNAME) || '' ''  ||  TRIM(A.MIDDLENAME) || '' ''  || TRIM(A.LASTNAME) || '' ''  || TRIM(A.SECONDLASTNAME) "Asegurado", LKS.DESCRIPTION "Estado",
        LKF.DESCRIPTION "Filial", LKF.EXTENDSTRINGVALUE1 "PolizaTron"
  FROM Risk P
  LEFT JOIN RiskRoles A ON A.POLICYID = P.ID AND A.TYPE=2
  LEFT JOIN RiskBayer B ON B.ID = P.ID
  LEFT JOIN LOOKUP LKR ON LKR.LOOKUPID = 2000 AND LKR.COMPANYID=P.COMPANYID AND LKR.LANGUAGE=1 AND LKR.CODE = P.LINEOFBUSINESSCODE
  LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 2050 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE = P.STATUS
  LEFT JOIN LOOKUP LKF ON LKF.LOOKUPID = 4000 AND LKF.COMPANYID=P.COMPANYID AND LKF.LANGUAGE=1 AND LKF.CODE = B.MAINPOLICYID
 WHERE P.CompanyId={app.companyid} AND P.STATUS in ( 2, 32)
 ORDER BY P.ISSUEDATE DESC '));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (42,1,1,'Solicitudes','Solicitudes',NULL,NULL,NULL,NULL,1,1,77,TIMESTAMP'2022-01-20 21:15:52',TO_CLOB('{
    "title": "Todas",
    "table": {
        "pagination": true,
        "search": true,
        "showToggle": false,
        "showRefresh": true,
        "showColumns": false,
        "showExport": false,
        "showPaginationSwitch": false,
        "detailView": false,
        "columns": [
            {
                "field": "Inclusión",
                "title": "Inclusión",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "Ramo",
                "title": "Tipo",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Póliza",
                "title": "Solicitud",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "function (value, row, index, field) { return ''<a href=../Bayer/Inclusion?id='' + row.Id + ''>'' + value + ''</a>'';}",
                "visible": true
            },
            {
                "field": "Identificación",
                "title": "Identificación",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Asegurado",
                "title": "Asegurado",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Filial",
                "title": "Filial",
                "sortable": true,
                "halign"')||TO_CLOB(': "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "PolizaTron",
                "title": "N° de póliza",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "Estado",
                "title": "Estado",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            }
        ]
    }
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT P.ISSUEDATE "Inclusión", LKR.DESCRIPTION "Ramo", P.ID "Id", DECODE(P.POLICYID, 0,''I-''|| P.ID, P.POLICYID) "Póliza",
        A.DOCUMENTNUMBER "Identificación", TRIM(A.FIRSTNAME) || '' ''  ||  TRIM(A.MIDDLENAME) || '' ''  || TRIM(A.LASTNAME) || '' ''  || TRIM(A.SECONDLASTNAME) "Asegurado", LKS.DESCRIPTION "Estado",
        LKF.DESCRIPTION "Filial", LKF.EXTENDSTRINGVALUE1 "PolizaTron"
  FROM Risk P
  LEFT JOIN RiskRoles A ON A.POLICYID = P.ID AND A.TYPE=2
  LEFT JOIN RiskBayer B ON B.ID = P.ID
  LEFT JOIN LOOKUP LKR ON LKR.LOOKUPID = 2000 AND LKR.COMPANYID=P.COMPANYID AND LKR.LANGUAGE=1 AND LKR.CODE = P.LINEOFBUSINESSCODE
  LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 2050 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE = P.STATUS
  LEFT JOIN LOOKUP LKF ON LKF.LOOKUPID = 4000 AND LKF.COMPANYID=P.COMPANYID AND LKF.LANGUAGE=1 AND LKF.CODE = B.MAINPOLICYID
 WHERE P.CompanyId={app.companyid} AND P.STATUS > 1
 ORDER BY P.ISSUEDATE DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (60,1,7,'Productos por compañia',NULL,NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-04-09 12:09:08',NULL,'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT lb.CODE LINE, lb.DESCRIPTION LINEDESC, prd.CODE PROD, prd.DESCRIPTION PRODDESC, prd.EXTENDSTRINGVALUE1 config 
  FROM Lookup prd
  LEFT JOIN Lookup lb ON lb.LookupId=2000 AND lb.CompanyId=prd.CompanyId AND lb.CODE=PRD.PARENTLOOKUPID
 WHERE prd.LookupId=2001 AND prd.CompanyId={app.companyid} AND prd.RecordStatus =1
 ORDER BY prd.QUERYORDER, prd.DESCRIPTION'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (110,1,8,'Resultado Domiciliación','Domiciliación Colones',NULL,NULL,NULL,NULL,1,1,111,TIMESTAMP'2025-05-20 00:00:00',NULL,'tron',1,NULL,NULL,'ReporteDomiciliacion',NULL,TO_CLOB('SELECT ''EGRESOS'' "Tipo de Transaccion", ''CDKEVI1'' "Cod. Cajero", ''SAN PEDRO DE MONTES DE OCA'' "Oficina Comercial", OP.RECEIPT "Transaccion", OP.ISSUEDATE "Fecha", 
       ''CT Cobro'' "Oper.", B.CARD "Ref Doc.", NULL "Cheque", NULL "Cta. Simp", ''COBROS DE RECIBOS'' "Descripcion", OP.POLICYID "Poliza", OP.FIRSTNAME || '' '' || OP.LASTNAME "Tercero", 
       OP.AMOUNT "Importe Local Mon", 1 "Val. Cambio", NULL "Importe Ext.", OP.BILLNUMBER "Num. Recibo", a700.NUM_AVISO "Num. Aviso" 
  FROM ALIADOS.ONLINEPAYMENT OP
  JOIN ALIADOS.BOVEDA B ON DECODE(B.TIP_DOCUM, ''CNA'', 1, ''CRE'', 2, ''PAS'', 3, ''CJU'', 4, NULL)=OP.DOCUMENTTYPE AND B.COD_DOCUM=OP.DOCUMENTNUMBER AND  B.NUM_POLIZA=OP.POLICYID
  JOIN A2990700 a700 ON a700.NUM_RECIBO  = OP.BILLNUMBER  
 WHERE OP.PROVIDERSTATUS =''APPROVED'' AND OP.Source=''Recurring'' AND OP.CURRENCY=1 AND OP.ProcessId={processId:varchar}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (110,2,8,'Resultado Domiciliación','Domiciliación Dólares',NULL,NULL,NULL,NULL,1,1,111,TIMESTAMP'2025-05-20 00:00:00',NULL,'tron',1,NULL,NULL,'ReporteDomiciliacion',NULL,TO_CLOB('SELECT ''EGRESOS'' "Tipo de Transaccion", ''CDKEVI1'' "Cod. Cajero", ''SAN PEDRO DE MONTES DE OCA'' "Oficina Comercial", OP.RECEIPT "Transaccion", OP.ISSUEDATE "Fecha", 
       ''CT Cobro'' "Oper.", B.CARD "Ref Doc.", NULL "Cheque", NULL "Cta. Simp", ''COBROS DE RECIBOS'' "Descripcion", OP.POLICYID "Poliza", OP.FIRSTNAME || '' '' || OP.LASTNAME "Tercero", 
       OP.AMOUNT * A500.VAL_CAMBIO "Importe Local Mon", A500.VAL_CAMBIO "Val. Cambio", OP.AMOUNT "Importe Ext.", OP.BILLNUMBER "Num. Recibo", a700.NUM_AVISO "Num. Aviso"
  FROM ALIADOS.ONLINEPAYMENT OP
  JOIN ALIADOS.BOVEDA B ON DECODE(B.TIP_DOCUM, ''CNA'', 1, ''CRE'', 2, ''PAS'', 3, ''CJU'', 4, NULL)=OP.DOCUMENTTYPE AND B.COD_DOCUM=OP.DOCUMENTNUMBER AND  B.NUM_POLIZA=OP.POLICYID
  JOIN A2990700 a700 ON a700.NUM_RECIBO  = OP.BILLNUMBER
  JOIN A1000500 A500 ON A500.COD_MON=OP.CURRENCY AND A500.FEC_CAMBIO = (SELECT MAX(FEC_CAMBIO) FROM A1000500 WHERE COD_MON=OP.CURRENCY)  
 WHERE OP.PROVIDERSTATUS =''APPROVED'' AND OP.Source=''Recurring'' AND OP.CURRENCY=2 AND OP.ProcessId={processId:varchar}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (110,3,8,'Resultado Domiciliación','Domiciliación Rechazos',NULL,NULL,NULL,NULL,1,1,111,TIMESTAMP'2025-05-20 00:00:00',NULL,'tron',1,NULL,NULL,'ReporteDomiciliacion',NULL,TO_CLOB('SELECT OP.BILLNUMBER "Numero de Recibo", B.CARD "Numero Tarjeta", OP.AMOUNT "Importe Cobro", OP.STATUSDATE "Fecha Cobro", OP.REASON "Observaciones", a700.NUM_AVISO "Numero de Aviso", 
       OP.POLICYID "Numero de Poliza", OP.CURRENCY "Codigo Moneda"
  FROM ALIADOS.ONLINEPAYMENT OP
  JOIN ALIADOS.BOVEDA B ON DECODE(B.TIP_DOCUM, ''CNA'', 1, ''CRE'', 2, ''PAS'', 3, ''CJU'', 4, NULL)=OP.DOCUMENTTYPE AND B.COD_DOCUM=OP.DOCUMENTNUMBER AND  B.NUM_POLIZA=OP.POLICYID
  JOIN A2990700 a700 ON a700.NUM_RECIBO  = OP.BILLNUMBER  
 WHERE OP.PROVIDERSTATUS <> ''APPROVED'' AND OP.Source=''Recurring'' AND OP.ProcessId={processId:varchar}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (110,4,8,'Resultado Domiciliación','Domiciliación Denegadas del mes',NULL,NULL,NULL,NULL,1,1,111,TIMESTAMP'2025-11-24 12:38:00',NULL,'tron',1,NULL,NULL,'ReporteDomiciliacion',NULL,TO_CLOB('WITH UltimoIntentoDePago AS (
SELECT OP.*, ROW_NUMBER() OVER (PARTITION BY OP.BILLNUMBER ORDER BY OP.STATUSDATE DESC) AS RN
  FROM ALIADOS.ONLINEPAYMENT OP 
 WHERE OP.PROVIDERSTATUS=''REJECTED'' AND OP.Source=''Recurring'' AND EXTRACT(MONTH FROM OP.STATUSDATE)=EXTRACT(MONTH FROM SYSDATE))
SELECT DISTINCT OP.ISSUEDATE "Fecha", a700.NUM_AVISO "Nro. Aviso", TRIM(v1390.nom_tercero) || '' '' || TRIM(v1390.ape1_tercero) "Intermediario", OP.POLICYID "Poliza", a700.FEC_EFEC_RECIBO "Fecha Efec. Recibo", 
       OP.BILLNUMBER "Num_recibo", B.CARD "Nro. Tarjeta", B.CARDEXPIRATIONDATE "Vencimiento Tarjeta",
       a700.FEC_VCTO_RECIBO "Vencimiento recibo", a700.TIP_SITUACION  "Estatus. Recibo", a700.FEC_REMESA "Fecha Cobro Recibo", OP.AMOUNT "Imp. Recibo", DECODE(OP.CURRENCY, 1, ''CRC'', 2, ''USD'', NULL)  "Moneda", ''DENEGADA'' "Status", 
       OP.STATUSDATE "Fec. Denegada", OP.REASON "Razón", 
       B.TIP_DOCUM "Tip. Docum", OP.DOCUMENTNUMBER "Cod. Docum", OP.FIRSTNAME || '' '' || OP.LASTNAME "Tomador", OP.PHONENUMBERMOBILE "Telefono", OP.PRIMARYEMAILADDRESS "Email"
  FROM UltimoIntentoDePago OP
  JOIN ALIADOS.BOVEDA B ON DECODE(B.TIP_DOCUM, ''CNA'', 1, ''CRE'', 2, ''PAS'', 3, ''CJU'', 4, NULL)=OP.DOCUMENTTYPE AND B.COD_DOCUM=OP.DOCUMENTNUMBER AND  B.NUM_POLIZA=OP.POLICYID
  JOIN A2990700 a700 ON a700.NUM_RECIBO  = OP.BILLNUMBER
  JOIN A1001332 a1332 ON a1332.cod_cia = a700.COD_CIA AND a1332.COD_AGT = a700.COD_AGT AND a1332.fec_validez <= SYSDATE
  JOIN v1001390 v1390 ON a1332.cod_cia = v1390.cod_cia AND a1332.tip_docum = v1390.tip_docum AND a1332.cod_docum = v1390.cod_docum AND a1332.cod_act_tercero = v1390.cod_act_tercero  
 WHERE OP.RN = 1'));
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
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 113, @_@_)',NULL,'CobrosRechazados','Extend.CobrosRechazados.js',TO_CLOB('SELECT DISTINCT null Sel, OP.POLICYID, OP.BILLNUMBER, OP.AMOUNT, OP.CURRENCY Cod_Mon, OP.STATUSDATE, OP.REASON
  FROM ALIADOS.ONLINEPAYMENT OP
  JOIN ALIADOS.BOVEDA B ON DECODE(B.TIP_DOCUM, ''CNA'', 1, ''CRE'', 2, ''PAS'', 3, ''CJU'', 4, NULL)=OP.DOCUMENTTYPE AND B.COD_DOCUM=OP.DOCUMENTNUMBER AND  B.NUM_POLIZA=OP.POLICYID
  JOIN A2990700 a700 ON a700.NUM_RECIBO  = OP.BILLNUMBER AND a700.TIP_SITUACION IN (''RE'',''EP'') AND a700.TIP_GESTOR =''TA'' AND a700.COD_AGT = {cod_agt} 
 WHERE  OP.STATUSDATE = (SELECT MAX(STATUSDATE) FROM ALIADOS.ONLINEPAYMENT OPM WHERE OPM.BILLNUMBER=OP.BILLNUMBER) AND OP.PROVIDERSTATUS <> ''APPROVED'' AND OP.Source=''Recurring'''));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (120,1,1,'Lista de casos por devolución de dinero','Lista de casos por devolución de dinero',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2025-05-28 19:56:10',TO_CLOB('{
    "title": "Lista de casos por devolución de dinero",
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
                "field": "Caso #",
                "title": "Caso",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.IntegerFormatter"
            },
            {
                "field": "Inicio",
                "title": "Inicio",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateAndTimeFormatter"
            },
            {
                "field": "Completado",
                "title": "Completado",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateAndTimeFormatter"
            },
            {
                "field": "Asunto",
                "title": "Asunto",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Proceso",
                "title": "Proceso",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Descripción",
                "title": "Descripción",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
      ')||TO_CLOB('      },
            {
                "field": "Estado",
                "title": "Estado",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Prioridad",
                "title": "Prioridad",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Tomador",
                "title": "Tomador",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Póliza",
                "title": "Póliza",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Correduria",
                "title": "Correduria",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Categoría",
                "title": "Categoría",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Tipo de variación",
                "title": "Tipo De Variación",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Monto",
                "title": "Monto",
             ')||TO_CLOB('   "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Moneda y cuenta",
                "title": "Moneda y Cuenta",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Indentificación",
                "title": "Indentificación",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Cuenta bancaria",
                "title": "Cuenta Bancaria",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Banco",
                "title": "Banco",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            }
        ]
    }
}'),'Research',1,'|título
|zona|4
 Finalizandos desde+|fecha|default=today;helptext=Fecha de finalización de la etapa de devolución en bancos
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 120, @_@_)',NULL,NULL,NULL,TO_CLOB('WITH FOCUS AS (
SELECT PI.INSTANCEID, PF.NAME, PI.STARTDATE, PI.FINISHDATE
  FROM aliados.PROCESSINSTANCE PI
  JOIN aliados.PROCESSSPECFLOW PF ON PF.COMPANYID = PI.COMPANYID AND PF.ID = PI.FLOWID AND PF.name IN ( ''DEVOLUCIÓN DE DINERO'', ''DEVOLUCIÓN DE DINERO - SAC'', ''DEVOLUCIÓN DE DINERO - COBROS'' )
 WHERE PI.COMPANYID =100 
   AND PI.STEPID = (SELECT PS.ID FROM aliados.PROCESSSPECSTEP PS WHERE PS.flowid = PI.FLOWID AND PS.NAME = ''SE TRAMITA DEVOLUCIÓN EN BANCOS'')
   AND PI.TASKID = 0
   AND TRUNC(PI.FINISHDATE) >= TRUNC({desde:date})
)   
SELECT PC.ID "Caso #", PINIT.STARTDATE "Inicio", F.STARTDATE "Inicio de la etapa de devolución", F.FINISHDATE "Completado de la etapa de devolución", PINIT.FINISHDATE "Completado",
      PC.TITLE "Asunto", F.NAME "Proceso", PC.DESCRIPTION "Descripción", LKS.DESCRIPTION "Estado", LKCP.DESCRIPTION "Prioridad",
      PC.REFERENCE1 "Tomador", PC.REFERENCE2 "Póliza", PC.REFERENCE3 "Correduria", PC.REFERENCE4 "Categoría", PC.REFERENCE5 "Tipo de variación", PC.REFERENCE6 "Monto", PC.REFERENCE7 "Moneda y cuenta", PC.REFERENCE8 "Indentificación", PC.REFERENCE9 "Cuenta bancaria", PC.REFERENCE10 "Banco"
  FROM aliados.PROCESSCASE PC
  JOIN FOCUS F ON F.INSTANCEID = PC.INSTANCEID
  JOIN aliados.PROCESSINSTANCE PINIT ON PINIT.COMPANYID=PC.COMPANYID AND PINIT.INSTANCEID =F.INSTANCEID  AND PINIT.STEPID=0 AND  PINIT.TASKID=0
  LEFT JOIN aliados.LOOKUP LKS ON LKS.LOOKUPID = 61 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE =PC.STATUS
  LEFT JOIN aliados.LOOKUP LKCP ON LKCP.LOOKUPID = 62 AND LKCP.COMPANYID=0 AND LKCP.LANGUAGE=1 AND LKCP.CODE =PC.PRIORITY
  WHERE PC.COMPANYID=100
  ORDER BY PC.ID'));
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
      },
      {
        "field": "FIRSTBILL",
        "title": ')||TO_CLOB('"Primer recibo",
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
"halign": "center",
"align": "center",
"formatter": "app')||TO_CLOB('.ui.StringFormatter"
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
"title": "Riesgo",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringFormatter"
},
{
"field": "NOM_FRACC_PAGO",
"title')||TO_CLOB('": "Fraccionamiento",
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
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (302,1,1,'Detalle de la póliza - Datos generales','Detalle...',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
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
                "title": "No. de póliza",
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
                "')||TO_CLOB('align": "left",
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
				   AND a20.cod_agt = {app.P_COD_AGT}
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
"formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button type=\"button\" name=\"printid\" class=\"btn btn-sm btn-white event\" title=\"Permite imprimir el certificado\"><i class=\"fa fa-print\"></i></button>'' +''</span>'' ;}",
"visible": true,
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
        "formatter": "function (value, row, index, field) { return ''<span class=\"columnBtn\"><button type=\"button\" name=\"print\" class=\"btn btn-sm btn-white event\" title=\"Permite imprimir la poliza\"><i class=\"fa fa-print\"></i></button>'' + ''</span>'' ;}",
        "visible": true,
        "events": true,
        "action_sendemail": "app.ui.ShowSideBar({ title: ''Enviar certificado por correo'', subtitle: ''Poliza #{NUM_POLIZA}'', id: 9000, data: row})"
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
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatt')||TO_CLOB('er",
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
}'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('em_k_jrp_cuadro_poliza_302_mcr.p_lista_certificado_historico {app.p_cod_cia} {P_NUM_POLIZA:varchar}'));
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
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (305,1,1,'Polizas de Caucción','Consultas MAPFRE - Caucción',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2025-07-28 00:00:00',TO_CLOB('{
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
    AND a.cod_ramo = 280
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
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (330,1,1,'Siniestros','Siniestros por agente (Panel)',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-01-23 12:18:19',NULL,'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT a900.NUM_SINI, a900.TIP_EST_SINI, G31A.NOM_VALOR NOM_TIP_EST_SINI, a900.FEC_DENU_SINI,a900.HORA_DENU_SINI, a900.FEC_SINI, a900.HORA_SINI, a900.COD_CAUSA_SINI, G200.NOM_CAUSA, a900.FEC_TERM_SINI, a900.FEC_REAP_SINI, a900.MCA_CULPABLE,a900.TIP_APERTURA,
        a900.COD_RAMO, a1800.NOM_RAMO, a900.NUM_POLIZA, a900.NUM_RIESGO, A2020.VAL_CAMPO Matricula,
       em_f_nom_riesgo_web (a900.cod_cia, a900.num_poliza, a900.num_spto, a900.num_riesgo) nom_riesgo,
       a900.TIP_DOCUM_TOMADOR, a900.COD_DOCUM_TOMADOR, A1399A.NOM_TERCERO NOM_TOMADOR,  A1399A.APE1_TERCERO APE_TOMADOR,
       a900.TIP_DOCUM_ASEG, a900.COD_DOCUM_ASEG, A1399A.NOM_TERCERO NOM_ASEG,  A1399A.APE1_TERCERO APE_ASEG, A1331.EMAIL EMAIL_ASEG,
       a900.TIP_DOCUM_CONTACTO, a900.COD_DOCUM_CONTACTO, a900.NOM_CONTACTO, a900.APE_CONTACTO, a900.TEL_PAIS_CONTACTO, a900.TEL_ZONA_CONTACTO, a900.TEL_NUMERO_CONTACTO, a900.EMAIL_CONTACTO, a900.TIP_RELACION, G31B.NOM_VALOR NOM_TIP_RELACION   
  FROM a7000900 a900
  LEFT JOIN G1010031 G31A ON G31A.COD_CAMPO =''TIP_EST_SINI'' AND G31A.COD_VALOR = a900.TIP_EST_SINI AND G31A.COD_IDIOMA=''ES''
  LEFT JOIN G1010031 G31B ON G31B.COD_CAMPO =''TIP_RELACION'' AND G31B.COD_VALOR = a900.TIP_RELACION AND G31B.COD_IDIOMA=''ES''
  LEFT JOIN A1001399 A1399T ON A1399T.COD_CIA=a900.COD_CIA AND A1399T.TIP_DOCUM = a900.TIP_DOCUM_TOMADOR AND  A1399T.COD_DOCUM = a900.COD_DOCUM_TOMADOR  
  LEFT JOIN A1001399 A1399A ON A1399A.COD_CIA=a900.COD_CIA AND A1399A.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1399A.COD_DOCUM = a900.COD_DOCUM_ASEG
  LEFT JOIN A1001331 A1331 ON A1331.COD_CIA=a900.COD_CIA AND A1331.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1331.COD_DOCUM = a900.COD_DOCUM_ASEG  
  LEFT JOIN a1001800 a1800 ON a1800.COD_CIA=a900.COD_CIA AND a1800.COD_RAMO = a900.COD_RAMO
  LEFT JOIN G7000200 G200 ON G200.COD_CIA = G200.COD_CIA AND G200.TIP_CAUSA = 1 AND G200.COD_CAUSA = a900.COD_CAUSA_SINI
  LEFT JOIN A2000020 A2020 ON A2020.COD_CIA=a900.COD_CIA AND A2020.NUM_POLIZA=a900.NUM_POLIZA AND A2020.NUM_SPTO=0')||TO_CLOB(' AND A2020.NUM_APLI=0 AND A2020.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020.NUM_RIESGO=a900.NUM_RIESGO AND A2020.COD_CAMPO=''NUM_MATRICULA''  
  WHERE a900.COD_CIA={app.P_COD_CIA}
    AND a900.COD_AGT={app.P_COD_AGT}
 ORDER BY a900.FEC_SINI DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (330,2,1,'Expedientes','Expedientes de un siniestro (Panel)',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-01-24 22:30:14',NULL,'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT a1000.NUM_EXP, a1000.TIP_EXP, G90.NOM_EXP,a1000.FEC_APER_EXP, a1000.FEC_TERM_EXP,  a1000.TIP_EST_EXP, G31A.NOM_VALOR NOM_TIP_EST_EXP,
       nvl(a1000.imp_val_inicial,0) IMP_RESERVA, nvl(a1000.imp_val,0) IMP_ESTIMADO, nvl(a1000.imp_liq,0) IMP_LIQUIDADO, nvl(a1000.imp_pag,0) IMP_PAGADO,     
       a1000.TIP_DOCUM, a1000.COD_DOCUM, a1000.NOMBRE, a1000.APELLIDOS
  FROM A7001000 a1000
  LEFT JOIN G7000090 G90 ON G90.COD_CIA = a1000.COD_CIA AND G90.TIP_EXP = a1000.TIP_EXP
  LEFT JOIN G1010031 G31A ON G31A.COD_CAMPO =''TIP_EST_EXP'' AND G31A.COD_VALOR = a1000.TIP_EST_EXP AND G31A.COD_IDIOMA=''ES''
 WHERE a1000.COD_CIA={app.p_cod_cia} AND a1000.NUM_SINI={num_sini} ORDER BY a1000.NUM_EXP'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (330,3,1,'Relato','Relato de un siniestro (Panel)',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-01-26 10:42:31',NULL,'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT TXT_RELATO
FROM A7000971 WHERE COD_CIA={app.p_cod_cia} AND NUM_SINI={num_sini}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (331,1,1,'Reporte de trazabilidad de siniestros en progreso',NULL,NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-02-15 14:47:58',TO_CLOB('{
"title": "Reporte de trazabilidad de siniestros en progreso",
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
    "field": "Siniestro",
    "title": "No. Siniestro",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": true
},
{
    "field": "Expediente",
    "title": "Expediente",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": true
},
{
    "field": "Poliza",
    "title": "No. Póliza",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": true
},
{
    "field": "Asegurado",
    "title": "Asegurado",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringCapitalizeFormatter",
    "visible": true
},
{
    "field": "EMail",
    "title": "Correo",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": false
},
{
    "field": "Creado",
    "title": "Creado",
    "sortable": true,
    "halign": "center",
    "align": "center",
    "formatter": "app.ui.DateAndTimeFormatter",
    "visible": true
},
{
    "field": "Estado",
    "title": "Estado",
    "sortable": true,
    "halign": "center",
    "align": "center",
    "formatter": "app.ui.StringFormatter",
    "visible": true
},
{
    "field": "Etapa",
    "title": "Etapa",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
},
{
    "field": "Desde",
    "title": "Desde",
    "sortable": true,
    "halign": "center",
    "align": "center",
    "formatter": "app.ui.DateAndTimeFormatter",
    "visible": true
},
{
    "field": "')||TO_CLOB('Progreso",
    "title": "% Progreso",
    "sortable": true,
    "halign": "center",
    "align": "center",
    "format": "<div class=''progress progress-mini''><div style=''width: {Progreso}%;'' class=''progress-bar''></div></div><small>{Progreso} % / {Actual}</small>"
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
    "field": "Comentario",
    "title": "Comentario",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": true
},
{
    "field": "Honorarios",
    "title": "Honorarios",
    "sortable": true,
    "halign": "center",
    "align": "right",
    "formatter": "app.ui.DecimalFormatter"
},
{
    "field": "Indenmizacion",
    "title": "Indenmización",
    "sortable": true,
    "halign": "center",
    "align": "right",
    "formatter": "app.ui.DecimalFormatter"
},
{
    "field": "Deducible",
    "title": "Deducible",
    "sortable": true,
    "halign": "center",
    "align": "right",
    "formatter": "app.ui.DecimalFormatter"
},
{
    "field": "Repuestos",
    "title": "Repuestos",
    "sortable": true,
    "halign": "center",
    "align": "right",
    "formatter": "app.ui.DecimalFormatter"
},
{
    "field": "ManoDeObra",
    "title": "Mano de obra",
    "sortable": true,
    "halign": "center",
    "align": "right",
    "formatter": "app.ui.DecimalFormatter"
}
]
}
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB(' SELECT PC.REFERENCE1 "Siniestro", PC.REFERENCE2 "Expediente", PC.REFERENCE3 "Poliza", PC.CONTACTMAINNAME "Asegurado", PC.CONTACTMAINEMAIL "EMail",
       PI.CREATED "Creado", CASE WHEN SS.PROCESSSTATUS=10 THEN ''Inicio'' WHEN SS.PROCESSSTATUS=90 THEN ''Fin'' ELSE ''En progreso'' END "Estado",
       SS.NAME "Etapa",
       ''Etapa '' || TO_CHAR((select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PI.FLOWID AND SSC.ID<=PI.STEPID)) || '' de '' || TO_CHAR((select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PI.FLOWID)) "Actual",
       CAST ((select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PI.FLOWID)/(select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PI.FLOWID AND SSC.ID<=PI.STEPID) AS DECIMAL(5,0)) "Progreso", 
       PI.STARTDATE "Desde", um.FirstName || '' '' || um.LastName "Usuario",   PI.COMMENTS "Comentario",
       PCC.FEE "Honorarios", PCC.COMPENSATION "Indenmizacion", PCC.DEDUCTIBLE "Deducible", PCC.SPAREPARTS "Repuestos",PCC.MANPOWER "ManoDeObra"
  FROM PROCESSINSTANCE PI   
  LEFT JOIN PROCESSCASE PC ON PC.ID=PI.CASEID
  LEFT JOIN PROCESSCASECOMPLEMENT PCC ON PCC.CASEID=PI.CASEID  
  LEFT JOIN PROCESSSPECSTEP SS ON SS.ID=PI.STEPID
  LEFT JOIN UserMember um ON um.UserId = PI.UpdateUserCode
 WHERE PI.ENTITYTYPE=9500 
   AND PI.STEPID>0 AND PI.TASKID=0 AND NOT PI.STARTDATE IS NULL AND PI.FINISHDATE IS NULL 
 ORDER BY PI.CREATED DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (332,1,1,'Reporte de trazabilidad de siniestros II',NULL,NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-05-12 20:36:32',TO_CLOB('{
"title": "Reporte de trazabilidad de siniestros II",
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
    [
        {
            "field": "Ingreso del siniestro",
            "title": "Ingreso",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.DateFormatter",
            "rowspan": 2
        },
        {
            "field": "Siniestro",
            "title": "No. Siniestro",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "rowspan": 2
        },
        {
            "field": "Estado",
            "title": "Estado",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "rowspan": 2
        },
        {
            "field": "Poliza",
            "title": "No. Póliza",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "rowspan": 2
        },
        {
            "field": "Matricula",
            "title": "Matricula",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "rowspan": 2
        },
        {
            "field": "Asegurado",
            "title": "Asegurado",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "rowspan": 2
        },
        {
            "field": "EMail",
            "title": "Correo",
            "sortable": true,
    ')||TO_CLOB('        "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "rowspan": 2
        },
        {
            "field": "Telefono",
            "title": "Teléfono",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "rowspan": 2
        },
        {
            "field": "Taller",
            "title": "Taller",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter",
            "rowspan": 2
        },
        {
            "title": "Informe de reparación",
            "colspan": 4,
            "align": "center"
        },
        {
            "title": "Repuestos no indispensables",
            "colspan": 8,
            "align": "center"
        },
        {
            "title": "Liquidación",
            "colspan": 8,
            "align": "center"
        }
    ],
    [
        {
            "field": "RepRep Fecha",
            "title": "Fecha IR",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.DateFormatter"
        },
        {
            "field": "RepRep Monto total",
            "title": "Monto total IR",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalWithZeroFormatter"
        },
        {
            "field": "RepRep Repuestos",
            "title": "Repuestos IR",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalWithZeroFormatter"
        },
        {
            "field": "RepRep ManoDeObra",
            "title": "Mano de obra IR",
            "sortable": true,
            "halign": "center",
            "ali')||TO_CLOB('gn": "right",
            "formatter": "app.ui.DecimalWithZeroFormatter"
        },
        {
            "field": "Rep No Ind Fecha",
            "title": "Fecha de la liquidación parcial",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.DateFormatter"
        },
        {
            "field": "Rep No Ind Honorarios",
            "title": "Honorarios Parciales",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalWithZeroFormatter"
        },
        {
            "field": "Rep No Ind  Indenmizacion",
            "title": "Indenmizacion",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalWithZeroFormatter"
        },
        {
            "field": "Rep No Ind  Deducible",
            "title": "Deducible",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalWithZeroFormatter"
        },
        {
            "field": "Rep No Ind  Fact Repuestos",
            "title": "Factura repuestos Parcial",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter"
        },
        {
            "field": "Rep No Ind  Repuestos",
            "title": "Repuestos Parcial",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalWithZeroFormatter"
        },
        {
            "field": "Rep No Ind  Fact ManoDeObra",
            "title": "Factura mano de obra Parcial",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter"
        },
        {
            "field": "')||TO_CLOB('Rep No Ind  ManoDeObra",
            "title": "Mano de obra Parcial",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalWithZeroFormatter"
        },
        {
            "field": "Liq Fecha",
            "title": "Fecha",
            "sortable": true,
            "halign": "center",
            "align": "center",
            "formatter": "app.ui.DateFormatter"
        },
        {
            "field": "Liq Honorarios",
            "title": "Honorarios",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalWithZeroFormatter"
        },
        {
            "field": "Liq Indenmizacion",
            "title": "Indenmizacion",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalWithZeroFormatter"
        },
        {
            "field": "Liq Deducible",
            "title": "Deducible",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalWithZeroFormatter"
        },
        {
            "field": "Liq Fact Repuestos",
            "title": "Factura repuestos",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter"
        },
        {
            "field": "Liq Repuestos",
            "title": "Repuestos",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalWithZeroFormatter"
        },
        {
            "field": "Liq Fact ManoDeObra",
            "title": "Factura mano de obra",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "formatter": "app.ui.StringFormatter"
       ')||TO_CLOB(' },
        {
            "field": "Liq ManoDeObra",
            "title": "Mano de obra",
            "sortable": true,
            "halign": "center",
            "align": "right",
            "formatter": "app.ui.DecimalWithZeroFormatter"
        }
    ]
]
}
}'),'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT a900.FEC_SINI "Ingreso del siniestro", PC.REFERENCE1 "Siniestro", LKS.DESCRIPTION "Estado", a900.NUM_POLIZA "Poliza", A2020.VAL_CAMPO "Matricula", PC.CONTACTMAINNAME "Asegurado", PC.CONTACTMAINEMAIL "EMail", A1331.TLF_NUMERO "Telefono", TalleresLkP.Description "Taller",
       PCC.REPORTDATE "RepRep Fecha", PCC.REPAIRTOTALAMOUNT "RepRep Monto total",  PCC.REPAIRSPAREPARTS "RepRep Repuestos",PCC.REPAIRMANPOWER "RepRep ManoDeObra",
       PCC.SetSpaSettlementDate "Rep No Ind Fecha", PCC.SetSpaFee "Rep No Ind Honorarios", PCC.SetSpaCompensation "Rep No Ind  Indenmizacion", PCC.SetSpaDeductible "Rep No Ind  Deducible", PCC.SetSpaSpareParts "Rep No Ind  Repuestos", PCC.SetSpaSparePartsInvoice "Rep No Ind  Fact Repuestos",PCC.SetSpaManPower "Rep No Ind  ManoDeObra", PCC.SetSpaManPowerInvoice "Rep No Ind  Fact ManoDeObra",
       PCC.SETTLEMENTDATE "Liq Fecha", PCC.FEE "Liq Honorarios", PCC.COMPENSATION "Liq Indenmizacion", PCC.DEDUCTIBLE "Liq Deducible", PCC.SPAREPARTS "Liq Repuestos", PCC.SPAREPARTSINVOICE "Liq Fact Repuestos",PCC.MANPOWER "Liq ManoDeObra", PCC.MANPOWERINVOICE "Liq Fact ManoDeObra"      
  FROM ALIADOS.PROCESSCASE PC
  LEFT JOIN ALIADOS.PROCESSCASECOMPLEMENT PCC ON PCC.CASEID=PC.ID
  LEFT JOIN ALIADOS.LOOKUP TalleresLkP ON TalleresLkP.LOOKUPID = 4100 AND TalleresLkP.LANGUAGE=1 AND TalleresLkP.PARENTLOOKUPID=0 AND TalleresLkP.CODE=PCC.WORKSHOP
  LEFT JOIN ALIADOS.LOOKUP LKS ON LKS.LOOKUPID = 61 AND LKS.LANGUAGE=1 AND LKS.CODE =PC.STATUS  
  LEFT JOIN a7000900 a900 ON a900.COD_CIA=1 AND a900.NUM_SINI=PC.REFERENCE1
  LEFT JOIN A1001331 A1331 ON A1331.COD_CIA=a900.COD_CIA AND A1331.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1331.COD_DOCUM = a900.COD_DOCUM_ASEG  
  LEFT JOIN A2000020 A2020 ON A2020.COD_CIA=a900.COD_CIA AND A2020.NUM_POLIZA=a900.NUM_POLIZA AND A2020.NUM_SPTO=0 AND A2020.NUM_APLI=0 AND A2020.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020.NUM_RIESGO=a900.NUM_RIESGO AND A2020.COD_CAMPO=''NUM_MATRICULA''  
 WHERE PC.FLOWID=1 AND PC.COMPANYID={app.comp')||TO_CLOB('anyid} AND PC.REFERENCE2=''PPC''
 ORDER BY a900.FEC_SINI DESC'));
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
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (340,1,1,'Controles t?cnicos','Pendientes',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 21:35:45',TO_CLOB('{
    "title": "Pendientes",
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
                "title": "No. Poliza grupo",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NUM_CONTRATO",
                "title": "Contrato",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NUM_POLIZA",
                "title": "No. Poliza",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NUM_SPTO",
                "title": "No. Suplemento",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.IntegerWithZeroFormatter",
                "visible": true
            },
            {
                "field": "COD_DOCUM",
                "title": "Asegurado",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true,
                "format": "{COD_DOCUM} - {NOMBRE_ASEG}"
            },
            {
                "field": "NOM_ACREEDOR",
                "title": "A')||TO_CLOB('creedor",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NOM_PAGADOR",
                "title": "Pagador",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NOM_FRACC_PAGO",
                "title": "Fraccionamiento",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "PRIMA_TOTAL",
                "title": "Prima Total",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "COD_ERROR",
                "title": "Causa del control",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "visible": true,
                "format": "{COD_ERROR} - {NOM_ERROR}"
            },
            {
                "title": "Acciones",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "function (value, row, index, field) { return ''<span class=columnBtn>'' + ''<button type=\"button\" name=\"ctroltec\" class=\"btn btn-sm btn-white event\" title=\"Permite procesar un control t?cnico\"><i class=\"fa fa-check\"></i></button>''+''<button type=\"button\" name=\"print\" class=\"btn btn-sm btn-white event\" title=\"Permite imprimir la poliza\"><i class=\"fa fa-print\"></i></button>''+''</s')||TO_CLOB('pan>'' ;}",
                "visible": true,
                "events": true,
                "action_ctroltec": "app.ui.ShowSideBar({ title: ''Control t?cnico'', subtitle: ''Poliza #{NUM_POLIZA}'', id: 9004, data: row, callback: ''app.Ex_Policy.ControlTecnico_Init'', width: ''400px''})"
            }
        ]
    }
}'),'Tron',1,NULL,NULL,NULL,'Extend.Policy.js',TO_CLOB('SELECT distinct a21.num_poliza, y.nom_ramo, a21.num_spto, a21.cod_error,
                g20.nom_error, a21.mca_autorizacion, a60.cod_docum,
                a100.nom_tercero || '' '' || a100.ape1_tercero || '' '' || a100.ape2_tercero NOMBRE_ASEG,
                em_k_Mapfre_Query_Contract_mcr.f_search_name_client_tip_benef(a30.num_poliza,''8'') nom_acreedor,
                em_k_Mapfre_Query_Contract_mcr.f_search_name_client_tip_benef(a30.num_poliza,''21'') nom_pagador,
                a30.num_poliza_grupo, a30.num_contrato, a21.fec_autorizacion,  a1402.nom_fracc_pago,
                F_PRIMA_TOTAL_MCR(a30.num_poliza) prima_total
FROM A2000221 a21,
     G2000211 g20,
     a2000060 a60,
     a1001399 a100,
     a1001403 a1403,
     a1001402 a1402,
     a2000030 a30
LEFT JOIN a1001800 y ON y.cod_cia = a30.cod_cia AND y.cod_ramo = a30.cod_ramo
WHERE  a21.COD_CIA = 1
AND    a21.COD_SISTEMA = 2
AND    a21.MCA_AUTORIZACION = ''N''
AND    a21.NUM_POLIZA IN
     (SELECT NUM_POLIZA
       FROM   A2000030
       WHERE  COD_CIA = 1
       AND    COD_AGT = {app.P_COD_AGT})
--AND    a21.cod_error in (3030,549)
AND    A21.COD_ERROR = G20.COD_ERROR
AND    a60.num_poliza = a21.num_poliza
AND    a60.tip_benef = 2
AND    a100.cod_docum = a60.cod_docum
---Poliza Grupo
AND    a30.cod_agt = {app.P_COD_AGT}
AND    a30.num_poliza = a21.num_poliza
---Fraccionamiento de Pago
and a30.cod_cia = a1403.cod_cia
and a30.cod_mon = a1403.cod_mon
and a30.cod_ramo = a1403.cod_ramo
and a30.cod_fracc_pago = a1403.cod_fracc_pago
and a1403.cod_cia = a1402.cod_cia
and a1403.cod_fracc_pago = a1402.cod_fracc_pago'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (340,2,1,'Controles t?cnicos','Procesados',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 21:35:45',TO_CLOB('{
    "title": "Procesados",
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
                "title": "No. P?liza",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NUM_SPTO",
                "title": "No. Suplemento",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DecimalFormatter",
                "visible": true
            },
            {
                "field": "COD_ERROR",
                "title": "Causa del control",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "visible": true,
                "format": "{COD_ERROR} - {NOM_ERROR}"
            },
            {
                "field": "FEC_AUTORIZACION",
                "title": "Autorizado",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter",
                "visible": true
            },
            {
                "field": "COD_USR_AUTORIZACION",
                "title": "Autorizado por",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "OBS_AUTORIZACION",
                "title": "Observaci?n",
                "sortable": true,
  ')||TO_CLOB('              "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            }
        ]
    }
}'),'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT a21.num_poliza,
     a21.num_spto,
     a21.cod_error,
     g20.nom_error,
     a21.mca_autorizacion,
     a21.fec_autorizacion,
     a21.cod_usr_autorizacion,
     a21.obs_autorizacion
FROM   A2000221 a21, G2000211 g20
WHERE  a21.COD_CIA = 1
AND    a21.COD_SISTEMA = 2
AND    a21.MCA_AUTORIZACION = ''S''
AND    a21.NUM_POLIZA IN
     (SELECT NUM_POLIZA
       FROM   A2000030
       WHERE  COD_CIA = 1
       AND    COD_AGT = {app.P_COD_AGT})
AND    A21.COD_ERROR = G20.COD_ERROR
ORDER BY a21.fec_autorizacion DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (341,1,1,'Renovaci?n de p?lizas','Renovaci?n de p?lizas',NULL,NULL,NULL,NULL,1,1,888,TIMESTAMP'2023-03-31 00:00:00',TO_CLOB('{
    "title": "Renovaci?n de p?lizas",
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
                "title": "No. P?liza",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "ABR_RAMO",
                "title": "Ramo",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "field": "NOM_COMPLETO",
                "title": "Contratante",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "format": "{IDENTIFICACION} {NOM_COMPLETO}",
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
                "field": "NOM_RIESGO",
                "title": "Riesgo",
                "sortable": true,
               ')||TO_CLOB(' "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "title": "Acciones",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "function (value, row, index, field) { return ''<span class=columnBtn>'' + ''<button type=\"button\" name=\"renovarPol\" class=\"btn btn-sm btn-white event\" title=\"Permite renovar una p?liza\"><i class=\"fa fa-step-forward\"></i></button>''+''</span>'' ;}",
                "visible": true,
                "events": true,
                "action_renovarPol": "app.ui.ShowSideBar({ title: ''Renovar la p?liza'', subtitle: ''#{NUM_POLIZA}'', id: 9005, data: row, width: ''400px''})"
            }
        ]
    }
}'),'Tron',2,NULL,NULL,NULL,'Extend.Policy.js',TO_CLOB('EM_K_TABLES_CONTRACT_MCR.p_lee_polizas_cotz_13_meses {app.P_COD_CIA} {app.P_COD_AGT}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (350,1,1,'Siniestros','Siniestros por agente',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-01-23 12:18:19',TO_CLOB('{
  "title": "Siniestros",
  "table": {
    "skipload": false,
    "extendName": "ExtendClaims",
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
    "detailId": 351,
    "detailParameters": "num_sini=NUM_SINI",
    "columns": [{
        "title": "No. Siniestro",
        "halign": "center",
        "align": "center",
        "formatter": "app.ExtendClaims.NUM_SINIFormatter",
        "visible": true,
        "events": true,
        "action_viewClaim": "app.ExtendClaims.ShowClaimDetail(row)",
		"action_viewPlan": "app.ExtendClaims.ShowClaimPlan(row)"
      },
      {
        "field": "ASIGES",
        "title": "ASIGES",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ExtendClaims.ASIGESFormatter",
        "visible": true,
        "events": true,
        "action_viewClaimPanel": "app.ExtendClaims.ShowClaimPanel(row)"
      },
      {
        "field": "TIPODEINDEMNIZACION",
        "title": "Tipo de indemnizaci?n",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "cellStyle": "app.ExtendClaims.NOM_TIP_EST_SINICellStyle",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter"
      },
      {
        "field": "FEC_SINI",
        "title": "Ocurrencia",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ExtendClaims.FEC_SINIFormatter"
      },
      {
        "field": "NOM_CAUSA",
        "title": "Causa",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter"
      },
      {
        "field": "NOM_TIP_EST_SINI",
        "title": "Estado",
        "titleTooltip": "Estado MAPFRE",
        "sortable": true,
        "halign": "center",
        "ali')||TO_CLOB('gn": "center",
        "cellStyle": "app.ExtendClaims.NOM_TIP_EST_SINICellStyle",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter"
      },
      {
        "field": "NUM_POLIZA",
        "title": "No. P?liza",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ExtendClaims.NUM_POLIZAFormatter",
        "visible": true,
        "events": true,
        "action_viewPolicy": "app.ExtendClaims.ShowPolicyDetail(row)",
      },
      {
        "field": "MATRICULA",
        "title": "Placa",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "NOM_ASEG",
        "title": "Asegurado",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ExtendClaims.NOM_ASEG2Formatter",
        "events": true,
        "action_viewTercero": "app.ExtendClaims.ShowTercero(row)",
      },
      {
        "field": "COD_DOCUM_ASEG",
        "visible": false
      },
      {
        "field": "APE_ASEG",
        "visible": false
      },
      {
        "field": "NUM_SINI",
        "title": "Detalle",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ExtendClaims.SINIDetailFormatter",
        "visible": false
      }
    ]
  }
}'),'Tron',1,'|titulo
|zona|4
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Filtrar|Boton|class=btn-form btn-primary btn-QueryFilter;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 350, @_@_)',NULL,NULL,'Extend.Claims.js',TO_CLOB('SELECT a900.NUM_SINI, a80.NUM_EXP, a80.OBS ASIGES, a900.TIP_EST_SINI, G31A.NOM_VALOR NOM_TIP_EST_SINI, L.DESCRIPTION TIPODEINDEMNIZACION, a900.FEC_DENU_SINI,a900.HORA_DENU_SINI, a900.FEC_SINI, a900.HORA_SINI, a900.COD_CAUSA_SINI, G200.NOM_CAUSA, a900.FEC_TERM_SINI, a900.FEC_REAP_SINI, a900.MCA_CULPABLE,a900.TIP_APERTURA,
        a900.COD_RAMO, a1800.NOM_RAMO, a900.NUM_POLIZA, a900.NUM_SPTO, a900.NUM_APLI, a900.NUM_SPTO_APLI, a900.NUM_RIESGO, A2020.VAL_CAMPO Matricula,
       em_f_nom_riesgo_web (a900.cod_cia, a900.num_poliza, a900.num_spto, a900.num_riesgo) nom_riesgo,
       a900.TIP_DOCUM_TOMADOR, a900.COD_DOCUM_TOMADOR, A1399A.NOM_TERCERO NOM_TOMADOR,  A1399A.APE1_TERCERO APE_TOMADOR,
       a900.TIP_DOCUM_ASEG, a900.COD_DOCUM_ASEG, A1399A.NOM_TERCERO NOM_ASEG,  A1399A.APE1_TERCERO APE_ASEG, A1331.EMAIL EMAIL_ASEG,
       a900.TIP_DOCUM_CONTACTO, a900.COD_DOCUM_CONTACTO, a900.NOM_CONTACTO, a900.APE_CONTACTO, a900.TEL_PAIS_CONTACTO, a900.TEL_ZONA_CONTACTO, a900.TEL_NUMERO_CONTACTO, a900.EMAIL_CONTACTO, a900.TIP_RELACION, G31B.NOM_VALOR NOM_TIP_RELACION
  FROM a7000900 a900
  LEFT JOIN G1010031 G31A ON G31A.COD_CAMPO =''TIP_EST_SINI'' AND G31A.COD_VALOR = a900.TIP_EST_SINI AND G31A.COD_IDIOMA=''ES''
  LEFT JOIN G1010031 G31B ON G31B.COD_CAMPO =''TIP_RELACION'' AND G31B.COD_VALOR = a900.TIP_RELACION AND G31B.COD_IDIOMA=''ES''
  LEFT JOIN A1001399 A1399T ON A1399T.COD_CIA=a900.COD_CIA AND A1399T.TIP_DOCUM = a900.TIP_DOCUM_TOMADOR AND  A1399T.COD_DOCUM = a900.COD_DOCUM_TOMADOR
  LEFT JOIN A1001399 A1399A ON A1399A.COD_CIA=a900.COD_CIA AND A1399A.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1399A.COD_DOCUM = a900.COD_DOCUM_ASEG
  LEFT JOIN A1001331 A1331 ON A1331.COD_CIA=a900.COD_CIA AND A1331.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1331.COD_DOCUM = a900.COD_DOCUM_ASEG
  LEFT JOIN a1001800 a1800 ON a1800.COD_CIA=a900.COD_CIA AND a1800.COD_RAMO = a900.COD_RAMO
  LEFT JOIN G7000200 G200 ON G200.COD_CIA = G200.COD_CIA AND G200.TIP_CAUSA = 1 AND G200.COD_CAUSA = a900.COD_CAUSA_SINI
  LEFT ')||TO_CLOB('JOIN A2000020 A2020 ON A2020.COD_CIA=a900.COD_CIA AND A2020.NUM_POLIZA=a900.NUM_POLIZA AND A2020.NUM_SPTO=0 AND A2020.NUM_APLI=0 AND A2020.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020.NUM_RIESGO=a900.NUM_RIESGO AND A2020.COD_CAMPO=''NUM_MATRICULA''
  LEFT JOIN A7001080 a80 ON a80.COD_CIA=a900.COD_CIA AND a80.NUM_SINI=a900.NUM_SINI AND NOT a80.OBS IS NULL
  LEFT JOIN ALIADOS.PURDYPANELEVENTO E ON E.NUM_SINI=a900.NUM_SINI AND E.NUM_EXP=a80.NUM_EXP AND E.ASIGES=a80.OBS
  LEFT JOIN ALIADOS.LOOKUP L ON L.LOOKUPID=4101 AND L.CODE=E.TIPODEINDEMNIZACION
  WHERE a900.COD_CIA={app.P_COD_CIA}
    AND a900.COD_AGT={app.P_COD_AGT}
    AND trunc(a900.FEC_SINI) BETWEEN {desde:date} AND {hasta:date}
 ORDER BY a900.FEC_SINI DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (351,1,1,'Expedientes','Expedientes del siniestro',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-01-24 22:30:14',TO_CLOB('{
  "title": "Expedientes del siniestro #{NUM_SINI}",
  "table": {
    "pagination": true,
    "search": false,
    "showToggle": false,
    "showRefresh": true,
    "showColumns": false,
    "showExport": false,
    "showPaginationSwitch": false,
    "exportTypes": [
      "csv",
      "excel"
    ],
    "detailId": 353,
    "detailParameters": "num_sini=NUM_SINI:num_exp=NUM_EXP",
    "columns": [
      {
        "field": "NOM_EXP",
        "title": "Expediente",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ExtendClaims.NOM_EXPFormatter",
        "events": true,
        "action_viewClaimExp": "app.ExtendClaims.ShowExpedienteDetail(row)"
      },
      {
        "field": "NOM_TIP_EST_EXP",
        "title": "Estado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.StringCapitalizeFormatter"
      },
      {
        "field": "FEC_APER_EXP",
        "title": "Apertura",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter"
      },
      {
        "field": "FEC_TERM_EXP",
        "title": "Termino",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateFormatter"
      },
      {
        "field": "IMP_RESERVA",
        "title": "Reserva",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalWithZeroFormatter"
      },
      {
        "field": "IMP_ESTIMADO",
        "title": "Estimado",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalWithZeroFormatter",
        "visible": false
      },
      {
        "field": "IMP_LIQUIDADO",
        "title": "Liquidado",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalWithZeroFormatter",
 ')||TO_CLOB('       "visible": false
      },
      {
        "field": "IMP_PAGADO",
        "title": "Pagado",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.DecimalWithZeroFormatter",
        "visible": false
      }
    ]
  }
}'),'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT a1000.NUM_SINI, a1000.NUM_EXP, a1000.TIP_EXP, G90.NOM_EXP,a1000.FEC_APER_EXP, a1000.FEC_TERM_EXP,  a1000.TIP_EST_EXP, G31A.NOM_VALOR NOM_TIP_EST_EXP,
       nvl(a1000.imp_val_inicial,0) IMP_RESERVA, nvl(a1000.imp_val,0) IMP_ESTIMADO, nvl(a1000.imp_liq,0) IMP_LIQUIDADO, nvl(a1000.imp_pag,0) IMP_PAGADO,
       a1000.TIP_DOCUM, a1000.COD_DOCUM, a1000.NOMBRE, a1000.APELLIDOS
  FROM A7001000 a1000
  LEFT JOIN G7000090 G90 ON G90.COD_CIA = a1000.COD_CIA AND G90.TIP_EXP = a1000.TIP_EXP
  LEFT JOIN G1010031 G31A ON G31A.COD_CAMPO =''TIP_EST_EXP'' AND G31A.COD_VALOR = a1000.TIP_EST_EXP AND G31A.COD_IDIOMA=''ES''
 WHERE a1000.COD_CIA={app.p_cod_cia} AND a1000.NUM_SINI={num_sini} ORDER BY a1000.NUM_EXP'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (352,1,1,'Reporte Capita','Para Purdy Corredora',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'2024-02-06 11:15:54',TO_CLOB('{
"title": "Reporte de Capita",
"table": {
   "skipfirstload": true,   
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
    "title": "No. Poliza",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
 },
 {
    "field": "NUM_POLIZA_GRUPO",
    "title": "Poliza Grupo",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
 },
 {
    "field": "NUM_CONTRATO",
    "title": "Contrato",
    "sortable": true,
    "halign": "center",
    "align": "center"
 },
 {
    "field": "NOM_TOMADOR",
    "title": "Tomador",
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
    "field": "NOM_PAGADOR",
    "title": "Pagador",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
 },
 {
    "field": "COD_MON",
    "title": "Moneda",
    "sortable": true,
    "halign": "center",
    "align": "center"
 },
 {
    "field": "COD_FRACC_PAGO",
    "title": "Fraccionamiento",
    "sortable": true,
    "halign": "center",
    "align": "center"
 },
 {
    "field": "NUM_RECIBO",
    "title": "Recibo",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "IMP_RECIBO",
    "title": "Monto",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "FEC_EFEC_RECIBO",
    "title": "Fecha de Efecto",
    "sortable": true,
    "halign": "center",
    "align": "center",
    "formatter": "app.ui.DateFormatter"
 },
 {
    "field": "FEC')||TO_CLOB('_VCTO_RECIBO",
    "title": "Fecha de Vencimiento",
    "sortable": true,
    "halign": "center",
    "align": "center",
    "formatter": "app.ui.DateFormatter"
 },
 {
    "field": "FEC_PAGO_RECIBO",
    "title": "Fecha de Pago",
    "sortable": true,
    "halign": "center",
    "align": "center",
    "formatter": "app.ui.DateFormatter"
 },
 {
    "field": "IMP_COM_TOTAL",
    "title": "Comision Total",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "COBERTURA",
    "title": "Cobertura",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
 },
 {
    "field": "PRIMA_NETA",
    "title": "Prima Neta",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "INEC",
    "title": "Inec",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "BOMBEROS",
    "title": "Bomberos",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "IVA",
    "title": "Iva",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "PRIMA_BRUTA",
    "title": "Prima Bruta",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "PRIMA_SIN_IVA",
    "title": "Prima Sin Iva",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "RECARGO_FINANCIERO",
    "title": "Recargo",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "COMISION_INTERMEDIACION",
    "title": "Comision Intermediacion",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "COMISION_ACREEDOR",
    "title": "Comision Acreedor",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "PCT_COMIS_ACREEDOR",
    "title": "Porcentaje Acreedor",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "COMISION_COBRO_DE_MAS",
    ')||TO_CLOB('"title": "Comision de mas",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "MAPFRE_SIN_BOMBEROS_INEC_PATEN",
    "title": "MAPFRE_sin_bomberos_inec_paten",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "MAPFRE_SIN_BOMBEROS_INEC_PATEN",
    "title": "MAPFRE_sin_bomberos_inec_paten",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "PRIMA_PURDY",
    "title": "Prima Purdy",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "CAT_IMP",
    "title": "CAT_IMP",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "FEE_IMP",
    "title": "FEE_IMP",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "COMISION_COBRO_BANCO",
    "title": "Comision cobro Banco",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "COMISION_INTERMEDIACION_PURDY",
    "title": "Comision intermediacion Purdy",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "TOTAL_PM",
    "title": "TOTAL_PM",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "MCA_POLMODELO_PURDY",
    "title": "MCA_POLMODELO_PURDY",
    "sortable": true,
    "halign": "center",
    "align": "left"
 },
 {
    "field": "MESES_GRATIS",
    "title": "MESES_GRATIS",
    "sortable": true,
    "halign": "center",
    "align": "left"
 }             
]
}
}'),'Tron',2,'|titulo
|zona|4
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 352, @_@_)',NULL,NULL,NULL,TO_CLOB('gc_k_reporte_capita_mcr.p_consulta_web {const.1} {desde:date} {hasta:date} {const.} {const.S}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (353,1,1,'Plan de tramitaci?n','Plan de tramitaci?n',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-01-24 22:30:14',TO_CLOB('{
  "title": "Plan de tramitaci?n",
  "table": {
    "pagination": true,
    "search": false,
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
        "field": "NIVEL",
        "title": "Nivel",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter",
        "width": 20,
        "widthUnit": "%"
      },
      {
        "field": "TRAMITE",
        "title": "Tramite",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter",
        "width": 15,
        "widthUnit": "%"
      },
      {
        "field": "OBSERVACIONES",
        "title": "Observaciones",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ExtendClaims.ObservacionesFormatter",
        "width": 65,
        "widthUnit": "%"
      }
    ]
  }
}'),'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT DISTINCT q.NUM_exp, s.NOM_NIVEL nivel, t.nom_tramite tramite, LISTAGG(TO_CHAR(q.fec_actu, ''DD/MM/YY HH:MMAM'') || '' '' ||q.obs_tramite, '', '') within GROUP(ORDER BY q.fec_actu) AS observaciones
  FROM A7500000 q
  JOIN G7500020 t ON t.cod_tramite = q.cod_tramite
  JOIN G7500010 s ON s.cod_cia = q.cod_cia AND s.cod_nivel = q.cod_nivel
 WHERE q.cod_cia = {app.p_cod_cia}
   AND q.num_sini = {num_sini}
   AND q.num_exp = {num_exp}
   AND q.tip_est_tramite NOT IN (''IN'')
 GROUP BY q.NUM_exp, s.NOM_NIVEL, q.num_exp, t.nom_tramite'));
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
"field":')||TO_CLOB(' "NOM_TOMADOR",
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
         --AND a.cod_ramo           in (194, 401, 117)
         AND a.mca_spto_anulado   = ''N''
         AND a.mca_poliza_anulada = ''N''
         AND a.mca_pr')||TO_CLOB('ovisional    = ''N''
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
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (361,1,1,'Siniestros','Siniestros version 2',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-07-24 14:38:50',TO_CLOB('{
  "title": "Siniestros",
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
    "columns": [{
        "title": "No. Siniestro",
        "halign": "center",
        "align": "center",
        "formatter": "app.ExtendClaims.NUM_SINIFormatter",
        "visible": true,
        "events": true,
        "action_viewClaim": "app.ExtendClaims.ShowClaimDetail(row)",
      },   
      {
        "field": "FEC_SINI",
        "title": "Ocurrencia",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ExtendClaims.FEC_SINIFormatter"
      },
      {
        "field": "NOM_CAUSA",
        "title": "Causa",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter"
      },
      {
        "field": "NOM_TIP_EST_SINI",
        "title": "Estado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "cellStyle": "app.ExtendClaims.NOM_TIP_EST_SINICellStyle",
        "formatter": "app.ui.StringCapitalizeEachWordFormatter"
      },
            {
                "field": "NOM_EXP",
                "title": "Expediente",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ExtendClaims.NOM_EXPFormatter",
                "events": true,
                "action_viewClaimExp": "app.ExtendClaims.ShowExpedienteDetail(row)"
            },        
      {
        "field": "NUM_POLIZA",
        "title": "No. Póliza",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ExtendClaims.NUM_POLIZAFormatter",
        "visible": true,
    ')||TO_CLOB('    "events": true,
        "action_viewPolicy": "app.ExtendClaims.ShowPolicyDetail(row)",
      },
      {
        "field": "NOM_ASEG",
        "title": "Asegurado",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ExtendClaims.NOM_ASEG2Formatter",
        "events": true,
        "action_viewTercero": "app.ExtendClaims.ShowTercero(row)"        
      },
      {"field": "NUM_SINI", "visible": false},      
      {"field": "ASIGES", "visible": false},
      {"field": "COD_DOCUM_ASEG", "visible": false},
      {"field": "APE_ASEG", "visible": false},
      {"field": "MATRICULA", "visible": false}
    ]
  }
}'),'Tron',1,NULL,NULL,NULL,'Extend.Claims.js',TO_CLOB('   SELECT a900.NUM_SINI, a80.OBS ASIGES, a900.TIP_EST_SINI, G31A.NOM_VALOR NOM_TIP_EST_SINI, a900.FEC_DENU_SINI,a900.HORA_DENU_SINI, a900.FEC_SINI, a900.HORA_SINI, a900.COD_CAUSA_SINI, G200.NOM_CAUSA, a900.FEC_TERM_SINI, a900.FEC_REAP_SINI, a900.MCA_CULPABLE,a900.TIP_APERTURA,
        a900.COD_RAMO, a1800.NOM_RAMO, a900.NUM_POLIZA, a900.NUM_SPTO, a900.NUM_APLI, a900.NUM_SPTO_APLI, a900.NUM_RIESGO, A2020.VAL_CAMPO Matricula,
       em_f_nom_riesgo_web (a900.cod_cia, a900.num_poliza, a900.num_spto, a900.num_riesgo) nom_riesgo,
       a900.TIP_DOCUM_TOMADOR, a900.COD_DOCUM_TOMADOR, A1399A.NOM_TERCERO NOM_TOMADOR,  A1399A.APE1_TERCERO APE_TOMADOR,
       a900.TIP_DOCUM_ASEG, a900.COD_DOCUM_ASEG, A1399A.NOM_TERCERO NOM_ASEG,  A1399A.APE1_TERCERO APE_ASEG, A1331.EMAIL EMAIL_ASEG,
       a900.TIP_DOCUM_CONTACTO, a900.COD_DOCUM_CONTACTO, a900.NOM_CONTACTO, a900.APE_CONTACTO, a900.TEL_PAIS_CONTACTO, a900.TEL_ZONA_CONTACTO, a900.TEL_NUMERO_CONTACTO, a900.EMAIL_CONTACTO, a900.TIP_RELACION, G31B.NOM_VALOR NOM_TIP_RELACION,
       a1000.NUM_EXP, a1000.TIP_EXP, G90.NOM_EXP,a1000.FEC_APER_EXP, a1000.FEC_TERM_EXP,  a1000.TIP_EST_EXP, G31EA.NOM_VALOR NOM_TIP_EST_EXP,
       nvl(a1000.imp_val_inicial,0) IMP_RESERVA, nvl(a1000.imp_val,0) IMP_ESTIMADO, nvl(a1000.imp_liq,0) IMP_LIQUIDADO, nvl(a1000.imp_pag,0) IMP_PAGADO,
       a1000.TIP_DOCUM, a1000.COD_DOCUM, a1000.NOMBRE, a1000.APELLIDOS       
  FROM a7000900 a900
  LEFT JOIN G1010031 G31A ON G31A.COD_CAMPO =''TIP_EST_SINI'' AND G31A.COD_VALOR = a900.TIP_EST_SINI AND G31A.COD_IDIOMA=''ES''
  LEFT JOIN G1010031 G31B ON G31B.COD_CAMPO =''TIP_RELACION'' AND G31B.COD_VALOR = a900.TIP_RELACION AND G31B.COD_IDIOMA=''ES''
  LEFT JOIN A1001399 A1399T ON A1399T.COD_CIA=a900.COD_CIA AND A1399T.TIP_DOCUM = a900.TIP_DOCUM_TOMADOR AND  A1399T.COD_DOCUM = a900.COD_DOCUM_TOMADOR
  LEFT JOIN A1001399 A1399A ON A1399A.COD_CIA=a900.COD_CIA AND A1399A.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1399A.COD_DOCUM = a900.COD_DOCUM_ASEG
  LEFT JOIN A100133')||TO_CLOB('1 A1331 ON A1331.COD_CIA=a900.COD_CIA AND A1331.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1331.COD_DOCUM = a900.COD_DOCUM_ASEG
  LEFT JOIN a1001800 a1800 ON a1800.COD_CIA=a900.COD_CIA AND a1800.COD_RAMO = a900.COD_RAMO
  LEFT JOIN G7000200 G200 ON G200.COD_CIA = G200.COD_CIA AND G200.TIP_CAUSA = 1 AND G200.COD_CAUSA = a900.COD_CAUSA_SINI
  LEFT JOIN A2000020 A2020 ON A2020.COD_CIA=a900.COD_CIA AND A2020.NUM_POLIZA=a900.NUM_POLIZA AND A2020.NUM_SPTO=0 AND A2020.NUM_APLI=0 AND A2020.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020.NUM_RIESGO=a900.NUM_RIESGO AND A2020.COD_CAMPO=''NUM_MATRICULA''
  LEFT JOIN A7001080 a80 ON a80.COD_CIA=a900.COD_CIA AND a80.NUM_SINI=a900.NUM_SINI AND NOT a80.OBS IS NULL
  LEFT JOIN A7001000 a1000 ON a1000.COD_CIA=a900.COD_CIA AND a1000.NUM_SINI=a900.NUM_SINI
  LEFT JOIN G7000090 G90 ON G90.COD_CIA = a1000.COD_CIA AND G90.TIP_EXP = a1000.TIP_EXP
  LEFT JOIN G1010031 G31EA ON G31EA.COD_CAMPO =''TIP_EST_EXP'' AND G31EA.COD_VALOR = a1000.TIP_EST_EXP AND G31EA.COD_IDIOMA=''ES''  
  WHERE a900.COD_CIA={app.P_COD_CIA}
    AND a900.COD_AGT={app.P_COD_AGT}
 ORDER BY a900.FEC_SINI DESC, a900.NUM_SINI, a1000.NUM_EXP'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (390,1,1,'Documentos y enlaces','Documentos y enlaces',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-06-14 09:13:53',TO_CLOB('{
  "title": "Documentación",
  "table": {
    "searchStyle": "100%",
    "showHeader": false,
    "pagination": true,
    "paginationParts": ["pageInfoShort", "pageList"],
    "search": true,
    "showToggle": false,
    "showRefresh": false,
    "showColumns": false,
    "showExport": false,
    "showPaginationSwitch": false,
    "classes": "clearTable",
    "columns": [
      {
        "field": "TITLE",
        "title": "Documento",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "function (value, row, index, field) { let tmpl=''<a title=@_{DESCRIPTION}@_ style=@_font-size: medium;@_ href=@_{URL}@_ download>{TITLE}</a><br>''; if(row.TYPE===1) tmpl = tmpl.replace('' download'', '' target=_blank''); return tmpl.supplant(row)+jQuery.map(row.LABEL.split('' ''), function( i ) {  return  ''<small class=@_badge badge-pill badge-warning@_ style=@_font-size: smaller; margin-top: 8px;@_>''+i+''</small>'' ;}).join('' '');}"
      },
      {
        "field": "LABEL",
        "visible": false
      }
    ]
  }
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT ID, FOLDER, TITLE, DESCRIPTION, LABEL, URL, TYPE
  FROM UTILLINKS
 WHERE TYPE={t} AND (ExpirationDate IS NULL OR ExpirationDate >= TRUNC({const.date.today}))
 ORDER BY FOLDER, TITLE'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (392,1,1,'Preguntas y respuestas','Preguntas y respuestas frecuentes',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'1970-02-07 00:00:00',TO_CLOB('{
    "title": "Documentación",
    "table": {
      "searchStyle": "100%",
      "showHeader": false,
      "pagination": true,
      "paginationParts": ["pageInfoShort", "pageList"],
      "search": true,
      "showToggle": false,
      "showRefresh": false,
      "showColumns": false,
      "showExport": false,
      "detailView": true,
      "showPaginationSwitch": false,
      "classes": "clearTable",
            "detailFormatter": "function (index, row, element) { return ''<div style=padding:6px 6px 6px 10px;>''+row.DESCRIPTION+''</span>''}",
      "columns": [
        {
          "field": "TITLE",
          "title": "Documento",
          "sortable": true,
          "halign": "center",
          "align": "left",
          "width": "1000",
          "format": "<span style=''color: #007bff; font-size: medium;''>{TITLE}</span>"
        },
      {
        "field": "DESCRIPTION",
        "visible": false
      }
      ]
    }
  }

'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT ID, FOLDER, TITLE, DESCRIPTION, LABEL, URL, TYPE
  FROM UTILLINKS
 WHERE TYPE={t} AND (ExpirationDate IS NULL OR ExpirationDate >= TRUNC({const.date.today}))
 ORDER BY FOLDER, TITLE'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (393,1,1,'Preguntas y respuestas','Preguntas y respuestas frecuentes (ext)',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'1970-02-07 00:00:00',NULL,'Research',1,NULL,NULL,'preguntasyrespuestas',NULL,TO_CLOB('SELECT TITLE, DESCRIPTION
  FROM UTILLINKS
 WHERE TYPE=4 AND (ExpirationDate IS NULL OR ExpirationDate >= TRUNC({const.date.today}))
 ORDER BY TITLE'));
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
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (396,1,1,'Polizas para Variaciones','Mis clientes - Agente conectado',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2024-10-22 21:49:26',TO_CLOB('{
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
"formatter": "function (value, row, index, field) { var url = '''';switch (row.COD_RAMO){case 302: url = ''/Aliados/Variaciones/MapfreMasOld?poliza=''+row.NUM_POLIZA+''&spto=''+row.NUM_SPTO+''&mca_provisional=''+row.MCA_PROVISIONAL;break;case 303: url = ''/Aliados/Variaciones/MapfreMasPlus?poliza=''+row.NUM_POLIZA+''&spto=''+row.NUM_SPTO+''&mca_provisional=''+row.MCA_PROVISIONAL;break;case 201: url = ''/Aliados/Variaciones/HogarTotal?poliza=''+row.NUM_POLIZA+''&spto=''+row.NUM_SPTO+''&mca_provisional=''+row.MCA_PROVISIONAL;break;case 202: url = ''/Aliados/Variaciones/Multirriesgo?poliza=''+row.NUM_POLIZA+''&spto=''+row.NUM_SPTO+''&mca_provisional=''+row.MCA_PROVISIONAL;break;}return ''<a href=\"'' + url + ''\" target=\"_blank\"><span class=columnBtn><button type=\"button\" name=\"search\" class=\"btn btn-sm btn-white event\" title=\"Permite consultar la poliza\"><i class=\"fa fa-pencil\"></i></button></span></a>'' ;}",
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
"halign')||TO_CLOB('": "center",
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
"halign": "ce')||TO_CLOB('nter",
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
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (420,1,1,'Polizas TA','Listado de Polizas TA por Agente',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2025-11-04 11:29:43',TO_CLOB('{
  "title": "Polizas Tipo Gestor TA",
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
  "title": "Poliza",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.StringFormatter"
  },
  {
  "field": "NUM_RIESGO",
  "title": "Num. Riesgo",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.IntegerFormatter"
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
  "field": "COD_GESTOR",
  "title": "Gestor",
  "sortable": true,
  "halign": "center",
  "align": "left",
  "formatter": "app.ui.StringFormatter"
  },
  {
  "field": "TIP_DOCUM_TOM",
  "title": "T.Doc. Tomador",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.StringFormatter"
  },
  {
  "field": "COD_DOCUM_TOM",
  "title": "Doc. Tomador",
  "sortable": true,
  "halign": "center",
  "align": "left",
  "formatter": "app.ui.StringFormatter"
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
  "field": "TIP_DOCUM_ASE",
  "title": "T.Doc. Asegurado",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.StringFormatter"
  },
  {
  "field": "COD_DOCUM_ASE",
  "title": "Doc. Asegurado",
  "sortable": true,
  "halign": "center",
  "align": "left",
  "formatter": "app.ui.StringFormatter"
  },
  {
  "field": "NOM_ASEGURADO",
  "title": "Asegurado",
  "sortable": true,
  "halign": "center",
  "align": "left",
  "formatter": "app.ui.StringCapitalizeEachWordFormatter"
  },
  {
  "field": "TIP_DOCUM_PAG",
  "title": "T.Doc. Pagador",
  ')||TO_CLOB('"sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.StringFormatter"
  },
  {
  "field": "COD_DOCUM_PAG",
  "title": "Doc. Pagador",
  "sortable": true,
  "halign": "center",
  "align": "left",
  "formatter": "app.ui.StringFormatter"
  },
  {
  "field": "NOM_PAGADOR",
  "title": "Pagador",
  "sortable": true,
  "halign": "center",
  "align": "left",
  "formatter": "app.ui.StringCapitalizeEachWordFormatter"
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
  "field": "SPTO_TA_MAX",
  "title": "Spto TA Max",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.StringFormatter"
  },
  {
  "field": "NUM_SPTO_ULT_PAGO",
  "title": "Spto ultimo pago",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.StringFormatter"
  },
  {
  "field": "FEC_ULTIMO_PAGO",
  "title": "Fecha ultimo pago",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.DateFormatter"
  },
  {
  "field": "ULT_SPTO_POLIZA",
  "title": "Ultimo spto poliza",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.StringFormatter"
  },
  {
  "field": "TIPO",
  "title": "Origen registro",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.StringFormatter"
  },
  ]
  }
  }'),'Tron',1,NULL,NULL,NULL,'Extend.js',TO_CLOB('SELECT x.num_poliza,
       x.num_riesgo,
       x.nom_riesgo,
       x.tip_gestor,
       x.cod_gestor,
       x.tip_docum_tom,
       x.cod_docum_tom,
       x.nom_tomador,
       x.tip_docum_ase,
       x.cod_docum_ase,
       x.nom_asegurado,
       x.tip_docum_pag,
       x.cod_docum_pag,
       x.nom_pagador,
       MAX(SUBSTR(ta.num_tarjeta, -4, 4)) num_tarjeta,
       x.spto_ta_max,
       MAX(e.num_spto_ult_pago) num_spto_ult_pago,
       MAX(e.fec_ultimo_pago)   fec_ultimo_pago,
       x.ult_spto_poliza,
       ''TRON2000''              tipo
  FROM a1000802 ta, --Tarjetas de terceros x póliza
       (SELECT e.cod_cia,
               e.num_poliza,
               MAX(e.num_spto) num_spto_ult_pago,
               MAX(e.fec_actu) fec_ultimo_pago
          FROM tron2000.a2000030 w,
               tron2000.a2990700 e  --Recibos
         WHERE e.tip_situacion      = ''CT''
           AND w.cod_cia            = e.cod_cia
           AND w.num_poliza         = e.num_poliza
           AND w.num_spto           = e.num_spto
           AND w.mca_poliza_anulada = ''N''
           AND w.tip_gestor         = ''TA''
           AND w.mca_spto_anulado   = ''N''
           AND w.tip_spto           IN (''XX'', ''RF'')
         GROUP BY e.cod_cia,
               e.num_poliza
       ) e, --Recibo CT más reciente
       (SELECT a.cod_cia,
               a.cod_ramo,
               a.num_poliza,
               a.tip_gestor,
               a.cod_gestor,
               a.tip_docum   tip_docum_tom, --Tomador
               a.cod_docum   cod_docum_tom,
               a.num_spto    ult_spto_poliza,
               y.spto_ta_max,
               TRIM(TRIM(TRIM(n.nom_tercero||'' ''||n.nom2_tercero)||'' ''||n.ape1_tercero)||'' ''||n.ape2_tercero) nom_tomador,
               t.tip_docum     tip_docum_ase, --Asegurado
               t.cod_docum     cod_docum_ase,
               TRIM(TRIM(TRIM(s.nom_tercero||'' ''||s.nom2_tercero)||'' ''||s.ape1_tercero)||'' ''||s.ape2_tercero) nom_asegurado,
               p.tip_docum  ')||TO_CLOB('   tip_docum_pag, --Pagador
               p.cod_docum     cod_docum_pag,
               TRIM(TRIM(TRIM(g.nom_tercero||'' ''||g.nom2_tercero)||'' ''||g.ape1_tercero)||'' ''||g.ape2_tercero) nom_pagador,
               r.num_riesgo,
               r.nom_riesgo
          FROM (SELECT y.cod_cia,
                       y.num_poliza,
                       MAX(y.num_spto)   spto_ta_max
                  FROM tron2000.a2000030 z,
                       tron2000.a1000802 y
                 WHERE z.cod_cia            = y.cod_cia
                   AND z.num_poliza         = y.num_poliza --No se cruza num_spto debido a sptos SM, a1000802 registra anterior spto
                   AND z.mca_poliza_anulada = ''N''
                   AND z.tip_gestor         = ''TA''
                   AND z.mca_spto_anulado   = ''N''
                 GROUP BY y.cod_cia,
                       y.num_poliza
               ) y, --Suplemento más reciente de pólizas TA
               tron2000.a1001399 g,  --Datos de terceros
               tron2000.a2000060 p,  --Terceros de una póliza - Pagador
               tron2000.a1001399 s,
               tron2000.a2000060 t,  --Terceros de una póliza - Asegurado
               tron2000.a1001399 n,
               tron2000.a2000031 r,
               tron2000.a2000030 a
         WHERE y.cod_cia        (+) = a.cod_cia
           AND y.num_poliza     (+) = a.num_poliza
           AND g.cod_cia        (+) = p.cod_cia
           AND g.tip_docum      (+) = p.tip_docum
           AND g.cod_docum      (+) = p.cod_docum
           AND p.cod_cia        (+) = a.cod_cia
           AND p.num_poliza     (+) = a.num_poliza
           AND p.num_spto       (+) = a.num_spto
           AND p.mca_baja       (+) = ''N''
           AND p.mca_vigente    (+) = ''S''
           AND p.num_riesgo     (+) = r.num_riesgo
           AND p.tip_benef      (+) = 21 --Pagador
           AND s.cod_cia            = t.cod_cia
           AND s.tip_docum          = t.tip_docum
           AND s.cod_docum          =')||TO_CLOB(' t.cod_docum
           AND t.cod_cia            = a.cod_cia
           AND t.num_poliza         = a.num_poliza
           AND t.mca_baja           = ''N''
           AND t.mca_vigente        = ''S''
           AND t.num_riesgo         = r.num_riesgo
           AND t.tip_benef          = 2 --Asegurado
           AND n.cod_cia            = a.cod_cia
           AND n.tip_docum          = a.tip_docum
           AND n.cod_docum          = a.cod_docum
           AND r.cod_cia            = a.cod_cia
           AND r.num_poliza         = a.num_poliza
           AND r.mca_vigente        = ''S''
           AND r.mca_baja_riesgo    = ''N''
           AND a.tip_gestor         = ''TA''
           AND a.cod_agt            = {app.cod_agt}
           AND a.mca_poliza_anulada = ''N''
           AND a.num_spto           = (SELECT MAX(x.num_spto)
                                         FROM tron2000.a2000030 x
                                        WHERE x.cod_cia          = a.cod_cia
                                          AND x.cod_ramo         = a.cod_ramo
                                          AND x.num_poliza       = a.num_poliza
                                          AND x.mca_spto_anulado = ''N''
                                      )
       )x
 WHERE e.cod_cia           (+) = x.cod_cia
   AND e.num_poliza        (+) = x.num_poliza
   AND e.num_spto_ult_pago (+) >= x.spto_ta_max
   AND ta.cod_cia          (+) = x.cod_cia
   AND ta.num_poliza       (+) = x.num_poliza
   AND ta.num_spto         (+) = x.spto_ta_max
GROUP BY x.num_poliza,
       x.num_riesgo,
       x.nom_riesgo,
       x.tip_gestor,
       x.cod_gestor,
       x.tip_docum_tom,
       x.cod_docum_tom,
       x.nom_tomador,
       x.tip_docum_ase,
       x.cod_docum_ase,
       x.nom_asegurado,
       x.tip_docum_pag,
       x.cod_docum_pag,
       x.nom_pagador,
       x.spto_ta_max,
       x.ult_spto_poliza,
       ''TRON2000''
UNION
SELECT b.num_poliza,
       r.num_riesgo,
       r.nom_riesgo,
       a.tip_gestor,
 ')||TO_CLOB('      a.cod_gestor,
       a.tip_docum   tip_docum_tom, --Tomador
       a.cod_docum   cod_docum_tom,
       TRIM(TRIM(TRIM(n.nom_tercero||'' ''||n.nom2_tercero)||'' ''||n.ape1_tercero)||'' ''||n.ape2_tercero) nom_tomador,
       t.tip_docum     tip_docum_ase, --Asegurado
       t.cod_docum     cod_docum_ase,
       TRIM(TRIM(TRIM(s.nom_tercero||'' ''||s.nom2_tercero)||'' ''||s.ape1_tercero)||'' ''||s.ape2_tercero) nom_asegurado,
       p.tip_docum     tip_docum_pag, --Pagador
       p.cod_docum     cod_docum_pag,
       TRIM(TRIM(TRIM(g.nom_tercero||'' ''||g.nom2_tercero)||'' ''||g.ape1_tercero)||'' ''||g.ape2_tercero) nom_pagador,
       SUBSTR(b.card, -4, 4)    num_tarjeta,
       NULL                     spto_ta_max,
       b.num_spto               num_spto_ult_pago,
       b.updatedate             fec_ultimo_pago,
       a.num_spto               ult_spto_poliza,
       ''ALIADOS''                tipo
  FROM tron2000.a1001399 g,  --Datos de terceros
       tron2000.a2000060 p,  --Terceros de una póliza - Pagador
       tron2000.a1001399 s,
       tron2000.a2000060 t,  --Terceros de una póliza - Asegurado
       tron2000.a1001399 n,
       tron2000.a2000031 r,
       tron2000.a2000030 a,
       aliados.boveda    b
 WHERE g.cod_cia        (+) = p.cod_cia
   AND g.tip_docum      (+) = p.tip_docum
   AND g.cod_docum      (+) = p.cod_docum
   AND p.cod_cia        (+) = a.cod_cia
   AND p.num_poliza     (+) = a.num_poliza
   AND p.num_spto       (+) = a.num_spto
   AND p.mca_baja       (+) = ''N''
   AND p.mca_vigente    (+) = ''S''
   AND p.num_riesgo     (+) = r.num_riesgo
   AND p.tip_benef      (+) = 21 --Pagador
   AND s.cod_cia            = t.cod_cia
   AND s.tip_docum          = t.tip_docum
   AND s.cod_docum          = t.cod_docum
   AND t.cod_cia            = a.cod_cia
   AND t.num_poliza         = a.num_poliza
   AND t.mca_baja           = ''N''
   AND t.mca_vigente        = ''S''
   AND t.num_riesgo         = r.num_riesgo
   AND t.tip_benef          = 2 --Asegurado
   AND n.cod_cia   ')||TO_CLOB('         = a.cod_cia
   AND n.tip_docum          = a.tip_docum
   AND n.cod_docum          = a.cod_docum
   AND b.num_poliza         = a.num_poliza
   AND b.updatedate         = (SELECT MAX(y.updatedate)
                                 FROM aliados.boveda y
                                WHERE y.num_poliza = b.num_poliza
                              )
   AND r.cod_cia            = a.cod_cia
   AND r.num_poliza         = a.num_poliza
   AND r.mca_vigente        = ''S''
   AND r.mca_baja_riesgo    = ''N''
   AND a.cod_agt            = {app.cod_agt}
   AND a.num_spto           = (SELECT MAX(x.num_spto)
                                 FROM tron2000.a2000030 x
                                WHERE x.cod_cia          = a.cod_cia
                                  AND x.cod_ramo         = a.cod_ramo
                                  AND x.num_poliza       = a.num_poliza
                                  AND x.mca_spto_anulado = ''N''
                              )'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (777,1,3,'XXXXX','XXXXX',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-12-03 21:43:09',TO_CLOB('<style>
    .pricingTable {
        background-color: #fff;
        font-family: ''Roboto'', sans-serif;
        text-align: center;
        padding: 35px 0 0;
        box-shadow: 3px 3px 7px 0px rgba(0, 0, 0, 0.3);
        border-radius: 20px;
        margin-top: 15px;
    }

    .pricingTable .pricingTable-header {
        background: linear-gradient(transparent, transparent, #e7e7e7);
        padding: 0 0 30px;
    }

    .pricingTable .title {
        color: #333;
        font-size: 33px;
        font-weight: 700;
        letter-spacing: 2px;
        text-transform: uppercase;
        margin: 0 0 20px;
    }

    .pricingTable .title:after {
        content: "";
        background: #F63459;
        width: 160px;
        height: 3px;
        margin: 20px auto 0;
        display: block;
        clear: both;
    }

    .pricingTable .price-value {
        color: #F63459;
        font-size: 52px;
        font-weight: 800;
        line-height: 47px;
        letter-spacing: 2px;
        display: block;
    }

    .pricingTable .price-value sup {
        font-size: 30px;
        vertical-align: bottom;
    }

    .pricingTable .pricing-content {
        background: linear-gradient(#F53149, #FD6653);
        border-radius: 0 0 20px 20px;
        padding: 35px 30px;
    }

    .pricingTable .pricing-content ul {
        text-align: left;
        padding: 0 0 0 20px;
        margin: 0 0 25px;
        display: inline-block;
    }

    .pricingTable .pricing-content ul li {
        color: #fff;
        font-size: 17px;
        font-weight: 300;
        margin: 0 0 15px;
        letter-spacing: 0.5px;
        position: relative;
    }

    .pricingTable .pricing-content ul li:last-child {
        margin: 0;
    }

    .pricingTable .pricingTable-signup a {
        color: #fff;
        font-size: 20px;
        font-weight: 400;
        font-style: italic;
        text-transform: uppercase;
        letter-spacing: 1px;
        padding: 7px 25px;
        margin: 0 auto;
        b')||TO_CLOB('order: 2px solid #fff;
        border-radius: 10px;
        display: inline-block;
        transition: all 0.5s;
    }

    .pricingTable .pricingTable-signup a:hover {
        letter-spacing: 2px;
        box-shadow: 0 0 0 5px rgba(255, 255, 255, 0.5);
    }

    .pricingTable.orange .title:after {
        background-color: #ED8009;
    }

    .pricingTable.orange .price-value {
        color: #ED8009;
    }

    .pricingTable.orange .pricing-content {
        background: linear-gradient(#ED8009, #FCA531);
    }

    @media only screen and (max-width: 990px) {
        .pricingTable {
            margin-bottom: 40px;
        }
    }
</style>

<div class="demo">
    <div class="container">
        <div class="row">
            {{#each data}}
            <div class="col-md-4 col-sm-6">
                <div class="pricingTable{{js "this.RECORDSTATUS==1 ? '' orange'' : ''''"}}">
                    <div class="pricingTable-header">
                        <h3 class="title">{{FIRSTNAME}} {{LASTNAME}}</h3>
                        <div class="price-value">$10<sup>.99</sup></div>
                    </div>
                    <div class="pricing-content">
                        <ul>
                            <li>50GB Disk Space</li>
                            <li>50 Email Accounts</li>
                            <li>50GB Bandwidth</li>
                            <li>Maintenance</li>
                            <li>15 Subdomains</li>
                        </ul>
                        <div class="pricingTable-signup">
                            <a href="#">Sign Up</a>
                        </div>
                    </div>
                </div>
            </div>
            {{/each}}
        </div>
    </div>
</div>'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('select * from usermember where  userid < 20'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (900,1,1,'Presupuestos pendientes de emitir por agente','Presupuestos pendientes de emitir por agente',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-07-10 19:57:22',TO_CLOB('{
  "title": "Presupuestos pendientes de emitir por agente",
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
        "sortable": true,
        "halign": "center",
        "align": "left",
        "format": "{INSUREDID} {INSUREDNAME}"
      },
      {
        "field": "SUMMARY",
        "title": "Detalles",
        "sortable": true,
     ')||TO_CLOB('   "halign": "center",
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
}'),'Research',1,'|título
|zona|4
 Agente+|lista|name=cod_agt;lookup=Agents
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 900, @_@_)',NULL,NULL,'Extend.js',TO_CLOB('SELECT ID, PROPOSALID, INSUREDID, REPLACE(INSUREDID, ''-'', '''') INSUREDIDCLEAR, INSUREDNAME, SUMMARY, ISSUEDATE, SIGNINGREQUESTID, STATUS, LKS.DESCRIPTION STATUSDESC, SigningType, PrimaryEmailAddress
  FROM POLICYPROPOSAL
  LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 2050 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE = POLICYPROPOSAL.STATUS
 WHERE POLICYPROPOSAL.COMPANYID={app.companyid} AND AGENTCODE={cod_agt} ORDER BY ISSUEDATE DESC, POLICYPROPOSAL.UPDATEDATE DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (3000,1,1,'Mis pólizas','Cliente conectado',NULL,NULL,NULL,NULL,1,1,10509,TIMESTAMP'2022-05-31 00:00:00',TO_CLOB('{
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
            "formatter": "app.ui.DateFormatte')||TO_CLOB('r",
            "visible": true
        },
        {
            "field": "FEC_VCTO_SPTO",
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
}'),'Tron',1,NULL,NULL,NULL,'Extend.js',TO_CLOB('WITH EXCLUIDOS AS (
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
   AND a.num_spto_apli = em_f_max_spto_apli_1_web(a.cod_cia, a.num_pol')||TO_CLOB('iza, a.num_spto, a.num_apli, NULL)
   AND NOT EXISTS (SELECT 1 FROM EXCLUIDOS x WHERE x.NUM_POLIZA = a.NUM_POLIZA_GRUPO AND ((x.NUM_CONTRATO =0) OR (x.NUM_CONTRATO >0 AND x.NUM_CONTRATO = a.NUM_CONTRATO )))   
ORDER BY fec_efec_spto desc'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (3000,2,1,'Mis siniestros','Cliente conectado',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-11-24 16:36:23',TO_CLOB('{
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
                "ha')||TO_CLOB('lign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
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
}'),'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('WITH EXCLUIDOS AS (
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
 ORDER BY s.fec_denu_sini'));
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
                "colorstate": {"VIGENTE":"primary","_":"danger","Cobrado":"success","Pendiente":"warning"}
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
                "formatter": "app.ui.DateFormatt')||TO_CLOB('er",
                "visible": true
            },
            {
                "title": "Acciones",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button name=\"printr\" type=\"button\"class=\"btn btn-sm btn-white event\" title=\"Permite imprimir el recibo\"><i class=\"fa fa-print\"></i></button><button type=\"button\" name=\"payment\" class=\"btn btn-sm btn-white event\" title=\"Permite pagar el recibo actual\"><i class=\"fa fa-shopping-cart\"></i></button></span>'' ;}",
                "visible": true,
                "events": true,
                "action_payment": "app.core.LoadScriptFile(''Payment.js'').then(d => {app.Payment.Recibo(row, 3001, 1)})"
            }
        ]
    }
}'),'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT a.num_poliza, a.num_recibo, a.fec_efec_recibo, a.fec_vcto_recibo,a.fec_vcto_pago, a.cod_mon, a.imp_recibo,
     a.tip_situacion, b.nom_situacion situacion_recibo, decode(a.tip_situacion, ''CT'', ''Cobrado'', ''Pendiente'') tip_situacion_desc
  FROM a2990700 a
  LEFT JOIN a5020500 b ON b.tip_situacion = a.tip_situacion
 WHERE a.cod_cia = {app.P_COD_CIA}
   AND a.num_poliza = {NUM_POLIZA:varchar}
   AND a.num_spto IN (SELECT DISTINCT d.num_spto FROM a2000030 d WHERE d.cod_cia = a.cod_cia AND d.num_poliza = a.num_poliza  and trunc(SYSDATE) BETWEEN d.fec_efec_spto and d.fec_vcto_spto)
   AND a.num_recibo > 0
 ORDER BY a.num_recibo ASC'));
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
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (4000,1,1,'Casos',NULL,NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'1970-02-07 00:00:00',TO_CLOB('{
"title": "Casos",
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
	"field": "ID",
	"title": "No. Caso",
	"sortable": true,
	"halign": "center",
	"align": "right",
	"formatter": "app.ui.IntegerFormatter",
	"visible": true
  },
  {
	"field": "PRIORITYDESC",
	"title": "Prioridad",
	"sortable": true,
	"halign": "center",
	"align": "center",
	"formatter": "app.ui.StringFormatter",
  "visible": true
  },
  {
  "field": "TITLE",
  "title": "Asunto",
  "sortable": true,
  "halign": "center",
  "align": "left",
  "visible": true,
  "format": "<a href=''../cases/case?id={ID}'' title=''Ver caso #{ID}''>{TITLE}</a>. <small class=''text-muted''>{FLOWNAME}</small>"
  },
  {
  "field": "CORREDURIA",
  "title": "Correduria",
  "sortable": true,
  "halign": "center",
  "align": "left",
  "formatter": "app.ui.StringFormatter",
  "visible": true
  },
  {
  "field": "CONTACTMAINNAME",
  "title": "Contacto",
  "sortable": true,
  "halign": "center",
  "align": "left",
  "formatter": "app.ui.StringFormatter",
  "visible": true
  },
  {
  "field": "STARTDATE",
  "title": "Creado",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.DateAndTimeFormatter",
  "visible": true
  },
  {
  "field": "STATUSDESC",
  "title": "Estado",
  "sortable": true,
  "halign": "center",
  "align": "left",
  "formatter": "app.ui.StringFormatter",
  "visible": true
  },
  {
  "field": "Progreso",
  "title": "% Progreso",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "format": "<div class=''progress progress-mini''><div style=''width: {PROGRESS}%;'' class=''progress-bar''></div></div><small>{PROGRESS} % / Etapa {STEPCURRENT} de {STEPTOTAL}</small>"
  },
  {
  "field": "STEPNAME",
  "title": "Etapa actual",
  "sortable": true,
  "halign": "center",
  "align": "left",
  "formatter": "app.ui.StringFormatter",
 ')||TO_CLOB(' "visible": true
  },
  {
  "field": "FINISHDATE",
  "title": "Terminado",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.DateAndTimeFormatter",
  "visible": true
  },
  {
  "field": "STEPSTARTDATE",
  "title": "STEPSTARTDATE",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.DateAndTimeFormatter",
  "visible": false
  },
  {
  "field": "STEPFINISHDATE",
  "title": "STEPFINISHDATE",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.DateAndTimeFormatter",
  "visible": false
  },
  {
  "field": "STEPDUEDATE",
  "title": "STEPDUEDATE",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.DateAndTimeFormatter",
  "visible": false
  },
  {
  "field": "ROLES",
  "title": "Roles",
  "sortable": true,
  "halign": "center",
  "align": "left",
  "formatter": "app.ui.StringFormatter",
  "width": 10,
  "widthUnit": "%"
  }
]
}
}'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT PC.ID, PC.CONTACTMAINNAME, PC.TITLE, PC.DESCRIPTION, LKCP.DESCRIPTION PRIORITYDESC, PC.STATUS, LKS.DESCRIPTION STATUSDESC, PC.LABEL, PC.SUBLABEL,
       PC.FLOWID, PF.NAME FLOWNAME, PC.INSTANCEID, PIF.CREATED, PIF .STARTDATE, PIF.FINISHDATE, PIF.DUEDATE,
       (select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID AND SSC.ID<=PC.CURRENTSTEPID) STEPCURRENT,
       (select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID) STEPTOTAL,
      CAST (((select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID AND SSC.ID<=PC.CURRENTSTEPID)*100)/(select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID) AS DECIMAL(5,0)) PROGRESS,
       PIS.STEPID, PIST.NAME STEPNAME, PIS.STARTDATE  STEPSTARTDATE, PIS.FINISHDATE STEPFINISHDATE, PIS.DUEDATE  STEPDUEDATE,
       (SELECT LISTAGG(RM.ROLENAME , '', '') WITHIN GROUP (ORDER BY RM.ROLENAME ) FROM PROCESSSPECSTEPROLE prm LEFT JOIN ROLEMEMBER rm ON rm.RoleId = prm.RoleId WHERE prm.COMPANYID=PC.CompanyId AND prm.ID=PIS.STEPID) Roles, PC.REFERENCE3 correduria
  FROM PROCESSCASE PC
  LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 61 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE =PC.STATUS
  LEFT JOIN LOOKUP LKCP ON LKCP.LOOKUPID = 62 AND LKCP.COMPANYID=0 AND LKCP.LANGUAGE=1 AND LKCP.CODE =PC.PRIORITY
  LEFT JOIN PROCESSSPECFLOW PF ON PF.COMPANYID=PC.COMPANYID AND PF.ID=PC.FLOWID
  LEFT JOIN PROCESSINSTANCE PIF ON PIF.COMPANYID=PC.COMPANYID AND PIF.INSTANCEID=PC.INSTANCEID AND PIF.STEPID=0
  LEFT JOIN PROCESSINSTANCE PIS ON PIS.COMPANYID=PC.COMPANYID AND PIS.INSTANCEID=PC.INSTANCEID AND PIS.STEPID>0 AND PIS.TASKID=0 AND NOT PIS.STARTDATE IS NULL AND PIS.FINISHDATE IS NULL
  LEFT JOIN PROCESSSPECSTEP PIST ON PIST.COMPANYID=PIS.COMPANYID AND PIST.FLOWID=PIS.FLOWID AND PIST.ID=PIS.STEPID
  JOIN PROCESSSPECSTEPROLE prm2 ON prm2.COMPANYID=PC.CompanyId AND prm2.ID=PIST.ID
  JOIN ROLEMEMBER rm ON rm.RoleId = prm2.RoleId and lower(rm.rolename) in ({app.UserRoleNameList})
 WHERE PC.CompanyId={app.c')||TO_CLOB('ompanyid} AND PC.FLOWID>0 AND PC.INSTANCEID>0 AND (select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID) > 0'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (4001,1,1,'Detalle por caso','Detalle por caso',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2025-06-02 17:19:00',TO_CLOB('{
"title": "Detalle por caso",
"table": {
"pagination": true,
"search": true,
"showToggle": false,
"showRefresh": false,
"showColumns": false,
"showExport": false,
"showPaginationSwitch": false,
"buttons": "app.Ex_CaseDetail.Boton",
"showButtonText": true,
"columns": [
  {
    "field": "ID",
    "title": "No. Caso",
    "sortable": true,
    "halign": "center",
    "align": "right",
    "formatter": "app.ui.IntegerFormatter"
  },
  {
    "field": "STATUSDESC",
    "title": "Estatus del caso",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  },
  {
    "field": "CREATEDATE",
    "title": "Fecha de solicitud (Creada)",
    "sortable": true,
    "halign": "center",
    "align": "center",
    "formatter": "app.ui.DateFormatter"
  },
  {
    "field": "CREATETIME",
    "title": "Hora",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter",
    "visible": true
  },
  {
    "field": "CONTACTMAINNAME",
    "title": "Contacto",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  },
  {
    "field": "TITLE",
    "title": "Asunto",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  },
  {
    "field": "FLOWNAME",
    "title": "Nombre del caso",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  },
  {
    "field": "DESCRIPTION",
    "title": "Descripci?n",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  },
  {
    "field": "PRIORITYDESC",
    "title": "Prioridad",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  },
  {
    "field": "STARTDATE",
    "title": "Fecha etapa",
    "')||TO_CLOB('sortable": true,
    "halign": "center",
    "align": "center",
    "formatter": "app.ui.DateFormatter"
  },
  {
    "field": "STARTTIME",
    "title": "Hora etapa",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  },
  {
    "field": "ROL",
    "title": "Rol",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  },
  {
    "field": "UPDATEUSERNAME",
    "title": "Realizado por",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  },
  {
    "field": "STEPNAME",
    "title": "Etapa",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  },
  {
    "field": "PROGRESS",
    "title": "% Progreso",
    "sortable": true,
    "halign": "center",
    "align": "right",
    "formatter": "app.ui.IntegerFormatter"
  },
  {
    "field": "NOTES",
    "title": "Notas",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  },
  {
    "field": "FINISHDATE",
    "title": "Fecha de finalizacion",
    "sortable": true,
    "halign": "center",
    "align": "center",
    "formatter": "app.ui.DateFormatter"
  },
  {
    "field": "FINISHTIME",
    "title": "Hora de finalizacion",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  },
  {
    "field": "DAYS",
    "title": "Cantidad de Dias",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  },
  {
    "field": "TOTALDAYS",
    "title": "Total de Dias",
    "sortable": true,
    "halign": "center",
    "align": "left",
    "formatter": "app.ui.StringFormatter"
  }  
],
}
}'),'Research',1,'|titulo
|zona|4
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Proceso|lista|name=FlowId;lookup=Process.
 Estado|lista|name=Status;lookup=ProcessStatus.
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 4001, @_@_)',NULL,'CaseDetail','Extend.CaseDetail.js',TO_CLOB('SELECT CS.ID, LKSCS.DESCRIPTION STATUSDESC, TRUNC(PI.CREATED) CREATEDATE,TO_CHAR(PI.CREATED, ''HH:MI AM'') CREATETIME, CS.CONTACTMAINNAME,
       CS.TITLE , PF.NAME FLOWNAME, CS.DESCRIPTION, LKCP.DESCRIPTION PRIORITYDESC,
       TRUNC(PI.STARTDATE) STARTDATE, TO_CHAR(PI.STARTDATE, ''HH:MI AM'') STARTTIME,
       (SELECT LISTAGG(RM.ROLENAME , '', '') WITHIN GROUP (ORDER BY RM.ROLENAME ) FROM PROCESSSPECSTEPROLE prm LEFT JOIN ROLEMEMBER rm ON rm.RoleId = prm.RoleId WHERE prm.COMPANYID=PI.COMPANYID AND prm.ID=PI.STEPID) ROL,
       U.FIRSTNAME || '' '' || U.LASTNAME UPDATEUSERNAME,
       PS.NAME STEPNAME,
       CAST (((select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=CS.FLOWID AND SSC.STEPORDER<=PS.STEPORDER)*100)/(select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=CS.FLOWID) AS DECIMAL(5,0)) Progress,
       (SELECT LISTAGG(TO_CHAR(NT.UPDATEDATE , ''DD/MM/YYYY HH24:MI'') || '' '' || NU.FIRSTNAME || '' '' || NU.LASTNAME || '': '' || NT.NOTE, chr(13) || chr(10)) WITHIN GROUP (ORDER BY NT.ID ) FROM NOTES NT LEFT JOIN USERMEMBER NU ON NU.COMPANYID=NT.COMPANYID AND NU.USERID=NT.UPDATEUSERCODE WHERE NT.COMPANYID= CS.COMPANYID AND NT.ENTITYTYPE=1304 AND NT.ENTITYID=CS.ID) NOTES,
       TRUNC(PI.FINISHDATE) FINISHDATE,TO_CHAR(PI.FINISHDATE, ''HH:MI AM'') FINISHTIME, calcular_dias(PI.STARTDATE, PI.FINISHDATE, ''S'') DAYS, calcular_dias(PI2.STARTDATE, PI2.FINISHDATE, ''S'')  TOTALDAYS
  FROM PROCESSCASE CS
  LEFT JOIN PROCESSINSTANCE PI ON PI.COMPANYID=CS.COMPANYID AND PI.INSTANCEID=CS.INSTANCEID AND PI.STEPID>0  AND PI.TASKID=0 AND not PI.STARTDATE IS NULL
  LEFT JOIN PROCESSSPECFLOW PF ON PF.COMPANYID=PI.COMPANYID AND PF.ID=PI.FLOWID
  LEFT JOIN PROCESSSPECSTEP PS ON PS.COMPANYID=PI.COMPANYID AND PS.FLOWID=PI.FLOWID AND PS.ID=PI.STEPID
  LEFT JOIN LOOKUP LKCP ON LKCP.LOOKUPID = 62 AND LKCP.COMPANYID=0 AND LKCP.LANGUAGE=1 AND LKCP.CODE =CS.PRIORITY
  LEFT JOIN LOOKUP LKSCS ON LKSCS.LOOKUPID = 61 AND LKSCS.COMPANYID=0 AND LKSCS.LANGUAGE=1 AND LKSCS.CODE =CS.STATUS
  ')||TO_CLOB('LEFT JOIN USERMEMBER U ON U.COMPANYID=PI.COMPANYID AND U.USERID=PI.UPDATEUSERCODE
  LEFT JOIN PROCESSINSTANCE PI2 ON PI2.COMPANYID=CS.COMPANYID AND PI2.INSTANCEID=CS.INSTANCEID AND PI2.STEPID=0 AND PI2.TASKID=0
 WHERE CS.COMPANYID={app.companyid} AND ({FlowId} =0 OR CS.FLOWID = {FlowId}) AND ({Status} =0 OR CS.STATUS = {Status}) AND TRUNC(PI.CREATED)>={desde:date} AND TRUNC(PI.CREATED)<={hasta:date}
 ORDER BY CS.ID, PI.ActivityId'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (4002,1,1,'Detalle por caso (excel)','Detalle por caso',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2025-06-02 17:19:00',NULL,'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT CS.ID "No. Caso", LKSCS.DESCRIPTION "Estatus del caso", TRUNC(PI.CREATED) "Fecha de solicitud (Creada)",TO_CHAR(PI.CREATED, ''HH:MI AM'') "Hora", CS.CONTACTMAINNAME "Contacto", CS.REFERENCE4 "Categoria por correduria", CS.REFERENCE3 "Corredur?a", CS.REFERENCE1 "Tomador", CS.REFERENCE2 "Numero de poliza",
       CS.TITLE "Asunto", PF.NAME "Nombre del caso", CASE WHEN PF.REFERENCECAPTION5 = ''TIPO DE VARIACION'' THEN CS.REFERENCE5 ELSE NULL END "Tipo de variación", CS.DESCRIPTION "Descripci?n", LKCP.DESCRIPTION "Prioridad",
       TRUNC(PI.STARTDATE) "Fecha etapa actual", TO_CHAR(PI.STARTDATE, ''HH:MI AM'') "Hora etapa actual",
       (SELECT LISTAGG(RM.ROLENAME , '', '') WITHIN GROUP (ORDER BY RM.ROLENAME ) FROM PROCESSSPECSTEPROLE prm LEFT JOIN ROLEMEMBER rm ON rm.RoleId = prm.RoleId WHERE prm.COMPANYID=PI.COMPANYID AND prm.ID=PI.STEPID) "Rol",
       U.FIRSTNAME || '' '' || U.LASTNAME "Realizado por",
       PS.NAME "Etapa actual",
       CAST (((select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=CS.FLOWID AND SSC.STEPORDER<=PS.STEPORDER)*100)/(select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=CS.FLOWID) AS DECIMAL(5,0)) "% Progreso",
       (SELECT LISTAGG(TO_CHAR(NT.UPDATEDATE , ''DD/MM/YYYY HH24:MI'') || '' '' || NU.FIRSTNAME || '' '' || NU.LASTNAME || '': '' || NT.NOTE, chr(13) || chr(10)) WITHIN GROUP (ORDER BY NT.ID ) FROM NOTES NT LEFT JOIN USERMEMBER NU ON NU.COMPANYID=NT.COMPANYID AND NU.USERID=NT.UPDATEUSERCODE WHERE NT.COMPANYID= CS.COMPANYID AND NT.ENTITYTYPE=1304 AND NT.ENTITYID=CS.ID) "Notas",
       TRUNC(PI.FINISHDATE) "Fecha de finalizacion",TO_CHAR(PI.FINISHDATE, ''HH:MI AM'') "Hora de finalizacion", calcular_dias(PI.STARTDATE, PI.FINISHDATE, ''S'')  "Cantidad de Dias", calcular_dias(PI2.STARTDATE, PI2.FINISHDATE, ''S'') "Total de Dias"
  FROM PROCESSCASE CS
  LEFT JOIN PROCESSINSTANCE PI ON PI.COMPANYID=CS.COMPANYID AND PI.INSTANCEID=CS.INSTANCEID AND PI.STEPID>0 AND PI.TASKID=0 AND not PI.STARTDATE IS NULL
  LEFT JOIN PROCESSSPECFLOW PF')||TO_CLOB(' ON PF.COMPANYID=PI.COMPANYID AND PF.ID=PI.FLOWID
  LEFT JOIN PROCESSSPECSTEP PS ON PS.COMPANYID=PI.COMPANYID AND PS.FLOWID=PI.FLOWID AND PS.ID=PI.STEPID
  LEFT JOIN LOOKUP LKCP ON LKCP.LOOKUPID = 62 AND LKCP.COMPANYID=0 AND LKCP.LANGUAGE=1 AND LKCP.CODE =CS.PRIORITY
  LEFT JOIN LOOKUP LKSCS ON LKSCS.LOOKUPID = 61 AND LKSCS.COMPANYID=0 AND LKSCS.LANGUAGE=1 AND LKSCS.CODE =CS.STATUS
  LEFT JOIN USERMEMBER U ON U.COMPANYID=PI.COMPANYID AND U.USERID=PI.UPDATEUSERCODE
  LEFT JOIN PROCESSINSTANCE PI2 ON PI2.COMPANYID=CS.COMPANYID AND PI2.INSTANCEID=CS.INSTANCEID AND PI2.STEPID=0 AND PI2.TASKID=0
 WHERE CS.COMPANYID={app.companyid} AND ({FlowId} =0 OR CS.FLOWID = {FlowId}) AND ({Status} =0 OR CS.STATUS = {Status}) AND TRUNC(PI.CREATED)>={desde:date} AND TRUNC(PI.CREATED)<={hasta:date}
 ORDER BY CS.ID, PI.ActivityId'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (4003,1,1,'Todos los casos',NULL,NULL,NULL,NULL,NULL,1,1,888,TIMESTAMP'2023-03-31 00:00:00',TO_CLOB('{
  "title": "Casos",
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
	"field": "ID",
	"title": "No. Caso",
	"sortable": true,
	"halign": "center",
	"align": "center",
	"formatter": "app.ui.IntegerFormatter",
  "visible": true
  },    
{
  "field": "PRIORITYDESC",
  "title": "Prioridad",
  "sortable": true,
  "halign": "center",
  "align": "center",
  "formatter": "app.ui.StringFormatter",
  "visible": true
  },    
      {
        "field": "TITLE",
        "title": "Asunto",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "visible": true,
        "format": "<button type=''button'' name=''deletecase'' class=''btn btn-sm btn-link d-none role-Supervisor-visible event'' title=''Permite eliminar un caso''><i class=''fa fa-close text-danger''></i></button> <a href=''../cases/case?id={ID}'' title=''Ver caso #{ID}''>{TITLE}</a>. <small class=''text-muted''>{FLOWNAME}</small>",
          "events": true,
          "action_deletecase": "app.Ex_Cases.Eliminar(row)"
      },
      {
        "field": "CONTACTMAINNAME",
        "title": "Contacto",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "STARTDATE",
        "title": "Creado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateAndTimeFormatter",
        "visible": true
      },
      {
        "field": "STATUSDESC",
        "title": "Estado",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "Progreso",
        "title": "% Progreso",
        "sortable": true,
        "halign')||TO_CLOB('": "center",
        "align": "center",
        "format": "<div class=''progress progress-mini''><div style=''width: {PROGRESS}%;'' class=''progress-bar''></div></div><small>{PROGRESS} % / Etapa {STEPCURRENT} de {STEPTOTAL}</small>"
      },
      {
        "field": "STEPNAME",
        "title": "Etapa actual",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "FINISHDATE",
        "title": "Terminado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateAndTimeFormatter",
        "visible": true
      },
      {
        "field": "STEPSTARTDATE",
        "title": "STEPSTARTDATE",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateAndTimeFormatter",
        "visible": false
      },
      {
        "field": "STEPFINISHDATE",
        "title": "STEPFINISHDATE",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateAndTimeFormatter",
        "visible": false
      },
      {
        "field": "STEPDUEDATE",
        "title": "STEPDUEDATE",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateAndTimeFormatter",
        "visible": false
      },
      {
        "field": "ROLES",
        "title": "Roles",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "width": 10,
        "widthUnit": ''%''
      }
    ]
  }
}'),'Research',1,NULL,NULL,NULL,'Extend.Cases.js',TO_CLOB('SELECT PC.ID, PC.CONTACTMAINNAME, PC.TITLE, PC.DESCRIPTION, LKCP.DESCRIPTION PRIORITYDESC, PC.STATUS, LKS.DESCRIPTION STATUSDESC, PC.LABEL, PC.SUBLABEL,
       PC.FLOWID, PF.NAME FLOWNAME, PC.INSTANCEID, PIF.CREATED, PIF .STARTDATE, PIF.FINISHDATE, PIF.DUEDATE,
       (select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID AND SSC.ID<=PC.CURRENTSTEPID) STEPCURRENT,
       (select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID) STEPTOTAL,
      CAST (((select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID AND SSC.ID<=PC.CURRENTSTEPID)*100)/(select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID) AS DECIMAL(5,0)) PROGRESS,
       PIS.STEPID, PIST.NAME STEPNAME, PIS.STARTDATE  STEPSTARTDATE, PIS.FINISHDATE STEPFINISHDATE, PIS.DUEDATE  STEPDUEDATE,
       (SELECT LISTAGG(RM.ROLENAME , '', '') WITHIN GROUP (ORDER BY RM.ROLENAME ) FROM PROCESSSPECSTEPROLE prm LEFT JOIN ROLEMEMBER rm ON rm.RoleId = prm.RoleId WHERE prm.COMPANYID=PC.CompanyId AND prm.ID=PIS.STEPID) Roles
  FROM PROCESSCASE PC
  LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 61 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE =PC.STATUS
  LEFT JOIN LOOKUP LKCP ON LKCP.LOOKUPID = 62 AND LKCP.COMPANYID=0 AND LKCP.LANGUAGE=1 AND LKCP.CODE =PC.PRIORITY
  LEFT JOIN PROCESSSPECFLOW PF ON PF.COMPANYID=PC.COMPANYID AND PF.ID=PC.FLOWID
  LEFT JOIN PROCESSINSTANCE PIF ON PIF.COMPANYID=PC.COMPANYID AND PIF.INSTANCEID=PC.INSTANCEID AND PIF.STEPID=0
  LEFT JOIN PROCESSINSTANCE PIS ON PIS.COMPANYID=PC.COMPANYID AND PIS.INSTANCEID=PC.INSTANCEID AND PIS.STEPID>0 AND PIS.TASKID=0 AND NOT PIS.STARTDATE IS NULL AND PIS.FINISHDATE IS NULL
  LEFT JOIN PROCESSSPECSTEP PIST ON PIST.COMPANYID=PIS.COMPANYID AND PIST.FLOWID=PIS.FLOWID AND PIST.ID=PIS.STEPID
 WHERE PC.CompanyId={app.companyid} AND PC.FLOWID>0 AND PC.INSTANCEID>0 AND (select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID) > 0'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (4004,1,1,'Todos los casos que tiene acceso el usuario',NULL,NULL,NULL,NULL,NULL,1,1,888,TIMESTAMP'2023-03-31 00:00:00',TO_CLOB('{
  "title": "Casos",
  "table": {
    "pagination": true,
    "search": true,
    "showToggle": false,
    "showRefresh": true,
    "showColumns": true,
    "showExport": true,
    "showPaginationSwitch": false,
    "exportTypes": ["csv", "excel"],
    "columns": [
      {
        "field": "ID",
        "title": "No. Caso",
        "sortable": true,
        "halign": "center",
        "align": "right",
        "formatter": "app.ui.IntegerFormatter",
        "visible": true
      },
      {
        "field": "TITLE",
        "title": "Asunto",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "visible": true,
        "format": "<a href=''../cases/case?id={ID}'' title=''Ver caso #{ID}''>{TITLE}</a>. <small class=''text-muted''>{FLOWNAME}</small>"
      },
      {
        "field": "CONTACTMAINNAME",
        "title": "Contacto",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": false
      },
      {
        "field": "STARTDATE",
        "title": "Creado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateAndTimeFormatter",
        "visible": false
      },
      {
        "field": "STATUSDESC",
        "title": "Estado",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "Progreso",
        "title": "% Progreso",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "format": "<div class=''progress progress-mini''><div style=''width: {PROGRESS}%;'' class=''progress-bar''></div></div><small>{PROGRESS} % / Etapa {STEPCURRENT} de {STEPTOTAL}</small>"
      },
      {
        "field": "STEPNAME",
        "title": "Etapa",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.Ex')||TO_CLOB('_Cases.EtapaFormatter",
        "visible": true,
        "style": "function (value, row, index, field) { let vs = {}; if(row.STEPFINISHDATE!=null) vs.background = ''lightyellow''; return { css: vs } }"
      },
      {
        "field": "FINISHDATE",
        "title": "Terminado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.DateAndTimeFormatter",
        "visible": false
      },
      {
        "field": "STEPFINISHDATE",
        "title": "Realizado por",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "app.ui.UpdateDateAndUserFormatter",
        "visible": false
      },
      {
        "field": "ROLES",
        "title": "Roles",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "width": 10,
        "widthUnit": ''%'',
        "visible": false
      },
      {
        "field": "STEPFINISHDATE",
        "title": "Estado de la etapa",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "formatter": "function (value, row, index, field) {  return value==null ? `<a href=@_../cases/case?id=${row.ID}@_ title=@_Ver caso #${row.ID}@_><span class=@_badge badge-warning@_><small> Pendiente </small></span></a>` : ''''; }",
        "width": 10,
        "widthUnit": ''%'',
        "style": "function (value, row, index, field) { let vs = {}; if(row.STEPFINISHDATE!=null) vs.background = ''lightyellow''; return { css: vs } }",
        "visible": true
      }
    ]
  }
}'),'Research',1,NULL,NULL,NULL,'Extend.Cases.js',TO_CLOB('SELECT DISTINCT PC.ID, PC.CONTACTMAINNAME, PC.TITLE, PC.DESCRIPTION, PC.STATUS, LKS.DESCRIPTION STATUSDESC, PC.LABEL, PC.SUBLABEL,
       PC.FLOWID, PF.NAME FLOWNAME, PC.INSTANCEID, PIF.CREATED, PIF.STARTDATE, PIF.FINISHDATE, PIF.DUEDATE,
       (select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID AND SSC.ID<=PC.CURRENTSTEPID) STEPCURRENT,
       (select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID) STEPTOTAL,
      CAST (((select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID AND SSC.ID<=PC.CURRENTSTEPID)*100)/(select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID) AS DECIMAL(5,0)) PROGRESS,
       PIS.STEPID, PIST.NAME STEPNAME, PIS.STARTDATE  STEPSTARTDATE, PIS.FINISHDATE STEPFINISHDATE, PIS.DUEDATE  STEPDUEDATE,
       (SELECT LISTAGG(RM.ROLENAME , '', '') WITHIN GROUP (ORDER BY RM.ROLENAME ) FROM PROCESSSPECSTEPROLE prm LEFT JOIN ROLEMEMBER rm ON rm.RoleId = prm.RoleId WHERE prm.COMPANYID=PC.CompanyId AND prm.ID=PIS.STEPID) Roles,
       PIS.USERID, um.FirstName || '' '' || um.LastName AS UpdateUserName
  FROM PROCESSCASE PC
  LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 61 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE =PC.STATUS
  LEFT JOIN PROCESSSPECFLOW PF ON PF.COMPANYID=PC.COMPANYID AND PF.ID=PC.FLOWID
  LEFT JOIN PROCESSINSTANCE PIF ON PIF.COMPANYID=PC.COMPANYID AND PIF.INSTANCEID=PC.INSTANCEID AND PIF.STEPID=0
  LEFT JOIN PROCESSINSTANCE PIS ON PIS.COMPANYID=PC.COMPANYID AND PIS.INSTANCEID=PC.INSTANCEID AND PIS.STEPID>0 AND PIS.STEPID<=PC.CURRENTSTEPID AND PIS.TASKID=0 AND NOT PIS.STARTDATE IS NULL
  LEFT JOIN PROCESSSPECSTEP PIST ON PIST.COMPANYID=PIS.COMPANYID AND PIST.FLOWID=PIS.FLOWID AND PIST.ID=PIS.STEPID
  LEFT JOIN UserMember um ON um.UserId = PIS.USERID
  JOIN PROCESSSPECSTEPROLE prm2 ON prm2.COMPANYID=PC.CompanyId AND prm2.ID=PIST.ID
  JOIN ROLEMEMBER rm ON rm.RoleId = prm2.RoleId and lower(rm.rolename) in ({app.UserRoleNameList})
WHERE PC.CompanyId=100 AND PC.FLOWID>0 AND (select count(*')||TO_CLOB(') from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID) > 0
ORDER BY PC.ID DESC,PIS.STARTDATE DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (4005,1,9,'Purdy Reporte de siniestros','Panel',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-03-29 20:02:48',TO_CLOB('<CLOB>'),NULL,NULL,'Reporte de siniestros|titulo
|zona|12
 Generar el reporte|Boton|class=btn-block btn-primary;click=app.core.GetPDF(''excel.4006'',true,''purdy.siniestros.xlsx'')',NULL,NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (4006,1,1,'Purdy Reporte de siniestros','Reporte',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-12-30 15:40:46',TO_CLOB('<CLOB>'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('EM_K_MAPFRE_ALIADOS.PURDYREPSINIESTROS {app.P_COD_AGT}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (4007,1,9,'Mapfre Reporte de siniestros','Panel',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-03-29 20:02:48',TO_CLOB('<CLOB>'),NULL,NULL,'Reporte de siniestros|titulo
|zona|12
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Agente|lista|name=cod_agt;lookup=Agents.
 Generar el reporte|Boton|class=btn-block btn-primary;click=app.core.GetXLSX(''4008'', ''mapfre.siniestros.xlsx'', true)',NULL,NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (4008,1,1,'Mapfre Reporte de siniestros','Reporte',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2020-12-30 15:40:46',TO_CLOB('<CLOB>'),'Tron',2,NULL,NULL,NULL,NULL,TO_CLOB('EM_K_MAPFRE_ALIADOS.MAPFREREPSINIESTROS {cod_agt} {desde:date} {hasta:date}'));
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
          "title": "Vigencia",
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
         ')||TO_CLOB(' "colspan": 2
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
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (7000,1,7,'Cotizaciones vigentes','Card',NULL,NULL,NULL,NULL,1,1,111,TIMESTAMP'2021-10-27 21:21:42',NULL,'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT COUNT(p30.num_poliza) Cotizaciones
  FROM P2000030 p30
  WHERE  p30.cod_cia = 1
  and p30.num_poliza  not in  (
       select a.num_presupuesto
       from a2000030 a, p2000030 p
       where a.num_presupuesto = p.num_poliza
       and a.fec_efec_poliza>= SYSDATE-180
       )
  and p30.cod_ramo = 302
  and p30.cod_agt = {app.P_COD_AGT}
  and p30.tip_spto = ''XX''
  and p30.fec_efec_poliza >= SYSDATE-180'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (7000,2,7,'Pólizas activas','Card',NULL,NULL,NULL,NULL,1,1,111,TIMESTAMP'2021-10-27 21:23:06',NULL,'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT count(a.num_poliza) POLIZAS
  FROM a2000030 a
 WHERE a.cod_cia            = {app.P_COD_CIA}
   AND a.cod_agt            = {app.P_COD_AGT}
   AND a.mca_spto_anulado   = ''N''
   AND a.mca_poliza_anulada = ''N''
   AND a.mca_provisional    = ''N''
   AND a.num_spto  in (select max(num_spto)
                       from a2000030 a20
                      where a20.cod_cia  = a.cod_cia
                        and a20.num_poliza = a.num_poliza
                        AND a20.mca_spto_anulado = ''N'')'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (7000,3,7,'Siniestros activos','Card',NULL,NULL,NULL,NULL,1,1,111,TIMESTAMP'2021-10-27 21:24:17',NULL,'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT COUNT(a10.num_sini) SINIESTROS
  FROM a7000900 a90,
           a7001000 a10
     where a90.cod_cia     = {app.P_COD_CIA}
       and a90.cod_agt     = {app.P_COD_AGT}
       ---
       and a10.cod_cia     = a90.cod_cia
       and a10.num_sini    = a90.num_sini
       and a10.tip_est_exp = ''P'''));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (7000,4,7,'Recibos pendientes','Card',NULL,NULL,NULL,NULL,1,1,111,TIMESTAMP'2021-10-27 21:25:42',NULL,'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT COUNT(c.num_recibo) recibos
    FROM a2000030 a
    JOIN a2990700 c
      ON c.cod_cia = a.cod_cia
     AND c.num_spto = a.num_spto
     AND c.num_apli = a.num_apli
     AND c.num_poliza = a.num_poliza
     AND c.num_spto_apli = a.num_spto_apli
     AND c.tip_situacion in (''RE'',''EP'')
     AND trunc(c.fec_efec_recibo) <= trunc(sysdate) + 10
   WHERE a.cod_cia             = {app.P_COD_CIA}
     AND a.cod_agt             = {app.P_COD_AGT}
     AND a.mca_spto_anulado    = ''N''
     AND a.mca_poliza_anulada  = ''N'''));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (7000,10,7,'Ultimas cotizaciones','Card',NULL,NULL,NULL,NULL,1,1,111,TIMESTAMP'2021-10-28 17:56:27',NULL,'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT p30.num_poliza "NUM_PRESUPUESTO", p30.fec_actu,
  LISTAGG(p20.txt_campo, '' - '') WITHIN GROUP (ORDER BY p20.num_secu) "DETALLE" , a1402.nom_fracc_pago "FRACCIONAMIENTODEPAGO",
  CASE
  WHEN SYSDATE-p30.fec_actu<30 THEN ''Pendiente''
  ELSE ''Vencido''
END AS Vigencia
  FROM P2000030 p30, p2000020 p20, a1001403 a1403, a1001402 a1402
  WHERE p30.fec_efec_poliza >= SYSDATE-{const.180}
  and p30.cod_ramo = {const.302}
  and p30.tip_spto = ''XX''
  and p30.num_poliza  not in  (
                               select a.num_presupuesto
                               from a2000030 a, p2000030 p
                               where a.num_presupuesto = p.num_poliza
                               and a.fec_efec_poliza>= SYSDATE-{const.180}
                               and p30.cod_agt = {app.P_COD_AGT}
                               )
  and p30.cod_agt = {app.P_COD_AGT}
  --Datos Variales
  and p30.num_poliza = p20.num_poliza
  and p30.cod_cia = p20.cod_cia
  and p30.num_spto = p20.num_spto
  and p30.num_apli = p20.num_apli
  and p30.num_spto_apli = p20.num_spto_apli
  and p30.cod_ramo = p20.cod_ramo
  and p20.cod_campo in (''COD_MARCA'',''COD_MODELO'',''ANIO_SUB_MODELO'',''COD_TIP_VEHI'',''COD_PLAN_AUTO'',''IMP_VR'',''DED_AUTO_CYV'')
  --Fraccionamiento de pago
  and p30.cod_cia = a1403.cod_cia
  and p30.cod_mon = a1403.cod_mon
  and p30.cod_ramo = a1403.cod_ramo
  and p30.cod_fracc_pago = a1403.cod_fracc_pago
  and a1403.cod_cia = a1402.cod_cia
  and a1403.cod_fracc_pago = a1402.cod_fracc_pago
  group by p30.num_poliza, p30.fec_actu,  a1402.nom_fracc_pago
  order by p30.fec_actu desc, p30.num_poliza,  a1402.nom_fracc_pago
  FETCH FIRST {NumRows} ROWS ONLY'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (7000,11,7,'Ultimas pólizas emitidas','Card',NULL,NULL,NULL,NULL,1,1,111,TIMESTAMP'2021-10-28 19:02:01',NULL,'Tron',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT a30.fec_actu, a30.NUM_POLIZA, LISTAGG(a20.txt_campo, '' - '') WITHIN GROUP (ORDER BY a20.num_secu) "DETALLE", a30.fec_efec_poliza, a30.fec_vcto_poliza, a1402.nom_fracc_pago "FRACCIONAMIENTODEPAGO",
       a1331.tip_docum, a1331.cod_docum, a1331.tlf_numero, a1331.email, v1390.NOM_COMPLETO
  FROM a2000030 a30
  LEFT JOIN a1001402 a1402 ON  a1402.cod_cia = a30.cod_cia AND a1402.COD_FRACC_PAGO = a30.COD_FRACC_PAGO
  LEFT JOIN A2000020 a20 ON a20.cod_cia = a30.cod_cia and a20.num_poliza = a30.num_poliza and a20.num_spto = a30.num_spto and a20.num_apli = a30.num_apli and a20.num_spto_apli = a30.num_spto_apli and a20.cod_ramo = a30.cod_ramo and a20.cod_campo in (''COD_MARCA'',''COD_MODELO'',''ANIO_SUB_MODELO'',''COD_TIP_VEHI'',''COD_PLAN_AUTO'',''IMP_VR'',''DED_AUTO_CYV'')
  LEFT JOIN a1001331 a1331 ON a1331.cod_cia = a30.cod_cia AND a1331.TIP_DOCUM = a30.TIP_DOCUM AND a1331.COD_DOCUM = a30.COD_DOCUM
  LEFT JOIN v1001390 v1390 ON v1390.cod_cia = a30.cod_cia AND v1390.TIP_DOCUM = a30.TIP_DOCUM AND v1390.COD_DOCUM = a30.COD_DOCUM
 WHERE a30.cod_cia            = 1
   AND a30.cod_agt            = {app.P_COD_AGT}
   AND a30.mca_spto_anulado   = ''N''
   AND a30.mca_poliza_anulada = ''N''
   AND a30.mca_provisional    = ''N''
   AND a30.num_spto in (select max(num_spto) from a2000030 a20 where a20.cod_cia  = a30.cod_cia and a20.num_poliza = a30.num_poliza AND a20.mca_spto_anulado = ''N'')
 GROUP BY a30.fec_actu, a30.NUM_POLIZA, a30.fec_efec_poliza, a30.fec_vcto_poliza, a1402.nom_fracc_pago,   a1331.tip_docum, a1331.cod_docum, a1331.tlf_numero, a1331.email, v1390.NOM_COMPLETO
 ORDER BY a30.fec_actu DESC
FETCH FIRST {NumRows} ROWS ONLY
'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9000,1,9,'Enviar certificado por correo','Panel',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'1970-02-07 00:00:00',NULL,NULL,NULL,'Enviar certificado por correo|título
|zona|12
 Principal+|Correo
 Copia 1|Correo
 Copia 2|Correo
 Enviar|Boton|click=app.core.ExternalCall(app.Cotizacion, ''Cotizacion.js'', ''app.Cotizacion.EnviarCertificado({NUM_POLIZA},{NUM_RIESGO},$(@_#principal@_).val(),$(@_#copia1@_).val(),$(@_#copia1@_).val())'')
',NULL,NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9001,1,9,'Enviar solicitud',NULL,NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-07-12 21:08:55',NULL,NULL,NULL,'Enviar solicitud|titulo
|zona|12
 Correo+|Correo|default={PRIMARYEMAILADDRESS}
 Enviar|Boton|click=app.Extend.NuevoEnvio({PROPOSALID},$(@_qt#correo@_qt).val())',NULL,NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9002,1,9,'Cargar de documento','Panel',NULL,NULL,NULL,NULL,1,1,77,TIMESTAMP'2021-12-21 10:19:24',NULL,NULL,NULL,'Cargar de documento|título|name=DocumentUpload
|zona|12
 Descripción+|Texto(120)
 Archivo+|Archivo
 Guardar|Boton|class=btn-form btn-primary float-right;event.click=app.core.UpLoadFileEx(''#DocumentUploadEdtForm'', ''#archivo'', 3000, {NUM_POLIZA}, 99, $(''#descripcion'').val(), function (fileList) { $(''#9002 .close'').click()@_sc app.ViewerQuery.Refresh(undefined, $(''#6GridTbl''), 302,'''',6)@_sc })',NULL,NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9003,1,9,'Cancelar una p?liza','Panel',NULL,NULL,NULL,NULL,1,1,888,TIMESTAMP'2023-03-31 00:00:00',NULL,NULL,NULL,'Cancelar la póliza #|título
|zona|12
 Fecha de cancelación+|fecha|default=today;name=Fec_Anulacion
 Motivo+|nota|filas=2;name=Mot_Spto
 Cancelar|Boton|name=CancelarBtn;click=app.Ex_Policy.Cancelar({NUM_POLIZA});class=btn-danger',NULL,NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9004,1,9,'Control tecnico','Panel',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 00:00:00',NULL,NULL,NULL,'Control tecnico|titulo
|zona|12
 Ramo|text|name=cod_ramo
 Causa del control|nota|files=2
 Estatus+|lista|name=tip_autoriza;values=1->Autoriza,2->Rechaza,3->Pendiente
 Observacion+|nota|name=observacion;files=2
 Principal|Correo|name=correo1
 Copia 1|Correo|name=correo2
 Procesar|Boton|event.clickWithValidate=app.Ex_Policy.ControlTecnico_Procesar;class=btn-primary',NULL,NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9005,1,9,'Renovar una p?liza','Panel',NULL,NULL,NULL,NULL,1,1,888,TIMESTAMP'2023-03-31 00:00:00',NULL,NULL,NULL,'Renovar una p?liza|t?tulo
|zona|12
 Renovar|Boton|event.clickWithValidate=app.Ex_Policy.Renovacion_Procesar;class=btn-primary',NULL,NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9006,1,9,'Enviar enlace de pago','Panel',NULL,NULL,NULL,NULL,1,1,2025,TIMESTAMP'2025-01-15 00:00:00',NULL,NULL,NULL,'Opciones de pago|titulo
|zona|12
 Enviar por Correo|Boton|name=ESendBtn;click=app.Payment.CorreoInfo({NUM_POLIZA},{NUM_RECIBO},{COD_AGT});class=btn-danger btn-outline btn-block m-t
 Pago Directo|Boton|name=DirectBtn;click=app.Payment.SendLink(''Direct'',{NUM_POLIZA},{NUM_RECIBO},{COD_AGT});class=btn-danger btn-outline btn-block m-t',NULL,NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9007,1,9,'Cambio de beneficiario pagador','Panel',NULL,NULL,NULL,NULL,1,1,888,TIMESTAMP'2023-03-31 00:00:00',NULL,NULL,NULL,'Cambio de beneficiario pagador|título
|zona|12
 Identificación+|cedula
 Aplicar cambio|Boton|name=ApplyChangeBtn;click=app.Ex_Policy.ChangePayer({NUM_POLIZA}, {NUM_RIESGO});class=btn-primary',NULL,NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9008,1,9,'Enviar de link de pago',NULL,NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-07-12 21:08:55',NULL,NULL,NULL,'Enviar enlace de pago|titulo
|zona|12
 Correo+|Correo|default={EMAIL}
 Enviar|Boton|click=app.Payment.SendLink(''Correo'',{NUM_POLIZA},{NUM_RECIBO},{COD_AGT},$(@_qt#correo@_qt).val())',NULL,NULL,NULL,NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9100,1,9,'Información del proveedor','Form',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 00:00:00',NULL,NULL,NULL,'Información del proveedor|título
Datos para la busqueda|zona|4
 Identificación del proveedor a buscar+|texto(12)|name=SUPPLIER_ID
 Buscar|button|name=btnSearch;class=btn-on-primary
Datos del proveedor|zona|4
 Nombre|texto|name=SUPPLIER_NM;disabled=true
 Direcci?n|texto|name=ADDR;disabled=true
 C?digo postal|texto|name=POST_NO;disabled=true
 P?gina web|texto|name=HPAGE;disabled=true
Datos de contacto|zona|4
 N?mero de teléfono|texto|name=TEL_NO;disabled=true
 N?mero de fax|texto|name=FAX_NO;disabled=true
 Correo electrónico|texto|name=EMAIL;disabled=true',NULL,'InformacionProveedor','Form.Ext.SICOP.js',NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9101,1,9,'Notificar a SICOP de la recepción de garantías electrónicas de participación y cumplimiento','Form',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 00:00:00',NULL,NULL,NULL,'Notificar a SICOP de la recepcion de garantias electronicas de participacion y cumplimiento|titulo
Datos de la garantia electronica|zona|3
 Numero+|texto(14)|name=Guarantee_number|title=Cedula juridica institucion que promueve el proceso de contratacion
 Secuencia+|texto(2)|name=Guarantee_sequencenumber|disabled=true
 Tipo|radio|name=Guarantee_type_code|values=BG->Participacion,CG->Cumplimiento,PG->Colateral|datatype=string
 Forma de pago|lista|name=Guarantee_payment_code|datatype=string|values=01->Efectivo,02->Certificados depositos,03->Cheque certificado,05->Bono del estado,06->Cheque gerencia,07->Garantia Electronica|default=07|disabled=true
 Numero de cuenta|texto(20)|name=Cuenta_cliente|title=Solo en caso de ser garantias en efectivo|visible=ctrol.Guarantee_payment_code.eq.''01'' 
 Moneda+|radio|name=Moneda|values=CRC->Colon Costarricense,USD->Dolar|default=CRC|datatype=string
 Monto total+|decimal(18,3)|name=Guarantee_amount
 Tipo de modificacion+|radio|name=Tipo_de_modification|values=01->Ampliacion de plazo,02->Ampliacion de monto,03->Prorroga de plazo y monto|datatype=string|hidden=true 
Datos de la entidad garante|zona|3  
 Cedula juridica+|texto(10)|name=Guarantee_identifier|disabled=true
 Entidad garante|texto(200)|name=Guarantee_name|disabled=true
 Nombre del funcionario|texto(200)|name=Guarantee_charge_person_name|column=6
 Correo electronico|Correo(50)|name=Guarantee_charge_person_email
 Telefono|Telefono(16)|name=Guarantee_telephone_number|modo=simple
 Codigo postal|texto(5)|name=Guarantee_postal_code
 Direccion|nota(200)|name=Guarantee_address_line|filas=2|column=6 
Datos generales|zona|3
 Numero de procedimiento+|texto(24)|name=Institucion_notice_number
 Numero del pliego de condiciones+|texto(11)|name=Notice_number|title=Numero de cartel en SICOP
 Cedula del proveedor+|texto(12)|name=Supplier_identifier|title=Garantia por cuenta de
 Nombre del proveedor|texto(200)|name=Supplier_name|disabled=true
 Cedula de la institucion+|texto(10)|name=Institution_identifier|title=Garantia a favor de
 Fecha de inicio de validez+|fechainicio|name=Issue_date|default=today|title=Fecha de inicio de validez de la garantia
 Fecha de vencimiento+|fechafin|name=Valid_period_date|title=Fecha de vencimiento de la garantia
 Comentarios de la garantia|nota(2000)|name=Guarantee_contents|filas=4|column=6 
 Notificar|button|name=btnNotify|class=btn-on-primary',NULL,'NotificarGarantia','Form.Ext.SICOP.js',NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9102,1,9,'Notificar a SICOP de la recepción de garantías electrónicas de participación y cumplimiento','Form',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 00:00:00',NULL,NULL,NULL,'Notificar a SICOP sobre la ejecucion de los procesos de liberacion y ejecucion de las Garantias Electronicas por parte de la Institucion promotora del proceso de Contratacion Administrativa|titulo
Datos generales|zona|3
 Numero de garantia electronica generado por la entidad garante+|texto(14)|name=Guarantee_number|disabled=true
 Secuencia de la garantia electronica+|texto(2)|name=Guarantee_sequencenumber|disabled=true
 Cedula juridica de la entidad garante|texto(10)|name=Guarantee_identifier|disabled=true
 Nombre de la entidad garante|texto(200)|name=Guarantee_name|disabled=true
 Numero de cuenta en la cual se deposito el monto solicitado|texto(20)|name=Cuenta_cliente|disabled=true
 Moneda+|radio|name=Moneda|values=CRC->Colon Costarricense,USD->Dolar|default=CRC|datatype=string|disabled=true
 Monto de ejecucion/liberacion de la garantia+|decimal(18,3)|name=Execute_release_amount|disabled=true
 Numero de comprobante de la transaccion|texto(25)|name=Transaction_num
 Fecha y hora de la fecha en que se hace efectiva la ejecucion o liberacion de la garantia+|fecha|name=Date_time|default=today
 Descripcion o comentario de la ejecucion/liberacion de la Garantia|nota(2000)|name=Execute_release_contents|filas=4|column=6 
 Notificar|button|name=btnNotify|class=btn-on-primary',NULL,'NotificarLiberacion','Form.Ext.SICOP.js',NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9103,1,1,'Garantías electrónicas',NULL,NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'2024-05-13 00:00:00',TO_CLOB('{
	"title": "Garantías electrónicas",
	"table": {
		"pagination": true,
		"search": true,
		"showToggle": false,
		"showRefresh": true,
		"showColumns": true,
		"showExport": true,
		"showPaginationSwitch": false,
		"exportTypes": [
			"csv"
		],
		"buttons": "app.Form_Ext_SICOP.Boton",
		"detailId": 9104,
		"detailParameters": "code=GUARANTEE_NUMBER",
		"columns": [
			{
				"title": "Acciones",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.Form_Ext_SICOP.ActionFormatter",
				"events": true,
				"action_editar": "app.ui.Redirect(''../viewer/Form?id=NotificarGarantia&code={GUARANTEE_NUMBER}'')",
				"action_liberar": "app.ui.Redirect(''../viewer/Form?id=NotificarLiberacion&code={GUARANTEE_NUMBER}'')"
			},
			{
				"field": "GUARANTEE_NUMBER",
				"title": "Garantía #",
				"sortable": true,
				"halign": "center",
				"align": "center",
				"format": "<a href=''../viewer/Form?id=NotificarGarantia&code={GUARANTEE_NUMBER}'' title=''Modificar la garantía #{GUARANTEE_NUMBER}''>{GUARANTEE_NUMBER} - {GUARANTEE_SEQUENCENUMBER}</a>"
			},		
{
				"field": "EX_METODO",
				"title": "Estado",
				"sortable": true,
				"halign": "center",
				"align": "center",
				"formatter": "app.Form_Ext_SICOP.EstadoFormatter",
				"visible": true
			},
			{
				"field": "EX_CODIGO_PROCESO",
				"title": "Código de proceso",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
            {
                "field": "EX_FECHA_PROCESO",
                "title": "Fecha y hora del estado",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateAndTimeFormatter",
				"visible": false
            },
			{
				"field": "ISSUE_DATE",
				"title": "Fecha de inicio",
				"sortable": true,
				"halign": "center",
				"align": "')||TO_CLOB('center",
				"formatter": "app.ui.DateFormatter"
			},            
			{
				"field": "VALID_PERIOD_DATE",
				"title": "Fecha de vencimiento",
				"sortable": true,
				"halign": "center",
				"align": "center",
				"formatter": "app.ui.DateFormatter"
			},
			{
				"field": "GUARANTEE_TYPE_CODE",
				"title": "Tipo",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.LookUpListFormatter",
				"lookupList": "[{''code'':''BG'',''desc'':''Participación''},{''code'':''CG'',''desc'':''Cumplimiento''},{''code'':''PG'',''desc'':''Colateral''}]"
			},
			{
				"field": "INSTITUTION_IDENTIFIER",
				"title": "Institución que promueve",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter"
			},
			{
				"field": "SUPPLIER_IDENTIFIER",
				"title": "Proveedor",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter"
			},
			{
				"field": "GUARANTEE_IDENTIFIER",
				"title": "Entidad garante",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"format": "{GUARANTEE_IDENTIFIER} {GUARANTEE_NAME}",
				"visible": false
			},
			{
				"field": "INSTITUCION_NOTICE_NUMBER",
				"title": "Número de procedimiento",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "NOTICE_NUMBER",
				"title": "Número de cartel",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter"
			},
			{
				"field": "CUENTA_CLIENTE",
				"title": "Número de cuenta",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "GUARANTEE_CHARGE_PERSON_NAME",
				"title": "Nombre del funcionario",

				"sortable": true,
				"halign": "center",')||TO_CLOB('
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "GUARANTEE_CHARGE_PERSON_EMAIL",
				"title": "Correo electrónico del funcionario",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "GUARANTEE_TELEPHONE_NUMBER",
				"title": "Teléfono del funcionario",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "GUARANTEE_POSTAL_CODE",
				"title": "Código postal del funcionario",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "GUARANTEE_ADDRESS_LINE",
				"title": "Dirección del funcionario",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "GUARANTEE_PAYMENT_CODE",
				"title": "Forma de pago",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.LookUpListFormatter",
				"lookupList": "[{''code'':''01'',''desc'':''Efectivo''},{''code'':''02'',''desc'':''Certificados depósitos''},{''code'':''03'',''desc'':''Cheque certificado''},{''code'':''05'',''desc'':''Bono del estado''},{''code'':''06'',''desc'':''Cheque gerencia''},{''code'':''07'',''desc'':''Garantía Electrónica''}]"
			},
			{
				"field": "GUARANTEE_AMOUNT",
				"title": "Monto",
				"sortable": true,
				"halign": "center",
				"align": "right",
				"formatter": "app.ui.CurrencyAmountFormatter"
			},
			{
				"field": "MONEDA",
				"title": "Moneda",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "TIPO_DE_MODIFICATION",
				"title": "Tipo de cambio",
				"sortable": true,')||TO_CLOB('
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.LookUpListFormatter",
				"lookupList": "[{''code'':''01'',''desc'':''Ampliación de plazo''},{''code'':''02'',''desc'':''Ampliación de monto''},{''code'':''03'',''desc'':''Prórroga de plazo y monto''}]",
				"visible": false
			},
			{
				"field": "GUARANTEE_CONTENTS",
				"title": "Comentarios",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter"
			},
			{
				"field": "CONFIRMATION",
				"title": "Confirmación",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "MSG_ERR",
				"title": "Mensaje retornado",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter"
			},
			{
				"field": "UPDATEDATE",
				"title": "Realizado por",
				"sortable": true,
				"halign": "center",
				"align": "center",
				"formatter": "app.ui.UpdateDateAndUserFormatter"
			}
		]
	}
}'),'Research',1,NULL,NULL,NULL,'Form.Ext.SICOP.js',TO_CLOB('SELECT ID, INSTITUTION_IDENTIFIER, SUPPLIER_IDENTIFIER, GUARANTEE_IDENTIFIER, GUARANTEE_NAME, INSTITUCION_NOTICE_NUMBER, NOTICE_NUMBER, CUENTA_CLIENTE, GUARANTEE_CHARGE_PERSON_NAME, GUARANTEE_CHARGE_PERSON_EMAIL, GUARANTEE_TELEPHONE_NUMBER, GUARANTEE_POSTAL_CODE, GUARANTEE_ADDRESS_LINE, GUARANTEE_NUMBER, GUARANTEE_SEQUENCENUMBER, GUARANTEE_TYPE_CODE, GUARANTEE_PAYMENT_CODE, GUARANTEE_AMOUNT, MONEDA, ISSUE_DATE, VALID_PERIOD_DATE, TIPO_DE_MODIFICATION, GUARANTEE_CONTENTS, CONFIRMATION, MSG_ERR, UPDATEUSERCODE, UPDATEDATE, SUPPLIER_NAME, EX_METODO, EX_CODIGO_PROCESO, EX_FECHA_PROCESO FROM ELECTRONICWARRANTY P
WHERE P.Guarantee_sequencenumber = (SELECT max(Guarantee_sequencenumber) FROM ElectronicWarranty M WHERE M.Guarantee_number = P.Guarantee_number) ORDER BY UPDATEDATE DESC'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9104,1,1,'Garantías electrónicas - Historia',NULL,NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'2024-05-13 00:00:00',TO_CLOB('{
    "title": "Historia",
    "table": {
  		"pagination": true,
		"search": false,
		"showToggle": false,
		"showRefresh": false,
		"showColumns": false,
		"showExport": false,
        "columns": [
            {
                "field": "Guarantee_sequencenumber",
                "title": "N?mero de secuencia",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Guarantee_amount",
                "title": "Monto de la garant?a",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.CurrencyAmountFormatter"
            },
            {
                "field": "Valid_period_date",
                "title": "Fecha de Vencimiento",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter"
            },
            {
                "field": "Tipo_de_modificationDesc",
                "title": "Tipo de modificaci?n",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "UpdateDate",
                "title": "Fecha y hora de recepci?n de garant?a",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateAndTimeFormatter"
            }
        ]
    }
}'),'Research',1,NULL,NULL,NULL,'Form.Ext.SICOP.js',TO_CLOB('SELECT Guarantee_sequencenumber "Guarantee_sequencenumber", Guarantee_amount "Guarantee_amount", Moneda "Moneda",  Valid_period_date "Valid_period_date", DECODE(Tipo_de_modification, ''01'',''Ampliaci?n de plazo'',''02'',''Ampliaci?n de monto'',''03'',''Pr?rroga de plazo y monto'', '''') "Tipo_de_modificationDesc", UpdateDate "UpdateDate"
FROM ElectronicWarranty P WHERE Guarantee_number={code:varchar} ORDER BY Guarantee_sequencenumber DESC'));
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
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9106,1,9,'Anular una póliza','Form',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 00:00:00',NULL,NULL,NULL,'Anular una pólizas|título
Datos generales|zona|columns=4|width=6
 Ramo+|lista|name=RAMO|values=194->Accidentes personales,401->Saldo deudor declarativo,117->Seguro vida colectivo|disabled=true
 Contrato+|lista|name=NUM_CONTRATO|disabled=true
 Póliza Grupo|texto(13)|name=NUM_POLIZA_GRUPO|disabled=true
 Moneda|texto|name=MONEDA|disabled=true
 Inicio de vigencia+|fechainicio|name=EFEC_SPTO|disabled=true
 Fin de vigencia+|fechafin|name=VCTO_SPTO|disabled=true
Datos del asegurado|zona|columns=4|width=6
 Identificación+|cedula|name=COD_DOCUM_ASEG|disabled=true
 Nombre+|texto(20)|name=NOM_TERCERO_ASEG|disabled=true
 Apellido+|texto(20)|name=APE_TERCERO_ASEG|disabled=true
 Fecha de nacimiento|Nacimiento|name=NAC_ASEG|disabled=true
 Sexo|radio|name=MCA_SEXO_ASEG|values=0->Femenino,1->Masculino|disabled=true
 Nacionalidad|tron.País|name=NACIONALIDAD_ASEG|disabled=true
 Provincia|tron.Provincia|name=COD_ESTADO|disabled=true
 Cantón|tron.Cantón|name=COD_PROVINCIA|disabled=true
 Distrito|tron.Distrito|name=COD_LOCALIDAD|disabled=true
 Otra señas|nota(180)|name=DOMICILIO|filas=2|column=12|disabled=true
Datos del riesgo|zona|columns=4|visible=entry.RAMO.neq.0
 Número del préstamo|texto(30)|name=NUM_PRESTAMO|visible=entry.RAMO.eq.401|disabled=true
 Inicio del préstamo|fecha|name=INI_PRESTAMO|visible=entry.RAMO.eq.401|disabled=true
 Fin del préstamo|fecha|name=VCTO_PRESTAMO|visible=entry.RAMO.eq.401|disabled=true
 Suma asegurada|decimal(18,3)|name=IMP_SUMA_ASEG|visible=entry.RAMO.eq.401|disabled=true
 Prima informada|decimal(18,3)|name=IMP_PRIMA_INFORMADA|visible=entry.RAMO.eq.117.or.entry.RAMO.eq.401|disabled=true
 Identificación del estudiante|texto(15)|name=ID_CRED_ESTUDIANTE|visible=entry.RAMO.eq.194|disabled=true
 ¿Asistencia?|radio|name=MCA_ASISTENCIA|values=1->Si,2->No|disabled=true
 Suma asegurada por muerte|decimal(18,3)|name=IMP_SUMA_MUERTE|visible=entry.RAMO.eq.194|disabled=true
 Plan|texto(30)|name=COD_PLAN_AP|visible=entry.RAMO.eq.194|disabled=true
 Anular|button|name=btnIssue|class=btn-on-primary|disabled=true
',NULL,'AnularPoliza','Form.Ext.Bajas.js',NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (9107,1,9,'Pólizas excluidas para clientes','Form',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'2025-07-23 00:00:00',NULL,NULL,NULL,'Pólizas excluidas|tabla|showtitle=false
 Número de póliza grupo+|lista|name=NUM_POLIZA|lookup=POLIZA_GRUPO|format={NUM_POLIZADesc}|visible=false
 Número de póliza grupo+|texto(226)|name=NUM_POLIZA_NOM|tablevisible=false|helptext=Indique el número de la póliza o nombre asociada a la misma
 Número de contrato|lista|name=NUM_CONTRATO|format={NUM_CONTRATODesc}',NULL,'ExcludedPolicies','Form.Ext.ExcludedPolicies.js',NULL);
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (10000,1,8,'Export','Roles permitidos',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-03-03 20:16:42',NULL,'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT RoleId "Código de Rol", RoleName "Rol", RoleMember.Description "Descripción", RoleMember.SecurityLevel "Seguridad", RoleMember.RecordStatus "Código de estado", RecordStatusLkP.Description "Estado", 
       RoleMember.UpdateUserCode "Código de usuario", um.FirstName || '' '' || um.LastName "Usuario", RoleMember.UpdateDate "Actualización" 
  FROM RoleMember    
  LEFT JOIN LOOKUP RecordStatusLkP ON RecordStatusLkP.LOOKUPID = 1 AND RecordStatusLkP.LANGUAGE=1 AND RecordStatusLkP.PARENTLOOKUPID=0 AND RecordStatusLkP.CODE=RoleMember.RecordStatus
  LEFT JOIN UserMember um ON um.UserId = RoleMember.UpdateUserCode
 WHERE RoleMember.CompanyId={app.companyid}
 ORDER BY RoleName'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (10001,1,8,'Formato de carga SISMAP','Títulares',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'1970-02-07 00:00:00',NULL,'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT 0 IDEPOL, 5 CLASE, TO_CHAR(R.ISSUEDATE, ''YYYYMMDD'') "FECHA DE EFECTIVIDAD", RL.LASTNAME APELLIDOS, RL.FIRSTNAME NOMBRES, DECODE(RL.GENDER,1,''M'',''F'') SEXO, REPLACE(RL.DOCUMENTNUMBER,''-'','''') CEDULA, TO_CHAR(RL.BIRTHDATE, ''YYYYMMDD'') "FECHA DE NACIMIENTO",
       B.MONTHLYSALARY SALARIO, R.INSUREDAMOUNT "SUMA ASEG.", ''O'' "MOTIVO DE CONTINUIDAD", TO_CHAR(R.ISSUEDATE, ''YYYYMMDD'') "FECHA EFECTIVA DE LA CONT.", ''AMSA'' "COMPAÑÍA ANTERIOR",
       NULL "# POLIZA ANTERIOR", NULL "MAXIMO VITALICIO CONSUMIDO", NULL "DEDUCIBLE CONSUMIDO", NULL "# EMPLEADO", ROWNUM "# CERTIFICADO ANTERIOR",
       NULL "CENTRO DE COSTO", RL.WEIGHT PESO, RL.HEIGHT ESTATURA, NULL RECARGO, NULL "CODIGO DIVISION", DECODE(RL.DOCUMENTTYPE,2,''P'') "TIPO DE IDENTIFICACION"
  FROM RISKROLES RL
  LEFT JOIN RISK R ON R.ID=RL.POLICYID AND R.COMPANYID=RL.COMPANYID
  LEFT JOIN RISKBAYER B ON B.ID=RL.POLICYID AND B.COMPANYID=RL.COMPANYID
 WHERE RL.COMPANYID=4 AND RL.TYPE=2 AND R.ISSUEDATE >= {desde:date} AND R.ISSUEDATE <= {hasta:date}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (10001,2,8,'Formato de carga SISMAP','Dependientes',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'1970-02-07 00:00:00',NULL,'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('SELECT 0 IDEPOL, ROWNUM "# CERTIFICADO", NULL "NOMBRE UNICO", RL.FIRSTNAME "NOMBRE DEPENDIENTE", RL.LASTNAME "APELLIDO DEPENDIENTE", REPLACE(RL.DOCUMENTNUMBER,''-'','''') "CEDULA DEPENDIENTE", TO_CHAR(RL.BIRTHDATE, ''YYYYMMDD'') "FECHA NACIMIENTO DEPENDIENTE", DECODE(RL.GENDER,1,''M'',2,''F'', null) SEXO,
       DECODE(RL.RELATIONSHIP,1,''E'',2,''H'', null) "RELACION (HIJO - ESPOSO)", TO_CHAR(R.ISSUEDATE, ''YYYYMMDD'') "FECHA EFECTIVA", REPLACE(RLT.DOCUMENTNUMBER,''-'','''') "CEDULA TITULAR",
       NULL "# POLIZA ANTERIOR", NULL "COMPAÑÍA ANTERIOR", TO_CHAR(R.ISSUEDATE, ''YYYYMMDD'') "FECHA CONTINUIDAD", NULL "DEDUCIBLE CONSUMIDO", NULL "VITALICIO CONSUMIDO", ''O'' "CODIGO CONTINUIDAD", DECODE(RL.DOCUMENTTYPE,2,''P'') "TIPO DE IDENTIFICACION"
  FROM RISKROLES RL
  LEFT JOIN RISK R ON R.ID=RL.POLICYID AND R.COMPANYID=RL.COMPANYID
  LEFT JOIN RISKBAYER B ON B.ID=RL.POLICYID AND B.COMPANYID=RL.COMPANYID
  LEFT JOIN RISKROLES RLT ON RLT.POLICYID=RL.POLICYID AND RLT.COMPANYID=RL.COMPANYID AND RLT.TYPE=2
 WHERE RL.COMPANYID=4 AND RL.TYPE=90 AND R.ISSUEDATE >= {desde:date} AND R.ISSUEDATE <= {hasta:date}'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (10002,1,9,'Excel para carga SISMAP','Panel',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-03-29 20:02:48',NULL,NULL,NULL,'Excel para carga SISMAP|título
|zona|12
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Exportar|Boton|class=btn-block btn-primary;click=app.core.GetXLSX(10001)',NULL,NULL,NULL,TO_CLOB('Excel para carga SISMAP|título
|zona|12
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Exportar|Boton|class=btn-block btn-primary;click=app.core.GetXLSX(10001)'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (10003,1,8,'Autocomplete','Marca, Modelo y Submodelo',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 20:16:42',NULL,'tron',1,NULL,NULL,'VehicleModelHelper',NULL,TO_CLOB('SELECT ma.nom_marca || '' '' || NVL(sm.nom_sub_modelo, mo.nom_modelo) titulo, ma.cod_marca, mo.cod_modelo, sm.cod_sub_modelo, ma.nom_marca, mo.nom_modelo, sm.nom_sub_modelo
  FROM a2100400 ma
  JOIN a2100410 mo ON mo.cod_cia=ma.cod_cia AND mo.cod_marca=ma.cod_marca AND mo.fec_validez <= SYSDATE AND mo.nom_modelo NOT IN (''ACURA'', ''ECLIPSE'', ''JOYCE'',''PARKTOWN'', ''SKYLINE'', ''MONTAINER'', ''TIBURON'', ''SONATA'', ''SANTAMO'')
  LEFT JOIN a2100420 sm ON sm.cod_cia=mo.cod_cia AND sm.cod_marca=ma.cod_marca AND sm.cod_modelo=mo.cod_modelo AND sm.fec_validez <= SYSDATE
 WHERE ma.cod_cia = 1 AND ma.fec_validez <= SYSDATE AND ma.mca_inh = ''N''
 ORDER BY ma.nom_marca, mo.nom_modelo, sm.nom_sub_modelo'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (10004,1,8,'Autocomplete','Provincia, canton y distrito',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 20:16:42',NULL,'tron',1,NULL,NULL,'AddressHelper',NULL,TO_CLOB('SELECT c.nom_prov || '', '' || d.nom_localidad || ''. '' || p.nom_estado || ''. '' || d.cod_localidad direccion,
       p.cod_estado, p.nom_estado, c.cod_prov, c.nom_prov, c.abr_prov, d.cod_localidad, d.nom_localidad, d.abr_localidad
  FROM A1000104 p
  LEFT JOIN a1000100 c ON c.cod_pais = p.cod_pais AND c.cod_estado = p.cod_estado AND c.mca_inh = ''N''
  LEFT JOIN A1000102 d ON d.cod_pais = p.cod_pais AND d.cod_prov = c.cod_prov AND d.mca_inh = ''N''
WHERE p.cod_pais = ''CRI'' AND p.mca_inh = ''N''
ORDER BY p.nom_estado, c.nom_prov, d.nom_localidad'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (10007,1,8,'Autocomplete','P?liza grupo / contrato',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 20:16:42',NULL,'tron',1,NULL,NULL,'PolicyGroupAndContract',NULL,TO_CLOB('SELECT DESCRIPCION, NUM_POLIZA, NUM_CONTRATO
FROM (
SELECT DISTINCT G2917.NOM_POLIZA DESCRIPCION, G2917.NUM_POLIZA, 0 NUM_CONTRATO, 1 NIVEL, G2917.NOM_POLIZA SEQ
  FROM G2990000 G29
  JOIN A2000010 A20 ON A20.COD_CIA = G29.COD_CIA AND A20.NUM_CONTRATO = G29.NUM_CONTRATO
  JOIN G2990017 G2917 ON G2917.COD_CIA = A20.COD_CIA AND G2917.NUM_POLIZA = A20.NUM_POLIZA
 WHERE G29.COD_CIA = 1
   AND G29.COD_RAMO > 0
   AND nvl(G29.COD_MON, 99) IN ({cod_mon}, 99)
   AND G29.COD_AGT = {app.agentcode}
UNION
SELECT ''> '' ||  to_char(G29.NUM_CONTRATO) || '' -  '' || G299.NOM_CONTRATO   DESCRIPCION, A20.NUM_POLIZA, G29.NUM_CONTRATO, 2 NIVEL, G2917.NOM_POLIZA  || '' - '' ||  G299.NOM_CONTRATO || '' - '' ||  to_char(G29.NUM_CONTRATO) SEQ
  FROM G2990000 G29
  JOIN A2000010 A20 ON A20.COD_CIA = G29.COD_CIA AND A20.NUM_CONTRATO = G29.NUM_CONTRATO
  JOIN G2990017 G2917 ON G2917.COD_CIA = A20.COD_CIA AND G2917.NUM_POLIZA = A20.NUM_POLIZA
  JOIN g2990001 G299 ON G299.COD_CIA = A20.COD_CIA AND G299.NUM_CONTRATO = A20.NUM_CONTRATO
 WHERE G29.COD_CIA = 1
   AND G29.COD_RAMO > 0
   AND nvl(G29.COD_MON, 99) IN ({cod_mon}, 99)
   AND G29.COD_AGT = {app.agentcode}
ORDER BY SEQ, NIVEL)'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (10008,1,8,'Autocomplete','P?liza grupo / contrato por agente',NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 20:16:42',NULL,'tron',1,NULL,NULL,'PolicyGroupAndContractByAgent',NULL,TO_CLOB('SELECT DESCRIPCION, NUM_POLIZA, NUM_CONTRATO
FROM (
SELECT DISTINCT G2917.NOM_POLIZA DESCRIPCION, G2917.NUM_POLIZA, 0 NUM_CONTRATO, 1 NIVEL, G2917.NOM_POLIZA SEQ
  FROM G2990000 G29
  JOIN A2000010 A20 ON A20.COD_CIA = G29.COD_CIA AND A20.NUM_CONTRATO = G29.NUM_CONTRATO
  JOIN G2990017 G2917 ON G2917.COD_CIA = A20.COD_CIA AND G2917.NUM_POLIZA = A20.NUM_POLIZA
 WHERE G29.COD_CIA = 1
   AND G29.COD_RAMO > 0
   AND nvl(G29.COD_MON, 99) IN ({cod_mon}, 99)
   AND G29.COD_AGT = {Cod_Agt}
UNION
SELECT ''> '' ||  to_char(G29.NUM_CONTRATO) || '' -  '' || G299.NOM_CONTRATO   DESCRIPCION, A20.NUM_POLIZA, G29.NUM_CONTRATO, 2 NIVEL, G2917.NOM_POLIZA  || '' - '' ||  G299.NOM_CONTRATO || '' - '' ||  to_char(G29.NUM_CONTRATO) SEQ
  FROM G2990000 G29
  JOIN A2000010 A20 ON A20.COD_CIA = G29.COD_CIA AND A20.NUM_CONTRATO = G29.NUM_CONTRATO
  JOIN G2990017 G2917 ON G2917.COD_CIA = A20.COD_CIA AND G2917.NUM_POLIZA = A20.NUM_POLIZA
  JOIN g2990001 G299 ON G299.COD_CIA = A20.COD_CIA AND G299.NUM_CONTRATO = A20.NUM_CONTRATO
 WHERE G29.COD_CIA = 1
   AND G29.COD_RAMO > 0
   AND nvl(G29.COD_MON, 99) IN ({cod_mon}, 99)
   AND G29.COD_AGT = {Cod_Agt}
ORDER BY SEQ, NIVEL)'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (10009,1,9,'Excel para carga ARS','Panel',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2021-03-29 20:02:48',TO_CLOB('<CLOB>'),NULL,NULL,'Excel para carga ARS|titulo
|zona|12
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Exportar|Boton|class=btn-block btn-primary;click=app.core.GetXLSX(10010)',NULL,NULL,NULL,TO_CLOB('Excel para carga ARS|titulo
|zona|12
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Exportar|Boton|class=btn-block btn-primary;click=app.core.GetXLSX(10010)'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (10010,1,8,'Carga electronica ARS','Carga electronica ARS',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'1970-02-07 00:00:00',TO_CLOB('<CLOB>'),'Research',1,NULL,NULL,NULL,NULL,TO_CLOB('WITH CTE AS (SELECT A.POLICYID, A.TYPE, A.UPDATEDATE, A.DOCUMENTNUMBER, A.FIRSTNAME, A.MIDDLENAME, A.LASTNAME, A.SECONDLASTNAME, A.BirthDate,
       A.PARTICIPATIONRATE, A.RELATIONSHIP, LKRE.DESCRIPTION RELATIONSHIPDESC,
       row_number() over (partition by A.POLICYID order by A.UPDATEDATE desc) as row_num
  FROM RiskRoles A LEFT JOIN LOOKUP LKRE ON LKRE.LOOKUPID = 2108 AND LKRE.LANGUAGE=1 AND LKRE.CODE = A.RELATIONSHIP WHERE A.TYPE=100)
SELECT NULL CONTRATO, DECODE(B.ISHEALTH, ''A'', ''Clase 1'', ''B'', ''Clase 2'', ''C'', ''Clase 3'') PLAN, R.ID CODIGO_EMPLEADO, REPLACE(RL.DOCUMENTNUMBER,''-'','''') CEDULA,
       RL.FIRSTNAME PRI_NOM, RL.MIDDLENAME SEG_NOM, RL.LASTNAME PRI_APE, RL.SECONDLASTNAME SEG_APE,
       DECODE(RL.TYPE, 2, ''T'', ''D'') TIP_AFI,  DECODE(RL.RELATIONSHIP,0,''Titular'',l.DESCRIPTION) PARENTESCO, DECODE(RL.GENDER,1,''M'',''F'') SEXO,
       RL.BIRTHDATE FEC_NAC, DECODE(RL.RELATIONSHIP,0,B.MONTHLYSALARY,NULL) SALARIO, DECODE(B.ISLIFE, ''A'', ''Clase 1'', ''B'', ''Clase 2'', ''C'', ''Clase 3'') CLASE,
       TRIM(T.FIRSTNAME) || '' ''  ||  TRIM(T.MIDDLENAME) || '' ''  || TRIM(T.LASTNAME) || '' ''  || TRIM(T.SECONDLASTNAME) BENEFICIARIO, B.RefundBankAccount "NUMERO CUENTA", DECODE(B.RefundBankAccountCurrency,1,''Colones'',2,''D?lares'') MONEDA, DECODE(B.RefundBankAccountType,1,''AH'',2,''CO'') "TIPO CUENTA",
       DECODE(B.RefundBankCode, 1,''Banco BAC San Jos? S.A.'', 2,''Banco BCT S.A.'', 3,''Banco Cathay de Costa Rica S.A.'', 4,''Banco Davivienda S.A.'', 5,''Banco de Costa Rica'', 6,''Banco General S.A.'', 7,''Banco Improsa S.A.'', 8,''Banco Lafise S.A.'', 9,''Banco Nacional de Costa Rica'', 12,''Banco Popular'', 10,''Banco Prom?rica de Costa Rica S.A.'', 13,''MUCAP (Mutual Cartago Ahorro y Prestamo)'', 11,''Scotiabank de Costa Rica S.A'') BANCO,
         BN1.PARTICIPATIONRATE "PORCIENTO BENEFICIARIO", BN1.FIRSTNAME "PRIMER NOMBRE", BN1.MIDDLENAME "SEGUNDO NOMBRE", BN1.LASTNAME "PRIMER APELLIDO", BN1.SECONDLASTNAME "SEGUNDO APELLIDO", BN1.RELATIONSHIPDESC PARENTESCO, BN1.BirthDate "FECHA NACIIMENTO", NULL"RNC CEDULA"')||TO_CLOB(',
         BN2.PARTICIPATIONRATE "PORCIENTO BENEFICIARIO", BN2.FIRSTNAME "PRIMER NOMBRE", BN2.MIDDLENAME "SEGUNDO NOMBRE", BN2.LASTNAME "PRIMER APELLIDO", BN2.SECONDLASTNAME "SEGUNDO APELLIDO", BN2.RELATIONSHIPDESC PARENTESCO, BN2.BirthDate "FECHA NACIIMENTO", NULL"RNC CEDULA",
         BN3.PARTICIPATIONRATE "PORCIENTO BENEFICIARIO", BN3.FIRSTNAME "PRIMER NOMBRE", BN3.MIDDLENAME "SEGUNDO NOMBRE", BN3.LASTNAME "PRIMER APELLIDO", BN3.SECONDLASTNAME "SEGUNDO APELLIDO", BN3.RELATIONSHIPDESC PARENTESCO, BN3.BirthDate "FECHA NACIIMENTO", NULL"RNC CEDULA"
  FROM RISKROLES RL
  LEFT JOIN RISK R ON R.ID=RL.POLICYID AND R.COMPANYID=RL.COMPANYID
  LEFT JOIN RISKBAYER B ON B.ID=RL.POLICYID AND B.COMPANYID=RL.COMPANYID
  LEFT JOIN LOOKUP l ON l.LOOKUPID =2108 AND l.CODE=RL.RELATIONSHIP
  LEFT JOIN RISKROLES T ON T.POLICYID=RL.POLICYID AND T.COMPANYID=RL.COMPANYID AND T.TYPE=2
  LEFT JOIN (SELECT * FROM (CTE) b1  where b1.row_num = 1) BN1 on BN1.POLICYID = R.ID
  LEFT JOIN (SELECT * FROM (CTE) b1  where b1.row_num = 2) BN2 on BN2.POLICYID = R.ID
  LEFT JOIN (SELECT * FROM (CTE) b1  where b1.row_num = 3) BN3 on BN3.POLICYID = R.ID
 WHERE RL.COMPANYID=4 AND RL.TYPE IN (2,90) AND R.ISSUEDATE >= {desde:date} AND R.ISSUEDATE <= {hasta:date}
ORDER BY R.ID'));
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (140014,1,1,'Poliza registradas','Listado de todas las polizas registra en el sistema',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'1970-02-07 00:00:00',NULL,'Research',1,NULL,NULL,'demo',NULL,TO_CLOB('WITH CTE AS (SELECT B1.*, row_number() over (partition by POLICYID order by UPDATEDATE desc) as row_num FROM VRiskRoles B1 WHERE B1.TYPE=100)
SELECT P.ISSUEDATE "Inclusion", P.LINEOFBUSINESSCODEDESC "Ramo", P.PRODUCTCODEDESC "Producto", P.POLICY "Poliza",
        A.DOCUMENTNUMBER "Identificacion", A.FULLNAME "Asegurado", A.BIRTHDATE "Fecha de nacimiento", A.GenderDesc "Gonero", A.PHONENUMBER "Telofono", A.PRIMARYEMAILADDRESS "Correo", A.ProvinceDesc "Provincia", A.CantonDesc "Canton", A.DistrictDesc "Distrito", A.AddressDetail "Direccion",
        P.MODULECODEDESC "Plan",
        P.EFFECTIVEDATE "Inicio de vigencia", P.ENDINGDATE "Fin de vigencia", P.STATUSDESC "Estado", P.CURRENCYDESC "Moneda",
        P.CANCELLATIONDATE "Fecha de baja", P.REASONFORSTATUSDESC "Causa de la baja", P.INSUREDAMOUNT "Suma asegurada", P.SURCHARGE "Recargo", P.ANNUALPREMIUM "Prima anual", P.BRANCHOFFICEDESC "Sucursal",
        P.ExecutiveUser "Ejecutivo", P.COMMENTS "Observaciones", P.AttachmentCount "Cantidad de adjuntos",
        BN1.DOCUMENTNUMBER "BE 1 - Identificacion", BN1.FULLNAME "BN 1 - Nombre Completo", BN1.GenderDesc "BN 1 - Genero", BN1.RELATIONSHIP "BN 1 - Relacion", BN1.PARTICIPATIONRATE "BN 1 - Participacion", BN1.PHONENUMBER "BN 1 - Telefono", BN1.PRIMARYEMAILADDRESS "BN 1 - Correo", BN1.ProvinceDesc "BN 1 - Provincia", BN1.CantonDesc "BN 1 - Canton", BN1.DistrictDesc "BN 1 - Distrito", BN1.AddressDetail "BN 1 - Direccion",
        BN2.DOCUMENTNUMBER "BN 2 - Identificacion", BN2.FULLNAME "BN 2 - Nombre Completo", BN2.GenderDesc "BN 2 - G?nero", BN2.RELATIONSHIP "BN 2 - Relacion", BN2.PARTICIPATIONRATE "BN 2 - Participaci?n", BN2.PHONENUMBER "BN 2 - Telefono", BN2.PRIMARYEMAILADDRESS "BN 2 - Correo", BN2.ProvinceDesc "BN 2 - Provincia", BN2.CantonDesc "BN 2 - Cant?n", BN2.DistrictDesc "BN 2 - Distrito", BN2.AddressDetail "BN 2 - Direccion",
        BN3.DOCUMENTNUMBER "BN 3 - Identificacion", BN3.FULLNAME "BN 3 - Nombre Completo", BN3.GenderDesc "BN 3 - Genero", BN3.RELATION')||TO_CLOB('SHIP "BN 3 - Relacion", BN3.PARTICIPATIONRATE "BN 3 - Participacion", BN3.PHONENUMBER "BN 3 - Telefono", BN3.PRIMARYEMAILADDRESS "BN 3 - Correo", BN3.ProvinceDesc "BN 3 - Provincia", BN3.CantonDesc "BN 3 - Canton", BN3.DistrictDesc "BN 3 - Distrito", BN3.AddressDetail "BN 3 - Direccion"
  FROM VRisk P
  LEFT JOIN VRiskRoles A ON A.POLICYID = P.ID AND A.TYPE=2
  LEFT JOIN (SELECT * FROM (CTE) b1  where b1.row_num = 1) BN1 on BN1.POLICYID = P.ID
  LEFT JOIN (SELECT * FROM (CTE) b2  where b2.row_num = 2) BN2 on BN2.POLICYID = P.ID
  LEFT JOIN (SELECT * FROM (CTE) b3  where b3.row_num = 3) BN3 on BN3.POLICYID = P.ID
 WHERE P.CompanyId={app.companyid}
 ORDER BY P.ISSUEDATE DESC'));
