var app = app || {};
app.ui = (function () {

    return {
        StringValueToString: function (value, defaultValue) {
            if (value === null) {
                return defaultValue === undefined ? '' : defaultValue;
            }
            else {
                return value;
            }
        },
        DateTimeValueToString: function (value, hourValue, defaultValue) {
            if (value === null) {
                return defaultValue === undefined ? '' : defaultValue;
            }
            else {
                let hfmt = '';
                if (hourValue != undefined) {
                    hfmt = ' hh:mma';
                    if (hourValue != null) {
                        value = value.replace("T00:00", "T" + hourValue)
                    }
                }
                return moment(value).format('DD/MM/YYYY' + hfmt);
                return value;
            }
        },
        Age: function (birthDate) {
            let age = moment().diff(birthDate, 'years');
            if (Number.isNaN(age))
                age = 0;
            return age;
        },
        DropDownValueWithOption: function (selector, value, display) {
            $(selector).append(`<option value=${value} selected>${display}</option>`);
        },
        SetDropDownMultiValues: function (selector, values) {
            var control = $('select#' + selector);
            var valueSelect = [];

            if (values != null && Array.isArray(values)) {
                var adapter = control.data('select2').dataAdapter;
                var allItem = [];
                adapter.$element.children().each(function () {
                    if (!$(this).is('option') && !$(this).is('optgroup')) {
                        return true;
                    }
                    allItem.push(adapter.item($(this)));
                });
                $.each(values, function (keyDefaul, value) {
                    valueSelect.push(value.Code.toString());
                    $.each(allItem, function (key, valueData) {
                        if (value.Code === valueData.id) {
                            valueData.selected = true;
                            valueSelect.push(valueData.id);
                        }
                    });
                });
            }
            control.val(valueSelect);
            control.trigger('change');
        },
        GetDropDownMultiValues: function (selector) {
            var control = $('select#' + selector);
            var adapter = control.data('select2').dataAdapter;
            var allItem = [];

            $.each(control.select2('data'), function (index, element) {
                if (element.selected)
                    allItem.push({ Code: element.id, Description: element.text });
            });

            return allItem;
        },
        GetDropDownMultiStringValues: function (selector) {
            return $('select' + selector).select2('data').map(function (item) { return item['id']; }).toString();
        },
        IsElementValid: function (formId, elementId) {
            var result = false;
            var instance = $(formId);
            var validate = instance.validate();

            validate.settings.ignore = '';

            if (validate.element(elementId)) {
                validate.resetElements($(elementId));
                $(elementId + '-error').hide();
                result = true;
            }
            validate.settings.ignore = ':hidden';
            return result;
        },
        GetDateRawValue: function (selector) {
            return (($(selector).val() !== '') ? $(selector + '_group').data('DateTimePicker').date().toDate() : moment('0001-01-01T00:00:00').toDate());
        },
        GetDateValue: function (selector) {
            return (($(selector).val() !== '') ? $(selector + '_group').data('DateTimePicker').date().format('YYYY-MM-DDT00:00:00') : moment('0001-01-01T00:00:00').format('YYYY-MM-DDT00:00:00'));
        },
        SetDateValue: function (selector, value) {
            if (value === null || value.toString() === '0001-01-01T00:00:00')
                $(selector + '_group').data("DateTimePicker").date(null);
            else
                $(selector + '_group').data("DateTimePicker").date(moment(value));
        },
        GetDropDownStringValue: function (selector) {
            return $(selector).val();
        },
        GetDropDownSelectedText: function (selector) {
            return $(selector + ' option:selected').text();
        },
        GetDropDownNumericValue: function (selector) {
            var value = $(selector).val();
            if (value === null || value === '')
                value = 0;
            return parseInt(value, 10);
        },
        SetDropDownNumericValue: function (selector, value, autoSelect, defaultValue) {


            $(selector).val(value);

            if ($(selector).val() === null && (defaultValue != undefined && defaultValue != null)) {
                $(selector).val(defaultValue);
            }

            if (autoSelect && (value === null || value === '') && (defaultValue === undefined || defaultValue == null)) {
                $(selector).val($(selector + ' option:first').val());
                $(selector).change();
            } else {
                if (autoSelect && ($(selector).val() === null)) {
                    $(selector).val($(selector + ' option:first').val());
                    $(selector).change();
                }
            }

        },
        GetDropDownNumericValue: function (selector) {
            var value = $(selector).val();
            if (value === null || value === '')
                value = 0;
            return parseInt(value, 10);
        },
        SetDropDownStringValue: function (selector, value, autoSelect, defaultValue) {


            $(selector).val(value);

            if ($(selector).val() === null && (defaultValue != undefined && defaultValue != null)) {
                $(selector).val(defaultValue);
            }

            if (autoSelect && (value === null || value === '') && (defaultValue === undefined || defaultValue == null)) {
                $(selector).val($(selector + ' option:first').val());
                $(selector).change();
            } else {
                if (autoSelect && ($(selector).val() === null)) {
                    $(selector).val($(selector + ' option:first').val());
                    $(selector).change();
                }
            }

        },
        SelectDropDownByText: function (selector, selectText) {
            let value = selectText.replace(/[ \.Cc\$\%\/]/g, '');
            let changed = false;

            $(selector + ' option').each(function (index, element) {
                if (element.text.replace(/[ \.Cc\$\%\/]/g, '') === value) {
                    element.selected = true;
                    changed = true;
                }
            });
            return changed;
        },
        GetNumericValue: function (selector) {
            var value = AutoNumeric.getNumber(selector)
            if (value === null)
                value = 0;
            return value;
        },
        GetHiddenNumericValue: function (selector) {
            var value = $(selector).val();
            if (value === null || value === '')
                value = 0;
            return parseInt(value, 10);
        },
        SetNumericValue: function (selector, value, min, max) {
            if (min != undefined && value < min) {
                value = min;
            }
            if (max != undefined && value > max) {
                value = max;
            }
            AutoNumeric.set(selector, value);
        },
        SetRadioNumericValue: function (name, value) {
            $('input:radio[name=' + name + '][value=' + value + ']').prop('checked', true);
        },
        SetRadioStringValue: function (name, value) {
            $('input:radio[name=' + name + '][value=' + value + ']').prop('checked', true);
        },
        GetRadioNumericValue: function (name) {
            return parseInt($('input:radio[name=' + name + ']:checked').val(), 10);
        },
        SetRadioStringValue: function (name, value) {
            $('input:radio[name=' + name + '][value=' + value + ']').prop('checked', true);
        },
        GetRadioStringValue: function (name) {
            return $('input:radio[name=' + name + ']:checked').val();
        },
        GetRadioSelectedText: function (name) {
            return $('label[for=' + name + '_' + app.ui.GetRadioNumericValue(name) + ']').text();
        },
        SetDocumentTypeValue: function (name, value) {
            if (value == null || value == 0) {
                value = 1;
            }
            $(name).data('value', value);
            $(name).text($(name).parent().find(name + 'Menu a[data-value=' + value + ']').text());
        },
        IsValid: function (formId, ignore, showResume, others) {
            if (ignore)
                return true;
            else {
                var instance = $(formId);
                var validate = instance.validate();
                var result = instance.valid();
                if (showResume === undefined || showResume == null) {
                    showResume = true;
                }
                if (others === undefined || others == null) {
                    others = [];
                }
                if ((!result || others.length > 0) && showResume) {
                    var title = '';
                    var count = validate.errorList.length;
                    let iCount = count + others.length;
                    if (iCount > 1)
                        title = 'Existen ' + iCount + ' errores';
                    else
                        title = 'Existe ' + iCount + ' error';
                    title += ' que necesitan su atención';
                    var errorHtml = '<small>';
                    if (count > 7) {
                        errorHtml += 'Algunos de ellos son:<br>';
                        count = 7;
                    }

                    for (var i = 0; i < count; i++) {
                        errorHtml += '<label id="' + $(validate.errorList[i]['element']).attr('id') + '-error" for="' + $(validate.errorList[i]['element']).attr('id') + '">' + validate.errorList[i]['message'] + '</label>';
                    }
                    if (count <= 5) {
                        for (var i = 0; i < others.length; i++) {
                            errorHtml += '<label id="' + others[i].id + '" for="' + others[i].id + '">' + others[i].message + '</label>';
                        }
                    }
                    errorHtml += '</small>';
                    toastr.error(errorHtml, title, { timeOut: 9000, closeButton: true, progressBar: true });
                    validate.focusInvalid();
                    result = false;
                }

                return result;
            }
        },
        StringFormatter: function (value, row, index, field) {
            if (value === null || value === 0)
                return '';
            else
                return value;
        },
        StringCapitalizeFormatter: function (value, row, index, field) {
            if (value === null || value === 0 || typeof value === 'object')
                return '';
            else
                return value.charAt(0).toUpperCase() + value.slice(1).toLowerCase();
        },
        StringCapitalizeEachWordFormatter: function (value, row, index, field) {
            if (value === null || value === 0 || typeof value === 'object')
                return '';
            else {
                var words = value.split(" ");
                for (let i = 0; i < words.length; i++) {
                    words[i] = words[i].charAt(0).toUpperCase() + words[i].slice(1).toLowerCase();
                }
                return words.join(" ");
            }
        },
        NumericValueFormat: function (value, fractionDigits) {
            if (value === null)
                value = 0;
            return value.toLocaleString('ES', { minimumFractionDigits: fractionDigits, maximumFractionDigits: fractionDigits });
        },
        BooleanFormatter: function (value, row, index, field) {
            let result = '';
            if (value) {
                result = '<i class="fa fa-check" aria-hidden="true"></i>';
            }
            return result;
        },
        IntegerFormatter: function (value, row, index, field) {
            if (value === null || value === 0)
                return '';
            else if (value === undefined) {
                console.log("IntegerFormatter", field, value);
                return '';
            }

            else
                return value.toLocaleString('ES', { minimumFractionDigits: 0, maximumFractionDigits: 0 });
        },
        IntegerWithZeroFormatter: function (value, row, index, field) {
            if (value === null)
                value = 0;
            else if (value === undefined) {
                console.log("IntegerFormatter", field, value);
                value = 0;
            }
            return value.toLocaleString('ES', { minimumFractionDigits: 0, maximumFractionDigits: 0 });
        },
        DecimalFormatter: function (value, row, index, field) {
            if (value == undefined || value === null || value === 0)
                return '';
            else
                return value.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
        },
        DecimalWithZeroFormatter: function (value, row, index, field) {
            if (value === null) {
                value = 0;
            }
            return value.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
        },
        CurrencyAmountFormatter: function (value, row, index, field) {
            let currency = '';
            if (value === null) {
                value = 0;
            }
            if (row?.NOM_MON == 'CRC') currency = '₡ ';
            if (row?.NOM_MON == 'USD') currency = '$ ';
            if (row?.Cod_Mon == 1) currency = '₡ ';
            if (row?.Cod_Mon == 2) currency = '$ ';
            if (row?.COD_MON == 1) currency = '₡ ';
            if (row?.COD_MON == 2) currency = '$ ';
            return currency + value.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
        },
        DateFormatter: function (value, row, index, field) {
            if (value === null || value === '0001-01-01T00:00:00')
                value = '';
            else
                value = moment(value).format('DD/MM/YYYY');

            return value;
        },

        TestFormatter: function (value, row, index, field) {
            var code = '<span class=columnBtn><button type=\"button\" name=\"xxx\" class=\"btn btn-white ns\" title=\"Permite imprimir la poliza\"><i class=\"fa fa-ellipsis-v\"></i></button>' + '</span>'
            return code;

        },
        DateAndTimeFormatter: function (value, row, index, field) {
            if (value === null || value === '0001-01-01T00:00:00')
                value = '';
            else
                value = moment(value).format('DD/MM/YYYY hh:mma');

            return value;
        },
        UpdateDateAndUserFormatter: function (value, row, index, field) {
            let userName = '';
            if (row.UpdateUserName != undefined) {
                userName = row.UpdateUserName;
            }
            else if (row.UPDATEUSERNAME != undefined) {
                userName = row.UPDATEUSERNAME;
            }
            if (value === null || value === '0001-01-01T00:00:00')
                return '';
            else
                return '<span title="' + moment(value).format('DD/MM/YYYY hh:mm:ssa') + '">' + userName + ' <small class="text-muted"> ' + moment(value).from() + '</small></span>';
        },
        EditLinkFormatter: function (value, row, index, field) {
            return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de la fila">' + value + '</a>';
        },
        GenericDetailFormatter: function (index, row) {
            var html = [];
            var columns = $(this).bootstrapTable('getOptions')[0].columns[0];
            $.each(columns, function (key, column) {
                html.push('<p>');
                html.push('<b>' + column.title + ':</b> ');
                if (typeof column.formatter === 'function')
                    html.push(column.formatter(row[column.field], row, key, column.field));
                else
                    html.push(row[column.field]);
                html.push('</p>');
            })
            return html.join('')
        },
        ButtonDoing: function (ctrolId, noBody) {
            $(ctrolId).data("done", $(ctrolId).html());
            //$(ctrolId).html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> ' + $(ctrolId).data("doing"));
            $(ctrolId).html($(ctrolId).data("doing"));
            $(ctrolId).prop("disabled", true);
            if (noBody === undefined) {
                $('.ibox-content').toggleClass('sk-loading');
            }
            return ctrolId;
        },
        ButtonDone: function (ctrolId, noBody) {
            $(ctrolId).html($(ctrolId).data("done"));
            $(ctrolId).prop("disabled", false);
            if (noBody === undefined) {
                $('.ibox-content').toggleClass('sk-loading');
            }
            return '';
        },
        ShowAlert: function (ctrolId, alertClass, message) {
            $('#' + ctrolId).html("<div id='" + ctrolId + "Alert' class='alert alert-dismissable animated fadeInDown " + alertClass + "'>" +
                "<button aria-hidden='true' data-dismiss='alert' class='close' type='button'>×</button>" +
                message +
                "</div>");
        },
        GetExtentValue: function () {
            var data = {};
            $('[data-custom]').each(function (index, element) {
                data[element.id] = $(element).val();
            });
            return data;
        },
        SetExtentValue: function (data) {
            $('[data-custom]').each(function (index, element) {
                if (data == null) {
                    $(element).val(data);
                }
                else {
                    $(element).val(data[element.id]);
                }
            });
        },
        ErrorPlacement: function (error, element) {
            var name = $(element).attr("name");
            var $obj = $("#" + name + "_validate");
            if ($obj.length) {
                error.appendTo($obj);
            }
            else {
                error.insertAfter(element);
            }
        },
        Yesterday: function () {
            var value = new Date();
            value.setDate(value.getDate() - 1);
            return value;
        },
        DocumentTypeHandler: function (el, element, type, callbackDocumentType) {
            var btn = $(el).parent().parent().find('.btn');
            var elementType = $(el).prop('type');
            if (elementType == "radio") {
                var value = app.ui.GetRadioNumericValue(el.name);
            }
            else {
                var value = $(el).data('value');
            }
            btn.text($(el).text());
            btn.data('value', value);
            event.preventDefault();

            if (type == 'Identification') {
                switch (value) {
                    case 1: //Cédula física 9 
                        $(element).val('');
                        $(element).formatter().resetPattern('0{{9}}-{{9999}}-{{9999}}');
                        $(element).attr('placeholder', '0X-XXXX-XXXX');
                        break;
                    case 2: //DIME 11 o 12  12 DÍGITOS Y DEBE INICIAR CON “1”: 1XXX-XXXXXX-XX
                        $(element).val('');
                        $(element).formatter().resetPattern('{{9999}}-{{999999}}-{{99}}');
                        $(element).attr('placeholder', 'XXXX-XXXXXX-XX');
                        break;
                    case 3: //Pasaporte 14 DÍGITOS: XXXXXXXXXXXXXX
                        $(element).val('');
                        $(element).formatter().resetPattern('{{**************}}');
                        $(element).attr('placeholder', 'XXXXXXXXXXXXXX');
                        break;
                    case 4: // Cédula jurídica 10
                        $(element).val('');
                        $(element).formatter().resetPattern('{{9999999999}}');
                        $(element).attr('placeholder', 'XXXXXXXXXX');
                        break;
                }
            }
            if (callbackDocumentType !== undefined && callbackDocumentType !== null) {
                callbackDocumentType(value);
            }
        },
        DocumentNumberHandler: function (documentNumberElement, callbackDone, callbackDocType) {
            $(documentNumberElement).formatter({
                pattern: '',
                persistent: false
            });
            $(documentNumberElement + 'TypeMenu a').click(function () {
                app.ui.DocumentTypeHandler(this, documentNumberElement, 'Identification', callbackDocType);
            });
            $(documentNumberElement).on('blur', function () {
                var validation = app.ui.IsDocumentNumberValid($(documentNumberElement + 'Type').data('value'), $(documentNumberElement).val());
                if (validation.result) {
                    $(documentNumberElement).addClass('loading');
                    var encodedDocNum = encodeURIComponent($(documentNumberElement).val());
                    var docType = $(documentNumberElement + 'Type').data('value');
                    if (docType == 1) {
                        var apiUrl = app.setting.apipath + 'v1/Insured/' + $(documentNumberElement).val().replace(/-/g, '') + '?docType=' + docType;

                    } else {
                        var apiUrl = app.setting.apipath + 'v1/Insured/' + (docType != 1 && docType != 2 ? encodedDocNum : parseInt(0 + $(documentNumberElement).val().replace(/-/g, ''), 10)) + '?docType=' + docType;
                    }
                    app.core.Get(apiUrl).done(function (data, textStatus, jqXHR) {
                        if (data != null && data.FirstName !== null) {
                            if (data.MiddleName === null) data.MiddleName = '';
                            if (data.LastName === null) data.LastName = '';
                            if (data.SecondLastName === null) data.SecondLastName = '';
                        } else {
                            data = null;
                        }
                        if (callbackDone) callbackDone(data);
                    }).always(function () {
                        $(documentNumberElement).removeClass('loading');
                    });
                    $(documentNumberElement).formatter({
                        pattern: validation.pattern,
                        persistent: false,
                    });
                }
            });
        },

        DocumentNumberHandlerKYC: function (documentNumberElement, callbackDone, callbackDocumentType, TypeKYC) {
            var typedocument;
            let documenttype = documentNumberElement + "tipo"
            if (TypeKYC == "juridico") {
                $(documentNumberElement).formatter({
                    pattern: '{{9999999999}}',
                    persistent: false
                });
                $(documentNumberElement).attr('placeholder', 'XXXXXXXXXX');

                typedocument = 4;
            }
            else {
                $(documentNumberElement).formatter({
                    pattern: '0{{9}}-{{9999}}-{{9999}}',
                    persistent: false
                });
                documenttype = documenttype.substring(1);
                $("input:radio[name=" + documenttype + "]").on("change", function () {
                    app.ui.DocumentTypeHandler(this, documentNumberElement, 'Identification', callbackDocumentType);
                });
            }

            $(documentNumberElement).on('blur', function () {
                if (typedocument != 4) {
                    typedocument = app.ui.GetRadioNumericValue(documenttype)
                }
                if (app.ui.IsDocumentNumberValid(typedocument, $(documentNumberElement).val())) {
                    var value = $(documentNumberElement).val().replace(/-/g, '');
                    if (value !== null && parseInt(0 + value, 10) !== 0 && parseInt(0 + value, 10) <= 999999999) {
                        $(documentNumberElement).addClass('loading');
                        app.core.Get(app.setting.apipath + 'v1/Insured/' + parseInt(0 + value, 10))
                            .done(function (data, textStatus, jqXHR) {
                                if (data != null) {
                                    if (data.FirstName === null) {
                                        data = null;
                                    }
                                    else {
                                        if (data.MiddleName === null) {
                                            data.MiddleName = '';
                                        }
                                        if (data.LastName === null) {
                                            data.LastName = '';
                                        }
                                        if (data.SecondLastName === null) {
                                            data.SecondLastName = '';
                                        }
                                    }
                                }
                                if (callbackDone !== undefined && callbackDone !== null) {
                                    callbackDone(data);
                                }
                            }).always(function () {
                                $(documentNumberElement).removeClass('loading');
                            });
                    }
                }
            });

        },
        IsDocumentNumberValid: function (documentType, documentNumber) {
            var result = false;
            var length = documentNumber.length;
            var pattern = "";

            switch (documentType) {
                case 1: //Cédula física: 10 DIGITOS Y DEBE INICIAR CON “0”: 0X-XXXX-XXXX
                    pattern = '0{{9}}-{{9999}}-{{9999}}';
                    result = (length === 12 && documentNumber.match(/^0\d{1}-\d{4}-\d{4}$/));
                    break;
                case 2: //DIME: 12 DÍGITOS Y DEBE INICIAR CON “1”: 1XXX-XXXXXX-XX
                    pattern = '{{9999}}-{{999999}}-{{99}}';
                    result = (length === 14 && documentNumber.match(/^1\d{3}-\d{6}-\d{2}$/));
                    break;
                case 3: //Pasaporte: DE 7 A 14 DÍGITOS, NUMÉRICOS O ALFANUMÉRICOS
                    pattern = '{{9999999}}|{{99999999}}|{{999999999}}|{{9999999999}}';
                    result = (length >= 7 && length <= 14 && documentNumber.match(/^[a-zA-Z0-9]{7,14}$/));
                    break;
                case 4: //Cédula jurídica: 10 DÍGITOS
                    pattern = '{{9999999999}}';
                    result = (length >= 7 && length <= 14 && documentNumber.match(/^\d{10}$/));
                    break;
            }
            return {
                result: result,
                pattern: pattern,
            };
        },
        DocumentNumberValidators: function () {
            $.validator.addMethod("DocumentNumberLength",
                function (value, element, params) {
                    return app.ui.IsDocumentNumberValid($("#DocumentType").data("value"), value);
                }
            );
        },
        DateValidators: function () {
            $.validator.addMethod("localDate",
                function (value, element) {
                    return this.optional(element) || value.match(/^(0?[1-9]|[12][0-9]|3[0-1])[/., -](0?[1-9]|1[0-2])[/., -](19|20)?\d{2}$/);
                }, "Ingrese una fecha en el formato dd/mm/yyyy"
            );
            $.validator.addMethod("BirthDate",
                function (value, element) {

                    if (this.optional(element))
                        return true;
                    else {
                        if (value.match(/^(0?[1-9]|[12][0-9]|3[0-1])[/., -](0?[1-9]|1[0-2])[/., -](19|20)?\d{2}$/)) {
                            if (moment(value, 'DD/MM/YYYY').isValid()) {
                                var current = moment(value, 'DD/MM/YYYY').toDate();
                                var current2 = moment(moment().format('DD/MM/YYYY'), 'DD/MM/YYYY').toDate();
                                return (current < current2);
                            }
                        }
                    }
                    return false;
                }, "Ingrese una fecha inferior al día de hoy"
            );
            $.validator.addMethod("localDate_future",
                function (value, element) {
                    if (this.optional(element))
                        return true;
                    else {
                        if (value.match(/^(0?[1-9]|[12][0-9]|3[0-1])[/., -](0?[1-9]|1[0-2])[/., -](19|20)?\d{2}$/)) {
                            if (moment(value, 'DD/MM/YYYY').isValid()) {
                                var current = moment(value, 'DD/MM/YYYY').toDate();
                                var current2 = moment(moment().format('DD/MM/YYYY'), 'DD/MM/YYYY').toDate();
                                return (current > current2);
                            }
                        }
                    }
                }, "Ingrese una fecha en el formato dd/mm/yyyy"
            );
        },
        NumericValidators: function () {
            $.validator.addMethod("Numeric",
                function (value, element, params) {
                    if (this.optional(element))
                        return true;
                    else {
                        return (value != "0,00" && value != "0" && value != "");
                    }
                }
            );
            $.validator.addMethod("AtLeastOne",
                function (value, element, params) {

                    if (this.optional(element))
                        return true;
                    else {
                        let ctrolValue;
                        let result = false;
                        params.split(",").forEach(function (value, index, array) {
                            ctrolValue = $('#' + value).val();
                            if (ctrolValue != "0,00" && ctrolValue != "0" && ctrolValue != "") {
                                result = true;
                            }
                        });
                        return result;
                    }
                }
            );
        },
        NotifyErrors: function (message, errors, formName) {

            if ((message === null || message === '') && (errors === null || errors.length === 0)) {
                return false;
            }

            if (message != null && message != '') {
                app.ui.ShowAlert('quoteNotify', 'alert-danger', message);
                return true;
            }


            var count = errors.length;
            if (count === 1 && errors[0]['Key'] === '*') {
                app.ui.ShowAlert(this['Group'] + 'Notify', 'alert-danger', this['Message']);
                return true;
            }

            var title = '';

            if (count > 1)
                title = 'Existen ' + count + ' errores';
            else
                title = 'Existe ' + count + ' error';

            title += ' que necesitan su atención';

            var errorHtml = '<small>';
            if (count > 7) {
                errorHtml += 'Algunos de ellos son:<br>';
                count = 7;
            }
            var options = {};
            var groupName = '';
            var id = '';
            for (var i = 0; i < count; i++) {

                if (errors[i]['Group'] === 'Table') {
                    id = errors[i]['Key'];
                    errorHtml += '<label id="' + id + '-error" for="' + id + '-validate"><a href="#' + id + '-validate">' + errors[i]['Message'] + '</a></label>';
                    $('#' + id + '-validate').text(errors[i]['Message']);
                    $('#' + id + '-validate').removeClass('d-none');
                }
                else {
                    id = $('#' + errors[i]['Key']).attr('id');
                    errorHtml += '<label id="' + id + '-error" for="' + id + '">' + errors[i]['Message'] + '</label>';

                    options = {};
                    options[errors[i]['Key']] = errors[i]['Message'];
                    if (formName != null) {
                        groupName = formName;
                    }
                    else {
                        groupName = '#' + errors[i]['Group'];
                    }
                    $(groupName).validate().showErrors(options);

                    if (i === 0)
                        $('#' + errors[i]['Key']).focus();
                }
            }
            errorHtml += '</small>';

            toastr.error(errorHtml, title, { timeOut: 7000, closeButton: true, progressBar: true });
            return true;
        },
        ShowSideBarEx: function (options) {
            var $offCanvas;
            var $offCanvasHeader = $("<div />").attr({ id: "off-canvas-header" }).addClass("border-bottom");

            if (options.isExternal === undefined) {
                options.isExternal = false;
            }

            if ($("#off-canvas").length > 0) {
                $offCanvas = $("#off-canvas");
                $offCanvas.empty();
            }
            else
                $offCanvas = $("<div />").attr({ id: "off-canvas" }).addClass("col-sm-3 col-xs-10");

            $offCanvasHeader.append('<button type="button" class="close" id="closeoffCanvas" aria-hidden="true">×</button>');
            if (typeof options.title != "undefined") {
                //'<i class="fa fa-info-circle"></i>'
                $offCanvasHeader.append('<h3>' + options.title + '</h3>');
            }

            $offCanvas.append($offCanvasHeader);

            $offCanvas.appendTo("body").show("slide", { direction: "right" }, 300, function () {
                if (options.isExternal)
                    $offCanvas.append($("<iframe />").attr({ frameBorder: 0, src: options.url }));
                else {

                    localStorage.setItem('current', JSON.stringify(options.data));

                    app.core.Get(app.setting.apipath + `v1/Viewer/Dialog?id=${options.id}`)
                        .done(function (data, textStatus, jqXHR) {
                            $offCanvas.append($("<div/>").attr({ id: "off-canvas-content" }).html(data));
                        });
                }

            });

            $offCanvasHeader.find("#closeoffCanvas").click(function (event) {
                event.preventDefault();
                $offCanvas.hide("slide", { direction: "right" }, 300, function () {
                    $offCanvas.remove();
                });
            });

        },
        ShowPopover: function (options, element) {
            //Check that the popover is not on the screen
            if ($("#" + $(element).attr("aria-describedby")).length == 0) {
                //Size to css
                options.cssWidth = options.width > 0 ? { "min-width": options.width } : {};
                options.cssHeight = options.height > 0 ? { "height": options.height } : {};
                options.title = typeof options.title != "undefined" ? options.title : " ";

                if (!options.isExternal)
                    $.extend(options.cssHeight, { overflow: "auto" });

                //Create the Popover structure
                var $newPopover = $("<div />").attr({ "role": "tooltip" }).addClass("popover dynamicPopover").css(options.cssWidth).html('<div class="arrow"></div>');
                var $popTitle = $("<h3 />").addClass("popover-title").text(options.title);
                var $popContent = $("<div />").addClass("popover-content").css(options.cssHeight);

                //Build the Popover html
                $newPopover.append($popTitle).append($popContent);

                $(element).attr({
                    'data-toggle': "popover",
                    'title': options.title,
                    'data-content': ""
                });

                //'data-trigger': "focus"
                //'data-trigger': "hover"

                $(element).popover({
                    template: $newPopover[0].outerHTML
                });

                //Build the Popover
                $(element).popover("show");

                //load teh content
                var popOverInstance = $("#" + $(element).attr("aria-describedby"));
                if (options.isExternal)
                    popOverInstance.find(".popover-content").append($("<iframe />").attr({ frameBorder: 0, src: options.url }));
                else
                    popOverInstance.find(".popover-content").load(options.url);
            }
        },
        ShowModal: function (options) {
            //Size to css
            options.cssWidth = options.width > 0 ? { "min-width": (options.width * 0.96) + "%" } : {};
            options.cssHeight = options.height > 0 ? { "height": (options.height) + "%" } : {};

            //Create the modal structure
            var $newModal = $("<div id='" + options.id + "' />").attr({ "role": "dialog" }).addClass("modal fade dynamicModal");
            var $modalDialog = $("<div />").attr({ "role": "document" }).addClass("modal-dialog");
            var $modalContent = $("<div />").addClass("modal-content");
            var $modalHeader = $("<div />").addClass("modal-header");
            var $modalBody = $("<div />").addClass("modal-body clearfix");

            //Apply the custom options
            $modalDialog.css(options.cssWidth);
            $modalContent.css(options.cssHeight);
            $modalHeader.append(typeof options.title != "undefined" ? "<h4>" + options.title + "</h4>" : "");
            $modalHeader.append('<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>');

            //Build the modal
            $modalContent.append($modalHeader).append($modalBody);
            $modalDialog.append($modalContent);
            $newModal.append($modalDialog);

            $("body").append($newModal);
            if (options.id != null) {
                app.core.Get(app.setting.apipath + `v1/Viewer/Dialog?id=${options.id}`)
                    .done(function (data, textStatus, jqXHR) {
                        let html = data.HTML.supplant(options.data);
                        html = app.core.ReplaceAll(html, '@_eq', '=');
                        html = app.core.ReplaceAll(html, '@_qt', '\'');
                        html = app.core.ReplaceAll(html, '@_sc', ';');

                        $modalBody.append(html.replace('ibox-content', 'ibox-content sidebar-content'));

                        $newModal.modal("show");
                        $newModal.on('hidden.bs.modal', function () { $newModal.remove() });
                        let code = data.Code.supplant(options.data);
                        code = app.core.ReplaceAll(code, '@_sc', ';');
                        eval(code);
                    });
            }
            else {
                //load teh content
                if (options.isExternal) {
                    $modalContent.addClass(options.height > 0 ? "" : "default-size");
                    $modalBody.html($("<iframe />").attr({ frameBorder: 0, src: options.url }));
                }
                else {
                    $internalContent = $("<div />").addClass("internalContent").load(options.url);
                    $internalContent.addClass(options.height > 0 ? "overflow-auto" : "");
                    $modalBody.append($internalContent);
                }

                //Display the modal
                $newModal.modal("show");
                $newModal.on('hidden.bs.modal', function () { $newModal.remove() });
            }
        },
        CloseSideBar: function () {
            if ($('#right-sidebar').hasClass('sidebar-open')) {
                $('#right-sidebar').removeClass('d-none');
                $('#right-sidebar').toggleClass('sidebar-open');
                $('#right-sidebar').attr('style', 'width: 0px !important');
            }
        },
        ShowSideBar: function (options) {
            if (options.isHTML === undefined) {
                options.isHTML = false;
            }
            if (options.isExternal === undefined) {
                options.isExternal = false;
            }
            if (options.class === undefined || options.class === null) {
                options.class = '';
            }
            if (options.width === undefined || options.width === null) {
                options.width = "260px";
            }
            if (options.data != undefined && options.data != null) {
                localStorage.setItem('current', JSON.stringify(options.data));
            }
            $('#sidebarTitle').html('');
            if (typeof options.title != "undefined") {
                $('#sidebarTitle').append('<h3>' + options.title.supplant(options.data) + '</h3>');
            }
            if (typeof options.subtitle != "undefined") {
                $('#sidebarTitle').append('<small>' + options.subtitle.supplant(options.data) + '</small>');
            }
            if (options.class === '') {
                $('#right-sidebar').attr('style', 'width:' + options.width + ' !important');
            } else {
                $('#right-sidebar').addClass(options.class);
            }

            if ($('#right-sidebar').hasClass('sidebar-open')) {
                $('#right-sidebar').toggleClass('sidebar-open');
                $('.sidebar-content').replaceWith('<div class="ibox-content sidebar-content"><div class="sk-spinner sk-spinner-wave"><div class="sk-rect1"></div><div class="sk-rect2"></div><div class="sk-rect3"></div><div class="sk-rect4"></div><div class="sk-rect5"></div></div><div class="sidebarContent" /></div>');
                $('.sidebarContent').html('');
                $('#right-sidebar').addClass('d-none');
            }

            if (!$('#right-sidebar').hasClass('sidebar-open')) {
                $('#right-sidebar').removeClass('d-none');
                $('#right-sidebar').toggleClass('sidebar-open');
            }
            if (options.isHTML) {
                $('.sidebarContent').html(options.HTML);
            } else if (!options.isExternal) {
                $('.sidebar-content').toggleClass('sk-loading');
                app.core.Get(app.setting.apipath + `v1/Viewer/Dialog?id=${options.id}`)
                    .done(function (data, textStatus, jqXHR) {
                        let html = data.HTML.supplant(options.data);
                        html = app.core.ReplaceAll(html, '@_eqg', '>=');
                        html = app.core.ReplaceAll(html, '@_eq', '=');
                        html = app.core.ReplaceAll(html, '@_qt', '\'');
                        html = app.core.ReplaceAll(html, '@_sc', ';');
                        html = app.core.ReplaceAll(html, '@_ee', ' ');
                        //html = html.replace(/@_/g, '\'');
                        $('.sidebar-content').replaceWith(html.replace('ibox-content', 'ibox-content sidebar-content'));
                        if (options.callback != undefined) {
                            data.Code = data.Code.replace("//Custom.Extend", options.callback + "(this, JSON.parse(localStorage.getItem('current')));");
                        }
                        eval(data.Code);
                        //if (options.callback != undefined) {
                        //    eval(options.callback + '(app.Prototype, options.data)');
                        //}
                    });
            }
            else {
                $('.sidebar-content').toggleClass('sk-loading');
                $('.sidebar-content').replaceWith($("<iframe id='sidebarFrame' class='sidebar-content'/>").attr({ frameBorder: 0, width: '100%', height: 60 + $('#right-sidebar').height() + 'px', src: options.url, scrolling: 'no' }));
                $('#sidebarFrame').on('load', function (e) {
                    $('.sidebar-content').attr({ height: document.getElementById("sidebarFrame").contentWindow.document.body.scrollHeight + 'px' });
                });
            }
        },
        RemoveInJuridico: function (el, element, type, callbackDocumentType) {
            var btn = $(el).parent().parent().find('.btn');
            var elementType = $(el).prop('type');
            if (elementType == "radio") {
                var value = app.ui.GetRadioNumericValue(el.name);
            }
            else {
                var value = $(el).data('value');
            }
            btn.text($(el).text());
            btn.data('value', value);
            event.preventDefault();

            var col4 = $('.col-sm-4')

            if (type == 'Identification') {
                switch (value) {
                    case 1: //Cédula física
                        $(document).ready(function () {
                            $(col4).each(function () {
                                $(col4).addClass('animated fadeIn')
                                var idI = $(this).find('input').attr('id');
                                var idS = $(this).find('select').attr('id');
                                if (idI === 'apellido1' || idI === 'apellido2' || idI === 'fechadenacimiento' || idS === 'tercerosMca_sexo' || idS === 'estadoCivil') {
                                    $(this).removeClass('d-none');
                                }
                            });
                        });
                        break;
                    case 2: //DIMEX
                        $(document).ready(function () {
                            $(col4).each(function () {
                                $(col4).addClass('animated fadeIn')
                                var idI = $(this).find('input').attr('id');
                                var idS = $(this).find('select').attr('id');
                                if (idI === 'apellido1' || idI === 'apellido2' || idI === 'fechadenacimiento' || idS === 'tercerosMca_sexo' || idS === 'estadoCivil') {
                                    $(this).removeClass('d-none');
                                }
                            });
                        });
                        break;
                    case 3: //Pasaporte
                        $(document).ready(function () {
                            $(col4).each(function () {
                                $(col4).addClass('animated fadeIn')
                                var idI = $(this).find('input').attr('id');
                                var idS = $(this).find('select').attr('id');
                                if (idI === 'apellido1' || idI === 'apellido2' || idI === 'fechadenacimiento' || idS === 'tercerosMca_sexo' || idS === 'estadoCivil') {
                                    $(this).removeClass('d-none');
                                }
                            });
                        });
                        break;
                    case 4: // Cédula jurídica
                        $(document).ready(function () {
                            $(col4).each(function () {
                                $(col4).addClass('animated fadeIn')
                                var idI = $(this).find('input').attr('id');
                                var idS = $(this).find('select').attr('id');
                                if (idI === 'apellido1' || idI === 'apellido2' || idI === 'fechadenacimiento' || idS === 'tercerosMca_sexo' || idS === 'estadoCivil') {
                                    $(this).addClass('d-none');
                                }
                            });
                        });
                        break;
                }
            }
            if (callbackDocumentType !== undefined && callbackDocumentType !== null) {
                callbackDocumentType(value);
            }
        },
        DocumentNumberHandlerJDC: function (documentNumberElement, callbackDone, callbackDocumentType) {
            $(documentNumberElement + 'TypeMenu a').click(function () {
                app.ui.RemoveInJuridico(this, documentNumberElement, 'Identification', callbackDocumentType);
            });
        },
        DataEntryBehavior: function (formName, behavior) {
            $(formName + ' :input').each(function () {
                switch (behavior) {
                    case 'enabled':
                        $(this).prop("disabled", false);
                        break;
                    case 'disabled':
                        $(this).prop("disabled", true);
                        break;
                    case 'hide':
                        break;
                    case 'show':
                        break;
                }
            });
        },
        LookupLoad: function (ctrl, lkpData, autoSelect) {
            let selectedOptions = $('select#' + ctrl);
            selectedOptions.children().remove();
            $.each(lkpData, function () {
                selectedOptions.append($('<option />').val(this['Code']).text(this['Description']));
            });
            if (lkpData?.length == 1 && !selectedOptions.is(':disabled')) {
                selectedOptions.val(lkpData[0]['Code']);
            } else {
                if (!selectedOptions.is(':disabled') && autoSelect != undefined && autoSelect != null && autoSelect) {
                    selectedOptions.val($('select#' + ctrl + ' option:first').val());
                } else {
                    if (!selectedOptions.is(':disabled') && selectedOptions.data("autoselect") === true) {
                        selectedOptions.val($('select#' + ctrl + ' option:first').val());
                    } else {
                        selectedOptions.val(-1);
                    }
                }

            }
        },
        DropDownDisabled: function (element, disabled, clean) {
            let current = $(element).is(':disabled');
            $(element).prop("disabled", disabled);
            if (current && !disabled && $(element + ' option').length == 1) {
                $(element).prop("selectedIndex", 0);
            }
            if (clean != undefined && clean) {
                $(element).prop("selectedIndex", -1);
            }
            if (current && !disabled && $(element).data("autoselect") === true) {
                $(element).val($('select' + element + ' option:first').val());
            }

        },
        Download: function (fileName, id) {
            fileName = fileName.toLowerCase();
            if (fileName.endsWith("jpg") || fileName.endsWith("pdf"))
                window.open(app.setting.apipath + 'v1/Common/Download2?id=' + id, "Adjunto", "width=500, height=450, titlebar=no, location=NO");
            else
                window.location.href = app.setting.apipath + 'v1/Common/Download2?id=' + id;
        },
        GetApi: function (url) {
            $('.sidebar-content').toggleClass('sk-loading');
            return app.core.Get(app.setting.apipath + url)
                .done(function (data, textStatus, jqXHR) {
                    toastr.info(data, '', { timeOut: 7000, closeButton: true, progressBar: true });
                }).always(function () {
                    app.ui.CloseSideBar()
                });
        },
        TextColorFormatter: function (value, row, index, field) {
            return '<span class="text-' + (app.ViewerQuery.state[field][value] || app.ViewerQuery.state[field]['_']) + '">' + app.ui.StringCapitalizeFormatter(value) + '</span>';
        },
        BadgeColorFormatter: function (value, row, index, field) {
            return '<span class="badge badge-' + (app.ViewerQuery.state[field][value] || app.ViewerQuery.state[field]['_']) + '">' + app.ui.StringCapitalizeFormatter(value) + '</span>';
        },
        LabelColorFormatter: function (value, row, index, field) {
            return '<span class="label label-' + (app.ViewerQuery.state[field][value] || app.ViewerQuery.state[field]['_']) + '">' + app.ui.StringCapitalizeFormatter(value) + '</span>';
        },
        CommonBehaviour: function (custom) {
            let roles = JSON.parse(localStorage.getItem('Roles'));
            let tenant = localStorage.getItem('Tenant');
            roles.forEach(function (item) {
                $(`.role-${item}-visible`).removeClass('d-none');
                $(`.role-${item}-notvisible`).addClass('d-none');
                $(`.role-${item}-enable`).prop("disabled", false);
                $(`.role-${item}-disable`).prop("disabled", true);
                $(`.role-${item}-${tenant}-visible`).removeClass('d-none');
                $(`.role-${item}-${tenant}-enable`).prop("disabled", false);
                $(`.role--${tenant}-visible`).removeClass('d-none');
                $(`.role--${tenant}-enable`).prop("disabled", false);
                if (custom != undefined) {
                }
            })
        },
        CustomBehaviour: function (tag, condition) {

            let roles = JSON.parse(localStorage.getItem('Roles'));
            roles.forEach(function (item) {

                if (condition)
                    $(`.role-${item}-${tag}-visible`).removeClass('d-none');
                else
                    $(`.role-${item}-${tag}-visible`).addClass('d-none');
            })
        },
        VisibleBehaviour: function (tag, condition) {
            if (condition)
                if (tag.startsWith('#'))
                    $(`${tag}`).removeClass('d-none');
                else
                    $(`${tag}-visible`).removeClass('d-none');
            else
                if (tag.startsWith('#'))
                    $(`${tag}`).addClass('d-none');
                else
                    $(`${tag}-visible`).addClass('d-none');
        },
        RequiredMark: function (ctrlId, add) {
            const mark = ' <span class="required-mark" title="Este campo debe ser llenado de forma obligatoria">*</span>';
            let ctrl = $("[for=" + ctrlId + "]");
            if (add) {
                if (!ctrl.html().includes(mark)) {
                    ctrl.html(ctrl.html() + mark);
                }
            } else {
                if (ctrl.html().includes(mark)) {
                    ctrl.html(ctrl.html().replace(mark, ''));
                }
            }
        },
        LookUpListFormatter: function (value, row, index, field) {
            if (value === null || value === 0 || typeof value === 'object')
                return '';
            else {
                let lkp = [];
                if (this.lookupList != undefined) {
                    lkp = JSON.parse(this.lookupList.replaceAll("\'", "\""));
                }
                let lkpValue = lkp.find(({ code }) => code === value)

                return lkpValue == undefined ? value : lkpValue.desc;
            }
        },
        IsSameDate: function (dateSource, dateTarget) {
            if (dateSource != undefined && dateSource != null && dateTarget != undefined && dateTarget != null) {
                let source = dateSource;
                if (typeof source === 'string') {
                    source = new Date(source);
                }
                return (source.getFullYear() === dateTarget.getFullYear() &&
                    source.getMonth() === dateTarget.getMonth() &&
                    source.getDay() === dateTarget.getDay())
            }
            else
                return false;
        },
        Warning: function (msg, title, settings) {

            toastr.warning(msg, title, settings);
        },
        Success: function (msg, title, settings) {

            toastr.success(msg, '', { timeOut: 5000, closeButton: true, progressBar: true });
        },
        Success: function (msg, title, settings) {

            toastr.success(msg, title, settings);
        },
        Error: function (msg) {
            app.ui.Error(msg, '', { timeOut: 9000, closeButton: true, progressBar: true });
        },
        Error: function (msg, title, settings) {

            toastr.error(msg, title, settings);
        },
        NotifyClear: function (msg, title, settings) {

            toastr.remove();
        }
    };
})();