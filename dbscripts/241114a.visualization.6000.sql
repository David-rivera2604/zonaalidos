DELETE FROM VISUALIZATIONS WHERE ID=6000 AND "SEQUENCE"=1;

INSERT INTO VISUALIZATIONS (ID, "SEQUENCE", "TYPE", CAPTION, DESCRIPTION, "STATEMENT", ICON, ICONCLASS, VALUEFORMAT, ENTITYTYPE, RECORDSTATUS, COMPANYID, UPDATEUSERCODE, UPDATEDATE, SPECIFICATION, CONNECTIONNAME, STATEMENTTYPE, DIALOG, STATEMENTEXTEND, "KEY", JAVASCRIPTTOINCLUDE) VALUES(6000, 1, 1, 'Pólizas', 'Pólizas', 'DC_K_CONSULTA_WEB.P_DEVUELVE_CONSULTA {app.P_COD_CIA} {const.9999999} {P_COD_USR:varchar} {tipo:varchar} {tip_docum:varchar} {valor:varchar} {p_rol_usr_web:varchar} {p_grupo_cliente:varchar} {p_dev_consulta:cursor} {p_errores:cursor}', NULL, NULL, NULL, NULL, 1, 1, 1, TIMESTAMP '2020-12-30 15:40:46.000000', '{
"title": "Pólizas",
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
            "title": "Póliza",
            "sortable": true,
            "halign": "center",
            "align": "left",
            "format": "<a href=''tabrender?id=302&P_NUM_POLIZA={NUM_POLIZA}'' onclick=''app.ViewerQuery.TabRender(this); return false;'' title=''Ver detalle de la póliza''>{NUM_POLIZA} <button type=''button'' class=''btn btn-slim btn-sm btn-link''><i class=''fa fa-plus-square-o''></i></button></a>",
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
            "title": "Identificación",
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
}', 'Tron', 2, '|titulo
|zona|3
 Buscar por+|lista|name=tipo;datatype=string;values=D->Número de documento de identificación,P->Póliza,M->Matrícula,C->Chasis,T->Motor
 Tipo de documento+|lista|name=tip_docum;datatype=string;values=CNA->Cédula nacional,CJU->Cédula juridica,CRE->Cédula de residencia,EEX->Empresa extrajera,PAS->Pasaporte 
 Valor+|Texto(120)
 Filtrar|Boton|class=btn-primary btn-QueryFilter;click=app.Extend.Query()', NULL, NULL, 'Extend.CallCenter.js');