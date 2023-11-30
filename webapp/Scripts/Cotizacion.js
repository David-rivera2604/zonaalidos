var app = app || {};

app.Cotizacion = (function () {

    let settings = [];
    let roles = [];

    return {
        Imprimir: function (name, data) {
            var urlServer = app.setting.apibase + '/AliadoServReports/api/Report/Build';
            //urlServer = 'http://216.177.200.23/Report.Services/api/Report/Build';
            var data2 = {
                Source: JSON.stringify(data),
                Type: 'pdf',
                ReportName: name + '.repx',
                Path: ''
            };
            $.post(urlServer, data2, { responseType: 'arraybuffer' })
                .then(function (response) {
                    var file = new Blob([response.Data], { type: 'application/octet-binary' });
                    var blob = app.core.b64StrtoBlob(response.Data, 'application/pdf');
                    var blobUrl = URL.createObjectURL(blob);
                    window.open(blobUrl);
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
                        case 'DropDownNumericValue':
                            let value = Number(item.Value);
                            if (app.ui.GetDropDownNumericValue(name) != value) {
                                console.log("  ", item);
                                app.ui.SetDropDownNumericValue(name, item.Value);
                                $(name).change();
                            }
                            break;
                    }
                });
            });
        }
    };
})();