using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Variaciones
{
    public class VariacionBase
    {
        public static void EvaluaAgregarOcurrencia(Dictionary<string, ValDatoVariable> diccionario, string cod_campo_count, string cod_campo_ocurrencia, string val_campo_ocurrencia)
        {
            if (val_campo_ocurrencia.IsNotEmpty())
            {
                ValDatoVariable val_dato = new ValDatoVariable();
                val_dato.val_campo = val_campo_ocurrencia.Split(',').Count().ToString();
                val_dato.tiene_ocurrencia = true;

                int index = 1;
                foreach (string item in val_campo_ocurrencia.Split(','))
                {
                    val_dato.ocurrencias.Add(new OcurrenciaVariacion { cod_campo = cod_campo_ocurrencia, val_campo = item, index = index });
                    index++;
                }

                if (!diccionario.ContainsKey(cod_campo_count))
                {
                    diccionario.Add(cod_campo_count, val_dato);
                }
            }
        }

        public static void EvaluaAgregarItem<T>(
            Dictionary<string, ValDatoVariable> diccionario,
            IEnumerable<T> lista,
            Func<T, bool> condicion,
            string nuevaClave)
            where T : class
        {
            var filtrados = lista.Where(condicion).ToList();

            if (filtrados.Any())
            {
                var prop = typeof(T).GetProperty("mcaSeleccion");
                if (prop != null)
                {
                    var valores = filtrados.Select(x => prop.GetValue(x)?.ToString()).ToList();

                    string nuevoValor = string.Empty;

                    if (valores.Any(v => v == "*"))
                        nuevoValor = "S";
                    else if (valores.All(v => v == "X"))
                        nuevoValor = "N";
                    else
                        return;

                    if (!diccionario.ContainsKey(nuevaClave))
                    {
                        diccionario.Add(nuevaClave, new ValDatoVariable { val_campo = nuevoValor, tiene_ocurrencia = false });
                    }
                }
            }
        }

    }
    public class OcurrenciaVariacion
    {
        public string cod_campo { get; set; }
        public string val_campo { get; set; }
        public int index { get; set; }
    }

    public class ValDatoVariable
    {
        public string val_campo { get; set; }
        public bool tiene_ocurrencia { get; set; }
        public List<OcurrenciaVariacion> ocurrencias { get; set; } = new List<OcurrenciaVariacion>();
    }
}
