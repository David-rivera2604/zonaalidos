SET DEFINE OFF;
MERGE INTO VISUALIZATIONS A USING
 (SELECT
  341 as ID,
  1 as SEQUENCE,
  NULL as KEY,
  1 as COMPANYID,
  NULL as ENTITYTYPE,
  1 as TYPE,
  'Renovación de pólizas' as CAPTION,
  'Renovación de pólizas' as DESCRIPTION,
  2 as STATEMENTTYPE,
  'EM_K_TABLES_CONTRACT_MCR.p_lee_polizas_cotz_13_meses {app.P_COD_CIA} {app.P_COD_AGT}' as STATEMENT,
  '{
    "title": "Renovación de pólizas",
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
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
            {
                "title": "Acciones",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "function (value, row, index, field) { return ''<span class=columnBtn>'' + ''<button type=\"button\" name=\"renovarPol\" class=\"btn btn-sm btn-white event\" title=\"Permite renovar una póliza\"><i class=\"fa fa-step-forward\"></i></button>''+''</span>'' ;}",
                "visible": true,
                "events": true,
                "action_renovarPol": "app.ui.ShowSideBar({ title: ''Renovar la póliza'', subtitle: ''#{NUM_POLIZA}'', id: 9005, data: row, width: ''400px''})"
            }
        ]
    }
}' as SPECIFICATION,
  NULL as DIALOG,
  NULL as ICON,
  NULL as ICONCLASS,
  NULL as VALUEFORMAT,
  'Tron' as CONNECTIONNAME,
  'Extend.Policy.js' as JAVASCRIPTTOINCLUDE,
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

MERGE INTO VISUALIZATIONS A USING
 (SELECT
  9003 as ID,
  1 as SEQUENCE,
  NULL as KEY,
  1 as COMPANYID,
  NULL as ENTITYTYPE,
  9 as TYPE,
  'Cancelar una póliza' as CAPTION,
  'Panel' as DESCRIPTION,
  NULL as STATEMENTTYPE,
  NULL as STATEMENT,
  NULL as SPECIFICATION,
  'Cancelar la póliza #|título
|zona|12
 Fecha de cancelación+|fecha|default=today;name=Fec_Anulacion
 Motivo+|nota|filas=2;name=Mot_Spto
 Cancelar|Boton|name=CancelarBtn;click=app.Ex_Policy.Cancelar({NUM_POLIZA});class=btn-danger' as DIALOG,
  NULL as ICON,
  NULL as ICONCLASS,
  NULL as VALUEFORMAT,
  NULL as CONNECTIONNAME,
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

MERGE INTO VISUALIZATIONS A USING
 (SELECT
  9005 as ID,
  1 as SEQUENCE,
  NULL as KEY,
  1 as COMPANYID,
  NULL as ENTITYTYPE,
  9 as TYPE,
  'Renovar una póliza' as CAPTION,
  'Panel' as DESCRIPTION,
  NULL as STATEMENTTYPE,
  NULL as STATEMENT,
  NULL as SPECIFICATION,
  'Renovar una póliza|título
|zona|12
 Renovar|Boton|event.clickWithValidate=app.Ex_Policy.Renovacion_Procesar;class=btn-primary' as DIALOG,
  NULL as ICON,
  NULL as ICONCLASS,
  NULL as VALUEFORMAT,
  NULL as CONNECTIONNAME,
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

MERGE INTO VISUALIZATIONS A USING
 (SELECT
  302 as ID,
  7 as SEQUENCE,
  NULL as KEY,
  1 as COMPANYID,
  NULL as ENTITYTYPE,
  1 as TYPE,
  'Detalle de la póliza - Certificados por vigencia' as CAPTION,
  'Detalle...' as DESCRIPTION,
  2 as STATEMENTTYPE,
  'em_k_jrp_cuadro_poliza_302_mcr.p_lista_certificado_historico {app.p_cod_cia} {P_NUM_POLIZA:varchar}' as STATEMENT,
  '{
    "title": "Detalle de la póliza - Certificados por vigencia",
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
                "title": "No. Póliza",
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
                "lookupList": "[{''code'':''XX'',''desc'':''XX''},{''code'':''RF'',''desc'':''Renovación manual''}]",
                "visible": true
            },
            {
                "field": "FEC_EMISION",
                "title": "Emisión",
                "sortable": true,
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
}' as SPECIFICATION,
  NULL as DIALOG,
  NULL as ICON,
  NULL as ICONCLASS,
  NULL as VALUEFORMAT,
  'Tron' as CONNECTIONNAME,
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
