var app = app || {};

app.Form_Ext_Bajas = (function () {

    function show(row) {

        //let row = {
        //    NUM_POLIZA: "4012200005031", FEC_EFEC_SPTO: app.ui.Today(), FEC_VCTO_SPTO: app.ui.Today(), PRIMA_TOTAL: "CRC-9.100.00", OBSERVACION: " aasdAS D ;alsdk ;D as;dlKAS DA;SLDKa",
        //    RECIBOS_RECAUDADOS: [
        //        {
        //            NUM_RECIBO: 11035207,
        //            MONTO: "CRC/-214,88"
        //        }],
        //    RECIBOS_ANULADOS: [
        //        {
        //            NUM_RECIBO: 11035207,
        //            MONTO: "CRC/-214,88"
        //        },
        //        {
        //            NUM_RECIBO: 11035208,
        //            MONTO: "CRC/-214,88"
        //        },
        //        {
        //            NUM_RECIBO: 11035209,
        //            MONTO: "CRC/-214,88"
        //        },
        //        {
        //            NUM_RECIBO: 11035210,
        //            MONTO: "CRC/-214,88"
        //        },
        //        {
        //            NUM_RECIBO: 11035211,
        //            MONTO: "CRC/-214,88"
        //        },
        //        {
        //            NUM_RECIBO: 11035212,
        //            MONTO: "CRC/-214,88"
        //        }
        //    ]
        //}


        var html = [];


        html.push('<div class="row">');

        [
            { key: 'Inicio de vigencia', value: app.ui.StringValueToString(row.FEC_EFEC_SPTO, '---'), size: 6 },
            { key: 'Fin de vigencia', value: app.ui.StringValueToString(row.FEC_VCTO_SPTO, '---'), size: 6 },
            { key: 'Prima total', value: `${app.ui.StringValueToString(row.PRIMA_TOTAL, '---')}`, size: 6 },
            { key: 'Observación', value: `${app.ui.StringValueToString(row.OBSERVACION, '---')}`, size: 12 }
        ].forEach(function (item) {
            html.push(`<div class="col-md-${item.size}"><div class="readonlyfield"><strong>${item.key}</strong><div>${item.value}</div></div></div>`);
        });
        html.push(`</div>`);

        html.push('<div class="row">');
        html.push(`<div class="col-md-12"><div class="readonlyfield"><strong>Recibos recaudados</strong>`);
        if (row.RECIBOS_RECAUDADOS == null) {
            html.push(`<div>No hay recibos recaudados</div>`);
        } else {
            html.push('<table class="table table-hover margin bottom">');
            html.push('<thead><tr><th style="width: 1%" class="text-center">No.</th><th>Recibo</th><th class="text-center">Monto</th></tr></thead><tbody>');
            row.RECIBOS_RECAUDADOS.forEach(function (item, index) {
                html.push(`<tr><td class="text-center">${index + 1}</td><td> ${item.NUM_RECIBO}</td><td class="text-center"><span class="label label-primary">${item.MONTO}</span></td></tr>`);
            });
            html.push('</tbody></table>');
        }
        html.push(`</div></div></div>`);

        html.push('<div class="row">');
        html.push(`<div class="col-md-12"><div class="readonlyfield"><strong>Recibos anulados</strong>`);
        if (row.RECIBOS_ANULADOS == null) {
            html.push(`<div>No hay recibos anulados</div>`);
        } else {
            html.push('<table class="table table-hover margin bottom">');
            html.push('<thead><tr><th style="width: 1%" class="text-center">No.</th><th>Recibo</th><th class="text-center">Monto</th></tr></thead><tbody>');
            row.RECIBOS_ANULADOS.forEach(function (item, index) {
                html.push(`<tr><td class="text-center">${index + 1}</td><td> ${item.NUM_RECIBO}</td><td class="text-center"><span class="label label-primary">${item.MONTO}</span></td></tr>`);
            });
            html.push('</tbody></table>');
        }
        html.push(`</div></div></div>`);

        app.ui.ShowSideBar({ title: 'PÓLIZA #{NUM_POLIZA}', subtitle: 'La póliza fue anulada de forma exitosa', isHTML: true, HTML: html.join(''), data: row, width: '380px' });

        $('.sidebar-content').toggleClass('sk-loading');
    }

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
                                    let msg = 'La póliza fue anulada de forma exitosa';
                                    if (posted.ID_TIP_RESPUESTA === 2)
                                        msg = +', pero retenida por control técnico';
                                    app.ui.Success(msg);
                                    app.ui.ShowAlert('generalNotify', 'alert-success', `<b> <i class="fa fa-check"></i> ${msg}</b>`);

                                    $("#btnIssue").addClass('d-none');
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

            $('.ibox-content').toggleClass('sk-loading');            
            app.core.datapi('GET', `PolicyToCancel/${poliza}`)
                .then(data => {
                    console.log(data);
                    if (data.General != null) {
                        app.ui.SetDropDownNumericValue('#RAMO', data.General.COD_RAMO, false);
                        $('#RAMO').change();
                        app.core.Lookups(['Contratos_v2.NUM_CONTRATO'], function () {

                            //$("#NUM_CONTRATO").prop("disabled", $('#NUM_CONTRATO').children().length == 0);

                            app.ui.SetDropDownNumericValue('#NUM_CONTRATO', data.General.NUM_CONTRATO, false);

                            let _polizagrupo = app.core.Data().lookups.filter(i => i.Key === 'Contratos_v2')[0].Lkp.filter(l => l.Code === data.General.NUM_CONTRATO + '')[0];
                            let setdefaultVcto = true;

                            if (_polizagrupo != null) {
                                $('#NUM_POLIZA_GRUPO').val(_polizagrupo.NUM_POLIZA);
                                $('#MONEDA').val(_polizagrupo.NOM_MON);
                                if (_polizagrupo.FEC_VCTO_POLIZA != null) {
                                    app.ui.SetDateValue('#VCTO_SPTO', moment(_polizagrupo.FEC_VCTO_POLIZA, 'DD/MM/YYYY').toDate());
                                    setdefaultVcto = false;
                                }
                            }

                            app.ui.SetDateValue('#EFEC_SPTO', data.General.FEC_EFEC_POLIZA);
                            app.ui.SetDateValue('#VCTO_SPTO', data.General.FEC_VCTO_POLIZA);


                        }, options.Base + `:cod_ramo=${data.General.COD_RAMO}`);

                        let tip_docu = 1;
                        switch (data.General.COD_DOCUM_ASEGType) {
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
                        $('#COD_DOCUM_ASEG').val(data.General.COD_DOCUM);
                        $('#NOM_TERCERO_ASEG').val(data.General.NOM_TERCERO);
                        $('#APE_TERCERO_ASEG').val(data.General.APE1_TERCERO);
                        app.ui.SetDateValue('#NAC_ASEG', data.General.FEC_NACIMIENTO);
                        app.ui.SetRadioNumericValue('MCA_SEXO_ASEG', data.General.MCA_SEXO == 'M' || data.General.MCA_SEXO == '1' ? 1 : 0);
                        $('#DOMICILIO').val(data.General.NOM_DOMICILIO1);
                        app.core.Lookups(options.Lookups,
                            function () {
                                app.ui.SetDropDownStringValue('#NACIONALIDAD_ASEG', data.General.COD_NACIONALIDAD, false);
                                app.ui.SetDropDownNumericValue('#COD_ESTADO', data.General.COD_ESTADO, false);

                                app.core.LookupDependency(data.General.COD_ESTADO, 'COD_PROVINCIA', 'Cantones', '', data.General.COD_PROV, false, null, `cod_pais=${cod_pais}:cod_estado=`);
                                app.core.LookupDependency(data.General.COD_PROV, 'COD_LOCALIDAD', 'Distritos', '', data.General.COD_LOCALIDAD, false, null, `cod_pais=${cod_pais}:cod_prov=`);


                            }, options.Base);


                        $('#COD_PLAN_AP').val(data.General.COD_PLAN_AP);
                        $('#NUM_PRESTAMO').val(data.General.NUM_PRESTAMO);



                        app.ui.SetNumericValue('#IMP_PRIMA_INFORMADA', data.General.IMP_PRIMA_INFORMADA);
                        if (data.General.FEC_VCTO_PRESTAMO != null && data.General.FEC_VCTO_PRESTAMO != '') {
                            app.ui.SetDateValue('#VCTO_PRESTAMO', moment(data.General.FEC_VCTO_PRESTAMO, 'DDMMYYYY').toDate());
                        }
                        app.ui.SetRadioNumericValue('MCA_ASISTENCIA', data.General.MCA_COBRA_ASISTENCIA);
                        $("#btnIssue").prop("disabled", false);
                    }
                    $('.ibox-content').toggleClass('sk-loading');
                });

        }
    };
})();