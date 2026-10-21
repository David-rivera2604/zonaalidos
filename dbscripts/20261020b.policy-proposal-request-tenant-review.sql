-- Configuración exclusiva del monitor de solicitudes de póliza.
--
-- La clave PolicyProposal.Request.Tenant.Review define los tenant separados por coma
-- que el monitor debe revisar para procesar entregas de firma, firmas confirmadas y
-- emisiones automáticas. No reutiliza la configuración de información de agentes TRON.
--
-- SETTINGS.DESCRIPTION documenta el propósito funcional de la configuración; COMPANYID=0
-- la hace global, LOCALSTORAGEENABLED=0 evita exponerla al navegador y TOKENENABLED=0
-- evita incluirla en el token de sesión.

MERGE INTO SETTINGS destino
USING (
    SELECT 'PolicyProposal.Request.Tenant.Review' AS "KEY",
           '100' AS VALUE,
           'Descripción funcional: lista de tenant que el monitor de solicitudes de póliza debe revisar para procesar firma y emisión.' AS DESCRIPTION
      FROM DUAL
) origen
ON (destino."KEY" = origen."KEY" AND destino.COMPANYID = 0)
WHEN MATCHED THEN UPDATE SET
    destino.VALUE = origen.VALUE,
    destino.DESCRIPTION = origen.DESCRIPTION,
    destino.RECORDSTATUS = 1,
    destino.LOCALSTORAGEENABLED = 0,
    destino.TOKENENABLED = 0,
    destino.UPDATEDATE = SYSTIMESTAMP
WHEN NOT MATCHED THEN INSERT
    (ID, "KEY", VALUE, RECORDSTATUS, COMPANYID, UPDATEUSERCODE, UPDATEDATE,
     LOCALSTORAGEENABLED, TOKENENABLED, DESCRIPTION)
VALUES
    ((SELECT NVL(MAX(ID), 0) + 1 FROM SETTINGS), origen."KEY", origen.VALUE,
     1, 0, 1, SYSTIMESTAMP, 0, 0, origen.DESCRIPTION);

COMMIT;
