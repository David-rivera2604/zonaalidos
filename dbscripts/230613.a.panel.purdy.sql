CREATE TABLE PURDYPANELEVENTO 
   (	ID NUMBER(9,0), 
	ASIGES VARCHAR2(40), 
	FECHADELEVENTO DATE, 
	ANALISTARECLAMOS NUMBER(9,0), 
	TIPODEINDEMNIZACION NUMBER(5,0), 
	MOTIVONOPROCEDE NUMBER(5,0), 
	DETALLENOPROCEDE VARCHAR2(200), 
	DETALLESINIESTRO VARCHAR2(200), 
	TIPODECOBERTURA NUMBER(5,0), 
	CATEGORIADESINIESTRO NUMBER(5,0), 
	POSIBLESUBROGACION NUMBER(1,0), 
	FECHAPOSIBLESUBROGACION DATE, 
	ENVIADOAINVESTIGACION NUMBER(1,0), 
	FECHAENVIADOAINVESTIGACION DATE, 
	ENVIADOAACOMPANAMIENTOLEGAL NUMBER(1,0), 
	FECHAENVIADOACOMPALEGAL DATE, 
	INFRASEGURO NUMBER(1,0), 
	AUTORIZACIONDEUSOPOLIZA NUMBER(1,0), 
	FECHAAUTORIZACIONDEUSOPOLIZA DATE, 
	NOMBREDELCHOFER VARCHAR2(100), 
	TELEFONODELCHOFER VARCHAR2(9), 	
	UPDATEUSERCODE NUMBER(9,0), 
	UPDATEDATE DATE, 
	 PRIMARY KEY (ID))  ;

CREATE TABLE PURDYPANELDANO 
   (	ID NUMBER(9,0), 
	ASIGES VARCHAR2(40), 
	TALLER NUMBER(5,0), 
	FECHAENVIODELAVALUO DATE, 
	PREREPUESTOS NUMBER(18,0), 
	PREREPUESTOSIVA NUMBER(18,0), 
	PREREPUESTOSTOTAL NUMBER(18,0), 
	PREMANO NUMBER(18,0), 
	PREMANOIVA NUMBER(18,0), 
	PREMANOTOTAL NUMBER(18,0), 
	PREPERDIDA NUMBER(18,0), 
	AUTORIZACIONDEUSOPOLIZA NUMBER(1,0), 
	FECHAAUTORIZACIONDEUSOPOLIZA DATE, 
	OT NUMBER(6,0), 
	ASESORTALLER VARCHAR2(100), 
	EXPEDIENTE VARCHAR2(20), 
	ANALISTADEDANOS NUMBER(9,0), 
	DEPRECIACIONYEXCLUSIONES NUMBER(18,0), 
	PERDREPUESTO NUMBER(18,0), 
	PERDREPUESTOIVA NUMBER(18,0), 
	PERDREPUESTOTOTAL NUMBER(18,0), 
	PERDMANO NUMBER(18,0), 
	PERDMANOIVA NUMBER(18,0), 
	PERDMANOTOTAL NUMBER(18,0), 
	PERDIDA NUMBER(18,0), 
	SEVERIDADDELSINIESTRO NUMBER(5,0), 
	AVALUOAUTORIZADO NUMBER(1,0), 
	FECHAAUTORIZACION DATE, 
	PERDIDATOTAL NUMBER(1,0), 
	TIPODEPERDIDATOTAL NUMBER(5,0), 
	PRESENTADANOOCULTO NUMBER(1,0), 
	FECHASOLICITADO DATE, 
	OBSERVACIONES VARCHAR2(200), 
	DANOOCULTOMONTOREPDANOOCULTO NUMBER(18,0), 
	DANOOCULTOIVA NUMBER(18,0), 
	DANOOCULTOTOTAL NUMBER(18,0), 
	DANOOCULTOMANO NUMBER(18,0), 
	DANOOCULTOMANOIVA NUMBER(18,0), 
	DANOOCULTOMANOTOTAL NUMBER(18,0), 
	OTROSIIOTROSIIDANOCULMANOTOTAL NUMBER(18,0), 
	UPDATEUSERCODE NUMBER(9,0), 
	UPDATEDATE DATE, 
	 PRIMARY KEY (ID)
   ) ;
   
CREATE TABLE PURDYPANELMONTOS 
   (	ID NUMBER(9,0), 
	ASIGES VARCHAR2(40), 
	MONTOINICIALPORINDEMNIZAR NUMBER(18,0), 
	MONTOINICIALPORINDEMNIZARREPUE NUMBER(18,0), 
	MONTOINICIALPORINDEMNIZARMANOD NUMBER(18,0), 
	MONTODANOOCULTOPORINDEMNIZAR NUMBER(18,0), 
	MONTODANOOCULTOPORINDEMNIZARRE NUMBER(18,0), 
	MONTODANOOCULTOPORINDEMNIZARMA NUMBER(18,0), 
	UPDATEUSERCODE NUMBER(9,0), 
	UPDATEDATE DATE, 
	 PRIMARY KEY (ID)   ) ;


CREATE TABLE PURDYPANELBALANCE 
   (	ID NUMBER(9,0), 
	ASIGES VARCHAR2(40), 
	NUMERODESINIESTRO VARCHAR2(20), 
	TIPODEDOCUMENTO NUMBER(5,0), 
	NUMERODEDOCUMENTO VARCHAR2(20), 
	FECHA DATE, 
	RECEPTOR VARCHAR2(100), 
	MONTO NUMBER(18,0), 
	NCREPUESTO NUMBER(18,0), 
	OBSERVACION VARCHAR2(200), 
	UPDATEUSERCODE NUMBER(9,0), 
	UPDATEDATE DATE, 
	 PRIMARY KEY (ID)) ;
	 
	 
CREATE TABLE PURDYPANELRECUPERACION 
   (	ID NUMBER(9,0), 
	ASIGES VARCHAR2(40), 
	NUMERODESINIESTRO VARCHAR2(20), 
	TIPODEDOCUMENTO NUMBER(5,0), 
	NUMERODEDOCUMENTO VARCHAR2(20), 
	FECHARECUPERA DATE, 
	RECEPTOR VARCHAR2(100), 
	MONTORECUPERA NUMBER(18,0), 
	OBSERVACION VARCHAR2(200), 
	UPDATEUSERCODE NUMBER(9,0), 
	UPDATEDATE DATE, 
	 PRIMARY KEY (ID)) ;

