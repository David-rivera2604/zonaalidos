var app = app || {};

app.PurdyPanelEncabezado = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {

        //app.core.Get(app.setting.apipath + 'v1/Quote/EncabezadoSetup', null,
        //    function (data) {
        //        app.core.Lookups([],
        //            function () {
        //                setupData = data;
        //                MapObjectToInput(data);
        //            }, ``);

        //    });
    };

    function ReadOnly() {
        $('#aSIGES').replaceWith('<div>' + $('#aSIGES').val() + '</div>');
        $('#tipodeIndemnizacion').replaceWith('<div>' + $('#tipodeIndemnizacion option:selected').text() + '</div>');
        $('#estadoMapfre').replaceWith('<div>' + $('#estadoMapfre option:selected').text() + '</div>');
        $('#numerodepoliza').replaceWith('<div>' + $('#numerodepoliza').val() + '</div>');
        $('#nombreAsegurado').replaceWith('<div>' + $('#nombreAsegurado').val() + '</div>');
        $('#DocumentNumber').replaceWith('<div>' + $('#DocumentNumber').val() + '</div>');
        $('#correoAsegurado').replaceWith('<div>' + $('#correoAsegurado').val() + '</div>');
        $('#telefonoAsegurado').replaceWith('<div>' + $('#telefonoAsegurado').val() + '</div>');
        $('#ingresodeaviso_group').replaceWith('<div>' + $('#ingresodeaviso').val() + '</div>');
        $('#fechadelevento_group').replaceWith('<div>' + $('#fechadelevento').val() + '</div>');
        $('#noSiniestro').replaceWith('<div>' + $('#noSiniestro').val() + '</div>');
        $('#analistaReclamos').replaceWith('<div>' + $('#analistaReclamos option:selected').text() + '</div>');
        $('#analistaGestora').replaceWith('<div>' + $('#analistaGestora option:selected').text() + '</div>');
        $('#tipodeIndemnizacion').replaceWith('<div>' + $('#tipodeIndemnizacion option:selected').text() + '</div>');
        $('#detalleSiniestro').replaceWith('<div>' + $('#detalleSiniestro').val() + '</div>');
        $('#categoriadeSiniestro').replaceWith('<div>' + $('#categoriadeSiniestro option:selected').text() + '</div>');

    };

    function MapInputToObject() {
        var data = {
            aSIGES: $('#aSIGES').val(),
            tipodeIndemnizacion: app.ui.GetDropDownNumericValue('#tipodeIndemnizacion'),
            tipodeIndemnizacionDesc: app.ui.GetDropDownSelectedText('#tipodeIndemnizacion'),
            estadoMapfre: app.ui.GetDropDownNumericValue('#estadoMapfre'),
            estadoMapfreDesc: app.ui.GetDropDownSelectedText('#estadoMapfre'),
            numerodepoliza: $('#numerodepoliza').val(),
            nombreAsegurado: $('#nombreAsegurado').val(),
            DocumentNumber: $('#DocumentNumber').val(),
            correoAsegurado: $('#correoAsegurado').val(),
            telefonoAsegurado: $('#telefonoAsegurado').val(),
            ingresodeaviso: app.ui.GetDateValue('#ingresodeaviso'),
            fechadelevento: app.ui.GetDateValue('#fechadelevento'),
            noSiniestro: $('#noSiniestro').val(),
            analistaReclamos: app.ui.GetDropDownNumericValue('#analistaReclamos'),
            analistaReclamosDesc: app.ui.GetDropDownSelectedText('#analistaReclamos'),
            analistaGestora: app.ui.GetDropDownNumericValue('#analistaGestora'),
            analistaGestoraDesc: app.ui.GetDropDownSelectedText('#analistaGestora'),
            tipodeIndemnizacion: app.ui.GetDropDownNumericValue('#tipodeIndemnizacion'),
            tipodeIndemnizacionDesc: app.ui.GetDropDownSelectedText('#tipodeIndemnizacion'),
            detalleSiniestro: $('#detalleSiniestro').val(),
            categoriadeSiniestro: app.ui.GetDropDownNumericValue('#categoriadeSiniestro'),
            categoriadeSiniestroDesc: app.ui.GetDropDownSelectedText('#categoriadeSiniestro'),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#aSIGES').val(data.aSIGES);
        app.ui.SetDropDownNumericValue('#tipodeIndemnizacion', data.tipodeIndemnizacion, true);
        app.ui.SetDropDownNumericValue('#estadoMapfre', data.estadoMapfre, true);
        $('#numerodepoliza').val(data.numerodepoliza);
        $('#nombreAsegurado').val(data.nombreAsegurado);
        $('#DocumentNumber').val(data.DocumentNumber);
        $('#correoAsegurado').val(data.correoAsegurado);
        $('#telefonoAsegurado').val(data.telefonoAsegurado);
        app.ui.SetDateValue('#ingresodeaviso', data.ingresodeaviso);
        app.ui.SetDateValue('#fechadelevento', data.fechadelevento);
        $('#noSiniestro').val(data.noSiniestro);
        app.ui.SetDropDownNumericValue('#analistaReclamos', data.analistaReclamos, true);
        app.ui.SetDropDownNumericValue('#analistaGestora', data.analistaGestora, true);
        app.ui.SetDropDownNumericValue('#tipodeIndemnizacion', data.tipodeIndemnizacion, true);
        $('#detalleSiniestro').val(data.detalleSiniestro);
        app.ui.SetDropDownNumericValue('#categoriadeSiniestro', data.categoriadeSiniestro, true);

    };

    function Controls_setup() {
        $('#DocumentNumber').formatter({
            pattern: '0{{9}}-{{9999}}-{{9999}}',
            persistent: false
        });
        $('#telefonoAsegurado').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#ingresodeaviso_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechadelevento_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });

    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#PanelPurdyEncabezadoEdtForm :input").change(function () {
            data_changed();
        });

        $('#DocumentNumberTypeMenu a').click(function () {
            app.ui.DocumentTypeHandler(this, '#DocumentNumber', 'Identification');
        });

        $('#DocumentNumber').on('blur', function () {
            if (app.ui.IsDocumentNumberValid($('#DocumentNumberType').data('value'), $('#DocumentNumber').val())) {
                var value = $('#DocumentNumber').val().replace(/-/g, '');
                if (value !== null && parseInt(0 + value, 10) !== 0 && parseInt(0 + value, 10) <= 999999999) {
                    $('#DocumentNumber').addClass('loading');
                    app.core.GetExt('https://www.inmotiontools.com:8083/logic/api/padron/personaporcedula?cedula=' + parseInt(0 + value, 10))
                        .done(function (data, textStatus, jqXHR) {
                            if (data.Nombre !== null) {
                                alert(data.Nombre);
                            }
                        }).always(function () {
                            $('#DocumentNumber').removeClass('loading');
                        });
                }
            }
        });
        $('#telefonoAseguradoTypeMenu a').click(function () {
            app.ui.DocumentTypeHandler(this, '#telefonoAsegurado', 'Phone');
        });

        $('#PanelPurdyEncabezadoEdtFormSave').click(function () {

            if (app.ui.IsValid('#PanelPurdyEncabezadoEdtForm', false)) {
                app.ui.ButtonDoing('#PanelPurdyEncabezadoEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/PanelPurdy/Encabezado',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {

                        }

                    }).always(function () {
                        app.ui.ButtonDone('#PanelPurdyEncabezadoEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#PanelPurdyEncabezadoEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#PanelPurdyEncabezadoEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PanelPurdyEncabezadoEdtFormCancel'); }, 3000);
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
        $("#PanelPurdyEncabezadoEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                aSIGES: { required: true },
                correoAsegurado: { email: true },
            },
            messages: {
                aSIGES: { required: 'Debe indicar el asiges' },
                correoAsegurado: { email: 'Debe indicar un correo electrónico valido' },
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
            return app.ui.IsValid('#PanelPurdyEncabezadoEdtForm', false, showResume);
        }
    };
})();


