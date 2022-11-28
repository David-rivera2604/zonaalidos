var app = app || {};

app.EmisionSaldoDeudor = (function () {

    let setupData = null;
    let workMode = '';
    let changedCallback = null;
    let CapitalCtrls = [];
    let edad_asegurado = 0;
    let suma_asegurada = 0;

    function Setup() {
        let _id = app.core.URLStringValue('presupuesto');
        if (_id != '') {
            workMode = app.core.URLStringValue('mode');

            if (workMode === 'draft' || workMode === 'resume') {
                $('#guardarenviar').removeClass('d-none');
                $("#guardarenviar").appendTo("#GenericToolBar");
                $('#cotizar').addClass('d-none');
                $('.documentosrequeridosGrid').addClass('d-none');

                $('.datosgeneralesZone').removeClass('col-md-12');
                $('.datosgeneralesZone').addClass('col-md-7');
                $('.enviosolicitudZone').removeClass('d-none');
            } else {
                $('#cotizar').removeClass('d-none');
                $("#cotizar").appendTo("#GenericToolBar");
                $('#cuestionario_form').addClass('d-none');
                $('.enviosolicitudZone').addClass('d-none');
                
            }

            app.core.Get(app.setting.apipath + 'v1/Issue/SaldoDeudor/' + _id + '?mode=' + workMode, null,
                function (data) {
                    setupData = data;
                    app.core.Lookups(['MonedasPorRamo.cod_mon', 'FrecuenciaDePagoPorRamo.cod_fracc_pago', 'TRON_G2990004.COD_MODALIDAD_RIESGO', 'TRON_G2990006:COD_CIA_ORI.COD_CIA_ORI', 'TRON_G2990006:TIP_NEGOCIO.TIP_NEGOCIO', 'TRON_G7000210.COD_ENF_EXC', 'TRON_G1010031:COD_TIP_EXC.COD_TIP_EXC', 'Paises.cod_pais', 'Provincias.TProvincia'],
                        function () {
                            setupData = data;
                            workMode = data.Modo;
                            edad_asegurado = moment().diff(data.FEC_NACIMIENTO, 'years');
                            suma_asegurada = data.IMP_SLD_ACTUAL;
                            MapObjectToInput(data);
                            Dynamic_Event_Controls();
                            ReadOnly();
                            $('#plandepagoporfrecuencia').removeClass('d-none');
                            $('#plandepagoRow').removeClass('d-none');
                        }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}:cod_pais=CRI`);

                });
        }

       $("#tipodetercero option[value=0]").remove();
        /* $("#tipodetercero option[value=8]").remove();

        var array_codigo = ["6", "8"];
        var array_descripcion = ["Beneficiario(a)", "Acreedor(a)"];
        for (var i in array_codigo) {
            document.getElementById("tipodetercero").innerHTML += "<option value='" + array_codigo[i] + "'>" + array_descripcion[i] + "</option>";
        }*/
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


                    $('#mainBlock').removeClass('col-md-12');
                    $('#mainBlock').addClass('col-md-9');
                    $('#quoteBlock').removeClass('d-none');
                    $('#tercerosNew').addClass('d-none');
                    $('#tercerosTbl').bootstrapTable('hideColumn', 'Actions');
                    $('#documentosrequeridosNew').addClass('d-none');
                    $('#documentosrequeridosTbl').bootstrapTable('hideColumn', 'Actions');

                    showCalculate = true;
                    if (data.resumen != null) {
                        var moneda = "$ ";
                        if (data.cod_mon == 1) {
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

        data.Modo = app.core.URLStringValue('mode');
        data.tip_firma = $('#tip_firma').val();
        data.tip_firmaDesc = $("#tip_firma option:selected").text();
        data.correoenvio = $('#correoenvio').val();
        data.terceros = $('#tercerosTbl').bootstrapTable('getData');
        data.documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');

        //Datos Solcitud
        data.Questionary = [];
        for (index = 1; index <= 14; index++) {
            data.Questionary.push({
                QuestionId: index,
                Confirmation: $('input:radio[name=Confirmation_' + index + ']:checked').val(),
                Detail: $('#Diagnosis_' + index).val() + ' ' + $('#Treatment_' + index).val() + ' ' + $('#Doctor_' + index).val(), 
                Summary: $('#Diagnosis_' + index).val() + ' ' + $('#Treatment_' + index).val() + ' ' + $('#Doctor_' + index).val(),
                When: app.ui.GetDateValue('#When_' + index),
                Diagnosis: $('#Diagnosis_' + index).val(),
                Treatment: $('#Treatment_' + index).val(),
                Doctor: $('#Doctor_' + index).val(),
            });
        };

        
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

        if (data.terceros != null)
            $('#tercerosTbl').bootstrapTable('load', data.terceros);
        else
            $('#tercerosTbl').bootstrapTable('load', {});
        if (data.documentosrequeridos != null)
            $('#documentosrequeridosTbl').bootstrapTable('load', data.documentosrequeridos);
        else
            $('#documentosrequeridosTbl').bootstrapTable('load', {});

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
            if (app.ui.IsValid('#SaldoDeudorEdtForm', false, true, OtherValidations())) {
                app.ui.ButtonDoing('#cotizar');
                Quote();
            }
            event.preventDefault();
        });

        $('#guardarenviar').click(function () {
            var others = OtherValidations();
            var cuestionario_validations = Validations_Salud2();

            if (app.ui.IsValid('#SaldoDeudorEdtForm', false) && others.length === 0 && cuestionario_validations.length === 0) {
                app.ui.ButtonDoing('#guardarenviar');
                app.core.Post(app.setting.apipath + 'v1/Issue/SaldoDeudor',
                    JSON.stringify(MapInputToObject()),
                    function (data) {

                        $('#guardarenviar').addClass('d-none');
                        $('#Fuente_Tomador').replaceWith('<div>' + $('#Fuente_Tomador option:selected').text() + '</div>');
                        $('#Modalidad_Pago').replaceWith('<div>' + $('#Modalidad_Pago option:selected').text() + '</div>');
                        $('#tip_firma').replaceWith('<div>' + $('#tip_firma option:selected').text() + '</div>');
                        $('#correoenvio').replaceWith('<div>' + $('#correoenvio').val() + '</div>');

                        //ReadOnly_End();

                    }).always(function () {
                        app.ui.ButtonDone('#guardarenviar');
                    });
            }
            else {
                var instance = $('#SaldoDeudorEdtForm');
                var validate = instance.validate();
                validate.settings.ignore = '';
                var result = instance.valid();
                var count = validate.numberOfInvalids();
                validate.settings.ignore = ':hidden';
                toastr.error("Existen " + (count + others.length + cuestionario_validations.length) + " error(es), que ameritan su atención.", "", { closeButton: true, progressBar: true });
            }
            event.preventDefault();
        });

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

    function OtherValidations() {
        let result = [];
        let message = 'Debe indicar la información de terceros';
        let terceros = $('#tercerosTbl').bootstrapTable('getData');
        let terceroserrors = (terceros.length === 0);

        if (!terceroserrors) {
            let holder = terceros.filter(i => i.tipodetercero === 0);
            let insured = terceros.filter(i => i.tipodetercero === 2);

            //if (holder.length === 0 || holder[0].DocumentNumber === '') {
            //    let currentAseguradoTomador = terceros.find(e => e.tipodetercero === 2 && e.elaseguradoeselmismotomador === 1);
            //    if (currentAseguradoTomador == null) {
            //        message += ', indique el tomador';
            //        terceroserrors = true;
            //    }
            //}
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
        if (lista.length > 0 && workMode != "draft")  {
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
                    formatter: 'app.ui.DecimalFormatter',
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

    function Coberturas_ManejoGeneral() {
        coberturas = $('#coberturasTbl').bootstrapTable('getData');
        coberturas.forEach(function (value, index, array) {
            $('[name=btSelectItem][data-index=' + index + ']').prop('disabled', true);
        });
        $('[name=btSelectAll]').prop('disabled', true);
    };


    function cuestionarioCovid_table_setup() {

        $('#cuestionarioCovidNew').click(function () {
            //$('#tipodetercero').val($('#tipodetercero option[disabled!="disabled"]')[0].value);
            //$('#tipodetercero').change();
            cuestionarioCovid_table_row_edit();
        });

    }

    function cuestionarioCovid_table_row_edit(row) {
        var md = $('#cuestionarioCovidModal').modal({ show: false });
        var formInstance = $("#QuestionaryCovidEdtFrm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();

        md.modal('show');
    }

//#region Terceros

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
                porcentaje: app.ui.GetNumericValue('#porcentaje'),
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
        app.ui.SetNumericValue('#porcentaje', row.porcentaje);


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
        new AutoNumeric('#porcentaje', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });

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
//#endregion

//#region Documentos Requeridos
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
        debugger;
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
//#endregion

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

                cuestionario_table_setup();
                cuestionarioCovid_table_setup();

                terceros_controls_setup();
                terceros_table_setup();
                terceros_table_Validations();
                terceros_controls_Events();

                documentosrequeridos_controls_setup();
                documentosrequeridos_table_setup();
                documentosrequeridos_table_Validations();
                documentosrequeridos_controls_Events();

                //Cuestionario Salud
                Init_Controls_Salud();
                Init_Lookups_Salud();
                Event_Controls_Salud();
                //Setup_Validations_Salud();

                //Cuestionario Covid
                Init_Controls_Covid();
                Init_Lookups_Covid();
                Event_Controls_Covid();
                Setup_Validations_Covid();

                Setup();
                console.log("Inicio");
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
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
        },
        InputToObject_Salud: _inputToObject_Salud,
        ObjectToInput_Salud: _objectToInput_Salud,
        IsValid_Salud: function () {
            var instance = $('#QuestionaryEdtFrm');
            var validate = instance.validate();

            validate.settings.ignore = '';
            var result = instance.valid();
            var count = validate.numberOfInvalids();
            validate.settings.ignore = ':hidden';

            if (count > 0)
                $('#cuestionarioHTab .badge').html(count);
            else
                $('#cuestionarioHTab .badge').html('');
            return result;
        },
        UIBehavior: function (gender, birthDate) {
            if (app.poliza.EntryAllowed()?.includes(";Questionnaires;")) {

                /*let age = moment().diff(birthDate, 'years');
                if (Number.isNaN(age))
                    age = 0;
                let enable = !(age >= 40);
                gender = tercerosMca_sexo.val();
                if (gender === '1') { //Masculino*/
                    $('#Confirmation_6a').prop("enabled", true);
                    $('#Confirmation_6b').prop("enabled", true);
                    $('#Confirmation_9a').prop("enabled", true);
                    $('#Confirmation_9b').prop("enabled", true);
                    $($('input:radio[name=Confirmation_6][value=1]')).prop('checked', false);
                    $($('input:radio[name=Confirmation_6][value=2]')).prop('checked', false);
                    $($('input:radio[name=Confirmation_9][value=1]')).prop('checked', false);
                    $($('input:radio[name=Confirmation_9][value=2]')).prop('checked', false);
                    let enable = !(age >= 40);
                    $('#Confirmation_10a').prop("enabled", enable);
                    $('#Confirmation_10b').prop("enabled", enable);
                //}
                //if (gender === '2') { //Femenino
                    $('#Confirmation_6a').prop("enabled", enable);
                    $('#Confirmation_6b').prop("enabled", enable);
                    $('#Confirmation_9a').prop("enabled", enable);
                    $('#Confirmation_9b').prop("enabled", enable);

                    $($('input:radio[name=Confirmation_10][value=1]')).prop('checked', false);
                    $($('input:radio[name=Confirmation_10][value=2]')).prop('checked', false);

                    $('#Confirmation_10a').prop("enabled", true);
                    $('#Confirmation_10b').prop("enabled", true);
                //}
            }
        },
        InputToObject_Covid: _inputToObject_Covid,
        ObjectToInput_Covid: _objectToInput_Covid,
        IsValid_Covid: function () {
            var instance = $('#QuestionaryCovidEdtFrm');
            var validate = instance.validate();

            validate.settings.ignore = '';
            var result = instance.valid();
            var count = validate.numberOfInvalids();
            validate.settings.ignore = ':hidden';

            if (count > 0)
                $('#cuestionarioCovidHTab .badge').html(count);
            else
                $('#cuestionarioCovidHTab .badge').html('');
            return result;
        }
    };


window.enfermedadesexcluidasTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.enfermedadesexcluidasId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionSaldoDeudor.enfermedadesexcluidasDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionSaldoDeudor.enfermedadesexcluidasEditRow(row);
        e.stopPropagation();
    }
};

window.tercerosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el tercero '" + row.nombre + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionSaldoDeudor.tercerosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionSaldoDeudor.tercerosEditRow(row);
        e.stopPropagation();
    }
};

window.documentosrequeridosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer limpiar el documento requerido '" + row.DNombre + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionSaldoDeudor.documentosrequeridosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionSaldoDeudor.documentosrequeridosEditRow(row);
        e.stopPropagation();
    }
};

//#region Cuestionario Salud

function cuestionario_table_setup() {

    $('#cuestionarioNew').click(function () {
        //$('#tipodetercero').val($('#tipodetercero option[disabled!="disabled"]')[0].value);
        //$('#tipodetercero').change();
        cuestionario_table_row_edit();
    });

}

function cuestionario_table_row_edit(row) {
    var md = $('#cuestionarioSaludModal').modal({ show: false });
    var formInstance = $("#QuestionaryEdtFrm");
    var fvalidate = formInstance.validate();
    fvalidate.resetForm();

    md.modal('show');
}

function Init_Controls_Salud() {
    for (index = 1; index <= 14; index++) {
        $('#When_' + index + '_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
    };
};

function Init_Lookups_Salud() {
};

function Event_Controls_Salud() {
    $("input:radio[name='Confirmation_1'],input:radio[name='Confirmation_2'],input:radio[name='Confirmation_3'],input:radio[name='Confirmation_4'],input:radio[name='Confirmation_5'],input:radio[name='Confirmation_6'],input:radio[name='Confirmation_7'],input:radio[name='Confirmation_8'],input:radio[name='Confirmation_9'],input:radio[name='Confirmation_10'],input:radio[name='Confirmation_11'],input:radio[name='Confirmation_12'],input:radio[name='Confirmation_13'],input:radio[name='Confirmation_14']").on('change', function () {
        let indexValue = $(this)[0].name.substring(13);
        let value = this.value;

        if (value === '1') {
            $('#question_' + indexValue).removeClass('d-none');
            $('#Diagnosis_' + indexValue).prop("disabled", false)
            $('#Doctor_' + indexValue).prop("disabled", false)
            $('#Treatment_' + indexValue).prop("disabled", false)
            $('#When_' + indexValue).prop("disabled", false)
        }
        else {
            $('#question_' + indexValue).addClass('d-none');
            $('#Diagnosis_' + indexValue).prop("disabled", true)
            $('#Doctor_' + indexValue).prop("disabled", true)
            $('#Treatment_' + indexValue).prop("disabled", true)
            $('#When_' + indexValue).prop("disabled", true)
        }
    });
};


    function Validations_Salud2() {
        let result = [];
        let message = '';

        if (edad_asegurado > 64 || suma_asegurada > 100000) {

            if (!document.getElementById('Confirmation_1a').checked && !document.getElementById('Confirmation_1b').checked) {
                message += 'Es necesario responder la pregunta #1 ';
                result.push({ id: 'pregunta_1', message: message });

            }
            else {
                if (document.getElementById('Confirmation_1a').checked) {
                    if (document.getElementById('Diagnosis_1').value == '' || document.getElementById('Treatment_1').value == '' ||
                        document.getElementById('Doctor_1').value == '' || document.getElementById('When_1').value == '') {
                        message += 'Debe responder el detalle de la pregunta #1 ';
                        result.push({ id: 'pregunta_1', message: message });
                    }
                }
            }
            if (!document.getElementById('Confirmation_3a').checked && !document.getElementById('Confirmation_3b').checked) {
                message += 'Es necesario responder la pregunta #2 ';
                result.push({ id: 'pregunta_2', message: message });

            }
            else {
                if (document.getElementById('Confirmation_3a').checked) {
                    if (document.getElementById('Diagnosis_3').value == '' || document.getElementById('Treatment_3').value == '' ||
                        document.getElementById('Doctor_3').value == '' || document.getElementById('When_3').value == '') {
                        message += 'Debe responder el detalle de la pregunta #2 ';
                        result.push({ id: 'pregunta_2', message: message });
                    }
                }
            }
            if (!document.getElementById('Confirmation_8a').checked && !document.getElementById('Confirmation_8b').checked) {
                message += 'Es necesario responder la pregunta #3 ';
                result.push({ id: 'pregunta_3', message: message });

            }
            else {
                if (document.getElementById('Confirmation_8a').checked) {
                    if (document.getElementById('Diagnosis_8').value == '' || 
                        document.getElementById('Doctor_8').value == '' || document.getElementById('When_8').value == '') {
                        message += 'Debe responder el detalle de la pregunta #3 ';
                        result.push({ id: 'pregunta_3', message: message });
                    }
                }
            }
            if (!document.getElementById('Confirmation_11a').checked && !document.getElementById('Confirmation_11b').checked) {
                message += 'Es necesario responder la pregunta #4 ';
                result.push({ id: 'pregunta_4', message: message });

            }
            else {
                if (document.getElementById('Confirmation_11a').checked) {
                    if (document.getElementById('Diagnosis_11').value == '' || document.getElementById('Treatment_11').value == '' ||
                        document.getElementById('Doctor_11').value == '' || document.getElementById('When_11').value == '') {
                        message += 'Debe responder el detalle de la pregunta #4 ';
                        result.push({ id: 'pregunta_4', message: message });
                    }
                }
            }
            if (!document.getElementById('Confirmation_5a').checked && !document.getElementById('Confirmation_5b').checked) {
                message += 'Es necesario responder la pregunta #5 ';
                result.push({ id: 'pregunta_5', message: message });

            }
            else {
                if (document.getElementById('Confirmation_5a').checked) {
                    if (document.getElementById('Diagnosis_5').value == '' || document.getElementById('Treatment_5').value == '' ||
                        document.getElementById('Doctor_5').value == '' || document.getElementById('When_5').value == '') {
                        message += 'Debe responder el detalle de la pregunta #5 ';
                        result.push({ id: 'pregunta_5', message: message });
                    }
                }
            }
            if (!document.getElementById('Confirmation_12a').checked && !document.getElementById('Confirmation_12b').checked) {
                message += 'Es necesario responder la pregunta #6 ';
                result.push({ id: 'pregunta_6', message: message });

            }
            else {
                if (document.getElementById('Confirmation_12a').checked) {
                    if (document.getElementById('Diagnosis_12').value == '') {
                        message += 'Debe responder el detalle de la pregunta #6 ';
                        result.push({ id: 'pregunta_6', message: message });
                    }
                }
            }
            if (!document.getElementById('Confirmation_6a').checked && !document.getElementById('Confirmation_6b').checked) {
                message += 'Es necesario responder la pregunta #7 ';
                result.push({ id: 'pregunta_7', message: message });

            }
            else {
                if (document.getElementById('Confirmation_6a').checked) {
                    if (document.getElementById('When_6').value == '') {
                        message += 'Debe responder el detalle de la pregunta #7 ';
                        result.push({ id: 'pregunta_7', message: message });
                    }
                }
            }
            if (!document.getElementById('Confirmation_2a').checked && !document.getElementById('Confirmation_2b').checked) {
                message += 'Es necesario responder la pregunta #8 ';
                result.push({ id: 'pregunta_8', message: message });

            }
            else {
                if (document.getElementById('Confirmation_2a').checked) {
                    if (document.getElementById('Diagnosis_2').value == '') {
                        message += 'Debe responder el detalle de la pregunta #8 ';
                        result.push({ id: 'pregunta_8', message: message });
                    }
                }
            }
            if (!document.getElementById('Confirmation_13a').checked && !document.getElementById('Confirmation_13b').checked) {
                message += 'Es necesario responder la pregunta #9 ';
                result.push({ id: 'pregunta_9', message: message });

            }
            else {
                if (document.getElementById('Confirmation_13a').checked) {
                    if (document.getElementById('Diagnosis_13').value == '') {
                        message += 'Debe responder el detalle de la pregunta #9 ';
                        result.push({ id: 'pregunta_9', message: message });
                    }
                }
            }
            if (!document.getElementById('Confirmation_7a').checked && !document.getElementById('Confirmation_7b').checked) {
                message += 'Es necesario responder la pregunta #10 ';
                result.push({ id: 'pregunta_10', message: message });

            }
            else {
                if (document.getElementById('Confirmation_7a').checked) {
                    if (document.getElementById('Diagnosis_7').value == '') {
                        message += 'Debe responder el detalle de la pregunta #10 ';
                        result.push({ id: 'pregunta_10', message: message });
                    }
                }
            }
            if (!document.getElementById('Confirmation_14a').checked && !document.getElementById('Confirmation_14b').checked) {
                message += 'Es necesario responder la pregunta #11 ';
                result.push({ id: 'pregunta_11', message: message });

            }
            else {
                if (document.getElementById('Confirmation_14a').checked) {
                    if (document.getElementById('Doctor_14').value == '' || document.getElementById('When_14').value == '') {
                        message += 'Debe responder el detalle de la pregunta #11 ';
                        result.push({ id: 'pregunta_11', message: message });
                    }
                }
            }
            if (!document.getElementById('Confirmation_4a').checked && !document.getElementById('Confirmation_4b').checked) {
                message += 'Es necesario responder la pregunta #12 ';
                result.push({ id: 'pregunta_12', message: message });

            }
            else {
                if (document.getElementById('Confirmation_4a').checked) {
                    if (document.getElementById('Diagnosis_4').value == '' || document.getElementById('Treatment_4').value == '' ||
                        document.getElementById('Doctor_4').value == '' || document.getElementById('When_4').value == '') {
                        message += 'Debe responder el detalle de la pregunta #12 ';
                        result.push({ id: 'pregunta_12', message: message });
                    }
                }
            }
            if (!document.getElementById('Confirmation_9a').checked && !document.getElementById('Confirmation_9b').checked) {
                message += 'Es necesario responder la pregunta #13 ';
                result.push({ id: 'pregunta_13', message: message });

            }
            else {
                if (document.getElementById('Confirmation_9a').checked) {
                    if (document.getElementById('Diagnosis_9').value == '' || document.getElementById('Treatment_9').value == '' ||
                        document.getElementById('Doctor_9').value == '' || document.getElementById('When_9').value == '') {
                        message += 'Debe responder el detalle de la pregunta #13 ';
                        result.push({ id: 'pregunta_13', message: message });
                    }
                }
            }
            if (!document.getElementById('Confirmation_10a').checked && !document.getElementById('Confirmation_10b').checked) {
                message += 'Es necesario responder la pregunta #14 ';
                result.push({ id: 'pregunta_14', message: message });

            }
            else {
                if (document.getElementById('Confirmation_10a').checked) {
                    if (document.getElementById('Diagnosis_10').value == '' || document.getElementById('Treatment_10').value == '' ||
                        document.getElementById('Doctor_10').value == '' || document.getElementById('When_10').value == '') {
                        message += 'Debe responder el detalle de la pregunta #14 ';
                        result.push({ id: 'pregunta_14', message: message });
                    }
                }
            }


            $('#cuestionario-error').html(message);
            $('#cuestionario-error').removeClass('d-none');

        }

        return result;
    }


var _inputToObject_Salud = function () {
    var data = [];
    for (index = 1; index <= 14; index++) {
        data.push({
            QuestionId: index,
            Confirmation: $('input:radio[name=Confirmation_' + index + ']:checked').val(),
            Diagnosis: $('#Diagnosis_' + index).val(),
            Treatment: $('#Treatment_' + index).val(),
            Doctor: $('#Doctor_' + index).val(),
            When: app.ui.GetDateValue('#When_' + index)
        });
    };
    return data;
};

var _objectToInput_Salud = function (data) {
    if (data !== null) {
        let nindex = 1;

        $.each(data, function (index, row) {
            if (row.QuestionId >= 1 && row.QuestionId <= 14) {
                nindex = row.QuestionId;
                $($('input:radio[name=Confirmation_' + nindex + '][value=' + row.Confirmation + ']')).prop('checked', true);
                $('input:radio[name=Confirmation_' + nindex + '][value=' + row.Confirmation + ']').change();
                $('#Diagnosis_' + nindex).val(row.Diagnosis);
                $('#Treatment_' + nindex).val(row.Treatment);
                $('#Doctor_' + nindex).val(row.Doctor);
                app.ui.SetDateValue('#When_' + nindex, row.When);
            }
        });
    }
};
//#endregion

//#region Cuestionario Covid

function Init_Controls_Covid() {
    for (index = 51; index <= 59; index++) {
        $('#When_' + index + '_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
    };
};



function Init_Lookups_Covid() {
};

function Event_Controls_Covid() {
    $("input:radio[name='Confirmation_51'],input:radio[name='Confirmation_52'],input:radio[name='Confirmation_53'],input:radio[name='Confirmation_54'],input:radio[name='Confirmation_55'],input:radio[name='Confirmation_56'],input:radio[name='Confirmation_57'],input:radio[name='Confirmation_58'],input:radio[name='Confirmation_59']").on('change', function () {
        let indexValue = $(this)[0].name.substring(13);
        let value = this.value;
        if (indexValue === '58') {
            value = value === '1' ? '2' : '1';
        }
        if (value === '1') {
            $('#question_' + indexValue).removeClass('d-none');
            $('#Diagnosis_' + indexValue).prop("disabled", false)
            $('#Doctor_' + indexValue).prop("disabled", false)
            $('#Treatment_' + indexValue).prop("disabled", false)
            $('#When_' + indexValue).prop("disabled", false)
        }
        else {
            $('#question_' + indexValue).addClass('d-none');
            $('#Diagnosis_' + indexValue).prop("disabled", true)
            $('#Doctor_' + indexValue).prop("disabled", true)
            $('#Treatment_' + indexValue).prop("disabled", true)
            $('#When_' + indexValue).prop("disabled", true)
        }
    });
};

function Setup_Validations_Covid() {

    $.validator.addMethod("AgeGreaterThan60_radio",
        function (value, element) {
            var notError = true;
            var age = moment().diff($('#BirthDate_group').data('DateTimePicker').date(), 'years');
            if (!Number.isNaN(age)) {
                if (age >= 60 && $('input:radio[name=' + element.id.substring(0, element.id.length - 1) + ']:checked').val() === undefined) {
                    notError = false;
                }
            }
            return notError;
        }
    );

    $.validator.addMethod("Q54",
        function (value, element) {
            var notError = false;
            if ($('input:radio[name=Confirmation_54]:checked').val() === undefined || $('input:radio[name=Confirmation_54]:checked').val() == '2' || $('#Diagnosis_54_1').is(':checked') || $('#Diagnosis_54_2').is(':checked') || $('#Diagnosis_54_3').is(':checked') || $('#Diagnosis_54_4').is(':checked') || $('#Diagnosis_54_5').is(':checked') || $('#Diagnosis_54_6').is(':checked')) {
                notError = true;
            }
            return notError;
        }
    )

    $("#QuestionaryCovidEdtFrm").validate({
        errorPlacement: function (error, element) {
            var name = $(element).attr("name");
            var $obj = $("#" + name + "_validate");
            if ($obj.length) {
                error.appendTo($obj);
            }
            else {
                error.insertAfter(element);
            }
        },
        rules: {
            Confirmation_51: {
                AgeGreaterThan60_radio: true
            },
            Diagnosis_51: {
                required: true
            },
            Confirmation_52: {
                AgeGreaterThan60_radio: true
            },
            Confirmation_53: {
                AgeGreaterThan60_radio: true
            },
            Diagnosis_53: {
                required: true
            },
            Confirmation_54: {
                AgeGreaterThan60_radio: true,
                Q54: true
            },
            Confirmation_55: {
                AgeGreaterThan60_radio: true
            },
            Confirmation_56: {
                AgeGreaterThan60_radio: true
            },
            Diagnosis_56: {
                required: true
            },
            Confirmation_57: {
                AgeGreaterThan60_radio: true
            },
            When_57: {
                required: true
            },
            Confirmation_58: {
                AgeGreaterThan60_radio: true
            },
            Diagnosis_58: {
                required: true
            },
            Confirmation_59: {
                AgeGreaterThan60_radio: true
            },
            Treatment_59: {
                required: true
            },
            When_59: {
                required: true
            },
            Doctor_59: {
                required: true
            }
        },
        messages: {
            Confirmation_51: {
                AgeGreaterThan60_radio: 'Para mayores  de 60 años debe responder la pregunta 1',
            },
            Diagnosis_51: {
                required: 'Debe indicar en qué país o países y las fechas exactas'
            },
            Confirmation_52: {
                AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 2',
            },
            Confirmation_53: {
                AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 3',
            },
            Diagnosis_53: {
                required: 'Debe indicar el detalle'
            },
            Confirmation_54: {
                AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 4',
                Q54: 'Debe indicar cuales síntomas'
            },
            Confirmation_55: {
                AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 5',
            },
            Confirmation_56: {
                AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 6',
            },
            Diagnosis_56: {
                required: 'Debe indicar el detalle'
            },
            Confirmation_57: {
                AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 7',
            },
            When_57: {
                required: 'Debe indicar la fecha'
            },
            Confirmation_58: {
                AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 8',
            },
            Diagnosis_58: {
                required: 'Debe indicar el motivo'
            },
            Confirmation_59: {
                AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 9',
            },
            Treatment_59: {
                required: 'Debe indicar cual vacuna le aplicaron'
            },
            When_59: {
                required: 'Debe indicar la fecha'
            },
            Doctor_59: {
                required: 'Debe indicar cuántas dosis posee'
            }
        }
    });
};

var _inputToObject_Covid = function () {
    let data = [];
    let row = null;
    for (index = 51; index <= 59; index++) {
        row = {
            QuestionId: index,
            Confirmation: $('input:radio[name=Confirmation_' + index + ']:checked').val(),
            Diagnosis: $('#Diagnosis_' + index).val(),
            Treatment: $('#Treatment_' + index).val(),
            Doctor: $('#Doctor_' + index).val(),
            When: null
        };
        if (index === 54) {
            row.Diagnosis = [$('#Diagnosis_54_1').is(':checked'), $('#Diagnosis_54_2').is(':checked'), $('#Diagnosis_54_3').is(':checked'), $('#Diagnosis_54_4').is(':checked'), $('#Diagnosis_54_5').is(':checked'), $('#Diagnosis_54_6').is(':checked')].toString();
        }
        if ($('#When_' + index).length > 0) {
            row.When = app.ui.GetDateValue('#When_' + index);
        }
        data.push(row);
    }
    return data;
};

var _objectToInput_Covid = function (data) {
    if (data !== null) {
        let nindex = 1;

        $.each(data, function (index, row) {
            if (row.QuestionId >= 51 && row.QuestionId <= 59) {
                nindex = row.QuestionId;
                $($('input:radio[name=Confirmation_' + nindex + '][value=' + row.Confirmation + ']')).prop('checked', true);
                $('input:radio[name=Confirmation_' + nindex + '][value=' + row.Confirmation + ']').change();
                $('#Diagnosis_' + nindex).val(row.Diagnosis);
                $('#Treatment_' + nindex).val(row.Treatment);
                $('#Doctor_' + nindex).val(row.Doctor);
                if ($('#When_' + nindex).length > 0)
                    app.ui.SetDateValue('#When_' + nindex, row.When);
                if (nindex === 54) {
                    $.each(row.Diagnosis.split(','), function (indexRow, rowValue) {
                        $('#Diagnosis_54_' + (indexRow + 1)).prop('checked', rowValue === 'true');
                    });
                }
            }
        });
    }
};

})();

//#endregion