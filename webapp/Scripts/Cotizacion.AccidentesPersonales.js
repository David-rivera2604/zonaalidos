var app = app || {};
var errors = false;
var msj_errors = '';
app.CotizacionAccidentesPersonales = (function () {
    let setupData = null;
    let changedCallback = null;
    var workMode = '&mode=resume';
    function Setup() {
        app.core.Get(app.setting.apipath + 'v1/Quote/AccidentesPersonalesSetup', null,
            function (data) {
                setupData = data;
                let lookupList = [
                    'MonedasPorRamo.cod_mon',
                    'TRON_TAVID000.COD_PLAN_AP',
                    'TRON_TAVID001.COD_MODALIDAD',
                    'TRON_TAVID002.COD_OCUPACION',
                    'TRON_TAVID003.COD_DEDUCIBLE'];
                setupData = JSON.parse(JSON.stringify(data));
                app.core.Lookups(lookupList,
                    function () {
                        setupData = data;
                        MapObjectToInput(data);
                    }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}`);
            });

    };
    function MapInputToObject() {
        var data = {
            cod_mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            cod_mon_desc: $('#cod_mon option:selected').text(),
            cod_fracc_pago: app.ui.GetDropDownNumericValue('#cod_fracc_pago'),
            fec_efec_poliza: app.ui.GetDateValue('#fec_efec_poliza'),
            fec_vcto_poliza: app.ui.GetDateValue('#fec_vcto_poliza'),
            FEC_NACIMIENTO: app.ui.GetDateValue('#FEC_NACIMIENTO'),
            MCA_SEXO: app.ui.GetRadioStringValue('MCA_SEXO'),
            NOM_SEXO: $('label[for=MCA_SEXO_' + app.ui.GetRadioStringValue('MCA_SEXO') + ']').html(),
            TXT_CRED_ESTUD: $('#TXT_CRED_ESTUD').val(),
            COD_PLAN_AP: app.ui.GetDropDownNumericValue('#COD_PLAN_AP'),
            NOM_PLAN_AP: $("#COD_PLAN_AP option:selected").text(),
            coberturas: $('#coberturasTbl').bootstrapTable('getData'),
            plandepago: $('#plandepagoTbl').bootstrapTable('getData'),
            COD_MODALIDAD: app.ui.GetDropDownNumericValue('#COD_MODALIDAD'),
            nom_modalidad: $('#COD_MODALIDAD option:selected').text(),
            COD_OCUPACION: app.ui.GetDropDownNumericValue('#COD_OCUPACION'),
            NOM_OCUPACION: $("#COD_OCUPACION option:selected").text(),
            COD_DEDUCIBLE: app.ui.GetDropDownNumericValue('#COD_DEDUCIBLE'),
            NOM_DEDUCIBLE: $("#COD_DEDUCIBLE option:selected").text(),
        };
        return data;
    };
    function MapObjectToInput(data) {
        $('#cod_mon').val(data.cod_mon);
        app.ui.SetDropDownNumericValue('#cod_mon', data.cod_mon, true);
        $('#cod_fracc_pago').val(data.cod_fracc_pago);
        app.ui.SetDropDownNumericValue('#cod_fracc_pago', data.cod_fracc_pago, true);
        app.ui.SetDateValue('#fec_efec_poliza', data.fec_efec_poliza);
        app.ui.SetDateValue('#fec_vcto_poliza', data.fec_vcto_poliza);
        app.ui.SetDateValue('#FEC_NACIMIENTO', data.FEC_NACIMIENTO);
        app.ui.SetRadioStringValue('MCA_SEXO', data.MCA_SEXO);
        $('#TXT_CRED_ESTUD').val(data.TXT_CRED_ESTUD);
        $('#COD_PLAN_AP').val(data.COD_PLAN_AP);
        $('#COD_MODALIDAD').val(data.COD_MODALIDAD);
        $('#COD_DEDUCIBLE').val(data.COD_DEDUCIBLE);
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
        $('#FEC_NACIMIENTO_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $("#cotizar").appendTo("#GenericToolBar");
        $("#limpiar").appendTo("#GenericToolBar");
    };
    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#EstudiantilEdtForm :input").change(function () {
            data_changed();
        });
        $('#fec_efec_poliza').blur(function () {
            let minDate = app.ui.GetDateRawValue('#fec_efec_poliza');
            minDate.setDate(minDate.getDate());
            app.ui.SetDateValue('#fec_vcto_poliza', minDate.setFullYear(minDate.getFullYear() + 1));
        });
        $('#cotizar').click(function () {
            if (app.ui.IsValid('#EstudiantilEdtForm', false)) {
                if (errors === false) {
                    app.ui.ButtonDoing('#cotizar');
                    Quote();
                }
                else {
                    toastr.error("Existen errores" + msj_errors, "", { closeButton: true, progressBar: true });
                }

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
            $("#EstudiantilEdtForm").validate().resetForm();
            app.ui.ButtonDone('#limpiar');
            event.preventDefault();
        });
        $('#print').click(function () {
            event.preventDefault();
            app.Cotizacion.Imprimir('Estudiantil', app.AccidentesPersonales.Data());
        });
        $('#emitir').click(function () {
            event.preventDefault();
            window.location.replace(app.setting.basepath + 'emision/AccidentesPersonales?presupuesto=' + quoteData.presupuesto + workMode);
        });
    };
    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#EstudiantilEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                cod_mon: { required: true },
                cod_fracc_pago: { required: true },
                fec_efec_poliza: { required: true },
                fec_vcto_poliza: { required: true },
                FEC_NACIMIENTO: { required: true },
                MCA_SEXO: { required: true },
                TXT_CRED_ESTUD: { required: true },
                COD_PLAN_AP: { required: true },
                COD_MODALIDAD: { required: true },
                COD_OCUPACION: { required: true },
                COD_DEDUCIBLE: { required: true },
            },
            messages: {
                cod_mon: { required: 'Debe indicar la moneda' },
                cod_fracc_pago: { required: 'Debe indicar el fraccionamiento de pago' },
                fec_efec_poliza: { required: 'Debe indicar el inicio de vigencia' },
                fec_vcto_poliza: { required: 'Debe indicar el in de vigencia' },
                FEC_NACIMIENTO: { required: 'Debe indicar la fecha de nacimiento' },
                MCA_SEXO: { required: 'Debe indicar el sexo' },
                TXT_CRED_ESTUD: { required: 'Debe indicar el credencial del estudiante' },
                COD_PLAN_AP: { required: 'Debe indicar el plan' },
                COD_MODALIDAD: { required: 'Debe indicar la modalidad' },
                COD_OCUPACION: { required: 'Debe indicar la ocupación' },
                COD_DEDUCIBLE: { required: 'Debe indicar los Días de Deducible Renta Diaria' }
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
                    field: 'recardoporfraccionamiento',
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
    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Quote/AccidentesPersonalesQuote',
            JSON.stringify(MapInputToObject()),
            function (data) {
                quoteData = data;
                if (!app.ui.NotifyErrors(data.Mensaje, data.Errors, '#EstudiantilEdtForm')) {
                    $('#presupuesto').html(data.presupuesto);
                    $('#coberturasRow').removeClass('d-none');
                    $('#coberturasTbl').bootstrapTable('load', data.coberturas);
                    $('#plandepagoRow').removeClass('d-none');
                    $('#plandepagoTbl').bootstrapTable('load', data.plandepago);
                    if (data.plandepagoporfrecuencia != null) {
                        $('#plandepagoporfrecuenciaTbl').bootstrapTable('load', data.plandepagoporfrecuencia);
                        $('#plandepagoporfrecuencia').removeClass('d-none');
                    }
                    else
                        $('#plandepagoporfrecuencia').bootstrapTable('load', {});
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
    }
    return {
        Init: function () {
            try {
                Controls_setup();
                Setup_Validations();
                Setup();
                coberturas_table_setup();
                plandepago_table_setup();
                plandepagoporfrecuencia_table_setup();
                Controls_Events();

                console.log("Inicio");
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Data: function () {
            let data = MapInputToObject();
            data.plandepagoporfrecuencia = quoteData.plandepagoporfrecuencia;
            data.presupuesto = quoteData.presupuesto;
            data.Agente = setupData.Agente;
            return data;
        },
        Changed: function (callback) {
            changedCallback = callback;
        },
        IsValid: function (showResume) {
            return app.ui.IsValid('#EstudiantilEdtForm', false, showResume);
        }
    };
})();
