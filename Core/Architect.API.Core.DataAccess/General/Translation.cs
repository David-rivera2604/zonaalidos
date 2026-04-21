using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Acceso a datos para el repositorio global de traducciones multi-idioma (ALIADOS.TRANSLATIONS).
    /// </summary>
    public sealed class Translation
    {
        /// <summary>
        /// Recupera el texto traducido de una clave específica dentro de un contexto e idioma dados.
        /// </summary>
        /// <param name="context">Agrupador lógico de la traducción (ej: 'NAVIGATION', 'ERRORS').</param>
        /// <param name="key">Clave técnica que identifica el texto dentro del contexto.</param>
        /// <param name="language">Código ISO de 2 caracteres del idioma solicitado (ej: 'ES', 'EN').</param>
        /// <param name="connection">Instancia de una conexión compartida.</param>
        /// <returns>Texto traducido o <c>null</c> si no existe el registro.</returns>
        public static string GetText(string context, string key, string language, IDbConnection connection = null)
        {
            string result = null;
            Database.Select("SELECT TRANSLATED_TEXT " +
                              "FROM ALIADOS.TRANSLATIONS " +
                             "WHERE CONTEXT = :Context " +
                               "AND TRANSLATION_KEY = :TranslationKey " +
                               "AND LANGUAGE = :Language")
                        .AddParameter("Context", DbType.AnsiString, 80, context)
                        .AddParameter("TranslationKey", DbType.AnsiString, 100, key)
                        .AddParameter("Language", DbType.AnsiStringFixedLength, 2, language)
                        .Query(connection, "Research", new System.Action<IDataReader>((reader) =>
                        {
                            result = reader.StringValue("TRANSLATED_TEXT");
                        }));
            return result;
        }

        /// <summary>
        /// Recupera todas las traducciones pertenecientes a un contexto e idioma específicos.
        /// </summary>
        /// <param name="context">Agrupador lógico de las traducciones (ej: 'NAVIGATION', 'ERRORS').</param>
        /// <param name="language">Código ISO de 2 caracteres del idioma solicitado (ej: 'ES', 'EN').</param>
        /// <param name="connection">Instancia de una conexión compartida.</param>
        /// <returns>Lista de instancias de <see cref="Architect.API.Core.Contracts.General.Translation"/>.</returns>
        public static List<Architect.API.Core.Contracts.General.Translation> GetByContext(string context, string language, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Translation> result = new List<Architect.API.Core.Contracts.General.Translation>();
            Database.Select("SELECT ID, CONTEXT, TRANSLATION_KEY, LANGUAGE, TRANSLATED_TEXT " +
                              "FROM ALIADOS.TRANSLATIONS " +
                             "WHERE CONTEXT = :Context " +
                               "AND LANGUAGE = :Language " +
                             "ORDER BY TRANSLATION_KEY")
                        .AddParameter("Context", DbType.AnsiString, 80, context)
                        .AddParameter("Language", DbType.AnsiStringFixedLength, 2, language)
                        .Query(connection, "Research", new System.Action<IDataReader>((reader) =>
                        {
                            result.Add(new Architect.API.Core.Contracts.General.Translation()
                            {
                                Id             = reader.IntegerValue("ID"),
                                Context        = reader.StringValue("CONTEXT"),
                                TranslationKey = reader.StringValue("TRANSLATION_KEY"),
                                Language       = reader.StringValue("LANGUAGE"),
                                TranslatedText = reader.StringValue("TRANSLATED_TEXT")
                            });
                        }));
            return result;
        }
    }
}
