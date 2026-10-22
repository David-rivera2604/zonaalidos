-- La secuencia de PolicyProposal se libera en un cambio independiente para simplificar este despliegue.
-- Mientras tanto, la aplicación conserva el patrón histórico MAX(Id) + 1 para identificadores NUMBER(9).
COMMENT ON TABLE PolicyProposal IS 'Almacena las solicitudes de póliza y su ciclo de borrador, firma y emisión.';
COMMENT ON COLUMN PolicyProposal.Id IS 'Identificador NUMBER(9) asignado temporalmente por el patrón histórico MAX(Id) + 1.';
COMMENT ON COLUMN PolicyProposal.Status IS 'Estado del ciclo de solicitud: incompleta, complementos, firma, emisión o alta.';
COMMENT ON COLUMN PolicyProposal.ProposalData IS 'Instantánea JSON de los datos de la solicitud utilizada para firma y emisión.';
COMMENT ON COLUMN PolicyProposal.SigningRequestId IS 'Identificador de la solicitud remitida al proveedor de firma electrónica.';
COMMENT ON COLUMN PolicyProposal.PolicyId IS 'Identificador de póliza asignado al concluir una emisión exitosa.';
COMMENT ON COLUMN PolicyProposal.UpdateUserCode IS 'Usuario agente, empleado o técnico que realizó la última transición.';
COMMENT ON COLUMN PolicyProposal.UpdateDate IS 'Fecha y hora de la última actualización del ciclo de solicitud.';
