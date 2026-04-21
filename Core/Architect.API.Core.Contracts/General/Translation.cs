using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Representa una entrada de traducción del repositorio global multi-idioma del sistema ALIADOS.
    /// </summary>
    public class Translation
    {
        /// <summary>
        /// Identificador único del registro de traducción.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }

        /// <summary>
        /// Agrupador lógico que define el ámbito de la traducción (ej: 'NAVIGATION', 'ERRORS').
        /// </summary>
        [DataMember(), JsonProperty()] public string Context { get; set; }

        /// <summary>
        /// Clave técnica que identifica la cadena de texto dentro de un contexto.
        /// </summary>
        [DataMember(), JsonProperty()] public string TranslationKey { get; set; }

        /// <summary>
        /// Código ISO de 2 caracteres que identifica el idioma (ej: 'ES', 'EN').
        /// </summary>
        [DataMember(), JsonProperty()] public string Language { get; set; }

        /// <summary>
        /// Texto traducido al idioma especificado.
        /// </summary>
        [DataMember(), JsonProperty()] public string TranslatedText { get; set; }
    }
}
