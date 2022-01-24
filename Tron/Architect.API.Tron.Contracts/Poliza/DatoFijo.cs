using System;
using System.Collections.Generic;

namespace Architect.API.Tron.Contracts.Poliza
{
    /// <summary>
    ///  Datos fijos de la póliza (A2000030)
    /// </summary>
    public partial class DatoFijo
    {
        /// <summary>
        ///  Código de compañía
        /// </summary>
        public int cod_cia { get; set; }

        /// <summary>
        ///  Póliza
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
        ///  Suplemento de la aplicación
        /// </summary>
        public int num_spto_apli { get; set; }

        /// <summary>
        ///  Sector
        /// </summary>
        public int cod_sector { get; set; }

        /// <summary>
        ///  Ramo
        /// </summary>
        public int cod_ramo { get; set; }

        /// <summary>
        ///  Fecha de la imagen del ramo
        /// </summary>
        public DateTime fec_validez { get; set; }

        /// <summary>
        ///  Fecha de contabilización inicial
        /// </summary>
        public DateTime fec_emision { get; set; }

        /// <summary>
        ///  Fecha de contabilización del suplemento
        /// </summary>
        public DateTime fec_emision_spto { get; set; }

        /// <summary>
        ///  Efecto de la póliza
        /// </summary>
        public DateTime fec_efec_poliza { get; set; }

        /// <summary>
        ///  Vencimiento de la póliza
        /// </summary>
        public DateTime fec_vcto_poliza { get; set; }

        /// <summary>
        ///  Efecto del suplemento
        /// </summary>
        public DateTime fec_efec_spto { get; set; }

        /// <summary>
        ///  Vencimiento del suplemento
        /// </summary>
        public DateTime fec_vcto_spto { get; set; }

        /// <summary>
        ///  Duración de la póliza
        /// </summary>
        public int tip_duracion { get; set; }

        /// <summary>
        ///  Número total de riesgos que ha tenido
        /// </summary>
        public int num_riesgos { get; set; }

        /// <summary>
        ///  Moneda
        /// </summary>
        public int cod_mon { get; set; }

        /// <summary>
        ///  Plan de pago
        /// </summary>
        public int cod_fracc_pago { get; set; }

        /// <summary>
        ///  Número máximo de renovaciones que tendrá la póliza
        /// </summary>
        public int cant_renovaciones { get; set; }

        /// <summary>
        ///  Cantidad de renovaciones realizadas
        /// </summary>
        public int num_renovaciones { get; set; }

        /// <summary>
        ///  Tipo de coa-seguro
        /// </summary>
        public int tip_coaseguro { get; set; }

        /// <summary>
        ///  Presupuesto
        /// </summary>
        public string num_presupuesto { get; set; }

        /// <summary>
        ///  póliza anterior
        /// </summary>
        public string num_poliza_anterior { get; set; }

        /// <summary>
        ///  póliza cliente
        /// </summary>
        public string num_poliza_cliente { get; set; }

        /// <summary>
        ///  Contrato
        /// </summary>
        public int num_contrato { get; set; }

        /// <summary>
        ///  póliza grupo
        /// </summary>
        public string num_poliza_grupo { get; set; }

        /// <summary>
        ///  Número de secuencia dentro de la póliza grupo
        /// </summary>
        public int num_secu_grupo { get; set; }

        /// <summary>
        ///  Suplemento
        /// </summary>
        public int cod_spto { get; set; }

        /// <summary>
        ///  Suplemento
        /// </summary>
        public int sub_cod_spto { get; set; }

        /// <summary>
        ///  Causa del suplemento
        /// </summary>
        public string cod_tip_spto { get; set; }

        /// <summary>
        ///  Tipo de suplemento
        /// </summary>
        public string tip_spto { get; set; }

        /// <summary>
        ///  Texto que determina el motivo del suplemento
        /// </summary>
        public string txt_motivo_spto { get; set; }

        /// <summary>
        ///  Tipo del documento del tercero
        /// </summary>
        public string tip_docum { get; set; }

        /// <summary>
        ///  Documento del tercero
        /// </summary>
        public string cod_docum { get; set; }

        /// <summary>
        ///  Cuadro de comisiones
        /// </summary>
        public int cod_cuadro_com { get; set; }

        /// <summary>
        ///  Agente
        /// </summary>
        public int cod_agt { get; set; }

        /// <summary>
        ///  Porcentaje relativo del total de comisiones
        /// </summary>
        public double pct_agt { get; set; }

