INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE,"STATEMENT") VALUES (317,1,1,'Recibos pendientes de cobro','Para el agente conectado',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'2021-06-15 14:14:20',TO_CLOB('{
"title": "Recibos pendientes de cobro",
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
      "align": "left",
      "formatter": "app.ui.StringFormatter"
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
   },   
   {
      "field": "NOM_COMPLETO2",
      "title": "Contratante",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "NUM_RECIBO",
      "title": "Recibo",
      "sortable": true,
      "halign": "center",
      "align": "center"
   },
   {
      "field": "TIP_GESTOR_DESC",
      "title": "Gestor",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "TIP_SITUACION_DESC",
      "title": "Estado",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "NOM_MON",
      "title": "Moneda",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "IMP_RECIBO",
      "title": "Monto",
      "sortable": true,
      "halign": "center",
      "align": "right",
      "formatter": "app.ui.DecimalFormatter"
   },
   {
      "field": "IMP_COMIS",
      "title": "Comisión')||TO_CLOB('",
      "sortable": true,
      "halign": "center",
      "align": "right",
      "formatter": "app.ui.DecimalFormatter"
   },
   {
      "field": "FEC_VCTO_RECIBO",
      "title": "Fecha de Vencimiento",
      "sortable": true,
      "halign": "center",
      "align": "center",
      "formatter": "app.ui.DateFormatter"
   },
   {
      "field": "NOM_FRACC_PAGO",
      "title": "Frecuencia de pago",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },   
   {
      "field": "EMAIL",
      "title": "Email",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "TLF_NUMERO",
      "title": "Telf. 1",
      "titleTooltip": "Número de teléfono 1",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "TLF_NUMERO_COM",
      "title": "Telf. 2",
      "titleTooltip": "Número de teléfono 2",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "formatter": "app.ui.StringFormatter"
   },
   {
      "field": "NOM_DOMICILIO1",
      "title": "Dirección",
      "sortable": true,
      "halign": "center",
      "align": "left",
      "format": "{NOM_DOMICILIO1} {NOM_DOMICILIO2} {NOM_DOMICILIO3}"
   }                 
]
}
}'),'Tron',2,'|título
|zona|4
 Desde+|fechainicio|default=today
 Hasta+|fechafin|default=today
 Filtrar|Boton|class=btn-form btn-primary;click=app.ViewerQuery.Refresh(undefined, $(@_#RoleMemberGridTbl@_), 11, @_@_)',NULL,NULL,NULL,TO_CLOB('em_k_Mapfre_Query_Contract_mcr.p_pending_receipts {app.P_COD_CIA} {app.P_COD_AGT} {desde:date} {hasta:date}'));
