INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (422,1,1,'Casos creados por Purdy','Filtro',NULL,NULL,NULL,NULL,1,1,1,TIMESTAMP'2023-04-03 08:00:20',TO_CLOB('{
"title": "Casos creados por Purdy",
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
                "field": "NUMERO_CASO",
                "title": "Número de caso",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.IntegerFormatter"
            },
            {
                "field": "FECHA_INGRESO",
                "title": "Fecha de ingreso",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter"
            },
            {
                "field": "ASUNTO",
                "title": "Asunto",
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
                "field": "PRIORIDAD",
                "title": "Prioridad",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "USUARIO_CREACION",
                "title": "Creado por",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            }
        ]
    }
 }'),'research',1,'|titulo
|zona|4
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 422, @_@_)',NULL,NULL,NULL,TO_CLOB('SELECT
PC.ID AS NUMERO_CASO,
PI.CREATED AS FECHA_INGRESO,
PC.TITLE AS ASUNTO,
LKS.DESCRIPTION AS ESTADO,
LKP.DESCRIPTION AS PRIORIDAD,
UM.FIRSTNAME || '' '' || UM.LASTNAME AS USUARIO_CREACION
FROM ALIADOS.PROCESSCASE PC
/* Relación con la instancia para obtener la fecha de creación original del proceso */
JOIN ALIADOS.PROCESSINSTANCE PI ON PC.ID = PI.CASEID AND PI.STEPID = 0 AND PI.TASKID = 0
/* Relación con la tabla de usuarios para identificar al creador */
JOIN ALIADOS.USERMEMBER UM ON PC.USERSEND = UM.USERID 
/* Join para obtener la descripción de la compañía del usuario creador */
JOIN LOOKUP LKC_USER ON LKC_USER.LOOKUPID = 4 AND LKC_USER.LANGUAGE = 1 AND LKC_USER.CODE = UM.COMPANYID AND LKC_USER.DESCRIPTION = ''Purdy''
/* Join para obtener la descripción del estado del caso */
JOIN LOOKUP LKS ON LKS.LOOKUPID = 61 AND LKS.LANGUAGE = 1 AND LKS.CODE = PC.STATUS
/* Join para obtener la descripción de la prioridad */
JOIN LOOKUP LKP ON LKP.LOOKUPID = 62 AND LKP.LANGUAGE = 1 AND LKP.CODE = PC.PRIORITY
WHERE trunc(PI.CREATED) BETWEEN {desde:date}  AND {hasta:date}
/* Ordenado por la fecha de creación de la instancia */
ORDER BY PI.CREATED DESC'));
