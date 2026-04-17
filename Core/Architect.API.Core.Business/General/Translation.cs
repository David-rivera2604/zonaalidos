using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Lógica de negocio para la gestión de traducciones multi-idioma del sistema ALIADOS.
    /// </summary>
    public static class Translation
    {
        /// <summary>
        /// Recupera el texto traducido de una clave específica dentro de un contexto e idioma dados.
        /// Si no existe la traducción, retorna <c>null</c>.
        /// </summary>
        /// <param name="context">Agrupador lógico de la traducción (ej: 'NAVIGATION', 'ERRORS').</param>
        /// <param name="key">Clave técnica que identifica el texto dentro del contexto.</param>
        /// <param name="language">Código ISO de 2 caracteres del idioma solicitado (ej: 'ES', 'EN').</param>
        /// <returns>Texto traducido o <c>null</c> si no existe el registro.</returns>
        public static string GetText(string context, string key, string language)
        {
            return Core.DataAccess.General.Translation.GetText(context, key, language);
        }

        /// <summary>
        /// Recupera todas las traducciones pertenecientes a un contexto e idioma específicos.
        /// Útil para descargar en bloque las etiquetas de una sección de la aplicación.
        /// </summary>
        /// <param name="context">Agrupador lógico de las traducciones (ej: 'NAVIGATION', 'ERRORS').</param>
        /// <param name="language">Código ISO de 2 caracteres del idioma solicitado (ej: 'ES', 'EN').</param>
        /// <returns>Lista de instancias de <see cref="Contracts.General.Translation"/>.</returns>
        public static List<Contracts.General.Translation> GetByContext(string context, string language)
        {
            return Core.DataAccess.General.Translation.GetByContext(context, language);
        }
    }
}
