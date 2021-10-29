var app = app || {};

app.CotizacionViajero = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {
	
app.core.Get(app.setting.apipath + 'v1/Quote/ViajeroSetup', null,
            function (data) {
                app.core.Lookups(['MonedasPorRamo.cod_mon','FrecuenciaDePagoPorRamo.cod_fracc_pago','TRON_G2990006:TIP_PLAN.TIP_PLAN','TRON_G2990006:TIP_VIAJE.TIP_VIAJE','TRON_A1002090.COD_MODALIDAD',],
                    function () {
                        setupData = data;
                        MapObjectToInput(data);
                    }, `cod_ramo=441:cod_mon=2`);

            });
    };

    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Quote/ViajeroQuote',
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
                        $('#recargoporfraccionamiento').html(data.resumen.recargoporfraccionamiento.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#cuotas').html(data.resumen.cuota);
                        $('html,body').animate({ scrollTop: $('#quoteBlock').offset().top }, 'slow');
                    }
                }


            }).always(function () {
                app.ui.ButtonDone('#cotizar');
            });
    };
    
    function ReadOnly() {
        $('#cod_mon').replaceWith('<div>' + $('#cod_mon option:selected').text() + '</div>');
        $('#cod_fracc_pago').replaceWith('<div>' + $('#cod_fracc_pago option:selected').text() + '</div>');
        $('#fec_efec_poliza_group').replaceWith('<div>' + $('#fec_efec_poliza').val() + '</div>');
        $('#fec_vcto_poliza_group').replaceWith('<div>' + $('#fec_vcto_poliza').val() + '</div>');
        $('#TIP_PLAN').replaceWith('<div>' + $('#TIP_PLAN option:selected').text() + '</div>');
        $('#TIP_VIAJE').replaceWith('<div>' + $('#TIP_VIAJE option:selected').text() + '</div>');
        $('#FEC_VIAJE_group').replaceWith('<div>' + $('#FEC_VIAJE').val() + '</div>');
        $('#DES_DESTINO').replaceWith('<div>' + $('#DES_DESTINO').val() + '</div>');
        $('#FEC_NACIMIENTO_group').replaceWith('<div>' + $('#FEC_NACIMIENTO').val() + '</div>');
        $('#COD_MODALIDAD').replaceWith('<div>' + $('#COD_MODALIDAD option:selected').text() + '</div>');

    };
    
  function MapInputToObject() {
        var data = {
            cod_mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            cod_fracc_pago: app.ui.GetDropDownNumericValue('#cod_fracc_pago'),
            fec_efec_poliza: app.ui.GetDateValue('#fec_efec_poliza'),
            fec_vcto_poliza: app.ui.GetDateValue('#fec_vcto_poliza'),
            TIP_PLAN: app.ui.GetDropDownStringValue('#TIP_PLAN'),
            //TIP_PLAN_DESC = $("#TIP_PLAN option:selected").text(),
            TIP_VIAJE: app.ui.GetDropDownStringValue('#TIP_VIAJE'),
            //TIP_VIAJE_DESC = $("#TIP_VIAJE option:selected").text(),
            FEC_VIAJE: app.ui.GetDateValue('#FEC_VIAJE'),
            DES_DESTINO: $('#DES_DESTINO').val(),
            FEC_NACIMIENTO: app.ui.GetDateValue('#FEC_NACIMIENTO'),
            COD_MODALIDAD: app.ui.GetDropDownNumericValue('#COD_MODALIDAD'),
            //COD_MODALIDAD_DESC = $("#COD_MODALIDAD option:selected").text(),
            coberturas: $('#coberturasTbl').bootstrapTable('getData'),
            plandepago: $('#plandepagoTbl').bootstrapTable('getData'),
            

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
        app.ui.SetDateValue('#fec_vcto_poliza', data.fec_vcto_poliza);
        $('#TIP_PLAN').val(data.TIP_PLAN);
        app.ui.SetDropDownNumericValue('#TIP_PLAN', data.TIP_PLAN, true, 'I');
        $('#TIP_VIAJE').val(data.TIP_VIAJE);
        app.ui.SetDropDownNumericValue('#TIP_VIAJE', data.TIP_VIAJE, true, 'NA');
        app.ui.SetDateValue('#FEC_VIAJE', data.FEC_VIAJE);
        $('#DES_DESTINO').val(data.DES_DESTINO);
        app.ui.SetDateValue('#FEC_NACIMIENTO', data.FEC_NACIMIENTO);
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
            var minDate = app.ui.GetDateRawValue('#fec_efec_poliza');
            minDate.setDate(minDate.getDate());

            $('#fec_vcto_poliza_group').data("DateTimePicker").minDate(minDate);
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
        $("#VisualizationsEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {cod_mon: { required: true },
cod_fracc_pago: { required: true },
fec_efec_poliza: { required: true },
fec_vcto_poliza: { required: true },
TIP_PLAN: { required: true },
TIP_VIAJE: { required: true },
FEC_VIAJE: { required: true },
DES_DESTINO: { required: true },
FEC_NACIMIENTO: { required: true },
COD_MODALIDAD: { required: true },
},
            messages: {cod_mon: { required: 'Debe indicar el Moneda' },
cod_fracc_pago: { required: 'Debe indicar el Fraccionamiento de pago' },
fec_efec_poliza: { required: 'Debe indicar el Inicio de vigencia' },
fec_vcto_poliza: { required: 'Debe indicar el Fin de vigencia' },
TIP_PLAN: { required: 'Debe indicar el Plan' },
TIP_VIAJE: { required: 'Debe indicar el Tipo de viaje' },
FEC_VIAJE: { required: 'Debe indicar el Fecha de inicio del viaje' },
DES_DESTINO: { required: 'Debe indicar el Lugar de destino' },
FEC_NACIMIENTO: { required: 'Debe indicar el Fecha de nacimiento' },
COD_MODALIDAD: { required: 'Debe indicar el Modalidad' },
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
                    checkbox: true
                },{
	field: 'codigo',
	title: 'Código',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'right',
    formatter: 'app.ui.IntegerFormatter',
    visible: true
},{
	field: 'nombre',
	title: 'Nombre',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
	field: 'capital',
	title: 'Capital',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'right',
    formatter: 'app.ui.DecimalFormatter',
    visible: true
},{
	field: 'primatotal',
	title: 'Prima total',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'right',
    formatter: 'app.ui.DecimalFormatter',
    visible: true
},{
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
},{
	field: 'fechadesde',
	title: 'Fecha desde',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'center',
    formatter: 'app.ui.DateFormatter',
    visible: true
},{
	field: 'fechahasta',
	title: 'Fecha hasta',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'center',
    formatter: 'app.ui.DateFormatter',
    visible: true
},{
	field: 'primaneta',
	title: 'Prima neta',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'right',
    formatter: 'app.ui.DecimalFormatter',
    visible: true
},{
	field: 'iVA',
	title: 'IVA',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'right',
    formatter: 'app.ui.DecimalFormatter',
    visible: true
},{
	field: 'recargoporfraccionamiento',
	title: 'Recargo por fraccionamiento',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'right',
    formatter: 'app.ui.DecimalFormatter',
    visible: true
},{
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
			catch(err) {
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


