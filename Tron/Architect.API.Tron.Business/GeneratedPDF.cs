using iTextSharp.text.pdf;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using Architect.API.Tron.Contracts.Comun;
using Architect.API.Tron.Contracts.Emision;
using Architect.Utilities.Extensions;

namespace Architect.API.Tron.Business.DocumentGenerator
{
    public class GeneratedPDF
    {
        public string GeneratePDF(dynamic datos, Core.Contracts.Security.Token tokenInfo)
        {

            string PlantillaPdf = string.Empty;
            string filenamenew = string.Empty;
            string fullnewpath = string.Empty;
            string fullpath = string.Empty;

            if (datos is Contracts.Emision.MultirriesgoSolicitud) {
                MultirriesgoSolicitud multirriesgoSolicitud = datos;
                if (tokenInfo.Roles.Contain("PolizaGrupo") && multirriesgoSolicitud.polizagrupo != null)
                {
                    filenamenew = @"MultiriesgoSolicitud(Colectiva)_" + multirriesgoSolicitud.presupuesto.Replace(" ", "").Trim() + ".pdf";
                    PlantillaPdf = @"MultiriesgoSolicitud_Colectiva_Juridico.pdf";
                }
                else
                {
                    filenamenew = @"MultiriesgoSolicitud(Individual)_" + multirriesgoSolicitud.presupuesto.Replace(" ", "").Trim() + ".pdf";
                    
                    if (multirriesgoSolicitud.titular.DocumentNumberType == 4)
                    {
                        PlantillaPdf = @"MultiriesgoSolicitud_Individual_Juridico.pdf";
                        
                    }
                    else
                    {
                        PlantillaPdf = @"MultiriesgoSolicitud_Individual_Persona.pdf";
                    }
                }

                fullnewpath = ConfigurationManager.AppSettings["Attachments.Path"] + filenamenew;
                fullpath = ConfigurationManager.AppSettings["Reportpdf.Path"] + PlantillaPdf;

                using (var existingfilestream = new FileStream(fullpath, FileMode.Open))

                using (var newfilestream = new FileStream(fullnewpath, FileMode.Create))
                {
                    var pdfreader = new PdfReader(existingfilestream);

                    var stamper = new PdfStamper(pdfreader, newfilestream);

                    AcroFields fields = stamper.AcroFields;

                    FileData(multirriesgoSolicitud, fields);

                    tercero titular = multirriesgoSolicitud.titular;
                    tercero asegurado = multirriesgoSolicitud.asegurado;


                    string NombreCompletoTom = titular.nombre + " " + titular.apellido1 + " " + titular.apellido2;
                    string NombreCompletoAse = asegurado.nombre + " " + asegurado.apellido1 + " " + asegurado.apellido2;

                    fields.SetField("NombreCompletoTom", NombreCompletoTom);
                    fields.SetField("NombreCompletoTom_2", NombreCompletoTom);
                    fields.SetField("NombreCompletoAse", NombreCompletoAse);
                    fields.SetField("cod_mon#1", (multirriesgoSolicitud.cod_mon).ToString());

                    stamper.FormFlattening = true;
                    stamper.Close();
                    pdfreader.Close();
                }
            }
            else if (datos is Contracts.Emision.HogarTotalSolicitud)
            {
                HogarTotalSolicitud hogartotalSolicitud = datos;
                tercero titular = datos.titular;
                tercero asegurado = datos.asegurado;
                string presupuesto = datos.presupuesto;
                int typeForm = datos.terceros[0].DocumentNumberType; //Tipo de cedula 



                //KYC Juridico por repeticion de 2 datos en el PDF
                string periocidad2 = string.Empty;
                string formaPago2 = string.Empty;


                //Condition of TypePDF
                if (typeForm == 1) //Cedula Identidad
                {
                    PlantillaPdf = @"HogarTotalSolicitudMIP_.pdf";
                    filenamenew = @"HogarTotalSolicitudMIP_" + presupuesto.Replace(" ", "").Trim() + ".pdf"; //Modalidad Individual Persona
                }
                else if (tokenInfo.Roles.Contain("PolizaGrupo") && hogartotalSolicitud.polizagrupo != null) // Poliza Grupo
                {
                    PlantillaPdf = @"HogarTotalSolicitudMCPG_.pdf";
                    filenamenew = @"HogarTotalSolicitudMCPG_" + presupuesto.Replace(" ", "").Trim() + ".pdf"; //Modalidad Colectiva Poliza Grupo Rol Coopenae    

                    int anotherPeriocidad = datos.kyc.periodicidad;
                    periocidad2 = anotherPeriocidad.ToString();
                    int anotherPago = datos.kyc.formadepagodelapoliza;
                    formaPago2 = anotherPago.ToString();
                }
                else if (typeForm == 4) // Juridica
                {
                    PlantillaPdf = @"HogarTotalSolicitudMIJ_.pdf";
                    filenamenew = @"HogarTotalSolicitudMIJ_" + presupuesto.Replace(" ", "").Trim() + ".pdf"; //Modalidad Individual Juridica

                    int anotherPeriocidad = datos.kyc.periodicidad;
                    periocidad2 = anotherPeriocidad.ToString();
                    int anotherPago = datos.kyc.formadepagodelapoliza;
                    formaPago2 = anotherPago.ToString();
                }
                else
                {
                    PlantillaPdf = @"HogarTotalSolicitudMIP_.pdf";
                    filenamenew = @"HogarTotalSolicitudMIP_" + presupuesto.Replace(" ", "").Trim() + ".pdf";
                }

                fullnewpath = ConfigurationManager.AppSettings["Attachments.Path"] + filenamenew;
                fullpath = ConfigurationManager.AppSettings["Reportpdf.Path"] + PlantillaPdf;

                using (var existingfilestream = new FileStream(fullpath, FileMode.Open))
                using (var newfilestream = new FileStream(fullnewpath, FileMode.Create))
                {
                    var pdfreader = new PdfReader(existingfilestream);

                    var stamper = new PdfStamper(pdfreader, newfilestream);

                    AcroFields fields = stamper.AcroFields;

                    FileData(hogartotalSolicitud, fields);


                    //Repeticiones de datos PDF
                    int anotherMoneda = datos.moneda;
                    string moneda2 = anotherMoneda.ToString();

                    string NombreCompletoTom = titular.nombre + " " + titular.apellido1 + " " + titular.apellido2;
                    string NombreCompletoAse = asegurado.nombre + " " + asegurado.apellido1 + " " + asegurado.apellido2;


                    fields.SetField("NombreCompletoTom", NombreCompletoTom);
                    fields.SetField("NombreCompletoTom_2", NombreCompletoTom);
                    fields.SetField("NombreCompletoAse", NombreCompletoAse);
                    fields.SetField("periocidadJurKYCJ", periocidad2);
                    fields.SetField("formadepagodelapolizaJurKYCJ", formaPago2);
                    fields.SetField("moneda2", moneda2);

                    stamper.FormFlattening = true;
                    stamper.Close();
                    pdfreader.Close();
                }
            }
            return fullnewpath;
        }

