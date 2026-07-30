-- =============================================================
-- Visualizaciones: Gestion de Asignacion de Casos
-- IDs: 200002 (lista), 200003 (formulario)
-- Generado: 2026-05-05
-- =============================================================

-- -------------------------------------------------------
-- Visualization ID: 200002 | Gestion de Asignacion de Casos
-- -------------------------------------------------------
MERGE INTO VISUALIZATIONS V
USING (SELECT 200002 AS ID FROM DUAL) SRC
ON (V.ID = SRC.ID)
WHEN MATCHED THEN UPDATE SET
    V.SEQUENCE = 1,
    V.KEY = NULL,
    V.COMPANYID = 1,
    V.ENTITYTYPE = NULL,
    V.TYPE = 1,
    V.CAPTION = 'Gestion de Asignacion de Casos',
    V.DESCRIPTION = 'Casos activos por rol del supervisor. Permite asignar y reasignar colaboradores por etapa.',
    V.STATEMENTTYPE = 1,
    V.SPECIFICATION = '{
  "title": "Gestion de Asignacion de Casos",
  "entity": "Case",
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
        "field": "ROLES",
        "title": "Roles",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "TIEMPOETAPA",
        "title": "Tiempo asignado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "visible": true,
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "USUARIOETAPA",
        "title": "Asignado actualmente",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "title": "Acciones",
        "sortable": false,
        "halign": "center",
        "align": "center",
        "visible": true,
        "format": "<button type=''button'' name=''assign'' class=''btn btn-sm btn-primary event'' title=''Asignar o reasignar colaborador''><i class=''fa fa-user-plus''></i> Reasignar</button>",
        "titleTooltip": "Acciones disponibles",
        "width": 10,
        "widthUnit": "%",
        "events": true,
        "action_assign": "app.Ext_CaseAssignment.Assign(row)"
      }
    ],
    "extendName": "Ext_CaseAssignment"
  }
}',
    V.DIALOG = NULL,
    V.ICON = NULL,
    V.ICONCLASS = NULL,
    V.VALUEFORMAT = NULL,
    V.CONNECTIONNAME = 'Research',
    V.JAVASCRIPTTOINCLUDE = 'Cases/Ext.CaseAssignment.js',
    V.RECORDSTATUS = 1,
    V.UPDATEUSERCODE = 6329,
    V.UPDATEDATE = SYSDATE,
    V.STATEMENT = TO_CLOB('SELECT
    PC.ID,
    PIS.STEPID,
    PC.CONTACTMAINNAME,
    PC.TITLE,
    PC.DESCRIPTION,
    LKCP.DESCRIPTION                                                            PRIORITYDESC,
    PC.STATUS,
    LKS.DESCRIPTION                                                             STATUSDESC,
    PC.FLOWID,
    PF.NAME                                                                     FLOWNAME,
    PC.INSTANCEID,
    PIF.CREATED,
    PIF.STARTDATE,
    PIF.DUEDATE,
    CASE
        WHEN PIS.STARTDATE IS NULL THEN ''Sin iniciar''
        WHEN (SYSDATE - PIS.STARTDATE) < 1/24
            THEN FLOOR((SYSDATE - PIS.STARTDATE) * 1440) || '' min''
        WHEN (SYSDATE - PIS.STARTDATE) < 1
            THEN FLOOR((SYSDATE - PIS.STARTDATE) * 24) || '' h '' ||
                 FLOOR(((SYSDATE - PIS.STARTDATE) * 24 - FLOOR((SYSDATE - PIS.STARTDATE) * 24)) * 60) || '' min''
        ELSE FLOOR(SYSDATE - PIS.STARTDATE) || '' dias '' ||
             FLOOR(((SYSDATE - PIS.STARTDATE) - FLOOR(SYSDATE - PIS.STARTDATE)) * 24) || '' h''
    END                                                                         TIEMPOETAPA,
    (SELECT COUNT(*) FROM PROCESSSPECSTEP SSC
     WHERE SSC.FLOWID = PC.FLOWID AND SSC.ID <= PC.CURRENTSTEPID)              STEPCURRENT,
    (SELECT COUNT(*) FROM PROCESSSPECSTEP SSC
     WHERE SSC.FLOWID = PC.FLOWID)                                              STEPTOTAL,
    CAST(
        ((SELECT COUNT(*) FROM PROCESSSPECSTEP SSC
          WHERE SSC.FLOWID = PC.FLOWID AND SSC.ID <= PC.CURRENTSTEPID) * 100)
        / NULLIF((SELECT COUNT(*) FROM PROCESSSPECSTEP SSC
                  WHERE SSC.FLOWID = PC.FLOWID), 0)
    AS DECIMAL(5,0))                                                            PROGRESS,
    PIST.NAME                                                                   STEPNAME,
    PIS.STARTDATE                                                               STEPSTARTDATE,
    PIS.DUEDATE                                                                 STEPDUEDATE,
    UM_STEP.FIRSTNAME || '' '' || UM_STEP.LASTNAME                               USUARIOETAPA,
    (SELECT LISTAGG(NOMBRE || '' ('' || CARGA || '' casos)'', '' | '')
            WITHIN GROUP (ORDER BY CARGA ASC, NOMBRE ASC)
     FROM (
         SELECT DISTINCT
                UM2.FIRSTNAME || '' '' || UM2.LASTNAME AS NOMBRE,
                (SELECT COUNT(*) FROM PROCESSCASE PC2
                 WHERE PC2.COMPANYID = PC.COMPANYID
                   AND PC2.USERASSIGNED = UM2.USERID
                   AND PC2.STATUS NOT IN (3,4)) AS CARGA
         FROM PROCESSSPECSTEPROLE PSR3
         JOIN ROLEMEMBER RM3') || TO_CLOB('
              ON RM3.ROLEID = PSR3.ROLEID
             AND RM3.COMPANYID = PC.COMPANYID
             AND LOWER(RM3.ROLENAME) IN ({app.UserRoleNameList})
         JOIN USERROLEMEMBER URM2
              ON URM2.ROLEID = RM3.ROLEID
             AND URM2.COMPANYID = PC.COMPANYID
         JOIN USERMEMBER UM2
              ON UM2.USERID = URM2.USERID
             AND UM2.RECORDSTATUS = 1
         WHERE PSR3.COMPANYID = PC.COMPANYID
           AND PSR3.ID = PIS.STEPID
     ))                                                                         COLABORADORES,
    (SELECT LISTAGG(RM2.ROLENAME, '', '') WITHIN GROUP (ORDER BY RM2.ROLENAME)
     FROM PROCESSSPECSTEPROLE PSR2
     JOIN ROLEMEMBER RM2
          ON RM2.ROLEID = PSR2.ROLEID
         AND RM2.COMPANYID = PC.COMPANYID
         AND LOWER(RM2.ROLENAME) IN ({app.UserRoleNameList})
     WHERE PSR2.COMPANYID = PC.COMPANYID
       AND PSR2.ID = PIS.STEPID)                                                ROLES,
    PC.REFERENCE3                                                               CORREDURIA
FROM PROCESSCASE PC
LEFT JOIN LOOKUP LKS
    ON LKS.LOOKUPID = 61 AND LKS.COMPANYID = 0 AND LKS.LANGUAGE = 1 AND LKS.CODE = PC.STATUS
LEFT JOIN LOOKUP LKCP
    ON LKCP.LOOKUPID = 62 AND LKCP.COMPANYID = 0 AND LKCP.LANGUAGE = 1 AND LKCP.CODE = PC.PRIORITY
LEFT JOIN PROCESSSPECFLOW PF
    ON PF.COMPANYID = PC.COMPANYID AND PF.ID = PC.FLOWID
LEFT JOIN PROCESSINSTANCE PIF
    ON PIF.COMPANYID = PC.COMPANYID AND PIF.INSTANCEID = PC.INSTANCEID AND PIF.STEPID = 0
LEFT JOIN PROCESSINSTANCE PIS
    ON PIS.COMPANYID = PC.COMPANYID AND PIS.INSTANCEID = PC.INSTANCEID
    AND PIS.STEPID > 0 AND PIS.TASKID = 0
    AND PIS.STARTDATE IS NOT NULL AND PIS.FINISHDATE IS NULL
LEFT JOIN PROCESSSPECSTEP PIST
    ON PIST.COMPANYID = PIS.COMPANYID AND PIST.FLOWID = PIS.FLOWID AND PIST.ID = PIS.STEPID
LEFT JOIN USERMEMBER UM_STEP
    ON UM_STEP.USERID = PIS.USERASSIGNED AND UM_STEP.COMPANYID = PC.COMPANYID
JOIN PROCESSSPECSTEPROLE PSR
    ON PSR.COMPANYID = PC.COMPANYID AND PSR.ID = PIST.ID
JOIN ROLEMEMBER RM
    ON RM.ROLEID = PSR.ROLEID
   AND RM.COMPANYID = PC.COMPANYID
   AND LOWER(RM.ROLENAME) IN ({app.UserRoleNameList})
WHERE PC.COMPANYID = {app.companyid}
  AND PC.FLOWID > 0
  AND PC.INSTANCEID > 0
  AND PC.STATUS NOT IN (3, 4)
  AND (SELECT COUNT(*) FROM PROCESSSPECSTEP SSC WHERE SSC.FLOWID = PC.FLOWID) > 0
ORDER BY PIF.STARTDATE DESC')
WHEN NOT MATCHED THEN INSERT (
    ID, SEQUENCE, KEY, COMPANYID, ENTITYTYPE, TYPE, CAPTION, DESCRIPTION, STATEMENTTYPE, SPECIFICATION, DIALOG, ICON, ICONCLASS, VALUEFORMAT, CONNECTIONNAME, JAVASCRIPTTOINCLUDE, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE, STATEMENT
) VALUES (
    200002, 1, NULL, 1, NULL, 1, 'Gestion de Asignacion de Casos', 'Casos activos por rol del supervisor. Permite asignar y reasignar colaboradores por etapa.', 1, '{
  "title": "Gestion de Asignacion de Casos",
  "entity": "Case",
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
        "field": "ROLES",
        "title": "Roles",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "field": "TIEMPOETAPA",
        "title": "Tiempo asignado",
        "sortable": true,
        "halign": "center",
        "align": "center",
        "visible": true,
        "formatter": "app.ui.StringFormatter"
      },
      {
        "field": "USUARIOETAPA",
        "title": "Asignado actualmente",
        "sortable": true,
        "halign": "center",
        "align": "left",
        "formatter": "app.ui.StringFormatter",
        "visible": true
      },
      {
        "title": "Acciones",
        "sortable": false,
        "halign": "center",
        "align": "center",
        "visible": true,
        "format": "<button type=''button'' name=''assign'' class=''btn btn-sm btn-primary event'' title=''Asignar o reasignar colaborador''><i class=''fa fa-user-plus''></i> Reasignar</button>",
        "titleTooltip": "Acciones disponibles",
        "width": 10,
        "widthUnit": "%",
        "events": true,
        "action_assign": "app.Ext_CaseAssignment.Assign(row)"
      }
    ],
    "extendName": "Ext_CaseAssignment"
  }
}', NULL, NULL, NULL, NULL, 'Research', 'Cases/Ext.CaseAssignment.js', 1, 6329, SYSDATE, TO_CLOB('SELECT
    PC.ID,
    PIS.STEPID,
    PC.CONTACTMAINNAME,
    PC.TITLE,
    PC.DESCRIPTION,
    LKCP.DESCRIPTION                                                            PRIORITYDESC,
    PC.STATUS,
    LKS.DESCRIPTION                                                             STATUSDESC,
    PC.FLOWID,
    PF.NAME                                                                     FLOWNAME,
    PC.INSTANCEID,
    PIF.CREATED,
    PIF.STARTDATE,
    PIF.DUEDATE,
    CASE
        WHEN PIS.STARTDATE IS NULL THEN ''Sin iniciar''
        WHEN (SYSDATE - PIS.STARTDATE) < 1/24
            THEN FLOOR((SYSDATE - PIS.STARTDATE) * 1440) || '' min''
        WHEN (SYSDATE - PIS.STARTDATE) < 1
            THEN FLOOR((SYSDATE - PIS.STARTDATE) * 24) || '' h '' ||
                 FLOOR(((SYSDATE - PIS.STARTDATE) * 24 - FLOOR((SYSDATE - PIS.STARTDATE) * 24)) * 60) || '' min''
        ELSE FLOOR(SYSDATE - PIS.STARTDATE) || '' dias '' ||
             FLOOR(((SYSDATE - PIS.STARTDATE) - FLOOR(SYSDATE - PIS.STARTDATE)) * 24) || '' h''
    END                                                                         TIEMPOETAPA,
    (SELECT COUNT(*) FROM PROCESSSPECSTEP SSC
     WHERE SSC.FLOWID = PC.FLOWID AND SSC.ID <= PC.CURRENTSTEPID)              STEPCURRENT,
    (SELECT COUNT(*) FROM PROCESSSPECSTEP SSC
     WHERE SSC.FLOWID = PC.FLOWID)                                              STEPTOTAL,
    CAST(
        ((SELECT COUNT(*) FROM PROCESSSPECSTEP SSC
          WHERE SSC.FLOWID = PC.FLOWID AND SSC.ID <= PC.CURRENTSTEPID) * 100)
        / NULLIF((SELECT COUNT(*) FROM PROCESSSPECSTEP SSC
                  WHERE SSC.FLOWID = PC.FLOWID), 0)
    AS DECIMAL(5,0))                                                            PROGRESS,
    PIST.NAME                                                                   STEPNAME,
    PIS.STARTDATE                                                               STEPSTARTDATE,
    PIS.DUEDATE                                                                 STEPDUEDATE,
    UM_STEP.FIRSTNAME || '' '' || UM_STEP.LASTNAME                               USUARIOETAPA,
    (SELECT LISTAGG(NOMBRE || '' ('' || CARGA || '' casos)'', '' | '')
            WITHIN GROUP (ORDER BY CARGA ASC, NOMBRE ASC)
     FROM (
         SELECT DISTINCT
                UM2.FIRSTNAME || '' '' || UM2.LASTNAME AS NOMBRE,
                (SELECT COUNT(*) FROM PROCESSCASE PC2
                 WHERE PC2.COMPANYID = PC.COMPANYID
                   AND PC2.USERASSIGNED = UM2.USERID
                   AND PC2.STATUS NOT IN (3,4)) AS CARGA
         FROM PROCESSSPECSTEPROLE PSR3
         JOIN ROLEMEMBER RM3') || TO_CLOB('
              ON RM3.ROLEID = PSR3.ROLEID
             AND RM3.COMPANYID = PC.COMPANYID
             AND LOWER(RM3.ROLENAME) IN ({app.UserRoleNameList})
         JOIN USERROLEMEMBER URM2
              ON URM2.ROLEID = RM3.ROLEID
             AND URM2.COMPANYID = PC.COMPANYID
         JOIN USERMEMBER UM2
              ON UM2.USERID = URM2.USERID
             AND UM2.RECORDSTATUS = 1
         WHERE PSR3.COMPANYID = PC.COMPANYID
           AND PSR3.ID = PIS.STEPID
     ))                                                                         COLABORADORES,
    (SELECT LISTAGG(RM2.ROLENAME, '', '') WITHIN GROUP (ORDER BY RM2.ROLENAME)
     FROM PROCESSSPECSTEPROLE PSR2
     JOIN ROLEMEMBER RM2
          ON RM2.ROLEID = PSR2.ROLEID
         AND RM2.COMPANYID = PC.COMPANYID
         AND LOWER(RM2.ROLENAME) IN ({app.UserRoleNameList})
     WHERE PSR2.COMPANYID = PC.COMPANYID
       AND PSR2.ID = PIS.STEPID)                                                ROLES,
    PC.REFERENCE3                                                               CORREDURIA
