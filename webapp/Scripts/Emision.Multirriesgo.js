var app = app || {};

app.EmisionMultirriesgo = (function () {

    var workMode = '';
    var setupData = null;
    var showCalculate = false;
    var rowDocumentosrequeridos = null;

    function Setup() {
        var _id = app.core.URLStringValue('presupuesto');
        if (_id != '') {
            workMode = app.core.URLStringValue('mode');

            $('#coberturasTbl').bootstrapTable('showLoading');
            app.core.Get(app.setting.apipath + 'v1/Issue/MultirriesgoSetup/' + _id + '?mode=' + workMode)
                .done(function (data, textStatus, jqXHR) {
                    workMode = data.Modo;
                    if (localStorage.getItem('Roles').includes('Purdy')) {
                        $('.Purdy').removeClass('d-none');
                        $('#Fuente_Tomador').prop("disabled", (workMode != 'draft' && workMode != 'resume'));
                    }

                    if (workMode === 'draft' || workMode === 'resume') {
                        $('#guardarenviar').removeClass('d-none');
                        $("#guardarenviar").appendTo("#GenericToolBar");
                        $('.documentosrequeridosGrid').addClass('d-none');

                        $('.enviosolicitudZone').removeClass('d-none');
                        $('.Solictud_DatosVar').removeClass('d-none');
                        $('#PageSubTitle').text("Emision Solicitud de Seguro")
                    } else {
                        $('#cotizar').removeClass('d-none');
                        $("#cotizar").appendTo("#GenericToolBar");
                    }

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

    function ReadOnly_End() {
        $('#tercerosNew').addClass('d-none');
        $('#tercerosTbl').bootstrapTable('hideColumn', 'Actions');
        $('#documentosrequeridosNew').addClass('d-none');
        $('#documentosrequeridosTbl').bootstrapTable('hideColumn', 'Actions');
        $('#formulariosNew').addClass('d-none');
        $('#formulariosTbl').bootstrapTable('hideColumn', 'Actions');
    }

    function Init_Lookups(data) {
        setupData = JSON.parse(JSON.stringify(data));
        let lookupList = [
            'MonedasPorRamo.cod_mon',
            'FrecuenciaDePagoPorRamo.cod_fracc_pago',
            'Paises.cod_pais',
            'Provincias.cod_estado',
            'MM_MCA_TIP_FIRMA.tip_firma',
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
            'Paises.tercerosCod_pais', 'Provincias.TProvincia', 'Cantones.TCanton', 'Distritos.TDistrito'];
        app.core.Lookups(lookupList,
            function () {
                MapObjectToInput_First(data);
                MapObjectToInput(data);
                ReadOnly();
                $("#tercerosNew").removeClass('d-none')
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
        data.num_poliza = null
        data.Mensaje = null
        data.Error = null
        data.Errors = null
        data.anodeconstruccion = app.ui.GetNumericValue('#anodeconstruccion');
        data.terceros = $('#tercerosTbl').bootstrapTable('getData');
        data.tip_firma = $('#tip_firma').val();
        data.tip_firmaDesc = $("#tip_firma option:selected").text();
        data.correoenvio = $('#correoenvio').val();
        data.documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');
        data.kyc = null;
        let formulariosDatakyc = $('#formulariosTbl').bootstrapTable('getData');
        if (formulariosDatakyc.length > 0) {
            data.kyc = $('#formulariosTbl').bootstrapTable('getData')[0].data;
        }
        let formularioDataDV = $('#formulariosDV').bootstrapTable('getData');
        if (formularioDataDV.length > 0) {
            data.datosvariables = $('#formulariosDV').bootstrapTable('getData')[0].data;

            if (data.datosvariables == null) {
                data.datosvariables = MapInputtoObjecdatosvar();
            }
        }
        return data;
    };

    function MapObjectToInput_First(data) {

        //app.ui.SetNumericValue('#edad', data.edad);
        //$('#mca_sexo').val(data.mca_sexo);
        $('#cod_mon').val(data.cod_mon);
        $('#cod_fracc_pago').val(data.cod_fracc_pago);
        $('#tip_firma').val(data.tip_firma);

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
    }

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

        if (data.datosvariables != null) {
            let rowdv = {
                "data": data.datosvariables,
                "formularioid": 1,
                "name": "Informacion de la edificación",
                "type": "datosvariables",
                "when": new Date()

            }
            $('#formulariosDV').bootstrapTable('updateByUniqueId', { id: rowdv.formularioid, row: rowdv });
        }
        else
            $('#formulariosDV').bootstrapTable('load', {});

    };

    function TipoTercero_Filtro() {
        let terceros = $('#tercerosTbl').bootstrapTable('getData');
        let holder = terceros.filter(i => i.tipodetercero == 0);
        let insured = terceros.filter(i => i.tipodetercero == 2);
        let driver = terceros.filter(i => i.tipodetercero == 3);
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
        new AutoNumeric('#anodeconstruccion', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '9999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        //Inicio Datos Variables
        new AutoNumeric('#Area_Constru', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Dis_ZonaAcu', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Colin_Norte', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Colin_Sur', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Colin_Este', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Colin_Oeste', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        $("#Geo_Longitud").formatter({
            pattern: '{{999}}°{{999}},{{999}}',
            persistent: false
        });
        $("#Geo_Longitud").attr('placeholder', 'XXX°XXX,XXX');

        $("#Geo_Latitud").formatter({
            pattern: '{{99}}°{{99}},{{99}}',
            persistent: false
        });
        $("#Geo_Latitud").attr('placeholder', 'XX°XX,XX');

        new AutoNumeric('#Suma_Bode', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Suma_Gara', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Suma_Tapias', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Suma_Piscina', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Suma_Otros', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        //Fin Datos Variables
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

        $("#datosvarEdt :input").change(function () {
            data_changed();
        });

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

        $('#DetallesSave').click(function () {

            var anio = detalle_validations();

            if (app.ui.IsValid('#DetallesEdifi', false) && anio === 0) {
                app.ui.ButtonDoing('#DetallesSave');
                formularios_table_DetallesSetData()
                app.ui.ButtonDone('#DetallesSave');
            }
            else {
                toastr.error("Debe indicar el año de construccion", "", { closeButton: true, progressBar: true });
            }
            event.preventDefault();
        });
        $('#cotizar').click(function () {
            var others = OtherValidations();
            var detalle = detalle_validations();

            if (app.ui.IsValid('#VisualizationsEdtForm', false) && others === 0 && detalle === 0) {
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
                if (detalle === 1) {
                    toastr.error("Debe indicar el año de construccion", "", { closeButton: true, progressBar: true });
                    $('#detalleSolicitud-error').html('Debe indicar información de Datos de la Solicitud');
                }
            }
            event.preventDefault();
        });

        $('#guardarenviar').click(function () {
            var others = OtherValidations();
            var detalle = detalle_validations();

            if (app.ui.IsValid('#VisualizationsEdtForm', false) && others === 0 && detalle === 0) {
                app.ui.ButtonDoing('#guardarenviar');
                app.core.Post(app.setting.apipath + 'v1/Issue/Multirriesgo',
                    JSON.stringify(MapInputToObject()),
                    function (data) {

                        $('#guardarenviar').addClass('d-none');
                        $('#tip_firma').replaceWith('<div>' + $('#tip_firma option:selected').text() + '</div>');
                        $('#correoenvio').replaceWith('<div>' + $('#correoenvio').val() + '</div>');

                        ReadOnly_End();

                    }).always(function () {
                        app.ui.ButtonDone('#guardarenviar');
                    });
            }
            else {
                var instance = $('#VisualizationsEdtForm');
                var validate = instance.validate();
                validate.settings.ignore = '';
                var result = instance.valid();
                var count = validate.numberOfInvalids();
                validate.settings.ignore = ':hidden';
                toastr.error("Existen " + (count + others) + " error(es), que ameritan su atención.", "", { closeButton: true, progressBar: true });
                if (detalle === 1) {
                    toastr.error("Debe indicar el año de construccion", "", { closeButton: true, progressBar: true });
                    $('#detalleSolicitud-error').html('Debe indicar información de Datos de la Solicitud');
                }
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
                anodeconstruccion: { required: true, Numeric: true },
                tip_firma: { required: true },
                correoenvio: { email: true, required: true },
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
                anodeconstruccion: { required: 'Debe indicar el año de construcción', Numeric: 'Debe indicar el año de construcción' },
                tip_firma: { required: 'Debe indicar el tipo de envío' },
                correoenvio: { email: 'Debe indicar un correo electrónico valido', required: 'Debe indicar el correo para el envío' },
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
        if (app.ui.GetRadioNumericValue('ZonaAcuifera') == 1)
            $('.Distan_Ag').removeClass('d-none');
        else {
            app.ui.SetNumericValue('#Dis_ZonaAcu', 0)
            $('.Distan_Ag').addClass('d-none');
        }

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
        let message = 'Debe indicar la información de terceros';
        var terceros = $('#tercerosTbl').bootstrapTable('getData');
        var documentosrequeridos = $('#documentosrequeridosTbl').bootstrapTable('getData');
        let terceroserrors = (terceros.length === 0);

        if (!terceroserrors && (workMode === 'draft' || workMode === 'resume')) {
            let holder = terceros.filter(i => i.tipodetercero == 0);
            let insured = terceros.filter(i => i.tipodetercero == 2);
            let driver = terceros.filter(i => i.tipodetercero == 3);

            if (holder.length === 0) {
                message += ', indique el tomador';
                terceroserrors = true;
            }
            if (insured.length === 0) {
                message += ', indique el asegurado';
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
    };

    function detalle_validations() {
        var result = 0;
        var anio = app.ui.GetNumericValue('#anodeconstruccion');

        if (anio === 0) {
            result = 1;
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
            $('#tipodetercero').val($('#tipodetercero option[disabled!="disabled"]')[0].value);
            $('#tipodetercero').change();
            terceros_table_row_edit();
        });

        $('#tercerosEdtFormSave').click(function () {
            let TerceroLista = $('#tercerosTbl').bootstrapTable('getData');
            var idlist = [];
            for (var id in TerceroLista) {
                idlist.push(TerceroLista[id]["tercerosId"])
            }
            if (app.ui.IsValid('#tercerosEdtForm', false)) {
                app.ui.ButtonDoing('#tercerosEdtFormSave');

                var row = terceros_table_row('values');
                if (row.tercerosId === null) {
                    if (idlist.length > 0) {
                        var lastid = Math.max(...idlist);
                        row.tercerosId = lastid + 1;
                    }
                    else {
                        row.tercerosId = 1;
                    }
                }

                let Rules = terceros_table_rules($('#tercerosModal').data('id'), TerceroLista, row)

                if (Rules.Error) {
                    if (Rules.type == "error") {
                        toastr.error(Rules.message, Rules.title, { timeOut: 9000, closeButton: true, progressBar: true });
                    }
                    else {
                        toastr.info(Rules.message, Rules.title, { timeOut: 9000, closeButton: true, progressBar: true });
                    }
                    app.ui.ButtonDone('#tercerosEdtFormSave')
                }
                else {
                    if (Rules.Event == "Update") {
                        for (var a in Rules.Result) {
                            $('#tercerosTbl').bootstrapTable('updateByUniqueId', { id: Rules.Result[a].tercerosId, row: Rules.Result[a] });
                        }

                        if (row.tipodetercero === 2) {
                            $('#correoenvio').val(row.correoelectronico);
                        }

                        if (row.eltomadoreselmismoasegurado === 1 && row.tipodetercero == 0) {
                            let AseguradoExiste = $('#tercerosTbl').bootstrapTable('getData').filter(i => i.DocumentNumber == row.DocumentNumber);
                            AseguradoExiste = AseguradoExiste.filter(i => i.tipodetercero == 2);
                            if (!(AseguradoExiste.length > 0)) {
                                let AseguradoActual = TerceroLista.filter(i => i.tipodetercero == 2)[0]
                                let newinsurance = JSON.parse(JSON.stringify(row));
                                if (idlist.length > 0) {
                                    var lastid = Math.max(...idlist);
                                    newinsurance.tercerosId = lastid + 1;
                                }
                                else {
                                    newinsurance.tercerosId += 1;
                                }
                                newinsurance.tipodetercero = '2';
                                newinsurance.tipodeterceroDesc = $('#tipodetercero option[value="2"]').text();

                                if (AseguradoActual != undefined || AseguradoActual != null) {
                                    $('#tercerosTbl').bootstrapTable('removeByUniqueId', AseguradoActual.tercerosId);
                                    $('#tercerosTbl').bootstrapTable('append', newinsurance);
                                    toastr.info("Debido a que el tomador es el mismo asegurado se elimino al tercero asegurado con identificacion: " + AseguradoActual.DocumentNumber, "Se elimino un Tercero", { timeOut: 9000, closeButton: true, progressBar: true });
                                }
                                else {
                                    $('#tercerosTbl').bootstrapTable('append', newinsurance);
                                }
                            }

                        }
                    }
                    else if (Rules.Event == "Insert") {
                        $('#tercerosTbl').bootstrapTable('append', row);

                        if (row.eltomadoreselmismoasegurado === 1 && row.tipodetercero == 0) {
                            let AseguradoExiste = $('#tercerosTbl').bootstrapTable('getData').filter(i => i.DocumentNumber == row.DocumentNumber);
                            AseguradoExiste = AseguradoExiste.filter(i => i.tipodetercero == 2);
                            if (!(AseguradoExiste.length > 0)) {
                                let newinsurance = JSON.parse(JSON.stringify(row));
                                newinsurance.tercerosId += 1;
                                newinsurance.tipodetercero = '2';
                                newinsurance.tipodeterceroDesc = $('#tipodetercero option[value="2"]').text();
                                $('#tercerosTbl').bootstrapTable('append', newinsurance);
                            }
                            else {
                                let newinsurance = JSON.parse(JSON.stringify(row));
                                newinsurance.tercerosId = AseguradoExiste[0].tercerosId;
                                newinsurance.tipodetercero = AseguradoExiste[0].tipodetercero;
                                newinsurance.tipodeterceroDesc = AseguradoExiste[0].tipodeterceroDesc;
                                $('#tercerosTbl').bootstrapTable('updateByUniqueId', { id: AseguradoExiste[0].tercerosId, row: newinsurance });
                            }

                        }
                        if (row.tipodetercero === 2) {
                            $('#correoenvio').val(row.correoelectronico);
                        }
                    }

                    app.ui.ButtonDone('#tercerosEdtFormSave')
                    $('#tercerosModal').modal('hide');
                    formularios_handler();


                }

            }

        });

    };

    function terceros_table_rules(Event, TercerosList, Tercero) {
        let TerceroTomador = TercerosList.filter(i => i.tipodetercero === "0")[0];
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
                    title: "Existe 1 error",
                    message: "No pueden haber mas de dos tomadores",
                    type: "error"
                }
            }
            else if (TercerosList.filter(i => i.tipodetercero == 2).length > 0 && TercerosList.filter(i => i.tipodetercero == 2)[0]["tercerosId"] != Tercero.tercerosId && Tercero.tipodetercero == 2) {
                return Rules = {
                    Event: "Update",
                    Error: true,
                    title: "Existe 1 error",
                    message: "No pueden haber mas de dos Asegurados",
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
                Rules = {
                    Event: "Insert",
                    Error: true,
                    title: "Existe 1 error",
                    message: "No pueden haber mas de dos tomadores",
                    type: "error"
                }
            }
            else if (TercerosList.filter(i => i.tipodetercero == 2).length > 0 && Tercero.tipodetercero == 2) {
                Rules = {
                    Event: "Insert",
                    Error: true,
                    title: "Existe 1 error",
                    message: "No pueden haber mas de dos asegurados",
                    type: "error"
                }
            }
            else if (TerceroExiste.length > 0) {
                Rules = {
                    Event: "Insert",
                    Error: true,
                    title: "El tercero ya existe",
                    message: "El tercero con cedula: " + TerceroExiste[0]["DocumentNumber"] + " y con el tipo de: " + TerceroExiste[0]["tipodeterceroDesc"] + " ya fue insertado",
                    type: "info"
                }
            }
            else {
                Rules.Event = "Insert";
            }

            if (TerceroTomador != undefined) {
                if (TerceroTomador.eltomadoreselmismoasegurado == 1) {
                    if (TercerosList.filter(i => i.tipodetercero == 2).length == 0 && Tercero.tipodetercero == 2 && TerceroTomador["DocumentNumber"] != Tercero.DocumentNumber) {
                        Rules = {
                            Event: "Insert",
                            Error: true,
                            title: "Existe 1 error",
                            message: "No puede agregar otro asegurado que no sea " + TerceroTomador.nombre + " " + TerceroTomador.apellido1 + " " + TerceroTomador.apellido2,
                            type: "info"
                        }
                    }
                }
            }

            return Rules
        }
    }

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
                eltomadoreselmismoasegurado: 2,
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
                tercerosMca_sexo: $('#tercerosMca_sexo').val(),
                tercerosMca_sexoDesc: $('#tercerosMca_sexo option:selected').text(),
                estadoCivil: $('#estadoCivil').val(),
                estadoCivilDesc: $('#estadoCivil option:selected').text(),
                numerodetelefono: $('#numerodetelefono').val(),
                correoelectronico: $('#correoelectronico').val(),
                cod_pais: $('#tercerosCod_pais').val(),
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
        $('#tercerosCod_pais').val(row.cod_pais);
        $('#cod_pais').val(row.cod_pais);
        $('#TProvincia').val(row.TProvincia);

        app.core.LookupDependency(row.TProvincia, 'TCanton', 'Cantones', '', row.TCanton, false, null, `cod_pais=${row.cod_pais}:cod_estado=`);
        app.core.LookupDependency(row.TCanton, 'TDistrito', 'Distritos', '', row.TDistrito, false, null, `cod_pais=${row.cod_pais}:cod_prov=`);

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
                tercerosMca_sexo: { required: true },
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
                tercerosMca_sexo: { required: 'Debe indicar el Sexo' },
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
            $('#tercerosMca_sexo').val(data.Gender == 2 ? 1 : 2);
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
        app.ui.DocumentNumberHandlerJDC('#DocumentNumber', terceros_documentNumberCallBack);

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

        $('#formulariosDV').bootstrapTable({
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
                            return '<span class="label label-secondary">Opcional</span>';
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
                    title: 'Formulario',
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
                    events: 'formulariosDV_Events',
                    formatter: function (value, row, index, field) {
                        var html = [];
                        html.push('<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite agregar o editar la información de un formulario"> <i class="fa fa-pencil"></i> </button>');
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

        let row = { formularioId: 1, name: 'Información de la edificación', when: null, type: 'datosvariables', data: null };
        $('#formulariosDV').bootstrapTable('load', [row]);
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
                                            ref.AcceptCallBack(app.EmisionMultirriesgo.Accept);
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
                                            ref.AcceptCallBack(app.EmisionMultirriesgo.Accept);
                                        })
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

    function formularios_table_DetallesSetData() {
        if (formularioRow.type == 'datosvariables') {
            let name = "#" + formularioRow.type;
            var objdata = MapInputtoObjecdatosvar();
            formularioRow.data = objdata;
            formularioRow.when = new Date();
            $('#formulariosDV').bootstrapTable('updateByUniqueId', { id: formularioRow.formularioId, row: formularioRow });
            $(name + 'Modal').modal('hide');
        }
    };

    function MapInputtoObjecdatosvar() {
        var dataVar = {
            FOLIO_RGO1: $('#num_folio').val(),
            NUM_FINCA_FILIAL: $('#num_finca').val(),
            NUM_METROS_CONSTRUIDOS: app.ui.GetNumericValue('#Area_Constru'),
            DISTANCIA_MTS: app.ui.GetNumericValue('#Dis_ZonaAcu'),
            CERCA_RI_MAR_LAG_TA_CI: app.ui.GetRadioNumericValue('ZonaAcuifera'),
            COLINDANTE_NORTE: app.ui.GetNumericValue('#Colin_Norte'),
            COLINDANTE_SUR: app.ui.GetNumericValue('#Colin_Sur'),
            COLINDANTE_ESTE: app.ui.GetNumericValue('#Colin_Este'),
            COLINDANTE_OESTE: app.ui.GetNumericValue('#Colin_Oeste'),
            GEO_LONGITUD_TEXT: $('#Geo_Longitud').val(),
            Est_OestMenu: $('#Est_OestMenu').val(),
            GEO_LONGITUD: $('#Geo_Longitud').val() + $('#Est_OestMenu').val(),
            GEO_LATITUD_TEXT: $('#Geo_Latitud').val(),
            Nor_SurMenu: $('#Nor_SurMenu').val(),
            GEO_LATITUD: $('#Geo_Latitud').val() + $('#Nor_SurMenu').val(),
            MATERIAL_ESTRUCTURA: $('#Mate_Estruc').val(),
            TIP_MAMPOSTERIA: $('#Tip_Mampost').val(),
            MATERIAL_PARED_INTERNAS: $('#Mate_PardIn').val(),
            MATERIAL_TECHO: $('#Mate_Techo').val(),
            MATERIAL_ENTREPISOS: $('#Mate_EntrePiso').val(),
            MATERIAL_PISO: $('#Mate_Piso').val(),
            SOBREPESO_EXTRUCTURAS: $('#SobrePes_Estruct').val(),
            BIEN_ESQ_INTER_VEHI: $('#Intersec_Vehicula').val(),
            DANOS_PREVIOS_REPARACION: $('#Daños_Prev').val(),
            INS_ELECT_ENTUB: app.ui.GetRadioNumericValue('Insta_Elect_Entub'),
            SUMA_BODE: app.ui.GetNumericValue('#Suma_Bode'),
            SUMA_GARA: app.ui.GetNumericValue('#Suma_Gara'),
            SUMA_TAPIA: app.ui.GetNumericValue('#Suma_Tapias'),
            SUMA_PISCI: app.ui.GetNumericValue('#Suma_Piscina'),
            SUMA_OTROS: app.ui.GetNumericValue('#Suma_Otros'),
            VULNER_CONTEN: app.ui.GetRadioNumericValue('Vuln_Conten'),
        }

        return dataVar;
    }
    function MapObjectoinputdatosvar(data) {
        $('#num_folio').val(data.FOLIO_RGO1)
        $('#num_finca').val(data.NUM_FINCA_FILIAL)
        app.ui.SetNumericValue('#Area_Constru', data.NUM_METROS_CONSTRUIDOS)
        app.ui.SetNumericValue('#Dis_ZonaAcu', data.DISTANCIA_MTS)
        app.ui.SetRadioNumericValue('ZonaAcuifera', data.CERCA_RI_MAR_LAG_TA_CI);
        $("[name=ZonaAcuifera]").change();
        app.ui.SetNumericValue('#Colin_Norte', data.COLINDANTE_NORTE)
        app.ui.SetNumericValue('#Colin_Sur', data.COLINDANTE_SUR)
        app.ui.SetNumericValue('#Colin_Este', data.COLINDANTE_ESTE)
        app.ui.SetNumericValue('#Colin_Oeste', data.COLINDANTE_OESTE)

        app.ui.SetNumericValue('#Suma_Bode', data.SUMA_BODE)
        app.ui.SetNumericValue('#Suma_Gara', data.SUMA_GARA)
        app.ui.SetNumericValue('#Suma_Tapias', data.SUMA_TAPIA)
        app.ui.SetNumericValue('#Suma_Piscina', data.SUMA_PISCI)
        app.ui.SetNumericValue('#Suma_Otros', data.SUMA_OTROS)
        $('#Geo_Longitud').val(data.GEO_LONGITUD_TEXT)
        $('#Est_OestMenu').val(data.Est_OestMenu)
        $('#Geo_Latitud').val(data.GEO_LATITUD_TEXT)
        $('#Nor_SurMenu').val(data.Nor_SurMenu)
        $('#Mate_Estruc').val(data.MATERIAL_ESTRUCTURA)
        $('#Tip_Mampost').val(data.TIP_MAMPOSTERIA)
        $('#Mate_PardIn').val(data.MATERIAL_PARED_INTERNAS)
        $('#Mate_Techo').val(data.MATERIAL_TECHO)
        $('#Mate_EntrePiso').val(data.MATERIAL_ENTREPISOS)
        $('#Mate_Piso').val(data.MATERIAL_PISO)
        $('#SobrePes_Estruct').val(data.SOBREPESO_EXTRUCTURAS)
        $('#Intersec_Vehicula').val(data.BIEN_ESQ_INTER_VEHI)
        $('#Daños_Prev').val(data.DANOS_PREVIOS_REPARACION)
        app.ui.SetRadioNumericValue('Insta_Elect_Entub', data.INS_ELECT_ENTUB);
        app.ui.SetRadioNumericValue('Nor_SurMenu', data.Nor_SurMenu);
        app.ui.SetRadioNumericValue('Est_OestMenu', data.Est_OestMenu);
        app.ui.SetRadioNumericValue('Vuln_Conten', data.VULNER_CONTEN);
    }

    function formularios_handler() {
        if (formulariosMode()) {
            mainHolder = $('#tercerosTbl').bootstrapTable('getData').filter(i => i.tipodetercero === "0");
            if (mainHolder.length > 0) {

                $('.formulariosGrid').removeClass('d-none');

                let row = { formularioId: 1, name: 'Conozca a su cliente persona', when: null, type: 'kycpersona', data: null };

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
        return ((workMode === 'draft' || workMode === 'resume') && !localStorage.getItem('Roles').includes('Purdy') && !localStorage.getItem('Roles').includes('Davivienda_Prendarios') && !localStorage.getItem('Roles').includes('Davivienda_Leasing'));
    }


    return {
        Init: function () {
            Setup();
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

            formularios_table_setup();


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
        formulariosEditRow: function (row) {
            formularios_table_row_edit(row);
        },
        formulariosDeleteRow: function (row) {
            formularios_table_row_delete(row);
        },
        Accept: function (data) {
            formularios_table_kycSetData(data);
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

window.formulariosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer limpiar la información del formulario  '" + row.name + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionMultirriesgo.formulariosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionMultirriesgo.formulariosEditRow(row);
        e.stopPropagation();
    }
};

window.formulariosDV_Events = {
    'click .edit': function (e, value, row, index) {
        app.EmisionMultirriesgo.formulariosEditRow(row);
        e.stopPropagation();
    }
};