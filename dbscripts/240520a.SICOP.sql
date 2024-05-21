ALTER TABLE ALIADOS.ELECTRONICWARRANTY ADD EX_AMOUNT NUMBER(18,3) NULL;
ALTER TABLE ALIADOS.ELECTRONICWARRANTY ADD EX_CONTENTS VARCHAR2(200) NULL;
ALTER TABLE ALIADOS.ELECTRONICWARRANTY ADD EX_CUENTA_CLIENTE VARCHAR2(20) NULL;
ALTER TABLE ALIADOS.ELECTRONICWARRANTY ADD EX_METODO VARCHAR2(1) NULL;
ALTER TABLE ALIADOS.ELECTRONICWARRANTY ADD EX_CODIGO_PROCESO VARCHAR2(16) NULL;
ALTER TABLE ALIADOS.ELECTRONICWARRANTY ADD EX_FECHA_PROCESO DATE NULL;
ALTER TABLE ALIADOS.ELECTRONICWARRANTY ADD RE_TRANSACTION_NUM VARCHAR2(25) NULL;
ALTER TABLE ALIADOS.ELECTRONICWARRANTY ADD RE_CONTENTS VARCHAR2(200) NULL;
ALTER TABLE ALIADOS.ELECTRONICWARRANTY ADD RE_FECHA_PROCESO DATE NULL;
ALTER TABLE ALIADOS.ELECTRONICWARRANTY DROP COLUMN FECHA_PROCESO;
ALTER TABLE ALIADOS.ELECTRONICWARRANTY DROP COLUMN CODIGO_PROCESO;
ALTER TABLE ALIADOS.ELECTRONICWARRANTY DROP COLUMN METODO;



DELETE FROM VISUALIZATIONS v WHERE id IN (402,403,404,405,406);

