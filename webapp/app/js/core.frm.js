var app = app || {};
app.frm = (() => {

    const getTableLanguageConfig = () => {
        if (!app.language || typeof app.language.getBootstrapTableTranslations !== 'function') {
            return {};
        }

        return app.language.getBootstrapTableTranslations() || {};
    };

    const Validations_Setup = (formSelector, elements) => {

        // Construir reglas y mensajes dinámicamente desde elements
        const validationRules = {};
        const validationMessages = {};

        Object.keys(elements).forEach(fieldName => {
            const field = elements[fieldName];

            // Si el campo tiene reglas definidas
            if (field.rules && field.rules.length > 0) {
                validationRules[fieldName] = {};
                validationMessages[fieldName] = {};

                field.rules.forEach(rule => {
                    // Mapear el tipo de regla al formato de jQuery Validate
                    if (rule.type === 'required') {
                        validationRules[fieldName].required = true;
                        validationMessages[fieldName].required = rule.message;
                    } else if (rule.type === 'email') {
                        validationRules[fieldName].email = true;
                        validationMessages[fieldName].email = rule.message;
                    } else {
                        // Para otros tipos de validación personalizada
                        validationRules[fieldName][rule.type] = true;
                        validationMessages[fieldName][rule.type] = rule.message;
                    }
                });
            }
        });

        // Solo aplicar validaciones si hay al menos una regla definida
        if (Object.keys(validationRules).length > 0) {
            // Verificar si hay al menos un campo de tipo fecha
            const hasDateFields = Object.values(elements).some(field => field.type === 'date');
            if (hasDateFields) {
                app.ui.DateValidators();
            }

            $(formSelector).validate({
                errorPlacement: app.ui.ErrorPlacement,
                rules: validationRules,
                messages: validationMessages
            });
        }
    };

    function ElementReference(fieldName, type) {
        let selector = `#${fieldName}`;

        if (type.startsWith('radio')) {
            selector = `input:radio[name=${fieldName}]`;
        }
        return $(selector);
    }

    return {
        PhoneNumberWidget: function (selector) {
            return $(selector).formatter({
                pattern: '{{9999}}-{{9999}}',
                persistent: false
            });
        },
        DocumentNumberWidget: function (selector) {
            return $(selector).formatter({
                pattern: '0{{9}}-{{9999}}-{{9999}}',
                persistent: false
            });
        },
        DateWidget: function (selector, options) {
            let conf = {
                format: 'DD/MM/YYYY',
                locale: 'es',
                minDate: moment('1900-01-01')
            };
            const settings = { ...conf, ...options };
            return $(selector + '_group').datetimepicker(settings);
        },
        NumericWidget: function (selector, options) {

            if (options ==  undefined) {
                options = {};
            }

            if (options.options == null) {
                options.options = '';
            }
            if (options.minimumValue == null) {
                options.minimumValue = '0';
            }
            if (options.maximumValue == null) {
                options.maximumValue = '99999999999999';
            }
            if (options.decimalPlaces == null) {
                options.decimalPlaces = '0';
            }

            let _minimumValue = options.minimumValue;
            let _maximumValue = options.maximumValue;
            let _decimalPlaces = options.decimalPlaces;

            options.options = ',' + options.options.toLowerCase() + ',';
            if (options.options.includes(',allownegative,') && _minimumValue === '0') {
                _minimumValue = '-99999999999999999';
            }
            if (options.options.includes(',integer,') && minimumValue === '0') {
                _decimalPlaces = '0';
            }

            let settings = {
                decimalCharacter: ',',
                decimalCharacterAlternative: '.',
                digitGroupSeparator: '.',
                minimumValue: _minimumValue,
                maximumValue: _maximumValue,
                decimalPlaces: _decimalPlaces,
                emptyInputBehavior: 'null'
            };
            return new AutoNumeric(selector, settings);
        },
        IdentificationWidget: function (selector) {
            return $(selector).formatter({ pattern: '0{{9}}-{{9999}}-{{9999}}', persistent: false });
        },
        PhoneWidget: function (selector) {
            return $(selector).formatter({ pattern: '{{9999}}-{{9999}}', persistent: false });
        },
        SelectWidget: function (selector) {
            return $(selector).select2({ width: '100%', theme: 'bootstrap4' });
        },
        TableWidget: function (selector, options, estilo = null) {
            const conf = {
                uniqueId: 'Id',
                classes: 'table table-bordered table-hover table-index',
                pagination: true,
                smartDisplay: true,
                showColumns: false,
                icons: {
                    paginationSwitchDown: 'fa-caret-square-o-down',
                    paginationSwitchUp: 'fa-caret-square-o-up',
                    refresh: 'fa-refresh',
                    toggleOff: 'fa-toggle-off',
                    toggleOn: 'fa-toggle-on',
                    columns: 'fa-th-list',
                    fullscreen: 'fa-arrows-alt',
                    detailOpen: 'fa-angle-double-right',
                    detailClose: 'fa-angle-double-down',
                    export: 'fa-download'
                }
            };
            const languageConfig = getTableLanguageConfig();
            const fullconfig = { ...conf, ...languageConfig, ...options };
            if (typeof selector === 'string') {
                $(selector).bootstrapTable(fullconfig);
            } else {
                selector.bootstrapTable(fullconfig);
            }
        },
        IntegerColumnWidget: function (field, title, titleTooltip = '', visible = true) {
            return {
                field: field,
                title: title,
                titleTooltip: titleTooltip,
                sortable: true,
                halign: 'center',
                align: 'right',
                formatter: 'app.ui.IntegerFormatter',
                visible: visible
            };
        },
        StringColumnWidget: function (field, title, titleTooltip = '', options) {
            const conf = {
                field: field,
                title: title,
                titleTooltip: titleTooltip,
                sortable: true,
                halign: 'center',
                align: 'left',
                formatter: 'app.ui.StringFormatter'
            };
            const fullconfig = { ...conf, ...options };
            return fullconfig;
        },
        UpdateDateAndUserColumnWidget: function (field) {
            return {
                field: field,
                title: 'Realizado por',
                class: 'd-none d-sm-table-cell',
                sortable: true,
                halign: 'center',
                width: 15,
                widthUnit: '%',
                formatter: 'app.ui.UpdateDateAndUserFormatter'
            }
        },
        ActionsColumnWidget: function (titleTooltip, events) {
            return {
                title: 'Acciones',
                class: 'd-none d-sm-table-cell',
                titleTooltip: titleTooltip,
                sortable: false,
                halign: 'center',
                align: 'center',
                width: 10,
                widthUnit: "%",
                events: events,
                formatter: function (value, row, index, field) {
                    return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del process spec step de la fila"> <i class="fa fa-pencil"></i> </button>' +
                        '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del process spec step de la fila"> <i class="fa fa-close"></i> </button>';
                },
                cellStyle: function (value, row, index) {
                    return {
                        css: {
                            'white-space': 'nowrap',
                            'vertical-align': 'top'
                        }
                    }
                }
            };
        },
        ValidateWidget: function (selector, options) {
            const conf = {
                errorPlacement: function (error, element) {
                    var name = $(element).attr("name");
                    var $obj = $("#" + name + "_validate");
                    if ($obj.length) {
                        error.appendTo($obj);
                    }
                    else {
                        error.insertAfter(element);
                    }
                }
            };
            const rules = options.rules.reduce((acc, item) => {
                const fieldName = item.field;
                const ruleType = item.type; // e.g., 'required'
                const messageText = item.message;

                // 1. Construir el objeto 'rules'
                // acc.rules es el objeto acumulador para las reglas
                acc.rules[fieldName] = {
                    ...acc.rules[fieldName], // Mantener reglas existentes (si las hay)
                    [ruleType]: true         // Agregar la nueva regla (e.g., required: true)
                };

                // 2. Construir el objeto 'messages'
                // acc.messages es el objeto acumulador para los mensajes
                acc.messages[fieldName] = {
                    ...acc.messages[fieldName], // Mantener mensajes existentes
                    [ruleType]: messageText     // Agregar el nuevo mensaje
                };

                return acc;
            }, {
                // Objeto inicial (el valor inicial del acumulador 'acc')
                rules: {},
                messages: {}
            });

            const fullconfig = { ...conf, ...rules };
            if (options.DateValidators) {
                app.ui.DateValidators();
            }
            $(selector).validate(fullconfig);
        },
        ObjectToDataEntry: async function (elementsConfig, data) {
            for (const [fieldName, configObject] of Object.entries(elementsConfig)) {

                const dataType = configObject.type;
                let $element = configObject.element;
                let $change = configObject.change || false;
                let value;

                if ((!$element || $element.length === 0) && !dataType.startsWith('radio')) {
                    console.warn(`Elemento no encontrado para el campo: ${fieldName}.`);
                    continue;
                }

                switch (dataType) {
                    case 'documentnumbertype':
                        app.ui.SetDocumentTypeValue(`#${$element[0].id}`, data[fieldName]);
                        break;
                    case 'documentnumber':
                        $(`#${$element[0].id}`).val(data[fieldName]);
                        break;
                    case 'date':
                        value = app.ui.SetDateValue(`#${$element[0].id}`, data[fieldName]);
                        break;
                    case 'numeric':
                        value = app.ui.SetNumericValue(`#${$element[0].id}`, data[fieldName]);
                        break;
                    case 'dropdownnumeric':
                        value = app.ui.SetDropDownNumericValue(`#${$element[0].id}`, data[fieldName]);
                        break;
                    case 'dropdownstring':
                        value = app.ui.SetDropDownStringValue(`#${$element[0].id}`, data[fieldName]);
                        break;
                    case 'dropdownmulti':
                        app.ui.SetDropDownMultiValues(fieldName, data[fieldName]);
                        break;

                    case 'radioboolean':
                    case 'radionumeric':
                        if (!$element || $element.length === 0) {
                            $element = $(`input:radio[name=${fieldName}]:checked`);
                            configObject.element = $element;
                        }
                        app.ui.SetRadioNumericValue(fieldName, data[fieldName]);
                        break;
                    case 'hiddennumeric':
                        $element.val(data[fieldName]);
                        break;
                    case 'string':
                    case 'phone':
                    case 'email':
                    case 'typeahead':
                        $element.val(data[fieldName]);
                        break;
                    default:
                        throw new Error(`El tipo "${dataType}" no esta implementado`)
                        break;
                }
                if ($change) {
                    $element.change();
                }
            }
        },
        DataEntryToObject: function (elementsConfig) {
            const formData = {};

            for (const [fieldName, configObject] of Object.entries(elementsConfig)) {
                const dataType = configObject.type;

                if (configObject.element == undefined) {
                    configObject.element = ElementReference(fieldName, dataType);
                }

                let $element = configObject.element;
                let value;
                let desc = null;

                if ((!$element || $element.length === 0) && !dataType.startsWith('radio')) {
                    console.warn(`Elemento no encontrado para el campo: ${fieldName}. Se asigna null.`);
                    formData[fieldName] = null;
                    continue;
                }

                switch (dataType) {
                    case 'documentnumbertype':
                        value = $(`#${$element[0].id}`).data("value");
                        break;
                    case 'documentnumber':
                        value = $(`#${$element[0].id}`).val();
                        break;
                    case 'date':
                        value = app.ui.GetDateValue(`#${$element[0].id}`)
                        break;
                    case 'numeric':
                        value = app.ui.GetNumericValue(`#${$element[0].id}`);
                        break;
                    case 'dropdownnumeric':
                        value = app.ui.GetDropDownNumericValue(`#${$element[0].id}`);
                        desc = app.ui.GetDropDownSelectedText(`#${$element[0].id}`);
                        break;
                    case 'dropdownstring':
                        value = app.ui.GetDropDownStringValue(`#${$element[0].id}`);
                        desc = app.ui.GetDropDownSelectedText(`#${$element[0].id}`);
                        break;

                    case 'dropdownmulti':
                        value = app.ui.GetDropDownMultiValues(fieldName);
                        break;

                    case 'radioboolean':
                    case 'radionumeric':
                        if (!$element || $element.length === 0) {
                            $element = $(`input:radio[name=${fieldName}]`);
                            configObject.element = $element;
                        }
                        if (dataType === 'radionumeric') {
                            value = app.ui.GetRadioNumericValue(fieldName);
                        } else {
                            value = $element.filter(':checked').val() == 'true';
                        }
                        break;
                    case 'hiddennumeric':
                        value = parseInt(0 + $element.val(), 10) || null;
                        break;
                    case 'string':
                    case 'phone':
                    case 'email':
                    case 'typeahead':
                    case 'password':
                        value = $element.val();
                        break;
                    default:
                        throw new Error(`El tipo ${dataType}" no esta implementado`)
                        break;
                }
                formData[fieldName] = value;
                if (desc != null) {
                    formData[fieldName + 'Desc'] = desc;
                }
            }

            return formData;
        },
        Empty_Object: function (elementsConfig) {
            const formData = {};

            for (const [fieldName, configObject] of Object.entries(elementsConfig)) {

                const dataType = configObject.type;
                let $element = configObject.element;
                let defaultValue = configObject.default || null;
                let value = null;

                if ((!$element || $element.length === 0) && !dataType.startsWith('radio')) {
                    console.warn(`Elemento no encontrado para el campo: ${fieldName}. Se asigna null.`);
                    formData[fieldName] = null;
                    continue;
                }

                switch (dataType) {
                    case 'documentnumbertype':
                        value = 0;
                        break;
                    case 'documentnumber':
                        value = null;
                        break;
                    case 'date':
                        value = null;
                        break;
                    case 'numeric':
                        value = null;
                        break;
                    case 'dropdownnumeric':
                        value = null;
                        break;
                    case 'dropdownstring':
                        value = defaultValue;
                        break;

                    case 'dropdownmulti':
                        value = null;
                        break;

                    case 'radioboolean':
                    case 'radionumeric':
                        value = defaultValue;
                        break;
                    case 'hiddennumeric':
                        value = null;
                        break;
                    case 'string':
                    case 'phone':
                    case 'email':
                    case 'typeahead':
                    case 'password':
                        value = null;
                        break;
                    default:
                        throw new Error(`El tipo ${dataType}" no esta implementado`)
                        break;
                }
                formData[fieldName] = value;
            }

            return formData;
        },
        InitDataEntry: async function (elementsConfig, formSelector) {
            for (const [fieldName, configObject] of Object.entries(elementsConfig)) {
                const dataType = configObject.type;
                let selector = `#${fieldName}`;

                switch (configObject.type) {
                    case 'numeric':
                        app.frm.NumericWidget(`#${fieldName}`, configObject.settings);
                        break;
                    case 'date':
                        app.frm.DateWidget(`#${fieldName}`, configObject.settings);
                        break;
                    case 'documentnumber':
                        $(`#${fieldName}`).formatter({
                            pattern: '0{{9}}-{{9999}}-{{9999}}',
                            persistent: false
                        });
                        app.ui.DocumentNumberHandler(`#${fieldName}`, configObject.settings.callbackDone, configObject.settings.callbackDocType);

                        break;
                    case 'phone':
                        app.frm.PhoneNumberWidget(`#${fieldName}`);
                        break;

                    case 'string':
                    case 'email':
                    case 'dropdownnumeric':
                    case 'dropdownstring':
                    case 'radionumeric':
                    case 'hiddennumeric':
                    case 'documentnumbertype':
                    case 'typeahead':
                    case 'dropdownmulti':
                    case 'radioboolean':
                        break;
                    default:
                        throw new Error(`El tipo ${dataType}" no esta implementado`)
                        break;
                }

                if (configObject.type.startsWith('radio')) {
                    selector = `input:radio[name=${fieldName}]`;
                }
                configObject.element = $(selector);
            }

            Validations_Setup(formSelector, elementsConfig);

            return elementsConfig;
        }
    };
})();
