-- Propósito: persiste la invitación de privilegio mínimo, la carga completada y la bitácora de auditoría del completado por asegurado.
-- Ejecución: aplicar una sola vez en el esquema Research aprobado mediante el proceso habitual de migraciones del DBA.
-- Seguridad: SecretHash y SessionHash contienen únicamente verificadores SHA-256; nunca almacenar ni registrar capacidades en texto plano.
-- Reversión: requiere un cambio aprobado por el DBA porque las tablas conservan evidencia de completado; no eliminarlas automáticamente.

-- Las secuencias proporcionan identificadores numéricos alineados con la convención Oracle NUMBER(9) existente.
CREATE SEQUENCE SEQ_POLICYPROPOSALINVITATION START WITH 1 INCREMENT BY 1 NOCYCLE;
CREATE SEQUENCE SEQ_POLICYPROPOSALCOMPLETIONAUDIT START WITH 1 INCREMENT BY 1 NOCYCLE;

-- Una invitación autoriza a un asegurado a completar una única propuesta de póliza.
CREATE TABLE PolicyProposalInvitation
(
    Id                    NUMBER(9)          NOT NULL,
    CompanyId             NUMBER(9)          NOT NULL,
    PolicyProposalId      NUMBER(9)          NOT NULL,
    ProposalId            VARCHAR2(40 CHAR)  NOT NULL,
    RecipientEmail        VARCHAR2(320 CHAR) NOT NULL,
    SecretHash            CHAR(64 CHAR)      NOT NULL,
    SessionHash           CHAR(64 CHAR),
    Status                VARCHAR2(16 CHAR)  NOT NULL,
    ExpiresAtUtc          TIMESTAMP(6)       NOT NULL,
    SessionExpiresAtUtc   TIMESTAMP(6),
    CreatedAtUtc          TIMESTAMP(6)       NOT NULL,
    CompletedAtUtc        TIMESTAMP(6),
    RevokedAtUtc          TIMESTAMP(6),
    SendCount             NUMBER(3)          DEFAULT 1 NOT NULL,
    RowVersion            NUMBER(10)         DEFAULT 1 NOT NULL,
    CONSTRAINT PK_PolicyProposalInvitation PRIMARY KEY (Id),
    CONSTRAINT UQ_PolicyProposalInvitation_Secret UNIQUE (SecretHash),
    CONSTRAINT FK_PolicyProposalInvitation_PolicyProposal
        FOREIGN KEY (PolicyProposalId) REFERENCES PolicyProposal (Id) ON DELETE CASCADE,
    CONSTRAINT CK_PolicyProposalInvitation_Status
        CHECK (Status IN ('Active', 'Completed', 'Revoked', 'Expired')),
    CONSTRAINT CK_PolicyProposalInvitation_SendCount CHECK (SendCount >= 1)
);

CREATE INDEX IX_PolicyProposalInvitation_Proposal
    ON PolicyProposalInvitation (CompanyId, ProposalId, Status);

CREATE INDEX IX_PolicyProposalInvitation_PolicyProposal
    ON PolicyProposalInvitation (PolicyProposalId);

CREATE INDEX IX_PolicyProposalInvitation_Session
    ON PolicyProposalInvitation (SessionHash, Status);

COMMENT ON TABLE PolicyProposalInvitation IS 'Invitacion de capacidad limitada para que un asegurado complete una unica propuesta sin cuenta de usuario.';
COMMENT ON COLUMN PolicyProposalInvitation.Id IS 'Identificador NUMBER(9) obtenido de SEQ_POLICYPROPOSALINVITATION.';
COMMENT ON COLUMN PolicyProposalInvitation.CompanyId IS 'Empresa propietaria de la propuesta.';
COMMENT ON COLUMN PolicyProposalInvitation.PolicyProposalId IS 'Identificador técnico NUMBER(9) de PolicyProposal; clave foránea de la invitación.';
COMMENT ON COLUMN PolicyProposalInvitation.ProposalId IS 'Identificador de negocio de la propuesta autorizada, formado por RAMO e Id.';
COMMENT ON COLUMN PolicyProposalInvitation.RecipientEmail IS 'Correo del asegurado destinatario; no debe exponerse en trazas.';
COMMENT ON COLUMN PolicyProposalInvitation.SecretHash IS 'Verificador SHA-256 del secreto de invitacion; nunca contiene el secreto en texto plano.';
COMMENT ON COLUMN PolicyProposalInvitation.SessionHash IS 'Verificador SHA-256 de la cookie de sesion temporal; nunca contiene el secreto en texto plano.';
COMMENT ON COLUMN PolicyProposalInvitation.Status IS 'Estado del ciclo de vida: Active, Completed, Revoked o Expired.';
COMMENT ON COLUMN PolicyProposalInvitation.ExpiresAtUtc IS 'Fecha y hora UTC de vencimiento de la invitacion.';
COMMENT ON COLUMN PolicyProposalInvitation.SessionExpiresAtUtc IS 'Fecha y hora UTC de vencimiento por inactividad de la sesion restringida.';
COMMENT ON COLUMN PolicyProposalInvitation.CreatedAtUtc IS 'Fecha y hora UTC de emision de la invitacion.';
COMMENT ON COLUMN PolicyProposalInvitation.CompletedAtUtc IS 'Fecha y hora UTC de aceptacion de la entrega del asegurado.';
COMMENT ON COLUMN PolicyProposalInvitation.RevokedAtUtc IS 'Fecha y hora UTC de revocacion o reemplazo de la invitacion.';
COMMENT ON COLUMN PolicyProposalInvitation.SendCount IS 'Cantidad de correos emitidos para este registro de invitacion.';
COMMENT ON COLUMN PolicyProposalInvitation.RowVersion IS 'Version de concurrencia optimista del registro.';

