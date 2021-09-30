using Architect.Utilities.Extensions;
using Architect.Extend.Integrations.cr.fi.cs.crm;
using System;
using System.Globalization;

namespace Architect.Extend.Integrations.Coope
{
    /// <summary>
    /// Consultas de integración por parte de coopeservidores.
    /// </summary>
    public static class Consultas
    {

        /// <summary>
        /// Permite recuperar la información personal de un cliente por medio de su identificación.
        /// </summary>
        public static Architect.API.Insurance.Contracts.Policy.Insured ClientePorIdentificacion(string identificacion)
        {
            Architect.API.Insurance.Contracts.Policy.Insured result = null;
            Solicitud solicitud = new Solicitud()
            {
                encabezado = new EncabezadoSolicitud()
                {
                    idCanal = 45,
                    idMensaje = "1",
                    usuario = "MAPFRE",
                    fechaHora = DateTime.Now,
                    idServicio = 14,
                    idOperacion = 119,
                    version = "1"
                },
                cuerpo = new SolicitudCuerpo()
                {
                    entradaServicio = new entradaServicio()
                    {
                        PE_IDENTIFICACION = identificacion
                    }
                }
            };

            var client = new ServiciosMAPFREDigitalBindingQSService();
            try
            {
                Respuesta respuesta = client.ConsultarCliente(solicitud);
                if (respuesta?.cuerpo?.salidaServicio?.PS_CODIGO_MENSAJE == "0")
                {
                    result = new API.Insurance.Contracts.Policy.Insured()
                    {
                        DocumentType = int.Parse(respuesta.cuerpo.salidaServicio.PS_CODIGO_TIPO_IDENTIFICACION),
                        DocumentNumber = respuesta.cuerpo.salidaServicio.PS_NUMERO_IDENTIFICACION,
                        FirstName = respuesta.cuerpo.salidaServicio.PS_NOMBRES.Capitalize(),
                        MiddleName = string.Empty,
                        LastName = respuesta.cuerpo.salidaServicio.PS_PRIMER_APELLIDO.Capitalize(),
                        SecondLastName = respuesta.cuerpo.salidaServicio.PS_SEGUNDO_APELLIDO.Capitalize(),
                        BirthDate = DateTime.ParseExact(respuesta.cuerpo.salidaServicio.PS_FECHA_NACIMIENTO, "MM/dd/yyyy", CultureInfo.CurrentCulture),
                        Gender = int.Parse(respuesta.cuerpo.salidaServicio.PS_SEXO),
                        CivilStatus = int.Parse(respuesta.cuerpo.salidaServicio.PS_ESTADO_CIVIL),
                        PrimaryEmailAddress = respuesta.cuerpo.salidaServicio.PS_EMAIL,
                        Province = int.Parse(respuesta.cuerpo.salidaServicio.PS_PROVINCIA),
                        Canton = int.Parse(respuesta.cuerpo.salidaServicio.PS_CANTON),
                        District = int.Parse(respuesta.cuerpo.salidaServicio.PS_DISTRITO),
                        AddressDetail = respuesta.cuerpo.salidaServicio.PS_DIRECCION.Capitalize(),
                        PhoneType = int.Parse(respuesta.cuerpo.salidaServicio.PS_TIPO_TELEFONO),
                        PhoneNumber = respuesta.cuerpo.salidaServicio.PS_TELEFONO,
                        Source = "Coope"
                    };

                    if (result.FirstName != null && result.FirstName.Split(' ').Length == 2)
                    {
                        result.MiddleName = result.FirstName.Split(' ')[1].Trim().Capitalize();
                        result.FirstName = result.FirstName.Split(' ')[0].Trim().Capitalize();
                    }

                    if (result.PhoneNumber != null)
                    {
                        result.PhoneNumber = result.PhoneNumber.Replace("-", string.Empty).Trim();
                        result.PhoneNumber = result.PhoneNumber.Replace("(", string.Empty).Trim();
                        result.PhoneNumber = result.PhoneNumber.Replace(")", string.Empty).Trim();
                        if (result.PhoneNumber.StartsWith("506"))
                        {
                            result.PhoneNumber = result.PhoneNumber.Substring(3).Trim();
                        }
                        result.PhoneNumber = result.PhoneNumber.Substring(0, 4) + "-" + result.PhoneNumber.Substring(4, 4);
                    }
                }                
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Coope.ConsultarCliente",
                                                   string.Format("Falla al tratar de consultar a identificación '{0}'", identificacion),
                                                   ex, "integrations");
            }
            return result;
        }
    }
}
