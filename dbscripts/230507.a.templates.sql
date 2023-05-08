SET DEFINE OFF;
MERGE INTO TEMPLATE A USING
 (SELECT
  350 as ID,
  100 as COMPANYID,
  'Notify_ContactProcess_Progress' as KEY,
  'Notificación de progreso del proceso para el contacto' as DESCRIPTION,
  NULL as EMAILTO,
  'Caso #{Data.Case.Id} {Data.Case.FlowIdDesc}. Informe de progreso ({Data.Case.StatusDesc})' as SUBJECT,
  '                <table class="main" width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="alert alert-good">
                        Su caso <strong>#{Data.Case.Id}</strong> ha cambiando a la etapa <strong>"{Data.Next.StepName}".
                        </td>
                    </tr>
                    <tr>
                        <td class="content-wrap">
                            <table width="100%" cellpadding="0" cellspacing="0">

                                <tr>
                                    <td class="content-block">
                                        Estimado(a) <strong>{Data.Case.ContactMainName}</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content-block">
<p>Su caso <strong>#{Data.Case.Id}</strong> relacionado con <strong>{Data.Case.FlowIdDesc}</strong> ha cambiando a la etapa <strong>"{Data.Next.StepName}".</strong></p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="main" width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="content-wrap">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="content-block2">
                                        MAPFRE Seguros Costa Rica.
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>' as BODY,
  0 as MASTERTEMPLATEID,
  2916 as UPDATEUSERCODE,
  TO_DATE('04/28/2023 08:03:33', 'MM/DD/YYYY HH24:MI:SS') as UPDATEDATE
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
  351 as ID,
  100 as COMPANYID,
  'Notify_ResponsibleProcess_Progress' as KEY,
  'Notificación de etapa activa para los roles asociados' as DESCRIPTION,
  NULL as EMAILTO,
  'Caso #{Data.Case.Id} {Data.Case.FlowIdDesc}. Revisión  ({Data.Case.StatusDesc})' as SUBJECT,
  '<table class="main" width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td class="alert alert-good">
        La etapa <strong>"{Data.Next.StepName}"</strong>, amerita su revisión.
        </td>
    </tr>
    <tr>
        <td class="content-wrap">
            <table width="100%" cellpadding="0" cellspacing="0">

                <tr>
                    <td class="content-block">
                        Tienes <strong>una notificación</strong> de revisión.
                    </td>
                </tr>
                <tr>
                    <td class="content-block">
                        <p>El caso <strong>#{Data.Case.Id}</strong> relacionado con <strong>{Data.Case.FlowIdDesc}</strong> ha cambiando a la etapa <strong>"{Data.Next.StepName}"</strong>, dicha etapa amerita su revisión.</p>
                    </td>
                </tr>
                <tr>
                    <td class="content-block">
                        <a href="{app.url}/Cases/case?id={Data.Case.Id}" class="btn-primary">Ver Caso #{Data.Case.Id}</a>
                    </td>
                </tr>
                <tr>
                    <td class="content-block2">
                    <span style="font-size: smaller;">{Data.Spec.ReferenceCaption1}: {Data.Case.Reference1} / {Data.Spec.ReferenceCaption3}: {Data.Case.Reference3}</span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>' as BODY,
  1001 as MASTERTEMPLATEID,
  2916 as UPDATEUSERCODE,
  TO_DATE('04/28/2023 08:03:24', 'MM/DD/YYYY HH24:MI:SS') as UPDATEDATE
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
  352 as ID,
  100 as COMPANYID,
  'Notify_ResponsibleProcess_OverDue' as KEY,
  'Notificación de etapa vencida para los roles asociados' as DESCRIPTION,
  NULL as EMAILTO,
  'La etapa ''{Data.Case.StatusDesc}'' del caso #{Data.Case.Id} {Data.Case.FlowIdDesc}, ha excedido el tiempo máximo para ser atendida' as SUBJECT,
  '<table class="main" width="100%" cellpadding="0" cellspacing="0">
  <tr>
    <td class="alert alert-good">
    La etapa <strong>{Data.Next.StepName}</strong>, ha excedido el tiempo máximo para ser atendida, amerita su revisión.
    </td>
  </tr>
  <tr>
    <td class="content-wrap">
      <table width="100%" cellpadding="0" cellspacing="0">

        <tr>
          <td class="content-block">
            Tienes <strong>una notificación</strong> de vencimiento de tarea.
          </td>
        </tr>
        <tr>
          <td class="content-block">
            <p>La etapa <strong>{Data.Next.StepName}</strong>, ha excedido el tiempo máximo para ser atendida, dicha etapa amerita su revisión.</p>
          </td>
        </tr>
        <tr>
          <td class="content-block">
            <a href="{app.url}/Cases/case?id={Data.Case.Id}" class="btn-primary">Ver Caso #{Data.Case.Id}</a>
          </td>
        </tr>
        <tr>
          <td class="content-block2">
          <span style="font-size: smaller;">{Data.Spec.ReferenceCaption1}: {Data.Case.Reference1} / {Data.Spec.ReferenceCaption3}: {Data.Case.Reference3}</span>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>' as BODY,
  1001 as MASTERTEMPLATEID,
  2916 as UPDATEUSERCODE,
  TO_DATE('04/28/2023 08:03:24', 'MM/DD/YYYY HH24:MI:SS') as UPDATEDATE
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
  1001 as ID,
  0 as COMPANYID,
  'Master_Notify' as KEY,
  'Plantilla para notificaciones' as DESCRIPTION,
  NULL as EMAILTO,
  'Plantilla para notificaciones' as SUBJECT,
  '<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml"><head><meta name="viewport" content="width=device-width"><meta http-equiv="Content-Type" content="text/html; charset=UTF-8"><title>{app.url}</title></head><style>*\{margin:0;padding:0;font-family:"Helvetica Neue",Helvetica,Helvetica,Arial,sans-serif;box-sizing:border-box;font-size:14px\}img\{max-width:100%\}body\{-webkit-font-smoothing:antialiased;-webkit-text-size-adjust:none;width:100%!important;height:100%;line-height:1.6\}table td\{vertical-align:top\}body\{background-color:#f6f6f6\}.body-wrap\{background-color:#f6f6f6;width:100%\}.container\{display:block!important;max-width:600px!important;margin:0 auto!important;clear:both!important\}.content\{max-width:600px;margin:0 auto;display:block;padding:20px\}.main\{background:#fff;border:1px solid #e9e9e9;border-radius:3px\}.content-wrap\{padding:20px\}.content-block\{padding:0 0 20px\}.content-block2\{padding:0\}.header\{width:100%;margin-bottom:20px\}.footer\{width:100%;clear:both;color:#999;padding:20px\}.footer a\{color:#999\}.footer a,.footer p,.footer td,.footer unsubscribe\{font-size:12px\}h1,h2,h3\{font-family:"Helvetica Neue",Helvetica,Arial,"Lucida Grande",sans-serif;color:#000;margin:40px 0 0;line-height:1.2;font-weight:400\}h1\{font-size:32px;font-weight:500\}h2\{font-size:24px\}h3\{font-size:18px\}h4\{font-size:14px;font-weight:600\}ol,p,ul\{margin-bottom:10px;font-weight:400\}ol li,p li,ul li\{margin-left:5px;list-style-position:inside\}a\{color:#1ab394;text-decoration:underline\}.btn-primary\{text-decoration:none;color:#fff;background-color:#1ab394;border:solid #1ab394;border-width:5px 10px;line-height:2;font-weight:700;text-align:center;cursor:pointer;display:inline-block;border-radius:5px;text-transform:capitalize\}.last\{margin-bottom:0\}.first\{margin-top:0\}.aligncenter\{text-align:center\}.alignright\{text-align:right\}.alignleft\{text-align:left\}.clear\{clear:both\}.alert\{font-size:16px;color:#fff;font-weight:500;padding:20px;text-align:center;border-radius:3px 3px 0 0\}.alert a\{color:#fff;text-decoration:none;font-weight:500;font-size:16px\}.alert.alert-warning\{background:#f8ac59\}.alert.alert-bad\{background:#ed5565\}.alert.alert-good\{background:#1ab394\}.invoice\{margin:40px auto;text-align:left;width:80%\}.invoice td\{padding:5px 0\}.invoice .invoice-items\{width:100%\}.invoice .invoice-items td\{border-top:#eee 1px solid\}.invoice .invoice-items .total td\{border-top:2px solid #333;border-bottom:2px solid #333;font-weight:700\}@media only screen and (max-width:640px)\{h1,h2,h3,h4\{font-weight:600!important;margin:20px 0 5px!important\}h1\{font-size:22px!important\}h2\{font-size:18px!important\}h3\{font-size:16px!important\}.container\{width:100%!important\}.content,.content-wrap\{padding:10px!important\}.invoice\{width:100%!important\}\}</style><body><table class="body-wrap"><tr><td></td><td class="container" width="600"><div class="content">{Content}<div class="footer"><table width="100%"><tr><td class="aligncenter content-block">Por favor no responda este correo.</td></tr></table></div></div></td><td></td></tr></table></body></html>' as BODY,
  NULL as MASTERTEMPLATEID,
  6329 as UPDATEUSERCODE,
  TO_DATE('05/06/2023 00:00:00', 'MM/DD/YYYY HH24:MI:SS') as UPDATEDATE
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