        /// <summary>
        ///  Organizador
        /// </summary>
        public int cod_org { get; set; }

        /// <summary>
        ///  Asesor
        /// </summary>
        public int cod_asesor { get; set; }

        /// <summary>
        ///  Nivel1 de la estructura comercial
        /// </summary>
        public int cod_nivel1 { get; set; }

        /// <summary>
        ///  Nivel2 de la estructura comercial
        /// </summary>
        public int cod_nivel2 { get; set; }

        /// <summary>
        ///  Código de nivel3 oficina captura
        /// </summary>
        public int cod_nivel3 { get; set; }

        /// <summary>
        ///  Forma en la que el tercero cobra o paga
        /// </summary>
        public int cod_compensacion { get; set; }

        /// <summary>
        ///  Tipo de gestor
        /// </summary>
        public string tip_gestor { get; set; }

        /// <summary>
        ///  Gestor de cobro
        /// </summary>
        public string cod_gestor { get; set; }

        /// <summary>
        ///  La póliza se revaloriza
        /// </summary>
        public string mca_regulariza { get; set; }

        /// <summary>
        ///  Forma de re-valorización
        /// </summary>
        public string tip_regulariza { get; set; }

        /// <summary>
        ///  Porcentaje de re-valorización
        /// </summary>
        public double pct_regulariza { get; set; }

        /// <summary>
        ///  Indice de re-valorización
        /// </summary>
        public int cod_indice { get; set; }

        /// <summary>
        ///  Anos de duración de la póliza
        /// </summary>
        public int anios_max_duracion { get; set; }

        /// <summary>
        ///  Meses de duración de la solicitud
        /// </summary>
        public int meses_max_duracion { get; set; }

        /// <summary>
        ///  Días de duración de la póliza
        /// </summary>
        public int dias_max_duracion { get; set; }

        /// <summary>
        ///  Agente secundario
        /// </summary>
        public int cod_agt2 { get; set; }

        /// <summary>
        ///  Porcentaje relativo del total de comisiones para agente secundario
        /// </summary>
        public double pct_agt2 { get; set; }

        /// <summary>
        ///  Agente secundario
        /// </summary>
        public int cod_agt3 { get; set; }

        /// <summary>
        ///  Porcentaje relativo del total de comisiones para agente secundario
        /// </summary>
        public double pct_agt3 { get; set; }

        /// <summary>
        ///  Agente secundario
        /// </summary>
        public int cod_agt4 { get; set; }

        /// <summary>
        ///  Porcentaje relativo del total de comisiones para agente secundario
        /// </summary>
        public double pct_agt4 { get; set; }

        /// <summary>
        ///  Duración del pago de primas (años)
        /// </summary>
        public int duracion_pago_prima { get; set; }

        /// <summary>
        ///  Forma en la que se envían los documentos
        /// </summary>
        public string cod_envio { get; set; }

        /// <summary>
        ///  Ejecutivo de cuenta
        /// </summary>
        public int cod_ejecutivo { get; set; }

        /// <summary>
        ///  Tiene tomadores alternos
        /// </summary>
        public string mca_tomadores_alt { get; set; }

        /// <summary>
        ///  El reaseguro se distribuye manualmente
        /// </summary>
        public string mca_reaseguro_manual { get; set; }

        /// <summary>
        ///  Calculo a prorrata o escala
        /// </summary>
        public string mca_prorrata { get; set; }

        /// <summary>
        ///  Primas manuales
        /// </summary>
        public string mca_prima_manual { get; set; }

        /// <summary>
        ///  El movimiento es provisional
        /// </summary>
        public string mca_provisional { get; set; }

        /// <summary>
        ///  Fecha de autorización del control técnico
        /// </summary>
        public DateTime fec_autorizacion { get; set; }

        /// <summary>
        ///  póliza anulada
        /// </summary>
        public string mca_poliza_anulada { get; set; }

        /// <summary>
        ///  Suplemento anulado
        /// </summary>
        public string mca_spto_anulado { get; set; }

        /// <summary>
        ///  Número de suplemento anulado/anulador
        /// </summary>
        public int num_spto_anulado { get; set; }

        /// <summary>
        ///  Fecha en la que el suplemento se ha anulado
        /// </summary>
        public DateTime fec_spto_anulado { get; set; }

        /// <summary>
        ///  Suplemento temporal
        /// </summary>
        public string mca_spto_tmp { get; set; }

