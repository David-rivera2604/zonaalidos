var app = app || {};

app.Cotizacion = (function () {

    let settings = [];
    let roles = [];
    let _data = {};
    let _monedaField = false;
    let _prefix = '';
    let _pago = {};
    let _copia = {};

    return {
        Imprimir: function (name, data) {
            $('.ibox-content').toggleClass('sk-loading');
            app.core.api_report(name, data)
                .then(data => {
                    $('.ibox-content').toggleClass('sk-loading');
                });
        },
        EnviarCertificado: function (num_poliza, num_riesgo, correoprincipal, correocopia1, correocopia2) {
            if (typeof correoprincipal == "undefined" || correoprincipal == '') {
                toastr.error('Debe indicar al menos el correo principal', '', { timeOut: 7000, closeButton: true, progressBar: true });
            }
            else
                app.core.Get(app.setting.apipath + `v1/TronCommon/EnviarCertificado?num_poliza=${num_poliza}&num_riesgo=${num_riesgo}&correoprincipal=${correoprincipal}&correocopia1=${correocopia1}&correocopia2=${correocopia2}`)
                    .done(function (data, textStatus, jqXHR) {
                        if (data == null || data === '') {
                            toastr.error('Ha ocurrido un error intentando enviar el certificado por correo', '', { timeOut: 7000, closeButton: true, progressBar: true });
                        }
                        else {
                            toastr.success(data, '', { timeOut: 7000, closeButton: true, progressBar: true });
                        }
                    });
        },
        CorreoTomador: function () {
            let terceros = $('#tercerosTbl').length > 0 ? ($('#tercerosTbl').bootstrapTable('getData') || []) : [];
            let conCorreo = t => $.trim(t.correoelectronico || '') !== '';
            let tomador = terceros.find(t => t.tipodetercero == 0 && conCorreo(t)) ||
                terceros.find(t => t.tipodetercero == 2 && (t.elaseguradoeselmismotomador == 1 || t.eltomadoreselmismoasegurado == 1) && conCorreo(t));
            return tomador ? $.trim(tomador.correoelectronico) : '';
        },
        EnviarCertificadoTomador: function (num_poliza, num_riesgo) {
            if (!num_poliza) {
                return;
            }
            let correo = app.Cotizacion.CorreoTomador();
            if (correo === '') {
                toastr.warning('El tomador no tiene correo, puede enviarlo con "Enviar copia de correo"', '', { timeOut: 7000, closeButton: true, progressBar: true });
                return;
            }
            app.Cotizacion.EnviarCertificado(num_poliza, num_riesgo, correo, '', '');
        },
        CopiaCorreo: function (num_poliza, num_riesgo) {
            _copia = { num_poliza: num_poliza, num_riesgo: num_riesgo };
            app.ui.ShowSideBar({
                title: 'Enviar copia de correo', subtitle: 'Póliza #{NUM_POLIZA}', isHTML: true,
                data: { NUM_POLIZA: num_poliza },
                HTML: '<div class="form-group"><label class="control-label" for="copiaCorreo1">Copia 1</label><input id="copiaCorreo1" type="email" class="form-control" maxlength="80"></div>' +
                    '<div class="form-group"><label class="control-label" for="copiaCorreo2">Copia 2</label><input id="copiaCorreo2" type="email" class="form-control" maxlength="80"></div>' +
                    '<button id="enviarCopiaCorreo" type="button" class="btn btn-primary btn-block">Enviar</button>'
            });
        },
        EnviarCopiaCorreo: function () {
            let copias = [$.trim($('#copiaCorreo1').val()), $.trim($('#copiaCorreo2').val())].filter(c => c !== '');
            if (copias.length === 0) {
                toastr.error('Debe indicar al menos un correo', '', { timeOut: 7000, closeButton: true, progressBar: true });
                return;
            }
            if (copias.some(c => !/^[^@\s]+@[^@\s]+\.[^@\s]+$/.test(c))) {
                toastr.error('Revise que los correos sean validos', '', { timeOut: 7000, closeButton: true, progressBar: true });
                return;
            }
            app.Cotizacion.EnviarCertificado(_copia.num_poliza, _copia.num_riesgo, copias[0], copias[1] || '', '');
        },
        OpcionesDePago: function (data) {
            _pago = { num_poliza: data?.num_poliza, plandepago: data?.plandepago || [] };
            let roles = [];
            try {
                roles = JSON.parse(localStorage.getItem('Roles')) || [];
            } catch (e) {
                roles = [];
            }
            let puedePagar = roles.some(r => String(r).toLowerCase() === 'pago');
            $('#opcionesPagoGroup').toggleClass('d-none', !(_pago.num_poliza && puedePagar));
        },
        PagarRecibo: function () {
            let num_poliza = _pago.num_poliza;
            if (!num_poliza) {
                return;
            }
            let abrir = function (row) {
                if (row == null) {
                    toastr.warning('La póliza ' + num_poliza + ' no tiene recibos pendientes de pago', '', { timeOut: 7000, closeButton: true, progressBar: true });
                    return;
                }
                app.core.LoadScriptFile('Payment.js').then(d => { app.Payment.Recibo(row, 310, 2); });
            };
            let respaldo = function () {
                let cuota = _pago.plandepago.find(p => p.recibo > 0);
                return cuota ? { NUM_POLIZA: num_poliza, NUM_RECIBO: cuota.recibo, COD_AGT: app.Cotizacion.AgentCode() || 0 } : null;
            };
            $('.ibox-content').toggleClass('sk-loading');
            app.core.Get(app.setting.apipath + 'v1/datasource/json?id=310&sequence=2&url=')
                .done(function (data) {
                    let recibos = (data || []).filter(r => String(r.NUM_POLIZA) === String(num_poliza))
                        .sort((a, b) => a.NUM_RECIBO - b.NUM_RECIBO);
                    $('.ibox-content').toggleClass('sk-loading');
                    abrir(recibos.length > 0 ? recibos[0] : respaldo());
                })
                .fail(function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    abrir(respaldo());
                });
        },
        ImprimirPoliza: function (num_poliza, num_riesgo) {
            app.core.GetPDF(app.setting.apipath + 'v1/TronCommon/ImprimirPoliza/' + num_poliza + "/" + num_riesgo, false, 'Mapfre Certificado.pdf');
        },
        ImprimirRecibo: function (num_recibo) {
            app.core.GetPDF(app.setting.apipath + 'v1/TronCommon/ImprimirRecibo/' + num_recibo, false, 'Mapfre Recibo.pdf');
        },
        Coberturas_Seleccionada: function (lista, codigo) {
            var result = false;
            if (lista != null) {
                for (var i = 0; i < lista.length; i++) {
                    if (lista[i].codigo == codigo) {
                        result = lista[i].seleccionado;
                        break;
                    }
                }
            }
            return result;
        },
        Coberturas_ComportamientoDependencia: function (element, disabled) {
            let ctrol = $(element);
            ctrol.prop("disabled", disabled);
            if (disabled) {
                $(element + '-error').html('');
                ctrol.removeClass('error');
            }
            else {
                if (ctrol.children().length == 1) {
                    ctrol.val($(element + ' option:first').val());
                    ctrol.change();
                } else {
                    if (!disabled && ctrol.data("autoselect") === true && (ctrol.val() == null || ctrol.val() == -1)) {
                        ctrol.val($(element + ' option:first').val());
                        ctrol.change();
                    }
                }
            }
        },
        DefaultSettings: function (code) {

            if (settings.length === 0) {
                app.core.Get(`${app.setting.entityapi}/QuoteSetting?code=${code}`)
                    .done(function (resp) {
                        if (resp?.Sucessfully) {
                            settings = resp.Data;
                            roles = JSON.parse(localStorage.getItem('Roles'));
                            if (settings === null) {
                                settings = [];
                            }
                            app.Cotizacion.QuoteSettings();
                        }
                    });
            } else
                app.Cotizacion.QuoteSettings();
        },
        QuoteSettings: function () {
            roles.forEach(function (role) {
                settings.filter(r => r.Role === role).forEach(function (item) {

                    let name = '#' + item.Field;
                    switch (item.Type) {
                        case 'TextValue':
                            if (item.Value != null && item.Value != '') {
                                let value = item.Value;
                                if ($(name).val() != value) {
                                    $(name).val(item.Value);
                                    $(name).change();
                                }
                            }
                            if (item.Disable === 1) {
                                $(name).prop('disabled', true);
                            }
                            if (item.Visible === 0) {
                                $(name).parent().parent().addClass('d-none');
                            }
                            break;
                        case 'NumericValue':
                            if (item.Value != null && item.Value != '') {
                                let value = Number(item.Value);
                                if (app.ui.GetNumericValue(name) != value) {
                                    app.ui.SetNumericValue(name, value);
                                    $(name).change();
                                }
                            }
                            if (item.Disable === 1) {
                                $(name).prop('disabled', true);
                            }
                            if (item.Visible === 0) {
                                $(name).parent().parent().addClass('d-none');
                            }
                            break;
                        case 'RadioStringValue':
                            if (item.Value != null && item.Value != '') {
                                app.ui.SetRadioStringValue(item.Field, item.Value);
                            }
                            if (item.Disable === 1) {
                                $('input:radio[name=' + item.Field + ']').prop('disabled', true);
                            }
                            if (item.Visible === 0) {
                                $('input:radio[name=' + item.Field + ']').parent().parent().parent().parent().addClass('d-none');
                            }
                            break;
                        case 'Zone':
                            if (item.Visible === 0) {
                                $('.' + item.Field).addClass('d-none');
                            }
                            break;
                        case 'DropDownNumericValue':
                            if (item.AllowedValues != null && item.AllowedValues != '') {
                                item.AllowedValues = ',' + item.AllowedValues + ',';
                                let toRemove = '';
                                document.querySelectorAll(name + ' option').forEach(function (option, index, array) {
                                    if (item.AllowedValues.indexOf(',' + option.value + ',') === -1)
                                        toRemove += '[value="' + option.value + '"],';
                                });
                                if (toRemove != '') {
                                    $(name).find(toRemove.substring(0, toRemove.length - 1)).remove();
                                }
                                if (item.Field === 'cod_marca') {
                                    $("#VehicleModelHelper").parent().addClass('d-none');
                                }
                            }
                            if (item.ValuesToRemove != null && item.ValuesToRemove != '') {
                                item.ValuesToRemove.split(",").forEach(function (value, index, array) {
                                    $(name + ' option[value="' + value + '"').remove();
                                });
                                if (item.Field === 'cod_marca') {
                                    $("#VehicleModelHelper").parent().addClass('d-none');
                                }
                            }
                            if (item.Value != null && item.Value != '') {
                                let value = Number(item.Value);
                                if (app.ui.GetDropDownNumericValue(name) != value) {
                                    app.ui.SetDropDownNumericValue(name, item.Value);
                                    $(name).change();
                                }
                            }
                            if (item.Disable === 1) {
                                app.ui.DropDownDisabled(name, true, false);
                            }
                            if (item.Visible === 0) {
                                $(name).parent().parent().addClass('d-none');
                            }
                            break;
                    }
                });
            });
        },
        CustomAgentHandler: function (prefix, data) {

            if (data?.cod_mon == undefined) {
                data.cod_mon = data.moneda; //Hogar
                _monedaField = true;
            }
            _data = data;
            _prefix = prefix;

            if (localStorage.getItem('Roles').includes('Emisión MAPFRE')) {

                app.core.Lookups([`Agents.${prefix}agt_cod`],
                    function () {

                        $(`#${prefix}agt_cod`).select2({
                            width: '100%', theme: 'bootstrap4',
                            language: { noResults: function () { return "No hay resultado"; }, searching: function () { return "Buscando.."; } }
                        });

                        app.ui.SetDropDownNumericValue(`#${prefix}agt_cod`, data.cod_agt);

                        $(`#${prefix}agt_cod`).trigger('change');


                    }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}`);


                // Dependencies events
                $(`#${prefix}agt_cod`).on('change', function () {
                    let agt_cod = app.ui.GetDropDownNumericValue(`select#${prefix}agt_cod`);

                    app.core.Lookups([`CuadroComPorAgente.${prefix}cod_cuadro_com`],
                        function () {
                            $(`#${prefix}cod_cuadro_com`).prop("disabled", $(`#${prefix}cod_cuadro_com`).children().length == 0);
                        }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}:agt_cod=${agt_cod}`);
                    if (_monedaField)
                        $('#moneda').trigger('change');
                    else
                        $('#cod_mon').trigger('change');
                });


                $(`.${prefix}custom_agent`).removeClass('d-none');
            }
        },
        AgentCode: function () {
            if (localStorage.getItem('Roles').includes('Emisión MAPFRE')) {
                if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
                    return app.ui.GetDropDownNumericValue('#pg_agt_cod')
                } else {
                    return app.ui.GetDropDownNumericValue('#agt_cod')
                }
            } else {
                return _data.cod_agt;
            }
        },
        CuadroCom: function () {
            if (localStorage.getItem('Roles').includes('Emisión MAPFRE')) {
                if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
                    return app.ui.GetDropDownNumericValue('#pg_cod_cuadro_com')
                } else {
                    return app.ui.GetDropDownNumericValue('#cod_cuadro_com')
                }
            } else {
                return _data.cod_cuadro_com;
            }
        }
    };
})();

$(document).on('click', '#opcionesPago', function (e) {
    e.preventDefault();
    app.Cotizacion.PagarRecibo();
});

$(document).on('click', '#enviarCopiaCorreo', function (e) {
    e.preventDefault();
    app.Cotizacion.EnviarCopiaCorreo();
});
