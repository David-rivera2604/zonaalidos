var app = app || {};

app.PurdyPanelEvento = (function () {

    let _eventCallback = null;
    var setupData = null;
    var changedCallback = null;

    function MapInputToObject() {
        var data = {
            fechadelevento: app.ui.GetDateValue('#fechadelevento'),
            analistareclamos: app.ui.GetDropDownNumericValue('#analistareclamos'),
            analistareclamosDesc: app.ui.GetDropDownSelectedText('#analistareclamos'),
            tipodeindemnizacion: app.ui.GetDropDownNumericValue('#tipodeindemnizacion'),
            tipodeindemnizacionDesc: app.ui.GetDropDownSelectedText('#tipodeindemnizacion'),
            motivonoProcede: app.ui.GetDropDownNumericValue('#motivonoProcede'),
            motivonoProcedeDesc: app.ui.GetDropDownSelectedText('#motivonoProcede'),
            detallenoprocede: $('#detallenoprocede').val(),
            detallesiniestro: $('#detallesiniestro').val(),
            tipodecobertura: app.ui.GetDropDownNumericValue('#tipodecobertura'),
            tipodecoberturaDesc: app.ui.GetDropDownSelectedText('#tipodecobertura'),
            categoriadesiniestro: app.ui.GetDropDownNumericValue('#categoriadesiniestro'),
            categoriadesiniestroDesc: app.ui.GetDropDownSelectedText('#categoriadesiniestro'),
            posiblesubrogacion: app.ui.GetRadioNumericValue('posiblesubrogacion'),
            posiblesubrogacionDesc: app.ui.GetRadioSelectedText('posiblesubrogacion'),
            fechaidentificadocomoPosibleSubrogacion: app.ui.GetDateValue('#fechaidentificadocomoPosibleSubrogacion'),
            enviadoaInvestigacion: app.ui.GetRadioNumericValue('enviadoaInvestigacion'),
            enviadoaInvestigacionDesc: app.ui.GetRadioSelectedText('enviadoaInvestigacion'),
            fechaenviadoainvestigacion: app.ui.GetDateValue('#fechaenviadoainvestigacion'),
            enviadoaacompanamientoLegal: app.ui.GetRadioNumericValue('enviadoaacompanamientoLegal'),
            enviadoaacompanamientoLegalDesc: app.ui.GetRadioSelectedText('enviadoaacompanamientoLegal'),
            fechaenviadoaacompanamientoLegal: app.ui.GetDateValue('#fechaenviadoaacompanamientoLegal'),
            infraseguro: app.ui.GetRadioNumericValue('infraseguro'),
            infraseguroDesc: app.ui.GetRadioSelectedText('infraseguro'),
            autorizaciondeusopoliza: app.ui.GetRadioNumericValue('autorizaciondeusopoliza'),
            autorizaciondeusopolizaDesc: app.ui.GetRadioSelectedText('autorizaciondeusopoliza'),
            fechaautorizaciondeusopoliza: app.ui.GetDateValue('#fechaautorizaciondeusopoliza'),

        };
        return data;
    };

    function MapObjectToInput(data) {
        app.ui.SetDateValue('#fechadelevento', data.fechadelevento);
        app.ui.SetDropDownNumericValue('#analistareclamos', data.analistareclamos, true);
        app.ui.SetDropDownNumericValue('#tipodeindemnizacion', data.tipodeindemnizacion, true, 7);
        app.ui.SetDropDownNumericValue('#motivonoProcede', data.motivonoProcede, true);
        $('#detallenoprocede').val(data.detallenoprocede);
        $('#detallesiniestro').val(data.detallesiniestro);
        app.ui.SetDropDownNumericValue('#tipodecobertura', data.tipodecobertura, true);
        app.ui.SetDropDownNumericValue('#categoriadesiniestro', data.categoriadesiniestro, true);
        app.ui.SetRadioNumericValue('posiblesubrogacion', data.posiblesubrogacion);
        app.ui.SetDateValue('#fechaidentificadocomoPosibleSubrogacion', data.fechaidentificadocomoPosibleSubrogacion);
        app.ui.SetRadioNumericValue('enviadoaInvestigacion', data.enviadoaInvestigacion);
        app.ui.SetDateValue('#fechaenviadoainvestigacion', data.fechaenviadoainvestigacion);
        app.ui.SetRadioNumericValue('enviadoaacompanamientoLegal', data.enviadoaacompanamientoLegal);
        app.ui.SetDateValue('#fechaenviadoaacompanamientoLegal', data.fechaenviadoaacompanamientoLegal);
        app.ui.SetRadioNumericValue('infraseguro', data.infraseguro);
        app.ui.SetRadioNumericValue('autorizaciondeusopoliza', data.autorizaciondeusopoliza);
        app.ui.SetDateValue('#fechaautorizaciondeusopoliza', data.fechaautorizaciondeusopoliza);

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
        $('#fechaenviadoainvestigacion_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechaenviadoaacompanamientoLegal_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechaautorizaciondeusopoliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });

    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#PurdyPanelEventoEdtForm :input").change(function () {
            data_changed();
        });


        $('#PurdyPanelEventoEdtFormSave').click(function () {

            if (app.ui.IsValid('#PurdyPanelEventoEdtForm', false)) {
                app.ui.ButtonDoing('#PurdyPanelEventoEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/Purdy/PanelEvento',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {

                        }

                    }).always(function () {
                        app.ui.ButtonDone('#PurdyPanelEventoEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#PurdyPanelEventoEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#PurdyPanelEventoEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PurdyPanelEventoEdtFormCancel'); }, 3000);
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
        $("#PurdyPanelEventoEdtForm").validate({
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