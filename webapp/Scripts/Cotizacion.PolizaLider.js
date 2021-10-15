var app = app || {};

app.CotizacionPolizaLider = (function () {

    var setupData = null;
    var quoteData = null;
    var showCalculate = false;

    function Setup() {
        $('#coberturasTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/Quote/PolizaLiderSetup')
            .done(function (data, textStatus, jqXHR) {
                Init_Lookups(data);
            });
    };

    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Quote/PolizaLiderQuote',
            JSON.stringify(MapInputToObject()),
            function (data) {
                quoteData = data;
                if (!app.ui.NotifyErrors(data.Mensaje, data.Errors, '#VisualizationsEdtForm')) {
                    $('#coberturasRow').removeClass('d-none');
                    Coberturas_Handler(data.coberturas);

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
                        if (app.ui.GetDropDownNumericValue('#cod_mon') == 1) {
                            moneda = "₡ "
                        }
                        $('#importetotal').html(moneda + data.resumen.importetotal.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#primaneta').html(data.resumen.primaneta.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#iva').html(data.resumen.iVA.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#recargoporfraccionamiento').html(data.resumen.recargoporfraccionamiento.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#cuotas').html(data.resumen.cuotas);
                        $('html,body').animate({ scrollTop: $('#quoteBlock').offset().top }, 'slow');
                    }
                }
            }).always(function () {
                app.ui.ButtonDone('#cotizar');
            });
    };

    function Init_Lookups(data) {
        setupData = JSON.parse(JSON.stringify(data));
        app.core.Lookups([
            'MonedasPorRamo.cod_mon',
            'FrecuenciaDePagoPorRamo.cod_fracc_pago',
            'PlanesAutoLider.COD_PLAN_AUTO',
            'MarcasVehiculos.COD_MARCA',
            'ModelosVehiculos.COD_MODELO',
            'DescuentoPolizaLider.PCT_DCTO_AUTO_PAR',
            'ClaseVehiculos.COD_TIP_VEHI',
            'UsoVehiculo.COD_USO_VEHI',
            'CapitalRCPolizaLider.Resp_civilSA',
            'CapitalGMPolizaLider.Gast_medicSA',
            'CapitalACPolizaLider.Acc_ConducSA',
            'CapitalRCRIPolizaLider.IMP_AUTO_CRI'],
            function () {
                MapObjectToInput(data);
                Coberturas_ManejoDeCapital();
            }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}:cod_pais=${data.cod_pais}:cod_tip_ocup=${data.cod_ramo}%:cod_estado=${data.cod_estado}:cod_prov=${data.cod_prov}:cod_marca=${data.COD_MARCA}`);

        // Dependencies events
        $('#COD_MARCA').on('change', function () {
            app.core.LookupDependency($('select#COD_MARCA').val(), 'COD_MODELO', 'ModelosVehiculos', '', null, true, null, `cod_marca=`);
        });
    };

    function MapInputToObject() {
        var data = {
            cod_mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            cod_monDesc: $("#cod_mon option:selected").text(),
            cod_fracc_pago: app.ui.GetDropDownNumericValue('#cod_fracc_pago'),
            fec_efec_poliza: app.ui.GetDateValue('#fec_efec_poliza'),
            fec_vcto_poliza: app.ui.GetDateValue('#fec_vcto_poliza'),
            COD_PLAN_AUTO: app.ui.GetDropDownNumericValue('#COD_PLAN_AUTO'),
            COD_PLAN_AUTODesc: $("#COD_PLAN_AUTO option:selected").text(),
            COD_MARCA: app.ui.GetDropDownNumericValue('#COD_MARCA'),
            COD_MARCADesc: $("#COD_MARCA option:selected").text(),
            COD_MODELO: app.ui.GetDropDownNumericValue('#COD_MODELO'),
            COD_MODELODesc: $("#COD_MODELO option:selected").text(),
            PCT_DCTO_AUTO_PAR: app.ui.GetDropDownNumericValue('#PCT_DCTO_AUTO_PAR'),
            COD_TIP_VEHI: app.ui.GetDropDownNumericValue('#COD_TIP_VEHI'),
            COD_TIP_VEHIDesc: $("#COD_TIP_VEHI option:selected").text(),
            COD_USO_VEHI: app.ui.GetDropDownNumericValue('#COD_USO_VEHI'),
            COD_USO_VEHIDesc: $("#COD_USO_VEHI option:selected").text(),
            ANIO_SUB_MODELO: app.ui.GetNumericValue('#ANIO_SUB_MODELO'),
            MCA_VR: app.ui.GetRadioNumericValue('MCA_VR'),
            MCA_DESC_CLIENTE_NUEVO: app.ui.GetRadioNumericValue('MCA_DESC_CLIENTE_NUEVO'),
            MCA_CERO_KM: app.ui.GetRadioNumericValue('MCA_CERO_KM'),
            MCA_AUTO_GPS: app.ui.GetRadioNumericValue('MCA_AUTO_GPS'),
            mca_HogarTotal: app.ui.GetRadioNumericValue('mca_HogarTotal'),
            MCA_AUTO_GPS_CMS: app.ui.GetRadioNumericValue('MCA_AUTO_GPS_CMS'),
            Resp_civilSA: app.ui.GetDropDownNumericValue('#Resp_civilSA'),
            Gast_medicSA: app.ui.GetDropDownNumericValue('#Gast_medicSA'),
            Acc_ConducSA: app.ui.GetDropDownNumericValue('#Acc_ConducSA'),
            Valor_VehiSA: app.ui.GetNumericValue('#Valor_VehiSA'),
            Equi_EspeSA: app.ui.GetNumericValue('#Equi_EspeSA'),
            IMP_AUTO_CRI: app.ui.GetDropDownNumericValue('#IMP_AUTO_CRI'),
            coberturas: $('#coberturasTbl').bootstrapTable('getData'),
            plandepago: $('#plandepagoTbl').bootstrapTable('getData'),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#cod_mon').val(data.cod_mon);
        $('#cod_fracc_pago').val(data.cod_fracc_pago);
        app.ui.SetDateValue('#fec_efec_poliza', data.fec_efec_poliza);
        $('#fec_vcto_poliza_group').data("DateTimePicker").minDate($('#fec_efec_poliza_group').data("DateTimePicker").date());
        app.ui.SetDateValue('#fec_vcto_poliza', data.fec_vcto_poliza);
        $('#COD_PLAN_AUTO').val(data.COD_PLAN_AUTO);
        $('#COD_MARCA').val(data.COD_MARCA);
        $('#COD_MODELO').val(data.COD_MODELO);
        $('#PCT_DCTO_AUTO_PAR').val(data.PCT_DCTO_AUTO_PAR);
        $('#COD_TIP_VEHI').val(data.COD_TIP_VEHI);
        $('#COD_USO_VEHI').val(data.COD_USO_VEHI);
        app.ui.SetNumericValue('#ANIO_SUB_MODELO', data.ANIO_SUB_MODELO);
        app.ui.SetRadioNumericValue('MCA_VR', data.MCA_VR);
        app.ui.SetRadioNumericValue('MCA_DESC_CLIENTE_NUEVO', data.MCA_DESC_CLIENTE_NUEVO);
        app.ui.SetRadioNumericValue('MCA_CERO_KM', data.MCA_CERO_KM);
        app.ui.SetRadioNumericValue('MCA_AUTO_GPS', data.MCA_AUTO_GPS);
        app.ui.SetRadioNumericValue('mca_HogarTotal', data.mca_HogarTotal);
        app.ui.SetRadioNumericValue('MCA_AUTO_GPS_CMS', data.MCA_AUTO_GPS_CMS);
        $('#Resp_civilSA').val(data.Resp_civilSA);
        $('#Gast_medicSA').val(data.Gast_medicSA);
        $('#Acc_ConducSA').val(data.Acc_ConducSA);
        app.ui.SetNumericValue('#Valor_VehiSA', data.Valor_VehiSA);
        app.ui.SetNumericValue('#Equi_EspeSA', data.Equi_EspeSA);
        $('#IMP_AUTO_CRI').val(data.IMP_AUTO_CRI);
        Coberturas_Handler(data.coberturas);
        $('#coberturasTbl').bootstrapTable('hideLoading');
        if (data.plandepago != null)
            $('#plandepagoTbl').bootstrapTable('load', data.plandepago);
        else
            $('#plandepagoTbl').bootstrapTable('load', {});

    };

    function Controls_setup() {
        $('#fec_efec_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fec_vcto_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#ANIO_SUB_MODELO', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '',
            maximumValue: '9999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Valor_VehiSA', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Equi_EspeSA', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        $("#cotizar").appendTo("#GenericToolBar");
        $("#limpiar").appendTo("#GenericToolBar");
    };

    function Controls_Events() {

        $("#VisualizationsEdtForm :input").change(function () {
            data_changed();
        });

        $('#fec_efec_poliza').blur(function () {
            var minDate = app.ui.GetDateRawValue('#fec_efec_poliza');
            minDate.setDate(minDate.getDate() + 1);

            $('#fec_vcto_poliza_group').data("DateTimePicker").minDate(minDate);
        });

        $('#cotizar').click(function () {

            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#cotizar');
                Quote();
            }
            event.preventDefault();
        });

        $('#limpiar').click(function () {
            app.ui.ButtonDoing('#limpiar');
            $('#mainBlock').removeClass('col-md-9');
            $('#mainBlock').addClass('col-md-12');
            $('#quoteBlock').addClass('d-none');
            $('#plandepagoRow').addClass('d-none');
            MapObjectToInput(setupData);
            app.ui.ButtonDone('#limpiar');
            event.preventDefault();
        });

        $('#print').click(function () {
            event.preventDefault();
            let data = MapInputToObject();
            data.plandepagoporfrecuencia = quoteData.plandepagoporfrecuencia;
            data.Agente = setupData.Agente;
            app.Cotizacion.Imprimir('PolizaLider', data);
        });

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
                COD_PLAN_AUTO: { required: true },
                COD_MARCA: { required: true },
                COD_MODELO: { required: true },
                PCT_DCTO_AUTO_PAR: { required: true },
                COD_TIP_VEHI: { required: true },
                COD_USO_VEHI: { required: true },
                ANIO_SUB_MODELO: { required: true },
                Resp_civilSA: { required: true, min: 1 },
                Gast_medicSA: { required: true, min: 1 },
                Acc_ConducSA: { required: true, min: 1 },
                Valor_VehiSA: { required: true, Numeric: true },
                Equi_EspeSA: { required: true, Numeric: true },
                IMP_AUTO_CRI: { required: true, min: 1 },
            },
            messages: {
                cod_mon: { required: 'Debe indicar el Moneda' },
                cod_fracc_pago: { required: 'Debe indicar el Fraccionamiento de pago' },
                fec_efec_poliza: { required: 'Debe indicar el Inicio de vigencia' },
                fec_vcto_poliza: { required: 'Debe indicar el Fin de vigencia' },
                COD_PLAN_AUTO: { required: 'Debe indicar el Plan' },
                COD_MARCA: { required: 'Debe indicar el Marca' },
                COD_MODELO: { required: 'Debe indicar el Modelo' },
                PCT_DCTO_AUTO_PAR: { required: 'Debe indicar el % de descuento familiar' },
                COD_TIP_VEHI: { required: 'Debe indicar el Clase del vehículo' },
                COD_USO_VEHI: { required: 'Debe indicar el Uso del vehículo' },
                ANIO_SUB_MODELO: { required: 'Debe indicar el Año de fabricación' },
                Resp_civilSA: { required: 'Debe indicar el valor para responsabilidad civil', min: 'Debe indicar el valor para responsabilidad civil' },
                Gast_medicSA: { required: 'Debe indicar el valor para los gastos médicos de los ocupantes', min: 'Debe indicar el monto para los gastos médicos de los ocupantes' },
                Acc_ConducSA: { required: 'Debe indicar el valor para accidentes al conductor', min: 'Debe indicar el valor para accidentes al conductor' },
                Valor_VehiSA: { required: 'Debe indicar el valor del vehículo asegurado', Numeric: 'Debe indicar el valor del vehículo asegurado' },
                Equi_EspeSA: { required: 'Debe indicar el valor del Equipo especial', Numeric: 'Debe indicar el valor del equipo especial' },
                IMP_AUTO_CRI: { required: 'Debe indicar el valor para rotura de cristales', min: 'Debe indicar el valor para rotura de cristales' },
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
                    align: 'center',
                    checkbox: true
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
                    formatter: 'app.ui.DecimalWithZeroFormatter',
                    visible: true
                }, {
                    field: 'primatotal',
                    title: 'Prima total',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalWithZeroFormatter',
                    visible: true
                }, {
                    field: 'decucible',
                    title: 'Deducible',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                },]
        });

        $('#coberturasTbl').on('check.bs.table', function () {
            Coberturas_ManejoDeCapital();
        });
        $('#coberturasTbl').on('check-all.bs.table', function () {
            Coberturas_ManejoDeCapital();
        });
        $('#coberturasTbl').on('uncheck.bs.table', function () {
            Coberturas_ManejoDeCapital();
        });
        $('#coberturasTbl').on('uncheck-all.bs.table', function () {
            Coberturas_ManejoDeCapital();
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

    function plandepagoporfrecuencia_table_setup() {

        $('#plandepagoporfrecuenciaTbl').bootstrapTable({
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            columns: [
                {
                    field: 'codigo',
                    title: 'codigo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                }, {
                    field: 'frecuencia',
                    title: 'Fraccionamiento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    visible: true
                }, {
                    field: 'importetotal',
                    title: 'Importe',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'recargoporfraccionamiento',
                    title: '%',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }]
        });

    };

    function data_changed() {
        if (showCalculate) {
            $('#plandepagoRow').addClass('d-none');

            $('#mainBlock').addClass('col-md-12');
            $('#mainBlock').removeClass('col-md-9');
            $('#quoteBlock').addClass('d-none');


            var coberturas = $('#coberturasTbl').bootstrapTable('getData');
            for (var i = 0; i < coberturas.length; i++) {
                coberturas[i].capital = 0;
                coberturas[i].primatotal = 0;
                coberturas[i].decucible = '';
                coberturas[i].error = '';
            }
            Coberturas_Handler(coberturas);
            $('#plandepagoTbl').bootstrapTable('load', {});

            showCalculate = false;
        }

        if (!$('#coberturasTbl-validate').hasClass("d-none")) {
            $('#coberturasTbl-validate').text('');
            $('#coberturasTbl-validate').addClass('d-none');
        }
    };

    function Coberturas_Handler(coberturas) {
        if (coberturas === null) {
            coberturas = {};
        }
        $('#coberturasTbl').bootstrapTable('load', coberturas);
        $('[name=btSelectAll]').prop("disabled", true);
        coberturas.forEach(function (value, index, array) {
            if (value.requerida) {
                $('[name=btSelectItem][data-index=' + index + ']').prop("disabled", true);
            }
        });
    };

    function Coberturas_ManejoDeCapital() {
        var coberturas = $('#coberturasTbl').bootstrapTable('getData');

        if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3001)) {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#Resp_civilSA', false);
        }
        else {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#Resp_civilSA', true);
            $('#Resp_civilSA').val(0);
        }
        if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3002)) {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#Gast_medicSA', false);
        }
        else {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#Gast_medicSA', true);
            $('#Gast_medicSA').val(0);
        }
        if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3003)) {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#Acc_ConducSA', false);
        }
        else {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#Acc_ConducSA', true);
            $('#Acc_ConducSA').val(0);
        }
        if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3004) || app.Cotizacion.Coberturas_Seleccionada(coberturas, 3005) || app.Cotizacion.Coberturas_Seleccionada(coberturas, 3006)) {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#Valor_VehiSA', false);
        }
        else {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#Valor_VehiSA', true);
            app.ui.SetNumericValue('#Valor_VehiSA', 0);
        }
        if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3007)) {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#Equi_EspeSA', false);
        }
        else {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#Equi_EspeSA', true);
            app.ui.SetNumericValue('#Equi_EspeSA', 0);
        }
        if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3009)) {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_CRI', false);
        }
        else {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_CRI', true);
            $('#IMP_AUTO_CRI').val(0);
        }

        //if (Coberturas_Seleccionada(coberturas, 2010) || Coberturas_Seleccionada(coberturas, 2055) || Coberturas_Seleccionada(coberturas, 2056) || Coberturas_Seleccionada(coberturas, 2057) || Coberturas_Seleccionada(coberturas, 2012) || Coberturas_Seleccionada(coberturas, 2014)) {
        //    Coberturas_ComportamientoDependencia('#sAObjetosvaliosos', false);
        //    Coberturas_ComportamientoDependencia('#sAMobiliario', false);
        //}
        //else {
        //    Coberturas_ComportamientoDependencia('#sAObjetosvaliosos', true);
        //    Coberturas_ComportamientoDependencia('#sAMobiliario', true);
        //    app.ui.SetNumericValue('#sAObjetosvaliosos', 0);
        //    app.ui.SetNumericValue('#sAMobiliario', 0);
        //}

        //if (Coberturas_Seleccionada(coberturas, 2007)) {
        //    Coberturas_ComportamientoDependencia('#sADomocristalmarmolgranito', false);
        //}
        //else {
        //    Coberturas_ComportamientoDependencia('#sADomocristalmarmolgranito', true);
        //    app.ui.SetNumericValue('#sADomocristalmarmolgranito', 0);
        //}

        //if (Coberturas_Seleccionada(coberturas, 2017)) {
        //    Coberturas_ComportamientoDependencia('#sAGastosalquiler', false);
        //}
        //else {
        //    Coberturas_ComportamientoDependencia('#sAGastosalquiler', true);
        //    app.ui.SetNumericValue('#sAGastosalquiler', 0);
        //}

        //if (Coberturas_Seleccionada(coberturas, 2018)) {
        //    Coberturas_ComportamientoDependencia('#sAPerdidaderentas', false);
        //    Coberturas_ComportamientoDependencia('#mesesaampararporperdrentas', false);
        //}
        //else {
        //    Coberturas_ComportamientoDependencia('#sAPerdidaderentas', true);
        //    Coberturas_ComportamientoDependencia('#mesesaampararporperdrentas', true);
        //    app.ui.SetNumericValue('#sAPerdidaderentas', 0);
        //    app.ui.SetNumericValue('#mesesaampararporperdrentas', 0);
        //}

        //if (Coberturas_Seleccionada(coberturas, 2034)) {
        //    Coberturas_ComportamientoDependencia('#sARespcivil', false);
        //}
        //else {
        //    Coberturas_ComportamientoDependencia('#sARespcivil', true);
        //    $('#sARespcivil').val(-1);
        //}
        data_changed();
    };

    return {
        Init: function () {
            Controls_setup();
            Setup_Validations();
            coberturas_table_setup();
            plandepago_table_setup();
            plandepagoporfrecuencia_table_setup();

            Controls_Events();
            Setup();
        }
    };
})();