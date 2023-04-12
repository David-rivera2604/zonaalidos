using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts
{
    /// <summary>
    /// Conozca a su cliente Datos Genericos
    /// </summary>
    public class Kyc
    {
        /// <summary>
        /// Numero de identificacion
        /// </summary>
        public string numidentificacion { get; set; }

        //Domicilio Permanente

        /// <summary>
        /// Codigo Pais Domicilio Permanente
        /// </summary>
        public string domiciliopermanenteCod_pais { get; set; }
        /// <summary>
        /// Pais Describcion Domicilio Permanente
        /// </summary>
        public string domiciliopermanenteCod_paisDesc { get; set; }
        /// <summary>
        /// Codigo Provincia Domicilio Permanente
        /// </summary>
        public int domiciliopermanenteCod_estado { get; set; }
        /// <summary>
        /// Provincia Describcion Domicilio Permanente
        /// </summary>
        public string domiciliopermanenteCod_estadoDesc { get; set; }
        /// <summary>
        /// Codigo Canton Domicilio Permanente
        /// </summary>
        public int domiciliopermanenteCod_prov { get; set; }
        /// <summary>
        /// Canton Describcion Domicilio Permanente
        /// </summary>
        public string domiciliopermanenteCod_provDesc { get; set; }
        /// <summary>
        /// Codigo Distrito Domicilio Permanente
        /// </summary>
        public int domiciliopermanenteCod_localidad { get; set; }
        /// <summary>
        /// Distrito Describcion Domicilio Permanente
        /// </summary>
        public string domiciliopermanenteCod_localidadDesc { get; set; }
        /// <summary>
        /// Direccion exacta Domicilio Permanente
        /// </summary>
        public string domiciliopermanenteDireccionexacta { get; set; }

        //Domicilio comercial

        /// <summary>
        /// Codigo Pais Domicilio comercial
        /// </summary>
        public string domiciliocomercialCod_pais { get; set; }
        /// <summary>
        /// Pais describcion Domicilio comercial
        /// </summary>
        public string domiciliocomercialCod_paisDesc { get; set; }
        /// <summary>
        /// Codigo de provincia Domicilio comercial
        /// </summary>
        public int domiciliocomercialCod_estado { get; set; }
        /// <summary>
        /// Provincia describcion Domicilio comercial
        /// </summary>
        public string domiciliocomercialCod_estadoDesc { get; set; }
        /// <summary>
        /// Codigo de canto Domicilio comercial
        /// </summary>
        public int domiciliocomercialCod_prov { get; set; }
        /// <summary>
        /// Canton describcion Domicilio comercial
        /// </summary>
        public string domiciliocomercialCod_provDesc { get; set; }
        /// <summary>
        /// Codigo distrito Domicilio comercial
        /// </summary>
        public int domiciliocomercialCod_localidad { get; set; }
        /// <summary>
        /// Distrito describcion Domicilio comercial
        /// </summary>
        public string domiciliocomercialCod_localidadDesc { get; set; }
        /// <summary>
        /// Direccion exacta Domicilio comercial
        /// </summary>
        public string domiciliocomercialDireccionexacta { get; set; }


        //Origen de los fondos

        /// <summary>
        /// Correspondencia Origen de los fondos persona
        /// </summary>
        public string correspondenciaOrigendelosfondos { get; set; }
        /// <summary>
        /// Pais de mayor actividad economica
        /// </summary>
        public string paismayoractividad { get; set; }
        /// <summary>
        /// Ingresos mensuales estimados persona
        /// </summary>
        public int ingresomensualestimado { get; set; }
        /// <summary>
        /// No. Fondos Propios o de terceros
        /// </summary>
        public int fondospormivilizar { get; set; }
        /// <summary>
        /// Fondos Propios o de terceros Describcion
        /// </summary>
        public string fondospormivilizarDesc { get; set; }
        /// <summary>
        /// No. Desempeñado en las actividades del articulo 15 
        /// </summary>
        public int actividadesart15 { get; set; }
        /// <summary>
        /// Desempeñado en las actividades del articulo 15 Describcion 
        /// </summary>
        public string actividadesart15Desc { get; set; }

        //Tipos de activos

        /// <summary>
        /// No. Activos corresponden a
        /// </summary>
        public int activoscorresponden { get; set; }
        /// <summary>
        /// Activos corresponden describcion
        /// </summary>
        public string activoscorrespondenDesc { get; set; }

        //PEPs

        /// <summary>
        /// No. Pep cargo funciones publicas
        /// </summary>
        public int pepcargo { get; set; }
        /// <summary>
        /// Pep cargo funciones publicas describcion
        /// </summary>
        public string pepcargoDesc { get; set; }
        /// <summary>
        /// PEP Duracion de las funciones publicas
        /// </summary>
        public string pepduracion { get; set; }
        /// <summary>
        /// No. PEP Relacion con personas expuestas politicamente
        /// </summary>
        public int peprelacion { get; set; }
        /// <summary>
        /// PEP Relacion con personas expuestas politicamente describcion
        /// </summary>
        public string peprelacionDesc { get; set; }
        /// <summary>
        /// Tipo de relacion
        /// </summary>
        public string peptiporelacion { get; set; }

        //Describcion de la poliza


        /// <summary>
        /// Proposito de la relacion comercial
        /// </summary>
        public string propositorelacioncomercial { get; set; }
        /// <summary>
        /// Monto de la prima
        /// </summary>
        public int montoprima { get; set; }
        /// <summary>
        /// Tipo de prima
        /// </summary>
        public string tipodeprima { get; set; }
        /// <summary>
        /// No. Periodicad
        /// </summary>
        public int periodicidad { get; set; }
        /// <summary>
        ///  Periodicad Describcion
        /// </summary>
        public string periodicidadDesc { get; set; }
        /// <summary>
        /// Monto del valor asegurado
        /// </summary>
        public int montoValorasegurado { get; set; }
        /// <summary>
        /// No. Forma de pago de la poliza
        /// </summary>
        public int formadepagodelapoliza { get; set; }
        /// <summary>
        /// Forma de pago de la poliza Describcion
        /// </summary>
        public string formadepagodelapolizaDesc { get; set; }

        //Correspondencia

        /// <summary>
        /// No. Medio de envio 
        /// </summary>
        public int mediodeenvio { get; set; }
        /// <summary>
        /// Medio de envio describcion
        /// </summary>
        public string mediodeenvioDesc { get; set; }
        /// <summary>
        /// Especificacion de Correspondencia
        /// </summary>
        public string especifique { get; set; }
        /// <summary>
        /// Actividad Economica
        /// </summary>
        public int actividadEconomica { get; set; }
        
        /// <summary>
        /// FATCA
        /// </summary>
        public string numeroTIN { get; set; }
        public string numeroExt { get; set; }
        public string otrassenasFATCA { get; set; }
        public int greencard { get; set; }
        public int identificacionEIN { get; set; }
        public int contribuyenteUSA { get; set; }
        public int domicilioExtranjero { get; set; }
        public int paisDomicilio { get; set; }
        public int poseeTelefonoExtranjero { get; set; }
        public int aportaXMLFATCA { get; set; }

        /// <summary>
        /// Otros Atributos
        /// </summary>
        public int atributocanaldeingreso { get; set; }
        public int valorcanalingreso { get; set; }
        public string valorcanalingresoDesc { get; set; }
    }

    /// <summary>
    /// Conozca a su cliente Persona
    /// </summary>
    public class Kycpersona : Kyc
    {
        //Datos Generales
        /// <summary>
        /// Apellido de la persona
        /// </summary>
        public string primerapellidoPer { get; set; }
        /// <summary>
        /// Apellido de la persona
        /// </summary>
        public string segundoapellidoPer { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string nombrePer { get; set; }
        /// <summary>
        /// Codigo del cliente
        /// </summary>
        public string codigodeclientePer { get; set; }

        /// <summary>
        /// No. Tipo de identificacion
        /// </summary>
        public int numidentificaciontipo { get; set; }
        /// <summary>
        /// Tipo de identificacion describcion
        /// </summary>
        public string numidentificaciontipoDesc { get; set; }
        /// <summary>
        /// Fecha de caducidad
        /// </summary>
        public DateTime fechadecaducidadPer { get; set; }
        /// <summary>
        /// No. Nacionalidad
        /// </summary>
        public int nacionalidadPer { get; set; }
        /// <summary>
        /// Nacionalidad describcion
        /// </summary>
        public string nacionalidadPerDesc { get; set; }
        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        public DateTime fechadenacimientoPer { get; set; }
        /// <summary>
        /// No. Pais de nacimiento
        /// </summary>
        public int paisdenacimientoPer { get; set; }
        /// <summary>
        /// Pais de nacimiento Describicion
        /// </summary>
        public string paisdenacimientoPerDesc { get; set; }
        /// <summary>
        /// No. Profesion
        /// </summary>
        public int profesionPer { get; set; }
        /// <summary>
        /// Profesion Describcion
        /// </summary>
        public string profesionPerDesc { get; set; }
        /// <summary>
        /// No. Estado Civil
        /// </summary>
        public int estadocivilPer { get; set; }
        /// <summary>
        /// Estado Civil Describcion
        /// </summary>
        public string estadocivilPerDesc { get; set; }
        /// <summary>
        /// No. Sexo
        /// </summary>
        public int sexoPer { get; set; }
        /// <summary>
        /// Sexo Describcion
        /// </summary>
        public string sexoPerDesc { get; set; }
        /// <summary>
        /// No. de póliza.
        /// </summary>
        public string telefonoresidenciaPer { get; set; }
        /// <summary>
        /// Telefono Persona
        /// </summary>
        public string telefonocelularPer { get; set; }
        /// <summary>
        /// Fax Persona
        /// </summary>
        public string faxPer { get; set; }
        /// <summary>
        /// Apartado Postal Persona
        /// </summary>
        public string apartadopostalPer { get; set; }
        /// <summary>
        /// Correo electronico persona
        /// </summary>
        public string correoelectronicoPer { get; set; }

        //Ocupacion 

        /// <summary>
        /// No. Ocupacion de la persona
        /// </summary>

        public int OcupacionPer { get; set; }
        /// <summary>
        /// Ocupacion persona describcion
        /// </summary>
        public string OcupacionPerDesc { get; set; }
        /// <summary>
        /// Nombre Empresa
        /// </summary>

        //Datos de la empresa o lugar que genera sus ingresos en caso de ser independiente
        public string nombreempresaPer { get; set; }
        /// <summary>
        /// Actividades en la empresa
        /// </summary>
        public string actividadempresaPer { get; set; }
        /// <summary>
        /// Cargo en la empresa
        /// </summary>
        public string cargoempresaPer { get; set; }
        /// <summary>
        /// Telefono de la empresa
        /// </summary>
        public string telefonoempresaPer { get; set; }
        /// <summary>
        /// Fax de la empresa
        /// </summary>
        public string faxempresaPer { get; set; }



    }

    /// <summary>
    /// Conozca a su cliente Juridico
    /// </summary>
    public class KycJuridico : Kyc
    {
        //Datos de la empresa
        /// <summary>
        /// Nombre comercial
        /// </summary>
        public string nombrecomercialJur { get; set; }
        /// <summary>
        /// Razon Social
        /// </summary>
        public string razonsocialJur { get; set; }
        /// <summary>
        /// Codigo del cliente juridico
        /// </summary>
        public string codigodeclienteJur { get; set; }
        /// <summary>
        /// Tipo de sociedad
        /// </summary>
        public string tipodesociedadJur { get; set; }
        /// <summary>
        /// No. Tipo de cedula juridica
        /// </summary>
        public int tipodecedulajuridicaJur { get; set; }
        /// <summary>
        /// Describcion Tipo de cedula juridica
        /// </summary>
        public string tipodecedulajuridicaJurDesc { get; set; }
        /// <summary>
        /// No. Pais de constitucion
        /// </summary>
        public int paisdeconstitucionJur { get; set; }
        /// <summary>
        /// Describcion Pais de constitucion
        /// </summary>
        public string paisdeconstitucionJurDesc { get; set; }
        /// <summary>
        /// Fecha de constitucion
        /// </summary>
        public DateTime fechadeconstitucionJur { get; set; }
        /// <summary>
        /// Actividad del cliente
        /// </summary>
        public string actividaddelclientenaturalezadelnegocioJur { get; set; }
        /// <summary>
        /// Telefono Juridico
        /// </summary>
        public string telefonoJur { get; set; }
        /// <summary>
        /// Fax Juridico
        /// </summary>
        public string faxJur { get; set; }
        /// <summary>
        /// Apartado postal juridico
        /// </summary>
        public string apartadopostalJur { get; set; }
        /// <summary>
        /// correo electronico juridico
        /// </summary>
        public string correoelectronicoJur { get; set; }
        /// <summary>
        /// Pagina wbe juridico
        /// </summary>
        public string paginaWebJur { get; set; }

        //Datos del representante
        /// <summary>
        /// Representante legal primer apellido
        /// </summary>
        public string primerapellidoJur { get; set; }
        /// <summary>
        /// Representante legal segundo apellido
        /// </summary>
        public string segundoapellidoJur { get; set; }
        /// <summary>
        /// Representante legal nombre completo
        /// </summary>
        public string nombrecompletoJur { get; set; }
        /// <summary>
        /// Representante legal posicion dentro de la empresa
        /// </summary>
        public string posiciondentrodelaempresaJur { get; set; }
        /// <summary>
        /// Representante legal No. de identificacion
        /// </summary>
        public string numerodeidentificacionJur { get; set; }
        /// <summary>
        /// Representante legal No. Tipo de identificacion
        /// </summary>
        public int tipodeidentificacionJur { get; set; }
        /// <summary>
        /// Representante legal describcion tipo de identificacion
        /// </summary>
        public string tipodeidentificacionJurDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string especifiqueJur { get; set; }
        /// <summary>
        /// Representante legal Fecha de caducidad
        /// </summary>
        public DateTime fechadecaducidadJur { get; set; }
        /// <summary>
        /// Representante legal No. Nacionalidad
        /// </summary>
        public int nacionalidadJur { get; set; }
        /// <summary>
        /// Representante legal describcion nacionalidad
        /// </summary>
        public string nacionalidadJurDesc { get; set; }
        /// <summary>
        /// Representante legal fecha de nacimiento
        /// </summary>
        public DateTime fechadenacimientoJur { get; set; }
        /// <summary>
        /// Representante legal No. pais de nacimiento
        /// </summary>
        public int paisdenacimientoJur { get; set; }
        /// <summary>
        /// Representante legal describcion pais de nacimiento
        /// </summary>
        public string paisdenacimientoJurDesc { get; set; }
        /// <summary>
        /// Representante legal No. Profesion
        /// </summary>
        public int profesionJur { get; set; }
        /// <summary>
        /// Representante legal Describcion Profesion
        /// </summary>
        public string profesionJurDesc { get; set; }
        /// <summary>
        /// Representante legal No. estado civil
        /// </summary>
        public int estadocivilJur { get; set; }
        /// <summary>
        /// Representante legal Describcion estado civil
        /// </summary>
        public string estadocivilJurDesc { get; set; }
        /// <summary>
        /// Representante legal No. Sexo
        /// </summary>
        public int sexoJur { get; set; }
        /// <summary>
        /// Representante legal Describcion Sexo
        /// </summary>
        public string sexoJurDesc { get; set; }

        /// <summary>
        /// Representante legal telefono de residencia
        /// </summary>
        public string telefonoresidenciaJur { get; set; }
        /// <summary>
        /// Representante legal Telefono celular
        /// </summary>
        public string telefonocelularJur { get; set; }
        /// <summary>
        /// Representante legal fax
        /// </summary>
        public string datosdelrepresentantelegalFaxJur { get; set; }
        /// <summary>
        /// Representante legal Apartado postal
        /// </summary>
        public string datosdelrepresentantelegalApartadopostalJur { get; set; }
        /// <summary>
        /// Representante legal Correo electronico
        /// </summary>
        public string datosdelrepresentantelegalCorreoelectronicoJur { get; set; }

        //Participación accionaria
        /// <summary>
        /// Participacion de accionarios
        /// </summary>
        public List<Participador_Accionario> participacionaccionariaJur { get; set; }
        public string participaciostring { get; set; }

        public int actividadEconomicaRep { get; set; }


    }


}

public class Participador_Accionario
{
    public string participacionaccionariaNombrecompletoJur { get; set; }
    public int porcentajedeparticipacionJur { get; set; }
    public string participacionaccionariaJurId { get; set; }
    public string participacionaccionariaNumerodeidentificacionJur { get; set; }
    public int participacionaccionariaTipodeidentificacionJur { get; set; }
    public string participacionaccionariaTipodeidentificacionJurDesc { get; set; }
    public int participacionaccionariaSexoJur { get; set; }
    public string participacionaccionariaSexoJurDesc { get; set; }
    public DateTime participacionaccionariaFechadenacimientoJur { get; set; }
    public int participacionaccionariaPaisdenacimientoJur { get; set; }
    public string participacionaccionariaPaisdenacimientoJurDesc { get; set; }
    public int participacionaccionariaProfesionJur { get; set; }
    public string participacionaccionariaProfesionJurDesc { get; set; }
    public int participacionaccionariaEstadocivilJur { get; set; }
    public string participacionaccionariaEstadocivilJurDesc { get; set; }
    public int participacionaccionariaPepCargoJur { get; set; }
    public string participacionaccionariaPepCargoJurDesc { get; set; }
    public string pepduracionsocioJur { get; set; }
    public int participacionaccionariaPepRelacionJur { get; set; }
    public string participacionaccionariaPepRelacionJurDesc { get; set; }
    public string peptiporelacionSocioJur { get; set; }
    public int participacionaccionariaArt15Jur { get; set; }
    public string participacionaccionariaArt15JurDesc { get; set; }
    public int participacionaccionariaAct_Economica { get; set; }
    public string participacionaccionariaAct_EconomicaDesc { get; set; }
}