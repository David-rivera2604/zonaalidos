var app = app || {};

//Aliniacion a la derecha de los combos
//select { text-align-last: right; }
//option { direction: rtl; }

app.CotizacionMapfreMas = (function () {

    let fec_vcto_poliza_grupo = null;
    let modelHelper = [];

    var workMode = '';
    var setupData = null;
    var quoteData = null;
    var showCalculate = false;
    var coberturas = null;

    // SettingReload()/CoverageReload() se disparan desde varios eventos
    // (cambio de contrato, tipo de producto, moneda, marca/modelo, etc.) y
    // no cancelan la llamada anterior. Si dos quedan en vuelo a la vez, las
    // respuestas del servidor pueden llegar en un orden distinto al que se
    // pidieron: la más reciente en LLEGAR gana, no la más reciente en
    // pedirse. Con latencia alta o variable (como en producción) esto pinta
    // el plan/coberturas de una selección vieja encima de la actual -por
    // ejemplo, "se queda en básico" luego de elegir otro tipo de producto.
    // Estos contadores descartan cualquier respuesta que ya no sea la del
    // último pedido hecho.
    var settingReloadSeq = 0;
    var coverageReloadSeq = 0;

    function Setup(mode) {
        app.ui.CommonBehaviour();
        if (localStorage.getItem('Roles').includes('Purdy')) {
            $('.contratanteZone').removeClass('col-md-8');
            $('.contratanteZone').addClass('col-md-12');

            $("label[for='nombredelcontratante']").html($("label[for='nombredelcontratante']").html() + "<span class='required-mark' title='Este campo debe ser llenado de forma obligatoria'>*</span>")
        }

        //if (localStorage.getItem('Roles').includes('Purdy') || localStorage.getItem('Roles').includes('Davivienda_Prendarios') ||
        //    localStorage.getItem('Roles').includes('Davivienda_Leasing')) {
        $('#emitir').html("<i class='fa fa-check'></i> Completar solicitud");
        workMode = '&mode=draft';
        //}
        //else {
        //    $('#emitir').html("<i class='fa fa-check'></i> Emitir");
        //    workMode = '&mode=continue';
        //}

        $('#coberturasTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + `v1/Quote/MapfreMasSetup?mode=${mode}`)
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
                    $('#presupuesto').html(data.presupuesto);
                    $('#coberturasRow').removeClass('d-none');
                    $('#coberturasTbl').bootstrapTable('load', data.coberturas);
                    Coberturas_Fijas(data.coberturas);
                    $('#plandepagoRow').removeClass('d-none');
                    $('#plandepagoTbl').bootstrapTable('load', data.plandepago);

                    if (data.plandepagoFull != null && data.plandepagoFull.length > 0) {
                        $('#plandepagoFullRow').removeClass('d-none');
                        $('#plandepagoFullTbl').bootstrapTable('load', data.plandepagoFull);
                    }


                    if (data.plandepagoporfrecuencia != null) {
                        $('.plandepagoporfrecuencia').removeClass('d-none');
                        $('#plandepagoporfrecuenciaTbl').bootstrapTable('load', data.plandepagoporfrecuencia);
                    }
                    else {
                        $('.plandepagoporfrecuencia').addClass('d-none');
                        $('#plandepagoporfrecuenciaTbl').bootstrapTable('load', {});
                    }


                    $('#mainBlock').removeClass('col-md-12');
                    $('#mainBlock').addClass('col-md-9');
                    $('#quoteBlock').removeClass('d-none');
                    showCalculate = true;
                    if (data.resumen != null) {
                        var moneda = "$ ";
                        if (app.ui.GetDropDownNumericValue('#cod_mon') == 1) {
                            moneda = "₡ ";
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
            app.Cotizacion.CustomAgentHandler('pg_', setupData);
        } else {
            app.Cotizacion.CustomAgentHandler('', setupData);
        }
        app.core.Lookups(lookupList,
            function () {
                MapObjectToInput_First(data);
                SettingReload(function () {
                    MapObjectToInput(data);
                    data_changed();
                });
            }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}:edad=${data.edad}:plan=${data.tipo_prod}:cod_marca=${data.cod_marca}:cod_agt=${data.cod_agt}`, 'v1/TronCommon/Lkps');

        // Dependencies events
        $('#cod_marca').on('change', function () {
            app.core.LookupDependency($('select#cod_marca').val(), 'cod_modelo', 'MM_ModelosVehiculos', '', null, true, null, `cod_marca=`, 'v1/TronCommon/LkpChild');
        });

        // Dependencies events
        $('#cod_modelo').on('change', function () {
            let data = {
                cod_marca: app.ui.GetDropDownNumericValue('#cod_marca'),
                cod_modelo: app.ui.GetDropDownNumericValue('#cod_modelo'),
                contrato: app.ui.GetDropDownNumericValue('#contrato'),
                subcontrato: app.ui.GetDropDownNumericValue('#subcontrato'),
                polizagrupo: setupData.polizagrupo,
                p_fec_validez: moment().format('YYYYMMDD'),
                cod_agt: app.Cotizacion.AgentCode()
            }
            app.core.Lookups(['MM_SubModelosVehiculos.cod_sub_modelo'], null,
                `cod_marca=${data.cod_marca}:cod_modelo=${data.cod_modelo}:p_fec_validez=${data.p_fec_validez}:polizagrupo=${data.polizagrupo}:contrato=${data.contrato}:cod_agt=${data.cod_agt}`, 'v1/TronCommon/Lkps');
        });

        $('#contrato').on('change', function () {
            let contracto = app.ui.GetDropDownNumericValue('#contrato');

            if (contracto > 0) {
                setupData.polizagrupo = app.core.Data().lookups.filter(i => i.Key === 'MM_POLIZA_GRUPO')[0].Lkp.filter(l => l.Code === contracto + '')[0].NUM_POLIZA;
            }
            AplicarRestriccionTipoProductoPorContrato(contracto);
            initializeDateTimePicker();
            SettingReload();
            app.core.LookupDependency($('select#contrato').val(), 'subcontrato', 'MM_SUB_CONTRATOS', '', null, true,
                function (lkpData) {

                    app.ui.DropDownDisabled('#subcontrato', lkpData && lkpData.length == 0);
                    if (lkpData.length != 0) {
                        $('select#subcontrato').val(app.ui.GetDropDownNumericValue('#cod_mon'));
                        $('select#subcontrato').change();
                    } { }
                },
                `cod_ramo=${setupData.cod_ramo}:num_contrato=`);
        });

        // Contratos 99780 y 99781 solo se permite el tipo de producto "Trébol"
        function AplicarRestriccionTipoProductoPorContrato(contratoValue) {
            // Esta exclusividad solo aplica a cuentas Purdy: para el resto de
            // cuentas PolizaGrupo, "Contrato" y "Tipo de producto" deben poder
            // elegirse de forma independiente, porque bloquearlos rompe el
            // flujo normal de cotización para esas cuentas.
            if (!localStorage.getItem('Roles').includes('Purdy')) {
                return;
            }

            var contratosSoloTrebol = [99780, 99781];

            // Exclusividad: "Tipo de producto" y "Contrato" son dos formas
            // alternas de indicar el mismo plan. SettingParameter() manda
            // siempre los dos juntos al backend (v1/Quote/MapfreMasSettings y
            // MapfreMasCoverages), así que si ambos llegan con valor a la vez
            // el backend recibe una combinación contradictoria y las tablas
            // de coberturas/plan de pago pueden no cargar bien. Cualquier
            // contrato elegido bloquea "Tipo de producto" -incluidos 99780 y
            // 99781, que además fuerzan "Trébol": ahí se bloquea igual pero
            // sin desmarcarlo, porque esos dos contratos SÍ necesitan que
            // quede fijo en Trébol.
            var bloquearTipoProd = contratoValue > 0;

            if (contratosSoloTrebol.indexOf(contratoValue) !== -1) {
                $('input:radio[name=tipo_prod]').not('#tipo_prod_6').closest('.custom-control').addClass('d-none');
                if (!$('#tipo_prod_6').prop('checked')) {
                    $('#tipo_prod_6').prop('checked', true);
                }
                $('input:radio[name=tipo_prod]').prop('disabled', true);
            } else {
                $('input:radio[name=tipo_prod]').closest('.custom-control').removeClass('d-none');
                $('input:radio[name=tipo_prod]').prop('disabled', bloquearTipoProd);
                if (bloquearTipoProd) {
                    $('input:radio[name=tipo_prod]').prop('checked', false);
                }
            }
            $('#contratoClearBtn').toggleClass('d-none', !bloquearTipoProd);
        }

        // Botón "Quitar selección" junto a Contrato: limpia Contrato/Sub
        // contrato y vuelve a habilitar Tipo de producto (mano a mano con
        // AplicarRestriccionTipoProductoPorContrato, que hace el bloqueo).
        $('#contratoClearBtn').on('click', function (e) {
            e.preventDefault();
            $('#contrato').prop('selectedIndex', -1);
            $('#subcontrato').prop('selectedIndex', -1).prop('disabled', true);
            // Por si el contrato quitado era uno de los especiales (99780/
            // 99781): se desmarca Trébol y se vuelven a mostrar todas las
            // opciones de "Tipo de producto" que esos contratos ocultaban.
            $('input:radio[name=tipo_prod]').prop('checked', false).prop('disabled', false).closest('.custom-control').removeClass('d-none');
            $('#contratoClearBtn').addClass('d-none');
            SettingReload();
        });

        // Botón "Quitar selección" junto a Tipo de producto: lo despinta y
        // vuelve a habilitar Contrato/Sub contrato.
        $('#tipoProdClearBtn').on('click', function (e) {
            e.preventDefault();
            $('input:radio[name=tipo_prod]').prop('checked', false);
            app.ui.DropDownDisabled('#contrato', false, false);
            $('#tipoProdClearBtn').addClass('d-none');
            CoverageReload();
        });

        $('input:radio[name=tipo_prod]').change(function () {
            // Exclusividad inversa: al elegir un tipo de producto, "Contrato"
            // y "Sub contrato" dejan de poder elegirse (ver
            // AplicarRestriccionTipoProductoPorContrato más arriba). Solo
            // aplica a cuentas Purdy.
            if (localStorage.getItem('Roles').includes('Purdy')) {
                app.ui.DropDownDisabled('#contrato', true, true);
                app.ui.DropDownDisabled('#subcontrato', true, true);
                $('#tipoProdClearBtn').removeClass('d-none');
            }

            var data = {
                cod_ramo: setupData.cod_ramo,
                edad: app.ui.GetNumericValue('#edad'),
                cod_mon: app.ui.GetDropDownNumericValue('#cod_mon'),
                tipo_prod: $('input:radio[name=tipo_prod]:checked').val(),
                cod_marca: app.ui.GetDropDownNumericValue('#cod_marca'),
                cod_agt: app.Cotizacion.AgentCode()
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
                }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}:edad=${data.edad}:plan=${data.tipo_prod}:cod_marca=${data.cod_marca}:cod_agt=${data.cod_agt}`);

        });

        $('#COD_PLAN_AUTO, #cod_tip_vehi, #cod_uso_vehi').on('change', function () {
            CoverageReload();
        });

        $('#cod_mon').on('change', function () {

            if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
                let cod_mon = app.ui.GetDropDownNumericValue('#cod_mon');
                let cod_agt = app.Cotizacion.AgentCode();
                app.ui.DropDownDisabled('#subcontrato', true, true);
                app.core.Lookups([
                    'MM_POLIZA_GRUPO.contrato'],
                    function () {
                        SettingReload();
                    }, `cod_ramo=${data.cod_ramo}:cod_mon=${cod_mon}:cod_agt=${cod_agt}`);
            } else {
                SettingReload();
            }

        });

        $('#COD_TIP_COM_VEHI').on('change', function () {
            LimpiarCoberturasPorCambioCombustible();
        });

    }

    function MapInputToObject() {
        let data = {
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
            cod_sub_modelo: app.ui.GetDropDownNumericValue('#cod_sub_modelo'),
            cod_sub_modeloDesc: $("#cod_sub_modelo option:selected").text(),
            ANIO_SUB_MODELO: app.ui.GetNumericValue('#ANIO_SUB_MODELO'),
            NUM_MATRICULA: $('#NUM_MATRICULA').val(),
            COD_CHASSIS: $('#COD_CHASSIS').val(),
            NUM_MOTOR: $('#NUM_MOTOR').val(),
            cod_tip_vehi: app.ui.GetDropDownNumericValue('#cod_tip_vehi'),
            cod_tip_vehiDesc: $("#cod_tip_vehi option:selected").text(),
            cod_uso_vehi: app.ui.GetDropDownNumericValue('#cod_uso_vehi'),
            cod_uso_vehiDesc: $("#cod_uso_vehi option:selected").text(),
            COD_TIP_COM_VEHI: $("#COD_TIP_COM_VEHI option:selected").val(),
            COD_TIP_COM_VEHI_DESC: $("#COD_TIP_COM_VEHI option:selected").text(),
            MCA_CERO_KM: app.ui.GetRadioNumericValue('MCA_CERO_KM'),
            MCA_AUTO_GPS: app.ui.GetRadioNumericValue('MCA_AUTO_GPS'),
            MCA_AUTO_GPS_CMS: app.ui.GetRadioNumericValue('MCA_AUTO_GPS_CMS'),
            ext_garantia: app.ui.GetRadioNumericValue('ext_garantia'),
            rc_alcohol: app.ui.GetRadioStringValue('rc_alcohol'),
            rc_conductor: app.ui.GetRadioStringValue('rc_conductor'),
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
            AutoSust: app.ui.GetDropDownNumericValue('#AutoSust'),
            DedudAutoSust: app.ui.GetDropDownNumericValue('#DedudAutoSust'),
            coberturas: $('#coberturasTbl').bootstrapTable('getData'),
            plandepago: $('#plandepagoTbl').bootstrapTable('getData'),
            plandepagoFull: $('#plandepagoFullTbl').bootstrapTable('getData'),
            contrato: app.ui.GetDropDownNumericValue('#contrato'),
            contratoDesc: $("#contrato option:selected").text(),
            subcontrato: app.ui.GetDropDownNumericValue('#subcontrato'),
            polizagrupo: setupData.polizagrupo,
            mc_cuotas_gratis: app.ui.GetRadioStringValue('mc_cuotas_gratis'),
            //num_cuotas_gratis: app.ui.GetDropDownNumericValue('#num_cuotas_gratis')
            num_cuotas_gratis: app.ui.GetDropDownNumericValue('#num_cuotas_gratis'),
            cod_agt: app.Cotizacion.AgentCode(),
            cod_cuadro_com: app.Cotizacion.CuadroCom()

        };
        data.NUM_MATRICULA = data.NUM_MATRICULA.replace(/[^a-zA-Z0-9]/g, "");
        return data;
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
        if ($('#COD_PLAN_AUTO option').length == 1) {
            data.COD_PLAN_AUTO = $("#COD_PLAN_AUTO option:first").val();
        }
        $('#COD_PLAN_AUTO').val(data.COD_PLAN_AUTO);
        app.ui.SetNumericValue('#ANIO_SUB_MODELO', data.ANIO_SUB_MODELO);
        app.ui.SetRadioNumericValue('MCA_CERO_KM', data.MCA_CERO_KM);
        app.ui.SetRadioNumericValue('MCA_AUTO_GPS', data.MCA_AUTO_GPS);
        app.ui.SetRadioNumericValue('MCA_AUTO_GPS_CMS', data.MCA_AUTO_GPS_CMS);
        app.ui.SetRadioNumericValue('MCA_MONITOREO_GPS', data.MCA_MONITOREO_GPS);
        app.ui.SetRadioNumericValue('ext_garantia', data.ext_garantia);
        app.ui.SetRadioStringValue('rc_alcohol', data.rc_alcohol);
        app.ui.SetRadioStringValue('rc_conductor', data.rc_conductor);
        app.ui.SetRadioNumericValue('MCA_PRA', data.MCA_PRA);
        app.ui.SetRadioNumericValue('MCA_VR', data.MCA_VR);
        app.ui.SetNumericValue('#IMP_VR', data.IMP_VR);
        app.ui.SetRadioNumericValue('MCA_DESC_CLIENTE_NUEVO', data.MCA_DESC_CLIENTE_NUEVO);
        app.ui.SetNumericValue('#PCT_AJUSTE_GEN', data.PCT_AJUSTE_GEN);
        app.ui.SetRadioStringValue('mc_cuotas_gratis', data.mc_cuotas_gratis);
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

        var roles = localStorage.getItem('Roles');
        $('#fec_efec_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            minDate: (roles.includes('Purdy')
                ? moment().subtract(15, 'days').startOf('day')
                : moment().startOf('day'))
        });

        $('#fec_vcto_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });

        $('#fec_vcto_poliza_group').prop('disabled', true);

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
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        const tienePrivilegios = localStorage.getItem('Roles')?.includes('Privilegios');
        const opcionesAutoNumeric = {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            decimalPlaces: '0',
            emptyInputBehavior: 'null',
            maximumValue: '0'
        };
        // Solo aplicar límites si NO tiene privilegios
        if (!tienePrivilegios) {
            opcionesAutoNumeric.minimumValue = '-15';
        }
        new AutoNumeric('#PCT_AJUSTE_GEN', opcionesAutoNumeric);

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
                app.ui.SetDateValue('#fec_vcto_poliza', fec_vcto_poliza_grupo);
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
            $('#plandepagoRowFull').addClass('d-none');
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

        $('#VehicleModelHelper').click(function () {
            if (modelHelper.length === 0) {
                let cod_agt = app.Cotizacion.AgentCode();
                app.core.Get(app.setting.apipath + 'v1/datasource/VehicleModelHelper?cod_agt' + cod_agt)
                    .done(function (data) {
                        modelHelper = data;
                        let source = [];
                        data.forEach(function (value, index, array) {
                            source.push({ "name": value.TITULO, "code": value });
                        });
                        $('#cod_marcaHelper').typeahead({
                            highlight: true,
                            source: source,
                            afterSelect: function (item) {
                                console.log(item);
                                $('#cod_marca').val(item.code.COD_MARCA);
                                app.core.LookupDependency(item.code.COD_MARCA, 'cod_modelo', 'MM_ModelosVehiculos', '', item.code.COD_MODELO, false, function () {
                                    if (localStorage.getItem('Roles').includes('Purdy')) {
                                        let data = {
                                            cod_marca: app.ui.GetDropDownNumericValue('#cod_marca'),
                                            cod_modelo: app.ui.GetDropDownNumericValue('#cod_modelo'),
                                            contrato: app.ui.GetDropDownNumericValue('#contrato'),
                                            subcontrato: app.ui.GetDropDownNumericValue('#subcontrato'),
                                            polizagrupo: setupData.polizagrupo,
                                            p_fec_validez: moment().format('YYYYMMDD'),
                                            cod_agt: app.Cotizacion.AgentCode()
                                        }
                                        app.core.Lookups(['MM_SubModelosVehiculos.cod_sub_modelo'], function () {
                                            $('#cod_sub_modelo').val(item.code.COD_SUB_MODELO);
                                        }, `cod_marca=${data.cod_marca}:cod_modelo=${data.cod_modelo}:p_fec_validez=${data.p_fec_validez}:polizagrupo=${data.polizagrupo}:contrato=${data.contrato}:cod_agt=${data.cod_agt}`, 'v1/TronCommon/Lkps');
                                    }
                                }, `cod_marca=`, 'v1/TronCommon/LkpChild');
                                $('.handler-marcaHelper').addClass('d-none');
                                $('.handler-marca').removeClass('d-none');
                            }
                        });
                        $('.handler-marcaHelper').removeClass('d-none');
                        $('.handler-marca').addClass('d-none');

                    })
            } else {
                $('.handler-marcaHelper').removeClass('d-none');
                $('.handler-marca').addClass('d-none');
            }
            event.preventDefault();
        });
        $('#VehicleModelHelperCancel').click(function () {
            $('.handler-marcaHelper').addClass('d-none');
            $('.handler-marca').removeClass('d-none');
            event.preventDefault();
        });

        //const radioSi = document.getElementById("mc_cuotas_gratis_1");
        //const radioNo = document.getElementById("mc_cuotas_gratis_2");
        //radioSi.addEventListener("change", function () {
        //    if (this.checked) {
        //        app.ui.DropDownDisabled('#num_cuotas_gratis', false);
        //    }
        //});
        //radioNo.addEventListener("change", function () {
        //    if (this.checked) {
        //        $('#num_cuotas_gratis').val(0);
        //        app.ui.DropDownDisabled('#num_cuotas_gratis', true);
        //    }
        //});

        const radioSi = document.getElementById("mc_cuotas_gratis_1");
        const radioNo = document.getElementById("mc_cuotas_gratis_2");
        radioSi.addEventListener("change", function () {
            if (this.checked) {
                $('#num_cuotas_gratis').prop('disabled', false);
            }
        });
        radioNo.addEventListener("change", function () {
            if (this.checked) {
                $('#num_cuotas_gratis').val(0);
                $('#num_cuotas_gratis').prop('disabled', true);
            }
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
                if (localStorage.getItem('Roles').includes('Privilegios') || localStorage.getItem('Roles').includes('Purdy') || localStorage.getItem('Roles').includes('Comercial_Mapfre'))
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
                let nvalue = Number(value);
                if (nvalue === 0) {
                    return true;
                }
                else {
                    let yearVeh = app.ui.GetNumericValue('#ANIO_SUB_MODELO');
                    let year = new Date().getFullYear();
                    let minYear = year - 5;
                    if ((yearVeh >= minYear && nvalue < -4) && !(localStorage.getItem('Roles').includes('Privilegios'))) {
                        $('#PCT_AJUSTE_GEN').rules('add', { messages: { AjustePorAnoFabricacion: 'Si el vehículo esta entre 0-5 años de antigüedad, el porcentaje de ajuste comercial no debe exceder el 4%' } });
                        return false;
                    }
                    else {
                        return true;
                    }
                }
            }
        );


        $.validator.addMethod("ValidarAjusteConRol", function (value, element) {
            const tienePrivilegios = localStorage.getItem('Roles')?.includes('Privilegios');
            if (tienePrivilegios) return true; // No validar si tiene el rol

            const num = parseFloat(value);
            return !isNaN(num) && num >= -15 && num <= 0;
        }, "El porcentaje de ajuste comercial debe estar entre el 0 y el -15 %");


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
                PCT_AJUSTE_GEN: { AjustePorAnoFabricacion: true, ValidarAjusteConRol: true },
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
                AutoSust: { required: true },
                DedudAutoSust: { required: true },
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
                PCT_AJUSTE_GEN: { ValidarAjusteConRol: 'El porcentaje de ajuste comercial debe estar entre el 0 y el -15 %, salvo que tenga privilegios', AjustePorAnoFabricacion: '' },
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

                AutoSust: { required: 'Debe indicar el auto sustituto' },
                DedudAutoSust: { required: 'Debe indicar el deducible para el auto sustituto' },
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

        $('#coberturasTbl').on('check.bs.table', function (e, row) {
            if (!validarCoberturaSeleccionable(row)) {
                $('#coberturasTbl').bootstrapTable('uncheckBy', {
                    field: 'codigo',
                    values: [row.codigo]
                });
                return;
            }
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

    function plandepagoFull_table_setup() {

        $('#plandepagoFullTbl').bootstrapTable({
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
        if (tipo_prod === 'trebolbc' || tipo_prod === 'trebolpr') {
            // Ramo 302 MAPFRE Más: para Trébol Basic y Trébol Premium no se permite ajuste comercial
            app.ui.SetNumericValue('#PCT_AJUSTE_GEN', 0);
            $('#PCT_AJUSTE_GEN').prop('disabled', true);
            $('#PCT_AJUSTE_GEN').closest('.col-sm-3.col-md-3').addClass('d-none');
        }
        else if (
            (tipo_prod === 'basico' || tipo_prod === 'amplio' || tipo_prod === 'plus') &&
            (cod_marca === 31 ||
                cod_marca === 74 ||
                cod_marca === 73 ||
                cod_marca === 55 ||
                cod_marca === 40 ||
                cod_marca === 50 ||
                cod_marca === 13 ||
                cod_marca === 30)
        ) {
            $('#PCT_AJUSTE_GEN').closest('.col-sm-3.col-md-3').removeClass('d-none');

            if (!localStorage.getItem('Roles').includes('Privilegios')) {
                app.ui.SetNumericValue('#PCT_AJUSTE_GEN', 0);
                $('#PCT_AJUSTE_GEN').prop('disabled', true);
            }
        }
        else {
            $('#PCT_AJUSTE_GEN').closest('.col-sm-3.col-md-3').removeClass('d-none');
            $('#PCT_AJUSTE_GEN').prop('disabled', false);
        }

        //if (cod_tip_vehi === 2 && (cod_plan_auto === 31 && cod_plan_auto === 32 && cod_plan_auto == 33)) {
        //    //La cobertura Gastos Médicos no se toma en cuenta para el auto de uso Comercial
        //    //La cobertura Accidentes no se toma en cuenta para el auto de uso Comercial
        //    app.ui.DropDownDisabled('#IMP_AUTO_GMO', true);
        //    app.ui.DropDownDisabled('#IMP_AUTO_ACO', true);
        //}
        //else {
        //    //La cobertura Gastos Médicos no se toma en cuenta para el plan Básico
        //    //La cobertura Accidentes no se toma en cuenta para el plan Básico
        //    app.ui.DropDownDisabled('#IMP_AUTO_GMO', cod_plan_auto === 31);
        //    app.ui.DropDownDisabled('#IMP_AUTO_ACO', cod_plan_auto === 31);
        //}

        app.ui.DropDownDisabled('#IMP_AUTO_GMO', !app.Cotizacion.Coberturas_Seleccionada(coberturas, 3002), true);
        app.ui.DropDownDisabled('#IMP_AUTO_ACO', !app.Cotizacion.Coberturas_Seleccionada(coberturas, 3003), true);

        if (showCalculate) {
            $('#plandepagoRow').addClass('d-none');
            $('#plandepagoRowFull').addClass('d-none');

            $('#plandepagoFullRow').addClass('d-none');

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

    function SettingParameter() {
        return {
            cod_ramo: setupData.cod_ramo,
            edad: app.ui.GetNumericValue('#edad'),
            cod_mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            tipo_prod: $('input:radio[name=tipo_prod]:checked').val(),
            cod_marca: app.ui.GetDropDownNumericValue('#cod_marca'),

            cod_modelo: app.ui.GetDropDownNumericValue('#cod_modelo'),
            cod_sub_modelo: app.ui.GetDropDownNumericValue('#cod_sub_modelo'),
            anio_sub_modelo: app.ui.GetNumericValue('#ANIO_SUB_MODELO'),
            cod_tip_vehi: app.ui.GetDropDownNumericValue('#cod_tip_vehi'),
            cod_uso_vehi: app.ui.GetDropDownNumericValue('#cod_uso_vehi'),
            mca_sexo: app.ui.GetDropDownNumericValue('#mca_sexo'),
            cod_zona_circul: app.ui.GetDropDownNumericValue('#cod_zona_circul'),
            cod_plan_auto: app.ui.GetDropDownNumericValue('#COD_PLAN_AUTO'),

            num_contrato: app.ui.GetDropDownNumericValue('#contrato'),
            num_subcontrato: app.ui.GetDropDownNumericValue('#subcontrato'),
            num_poliza_grupo: setupData.polizagrupo == null ? '' : setupData.polizagrupo,
            cod_agt: app.Cotizacion.AgentCode()
        };
    }

    function SettingReload(callback) {
        var param = SettingParameter();
        var mySeq = ++settingReloadSeq;

        app.core.Get(app.setting.apipath + `v1/Quote/MapfreMasSettings?cod_ramo=${param.cod_ramo}&cod_mon=${param.cod_mon}&cod_marca=${param.cod_marca}&cod_modelo=${param.cod_modelo}&cod_sub_modelo=${param.cod_sub_modelo}&anio_sub_modelo=${param.anio_sub_modelo}&cod_tip_vehi=${param.cod_tip_vehi}&cod_uso_vehi=${param.cod_uso_vehi}&mca_sexo=${param.mca_sexo}&cod_zona_circul=${param.cod_zona_circul}&edad=${param.edad}&cod_plan_auto=${param.cod_plan_auto}&num_contrato=${param.num_contrato}&num_subcontrato=${param.num_subcontrato}&num_poliza_grupo=${param.num_poliza_grupo}&tipo_prod=${param.tipo_prod}&cod_agt=${param.cod_agt}`)
            .done(function (settingData) {
                // Llegó una respuesta vieja: ya se pidió un SettingReload más
                // reciente (p.ej. el usuario cambió de contrato o de tipo de
                // producto mientras esta petición seguía en camino). Se
                // descarta para no pintar datos de una selección anterior.
                if (mySeq !== settingReloadSeq) {
                    return;
                }

                fec_vcto_poliza_grupo = settingData.fec_vcto_poliza_grupo;
                app.ui.SetDateValue('#fec_vcto_poliza', app.ui.GetDateValue('#fec_efec_poliza'));
                if (fec_vcto_poliza_grupo == null) {
                    settingData.fec_vcto_poliza = app.ui.GetDateRawValue('#fec_efec_poliza');
                    settingData.fec_vcto_poliza.setFullYear(settingData.fec_vcto_poliza.getFullYear() + 1);
                }
                app.ui.SetDateValue('#fec_vcto_poliza', settingData.fec_vcto_poliza);

                app.ui.LookupLoad('cod_marca', settingData.cod_marca, false);

                app.ui.LookupLoad('cod_tip_vehi', settingData.cod_tip_vehi, true);
                app.ui.LookupLoad('COD_TIP_COM_VEHI', settingData.COD_TIP_COM_VEHI, true);
                app.ui.LookupLoad('COD_PLAN_AUTO', settingData.PLAN_AUTO, true);
                app.ui.LookupLoad('IMP_AUTO_RC', settingData.IMP_AUTO_RC, true);
                app.ui.DropDownDisabled('#IMP_AUTO_RC', settingData.IMP_AUTO_RC.length == 0);
                app.ui.LookupLoad('DED_AUTO_RC', settingData.DED_AUTO_RC, true);

                app.ui.LookupLoad('IMP_AUTO_GMO', settingData.IMP_AUTO_GMO, true);
                app.ui.LookupLoad('IMP_AUTO_ACO', settingData.IMP_AUTO_ACO, true);
                app.ui.LookupLoad('IMP_AUTO_NEUM', settingData.IMP_AUTO_NEUM, true);
                app.ui.LookupLoad('IMP_AUTO_MECA', settingData.IMP_AUTO_MECA, true);
                app.ui.LookupLoad('IMP_AUTO_CRI', settingData.IMP_AUTO_CRI, true);

                app.ui.LookupLoad('DED_AUTO_CRI', settingData.DED_AUTO_CRI, true);

                app.ui.LookupLoad('DED_AUTO_CYV', settingData.DED_AUTO_CYV, true);
                app.ui.LookupLoad('DED_AUTO_RAD', settingData.DED_AUTO_RAD, true);
                app.ui.LookupLoad('DED_AUTO_ROB', settingData.DED_AUTO_ROB, true);
                app.ui.LookupLoad('DED_AUTO_EQESP', settingData.DED_AUTO_EQESP, true);

                if (settingData.cod_fracc_pago > 0) {
                    $('#cod_fracc_pago').val(settingData.cod_fracc_pago);
                    $('#cod_fracc_pago').prop('disabled', true);
                } else {
                    $('#cod_fracc_pago').prop('disabled', false);
                }

                // Si para la combinación actual (tipo de producto/contrato +
                // datos del vehículo) el backend no devuelve ningún "Plan"
                // válido, el campo queda sin opciones y la tabla de
                // coberturas se termina pidiendo con un plan inválido -se ve
                // como "la tabla no cargó", sin ninguna explicación. Esto no
                // es un bug de este archivo: la lista de planes válidos la
                // decide un motor de reglas externo (fuera de este código).
                // Se avisa en vez de dejarlo en silencio.
                if (settingData.PLAN_AUTO != null && settingData.PLAN_AUTO.length === 0) {
                    toastr.warning(
                        'No hay ningún plan disponible para la combinación de tipo de producto/contrato y datos del vehículo seleccionados. Revise esos datos.',
                        '',
                        { closeButton: true, progressBar: true });
                }

                if (callback !== undefined && callback !== null) {
                    callback();
                }
                CoverageReload();
                app.Cotizacion.DefaultSettings('MapfreMas');
            });

    }


    function CoverageReload() {
        //  int mca_sexo, int cod_zona_circul, int edad, int cod_plan_auto
        var param = SettingParameter();
        var mySeq = ++coverageReloadSeq;
        $('#coberturasTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + `v1/Quote/MapfreMasCoverages?cod_ramo=${param.cod_ramo}&cod_mon=${param.cod_mon}&cod_marca=${param.cod_marca}&cod_modelo=${param.cod_modelo}&cod_sub_modelo=${param.cod_sub_modelo}&anio_sub_modelo=${param.anio_sub_modelo}&cod_tip_vehi=${param.cod_tip_vehi}&cod_uso_vehi=${param.cod_uso_vehi}&mca_sexo=${param.mca_sexo}&cod_zona_circul=${param.cod_zona_circul}&edad=${param.edad}&cod_plan_auto=${param.cod_plan_auto}&num_contrato=${param.num_contrato}&num_subcontrato=${param.num_subcontrato}&num_poliza_grupo=${param.num_poliza_grupo}&cod_agt=${param.cod_agt}`)
            .done(function (data) {
                // Descarta respuestas de un CoverageReload anterior que
                // llegaron después de uno más reciente (mismo motivo que en
                // SettingReload).
                if (mySeq !== coverageReloadSeq) {
                    return;
                }
                if (data != null) {
                    $('#coberturasTbl').bootstrapTable('load', data);
                    Coberturas_Fijas(data);
                    Coberturas_ManejoDeCapital();
                }
                else
                    $('#coberturasTbl').bootstrapTable('load', {});
            }).always(function () {
                if (mySeq === coverageReloadSeq) {
                    $('#coberturasTbl').bootstrapTable('hideLoading');
                }
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
            app.ui.SetDropDownNumericValue('#DED_AUTO_CYV', -1);
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
            app.ui.SetDropDownNumericValue('#DED_AUTO_RAD', -1);
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
            app.ui.SetDropDownNumericValue('#DED_AUTO_ROB', -1);
        }
        if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3009)) {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_CRI', false);
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DED_AUTO_CRI', false);
        }
        else {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#IMP_AUTO_CRI', true);
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DED_AUTO_CRI', true);
            app.ui.SetDropDownNumericValue('#IMP_AUTO_CRI', -1);
            app.ui.SetDropDownNumericValue('#DED_AUTO_CRI', -1);
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
            app.ui.SetDropDownNumericValue('#DED_AUTO_EQESP', 0);
        }
        if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3017)) {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DedudAutoSust', false);
        }
        else {
            app.Cotizacion.Coberturas_ComportamientoDependencia('#DedudAutoSust', true);
            app.ui.SetDropDownNumericValue('#DedudAutoSust', 0);
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

    function validarCoberturaSeleccionable(row) {
        const tipoCombustible = $("#COD_TIP_COM_VEHI option:selected").val();
        var roles = localStorage.getItem('Roles'); 

        if (roles.includes('Veinsa')) {
            // Eléctrico
            if (tipoCombustible == "2" && row.codigo == 3010) {
                toastr.warning('La cobertura 3010 no aplica para vehículos eléctricos.');
                return false;
            }

            // Combustible o Híbrido
            if ((tipoCombustible == "1" || tipoCombustible == "3") && row.codigo == 1060) {
                toastr.warning('La cobertura 1060 solo aplica para vehículos eléctricos.');
                return false;
            }
        }
            return true;
        
    }

    function LimpiarCoberturasPorCambioCombustible() {
        var roles = localStorage.getItem('Roles');

        if (roles.includes('Veinsa')) {
            $('#coberturasTbl').bootstrapTable('uncheckBy', {
                field: 'codigo',
                values: [3010]
            });

            $('#coberturasTbl').bootstrapTable('uncheckBy', {
                field: 'codigo',
                values: [1060]
            });

            Coberturas_ManejoDeCapital();
        }
    }


    function initializeDateTimePicker() {
        var contratoValue = app.ui.GetDropDownNumericValue('#contrato');
        var roles = localStorage.getItem('Roles');

        if (contratoValue !== null && contratoValue !== undefined) {
            var minDate;

            if (contratoValue === 10006 || contratoValue === 14002) {
                minDate = moment().subtract(6, 'months').startOf('day'); // Retroceso de 6 meses
            }
            else if (roles.includes('Purdy')) {
                minDate = moment().subtract(15, 'days').startOf('day'); // Retroceso de 15 días
            }
            else {
                minDate = moment().startOf('day');
            }

            $('#fec_efec_poliza_group').datetimepicker('destroy');
            $('#fec_efec_poliza_group').datetimepicker({
                format: 'DD/MM/YYYY',
                locale: 'es',
                minDate: minDate
            });
        }
    }

    return {
        Data: function () {
            return MapInputToObject();
        },
        Init: function () {
            let mode = app.core.URLStringValue('modo');
            if (mode === 'plus') {
                window.history.replaceState({}, null, location.pathname + 'Plus');
            }

            Controls_setup();
            Setup_Validations();
            coberturas_table_setup();
            plandepago_table_setup();
            plandepagoFull_table_setup();
            plandepagoporfrecuencia_table_setup();

            Controls_Events();
            if (app.language && app.language.translate) {
                app.language.translate('#quoteBlock', '_resumen')();
                app.language.translate('#DatosGeneralesTitle', '_datosgenerales')();
                app.language.translate('#coberturasTbl', '_coberturaPlan')();
                app.language.translate('#polizagrupoZone', '_polizagrupo')();
            }
            app.language.translate('body', 'MapfreMas')();
            Setup(mode);
        }
    };
})();


