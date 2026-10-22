-- Agrega el destino interno y el flujo autorizado a las invitaciones de completado.
-- Ejecutar una única vez y únicamente mediante el proceso aprobado por el DBA.
-- Las invitaciones activas previas no tienen destino persistido y se revocan para impedir su reutilización ambigua.
ALTER TABLE PolicyProposalInvitation ADD
(
    CompletionPath VARCHAR2(512 CHAR),
    CompletionFlow VARCHAR2(64 CHAR)
);

UPDATE PolicyProposalInvitation
SET Status = 'Revoked',
    RevokedAtUtc = COALESCE(RevokedAtUtc, SYSTIMESTAMP),
    SessionHash = NULL,
    SessionExpiresAtUtc = NULL,
    RowVersion = RowVersion + 1
WHERE Status = 'Active'
  AND (CompletionPath IS NULL OR CompletionFlow IS NULL);

ALTER TABLE PolicyProposalInvitation ADD CONSTRAINT CK_PolicyProposalInvitation_ActiveDestination
    CHECK (Status <> 'Active' OR (CompletionPath IS NOT NULL AND CompletionFlow IS NOT NULL));

COMMENT ON COLUMN PolicyProposalInvitation.CompletionPath IS 'Ruta relativa interna y parámetros del destino de completado; nunca contiene secretos.';
COMMENT ON COLUMN PolicyProposalInvitation.CompletionFlow IS 'Código de flujo aprobado en servidor que limita los recursos de la sesión técnica.';
