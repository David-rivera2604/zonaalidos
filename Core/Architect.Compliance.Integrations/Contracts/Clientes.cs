using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Compliance.Integrations.Contracts
{
    public class Clientes
    {
        public int tipoIdentificacion { get; set; }
        public string numeroIdentificacion { get; set; }
        public string nombreCliente { get; set; }
        public string segundoNombreCliente { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string conocidoComo { get; set; }
        public string razonSocial { get; set; }
        public string nombreComercial { get; set; }
        public string descripcionCuenta { get; set; }
        public string numeroIdentificacionEntidad { get; set; }
        public DateTime fechaVencimientoIdentificacion { get; set; }
        public string lugarExpedicionIdentificacion { get; set; }
        public DateTime fechaUltimaActualizacion { get; set; }
        public string genero { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string estadoCivil { get; set; }
        public int paisOrigen { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaSalida { get; set; }
        public DateTime fechaInactividad { get; set; }
        public DateTime fechaVinculacion { get; set; }
        public string estado { get; set; }
        public string ejecutivo { get; set; }
        public string estadoXML { get; set; }
        public string tipoCuenta { get; set; }
        public int codigoOficina { get; set; }
        public string usuarioRegistro { get; set; }
        public string administFondosTercero { get; set; }
        public int estructuraLegal { get; set; }
        public int profesion { get; set; }
        public int actividadEconomica { get; set; }
        public string sectorPublico { get; set; }
        public string institucionLabora { get; set; }
        public int cantidadAnosLaborar { get; set; }
        public int monedaIngresoMensual { get; set; }
        public int montoIngresoMensual { get; set; }
        public string esEmpleado { get; set; }
        public string esPep { get; set; }
        public string tipoPep { get; set; }
        public string articulo15 { get; set; }
        public int origenFondos { get; set; }
        public int inversionInicial { get; set; }
        public string residente { get; set; }
        public DateTime fechaCargaCliente { get; set; }
        public int usuario { get; set; }
        public DateTime fechaValor { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string descripcionObservaciones { get; set; }
        public string esApnfd { get; set; }
        public string tipoApnfd { get; set; }
        public DateTime fechaRegistroApnfd { get; set; }
        public int entidadSupervisora { get; set; }
        public string esCpe { get; set; }
        public string pagaImpuestos { get; set; }
        public Clientesnacionalidade[] clientesNacionalidades { get; set; }
        public List<Clientesubicacione> clientesUbicaciones { get; set; }
        public Clientesfatca[] clientesFATCA { get; set; }
        public Clientesingreso[] clientesIngresos { get; set; }
        public Clientesfondostercero[] clientesFondosTerceros { get; set; }
        public Clientespatrimonio[] clientesPatrimonio { get; set; }
        public Clientesfuncionespep[] clientesFuncionesPEP { get; set; }
        public Clientestransaccione[] clientesTransacciones { get; set; }
        public List<Clientespoliza> clientesPolizas { get; set; }
        public Clientesotrosatributo[] clientesOtrosAtributos { get; set; }
        public Clientessocio[] clientesSocios { get; set; }
        public Clientesrelacione[] clientesRelaciones { get; set; }
        public Clientesrepresentante[] clientesRepresentantes { get; set; }
        public int codigoCompania { get; set; }
        public string nombreContacto { get; set; }
        public int tipoEntidad { get; set; }
        public int codigoPromedioIngresoMensual { get; set; }
        public int codigoPromedioEgresoMensual { get; set; }
        public int codigoPrincipalFuenteIngreso { get; set; }
        public string descripcionInversionInicial { get; set; }
        public int codigoSesion { get; set; }
        public DateTime fechaProximaActualizacion { get; set; }
    }

    public class Clientesnacionalidade
    {
        public int nacionalidad { get; set; }
    }

    public class Clientesubicacione
    {
        public int tipoUbicacion { get; set; }
        public int divisionTerritorial { get; set; }
        public string descripcionUbicacion { get; set; }
    }

    public class Clientesfatca
    {
        public string poseeGreenCard { get; set; }
        public string poseeEIN { get; set; }
        public string numeroEIN { get; set; }
        public string contribuyenteUSA { get; set; }
        public string numeroTIN { get; set; }
        public string domicilioExtranjero { get; set; }
        public int paisDomicilio { get; set; }
        public string detalleDomicilio { get; set; }
        public string poseeTelefonoExtranjero { get; set; }
        public string telefonoExtranjero { get; set; }
        public string poseeProductos { get; set; }
        public string detalleProductos { get; set; }
    }

    public class Clientesingreso
    {
        public string nombreEmpresa { get; set; }
        public string cargo { get; set; }
        public int actividadEconomica { get; set; }
        public string telefonoCentral { get; set; }
        public string telefonoDirecto { get; set; }
        public string direccion { get; set; }
        public int divisionTerritorial { get; set; }
        public int origenRecursos { get; set; }
        public string justificacionOrigenRecursos { get; set; }
        public string detalle { get; set; }
        public string sustentoOtraPersonas { get; set; }
        public string detalleSustento { get; set; }
        public int monto { get; set; }
        public int moneda { get; set; }
    }

    public class Clientesfondostercero
    {
        public int tipoIdentificacionTercero { get; set; }
        public string numeroIdentificacionTercero { get; set; }
        public string nombreTercero { get; set; }
        public int paisOrigen { get; set; }
        public int actividadEconomica { get; set; }
        public int origenRecursos { get; set; }
        public int monto { get; set; }
        public int moneda { get; set; }
    }

    public class Clientespatrimonio
    {
        public string descripcionPatrimonio { get; set; }
        public int tipoBien { get; set; }
        public int moneda { get; set; }
        public int montoValor { get; set; }
        public DateTime fechaRegistro { get; set; }
    }

    public class Clientesfuncionespep
    {
        public string cargo { get; set; }
        public string esVigente { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinalizacion { get; set; }
        public string entidad { get; set; }
        public int pais { get; set; }
    }

    public class Clientestransaccione
    {
        public string inversionInicial { get; set; }
        public string detalleInversionInicial { get; set; }
        public int monto { get; set; }
        public int cantidadIngresoMensuales { get; set; }
        public int montoIngresoMensual { get; set; }
        public int cantidadEgresoMensuales { get; set; }
        public int montoEgresoMensual { get; set; }
        public string finalidad { get; set; }
        public string motivo { get; set; }
        public string frecuencia { get; set; }
    }

    public class Clientespoliza
    {
        public string numeroPoliza { get; set; }
        public string descripcionPoliza { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinalizacion { get; set; }
        public int moneda { get; set; }
        public int prima { get; set; }
        public int montoAsegurado { get; set; }
        public string tipoPrima { get; set; }
        public string estado { get; set; }
        public string tipoPoliza { get; set; }
        public int tipoProducto { get; set; }
        public int tipoIdentificacion { get; set; }
        public string identificacion { get; set; }
    }

    public class Clientesotrosatributo
    {
        public int atributo { get; set; }
        public string descripcionAtributo { get; set; }
    }

    public class Clientessocio
    {
        public int tipoIdentificacionSocio { get; set; }
        public string numeroIdentificacionSocio { get; set; }
        public string nombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string conocidoComo { get; set; }
        public string genero { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string estadoCivil { get; set; }
        public int paisOrigen { get; set; }
        public int profesion { get; set; }
        public int actividadEconomica { get; set; }
        public string esPep { get; set; }
        public string tipoPep { get; set; }
        public string descripcionPep { get; set; }
        public string articulo15 { get; set; }
        public int participacion { get; set; }
    }

    public class Clientesrelacione
    {
        public int tipoRelacion { get; set; }
        public int tipoIdentificacionRelacion { get; set; }
        public string numeroIdentificacionRelacion { get; set; }
        public string nombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string conocidoComo { get; set; }
        public string genero { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string estadoCivil { get; set; }
        public int paisOrigen { get; set; }
        public int profesion { get; set; }
        public int actividadEconomica { get; set; }
        public string esPep { get; set; }
        public string tipoPep { get; set; }
        public string articulo15 { get; set; }
        public string beneficiario { get; set; }
        public string titular { get; set; }
        public string tipoTitularidad { get; set; }
        public int participacion { get; set; }
        public DateTime fechaVencimientoIdentificacion { get; set; }
        public string cargo { get; set; }
        public string descripcionPep { get; set; }
        public DateTime fechaInscripcionCargo { get; set; }
        public DateTime fechaFinalizacionCargo { get; set; }
        public Clientesrelacionesnacionalidade[] clientesRelacionesNacionalidades { get; set; }
        public Clientesrelacionesubicacione[] clientesRelacionesUbicaciones { get; set; }
        public int codigoSesion { get; set; }
        public int codigoRelacion { get; set; }
        public string descripcionUbicacion { get; set; }
    }

    public class Clientesrelacionesnacionalidade
    {
        public int nacionalidad { get; set; }
    }

    public class Clientesrelacionesubicacione
    {
        public int tipoUbicacion { get; set; }
        public int divisionTerritorial { get; set; }
        public string descripcionUbicacion { get; set; }
    }

    public class Clientesrepresentante
    {
        public int tipoIdentificacionRepresentante { get; set; }
        public string numeroIdentificacionRepresentante { get; set; }
        public string nombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string conocidoComo { get; set; }
        public string genero { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string estadoCivil { get; set; }
        public int paisOrigen { get; set; }
        public int profesion { get; set; }
        public int actividadEconomica { get; set; }
        public string esPep { get; set; }
        public string tipoPep { get; set; }
        public string descripcionPep { get; set; }
        public string articulo15 { get; set; }
        public string cargo { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public Clientesrepresentantesnacionalidade[] clientesRepresentantesNacionalidades { get; set; }
        public Clientesrepresentantesubicacione[] clientesRepresentantesUbicaciones { get; set; }
        public int codigoSesion { get; set; }
        public int codigoRegistro { get; set; }
    }

    public class Clientesrepresentantesnacionalidade
    {
        public int nacionalidad { get; set; }
    }

    public class Clientesrepresentantesubicacione
    {
        public int tipoUbicacion { get; set; }
        public int divisionTerritorial { get; set; }
        public string descripcionUbicacion { get; set; }
    }

}
