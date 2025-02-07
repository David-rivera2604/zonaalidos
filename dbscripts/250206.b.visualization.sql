UPDATE VISUALIZATIONS SET "TYPE"=1, CAPTION='Detalle por caso', DESCRIPTION='Detalle por caso', "STATEMENT"='SELECT CS.ID, LKSCS.DESCRIPTION STATUSDESC, TRUNC(PI.CREATED) CREATEDATE,TO_CHAR(PI.CREATED, ''HH:MI AM'') CREATETIME, CS.CONTACTMAINNAME,
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
  LEFT JOIN USERMEMBER U ON U.COMPANYID=PI.COMPANYID AND U.USERID=PI.UPDATEUSERCODE
  LEFT JOIN PROCESSINSTANCE PI2 ON PI2.COMPANYID=CS.COMPANYID AND PI2.INSTANCEID=CS.INSTANCEID AND PI2.STEPID=0 AND PI2.TASKID=0
 WHERE CS.COMPANYID={app.companyid} AND ({FlowId} =0 OR CS.FLOWID = {FlowId}) AND ({Status} =0 OR CS.STATUS = {Status}) AND TRUNC(PI.CREATED)>={desde:date} AND TRUNC(PI.CREATED)<={hasta:date}
 ORDER BY CS.ID, PI.ActivityId', ICON=NULL, ICONCLASS=NULL, VALUEFORMAT=NULL, ENTITYTYPE=NULL, RECORDSTATUS=1, COMPANYID=1, UPDATEUSERCODE=1, UPDATEDATE=TIMESTAMP '2025-06-02 17:19:00.000000', SPECIFICATION='{
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
    "sortable": true,
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
}', CONNECTIONNAME='Research', STATEMENTTYPE=1, DIALOG='|titulo
|zona|4
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Proceso|lista|name=FlowId;lookup=Process.
 Estado|lista|name=Status;lookup=ProcessStatus.
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 4001, @_@_)', STATEMENTEXTEND=NULL, "KEY"='CaseDetail', JAVASCRIPTTOINCLUDE='Extend.CaseDetail.js' WHERE ID=4001 AND "SEQUENCE"=1;
UPDATE VISUALIZATIONS SET "TYPE"=1, CAPTION='Detalle por caso (excel)', DESCRIPTION='Detalle por caso', "STATEMENT"='SELECT CS.ID "No. Caso", LKSCS.DESCRIPTION "Estatus del caso", TRUNC(PI.CREATED) "Fecha de solicitud (Creada)",TO_CHAR(PI.CREATED, ''HH:MI AM'') "Hora", CS.CONTACTMAINNAME "Contacto", CS.REFERENCE4 "Categoria por correduria", CS.REFERENCE3 "Corredur?a", CS.REFERENCE1 "Tomador", CS.REFERENCE2 "Numero de poliza",
       CS.TITLE "Asunto", PF.NAME "Nombre del caso", CS.DESCRIPTION "Descripci?n", LKCP.DESCRIPTION "Prioridad",
       TRUNC(PI.STARTDATE) "Fecha etapa actual", TO_CHAR(PI.STARTDATE, ''HH:MI AM'') "Hora etapa actual",
       (SELECT LISTAGG(RM.ROLENAME , '', '') WITHIN GROUP (ORDER BY RM.ROLENAME ) FROM PROCESSSPECSTEPROLE prm LEFT JOIN ROLEMEMBER rm ON rm.RoleId = prm.RoleId WHERE prm.COMPANYID=PI.COMPANYID AND prm.ID=PI.STEPID) "Rol",
       U.FIRSTNAME || '' '' || U.LASTNAME "Realizado por",
       PS.NAME "Etapa actual",
       CAST (((select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=CS.FLOWID AND SSC.STEPORDER<=PS.STEPORDER)*100)/(select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=CS.FLOWID) AS DECIMAL(5,0)) "% Progreso",
       (SELECT LISTAGG(TO_CHAR(NT.UPDATEDATE , ''DD/MM/YYYY HH24:MI'') || '' '' || NU.FIRSTNAME || '' '' || NU.LASTNAME || '': '' || NT.NOTE, chr(13) || chr(10)) WITHIN GROUP (ORDER BY NT.ID ) FROM NOTES NT LEFT JOIN USERMEMBER NU ON NU.COMPANYID=NT.COMPANYID AND NU.USERID=NT.UPDATEUSERCODE WHERE NT.COMPANYID= CS.COMPANYID AND NT.ENTITYTYPE=1304 AND NT.ENTITYID=CS.ID) "Notas",
       TRUNC(PI.FINISHDATE) "Fecha de finalizacion",TO_CHAR(PI.FINISHDATE, ''HH:MI AM'') "Hora de finalizacion", calcular_dias(PI.STARTDATE, PI.FINISHDATE, ''S'')  "Cantidad de Dias", calcular_dias(PI2.STARTDATE, PI2.FINISHDATE, ''S'') "Total de Dias"
  FROM PROCESSCASE CS
  LEFT JOIN PROCESSINSTANCE PI ON PI.COMPANYID=CS.COMPANYID AND PI.INSTANCEID=CS.INSTANCEID AND PI.STEPID>0 AND PI.TASKID=0 AND not PI.STARTDATE IS NULL
  LEFT JOIN PROCESSSPECFLOW PF ON PF.COMPANYID=PI.COMPANYID AND PF.ID=PI.FLOWID
  LEFT JOIN PROCESSSPECSTEP PS ON PS.COMPANYID=PI.COMPANYID AND PS.FLOWID=PI.FLOWID AND PS.ID=PI.STEPID
  LEFT JOIN LOOKUP LKCP ON LKCP.LOOKUPID = 62 AND LKCP.COMPANYID=0 AND LKCP.LANGUAGE=1 AND LKCP.CODE =CS.PRIORITY
  LEFT JOIN LOOKUP LKSCS ON LKSCS.LOOKUPID = 61 AND LKSCS.COMPANYID=0 AND LKSCS.LANGUAGE=1 AND LKSCS.CODE =CS.STATUS
  LEFT JOIN USERMEMBER U ON U.COMPANYID=PI.COMPANYID AND U.USERID=PI.UPDATEUSERCODE
  LEFT JOIN PROCESSINSTANCE PI2 ON PI2.COMPANYID=CS.COMPANYID AND PI2.INSTANCEID=CS.INSTANCEID AND PI2.STEPID=0 AND PI2.TASKID=0
 WHERE CS.COMPANYID={app.companyid} AND ({FlowId} =0 OR CS.FLOWID = {FlowId}) AND ({Status} =0 OR CS.STATUS = {Status}) AND TRUNC(PI.CREATED)>={desde:date} AND TRUNC(PI.CREATED)<={hasta:date}
 ORDER BY CS.ID, PI.ActivityId', ICON=NULL, ICONCLASS=NULL, VALUEFORMAT=NULL, ENTITYTYPE=NULL, RECORDSTATUS=1, COMPANYID=1, UPDATEUSERCODE=1, UPDATEDATE=TIMESTAMP '2025-06-02 17:19:00.000000', SPECIFICATION=NULL, CONNECTIONNAME='Research', STATEMENTTYPE=1, DIALOG=NULL, STATEMENTEXTEND=NULL, "KEY"=NULL, JAVASCRIPTTOINCLUDE=NULL WHERE ID=4002 AND "SEQUENCE"=1;