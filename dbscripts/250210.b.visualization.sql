UPDATE VISUALIZATIONS SET "TYPE"=1, CAPTION='Polizas activas', DESCRIPTION='Mis clientes - Agente conectado', "STATEMENT"='em_k_Mapfre_Query_Contract_mcr.p_policy_by_agent_tomador {app.P_COD_CIA} {app.P_COD_AGT}', ICON=NULL, ICONCLASS=NULL, VALUEFORMAT=NULL, ENTITYTYPE=NULL, RECORDSTATUS=1, COMPANYID=1, UPDATEUSERCODE=777, UPDATEDATE=TIMESTAMP '2023-02-27 21:49:26.000000', SPECIFICATION='{
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
"formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button type=\"button\" name=\"print\" class=\"btn btn-sm btn-white event\" title=\"Permite imprimir la poliza\"><i class=\"fa fa-print\"></i></button>'' + ''<button type=\"button\" name=\"sendemail\" class=\"btn btn-sm btn-white event\" title=\"Permite enviar el certificado por correo\"><i class=\"fa fa-envelope-o\"></i></button>'' + ''<button type=\"button\" name=\"updatepol\" class=\"btn btn-sm btn-white event\" title=\"Permite realizar variaciones sobre la poliza\"><i class=\"fa fa-pencil\"></i></button>''+''<button type=\"button\" name=\"cancelpol\" class=\"btn btn-sm btn-white event\" title=\"Permite cancelar la p?liza\"><i class=\"fa fa-close\"></i></button>''+''<button type=\"button\" name=\"changeBenf\" class=\"btn btn-sm btn-white event\" title=\"Permite cambiar el beneficiario pagador\"><i class=\"fa fa-handshake-o\"></i></button>''+''</span>'' ;}",
"visible": true,
"events": true,
"action_sendemail": "app.ui.ShowSideBar({ title: ''Enviar certificado por correo'', subtitle: ''Poliza #{NUM_POLIZA}'', id: 9000, data: row})",
"action_updatepol": "app.ui.ShowSideBar({ isExternal: true, url: ''/Aliados/variaciones/mapfremas'', title: ''Solicitud de variaciones'', width: ''600px'', data: row})",
"action_cancelpol":  "app.ui.ShowSideBar({ title: ''Cancelar la poliza #{NUM_POLIZA}'', id: 9003, data: row})",
"action_changeBenf": "app.ui.ShowSideBar({ title: ''Poliza #{NUM_POLIZA}'', id: 9007, data: row})"
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
}', CONNECTIONNAME='Tron', STATEMENTTYPE=2, DIALOG=NULL, STATEMENTEXTEND=NULL, "KEY"=NULL, JAVASCRIPTTOINCLUDE='Extend.Policy.js' WHERE ID=300 AND "SEQUENCE"=1;
UPDATE VISUALIZATIONS SET "TYPE"=9, CAPTION='Cambio de beneficiario pagador', DESCRIPTION='Panel', "STATEMENT"=NULL, ICON=NULL, ICONCLASS=NULL, VALUEFORMAT=NULL, ENTITYTYPE=NULL, RECORDSTATUS=1, COMPANYID=1, UPDATEUSERCODE=888, UPDATEDATE=TIMESTAMP '2023-03-31 00:00:00.000000', SPECIFICATION=NULL, CONNECTIONNAME=NULL, STATEMENTTYPE=NULL, DIALOG='Cambio de beneficiario pagador|título
|zona|12
 Identificación del nuevo pagador+|cedula
 Aplicar cambio|Boton|name=ApplyChangeBtn;click=app.Ex_Policy.ChangePayer(''{NUM_POLIZA_GRUPO}'', ''{NUM_POLIZA}'', ''{NUM_RIESGO}'');class=btn-primary', STATEMENTEXTEND=NULL, "KEY"=NULL, JAVASCRIPTTOINCLUDE=NULL WHERE ID=9007 AND "SEQUENCE"=1;