        /// <summary>
        ///  póliza con datos mínimos para uso de siniestros
        /// </summary>
        public string mca_datos_minimos { get; set; }

        /// <summary>
        ///  Ha sido impreso
        /// </summary>
        public string mca_impresion { get; set; }

        /// <summary>
        ///  No se usa
        /// </summary>
        public string mca_exclusivo { get; set; }

        /// <summary>
        ///  Usuario que actualizo la fila
        /// </summary>
        public string cod_usr { get; set; }

        /// <summary>
        ///  Nivel3 de la estructura comercial del usuario que capturo el movimiento
        /// </summary>
        public int cod_nivel3_captura { get; set; }

        /// <summary>
        ///  Fecha de la ultima actualización del registro
        /// </summary>
        public DateTime fec_actu { get; set; }

        /// <summary>
        ///  La aplicación se rea-segura como la marco
        /// </summary>
        public string mca_reaseguro_marco { get; set; }

        /// <summary>
        ///  Tipo de póliza
        /// </summary>
        public string tip_poliza_tr { get; set; }

        /// <summary>
        ///  En que póliza se ha convertido
        /// </summary>
        public string num_poliza_siguiente { get; set; }

        /// <summary>
        ///  Distribución de las comisiones
        /// </summary>
        public int cod_dst_agt { get; set; }

        /// <summary>
        ///  Cuadro de coa-seguro
        /// </summary>
        public string cod_cuadro_coa { get; set; }

        /// <summary>
        ///  Tipo de reaseguro 0=sin reaseguro, 1=cedido, 2=aceptado
        /// </summary>
        public string tip_rea { get; set; }

        /// <summary>
        ///  Número de suplemento publico
        /// </summary>
        public int num_spto_publico { get; set; }

        /// <summary>
        ///  Valor utilizado por núcleo para validaciones internas
        /// </summary>
        public string val_mca_int { get; set; }

        /// <summary>
        ///  Horario de comienzo
        /// </summary>
        public string hora_desde { get; set; }

        /// <summary>
        ///  Número de sub-contrato
        /// </summary>
        public int num_subcontrato { get; set; }

        /// <summary>
        ///  Tipo de negocio (grandes riesgos)
        /// </summary>
        public string cod_negocio { get; set; }

        /// <summary>
        ///  Número de secuencia de cuenta o tarjeta
        /// </summary>
        public int num_secu_cta_tar { get; set; }


        /// <summary>
        ///
        /// </summary>
        public string Error_Emision { get; set; }

        /// <summary>
        /// Fecha en la que se realiza el proceso masivo
        /// </summary>
        public DateTime fec_tratamiento { get; set; }

        /// <summary>
        /// Número del proceso masivo
        /// </summary>
        public int num_orden { get; set; }

        /// <summary>
        /// Tipo de proceso masivo
        /// </summary>
        public string tip_mvto_batch { get; set; }


        /// <summary>
        ///  Procesos masivos (G2000510)
        /// </summary>
        public Batch.Proceso DatosDelProceso { get; set; }

        /// <summary>
        /// Riesgos de la póliza (A2000031)
        /// </summary>
        public List<Riesgo> Riesgos { get; set; }

        /// <summary>
        ///  Datos variables de la póliza (A2000020)
        /// </summary>
        public List<DatoVariable> DatosVariables { get; set; }

        /// <summary>
        /// Ocurrencias de la póliza (A2000025)
        /// </summary>
        public List<Ocurrencia> Ocurrencias { get; set; }

        /// <summary>
        ///  Conceptos de desglose económico (a2100170)
        /// </summary>
        public List<DesgloseEconomico> DesgloseEconomico { get; set; }

        /// <summary>
        ///  Terceros de la póliza (A2000060)
        /// </summary>
        public List<Tercero> Terceros { get; set; }

        /// <summary>
        ///  Coberturas de la póliza (A2000040)
        /// </summary>
        public List<Cobertura> Coberturas { get; set; }

        /// <summary>
        ///  Recibos/cuotas de una póliza (A2990700)
        /// </summary>
        public List<Recibo> Recibos { get; set; }

        public Calculado Calculado { get; set; }

    }
    public class Calculado
    {
        /// <summary>
        ///  Coberturas de la póliza (A2000040)
        /// </summary>
        public List<CoberturaCalculada> Coberturas { get; set; }

        /// <summary>
        ///  Recibos/cuotas de una póliza (A2990700)
        /// </summary>
        public List<ReciboCalculado> Recibos { get; set; }
    }
}