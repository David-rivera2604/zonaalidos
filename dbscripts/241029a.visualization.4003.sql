UPDATE VISUALIZATIONS SET "STATEMENT"='SELECT PC.ID, PC.CONTACTMAINNAME, PC.TITLE, PC.DESCRIPTION, LKCP.DESCRIPTION PRIORITYDESC, PC.STATUS, LKS.DESCRIPTION STATUSDESC, PC.LABEL, PC.SUBLABEL,
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
 WHERE PC.CompanyId={app.companyid} AND PC.FLOWID>0 AND PC.INSTANCEID>0 AND (select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID) > 0', SPECIFICATION='{
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
}' WHERE ID=4003 AND "SEQUENCE"=1;