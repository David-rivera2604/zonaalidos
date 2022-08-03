var app = app || {};

//Aliniacion a la derecha de los combos
//select { text-align-last: right; }
//option { direction: rtl; }

app.CotizacionMapfreMas = (function () {

    let fec_vcto_poliza_grupo = null;
    var workMode = '';
    var setupData = null;
    var quoteData = null;
    var showCalculate = false;
    var coberturas = null;

    function Setup() {
        if (localStorage.getItem('Roles').includes('Purdy')) {
            $('.tipodeproductoZone').addClass('d-none');
            $('.contratanteZone').removeClass('col-md-8');
            $('.contratanteZone').addClass('col-md-12');

            $("label[for='nombredelcontratante']").html($("label[for='nombredelcontratante']").html() + "<span class='required-mark' title='Este campo debe ser llenado de forma obligatoria'>*</span>")
        }
        if (localStorage.getItem('Roles').includes('Purdy') || localStorage.getItem('Roles').includes('Davivienda_Prendarios') || localStorage.getItem('Roles').includes('Davivienda_Leasing')) {
            $('#emitir').html("<i class='fa fa-check'></i> Completar solicitud");
            workMode = '&mode=draft';
        }
        $('#coberturasTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/Quote/MapfreMasSetup')
            .done(function (data, textStatus, jqXHR) {
                Init_Lookups(data);
            });
    }

    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Quote/MapfreMasQuote',
            JSON.stringify(MapInputToObject()),
            function (data) {
                quoteData = data;
                if (!app.ui.NotifyErrors(data.Mensaje, data.Errors, '#VisualizationsEdtForm')) {
                    $('#coberturasRow').removeClass('d-none');
                    $('#coberturasTbl').bootstrapTable('load', data.coberturas);
                    Coberturas_Fijas(data.coberturas);
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
    }

    function Init_Lookups(data) {
        let lookupList = [
            'MM_Sexo.mca_sexo',
            'MonedasPorRamo.cod_mon',
            'FrecuenciaDePagoPorRamo.cod_fracc_pago',
            'ZonaCirculacion.cod_zona_circul',
            'MM_MarcasVehiculos.cod_marca',
            'MM_ModelosVehiculos.cod_modelo',
            'UsoVehiculo.cod_uso_vehi',
            'MM_DEDU_AUTOSUS.DedudAutoSust'];

        setupData = JSON.parse(JSON.stringify(data));
        if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
            lookupList.push('MM_POLIZA_GRUPO.contrato'); //, 'MM_SUB_CONTRATOS.subcontrato'
            $('#polizagrupoZone').removeClass('d-none');
        }
        app.core.Lookups(lookupList,
            function () {
                MapObjectToInput_First(data);
                SettingReload(function () {
                    MapObjectToInput(data);
                    data_changed();
                });
            }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}:edad=${data.edad}:plan=${data.tipo_prod}:cod_marca=${data.cod_marca}`);

        // Dependencies events
        $('#cod_marca').on('change', function () {
            app.core.LookupDependency($('select#cod_marca').val(), 'cod_modelo', 'MM_ModelosVehiculos', '', null, true, null, `cod_marca=`);
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

        $('input:radio[name=tipo_prod]').change(function () {
            var data = {
                cod_ramo: setupData.cod_ramo,
                edad: app.ui.GetNumericValue('#edad'),
                cod_mon: app.ui.GetDropDownNumericValue('#cod_mon'),
                tipo_prod: $('input:radio[name=tipo_prod]:checked').val(),
                cod_marca: app.ui.GetDropDownNumericValue('#cod_marca')
            };

            if (data.tipo_prod === 'trebolrc') {
                $('#cod_uso_vehi').val('1');
                app.ui.DropDownDisabled('#cod_uso_vehi', true, false);
                app.ui.SetNumericValue('#IMP_VR', 0);
                $('#IMP_VR').prop('disabled', true);
            } else {
                app.ui.DropDownDisabled('#cod_uso_vehi', false, false);
                $('#IMP_VR').prop('disabled', false);
            }

            app.core.Lookups([
                'MM_Plan.COD_PLAN_AUTO'],
                function () {
                    if ($('#COD_PLAN_AUTO option').length == 1) {
                        $("#COD_PLAN_AUTO").val($("#COD_PLAN_AUTO option:first").val());
                    }
                    SettingReload();
                }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}:edad=${data.edad}:plan=${data.tipo_prod}:cod_marca=${data.cod_marca}`);

        });

        $('#COD_PLAN_AUTO, #cod_tip_vehi, #cod_uso_vehi').on('change', function () {
            CoverageReload();
        });

        $('#cod_mon').on('change', function () {

            if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
                let cod_mon = app.ui.GetDropDownNumericValue('#cod_mon');
                app.ui.DropDownDisabled('#subcontrato', true, true);
                app.core.Lookups([
                    'MM_POLIZA_GRUPO.contrato'],
                    function () {
                        SettingReload();
                    }, `cod_ramo=${data.cod_ramo}:cod_mon=${cod_mon}`);
            } else {
                SettingReload();
            }

        });

    }

    function MapInputToObject() {
        let contracto = app.ui.GetDropDownNumericValue('#contrato');
        return {
            cod_ramo: setupData.cod_ramo,
            edad: app.ui.GetNumericValue('#edad'),
            nombredelcontratante: $('#nombredelcontratante').val(),
            mca_sexo: app.ui.GetDropDownNumericValue('#mca_sexo'),
            mca_sexoDesc: $("#mca_sexo option:selected").text(),
            cod_mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            cod_monDesc: $("#cod_mon option:selected").text(),
            cod_fracc_pago: app.ui.GetDropDownNumericValue('#cod_fracc_pago'),
            fec_efec_poliza: app.ui.GetDateValue('#fec_efec_poliza'),
            fec_vcto_poliza: app.ui.GetDateValue('#fec_vcto_poliza'),
            tipo_prod: app.ui.GetRadioStringValue('tipo_prod'),
            tipo_prodDesc: $('input:radio[name=tipo_prod]:checked').next().html(),
            COD_PLAN_AUTO: app.ui.GetDropDownNumericValue('#COD_PLAN_AUTO'),
            COD_PLAN_AUTODesc: $("#COD_PLAN_AUTO option:selected").text(),
            cod_zona_circul: app.ui.GetDropDownNumericValue('#cod_zona_circul'),
            cod_zona_circulDesc: $("#cod_zona_circul option:selected").text(),
            cod_marca: app.ui.GetDropDownNumericValue('#cod_marca'),
            cod_marcaDesc: $("#cod_marca option:selected").text(),
            cod_modelo: app.ui.GetDropDownNumericValue('#cod_modelo'),
            cod_modeloDesc: $("#cod_modelo option:selected").text(),
            ANIO_SUB_MODELO: app.ui.GetNumericValue('#ANIO_SUB_MODELO'),
            NUM_MATRICULA: $('#NUM_MATRICULA').val(),
            COD_CHASSIS: $('#COD_CHASSIS').val(),
            NUM_MOTOR: $('#NUM_MOTOR').val(),
            cod_tip_vehi: app.ui.GetDropDownNumericValue('#cod_tip_vehi'),
            cod_tip_vehiDesc: $("#cod_tip_vehi option:selected").text(),
            cod_uso_vehi: app.ui.GetDropDownNumericValue('#cod_uso_vehi'),
            cod_uso_vehiDesc: $("#cod_uso_vehi option:selected").text(),
            MCA_CERO_KM: app.ui.GetRadioNumericValue('MCA_CERO_KM'),
            MCA_AUTO_GPS: app.ui.GetRadioNumericValue('MCA_AUTO_GPS'),
            MCA_AUTO_GPS_CMS: app.ui.GetRadioNumericValue('MCA_AUTO_GPS_CMS'),
            MCA_MONITOREO_GPS: app.ui.GetRadioNumericValue('MCA_MONITOREO_GPS'),
            MCA_PRA: app.ui.GetRadioNumericValue('MCA_PRA'),
            MCA_VR: app.ui.GetRadioNumericValue('MCA_VR'),
            IMP_VR: app.ui.GetNumericValue('#IMP_VR'),
            MCA_DESC_CLIENTE_NUEVO: app.ui.GetRadioNumericValue('MCA_DESC_CLIENTE_NUEVO'),
            PCT_AJUSTE_GEN: app.ui.GetNumericValue('#PCT_AJUSTE_GEN'),
            IMP_AUTO_RC: app.ui.GetDropDownNumericValue('#IMP_AUTO_RC'),
            DED_AUTO_RC: app.ui.GetDropDownNumericValue('#DED_AUTO_RC'),
            IMP_AUTO_GMO: app.ui.GetDropDownNumericValue('#IMP_AUTO_GMO'),
            IMP_AUTO_ACO: app.ui.GetDropDownNumericValue('#IMP_AUTO_ACO'),
            IMP_AUTO_CYV: app.ui.GetNumericValue('#IMP_AUTO_CYV'),
            DED_AUTO_CYV: app.ui.GetDropDownNumericValue('#DED_AUTO_CYV'),
            IMP_AUTO_RAD: app.ui.GetNumericValue('#IMP_AUTO_RAD'),
            DED_AUTO_RAD: app.ui.GetDropDownNumericValue('#DED_AUTO_RAD'),
            IMP_AUTO_ROB: app.ui.GetNumericValue('#IMP_AUTO_ROB'),
            DED_AUTO_ROB: app.ui.GetDropDownNumericValue('#DED_AUTO_ROB'),
            IMP_AUTO_EQESP: app.ui.GetNumericValue('#IMP_AUTO_EQESP'),
            DED_AUTO_EQESP: app.ui.GetDropDownNumericValue('#DED_AUTO_EQESP'),
            IMP_AUTO_NEUM: app.ui.GetDropDownNumericValue('#IMP_AUTO_NEUM'),
            IMP_AUTO_MECA: app.ui.GetDropDownNumericValue('#IMP_AUTO_MECA'),
            IMP_AUTO_CRI: app.ui.GetDropDownNumericValue('#IMP_AUTO_CRI'),
            DED_AUTO_CRI: app.ui.GetDropDownNumericValue('#DED_AUTO_CRI'),
            coberturas: $('#coberturasTbl').bootstrapTable('getData'),
            plandepago: $('#plandepagoTbl').bootstrapTable('getData'),
            contrato: contracto,
            subcontrato: app.ui.GetDropDownNumericValue('#subcontrato'),
            polizagrupo: setupData.polizagrupo
        };
    }

    function MapObjectToInput_First(data) {
        app.ui.SetNumericValue('#edad', data.edad);
        $('#mca_sexo').val(data.mca_sexo);
        $('#nombredelcontratante').val(data.nombredelcontratante);
        $('#cod_mon').val(data.cod_mon);
        $('#cod_fracc_pago').val(data.cod_fracc_pago);
        $('#cod_zona_circul').val(data.cod_zona_circul);
        $('#cod_marca').val(data.cod_marca);
        $('#cod_modelo').val(data.cod_modelo);
        $('#cod_tip_vehi').val(data.cod_tip_vehi);
        $('#cod_uso_vehi').val(data.cod_uso_vehi);
        app.ui.SetRadioStringValue('tipo_prod', data.tipo_prod);
        app.ui.SetDateValue('#fec_efec_poliza', data.fec_efec_poliza);
        $('#fec_vcto_poliza_group').data("DateTimePicker").minDate($('#fec_efec_poliza_group').data("DateTimePicker").date());
    }

    function MapObjectToInput(data) {
        app.ui.SetDateValue('#fec_vcto_poliza', data.fec_vcto_poliza);
        $('#COD_PLAN_AUTO').val(data.COD_PLAN_AUTO);
        app.ui.SetNumericValue('#ANIO_SUB_MODELO', data.ANIO_SUB_MODELO);
        app.ui.SetRadioNumericValue('MCA_CERO_KM', data.MCA_CERO_KM);
        app.ui.SetRadioNumericValue('MCA_AUTO_GPS', data.MCA_AUTO_GPS);
        app.ui.SetRadioNumericValue('MCA_AUTO_GPS_CMS', data.MCA_AUTO_GPS_CMS);
        app.ui.SetRadioNumericValue('MCA_MONITOREO_GPS', data.MCA_MONITOREO_GPS);
        app.ui.SetRadioNumericValue('MCA_PRA', data.MCA_PRA);
        app.ui.SetRadioNumericValue('MCA_VR', data.MCA_VR);
        app.ui.SetNumericValue('#IMP_VR', data.IMP_VR);
        app.ui.SetRadioNumericValue('MCA_DESC_CLIENTE_NUEVO', data.MCA_DESC_CLIENTE_NUEVO);
        app.ui.SetNumericValue('#PCT_AJUSTE_GEN', data.PCT_AJUSTE_GEN);
        $('#IMP_AUTO_RC').val(data.IMP_AUTO_RC);
        $('#DED_AUTO_RC').val(data.DED_AUTO_RC);
        $('#IMP_AUTO_GMO').val(data.IMP_AUTO_GMO);
        $('#IMP_AUTO_ACO').val(data.IMP_AUTO_ACO);
        app.ui.SetNumericValue('#IMP_AUTO_CYV', data.IMP_AUTO_CYV);
        $('#DED_AUTO_CYV').val(data.DED_AUTO_CYV);
        app.ui.SetNumericValue('#IMP_AUTO_RAD', data.IMP_AUTO_RAD);
        $('#DED_AUTO_RAD').val(data.DED_AUTO_RAD);
        app.ui.SetNumericValue('#IMP_AUTO_ROB', data.IMP_AUTO_ROB);
        $('#DED_AUTO_ROB').val(data.DED_AUTO_ROB);
        app.ui.SetNumericValue('#IMP_AUTO_EQESP', data.IMP_AUTO_EQESP);
        $('#DED_AUTO_EQESP').val(data.DED_AUTO_EQESP);
        $('#IMP_AUTO_NEUM').val(data.IMP_AUTO_NEUM);
        $('#IMP_AUTO_MECA').val(data.IMP_AUTO_MECA);
        $('#IMP_AUTO_CRI').val(data.IMP_AUTO_CRI);
        $('#DED_AUTO_CRI').val(data.DED_AUTO_CRI);
        if (data.coberturas != null)
            $('#coberturasTbl').bootstrapTable('load', data.coberturas);
        else
            $('#coberturasTbl').bootstrapTable('load', {});
        coberturas = data.coberturas;
        Coberturas_Fijas(data.coberturas);
        $('#coberturasTbl').bootstrapTable('hideLoading');
        if (data.plandepago != null)
            $('#plandepagoTbl').bootstrapTable('load', data.plandepago);
        else
            $('#plandepagoTbl').bootstrapTable('load', {});
    }

    function Controls_setup() {
        new AutoNumeric('#edad', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        $('#fec_efec_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fec_vcto_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#ANIO_SUB_MODELO', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '',
            maximumValue: '9999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_VR', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#PCT_AJUSTE_GEN', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '0',
            minimumValue: '-25',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_AUTO_CYV', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_AUTO_RAD', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_AUTO_ROB', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#IMP_AUTO_EQESP', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        $("#cotizar").appendTo("#GenericToolBar");
        $("#limpiar").appendTo("#GenericToolBar");
    }

    function Controls_Events() {

        $("#VisualizationsEdtForm :input").change(function () {
            data_changed();
        });

        $('#fec_efec_poliza').blur(function () {
            let minDate = app.ui.GetDateRawValue('#fec_efec_poliza');
            minDate.setDate(minDate.getDate() + 1);

            $('#fec_vcto_poliza_group').data("DateTimePicker").minDate(minDate);

            if (fec_vcto_poliza_grupo != null) {
                app.ui.SetDateValue('#fec_vcto_poliza', fec_vcto_poliza);
            } else {
                let fec_vcto = app.ui.GetDateRawValue('#fec_efec_poliza');
                fec_vcto.setFullYear(fec_vcto.getFullYear() + 1);
                app.ui.SetDateValue('#fec_vcto_poliza', fec_vcto);
            }

        });

        $('#cotizar').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
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
            MapObjectToInput_First(setupData);
            MapObjectToInput(setupData);
            $("#VisualizationsEdtForm").validate().resetForm();
            app.ui.ButtonDone('#limpiar');
            event.preventDefault();
        });

        $('#print').click(function () {
            event.preventDefault();
            let data = MapInputToObject();
            data.plandepagoporfrecuencia = quoteData.plandepagoporfrecuencia;
            data.presupuesto = quoteData.presupuesto;
            data.Agente = setupData.Agente;
            app.Cotizacion.Imprimir('MapfreMas', data);
        });

        $('#emitir').click(function () {
            event.preventDefault();
            window.location.replace(app.setting.basepath + 'emision/mapfremas?presupuesto=' + quoteData.presupuesto + workMode);
        });

        $('#IMP_VR').change(function () {
            var value = app.ui.GetNumericValue('#IMP_VR');

            if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3004))
                app.ui.SetNumericValue('#IMP_AUTO_CYV', value);
            else
                app.ui.SetNumericValue('#IMP_AUTO_CYV', 0);

            if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3005))
                app.ui.SetNumericValue('#IMP_AUTO_RAD', value);
            else
                app.ui.SetNumericValue('#IMP_AUTO_RAD', 0);

            if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3006))
                app.ui.SetNumericValue('#IMP_AUTO_ROB', value);
            else
                app.ui.SetNumericValue('#IMP_AUTO_ROB', 0);
            data_changed();

            $("#VisualizationsEdtForm").validate().resetForm();
        });
    }

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();

        $.validator.addMethod("Purdy_TextRequired",
            function (value, element, params) {
                if (!localStorage.getItem('Roles').includes('Purdy'))
                    return true;
                else {
                    return (value != '');
                }
            }
        );
        $.validator.addMethod("ValorRequeridoSegunVechiculoPlan",
            function (value, element, params) {
                let cod_tip_vehi = app.ui.GetDropDownNumericValue('#cod_tip_vehi');
                let cod_plan_auto = app.ui.GetDropDownNumericValue('#COD_PLAN_AUTO');

                if (cod_tip_vehi === 2 && cod_plan_auto != 32 && cod_plan_auto != 33) {
                    return true;
                }
                else if (cod_plan_auto == 35) {
                    return true;
                }
                else {
                    return (value != '0');
                }
            }
        );
        $.validator.addMethod("AnoFabricacion",
            function (value, element, params) {
                if (localStorage.getItem('Roles').includes('Privilegios') || localStorage.getItem('Roles').includes('Purdy'))
                    return true;
                else {
                    let nvalue = parseInt(value, 10);
                    let year = new Date().getFullYear();
                    let minYear = year - 15;
                    let maxYear = year + 2;
                    if (nvalue >= minYear && nvalue <= maxYear) {
                        return true;
                    }
                    else {
                        $('#ANIO_SUB_MODELO').rules('add', { messages: { AnoFabricacion: `El año del vehículo debe estar entre ${minYear} y ${maxYear}` } });
                        return false;
                    }
                }
            }
        );
        $.validator.addMethod("AjustePorAnoFabricacion",
            function (value, element, params) {
                let nvalue = parseInt('0' + value, 10);
                let yearVeh = app.ui.GetNumericValue('#ANIO_SUB_MODELO');
                let year = new Date().getFullYear();
                let minYear = year - 5;
                if (nvalue === 0) {
                    return true;
                }
                else if (yearVeh > minYear && nvalue >= -10) {
                    return true;
                }
                else {
                    $('#PCT_AJUSTE_GEN').rules('add', { messages: { AjustePorAnoFabricacion: 'Si el vehículo esta entre 0-5 años de antigüedad, el porcentaje de ajuste comercial no debe exceder el 10%' } });
                    return false;
                }
            }
        );

        $("#VisualizationsEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                edad: { required: true },
                mca_sexo: { required: true },
                nombredelcontratante: { Purdy_TextRequired: true },
                cod_mon: { required: true },
                cod_fracc_pago: { required: true },
                fec_efec_poliza: { required: true },
                fec_vcto_poliza: { required: true },
                COD_PLAN_AUTO: { required: true },
                cod_marca: { required: true },
                cod_modelo: { required: true },
                ANIO_SUB_MODELO: { required: true, AnoFabricacion: true },
                cod_tip_vehi: { required: true },
                cod_uso_vehi: { required: true },
                IMP_VR: { required: true, Numeric: true },
                PCT_AJUSTE_GEN: { min: -25, max: 0, AjustePorAnoFabricacion: true },
                IMP_AUTO_RC: { required: true },
                DED_AUTO_RC: { required: true },
                IMP_AUTO_GMO: { ValorRequeridoSegunVechiculoPlan: true },
                IMP_AUTO_ACO: { ValorRequeridoSegunVechiculoPlan: true },
                IMP_AUTO_CYV: { required: true, Numeric: true },
                DED_AUTO_CYV: { required: true, min: 1 },
                IMP_AUTO_RAD: { required: true, Numeric: true },
                DED_AUTO_RAD: { required: true, min: 1 },
                IMP_AUTO_ROB: { required: true, Numeric: true },
                DED_AUTO_ROB: { required: true, min: 1 },
                DED_AUTO_EQESP: { required: true },
                IMP_AUTO_NEUM: { required: true },
                IMP_AUTO_MECA: { required: true },
                IMP_AUTO_CRI: { required: true },
                DED_AUTO_CRI: { required: true },
                contrato: { required: false },
                subcontrato: { required: false }
            },
            messages: {
                edad: { required: 'Debe indicar el edad' },
                mca_sexo: { required: 'Debe indicar el sexo' },
                nombredelcontratante: { Purdy_TextRequired: 'Debe indicar el nombre del contratante' },
                cod_mon: { required: 'Debe indicar el moneda' },
                cod_fracc_pago: { required: 'Debe indicar el fraccionamiento de pago' },
                fec_efec_poliza: { required: 'Debe indicar el inicio de vigencia' },
                fec_vcto_poliza: { required: 'Debe indicar el fin de vigencia' },
                COD_PLAN_AUTO: { required: 'Debe indicar el plan' },
                cod_marca: { required: 'Debe indicar el marca' },
                cod_modelo: { required: 'Debe indicar el modelo' },
                ANIO_SUB_MODELO: { required: 'Debe indicar el año del vehículo', AnoFabricacion: '' },
                cod_tip_vehi: { required: 'Debe indicar el clase del vehículo' },
                cod_uso_vehi: { required: 'Debe indicar el uso del vehículo' },
                IMP_VR: { required: 'Debe indicar el valor del vehículo asegurado', Numeric: 'Debe indicar el valor del vehículo asegurado' },
                PCT_AJUSTE_GEN: { min: 'El porcentaje de ajuste comercial debe estar entre el 0 y el -25 %', max: 'El porcentaje de ajuste comercial debe estar entre el 0 y el -25 %', AjustePorAnoFabricacion: '' },
                IMP_AUTO_RC: { required: 'Debe indicar el responsabilidad civil' },
                DED_AUTO_RC: { required: 'Debe indicar el deducible responsabilidad civil' },
                IMP_AUTO_GMO: { ValorRequeridoSegunVechiculoPlan: 'Debe indicar el monto de gastos médicos de ocupantes para el plan seleccionado' },
                IMP_AUTO_ACO: { ValorRequeridoSegunVechiculoPlan: 'Debe indicar el monto de accidentes al conductor para el plan seleccionado' },
                IMP_AUTO_CYV: { required: 'Debe indicar el valor para la colisión y el vuelco', Numeric: 'Debe indicar el valor para la colisión y el vuelco' },
                DED_AUTO_CYV: { required: 'Debe indicar el deducible para la colisión y el vuelco', min: 'Debe indicar el deducible para la colisión y el vuelco' },
                IMP_AUTO_RAD: { required: 'Debe indicar el valor para los riesgos adicionales', Numeric: 'Debe indicar el valor para los riesgos adicionales' },
                DED_AUTO_RAD: { required: 'Debe indicar el deducible riesgos adicionales', min: 'Debe indicar el deducible riesgos adicionales' },
                IMP_AUTO_ROB: { required: 'Debe indicar el valor para robo', Numeric: 'Debe indicar el valor para robo' },
                DED_AUTO_ROB: { required: 'Debe indicar el deducible para robo', min: 'Debe indicar el deducible para robo' },
                DED_AUTO_EQESP: { required: 'Debe indicar el deducible equipo especial' },
                IMP_AUTO_NEUM: { required: 'Debe indicar el garantía de neumáticos' },
                IMP_AUTO_MECA: { required: 'Debe indicar el avería mecánica' },
                IMP_AUTO_CRI: { required: 'Debe indicar el rotura de cristales' },
                DED_AUTO_CRI: { required: 'Debe indicar el deducible rotura de cristales' },
                contrato: { required: 'Debe indicar el contrato' },
                subcontrato: { required: 'Debe indicar el subcontrato' }
            }
        });
    }

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

    }

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
                    formatter: 'app.ui.DecimalWithZeroFormatter',
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
    }

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
        let cod_tip_vehi = app.ui.GetDropDownNumericValue('#cod_tip_vehi');
        let cod_plan_auto = app.ui.GetDropDownNumericValue('#COD_PLAN_AUTO');

        //$('#IMP_VR').prop('disabled', app.ui.GetRadioNumericValue('MCA_VR') === '2');

        app.ui.DropDownDisabled('#DED_AUTO_CYV', !app.Cotizacion.Coberturas_Seleccionada(coberturas, 3004) || (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3004) && app.ui.GetNumericValue('#IMP_AUTO_CYV') === 0));

        app.ui.DropDownDisabled('#DED_AUTO_ROB', !app.Cotizacion.Coberturas_Seleccionada(coberturas, 3006) || (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3006) && app.ui.GetNumericValue('#IMP_AUTO_ROB') === 0));

        app.ui.DropDownDisabled('#DED_AUTO_EQESP', $('#IMP_AUTO_EQESP').prop('disabled') && app.ui.GetNumericValue('#IMP_AUTO_EQESP') === 0);

        if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
            app.ui.DropDownDisabled('#DED_AUTO_RAD', $('#IMP_AUTO_RAD').prop('disabled') && app.ui.GetNumericValue('#IMP_AUTO_RAD') === 0);
        } else {
            // if (!$('#DED_AUTO_RAD').prop('disabled')) {
            app.ui.SelectDropDownByText('#DED_AUTO_RAD', app.ui.GetDropDownSelectedText('#DED_AUTO_CYV'));
            // }
        }

        let cod_marca = app.ui.GetDropDownNumericValue('#cod_marca');
        let tipo_prod = app.ui.GetRadioStringValue('tipo_prod');
        //31 HYUNDAI, 74 TOYOTA, 73 SUZUKI, 55 MITSUBISHI, 40 KIA, 50 MAZDA, 13 CHEVROLET, 30 HONDA
        if ((tipo_prod === 'basico' || tipo_prod === 'amplio' || tipo_prod === 'plus') &&
            (cod_marca === 31 || cod_marca === 74 || cod_marca === 73 || cod_marca === 55 || cod_marca === 40 || cod_marca === 50 || cod_marca === 13 || cod_marca === 30)) {
            app.ui.SetNumericValue('#PCT_AJUSTE_GEN', 0);
            $('#PCT_AJUSTE_GEN').prop('disabled', true);
        } else {
            $('#PCT_AJUSTE_GEN').prop('disabled', false);
        }

        if (cod_tip_vehi === 2 && (cod_plan_auto === 31 && cod_plan_auto === 32 && cod_plan_auto == 33)) {
            //La cobertura Gastos Médicos no se toma en cuenta para el auto de uso Comercial
            //La cobertura Accidentes no se toma en cuenta para el auto de uso Comercial
            app.ui.DropDownDisabled('#IMP_AUTO_GMO', true);
            app.ui.DropDownDisabled('#IMP_AUTO_ACO', true);
        }
        else {
            //La cobertura Gastos Médicos no se toma en cuenta para el plan Básico
            //La cobertura Accidentes no se toma en cuenta para el plan Básico
            app.ui.DropDownDisabled('#IMP_AUTO_GMO', cod_plan_auto === 31);
            app.ui.DropDownDisabled('#IMP_AUTO_ACO', cod_plan_auto === 31);
        }

        if (showCalculate) {
            $('#plandepagoRow').addClass('d-none');

            $('#mainBlock').addClass('col-md-12');
            $('#mainBlock').removeClass('col-md-9');
            $('#quoteBlock').addClass('d-none');


            var coberturasLocal = $('#coberturasTbl').bootstrapTable('getData');
            for (var i = 0; i < coberturasLocal.length; i++) {
                coberturasLocal[i].capital = 0;
                coberturasLocal[i].primatotal = 0;
                coberturasLocal[i].deducible = '';
                coberturasLocal[i].error = '';
            }
            $('#coberturasTbl').bootstrapTable('load', coberturasLocal);
            $('#plandepagoTbl').bootstrapTable('load', {});
            showCalculate = false;
        }
    }

    function SettingReload(callback) {
        var data = {
            cod_ramo: setupData.cod_ramo,
            edad: app.ui.GetNumericValue('#edad'),
            cod_mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            tipo_prod: $('input:radio[name=tipo_prod]:checked').val(),
            cod_marca: app.ui.GetDropDownNumericValue('#cod_marca'),
            num_contrato: app.ui.GetDropDownNumericValue('#contrato'),
            num_subcontrato: app.ui.GetDropDownNumericValue('#subcontrato'),
            num_poliza_grupo: setupData.polizagrupo
        };

        app.core.Get(app.setting.apipath + 'v1/Quote/MapfreMasSettings?' + `cod_ramo=${data.cod_ramo}&cod_mon=${data.cod_mon}&edad=${data.edad}&tipo_prod=${data.tipo_prod}&cod_marca=${data.cod_marca}&num_contrato=${data.num_contrato}&num_subcontrato=${data.num_subcontrato}&num_poliza_grupo=${data.num_poliza_grupo}`, null,
            function (settingData) {
                fec_vcto_poliza_grupo = settingData.fec_vcto_poliza_grupo;
                app.ui.SetDateValue('#fec_vcto_poliza', app.ui.GetDateValue('#fec_efec_poliza'))
                app.ui.SetDateValue('#fec_vcto_poliza', settingData.fec_vcto_poliza);

                app.ui.LookupLoad('cod_tip_vehi', settingData.cod_tip_vehi);

                app.ui.LookupLoad('COD_PLAN_AUTO', settingData.PLAN_AUTO);
                app.ui.LookupLoad('IMP_AUTO_RC', settingData.IMP_AUTO_RC);
                app.ui.DropDownDisabled('#IMP_AUTO_RC', settingData.IMP_AUTO_RC.length == 0);
                app.ui.LookupLoad('DED_AUTO_RC', settingData.DED_AUTO_RC);

                app.ui.LookupLoad('IMP_AUTO_GMO', settingData.IMP_AUTO_GMO);
                app.ui.LookupLoad('IMP_AUTO_ACO', settingData.IMP_AUTO_ACO);
                app.ui.LookupLoad('IMP_AUTO_NEUM', settingData.IMP_AUTO_NEUM);
                app.ui.LookupLoad('IMP_AUTO_MECA', settingData.IMP_AUTO_MECA);
                app.ui.LookupLoad('IMP_AUTO_CRI', settingData.IMP_AUTO_CRI);

                app.ui.LookupLoad('DED_AUTO_CRI', settingData.DED_AUTO_CRI);

                app.ui.LookupLoad('DED_AUTO_CYV', settingData.DED_AUTO_CYV);
                app.ui.LookupLoad('DED_AUTO_RAD', settingData.DED_AUTO_RAD);
                app.ui.LookupLoad('DED_AUTO_ROB', settingData.DED_AUTO_ROB);
                app.ui.LookupLoad('DED_AUTO_EQESP', settingData.DED_AUTO_EQESP);

                if (settingData.PLAN_AUTO.length == 1) {
                    $("#COD_PLAN_AUTO").val(settingData.PLAN_AUTO[0].Code);
                }
                if (callback !== undefined && callback !== null) {
                    callback();
                }
                CoverageReload();
            });

    }

    function CoverageReload() {
        //  int mca_sexo, int cod_zona_circul, int edad, int cod_plan_auto
        var param = {
            cod_mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            cod_marca: app.ui.GetDropDownNumericValue('#cod_marca'),
            cod_modelo: app.ui.GetDropDownNumericValue('#cod_modelo'),
            anio_sub_modelo: app.ui.GetNumericValue('#ANIO_SUB_MODELO'),
            cod_tip_vehi: app.ui.GetDropDownNumericValue('#cod_tip_vehi'),
            cod_uso_vehi: app.ui.GetDropDownNumericValue('#cod_uso_vehi'),
            mca_sexo: app.ui.GetDropDownNumericValue('#mca_sexo'),
            cod_zona_circul: app.ui.GetDropDownNumericValue('#cod_zona_circul'),
            edad: app.ui.GetNumericValue('#edad'),
            cod_plan_auto: app.ui.GetDropDownNumericValue('#COD_PLAN_AUTO'),
            num_contrato: app.ui.GetDropDownNumericValue('#contrato'),
            num_subcontrato: app.ui.GetDropDownNumericValue('#subcontrato'),
            num_poliza_grupo: setupData.polizagrupo == null ? '' : setupData.polizagrupo
        };
        $('#coberturasTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/Quote/MapfreMasCoverages?' + `cod_mon=${param.cod_mon}&cod_marca=${param.cod_marca}&cod_modelo=${param.cod_modelo}&anio_sub_modelo=${param.anio_sub_modelo}&cod_tip_vehi=${param.cod_tip_vehi}&cod_uso_vehi=${param.cod_uso_vehi}&mca_sexo=${param.mca_sexo}&cod_zona_circul=${param.cod_zona_circul}&edad=${param.edad}&cod_plan_auto=${param.cod_plan_auto}&num_contrato=${param.num_contrato}&num_subcontrato=${param.num_subcontrato}&num_poliza_grupo=${param.num_poliza_grupo}`)
            .done(function (data) {
                if (data != null) {
                    $('#coberturasTbl').bootstrapTable('load', data);
                    Coberturas_Fijas(data);
                    Coberturas_ManejoDeCapital();
                }
                else
                    $('#coberturasTbl').bootstrapTable('load', {});
            }).always(function () {
                $('#coberturasTbl').bootstrapTable('hideLoading');
            });
    }

    function Coberturas_ManejoDeCapital() {
        coberturas = $('#coberturasTbl').bootstrapTable('getData');

        if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3004)) {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_CYV', true);
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DED_AUTO_CYV', true);
            app.ui.SetNumericValue('#IMP_AUTO_CYV', app.ui.GetNumericValue('#IMP_VR'));
        }
        else {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_CYV', true);
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DED_AUTO_CYV', true);
            app.ui.SetNumericValue('#IMP_AUTO_CYV', 0);
            app.ui.SetDropDownNumericValue('#DED_AUTO_CYV', 0);
        }
        if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3005)) {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_RAD', true);
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DED_AUTO_RAD', true);
            app.ui.SetNumericValue('#IMP_AUTO_RAD', app.ui.GetNumericValue('#IMP_VR'));
        }
        else {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_RAD', true);
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DED_AUTO_RAD', true);
            app.ui.SetNumericValue('#IMP_AUTO_RAD', 0);
            app.ui.SetDropDownNumericValue('#DED_AUTO_RAD', 0);
        }
        if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3006)) {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_ROB', true);
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DED_AUTO_ROB', true);
            app.ui.SetNumericValue('#IMP_AUTO_ROB', app.ui.GetNumericValue('#IMP_VR'));
        }
        else {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_ROB', true);
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DED_AUTO_ROB', true);
            app.ui.SetNumericValue('#IMP_AUTO_ROB', 0);
            app.ui.SetDropDownNumericValue('#DED_AUTO_ROB', 0);
        }
        if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3009)) {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_CRI', false);
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DED_AUTO_CRI', false);
        }
        else {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_CRI', true);
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DED_AUTO_CRI', true);
            app.ui.SetNumericValue('#IMP_AUTO_CRI', 0);
            app.ui.SetDropDownNumericValue('#DED_AUTO_CRI', 0);
        }
        if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3007)) {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_EQESP', false);
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DED_AUTO_EQESP', false);
        }
        else {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_EQESP', true);
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DED_AUTO_EQESP', true);
            app.ui.SetNumericValue('#IMP_AUTO_EQESP', 0);
            app.ui.SetDropDownNumericValue('#DED_AUTO_EQESP', 0);
        }
        data_changed();
        Coberturas_Fijas(coberturas);
    }

    function Coberturas_Fijas(coberturas) {
        coberturas.forEach(function (value, index, array) {
            $('[name=btSelectItem][data-index=' + index + ']').prop('disabled', value.requerida);
        });
        $('[name=btSelectAll]').prop('disabled', true);
    }

    return {
        Data: function () {
            return MapInputToObject();
        },
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