FROM PROCESSCASE PC
LEFT JOIN LOOKUP LKS
    ON LKS.LOOKUPID = 61 AND LKS.COMPANYID = 0 AND LKS.LANGUAGE = 1 AND LKS.CODE = PC.STATUS
LEFT JOIN LOOKUP LKCP
    ON LKCP.LOOKUPID = 62 AND LKCP.COMPANYID = 0 AND LKCP.LANGUAGE = 1 AND LKCP.CODE = PC.PRIORITY
LEFT JOIN PROCESSSPECFLOW PF
    ON PF.COMPANYID = PC.COMPANYID AND PF.ID = PC.FLOWID
LEFT JOIN PROCESSINSTANCE PIF
    ON PIF.COMPANYID = PC.COMPANYID AND PIF.INSTANCEID = PC.INSTANCEID AND PIF.STEPID = 0
LEFT JOIN PROCESSINSTANCE PIS
    ON PIS.COMPANYID = PC.COMPANYID AND PIS.INSTANCEID = PC.INSTANCEID
    AND PIS.STEPID > 0 AND PIS.TASKID = 0
    AND PIS.STARTDATE IS NOT NULL AND PIS.FINISHDATE IS NULL
LEFT JOIN PROCESSSPECSTEP PIST
    ON PIST.COMPANYID = PIS.COMPANYID AND PIST.FLOWID = PIS.FLOWID AND PIST.ID = PIS.STEPID
