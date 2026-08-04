var app = app || {};

app.Form_Ext_Altas = (function () {

    let _test = {
        "RAMO": 401,
        "RAMODesc": "Saldo deudor declarativo",
        "NUM_CONTRATO": 0,
        "NUM_CONTRATODesc": "",
        "NUM_POLIZA_GRUPO": "",
        "MONEDA": "",
        "EFEC_SPTO": "2025-08-01T00:00:00",
        "VCTO_SPTO": "2026-08-01T00:00:00",
        "COD_DOCUM_ASEGType": 1,
        "COD_DOCUM_ASEG": "02-5894-1365",
        "NOM_TERCERO_ASEG": "Wilson",
        "APE_TERCERO_ASEG": "Torres",
        "NAC_ASEG": "1999-06-06T00:00:00",
        "MCA_SEXO_ASEG": 1,
        "MCA_SEXO_ASEGDesc": "Masculino",
        "TLF_NUMERO_ASEG": "0689-0763",
        "OCUPACION_ASEG": 6002,
        "OCUPACION_ASEGDesc": " Abogado liberal y bufete de abogados que NO manejan fondos para terceros",
        "NACIONALIDAD_ASEG": "CRI",
        "NACIONALIDAD_ASEGDesc": "COSTA RICA",
        "COD_ESTADO": 5,
        "COD_ESTADODesc": "GUANACASTE",
        "COD_PROVINCIA": 505,
        "COD_PROVINCIADesc": "CARRILLO",
        "COD_LOCALIDAD": 50504,
        "COD_LOCALIDADDesc": "BELEN",
        "DOMICILIO": "",
        "NUM_PRESTAMO": "738913",
        "INI_PRESTAMO": "2025-08-01T00:00:00",
        "VCTO_PRESTAMO": "2026-08-01T00:00:00",
        "IMP_SUM_ASEG_VC": 0,
        "IMP_SUMA_ASEG": 50000,
        "IMP_PRIMA_FACT": 0,
        "IMP_PRIMA_INFORMADA": 20000,
        "ID_CRED_ESTUDIANTE": "",
        "MCA_ASISTENCIA": 2,
        "MCA_ASISTENCIADesc": "No",
        "IMP_SUMA_MUERTE": 0,
        "COD_PLAN_AP": null,
        "COD_PLAN_APDesc": "",
        "beneficiarios": [
            {
                "beneficiariosId": 1,
                "COD_DOCUM_BENEF": "09-1011-1258",
                "NOM_TERCERO_BENEF": "TEFA",
                "NOM2_TERCERO_BENEF": "2",
                "APE1_TERCERO_BENEF": "torres",
                "APE2_TERCERO_BENEF": "2",
                "FEC_NAC_BENEF": "2004-12-07T00:00:00",
                "MCA_SEXO_BENEF": "F",
                "MCA_SEXO_BENEFDesc": "Femenino",
                "TLF_NUMERO_BENEF": "4548-5362",
                "EMAIL_BENEF": "tefa123@gmail.com",
                "TIP_RELAC": 1,
                "TIP_RELACDesc": "Conyuge",
                "PCT_PARTICIPACION": 50,
                "PROVINCIA_BENEF": 2,
                "PROVINCIA_BENEFDesc": "ALAJUELA",
                "LOCALIDAD_BENEF": 201,
                "LOCALIDAD_BENEFDesc": "ALAJUELA"
            },
            {
                "beneficiariosId": 2,
                "COD_DOCUM_BENEF": "01-1586-4741",
                "NOM_TERCERO_BENEF": "dante",
                "NOM2_TERCERO_BENEF": "2",
                "APE1_TERCERO_BENEF": "sanntiago",
                "APE2_TERCERO_BENEF": "meneses",
                "FEC_NAC_BENEF": "2013-01-07T00:00:00",
                "MCA_SEXO_BENEF": "M",
                "MCA_SEXO_BENEFDesc": "Masculino",
                "TLF_NUMERO_BENEF": "5448-5362",
                "EMAIL_BENEF": "dante123@gmail.com",
                "TIP_RELAC": 1,
                "TIP_RELACDesc": "Conyuge",
                "PCT_PARTICIPACION": 50,
                "PROVINCIA_BENEF": 5,
                "PROVINCIA_BENEFDesc": "GUANACASTE",
                "LOCALIDAD_BENEF": 507,
                "LOCALIDAD_BENEFDesc": "ABANGARES"
            }
        ]
    };

    let _polizagrupo = null;

    function show(row) {

        //            let row = { NUM_POLIZA: "4012200005031", FEC_EFEC_SPTO: app.ui.Today(), FEC_VCTO_SPTO: app.ui.Today(), PRIMA_TOTAL: "CRC-9.100.00", COBERTURAS: " aasdAS D ;alsdk ;D as;dlKAS DA;SLDKa", OBSERVACION: " aasdAS D ;alsdk ;D as;dlKAS DA;SLDKa" }


        var html = [];


        html.push('<div class="row">');

        [
            { key: 'Inicio de vigencia', value: app.ui.StringValueToString(row.FEC_EFEC_SPTO, '---'), size: 6 },
            { key: 'Fin de vigencia', value: app.ui.StringValueToString(row.FEC_VCTO_SPTO, '---'), size: 6 },
            { key: 'Prima total', value: `${app.ui.StringValueToString(row.PRIMA_TOTAL, '---')}`, size: 6 },
            { key: 'Coberturas', value: `${app.ui.StringValueToString(row.COBERTURAS, '---')}`, size: 12 },
            { key: 'Observación', value: `${app.ui.StringValueToString(row.OBSERVACION, '---')}`, size: 12 }
        ].forEach(function (item) {
            html.push(`<div class="col-md-${item.size}"><div class="readonlyfield"><strong>${item.key}</strong><div>${item.value}</div></div></div>`);
        });
        html.push(`</div>`);

        html.push(`<div class="col-md-12"><div class="row">`);
        html.push('<table class="table table-hover margin bottom">');
        html.push('<thead><tr><th style="width: 1%" class="text-center">No.</th><th>Recibo</th><th class="text-center">Monto</th></tr></thead><tbody>');
        row.RECIBOS.forEach(function (item, index) {
            html.push(`<tr><td class="text-center">${index + 1}</td><td> ${item.NUM_RECIBO}</td><td class="text-center"><span class="label label-primary">${item.MONTO}</span></td></tr>`);
        });
        html.push('</tbody></table>');
        html.push(`</div></div>`);
        app.ui.ShowSideBar({ title: 'PÓLIZA #{NUM_POLIZA}', subtitle: 'La póliza fue emitida de forma exitosa', isHTML: true, HTML: html.join(''), data: row, width: '380px' });

       // $('.sidebar-content').toggleClass('sk-loading');
    }

    function update_info_poliza_grupo() {
        let cod_ramo = app.ui.GetDropDownNumericValue('#RAMO');
        let contracto = app.ui.GetDropDownNumericValue('#NUM_CONTRATO');
        let setdefaultVcto = true;
        if (contracto > 0) {
            _polizagrupo = app.core.Data().lookups.filter(i => i.Key === 'Contratos_v2')[0].Lkp.filter(l => l.Code === contracto + '')[0];

            if (_polizagrupo != null) {
                $('#NUM_POLIZA_GRUPO').val(_polizagrupo.NUM_POLIZA);
                $('#MONEDA').val(_polizagrupo.NOM_MON);
                if (_polizagrupo.FEC_VCTO_POLIZA != null && _polizagrupo.FEC_VCTO_POLIZA != '') {
                    app.ui.SetDateValue('#VCTO_SPTO', moment(_polizagrupo.FEC_VCTO_POLIZA, 'DD/MM/YYYY').toDate());
                    setdefaultVcto = false;
                }

                if (cod_ramo === 117) {
                    switch (_polizagrupo.MODALIDAD) {
                        case '11701':
                            $("#IMP_PRIMA_FACT").prop("disabled", true);
                            app.ui.SetDropDownNumericValue('#IMP_PRIMA_FACT', 0);
                            $("#IMP_PRIMA_INFORMADA").prop("disabled", true);
                            $(".IMP_PRIMA_FACTVisible").addClass('d-none');
                            app.ui.SetNumericValue('#IMP_PRIMA_INFORMADA', app.ui.GetNumericValue('#IMP_SUM_ASEG_VC'));
                            break;
                        case '11702':
                            $("#IMP_PRIMA_FACT").prop("disabled", false);
                            $(".IMP_PRIMA_FACTVisible").removeClass('d-none');
                            app.core.Lookups(['TRON_G2990006_ByMod:IMP_PRIMA_FACT.IMP_PRIMA_FACT'], function () {


                            },  `cod_ramo=${cod_ramo}:cod_modalidad=${_polizagrupo.MODALIDAD}`);
                            $("#IMP_PRIMA_INFORMADA").prop("disabled", true);
                            app.ui.SetNumericValue('#IMP_PRIMA_INFORMADA', 0);
                            break;
                        default:
                            $("#IMP_PRIMA_FACT").prop("disabled", false);
                            app.ui.SetDropDownNumericValue('#IMP_PRIMA_FACT', 0);
                            $(".IMP_PRIMA_FACTVisible").addClass('d-none');
                            $("#IMP_PRIMA_INFORMADA").prop("disabled", false);
                            break;
                    }
                }

            }
        }

        if (setdefaultVcto) {
            let newvcto = app.ui.GetDateRawValue('#EFEC_SPTO');
            newvcto.setFullYear(newvcto.getFullYear() + 1);
            app.ui.SetDateValue('#VCTO_SPTO', newvcto);
        }
    };

    function beneficiarios_table_OtherValidations() {
        var result = true;
        var beneficiarios = $('#beneficiariosTbl').bootstrapTable('getData');

        if (beneficiarios.length === 0) {
            result = false;
            $('#beneficiariosTbl-error').text('Debe existir al menos un beneficiario');
            $('#beneficiariosTbl-error').removeClass('d-none');
        }
        else if (beneficiarios.reduce((total, item) => total + item.PCT_PARTICIPACION, 0) != 100) {
            result = false;
            $('#beneficiariosTbl-error').text('El total del porcentaje de participación debe ser el 100%');
            $('#beneficiariosTbl-error').removeClass('d-none');
        }
        else {
            $('#beneficiariosTbl-error').text('');
            $('#beneficiariosTbl-error').addClass('d-none');
        }

        return result;
    }

    return {
        Init: function (spec, formName) {
            let cod_pais = 'CRI';
            let options = spec.Options();
            options.Base = `cod_pais=${cod_pais}`;
            options.Changed = function (data, source) {
                console.log('Changed', data, source);
                if (source === 'after') {
                    let polizagrupo = app.Form_Ext_Altas.polizagrupo();
                    console.log('xx', polizagrupo);
                    if (data.RAMO === 117 && polizagrupo != null) {
                        switch (polizagrupo.MODALIDAD) {
                            case '11701':
                                app.ui.SetNumericValue('#IMP_PRIMA_INFORMADA', app.ui.GetNumericValue('#IMP_SUM_ASEG_VC'));
                                break;
                            case '11702':
                                app.ui.SetNumericValue('#IMP_PRIMA_INFORMADA', app.ui.GetNumericValue('#IMP_SUM_ASEG_VC') * app.ui.GetDropDownNumericValue('#IMP_PRIMA_FACT'));
                                break;
                            default:
                                break;
                        }
                    }
                }
            };

            options.Events = function (field, data, source) {
                console.log('Event', field, data, source);
                if (field === '#COD_DOCUM_ASEG' && source === 'Identification') {
                    if (data != null) {
                        $('#NOM_TERCERO_ASEG').val(data.FirstName);
                        $('#APE_TERCERO_ASEG').val(data.LastName);
                        $('#EMAIL_ASEG').val(data.PrimaryEmailAddress);
                        $('#TLF_NUMERO_ASEG').val(data.PhoneNumber);
                        
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
                        $('#EMAIL_ASEG').val('');
                        $('#TLF_NUMERO_ASEG').val('');
                        app.ui.SetDateValue('#NAC_ASEG', null);
                        app.ui.SetRadioNumericValue('MCA_SEXO_ASEG', null);
                        app.ui.SetDropDownStringValue('#NACIONALIDAD_ASEG', 'CRI', true);
                        app.ui.SetDropDownNumericValue('#COD_ESTADO', null, false);
                        app.ui.SetDropDownNumericValue('#COD_PROVINCIA', null, false);
                        app.ui.SetDropDownNumericValue('#COD_LOCALIDAD', null, false);
                        $('#DOMICILIO').val('');
                    }
                }
                if (field === '#COD_DOCUM_BENEF' && source === 'Identification') {
                    if (data != null) {
                        $('#NOM_TERCERO_BENEF').val(data.FirstName);
                        $('#NOM2_TERCERO_BENEF').val(data.MiddleName);
                        $('#APE1_TERCERO_BENEF').val(data.LastName);
                        $('#APE2_TERCERO_BENEF').val(data.SecondLastName);

                        app.ui.SetDateValue('#FEC_NAC_BENEF', data.BirthDate);
                        app.ui.SetRadioStringValue('MCA_SEXO_BENEF', data.Gender === 2 ? 'M' : 'F');
                        $('#EMAIL_BENEF').val(data.PrimaryEmailAddress);
                        $('#TLF_NUMERO_BENEF').val(data.PhoneNumber);

                        app.ui.SetDropDownNumericValue('#PROVINCIA_BENEF', data.Canton, false);
                        app.ui.SetDropDownNumericValue('#LOCALIDAD_BENEF', data.District, false);

                        app.core.LookupDependency($('select#PROVINCIA_BENEF').val(), 'LOCALIDAD_BENEF', 'Cantones', '', null, true, null, `cod_pais=${cod_pais}:cod_estado=`);

                    } else {
                        $('#NOM_TERCERO_BENEF').val('');
                        $('#NOM2_TERCERO_BENEF').val('');
                        $('#APE1_TERCERO_BENEF').val('');
                        $('#APE2_TERCERO_BENEF').val('');
                        app.ui.SetDateValue('#FEC_NAC_BENEF', null);
                        app.ui.SetRadioNumericValue('MCA_SEXO_BENEF', null);
                        $('#EMAIL_BENEF').val('');
                        $('#TLF_NUMERO_BENEF').val('');
                        app.ui.SetDropDownNumericValue('#PROVINCIA_BENEF', null, false);
                        app.ui.SetDropDownNumericValue('#LOCALIDAD_BENEF', null, false);

                    }
                }
            };

            spec.SetOptions(options);

            $.validator.addMethod("ContratoVencido", function (value, element, params) {
                let result = true;
                _polizagrupo = app.core.Data().lookups.filter(i => i.Key === 'Contratos_v2')[0].Lkp.filter(l => l.Code === value + '')[0];

                if (_polizagrupo != null && _polizagrupo.FEC_VCTO_POLIZA != null && _polizagrupo.FEC_VCTO_POLIZA != '') {
                    let vcto = moment(_polizagrupo.FEC_VCTO_POLIZA, 'DD/MM/YYYY').toDate();
                    result = (vcto > app.ui.Today())
                    if (!result) {
                        $('#NUM_CONTRATO').rules('add', { messages: { ContratoVencido: `La póliza grupo se encuentra vencida ${_polizagrupo.FEC_VCTO_POLIZA}` } });
                    }
                }
                return result;
            });
            $(`#${formName}EdtForm`).validate(); $("#NUM_CONTRATO").rules('add', { ContratoVencido: true, messages: { ContratoVencido: "La póliza grupo se encuentra vencida" } });

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
                    $('#PROVINCIA_BENEF').on('change', function () {
                        app.core.LookupDependency($('select#PROVINCIA_BENEF').val(), 'LOCALIDAD_BENEF', 'Cantones', '', null, true, null, `cod_pais=${cod_pais}:cod_estado=`);
                    });
                    $('#OCUPACION_ASEG').select2({ width: '100%', theme: 'bootstrap4' });
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
                let data = _test; // JSON.parse($('#testdata').val());
                //data.testdata = $('#testdata').val();

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
                let other = app.Form_Ext_Altas.OtherValidations();
                if (spec.IsValid(true) && other) {
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
                                        msg = msg + ', pero retenida por control técnico';
                                    app.ui.Success(msg);
                                    app.ui.ShowAlert('generalNotify', 'alert-success', `<b> <i class="fa fa-check"></i> ${msg}</b>`);

                                    $("#EmitirPolizaEdtForm fieldset").prop("disabled", true);
                                    $("#btnIssue").addClass('d-none');
                                    //$(".resultadoToggle").removeClass('d-none');

                                    show(posted);

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

            let code = app.core.URLStringValue('ramo');
            if (code != '') {
                app.ui.SetDropDownNumericValue('#RAMO', code, false);
                $('#RAMO').change();
            } else {
                app.ui.SetDropDownNumericValue('#RAMO', 0, false);
            }
            app.ui.SetRadioNumericValue('MCA_SEXO_ASEG', 0);
            app.ui.SetRadioNumericValue('MCA_ASISTENCIA', 2);
            let today = app.ui.Today();
            app.ui.SetDateValue('#EFEC_SPTO', today);
            $('#EFEC_SPTO').blur();
            let fec_vcto = today.setFullYear(today.getFullYear() + 1);
            app.ui.SetDateValue('#VCTO_SPTO', fec_vcto);
            spec.Changed(false);
        },
        polizagrupo: function () {
            return _polizagrupo;
        },
        OtherValidations: function () {
            return beneficiarios_table_OtherValidations();
        }

    };
})();