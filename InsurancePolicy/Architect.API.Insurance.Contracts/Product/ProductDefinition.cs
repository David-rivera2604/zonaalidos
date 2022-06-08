using System;
using System.Collections.Generic;

namespace Architect.API.Insurance.Contracts.Product
{
    /// <summary>
    /// Característica de un producto.
    /// </summary>
    public class ProductDefinition
    {
        /// <summary>
        /// Inicio de vigencia de la póliza matriz.
        /// </summary>
        public DateTime Effective { get; set; }
        /// <summary>
        /// Fin de vigencia de la póliza matriz.
        /// </summary>
        public DateTime Ending { get; set; }

        /// <summary>
        /// Titulo principal a nivel de la pantalla.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Titulo complementario a nivel de la pantalla.
        /// </summary>
        public string SubTitle { get; set; }
        /// <summary>
        /// Monedas permitidas.
        /// </summary>
        public List<LookupSimple> Currencies { get; set; }
        /// <summary>
        /// Módulos o planes.
        /// </summary>
        public List<LookupModules> Modules { get; set; }
        /// <summary>
        /// Frecuencias de pago permitidas y recargo por fraccionamiento del pago.
        /// </summary>
        public List<LookupSimple> PaymentFrequencies { get; set; }

        /// <summary>
        /// seccion o entradas de datos permitidas.
        /// </summary>
        public string EntryAllowed { get; set; }

        /// <summary>
        /// seccion o entradas de datos requeridas.
        /// </summary>
        public string EntryIsRequired { get; set; }

        /// <summary>
        /// Nombre del tomandor de la póliza matriz.
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Identificador del tomandor de la póliza matriz.
        /// </summary>
        public string OwnerId { get; set; }


        public string Behavior { get; set; }
    }
    /// <summary>
    /// Código y descripción usado para lista genericas.
    /// </summary>
    public class LookupSimple
    {
        /// <summary>
        /// Código.
        /// </summary>
        public Int16 Code { get; set; }
        /// <summary>
        /// Descripción.
        /// </summary>
        public string Description { get; set; }
    }
    /// <summary>
    /// Información de planes.
    /// </summary>
    public class LookupModules
    {
        /// <summary>
        /// Código.
        /// </summary>
        public Int16 Code { get; set; }
        /// <summary>
        /// Descripción.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Monto mínimo de capital asegurado.
        /// </summary>
        public decimal MinimumInsuredAmount { get; set; }
        /// <summary>
        /// Monto máximo de capital asegurado
        /// </summary>
        public decimal MaximumInsuredAmount { get; set; }
        /// <summary>
        /// Edad mínima de contratación.
        /// </summary>
        public Int32 MinimumAge { get; set; }
        /// <summary>
        /// Edad máxima de contratación.
        /// </summary>
        public Int32 MaximumAge { get; set; }
        /// <summary>
        /// Monto fijo de capital.
        /// </summary>
        public decimal FixedInsuredAmount { get; set; }
        /// <summary>
        /// Monto de prima fija o monto a agregar a la prima.
        /// </summary>
        public decimal FixedPremium { get; set; }
        /// <summary>
        /// Monto de prima fija mensual.
        /// </summary>
        public decimal FixedMonthlyPremium { get; set; }
    }
}
