DELETE FROM VISUALIZATIONS where id =9103;

INSERT INTO VISUALIZATIONS (DIALOG,"KEY",ID,CAPTION,JAVASCRIPTTOINCLUDE,"SEQUENCE",COMPANYID,ENTITYTYPE,"TYPE",DESCRIPTION,STATEMENTTYPE,"STATEMENT",SPECIFICATION,ICON,ICONCLASS,VALUEFORMAT,CONNECTIONNAME,STATEMENTEXTEND,RECORDSTATUS,UPDATEUSERCODE,UPDATEDATE) VALUES (NULL,NULL,9103,'Garantías electrónicas','Form.Ext.SICOP.js',1,1,NULL,1,NULL,1,'SELECT ID, INSTITUTION_IDENTIFIER, SUPPLIER_IDENTIFIER, GUARANTEE_IDENTIFIER, GUARANTEE_NAME, INSTITUCION_NOTICE_NUMBER, NOTICE_NUMBER, CUENTA_CLIENTE, GUARANTEE_CHARGE_PERSON_NAME, GUARANTEE_CHARGE_PERSON_EMAIL, GUARANTEE_TELEPHONE_NUMBER, GUARANTEE_POSTAL_CODE, GUARANTEE_ADDRESS_LINE, GUARANTEE_NUMBER, GUARANTEE_SEQUENCENUMBER, GUARANTEE_TYPE_CODE, GUARANTEE_PAYMENT_CODE, GUARANTEE_AMOUNT, MONEDA, ISSUE_DATE, VALID_PERIOD_DATE, TIPO_DE_MODIFICATION, GUARANTEE_CONTENTS, CONFIRMATION, MSG_ERR, UPDATEUSERCODE, UPDATEDATE, SUPPLIER_NAME, METODO, CODIGO_PROCESO, FECHA_PROCESO FROM ELECTRONICWARRANTY P
WHERE P.Guarantee_sequencenumber = (SELECT max(Guarantee_sequencenumber) FROM ElectronicWarranty M WHERE M.Guarantee_number = P.Guarantee_number) ORDER BY UPDATEDATE DESC',TO_CLOB('{
	"title": "Garantías electrónicas",
	"table": {
		"pagination": true,
		"search": true,
		"showToggle": false,
		"showRefresh": true,
		"showColumns": true,
		"showExport": true,
		"showPaginationSwitch": false,
		"exportTypes": [
			"csv"
		],
		"buttons": "app.Form_Ext_SICOP.Boton",
		"detailId": 9104,
		"detailParameters": "code=GUARANTEE_NUMBER",
		"columns": [
			{
				"title": "Acciones",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.Form_Ext_SICOP.ActionFormatter",
				"events": true,
				"action_editar": "app.ui.Redirect(''../viewer/Form?id=NotificarGarantia&code={GUARANTEE_NUMBER}'')",
				"action_liberar": "app.ui.Redirect(''../viewer/Form?id=NotificarLiberacion&code={GUARANTEE_NUMBER}'')"
			},
			{
				"field": "GUARANTEE_NUMBER",
				"title": "Garantía #",
				"sortable": true,
				"halign": "center",
				"align": "center",
				"format": "<a href=''../viewer/Form?id=NotificarGarantia&code={GUARANTEE_NUMBER}'' title=''Modificar la garantía #{GUARANTEE_NUMBER}''>{GUARANTEE_NUMBER} - {GUARANTEE_SEQUENCENUMBER}</a>"
			},		
{
				"field": "METODO",
				"title": "Estado",
				"sortable": true,
				"halign": "center",
				"align": "center",
				"formatter": "app.ui.LookUpListFormatter",
				"lookupList": "[{''code'':''0'',''desc'':''Ejecutar''},{''code'':''1'',''desc'':''Liberar''}]",
				"visible": true
			},
			{
				"field": "CODIGO_PROCESO",
				"title": "Código de proceso",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
            {
                "field": "FECHA_PROCESO",
                "title": "Fecha y hora del estado",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateAndTimeFormatter",
				"visible": false
            },
			{
				"field": "ISSUE_DATE",
				"title": "Fecha de inicio",
				"sortabl')||TO_CLOB('e": true,
				"halign": "center",
				"align": "center",
				"formatter": "app.ui.DateFormatter"
			},            
			{
				"field": "VALID_PERIOD_DATE",
				"title": "Fecha de vencimiento",
				"sortable": true,
				"halign": "center",
				"align": "center",
				"formatter": "app.ui.DateFormatter"
			},
			{
				"field": "GUARANTEE_TYPE_CODE",
				"title": "Tipo",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.LookUpListFormatter",
				"lookupList": "[{''code'':''BG'',''desc'':''Participación''},{''code'':''CG'',''desc'':''Cumplimiento''},{''code'':''PG'',''desc'':''Colateral''}]"
			},
			{
				"field": "INSTITUTION_IDENTIFIER",
				"title": "Institución que promueve",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter"
			},
			{
				"field": "SUPPLIER_IDENTIFIER",
				"title": "Proveedor",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter"
			},
			{
				"field": "GUARANTEE_IDENTIFIER",
				"title": "Entidad garante",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"format": "{GUARANTEE_IDENTIFIER} {GUARANTEE_NAME}",
				"visible": false
			},
			{
				"field": "INSTITUCION_NOTICE_NUMBER",
				"title": "Número de procedimiento",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "NOTICE_NUMBER",
				"title": "Número de cartel",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter"
			},
			{
				"field": "CUENTA_CLIENTE",
				"title": "Número de cuenta",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "GUARANTEE_CHARGE_PERSON_NAME",
				"title": "Nombre del funcionario",
')||TO_CLOB('
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "GUARANTEE_CHARGE_PERSON_EMAIL",
				"title": "Correo electrónico del funcionario",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "GUARANTEE_TELEPHONE_NUMBER",
				"title": "Teléfono del funcionario",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "GUARANTEE_POSTAL_CODE",
				"title": "Código postal del funcionario",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "GUARANTEE_ADDRESS_LINE",
				"title": "Dirección del funcionario",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "GUARANTEE_PAYMENT_CODE",
				"title": "Forma de pago",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.LookUpListFormatter",
				"lookupList": "[{''code'':''01'',''desc'':''Efectivo''},{''code'':''02'',''desc'':''Certificados depósitos''},{''code'':''03'',''desc'':''Cheque certificado''},{''code'':''05'',''desc'':''Bono del estado''},{''code'':''06'',''desc'':''Cheque gerencia''},{''code'':''07'',''desc'':''Garantía Electrónica''}]"
			},
			{
				"field": "GUARANTEE_AMOUNT",
				"title": "Monto",
				"sortable": true,
				"halign": "center",
				"align": "right",
				"formatter": "app.ui.CurrencyAmountFormatter"
			},
			{
				"field": "MONEDA",
				"title": "Moneda",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "TIPO_DE_MODIFICATION",
				"t')||TO_CLOB('itle": "Tipo de cambio",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.LookUpListFormatter",
				"lookupList": "[{''code'':''01'',''desc'':''Ampliación de plazo''},{''code'':''02'',''desc'':''Ampliación de monto''},{''code'':''03'',''desc'':''Prórroga de plazo y monto''}]",
				"visible": false
			},
			{
				"field": "GUARANTEE_CONTENTS",
				"title": "Comentarios",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter"
			},
			{
				"field": "CONFIRMATION",
				"title": "Confirmación",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
			{
				"field": "MSG_ERR",
				"title": "Mensaje retornado",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter"
			},
			{
				"field": "UPDATEDATE",
				"title": "Realizado por",
				"sortable": true,
				"halign": "center",
				"align": "center",
				"formatter": "app.ui.UpdateDateAndUserFormatter"
			}
		]
	}
}'),NULL,NULL,NULL,'Test',NULL,1,6329,TIMESTAMP'2024-05-13 00:00:00');
