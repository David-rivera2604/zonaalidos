CREATE TABLE ELECTRONICWARRANTY 
   (	ID NUMBER(9,0), 
	INSTITUTION_IDENTIFIER VARCHAR2(10), 
	SUPPLIER_IDENTIFIER VARCHAR2(12), 
	GUARANTEE_IDENTIFIER VARCHAR2(10), 
	GUARANTEE_NAME VARCHAR2(200), 
	INSTITUCION_NOTICE_NUMBER VARCHAR2(12), 
	NOTICE_NUMBER VARCHAR2(11), 
	CUENTA_CLIENTE VARCHAR2(20), 
	GUARANTEE_CHARGE_PERSON_NAME VARCHAR2(200), 
	GUARANTEE_CHARGE_PERSON_EMAIL VARCHAR2(50), 
	GUARANTEE_TELEPHONE_NUMBER VARCHAR2(16), 
	GUARANTEE_POSTAL_CODE VARCHAR2(5), 
	GUARANTEE_ADDRESS_LINE VARCHAR2(200), 
	GUARANTEE_NUMBER VARCHAR2(14), 
	GUARANTEE_SEQUENCENUMBER VARCHAR2(2), 
	GUARANTEE_TYPE_CODE VARCHAR2(2), 
	GUARANTEE_PAYMENT_CODE VARCHAR2(2), 
	GUARANTEE_AMOUNT NUMBER(18,3), 
	MONEDA VARCHAR2(3), 
	ISSUE_DATE DATE, 
	VALID_PERIOD_DATE DATE, 
	TIPO_DE_MODIFICATION VARCHAR2(2), 
	GUARANTEE_CONTENTS VARCHAR2(200), 
	CONFIRMATION VARCHAR2(2), 
	MSG_ERR VARCHAR2(200), 
	UPDATEUSERCODE NUMBER(9,0), 
	UPDATEDATE DATE, 
	 PRIMARY KEY (ID)
	 );


