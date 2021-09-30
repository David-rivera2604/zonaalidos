using System;

namespace Architect.API.Tron.Contracts.Presupuesto
{
    /// <summary>
    ///  Modificaciones de un tercero para un presupuesto (P1001331)
    /// </summary>
    public partial class DetalleDeTercero
    {
        /// <summary>
        ///  Fecha en la que se realiza el proceso masivo
        /// </summary>
        public DateTime fec_tratamiento { get; set; }

        /// <summary>
        ///  Tipo del proceso masivo
        /// </summary>
        public string tip_mvto_batch { get; set; }

        /// <summary>
        ///  Código de compañía
        /// </summary>
        public int cod_cia { get; set; }

        /// <summary>
        ///  Tipo del documento del tercero
        /// </summary>
        public string tip_docum { get; set; }

        /// <summary>
        ///  Documento del tercero
        /// </summary>
        public string cod_docum { get; set; }

        /// <summary>
        ///  Actividad del tercero
        /// </summary>
        public int cod_act_tercero { get; set; }

        /// <summary>
        ///  Físico o jurídico
        /// </summary>
        public string mca_fisico { get; set; }

        /// <summary>
        ///  Primer apellido del tercero
        /// </summary>
        public string ape1_tercero { get; set; }

        /// <summary>
        ///  Segundo apellido del tercero
        /// </summary>
        public string ape2_tercero { get; set; }

        /// <summary>
        ///  Nombre del tercero
        /// </summary>
        public string nom_tercero { get; set; }

        /// <summary>
        ///  Código de tercero
        /// </summary>
        public int cod_tercero { get; set; }

        /// <summary>
        ///  Tipo de documento tercero padre
        /// </summary>
        public string tip_docum_padre { get; set; }

        /// <summary>
        ///  Documento del tercero padre
        /// </summary>
        public string cod_docum_padre { get; set; }

        /// <summary>
        ///  Tipo de nacionalidad
        /// </summary>
        public string tip_nacionalidad { get; set; }

        /// <summary>
        ///  Nacionalidad
        /// </summary>
        public string cod_nacionalidad { get; set; }

        /// <summary>
        ///  Tipo de domicilio
        /// </summary>
        public int tip_domicilio { get; set; }

        /// <summary>
        ///  Domicilio (primera linea)
        /// </summary>
        public string nom_domicilio1 { get; set; }

        /// <summary>
        ///  Domicilio (segunda linea)
        /// </summary>
        public string nom_domicilio2 { get; set; }

        /// <summary>
        ///  Domicilio (tercera linea)
        /// </summary>
        public string nom_domicilio3 { get; set; }

        /// <summary>
        ///  Descripción del cuarto nivel de la estructura geográfica
        /// </summary>
        public string nom_localidad { get; set; }

        /// <summary>
        ///  País, primer nivel de la estructura geográfica
        /// </summary>
        public string cod_pais { get; set; }

        /// <summary>
        ///  Tercer nivel de la estructura geográfica
        /// </summary>
        public int cod_prov { get; set; }

        /// <summary>
        ///  Código postal
        /// </summary>
        public string cod_postal { get; set; }

        /// <summary>
        ///  Apartado postal
        /// </summary>
        public string num_apartado { get; set; }

        /// <summary>
        ///  Prefijo telefonico del pais
        /// </summary>
        public string tlf_pais { get; set; }

        /// <summary>
        ///  Prefijo telefonico de la zona
        /// </summary>
        public string tlf_zona { get; set; }

        /// <summary>
        ///  Número de telefono
        /// </summary>
        public string tlf_numero { get; set; }

        /// <summary>
        ///  Fax
        /// </summary>
        public string fax_numero { get; set; }

        /// <summary>
        ///  Direccion de correo electronico
        /// </summary>
        public string email { get; set; }

        /// <summary>
        ///  Tipo de domicilio. direccion comercial
        /// </summary>
        public int tip_domicilio_com { get; set; }

        /// <summary>
        ///  Domicilio (primera linea). direccion comercial
        /// </summary>
        public string nom_domicilio1_com { get; set; }

        /// <summary>
        ///  Domicilio (segunda linea). direccion comercial
        /// </summary>
        public string nom_domicilio2_com { get; set; }

