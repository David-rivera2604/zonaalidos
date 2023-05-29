var app = app || {};

app.PurdyPanelDanos = (function () {

    let _eventCallback = null;
    var setupData = null;
    var changedCallback = null;

    function Setup() {

        app.core.Get(app.setting.apipath + 'v1/Quote/PanelDanosSetup', null,
            function (data) {
                app.core.Lookups(['Users-Avalúos.analistadeDanos',],
                    function () {
                        setupData = data;
                        MapObjectToInput(data);
                    }, ``);

            });
    };

    function MapInputToObject() {
        var data = {
            taller: app.ui.GetDropDownNumericValue('#taller'),
            tallerDesc: app.ui.GetDropDownSelectedText('#taller'),
            fechaenviodelavaluo: app.ui.GetDateValue('#fechaenviodelavaluo'),
            prerepuestos: app.ui.GetNumericValue('#prerepuestos'),
            prerepuestosiva: app.ui.GetNumericValue('#prerepuestosiva'),
            prerepuestostotal: app.ui.GetNumericValue('#prerepuestostotal'),
            premano: app.ui.GetNumericValue('#premano'),
            premanoiva: app.ui.GetNumericValue('#premanoiva'),
            premanototal: app.ui.GetNumericValue('#premanototal'),
            preperdida: app.ui.GetNumericValue('#preperdida'),
            autorizaciondeusopoliza: app.ui.GetRadioNumericValue('autorizaciondeusopoliza'),
            autorizaciondeusopolizaDesc: app.ui.GetRadioSelectedText('autorizaciondeusopoliza'),
            fechaAutorizaciondeUsoPoliza: app.ui.GetDateValue('#fechaAutorizaciondeUsoPoliza'),
            oT: app.ui.GetNumericValue('#oT'),
            asesorTaller: $('#asesorTaller').val(),
            expediente: $('#expediente').val(),
            analistadeDanos: app.ui.GetDropDownNumericValue('#analistadeDanos'),
            analistadeDanosDesc: app.ui.GetDropDownSelectedText('#analistadeDanos'),
            depreciacionyexclusiones: app.ui.GetNumericValue('#depreciacionyexclusiones'),
            perdrepuesto: app.ui.GetNumericValue('#perdrepuesto'),
            perdrepuestoiva: app.ui.GetNumericValue('#perdrepuestoiva'),
            perdrepuestototal: app.ui.GetNumericValue('#perdrepuestototal'),
            perdmano: app.ui.GetNumericValue('#perdmano'),
            perdmanoiva: app.ui.GetNumericValue('#perdmanoiva'),
            perdmanototal: app.ui.GetNumericValue('#perdmanototal'),
            perdida: app.ui.GetNumericValue('#perdida'),
            severidaddelsiniestro: app.ui.GetDropDownNumericValue('#severidaddelsiniestro'),
            severidaddelsiniestroDesc: app.ui.GetDropDownSelectedText('#severidaddelsiniestro'),
            avaluoautorizado: app.ui.GetRadioNumericValue('avaluoautorizado'),
            avaluoautorizadoDesc: app.ui.GetRadioSelectedText('avaluoautorizado'),
            fechaautorizacion: app.ui.GetDateValue('#fechaautorizacion'),
            perdidatotal: app.ui.GetRadioNumericValue('perdidatotal'),
            perdidatotalDesc: app.ui.GetRadioSelectedText('perdidatotal'),
            tipodeperdidatotal: app.ui.GetDropDownNumericValue('#tipodeperdidatotal'),
            tipodeperdidatotalDesc: app.ui.GetDropDownSelectedText('#tipodeperdidatotal'),
            presentadanooculto: app.ui.GetRadioNumericValue('presentadanooculto'),
            presentadanoocultoDesc: app.ui.GetRadioSelectedText('presentadanooculto'),
            fechasolicitado: $('#fechasolicitado').val(),
            observaciones: $('#observaciones').val(),
            danoocultomontoRepuestosDanooculto: app.ui.GetNumericValue('#danoocultomontoRepuestosDanooculto'),
            danoocultoiva: app.ui.GetNumericValue('#danoocultoiva'),
            danoocultototal: app.ui.GetNumericValue('#danoocultototal'),
            danoocultomano: app.ui.GetNumericValue('#danoocultomano'),
            danoocultomanoiva: app.ui.GetNumericValue('#danoocultomanoiva'),
            danoocultomanototal: app.ui.GetNumericValue('#danoocultomanototal'),
            otrosIIOtrosIIDanoocultomanototal: app.ui.GetNumericValue('#otrosIIOtrosIIDanoocultomanototal'),

        };
        return data;
    };

    function MapObjectToInput(data) {
        app.ui.SetDropDownNumericValue('#taller', data.taller, true);
        app.ui.SetDateValue('#fechaenviodelavaluo', data.fechaenviodelavaluo);
        app.ui.SetNumericValue('#prerepuestos', data.prerepuestos);
        app.ui.SetNumericValue('#prerepuestosiva', data.prerepuestosiva);
        app.ui.SetNumericValue('#prerepuestostotal', data.prerepuestostotal);
        app.ui.SetNumericValue('#premano', data.premano);
        app.ui.SetNumericValue('#premanoiva', data.premanoiva);
        app.ui.SetNumericValue('#premanototal', data.premanototal);
        app.ui.SetNumericValue('#preperdida', data.preperdida);
        app.ui.SetRadioNumericValue('autorizaciondeusopoliza', data.autorizaciondeusopoliza);
        app.ui.SetDateValue('#fechaAutorizaciondeUsoPoliza', data.fechaAutorizaciondeUsoPoliza);
        app.ui.SetNumericValue('#oT', data.oT);
        $('#asesorTaller').val(data.asesorTaller);
        $('#expediente').val(data.expediente);
        app.ui.SetDropDownNumericValue('#analistadeDanos', data.analistadeDanos, true);
        app.ui.SetNumericValue('#depreciacionyexclusiones', data.depreciacionyexclusiones);
        app.ui.SetNumericValue('#perdrepuesto', data.perdrepuesto);
        app.ui.SetNumericValue('#perdrepuestoiva', data.perdrepuestoiva);
        app.ui.SetNumericValue('#perdrepuestototal', data.perdrepuestototal);
        app.ui.SetNumericValue('#perdmano', data.perdmano);
        app.ui.SetNumericValue('#perdmanoiva', data.perdmanoiva);
        app.ui.SetNumericValue('#perdmanototal', data.perdmanototal);
        app.ui.SetNumericValue('#perdida', data.perdida);
        app.ui.SetDropDownNumericValue('#severidaddelsiniestro', data.severidaddelsiniestro, true);
        app.ui.SetRadioNumericValue('avaluoautorizado', data.avaluoautorizado);
        app.ui.SetDateValue('#fechaautorizacion', data.fechaautorizacion);
        app.ui.SetRadioNumericValue('perdidatotal', data.perdidatotal);
        app.ui.SetDropDownNumericValue('#tipodeperdidatotal', data.tipodeperdidatotal, true);
        app.ui.SetRadioNumericValue('presentadanooculto', data.presentadanooculto);
        $('#fechasolicitado').val(data.fechasolicitado);
        $('#observaciones').val(data.observaciones);
        app.ui.SetNumericValue('#danoocultomontoRepuestosDanooculto', data.danoocultomontoRepuestosDanooculto);
        app.ui.SetNumericValue('#danoocultoiva', data.danoocultoiva);
        app.ui.SetNumericValue('#danoocultototal', data.danoocultototal);
        app.ui.SetNumericValue('#danoocultomano', data.danoocultomano);
        app.ui.SetNumericValue('#danoocultomanoiva', data.danoocultomanoiva);
        app.ui.SetNumericValue('#danoocultomanototal', data.danoocultomanototal);
        app.ui.SetNumericValue('#otrosIIOtrosIIDanoocultomanototal', data.otrosIIOtrosIIDanoocultomanototal);

    };

    function Controls_setup() {
        $('#fechaenviodelavaluo_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#prerepuestos', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#prerepuestosiva', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#prerepuestostotal', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#premano', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#premanoiva', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#premanototal', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#preperdida', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#fechaAutorizaciondeUsoPoliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#oT', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#depreciacionyexclusiones', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#perdrepuesto', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#perdrepuestoiva', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#perdrepuestototal', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#perdmano', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#perdmanoiva', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#perdmanototal', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#perdida', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#fechaautorizacion_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#danoocultomontoRepuestosDanooculto', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#danoocultoiva', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#danoocultototal', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#danoocultomano', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#danoocultomanoiva', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#danoocultomanototal', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#otrosIIOtrosIIDanoocultomanototal', {
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
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#PurdyPanelDanosEdtForm :input").change(function () {
            data_changed();
        });


        $('#PurdyPanelDanosEdtFormSave').click(function () {

            if (app.ui.IsValid('#PurdyPanelDanosEdtForm', false)) {
                app.ui.ButtonDoing('#PurdyPanelDanosEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/Purdy/PanelDanos',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {

                        }

                    }).always(function () {
                        app.ui.ButtonDone('#PurdyPanelDanosEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#PurdyPanelDanosEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#PurdyPanelDanosEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PurdyPanelDanosEdtFormCancel'); }, 3000);
            event.preventDefault();
        });

    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
        if (taller === 1)
            $('.asesorTallerVisible').removeClass('d-none');
        else
            $('.asesorTallerVisible').addClass('d-none');
        if (taller === 1)
            $('.expedienteVisible').removeClass('d-none');
        else
            $('.expedienteVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('avaluoautorizado') === 'Si')
            $('.fechaautorizacionVisible').removeClass('d-none');
        else
            $('.fechaautorizacionVisible').addClass('d-none');
        if (perdidatotal === Si)
            $('.tipodeperdidatotalVisible').removeClass('d-none');
        else
            $('.tipodeperdidatotalVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('presentadanooculto') === 'Si')
            $('.observacionesVisible').removeClass('d-none');
        else
            $('.observacionesVisible').addClass('d-none');
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#PurdyPanelDanosEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {},
            messages: {}
        });
    };



    return {
        Init: function (eventCallback) {
            try {
                _eventCallback = eventCallback;
                Controls_setup();
                Setup_Validations();

                Controls_Events();

            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Event: function (src, data) {
        }
    };
})();
