using System;

namespace Architect.API.Tron.Contracts.Presupuesto
{
    /// <summary>
    ///  Recibos/cuotas del presupuesto (P2990700)
    /// </summary>
    public partial class Recibo
    {
        /// <summary>
        ///  Código de compañía
        /// </summary>
        public int cod_cia { get; set; }

        /// <summary>
        ///  Poliza
        /// </summary>
        public string num_poliza { get; set; }

        /// <summary>
        ///  Número de suplemento
        /// </summary>
        public int num_spto { get; set; }

        /// <summary>
        ///  Número de aplicación
        /// </summary>
        public int num_apli { get; set; }

        /// <summary>
        ///  Suplemento de la aplicacion
        /// </summary>
        public int num_spto_apli { get; set; }

        /// <summary>
        ///  Cuota
        /// </summary>
        public int num_cuota { get; set; }

        /// <summary>
        ///  La fila corresponde a un cambio de agente (anula la fila original)
        /// </summary>
        public string mca_ca { get; set; }

        /// <summary>
        ///  La fila corresponde a un cambio de plan de pago (anula la fila original)
        /// </summary>
        public string mca_cv { get; set; }

        /// <summary>
        ///  Recibo
        /// </summary>
        public int num_recibo { get; set; }

        /// <summary>
        ///  Tipo de recibo (domiciliado, ventanilla, etc)
        /// </summary>
        public string tip_recibo { get; set; }

        /// <summary>
        ///  Efecto del recibo
        /// </summary>
        public DateTime fec_efec_recibo { get; set; }

        /// <summary>
        ///  Vencimiento del recibo
        /// </summary>
        public DateTime fec_vcto_recibo { get; set; }

        /// <summary>
        ///  Tipo de gestor
        /// </summary>
        public string tip_gestor { get; set; }

        /// <summary>
        ///  Gestor de cobro
        /// </summary>
        public string cod_gestor { get; set; }

        /// <summary>
        ///  Fecha de contabilizacion del suplemento
        /// </summary>
        public DateTime fec_emision_spto { get; set; }

        /// <summary>
        ///  Situacion
        /// </summary>
        public string tip_situacion { get; set; }

        /// <summary>
        ///  Tipo de remesa para control de saldos(0-ambos, 1-primas,2-stros .... )
        /// </summary>
        public string tip_remesa { get; set; }

        /// <summary>
        ///  Fecha de remesa
        /// </summary>
        public DateTime fec_remesa { get; set; }

        /// <summary>
        ///  Para el asiento de emision o fecha de pago
        /// </summary>
        public DateTime fec_ctable { get; set; }

        /// <summary>
        ///  Fecha valor
        /// </summary>
        public DateTime fec_valor { get; set; }

        /// <summary>
        ///  Moneda
        /// </summary>
        public int cod_mon { get; set; }

        /// <summary>
        ///  Valor  cambio
        /// </summary>
        public double val_cambio { get; set; }

        /// <summary>
        ///  Total del recibo
        /// </summary>
        public double imp_recibo { get; set; }

        /// <summary>
        ///  Prima neta
        /// </summary>
        public double imp_neta { get; set; }

        /// <summary>
        ///  Recargos
        /// </summary>
        public double imp_recargo { get; set; }

        /// <summary>
        ///  Impuestos
        /// </summary>
        public double imp_imptos { get; set; }

        /// <summary>
        ///  Bonificaciones
        /// </summary>
        public double imp_boni { get; set; }

        /// <summary>
        ///  Importe de la comision
        /// </summary>
        public double imp_comis { get; set; }

        /// <summary>
        ///  Tipo de coaseguro
        /// </summary>
        public int tip_coaseguro { get; set; }

        /// <summary>
        ///  Código de nivel3 oficina captura
        /// </summary>
        public int cod_nivel3 { get; set; }

        /// <summary>
        ///  Agente
        /// </summary>
        public int cod_agt { get; set; }

        /// <summary>
        ///  Número de veces que se ha impreso
        /// </summary>
        public int num_impresion { get; set; }

        /// <summary>
        ///  Control de aviso de morosos
        /// </summary>
        public string ctrl_moroso { get; set; }

        /// <summary>
        ///  Campo auxiliar 1 (para datos especificos de una instalacion.  este campo no se debe usar en instalaciones nuevas)
        /// </summary>
        public string txt_aux1 { get; set; }

        /// <summary>
        ///  Campo auxiliar 2 (para datos especificos de una instalacion.  este campo no se debe usar en instalaciones nuevas)
        /// </summary>
        public string txt_aux2 { get; set; }

        /// <summary>
        ///  Fecha de la ultima actualizacion del registro
        /// </summary>
        public DateTime fec_actu { get; set; }

        /// <summary>
        ///  Total de la comision del recibo
        /// </summary>
        public double imp_total_comis { get; set; }

        /// <summary>
        ///  Número de aviso
        /// </summary>
        public string num_aviso { get; set; }

        /// <summary>
        ///  Tipo del documento de pago
        /// </summary>
        public string tip_docum_pago { get; set; }

        /// <summary>
        ///  Documento del tercero del pago
        /// </summary>
        public string cod_docum_pago { get; set; }

        /// <summary>
        ///  Intereses
        /// </summary>
        public double imp_interes { get; set; }

        /// <summary>
        ///  Impuestos de los intereses
        /// </summary>
        public double imp_imptos_interes { get; set; }

        /// <summary>
        ///  Número de movimiento en un cambio de plan de pago
        /// </summary>
        public int num_mvto_cv { get; set; }

        /// <summary>
        ///  Indica si se descuenta las comisiones en el momento del cobro del recibo
        /// </summary>
        public string mca_dcto_comis { get; set; }

        /// <summary>
        ///  Fecha vencimiento de pago (ultimo dia de gracia)
        /// </summary>
        public DateTime fec_vcto_pago { get; set; }
    }
}