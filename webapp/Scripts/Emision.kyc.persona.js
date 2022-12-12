var app = app || {};

app.kycpersona = (function () {

    let setupData = null;
    let changedCallback = null;
    let acceptCallback = null;

    function Setup(data) {
        app.core.Lookups(['Pais.nacionalidadPer', 'Pais.paisdenacimientoPer', 'CivilStatus.estadocivilPer', 'Gender.sexoPer', 'Paises.cod_paisPer', 'Provincias.cod_estadoPer', 'Paises.domiciliocomercialCod_paisPer', 'Provincias.domiciliocomercialCod_estadoPer'],
            function () {
                setupData = data;
                MapObjectToInput(data);
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
    };

    function MapInputToObject() {
        var data = {
            primerapellidoPer: $('#primerapellidoPer').val(),
            segundoapellidoPer: $('#segundoapellidoPer').val(),
            nombrePer: $('#nombrePer').val(),
            codigodeclientePer: $('#codigodeclientePer').val(),
            numerodeidentificacionPer: $('#numerodeidentificacionPer').val(),
            tipodeidentificacionPer: app.ui.GetRadioNumericValue('tipodeidentificacionPer'),
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
            apartadopostalPer: $('#apartadopostalPer').val(),
            correoelectronicoPer: $('#correoelectronicoPer').val(),
            cod_paisPer: app.ui.GetDropDownStringValue('#cod_paisPer'),
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
            domiciliocomercialCod_paisPer: app.ui.GetDropDownStringValue('#domiciliocomercialCod_paisPer'),
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
        app.ui.SetRadioNumericValue('tipodeidentificacionPer', data.tipodeidentificacionPer);
        app.ui.SetDateValue('#fechadecaducidadPer', data.fechadecaducidadPer);
        app.ui.SetDropDownNumericValue('#nacionalidadPer', data.nacionalidadPer, true);
        app.ui.SetDateValue('#fechadenacimientoPer', data.fechadenacimientoPer);
        app.ui.SetDropDownNumericValue('#paisdenacimientoPer', data.paisdenacimientoPer, true);
        app.ui.SetDropDownNumericValue('#profesionPer', data.profesionPer, true);
        app.ui.SetDropDownNumericValue('#estadocivilPer', data.estadocivilPer, true);
        app.ui.SetDropDownNumericValue('#sexoPer', data.sexoPer, true);
        $('#telefonoresidenciaPer').val(data.telefonoresidenciaPer);
        $('#telefonocelularPer').val(data.telefonocelularPer);
        $('#faxPer').val(data.faxPer);
        $('#apartadopostalPer').val(data.apartadopostalPer);
        $('#correoelectronicoPer').val(data.correoelectronicoPer);

        app.ui.SetDropDownStringValue('#cod_paisPer', data.cod_paisPer, true);
        app.ui.SetDropDownNumericValue('#cod_estadoPer', data.cod_estadoPer, true);
        app.core.LookupDependency(data.cod_estadoPer, 'cod_provPer', 'Cantones', '', data.cod_provPer, false, null, `cod_pais=${data.cod_paisPer}:cod_estado=`);
        app.core.LookupDependency(data.cod_provPer, 'cod_localidadPer', 'Distritos', '', data.cod_localidadPer, false, null, `cod_pais=${data.cod_paisPer}:cod_prov=`);

        $('#direccionexactaPer').val(data.direccionexactaPer);
        app.ui.SetRadioNumericValue('OcupacionPer', data.OcupacionPer);
        $('#nombreempresaPer').val(data.nombreempresaPer);
        $('#actividadempresaPer').val(data.actividadempresaPer);
        $('#cargoempresaPer').val(data.cargoempresaPer);
        $('#telefonoempresaPer').val(data.telefonoempresaPer);
        $('#faxempresaPer').val(data.faxempresaPer);

        app.ui.SetDropDownStringValue('#domiciliocomercialCod_paisPer', data.domiciliocomercialCod_paisPer, true);
        app.ui.SetDropDownNumericValue('#domiciliocomercialCod_estadoPer', data.domiciliocomercialCod_estadoPer, true);
        app.core.LookupDependency(data.domiciliocomercialCod_estadoPer, 'domiciliocomercialCod_provPer', 'Cantones', '', data.domiciliocomercialCod_provPer, false, null, `cod_pais=${data.cod_paisPer}:cod_estado=`);
        app.core.LookupDependency(data.domiciliocomercialCod_provPer, 'domiciliocomercialCod_localidadPer', 'Distritos', '', data.domiciliocomercialCod_localidadPer, false, null, `cod_pais=${data.cod_paisPer}:cod_prov=`);


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


        //$('#kycpersonaPerEdtFormCancel').click(function () {
        //    app.ui.ButtonDoing('#kycpersonaPerEdtFormCancel');
        //    setTimeout(() => { app.ui.ButtonDone('#kycpersonaPerEdtFormCancel'); }, 3000);
        //    event.preventDefault();
        //});

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
                primerapellidoPer: { required: true },
                segundoapellidoPer: { required: true },
                nombrePer: { required: true },
                codigodeclientePer: { required: true },
                numerodeidentificacionPer: { required: true },
                tipodeidentificacionPer: { required: true },
                fechadecaducidadPer: { required: true },
                nacionalidadPer: { required: true },
                fechadenacimientoPer: { required: true },
                paisdenacimientoPer: { required: true },
                profesionPer: { required: true },
                estadocivilPer: { required: true },
                sexoPer: { required: true },
                telefonoresidenciaPer: { required: true },
                telefonocelularPer: { required: true },
                faxPer: { required: true },
                apartadopostalPer: { required: true },
                correoelectronicoPer: { required: true, email: true },
                cod_paisPer: { required: true },
                cod_estadoPer: { required: true },
                cod_provPer: { required: true },
                cod_localidadPer: { required: true },
                direccionexactaPer: { required: true },
                OcupacionPer: { required: true },
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
                montoprimaPer: { required: true },
                tipodeprimaPer: { required: true },
                periodicidadPer: { required: true },
                montoValoraseguradoPer: { required: true },
                formadepagodelapolizaPer: { required: true },
                mediodeenvioPer: { required: true },
                especifiquePer: { required: true },
            },
            messages: {
                primerapellidoPer: { required: 'Debe indicar el Primer apellido' },
                segundoapellidoPer: { required: 'Debe indicar el Segundo apellido' },
                nombrePer: { required: 'Debe indicar el Nombre' },
                codigodeclientePer: { required: 'Debe indicar el Código de cliente' },
                numerodeidentificacionPer: { required: 'Debe indicar el Número de identificación' },
                tipodeidentificacionPer: { required: 'Debe indicar el Tipo de identificación' },
                fechadecaducidadPer: { required: 'Debe indicar el Fecha de caducidad' },
                nacionalidadPer: { required: 'Debe indicar el Nacionalidad' },
                fechadenacimientoPer: { required: 'Debe indicar el Fecha de nacimiento' },
                paisdenacimientoPer: { required: 'Debe indicar el País de nacimiento' },
                profesionPer: { required: 'Debe indicar el Profesión' },
                estadocivilPer: { required: 'Debe indicar el Estado civil' },
                sexoPer: { required: 'Debe indicar el Sexo' },
                telefonoresidenciaPer: { required: 'Debe indicar el Teléfono residencia' },
                telefonocelularPer: { required: 'Debe indicar el Teléfono celular' },
                faxPer: { required: 'Debe indicar el Fax' },
                apartadopostalPer: { required: 'Debe indicar el Apartado postal' },
                correoelectronicoPer: { required: 'Debe indicar el Correo electrónico', email: 'Debe indicar un correo electrónico valido' },
                cod_paisPer: { required: 'Debe indicar el País' },
                cod_estadoPer: { required: 'Debe indicar el Provincia' },
                cod_provPer: { required: 'Debe indicar el Cantón' },
                cod_localidadPer: { required: 'Debe indicar el Distrito' },
                direccionexactaPer: { required: 'Debe indicar el Dirección exacta' },
                OcupacionPer: { required: 'Debe indicar el Indique su ocupación o actividad actual' },
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
                montoprimaPer: { required: 'Debe indicar el Monto prima' },
                tipodeprimaPer: { required: 'Debe indicar el Tipo de prima' },
                periodicidadPer: { required: 'Debe indicar el Periodicidad' },
                montoValoraseguradoPer: { required: 'Debe indicar el Monto Valor asegurado' },
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
                data = app.kycpersona.InitData();
            }
            setupData = data;
            MapObjectToInput(data);
        },
        InitData: function () {
            return {
                "primerapellidoPer": "",
                "segundoapellidoPer": "",
                "nombrePer": "",
                "codigodeclientePer": "",
                "numerodeidentificacionPer": "",
                "tipodeidentificacionPer": 0,
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
                "cod_paisPer": "CRI",
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
                "domiciliocomercialCod_paisPer": "CRI",
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
    };
})();
