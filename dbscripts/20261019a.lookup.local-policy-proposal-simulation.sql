-- Simulación local de catálogos para el formulario EmitirPoliza.
--
-- Este script no sustituye los catálogos de TRON. Crea maestros con prefijo s_
-- que el navegador solicita únicamente si PolicyProposal.LocalSimulation=true y
-- se ejecuta en localhost. Los identificadores 990701001 a 990701008 quedan
-- reservados para esta simulación y cumplen el límite NUMBER(9).
--
-- LOOKUPMASTER documenta el origen de cada lista:
--   LOOKUPID: identificador del maestro; KEY: clave que recibe la API;
--   DESCRIPTION: descripción funcional; TENANT=0: lista global de desarrollo;
--   TYPE: 1 obtiene registros de LOOKUP y 2 ejecuta STATEMENT;
--   STATEMENT, CONNECTIONNAME y STATEMENTTYPE definen la consulta de TYPE=2;
--   ISCACHED evita datos obsoletos durante pruebas; RECORDSTATUS controla vigencia.
-- LOOKUP documenta los valores simulados:
--   LOOKUPID relaciona el valor con su maestro; COMPANYID=0 lo hace global;
--   LANGUAGE=1 identifica el idioma; PARENTLOOKUPID establece dependencias;
--   CODE es el valor técnico, DESCRIPTION el texto visible y QUERYORDER el orden;
--   RECORDSTATUS, UPDATEUSERCODE y UPDATEDATE registran vigencia y auditoría.

MERGE INTO ALIADOS.LOOKUPMASTER destino
USING (
    SELECT 990701001 AS LOOKUPID, 'Ocupaciones simuladas para EmitirPoliza' AS DESCRIPTION,
           's_TRON_G1000100' AS "KEY", 0 AS TENANT, 1 AS "TYPE",
           CAST(NULL AS VARCHAR2(4000)) AS "STATEMENT", CAST(NULL AS VARCHAR2(100)) AS CONNECTIONNAME
      FROM DUAL
    UNION ALL
    SELECT 990701002, 'Nacionalidades simuladas para EmitirPoliza',
           's_Paises', 0, 2,
           'SELECT ''CRI'' AS CODE, DESCRIPTION FROM LOOKUP WHERE LOOKUPID = 990701002 AND COMPANYID = 0 AND LANGUAGE = 1 AND RECORDSTATUS = 1 ORDER BY QUERYORDER, DESCRIPTION',
           'Research'
      FROM DUAL
    UNION ALL
    SELECT 990701003, 'Provincias simuladas para EmitirPoliza',
           's_Provincias', 0, 1, CAST(NULL AS VARCHAR2(4000)), CAST(NULL AS VARCHAR2(100)) FROM DUAL
    UNION ALL
    SELECT 990701004, 'Cantones simulados para EmitirPoliza',
           's_Cantones', 0, 1, CAST(NULL AS VARCHAR2(4000)), CAST(NULL AS VARCHAR2(100)) FROM DUAL
    UNION ALL
    SELECT 990701005, 'Distritos simulados para EmitirPoliza',
           's_Distritos', 0, 1, CAST(NULL AS VARCHAR2(4000)), CAST(NULL AS VARCHAR2(100)) FROM DUAL
    UNION ALL
    SELECT 990701006, 'Parentescos simulados para EmitirPoliza',
           's_Relationship', 0, 1, CAST(NULL AS VARCHAR2(4000)), CAST(NULL AS VARCHAR2(100)) FROM DUAL
    UNION ALL
    SELECT 990701007, 'Planes simulados para EmitirPoliza',
           's_TRON_TAVID000', 0, 1, CAST(NULL AS VARCHAR2(4000)), CAST(NULL AS VARCHAR2(100)) FROM DUAL
    UNION ALL
    SELECT 990701008, 'Contrato simulado para Vida Colectivo',
           's_Contratos_v2', 0, 2,
           'SELECT ''99340'' AS CODE, ''DINAMICA CORREDORA CRC 99340'' AS DESCRIPTION, ''1170000000008'' AS NUM_POLIZA, ''COLONES'' AS NOM_MON, ''01/03/2027'' AS FEC_VCTO_POLIZA, ''11701'' AS MODALIDAD FROM DUAL WHERE {cod_ramo} = 117',
           'Research'
) origen
ON (destino.LOOKUPID = origen.LOOKUPID)
WHEN MATCHED THEN UPDATE SET
    destino.DESCRIPTION = origen.DESCRIPTION,
    destino."KEY" = origen."KEY",
    destino.TENANT = origen.TENANT,
    destino.RECORDSTATUS = 1,
    destino."TYPE" = origen."TYPE",
    destino."STATEMENT" = origen."STATEMENT",
    destino.CONNECTIONNAME = origen.CONNECTIONNAME,
    destino.ISCACHED = 0,
    destino.STATEMENTTYPE = 1,
    destino.UPDATEUSERCODE = 1,
    destino.UPDATEDATE = SYSTIMESTAMP
