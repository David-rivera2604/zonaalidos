using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Tron.Business.Siniestro
{
    /// <summary>
    /// Información detalle de un siniestro procesado por Purdy
    /// </summary>
    public static partial class SiniestroPurdy
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla SiniestroPurdy.
        /// </summary>
        /// <param name="item">Instancia de SiniestroPurdy</param>
        /// <returns>Instancia de SiniestroPurdy creada o actualizada.</returns>
        public static int CreateOrUpdate(Architect.API.Tron.Contracts.Siniestro.Purdy.SiniestroPurdy item)
        {
            if (DataAccess.Siniestro.Purdy.SiniestroPurdy.Count(item.NUM_SINI, item.NUM_EXP) == 0)
            {
                return DataAccess.Siniestro.Purdy.SiniestroPurdy.Create(item);
            }
            else
            {
                return DataAccess.Siniestro.Purdy.SiniestroPurdy.Update(item);
            }
        }

    }
}
