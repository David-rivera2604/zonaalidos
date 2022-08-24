using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    /// <summary>
    /// Información del cliente y figuras dentro de la póliza
    /// </summary>
    public class Tercero
    {
        public int tipodetercero { get; set; }
        public string tipodeterceroDesc { get; set; }
        public string numeroderiesgo { get; set; }
        public int tipoDocumentacion { get; set; }
        public string numeroDocumentacion { get; set; }
        public string DocumentacionTributaria { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public DateTime fechadenacimiento { get; set; }
        public string tercerosMca_sexo { get; set; }
        public string tercerosMca_sexoDesc { get; set; }
        public string estadoCivil { get; set; }
        public string estadoCivilDesc { get; set; }
        public string numerodetelefono { get; set; }
        public string correoelectronico { get; set; }
        public List<Domicilio> domicilio { get; set; }
        public string numerodeprestamo { get; set; }
        public int importedecesion { get; set; }
        public DateTime vencimientodecesion { get; set; }
        public int porcentajeacredor { get; set; }
        public string parentesco { get; set; }
        public string parentescoDesc { get; set; }
        public int porcentaje { get; set; }
    }
}
