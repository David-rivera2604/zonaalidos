var app = app || {};

app.AvisosRecibos = (function () {
    const estado = { EP: "Pendiente" };
    let changedCallback = null;

    function Setup() {
        let lks = ['MonedasPorRamo.cod_mon', 'FrecuenciaDePagoPorRamo.cod_fracc_pago.'];

        if (localStorage.getItem('Roles').includes('Empleado')) {
            lks.push('Agents.Cod_Agt');
        } else {
            lks.push('PolizaGrupo.polizagrupo.');
            lks.push('Contratos.contratos.');
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

            }, `cod_ramo=302:cod_mon=1`);
    };

    function MapInputToObject() {

        let data = {
            Cod_Agt: app.ui.GetDropDownNumericValue('#Cod_Agt'),
            Fec_Efec_Rec_Desde: app.ui.GetDateValue('#desde'),
            Fec_Efec_Rec_Hasta: app.ui.GetDateValue('#hasta'),
            Cod_Mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            Cod_Fracc_Pago: app.ui.GetDropDownNumericValue('#cod_fracc_pago'),
            Num_Poliza_Grupo: app.ui.GetDropDownNumericValue('#polizagrupo'),
            Num_Contrato: app.ui.GetDropDownNumericValue('#contratos'),
            Tip_Docum: {
                1: 'CNA',
                2: 'CRE',
                3: 'PAS',
                4: 'CJU'
            }[$("#DocumentNumberType").data("value")] || 'DESCONOCIDO',
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
        app.ui.SetDropDownNumericValue('#Cod_Agt', data.Cod_Agt, true);
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
            $('#RecibosGridTbl').bootstrapTable('load', data.recibos);
        else
            $('#RecibosGridTbl').bootstrapTable('load', {});

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

        $('#GeneraAvisos').click(function () {

            if (app.ui.IsValid('#PrototypeEdtForm', false)) {
                let payload = MapInputToObject();
                payload.Lista_Recibos = $('#RecibosGridTbl').bootstrapTable('getData').filter(i => i.seleccionado).map(u => u.Num_Recibo).join(';');

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
                        $('#RecibosGridTbl').bootstrapTable('removeAll', {});
                        $('#RecibosGridTbl').bootstrapTable('load', {});

                    }).always(function () {
                        app.ui.ButtonDone('#GeneraAvisos');
                    });


            }
            event.preventDefault();
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
                                $('#RecibosGridTbl').bootstrapTable('load', data);
                            else
                                $('#RecibosGridTbl').bootstrapTable('load', {});
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

        $('#Cod_Agt').on('change', function () {
            if (localStorage.getItem('Roles').includes('Empleado')) {
                app.core.LookupDependency($('select#Cod_Agt').val(), 'polizagrupo', 'PolizaGrupoPorAgente', '', null, true, null, `cod_ramo=302:cod_mon=${app.ui.GetDropDownNumericValue('#cod_mon')}:Cod_Agt=`);
                app.core.LookupDependency($('select#Cod_Agt').val(), 'contratos', 'ContratosPorAgente', '', null, true, null, `cod_ramo=302:cod_mon=${app.ui.GetDropDownNumericValue('#cod_mon')}:Cod_Agt=`);
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
                $('#RecibosGridTbl').bootstrapTable('removeAll', {});
                $('#RecibosGridTbl').bootstrapTable('load', {});
                break;
        }

        if ($('#generalNotify').html().length > 10) {
            $('#generalNotify').html('');
        }
        $('#GeneraAvisos').prop("disabled", $('#RecibosGridTbl').bootstrapTable('getData').filter(i => i.seleccionado).length == 0);

        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());

        if (e != null && e.name == 'btSelectAllX') {
            console.log(e);
            let checked = $("[name='btSelectAll']").is(":checked");
            $('#RecibosGridTbl').bootstrapTable('getData').forEach(function (item) {
                item.seleccionado = checked;
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

        $('#RecibosGridTbl').bootstrapTable({
            uniqueId: 'Num_Recibo',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            search: true,
            searchAlign: 'left',
            maintainMetaData: true,
            clickToSelect: true,
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
                },
                 {
                    field: 'mca_cuota_gratis',
                    title: 'Marca Cuotas Gratis',
                    titleTooltip: 'Marca Cuotas Gratis',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                },
                {
                    field: 'tip_docum_pag',
                    title: 'Pagador',
                    titleTooltip: 'Pagador',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: function (value, row, index, field) {
                        return `<span>${row.tip_docum_pag} ${row.cod_docum_pag} - ${row.nom_pagador}</span>`;
                    }
                }  ]
        });

        $('#RecibosGridTbl').on('check.bs.table', function () {
            data_changed('#RecibosGridTbl');
        });
        $('#RecibosGridTbl').on('uncheck.bs.table', function () {
            data_changed('#RecibosGridTbl');
        });

        $('#RecibosGridTbl').on('check-all.bs.table', function () {
            $('#RecibosGridTbl').bootstrapTable('getData').forEach(function (item) {
                item.seleccionado = true;
            })
        });
        $('#RecibosGridTbl').on('uncheck-all.bs.table', function () {
            $('#RecibosGridTbl').bootstrapTable('getData').forEach(function (item) {
                item.seleccionado = false;
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
                app.language.translate('body', 'Recibos')();
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
