CREATE OR REPLACE FUNCTION ALIADOS.StringFilter  (
    p_filtro IN VARCHAR2
)
RETURN VARCHAR2
IS
    -- Bandera para verificar si se encontraron comodines
    v_contiene_comodin BOOLEAN := FALSE;
    -- Variable para almacenar el filtro modificado
    v_filtro_modificado VARCHAR2(4000);
BEGIN
    -- Manejar el caso de filtro nulo primero
    IF p_filtro IS NULL THEN
        RETURN NULL;
    END IF;

    v_filtro_modificado := p_filtro;

    -- 1. Verificar si el filtro contiene '%' o '_'
    -- Usamos LIKE para verificar si el texto contiene cualquier comodín
    -- El ESCAPE '#' asegura que los caracteres literales '%' y '_' dentro del filtro no sean tratados como comodines.
    IF p_filtro LIKE '%#%%' ESCAPE '#' OR p_filtro LIKE '%#\_%' ESCAPE '#' THEN
        v_contiene_comodin := TRUE;
    END IF;

    -- 2. Aplicar la lógica de formato
    IF v_contiene_comodin = TRUE THEN
        -- Si ya tiene comodines, se devuelve tal cual para respetar la búsqueda avanzada.
        RETURN v_filtro_modificado;
    ELSE
        -- Si NO tiene comodines:
        -- a) Reemplazar todos los espacios por '%' (comodín)
        v_filtro_modificado := REPLACE(v_filtro_modificado, ' ', '%');

        -- b) Agregar comodines al inicio y al final para asegurar la búsqueda tipo "contiene"
        RETURN '%' || v_filtro_modificado || '%';
    END IF;

EXCEPTION
    WHEN OTHERS THEN
        -- En caso de error, devolver el filtro original
        RETURN p_filtro;
END;