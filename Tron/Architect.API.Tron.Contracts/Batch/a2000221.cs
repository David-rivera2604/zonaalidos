/// <summary>
///  Control tecnico de la poliza
/// </summary>

using System;

namespace Architect.API.Tron.Contracts.Batch
{
    public partial class a2000221
    {
        /// <summary>
        ///  Codigo de compañia
        /// </summary>
        public int cod_cia { get; set; }

        /// <summary>
        ///  Poliza
        /// </summary>
        public string num_poliza { get; set; }

        /// <summary>
        ///  Numero de suplemento
        /// </summary>
        public int num_spto { get; set; }

        /// <summary>
        ///  Numero de aplicacion
        /// </summary>
        public int num_apli { get; set; }

        /// <summary>
        ///  Suplemento de la aplicacion
        /// </summary>
        public int num_spto_apli { get; set; }

        /// <summary>
        ///  Riesgo
        /// </summary>
        public int num_riesgo { get; set; }

        /// <summary>
        ///  Cobertura
        /// </summary>
        public int cod_cob { get; set; }

        /// <summary>
        ///  Seccion de reaseguro (politica de distribucion)
        /// </summary>
        public int cod_secc_reas { get; set; }

        /// <summary>
        ///  Error
        /// </summary>
        public int cod_error { get; set; }

        /// <summary>
        ///  Area a la que pertenece (emision, stros, ...)
        /// </summary>
        public string cod_sistema { get; set; }

        /// <summary>
        ///  Lugar donde se produce el error
        /// </summary>
        public string cod_nivel_salto { get; set; }

        /// <summary>
        ///  Autorizado
        /// </summary>
        public string mca_autorizacion { get; set; }

        /// <summary>
        ///  Fecha de autorizacion del control tecnico
        /// </summary>
        public DateTime fec_autorizacion { get; set; }

        /// <summary>
        ///  Usuario que autoriza
        /// </summary>
        public string cod_usr_autorizacion { get; set; }

        /// <summary>
        ///  Observaciones autorizacion
        /// </summary>
        public string obs_autorizacion { get; set; }

        /// <summary>
        ///  Sistema que puede autorizar (departamento)
        /// </summary>
        public string cod_sist_aut { get; set; }

        /// <summary>
        ///  Anexo al error
        /// </summary>
        public string obs_error { get; set; }
    }
}