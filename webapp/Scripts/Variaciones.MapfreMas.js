var app = app || {};

app.VariacionesMapfreMas = (function () {

    let variacion = null;

    function Setup() {
        let parameter = JSON.parse(localStorage.getItem('current'));
        variacion = { cod_ramo: parameter.COD_RAMO, cod_ramoDesc: parameter.ABR_RAMO, num_poliza: parameter.NUM_POLIZA, num_riesgo: parameter.NUM_RIESGO, fec_validez: new Date(), txt_obs: null, Detalle: null };

        $("#cod_ramo").append(`<option value=${variacion.cod_ramo} selected>${variacion.cod_ramo} - ${variacion.cod_ramoDesc}</option>`);
        $('#num_poliza').val(variacion.num_poliza);
        $('#num_riesgo').val(variacion.num_riesgo);
        app.ui.SetDateValue('#fec_validez', variacion.fec_validez);

        app.core.Get(app.setting.apipath + `v1/Poliza/${variacion.num_poliza}/DatosVariables`)
            .done(function (data) {
                variacion.Detalle = data;
                data.forEach(function (item, index, array) {
                    switch (item.cod_campo) {
                        case 'NUM_MATRICULA':
                            $('#num_matricula').val(item.val_campo_act);
                            $('#num_matricula').data('oldvalue', item.val_campo_act);
                            break;
                        case 'NUM_MOTOR':
                            $('#num_motor').val(item.val_campo_act);
                            $('#num_motor').data('oldvalue', item.val_campo_act);
                            break;
                        case 'COD_CHASSIS':
                            $('#cod_chassis').val(item.val_campo_act);
                            $('#cod_chassis').data('oldvalue', item.val_campo_act);
                            break;
                    }
                });
            });
    }

    function MapInputToObject() {
        variacion.fec_validez = app.ui.GetDateValue('#fec_validez');
        variacion.txt_obs = $('#txt_obs').val();
        variacion.Detalle = [
            { cod_campo: 'NUM_MATRICULA', val_campo_ant: $('#num_matricula').data('oldvalue'), val_campo_act: $('#num_matricula').val() },
            { cod_campo: 'NUM_MOTOR', val_campo_ant: $('#num_motor').data('oldvalue'), val_campo_act: $('#num_motor').val() },
            { cod_campo: 'COD_CHASSIS', val_campo_ant: $('#cod_chassis').data('oldvalue'), val_campo_act: $('#cod_chassis').val() }];
        return variacion;
    }

    function Controls_setup() {
        $('#fec_validez_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
    }

    function Controls_Events() {

        $('#VariacionesEdtForm :input').change(function () {

            $('#VariacionesEdtFormSave').prop("disabled",
                $('#num_matricula').data('oldvalue') === $('#num_matricula').val() &&
                $('#num_motor').data('oldvalue') === $('#num_motor').val() &&
                $('#cod_chassis').data('oldvalue') === $('#cod_chassis').val());
        });

        $('#VariacionesEdtFormSave').click(function () {

            if (app.ui.IsValid('#VariacionesEdtForm', false)) {
                app.ui.ButtonDoing('#VariacionesEdtFormSave');

                app.core.Put(app.setting.apipath + `v1/Poliza/${variacion.num_poliza}/Variaciones`, JSON.stringify(MapInputToObject()))
                    .done(function (data) {
                        $('#num_matricula').data('oldvalue', $('#num_matricula').val());
                        $('#num_motor').data('oldvalue', $('#num_motor').val());
                        $('#cod_chassis').data('oldvalue', $('#cod_chassis').val());
                    }).always(function () {
                        app.ui.ButtonDone('#VariacionesEdtFormSave');
                        $('#VariacionesEdtFormSave').prop("disabled", true);
                    });
            }
            event.preventDefault();
        });
    }

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#VariacionesEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                num_poliza: { required: true },
                num_matricula: { required: true },
                num_motor: { required: true },
                cod_chassis: { required: true },
            },
            messages: {
                num_poliza: { required: 'Debe indicar el N° de póliza' },
                num_matricula: { required: 'Debe indicar el N° de matricula' },
                num_motor: { required: 'Debe indicar el N° de motor' },
                cod_chassis: { required: 'Debe indicar el cod_chassis' },
            }
        });
    }

    return {
        Init: function () {
            Controls_setup();
            Setup_Validations();

            Controls_Events();
            Setup();
        },
        Data: function () {
            return MapInputToObject();
        }
    };
})();