LEFT JOIN USERMEMBER UM_STEP
    ON UM_STEP.USERID = PIS.USERASSIGNED AND UM_STEP.COMPANYID = PC.COMPANYID
JOIN PROCESSSPECSTEPROLE PSR
    ON PSR.COMPANYID = PC.COMPANYID AND PSR.ID = PIST.ID
JOIN ROLEMEMBER RM
    ON RM.ROLEID = PSR.ROLEID
   AND RM.COMPANYID = PC.COMPANYID
   AND LOWER(RM.ROLENAME) IN ({app.UserRoleNameList})
WHERE PC.COMPANYID = {app.companyid}
  AND PC.FLOWID > 0
  AND PC.INSTANCEID > 0
  AND PC.STATUS NOT IN (3, 4)
  AND (SELECT COUNT(*) FROM PROCESSSPECSTEP SSC WHERE SSC.FLOWID = PC.FLOWID) > 0
ORDER BY PIF.STARTDATE DESC')
);

-- -------------------------------------------------------
-- Visualization ID: 200003 | Asignacion de Caso
-- -------------------------------------------------------
MERGE INTO VISUALIZATIONS V
USING (SELECT 200003 AS ID FROM DUAL) SRC
ON (V.ID = SRC.ID)
WHEN MATCHED THEN UPDATE SET
    V.SEQUENCE = 1,
    V.KEY = 'CaseAssignment',
    V.COMPANYID = 1,
    V.ENTITYTYPE = NULL,
    V.TYPE = 9,
    V.CAPTION = 'Asignacion de Caso',
    V.DESCRIPTION = 'Form',
    V.STATEMENTTYPE = NULL,
    V.SPECIFICATION = NULL,
    V.DIALOG = 'Asignacion de Caso|titulo
