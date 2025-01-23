var app = app || {};

app.EmisionMapfreMasPlus = (function () {

    let mainHolder = null;
    let fec_vcto_poliza_grupo = null;
    let formularioRow = null;
    let workMode = '';
    let setupData = null;
    let showCalculate = false;
    let rowDocumentosrequeridos = null;
    let mca_cuotas_gratis = 'N';

    var setupDataFirst = null;
    var COD_PLAN_AUTO = 0;
    var MCA_PROVISIONAL = 'N';
    var NUM_SPTO = 0;
    var NEW_NUM_SPTO = 0;

    function Setup() {
        app.ui.CommonBehaviour();
        var _id = app.core.URLStringValue('poliza');
        NUM_SPTO = app.core.URLStringValue('spto');
        MCA_PROVISIONAL = app.core.URLStringValue('mca_provisional');

        if (_id != '') {
            workMode = app.core.URLStringValue('mode');

            $('#coberturasTbl').bootstrapTable('showLoading');
            app.core.Get(app.setting.apipath + 'v1/Variaciones/MapfreMasPlusSetup/' + _id + '/' + NUM_SPTO + '/' + MCA_PROVISIONAL)
                .done(function (data, textStatus, jqXHR) {
                    workMode = data.Modo;
                    if (localStorage.getItem('Roles').includes('Purdy')) {
                        $('.Purdy').removeClass('d-none');
                        $('#Fuente_Tomador').prop("disabled", (workMode != 'draft' && workMode != 'resume'));
                        $('#Modalidad_Pago').prop("disabled", (workMode != 'draft' && workMode != 'resume'));
                    }

                    $('.datosgeneralesZone').removeClass('col-md-12');
                    $('.datosgeneralesZone').addClass('col-md-12');
                    $('.enviosolicitudZone').removeClass('d-none');

                    if (workMode === 'draft' || workMode === 'resume') {
                        $('#guardarenviar').removeClass('d-none');
                        $("#guardarenviar").appendTo("#GenericToolBar");
                        $('.documentosrequeridosGrid').addClass('d-none');

                  
                    } else {
                        //$('#cotizar').removeClass('d-none');
                        $('.VerificarDomicilio').removeClass('d-none');
                        $("#cotizar").appendTo("#GenericToolBar");
                    }

                    COD_PLAN_AUTO = data.COD_PLAN_AUTO;

                    $('#hhd-codplanauto').val(COD_PLAN_AUTO);

                    if (MCA_PROVISIONAL == "S") {
                        $('#authorizarct').removeClass('d-none');
                        $("#authorizarct").appendTo("#GenericToolBar");
                        $('#rechazarct').removeClass('d-none');
                        $("#rechazarct").appendTo("#GenericToolBar");
                        if (Array.isArray(data.Recibos) && data.Recibos.length > 0) {
                            $('#resultvariacionTbl').bootstrapTable('load', data.Recibos);
                            $('#resultvariacion').removeClass('d-none');
                        }
                    } else {
                        $('#generarvariacion').removeClass('d-none');
                        $("#generarvariacion").appendTo("#GenericToolBar");
                        $('#cancelarpoliza').removeClass('d-none');
                        $("#cancelarpoliza").appendTo("#GenericToolBar");
                    }

                    Init_Lookups(data);
                });
        }
    }

    function ReadOnly() {
        $('input[name=tipo_prod').first().parent().parent().replaceWith('<div>' + $('input:radio[name=tipo_prod]:checked').next().html() + '</div>')
        $('#cod_mon').replaceWith('<div>' + $('#cod_mon option:selected').text() + '</div>');
        /*$('#cod_fracc_pago').replaceWith('<div>' + $('#cod_fracc_pago option:selected').text() + '</div>');*/
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
        //$('#NUM_MATRICULA').replaceWith('<div>' + $('#NUM_MATRICULA').val() + '</div>');
        $('#COD_CHASSIS').replaceWith('<div>' + $('#COD_CHASSIS').val() + '</div>');
        $('#DES_TIP_CILINDRAJE').replaceWith('<div>' + $('#DES_TIP_CILINDRAJE').val() + '</div>');
        $('#VAL_PESO').replaceWith('<div>' + $('#VAL_PESO').val() + '</div>');
        //$('#COD_COLOR').replaceWith('<div>' + $('#COD_COLOR option:selected').text() + '</div>');
        $('#NUM_MOTOR').replaceWith('<div>' + $('#NUM_MOTOR').val() + '</div>');
        $('#VAL_CAPACIDAD').replaceWith('<div>' + $('#VAL_CAPACIDAD').val() + '</div>');
        $('label[for=MCA_CERO_KM').next().replaceWith('<div>' + $('label[for=MCA_CERO_KM_' + app.ui.GetRadioNumericValue('MCA_CERO_KM') + '').html() + '</div>');
        $('label[for=MCA_AUTO_GPS').next().replaceWith('<div>' + $('label[for=MCA_AUTO_GPS_' + app.ui.GetRadioNumericValue('MCA_AUTO_GPS') + '').html() + '</div>');
        $('label[for=MCA_AUTO_GPS_CMS').next().replaceWith('<div>' + $('label[for=MCA_AUTO_GPS_CMS_' + app.ui.GetRadioNumericValue('MCA_AUTO_GPS_CMS') + '').html() + '</div>');
        $('label[for=MCA_MONITOREO_GPS').next().replaceWith('<div>' + $('label[for=MCA_MONITOREO_GPS_' + app.ui.GetRadioNumericValue('MCA_MONITOREO_GPS') + '').html() + '</div>');
        $('label[for=MCA_PRA').next().replaceWith('<div>' + $('label[for=MCA_PRA_' + app.ui.GetRadioNumericValue('MCA_PRA') + '').html() + '</div>');
        $('label[for=MCA_VR').next().replaceWith('<div>' + $('label[for=MCA_VR_' + app.ui.GetRadioNumericValue('MCA_VR') + '').html() + '</div>');
        //$('#IMP_VR').replaceWith('<div>' + $('#IMP_VR').val() + '</div>');
        $('label[for=MCA_DESC_CLIENTE_NUEVO').next().replaceWith('<div>' + $('label[for=MCA_DESC_CLIENTE_NUEVO_' + app.ui.GetRadioNumericValue('MCA_DESC_CLIENTE_NUEVO') + '').html() + '</div>');
        $('label[for=ext_garantia').next().replaceWith('<div>' + $('label[for=ext_garantia_' + app.ui.GetRadioNumericValue('ext_garantia') + '').html() + '</div>');
        $('#PCT_AJUSTE_GEN').parent().replaceWith('<div>' + $('#PCT_AJUSTE_GEN').val() + ' %</div>');
        //$('#IMP_AUTO_RC').replaceWith('<div>' + $('#IMP_AUTO_RC option:selected').text() + '</div>');
        //$('#DED_AUTO_RC').replaceWith('<div>' + $('#DED_AUTO_RC option:selected').text() + '</div>');
        //$('#IMP_AUTO_GMO').replaceWith('<div>' + $('#IMP_AUTO_GMO option:selected').text() + '</div>');
        //$('#IMP_AUTO_ACO').replaceWith('<div>' + $('#IMP_AUTO_ACO option:selected').text() + '</div>');
        //$('#IMP_AUTO_CYV').replaceWith('<div>' + $('#IMP_AUTO_CYV').val() + '</div>');
        //$('#DED_AUTO_CYV').replaceWith('<div>' + $('#DED_AUTO_CYV option:selected').text() + '</div>');
        //$('#IMP_AUTO_RAD').replaceWith('<div>' + $('#IMP_AUTO_RAD').val() + '</div>');
        //$('#DED_AUTO_RAD').replaceWith('<div>' + $('#DED_AUTO_RAD option:selected').text() + '</div>');
        //$('#IMP_AUTO_ROB').replaceWith('<div>' + $('#IMP_AUTO_ROB').val() + '</div>');
        //$('#DED_AUTO_ROB').replaceWith('<div>' + $('#DED_AUTO_ROB option:selected').text() + '</div>');
        //$('#IMP_AUTO_EQESP').replaceWith('<div>' + $('#IMP_AUTO_EQESP').val() + '</div>');
        //$('#DED_AUTO_EQESP').replaceWith('<div>' + $('#DED_AUTO_EQESP option:selected').text() + '</div>');
        $('#IMP_AUTO_NEUM').replaceWith('<div>' + $('#IMP_AUTO_NEUM option:selected').text() + '</div>');
        $('#IMP_AUTO_MECA').replaceWith('<div>' + $('#IMP_AUTO_MECA option:selected').text() + '</div>');
        //$('#IMP_AUTO_CRI').replaceWith('<div>' + $('#IMP_AUTO_CRI option:selected').text() + '</div>');
        //$('#DED_AUTO_CRI').replaceWith('<div>' + $('#DED_AUTO_CRI option:selected').text() + '</div>');
        $('#DedudAutoSust').replaceWith('<div>' + $('#DedudAutoSust option:selected').text() + '</div>');
        //$('#tercerosNew').addClass('d-none');
        //$('#tercerosTbl').bootstrapTable('hideColumn', 'Actions');
        //$('#documentosrequeridosNew').addClass('d-none');
        //$('#documentosrequeridosTbl').bootstrapTable('hideColumn', 'Actions');
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

        $('#tercerosNew').addClass('d-none');
        $('#tercerosTbl').bootstrapTable('hideColumn', 'Actions');
        $('#documentosrequeridosNew').addClass('d-none');
        $('#documentosrequeridosTbl').bootstrapTable('hideColumn', 'Actions');
        $('#formulariosNew').addClass('d-none');
        $('#formulariosTbl').bootstrapTable('hideColumn', 'Actions');
    }

    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Issue/MapfreMasPlus',
            JSON.stringify(MapInputToObject()),
            function (data) {
                setupData = data;
                if (data.Mensaje != null) {
                    app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                }
                else {
                    $('#coberturasTbl').bootstrapTable('load', data.coberturas);
                    $('#plandepagoTbl').bootstrapTable('load', data.plandepago);
                    $('#NumPoliza').html(data.num_poliza);
                    $('#cotizar').addClass('d-none');
                    $('.VerificarDomicilio').addClass('d-none');
                    ReadOnly_End();

                    $('#mainBlock').removeClass('col-md-12');
                    $('#mainBlock').addClass('col-md-9');
                    $('#quoteBlock').removeClass('d-none');
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
            'Paises.cod_pais', 'Provincias.TProvincia'];
        if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
            lookupList.push('MM_POLIZA_GRUPO.contrato',
                'MM_SUB_CONTRATOS.subcontrato');
        }
        app.core.Lookups(lookupList,
            function () {
                MapObjectToInput_First(data);
                SettingReload(function () {
                    MapObjectToInput(data);
                    GetSumaAseguradaAndEnableControls(data.coberturas);
                });
            }, `cod_ramo=${data.cod_ramo}:cod_pais=CRI:cod_mon=${data.cod_mon}:edad=${data.edad}:plan=${data.tipo_prod}:cod_marca=${data.cod_marca}:num_contrato=${data.contrato}:cod_agt=${data.cod_agt}`);


    }

    function SettingParameter() {
        return {
            cod_ramo: setupData.cod_ramo,
            edad: setupData.edad,
            cod_mon: app.ui.GetDropDownNumericValue('#cod_mon'),
            tipo_prod: $('input:radio[name=tipo_prod]:checked').val(),
            cod_marca: app.ui.GetDropDownNumericValue('#cod_marca'),

            cod_modelo: setupData.cod_modelo,
            cod_sub_modelo: setupData.cod_sub_modelo,
            anio_sub_modelo: setupData.ANIO_SUB_MODELO,
            cod_tip_vehi: setupData.cod_tip_vehi,
            cod_uso_vehi: setupData.cod_uso_vehi,
            mca_sexo: setupData.mca_sexo,
            cod_zona_circul: setupData.cod_zona_circul,
            cod_plan_auto: setupData.COD_PLAN_AUTO,

            num_contrato: setupData.contrato,
            num_subcontrato: setupData.subcontrato,
            num_poliza_grupo: setupData.polizagrupo == null ? '' : setupData.polizagrupo
        };
    }

    function SettingReload(callback) {
        var param = SettingParameter();

        app.core.Get(app.setting.apipath + `v1/Quote/MapfreMasPlusSettings?cod_ramo=${param.cod_ramo}&cod_mon=${param.cod_mon}&cod_marca=${param.cod_marca}&cod_modelo=${param.cod_modelo}&cod_sub_modelo=${param.cod_sub_modelo}&anio_sub_modelo=${param.anio_sub_modelo}&cod_tip_vehi=${param.cod_tip_vehi}&cod_uso_vehi=${param.cod_uso_vehi}&mca_sexo=${param.mca_sexo}&cod_zona_circul=${param.cod_zona_circul}&edad=${param.edad}&cod_plan_auto=${param.cod_plan_auto}&num_contrato=${param.num_contrato}&num_subcontrato=${param.num_subcontrato}&num_poliza_grupo=${param.num_poliza_grupo}&tipo_prod=${param.tipo_prod}&cod_agt=${param.cod_agt}`)
            .done(function (settingData) {
                fec_vcto_poliza_grupo = settingData.fec_vcto_poliza_grupo;
                /*if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
                    app.ui.SetDateValue('#fec_vcto_poliza', app.ui.GetDateValue('#fec_efec_poliza'))
                    app.ui.SetDateValue('#fec_vcto_poliza', settingData.fec_vcto_poliza);
                }*/

                app.ui.LookupLoad('IMP_AUTO_RC', settingData.IMP_AUTO_RC);
                app.ui.DropDownDisabled('#IMP_AUTO_RC', settingData.IMP_AUTO_RC.length == 0);
                app.ui.LookupLoad('DED_AUTO_RC', settingData.DED_AUTO_RC);

                app.ui.LookupLoad('IMP_AUTO_GMO', settingData.IMP_AUTO_GMO);
                app.ui.LookupLoad('IMP_AUTO_ACO', settingData.IMP_AUTO_ACO);
                app.ui.LookupLoad('IMP_AUTO_NEUM', settingData.IMP_AUTO_NEUM);
                app.ui.LookupLoad('IMP_AUTO_MECA', settingData.IMP_AUTO_MECA);
                app.ui.LookupLoad('IMP_AUTO_CRI', settingData.IMP_AUTO_CRI);

                app.ui.LookupLoad('DED_AUTO_CYV', settingData.DED_AUTO_CYV);
                app.ui.LookupLoad('DED_AUTO_RAD', settingData.DED_AUTO_RAD);
                app.ui.LookupLoad('DED_AUTO_ROB', settingData.DED_AUTO_ROB);
                app.ui.LookupLoad('DED_AUTO_EQESP', settingData.DED_AUTO_EQESP);
                app.ui.LookupLoad('DED_AUTO_CRI', settingData.DED_AUTO_CRI);

                if (callback !== undefined && callback !== null) {
                    callback();
                }
                ReadOnly();
            });

    }

    function MapInputToObject() {
        //var data = setupData;
        //data.cod_fracc_pago = app.ui.GetDropDownNumericValue('#cod_fracc_pago');
        //data.fec_efec_poliza = app.ui.GetDateValue('#fec_efec_poliza');
        //data.fec_vcto_poliza = app.ui.GetDateValue('#fec_vcto_poliza');
        //data.Fuente_Tomador = $('#Fuente_Tomador').val();
        //data.Modalidad_Pago = $('#Modalidad_Pago').val();
        //data.tip_firma = $('#tip_firma').val();
        //data.tip_firmaDesc = $("#tip_firma option:selected").text();
        //data.correoenvio = $('#correoenvio').val();
        //data.NUM_MATRICULA = $('#NUM_MATRICULA').val();
        //data.COD_CHASSIS = $('#COD_CHASSIS').val();
        //data.NUM_MOTOR = $('#NUM_MOTOR').val();
        //data.DES_TIP_CILINDRAJE = $('#DES_TIP_CILINDRAJE').val();
        //data.VAL_PESO = app.ui.GetNumericValue('#VAL_PESO');
        //data.COD_COLOR = app.ui.GetDropDownNumericValue('#COD_COLOR');
        //data.COD_COLORDesc = $("#COD_COLOR option:selected").text();
        //data.VAL_CAPACIDAD = app.ui.GetNumericValue('#VAL_CAPACIDAD');
        //data.Vehiculo_Otra_Poliza = app.ui.GetRadioStringValue('Vehiculo_Otra_Poliza');
        //data.terceros = $('#tercerosTbl').bootstrapTable('getData');
        //data.documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');
        //data.kyc = null;
        //let formulariosData = $('#formulariosTbl').bootstrapTable('getData');
        //if (formulariosData.length > 0) {
        //    data.kyc = $('#formulariosTbl').bootstrapTable('getData')[0].data;
        //}
        //data.NUM_MATRICULA = data.NUM_MATRICULA.replace(/[^a-zA-Z0-9]/g, "");
        //setupData = data;
        //return data;

        var data = setupData;
        data.cod_fracc_pago = app.ui.GetDropDownNumericValue('#cod_fracc_pago');
        data.COD_COLOR = app.ui.GetDropDownNumericValue('#COD_COLOR');
        data.COD_COLORDesc = $("#COD_COLOR option:selected").text();
        data.NUM_MATRICULA = $('#NUM_MATRICULA').val();
        data.IMP_AUTO_RC = app.ui.GetDropDownNumericValue('#IMP_AUTO_RC');
        data.IMP_AUTO_GMO = app.ui.GetDropDownNumericValue('#IMP_AUTO_GMO');
        data.IMP_AUTO_ACO = app.ui.GetDropDownNumericValue('#IMP_AUTO_ACO');
        data.IMP_AUTO_CYV = app.ui.GetNumericValue('#IMP_AUTO_CYV');
        data.IMP_VR = app.ui.GetNumericValue('#IMP_VR');
        data.IMP_PRA = app.ui.GetNumericValue('#IMP_VR');
        data.IMP_AUTO_CRI = app.ui.GetDropDownNumericValue('#IMP_AUTO_CRI');
        data.IMP_AUTO_RAD = app.ui.GetNumericValue('#IMP_AUTO_RAD');
        data.IMP_AUTO_ROB = app.ui.GetNumericValue('#IMP_AUTO_ROB');
        data.DED_AUTO_RC = app.ui.GetDropDownNumericValue('#DED_AUTO_RC');
        data.MCA_FEC_EFEC_SYS = app.ui.GetRadioStringValue('MCA_FEC_EFEC_SYS');
        data.DED_AUTO_ROB = app.ui.GetDropDownNumericValue('#DED_AUTO_ROB');
        data.DED_AUTO_CYV = app.ui.GetDropDownNumericValue('#DED_AUTO_CYV');
        data.DED_AUTO_RAD = app.ui.GetDropDownNumericValue('#DED_AUTO_RAD');
        data.IMP_AUTO_EQESP = app.ui.GetNumericValue('#IMP_AUTO_EQESP');
        data.DED_AUTO_EQESP = app.ui.GetDropDownNumericValue('#DED_AUTO_EQESP');

        data.NUM_MATRICULA = data.NUM_MATRICULA.replace(/[^a-zA-Z0-9]/g, "");

        const coberturas = JSON.parse($('#coberturasData').val());

        let NewCoverages = [];
        if (Array.isArray(coberturas) && coberturas.length > 0) {
            if (coberturas) {
                NewCoverages = coberturas.map(row => {
                    let addrow = {
                        capital: row.capital,
                        codigo: row.codigo,
                        deducible: row.deducible,
                        nombre: row.nombre,
                        primatotal: row.primatotal,
                        requerida: row.requerida,
                        riesgo: row.riesgo,
                        seleccionado: row.seleccionado,
                        mcaSeleccion: row.mcaSeleccion
                    };
                    return addrow;
                })
            }
        }

        data.NewCoverages = NewCoverages;

        setupData = data;
        return data;
    }

    function MapObjectToInput_First(data) {
        setupDataFirst = data;

        //app.ui.SetNumericValue('#edad', data.edad);
        //$('#mca_sexo').val(data.mca_sexo);
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

        TipoTercero_Filtro();
        mca_cuotas_gratis = data.mc_cuotas_gratis;

        $('#coberturasNewTbl').bootstrapTable('load', data.AvailableCoverages);
    }

    function MapObjectToInput(data) {

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

        $('#coberturasData').val('[]');
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
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {

                if (setupDataFirst.cod_fracc_pago !== app.ui.GetDropDownNumericValue('#cod_fracc_pago')) {
                    var md = $('#messageModal').modal({ show: false });
                    md.modal('show');
                }
                else {
                    app.ui.ButtonDoing('#generarvariacion');
                    app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMasPlus',
                        JSON.stringify(MapInputToObject()),
                        function (data) {

                            $('#Fuente_Tomador').replaceWith('<div>' + $('#Fuente_Tomador option:selected').text() + '</div>');
                            $('#Modalidad_Pago').replaceWith('<div>' + $('#Modalidad_Pago option:selected').text() + '</div>');
                            $('#tip_firma').replaceWith('<div>' + $('#tip_firma option:selected').text() + '</div>');
                            $('#correoenvio').replaceWith('<div>' + $('#correoenvio').val() + '</div>');

                            if (data.McaError === "N") {
                                if (Array.isArray(data.Recibos) && data.Recibos.length > 0) {
                                    $('#resultvariacionTbl').bootstrapTable('load', data.Recibos);
                                    $('#resultvariacion').removeClass('d-none');

                                    let firstRecord = data.Recibos[0];
                                    NEW_NUM_SPTO = firstRecord.num_spto;
                                }

                                if (data.coberturas != null)
                                    $('#coberturasTbl').bootstrapTable('load', data.coberturas);
                                $('#coberturasTbl').bootstrapTable('hideLoading');
                                if (data.plandepago != null)
                                    $('#plandepagoTbl').bootstrapTable('load', data.plandepago);

                                $('#generarvariacion').addClass('d-none');
                                $('#cancelarpoliza').addClass('d-none');
                                $('#authorizarct').removeClass('d-none');
                                $('#rechazarct').removeClass('d-none');
                                MCA_PROVISIONAL = "S";
                                DisabledAllControls(true);

                                toastr.info("Se generó correctamente la variación", "Variación", { timeOut: 9000, closeButton: true, progressBar: true });
                            }
                            else {
                                app.EmisionMapfreMas.custonMessageResponse(data, "Error el emitir la variación");
                                /*toastr.error(data.ProcessResult.txt_error, "Error el emitir la variación", { timeOut: 9000, closeButton: true, progressBar: true });*/
                            }

                        }).always(function () {
                            app.ui.ButtonDone('#generarvariacion');
                        });
                }
            }
            else {
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
                app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMasPlus',
                    JSON.stringify(MapInputToObject()),
                    function (data) {

                        $('#Fuente_Tomador').replaceWith('<div>' + $('#Fuente_Tomador option:selected').text() + '</div>');
                        $('#Modalidad_Pago').replaceWith('<div>' + $('#Modalidad_Pago option:selected').text() + '</div>');
                        $('#tip_firma').replaceWith('<div>' + $('#tip_firma option:selected').text() + '</div>');
                        $('#correoenvio').replaceWith('<div>' + $('#correoenvio').val() + '</div>');

                        if (data.McaError === "N") {
                            if (Array.isArray(data.Recibos) && data.Recibos.length > 0) {
                                $('#resultvariacionTbl').bootstrapTable('load', data.Recibos);
                                $('#resultvariacion').removeClass('d-none');

                                let firstRecord = data.Recibos[0];
                                NEW_NUM_SPTO = firstRecord.num_spto;
                            }

                            if (data.coberturas != null)
                                $('#coberturasTbl').bootstrapTable('load', data.coberturas);
                            $('#coberturasTbl').bootstrapTable('hideLoading');
                            if (data.plandepago != null)
                                $('#plandepagoTbl').bootstrapTable('load', data.plandepago);

                            $('#generarvariacion').addClass('d-none');
                            $('#cancelarpoliza').addClass('d-none');
                            $('#authorizarct').removeClass('d-none');
                            $('#rechazarct').removeClass('d-none');
                            MCA_PROVISIONAL = "S";
                            DisabledAllControls(true);

                            setupDataFirst.cod_fracc_pago = app.ui.GetDropDownNumericValue('#cod_fracc_pago');

                            toastr.info("Se generó correctamente la variación", "Variación", { timeOut: 9000, closeButton: true, progressBar: true });
                        }
                        else {
                            app.EmisionMapfreMas.custonMessageResponse(data, "Error el emitir la variación");
                        }
                        $('#messageModal').modal('hide'); // Cerrar el popup

                    }).always(function () {
                        app.ui.ButtonDone('#aceptarmessage');
                    });
            }
            else {
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

        $('#cancelarpoliza').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#cancelarpoliza');
                app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMasPlusCancelation',
                    JSON.stringify(MapInputToObject()),
                    function (data) {

                        if (data.McaError === "N") {
                            if (Array.isArray(data.Recibos) && data.Recibos.length > 0) {
                                $('#resultvariacionTbl').bootstrapTable('load', data.Recibos);
                                $('#resultvariacion').removeClass('d-none');

                                let firstRecord = data.Recibos[0];
                                NEW_NUM_SPTO = firstRecord.num_spto;
                            }

                            $('#cancelarpoliza').addClass('d-none');
                            $('#generarvariacion').addClass('d-none');
                            $('#authorizarct').addClass('d-none');
                            $('#rechazarct').addClass('d-none');

                            toastr.info("Se generó correctamente la cancelación", "Cancelación", { timeOut: 9000, closeButton: true, progressBar: true });
                        }
                        else {
                            app.EmisionMapfreMas.custonMessageResponse(data, "Error el emitir la cancelación");
                        }

                    }).always(function () {
                        app.ui.ButtonDone('#cancelarpoliza');
                    });
            }
            else {
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

        $('#authorizarct').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#authorizarct');

                var data = setupData;
                data.Mca_Autoriza_CT = "S";
                data.num_spto = NEW_NUM_SPTO;

                app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMasPlusManageAuthorizationCT',
                    JSON.stringify(data),
                    function (data) {
                        if (data.McaError === "N") {
                            $('#cancelarpoliza').removeClass('d-none');
                            $('#generarvariacion').removeClass('d-none');
                            $('#authorizarct').addClass('d-none');
                            $('#rechazarct').addClass('d-none');
                            DisabledAllControls(false);
                            Controls_sum_enable(setupData);
                            MCA_PROVISIONAL = "N";

                            if (data.coberturas != null)
                                $('#coberturasTbl').bootstrapTable('load', data.coberturas);
                            $('#coberturasTbl').bootstrapTable('hideLoading');
                            if (data.plandepago != null)
                                $('#plandepagoTbl').bootstrapTable('load', data.plandepago);

                            if (Array.isArray(data.Recibos) && data.Recibos.length > 0) {
                                $('#resultvariacionTbl').bootstrapTable('load', data.Recibos);


                                $('#resultvariacion').removeClass('d-none');
                            }
                            toastr.info("Se autorizó el CT", "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
                        }
                        else {
                            app.EmisionMapfreMas.custonMessageResponse(data, "Error al autorizar el CT");
                        }

                    }).always(function () {
                        app.ui.ButtonDone('#authorizarct');
                    });
            }
            else {
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

        $('#rechazarct').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#rechazarct');

                var data = setupData;
                data.Mca_Autoriza_CT = "N";

                app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMasPlusManageAuthorizationCT',
                    JSON.stringify(MapInputToObject()),
                    function (data) {

                        if (data.McaError === "N") {

                            if (data.coberturas != null)
                                $('#coberturasTbl').bootstrapTable('load', data.coberturas);
                            $('#coberturasTbl').bootstrapTable('hideLoading');
                            if (data.plandepago != null)
                                $('#plandepagoTbl').bootstrapTable('load', data.plandepago);

                            $('#cancelarpoliza').removeClass('d-none');
                            $('#generarvariacion').removeClass('d-none');
                            $('#authorizarct').addClass('d-none');
                            $('#rechazarct').addClass('d-none');
                            DisabledAllControls(false);
                            Controls_sum_enable(setupData);
                            MCA_PROVISIONAL = "N";

                            toastr.info("Se rechazo el CT", "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
                        }
                        else {
                            app.EmisionMapfreMas.custonMessageResponse(data, "Error al rechazar el CT");
                            //toastr.error(data.ProcessResult.txt_error, "Error al rechazar el CT", { timeOut: 9000, closeButton: true, progressBar: true });
                        }

                    }).always(function () {
                        app.ui.ButtonDone('#rechazarct');
                    });
            }
            else {
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

    }

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#VisualizationsEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                edad: { required: true },
                mca_sexo: { required: true },
                cod_mon: { required: true },
                cod_fracc_pago: { required: true },
                fec_efec_poliza: { required: true },
                fec_vcto_poliza: { required: true },
                Fuente_Tomador: { required: true },
                tip_firma: { required: true },
                correoenvio: { email: true, required: true },
                COD_PLAN_AUTO: { required: true },
                cod_marca: { required: true },
                cod_modelo: { required: true },
                ANIO_SUB_MODELO: { required: true },
                cod_tip_vehi: { required: true },
                cod_uso_vehi: { required: true },
                NUM_MATRICULA: { required: true },
                COD_CHASSIS: { required: true },
                DES_TIP_CILINDRAJE: { required: true },
                VAL_PESO: { required: true },
                COD_COLOR: { required: true },
                NUM_MOTOR: { required: true },
                VAL_CAPACIDAD: { required: true },
                IMP_VR: { required: true },
                IMP_AUTO_RC: { required: true },
                DED_AUTO_RC: { required: true },
                IMP_AUTO_GMO: { required: true },
                IMP_AUTO_ACO: { required: true },
                IMP_AUTO_CYV: { required: true },
                DED_AUTO_CYV: { required: true },
                IMP_AUTO_RAD: { required: true },
                DED_AUTO_RAD: { required: true },
                IMP_AUTO_ROB: { required: true },
                DED_AUTO_ROB: { required: true },
                DED_AUTO_EQESP: { required: true },
                IMP_AUTO_NEUM: { required: true },
                IMP_AUTO_MECA: { required: true },
                IMP_AUTO_CRI: { required: true },
                DED_AUTO_CRI: { required: true }
            },
            messages: {
                edad: { required: 'Debe indicar el Edad' },
                mca_sexo: { required: 'Debe indicar el Sexo' },
                cod_mon: { required: 'Debe indicar el Moneda' },
                cod_fracc_pago: { required: 'Debe indicar el Fraccionamiento de pago' },
                fec_efec_poliza: { required: 'Debe indicar el Inicio de vigencia' },
                fec_vcto_poliza: { required: 'Debe indicar el Fin de vigencia' },
                Fuente_Tomador: { required: 'Debe indicar el tomador' },
                tip_firma: { required: 'Debe indicar el tipo de envío' },
                correoenvio: { email: 'Debe indicar un correo electrónico valido', required: 'Debe indicar el correo para el envío' },
                COD_PLAN_AUTO: { required: 'Debe indicar el Plan' },
                cod_marca: { required: 'Debe indicar el Marca' },
                cod_modelo: { required: 'Debe indicar el Modelo' },
                NUM_MATRICULA: { required: 'Debe indicar el Número de placa' },
                COD_CHASSIS: { required: 'Debe indicar el Número de Chasis' },
                DES_TIP_CILINDRAJE: { required: 'Debe indicar el cilindraje del vehículo' },
                VAL_PESO: { required: 'Debe indicar el Peso del vehículo' },
                COD_COLOR: { required: 'Debe indicar el Color del vehículo' },
                NUM_MOTOR: { required: 'Debe indicar el Motor del vehículo' },
                VAL_CAPACIDAD: { required: 'Debe indicar el Capacidad del vehículo' },
                ANIO_SUB_MODELO: { required: 'Debe indicar el Año del vehículo' },
                cod_tip_vehi: { required: 'Debe indicar el Clase del vehículo' },
                cod_uso_vehi: { required: 'Debe indicar el Uso del vehículo' },
                IMP_VR: { required: 'Debe indicar el Valor del vehículo asegurado' },
                IMP_AUTO_RC: { required: 'Debe indicar el Responsabilidad civil' },
                DED_AUTO_RC: { required: 'Debe indicar el Deducible responsabilidad civil' },
                IMP_AUTO_GMO: { required: 'Debe indicar el Gastos médicos de ocupantes' },
                IMP_AUTO_ACO: { required: 'Debe indicar el Accidentes al conductor' },
                IMP_AUTO_CYV: { required: 'Debe indicar el Colisión y vuelco' },
                DED_AUTO_CYV: { required: 'Debe indicar el Deducible colisión y vuelco' },
                IMP_AUTO_RAD: { required: 'Debe indicar el Riesgos adicionales' },
                DED_AUTO_RAD: { required: 'Debe indicar el Deducible riesgos adicionales' },
                IMP_AUTO_ROB: { required: 'Debe indicar el Robo' },
                DED_AUTO_ROB: { required: 'Debe indicar el Deducible robo' },
                DED_AUTO_EQESP: { required: 'Debe indicar el Deducible equipo especial' },
                IMP_AUTO_NEUM: { required: 'Debe indicar el Garantía de neumáticos' },
                IMP_AUTO_MECA: { required: 'Debe indicar el Avería mecánica' },
                IMP_AUTO_CRI: { required: 'Debe indicar el Rotura de cristales' },
                DED_AUTO_CRI: { required: 'Debe indicar el Deducible rotura de cristales' }
            }
        });
    }

    function coberturas_table_setup() {

        $('#coberturasTbl').bootstrapTable({
            uniqueId: 'codigo',
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
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'mcanew',
                    title: 'McaNuevo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                },
                {
                    field: 'added',
                    title: 'Agregado',
                    halign: 'center',
                    align: 'center',
                    visible: false,
                    formatter: function (value) {
                        return value
                            ? '<i class="fa fa-check-circle text-success"></i>'
                            : '<i class="fa fa-check-circle text-muted"></i>';
                    }
                },
                {
                    field: 'actions',
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    events: 'coberturasTbl_Events',
                    formatter: function (_, row) {
                        let result = false;

                        if (row.requerida) {
                            result = false;
                        }
                        else {
                            if (row.added) {
                                result = true;
                            }
                            else {
                                if (row.seleccionado) {
                                    result = false;
                                }
                                else {
                                    result = true;
                                }
                            }
                        }

                        return (result) ? '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos de la cobertura de la fila"> <i class="fa fa-close"></i> </button>' : '';
                    },
                    cellStyle: function (value, row, index) {
                        return {
                            css: {
                                'white-space': 'nowrap',
                                'vertical-align': 'top'
                            }
                        }
                    }
                }
            ]
        });

        //$('#coberturasTbl').bootstrapTable('filterBy', { seleccionado: [true] })

        $('#coberturasNew').click(function () {
            //$('#tipodetercero').val($('#tipodetercero option[disabled!="disabled"]')[0].value);
            //$('#tipodetercero').change();
            //$('#DocumentNumberTypeMenu a.active').click();

            coberturas_table_row_edit();
        });

    }

    function coberturasNew_table_setup() {

        $('#coberturasNewTbl').bootstrapTable({
            uniqueId: 'codigo',
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
                    visible: false
                }, {
                    field: 'primatotal',
                    title: 'Prima total',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalWithZeroFormatter',
                    visible: false
                }, {
                    field: 'deducible',
                    title: 'Deducible',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'riesgo',
                    title: 'Riesgo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                }, {
                    field: 'seleccionar',
                    title: 'Seleccione',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    checkbox: true,
                    visible: true
                }
                //{
                //    field: 'Actions',
                //    title: 'Acciones',
                //    class: 'd-none d-sm-table-cell',
                //    titleTooltip: 'Acciones disponibles para un visualizations',
                //    sortable: false,
                //    halign: 'center',
                //    align: 'center',
                //    width: 10,
                //    widthUnit: "%",
                //    visible: true,
                //    events: 'tercerosTbl_Events',
                //    formatter: function (value, row, index, field) {
                //        let attribute = row.NoEditable ? " disabled" : "";
                //        return '<button type="button"' + attribute + ' class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del tercero de la fila"> <i class="fa fa-pencil"></i> </button>' +
                //            '<button type="button"' + attribute + ' class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del tercero de la fila"> <i class="fa fa-close"></i> </button>';
                //    },
                //    cellStyle: function (value, row, index) {
                //        return {
                //            css: {
                //                'white-space': 'nowrap',
                //                'vertical-align': 'top'
                //            }
                //        }
                //    }
                //}
            ]
        });

        //$('#coberturasNewTbl').bootstrapTable('filterBy', { seleccionado: [true] })

        $('#agregarCobertura').click(function () {

            const selectedRows = $('#coberturasNewTbl').bootstrapTable('getSelections');
            const mainTableData = $('#coberturasTbl').bootstrapTable('getData');
            let cod_plan_auto_val = $('#hhd-codplanauto').val();
            selectedRows.forEach(row => {

                if (cod_plan_auto_val === "31" && (row.codigo === 3002 || row.codigo === 3003)) {
                    toastr.error("La cobertura " + row.nombre + " no esta permitida para esta póliza", "Mensaje de Validación", { timeOut: 9000, closeButton: true, progressBar: true });
                }
                else {
                    const exists = mainTableData.some(item => item.codigo === row.codigo);

                    if (exists) {

                        // Obtener la celda de acciones de la fila actualizada
                        const rowIndex = $('#coberturasTbl').bootstrapTable('getData').findIndex(r => r.codigo === row.codigo);
                        if (rowIndex !== -1) {
                            $('#coberturasTbl').bootstrapTable('updateCell', {
                                index: rowIndex,
                                field: 'added',
                                value: true // Forzar actualización (se recalculará con el formatter)
                            });
                        }
                    } else {
                        // Si no existe, agregarlo como nuevo
                        const newRow = { ...row, added: true, requerida: false };
                        $('#coberturasTbl').bootstrapTable('append', newRow);
                    }
                    $('#coberturasNewTbl').bootstrapTable('removeByUniqueId', row.codigo);
                    ManagerUpdateCoberturas(row, "*");
                    const dataCoberturas = $('#coberturasTbl').bootstrapTable('getData');
                    GetSumaAseguradaAndEnableControls(dataCoberturas);
                }


            });
            $('#coberturasNewModal').modal('hide'); // Cerrar el popup

        });
    }

    function coberturas_table_row_edit() {
        var md = $('#coberturasNewModal').modal({ show: false });

        //var formInstance = $("#tercerosEdtForm");
        //var fvalidate = formInstance.validate();
        //fvalidate.resetForm();
        //row = row || terceros_table_row();
        //md.data('id', row.tercerosId);
        //$('#coberturasNewTbl').bootstrapTable('load', row);

        md.modal('show');
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
                    field: 'recibo',
                    title: 'Recibo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'cuota',
                    title: 'Cuota',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: true
                }, {
                    field: 'tipsituacion',
                    title: 'Estado del recibo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'numspto',
                    title: 'Num Spto',
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
    }

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

    function Controls_sum_enable(setupData) {


        if (setupData) {
            $('#IMP_AUTO_RC').prop('disabled', !setupData.AUTO_RC);
            $('#DED_AUTO_RC').prop('disabled', !setupData.AUTO_RC);

            $('#IMP_AUTO_CYV').prop('disabled', !setupData.AUTO_CYV);
            $('#DED_AUTO_CYV').prop('disabled', !setupData.AUTO_CYV);

            $('#IMP_AUTO_ROB').prop('disabled', !setupData.AUTO_ROB);
            $('#DED_AUTO_ROB').prop('disabled', !setupData.AUTO_ROB);

            if (COD_PLAN_AUTO === 31) {
                $('#IMP_AUTO_GMO').prop('disabled', COD_PLAN_AUTO === 31);
                $('#IMP_AUTO_ACO').prop('disabled', COD_PLAN_AUTO === 31);
            }
            else {
                $('#IMP_AUTO_GMO').prop('disabled', !setupData.AUTO_GMO);
                $('#IMP_AUTO_ACO').prop('disabled', !setupData.AUTO_ACO);
            }

            $('#IMP_AUTO_RAD').prop('disabled', !setupData.AUTO_RAD);
            $('#DED_AUTO_RAD').prop('disabled', !setupData.AUTO_RAD);

            $('#IMP_AUTO_EQESP').prop('disabled', !setupData.AUTO_EQESP);
            $('#DED_AUTO_EQESP').prop('disabled', !setupData.AUTO_EQESP);

            $('#IMP_AUTO_CRI').prop('disabled', !setupData.AUTO_CRI);
            $('#DED_AUTO_CRI').prop('disabled', !setupData.AUTO_CRI);

            $('#IMP_AUTO_NEUM').prop('disabled', !setupData.AUTO_NEUM);

            $('#IMP_AUTO_MECA').prop('disabled', !setupData.AUTO_MECA);

            if (!setupData.AUTO_CRI) $('#DED_AUTO_CRI').val("0");
        }
        else {
            $('#IMP_AUTO_GMO').prop('disabled', COD_PLAN_AUTO === 31);
            $('#IMP_AUTO_ACO').prop('disabled', COD_PLAN_AUTO === 31);
        }

        //Reglas del ramo 302

        $('#IMP_AUTO_CYV').prop('disabled', true);
        $('#IMP_AUTO_RAD').prop('disabled', true);
        $('#IMP_AUTO_ROB').prop('disabled', true);
    }


    function GetSumaAseguradaAndEnableControls(coberturas) {
        const listaSumasAseguradasValidas = [];

        if (coberturas) {
            coberturas.forEach(cobertura => {
                const sumasAsegurada = setupData.SumAseguradaRamo.filter(item => item.cod_cob === cobertura.codigo)
                    .map(item => item.cod_campo);

                sumasAsegurada.forEach(sumaAseg => {
                    listaSumasAseguradasValidas.push({
                        cod_cob: cobertura.codigo,
                        cod_suma: sumaAseg
                    });
                });
            });
        }
        SetControls();
        EnableControls(listaSumasAseguradasValidas);
        Controls_sum_enable(setupData);
    }

    function EnableControls(sumaAseguradas) {
        if (sumaAseguradas) {
            sumaAseguradas.forEach(item => {
                switch (item.cod_suma) {
                    case "IMP_AUTO_RC":
                        setupData.AUTO_RC = true;
                        break;
                    case "IMP_AUTO_CYV":
                        setupData.AUTO_CYV = true;
                        break;
                    case "IMP_AUTO_ROB":
                        setupData.AUTO_ROB = true;
                        break;
                    case "IMP_AUTO_GMO":
                        setupData.AUTO_GMO = true;
                        break;
                    case "IMP_AUTO_ACO":
                        setupData.AUTO_ACO = true;
                        break;
                    case "IMP_AUTO_RAD":
                        setupData.AUTO_RAD = true;
                        break;
                    case "IMP_AUTO_EQESP":
                        setupData.AUTO_EQESP = true;
                        break;
                    case "IMP_AUTO_CRI":
                        setupData.AUTO_CRI = true;
                        break;
                    case "IMP_AUTO_NEUM":
                        setupData.AUTO_NEUM = true;
                        break;
                    case "IMP_AUTO_MECA":
                        setupData.AUTO_MECA = true;
                        break;
                }
            });
        }
    }

    function SetControls() {
        setupData.AUTO_RC = false;
        setupData.AUTO_CYV = false;
        setupData.AUTO_ROB = false;
        setupData.AUTO_GMO = false;
        setupData.AUTO_ACO = false;
        setupData.AUTO_RAD = false;
        setupData.AUTO_EQESP = false;
        setupData.AUTO_CRI = false;
        setupData.AUTO_NEUM = false;
        setupData.AUTO_MECA = false;
    }

    function coberturas_table_row_delete(row) {

        const mainTableData = $('#coberturasTbl').bootstrapTable('getData');
        const exists = mainTableData.find(item => item.codigo === row.codigo);

        if (exists) {

            if (exists.seleccionado) {
                // Obtener la celda de acciones de la fila actualizada
                const rowIndex = $('#coberturasTbl').bootstrapTable('getData').findIndex(r => r.codigo === row.codigo);
                if (rowIndex !== -1) {
                    $('#coberturasTbl').bootstrapTable('updateCell', {
                        index: rowIndex,
                        field: 'added',
                        value: false // Forzar actualización (se recalculará con el formatter)
                    });
                }
            }
            else {
                $('#coberturasTbl').bootstrapTable('removeByUniqueId', row.codigo);

                const coberturasNewTbl = $('#coberturasNewTbl').bootstrapTable('getData');
                const exists = coberturasNewTbl.some(item => item.codigo === row.codigo);

                if (!exists) {
                    row.seleccionado = false;
                    $('#coberturasNewTbl').bootstrapTable('append', row);
                }
            }
            const dataCoberturas = $('#coberturasTbl').bootstrapTable('getData');
            ManagerUpdateCoberturas(row, "X");
            GetSumaAseguradaAndEnableControls(dataCoberturas);
        }
    }

    function ManagerUpdateCoberturas(cobertura, action) {
        var coberturasData = $('#coberturasData').val();
        var coberturas = JSON.parse(coberturasData);

        if (!Array.isArray(coberturas)) {
            coberturas = [];
        }

        let index = coberturas.findIndex(c => c.codigo === cobertura.codigo);
        if (action === "-") {
            coberturas.splice(index, 1);
        }
        else {
            if (index !== -1) {
                coberturas[index].mcaSeleccion = action;
            }
            else {
                cobertura.mcaSeleccion = action;
                coberturas.push(cobertura);
            }
        }
        $('#coberturasData').val(JSON.stringify(coberturas));
    }

    function OtherValidations() {
        let result = 0;
        let message = 'Verifique la información de terceros';
        let terceros = $('#tercerosTbl').bootstrapTable('getData');
        let terceroserrors = (terceros.length === 0);
        

        if (!terceroserrors && (workMode === 'draft' || workMode === 'resume' || workMode === 'continue')) {
            let holder = terceros.filter(i => i.tipodetercero === 0);
            let insured = terceros.filter(i => i.tipodetercero === 2);
            let driver = terceros.filter(i => i.tipodetercero === 3);
            let bene = terceros.filter(i => i.tipodetercero === 6);
            let pagador = terceros.filter(i => i.tipodetercero === 21);

            if (holder.length === 0) {
                message += ', indique el tomador';
                terceroserrors = true;
            }
            if (insured.length === 0) {
                message += ', indique el asegurado';
                terceroserrors = true;
            }
            if (driver.length === 0) {
                message += ', indique el conductor habitual';
                terceroserrors = true;
            }
            if (bene.length > 0) {
                if (bene.reduce((total, item) => total + item.porcentaje, 0) != 100) {
                    message += ', El total del porcentaje de participación para los beneficiarios debe ser el 100%';
                    terceroserrors = true;
                }
            }
            if ((pagador.length == 0) && (mca_cuotas_gratis == 'S')) {
                message += ', Si posee cuotas gratis , indique el pagador.';
                terceroserrors = true;
            }
        }
        

        if (terceroserrors) {
            $('#tercerosTbl-error').html(message);
            $('#tercerosTbl-error').removeClass('d-none');
            result = result + 1;
        } else {
            $('#tercerosTbl-error').addClass('d-none');
        }

        if (workMode != 'draft' && workMode != 'resume') {
            var grupo = 'F';
            let documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');
            let lista = documentosrequeridos.filter(function (row) {
                return (row.DStored === null || row.DStored === '');
            });
            if (lista.length > 0) {
                $('#documentosrequeridosTbl-error').html('Debe cargar todos los documentos pendientes');
                $('#documentosrequeridosTbl-error').removeClass('d-none');
                result = result + 1;
            }
        }

        if (formulariosMode()) {
            result = FormulariosValidations(result);
        }
        return result;
    }

    function FormulariosValidations(result) {
        let formularios = $('#formulariosTbl').bootstrapTable('getData');
        let formularioserrors = (formularios.length === 0);
        let message = '';

        if (formularioserrors) {
            message = 'Debe responder los formularios requeridos';
        } else {
            if (formularios[0].when === null) {
                message = 'Debe responder el formulario ' + formularios[0].name.toLowerCase();
                formularioserrors = true;
            }
        }
        if (formularioserrors) {
            $('#formulariosTbl-error').html(message);
            $('#formulariosTbl-error').removeClass('d-none');
            result = result + 1;

        } else {
            $('#formulariosTbl-error').addClass('d-none');
        }
        return result;
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
                }
            ]
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
                data.append('Description', arr[0].name);
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
                    let oldId = rowDocumentosrequeridos.documentosrequeridosId;
                    rowDocumentosrequeridos.documentosrequeridosId = data[0].Id;
                    rowDocumentosrequeridos.DNombre = data[0].FileName;
                    rowDocumentosrequeridos.DStored = data[0].StoredFileName;
                    rowDocumentosrequeridos.DTamano = data[0].Size;
                    rowDocumentosrequeridos.DFecha = new Date();
                    $('#documentosrequeridosTbl').bootstrapTable('updateByUniqueId', { id: oldId, row: rowDocumentosrequeridos });

                }).fail(function (jqXHR, textStatus, errorThrown) {
                    console.log("ERROR : ", jqXHR);
                }).always(function () {
                    app.ui.ButtonDone('#fileUpload')
                });
            }
        });

    }

    function formularios_table_setup() {
        $('#formulariosTbl').bootstrapTable({
            uniqueId: 'formularioId',
            data: [],
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'status',
                    title: 'Estado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: function (value, row, index, field) {

                        if (row.data === null) {
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
                    field: 'name',
                    title: 'Tipo de formulario',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true,
                    width: 60,
                    widthUnit: '%'
                }, {
                    field: 'when',
                    title: 'Cuando',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateAndTimeFormatter',
                    visible: true,
                    width: 20,
                    widthUnit: '%'
                }, {
                    field: 'Actions',
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un formulario',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    visible: true,
                    events: 'formulariosTbl_Events',
                    formatter: function (value, row, index, field) {
                        var html = [];
                        html.push('<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite agregar o editar la información de un formulario"> <i class="fa fa-pencil"></i> </button>');
                        html.push('<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar la información de un formulario"> <i class="fa fa-recycle"></i> </button>');
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

    }

    function formularios_table_row_edit(row) {
        formularioRow = row;
        let name = "#" + formularioRow.type;

        if ($(name + 'Modal').length == 1) {
            let md = $(name + 'Modal').modal({ show: false });
            let ref = formularioRow.type === 'kycpersona' ? app.kycpersona : app.kycjuridico;
            md.modal('show');
            ref.SetData(formularioRow.data);
        } else {

            $('.ibox-content').toggleClass('sk-loading');

            app.core.GetView(app.setting.viewpath + (formularioRow.type === 'kycpersona' ? 'Emision/_kyc_persona' : 'Emision/_kyc_juridico'))
                .done(function (data, textStatus, jqXHR) {
                    $("#dynamic").append(data);

                    let md = $(name + 'Modal').modal({ show: false });

                    md.modal('show');

                    app.core.LoadScriptFile(formularioRow.type === 'kycpersona' ? 'Emision.kyc.persona.js' : 'Emision.kyc.juridico.js')
                        .then(d => {
                            let ref = formularioRow.type === 'kycpersona' ? app.kycpersona : app.kycjuridico;
                            if (formularioRow.data === null) {
                                formularioRow.data = ref.InitData(false);
                                if (formularioRow.type === 'kycpersona') {
                                    if (app.ui.IsDocumentNumberValid(mainHolder[0].DocumentNumberType, mainHolder[0].DocumentNumber)) {
                                        var value = mainHolder[0].DocumentNumber.replace(/-/g, '');
                                        app.core.Get(app.setting.apipath + 'v1/KYC/' + "persona" + "?id=" + value)
                                            .done(function (data, textStatus, jqXHR) {
                                                if (data != null) {
                                                    for (const a in formularioRow.data) {
                                                        for (const b in data) {
                                                            if (a == b) {
                                                                formularioRow.data[a] = data[b]
                                                            }
                                                        }
                                                    }

                                                }
                                                else {
                                                    formularioRow.data.nacionalidadPer = 188;
                                                    formularioRow.data.paisdenacimientoPer = 188;
                                                }

                                                formularioRow.data.primerapellidoPer = mainHolder[0].apellido1;
                                                formularioRow.data.segundoapellidoPer = mainHolder[0].apellido2;
                                                formularioRow.data.nombrePer = mainHolder[0].nombre;
                                                formularioRow.data.fechadenacimientoPer = mainHolder[0].fechadenacimiento;
                                                formularioRow.data.correoelectronicoPer = mainHolder[0].correoelectronico;
                                                formularioRow.data.sexoPer = mainHolder[0].tercerosMca_sexo;
                                                formularioRow.data.numidentificacion = mainHolder[0].DocumentNumber;
                                                formularioRow.data.numidentificaciontipo = mainHolder[0].DocumentNumberType;
                                                formularioRow.data.estadocivilPer = mainHolder[0].estadoCivil;
                                                formularioRow.data.telefonoresidenciaPer = mainHolder[0].numerodetelefono;

                                                formularioRow.data.domiciliopermanenteCod_pais = mainHolder[0].cod_pais;
                                                formularioRow.data.domiciliopermanenteCod_estado = mainHolder[0].TProvincia;
                                                formularioRow.data.domiciliopermanenteCod_prov = mainHolder[0].TCanton;
                                                formularioRow.data.domiciliopermanenteCod_localidad = mainHolder[0].TDistrito;
                                                formularioRow.data.domiciliopermanenteDireccionexacta = mainHolder[0].otrasenas;

                                                ref.Init(formularioRow.data);
                                                ref.AcceptCallBack(app.EmisionMapfreMasPlus.Accept);
                                            })
                                    }
                                }
                                else {
                                    if (app.ui.IsDocumentNumberValid(mainHolder[0].DocumentNumberType, mainHolder[0].DocumentNumber)) {
                                        var value = mainHolder[0].DocumentNumber.replace(/-/g, '');
                                        app.core.Get(app.setting.apipath + 'v1/KYC/' + "juridico" + "?id=" + value)
                                            .done(function (data, textStatus, jqXHR) {
                                                if (data != null) {
                                                    for (const a in formularioRow.data) {
                                                        for (const b in data) {
                                                            if (a == b) {
                                                                formularioRow.data[a] = data[b]
                                                            }
                                                        }
                                                    }
                                                }


                                                formularioRow.data.nombrecomercialJur = mainHolder[0].nombre;
                                                formularioRow.data.razonsocialJur = mainHolder[0].nombre;
                                                formularioRow.data.numidentificacion = mainHolder[0].DocumentNumber;
                                                formularioRow.data.correoelectronicoJur = mainHolder[0].correoelectronico;

                                                formularioRow.data.domiciliocomercialCod_pais = mainHolder[0].cod_pais;
                                                formularioRow.data.domiciliocomercialCod_estado = mainHolder[0].TProvincia;
                                                formularioRow.data.domiciliocomercialCod_prov = mainHolder[0].TCanton;
                                                formularioRow.data.domiciliocomercialCod_localidad = mainHolder[0].TDistrito;
                                                formularioRow.data.domiciliocomercialDireccionexacta = mainHolder[0].otrasenas;

                                                ref.Init(formularioRow.data);
                                                ref.AcceptCallBack(app.EmisionMapfreMasPlus.Accept);
                                            })
                                    }

                                }
                            }
                        })
                        .catch(err => {
                            console.error(err);
                        });
                }).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });
        }
    }

    function formularios_table_row_delete(row) {
        row.when = null;
        row.data = null;
        $('#formulariosTbl').bootstrapTable('updateByUniqueId', { id: row.formularioId, row: row });
    }

    function formularios_table_kycSetData(data) {
        let name = "#" + formularioRow.type;
        formularioRow.data = data;
        formularioRow.when = new Date();
        $('#formulariosTbl').bootstrapTable('updateByUniqueId', { id: formularioRow.formularioId, row: formularioRow });
        $(name + 'Modal').modal('hide');
        FormulariosValidations(0);
    };

    function formularios_handler() {
        if (formulariosMode()) {
            mainHolder = $('#tercerosTbl').bootstrapTable('getData').filter(i => i.tipodetercero === 0);
            if (mainHolder.length > 0 && $('#formulariosTbl').bootstrapTable('getData').length == 0) {

                $('.formulariosGrid').removeClass('d-none');

                let row = { formularioId: 1, name: 'Conozca a su cliente persona', when: setupData.kyc === null ? null : new Date(), type: 'kycpersona', data: setupData.kyc };

                if (mainHolder[0].DocumentNumberType === 4) {
                    row.name = 'Conozca a su cliente Jurídico';
                    row.type = 'kycjuridico';
                }

                $('#formulariosTbl').bootstrapTable('load', [row]);
            }
            if (mainHolder.length === 0) {
                $('.formulariosGrid').addClass('d-none');
            }
        }
    };

    function formulariosMode() {
        //return ((workMode === 'draft' || workMode === 'resume') && !localStorage.getItem('Roles').includes('Purdy') && !localStorage.getItem('Roles').includes('Davivienda_Prendarios') && !localStorage.getItem('Roles').includes('Davivienda_Leasing'));
        return ((workMode === 'draft' || workMode === 'resume') && !localStorage.getItem('Roles').includes('Purdy'));
    }

    return {
        Data: function () {
            return setupData;
        },
        Init: function () {
            Controls_setup();
            Setup_Validations();
            coberturas_table_setup();
            coberturasNew_table_setup();
            plandepago_table_setup();
            Controls_Events();

            terceros_table_setup();

            documentosrequeridos_controls_setup();
            documentosrequeridos_table_setup();
            documentosrequeridos_table_Validations();
            documentosrequeridos_controls_Events();

            formularios_table_setup();

            $('.mapfremas-visible').removeClass('d-none');

            Setup();
        },
        documentosrequeridosEditRow: function (row) {
            documentosrequeridos_table_row_edit(row);
        },
        documentosrequeridosDeleteRow: function (row) {
            documentosrequeridos_table_row_delete(row);
        },
        formulariosEditRow: function (row) {
            formularios_table_row_edit(row);
        },
        formulariosDeleteRow: function (row) {
            formularios_table_row_delete(row);
        },
        Accept: function (data) {
            formularios_table_kycSetData(data);
        },
        formularios_handler: function (src) {
            formularios_handler();
        },
        coberturasDeleteRow: function (row) {
            coberturas_table_row_delete(row);
        }
    };
})();

window.coberturasTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar la cobertura '" + row.nombre + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMapfreMasPlus.coberturasDeleteRow(row); } });
        e.stopPropagation();
    }
};

window.documentosrequeridosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer limpiar el documento requerido '" + row.DNombre + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMapfreMasPlus.documentosrequeridosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionMapfreMasPlus.documentosrequeridosEditRow(row);
        e.stopPropagation();
    }
};
window.formulariosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer limpiar la información del formulario  '" + row.name + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMapfreMasPlus.formulariosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionMapfreMasPlus.formulariosEditRow(row);
        e.stopPropagation();
    }
};