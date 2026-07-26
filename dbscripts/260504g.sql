-- ============================================================
-- 260504g.sql — Templates de notificaciones en tiempo real
-- SUBJECT = titulo de la notificacion
-- BODY    = mensaje (SmartFormat: {placeholder})
-- COMPANYID=0 = global todos los tenants
-- ============================================================
SET DEFINE OFF

DELETE TEMPLATE WHERE "KEY" IN (
    'Notify_ProcessReassign','Notify_ProcessAssign','Notify_ProcessOverdue',
    'Notify_PolicyIssued','Notify_PaymentFailed','Notify_DocuSignSigned','Notify_EvicertiaSigned'
);

INSERT INTO TEMPLATE (ID,COMPANYID,"KEY",DESCRIPTION,SUBJECT,"BODY",UPDATEUSERCODE,UPDATEDATE,EMAILTO,MASTERTEMPLATEID)
VALUES (3008,0,'Notify_ProcessReassign','Notificacion: Proceso reasignado',
    'El caso {caseId}, le fue reasignado',
    '{caseTitle}<br/><a href=''../cases/case?id={caseId}'' target=''_blank'' style=''font-weight:600;color:#1ab394;''>Ir al caso</a>',
    1,TIMESTAMP'2026-05-08 00:00:00',NULL,0);

INSERT INTO TEMPLATE (ID,COMPANYID,"KEY",DESCRIPTION,SUBJECT,"BODY",UPDATEUSERCODE,UPDATEDATE,EMAILTO,MASTERTEMPLATEID)
VALUES (3009,0,'Notify_ProcessAssign','Notificacion: Proceso asignado',
    'El caso {caseId}, le fue asignado',
    '{caseTitle}<br/><a href=''../cases/case?id={caseId}'' target=''_blank'' style=''font-weight:600;color:#1ab394;''>Ir al caso</a>',
    1,TIMESTAMP'2026-05-08 00:00:00',NULL,0);

INSERT INTO TEMPLATE (ID,COMPANYID,"KEY",DESCRIPTION,SUBJECT,"BODY",UPDATEUSERCODE,UPDATEDATE,EMAILTO,MASTERTEMPLATEID)
VALUES (3010,0,'Notify_ProcessOverdue','Notificacion: Paso vencido por SLA',
    'El caso {caseId}, tiene un paso vencido',
    '{caseTitle}<br/>El paso ''{stepName}'' supero el SLA.<br/><a href=''../cases/case?id={caseId}'' target=''_blank'' style=''font-weight:600;color:#e74c3c;''>Ir al caso</a>',
    1,TIMESTAMP'2026-05-08 00:00:00',NULL,0);

INSERT INTO TEMPLATE (ID,COMPANYID,"KEY",DESCRIPTION,SUBJECT,"BODY",UPDATEUSERCODE,UPDATEDATE,EMAILTO,MASTERTEMPLATEID)
VALUES (3004,0,'Notify_PolicyIssued','Notificacion: Poliza emitida',
    'La poliza {policyNumber} fue emitida',
    '{policyNumber}<br/>La poliza fue emitida exitosamente.',
    1,TIMESTAMP'2026-05-08 00:00:00',NULL,0);

INSERT INTO TEMPLATE (ID,COMPANYID,"KEY",DESCRIPTION,SUBJECT,"BODY",UPDATEUSERCODE,UPDATEDATE,EMAILTO,MASTERTEMPLATEID)
VALUES (3005,0,'Notify_PaymentFailed','Notificacion: Pago fallido',
    'Pago fallido - recibo #{receiptId}',
    'El recibo #{receiptId} no pudo procesarse.<br/>{reason}',
    1,TIMESTAMP'2026-05-08 00:00:00',NULL,0);

INSERT INTO TEMPLATE (ID,COMPANYID,"KEY",DESCRIPTION,SUBJECT,"BODY",UPDATEUSERCODE,UPDATEDATE,EMAILTO,MASTERTEMPLATEID)
VALUES (3006,0,'Notify_DocuSignSigned','Notificacion: Firma DocuSign completada',
    'La poliza {policyNumber} fue firmada via DocuSign',
    '{policyNumber}<br/>Firma digital completada via DocuSign.',
    1,TIMESTAMP'2026-05-08 00:00:00',NULL,0);

INSERT INTO TEMPLATE (ID,COMPANYID,"KEY",DESCRIPTION,SUBJECT,"BODY",UPDATEUSERCODE,UPDATEDATE,EMAILTO,MASTERTEMPLATEID)
VALUES (3007,0,'Notify_EvicertiaSigned','Notificacion: Firma Evicertia completada',
    'La solicitud #{inclusionId} fue firmada via Evicertia',
    'La solicitud #{inclusionId} fue firmada digitalmente via Evicertia.',
    1,TIMESTAMP'2026-05-08 00:00:00',NULL,0);

COMMIT;