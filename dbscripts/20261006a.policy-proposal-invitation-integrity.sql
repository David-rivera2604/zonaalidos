-- Refuerza la integridad de la invitación con la solicitud técnica y habilita el borrado en cascada.
-- Ejecutar una única vez únicamente en ambientes de desarrollo donde el mecanismo aún no ha sido liberado.
-- Las invitaciones existentes son datos de prueba; se eliminan antes de crear la columna obligatoria y sus restricciones.

-- Se eliminan primero los dependientes para respetar las claves foráneas vigentes.
DELETE FROM PolicyProposalCompletionAudit;
DELETE FROM PolicyProposalCompletion;
DELETE FROM PolicyProposalInvitation;

-- El agente responsable se obtiene desde PolicyProposal mediante PolicyProposalId; la invitación no mantiene una copia.
ALTER TABLE PolicyProposalInvitation DROP COLUMN AgentCode;

-- Cada nueva invitación conserva la clave técnica NUMBER(9) de su solicitud propietaria.
ALTER TABLE PolicyProposalInvitation ADD (PolicyProposalId NUMBER(9) NOT NULL);

-- Se reemplazan las referencias de hijos para que una eliminación de la solicitud propague el borrado completo.
ALTER TABLE PolicyProposalCompletion DROP CONSTRAINT FK_PolicyProposalCompletion_Invitation;
ALTER TABLE PolicyProposalCompletionAudit DROP CONSTRAINT FK_PolicyProposalCompletionAudit_Invitation;

ALTER TABLE PolicyProposalInvitation ADD CONSTRAINT FK_PolicyProposalInvitation_PolicyProposal
    FOREIGN KEY (PolicyProposalId) REFERENCES PolicyProposal (Id) ON DELETE CASCADE;

ALTER TABLE PolicyProposalCompletion ADD CONSTRAINT FK_PolicyProposalCompletion_Invitation
    FOREIGN KEY (InvitationId) REFERENCES PolicyProposalInvitation (Id) ON DELETE CASCADE;

ALTER TABLE PolicyProposalCompletionAudit ADD CONSTRAINT FK_PolicyProposalCompletionAudit_Invitation
    FOREIGN KEY (InvitationId) REFERENCES PolicyProposalInvitation (Id) ON DELETE CASCADE;

CREATE INDEX IX_PolicyProposalInvitation_PolicyProposal
    ON PolicyProposalInvitation (PolicyProposalId);

COMMENT ON COLUMN PolicyProposalInvitation.PolicyProposalId IS 'Identificador técnico NUMBER(9) de PolicyProposal; clave foránea de la invitación.';
COMMENT ON COLUMN PolicyProposalInvitation.ProposalId IS 'Identificador de negocio de la propuesta autorizada, formado por RAMO e Id.';