-- El formulario completado se conserva solo después de la validación del servidor y del consentimiento explícito.
CREATE TABLE PolicyProposalCompletion
(
    InvitationId          NUMBER(9)          NOT NULL,
    FormVersion           VARCHAR2(64 CHAR)  NOT NULL,
    PayloadJson           CLOB               NOT NULL,
    ConsentTextVersion    VARCHAR2(64 CHAR)  NOT NULL,
    ConsentAccepted       NUMBER(1)          NOT NULL,
    CompletedAtUtc        TIMESTAMP(6)       NOT NULL,
    RowVersion            NUMBER(10)         DEFAULT 1 NOT NULL,
    CONSTRAINT PK_PolicyProposalCompletion PRIMARY KEY (InvitationId),
    CONSTRAINT FK_PolicyProposalCompletion_Invitation
        FOREIGN KEY (InvitationId) REFERENCES PolicyProposalInvitation (Id) ON DELETE CASCADE,
    CONSTRAINT CK_PolicyProposalCompletion_Consent CHECK (ConsentAccepted IN (0, 1))
);

-- Los eventos de seguridad de solo inserción permiten rastrear cambios de ciclo de vida sin conservar secretos.
CREATE TABLE PolicyProposalCompletionAudit
(
    Id                    NUMBER(9)          NOT NULL,
    InvitationId          NUMBER(9)          NOT NULL,
    EventType             VARCHAR2(32 CHAR)  NOT NULL,
    ActorType             VARCHAR2(16 CHAR)  NOT NULL,
    OccurredAtUtc         TIMESTAMP(6)       NOT NULL,
    RemoteAddress         VARCHAR2(64 CHAR),
    UserAgent             VARCHAR2(512 CHAR),
    CorrelationId         VARCHAR2(64 CHAR),
    CONSTRAINT PK_PolicyProposalCompletionAudit PRIMARY KEY (Id),
    CONSTRAINT FK_PolicyProposalCompletionAudit_Invitation
        FOREIGN KEY (InvitationId) REFERENCES PolicyProposalInvitation (Id) ON DELETE CASCADE,
    CONSTRAINT CK_PolicyProposalCompletionAudit_Actor
        CHECK (ActorType IN ('Agent', 'InsuredInvite', 'System'))
);

CREATE INDEX IX_PolicyProposalCompletionAudit_Invitation
    ON PolicyProposalCompletionAudit (InvitationId, OccurredAtUtc);

COMMENT ON TABLE PolicyProposalCompletion IS 'Carga validada y evidencia de consentimiento de una solicitud completada por el asegurado.';
COMMENT ON COLUMN PolicyProposalCompletion.InvitationId IS 'Identificador NUMBER(9) de la invitacion que autorizo la entrega.';
COMMENT ON COLUMN PolicyProposalCompletion.FormVersion IS 'Version del contrato de campos mostrado al asegurado.';
COMMENT ON COLUMN PolicyProposalCompletion.PayloadJson IS 'Carga JSON validada en servidor; no debe registrarse en trazas.';
COMMENT ON COLUMN PolicyProposalCompletion.ConsentTextVersion IS 'Version del texto de consentimiento aceptado.';
COMMENT ON COLUMN PolicyProposalCompletion.ConsentAccepted IS 'Indicador 1/0 de aceptacion explicita de consentimiento.';
COMMENT ON COLUMN PolicyProposalCompletion.CompletedAtUtc IS 'Fecha y hora UTC de aceptacion de la entrega.';
COMMENT ON COLUMN PolicyProposalCompletion.RowVersion IS 'Version de concurrencia optimista del registro.';

COMMENT ON TABLE PolicyProposalCompletionAudit IS 'Eventos de seguridad y trazabilidad del flujo de completado por asegurado.';
COMMENT ON COLUMN PolicyProposalCompletionAudit.Id IS 'Identificador NUMBER(9) obtenido de SEQ_POLICYPROPOSALCOMPLETIONAUDIT.';
COMMENT ON COLUMN PolicyProposalCompletionAudit.InvitationId IS 'Identificador NUMBER(9) de la invitacion relacionada.';
COMMENT ON COLUMN PolicyProposalCompletionAudit.EventType IS 'Nombre controlado del evento de seguridad.';
COMMENT ON COLUMN PolicyProposalCompletionAudit.ActorType IS 'Tipo de actor: Agent, InsuredInvite o System.';
COMMENT ON COLUMN PolicyProposalCompletionAudit.OccurredAtUtc IS 'Fecha y hora UTC en que ocurrio el evento.';
COMMENT ON COLUMN PolicyProposalCompletionAudit.RemoteAddress IS 'Direccion remota observada, cuando exista.';
COMMENT ON COLUMN PolicyProposalCompletionAudit.UserAgent IS 'Agente de usuario recortado, cuando exista.';
COMMENT ON COLUMN PolicyProposalCompletionAudit.CorrelationId IS 'Identificador de correlacion de la solicitud.';
