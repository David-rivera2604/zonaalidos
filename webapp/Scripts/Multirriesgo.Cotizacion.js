var app = app || {};

app.CotizacionMultirriesgo = (function () {
    const grouped_coverage_management = true;

    let setupData = null;
    let quoteData = null;
    let showCalculate = false;
    let workMode = '';

    function Setup() {
        $('#coberturasTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/Multirriesgo/QuoteSetup')
            .done(function (data, textStatus, jqXHR) {
                if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
                    $('#polizagrupoZone').removeClass('d-none');
                    app.Cotizacion.CustomAgentHandler('pg_', data);
                } else {
                    app.Cotizacion.CustomAgentHandler('', data);
                }
                Init_Lookups(data);
            });

        if (localStorage.getItem('Roles').includes('Formularios_digitales')) {
            $('#emitir').html("<i class='fa fa-check'></i> Completar solicitud");
            workMode = '&mode=draft';
        }
        else {
            $('#emitir').html("<i class='fa fa-check'></i> Emitir");
            workMode = '&mode=continue';
        }
    };

    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Multirriesgo/Quote',
            JSON.stringify(MapInputToObject()),
            function (data) {
                quoteData = data;
                if (!app.ui.NotifyErrors(data.Mensaje, data.Errors, '#VisualizationsEdtForm')) {
                    $('#presupuesto').html(data.presupuesto);
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
    };

    function Init_Lookups(data) {
        let lookupList = [
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
            'TiposMedidasContraIncendio.cod_tip_med_inc'];
        if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
            lookupList.push('MM_POLIZA_GRUPO.contrato'); //, 'MM_SUB_CONTRATOS.subcontrato'
        };
        setupData = JSON.parse(JSON.stringify(data));
        app.core.Lookups(lookupList,
            function () {
                MapObjectToInput(data);
            }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}:cod_pais=${data.cod_pais}:cod_tip_ocup=${data.cod_ramo}%:cod_estado=${data.cod_estado}:cod_prov=${data.cod_prov}:cod_agt=${data.cod_agt}`);

        // Dependencies events
        $('#cod_estado').on('change', function () {
            var cod_pais = $('select#cod_pais').val();
            app.core.LookupDependency($('select#cod_estado').val(), 'cod_prov', 'Cantones', '', null, true, null, `cod_pais=${cod_pais}:cod_estado=`);
        });
        $('#cod_prov').on('change', function () {
            var cod_pais = $('select#cod_pais').val();
            app.core.LookupDependency($('select#cod_prov').val(), 'cod_localidad', 'Distritos', '', null, false, null, `cod_pais=${cod_pais}:cod_prov=`);
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
    }

    function SettingReload() {
        var data = {
            cod_ramo: setupData.cod_ramo,
            num_contrato: app.ui.GetDropDownNumericValue('#contrato'),
            num_subcontrato: app.ui.GetDropDownNumericValue('#subcontrato'),
            num_poliza_grupo: setupData.polizagrupo,
            cod_mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            cod_agt: app.Cotizacion.AgentCode()
        };

        $('#coberturasTbl').bootstrapTable('showLoading');

        app.core.Get(app.setting.apipath + 'v1/Multirriesgo/QuoteSettings?' + `cod_ramo=${data.cod_ramo}&num_contrato=${data.num_contrato}&num_subcontrato=${data.num_subcontrato}&num_poliza_grupo=${data.num_poliza_grupo}&cod_mon=${data.cod_mon}&cod_agt=${data.cod_agt}`)
            .done(function (settingData) {
                app.ui.SetDateValue('#fec_vcto_poliza', app.ui.GetDateValue('#fec_efec_poliza'))
                app.ui.SetDateValue('#fec_vcto_poliza', settingData.fec_vcto_poliza);

                if (settingData.coberturas != null)
                    $('#coberturasTbl').bootstrapTable('load', settingData.coberturas);
                else
                    $('#coberturasTbl').bootstrapTable('load', {});
            }).always(function () {
                $('#coberturasTbl').bootstrapTable('hideLoading');
            });
    }

    function MapInputToObject() {
        var data = {
            cod_ramo: setupData.cod_ramo,
            cod_mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            cod_monDesc: $("#cod_mon option:selected").text(),
            cod_fracc_pago: app.ui.GetDropDownNumericValue('#cod_fracc_pago'),
            fec_efec_poliza: app.ui.GetDateValue('#fec_efec_poliza'),
            fec_vcto_poliza: app.ui.GetDateValue('#fec_vcto_poliza'),
            nombredelcontratante: $('#nombredelcontratante').val(),
            cod_pais: app.ui.GetDropDownStringValue('#cod_pais'),
            cod_paisDesc: $("#cod_pais option:selected").text(),
            cod_estado: app.ui.GetDropDownNumericValue('#cod_estado'),
            cod_estadoDesc: $("#cod_estado option:selected").text(),
            cod_prov: app.ui.GetDropDownNumericValue('#cod_prov'),
            cod_provDesc: $("#cod_prov option:selected").text(),
            cod_localidad: app.ui.GetDropDownNumericValue('#cod_localidad'),
            cod_localidadDesc: $("#cod_localidad option:selected").text(),
            otrassenasdelriesgo: $('#otrassenasdelriesgo').val(),
            cod_tip_ocup: app.ui.GetDropDownNumericValue('#cod_tip_ocup'),
            cod_tip_ocupDesc: $("#cod_tip_ocup option:selected").text(),
            cod_tip_edit: app.ui.GetDropDownNumericValue('#cod_tip_edit'),
            cod_tip_editDesc: $("#cod_tip_edit option:selected").text(),
            num_pisos_edif: app.ui.GetDropDownNumericValue('#num_pisos_edif'),
            num_pisos_edifDesc: $("#num_pisos_edif option:selected").text(),
            cod_tipo_estruc: app.ui.GetDropDownNumericValue('#cod_tipo_estruc'),
            cod_tipo_estrucDesc: $("#cod_tipo_estruc option:selected").text(),
            cod_tipo_techo: app.ui.GetDropDownNumericValue('#cod_tipo_techo'),
            cod_tipo_techoDesc: $("#cod_tipo_techo option:selected").text(),
            cod_tipo_pared: app.ui.GetDropDownNumericValue('#cod_tipo_pared'),
            cod_tipo_paredDesc: $("#cod_tipo_pared option:selected").text(),
            IMP_EDIFICIO: app.ui.GetNumericValue('#IMP_EDIFICIO'),
            cod_tip_med_rob: app.ui.GetDropDownNumericValue('#cod_tip_med_rob'),
            IMP_DOMOS_TOTAL: app.ui.GetNumericValue('#IMP_DOMOS_TOTAL'),
            IMP_GAS_ALQ: app.ui.GetNumericValue('#IMP_GAS_ALQ'),
            IMP_PER_REN: app.ui.GetNumericValue('#IMP_PER_REN'),
            COB_PDR_MESES: app.ui.GetNumericValue('#COB_PDR_MESES'),
            IMP_MER_TRA: app.ui.GetNumericValue('#IMP_MER_TRA'),
            cod_tip_med_rdm: app.ui.GetDropDownNumericValue('#cod_tip_med_rdm'),
            IMP_INT_NEG: app.ui.GetNumericValue('#IMP_INT_NEG'),
            COB_IDN_MESES: app.ui.GetNumericValue('#COB_IDN_MESES'),
            cod_tip_rgo_idn: app.ui.GetDropDownNumericValue('#cod_tip_rgo_idn'),
            IMP_MOBILIARIO: app.ui.GetNumericValue('#IMP_MOBILIARIO'),
            IMP_MAQUINARIA: app.ui.GetNumericValue('#IMP_MAQUINARIA'),
            IMP_EQUIP_ELEC: app.ui.GetNumericValue('#IMP_EQUIP_ELEC'),
            IMP_EQUIP_ELEC_M: app.ui.GetNumericValue('#IMP_EQUIP_ELEC_M'),
            IMP_MERCADERIA: app.ui.GetNumericValue('#IMP_MERCADERIA'),
            IMP_BIE_TEM_DES: app.ui.GetNumericValue('#IMP_BIE_TEM_DES'),
            IMP_BIE_INT: app.ui.GetNumericValue('#IMP_BIE_INT'),
            IMP_OBJ_ESP_VAL: app.ui.GetNumericValue('#IMP_OBJ_ESP_VAL'),
            cod_tip_med_inc: app.ui.GetDropDownNumericValue('#cod_tip_med_inc'),
            MCA_EXTIN_INC: app.ui.GetRadioNumericValue('MCA_EXTIN_INC'),
            NUM_EXTIN_INC: app.ui.GetNumericValue('#NUM_EXTIN_INC'),
            coberturas: $('#coberturasTbl').bootstrapTable('getData'),
            plandepago: $('#plandepagoTbl').bootstrapTable('getData'),
            contrato: app.ui.GetDropDownNumericValue('#contrato'),
            subcontrato: app.ui.GetDropDownNumericValue('#subcontrato'),
            polizagrupo: setupData.polizagrupo,
            cod_agt: app.Cotizacion.AgentCode(),
            cod_cuadro_com: app.Cotizacion.CuadroCom()
        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#cod_mon').val(data.cod_mon);
        $('#cod_fracc_pago').val(data.cod_fracc_pago);
        app.ui.SetDateValue('#fec_efec_poliza', data.fec_efec_poliza);
        $('#fec_vcto_poliza_group').data("DateTimePicker").minDate($('#fec_efec_poliza_group').data("DateTimePicker").date());
        app.ui.SetDateValue('#fec_vcto_poliza', data.fec_vcto_poliza);
        $('#nombredelcontratante').val(data.nombredelcontratante);
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
        $('#fec_efec_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fec_vcto_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
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
        $("#limpiar").appendTo("#GenericToolBar");
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

        $('#cotizar').click(function (e) {

            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#cotizar');
                Quote();
            }
            e.preventDefault();
        });

        $('#limpiar').click(function (e) {
            app.ui.ButtonDoing('#limpiar');
            $('#mainBlock').removeClass('col-md-9');
            $('#mainBlock').addClass('col-md-12');
            $('#quoteBlock').addClass('d-none');
            $('#plandepagoRow').addClass('d-none');
            MapObjectToInput(setupData);
            app.ui.ButtonDone('#limpiar');
            e.preventDefault();
        });

        $('#print').click(function (e) {
            e.preventDefault();
            let data = MapInputToObject();
            data.plandepagoporfrecuencia = quoteData.plandepagoporfrecuencia;
            data.presupuesto = quoteData.presupuesto;
            data.Agente = setupData.Agente;
            app.Cotizacion.Imprimir('Multirriesgo', data);
        });

        $('#emitir').click(function (e) {
            e.preventDefault();
            if (localStorage.getItem('Roles').includes('Formularios_digitales')) {
                window.location.replace(app.setting.basepath + 'multirriesgo/solicitud?presupuesto=' + quoteData.presupuesto + workMode);
            }
            else {
                window.location.replace(app.setting.basepath + 'multirriesgo/emision?presupuesto=' + quoteData.presupuesto + workMode);
            }
        });

    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();

        $.validator.addMethod("Purdy_TextRequired",
            function (value, element, params) {
                if (!localStorage.getItem('Roles').includes('Agente'))
                    return true;
                else {

                    var total = parseFloat(imp_edificio.GetValue()) +
                        parseFloat(imp_mobiliario.GetValue()) +
                        parseFloat(imp_mercaderia.GetValue()) +
                        parseFloat(imp_bie_tem_des.GetValue()) +
                        parseFloat(imp_bie_int.GetValue()) +
                        parseFloat(imp_obj_esp_val.GetValue()) +
                        parseFloat(imp_domos_total.GetValue()) +
                        parseFloat(imp_gas_alq.GetValue()) +
                        parseFloat(imp_per_ren.GetValue()) +
                        parseFloat(imp_bie_ref.GetValue()) +
                        parseFloat(imp_mer_tra.GetValue()) +
                        parseFloat(imp_maquinaria.GetValue()) +
                        parseFloat(imp_equip_elec.GetValue()) +
                        parseFloat(imp_equip_elec_m.GetValue()) +
                        parseFloat(imp_int_neg.GetValue());
                    return (value != '');
                }
            }
        );

        $("#VisualizationsEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                cod_mon: { required: true },
                cod_fracc_pago: { required: true },
                fec_efec_poliza: { required: true },
                fec_vcto_poliza: { required: true },
                IMP_EDIFICIO: { required: true, Numeric: true },
                cod_tip_med_rob: { required: true },
                IMP_DOMOS_TOTAL: { required: true, Numeric: true },
                IMP_GAS_ALQ: { required: true, Numeric: true },
                IMP_PER_REN: { required: true, Numeric: true },
                COB_PDR_MESES: { required: true },
                IMP_MER_TRA: { required: true, Numeric: true },
                cod_tip_med_rdm: { required: true },
                IMP_INT_NEG: { required: true, Numeric: true },
                COB_IDN_MESES: { required: true },
                cod_tip_rgo_idn: { required: true },
                NUM_EXTIN_INC: { required: true },
                IMP_MOBILIARIO: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
                IMP_MAQUINARIA: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
                IMP_EQUIP_ELEC: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
                IMP_EQUIP_ELEC_M: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
                IMP_MERCADERIA: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
                IMP_BIE_TEM_DES: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
                IMP_BIE_INT: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
                IMP_OBJ_ESP_VAL: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' }
            },
            messages: {
                cod_mon: { required: 'Debe indicar el Moneda' },
                cod_fracc_pago: { required: 'Debe indicar el Fraccionamiento de pago' },
                fec_efec_poliza: { required: 'Debe indicar el Inicio de vigencia' },
                fec_vcto_poliza: { required: 'Debe indicar el Fin de vigencia' },
                IMP_EDIFICIO: { required: 'Debe indicar el Edificio', Numeric: 'Debe indicar el Edificio' },
                cod_tip_med_rob: { required: 'Debe indicar el Tipo de medida por robo' },
                IMP_DOMOS_TOTAL: { required: 'Debe indicar el Rotura domo, cristales, mármol y granito', Numeric: 'Debe indicar el Rotura domo, cristales, mármol y granito' },
                IMP_GAS_ALQ: { required: 'Debe indicar el Gastos por alquiler', Numeric: 'Debe indicar el Gastos por alquiler' },
                IMP_PER_REN: { required: 'Debe indicar el Perdida de rentas', Numeric: 'Debe indicar el Perdida de rentas' },
                COB_PDR_MESES: { required: 'Debe indicar el Meses a amparar' },
                IMP_MER_TRA: { required: 'Debe indicar el Mercancía en tránsito', Numeric: 'Debe indicar el Mercancía en tránsito' },
                cod_tip_med_rdm: { required: 'Debe indicar el Tipo de medida por rotura de maquinaria' },
                IMP_INT_NEG: { required: 'Debe indicar el Interrupción de negocios', Numeric: 'Debe indicar el Interrupción de negocios' },
                COB_IDN_MESES: { required: 'Debe indicar el Meses a amparar' },
                cod_tip_rgo_idn: { required: 'Debe indicar el Tipo de riesgos por interrupción de negocios' },
                NUM_EXTIN_INC: { required: 'Debe indicar el Cuantos extintores de incendio' },
                IMP_MOBILIARIO: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
                IMP_MAQUINARIA: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
                IMP_EQUIP_ELEC: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
                IMP_EQUIP_ELEC_M: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
                IMP_MERCADERIA: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
                IMP_BIE_TEM_DES: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
                IMP_BIE_INT: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
                IMP_OBJ_ESP_VAL: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' }
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
                },]
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
            pagination: true,
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

        if (grouped_coverage_management) {
            cob2001Selected = Coberturas_Seleccionada(coberturas, 2001);
            coberturas.filter(r => [2002, 2024, 2025, 2026, 2004].includes(r.codigo)).forEach(function (item, index) {
                item.seleccionado = cob2001Selected;
            });

            cob2009Selected = Coberturas_Seleccionada(coberturas, 2009);
            coberturas.filter(r => [2010, 2055, 2056, 2057, 2012].includes(r.codigo)).forEach(function (item, index) {
                item.seleccionado = cob2009Selected;
            });

            $('#coberturasTbl').bootstrapTable('load', coberturas);
            coberturas.forEach(function (value, index) {
                $('[name=btSelectItem][data-index=' + index + ']').prop('disabled',
                    [2002, 2024, 2025, 2026, 2004].includes(value.codigo) || [2010, 2055, 2056, 2057, 2012].includes(value.codigo));
            });
        }

        if (Coberturas_Seleccionada(coberturas, 2001) ||
            Coberturas_Seleccionada(coberturas, 2002) ||
            Coberturas_Seleccionada(coberturas, 2024) ||
            Coberturas_Seleccionada(coberturas, 2025) ||
            Coberturas_Seleccionada(coberturas, 2026) ||
            Coberturas_Seleccionada(coberturas, 2004)) {
            Coberturas_ComportamientoDependencia('#IMP_EDIFICIO', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#IMP_EDIFICIO', true);
            app.ui.SetNumericValue('#IMP_EDIFICIO', 0);
        }

        if (Coberturas_Seleccionada(coberturas, 2002)) {
            Coberturas_ComportamientoDependencia('#cod_tip_med_inc', false);
            $('[name=MCA_EXTIN_INC]').prop("disabled", false);
            Coberturas_ComportamientoDependencia('#NUM_EXTIN_INC', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#cod_tip_med_inc', true);
            $('[name=MCA_EXTIN_INC]').prop("disabled", true);
            Coberturas_ComportamientoDependencia('#NUM_EXTIN_INC', true);
            $('#cod_tip_med_inc').val(-1);
            $('#NUM_EXTIN_INC').val(-1);
        }

        if (Coberturas_Seleccionada(coberturas, 2008) ||
            Coberturas_Seleccionada(coberturas, 2009) ||
            Coberturas_Seleccionada(coberturas, 2010) ||
            Coberturas_Seleccionada(coberturas, 2055) ||
            Coberturas_Seleccionada(coberturas, 2056) ||
            Coberturas_Seleccionada(coberturas, 2057) ||
            Coberturas_Seleccionada(coberturas, 2012)) {
            Coberturas_ComportamientoDependencia('#IMP_MOBILIARIO', false);
            Coberturas_ComportamientoDependencia('#IMP_MAQUINARIA', false);
            Coberturas_ComportamientoDependencia('#IMP_MERCADERIA', false);
            Coberturas_ComportamientoDependencia('#IMP_BIE_TEM_DES', false);
            Coberturas_ComportamientoDependencia('#IMP_BIE_INT', false);
            Coberturas_ComportamientoDependencia('#IMP_OBJ_ESP_VAL', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#IMP_MOBILIARIO', true);
            Coberturas_ComportamientoDependencia('#IMP_MAQUINARIA', true);
            Coberturas_ComportamientoDependencia('#IMP_MERCADERIA', true);
            Coberturas_ComportamientoDependencia('#IMP_BIE_TEM_DES', true);
            Coberturas_ComportamientoDependencia('#IMP_BIE_INT', true);
            Coberturas_ComportamientoDependencia('#IMP_OBJ_ESP_VAL', true);
            app.ui.SetNumericValue('#IMP_MOBILIARIO', 0);
            app.ui.SetNumericValue('#IMP_MAQUINARIA', 0);
            app.ui.SetNumericValue('#IMP_MERCADERIA', 0);
            app.ui.SetNumericValue('#IMP_BIE_TEM_DES', 0);
            app.ui.SetNumericValue('#IMP_BIE_INT', 0);
            app.ui.SetNumericValue('#IMP_OBJ_ESP_VAL', 0);
        }

        if (Coberturas_Seleccionada(coberturas, 2008) ||
            Coberturas_Seleccionada(coberturas, 2009) ||
            Coberturas_Seleccionada(coberturas, 2010) ||
            Coberturas_Seleccionada(coberturas, 2055) ||
            Coberturas_Seleccionada(coberturas, 2056) ||
            Coberturas_Seleccionada(coberturas, 2057) ||
            Coberturas_Seleccionada(coberturas, 2012) ||
            Coberturas_Seleccionada(coberturas, 2022)) {
            Coberturas_ComportamientoDependencia('#IMP_EQUIP_ELEC', false);
            Coberturas_ComportamientoDependencia('#IMP_EQUIP_ELEC_M', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#IMP_EQUIP_ELEC', true);
            Coberturas_ComportamientoDependencia('#IMP_EQUIP_ELEC_M', true);
            app.ui.SetNumericValue('#IMP_EQUIP_ELEC', 0);
            app.ui.SetNumericValue('#IMP_EQUIP_ELEC_M', 0);
        }

        if (Coberturas_Seleccionada(coberturas, 2008)) {
            Coberturas_ComportamientoDependencia('#cod_tip_med_rob', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#cod_tip_med_rob', true);
            $('#cod_tip_med_rob').val(-1);
        }

        if (Coberturas_Seleccionada(coberturas, 2007)) {
            Coberturas_ComportamientoDependencia('#IMP_DOMOS_TOTAL', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#IMP_DOMOS_TOTAL', true);
            app.ui.SetNumericValue('#IMP_DOMOS_TOTAL', 0);
        }

        if (Coberturas_Seleccionada(coberturas, 2017)) {
            Coberturas_ComportamientoDependencia('#IMP_GAS_ALQ', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#IMP_GAS_ALQ', true);
            app.ui.SetNumericValue('#IMP_GAS_ALQ', 0);
        }

        if (Coberturas_Seleccionada(coberturas, 2018)) {
            Coberturas_ComportamientoDependencia('#IMP_PER_REN', false);
            Coberturas_ComportamientoDependencia('#COB_PDR_MESES', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#IMP_PER_REN', true);
            Coberturas_ComportamientoDependencia('#COB_PDR_MESES', true);
            app.ui.SetNumericValue('#IMP_PER_REN', 0);
            app.ui.SetNumericValue('#COB_PDR_MESES', 0);
        }

        if (Coberturas_Seleccionada(coberturas, 2020)) {
            Coberturas_ComportamientoDependencia('#IMP_MER_TRA', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#IMP_MER_TRA', true);
            app.ui.SetNumericValue('#IMP_MER_TRA', 0);
        }
        if (Coberturas_Seleccionada(coberturas, 2021)) {
            Coberturas_ComportamientoDependencia('#cod_tip_med_rdm', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#cod_tip_med_rdm', true);
            $("#cod_tip_med_rdm").val(-1);
        }
        if (Coberturas_Seleccionada(coberturas, 2023)) {
            Coberturas_ComportamientoDependencia('#IMP_INT_NEG', false);
            Coberturas_ComportamientoDependencia('#COB_IDN_MESES', false);
            Coberturas_ComportamientoDependencia('#cod_tip_rgo_idn', false);
        }
        else {
            Coberturas_ComportamientoDependencia('#IMP_INT_NEG', true);
            Coberturas_ComportamientoDependencia('#COB_IDN_MESES', true);
            Coberturas_ComportamientoDependencia('#cod_tip_rgo_idn', true);
            app.ui.SetNumericValue('#IMP_INT_NEG', 0);
            app.ui.SetNumericValue('#COB_IDN_MESES', 0);
            // $("#cod_tip_rgo_idn").val(-1);
        }

        data_changed();
    };

    return {
        Init: function () {
            Controls_setup();
            Setup_Validations();
            coberturas_table_setup();
            plandepago_table_setup();
            plandepagoporfrecuencia_table_setup();

            Controls_Events();
            Setup();
        }
    };
})();