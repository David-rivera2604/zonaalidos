using Architect.API.Core.Contracts;
using Architect.DataFactory;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;


namespace Architect.API.Core.DataAccess
{
	/// <summary>
	/// .
	/// </summary>
	public static partial class KycDataBase
	{
		static string alloptionjuridico = "NUM_IDENTIFI,NOM_COMERCIAL, RAZON_SOCIAL, COD_CLIENTE, TIP_SOCIEDAD, " +
                    "TIP_IDENT_JUR, TIP_IDENT_JUR_DESC, COD_PAIS_CONSTI, COD_PAIS_CONSTI_DESC, FECHA_CONSTI, ACTI_EMPRESA,TELF_JUR, FAX_JUR,APART_POSTAL_JUR, " +
                    "CORREO_ELECT_JUR,PAG_WEB,APELLIDO1_REP,APELLIDO2_REP,NOMBRE_REP,POSICI_ENMPRE,NUM_IDENTI_REP,COD_IDENTI_REP,COD_IDENTI_REP_DESC," +
                    "ESPEC_IDENTI_REP,FECHA_CADUCIDAD_REP,COD_NACION_REP,COD_NACION_REP_DESC,FECHA_NACI_REP,COD_PAIS_NACI_REP,COD_PAIS_NACI_REP_DESC,COD_PROFESION_REP,COD_PROFESION_REP_DESC,COD_ESTAD_CIVIL_REP," +
                    "COD_ESTAD_CIVIL_REP_DESC,COD_SEXO_REP,COD_SEXO_REP_DESC,TELF_RESI_REP,TELF_CELU_REP,FAX_REP,APARTA_POSTAL_REP,CORREO_ELECT_REP," +
                    "PARTI_ACCIONA,COD_DOMIC_PERMAN_PAIS,COD_DOMIC_PERMAN_PAIS_DESC,COD_DOMIC_PERMAN_PROV,COD_DOMIC_PERMAN_PROV_DESC," +
                    "COD_DOMIC_PERMAN_CANT,COD_DOMIC_PERMAN_CANT_DESC,COD_DOMIC_PERMAN_DIST,COD_DOMIC_PERMAN_DIST_DESC,DOMIC_PERMAN_DIREC_EXAT_PER," +
                    "COD_DOMICI_COME_PAIS,COD_DOMICI_COME_PAIS_DESC,COD_DOMICI_COME_PROV,COD_DOMICI_COME_PROV_DESC,COD_DOMICI_COME_CANT," +
                    "COD_DOMICI_COME_CANT_DESC,COD_DOMICI_COME_DIST,COD_DOMICI_COME_DIST_DESC,DOMICI_COME_DIREC_EXAT,CORRE_ORIGIN_FONDO," +
                    "PAIS_MAX_ACTIVI,INGRE_MENS,COD_FONDOSMOV,COD_FONDOSMOV_DESC,COD_ACTIVI_ART15,COD_ACTIVI_ART15_DESC,COD_ACTIVO_CORRE," +
                    "COD_ACTIVO_CORRE_DESC,COD_PEP_CARGO,COD_PEP_CARGO_DESC,PEP_DURACION,COD_PEP_RELACION,COD_PEP_RELACION_DESC," +
                    "PEP_TIP_RELACION,PROP_RELA_COMERCI,MONT_PRIMA,TIP_PRIMA,COD_PERIOD,COD_PERIOD_DESC,MONT_VAL_ASEGU,COD_FORM_PAGO," +
                    "COD_FORM_PAGO_DESC,COD_MEDIO_ENVIO,COD_MEDIO_ENVIO_DESC,CORRESPON_ESPECIFI, NUM_TIN, NUM_EXTRANJERO, SENAS_DOMIC_EXTRAN," +
                    "GREEN_CARD, IDENTI_EIN, CONTRI_USA, POSEE_DOMIC_EXTRAN, PAIS_DOMIC, POSEE_TEL_EXTRAN, APORT_XML_FATCA," +
                    "ATRI_CANAL_ING, VAL_CANAL_ING,COD_ACT_ECONOMICA,COD_ACT_ECONOMICA_REP";

