var app = app || {};
app.PurdyPanelDetalle = (function () {

    let _eventCallback = null;
    let _data = null;

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

            switch (src) {
                case 'ASIGESChange':
                    if (data.claim != null) {
                        $('#numerodepoliza').html(data.claim.NUM_POLIZA);
                        $('#monedadepoliza').html(data.claim.NOM_MON);
                        $('#tomador').html(`${data.claim.TIP_DOCUM_TOMADOR} ${data.claim.COD_DOCUM_TOMADOR} - ${data.claim.NOM_TOMADOR} ${data.claim.APE_TOMADOR}`);
                        $('#coberturaafectada').html(`${data.claim.COD_CAUSA_SINI} ${data.claim.NOM_COB}`);

                        app.core.Get(`https://appqa.mapfrecr.com/datapi/api/entity/policy/${data.claim.NUM_POLIZA}?NUM_SPTO=${data.claim.NUM_SPTO}&NUM_APLI=${data.claim.NUM_APLI}&NUM_SPTO_APLI=${data.claim.NUM_SPTO_APLI}&NUM_RIESGO=${data.claim.NUM_RIESGO}`)
                            .done(function (policy) {
                                if (policy?.Sucessfully) {
                                    _data = policy.Data.Fixeddata.Data;
                                    _eventCallback('PolicyChange', _data);

                                    roles = policy.Data.Thirdparties.Data;
                                    _data.roles = roles;
                                    let acreedor = roles.filter(i => i.TIP_BENEF === "8");
                                    if (acreedor.length > 0) {
                                        $('#acreedor').html(`${acreedor[0].TIP_DOCUM} ${acreedor[0].COD_DOCUM} - ${acreedor[0].NOM_COMPLETO}`);
                                    } else {
                                        $('#acreedor').html('---');
                                    }
                                    _eventCallback('PolicyRolesChange', _data);

                                    data = policy.Data.Variabledata.Data;
                                    _data.data = data;
                                    ShowValue(data.filter(i => i.COD_CAMPO === "NUM_MATRICULA"), 'placa', 'VAL_CAMPO');
                                    ShowValue(data.filter(i => i.COD_CAMPO === "COD_CHASSIS"), 'chasis', 'VAL_CAMPO');
                                    ShowValue(data.filter(i => i.COD_CAMPO === "COD_MARCA"), 'marca', 'TXT_CAMPO');
                                    ShowValue(data.filter(i => i.COD_CAMPO === "IMP_VR"), 'valorasegurado', 'TXT_CAMPO');
                                    ShowValue(data.filter(i => i.COD_CAMPO === "COD_USO_VEHI"), 'usodepoliza', 'TXT_CAMPO');
                                    _eventCallback('PolicyDataChange', _data);
                                }
                            });
                        break;
                    } else {
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
            }

        }
    };
})();