        /// <summary>
        ///  Domicilio (tercera linea). direccion comercial
        /// </summary>
        public string nom_domicilio3_com { get; set; }

        /// <summary>
        ///  Descripcion del cuarto nivel de la estructura geografica. direccion comercial
        /// </summary>
        public string nom_localidad_com { get; set; }

        /// <summary>
        ///  Pais, primer nivel de la estructura geografica. direccion comercial
        /// </summary>
        public string cod_pais_com { get; set; }

        /// <summary>
        ///  Tercer nivel de la estructura geografica. direccion comercial
        /// </summary>
        public int cod_prov_com { get; set; }

        /// <summary>
        ///  Código postal. direccion comercial
        /// </summary>
        public string cod_postal_com { get; set; }

        /// <summary>
        ///  Prefijo telefonico del pais, direccion comercial
        /// </summary>
        public string tlf_pais_com { get; set; }

        /// <summary>
        ///  Prefijo telefonico de la zona. direccion comercial
        /// </summary>
        public string tlf_zona_com { get; set; }

        /// <summary>
        ///  Número de telefono. direccion comercial
        /// </summary>
        public string tlf_numero_com { get; set; }

        /// <summary>
        ///  Fax. direccion comercial
        /// </summary>
        public string fax_numero_com { get; set; }

        /// <summary>
        ///  Direccion de correo electronico. direccion comercial
        /// </summary>
        public string email_com { get; set; }

        /// <summary>
        ///  Direccion (primera linea)
        /// </summary>
        public string txt_etiqueta1 { get; set; }

        /// <summary>
        ///  Direccion (segunda linea)
        /// </summary>
        public string txt_etiqueta2 { get; set; }

        /// <summary>
        ///  Direccion (tercera linea)
        /// </summary>
        public string txt_etiqueta3 { get; set; }

        /// <summary>
        ///  Direccion (cuarta linea)
        /// </summary>
        public string txt_etiqueta4 { get; set; }

        /// <summary>
        ///  Direccion (quinta linea)
        /// </summary>
        public string txt_etiqueta5 { get; set; }

        /// <summary>
        ///  Persona de contacto
        /// </summary>
        public string nom_contacto { get; set; }

        /// <summary>
        ///  Tipo de cargo en la empresa
        /// </summary>
        public int tip_cargo { get; set; }

        /// <summary>
        ///  Tipo de actividad economica para personas juridicas
        /// </summary>
        public int tip_act_economica { get; set; }

        /// <summary>
        ///  Entidad bancaria
        /// </summary>
        public string cod_entidad { get; set; }

        /// <summary>
        ///  Oficina bancaria
        /// </summary>
        public string cod_oficina { get; set; }

        /// <summary>
        ///  Cuenta corrriente bancaria
        /// </summary>
        public string cta_cte { get; set; }

        /// <summary>
        ///  Digito de control de la cuenta corriente bancaria
        /// </summary>
        public string cta_dc { get; set; }

        /// <summary>
        ///  Fecha de nacimiento
        /// </summary>
        public DateTime fec_nacimiento { get; set; }

        /// <summary>
        ///  Fecha de carnet de conducir
        /// </summary>
        public DateTime fec_carnet_con { get; set; }

        /// <summary>
        ///  Ocupacion
        /// </summary>
        public int cod_ocupacion { get; set; }

        /// <summary>
        ///  Estado civil
        /// </summary>
        public string cod_est_civil { get; set; }

        /// <summary>
        ///  Profesion
        /// </summary>
        public int cod_profesion { get; set; }

        /// <summary>
        ///  Sexo
        /// </summary>
        public string mca_sexo { get; set; }

        /// <summary>
        ///  Calidad del tercero
        /// </summary>
        public string cod_calidad { get; set; }

        /// <summary>
        ///  Idioma
        /// </summary>
        public string cod_idioma { get; set; }

        /// <summary>
        ///  Observaciones asegurado
        /// </summary>
        public string obs_asegurado { get; set; }

        /// <summary>
        ///  Agrupamento del tercero
        /// </summary>
        public string cod_grp_tercero { get; set; }

