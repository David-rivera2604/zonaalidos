UPDATE VISUALIZATIONS SET ID=9100, "KEY"='InformacionProveedor', DIALOG='Información del proveedor|título
Datos para la busqueda|zona|4
 Identificación del proveedor a buscar+|texto(12)|name=SUPPLIER_ID
 Buscar|button|name=btnSearch|class=btn-on-primary
Datos del proveedor|zona|4
 Nombre|texto|name=SUPPLIER_NM|disabled=true
 Dirección|texto|name=ADDR|disabled=true
 Código postal|texto|name=POST_NO|disabled=true
 Página web|texto|name=HPAGE|disabled=true
Datos de contacto|zona|4 
 Número de teléfono|texto|name=TEL_NO|disabled=true
 Número de fax|texto|name=FAX_NO|disabled=true
 Correo electrónico|texto|name=EMAIL|disabled=true';

UPDATE VISUALIZATIONS SET ID=9101, "KEY"='NotificarGarantia', DIALOG='Notificar a SICOP de la recepción de garantías electrónicas de participación y cumplimiento|título
Datos de la garantía electrónica|zona|3
 Número+|texto(14)|name=Guarantee_number|title=Cedula jurídica institución que promueve el proceso de contratación
 Secuencia+|texto(2)|name=Guarantee_sequencenumber|disabled=true
 Tipo|radio|name=Guarantee_type_code|values=BG->Participación,CG->Cumplimiento,PG->Colateral|datatype=string
 Forma de pago|lista|name=Guarantee_payment_code|datatype=string|values=01->Efectivo,02->Certificados depósitos,03->Cheque certificado,05->Bono del estado,06->Cheque gerencia,07->Garantía Electrónica|default=07|disabled=true
 Número de cuenta|texto(20)|name=Cuenta_cliente|title=Solo en caso de ser garantías en efectivo|visible=ctrol.Guarantee_payment_code.eq.''01'' 
 Moneda+|radio|name=Moneda|values=CRC->Colón Costarricense,USD->Dolar|default=CRC|datatype=string
 Monto total+|decimal(18,3)|name=Guarantee_amount
 Tipo de modificación+|radio|name=Tipo_de_modification|values=01->Ampliación de plazo,02->Ampliación de monto,03->Prórroga de plazo y monto|datatype=string|hidden=true 
Datos de la entidad garante|zona|3  
 Cédula jurídica+|texto(10)|name=Guarantee_identifier|disabled=true
 Entidad garante|texto(200)|name=Guarantee_name|disabled=true
 Nombre del funcionario|texto(200)|name=Guarantee_charge_person_name|column=6
 Correo electrónico|Correo(50)|name=Guarantee_charge_person_email
 Teléfono|Teléfono(16)|name=Guarantee_telephone_number|modo=simple
 Código postal|texto(5)|name=Guarantee_postal_code
 Dirección|nota(200)|name=Guarantee_address_line|filas=2|column=6 
Datos generales|zona|3
 Número de procedimiento+|texto(24)|name=Institucion_notice_number
 Número del pliego de condiciones+|texto(11)|name=Notice_number|title=Número de cartel en SICOP
 Cédula del proveedor+|texto(12)|name=Supplier_identifier|title=Garantía por cuenta de
 Nombre del proveedor|texto(200)|name=Supplier_name|disabled=true
 Cédula de la institución+|texto(10)|name=Institution_identifier|title=Garantía a favor de
 Fecha de inicio de validez+|fechainicio|name=Issue_date|default=today|title=Fecha de inicio de validez de la garantía
 Fecha de vencimiento+|fechafin|name=Valid_period_date|title=Fecha de vencimiento de la garantía
 Comentarios de la garantía|nota(2000)|name=Guarantee_contents|filas=4|column=6 
 Notificar|button|name=btnNotify|class=btn-on-primary';

UPDATE VISUALIZATIONS SET ID=9102, "KEY"='NotificarLiberacion', DIALOG='Notificar a SICOP sobre la ejecución de los procesos de liberación y ejecución de las Garantías Electrónicas por parte de la Institución promotora del proceso de Contratación Administrativa|título
Datos generales|zona|3
 Número de garantía electrónica generado por la entidad garante+|texto(14)|name=Guarantee_number|disabled=true
 Secuencia de la garantía electrónica+|texto(2)|name=Guarantee_sequencenumber|disabled=true
 Cédula jurídica de la entidad garante|texto(10)|name=Guarantee_identifier|disabled=true
 Nombre de la entidad garante|texto(200)|name=Guarantee_name|disabled=true
 Número de cuenta en la cual se depositó el monto solicitado|texto(20)|name=Cuenta_cliente|disabled=true
 Moneda+|radio|name=Moneda|values=CRC->Colón Costarricense,USD->Dolar|default=CRC|datatype=string|disabled=true
 Monto de ejecución/liberación de la garantía+|decimal(18,3)|name=Execute_release_amount|disabled=true
 Número de comprobante de la transacción|texto(25)|name=Transaction_num
 Fecha y hora de la fecha en que se hace efectiva la ejecución o liberación de la garantía+|fecha|name=Date_time|default=today
 Descripción o comentario de la ejecución/liberación de la Garantía|nota(2000)|name=Execute_release_contents|filas=4|column=6 
 Notificar|button|name=btnNotify|class=btn-on-primary';
 
 UPDATE VISUALIZATIONS SET ID=9103, "STATEMENT"='SELECT ID, INSTITUTION_IDENTIFIER, SUPPLIER_IDENTIFIER, GUARANTEE_IDENTIFIER, GUARANTEE_NAME, INSTITUCION_NOTICE_NUMBER, NOTICE_NUMBER, CUENTA_CLIENTE, GUARANTEE_CHARGE_PERSON_NAME, GUARANTEE_CHARGE_PERSON_EMAIL, GUARANTEE_TELEPHONE_NUMBER, GUARANTEE_POSTAL_CODE, GUARANTEE_ADDRESS_LINE, GUARANTEE_NUMBER, GUARANTEE_SEQUENCENUMBER, GUARANTEE_TYPE_CODE, GUARANTEE_PAYMENT_CODE, GUARANTEE_AMOUNT, MONEDA, ISSUE_DATE, VALID_PERIOD_DATE, TIPO_DE_MODIFICATION, GUARANTEE_CONTENTS, CONFIRMATION, MSG_ERR, UPDATEUSERCODE, UPDATEDATE, SUPPLIER_NAME, EX_METODO, EX_CODIGO_PROCESO, EX_FECHA_PROCESO FROM ELECTRONICWARRANTY P
WHERE P.Guarantee_sequencenumber = (SELECT max(Guarantee_sequencenumber) FROM ElectronicWarranty M WHERE M.Guarantee_number = P.Guarantee_number) ORDER BY UPDATEDATE DESC', SPECIFICATION='{
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
				"field": "EX_METODO",
				"title": "Estado",
				"sortable": true,
				"halign": "center",
				"align": "center",
				"formatter": "app.Form_Ext_SICOP.EstadoFormatter",
				"visible": true
			},
			{
				"field": "EX_CODIGO_PROCESO",
				"title": "Código de proceso",
				"sortable": true,
				"halign": "center",
				"align": "left",
				"formatter": "app.ui.StringFormatter",
				"visible": false
			},
            {
                "field": "EX_FECHA_PROCESO",
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
				"sortable": true,
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
				"formatter": "app.ui.CurrencyAmountFormatter",
				"style": "function (value, row, index) { return { css: { ''white-space'': ''nowrap'', ''vertical-align'': ''top''}}}"
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
				"title": "Tipo de cambio",
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
}';