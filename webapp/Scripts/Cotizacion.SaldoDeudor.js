var app = app || {};

app.CotizacionSaldoDeudor = (function () {

    let setupData = null;
    let changedCallback = null;
    let CapitalCtrls = [];
    var workMode = '';

    function Setup()
    {

        if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
            $('#emitir').html("<i class='fa fa-check'></i> Completar solicitud");
            workMode = '&mode=draft';
        }

        app.core.Get(app.setting.apipath + 'v1/Quote/SaldoDeudorSetup', null,
            function (data) {
                setupData = data;

                let lookupList = [
                    'MonedasPorRamo.cod_mon',
                    'FrecuenciaDePagoPorRamo.cod_fracc_pago',
                    'TRON_G2990004.COD_MODALIDAD_RIESGO',
                    'TRON_G2990006:COD_CIA_ORI.COD_CIA_ORI',
                    'TRON_G2990006:TIP_NEGOCIO.TIP_NEGOCIO',
                    'TRON_G7000210.COD_ENF_EXC',
                    'TRON_G1010031:COD_TIP_EXC.COD_TIP_EXC'];

                if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
                    lookupList.push('MM_POLIZA_GRUPO.contrato');
                    $('#polizagrupoZone').removeClass('d-none');
                }

                setupData = JSON.parse(JSON.stringify(data));

                app.core.Lookups(lookupList,
                    function () {
                        setupData = data;
                        MapObjectToInput(data);
                        Dynamic_Event_Controls();
                    }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}`);

            });

        $('#cod_mon').on('change', function () {
            if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
                let cod_mon = app.ui.GetDropDownNumericValue('#cod_mon');
                let lookupList = ['MM_POLIZA_GRUPO.contrato'];
                app.ui.DropDownDisabled('#subcontrato', true, true);
                app.core.Lookups(lookupList,
                    function () {
                        SettingReload();
                    }, `cod_ramo=${setupData.cod_ramo}:cod_mon=${cod_mon}`);
            }
            else {
                //app.core.LookupDependency($('select#moneda').val(), 'sARespcivil', 'SumasAseguradasRC', '', null, false, null, `cod_ramo=${setupData.cod_ramo}:cod_mon=`);
            }
        });

        $('#contrato').on('change', function () {
            let contracto = app.ui.GetDropDownNumericValue('#contrato');

            if (contracto > 0) {
                setupData.polizagrupo = app.core.Data().lookups.filter(i => i.Key === 'MM_POLIZA_GRUPO')[0].Lkp.filter(l => l.Code === contracto + '')[0].NUM_POLIZA;
            }

            SettingReload();

            app.core.LookupDependency($('select#contrato').val(), 'subcontrato', 'MM_SUB_CONTRATOS', '', null, true,
                function (lkpData) {

                    app.ui.DropDownDisabled('#subcontrato', lkpData && lkpData.length == 0);
                },
                `cod_ramo=${setupData.cod_ramo}:num_contrato=`);
        });
    };

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
            NUM_ESTATURA_CM: app.ui.GetNumericValue('#NUM_ESTATURA_CM'),
            NUM_PESO: app.ui.GetNumericValue('#NUM_PESO'),
            NUM_IMC: app.ui.GetNumericValue('#NUM_IMC'),
            COD_MODALIDAD_RIESGO: app.ui.GetDropDownNumericValue('#COD_MODALIDAD_RIESGO'),
            NOM_MODALIDAD_RIESGO: $("#COD_MODALIDAD_RIESGO option:selected").text(),
            MCA_NEGOCIO_MIGRADO: app.ui.GetRadioStringValue('MCA_NEGOCIO_MIGRADO'),
            NOM_NEGOCIO_MIGRADO: $('label[for=MCA_NEGOCIO_MIGRADO_' + app.ui.GetRadioStringValue('MCA_NEGOCIO_MIGRADO') + ']').html(),
            COD_CIA_ORI: app.ui.GetDropDownStringValue('#COD_CIA_ORI'),
            FEC_EMISION_ORI: app.ui.GetDateValue('#FEC_EMISION_ORI'),
            IMP_MONTO_ORI: app.ui.GetNumericValue('#IMP_MONTO_ORI'),
            IMP_SLD_ACTUAL: app.ui.GetNumericValue('#IMP_SLD_ACTUAL'),
            NUM_PRESTAMO: $('#NUM_PRESTAMO').val(),
            TIP_NEGOCIO: app.ui.GetDropDownStringValue('#TIP_NEGOCIO'),
            NOM_TIP_NEGOCIO: $("#TIP_NEGOCIO option:selected").text(),
            IMP_PRIMA_INFORMADA: app.ui.GetNumericValue('#IMP_PRIMA_INFORMADA'),
            IMP_GASTOS_EMISION: app.ui.GetNumericValue('#IMP_GASTOS_EMISION'),
            PCT_DTO_COMERCIAL: app.ui.GetNumericValue('#PCT_DTO_COMERCIAL'),
            PCT_DCTO_TECNICO: app.ui.GetNumericValue('#PCT_DCTO_TECNICO'),
            FEC_PRIM_FINAN: app.ui.GetDateValue('#FEC_PRIM_FINAN'),
            FEC_VCTO_PRESTAMO: app.ui.GetDateValue('#FEC_VCTO_PRESTAMO'),
            enfermedadesexcluidas: $('#enfermedadesexcluidasTbl').bootstrapTable('getData'),
            coberturas: $('#coberturasTbl').bootstrapTable('getData'),
            plandepago: $('#plandepagoTbl').bootstrapTable('getData'),
            num_contrato: app.ui.GetDropDownNumericValue('#contrato'),
            num_subcontrato: app.ui.GetDropDownNumericValue('#subcontrato'),
            num_poliza_grupo: setupData.polizagrupo
        };
        
        data.coberturas.forEach(function (currentValue, index) {
            if (currentValue.edtCapital)
                currentValue.capital = app.ui.GetNumericValue('#CapitalRow_' + index);
        })

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
        app.ui.SetDateValue('#FEC_VCTO_PRESTAMO', data.FEC_VCTO_PRESTAMO);
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
        $('#FEC_VCTO_PRESTAMO_group').datetimepicker({
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
        $("#limpiar").appendTo("#GenericToolBar");

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
            if (app.ui.IsValid('#SaldoDeudorEdtForm', false)) {
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
            $("#SaldoDeudorEdtForm").validate().resetForm();
            app.ui.ButtonDone('#limpiar');
            event.preventDefault();
        });

        $('#print').click(function () {
            event.preventDefault();
            app.Cotizacion.Imprimir('SaldoDeudor', app.CotizacionSaldoDeudor.Data());
        });

        $('#emitir').click(function () {
            event.preventDefault();
            window.location.replace(app.setting.basepath + 'emision/SaldoDeudor?presupuesto=' + quoteData.presupuesto + workMode);
        });
    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };

    function SettingReload() {
        var data = {
            cod_ramo: setupData.cod_ramo,
            num_contrato: app.ui.GetDropDownNumericValue('#contrato'),
            num_subcontrato: app.ui.GetDropDownNumericValue('#subcontrato'),
            num_poliza_grupo: setupData.polizagrupo,
            cod_mon: app.ui.GetDropDownNumericValue('#cod_mon')
        };

        $('#coberturasTbl').bootstrapTable('showLoading');

        app.core.Get(app.setting.apipath + 'v1/Quote/SaldoDeudorSettings?' + `cod_ramo=${data.cod_ramo}&num_contrato=${data.num_contrato}&num_subcontrato=${data.num_subcontrato}&num_poliza_grupo=${data.num_poliza_grupo}&cod_mon=${data.cod_mon}`)
            .done(function (settingData) {

                app.ui.SetDateValue('#fec_vcto_poliza', app.ui.GetDateValue('#fec_efec_poliza'))
                app.ui.SetDateValue('#fec_vcto_poliza', settingData.fec_vcto_poliza);

                //Fraccionamiento
                if (settingData.cod_fracc_pago > 0) {
                    $('#cod_fracc_pago').val(settingData.cod_fracc_pago);
                    $('#cod_fracc_pago').prop('disabled', true);
                } else {
                    $('#cod_fracc_pago').prop('disabled', false);
                }
                //Modalidad
                app.ui.LookupLoad('COD_MODALIDAD_RIESGO', settingData.COD_MODALIDAD_RIESGO);

                //Tipo Negocio
                app.ui.LookupLoad('TIP_NEGOCIO', settingData.TIP_NEGOCIO);
                
                if (settingData.coberturas != null) {
                    $('#coberturasTbl').bootstrapTable('load', settingData.coberturas);
                    Coberturas_ManejoGeneral();
                }
                else {
                    $('#coberturasTbl').bootstrapTable('load', {});
                    Coberturas_ManejoGeneral();
                }
                
                }).always(function () {
                    $('#coberturasTbl').bootstrapTable('hideLoading');
                });
            }
               

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
                NUM_ESTATURA_CM: { required: true, Numeric: true },
                NUM_PESO: { required: true, Numeric: true },
                COD_MODALIDAD_RIESGO: { required: true },
                MCA_NEGOCIO_MIGRADO: { required: true },
                COD_CIA_ORI: { required: false },
                FEC_EMISION_ORI: { required: false },
                IMP_MONTO_ORI: { required: true, Numeric: true },
                NUM_PRESTAMO: { required: true },
                TIP_NEGOCIO: { required: true },
                FEC_VCTO_PRESTAMO: { required: true },
                contrato: { required: true },
                subcontrato: { required: true }
            },
            messages: {
                cod_mon: { required: 'Debe indicar la moneda' },
                cod_fracc_pago: { required: 'Debe indicar el fraccionamiento de pago' },
                fec_efec_poliza: { required: 'Debe indicar el inicio de vigencia' },
                fec_vcto_poliza: { required: 'Debe indicar el in de vigencia' },
                FEC_NACIMIENTO: { required: 'Debe indicar la fecha de nacimiento' },
                MCA_SEXO: { required: 'Debe indicar el sexo' },
                COD_MODALIDAD_RIESGO: { required: 'Debe indicar la modalidad de riesgo' },
                NUM_ESTATURA_CM: { required: 'Debe indicar la estatura en centímetros', Numeric: 'Debe indicar la estatura en centímetros' },
                NUM_PESO: { required: 'Debe indicar el peso', Numeric: 'Debe indicar el peso' },
                MCA_NEGOCIO_MIGRADO: { required: 'Debe indicar si es un negocio migrado' },
                COD_CIA_ORI: { required: 'Debe indicar la compañía original' },
                FEC_EMISION_ORI: { required: 'Debe indicar la fecha de emisión original' },
                IMP_MONTO_ORI: { required: 'Debe indicar el monto original del préstamo', Numeric: 'Debe indicar el monto original del préstamo' },
                NUM_PRESTAMO: { required: 'Debe indicar el número de préstamo' },
                TIP_NEGOCIO: { required: 'Debe indicar el tipo de negocio' },
                FEC_VCTO_PRESTAMO: { required: "Debe indicar el Vencimiento del Prestamo" },
                contrato: { required: 'Debe indicar el contrato' },
                subcontrato: { required: 'Debe indicar el subcontrato' }
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
                    field: 'riesgo',
                    title: 'Riesgo',
                    titleTooltip: 'Número del riesgo',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
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
                    if (index == 0)
                        app.ui.SetNumericValue('#CapitalRow_' + index, app.ui.GetNumericValue('#IMP_MONTO_ORI'));
                    else {
                        app.ui.SetNumericValue('#CapitalRow_' + index, '');
                        document.getElementById("CapitalRow_"+ index).disabled = false;
                    }
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

    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Quote/SaldoDeudorQuote',
            JSON.stringify(MapInputToObject()),
            function (data) {
                quoteData = data;
                if (!app.ui.NotifyErrors(data.Mensaje, data.Errors, '#SaldoDeudorEdtForm')) {
                    $('#presupuesto').html(data.presupuesto);
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

    return {
        Init: function () {
            try {
                Controls_setup();
                Setup_Validations();

                coberturas_table_setup();
                plandepago_table_setup();
                plandepagoporfrecuencia_table_setup();

                Controls_Events();

                app.core.LoadScriptFile("Cotizacion.SaldoDeudor.enfermedadesexcluidas.js")
                    .then(d => {
                        app.CotizacionSaldoDeudorEnfermedadesExcluidas.Init();
                        Setup();
                    })
                    .catch(err => {
                        console.error(err);
                    });


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