        /// <summary>
        ///  Campo auxiliar 1 (para datos especificos de una instalacion.  este campo no se debe usar en instalaciones nuevas)
        /// </summary>
        public string txt_aux1 { get; set; }

        /// <summary>
        ///  Campo auxiliar 2 (para datos especificos de una instalacion.  este campo no se debe usar en instalaciones nuevas)
        /// </summary>
        public string txt_aux2 { get; set; }

        /// <summary>
        ///  Campo auxiliar 3 (para datos especificos de una instalacion.  este campo no se debe usar en instalaciones nuevas)
        /// </summary>
        public string txt_aux3 { get; set; }

        /// <summary>
        ///  Campo auxiliar 4 (para datos especificos de una instalacion.  este campo no se debe usar en instalaciones nuevas)
        /// </summary>
        public string txt_aux4 { get; set; }

        /// <summary>
        ///  Campo auxiliar 5 (para datos especificos de una instalacion.  este campo no se debe usar en instalaciones nuevas)
        /// </summary>
        public string txt_aux5 { get; set; }

        /// <summary>
        ///  Campo auxiliar 6
        /// </summary>
        public string txt_aux6 { get; set; }

        /// <summary>
        ///  Campo auxiliar 7
        /// </summary>
        public string txt_aux7 { get; set; }

        /// <summary>
        ///  Campo auxiliar 8
        /// </summary>
        public string txt_aux8 { get; set; }

        /// <summary>
        ///  Campo auxiliar 9
        /// </summary>
        public string txt_aux9 { get; set; }

        /// <summary>
        ///  Usuario que actualizo la fila
        /// </summary>
        public string cod_usr { get; set; }

        /// <summary>
        ///  Fecha de la ultima actualizacion del registro
        /// </summary>
        public DateTime fec_actu { get; set; }

        /// <summary>
        ///  Telefono movil del tercero
        /// </summary>
        public string tlf_movil { get; set; }

        /// <summary>
        ///  Número del busca
        /// </summary>
        public string num_busca { get; set; }

        /// <summary>
        ///  Tipo de direccion de etiqueta
        /// </summary>
        public int tip_etiqueta { get; set; }

        /// <summary>
        ///  Segundo nivel de la estructura geografica
        /// </summary>
        public int cod_estado { get; set; }

        /// <summary>
        ///  Segundo nivel de la estructura geografica. direccion comercial
        /// </summary>
        public int cod_estado_com { get; set; }

        /// <summary>
        ///  Direccion de correo electronico
        /// </summary>
        public string txt_email { get; set; }

        /// <summary>
        ///  Apartado postal. direccion comercial
        /// </summary>
        public string num_apartado_com { get; set; }

        /// <summary>
        ///  Pais, primer nivel de la estructura geografica. direccion etiqueta
        /// </summary>
        public string cod_pais_etiqueta { get; set; }

        /// <summary>
        ///  Estado, segundo nivel de la estructura geografica. direccion etiqueta
        /// </summary>
        public int cod_estado_etiqueta { get; set; }

        /// <summary>
        ///  Tercer nivel de la estructura geografica. direccion etiqueta
        /// </summary>
        public int cod_prov_etiqueta { get; set; }

        /// <summary>
        ///  Código postal. direccion etiqueta
        /// </summary>
        public string cod_postal_etiqueta { get; set; }

        /// <summary>
        ///  Número del apartado postal. direccion etiqueta
        /// </summary>
        public string num_apartado_etiqueta { get; set; }

        /// <summary>
        ///  Cuarto nivel de la estructura geografica
        /// </summary>
        public int cod_localidad { get; set; }

        /// <summary>
        ///  Tipo de tarjeta de credito
        /// </summary>
        public int tip_tarjeta { get; set; }

        /// <summary>
        ///  Código de tarjeta de credito
        /// </summary>
        public int cod_tarjeta { get; set; }

        /// <summary>
        ///  Número de la tarjeta de credito
        /// </summary>
        public string num_tarjeta { get; set; }

        /// <summary>
        ///  Localidad, cuarto nivel de la estructura geografica. direccion comercial
        /// </summary>
        public int cod_localidad_com { get; set; }

        /// <summary>
        ///  Localidad, cuarto nivel de la estructura geografica. direccion etiqueta
        /// </summary>
        public int cod_localidad_etiqueta { get; set; }

