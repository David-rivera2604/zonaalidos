var app = app || {};

app.HogarTotal = (function () {

    var setupData = null;
    var showCalculate = false;
    var rowDocumentosrequeridos = null;

    let mainHolder = null;
    var workMode = '';
    let formularioRow = null;
    let fec_efec_poliza_grupo = null;

    function Setup() {
        if (localStorage.getItem('Roles').includes('Coopenae-Credecoop')) {
            $('#tipoplan option[value="2"]').prop("selected", true);
            $('#tipoplan').prop("disabled", true);
            $("#tipodetercero option[value=0]").remove();
            $('#tipodetercero option[value="2"]').prop("selected", true);
        }

        var _id = app.core.URLStringValue('presupuesto');
        if (_id != '') {
            workMode = app.core.URLStringValue('mode');

            $('#coberturasTbl').bootstrapTable('showLoading');
            app.core.Get(app.setting.apipath + 'v1/Issue/HogarTotalSetup/' + _id + '?mode=' + workMode)
                .done(function (data, textStatus, jqXHR) {
                    workMode = data.Modo;
                    if (localStorage.getItem('Roles').includes('Purdy')) {
                        $('.Purdy').removeClass('d-none');
                        $('#Fuente_Tomador').prop("disabled", (workMode != 'draft' && workMode != 'resume'));
                    }

                    if (workMode === 'draft' || workMode === 'resume') {
                        $('#guardarenviar').removeClass('d-none');
                        $("#guardarenviar").appendTo("#GenericToolBar");
                        $('.documentosrequeridosGrid').addClass('d-none');

                        $('#PageSubTitle').text("Emision Solicitud de Seguro.")
                        $('.datosgeneralesZone').removeClass('col-md-12');
                        $('.datosgeneralesZone').addClass('col-md-7');
                        $('.enviosolicitudZone').removeClass('d-none');
                    } else {
                        $('#cotizar').removeClass('d-none');
                        $("#cotizar").appendTo("#GenericToolBar");
                    }

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

    function ReadOnly_End() {
        $('#fec_efec_poliza_group').replaceWith('<div>' + $('#fec_efec_poliza').val() + '</div>');
        $('#fec_vcto_poliza_group').replaceWith('<div>' + $('#fec_vcto_poliza').val() + '</div>');
        $('#tercerosNew').addClass('d-none');
        $('#tercerosTbl').bootstrapTable('hideColumn', 'Actions');
        $('#propiedadNew').addClass('d-none');
        $('#propiedadTbl').bootstrapTable('hideColumn', 'Actions');
        $('#documentosrequeridosNew').addClass('d-none');
        $('#documentosrequeridosTbl').bootstrapTable('hideColumn', 'Actions');
        $('#formulariosNew').addClass('d-none');
        $('#formulariosTbl').bootstrapTable('hideColumn', 'Actions');
    }

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
                    ReadOnly_End();

                    $('#tercerosNew').addClass('d-none');
                    $('#tercerosTbl').bootstrapTable('hideColumn', 'Actions');

                    $('#propiedadNew').addClass('d-none');
                    $('#propiedadTbl').bootstrapTable('hideColumn', 'Actions');

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
        let lookupList = [
            'MonedasPorRamo.moneda',
            'FrecuenciaDePagoPorRamo.fraccionamientodepago',
            'MM_MCA_TIP_FIRMA.tip_firma',
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
            'Paises.cod_pais', 'Provincias.TProvincia', 'Cantones.TCanton', 'Distritos.TDistrito'];
        app.core.Lookups(lookupList,
            function () {
                MapObjectToInput_First(data);
                MapObjectToInput(data);
                ReadOnly();
                $("#tercerosNew").removeClass('d-none')
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

        data.tip_firma = $('#tip_firma').val();
        data.tip_firmaDesc = $("#tip_firma option:selected").text();
        data.correoenvio = $('#correoenvio').val();

        data.terceros = $('#tercerosTbl').bootstrapTable('getData');
        data.propiedad = $('#propiedadTbl').bootstrapTable('getData');
        data.documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');
       
        let formulariosDatakyc = $('#formulariosTbl').bootstrapTable('getData');
        if (formulariosDatakyc.length > 0) {
            data.kyc = $('#formulariosTbl').bootstrapTable('getData')[0].data;
        }
        setupData = data;
        return data;
    };

    function MapObjectToInput_First(data) {
        $('#Fuente_Tomador').val(data.Fuente_Tomador);
        $('#cod_mon').val(data.cod_mon);
        $('#cod_fracc_pago').val(data.cod_fracc_pago);
        $('#tip_firma').val(data.tip_firma);
        $('#Modalidad_Pago').val(data.Modalidad_Pago);

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
        if (data.propiedad != null)
            $('#propiedadTbl').bootstrapTable('load', data.propiedad);
        else
            $('#propiedadTbl').bootstrapTable('load', {});
        if (data.kyc != null)
            $("#formulariosTbl").bootstrapTable('load', data.kyc);
        else
            $('#formulariosTbl').bootstrapTable('load', {});
        TipoTercero_Filtro();
    }

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
    };

    function TipoTercero_Filtro() {
        let terceros = $('#tercerosTbl').bootstrapTable('getData');
        let holder = terceros.filter(i => i.tipodetercero === 0);
        let insured = terceros.filter(i => i.tipodetercero === 2);
        if (holder.length > 0) {
            $('#tipodetercero option[value="0"]').attr('disabled', 'disabled');
        }
        if (insured.length > 0) {
            $('#tipodetercero option[value="2"]').attr('disabled', 'disabled');
        }

        formularios_handler();

    }

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
        new AutoNumeric('#DISTANCIA_MTS', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '',
            maximumValue: '999999',
            minimumValue: '0',
            decimalPlaces: '0',
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

        $("#longitud").formatter({
            pattern: '{{999}}°{{999}},{{999}}',
            persistent: false
        });
        $("#longitud").attr('placeholder', 'XXX°XXX,XXX');

        $("#latitud").formatter({
            pattern: '{{99}}°{{99}},{{99}}',
            persistent: false
        });
        $("#latitud").attr('placeholder', 'XX°XX,XX');


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

        $('#Fuente_Tomador').change(function () {
            let value = $('#Fuente_Tomador').val();
            app.core.Post(app.setting.apipath + 'v1/Issue/HogarTotal/Terceros/' + value,
                JSON.stringify($('#tercerosTbl').bootstrapTable('getData')),
                function (data) {
                    setupData.terceros = data;
                    if (data != null)
                        $('#tercerosTbl').bootstrapTable('load', data);
                    else
                        $('#tercerosTbl').bootstrapTable('load', {});
                });
        });

        $('input:radio[name=CERCA_RI_MAR_LAG_TA_CI]').change(function () {
            $('#DISTANCIA_MTS').prop("disabled", app.ui.GetRadioNumericValue('CERCA_RI_MAR_LAG_TA_CI') === 2);
        });


        $('#guardarenviar').click(function () {
            var others = OtherValidations();
            if (app.ui.IsValid('#VisualizationsEdtForm', false) && others === 0) {
                app.ui.ButtonDoing('#guardarenviar');
                app.core.Post(app.setting.apipath + 'v1/Issue/HogarTotal',
                    JSON.stringify(MapInputToObject()),
                    function (data) {

                        $('#guardarenviar').addClass('d-none');
                        $('#Fuente_Tomador').replaceWith('<div>' + $('#Fuente_Tomador option:selected').text() + '</div>');
                        $('#Modalidad_Pago').replaceWith('<div>' + $('#Modalidad_Pago option:selected').text() + '</div>');
                        $('#tip_firma').replaceWith('<div>' + $('#tip_firma option:selected').text() + '</div>');
                        $('#correoenvio').replaceWith('<div>' + $('#correoenvio').val() + '</div>');

                        ReadOnly_End();

                    }).always(function () {
                        app.ui.ButtonDone('#guardarenviar');
                    });
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
                tip_firma: { required: true },
                correoenvio: { email: true, required: true },
            },
            messages: {
                tip_firma: { required: 'Debe indicar el tipo de envío' },
                correoenvio: { email: 'Debe indicar un correo electrónico valido', required: 'Debe indicar el correo para el envío' },
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
        $('#propiedadTbl-error').addClass('d-none');
    };

    function OtherValidations() {
        var result = 0;
        let message = 'Debe indicar la información de terceros';
        var terceros = $('#tercerosTbl').bootstrapTable('getData');
        var propiedad = $('#propiedadTbl').bootstrapTable('getData');
        let terceroserrors = (terceros.length === 0);

        if (terceros.length === 0) {
            $('#tercerosTbl-error').removeClass('d-none');
            result = result + 1;
        }

        if (propiedad.length === 0) {
            $('#propiedadTbl-error').removeClass('d-none');
            result = result + 1;
        }

        if (!terceroserrors && (workMode === 'draft' || workMode === 'resume')) {
            let holder = terceros.filter(i => i.tipodetercero == 0);
            let insured = terceros.filter(i => i.tipodetercero == "2");
            let bene = terceros.filter(i => i.tipodetercero == 6);

            if (holder.length == 0 || holder.length == "0") {
                message += ', indique el tomador';
                terceroserrors = true;
            }
            if (insured.length == 0 || insured.length == "0") {
                message += ', indique el asegurado';
                terceroserrors = true;
            }
            if (bene.length > 0) {
                if (bene.reduce((total, item) => total + item.porcentaje, 0) != 100) {
                    message += ', El total del porcentaje de participación para los beneficiarios debe ser el 100%';
                    terceroserrors = true;
                }
            }
        }
        if (terceroserrors) {
            $('#tercerosTbl-error').html(message);
            $('#tercerosTbl-error').removeClass('d-none');
            result = result + 1;
        } else {
            $('#tercerosTbl-error').addClass('d-none');
        }

        if (workMode != 'draft' && workMode != 'resume') {
            var grupo = 'F';
            let documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');
            let lista = documentosrequeridos.filter(function (row) {
                return (row.DStored === null || row.DStored === '');
            });
            if (lista.length > 0) {
                $('#documentosrequeridosTbl-error').html('Debe cargar todos los documentos pendientes');
                $('#documentosrequeridosTbl-error').removeClass('d-none');
                result = result + 1;
            }
        }

        if (formulariosMode()) {
            result = FormulariosValidations(result);
        }

        return result;
    };


    function FormulariosValidations(result) {
        let formularios = $('#formulariosTbl').bootstrapTable('getData');
        let formularioserrors = (formularios.length === 0);
        let message = '';

        if (formularioserrors) {
            message = 'Debe responder los formularios requeridos';
        } else {
            if (formularios[0].when === null) {
                message = 'Debe responder el formulario ' + formularios[0].name.toLowerCase();
                formularioserrors = true;
            }
        }
        if (formularioserrors) {
            $('#formulariosTbl-error').html(message);
            $('#formulariosTbl-error').removeClass('d-none');
            result = result + 1;

        } else {
            $('#formulariosTbl-error').addClass('d-none');
        }
        return result;
    }


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
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'DocumentNumber',
                    title: 'Identificación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
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
                    visible: true,
                    formatter: function (value, row, index, field) {
                        let name = value + (row.apellido1 ? ' ' + row.apellido1 : '');
                        return `<span>${name}</span>`;
                    }
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
                    align: 'center',
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
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'TProvinciaDesc',
                    title: 'Provincia',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'TCantonDesc',
                    title: 'Cantón',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'TDistritoDesc',
                    title: 'Distrito',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
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
                                'white-space': 'nowrap'
                            }
                        }
                    }
                }]
        });

        $('#tercerosNew').click(function () {
            $('#tipodetercero').val($('#tipodetercero option[disabled!="disabled"]')[0].value);
            $('#tipodetercero').change();
            $('#DocumentNumberTypeMenu a.active').click();
            terceros_table_row_edit();
        });



        $('#tercerosEdtFormSave').click(function () {
            let TerceroLista = $('#tercerosTbl').bootstrapTable('getData');
            var idlist = [];
            for (var id in TerceroLista) {
                idlist.push(TerceroLista[id]["tercerosId"])
            }
            if (app.ui.IsValid('#tercerosEdtForm', false)) {
                app.ui.ButtonDoing('#tercerosEdtFormSave');

                var row = terceros_table_row('values');
                if (row.tercerosId === null) {
                    if (idlist.length > 0) {
                        var lastid = Math.max(...idlist);
                        row.tercerosId = lastid + 1;
                    }
                    else {
                        row.tercerosId = 1;
                    }
                }

                let Rules = terceros_table_rules($('#tercerosModal').data('id'), TerceroLista, row)

                if (Rules.Error) {
                    if (Rules.type == "error") {
                        toastr.error(Rules.message, Rules.title, { timeOut: 9000, closeButton: true, progressBar: true });
                    }
                    else {
                        toastr.info(Rules.message, Rules.title, { timeOut: 9000, closeButton: true, progressBar: true });
                    }
                    app.ui.ButtonDone('#tercerosEdtFormSave')
                }
                else {
                    if (Rules.Event == "Update") {
                        for (var a in Rules.Result) {
                            $('#tercerosTbl').bootstrapTable('updateByUniqueId', { id: Rules.Result[a].tercerosId, row: Rules.Result[a] });
                        }

                        if (row.tipodetercero === 2) {
                            $('#correoenvio').val(row.correoelectronico);
                        }

                        if (row.eltomadoreselmismoasegurado === 1 && row.tipodetercero == 0) {
                            let AseguradoExiste = $('#tercerosTbl').bootstrapTable('getData').filter(i => i.DocumentNumber == row.DocumentNumber);
                            AseguradoExiste = AseguradoExiste.filter(i => i.tipodetercero == 2);
                            if (!(AseguradoExiste.length > 0)) {
                                let newinsurance = JSON.parse(JSON.stringify(row));
                                if (idlist.length > 0) {
                                    var lastid = Math.max(...idlist);
                                    newinsurance.tercerosId = lastid + 1;
                                }
                                else {
                                    newinsurance.tercerosId += 1;
                                }
                                newinsurance.tipodetercero = '2';
                                newinsurance.tipodeterceroDesc = $('#tipodetercero option[value="2"]').text();
                                $('#tercerosTbl').bootstrapTable('append', newinsurance);
                            }

                        }
                    }
                    else if (Rules.Event == "Insert") {
                        $('#tercerosTbl').bootstrapTable('append', row);

                        if (row.eltomadoreselmismoasegurado === 1 && row.tipodetercero == 0) {
                            let AseguradoExiste = $('#tercerosTbl').bootstrapTable('getData').filter(i => i.DocumentNumber == row.DocumentNumber);
                            AseguradoExiste = AseguradoExiste.filter(i => i.tipodetercero == 2);
                            if (!(AseguradoExiste.length > 0)) {
                                let newinsurance = JSON.parse(JSON.stringify(row));
                                newinsurance.tercerosId += 1;
                                newinsurance.tipodetercero = '2';
                                newinsurance.tipodeterceroDesc = $('#tipodetercero option[value="2"]').text();
                                $('#tercerosTbl').bootstrapTable('append', newinsurance);
                            }
                            else {
                                let newinsurance = JSON.parse(JSON.stringify(row));
                                newinsurance.tercerosId = AseguradoExiste[0].tercerosId;
                                newinsurance.tipodetercero = AseguradoExiste[0].tipodetercero;
                                newinsurance.tipodeterceroDesc = AseguradoExiste[0].tipodeterceroDesc;
                                $('#tercerosTbl').bootstrapTable('updateByUniqueId', { id: AseguradoExiste[0].tercerosId, row: newinsurance });
                            }

                        }
                        if (row.tipodetercero === 2) {
                            $('#correoenvio').val(row.correoelectronico);
                        }
                    }

                    app.ui.ButtonDone('#tercerosEdtFormSave')
                    $('#tercerosModal').modal('hide');
                    formularios_handler();


                }

            }

        });

    };

    function terceros_table_rules(Event, TercerosList, Tercero) {
        let TerceroTomador = TercerosList.filter(i => i.tipodetercero === "0")[0];
        let Rules = {
            Event: "",
            Error: false,
            title: null,
            message: null,
            Result: null,
        }
        if (Event != null) {
            if (TerceroTomador != undefined && TerceroTomador["tercerosId"] != Tercero.tercerosId && Tercero.tipodetercero == 0) {
                return Rules = {
                    Event: "Update",
                    Error: true,
                    title: "Existe 1 error",
                    message: "No pueden haber mas de dos tomadores",
                    type: "error"
                }
            }
            else {
                var TercerosUpdate = []
                TercerosUpdate.push(Tercero)

                var listClon = []
                if (TercerosList.length > 0) {
                    for (var tercero in TercerosList) {
                        if (Tercero.DocumentNumberType === TercerosList[tercero]["DocumentNumberType"] && Tercero.DocumentNumber === TercerosList[tercero]["DocumentNumber"] && Tercero.tercerosId != TercerosList[tercero]["tercerosId"]) {
                            listClon.push(TercerosList[tercero])
                        }
                    }
                }

                if (listClon.length > 0) {
                    for (var Clon in listClon) {
                        if (Tercero.tipodetercero == listClon[Clon]["tipodetercero"]) {
                            $('#tercerosTbl').bootstrapTable('removeByUniqueId', listClon[Clon]["tercerosId"]);
                        }
                        else {
                            var newterc = Object.assign({}, Tercero);
                            newterc.tercerosId = listClon[Clon]["tercerosId"]
                            newterc.tipodetercero = listClon[Clon]["tipodetercero"]
                            newterc.tipodeterceroDesc = listClon[Clon]["tipodeterceroDesc"]
                            TercerosUpdate.push(newterc)
                        }
                    }
                }

                Rules.Event = "Update";
                Rules.Result = TercerosUpdate;
                return Rules;
            }
        }
        else {
            let TerceroExiste = TercerosList.filter(i => i.DocumentNumber == Tercero.DocumentNumber);
            TerceroExiste = TerceroExiste.filter(i => i.tipodetercero == Tercero.tipodetercero);
            if (TerceroTomador != undefined && Tercero.tipodetercero == 0) {
                return Rules = {
                    Event: "Insert",
                    Error: true,
                    title: "Existe 1 error",
                    message: "No pueden haber mas de dos tomadores",
                    type: "error"
                }
            }
            else if (TerceroExiste.length > 0) {
                return Rules = {
                    Event: "Insert",
                    Error: true,
                    title: "El tercero ya existe",
                    message: "El tercero con cedula: " + TerceroExiste[0]["DocumentNumber"] + " y con el tipo de: " + TerceroExiste[0]["tipodeterceroDesc"] + " ya fue insertado",
                    type: "info"
                }
            }
            else {
                Rules.Event = "Insert";
                return Rules;
            }
        }
    }

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
                cod_paisDesc: $('#cod_pais option:selected').text(),
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
        $('#tipodetercero').change();
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
                otrasenas: { required: 'Debe indicar otras señas' },
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
        })
    };

    function terceros_documentNumberCallBack(data) {
        if (data != null) {
            $('#nombre').val((data.FirstName + ' ' + data.MiddleName).trim());
            $('#apellido1').val(data.LastName);
            $('#apellido2').val(data.SecondLastName);
            $('#PhoneNumber').val(data.PhoneNumber);
            app.ui.SetDateValue('#fechadenacimiento', data.BirthDate);
            $('#tercerosMca_sexo').val(data.Gender == 2 ? 1 : 0);
            $('#TProvincia').val(data.Province);
            $('#correoelectronico').val(data.PrimaryEmailAddress);
            $('#numerodetelefono').val(data.PhoneNumber);

            let value = data.CivilStatus;
            if (value == '1')
                value = 'C';
            else if (value == '2')
                value = 'D';
            else if (value == '3')
                value = 'S';
            else if (value == '4')
                value = 'V';
            $('#estadoCivil').val(value);



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
        app.ui.DocumentNumberHandlerJDC('#DocumentNumber', terceros_documentNumberCallBack);
        $('#tipodetercero').change(function () {
            switch ($('#tipodetercero').val()) {
                case '0':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().removeClass('d-none');
                    $('#acredorZone').addClass('d-none');
                    $('#beneficiarioZone').addClass('d-none');
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















    //-------------------------------------------------------------------------Scripts propiedadNew------------------------------------------------------------------------------
    function propiedad_table_setup() {
        $('#propiedadTbl').bootstrapTable({
            uniqueId: 'propiedadId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'tipoplan',
                    title: 'Tipo plan',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'otrassenas',
                    title: 'Otras señas',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    width: 20,
                    widthUnit: "%",
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'numerodefolio',
                    title: 'Número de folio',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'anodeconstruccion',
                    title: 'Año de construcción',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'numerometrosconstruidos',
                    title: 'Número de metros construidos',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'numerodepiso',
                    title: 'Número de pisos',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
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
                    events: 'propiedad_Events',
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

        $('#propiedadNew').click(function () {
            propiedad_table_row_edit();
        });

        $('#propiedadEdtFormSave').click(function () {
            if (app.ui.IsValid('#propiedadEdtForm', false)) {
                app.ui.ButtonDoing('#propiedadEdtFormSave');

                var row = propiedad_table_row('values');

                if (row.propiedadId === null)
                    row.propiedadId = 1;
                if ($('#propiedadModal').data('id') != null) {
                    $('#propiedadTbl').bootstrapTable('updateByUniqueId', { id: row.propiedadId, row: row });
                }
                else {
                    $('#propiedadTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#propiedadEdtFormSave')
                $('#propiedadModal').modal('hide');
                $('#propiedadNew').addClass('d-none')
            }
        });

    };

    function propiedad_table_row(mode) {
        if (mode == null) {
            return {
                propiedadId: null,
                tipoplan: null,
                otrassenas: null,
                numerodefolio: null,
                anodeconstruccion: null,
                numerometrosconstruidos: null,
                numerodepiso: null,

                numerofincafilial: null,
                numerodefoliomadre: null,
                alturaedificio: null,
                NS_latitud: '',
                EO_longitud: '',
                latitud: '',
                longitud: '',
                norte: null,
                sur: null,
                este: null,
                oeste: null,
                material_estructura: null,
                mamposteria: null,
                paredes_internas: null,
                techo: null,
                material_piso: null,
                entrepisos: null,
                danosprevios: null,
                piso: null,
                sobrepeso: null,
                lugardelbien: null,
                INS_ELECT_ENTUB: null,
                CERCA_RI_MAR_LAG_TA_CI: null,
                DISTANCIA_MTS: null,
                VULNERABILIDAD: null,
                bodega: null,
                garaje: null,
                tapias: null,
                piscina: null,
                otras_sumas: null
            };
        }
        else {
            return {
                propiedadId: $('#propiedadModal').data('id'),
                tipoplan: $('#tipoplan').val(),
                otrassenas: $('#otrassenas').val(),
                numerodefolio: $('#numerodefolio').val(),
                anodeconstruccion: $('#anodeconstruccion').val(),
                numerometrosconstruidos: $('#numerometrosconstruidos').val(),
                numerodepiso: $('#numerodepiso').val(),



                numerofincafilial: $('#numerofincafilial').val(),
                numerodefoliomadre: $('#numerodefoliomadre').val(),
                alturaedificio: $('#alturaedificio').val(),

                NS_latitudText: $('#NS_latitud').val(),
                NS_latitud: $('#NS_latitud').val(),
                latitud: $('#latitud').val() + $('#NS_latitud option:selected').text(),

                EO_longitudText: $('#EO_longitud').val(),
                EO_longitud: $('#EO_longitud').val(),
                longitud: $('#longitud').val() + $('#EO_longitud option:selected').text(),

                norte: $('#norte').val(),
                sur: $('#sur').val(),
                este: $('#este').val(),
                oeste: $('#oeste').val(),
                material_estructura: $('#material_estructura').val(),
                mamposteria: $('#mamposteria').val(),
                paredes_internas: $('#paredes_internas').val(),
                techo: $('#techo').val(),
                material_piso: $('#material_piso').val(),
                entrepisos: $('#entrepisos').val(),

                sobrepeso: app.ui.GetRadioNumericValue('sobrepeso'),
                sobrepesoDesc: app.ui.GetRadioSelectedText('sobrepeso'),

                lugardelbien: $('#lugardelbien').val(),
                lugardelbienDesc: $('#lugardelbien option:selected').text(),

                danosprevios: app.ui.GetRadioNumericValue('danosprevios'),
                danospreviosDesc: app.ui.GetRadioSelectedText('danosprevios'),

                CERCA_RI_MAR_LAG_TA_CI: app.ui.GetRadioNumericValue('CERCA_RI_MAR_LAG_TA_CI'),
                DISTANCIA_MTS: app.ui.GetNumericValue('#DISTANCIA_MTS'),
                INS_ELECT_ENTUB: app.ui.GetRadioNumericValue('INS_ELECT_ENTUB'),
                VULNERABILIDAD: app.ui.GetRadioNumericValue('VULNERABILIDAD'),
                bodega: app.ui.GetNumericValue('#bodega'),
                garaje: app.ui.GetNumericValue('#garaje'),
                tapias: app.ui.GetNumericValue('#tapias'),
                piscina: app.ui.GetNumericValue('#piscina'),
                otras_sumas: app.ui.GetNumericValue('#otras_sumas')
            };
        }
    };


    function propiedad_table_row_edit(row) {
        var md = $('#propiedadModal').modal({ show: false });
        var formInstance = $("#propiedadEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || propiedad_table_row();
        md.data('id', row.propiedadId);

        //Required
        $('#tipoplan').val(row.tipoplan);
        $('#otrassenas').val(row.otrassenas);
        $('#numerodefolio').val(row.numerodefolio);
        $('#anodeconstruccion').val(row.anodeconstruccion);
        $('#numerodepiso').val(row.numerodepiso);


        $('#numerofincafilial').val(row.numerofincafilial);
        $('#numerodefoliomadre').val(row.numerodefoliomadre);
        $('#alturaedificio').val(row.alturaedificio);
        $('#NS_latitud').val(row.NS_latitud);
        $('#EO_longitud').val(row.EO_longitud);
        $('#latitud').val(row.latitud);
        $('#longitud').val(row.longitud);
        $('#norte').val(row.norte);
        $('#sur').val(row.sur);
        $('#este').val(row.este);
        $('#oeste').val(row.oeste);
        $('#material_estructura').val(row.material_estructura);
        $('#mamposteria').val(row.mamposteria);
        $('#techo').val(row.techo);
        $('#material_piso').val(row.material_piso);
        $('#entrepisos').val(row.entrepisos);
        $('#piso').val(row.piso);
        app.ui.SetRadioNumericValue('sobrepeso', row.sobrepeso);
        $('#lugardelbien').val(row.lugardelbien);


        app.ui.SetRadioNumericValue('danosprevios', row.danosprevios);
        app.ui.SetRadioNumericValue('INS_ELECT_ENTUB', row.INS_ELECT_ENTUB);
        app.ui.SetRadioNumericValue('VULNERABILIDAD', row.VULNERABILIDAD);
        app.ui.SetNumericValue('#DISTANCIA_MTS', row.DISTANCIA_MTS);
        app.ui.SetRadioNumericValue('CERCA_RI_MAR_LAG_TA_CI', row.CERCA_RI_MAR_LAG_TA_CI);

        app.ui.SetNumericValue('#bodega', row.bodega);
        app.ui.SetNumericValue('#garaje', row.garaje);
        app.ui.SetNumericValue('#tapias', row.tapias);
        app.ui.SetNumericValue('#piscina', row.piscina);
        app.ui.SetNumericValue('#otras_sumas', row.otras_sumas);


        md.modal('show');
    };

    function propiedad_table_row_delete(row) {
        $('#propiedadTbl').bootstrapTable('removeByUniqueId', row.propiedadId);
    };




    function propiedad_table_Validations() {
        app.ui.DateValidators();
        $("#propiedadEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                tipoplan: { required: true },
                otrassenas: { required: true },
                numerodefolio: { required: true },
                anodeconstruccion: { required: true },
                numerometrosconstruidos: { required: true },
                numerodepiso: { required: true },
            },
            messages: {
                tipoplan: { required: 'Debe indicar el tipo plan' },
                otrassenas: { required: 'Debe indicar otras señas' },
                numerodefolio: { required: 'Debe indicar el número de folio' },
                anodeconstruccion: { required: 'Debe indicar el año de construcción' },
                numerometrosconstruidos: { required: 'Debe indicar el número metros construidos' },
                numerodepiso: { required: 'Debe indicar el número de piso' },
            }
        });
    };

    function propiedad_controls_setup() {
        new AutoNumeric('#garaje', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#bodega', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#piscina', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#otras_sumas', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#tapias', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
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
                            return '<span class="label label-danger d-flex flex-column text-center"><i class="fa fa-file-pdf-o"></i> Pendiente</span>';
                        }
                        else {
                            return '<span class="label label-success d-flex flex-column text-center"><i class="fa fa-file-pdf-o"></i> Listo</span>';
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
                        let result;
                        if (row.DStored != null && row.DStored != '') {
                            result = `<span><a href=# onclick="app.ui.Download('${row.DNombre}', ${row.documentosrequeridosId}); return false;" title="Descargar adjunto"><i class="fa fa-paperclip"></i></a>`;
                        } else {
                            result = '<span><i class="fa fa-paperclip"></i>';
                        }
                        if (row.tipo == 'Genérico') {
                            result += ' ' + row.DDescripcion + ' (' + value + ')</span>';
                        }
                        else {
                            result += ' ' + value + '</span>';
                        }
                        return result;
                    },
                    visible: true,
                    width: 30,
                    widthUnit: '%'
                }, {
                    field: 'DNombre',
                    title: 'Archivo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
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
                    align: 'center',
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

    function formularios_table_setup() {
        $('#formulariosTbl').bootstrapTable({
            uniqueId: 'formularioId',
            data: [],
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'status',
                    title: 'Estado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: function (value, row, index, field) {

                        if (row.data === null) {
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
                    field: 'name',
                    title: 'Tipo de formulario',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true,
                    width: 60,
                    widthUnit: '%'
                }, {
                    field: 'when',
                    title: 'Cuando',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateAndTimeFormatter',
                    visible: true,
                    width: 20,
                    widthUnit: '%'
                }, {
                    field: 'Actions',
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un formulario',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    visible: true,
                    events: 'formulariosTbl_Events',
                    formatter: function (value, row, index, field) {
                        var html = [];
                        html.push('<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite agregar o editar la información de un formulario"> <i class="fa fa-pencil"></i> </button>');
                        html.push('<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar la información de un formulario"> <i class="fa fa-recycle"></i> </button>');
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

    }

    function formularios_table_row_edit(row) {
        formularioRow = row;
        let name = "#" + formularioRow.type;

        if ($(name + 'Modal').length == 1) {
            if (name == "#datosvariables") {
                let md = $(name + 'Modal').modal({ show: false });
                md.modal('show');
                if (formularioRow.data != null) {
                    MapObjectoinputdatosvar(formularioRow.data);
                }
            }
            else {
                let md = $(name + 'Modal').modal({ show: false });
                let ref = formularioRow.type === 'kycpersona' ? app.kycpersona : app.kycjuridico;
                md.modal('show');
                ref.SetData(formularioRow.data);
            }
        } else {

            $('.ibox-content').toggleClass('sk-loading');

            app.core.GetView(app.setting.viewpath + (formularioRow.type === 'kycpersona' ? 'Emision/_kyc_persona' : 'Emision/_kyc_juridico'))
                .done(function (data, textStatus, jqXHR) {
                    $("#dynamic").append(data);

                    let md = $(name + 'Modal').modal({ show: false });

                    md.modal('show');

                    app.core.LoadScriptFile(formularioRow.type === 'kycpersona' ? 'Emision.kyc.persona.js' : 'Emision.kyc.juridico.js')
                        .then(d => {
                            let ref = formularioRow.type === 'kycpersona' ? app.kycpersona : app.kycjuridico;
                            formularioRow.data = ref.InitData(false);
                            if (formularioRow.type === 'kycpersona') {
                                if (app.ui.IsDocumentNumberValid(mainHolder[0].DocumentNumberType, mainHolder[0].DocumentNumber)) {
                                    var value = mainHolder[0].DocumentNumber.replace(/-/g, '');
                                    app.core.Get(app.setting.apipath + 'v1/KYC/' + "persona" + "?id=" + value)
                                        .done(function (data, textStatus, jqXHR) {
                                            if (data != null) {
                                                for (const a in formularioRow.data) {
                                                    for (const b in data) {
                                                        if (a == b) {
                                                            formularioRow.data[a] = data[b]
                                                        }
                                                    }
                                                }

                                            }
                                            else {
                                                formularioRow.data.nacionalidadPer = 188;
                                                formularioRow.data.paisdenacimientoPer = 188;
                                            }

                                            formularioRow.data.primerapellidoPer = mainHolder[0].apellido1;
                                            formularioRow.data.segundoapellidoPer = mainHolder[0].apellido2;
                                            formularioRow.data.nombrePer = mainHolder[0].nombre;
                                            formularioRow.data.fechadenacimientoPer = mainHolder[0].fechadenacimiento;
                                            formularioRow.data.correoelectronicoPer = mainHolder[0].correoelectronico;
                                            formularioRow.data.sexoPer = mainHolder[0].tercerosMca_sexo;
                                            formularioRow.data.numidentificacion = mainHolder[0].DocumentNumber;
                                            formularioRow.data.numidentificaciontipo = mainHolder[0].DocumentNumberType;
                                            formularioRow.data.estadocivilPer = mainHolder[0].estadoCivil;
                                            formularioRow.data.telefonoresidenciaPer = mainHolder[0].numerodetelefono;

                                            formularioRow.data.domiciliopermanenteCod_pais = mainHolder[0].cod_pais;
                                            formularioRow.data.domiciliopermanenteCod_estado = mainHolder[0].TProvincia;
                                            formularioRow.data.domiciliopermanenteCod_prov = mainHolder[0].TCanton;
                                            formularioRow.data.domiciliopermanenteCod_localidad = mainHolder[0].TDistrito;
                                            formularioRow.data.domiciliopermanenteDireccionexacta = mainHolder[0].otrasenas;

                                            ref.Init(formularioRow.data);
                                            ref.AcceptCallBack(app.HogarTotal.Accept);
                                        })
                                }
                            }
                            else {
                                if (app.ui.IsDocumentNumberValid(mainHolder[0].DocumentNumberType, mainHolder[0].DocumentNumber)) {
                                    var value = mainHolder[0].DocumentNumber.replace(/-/g, '');
                                    app.core.Get(app.setting.apipath + 'v1/KYC/' + "juridico" + "?id=" + value)
                                        .done(function (data, textStatus, jqXHR) {
                                            if (data != null) {
                                                for (const a in formularioRow.data) {
                                                    for (const b in data) {
                                                        if (a == b) {
                                                            formularioRow.data[a] = data[b]
                                                        }
                                                    }
                                                }
                                            }
                                            formularioRow.data.nombrecomercialJur = mainHolder[0].nombre;
                                            formularioRow.data.razonsocialJur = mainHolder[0].nombre;
                                            formularioRow.data.numidentificacion = mainHolder[0].DocumentNumber;
                                            formularioRow.data.correoelectronicoJur = mainHolder[0].correoelectronico;

                                            formularioRow.data.domiciliocomercialCod_pais = mainHolder[0].cod_pais;
                                            formularioRow.data.domiciliocomercialCod_estado = mainHolder[0].TProvincia;
                                            formularioRow.data.domiciliocomercialCod_prov = mainHolder[0].TCanton;
                                            formularioRow.data.domiciliocomercialCod_localidad = mainHolder[0].TDistrito;
                                            formularioRow.data.domiciliocomercialDireccionexacta = mainHolder[0].otrasenas;

                                            ref.Init(formularioRow.data);
                                            ref.AcceptCallBack(app.HogarTotal.Accept);
                                        })
                                }

                            }
                        })
                        .catch(err => {
                            console.error(err);
                        });
                }).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });
        }
    }

    function formularios_table_row_delete(row) {
        row.when = null;
        row.data = null;
        $('#formulariosTbl').bootstrapTable('updateByUniqueId', { id: row.formularioId, row: row });
    }

    function formularios_table_kycSetData(data) {
        let name = "#" + formularioRow.type;
        formularioRow.data = data;
        formularioRow.when = new Date();
        $('#formulariosTbl').bootstrapTable('updateByUniqueId', { id: formularioRow.formularioId, row: formularioRow });
        $(name + 'Modal').modal('hide');
        FormulariosValidations(0);
    };

    function formularios_handler() {
        if (formulariosMode()) {
            mainHolder = $('#tercerosTbl').bootstrapTable('getData').filter(i => i.tipodetercero == "0");
            if (mainHolder.length > 0) {

                $('.formulariosGrid').removeClass('d-none');

                let row = { formularioId: 1, name: 'Conozca a su cliente persona', when: null, type: 'kycpersona', data: null };

                if (mainHolder[0].DocumentNumberType === 4) {
                    row.name = 'Conozca a su cliente Jurídico';
                    row.type = 'kycjuridico';
                }

                $('#formulariosTbl').bootstrapTable('load', [row]);
            }
            if (mainHolder.length === 0) {
                $('.formulariosGrid').addClass('d-none');
            }
        }
    };

    function formulariosMode() {
        return ((workMode === 'draft' || workMode === 'resume') && !localStorage.getItem('Roles').includes('Purdy') && !localStorage.getItem('Roles').includes('Davivienda_Prendarios') && !localStorage.getItem('Roles').includes('Davivienda_Leasing'));
    }


    return {
        Data: function () {
            return setupData;
        },

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

           propiedad_controls_setup();
            propiedad_table_setup();
            propiedad_table_Validations();

            documentosrequeridos_controls_setup();
            documentosrequeridos_table_setup();
            documentosrequeridos_table_Validations();
            documentosrequeridos_controls_Events();

            formularios_table_setup();

            Setup();
        },
        tercerosEditRow: function (row) {
            terceros_table_row_edit(row);
        },
        tercerosDeleteRow: function (row) {
            terceros_table_row_delete(row);
        },
        propiedadEditRow: function (row) {
            propiedad_table_row_edit(row);
        },
        propiedadDeleteRow: function (row) {
            propiedad_table_row_delete(row);
        },

        documentosrequeridosEditRow: function (row) {
            documentosrequeridos_table_row_edit(row);
        },
        documentosrequeridosDeleteRow: function (row) {
            documentosrequeridos_table_row_delete(row);
        },

        formulariosEditRow: function (row) {
            formularios_table_row_edit(row);
        },
        formulariosDeleteRow: function (row) {
            formularios_table_row_delete(row);
        },
        Accept: function (data) {
            formularios_table_kycSetData(data);
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
        $(document).ready(function () {
            $('.col-sm-4').each(function () {
                var idI = $(this).find('input').attr('id');
                var idS = $(this).find('select').attr('id');
                var typeNum = (row.DocumentNumberType != 1 && row.DocumentNumberType != 2 && row.DocumentNumberType != 3);
                if (typeNum && (idI === 'apellido1' || idI === 'apellido2' || idI === 'fechadenacimiento' || idS === 'tercerosMca_sexo' || idS === 'estadoCivil')) {
                    $(this).addClass('d-none');
                } else if (!typeNum && (idI === 'apellido1' || idI === 'apellido2' || idI === 'fechadenacimiento' || idS === 'tercerosMca_sexo' || idS === 'estadoCivil')) {
                    $(this).removeClass('d-none');
                }
            })
        })
    }
};


window.propiedad_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.propiedadId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.HogarTotal.propiedadDeleteRow(row); } });
        e.stopPropagation();
        $('#propiedadNew').removeClass('d-none');
    },
    'click .edit': function (e, value, row, index) {
        app.HogarTotal.propiedadEditRow(row);
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

window.formulariosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer limpiar la información del formulario  '" + row.name + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.HogarTotal.formulariosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.HogarTotal.formulariosEditRow(row);
        e.stopPropagation();
    }
};

