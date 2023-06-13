DELETE VISUALIZATIONS where id=340 and sequence=1;
DELETE VISUALIZATIONS where id=9004 and sequence=1;

insert into VISUALIZATIONS (ID, SEQUENCE, TYPE, CAPTION, DESCRIPTION, STATEMENT, ICON, ICONCLASS, VALUEFORMAT, ENTITYTYPE, RECORDSTATUS, COMPANYID, UPDATEUSERCODE, UPDATEDATE, SPECIFICATION, CONNECTIONNAME, STATEMENTTYPE, DIALOG, STATEMENTEXTEND, KEY, JAVASCRIPTTOINCLUDE)
values (340, 1, 1, 'Controles técnicos', 'Pendientes', 'SELECT a21.num_poliza,
   y.nom_ramo,
     a21.num_spto,
     a21.cod_error,
     g20.nom_error,
     a21.mca_autorizacion,
     a60.cod_docum,
     a100.nom_tercero || '' '' || a100.ape1_tercero || '' '' || a100.ape2_tercero NOMBRE_ASEG,
     a30.num_poliza_grupo,
   a21.fec_autorizacion
FROM  A2000221 a21,
     G2000211 g20,
     a2000060 a60,
     a1001399 a100,
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
AND    A21.COD_ERROR = G20.COD_ERROR
AND    a60.num_poliza = a21.num_poliza
AND    a60.tip_benef = 2
AND    a100.cod_docum = a60.cod_docum
    ---Poliza Grupo
AND    a30.cod_agt = {app.P_COD_AGT}
AND    a30.num_poliza = a21.num_poliza', null, null, null, null, 1, 1, 777, to_date('27-02-2023 21:35:45', 'dd-mm-yyyy hh24:mi:ss'), '{
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
                "title": "No. Póliza grupo",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter",
                "visible": true
            },
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
                "formatter": "function (value, row, index, field) { return ''<span class=columnBtn>'' + ''<button type=\"button\" name=\"ctroltec\" class=\"btn btn-sm btn-white event\" title=\"Permite procesar un control técnico\"><i class=\"fa fa-check\"></i></button>''+''</span>'' ;}",
                "visible": true,
                "events": true,
                "action_ctroltec": "app.ui.ShowSideBar({ title: ''Control técnico'', subtitle: ''Póliza #{NUM_POLIZA}'', id: 9004, data: row, callback: ''app.Ex_Policy.ControlTecnico_Init'', width: ''400px''})"
            }
        ]
    }
}', 'Tron', 1, null, null, null, 'Extend.Policy.js');

insert into VISUALIZATIONS (ID, SEQUENCE, TYPE, CAPTION, DESCRIPTION, STATEMENT, ICON, ICONCLASS, VALUEFORMAT, ENTITYTYPE, RECORDSTATUS, COMPANYID, UPDATEUSERCODE, UPDATEDATE, SPECIFICATION, CONNECTIONNAME, STATEMENTTYPE, DIALOG, STATEMENTEXTEND, KEY, JAVASCRIPTTOINCLUDE)
values (9004, 1, 9, 'Control técnico', 'Panel', null, null, null, null, null, 1, 1, 777, to_date('27-02-2023', 'dd-mm-yyyy'), null, null, null, 'Control técnico|título
|zona|12
 Ramo|text|name=cod_ramo
 Causa del control|nota|files=2
 Estatus+|lista|name=tip_autoriza;values=1->Autoriza,2->Rechaza,3->Pendiente
 Observación+|nota|name=observacion;files=2
 Principal|Correo|name=correo1
 Copia 1|Correo|name=correo2
 Procesar|Boton|event.clickWithValidate=app.Ex_Policy.ControlTecnico_Procesar;class=btn-primary', null, null, null);
