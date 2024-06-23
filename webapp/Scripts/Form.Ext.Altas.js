var app = app || {};

app.Form_Ext_Altas = (function () {


    return {
        Init: function (spec, formName) {

            app.core.Lookups(['Paises.NACIONALIDAD_ASEG', 'Provincias.COD_ESTADO', 'Cantones.COD_PROVINCIA', 'Distritos.COD_LOCALIDAD'],
                function () {
                    $('#COD_ESTADO').on('change', function () {
                        var pais = $('select#cod_pais').val();
                        app.core.LookupDependency($('select#COD_ESTADO').val(), 'COD_PROVINCIA', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
                    });
                    $('#COD_PROVINCIA').on('change', function () {
                        var pais = $('select#cod_pais').val();
                        app.core.LookupDependency($('select#COD_PROVINCIA').val(), 'COD_LOCALIDAD', 'Distritos', '', null, false, null, `cod_pais=${pais}:cod_prov=`);
                    });
                }, ``);


            $('#btnIssue').click(function (e) {
                if (spec.IsValid(true)) {
                    $('#generalNotify').html('');
                    app.ui.ButtonDoing('#btnIssue');
                    let entry = spec.Data();

                    entry.TIP_DOCUM_ASEG = $("#COD_DOCUM_ASEGType").data("value");

                    app.core.Post(app.setting.apipath + 'v1/Poliza/Altas', JSON.stringify(entry))
                        .done(function (posted) {
                            if (posted != null) {

                                //if (posted.Confirmation != '0') {
                                //    app.ui.Error(posted.Msg_err);
                                //    app.ui.ShowAlert('generalNotify', 'alert-danger', `<b> <i class="fa fa-check"></i> ${posted.Msg_err}</b>`);
                                //} else {
                                //    let msg = 'Se ha realizado la notificación de forma exitosa';
                                //    if (entry.Tipo_de_modification != '')
                                //        msg = 'Se ha realizado la modificación de forma exitosa';
                                //    app.ui.Success(posted.msg);
                                //    app.ui.ShowAlert('generalNotify', 'alert-success', `<b> <i class="fa fa-check"></i> ${msg}</b>`);
                                $("#EmitirPolizaEdtForm fieldset").prop("disabled", true);
                                $("#btnIssue").addClass('d-none');
                                //}
                            }
                        }).always(function () {
                            app.ui.ButtonDone('#btnIssue');
                        });

                }
                e.preventDefault();
            });

            spec['Changed'](function (data) {
                console.log(data);
                let ramo = app.ui.GetDropDownNumericValue('#RAMO');

                if (ramo == 117 || ramo == 401) {
                    $("#IMP_PRIMA_INFORMADA").parent().parent().removeClass('d-none');
                } else {
                    $("#IMP_PRIMA_INFORMADA").parent().parent().addClass('d-none');
                }
            });
            app.ui.SetDropDownNumericValue('#RAMO', 0, false);


        }
    };
})();