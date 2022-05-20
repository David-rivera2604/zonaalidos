var app = app || {};
app.ui = (function () {

    return {
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

            if (values != null) {
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
        SetNumericValue: function (selector, value) {
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
        SetDocumentTypeValue: function (name, value) {
            if (value == null || value == 0) {
                value = 1;
            }
            $(name).data('value', value);
            $(name).text($(name).parent().find(name + 'Menu a[data-value=' + value + ']').text());
        },
        IsValid: function (formId, ignore, showResume) {
            if (ignore)
                return true;
            else {
                var instance = $(formId);
                var validate = instance.validate();
                var result = instance.valid();
                if (showResume === undefined || showResume == null) {
                    showResume = true;
                }
                if (!result && showResume) {
                    var title = '';
                    var count = validate.errorList.length;
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

                    for (var i = 0; i < count; i++) {
                        errorHtml += '<label id="' + $(validate.errorList[i]['element']).attr('id') + '-error" for="' + $(validate.errorList[i]['element']).attr('id') + '">' + validate.errorList[i]['message'] + '</label>';
                    }
                    errorHtml += '</small>';
                    toastr.error(errorHtml, title, { timeOut: 7000, closeButton: true, progressBar: true });
                    validate.focusInvalid();
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
            if (value === null || value === 0)
                return '';
            else
                return value.charAt(0).toUpperCase() + value.slice(1).toLowerCase();
        },
        StringCapitalizeEachWordFormatter: function (value, row, index, field) {
            if (value === null || value === 0)
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
            let currency = 'XX';
            if (value === null) {
                value = 0;
            }
            if (row?.NOM_MON == 'CRC') currency = '₡ ';
            if (row?.NOM_MON == 'USD') currency = '$ ';
            return currency + value.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
        },
        DateFormatter: function (value, row, index, field) {
            if (value === null || value === '0001-01-01T00:00:00')
                value = '';
            else
                value = moment(value).format('DD/MM/YYYY');

            return value;
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
        DocumentTypeHandler: function (el, element, type, callbackDocumentType) {
            var btn = $(el).parent().parent().find('.btn');
            var value = $(el).data('value');
            btn.text($(el).text());
            btn.data('value', value);
            event.preventDefault();

            if (type == 'Identification') {
                switch (value) {
                    case 1: //10 DIGITOS Y DEBE INICIAR CON “0”: 0X-XXXX-XXXX
                        $(element).formatter().resetPattern('0{{9}}-{{9999}}-{{9999}}');
                        $(element).attr('placeholder', '0X-XXXX-XXXX');
                        break;
                    case 2: //12 DÍGITOS Y DEBE INICIAR CON “1”: 1XXX-XXXXXX-XX
                        $(element).formatter().resetPattern('1{{999}}-{{999999}}-{{99}}');
                        $(element).attr('placeholder', '1XXX-XXXXXX-XX');
                        break;
                    case 3: //14 DÍGITOS: XXXXXXXXXXXXXX
                        $(element).formatter().resetPattern('{{*************}}');
                        $('#identificacion').attr('placeholder', 'XXXXXXXXXXXXXX');
                        break;
                    case 4:
                        $(element).formatter().resetPattern('{{99999999999999999}}');
                        $(element).attr('placeholder', 'XXXXXXXXXXXXXXXXX');
                        break;
                }
            }
            if (callbackDocumentType !== undefined && callbackDocumentType !== null) {
                callbackDocumentType(value);
            }
        },
        Yesterday: function () {
            var value = new Date();
            value.setDate(value.getDate() - 1);
            return value;
        },
        IsDocumentNumberValid: function (documentType, documentNumber) {
            var result = false;
            var length = documentNumber.length;

            switch (documentType) {
                case 1: //10 DIGITOS Y DEBE INICIAR CON “0”: 0X-XXXX-XXXX
                    result = (length === 12);
                    break;
                case 2: //12 DÍGITOS Y DEBE INICIAR CON “1”: 1XXX-XXXXXX-XX
                    result = (length === 14);
                    break;
                case 3: //14 DÍGITOS: PASXXXXXXXXXXXXXX
                    result = (length === 17);
                    break;
                case 4:
                    result = (length >= 7 && length <= 14);
                    break;
            }
            return result;
        },
        DocumentNumberHandler: function (documentNumberElement, callbackDone, callbackDocumentType) {
            $(documentNumberElement).formatter({
                pattern: '0{{9}}-{{9999}}-{{9999}}',
                persistent: false
            });
            $(documentNumberElement + 'TypeMenu a').click(function () {
                app.ui.DocumentTypeHandler(this, documentNumberElement, 'Identification', callbackDocumentType);
            });
            $(documentNumberElement).on('blur', function () {
                if (app.ui.IsDocumentNumberValid($(documentNumberElement + 'Type').data('value'), $(documentNumberElement).val())) {
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
            $('.sidebar-content').toggleClass('sk-loading');
            if (options.class === '') {
                $('#right-sidebar').attr('style', 'width:' + options.width + ' !important');
            } else {
                $('#right-sidebar').addClass(options.class);
            }
            if (!$('#right-sidebar').hasClass('sidebar-open')) {
                $('#right-sidebar').removeClass('d-none');
                $('#right-sidebar').toggleClass('sidebar-open');
            }

            if (!options.isExternal) {
                app.core.Get(app.setting.apipath + `v1/Viewer/Dialog?id=${options.id}`)
                    .done(function (data, textStatus, jqXHR) {
                        let html = data.HTML.supplant(options.data);
                        html = app.core.ReplaceAll(html, '@_eq', '=');
                        html = app.core.ReplaceAll(html, '@_qt', '\'');
                        html = app.core.ReplaceAll(html, '@_sc', ';');
                        //html = html.replace(/@_/g, '\'');
                        $('.sidebar-content').replaceWith(html.replace('ibox-content', 'ibox-content sidebar-content'));
                        eval(data.Code);
                    });
            }
            else {
                $('.sidebar-content').replaceWith($("<iframe id='sidebarFrame' class='sidebar-content'/>").attr({ frameBorder: 0, width: '100%', height: 60 + $('#right-sidebar').height() + 'px', src: options.url, scrolling: 'no' }));
                $('#sidebarFrame').on('load', function (e) {
                    $('.sidebar-content').attr({ height: document.getElementById("sidebarFrame").contentWindow.document.body.scrollHeight + 'px' });
                });
            }
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
        LookupLoad: function (ctrl, lkpData) {
            let selectedOptions = $('select#' + ctrl);
            selectedOptions.children().remove();
            $.each(lkpData, function () {
                selectedOptions.append($('<option />').val(this['Code']).text(this['Description']));
            });
            if (lkpData.length == 1 && !selectedOptions.is(':disabled')) {
                selectedOptions.val(lkpData[0]['Code']);
            } else {
                selectedOptions.val(-1);
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
    };
})();