        public void FileData(dynamic datos, AcroFields fields)
        {
            string thisDay = DateTime.Today.ToString("d");
            DateTime fecha = DateTime.Now;
            string thisHour = DateTime.Now.ToString("hh:mm:ss tt");
            string[] ListElement = thisDay.Split('/');
            string month = fecha.ToString("MMMM", new System.Globalization.CultureInfo("es-ES"));
            string day = ListElement[0];   
            string year = fecha.ToString("yyyy");

            fields.SetField("dia", day);
            fields.SetField("mes", month);
            fields.SetField("año", year);

            fields.SetField("Fecha_Creacion", thisDay);
            fields.SetField("Hora_Creacion", thisHour);

            Type _type = datos.GetType();

            System.Reflection.PropertyInfo[] LPropiedades = _type.GetProperties();

            foreach (System.Reflection.PropertyInfo prop in LPropiedades)
            {
                string propiedad = string.Empty;
                string value = string.Empty;
                dynamic PropertyValue = prop.GetValue(datos, null);

                if (PropertyValue is string || PropertyValue is int || PropertyValue is bool)
                {
                    propiedad = prop.Name;
                    value = Convert.ToString(PropertyValue);
                    fields.SetField(propiedad, value);
                }
                else if (PropertyValue is DateTime)
                {
                    propiedad = prop.Name;
                    value = Convert.ToString(PropertyValue);
                    fields.SetField(propiedad, value);
                }
                else if (prop.PropertyType.IsGenericType)
                {
                    if (PropertyValue != null)
                    {
                        foreach (dynamic Elementlist in PropertyValue)
                        {
                            Type _types = Elementlist.GetType();
                            if (prop.Name == "terceros")
                            {
                                string TipoTercero = string.Empty;
                                System.Reflection.PropertyInfo[] listaPropiedades = _types.GetProperties();

                                foreach (System.Reflection.PropertyInfo FoundType in listaPropiedades)
                                {

                                    propiedad = FoundType.Name;
                                    value = Convert.ToString(FoundType.GetValue(Elementlist, null));
                                    if (propiedad == "tipodetercero")
                                    {
                                        TipoTercero = value;

                                        foreach (System.Reflection.PropertyInfo PropiedadLista in listaPropiedades)
                                        {
                                            propiedad = PropiedadLista.Name;
                                            value = Convert.ToString(PropiedadLista.GetValue(Elementlist, null));
                                            fields.SetField(propiedad + "_" + TipoTercero, value);
                                        }
                                    }
                                }
                            }
                            if (prop.Name == "coberturas")
                            {
                                string TipoTercero = string.Empty;
                                System.Reflection.PropertyInfo[] listaPropiedades = _types.GetProperties();

                                foreach (System.Reflection.PropertyInfo CheckTrue in listaPropiedades)
                                {

                                    propiedad = CheckTrue.Name;
                                    value = Convert.ToString(CheckTrue.GetValue(Elementlist, null));
                                    if (propiedad == "seleccionado" && value == "True")
                                    {
                                        propiedad = Elementlist.nombre;
                                        fields.SetField(propiedad, value);
                                    }
                                }
                            }
                            else
                            {
                                System.Reflection.PropertyInfo[] listaPropiedades = _types.GetProperties();

                                foreach (System.Reflection.PropertyInfo PropiedadLista in listaPropiedades)
                                {
                                    propiedad = PropiedadLista.Name;
                                    value = Convert.ToString(PropiedadLista.GetValue(Elementlist, null));
                                    fields.SetField(propiedad, value);

                                }
                            }

                        }
                    }
                        
                }   
                else if (PropertyValue is object)
                {

                    if(PropertyValue is JObject)
                    {
                        if (PropertyValue != null)
                        {
                            foreach (JProperty jsonOPropiedades in PropertyValue.Children<JProperty>())
                            {
                                //Aqui para poder identificar las propiedades y sus valores
                                propiedad = jsonOPropiedades.Name;
                                value = Convert.ToString(jsonOPropiedades.Value);
                                fields.SetField(propiedad, value);

                            }
                        }
                    }
                    else
                    {
                        if (PropertyValue != null)
                        {
                            Type ClaseOrigen = PropertyValue.GetType();

                            System.Reflection.PropertyInfo[] PropiedadesClass = ClaseOrigen.GetProperties();

                            foreach (System.Reflection.PropertyInfo PropiedadClass in PropiedadesClass)
                            {
                                if (PropiedadClass.PropertyType.IsGenericType)
                                {
                                    int count = 0;
                                    dynamic List = PropiedadClass.GetValue(PropertyValue, null);
                                    foreach (dynamic Elementlist in List)
                                    {
                                        Type _types = Elementlist.GetType();
                                        if (PropiedadClass.Name == "participacionaccionariaJur")
                                        {
                                            System.Reflection.PropertyInfo[] listaPropiedades = _types.GetProperties();
                                            foreach (System.Reflection.PropertyInfo PropiedadLista in listaPropiedades)
                                            {
                                               propiedad = PropiedadLista.Name;
                                               value = Convert.ToString(PropiedadLista.GetValue(Elementlist, null));
                                               fields.SetField(propiedad + "_" + count.ToString(), value);
                                            }
                                        }
                                        count += 1;
                                    }
                                }
                                else
                                {
                                    propiedad = PropiedadClass.Name;
                                    value = Convert.ToString(PropiedadClass.GetValue(PropertyValue, null));
                                    fields.SetField(propiedad, value);
                                }
                                
                            }
                        }
                    }
                }

            }
            
        }
    }

   
}