Detalle del caso|zona|columns=3
 No. Caso|entero(9)|name=CaseId|hidden=true
 Asunto|texto(130)|name=CaseTitle|readonly=true
 Flujo del proceso|texto(80)|name=FlowName|readonly=true
 Estado|texto(80)|name=StatusDesc|readonly=true
 Prioridad|texto(80)|name=PriorityDesc|readonly=true
 Etapa actual|texto(80)|name=StepName|readonly=true
 Tiempo en etapa|texto(80)|name=TiempoEtapa|readonly=true
 Avance|texto(80)|name=Progreso|readonly=true
Asignacion de colaborador|zona|columns=2
 Actualmente asignado|texto(256)|name=CurrentAssignee|readonly=true
Historial de asignaciones|zona|columns=2
 Historial|texto(80)|name=TimelineHistorial|readonly=true
Reasignacion|zona|columns=2
 Reasignar a+|lista|name=UserAssigned|lookup=Users
Acciones|zona|columns=2
 Confirmar asignacion|button|name=saveBtn|class=btn-primary btn-sm formbtn
 Cancelar|button|name=cancelBtn|class=btn-white btn-sm formbtn',
    V.ICON = NULL,
    V.ICONCLASS = NULL,
    V.VALUEFORMAT = NULL,
    V.CONNECTIONNAME = NULL,
    V.JAVASCRIPTTOINCLUDE = 'Cases/Ext.CaseAssignment.js',
    V.RECORDSTATUS = 1,
    V.UPDATEUSERCODE = 6329,
    V.UPDATEDATE = SYSDATE,
    V.STATEMENT = NULL
