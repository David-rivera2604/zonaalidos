var app = app || {};

app.PurdyPanelEncabezado = (function () {

    let _eventCallback = null;
    var setupData = null;
    var changedCallback = null;

    function MapInputToObject() {
        var data = {
            aSIGES: $('#aSIGES').val(),
            tipodeindemnizacionEnc: app.ui.GetDropDownNumericValue('#tipodeindemnizacionEnc'),
            tipodeindemnizacionEncDesc: app.ui.GetDropDownSelectedText('#tipodeindemnizacionEnc')
        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#estadoMapfre').html('En reserva');
        $('#NUM_POLIZA').html(data.NUM_POLIZA);
        $('#nombreasegurado').html(`${data.NOM_ASEG} ${data.APE_ASEG}`);
        $('#cedulaasegurado').html(`${data.TIP_DOCUM_ASEG} ${data.COD_DOCUM_ASEG}`);
        $('#correoasegurado').html(`<a href="mailto:${data.EMAIL_ASEG}" title="Al hacer click se podrá escribir un correo electrónico usando esta dirección">${data.EMAIL_ASEG}</a>`);
        $('#telefonoasegurado').html(`<a href="tel:${data.TLF_NUMERO_ASEG}" title="Al hacer click se podrá llamar a este teléfono">${data.TLF_NUMERO_ASEG}</a>`);
        $('#ingresodeaviso').html(`${app.ui.DateFormatter(data.FEC_DENU_SINI)} ${data.HORA_DENU_SINI}`);
        $('#fechadeleventoEnc').html(`${app.ui.DateFormatter(data.FEC_SINI)} ${data.HORA_SINI}`);
        $('#noSiniestro').html(data.NUM_SINI);
        $('#tipodeindemnizacionSel').html(data.tipodeindemnizacionEnc);
        $('#categoriadesiniestroEnc').html(data.categoriadesiniestro);
        $('#analistareclamosSel').html(data.analistareclamosSel);
        $('#analistagestora').html(data.analistagestora);
        $('#detallesiniestro').html(data.TXT_DANO_VEHI);
    };

    function Controls_setup() {



    };

    function Controls_Events() {

        $('#aSIGES').change(function () {
            let code = $('#aSIGES').val();
            let data = { ASIGES: code };

            $('.panelinfo').addClass('d-none');
            $('.panelinfo').removeClass('d-none');

            _eventCallback('ASIGESChange', data);

            //app.core.Get(`${app.setting.apipath}v1/datasource/json?id=700&sequence=1&url=asiges=${code}`)
            //    .done(function (claim) {
            //        claim[0]['ASIGES'] = code;
            //        MapObjectToInput(claim[0]);
            //        _eventCallback('ASIGESChange', claim[0]);
            //    });
        });
    };


    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#PurdyPanelEncabezadoEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                aSIGES: { required: true },
                correoasegurado: { email: true },
            },
            messages: {
                aSIGES: { required: 'Debe indicar el asiges' },
                correoasegurado: { email: 'Debe indicar un correo electrónico valido' },
            }
        });
    };



    return {
        Init: function (eventCallback) {
            try {
                _eventCallback = eventCallback;
                Controls_setup();
                Setup_Validations();

                Controls_Events();
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Event: function (src, data) {
            switch (src) {
                case 'EventoDataChange':
                    $('#tipodeindemnizacionSel').html(data.event.TIPODEINDEMNIZACIONDESC);
                    $('#analistareclamosSel').html(data.event.ANALISTARECLAMOSDESC);
                    $('#categoriadesiniestroEnc').html(data.event.CATEGORIADESINIESTRODESC);
                    break;
            }
        }
    };
})();


