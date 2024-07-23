var app = app || {};

app.CotizacionViajero = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {

        app.core.Get(app.setting.apipath + 'v1/Quote/ViajeroSetup', null,
            function (data) {
                app.Cotizacion.CustomAgentHandler('', data);

                app.core.Lookups(['MonedasPorRamo.cod_mon', 'FrecuenciaDePagoPorRamo.cod_fracc_pago', 'TRON_G2990006:TIP_PLAN.TIP_PLAN', 'TRON_G2990006:TIP_VIAJE.TIP_VIAJE', 'TRON_A1002090.COD_MODALIDAD',
                    'TRON_A1000101.PAIS_ORIGEN', 'TRON_A1000101.DES_DESTINO'],
                    function () {
                        setupData = data;
                        MapObjectToInput(data);
                    }, `cod_ramo=441:cod_mon=2:cod_agt=${data.cod_agt}`);

            });
    };

    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Quote/ViajeroQuote',
            JSON.stringify(MapInputToObject()),
            function (data) {
                quoteData = data;
                if (!app.ui.NotifyErrors(data.Mensaje, data.Errors, '#VisualizationsEdtForm')) {
                    $('#presupuesto').html(data.presupuesto);
                    $('#coberturasRow').removeClass('d-none');
                    $('#coberturasTbl').bootstrapTable('load', data.coberturas);

                    $('#plandepagoRow').removeClass('d-none');
                    $('#plandepagoTbl').bootstrapTable('load', data.plandepago);


                    if (data.plandepagoporfrecuencia != null)
                        $('#plandepagoporfrecuenciaTbl').bootstrapTable('load', data.plandepagoporfrecuencia);
                    else
                        $('#plandepagoporfrecuenciaTbl').bootstrapTable('load', {});

                    $('#mainBlock').removeClass('col-md-12');
                    $('#mainBlock').addClass('col-md-9');
                    $('#quoteBlock').removeClass('d-none');
                    showCalculate = true;
                    if (data.resumen != null) {
                        var moneda = "$ ";
                        if (app.ui.GetDropDownNumericValue('#moneda') == 1) {
                            moneda = "₡ "
                        }
                        $('#importetotal').html(moneda + data.resumen.importetotal.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#primaneta').html(data.resumen.primaneta.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#iva').html(data.resumen.iVA.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#recargoporfraccionamiento').html(data.resumen.recargoporfraccionamiento.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#cuotas').html(data.resumen.cuota);
                        $('html,body').animate({ scrollTop: $('#quoteBlock').offset().top }, 'slow');
                    }
                }


            }).always(function () {
                app.ui.ButtonDone('#cotizar');
            });
    };

    function MapInputToObject() {
        var data = {
            cod_mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            cod_mon_desc: $("#cod_mon option:selected").text(),
            cod_fracc_pago: app.ui.GetDropDownNumericValue('#cod_fracc_pago'),
            fec_efec_poliza: app.ui.GetDateValue('#fec_efec_poliza'),
            fec_vcto_poliza: app.ui.GetDateValue('#fec_vcto_poliza'),
            TIP_PLAN: app.ui.GetDropDownStringValue('#TIP_PLAN'),
            TIP_PLAN_DESC: $("#TIP_PLAN option:selected").text(),
            TIP_VIAJE: app.ui.GetDropDownStringValue('#TIP_VIAJE'),
            TIP_VIAJE_DESC: $("#TIP_VIAJE option:selected").text(),
            FEC_VIAJE: app.ui.GetDateValue('#FEC_VIAJE'),
            COD_PAIS_ORIGEN: $('#PAIS_ORIGEN').val(),
            PAIS_ORIGEN_DESC: $("#PAIS_ORIGEN option:selected").text(),
            DES_DESTINO: $('#DES_DESTINO').val(),
            DES_DESTINO_DESC: $("#DES_DESTINO option:selected").text(),
            FEC_NACIMIENTO: app.ui.GetDateValue('#FEC_NACIMIENTO'),
            FEC_NACIMIENTO2: app.ui.GetDateValue('#FEC_NACIMIENTO2'),
            FEC_NACIMIENTO3: app.ui.GetDateValue('#FEC_NACIMIENTO3'),
            FEC_NACIMIENTO4: app.ui.GetDateValue('#FEC_NACIMIENTO4'),
            FEC_NACIMIENTO5: app.ui.GetDateValue('#FEC_NACIMIENTO5'),
            FEC_NACIMIENTO6: app.ui.GetDateValue('#FEC_NACIMIENTO6'),
            FEC_NACIMIENTO7: app.ui.GetDateValue('#FEC_NACIMIENTO7'),
            FEC_NACIMIENTO8: app.ui.GetDateValue('#FEC_NACIMIENTO8'),
            FEC_NACIMIENTO9: app.ui.GetDateValue('#FEC_NACIMIENTO9'),
            FEC_NACIMIENTO10: app.ui.GetDateValue('#FEC_NACIMIENTO10'),
            COD_MODALIDAD: app.ui.GetDropDownNumericValue('#COD_MODALIDAD'),
            COD_MODALIDAD_DES: $("#COD_MODALIDAD option:selected").text(),
            cantidad_riesgos: app.ui.GetNumericValue('#cantidad_riesgos'),
            coberturas: $('#coberturasTbl').bootstrapTable('getData'),
            plandepago: $('#plandepagoTbl').bootstrapTable('getData')
        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#cod_mon').val(data.cod_mon);
        app.ui.SetDropDownNumericValue('#cod_mon', data.cod_mon, true);
        $('#cod_fracc_pago').val(data.cod_fracc_pago);
        app.ui.SetDropDownNumericValue('#cod_fracc_pago', data.cod_fracc_pago, true);
        app.ui.SetDateValue('#fec_efec_poliza', data.fec_efec_poliza);
        $('#fec_vcto_poliza_group').data("DateTimePicker").minDate($('#fec_efec_poliza_group').data("DateTimePicker").date());
        $('#TIP_PLAN').val(data.TIP_PLAN);
        app.ui.SetDropDownNumericValue('#TIP_PLAN', data.TIP_PLAN, true, 'I');
        $('#TIP_VIAJE').val(data.TIP_VIAJE);
        app.ui.SetDropDownNumericValue('#TIP_VIAJE', data.TIP_VIAJE, true, 'NA');
        app.ui.SetDateValue('#FEC_VIAJE', data.FEC_VIAJE);
        $('#PAIS_ORIGEN').val(data.COD_PAIS_ORIGEN);
        $('#DES_DESTINO').val(data.DES_DESTINO);
        app.ui.SetNumericValue('#cantidad_riesgos', data.cantidad_riesgos);
        app.ui.SetDateValue('#FEC_NACIMIENTO', data.FEC_NACIMIENTO);
        app.ui.SetDateValue('#FEC_NACIMIENTO2', data.FEC_NACIMIENTO2);
        app.ui.SetDateValue('#FEC_NACIMIENTO3', data.FEC_NACIMIENTO3);
        app.ui.SetDateValue('#FEC_NACIMIENTO4', data.FEC_NACIMIENTO4);
        app.ui.SetDateValue('#FEC_NACIMIENTO5', data.FEC_NACIMIENTO5);
        app.ui.SetDateValue('#FEC_NACIMIENTO6', data.FEC_NACIMIENTO6);
        app.ui.SetDateValue('#FEC_NACIMIENTO7', data.FEC_NACIMIENTO7);
        app.ui.SetDateValue('#FEC_NACIMIENTO8', data.FEC_NACIMIENTO8);
        app.ui.SetDateValue('#FEC_NACIMIENTO9', data.FEC_NACIMIENTO9);
        app.ui.SetDateValue('#FEC_NACIMIENTO10', data.FEC_NACIMIENTO10);
        $('#COD_MODALIDAD').val(data.COD_MODALIDAD);
        app.ui.SetDropDownNumericValue('#COD_MODALIDAD', data.COD_MODALIDAD, true);
        if (data.coberturas != null)
            $('#coberturasTbl').bootstrapTable('load', data.coberturas);
        else
            $('#coberturasTbl').bootstrapTable('load', {});
        if (data.plandepago != null)
            $('#plandepagoTbl').bootstrapTable('load', data.plandepago);
        else
            $('#plandepagoTbl').bootstrapTable('load', {});

    };

    function Controls_setup() {
        $('#fec_efec_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            defaultDate: new Date()

        });
        $('#fec_vcto_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#FEC_VIAJE_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#FEC_NACIMIENTO_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#FEC_NACIMIENTO2_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#FEC_NACIMIENTO3_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#FEC_NACIMIENTO4_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#FEC_NACIMIENTO5_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#FEC_NACIMIENTO6_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#FEC_NACIMIENTO7_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#FEC_NACIMIENTO8_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#FEC_NACIMIENTO9_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#FEC_NACIMIENTO10_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        new AutoNumeric('#cantidad_riesgos', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '10',
            minimumValue: '1',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });

        $("#PAIS_ORIGEN").append($("#PAIS_ORIGEN option").remove().sort(function (a, b) {
            var at = $(a).text(), bt = $(b).text();
            return (at > bt) ? 1 : ((at < bt) ? -1 : 0);
        }));

        $("#DES_DESTINO").append($("#DES_DESTINO option").remove().sort(function (a, b) {
            var at = $(a).text(), bt = $(b).text();
            return (at > bt) ? 1 : ((at < bt) ? -1 : 0);
        }));

        $("#cotizar").appendTo("#GenericToolBar");
        $("#limpiar").appendTo("#GenericToolBar");
    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#VisualizationsEdtForm :input").change(function () {
            data_changed();
        });

        $('#fec_efec_poliza').blur(function () {
            let minDate = app.ui.GetDateRawValue('#fec_efec_poliza');
            minDate.setDate(minDate.getDate());

            //Asignacion a vencimiento
            app.ui.SetDateValue('#fec_vcto_poliza', minDate + 1);

            //Asignacion a fecha de viaje
            app.ui.SetDateValue('#FEC_VIAJE', minDate);
        });

        $('#cantidad_riesgos').blur(function () {
            let riesgos = app.ui.GetNumericValue('#cantidad_riesgos');

            for (var i = 2; i <= 10; i++) {
                if (i <= riesgos) {
                    $('#FEC_NACIMIENTO' + i).parent().parent().parent().removeClass('d-none');
                } else {
                    $('#FEC_NACIMIENTO' + i).parent().parent().parent().addClass('d-none');
                }
            }

        });

        $('#VisualizationsEdtFormSave').click(function () {

            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#VisualizationsEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/Cotizacion/Viajero',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {

                        }

                    }).always(function () {
                        app.ui.ButtonDone('#VisualizationsEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#VisualizationsEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#VisualizationsEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#VisualizationsEdtFormCancel'); }, 3000);
            event.preventDefault();
        });

        $('#cotizar').click(function () {

            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#cotizar');
                Quote();
            }
            event.preventDefault();
        });

        $('#print').click(function () {
            event.preventDefault();
            let data = MapInputToObject();
            data.plandepagoporfrecuencia = quoteData.plandepagoporfrecuencia;
            data.presupuesto = quoteData.presupuesto;
            data.Agente = setupData.Agente;
            app.Cotizacion.Imprimir('SegurViaje', data);
        });

        $('#emitir').click(function () {
            event.preventDefault();
            window.location.replace(app.setting.basepath + 'emision/viajero?presupuesto=' + quoteData.presupuesto);
        });

    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#VisualizationsEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                cod_mon: { required: true },
                cod_fracc_pago: { required: true },
                fec_efec_poliza: { required: true },
                fec_vcto_poliza: { required: true },
                TIP_PLAN: { required: true },
                TIP_VIAJE: { required: true },
                FEC_VIAJE: { required: true },
                PAIS_ORIGEN: { required: true },
                DES_DESTINO: { required: true },
                COD_MODALIDAD: { required: true },
                cantidad_riesgos: { required: true, Numeric: true },
                FEC_NACIMIENTO: { required: true },
                FEC_NACIMIENTO2: { required: true },
                FEC_NACIMIENTO3: { required: true },
                FEC_NACIMIENTO4: { required: true },
                FEC_NACIMIENTO5: { required: true },
                FEC_NACIMIENTO6: { required: true },
                FEC_NACIMIENTO7: { required: true },
                FEC_NACIMIENTO8: { required: true },
                FEC_NACIMIENTO9: { required: true },
                FEC_NACIMIENTO10: { required: true }
            },
            messages: {
                cod_mon: { required: 'Debe indicar la moneda' },
                cod_fracc_pago: { required: 'Debe indicar el fraccionamiento de pago' },
                fec_efec_poliza: { required: 'Debe indicar el inicio de vigencia' },
                fec_vcto_poliza: { required: 'Debe indicar el fin de vigencia' },
                TIP_PLAN: { required: 'Debe indicar el plan' },
                TIP_VIAJE: { required: 'Debe indicar el tipo de viaje' },
                FEC_VIAJE: { required: 'Debe indicar el fecha de inicio del viaje' },
                PAIS_ORIGEN: { required: 'Debe indicar el pais de origen' },
                DES_DESTINO: { required: 'Debe indicar el lugar de destino' },
                COD_MODALIDAD: { required: 'Debe indicar la modalidad' },
                cantidad_riesgos: { required: 'Debe indicar la cantidad de riesgos', Numeric: 'Debe indicar la cantidad de riesgos' },
                FEC_NACIMIENTO: { required: 'Debe indicar la fecha de nacimiento - Riesgo 1' },
                FEC_NACIMIENTO2: { required: 'Debe indicar la fecha de nacimiento - Riesgo 2' },
                FEC_NACIMIENTO3: { required: 'Debe indicar la fecha de nacimiento - Riesgo 3' },
                FEC_NACIMIENTO4: { required: 'Debe indicar la fecha de nacimiento - Riesgo 4' },
                FEC_NACIMIENTO5: { required: 'Debe indicar la fecha de nacimiento - Riesgo 5' },
                FEC_NACIMIENTO6: { required: 'Debe indicar la fecha de nacimiento - Riesgo 6' },
                FEC_NACIMIENTO7: { required: 'Debe indicar la fecha de nacimiento - Riesgo 7' },
                FEC_NACIMIENTO8: { required: 'Debe indicar la fecha de nacimiento - Riesgo 8' },
                FEC_NACIMIENTO9: { required: 'Debe indicar la fecha de nacimiento - Riesgo 9' },
                FEC_NACIMIENTO10: { required: 'Debe indicar la fecha de nacimiento - Riesgo 10' }
            }
        });
    };

    function coberturas_table_setup() {

        $('#coberturasTbl').bootstrapTable({
            uniqueId: 'coberturasId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'seleccionado',
                    checkbox: true,
                    visible: false
                }, {
                    field: 'riesgo',
                    title: 'Riesgo',
                    titleTooltip: 'Número del riesgo',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: true
                }, {
                    field: 'codigo',
                    title: 'Código',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: true
                }, {
                    field: 'nombre',
                    title: 'Nombre',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'capital',
                    title: 'Capital',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'primatotal',
                    title: 'Prima total',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'deducible',
                    title: 'Deducible',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                },]
        });



    };

    function plandepago_table_setup() {

        $('#plandepagoTbl').bootstrapTable({
            uniqueId: 'plandepagoId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'cuota',
                    title: 'Cuota',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: true
                }, {
                    field: 'fechadesde',
                    title: 'Fecha desde',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'fechahasta',
                    title: 'Fecha hasta',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'primaneta',
                    title: 'Prima neta',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'iVA',
                    title: 'IVA',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'recargoporfraccionamiento',
                    title: 'Recargo por fraccionamiento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'importetotal',
                    title: 'Importe total',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                },]
        });

    };

    return {
        Init: function () {
            try {
                Controls_setup();
                Setup_Validations();
                coberturas_table_setup();
                plandepago_table_setup();

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
            return app.ui.IsValid('#VisualizationsEdtForm', false, showResume);
        }
    };
})();