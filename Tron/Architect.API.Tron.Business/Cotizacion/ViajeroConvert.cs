using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Cotizacion
{
    public static class ViajeroConvert
    {

        public static Contracts.Presupuesto.DatoFijo ToTron(Contracts.Cotizacion.Viajero quoteInfo, int branch, int agentCode, string userName)
        {

            Contracts.Presupuesto.DatoFijo datosFijos = Util.DatosFijos(quoteInfo, branch, agentCode, userName, 4);

            datosFijos.Riesgos = Util.DatosDelRiesgo(datosFijos, "Cotizador Seguro de Viaje", quoteInfo.cantidad_riesgos);
            datosFijos.Terceros = Util.Terceros(datosFijos);
            datosFijos.Coberturas = Util.Coberturas(quoteInfo, datosFijos, false, quoteInfo.cantidad_riesgos);
            datosFijos.DatosVariables = DatosVariable_ToTron(quoteInfo, datosFijos);

            return datosFijos;
        }

        private static List<Contracts.Presupuesto.DatoVariable> DatosVariable_ToTron(Contracts.Cotizacion.Viajero quoteInfo, Contracts.Presupuesto.DatoFijo datosFijos)
        {
            List<Contracts.Presupuesto.DatoVariable> datosVariables = new List<Contracts.Presupuesto.DatoVariable>();

            //Número de Días
            TimeSpan difFechas = quoteInfo.fec_vcto_poliza - quoteInfo.fec_efec_poliza;
            int dias = difFechas.Days + 1;
            if(quoteInfo.DES_DESTINO_DESC == String.Empty)
            {
                quoteInfo.DES_DESTINO_DESC = Destino(quoteInfo.DES_DESTINO);
            }
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "TIP_PLAN", quoteInfo.TIP_PLAN, 1, 1));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "FEC_VIAJE", quoteInfo.FEC_VIAJE.ToString("ddMMyyyy"), 1, 2));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "NUM_DIA", Convert.ToString(dias), 1, 3));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "DES_DESTINO", quoteInfo.DES_DESTINO, 1, 4, quoteInfo.DES_DESTINO_DESC));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "CANAL_VENTA", "TWB", 1, 5));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "TIP_VIAJE", quoteInfo.TIP_VIAJE, 1, 6));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "ORI_ORIGEN", quoteInfo.COD_PAIS_ORIGEN, 1, 9,quoteInfo.PAIS_ORIGEN_DESC));

            for (int i = 1; i <= quoteInfo.cantidad_riesgos; i++)
            {
                switch (i)
                {
                    case 1:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO, quoteInfo.COD_MODALIDAD));
                        break;
                    case 2:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO2, quoteInfo.COD_MODALIDAD));
                        break;
                    case 3:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO3, quoteInfo.COD_MODALIDAD));
                        break;
                    case 4:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO4, quoteInfo.COD_MODALIDAD));
                        break;
                    case 5:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO5, quoteInfo.COD_MODALIDAD));
                        break;
                    case 6:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO6, quoteInfo.COD_MODALIDAD));
                        break;
                    case 7:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO7, quoteInfo.COD_MODALIDAD));
                        break;
                    case 8:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO8, quoteInfo.COD_MODALIDAD));
                        break;
                    case 9:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO9, quoteInfo.COD_MODALIDAD));
                        break;
                    case 10:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO10, quoteInfo.COD_MODALIDAD));
                        break;
                }
            }

            return datosVariables;
        }

        private static List<Contracts.Presupuesto.DatoVariable> DatosVariable_ToTron_por_riesgo(Contracts.Presupuesto.DatoFijo datosFijos, int num_riesgo, DateTime nacimiento, int cod_modalidad)
        {
            List<Contracts.Presupuesto.DatoVariable> datosVariables = new List<Contracts.Presupuesto.DatoVariable>();
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "FEC_NACIMIENTO", nacimiento.ToString("ddMMyyyy"), 2, 2));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "VAL_EDAD", edad.ToString(), 2, 3));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_MODALIDAD", cod_modalidad.ToString(), 2, 99));
            return datosVariables;
        }

        internal static Contracts.Cotizacion.Viajero FromTron_Full(Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            Contracts.Cotizacion.Viajero quoteInfo = (Contracts.Cotizacion.Viajero)Util.GenericInfo_FromTron(tronQuoteInfo, new Contracts.Cotizacion.Viajero());

            return FromTron_DatosVariables(tronQuoteInfo, quoteInfo);
        }

        private static Contracts.Cotizacion.Viajero FromTron_DatosVariables(Contracts.Presupuesto.DatoFijo tronQuoteInfo, Contracts.Cotizacion.Viajero quoteInfo)
        {
            foreach (Contracts.Presupuesto.DatoVariable item in tronQuoteInfo.DatosVariables)
            {
                switch (item.cod_campo)
                {
                    case "TIP_PLAN":
                        quoteInfo.TIP_PLAN = item.val_campo;
                        break;
                    case "FEC_VIAJE":
                        quoteInfo.FEC_VIAJE = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                        break;
                    case "DES_DESTINO":
                        quoteInfo.DES_DESTINO_DESC = item.val_campo;
                        break;
                    case "TIP_VIAJE":
                        quoteInfo.TIP_VIAJE = item.val_campo;
                        break;

                    case "FEC_NACIMIENTO":
                        switch (item.num_riesgo)
                        {
                            case 1:
                                quoteInfo.FEC_NACIMIENTO = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 1;
                                break;
                            case 2:
                                quoteInfo.FEC_NACIMIENTO2 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 2;
                                break;
                            case 3:
                                quoteInfo.FEC_NACIMIENTO3 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 3;
                                break;
                            case 4:
                                quoteInfo.FEC_NACIMIENTO4 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 4;
                                break;
                            case 5:
                                quoteInfo.FEC_NACIMIENTO5 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 5;
                                break;
                            case 6:
                                quoteInfo.FEC_NACIMIENTO6 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 6;
                                break;
                            case 7:
                                quoteInfo.FEC_NACIMIENTO7 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 7;
                                break;
                            case 8:
                                quoteInfo.FEC_NACIMIENTO8 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 8;
                                break;
                            case 9:
                                quoteInfo.FEC_NACIMIENTO9 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 9;
                                break;
                            case 10:
                                quoteInfo.FEC_NACIMIENTO10 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 10;
                                break;
                        }

                        break;


                    case "NUM_DIA":
                    case "CANAL_VENTA":
                    case "VAL_EDAD":
                    case "COD_MODALIDAD":
                        break;
                }
            }
            return quoteInfo;
        }

        private static string Destino(string code)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>() {                                                                 {"AD", "Andorra"},
                                                                {"AE", "Emiratos Árabes Unidos"},
                                                                {"AF", "Afganistán"},
                                                                {"AG", "Antigua y Barbuda"},
                                                                {"AI", "Anguila"},
                                                                {"AL", "Albania"},
                                                                {"AM", "Armenia"},
                                                                {"AN", "Antillas Neerlandesas"},
                                                                {"AO", "Angola"},
                                                                {"AQ", "Antártida"},
                                                                {"AR", "Argentina"},
                                                                {"AS", "Samoa Americana"},
                                                                {"AT", "Austria"},
                                                                {"AU", "Australia"},
                                                                {"AW", "Aruba"},
                                                                {"AX", "Islas Áland"},
                                                                {"AZ", "Azerbaiyán"},
                                                                {"BA", "Bosnia y Herzegovina"},
                                                                {"BB", "Barbados"},
                                                                {"BD", "Bangladesh"},
                                                                {"BE", "Bélgica"},
                                                                {"BF", "Burkina Faso"},
                                                                {"BG", "Bulgaria"},
                                                                {"BH", "Bahréin"},
                                                                {"BI", "Burundi"},
                                                                {"BJ", "Benin"},
                                                                {"BL", "San Bartolomé"},
                                                                {"BM", "Bermudas"},
                                                                {"BN", "Brunéi"},
                                                                {"BO", "Bolivia"},
                                                                {"BR", "Brasil"},
                                                                {"BS", "Bahamas"},
                                                                {"BT", "Bhután"},
                                                                {"BV", "Isla Bouvet"},
                                                                {"BW", "Botsuana"},
                                                                {"BY", "Belarús"},
                                                                {"BZ", "Belice"},
                                                                {"CA", "Canadá"},
                                                                {"CC", "Islas Cocos"},
                                                                {"CF", "República Centro-Africana"},
                                                                {"CG", "Congo"},
                                                                {"CH", "Suiza"},
                                                                {"CI", "Costa de Marfil"},
                                                                {"CK", "Islas Cook"},
                                                                {"CL", "Chile"},
                                                                {"CM", "Camerún"},
                                                                {"CN", "China"},
                                                                {"CO", "Colombia"},
                                                                {"CR", "Costa Rica"},
                                                                {"CU", "Cuba"},
                                                                {"CV", "Cabo Verde"},
                                                                {"CX", "Islas Christmas"},
                                                                {"CY", "Chipre"},
                                                                {"CZ", "República Checa"},
                                                                {"DE", "Alemania"},
                                                                {"DJ", "Yibuti"},
                                                                {"DK", "Dinamarca"},
                                                                {"DM", "Domínica"},
                                                                {"DO", "República Dominicana"},
                                                                {"DZ", "Argel"},
                                                                {"EC", "Ecuador"},
                                                                {"EE", "Estonia"},
                                                                {"EG", "Egipto"},
                                                                {"EH", "Sahara Occidental"},
                                                                {"ER", "Eritrea"},
                                                                {"ES", "España"},
                                                                {"ET", "Etiopía"},
                                                                {"FI", "Finlandia"},
                                                                {"FJ", "Fiji"},
                                                                {"FK", "Islas Malvinas"},
                                                                {"FM", "Micronesia"},
                                                                {"FO", "Islas Faroe"},
                                                                {"FR", "Francia"},
                                                                {"GA", "Gabón"},
                                                                {"GB", "Reino Unido"},
                                                                {"GD", "Granada"},
                                                                {"GE", "Georgia"},
                                                                {"GF", "Guayana Francesa"},
                                                                {"GG", "Guernsey"},
                                                                {"GH", "Ghana"},
                                                                {"GI", "Gibraltar"},
                                                                {"GL", "Groenlandia"},
                                                                {"GM", "Gambia"},
                                                                {"GN", "Guinea"},
                                                                {"GP", "Guadalupe"},
                                                                {"GQ", "Guinea Ecuatorial"},
                                                                {"GR", "Grecia"},
                                                                {"GS", "Georgia del Sur e Islas Sandwich del Sur"},
                                                                {"GT", "Guatemala"},
                                                                {"GU", "Guam"},
                                                                {"GW", "Guinea-Bissau"},
                                                                {"GY", "Guayana"},
                                                                {"HK", "Hong Kong"},
                                                                {"HM", "Islas Heard y McDonald"},
                                                                {"HN", "Honduras"},
                                                                {"HR", "Croacia"},
                                                                {"HT", "Haití"},
                                                                {"HU", "Hungría"},
                                                                {"ID", "Indonesia"},
                                                                {"IE", "Irlanda"},
                                                                {"IL", "Israel"},
                                                                {"IM", "Isla de Man"},
                                                                {"IN", "India"},
                                                                {"IO", "Territorio Británico del Océano Índico"},
                                                                {"IQ", "Irak"},
                                                                {"IR", "Irán"},
                                                                {"IS", "Islandia"},
                                                                {"IT", "Italia"},
                                                                {"JE", "Jersey"},
                                                                {"JM", "Jamaica"},
                                                                {"JO", "Jordania"},
                                                                {"JP", "Japón"},
                                                                {"KE", "Kenia"},
                                                                {"KG", "Kirguistán"},
                                                                {"KH", "Camboya"},
                                                                {"KI", "Kiribati"},
                                                                {"KM", "Comoros"},
                                                                {"KN", "San Cristóbal y Nieves"},
                                                                {"KP", "Corea del Norte"},
                                                                {"KR", "Corea del Sur"},
                                                                {"KW", "Kuwait"},
                                                                {"KY", "Islas Caimán"},
                                                                {"KZ", "Kazajstán"},
                                                                {"LA", "Laos"},
                                                                {"LB", "Líbano"},
                                                                {"LC", "Santa Lucía"},
                                                                {"LI", "Liechtenstein"},
                                                                {"LK", "Sri Lanka"},
                                                                {"LR", "Liberia"},
                                                                {"LS", "Lesotho"},
                                                                {"LT", "Lituania"},
                                                                {"LU", "Luxemburgo"},
                                                                {"LV", "Letonia"},
                                                                {"LY", "Libia"},
                                                                {"MA", "Marruecos"},
                                                                {"MC", "Mónaco"},
                                                                {"MD", "Moldova"},
                                                                {"ME", "Montenegro"},
                                                                {"MG", "Madagascar"},
                                                                {"MH", "Islas Marshall"},
                                                                {"MK", "Macedonia"},
                                                                {"ML", "Mali"},
                                                                {"MM", "Myanmar"},
                                                                {"MN", "Mongolia"},
                                                                {"MO", "Macao"},
                                                                {"MQ", "Martinica"},
                                                                {"MR", "Mauritania"},
                                                                {"MS", "Montserrat"},
                                                                {"MT", "Malta"},
                                                                {"MU", "Mauricio"},
                                                                {"MV", "Maldivas"},
                                                                {"MW", "Malawi"},
                                                                {"MX", "México"},
                                                                {"MY", "Malasia"},
                                                                {"MZ", "Mozambique"},
                                                                {"NA", "Namibia"},
                                                                {"NC", "Nueva Caledonia"},
                                                                {"NE", "Níger"},
                                                                {"NF", "Islas Norkfolk"},
                                                                {"NG", "Nigeria"},
                                                                {"NI", "Nicaragua"},
                                                                {"NL", "Países Bajos"},
                                                                {"NO", "Noruega"},
                                                                {"NP", "Nepal"},
                                                                {"NR", "Nauru"},
                                                                {"NU", "Niue"},
                                                                {"NZ", "Nueva Zelanda"},
                                                                {"OM", "Omán"},
                                                                {"PA", "Panamá"},
                                                                {"PE", "Perú"},
                                                                {"PF", "Polinesia Francesa"},
                                                                {"PG", "Papúa Nueva Guinea"},
                                                                {"PH", "Filipinas"},
                                                                {"PK", "Pakistán"},
                                                                {"PL", "Polonia"},
                                                                {"PM", "San Pedro y Miquelón"},
                                                                {"PN", "Islas Pitcairn"},
                                                                {"PR", "Puerto Rico"},
                                                                {"PS", "Palestina"},
                                                                {"PT", "Portugal"},
                                                                {"PW", "Islas Palaos"},
                                                                {"PY", "Paraguay"},
                                                                {"QA", "Qatar"},
                                                                {"RE", "Reunión"},
                                                                {"RO", "Rumanía"},
                                                                {"RS", "Serbia y Montenegro"},
                                                                {"RU", "Rusia"},
                                                                {"RW", "Ruanda"},
                                                                {"SA", "Arabia Saudita"},
                                                                {"SB", "Islas Solomón"},
                                                                {"SC", "Seychelles"},
                                                                {"SD", "Sudán"},
                                                                {"SE", "Suecia"},
                                                                {"SG", "Singapur"},
                                                                {"SH", "Santa Elena"},
                                                                {"SI", "Eslovenia"},
                                                                {"SJ", "Islas Svalbard y Jan Mayen"},
                                                                {"SK", "Eslovaquia"},
                                                                {"SL", "Sierra Leona"},
                                                                {"SM", "San Marino"},
                                                                {"SN", "Senegal"},
                                                                {"SO", "Somalia"},
                                                                {"SR", "Surinam"},
                                                                {"ST", "Santo Tomé y Príncipe"},
                                                                {"SV", "El Salvador"},
                                                                {"SY", "Siria"},
                                                                {"SZ", "Suazilandia"},
                                                                {"TC", "Islas Turcas y Caicos"},
                                                                {"TD", "Chad"},
                                                                {"TF", "Territorios Australes Franceses"},
                                                                {"TG", "Togo"},
                                                                {"TH", "Tailandia"},
                                                                {"TH", "Tanzania"},
                                                                {"TJ", "Tayikistán"},
                                                                {"TK", "Tokelau"},
                                                                {"TL", "Timor-Leste"},
                                                                {"TM", "Turkmenistán"},
                                                                {"TN", "Túnez"},
                                                                {"TO", "Tonga"},
                                                                {"TR", "Turquía"},
                                                                {"TT", "Trinidad y Tobago"},
                                                                {"TV", "Tuvalu"},
                                                                {"TW", "Taiwán"},
                                                                {"UA", "Ucrania"},
                                                                {"UG", "Uganda"},
                                                                {"US", "Estados Unidos de América"},
                                                                {"UY", "Uruguay"},
                                                                {"UZ", "Uzbekistán"},
                                                                {"VA", "Ciudad del Vaticano"},
                                                                {"VC", "San Vicente y las Granadinas"},
                                                                {"VE", "Venezuela"},
                                                                {"VG", "Islas Vírgenes Británicas"},
                                                                {"VI", "Islas Vírgenes de los Estados Unidos de América"},
                                                                {"VN", "Vietnam"},
                                                                {"VU", "Vanuatu"},
                                                                {"WF", "Wallis y Futuna"},
                                                                {"WS", "Samoa"},
                                                                {"YE", "Yemen"},
                                                                {"YT", "Mayotte"},
                                                                {"ZA", "Sudáfrica"} };
            if (lista.ContainsKey(code))

                return lista[code];
            else
                return String.Empty;
        }
    }
}
