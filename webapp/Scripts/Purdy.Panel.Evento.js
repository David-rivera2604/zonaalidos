var app = app || {};

app.PurdyPanelEvento = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {

        //app.core.Get(app.setting.apipath + 'v1/Quote/EventoSetup', null,
        //    function (data) {
        //        app.core.Lookups([],
        //            function () {
        //                setupData = data;
        //                MapObjectToInput(data);
        //            }, ``);

        //    });
    };

    function ReadOnly() {
        $('#fechadelevento_group').replaceWith('<div>' + $('#fechadelevento').val() + '</div>');
        $('#analistaReclamos').replaceWith('<div>' + $('#analistaReclamos option:selected').text() + '</div>');
        $('#motivoNoProcede').replaceWith('<div>' + $('#motivoNoProcede option:selected').text() + '</div>');
        $('#detalleNoprocede').replaceWith('<div>' + $('#detalleNoprocede').val() + '</div>');
        $('#detalleSiniestro').replaceWith('<div>' + $('#detalleSiniestro').val() + '</div>');
        $('#tipodeCobertura').replaceWith('<div>' + $('#tipodeCobertura option:selected').text() + '</div>');
        $('#categoriadeSiniestro').replaceWith('<div>' + $('#categoriadeSiniestro option:selected').text() + '</div>');
        $('#fechaidentificadocomoPosibleSubrogacion_group').replaceWith('<div>' + $('#fechaidentificadocomoPosibleSubrogacion').val() + '</div>');
        $('#fechaEnviadoaInvestigacion_group').replaceWith('<div>' + $('#fechaEnviadoaInvestigacion').val() + '</div>');
        $('#fechaEnviadoaAcompanamientoLegal_group').replaceWith('<div>' + $('#fechaEnviadoaAcompanamientoLegal').val() + '</div>');
        $('#fechaAutorizaciondeUsoPoliza_group').replaceWith('<div>' + $('#fechaAutorizaciondeUsoPoliza').val() + '</div>');

    };

    function MapInputToObject() {
        var data = {
            fechadelevento: app.ui.GetDateValue('#fechadelevento'),
            analistaReclamos: app.ui.GetDropDownNumericValue('#analistaReclamos'),
            analistaReclamosDesc: app.ui.GetDropDownSelectedText('#analistaReclamos'),
            motivoNoProcede: app.ui.GetDropDownNumericValue('#motivoNoProcede'),
            motivoNoProcedeDesc: app.ui.GetDropDownSelectedText('#motivoNoProcede'),
            detalleNoprocede: $('#detalleNoprocede').val(),
            detalleSiniestro: $('#detalleSiniestro').val(),
            tipodeCobertura: app.ui.GetDropDownNumericValue('#tipodeCobertura'),
            tipodeCoberturaDesc: app.ui.GetDropDownSelectedText('#tipodeCobertura'),
            categoriadeSiniestro: app.ui.GetDropDownNumericValue('#categoriadeSiniestro'),
            categoriadeSiniestroDesc: app.ui.GetDropDownSelectedText('#categoriadeSiniestro'),
            fechaidentificadocomoPosibleSubrogacion: app.ui.GetDateValue('#fechaidentificadocomoPosibleSubrogacion'),
            fechaEnviadoaInvestigacion: app.ui.GetDateValue('#fechaEnviadoaInvestigacion'),
            fechaEnviadoaAcompanamientoLegal: app.ui.GetDateValue('#fechaEnviadoaAcompanamientoLegal'),
            fechaAutorizaciondeUsoPoliza: app.ui.GetDateValue('#fechaAutorizaciondeUsoPoliza'),

        };
        return data;
    };

    function MapObjectToInput(data) {
        app.ui.SetDateValue('#fechadelevento', data.fechadelevento);
        app.ui.SetDropDownNumericValue('#analistaReclamos', data.analistaReclamos, true);
        app.ui.SetDropDownNumericValue('#motivoNoProcede', data.motivoNoProcede, true);
        $('#detalleNoprocede').val(data.detalleNoprocede);
        $('#detalleSiniestro').val(data.detalleSiniestro);
        app.ui.SetDropDownNumericValue('#tipodeCobertura', data.tipodeCobertura, true);
        app.ui.SetDropDownNumericValue('#categoriadeSiniestro', data.categoriadeSiniestro, true);
        app.ui.SetDateValue('#fechaidentificadocomoPosibleSubrogacion', data.fechaidentificadocomoPosibleSubrogacion);
        app.ui.SetDateValue('#fechaEnviadoaInvestigacion', data.fechaEnviadoaInvestigacion);
        app.ui.SetDateValue('#fechaEnviadoaAcompanamientoLegal', data.fechaEnviadoaAcompanamientoLegal);
        app.ui.SetDateValue('#fechaAutorizaciondeUsoPoliza', data.fechaAutorizaciondeUsoPoliza);

    };

    function Controls_setup() {
        $('#fechadelevento_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechaidentificadocomoPosibleSubrogacion_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechaEnviadoaInvestigacion_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechaEnviadoaAcompanamientoLegal_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechaAutorizaciondeUsoPoliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });

    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#PanelPurdyEventoEdtForm :input").change(function () {
            data_changed();
        });


        $('#PanelPurdyEventoEdtFormSave').click(function () {

            if (app.ui.IsValid('#PanelPurdyEventoEdtForm', false)) {
                app.ui.ButtonDoing('#PanelPurdyEventoEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/PanelPurdy/Evento',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {

                        }

                    }).always(function () {
                        app.ui.ButtonDone('#PanelPurdyEventoEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#PanelPurdyEventoEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#PanelPurdyEventoEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PanelPurdyEventoEdtFormCancel'); }, 3000);
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
        $("#PanelPurdyEventoEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {},
            messages: {}
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
            return app.ui.IsValid('#PanelPurdyEventoEdtForm', false, showResume);
        }
    };
})();