WHEN NOT MATCHED THEN INSERT
    (LOOKUPID, DESCRIPTION, "KEY", TENANT, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE,
     "STATEMENT", CONNECTIONNAME, "TYPE", INCLUDEBYROLE, EXCLUDEBYROLE, ISCACHED, STATEMENTTYPE, FIELDS)
VALUES
    (origen.LOOKUPID, origen.DESCRIPTION, origen."KEY", origen.TENANT, 1, 1, SYSTIMESTAMP,
     origen."STATEMENT", origen.CONNECTIONNAME, origen."TYPE", NULL, NULL, 0, 1, NULL);

MERGE INTO ALIADOS.LOOKUP destino
USING (
    SELECT 990701001 AS LOOKUPID, 9001 AS CODE, 'Ocupación de prueba' AS DESCRIPTION,
           0 AS PARENTLOOKUPID, 1 AS QUERYORDER FROM DUAL
    UNION ALL SELECT 990701001, 6003, 'Ocupación simulada 6003', 0, 2 FROM DUAL
    UNION ALL SELECT 990701002, 1, 'Costa Rica', 0, 1 FROM DUAL
    UNION ALL SELECT 990701003, 1, 'Provincia de prueba', 0, 1 FROM DUAL
    UNION ALL SELECT 990701004, 101, 'Cantón de prueba', 1, 1 FROM DUAL
    UNION ALL SELECT 990701005, 10101, 'Distrito de prueba', 101, 1 FROM DUAL
    UNION ALL SELECT 990701006, 1, 'Hijo(a)', 0, 1 FROM DUAL
    UNION ALL SELECT 990701007, 1, 'Plan de prueba', 0, 1 FROM DUAL
) origen
ON (destino.LOOKUPID = origen.LOOKUPID
    AND destino.COMPANYID = 0
    AND destino.LANGUAGE = 1
    AND destino.CODE = origen.CODE
    AND destino.PARENTLOOKUPID = origen.PARENTLOOKUPID)
WHEN MATCHED THEN UPDATE SET
    destino.DESCRIPTION = origen.DESCRIPTION,
    destino.QUERYORDER = origen.QUERYORDER,
    destino.RECORDSTATUS = 1,
    destino.UPDATEUSERCODE = 1,
    destino.UPDATEDATE = SYSTIMESTAMP
WHEN NOT MATCHED THEN INSERT
    (LOOKUPID, COMPANYID, LANGUAGE, PARENTLOOKUPID, SUBPARENTLOOKUPID,
     CODE, DESCRIPTION, QUERYORDER, HOMOLOGOUSCODE, EXTENDNUMBERVALUE1,
     EXTENDNUMBERVALUE2, EXTENDSTRINGVALUE1, EXTENDSTRINGVALUE2, RECORDSTATUS,
     UPDATEUSERCODE, UPDATEDATE)
VALUES
    (origen.LOOKUPID, 0, 1, origen.PARENTLOOKUPID, 0,
     origen.CODE, origen.DESCRIPTION, origen.QUERYORDER, NULL, NULL,
     NULL, NULL, NULL, 1,
     1, SYSTIMESTAMP);

COMMIT;
