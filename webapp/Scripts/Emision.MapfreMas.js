var app = app || {};

//Aliniacion a la derecha de los combos
//select { text-align-last: right; }
//option { direction: rtl; }

app.EmisionMapfreMas = (function () {

    var setupData = null;
    var showCalculate = false;
    var rowDocumentosrequeridos = null;

    function Setup() {
        var _id = app.core.URLStringValue('presupuesto');
        if (_id != '') {
            $('#coberturasTbl').bootstrapTable('showLoading');
            app.core.Get(app.setting.apipath + 'v1/Issue/MapfreMasSetup/' + _id)
                .done(function (data, textStatus, jqXHR) {
                    Init_Lookups(data);
                });
        }
    };

    function ReadOnly() {
        $('input[name=tipo_prod').first().parent().parent().replaceWith('<div>' + $('input:radio[name=tipo_prod]:checked').next().html() + '</div>')
        $('#cod_mon').replaceWith('<div>' + $('#cod_mon option:selected').text() + '</div>');
        $('#cod_fracc_pago').replaceWith('<div>' + $('#cod_fracc_pago option:selected').text() + '</div>');
        $('#fec_efec_poliza_group').replaceWith('<div>' + $('#fec_efec_poliza').val() + '</div>');
        $('#fec_vcto_poliza_group').replaceWith('<div>' + $('#fec_vcto_poliza').val() + '</div>');
        $('#COD_PLAN_AUTO').replaceWith('<div>' + $('#COD_PLAN_AUTO option:selected').text() + '</div>');
        $('#cod_zona_circul').replaceWith('<div>' + $('#cod_zona_circul option:selected').text() + '</div>');
        $('#cod_marca').replaceWith('<div>' + $('#cod_marca option:selected').text() + '</div>');
        $('#cod_modelo').replaceWith('<div>' + $('#cod_modelo option:selected').text() + '</div>');
        $('#ANIO_SUB_MODELO').replaceWith('<div>' + $('#ANIO_SUB_MODELO').val() + '</div>');
        $('#cod_tip_vehi').replaceWith('<div>' + $('#cod_tip_vehi option:selected').text() + '</div>');
        $('#cod_uso_vehi').replaceWith('<div>' + $('#cod_uso_vehi option:selected').text() + '</div>');
        //$('#NUM_MATRICULA').replaceWith('<div>' + $('#NUM_MATRICULA').val() + '</div>');
        //$('#COD_CHASSIS').replaceWith('<div>' + $('#COD_CHASSIS').val() + '</div>');
        //$('#DES_TIP_CILINDRAJE').replaceWith('<div>' + $('#DES_TIP_CILINDRAJE').val() + '</div>');
        //$('#VAL_PESO').replaceWith('<div>' + $('#VAL_PESO').val() + '</div>');
        //$('#COD_COLOR').replaceWith('<div>' + $('#COD_COLOR option:selected').text() + '</div>');
        //$('#NUM_MOTOR').replaceWith('<div>' + $('#NUM_MOTOR').val() + '</div>');
        //$('#VAL_CAPACIDAD').replaceWith('<div>' + $('#VAL_CAPACIDAD').val() + '</div>');
        $('label[for=MCA_CERO_KM').next().replaceWith('<div>' + $('label[for=MCA_CERO_KM_' + app.ui.GetRadioNumericValue('MCA_CERO_KM') + '').html() + '</div>');
        $('label[for=MCA_AUTO_GPS').next().replaceWith('<div>' + $('label[for=MCA_AUTO_GPS_' + app.ui.GetRadioNumericValue('MCA_AUTO_GPS') + '').html() + '</div>');
        $('label[for=MCA_AUTO_GPS_CMS').next().replaceWith('<div>' + $('label[for=MCA_AUTO_GPS_CMS_' + app.ui.GetRadioNumericValue('MCA_AUTO_GPS_CMS') + '').html() + '</div>');
        $('label[for=MCA_MONITOREO_GPS').next().replaceWith('<div>' + $('label[for=MCA_MONITOREO_GPS_' + app.ui.GetRadioNumericValue('MCA_MONITOREO_GPS') + '').html() + '</div>');
        $('label[for=MCA_PRA').next().replaceWith('<div>' + $('label[for=MCA_PRA_' + app.ui.GetRadioNumericValue('MCA_PRA') + '').html() + '</div>');
        $('label[for=MCA_VR').next().replaceWith('<div>' + $('label[for=MCA_VR_' + app.ui.GetRadioNumericValue('MCA_VR') + '').html() + '</div>');
        $('#IMP_VR').replaceWith('<div>' + $('#IMP_VR').val() + '</div>');
        $('label[for=MCA_DESC_CLIENTE_NUEVO').next().replaceWith('<div>' + $('label[for=MCA_DESC_CLIENTE_NUEVO_' + app.ui.GetRadioNumericValue('MCA_DESC_CLIENTE_NUEVO') + '').html() + '</div>');
        $('#PCT_AJUSTE_GEN').parent().replaceWith('<div>' + $('#PCT_AJUSTE_GEN').val() + ' %</div>');
        $('#IMP_AUTO_RC').replaceWith('<div>' + $('#IMP_AUTO_RC option:selected').text() + '</div>');
        $('#DED_AUTO_RC').replaceWith('<div>' + $('#DED_AUTO_RC option:selected').text() + '</div>');
        $('#IMP_AUTO_GMO').replaceWith('<div>' + $('#IMP_AUTO_GMO option:selected').text() + '</div>');
        $('#IMP_AUTO_ACO').replaceWith('<div>' + $('#IMP_AUTO_ACO option:selected').text() + '</div>');
        $('#IMP_AUTO_CYV').replaceWith('<div>' + $('#IMP_AUTO_CYV').val() + '</div>');
        $('#DED_AUTO_CYV').replaceWith('<div>' + $('#DED_AUTO_CYV option:selected').text() + '</div>');
        $('#IMP_AUTO_RAD').replaceWith('<div>' + $('#IMP_AUTO_RAD').val() + '</div>');
        $('#DED_AUTO_RAD').replaceWith('<div>' + $('#DED_AUTO_RAD option:selected').text() + '</div>');
        $('#IMP_AUTO_ROB').replaceWith('<div>' + $('#IMP_AUTO_ROB').val() + '</div>');
        $('#DED_AUTO_ROB').replaceWith('<div>' + $('#DED_AUTO_ROB option:selected').text() + '</div>');
        $('#IMP_AUTO_EQESP').replaceWith('<div>' + $('#IMP_AUTO_EQESP').val() + '</div>');
        $('#DED_AUTO_EQESP').replaceWith('<div>' + $('#DED_AUTO_EQESP option:selected').text() + '</div>');
        $('#IMP_AUTO_NEUM').replaceWith('<div>' + $('#IMP_AUTO_NEUM option:selected').text() + '</div>');
        $('#IMP_AUTO_MECA').replaceWith('<div>' + $('#IMP_AUTO_MECA option:selected').text() + '</div>');
        $('#IMP_AUTO_CRI').replaceWith('<div>' + $('#IMP_AUTO_CRI option:selected').text() + '</div>');
        $('#DED_AUTO_CRI').replaceWith('<div>' + $('#DED_AUTO_CRI option:selected').text() + '</div>');
        $('#DedudAutoSust').replaceWith('<div>' + $('#DedudAutoSust option:selected').text() + '</div>');
        //$('#tercerosNew').addClass('d-none');
        //$('#tercerosTbl').bootstrapTable('hideColumn', 'Actions');
        //$('#documentosrequeridosNew').addClass('d-none');
        //$('#documentosrequeridosTbl').bootstrapTable('hideColumn', 'Actions');
    };

    function Quote() {
        app.core.Post(app.setting.apipath + 'v1/Issue/MapfreMas',
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

                    $('#tipoplan').replaceWith("<div>" + $('#tipoplan option:selected').text() + "</div>");
                    $('#otrassenas').replaceWith("<div>" + $('#otrassenas').val() + "</div>");
                    $('#numerodefolio').replaceWith("<div>" + $('#numerodefolio').val() + "</div>");
                    $('#numerodefoliomadre').replaceWith("<div>" + $('#numerodefoliomadre').val() + "</div>");
                    $('#anodeconstruccion').replaceWith("<div>" + $('#anodeconstruccion').val() + "</div>");
                    $('#alturaedificio').parent().replaceWith("<div>" + $('#alturaedificio').val() + "</div>");
                    $('#numerometrosconstruidos').parent().replaceWith("<div>" + $('#numerometrosconstruidos').val() + "</div>");
                    $('#numerodepiso').replaceWith("<div>" + $('#numerodepiso').val() + "</div>");

                    $('#tercerosTbl').bootstrapTable('hideColumn', 'Actions');
                    $('#documentosrequeridosTbl').bootstrapTable('hideColumn', 'Actions');

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
                        $('#recardoporfraccionamiento').html(data.resumen.recardoporfraccionamiento.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#cuotas').html(data.resumen.cuotas);
                        $('html,body').animate({ scrollTop: $('#quoteBlock').offset().top }, 'slow');
                    }
                }


            }).always(function () {
                app.ui.ButtonDone('#cotizar');
            });
    };

    function Init_Lookups(data) {
        setupData = JSON.parse(JSON.stringify(data));
        app.core.Lookups([
            'MM_Sexo.mca_sexo',
            'MonedasPorRamo.cod_mon',
            'FrecuenciaDePagoPorRamo.cod_fracc_pago',
            'MM_Plan.COD_PLAN_AUTO',
            'ZonaCirculacion.cod_zona_circul',
            'MM_MarcasVehiculos.cod_marca',
            'MM_ModelosVehiculos.cod_modelo',
            'MM_ClaseVehiculos.cod_tip_vehi',
            'UsoVehiculo.cod_uso_vehi',
            'MM_COD_COLOR.COD_COLOR',
            'MM_CAPITAL_RC.IMP_AUTO_RC',
            'MM_DEDU_RC.DED_AUTO_RC',
            'MM_CAPITAL_GM.IMP_AUTO_GMO',
            'MM_CAPITAL_AC.IMP_AUTO_ACO',
            'MM_DEDU_CV.DED_AUTO_CYV',
            'MM_DEDU_RA.DED_AUTO_RAD',
            'MM_DEDU_ROBO.DED_AUTO_ROB',
            'MM_DEDU_EE.DED_AUTO_EQESP',
            'MM_CAPITAL_GN.IMP_AUTO_NEUM',
            'MM_CAPITAL_AM.IMP_AUTO_MECA',
            'MM_CAPITAL_ROTCRI.IMP_AUTO_CRI',
            'MM_DEDU_ROTCRI.DED_AUTO_CRI',
            'MM_DEDU_AUTOSUS.DedudAutoSust',
            'Paises.cod_pais', 'Provincias.TProvincia'],
            function () {
                MapObjectToInput(data);
                ReadOnly();
            }, `cod_ramo=${data.cod_ramo}:cod_pais=CRI:cod_mon=${data.cod_mon}:edad=${data.edad}:plan=${data.tipo_prod}:cod_marca=${data.cod_marca}`);

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

    function MapInputToObject() {
        var data = setupData;
        data.NUM_MATRICULA = $('#NUM_MATRICULA').val();
        data.COD_CHASSIS = $('#COD_CHASSIS').val();
        data.DES_TIP_CILINDRAJE = $('#DES_TIP_CILINDRAJE').val();
        data.VAL_PESO = app.ui.GetNumericValue('#VAL_PESO');
        data.COD_COLOR = app.ui.GetDropDownNumericValue('#COD_COLOR');
        data.NUM_MOTOR = $('#NUM_MOTOR').val();
        data.VAL_CAPACIDAD = app.ui.GetNumericValue('#VAL_CAPACIDAD');
        data.terceros = $('#tercerosTbl').bootstrapTable('getData');
        data.documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');
        return data;
    };

    function MapObjectToInput(data) {
        //app.ui.SetNumericValue('#edad', data.edad);
        //$('#mca_sexo').val(data.mca_sexo);
        $('#cod_mon').val(data.cod_mon);
        $('#cod_fracc_pago').val(data.cod_fracc_pago);
        app.ui.SetDateValue('#fec_efec_poliza', data.fec_efec_poliza);
        $('#fec_vcto_poliza_group').data("DateTimePicker").minDate($('#fec_efec_poliza_group').data("DateTimePicker").date());
        app.ui.SetDateValue('#fec_vcto_poliza', data.fec_vcto_poliza);
        app.ui.SetRadioStringValue('tipo_prod', data.tipo_prod);
        $('#COD_PLAN_AUTO').val(data.COD_PLAN_AUTO);
        $('#cod_zona_circul').val(data.cod_zona_circul);
        $('#cod_marca').val(data.cod_marca);
        $('#cod_modelo').val(data.cod_modelo);
        app.ui.SetNumericValue('#ANIO_SUB_MODELO', data.ANIO_SUB_MODELO);
        $('#cod_tip_vehi').val(data.cod_tip_vehi);
        $('#cod_uso_vehi').val(data.cod_uso_vehi);
        $('#NUM_MATRICULA').val(data.NUM_MATRICULA);
        $('#COD_CHASSIS').val(data.COD_CHASSIS);
        $('#DES_TIP_CILINDRAJE').val(data.DES_TIP_CILINDRAJE);
        app.ui.SetNumericValue('#VAL_PESO', data.VAL_PESO);
        $('#COD_COLOR').val(data.COD_COLOR);
        $('#NUM_MOTOR').val(data.NUM_MOTOR);
        app.ui.SetNumericValue('#VAL_CAPACIDAD', data.VAL_CAPACIDAD);
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
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#PCT_AJUSTE_GEN', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
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
    };

    function Controls_Events() {

        $("#VisualizationsEdtForm :input").change(function () {
            data_changed();
        });

        $('#fec_efec_poliza').blur(function () {
            var minDate = app.ui.GetDateRawValue('#fec_efec_poliza');
            minDate.setDate(minDate.getDate() + 1);

            $('#fec_vcto_poliza_group').data("DateTimePicker").minDate(minDate);
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
                toastr.error("Existen " + (count + others) + " errore(s), que ameritan su atención.", "", { closeButton: true, progressBar: true });
            }
            event.preventDefault();
        });

        $('#print').click(function () {
            event.preventDefault();
            app.ui.ShowSideBar({ title: 'Enviar certificado por correo', subtitle: 'Póliza #{NUM_POLIZA}', id: 9000, data: { NUM_POLIZA: setupData.num_poliza } })
        });
    };

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
                COD_PLAN_AUTO: { required: 'Debe indicar el Plan' },
                cod_marca: { required: 'Debe indicar el Marca' },
                cod_modelo: { required: 'Debe indicar el Modelo' },
                NUM_MATRICULA: { required: 'Debe indicar el Número de placa' },
                COD_CHASSIS: { required: 'Debe indicar el Número de Chasis' },
                DES_TIP_CILINDRAJE: { required: 'Debe indicar el Cilindraje del vehículo' },
                VAL_PESO: { required: 'Debe indicar el Peso del vehiculo' },
                COD_COLOR: { required: 'Debe indicar el Color del vehiculo' },
                NUM_MOTOR: { required: 'Debe indicar el Motor del vehiculo' },
                VAL_CAPACIDAD: { required: 'Debe indicar el Capacidad del vehiculo' },
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
                IMP_AUTO_NEUM: { required: 'Debe indicar el Garantia de neumáticos' },
                IMP_AUTO_MECA: { required: 'Debe indicar el Avería mecánica' },
                IMP_AUTO_CRI: { required: 'Debe indicar el Rotura de cristales' },
                DED_AUTO_CRI: { required: 'Debe indicar el Deducible rotura de cristales' }
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
                    field: 'decucible',
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
                    field: 'recardoporfraccionamiento',
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
                coberturas[i].decucible = '';
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
                    field: 'tercerosMca_sexoDesc',
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
                    field: 'cod_pais',
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
                    field: 'Parentesco',
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
                tercerosMca_sexo: null,
                estadoCivil: null,
                numerodetelefono: null,
                correoelectronico: null,
                cod_pais: 'CRI',
                TProvincia: null,
                TCanton: null,
                TDistrito: null,
                otrasenas: null,
                eltomadoreselmismoasegurado: null,
                elaseguradoeselconductorhabitual: null,
                numerodeprestamo: null,
                importedecesion: null,
                vencimientodecesion: null,
                porcentajeacredor: null,
                Parentesco: null,
                porcentaje: null
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
                tercerosMca_sexo: $('#tercerosMca_sexo').val(),
                mca_sexoDesc: $('#tercerosMca_sexo option:selected').text(),
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
                Parentesco: $('#Parentesco').val(),
                porcentaje: app.ui.GetNumericValue('#porcentaje')
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
        $('#Parentesco').val(row.Parentesco);
        app.ui.SetNumericValue('#porcentaje', row.porcentaje);


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
                Parentesco: { required: true },
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
                Parentesco: { required: 'Debe indicar el Parentesco' },
                porcentaje: { required: 'Debe indicar el Porcentaje' },
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
        new AutoNumeric('#porcentaje', {
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
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.tercerosId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMapfreMas.tercerosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionMapfreMas.tercerosEditRow(row);
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