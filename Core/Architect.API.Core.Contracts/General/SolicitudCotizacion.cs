using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts
{
    /// <summary>
    /// Conozca a su cliente Datos Genericos
    /// </summary>
    public class Solicitud
    {
        public string Comentario { get; set; }
        public DatosSeguro Seguro { get; set; }
        public Persona_Solicitud Persona { get; set; }
        public DatosMoneda DatosMoneda { get; set; }
        public List<DatosCoberturas> Solicitud_Coberturas { get; set; }
        public List<DatosSumas> SumasAseguradas { get; set; }
        public DatosViaje Viajes { get; set; }
        public DatosPlan Plan { get; set; }

    }

    /// <summary>
    /// Conozca a su cliente Persona
    /// </summary>
    public class Persona_Solicitud
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string telefono { get; set; }

        public string Email { get; set; }
    }

    public class DatosCoberturas
    {
        public string Cobertura_Nombre { get; set; }
        public string Cobertura_codigo { get; set; }
        public bool Cobertura_seleccionado { get; set; }
        public int Cobertura_suma { get; set; }
        public List<string> Cobertura_tipo { get; set; }

    }
    public class DatosViaje
    {
        public string Plan { get; set; }
        public string Tipo { get; set; }
        public DateTime In_Vigencia { get; set; }
        public DateTime Fin_Vigencia { get; set; }
        public string Pais { get; set; }
        public string Modalidad { get; set; }
        public int CantidadRiesgos { get; set; }
        public List<DatosRiego> Edades { get; set; }
    }

    public class DatosSumas
    {
        public string Suma_Nombre { get; set; }
        public string Suma_codigo { get; set; }
        public int Suma_valor { get; set; }

    }

    public class DatosSeguro
    {
        public int id { get; set; }
        public string title { get; set; }

    }

    public class DatosMoneda
    {
        public int Valor { get; set; }
        public string NombreMoneda { get; set; }

    }

    public class DatosRiego
    {
        public int index { get; set; }
        public string FechaNacimiento { get; set; }
    }

    public class DatosPlan
    {
        public string PlanTitle { get; set; }
        public List<DatosCoberturas> Coberturas { get; set; }
    }

}

