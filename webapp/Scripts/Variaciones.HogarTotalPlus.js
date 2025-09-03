var app = app || {};

app.VariacionHogarTotalPlus = (function () {

    let mainHolder = null;
    let fec_vcto_poliza_grupo = null;
    let formularioRow = null;
    var workMode = '';
    var setupData = null;
    var showCalculate = false;
    var rowDocumentosrequeridos = null;
    let mca_cuotas_gratis = 'N';

    var setupDataFirst = null;
    var COD_PLAN_AUTO = 0;
    var MCA_PROVISIONAL = 'N';
    var NUM_SPTO = 0;
    var NEW_NUM_SPTO = 0;
    var fileAuthorization = [];
    var fileCancelation = [];

    // Instancias de componentes
    let coberturasComponent;
    let sumasAseguradasComponent;
    let tercerosDisplayComponent;
    let planPagoResumenComponent;

    function Setup() {
        app.ui.CommonBehaviour();
        var _id = app.core.URLStringValue('poliza');
        NUM_SPTO = app.core.URLStringValue('spto');
        MCA_PROVISIONAL = app.core.URLStringValue('mca_provisional');

        if (_id != '') {
            $('#coberturasTbl').bootstrapTable('showLoading');
            app.core.Get(app.setting.apipath + 'v1/Variaciones/MapfreMasSetup/' + _id + '/' + NUM_SPTO + '/' + MCA_PROVISIONAL)
                .done(function (data, textStatus, jqXHR) {
                    if (localStorage.getItem('Roles').includes('Purdy')) {
                        $('.Purdy').removeClass('d-none');
                    }

                    $('.documentosrequeridosGrid').addClass('d-none');
                    $('#resultvariacion').addClass('d-none');

                    setupUIForVariation();
                    COD_PLAN_AUTO = data.COD_PLAN_AUTO;
                    $('#hhd-codplanauto').val(COD_PLAN_AUTO);

                    configureButtonsBasedOnMode();
                    Init_Lookups(data);
                });
        }
    }

    function setupUIForVariation() {
        $('#PageSubTitle').text("Emision de Variación y/o Cancelación");
        $('.datosgeneralesZone').removeClass('col-md-12').addClass('col-md-10');
        $('.enviosolicitudZone').removeClass('d-none');
    }

    function configureButtonsBasedOnMode() {
        if (MCA_PROVISIONAL == "S") {
            $('#authorizarct, #rechazarct').removeClass('d-none').appendTo("#GenericToolBar");
            if (Array.isArray(setupData?.Recibos) && setupData.Recibos.length > 0) {
                $('#resultvariacionTbl').bootstrapTable('load', setupData.Recibos);
                $('#resultvariacion').removeClass('d-none');
            }
        } else {
            $('#generarvariacion, #cancelarpoliza').removeClass('d-none').appendTo("#GenericToolBar");
        }
    }

    function Init_Lookups(data) {
        setupData = JSON.parse(JSON.stringify(data));
        let lookupList = [
            'MM_Sexo.mca_sexo',
            'MonedasPorRamo.cod_mon',
            'FrecuenciaDePagoPorRamo.cod_fracc_pago',
            'MM_MCA_TIP_FIRMA.tip_firma',
            'MM_MarcasVehiculos.cod_marca',
            'MM_ModelosVehiculos.cod_modelo',
            'MM_ClaseVehiculos.cod_tip_vehi',
            'UsoVehiculo.cod_uso_vehi',
            'MM_COD_COLOR.COD_COLOR',
            'MM_DEDU_AUTOSUS.DedudAutoSust',
            'Paises.cod_pais',
            'Provincias.TProvincia'
        ];

        if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
            lookupList.push('MM_POLIZA_GRUPO.contrato', 'MM_SUB_CONTRATOS.subcontrato');
        }

        app.core.Lookups(lookupList, function () {
            MapObjectToInput_First(data);

            // PRIMERO inicializar los componentes
            initializeComponents(data);

            // DESPUÉS cargar configuraciones y datos
            SettingReload(function () {
                MapObjectToInput(data);
                data_changed();
            });
        }, `cod_ramo=${data.cod_ramo}:cod_pais=CRI:cod_mon=${data.cod_mon}:edad=${data.edad}:plan=${data.tipo_prod}:cod_marca=${data.cod_marca}:num_contrato=${data.contrato}:cod_agt=${data.cod_agt}`);
    }

    function initializeComponents(data) {
        // Inicializar componente de coberturas
        coberturasComponent = app.CoberturasComponent;
        coberturasComponent.init({
            tableId: 'coberturasTbl',
            modalId: 'coberturasNewModal',
            newTableId: 'coberturasNewTbl',
            dataFieldId: 'coberturasData',
            buttonNewId: 'coberturasNew',
            buttonAgregarId: 'agregarCobertura',
            allowAdd: MCA_PROVISIONAL !== "S",
            allowDelete: MCA_PROVISIONAL !== "S",
            onDataChange: function (coberturas) {
                sumasAseguradasComponent.enableControlsByCoverages(coberturas);
                data_changed();
            }
        });

        // Inicializar componente de sumas aseguradas
        sumasAseguradasComponent = app.SumasAseguradasComponent;
        sumasAseguradasComponent.init({
            containerId: 'sumasaseguradas',
            readOnly: MCA_PROVISIONAL === "S",
            productCode: COD_PLAN_AUTO,
            onDataChange: data_changed
        });

        // Inicializar componente de terceros (solo visualización)
        tercerosDisplayComponent = app.TercerosDisplayComponent;
        tercerosDisplayComponent.init({
            tableId: 'tercerosTbl',
            showActions: false
        });

        // Inicializar componente de plan de pago resumen
        planPagoResumenComponent = app.PlanPagoResumenComponent;
        planPagoResumenComponent.init({
            tableId: 'plandepagoresumenTbl',
            containerId: 'plandepagoresumenContainer'
        });

        // Cargar datos en los componentes
        loadDataIntoComponents(data);
    }

    function loadDataIntoComponents(data) {
        // Cargar coberturas
        if (data.coberturas) {
            coberturasComponent.loadData(data.coberturas);
        }
        if (data.AvailableCoverages) {
            coberturasComponent.loadAvailableCoverages(data.AvailableCoverages);
        }

        // Configurar sumas aseguradas
        sumasAseguradasComponent.setSetupData(data);
        sumasAseguradasComponent.setProductCode(COD_PLAN_AUTO);
        sumasAseguradasComponent.enableControlsByCoverages(data.coberturas);

        // Cargar terceros
        if (data.terceros) {
            tercerosDisplayComponent.loadData(data.terceros);
        }

        // Cargar plan de pago resumen
        if (data.plandepagoresumen) {
            planPagoResumenComponent.loadData(data.plandepagoresumen);
        }
    }

    function SettingReload(callback) {
        let param = setupData;
        param.cod_mon = app.ui.GetDropDownNumericValue('#cod_mon');
        param.tipo_prod = $('input:radio[name=tipo_prod]:checked').val();
        param.cod_marca = app.ui.GetDropDownNumericValue('#cod_marca');

        app.core.Get(app.setting.apipath + `v1/Variaciones/MapfreMasSettings?cod_ramo=${param.cod_ramo}&cod_mon=${param.cod_mon}&cod_marca=${param.cod_marca}&cod_modelo=${param.cod_modelo}&cod_sub_modelo=${param.cod_sub_modelo}&anio_sub_modelo=${param.ANIO_SUB_MODELO}&cod_tip_vehi=${param.cod_tip_vehi}&cod_uso_vehi=${param.cod_uso_vehi}&mca_sexo=${param.mca_sexo}&cod_zona_circul=${param.cod_zona_circul}&edad=${param.edad}&cod_plan_auto=${param.COD_PLAN_AUTO}&num_contrato=${param.contrato}&num_subcontrato=${param.subcontrato}&num_poliza_grupo=${param.polizagrupo}&tipo_prod=${param.tipo_prod}&cod_agt=${param.cod_agt}`)
            .done(function (settingData) {
                fec_vcto_poliza_grupo = settingData.fec_vcto_poliza_grupo;

                // AHORA los componentes ya están inicializados, así que verificamos si existen
                if (sumasAseguradasComponent) {
                    console.log('✅ Componente de sumas aseguradas encontrado, cargando lookups...');
                    sumasAseguradasComponent.loadLookups(settingData);
                    // Cargar los valores después de que los combos tengan opciones
                    sumasAseguradasComponent.loadData(setupData);
                } else {
                    console.log('❌ Componente de sumas aseguradas no encontrado, usando método original...');
                    // Fallback al método original si el componente no está disponible
                    loadSumasAseguradasOriginal(settingData, setupData);
                }

                if (callback !== undefined && callback !== null) {
                    callback();
                }
                ReadOnly();
            });
    }

    // Método fallback con la lógica original
    function loadSumasAseguradasOriginal(settingData, data) {
        app.ui.LookupLoad('IMP_AUTO_RC', settingData.IMP_AUTO_RC);
        $('#IMP_AUTO_RC').prop('disabled', settingData.IMP_AUTO_RC.length == 0);
        app.ui.LookupLoad('DED_AUTO_RC', settingData.DED_AUTO_RC);

        app.ui.LookupLoad('IMP_AUTO_GMO', settingData.IMP_AUTO_GMO);
        app.ui.LookupLoad('IMP_AUTO_ACO', settingData.IMP_AUTO_ACO);
        app.ui.LookupLoad('IMP_AUTO_NEUM', settingData.IMP_AUTO_NEUM);
        app.ui.LookupLoad('IMP_AUTO_MECA', settingData.IMP_AUTO_MECA);
        app.ui.LookupLoad('IMP_AUTO_CRI', settingData.IMP_AUTO_CRI);

        app.ui.LookupLoad('DED_AUTO_CYV', findOrAddRecordCombobox(settingData.DED_AUTO_CYV, data.DED_AUTO_CYV, data.DED_AUTO_CYV_Desc));
        app.ui.LookupLoad('DED_AUTO_RAD', findOrAddRecordCombobox(settingData.DED_AUTO_RAD, data.DED_AUTO_RAD, data.DED_AUTO_RAD_Desc));
        app.ui.LookupLoad('DED_AUTO_ROB', findOrAddRecordCombobox(settingData.DED_AUTO_ROB, data.DED_AUTO_ROB, data.DED_AUTO_ROB_Desc));
        app.ui.LookupLoad('DED_AUTO_EQESP', settingData.DED_AUTO_EQESP);
        app.ui.LookupLoad('DED_AUTO_CRI', settingData.DED_AUTO_CRI);
    }

    // Función auxiliar
    function findOrAddRecordCombobox(array, code, description) {
        if (!array) return [];
        const record = array.find(item => item.Code == code);
        if (!record) {
            array.push({ Code: code, Description: description });
        }
        return array;
    }

    function MapInputToObject() {
        var data = setupData;
        data.cod_fracc_pago = app.ui.GetDropDownNumericValue('#cod_fracc_pago');
        data.COD_COLOR = app.ui.GetDropDownNumericValue('#COD_COLOR');
        data.COD_COLORDesc = $("#COD_COLOR option:selected").text();
        data.NUM_MATRICULA = $('#NUM_MATRICULA').val();
        data.NUM_MATRICULA = data.NUM_MATRICULA.replace(/[^a-zA-Z0-9]/g, "");
        data.fec_efec = app.ui.GetDateValue('#fec_efec');

        // Obtener datos de sumas aseguradas del componente
        if (sumasAseguradasComponent) {
            const sumasData = sumasAseguradasComponent.getData();
            Object.assign(data, sumasData);
        }

        // Obtener datos de coberturas
        const coberturas = JSON.parse($('#coberturasData').val() || '[]');
        let NewCoverages = [];
        if (Array.isArray(coberturas) && coberturas.length > 0) {
            NewCoverages = coberturas.map(row => ({
                capital: row.capital,
                codigo: row.codigo,
                deducible: row.deducible,
                nombre: row.nombre,
                primatotal: row.primatotal,
                requerida: row.requerida,
                riesgo: row.riesgo,
                seleccionado: row.seleccionado,
                mcaSeleccion: row.mcaSeleccion
            }));
        }
        data.NewCoverages = NewCoverages;

        setupData = data;
        return data;
    }

    function existeCambios() {
        let result = true;
        const camposAComparar = ["cod_fracc_pago", "NUM_MATRICULA", "IMP_AUTO_RC", "IMP_AUTO_GMO", "IMP_AUTO_ACO", "IMP_AUTO_CYV", "IMP_VR", "IMP_AUTO_CRI",
            "IMP_AUTO_RAD", "IMP_AUTO_ROB", "DED_AUTO_RC", "DED_AUTO_ROB", "DED_AUTO_CYV", "DED_AUTO_RAD", "IMP_AUTO_EQESP", "DED_AUTO_EQESP"];

        let data = MapInputToObject();
        const isEquals = sonObjetosIguales(setupDataFirst, data, camposAComparar);
        const lista = data.NewCoverages || [];

        if (lista.length <= 0 && isEquals) {
            result = false;
            toastr.error("Existe un error, debe modificar alguno de los datos", "Error el emitir la variación", { timeOut: 9000, closeButton: true, progressBar: true });
        }

        return result;
    }

    function sonObjetosIguales(obj1, obj2, camposAComparar) {
        for (const campo of camposAComparar) {
            if (!obj1.hasOwnProperty(campo) || !obj2.hasOwnProperty(campo)) {
                return false;
            }
            if (JSON.stringify(obj1[campo]) !== JSON.stringify(obj2[campo])) {
                return false;
            }
        }
        return true;
    }

    function MapObjectToInput_First(data) {
        setupDataFirst = data;
        app.ui.SetNumericValue('#NUM_POLIZA', data.num_poliza);
        $('#NUM_POLIZA').val(data.num_poliza);
        $('#Fuente_Tomador').val(data.Fuente_Tomador);
        $('#cod_mon').val(data.cod_mon);
        $('#cod_fracc_pago').val(data.cod_fracc_pago);
        $('#tip_firma').val(data.tip_firma);

        if (localStorage.getItem('Roles').includes('Purdy')) {
            const data = {
                tip_firma: 'valorSeleccionado',
                opciones: [
                    { valor: 'M', texto: 'FIRMA MANUAL' },
                    { valor: 'F', texto: 'FIRMA ACEPTACION DIGITAL' }
                ]
            };
            $('#tip_firma').html(data.opciones.map(opcion =>
                `<option value="${opcion.valor}">${opcion.texto}</option>`).join('')).val(data.tip_firma);
        }

        $('#Modalidad_Pago').val(data.Modalidad_Pago);
        app.ui.SetDateValue('#fec_efec_poliza', data.fec_efec_poliza);
        $('#fec_vcto_poliza_group').data("DateTimePicker").minDate($('#fec_efec_poliza_group').data("DateTimePicker").date());
        app.ui.SetDateValue('#fec_vcto_poliza', data.fec_vcto_poliza);
        app.ui.SetRadioStringValue('tipo_prod', data.tipo_prod);
        app.ui.DropDownValueWithOption('#COD_PLAN_AUTO', data.COD_PLAN_AUTO, data.COD_PLAN_AUTODesc);
        app.ui.DropDownValueWithOption('#cod_zona_circul', data.cod_zona_circul, data.cod_zona_circulDesc);
        $('#cod_marca').val(data.cod_marca);
        $('#cod_modelo').val(data.cod_modelo);
        $('#cod_sub_modelo').val(data.cod_sub_modelo);
        app.ui.SetNumericValue('#ANIO_SUB_MODELO', data.ANIO_SUB_MODELO);
        $('#cod_tip_vehi').val(data.cod_tip_vehi);
        $('#cod_uso_vehi').val(data.cod_uso_vehi);
        $('#NUM_MATRICULA').val(data.NUM_MATRICULA);
        $('#COD_CHASSIS').val(data.COD_CHASSIS);
        $('#NUM_MOTOR').val(data.NUM_MOTOR);
        $('#DES_TIP_CILINDRAJE').val(data.DES_TIP_CILINDRAJE);
        app.ui.SetNumericValue('#VAL_PESO', data.VAL_PESO);
        $('#COD_COLOR').val(data.COD_COLOR);
        app.ui.SetNumericValue('#VAL_CAPACIDAD', data.VAL_CAPACIDAD);
        app.ui.SetRadioNumericValue('MCA_CERO_KM', data.MCA_CERO_KM);
        app.ui.SetRadioNumericValue('MCA_AUTO_GPS', data.MCA_AUTO_GPS);
        app.ui.SetRadioNumericValue('MCA_AUTO_GPS_CMS', data.MCA_AUTO_GPS_CMS);
        app.ui.SetRadioNumericValue('MCA_MONITOREO_GPS', data.MCA_MONITOREO_GPS);
        app.ui.SetRadioNumericValue('MCA_PRA', data.MCA_PRA);
        app.ui.SetRadioNumericValue('MCA_VR', data.MCA_VR);
        app.ui.SetNumericValue('#IMP_VR', data.IMP_VR);
        app.ui.SetRadioStringValue('Vehiculo_Otra_Poliza', data.Vehiculo_Otra_Poliza);
        app.ui.SetRadioNumericValue('MCA_DESC_CLIENTE_NUEVO', data.MCA_DESC_CLIENTE_NUEVO);
        app.ui.SetNumericValue('#PCT_AJUSTE_GEN', data.PCT_AJUSTE_GEN);
        app.ui.SetRadioNumericValue('ext_garantia', data.ext_garantia);
        app.ui.SetRadioStringValue('MCA_FEC_EFEC_SYS', data.MCA_FEC_EFEC_SYS);

        if (data.documentosrequeridos != null)
            $('#documentosrequeridosTbl').bootstrapTable('load', data.documentosrequeridos);
        else
            $('#documentosrequeridosTbl').bootstrapTable('load', {});

        if (data.plandepago != null)
            $('#plandepagoTbl').bootstrapTable('load', data.plandepago);
        else
            $('#plandepagoTbl').bootstrapTable('load', {});

        TipoTercero_Filtro();
        mca_cuotas_gratis = data.mc_cuotas_gratis;

        $('#coberturasData').val('[]');
    }

    function MapObjectToInput(data) {
        // Cargar datos en el componente de sumas aseguradas
        if (sumasAseguradasComponent) {
            sumasAseguradasComponent.loadData(data);
        }

        if (data.kyc != null) {
            let titular = data.terceros.filter(i => i.tipodetercero == 0);
            let row = {
                formularioId: 1,
                name: 'Conozca a su cliente persona',
                when: new Date(),
                type: 'kycpersona',
                data: data.kyc
            };
            if (titular[0].DocumentNumberType == 4) {
                row.name = 'Conozca a su cliente Jurídico';
                row.type = 'kycjuridico';
            }
            $('#formulariosTbl').bootstrapTable('append', row);
        } else {
            $('#formulariosTbl').bootstrapTable('load', {});
        }
    }

    function ReadOnly() {
        $('input[name=tipo_prod').first().parent().parent().replaceWith('<div>' + $('input:radio[name=tipo_prod]:checked').next().html() + '</div>');
        $('#NUM_POLIZA').replaceWith('<div>' + $('#NUM_POLIZA').val() + '</div>');
        $('#cod_mon').replaceWith('<div>' + $('#cod_mon option:selected').text() + '</div>');
        $('#fec_efec_poliza_group').replaceWith('<div>' + $('#fec_efec_poliza').val() + '</div>');
        $('#fec_vcto_poliza_group').replaceWith('<div>' + $('#fec_vcto_poliza').val() + '</div>');
        $('#COD_PLAN_AUTO').replaceWith('<div>' + $('#COD_PLAN_AUTO option:selected').text() + '</div>');
        $('#cod_zona_circul').replaceWith('<div>' + $('#cod_zona_circul option:selected').text() + '</div>');
        $('#cod_marca').replaceWith('<div>' + $('#cod_marca option:selected').text() + '</div>');
        $('#cod_modelo').replaceWith('<div>' + $('#cod_modelo option:selected').text() + '</div>');
        $('#cod_sub_modelo').replaceWith('<div>' + $('#cod_sub_modelo option:selected').text() + '</div>');
        $('#ANIO_SUB_MODELO').replaceWith('<div>' + $('#ANIO_SUB_MODELO').val() + '</div>');
        $('#cod_tip_vehi').replaceWith('<div>' + $('#cod_tip_vehi option:selected').text() + '</div>');
        $('#cod_uso_vehi').replaceWith('<div>' + $('#cod_uso_vehi option:selected').text() + '</div>');
        $('#COD_CHASSIS').replaceWith('<div>' + $('#COD_CHASSIS').val() + '</div>');
        $('#DES_TIP_CILINDRAJE').replaceWith('<div>' + $('#DES_TIP_CILINDRAJE').val() + '</div>');
        $('#VAL_PESO').replaceWith('<div>' + $('#VAL_PESO').val() + '</div>');
        $('#COD_COLOR').replaceWith('<div>' + $('#COD_COLOR option:selected').text() + '</div>');
        $('#NUM_MOTOR').replaceWith('<div>' + $('#NUM_MOTOR').val() + '</div>');
        $('#VAL_CAPACIDAD').replaceWith('<div>' + $('#VAL_CAPACIDAD').val() + '</div>');
        $('label[for=MCA_CERO_KM').next().replaceWith('<div>' + $('label[for=MCA_CERO_KM_' + app.ui.GetRadioNumericValue('MCA_CERO_KM') + '').html() + '</div>');
        $('label[for=MCA_AUTO_GPS').next().replaceWith('<div>' + $('label[for=MCA_AUTO_GPS_' + app.ui.GetRadioNumericValue('MCA_AUTO_GPS') + '').html() + '</div>');
        $('label[for=MCA_AUTO_GPS_CMS').next().replaceWith('<div>' + $('label[for=MCA_AUTO_GPS_CMS_' + app.ui.GetRadioNumericValue('MCA_AUTO_GPS_CMS') + '').html() + '</div>');
        $('label[for=MCA_MONITOREO_GPS').next().replaceWith('<div>' + $('label[for=MCA_MONITOREO_GPS_' + app.ui.GetRadioNumericValue('MCA_MONITOREO_GPS') + '').html() + '</div>');
        $('label[for=MCA_PRA').next().replaceWith('<div>' + $('label[for=MCA_PRA_' + app.ui.GetRadioNumericValue('MCA_PRA') + '').html() + '</div>');
        $('label[for=MCA_VR').next().replaceWith('<div>' + $('label[for=MCA_VR_' + app.ui.GetRadioNumericValue('MCA_VR') + '').html() + '</div>');
        $('label[for=MCA_DESC_CLIENTE_NUEVO').next().replaceWith('<div>' + $('label[for=MCA_DESC_CLIENTE_NUEVO_' + app.ui.GetRadioNumericValue('MCA_DESC_CLIENTE_NUEVO') + '').html() + '</div>');
        $('label[for=ext_garantia').next().replaceWith('<div>' + $('label[for=ext_garantia_' + app.ui.GetRadioNumericValue('ext_garantia') + '').html() + '</div>');
        $('#PCT_AJUSTE_GEN').parent().replaceWith('<div>' + $('#PCT_AJUSTE_GEN').val() + ' %</div>');
        $('#IMP_AUTO_NEUM').replaceWith('<div>' + $('#IMP_AUTO_NEUM option:selected').text() + '</div>');
        $('#IMP_AUTO_MECA').replaceWith('<div>' + $('#IMP_AUTO_MECA option:selected').text() + '</div>');
        $('#DedudAutoSust').replaceWith('<div>' + $('#DedudAutoSust option:selected').text() + '</div>');

        if (MCA_PROVISIONAL === "S") {
            DisabledAllControls(true);
        }
    }

    function ReadOnly_End() {
        $('#fec_efec_poliza_group').replaceWith('<div>' + $('#fec_efec_poliza').val() + '</div>');
        $('#fec_vcto_poliza_group').replaceWith('<div>' + $('#fec_vcto_poliza').val() + '</div>');
        $('#NUM_MATRICULA').replaceWith('<div>' + $('#NUM_MATRICULA').val() + '</div>');
        $('#COD_CHASSIS').replaceWith('<div>' + $('#COD_CHASSIS').val() + '</div>');
        $('#NUM_MOTOR').replaceWith('<div>' + $('#NUM_MOTOR').val() + '</div>');
        $('#DES_TIP_CILINDRAJE').replaceWith('<div>' + $('#DES_TIP_CILINDRAJE').val() + '</div>');
        $('#VAL_PESO').parent().replaceWith('<div>' + $('#VAL_PESO').val() + ' Kg</div>');
        $('#COD_COLOR').replaceWith('<div>' + $('#COD_COLOR option:selected').text() + '</div>');
        $('#VAL_CAPACIDAD').replaceWith('<div>' + $('#VAL_CAPACIDAD').val() + '</div>');
        $('label[for=Vehiculo_Otra_Poliza').next().replaceWith('<div>' + $('label[for=Vehiculo_Otra_Poliza_' + app.ui.GetRadioStringValue('Vehiculo_Otra_Poliza') + '').html() + '</div>');

        $('#documentosrequeridosNew').addClass('d-none');
        $('#documentosrequeridosTbl').bootstrapTable('hideColumn', 'Actions');
        $('#formulariosNew').addClass('d-none');
        $('#formulariosTbl').bootstrapTable('hideColumn', 'Actions');
    }

    function DisabledAllControls(isdisabled) {
        $('#cod_fracc_pago').prop('disabled', isdisabled);
        $('#NUM_MATRICULA').prop('disabled', isdisabled);
        $('#COD_COLOR').prop('disabled', isdisabled);

        // Configurar componentes según el estado
        if (coberturasComponent) {
            coberturasComponent.setReadOnly(isdisabled);
        }
        if (sumasAseguradasComponent) {
            sumasAseguradasComponent.setReadOnly(isdisabled);
        }

        $('#plandepagoTbl').find('input, button').prop('disabled', isdisabled);
    }

    function TipoTercero_Filtro() {
        let terceros = $('#tercerosTbl').bootstrapTable('getData');
        let holder = terceros.filter(i => i.tipodetercero === 0);
        let insured = terceros.filter(i => i.tipodetercero === 2);
        let driver = terceros.filter(i => i.tipodetercero === 3);
        if (holder.length > 0) {
            $('#tipodetercero option[value="0"]').attr('disabled', 'disabled');
        }
        if (insured.length > 0) {
            $('#tipodetercero option[value="2"]').attr('disabled', 'disabled');
        }
        if (driver.length > 0) {
            $('#tipodetercero option[value="3"]').attr('enabled', 'enabled');
        }
        formularios_handler();
    }

    function Controls_setup() {
        $('#fec_efec_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fec_vcto_poliza_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });

        // Configurar controles numéricos básicos
        new AutoNumeric('#ANIO_SUB_MODELO', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '',
            maximumValue: '9999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });

        new AutoNumeric('#VAL_PESO', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '9999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });

        new AutoNumeric('#VAL_CAPACIDAD', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '9999999999',
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

        new AutoNumeric('#PCT_AJUSTE_GEN', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '0',
            minimumValue: '-99',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });

        $('#fec_efec_cancel_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            minDate: moment().startOf('day')
        });

        $('#fec_efec_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            minDate: moment().startOf('day')
        });
    }

    function Controls_Events() {
        $("#VisualizationsEdtForm :input").change(function () {
            data_changed();
        });

        $('#IMP_VR').change(function () {
            var value = app.ui.GetNumericValue('#IMP_VR');
            app.ui.SetNumericValue('#IMP_AUTO_CYV', value);
            app.ui.SetNumericValue('#IMP_AUTO_RAD', value);
            app.ui.SetNumericValue('#IMP_AUTO_ROB', value);
            data_changed();
            $("#VisualizationsEdtForm").validate().resetForm();
        });

        $('#generarvariacion').click(function () {
            if (!existeCambios()) {
                return;
            }

            result = true;
            var fec_efec = app.ui.GetDateValue('#fec_efec');
            const date = new Date(fec_efec);
            const timestamp = date.getTime();

            if (isNaN(timestamp) || timestamp < 0) {
                toastr.error('Debe registrar la fecha de efecto', "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
                result = false;
                return result;
            }

            if (setupDataFirst.cod_fracc_pago !== app.ui.GetDropDownNumericValue('#cod_fracc_pago')) {
                var md = $('#confirmation-autorization-Modal').modal({ show: false });
                md.modal('show');
                $('#mensaje_fracc_pago').removeClass('d-none');
                $('#fileTableAutorization').addClass('d-none');
                $('#fileTableBodyAuthorization').empty();
                $('#doc_autorization_poliza').next('.custom-file-label').text('Indique el archivo a procesar...');
                fileAuthorization = [];
            } else {
                generateVariation();
            }
            event.preventDefault();
        });

        // Resto de eventos...
        setupFileHandlers();
        setupAuthorizationEvents();
        setupCancelationEvents();
    }

    function generateVariation() {
        app.ui.ButtonDoing('#generarvariacion');
        app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMas',
            JSON.stringify(MapInputToObject()),
            function (data) {
                if (data.McaError === "N") {
                    handleSuccessfulVariation(data);
                } else {
                    custonMessageResponse(data, "Error el emitir la variación");
                }
            }).always(function () {
                app.ui.ButtonDone('#generarvariacion');
            });
    }

    function handleSuccessfulVariation(data) {
        if (Array.isArray(data.Recibos) && data.Recibos.length > 0) {
            $('#resultvariacionTbl').bootstrapTable('load', data.Recibos);
            $('#resultvariacion').removeClass('d-none');
            let firstRecord = data.Recibos[0];
            NEW_NUM_SPTO = firstRecord.num_spto;
        }

        if (data.plandepago != null) {
            $('#plandepagoTbl').bootstrapTable('load', data.plandepago);
        }

        if (data.plandepagoresumen != null && planPagoResumenComponent) {
            planPagoResumenComponent.loadData(data.plandepagoresumen);
        }

        if (data.coberturas != null && coberturasComponent) {
            coberturasComponent.loadData(data.coberturas);
        }

        $('#generarvariacion').addClass('d-none');
        $('#cancelarpoliza').addClass('d-none');
        $('#authorizarct').removeClass('d-none');
        $('#rechazarct').removeClass('d-none');
        MCA_PROVISIONAL = "S";
        DisabledAllControls(true);

        toastr.info("Se generó correctamente la variación", "Variación", { timeOut: 9000, closeButton: true, progressBar: true });
    }

    function setupFileHandlers() {
        // Manejadores de archivos de autorización y cancelación
        $('#doc_cancelation_poliza').change(function (e) {
            var file = e.target.files[0];
            var fileName = e.target.files[0]?.name || "Indique el archivo a procesar...";
            $(this).next('.custom-file-label').text(fileName);

            if (file) {
                if (validateFile(file, fileCancelation, "Cancelación")) {
                    $('#fileTableCancelation').removeClass('d-none');
                    fileCancelation.push(file);
                    var newRow = `<tr>
                                    <td>${fileName}</td>
                                    <td>
                                        <button type="button" class="btn btn-sm btn-white delete remove-btn">
                                            <i class="fa fa-close"></i>
                                        </button>
                                    </td>
                                  </tr>`;
                    $('#fileTableCancelation tbody').append(newRow);
                }
                this.value = '';
            }
        });

        $('#doc_autorization_poliza').change(function (e) {
            var file = e.target.files[0];
            var fileName = file?.name || "Indique el archivo a procesar...";
            $(this).next('.custom-file-label').text(fileName);

            if (file) {
                if (validateFile(file, fileAuthorization, 'Autorización')) {
                    $('#fileTableAutorization').removeClass('d-none');
                    fileAuthorization.push(file);
                    var newRow = `<tr>
                                    <td>${fileName}</td>
                                    <td>
                                        <button type="button" class="btn btn-sm btn-white delete remove-btn">
                                            <i class="fa fa-close"></i>
                                        </button>
                                    </td>
                                  </tr>`;
                    $('#fileTableAutorization tbody').append(newRow);
                }
                this.value = '';
            }
        });

        // Eventos de eliminación de archivos
        $('#fileTableAutorization').on('click', '.remove-btn', function () {
            var row = $(this).closest('tr');
            var fileName = row.find('td:first').text();
            fileAuthorization = fileAuthorization.filter(function (file) {
                return file.name !== fileName;
            });
            row.remove();
        });

        $('#fileTableCancelation').on('click', '.remove-btn', function () {
            var row = $(this).closest('tr');
            var fileName = row.find('td:first').text();
            fileCancelation = fileCancelation.filter(function (file) {
                return file.name !== fileName;
            });
            row.remove();
        });
    }

    function setupAuthorizationEvents() {
        $('#authorizarct').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                var md = $('#confirmation-autorization-Modal').modal({ show: false });
                md.modal('show');
                $('#mensaje_fracc_pago').addClass('d-none');
                $('#fileTableAutorization').addClass('d-none');
                $('#fileTableBodyAuthorization').empty();
                $('#doc_autorization_poliza').next('.custom-file-label').text('Indique el archivo a procesar...');
                fileAuthorization = [];
            } else {
                var instance = $('#VisualizationsEdtForm');
                var validate = instance.validate();
                validate.settings.ignore = '';
                var result = instance.valid();
                var count = validate.numberOfInvalids();
                validate.settings.ignore = ':hidden';
                toastr.error("Existen " + count + " error(es), que ameritan su atención.", "", { closeButton: true, progressBar: true });
            }
            event.preventDefault();
        });

        $('#aceptar-autorization').click(function () {
            processAutorizationCT();
        });

        $('#rechazarct').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#rechazarct');
                var data = setupData;
                data.Mca_Autoriza_CT = "N";

                app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMasManageAuthorizationCT',
                    JSON.stringify(data),
                    function (data) {
                        if (data.McaError === "N") {
                            handleRejectionSuccess(data);
                        } else {
                            custonMessageResponse(data, "Error al rechazar el CT");
                        }
                    }).always(function () {
                        app.ui.ButtonDone('#rechazarct');
                    });
            } else {
                var instance = $('#VisualizationsEdtForm');
                var validate = instance.validate();
                validate.settings.ignore = '';
                var result = instance.valid();
                var count = validate.numberOfInvalids();
                validate.settings.ignore = ':hidden';
                toastr.error("Existen " + count + " error(es), que ameritan su atención.", "", { closeButton: true, progressBar: true });
            }
            event.preventDefault();
        });

        $('#aceptarmessage').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#aceptarmessage');
                app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMas',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        $('#Fuente_Tomador').replaceWith('<div>' + $('#Fuente_Tomador option:selected').text() + '</div>');
                        $('#Modalidad_Pago').replaceWith('<div>' + $('#Modalidad_Pago option:selected').text() + '</div>');
                        $('#tip_firma').replaceWith('<div>' + $('#tip_firma option:selected').text() + '</div>');
                        $('#correoenvio').replaceWith('<div>' + $('#correoenvio').val() + '</div>');

                        if (data.McaError === "N") {
                            handleSuccessfulVariationFromMessage(data);
                            setupDataFirst.cod_fracc_pago = app.ui.GetDropDownNumericValue('#cod_fracc_pago');
                            toastr.info("Se generó correctamente la variación", "Variación", { timeOut: 9000, closeButton: true, progressBar: true });
                        } else {
                            custonMessageResponse(data, "Error el emitir la variación");
                        }
                        $('#messageModal').modal('hide');
                    }).always(function () {
                        app.ui.ButtonDone('#aceptarmessage');
                    });
            } else {
                var instance = $('#VisualizationsEdtForm');
                var validate = instance.validate();
                validate.settings.ignore = '';
                var result = instance.valid();
                var count = validate.numberOfInvalids();
                validate.settings.ignore = ':hidden';
                toastr.error("Existen " + count + " error(es), que ameritan su atención.", "", { closeButton: true, progressBar: true });
            }
        });
    }

    function handleRejectionSuccess(data) {
        if (data.coberturas != null && coberturasComponent) {
            coberturasComponent.loadData(data.coberturas);
        }

        if (data.plandepago != null) {
            $('#plandepagoTbl').bootstrapTable('load', data.plandepago);
        }

        if (data.plandepagoresumen != null && planPagoResumenComponent) {
            planPagoResumenComponent.loadData(data.plandepagoresumen);
        }

        $('#cancelarpoliza').removeClass('d-none');
        $('#generarvariacion').removeClass('d-none');
        $('#authorizarct').addClass('d-none');
        $('#rechazarct').addClass('d-none');
        DisabledAllControls(false);
        MCA_PROVISIONAL = "N";

        custonMessageResponse(data, "Autorización");
    }

    function handleSuccessfulVariationFromMessage(data) {
        if (Array.isArray(data.Recibos) && data.Recibos.length > 0) {
            $('#resultvariacionTbl').bootstrapTable('load', data.Recibos);
            $('#resultvariacion').removeClass('d-none');
            let firstRecord = data.Recibos[0];
            NEW_NUM_SPTO = firstRecord.num_spto;
        }

        if (data.coberturas != null && coberturasComponent) {
            coberturasComponent.loadData(data.coberturas);
        }

        if (data.plandepago != null) {
            $('#plandepagoTbl').bootstrapTable('load', data.plandepago);
        }

        if (data.plandepagoresumen != null && planPagoResumenComponent) {
            planPagoResumenComponent.loadData(data.plandepagoresumen);
        }

        $('#cancelarpoliza').removeClass('d-none');
        $('#generarvariacion').removeClass('d-none');
        $('#authorizarct').addClass('d-none');
        $('#rechazarct').addClass('d-none');

        MCA_PROVISIONAL = "N";
        DisabledAllControls(false);
    }

    function processAutorizationCT() {
        var index = 0;
        var arr = fileAuthorization;

        if (!validateAuthorization()) {
            return;
        }

        if (ValidateDocument(arr)) {
            app.ui.ButtonDoing('#aceptar-autorization');

            var data = new FormData();
            data.append('EntityType', 3000);
            data.append('EntityId', setupData.num_poliza);
            data.append('DocumentType', 99);
            data.append('Description', arr.length > 0 ? arr[0].name : 'Autorización CT');

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
            }).done(function (uploadData, textStatus, jqXHR) {
                if (uploadData.length > 0) {
                    uploadData.forEach(row => {
                        toastr.info("Se guardó correctamente el documento " + row.FileName, "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
                    });
                }

                // Verificar si hay cambio de fraccionamiento
                if (setupDataFirst.cod_fracc_pago !== app.ui.GetDropDownNumericValue('#cod_fracc_pago')) {
                    generateVariacionFraccPago();
                } else {
                    authorizationCT();
                }

            }).fail(function (jqXHR, textStatus, errorThrown) {
                if (jqXHR?.responseJSON?.Message) {
                    toastr.error(jqXHR.responseJSON.Message, "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
                }
                // IMPORTANTE: Quitar el loading en caso de error
                app.ui.ButtonDone('#aceptar-autorization');
            }).always(function () {
                // IMPORTANTE: Esto se ejecuta siempre, pero solo si no se ejecutaron los otros procesos
                // Lo removemos de aquí porque se maneja en cada caso específico
            });
        } else {
            // IMPORTANTE: Si la validación falla, quitar el loading
            app.ui.ButtonDone('#aceptar-autorization');
        }
    }

    function generateVariacionFraccPago() {
        app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMas',
            JSON.stringify(MapInputToObject()),
            function (data) {
                $('#Fuente_Tomador').replaceWith('<div>' + $('#Fuente_Tomador option:selected').text() + '</div>');
                $('#Modalidad_Pago').replaceWith('<div>' + $('#Modalidad_Pago option:selected').text() + '</div>');
                $('#tip_firma').replaceWith('<div>' + $('#tip_firma option:selected').text() + '</div>');
                $('#correoenvio').replaceWith('<div>' + $('#correoenvio').val() + '</div>');

                if (data.McaError === "N") {
                    handleSuccessfulVariationFromMessage(data);
                    setupDataFirst.cod_fracc_pago = app.ui.GetDropDownNumericValue('#cod_fracc_pago');
                    toastr.info("Se generó correctamente la variación", "Variación", { timeOut: 9000, closeButton: true, progressBar: true });
                } else {
                    custonMessageResponse(data, "Error el emitir la variación");
                }

                $('#confirmation-autorization-Modal').modal('hide');
                clearAuthorizationFiles();

                // IMPORTANTE: Quitar el loading después de procesar
                app.ui.ButtonDone('#aceptar-autorization');

            }).fail(function (jqXHR, textStatus, errorThrown) {
                // IMPORTANTE: Quitar el loading en caso de error
                app.ui.ButtonDone('#aceptar-autorization');
            });
    }

    function authorizationCT() {
        var ctData = setupData;
        ctData.Mca_Autoriza_CT = "S";
        ctData.num_spto = NEW_NUM_SPTO;

        app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMasManageAuthorizationCT',
            JSON.stringify(ctData),
            function (data) {
                if (data.McaError === "N") {
                    $('#cancelarpoliza').removeClass('d-none');
                    $('#generarvariacion').removeClass('d-none');
                    $('#authorizarct').addClass('d-none');
                    $('#rechazarct').addClass('d-none');
                    DisabledAllControls(false);
                    MCA_PROVISIONAL = "N";

                    if (data.coberturas != null && coberturasComponent) {
                        coberturasComponent.loadData(data.coberturas);
                    }

                    if (data.plandepago != null) {
                        $('#plandepagoTbl').bootstrapTable('load', data.plandepago);
                    }

                    if (data.plandepagoresumen != null && planPagoResumenComponent) {
                        planPagoResumenComponent.loadData(data.plandepagoresumen);
                    }

                    if (Array.isArray(data.Recibos) && data.Recibos.length > 0) {
                        $('#resultvariacionTbl').bootstrapTable('load', data.Recibos);
                        $('#resultvariacion').removeClass('d-none');
                    }

                    custonMessageResponse(data, "Autorización");
                } else {
                    custonMessageResponse(data, "Error al autorizar el CT");
                }

                $('#confirmation-autorization-Modal').modal('hide');
                clearAuthorizationFiles();

                // IMPORTANTE: Quitar el loading después de procesar
                app.ui.ButtonDone('#aceptar-autorization');

            }).fail(function (jqXHR, textStatus, errorThrown) {
                // IMPORTANTE: Quitar el loading en caso de error
                app.ui.ButtonDone('#aceptar-autorization');
            });
    }

    function clearAuthorizationFiles() {
        $('#fileTableAutorization').addClass('d-none');
        $('#fileTableBodyAuthorization').empty();
        $('#doc_autorization_poliza').next('.custom-file-label').text('Indique el archivo a procesar...');
        fileAuthorization = [];
    }

    function ValidateDocument(files) {
        var allowedExtensions = ['pdf', 'docx'];
        var result = true;
        var message = '';

        if (files.length > 0) {
            for (let i = 0; i < files.length; i++) {
                if (files[i].size >= 31457280) {
                    if (message !== '') {
                        message += ', ';
                    }
                    message += 'El tamaño del archivo ' + files[i].name + ' es mayor a 30mb';
                    result = false;
                }

                const fileExtension = files[i].name.split('.').pop().toLowerCase();
                if (!allowedExtensions.includes(fileExtension)) {
                    if (message !== '') {
                        message += ', ';
                    }
                    message += 'El archivo ' + files[i].name + ' no tiene el formato PDF o Word (docx)';
                    result = false;
                }
            }
        } else {
            message = "No ha cargado ningún archivo";
            result = false;
        }

        if (!result) {
            toastr.error(message, "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
        }

        return result;
    }

    function validateAuthorization() {
        var result = true;
        var fec_efec = app.ui.GetDateValue('#fec_efec');
        const date = new Date(fec_efec);
        const timestamp = date.getTime();

        if (isNaN(timestamp) || timestamp < 0) {
            toastr.error('Debe registrar la fecha de efecto', "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
            result = false;
        }

        return result;
    }

    function setupCancelationEvents() {
        $('#cancelarpoliza').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                var md = $('#confirmation-cancelation-Modal').modal({ show: false });
                md.modal('show');
                $('#fileTableCancelation').addClass('d-none');
                $('#fileTableBodyCancelation').empty();
                $('#doc_cancelation_poliza').next('.custom-file-label').text('Indique el archivo a procesar...');
                fileCancelation = [];
            } else {
                var instance = $('#VisualizationsEdtForm');
                var validate = instance.validate();
                validate.settings.ignore = '';
                var result = instance.valid();
                var count = validate.numberOfInvalids();
                validate.settings.ignore = ':hidden';
                toastr.error("Existen " + count + " error(es), que ameritan su atención.", "", { closeButton: true, progressBar: true });
            }
            event.preventDefault();
        });

        $('#aceptar-cancelation').click(function () {
            processCancelation();
        });
    }

    function processCancelation() {
        if (!validateCancelation()) {
            return;
        }

        var index = 0;
        var arr = fileCancelation;

        if (ValidateDocument(arr)) {
            app.ui.ButtonDoing('#aceptar-cancelation');

            var uploadData = new FormData();
            uploadData.append('EntityType', 3000);
            uploadData.append('EntityId', setupData.num_poliza);
            uploadData.append('DocumentType', 99);
            uploadData.append('Description', arr.length > 0 ? arr[0].name : 'Cancelación Póliza');

            for (index = 0; index < arr.length; index++) {
                uploadData.append('files', arr[index]);
            }

            $.ajax({
                type: "POST",
                enctype: 'multipart/form-data',
                url: app.setting.apipath + 'v1/Common/Upload',
                data: uploadData,
                processData: false,
                contentType: false,
                cache: false,
                timeout: 600000,
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('Token'));
                }
            }).done(function (uploadResult, textStatus, jqXHR) {
                if (uploadResult.length > 0) {
                    uploadResult.forEach(row => {
                        toastr.info("Se guardó correctamente el documento " + row.FileName, "Cancelación", { timeOut: 9000, closeButton: true, progressBar: true });
                    });
                }

                // Proceder con la cancelación de la póliza
                cancelationPoliza();

            }).fail(function (jqXHR, textStatus, errorThrown) {
                if (jqXHR?.responseJSON?.Message) {
                    toastr.error(jqXHR.responseJSON.Message, "Cancelación", { timeOut: 9000, closeButton: true, progressBar: true });
                }
                app.ui.ButtonDone('#aceptar-cancelation');
            }).always(function () {
                app.ui.ButtonDone('#aceptar-cancelation');
            });
        }
    }

    function validateCancelation() {
        var result = true;
        var fec_efec_cancel = app.ui.GetDateValue('#fec_efec_cancel');
        var txt_motivo = $('#txt_motivo').val();
        const date = new Date(fec_efec_cancel);
        const timestamp = date.getTime();

        if (isNaN(timestamp) || timestamp < 0) {
            toastr.error('Debe registrar la fecha de cancelación', "Cancelación", { timeOut: 9000, closeButton: true, progressBar: true });
            result = false;
        }

        if (!txt_motivo || txt_motivo.trim() === '') {
            toastr.error('Debe registrar el motivo de cancelación', "Cancelación", { timeOut: 9000, closeButton: true, progressBar: true });
            result = false;
        }

        return result;
    }

    function cancelationPoliza() {
        var cancelData = setupData;
        cancelData.fec_efec_cancel = app.ui.GetDateValue('#fec_efec_cancel');
        cancelData.txt_motivo = $('#txt_motivo').val();

        app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMasCancelation',
            JSON.stringify(cancelData),
            function (data) {
                if (data.McaError === "N") {
                    let messageSaldo = "";

                    if (Array.isArray(data.Recibos) && data.Recibos.length > 0) {
                        $('#resultvariacionTbl').bootstrapTable('load', data.Recibos);
                        $('#resultvariacion').removeClass('d-none');

                        let firstRecord = data.Recibos[0];
                        NEW_NUM_SPTO = firstRecord.num_spto;

                        const suma_imp_recibo_spto = data.Recibos.reduce((acumulador, obj) => {
                            return acumulador + obj.imp_recibo_spto;
                        }, 0);

                        let saldoPositivo = Math.abs(suma_imp_recibo_spto);
                        let saldoTexto = FormatearNumero(saldoPositivo);

                        if (saldoPositivo > 0) {
                            messageSaldo = " El cliente cuenta con un saldo a favor de " + saldoTexto + " por concepto de primas no devengadas";
                        }
                    }

                    if (data.coberturas != null && coberturasComponent) {
                        coberturasComponent.loadData(data.coberturas);
                    }

                    if (data.plandepago != null) {
                        $('#plandepagoTbl').bootstrapTable('load', data.plandepago);
                    }

                    if (data.plandepagoresumen != null && planPagoResumenComponent) {
                        planPagoResumenComponent.loadData(data.plandepagoresumen);
                    }

                    $('#cancelarpoliza').addClass('d-none');
                    $('#generarvariacion').addClass('d-none');
                    $('#authorizarct').addClass('d-none');
                    $('#rechazarct').addClass('d-none');

                    toastr.info("La cancelación fue procesada de forma correcta." + messageSaldo, "Cancelación", { timeOut: 10000, closeButton: true, progressBar: true });

                    clearCancelationFiles();
                } else {
                    custonMessageResponse(data, "Error al emitir la cancelación");
                }

                app.ui.ButtonDone('#aceptar-cancelation');
            }).always(function () {
                app.ui.ButtonDone('#aceptar-cancelation');
            });
    }

    function clearCancelationFiles() {
        $('#confirmation-cancelation-Modal').modal('hide');
        $('#fileTableCancelation').addClass('d-none');
        $('#fileTableBodyCancelation').empty();
        $('#doc_cancelation_poliza').next('.custom-file-label').text('Indique el archivo a procesar...');
        fileCancelation = [];
    }

    function data_changed() {
        if (showCalculate) {
            $('#plandepagoRow').addClass('d-none');
            $('#mainBlock').addClass('col-md-12');
            $('#mainBlock').removeClass('col-md-9');
            $('#quoteBlock').addClass('d-none');

            // Limpiar datos de coberturas si es necesario
            if (coberturasComponent) {
                var coberturas = coberturasComponent.getData();
                for (var i = 0; i < coberturas.length; i++) {
                    coberturas[i].capital = 0;
                    coberturas[i].primatotal = 0;
                    coberturas[i].error = '';
                }
                coberturasComponent.loadData(coberturas);
            }

            $('#plandepagoTbl').bootstrapTable('load', {});
            showCalculate = false;
        }
    }

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();

        // Obtener reglas de validación de los componentes
        let sumasValidation = {};
        if (sumasAseguradasComponent) {
            sumasValidation = sumasAseguradasComponent.getValidationRules();
        }

        $("#VisualizationsEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: Object.assign({
                cod_fracc_pago: { required: true },
                NUM_MATRICULA: { required: true },
                IMP_VR: { required: true, Numeric: true }
            }, sumasValidation.rules || {}),
            messages: Object.assign({
                cod_fracc_pago: { required: 'Debe indicar el Fraccionamiento de pago' },
                NUM_MATRICULA: { required: 'Debe indicar el Número de placa' },
                IMP_VR: { required: 'Debe indicar el Valor del vehículo asegurado' }
            }, sumasValidation.messages || {})
        });
    }

    // Funciones auxiliares para archivos y validaciones
    function validateFile(file, files, process) {
        var result = true;
        var message = '';
        var allowedExtensions = ['pdf', 'docx'];
        const fileExtension = file.name.split('.').pop().toLowerCase();

        if (!allowedExtensions.includes(fileExtension)) {
            message = 'El archivo ' + file.name + ' no tiene el formato PDF o Word (docx)';
        }

        if (file.size >= 31457280) {
            if (message) message += ', ';
            message += 'El tamaño del archivo ' + file.name + ' es mayor a 30mb';
        }

        if (files.some(f => f.name === file.name)) {
            if (message) message += ', ';
            message += 'El archivo ' + file.name + ' ya fue agregado';
        }

        if (message) {
            result = false;
            toastr.error(message, process, { timeOut: 9000, closeButton: true, progressBar: true });
        }
        return result;
    }

    // Función auxiliar para manejar formularios (placeholder)
    function formularios_handler() {
        // Implementar lógica de formularios si es necesaria
        console.log('formularios_handler called');
    }

    function custonMessageResponse(data, title) {
        if (!data) return;

        if (data.ProcessResult.length > 0) {
            let timeOut = 9000;
            data.ProcessResult.forEach(function (record) {
                if (data.McaError === "N") {
                    toastr.info(record.txt_error, title, { timeOut: timeOut, closeButton: true, progressBar: true });
                    return;
                }
                toastr.error(record.txt_error, title, { timeOut: timeOut, closeButton: true, progressBar: true });
                timeOut += 5000;
            });
        }
    }

    function FormatearNumero(numero, separadorDecimal = '.', separadorMiles = ',') {
        if (isNaN(numero)) return '';

        let numeroFormateado = Number(numero).toFixed(2);
        let partes = numeroFormateado.split('.');
        let parteEntera = partes[0];
        let parteDecimal = partes[1];

        let parteEnteraFormateada = '';
        for (let i = parteEntera.length - 1, j = 0; i >= 0; i--, j++) {
            if (j % 3 === 0 && j > 0) {
                parteEnteraFormateada = separadorMiles + parteEnteraFormateada;
            }
            parteEnteraFormateada = parteEntera.charAt(i) + parteEnteraFormateada;
        }

        return parteEnteraFormateada + separadorDecimal + parteDecimal;
    }

    // Configuración de tablas restantes (documentos, plan de pago, etc.)
    function setupRemainingTables() {
        // Plan de pago tabla
        $('#plandepagoTbl').bootstrapTable({
            uniqueId: 'plandepagoId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            columns: [
                {
                    field: 'recibo',
                    title: 'Recibo',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.StringFormatter'
                },
                {
                    field: 'cuota',
                    title: 'Cuota',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                },
                {
                    field: 'tipsituacion',
                    title: 'Estado del recibo',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.StringFormatter'
                },
                {
                    field: 'fechadesde',
                    title: 'Fecha desde',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter'
                },
                {
                    field: 'fechahasta',
                    title: 'Fecha hasta',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter'
                },
                {
                    field: 'primaneta',
                    title: 'Prima neta',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter'
                },
                {
                    field: 'iVA',
                    title: 'IVA',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter'
                },
                {
                    field: 'importetotal',
                    title: 'Importe total',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter'
                }
            ]
        });

        // Documentos requeridos tabla
        $('#documentosrequeridosTbl').bootstrapTable({
            uniqueId: 'documentosrequeridosId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            columns: [
                {
                    field: 'DStored',
                    title: 'Estado',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: function (value, row, index, field) {
                        if (row.DStored === null || row.DStored === '') {
                            return '<span class="label label-danger">Pendiente</span>';
                        } else {
                            return '<span class="label label-success">Listo</span>';
                        }
                    },
                    width: 10,
                    widthUnit: '%'
                },
                {
                    field: 'tipo',
                    title: 'Tipo de documento',
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
                        } else {
                            result += ' ' + value + '</span>';
                        }
                        return result;
                    },
                    width: 40,
                    widthUnit: '%'
                },
                {
                    field: 'DNombre',
                    title: 'Archivo',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    width: 20,
                    widthUnit: '%'
                },
                {
                    field: 'DFecha',
                    title: 'Fecha',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateAndTimeFormatter',
                    width: 20,
                    widthUnit: '%'
                }
            ]
        });

        // Tabla de resultado de variación
        $('#resultvariacionTbl').bootstrapTable({
            uniqueId: 'plandepagoId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            columns: [
                {
                    field: 'num_poliza',
                    title: 'Número de poliza',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.StringFormatter'
                },
                {
                    field: 'num_spto',
                    title: 'Nro Suplemento',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter'
                },
                {
                    field: 'imp_recibo_spto',
                    title: 'Imp. Recibo suplemento',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DecimalFormatter'
                },
                {
                    field: 'num_cuota',
                    title: 'Nro Cuota',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                },
                {
                    field: 'fec_efec_recibo',
                    title: 'Fec. Efec. Recibo',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DateFormatter'
                },
                {
                    field: 'tip_situacion',
                    title: 'Tip. Situación',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.StringFormatter'
                },
                {
                    field: 'imp_recibo',
                    title: 'Imp. Recibo',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter'
                }
            ]
        });
    }

    // API Pública
    return {
        Data: function () {
            return setupData;
        },
        Init: function () {
            Controls_setup();
            Setup_Validations();
            Controls_Events();
            setupRemainingTables();
            $('.mapfremas-visible').removeClass('d-none');
            Setup();
        },
        custonMessageResponse: custonMessageResponse,
        FormatearNumero: FormatearNumero,

        // Funciones auxiliares que se necesitan
        formularios_handler: function () {
            return formularios_handler();
        },

        // Métodos que pueden ser llamados desde otras partes del código
        tercerosEditRow: function (row) {
            // Implementar si se necesita
            console.log('tercerosEditRow called with:', row);
        },

        tercerosDeleteRow: function (row) {
            // Implementar si se necesita
            console.log('tercerosDeleteRow called with:', row);
        },

        coberturasDeleteRow: function (row) {
            if (coberturasComponent) {
                // Lógica para eliminar cobertura si se llama externamente
                console.log('coberturasDeleteRow called with:', row);
            }
        },

        documentosrequeridosEditRow: function (row) {
            // Implementar si se necesita
            console.log('documentosrequeridosEditRow called with:', row);
        },

        documentosrequeridosDeleteRow: function (row) {
            // Implementar si se necesita
            console.log('documentosrequeridosDeleteRow called with:', row);
        },

        Accept: function (data) {
            // Para compatibilidad con formularios KYC
            console.log('Accept called with:', data);
        }
    };
})();