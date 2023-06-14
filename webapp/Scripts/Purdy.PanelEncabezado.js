var app = app || {};

app.PurdyPanelEncabezado = (function () {

    let _eventCallback = null;

    function api_ShowError() {
        toastr.error("Por favor intente nuevamente y en caso de persistir el problema contacte el personal de soporte", "Ha ocurrido un error no controlado", { timeOut: 10000, closeButton: true, progressBar: true });
    }

    function api_sendHttpRequest(method, url, data) {
        return fetch(url, {
            body: method === 'GET' ? null : JSON.stringify(data),
            method: method,
            headers: {
                'Content-Type': data ? 'application/json; charset=utf-8' : {},
                'Authorization': 'Bearer ' + localStorage.getItem('Token')
            }
        }).then(response => {
            if (!response.ok) {
                api_ShowError();
                return;
            } else {
                return response.json();
            }
        });
    };

    function api_get(url) {
        return new Promise((resolve, reject) => {
            api_sendHttpRequest('GET', url)
                .then(data => {
                    if (data === undefined) {
                        resolve(null);
                    } else {
                        if (data?.Sucessfully != undefined && data.Sucessfully) {
                            resolve(data.Data);
                        } else {
                            api_ShowError();
                            resolve(null);
                        }
                    }
                });
        })
    };

    async function GetClaim(code) {
        api_get(`${app.setting.entityapi}/claim/asiges?code=${code}`)
            .then(data => {
                if (data != null) {
                    app.ui.NotifyClear();
                    $('.panelinfo').removeClass('d-none');
                    data.ASIGES = code;
                    MapObjectToInput(data);
                } else {
                    $('.panelinfo').addClass('d-none');
                    MapObjectToInput({
                        NUM_POLIZA: '',
                        NOM_ASEG: '',
                        APE_ASEG: '',
                        TIP_DOCUM_ASEG: '',
                        COD_DOCUM_ASEG: '',
                        EMAIL_ASEG: '',
                        EMAIL_ASEG: '',
                        TLF_NUMERO_ASEG: '',
                        TLF_NUMERO_ASEG: '',
                        FEC_DENU_SINI: null,
                        HORA_DENU_SINI: '',
                        NUM_SINI: '',
                        TXT_DANO_VEHI: ''
                    });
                    app.ui.SetDropDownNumericValue('#tipodeindemnizacionEnc', -1);
                    $('#estadoMapfre').html('');
                    $('#tipodeindemnizacionSel').html('');
                    $('#analistareclamosSel').html('');
                    $('#categoriadesiniestroEnc').html('');
                    $('#fechadeleventoEnc').html('');
                    $('.panelinfo').addClass('d-none');
                    app.ui.Error(`El código ASIGES '${code}' no fue encontrado en nuestro sistema, por favor intente con otro código.`);
                }
                _eventCallback('ASIGESChange', data);
            });


        //app.core.Get(`${app.setting.entityapi}/claim/asiges?code=${code}`)
        //    .done(function (claim) {
        //        if (claim?.Sucessfully) {
        //            if (claim.Data != null) {
        //                app.ui.NotifyClear();
        //                $('.panelinfo').removeClass('d-none');
        //                claim.Data.ASIGES = code;
        //                MapObjectToInput(claim.Data);
        //            } else {
        //                $('.panelinfo').addClass('d-none');
        //                MapObjectToInput({
        //                    NUM_POLIZA: '',
        //                    NOM_ASEG: '',
        //                    APE_ASEG: '',
        //                    TIP_DOCUM_ASEG: '',
        //                    COD_DOCUM_ASEG: '',
        //                    EMAIL_ASEG: '',
        //                    EMAIL_ASEG: '',
        //                    TLF_NUMERO_ASEG: '',
        //                    TLF_NUMERO_ASEG: '',
        //                    FEC_DENU_SINI: null,
        //                    HORA_DENU_SINI: '',
        //                    NUM_SINI: '',
        //                    TXT_DANO_VEHI: ''
        //                });
        //                app.ui.SetDropDownNumericValue('#tipodeindemnizacionEnc', -1);
        //                $('#estadoMapfre').html('');
        //                $('#tipodeindemnizacionSel').html('');
        //                $('#analistareclamosSel').html('');
        //                $('#categoriadesiniestroEnc').html('');
        //                $('#fechadeleventoEnc').html('');
        //                $('.panelinfo').addClass('d-none');
        //                app.ui.Error(`El código ASIGES '${code}' no fue encontrado en nuestro sistema, por favor intente con otro código.`);
        //            }
        //            _eventCallback('ASIGESChange', claim.Data);
        //        }
        //    });
    };

    function MapObjectToInput(data) {
        $('#estadoMapfre').html(EstadoMapfre(data.tipodeindemnizacionEnc));
        $('#NUM_POLIZA').html(data.NUM_POLIZA);
        $('#nombreasegurado').html(`${data.NOM_ASEG} ${data.APE_ASEG}`);
        $('#cedulaasegurado').html(`${data.TIP_DOCUM_ASEG} ${data.COD_DOCUM_ASEG}`);
        $('#correoasegurado').html(`<a href="mailto:${data.EMAIL_ASEG}" title="Al hacer click se podrá escribir un correo electrónico usando esta dirección">${data.EMAIL_ASEG}</a>`);
        $('#telefonoasegurado').html(`<a href="tel:${data.TLF_NUMERO_ASEG}" title="Al hacer click se podrá llamar a este teléfono">${data.TLF_NUMERO_ASEG}</a>`);
        $('#ingresodeaviso').html(`${app.ui.DateFormatter(data.FEC_DENU_SINI)} ${data.HORA_DENU_SINI}`);
        $('#fechadeleventoEnc').html(``);
        $('#noSiniestro').html(data.NUM_SINI);
        $('#tipodeindemnizacionSel').html(data.tipodeindemnizacionEnc);
        $('#categoriadesiniestroEnc').html(data.categoriadesiniestro);
        $('#analistareclamosSel').html(data.analistareclamosSel);
        $('#analistagestora').html(data.analistagestora);
        $('#detallesiniestro').html(data.TXT_DANO_VEHI);
    };

    function Controls_Events() {

        $('#aSIGES').change(function () {
            let code = $('#aSIGES').val();
            let data = { ASIGES: code };
            GetClaim(code)
        });
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#PurdyPanelEncabezadoEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                aSIGES: { required: true }
            },
            messages: {
                aSIGES: { required: 'Debe indicar el asiges' }
            }
        });
    };

    function EstadoMapfre(tipodeindemnizacion) {
        let result = '';
        switch (tipodeindemnizacion) {
            case 1: // -> Casos reparados
            case 2: // -> Pérdida total financiera
            case 3: // -> Pérdida total estructural
            case 10: // -> Pago directo
                result = 'Pagado';
                break;
            case 4: // -> Casos con avalúo pendiente de reparación
            case 5: // -> Repuestos pendientes
            case 6: // -> Avalúo cliente no repara aún
                result = 'Reparación en reserva';
                break;
            case 8: // -> No procede
                result = 'Cerrado';
                break;
            case 7: // -> Pendiente avalúo
            case 9: // -> Posible pérdida total
            default:
                result = 'En reserva';
                break;
        }
        return result;
    }

    return {
        Init: function (eventCallback) {
            try {
                _eventCallback = eventCallback;

                Setup_Validations();

                Controls_Events();
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Event: async function (src, data) {
            switch (src) {
                case 'EventoDataChange':
                    app.ui.SetDropDownNumericValue('#tipodeindemnizacionEnc', data.event.TIPODEINDEMNIZACION);
                    $('#estadoMapfre').html(EstadoMapfre(data.event.TIPODEINDEMNIZACION));
                    $('#tipodeindemnizacionSel').html(data.event.TIPODEINDEMNIZACIONDESC);
                    $('#analistareclamosSel').html(data.event.ANALISTARECLAMOSDESC);
                    $('#categoriadesiniestroEnc').html(data.event.CATEGORIADESINIESTRODESC);
                    $('#fechadeleventoEnc').html(`${app.ui.DateFormatter(data.event.FECHADELEVENTO)}`);
                    break;
            }
        }
    };
})();