CREATE TABLE PURDYPANELDETALLE 
   (	ID NUMBER(9,0), 
	ASIGES VARCHAR2(40), 
	ENVIADOAINVESTIGACION NUMBER(1,0), 
	FECHAENVIADOAINVESTIGACION DATE, 
	REQUISITOSPORPRESENTARPARARECO VARCHAR2(200), 
	ENVIADOAACOMPANAMIENTOLEGA NUMBER(1,0), 
	FECHAENVIADOAACOMPANAMIENTOLEG DATE, 
	FECHADELEVENTO DATE, 
	POSIBLESUBROGACION NUMBER(1,0), 
	FECHAIDENTIFICADOCOMOPOSIBLESU DATE, 
	MUERTOS VARCHAR2(100), 
	LESIONADOS VARCHAR2(100), 
	LESIONADOSPOSIBLERESULTADO VARCHAR2(100), 
	ASESORLEGAL VARCHAR2(100), 
	ESTADOPROCESAL VARCHAR2(100), 
	RECOMENDACIONLEGAL VARCHAR2(100), 
	NOMBREDELTERCERO VARCHAR2(100), 
	CEDULADELTERCERO VARCHAR2(20), 
	TELEFONODELTERCERO VARCHAR2(9), 
	CORREODELTERCERO VARCHAR2(80), 
	PLACADETERCEROCONTRAPARTE VARCHAR2(8), 
	LUGARACCIDENTE VARCHAR2(100), 
	JUZGADO NUMBER(5,0), 
	EXPEDIENTEJUDICIAL VARCHAR2(100), 
	FECHASENTENCIA DATE, 
	SUBROGACION NUMBER(1,0), 
	MONTOPORRECUPERAR NUMBER(18,0), 
	MONTORECUPERADO NUMBER(18,0), 
	SALDOPORRECUPERAR NUMBER(18,0), 
	UPDATEUSERCODE NUMBER(9,0), 
	UPDATEDATE DATE, 
	 PRIMARY KEY (ID)) ;




INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(100, 'Claim/ASIGES', 1, 'GET', 'Siniestro por ASIGES', NULL, 'SELECT', 2, 'select a80.NUM_SINI, a80.NUM_EXP, a80.TXT_DANO_VEHI,
       a900.COD_RAMO, a900.NUM_POLIZA, a900.NUM_SPTO, a900.NUM_APLI, a900.NUM_SPTO_APLI, a900.NUM_RIESGO, a900.FEC_DENU_SINI, a900.HORA_DENU_SINI, a900.FEC_SINI, a900.HORA_SINI,
       a900.TIP_EST_SINI, G31A.NOM_VALOR NOM_TIP_EST_SINI,
       a900.cod_causa_sini, a2159.COD_COB, a2159.NOM_COB, a900.COD_CAUSA_SINI, G200.NOM_CAUSA,       
       a1000.COD_MON, a400.NOM_MON,          
       a1000.TIP_EXP, a1000.TIP_EST_EXP,
       a900.TIP_DOCUM_TOMADOR, a900.COD_DOCUM_TOMADOR, A1399T.NOM_TERCERO NOM_TOMADOR,  A1399T.APE1_TERCERO APE_TOMADOR, A1331T.EMAIL EMAIL_TOMADOR, A1331T.TLF_NUMERO TLF_NUMERO_TOMADOR,
       a900.TIP_DOCUM_ASEG, a900.COD_DOCUM_ASEG, A1399A.NOM_TERCERO NOM_ASEG, A1399A.APE1_TERCERO APE_ASEG, A1331A.EMAIL EMAIL_ASEG, A1331A.TLF_NUMERO TLF_NUMERO_ASEG
  from A7001080 a80 
  join a7000900 a900 on a900.NUM_SINI=a80.NUM_SINI
  join A7001000 a1000 on a1000.NUM_SINI=a80.NUM_SINI AND a1000.NUM_EXP=a80.NUM_EXP
  LEFT JOIN G1010031 G31A ON G31A.COD_CAMPO =''TIP_EST_SINI'' AND G31A.COD_VALOR = a900.TIP_EST_SINI AND G31A.COD_IDIOMA=''ES''
  LEFT JOIN A1001399 A1399T ON A1399T.COD_CIA=a900.COD_CIA AND A1399T.TIP_DOCUM = a900.TIP_DOCUM_TOMADOR AND  A1399T.COD_DOCUM = a900.COD_DOCUM_TOMADOR  
  LEFT JOIN A1001331 A1331T ON A1331T.COD_CIA=a900.COD_CIA AND A1331T.TIP_DOCUM = a900.TIP_DOCUM_TOMADOR AND  A1331T.COD_DOCUM = a900.COD_DOCUM_TOMADOR
  LEFT JOIN A1001399 A1399A ON A1399A.COD_CIA=a900.COD_CIA AND A1399A.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1399A.COD_DOCUM = a900.COD_DOCUM_ASEG
  LEFT JOIN A1001331 A1331A ON A1331A.COD_CIA=a900.COD_CIA AND A1331A.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1331A.COD_DOCUM = a900.COD_DOCUM_ASEG  
  LEFT JOIN a1000400 a400 on a400.COD_MON = a1000.COD_MON
  LEFT JOIN A1002150 a2159 on a2159.COD_CIA= a900.COD_CIA AND a2159.COD_RAMO= a900.COD_RAMO AND a2159.COD_MODALIDAD= a900.COD_MODALIDAD AND a2159.COD_COB= a900.cod_causa_sini
  LEFT JOIN G7000200 G200 ON G200.COD_CIA = G200.COD_CIA AND G200.TIP_CAUSA = 1 AND G200.COD_CAUSA = a900.COD_CAUSA_SINI
 where a80.COD_CIA= 1 AND a80.OBS = {code:varchar2.40:Required}', 1, 'Custom', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(101, 'Policy/{id}', 1, 'GET', 'Información de pólizas', NULL, 'SELECT', 2, 'SELECT a30.COD_RAMO, a30.FEC_EFEC_POLIZA, a30.FEC_VCTO_POLIZA, 
       a30.COD_MON, a400.NOM_MON
  FROM A2000030 a30 
  LEFT JOIN a1000400 a400 on a400.COD_MON = a30.COD_MON AND a400.COD_CIA = a30.COD_CIA
  WHERE a30.COD_CIA=1 AND a30.NUM_POLIZA={ID:VARCHAR2.13:Required} AND a30.NUM_SPTO = {NUM_SPTO:NUMBER.22:Required} AND a30.NUM_APLI = NVL({NUM_APLI:NUMBER.22:Required}, 0) AND a30.NUM_SPTO_APLI = NVL({NUM_SPTO_APLI:NUMBER.22:Required}, 0)', 1, 'Custom', 0, 'FixedData', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(102, 'Policy/{id}', 2, 'GET', 'Terceros de una póliza', NULL, 'SELECT', 2, 'SELECT A60.NUM_RIESGO, A60.TIP_BENEF, G31.NOM_VALOR NOM_BENEF, A60.NUM_SECU, 
       A60.TIP_DOCUM, A60.COD_DOCUM, V90.NOM_COMPLETO,
       A60.PCT_PARTICIPACION, A60.FEC_VCTO_CESION, A60.IMP_CESION, A60.NUM_PRESTAMO, A60.TIP_RELAC
  FROM A2000060 A60
  LEFT JOIN G1010031 G31 ON G31.COD_CIA= A60.COD_CIA  AND G31.COD_CAMPO = ''TIP_BENEF'' AND G31.COD_IDIOMA = ''ES'' AND A60.TIP_BENEF = G31.COD_VALOR 
  LEFT JOIN V1001390 V90 ON V90.TIP_DOCUM = A60.TIP_DOCUM AND V90.COD_DOCUM = A60.COD_DOCUM
 WHERE a60.NUM_POLIZA={ID:VARCHAR2.13:Required} AND A60.MCA_BAJA = ''N'' AND A60.MCA_VIGENTE = ''S''
 ORDER BY A60.TIP_BENEF', 0, 'Custom', 0, 'ThirdParties', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(103, 'Policy/{id}', 3, 'GET', 'Datos variable de una póliza', NULL, 'SELECT', 2, 'SELECT A20.TIP_NIVEL, A20.COD_CAMPO, G10.NOM_CAMPO, A20.VAL_CAMPO, A20.VAL_COR_CAMPO, A20.NUM_SECU, A20.TXT_CAMPO
  FROM A2000020 A20
  LEFT JOIN G2000010 G10 ON A20.COD_CIA = G10.COD_CIA AND A20.COD_CAMPO = G10.COD_CAMPO
 WHERE A20.NUM_POLIZA = {ID:VARCHAR2.13:Required} AND A20.COD_CIA = 1 AND A20.NUM_RIESGO={NUM_RIESGO:NUMBER.7:Required} AND A20.MCA_VIGENTE = ''S'' AND A20.MCA_BAJA_RIESGO = ''N'' AND A20.MCA_VIGENTE_APLI = ''S''
 ORDER BY A20.TIP_NIVEL, A20.NUM_SECU', 0, 'Custom', 0, 'VariableData', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(107, 'Policy/{id}/AllPremiums', 1, 'GET', 'Recibos de una póliza', NULL, 'SELECT', 2, 'SELECT NUM_RECIBO, FEC_EFEC_RECIBO, FEC_VCTO_RECIBO, TIP_SITUACION, a700.COD_MON,
       SUM(IMP_RECIBO) IMP_RECIBO,
       SUM(IMP_NETA) + SUM(IMP_RECARGO) IMP_NETA, -- se suma la prima neta mas el impuesto de bomberos
       SUM(IMP_RECARGO) IMP_RECARGO,
       SUM(IMP_IMPTOS) IMP_IMPTOS,
       SUM(IMP_INTERES) IMP_INTERES
  FROM A2990700 a700
  JOIN a2000030 a30
    ON a700.cod_cia       = a30.cod_cia
   AND a700.num_spto      = a30.num_spto
   AND a700.num_apli      = a30.num_apli
   AND a700.num_poliza    = a30.num_poliza
   AND a700.num_spto_apli = a30.num_spto_apli
 WHERE a700.COD_CIA = 1
   AND a700.NUM_POLIZA = {ID:VARCHAR2.13:Required}
   AND a700.FEC_EFEC_RECIBO BETWEEN a30.FEC_EFEC_POLIZA AND a30.FEC_VCTO_POLIZA
   AND IMP_RECIBO != 0
 GROUP BY NUM_RECIBO, FEC_EFEC_RECIBO, FEC_VCTO_RECIBO, TIP_SITUACION, a700.COD_MON
 ORDER BY FEC_EFEC_RECIBO', 0, 'Custom', 0, 'Premiums', NULL, 0, 0, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(104, 'Policy/{id}/Coverages', 4, 'GET', 'Coberturas de una póliza', NULL, 'SELECT', 2, 'SELECT A40.COD_COB, A2150.NOM_COB, A40.SUMA_ASEG,
       EM_K_MAPFRE_BATCH_CONTRACT_MCR.F_IMP_PRIMA_COMERCIAL_POL(A40.COD_CIA, A40.NUM_POLIZA, A40.NUM_SPTO, A40.NUM_APLI, A40.NUM_SPTO_APLI, A40.NUM_RIESGO, A40.COD_COB, A40.COD_RAMO) IMP_ANUAL,
       EM_K_MAPFRE_BATCH_CONTRACT_MCR.F_IMP_IVA_POL(A40.COD_CIA, A40.NUM_POLIZA, A40.NUM_SPTO, A40.NUM_APLI, A40.NUM_SPTO_APLI, A40.NUM_RIESGO, A40.COD_COB, A40.COD_RAMO) IMP_IVA,
       EM_K_MAPFRE_BATCH_CONTRACT_MCR.F_IMP_RECARGO_FRACC_POL(A40.COD_CIA, A40.NUM_POLIZA, A40.NUM_SPTO, A40.NUM_APLI, A40.NUM_SPTO_APLI, A40.NUM_RIESGO, A40.COD_COB, A40.COD_RAMO) IMP_FRACC,
       EM_K_MAPFRE_BATCH_CONTRACT_MCR.F_IMP_PRIMA_TOTAL_POL(A40.COD_CIA, A40.NUM_POLIZA, A40.NUM_SPTO, A40.NUM_APLI, A40.NUM_SPTO_APLI, A40.NUM_RIESGO, A40.COD_COB, A40.COD_RAMO) IMP_TOTAL,
       A40.COD_FRANQUICIA,
       EM_K_MAPFRE_BATCH_CONTRACT_MCR.F_NOM_FRANQUCIA(A40.COD_CIA, A40.COD_MON_CAPITAL, A40.COD_FRANQUICIA) NOM_FRANQUICIA
  FROM A2000040 A40
 LEFT JOIN A1002150 A2150
    ON A2150.COD_CIA = A40.COD_CIA 
   AND A2150.COD_RAMO = A40.COD_RAMO 
   AND A2150.COD_MODALIDAD = 99999
   AND A2150.COD_COB = A40.COD_COB
   AND A2150.FEC_VALIDEZ = (SELECT MAX(FEC_VALIDEZ) FROM A1002150 A10 WHERE A10.COD_CIA = A2150.COD_CIA AND A10.COD_RAMO = A2150.COD_RAMO AND A10.COD_MODALIDAD = A2150.COD_MODALIDAD AND A10.COD_COB = A2150.COD_COB AND A10.FEC_VALIDEZ <= SYSDATE)
 WHERE A40.COD_CIA = 1
   AND A40.NUM_POLIZA = {ID:VARCHAR2.13:Required}
   AND A40.NUM_SPTO = (SELECT MAX(NUM_SPTO) FROM A2000030 A20 WHERE A20.COD_CIA = A40.COD_CIA AND A20.NUM_POLIZA =A40.NUM_POLIZA)
   AND A40.MCA_BAJA_COB = ''N''
   AND A40.MCA_BAJA_RIESGO = ''N''
   AND A40.MCA_VIGENTE_APLI = ''S''
 ORDER BY A2150.NOM_COB', 0, 'Custom', 0, 'Coverage', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(105, 'Policy/{id}/Premiums', 5, 'GET', 'Recibos pendiente de una póliza', NULL, 'SELECT', 2, 'SELECT COD_CIA, NUM_POLIZA, NUM_SPTO, NUM_APLI, NUM_SPTO_APLI, NUM_CUOTA, NUM_RECIBO, TIP_RECIBO, FEC_EFEC_RECIBO, FEC_VCTO_RECIBO, TIP_GESTOR, COD_GESTOR, FEC_EMISION_SPTO, TIP_SITUACION, TIP_REMESA, FEC_REMESA, FEC_CTABLE, FEC_VALOR, COD_MON, VAL_CAMBIO, IMP_RECIBO, IMP_NETA, IMP_RECARGO, IMP_IMPTOS, IMP_BONI, IMP_COMIS, TIP_COASEGURO, COD_NIVEL3, COD_AGT, NUM_IMPRESION, CTRL_MOROSO, TXT_AUX1, TXT_AUX2, FEC_ACTU, IMP_TOTAL_COMIS, MCA_CA, MCA_CV, NUM_AVISO, TIP_DOCUM_PAGO, COD_DOCUM_PAGO, IMP_INTERES, IMP_IMPTOS_INTERES, NUM_MVTO_CV, MCA_DCTO_COMIS, FEC_VCTO_PAGO, NUM_MVTO_CA, MCA_DTO_IMPTO, MCA_DTO_RECARGO
  FROM TRON2000.A2990700 a 
 WHERE a.NUM_POLIZA={ID:VARCHAR2.13:Required}
   AND a.num_spto IN (select max(aa.num_spto) from a2000030 aa JOIN a2990700 t on t.cod_cia = aa.cod_cia and t.num_poliza = aa.num_poliza and t.num_spto = aa.num_spto and t.num_apli = aa.num_apli and t.num_spto_apli = aa.num_spto_apli and t.tip_situacion = ''EP'' where aa.cod_cia  = a.cod_cia and aa.num_poliza = a.NUM_POLIZA AND aa.mca_spto_anulado = ''N'')
   AND num_recibo IN (select min(t.num_recibo) from a2990700 t where t.cod_cia = a.cod_cia and t.num_poliza = a.num_poliza and t.num_spto = a.num_spto and t.num_apli = a.num_apli and t.num_spto_apli = a.num_spto_apli and t.tip_situacion = ''EP'')
', 0, 'Custom', 0, 'PendingPremiums', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(106, 'Policy/{id}/Premiums', 6, 'GET', 'Recibos pagados de una póliza', NULL, 'SELECT', 2, 'SELECT COD_CIA, NUM_POLIZA, NUM_SPTO, NUM_APLI, NUM_SPTO_APLI, NUM_CUOTA, NUM_RECIBO, TIP_RECIBO, FEC_EFEC_RECIBO, FEC_VCTO_RECIBO, TIP_GESTOR, COD_GESTOR, FEC_EMISION_SPTO, TIP_SITUACION, TIP_REMESA, FEC_REMESA, FEC_CTABLE, FEC_VALOR, COD_MON, VAL_CAMBIO, IMP_RECIBO, IMP_NETA, IMP_RECARGO, IMP_IMPTOS, IMP_BONI, IMP_COMIS, TIP_COASEGURO, COD_NIVEL3, COD_AGT, NUM_IMPRESION, CTRL_MOROSO, TXT_AUX1, TXT_AUX2, FEC_ACTU, IMP_TOTAL_COMIS, MCA_CA, MCA_CV, NUM_AVISO, TIP_DOCUM_PAGO, COD_DOCUM_PAGO, IMP_INTERES, IMP_IMPTOS_INTERES, NUM_MVTO_CV, MCA_DCTO_COMIS, FEC_VCTO_PAGO, NUM_MVTO_CA, MCA_DTO_IMPTO, MCA_DTO_RECARGO
  FROM TRON2000.A2990700 a 
 WHERE a.NUM_POLIZA={ID:VARCHAR2.13:Required}
   AND a.num_spto IN (select max(aa.num_spto) from a2000030 aa JOIN a2990700 t on t.cod_cia = aa.cod_cia and t.num_poliza = aa.num_poliza and t.num_spto = aa.num_spto and t.num_apli = aa.num_apli and t.num_spto_apli = aa.num_spto_apli and t.tip_situacion = ''CT'' where aa.cod_cia  = a.cod_cia and aa.num_poliza = a.NUM_POLIZA AND aa.mca_spto_anulado = ''N'')
   AND num_recibo IN (select max(t.num_recibo) from a2990700 t where t.cod_cia = a.cod_cia and t.num_poliza = a.num_poliza and t.num_spto = a.num_spto and t.num_apli = a.num_apli and t.num_spto_apli = a.num_spto_apli and t.tip_situacion = ''CT'')', 0, 'Custom', 0, 'PaidPremiums', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(213, 'PurdyPanelBalance', 1, 'POST', 'Recupera el próximo id disponible para la tabla PurdyPanelBalance', NULL, 'SELECT', 1, 'SELECT NVL(MAX(ID),0)+1 AS NextId FROM PurdyPanelBalance', 1, 'PurdyPanelBalance', 0, 'Next', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(214, 'PurdyPanelBalance', 2, 'POST', 'Crea un registro de PurdyPanelBalance', NULL, 'INSERT', 1, 'INSERT INTO PurdyPanelBalance (ID, asiges, NUMERODESINIESTRO, TIPODEDOCUMENTO, NUMERODEDOCUMENTO, FECHA, RECEPTOR, MONTO, NCREPUESTO, OBSERVACION, UPDATEUSERCODE, UPDATEDATE) VALUES  ({dependency.Next.NEXTID:NUMBER.9:Required}, {asiges:VARCHAR2.40}, {NUMERODESINIESTRO:VARCHAR2.20}, {TIPODEDOCUMENTO:NUMBER.5}, {NUMERODEDOCUMENTO:VARCHAR2.20}, {FECHA:DATE.0}, {RECEPTOR:VARCHAR2.100}, {MONTO:NUMBER.18}, {NCREPUESTO:NUMBER.18}, {OBSERVACION:VARCHAR2.200}, {App.UserId}, {Const.Date.Now})', 0, 'PurdyPanelBalance', 0, 'Create', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(215, 'PurdyPanelBalance/ASIGES', 1, 'GET', 'Recupera los registros de balance por medio del código ASIGES', NULL, 'SELECT', 1, 'SELECT ID, asiges, NUMERODESINIESTRO, TIPODEDOCUMENTO, NUMERODEDOCUMENTO, FECHA, RECEPTOR, MONTO, NCREPUESTO, OBSERVACION, UPDATEUSERCODE, UPDATEDATE FROM PurdyPanelBalance WHERE asiges = {code:varchar2.40:Required}', 0, 'PurdyPanelBalance', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(217, 'PurdyPanelBalance/{id}', 1, 'DELETE', 'Elimina un registro de la tabla PurdyPanelBalance por medio de su clave', NULL, 'DELETE', 1, 'DELETE PurdyPanelBalance WHERE ID={ID:NUMBER.9:Required}', 0, 'PurdyPanelBalance', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(216, 'PurdyPanelBalance/{id}', 1, 'PUT', 'Actualiza un registro de la tabla PurdyPanelBalance/{id} por medio de su clave', NULL, 'UPDATE', 1, 'UPDATE PurdyPanelBalance SET asiges={asiges:VARCHAR2.40}, NUMERODESINIESTRO={NUMERODESINIESTRO:VARCHAR2.20}, TIPODEDOCUMENTO={TIPODEDOCUMENTO:NUMBER.5}, NUMERODEDOCUMENTO={NUMERODEDOCUMENTO:VARCHAR2.20}, FECHA={FECHA:DATE.0}, RECEPTOR={RECEPTOR:VARCHAR2.100}, MONTO={MONTO:NUMBER.18}, NCREPUESTO={NCREPUESTO:NUMBER.18}, OBSERVACION={OBSERVACION:VARCHAR2.200}, UPDATEUSERCODE={App.UserId}, UPDATEDATE={Const.Date.Now} WHERE ID={ID:NUMBER.9:Required}', 0, 'PurdyPanelBalance', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(205, 'PurdyPanelDano', 1, 'POST', 'Recupera el próximo id disponible para la tabla PurdyPanelDano', NULL, 'SELECT', 1, 'SELECT NVL(MAX(ID),0)+1 AS NextId FROM PurdyPanelDano', 1, 'PurdyPanelDano', 0, 'Next', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(206, 'PurdyPanelDano', 2, 'POST', 'Crea un registro de PurdyPanelDano', NULL, 'INSERT', 1, 'INSERT INTO PurdyPanelDano (ID, asiges, taller, fechaenviodelavaluo, prerepuestos, prerepuestosiva, prerepuestostotal, premano, premanoiva, premanototal, preperdida, autorizaciondeusopoliza, fechaAutorizaciondeUsoPoliza, oT, asesorTaller, expediente, analistadeDanos, depreciacionyexclusiones, perdrepuesto, perdrepuestoiva, perdrepuestototal, perdmano, perdmanoiva, perdmanototal, perdida, severidaddelsiniestro, avaluoautorizado, fechaautorizacion, perdidatotal, tipodeperdidatotal, presentadanooculto, fechasolicitado, observaciones, danoocultomontoRepDanooculto, danoocultoiva, danoocultototal, danoocultomano, danoocultomanoiva, danoocultomanototal, otrosIIOtrosIIDanoculmanototal, UPDATEUSERCODE, UPDATEDATE) VALUES  ({dependency.Next.NEXTID:NUMBER.9:Required}, {asiges:VARCHAR2.40}, {taller:NUMBER.5}, {fechaenviodelavaluo:DATE.7}, {prerepuestos:NUMBER.18}, {prerepuestosiva:NUMBER.18}, {prerepuestostotal:NUMBER.18}, {premano:NUMBER.18}, {premanoiva:NUMBER.18}, {premanototal:NUMBER.18}, {preperdida:NUMBER.18}, {autorizaciondeusopoliza:NUMBER.1}, {fechaAutorizaciondeUsoPoliza:DATE.0}, {oT:NUMBER.6}, {asesorTaller:VARCHAR2.100}, {expediente:VARCHAR2.20}, {analistadeDanos:NUMBER.9}, {depreciacionyexclusiones:NUMBER.18}, {perdrepuesto:NUMBER.18}, {perdrepuestoiva:NUMBER.18}, {perdrepuestototal:NUMBER.18}, {perdmano:NUMBER.18}, {perdmanoiva:NUMBER.18}, {perdmanototal:NUMBER.18}, {perdida:NUMBER.18}, {severidaddelsiniestro:NUMBER.5}, {avaluoautorizado:NUMBER.1}, {fechaautorizacion:DATE.0}, {perdidatotal:NUMBER.1}, {tipodeperdidatotal:NUMBER.5}, {presentadanooculto:NUMBER.1}, {fechasolicitado:DATE.0}, {observaciones:VARCHAR2.200}, {danoocultomontoRepDanooculto:NUMBER.18}, {danoocultoiva:NUMBER.18}, {danoocultototal:NUMBER.18}, {danoocultomano:NUMBER.18}, {danoocultomanoiva:NUMBER.18}, {danoocultomanototal:NUMBER.18}, {otrosIIOtrosIIDanoculmanototal:NUMBER.18}, {App.UserId}, {Const.Date.Now})', 0, 'PurdyPanelDano', 0, 'Create', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(207, 'PurdyPanelDano/ASIGES', 1, 'GET', 'Recupera un daño por medio del código ASIGES', NULL, 'SELECT', 1, 'SELECT ID, asiges, taller, fechaenviodelavaluo, prerepuestos, prerepuestosiva, prerepuestostotal, premano, premanoiva, premanototal, preperdida, autorizaciondeusopoliza, fechaAutorizaciondeUsoPoliza, oT, asesorTaller, expediente, analistadeDanos, depreciacionyexclusiones, perdrepuesto, perdrepuestoiva, perdrepuestototal, perdmano, perdmanoiva, perdmanototal, perdida, severidaddelsiniestro, avaluoautorizado, fechaautorizacion, perdidatotal, tipodeperdidatotal, presentadanooculto, fechasolicitado, observaciones, danoocultomontoRepDanooculto, danoocultoiva, danoocultototal, danoocultomano, danoocultomanoiva, danoocultomanototal, otrosIIOtrosIIDanoculmanototal, UPDATEUSERCODE, UPDATEDATE FROM PurdyPanelDano WHERE asiges = {code:varchar2.40:Required}', 1, 'PurdyPanelDano', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(204, 'PurdyPanelDano/{id}', 1, 'PUT', 'Actualiza un registro de la tabla PurdyPanelDano/{id} por medio de su clave', NULL, 'UPDATE', 1, 'UPDATE PurdyPanelDano SET asiges={asiges:VARCHAR2.40}, taller={taller:NUMBER.5}, fechaenviodelavaluo={fechaenviodelavaluo:DATE.0}, prerepuestos={prerepuestos:NUMBER.18}, prerepuestosiva={prerepuestosiva:NUMBER.18}, prerepuestostotal={prerepuestostotal:NUMBER.18}, premano={premano:NUMBER.18}, premanoiva={premanoiva:NUMBER.18}, premanototal={premanototal:NUMBER.18}, preperdida={preperdida:NUMBER.18}, autorizaciondeusopoliza={autorizaciondeusopoliza:NUMBER.1}, fechaAutorizaciondeUsoPoliza={fechaAutorizaciondeUsoPoliza:DATE.0}, oT={oT:NUMBER.6}, asesorTaller={asesorTaller:VARCHAR2.100}, expediente={expediente:VARCHAR2.20}, analistadeDanos={analistadeDanos:NUMBER.9}, depreciacionyexclusiones={depreciacionyexclusiones:NUMBER.18}, perdrepuesto={perdrepuesto:NUMBER.18}, perdrepuestoiva={perdrepuestoiva:NUMBER.18}, perdrepuestototal={perdrepuestototal:NUMBER.18}, perdmano={perdmano:NUMBER.18}, perdmanoiva={perdmanoiva:NUMBER.18}, perdmanototal={perdmanototal:NUMBER.18}, perdida={perdida:NUMBER.18}, severidaddelsiniestro={severidaddelsiniestro:NUMBER.5}, avaluoautorizado={avaluoautorizado:NUMBER.1}, fechaautorizacion={fechaautorizacion:DATE.0}, perdidatotal={perdidatotal:NUMBER.1}, tipodeperdidatotal={tipodeperdidatotal:NUMBER.5}, presentadanooculto={presentadanooculto:NUMBER.1}, fechasolicitado={fechasolicitado:DATE.0}, observaciones={observaciones:VARCHAR2.200}, danoocultomontoRepDanooculto={danoocultomontoRepDanooculto:NUMBER.18}, danoocultoiva={danoocultoiva:NUMBER.18}, danoocultototal={danoocultototal:NUMBER.18}, danoocultomano={danoocultomano:NUMBER.18}, danoocultomanoiva={danoocultomanoiva:NUMBER.18}, danoocultomanototal={danoocultomanototal:NUMBER.18}, otrosIIOtrosIIDanoculmanototal={otrosIIOtrosIIDanoculmanototal:NUMBER.18}, UPDATEUSERCODE={App.UserId}, UPDATEDATE={Const.Date.Now} WHERE ID={ID:NUMBER.9:Required}', 0, 'PurdyPanelDano', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(227, 'PurdyPanelDetalle', 1, 'POST', 'Recupera el próximo id disponible para la tabla PurdyPanelDetalle', NULL, 'SELECT', 1, 'SELECT NVL(MAX(ID),0)+1 AS NextId FROM PurdyPanelDetalle', 1, 'PurdyPanelDetalle', 0, 'Next', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(223, 'PurdyPanelDetalle', 2, 'POST', 'Crea un registro de PurdyPanelDetalle', NULL, 'INSERT', 1, 'INSERT INTO PurdyPanelDetalle (ID, asiges, enviadoainvestigacion, fechaenviadoainvestigacion, requisitosporpresentarparareco, enviadoaacompanamientolega, fechaenviadoaacompanamientoLeg, fechadelevento, posiblesubrogacion, fechaidentificadocomoposiblesu, muertos, lesionados, lesionadosPosibleResultado, asesorlegal, estadoprocesal, recomendacionlegal, nombredeltercero, ceduladeltercero, telefonodeltercero, correodeltercero, placadetercerocontraparte, lugaraccidente, juzgado, expedientejudicial, fechasentencia, subrogacion, montoporrecuperar, montorecuperado, saldoporrecuperar, UPDATEUSERCODE, UPDATEDATE) VALUES  ({dependency.Next.NEXTID:NUMBER.9:Required}, {asiges:VARCHAR2.40}, {enviadoainvestigacion:NUMBER.1}, {fechaenviadoainvestigacion:DATE.0}, {requisitosporpresentarparareco:VARCHAR2.200}, {enviadoaacompanamientolega:NUMBER.1}, {fechaenviadoaacompanamientoLeg:DATE.0}, {fechadelevento:DATE.0}, {posiblesubrogacion:NUMBER.1}, {fechaidentificadocomoposiblesu:DATE.0}, {muertos:VARCHAR2.100}, {lesionados:VARCHAR2.100}, {lesionadosPosibleResultado:VARCHAR2.100}, {asesorlegal:VARCHAR2.100}, {estadoprocesal:VARCHAR2.100}, {recomendacionlegal:VARCHAR2.100}, {nombredeltercero:VARCHAR2.100}, {ceduladeltercero:VARCHAR2.20}, {telefonodeltercero:VARCHAR2.9}, {correodeltercero:VARCHAR2.80}, {placadetercerocontraparte:VARCHAR2.8}, {lugaraccidente:VARCHAR2.100}, {juzgado:NUMBER.5}, {expedientejudicial:VARCHAR2.100}, {fechasentencia:DATE.0}, {subrogacion:NUMBER.1}, {montoporrecuperar:NUMBER.18}, {montorecuperado:NUMBER.18}, {saldoporrecuperar:NUMBER.18}, {App.UserId}, {Const.Date.Now})', 0, 'PurdyPanelDetalle', 0, 'Create', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(226, 'PurdyPanelDetalle/ASIGES', 1, 'GET', 'Recupera un detalle por medio del código ASIGES', NULL, 'SELECT', 1, 'SELECT ID "ID", asiges "asiges", enviadoainvestigacion "enviadoainvestigacion", fechaenviadoainvestigacion "fechaenviadoainvestigacion", requisitosporpresentarparareco "requisitosporpresentarparareco", enviadoaacompanamientolega "enviadoaacompanamientolega", fechaenviadoaacompanamientoLeg "fechaenviadoaacompanamientoLeg", fechadelevento "fechadelevento", posiblesubrogacion "posiblesubrogacion", fechaidentificadocomoposiblesu "fechaidentificadocomoposiblesu", muertos "muertos", lesionados "lesionados", lesionadosPosibleResultado "lesionadosPosibleResultado", asesorlegal "asesorlegal", estadoprocesal "estadoprocesal", recomendacionlegal "recomendacionlegal", nombredeltercero "nombredeltercero", ceduladeltercero "ceduladeltercero", telefonodeltercero "telefonodeltercero", correodeltercero "correodeltercero", placadetercerocontraparte "placadetercerocontraparte", lugaraccidente "lugaraccidente", juzgado "juzgado", expedientejudicial "expedientejudicial", fechasentencia "fechasentencia", subrogacion "subrogacion", montoporrecuperar "montoporrecuperar", montorecuperado "montorecuperado", saldoporrecuperar "saldoporrecuperar", UPDATEUSERCODE "UPDATEUSERCODE", UPDATEDATE "UPDATEDATE" FROM PurdyPanelDetalle WHERE asiges = {code:varchar2.40:Required}', 0, 'PurdyPanelDetalle', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(224, 'PurdyPanelDetalle/{id}', 1, 'DELETE', 'Elimina un registro de la tabla PurdyPanelDetalle por medio de su clave', NULL, 'DELETE', 1, 'DELETE PurdyPanelDetalle WHERE ID={ID:NUMBER.9:Required}', 0, 'PurdyPanelDetalle', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(225, 'PurdyPanelDetalle/{id}', 1, 'PUT', 'Actualiza un registro de la tabla PurdyPanelDetalle/{id} por medio de su clave', NULL, 'UPDATE', 1, 'UPDATE PurdyPanelDetalle SET asiges={asiges:VARCHAR2.40}, enviadoainvestigacion={enviadoainvestigacion:NUMBER.1}, fechaenviadoainvestigacion={fechaenviadoainvestigacion:DATE.0}, requisitosporpresentarparareco={requisitosporpresentarparareco:VARCHAR2.200}, enviadoaacompanamientolega={enviadoaacompanamientolega:NUMBER.1}, fechaenviadoaacompanamientoLeg={fechaenviadoaacompanamientoLeg:DATE.0}, fechadelevento={fechadelevento:DATE.0}, posiblesubrogacion={posiblesubrogacion:NUMBER.1}, fechaidentificadocomoposiblesu={fechaidentificadocomoposiblesu:DATE.0}, muertos={muertos:VARCHAR2.100}, lesionados={lesionados:VARCHAR2.100}, lesionadosPosibleResultado={lesionadosPosibleResultado:VARCHAR2.100}, asesorlegal={asesorlegal:VARCHAR2.100}, estadoprocesal={estadoprocesal:VARCHAR2.100}, recomendacionlegal={recomendacionlegal:VARCHAR2.100}, nombredeltercero={nombredeltercero:VARCHAR2.100}, ceduladeltercero={ceduladeltercero:VARCHAR2.20}, telefonodeltercero={telefonodeltercero:VARCHAR2.9}, correodeltercero={correodeltercero:VARCHAR2.80}, placadetercerocontraparte={placadetercerocontraparte:VARCHAR2.8}, lugaraccidente={lugaraccidente:VARCHAR2.100}, juzgado={juzgado:NUMBER.5}, expedientejudicial={expedientejudicial:VARCHAR2.100}, fechasentencia={fechasentencia:DATE.0}, subrogacion={subrogacion:NUMBER.1}, montoporrecuperar={montoporrecuperar:NUMBER.18}, montorecuperado={montorecuperado:NUMBER.18}, saldoporrecuperar={saldoporrecuperar:NUMBER.18}, UPDATEUSERCODE={App.UserId}, UPDATEDATE={Const.Date.Now} WHERE ID={ID:NUMBER.9:Required}', 0, 'PurdyPanelDetalle', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(200, 'PurdyPanelEvento', 1, 'POST', 'Recupera el próximo id disponible para la tabla PurdyPanelEvento', NULL, 'SELECT', 1, 'SELECT NVL(MAX(ID),0)+1 AS NextId FROM PurdyPanelEvento', 1, 'PurdyPanelEvento', 0, 'Next', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(202, 'PurdyPanelEvento', 2, 'POST', 'Crea un registro de PurdyPanelEvento', NULL, 'INSERT', 1, 'INSERT INTO PurdyPanelEvento (ID, asiges, fechadelevento, analistareclamos, tipodeindemnizacion, motivonoProcede, detallenoprocede, detallesiniestro, tipodecobertura, categoriadesiniestro, posiblesubrogacion, fechaPosibleSubrogacion, enviadoaInvestigacion, fechaenviadoainvestigacion, enviadoaacompanamientoLegal, fechaenviadoacompaLegal, infraseguro, autorizaciondeusopoliza, fechaautorizaciondeusopoliza, UPDATEUSERCODE, UPDATEDATE) VALUES  ({dependency.Next.NEXTID:NUMBER.9:Required}, {asiges:VARCHAR2.40}, {fechadelevento:DATE.0}, {analistareclamos:NUMBER.9}, {tipodeindemnizacion:NUMBER.5}, {motivonoProcede:NUMBER.5}, {detallenoprocede:VARCHAR2.200}, {detallesiniestro:VARCHAR2.200}, {tipodecobertura:NUMBER.5}, {categoriadesiniestro:NUMBER.5}, {posiblesubrogacion:NUMBER.1}, {fechaPosibleSubrogacion:DATE.0}, {enviadoaInvestigacion:NUMBER.1}, {fechaenviadoainvestigacion:DATE.0}, {enviadoaacompanamientoLegal:NUMBER.1}, {fechaenviadoacompaLegal:DATE.0}, {infraseguro:NUMBER.1}, {autorizaciondeusopoliza:NUMBER.1}, {fechaautorizaciondeusopoliza:DATE.0}, {App.UserId}, {Const.Date.Now})', 0, 'PurdyPanelEvento', 0, 'Create', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(203, 'PurdyPanelEvento/ASIGES', 1, 'GET', 'Recupera un evento por medio del código ASIGES', NULL, 'SELECT', 1, 'SELECT ID, asiges, fechadelevento, analistareclamos, tipodeindemnizacion, motivonoProcede, detallenoprocede, detallesiniestro, tipodecobertura, categoriadesiniestro, posiblesubrogacion, fechaPosibleSubrogacion, enviadoaInvestigacion, fechaenviadoainvestigacion, enviadoaacompanamientoLegal, fechaenviadoacompaLegal, infraseguro, autorizaciondeusopoliza, fechaautorizaciondeusopoliza, nombredelchofer, telefonodelchofer, UPDATEUSERCODE, UPDATEDATE FROM PurdyPanelEvento WHERE asiges = {code:varchar2.40:Required}', 1, 'PurdyPanelEvento', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(201, 'PurdyPanelEvento/{id}', 1, 'PUT', 'Actualiza un registro de la tabla PurdyPanelEvento/{id} por medio de su clave', NULL, 'UPDATE', 1, 'UPDATE PurdyPanelEvento SET asiges={asiges:VARCHAR2.40}, fechadelevento={fechadelevento:DATE.0}, analistareclamos={analistareclamos:NUMBER.9}, tipodeindemnizacion={tipodeindemnizacion:NUMBER.5}, motivonoProcede={motivonoProcede:NUMBER.5}, detallenoprocede={detallenoprocede:VARCHAR2.200}, detallesiniestro={detallesiniestro:VARCHAR2.200}, tipodecobertura={tipodecobertura:NUMBER.5}, categoriadesiniestro={categoriadesiniestro:NUMBER.5}, posiblesubrogacion={posiblesubrogacion:NUMBER.1}, fechaPosibleSubrogacion={fechaPosibleSubrogacion:DATE.0}, enviadoaInvestigacion={enviadoaInvestigacion:NUMBER.1}, fechaenviadoainvestigacion={fechaenviadoainvestigacion:DATE.0}, enviadoaacompanamientoLegal={enviadoaacompanamientoLegal:NUMBER.1}, fechaenviadoacompaLegal={fechaenviadoacompaLegal:DATE.0}, infraseguro={infraseguro:NUMBER.1}, autorizaciondeusopoliza={autorizaciondeusopoliza:NUMBER.1}, fechaautorizaciondeusopoliza={fechaautorizaciondeusopoliza:DATE.0}, UPDATEUSERCODE={App.UserId}, UPDATEDATE={Const.Date.Now} WHERE ID={ID:NUMBER.9:Required}', 0, 'PurdyPanelEvento', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(211, 'PurdyPanelMontos', 1, 'POST', 'Recupera el próximo id disponible para la tabla PurdyPanelMontos', NULL, 'SELECT', 1, 'SELECT NVL(MAX(ID),0)+1 AS NextId FROM PurdyPanelMontos', 1, 'PurdyPanelMontos', 0, 'Next', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(209, 'PurdyPanelMontos', 2, 'POST', 'Crea un registro de PurdyPanelMontos', NULL, 'INSERT', 1, 'INSERT INTO PurdyPanelMontos (ID, asiges, MONTOINICIALPORINDEMNIZAR, MONTOINICIALPORINDEMNIZARREPUE, MONTOINICIALPORINDEMNIZARMANOD, MONTODANOOCULTOPORINDEMNIZAR, MONTODANOOCULTOPORINDEMNIZARRE, MONTODANOOCULTOPORINDEMNIZARMA, UPDATEUSERCODE, UPDATEDATE) VALUES  ({dependency.Next.NEXTID:NUMBER.9:Required}, {asiges:VARCHAR2.40}, {MONTOINICIALPORINDEMNIZAR:NUMBER.18}, {MONTOINICIALPORINDEMNIZARREPUE:NUMBER.18}, {MONTOINICIALPORINDEMNIZARMANOD:NUMBER.18}, {MONTODANOOCULTOPORINDEMNIZAR:NUMBER.18}, {MONTODANOOCULTOPORINDEMNIZARRE:NUMBER.18}, {MONTODANOOCULTOPORINDEMNIZARMA:NUMBER.18}, {App.UserId}, {Const.Date.Now})', 0, 'PurdyPanelMontos', 0, 'Create', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(210, 'PurdyPanelMontos/ASIGES', 1, 'GET', 'Recupera los montos por medio del código ASIGES', NULL, 'SELECT', 1, 'SELECT ID, asiges, MONTOINICIALPORINDEMNIZAR, MONTOINICIALPORINDEMNIZARREPUE, MONTOINICIALPORINDEMNIZARMANOD, MONTODANOOCULTOPORINDEMNIZAR, MONTODANOOCULTOPORINDEMNIZARRE, MONTODANOOCULTOPORINDEMNIZARMA, UPDATEUSERCODE, UPDATEDATE FROM PurdyPanelMontos WHERE asiges = {code:varchar2.40:Required}', 0, 'PurdyPanelMontos', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(212, 'PurdyPanelMontos/{id}', 1, 'DELETE', 'Elimina un registro de la tabla PurdyPanelMontos por medio de su clave', NULL, 'DELETE', 1, 'DELETE PurdyPanelMontos WHERE ID={ID:NUMBER.9:Required}', 0, 'PurdyPanelMontos', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(208, 'PurdyPanelMontos/{id}', 1, 'PUT', 'Actualiza un registro de la tabla PurdyPanelMontos/{id} por medio de su clave', NULL, 'UPDATE', 1, 'UPDATE PurdyPanelMontos SET asiges={asiges:VARCHAR2.40}, MONTOINICIALPORINDEMNIZAR={MONTOINICIALPORINDEMNIZAR:NUMBER.18}, MONTOINICIALPORINDEMNIZARREPUE={MONTOINICIALPORINDEMNIZARREPUE:NUMBER.18}, MONTOINICIALPORINDEMNIZARMANOD={MONTOINICIALPORINDEMNIZARMANOD:NUMBER.18}, MONTODANOOCULTOPORINDEMNIZAR={MONTODANOOCULTOPORINDEMNIZAR:NUMBER.18}, MONTODANOOCULTOPORINDEMNIZARRE={MONTODANOOCULTOPORINDEMNIZARRE:NUMBER.18}, MONTODANOOCULTOPORINDEMNIZARMA={MONTODANOOCULTOPORINDEMNIZARMA:NUMBER.18}, UPDATEUSERCODE={App.UserId}, UPDATEDATE={Const.Date.Now} WHERE ID={ID:NUMBER.9:Required}', 0, 'PurdyPanelMontos', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(228, 'PurdyPanelOtros', 1, 'POST', 'Recupera el próximo id disponible para la tabla PurdyPanelOtros', NULL, 'SELECT', 1, 'SELECT NVL(MAX(ID),0)+1 AS NextId FROM PurdyPanelEvento', 1, 'Custom', 0, 'Next', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(229, 'PurdyPanelOtros', 2, 'POST', 'Crea un registro de PurdyPanelOtros', NULL, 'INSERT', 1, 'INSERT INTO PurdyPanelEvento (ID, asiges, nombredelchofer, telefonodelchofer, UPDATEUSERCODE, UPDATEDATE) VALUES  ({dependency.Next.NEXTID:NUMBER.9:Required}, {asiges:VARCHAR2.40}, {nombredelchofer:VARCHAR2.100}, {telefonodelchofer:VARCHAR2.9}, {App.UserId}, {Const.Date.Now})', 0, 'Custom', 0, 'Create', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(230, 'PurdyPanelOtros/{id}', 1, 'PUT', 'Actualiza un registro de la tabla PurdyPanelOtros por medio de su clave', NULL, 'UPDATE', 1, 'UPDATE PurdyPanelEvento SET  nombredelchofer={nombredelchofer:VARCHAR2.100}, telefonodelchofer={telefonodelchofer:VARCHAR2.9}, UPDATEUSERCODE={App.UserId}, UPDATEDATE={Const.Date.Now} WHERE ID={ID:NUMBER.9:Required}', 0, 'Custom', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(218, 'PurdyPanelRecuperacion', 1, 'POST', 'Recupera el próximo id disponible para la tabla PurdyPanelRecuperacion', NULL, 'SELECT', 1, 'SELECT NVL(MAX(ID),0)+1 AS NextId FROM PurdyPanelRecuperacion', 1, 'PurdyPanelRecuperacion', 0, 'Next', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(221, 'PurdyPanelRecuperacion', 2, 'POST', 'Crea un registro de PurdyPanelRecuperacion', NULL, 'INSERT', 1, 'INSERT INTO PurdyPanelRecuperacion (ID, asiges, numerodesiniestro, tipodedocumento, numerodedocumento, fecharecupera, receptor, montorecupera, observacion, UPDATEUSERCODE, UPDATEDATE) VALUES  ({dependency.Next.NEXTID:NUMBER.9:Required}, {asiges:VARCHAR2.40}, {numerodesiniestro:VARCHAR2.20}, {tipodedocumento:NUMBER.5}, {numerodedocumento:VARCHAR2.20}, {fecharecupera:DATE.0}, {receptor:VARCHAR2.100}, {montorecupera:NUMBER.18}, {observacion:VARCHAR2.200}, {App.UserId}, {Const.Date.Now})', 0, 'PurdyPanelRecuperacion', 0, 'Create', NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(222, 'PurdyPanelRecuperacion/ASIGES', 1, 'GET', 'Recupera una recuperación por medio del código ASIGES', NULL, 'SELECT', 1, 'SELECT ID "ID", asiges "asiges",  numerodesiniestro "numerodesiniestro", tipodedocumento "tipodedocumento", numerodedocumento "numerodedocumento", fecharecupera "fecharecupera", receptor "receptor", montorecupera "montorecupera", observacion "observacion", UPDATEUSERCODE, "UPDATEUSERCODE", UPDATEDATE, "UPDATEDATE" FROM PurdyPanelRecuperacion WHERE asiges = {code:varchar2.40:Required}', 0, 'PurdyPanelRecuperacion', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(219, 'PurdyPanelRecuperacion/{id}', 1, 'DELETE', 'Elimina un registro de la tabla PurdyPanelRecuperacion por medio de su clave', NULL, 'DELETE', 1, 'DELETE PurdyPanelRecuperacion WHERE ID={ID:NUMBER.9:Required}', 0, 'PurdyPanelRecuperacion', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
INSERT INTO RESTENDPOINTS (ID, "PATH", "SEQUENCE", VERB, SUMMARY, DESCRIPTION, STATEMENTTYPE, DATASOURCE, "STATEMENT", ONERECORD, "SOURCE", COMPANYID, ALIAS, ROLES, AUTHORIZATIONREQUIRED, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE) VALUES(220, 'PurdyPanelRecuperacion/{id}', 1, 'PUT', 'Actualiza un registro de la tabla PurdyPanelRecuperacion/{id} por medio de su clave', NULL, 'UPDATE', 1, 'UPDATE PurdyPanelRecuperacion SET asiges={asiges:VARCHAR2.40}, numerodesiniestro={numerodesiniestro:VARCHAR2.20}, tipodedocumento={tipodedocumento:NUMBER.5}, numerodedocumento={numerodedocumento:VARCHAR2.20}, fecharecupera={fecharecupera:DATE.0}, receptor={receptor:VARCHAR2.100}, montorecupera={montorecupera:NUMBER.18}, observacion={observacion:VARCHAR2.200}, UPDATEUSERCODE={App.UserId}, UPDATEDATE={Const.Date.Now} WHERE ID={ID:NUMBER.9:Required}', 0, 'PurdyPanelRecuperacion', 0, NULL, NULL, 0, 1, 6329, TIMESTAMP '2023-06-13 00:00:00.000000');
