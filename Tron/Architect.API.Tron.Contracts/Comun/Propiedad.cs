using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Comun
{
    /// <summary>
    /// Información de la propiedad a asegurar
    /// </summary>
    public class propiedad
    {
        /// <summary>
        /// Propiedad ID
        /// </summary>
        [DataMember(), JsonProperty()] public int propiedadId { get; set; }

        /// <summary>
        /// Tipo plan.
        /// </summary>
        [DataMember(), JsonProperty()] public int tipoplan { get; set; }

        ///  <summary>
        ///  Otras señas
        ///  </summary>
        [DataMember(), JsonProperty()] public string otrassenas { get; set; }

        /// <summary>
        /// Número de folio.
        /// </summary>
        [DataMember(), JsonProperty()] public string numerodefolio { get; set; }
        /// <summary>
        /// Número de folio madre.
        /// </summary>
        [DataMember(), JsonProperty()] public string numerofincafilial { get; set; }
        /// <summary>
        /// Año de construcción.
        /// </summary>
        [DataMember(), JsonProperty()] public int anodeconstruccion { get; set; }
        /// <summary>
        /// Altura edificio.
        /// </summary>
        [DataMember(), JsonProperty()] public int alturaedificio { get; set; }
        /// <summary>
        /// Número metros construidos.
        /// </summary>
        [DataMember(), JsonProperty()] public int numerometrosconstruidos { get; set; }
        /// <summary>
        /// Número de piso.
        /// </summary>
        [DataMember(), JsonProperty()] public int numerodepiso { get; set; }

        /// <summary>
        ///  ¿Está cerca de un río, mar, lago, talud, en la cima?
        ///  </summary>
        [DataMember(), JsonProperty()] public int CERCA_RI_MAR_LAG_TA_CI { get; set; }
        ///  <summary>
        ///  Distancia/Metros
        ///  </summary>
        [DataMember(), JsonProperty()] public int DISTANCIA_MTS { get; set; }
        ///  <summary>
        ///  ¿Las instalaciones eléctricas se encuentran entubadas?
        ///  </summary>
        [DataMember(), JsonProperty()] public int INS_ELECT_ENTUB { get; set; }

         ///  <summary>
        ///  Vulnerabilidad de los contenidos
        ///  </summary>
        [DataMember(), JsonProperty()] public int VULNERABILIDAD { get; set; }


        ///  <summary>
        ///  Folio madre
        ///  </summary>
        [DataMember(), JsonProperty()] public string numerodefoliomadre { get; set; }

        ///  <summary>
        ///  Georeferencia Latitud
        ///  </summary>
        [DataMember(), JsonProperty()] public string latitud { get; set; }

        ///  <summary>
        ///  Georeferencia Longitud
        ///  </summary>
        [DataMember(), JsonProperty()] public string longitud { get; set; }

        ///  <summary>
        ///  Colindante Norte
        ///  </summary>
        [DataMember(), JsonProperty()] public string norte { get; set; }

        ///  <summary>
        ///  Colindante Sur
        ///  </summary>
        [DataMember(), JsonProperty()] public string sur { get; set; }

        ///  <summary>
        ///  Colindante Este
        ///  </summary>
        [DataMember(), JsonProperty()] public string este { get; set; }

        ///  <summary>
        ///  Colindante Oeste
        ///  </summary>
        [DataMember(), JsonProperty()] public string oeste { get; set; }

        ///  <summary>
        ///  Material de la estructura
        ///  </summary>
        [DataMember(), JsonProperty()] public string material_estructura { get; set; }

        ///  <summary>
        ///  Tipo de Mamposteria
        ///  </summary>
        [DataMember(), JsonProperty()] public string mamposteria { get; set; }

        ///  <summary>
        ///  Material Paredes Internas
        ///  </summary>
        [DataMember(), JsonProperty()] public string paredes_internas { get; set; }

        ///  <summary>
        ///  Material del Techo
        ///  </summary>
        [DataMember(), JsonProperty()] public string techo { get; set; }

        ///  <summary>
        ///  Material del piso
        ///  </summary>
        [DataMember(), JsonProperty()] public string material_piso { get; set; }

        ///  <summary>
        ///  Material de los entrepisos
        ///  </summary>
        [DataMember(), JsonProperty()] public string entrepisos { get; set; }

        ///  <summary>
        ///  ¿Existe sobrepeso en las estructuras?
        ///  </summary>
        [DataMember(), JsonProperty()] public int sobrepeso { get; set; }

        ///  <summary>
        ///  Descripcion del sobrepeso de las estructuras
        ///  </summary>
        [DataMember(), JsonProperty()] public string sobrepesoDesc { get; set; }

        ///  <summary>
        ///  ¿Donde se encuenta el lugar del bien?
        ///  </summary>
        [DataMember(), JsonProperty()] public int lugardelbien { get; set; }

        ///  <summary>
        ///  Descripcion del lugar del bien
        ///  </summary>
        [DataMember(), JsonProperty()] public string lugardelbienDesc { get; set; }

        ///  <summary>
        ///  ¿El bien asegurado a tenido daños previos?
        ///  </summary>
        [DataMember(), JsonProperty()] public int danosprevios { get; set; }

        ///  <summary>
        ///  Descripcion de los daños previos
        ///  </summary>
        [DataMember(), JsonProperty()] public string danospreviosDesc { get; set; }



        ///  <summary>
        ///  Suma de Bodega
        ///  </summary>
        [DataMember(), JsonProperty()] public int bodega { get; set; }

        ///  <summary>
        ///  Suma del garaje
        ///  </summary>
        [DataMember(), JsonProperty()] public int garaje { get; set; }

        ///  <summary>
        ///  Suma de las tapias
        ///  </summary>
        [DataMember(), JsonProperty()] public int tapias { get; set; }

        ///  <summary>
        ///  Sumas de las piscina
        ///  </summary>
        [DataMember(), JsonProperty()] public int piscina { get; set; }

        ///  <summary>
        ///  Otras sumas 
        ///  </summary>
        [DataMember(), JsonProperty()] public int otras_sumas { get; set; }
    }
}
