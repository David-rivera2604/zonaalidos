-- Propósito: crea la plantilla genérica de correo usada para entregar enlaces de invitación de completado por asegurado.
-- Ejecución: aplicar una sola vez en el esquema Research aprobado después de desplegar el mecanismo de invitaciones.
-- Seguridad: el asunto no contiene datos personales ni secretos de capacidad; la URL solo se renderiza en el cuerpo HTML como Data.InvitationUrl.
-- Idempotencia: el MERGE actualiza la plantilla global cuando existe y la inserta en caso contrario.

MERGE INTO Template target
USING (
    SELECT
        0 AS CompanyId,
        'InsuredCompletionInvitation' AS TemplateKey,
        'Invitacion para completar solicitud de seguro' AS Description,
        'Complete su solicitud de seguro' AS Subject,
        q'~
<p>Hola,</p>
<p>{CurrentUser.FirstName} {CurrentUser.LastName} le ha enviado una solicitud de seguro para que la complete.</p>
<p><a href="{Data.InvitationUrl}">Completar solicitud</a></p>
<p>Por seguridad, este enlace es personal, temporal y deja de funcionar si se solicita uno nuevo.</p>
<p>Si no reconoce esta solicitud, puede ignorar este correo.</p>
~' AS Body
    FROM DUAL
) source
ON (target.CompanyId = source.CompanyId AND target.Key = source.TemplateKey)
WHEN MATCHED THEN UPDATE SET
    target.Description = source.Description,
    target.EmailTo = NULL,
    target.Subject = source.Subject,
    target.Body = source.Body,
    target.MasterTemplateId = 0,
    target.UpdateUserCode = 0,
    target.UpdateDate = SYSTIMESTAMP
WHEN NOT MATCHED THEN INSERT
    (Id, CompanyId, Key, Description, EmailTo, Subject, Body, MasterTemplateId, UpdateUserCode, UpdateDate)
VALUES
    ((SELECT NVL(MAX(Id), 0) + 1 FROM Template), source.CompanyId, source.TemplateKey,
     source.Description, NULL, source.Subject, source.Body, 0, 0, SYSTIMESTAMP);

-- Verificación: esta consulta devuelve la plantilla global activa sin exponer una URL de invitación renderizada.
SELECT Id, CompanyId, Key, Description, Subject, MasterTemplateId
FROM Template
WHERE CompanyId = 0 AND Key = 'InsuredCompletionInvitation';
