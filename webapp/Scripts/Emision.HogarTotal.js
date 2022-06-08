var app = app || {};

app.HogarTotal = (function () {

    var setupData = null;
    var showCalculate = false;
    var rowDocumentosrequeridos = null;

    function Setup() {
        var _id = app.core.URLStringValue('presupuesto');
        if (_id != '') {
            $('#coberturasTbl').bootstrapTable('showLoading');
            app.core.Get(app.setting.apipath + 'v1/Issue/HogarTotalSetup/' + _id)
                .done(function (data) {
                    Init_Lookups(data);
                });
        }
    };

    function ReadOnly() {

        $('#moneda').replaceWith("<div>" + $('#moneda option:selected').text() + "</div>");
        $('#fraccionamientodepago').replaceWith("<div>" + $('#fraccionamientodepago option:selected').text() + "</div>");
        $('#iniciodevigencia_group').replaceWith("<div>" + $('#iniciodevigencia').val() + "</div>");
        $('#findevigencia_group').replaceWith("<div>" + $('#findevigencia').val() + "</div>");

        $('#pais').replaceWith("<div>" + $('#pais option:selected').text() + "</div>");
        $('#provincia').replaceWith("<div>" + $('#provincia option:selected').text() + "</div>");
        $('#canton').replaceWith("<div>" + $('#canton option:selected').text() + "</div>");
        $('#distrito').replaceWith("<div>" + $('#distrito option:selected').text() + "</div>");
        $('#ocupaciondelriesgo').replaceWith("<div>" + $('#ocupaciondelriesgo option:selected').text() + "</div>");
        $('#tipodesuscripcion').replaceWith("<div>" + $('#tipodesuscripcion option:selected').text() + "</div>");
        $('#numerodepisosedificacion').replaceWith("<div>" + $('#numerodepisosedificacion option:selected').text() + "</div>");
        $('#tipodeestrucdelaedificacion').replaceWith("<div>" + $('#tipodeestrucdelaedificacion option:selected').text() + "</div>");
        $('#mesesaampararporperdrentas').replaceWith("<div>" + $('#mesesaampararporperdrentas').val() + "</div>");
        $('#medidasdeseguridad').next().replaceWith("<div>" + $('#medidasdeseguridad option:selected').text() + "</div>");
        $('#descuento').replaceWith("<div>" + $('#descuento option:selected').text() + "</div>");

        $('#sAEdificio').replaceWith("<div>" + $('#sAEdificio').val() + "</div>");
        $('#sAObjetosvaliosos').replaceWith("<div>" + $('#sAObjetosvaliosos').val() + "</div>");
        $('#sADomocristalmarmolgranito').replaceWith("<div>" + $('#sADomocristalmarmolgranito').val() + "</div>");
        $('#sAGastosalquiler').replaceWith("<div>" + $('#sAGastosalquiler').val() + "</div>");
        $('#sAPerdidaderentas').replaceWith("<div>" + $('#sAPerdidaderentas').val() + "</div>");
        $('#sARespcivil').replaceWith("<div>" + $('#sARespcivil option:selected').text() + "</div>");
        $('#sAMobiliario').replaceWith("<div>" + $('#sAMobiliario').val() + "</div>");
    };

    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Issue/HogarTotal',
            JSON.stringify(MapInputToObject()),
            function (data) {
                setupData = data;
                if (data.Mensaje != null) {
                    app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                }
                else {
                    $('#coberturasRow').removeClass('d-none');
                    $('#coberturasTbl').bootstrapTable('load', data.coberturas);

                    $('#plandepagoRow').removeClass('d-none');
                    $('#plandepagoTbl').bootstrapTable('load', data.plandepago);


                    $('#NumPoliza').html(data.num_poliza);


                    $('#cotizar').addClass('d-none');
                    $('#tercerosNew').addClass('d-none');

                    $('#tipoplan').replaceWith("<div>" + $('#tipoplan option:selected').text() + "</div>");
                    $('#otrassenas').replaceWith("<div>" + $('#otrassenas').val() + "</div>");
                    $('#numerodefolio').replaceWith("<div>" + $('#numerodefolio').val() + "</div>");
                    $('#numerodefoliomadre').replaceWith("<div>" + $('#numerodefoliomadre').val() + "</div>");
                    $('#anodeconstruccion').replaceWith("<div>" + $('#anodeconstruccion').val() + "</div>");
                    $('#alturaedificio').parent().replaceWith("<div>" + $('#alturaedificio').val() + "</div>");
                    $('#numerometrosconstruidos').parent().replaceWith("<div>" + $('#numerometrosconstruidos').val() + "</div>");
                    $('#numerodepiso').replaceWith("<div>" + $('#numerodepiso').val() + "</div>");

                    $('#tercerosTbl').bootstrapTable('hideColumn', 'Actions');
                    $('#documentosrequeridosTbl').bootstrapTable('hideColumn', 'Actions');

                    $('#mainBlock').removeClass('col-md-12');
                    $('#mainBlock').addClass('col-md-9');
                    $('#quoteBlock').removeClass('d-none');
                    showCalculate = true;
                    if (data.resumen != null) {
                        var moneda = "$ ";
                        if (data.moneda == 1) {
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
            'SumasAseguradasRC.sARespcivil',
            'Paises.cod_pais', 'Provincias.TProvincia', 'Cantones.TCanton', 'Distritos.TDistrito'],
            function () {
                MapObjectToInput(data);
                ReadOnly();
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

        $('#TProvincia').on('change', function () {
            var pais = $('select#cod_pais').val();
            app.core.LookupDependency($('select#TProvincia').val(), 'TCanton', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
        });
        $('#TCanton').on('change', function () {
            var pais = $('select#cod_pais').val();
            app.core.LookupDependency($('select#TCanton').val(), 'TDistrito', 'Distritos', '', null, false, null, `cod_pais=${pais}:cod_prov=`);
        });
        $('#moneda').on('change', function () {
            app.core.LookupDependency($('select#moneda').val(), 'sARespcivil', 'SumasAseguradasRC', '', null, false, null, `cod_ramo=${setupData.cod_ramo}:cod_mon=`);
        });
    };

    function MapInputToObject() {
        var data = setupData;

        data.tipoplan = app.ui.GetDropDownNumericValue('#tipoplan');
        data.otrassenas = $('#otrassenas').val();
        data.numerodefolio = $('#numerodefolio').val();
        data.numerodefoliomadre = $('#numerodefoliomadre').val();
        data.anodeconstruccion = app.ui.GetNumericValue('#anodeconstruccion');
        data.alturaedificio = app.ui.GetNumericValue('#alturaedificio');
        data.numerometrosconstruidos = app.ui.GetNumericValue('#numerometrosconstruidos');
        data.numerodepiso = app.ui.GetNumericValue('#numerodepiso');
        data.terceros = $('#tercerosTbl').bootstrapTable('getData');
        data.documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');
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
        $('#otrassenas').val(data.otrassenas);
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
        if (data.terceros != null)
            $('#tercerosTbl').bootstrapTable('load', data.terceros);
        else
            $('#tercerosTbl').bootstrapTable('load', {});
        if (data.documentosrequeridos != null)
            $('#documentosrequeridosTbl').bootstrapTable('load', data.documentosrequeridos);
        else
            $('#documentosrequeridosTbl').bootstrapTable('load', {});
        if (data.coberturas != null)
            $('#coberturasTbl').bootstrapTable('load', data.coberturas);
        else
            $('#coberturasTbl').bootstrapTable('load', {});
        $('#coberturasTbl').bootstrapTable('hideLoading');
        if (data.plandepago != null)
            $('#plandepagoTbl').bootstrapTable('load', data.plandepago);
        else
            $('#plandepagoTbl').bootstrapTable('load', {});



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

        new AutoNumeric('#porcentajeacredor', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#anodeconstruccion', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '',
            maximumValue: '9999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#alturaedificio', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '9999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#numerometrosconstruidos', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '9999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#numerodepiso', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '9999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });

    };

    function Controls_Events() {

        $("#VisualizationsEdtForm :input").change(function () {
            data_changed();
        });

        $('#iniciodevigencia').blur(function () {
            var minDate = app.ui.GetDateRawValue('#iniciodevigencia');
            minDate.setDate(minDate.getDate() + 1);

            $('#findevigencia_group').data("DateTimePicker").minDate(minDate);

            let fec_vcto = app.ui.GetDateRawValue('#iniciodevigencia');
            fec_vcto.setFullYear(fec_vcto.getFullYear() + 1);
            app.ui.SetDateValue('#findevigencia', fec_vcto);
        });

        $('#cotizar').click(function () {
            var others = OtherValidations();
            if (app.ui.IsValid('#VisualizationsEdtForm', false) && others === 0) {
                app.ui.ButtonDoing('#cotizar');
                Quote();
            }
            else {
                var instance = $('#VisualizationsEdtForm');
                var validate = instance.validate();
                validate.settings.ignore = '';
                var result = instance.valid();
                var count = validate.numberOfInvalids();
                validate.settings.ignore = ':hidden';
                toastr.error("Existen " + (count + others) + " error(es), que ameritan su atención.", "", { closeButton: true, progressBar: true });
            }
            event.preventDefault();
        });

        $('#print').click(function () {
            event.preventDefault();
            app.ui.ShowSideBar({ title: 'Enviar certificado por correo', subtitle: 'Póliza #{NUM_POLIZA}', id: 9000, data: { NUM_POLIZA: setupData.num_poliza, NUM_RIESGO: 1 } })
        });
    };

    function Setup_Validations() {
        app.ui.DateValidators();

        $.validator.addMethod("Complement",
            function (value, element, params) {
                return !(app.ui.GetNumericValue('#sAObjetosvaliosos') === 0 &&
                    app.ui.GetNumericValue('#sAMobiliario') === 0);
            }
        );

        $.validator.addMethod("NumericRequired",
            function (value, element, params) {
                if (this.optional(element))
                    return true;
                else {
                    return (value != "0,00" && value != "0");
                }
            }
        );

        $("#VisualizationsEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                tipoplan: { required: true },
                otrassenas: { required: true },
                numerodefolio: { required: true },
                anodeconstruccion: { required: true },
                numerometrosconstruidos: { required: true },
                numerodepiso: { required: true }
            },
            messages: {
                tipoplan: { required: 'Debe indicar el tipo plan' },
                otrassenas: { required: 'Debe indicar otras señas' },
                numerodefolio: { required: 'Debe indicar el número de folio' },
                anodeconstruccion: { required: 'Debe indicar el año de construcción' },
                numerometrosconstruidos: { required: 'Debe indicar el número metros construidos' },
                numerodepiso: { required: 'Debe indicar el número de piso' }
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
                    field: 'deducible',
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

        $('#coberturasTbl').bootstrapTable('filterBy', { seleccionado: [true] })
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
                coberturas[i].deducible = '';
                coberturas[i].error = '';
            }
            $('#coberturasTbl').bootstrapTable('load', coberturas);
            $('#plandepagoTbl').bootstrapTable('load', {});
            showCalculate = false;
        }
        $('#tercerosTbl-error').addClass('d-none');
        $('#documentosrequeridosTbl-error').addClass('d-none');
    };

    function OtherValidations() {
        var result = 0;
        var grupo = 'F';
        var terceros = $('#tercerosTbl').bootstrapTable('getData');
        var documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');

        if (terceros.length === 0) {
            $('#tercerosTbl-error').removeClass('d-none');
            result = result + 1;
        }

        var lista = documentosrequeridos.filter(function (row) {
            return (row.DStored === null || row.DStored === '');
        });
        if (lista.length > 0) {
            $('#documentosrequeridosTbl-error').removeClass('d-none');
            result = result + 1;
        }

        return result;
    };


    function terceros_table_setup() {

        $('#tercerosTbl').bootstrapTable({
            uniqueId: 'tercerosId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'tipodeterceroDesc',
                    title: 'Tipo de tercero',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'DocumentNumber',
                    title: 'Identificación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
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
                    field: 'apellido1',
                    title: 'Apellido',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'apellido2',
                    title: 'Apellido 2',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'fechadenacimiento',
                    title: 'Nacimiento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'tercerosMca_sexoDesc',
                    title: 'Sexo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'estadoCivilDesc',
                    title: 'Estado Civil',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'numerodetelefono',
                    title: 'Teléfono',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'correoelectronico',
                    title: 'Correo electrónico',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'cod_pais',
                    title: 'País',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'TProvinciaDesc',
                    title: 'Provincia',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'TCantonDesc',
                    title: 'Cantón',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'TDistritoDesc',
                    title: 'Distrito',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'otrasenas',
                    title: 'Otra señas',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'numerodeprestamo',
                    title: 'El tomador es el mismo asegurado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'numerodeprestamo',
                    title: 'Número de prestamo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'importedecesion',
                    title: 'Importe de cesión',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: false
                }, {
                    field: 'vencimientodecesion',
                    title: 'Vencimiento de cesión',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: false
                }, {
                    field: 'porcentajeacredor',
                    title: 'Porcentaje acredor',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                }, {
                    field: 'Actions',
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un visualizations',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    visible: true,
                    events: 'tercerosTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del tercero de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del tercero de la fila"> <i class="fa fa-close"></i> </button>';
                    },
                    cellStyle: function (value, row, index) {
                        return {
                            css: {
                                'white-space': 'nowrap',
                                'vertical-align': 'top'
                            }
                        }
                    }
                }]
        });

        $('#tercerosNew').click(function () {
            terceros_table_row_edit();
        });

        $('#tercerosEdtFormSave').click(function () {
            if (app.ui.IsValid('#tercerosEdtForm', false)) {
                app.ui.ButtonDoing('#tercerosEdtFormSave');

                var row = terceros_table_row('values');

                if (row.tercerosId === null)
                    row.tercerosId = 1;

                if ($('#tercerosModal').data('id') != null) {
                    $('#tercerosTbl').bootstrapTable('updateByUniqueId', { id: row.tercerosId, row: row });
                }
                else {
                    $('#tercerosTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#tercerosEdtFormSave')
                $('#tercerosModal').modal('hide');
            }
        });

    };

    function terceros_table_row(mode) {
        if (mode == null) {
            return {
                tercerosId: null,
                tipodetercero: 0,
                DocumentNumberType: null,
                DocumentNumber: null,
                nombre: null,
                apellido1: null,
                apellido2: null,
                fechadenacimiento: null,
                tercerosMca_sexo: null,
                estadoCivil: null,
                numerodetelefono: null,
                correoelectronico: null,
                cod_pais: 'CRI',
                TProvincia: null,
                TCanton: null,
                TDistrito: null,
                otrasenas: null,
                eltomadoreselmismoasegurado: null,
                numerodeprestamo: null,
                importedecesion: null,
                vencimientodecesion: null,
                porcentajeacredor: null
            };
        }
        else {
            return {
                tercerosId: $('#tercerosModal').data('id'),
                tipodetercero: $('#tipodetercero').val(),
                tipodeterceroDesc: $('#tipodetercero option:selected').text(),
                DocumentNumberType: $("#DocumentNumberType").data("value"),
                DocumentNumber: $('#DocumentNumber').val(),
                nombre: $('#nombre').val(),
                apellido1: $('#apellido1').val(),
                apellido2: $('#apellido2').val(),
                fechadenacimiento: app.ui.GetDateValue('#fechadenacimiento'),
                tercerosMca_sexo: $('#tercerosMca_sexo').val(),
                tercerosMca_sexoDesc: $('#tercerosMca_sexo option:selected').text(),
                estadoCivil: $('#estadoCivil').val(),
                estadoCivilDesc: $('#estadoCivil option:selected').text(),
                numerodetelefono: $('#numerodetelefono').val(),
                correoelectronico: $('#correoelectronico').val(),
                cod_pais: $('#cod_pais').val(),
                TProvincia: $('#TProvincia').val(),
                TProvinciaDesc: $('#TProvincia option:selected').text(),
                TCanton: $('#TCanton').val(),
                TCantonDesc: $('#TCanton option:selected').text(),
                TDistrito: $('#TDistrito').val(),
                TDistritoDesc: $('#TDistrito option:selected').text(),
                otrasenas: $('#otrasenas').val(),
                eltomadoreselmismoasegurado: app.ui.GetRadioNumericValue('eltomadoreselmismoasegurado'),
                numerodeprestamo: $('#numerodeprestamo').val(),
                importedecesion: app.ui.GetNumericValue('#importedecesion'),
                vencimientodecesion: app.ui.GetDateValue('#vencimientodecesion'),
                porcentajeacredor: app.ui.GetNumericValue('#porcentajeacredor')
            };
        }
    };

    function terceros_table_row_edit(row) {
        var md = $('#tercerosModal').modal({ show: false });
        var formInstance = $("#tercerosEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || terceros_table_row();
        md.data('id', row.tercerosId);

        $('#tipodetercero').val(row.tipodetercero);
        app.ui.SetDocumentTypeValue('#DocumentNumberType', row.DocumentNumberType);
        $('#DocumentNumber').val(row.DocumentNumber);
        $('#nombre').val(row.nombre);
        $('#apellido1').val(row.apellido1);
        $('#apellido2').val(row.apellido2);
        app.ui.SetDateValue('#fechadenacimiento', row.fechadenacimiento);
        $('#tercerosMca_sexo').val(row.tercerosMca_sexo);
        $('#estadoCivil').val(row.estadoCivil);
        $('#numerodetelefono').val(row.numerodetelefono);
        $('#correoelectronico').val(row.correoelectronico);
        $('#cod_pais').val(row.cod_pais);
        $('#TProvincia').val(row.TProvincia);
        $('#TCanton').val(row.TCanton);
        $('#TDistrito').val(row.TDistrito);
        $('#otrasenas').val(row.otrasenas);
        app.ui.SetRadioNumericValue('eltomadoreselmismoasegurado', row.eltomadoreselmismoasegurado)
        $('#numerodeprestamo').val(row.numerodeprestamo);
        app.ui.SetNumericValue('#importedecesion', row.importedecesion);
        app.ui.SetDateValue('#vencimientodecesion', row.vencimientodecesion);
        app.ui.SetNumericValue('#porcentajeacredor', row.porcentajeacredor);


        md.modal('show');
    };

    function terceros_table_row_delete(row) {
        $('#tercerosTbl').bootstrapTable('removeByUniqueId', row.tercerosId);
    };

    function terceros_table_Validations() {
        app.ui.DateValidators();
        $("#tercerosEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                tipodetercero: { required: true },
                DocumentNumber: { required: true },
                nombre: { required: true },
                apellido1: { required: true },
                apellido2: { required: true },
                fechadenacimiento: { required: true },
                tercerosMca_sexo: { required: true },
                estadoCivil: { required: true },
                numerodetelefono: { required: true },
                correoelectronico: { email: true, required: true },
                cod_pais: { required: true },
                TProvincia: { required: true },
                TCanton: { required: true },
                TDistrito: { required: true },
                otrasenas: { required: true },
                vencimientodecesion: { required: true },
            },
            messages: {
                tipodetercero: { required: 'Debe indicar el Tipo de tercero' },
                DocumentNumber: { required: 'Debe indicar el Identificación' },
                nombre: { required: 'Debe indicar el Nombre' },
                apellido1: { required: 'Debe indicar el Apellido 1' },
                apellido2: { required: 'Debe indicar el Apellido 2' },
                fechadenacimiento: { required: 'Debe indicar el Fecha de nacimiento' },
                tercerosMca_sexo: { required: 'Debe indicar el Sexo' },
                estadoCivil: { required: 'Debe indicar el Estado Civil' },
                numerodetelefono: { required: 'Debe indicar el Número de teléfono' },
                correoelectronico: { email: 'Debe indicar un correo electrónico valido', required: 'Debe indicar el correo electrónico' },
                cod_pais: { required: 'Debe indicar el País' },
                TProvincia: { required: 'Debe indicar el Provincia' },
                TCanton: { required: 'Debe indicar el Cantón' },
                TDistrito: { required: 'Debe indicar el Distrito' },
                otrasenas: { required: 'Debe indicar el Otra señas' },
                vencimientodecesion: { required: 'Debe indicar el Vencimiento de cesión' },
            }
        });
    };

    function terceros_controls_setup() {
        $('#DocumentNumber').formatter({
            pattern: '0{{9}}-{{9999}}-{{9999}}',
            persistent: false
        });
        $('#fechadenacimiento_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#numerodetelefono').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        new AutoNumeric('#importedecesion', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#vencimientodecesion_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#porcentajeacredor', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });

    };

    function terceros_documentNumberCallBack(data) {
        if (data != null) {
            $('#nombre').val((data.FirstName + ' ' + data.MiddleName).trim());
            $('#apellido1').val(data.LastName);
            $('#apellido2').val(data.SecondLastName);
            $('#PhoneNumber').val(data.PhoneNumber);
            app.ui.SetDateValue('#fechadenacimiento', data.BirthDate);
            $('#tercerosMca_sexo').val(data.Gender);
            $('#TProvincia').val(data.Province);
            $('#correoelectronico').val(data.PrimaryEmailAddress);
            $('#numerodetelefono').val(data.PhoneNumber);



            //function LookupDependency(parentValue, childId, lookupKey, emptyValue, newValue, triggerChange, callback, url) {

            app.core.LookupDependency(data.Province, 'TCanton', 'Cantones', '', data.Canton, false, null, 'cod_pais=CRI:cod_estado=');
            app.core.LookupDependency(data.Canton, 'TDistrito', 'Distritos', '', data.District, false, null, 'cod_pais=CRI:cod_prov=');

            //$('#TCanton').val(data.Canton);
            //$('#TDistrito').val(data.District);
            $('#otrasenas').val(data.AddressDetail);





        }
    }

    function terceros_controls_Events() {
        app.ui.DocumentNumberHandler('#DocumentNumber', terceros_documentNumberCallBack);

        $('#tipodetercero').change(function () {
            switch ($('#tipodetercero').val()) {
                case '0':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().removeClass('d-none');
                    $('#acredorZone').addClass('d-none');
                    break;
                case '2':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().addClass('d-none');
                    $('#acredorZone').addClass('d-none');
                    break;
                case '8':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().addClass('d-none');
                    $('#acredorZone').removeClass('d-none');
                    break;

            }

        });

    };


    function documentosrequeridos_table_setup() {

        $('#documentosrequeridosTbl').bootstrapTable({
            uniqueId: 'documentosrequeridosId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'DStored',
                    title: 'Estado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: function (value, row, index, field) {

                        if (row.DStored === null || row.DStored === '') {
                            return '<span class="label label-danger">Pendiente</span>';
                        }
                        else {
                            return '<span class="label label-success">Listo</span>';
                        }

                    },
                    visible: true,
                    width: 10,
                    widthUnit: '%'
                }, {
                    field: 'tipo',
                    title: 'Tipo de documento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: function (value, row, index, field) {
                        if (row.tipo == 'Genérico') {
                            return '<span><i class="fa fa-paperclip"></i> ' + row.DDescripcion + ' (' + value + ')</span>';
                        }
                        else {
                            return '<span><i class="fa fa-paperclip"></i> ' + value + '</span>';
                        }
                    },
                    visible: true,
                    width: 40,
                    widthUnit: '%'
                }, {
                    field: 'DNombre',
                    title: 'Archivo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true,
                    width: 20,
                    widthUnit: '%'
                }, {
                    field: 'DArchivoEsperado',
                    title: 'Archivoeseperado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'Grupo',
                    title: 'Grupo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'DFecha',
                    title: 'Fecha',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateAndTimeFormatter',
                    visible: true,
                    width: 20,
                    widthUnit: '%'
                }, {
                    field: 'DTamano',
                    title: 'Tamaño',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: function (value, row, index, field) {
                        if (value === null || value === 0)
                            return '';
                        else
                            return parseInt(value / 1024) + 'kb';
                    },
                    visible: true,
                    width: 10,
                    widthUnit: '%'
                }, {
                    field: 'Actions',
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un visualizations',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    visible: true,
                    events: 'documentosrequeridosTbl_Events',
                    formatter: function (value, row, index, field) {
                        var html = [];
                        if (row.tipo == 'Genérico') {
                            html.push('<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del documento"> <i class="fa fa-pencil"></i> </button>');
                            html.push('<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar el documento"> <i class="fa fa-eraser"></i> </button>');
                        } else {
                            html.push('<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la carga del documento requerido"> <i class="fa fa-upload"></i> </button>');
                            html.push('<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar el documento agregado de la fila"> <i class="fa fa-recycle"></i> </button>');
                        }
                        return html.join('');
                    },
                    cellStyle: function (value, row, index) {
                        return {
                            css: {
                                'white-space': 'nowrap',
                                'vertical-align': 'top'
                            }
                        }
                    }
                }]
        });

        $('#documentosrequeridosNew').click(function () {
            documentosrequeridos_table_row_edit(null);
        });

        $('#documentosrequeridosEdtFormSave').click(function () {
            if (app.ui.IsValid('#documentosrequeridosEdtForm', false)) {
                app.ui.ButtonDoing('#documentosrequeridosEdtFormSave');

                var row = documentosrequeridos_table_row('values');

                if (row.documentosrequeridosId === null) {
                    row.documentosrequeridosId = 100 + Math.max.apply(Math, $('#documentosrequeridosTbl').bootstrapTable('getData').map(function (o) { return o.documentosrequeridosId == 10 ? o.documentosrequeridosId : null; }));
                }
                if ($('#documentosrequeridosModal').data('id') != null) {
                    $('#documentosrequeridosTbl').bootstrapTable('updateByUniqueId', { id: row.documentosrequeridosId, row: row });
                }
                else {
                    $('#documentosrequeridosTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#documentosrequeridosEdtFormSave')
                $('#documentosrequeridosModal').modal('hide');
            }
        });

        $('#documentosrequeridosTbl').bootstrapTable('filterBy', { Grupo: ['F'] })
    };

    function documentosrequeridos_table_row(mode) {
        if (mode == null) {
            return {
                documentosrequeridosId: null,
                DStored: null,
                tipo: 'Genérico',
                DNombre: null,
                DArchivoEsperado: null,
                Grupo: 'F',
                DFecha: null,
                DTamano: null,
                DDescripcion: null
            };
        }
        else {
            return {
                documentosrequeridosId: $('#documentosrequeridosModal').data('id'),
                DStored: $('#DStored').val(),
                tipo: $('#tipo option:selected').text(),
                DNombre: $('#DNombre').val(),
                DArchivoEsperado: $('#DArchivoEsperado').val(),
                Grupo: $('#Grupo').val(),
                DFecha: new Date(),
                DTamano: $('#DTamano').val(),
                DDescripcion: $('#DDescripcion').val()
            };
        }
    };

    function documentosrequeridos_table_row_edit(row) {
        if (row != null && row.tipo != 'Genérico') {
            rowDocumentosrequeridos = row;
            $('#fileUpload').click();
        }
        else {
            var md = $('#documentosrequeridosModal').modal({ show: false });
            var formInstance = $("#documentosrequeridosEdtForm");
            var fvalidate = formInstance.validate();
            fvalidate.resetForm();
            row = row || documentosrequeridos_table_row();
            md.data('id', row.documentosrequeridosId);

            $('#DDescripcion').val(row.DDescripcion);
            $('#DTamano').val(row.DTamano);
            $('#DFecha').val(row.DFecha);
            $('#Grupo').val(row.Grupo);
            $('#DNombre').val(row.DNombre);

            md.modal('show');
        }
    };

    function documentosrequeridos_table_row_delete(row) {
        if (row.tipo != 'Genérico') {
            row.DNombre = '';
            row.DStored = '';
            row.DTamano = 0;
            row.DFecha = null;
            $('#documentosrequeridosTbl').bootstrapTable('updateByUniqueId', { id: row.documentosrequeridosId, row: row });
        }
        else {
            $('#documentosrequeridosTbl').bootstrapTable('removeByUniqueId', row.documentosrequeridosId);
        }
    };

    function documentosrequeridos_table_Validations() {
        app.ui.DateValidators();
        $("#documentosrequeridosEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                DDescripcion: {
                    required: true
                },
                tipo: {
                    required: true
                },
                FileName: {
                    required: true
                }
            },
            messages: {
                DDescripcion: {
                    required: 'Debe indicar una descripción del archivo'
                },
                tipo: {
                    required: 'Debe indicar el tipo de documento'
                },
                FileName: {
                    required: 'Debe indicar un archivo'
                }
            }
        });
    };

    function documentosrequeridos_controls_setup() {
    };

    function documentosrequeridos_controls_Events() {

        $('#fileUploadModal').on('change', function () {
            var index = 0;
            var arr = $('#fileUploadModal').prop('files');
            var message = '';

            for (index = 0; index < arr.length; index++) {
                if (arr[index].size >= 31457280) {
                    if (message != '') {
                        message = message & ', ';
                    }
                    message = message & 'El tamaño del archivo ' + arr[index].name + 'es mayor a 30mb';
                }
            }
            if (message != '') {
                elementInstance.showErrors({ 'FileName': message });
            }
            else {
                app.ui.ButtonDoing('#fileUploadModal');
                var data = new FormData();
                data.append('EntityType', 3000);
                data.append('EntityId', setupData.presupuesto);
                data.append('DocumentType', 99);
                data.append('Description', arr[0]);
                for (index = 0; index < arr.length; index++) {
                    data.append('files', arr[index]);
                }
                $.ajax({
                    type: "POST",
                    enctype: 'multipart/form-data',
                    url: app.setting.apipath + 'v1/Common/Upload',
                    data: data,
                    processData: false,
                    contentType: false,
                    cache: false,
                    timeout: 600000,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('Token'));
                    }
                }).done(function (data, textStatus, jqXHR) {

                    $('#DNombre').val(data[0].FileName);
                    $('#DStored').val(data[0].StoredFileName);
                    $('#DTamano').val(data[0].Size);
                    $('#DDescripcion').val(app.ui.StringCapitalizeFormatter(data[0].FileName.substring(0, data[0].FileName.indexOf('.'))));
                    $('#DDescripcion').select().focus()
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    console.log("ERROR : ", jqXHR);
                }).always(function () {
                    app.ui.ButtonDone('#fileUploadModal')
                });
            }
        });

        $('#fileUpload').on('change', function () {
            var index = 0;
            var arr = $('#fileUpload').prop('files');
            var message = '';

            for (index = 0; index < arr.length; index++) {
                if (arr[index].size >= 31457280) {
                    if (message != '') {
                        message = message & ', ';
                    }
                    message = message & 'El tamaño del archivo ' + arr[index].name + 'es mayor a 30mb';
                }
            }
            if (message != '') {
                elementInstance.showErrors({ 'FileName': message });
            }
            else {
                app.ui.ButtonDoing('#fileUpload');
                var data = new FormData();
                data.append('EntityType', 3000);
                data.append('EntityId', setupData.presupuesto);
                data.append('DocumentType', rowDocumentosrequeridos.documentosrequeridosId);
                data.append('Description', rowDocumentosrequeridos.tipo);
                for (index = 0; index < arr.length; index++) {
                    data.append('files', arr[index]);
                }
                $.ajax({
                    type: "POST",
                    enctype: 'multipart/form-data',
                    url: app.setting.apipath + 'v1/Common/Upload',
                    data: data,
                    processData: false,
                    contentType: false,
                    cache: false,
                    timeout: 600000,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('Token'));
                    }
                }).done(function (data, textStatus, jqXHR) {

                    rowDocumentosrequeridos.DNombre = data[0].FileName;
                    rowDocumentosrequeridos.DStored = data[0].StoredFileName;
                    rowDocumentosrequeridos.DTamano = data[0].Size;
                    rowDocumentosrequeridos.DFecha = new Date();
                    $('#documentosrequeridosTbl').bootstrapTable('updateByUniqueId', { id: rowDocumentosrequeridos.documentosrequeridosId, row: rowDocumentosrequeridos });

                }).fail(function (jqXHR, textStatus, errorThrown) {
                    console.log("ERROR : ", jqXHR);
                }).always(function () {
                    app.ui.ButtonDone('#fileUpload')
                });
            }
        });

    };


    return {
        Init: function () {
            Controls_setup();
            Setup_Validations();

            coberturas_table_setup();
            plandepago_table_setup();

            Controls_Events();

            terceros_controls_setup();
            terceros_table_setup();
            terceros_table_Validations();
            terceros_controls_Events();

            documentosrequeridos_controls_setup();
            documentosrequeridos_table_setup();
            documentosrequeridos_table_Validations();
            documentosrequeridos_controls_Events();

            Setup();
        },
        tercerosEditRow: function (row) {
            terceros_table_row_edit(row);
        },
        tercerosDeleteRow: function (row) {
            terceros_table_row_delete(row);
        },
        documentosrequeridosEditRow: function (row) {
            documentosrequeridos_table_row_edit(row);
        },
        documentosrequeridosDeleteRow: function (row) {
            documentosrequeridos_table_row_delete(row);
        }
    };
})();

window.tercerosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.tercerosId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.HogarTotal.tercerosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.HogarTotal.tercerosEditRow(row);
        e.stopPropagation();
    }
};

window.documentosrequeridosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer limpiar el documento requerido '" + row.DNombre + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.HogarTotal.documentosrequeridosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.HogarTotal.documentosrequeridosEditRow(row);
        e.stopPropagation();
    }
};