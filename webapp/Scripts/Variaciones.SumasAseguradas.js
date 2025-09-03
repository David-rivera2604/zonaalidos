// Componente de Sumas Aseguradas Reutilizable
var app = app || {};

app.SumasAseguradasComponent = (function () {
    let settings = {
        containerId: 'sumasaseguradas',
        onDataChange: null,
        readOnly: false,
        productCode: null,
        ramo: 0
    };

    let componentData = {
        setupData: null,
        controls: {
            AUTO_RC: false,
            AUTO_CYV: false,
            AUTO_ROB: false,
            AUTO_GMO: false,
            AUTO_ACO: false,
            AUTO_RAD: false,
            AUTO_EQESP: false,
            AUTO_CRI: false,
            AUTO_NEUM: false,
            AUTO_MECA: false
        }
    };

    function init(options) {
        settings = Object.assign(settings, options);

        if (settings.ramo == 302 || settings.ramo == 303) {
            setupControls();
            setupEvents();
            setupValidations();
        }

        if (settings.ramo == 201) {
            setupControlsHogarTotal();
            //setupEvents();
            //setupValidations();
        }

        if (settings.ramo == 202) {
            setupControlsMultirriesgo();
            //setupEvents();
            //setupValidations();
        }
    }

    function setupControlsMultirriesgo() {
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
    }
    function setupControlsHogarTotal() {

        new AutoNumeric('#mesesaampararporperdrentas', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '12',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });

        new AutoNumeric('#sAEdificio', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#sAObjetosvaliosos', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#sADomocristalmarmolgranito', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#sAGastosalquiler', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#sAPerdidaderentas', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#sAMobiliario', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
    }
    function setupControls() {
        // Configurar controles numéricos


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
    }

    function setupEvents() {
        if (settings.readOnly) return;

        // Eventos de cambio para notificar actualizaciones
        $(`#${settings.containerId} input, #${settings.containerId} select`).off('change.sumasAseguradas')
            .on('change.sumasAseguradas', function () {
                notifyDataChange();
            });
    }

    function setupValidations() {
        // Agregar método de validación personalizado
        $.validator.addMethod("ValorRequeridoSegunVechiculoPlan",
            function (value, element, params) {
                if (settings.productCode == 31) {
                    return true;
                }
                return (value != '0') && value;
            }
        );

        // Configurar reglas de validación
        let data = {}

        switch (settings.ramo) {
            case 303: data = rulesValidation303(); break;
            case 201: data = rulesValidation201(); break;
            case 202: data = rulesValidation202(); break;
        }

        return { rules: validationRules, messages: validationMessages };
    }

    function rulesValidation303(){
        const validationRules = {
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
            IMP_AUTO_CRI: { required: true },
            DED_AUTO_CRI: { required: true }
        };

        const validationMessages = {
            IMP_AUTO_RC: { required: 'Debe indicar la Responsabilidad civil' },
            DED_AUTO_RC: { required: 'Debe indicar el Deducible responsabilidad civil' },
            IMP_AUTO_GMO: { ValorRequeridoSegunVechiculoPlan: 'Debe indicar los Gastos médicos de ocupantes' },
            IMP_AUTO_ACO: { ValorRequeridoSegunVechiculoPlan: 'Debe indicar los Accidentes al conductor' },
            IMP_AUTO_CYV: { required: 'Debe indicar la Colisión y vuelco' },
            DED_AUTO_CYV: { required: 'Debe indicar el Deducible colisión y vuelco' },
            IMP_AUTO_RAD: { required: 'Debe indicar los Riesgos adicionales' },
            DED_AUTO_RAD: { required: 'Debe indicar el Deducible riesgos adicionales' },
            IMP_AUTO_ROB: { required: 'Debe indicar el Robo' },
            DED_AUTO_ROB: { required: 'Debe indicar el Deducible robo' },
            IMP_AUTO_EQESP: { required: 'Debe indicar el Equipo especial' },
            DED_AUTO_EQESP: { required: 'Debe indicar el Deducible equipo especial' },
            IMP_AUTO_CRI: { required: 'Debe indicar la Rotura de cristales' },
            DED_AUTO_CRI: { required: 'Debe indicar el Deducible rotura de cristales' }
        };

        return { rules: validationRules, messages: validationMessages };
    }

    function rulesValidation202() {
        const validationRules = {
            IMP_EDIFICIO: { required: true, Numeric: true },
            IMP_MOBILIARIO: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_MERCADERIA: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_BIE_TEM_DES: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_BIE_INT: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_OBJ_ESP_VAL: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_MAQUINARIA: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_EQUIP_ELEC: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_EQUIP_ELEC_M: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_DOMOS_TOTAL: { required: true, Numeric: true },
            IMP_GAS_ALQ: { required: true, Numeric: true },
            COB_PDR_MESES: { required: true },
            IMP_PER_REN: { required: true, Numeric: true },
            IMP_MER_TRA: { required: true, Numeric: true },
            COB_IDN_MESES: { required: true },
            IMP_INT_NEG: { required: true, Numeric: true },
            cod_tip_med_rob: { required: true },
            cod_tip_med_rdm: { required: true },
            NUM_EXTIN_INC: { required: true },
            cod_tip_rgo_idn: { required: true }
        };

        const validationMessages = {
            IMP_EDIFICIO: { required: 'Debe indicar el Edificio', Numeric: 'Debe indicar el Edificio' },
            IMP_MOBILIARIO: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_MERCADERIA: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_BIE_TEM_DES: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_BIE_INT: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_OBJ_ESP_VAL: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_MAQUINARIA: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_EQUIP_ELEC: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_EQUIP_ELEC_M: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_DOMOS_TOTAL: { required: 'Debe indicar el Rotura domo, cristales, mármol y granito', Numeric: 'Debe indicar el Rotura domo, cristales, mármol y granito' },
            IMP_GAS_ALQ: { required: 'Debe indicar el Gastos por alquiler', Numeric: 'Debe indicar el Gastos por alquiler' },
            COB_PDR_MESES: { required: 'Debe indicar el Meses a amparar' },
            IMP_PER_REN: { required: 'Debe indicar el Perdida de rentas', Numeric: 'Debe indicar el Perdida de rentas' },
            IMP_MER_TRA: { required: 'Debe indicar el Mercancía en tránsito', Numeric: 'Debe indicar el Mercancía en tránsito' },
            COB_IDN_MESES: { required: 'Debe indicar el Meses a amparar' },
            IMP_INT_NEG: { required: 'Debe indicar el Interrupción de negocios', Numeric: 'Debe indicar el Interrupción de negocios' },
            cod_tip_med_rob: { required: 'Debe indicar el Tipo de medida por robo' },
            cod_tip_med_rdm: { required: 'Debe indicar el Tipo de medida por rotura de maquinaria' },
            NUM_EXTIN_INC: { required: 'Debe indicar el Cuantos extintores de incendio' },
            cod_tip_rgo_idn: { required: 'Debe indicar el Tipo de riesgos por interrupción de negocios' },
        };

        return { rules: validationRules, messages: validationMessages };
    }

    function rulesValidation201() {
        const validationRules = {
            IMP_EDIFICIO: { required: true, Numeric: true },
            IMP_MOBILIARIO: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_MERCADERIA: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_BIE_TEM_DES: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_BIE_INT: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_OBJ_ESP_VAL: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_MAQUINARIA: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_EQUIP_ELEC: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_EQUIP_ELEC_M: { AtLeastOne: 'IMP_MOBILIARIO,IMP_MAQUINARIA,IMP_EQUIP_ELEC,IMP_EQUIP_ELEC_M,IMP_MERCADERIA,IMP_BIE_TEM_DES,IMP_BIE_INT,IMP_OBJ_ESP_VAL' },
            IMP_DOMOS_TOTAL: { required: true, Numeric: true },
            IMP_GAS_ALQ: { required: true, Numeric: true },
            COB_PDR_MESES: { required: true },
            IMP_PER_REN: { required: true, Numeric: true },
            IMP_MER_TRA: { required: true, Numeric: true },
            COB_IDN_MESES: { required: true },
            IMP_INT_NEG: { required: true, Numeric: true },
            cod_tip_med_rob: { required: true },
            cod_tip_med_rdm: { required: true },
            NUM_EXTIN_INC: { required: true }
        };

        const validationMessages = {
            IMP_EDIFICIO: { required: 'Debe indicar el Edificio', Numeric: 'Debe indicar el Edificio' },
            IMP_MOBILIARIO: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_MERCADERIA: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_BIE_TEM_DES: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_BIE_INT: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_OBJ_ESP_VAL: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_MAQUINARIA: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_EQUIP_ELEC: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_EQUIP_ELEC_M: { AtLeastOne: 'Debe indicar al menos una suma asegurada para rubros' },
            IMP_DOMOS_TOTAL: { required: 'Debe indicar el Rotura domo, cristales, mármol y granito', Numeric: 'Debe indicar el Rotura domo, cristales, mármol y granito' },
            IMP_GAS_ALQ: { required: 'Debe indicar el Gastos por alquiler', Numeric: 'Debe indicar el Gastos por alquiler' },
            COB_PDR_MESES: { required: 'Debe indicar el Meses a amparar' },
            IMP_PER_REN: { required: 'Debe indicar el Perdida de rentas', Numeric: 'Debe indicar el Perdida de rentas' },
            IMP_MER_TRA: { required: 'Debe indicar el Mercancía en tránsito', Numeric: 'Debe indicar el Mercancía en tránsito' },
            COB_IDN_MESES: { required: 'Debe indicar el Meses a amparar' },
            IMP_INT_NEG: { required: 'Debe indicar el Interrupción de negocios', Numeric: 'Debe indicar el Interrupción de negocios' },
            cod_tip_med_rob: { required: 'Debe indicar el Tipo de medida por robo' },
            cod_tip_med_rdm: { required: 'Debe indicar el Tipo de medida por rotura de maquinaria' },
            NUM_EXTIN_INC: { required: 'Debe indicar el Cuantos extintores de incendio' }
        };

        return { rules: validationRules, messages: validationMessages };
    }

    function loadLookupData(lookupData) {
        if (!lookupData) return;

        app.ui.LookupLoad('IMP_AUTO_RC', lookupData.IMP_AUTO_RC);
        app.ui.LookupLoad('DED_AUTO_RC', lookupData.DED_AUTO_RC);
        app.ui.LookupLoad('IMP_AUTO_GMO', lookupData.IMP_AUTO_GMO);
        app.ui.LookupLoad('IMP_AUTO_ACO', lookupData.IMP_AUTO_ACO);
        app.ui.LookupLoad('IMP_AUTO_NEUM', lookupData.IMP_AUTO_NEUM);
        app.ui.LookupLoad('IMP_AUTO_MECA', lookupData.IMP_AUTO_MECA);
        app.ui.LookupLoad('IMP_AUTO_CRI', lookupData.IMP_AUTO_CRI);
        app.ui.LookupLoad('DED_AUTO_CYV', lookupData.DED_AUTO_CYV);
        app.ui.LookupLoad('DED_AUTO_RAD', lookupData.DED_AUTO_RAD);
        app.ui.LookupLoad('DED_AUTO_ROB', lookupData.DED_AUTO_ROB);
        app.ui.LookupLoad('DED_AUTO_EQESP', lookupData.DED_AUTO_EQESP);
        app.ui.LookupLoad('DED_AUTO_CRI', lookupData.DED_AUTO_CRI);
    }

    function enableControls(coberturas) {
        // Resetear controles
        Object.keys(componentData.controls).forEach(key => {
            componentData.controls[key] = false;
        });

        // Habilitar controles según coberturas
        if (coberturas && componentData.setupData) {
            const listaSumasAseguradasValidas = [];

            coberturas.forEach(cobertura => {
                const sumasAsegurada = componentData.setupData.SumAseguradaRamo
                    .filter(item => item.cod_cob === cobertura.codigo)
                    .map(item => item.cod_campo);

                sumasAsegurada.forEach(sumaAseg => {
                    listaSumasAseguradasValidas.push({
                        cod_cob: cobertura.codigo,
                        cod_suma: sumaAseg
                    });
                });
            });

            // Aplicar habilitaciones
            listaSumasAseguradasValidas.forEach(item => {
                switch (item.cod_suma) {
                    case "IMP_AUTO_RC":
                        componentData.controls.AUTO_RC = true;
                        break;
                    case "IMP_AUTO_CYV":
                        componentData.controls.AUTO_CYV = true;
                        break;
                    case "IMP_AUTO_ROB":
                        componentData.controls.AUTO_ROB = true;
                        break;
                    case "IMP_AUTO_GMO":
                        componentData.controls.AUTO_GMO = true;
                        break;
                    case "IMP_AUTO_ACO":
                        componentData.controls.AUTO_ACO = true;
                        break;
                    case "IMP_AUTO_RAD":
                        componentData.controls.AUTO_RAD = true;
                        break;
                    case "IMP_AUTO_EQESP":
                        componentData.controls.AUTO_EQESP = true;
                        break;
                    case "IMP_AUTO_CRI":
                        componentData.controls.AUTO_CRI = true;
                        break;
                    case "IMP_AUTO_NEUM":
                        componentData.controls.AUTO_NEUM = true;
                        break;
                    case "IMP_AUTO_MECA":
                        componentData.controls.AUTO_MECA = true;
                        break;
                }
            });
        }

        applyControlStates();
    }

    function applyControlStates() {
        const isReadOnly = settings.readOnly;
        const productCode = settings.productCode;

        // Aplicar estados de controles
        $('#IMP_AUTO_RC').prop('disabled', isReadOnly || !componentData.controls.AUTO_RC);
        $('#DED_AUTO_RC').prop('disabled', isReadOnly || !componentData.controls.AUTO_RC);

        $('#IMP_AUTO_CYV').prop('disabled', true); // Siempre deshabilitado según reglas del ramo 302
        $('#DED_AUTO_CYV').prop('disabled', isReadOnly || !componentData.controls.AUTO_CYV);

        $('#IMP_AUTO_ROB').prop('disabled', true); // Siempre deshabilitado según reglas del ramo 302
        $('#DED_AUTO_ROB').prop('disabled', isReadOnly || !componentData.controls.AUTO_ROB);

        if (productCode === 31) {
            $('#IMP_AUTO_GMO').prop('disabled', true);
            $('#IMP_AUTO_ACO').prop('disabled', true);
        } else {
            $('#IMP_AUTO_GMO').prop('disabled', isReadOnly || !componentData.controls.AUTO_GMO);
            $('#IMP_AUTO_ACO').prop('disabled', isReadOnly || !componentData.controls.AUTO_ACO);
        }

        $('#IMP_AUTO_RAD').prop('disabled', true); // Siempre deshabilitado según reglas del ramo 302
        $('#DED_AUTO_RAD').prop('disabled', isReadOnly || !componentData.controls.AUTO_RAD);

        $('#IMP_AUTO_EQESP').prop('disabled', isReadOnly || !componentData.controls.AUTO_EQESP);
        $('#DED_AUTO_EQESP').prop('disabled', isReadOnly || !componentData.controls.AUTO_EQESP);

        $('#IMP_AUTO_CRI').prop('disabled', isReadOnly || !componentData.controls.AUTO_CRI);
        $('#DED_AUTO_CRI').prop('disabled', isReadOnly || !componentData.controls.AUTO_CRI);

        $('#IMP_AUTO_NEUM').prop('disabled', isReadOnly || !componentData.controls.AUTO_NEUM);
        $('#IMP_AUTO_MECA').prop('disabled', isReadOnly || !componentData.controls.AUTO_MECA);

        // Limpiar valores si el control está deshabilitado
        if (!componentData.controls.AUTO_CRI) {
            $('#DED_AUTO_CRI').val("0");
        }
    }

    function notifyDataChange() {
        if (settings.onDataChange && typeof settings.onDataChange === 'function') {
            const data = getData();
            settings.onDataChange(data);
        }
    }

    function getData() {
        return {
            sAEdificio: app.ui.GetNumericValue('#sAEdificio'),
            sAObjetosvaliosos: app.ui.GetNumericValue('#sAObjetosvaliosos'),
            sADomocristalmarmolgranito: app.ui.GetNumericValue('#sADomocristalmarmolgranito'),
            sAGastosalquiler: app.ui.GetNumericValue('#sAGastosalquiler'),
            sAPerdidaderentas: app.ui.GetNumericValue('#sAPerdidaderentas'),
            sARespcivil: app.ui.GetDropDownNumericValue('#sARespcivil'),
            sAMobiliario: app.ui.GetNumericValue('#sAMobiliario'),
            mesesaampararporperdrentas: app.ui.GetNumericValue('#mesesaampararporperdrentas')
        };
    }

    function getData202() {

        return {
            IMP_EDIFICIO: app.ui.GetNumericValue('#IMP_EDIFICIO'),
            IMP_MOBILIARIO: app.ui.GetNumericValue('#IMP_MOBILIARIO'),
            IMP_MERCADERIA: app.ui.GetNumericValue('#IMP_MERCADERIA'),
            IMP_BIE_TEM_DES: app.ui.GetNumericValue('#IMP_BIE_TEM_DES'),
            IMP_BIE_INT: app.ui.GetNumericValue('#IMP_BIE_INT'),
            IMP_OBJ_ESP_VAL: app.ui.GetNumericValue('#IMP_OBJ_ESP_VAL'),
            IMP_MAQUINARIA: app.ui.GetNumericValue('#IMP_MAQUINARIA'),
            IMP_EQUIP_ELEC: app.ui.GetNumericValue('#IMP_EQUIP_ELEC'),
            IMP_EQUIP_ELEC_M: app.ui.GetNumericValue('#IMP_EQUIP_ELEC_M'),
            IMP_DOMOS_TOTAL: app.ui.GetNumericValue('#IMP_DOMOS_TOTAL'),
            IMP_GAS_ALQ: app.ui.GetNumericValue('#IMP_GAS_ALQ'),
            COB_PDR_MESES: app.ui.GetNumericValue('#COB_PDR_MESES'),
            IMP_PER_REN: app.ui.GetNumericValue('#IMP_PER_REN'),
            IMP_MER_TRA: app.ui.GetNumericValue('#IMP_MER_TRA'),
            COB_IDN_MESES: app.ui.GetNumericValue('#COB_IDN_MESES'),
            IMP_INT_NEG: app.ui.GetNumericValue('#IMP_INT_NEG'),
            cod_tip_med_rob: GetDropDownMultipleStringValue('#cod_tip_med_rob'),
            cod_tip_med_rdm: GetDropDownMultipleStringValue('#cod_tip_med_rdm'),
            MCA_EXTIN_INC: app.ui.GetRadioNumericValue('MCA_EXTIN_INC'),
            NUM_EXTIN_INC: app.ui.GetNumericValue('#NUM_EXTIN_INC'),
            cod_tip_med_inc: GetDropDownMultipleStringValue('#cod_tip_med_inc'),
            cod_tip_rgo_idn: app.ui.GetDropDownNumericValue('#cod_tip_rgo_idn'),
        };
    }

    function SetDropDownMultipleValue(selector, value) {
        if (value) {
            $(selector).val(value.split(",")).trigger("change");
        }
        else {
            $(selector).val(-1);
        }
    }

    function GetDropDownMultipleStringValue(selector) {

        if ($(selector).val()) {
            return $(selector).val().join(",");
        }

        return "";
    }

    // API Pública
    return {
        init: init,
        loadData: function (data) {
            if (!data) return;

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
        },
        loadData201: function (data) {
            if (!data) return;

            app.ui.SetNumericValue('#sAEdificio', data.sAEdificio);
            app.ui.SetNumericValue('#sAObjetosvaliosos', data.sAObjetosvaliosos);
            app.ui.SetNumericValue('#sADomocristalmarmolgranito', data.sADomocristalmarmolgranito);
            app.ui.SetNumericValue('#sAGastosalquiler', data.sAGastosalquiler);
            app.ui.SetNumericValue('#sAPerdidaderentas', data.sAPerdidaderentas);
            $('#sARespcivil').val(data.sARespcivil);
            app.ui.SetNumericValue('#sAMobiliario', data.sAMobiliario);
            SetDropDownMultipleValue('#medidasdeseguridad', data.medidasdeseguridad);

        },
        loadData202: function (data) {
            if (!data) return;


            app.ui.SetNumericValue('#IMP_EDIFICIO', data.IMP_EDIFICIO);
            SetDropDownMultipleValue('#cod_tip_med_rob', data.cod_tip_med_rob);
            app.ui.SetNumericValue('#IMP_DOMOS_TOTAL', data.IMP_DOMOS_TOTAL);
            app.ui.SetNumericValue('#IMP_GAS_ALQ', data.IMP_GAS_ALQ);
            app.ui.SetNumericValue('#IMP_PER_REN', data.IMP_PER_REN);
            app.ui.SetNumericValue('#COB_PDR_MESES', data.COB_PDR_MESES);
            app.ui.SetNumericValue('#IMP_MER_TRA', data.IMP_MER_TRA);
            SetDropDownMultipleValue('#cod_tip_med_rdm', data.cod_tip_med_rdm);
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
            SetDropDownMultipleValue('#cod_tip_med_inc', data.cod_tip_med_inc);
            app.ui.SetRadioNumericValue('MCA_EXTIN_INC', data.MCA_EXTIN_INC);
            app.ui.SetNumericValue('#NUM_EXTIN_INC', data.NUM_EXTIN_INC);

        },
        loadLookups: loadLookupData,
        enableControlsByCoverages: enableControls,
        setSetupData: function (setupData) {
            componentData.setupData = setupData;
        },
        setProductCode: function (productCode) {
            settings.productCode = productCode;
            applyControlStates();
        },
        setReadOnly: function (readOnly) {
            settings.readOnly = readOnly;
            applyControlStates();
        },
        getData: getData,
        getData202: getData202,
        getValidationRules: setupValidations,
        destroy: function () {
            $(`#${settings.containerId} input, #${settings.containerId} select`).off('change.sumasAseguradas');
        }
    };
})();