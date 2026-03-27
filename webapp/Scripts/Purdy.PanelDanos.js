var app = app || {};

app.PurdyPanelDanos = (function () {

    let _eventCallback = null;
    let _data = null;
    let _claim = null;
    let _loadready = false;
    let _changed = false;
    let _deducible = 0;
    let _deducibleColOld = 0;
    let _deducibleCol = 0;
    let _empresa = '';

    function MapInputToObject() {
        var data = {
            ID: _data.ID,
            ASIGES: _data.ASIGES,
            NUM_SINI: _claim.NUM_SINI,
            NUM_EXP: _claim.NUM_EXP,
            TALLER: app.ui.GetDropDownNumericValue('#taller'),
            TALLERDESC: app.ui.GetDropDownSelectedText('#taller'),
            FECHAENVIODELAVALUO: app.ui.GetDateValue('#fechaenviodelavaluo'),
            PREREPUESTOS: app.ui.GetNumericValue('#prerepuestos'),
            PREREPUESTOSDESC: app.ui.GetNumericValue('#prerepuestosdesc'),
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
            TIPOCAMBIO: app.ui.GetNumericValue('#TipoCambio'),
            ASESORTALLER: $('#asesorTaller').val(),
            EXPEDIENTE: $('#expediente').val(),
            ANALISTADEDANOS: app.ui.GetDropDownNumericValue('#analistadeDanos'),
            ANALISTADEDANOSDESC: app.ui.GetDropDownSelectedText('#analistadeDanos'),
            DEPRECIACIONYEXCLUSIONES: app.ui.GetNumericValue('#depreciacionyexclusiones'),
            PERDREPUESTO: app.ui.GetNumericValue('#perdrepuesto'),
            PERDREPUESTODESC: app.ui.GetNumericValue('#perdrepuestodesc'),
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
            DANOOCULTODESC: app.ui.GetNumericValue('#danoocultodesc'),
            OTROSIIOTROSIIDANOCULMANOTOTAL: app.ui.GetNumericValue('#otrosIIOtrosIIDanoocultomanototal'),
            PERDIDATMONTO: app.ui.GetNumericValue('#PERDIDATMONTO'),
            PERDIDATMONTOCOL: 0,
            PERDIDATMONTODOL: 0,
            DEDUCIBLECOL: 0,
            DEDUCIBLEDOL: 0
        };
        if (_claim.COD_MON === 2) {
            data.PERDIDATMONTODOL = data.PERDIDATMONTO;
            data.DEDUCIBLEDOL = _deducible;
        } else {
            data.PERDIDATMONTOCOL = data.PERDIDATMONTO;
            data.DEDUCIBLECOL = _deducible;
        }
        if (data.TIPOCAMBIO > 0 && data.PERDIDATMONTO > 0) {
            data.PERDIDATMONTOCOL = _claim.COD_MON === 2 ? data.PERDIDATMONTO * data.TIPOCAMBIO : data.PERDIDATMONTO;
            data.PERDIDATMONTODOL = _claim.COD_MON === 2 ? data.PERDIDATMONTO : data.PERDIDATMONTO / data.TIPOCAMBIO;
        }
        if (data.TIPOCAMBIO > 0 && _deducible > 0) {
            data.DEDUCIBLECOL = _claim.COD_MON === 2 ? _deducible * data.TIPOCAMBIO : _deducible;
            data.DEDUCIBLEDOL = _claim.COD_MON === 2 ? _deducible : _deducible / data.TIPOCAMBIO;
        }
        return data;
    };

    function MapObjectToInput(data) {
        _loadready = false;
        app.ui.SetDropDownNumericValue('#taller', data.TALLER, false);
        app.ui.SetDateValue('#fechaenviodelavaluo', data.FECHAENVIODELAVALUO);
        app.ui.SetNumericValue('#prerepuestos', data.PREREPUESTOS);
        app.ui.SetNumericValue('#prerepuestosdesc', data.PREREPUESTOSDESC);
        app.ui.SetNumericValue('#prerepuestosiva', data.PREREPUESTOSIVA);
        app.ui.SetNumericValue('#prerepuestostotal', data.PREREPUESTOSTOTAL);
        app.ui.SetNumericValue('#premano', data.PREMANO);
        app.ui.SetNumericValue('#premanoiva', data.PREMANOIVA);
        app.ui.SetNumericValue('#premanototal', data.PREMANOTOTAL);
        app.ui.SetNumericValue('#preperdida', data.PREPERDIDA);
        //app.ui.SetRadioNumericValue('autorizaciondeusopoliza', data.AUTORIZACIONDEUSOPOLIZA);
        //app.ui.SetDateValue('#fechaAutorizaciondeUsoPoliza', data.FECHAAUTORIZACIONDEUSOPOLIZA);
        app.ui.SetNumericValue('#oT', data.OT);
        app.ui.SetNumericValue('#TipoCambio', data.TIPOCAMBIO);
        $('#asesorTaller').val(data.ASESORTALLER);
        $('#expediente').val(data.EXPEDIENTE);
        app.ui.SetDropDownNumericValue('#analistadeDanos', data.ANALISTADEDANOS, false);
        app.ui.SetNumericValue('#depreciacionyexclusiones', data.DEPRECIACIONYEXCLUSIONES);

        app.ui.SetNumericValue('#perdrepuesto', data.PERDREPUESTO);
        app.ui.SetNumericValue('#perdrepuestodesc', data.PERDREPUESTODESC);
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
        app.ui.SetNumericValue('#danoocultodesc', data.DANOOCULTODESC);
        app.ui.SetNumericValue('#danoocultototal', data.DANOOCULTOTOTAL);
        app.ui.SetNumericValue('#danoocultomano', data.DANOOCULTOMANO);
        app.ui.SetNumericValue('#danoocultomanoiva', data.DANOOCULTOMANOIVA);
        app.ui.SetNumericValue('#danoocultomanototal', data.DANOOCULTOMANOTOTAL);
        app.ui.SetNumericValue('#otrosIIOtrosIIDanoocultomanototal', data.OTROSIIOTROSIIDANOCULMANOTOTAL);

        app.ui.SetNumericValue('#PERDIDATMONTO', data.PERDIDATMONTO);


        data_changed();
        _changed = false;
        _loadready = true;
    };

    function Controls_setup() {
        $('#fechaenviodelavaluo_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            minDate: moment('1900-01-01')
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
        new AutoNumeric('#prerepuestosdesc', {
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
            locale: 'es',
            minDate: moment('1900-01-01')
        });
        new AutoNumeric('#TipoCambio', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
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
        new AutoNumeric('#perdrepuestodesc', {
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
            locale: 'es',
            minDate: moment('1900-01-01')
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
        new AutoNumeric('#danoocultodesc', {
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
        new AutoNumeric('#PERDIDATMONTO', {
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
            locale: 'es',
            minDate: moment('1900-01-01')
        });
    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#PurdyPanelDanosEdtForm :input").change(function () {
            data_changed();
        });

        $('#PurdyPanelDanosEdtFormSave').click(function (e) {

            if (app.ui.IsValid('#PurdyPanelDanosEdtForm', false)) {
                app.ui.ButtonDoing('#PurdyPanelDanosEdtFormSave');
                let submitData = MapInputToObject();
                if (submitData.ID === null) {
                    app.core.datapi('POST', `PurdyPanelDano`, submitData)
                        .then(created => {
                            _data = submitData
                            _data.ID = created.Next.NEXTID
                            _loadready = true;
                            _changed = false;
                            _eventCallback('DanosDataChange', _data);
                            app.ui.CustomBehaviour('danoChanged', false);
                            app.ui.Success('La información del análisis del daño, fue actualizada de forma exitosa');

                        }).finally(() => {
                            app.ui.ButtonDone('#PurdyPanelDanosEdtFormSave');
                        });
                }
                else {
                    app.core.datapi('PUT', `PurdyPanelDano/${submitData.ID}`, submitData)
                        .then(updated => {
                            _data = submitData
                            _loadready = true;
                            _changed = false;
                            _eventCallback('DanosDataChange', _data);
                            app.ui.CustomBehaviour('danoChanged', false);
                            app.ui.Success('La información del análisis del daño, fue actualizada de forma exitosa');
                        }).finally(() => {
                            app.ui.ButtonDone('#PurdyPanelDanosEdtFormSave');
                        });
                }
            }
            e.preventDefault();
        });

        $('#PurdyPanelDanosEdtFormCancel').click(function (e) {
            Get(_data.ASIGES);
            e.preventDefault();
        });

    };

    function data_changed() {
        let taller = app.ui.GetDropDownNumericValue('#taller');

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
        if (_claim != null) {
            let tipoCambio = app.ui.GetNumericValue('#TipoCambio');
            if (tipoCambio === 0)
                tipoCambio = 1;
            _deducibleCol = _claim.COD_MON === 2 ? _deducible * tipoCambio : _deducible;

            if (_deducibleCol != _deducibleColOld) {
                _deducibleColOld = _deducibleCol;
                _eventCallback('DetalleDeducibleCol', _deducibleCol);
            }

            console.log('_deducibleCol', _deducibleCol);
        }
        app.ui.VisibleBehaviour('.presentadanooculto', app.ui.GetRadioNumericValue('presentadanooculto') === 1);

        if (app.ui.GetRadioNumericValue('presentadanooculto') === 2) {
            app.ui.SetDateValue('#fechasolicitado', null);
            $('#observaciones').val('');
            app.ui.SetNumericValue('#danoocultomontoRepuestosDanooculto', 0);
            app.ui.SetNumericValue('#danoocultoiva', 0);
            app.ui.SetNumericValue('#danoocultodesc', 0);
            app.ui.SetNumericValue('#danoocultototal', 0);
            app.ui.SetNumericValue('#danoocultomano', 0);
            app.ui.SetNumericValue('#danoocultomanoiva', 0);
            app.ui.SetNumericValue('#danoocultomanototal', 0);
            app.ui.SetNumericValue('#otrosIIOtrosIIDanoocultomanototal', 0);
        }
        let factor = 0.15;
        switch (taller) {
            case 1: //Purdy Auto SA
                factor = _empresa === 'Purdy Motor' ? 0.15 : 0.10;
                break;
            default: //otros talleres
                factor = _empresa === 'Purdy Motor' ? 0.20 : 0.15;
                break;

        }

        let danoocultomontoRep = app.ui.GetNumericValue('#danoocultomontoRepuestosDanooculto');
        let danoocultodesc = danoocultomontoRep * factor;
        let danoocultomontoRepsubtotal = danoocultomontoRep - danoocultodesc;
        $('#pordanoocultodesc').html((factor * 100).toString() + ' % Descuento');
        $('#pordanoocultodesc').attr('title', ' Empresa ' + _empresa);
        app.ui.SetNumericValue('#danoocultodesc', danoocultodesc);
        app.ui.SetNumericValue('#danoocultoiva', danoocultomontoRepsubtotal * 0.13);
        app.ui.SetNumericValue('#danoocultototal', danoocultomontoRepsubtotal * 1.13);
        app.ui.SetNumericValue('#danoocultomanoiva', app.ui.GetNumericValue('#danoocultomano') * 0.13);
        app.ui.SetNumericValue('#danoocultomanototal', app.ui.GetNumericValue('#danoocultomano') * 1.13);
        app.ui.SetNumericValue('#otrosIIOtrosIIDanoocultomanototal', (danoocultomontoRepsubtotal * 1.13) + (app.ui.GetNumericValue('#danoocultomano') * 1.13));

        let prerepuestos = app.ui.GetNumericValue('#prerepuestos');
        let prerepuestosdesc = prerepuestos * factor;
        let prerepuestossubtotal = prerepuestos - prerepuestosdesc;
        $('#porprerepuestosdesc').html((factor * 100).toString() + ' % Descuento');
        $('#porprerepuestosdesc').attr('title', ' Empresa ' + _empresa);
        app.ui.SetNumericValue('#prerepuestosdesc', prerepuestosdesc);
        app.ui.SetNumericValue('#prerepuestosiva', prerepuestossubtotal * 0.13);
        app.ui.SetNumericValue('#prerepuestostotal', prerepuestossubtotal * 1.13);
        app.ui.SetNumericValue('#premanoiva', app.ui.GetNumericValue('#premano') * 0.13);
        app.ui.SetNumericValue('#premanototal', app.ui.GetNumericValue('#premano') * 1.13);
        $('#preperdida').attr('title', _deducibleCol.toString() + ' de deducible');
        let preperdida = (prerepuestossubtotal * 1.13) + (app.ui.GetNumericValue('#premano') * 1.13) - _deducibleCol - app.ui.GetNumericValue('#depreciacionyexclusiones');
        if (preperdida < 0) {
            preperdida = 0;
        }
        $('#porperdrepuestodesc').html((factor * 100).toString() + ' % Descuento');
        $('#porperdrepuestodesc').attr('title', ' Empresa ' + _empresa);
        app.ui.SetNumericValue('#preperdida', preperdida);

        app.ui.SetNumericValue('#perdrepuesto', app.ui.GetNumericValue('#danoocultomontoRepuestosDanooculto') + app.ui.GetNumericValue('#prerepuestos'));
        app.ui.SetNumericValue('#perdrepuestodesc', app.ui.GetNumericValue('#danoocultodesc') + app.ui.GetNumericValue('#prerepuestosdesc'));
        app.ui.SetNumericValue('#perdrepuestoiva', app.ui.GetNumericValue('#danoocultoiva') + app.ui.GetNumericValue('#prerepuestosiva'));
        app.ui.SetNumericValue('#perdrepuestototal', app.ui.GetNumericValue('#danoocultototal') + app.ui.GetNumericValue('#prerepuestostotal'));
        app.ui.SetNumericValue('#perdmano', app.ui.GetNumericValue('#danoocultomano') + app.ui.GetNumericValue('#premano'));
        app.ui.SetNumericValue('#perdmanoiva', app.ui.GetNumericValue('#danoocultomanoiva') + app.ui.GetNumericValue('#premanoiva'));
        app.ui.SetNumericValue('#perdmanototal', app.ui.GetNumericValue('#perdmano') + app.ui.GetNumericValue('#perdmanoiva'));
        let perdida = app.ui.GetNumericValue('#perdrepuestototal') + app.ui.GetNumericValue('#perdmanototal') - _deducibleCol - app.ui.GetNumericValue('#depreciacionyexclusiones');
        if (perdida < 0) {
            perdida = 0;
        }
        app.ui.SetNumericValue('#perdida', perdida);


        if (_loadready) {
            _changed = true;
        }
        app.ui.CustomBehaviour('danoChanged', _loadready && _changed);
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
            PREREPUESTOSDESC: null,
            PREREPUESTOSIVA: null,
            PREREPUESTOSTOTAL: null,
            PREMANO: null,
            PREMANOIVA: null,
            PREMANOTOTAL: null,
            PREPERDIDA: null,
            AUTORIZACIONDEUSOPOLIZA: 2,
            FECHAAUTORIZACIONDEUSOPOLIZA: null,
            TIPOCAMBIO: null,
            OT: null,
            ASESORTALLER: null,
            EXPEDIENTE: null,
            ANALISTADEDANOS: null,
            DEPRECIACIONYEXCLUSIONES: null,
            PERDREPUESTO: null,
            PERDREPUESTODESC: null,
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
            DANOOCULTODESC: null,
            DANOOCULTOTOTAL: null,
            DANOOCULTOMANO: null,
            DANOOCULTOMANOIVA: null,
            DANOOCULTOMANOTOTAL: null,
            OTROSIIOTROSIIDANOCULMANOTOTAL: null,
            UPDATEUSERCODE: null,
            UPDATEDATE: null,
            PERDIDATMONTO: null
        };
        return data;
    };

    async function Get(asigesCode, claim, exp) {
        app.core.datapi('GET', `PurdyPanelDano/asiges?code=${asigesCode}&claim=${claim}&exp=${exp}`)
            .then(dataDanos => {

                if (dataDanos?.Danos === null) {
                    dataDanos.Danos = EmptyPurdyPanelDano();
                    dataDanos.Danos.ASIGES = asigesCode;
                }
                _data = dataDanos.Danos;
                MapObjectToInput(dataDanos.Danos);
                _eventCallback('DanosDataChange', dataDanos.Danos);

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

                    }, ``);
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Event: async function (src, data, eventData) {
            switch (src) {
                case 'ASIGESChange':
                    _loadready = false;
                    if (data.claim != null) {
                        _claim = data.claim;
                        Get(data.asiges, data.claim.NUM_SINI, data.claim.NUM_EXP);
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
                case 'DetalleDeducible':
                    _deducible = eventData;
                    data_changed();
                    break;
                case 'PolicyDataChange':
                    _empresa = eventData.empresa;
                    data_changed();
                    break;
            }
        }
    };
})();
