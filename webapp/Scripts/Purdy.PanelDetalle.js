var app = app || {};
app.PurdyPanelDetalle = (function () {

    let _eventCallback = null;
    let _claim = null;
    let _loadready = false;
    let _changed = false;

    function Controls_setup() {

        $('#telefonodelchofer').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: true,
            change: true
        });
    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });

        $("#PurdyPanelDetalleEdtForm :input").change(function () {
            data_changed();
        });

        $('#PurdyPanelDetalleEdtFormSave').click(function (e) {
            Save();
            e.preventDefault();
        });

        $('#PurdyPanelDetalleEdtFormCancel').click(function (e) {
            _eventCallback('EventoDataCancel', submitData);
            e.preventDefault();
        });

    };

    function data_changed() {
        if (_loadready) {
            _changed = true;
        }
        app.ui.VisibleBehaviour('.detalleChanged', _loadready && _changed);

    };

    function ShowValue(row, uifield, field) {
        let value = '';
        if (row.length > 0) {
            value = row[0][field];
            $('#' + uifield).html(`${value}`);
        } else {
            $('#' + uifield).html('---');
        }
        return value;
    };

    async function Save() {
        app.ui.ButtonDoing('#PurdyPanelDetalleEdtFormSave');
        let submitData = {
            ID: _claim.event?.ID,
            ASIGES: _claim.asiges,
            NOMBREDELCHOFER: $('#nombredelchofer').val(),
            TELEFONODELCHOFER: $('#telefonodelchofer').val()
        };
        if (submitData.ID === null) {
            app.core.Post(`${app.setting.entityapi}/PurdyPanelOtros`, JSON.stringify(submitData))
                .done(function (created) {
                    if (created?.Sucessfully) {
                        _eventCallback('detalleChanged', created);
                        app.ui.VisibleBehaviour('.detalleChanged', false);
                        app.ui.Success('La información del chofer, fue actualizada de forma exitosa');
                    }
                    else {
                        console.error(created);
                    }

                }).always(function () {
                    app.ui.ButtonDone('#PurdyPanelDetalleEdtFormSave');
                });
        }
        else {
            app.core.Put(`${app.setting.entityapi}/PurdyPanelOtros/${submitData.ID}`, JSON.stringify(submitData))
                .done(function (updated) {
                    if (updated?.Sucessfully) {
                        _eventCallback('detalleChanged', updated);
                        app.ui.VisibleBehaviour('.detalleChanged', false);
                        app.ui.Success('La información del chofer, fue actualizada de forma exitosa');
                    }
                    else {
                        console.error(updated);
                    }
                }).always(function () {
                    app.ui.ButtonDone('#PurdyPanelDetalleEdtFormSave');
                });
        }
    };
    async function GetPolicy(data) {

        app.core.Get(`${app.setting.entityapi}/policy/${data.claim.NUM_POLIZA}?NUM_SPTO=${data.claim.NUM_SPTO}&NUM_APLI=${data.claim.NUM_APLI}&NUM_SPTO_APLI=${data.claim.NUM_SPTO_APLI}&NUM_RIESGO=${data.claim.NUM_RIESGO}`)
            .done(function (policy) {
                if (policy?.Sucessfully) {
                    let data = policy.Data.Fixeddata.Data;
                    _eventCallback('PolicyChange', data);

                    roles = policy.Data.Thirdparties.Data;
                    data.roles = roles;
                    let acreedor = roles.filter(i => i.TIP_BENEF === "8");
                    if (acreedor.length > 0) {
                        $('#acreedor').html(`${acreedor[0].TIP_DOCUM} ${acreedor[0].COD_DOCUM} - ${acreedor[0].NOM_COMPLETO}`);
                    } else {
                        $('#acreedor').html('---');
                    }
                    _eventCallback('PolicyRolesChange', data);

                    dataVar = policy.Data.Variabledata.Data;
                    data.data = dataVar;
                    data.marca = ShowValue(dataVar.filter(i => i.COD_CAMPO === "COD_MARCA"), 'marca', 'TXT_CAMPO');
                    data.empresa = 'Purdy Motor';
                    ShowValue(dataVar.filter(i => i.COD_CAMPO === "NUM_MATRICULA"), 'placa', 'VAL_CAMPO');
                    ShowValue(dataVar.filter(i => i.COD_CAMPO === "COD_CHASSIS"), 'chasis', 'VAL_CAMPO');
                    ShowValue(dataVar.filter(i => i.COD_CAMPO === "IMP_VR"), 'valorasegurado', 'TXT_CAMPO');
                    ShowValue(dataVar.filter(i => i.COD_CAMPO === "COD_USO_VEHI"), 'usodepoliza', 'TXT_CAMPO');
                    if (data.marca === 'FORD' || data.marca === 'VOLKSWAGEN') {
                        data.empresa = 'Automotriz';
                    }
                    _eventCallback('PolicyDataChange', data);
                }
            });
    };

    async function GetCoverages(data) {
        $('#primaanual').html('---');

        app.core.Get(`${app.setting.entityapi}/policy/${data.claim.NUM_POLIZA}/Coverages?NUM_SPTO=${data.claim.NUM_SPTO}&NUM_APLI=${data.claim.NUM_APLI}&NUM_SPTO_APLI=${data.claim.NUM_SPTO_APLI}&NUM_RIESGO=${data.claim.NUM_RIESGO}`)
            .done(function (coverages) {
                if (coverages?.Sucessfully && coverages.Data != null) {
                    let primaanual = coverages.Data.reduce((accumulator, item) => { return accumulator + item.IMP_TOTAL; }, 0);

                    $('#primaanual').html(`${app.ui.DecimalFormatter(primaanual)}`);
                    _eventCallback('CoverageDataChange', {
                        primaanual: primaanual, coverages: coverages.Data
                    });
                }
            });
    };
    async function GetPremiums(data) {

        $('#primaspendientesdecobro').html('---');
        $('#primaspagadas').html('---');
        $('#fechaultimaprimacobrada').html('---');

        app.core.Get(`${app.setting.entityapi}/policy/${data.claim.NUM_POLIZA}/Premiums?NUM_SPTO=${data.claim.NUM_SPTO}&NUM_APLI=${data.claim.NUM_APLI}&NUM_SPTO_APLI=${data.claim.NUM_SPTO_APLI}&NUM_RIESGO=${data.claim.NUM_RIESGO}`)
            .done(function (premiums) {

                if (premiums?.Sucessfully) {
                    let primaspendientesdecobro = 0;
                    let primaspagadas = 0;
                    if (premiums.Data.Pendingpremiums?.Sucessfully && premiums.Data.Pendingpremiums?.Data != null) {
                        primaspendientesdecobro = premiums.Data.Pendingpremiums.Data.reduce((accumulator, item) => { return accumulator + item.IMP_RECIBO; }, 0);
                    }

                    if (premiums.Data.Paidpremiums?.Sucessfully && premiums.Data.Paidpremiums?.Data != null) {
                        primaspagadas = premiums.Data.Paidpremiums.Data.reduce((accumulator, item) => { return accumulator + item.IMP_RECIBO; }, 0);

                        //$('#primaspagadas').html(app.ui.DecimalFormatter(app.ui.DecimalFormatter(premiums.Data.Paidpremiums.Data[0].IMP_RECIBO)));
                        $('#fechaultimaprimacobrada').html(app.ui.DateFormatter(premiums.Data.Paidpremiums.Data[0].FEC_REMESA));
                    }

                    $('#primaspendientesdecobro').html(app.ui.DecimalFormatter(primaspendientesdecobro));
                    $('#primaspagadas').html(app.ui.DecimalFormatter(primaspagadas));

                    _eventCallback('PremiumDataChange', { primaspendientesdecobro: primaspendientesdecobro, primaspagadas: primaspagadas, premiums: premiums.Data });
                }
            });
    };

    return {
        Init: function (eventCallback) {
            try {
                Controls_setup();
                Controls_Events();
                _eventCallback = eventCallback;
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
                    _claim = data;
                    if (data.claim != null) {
                        $('#numerodepoliza').html(data.claim.NUM_POLIZA);
                        $('#monedadepoliza').html(data.claim.NOM_MON);
                        $('#tomador').html(`${data.claim.TIP_DOCUM_TOMADOR} ${data.claim.COD_DOCUM_TOMADOR} - ${data.claim.NOM_TOMADOR} ${app.ui.StringValueToString(data.claim.APE_TOMADOR)}`);
                        

                        let deducible = 0;
                        let deducibleDesc = '';
                        data.claim.Coberturas.forEach(function (item) {
                            if (item.NOM_FRANQUICIA != null) {
                                deducible += Number(item.NOM_FRANQUICIA.replace(/[^0-9\.]+/g, ""));
                            }
                            if (deducibleDesc != '')
                                deducibleDesc += ', ';
                            deducibleDesc += `${item.COD_COB} ${item.NOM_COB}`;
                        })
                        $('#coberturaafectada').html(deducibleDesc);
                        $('#deducible').html(`${app.ui.DecimalFormatter(deducible)}`);
                        
                        _eventCallback('DetalleDeducible', deducible);


                        GetPolicy(data);
                        GetCoverages(data);
                        GetPremiums(data);
                    } else {
                        $('#deducible').html('---');
                        $('#numerodepoliza').html('');
                        $('#monedadepoliza').html('');
                        $('#tomador').html('');
                        $('#coberturaafectada').html('');
                        $('#acreedor').html('');
                        $('#placa').html('');
                        $('#chasis').html('');
                        $('#marca').html('');
                        $('#valorasegurado').html('');
                        $('#usodepoliza').html('');
                    }
                    break;

                case 'EventoDataChange':
                    _claim = data
                    _loadready = false;
                    $('#nombredelchofer').val(eventData.NOMBREDELCHOFER);
                    $('#telefonodelchofer').val(eventData.TELEFONODELCHOFER);
                    _loadready = true;
                    break;
            }

        }
    };
})();
