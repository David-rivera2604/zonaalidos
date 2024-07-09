var app = app || {};

app.Form_Ext_Altas = (function () {

    let _polizagrupo = {};

    let _test = {
        "RAMO": 401,
        "RAMODesc": "Saldo deudor declarativo",
        "NUM_CONTRATO": 74,
        "NUM_CONTRATODesc": "A.S.E.P.G. CRC 74",
        "NUM_POLIZA_GRUPO": "4010000000021",
        "MONEDA": "COLONES",
        "EFEC_SPTO": "2024-06-26T00:00:00",
        "VCTO_SPTO": "2025-06-26T00:00:00",
        "COD_DOCUM_ASEGType": 1,
        "COD_DOCUM_ASEG": "04-5945-1489",
        "NOM_TERCERO_ASEG": "DEMIAN",
        "APE_TERCERO_ASEG": "TORRES",
        "NAC_ASEG": "1998-06-06T00:00:00",
        "MCA_SEXO_ASEG": 1,
        "MCA_SEXO_ASEGDesc": "Masculino",
        "NACIONALIDAD_ASEG": "CRI",
        "NACIONALIDAD_ASEGDesc": "COSTA RICA",
        "COD_ESTADO": 5,
        "COD_ESTADODesc": "GUANACASTE",
        "COD_PROVINCIA": 505,
        "COD_PROVINCIADesc": "CARRILLO",
        "COD_LOCALIDAD": 50504,
        "COD_LOCALIDADDesc": "BELEN",
        "DOMICILIO": "AVENIDA ALAMEDA",
        "NUM_PRESTAMO": "2002",
        "INI_PRESTAMO": "2023-06-14T00:00:00",
        "VCTO_PRESTAMO": "2024-07-14T00:00:00",
        "IMP_SUMA_ASEG": 500000,
        "IMP_PRIMA_INFORMADA": 1000000,
        "ID_CRED_ESTUDIANTE": "",
        "MCA_ASISTENCIA": 2,
        "MCA_ASISTENCIADesc": "No",
        "IMP_SUMA_MUERTE": 0
    };


    function update_info_poliza_grupo() {
        let contracto = app.ui.GetDropDownNumericValue('#NUM_CONTRATO');
        let setdefaultVcto = true;
        if (contracto > 0) {
            let _polizagrupo = app.core.Data().lookups.filter(i => i.Key === 'Contratos_v2')[0].Lkp.filter(l => l.Code === contracto + '')[0];

            if (_polizagrupo != null) {
                $('#NUM_POLIZA_GRUPO').val(_polizagrupo.NUM_POLIZA);
                $('#MONEDA').val(_polizagrupo.NOM_MON);
                if (_polizagrupo.FEC_VCTO_POLIZA != null) {
                    app.ui.SetDateValue('#VCTO_SPTO', moment(_polizagrupo.FEC_VCTO_POLIZA, 'DD/MM/YYYY').toDate());
                    setdefaultVcto = false;
                }
            }
        }

        if (setdefaultVcto) {
            let newvcto = app.ui.GetDateRawValue('#EFEC_SPTO');
            newvcto.setFullYear(newvcto.getFullYear() + 1);
            app.ui.SetDateValue('#VCTO_SPTO', newvcto);
        }
    };

    return {
        Init: function (spec, formName) {
            let cod_pais = 'CRI';
            let options = spec.Options();
            options.Base = `cod_pais=${cod_pais}`;
            //options.Changed = function (data, source) { onsole.log('Changed', data, source); };

            options.Events = function (field, data, source) {
                //console.log('Event', field, data, source);
                if (field === '#COD_DOCUM_ASEG' && source === 'Identification') {
                    if (data != null) {
                        $('#NOM_TERCERO_ASEG').val(data.FirstName);
                        $('#APE_TERCERO_ASEG').val(data.LastName);
                        app.ui.SetDateValue('#NAC_ASEG', data.BirthDate);
                        app.ui.SetRadioNumericValue('MCA_SEXO_ASEG', data.Gender === 2 ? 0 : 1);
                        app.ui.SetDropDownStringValue('#NACIONALIDAD_ASEG', data.CountryOfNationalityISO, false);
                        app.ui.SetDropDownNumericValue('#COD_ESTADO', data.Province, false);
                        //app.ui.SetDropDownNumericValue('#COD_PROVINCIA', data.Canton, false);
                        //app.ui.SetDropDownNumericValue('#COD_LOCALIDAD', data.District, false);

                        app.core.LookupDependency(data.Province, 'COD_PROVINCIA', 'Cantones', '', data.Canton, false, null, `cod_pais=${cod_pais}:cod_estado=`);
                        app.core.LookupDependency(data.Canton, 'COD_LOCALIDAD', 'Distritos', '', data.District, false, null, `cod_pais=${cod_pais}:cod_prov=`);

                        $('#DOMICILIO').val(data.AddressDetail);
                    } else {
                        $('#NOM_TERCERO_ASEG').val('');
                        $('#APE_TERCERO_ASEG').val('');
                        app.ui.SetDateValue('#NAC_ASEG', null);
                        app.ui.SetRadioNumericValue('MCA_SEXO_ASEG', null);
                        app.ui.SetDropDownStringValue('#NACIONALIDAD_ASEG', 'CRI', true);
                        app.ui.SetDropDownNumericValue('#COD_ESTADO', null, false);
                        app.ui.SetDropDownNumericValue('#COD_PROVINCIA', null, false);
                        app.ui.SetDropDownNumericValue('#COD_LOCALIDAD', null, false);
                        $('#DOMICILIO').val('');
                    }
                }
            };

            spec.SetOptions(options);

            app.core.Lookups(options.Lookups,
                function () {
                    app.ui.SetDropDownStringValue('#NACIONALIDAD_ASEG', 'CRI', false);
                    $('#COD_ESTADO').on('change', function () {
                        app.core.LookupDependency($('select#COD_ESTADO').val(), 'COD_PROVINCIA', 'Cantones', '', null, true, null, `cod_pais=${cod_pais}:cod_estado=`);
                    });
                    $('#COD_PROVINCIA').on('change', function () {
                        var pais = $('select#cod_pais').val();
                        app.core.LookupDependency($('select#COD_PROVINCIA').val(), 'COD_LOCALIDAD', 'Distritos', '', null, false, null, `cod_pais=${cod_pais}:cod_prov=`);
                    });
                }, options.Base);

            $('#RAMO').on('change', function () {
                let cod_ramo = app.ui.GetDropDownNumericValue('#RAMO');
                app.core.Lookups(['Contratos_v2.NUM_CONTRATO'], function () {

                    $("#NUM_CONTRATO").prop("disabled", $('#NUM_CONTRATO').children().length == 0);

                    $('#NUM_POLIZA_GRUPO').val('');
                    $('#MONEDA').val('');

                }, options.Base + `:cod_ramo=${cod_ramo}`);
            });

            $('#EFEC_SPTO').blur(function () {
                let minDate = app.ui.GetDateRawValue('#EFEC_SPTO');
                minDate.setDate(minDate.getDate() + 1);

                $('#VCTO_SPTO_group').data("DateTimePicker").minDate(minDate);

                update_info_poliza_grupo();
            });

            $('#NUM_CONTRATO').on('change', function () {
                update_info_poliza_grupo();
            });

            $('#testdata').val(JSON.stringify(_test));

            $('#setdata').click(function (e) {
                let data = JSON.parse($('#testdata').val());
                data.testdata = $('#testdata').val();

                app.EmitirPoliza.SetData(data);
                $('#RAMO').change();
                let l1 = setInterval(function () {
                    app.EmitirPoliza.SetData(data);
                    clearInterval(l1)
                }, 1000);
                $('#COD_ESTADO').change();
                let l2 = setInterval(function () {
                    app.core.LookupDependency(data.COD_ESTADO, 'COD_PROVINCIA', 'Cantones', '', data.COD_PROVINCIA, false, null, `cod_pais=CRI:cod_estado=`);
                    clearInterval(l2)
                }, 500);
                $('#COD_PROVINCIA').change();
                let l3 = setInterval(function () {
                    app.core.LookupDependency(data.COD_PROVINCIA, 'COD_LOCALIDAD', 'Distritos', '', data.COD_LOCALIDAD, false, null, `cod_pais=CRI:cod_prov=`);
                    clearInterval(l3)
                }, 1000);

                e.preventDefault();
            });

            $('#btnIssue').click(function (e) {
                if (spec.IsValid(true)) {
                    $('#generalNotify').html('');
                    app.ui.ButtonDoing('#btnIssue');
                    let entry = spec.Data();

                    entry.TIP_DOCUM_ASEG = $("#COD_DOCUM_ASEGType").data("value");

                    app.core.Post(app.setting.apipath + 'v1/Poliza/Altas', JSON.stringify(entry))
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

            app.ui.SetDropDownNumericValue('#RAMO', 0, false);
            app.ui.SetRadioNumericValue('MCA_SEXO_ASEG', 0);
            app.ui.SetRadioNumericValue('MCA_ASISTENCIA', 2);
            let today = app.ui.Today();
            app.ui.SetDateValue('#EFEC_SPTO', today);
            $('#EFEC_SPTO').blur();
            let fec_vcto = today.setFullYear(today.getFullYear() + 1);
            app.ui.SetDateValue('#VCTO_SPTO', fec_vcto);
            spec.Changed(false);
        }
    };
})();