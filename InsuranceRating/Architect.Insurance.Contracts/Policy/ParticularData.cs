using System;
using System.Linq;

namespace Architect.Insurance.Contracts.Policy
{
    /// <summary>
    /// Datos particulares.
    /// </summary>
    /// <remarks>VT.NONE</remarks>
    public class ParticularData
    {
        /// <summary>
        /// Datos particulares del ramo de automóvil.
        /// </summary>
        /// <remarks>VT.AUTO</remarks>
        public Auto Auto{ get; set; }

        /// <summary>
        /// Datos particulares del ramo de vida.
        /// </summary>
        /// <remarks>VT.LIFE</remarks>
        public Life Life { get; set; }

        /// <summary>
        /// Uso interno. Permite recuperar la instancia de datos particulares en uso.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        public Interfaces.IParticularData Data
        {
            get
            {
                if (Auto != null)
                    return Auto;
                if (Life != null)
                    return Life;
                return null;
            }
        }


    }
}
