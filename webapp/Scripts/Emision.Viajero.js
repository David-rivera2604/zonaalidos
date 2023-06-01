var app = app || {};

app.EmisionViajero = (function () {
    let workMode = '';
    var setupData = null;
    var changedCallback = null;
    var showCalculate = false;

    function Setup() {
        var _id = app.core.URLStringValue('presupuesto');
        if (_id != '') {
            workMode = app.core.URLStringValue('mode');
            $('#coberturasTbl').bootstrapTable('showLoading');
            app.core.Get(app.setting.apipath + 'v1/Issue/Viajero/' + _id + '?mode=' + workMode)
                .done(function (data) {
                    Init_Lookups(data);
                });
        }
    };

    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Issue/Viajero',
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
                    //$('#emitir').html('Emision Procesada');
                    $("#emitir").css("display", "none");


                    $('#emitir').addClass('d-none');
                    $('#tercerosNew').addClass('d-none');


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
                app.ui.ButtonDone('#emitir');
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
        $('#cantidad_riesgos').replaceWith('<div>' + $('#cantidad_riesgos').val() + '</div>');
        $('#FEC_NACIMIENTO_group').replaceWith('<div>' + $('#FEC_NACIMIENTO').val() + '</div>');
        $('#COD_MODALIDAD').replaceWith('<div>' + $('#COD_MODALIDAD option:selected').text() + '</div>');

    };

    function Init_Lookups(data) {
        setupData = JSON.parse(JSON.stringify(data));
        app.core.Lookups([
            'MonedasPorRamo.cod_mon', 'FrecuenciaDePagoPorRamo.cod_fracc_pago', 'TRON_G2990006:TIP_PLAN.TIP_PLAN',
            'TRON_G2990006:TIP_VIAJE.TIP_VIAJE', 'TRON_A1002090.COD_MODALIDAD',
            'Paises.cod_pais', 'Provincias.TProvincia'],
            function () {
                MapObjectToInput(data);
                ReadOnly();
            }, `cod_ramo=441:cod_mon=2:cod_pais=CRI`);

        // Dependencies events
        $('#TProvincia').on('change', function () {
            var pais = $('select#cod_pais').val();
            app.core.LookupDependency($('select#TProvincia').val(), 'TCanton', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
        });
        $('#TCanton').on('change', function () {
            var pais = $('select#cod_pais').val();
            app.core.LookupDependency($('select#TCanton').val(), 'TDistrito', 'Distritos', '', null, false, null, `cod_pais=${pais}:cod_prov=`);
        });
    };

    function MapInputToObject() {
        var data = setupData;

        data.terceros = $('#tercerosTbl').bootstrapTable('getData');
        data.documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');

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
        $('#DES_DESTINO').val(data.DES_DESTINO_DESC);
        $('#cantidad_riesgos').val(data.cantidad_riesgos);
        //app.ui.SetDateValue('#FEC_NACIMIENTO', data.FEC_NACIMIENTO);
        $('#COD_MODALIDAD').val(data.COD_MODALIDAD);
        app.ui.SetDropDownNumericValue('#COD_MODALIDAD', data.COD_MODALIDAD, true);
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

        $('#cod_pais').val(data.pais);
        $('#Tprovincia').val(data.provincia);
        $('#Tcanton').val(data.canton);
        $('#Tdistrito').val(data.distrito);
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

        $("#emitir").appendTo("#GenericToolBar");
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

        $('#emitir').click(function () {
            let others = OtherValidations();
            if (app.ui.IsValid('#VisualizationsEdtForm', false) && others === 0) {
                app.ui.ButtonDoing('#emitir');
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
            app.ui.ShowSideBar({ title: 'Enviar certificado por correo', subtitle: 'Póliza #{NUM_POLIZA}', id: 9000, data: { NUM_POLIZA: setupData.num_poliza, NUM_RIESGO: setupData.cantidad_riesgos * -1 } })
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
            rules: {
                cod_mon: { required: true },
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
            messages: {
                cod_mon: { required: 'Debe indicar el Moneda' },
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
    }

    function OtherValidations() {
        let result = 0;
        let message = 'Debe indicar la información de terceros';
        let terceros = $('#tercerosTbl').bootstrapTable('getData');
        let terceroserrors = (terceros.length === 0);

        if (!terceroserrors) {
            let holder = terceros.filter(i => i.tipodetercero === 0);
            let insured = terceros.filter(i => i.tipodetercero === 2);

            if (holder.length === 0 || holder[0].DocumentNumber === '') {
                let currentAseguradoTomador = terceros.find(e => e.tipodetercero === 2 && e.elaseguradoeselmismotomador === 1);
                if (currentAseguradoTomador == null) {
                    message += ', indique el tomador';
                    terceroserrors = true;
                }
            }
            if (insured.length === 0 || insured[0].DocumentNumber === '') {
                message += ', indique el asegurado';
                terceroserrors = true;
            }
        }
        if (terceroserrors) {
            $('#tercerosTbl-error').html(message);
            $('#tercerosTbl-error').removeClass('d-none');
            result = result + 1;
        }


        let grupo = 'F';
        let documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');
        let lista = documentosrequeridos.filter(function (row) {
            return (row.DStored === null || row.DStored === '');
        });
        if (lista.length > 0) {
            $('#documentosrequeridosTbl-error').html('Debe cargar todos los documentos pendientes');
            $('#documentosrequeridosTbl-error').removeClass('d-none');
            result = result + 1;
        }
        return result;
    }

    //Terceros

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
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'numeroderiesgo',
                    title: 'Riesgo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'DocumentNumber',
                    title: 'Identificación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'nombre',
                    title: 'Nombre completo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: function (value, row, index, field) {
                        let name = value + (row.apellido1 ? ' ' + row.apellido1 : '');
                        return `<span>${name}</span>`;
                    }
                }, {
                    field: 'fechadenacimiento',
                    title: 'Nacimiento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter'
                }, {
                    field: 'tercerosMca_sexoDesc',
                    title: 'Sexo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'estadoCivilDesc',
                    title: 'Estado Civil',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'numerodetelefono',
                    title: 'Teléfono',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'correoelectronico',
                    title: 'Correo electrónico',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'TProvinciaDesc',
                    title: 'Provincia',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'TCantonDesc',
                    title: 'Cantón',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'TDistritoDesc',
                    title: 'Distrito',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
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
                    title: 'El asegurado es el conductor habitual',
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
                    field: 'parentesco',
                    title: 'Parentesco',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'porcentaje',
                    title: 'Porcentaje',
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
                        let attribute = row.NoEditable ? " disabled" : "";
                        return '<button type="button"' + attribute + ' class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del tercero de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button"' + attribute + ' class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del tercero de la fila"> <i class="fa fa-close"></i> </button>';
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

                let row = terceros_table_row('values');
                let cloneBeneficiario = (row.elbeneficiarioeselmismotodoslosriesgos === 1);

                
                if (cloneBeneficiario) {
                    row.elbeneficiarioeselmismotodoslosriesgos = 2;
                    row.numeroderiesgo = 1;
                }
                if (row.tercerosId === null)
                    row.tercerosId = $('#tercerosTbl').bootstrapTable('getData').length + 1;

                if ($('#tercerosModal').data('id') != null) {
                    $('#tercerosTbl').bootstrapTable('updateByUniqueId', { id: row.tercerosId, row: row });
                }
                else {
                    $('#tercerosTbl').bootstrapTable('append', row);

                    if (row.eltomadoreselmismoasegurado === 1) {
                        terceros_clone(row, 2, 1, 1);
                    }
                    if (cloneBeneficiario) {
                        terceros_clone(row, 6, 2, setupData.cantidad_riesgos);
                    }
                }

                if (row.tipodetercero === 2) {
                    $('#correoenvio').val(row.correoelectronico);
                }

                app.ui.ButtonDone('#tercerosEdtFormSave')
                $('#tercerosModal').modal('hide');
            }
        });

    }

    function terceros_clone(row, rol, num_riesgo_ini, num_riesgo_fin) {
        let tbl = $('#tercerosTbl');
        for (index = num_riesgo_ini; index <= num_riesgo_fin; index++) {
            let newinsurance = JSON.parse(JSON.stringify(row));
            newinsurance.tercerosId = tbl.bootstrapTable('getData').length + 1;
            newinsurance.numeroderiesgo = index;
            newinsurance.tipodetercero = rol;
            newinsurance.tipodeterceroDesc = $('#tipodetercero option[value="' + rol + '"]').text();
            newinsurance.eltomadoreselmismoasegurado = 2;
            newinsurance.elaseguradoeselconductorhabitual = 2;
            newinsurance.elbeneficiarioeselmismotodoslosriesgos = 2;
            tbl.bootstrapTable('append', newinsurance);
        }
    }

    function terceros_table_row(mode) {
        if (mode == null) {
            return {
                tercerosId: null,
                tipodetercero: 2,
                numeroderiesgo: 1,
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
                eltomadoreselmismoasegurado: 2,
                elaseguradoeselconductorhabitual: 2,
                elbeneficiarioeselmismotodoslosriesgos: 2,
                elaseguradoeselmismotomador: 2,
                reutilizarestadireccion: false,
                numerodeprestamo: null,
                importedecesion: null,
                vencimientodecesion: null,
                porcentajeacredor: null,
                parentesco: null,
                porcentaje: null,
                NoEditable: false
            };
        }
        else {
            return {
                tercerosId: $('#tercerosModal').data('id'),
                tipodetercero: app.ui.GetDropDownNumericValue('#tipodetercero'),
                tipodeterceroDesc: $('#tipodetercero option:selected').text(),
                numeroderiesgo: app.ui.GetNumericValue('#numeroderiesgo'),
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
                elaseguradoeselmismotomador: app.ui.GetRadioNumericValue('elaseguradoeselmismotomador'),
                elaseguradoeselconductorhabitual: app.ui.GetRadioNumericValue('elaseguradoeselconductorhabitual'),
                elbeneficiarioeselmismotodoslosriesgos: app.ui.GetRadioNumericValue('elbeneficiarioeselmismotodoslosriesgos'),
                numerodeprestamo: $('#numerodeprestamo').val(),
                importedecesion: app.ui.GetNumericValue('#importedecesion'),
                vencimientodecesion: app.ui.GetDateValue('#vencimientodecesion'),
                porcentajeacredor: app.ui.GetNumericValue('#porcentajeacredor'),
                parentesco: $('#parentesco').val(),
                parentescoDesc: $('#parentesco option:selected').text(),
                porcentaje: app.ui.GetNumericValue('#porcentaje'),
                reutilizarestadireccion: $('#reutilizarestadireccion').is(':checked'),
                NoEditable: false
            };
        }
    }

    function terceros_table_row_edit(row) {
        var md = $('#tercerosModal').modal({ show: false });
        var formInstance = $("#tercerosEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();

        row = row || terceros_table_row();
        md.data('id', row.tercerosId);

        $('#tipodetercero').val(row.tipodetercero);

        let terceros = $('#tercerosTbl').bootstrapTable('getData');

        let currentTomador = terceros.find(e => e.tipodetercero === 0);
        let currentAseguradoTomador = terceros.find(e => e.tipodetercero === 2 && e.elaseguradoeselmismotomador === 1);
        let direccion = terceros.find(e => e.reutilizarestadireccion);
        if ((currentTomador && currentTomador.tercerosId != row.tercerosId) || (currentAseguradoTomador && currentAseguradoTomador.tercerosId != row.tercerosId)) {
            $('#tipodetercero option[value=0]').attr('hidden', '');
        } else {
            $('#tipodetercero option[value=0]').removeAttr('hidden');
        }
        if (currentAseguradoTomador && currentAseguradoTomador.tercerosId != row.tercerosId) {
            $('[name=elaseguradoeselmismotomador]').first().parent().parent().parent().parent().addClass('d-none');
        } else {
            $('[name=elaseguradoeselmismotomador]').first().parent().parent().parent().parent().removeClass('d-none');
        }

        if (direccion) {
            $('#reutilizarestadireccion').parent().addClass('d-none');
            if (row.otrasenas === '') {
                row.cod_pais = direccion.cod_pais;
                row.TProvincia = direccion.TProvincia;
                row.TCanton = direccion.TCanton;
                row.TDistrito = direccion.TDistrito;
                row.otrasenas = direccion.otrasenas;
            }
        } else {
            $('#reutilizarestadireccion').parent().removeClass('d-none');
        }

        let currentBeneficiario = terceros.find(e => e.tipodetercero === 6);
        if (currentBeneficiario && currentBeneficiario.elbeneficiarioeselmismotodoslosriesgos === 1 && currentBeneficiario.tercerosId != row.tercerosId) {
            $('#tipodetercero option[value=6]').attr('hidden', '');
        } else {
            $('#tipodetercero option[value=6]').removeAttr('hidden');
        }

        app.ui.SetDocumentTypeValue('#DocumentNumberType', row.DocumentNumberType);
        terceros_documentTypeCallBack(row.DocumentNumberType);
        app.ui.SetNumericValue('#numeroderiesgo', row.numeroderiesgo);
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
        app.ui.SetRadioNumericValue('elaseguradoeselmismotomador', row.elaseguradoeselmismotomador)
        app.ui.SetRadioNumericValue('elbeneficiarioeselmismotodoslosriesgos', row.elbeneficiarioeselmismotodoslosriesgos)
        $('#numerodeprestamo').val(row.numerodeprestamo);
        app.ui.SetNumericValue('#importedecesion', row.importedecesion);
        app.ui.SetDateValue('#vencimientodecesion', row.vencimientodecesion);
        app.ui.SetNumericValue('#porcentajeacredor', row.porcentajeacredor);
        app.ui.SetNumericValue('#porcentaje', row.porcentaje);
        $('#reutilizarestadireccion').prop('checked', row.reutilizarestadireccion)
        //terceros_tipodeterceroHandler();

        md.modal('show');
    };

    function terceros_table_row_delete(row) {
        $('#tercerosTbl').bootstrapTable('removeByUniqueId', row.tercerosId);
    }

    function terceros_table_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#tercerosEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                tipodetercero: { required: true },
                numeroderiesgo: { required: true },
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
                parentesco: { required: true },
                porcentaje: { required: true, Numeric: true },
            },
            messages: {
                tipodetercero: { required: 'Debe indicar el tipo de tercero' },
                numeroderiesgo: { required: 'Debe indicar el número de riesgo' },
                DocumentNumber: { required: 'Debe indicar la identificación' },
                nombre: { required: 'Debe indicar el nombre' },
                apellido1: { required: 'Debe indicar el apellido 1' },
                apellido2: { required: 'Debe indicar el apellido 2' },
                fechadenacimiento: { required: 'Debe indicar la fecha de nacimiento' },
                tercerosMca_sexo: { required: 'Debe indicar el sexo' },
                estadoCivil: { required: 'Debe indicar el estado Civil' },
                numerodetelefono: { required: 'Debe indicar el número de teléfono' },
                correoelectronico: { email: 'Debe indicar un correo electrónico valido', required: 'Debe indicar el correo electrónico' },
                cod_pais: { required: 'Debe indicar el país' },
                TProvincia: { required: 'Debe indicar la provincia' },
                TCanton: { required: 'Debe indicar el cantón' },
                TDistrito: { required: 'Debe indicar el distrito' },
                otrasenas: { required: 'Debe indicar las otra señas' },
                vencimientodecesion: { required: 'Debe indicar el vencimiento de cesión' },
                parentesco: { required: 'Debe indicar el parentesco' },
                porcentaje: { required: 'Debe indicar el porcentaje', Numeric: 'Debe indicar el porcentaje' },
            }
        });
    }

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
            maximumValue: '100',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#porcentaje', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#numeroderiesgo', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99',
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
            if (app.ui.GetDateValue('#fechadenacimiento') === '0001-01-01T00:00:00') {
                app.ui.SetDateValue('#fechadenacimiento', data.BirthDate);
            }
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

    function terceros_documentTypeCallBack(data) {
        data = $("#DocumentNumberType").data("value");
        if (data === 4) {
            $('#apellido1').parent().parent().addClass('d-none');
            $('#apellido2').parent().parent().addClass('d-none');
            $('#fechadenacimiento').parent().parent().parent().addClass('d-none');
            $('#tercerosMca_sexo').parent().parent().addClass('d-none');
            $('#estadoCivil').parent().parent().addClass('d-none');
            $('#nombre').parent().parent().addClass('col-sm-8 col-md-8');

        } else {
            $('#apellido1').parent().parent().removeClass('d-none');
            $('#apellido2').parent().parent().removeClass('d-none');
            $('#fechadenacimiento').parent().parent().parent().removeClass('d-none');
            $('#tercerosMca_sexo').parent().parent().removeClass('d-none');
            $('#estadoCivil').parent().parent().removeClass('d-none');
            $('#nombre').parent().parent().removeClass('col-sm-8 col-md-8');
        }
    }

    function terceros_controls_Events() {
        app.ui.DocumentNumberHandler('#DocumentNumber', terceros_documentNumberCallBack, terceros_documentTypeCallBack);

        $('#tipodetercero').change(function () {

            terceros_tipodeterceroHandler();
        });

    }

    function terceros_tipodeterceroHandler() {
        let terceros = $('#tercerosTbl').bootstrapTable('getData');
        let currentAseguradoTomador = terceros.find(e => e.tipodetercero === 2 && e.elaseguradoeselmismotomador === 1);

        switch ($('#tipodetercero').val()) {
            case '0':
                //$('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().removeClass('d-none');
                //$('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().removeClass('d-none');
                $('[name=elaseguradoeselmismotomador]').first().parent().parent().parent().parent().addClass('d-none');
                $('[name=elbeneficiarioeselmismotodoslosriesgos]').first().parent().parent().parent().parent().addClass('d-none');
                $('#beneficiarioZone').addClass('d-none');
                $('#acredorZone').addClass('d-none');
                break;
            case '2':
                $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                if (currentAseguradoTomador) {
                    $('[name=elaseguradoeselmismotomador]').first().parent().parent().parent().parent().addClass('d-none');
                } else {
                    $('[name=elaseguradoeselmismotomador]').first().parent().parent().parent().parent().removeClass('d-none');
                }
                $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().removeClass('d-none');
                $('[name=elbeneficiarioeselmismotodoslosriesgos]').first().parent().parent().parent().parent().addClass('d-none');
                $('#beneficiarioZone').addClass('d-none');
                $('#acredorZone').addClass('d-none');
                break;
            case '3':
                $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                $('[name=elaseguradoeselmismotomador]').first().parent().parent().parent().parent().addClass('d-none');
                $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().addClass('d-none');
                $('[name=elbeneficiarioeselmismotodoslosriesgos]').first().parent().parent().parent().parent().addClass('d-none');
                $('#beneficiarioZone').addClass('d-none');
                $('#acredorZone').addClass('d-none');
                break;
            case '6':
                $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                $('[name=elaseguradoeselmismotomador]').first().parent().parent().parent().parent().addClass('d-none');
                $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().addClass('d-none');
                $('[name=elbeneficiarioeselmismotodoslosriesgos]').first().parent().parent().parent().parent().removeClass('d-none');
                $('#beneficiarioZone').removeClass('d-none');
                $('#acredorZone').addClass('d-none');
                break;
            case '8':
                $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                $('[name=elaseguradoeselmismotomador]').first().parent().parent().parent().parent().addClass('d-none');
                $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().addClass('d-none');
                $('[name=elbeneficiarioeselmismotodoslosriesgos]').first().parent().parent().parent().parent().addClass('d-none');
                $('#beneficiarioZone').addClass('d-none');
                $('#acredorZone').removeClass('d-none');
                break;
        }
    }

    //Documentos Requeridos
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
    }

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
    }

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
    }

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
    }

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
    }

    function documentosrequeridos_controls_setup() {
    }

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
        toastr.warning("Si está seguro de querer eliminar el tercero '" + row.nombre + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionViajero.tercerosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionViajero.tercerosEditRow(row);
        e.stopPropagation();
    }
};
window.documentosrequeridosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer limpiar el documento requerido '" + row.DNombre + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionViajero.documentosrequeridosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionViajero.documentosrequeridosEditRow(row);
        e.stopPropagation();
    }
};