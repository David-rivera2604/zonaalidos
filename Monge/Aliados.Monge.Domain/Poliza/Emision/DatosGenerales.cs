using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{

    /// <summary>
    /// Datos generales del producto a emitir
    /// </summary>
    public class DatosGenerales
    {
        public string pais { get; set; }
        public string cod_producto { get; set; }
        public string producto { get; set; }
        public string moneda { get; set; }
        public int cod_fracc_pago { get; set; }
        public DateTime fec_efec_poliza { get; set; }
        public DateTime fec_vcto_poliza { get; set; }
        public int cod_modalidad { get; set; }
        public string nom_modalidad { get; set; }
        public string numero_factura { get; set; }
        public string nombre_vendedor { get; set; }
        public string identificacion_vendedor { get; set; }
        public Tienda tienda { get; set; }
    }
}
