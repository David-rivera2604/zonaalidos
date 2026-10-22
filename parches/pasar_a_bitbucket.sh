#!/usr/bin/env bash
set -e

ORIGEN="$(cd "$(dirname "$0")/.." && pwd)"
DESTINO="${1:-}"

if [ -z "$DESTINO" ] || [ ! -d "$DESTINO/webapp" ]; then
    echo "Uso: bash pasar_a_bitbucket.sh /c/bitbucket/Aliados"
    exit 1
fi

ARCHIVOS=(
    "webapp/app/css/mapfre.css"
    "webapp/Scripts/Cotizacion.js"
    "webapp/Scripts/Emision.AccidentesPersonales.js"
    "webapp/Scripts/Emision.Estudiantil.js"
    "webapp/Scripts/Emision.HogarTotal.js"
    "webapp/Scripts/Emision.MapfreMas.js"
    "webapp/Scripts/Emision.MapfreMasPlus.js"
    "webapp/Scripts/Emision.Multirriesgo.js"
    "webapp/Scripts/Emision.SaldoDeudor.js"
    "webapp/Scripts/Emision.Viajero.js"
    "webapp/Scripts/HogarTotal.Emision.js"
    "webapp/Scripts/Multirriesgo.Emision.js"
    "webapp/Views/Clientes/CompraSegurosC.cshtml"
    "webapp/Views/Clientes/CompraSegurosE.cshtml"
    "webapp/Views/Cotizacion/AccidentesPersonales.cshtml"
    "webapp/Views/Cotizacion/Estudiantil.cshtml"
    "webapp/Views/Cotizacion/MapfreMas.cshtml"
    "webapp/Views/Cotizacion/MapfreMasPlus.cshtml"
    "webapp/Views/Cotizacion/PolizaLider.cshtml"
    "webapp/Views/Cotizacion/SaldoDeudor.cshtml"
    "webapp/Views/Cotizacion/Viajero.cshtml"
    "webapp/Views/Cotizacion/hogartotal.cshtml"
    "webapp/Views/Cotizacion/multirriesgo.cshtml"
    "webapp/Views/Emision/AccidentesPersonales.cshtml"
    "webapp/Views/Emision/Estudiantil.cshtml"
    "webapp/Views/Emision/MapfreMas.cshtml"
    "webapp/Views/Emision/MapfreMasPlus.cshtml"
    "webapp/Views/Emision/SaldoDeudor.cshtml"
    "webapp/Views/Emision/Viajero.cshtml"
    "webapp/Views/Emision/_resumen.cshtml"
    "webapp/Views/Emision/hogartotal.cshtml"
    "webapp/Views/Emision/multirriesgo.cshtml"
    "webapp/Views/Funerario/Cotizacion.cshtml"
    "webapp/Views/HogarTotal/Cotizacion.cshtml"
    "webapp/Views/HogarTotal/Emision.cshtml"
    "webapp/Views/Multirriesgo/Cotizacion.cshtml"
    "webapp/Views/Multirriesgo/Emision.cshtml"
    "webapp/Views/Variaciones/HogarTotal.cshtml"
    "webapp/Views/Variaciones/HogarTotalPlus.cshtml"
    "webapp/Views/Variaciones/MapfreMasOld.cshtml"
    "webapp/Views/Variaciones/MapfreMasPlus.cshtml"
    "webapp/Views/Variaciones/Multirriesgo.cshtml"
    "webapp/locales/Emision/Viajero.en.json"
)

copiados=0
faltan=0
for f in "${ARCHIVOS[@]}"; do
    fuente="$ORIGEN/$f"
    if [ ! -f "$fuente" ] && [ -f "$ORIGEN/WebApp/${f#webapp/}" ]; then
        fuente="$ORIGEN/WebApp/${f#webapp/}"
    fi
    if [ ! -f "$fuente" ]; then
        echo "No existe en GitHub: $f"
        faltan=$((faltan + 1))
        continue
    fi
    if [ ! -d "$(dirname "$DESTINO/$f")" ]; then
        echo "No existe la carpeta en Bitbucket: $(dirname "$f")"
        faltan=$((faltan + 1))
        continue
    fi
    cp "$fuente" "$DESTINO/$f"
    copiados=$((copiados + 1))
done

echo ""
echo "Copiados: $copiados de ${#ARCHIVOS[@]}"
if [ "$faltan" -gt 0 ]; then
    echo "Con problemas: $faltan (revise los mensajes de arriba)"
fi
