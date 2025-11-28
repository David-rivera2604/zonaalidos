CREATE OR REPLACE FUNCTION ALIADOS.calcular_dias(
    p_fecha_inicio DATE,
    p_fecha_fin DATE DEFAULT NULL,
    p_excluir_fines_de_semana CHAR DEFAULT 'N'
) RETURN NUMBER IS
    v_fecha_fin DATE;
    v_contador NUMBER;
    v_fecha_actual DATE;
BEGIN
    -- Si la fecha_fin es NULL, usar la fecha actual
    v_fecha_fin := NVL(p_fecha_fin, SYSDATE);

    -- Asegurar que la fecha de inicio no sea mayor que la fecha de fin
    IF p_fecha_inicio > v_fecha_fin THEN
        RETURN 0; -- Retorna 0 si las fechas están en orden incorrecto
    END IF;

    -- Si no se excluyen los fines de semana, devolver la diferencia de días directamente
    IF p_excluir_fines_de_semana = 'N' THEN
        RETURN TRUNC(v_fecha_fin) - TRUNC(p_fecha_inicio);
    END IF;

    -- Si se excluyen fines de semana, recorrer los días y contar solo los hábiles
    v_fecha_actual := p_fecha_inicio;
    v_contador := 0;
    WHILE v_fecha_actual <= v_fecha_fin LOOP
        -- Verificar si el día NO es sábado (7) ni domingo (1)
        IF TO_CHAR(v_fecha_actual, 'D') NOT IN ('7', '1') THEN
            v_contador := v_contador + 1;
        END IF;
        -- Avanzar al siguiente día
        v_fecha_actual := v_fecha_actual + 1;
    END LOOP;

    RETURN v_contador;
END calcular_dias;