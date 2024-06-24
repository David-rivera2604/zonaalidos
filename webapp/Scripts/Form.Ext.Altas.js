var app = app || {};

app.Form_Ext_Altas = (function () {


    return {
        Init: function (spec, formName) {

            let options = spec.Options();

            options.Changed = function (data, source) {
                console.log('Changed', data, source);

                //    let ramo = app.ui.GetDropDownNumericValue('#RAMO');

                //    if (ramo == 117 || ramo == 401) {
                //        $("#IMP_PRIMA_INFORMADA").parent().parent().removeClass('d-none');
                //    } else {
                //        $("#IMP_PRIMA_INFORMADA").parent().parent().addClass('d-none');
                //    }
            };

            options.Events = function (field, data, source) {
                console.log('Event', field, data, source);
                if (field === '#COD_DOCUM_ASEG' && source === 'Identification') {
                    if (data != null) {
                        $('#NOM_TERCERO_ASEG').val(data.FirstName);
                        $('#APE_TERCERO_ASEG').val(data.LastName);
                        app.ui.SetDateValue('#NAC_ASEG', data.BirthDate);
                        app.ui.SetRadioNumericValue('MCA_SEXO_ASEG', data.Gender);
                        app.ui.SetDropDownStringValue('#NACIONALIDAD_ASEG', data.CountryOfNationality, true);
                        app.ui.SetDropDownNumericValue('#COD_ESTADO', data.Province, false);
                        app.ui.SetDropDownNumericValue('#COD_PROVINCIA', data.Canton, false);
                        app.ui.SetDropDownNumericValue('#COD_LOCALIDAD', data.District, false);
                        $('#DOMICILIO').val(data.DOMICILIO);
                    } else {
                        $('#NOM_TERCERO_ASEG').val('');
                        $('#APE_TERCERO_ASEG').val('');
                        app.ui.SetDateValue('#NAC_ASEG', null);
                        app.ui.SetRadioNumericValue('MCA_SEXO_ASEG', data.MCA_SEXO_ASEG);
                        app.ui.SetDropDownStringValue('#NACIONALIDAD_ASEG', 'CRI', true);
                        app.ui.SetDropDownNumericValue('#COD_ESTADO', null, false);
                        app.ui.SetDropDownNumericValue('#COD_PROVINCIA', null, false);
                        app.ui.SetDropDownNumericValue('#COD_LOCALIDAD', null, false);
                        $('#DOMICILIO').val('');
                    }
                }
            };

            spec.SetOptions(options);

            //app.core.Lookups(options.Lookups,
            //    function () {
            //        $('#COD_ESTADO').on('change', function () {
            //            var pais = $('select#cod_pais').val();
            //            app.core.LookupDependency($('select#COD_ESTADO').val(), 'COD_PROVINCIA', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
            //        });
            //        $('#COD_PROVINCIA').on('change', function () {
            //            var pais = $('select#cod_pais').val();
            //            app.core.LookupDependency($('select#COD_PROVINCIA').val(), 'COD_LOCALIDAD', 'Distritos', '', null, false, null, `cod_pais=${pais}:cod_prov=`);
            //        });
            //    }, options.Base);

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
                                $(".resultadoToggle").removeClass('d-none');
                                //}
                            }
                        }).always(function () {
                            app.ui.ButtonDone('#btnIssue');
                        });

                }
                e.preventDefault();
            });

            app.ui.SetDropDownNumericValue('#RAMO', 194, false);
            app.ui.SetRadioNumericValue('MCA_SEXO_ASEG', 0);
            let today = app.ui.Today();
            app.ui.SetDateValue('#EFEC_SPTO', today);
            $('#EFEC_SPTO').blur();
            let fec_vcto = today.setFullYear(today.getFullYear() + 1);
            app.ui.SetDateValue('#VCTO_SPTO', fec_vcto);
            app.ui.SetDropDownStringValue('#NACIONALIDAD_ASEG', 'CRI', false);
            spec.Changed(false);
        }
    };
})();