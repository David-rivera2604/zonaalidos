-- =============================================================
-- Navegacion: Gestion de Asignacion de Casos (Visualizacion 200002)
-- Menu: Casos > Gestion de Asignacion
-- Generado: 2026-05-05
-- =============================================================

-- -------------------------------------------------------
-- 1. Entrada de navegacion
-- -------------------------------------------------------
MERGE INTO NAVIGATION N
USING (SELECT 'CASE005' AS CODE, 100 AS COMPANYID FROM DUAL) SRC
ON (N.CODE = SRC.CODE AND N.COMPANYID = SRC.COMPANYID)
WHEN MATCHED THEN UPDATE SET
    N.TITLE          = 'Gestion de Asignacion',
    N.MENUTITLE      = 'Gestion de Asignacion',
    N.DESCRIPTION    = 'Gestion y reasignacion de casos por supervisor',
    N.URLPATH        = 'viewer/viewer?id=200002',
    N.SEQUENCE       = 906,
    N.RECORDSTATUS   = 1,
    N.UPDATEUSERCODE = 6329,
    N.UPDATEDATE     = SYSDATE
WHEN NOT MATCHED THEN INSERT (
    NAVIGATIONID, COMPANYID, CODE, PARENTCODE, TYPE,
    TITLE, MENUTITLE, DESCRIPTION, URLPATH,
    SEQUENCE, RECORDSTATUS, UPDATEUSERCODE, UPDATEDATE
) VALUES (
    303, 100, 'CASE005', 'CASEMN', 2,
    'Gestion de Asignacion', 'Gestion de Asignacion', 'Gestion y reasignacion de casos por supervisor',
    'viewer/viewer?id=200002',
    906, 1, 6329, SYSDATE
);

-- -------------------------------------------------------
-- 2. Permisos de roles (mismos roles que tienen acceso a CASEMN)
-- -------------------------------------------------------
MERGE INTO ROLEMEMBERNAVIGATION RN
USING (SELECT 145 AS ROLEID, 'CASE005' AS CODE, 100 AS COMPANYID FROM DUAL) SRC
ON (RN.ROLEID = SRC.ROLEID AND RN.CODE = SRC.CODE AND RN.COMPANYID = SRC.COMPANYID)
WHEN MATCHED THEN UPDATE SET
    RN.ALLOW = 0, RN.UPDATEUSERCODE = 6329, RN.UPDATEDATE = SYSDATE
WHEN NOT MATCHED THEN INSERT (
    ID, COMPANYID, ROLEID, CODE, ALLOW, SECURITYLEVEL,
    CREATEACTION, READACTION, UPDATEACTION, DELETEACTION, LISTACTION, PRINTACTION,
    UPDATEUSERCODE, UPDATEDATE
) VALUES (
    465, 100, 145, 'CASE005', 0, 0,
    0, 0, 0, 0, 0, 0,
    6329, SYSDATE
);

MERGE INTO ROLEMEMBERNAVIGATION RN
USING (SELECT 147 AS ROLEID, 'CASE005' AS CODE, 100 AS COMPANYID FROM DUAL) SRC
ON (RN.ROLEID = SRC.ROLEID AND RN.CODE = SRC.CODE AND RN.COMPANYID = SRC.COMPANYID)
WHEN MATCHED THEN UPDATE SET
    RN.ALLOW = 0, RN.UPDATEUSERCODE = 6329, RN.UPDATEDATE = SYSDATE
WHEN NOT MATCHED THEN INSERT (
    ID, COMPANYID, ROLEID, CODE, ALLOW, SECURITYLEVEL,
    CREATEACTION, READACTION, UPDATEACTION, DELETEACTION, LISTACTION, PRINTACTION,
    UPDATEUSERCODE, UPDATEDATE
) VALUES (
    466, 100, 147, 'CASE005', 0, 0,
    0, 0, 0, 0, 0, 0,
    6329, SYSDATE
);

COMMIT;
