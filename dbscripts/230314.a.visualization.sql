SET DEFINE OFF;
MERGE INTO VISUALIZATIONS A USING
 (SELECT
  4003 as ID,
  1 as SEQUENCE,
  NULL as KEY,
  1 as COMPANYID,
  NULL as ENTITYTYPE,
  1 as TYPE,
  'Todos los casos' as CAPTION,
  NULL as DESCRIPTION,
  1 as STATEMENTTYPE,
  'SELECT PC.ID, PC.CONTACTMAINNAME, PC.TITLE, PC.DESCRIPTION, PC.STATUS, LKS.DESCRIPTION STATUSDESC, PC.LABEL, PC.SUBLABEL,
       PC.FLOWID, PF.NAME FLOWNAME, PC.INSTANCEID, PIF.CREATED, PIF .STARTDATE, PIF.FINISHDATE, PIF.DUEDATE,
       (select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID AND SSC.ID<=PC.CURRENTSTEPID) STEPCURRENT,
       (select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID) STEPTOTAL,
      CAST (((select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID AND SSC.ID<=PC.CURRENTSTEPID)*100)/(select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID) AS DECIMAL(5,0)) PROGRESS,
       PIS.STEPID, PIST.NAME STEPNAME, PIS.STARTDATE  STEPSTARTDATE, PIS.FINISHDATE STEPFINISHDATE, PIS.DUEDATE  STEPDUEDATE,
       (SELECT LISTAGG(RM.ROLENAME , '', '') WITHIN GROUP (ORDER BY RM.ROLENAME ) FROM PROCESSSPECSTEPROLE prm LEFT JOIN ROLEMEMBER rm ON rm.RoleId = prm.RoleId WHERE prm.COMPANYID=PC.CompanyId AND prm.ID=PIS.STEPID) Roles
  FROM PROCESSCASE PC
  LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 61 AND LKS.COMPANYID=0 AND LKS.LANGUAGE=1 AND LKS.CODE =PC.STATUS
  LEFT JOIN PROCESSSPECFLOW PF ON PF.COMPANYID=PC.COMPANYID AND PF.ID=PC.FLOWID
  LEFT JOIN PROCESSINSTANCE PIF ON PIF.COMPANYID=PC.COMPANYID AND PIF.INSTANCEID=PC.INSTANCEID AND PIF.STEPID=0
  LEFT JOIN PROCESSINSTANCE PIS ON PIS.COMPANYID=PC.COMPANYID AND PIS.INSTANCEID=PC.INSTANCEID AND PIS.STEPID>0 AND PIS.TASKID=0 AND NOT PIS.STARTDATE IS NULL AND PIS.FINISHDATE IS NULL
  LEFT JOIN PROCESSSPECSTEP PIST ON PIST.COMPANYID=PIS.COMPANYID AND PIST.FLOWID=PIS.FLOWID AND PIST.ID=PIS.STEPID
 WHERE PC.CompanyId={app.companyid} AND PC.FLOWID>0 AND PC.INSTANCEID>0 AND (select count(*) from PROCESSSPECSTEP SSC WHERE SSC.FLOWID=PC.FLOWID) > 0' as STATEMENT,
  '{
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
}' as SPECIFICATION,
  NULL as DIALOG,
  NULL as ICON,
  NULL as ICONCLASS,
  NULL as VALUEFORMAT,
  'Research' as CONNECTIONNAME,
  NULL as JAVASCRIPTTOINCLUDE,
  1 as RECORDSTATUS,
  888 as UPDATEUSERCODE,
  TO_DATE('03/31/2023 00:00:00', 'MM/DD/YYYY HH24:MI:SS') as UPDATEDATE
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
