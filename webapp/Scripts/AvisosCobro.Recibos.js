var app = app || {};

app.AvisosRecibos = (function () {

    let changedCallback = null;

    function Setup() {
        app.core.Lookups(['MonedasPorRamo.cod_mon', 'FrecuenciaDePagoPorRamo.cod_fracc_pago.', 'PolizaGrupo.polizagrupo.', 'Contratos.contratos.'],
            function () {
                data = {
                    desde: new Date(),
                    hasta: new Date(),
                    cod_mon: 1,
                    cod_fracc_pago: null,
                    polizagrupo: null,
                    contratos: null,
                    DocumentNumber: null,
                    recibos: null,
                };
                MapObjectToInput(data);
            }, `cod_ramo=302:cod_mon=1`);
    };

    function MapInputToObject() {
        let data = {
            Fec_Efec_Rec_Desde: app.ui.GetDateValue('#desde'),
            Fec_Efec_Rec_Hasta: app.ui.GetDateValue('#hasta'),
            Cod_Mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            Cod_Fracc_Pago: app.ui.GetDropDownNumericValue('#cod_fracc_pago'),
            Num_Poliza_Grupo: app.ui.GetDropDownNumericValue('#polizagrupo'),
            Num_Contrato: app.ui.GetDropDownNumericValue('#contratos'),
            Tip_Docum: $("#DocumentNumberType").data("value"),
            Cod_Docum: $('#DocumentNumber').val()
        };
        if (data.Cod_Docum == '') {
            data.Tip_Docum = '';
        }
        if (data.Num_Poliza_Grupo == 0) {
            data.Num_Poliza_Grupo = '';
        }
        return data;
    };

    function MapObjectToInput(data) {
        app.ui.SetDateValue('#desde', data.desde);
        $('#hasta_group').data("DateTimePicker").minDate($('#desde_group').data("DateTimePicker").date());
        app.ui.SetDateValue('#hasta', data.hasta);
        $('#cod_mon').val(data.cod_mon);
        app.ui.SetDropDownNumericValue('#cod_mon', data.cod_mon, true);
        $('#cod_fracc_pago').val(data.cod_fracc_pago);
        app.ui.SetDropDownNumericValue('#cod_fracc_pago', data.cod_fracc_pago, true);
        $('#polizagrupo').val(data.polizagrupo);
        app.ui.SetDropDownNumericValue('#polizagrupo', data.polizagrupo, true);
        $('#contratos').val(data.contratos);
        app.ui.SetDropDownNumericValue('#contratos', data.contratos, true);
        $('#DocumentNumber').val(data.DocumentNumber);
        if (data.recibos != null)
            $('#recibosTbl').bootstrapTable('load', data.recibos);
        else
            $('#recibosTbl').bootstrapTable('load', {});

    };

    function Controls_setup() {
        $('#desde_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            defaultDate: new Date()

        });
        $('#hasta_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            defaultDate: new Date()

        });
        $('#DocumentNumber').formatter({
            pattern: '0{{9}}-{{9999}}-{{9999}}',
            persistent: false
        });
        $("#PrototypeEdtFormSave").appendTo("#GenericToolBar");
        $("#PrototypeEdtFormCancel").appendTo("#GenericToolBar");
    };

    function Controls_Events() {

        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });

        $("#PrototypeEdtForm :input").change(function () {
            data_changed();
        });

        $('#desde').blur(function () {
            var minDate = app.ui.GetDateRawValue('#desde');
            minDate.setDate(minDate.getDate());

            $('#hasta_group').data("DateTimePicker").minDate(minDate);
        });

        $('#DocumentNumberTypeMenu a').click(function () {
            app.ui.DocumentTypeHandler(this, '#DocumentNumber', 'Identification');
        });

        $('#DocumentNumber').on('blur', function () {
            if (app.ui.IsDocumentNumberValid($('#DocumentNumberType').data('value'), $('#DocumentNumber').val())) {
                var value = $('#DocumentNumber').val().replace(/-/g, '');
                if (value !== null && parseInt(0 + value, 10) !== 0 && parseInt(0 + value, 10) <= 999999999) {
                    $('#DocumentNumber').addClass('loading');
                    app.core.GetExt('https://www.inmotiontools.com:8083/logic/api/padron/personaporcedula?cedula=' + parseInt(0 + value, 10))
                        .done(function (data, textStatus, jqXHR) {
                            if (data.Nombre !== null) {
                                alert(data.Nombre);
                            }
                        }).always(function () {
                            $('#DocumentNumber').removeClass('loading');
                        });
                }
            }
        });

        $('#PrototypeEdtFormSave').click(function () {

            if (app.ui.IsValid('#PrototypeEdtForm', false)) {
                app.ui.ButtonDoing('#PrototypeEdtFormSave');

                app.core.Post(app.setting.apipath + 'v1/AvisoCobro/ConsultaRecibos',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {
                            if (data != null)
                                $('#recibosTbl').bootstrapTable('load', data);
                            else
                                $('#recibosTbl').bootstrapTable('load', {});
                        }

                    }).always(function () {
                        app.ui.ButtonDone('#PrototypeEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#PrototypeEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#PrototypeEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PrototypeEdtFormCancel'); }, 3000);
            event.preventDefault();
        });

    };

    function data_changed() {
        $('#recibosTbl').bootstrapTable('load', {});


        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#PrototypeEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                desde: { required: true },
                hasta: { required: true },
                cod_mon: { required: true },
            },
            messages: {
                desde: { required: 'Debe indicar el Desde' },
                hasta: { required: 'Debe indicar el Hasta' },
                cod_mon: { required: 'Debe indicar el Moneda' },
            }
        });
    };

    function recibos_table_setup() {

        $('#recibosTbl').bootstrapTable({
            uniqueId: 'Num_Recibo',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            search: true,
            searchAlign: 'left',
            columns: [
                {
                    field: 'seleccionado',
                    align: 'center',
                    titleTooltip: 'Permite seleccionar el recibo para crear el aviso de cobro',
                    checkbox: true
                },
                {
                    field: 'Num_Poliza',
                    title: 'Póliza',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'Num_Recibo',
                    title: 'Recibo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'Imp_Recibo',
                    title: 'Monto',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.CurrencyAmountFormatter'
                }, {
                    field: 'Fec_Efec_Recibo',
                    title: 'Fecha efecto',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter'
                }, {
                    field: 'Estatus',
                    title: 'Estado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'Nom_Riesgo',
                    title: 'Riesgo',
                    titleTooltip: 'Nombre del riesgo',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'Tip_Docum_Aseg',
                    title: 'Asegurado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: function (value, row, index, field) {
                        return `<span>${row.Tip_Docum_Aseg} ${row.Cod_Docum_Aseg} - ${row.Nom_Asegurado}</span>`;
                    }
                }]
        });

    };

    return {
        Init: function () {
            try {
                Controls_setup();
                Setup_Validations();
                recibos_table_setup();

                Controls_Events();
                Setup();
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
        Changed: function (callback) {
            changedCallback = callback;
        },
        IsValid: function (showResume) {
            return app.ui.IsValid('#PrototypeEdtForm', false, showResume);
        }
    };
})();
