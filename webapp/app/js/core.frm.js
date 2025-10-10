var app = app || {};
app.frm = (() => {
    return {
        DateWidget: function (selector) {
            let settings = {
                format: 'DD/MM/YYYY',
                locale: 'es',
                minDate: new Date('1900-01-01T00:00:00')
            };
            return $(selector + '_group').datetimepicker(settings);
        },
        NumericWidget: function (selector, options = '', minimumValue = '0', maximumValue = '999999999999999999', decimalPlaces = '2') {

            options = ',' + options.toLowerCase() + ',';
            if (options.includes(',allownegative,') && minimumValue === '0') {
                minimumValue = '-99999999999999999';
            }
            if (options.includes(',integer,') && minimumValue === '0') {
                decimalPlaces = '0';
            }

            let settings = {
                decimalCharacter: ',',
                decimalCharacterAlternative: '.',
                digitGroupSeparator: '.',
                minimumValue: minimumValue,
                maximumValue: maximumValue,
                decimalPlaces: decimalPlaces,
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
            const fullconfig = { ...conf, ...options };
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
        InitDataEntry: async function (elementsConfig) {
            for (const [fieldName, configObject] of Object.entries(elementsConfig)) {
                let selector = `#${fieldName}`;
                if (configObject.type === 'radionumeric') {
                    selector = `input:radio[name=${fieldName}]`;
                }
                configObject.element = $(selector);
            }
            return elementsConfig;
        },
        ObjectToDataEntry: async function (elementsConfig, data) {
            for (const [fieldName, configObject] of Object.entries(elementsConfig)) {

                const dataType = configObject.type;
                let $element = configObject.element;
                let $change = configObject.change || false;
                let value;

                if ((!$element || $element.length === 0) && dataType != 'radioboolean') {
                    console.warn(`Elemento no encontrado para el campo: ${fieldName}.`);
                    continue;
                }

                switch (dataType) {
                    case 'numeric':
                        value = app.ui.SetNumericValue(`#${$element[0].id}`, data[fieldName]);
                        break;
                    case 'dropdownnumeric':
                        value = app.ui.SetDropDownNumericValue(`#${$element[0].id}`, data[fieldName]);
                        break;

                    case 'dropdownmulti':
                        app.ui.SetDropDownMultiValues(fieldName, data[fieldName]);
                        break;

                    case 'radioboolean':
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
                        $element.val(data[fieldName]);
                        break;
                    default:
                        throw new Error(`El tipo ${dataType}" no esta implementado`)
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
                let $element = configObject.element;
                let value;

                if ((!$element || $element.length === 0) && dataType != 'radioboolean') {
                    console.warn(`Elemento no encontrado para el campo: ${fieldName}. Se asigna null.`);
                    formData[fieldName] = null;
                    continue;
                }

                switch (dataType) {
                    case 'numeric':
                        value = app.ui.GetNumericValue(`#${$element[0].id}`);
                        break;
                    case 'dropdownnumeric':
                        value = app.ui.GetDropDownNumericValue(`#${$element[0].id}`);
                        break;

                    case 'dropdownmulti':
                        value = app.ui.GetDropDownMultiValues(fieldName);
                        break;

                    case 'radioboolean':
                        if (!$element || $element.length === 0) {
                            $element = $(`input:radio[name=${fieldName}]`);
                            configObject.element = $element;
                        }
                        value =  $element.filter(':checked').val() == 'true';
                        break;
                    case 'hiddennumeric':
                        value = parseInt(0 + $element.val(), 10) || null;
                        break;
                    case 'string':
                        value = $element.val();
                        break;
                    default:
                        throw new Error(`El tipo ${dataType}" no esta implementado`)
                        break;
                }
                formData[fieldName] = value;
            }

            return formData;
        }
    };
})();