        static string alloptionpersona = "NUM_IDENTIFI,NOMBRE,APELLIDO1, APELLIDO2, COD_CLIENTE, COD_TIP_IDENTIFI," +
                    "TIP_IDENT_DESC, FECHA_CADUCIDAD, COD_NACIONALI, COD_NACIONALI_DESC, FECHA_NACI, COD_PAIS_NACI,COD_PAIS_NACI_DESC, COD_PROFESION,COD_PROFESION_DESC, " +
                    "COD_ESTAD_CIVIL, COD_ESTAD_CIVIL_DESC, COD_SEXO, COD_SEXO_DESC, TELF_RESIDEN, TELF_CELULAR, FAX_PER, " +
                    "APARTADO_POST_PER,CORREO_ELEC_PER,COD_DOMIC_PERMAN_PAIS,COD_DOMIC_PERMAN_PAIS_DESC,COD_DOMIC_PERMAN_PROV,COD_DOMIC_PERMAN_PROV_DESC," +
                    "COD_DOMIC_PERMAN_CANT,COD_DOMIC_PERMAN_CANT_DESC,COD_DOMIC_PERMAN_DIST,COD_DOMIC_PERMAN_DIST_DESC,DOMIC_PERMAN_DIREC_EXAT_PER," +
                    "COD_OCUP_PER,COD_OCUP_PER_DESC,NOM_EMPRES,ACTIVI_EMPRES,CARGO_EMPRES,TELF_EMPRES,FAX_EMPRES,COD_DOMICI_COME_PAIS,COD_DOMICI_COME_PAIS_DESC," +
                    "COD_DOMICI_COME_PROV,COD_DOMICI_COME_PROV_DESC,COD_DOMICI_COME_CANT,COD_DOMICI_COME_CANT_DESC,COD_DOMICI_COME_DIST,COD_DOMICI_COME_DIST_DESC," +
                    "DOMICI_COME_DIREC_EXAT,CORRE_ORIGIN_FONDO,PAIS_MAX_ACTIVI,INGRE_MENS,COD_FONDOSMOV," +
                    "COD_FONDOSMOV_DESC,COD_ACTIVI_ART15,COD_ACTIVI_ART15_DESC,COD_ACTIVO_CORRE,COD_ACTIVO_CORRE_DESC,COD_PEP_CARGO,COD_PEP_CARGO_DESC,PEP_DURACION," +
                    "COD_PEP_RELACION,COD_PEP_RELACION_DESC,PEP_TIP_RELACION,PROP_RELA_COMERCI,MONT_PRIMA,TIP_PRIMA,COD_PERIOD,COD_PERIOD_DESC," +
                    "MONT_VAL_ASEGU,COD_FORM_PAGO,COD_FORM_PAGO_DESC,COD_MEDIO_ENVIO,COD_MEDIO_ENVIO_DESC,CORRESPON_ESPECIFI, NUM_TIN, NUM_EXTRANJERO, SENAS_DOMIC_EXTRAN," +
                    "GREEN_CARD, IDENTI_EIN, CONTRI_USA, POSEE_DOMIC_EXTRAN, PAIS_DOMIC, POSEE_TEL_EXTRAN, APORT_XML_FATCA," +
                    "ATRI_CANAL_ING, VAL_CANAL_ING,COD_ACT_ECONOMICA";
        /// <summary>
        /// Crea un registro en la tabla KycPersona o en KycJuridico
        /// </summary>
        /// <param name="kycobject">Instancia de kyc</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(dynamic kycobject, IDbConnection connection = null)
		{
			if(kycobject is Kycpersona)
			{
				Kycpersona kycpersona = kycobject;

                Database.Insert("INSERT INTO KYCPERSONA (" + alloptionpersona + ")"+

                    "VALUES(:NUM_IDENTIFI,:NOMBRE, :APELLIDO1, :APELLIDO2, :COD_CLIENTE, :COD_TIP_IDENTIFI, " +
                    ":TIP_IDENT_DESC, :FECHA_CADUCIDAD, :COD_NACIONALI, :COD_NACIONALI_DESC, :FECHA_NACI, :COD_PAIS_NACI,:COD_PAIS_NACI_DESC,  :COD_PROFESION,:COD_PROFESION_DESC, " +
                    ":COD_ESTAD_CIVIL, :COD_ESTAD_CIVIL_DESC, :COD_SEXO, :COD_SEXO_DESC, :TELF_RESIDEN, :TELF_CELULAR, :FAX_PER, " +
                    ":APARTADO_POST_PER,:CORREO_ELEC_PER,:COD_DOMIC_PERMAN_PAIS,:COD_DOMIC_PERMAN_PAIS_DESC,:COD_DOMIC_PERMAN_PROV,:COD_DOMIC_PERMAN_PROV_DESC," +
                    ":COD_DOMIC_PERMAN_CANT,:COD_DOMIC_PERMAN_CANT_DESC,:COD_DOMIC_PERMAN_DIST,:COD_DOMIC_PERMAN_DIST_DESC,:DOMIC_PERMAN_DIREC_EXAT_PER," +
                    ":COD_OCUP_PER,:COD_OCUP_PER_DESC,:NOM_EMPRES,:ACTIVI_EMPRES,:CARGO_EMPRES,:TELF_EMPRES,:FAX_EMPRES,:COD_DOMICI_COME_PAIS,:COD_DOMICI_COME_PAIS_DESC," +
                    ":COD_DOMICI_COME_PROV,:COD_DOMICI_COME_PROV_DESC,:COD_DOMICI_COME_CANT,:COD_DOMICI_COME_CANT_DESC,:COD_DOMICI_COME_DIST,:COD_DOMICI_COME_DIST_DESC," +
                    ":DOMICI_COME_DIREC_EXAT,:CORRE_ORIGIN_FONDO,:PAIS_MAX_ACTIVI,:INGRE_MENS,:COD_FONDOSMOV," +
                    ":COD_FONDOSMOV_DESC,:COD_ACTIVI_ART15,:COD_ACTIVI_ART15_DESC,:COD_ACTIVO_CORRE,:COD_ACTIVO_CORRE_DESC,:COD_PEP_CARGO,:COD_PEP_CARGO_DESC,:PEP_DURACION," +
                    ":COD_PEP_RELACION,:COD_PEP_RELACION_DESC,:PEP_TIP_RELACION,:PROP_RELA_COMERCI,:MONT_PRIMA,:TIP_PRIMA,:COD_PERIOD,:COD_PERIOD_DESC," +
                    ":MONT_VAL_ASEGU,:COD_FORM_PAGO,:COD_FORM_PAGO_DESC,:COD_MEDIO_ENVIO,:COD_MEDIO_ENVIO_DESC,:CORRESPON_ESPECIFI, :NUM_TIN, :NUM_EXTRANJERO, :SENAS_DOMIC_EXTRAN,"+
                    ":GREEN_CARD, :IDENTI_EIN, :CONTRI_USA, :POSEE_DOMIC_EXTRAN, :PAIS_DOMIC, :POSEE_TEL_EXTRAN, :APORT_XML_FATCA, :ATRI_CANAL_ING, :VAL_CANAL_ING,:COD_ACT_ECONOMICA)")
                                .AddParameter("NUM_IDENTIFI", DbType.AnsiString, 25, kycpersona.numidentificacion)			
								.AddParameter("NOMBRE", DbType.AnsiString, 20, kycpersona.nombrePer)
								.AddParameter("APELLIDO1", DbType.AnsiString, 20, kycpersona.primerapellidoPer)
								.AddParameter("APELLIDO2", DbType.AnsiString, 20, kycpersona.segundoapellidoPer)
								.AddParameter("COD_CLIENTE", DbType.AnsiString, 30, kycpersona.codigodeclientePer)
								.AddParameter("COD_TIP_IDENTIFI", DbType.Decimal, 20, kycpersona.numidentificaciontipo)
								.AddParameter("TIP_IDENT_DESC", DbType.AnsiString, 30, kycpersona.numidentificaciontipoDesc)
								.AddParameter("FECHA_CADUCIDAD", DbType.Date, 0, kycpersona.fechadecaducidadPer)
								.AddParameter("COD_NACIONALI", DbType.Decimal, 25, kycpersona.nacionalidadPer)
								.AddParameter("COD_NACIONALI_DESC", DbType.AnsiString, 15, kycpersona.nacionalidadPerDesc)
								.AddParameter("FECHA_NACI", DbType.Date, 0, kycpersona.fechadenacimientoPer)
								.AddParameter("COD_PAIS_NACI", DbType.Decimal, 10, kycpersona.paisdenacimientoPer)
								.AddParameter("COD_PAIS_NACI_DESC", DbType.AnsiString, 20, kycpersona.paisdenacimientoPerDesc)
								.AddParameter("COD_PROFESION", DbType.Decimal, 15, kycpersona.profesionPer)
								.AddParameter("COD_PROFESION_DESC", DbType.AnsiString, 40, kycpersona.profesionPerDesc)
								.AddParameter("COD_ESTAD_CIVIL", DbType.Decimal, 10, kycpersona.estadocivilPer)
								.AddParameter("COD_ESTAD_CIVIL_DESC", DbType.AnsiString, 15, kycpersona.estadocivilPerDesc)
								.AddParameter("COD_SEXO", DbType.Decimal, 10, kycpersona.sexoPer)
								.AddParameter("COD_SEXO_DESC", DbType.AnsiString, 10, kycpersona.sexoPerDesc)
								.AddParameter("TELF_RESIDEN", DbType.AnsiString, 9, kycpersona.telefonoresidenciaPer)
								.AddParameter("TELF_CELULAR", DbType.AnsiString, 9, kycpersona.telefonocelularPer)
								.AddParameter("FAX_PER", DbType.AnsiString, 9, kycpersona.faxPer)
								.AddParameter("APARTADO_POST_PER", DbType.AnsiString, 25, kycpersona.apartadopostalPer)
								.AddParameter("CORREO_ELEC_PER", DbType.AnsiString, 80, kycpersona.correoelectronicoPer)
								.AddParameter("COD_DOMIC_PERMAN_PAIS", DbType.AnsiString, 5, kycpersona.domiciliopermanenteCod_pais)
								.AddParameter("COD_DOMIC_PERMAN_PAIS_DESC", DbType.AnsiString, 20, kycpersona.domiciliopermanenteCod_paisDesc)
								.AddParameter("COD_DOMIC_PERMAN_PROV", DbType.Decimal, 9, kycpersona.domiciliopermanenteCod_estado)
								.AddParameter("COD_DOMIC_PERMAN_PROV_DESC", DbType.AnsiString, 20, kycpersona.domiciliopermanenteCod_estadoDesc)
								.AddParameter("COD_DOMIC_PERMAN_CANT", DbType.Decimal, 9, kycpersona.domiciliopermanenteCod_prov)
								.AddParameter("COD_DOMIC_PERMAN_CANT_DESC", DbType.AnsiString, 20, kycpersona.domiciliopermanenteCod_provDesc)
								.AddParameter("COD_DOMIC_PERMAN_DIST", DbType.Decimal, 9, kycpersona.domiciliopermanenteCod_localidad)
								.AddParameter("COD_DOMIC_PERMAN_DIST_DESC", DbType.AnsiString, 20, kycpersona.domiciliopermanenteCod_localidadDesc)
								.AddParameter("DOMIC_PERMAN_DIREC_EXAT_PER", DbType.AnsiString, 80, kycpersona.domiciliopermanenteDireccionexacta)
								.AddParameter("COD_OCUP_PER", DbType.Decimal, 9, kycpersona.OcupacionPer)
								.AddParameter("COD_OCUP_PER_DESC", DbType.AnsiString, 25, kycpersona.OcupacionPerDesc)
								.AddParameter("NOM_EMPRES", DbType.AnsiString, 60, kycpersona.nombreempresaPer)
								.AddParameter("ACTIVI_EMPRES", DbType.AnsiString, 60, kycpersona.actividadempresaPer)
								.AddParameter("CARGO_EMPRES", DbType.AnsiString, 60, kycpersona.cargoempresaPer)
								.AddParameter("TELF_EMPRES", DbType.AnsiString, 9, kycpersona.telefonoempresaPer)
								.AddParameter("FAX_EMPRES", DbType.AnsiString, 9, kycpersona.faxempresaPer)
								.AddParameter("COD_DOMICI_COME_PAIS", DbType.AnsiString, 5, kycpersona.domiciliocomercialCod_pais)
								.AddParameter("COD_DOMICI_COME_PAIS_DESC", DbType.AnsiString, 20, kycpersona.domiciliocomercialCod_paisDesc)
								.AddParameter("COD_DOMICI_COME_PROV", DbType.Decimal, 9, kycpersona.domiciliocomercialCod_estado)
								.AddParameter("COD_DOMICI_COME_PROV_DESC", DbType.AnsiString, 20, kycpersona.domiciliocomercialCod_estadoDesc)
								.AddParameter("COD_DOMICI_COME_CANT", DbType.Decimal, 9, kycpersona.domiciliocomercialCod_prov)
								.AddParameter("COD_DOMICI_COME_CANT_DESC", DbType.AnsiString, 20, kycpersona.domiciliocomercialCod_provDesc)
								.AddParameter("COD_DOMICI_COME_DIST", DbType.Decimal, 9, kycpersona.domiciliocomercialCod_localidad)
								.AddParameter("COD_DOMICI_COME_DIST_DESC", DbType.AnsiString, 20, kycpersona.domiciliocomercialCod_localidadDesc)
								.AddParameter("DOMICI_COME_DIREC_EXAT", DbType.AnsiString, 80, kycpersona.domiciliocomercialDireccionexacta)
								.AddParameter("CORRE_ORIGIN_FONDO", DbType.AnsiString, 60, kycpersona.correspondenciaOrigendelosfondos)
								.AddParameter("PAIS_MAX_ACTIVI", DbType.AnsiString, 60, kycpersona.paismayoractividad)
								.AddParameter("INGRE_MENS", DbType.Decimal, 20, kycpersona.ingresomensualestimado)
								.AddParameter("COD_FONDOSMOV", DbType.Decimal, 9, kycpersona.fondospormivilizar)
								.AddParameter("COD_FONDOSMOV_DESC", DbType.AnsiString, 15, kycpersona.fondospormivilizarDesc)
								.AddParameter("COD_ACTIVI_ART15", DbType.Decimal, 9, kycpersona.actividadesart15)
								.AddParameter("COD_ACTIVI_ART15_DESC", DbType.AnsiString, 9, kycpersona.actividadesart15Desc)
								.AddParameter("COD_ACTIVO_CORRE", DbType.Decimal, 9, kycpersona.activoscorresponden)
								.AddParameter("COD_ACTIVO_CORRE_DESC", DbType.AnsiString, 40, kycpersona.activoscorrespondenDesc)
								.AddParameter("COD_PEP_CARGO", DbType.Decimal, 5, kycpersona.pepcargo)
								.AddParameter("COD_PEP_CARGO_DESC", DbType.AnsiString, 10, kycpersona.pepcargoDesc)
								.AddParameter("PEP_DURACION", DbType.AnsiString, 60, kycpersona.pepduracion)
								.AddParameter("COD_PEP_RELACION", DbType.Decimal, 5, kycpersona.peprelacion)
								.AddParameter("COD_PEP_RELACION_DESC", DbType.AnsiString, 10, kycpersona.peprelacionDesc)
								.AddParameter("PEP_TIP_RELACION", DbType.AnsiString, 60, kycpersona.peptiporelacion)
								.AddParameter("PROP_RELA_COMERCI", DbType.AnsiString, 60, kycpersona.propositorelacioncomercial)
								.AddParameter("MONT_PRIMA", DbType.Decimal, 20, kycpersona.montoprima)
								.AddParameter("TIP_PRIMA", DbType.AnsiString, 60, kycpersona.tipodeprima)
								.AddParameter("COD_PERIOD", DbType.Decimal, 5, kycpersona.periodicidad)
								.AddParameter("COD_PERIOD_DESC", DbType.AnsiString, 10, kycpersona.periodicidadDesc)
								.AddParameter("MONT_VAL_ASEGU", DbType.Decimal, 20, kycpersona.montoValorasegurado)
								.AddParameter("COD_FORM_PAGO", DbType.Decimal, 5, kycpersona.formadepagodelapoliza)
								.AddParameter("COD_FORM_PAGO_DESC", DbType.AnsiString, 30, kycpersona.formadepagodelapolizaDesc)
								.AddParameter("COD_MEDIO_ENVIO", DbType.Decimal, 5, kycpersona.mediodeenvio)
								.AddParameter("COD_MEDIO_ENVIO_DESC", DbType.AnsiString, 25, kycpersona.mediodeenvioDesc)
								.AddParameter("CORRESPON_ESPECIFI", DbType.AnsiString, 60, kycpersona.especifique)
								.AddParameter("NUM_TIN", DbType.AnsiString, 20, kycpersona.numeroTIN)
								.AddParameter("NUM_EXTRANJERO", DbType.AnsiString, 20, kycpersona.numeroExt)
								.AddParameter("SENAS_DOMIC_EXTRAN", DbType.AnsiString, 80, kycpersona.otrassenasFATCA)
                                .AddParameter("GREEN_CARD", DbType.Decimal, 5, kycpersona.greencard)
                                .AddParameter("IDENTI_EIN", DbType.Decimal, 5, kycpersona.identificacionEIN)
                                .AddParameter("CONTRI_USA", DbType.Decimal, 5, kycpersona.contribuyenteUSA)
                                .AddParameter("POSEE_DOMIC_EXTRAN", DbType.Decimal, 25, kycpersona.domicilioExtranjero)
                                .AddParameter("PAIS_DOMIC", DbType.Decimal, 25, kycpersona.paisDomicilio)
                                .AddParameter("POSEE_TEL_EXTRAN", DbType.Decimal, 25, kycpersona.poseeTelefonoExtranjero)
                                .AddParameter("APORT_XML_FATCA", DbType.Decimal, 5, kycpersona.aportaXMLFATCA)
                                .AddParameter("ATRI_CANAL_ING", DbType.Decimal, 5, kycpersona.atributocanaldeingreso)
                                .AddParameter("VAL_CANAL_ING", DbType.Decimal, 5, kycpersona.valorcanalingreso)
                                .AddParameter("COD_ACT_ECONOMICA", DbType.Decimal, 10, kycpersona.actividadEconomica)
                                .Execute(connection, "Research");
                return 1;
            }
            else if(kycobject is KycJuridico)
            {
                KycJuridico kycjuridico = kycobject;
                
                Database.Insert("INSERT INTO KYCJURIDICO ("+alloptionjuridico+")" +
                    "VALUES(:NUM_IDENTIFI,:NOM_COMERCIAL, :RAZON_SOCIAL, :COD_CLIENTE,:TIP_SOCIEDAD, " +
                    ":TIP_IDENT_JUR, :TIP_IDENT_JUR_DESC, :COD_PAIS_CONSTI, :COD_PAIS_CONSTI_DESC, :FECHA_CONSTI, :ACTI_EMPRESA,:TELF_JUR, :FAX_JUR,:APART_POSTAL_JUR, " +
                    ":CORREO_ELECT_JUR,:PAG_WEB,:APELLIDO1_REP,:APELLIDO2_REP,:NOMBRE_REP,:POSICI_ENMPRE,:NUM_IDENTI_REP,:COD_IDENTI_REP,:COD_IDENTI_REP_DESC," +
                    ":ESPEC_IDENTI_REP,:FECHA_CADUCIDAD_REP,:COD_NACION_REP,:COD_NACION_REP_DESC,:FECHA_NACI_REP,:COD_PAIS_NACI_REP,:COD_PAIS_NACI_REP_DESC,:COD_PROFESION_REP,:COD_PROFESION_REP_DESC,:COD_ESTAD_CIVIL_REP," +
                    ":COD_ESTAD_CIVIL_REP_DESC,:COD_SEXO_REP,:COD_SEXO_REP_DESC,:TELF_RESI_REP,:TELF_CELU_REP,:FAX_REP,:APARTA_POSTAL_REP,:CORREO_ELECT_REP," +
                    ":PARTI_ACCIONA,:COD_DOMIC_PERMAN_PAIS,:COD_DOMIC_PERMAN_PAIS_DESC,:COD_DOMIC_PERMAN_PROV,:COD_DOMIC_PERMAN_PROV_DESC," +
                    ":COD_DOMIC_PERMAN_CANT,:COD_DOMIC_PERMAN_CANT_DESC,:COD_DOMIC_PERMAN_DIST,:COD_DOMIC_PERMAN_DIST_DESC,:DOMIC_PERMAN_DIREC_EXAT_PER," +
                    ":COD_DOMICI_COME_PAIS,:COD_DOMICI_COME_PAIS_DESC,:COD_DOMICI_COME_PROV,:COD_DOMICI_COME_PROV_DESC,:COD_DOMICI_COME_CANT," +
                    ":COD_DOMICI_COME_CANT_DESC,:COD_DOMICI_COME_DIST,:COD_DOMICI_COME_DIST_DESC,:DOMICI_COME_DIREC_EXAT,:CORRE_ORIGIN_FONDO," +
                    ":PAIS_MAX_ACTIVI,:INGRE_MENS,:COD_FONDOSMOV,:COD_FONDOSMOV_DESC,:COD_ACTIVI_ART15,:COD_ACTIVI_ART15_DESC,:COD_ACTIVO_CORRE," +
                    ":COD_ACTIVO_CORRE_DESC,:COD_PEP_CARGO,:COD_PEP_CARGO_DESC,:PEP_DURACION,:COD_PEP_RELACION,:COD_PEP_RELACION_DESC," +
                    ":PEP_TIP_RELACION,:PROP_RELA_COMERCI,:MONT_PRIMA,:TIP_PRIMA,:COD_PERIOD,:COD_PERIOD_DESC,:MONT_VAL_ASEGU,:COD_FORM_PAGO," +
                    ":COD_FORM_PAGO_DESC,:COD_MEDIO_ENVIO,:COD_MEDIO_ENVIO_DESC,:CORRESPON_ESPECIFI,:NUM_TIN,:NUM_EXTRANJERO,:SENAS_DOMIC_EXTRAN," +
                    ":GREEN_CARD,:IDENTI_EIN,:CONTRI_USA,:POSEE_DOMIC_EXTRAN,:PAIS_DOMIC,:POSEE_TEL_EXTRAN,:APORT_XML_FATCA,:ATRI_CANAL_ING,:VAL_CANAL_ING,:COD_ACT_ECONOMICA, :COD_ACT_ECONOMICA_REP)")
                                .AddParameter("NUM_IDENTIFI", DbType.AnsiString, 25, kycjuridico.numidentificacion)
                                .AddParameter("NOM_COMERCIAL", DbType.AnsiString, 30, kycjuridico.nombrecomercialJur)
                                .AddParameter("RAZON_SOCIAL", DbType.AnsiString, 40, kycjuridico.razonsocialJur)
                                .AddParameter("COD_CLIENTE", DbType.AnsiString, 30, kycjuridico.codigodeclienteJur)
                                .AddParameter("TIP_SOCIEDAD", DbType.AnsiString, 30, kycjuridico.tipodesociedadJur)
                                .AddParameter("TIP_IDENT_JUR", DbType.Decimal, 20, kycjuridico.tipodecedulajuridicaJur)
                                .AddParameter("TIP_IDENT_JUR_DESC", DbType.AnsiString, 30, kycjuridico.tipodecedulajuridicaJurDesc)
                                .AddParameter("COD_PAIS_CONSTI", DbType.Decimal, 25, kycjuridico.paisdeconstitucionJur)
                                .AddParameter("COD_PAIS_CONSTI_DESC", DbType.AnsiString, 30, kycjuridico.paisdeconstitucionJurDesc)
                                .AddParameter("FECHA_CONSTI", DbType.Date, 0, kycjuridico.fechadeconstitucionJur)
                                .AddParameter("ACTI_EMPRESA", DbType.AnsiString, 60, kycjuridico.actividaddelclientenaturalezadelnegocioJur)
                                .AddParameter("TELF_JUR", DbType.AnsiString, 9, kycjuridico.telefonoJur)
                                .AddParameter("FAX_JUR", DbType.AnsiString, 9, kycjuridico.faxJur)
                                .AddParameter("APART_POSTAL_JUR", DbType.AnsiString, 30, kycjuridico.apartadopostalJur)
                                .AddParameter("CORREO_ELECT_JUR", DbType.AnsiString, 25, kycjuridico.correoelectronicoJur)
                                .AddParameter("PAG_WEB", DbType.AnsiString, 80, kycjuridico.paginaWebJur)
                                .AddParameter("APELLIDO1_REP", DbType.AnsiString, 30, kycjuridico.primerapellidoJur)
                                .AddParameter("APELLIDO2_REP", DbType.AnsiString, 30, kycjuridico.segundoapellidoJur)
                                .AddParameter("NOMBRE_REP", DbType.AnsiString, 20, kycjuridico.nombrecompletoJur)
                                .AddParameter("POSICI_ENMPRE", DbType.AnsiString, 60, kycjuridico.posiciondentrodelaempresaJur)
                                .AddParameter("NUM_IDENTI_REP", DbType.AnsiString, 25, kycjuridico.numerodeidentificacionJur)
                                .AddParameter("COD_IDENTI_REP", DbType.Decimal, 8, kycjuridico.tipodeidentificacionJur)
                                .AddParameter("COD_IDENTI_REP_DESC", DbType.AnsiString, 30, kycjuridico.tipodeidentificacionJurDesc)
                                .AddParameter("ESPEC_IDENTI_REP", DbType.AnsiString, 60, kycjuridico.especifiqueJur)
                                .AddParameter("FECHA_CADUCIDAD_REP", DbType.Date, 0, kycjuridico.fechadecaducidadJur)
                                .AddParameter("COD_NACION_REP", DbType.Decimal, 10, kycjuridico.nacionalidadJur)
                                .AddParameter("COD_NACION_REP_DESC", DbType.AnsiString, 25, kycjuridico.nacionalidadJurDesc)
                                .AddParameter("FECHA_NACI_REP", DbType.Date, 0, kycjuridico.fechadenacimientoJur)
                                .AddParameter("COD_PAIS_NACI_REP", DbType.Decimal, 10, kycjuridico.paisdenacimientoJur)
                                .AddParameter("COD_PAIS_NACI_REP_DESC", DbType.AnsiString, 25, kycjuridico.paisdenacimientoJurDesc)
                                .AddParameter("COD_PROFESION_REP", DbType.Decimal, 15, kycjuridico.profesionJur)
                                .AddParameter("COD_PROFESION_REP_DESC", DbType.AnsiString, 60, kycjuridico.profesionJurDesc)
                                .AddParameter("COD_ESTAD_CIVIL_REP", DbType.Decimal, 10, kycjuridico.estadocivilJur)
                                .AddParameter("COD_ESTAD_CIVIL_REP_DESC", DbType.AnsiString, 25, kycjuridico.estadocivilJurDesc)
                                .AddParameter("COD_SEXO_REP", DbType.Decimal, 10, kycjuridico.sexoJur)
                                .AddParameter("COD_SEXO_REP_DESC", DbType.AnsiString, 10, kycjuridico.sexoJurDesc)
                                .AddParameter("TELF_RESI_REP", DbType.AnsiString, 9, kycjuridico.telefonoresidenciaJur)
                                .AddParameter("TELF_CELU_REP", DbType.AnsiString, 9, kycjuridico.telefonocelularJur)
                                .AddParameter("FAX_REP", DbType.AnsiString, 9, kycjuridico.datosdelrepresentantelegalFaxJur)
                                .AddParameter("APARTA_POSTAL_REP", DbType.AnsiString, 25, kycjuridico.datosdelrepresentantelegalApartadopostalJur)
                                .AddParameter("CORREO_ELECT_REP", DbType.AnsiString, 40, kycjuridico.datosdelrepresentantelegalCorreoelectronicoJur)
                                .AddParameter("PARTI_ACCIONA", DbType.Clob, 0, JsonConvert.SerializeObject(kycjuridico.participacionaccionariaJur))
                                .AddParameter("COD_DOMIC_PERMAN_PAIS", DbType.AnsiString, 5, kycjuridico.domiciliopermanenteCod_pais)
                                .AddParameter("COD_DOMIC_PERMAN_PAIS_DESC", DbType.AnsiString, 20, kycjuridico.domiciliopermanenteCod_paisDesc)
                                .AddParameter("COD_DOMIC_PERMAN_PROV", DbType.Decimal, 9, kycjuridico.domiciliopermanenteCod_estado)
                                .AddParameter("COD_DOMIC_PERMAN_PROV_DESC", DbType.AnsiString, 20, kycjuridico.domiciliopermanenteCod_estadoDesc)
                                .AddParameter("COD_DOMIC_PERMAN_CANT", DbType.Decimal, 9, kycjuridico.domiciliopermanenteCod_prov)
                                .AddParameter("COD_DOMIC_PERMAN_CANT_DESC", DbType.AnsiString, 20, kycjuridico.domiciliopermanenteCod_provDesc)
                                .AddParameter("COD_DOMIC_PERMAN_DIST", DbType.Decimal, 9, kycjuridico.domiciliopermanenteCod_localidad)
                                .AddParameter("COD_DOMIC_PERMAN_DIST_DESC", DbType.AnsiString, 20, kycjuridico.domiciliopermanenteCod_localidadDesc)
                                .AddParameter("DOMIC_PERMAN_DIREC_EXAT_PER", DbType.AnsiString, 80, kycjuridico.domiciliopermanenteDireccionexacta)
                                .AddParameter("COD_DOMICI_COME_PAIS", DbType.AnsiString, 5, kycjuridico.domiciliocomercialCod_pais)
                                .AddParameter("COD_DOMICI_COME_PAIS_DESC", DbType.AnsiString, 20, kycjuridico.domiciliocomercialCod_paisDesc)
                                .AddParameter("COD_DOMICI_COME_PROV", DbType.Decimal, 9, kycjuridico.domiciliocomercialCod_estado)
                                .AddParameter("COD_DOMICI_COME_PROV_DESC", DbType.AnsiString, 20, kycjuridico.domiciliocomercialCod_estadoDesc)
                                .AddParameter("COD_DOMICI_COME_CANT", DbType.Decimal, 9, kycjuridico.domiciliocomercialCod_prov)
                                .AddParameter("COD_DOMICI_COME_CANT_DESC", DbType.AnsiString, 20, kycjuridico.domiciliocomercialCod_provDesc)
                                .AddParameter("COD_DOMICI_COME_DIST", DbType.Decimal, 9, kycjuridico.domiciliocomercialCod_localidad)
                                .AddParameter("COD_DOMICI_COME_DIST_DESC", DbType.AnsiString, 20, kycjuridico.domiciliocomercialCod_localidadDesc)
                                .AddParameter("DOMICI_COME_DIREC_EXAT", DbType.AnsiString, 80, kycjuridico.domiciliocomercialDireccionexacta)
                                .AddParameter("CORRE_ORIGIN_FONDO", DbType.AnsiString, 60, kycjuridico.correspondenciaOrigendelosfondos)
                                .AddParameter("PAIS_MAX_ACTIVI", DbType.AnsiString, 60, kycjuridico.paismayoractividad)
                                .AddParameter("INGRE_MENS", DbType.Decimal, 20, kycjuridico.ingresomensualestimado)
                                .AddParameter("COD_FONDOSMOV", DbType.Decimal, 9, kycjuridico.fondospormivilizar)
                                .AddParameter("COD_FONDOSMOV_DESC", DbType.AnsiString, 15, kycjuridico.fondospormivilizarDesc)
                                .AddParameter("COD_ACTIVI_ART15", DbType.Decimal, 9, kycjuridico.actividadesart15)
                                .AddParameter("COD_ACTIVI_ART15_DESC", DbType.AnsiString, 9, kycjuridico.actividadesart15Desc)
                                .AddParameter("COD_ACTIVO_CORRE", DbType.Decimal, 9, kycjuridico.activoscorresponden)
                                .AddParameter("COD_ACTIVO_CORRE_DESC", DbType.AnsiString, 40, kycjuridico.activoscorrespondenDesc)
                                .AddParameter("COD_PEP_CARGO", DbType.Decimal, 5, kycjuridico.pepcargo)
                                .AddParameter("COD_PEP_CARGO_DESC", DbType.AnsiString, 10, kycjuridico.pepcargoDesc)
                                .AddParameter("PEP_DURACION", DbType.AnsiString, 60, kycjuridico.pepduracion)
                                .AddParameter("COD_PEP_RELACION", DbType.Decimal, 5, kycjuridico.peprelacion)
                                .AddParameter("COD_PEP_RELACION_DESC", DbType.AnsiString, 10, kycjuridico.peprelacionDesc)
                                .AddParameter("PEP_TIP_RELACION", DbType.AnsiString, 60, kycjuridico.peptiporelacion)
                                .AddParameter("PROP_RELA_COMERCI", DbType.AnsiString, 60, kycjuridico.propositorelacioncomercial)
                                .AddParameter("MONT_PRIMA", DbType.Decimal, 20, kycjuridico.montoprima)
                                .AddParameter("TIP_PRIMA", DbType.AnsiString, 60, kycjuridico.tipodeprima)
                                .AddParameter("COD_PERIOD", DbType.Decimal, 5, kycjuridico.periodicidad)
                                .AddParameter("COD_PERIOD_DESC", DbType.AnsiString, 10, kycjuridico.periodicidadDesc)
                                .AddParameter("MONT_VAL_ASEGU", DbType.Decimal, 20, kycjuridico.montoValorasegurado)
                                .AddParameter("COD_FORM_PAGO", DbType.Decimal, 5, kycjuridico.formadepagodelapoliza)
                                .AddParameter("COD_FORM_PAGO_DESC", DbType.AnsiString, 30, kycjuridico.formadepagodelapolizaDesc)
                                .AddParameter("COD_MEDIO_ENVIO", DbType.Decimal, 5, kycjuridico.mediodeenvio)
                                .AddParameter("COD_MEDIO_ENVIO_DESC", DbType.AnsiString, 25, kycjuridico.mediodeenvioDesc)
                                .AddParameter("CORRESPON_ESPECIFI", DbType.AnsiString, 60, kycjuridico.especifique)
                                .AddParameter("NUM_TIN", DbType.AnsiString, 20, kycjuridico.numeroTIN)
                                .AddParameter("NUM_EXTRANJERO", DbType.AnsiString, 20, kycjuridico.numeroExt)
                                .AddParameter("SENAS_DOMIC_EXTRAN", DbType.AnsiString, 80, kycjuridico.otrassenasFATCA)
                                .AddParameter("GREEN_CARD", DbType.Decimal, 5, kycjuridico.greencard)
                                .AddParameter("IDENTI_EIN", DbType.Decimal, 5, kycjuridico.identificacionEIN)
                                .AddParameter("CONTRI_USA", DbType.Decimal, 5, kycjuridico.contribuyenteUSA)
                                .AddParameter("POSEE_DOMIC_EXTRAN", DbType.Decimal, 25, kycjuridico.domicilioExtranjero)
                                .AddParameter("PAIS_DOMIC", DbType.Decimal, 25, kycjuridico.paisDomicilio)
                                .AddParameter("POSEE_TEL_EXTRAN", DbType.Decimal, 25, kycjuridico.poseeTelefonoExtranjero)
                                .AddParameter("APORT_XML_FATCA", DbType.Decimal, 5, kycjuridico.aportaXMLFATCA)
                                .AddParameter("ATRI_CANAL_ING", DbType.Decimal, 5, kycjuridico.atributocanaldeingreso)
                                .AddParameter("VAL_CANAL_ING", DbType.Decimal, 5, kycjuridico.valorcanalingreso)
                                .AddParameter("COD_ACT_ECONOMICA", DbType.Decimal, 10, kycjuridico.actividadEconomica)
                                .AddParameter("COD_ACT_ECONOMICA_REP", DbType.Decimal, 10, kycjuridico.actividadEconomicaRep)
                                .Execute(connection, "Research");
                return 1;
            }

			return 0;
            
        }

