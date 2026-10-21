-- Agrega el código de ramo de forma opcional para solicitudes creadas por Altas/Bajas.
-- Los procesos que no informan el ramo conservan el valor nulo durante esta liberación.
ALTER TABLE PolicyProposal ADD (BranchCode NUMBER(5,0) NULL);

COMMENT ON COLUMN PolicyProposal.BranchCode IS
    'Código numérico del ramo de seguros que originó la solicitud; opcional para procesos fuera de Altas/Bajas.';
