-- ============================================================
-- 260504f.sql — Agrega PIS.USERASSIGNED al SELECT de visualizacion 200002
-- Necesario para preseleccionar el usuario asignado en el formulario de reasignacion
-- ============================================================

UPDATE VISUALIZATIONS
   SET "STATEMENT" = REPLACE(
       "STATEMENT",
       'UM_STEP.FIRSTNAME || '' '' || UM_STEP.LASTNAME                               USUARIOETAPA,',
       'PIS.USERASSIGNED,' || CHR(10) ||
       '    UM_STEP.FIRSTNAME || '' '' || UM_STEP.LASTNAME                               USUARIOETAPA,'
   )
 WHERE ID = 200002
   AND SEQUENCE = 1
   AND "STATEMENT" LIKE '%USUARIOETAPA%'
   AND "STATEMENT" NOT LIKE '%PIS.USERASSIGNED%';

COMMIT;

SELECT CASE
           WHEN COUNT(*) > 0
           THEN 'OK - USERASSIGNED presente'
           ELSE 'ERROR - USERASSIGNED no fue agregado'
       END AS RESULTADO
  FROM VISUALIZATIONS
 WHERE ID = 200002
   AND SEQUENCE = 1
   AND "STATEMENT" LIKE '%PIS.USERASSIGNED%';