WHEN NOT MATCHED THEN INSERT (
    ID, SEQUENCE, KEY, COMPANYID, ENTITYTYPE, TYPE, CAPTION, DESCRIPTION, STATEMENTTYPE, SPECIFICATION, DIALOG, ICON, ICONCLASS, VALUEFORMAT, CONNECTIONNAME, JAVASCRIPTTOINCLUDE, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE, STATEMENT
) VALUES (
    200003, 1, 'CaseAssignment', 1, NULL, 9, 'Asignacion de Caso', 'Form', NULL, NULL, 'Asignacion de Caso|titulo
Detalle del caso|zona|columns=3
 No. Caso|entero(9)|name=CaseId|hidden=true
 Asunto|texto(130)|name=CaseTitle|readonly=true
 Flujo del proceso|texto(80)|name=FlowName|readonly=true
 Estado|texto(80)|name=StatusDesc|readonly=true
 Prioridad|texto(80)|name=PriorityDesc|readonly=true
 Etapa actual|texto(80)|name=StepName|readonly=true
 Tiempo en etapa|texto(80)|name=TiempoEtapa|readonly=true
 Avance|texto(80)|name=Progreso|readonly=true
Asignacion de colaborador|zona|columns=2
 Actualmente asignado|texto(256)|name=CurrentAssignee|readonly=true
Historial de asignaciones|zona|columns=2
 Historial|texto(80)|name=TimelineHistorial|readonly=true
Reasignacion|zona|columns=2
 Reasignar a+|lista|name=UserAssigned|lookup=Users
Acciones|zona|columns=2
 Confirmar asignacion|button|name=saveBtn|class=btn-primary btn-sm formbtn
 Cancelar|button|name=cancelBtn|class=btn-white btn-sm formbtn', NULL, NULL, NULL, NULL, 'Cases/Ext.CaseAssignment.js', 1, 6329, SYSDATE, NULL
);

COMMIT;
