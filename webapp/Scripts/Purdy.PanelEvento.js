var app = app || {};

app.PurdyPanelEvento = (function () {

    let _dep = { empresa: '', primaanual: 0, deducible: 0 };
    let _eventCallback = null;
    let _data = null;
    let _claim = null;
    let _loadready = false;
    let _changed = false;

    function MapInputToObject() {
        var data = {
            ID: _data.ID,
            ASIGES: _data.ASIGES,
            NUM_SINI: _claim.NUM_SINI,
            NUM_EXP: _claim.NUM_EXP,
            ANALISTAGESTORA: _data.ANALISTAGESTORA,
            FECHADELEVENTO: app.ui.GetDateValue('#fechadelevento'),
            ANALISTARECLAMOS: app.ui.GetDropDownNumericValue('#analistareclamos'),
            ANALISTARECLAMOSDESC: app.ui.GetDropDownSelectedText('#analistareclamos'),
            TIPODEINDEMNIZACION: _data.TIPODEINDEMNIZACION,
            TIPODEINDEMNIZACIONDESC: _data.TIPODEINDEMNIZACIONDESC,
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
            DETALLESINIESTRO: null,
            EMPRESA: _dep.empresa,
            PRIMAANUAL: _dep.primaanual,
            DEDUCIBLE: _dep.deducible
        };

        return data;
    };

    function MapObjectToInput(data) {
        _loadready = false;
        app.ui.SetDateValue('#fechadelevento', _claim != null ? _claim.FEC_DENU_SINI : null);
        app.ui.SetDropDownNumericValue('#analistareclamos', data.ANALISTARECLAMOS, false);
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
        _changed = false;
        _loadready = true;
    };

    function Controls_setup() {
        app.ui.NewDateWidget('#fechadelevento');
        app.ui.NewDateWidget('#fechaidentificadocomoPosibleSubrogacion');
        app.ui.NewDateWidget('#fechaenviadoainvestigacion');
        app.ui.NewDateWidget('#fechaenviadoaacompanamientoLegal');
        app.ui.NewDateWidget('#fechaautorizaciondeusopolizaEvent');
    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });

        $("#PurdyPanelEventoEdtForm :input").change(function () {
            data_changed();
        });

        $('#PurdyPanelEventoEdtFormSave').click(function (e) {

            if (app.ui.IsValid('#PurdyPanelEventoEdtForm', false)) {
                Save('La información del análisis del evento, fue creada de forma exitosa', 'La información del análisis del evento, fue actualizada de forma exitosa');
            }
            e.preventDefault();
        });

        $('#PurdyPanelEventoEdtFormCancel').click(function (e) {
            Get(_data.ASIGES);

            e.preventDefault();
        });

    };

    function data_changed() {
        if (_data?.TIPODEINDEMNIZACION === 8)
            $('.motivonoProcedeVisible').removeClass('d-none');
        else
            $('.motivonoProcedeVisible').addClass('d-none');
        if (_data?.TIPODEINDEMNIZACION === 8)
            $('.detallenoprocedeVisible').removeClass('d-none');
        else
            $('.detallenoprocedeVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('posiblesubrogacion') === 1) {
            $('.fechaidentificadocomoPosibleSubrogacionVisible').removeClass('d-none');
            if (app.ui.GetDateValue('#fechaidentificadocomoPosibleSubrogacion') === '0001-01-01T00:00:00') {
                app.ui.SetDateValue('#fechaidentificadocomoPosibleSubrogacion', new Date());
            }
        }
        else {
            $('.fechaidentificadocomoPosibleSubrogacionVisible').addClass('d-none');
            app.ui.SetDateValue('#fechaidentificadocomoPosibleSubrogacion', null);
        }

        if (app.ui.GetRadioNumericValue('enviadoaInvestigacion') === 1) {
            $('.fechaenviadoainvestigacionVisible').removeClass('d-none');
            if (app.ui.GetDateValue('#fechaenviadoainvestigacion') === '0001-01-01T00:00:00') {
                app.ui.SetDateValue('#fechaenviadoainvestigacion', new Date());
            }
        }
        else {
            $('.fechaenviadoainvestigacionVisible').addClass('d-none');
            app.ui.SetDateValue('#fechaenviadoainvestigacion', null);
        }

        if (app.ui.GetRadioNumericValue('enviadoaacompanamientoLegal') === 1) {
            $('.fechaenviadoaacompanamientoLegalVisible').removeClass('d-none');
            if (app.ui.GetDateValue('#fechaenviadoaacompanamientoLegal') === '0001-01-01T00:00:00') {
                app.ui.SetDateValue('#fechaenviadoaacompanamientoLegal', new Date());
            }
        }
        else {
            $('.fechaenviadoaacompanamientoLegalVisible').addClass('d-none');
            app.ui.SetDateValue('#fechaenviadoaacompanamientoLegal', null);
        }
        if (app.ui.GetRadioNumericValue('autorizaciondeusopolizaEvent') === 1) {
            $('.fechaautorizaciondeusopolizaEventVisible').removeClass('d-none');
            if (app.ui.GetDateValue('#fechaautorizaciondeusopolizaEvent') === '0001-01-01T00:00:00') {
                app.ui.SetDateValue('#fechaautorizaciondeusopolizaEvent', new Date());
            }
        }
        else {
            $('.fechaautorizaciondeusopolizaEventVisible').addClass('d-none');
            app.ui.SetDateValue('#fechaautorizaciondeusopolizaEvent', null);
        }
        if (_loadready) {
            _changed = true;
        }
        app.ui.CustomBehaviour('eventChanged', _loadready && _changed);


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

    async function Save(msgCreated, msgUpdated) {
        app.ui.ButtonDoing('#PurdyPanelEventoEdtFormSave');
        let submitData = MapInputToObject();
        if (submitData.ID === null) {
            app.core.datapi('POST', `PurdyPanelEvento`, submitData)
                .then(created => {
                    _data.ID = created.Next.NEXTID
                    _loadready = true;
                    _changed = false;
                    app.ui.CustomBehaviour('eventChanged', false);
                    _eventCallback('EventoDataChange', submitData);
                    app.ui.Success(msgCreated);
                })
                .finally(() => {
                    app.ui.ButtonDone('#PurdyPanelEventoEdtFormSave');
                });
        }
        else {
            app.core.datapi('PUT', `PurdyPanelEvento/${submitData.ID}`, submitData)
                .then(updated => {
                    _loadready = true;
                    _changed = false;
                    app.ui.CustomBehaviour('eventChanged', false);
                    _eventCallback('EventoDataChange', submitData);
                    app.ui.Success(msgUpdated);
                })
                .finally(() => {
                    app.ui.ButtonDone('#PurdyPanelEventoEdtFormSave');
                });
        }
    };

    async function Get(asigesCode, claim, exp) {
        app.core.datapi('GET', `PurdyPanelEvento/asiges?code=${asigesCode}&claim=${claim}&exp=${exp}`)
            .then(dataEvento => {
                if (dataEvento?.Evento === null) {
                    dataEvento.Evento = EmptyPurdyPanelEvento();
                    dataEvento.Evento.ASIGES = asigesCode;
                }
                _data = dataEvento.Evento;
                MapObjectToInput(dataEvento.Evento);
                dataEvento.Evento.ANALISTARECLAMOSDESC = app.ui.GetDropDownSelectedText('#analistareclamos');
                dataEvento.Evento.CATEGORIADESINIESTRODESC = app.ui.GetDropDownSelectedText('#categoriadesiniestro');
                _eventCallback('EventoDataChange', dataEvento.Evento);
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
        Event: async function (src, data, eventData) {
            switch (src) {
                case 'ASIGESChange':
                    _loadready = false;
                    _claim = data.claim;
                    if (data.claim != null) {
                        Get(data.asiges, data.claim.NUM_SINI, data.claim.NUM_EXP);
                    } else {
                        MapObjectToInput(EmptyPurdyPanelEvento());
                    }
                    break;
                case 'TipoDeIndemnizacionChange':
                    _data.TIPODEINDEMNIZACION = eventData.TIPODEINDEMNIZACION;
                    _data.TIPODEINDEMNIZACIONDESC = eventData.TIPODEINDEMNIZACIONDESC;

                    _loadready = true;
                    data_changed();
                    _loadready = false;

                    Save('El tipo de indemnización, fue almacenado de forma exitosa',
                        'El tipo de indemnización, fue actualizado de forma exitosa');
                    break;
                case 'AnalistaGestoraChange':
                    _data.ANALISTAGESTORA = eventData.ANALISTAGESTORA;
                    _data.ANALISTAGESTORADESC = eventData.ANALISTAGESTORADESC;

                    _loadready = true;
                    data_changed();
                    _loadready = false;

                    Save('La analista gestora, fue almacenada de forma exitosa',
                        'La analista gestora, fue actualizada de forma exitosa');
                    break;
                case 'detalleChanged':
                    alert(data.asiges);
                    Get(data.asiges);
                    break;
                case 'PolicyDataChange':
                    _dep.empresa = eventData.empresa;
                    break;
                case 'DetalleDeducible':
                    _dep.deducible = eventData;
                    break;
                case 'CoverageDataChange':
                    _dep.primaanual = eventData.primaanual;
                    break;
            }
        }
    };
})();