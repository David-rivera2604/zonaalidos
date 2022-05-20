var app = app || {};

app.EmisionMultirriesgo = (function () {

    var setupData = null;
    var showCalculate = false;
    var rowDocumentosrequeridos = null;

    function Setup() {
        var _id = app.core.URLStringValue('presupuesto');
        if (_id != '') {
            $('#coberturasTbl').bootstrapTable('showLoading');
            app.core.Get(app.setting.apipath + 'v1/Issue/MultirriesgoSetup/' + _id)
                .done(function (data, textStatus, jqXHR) {
                    Init_Lookups(data);
                });
        }
    };

    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Issue/Multirriesgo',
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

                    $('#anodeconstruccion').replaceWith('<div>' + $('#anodeconstruccion').val() + '</div>');

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

    function ReadOnly() {
        $('#cod_mon').replaceWith('<div>' + $('#cod_mon option:selected').text() + '</div>');
        $('#cod_fracc_pago').replaceWith('<div>' + $('#cod_fracc_pago option:selected').text() + '</div>');
        $('#fec_efec_poliza_group').replaceWith('<div>' + $('#fec_efec_poliza').val() + '</div>');
        $('#fec_vcto_poliza_group').replaceWith('<div>' + $('#fec_vcto_poliza').val() + '</div>');
        $('#cod_pais').replaceWith('<div>' + $('#cod_pais option:selected').text() + '</div>');
        $('#cod_estado').replaceWith('<div>' + $('#cod_estado option:selected').text() + '</div>');
        $('#cod_prov').replaceWith('<div>' + $('#cod_prov option:selected').text() + '</div>');
        $('#cod_localidad').replaceWith('<div>' + $('#cod_localidad option:selected').text() + '</div>');
        $('#otrassenasdelriesgo').replaceWith('<div>' + $('#otrassenasdelriesgo').val() + '</div>');
        $('#cod_tip_ocup').replaceWith('<div>' + $('#cod_tip_ocup option:selected').text() + '</div>');
        $('#cod_tip_edit').replaceWith('<div>' + $('#cod_tip_edit option:selected').text() + '</div>');
        $('#num_pisos_edif').replaceWith('<div>' + $('#num_pisos_edif option:selected').text() + '</div>');
        $('#cod_tipo_estruc').replaceWith('<div>' + $('#cod_tipo_estruc option:selected').text() + '</div>');
        $('#cod_tipo_techo').replaceWith('<div>' + $('#cod_tipo_techo option:selected').text() + '</div>');
        $('#cod_tipo_pared').replaceWith('<div>' + $('#cod_tipo_pared option:selected').text() + '</div>');
        //$('#anodeconstruccion').replaceWith('<div>' + $('#anodeconstruccion').val() + '</div>');
        $('#IMP_EDIFICIO').replaceWith('<div>' + $('#IMP_EDIFICIO').val() + '</div>');
        $('#cod_tip_med_rob').next().replaceWith("<div>" + $('#cod_tip_med_rob option:selected').text() + "</div>");
        $('#IMP_DOMOS_TOTAL').replaceWith('<div>' + $('#IMP_DOMOS_TOTAL').val() + '</div>');
        $('#IMP_GAS_ALQ').replaceWith('<div>' + $('#IMP_GAS_ALQ').val() + '</div>');
        $('#IMP_PER_REN').replaceWith('<div>' + $('#IMP_PER_REN').val() + '</div>');
        $('#COB_PDR_MESES').replaceWith('<div>' + $('#COB_PDR_MESES').val() + '</div>');
        $('#IMP_MER_TRA').replaceWith('<div>' + $('#IMP_MER_TRA').val() + '</div>');
        $('#cod_tip_med_rdm').next().replaceWith('<div>' + $('#cod_tip_med_rdm option:selected').text() + '</div>');
        $('#IMP_INT_NEG').replaceWith('<div>' + $('#IMP_INT_NEG').val() + '</div>');
        $('#COB_IDN_MESES').replaceWith('<div>' + $('#COB_IDN_MESES').val() + '</div>');
        $('#cod_tip_rgo_idn').replaceWith('<div>' + $('#cod_tip_rgo_idn option:selected').text() + '</div>');
        $('#IMP_MOBILIARIO').replaceWith('<div>' + $('#IMP_MOBILIARIO').val() + '</div>');
        $('#IMP_MAQUINARIA').replaceWith('<div>' + $('#IMP_MAQUINARIA').val() + '</div>');
        $('#IMP_EQUIP_ELEC').replaceWith('<div>' + $('#IMP_EQUIP_ELEC').val() + '</div>');
        $('#IMP_EQUIP_ELEC_M').replaceWith('<div>' + $('#IMP_EQUIP_ELEC_M').val() + '</div>');
        $('#IMP_MERCADERIA').replaceWith('<div>' + $('#IMP_MERCADERIA').val() + '</div>');
        $('#IMP_BIE_TEM_DES').replaceWith('<div>' + $('#IMP_BIE_TEM_DES').val() + '</div>');
        $('#IMP_BIE_INT').replaceWith('<div>' + $('#IMP_BIE_INT').val() + '</div>');
        $('#IMP_OBJ_ESP_VAL').replaceWith('<div>' + $('#IMP_OBJ_ESP_VAL').val() + '</div>');
        $('#cod_tip_med_inc').next().replaceWith('<div>' + $('#cod_tip_med_inc option:selected').text() + '</div>');
        $('label[for=MCA_EXTIN_INC').next().replaceWith('<div>' + $('label[for=MCA_EXTIN_INC_' + app.ui.GetRadioNumericValue('MCA_EXTIN_INC') + '').html() + '</div>');
        $('#NUM_EXTIN_INC').replaceWith('<div>' + $('#NUM_EXTIN_INC').val() + '</div>');


        //$('#tercerosNew').addClass('d-none');
        //$('#tercerosTbl').bootstrapTable('hideColumn', 'Actions');
        //$('#documentosrequeridosNew').addClass('d-none');
        //$('#documentosrequeridosTbl').bootstrapTable('hideColumn', 'Actions');
    };

    function Init_Lookups(data) {
        setupData = JSON.parse(JSON.stringify(data));
        app.core.Lookups([
            'MonedasPorRamo.cod_mon',
            'FrecuenciaDePagoPorRamo.cod_fracc_pago',
            'Paises.cod_pais',
            'Provincias.cod_estado',
            'Cantones.cod_prov',
            'Distritos.cod_localidad',
            'TiposOcupacion.cod_tip_ocup',
            'TiposEdificacion.cod_tip_edit',
            'NumeroPisosEdificacion.num_pisos_edif',
            'TipoEstructura.cod_tipo_estruc',
            'TipoTechoEdificacion.cod_tipo_techo',
            'TipoParedEdificacion.cod_tipo_pared',
            'TipoMedidasRobo.cod_tip_med_rob',
            'TipoMedidasRoturaMaquinaria.cod_tip_med_rdm',
            'TipoRiesgoInterrupNegocios.cod_tip_rgo_idn',
            'TiposMedidasContraIncendio.cod_tip_med_inc',
            'Paises.tercerosCod_pais', 'Provincias.TProvincia', 'Cantones.TCanton', 'Distritos.TDistrito'],
            function () {
                MapObjectToInput(data);
                ReadOnly();
            }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}:cod_pais=${data.cod_pais}:cod_tip_ocup=${data.cod_ramo}%:cod_estado=${data.cod_estado}:cod_prov=${data.cod_prov}`);

        // Dependencies events
        $('#cod_estado').on('change', function () {
            var cod_pais = $('select#cod_pais').val();
            app.core.LookupDependency($('select#cod_estado').val(), 'cod_prov', 'Cantones', '', null, true, null, `cod_pais=${cod_pais}:cod_estado=`);
        });
        $('#cod_prov').on('change', function () {
            var cod_pais = $('select#cod_pais').val();
            app.core.LookupDependency($('select#cod_prov').val(), 'cod_localidad', 'Distritos', '', null, false, null, `cod_pais=${cod_pais}:cod_prov=`);
        });

        $('#TProvincia').on('change', function () {
            var pais = $('select#tercerosCod_pais').val();
            app.core.LookupDependency($('select#TProvincia').val(), 'TCanton', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
        });
        $('#TCanton').on('change', function () {
            var pais = $('select#tercerosCod_pais').val();
            app.core.LookupDependency($('select#TCanton').val(), 'TDistrito', 'Distritos', '', null, false, null, `cod_pais=${pais}:cod_prov=`);
        });
    }

    function MapInputToObject() {
        var data = setupData;
        data.anodeconstruccion = app.ui.GetNumericValue('#anodeconstruccion');
        data.terceros = $('#tercerosTbl').bootstrapTable('getData');
        data.documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');
        return data;
    };

    function MapObjectToInput(data) {
        $('#cod_mon').val(data.cod_mon);
        $('#cod_fracc_pago').val(data.cod_fracc_pago);
        app.ui.SetDateValue('#fec_efec_poliza', data.fec_efec_poliza);
        $('#fec_vcto_poliza_group').data("DateTimePicker").minDate($('#fec_efec_poliza_group').data("DateTimePicker").date());
        app.ui.SetDateValue('#fec_vcto_poliza', data.fec_vcto_poliza);
        $('#cod_pais').val(data.cod_pais);
        $('#cod_estado').val(data.cod_estado);
        $('#cod_prov').val(data.cod_prov);
        $('#cod_localidad').val(data.cod_localidad);
        $('#otrassenasdelriesgo').val(data.otrassenasdelriesgo);
        $('#cod_tip_ocup').val(data.cod_tip_ocup);
        $('#cod_tip_edit').val(data.cod_tip_edit);
        $('#num_pisos_edif').val(data.num_pisos_edif);
        $('#cod_tipo_estruc').val(data.cod_tipo_estruc);
        $('#cod_tipo_techo').val(data.cod_tipo_techo);
        $('#cod_tipo_pared').val(data.cod_tipo_pared);
        app.ui.SetNumericValue('#anodeconstruccion', data.anodeconstruccion);
        app.ui.SetNumericValue('#IMP_EDIFICIO', data.IMP_EDIFICIO);
        $('#cod_tip_med_rob').val(data.cod_tip_med_rob);
        app.ui.SetNumericValue('#IMP_DOMOS_TOTAL', data.IMP_DOMOS_TOTAL);
        app.ui.SetNumericValue('#IMP_GAS_ALQ', data.IMP_GAS_ALQ);
        app.ui.SetNumericValue('#IMP_PER_REN', data.IMP_PER_REN);
        app.ui.SetNumericValue('#COB_PDR_MESES', data.COB_PDR_MESES);
        app.ui.SetNumericValue('#IMP_MER_TRA', data.IMP_MER_TRA);
        $('#cod_tip_med_rdm').val(data.cod_tip_med_rdm);
        app.ui.SetNumericValue('#IMP_INT_NEG', data.IMP_INT_NEG);
        app.ui.SetNumericValue('#COB_IDN_MESES', data.COB_IDN_MESES);
        $('#cod_tip_rgo_idn').val(data.cod_tip_rgo_idn);
        app.ui.SetNumericValue('#IMP_MOBILIARIO', data.IMP_MOBILIARIO);
        app.ui.SetNumericValue('#IMP_MAQUINARIA', data.IMP_MAQUINARIA);
        app.ui.SetNumericValue('#IMP_EQUIP_ELEC', data.IMP_EQUIP_ELEC);
        app.ui.SetNumericValue('#IMP_EQUIP_ELEC_M', data.IMP_EQUIP_ELEC_M);
        app.ui.SetNumericValue('#IMP_MERCADERIA', data.IMP_MERCADERIA);
        app.ui.SetNumericValue('#IMP_BIE_TEM_DES', data.IMP_BIE_TEM_DES);
        app.ui.SetNumericValue('#IMP_BIE_INT', data.IMP_BIE_INT);
        app.ui.SetNumericValue('#IMP_OBJ_ESP_VAL', data.IMP_OBJ_ESP_VAL);
        $('#cod_tip_med_inc').val(data.cod_tip_med_inc);
        app.ui.SetRadioNumericValue('MCA_EXTIN_INC', data.MCA_EXTIN_INC);
        app.ui.SetNumericValue('#NUM_EXTIN_INC', data.NUM_EXTIN_INC);
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
        $('#fec_efec_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fec_vcto_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#anodeconstruccion', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '9999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_EDIFICIO', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#cod_tip_med_rob').select2({ width: '100%', theme: 'bootstrap4' });
        new AutoNumeric('#IMP_DOMOS_TOTAL', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_GAS_ALQ', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_PER_REN', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#COB_PDR_MESES', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_MER_TRA', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#cod_tip_med_rdm').select2({ width: '100%', theme: 'bootstrap4' });
        new AutoNumeric('#IMP_INT_NEG', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#COB_IDN_MESES', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_MOBILIARIO', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_MAQUINARIA', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_EQUIP_ELEC', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_EQUIP_ELEC_M', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_MERCADERIA', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_BIE_TEM_DES', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_BIE_INT', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_OBJ_ESP_VAL', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#cod_tip_med_inc').select2({ width: '100%', theme: 'bootstrap4' });
        new AutoNumeric('#NUM_EXTIN_INC', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '9999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        $("#cotizar").appendTo("#GenericToolBar");

    };

    function Controls_Events() {

        $("#VisualizationsEdtForm :input").change(function () {
            data_changed();
        });

        $('#fec_efec_poliza').blur(function () {
            var minDate = app.ui.GetDateRawValue('#fec_efec_poliza');
            minDate.setDate(minDate.getDate() + 1);

            $('#fec_vcto_poliza_group').data("DateTimePicker").minDate(minDate);

            let fec_vcto = app.ui.GetDateRawValue('#fec_efec_poliza');
            fec_vcto.setFullYear(fec_vcto.getFullYear() + 1);
            app.ui.SetDateValue('#fec_vcto_poliza', fec_vcto);
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
        app.ui.NumericValidators();
        $("#VisualizationsEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                cod_mon: { required: true },
                cod_fracc_pago: { required: true },
                fec_efec_poliza: { required: true },
                fec_vcto_poliza: { required: true },
                anodeconstruccion: { required: true, Numeric: true},
                IMP_EDIFICIO: { required: true },
                cod_tip_med_rob: { required: true },
                IMP_DOMOS_TOTAL: { required: true },
                IMP_GAS_ALQ: { required: true },
                IMP_PER_REN: { required: true },
                COB_PDR_MESES: { required: true },
                IMP_MER_TRA: { required: true },
                cod_tip_med_rdm: { required: true },
                IMP_INT_NEG: { required: true },
                COB_IDN_MESES: { required: true },
                cod_tip_rgo_idn: { required: true },
                NUM_EXTIN_INC: { required: true }
            },
            messages: {
                cod_mon: { required: 'Debe indicar el Moneda' },
                cod_fracc_pago: { required: 'Debe indicar el Fraccionamiento de pago' },
                fec_efec_poliza: { required: 'Debe indicar el Inicio de vigencia' },
                fec_vcto_poliza: { required: 'Debe indicar el Fin de vigencia' },
                anodeconstruccion: { required: 'Debe indicar el año de construcción', Numeric: 'Debe indicar el año de construcción'},
                IMP_EDIFICIO: { required: 'Debe indicar el Edificio' },
                cod_tip_med_rob: { required: 'Debe indicar el Tipo de medida por robo' },
                IMP_DOMOS_TOTAL: { required: 'Debe indicar el Rotura domo, cristales, mármol y granito' },
                IMP_GAS_ALQ: { required: 'Debe indicar el Gastos por alquiler' },
                IMP_PER_REN: { required: 'Debe indicar el Perdida de rentas' },
                COB_PDR_MESES: { required: 'Debe indicar el Meses a amparar' },
                IMP_MER_TRA: { required: 'Debe indicar el Mercancía en tránsito' },
                cod_tip_med_rdm: { required: 'Debe indicar el Tipo de medida por rotura de maquinaria' },
                IMP_INT_NEG: { required: 'Debe indicar el Interrupción de negocios' },
                COB_IDN_MESES: { required: 'Debe indicar el Meses a amparar' },
                cod_tip_rgo_idn: { required: 'Debe indicar el Tipo de riesgos por interrupción de negocios' },
                NUM_EXTIN_INC: { required: 'Debe indicar el Cuantos extintores de incendio' }
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
            $('#tercerosTbl-error').html('Debe indicar la información de terceros');
            $('#tercerosTbl-error').removeClass('d-none');
            result = result + 1;
        }

        var lista = documentosrequeridos.filter(function (row) {
            return (row.DStored === null || row.DStored === '');
        });
        if (lista.length > 0) {
            $('#documentosrequeridosTbl-error').html('Debe cargar todos los documentos pendientes');
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
                    field: 'mca_sexoDesc',
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
                    field: 'tercerosCod_paisDesc',
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
                mca_sexo: null,
                estadoCivil: null,
                numerodetelefono: null,
                correoelectronico: null,
                tercerosCod_pais: 'CRI',
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
                mca_sexo: $('#mca_sexo').val(),
                mca_sexoDesc: $('#mca_sexo option:selected').text(),
                estadoCivil: $('#estadoCivil').val(),
                estadoCivilDesc: $('#estadoCivil option:selected').text(),
                numerodetelefono: $('#numerodetelefono').val(),
                correoelectronico: $('#correoelectronico').val(),
                tercerosCod_pais: $('#tercerosCod_pais').val(),
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
        $('#mca_sexo').val(row.mca_sexo);
        $('#estadoCivil').val(row.estadoCivil);
        $('#numerodetelefono').val(row.numerodetelefono);
        $('#correoelectronico').val(row.correoelectronico);
        $('#tercerosCod_pais').val(row.tercerosCod_pais);
        $('#TProvincia').val(row.TProvincia);
        $('#TCanton').val(row.TCanton);
        $('#TDistrito').val(row.TDistrito);
        $('#otrasenas').val(row.otrasenas);
        app.ui.SetRadioNumericValue('eltomadoreselmismoasegurado', row.eltomadoreselmismoasegurado);
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
                mca_sexo: { required: true },
                estadoCivil: { required: true },
                numerodetelefono: { required: true },
                correoelectronico: { required: true, email: true },
                tercerosCod_pais: { required: true },
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
                mca_sexo: { required: 'Debe indicar el Sexo' },
                estadoCivil: { required: 'Debe indicar el Estado Civil' },
                numerodetelefono: { required: 'Debe indicar el Número de teléfono' },
                correoelectronico: { required: 'Debe indicar el Correo electrónico', email: 'Debe indicar un correo electrónico valido' },
                tercerosCod_pais: { required: 'Debe indicar el País' },
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
                DDDescripcion: {
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
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.tercerosId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMultirriesgo.tercerosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionMultirriesgo.tercerosEditRow(row);
        e.stopPropagation();
    }
};
window.documentosrequeridosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el documento requerido '" + row.documentosrequeridosId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMultirriesgo.documentosrequeridosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionMultirriesgo.documentosrequeridosEditRow(row);
        e.stopPropagation();
    }
};