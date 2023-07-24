var app = app || {};

app.kycpersona = (function () {

    let setupData = null;
    let changedCallback = null;
    let acceptCallback = null;

    function Setup(data) {
        app.core.Lookups(['Pais.nacionalidadPer', 'Pais.paisdenacimientoPer', 'TRON_G1000100.profesionPer', 'CivilStatus.estadocivilPer', 'Gender.sexoPer', 'Paises.cod_paisPer', 'Provincias.cod_estadoPer', 'Paises.domiciliocomercialCod_paisPer', 'Provincias.domiciliocomercialCod_estadoPer', 'Pais.paisDomicilioPer'],
            function () {
                setupData = data;
                MapObjectToInput(data);
                app.core.Get(app.setting.apipath + 'v1/KYC/ActEco')
                    .done(function (data, textStatus, jqXHR) {
                        for (a in data) {
                            $('select#Act_Economica').append($('<option />').val(data[a].CodigoActividadEconomica).text(data[a].Descripcion));
                        }

                        app.ui.SetDropDownNumericValue('#Act_Economica', setupData.actividadEconomica, true);

                    });

            }, `cod_pais=CRI`);


        // Dependencies events
        $('#cod_estadoPer').on('change', function () {
            var pais = $('select#cod_paisPer').val();
            app.core.LookupDependency($('select#cod_estadoPer').val(), 'cod_provPer', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
        });
        $('#cod_provPer').on('change', function () {
            var pais = $('select#cod_paisPer').val();
            app.core.LookupDependency($('select#cod_provPer').val(), 'cod_localidadPer', 'Distritos', '', null, true, null, `cod_pais=${pais}:cod_prov=`);
        });

        $('#domiciliocomercialCod_estadoPer').on('change', function () {
            var pais = $('select#domiciliocomercialCod_paisPer').val();
            app.core.LookupDependency($('select#domiciliocomercialCod_estadoPer').val(), 'domiciliocomercialCod_provPer', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
        });
        $('#domiciliocomercialCod_provPer').on('change', function () {
            var pais = $('select#domiciliocomercialCod_paisPer').val();
            app.core.LookupDependency($('select#domiciliocomercialCod_provPer').val(), 'domiciliocomercialCod_localidadPer', 'Distritos', '', null, false, null, `cod_pais=${pais}:cod_prov=`);
        });

        $("#paisDomicilioPer")

    };

    function MapInputToObject() {
        var data = {
            //Datos Generales
            primerapellidoPer: $('#primerapellidoPer').val(),
            segundoapellidoPer: $('#segundoapellidoPer').val(),
            nombrePer: $('#nombrePer').val(),
            codigodeclientePer: $('#codigodeclientePer').val(),
            numidentificacion: $('#numidentificacion').val(),
            numidentificaciontipo: app.ui.GetRadioNumericValue('numidentificaciontipo'),
            numidentificaciontipoDesc: app.ui.GetRadioSelectedText('numidentificaciontipo'),
            fechadecaducidadPer: app.ui.GetDateValue('#fechadecaducidadPer'),
            nacionalidadPer: app.ui.GetDropDownNumericValue('#nacionalidadPer'),
            nacionalidadPerDesc: app.ui.GetDropDownSelectedText('#nacionalidadPer'),
            fechadenacimientoPer: app.ui.GetDateValue('#fechadenacimientoPer'),
            paisdenacimientoPer: app.ui.GetDropDownNumericValue('#paisdenacimientoPer'),
            paisdenacimientoPerDesc: app.ui.GetDropDownSelectedText('#paisdenacimientoPer'),
            profesionPer: app.ui.GetDropDownNumericValue('#profesionPer'),
            profesionPerDesc: app.ui.GetDropDownSelectedText('#profesionPer'),
            estadocivilPer: app.ui.GetDropDownNumericValue('#estadocivilPer'),
            estadocivilPerDesc: app.ui.GetDropDownSelectedText('#estadocivilPer'),
            sexoPer: app.ui.GetDropDownNumericValue('#sexoPer'),
            sexoPerDesc: app.ui.GetDropDownSelectedText('#sexoPer'),
            telefonoresidenciaPer: $('#telefonoresidenciaPer').val(),
            telefonocelularPer: $('#telefonocelularPer').val(),
            faxPer: $('#faxPer').val(),
            apartadopostalPer: $('#apartadopostalPer').val(),
            correoelectronicoPer: $('#correoelectronicoPer').val(),

            //Domicilio permanente
            domiciliopermanenteCod_pais: app.ui.GetDropDownStringValue('#cod_paisPer'),
            domiciliopermanenteCod_paisDesc: app.ui.GetDropDownSelectedText('#cod_paisPer'),
            domiciliopermanenteCod_estado: app.ui.GetDropDownNumericValue('#cod_estadoPer'),
            domiciliopermanenteCod_estadoDesc: app.ui.GetDropDownSelectedText('#cod_estadoPer'),
            domiciliopermanenteCod_prov: app.ui.GetDropDownNumericValue('#cod_provPer'),
            domiciliopermanenteCod_provDesc: app.ui.GetDropDownSelectedText('#cod_provPer'),
            domiciliopermanenteCod_localidad: app.ui.GetDropDownNumericValue('#cod_localidadPer'),
            domiciliopermanenteCod_localidadDesc: app.ui.GetDropDownSelectedText('#cod_localidadPer'),
            domiciliopermanenteDireccionexacta: $('#direccionexactaPer').val(),

            //Ocupación o actividad actual
            OcupacionPer: app.ui.GetRadioNumericValue('OcupacionPer'),
            OcupacionPerDesc: app.ui.GetRadioSelectedText('OcupacionPer'),
            fuenteIngresosPer: $('#fuenteIngresosPer').val(),

            //Datos de la empresa o lugar que genera sus ingresos en caso de ser independiente
            nombreempresaPer: $('#nombreempresaPer').val(),
            actividadempresaPer: $('#actividadempresaPer').val(),
            cargoempresaPer: $('#cargoempresaPer').val(),
            telefonoempresaPer: $('#telefonoempresaPer').val(),
            faxempresaPer: $('#faxempresaPer').val(),

            //Domicilio comercial
            domiciliocomercialCod_pais: app.ui.GetDropDownStringValue('#domiciliocomercialCod_paisPer'),
            domiciliocomercialCod_paisDesc: app.ui.GetDropDownSelectedText('#domiciliocomercialCod_paisPer'),
            domiciliocomercialCod_estado: app.ui.GetDropDownNumericValue('#domiciliocomercialCod_estadoPer'),
            domiciliocomercialCod_estadoDesc: app.ui.GetDropDownSelectedText('#domiciliocomercialCod_estadoPer'),
            domiciliocomercialCod_prov: app.ui.GetDropDownNumericValue('#domiciliocomercialCod_provPer'),
            domiciliocomercialCod_provDesc: app.ui.GetDropDownSelectedText('#domiciliocomercialCod_provPer'),
            domiciliocomercialCod_localidad: app.ui.GetDropDownNumericValue('#domiciliocomercialCod_localidadPer'),
            domiciliocomercialCod_localidadDesc: app.ui.GetDropDownSelectedText('#domiciliocomercialCod_localidadPer'),
            domiciliocomercialDireccionexacta: $('#domiciliocomercialDireccionexactaPer').val(),

            //Origen de los fondos
            actividadEconomica: app.ui.GetDropDownNumericValue('#Act_Economica'),
            Desc_actividadEconomica: "",
            correspondenciaOrigendelosfondos: $('#correspondenciaOrigendelosfondosPer').val(),
            paismayoractividad: $('#paismayoractividadPer').val(),
            ingresomensualestimado: app.ui.GetNumericValue('#ingresomensualestimadoPer'),
            fondospormivilizar: app.ui.GetRadioNumericValue('fondospormivilizarPer'),
            fondospormivilizarDesc: app.ui.GetRadioSelectedText('fondospormivilizarPer'),
            actividadesart15: app.ui.GetRadioNumericValue('actividadesart15Per'),
            actividadesart15Desc: app.ui.GetRadioSelectedText('actividadesart15Per'),

            //Tipos de activos
            activoscorresponden: app.ui.GetRadioNumericValue('activoscorrespondenPer'),
            activoscorrespondenDesc: app.ui.GetRadioSelectedText('activoscorrespondenPer'),



            //PEPs
            pepcargo: app.ui.GetRadioNumericValue('pepcargoPer'),
            pepcargoDesc: app.ui.GetRadioSelectedText('pepcargoPer'),
            pepduracion: $('#pepduracionPer').val(),
            peprelacion: app.ui.GetRadioNumericValue('peprelacionPer'),
            peprelacionDesc: app.ui.GetRadioSelectedText('peprelacionPer'),
            peptiporelacion: $('#peptiporelacionPer').val(),

            //FATCA
            greencard: app.ui.GetRadioNumericValue('greencardPer') == NaN ? 2 : 1,
            identificacionEIN: app.ui.GetRadioNumericValue('identificacionEINPer') == NaN ? 2 : 1,
            numeroTIN: $('#numeroTINPer').val(),
            numeroExt: $('#numeroExtPer').val(),
            otrassenasFATCA: $('#otrassenasFATCAPer').val(),
            contribuyenteUSA: app.ui.GetRadioNumericValue('contribuyenteUSAPer') == NaN ? 2 : 1,
            domicilioExtranjero: app.ui.GetRadioNumericValue('domicilioExtranjeroPer') == NaN ? 2 : 1,
            paisDomicilio: app.ui.GetDropDownNumericValue('#paisDomicilioPer') == NaN ? 0 : app.ui.GetDropDownNumericValue('#paisDomicilioPer'),
            poseeTelefonoExtranjero: app.ui.GetRadioNumericValue('poseeTelefonoExtranjeroPer') == NaN ? 2 : 1,
            aportaXMLFATCA: app.ui.GetRadioNumericValue('aportaXMLFATCAPer') == NaN ? 2 : 1,

            //Otros Atributos
            atributocanaldeingreso: app.ui.GetDropDownNumericValue('#atributocanaldeingresoPer') == NaN ? 1 : 1,
            valorcanalingreso: app.ui.GetDropDownNumericValue('#valorcanalingresoPer') == 0 ? 1 : app.ui.GetDropDownNumericValue('#valorcanalingresoPer'),
            valorcanalingresoDesc: app.ui.GetDropDownSelectedText('#valorcanalingresoPer') == "" ? "No registra" : app.ui.GetDropDownSelectedText('#valorcanalingresoPer'),


            //Describcion de la poliza
            propositorelacioncomercial: $('#propositorelacioncomercialPer').val(),
            montoprima: app.ui.GetNumericValue('#montoprimaPer'),
            tipodeprima: $('#tipodeprimaPer').val(),
            periodicidad: app.ui.GetRadioNumericValue('periodicidadPer'),
            periodicidadDesc: app.ui.GetRadioSelectedText('periodicidadPer'),
            montoValorasegurado: app.ui.GetNumericValue('#montoValoraseguradoPer'),
            formadepagodelapoliza: app.ui.GetRadioNumericValue('formadepagodelapolizaPer'),
            formadepagodelapolizaDesc: app.ui.GetRadioSelectedText('formadepagodelapolizaPer'),


            //Correspondencia
            mediodeenvio: app.ui.GetRadioNumericValue('mediodeenvioPer'),
            mediodeenvioDesc: app.ui.GetRadioSelectedText('mediodeenvioPer'),
            especifique: $('#especifiquePer').val()
        };
        return data;
    };

    function MapObjectToInput(data) {

        if (data != null) {
            document.querySelectorAll('#dynamic [type="radio"]').forEach((x) => x.checked = false);
            $('#primerapellidoPer').val(data.primerapellidoPer);
            $('#segundoapellidoPer').val(data.segundoapellidoPer);
            $('#nombrePer').val(data.nombrePer);
            $('#codigodeclientePer').val(data.codigodeclientePer);
            $('#numidentificacion').val(data.numidentificacion);
            app.ui.SetRadioNumericValue('numidentificaciontipo', data.numidentificaciontipo);
            app.ui.SetDateValue('#fechadecaducidadPer', data.fechadecaducidadPer);
            app.ui.SetDropDownNumericValue('#nacionalidadPer', data.nacionalidadPer, true);
            app.ui.SetDateValue('#fechadenacimientoPer', data.fechadenacimientoPer);
            app.ui.SetDropDownNumericValue('#paisdenacimientoPer', data.paisdenacimientoPer, true);
            app.ui.SetDropDownNumericValue('#profesionPer', data.profesionPer, true);

            app.ui.SetDropDownNumericValue('#Act_Economica', data.actividadEconomica, true);

            let value = data.estadocivilPer;
            if (value == 'C')
                value = '1';
            else if (value == 'D')
                value = '2';
            else if (value == 'S')
                value = '3';
            else if (value == 'V')
                value = '4';
            app.ui.SetDropDownNumericValue('#estadocivilPer', value, true);
            app.ui.SetDropDownNumericValue('#sexoPer', data.sexoPer, true);
            $('#telefonoresidenciaPer').val(data.telefonoresidenciaPer);
            $('#telefonocelularPer').val(data.telefonocelularPer);
            $('#faxPer').val(data.faxPer);
            $('#apartadopostalPer').val(data.apartadopostalPer);
            $('#correoelectronicoPer').val(data.correoelectronicoPer);
            app.ui.SetDropDownStringValue('#cod_paisPer', data.domiciliopermanenteCod_pais, true);
            app.ui.SetDropDownNumericValue('#cod_estadoPer', data.domiciliopermanenteCod_estado, true);
            app.core.LookupDependency(data.domiciliopermanenteCod_estado, 'cod_provPer', 'Cantones', '', data.domiciliopermanenteCod_prov, false, null, `cod_pais=${data.domiciliopermanenteCod_pais}:cod_estado=`);
            app.core.LookupDependency(data.domiciliopermanenteCod_prov, 'cod_localidadPer', 'Distritos', '', data.domiciliopermanenteCod_localidad, false, null, `cod_pais=${data.domiciliopermanenteCod_pais}:cod_prov=`);
            $('#direccionexactaPer').val(data.domiciliopermanenteDireccionexacta);
            app.ui.SetRadioNumericValue('OcupacionPer', data.OcupacionPer);
            $('#fuenteIngresosPer').val(data.fuenteIngresosPer);
            $('#nombreempresaPer').val(data.nombreempresaPer);
            $('#actividadempresaPer').val(data.actividadempresaPer);
            $('#cargoempresaPer').val(data.cargoempresaPer);
            $('#telefonoempresaPer').val(data.telefonoempresaPer);
            $('#faxempresaPer').val(data.faxempresaPer);
            app.ui.SetDropDownStringValue('#domiciliocomercialCod_paisPer', data.domiciliocomercialCod_pais, true);
            app.ui.SetDropDownNumericValue('#domiciliocomercialCod_estadoPer', data.domiciliocomercialCod_estado, true);
            app.core.LookupDependency(data.domiciliocomercialCod_estado, 'domiciliocomercialCod_provPer', 'Cantones', '', data.domiciliocomercialCod_prov, false, null, `cod_pais=${data.domiciliocomercialCod_pais}:cod_estado=`);
            app.core.LookupDependency(data.domiciliocomercialCod_prov, 'domiciliocomercialCod_localidadPer', 'Distritos', '', data.domiciliocomercialCod_localidad, false, null, `cod_pais=${data.domiciliocomercialCod_pais}:cod_prov=`);
            $('#domiciliocomercialDireccionexactaPer').val(data.domiciliocomercialDireccionexacta);
            $('#correspondenciaOrigendelosfondosPer').val(data.correspondenciaOrigendelosfondos);
            $('#paismayoractividadPer').val(data.paismayoractividad);
            app.ui.SetNumericValue('#ingresomensualestimadoPer', data.ingresomensualestimado);
            app.ui.SetRadioNumericValue('fondospormivilizarPer', data.fondospormivilizar);
            app.ui.SetRadioNumericValue('actividadesart15Per', data.actividadesart15);
            app.ui.SetRadioNumericValue('activoscorrespondenPer', data.activoscorresponden);

            app.ui.SetRadioNumericValue('greencardPer', data.greencard);
            app.ui.SetRadioNumericValue('identificacionEINPer', data.identificacionEIN);
            $('#numeroTINPer').val(data.numeroTIN);
            $('#numeroExtPer').val(data.numeroExt);
            $('#otrassenasFATCAPer').val(data.otrassenasFATCA);
            app.ui.SetRadioNumericValue('contribuyenteUSAPer', data.contribuyenteUSA);
            app.ui.SetRadioNumericValue('domicilioExtranjeroPer', data.domicilioExtranjero);
            app.ui.SetDropDownNumericValue('#paisDomicilioPer', data.paisDomicilio);
            app.ui.SetRadioNumericValue('poseeTelefonoExtranjeroPer', data.poseeTelefonoExtranjero);
            app.ui.SetRadioNumericValue('aportaXMLFATCAPer', data.aportaXMLFATCA);

            app.ui.SetDropDownNumericValue('#atributocanaldeingresoPer', data.atributocanaldeingreso);
            app.ui.SetDropDownNumericValue('#valorcanalingresoPer', data.valorcanalingreso);

            app.ui.SetRadioNumericValue('pepcargoPer', data.pepcargo);
            $("[name=pepcargoPer]").change();
            $('#pepduracionPer').val(data.pepduracion);
            app.ui.SetRadioNumericValue('peprelacionPer', data.peprelacion);
            $("[name=peprelacionPer]").change();
            $('#peptiporelacionPer').val(data.peptiporelacion);
            $('#propositorelacioncomercialPer').val(data.propositorelacioncomercial);
            app.ui.SetNumericValue('#montoprimaPer', data.montoprima);
            $('#tipodeprimaPer').val(data.tipodeprima);
            app.ui.SetRadioNumericValue('periodicidadPer', data.periodicidad);
            app.ui.SetNumericValue('#montoValoraseguradoPer', data.montoValorasegurado);
            app.ui.SetRadioNumericValue('formadepagodelapolizaPer', data.formadepagodelapoliza);
            app.ui.SetRadioNumericValue('mediodeenvioPer', data.mediodeenvio);
            $('#especifiquePer').val(data.especifique);
        }
    };

    function Mapdatatoinputs(data) {

    }

    function Controls_setup() {
        $('#fechadecaducidadPer_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechadenacimientoPer_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#telefonoresidenciaPer').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#telefonocelularPer').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#faxPer').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#telefonoempresaPer').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#faxempresaPer').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        new AutoNumeric('#ingresomensualestimadoPer', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoprimaPer', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoValoraseguradoPer', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });

    };

    function Controls_Events() {

        app.ui.DocumentNumberHandlerKYC('#numidentificacion', MapObjectToInput, undefined, "persona");

        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#kycpersonaPerEdtForm :input").change(function () {
            data_changed();
        });

        $('input:radio[name=poseeTelefonoExtranjeroPer]').change(function () {
            $('#numeroExtPer').prop("disabled", app.ui.GetRadioNumericValue('poseeTelefonoExtranjeroPer') === 2);
        });

        $('input:radio[name=domicilioExtranjeroPer]').change(function () {
            $('#paisDomicilioPer').prop("disabled", app.ui.GetRadioNumericValue('domicilioExtranjeroPer') === 2);
        });


        $('#kycpersonaPerEdtFormSave').click(function () {

            if (app.ui.IsValid('#kycpersonaPerEdtForm', false)) {
                app.ui.ButtonDoing('#kycpersonaPerEdtFormSave');
                acceptCallback(MapInputToObject());
                app.ui.ButtonDone('#kycpersonaPerEdtFormSave');
            }
            event.preventDefault();
        });


        //$('#kycpersonaPerEdtFormCancel').click(function () {
        //    app.ui.ButtonDoing('#kycpersonaPerEdtFormCancel');
        //    setTimeout(() => { app.ui.ButtonDone('#kycpersonaPerEdtFormCancel'); }, 3000);
        //    event.preventDefault();
        //});

    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
        if (app.ui.GetRadioNumericValue('pepcargoPer') === 1)
            $('.pepduracionPerVisible').removeClass('d-none');
        else
            $('.pepduracionPerVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('peprelacionPer') === 1)
            $('.peptiporelacionPerVisible').removeClass('d-none');
        else
            $('.peptiporelacionPerVisible').addClass('d-none');


        if (app.ui.GetRadioNumericValue('OcupacionPer') === 2)
            $('.empresaPerVisible').removeClass('d-none');
        else
            $('.empresaPerVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('OcupacionPer') === 3)
            $('.fuenteIngresosPerVisible').removeClass('d-none');
        else
            $('.fuenteIngresosPerVisible').addClass('d-none');
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#kycpersonaPerEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                primerapellidoPer: { required: true },
                segundoapellidoPer: { required: true },
                nombrePer: { required: true },
                numidentificacion: { required: true },
                numidentificaciontipo: { required: true },
                fechadecaducidadPer: { required: true },
                nacionalidadPer: { required: true },
                fechadenacimientoPer: { required: true },
                paisdenacimientoPer: { required: true },
                profesionPer: { required: true },
                estadocivilPer: { required: true },
                sexoPer: { required: true },
                correoelectronicoPer: { required: true, email: true },
                cod_paisPer: { required: true },
                cod_estadoPer: { required: true },
                cod_provPer: { required: true },
                cod_localidadPer: { required: true },
                direccionexactaPer: { required: true },
                OcupacionPer: { required: true },
                fuenteIngresosPer: { required: true },
                nombreempresaPer: { required: true },
                actividadempresaPer: { required: true },
                cargoempresaPer: { required: true },
                telefonoempresaPer: { required: true },
                faxempresaPer: { required: true },
                domiciliocomercialCod_paisPer: { required: true },
                domiciliocomercialCod_estadoPer: { required: true },
                domiciliocomercialCod_provPer: { required: true },
                domiciliocomercialCod_localidadPer: { required: true },
                domiciliocomercialDireccionexactaPer: { required: true },
                correspondenciaOrigendelosfondosPer: { required: true },
                paismayoractividadPer: { required: true },
                ingresomensualestimadoPer: { required: true },
                fondospormivilizarPer: { required: true },
                actividadesart15Per: { required: true },
                activoscorrespondenPer: { required: true },


                pepcargoPer: { required: true },
                pepduracionPer: { required: true },
                peprelacionPer: { required: true },
                peptiporelacionPer: { required: true },
                propositorelacioncomercialPer: { required: true },
                montoprimaPer: { required: true, Numeric: true },
                tipodeprimaPer: { required: true },
                periodicidadPer: { required: true },
                montoValoraseguradoPer: { required: true, Numeric: true },
                formadepagodelapolizaPer: { required: true },
                mediodeenvioPer: { required: true },
                especifiquePer: { required: true },
            },
            messages: {
                primerapellidoPer: { required: 'Debe indicar el Primer apellido' },
                segundoapellidoPer: { required: 'Debe indicar el Segundo apellido' },
                nombrePer: { required: 'Debe indicar el Nombre' },
                numidentificacion: { required: 'Debe indicar el Número de identificación' },
                numidentificaciontipo: { required: 'Debe indicar el Tipo de identificación' },
                fechadecaducidadPer: { required: 'Debe indicar el Fecha de caducidad' },
                nacionalidadPer: { required: 'Debe indicar el Nacionalidad' },
                fechadenacimientoPer: { required: 'Debe indicar el Fecha de nacimiento' },
                paisdenacimientoPer: { required: 'Debe indicar el País de nacimiento' },
                profesionPer: { required: 'Debe indicar el Profesión' },
                estadocivilPer: { required: 'Debe indicar el Estado civil' },
                sexoPer: { required: 'Debe indicar el Sexo' },
                correoelectronicoPer: { required: 'Debe indicar el Correo electrónico', email: 'Debe indicar un correo electrónico valido' },
                cod_paisPer: { required: 'Debe indicar el País' },
                cod_estadoPer: { required: 'Debe indicar el Provincia' },
                cod_provPer: { required: 'Debe indicar el Cantón' },
                cod_localidadPer: { required: 'Debe indicar el Distrito' },
                direccionexactaPer: { required: 'Debe indicar el Dirección exacta' },
                OcupacionPer: { required: 'Debe indicar el Indique su ocupación o actividad actual' },
                fuenteIngresosPer: { required: 'Debe indicar la fuente de los ingresos' },
                nombreempresaPer: { required: 'Debe indicar el Nombre de la empresa o negocio' },
                actividadempresaPer: { required: 'Debe indicar el Actividad de la empresa o negocio' },
                cargoempresaPer: { required: 'Debe indicar el Cargo que desempeña' },
                telefonoempresaPer: { required: 'Debe indicar el Teléfono' },
                faxempresaPer: { required: 'Debe indicar el Fax' },
                domiciliocomercialCod_paisPer: { required: 'Debe indicar el País' },
                domiciliocomercialCod_estadoPer: { required: 'Debe indicar el Provincia' },
                domiciliocomercialCod_provPer: { required: 'Debe indicar el Cantón' },
                domiciliocomercialCod_localidadPer: { required: 'Debe indicar el Distrito' },
                domiciliocomercialDireccionexactaPer: { required: 'Debe indicar el Dirección exacta' },
                correspondenciaOrigendelosfondosPer: { required: 'Debe indicar el Origen de los Fondos (¿De dónde provienen y en qué forma?)' },
                paismayoractividadPer: { required: 'Debe indicar el ¿En qué país desarrolla la mayoría de sus actividades económicas?' },
                ingresomensualestimadoPer: { required: 'Debe indicar el Ingreso mensual estimado' },
                fondospormivilizarPer: { required: 'Debe indicar el Los fondos por movilizar son propios o de terceros?' },
                actividadesart15Per: { required: 'Debe indicar el ¿Se desempeña entre las actividades citadas en el Artículo 15 de la Ley 8204 (manejo de fondos de terceros físicos o jurídicos)' },
                activoscorrespondenPer: { required: 'Debe indicar el La mayoría de sus activos corresponden a' },
                pepcargoPer: { required: 'Debe indicar el Manifiesta desempeñar o haber desempeñado algún cargo que implique funciones públicas destacadas en el país o en el extranjero' },
                pepduracionPer: { required: 'Debe indicar el En caso afirmativo, indique el período durante el cual desempeñó dichas funciones' },
                peprelacionPer: { required: 'Debe indicar el Manifiesta tener relación directa (consaguinidad) o indirecta (afinidad) con una persona expuesta políticamente (PEP)' },
                peptiporelacionPer: { required: 'Debe indicar el Detalle el tipo de relación' },
                propositorelacioncomercialPer: { required: 'Debe indicar el Propósito de relación comercial (Indicar el tipo de Seguro que está adquiriendo)' },
                montoprimaPer: { required: 'Debe indicar el Monto prima', Numeric: 'Debe indicar el Monto prima' },
                tipodeprimaPer: { required: 'Debe indicar el Tipo de prima' },
                periodicidadPer: { required: 'Debe indicar el Periodicidad' },
                montoValoraseguradoPer: { required: 'Debe indicar el Monto Valor asegurado', Numeric: 'Debe indicar el Monto Valor asegurado' },
                formadepagodelapolizaPer: { required: 'Debe indicar el Forma de pago de la póliza' },
                mediodeenvioPer: { required: 'Debe indicar el Favor indicar el medio por el cual desea que se le envíe información' },
                especifiquePer: { required: 'Debe indicar el Especifique' },
            }
        });
    };

    return {
        Init: function (data) {
            try {
                Controls_setup();
                Setup_Validations();

                Controls_Events();
                Setup(data);
                console.log("Inicio");
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Data: function () {
            return MapInputToObject();
        },
        Changed: function (callback) {
            changedCallback = callback;
        },
        IsValid: function (showResume) {
            return app.ui.IsValid('#kycpersonaPerEdtForm', false, showResume);
        },
        AcceptCallBack: function (callback) {
            acceptCallback = callback;
        },
        SetData: function (data) {
            if (data == null) {
                data = app.kycpersona.InitData(true);
            }
            else if (data != null || data != undefined) {
                setupData = data;
                MapObjectToInput(data);
            }
        },
        InitData: function (fill) {
            let InitKycpersona = {
                "primerapellidoPer": "",
                "segundoapellidoPer": "",
                "nombrePer": "",
                "codigodeclientePer": "",
                "numidentificacion": "",
                "numidentificaciontipo": 0,
                "fechadecaducidadPer": "0001-01-01T00:00:00",
                "nacionalidadPer": 0,
                "fechadenacimientoPer": "0001-01-01T00:00:00",
                "paisdenacimientoPer": 0,
                "profesionPer": 0,
                "actividadEconomica": 0,
                "estadocivilPer": 0,
                "sexoPer": 0,
                "telefonoresidenciaPer": "",
                "telefonocelularPer": "",
                "faxPer": "",
                "apartadopostalPer": "",
                "correoelectronicoPer": "",
                "domiciliopermanenteCod_pais": "CRI",
                "domiciliopermanenteCod_estado": 0,
                "domiciliopermanenteCod_prov": 0,
                "domiciliopermanenteCod_localidad": 0,
                "domiciliopermanenteDireccionexacta": "",
                "OcupacionPer": null,
                "fuenteIngresosPer": "",
                "nombreempresaPer": "",
                "actividadempresaPer": "",
                "cargoempresaPer": "",
                "telefonoempresaPer": "",
                "faxempresaPer": "",
                "domiciliocomercialCod_pais": "CRI",
                "domiciliocomercialCod_estado": 0,
                "domiciliocomercialCod_prov": 0,
                "domiciliocomercialCod_localidad": 0,
                "domiciliocomercialDireccionexacta": "",
                "correspondenciaOrigendelosfondos": "",
                "paismayoractividad": "",
                "ingresomensualestimado": 0,
                "fondospormivilizar": null,
                "actividadesart15": null,
                "activoscorresponden": null,
                "numeroTIN": "",
                "numeroExt": "",
                "otrassenasFATCA": "",
                "greencard": 0,
                "identificacionEIN": 0,
                "contribuyenteUSA": 0,
                "domicilioExtranjero": 0,
                "paisDomicilio": 0,
                "poseeTelefonoExtranjero": 0,
                "aportaXMLFATCA": 0,
                "valorcanalingreso": 1,
                "atributocanaldeingreso": 1,
                "pepcargo": null,
                "pepduracion": "",
                "peprelacion": null,
                "peptiporelacion": "",
                "propositorelacioncomercial": "",
                "montoprima": 0,
                "tipodeprima": "",
                "periodicidad": null,
                "montoValorasegurado": 0,
                "formadepagodelapoliza": null,
                "mediodeenvio": null,
                "especifique": ""
            };

            if (fill) {
                let mainHolder = $('#tercerosTbl').bootstrapTable('getData').filter(i => i.tipodetercero === "0");

                if (app.ui.IsDocumentNumberValid(mainHolder[0].DocumentNumberType, mainHolder[0].DocumentNumber)) {
                    var value = mainHolder[0].DocumentNumber.replace(/-/g, '');
                    app.core.Get(app.setting.apipath + 'v1/KYC/' + "persona" + "?id=" + value)
                        .done(function (data, textStatus, jqXHR) {
                            if (data != null) {
                                for (const a in InitKycpersona) {
                                    for (const b in data) {
                                        if (a == b) {
                                            InitKycpersona[a] = data[b]
                                        }
                                    }
                                }
                            }
                            else {

                                InitKycpersona.nacionalidadPer = 188;
                                InitKycpersona.paisdenacimientoPer = 188;
                            }

                            InitKycpersona.primerapellidoPer = mainHolder[0].apellido1;
                            InitKycpersona.segundoapellidoPer = mainHolder[0].apellido2;
                            InitKycpersona.nombrePer = mainHolder[0].nombre;
                            InitKycpersona.fechadenacimientoPer = mainHolder[0].fechadenacimiento;
                            InitKycpersona.correoelectronicoPer = mainHolder[0].correoelectronico;
                            InitKycpersona.sexoPer = mainHolder[0].tercerosMca_sexo;
                            InitKycpersona.numidentificacion = mainHolder[0].DocumentNumber;
                            InitKycpersona.numidentificaciontipo = mainHolder[0].DocumentNumberType;
                            InitKycpersona.estadocivilPer = mainHolder[0].estadoCivil;
                            InitKycpersona.telefonoresidenciaPer = mainHolder[0].numerodetelefono;

                            InitKycpersona.domiciliopermanenteCod_pais = mainHolder[0].cod_pais;
                            InitKycpersona.domiciliopermanenteCod_estado = mainHolder[0].TProvincia;
                            InitKycpersona.domiciliopermanenteCod_prov = mainHolder[0].TCanton;
                            InitKycpersona.domiciliopermanenteCod_localidad = mainHolder[0].TDistrito;
                            InitKycpersona.domiciliopermanenteDireccionexacta = mainHolder[0].otrasenas;

                            setupData = InitKycpersona;
                            MapObjectToInput(InitKycpersona);

                            return InitKycpersona;
                        })
                }
            }
            else {
                return InitKycpersona;
            }

        }
    };
})();