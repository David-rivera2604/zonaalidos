var app = app || {};
app.PurdyPanelDetalle = (function () {

    let _eventCallback = null;
    let _data = null;

    function MapObjectToInput(data) {
        $('#numerodepoliza').val(data.numerodepoliza);
        $('#monedadepoliza').val(data.monedadepoliza);
        $('#usodepoliza').val(data.usodepoliza);
        $('#coberturaafectada').val(data.coberturaafectada);
        $('#primaanual').val(data.primaanual);
        $('#primaspagadas').val(data.primaspagadas);
        $('#primaspendientesdecobro').val(data.primaspendientesdecobro);
        $('#fechaultimaprimacobrada').val(data.fechaultimaprimacobrada);
        $('#deducible').val(data.deducible);
        $('#tomador').val(data.tomador);
        $('#acreedor').val(data.acreedor);
        $('#placa').val(data.placa);
        $('#chasis').val(data.chasis);
        $('#marca').val(data.marca);
        $('#valorasegurado').val(data.valorasegurado);
        $('#nombredelchoferduranteelsiniestro').val(data.nombredelchoferduranteelsiniestro);
        $('#telefonodechofer').val(data.telefonodechofer);
    };

    function ShowValue(row, uifield, field) {
        if (row.length > 0) {
            $('#' + uifield).html(`${row[0][field]}`);
        } else {
            $('#' + uifield).html('---');
        }
    };

    return {
        Init: function (eventCallback) {
            try {
                _eventCallback = eventCallback;
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Event: function (src, data) {

            $('#numerodepoliza').html(data.claim.NUM_POLIZA);
            $('#monedadepoliza').html(data.claim.NOM_MON);
            $('#tomador').html(`${data.claim.TIP_DOCUM_TOMADOR} ${data.claim.COD_DOCUM_TOMADOR} - ${data.claim.NOM_TOMADOR} ${data.claim.APE_TOMADOR}`);
            $('#coberturaafectada').html(`${data.claim.COD_CAUSA_SINI} ${data.claim.NOM_COB}`);
            app.core.Get(`${app.setting.apipath}v1/datasource/json?id=700&sequence=2&url=NUM_POLIZA=${data.claim.NUM_POLIZA}:NUM_SPTO=${data.claim.NUM_SPTO}:NUM_APLI=${data.claim.NUM_APLI}:NUM_SPTO_APLI=${data.claim.NUM_SPTO_APLI}`)
                .done(function (policy) {
                    _data = policy[0];
                    _eventCallback('PolicyChange', _data);
                    app.core.Get(`${app.setting.apipath}v1/datasource/json?id=700&sequence=3&url=NUM_POLIZA=${data.claim.NUM_POLIZA}`)
                        .done(function (roles) {
                            _data.roles = roles;

                            let acreedor = roles.filter(i => i.TIP_BENEF === "8");
                            if (acreedor.length > 0) {
                                $('#acreedor').html(`${acreedor[0].TIP_DOCUM} ${acreedor[0].COD_DOCUM} - ${acreedor[0].NOM_COMPLETO}`);
                            } else {
                                $('#acreedor').html('---');
                            }

                            _eventCallback('PolicyRolesChange', _data);
                        });
                    app.core.Get(`${app.setting.apipath}v1/datasource/json?id=700&sequence=4&url=NUM_POLIZA=${data.claim.NUM_POLIZA}:NUM_RIESGO=${data.claim.NUM_RIESGO}`)
                        .done(function (data) {
                            _eventCallback('PolicyDataChange', _data);
                            _data.data = data;

                            ShowValue(data.filter(i => i.COD_CAMPO === "NUM_MATRICULA"), 'placa', 'VAL_CAMPO');
                            ShowValue(data.filter(i => i.COD_CAMPO === "COD_CHASSIS"), 'chasis', 'VAL_CAMPO');
                            ShowValue(data.filter(i => i.COD_CAMPO === "COD_MARCA"), 'marca', 'TXT_CAMPO');
                            ShowValue(data.filter(i => i.COD_CAMPO === "IMP_VR"), 'valorasegurado', 'TXT_CAMPO');
                            ShowValue(data.filter(i => i.COD_CAMPO === "COD_USO_VEHI"), 'usodepoliza', 'TXT_CAMPO');
                        });
                });
        }
    };
})();