		/// <summary>
		/// Recupera un registro en la tabla Kycpersona o KycJuridico por medio de su clave primaria.
		/// </summary>
		/// <param name="type">Tipo de peticion</param>
		/// <param name="identificacion">Identificación única de la solcitud..</param>
		/// <param name="connection">Instancia de una conexión compartida</param>
		/// <returns>Instancia de PolicyProposal</returns>
		public static dynamic Retrieve(string type,string identificacion, IDbConnection connection = null)
		{
			dynamic result = null;

            if (type == "persona")
            {
				result = new Kycpersona();
                Database.Select("SELECT " + alloptionpersona +
                                  " FROM KYCPERSONA " +
                                 "WHERE REPLACE (NUM_IDENTIFI,'-','')= :IDENTIFI ")
                        .AddParameter("IDENTIFI", DbType.String, 20, identificacion)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
							result = DataReaderToKycpersona(reader);
                        }));
            }
            else if(type == "juridico")
            {
                result = new KycJuridico();
                Database.Select("SELECT " + alloptionjuridico +
                                  " FROM KYCJURIDICO " +
                                 "WHERE REPLACE (NUM_IDENTIFI,'-','')= :IDENTIFI ")
                        .AddParameter("IDENTIFI", DbType.String, 20, identificacion)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToKycJuridico(reader);
                        }));
            }
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla PolicyProposal.
        /// </summary>
        /// <param name="id">Identificación.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de PolicyProposal</returns>
        public static List<dynamic> RetrieveAll(string id, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<dynamic> result = new List<dynamic>();
            Database.Select("SELECT " + alloptionpersona +
                              " FROM KYCPERSONA LEFT " +
                             "WHERE REPLACE (NUM_IDENTIFI,'-','')= :IDENTIFI")
                        .AddParameter("CompanyId", DbType.Decimal, 5, id)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToKycpersona(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla Kycpersona o kycjuridica por medio de su clave primaria.
        /// </summary>
        /// <param name="kycobject">Instancia de KYC</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(string id,dynamic kycobject, IDbConnection connection = null)
		{
            if (kycobject is Kycpersona)
            {
                Kycpersona kycpersona = kycobject;
                return Database.Update("Update KYCPERSONA " +
                    "Set NOMBRE=:NOMBRE, APELLIDO1=:APELLIDO1, APELLIDO2=:APELLIDO2, COD_CLIENTE=:COD_CLIENTE, COD_TIP_IDENTIFI=:COD_TIP_IDENTIFI, " +
                    "TIP_IDENT_DESC=:TIP_IDENT_DESC, FECHA_CADUCIDAD=:FECHA_CADUCIDAD, COD_NACIONALI=:COD_NACIONALI, COD_NACIONALI_DESC=:COD_NACIONALI_DESC, FECHA_NACI=:FECHA_NACI, COD_PAIS_NACI=:COD_PAIS_NACI,COD_PAIS_NACI_DESC=:COD_PAIS_NACI_DESC,  COD_PROFESION=:COD_PROFESION,COD_PROFESION_DESC=:COD_PROFESION_DESC, " +
                    "COD_ESTAD_CIVIL=:COD_ESTAD_CIVIL, COD_ESTAD_CIVIL_DESC=:COD_ESTAD_CIVIL_DESC, COD_SEXO=:COD_SEXO, COD_SEXO_DESC=:COD_SEXO_DESC, TELF_RESIDEN=:TELF_RESIDEN, TELF_CELULAR=:TELF_CELULAR, FAX_PER=:FAX_PER, " +
                    "APARTADO_POST_PER=:APARTADO_POST_PER,CORREO_ELEC_PER=:CORREO_ELEC_PER,COD_DOMIC_PERMAN_PAIS=:COD_DOMIC_PERMAN_PAIS,COD_DOMIC_PERMAN_PAIS_DESC=:COD_DOMIC_PERMAN_PAIS_DESC,COD_DOMIC_PERMAN_PROV=:COD_DOMIC_PERMAN_PROV,COD_DOMIC_PERMAN_PROV_DESC=:COD_DOMIC_PERMAN_PROV_DESC," +
                    "COD_DOMIC_PERMAN_CANT=:COD_DOMIC_PERMAN_CANT,COD_DOMIC_PERMAN_CANT_DESC=:COD_DOMIC_PERMAN_CANT_DESC,COD_DOMIC_PERMAN_DIST=:COD_DOMIC_PERMAN_DIST,COD_DOMIC_PERMAN_DIST_DESC=:COD_DOMIC_PERMAN_DIST_DESC,DOMIC_PERMAN_DIREC_EXAT_PER=:DOMIC_PERMAN_DIREC_EXAT_PER," +
                    "COD_OCUP_PER=:COD_OCUP_PER,COD_OCUP_PER_DESC=:COD_OCUP_PER_DESC,NOM_EMPRES=:NOM_EMPRES,ACTIVI_EMPRES=:ACTIVI_EMPRES,CARGO_EMPRES=:CARGO_EMPRES,TELF_EMPRES=:TELF_EMPRES,FAX_EMPRES=:FAX_EMPRES,COD_DOMICI_COME_PAIS=:COD_DOMICI_COME_PAIS,COD_DOMICI_COME_PAIS_DESC=:COD_DOMICI_COME_PAIS_DESC," +
                    "COD_DOMICI_COME_PROV=:COD_DOMICI_COME_PROV,COD_DOMICI_COME_PROV_DESC=:COD_DOMICI_COME_PROV_DESC,COD_DOMICI_COME_CANT=:COD_DOMICI_COME_CANT,COD_DOMICI_COME_CANT_DESC=:COD_DOMICI_COME_CANT_DESC,COD_DOMICI_COME_DIST=:COD_DOMICI_COME_DIST,COD_DOMICI_COME_DIST_DESC=:COD_DOMICI_COME_DIST_DESC," +
                    "DOMICI_COME_DIREC_EXAT=:DOMICI_COME_DIREC_EXAT,CORRE_ORIGIN_FONDO=:CORRE_ORIGIN_FONDO,PAIS_MAX_ACTIVI=:PAIS_MAX_ACTIVI,INGRE_MENS=:INGRE_MENS,COD_FONDOSMOV=:COD_FONDOSMOV," +
                    "COD_FONDOSMOV_DESC=:COD_FONDOSMOV_DESC,COD_ACTIVI_ART15=:COD_ACTIVI_ART15,COD_ACTIVI_ART15_DESC=:COD_ACTIVI_ART15_DESC,COD_ACTIVO_CORRE=:COD_ACTIVO_CORRE,COD_ACTIVO_CORRE_DESC=:COD_ACTIVO_CORRE_DESC,COD_PEP_CARGO=:COD_PEP_CARGO,COD_PEP_CARGO_DESC=:COD_PEP_CARGO_DESC,PEP_DURACION=:PEP_DURACION," +
                    "COD_PEP_RELACION=:COD_PEP_RELACION,COD_PEP_RELACION_DESC=:COD_PEP_RELACION_DESC,PEP_TIP_RELACION=:PEP_TIP_RELACION,PROP_RELA_COMERCI=:PROP_RELA_COMERCI,MONT_PRIMA=:MONT_PRIMA,TIP_PRIMA=:TIP_PRIMA,COD_PERIOD=:COD_PERIOD,COD_PERIOD_DESC=:COD_PERIOD_DESC," +
                    "MONT_VAL_ASEGU=:MONT_VAL_ASEGU,COD_FORM_PAGO=:COD_FORM_PAGO,COD_FORM_PAGO_DESC=:COD_FORM_PAGO_DESC,COD_MEDIO_ENVIO=:COD_MEDIO_ENVIO,COD_MEDIO_ENVIO_DESC=:COD_MEDIO_ENVIO_DESC,CORRESPON_ESPECIFI=:CORRESPON_ESPECIFI, NUM_TIN=:NUM_TIN, NUM_EXTRANJERO=:NUM_EXTRANJERO, SENAS_DOMIC_EXTRAN=:SENAS_DOMIC_EXTRAN," +
                    "GREEN_CARD=:GREEN_CARD, IDENTI_EIN=:IDENTI_EIN, CONTRI_USA=:CONTRI_USA, POSEE_DOMIC_EXTRAN=:POSEE_DOMIC_EXTRAN, PAIS_DOMIC=:PAIS_DOMIC," +
                    "POSEE_TEL_EXTRAN=:POSEE_TEL_EXTRAN, APORT_XML_FATCA=:APORT_XML_FATCA, ATRI_CANAL_ING=:ATRI_CANAL_ING, VAL_CANAL_ING=:VAL_CANAL_ING, COD_ACT_ECONOMICA=:COD_ACT_ECONOMICA " +
                    "Where REPLACE (NUM_IDENTIFI,'-','')=:NUM_IDENTIFI")
                            .AddParameter("NOMBRE", DbType.String, 20, kycpersona.nombrePer)
                            .AddParameter("APELLIDO1", DbType.AnsiString, 20, kycpersona.primerapellidoPer)
                            .AddParameter("APELLIDO2", DbType.AnsiString, 20, kycpersona.segundoapellidoPer)
                            .AddParameter("COD_CLIENTE", DbType.AnsiString, 30, kycpersona.codigodeclientePer)
                            .AddParameter("COD_TIP_IDENTIFI", DbType.Decimal, 20, kycpersona.numidentificaciontipo)
                            .AddParameter("TIP_IDENT_DESC", DbType.AnsiString, 30, kycpersona.numidentificaciontipoDesc)
                            .AddParameter("FECHA_CADUCIDAD", DbType.Date, 0, kycpersona.fechadecaducidadPer)
                            .AddParameter("COD_NACIONALI", DbType.Decimal, 25, kycpersona.nacionalidadPer)
                            .AddParameter("COD_NACIONALI_DESC", DbType.AnsiString, 15, kycpersona.nacionalidadPerDesc)
                            .AddParameter("FECHA_NACI", DbType.Date, 0, kycpersona.fechadenacimientoPer)
                            .AddParameter("COD_PAIS_NACI", DbType.Decimal, 10, kycpersona.paisdenacimientoPer)
                            .AddParameter("COD_PAIS_NACI_DESC", DbType.AnsiString, 20, kycpersona.paisdenacimientoPerDesc)
                            .AddParameter("COD_PROFESION", DbType.Decimal, 15, kycpersona.profesionPer)
                            .AddParameter("COD_PROFESION_DESC", DbType.AnsiString, 40, kycpersona.profesionPerDesc)
                            .AddParameter("COD_ESTAD_CIVIL", DbType.Decimal, 10, kycpersona.estadocivilPer)
                            .AddParameter("COD_ESTAD_CIVIL_DESC", DbType.AnsiString, 15, kycpersona.estadocivilPerDesc)
                            .AddParameter("COD_SEXO", DbType.Decimal, 10, kycpersona.sexoPer)
                            .AddParameter("COD_SEXO_DESC", DbType.AnsiString, 10, kycpersona.sexoPerDesc)
                            .AddParameter("TELF_RESIDEN", DbType.AnsiString, 9, kycpersona.telefonoresidenciaPer)
                            .AddParameter("TELF_CELULAR", DbType.AnsiString, 9, kycpersona.telefonocelularPer)
                            .AddParameter("FAX_PER", DbType.AnsiString, 9, kycpersona.faxPer)
                            .AddParameter("APARTADO_POST_PER", DbType.AnsiString, 25, kycpersona.apartadopostalPer)
                            .AddParameter("CORREO_ELEC_PER", DbType.AnsiString, 80, kycpersona.correoelectronicoPer)
                            .AddParameter("COD_DOMIC_PERMAN_PAIS", DbType.AnsiString, 5, kycpersona.domiciliopermanenteCod_pais)
                            .AddParameter("COD_DOMIC_PERMAN_PAIS_DESC", DbType.AnsiString, 20, kycpersona.domiciliopermanenteCod_paisDesc)
                            .AddParameter("COD_DOMIC_PERMAN_PROV", DbType.Decimal, 9, kycpersona.domiciliopermanenteCod_estado)
                            .AddParameter("COD_DOMIC_PERMAN_PROV_DESC", DbType.AnsiString, 20, kycpersona.domiciliopermanenteCod_estadoDesc)
                            .AddParameter("COD_DOMIC_PERMAN_CANT", DbType.Decimal, 9, kycpersona.domiciliopermanenteCod_prov)
                            .AddParameter("COD_DOMIC_PERMAN_CANT_DESC", DbType.AnsiString, 20, kycpersona.domiciliopermanenteCod_provDesc)
                            .AddParameter("COD_DOMIC_PERMAN_DIST", DbType.Decimal, 9, kycpersona.domiciliopermanenteCod_localidad)
                            .AddParameter("COD_DOMIC_PERMAN_DIST_DESC", DbType.AnsiString, 20, kycpersona.domiciliopermanenteCod_localidadDesc)
                            .AddParameter("DOMIC_PERMAN_DIREC_EXAT_PER", DbType.AnsiString, 80, kycpersona.domiciliopermanenteDireccionexacta)
                            .AddParameter("COD_OCUP_PER", DbType.Decimal, 9, kycpersona.OcupacionPer)
                            .AddParameter("COD_OCUP_PER_DESC", DbType.AnsiString, 25, kycpersona.OcupacionPerDesc)
                            .AddParameter("NOM_EMPRES", DbType.AnsiString, 60, kycpersona.nombreempresaPer)
                            .AddParameter("ACTIVI_EMPRES", DbType.AnsiString, 60, kycpersona.actividadempresaPer)
                            .AddParameter("CARGO_EMPRES", DbType.AnsiString, 60, kycpersona.cargoempresaPer)
                            .AddParameter("TELF_EMPRES", DbType.AnsiString, 9, kycpersona.telefonoempresaPer)
                            .AddParameter("FAX_EMPRES", DbType.AnsiString, 9, kycpersona.faxempresaPer)
                            .AddParameter("COD_DOMICI_COME_PAIS", DbType.AnsiString, 5, kycpersona.domiciliocomercialCod_pais)
                            .AddParameter("COD_DOMICI_COME_PAIS_DESC", DbType.AnsiString, 20, kycpersona.domiciliocomercialCod_paisDesc)
                            .AddParameter("COD_DOMICI_COME_PROV", DbType.Decimal, 9, kycpersona.domiciliocomercialCod_estado)
                            .AddParameter("COD_DOMICI_COME_PROV_DESC", DbType.AnsiString, 20, kycpersona.domiciliocomercialCod_estadoDesc)
                            .AddParameter("COD_DOMICI_COME_CANT", DbType.Decimal, 9, kycpersona.domiciliocomercialCod_prov)
                            .AddParameter("COD_DOMICI_COME_CANT_DESC", DbType.AnsiString, 20, kycpersona.domiciliocomercialCod_provDesc)
                            .AddParameter("COD_DOMICI_COME_DIST", DbType.Decimal, 9, kycpersona.domiciliocomercialCod_localidad)
                            .AddParameter("COD_DOMICI_COME_DIST_DESC", DbType.AnsiString, 20, kycpersona.domiciliocomercialCod_localidadDesc)
                            .AddParameter("DOMICI_COME_DIREC_EXAT", DbType.AnsiString, 80, kycpersona.domiciliocomercialDireccionexacta)
                            .AddParameter("CORRE_ORIGIN_FONDO", DbType.AnsiString, 60, kycpersona.correspondenciaOrigendelosfondos)
                            .AddParameter("PAIS_MAX_ACTIVI", DbType.AnsiString, 60, kycpersona.paismayoractividad)
                            .AddParameter("INGRE_MENS", DbType.Decimal, 20, kycpersona.ingresomensualestimado)
                            .AddParameter("COD_FONDOSMOV", DbType.Decimal, 9, kycpersona.fondospormivilizar)
                            .AddParameter("COD_FONDOSMOV_DESC", DbType.AnsiString, 15, kycpersona.fondospormivilizarDesc)
                            .AddParameter("COD_ACTIVI_ART15", DbType.Decimal, 9, kycpersona.actividadesart15)
                            .AddParameter("COD_ACTIVI_ART15_DESC", DbType.AnsiString, 9, kycpersona.actividadesart15Desc)
                            .AddParameter("COD_ACTIVO_CORRE", DbType.Decimal, 9, kycpersona.activoscorresponden)
                            .AddParameter("COD_ACTIVO_CORRE_DESC", DbType.AnsiString, 40, kycpersona.activoscorrespondenDesc)
                            .AddParameter("COD_PEP_CARGO", DbType.Decimal, 5, kycpersona.pepcargo)
                            .AddParameter("COD_PEP_CARGO_DESC", DbType.AnsiString, 10, kycpersona.pepcargoDesc)
                            .AddParameter("PEP_DURACION", DbType.AnsiString, 60, kycpersona.pepduracion)
                            .AddParameter("COD_PEP_RELACION", DbType.Decimal, 5, kycpersona.peprelacion)
                            .AddParameter("COD_PEP_RELACION_DESC", DbType.AnsiString, 10, kycpersona.peprelacionDesc)
                            .AddParameter("PEP_TIP_RELACION", DbType.AnsiString, 60, kycpersona.peptiporelacion)
                            .AddParameter("PROP_RELA_COMERCI", DbType.AnsiString, 60, kycpersona.propositorelacioncomercial)
                            .AddParameter("MONT_PRIMA", DbType.Decimal, 20, kycpersona.montoprima)
                            .AddParameter("TIP_PRIMA", DbType.AnsiString, 60, kycpersona.tipodeprima)
                            .AddParameter("COD_PERIOD", DbType.Decimal, 5, kycpersona.periodicidad)
                            .AddParameter("COD_PERIOD_DESC", DbType.AnsiString, 10, kycpersona.periodicidadDesc)
                            .AddParameter("MONT_VAL_ASEGU", DbType.Decimal, 20, kycpersona.montoValorasegurado)
                            .AddParameter("COD_FORM_PAGO", DbType.Decimal, 5, kycpersona.formadepagodelapoliza)
                            .AddParameter("COD_FORM_PAGO_DESC", DbType.AnsiString, 30, kycpersona.formadepagodelapolizaDesc)
                            .AddParameter("COD_MEDIO_ENVIO", DbType.Decimal, 5, kycpersona.mediodeenvio)
                            .AddParameter("COD_MEDIO_ENVIO_DESC", DbType.AnsiString, 25, kycpersona.mediodeenvioDesc)
                            .AddParameter("CORRESPON_ESPECIFI", DbType.AnsiString, 60, kycpersona.especifique)
                            .AddParameter("NUM_TIN", DbType.AnsiString, 20, kycpersona.numeroTIN)
                            .AddParameter("NUM_EXTRANJERO", DbType.AnsiString, 20, kycpersona.numeroExt)
                            .AddParameter("SENAS_DOMIC_EXTRAN", DbType.AnsiString, 80, kycpersona.otrassenasFATCA)
                            .AddParameter("GREEN_CARD", DbType.Decimal, 5, kycpersona.greencard)
                            .AddParameter("IDENTI_EIN", DbType.Decimal, 5, kycpersona.identificacionEIN)
                            .AddParameter("CONTRI_USA", DbType.Decimal, 5, kycpersona.contribuyenteUSA)
                            .AddParameter("POSEE_DOMIC_EXTRAN", DbType.Decimal, 25, kycpersona.domicilioExtranjero)
                            .AddParameter("PAIS_DOMIC", DbType.Decimal, 25, kycpersona.paisDomicilio)
                            .AddParameter("POSEE_TEL_EXTRAN", DbType.Decimal, 25, kycpersona.poseeTelefonoExtranjero)
                            .AddParameter("APORT_XML_FATCA", DbType.Decimal, 5, kycpersona.aportaXMLFATCA)
                            .AddParameter("ATRI_CANAL_ING", DbType.Decimal, 5, kycpersona.atributocanaldeingreso)
                            .AddParameter("VAL_CANAL_ING", DbType.Decimal, 5, kycpersona.valorcanalingreso)
                            .AddParameter("COD_ACT_ECONOMICA", DbType.Decimal, 10, kycpersona.actividadEconomica)
                            .AddParameter("NUM_IDENTIFI", DbType.String, 25, id)
                            .Execute(connection, "Research");
            }
            else if (kycobject is KycJuridico)
            {
                KycJuridico kycjuridico = kycobject;
                

                return Database.Update("Update KYCJURIDICO " +
                    "Set NOM_COMERCIAL=:NOM_COMERCIAL,RAZON_SOCIAL=:RAZON_SOCIAL,COD_CLIENTE=:COD_CLIENTE,TIP_SOCIEDAD=:TIP_SOCIEDAD,TIP_IDENT_JUR=:TIP_IDENT_JUR," +
                    "TIP_IDENT_JUR_DESC=:TIP_IDENT_JUR_DESC,COD_PAIS_CONSTI=:COD_PAIS_CONSTI,COD_PAIS_CONSTI_DESC=:COD_PAIS_CONSTI_DESC,FECHA_CONSTI=:FECHA_CONSTI," +
                    "ACTI_EMPRESA=:ACTI_EMPRESA,TELF_JUR=:TELF_JUR,FAX_JUR=:FAX_JUR,APART_POSTAL_JUR=:APART_POSTAL_JUR,CORREO_ELECT_JUR=:CORREO_ELECT_JUR,PAG_WEB=:PAG_WEB," +
                    "APELLIDO1_REP=:APELLIDO1_REP,APELLIDO2_REP=:APELLIDO2_REP,NOMBRE_REP=:NOMBRE_REP,POSICI_ENMPRE=:POSICI_ENMPRE,NUM_IDENTI_REP=:NUM_IDENTI_REP,COD_IDENTI_REP=:COD_IDENTI_REP," +
                    "COD_IDENTI_REP_DESC=:COD_IDENTI_REP_DESC,ESPEC_IDENTI_REP=:ESPEC_IDENTI_REP,FECHA_CADUCIDAD_REP=:FECHA_CADUCIDAD_REP,COD_NACION_REP=:COD_NACION_REP,COD_NACION_REP_DESC=:COD_NACION_REP_DESC," +
                    "FECHA_NACI_REP=:FECHA_NACI_REP,COD_PAIS_NACI_REP=:COD_PAIS_NACI_REP,COD_PAIS_NACI_REP_DESC=:COD_PAIS_NACI_REP_DESC,COD_PROFESION_REP=:COD_PROFESION_REP,COD_PROFESION_REP_DESC=:COD_PROFESION_REP_DESC," +
                    "COD_ESTAD_CIVIL_REP=:COD_ESTAD_CIVIL_REP,COD_ESTAD_CIVIL_REP_DESC=:COD_ESTAD_CIVIL_REP_DESC,COD_SEXO_REP=:COD_SEXO_REP,COD_SEXO_REP_DESC=:COD_SEXO_REP_DESC,TELF_RESI_REP=:TELF_RESI_REP,TELF_CELU_REP=:TELF_CELU_REP," +
                    "FAX_REP=:FAX_REP,APARTA_POSTAL_REP=:APARTA_POSTAL_REP,CORREO_ELECT_REP=:CORREO_ELECT_REP,PARTI_ACCIONA=:PARTI_ACCIONA,COD_DOMIC_PERMAN_PAIS=:COD_DOMIC_PERMAN_PAIS,COD_DOMIC_PERMAN_PAIS_DESC=:COD_DOMIC_PERMAN_PAIS_DESC,COD_DOMIC_PERMAN_PROV=:COD_DOMIC_PERMAN_PROV,COD_DOMIC_PERMAN_PROV_DESC=:COD_DOMIC_PERMAN_PROV_DESC," +
                    "COD_DOMIC_PERMAN_CANT=:COD_DOMIC_PERMAN_CANT,COD_DOMIC_PERMAN_CANT_DESC=:COD_DOMIC_PERMAN_CANT_DESC,COD_DOMIC_PERMAN_DIST=:COD_DOMIC_PERMAN_DIST,COD_DOMIC_PERMAN_DIST_DESC=:COD_DOMIC_PERMAN_DIST_DESC,DOMIC_PERMAN_DIREC_EXAT_PER=:DOMIC_PERMAN_DIREC_EXAT_PER," +
                    "COD_DOMICI_COME_PAIS=:COD_DOMICI_COME_PAIS,COD_DOMICI_COME_PAIS_DESC=:COD_DOMICI_COME_PAIS_DESC," +
                    "COD_DOMICI_COME_PROV=:COD_DOMICI_COME_PROV,COD_DOMICI_COME_PROV_DESC=:COD_DOMICI_COME_PROV_DESC,COD_DOMICI_COME_CANT=:COD_DOMICI_COME_CANT,COD_DOMICI_COME_CANT_DESC=:COD_DOMICI_COME_CANT_DESC,COD_DOMICI_COME_DIST=:COD_DOMICI_COME_DIST,COD_DOMICI_COME_DIST_DESC=:COD_DOMICI_COME_DIST_DESC," +
                    "DOMICI_COME_DIREC_EXAT=:DOMICI_COME_DIREC_EXAT,CORRE_ORIGIN_FONDO=:CORRE_ORIGIN_FONDO,PAIS_MAX_ACTIVI=:PAIS_MAX_ACTIVI,INGRE_MENS=:INGRE_MENS,COD_FONDOSMOV=:COD_FONDOSMOV," +
                    "COD_FONDOSMOV_DESC=:COD_FONDOSMOV_DESC,COD_ACTIVI_ART15=:COD_ACTIVI_ART15,COD_ACTIVI_ART15_DESC=:COD_ACTIVI_ART15_DESC,COD_ACTIVO_CORRE=:COD_ACTIVO_CORRE,COD_ACTIVO_CORRE_DESC=:COD_ACTIVO_CORRE_DESC,COD_PEP_CARGO=:COD_PEP_CARGO,COD_PEP_CARGO_DESC=:COD_PEP_CARGO_DESC,PEP_DURACION=:PEP_DURACION," +
                    "COD_PEP_RELACION=:COD_PEP_RELACION,COD_PEP_RELACION_DESC=:COD_PEP_RELACION_DESC,PEP_TIP_RELACION=:PEP_TIP_RELACION,PROP_RELA_COMERCI=:PROP_RELA_COMERCI,MONT_PRIMA=:MONT_PRIMA,TIP_PRIMA=:TIP_PRIMA,COD_PERIOD=:COD_PERIOD,COD_PERIOD_DESC=:COD_PERIOD_DESC," +
                    "MONT_VAL_ASEGU=:MONT_VAL_ASEGU,COD_FORM_PAGO=:COD_FORM_PAGO,COD_FORM_PAGO_DESC=:COD_FORM_PAGO_DESC,COD_MEDIO_ENVIO=:COD_MEDIO_ENVIO,COD_MEDIO_ENVIO_DESC=:COD_MEDIO_ENVIO_DESC,CORRESPON_ESPECIFI=:CORRESPON_ESPECIFI,NUM_TIN=:NUM_TIN, NUM_EXTRANJERO=:NUM_EXTRANJERO, SENAS_DOMIC_EXTRAN=:SENAS_DOMIC_EXTRAN," +
                    "GREEN_CARD=:GREEN_CARD, IDENTI_EIN=:IDENTI_EIN, CONTRI_USA=:CONTRI_USA, POSEE_DOMIC_EXTRAN=:POSEE_DOMIC_EXTRAN, PAIS_DOMIC=:PAIS_DOMIC," +
                    "POSEE_TEL_EXTRAN=:POSEE_TEL_EXTRAN, APORT_XML_FATCA=:APORT_XML_FATCA, ATRI_CANAL_ING=:ATRI_CANAL_ING, VAL_CANAL_ING=:VAL_CANAL_ING,COD_ACT_ECONOMICA=:COD_ACT_ECONOMICA,COD_ACT_ECONOMICA_REP=:COD_ACT_ECONOMICA_REP " +
                    "Where REPLACE (NUM_IDENTIFI,'-','')= :NUM_IDENTIFI")
                                .AddParameter("NOM_COMERCIAL", DbType.AnsiString, 30, kycjuridico.nombrecomercialJur)
                                .AddParameter("RAZON_SOCIAL", DbType.AnsiString, 40, kycjuridico.razonsocialJur)
                                .AddParameter("COD_CLIENTE", DbType.AnsiString, 30, kycjuridico.codigodeclienteJur)
                                .AddParameter("TIP_SOCIEDAD", DbType.AnsiString, 30, kycjuridico.tipodesociedadJur)
                                .AddParameter("TIP_IDENT_JUR", DbType.Decimal, 20, kycjuridico.tipodecedulajuridicaJur)
                                .AddParameter("TIP_IDENT_JUR_DESC", DbType.AnsiString, 30, kycjuridico.tipodecedulajuridicaJurDesc)
                                .AddParameter("COD_PAIS_CONSTI", DbType.Decimal, 25, kycjuridico.paisdeconstitucionJur)
                                .AddParameter("COD_PAIS_CONSTI_DESC", DbType.AnsiString, 30, kycjuridico.paisdeconstitucionJurDesc)
                                .AddParameter("FECHA_CONSTI", DbType.Date, 0, kycjuridico.fechadeconstitucionJur)
                                .AddParameter("ACTI_EMPRESA", DbType.AnsiString, 60, kycjuridico.actividaddelclientenaturalezadelnegocioJur)
                                .AddParameter("TELF_JUR", DbType.AnsiString, 9, kycjuridico.telefonoJur)
                                .AddParameter("FAX_JUR", DbType.AnsiString, 9, kycjuridico.faxJur)
                                .AddParameter("APART_POSTAL_JUR", DbType.AnsiString, 30, kycjuridico.apartadopostalJur)
                                .AddParameter("CORREO_ELECT_JUR", DbType.AnsiString, 25, kycjuridico.correoelectronicoJur)
                                .AddParameter("PAG_WEB", DbType.AnsiString, 80, kycjuridico.paginaWebJur)
                                .AddParameter("APELLIDO1_REP", DbType.AnsiString, 30, kycjuridico.primerapellidoJur)
                                .AddParameter("APELLIDO2_REP", DbType.AnsiString, 30, kycjuridico.segundoapellidoJur)
                                .AddParameter("NOMBRE_REP", DbType.AnsiString, 20, kycjuridico.nombrecompletoJur)
                                .AddParameter("POSICI_ENMPRE", DbType.AnsiString, 60, kycjuridico.posiciondentrodelaempresaJur)
                                .AddParameter("NUM_IDENTI_REP", DbType.AnsiString, 25, kycjuridico.numerodeidentificacionJur)
                                .AddParameter("COD_IDENTI_REP", DbType.Decimal, 8, kycjuridico.tipodeidentificacionJur)
                                .AddParameter("COD_IDENTI_REP_DESC", DbType.AnsiString, 30, kycjuridico.tipodeidentificacionJurDesc)
                                .AddParameter("ESPEC_IDENTI_REP", DbType.AnsiString, 60, kycjuridico.especifiqueJur)
                                .AddParameter("FECHA_CADUCIDAD_REP", DbType.Date, 0, kycjuridico.fechadecaducidadJur)
                                .AddParameter("COD_NACION_REP", DbType.Decimal, 10, kycjuridico.nacionalidadJur)
                                .AddParameter("COD_NACION_REP_DESC", DbType.AnsiString, 25, kycjuridico.nacionalidadJurDesc)
                                .AddParameter("FECHA_NACI_REP", DbType.Date, 0, kycjuridico.fechadenacimientoJur)
                                .AddParameter("COD_PAIS_NACI_REP", DbType.Decimal, 10, kycjuridico.paisdenacimientoJur)
                                .AddParameter("COD_PAIS_NACI_REP_DESC", DbType.AnsiString, 25, kycjuridico.paisdenacimientoJurDesc)
                                .AddParameter("COD_PROFESION_REP", DbType.Decimal, 15, kycjuridico.profesionJur)
                                .AddParameter("COD_PROFESION_REP_DESC", DbType.AnsiString, 60, kycjuridico.profesionJurDesc)
                                .AddParameter("COD_ESTAD_CIVIL_REP", DbType.Decimal, 10, kycjuridico.estadocivilJur)
                                .AddParameter("COD_ESTAD_CIVIL_REP_DESC", DbType.AnsiString, 25, kycjuridico.estadocivilJurDesc)
                                .AddParameter("COD_SEXO_REP", DbType.Decimal, 10, kycjuridico.sexoJur)
                                .AddParameter("COD_SEXO_REP_DESC", DbType.AnsiString, 10, kycjuridico.sexoJurDesc)
                                .AddParameter("TELF_RESI_REP", DbType.AnsiString, 9, kycjuridico.telefonoresidenciaJur)
                                .AddParameter("TELF_CELU_REP", DbType.AnsiString, 9, kycjuridico.telefonocelularJur)
                                .AddParameter("FAX_REP", DbType.AnsiString, 9, kycjuridico.datosdelrepresentantelegalFaxJur)
                                .AddParameter("APARTA_POSTAL_REP", DbType.AnsiString, 25, kycjuridico.datosdelrepresentantelegalApartadopostalJur)
                                .AddParameter("CORREO_ELECT_REP", DbType.AnsiString, 40, kycjuridico.datosdelrepresentantelegalCorreoelectronicoJur)
                                .AddParameter("PARTI_ACCIONA", DbType.Clob, 0, JsonConvert.SerializeObject(kycjuridico.participacionaccionariaJur))
                                .AddParameter("COD_DOMIC_PERMAN_PAIS", DbType.AnsiString, 5, kycjuridico.domiciliopermanenteCod_pais)
                                .AddParameter("COD_DOMIC_PERMAN_PAIS_DESC", DbType.AnsiString, 20, kycjuridico.domiciliopermanenteCod_paisDesc)
                                .AddParameter("COD_DOMIC_PERMAN_PROV", DbType.Decimal, 9, kycjuridico.domiciliopermanenteCod_estado)
                                .AddParameter("COD_DOMIC_PERMAN_PROV_DESC", DbType.AnsiString, 20, kycjuridico.domiciliopermanenteCod_estadoDesc)
                                .AddParameter("COD_DOMIC_PERMAN_CANT", DbType.Decimal, 9, kycjuridico.domiciliopermanenteCod_prov)
                                .AddParameter("COD_DOMIC_PERMAN_CANT_DESC", DbType.AnsiString, 20, kycjuridico.domiciliopermanenteCod_provDesc)
                                .AddParameter("COD_DOMIC_PERMAN_DIST", DbType.Decimal, 9, kycjuridico.domiciliopermanenteCod_localidad)
                                .AddParameter("COD_DOMIC_PERMAN_DIST_DESC", DbType.AnsiString, 20, kycjuridico.domiciliopermanenteCod_localidadDesc)
                                .AddParameter("DOMIC_PERMAN_DIREC_EXAT_PER", DbType.AnsiString, 80, kycjuridico.domiciliopermanenteDireccionexacta)
                                .AddParameter("COD_DOMICI_COME_PAIS", DbType.AnsiString, 5, kycjuridico.domiciliocomercialCod_pais)
                                .AddParameter("COD_DOMICI_COME_PAIS_DESC", DbType.AnsiString, 20, kycjuridico.domiciliocomercialCod_paisDesc)
                                .AddParameter("COD_DOMICI_COME_PROV", DbType.Decimal, 9, kycjuridico.domiciliocomercialCod_estado)
                                .AddParameter("COD_DOMICI_COME_PROV_DESC", DbType.AnsiString, 20, kycjuridico.domiciliocomercialCod_estadoDesc)
                                .AddParameter("COD_DOMICI_COME_CANT", DbType.Decimal, 9, kycjuridico.domiciliocomercialCod_prov)
                                .AddParameter("COD_DOMICI_COME_CANT_DESC", DbType.AnsiString, 20, kycjuridico.domiciliocomercialCod_provDesc)
                                .AddParameter("COD_DOMICI_COME_DIST", DbType.Decimal, 9, kycjuridico.domiciliocomercialCod_localidad)
                                .AddParameter("COD_DOMICI_COME_DIST_DESC", DbType.AnsiString, 20, kycjuridico.domiciliocomercialCod_localidadDesc)
                                .AddParameter("DOMICI_COME_DIREC_EXAT", DbType.AnsiString, 80, kycjuridico.domiciliocomercialDireccionexacta)
                                .AddParameter("CORRE_ORIGIN_FONDO", DbType.AnsiString, 60, kycjuridico.correspondenciaOrigendelosfondos)
                                .AddParameter("PAIS_MAX_ACTIVI", DbType.AnsiString, 60, kycjuridico.paismayoractividad)
                                .AddParameter("INGRE_MENS", DbType.Decimal, 20, kycjuridico.ingresomensualestimado)
                                .AddParameter("COD_FONDOSMOV", DbType.Decimal, 9, kycjuridico.fondospormivilizar)
                                .AddParameter("COD_FONDOSMOV_DESC", DbType.AnsiString, 15, kycjuridico.fondospormivilizarDesc)
                                .AddParameter("COD_ACTIVI_ART15", DbType.Decimal, 9, kycjuridico.actividadesart15)
                                .AddParameter("COD_ACTIVI_ART15_DESC", DbType.AnsiString, 9, kycjuridico.actividadesart15Desc)
                                .AddParameter("COD_ACTIVO_CORRE", DbType.Decimal, 9, kycjuridico.activoscorresponden)
                                .AddParameter("COD_ACTIVO_CORRE_DESC", DbType.AnsiString, 40, kycjuridico.activoscorrespondenDesc)
                                .AddParameter("COD_PEP_CARGO", DbType.Decimal, 5, kycjuridico.pepcargo)
                                .AddParameter("COD_PEP_CARGO_DESC", DbType.AnsiString, 10, kycjuridico.pepcargoDesc)
                                .AddParameter("PEP_DURACION", DbType.AnsiString, 60, kycjuridico.pepduracion)
                                .AddParameter("COD_PEP_RELACION", DbType.Decimal, 5, kycjuridico.peprelacion)
                                .AddParameter("COD_PEP_RELACION_DESC", DbType.AnsiString, 10, kycjuridico.peprelacionDesc)
                                .AddParameter("PEP_TIP_RELACION", DbType.AnsiString, 60, kycjuridico.peptiporelacion)
                                .AddParameter("PROP_RELA_COMERCI", DbType.AnsiString, 60, kycjuridico.propositorelacioncomercial)
                                .AddParameter("MONT_PRIMA", DbType.Decimal, 20, kycjuridico.montoprima)
                                .AddParameter("TIP_PRIMA", DbType.AnsiString, 60, kycjuridico.tipodeprima)
                                .AddParameter("COD_PERIOD", DbType.Decimal, 5, kycjuridico.periodicidad)
                                .AddParameter("COD_PERIOD_DESC", DbType.AnsiString, 10, kycjuridico.periodicidadDesc)
                                .AddParameter("MONT_VAL_ASEGU", DbType.Decimal, 20, kycjuridico.montoValorasegurado)
                                .AddParameter("COD_FORM_PAGO", DbType.Decimal, 5, kycjuridico.formadepagodelapoliza)
                                .AddParameter("COD_FORM_PAGO_DESC", DbType.AnsiString, 30, kycjuridico.formadepagodelapolizaDesc)
                                .AddParameter("COD_MEDIO_ENVIO", DbType.Decimal, 5, kycjuridico.mediodeenvio)
                                .AddParameter("COD_MEDIO_ENVIO_DESC", DbType.AnsiString, 25, kycjuridico.mediodeenvioDesc)
                                .AddParameter("CORRESPON_ESPECIFI", DbType.AnsiString, 60, kycjuridico.especifique)
                                .AddParameter("NUM_TIN", DbType.AnsiString, 20, kycjuridico.numeroTIN)
                                .AddParameter("NUM_EXTRANJERO", DbType.AnsiString, 20, kycjuridico.numeroExt)
                                .AddParameter("SENAS_DOMIC_EXTRAN", DbType.AnsiString, 80, kycjuridico.otrassenasFATCA)
                                .AddParameter("GREEN_CARD", DbType.Decimal, 5, kycjuridico.greencard)
                                .AddParameter("IDENTI_EIN", DbType.Decimal, 5, kycjuridico.identificacionEIN)
                                .AddParameter("CONTRI_USA", DbType.Decimal, 5, kycjuridico.contribuyenteUSA)
                                .AddParameter("POSEE_DOMIC_EXTRAN", DbType.Decimal, 25, kycjuridico.domicilioExtranjero)
                                .AddParameter("PAIS_DOMIC", DbType.Decimal, 25, kycjuridico.paisDomicilio)
                                .AddParameter("POSEE_TEL_EXTRAN", DbType.Decimal, 25, kycjuridico.poseeTelefonoExtranjero)
                                .AddParameter("APORT_XML_FATCA", DbType.Decimal, 5, kycjuridico.aportaXMLFATCA)
                                .AddParameter("ATRI_CANAL_ING", DbType.Decimal, 5, kycjuridico.atributocanaldeingreso)
                                .AddParameter("VAL_CANAL_ING", DbType.Decimal, 5, kycjuridico.valorcanalingreso)
                                .AddParameter("COD_ACT_ECONOMICA", DbType.Decimal, 10, kycjuridico.actividadEconomica)
                                .AddParameter("COD_ACT_ECONOMICA_REP", DbType.Decimal, 10, kycjuridico.actividadEconomicaRep)
                                .AddParameter("NUM_IDENTIFI", DbType.String, 25, id)
                                .Execute(connection, "Research");
            }

            return 0;

		}

		/// <summary>
		/// Elimina un registro en la tabla PolicyProposal por medio de su clave primaria.
		/// </summary>
		/// <param name="id">Identificación única de la solcitud.</param>
		/// <param name="companyId">Identificación de la compañía propietaria.</param>
		/// <param name="connection">Instancia de una conexión compartida</param>
		/// <returns>Cantidad de registros eliminados.</returns>
		public static int Delete(int id, int companyId, IDbConnection connection = null)
		{
			return Database.Delete("DELETE FROM KYCPERSONA " +
									"WHERE NUM_IDENTIFI=:Id")
								.AddParameter("Id", DbType.Decimal, 9, id)
								.Execute(connection, "Research");
		}

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla KycPersona por medio de su clave primaria.
        /// </summary>
        /// <param name="Num_identificacion">Identificación única de la solcitud.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string Num_identificacion,string type, IDbConnection connection = null)
		{
			if(type == "persona")
			{
                return (int)Database.Select("SELECT COUNT(NUM_IDENTIFI) " +
                                          "FROM KYCPERSONA " +
                                         "WHERE REPLACE (NUM_IDENTIFI,'-','')=:Id")
                               .AddParameter("Id", DbType.AnsiString, 15, Num_identificacion)
                               .QueryScalar<Decimal>(connection, "Research");
            }
            if (type == "juridico")
            {
                return (int)Database.Select("SELECT COUNT(NUM_IDENTIFI) " +
                                          "FROM KYCJURIDICO " +
                                         "WHERE REPLACE (NUM_IDENTIFI,'-','')=:Id")
                               .AddParameter("Id", DbType.AnsiString, 15, Num_identificacion)
                               .QueryScalar<Decimal>(connection, "Research");
            }
            return 0;
		}

		/// <summary>
		/// Convierte una fila de un 'DataReader' a un clase de tipo 'Kycpersona'.
		/// </summary>
		/// <param name="reader">DataReader</param>
		/// <param name="item">Instancia pre creada</param>
		/// <returns>Instancia con la información de la fila del 'DataReader'</returns>
		public static Kycpersona DataReaderToKycpersona(System.Data.IDataReader reader, Kycpersona item = null)
		{

			if (item == null)
			{
				item = new Kycpersona();
			}

			item.numidentificacion = reader.StringValue("NUM_IDENTIFI");
			item.nombrePer = reader.StringValue("NOMBRE");
            item.primerapellidoPer = reader.StringValue("APELLIDO1");
            item.segundoapellidoPer = reader.StringValue("APELLIDO2");
            item.codigodeclientePer = reader.StringValue("COD_CLIENTE");
            item.numidentificaciontipo = reader.IntegerValue("COD_TIP_IDENTIFI");
            item.fechadecaducidadPer = reader.DateTimeValue("FECHA_CADUCIDAD");
            item.nacionalidadPer = reader.IntegerValue("COD_NACIONALI");
            item.fechadenacimientoPer = reader.DateTimeValue("FECHA_NACI");
            item.paisdenacimientoPer = reader.IntegerValue("COD_PAIS_NACI");
            item.profesionPer = reader.IntegerValue("COD_PROFESION");
            item.estadocivilPer = reader.IntegerValue("COD_ESTAD_CIVIL");
            item.sexoPer = reader.IntegerValue("COD_SEXO");
            item.telefonoresidenciaPer = reader.StringValue("TELF_RESIDEN");
            item.telefonocelularPer = reader.StringValue("TELF_CELULAR");
            item.faxPer = reader.StringValue("FAX_PER");
            item.apartadopostalPer = reader.StringValue("APARTADO_POST_PER");
            item.correoelectronicoPer = reader.StringValue("CORREO_ELEC_PER");
            item.domiciliopermanenteCod_pais = reader.StringValue("COD_DOMIC_PERMAN_PAIS");
            item.domiciliopermanenteCod_estado = reader.IntegerValue("COD_DOMIC_PERMAN_PROV");
            item.domiciliopermanenteCod_prov = reader.IntegerValue("COD_DOMIC_PERMAN_CANT");
            item.domiciliopermanenteCod_localidad = reader.IntegerValue("COD_DOMIC_PERMAN_DIST");
            item.domiciliopermanenteDireccionexacta = reader.StringValue("DOMIC_PERMAN_DIREC_EXAT_PER");
			item.OcupacionPer = reader.IntegerValue("COD_OCUP_PER");
            item.nombreempresaPer = reader.StringValue("NOM_EMPRES");
            item.actividadempresaPer = reader.StringValue("ACTIVI_EMPRES");
            item.cargoempresaPer = reader.StringValue("CARGO_EMPRES");
            item.telefonoempresaPer = reader.StringValue("TELF_EMPRES");
            item.faxempresaPer = reader.StringValue("FAX_EMPRES");
            item.domiciliocomercialCod_pais = reader.StringValue("COD_DOMICI_COME_PAIS");
            item.domiciliocomercialCod_estado = reader.IntegerValue("COD_DOMICI_COME_PROV");
            item.domiciliocomercialCod_prov = reader.IntegerValue("COD_DOMICI_COME_CANT");
            item.domiciliocomercialCod_localidad = reader.IntegerValue("COD_DOMICI_COME_DIST");
            item.domiciliocomercialDireccionexacta = reader.StringValue("DOMICI_COME_DIREC_EXAT");
            item.correspondenciaOrigendelosfondos = reader.StringValue("CORRE_ORIGIN_FONDO");
            item.paismayoractividad = reader.StringValue("PAIS_MAX_ACTIVI");
            item.ingresomensualestimado = reader.IntegerValue("INGRE_MENS");
            item.fondospormivilizar = reader.IntegerValue("COD_FONDOSMOV");
            item.actividadesart15 = reader.IntegerValue("COD_ACTIVI_ART15");
            item.activoscorresponden = reader.IntegerValue("COD_ACTIVO_CORRE");
            item.pepcargo = reader.IntegerValue("COD_PEP_CARGO");
            item.pepduracion = reader.StringValue("PEP_DURACION");
            item.peprelacion = reader.IntegerValue("COD_PEP_RELACION");
            item.peptiporelacion = reader.StringValue("PEP_TIP_RELACION");
            item.propositorelacioncomercial = reader.StringValue("PROP_RELA_COMERCI");
            item.montoprima = reader.IntegerValue("MONT_PRIMA");
            item.tipodeprima = reader.StringValue("TIP_PRIMA");
            item.periodicidad = reader.IntegerValue("COD_PERIOD");
            item.montoValorasegurado = reader.IntegerValue("MONT_VAL_ASEGU");
            item.formadepagodelapoliza = reader.IntegerValue("COD_FORM_PAGO");
            item.mediodeenvio = reader.IntegerValue("COD_MEDIO_ENVIO");
            item.especifique = reader.StringValue("CORRESPON_ESPECIFI");
            item.numeroTIN = reader.StringValue("NUM_TIN");
            item.numeroExt = reader.StringValue("NUM_EXTRANJERO");
            item.otrassenasFATCA = reader.StringValue("SENAS_DOMIC_EXTRAN");
            item.greencard = reader.IntegerValue("GREEN_CARD");
            item.identificacionEIN = reader.IntegerValue("IDENTI_EIN");
            item.contribuyenteUSA = reader.IntegerValue("CONTRI_USA");
            item.domicilioExtranjero = reader.IntegerValue("POSEE_DOMIC_EXTRAN");
            item.paisDomicilio = reader.IntegerValue("PAIS_DOMIC");
            item.poseeTelefonoExtranjero = reader.IntegerValue("POSEE_TEL_EXTRAN");
            item.aportaXMLFATCA = reader.IntegerValue("APORT_XML_FATCA");
            item.atributocanaldeingreso = reader.IntegerValue("ATRI_CANAL_ING");
            item.valorcanalingreso = reader.IntegerValue("VAL_CANAL_ING");
            item.actividadEconomica = reader.IntegerValue("COD_ACT_ECONOMICA");

            return item;
		}
        /// <summary>
		/// Convierte una fila de un 'DataReader' a un clase de tipo 'Kycjuridico'.
		/// </summary>
		/// <param name="reader">DataReader</param>
		/// <param name="item">Instancia pre creada</param>
		/// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static KycJuridico DataReaderToKycJuridico(System.Data.IDataReader reader, KycJuridico item = null)
        {
            

            if (item == null)
            {
                item = new KycJuridico();
            }

            item.numidentificacion = reader.StringValue("NUM_IDENTIFI");
            item.nombrecomercialJur = reader.StringValue("NOM_COMERCIAL");
            item.razonsocialJur = reader.StringValue("RAZON_SOCIAL");
            item.codigodeclienteJur = reader.StringValue("COD_CLIENTE");
            item.tipodesociedadJur = reader.StringValue("TIP_SOCIEDAD");
            item.tipodecedulajuridicaJur = reader.IntegerValue("TIP_IDENT_JUR");
            item.tipodecedulajuridicaJurDesc = reader.StringValue("TIP_IDENT_JUR_DESC");
            item.paisdeconstitucionJur = reader.IntegerValue("COD_PAIS_CONSTI");
            item.paisdeconstitucionJurDesc = reader.StringValue("COD_PAIS_CONSTI_DESC");
            item.fechadeconstitucionJur = reader.DateTimeValue("FECHA_CONSTI");
            item.actividaddelclientenaturalezadelnegocioJur = reader.StringValue("ACTI_EMPRESA");
            item.telefonoJur = reader.StringValue("TELF_JUR");
            item.faxJur = reader.StringValue("FAX_JUR");
            item.apartadopostalJur = reader.StringValue("APART_POSTAL_JUR");
            item.correoelectronicoJur = reader.StringValue("CORREO_ELECT_JUR");
            item.paginaWebJur = reader.StringValue("PAG_WEB");
            item.primerapellidoJur = reader.StringValue("APELLIDO1_REP");
            item.segundoapellidoJur = reader.StringValue("APELLIDO2_REP");
            item.nombrecompletoJur = reader.StringValue("NOMBRE_REP");
            item.posiciondentrodelaempresaJur = reader.StringValue("POSICI_ENMPRE");
            item.numerodeidentificacionJur = reader.StringValue("NUM_IDENTI_REP");
            item.tipodeidentificacionJur = reader.IntegerValue("COD_IDENTI_REP");
            item.tipodeidentificacionJurDesc = reader.StringValue("COD_IDENTI_REP_DESC");
            item.especifiqueJur = reader.StringValue("ESPEC_IDENTI_REP");
            item.fechadecaducidadJur = reader.DateTimeValue("FECHA_CADUCIDAD_REP");
            item.nacionalidadJur = reader.IntegerValue("COD_NACION_REP");
            item.nacionalidadJurDesc = reader.StringValue("COD_NACION_REP_DESC");
            item.fechadenacimientoJur = reader.DateTimeValue("FECHA_NACI_REP");
            item.paisdenacimientoJur = reader.IntegerValue("COD_PAIS_NACI_REP");
            item.paisdenacimientoJurDesc = reader.StringValue("COD_PAIS_NACI_REP_DESC");
            item.profesionJur = reader.IntegerValue("COD_PROFESION_REP");
            item.profesionJurDesc = reader.StringValue("COD_PROFESION_REP_DESC");
            item.estadocivilJur = reader.IntegerValue("COD_ESTAD_CIVIL_REP");
            item.estadocivilJurDesc = reader.StringValue("COD_ESTAD_CIVIL_REP_DESC");
            item.sexoJur = reader.IntegerValue("COD_SEXO_REP");
            item.sexoJurDesc = reader.StringValue("COD_SEXO_REP_DESC");
            item.telefonoresidenciaJur = reader.StringValue("TELF_RESI_REP");
            item.telefonocelularJur = reader.StringValue("TELF_CELU_REP");
            item.datosdelrepresentantelegalFaxJur = reader.StringValue("FAX_REP");
            item.datosdelrepresentantelegalApartadopostalJur = reader.StringValue("APARTA_POSTAL_REP");
            item.datosdelrepresentantelegalCorreoelectronicoJur = reader.StringValue("CORREO_ELECT_REP");
            item.participaciostring = reader.StringValue("PARTI_ACCIONA");
            item.domiciliopermanenteCod_pais = reader.StringValue("COD_DOMIC_PERMAN_PAIS");
            item.domiciliopermanenteCod_estado = reader.IntegerValue("COD_DOMIC_PERMAN_PROV");
            item.domiciliopermanenteCod_prov = reader.IntegerValue("COD_DOMIC_PERMAN_CANT");
            item.domiciliopermanenteCod_localidad = reader.IntegerValue("COD_DOMIC_PERMAN_DIST");
            item.domiciliopermanenteDireccionexacta = reader.StringValue("DOMIC_PERMAN_DIREC_EXAT_PER");
            item.domiciliocomercialCod_pais = reader.StringValue("COD_DOMICI_COME_PAIS");
            item.domiciliocomercialCod_estado = reader.IntegerValue("COD_DOMICI_COME_PROV");
            item.domiciliocomercialCod_prov = reader.IntegerValue("COD_DOMICI_COME_CANT");
            item.domiciliocomercialCod_localidad = reader.IntegerValue("COD_DOMICI_COME_DIST");
            item.domiciliocomercialDireccionexacta = reader.StringValue("DOMICI_COME_DIREC_EXAT");
            item.correspondenciaOrigendelosfondos = reader.StringValue("CORRE_ORIGIN_FONDO");
            item.paismayoractividad = reader.StringValue("PAIS_MAX_ACTIVI");
            item.ingresomensualestimado = reader.IntegerValue("INGRE_MENS");
            item.fondospormivilizar = reader.IntegerValue("COD_FONDOSMOV");
            item.actividadesart15 = reader.IntegerValue("COD_ACTIVI_ART15");
            item.activoscorresponden = reader.IntegerValue("COD_ACTIVO_CORRE");
            item.pepcargo = reader.IntegerValue("COD_PEP_CARGO");
            item.pepduracion = reader.StringValue("PEP_DURACION");
            item.peprelacion = reader.IntegerValue("COD_PEP_RELACION");
            item.peptiporelacion = reader.StringValue("PEP_TIP_RELACION");
            item.propositorelacioncomercial = reader.StringValue("PROP_RELA_COMERCI");
            item.montoprima = reader.IntegerValue("MONT_PRIMA");
            item.tipodeprima = reader.StringValue("TIP_PRIMA");
            item.periodicidad = reader.IntegerValue("COD_PERIOD");
            item.montoValorasegurado = reader.IntegerValue("MONT_VAL_ASEGU");
            item.formadepagodelapoliza = reader.IntegerValue("COD_FORM_PAGO");
            item.mediodeenvio = reader.IntegerValue("COD_MEDIO_ENVIO");
            item.especifique = reader.StringValue("CORRESPON_ESPECIFI");
            item.numeroTIN = reader.StringValue("NUM_TIN");
            item.numeroExt = reader.StringValue("NUM_EXTRANJERO");
            item.otrassenasFATCA = reader.StringValue("SENAS_DOMIC_EXTRAN");
            item.greencard = reader.IntegerValue("GREEN_CARD");
            item.identificacionEIN = reader.IntegerValue("IDENTI_EIN");
            item.contribuyenteUSA = reader.IntegerValue("CONTRI_USA");
            item.domicilioExtranjero = reader.IntegerValue("POSEE_DOMIC_EXTRAN");
            item.paisDomicilio = reader.IntegerValue("PAIS_DOMIC");
            item.poseeTelefonoExtranjero = reader.IntegerValue("POSEE_TEL_EXTRAN");
            item.aportaXMLFATCA = reader.IntegerValue("APORT_XML_FATCA");
            item.atributocanaldeingreso = reader.IntegerValue("ATRI_CANAL_ING");
            item.valorcanalingreso = reader.IntegerValue("VAL_CANAL_ING");
            item.actividadEconomica = reader.IntegerValue("COD_ACT_ECONOMICA");
            item.actividadEconomicaRep = reader.IntegerValue("COD_ACT_ECONOMICA_REP");

            return item;
        }

        //public static string ParticipacionConvert(List<Participador_Accionario> ListaParticipadores)
        //{
        //    List<string> ListPA = new List<string>();
        //    string[] arrayPA = { };
        //    foreach (Participador_Accionario participador in ListaParticipadores)
        //    {
        //        ListPA.Add("{\"participacionaccionariaNombrecompletoJur\": \"" + participador.participacionaccionariaNombrecompletoJur
        //    + "\", \"porcentajedeparticipacionJur\": " + participador.porcentajedeparticipacionJur
        //    + ", \"participacionaccionariaJurId\": \"" + participador.participacionaccionariaJurId
        //    + "\", \"participacionaccionariaNumerodeidentificacionJur\": \"" + participador.participacionaccionariaNumerodeidentificacionJur
        //    + "\", \"participacionaccionariaTipodeidentificacionJur\": " + participador.participacionaccionariaTipodeidentificacionJur
        //    + ", \"participacionaccionariaTipodeidentificacionJurDesc\": \"" + participador.participacionaccionariaTipodeidentificacionJurDesc
        //    + "\", \"participacionaccionariaSexoJur\": " + participador.participacionaccionariaSexoJur
        //    + ", \"participacionaccionariaSexoJurDesc\": \"" + participador.participacionaccionariaSexoJurDesc
        //    + "\", \"participacionaccionariaFechadenacimientoJur\": \"" + participador.participacionaccionariaFechadenacimientoJur.ToString("yyyy-MM-dd")
        //    + "\", \"participacionaccionariaProfesionJur\": " + participador.participacionaccionariaProfesionJur
        //    + ", \"participacionaccionariaProfesionJurDesc\": \"" + participador.participacionaccionariaProfesionJurDesc
        //    + "\", \"participacionaccionariaPaisdenacimientoJur\": " + participador.participacionaccionariaPaisdenacimientoJur
        //    + ", \"participacionaccionariaPaisdenacimientoJurDesc\": \"" + participador.participacionaccionariaPaisdenacimientoJurDesc
        //    + "\", \"participacionaccionariaEstadocivilJur\": " + participador.participacionaccionariaEstadocivilJur
        //    + ", \"participacionaccionariaEstadocivilJurDesc\": \"" + participador.participacionaccionariaEstadocivilJurDesc
        //    + "\"}");

        //    }
        //    arrayPA = ListPA.ToArray();
        //    string Liststring = String.Join(",", arrayPA);
        //    Liststring = "[" + Liststring + "]";

        //    return Liststring;
        //}

    }

}