INSERT INTO RESTENDPOINTS (ID,"PATH","SEQUENCE",VERB,SUMMARY,DESCRIPTION,STATEMENTTYPE,DATASOURCE,"STATEMENT",ONERECORD,"SOURCE",ALIAS,AUTHORIZATIONREQUIRED,ROLES,CONTROLLERNAME,APPNAME,TRACED,PRECONDITION,VALIDATIONS,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,PRECALL,POSTCALL) VALUES (402,'ElectronicWarranty',1,'POST','Crea una garantía electrónica. Recupera el próximo identificador interno disponible para las garantías electrónicas',NULL,'SELECT',1,'SELECT NVL(MAX(ID),0)+1 AS NextId FROM ElectronicWarranty',1,'ElectronicWarranty','Next',0,NULL,NULL,NULL,0,NULL,NULL,1,0,1821,TIMESTAMP'2024-04-30 10:42:33',NULL,NULL);
INSERT INTO RESTENDPOINTS (ID,"PATH","SEQUENCE",VERB,SUMMARY,DESCRIPTION,STATEMENTTYPE,DATASOURCE,"STATEMENT",ONERECORD,"SOURCE",ALIAS,AUTHORIZATIONREQUIRED,ROLES,CONTROLLERNAME,APPNAME,TRACED,PRECONDITION,VALIDATIONS,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,PRECALL,POSTCALL) VALUES (403,'ElectronicWarranty',2,'POST','Crea una garantía electrónica',NULL,'INSERT',1,'INSERT INTO ElectronicWarranty (ID, Institution_identifier, Supplier_identifier, Guarantee_identifier, Guarantee_name, Institucion_notice_number, Notice_number, Cuenta_cliente, Guarantee_charge_person_name, Guarantee_charge_person_email, Guarantee_telephone_number, Guarantee_postal_code, Guarantee_address_line, Guarantee_number, Guarantee_sequencenumber, Guarantee_type_code, Guarantee_payment_code, Guarantee_amount, Moneda, Issue_date, Valid_period_date, Tipo_de_modification, Guarantee_contents, Confirmation, Msg_err, UpdateUserCode, UpdateDate, Supplier_Name) VALUES  ({dependency.Next.NEXTID:NUMBER.9:Required}, {Institution_identifier:VARCHAR2.10}, {Supplier_identifier:VARCHAR2.12}, {Guarantee_identifier:VARCHAR2.10}, {Guarantee_name:VARCHAR2.200}, {Institucion_notice_number:VARCHAR2.24}, {Notice_number:VARCHAR2.11}, {Cuenta_cliente:VARCHAR2.20}, {Guarantee_charge_person_name:VARCHAR2.200}, {Guarantee_charge_person_email:VARCHAR2.50}, {Guarantee_telephone_number:VARCHAR2.16}, {Guarantee_postal_code:VARCHAR2.5}, {Guarantee_address_line:VARCHAR2.200}, {Guarantee_number:VARCHAR2.14}, {Guarantee_sequencenumber:VARCHAR2.2}, {Guarantee_type_code:VARCHAR2.2}, {Guarantee_payment_code:VARCHAR2.2}, {Guarantee_amount:NUMBER.18}, {Moneda:VARCHAR2.3}, {Issue_date:DATE.0}, {Valid_period_date:DATE.0}, {Tipo_de_modification:VARCHAR2.2}, {Guarantee_contents:VARCHAR2.200}, {Confirmation:VARCHAR2.2}, {Msg_err:VARCHAR2.200}, {App.UserId}, {Const.Date.Now}, {Supplier_Name:VARCHAR2.200})',0,'ElectronicWarranty','CreateTrace',0,NULL,NULL,NULL,0,NULL,NULL,1,0,1821,TIMESTAMP'2024-04-30 10:42:33',NULL,NULL);
INSERT INTO RESTENDPOINTS (ID,"PATH","SEQUENCE",VERB,SUMMARY,DESCRIPTION,STATEMENTTYPE,DATASOURCE,"STATEMENT",ONERECORD,"SOURCE",ALIAS,AUTHORIZATIONREQUIRED,ROLES,CONTROLLERNAME,APPNAME,TRACED,PRECONDITION,VALIDATIONS,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,PRECALL,POSTCALL) VALUES (404,'ElectronicWarranty/Notify/{id}',1,'PUT','Actualiza una garantía electrónica por medio de su identificador interna',NULL,'UPDATE',1,'UPDATE ElectronicWarranty SET Confirmation={Confirmation:VARCHAR2.2}, Msg_err={Msg_err:VARCHAR2.200}, UpdateUserCode={App.UserId}, UpdateDate={Const.Date.Now} WHERE ID={ID:NUMBER.9:Required}',0,'ElectronicWarranty',NULL,0,NULL,NULL,NULL,0,NULL,NULL,1,0,1821,TIMESTAMP'2024-04-30 10:42:33',NULL,NULL);
INSERT INTO RESTENDPOINTS (ID,"PATH","SEQUENCE",VERB,SUMMARY,DESCRIPTION,STATEMENTTYPE,DATASOURCE,"STATEMENT",ONERECORD,"SOURCE",ALIAS,AUTHORIZATIONREQUIRED,ROLES,CONTROLLERNAME,APPNAME,TRACED,PRECONDITION,VALIDATIONS,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,PRECALL,POSTCALL) VALUES (405,'ElectronicWarranty/Guarantee',1,'GET','Recupera una garantía electrónica por medio de número de garantía',NULL,'SELECT',1,'SELECT ID "ID", Institution_identifier "Institution_identifier", Supplier_identifier "Supplier_identifier", Guarantee_identifier "Guarantee_identifier", Guarantee_name "Guarantee_name", Institucion_notice_number "Institucion_notice_number", Notice_number "Notice_number", Cuenta_cliente "Cuenta_cliente", Guarantee_charge_person_name "Guarantee_charge_person_name", Guarantee_charge_person_email "Guarantee_charge_person_email", Guarantee_telephone_number "Guarantee_telephone_number", Guarantee_postal_code "Guarantee_postal_code", Guarantee_address_line "Guarantee_address_line", Guarantee_number "Guarantee_number", Guarantee_sequencenumber "Guarantee_sequencenumber", Guarantee_type_code "Guarantee_type_code", Guarantee_payment_code "Guarantee_payment_code", Guarantee_amount "Guarantee_amount", Moneda "Moneda", Issue_date "Issue_date", Valid_period_date "Valid_period_date", Tipo_de_modification "Tipo_de_modification", Guarantee_contents "Guarantee_contents", Confirmation "Confirmation", Msg_err "Msg_err", UpdateUserCode "UpdateUserCode", UpdateDate "UpdateDate", SUPPLIER_NAME "Supplier_name", EX_METODO "Ex_Metodo", EX_CODIGO_PROCESO "Ex_Codigo_Proceso", EX_FECHA_PROCESO "Ex_Fecha_Proceso", EX_AMOUNT "Ex_Amount", EX_CONTENTS "Ex_Contents", EX_CUENTA_CLIENTE "Ex_Cuenta_Cliente" FROM ElectronicWarranty P WHERE Guarantee_number={code:VARCHAR2.14:Required} AND P.Guarantee_sequencenumber = (SELECT max(Guarantee_sequencenumber) FROM ElectronicWarranty M WHERE M.Guarantee_number = P.Guarantee_number)',1,'ElectronicWarranty','Guarantee',0,NULL,NULL,NULL,0,NULL,NULL,1,0,6329,TIMESTAMP'2024-05-13 00:00:00',NULL,NULL);
INSERT INTO RESTENDPOINTS (ID,"PATH","SEQUENCE",VERB,SUMMARY,DESCRIPTION,STATEMENTTYPE,DATASOURCE,"STATEMENT",ONERECORD,"SOURCE",ALIAS,AUTHORIZATIONREQUIRED,ROLES,CONTROLLERNAME,APPNAME,TRACED,PRECONDITION,VALIDATIONS,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,PRECALL,POSTCALL) VALUES (406,'ElectronicWarranty/Release/{id}',1,'PUT','Actualiza una garantía electrónica por medio de su identificador interna',NULL,'UPDATE',1,'UPDATE ElectronicWarranty SET RE_TRANSACTION_NUM={Transaction_num:VARCHAR2.25}, RE_CONTENTS={Execute_release_contents:VARCHAR2.200}, RE_FECHA_PROCESO={Const.Date.Now}, Confirmation={Confirmation:VARCHAR2.2}, Msg_err={Msg_err:VARCHAR2.200}, UpdateUserCode={App.UserId}, UpdateDate={Const.Date.Now} WHERE ID={ID:NUMBER.9:Required}',0,'ElectronicWarranty',NULL,0,NULL,NULL,NULL,0,NULL,NULL,1,0,1821,TIMESTAMP'2024-04-30 10:42:33',NULL,NULL);


