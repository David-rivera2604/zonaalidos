var app = app || {};

app.kycpersona = (function () {

    let setupData = null;
    let changedCallback = null;
    let acceptCallback = null;

    function Setup() {
        app.core.Lookups(['Pais.nacionalidadPer', 'Pais.paisdenacimientoPer', 'CivilStatus.estadocivilPer', 'Gender.sexoPer', 'Paises.cod_paisPer', 'Provincias.cod_estadoPer', 'Cantones.cod_provPer', 'Distritos.cod_localidadPer', 'Paises.domiciliocomercialCod_paisPer', 'Provincias.domiciliocomercialCod_estadoPer', 'Cantones.domiciliocomercialCod_provPer', 'Distritos.domiciliocomercialCod_localidadPer',],
            function () {
            }, `cod_pais=CRI`);
    };


    function MapInputToObject() {
        var data = {
            primerapellidoPer: $('#primerapellidoPer').val(),
            segundoapellidoPer: $('#segundoapellidoPer').val(),
            nombrePer: $('#nombrePer').val(),
            codigodeclientePer: $('#codigodeclientePer').val(),
            numerodeidentificacionPer: $('#numerodeidentificacionPer').val(),
            tipodeidentificacionPer: $('#tipodeidentificacionPer').val(),
            fechadecaducidadPer: app.ui.GetDateValue('#fechadecaducidadPer'),
            nacionalidadPer: app.ui.GetDropDownNumericValue('#nacionalidadPer'),
            fechadenacimientoPer: app.ui.GetDateValue('#fechadenacimientoPer'),
            paisdenacimientoPer: app.ui.GetDropDownNumericValue('#paisdenacimientoPer'),
            profesionPer: app.ui.GetDropDownNumericValue('#profesionPer'),
            estadocivilPer: app.ui.GetDropDownNumericValue('#estadocivilPer'),
            sexoPer: app.ui.GetDropDownNumericValue('#sexoPer'),
            telefonoresidenciaPer: $('#telefonoresidenciaPer').val(),
            telefonocelularPer: $('#telefonocelularPer').val(),
            faxPer: $('#faxPer').val(),
            apartadoPostalPer: $('#apartadoPostalPer').val(),
            correoelectronicoPer: $('#correoelectronicoPer').val(),
            cod_paisPer: app.ui.GetDropDownNumericValue('#cod_paisPer'),
            cod_estadoPer: app.ui.GetDropDownNumericValue('#cod_estadoPer'),
            cod_provPer: app.ui.GetDropDownNumericValue('#cod_provPer'),
            cod_localidadPer: app.ui.GetDropDownNumericValue('#cod_localidadPer'),
            direccionexactaPer: $('#direccionexactaPer').val(),
            OcupacionPer: app.ui.GetRadioNumericValue('OcupacionPer'),
            nombreempresaPer: $('#nombreempresaPer').val(),
            actividadempresaPer: $('#actividadempresaPer').val(),
            cargoempresaPer: $('#cargoempresaPer').val(),
            telefonoempresaPer: $('#telefonoempresaPer').val(),
            faxempresaPer: $('#faxempresaPer').val(),
            domiciliocomercialCod_paisPer: app.ui.GetDropDownNumericValue('#domiciliocomercialCod_paisPer'),
            domiciliocomercialCod_estadoPer: app.ui.GetDropDownNumericValue('#domiciliocomercialCod_estadoPer'),
            domiciliocomercialCod_provPer: app.ui.GetDropDownNumericValue('#domiciliocomercialCod_provPer'),
            domiciliocomercialCod_localidadPer: app.ui.GetDropDownNumericValue('#domiciliocomercialCod_localidadPer'),
            domiciliocomercialDireccionexactaPer: $('#domiciliocomercialDireccionexactaPer').val(),
            correspondenciaOrigendelosfondosPer: $('#correspondenciaOrigendelosfondosPer').val(),
            paismayoractividadPer: $('#paismayoractividadPer').val(),
            ingresomensualestimadoPer: app.ui.GetNumericValue('#ingresomensualestimadoPer'),
            fondospormivilizarPer: app.ui.GetRadioNumericValue('fondospormivilizarPer'),
            actividadesart15Per: app.ui.GetRadioNumericValue('actividadesart15Per'),
            activoscorrespondenPer: app.ui.GetRadioNumericValue('activoscorrespondenPer'),
            pepcargoPer: app.ui.GetRadioNumericValue('pepcargoPer'),
            pepduracionPer: $('#pepduracionPer').val(),
            peprelacionPer: app.ui.GetRadioNumericValue('peprelacionPer'),
            peptiporelacionPer: $('#peptiporelacionPer').val(),
            propositorelacioncomercialPer: $('#propositorelacioncomercialPer').val(),
            montoprimaPer: app.ui.GetNumericValue('#montoprimaPer'),
            tipodeprimaPer: $('#tipodeprimaPer').val(),
            periodicidadPer: app.ui.GetRadioNumericValue('periodicidadPer'),
            montoValoraseguradoPer: app.ui.GetNumericValue('#montoValoraseguradoPer'),
            formadepagodelapolizaPer: app.ui.GetRadioNumericValue('formadepagodelapolizaPer'),
            mediodeenvioPer: app.ui.GetRadioNumericValue('mediodeenvioPer'),
            especifiquePer: $('#especifiquePer').val(),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#primerapellidoPer').val(data.primerapellidoPer);
        $('#segundoapellidoPer').val(data.segundoapellidoPer);
        $('#nombrePer').val(data.nombrePer);
        $('#codigodeclientePer').val(data.codigodeclientePer);
        $('#numerodeidentificacionPer').val(data.numerodeidentificacionPer);
        $('#tipodeidentificacionPer').val(data.tipodeidentificacionPer);
        app.ui.SetDateValue('#fechadecaducidadPer', data.fechadecaducidadPer);
        $('#nacionalidadPer').val(data.nacionalidadPer);
        app.ui.SetDropDownNumericValue('#nacionalidadPer', data.nacionalidadPer, true);
        app.ui.SetDateValue('#fechadenacimientoPer', data.fechadenacimientoPer);
        $('#paisdenacimientoPer').val(data.paisdenacimientoPer);
        app.ui.SetDropDownNumericValue('#paisdenacimientoPer', data.paisdenacimientoPer, true);
        $('#profesionPer').val(data.profesionPer);
        app.ui.SetDropDownNumericValue('#profesionPer', data.profesionPer, true);
        $('#estadocivilPer').val(data.estadocivilPer);
        app.ui.SetDropDownNumericValue('#estadocivilPer', data.estadocivilPer, true);
        $('#sexoPer').val(data.sexoPer);
        app.ui.SetDropDownNumericValue('#sexoPer', data.sexoPer, true);
        $('#telefonoresidenciaPer').val(data.telefonoresidenciaPer);
        $('#telefonocelularPer').val(data.telefonocelularPer);
        $('#faxPer').val(data.faxPer);
        $('#apartadoPostalPer').val(data.apartadoPostalPer);
        $('#correoelectronicoPer').val(data.correoelectronicoPer);
        $('#cod_paisPer').val(data.cod_paisPer);
        app.ui.SetDropDownNumericValue('#cod_paisPer', data.cod_paisPer, true);
        $('#cod_estadoPer').val(data.cod_estadoPer);
        app.ui.SetDropDownNumericValue('#cod_estadoPer', data.cod_estadoPer, true);
        $('#cod_provPer').val(data.cod_provPer);
        app.ui.SetDropDownNumericValue('#cod_provPer', data.cod_provPer, true);
        $('#cod_localidadPer').val(data.cod_localidadPer);
        app.ui.SetDropDownNumericValue('#cod_localidadPer', data.cod_localidadPer, true);
        $('#direccionexactaPer').val(data.direccionexactaPer);
        app.ui.SetRadioNumericValue('OcupacionPer', data.OcupacionPer);
        $('#nombreempresaPer').val(data.nombreempresaPer);
        $('#actividadempresaPer').val(data.actividadempresaPer);
        $('#cargoempresaPer').val(data.cargoempresaPer);
        $('#telefonoempresaPer').val(data.telefonoempresaPer);
        $('#faxempresaPer').val(data.faxempresaPer);
        $('#domiciliocomercialCod_paisPer').val(data.domiciliocomercialCod_paisPer);
        app.ui.SetDropDownNumericValue('#domiciliocomercialCod_paisPer', data.domiciliocomercialCod_paisPer, true);
        $('#domiciliocomercialCod_estadoPer').val(data.domiciliocomercialCod_estadoPer);
        app.ui.SetDropDownNumericValue('#domiciliocomercialCod_estadoPer', data.domiciliocomercialCod_estadoPer, true);
        $('#domiciliocomercialCod_provPer').val(data.domiciliocomercialCod_provPer);
        app.ui.SetDropDownNumericValue('#domiciliocomercialCod_provPer', data.domiciliocomercialCod_provPer, true);
        $('#domiciliocomercialCod_localidadPer').val(data.domiciliocomercialCod_localidadPer);
        app.ui.SetDropDownNumericValue('#domiciliocomercialCod_localidadPer', data.domiciliocomercialCod_localidadPer, true);
        $('#domiciliocomercialDireccionexactaPer').val(data.domiciliocomercialDireccionexactaPer);
        $('#correspondenciaOrigendelosfondosPer').val(data.correspondenciaOrigendelosfondosPer);
        $('#paismayoractividadPer').val(data.paismayoractividadPer);
        app.ui.SetNumericValue('#ingresomensualestimadoPer', data.ingresomensualestimadoPer);
        app.ui.SetRadioNumericValue('fondospormivilizarPer', data.fondospormivilizarPer);
        app.ui.SetRadioNumericValue('actividadesart15Per', data.actividadesart15Per);
        app.ui.SetRadioNumericValue('activoscorrespondenPer', data.activoscorrespondenPer);
        app.ui.SetRadioNumericValue('pepcargoPer', data.pepcargoPer);
        $('#pepduracionPer').val(data.pepduracionPer);
        app.ui.SetRadioNumericValue('peprelacionPer', data.peprelacionPer);
        $('#peptiporelacionPer').val(data.peptiporelacionPer);
        $('#propositorelacioncomercialPer').val(data.propositorelacioncomercialPer);
        app.ui.SetNumericValue('#montoprimaPer', data.montoprimaPer);
        $('#tipodeprimaPer').val(data.tipodeprimaPer);
        app.ui.SetRadioNumericValue('periodicidadPer', data.periodicidadPer);
        app.ui.SetNumericValue('#montoValoraseguradoPer', data.montoValoraseguradoPer);
        app.ui.SetRadioNumericValue('formadepagodelapolizaPer', data.formadepagodelapolizaPer);
        app.ui.SetRadioNumericValue('mediodeenvioPer', data.mediodeenvioPer);
        $('#especifiquePer').val(data.especifiquePer);

    };

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
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoprimaPer', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoValoraseguradoPer', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });

    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#kycpersonaPerEdtForm :input").change(function () {
            data_changed();
        });


        $('#kycpersonaPerEdtFormSave').click(function () {

            if (app.ui.IsValid('#kycpersonaPerEdtForm', false)) {
                app.ui.ButtonDoing('#kycpersonaPerEdtFormSave');
                acceptCallback(MapInputToObject());
                app.ui.ButtonDone('#kycpersonaPerEdtFormSave');
            }
            event.preventDefault();
        });

        $('#kycpersonaPerEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#kycpersonaPerEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#kycpersonaPerEdtFormCancel'); }, 3000);
            event.preventDefault();
        });

    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#kycpersonaPerEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                correoelectronicoPer: { email: true },
            },
            messages: {
                correoelectronicoPer: { email: 'Debe indicar un correo electrónico valido' },
            }
        });
    };



    return {
        Init: function () {
            try {
                Controls_setup();
                Setup_Validations();

                Controls_Events();
                Setup();
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
                data = {
                    "primerapellidoPer": "",
                    "segundoapellidoPer": "",
                    "nombrePer": "",
                    "codigodeclientePer": "",
                    "numerodeidentificacionPer": "",
                    "tipodeidentificacionPer": "",
                    "fechadecaducidadPer": "0001-01-01T00:00:00",
                    "nacionalidadPer": 0,
                    "fechadenacimientoPer": "0001-01-01T00:00:00",
                    "paisdenacimientoPer": 0,
                    "profesionPer": 0,
                    "estadocivilPer": 0,
                    "sexoPer": 0,
                    "telefonoresidenciaPer": "",
                    "telefonocelularPer": "",
                    "faxPer": "",
                    "apartadoPostalPer": "",
                    "correoelectronicoPer": "",
                    "cod_paisPer": 0,
                    "cod_estadoPer": 0,
                    "cod_provPer": 0,
                    "cod_localidadPer": 0,
                    "direccionexactaPer": "",
                    "OcupacionPer": null,
                    "nombreempresaPer": "",
                    "actividadempresaPer": "",
                    "cargoempresaPer": "",
                    "telefonoempresaPer": "",
                    "faxempresaPer": "",
                    "domiciliocomercialCod_paisPer": 0,
                    "domiciliocomercialCod_estadoPer": 0,
                    "domiciliocomercialCod_provPer": 0,
                    "domiciliocomercialCod_localidadPer": 0,
                    "domiciliocomercialDireccionexactaPer": "",
                    "correspondenciaOrigendelosfondosPer": "",
                    "paismayoractividadPer": "",
                    "ingresomensualestimadoPer": 0,
                    "fondospormivilizarPer": null,
                    "actividadesart15Per": null,
                    "activoscorrespondenPer": null,
                    "pepcargoPer": null,
                    "pepduracionPer": "",
                    "peprelacionPer": null,
                    "peptiporelacionPer": "",
                    "propositorelacioncomercialPer": "",
                    "montoprimaPer": 0,
                    "tipodeprimaPer": "",
                    "periodicidadPer": null,
                    "montoValoraseguradoPer": 0,
                    "formadepagodelapolizaPer": null,
                    "mediodeenvioPer": null,
                    "especifiquePer": ""
                };

            }
            setupData = data;
            MapObjectToInput(data);
        }
    };
})();