ALTER TABLE ELECTRONICWARRANTY ADD SUPPLIER_NAME VARCHAR2(200) NULL;
ALTER TABLE ELECTRONICWARRANTY ADD METODO VARCHAR2(1) NULL;
ALTER TABLE ELECTRONICWARRANTY ADD CODIGO_PROCESO VARCHAR2(16) NULL;
ALTER TABLE ELECTRONICWARRANTY ADD FECHA_PROCESO DATE NULL;

DELETE RESTENDPOINTS WHERE ID IN (45,46);

INSERT INTO RESTENDPOINTS (ID,"SEQUENCE","PATH",VERB,SUMMARY,DESCRIPTION,STATEMENTTYPE,DATASOURCE,"STATEMENT",ONERECORD,"SOURCE",ALIAS,AUTHORIZATIONREQUIRED,ROLES,CONTROLLERNAME,APPNAME,TRACED,PRECONDITION,VALIDATIONS,PRECALL,POSTCALL,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE) VALUES (45,1,'ElectronicWarranty/Guarantee','GET','Recupera una garantía electrónica por medio de número de garantía',NULL,'SELECT',1,'SELECT ID "ID", Institution_identifier "Institution_identifier", Supplier_identifier "Supplier_identifier", Guarantee_identifier "Guarantee_identifier", Guarantee_name "Guarantee_name", Institucion_notice_number "Institucion_notice_number", Notice_number "Notice_number", Cuenta_cliente "Cuenta_cliente", Guarantee_charge_person_name "Guarantee_charge_person_name", Guarantee_charge_person_email "Guarantee_charge_person_email", Guarantee_telephone_number "Guarantee_telephone_number", Guarantee_postal_code "Guarantee_postal_code", Guarantee_address_line "Guarantee_address_line", Guarantee_number "Guarantee_number", Guarantee_sequencenumber "Guarantee_sequencenumber", Guarantee_type_code "Guarantee_type_code", Guarantee_payment_code "Guarantee_payment_code", Guarantee_amount "Guarantee_amount", Moneda "Moneda", Issue_date "Issue_date", Valid_period_date "Valid_period_date", Tipo_de_modification "Tipo_de_modification", Guarantee_contents "Guarantee_contents", Confirmation "Confirmation", Msg_err "Msg_err", UpdateUserCode "UpdateUserCode", UpdateDate "UpdateDate", SUPPLIER_NAME "Supplier_Name", METODO "Metodo", CODIGO_PROCESO "Codigo_Proceso", FECHA_PROCESO "Fecha_Proceso" FROM ElectronicWarranty P WHERE Guarantee_number={code:VARCHAR2.14:Required} AND P.Guarantee_sequencenumber = (SELECT max(Guarantee_sequencenumber) FROM ElectronicWarranty M WHERE M.Guarantee_number = P.Guarantee_number)',1,'ElectronicWarranty','Guarantee',0,NULL,NULL,NULL,0,NULL,NULL,NULL,NULL,1,0,6329,TIMESTAMP'2024-05-13 00:00:00');
INSERT INTO RESTENDPOINTS (ID,"SEQUENCE","PATH",VERB,SUMMARY,DESCRIPTION,STATEMENTTYPE,DATASOURCE,"STATEMENT",ONERECORD,"SOURCE",ALIAS,AUTHORIZATIONREQUIRED,ROLES,CONTROLLERNAME,APPNAME,TRACED,PRECONDITION,VALIDATIONS,PRECALL,POSTCALL,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE) VALUES (46,2,'XElectronicWarranty/Guarantee','GET','Recupera una garantía electrónica por medio de número de garantía',NULL,'SELECT',1,'SELECT Guarantee_sequencenumber "Guarantee_sequencenumber", Guarantee_amount "Guarantee_amount", Moneda "Moneda",  Valid_period_date "Valid_period_date", DECODE(Tipo_de_modification, ''01'',''Ampliación de plazo'',''02'',''Ampliación de monto'',''03'',''Prórroga de plazo y monto'') "Tipo_de_modificationDesc", UpdateDate "UpdateDate"
FROM ElectronicWarranty P WHERE Guarantee_number={code:VARCHAR2.14:Required} ORDER BY Guarantee_sequencenumber DESC',0,'ElectronicWarranty','History',0,NULL,NULL,NULL,0,NULL,NULL,NULL,NULL,1,0,6329,TIMESTAMP'2024-05-13 00:00:00');


DELETE VISUALIZATIONS WHERE ID IN (9103, 9104);

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
				"align": "center",
				"formatter": "function (value, row, index, field) { return ''<span class=columnBtn><button name=\"editar\" type=\"button\" class=\"btn btn-sm btn-white event\" title=\"Permite editar la garantía\"><i class=\"fa fa-pencil\"></i></button><button type=\"button\" name=\"liberar\" class=\"btn btn-sm btn-white event\" title=\"Permite liberar la garantía\"><i class=\"fa fa-asterisk\"></i></button></span>'' ;}",
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
				"format": "<a href=''../viewer/Form?id=NotificarGarantia&code={GUARANTEE_NUMBER}'' title=''Ver #{GUARANTEE_NUMBER}''>{GUARANTEE_NUMBER} - {GUARANTEE_SEQUENCENUMBER}</a>"
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
				"formatter": "app')||TO_CLOB('.ui.LookUpListFormatter",
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
				"title": "Teléfono del funcio')||TO_CLOB('nario",
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
		')||TO_CLOB('		"formatter": "app.ui.StringFormatter"
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
}'),NULL,NULL,NULL,'Research',NULL,1,6329,TIMESTAMP'2024-05-13 00:00:00');
INSERT INTO VISUALIZATIONS (DIALOG,"KEY",ID,CAPTION,JAVASCRIPTTOINCLUDE,"SEQUENCE",COMPANYID,ENTITYTYPE,"TYPE",DESCRIPTION,STATEMENTTYPE,"STATEMENT",SPECIFICATION,ICON,ICONCLASS,VALUEFORMAT,CONNECTIONNAME,STATEMENTEXTEND,RECORDSTATUS,UPDATEUSERCODE,UPDATEDATE) VALUES (NULL,NULL,9104,'Garantías electrónicas - Historia','Form.Ext.SICOP.js',1,1,NULL,1,NULL,1,'SELECT Guarantee_sequencenumber "Guarantee_sequencenumber", Guarantee_amount "Guarantee_amount", Moneda "Moneda",  Valid_period_date "Valid_period_date", DECODE(Tipo_de_modification, ''01'',''Ampliación de plazo'',''02'',''Ampliación de monto'',''03'',''Prórroga de plazo y monto'', '''') "Tipo_de_modificationDesc", UpdateDate "UpdateDate"
FROM ElectronicWarranty P WHERE Guarantee_number={code:varchar} ORDER BY Guarantee_sequencenumber DESC',TO_CLOB('{
    "title": "Historia",
    "table": {
  		"pagination": true,
		"search": false,
		"showToggle": false,
		"showRefresh": false,
		"showColumns": false,
		"showExport": false,
        "columns": [
            {
                "field": "Guarantee_sequencenumber",
                "title": "Número de secuencia",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "Guarantee_amount",
                "title": "Monto de la garantía",
                "sortable": true,
                "halign": "center",
                "align": "right",
                "formatter": "app.ui.CurrencyAmountFormatter"
            },
            {
                "field": "Valid_period_date",
                "title": "Fecha de Vencimiento",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateFormatter"
            },
            {
                "field": "Tipo_de_modificationDesc",
                "title": "Tipo de modificación",
                "sortable": true,
                "halign": "center",
                "align": "left",
                "formatter": "app.ui.StringFormatter"
            },
            {
                "field": "UpdateDate",
                "title": "Fecha y hora de recepción de garantía",
                "sortable": true,
                "halign": "center",
                "align": "center",
                "formatter": "app.ui.DateAndTimeFormatter"
            }
        ]        
    }
}'),NULL,NULL,NULL,'Research',NULL,1,6329,TIMESTAMP'2024-05-13 00:00:00');

