var app = app || {};

app.EmisionSaldoDeudor = (function () {

    let setupData = null;
    let workMode = '';
    let changedCallback = null;
    let CapitalCtrls = [];

    function Setup() {
        let _id = app.core.URLStringValue('presupuesto');
        if (_id != '') {
            workMode = app.core.URLStringValue('mode');
            app.core.Get(app.setting.apipath + 'v1/Issue/SaldoDeudor/' + _id + '?mode=' + workMode, null,
                function (data) {
                    setupData = data;
                    app.core.Lookups(['MonedasPorRamo.cod_mon', 'FrecuenciaDePagoPorRamo.cod_fracc_pago', 'TRON_G2990004.COD_MODALIDAD_RIESGO', 'TRON_G2990006:COD_CIA_ORI.COD_CIA_ORI', 'TRON_G2990006:TIP_NEGOCIO.TIP_NEGOCIO', 'TRON_G7000210.COD_ENF_EXC', 'TRON_G1010031:COD_TIP_EXC.COD_TIP_EXC', 'Paises.cod_pais', 'Provincias.TProvincia'],
                        function () {
                            setupData = data;
                            MapObjectToInput(data);
                            Dynamic_Event_Controls();
                            ReadOnly();
                            $('#plandepagoporfrecuencia').removeClass('d-none');
                        }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}:cod_pais=CRI`);

                });
        }
    };

    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Issue/SaldoDeudor',
            JSON.stringify(MapInputToObject()),
            function (data) {
                quoteData = data;
                if (!app.ui.NotifyErrors(data.Mensaje, data.Errors, '#SaldoDeudorEdtForm')) {

                    $('#NumPoliza').html(data.num_poliza);
                    $('#cotizar').addClass('d-none');

                    $('#coberturasRow').removeClass('d-none');
                    $('#coberturasTbl').bootstrapTable('load', data.coberturas);
                    Coberturas_ManejoGeneral();
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

    function Dynamic_Event_Controls() {
        $('input:radio[name=MCA_NEGOCIO_MIGRADO]').on('change', function () {
            if (app.ui.GetRadioStringValue('MCA_NEGOCIO_MIGRADO') == 'S')
                $('.MCA_NEGOCIO_MIGRADO_SHOW').removeClass('d-none');
            else
                $('.MCA_NEGOCIO_MIGRADO_SHOW').addClass('d-none');
        });
        $('#TIP_NEGOCIO').on('change', function () {

            if (app.ui.GetDropDownStringValue('#TIP_NEGOCIO') == 'A')
                $('.TIP_NEGOCIO_SHOW').removeClass('d-none');
            else
                $('.TIP_NEGOCIO_SHOW').addClass('d-none');
        });
    };

    function ReadOnly() {
        $('#cod_mon').replaceWith('<div>' + $('#cod_mon option:selected').text() + '</div>');
        $('#cod_fracc_pago').replaceWith('<div>' + $('#cod_fracc_pago option:selected').text() + '</div>');
        $('#fec_efec_poliza_group').replaceWith('<div>' + $('#fec_efec_poliza').val() + '</div>');
        $('#fec_vcto_poliza_group').replaceWith('<div>' + $('#fec_vcto_poliza').val() + '</div>');
        $('#FEC_NACIMIENTO_group').replaceWith('<div>' + $('#FEC_NACIMIENTO').val() + '</div>');
        $('label[for=MCA_SEXO').next().replaceWith('<div>' + $('label[for=MCA_SEXO_' + app.ui.GetRadioNumericValue('MCA_SEXO') + '').html() + '</div>');

        $('#NUM_ESTATURA_CM').parent().replaceWith('<div>' + $('#NUM_ESTATURA_CM').val() + ' cm</div>');
        $('#NUM_PESO').parent().replaceWith('<div>' + $('#NUM_PESO').val() + ' lbs</div>');
        $('#NUM_IMC').parent().replaceWith('<div>' + $('#NUM_IMC').val() + ' IMC</div>');


        $('#COD_MODALIDAD_RIESGO').replaceWith('<div>' + $('#COD_MODALIDAD_RIESGO option:selected').text() + '</div>');
        $('label[for=MCA_NEGOCIO_MIGRADO').next().replaceWith('<div>' + $('label[for=MCA_NEGOCIO_MIGRADO_' + app.ui.GetRadioStringValue('MCA_NEGOCIO_MIGRADO') + '').html() + '</div>');
        $('#COD_CIA_ORI').replaceWith('<div>' + $('#COD_CIA_ORI option:selected').text() + '</div>');
        $('#FEC_EMISION_ORI_group').replaceWith('<div>' + $('#FEC_EMISION_ORI').val() + '</div>');
        $('#IMP_MONTO_ORI').replaceWith('<div>' + $('#IMP_MONTO_ORI').val() + '</div>');
        $('#IMP_SLD_ACTUAL').replaceWith('<div>' + $('#IMP_SLD_ACTUAL').val() + '</div>');
        $('#NUM_PRESTAMO').replaceWith('<div>' + $('#NUM_PRESTAMO').val() + '</div>');
        $('#TIP_NEGOCIO').replaceWith('<div>' + $('#TIP_NEGOCIO option:selected').text() + '</div>');
        $('#IMP_PRIMA_INFORMADA').replaceWith('<div>' + $('#IMP_PRIMA_INFORMADA').val() + '</div>');
        $('#IMP_GASTOS_EMISION').replaceWith('<div>' + $('#IMP_GASTOS_EMISION').val() + '</div>');
        $('#PCT_DTO_COMERCIAL').parent().replaceWith('<div>' + $('#PCT_DTO_COMERCIAL').val() + ' %</div>');
        $('#PCT_DCTO_TECNICO').parent().replaceWith('<div>' + $('#PCT_DCTO_TECNICO').val() + ' %</div>');
        $('#FEC_PRIM_FINAN_group').replaceWith('<div>' + $('#FEC_PRIM_FINAN').val() + '</div>');
        $('#enfermedadesexcluidasNew').addClass('d-none');
        $('#enfermedadesexcluidasTbl').bootstrapTable('hideColumn', 'Actions');

    };

    function MapInputToObject() {
        let data = setupData;

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
        $('#FEC_FIN_EXC_group').data("DateTimePicker").minDate($('#FEC_INI_EXC_group').data("DateTimePicker").date());
        app.ui.SetDateValue('#fec_vcto_poliza', data.fec_vcto_poliza);
        app.ui.SetDateValue('#FEC_NACIMIENTO', data.FEC_NACIMIENTO);
        app.ui.SetRadioStringValue('MCA_SEXO', data.MCA_SEXO);
        app.ui.SetNumericValue('#NUM_ESTATURA_CM', data.NUM_ESTATURA_CM);
        app.ui.SetNumericValue('#NUM_PESO', data.NUM_PESO);
        app.ui.SetNumericValue('#NUM_IMC', data.NUM_IMC);
        $('#COD_MODALIDAD_RIESGO').val(data.COD_MODALIDAD_RIESGO);
        app.ui.SetDropDownNumericValue('#COD_MODALIDAD_RIESGO', data.COD_MODALIDAD_RIESGO, true, 40101);
        app.ui.SetRadioStringValue('MCA_NEGOCIO_MIGRADO', data.MCA_NEGOCIO_MIGRADO);
        $('#COD_CIA_ORI').val(data.COD_CIA_ORI);
        app.ui.SetDropDownNumericValue('#COD_CIA_ORI', data.COD_CIA_ORI, true);
        app.ui.SetDateValue('#FEC_EMISION_ORI', data.FEC_EMISION_ORI);
        app.ui.SetNumericValue('#IMP_MONTO_ORI', data.IMP_MONTO_ORI);
        app.ui.SetNumericValue('#IMP_SLD_ACTUAL', data.IMP_SLD_ACTUAL);
        $('#NUM_PRESTAMO').val(data.NUM_PRESTAMO);
        $('#TIP_NEGOCIO').val(data.TIP_NEGOCIO);
        app.ui.SetDropDownStringValue('#TIP_NEGOCIO', data.TIP_NEGOCIO, true, 'R');
        app.ui.SetNumericValue('#IMP_PRIMA_INFORMADA', data.IMP_PRIMA_INFORMADA);
        app.ui.SetNumericValue('#IMP_GASTOS_EMISION', data.IMP_GASTOS_EMISION);
        app.ui.SetNumericValue('#PCT_DTO_COMERCIAL', data.PCT_DTO_COMERCIAL);
        app.ui.SetNumericValue('#PCT_DCTO_TECNICO', data.PCT_DCTO_TECNICO);
        app.ui.SetDateValue('#FEC_PRIM_FINAN', data.FEC_PRIM_FINAN);
        if (data.enfermedadesexcluidas != null)
            $('#enfermedadesexcluidasTbl').bootstrapTable('load', data.enfermedadesexcluidas);
        else
            $('#enfermedadesexcluidasTbl').bootstrapTable('load', {});
        if (data.coberturas != null)
            $('#coberturasTbl').bootstrapTable('load', data.coberturas);
        else
            $('#coberturasTbl').bootstrapTable('load', {});
        Coberturas_ManejoGeneral();
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
        $('#FEC_NACIMIENTO_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#NUM_ESTATURA_CM', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: 2
        });
        new AutoNumeric('#NUM_PESO', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: 2
        });
        new AutoNumeric('#NUM_IMC', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: 2
        });
        $('#FEC_EMISION_ORI_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#IMP_MONTO_ORI', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_SLD_ACTUAL', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_PRIMA_INFORMADA', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_GASTOS_EMISION', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#PCT_DTO_COMERCIAL', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#PCT_DCTO_TECNICO', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        $('#FEC_PRIM_FINAN_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#FEC_INI_EXC_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#FEC_FIN_EXC_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });

        $("#cotizar").appendTo("#GenericToolBar");

        $('#IMP_MONTO_ORI').change(function () {
            let value = app.ui.GetNumericValue('#IMP_MONTO_ORI');
            // 4001	A - MUERTE POR CUALQUIER CAUSA
            app.ui.SetNumericValue('#CapitalRow_0', value);
        });

        $('#COD_ENF_EXC').select2({
            width: '100%', theme: 'bootstrap4', dropdownParent: $("#enfermedadesexcluidasModal .modal-content"),
            language: { noResults: function () { return "No hay resultado"; }, searching: function () { return "Buscando.."; } }
        });
    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#SaldoDeudorEdtForm :input").change(function () {
            data_changed();
        });

        $('#FEC_INI_EXC').blur(function () {
            var minDate = app.ui.GetDateRawValue('#FEC_INI_EXC');
            minDate.setDate(minDate.getDate());

            $('#FEC_FIN_EXC_group').data("DateTimePicker").minDate(minDate);
        });

        $('#cotizar').click(function () {
            if (app.ui.IsValid('#SaldoDeudorEdtForm', false, true, OtherValidations()) ) {
                app.ui.ButtonDoing('#cotizar');
                Quote();
            }
            event.preventDefault();
        });

    };

    function OtherValidations() {
        let result = [];
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
            result.push({ id: '#tercerosTbl-error', message: message });
        }

        let grupo = 'F';
        let documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');
        let lista = documentosrequeridos.filter(function (row) {
            return (row.DStored === null || row.DStored === '');
        });
        if (lista.length > 0) {
            $('#documentosrequeridosTbl-error').html('Debe cargar todos los documentos pendientes');
            $('#documentosrequeridosTbl-error').removeClass('d-none');
            result.push({ id: '#documentosrequeridosTbl-error', message: 'Debe cargar todos los documentos pendientes' });
        }
        return result;
    }

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#SaldoDeudorEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                cod_mon: { required: true },
                cod_fracc_pago: { required: true },
                fec_efec_poliza: { required: true },
                fec_vcto_poliza: { required: true },
                FEC_NACIMIENTO: { required: true },
                MCA_SEXO: { required: true },
                COD_MODALIDAD_RIESGO: { required: true },
                MCA_NEGOCIO_MIGRADO: { required: true },
                COD_CIA_ORI: { required: true },
                FEC_EMISION_ORI: { required: true },
                IMP_MONTO_ORI: { required: true, Numeric: true },
                NUM_PRESTAMO: { required: true },
                TIP_NEGOCIO: { required: true },
            },
            messages: {
                cod_mon: { required: 'Debe indicar la moneda' },
                cod_fracc_pago: { required: 'Debe indicar el fraccionamiento de pago' },
                fec_efec_poliza: { required: 'Debe indicar el inicio de vigencia' },
                fec_vcto_poliza: { required: 'Debe indicar el in de vigencia' },
                FEC_NACIMIENTO: { required: 'Debe indicar la fecha de nacimiento' },
                MCA_SEXO: { required: 'Debe indicar el sexo' },
                COD_MODALIDAD_RIESGO: { required: 'Debe indicar la modalidad de riesgo' },
                MCA_NEGOCIO_MIGRADO: { required: 'Debe indicar si es un negocio migrado' },
                COD_CIA_ORI: { required: 'Debe indicar la compañía original' },
                FEC_EMISION_ORI: { required: 'Debe indicar la fecha de emisión original' },
                IMP_MONTO_ORI: { required: 'Debe indicar el monto original del préstamo', Numeric: 'Debe indicar el monto original del préstamo' },
                NUM_PRESTAMO: { required: 'Debe indicar el número de préstamo' },
                TIP_NEGOCIO: { required: 'Debe indicar el tipo de negocio' },
            }
        });
    };

    function enfermedadesexcluidas_table_setup() {

        $('#enfermedadesexcluidasTbl').bootstrapTable({
            uniqueId: 'enfermedadesexcluidasId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'NOM_ENF_EXC',
                    title: 'Enfermedad',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'NOM_TIP_EXC',
                    title: 'Tipo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'FEC_INI_EXC',
                    title: 'Fecha inicio',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'FEC_FIN_EXC',
                    title: 'Fecha fin',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'TXT_OBS_ENF_EXC',
                    title: 'Observaciones',
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
                    events: 'enfermedadesexcluidasTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del visualizations de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del visualizations de la fila"> <i class="fa fa-close"></i> </button>';
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

        $('#enfermedadesexcluidasNew').click(function () {
            enfermedadesexcluidas_table_row_edit();
        });

        $('#enfermedadesexcluidasEdtFormSave').click(function () {
            if (app.ui.IsValid('#enfermedadesexcluidasEdtForm', false)) {
                app.ui.ButtonDoing('#enfermedadesexcluidasEdtFormSave');

                var row = enfermedadesexcluidas_table_row('values');

                if (row.enfermedadesexcluidasId === null)
                    row.enfermedadesexcluidasId = 1;

                if ($('#enfermedadesexcluidasModal').data('id') != null) {
                    $('#enfermedadesexcluidasTbl').bootstrapTable('updateByUniqueId', { id: row.enfermedadesexcluidasId, row: row });
                }
                else {
                    $('#enfermedadesexcluidasTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#enfermedadesexcluidasEdtFormSave')
                $('#enfermedadesexcluidasModal').modal('hide');
            }
        });

    };

    function enfermedadesexcluidas_table_row(mode) {
        if (mode == null) {
            return {
                enfermedadesexcluidasId: null,
                COD_ENF_EXC: null,
                NOM_ENF_EXC: null,
                TXT_OBS_ENF_EXC: null,
                COD_TIP_EXC: null,
                NOM_TIP_EXC: null,
                FEC_INI_EXC: null,
                FEC_FIN_EXC: null
            };
        }
        else {
            return {
                enfermedadesexcluidasId: $('#enfermedadesexcluidasModal').data('id'),
                COD_ENF_EXC: $('#COD_ENF_EXC').val(),
                NOM_ENF_EXC: $("#COD_ENF_EXC option:selected").text(),
                TXT_OBS_ENF_EXC: $('#TXT_OBS_ENF_EXC').val(),
                COD_TIP_EXC: $('#COD_TIP_EXC').val(),
                NOM_TIP_EXC: $("#COD_TIP_EXC option:selected").text(),
                FEC_INI_EXC: app.ui.GetDateValue('#FEC_INI_EXC'),
                FEC_FIN_EXC: app.ui.GetDateValue('#FEC_FIN_EXC')
            };
        }
    };

    function enfermedadesexcluidas_table_row_edit(row) {
        var md = $('#enfermedadesexcluidasModal').modal({ show: false });
        var formInstance = $("#enfermedadesexcluidasEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || enfermedadesexcluidas_table_row();
        md.data('id', row.enfermedadesexcluidasId);

        $('#COD_ENF_EXC').val(row.COD_ENF_EXC);
        $('#TXT_OBS_ENF_EXC').val(row.TXT_OBS_ENF_EXC);
        $('#COD_TIP_EXC').val(row.COD_TIP_EXC);
        app.ui.SetDateValue('#FEC_INI_EXC', row.FEC_INI_EXC);
        app.ui.SetDateValue('#FEC_FIN_EXC', row.FEC_FIN_EXC);


        md.modal('show');
    };

    function enfermedadesexcluidas_table_row_delete(row) {
        $('#enfermedadesexcluidasTbl').bootstrapTable('removeByUniqueId', row.enfermedadesexcluidasId);
    };

    function enfermedadesexcluidas_table_Validations() {
        app.ui.DateValidators();
        $("#enfermedadesexcluidasEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                COD_ENF_EXC: { required: true },
                COD_TIP_EXC: { required: true },
                FEC_INI_EXC: { required: true },
                FEC_FIN_EXC: { required: true },
            },
            messages: {
                COD_ENF_EXC: { required: 'Debe indicar el Enfermedades' },
                COD_TIP_EXC: { required: 'Debe indicar el Tipo exclusión' },
                FEC_INI_EXC: { required: 'Debe indicar el Fecha inicio de exclusión' },
                FEC_FIN_EXC: { required: 'Debe indicar el Fecha fin de exclusión' },
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
                    formatter: function (value, row, index, field) {
                        if (row.edtCapital)
                            return '<input id="CapitalRow_' + index + '" name="CapitalGridEdit" type="text" class="form-control grid-control text-right" size="21" maxlength="21" disabled placeholder="Indique el capital">';
                        else
                            if (value == undefined || value === null || value === 0)
                                return '';
                            else
                                return value.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                    }
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

        $('#coberturasTbl').on('check.bs.table', function () {
            Coberturas_ManejoGeneral2();
        });
        $('#coberturasTbl').on('uncheck.bs.table', function () {
            Coberturas_ManejoGeneral2();
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

    function Coberturas_ManejoGeneral2() {
        coberturas = $('#coberturasTbl').bootstrapTable('getData');
        coberturas.forEach(function (currentValue, index) {
            if (currentValue.edtCapital) {
                if (!currentValue.requerida)
                    $('#CapitalRow_' + index).prop('disabled', !currentValue.seleccionado);
                if (currentValue.capital == null || currentValue.capital == 0)
                    app.ui.SetNumericValue('#CapitalRow_' + index, '');
                else
                    app.ui.SetNumericValue('#CapitalRow_' + index, currentValue.capital);
            }
        });
    };
    function Coberturas_ManejoGeneral() {
        CapitalCtrls.forEach(element => element.wipe());
        CapitalCtrls = [];
        $('input[name="CapitalGridEdit"]').each(function () {
            CapitalCtrls.push(new AutoNumeric(this, {
                decimalCharacter: ',',
                decimalCharacterAlternative: '.',
                digitGroupSeparator: '.',
                maximumValue: '99999999999999',
                minimumValue: '0',
                decimalPlaces: '0',
                emptyInputBehavior: 'null'
            }));
        });

        coberturas = $('#coberturasTbl').bootstrapTable('getData');
        coberturas.forEach(function (currentValue, index) {
            if (currentValue.edtCapital)
                if (currentValue.capital == null || currentValue.capital == 0)
                    app.ui.SetNumericValue('#CapitalRow_' + index, '');
                else
                    app.ui.SetNumericValue('#CapitalRow_' + index, currentValue.capital);
        });

        coberturas.forEach(function (value, index, array) {
            $('[name=btSelectItem][data-index=' + index + ']').prop('disabled', value.requerida);
        });
        $('[name=btSelectAll]').prop('disabled', true);
        Coberturas_ManejoGeneral2();
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
            $('#tipodetercero').val($('#tipodetercero option[disabled!="disabled"]')[0].value);
            $('#tipodetercero').change();
            terceros_table_row_edit();
        });

        $('#tercerosEdtFormSave').click(function () {
            if (app.ui.IsValid('#tercerosEdtForm', false)) {
                app.ui.ButtonDoing('#tercerosEdtFormSave');

                var row = terceros_table_row('values');

                if (row.tercerosId === null)
                    row.tercerosId = $('#tercerosTbl').bootstrapTable('getData').length + 1;

                if ($('#tercerosModal').data('id') != null) {
                    $('#tercerosTbl').bootstrapTable('updateByUniqueId', { id: row.tercerosId, row: row });
                }
                else {
                    $('#tercerosTbl').bootstrapTable('append', row);

                    if (row.eltomadoreselmismoasegurado === 1) {
                        let newinsurance = JSON.parse(JSON.stringify(row));
                        newinsurance.tercerosId += 1;
                        newinsurance.tipodetercero = 2;
                        newinsurance.tipodeterceroDesc = $('#tipodetercero option[value="2"]').text();
                        newinsurance.eltomadoreselmismoasegurado = 1;
                        newinsurance.elaseguradoeselconductorhabitual = 2;
                        $('#tercerosTbl').bootstrapTable('append', newinsurance);
                    }

                    if (row.elaseguradoeselconductorhabitual === 1) {
                        let newDriver = JSON.parse(JSON.stringify(row));
                        newDriver.tercerosId += 1;
                        newDriver.tipodetercero = 3;
                        newDriver.tipodeterceroDesc = $('#tipodetercero option[value="3"]').text();
                        newDriver.eltomadoreselmismoasegurado = 1;
                        newDriver.elaseguradoeselconductorhabitual = 2;
                        $('#tercerosTbl').bootstrapTable('append', newDriver);
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

    function terceros_table_row(mode) {
        if (mode == null) {
            return {
                tercerosId: null,
                tipodetercero: $('#tipodetercero').val(),
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
                elaseguradoeselconductorhabitual: app.ui.GetRadioNumericValue('elaseguradoeselconductorhabitual'),
                numerodeprestamo: $('#numerodeprestamo').val(),
                importedecesion: app.ui.GetNumericValue('#importedecesion'),
                vencimientodecesion: app.ui.GetDateValue('#vencimientodecesion'),
                porcentajeacredor: app.ui.GetNumericValue('#porcentajeacredor'),
                parentesco: $('#parentesco').val(),
                parentescoDesc: $('#parentesco option:selected').text(),
                //porcentaje: app.ui.GetNumericValue('#porcentaje'),
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
        app.ui.SetRadioNumericValue('elaseguradoeselconductorhabitual', row.elaseguradoeselconductorhabitual)
        $('#numerodeprestamo').val(row.numerodeprestamo);
        app.ui.SetNumericValue('#importedecesion', row.importedecesion);
        app.ui.SetDateValue('#vencimientodecesion', row.vencimientodecesion);
        app.ui.SetNumericValue('#porcentajeacredor', row.porcentajeacredor);
        $('#parentesco').val(row.parentesco);
        // app.ui.SetNumericValue('#porcentaje', row.porcentaje);


        md.modal('show');
    }

    function terceros_table_row_delete(row) {
        $('#tercerosTbl').bootstrapTable('removeByUniqueId', row.tercerosId);
    }

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
                parentesco: { required: true },
                porcentaje: { required: true },
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
                parentesco: { required: 'Debe indicar el Parentesco' },
                porcentaje: { required: 'Debe indicar el Porcentaje' },
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
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        //new AutoNumeric('#porcentaje', {
        //    decimalCharacter: ',',
        //    decimalCharacterAlternative: '.',
        //    digitGroupSeparator: '.',
        //    maximumValue: '999',
        //    minimumValue: '0',
        //    decimalPlaces: '0',
        //    emptyInputBehavior: 'null'
        //});

    }

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

        $('#tipodetercero').change(function () {
            switch ($('#tipodetercero').val()) {
                case '0':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().removeClass('d-none');
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().removeClass('d-none');
                    $('#beneficiarioZone').addClass('d-none');
                    $('#acredorZone').addClass('d-none');
                    break;
                case '2':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().removeClass('d-none');
                    $('#beneficiarioZone').addClass('d-none');
                    $('#acredorZone').addClass('d-none');
                    break;
                case '3':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().addClass('d-none');
                    $('#beneficiarioZone').addClass('d-none');
                    $('#acredorZone').addClass('d-none');
                    break;
                case '6':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().addClass('d-none');
                    $('#beneficiarioZone').removeClass('d-none');
                    $('#acredorZone').addClass('d-none');
                    break;
                case '8':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().addClass('d-none');
                    $('#beneficiarioZone').addClass('d-none');
                    $('#acredorZone').removeClass('d-none');
                    break;
            }

        });

    }

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
        Init: function () {
            try {
                Controls_setup();
                Setup_Validations();
                enfermedadesexcluidas_table_setup();
                enfermedadesexcluidas_table_Validations();
                coberturas_table_setup();
                plandepago_table_setup();
                plandepagoporfrecuencia_table_setup();

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
            return app.ui.IsValid('#SaldoDeudorEdtForm', false, showResume);
        },
        enfermedadesexcluidasEditRow: function (row) {
            enfermedadesexcluidas_table_row_edit(row);
        },
        enfermedadesexcluidasDeleteRow: function (row) {
            enfermedadesexcluidas_table_row_delete(row);
        }
    };
})();

window.enfermedadesexcluidasTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.enfermedadesexcluidasId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.SaldoDeudor.enfermedadesexcluidasDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.SaldoDeudor.enfermedadesexcluidasEditRow(row);
        e.stopPropagation();
    }
};

window.tercerosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el tercero '" + row.nombre + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMapfreMas.tercerosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionViajero.tercerosEditRow(row);
        e.stopPropagation();
    }
};

window.documentosrequeridosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer limpiar el documento requerido '" + row.DNombre + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMapfreMas.documentosrequeridosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionViajero.documentosrequeridosEditRow(row);
        e.stopPropagation();
    }
};