INSERT INTO RESTENDPOINTS (ID,"PATH","SEQUENCE",VERB,SUMMARY,DESCRIPTION,STATEMENTTYPE,DATASOURCE,"STATEMENT",ONERECORD,"SOURCE",ALIAS,AUTHORIZATIONREQUIRED,ROLES,CONTROLLERNAME,APPNAME,TRACED,PRECONDITION,VALIDATIONS,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE) VALUES (40,'ElectronicWarranty',1,'POST','Recupera el próximo id disponible para la tabla ElectronicWarranty',NULL,'SELECT',5,'SELECT NVL(MAX(ID),0)+1 AS NextId FROM ElectronicWarranty',1,'ElectronicWarranty','Next',0,NULL,NULL,NULL,0,NULL,NULL,1,0,1821,TIMESTAMP'2024-04-29 19:40:55');
INSERT INTO RESTENDPOINTS (ID,"PATH","SEQUENCE",VERB,SUMMARY,DESCRIPTION,STATEMENTTYPE,DATASOURCE,"STATEMENT",ONERECORD,"SOURCE",ALIAS,AUTHORIZATIONREQUIRED,ROLES,CONTROLLERNAME,APPNAME,TRACED,PRECONDITION,VALIDATIONS,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE) VALUES (41,'ElectronicWarranty',2,'POST','Crea un registro de ElectronicWarranty',NULL,'INSERT',5,'INSERT INTO ElectronicWarranty (ID, Institution_identifier, Supplier_identifier, Guarantee_identifier, Guarantee_name, Institucion_notice_number, Notice_number, Cuenta_cliente, Guarantee_charge_person_name, Guarantee_charge_person_email, Guarantee_telephone_number, Guarantee_postal_code, Guarantee_address_line, Guarantee_number, Guarantee_sequencenumber, Guarantee_type_code, Guarantee_payment_code, Guarantee_amount, Moneda, Issue_date, Valid_period_date, Tipo_de_modification, Guarantee_contents, Confirmation, Msg_err, UpdateUserCode, UpdateDate) VALUES  ({dependency.Next.NEXTID:NUMBER.9:Required}, {Institution_identifier:VARCHAR2.10}, {Supplier_identifier:VARCHAR2.12}, {Guarantee_identifier:VARCHAR2.10}, {Guarantee_name:VARCHAR2.200}, {Institucion_notice_number:VARCHAR2.12}, {Notice_number:VARCHAR2.11}, {Cuenta_cliente:VARCHAR2.20}, {Guarantee_charge_person_name:VARCHAR2.200}, {Guarantee_charge_person_email:VARCHAR2.50}, {Guarantee_telephone_number:VARCHAR2.16}, {Guarantee_postal_code:VARCHAR2.5}, {Guarantee_address_line:VARCHAR2.200}, {Guarantee_number:VARCHAR2.14}, {Guarantee_sequencenumber:VARCHAR2.2}, {Guarantee_type_code:VARCHAR2.2}, {Guarantee_payment_code:VARCHAR2.2}, {Guarantee_amount:NUMBER.18}, {Moneda:VARCHAR2.3}, {Issue_date:DATE.0}, {Valid_period_date:DATE.0}, {Tipo_de_modification:VARCHAR2.2}, {Guarantee_contents:VARCHAR2.200}, {Confirmation:VARCHAR2.2}, {Msg_err:VARCHAR2.200}, {App.UserId}, {Const.Date.Now})',0,'ElectronicWarranty','Create',0,NULL,NULL,NULL,0,NULL,NULL,1,0,1821,TIMESTAMP'2024-04-30 01:40:55');
INSERT INTO RESTENDPOINTS (ID,"PATH","SEQUENCE",VERB,SUMMARY,DESCRIPTION,STATEMENTTYPE,DATASOURCE,"STATEMENT",ONERECORD,"SOURCE",ALIAS,AUTHORIZATIONREQUIRED,ROLES,CONTROLLERNAME,APPNAME,TRACED,PRECONDITION,VALIDATIONS,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE) VALUES (39,'ElectronicWarranty/{id}',1,'PUT','Actualiza un registro de la tabla ElectronicWarranty/{id} por medio de su clave',NULL,'UPDATE',5,'UPDATE ElectronicWarranty SET Confirmation={Confirmation:VARCHAR2.2}, Msg_err={Msg_err:VARCHAR2.200}, UpdateUserCode={App.UserId}, UpdateDate={Const.Date.Now} WHERE ID={ID:NUMBER.9:Required}',0,'ElectronicWarranty',NULL,0,NULL,NULL,NULL,0,NULL,NULL,1,0,1821,TIMESTAMP'2024-04-29 19:40:55');
INSERT INTO RESTENDPOINTS (ID,"PATH","SEQUENCE",VERB,SUMMARY,DESCRIPTION,STATEMENTTYPE,DATASOURCE,"STATEMENT",ONERECORD,"SOURCE",ALIAS,AUTHORIZATIONREQUIRED,ROLES,CONTROLLERNAME,APPNAME,TRACED,PRECONDITION,VALIDATIONS,RECORDSTATUS,COMPANYID,UPDATEUSERCODE,UPDATEDATE) VALUES (42,'ElectronicWarranty/{id}',1,'GET','Recupera un registro de la tabla ElectronicWarranty por medio de su clave',NULL,'SELECT',5,'SELECT ID "ID", Institution_identifier "Institution_identifier", Supplier_identifier "Supplier_identifier", Guarantee_identifier "Guarantee_identifier", Guarantee_name "Guarantee_name", Institucion_notice_number "Institucion_notice_number", Notice_number "Notice_number", Cuenta_cliente "Cuenta_cliente", Guarantee_charge_person_name "Guarantee_charge_person_name", Guarantee_charge_person_email "Guarantee_charge_person_email", Guarantee_telephone_number "Guarantee_telephone_number", Guarantee_postal_code "Guarantee_postal_code", Guarantee_address_line "Guarantee_address_line", Guarantee_number "Guarantee_number", Guarantee_sequencenumber "Guarantee_sequencenumber", Guarantee_type_code "Guarantee_type_code", Guarantee_payment_code "Guarantee_payment_code", Guarantee_amount "Guarantee_amount", Moneda "Moneda", Issue_date "Issue_date", Valid_period_date "Valid_period_date", Tipo_de_modification "Tipo_de_modification", Guarantee_contents "Guarantee_contents", Confirmation "Confirmation", Msg_err "Msg_err", UpdateUserCode "UpdateUserCode", UpdateDate "UpdateDate" FROM ElectronicWarranty WHERE ID={ID:NUMBER.9:Required}',1,'ElectronicWarranty',NULL,0,NULL,NULL,NULL,0,NULL,NULL,1,0,1821,TIMESTAMP'2024-04-29 19:40:55');
