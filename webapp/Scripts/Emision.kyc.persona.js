var app = app || {};

app.kycpersona = (function () {

    let setupData = null;
    let changedCallback = null;
    let acceptCallback = null;

    function Setup(data) {


        app.core.Lookups(['Pais.nacionalidadPer', 'Pais.paisdenacimientoPer', 'CivilStatus.estadocivilPer', 'Gender.sexoPer', 'Paises.cod_paisPer', 'Provincias.cod_estadoPer', 'Cantones.cod_provPer', 'Distritos.cod_localidadPer',],
            function () {
            }, `cod_pais=CRI`);
    };

    function ReadOnly() {
        $('#primerapellidoPer').replaceWith('<div>' + $('#primerapellidoPer').val() + '</div>');
        $('#segundoapellidoPer').replaceWith('<div>' + $('#segundoapellidoPer').val() + '</div>');
        $('#nombrePer').replaceWith('<div>' + $('#nombrePer').val() + '</div>');
        $('#codigodeclientePer').replaceWith('<div>' + $('#codigodeclientePer').val() + '</div>');
        $('#numerodeidentificacionPer').replaceWith('<div>' + $('#numerodeidentificacionPer').val() + '</div>');
        $('#tipodeidentificacionPer').replaceWith('<div>' + $('#tipodeidentificacionPer').val() + '</div>');
        $('#fechadecaducidadPer_group').replaceWith('<div>' + $('#fechadecaducidadPer').val() + '</div>');
        $('#nacionalidadPer').replaceWith('<div>' + $('#nacionalidadPer option:selected').text() + '</div>');
        $('#fechadenacimientoPer_group').replaceWith('<div>' + $('#fechadenacimientoPer').val() + '</div>');
        $('#paisdenacimientoPer').replaceWith('<div>' + $('#paisdenacimientoPer option:selected').text() + '</div>');
        $('#profesionPer').replaceWith('<div>' + $('#profesionPer option:selected').text() + '</div>');
        $('#estadocivilPer').replaceWith('<div>' + $('#estadocivilPer option:selected').text() + '</div>');
        $('#sexoPer').replaceWith('<div>' + $('#sexoPer option:selected').text() + '</div>');
        $('#telefonoresidenciaPer').replaceWith('<div>' + $('#telefonoresidenciaPer').val() + '</div>');
        $('#telefonocelularPer').replaceWith('<div>' + $('#telefonocelularPer').val() + '</div>');
        $('#faxPer').replaceWith('<div>' + $('#faxPer').val() + '</div>');
        $('#apartadoPostalPer').replaceWith('<div>' + $('#apartadoPostalPer').val() + '</div>');
        $('#correoelectronicoPer').replaceWith('<div>' + $('#correoelectronicoPer').val() + '</div>');
        $('#cod_paisPer').replaceWith('<div>' + $('#cod_paisPer option:selected').text() + '</div>');
        $('#cod_estadoPer').replaceWith('<div>' + $('#cod_estadoPer option:selected').text() + '</div>');
        $('#cod_provPer').replaceWith('<div>' + $('#cod_provPer option:selected').text() + '</div>');
        $('#cod_localidadPer').replaceWith('<div>' + $('#cod_localidadPer option:selected').text() + '</div>');
        $('#direccionexactaPer').replaceWith('<div>' + $('#direccionexactaPer').val() + '</div>');
        $('label[for=OcupacionPer').next().replaceWith('<div>' + $('label[for=OcupacionPer_' + app.ui.GetRadioNumericValue('OcupacionPer') + '').html() + '</div>');
        $('#nombreempresaPer').replaceWith('<div>' + $('#nombreempresaPer').val() + '</div>');
        $('#actividadempresaPer').replaceWith('<div>' + $('#actividadempresaPer').val() + '</div>');
        $('#cargoempresaPer').replaceWith('<div>' + $('#cargoempresaPer').val() + '</div>');
        $('#telefonoempresaPer').replaceWith('<div>' + $('#telefonoempresaPer').val() + '</div>');
        $('#faxempresaPer').replaceWith('<div>' + $('#faxempresaPer').val() + '</div>');
        $('#paisPer').replaceWith('<div>' + $('#paisPer option:selected').text() + '</div>');
        $('#provinciaPer').replaceWith('<div>' + $('#provinciaPer option:selected').text() + '</div>');
        $('#cantonPer').replaceWith('<div>' + $('#cantonPer option:selected').text() + '</div>');
        $('#distritoPer').replaceWith('<div>' + $('#distritoPer option:selected').text() + '</div>');
        $('#domiciliocomercialDireccionexactaPer').replaceWith('<div>' + $('#domiciliocomercialDireccionexactaPer').val() + '</div>');
        $('#correspondenciaOrigendelosfondosPer').replaceWith('<div>' + $('#correspondenciaOrigendelosfondosPer').val() + '</div>');
        $('#paismayoractividadPer').replaceWith('<div>' + $('#paismayoractividadPer').val() + '</div>');
        $('#ingresomensualestimadoPer').replaceWith('<div>' + $('#ingresomensualestimadoPer').val() + '</div>');
        $('label[for=fondospormivilizarPer').next().replaceWith('<div>' + $('label[for=fondospormivilizarPer_' + app.ui.GetRadioNumericValue('fondospormivilizarPer') + '').html() + '</div>');
        $('label[for=actividadesart15Per').next().replaceWith('<div>' + $('label[for=actividadesart15Per_' + app.ui.GetRadioNumericValue('actividadesart15Per') + '').html() + '</div>');
        $('label[for=activoscorrespondenPer').next().replaceWith('<div>' + $('label[for=activoscorrespondenPer_' + app.ui.GetRadioNumericValue('activoscorrespondenPer') + '').html() + '</div>');
        $('label[for=pepcargoPer').next().replaceWith('<div>' + $('label[for=pepcargoPer_' + app.ui.GetRadioNumericValue('pepcargoPer') + '').html() + '</div>');
        $('#pepduracionPer').replaceWith('<div>' + $('#pepduracionPer').val() + '</div>');
        $('label[for=peprelacionPer').next().replaceWith('<div>' + $('label[for=peprelacionPer_' + app.ui.GetRadioNumericValue('peprelacionPer') + '').html() + '</div>');
        $('#peptiporelacionPer').replaceWith('<div>' + $('#peptiporelacionPer').val() + '</div>');
        $('#propositorelacioncomercialPer').replaceWith('<div>' + $('#propositorelacioncomercialPer').val() + '</div>');
        $('#montoprimaPer').replaceWith('<div>' + $('#montoprimaPer').val() + '</div>');
        $('#tipodeprimaPer').replaceWith('<div>' + $('#tipodeprimaPer').val() + '</div>');
        $('label[for=periodicidadPer').next().replaceWith('<div>' + $('label[for=periodicidadPer_' + app.ui.GetRadioNumericValue('periodicidadPer') + '').html() + '</div>');
        $('#montoValoraseguradoPer').replaceWith('<div>' + $('#montoValoraseguradoPer').val() + '</div>');
        $('label[for=formadepagodelapolizaPer').next().replaceWith('<div>' + $('label[for=formadepagodelapolizaPer_' + app.ui.GetRadioNumericValue('formadepagodelapolizaPer') + '').html() + '</div>');
        $('label[for=mediodeenvioPer').next().replaceWith('<div>' + $('label[for=mediodeenvioPer_' + app.ui.GetRadioNumericValue('mediodeenvioPer') + '').html() + '</div>');
        $('#especifiquePer').replaceWith('<div>' + $('#especifiquePer').val() + '</div>');

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
            paisPer: app.ui.GetDropDownNumericValue('#paisPer'),
            provinciaPer: app.ui.GetDropDownNumericValue('#provinciaPer'),
            cantonPer: app.ui.GetDropDownNumericValue('#cantonPer'),
            distritoPer: app.ui.GetDropDownNumericValue('#distritoPer'),
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
        $('#paisPer').val(data.paisPer);
        app.ui.SetDropDownNumericValue('#paisPer', data.paisPer, true);
        $('#provinciaPer').val(data.provinciaPer);
        app.ui.SetDropDownNumericValue('#provinciaPer', data.provinciaPer, true);
        $('#cantonPer').val(data.cantonPer);
        app.ui.SetDropDownNumericValue('#cantonPer', data.cantonPer, true);
        $('#distritoPer').val(data.distritoPer);
        app.ui.SetDropDownNumericValue('#distritoPer', data.distritoPer, true);
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
            event.preventDefault();
            if (app.ui.IsValid('#kycpersonaPerEdtForm', false)) {
                app.ui.ButtonDoing('#kycpersonaPerEdtFormSave');

                //        console.log(MapInputToObject())

                //        app.core.Post(app.setting.apipath + 'v1/kyc/persona',
                //            JSON.stringify(MapInputToObject()),
                //            function (data) {
                //                if (data.Mensaje != null) {
                //                    app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                //                }
                //                else {

                //                }

                //            }).always(function () {
                //                app.ui.ButtonDone('#kycpersonaPerEdtFormSave');
                //            });

                acceptCallback(MapInputToObject());
                app.ui.ButtonDone('#kycpersonaPerEdtFormSave');
            }
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
            if (data != null) {
                setupData = data;
                MapObjectToInput(data);
            }
        }
    };
})();