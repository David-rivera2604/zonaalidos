var app = app || {};

//Aliniacion a la derecha de los combos
//select { text-align-last: right; }
//option { direction: rtl; }

app.EmisionMapfreMas = (function () {

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
                    $('#plandepagoresumenTbl').addClass('d-none');
                    $('#fileTableAutorization').addClass('d-none');
                    $('#fileTableCancelation').addClass('d-none');

                    $('#PageSubTitle').text("Emision de Variación y/o Cancelación")
                    $('.datosgeneralesZone').removeClass('col-md-12');
                    $('.datosgeneralesZone').addClass('col-md-10');
                    $('.enviosolicitudZone').removeClass('d-none');

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
        $('#NUM_POLIZA').replaceWith('<div>' + $('#NUM_POLIZA').val() + '</div>');
        $('#cod_mon').replaceWith('<div>' + $('#cod_mon option:selected').text() + '</div>');
        //$('#cod_fracc_pago').replaceWith('<div>' + $('#cod_fracc_pago option:selected').text() + '</div>');
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
        $('#COD_COLOR').replaceWith('<div>' + $('#COD_COLOR option:selected').text() + '</div>');
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
        /*$('#DED_AUTO_RAD').replaceWith('<div>' + $('#DED_AUTO_RAD option:selected').text() + '</div>');*/
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

        $('#tercerosNew').addClass('d-none');
        $('#tercerosTbl').bootstrapTable('hideColumn', 'Actions');
        $('#documentosrequeridosNew').addClass('d-none');
        $('#documentosrequeridosTbl').bootstrapTable('hideColumn', 'Actions');
        $('#formulariosNew').addClass('d-none');
        $('#formulariosTbl').bootstrapTable('hideColumn', 'Actions');
    }

    function DisabledAllControls(isdisabled) {
        $('#cod_fracc_pago').prop('disabled', isdisabled);
        $('#MCA_FEC_EFEC_SYS_1').prop('disabled', isdisabled);
        $('#MCA_FEC_EFEC_SYS_2').prop('disabled', isdisabled);

        $('#IMP_VR').prop('disabled', isdisabled);
        $('#NUM_MATRICULA').prop('disabled', isdisabled);
        $('#COD_COLOR').prop('disabled', isdisabled);

        $('#IMP_AUTO_RC').prop('disabled', isdisabled);
        $('#DED_AUTO_RC').prop('disabled', isdisabled);
        
        if (isdisabled) {
            $('#IMP_AUTO_GMO').prop('disabled', isdisabled);
            $('#IMP_AUTO_ACO').prop('disabled', isdisabled);
        }
        else {
            $('#IMP_AUTO_GMO').prop('disabled', COD_PLAN_AUTO === 31);
            $('#IMP_AUTO_ACO').prop('disabled', COD_PLAN_AUTO === 31);
        }

        $('#DED_AUTO_CYV').prop('disabled', isdisabled);
        $('#DED_AUTO_RAD').prop('disabled', isdisabled);
        $('#DED_AUTO_ROB').prop('disabled', isdisabled);
        $('#IMP_AUTO_CRI').prop('disabled', isdisabled);
        $('#DED_AUTO_CRI').prop('disabled', isdisabled);
        $('#IMP_AUTO_EQESP').prop('disabled', isdisabled);
        $('#DED_AUTO_EQESP').prop('disabled', isdisabled);

        $('#coberturasTbl').find('input, button').prop('disabled', isdisabled);
        $('#plandepagoTbl').find('input, button').prop('disabled', isdisabled);

        $('#coberturasNew').prop('disabled', isdisabled);
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
                    data_changed();
                    GetSumaAseguradaAndEnableControls(data.coberturas);
                    //Controls_sum_enable(data);
                });
            }, `cod_ramo=${data.cod_ramo}:cod_pais=CRI:cod_mon=${data.cod_mon}:edad=${data.edad}:plan=${data.tipo_prod}:cod_marca=${data.cod_marca}:num_contrato=${data.contrato}:cod_agt=${data.cod_agt}`);


    }

    function SettingReload(callback) {
        let param = setupData;
        param.cod_mon = app.ui.GetDropDownNumericValue('#cod_mon');
        param.tipo_prod = $('input:radio[name=tipo_prod]:checked').val();
        param.cod_marca = app.ui.GetDropDownNumericValue('#cod_marca');

        app.core.Get(app.setting.apipath + `v1/Variaciones/MapfreMasSettings?cod_ramo=${param.cod_ramo}&cod_mon=${param.cod_mon}&cod_marca=${param.cod_marca}&cod_modelo=${param.cod_modelo}&cod_sub_modelo=${param.cod_sub_modelo}&anio_sub_modelo=${param.ANIO_SUB_MODELO}&cod_tip_vehi=${param.cod_tip_vehi}&cod_uso_vehi=${param.cod_uso_vehi}&mca_sexo=${param.mca_sexo}&cod_zona_circul=${param.cod_zona_circul}&edad=${param.edad}&cod_plan_auto=${param.COD_PLAN_AUTO}&num_contrato=${param.contrato}&num_subcontrato=${param.subcontrato}&num_poliza_grupo=${param.polizagrupo}&tipo_prod=${param.tipo_prod}&cod_agt=${param.cod_agt}`)
            .done(function (settingData) {
                fec_vcto_poliza_grupo = settingData.fec_vcto_poliza_grupo;
                /*if (localStorage.getItem('Roles').includes('PolizaGrupo')) {
                    app.ui.SetDateValue('#fec_vcto_poliza', app.ui.GetDateValue('#fec_efec_poliza'))
                    app.ui.SetDateValue('#fec_vcto_poliza', settingData.fec_vcto_poliza);
                }*/

                app.ui.LookupLoad('IMP_AUTO_RC', settingData.IMP_AUTO_RC);
                //app.ui.DropDownDisabled('#IMP_AUTO_RC', settingData.IMP_AUTO_RC.length == 0);
                $('#IMP_AUTO_RC').prop('disabled', settingData.IMP_AUTO_RC.length == 0);
                app.ui.LookupLoad('DED_AUTO_RC', settingData.DED_AUTO_RC);

                app.ui.LookupLoad('IMP_AUTO_GMO', settingData.IMP_AUTO_GMO);
                app.ui.LookupLoad('IMP_AUTO_ACO', settingData.IMP_AUTO_ACO);
                app.ui.LookupLoad('IMP_AUTO_NEUM', settingData.IMP_AUTO_NEUM);
                app.ui.LookupLoad('IMP_AUTO_MECA', settingData.IMP_AUTO_MECA);
                app.ui.LookupLoad('IMP_AUTO_CRI', settingData.IMP_AUTO_CRI);

                app.ui.LookupLoad('DED_AUTO_CYV', app.EmisionMapfreMas.findOrAddRecordCombobox(settingData.DED_AUTO_CYV, param.DED_AUTO_CYV, param.DED_AUTO_CYV_Desc));
                app.ui.LookupLoad('DED_AUTO_RAD', app.EmisionMapfreMas.findOrAddRecordCombobox(settingData.DED_AUTO_RAD, param.DED_AUTO_RAD, param.DED_AUTO_RAD_Desc));
                app.ui.LookupLoad('DED_AUTO_ROB', app.EmisionMapfreMas.findOrAddRecordCombobox(settingData.DED_AUTO_ROB, param.DED_AUTO_ROB, param.DED_AUTO_ROB_Desc));
                app.ui.LookupLoad('DED_AUTO_EQESP', settingData.DED_AUTO_EQESP);
                app.ui.LookupLoad('DED_AUTO_CRI', settingData.DED_AUTO_CRI);

                if (callback !== undefined && callback !== null) {
                    callback();
                }
                ReadOnly();
            });

    }

    function MapInputToObject() {
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

        data.fec_efec = app.ui.GetDateValue('#fec_efec');

        setupData = data;
        return data;
    }

    function existeCambios() {
        let result = true;
        const camposAComparar = ["cod_fracc_pago", "NUM_MATRICULA", "IMP_AUTO_RC", "IMP_AUTO_GMO", "IMP_AUTO_ACO", "IMP_AUTO_CYV", "IMP_VR", "IMP_AUTO_CRI",
            "IMP_AUTO_RAD", "IMP_AUTO_ROB", "DED_AUTO_RC", "DED_AUTO_ROB", "DED_AUTO_CYV", "DED_AUTO_RAD", "IMP_AUTO_EQESP", "DED_AUTO_EQESP"];
        //const camposLista = ["codigo", "nombre", "capital", "primatotal", "deducible"];
        let data = MapInputToObject();

        const isEquals = sonObjetosIguales(setupDataFirst, data, camposAComparar);
        const lista = data.NewCoverages || [];        

        // Si no hay datos en la lista, no hay nuevos registros ni modificados de coverturas
        if (lista.length <= 0 && isEquals) {
            result = false;
            toastr.error("Existe un error, debe modificar alguno de los datos", "Error el emitir la variación", { timeOut: 9000, closeButton: true, progressBar: true });
        }

        return result;
    }

    function sonObjetosIguales(obj1, obj2, camposAComparar) {
        // 1. Comparar los campos específicos (excepto la lista)
        for (const campo of camposAComparar) {

            // Si algún campo no existe en uno de los objetos, son diferentes
            if (!obj1.hasOwnProperty(campo) || !obj2.hasOwnProperty(campo)) {
                return false;
            }

            // Si los valores son diferentes, los objetos son diferentes
            if (JSON.stringify(obj1[campo]) !== JSON.stringify(obj2[campo])) {
                return false;
            }
        }

        // Si llegamos hasta aquí, los objetos son idénticos en los campos especificados
        return true;
    }

    function MapObjectToInput_First(data) {
        setupDataFirst = data;
        app.ui.SetNumericValue('#NUM_POLIZA', data.num_poliza);
        $('#NUM_POLIZA').val(data.num_poliza);
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

        if (data.plandepagoresumen != null) {
            $('#plandepagoresumenTbl').removeClass('d-none');
            $('#plandepagoresumenTbl').bootstrapTable('load', data.plandepagoresumen);
        }
        else
            $('#plandepagoresumenTbl').bootstrapTable('load', {});

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
        }
        else
            $('#formulariosTbl').bootstrapTable('load', {});
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

        //$('#fec_cancelation_poliza').datetimepicker({
        //    format: 'DD/MM/YYYY',
        //    locale: 'es'
        //});
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

        //$('#fec_efec_poliza').blur(function () {
        //    var minDate = app.ui.GetDateRawValue('#fec_efec_poliza');
        //    minDate.setDate(minDate.getDate() + 1);

        //    $('#fec_vcto_poliza_group').data("DateTimePicker").minDate(minDate);
        //    if (fec_vcto_poliza_grupo != null) {
        //        app.ui.SetDateValue('#fec_vcto_poliza', fec_vcto_poliza_grupo);
        //    } else {
        //        let fec_vcto = app.ui.GetDateRawValue('#fec_efec_poliza');
        //        fec_vcto.setFullYear(fec_vcto.getFullYear() + 1);
        //        app.ui.SetDateValue('#fec_vcto_poliza', fec_vcto);
        //    }
        //});

        //$('#Fuente_Tomador').change(function () {
        //    let value = $('#Fuente_Tomador').val();
        //    app.core.Post(app.setting.apipath + 'v1/Issue/MapfreMas/Terceros/' + value,
        //        JSON.stringify($('#tercerosTbl').bootstrapTable('getData')),
        //        function (data) {
        //            setupData.terceros = data;
        //            if (data != null)
        //                $('#tercerosTbl').bootstrapTable('load', data);
        //            else
        //                $('#tercerosTbl').bootstrapTable('load', {});
        //        });
        //});

        //$('#cotizar').click(function () {
        //    var others = OtherValidations();
        //    if (app.ui.IsValid('#VisualizationsEdtForm', false) && others === 0) {
        //        app.ui.ButtonDoing('#cotizar');
        //        Quote();
        //    }
        //    else {
        //        var instance = $('#VisualizationsEdtForm');
        //        var validate = instance.validate();
        //        validate.settings.ignore = '';
        //        var result = instance.valid();
        //        var count = validate.numberOfInvalids();
        //        validate.settings.ignore = ':hidden';
        //        toastr.error("Existen " + (count + others) + " error(es), que ameritan su atención.", "", { closeButton: true, progressBar: true });
        //    }
        //    event.preventDefault();
        //});

        //$('#guardarenviar').click(function () {
        //    var others = OtherValidations();
        //    if (app.ui.IsValid('#VisualizationsEdtForm', false) && others === 0) {
        //        app.ui.ButtonDoing('#guardarenviar');
        //        app.core.Post(app.setting.apipath + 'v1/Issue/MapfreMas',
        //            JSON.stringify(MapInputToObject()),
        //            function (data) {

        //                $('#guardarenviar').addClass('d-none');
        //                $('#Fuente_Tomador').replaceWith('<div>' + $('#Fuente_Tomador option:selected').text() + '</div>');
        //                $('#Modalidad_Pago').replaceWith('<div>' + $('#Modalidad_Pago option:selected').text() + '</div>');
        //                $('#tip_firma').replaceWith('<div>' + $('#tip_firma option:selected').text() + '</div>');
        //                $('#correoenvio').replaceWith('<div>' + $('#correoenvio').val() + '</div>');

        //                ReadOnly_End();

        //            }).always(function () {
        //                app.ui.ButtonDone('#guardarenviar');
        //            });
        //    }
        //    else {
        //        var instance = $('#VisualizationsEdtForm');
        //        var validate = instance.validate();
        //        validate.settings.ignore = '';
        //        var result = instance.valid();
        //        var count = validate.numberOfInvalids();
        //        validate.settings.ignore = ':hidden';
        //        toastr.error("Existen " + (count + others) + " error(es), que ameritan su atención.", "", { closeButton: true, progressBar: true });
        //    }
        //    event.preventDefault();
        //});

        $('#IMP_VR').change(function () {
            var value = app.ui.GetNumericValue('#IMP_VR');

            app.ui.SetNumericValue('#IMP_AUTO_CYV', value);
            app.ui.SetNumericValue('#IMP_AUTO_RAD', value);
            app.ui.SetNumericValue('#IMP_AUTO_ROB', value);

            data_changed();

            $("#VisualizationsEdtForm").validate().resetForm();
        });

        $('#generarvariacion').click(function () {
            //if (app.ui.IsValid('#VisualizationsEdtForm', false)) {

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
                    //var md = $('#messageModal').modal({ show: false });
                    //md.modal('show');

                    var md = $('#confirmation-autorization-Modal').modal({ show: false });
                    md.modal('show');
                    $('#mensaje_fracc_pago').removeClass('d-none');
                    $('#fileTableAutorization').addClass('d-none');
                    $('#fileTableBodyAuthorization').empty();
                    $('#doc_autorization_poliza').next('.custom-file-label').text('Indique el archivo a procesar...');
                    fileAuthorization = [];
                }
                else {
                    app.ui.ButtonDoing('#generarvariacion');
                    app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMas',
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

                                if (data.plandepago != null)
                                    $('#plandepagoTbl').bootstrapTable('load', data.plandepago);

                                if (data.plandepagoresumen != null) {
                                    $('#plandepagoresumenTbl').removeClass('d-none');
                                    $('#plandepagoresumenTbl').bootstrapTable('load', data.plandepagoresumen);
                                }

                                $('#generarvariacion').addClass('d-none');
                                $('#cancelarpoliza').addClass('d-none');
                                $('#authorizarct').removeClass('d-none');
                                $('#rechazarct').removeClass('d-none');
                                MCA_PROVISIONAL = "S";
                                DisabledAllControls(true);

                                if (data.coberturas != null)
                                    $('#coberturasTbl').bootstrapTable('load', data.coberturas);
                                $('#coberturasTbl').bootstrapTable('hideLoading');

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
            //}
            //else {
            //    var instance = $('#VisualizationsEdtForm');
            //    var validate = instance.validate();
            //    validate.settings.ignore = '';
            //    var result = instance.valid();
            //    var count = validate.numberOfInvalids();
            //    validate.settings.ignore = ':hidden';
            //    toastr.error("Existen " + count + " error(es), que ameritan su atención.", "", { closeButton: true, progressBar: true });
            //}
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

                            if (data.plandepagoresumen != null) {
                                $('#plandepagoresumenTbl').removeClass('d-none');
                                $('#plandepagoresumenTbl').bootstrapTable('load', data.plandepagoresumen);
                            }

                            $('#cancelarpoliza').removeClass('d-none');
                            $('#generarvariacion').removeClass('d-none');
                            $('#authorizarct').addClass('d-none');
                            $('#rechazarct').addClass('d-none');

                            MCA_PROVISIONAL = "N";
                            DisabledAllControls(false);
                            Controls_sum_enable(setupData);

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
            //event.preventDefault();
        });

        $('#cancelarpoliza').click(function () {

            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {

                var md = $('#confirmation-cancelation-Modal').modal({ show: false });
                md.modal('show');
                $('#fileTableCancelation').addClass('d-none');
                $('#fileTableBodyAuthorization').empty();
                $('#doc_cancelation_poliza').next('.custom-file-label').text('Indique el archivo a procesar...');
                fileCancelation = [];

                //app.ui.ButtonDoing('#cancelarpoliza');
                //app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMasCancelation',
                //    JSON.stringify(MapInputToObject()),
                //    function (data) {

                //        if (data.McaError === "N") {
                //            if (Array.isArray(data.Recibos) && data.Recibos.length > 0) {
                //                $('#resultvariacionTbl').bootstrapTable('load', data.Recibos);
                //                $('#resultvariacion').removeClass('d-none');

                //                let firstRecord = data.Recibos[0];
                //                NEW_NUM_SPTO = firstRecord.num_spto;
                //            }

                //            $('#cancelarpoliza').addClass('d-none');
                //            $('#generarvariacion').addClass('d-none');
                //            $('#authorizarct').addClass('d-none');
                //            $('#rechazarct').addClass('d-none');

                //            toastr.info("Se generó correctamente la cancelación", "Cancelación", { timeOut: 9000, closeButton: true, progressBar: true });
                //        }
                //        else {
                //            app.EmisionMapfreMas.custonMessageResponse(data, "Error el emitir la cancelación");
                //        }

                //    }).always(function () {
                //        app.ui.ButtonDone('#cancelarpoliza');
                //    });
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

        $('#aceptar-cancelation').click(function () {

            //processCancelation();
            cancelationPoliza();

        });

        $('#authorizarct').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                //app.ui.ButtonDoing('#authorizarct');

                var md = $('#confirmation-autorization-Modal').modal({ show: false });
                md.modal('show');
                $('#mensaje_fracc_pago').addClass('d-none');
                $('#fileTableAutorization').addClass('d-none');
                $('#fileTableBodyAuthorization').empty();
                $('#doc_autorization_poliza').next('.custom-file-label').text('Indique el archivo a procesar...');
                fileAuthorization = [];

                //var data = setupData;
                //data.Mca_Autoriza_CT = "S";
                //data.num_spto = NEW_NUM_SPTO;

                //app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMasManageAuthorizationCT',
                //    JSON.stringify(data),
                //    function (data) {
                //        if (data.McaError === "N") {
                //            $('#cancelarpoliza').removeClass('d-none');
                //            $('#generarvariacion').removeClass('d-none');
                //            $('#authorizarct').addClass('d-none');
                //            $('#rechazarct').addClass('d-none');
                //            DisabledAllControls(false);
                //            Controls_sum_enable(setupData);
                //            MCA_PROVISIONAL = "N";

                //            if (data.coberturas != null)
                //                $('#coberturasTbl').bootstrapTable('load', data.coberturas);
                //            $('#coberturasTbl').bootstrapTable('hideLoading');
                //            if (data.plandepago != null)
                //                $('#plandepagoTbl').bootstrapTable('load', data.plandepago);

                //            if (Array.isArray(data.Recibos) && data.Recibos.length > 0) {
                //                $('#resultvariacionTbl').bootstrapTable('load', data.Recibos);


                //                $('#resultvariacion').removeClass('d-none');
                //            }
                //            toastr.info("Se autorizó el CT", "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
                //        }
                //        else {
                //            app.EmisionMapfreMas.custonMessageResponse(data, "Error al autorizar el CT");
                //        }

                //    }).always(function () {
                //        app.ui.ButtonDone('#authorizarct');
                //    });
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

                            if (data.coberturas != null)
                                $('#coberturasTbl').bootstrapTable('load', data.coberturas);
                            $('#coberturasTbl').bootstrapTable('hideLoading');
                            if (data.plandepago != null)
                                $('#plandepagoTbl').bootstrapTable('load', data.plandepago);

                            if (data.plandepagoresumen != null) {
                                $('#plandepagoresumenTbl').removeClass('d-none');
                                $('#plandepagoresumenTbl').bootstrapTable('load', data.plandepagoresumen);
                            }

                            $('#cancelarpoliza').removeClass('d-none');
                            $('#generarvariacion').removeClass('d-none');
                            $('#authorizarct').addClass('d-none');
                            $('#rechazarct').addClass('d-none');
                            DisabledAllControls(false);
                            Controls_sum_enable(setupData);
                            MCA_PROVISIONAL = "N";

                            //toastr.info("Se rechazo el CT", "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
                            app.EmisionMapfreMas.custonMessageResponse(data, "Autorización");
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
                                  </tr>`
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
                                  </tr>`
                    $('#fileTableAutorization tbody').append(newRow);
                }

                this.value = '';
            }
        });

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

        $('#print').click(function (e) {
            e.preventDefault();
            app.ui.ShowSideBar({ title: 'Enviar certificado por correo', subtitle: 'Póliza #{NUM_POLIZA}', id: 9000, data: { NUM_POLIZA: setupData.num_poliza, NUM_RIESGO: 1 } })
        });

        $('input:radio[name=DomicilioVerificado]').click(function (e) {
            if (app.ui.GetRadioStringValue('DomicilioVerificado') === 'S') {
                $('#cotizar').removeClass('d-none');
            } else {
                $('#cotizar').addClass('d-none');
            }
        });

        $('#IMP_VR').change(function () {
            var value = app.ui.GetNumericValue('#IMP_VR');

            app.ui.SetNumericValue('#IMP_AUTO_CYV', value);
            app.ui.SetNumericValue('#IMP_AUTO_RAD', value);
            app.ui.SetNumericValue('#IMP_AUTO_ROB', value);


            //if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3004))
            //    app.ui.SetNumericValue('#IMP_AUTO_CYV', value);
            //else
            //    app.ui.SetNumericValue('#IMP_AUTO_CYV', 0);

            //if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3005))
            //    app.ui.SetNumericValue('#IMP_AUTO_RAD', value);
            //else
            //    app.ui.SetNumericValue('#IMP_AUTO_RAD', 0);

            //if (app.Cotizacion.Coberturas_Seleccionada(coberturas, 3006))
            //    app.ui.SetNumericValue('#IMP_AUTO_ROB', value);
            //else
            //    app.ui.SetNumericValue('#IMP_AUTO_ROB', 0);
            data_changed();

            $("#VisualizationsEdtForm").validate().resetForm();
        });

        //$('#coberturasTbl').on('all.bs.table', function (name, args) {
        //    console.log('name:', name);
        //    console.log('args:', args);
        //    console.log('table coberturas:', $('#coberturasTbl').bootstrapTable('getData'));
        //});

    }

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();

        $.validator.addMethod("ValorRequeridoSegunVechiculoPlan",
            function (value, element, params) {
                let cod_plan_auto = COD_PLAN_AUTO;
                if (cod_plan_auto == 31) {
                    return true;
                }
                else {
                    var result = (value != '0') && value;
                    return result;
                }
            }
        );

        $("#VisualizationsEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                //edad: { required: true },
                //mca_sexo: { required: true },
                //cod_mon: { required: true },
                cod_fracc_pago: { required: true },
                //fec_efec_poliza: { required: true },
                //fec_vcto_poliza: { required: true },
                //Fuente_Tomador: { required: true },
                //tip_firma: { required: true },
                //correoenvio: { email: true, required: true },
                //COD_PLAN_AUTO: { required: true },
                //cod_marca: { required: true },
                //cod_modelo: { required: true },
                //ANIO_SUB_MODELO: { required: true },
                //cod_tip_vehi: { required: true },
                //cod_uso_vehi: { required: true },
                    NUM_MATRICULA: { required: true },
                //COD_CHASSIS: { required: true },
                //DES_TIP_CILINDRAJE: { required: true },
                //VAL_PESO: { required: true },
                    //COD_COLOR: { required: true },
                //NUM_MOTOR: { required: true },
                //VAL_CAPACIDAD: { required: true },
                    IMP_VR: { required: true, Numeric: true },
                    IMP_AUTO_RC: { required: true },
                    DED_AUTO_RC: { required: true },
                    IMP_AUTO_GMO: { ValorRequeridoSegunVechiculoPlan: true },
                    IMP_AUTO_ACO: { ValorRequeridoSegunVechiculoPlan: true },
                    IMP_AUTO_CYV: { required: true, Numeric: true },
                    DED_AUTO_CYV: { required: true },
                    IMP_AUTO_RAD: { required: true, Numeric: true },
                    DED_AUTO_RAD: { required: true },
                    IMP_AUTO_ROB: { required: true, Numeric: true },
                    DED_AUTO_ROB: { required: true },
                    IMP_AUTO_EQESP: { required: true, Numeric: true },
                    DED_AUTO_EQESP: { required: true },
                //IMP_AUTO_NEUM: { required: true },
                //IMP_AUTO_MECA: { required: true },
                    IMP_AUTO_CRI: { required: true },
                    DED_AUTO_CRI: { required: true }
            },
            messages: {
                //edad: { required: 'Debe indicar el Edad' },
                //mca_sexo: { required: 'Debe indicar el Sexo' },
                //cod_mon: { required: 'Debe indicar el Moneda' },
                cod_fracc_pago: { required: 'Debe indicar el Fraccionamiento de pago' },
                //fec_efec_poliza: { required: 'Debe indicar el Inicio de vigencia' },
                //fec_vcto_poliza: { required: 'Debe indicar el Fin de vigencia' },
                //Fuente_Tomador: { required: 'Debe indicar el tomador' },
                //tip_firma: { required: 'Debe indicar el tipo de envío' },
                //correoenvio: { email: 'Debe indicar un correo electrónico valido', required: 'Debe indicar el correo para el envío' },
                //COD_PLAN_AUTO: { required: 'Debe indicar el Plan' },
                //cod_marca: { required: 'Debe indicar el Marca' },
                //cod_modelo: { required: 'Debe indicar el Modelo' },
                    NUM_MATRICULA: { required: 'Debe indicar el Número de placa' },
                //COD_CHASSIS: { required: 'Debe indicar el Número de Chasis' },
                //DES_TIP_CILINDRAJE: { required: 'Debe indicar el cilindraje del vehículo' },
                //VAL_PESO: { required: 'Debe indicar el Peso del vehículo' },
                    //COD_COLOR: { required: 'Debe indicar el Color del vehículo' },
                //NUM_MOTOR: { required: 'Debe indicar el Motor del vehículo' },
                //VAL_CAPACIDAD: { required: 'Debe indicar el Capacidad del vehículo' },
                //ANIO_SUB_MODELO: { required: 'Debe indicar el Año del vehículo' },
                //cod_tip_vehi: { required: 'Debe indicar el Clase del vehículo' },
                //cod_uso_vehi: { required: 'Debe indicar el Uso del vehículo' },
                    IMP_VR: { required: 'Debe indicar el Valor del vehículo asegurado' },
                    IMP_AUTO_RC: { required: 'Debe indicar el Responsabilidad civil' },
                    DED_AUTO_RC: { required: 'Debe indicar el Deducible responsabilidad civil' },
                    IMP_AUTO_GMO: { ValorRequeridoSegunVechiculoPlan: 'Debe indicar el Gastos médicos de ocupantes' },
                    IMP_AUTO_ACO: { ValorRequeridoSegunVechiculoPlan: 'Debe indicar el Accidentes al conductor' },
                    IMP_AUTO_CYV: { required: 'Debe indicar el Colisión y vuelco' },
                DED_AUTO_CYV: { required: 'Debe indicar el Deducible colisión y vuelco' },
                    IMP_AUTO_RAD: { required: 'Debe indicar el Riesgos adicionales' },
                DED_AUTO_RAD: { required: 'Debe indicar el Deducible riesgos adicionales' },
                    IMP_AUTO_ROB: { required: 'Debe indicar el Robo' },
                DED_AUTO_ROB: { required: 'Debe indicar el Deducible robo' },
                IMP_AUTO_EQESP: { required: 'Debe indicar el equipo especial' },
                DED_AUTO_EQESP: { required: 'Debe indicar el Deducible equipo especial' },
                //IMP_AUTO_NEUM: { required: 'Debe indicar el Garantía de neumáticos' },
                //IMP_AUTO_MECA: { required: 'Debe indicar el Avería mecánica' },
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
            rowStyle: function (value, row, index) {
                let colorFila = (value.codigo === 3016 && !value.added && MCA_PROVISIONAL === "N") ? "#FFFFFF" : "#DFFFDE";
                return {
                    css: {
                        'background-color': colorFila
                    }
                }
            },
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

                        return (result) ? '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos de la cobertura de la fila"> <i class="fa fa-close"></i> </button>' :'';
                    },
                    cellStyle: function (value, row, index) {
                        let colorFila = (row.codigo === 3016 && !row.added && MCA_PROVISIONAL === "N") ? "#FFFFFF" : "#DFFFDE";
                        return {
                            css: {
                                'white-space': 'nowrap',
                                'vertical-align': 'top',
                                'background-color': colorFila
                            }
                        }
                    }
                }
            ]
        });

        //$('#coberturasTbl').bootstrapTable('filterBy', { seleccionado: [true] });
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

    function plandepagoresumen_table_setup() {

        $('#plandepagoresumenTbl').bootstrapTable({
            uniqueId: 'plandepagoId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'tip_situacion',
                    title: 'Estado del recibo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'fec_efec_recibo',
                    title: 'Fecha desde',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'fec_vcto_recibo',
                    title: 'Fecha hasta',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'imp_neta',
                    title: 'Prima neta',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                },  {
                    field: 'imp_imptos',
                    title: 'IVA',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'imp_interes',
                    title: 'Recargo por fraccionamiento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                },
                {
                    field: 'imp_recibo',
                    title: 'Importe total',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }            ]
        });
    }

    function resultvariacion_table_setup() {

        $('#resultvariacionTbl').bootstrapTable({
            uniqueId: 'plandepagoId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'num_poliza',
                    title: 'Número de poliza',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'num_spto',
                    title: 'Nro Suplemento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'imp_recibo_spto',
                    title: 'Imp. Recibo suplemento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'num_cuota',
                    title: 'Nro Cuota',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: true
                }, {
                    field: 'num_recibo',
                    title: 'Nro Recibo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'fec_efec_recibo',
                    title: 'Fec. Efec. Recibo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'fec_vcto_recibo',
                    title: 'Fec. Efec. Recivo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'tip_situacion',
                    title: 'Tip. Situación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'cod_mon',
                    title: 'Cod. Moneda',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'imp_recibo',
                    title: 'Imp. Recibo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'imp_neta',
                    title: 'Prima Neta',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'imp_recargo',
                    title: 'Recargo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'imp_imptos',
                    title: 'Impuestos',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'imp_boni',
                    title: 'Bonificaciones',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'imp_comis',
                    title: 'Imp Comisión',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'tip_coaseguro',
                    title: 'Coaseguro',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'cod_agt',
                    title: 'Cod. Agente',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'imp_total_comis',
                    title: 'Total comisión del recibo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'imp_interes',
                    title: 'Intereses',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'imp_imptos_interes',
                    title: 'Impuesto Intereses',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'fec_vcto_pago',
                    title: 'Fecha Vcto de Pago',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DateFormatter',
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
                //coberturas[i].deducible = '';
                coberturas[i].error = '';
            }
            $('#coberturasTbl').bootstrapTable('load', coberturas);
            $('#plandepagoTbl').bootstrapTable('load', {});
            showCalculate = false;
        }
        $('#tercerosTbl-error').addClass('d-none');
        $('#documentosrequeridosTbl-error').addClass('d-none');

        //app.ui.DropDownDisabled('#IMP_AUTO_GMO', COD_PLAN_AUTO === 31);
        //app.ui.DropDownDisabled('#IMP_AUTO_ACO', COD_PLAN_AUTO === 31);
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

    function EnableControls (sumaAseguradas) {
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
        let message = 'Verifque la información de terceros';
        let terceros = $('#tercerosTbl').bootstrapTable('getData');
        let vehiculo = $('#vehiculoTbl').bootstrapTable('getData');
        let terceroserrors = (terceros.length === 0);

        //if (vehiculo.length === 0) {
        //    $('#vehiculoTbl-error').removeClass('d-none');
        //    result = result + 1;
        //}
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
            const hayDuplicados = tieneTercerosDuplicados(terceros);
            if (hayDuplicados) {
                message += ', No se puede duplicar los tipos de terceros: Tomador, Asegurado, Conductor y Pagador';
                terceroserrors = true;
            }
            else {
                terceroserrors = false;
                message = '';
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

    function tieneTercerosDuplicados(terceros) {
        const ids = new Set();
        for (const tercero of terceros) {
            if (tercero.tipodetercero !== "6") {
                if (ids.has(tercero.tipodetercero)) {
                    return true;
                } else {
                    ids.add(tercero.tipodetercero);
                }
            }

        }
        return false;
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

        $('#tercerosNew').click(function () {
            $('#tipodetercero').val($('#tipodetercero option[disabled!="disabled"]')[0].value);
            $('#tipodetercero').change();
            $('#DocumentNumberTypeMenu a.active').click();
            terceros_table_row_edit();
        });

        $('#coberturasNew').click(function () {
            //$('#tipodetercero').val($('#tipodetercero option[disabled!="disabled"]')[0].value);
            //$('#tipodetercero').change();
            //$('#DocumentNumberTypeMenu a.active').click();

            coberturas_table_row_edit();
        });

        //$('#tercerosEdtFormSave').click(function () {
        //    let TerceroLista = $('#tercerosTbl').bootstrapTable('getData');
        //    var idlist = [];
        //    for (var id in TerceroLista) {
        //        idlist.push(TerceroLista[id]["tercerosId"])
        //    }
        //    if (app.ui.IsValid('#tercerosEdtForm', false)) {
        //        app.ui.ButtonDoing('#tercerosEdtFormSave');

        //        var row = terceros_table_row('values');

        //        if (row.tercerosId === null) {
        //            if (idlist.length > 0) {
        //                var lastid = Math.max(...idlist);
        //                row.tercerosId = lastid + 1;
        //            }
        //            else {
        //                row.tercerosId = 1;
        //            }
        //        }


        //        let Rules = terceros_table_rules($('#tercerosModal').data('id'), TerceroLista, row)
        //        if (Rules.Error) {
        //            if (Rules.type == "error") {
        //                toastr.error(Rules.message, Rules.title, { timeOut: 9000, closeButton: true, progressBar: true });
        //            }
        //            else {
        //                toastr.info(Rules.message, Rules.title, { timeOut: 9000, closeButton: true, progressBar: true });
        //            }
        //            app.ui.ButtonDone('#tercerosEdtFormSave')
        //        }
        //        else {
        //            if (Rules.Event == "Update") {
        //                for (var a in Rules.Result) {
        //                    $('#tercerosTbl').bootstrapTable('updateByUniqueId', { id: Rules.Result[a].tercerosId, row: Rules.Result[a] });
        //                }

        //                if (row.eltomadoreselmismoasegurado === 1 && row.tipodetercero == 0) {
        //                    let AseguradoExiste = $('#tercerosTbl').bootstrapTable('getData').filter(i => i.DocumentNumber == row.DocumentNumber);
        //                    AseguradoExiste = AseguradoExiste.filter(i => i.tipodetercero == 2);
        //                    if (!(AseguradoExiste.length > 0)) {
        //                        let newinsurance = JSON.parse(JSON.stringify(row));
        //                        if (idlist.length > 0) {
        //                            var lastid = Math.max(...idlist);
        //                            newinsurance.tercerosId = lastid + 1;
        //                        }
        //                        else {
        //                            newinsurance.tercerosId += 1;
        //                        }
        //                        newinsurance.tipodetercero = '2';
        //                        newinsurance.tipodeterceroDesc = $('#tipodetercero option[value="2"]').text();
        //                        //$('#tercerosTbl').bootstrapTable('append', newinsurance);
        //                    }

        //                }

        //                if (row.elaseguradoeselconductorhabitual === 1) {
        //                    let ConductorExiste = $('#tercerosTbl').bootstrapTable('getData').filter(i => i.DocumentNumber == row.DocumentNumber);
        //                    ConductorExiste = ConductorExiste.filter(i => i.tipodetercero == 3);
        //                    if (!(ConductorExiste.length > 0)) {
        //                        let newDriver = JSON.parse(JSON.stringify(row));
        //                        if (idlist.length > 0) {
        //                            var lastid = Math.max(...idlist);
        //                            newDriver.tercerosId = lastid + 1;
        //                        }
        //                        else {
        //                            newDriver.tercerosId += 1;
        //                        }
        //                        newDriver.tipodetercero = '3';
        //                        newDriver.tipodeterceroDesc = $('#tipodetercero option[value="3"]').text();
        //                        //$('#tercerosTbl').bootstrapTable('append', newDriver);
        //                    }

        //                }
        //            }
        //            else if (Rules.Event == "Insert") {
        //                // $('#tercerosTbl').bootstrapTable('append', row);

        //                if (row.eltomadoreselmismoasegurado === 1 && row.tipodetercero == 0) {
        //                    let AseguradoExiste = $('#tercerosTbl').bootstrapTable('getData').filter(i => i.DocumentNumber == row.DocumentNumber);
        //                    AseguradoExiste = AseguradoExiste.filter(i => i.tipodetercero == 2);
        //                    if (!(AseguradoExiste.length > 0)) {
        //                        let newinsurance = JSON.parse(JSON.stringify(row));
        //                        newinsurance.tercerosId += 1;
        //                        newinsurance.tipodetercero = '2';
        //                        newinsurance.tipodeterceroDesc = $('#tipodetercero option[value="2"]').text();
        //                        //$('#tercerosTbl').bootstrapTable('append', newinsurance);
        //                    }
        //                    else {
        //                        let newinsurance = JSON.parse(JSON.stringify(row));
        //                        newinsurance.tercerosId = AseguradoExiste[0].tercerosId;
        //                        newinsurance.tipodetercero = AseguradoExiste[0].tipodetercero;
        //                        newinsurance.tipodeterceroDesc = AseguradoExiste[0].tipodeterceroDesc;
        //                        $('#tercerosTbl').bootstrapTable('updateByUniqueId', { id: AseguradoExiste[0].tercerosId, row: newinsurance });
        //                    }

        //                }

        //                if (row.elaseguradoeselconductorhabitual === 1) {
        //                    let ConductorExiste = $('#tercerosTbl').bootstrapTable('getData').filter(i => i.DocumentNumber == row.DocumentNumber);
        //                    ConductorExiste = ConductorExiste.filter(i => i.tipodetercero == 3);
        //                    if (!(ConductorExiste.length > 0)) {
        //                        let newDriver = JSON.parse(JSON.stringify(row));
        //                        newDriver.tercerosId += 2;
        //                        newDriver.tipodetercero = '3';
        //                        newDriver.tipodeterceroDesc = $('#tipodetercero option[value="3"]').text();
        //                        //$('#tercerosTbl').bootstrapTable('append', newDriver);
        //                    }
        //                    else {
        //                        let newDriver = JSON.parse(JSON.stringify(row));
        //                        newDriver.tercerosId = ConductorExiste[0].tercerosId;
        //                        newDriver.tipodetercero = ConductorExiste[0].tipodetercero;
        //                        newDriver.tipodeterceroDesc = ConductorExiste[0].tipodeterceroDesc;
        //                        $('#tercerosTbl').bootstrapTable('updateByUniqueId', { id: ConductorExiste[0].tercerosId, row: newDriver });
        //                    }
        //                }
        //            }
        //            if (row.tipodetercero === 2) {
        //                $('#correoenvio').val(row.correoelectronico);
        //            }
        //            app.ui.ButtonDone('#tercerosEdtFormSave')
        //            $('#tercerosModal').modal('hide');
        //            formularios_handler();

        //        }
        //    }
        //});

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

    function terceros_table_rules(Event, TercerosList, Tercero) {
        let TerceroTomador = TercerosList.filter(i => i.tipodetercero === 0)[0];
        let TerceroValida = TercerosList.filter(i => i.tipodetercero == Tercero.tipodetercero);
        let Rules = {
            Event: "",
            Error: false,
            title: null,
            message: null,
            Result: null,
        }
        if (Event != null) {
            if (TerceroTomador != undefined && TerceroTomador["tercerosId"] != Tercero.tercerosId && Tercero.tipodetercero == 0) {
                return Rules = {
                    Event: "Update",
                    Error: true,
                    title: "Alerta",
                    message: "Recordar que no pueden haber mas de dos tomadores",
                    type: "error"
                }
            }
            else if (TerceroValida.length > 0 && TerceroTomador["tercerosId"] != Tercero.tercerosId && Tercero.tipodetercero == 2) {
                return Rules = {
                    Event: "Update",
                    Error: true,
                    title: "Alerta",
                    message: "Recordar que no pueden haber mas de dos Asegurados",
                    type: "error"
                }
            }
            else if (TerceroValida.length > 0 && TerceroTomador["tercerosId"] != Tercero.tercerosId && Tercero.tipodetercero == 3) {
                return Rules = {
                    Event: "Update",
                    Error: true,
                    title: "Alerta",
                    message: "Recordar que no pueden haber mas de dos Conductores",
                    type: "error"
                }
            }
            else if (TerceroValida.length > 0 && TerceroTomador["tercerosId"] != Tercero.tercerosId && Tercero.tipodetercero == 21) {
                return Rules = {
                    Event: "Update",
                    Error: true,
                    title: "Alerta",
                    message: "Recordar que no pueden haber mas de dos Pagadores",
                    type: "error"
                }
            }
            else {
                var TercerosUpdate = []
                TercerosUpdate.push(Tercero)

                var listClon = []
                if (TercerosList.length > 0) {
                    for (var tercero in TercerosList) {
                        if (Tercero.DocumentNumberType === TercerosList[tercero]["DocumentNumberType"] && Tercero.DocumentNumber === TercerosList[tercero]["DocumentNumber"] && Tercero.tercerosId != TercerosList[tercero]["tercerosId"]) {
                            listClon.push(TercerosList[tercero])
                        }
                    }
                }

                if (listClon.length > 0) {
                    for (var Clon in listClon) {
                        if (Tercero.tipodetercero == listClon[Clon]["tipodetercero"]) {
                            $('#tercerosTbl').bootstrapTable('removeByUniqueId', listClon[Clon]["tercerosId"]);
                        }
                        else {
                            var newterc = Object.assign({}, Tercero);
                            newterc.tercerosId = listClon[Clon]["tercerosId"]
                            newterc.tipodetercero = listClon[Clon]["tipodetercero"]
                            newterc.tipodeterceroDesc = listClon[Clon]["tipodeterceroDesc"]
                            TercerosUpdate.push(newterc)
                        }
                    }
                }

                Rules.Event = "Update";
                Rules.Result = TercerosUpdate;
                return Rules;
            }
        }
        else {
            let TerceroExiste = TercerosList.filter(i => i.DocumentNumber == Tercero.DocumentNumber);
            TerceroExiste = TerceroExiste.filter(i => i.tipodetercero == Tercero.tipodetercero);
            if (TerceroTomador != undefined && Tercero.tipodetercero == 0) {
                return Rules = {
                    Event: "Insert",
                    Error: true,
                    title: "Existe 1 error",
                    message: "No pueden haber mas de dos tomadores",
                    type: "error"
                }
            }
            else if (TerceroValida.length > 0 && Tercero.tipodetercero == 2) {
                return Rules = {
                    Event: "Insert",
                    Error: true,
                    title: "Existe 1 error",
                    message: "No pueden haber mas de dos Asegurados",
                    type: "error"
                }
            }
            else if (TerceroValida.length > 0 && Tercero.tipodetercero == 3) {
                return Rules = {
                    Event: "Insert",
                    Error: true,
                    title: "Existe 1 error",
                    message: "No pueden haber mas de dos Conductores",
                    type: "error"
                }
            }
            else if (TerceroValida.length > 0 && Tercero.tipodetercero == 21) {
                return Rules = {
                    Event: "Insert",
                    Error: true,
                    title: "Existe 1 error",
                    message: "No pueden haber mas de dos Pagadores",
                    type: "error"
                }
            }
            else if (TerceroExiste.length > 0) {
                return Rules = {
                    Event: "Insert",
                    Error: true,
                    title: "El tercero ya existe",
                    message: "El tercero con cedula: " + TerceroExiste[0]["DocumentNumber"] + " y con el tipo de: " + TerceroExiste[0]["tipodeterceroDesc"] + " ya fue insertado",
                    type: "info"
                }
            }
            else {
                Rules.Event = "Insert";
                return Rules;
            }
        }
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

        app.core.LookupDependency(row.TProvincia, 'TCanton', 'Cantones', '', row.TCanton, false, null, `cod_pais=${row.cod_pais}:cod_estado=`);
        app.core.LookupDependency(row.TCanton, 'TDistrito', 'Distritos', '', row.TDistrito, false, null, `cod_pais=${row.cod_pais}:cod_prov=`);

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

    function terceros_table_row_delete(row) {
        $('#tercerosTbl').bootstrapTable('removeByUniqueId', row.tercerosId);
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
            maximumValue: '100',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#porcentaje', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '100',
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
        app.ui.DocumentNumberHandlerJDC('#DocumentNumber', terceros_documentNumberCallBack);
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





    //-------------------------------------------------------------------------Scripts vehiculoNew------------------------------------------------------------------------------
    function vehiculo_table_setup() {
        $('#vehiculoTbl').bootstrapTable({
            uniqueId: 'vehiculoId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'NUM_MATRICULA',
                    title: 'Número de placa',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'COD_CHASSIS',
                    title: 'Número de chasis',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'NUM_MOTOR',
                    title: 'Número de motor',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'DES_TIP_CILINDRAJE',
                    title: 'Cilindraje del vehículo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'VAL_PESO',
                    title: 'Peso del vehiculo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'COD_COLORDesc',
                    title: 'Color del vehiculo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'VAL_CAPACIDAD',
                    title: 'Capacidad del vehiculo',
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
                    events: 'vehiculo_Events',
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

        $('#vehiculoNew').click(function () {
            vehiculo_table_row_edit();
        });

        $('#vehiculoEdtFormSave').click(function () {
            if (app.ui.IsValid('#vehiculoEdtForm', false)) {
                app.ui.ButtonDoing('#vehiculoEdtFormSave');

                var row = vehiculo_table_row('values');

                if (row.vehiculoId === null)
                    row.vehiculoId = 1;

                if ($('#vehiculoModal').data('id') != null) {
                    $('#vehiculoTbl').bootstrapTable('updateByUniqueId', { id: row.vehiculoId, row: row });
                }
                else {
                    $('#vehiculoTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#vehiculoEdtFormSave')
                $('#vehiculoModal').modal('hide');
            }
        });

    };

    function vehiculo_table_row(mode) {
        if (mode == null) {
            return {
                vehiculoId: null,
                NUM_MATRICULA: null,
                COD_CHASSIS: null,
                NUM_MOTOR: null,
                DES_TIP_CILINDRAJE: null,
                VAL_PESO: null,
                COD_COLOR: null,
                VAL_CAPACIDAD: null,
                Vehiculo_Otra_Poliza: null
            };
        }
        else {
            return {
                vehiculoId: $('#vehiculoModal').data('id'),
                NUM_MATRICULA: $('#NUM_MATRICULA').val(),
                COD_CHASSIS: $('#COD_CHASSIS').val(),
                NUM_MOTOR: $('#NUM_MOTOR').val(),
                DES_TIP_CILINDRAJE: $('#DES_TIP_CILINDRAJE').val(),
                VAL_PESO: app.ui.GetNumericValue('#VAL_PESO'),
                COD_COLOR: app.ui.GetDropDownNumericValue('#COD_COLOR'),
                COD_COLORDesc: $('#COD_COLOR option:selected').text(),
                VAL_CAPACIDAD: app.ui.GetNumericValue('#VAL_CAPACIDAD'),
                Vehiculo_Otra_Poliza: app.ui.GetRadioStringValue('Vehiculo_Otra_Poliza')
            };
        }
    }


    function vehiculo_table_row_edit(row) {
        var md = $('#vehiculoModal').modal({ show: false });
        var formInstance = $("#vehiculoEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || vehiculo_table_row();
        md.data('id', row.vehiculoId);

        //Required
        $('#NUM_MATRICULA').val(row.NUM_MATRICULA);
        $('#COD_CHASSIS').val(row.COD_CHASSIS);
        $('#NUM_MOTOR').val(row.NUM_MOTOR);
        $('#DES_TIP_CILINDRAJE').val(row.DES_TIP_CILINDRAJE);
        $('#VAL_PESO').val(row.VAL_PESO);
        $('#COD_COLOR').val(row.COD_COLOR);
        $('#NUM_MATRICULA').val(row.NUM_MATRICULA);
        $('#VAL_CAPACIDAD').val(row.VAL_CAPACIDAD);
        $('#NUM_MATRICULA').val(row.NUM_MATRICULA);
        app.ui.SetRadioStringValue('Vehiculo_Otra_Poliza', row.Vehiculo_Otra_Poliza);


        md.modal('show');
    };

    function vehiculo_table_row_delete(row) {
        $('#vehiculoTbl').bootstrapTable('removeByUniqueId', row.vehiculoId);
    };




    function vehiculo_table_Validations() {
        app.ui.DateValidators();
        $("#vehiculoEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                NUM_MATRICULA: { required: true },
                COD_CHASSIS: { required: true },
                DES_TIP_CILINDRAJE: { required: true },
                VAL_PESO: { required: true },
                COD_COLOR: { required: true },
                NUM_MOTOR: { required: true },
                VAL_CAPACIDAD: { required: true },
            },
            messages: {
                NUM_MATRICULA: { required: 'Debe indicar el Número de placa' },
                COD_CHASSIS: { required: 'Debe indicar el Número de Chasis' },
                DES_TIP_CILINDRAJE: { required: 'Debe indicar el cilindraje del vehículo' },
                VAL_PESO: { required: 'Debe indicar el Peso del vehículo' },
                COD_COLOR: { required: 'Debe indicar el Color del vehículo' },
                NUM_MOTOR: { required: 'Debe indicar el Motor del vehículo' },
                VAL_CAPACIDAD: { required: 'Debe indicar el Capacidad del vehículo' },
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
                DDescripcion: 'Genérico'
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

    function generateVariacionFraccPago() {
        app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMas',
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

                    if (data.plandepagoresumen != null) {
                        $('#plandepagoresumenTbl').removeClass('d-none');
                        $('#plandepagoresumenTbl').bootstrapTable('load', data.plandepagoresumen);
                    }

                    $('#cancelarpoliza').removeClass('d-none');
                    $('#generarvariacion').removeClass('d-none');
                    $('#authorizarct').addClass('d-none');
                    $('#rechazarct').addClass('d-none');

                    MCA_PROVISIONAL = "N";
                    DisabledAllControls(false);
                    Controls_sum_enable(setupData);

                    setupDataFirst.cod_fracc_pago = app.ui.GetDropDownNumericValue('#cod_fracc_pago');

                    toastr.info("Se generó correctamente la variación", "Variación", { timeOut: 9000, closeButton: true, progressBar: true });
                }
                else {
                    app.EmisionMapfreMas.custonMessageResponse(data, "Error el emitir la variación");
                }
                $('#confirmation-autorization-Modal').modal('hide'); // Cerrar el popup
                $('#fileTableAutorization').addClass('d-none');
                $('#fileTableBodyAuthorization').empty();
                $('#doc_autorization_poliza').next('.custom-file-label').text('Indique el archivo a procesar...');
                fileAuthorization = [];
                app.ui.ButtonDone('#aceptar-autorization');
            }).always(function () {
                app.ui.ButtonDone('#aceptar-autorization');
            });
    }

    function authorizationCT() {
        //app.ui.ButtonDoing('#aceptar-autorization');
        var data = setupData;
        data.Mca_Autoriza_CT = "S";
        data.num_spto = NEW_NUM_SPTO;

        app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMasManageAuthorizationCT',
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

                    if (data.plandepagoresumen != null) {
                        $('#plandepagoresumenTbl').removeClass('d-none');
                        $('#plandepagoresumenTbl').bootstrapTable('load', data.plandepagoresumen);
                    }

                    if (Array.isArray(data.Recibos) && data.Recibos.length > 0) {
                        $('#resultvariacionTbl').bootstrapTable('load', data.Recibos);
                        $('#resultvariacion').removeClass('d-none');
                    }

                    //toastr.info(data.ProcessResult[0].txt_error, "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
                    app.EmisionMapfreMas.custonMessageResponse(data, "Autorización");

                    $('#confirmation-autorization-Modal').modal('hide'); // Cerrar el popup
                    $('#fileTableAutorization').addClass('d-none');
                    $('#fileTableBodyAuthorization').empty();
                    $('#doc_autorization_poliza').next('.custom-file-label').text('Indique el archivo a procesar...');
                    fileAuthorization = [];
                    app.ui.ButtonDone('#aceptar-autorization');
                }
                else {
                    app.EmisionMapfreMas.custonMessageResponse(data, "Error al autorizar el CT");
                }

            }).fail(function (jqXHR, textStatus, errorThrown) {
                app.ui.ButtonDone('#aceptar-autorization');
            }).always(function () {
                app.ui.ButtonDone('#aceptar-autorization');
            });
        //event.preventDefault();
    }

    function ValidateDocument(file) {
        var allowedExtensions = ['pdf', 'docx'];
        var index = 0;
        var result = true;
        var message = '';

        if (file.length > 0) {
            for (index = 0; index < file.length; index++) {
                if (file[index].size >= 31457280) {
                    if (message != '') {
                        message = message + ', ';
                    }
                    message = message + 'El tamaño del archivo ' + file[index].name + ' es mayor a 30mb';
                }
                const fileExtension = file[index].name.split('.').pop().toLowerCase();

                if (!allowedExtensions.includes(fileExtension)) {
                    message = message + 'El archivo ' + file[index].name + ' no tiene el formato PDF o Word (docx)';
                }
            }
        }
        else {
            message = "No ha cargado ningún archivo";
        }

        if (message != '') {
            result = false;
            toastr.error(message, "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
        }
        return result;
    }

    function validateFile(file, files, process) {
        var result = true;
        var message = '';
        var allowedExtensions = ['pdf', 'docx'];
        const fileExtension = file.name.split('.').pop().toLowerCase();

        if (!allowedExtensions.includes(fileExtension)) {
            if (message != '') {
                message = message + ', ';
            }
            message = message + 'El archivo ' + file.name + ' no tiene el formato PDF o Word (docx)';
        }

        if (file.size >= 31457280) {
            if (message != '') {
                message = message + ', ';
            }
            message = message + 'El tamaño del archivo ' + file.name + ' es mayor a 30mb';
        }

        if (files.some(f => f.name === file.name)) {
            if (message != '') {
                message = message + ', ';
            }
            message = 'El archivo ' + file.name + ' ya fue agregado';
        }

        if (message != '') {
            result = false;
            toastr.error(message, process, { timeOut: 9000, closeButton: true, progressBar: true });
        }
        return result;
    }

    function validateCancelation() {
        result = true;
        var fec_efec_cancel = app.ui.GetDateValue('#fec_efec_cancel');
        var txt_motivo = $('#txt_motivo').val();
        const date = new Date(fec_efec_cancel);
        const timestamp = date.getTime();

        if (isNaN(timestamp) || timestamp < 0) {
            toastr.error('Debe registrar la fecha de cancelación', "Cancelación", { timeOut: 9000, closeButton: true, progressBar: true });
            result = false;
        }
        if (!txt_motivo) {
            toastr.error('Debe registrar el motivo de cancelación', "Cancelación", { timeOut: 9000, closeButton: true, progressBar: true });
            result = false;
        }

        return result;
    }

    function validateAuthorization() {
        result = true;
        var fec_efec = app.ui.GetDateValue('#fec_efec');
        const date = new Date(fec_efec);
        const timestamp = date.getTime();

        if (isNaN(timestamp) || timestamp < 0) {
            toastr.error('Debe registrar la fecha de efecto', "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
            result = false;
        }

        return result;
    }

    function processAutorizationCT() {

        var index = 0;
        var arr = fileAuthorization;
        var message = '';

        if (ValidateDocument(arr)) {

            app.ui.ButtonDoing('#aceptar-autorization');
            var data = new FormData();
            data.append('EntityType', 3000);
            data.append('EntityId', setupData.num_poliza);
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
                if (data.length > 0) {
                    data.forEach(row => {
                        toastr.info("Se guardo correctamente el documento " + row.FileName, "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
                    })
                }

                if (setupDataFirst.cod_fracc_pago !== app.ui.GetDropDownNumericValue('#cod_fracc_pago')) {
                    generateVariacionFraccPago();
                }
                else {
                    authorizationCT();
                }

            }).fail(function (jqXHR, textStatus, errorThrown) {
                if (jqXHR?.responseJSON?.Message) {
                    toastr.error(jqXHR.responseJSON.Message, "Autorización", { timeOut: 9000, closeButton: true, progressBar: true });
                }
                app.ui.ButtonDone('#aceptar-autorization')
            }).always(function () {
                app.ui.ButtonDone('#aceptar-autorization')
            });
        }
        //event.preventDefault();
    }

    function processCancelation() {

        var index = 0;
        var arr = fileCancelation;
        var message = '';

        if (ValidateDocument(arr) && validateCancelation()) {

            app.ui.ButtonDoing('#aceptar-cancelation');
            var data = new FormData();
            data.append('EntityType', 3000);
            data.append('EntityId', setupData.num_poliza);
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
                if (data.length > 0) {
                    data.forEach(row => {
                        toastr.info("Se guardo correctamente el documento " + row.FileName, "Cancelación", { timeOut: 9000, closeButton: true, progressBar: true });
                    })
                }
            }).fail(function (jqXHR, textStatus, errorThrown) {
                if (jqXHR?.responseJSON?.Message) {
                    toastr.error(jqXHR.responseJSON.Message, "Cancelación", { timeOut: 9000, closeButton: true, progressBar: true });
                }
                app.ui.ButtonDone('#aceptar-cancelation')
            }).always(function () {
                app.ui.ButtonDone('#aceptar-cancelation')
            });
        }
        //event.preventDefault();
    }

    function cancelationPoliza() {
        //app.ui.ButtonDoing('#aceptar-cancelation');

        var data = setupData;
        data.fec_efec_cancel = app.ui.GetDateValue('#fec_efec_cancel');
        data.txt_motivo = $('#txt_motivo').val();

        app.core.Post(app.setting.apipath + 'v1/Variaciones/MapfreMasCancelation',
            JSON.stringify(data),
            function (data) {
                let messageSaldo = "";
                if (data.McaError === "N") {
                    processCancelation();
                    if (Array.isArray(data.Recibos) && data.Recibos.length > 0) {
                        $('#resultvariacionTbl').bootstrapTable('load', data.Recibos);
                        $('#resultvariacion').removeClass('d-none');

                        let firstRecord = data.Recibos[0];
                        NEW_NUM_SPTO = firstRecord.num_spto;

                        const suma_imp_recibo_spto = data.Recibos.reduce((acumulador, obj) => {
                            return acumulador + obj.imp_recibo_spto;
                        }, 0);

                        let saldoPositivo = Math.abs(suma_imp_recibo_spto);
                        let saldoTexto = app.EmisionMapfreMas.FormatearNumero(saldoPositivo);

                        if (saldoPositivo > 0) {
                            //messageSaldo = ` El cliente cuenta con un saldo a favor de ${saldoPositivo} por concepto de primas no devengadas`;
                            messageSaldo = " El cliente cuenta con un saldo a favor de " + saldoTexto + " por concepto de primas no devengadas";
                        }
                    }


                    if (data.coberturas != null)
                        $('#coberturasTbl').bootstrapTable('load', data.coberturas);
                    $('#coberturasTbl').bootstrapTable('hideLoading');
                    if (data.plandepago != null)
                        $('#plandepagoTbl').bootstrapTable('load', data.plandepago);

                    if (data.plandepagoresumen != null) {
                        $('#plandepagoresumenTbl').removeClass('d-none');
                        $('#plandepagoresumenTbl').bootstrapTable('load', data.plandepagoresumen);
                    }

                    $('#cancelarpoliza').addClass('d-none');
                    $('#generarvariacion').addClass('d-none');
                    $('#authorizarct').addClass('d-none');
                    $('#rechazarct').addClass('d-none');

                    //toastr.info(`La cancelación fue procesada de forma correcta.${messageSaldo}`, "Cancelación", { timeOut: 9000, closeButton: true, progressBar: true });
                    toastr.info("La cancelación fue procesada de forma correcta." + messageSaldo, "Cancelación", { timeOut: 10000, closeButton: true, progressBar: true });


                    $('#confirmation-cancelation-Modal').modal('hide'); // Cerrar el popup
                    $('#fileTableCancelation').addClass('d-none');
                    $('#fileTableBodyAuthorization').empty();
                    $('#doc_cancelation_poliza').next('.custom-file-label').text('Indique el archivo a procesar...');
                    fileCancelation = [];
                }
                else {
                    app.EmisionMapfreMas.custonMessageResponse(data, "Error el emitir la cancelación");
                }
                app.ui.ButtonDone('#aceptar-cancelation');
            }).always(function () {
                app.ui.ButtonDone('#aceptar-cancelation');
            });
    }

    function documentosrequeridos_controls_Events() {

        $('#doc_autorization_poliza').on('change', function () {
            var index = 0;
            var arr = $('#doc_autorization_poliza').prop('files');
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
                app.ui.ButtonDoing('#doc_autorization_poliza');
                var data = new FormData();
                data.append('EntityType', 3000);
                data.append('EntityId', setupData.num_poliza);
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
                    console.log("upload", data);
                    $('#DNombre').val(data[0].FileName);
                    $('#DStored').val(data[0].StoredFileName);
                    $('#DTamano').val(data[0].Size);
                    $('#DDescripcion').val(app.ui.StringCapitalizeFormatter(data[0].FileName.substring(0, data[0].FileName.indexOf('.'))));
                    $('#DDescripcion').select().focus()

                }).fail(function (jqXHR, textStatus, errorThrown) {
                    console.log("ERROR : ", jqXHR);
                }).always(function () {
                    app.ui.ButtonDone('#doc_autorization_poliza')
                });
            }
        });

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
            if (name == "#datosvariables") {
                let md = $(name + 'Modal').modal({ show: false });
                md.modal('show');
                if (formularioRow.data != null) {
                    MapObjectoinputdatosvar(formularioRow.data);
                }
            }
            else {
                let md = $(name + 'Modal').modal({ show: false });
                let ref = formularioRow.type === 'kycpersona' ? app.kycpersona : app.kycjuridico;
                md.modal('show');
                ref.SetData(formularioRow.data);
            }
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
                                                ref.AcceptCallBack(app.EmisionMapfreMas.Accept);
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
                                                ref.AcceptCallBack(app.EmisionMapfreMas.Accept);
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
            plandepagoresumen_table_setup();
            Controls_Events();

            terceros_controls_setup();
            terceros_table_setup();
            terceros_table_Validations();
            terceros_controls_Events();

            vehiculo_table_setup();
            vehiculo_table_Validations();
            documentosrequeridos_controls_setup();
            documentosrequeridos_table_setup();
            documentosrequeridos_table_Validations();

            //documentosrequeridos_controls_Events();

            formularios_table_setup();
            resultvariacion_table_setup();
            $('.mapfremas-visible').removeClass('d-none');
            Setup();
        },
        tercerosEditRow: function (row) {
            terceros_table_row_edit(row);
        },
        tercerosDeleteRow: function (row) {
            terceros_table_row_delete(row);
        },
        coberturasDeleteRow: function (row) {
            coberturas_table_row_delete(row);
        },
        documentosrequeridosEditRow: function (row) {
            documentosrequeridos_table_row_edit(row);
        },
        vehiculoEditRow: function (row) {
            vehiculo_table_row_edit(row);
        },
        vehiculoDeleteRow: function (row) {
            vehiculo_table_row_delete(row);
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
        findOrAddRecordCombobox: function (array, code, description) {
            if (!array) return;

            const record = array.find(item => item.Code == code);

            if (!record) {
                array.push({Code: code, Description: description});
            }

            return array;
        },
        custonMessageResponse: function (data, title) {
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
        },
        GetSumaAseguradaAndEnableControls: function(coberturas) {
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
            app.EmisionMapfreMas.EnableControls(listaSumasAseguradasValidas);
        },
        EnableControls: function (sumaAseguradas) {
            if (sumaAseguradas) {
                sumaAseguradas.forEach(item => {
                    switch (sumaAseguradas.cod_suma) {
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
        },
        FormatearNumero: function (numero, separadorDecimal = '.', separadorMiles = ',') {
            if (isNaN(numero)) {
                return '';
            }

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
    };
})();

window.tercerosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el tercero '" + row.nombre + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMapfreMas.tercerosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionMapfreMas.tercerosEditRow(row);
        e.stopPropagation();
        $(document).ready(function () {
            $('.col-sm-4').each(function () {
                var idI = $(this).find('input').attr('id');
                var idS = $(this).find('select').attr('id');
                var typeNum = (row.DocumentNumberType != 1 && row.DocumentNumberType != 2 && row.DocumentNumberType != 3);
                if (typeNum && (idI === 'apellido1' || idI === 'apellido2' || idI === 'fechadenacimiento' || idS === 'tercerosMca_sexo' || idS === 'estadoCivil')) {
                    $(this).addClass('d-none');
                } else if (!typeNum && (idI === 'apellido1' || idI === 'apellido2' || idI === 'fechadenacimiento' || idS === 'tercerosMca_sexo' || idS === 'estadoCivil')) {
                    $(this).removeClass('d-none');
                }
            })
        })
    }
};

window.coberturasTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar la cobertura '" + row.nombre + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMapfreMas.coberturasDeleteRow(row); } });
        e.stopPropagation();
    }
};


window.vehiculo_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.vehiculodId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMapfreMas.vehiculoDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionMapfreMas.vehiculoEditRow(row);
        e.stopPropagation();
    }
};
window.documentosrequeridosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer limpiar el documento requerido '" + row.DNombre + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMapfreMas.documentosrequeridosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionMapfreMas.documentosrequeridosEditRow(row);
        e.stopPropagation();
    }
};
window.formulariosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer limpiar la información del formulario  '" + row.name + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMapfreMas.formulariosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionMapfreMas.formulariosEditRow(row);
        e.stopPropagation();
    }
};