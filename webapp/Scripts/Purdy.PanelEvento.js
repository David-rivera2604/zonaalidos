var app = app || {};

app.PurdyPanelEvento = (function () {

    let _eventCallback = null;
    let _data = null;
    let _loadready = false;
    let _changed = false;

    function MapInputToObject() {
        var data = {
            ID: _data.ID,
            ASIGES: _data.ASIGES,
            FECHADELEVENTO: app.ui.GetDateValue('#fechadelevento'),
            ANALISTARECLAMOS: app.ui.GetDropDownNumericValue('#analistareclamos'),
            ANALISTARECLAMOSDESC: app.ui.GetDropDownSelectedText('#analistareclamos'),
            TIPODEINDEMNIZACION: app.ui.GetDropDownNumericValue('#tipodeindemnizacion'),
            TIPODEINDEMNIZACIONDESC: app.ui.GetDropDownSelectedText('#tipodeindemnizacion'),
            MOTIVONOPROCEDE: app.ui.GetDropDownNumericValue('#motivonoProcede'),
            MOTIVONOPROCEDEDESC: app.ui.GetDropDownSelectedText('#motivonoProcede'),
            DETALLENOPROCEDE: $('#detallenoprocede').val(),
            TIPODECOBERTURA: app.ui.GetDropDownNumericValue('#tipodecobertura'),
            TIPODECOBERTURADESC: app.ui.GetDropDownSelectedText('#tipodecobertura'),
            CATEGORIADESINIESTRO: app.ui.GetDropDownNumericValue('#categoriadesiniestro'),
            CATEGORIADESINIESTRODESC: app.ui.GetDropDownSelectedText('#categoriadesiniestro'),
            POSIBLESUBROGACION: app.ui.GetRadioNumericValue('posiblesubrogacion'),
            POSIBLESUBROGACIONDESC: app.ui.GetRadioSelectedText('posiblesubrogacion'),
            FECHAPOSIBLESUBROGACION: app.ui.GetDateValue('#fechaidentificadocomoPosibleSubrogacion'),
            ENVIADOAINVESTIGACION: app.ui.GetRadioNumericValue('enviadoaInvestigacion'),
            ENVIADOAINVESTIGACIONDESC: app.ui.GetRadioSelectedText('enviadoaInvestigacion'),
            FECHAENVIADOAINVESTIGACION: app.ui.GetDateValue('#fechaenviadoainvestigacion'),
            ENVIADOAACOMPANAMIENTOLEGAL: app.ui.GetRadioNumericValue('enviadoaacompanamientoLegal'),
            ENVIADOAACOMPANAMIENTOLEGALDESC: app.ui.GetRadioSelectedText('enviadoaacompanamientoLegal'),
            FECHAENVIADOACOMPALEGAL: app.ui.GetDateValue('#fechaenviadoaacompanamientoLegal'),
            INFRASEGURO: app.ui.GetRadioNumericValue('infraseguro'),
            INFRASEGURODESC: app.ui.GetRadioSelectedText('infraseguro'),
            AUTORIZACIONDEUSOPOLIZA: app.ui.GetRadioNumericValue('autorizaciondeusopolizaEvent'),
            AUTORIZACIONDEUSOPOLIZADESC: app.ui.GetRadioSelectedText('autorizaciondeusopolizaEvent'),
            FECHAAUTORIZACIONDEUSOPOLIZA: app.ui.GetDateValue('#fechaautorizaciondeusopolizaEvent'),
            DETALLESINIESTRO: null
        };

        return data;
    };

    function MapObjectToInput(data) {
        app.ui.SetDateValue('#fechadelevento', data.FECHADELEVENTO);
        app.ui.SetDropDownNumericValue('#analistareclamos', data.ANALISTARECLAMOS, false);
        app.ui.SetDropDownNumericValue('#tipodeindemnizacion', data.TIPODEINDEMNIZACION, false, 7);
        app.ui.SetDropDownNumericValue('#motivonoProcede', data.MOTIVONOPROCEDE, false);
        $('#detallenoprocede').val(data.DETALLENOPROCEDE);
        app.ui.SetDropDownNumericValue('#tipodecobertura', data.TIPODECOBERTURA, false);
        app.ui.SetDropDownNumericValue('#categoriadesiniestro', data.CATEGORIADESINIESTRO, false);
        app.ui.SetRadioNumericValue('posiblesubrogacion', data.POSIBLESUBROGACION);
        app.ui.SetDateValue('#fechaidentificadocomoPosibleSubrogacion', data.FECHAPOSIBLESUBROGACION);
        app.ui.SetRadioNumericValue('enviadoaInvestigacion', data.ENVIADOAINVESTIGACION);
        app.ui.SetDateValue('#fechaenviadoainvestigacion', data.FECHAENVIADOAINVESTIGACION);
        app.ui.SetRadioNumericValue('enviadoaacompanamientoLegal', data.ENVIADOAACOMPANAMIENTOLEGAL);
        app.ui.SetDateValue('#fechaenviadoaacompanamientoLegal', data.FECHAENVIADOACOMPALEGAL);
        app.ui.SetRadioNumericValue('infraseguro', data.INFRASEGURO);
        app.ui.SetRadioNumericValue('autorizaciondeusopolizaEvent', data.AUTORIZACIONDEUSOPOLIZA);
        app.ui.SetDateValue('#fechaautorizaciondeusopolizaEvent', data.FECHAAUTORIZACIONDEUSOPOLIZA);

        data_changed();
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
        $('#fechaautorizaciondeusopolizaEvent_group').datetimepicker({
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
                let submitData = MapInputToObject();
                if (submitData.ID === null) {
                    app.core.Post(`https://appqa.mapfrecr.com/datapi/api/entity/PurdyPanelEvento`, JSON.stringify(submitData))
                        .done(function (created) {
                            if (created?.Sucessfully) {
                                _data.ID = created.Data.Next.NEXTID
                                _loadready = true;
                                _changed = false;
                                app.ui.CustomBehaviour('changed', false);
                                _eventCallback('EventoDataChange', submitData);
                                app.ui.Success('La información del análisis del evento, fue creada de forma exitosa');
                            }
                            else {
                                console.error(created);
                            }

                        }).always(function () {
                            app.ui.ButtonDone('#PurdyPanelEventoEdtFormSave');
                        });
                }
                else {
                    app.core.Put(`https://appqa.mapfrecr.com/datapi/api/entity/PurdyPanelEvento/${submitData.ID}`, JSON.stringify(submitData))
                        .done(function (updated) {
                            if (updated?.Sucessfully) {
                                _loadready = true;
                                _changed = false;
                                app.ui.CustomBehaviour('changed', false);
                                _eventCallback('EventoDataChange', submitData);
                                app.ui.Success('La información del análisis del evento, fue actualizada de forma exitosa');
                            }
                            else {
                                console.error(updated);
                            }
                        }).always(function () {
                            app.ui.ButtonDone('#PurdyPanelEventoEdtFormSave');
                        });
                }
            }
            event.preventDefault();
        });

        $('#PurdyPanelEventoEdtFormCancel').click(function () {
            Get(_data.ASIGES);

            event.preventDefault();
        });

    };

    function data_changed() {
        if (app.ui.GetDropDownNumericValue('#tipodeindemnizacion') === 8)
            $('.motivonoProcedeVisible').removeClass('d-none');
        else
            $('.motivonoProcedeVisible').addClass('d-none');
        if (app.ui.GetDropDownNumericValue('#tipodeindemnizacion') === 8)
            $('.detallenoprocedeVisible').removeClass('d-none');
        else
            $('.detallenoprocedeVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('posiblesubrogacion') === 1)
            $('.fechaidentificadocomoPosibleSubrogacionVisible').removeClass('d-none');
        else
            $('.fechaidentificadocomoPosibleSubrogacionVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('enviadoaInvestigacion') === 1)
            $('.fechaenviadoainvestigacionVisible').removeClass('d-none');
        else
            $('.fechaenviadoainvestigacionVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('enviadoaacompanamientoLegal') === 1)
            $('.fechaenviadoaacompanamientoLegalVisible').removeClass('d-none');
        else
            $('.fechaenviadoaacompanamientoLegalVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('autorizaciondeusopolizaEvent') === 1)
            $('.fechaautorizaciondeusopolizaEventVisible').removeClass('d-none');
        else
            $('.fechaautorizaciondeusopolizaEventVisible').addClass('d-none');
        if (_loadready) {
            _changed = true;
        }
        app.ui.CustomBehaviour('changed', _loadready && _changed);

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

    function EmptyPurdyPanelEvento() {
        let data = { ID: null, ASIGES: null, FECHADELEVENTO: null, ANALISTARECLAMOS: null, TIPODEINDEMNIZACION: null, MOTIVONOPROCEDE: null, DETALLENOPROCEDE: null, DETALLESINIESTRO: null, TIPODECOBERTURA: null, CATEGORIADESINIESTRO: null, POSIBLESUBROGACION: 2, FECHAPOSIBLESUBROGACION: null, ENVIADOAINVESTIGACION: 2, FECHAENVIADOAINVESTIGACION: null, ENVIADOAACOMPANAMIENTOLEGAL: 2, FECHAENVIADOACOMPALEGAL: null, INFRASEGURO: 2, AUTORIZACIONDEUSOPOLIZA: 2, FECHAAUTORIZACIONDEUSOPOLIZA: null };

        //if (localStorage.getItem('Roles').includes('Reclamos')) {
        //    app.ui.SelectDropDownByText('#analistareclamos', localStorage.getItem('Username'));

        //    data.FECHADELEVENTO = new Date();
        //    data.ANALISTARECLAMOS = app.ui.GetDropDownNumericValue('#analistareclamos')
        //}

        return data;
    };

    function Get(asigesCode) {
        _loadready = false;

        app.core.Get(`https://appqa.mapfrecr.com/datapi/api/entity/PurdyPanelEvento/asiges?code=${asigesCode}`)
            .done(function (dataEvento) {
                if (dataEvento?.Sucessfully) {
                    if (dataEvento.Data === null) {
                        dataEvento.Data = EmptyPurdyPanelEvento();
                        dataEvento.Data.ASIGES = asigesCode;
                    }
                    MapObjectToInput(dataEvento.Data);
                    dataEvento.Data.ANALISTARECLAMOSDESC = app.ui.GetDropDownSelectedText('#analistareclamos');
                    dataEvento.Data.TIPODEINDEMNIZACIONDESC = app.ui.GetDropDownSelectedText('#tipodeindemnizacion');
                    dataEvento.Data.CATEGORIADESINIESTRODESC = app.ui.GetDropDownSelectedText('#categoriadesiniestro');
                    _data = dataEvento.Data;
                    _eventCallback('EventoDataChange', dataEvento.Data);
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
                app.core.Lookups(['UsersByRol:Reclamos.analistareclamos'],
                    function () {
                        MapObjectToInput(EmptyPurdyPanelEvento());
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
                        MapObjectToInput(EmptyPurdyPanelEvento());
                    }                    
                    break;
            }
        }
    };
})();