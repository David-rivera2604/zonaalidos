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
        /**
         * Construye y renderiza un timeline de Inspinia en un contenedor.
         *
         * @param {string} container    - Selector jQuery del contenedor destino.
         * @param {Array}  items        - Array { UserName, UserAssignedDate, State, StateDesc }
         * @param {Object} [stateConfig] - Config opcional de estados: { icon, bg, label } por State.
         *
         * @example
         *   app.frm.RenderTimeline('#TimelineHistorial', historyArray);
         */
        /**
         * Renderiza un timeline en el contenedor indicado.
         *
         * @param {string} container     - Selector jQuery del contenedor destino.
         * @param {Array}  items         - Array { UserName, UserAssignedDate, State, StateDesc }
         * @param {Object} [options]     - Opciones:
         *                                  horizontal: true  → timeline horizontal compacto (default)
         *                                  horizontal: false → timeline vertical Inspinia
         *                                  stateConfig: {}   → override de icono/color por State
         */
        RenderTimeline: function (container, items, options) {
            const opts = Object.assign({ horizontal: true, stateConfig: {} }, options || {});
            const defaults = {
                1: { icon: 'fa-cog',     color: '#676a6c', label: 'Automatico'         },
                2: { icon: 'fa-user',    color: '#1ab394', label: 'Primera asignacion'  },
                3: { icon: 'fa-refresh', color: '#23c6c8', label: 'Reasignacion'        }
            };
            const config = Object.assign({}, defaults, opts.stateConfig);
            const $target = $(container);
            if (!$target.length) return;

            if (!items || items.length === 0) {
                $target.html('<p class="text-muted m-t-sm"><em>Sin historial de asignaciones.</em></p>');
                return;
            }

            if (opts.horizontal) {
                // Timeline horizontal compacto
                const steps = items.map(function (item, idx) {
                    const cfg  = config[item.State] || defaults[2];
                    const name = item.UserName  || 'Desconocido';
                    const desc = item.StateDesc || cfg.label;
                    const date = item.UserAssignedDate
                        ? new Date(item.UserAssignedDate).toLocaleString('es-CR', {
                              day:    '2-digit', month:  '2-digit', year: 'numeric',
                              hour:   '2-digit', minute: '2-digit'
                          })
                        : '';

                    let connector = '';
                    if (idx > 0) {
                        var prev    = items[idx - 1];
                        var diffMs  = (prev.UserAssignedDate && item.UserAssignedDate) ? new Date(item.UserAssignedDate) - new Date(prev.UserAssignedDate) : 0;
                        var diffMin = Math.floor(Math.abs(diffMs) / 60000);
                        var elapsed = diffMin < 60 ? diffMin + ' min' : diffMin < 1440 ? Math.floor(diffMin/60) + ' h' : Math.floor(diffMin/1440) + ' d';
                        connector =
                            '<div style="flex:1;display:flex;align-items:center;align-self:center;min-width:70px;margin:0 2px;">' +
                                '<div style="flex:1;height:2px;background:#e7eaec;"></div>' +
                                '<div style="background:#f5f5f5;border:1px solid #e0e0e0;border-radius:10px;padding:2px 7px;font-size:10px;color:#999;white-space:nowrap;flex-shrink:0;line-height:1.4;" title="Tiempo entre asignaciones">' +
                                    '<i class="fa fa-clock-o" style="font-size:9px;margin-right:2px;"></i>' + elapsed +
                                '</div>' +
                                '<div style="flex:1;height:2px;background:#e7eaec;"></div>' +
                            '</div>';
                    }

                    return `${connector}
                    <div style="display:flex;flex-direction:column;align-items:center;
                                min-width:100px;max-width:140px;margin-bottom:4px;">
                        <div style="width:34px;height:34px;border-radius:50%;
                                    background:${cfg.color};flex-shrink:0;
                                    display:flex;align-items:center;justify-content:center;
                                    box-shadow:0 2px 6px rgba(0,0,0,.18);">
                            <i class="fa ${cfg.icon}" style="color:#fff;font-size:13px;"></i>
                        </div>
                        <div style="margin-top:7px;text-align:center;width:100%;padding:0 4px;">
                            <div style="font-size:11px;font-weight:600;color:#333;
                                        word-break:break-word;line-height:1.3;"
                                 title="${name}">${name}</div>
                            <div style="font-size:10px;color:#888;margin-top:2px;
                                        font-style:italic;">${desc}</div>
                            <div style="font-size:10px;color:#aaa;margin-top:2px;">${date}</div>
                        </div>
                    </div>`;
                }).join('');

                // Liberar el overflow del div readonly para que el timeline no se corte
                $target.css({ 'overflow': 'visible', 'min-height': '100px' });
                $target.closest('.form-group').css('overflow', 'visible');

                $target.html(
                    `<div style="display:flex;align-items:flex-start;flex-wrap:wrap;
                                 gap:8px;width:100%;padding:10px 0;">${steps}</div>`
                );
            } else {
                // Timeline vertical Inspinia (original)
                const blocks = items.map(function (item) {
                    const cfg  = config[item.State] || defaults[2];
                    const name = item.UserName  || 'Usuario desconocido';
                    const desc = item.StateDesc || cfg.label;
                    const date = item.UserAssignedDate
                        ? new Date(item.UserAssignedDate).toLocaleString('es-CR', {
                              day: '2-digit', month: '2-digit', year: 'numeric',
                              hour: '2-digit', minute: '2-digit'
                          })
                        : '';
                    return `<div class="vertical-timeline-block">
                        <div class="vertical-timeline-icon" style="background:${cfg.color};">
                            <i class="fa ${cfg.icon}"></i>
                        </div>
                        <div class="vertical-timeline-content">
                            <h2>${name}</h2>
                            <p class="text-muted m-b-xs">${desc}</p>
                            <span class="vertical-date"><small>${date}</small></span>
                        </div>
                    </div>`;
                }).join('');

                $target.html(
                    `<div id="vertical-timeline" class="light-timeline no-margins">${blocks}</div>`
                );
            }
        },
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
        NumericWidget: function (selector, options = {}) {

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
                    case 'dropdownmulti':
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
