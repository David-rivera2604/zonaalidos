-- Cuenta técnica del mecanismo de completado de solicitudes por asegurado.
--
-- La clave incluye el identificador del tenant para que cada compañía pueda definir
-- explícitamente la cuenta con la que se genera el token temporal del asegurado.
-- La configuración se almacena en SETTINGS y no en Web.config, por lo que puede
-- administrarse por ambiente sin publicar secretos ni valores operativos en archivos.
--
-- SETTINGS.DESCRIPTION documenta el propósito funcional; COMPANYID=0 conserva el
-- valor como configuración global identificada por tenant. LOCALSTORAGEENABLED=0 y
-- TOKENENABLED=0 impiden que el identificador interno de la cuenta se exponga al navegador.

MERGE INTO SETTINGS destino
USING (
    SELECT 'PolicyProposal.InsuredCompletion.Tenant.100.UserId' AS "KEY",
           '999999006' AS VALUE,
           'Descripción funcional: identificador de la cuenta técnica usada para crear el token temporal de completado de solicitudes del tenant 100.' AS DESCRIPTION
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
