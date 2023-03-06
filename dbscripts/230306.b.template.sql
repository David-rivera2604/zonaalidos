SET DEFINE OFF;
MERGE INTO TEMPLATE A USING
 (SELECT
  500 as ID,
  0 as COMPANYID,
  'Send_Certificate' as KEY,
  'Envio del certificado de una póliza emitida' as DESCRIPTION,
  NULL as EMAILTO,
  'Notificación de Certificado de Póliza' as SUBJECT,
  '<p>Estimado(a) Asegurado(a),<br /><br /><br />Para <strong>MAPFRE Seguros Costa Rica</strong> es un placer atenderle en su póliza de seguro y al mismo tiempo agradecemos la confianza y preferencia que ha depositado en nosotros.<br /><br />Nos permitimos remitir el certificado de seguro correspondiente a su póliza número <strong>{Data.num_poliza}</strong> mismo que considera los términos y condiciones aplicables para el periodo en vigencia.<br /><br />Quedamos a su entera disposición para cualquier consulta. Contáctenos a través de los siguientes medios:<br /><br /></p>
<ul>
<li>Linea Gratuita 800 MAPFRE(8000 627373)</li>
<li>Central Telefónica 4104-0200</li>
<li><a href="mailto:servicioalcliente@mapfrecr.com" target="_blank" rel="noopener">servicioalcliente@mapfrecr.com</a></li>
</ul>
<p><br /><br />Estamos en la mejor disposición de brindarle el mejor servicio.<br /><br /></p>
<center><strong>Atentamente,</strong></center><center><strong>MAPFRE Seguros Costa Rica</strong></center>' as BODY,
  NULL as MASTERTEMPLATEID,
  6329 as UPDATEUSERCODE,
  TO_DATE('02/07/1970 00:00:00', 'MM/DD/YYYY HH24:MI:SS') as UPDATEDATE
  FROM DUAL) B
ON (A.ID = B.ID)
WHEN NOT MATCHED THEN 
INSERT (
  ID, COMPANYID, KEY, DESCRIPTION, EMAILTO, 
  SUBJECT, BODY, MASTERTEMPLATEID, UPDATEUSERCODE, UPDATEDATE)
VALUES (
  B.ID, B.COMPANYID, B.KEY, B.DESCRIPTION, B.EMAILTO, 
  B.SUBJECT, B.BODY, B.MASTERTEMPLATEID, B.UPDATEUSERCODE, B.UPDATEDATE)
WHEN MATCHED THEN
UPDATE SET 
  A.COMPANYID = B.COMPANYID,
  A.KEY = B.KEY,
  A.DESCRIPTION = B.DESCRIPTION,
  A.EMAILTO = B.EMAILTO,
  A.SUBJECT = B.SUBJECT,
  A.BODY = B.BODY,
  A.MASTERTEMPLATEID = B.MASTERTEMPLATEID,
  A.UPDATEUSERCODE = B.UPDATEUSERCODE,
  A.UPDATEDATE = B.UPDATEDATE;

MERGE INTO TEMPLATE A USING
 (SELECT
  2007 as ID,
  2 as COMPANYID,
  'Control_Tecnico' as KEY,
  'Envia de observaciones sobre controles técnicos' as DESCRIPTION,
  NULL as EMAILTO,
  'Notificación control técnico' as SUBJECT,
  '<font face=''tahoma'' size=2>Estimado(a) Usuario(a),</font>
<br />
<br />
<br />

<font face=''tahoma'' size=2>Nos permitimos informarle que para la póliza: </font><font face=''tahoma'' size=2><b>{Data.num_poliza}</b></font><font face=''tahoma'' size=2></font>
<br />
<br />
<font face=''tahoma'' size=2>Se encuentra en un estatus de pendiente de procesar por el siguiente motivo: {Data.observacion}</font>
<br />
<br />

<br />
<br />
<font face=''tahoma'' size=2>Estamos en la mejor disposición de brindarle el mejor servicio.</font>
<br />
<br />
<center><font face=''tahoma'' size=2><b>Atentamente,</b></font></center>
<center><font face=''tahoma'' size=2><b>MAPFRE Seguros Costa Rica</b></font></center>
' as BODY,
  0 as MASTERTEMPLATEID,
  254 as UPDATEUSERCODE,
  TO_DATE('03/06/2023 13:17:57', 'MM/DD/YYYY HH24:MI:SS') as UPDATEDATE
  FROM DUAL) B
ON (A.ID = B.ID)
WHEN NOT MATCHED THEN 
INSERT (
  ID, COMPANYID, KEY, DESCRIPTION, EMAILTO, 
  SUBJECT, BODY, MASTERTEMPLATEID, UPDATEUSERCODE, UPDATEDATE)
VALUES (
  B.ID, B.COMPANYID, B.KEY, B.DESCRIPTION, B.EMAILTO, 
  B.SUBJECT, B.BODY, B.MASTERTEMPLATEID, B.UPDATEUSERCODE, B.UPDATEDATE)
WHEN MATCHED THEN
UPDATE SET 
  A.COMPANYID = B.COMPANYID,
  A.KEY = B.KEY,
  A.DESCRIPTION = B.DESCRIPTION,
  A.EMAILTO = B.EMAILTO,
  A.SUBJECT = B.SUBJECT,
  A.BODY = B.BODY,
  A.MASTERTEMPLATEID = B.MASTERTEMPLATEID,
  A.UPDATEUSERCODE = B.UPDATEUSERCODE,
  A.UPDATEDATE = B.UPDATEDATE;

COMMIT;
