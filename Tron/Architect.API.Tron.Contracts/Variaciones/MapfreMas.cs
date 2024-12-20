using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Architect.API.Tron.Contracts.Variaciones
{
    public class MapfreMas : Cotizacion.MapfreMas
    {
        /// <summary>
        /// Codigo de compania
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_cia { get; set; }

        /// <summary>
        /// No. de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string num_poliza { get; set; }

        /// <summary>
        /// No. de suplemento.
        /// </summary>
        [DataMember(), JsonProperty()] public int num_spto { get; set; }

        /// <summary>
        /// Cilindraje del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public string DES_TIP_CILINDRAJE { get; set; }
        /// <summary>
        /// Peso del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public int VAL_PESO { get; set; }
        /// <summary>
        /// Color del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_COLOR { get; set; }
        [DataMember(), JsonProperty()] public string COD_COLORDesc { get; set; }
        /// <summary>
        /// Capacidad del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public int VAL_CAPACIDAD { get; set; }


        /// <summary>
        /// Correo principal.
        /// </summary>
        [DataMember(), JsonProperty()] public string correoprincipal { get; set; }
        /// <summary>
        /// Correo copia 1.
        /// </summary>
        [DataMember(), JsonProperty()] public string correocopia1 { get; set; }
        /// <summary>
        /// Correo copia 2.
        /// </summary>
        [DataMember(), JsonProperty()] public string correocopia2 { get; set; }

        /// <summary>
        /// Terceros
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.tercero> terceros { get; set; }

        /// <summary>
        /// Vehiculo
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.vehiculo> vehiculo { get; set; }

        /// <summary>				 
        /// Documentos requeridos
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.DocumentoRequerido> documentosrequeridos { get; set; }


        [DataMember(), JsonProperty()] public string tip_firma { get; set; } = "";
        [DataMember(), JsonProperty()] public string tip_firmaDesc { get; set; }

        [DataMember(), JsonProperty()] public string correoenvio { get; set; }

        [DataMember(), JsonProperty()] public bool Cliente_Mapfre { get; set; } = false;
        [DataMember(), JsonProperty()] public bool Cliente_Nuevo { get; set; } = false;
        [DataMember(), JsonProperty()] public bool Actualizacion_Cliente { get; set; } = false;
        [DataMember(), JsonProperty()] public string Tipo_Kilomentraje { get; set; } = "Km";
        [DataMember(), JsonProperty()] public string Vehiculo_Otra_Poliza { get; set; } = "N";
        [DataMember(), JsonProperty()] public string Modalidad_Pago { get; set; } = "DEPCM";
        [DataMember(), JsonProperty()] public string Tipo_Licencia { get; set; } = "B1";
        [DataMember(), JsonProperty()] public string Tiempo_Licencia { get; set; }
        [DataMember(), JsonProperty()] public string Fuente_Tomador { get; set; }

        [DataMember(), JsonProperty()] public string Modo { get; set; }

        [DataMember(), JsonProperty()] public EconomicData DatosEconomicos { get; set; }

        [DataMember(), JsonProperty()] public object kyc { get; set; }

        /// <summary>
        /// Conozca a su cliente
        /// </summary>
        [DataMember(), JsonProperty()] public Comun.ConoceTuCliente ConoceTuCliente { get; set; }

        [DataMember(), JsonProperty()] public string MCA_FEC_EFEC_SYS { get; set; } = "N";
        [DataMember(), JsonProperty()] public List<Receipt> Recibos { get; set; }
        [DataMember(), JsonProperty()] public string Mca_Autoriza_CT { get; set; }
        [DataMember(), JsonProperty()] public string DED_AUTO_CYV_Desc { get; set; }
        [DataMember(), JsonProperty()] public string DED_AUTO_ROB_Desc { get; set; }
        [DataMember(), JsonProperty()] public string DED_AUTO_RAD_Desc { get; set; }

        /// <summary>
        /// Coberturas
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.Cobertura> AvailableCoverages { get; set; }
        [DataMember(), JsonProperty()] public List<Comun.Cobertura> NewCoverages { get; set; }
        [DataMember(), JsonProperty()] public bool AUTO_RC { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_CYV { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_ROB { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_GMO { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_ACO { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_RAD { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_CRI { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_EQESP { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_NEUM { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_MECA { get; set; } = false;
    }

    public class MapfreMasSolicitud : MapfreMas
    {
        [DataMember(), JsonProperty()] public Contracts.Comun.tercero titular { get; set; }
        [DataMember(), JsonProperty()] public Contracts.Comun.tercero asegurado { get; set; }
        [DataMember(), JsonProperty()] public Contracts.Comun.tercero conductor { get; set; }
        [DataMember(), JsonProperty()] public Contracts.Comun.tercero beneficiario1 { get; set; }
        [DataMember(), JsonProperty()] public Contracts.Comun.tercero beneficiario2 { get; set; }
        [DataMember(), JsonProperty()] public Contracts.Comun.tercero acredor { get; set; }

        [DataMember(), JsonProperty()] public string mainrole { get; set; }
        
    }

    public class EconomicData
    {
        [DataMember(), JsonProperty()] public double annualnetpremium { get; set; }
        [DataMember(), JsonProperty()] public double tax { get; set; }
        [DataMember(), JsonProperty()] public double annualgrosspremium { get; set; }
        [DataMember(), JsonProperty()] public double monthlygrosspremium { get; set; }

    }

}
