var app = app || {};

app.AvisosRecibos = (function () {
    const estado = { EP: "Pendiente" };
    let changedCallback = null;
    let source = [];

    function Setup() {
        let lks = ['MonedasPorRamo.cod_mon', 'FrecuenciaDePagoPorRamo.cod_fracc_pago.'];

        if (localStorage.getItem('Roles').includes('Empleado')) {
            lks.push('Agents.Cod_Agt');
        }

        app.core.Lookups(lks,
            function () {
                data = {
                    Cod_Agt: null,
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
                LoadPolizagrupoHelper();

            }, `cod_ramo=302:cod_mon=1`);
    };

    function LoadPolizagrupoHelper() {
        let cod_agt = 0;
        let reqName = 'PolicyGroupAndContract';

        if (localStorage.getItem('Roles').includes('Empleado')) {
            cod_agt = app.ui.GetDropDownNumericValue('#Cod_Agt');
            reqName = 'PolicyGroupAndContractByAgent';
        }

        $('#polizagrupoHelper').typeahead('destroy');
        $("#polizagrupoHelper").val('');

        app.core.Get(app.setting.apipath + `v1/datasource/${reqName}?url=cod_mon=${app.ui.GetDropDownNumericValue('#cod_mon')}:cod_agt=${cod_agt}`)
            .done(function (data) {
                source = [];
                data.forEach(function (value, index, array) {
                    source.push({ "name": value.DESCRIPCION, "code": value });
                });
                $('#polizagrupoHelper').typeahead({
                    highlight: true,
                    source: source,
                    afterSelect: function (item) {
                        console.log('afterSelect', item);
                    }
                });
            });
    }

    function MapInputToObject() {
        let data = {
            Cod_Agt: app.ui.GetDropDownNumericValue('#Cod_Agt'),
            Fec_Efec_Rec_Desde: app.ui.GetDateValue('#desde'),
            Fec_Efec_Rec_Hasta: app.ui.GetDateValue('#hasta'),
            Cod_Mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            Cod_Fracc_Pago: app.ui.GetDropDownNumericValue('#cod_fracc_pago'),
            Num_Poliza_Grupo: '',
            Num_Contrato: 0,
            Tip_Docum: $("#DocumentNumberType").data("value"),
            Cod_Docum: $('#DocumentNumber').val()
        };
        if (data.Cod_Docum == '') {
            data.Tip_Docum = '';
        }
        if (data.Num_Poliza_Grupo == 0) {
            data.Num_Poliza_Grupo = '';
        }
        let polizagrupoHelper = $("#polizagrupoHelper").val();
        if (polizagrupoHelper != '') {
            let selected = source.find(e => e.name === polizagrupoHelper);
            if (selected != undefined) {
                data.Num_Poliza_Grupo = selected.code.NUM_POLIZA;
                data.Num_Contrato = selected.code.NUM_CONTRATO;
            }
        }
        return data;
    };

    function MapObjectToInput(data) {
        app.ui.SetDropDownNumericValue('#Cod_Agt', data.Cod_Agt, true);
        app.ui.SetDateValue('#desde', data.desde);
        $('#hasta_group').data("DateTimePicker").minDate($('#desde_group').data("DateTimePicker").date());
        app.ui.SetDateValue('#hasta', data.hasta);
        $('#cod_mon').val(data.cod_mon);
        app.ui.SetDropDownNumericValue('#cod_mon', data.cod_mon, true);
        $('#cod_fracc_pago').val(data.cod_fracc_pago);
        app.ui.SetDropDownNumericValue('#cod_fracc_pago', data.cod_fracc_pago, true);
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
        $("#PrototypeEdtFormSave").appendTo("#GenericToolBar");
        $("#PrototypeEdtFormCancel").appendTo("#GenericToolBar");
    };

    function Controls_Events() {

        $("#polizagrupoHelper").change(function (e) {
            let value = $(this).val();
            if (value != '' && source.find(e => e.name === value) === undefined) {
                $(this).val('');
            }
        });

        $("#cod_mon").change(function (e) {
            LoadPolizagrupoHelper();
        });

        $(".input-group.date").on('dp.change', function (e) {
            data_changed('#' + this.id.replace('_group', ''));
        });

        $("#PrototypeEdtForm :input").change(function (e) {
            data_changed(this);
        });

        $('#desde').blur(function () {
            var minDate = app.ui.GetDateRawValue('#desde');
            minDate.setDate(minDate.getDate());

            $('#hasta_group').data("DateTimePicker").minDate(minDate);
        });

        $('#GeneraAvisos').click(function (e) {

            if (app.ui.IsValid('#PrototypeEdtForm', false)) {
                let payload = MapInputToObject();
                payload.Lista_Recibos = $('#recibosTbl').bootstrapTable('getSelections').filter(i => i.Seleccionado).map(u => u.Num_Recibo).join(';');

                app.ui.ButtonDoing('#GeneraAvisos');
                app.core.Post(app.setting.apipath + 'v1/AvisoCobro/Generar',
                    JSON.stringify(payload),
                    function (data) {
                        console.log(data);
                        if (data?.length > 0) {
                            app.ui.ShowAlert('generalNotify', 'alert-success', `<b> <i class="fa fa-check"></i> El aviso de cobro #${data[0].Num_Aviso} por un total de ${data[0].Total_Importe_Aviso.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}, fue creado de forma existosa.</b> Se procesaron con exito ${data[0].Cantidad_Recibos} recibos y los no procesados fueron ${data[0].Cantidad_Recibos_No_Procesados}.`);
                        } else {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', 'Ha ocurrido un error al tratar de generar el aviso de cobro, por favor intente nuevamente y en caso de persistir el problema contacte el personal de soporte');
                        }
                        $('#recibosTbl').bootstrapTable('removeAll', {});
                        $('#recibosTbl').bootstrapTable('load', {});

                    }).always(function () {
                        app.ui.ButtonDone('#GeneraAvisos');
                    });


            }
            e.preventDefault();
        });

        $('#PrototypeEdtFormSave').click(function (e) {

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
            e.preventDefault();
        });

        $('#PrototypeEdtFormCancel').click(function (e) {
            app.ui.ButtonDoing('#PrototypeEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PrototypeEdtFormCancel'); }, 3000);
            e.preventDefault();
        });

        $('#Cod_Agt').on('change', function () {
            if (localStorage.getItem('Roles').includes('Empleado')) {
                LoadPolizagrupoHelper();
            }
        });

        app.ui.DocumentNumberHandler('#DocumentNumber', function (data) {
            $("#Name").html(data != null ? data.FullName : '');
        });
    };

    function data_changed(e) {

        let event = $(e).data('event');
        switch (event) {
            case 'clear.grid':
                $('#recibosTbl').bootstrapTable('removeAll', {});
                $('#recibosTbl').bootstrapTable('load', {});
                break;
        }

        if ($('#generalNotify').html().length > 10) {
            $('#generalNotify').html('');
        }
        $('#GeneraAvisos').prop("disabled", $('#recibosTbl').bootstrapTable('getSelections').filter(i => i.Seleccionado).length == 0);

        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());

        if (e != null && e.name == 'btSelectAllX') {
            console.log(e);
            let checked = $("[name='btSelectAll']").is(":checked");
            $('#recibosTbl').bootstrapTable('getData').forEach(function (item) {
                item.Seleccionado = checked;
            })
        }
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#PrototypeEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                Cod_Agt: { required: true },
                desde: { required: true },
                hasta: { required: true },
                cod_mon: { required: true },
            },
            messages: {
                Cod_Agt: { required: 'Debe indicar el agente' },
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
            maintainMetaData: true,
            maintainSelected: true,
            clickToSelect: true,
            columns: [
                {
                    field: 'Seleccionado',
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
                    formatter: function (value, row, index, field) {
                        if (value === null)
                            value = '';
                        else
                            value = estado[value] || value
                        return app.ui.BadgeColorFormatter(value, row, index, field)
                    }
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
                },
                {
                    field: 'Tip_Docum_Tom',
                    title: 'Tomador',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: function (value, row, index, field) {
                        return `<span>${row.Tip_Docum_Tom} ${row.Cod_Docum_Tom} - ${row.Nom_Tomador}</span>`;
                    }
                }]
        });

        $('#recibosTbl').on('check.bs.table', function () {
            data_changed('#recibosTbl');
        });
        $('#recibosTbl').on('uncheck.bs.table', function () {
            data_changed('#recibosTbl');
        });

        $('#recibosTbl').on('check-all.bs.table', function () {
            $('#recibosTbl').bootstrapTable('getData').forEach(function (item) {
                item.Seleccionado = true;
            })
        });
        $('#recibosTbl').on('uncheck-all.bs.table', function () {
            $('#recibosTbl').bootstrapTable('getData').forEach(function (item) {
                item.Seleccionado = false;
            })
        });

    };

    return {
        Init: function () {
            try {
                app.ui.CommonBehaviour();

                app.ViewerQuery.state = {
                    Estatus: { "VIGENTE": "primary", "_": "danger", "Cobrado": "success", "Pendiente": "warning" }
                };

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
app.ViewerQuery = {};
app.ViewerQuery.state = {};