using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Emision
{
    public class MapfreMas : Cotizacion.MapfreMas
    {
        /// <summary>
        /// No. de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string num_poliza { get; set; }

        /// <summary>
        /// Cilindraje del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public string DES_TIP_CILINDRAJE { get; set; }
        /// <summary>
        /// Peso del vehiculo.
        /// </summary>
        [DataMember(), JsonProperty()] public int VAL_PESO { get; set; }
        /// <summary>
        /// Color del vehiculo.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_COLOR { get; set; }
        [DataMember(), JsonProperty()] public string COD_COLORDesc { get; set; }
        /// <summary>
        /// Capacidad del vehiculo.
        /// </summary>
        [DataMember(), JsonProperty()] public int VAL_CAPACIDAD { get; set; }


        /// <summary>
        /// Correo principal.
        /// </summary>
        [DataMember(), JsonProperty()] public string correoprincipal { get; set; }
        /// <summary>
        /// Correo copia 1.
        /// </summary>
        [DataMember(), JsonProperty()] public string correocopia1 { get; set; }
        /// <summary>
        /// Correo copia 2.
        /// </summary>
        [DataMember(), JsonProperty()] public string correocopia2 { get; set; }

        /// <summary>
        /// Terceros
        /// </summary>
        [DataMember(), JsonProperty()] public List<MapfreMasterceros> terceros { get; set; }

        /// <summary>
        /// Documentos requeridos
        /// </summary>
        [DataMember(), JsonProperty()] public List<MapfreMasdocumentosrequeridos> documentosrequeridos { get; set; }


        [DataMember(), JsonProperty()] public string tip_firma { get; set; } = "";
        [DataMember(), JsonProperty()] public string tip_firmaDesc { get; set; }

        [DataMember(), JsonProperty()] public string correoenvio { get; set; }

        [DataMember(), JsonProperty()] public bool Cliente_Mapfre { get; set; } = false;
        [DataMember(), JsonProperty()] public bool Cliente_Nuevo { get; set; } = false;
        [DataMember(), JsonProperty()] public bool Actualizacion_Cliente { get; set; } = false;
        [DataMember(), JsonProperty()] public string Tipo_Kilomentraje { get; set; } = "Km";
        [DataMember(), JsonProperty()] public string Vehiculo_Otra_Poliza { get; set; } = "N";
        [DataMember(), JsonProperty()] public string Modalidad_Pago { get; set; } = "DEPCM";
        [DataMember(), JsonProperty()] public string Tipo_Licencia { get; set; } = "B1";
        [DataMember(), JsonProperty()] public string Tiempo_Licencia { get; set; }
        [DataMember(), JsonProperty()] public string Fuente_Tomador { get; set; } = "SCOTIABANK";

        [DataMember(), JsonProperty()] public string Modo { get; set; }

    }

    public class MapfreMasterceros
    {

        /// <summary>
        /// Id.
        /// </summary>
        [DataMember(), JsonProperty()] public int tercerosId { get; set; }
        /// <summary>
        /// Tipo de tercero.
        /// </summary>
        [DataMember(), JsonProperty()] public int tipodetercero { get; set; }
        [DataMember(), JsonProperty()] public string tipodeterceroDesc { get; set; }

        /// <summary>
        /// Tipo de identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public int DocumentNumberType { get; set; }
        /// <summary>
        /// Identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string DocumentNumber { get; set; }
        /// <summary>
        /// Nombre.
        /// </summary>
        [DataMember(), JsonProperty()] public string nombre { get; set; }
        /// <summary>
        /// Apellido 1.
        /// </summary>
        [DataMember(), JsonProperty()] public string apellido1 { get; set; }
        /// <summary>
        /// Apellido 2.
        /// </summary>
        [DataMember(), JsonProperty()] public string apellido2 { get; set; }
        /// <summary>
        /// Fecha de nacimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fechadenacimiento { get; set; }
        /// <summary>
        /// Sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public int tercerosMca_sexo { get; set; }
        [DataMember(), JsonProperty()] public string tercerosMca_sexoDesc { get; set; }

        /// <summary>
        /// Estado Civil.
        /// </summary>
        [DataMember(), JsonProperty()] public string estadoCivil { get; set; }
        [DataMember(), JsonProperty()] public string estadoCivilDesc { get; set; }

        /// <summary>
        /// Número de teléfono.
        /// </summary>
        [DataMember(), JsonProperty()] public string numerodetelefono { get; set; }
        /// <summary>
        /// Correo electrónico.
        /// </summary>
        [DataMember(), JsonProperty()] public string correoelectronico { get; set; }
        /// <summary>
        /// País.
        /// </summary>
        [DataMember(), JsonProperty()] public string cod_pais { get; set; }
        /// <summary>
        /// Provincia.
        /// </summary>
        [DataMember(), JsonProperty()] public int TProvincia { get; set; }
        [DataMember(), JsonProperty()] public string TProvinciaDesc { get; set; }
        /// <summary>
        /// Cantón.
        /// </summary>
        [DataMember(), JsonProperty()] public int TCanton { get; set; }
        [DataMember(), JsonProperty()] public string TCantonDesc { get; set; }

        /// <summary>
        /// Distrito.
        /// </summary>
        [DataMember(), JsonProperty()] public int TDistrito { get; set; }
        [DataMember(), JsonProperty()] public string TDistritoDesc { get; set; }
        /// <summary>
        /// Otra señas.
        /// </summary>
        [DataMember(), JsonProperty()] public string otrasenas { get; set; }
        /// <summary>
        /// El tomador es el mismo asegurado.
        /// </summary>
        [DataMember(), JsonProperty()] public int eltomadoreselmismoasegurado { get; set; }
        /// <summary>
        /// El asegurado es el conductor habitual.
        /// </summary>
        [DataMember(), JsonProperty()] public int elaseguradoeselconductorhabitual { get; set; }
        /// <summary>
        /// Número de prestamo.
        /// </summary>
        [DataMember(), JsonProperty()] public string numerodeprestamo { get; set; }
        /// <summary>
        /// Importe de cesión.
        /// </summary>
        [DataMember(), JsonProperty()] public double importedecesion { get; set; }
        /// <summary>
        /// Vencimiento de cesión.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime vencimientodecesion { get; set; }
        /// <summary>
        /// Porcentaje acredor.
        /// </summary>
        [DataMember(), JsonProperty()] public int porcentajeacredor { get; set; }
        /// <summary>
        /// Parentesco.
        /// </summary>
        [DataMember(), JsonProperty()] public int parentesco { get; set; }
        [DataMember(), JsonProperty()] public string parentescoDesc { get; set; }
        /// <summary>
        /// Porcentaje.
        /// </summary>
        [DataMember(), JsonProperty()] public int porcentaje { get; set; }
        [DataMember(), JsonProperty()] public bool NoEditable { get; set; }

    }

    public class MapfreMasdocumentosrequeridos
    {

        /// <summary>
        /// Id.
        /// </summary>
        [DataMember(), JsonProperty()] public int documentosrequeridosId { get; set; }
        /// <summary>
        /// Estado.
        /// </summary>
        [DataMember(), JsonProperty()] public string DStored { get; set; }
        /// <summary>
        /// Tipo de documento.
        /// </summary>
        [DataMember(), JsonProperty()] public string tipo { get; set; }
        /// <summary>
        /// Archivo.
        /// </summary>
        [DataMember(), JsonProperty()] public string DNombre { get; set; }
        /// <summary>
        /// Archivoeseperado.
        /// </summary>
        [DataMember(), JsonProperty()] public string DArchivoEsperado { get; set; }
        /// <summary>
        /// Grupo.
        /// </summary>
        [DataMember(), JsonProperty()] public string Grupo { get; set; }
        /// <summary>
        /// Fecha.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime DFecha { get; set; }
        /// <summary>
        /// Tamaño.
        /// </summary>
        [DataMember(), JsonProperty()] public int DTamano { get; set; }
        /// <summary>
        /// Descripción del documento.
        /// </summary>
        [DataMember(), JsonProperty()] public string DDescripcion { get; set; }

    }

    public class MapfreMasSolicitud : MapfreMas
    {
        [DataMember(), JsonProperty()] public MapfreMasterceros titular { get; set; }
        [DataMember(), JsonProperty()] public MapfreMasterceros asegurado { get; set; }
        [DataMember(), JsonProperty()] public MapfreMasterceros conductor { get; set; }
        [DataMember(), JsonProperty()] public MapfreMasterceros beneficiario1 { get; set; }
        [DataMember(), JsonProperty()] public MapfreMasterceros beneficiario2 { get; set; }
        [DataMember(), JsonProperty()] public MapfreMasterceros acredor { get; set; }

        [DataMember(), JsonProperty()] public string mainrole { get; set; }
        
    }

}
