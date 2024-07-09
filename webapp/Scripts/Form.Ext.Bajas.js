var app = app || {};

app.Form_Ext_Bajas = (function () {

    return {
        Init: function (spec, formName) {
            let cod_pais = 'CRI';
            let options = spec.Options();
            options.Base = `cod_pais=${cod_pais}`;
            spec.SetOptions(options);

            let poliza = app.core.URLStringValue('poliza', '');

            $("#COD_DOCUM_ASEGType").prop("disabled", true);
            $("#btnIssue").prop("disabled", true);
            

            $('#btnIssue').click(function (e) {
                if (spec.IsValid(true)) {
                    $('#generalNotify').html('');
                    app.ui.ButtonDoing('#btnIssue');
                    let entry = spec.Data();

                    entry.TIP_DOCUM_ASEG = $("#COD_DOCUM_ASEGType").data("value");

                    app.core.Post(app.setting.apipath + 'v1/Poliza/Bajas', JSON.stringify(entry))
                        .done(function (posted) {
                            console.log(posted);
                            if (posted != null) {
                                if (posted.ID_TIP_RESPUESTA === 1 || posted.ID_TIP_RESPUESTA === 2) {
                                    let msg = 'La póliza fue emitida de forma exitosa';
                                    if (posted.ID_TIP_RESPUESTA === 2)
                                        msg = +', pero retenida por control técnico';
                                    app.ui.Success(msg);
                                    app.ui.ShowAlert('generalNotify', 'alert-success', `<b> <i class="fa fa-check"></i> ${msg}</b>`);

                                    $("#EmitirPolizaEdtForm fieldset").prop("disabled", true);
                                    $("#btnIssue").addClass('d-none');
                                    $(".resultadoToggle").removeClass('d-none');
                                } else {
                                    console.error(posted);
                                    app.ui.Error(posted.OBSERVACION || posted.ERROR);
                                    app.ui.ShowAlert('generalNotify', 'alert-danger', `<b> <i class="fa fa-check"></i> ${posted.OBSERVACION || posted.ERROR} - ${posted.ID_TIP_RESPUESTA} </b>`);
                                }
                            }
                        }).always(function () {
                            app.ui.ButtonDone('#btnIssue');
                        });

                }
                e.preventDefault();
            });

            app.core.dataapi('GET', `PolicyToCancel/${poliza}`)
                .then(data => {
                    console.log(data);
                    if (data != null) {
                        app.ui.SetDropDownNumericValue('#RAMO', data.COD_RAMO, false);
                        $('#RAMO').change();
                        app.core.Lookups(['Contratos_v2.NUM_CONTRATO'], function () {

                            //$("#NUM_CONTRATO").prop("disabled", $('#NUM_CONTRATO').children().length == 0);

                            app.ui.SetDropDownNumericValue('#NUM_CONTRATO', data.NUM_CONTRATO, false);

                            let _polizagrupo = app.core.Data().lookups.filter(i => i.Key === 'Contratos_v2')[0].Lkp.filter(l => l.Code === data.NUM_CONTRATO + '')[0];
                            let setdefaultVcto = true;

                            if (_polizagrupo != null) {
                                $('#NUM_POLIZA_GRUPO').val(_polizagrupo.NUM_POLIZA);
                                $('#MONEDA').val(_polizagrupo.NOM_MON);
                                if (_polizagrupo.FEC_VCTO_POLIZA != null) {
                                    app.ui.SetDateValue('#VCTO_SPTO', moment(_polizagrupo.FEC_VCTO_POLIZA, 'DD/MM/YYYY').toDate());
                                    setdefaultVcto = false;
                                }
                            }

                            app.ui.SetDateValue('#EFEC_SPTO', data.FEC_EFEC_POLIZA);
                            app.ui.SetDateValue('#VCTO_SPTO', data.FEC_VCTO_POLIZA);


                        }, options.Base + `:cod_ramo=${data.COD_RAMO}`);

                        let tip_docu = 1;
                        switch (data.COD_DOCUM_ASEGType) {
                            case 'CNA':
                                tip_docu = 1;
                                break;
                            case 'CRE':
                                tip_docu = 2;
                                break;
                            case 'PAS':
                                tip_docu = 3;
                                break;
                            case 'CJU':
                                tip_docu = 4;
                                break;
                        }
                        app.ui.SetDocumentTypeValue('#COD_DOCUM_ASEGType', tip_docu);
                        $('#COD_DOCUM_ASEG').val(data.COD_DOCUM);
                        $('#NOM_TERCERO_ASEG').val(data.NOM_TERCERO);
                        $('#APE_TERCERO_ASEG').val(data.APE1_TERCERO);
                        app.ui.SetDateValue('#NAC_ASEG', data.FEC_NACIMIENTO);
                        app.ui.SetRadioNumericValue('MCA_SEXO_ASEG', data.MCA_SEXO == 'M' || data.MCA_SEXO == '1' ? 1 : 0);
                        $('#DOMICILIO').val(data.NOM_DOMICILIO1);
                        app.core.Lookups(options.Lookups,
                            function () {
                                app.ui.SetDropDownStringValue('#NACIONALIDAD_ASEG', data.COD_NACIONALIDAD, false);
                                app.ui.SetDropDownNumericValue('#COD_ESTADO', data.COD_ESTADO, false);

                                app.core.LookupDependency(data.COD_ESTADO, 'COD_PROVINCIA', 'Cantones', '', data.COD_PROV, false, null, `cod_pais=${cod_pais}:cod_estado=`);
                                app.core.LookupDependency(data.COD_PROV, 'COD_LOCALIDAD', 'Distritos', '', data.COD_LOCALIDAD, false, null, `cod_pais=${cod_pais}:cod_prov=`);


                            }, options.Base);


                        $('#COD_PLAN_AP').val(data.COD_PLAN_AP);
                        $('#NUM_PRESTAMO').val(data.NUM_PRESTAMO);

                        

                        app.ui.SetNumericValue('#IMP_PRIMA_INFORMADA', data.IMP_PRIMA_INFORMADA);
                        if (data.FEC_VCTO_PRESTAMO != null && data.FEC_VCTO_PRESTAMO != '') {
                            app.ui.SetDateValue('#VCTO_PRESTAMO', moment(data.FEC_VCTO_PRESTAMO, 'DDMMYYYY').toDate());
                        }
                        app.ui.SetRadioNumericValue('MCA_ASISTENCIA', data.MCA_COBRA_ASISTENCIA);
                        $("#btnIssue").prop("disabled", false);
                    }
                });

        }
    };
})();