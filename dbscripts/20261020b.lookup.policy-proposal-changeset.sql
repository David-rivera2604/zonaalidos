-- Registra el tipo de entidad utilizado por la auditoría funcional de solicitudes de póliza.
-- El catálogo 50 corresponde a los tipos de entidad empleados por CHANGESET.
-- La operación es idempotente y puede ejecutarse más de una vez sin duplicar el registro.


MERGE INTO ALIADOS.LOOKUP destino
USING (
    SELECT
        50 AS LOOKUPID,
        0 AS COMPANYID,
        1 AS "LANGUAGE",
        0 AS PARENTLOOKUPID,
        0 AS SUBPARENTLOOKUPID,
        2100 AS CODE,
        'Solicitud de póliza' AS DESCRIPTION,
        2100 AS QUERYORDER,
        'Solicitud de póliza' AS EXTENDSTRINGVALUE1,
        1 AS RECORDSTATUS,
        1 AS UPDATEUSERCODE
    FROM DUAL
) origen
ON (
    destino.LOOKUPID = origen.LOOKUPID
    AND destino.COMPANYID = origen.COMPANYID
    AND destino."LANGUAGE" = origen."LANGUAGE"
    AND destino.PARENTLOOKUPID = origen.PARENTLOOKUPID
    AND destino.SUBPARENTLOOKUPID = origen.SUBPARENTLOOKUPID
    AND destino.CODE = origen.CODE
)
WHEN MATCHED THEN
    UPDATE SET
        destino.DESCRIPTION = origen.DESCRIPTION,
        destino.QUERYORDER = origen.QUERYORDER,
        destino.EXTENDSTRINGVALUE1 = origen.EXTENDSTRINGVALUE1,
        destino.RECORDSTATUS = origen.RECORDSTATUS,
        destino.UPDATEUSERCODE = origen.UPDATEUSERCODE,
        destino.UPDATEDATE = SYSDATE
WHEN NOT MATCHED THEN
    INSERT (
        LOOKUPID,
        COMPANYID,
        "LANGUAGE",
        PARENTLOOKUPID,
        SUBPARENTLOOKUPID,
        CODE,
        DESCRIPTION,
        QUERYORDER,
        HOMOLOGOUSCODE,
        EXTENDNUMBERVALUE1,
        EXTENDNUMBERVALUE2,
        EXTENDSTRINGVALUE1,
        EXTENDSTRINGVALUE2,
        RECORDSTATUS,
        UPDATEUSERCODE,
        UPDATEDATE
    )
    VALUES (
        origen.LOOKUPID,
        origen.COMPANYID,
        origen."LANGUAGE",
        origen.PARENTLOOKUPID,
        origen.SUBPARENTLOOKUPID,
        origen.CODE,
        origen.DESCRIPTION,
        origen.QUERYORDER,
        NULL,
        NULL,
        NULL,
        origen.EXTENDSTRINGVALUE1,
        NULL,
        origen.RECORDSTATUS,
        origen.UPDATEUSERCODE,
        SYSDATE
    );

COMMIT;