DELETE FROM VISUALIZATIONS v WHERE id IN (9100,9101,9102,9103, 9104);

INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (9100,1,9,'Información del proveedor','Form',NULL,NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 00:00:00',NULL,NULL,NULL,'Información del proveedor|título
Datos para la busqueda|zona|4
 Identificación del proveedor a buscar+|texto(12)|name=SUPPLIER_ID
 Buscar|button|name=btnSearch;class=btn-on-primary
Datos del proveedor|zona|4
 Nombre|texto|name=SUPPLIER_NM;disabled=true
 Dirección|texto|name=ADDR;disabled=true
 Código postal|texto|name=POST_NO;disabled=true
 Página web|texto|name=HPAGE;disabled=true
Datos de contacto|zona|4 
 Número de teléfono|texto|name=TEL_NO;disabled=true
 Número de fax|texto|name=FAX_NO;disabled=true
 Correo electrónico|texto|name=EMAIL;disabled=true',NULL,'InformacionProveedor','Form.Ext.SICOP.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (9101,1,9,'Notificar a SICOP de la recepción de garantías electrónicas de participación y cumplimiento','Form',NULL,NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 00:00:00',NULL,NULL,NULL,'Notificar a SICOP de la recepción de garantías electrónicas de participación y cumplimiento|título
Datos de la garantía electrónica|zona|3
 Número+|texto(14)|name=Guarantee_number;title=Cedula jurídica institución que promueve el proceso de contratación
 Secuencia+|texto(2)|name=Guarantee_sequencenumber;disabled=true
 Tipo|radio|name=Guarantee_type_code;values=BG->Participación,CG->Cumplimiento,PG->Colateral;datatype=string
 Forma de pago|lista|name=Guarantee_payment_code;datatype=string;values=01->Efectivo,02->Certificados depósitos,03->Cheque certificado,05->Bono del estado,06->Cheque gerencia,07->Garantía Electrónica;disabled=true
 Número de cuenta|texto(20)|name=Cuenta_cliente;title=Solo en caso de ser garantías en efectivo;visible=ctrol.Guarantee_payment_code.eq.''01'' 
 Moneda+|radio|name=Moneda;values=CRC->Colón Costarricense,USD->Dolar;default=CRC;datatype=string
 Monto total+|decimal(18,3)|name=Guarantee_amount
 Tipo de modificación+|radio|name=Tipo_de_modification;values=01->Ampliación de plazo,02->Ampliación de monto,03->Prórroga de plazo y monto;datatype=string;hidden=true 
Datos de la entidad garante|zona|3  
 Cédula jurídica+|texto(10)|name=Guarantee_identifier;disabled=true
 Entidad garante|texto(200)|name=Guarantee_name;disabled=true
 Nombre del funcionario|texto(200)|name=Guarantee_charge_person_name;column=6
 Correo electrónico|Correo(50)|name=Guarantee_charge_person_email
 Teléfono|Teléfono(16)|name=Guarantee_telephone_number;modo=simple
 Código postal|texto(5)|name=Guarantee_postal_code
 Dirección|nota(200)|name=Guarantee_address_line;filas=2;column=6 
Datos generales|zona|3
 Número de procedimiento+|texto(24)|name=Institucion_notice_number
 Número del pliego de condiciones+|texto(11)|name=Notice_number;title=Número de cartel en SICOP
 Cédula del proveedor+|texto(12)|name=Supplier_identifier;title=Garantía por cuenta de
 Nombre del proveedor|texto(200)|name=Supplier_name;disabled=true
 Cédula de la institución+|texto(10)|name=Institution_identifier;title=Garantía a favor de
 Fecha de inicio de validez+|fechainicio|name=Issue_date;default=today;title=Fecha de inicio de validez de la garantía
 Fecha de vencimiento+|fechafin|name=Valid_period_date;title=Fecha de vencimiento de la garantía
 Comentarios de la garantía|nota(2000)|name=Guarantee_contents;filas=4;column=6 
 Notificar|button|name=btnNotify;class=btn-on-primary',NULL,'NotificarGarantia','Form.Ext.SICOP.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (9102,1,9,'Notificar a SICOP de la recepción de garantías electrónicas de participación y cumplimiento','Form',NULL,NULL,NULL,NULL,NULL,1,1,777,TIMESTAMP'2023-02-27 00:00:00',NULL,NULL,NULL,'Notificar a SICOP sobre la ejecución de los procesos de liberación y ejecución de las Garantías Electrónicas por parte de la Institución promotora del proceso de Contratación Administrativa|título
Datos generales|zona|3
 Número de garantía electrónica generado por la entidad garante+|texto(14)|name=Guarantee_number;disabled=true
 Secuencia de la garantía electrónica+|texto(2)|name=Guarantee_sequencenumber;disabled=true
 Cédula jurídica de la entidad garante|texto(10)|name=Guarantee_identifier;disabled=true
 Nombre de la entidad garante|texto(200)|name=Guarantee_name;disabled=true
 Número de cuenta en la cual se depositó el monto solicitado|texto(20)|name=Cuenta_cliente;disabled=true
 Número de comprobante de la transacción|texto(25)|name=Transaction_num
 Moneda+|radio|name=Moneda;values=CRC->Colón Costarricense,USD->Dolar;default=CRC;datatype=string;disabled=true
 Monto de ejecución/liberación de la garantía+|decimal(18,3)|name=Execute_release_amount;disabled=true
 Fecha y hora de la fecha en que se hace efectiva la ejecución o liberación de la garantía+|fecha|name=Date_time;default=today
 Descripción o comentario de la ejecución/liberación de la Garantía|nota(2000)|name=Execute_release_contents;filas=4;column=6 
 Notificar|button|name=btnNotify;class=btn-on-primary',NULL,'NotificarLiberacion','Form.Ext.SICOP.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (9103,1,1,'Garantías electrónicas',NULL,'SELECT ID, INSTITUTION_IDENTIFIER, SUPPLIER_IDENTIFIER, GUARANTEE_IDENTIFIER, GUARANTEE_NAME, INSTITUCION_NOTICE_NUMBER, NOTICE_NUMBER, CUENTA_CLIENTE, GUARANTEE_CHARGE_PERSON_NAME, GUARANTEE_CHARGE_PERSON_EMAIL, GUARANTEE_TELEPHONE_NUMBER, GUARANTEE_POSTAL_CODE, GUARANTEE_ADDRESS_LINE, GUARANTEE_NUMBER, GUARANTEE_SEQUENCENUMBER, GUARANTEE_TYPE_CODE, GUARANTEE_PAYMENT_CODE, GUARANTEE_AMOUNT, MONEDA, ISSUE_DATE, VALID_PERIOD_DATE, TIPO_DE_MODIFICATION, GUARANTEE_CONTENTS, CONFIRMATION, MSG_ERR, UPDATEUSERCODE, UPDATEDATE, SUPPLIER_NAME, EX_METODO, EX_CODIGO_PROCESO, EX_FECHA_PROCESO FROM ELECTRONICWARRANTY P
WHERE P.Guarantee_sequencenumber = (SELECT max(Guarantee_sequencenumber) FROM ElectronicWarranty M WHERE M.Guarantee_number = P.Guarantee_number) ORDER BY UPDATEDATE DESC',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'2024-05-13 00:00:00',TO_CLOB('{
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
				"title": "Fecha de inic')||TO_CLOB('io",
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
				"title": "Nombre ')||TO_CLOB('del funcionario",

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
				"field": "TIPO_DE_MO')||TO_CLOB('DIFICATION",
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
}'),'Research',1,NULL,NULL,NULL,'Form.Ext.SICOP.js');
INSERT INTO VISUALIZATIONS (ID,"SEQUENCE","TYPE",CAPTION,DESCRIPTION,"STATEMENT",ICON,ICONCLASS,VALUEFORMAT,ENTITYTYPE,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE,SPECIFICATION,CONNECTIONNAME,STATEMENTTYPE,DIALOG,STATEMENTEXTEND,"KEY",JAVASCRIPTTOINCLUDE) VALUES (9104,1,1,'Garantías electrónicas - Historia',NULL,'SELECT Guarantee_sequencenumber "Guarantee_sequencenumber", Guarantee_amount "Guarantee_amount", Moneda "Moneda",  Valid_period_date "Valid_period_date", DECODE(Tipo_de_modification, ''01'',''Ampliación de plazo'',''02'',''Ampliación de monto'',''03'',''Prórroga de plazo y monto'', '''') "Tipo_de_modificationDesc", UpdateDate "UpdateDate"
FROM ElectronicWarranty P WHERE Guarantee_number={code:varchar} ORDER BY Guarantee_sequencenumber DESC',NULL,NULL,NULL,NULL,1,1,6329,TIMESTAMP'2024-05-13 00:00:00',TO_CLOB('{
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
}'),'Research',1,NULL,NULL,NULL,'Form.Ext.SICOP.js');
