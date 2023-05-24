var app = app || {};

app.PurdyPanelEncabezado = (function () {

    var setupData = null;
    var changedCallback = null;

    function MapInputToObject() {
        var data = {
            aSIGES: $('#aSIGES').val(),
            tipodeindemnizacion: app.ui.GetDropDownNumericValue('#tipodeindemnizacion'),
            tipodeindemnizacionDesc: app.ui.GetDropDownSelectedText('#tipodeindemnizacion')
        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#estadoMapfre').html('En reserva');
        $('#numerodepoliza').html(data.NUM_POLIZA);
        $('#nombreasegurado').html(`${data.NOM_ASEG} ${data.APE_ASEG}`);
        $('#cedulaasegurado').html(`${data.TIP_DOCUM_ASEG} ${data.COD_DOCUM_ASEG}`);
        $('#correoasegurado').html(`<a href="mailto:${data.EMAIL_ASEG}" title="Al hacer click se podrá escribir un correo electrónico usando esta dirección">${data.EMAIL_ASEG}</a>`);
        $('#telefonoasegurado').html(`<a href="tel:${data.TLF_NUMERO_ASEG}" title="Al hacer click se podrá llamar a este teléfono">${data.TLF_NUMERO_ASEG}</a>`);
        $('#ingresodeaviso').html(`${app.ui.DateFormatter(data.FEC_DENU_SINI)} ${data.HORA_DENU_SINI}`);
        $('#fechadelevento').html(`${app.ui.DateFormatter(data.FEC_SINI)} ${data.HORA_SINI}`);
        $('#noSiniestro').html(data.NUM_SINI);
        $('#tipodeindemnizacion').html(data.tipodeindemnizacion);
        $('#categoriadesiniestro').html(data.categoriadesiniestro);
        $('#analistareclamos').html(data.analistareclamos);
        $('#analistagestora').html(data.analistagestora);
        $('#detallesiniestro').html(data.TXT_DANO_VEHI);
    };

    function Controls_setup() {

        

    };

    function Controls_Events() {

        $('#aSIGES').change(function () {
            let code = $('#aSIGES').val();
            let data = [{ "NUM_SINI": 101130223003326, "NUM_EXP": 1, "TXT_DANO_VEHI": "FRONTAL", "NUM_POLIZA": "3022010106226", "TIP_DOCUM_ASEG": "CRE", "COD_DOCUM_ASEG": "175600094530", "FEC_DENU_SINI": "2023-01-09T00:00:00", "HORA_DENU_SINI": "14:56", "FEC_SINI": "2023-01-09T00:00:00", "HORA_SINI": "14:56", "TIP_EXP": "PPD", "TIP_EST_EXP": "P", "NOM_ASEG": "CAMALEO ", "APE_ASEG": "SACAPALLO ", "EMAIL_ASEG": "CHRISTIAN@ELALMA.COM", "TLF_NUMERO_ASEG": "26669060" }];
            MapObjectToInput(data[0]);

            //app.core.Get(`https://appqa.mapfrecr.com/Aliadosdes/api/v1/datasource/json?id=700&sequence=1&url=asiges=${code}`)
            //    .done(function (data, textStatus, jqXHR) {
            //        console.log(data);
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
        Init: function () {
            try {
                Controls_setup();
                Setup_Validations();

                Controls_Events();
                console.log("Inicio");
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Data: function () {
            return MapInputToObject();
        },
        SetData: function (data) {
            MapObjectToInput(data);
        },
        Changed: function (callback) {
            changedCallback = callback;
        },
        IsValid: function (showResume) {
            return app.ui.IsValid('#PurdyPanelEncabezadoEdtForm', false, showResume);
        }
    };
})();


