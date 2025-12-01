DELETE FROM VISUALIZATIONS WHERE ID=120 AND SEQUENCE=1;

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
},
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
	"field": "Realizado por",
	"title": "Realizado por",
	"sortable": true,
	"halign": "center",
	"align": "left",
	"formatter": "app.ui.StringFormatter"
},
{
	"field": "CompletadoLegal",
	"title": "Completado Legal",
	"sortable": true,
	"halign": "center",
	"align": "center",
	"formatter": "app.ui.DateAndTimeFormatter"
},			
{
	"field": "Tomador",
	"title": "Tomador",
	"sortable": true,
	"halign": "center",
	"align": "left",
	"formatter": "app.ui.StringF')||TO_CLOB('ormatter"
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
	"sortable": true,
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
SELECT PI.INSTANCEID, PF.NAME, PI.STARTDATE, PI.FINISHDATE, PI.USERID
  FROM aliados.PROCESSINSTANCE PI
  JOIN aliados.PROCESSSPECFLOW PF ON PF.COMPANYID = PI.COMPANYID AND PF.ID = PI.FLOWID AND PF.name IN ( ''DEVOLUCIÓN DE DINERO'', ''DEVOLUCIÓN DE DINERO - SAC'', ''DEVOLUCIÓN DE DINERO - COBROS'' )
 WHERE PI.COMPANYID =100 
   AND PI.STEPID = (SELECT PS.ID FROM aliados.PROCESSSPECSTEP PS WHERE PS.flowid = PI.FLOWID AND PS.NAME = ''SE TRAMITA DEVOLUCIÓN EN BANCOS'')
   AND PI.TASKID = 0
   AND TRUNC(PI.FINISHDATE) >= TRUNC({finalizandosdesde:date})
), FOCUS2 AS (
SELECT PI.INSTANCEID, PF.NAME, PI.STARTDATE, PI.FINISHDATE, PI.USERID
  FROM aliados.PROCESSINSTANCE PI
  JOIN aliados.PROCESSSPECFLOW PF ON PF.COMPANYID = PI.COMPANYID AND PF.ID = PI.FLOWID AND PF.name IN ( ''DEVOLUCIÓN DE DINERO'', ''DEVOLUCIÓN DE DINERO - SAC'', ''DEVOLUCIÓN DE DINERO - COBROS'' )
 WHERE PI.COMPANYID =100 
   AND PI.STEPID = (SELECT PS.ID FROM aliados.PROCESSSPECSTEP PS WHERE PS.flowid = PI.FLOWID AND PS.NAME = ''APROBACIÓN DE CUMPLIMIENTO LEGAL'')
   AND PI.TASKID = 0
   AND NOT PI.FINISHDATE IS NULL
)
SELECT PC.ID "Caso #", PINIT.STARTDATE "Inicio", F.STARTDATE "Inicio de la etapa de devolución", F.FINISHDATE "Completado de la etapa de devolución", PINIT.FINISHDATE "Completado",
      PC.TITLE "Asunto", F.NAME "Proceso", PC.DESCRIPTION "Descripción", LKS.DESCRIPTION "Estado", LKCP.DESCRIPTION "Prioridad", um.FirstName || '' '' || um.LastName "Realizado por",
      F2.FINISHDATE "CompletadoLegal",      
      PC.REFERENCE1 "Tomador", PC.REFERENCE2 "Póliza", PC.REFERENCE3 "Correduria", PC.REFERENCE4 "Categoría", PC.REFERENCE5 "Tipo de variación", PC.REFERENCE6 "Monto", PC.REFERENCE7 "Moneda y cuenta", PC.REFERENCE8 "Indentificación", PC.REFERENCE9 "Cuenta bancaria", PC.REFERENCE10 "Banco"
  FROM aliados.PROCESSCASE PC
  JOIN FOCUS F ON F.INSTANCEID = PC.INSTANCEID
  JOIN FOCUS2 F2 ON F2.INSTANCEID = PC.INSTANCEID  
  JOIN aliados.PROCESSINSTANCE PINIT ON PINIT.COMP')||TO_CLOB('ANYID=PC.COMPANYID AND PINIT.INSTANCEID =F.INSTANCEID  AND PINIT.STEPID=0 AND  PINIT.TASKID=0
  LEFT JOIN aliados.LOOKUP LKS ON LKS.LOOKUPID = 61 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE =PC.STATUS
  LEFT JOIN aliados.LOOKUP LKCP ON LKCP.LOOKUPID = 62 AND LKCP.COMPANYID=0 AND LKCP.LANGUAGE=1 AND LKCP.CODE =PC.PRIORITY
  LEFT JOIN UserMember um ON um.UserId = F.USERID  
  WHERE PC.COMPANYID=100
  ORDER BY PC.ID'));
