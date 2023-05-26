var app = app || {};
app.PurdyPanelDanos = (function () {

    let _eventCallback = null;
    var setupData = null;
    var changedCallback = null;

    function Setup() {

        //app.core.Get(app.setting.apipath + 'v1/Quote/DanosSetup', null,
        //    function (data) {
        //        app.core.Lookups([],
        //            function () {
        //                setupData = data;
        //                MapObjectToInput(data);
        //            }, ``);

        //    });
    };

    function ReadOnly() {
        $('#taller').replaceWith('<div>' + $('#taller option:selected').text() + '</div>');
        $('#fechaenviodelavaluo_group').replaceWith('<div>' + $('#fechaenviodelavaluo').val() + '</div>');
        $('#montopreliminardeperdidaRepuestos').replaceWith('<div>' + $('#montopreliminardeperdidaRepuestos').val() + '</div>');
        $('#aMontoneto').replaceWith('<div>' + $('#aMontoneto').val() + '</div>');
        $('#bIVA').replaceWith('<div>' + $('#bIVA').val() + '</div>');
        $('#cMontototal').replaceWith('<div>' + $('#cMontototal').val() + '</div>');
        $('#montopreliminardeperdidaManodeObra').replaceWith('<div>' + $('#montopreliminardeperdidaManodeObra').val() + '</div>');
        $('#aMontoneto').replaceWith('<div>' + $('#aMontoneto').val() + '</div>');
        $('#bIVA').replaceWith('<div>' + $('#bIVA').val() + '</div>');
        $('#cMontototal').replaceWith('<div>' + $('#cMontototal').val() + '</div>');
        $('#montopreliminardePerdida').replaceWith('<div>' + $('#montopreliminardePerdida').val() + '</div>');
        $('#fechaAutorizaciondeUsoPoliza_group').replaceWith('<div>' + $('#fechaAutorizaciondeUsoPoliza').val() + '</div>');
        $('#oT').replaceWith('<div>' + $('#oT').val() + '</div>');
        $('#asesorTaller').replaceWith('<div>' + $('#asesorTaller').val() + '</div>');
        $('#expediente').replaceWith('<div>' + $('#expediente').val() + '</div>');
        $('#analistadeDanos').replaceWith('<div>' + $('#analistadeDanos option:selected').text() + '</div>');
        $('#depreciacionyExclusiones').replaceWith('<div>' + $('#depreciacionyExclusiones').val() + '</div>');
        $('#montototaldeperdidaRepuestos').replaceWith('<div>' + $('#montototaldeperdidaRepuestos').val() + '</div>');
        $('#aMontoneto').replaceWith('<div>' + $('#aMontoneto').val() + '</div>');
        $('#bIVA').replaceWith('<div>' + $('#bIVA').val() + '</div>');
        $('#cMontototal').replaceWith('<div>' + $('#cMontototal').val() + '</div>');
        $('#montototaldeperdidaManodeObra').replaceWith('<div>' + $('#montototaldeperdidaManodeObra').val() + '</div>');
        $('#aMontoneto').replaceWith('<div>' + $('#aMontoneto').val() + '</div>');
        $('#bIVA').replaceWith('<div>' + $('#bIVA').val() + '</div>');
        $('#cMontototal').replaceWith('<div>' + $('#cMontototal').val() + '</div>');
        $('#montoTotaldePerdida').replaceWith('<div>' + $('#montoTotaldePerdida').val() + '</div>');
        $('#severidaddelsiniestro').replaceWith('<div>' + $('#severidaddelsiniestro option:selected').text() + '</div>');
        $('#fechaAutorizacion_group').replaceWith('<div>' + $('#fechaAutorizacion').val() + '</div>');
        $('#tipodePerdidaTotal').replaceWith('<div>' + $('#tipodePerdidaTotal option:selected').text() + '</div>');
        $('#danoOculto').replaceWith('<div>' + $('#danoOculto').val() + '</div>');
        $('#danoOcultoFechaSolicitado_group').replaceWith('<div>' + $('#danoOcultoFechaSolicitado').val() + '</div>');
        $('#danoOcultoObservaciones').replaceWith('<div>' + $('#danoOcultoObservaciones').val() + '</div>');
        $('#danoOcultoMontoRepuestos').replaceWith('<div>' + $('#danoOcultoMontoRepuestos').val() + '</div>');
        $('#aMontoneto').replaceWith('<div>' + $('#aMontoneto').val() + '</div>');
        $('#bIVA').replaceWith('<div>' + $('#bIVA').val() + '</div>');
        $('#cMontototal').replaceWith('<div>' + $('#cMontototal').val() + '</div>');
        $('#danoOcultoMontoManodeObra').replaceWith('<div>' + $('#danoOcultoMontoManodeObra').val() + '</div>');
        $('#aMontoneto').replaceWith('<div>' + $('#aMontoneto').val() + '</div>');
        $('#bIVA').replaceWith('<div>' + $('#bIVA').val() + '</div>');
        $('#cMontototal').replaceWith('<div>' + $('#cMontototal').val() + '</div>');
        $('#danoOcultoMontoTotal').replaceWith('<div>' + $('#danoOcultoMontoTotal').val() + '</div>');

    };

    function MapInputToObject() {
        var data = {
            taller: app.ui.GetDropDownNumericValue('#taller'),
            tallerDesc: app.ui.GetDropDownSelectedText('#taller'),
            fechaenviodelavaluo: app.ui.GetDateValue('#fechaenviodelavaluo'),
            montopreliminardeperdidaRepuestos: app.ui.GetNumericValue('#montopreliminardeperdidaRepuestos'),
            aMontoneto: app.ui.GetNumericValue('#aMontoneto'),
            bIVA: app.ui.GetNumericValue('#bIVA'),
            cMontototal: app.ui.GetNumericValue('#cMontototal'),
            montopreliminardeperdidaManodeObra: app.ui.GetNumericValue('#montopreliminardeperdidaManodeObra'),
            aMontoneto: app.ui.GetNumericValue('#aMontoneto'),
            bIVA: app.ui.GetNumericValue('#bIVA'),
            cMontototal: app.ui.GetNumericValue('#cMontototal'),
            montopreliminardePerdida: app.ui.GetNumericValue('#montopreliminardePerdida'),
            fechaAutorizaciondeUsoPoliza: app.ui.GetDateValue('#fechaAutorizaciondeUsoPoliza'),
            oT: app.ui.GetNumericValue('#oT'),
            asesorTaller: $('#asesorTaller').val(),
            expediente: $('#expediente').val(),
            analistadeDanos: app.ui.GetDropDownNumericValue('#analistadeDanos'),
            analistadeDanosDesc: app.ui.GetDropDownSelectedText('#analistadeDanos'),
            depreciacionyExclusiones: app.ui.GetNumericValue('#depreciacionyExclusiones'),
            montototaldeperdidaRepuestos: app.ui.GetNumericValue('#montototaldeperdidaRepuestos'),
            aMontoneto: app.ui.GetNumericValue('#aMontoneto'),
            bIVA: app.ui.GetNumericValue('#bIVA'),
            cMontototal: app.ui.GetNumericValue('#cMontototal'),
            montototaldeperdidaManodeObra: app.ui.GetNumericValue('#montototaldeperdidaManodeObra'),
            aMontoneto: app.ui.GetNumericValue('#aMontoneto'),
            bIVA: app.ui.GetNumericValue('#bIVA'),
            cMontototal: app.ui.GetNumericValue('#cMontototal'),
            montoTotaldePerdida: app.ui.GetNumericValue('#montoTotaldePerdida'),
            severidaddelsiniestro: app.ui.GetDropDownNumericValue('#severidaddelsiniestro'),
            severidaddelsiniestroDesc: app.ui.GetDropDownSelectedText('#severidaddelsiniestro'),
            fechaAutorizacion: app.ui.GetDateValue('#fechaAutorizacion'),
            tipodePerdidaTotal: app.ui.GetDropDownNumericValue('#tipodePerdidaTotal'),
            tipodePerdidaTotalDesc: app.ui.GetDropDownSelectedText('#tipodePerdidaTotal'),
            danoOculto: app.ui.GetNumericValue('#danoOculto'),
            danoOcultoFechaSolicitado: app.ui.GetDateValue('#danoOcultoFechaSolicitado'),
            danoOcultoObservaciones: $('#danoOcultoObservaciones').val(),
            danoOcultoMontoRepuestos: app.ui.GetNumericValue('#danoOcultoMontoRepuestos'),
            aMontoneto: app.ui.GetNumericValue('#aMontoneto'),
            bIVA: app.ui.GetNumericValue('#bIVA'),
            cMontototal: app.ui.GetNumericValue('#cMontototal'),
            danoOcultoMontoManodeObra: app.ui.GetNumericValue('#danoOcultoMontoManodeObra'),
            aMontoneto: app.ui.GetNumericValue('#aMontoneto'),
            bIVA: app.ui.GetNumericValue('#bIVA'),
            cMontototal: app.ui.GetNumericValue('#cMontototal'),
            danoOcultoMontoTotal: app.ui.GetNumericValue('#danoOcultoMontoTotal'),

        };
        return data;
    };

    function MapObjectToInput(data) {
        app.ui.SetDropDownNumericValue('#taller', data.taller, true);
        app.ui.SetDateValue('#fechaenviodelavaluo', data.fechaenviodelavaluo);
        app.ui.SetNumericValue('#montopreliminardeperdidaRepuestos', data.montopreliminardeperdidaRepuestos);
        app.ui.SetNumericValue('#aMontoneto', data.aMontoneto);
        app.ui.SetNumericValue('#bIVA', data.bIVA);
        app.ui.SetNumericValue('#cMontototal', data.cMontototal);
        app.ui.SetNumericValue('#montopreliminardeperdidaManodeObra', data.montopreliminardeperdidaManodeObra);
        app.ui.SetNumericValue('#aMontoneto', data.aMontoneto);
        app.ui.SetNumericValue('#bIVA', data.bIVA);
        app.ui.SetNumericValue('#cMontototal', data.cMontototal);
        app.ui.SetNumericValue('#montopreliminardePerdida', data.montopreliminardePerdida);
        app.ui.SetDateValue('#fechaAutorizaciondeUsoPoliza', data.fechaAutorizaciondeUsoPoliza);
        app.ui.SetNumericValue('#oT', data.oT);
        $('#asesorTaller').val(data.asesorTaller);
        $('#expediente').val(data.expediente);
        app.ui.SetDropDownNumericValue('#analistadeDanos', data.analistadeDanos, true);
        app.ui.SetNumericValue('#depreciacionyExclusiones', data.depreciacionyExclusiones);
        app.ui.SetNumericValue('#montototaldeperdidaRepuestos', data.montototaldeperdidaRepuestos);
        app.ui.SetNumericValue('#aMontoneto', data.aMontoneto);
        app.ui.SetNumericValue('#bIVA', data.bIVA);
        app.ui.SetNumericValue('#cMontototal', data.cMontototal);
        app.ui.SetNumericValue('#montototaldeperdidaManodeObra', data.montototaldeperdidaManodeObra);
        app.ui.SetNumericValue('#aMontoneto', data.aMontoneto);
        app.ui.SetNumericValue('#bIVA', data.bIVA);
        app.ui.SetNumericValue('#cMontototal', data.cMontototal);
        app.ui.SetNumericValue('#montoTotaldePerdida', data.montoTotaldePerdida);
        app.ui.SetDropDownNumericValue('#severidaddelsiniestro', data.severidaddelsiniestro, true);
        app.ui.SetDateValue('#fechaAutorizacion', data.fechaAutorizacion);
        app.ui.SetDropDownNumericValue('#tipodePerdidaTotal', data.tipodePerdidaTotal, true);
        app.ui.SetNumericValue('#danoOculto', data.danoOculto);
        app.ui.SetDateValue('#danoOcultoFechaSolicitado', data.danoOcultoFechaSolicitado);
        $('#danoOcultoObservaciones').val(data.danoOcultoObservaciones);
        app.ui.SetNumericValue('#danoOcultoMontoRepuestos', data.danoOcultoMontoRepuestos);
        app.ui.SetNumericValue('#aMontoneto', data.aMontoneto);
        app.ui.SetNumericValue('#bIVA', data.bIVA);
        app.ui.SetNumericValue('#cMontototal', data.cMontototal);
        app.ui.SetNumericValue('#danoOcultoMontoManodeObra', data.danoOcultoMontoManodeObra);
        app.ui.SetNumericValue('#aMontoneto', data.aMontoneto);
        app.ui.SetNumericValue('#bIVA', data.bIVA);
        app.ui.SetNumericValue('#cMontototal', data.cMontototal);
        app.ui.SetNumericValue('#danoOcultoMontoTotal', data.danoOcultoMontoTotal);

    };

    function Controls_setup() {
        $('#fechaenviodelavaluo_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#montopreliminardeperdidaRepuestos', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#aMontoneto', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#bIVA', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#cMontototal', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montopreliminardeperdidaManodeObra', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#aMontoneto', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#bIVA', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#cMontototal', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montopreliminardePerdida', {
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
        new AutoNumeric('#depreciacionyExclusiones', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montototaldeperdidaRepuestos', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#aMontoneto', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#bIVA', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#cMontototal', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montototaldeperdidaManodeObra', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#aMontoneto', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#bIVA', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#cMontototal', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoTotaldePerdida', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#fechaAutorizacion_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#danoOculto', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        $('#danoOcultoFechaSolicitado_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#danoOcultoMontoRepuestos', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#aMontoneto', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#bIVA', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#cMontototal', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#danoOcultoMontoManodeObra', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#aMontoneto', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#bIVA', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#cMontototal', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#danoOcultoMontoTotal', {
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
        $("#PanelPurdyDanosEdtForm :input").change(function () {
            data_changed();
        });


        $('#PanelPurdyDanosEdtFormSave').click(function () {

            if (app.ui.IsValid('#PanelPurdyDanosEdtForm', false)) {
                app.ui.ButtonDoing('#PanelPurdyDanosEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/PanelPurdy/Danos',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {

                        }

                    }).always(function () {
                        app.ui.ButtonDone('#PanelPurdyDanosEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#PanelPurdyDanosEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#PanelPurdyDanosEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PanelPurdyDanosEdtFormCancel'); }, 3000);
            event.preventDefault();
        });

    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#PanelPurdyDanosEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {},
            messages: {}
        });
    };



    return {
        Init: function (eventCallback) {
            _eventCallback = eventCallback;
            try {
                Controls_setup();
                Setup_Validations();

                Controls_Events();
                Setup();
                //Custom.Extend
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
        SetData: function (data) {
            MapObjectToInput(data);
        },
        Changed: function (callback) {
            changedCallback = callback;
        },
        IsValid: function (showResume) {
            return app.ui.IsValid('#PanelPurdyDanosEdtForm', false, showResume);
        }
    };
})();