        /// <summary>
        ///  Descripcion del cuarto nivel de la estructura geografica. direccion etiqueta
        /// </summary>
        public string nom_localidad_etiqueta { get; set; }

        /// <summary>
        ///  Vencimiento de la tarjeta de credito
        /// </summary>
        public DateTime fec_vcto_tarjeta { get; set; }

        /// <summary>
        ///  Forma en la que el tercero cobra o paga
        /// </summary>
        public int cod_compensacion { get; set; }

        /// <summary>
        ///  Sociedad para consolidacion del grupo mapfre
        /// </summary>
        public string cod_soc_gl { get; set; }

        /// <summary>
        ///  Alias del tercero
        /// </summary>
        public string nom_alias { get; set; }

        /// <summary>
        ///  Segundo nombre
        /// </summary>
        public string nom2_tercero { get; set; }

        /// <summary>
        ///  Sufijo del nombre (sr., jr.  ,etc)
        /// </summary>
        public string tip_sufijo_nombre { get; set; }

        /// <summary>
        ///  Clase de beneficiario
        /// </summary>
        public string cod_clase_benef { get; set; }

        /// <summary>
        ///  Causa de inhabilitacion del tercero
        /// </summary>
        public int cod_causa_inh_trc { get; set; }

        /// <summary>
        ///  Fila inhabilitada
        /// </summary>
        public string mca_inh { get; set; }

        /// <summary>
        ///  Número de carnet de conducir
        /// </summary>
        public string num_carnet_con { get; set; }

        /// <summary>
        ///  Situación del carnet de conducir (vigente, suspendida, anulada, etc.)
        /// </summary>
        public string cod_situ_carnet_con { get; set; }

        /// <summary>
        ///  Número de la calle
        /// </summary>
        public string atr_domicilio1 { get; set; }

        /// <summary>
        ///  Número de portal
        /// </summary>
        public string atr_domicilio2 { get; set; }

        /// <summary>
        ///  Piso
        /// </summary>
        public string atr_domicilio3 { get; set; }

        /// <summary>
        ///  Letra de puerta
        /// </summary>
        public string atr_domicilio4 { get; set; }

        /// <summary>
        ///  Escalera
        /// </summary>
        public string atr_domicilio5 { get; set; }

        /// <summary>
        ///  Urbanización /polígono
        /// </summary>
        public string anx_domicilio { get; set; }

        /// <summary>
        ///  Extensión al código postal (será parametrizable)
        /// </summary>
        public string ext_cod_postal { get; set; }

        /// <summary>
        ///  Extensión telefónica
        /// </summary>
        public string tlf_extension { get; set; }

        /// <summary>
        ///  Nombre de la empresa (para la dirección comercial)
        /// </summary>
        public string nom_empresa_com { get; set; }

        /// <summary>
        ///  Número de la calle (comercial)
        /// </summary>
        public string atr_domicilio1_com { get; set; }

        /// <summary>
        ///  Portal (comercial)
        /// </summary>
        public string atr_domicilio2_com { get; set; }

        /// <summary>
        ///  Piso (comercial)
        /// </summary>
        public string atr_domicilio3_com { get; set; }

        /// <summary>
        ///  Letra de puerta  (comercial)
        /// </summary>
        public string atr_domicilio4_com { get; set; }

        /// <summary>
        ///  Escalera (comercial)
        /// </summary>
        public string atr_domicilio5_com { get; set; }

        /// <summary>
        ///  Urbanización /polígono (comercial)
        /// </summary>
        public string anx_domicilio_com { get; set; }

        /// <summary>
        ///  Extensión telefónica (comercial)
        /// </summary>
        public string tlf_extension_com { get; set; }

        /// <summary>
        ///  Extensión  al código postal (será parametrizable)
        /// </summary>
        public string ext_cod_postal_com { get; set; }

        /// <summary>
        ///  Extensión al código postal de la etiqueta
        /// </summary>
        public string ext_cod_postal_etiqueta { get; set; }

        /// <summary>
        ///  Código geografico de  expedicion del carnet de conducir
        /// </summary>
        public int cod_exp_carnet_con { get; set; }


        public bool titular { get; set; }
    }
}