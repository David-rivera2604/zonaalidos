DELETE VISUALIZATIONS where id=300 and sequence=1;
DELETE VISUALIZATIONS where id=9003 and sequence=1;
insert into VISUALIZATIONS (ID, SEQUENCE, TYPE, CAPTION, DESCRIPTION, STATEMENT, ICON, ICONCLASS, VALUEFORMAT, ENTITYTYPE, RECORDSTATUS, COMPANYID, UPDATEUSERCODE, UPDATEDATE, SPECIFICATION, CONNECTIONNAME, STATEMENTTYPE, DIALOG, STATEMENTEXTEND, KEY, JAVASCRIPTTOINCLUDE)
values (300, 1, 1, 'Pólizas activas', 'Mis clientes - Agente conectado', 'em_k_Mapfre_Query_Contract_mcr.p_policy_by_agent_tomador {app.P_COD_CIA} {app.P_COD_AGT}', null, null, null, null, 1, 1, 202305, to_date('31-05-2023', 'dd-mm-yyyy'), '{
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
"formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button type=\"button\" name=\"print\" class=\"btn btn-sm btn-white event\" title=\"Permite imprimir la poliza\"><i class=\"fa fa-print\"></i></button>'' + ''<button type=\"button\" name=\"sendemail\" class=\"btn btn-sm btn-white event\" title=\"Permite enviar el certificado por correo\"><i class=\"fa fa-envelope-o\"></i></button>'' + ''<button type=\"button\" name=\"updatepol\" class=\"btn btn-sm btn-white event\" title=\"Permite realizar variaciones sobre la poliza\"><i class=\"fa fa-pencil\"></i></button>''+''<button type=\"button\" name=\"cancelpol\" class=\"btn btn-sm btn-white event\" title=\"Permite cancelar la p?liza\"><i class=\"fa fa-close\"></i></button>''+''</span>'' ;}",
"visible": true,
"events": true,
"action_sendemail": "app.ui.ShowSideBar({ title: ''Enviar certificado por correo'', subtitle: ''Poliza #{NUM_POLIZA}'', id: 9000, data: row})",
"action_updatepol": "app.ui.ShowSideBar({ isExternal: true, url: ''/Aliados/variaciones/mapfremas'', title: ''Solicitud de variaciones'', width: ''600px'', data: row})",
"action_cancelpol":  "app.ui.ShowSideBar({ title: ''Cancelar la póliza #{NUM_POLIZA}'', id: 9003, data: row})"
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
"formatter": "function (value, row, index, field) { return ''<a href=tabrender?id=302='' + row.NUM_POLIZA + '' onclick=app.ViewerQuery.TabRender(this); return false;>'' + value + ''</a>''; }"
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
"title": "Cedula",
"sortable": true,
"halign": "center",
"align": "left",
"format": "{TIP_DOCUM} {COD_DOCUM}"
},
{
"field": "NOM_COMPLETO",
"title": "Contratante",
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
"field": "COD_DOCUM_ASEG",
"title": "Cedula Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"format": "{TIP_DOCUM_ASEG} {COD_DOCUM_ASEG}"
},
{
"field": "NOM_ASEGURADO",
"title": "Asegurado",
"sortable": true,
"halign": "center",
"align": "left",
"formatter": "app.ui.StringCapitalizeEachWordFormatter"
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
}', 'Tron', 2, null, null, null, 'Extend.Policy.js');

insert into VISUALIZATIONS (ID, SEQUENCE, TYPE, CAPTION, DESCRIPTION, STATEMENT, ICON, ICONCLASS, VALUEFORMAT, ENTITYTYPE, RECORDSTATUS, COMPANYID, UPDATEUSERCODE, UPDATEDATE, SPECIFICATION, CONNECTIONNAME, STATEMENTTYPE, DIALOG, STATEMENTEXTEND, KEY, JAVASCRIPTTOINCLUDE)
values (9003, 1, 9, 'Cancelar una póliza', 'Panel', null, null, null, null, null, 1, 1, 202305, to_date('31-05-2023', 'dd-mm-yyyy'), null, null, null, 'Cancelar la póliza #|título
|zona|12
 Fecha de cancelación+|fecha|default=today;name=Fec_Anulacion
 Motivo+|nota|filas=2;name=Mot_Spto
 Cancelar|Boton|name=CancelarBtn;click=app.Ex_Policy.Cancelar({NUM_POLIZA});class=btn-danger', null, null, null);
