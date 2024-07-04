var app = app || {};

app.ExtendClaims = (function () {

    let attr = '';

    async function LoadRelato(num_sini) {

        app.core.api_get(`Claim/${num_sini}/Story`)
            .then(data => {
                if (data !== null) {
                    $('#relato' + num_sini).html(app.ui.StringCapitalizeFormatter(data.TXT_RELATO));

                } else {
                    $('#relato' + num_sini).html('---');
                }
            });
    }

    return {
        Init: function () {
            if (app.core.URLStringValue('id') == '361') {
                attr = 'invisible';
            }
        },
        NUM_SINIFormatter: function (value, row, index, field) {
            let status = 'fa-check';
            let color = 'green';
            if (row.TIP_EST_SINI == 'P') {
                status = 'fa-clock-o';
                color = 'yellowgreen';
            }
            return `<i class="fa ${status}" aria-hidden="true" style="margin: 0px 8px 0px 5px;color: ${color};" title="${app.ui.StringCapitalizeFormatter(row.NOM_TIP_EST_SINI)}"></i>` +
                `<span  title="${app.ui.StringCapitalizeFormatter(row.NOM_CAUSA)}">` + row.NUM_SINI + '</span>' +
                `<button type="button" name="viewClaim" class="btn btn-slim btn-sm btn-link ${attr} event" title="Ver detalle del siniestro"><i class="fa fa-plus-square-o"></i></button>`;
        },
        ASIGESFormatter: function (value, row, index, field) {
            let comp = '';
            let asiges = row.ASIGES;

            if (asiges === null || asiges === '') {
                asiges = '';
            } else {
                comp = ' <button type="button" name="viewClaimPanel" class="btn btn-slim btn-sm btn-link event" title="Ver panel de siniestro"><i class="fa fa-plus-square-o" ></i></button>';
            }
            return `<span>${asiges}</span>` + comp;
        },
        NUM_POLIZAFormatter: function (value, row, index, field) {
            return `<span>${row.NUM_POLIZA}</span>` +
                ` <button type="button" name="viewPolicy" class="btn btn-slim btn-sm btn-link ${attr} event" title="Ver detalle de la póliza"><i class="fa fa-plus-square-o" ></i></button>`;
        },
        NOM_ASEGFormatter: function (value, row, index, field) {
            return `<span>${row.TIP_DOCUM_ASEG} ${row.COD_DOCUM_ASEG} - ${app.ui.StringCapitalizeFormatter(row.NOM_ASEG)} ${app.ui.StringCapitalizeFormatter(row.APE_ASEG)}</span>`;
        },
        NOM_ASEG2Formatter: function (value, row, index, field) {
            return `<span>${row.TIP_DOCUM_ASEG} ${row.COD_DOCUM_ASEG} - ${app.ui.StringCapitalizeFormatter(row.NOM_ASEG)} ${app.ui.StringCapitalizeFormatter(row.APE_ASEG)}</span>` +
                `<button type="button" name="viewTercero" class="btn btn-slim btn-sm btn-link ${attr} event" title="Ver detalle del tercero"><i class="fa fa-plus-square-o"></i></button>`;
        },
        FEC_SINIFormatter: function (value, row, index, field) {
            if (row.HORA_SINI != null) {
                value = value.replace("T00:00", "T" + row.HORA_SINI)
            }
            return '<span>' + moment(value).format('DD/MM/YYYY hh:mma') + '</span><br>';
        },
        NOM_EXPFormatter: function (value, row, index, field) {
            let status = 'fa-check';
            let color = 'green';
            if (row.TIP_EST_EXP == 'P') {
                status = 'fa-clock-o';
                color = 'yellowgreen';
            }
            if (value == null)
                return '';
            else
                return `<i class="fa ${status}" aria-hidden="true" style="margin: 0px 8px 0px 5px;color: ${color};" title="${app.ui.StringCapitalizeFormatter(row.NOM_TIP_EST_EXP)}"></i>` +
                    `<span>${row.NUM_EXP} - ${app.ui.StringCapitalizeFormatter(value)}</span>` +
                    ` <button type="button" name="viewClaimExp" class="btn btn-slim btn-sm btn-link ${attr} event" title="Ver detalle del expediente"><i class="fa fa-plus-square-o" ></i></button>`;
        },
        NOM_TIP_EST_SINICellStyle: function (value, row, index) {
            if (row.TIP_EST_SINI === 'P') {
                return {
                    css: {
                        'background': 'lightyellow'
                    }
                }
            }
            else
                return {};
        },
        ShowClaimDetail: function (row) {
            var html = [];

            let d = $('#1GridTbl').bootstrapTable('getData').filter(r => r.NUM_SINI == row.NUM_SINI);

            let reserva = d.reduce((accumulator, item) => { return accumulator + item.IMP_RESERVA; }, 0);
            let estimado = d.reduce((accumulator, item) => { return accumulator + item.IMP_ESTIMADO; }, 0);
            let liquidado = d.reduce((accumulator, item) => { return accumulator + item.IMP_LIQUIDADO; }, 0);
            let pagado = d.reduce((accumulator, item) => { return accumulator + item.IMP_PAGADO; }, 0);

            html.push('<div class="row">');
            [
                { key: 'Ocurrencia', value: `${app.ui.DateTimeValueToString(row.FEC_SINI, row.HORA_SINI, '---')}`, size: 6 },
                { key: 'Termino', value: `${app.ui.DateTimeValueToString(row.FEC_TERM_SINI, undefined, '---')}`, size: 6 },
                { key: 'Ramo', value: `${row.COD_RAMO} - ${app.ui.StringCapitalizeFormatter(row.NOM_RAMO)}`, size: 12 },
                { key: 'Causa', value: `${row.COD_CAUSA_SINI} - ${app.ui.StringCapitalizeFormatter(row.NOM_CAUSA)}`, size: 12 },
                { key: 'Reserva', value: app.ui.DecimalWithZeroFormatter(reserva), size: 6 },
                { key: 'Estimado', value: app.ui.DecimalWithZeroFormatter(estimado), size: 6 },
                { key: 'Liquidado', value: app.ui.DecimalWithZeroFormatter(liquidado), size: 6 },
                { key: 'Pagado', value: app.ui.DecimalWithZeroFormatter(pagado), size: 6 },
                { key: 'Descripción del riesgo', value: app.ui.StringCapitalizeFormatter(row.NOM_RIESGO), size: 12 },
                { key: 'Tomando', value: `${row.TIP_DOCUM_TOMADOR} ${row.COD_DOCUM_TOMADOR} - ${app.ui.StringCapitalizeFormatter(row.NOM_TOMADOR)} ${app.ui.StringCapitalizeFormatter(row.APE_TOMADOR)}`, size: 12 },
                { key: 'Asegurado', value: `${row.TIP_DOCUM_ASEG} ${row.COD_DOCUM_ASEG} - ${app.ui.StringCapitalizeFormatter(row.NOM_ASEG)} ${app.ui.StringCapitalizeFormatter(row.APE_ASEG)}`, size: 12 },
                { key: 'Email del asegurado', value: `${row.EMAIL_ASEG}`, size: 12 },
                { key: 'Contacto', value: `${row.TIP_DOCUM_CONTACTO} ${row.COD_DOCUM_ASEG} - ${app.ui.StringCapitalizeFormatter(row.NOM_CONTACTO)} ${app.ui.StringCapitalizeFormatter(row.APE_CONTACTO)}`, size: 12 },
                { key: 'Email del contacto', value: `${app.ui.StringValueToString(row.EMAIL_CONTACTO, '---')}`, size: 12 },
                { key: 'Teléfono del contacto', value: `${app.ui.StringValueToString(row.TEL_NUMERO_CONTACTO, '---')}`, size: 12 },
                { key: 'Relato', value: `<span id="relato${row.NUM_SINI}">Buscando información del relato para el siniestro ${row.NUM_SINI}...<span>`, size: 12 },
            ].forEach(function (item) {
                html.push(`<div class="col-md-${item.size}"><div class="readonlyfield"><strong>${item.key}</strong><div>${item.value}</div></div></div>`);
            });
            html.push(`</div>`);
            app.ui.ShowSideBar({ title: 'SINIESTRO #{NUM_SINI}', subtitle: 'Información', isHTML: true, HTML: html.join(''), data: row, width: '360px' });
            LoadRelato(row.NUM_SINI);
        },
        ShowExpedienteDetail: function (row) {
            var html = [];
            html.push('<div class="row">');
            [
                { key: 'Expediente', value: `${row.TIP_EXP} - ${app.ui.StringCapitalizeFormatter(row.NOM_EXP)}`, size: 12 },
                { key: 'Ocurrencia', value: app.ui.DateFormatter(row.FEC_OCURRENCIA), size: 6 },
                { key: 'Apertura', value: app.ui.DateFormatter(row.FEC_APER_EXP), size: 6 },
                { key: 'Termino', value: app.ui.DateFormatter(row.FEC_TERM_EXP), size: 6 },
                { key: 'Estado', value: app.ui.StringCapitalizeFormatter(row.NOM_TIP_EST_EXP), size: 12 },
                { key: 'Reserva', value: app.ui.DecimalWithZeroFormatter(row.IMP_RESERVA), size: 6 },
                { key: 'Estimado', value: app.ui.DecimalWithZeroFormatter(row.IMP_ESTIMADO), size: 6 },
                { key: 'Liquidado', value: app.ui.DecimalWithZeroFormatter(row.IMP_LIQUIDADO), size: 6 },
                { key: 'Pagado', value: app.ui.DecimalWithZeroFormatter(row.IMP_PAGADO), size: 6 },
                { key: 'Persona relacionada al expediente', value: row.COD_DOCUM == null ? '---' : `${row.TIP_DOCUM} ${row.COD_DOCUM} - ${app.ui.StringCapitalizeEachWordFormatter(row.NOMBRE)} ${app.ui.StringCapitalizeEachWordFormatter(row.APELLIDOS)}`, size: 12 },
            ].forEach(function (item) {
                html.push(`<div class="col-md-${item.size}"><div class="readonlyfield"><strong>${item.key}</strong><div>${item.value}</div></div></div>`);
            });

            html.push('</div>');

            app.ui.ShowSideBar({ title: 'EXPEDIENTE #{NUM_EXP}', subtitle: 'Información', isHTML: true, HTML: html.join(''), data: row, width: '360px' })
        },
        ShowTercero: function (row) {
            app.ui.ShowSideBar({ title: 'TERCERO - {TIP_DOCUM_ASEG} {COD_DOCUM_ASEG}', subtitle: 'Información', isHTML: true, HTML: `<div id="tercero${row.COD_DOCUM_ASEG}"></div>`, data: row, width: '360px' })

            $('.sidebar-content').toggleClass('sk-loading');

            app.core.api_get(`client/${row.COD_DOCUM_ASEG}`)
                .then(data => {
                    if (data != null) {
                        let info = data;
                        let html = [];
                        let isEmpleado = localStorage.getItem('Roles').includes('Empleado');
                        html.push('<div class="row">');
                        [
                            { key: 'Identificación', value: `${info.TIP_DOCUM} ${info.COD_DOCUM}`, size: 6, visible: true },
                            { key: 'Nombre', value: `${app.ui.StringCapitalizeFormatter(info.NOM_TERCERO)}`, size: 6, visible: true },
                            { key: 'Apellido', value: `${app.ui.StringCapitalizeFormatter(info.APE1_TERCERO)}`, size: 6, visible: true },
                            { key: 'Nacimiento', value: `${app.ui.DateTimeValueToString(info.FEC_NACIMIENTO, undefined, '---')}`, size: 6, visible: true },
                            { key: 'Teléfono', value: `${app.ui.StringValueToString(info.TLF_NUMERO, '---')}`, size: 6, visible: true },
                            { key: 'Celular', value: `${app.ui.StringValueToString(info.TLF_MOVIL, '---')}`, size: 6, visible: true },
                            { key: 'Email', value: `${info.EMAIL}`, size: 6, visible: true },
                            { key: '', value: '', size: 6, visible: true },

                            { key: 'Domicilio', value: `${app.ui.StringCapitalizeFormatter(info.NOM_DOMICILIO1)}`, size: 12, visible: true },
                            { key: 'Provincia', value: `${app.ui.StringCapitalizeFormatter(info.NOM_ESTADO)}`, size: 6, visible: true },
                            { key: 'Cantón', value: `${app.ui.StringCapitalizeFormatter(info.NOM_PROV)}`, size: 6, visible: true },
                            { key: 'Distrito', value: `${app.ui.StringCapitalizeFormatter(info.NOM_LOCALIDAD)}`, size: 6, visible: true },
                            { key: '', value: '', size: 6, visible: true },

                            { key: 'Tipo de tarjeta', value: `${app.ui.StringValueToString(info.NOM_TIP_TARJETA, '---')} - ${app.ui.StringValueToString(info.NOM_TARJETA, '---')}`, size: 12, visible: isEmpleado },
                            { key: 'Tarjeta', value: `${app.ui.StringValueToString(info.NUM_TARJETA, '---')}`, size: 6, visible: isEmpleado },
                            { key: 'Vencimiento', value: `${app.ui.DateTimeValueToString(info.FEC_VCTO_TARJETA, undefined, '---')}`, size: 6, visible: isEmpleado },
                            { key: '', value: '', size: 6, visible: isEmpleado },

                            { key: 'Contacto', value: `${app.ui.StringValueToString(info.NOM_CONTACTO, '---')} ${app.ui.StringValueToString(info.APELLIDO_CONTACTO)}`, size: 12, visible: true },
                            { key: 'Observación', value: `${app.ui.StringValueToString(info.OBS_ASEGURADO, '---')}`, size: 12, visible: true },

                        ].forEach(function (item) {
                            if (item.visible)
                                html.push(`<div class="col-md-${item.size}"><div class="readonlyfield"><strong>${item.key}</strong><div>${item.value}</div></div></div>`);
                        });
                        html.push(`</div>`);
                        $(`#tercero${row.COD_DOCUM_ASEG}`).html(html.join(''));
                    }
                    $('.sidebar-content').toggleClass('sk-loading');
                });
        },

        ShowPolicyDetail: function (row) {
            app.ui.ShowSideBar({ title: 'PÓLIZA #{NUM_POLIZA}', subtitle: 'Información', isHTML: true, HTML: `<div id="poliza${row.NUM_POLIZA}"></div>`, data: row, width: '360px' })
            $('.sidebar-content').toggleClass('sk-loading');

            app.core.api_get(`policy/${row.NUM_POLIZA}?NUM_SPTO=${row.NUM_SPTO}&NUM_APLI=${row.NUM_APLI}&NUM_SPTO_APLI=${row.NUM_SPTO_APLI}&NUM_RIESGO=${row.NUM_RIESGO}`)
                .then(data => {
                    if (data?.Fixeddata?.Sucessfully && data.Fixeddata?.Data != null) {
                        let info = data.Fixeddata.Data;
                        let html = [];
                        html.push('<div class="row">');
                        [
                            { key: 'Inicio de vigencia', value: `${app.ui.DateTimeValueToString(info.FEC_EFEC_POLIZA, undefined, '---')}`, size: 6 },
                            { key: 'Fin de vigencia', value: `${app.ui.DateTimeValueToString(info.FEC_VCTO_POLIZA, undefined, '---')}`, size: 6 },
                            { key: 'Ramo', value: `${info.COD_RAMO} - ${app.ui.StringCapitalizeFormatter(info.NOM_RAMO)}`, size: 12 },
                            { key: 'Fraccionamiento', value: `${info.COD_FRACC_PAGO} - ${app.ui.StringCapitalizeFormatter(info.NOM_FRACC_PAGO)}`, size: 12 },
                            { key: 'Moneda', value: `${info.COD_MON} - ${app.ui.StringCapitalizeFormatter(info.NOM_MON)}`, size: 12 },
                            { key: 'Póliza grupo', value: `${app.ui.StringValueToString(info.NUM_POLIZA_GRUPO, '---')}`, size: 6 },
                            { key: 'Contrato', value: `${app.ui.StringValueToString(info.NUM_CONTRATO, '---')}`, size: 6 },
                            { key: 'Descripción del riesgo', value: app.ui.StringCapitalizeFormatter(row.NOM_RIESGO), size: 12 },
                            { key: 'Tomando', value: `${row.TIP_DOCUM_TOMADOR} ${row.COD_DOCUM_TOMADOR} - ${app.ui.StringCapitalizeFormatter(row.NOM_TOMADOR)} ${app.ui.StringCapitalizeFormatter(row.APE_TOMADOR)}`, size: 12 },
                            { key: 'Asegurado', value: `${row.TIP_DOCUM_ASEG} ${row.COD_DOCUM_ASEG} - ${app.ui.StringCapitalizeFormatter(row.NOM_ASEG)} ${app.ui.StringCapitalizeFormatter(row.APE_ASEG)}`, size: 12 },
                            { key: 'Email del asegurado', value: `${row.EMAIL_ASEG}`, size: 12 },

                        ].forEach(function (item) {
                            html.push(`<div class="col-md-${item.size}"><div class="readonlyfield"><strong>${item.key}</strong><div>${item.value}</div></div></div>`);
                        });
                        html.push(`</div>`);
                        $(`#poliza${row.NUM_POLIZA}`).html(html.join(''));
                    }
                    $('.sidebar-content').toggleClass('sk-loading');
                });
        },
        ShowClaimPanel: function (row) {
            window.location.href = app.setting.basepath + 'purdy/panel?asiges=' + row.ASIGES;
        },
        EventHandler: function (id, index, stage) {
            console.log(id, index, stage);

            if (id != undefined && stage == 'onPostBody') {
                $(id + ' tbody tr').on('mouseover', function () {
                    $(this).find('.btn-link').removeClass('invisible'); $(this).siblings().find('.btn-link').addClass('invisible');
                });
            }
        }
    };
})();

if (app.core.URLStringValue('id') == '361') {
    app.Extend = app.Extend || {};
    app.Extend.EventHandler = app.ExtendClaims.EventHandler;
}
app.ExtendClaims.Init();