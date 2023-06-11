var app = app || {};

app.PurdyPanelDanos = (function () {

    let _eventCallback = null;
    let _data = null;
    let _loadready = false;
    let _changed = false;

    function MapInputToObject() {
        var data = {
            ID: _data.ID,
            ASIGES: _data.ASIGES,
            TALLER: app.ui.GetDropDownNumericValue('#taller'),
            TALLERDESC: app.ui.GetDropDownSelectedText('#taller'),
            FECHAENVIODELAVALUO: app.ui.GetDateValue('#fechaenviodelavaluo'),
            PREREPUESTOS: app.ui.GetNumericValue('#prerepuestos'),
            PREREPUESTOSIVA: app.ui.GetNumericValue('#prerepuestosiva'),
            PREREPUESTOSTOTAL: app.ui.GetNumericValue('#prerepuestostotal'),
            PREMANO: app.ui.GetNumericValue('#premano'),
            PREMANOIVA: app.ui.GetNumericValue('#premanoiva'),
            PREMANOTOTAL: app.ui.GetNumericValue('#premanototal'),
            PREPERDIDA: app.ui.GetNumericValue('#preperdida'),
            AUTORIZACIONDEUSOPOLIZA: null,
            AUTORIZACIONDEUSOPOLIZADESC: null,
            FECHAAUTORIZACIONDEUSOPOLIZA: null,
            OT: app.ui.GetNumericValue('#oT'),
            ASESORTALLER: $('#asesorTaller').val(),
            EXPEDIENTE: $('#expediente').val(),
            ANALISTADEDANOS: app.ui.GetDropDownNumericValue('#analistadeDanos'),
            ANALISTADEDANOSDESC: app.ui.GetDropDownSelectedText('#analistadeDanos'),
            DEPRECIACIONYEXCLUSIONES: app.ui.GetNumericValue('#depreciacionyexclusiones'),
            PERDREPUESTO: app.ui.GetNumericValue('#perdrepuesto'),
            PERDREPUESTOIVA: app.ui.GetNumericValue('#perdrepuestoiva'),
            PERDREPUESTOTOTAL: app.ui.GetNumericValue('#perdrepuestototal'),
            PERDMANO: app.ui.GetNumericValue('#perdmano'),
            PERDMANOIVA: app.ui.GetNumericValue('#perdmanoiva'),
            PERDMANOTOTAL: app.ui.GetNumericValue('#perdmanototal'),
            PERDIDA: app.ui.GetNumericValue('#perdida'),
            SEVERIDADDELSINIESTRO: app.ui.GetDropDownNumericValue('#severidaddelsiniestro'),
            SEVERIDADDELSINIESTRODESC: app.ui.GetDropDownSelectedText('#severidaddelsiniestro'),
            AVALUOAUTORIZADO: app.ui.GetRadioNumericValue('avaluoautorizado'),
            AVALUOAUTORIZADODESC: app.ui.GetRadioSelectedText('avaluoautorizado'),
            FECHAAUTORIZACION: app.ui.GetDateValue('#fechaautorizacion'),
            PERDIDATOTAL: app.ui.GetRadioNumericValue('perdidatotal'),
            PERDIDATOTALDESC: app.ui.GetRadioSelectedText('perdidatotal'),
            TIPODEPERDIDATOTAL: app.ui.GetDropDownNumericValue('#tipodeperdidatotal'),
            TIPODEPERDIDATOTALDESC: app.ui.GetDropDownSelectedText('#tipodeperdidatotal'),
            PRESENTADANOOCULTO: app.ui.GetRadioNumericValue('presentadanooculto'),
            PRESENTADANOOCULTODESC: app.ui.GetRadioSelectedText('presentadanooculto'),
            FECHASOLICITADO: app.ui.GetDateValue('#fechasolicitado'),
            OBSERVACIONES: $('#observaciones').val(),
            DANOOCULTOMONTOREPDANOOCULTO: app.ui.GetNumericValue('#danoocultomontoRepuestosDanooculto'),
            DANOOCULTOIVA: app.ui.GetNumericValue('#danoocultoiva'),
            DANOOCULTOTOTAL: app.ui.GetNumericValue('#danoocultototal'),
            DANOOCULTOMANO: app.ui.GetNumericValue('#danoocultomano'),
            DANOOCULTOMANOIVA: app.ui.GetNumericValue('#danoocultomanoiva'),
            DANOOCULTOMANOTOTAL: app.ui.GetNumericValue('#danoocultomanototal'),
            OTROSIIOTROSIIDANOCULMANOTOTAL: app.ui.GetNumericValue('#otrosIIOtrosIIDanoocultomanototal')
        };
        return data;
    };

    function MapObjectToInput(data) {
        app.ui.SetDropDownNumericValue('#taller', data.TALLER, false);
        app.ui.SetDateValue('#fechaenviodelavaluo', data.FECHAENVIODELAVALUO);
        app.ui.SetNumericValue('#prerepuestos', data.PREREPUESTOS);
        app.ui.SetNumericValue('#prerepuestosiva', data.PREREPUESTOSIVA);
        app.ui.SetNumericValue('#prerepuestostotal', data.PREREPUESTOSTOTAL);
        app.ui.SetNumericValue('#premano', data.PREMANO);
        app.ui.SetNumericValue('#premanoiva', data.PREMANOIVA);
        app.ui.SetNumericValue('#premanototal', data.PREMANOTOTAL);
        app.ui.SetNumericValue('#preperdida', data.PREPERDIDA);
        //app.ui.SetRadioNumericValue('autorizaciondeusopoliza', data.AUTORIZACIONDEUSOPOLIZA);
        //app.ui.SetDateValue('#fechaAutorizaciondeUsoPoliza', data.FECHAAUTORIZACIONDEUSOPOLIZA);
        app.ui.SetNumericValue('#oT', data.OT);
        $('#asesorTaller').val(data.ASESORTALLER);
        $('#expediente').val(data.EXPEDIENTE);
        app.ui.SetDropDownNumericValue('#analistadeDanos', data.ANALISTADEDANOS, false);
        app.ui.SetNumericValue('#depreciacionyexclusiones', data.DEPRECIACIONYEXCLUSIONES);

        app.ui.SetNumericValue('#perdrepuesto', data.PERDREPUESTO);
        app.ui.SetNumericValue('#perdrepuestoiva', data.PERDREPUESTOIVA);
        app.ui.SetNumericValue('#perdrepuestototal', data.PERDREPUESTOTOTAL);
        app.ui.SetNumericValue('#perdmano', data.PERDMANO);
        app.ui.SetNumericValue('#perdmanoiva', data.PERDMANOIVA);
        app.ui.SetNumericValue('#perdmanototal', data.PERDMANOTOTAL);
        app.ui.SetNumericValue('#perdida', data.PERDIDA);
        app.ui.SetDropDownNumericValue('#severidaddelsiniestro', data.SEVERIDADDELSINIESTRO, false);
        app.ui.SetRadioNumericValue('avaluoautorizado', data.AVALUOAUTORIZADO);
        app.ui.SetDateValue('#fechaautorizacion', data.FECHAAUTORIZACION);
        app.ui.SetRadioNumericValue('perdidatotal', data.PERDIDATOTAL);
        app.ui.SetDropDownNumericValue('#tipodeperdidatotal', data.TIPODEPERDIDATOTAL, false);
        app.ui.SetRadioNumericValue('presentadanooculto', data.PRESENTADANOOCULTO);
        app.ui.SetDateValue('#fechasolicitado', data.FECHASOLICITADO);
        $('#observaciones').val(data.OBSERVACIONES);
        app.ui.SetNumericValue('#danoocultomontoRepuestosDanooculto', data.DANOOCULTOMONTOREPDANOOCULTO);
        app.ui.SetNumericValue('#danoocultoiva', data.DANOOCULTOIVA);
        app.ui.SetNumericValue('#danoocultototal', data.DANOOCULTOTOTAL);
        app.ui.SetNumericValue('#danoocultomano', data.DANOOCULTOMANO);
        app.ui.SetNumericValue('#danoocultomanoiva', data.DANOOCULTOMANOIVA);
        app.ui.SetNumericValue('#danoocultomanototal', data.DANOOCULTOMANOTOTAL);
        app.ui.SetNumericValue('#otrosIIOtrosIIDanoocultomanototal', data.OTROSIIOTROSIIDANOCULMANOTOTAL);

        data_changed();
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
        $('#fechasolicitado_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
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
                let submitData = MapInputToObject();
                if (submitData.ID === null) {
                    app.core.Post(`https://appqa.mapfrecr.com/datapi/api/entity/PurdyPanelDano`, JSON.stringify(submitData))
                        .done(function (created) {
                            if (created?.Sucessfully) {
                                _data = submitData
                                _data.ID = created.Data.Next.NEXTID
                                _loadready = true;
                                _changed = false;
                                _eventCallback('DanosDataChange', _data);
                                app.ui.CustomBehaviour('changed', false);
                                app.ui.Success('La información del análisis del daño, fue actualizada de forma exitosa');
                            }
                            else {
                                console.error(created);
                            }

                        }).always(function () {
                            app.ui.ButtonDone('#PurdyPanelDanosEdtFormSave');
                        });
                }
                else {
                    app.core.Put(`https://appqa.mapfrecr.com/datapi/api/entity/PurdyPanelDano/${submitData.ID}`, JSON.stringify(submitData))
                        .done(function (updated) {
                            if (updated?.Sucessfully) {
                                _data = submitData
                                _loadready = true;
                                _changed = false;
                                _eventCallback('DanosDataChange', _data);
                                app.ui.CustomBehaviour('changed', false);
                                app.ui.Success('La información del análisis del daño, fue actualizada de forma exitosa');
                            }
                            else {
                                console.error(updated);
                            }
                        }).always(function () {
                            app.ui.ButtonDone('#PurdyPanelDanosEdtFormSave');
                        });
                }
            }
            event.preventDefault();
        });

        $('#PurdyPanelDanosEdtFormCancel').click(function () {
            Get(_data.ASIGES);
            event.preventDefault();
        });

    };

    function data_changed() {

        if (app.ui.GetDropDownNumericValue('#taller') === 1)
            $('.asesorTallerVisible').removeClass('d-none');
        else
            $('.asesorTallerVisible').addClass('d-none');
        if (app.ui.GetDropDownNumericValue('#taller') === 1)
            $('.oTVisible').removeClass('d-none');
        else
            $('.oTVisible').addClass('d-none');
        if (app.ui.GetDropDownNumericValue('#taller') === 1)
            $('.expedienteVisible').removeClass('d-none');
        else
            $('.expedienteVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('autorizaciondeusopoliza') === 1)
            $('.fechaAutorizaciondeUsoPolizaVisible').removeClass('d-none');
        else
            $('.fechaAutorizaciondeUsoPolizaVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('avaluoautorizado') === 1)
            $('.fechaautorizacionVisible').removeClass('d-none');
        else
            $('.fechaautorizacionVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('perdidatotal') === 1)
            $('.tipodeperdidatotalVisible').removeClass('d-none');
        else
            $('.tipodeperdidatotalVisible').addClass('d-none');



        app.ui.VisibleBehaviour('.presentadanooculto', app.ui.GetRadioNumericValue('presentadanooculto') === 1);

        if (app.ui.GetRadioNumericValue('presentadanooculto') === 2) {
            app.ui.SetDateValue('#fechasolicitado', null);
            $('#observaciones').val('');
            app.ui.SetNumericValue('#danoocultomontoRepuestosDanooculto', 0);
            app.ui.SetNumericValue('#danoocultoiva', 0);
            app.ui.SetNumericValue('#danoocultototal', 0);
            app.ui.SetNumericValue('#danoocultomano', 0);
            app.ui.SetNumericValue('#danoocultomanoiva', 0);
            app.ui.SetNumericValue('#danoocultomanototal', 0);
            app.ui.SetNumericValue('#otrosIIOtrosIIDanoocultomanototal', 0);
        }

        app.ui.SetNumericValue('#prerepuestosiva', app.ui.GetNumericValue('#prerepuestos') * 0.13);
        app.ui.SetNumericValue('#prerepuestostotal', app.ui.GetNumericValue('#prerepuestos') * 1.13);
        app.ui.SetNumericValue('#premanoiva', app.ui.GetNumericValue('#premano') * 0.13);
        app.ui.SetNumericValue('#premanototal', app.ui.GetNumericValue('#premano') * 1.13);
        app.ui.SetNumericValue('#preperdida', (app.ui.GetNumericValue('#prerepuestos') * 1.13) + (app.ui.GetNumericValue('#premano') * 1.13));


        app.ui.SetNumericValue('#perdrepuestoiva', app.ui.GetNumericValue('#perdrepuesto') * 0.13);
        app.ui.SetNumericValue('#perdrepuestototal', app.ui.GetNumericValue('#perdrepuesto') * 1.13);
        app.ui.SetNumericValue('#perdmanoiva', app.ui.GetNumericValue('#perdmano') * 0.13);
        app.ui.SetNumericValue('#perdmanototal', app.ui.GetNumericValue('#perdmano') * 1.13);
        app.ui.SetNumericValue('#perdida', (app.ui.GetNumericValue('#perdrepuesto') * 1.13) + (app.ui.GetNumericValue('#perdmano') * 1.13));

        app.ui.SetNumericValue('#danoocultoiva', app.ui.GetNumericValue('#danoocultomontoRepuestosDanooculto') * 0.13);
        app.ui.SetNumericValue('#danoocultototal', app.ui.GetNumericValue('#danoocultomontoRepuestosDanooculto') * 1.13);
        app.ui.SetNumericValue('#danoocultomanoiva', app.ui.GetNumericValue('#danoocultomano') * 0.13);
        app.ui.SetNumericValue('#danoocultomanototal', app.ui.GetNumericValue('#danoocultomano') * 1.13);
        app.ui.SetNumericValue('#otrosIIOtrosIIDanoocultomanototal', (app.ui.GetNumericValue('#danoocultomontoRepuestosDanooculto') * 1.13) + (app.ui.GetNumericValue('#danoocultomano') * 1.13));

        if (_loadready) {
            _changed = true;
        }
        app.ui.CustomBehaviour('changed', _loadready && _changed);
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

    function EmptyPurdyPanelDano() {
        let data = {
            ID: null,
            ASIGES: null,
            TALLER: null,
            FECHAENVIODELAVALUO: null,
            PREREPUESTOS: null,
            PREREPUESTOSIVA: null,
            PREREPUESTOSTOTAL: null,
            PREMANO: null,
            PREMANOIVA: null,
            PREMANOTOTAL: null,
            PREPERDIDA: null,
            AUTORIZACIONDEUSOPOLIZA: 2,
            FECHAAUTORIZACIONDEUSOPOLIZA: null,
            OT: null,
            ASESORTALLER: null,
            EXPEDIENTE: null,
            ANALISTADEDANOS: null,
            DEPRECIACIONYEXCLUSIONES: null,
            PERDREPUESTO: null,
            PERDREPUESTOIVA: null,
            PERDREPUESTOTOTAL: null,
            PERDMANO: null,
            PERDMANOIVA: null,
            PERDMANOTOTAL: null,
            PERDIDA: null,
            SEVERIDADDELSINIESTRO: null,
            AVALUOAUTORIZADO: 2,
            FECHAAUTORIZACION: null,
            PERDIDATOTAL: 2,
            TIPODEPERDIDATOTAL: null,
            PRESENTADANOOCULTO: 2,
            FECHASOLICITADO: null,
            OBSERVACIONES: null,
            DANOOCULTOMONTOREPDANOOCULTO: null,
            DANOOCULTOIVA: null,
            DANOOCULTOTOTAL: null,
            DANOOCULTOMANO: null,
            DANOOCULTOMANOIVA: null,
            DANOOCULTOMANOTOTAL: null,
            OTROSIIOTROSIIDANOCULMANOTOTAL: null,
            UPDATEUSERCODE: null,
            UPDATEDATE: null
        };
        return data;
    };

    function Get(asigesCode) {
        _loadready = false;
        app.core.Get(`https://appqa.mapfrecr.com/datapi/api/entity/PurdyPanelDano/asiges?code=${asigesCode}`)
            .done(function (dataDanos) {
                if (dataDanos?.Sucessfully) {
                    if (dataDanos.Data === null) {
                        dataDanos.Data = EmptyPurdyPanelDano();
                        dataDanos.Data.ASIGES = asigesCode;
                    }
                    MapObjectToInput(dataDanos.Data);
                    _data = dataDanos.Data;
                    _eventCallback('DanosDataChange', dataDanos.Data);
                }
                _changed = false;
                _loadready = true;
            });
    };

    return {
        Init: function (eventCallback) {
            try {
                _eventCallback = eventCallback;
                Controls_setup();
                Setup_Validations();

                Controls_Events();

                app.core.Lookups(['UsersByRol:Avalúos.analistadeDanos'],
                    function () {
                        MapObjectToInput(EmptyPurdyPanelDano());
                        _loadready = true;
                    }, ``);
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Event: function (src, data) {
            switch (src) {
                case 'ASIGESChange':
                    if (data.claim != null) {
                        Get(data.asiges);
                    } else {
                        MapObjectToInput(EmptyPurdyPanelDano());
                        app.ui.SetRadioNumericValue('autorizaciondeusopoliza', 2);
                        app.ui.SetDateValue('#fechaAutorizaciondeUsoPoliza', null);
                    }
                    break;
                case 'EventoDataChange':
                    app.ui.SetRadioNumericValue('autorizaciondeusopoliza', data.event.AUTORIZACIONDEUSOPOLIZA);
                    app.ui.SetDateValue('#fechaAutorizaciondeUsoPoliza', data.event.FECHAAUTORIZACIONDEUSOPOLIZA);
                    data_changed();
                    break;
            }
        }
    };
})();
