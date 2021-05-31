var app = app || {};

app.HogarTotal = (function () {

    var setupData = null;
    var quoteData = null;
    var showCalculate = false;

    function Setup() {
        $('#coberturasTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/Quote/HogarTotalSetup')
            .done(function (data, textStatus, jqXHR) {
                Init_Lookups(data);
            });
    };

    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Quote/HogarTotalQuote',
            JSON.stringify(MapInputToObject()),
            function (data) {
                quoteData = data;
                if (!app.ui.NotifyErrors(data.Mensaje, data.Errors, '#VisualizationsEdtForm')) {
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
                        $('#recardoporfraccionamiento').html(data.resumen.recardoporfraccionamiento.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
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
            'MonedasPorRamo.moneda',
            'FrecuenciaDePagoPorRamo.fraccionamientodepago',
            'Paises.pais',
            'Provincias.provincia',
            'Cantones.canton',
            'Distritos.distrito',
            'TiposOcupacion.ocupaciondelriesgo',
            'TiposSuscripcion.tipodesuscripcion',
            'NumeroPisos.numerodepisosedificacion',
            'TipoEstructura.tipodeestrucdelaedificacion',
            'MedidasSeguridad.medidasdeseguridad',
            'DescuentoHogarTotal.descuento',
            'SumasAseguradasRC.sARespcivil'],
            function () {
                MapObjectToInput(data);
            }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.moneda}:cod_pais=${data.pais}:cod_tip_ocup=${data.cod_ramo}%:cod_estado=${data.provincia}:cod_prov=${data.canton}`);

        // Dependencies events
        $('#provincia').on('change', function () {
            var pais = $('select#pais').val();
            app.core.LookupDependency($('select#provincia').val(), 'canton', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
        });
        $('#canton').on('change', function () {
            var pais = $('select#pais').val();
            app.core.LookupDependency($('select#canton').val(), 'distrito', 'Distritos', '', null, false, null, `cod_pais=${pais}:cod_prov=`);
        });
        $('#moneda').on('change', function () {
            app.core.LookupDependency($('select#moneda').val(), 'sARespcivil', 'SumasAseguradasRC', '', null, false, null, `cod_ramo=${setupData.cod_ramo}:cod_mon=`);
        });
    };

    function MapInputToObject() {
        var data = {
            cod_ramo: setupData.cod_ramo,
            moneda: app.ui.GetDropDownNumericValue('#moneda'),
            fraccionamientodepago: app.ui.GetDropDownNumericValue('#fraccionamientodepago'),
            iniciodevigencia: app.ui.GetDateValue('#iniciodevigencia'),
            findevigencia: app.ui.GetDateValue('#findevigencia'),
            pais: app.ui.GetDropDownStringValue('#pais'),
            provincia: app.ui.GetDropDownNumericValue('#provincia'),
            canton: app.ui.GetDropDownNumericValue('#canton'),
            distrito: app.ui.GetDropDownNumericValue('#distrito'),
            ocupaciondelriesgo: app.ui.GetDropDownNumericValue('#ocupaciondelriesgo'),
            tipodesuscripcion: app.ui.GetDropDownNumericValue('#tipodesuscripcion'),
            numerodepisosedificacion: app.ui.GetDropDownNumericValue('#numerodepisosedificacion'),
            tipodeestrucdelaedificacion: app.ui.GetDropDownNumericValue('#tipodeestrucdelaedificacion'),
            mesesaampararporperdrentas: app.ui.GetNumericValue('#mesesaampararporperdrentas'),
            medidasdeseguridad: app.ui.GetDropDownMultiStringValues('#medidasdeseguridad'),
            descuento: app.ui.GetDropDownNumericValue('#descuento'),
            sAEdificio: app.ui.GetNumericValue('#sAEdificio'),
            sAObjetosvaliosos: app.ui.GetNumericValue('#sAObjetosvaliosos'),
            sADomocristalmarmolgranito: app.ui.GetNumericValue('#sADomocristalmarmolgranito'),
            sAGastosalquiler: app.ui.GetNumericValue('#sAGastosalquiler'),
            sAPerdidaderentas: app.ui.GetNumericValue('#sAPerdidaderentas'),
            sARespcivil: app.ui.GetDropDownNumericValue('#sARespcivil'),
            sAMobiliario: app.ui.GetNumericValue('#sAMobiliario'),
            coberturas: $('#coberturasTbl').bootstrapTable('getData'),
            plandepago: $('#plandepagoTbl').bootstrapTable('getData'),
        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#moneda').val(data.moneda);
        $('#fraccionamientodepago').val(data.fraccionamientodepago);
        app.ui.SetDateValue('#iniciodevigencia', data.iniciodevigencia);
        $('#findevigencia_group').data("DateTimePicker").minDate($('#iniciodevigencia_group').data("DateTimePicker").date());
        app.ui.SetDateValue('#findevigencia', data.findevigencia);
        $('#pais').val(data.pais);
        $('#provincia').val(data.provincia);
        $('#canton').val(data.canton);
        $('#distrito').val(data.distrito);
        $('#ocupaciondelriesgo').val(data.ocupaciondelriesgo);
        $('#tipodesuscripcion').val(data.tipodesuscripcion);
        $('#numerodepisosedificacion').val(data.numerodepisosedificacion);
        $('#tipodeestrucdelaedificacion').val(data.tipodeestrucdelaedificacion);
        app.ui.SetNumericValue('#mesesaampararporperdrentas', data.mesesaampararporperdrentas);
        $('#medidasdeseguridad').val(data.medidasdeseguridad);
        $('#descuento').val(data.descuento);
        app.ui.SetNumericValue('#sAEdificio', data.sAEdificio);
        app.ui.SetNumericValue('#sAObjetosvaliosos', data.sAObjetosvaliosos);
        app.ui.SetNumericValue('#sADomocristalmarmolgranito', data.sADomocristalmarmolgranito);
        app.ui.SetNumericValue('#sAGastosalquiler', data.sAGastosalquiler);
        app.ui.SetNumericValue('#sAPerdidaderentas', data.sAPerdidaderentas);
        $('#sARespcivil').val(data.sARespcivil);
        app.ui.SetNumericValue('#sAMobiliario', data.sAMobiliario);
        if (data.coberturas != null)
            $('#coberturasTbl').bootstrapTable('load', data.coberturas);
        else
            $('#coberturasTbl').bootstrapTable('load', {});
        $('#coberturasTbl').bootstrapTable('hideLoading');
        if (data.plandepago != null)
            $('#plandepagoTbl').bootstrapTable('load', data.plandepago);
        else
            $('#plandepagoTbl').bootstrapTable('load', {});

        Coberturas_ManejoDeCapital();
    };

    function Controls_setup() {
        $('#iniciodevigencia_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#findevigencia_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#mesesaampararporperdrentas', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '12',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#sAEdificio', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#sAObjetosvaliosos', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#sADomocristalmarmolgranito', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#sAGastosalquiler', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#sAPerdidaderentas', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#sAMobiliario', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });

        $('#medidasdeseguridad').select2({ width: '100%', theme: 'bootstrap4' });

        $("#cotizar").appendTo("#GenericToolBar");
        $("#limpiar").appendTo("#GenericToolBar");
    };

    function Controls_Events() {

        $("#VisualizationsEdtForm :input").change(function () {
            data_changed();
        });

        $('#iniciodevigencia').blur(function () {
            var minDate = app.ui.GetDateRawValue('#iniciodevigencia');
            minDate.setDate(minDate.getDate() + 1);

            $('#findevigencia_group').data("DateTimePicker").minDate(minDate);
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
            quoteData.Agente = setupData.Agente;
            app.Cotizacion.Imprimir('HogarTotal', quoteData);
        });

        $('#emitir').click(function () {
            event.preventDefault();
            window.location.replace(app.setting.basepath + 'emision/hogartotal?presupuesto=' + quoteData.presupuesto);
        });

    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();

        $.validator.addMethod("Complement",
            function (value, element, params) {
                return !(app.ui.GetNumericValue('#sAObjetosvaliosos') === 0 &&
                    app.ui.GetNumericValue('#sAMobiliario') === 0);
            }
        );

        $("#VisualizationsEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                mesesaampararporperdrentas: { required: true, Numeric: true, min: 1, max: 12 },
                sAEdificio: { required: false, Numeric: true },
                sAObjetosvaliosos: { required: false, Numeric: false, Complement: true },
                sAMobiliario: { required: true, Numeric: false, Complement: true },
                sADomocristalmarmolgranito: { required: true, Numeric: true },
                sAGastosalquiler: { required: true, Numeric: true },
                sAPerdidaderentas: { required: true, Numeric: true },
                sARespcivil: { required: true, Numeric: true },
            },
            messages: {
                mesesaampararporperdrentas: { required: 'Debe indicar la cantidad de meses a amparar', Numeric: 'Debe indicar la cantidad de meses a amparar', min: 'Debe indicar indicar un valor entre 1 y 12', max: 'Debe indicar indicar un valor entre 1 y 12' },
                sAEdificio: { required: 'Debe indicar la suma asegurada del edificio', Numeric: 'Debe indicar la suma asegurada del edificio' },
                sAObjetosvaliosos: { required: 'Debe indicar la suma asegurada para objetos valiosos', Numeric: 'Debe indicar la suma asegurada para objetos valiosos', Complement: 'Debe indicar la suma asegurada para los objects valiosos y/o del mobiliario' },
                sAMobiliario: { required: 'Debe indicar la suma asegurada del mobiliario', Numeric: 'Debe indicar la suma asegurada del mobiliario', Complement: 'Debe indicar la suma asegurada del mobiliario y/o para los objects valiosos' },
                sADomocristalmarmolgranito: { required: 'Debe indicar la suma asegurada para domo, cristal, mármol, granito', Numeric: 'Debe indicar la suma asegurada para domo, cristal, mármol, granito' },
                sAGastosalquiler: { required: 'Debe indicar la suma asegurada para gastos de alquiler', Numeric: 'Debe indicar la suma asegurada para gastos de alquiler' },
                sAPerdidaderentas: { required: 'Debe indicar la suma asegurada para pérdida de rentas', Numeric: 'Debe indicar la suma asegurada para pérdida de rentas' },
                sARespcivil: { required: 'Debe indicar la suma asegurada para responsabilidad civil', Numeric: 'Debe indicar la suma asegurada para responsabilidad civil' },
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
            showFooter: false,
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
                    footerFormatter: function (rows, value) {
                        var field = this.field
                        return app.ui.DecimalWithZeroFormatter(rows.reduce(function (acc, row) { return acc + row[field]; }, 0));
                    },
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
                }, {
                    field: 'error',
                    title: 'Error',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }]
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
                    field: 'recardoporfraccionamiento',
                    title: 'Recardo por fraccionamiento',
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
                }]
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
                    field: 'recardoporfraccionamiento',
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
            $('#coberturasTbl').bootstrapTable('load', coberturas);
            $('#plandepagoTbl').bootstrapTable('load', {});
            showCalculate = false;
        }
        if (!$('#coberturasTbl-validate').hasClass("d-none")) {
            $('#coberturasTbl-validate').text('');
            $('#coberturasTbl-validate').addClass('d-none');
        }
    };

    function Coberturas_Seleccionada(lista, codigo) {
        var result = false;
        for (var i = 0; i < lista.length; i++) {
            if (lista[i].codigo == codigo) {
                result = lista[i].seleccionado;
                break;
            }
        }
        return result;
    }

    function Coberturas_ComportamientoDependencia(element, disabled) {
        $(element).prop("disabled", disabled);
        if (disabled) {
            $(element + '-error').html('');
            $(element).removeClass('error');
        }
    };

    function Coberturas_ManejoDeCapital() {
        var coberturas = $('#coberturasTbl').bootstrapTable('getData');

        if (Coberturas_Seleccionada(coberturas, 2002) || Coberturas_Seleccionada(coberturas, 2024) || Coberturas_Seleccionada(coberturas, 2025) || Coberturas_Seleccionada(coberturas, 2026) || Coberturas_Seleccionada(coberturas, 2004)) {
            Coberturas_ComportamientoDependencia('#sAEdificio', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#sAEdificio', true);
            app.ui.SetNumericValue('#sAEdificio', 0);
        }

        if (Coberturas_Seleccionada(coberturas, 2010) || Coberturas_Seleccionada(coberturas, 2055) || Coberturas_Seleccionada(coberturas, 2056) || Coberturas_Seleccionada(coberturas, 2057) || Coberturas_Seleccionada(coberturas, 2012) || Coberturas_Seleccionada(coberturas, 2014)) {
            Coberturas_ComportamientoDependencia('#sAObjetosvaliosos', false);
            Coberturas_ComportamientoDependencia('#sAMobiliario', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#sAObjetosvaliosos', true);
            Coberturas_ComportamientoDependencia('#sAMobiliario', true);
            app.ui.SetNumericValue('#sAObjetosvaliosos', 0);
            app.ui.SetNumericValue('#sAMobiliario', 0);
        }

        if (Coberturas_Seleccionada(coberturas, 2007)) {
            Coberturas_ComportamientoDependencia('#sADomocristalmarmolgranito', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#sADomocristalmarmolgranito', true);
            app.ui.SetNumericValue('#sADomocristalmarmolgranito', 0);
        }

        if (Coberturas_Seleccionada(coberturas, 2017)) {
            Coberturas_ComportamientoDependencia('#sAGastosalquiler', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#sAGastosalquiler', true);
            app.ui.SetNumericValue('#sAGastosalquiler', 0);
        }

        if (Coberturas_Seleccionada(coberturas, 2018)) {
            Coberturas_ComportamientoDependencia('#sAPerdidaderentas', false);
            Coberturas_ComportamientoDependencia('#mesesaampararporperdrentas', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#sAPerdidaderentas', true);
            Coberturas_ComportamientoDependencia('#mesesaampararporperdrentas', true);
            app.ui.SetNumericValue('#sAPerdidaderentas', 0);
            app.ui.SetNumericValue('#mesesaampararporperdrentas', 0);
        }

        if (Coberturas_Seleccionada(coberturas, 2034)) {
            Coberturas_ComportamientoDependencia('#sARespcivil', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#sARespcivil', true);
            $('#sARespcivil').val(-1);
        }
        data_changed();
    };

    return {
        Init: function () {
            Controls_setup();
            Setup_Validations();

            coberturas_table_setup();
            plandepago_table_setup();
            plandepagoporfrecuencia_table_setup()

            Controls_Events();

            Setup();
        }
    };
})();