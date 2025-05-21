var app = app || {};

app.PurdyPanelEncabezado = (function () {

    let _eventCallback = null;

    async function GetClaim(code, claim, exp) {
        $('.ibox-content').toggleClass('sk-loading');
        app.core.datapi('GET', `claim/asiges?code=${code}&claim=${claim}&exp=${exp}`)
            .then(data => {
                $('#tipodeindemnizacionEnc').html('');
                app.ui.VisibleBehaviour('#tipodeindemnizacionEnc', true);
                app.ui.VisibleBehaviour('.tipodeindemnizacionGrp', false);

                if (data?.General != null) {
                    data.General.Coberturas = data.Coberturas;
                    data = data.General;                    
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
                $('.ibox-content').toggleClass('sk-loading');
            });

    };

    function MapObjectToInput(data) {
        $('#estadoMapfre').html(EstadoMapfre(data.tipodeindemnizacionEnc));
        $('#NUM_POLIZA').html(data.NUM_POLIZA);
        $('#nombreasegurado').html(`${app.ui.StringValueToString(data.NOM_ASEG)} ${app.ui.StringValueToString(data.APE_ASEG)}`);
        $('#cedulaasegurado').html(`${app.ui.StringValueToString(data.TIP_DOCUM_ASEG)} ${app.ui.StringValueToString(data.COD_DOCUM_ASEG)}`);
        $('#correoasegurado').html(`<a href="mailto:${app.ui.StringValueToString(data.EMAIL_ASEG)}" title="Al hacer click se podrá escribir un correo electrónico usando esta dirección">${app.ui.StringValueToString(data.EMAIL_ASEG)}</a>`);
        $('#telefonoasegurado').html(`<a href="tel:${app.ui.StringValueToString(data.TLF_NUMERO_ASEG)}" title="Al hacer click se podrá llamar a este teléfono">${app.ui.StringValueToString(data.TLF_NUMERO_ASEG)}</a>`);
        $('#ingresodeaviso').html(`${app.ui.DateFormatter(data.FEC_DENU_SINI)} ${app.ui.StringValueToString(data.HORA_DENU_SINI)}`);
        $('#fechadeleventoEnc').html(``);
        $('#noSiniestro').html(data.NUM_SINI);
        $('#tipodeindemnizacionSel').html(data.tipodeindemnizacionEnc);
        $('#categoriadesiniestroEnc').html(data.categoriadesiniestro);
        $('#analistareclamosSel').html(data.analistareclamosSel);
        $('#analistagestoraEnc').html('');
        $('#detallesiniestro').html(data.TXT_DANO_VEHI);
    };

    function Controls_Events() {

        $('#aSIGES').change(function () {
            let code = $('#aSIGES').val();
            let data = { ASIGES: code };
            GetClaim(code)
        });
        $('#tipodeindemnizacion').change(function () {
            app.ui.VisibleBehaviour('.tipodeindemnizacionSave', true);
        });

        $('#tipodeindemnizacionSave').click(function (e) {

            _eventCallback('TipoDeIndemnizacionChange', {
                TIPODEINDEMNIZACION: app.ui.GetDropDownNumericValue('#tipodeindemnizacion'),
                TIPODEINDEMNIZACIONDESC: app.ui.GetDropDownSelectedText('#tipodeindemnizacion')
            });
            app.ui.VisibleBehaviour('.tipodeindemnizacionSave', false);
            e.preventDefault();
        });

        $('#analistagestora').change(function () {
            app.ui.VisibleBehaviour('.analistagestoraSave', true);
        });

        $('#analistagestoraSave').click(function (e) {

            _eventCallback('AnalistaGestoraChange', {
                ANALISTAGESTORA: app.ui.GetDropDownNumericValue('#analistagestora'),
                ANALISTAGESTORADESC: app.ui.GetDropDownSelectedText('#analistagestora')
            });
            app.ui.VisibleBehaviour('.analistagestoraSave', false);
            e.preventDefault();
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

                app.core.Lookups(['UsersByRol:Avalúos.analistagestora'], function () { }, ``);

            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Event: async function (src, data) {
            switch (src) {
                case 'EventoDataChange':
                    let allow = localStorage.getItem('Roles').includes('Reclamos') || localStorage.getItem('Roles').includes('Administrativo');
                    let isnew = false;
                    if (data.event.TIPODEINDEMNIZACION === null) {
                        data.event.TIPODEINDEMNIZACION = 7;
                        isnew = true;
                    }
                    app.ui.VisibleBehaviour('#tipodeindemnizacionEnc', !allow);
                    app.ui.VisibleBehaviour('.tipodeindemnizacionGrp', allow);
                    app.ui.VisibleBehaviour('.tipodeindemnizacionSave', isnew);
                    app.ui.SetDropDownNumericValue('#tipodeindemnizacion', data.event.TIPODEINDEMNIZACION);
                    $('#tipodeindemnizacionEnc').html(app.ui.GetDropDownSelectedText('#tipodeindemnizacion'));

                    app.ui.SetDropDownNumericValue('#analistagestora', data.event.ANALISTAGESTORA);
                    $('#analistagestoraEnc').html(app.ui.GetDropDownSelectedText('#analistagestora'));

                    allow = localStorage.getItem('Roles').includes('Avalúos');
                    app.ui.VisibleBehaviour('#analistagestoraEnc', !allow);
                    app.ui.VisibleBehaviour('.analistagestoraGrp', allow);

                    $('#estadoMapfre').html(EstadoMapfre(data.event.TIPODEINDEMNIZACION));
                    $('#tipodeindemnizacionSel').html(data.event.TIPODEINDEMNIZACIONDESC);
                    $('#analistareclamosSel').html(data.event.ANALISTARECLAMOSDESC);
                    $('#categoriadesiniestroEnc').html(data.event.CATEGORIADESINIESTRODESC);
                    $('#fechadeleventoEnc').html(`${app.ui.DateFormatter(data.event.FECHADELEVENTO)}`);
                    break;
            }
        },
        Called: function () {
            let id = app.core.URLStringValue('asiges');
            let claim = app.core.URLStringValue('claim');
            let exp = app.core.URLStringValue('exp');
            if (id != '') {
                if (id.length > 40) {
                    id = id.substring(0, 40);
                }
                $('#aSIGES').val(id);                
            }
            if (claim != '' && claim.length != 15) {
                claim = '';
            }
            if (exp != '' && exp.length > 5) {
                exp = '';
            }
            if (id != '' && claim != '') {
                GetClaim(id, claim, exp);
            }
        }
    };
})();