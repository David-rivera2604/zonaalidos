var app = app || {};
app.poliza = (function () {

    var productModules = null;
    var productAlias = null;
    var EntryAllowed = null;
    var reviewMode = false;

    function Init_Controls() {

        $('#IssueDate_group').datetimepicker(
            {
                format: 'DD/MM/YYYY',
                locale: 'es',
                defaultDate: new Date()
            });

        $('#EffectiveDate_group').datetimepicker(
            {
                format: 'DD/MM/YYYY',
                locale: 'es'
            });
        $('#EndingDate_group').datetimepicker(
            {
                format: 'DD/MM/YYYY',
                locale: 'es'
            });
        new AutoNumeric('#InsuredAmount', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999',
            minimumValue: '0',
            decimalPlaces: 2
        });
        new AutoNumeric('#InsuredAmountBase', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#InsuredAmountComplement', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#AnnualPremium', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999',
            minimumValue: '0',
            decimalPlaces: 2
        });
        new AutoNumeric('#MonthlyPremium', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999',
            minimumValue: '0',
            decimalPlaces: 2
        });
        new AutoNumeric('#Surcharge', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '1000',
            minimumValue: '0',
            decimalPlaces: 2
        });
        new AutoNumeric('#TotalAnnualPremium', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999',
            minimumValue: '0',
            decimalPlaces: 2
        });
        new AutoNumeric('#TotalPremium', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999',
            minimumValue: '0',
            decimalPlaces: 2
        });
        $('#CancellationDate_group').datetimepicker(
            {
                format: 'DD/MM/YYYY',
                locale: 'es'
            });
    };

    function Init_Lookups() {
        app.core.Lookups(['PolicyStatus.Status',
            'ReasonForStatus',
            'BayerPolizas.ContractorName',
            'BayerNumeroPoliza.MainPolicyId']);
    };

    function ProductDefinition(callback) {
        var currency = $('select#Currency');
        var module = $('select#ModuleCode');
        var paymentFrequency = $('select#PaymentFrequency');

        app.core.Get(app.setting.apipath + 'v1/Policy/ProductDefinition?productAlias=' + productAlias, null,
            function (data) {

                if (data.Behavior != null && data.Behavior != '') {
                    eval(data.Behavior);
                }
                $('#ProductTitle').html(data.Title);
                $('#ProductSubTitle').html(data.SubTitle);


                $('#EffectiveDate_group').data("DateTimePicker").date(moment(data.Effective))
                $('#EffectiveDate').prop("disabled", true);

                $('#EndingDate_group').data("DateTimePicker").date(moment(data.Ending))
                $('#EndingDate').prop("disabled", true);

                currency.children().remove();
                $.each(data.Currencies, function () {
                    currency.append($('<option />').val(this['Code']).text(this['Description']));
                });
                if (data.Currencies.length === 1) {
                    currency.val(data.Currencies[0].Code);
                    currency.prop("disabled", true);
                }
                else {
                    currency.val(-1);
                    currency.prop("disabled", false);
                }
                module.children().remove();
                productModules = data.Modules;
                EntryAllowed = data.EntryAllowed;

                if (EntryAllowed.includes(";Overdraft;")) {
                    $('#prestamosHTabHeader').removeClass('d-none');
                }
                if (EntryAllowed.includes(";Beneficiaries;")) {
                    $('#beneficiariosHTabHeader').removeClass('d-none');
                    if (data.EntryIsRequired.includes(";Beneficiaries;")) {
                        app.beneficiarios.IsRequired(true);
                    } else {
                        app.beneficiarios.IsRequired(false);
                    }
                }

                $.each(data.Modules, function () {
                    module.append($('<option />').val(this['Code']).text(this['Description']));
                });
                if (data.Modules.length === 1) {
                    module.val(data.Modules[0].Code);
                    module.prop("disabled", true);
                }
                else {
                    module.val(-1);
                    module.prop("disabled", false);
                }

                paymentFrequency.children().remove();
                $.each(data.PaymentFrequencies, function () {
                    paymentFrequency.append($('<option />').val(this['Code']).text(this['Description']));
                });
                if (data.PaymentFrequencies.length === 1) {
                    paymentFrequency.val(data.PaymentFrequencies[0].Code);
                    paymentFrequency.prop("disabled", true);
                }
                else {
                    paymentFrequency.val(-1);
                    paymentFrequency.prop("disabled", false);
                }

                $('#AnnualPremium').prop("disabled", true);
                $('#MonthlyPremium').prop("disabled", true);
                if (data.Modules.length === 1 && data.Modules[0].FixedInsuredAmount > 0) {
                    $('#InsuredAmountBase').prop("disabled", true);
                    $('#InsuredAmount').prop("disabled", true);
                    AutoNumeric.set("#InsuredAmountBase", data.Modules[0].FixedInsuredAmount);
                    AutoNumeric.set("#InsuredAmount", data.Modules[0].FixedInsuredAmount);
                    AutoNumeric.set("#AnnualPremium", data.Modules[0].FixedPremium);
                    AutoNumeric.set("#MonthlyPremium", data.Modules[0].FixedMonthlyPremium);
                }
                else {
                    AutoNumeric.set("#AnnualPremium", 0);
                    AutoNumeric.set("#MonthlyPremium", 0);
                }

                if (data.AllowDigitalSign) {
                    $('.DigitalSign-visible').removeClass('d-none');
                    $('.DigitalSign-enable').prop("disabled", false);
                }

                if (callback !== undefined)
                    callback();
            });
    };

    function Event_Controls() {
        $('#ModuleCode').change(function () {
            Calculate();
        });

        $("#InsuredAmountBase").blur(function () {
            AutoNumeric.set("#InsuredAmount", AutoNumeric.getNumber('#InsuredAmountBase') + AutoNumeric.getNumber('#InsuredAmountComplement'));
            Calculate();
        });
        $("#InsuredAmountComplement").blur(function () {
            AutoNumeric.set("#InsuredAmount", AutoNumeric.getNumber('#InsuredAmountBase') + AutoNumeric.getNumber('#InsuredAmountComplement'));
            Calculate();
        });

        $('#ReviewAccept').click(function () {
            event.preventDefault();
            ChangeStatus(10, 'Póliza emitida');
        });
        $('#ReviewCondition').click(function () {
            event.preventDefault();
            reviewMode = true;
            if (app.ui.IsValid('#RiskEdtFrm', false))
                ChangeStatus(4, 'Póliza condicionada');
            reviewMode = false;
        });
        $('#ReviewDecline').click(function () {
            event.preventDefault();
            reviewMode = true;
            if (app.ui.IsValid('#RiskEdtFrm', false))
                ChangeStatus(3, 'Póliza declinada');
            reviewMode = false;
        });
        $('#ReviewComplement').click(function () {
            event.preventDefault();
            reviewMode = true;
            if (app.ui.IsValid('#RiskEdtFrm', false))
                ChangeStatus(5, 'Complementos solicitados');
            reviewMode = false;
        });
        $('#AcceptCondition').click(function () {
            event.preventDefault();
            ChangeStatus(10, 'Póliza emitida');
        });
        $('#AcceptDecline').click(function () {
            event.preventDefault();
            ChangeStatus(3, 'Póliza declinada');
        });
        $('#AcceptComplement').click(function () {
            event.preventDefault();
            ChangeStatus(2, 'Póliza en revisión');
        });


        $('#AcceptCancellation').click(function () {
            event.preventDefault();
            if (app.ui.IsValid('#RiskEdtFrm', false))
                ChangeStatus(11, 'Póliza cancelada');
        });

        $("#Surcharge").blur(function () {
            let surcharge = app.ui.GetNumericValue('#Surcharge');
            let premium = app.ui.GetNumericValue('#MonthlyPremium');
            let AnnualPremium = app.ui.GetNumericValue('#AnnualPremium');
            if (surcharge > 0) {
                premium = premium * (1 + surcharge / 100);
                AnnualPremium = AnnualPremium * (1 + surcharge / 100);
                app.ui.SetNumericValue('#TotalPremium', premium);
                app.ui.SetNumericValue('#TotalAnnualPremium', AnnualPremium);
            }
            else {
                app.ui.SetNumericValue('#TotalPremium', premium);
                app.ui.SetNumericValue('#TotalAnnualPremium', AnnualPremium);
            }
        });

        $('#ContractorName').change(function () {
            $('#MainPolicyId').val($('#ContractorName').val());
        });
    };

    function Calculate() {
        if (app.ui.IsElementValid('#RiskEdtFrm', '#ModuleCode') &&
            app.ui.IsElementValid('#RiskEdtFrm', '#InsuredAmount')) {

            AutoNumeric.set("#InsuredAmount", AutoNumeric.getNumber('#InsuredAmountBase') + AutoNumeric.getNumber('#InsuredAmountComplement'));

            var insuredAmount = AutoNumeric.getNumber('#InsuredAmount');
            var moduleCode = parseInt(0 + $('#ModuleCode').val(), 10);

            AutoNumeric.set("#AnnualPremium", 0);
            AutoNumeric.set("#MonthlyPremium", 0);
            if (moduleCode !== 0 && insuredAmount !== 0)
                app.core.Post(app.setting.apipath + 'v1/Rating/Asegurado?productAlias=' + productAlias + '&currency=' + parseInt(0 + $('#Currency').val(), 10) + '&moduleCode=' + moduleCode + '&paymentFrequency=' + parseInt(0 + $('#PaymentFrequency').val(), 10) + '&insuredAmount=' + insuredAmount + "&birthDate=" + app.ui.GetDateValue('#BirthDate'), null,
                    function (data) {
                        app.ui.SetNumericValue("#AnnualPremium", data.AnnualPremium);
                        app.ui.SetNumericValue("#MonthlyPremium", data.MonthlyPremium);
                        app.ui.SetNumericValue('#TotalAnnualPremium', data.AnnualPremium);
                        app.ui.SetNumericValue('#TotalPremium', data.MonthlyPremium);
                    });

            app.poliza.PageBehavior();
        }
        else {
            app.ui.SetNumericValue("#AnnualPremium", 0);
            app.ui.SetNumericValue("#MonthlyPremium", 0);
            app.ui.SetNumericValue('#TotalAnnualPremium', 0);
            app.ui.SetNumericValue('#TotalPremium', 0);
        }
    };

    function Custom_Validations() {
        $.validator.addMethod("AgeRangePlan",
            function (value, element) {
                var notError = true;
                var age = moment().diff($('#BirthDate_group').data('DateTimePicker').date(), 'years');
                if (Number.isNaN(age)) {

                    $('#ModuleCode').rules('add', { messages: { AgeRangePlan: 'Se debe indicar la fecha de nacimiento del asegurado' } });

                    //$('#RiskEdtFrm').validate().showErrors({'ModuleCode': 'Se debe indicar la fecha de nacimiento del asegurado'});
                    notError = false;
                }
                else {
                    var currentModule = app.poliza.Modules().filter(function (item) {
                        return item.Code == value;
                    });
                    if (currentModule.length > 0) {
                        if (currentModule[0].MinimumAge > 0 && age < currentModule[0].MinimumAge) {
                            $('#ModuleCode').rules('add', { messages: { AgeRangePlan: 'La edad del asegurado (' + age + ') esta fuera el rango de ' + currentModule[0].MinimumAge + ' a ' + currentModule[0].MaximumAge + ' años' } });
                            notError = false;
                        }
                        else if (currentModule[0].MaximumAge > 0 && age > currentModule[0].MaximumAge) {
                            $('#ModuleCode').rules('add', { messages: { AgeRangePlan: 'La edad del asegurado (' + age + ') esta fuera el rango de ' + currentModule[0].MinimumAge + ' a ' + currentModule[0].MaximumAge + ' años' } });
                            notError = false;
                        }
                    }
                }
                return notError;
            }
        );
        $.validator.addMethod("InsuredAmountByPlan",
            function (value, element) {
                var notError = true;

                if (!$('#RiskEdtFrm').validate().element("#ModuleCode")) {

                    $('#InsuredAmount').rules('add', { messages: { InsuredAmountByPlan: 'Debe indicar un plan valido' } });

                    //$('#RiskEdtFrm').validate().showErrors({'ModuleCode': 'Se debe indicar la fecha de nacimiento del asegurado'});
                    notError = false;
                }
                else {
                    var currentModule = app.poliza.Modules().filter(function (item) {
                        return item.Code == $('#ModuleCode').val();
                    });
                    if (currentModule.length > 0) {
                        var ctrolValue = AutoNumeric.getNumber('#InsuredAmount');
                        if (currentModule[0].MinimumInsuredAmount > 0 && ctrolValue < currentModule[0].MinimumInsuredAmount) {
                            $('#InsuredAmount').rules('add', { messages: { InsuredAmountByPlan: 'La suma asegurada esta fuera del rango permitido de {0} a {1}'.format(app.ui.NumericValueFormat(currentModule[0].MinimumInsuredAmount, 2), app.ui.NumericValueFormat(currentModule[0].MaximumInsuredAmount, 2)) } });
                            notError = false;
                        }
                        else if (currentModule[0].MaximumInsuredAmount > 0 && ctrolValue > currentModule[0].MaximumInsuredAmount) {
                            $('#InsuredAmount').rules('add', { messages: { InsuredAmountByPlan: 'La suma asegurada esta fuera del rango permitido de {0} a {1}'.format(app.ui.NumericValueFormat(currentModule[0].MinimumInsuredAmount, 0), app.ui.NumericValueFormat(currentModule[0].MaximumInsuredAmount, 2)) } });
                            notError = false;
                        }
                    }
                }
                return notError;
            }
        );
        $.validator.addMethod("CommentReview",
            function (value, element, params) {
                if (reviewMode)
                    return (value !== '');
                else
                    return true;
            }
        );
    };

    function Setup_Validations() {
        Custom_Validations();
        $("#RiskEdtFrm").validate({
            errorPlacement: function (error, element) {
                var name = $(element).attr("name");
                var $obj = $("#" + name + "_validate");
                if ($obj.length) {
                    error.appendTo($obj);
                }
                else {
                    error.insertAfter(element);
                }
            },
            onkeyup: function (element) {
                if ($(element).attr('name') !== 'InsuredAmount') {
                    $.validator.defaults.onkeyup.apply(this, arguments);
                }
            },
            rules: {
                ModuleCode: {
                    required: true,
                    AgeRangePlan: true
                },
                IssueDate: {
                    required: true
                },
                InsuredAmount: {
                    required: true,
                    InsuredAmountByPlan: true
                },
                Comments: {
                    CommentReview: true
                },
                CancellationDate: {
                    required: true
                },
                ReasonForStatus: {
                    required: true
                },
                ContractorName: { required: true }
            },
            messages: {
                ModuleCode: {
                    required: 'Debe indicar el plan',
                    AgeRangePlan: ''
                },
                IssueDate: {
                    required: 'Debe indicar la fecha de alta'
                },
                InsuredAmount: {
                    required: 'Debe indicar la suma asegurada',
                    InsuredAmountByPlan: ''
                },
                Comments: {
                    CommentReview: 'Debe indicar una observación'
                },
                CancellationDate: {
                    required: 'Debe indicar la fecha de baja'
                },
                ReasonForStatus: {
                    required: 'Debe indicar la causa de la baja'
                },
                ContractorName: { required: 'Debe indicar la filial' }
            }

        });
    };

    var _inputToObject = function () {
        var data = {
            ProductAlias: productAlias,
            Currency: app.ui.GetDropDownNumericValue('#Currency'),
            ModuleCode: app.ui.GetDropDownNumericValue('#ModuleCode'),
            PaymentFrequency: app.ui.GetDropDownNumericValue('#PaymentFrequency'),
            IssueDate: app.ui.GetDateValue('#IssueDate'),
            EffectiveDate: app.ui.GetDateValue('#EffectiveDate'),
            EndingDate: app.ui.GetDateValue('#EndingDate'),
            InsuredAmountBase: app.ui.GetNumericValue('#InsuredAmountBase'),
            InsuredAmountComplement: app.ui.GetNumericValue('#InsuredAmountComplement'),
            InsuredAmount: app.ui.GetNumericValue('#InsuredAmount'),
            AnnualPremium: app.ui.GetNumericValue('#AnnualPremium'),
            MonthlyPremium: app.ui.GetNumericValue('#MonthlyPremium'),
            Status: app.ui.GetDropDownNumericValue('#Status'),
            Surcharge: app.ui.GetNumericValue('#Surcharge'),
            Comments: $('#Comments').val(),
            Annotation: $('#Annotation').val(),
            MainPolicyId: $('#MainPolicyId').val(),
            ContractorName: app.ui.GetDropDownNumericValue('#ContractorName'),
            ContractorDesc: $("#ContractorName option:selected").text(),
        };
        return data;
    };

    var _objectToInput = function (data) {
        if (data !== null) {
            $('#Id').val(data.Id);
            $('#Currency').val(data.Currency);
            $('#ModuleCode').val(data.ModuleCode);
            $('#PaymentFrequency').val(data.PaymentFrequency);
            app.ui.SetDateValue('#IssueDate', data.IssueDate);
            app.ui.SetDateValue('#EffectiveDate', data.EffectiveDate);
            app.ui.SetDateValue('#EndingDate', data.EndingDate);
            app.ui.SetNumericValue('#InsuredAmountBase', data.InsuredAmountBase);
            app.ui.SetNumericValue('#InsuredAmountComplement', data.InsuredAmountComplement);
            app.ui.SetNumericValue('#InsuredAmount', data.InsuredAmount);
            app.ui.SetNumericValue('#AnnualPremium', data.AnnualPremium);
            app.ui.SetNumericValue('#MonthlyPremium', data.MonthlyPremium);
            $('#Status').val(data.Status);
            app.ui.SetNumericValue('#Surcharge', data.Surcharge);
            $('#Comments').val(data.Comments);
            $('#Annotation').val(data.Annotation);
            app.ui.SetDateValue('#CancellationDate', data.CancellationDate);
            $('#ReasonForStatus').val(data.ReasonForStatus);

            $('#MainPolicyId').val(data.ContractorName);
            app.ui.SetDropDownNumericValue('#ContractorName', data.ContractorName, true);

            if (data.Surcharge > 0) {
                let Annualvalue = data.AnnualPremium * (1 + data.Surcharge / 100);
                let Monthlyvalue = data.MonthlyPremium * (1 + data.Surcharge / 100);
                app.ui.SetNumericValue('#TotalAnnualPremium', Annualvalue);
                app.ui.SetNumericValue('#TotalPremium', Monthlyvalue);
            }
            else {
                app.ui.SetNumericValue('#TotalAnnualPremium', data.AnnualPremium);
                app.ui.SetNumericValue('#TotalPremium', data.MonthlyPremium);
            }

            app.poliza.PageBehavior();

            WorkMode(data.Status);
        }
    };

    function WorkMode(status) {
        switch (status) {
            case 1:
                $("#RiskEdtFrm fieldset").prop("disabled", false);
                break;
            case 2:
                if (localStorage.getItem('Roles').includes("Suscriptor")) {
                    $("#RiskEdtFrm fieldset").prop("disabled", false);

                    $('select#Currency').prop("disabled", true);
                    $('select#ModuleCode').prop("disabled", true);
                    $('select#PaymentFrequency').prop("disabled", true);
                    $('#IssueDate').prop("disabled", true);
                    $('#EffectiveDate').prop("disabled", true);
                    $('#EndingDate').prop("disabled", true);
                    $('#InsuredAmount').prop("disabled", true);
                    $('#AnnualPremium').prop("disabled", true);
                    $('#MonthlyPremium').prop("disabled", true);

                    $('#Surcharge').parent().parent().removeClass('d-none');
                    $('#Surcharge').prop("disabled", false);

                    //$('#policyStatus').removeClass('d-none');
                    $('#policyComment').removeClass('d-none');
                    $('#Comments').prop("disabled", false);

                    $('#ReviewAccept').removeClass('d-none');
                    $('#ReviewCondition').removeClass('d-none');
                    $('#ReviewDecline').removeClass('d-none');
                    $('#ReviewComplement').removeClass('d-none');
                }
                else {
                    $('select#ModuleCode').prop("disabled", true);
                    $('#IssueDate').prop("disabled", true);
                    $('#InsuredAmount').prop("disabled", true);
                }
                break;

            case 4:
                $("#RiskEdtFrm fieldset").prop("disabled", false);

                $('select#Currency').prop("disabled", true);
                $('select#ModuleCode').prop("disabled", true);
                $('select#PaymentFrequency').prop("disabled", true);
                $('#IssueDate').prop("disabled", true);
                $('#EffectiveDate').prop("disabled", true);
                $('#EndingDate').prop("disabled", true);
                $('#InsuredAmount').prop("disabled", true);
                $('#AnnualPremium').prop("disabled", true);
                $('#MonthlyPremium').prop("disabled", true);

                $('#Surcharge').parent().removeClass('d-none');

                //$('#policyStatus').removeClass('d-none');
                $('#policyComment').removeClass('d-none');

                $('#AcceptCondition').removeClass('d-none');
                $('#AcceptDecline').removeClass('d-none');
                $('#AcceptComplement').removeClass('d-none');

                break;
            case 5:
                $("#RiskEdtFrm fieldset").prop("disabled", true);
                $('#Surcharge').parent().parent().removeClass('d-none');
                $('#policyComment').removeClass('d-none');
                $('#AcceptComplement').removeClass('d-none');
                break;
            case 10:
                if (app.PolicyEdit.NavegationMode() === 'cancel') {
                    $("#RiskEdtFrm fieldset").prop("disabled", false);

                    $('select#Currency').prop("disabled", true);
                    $('select#ModuleCode').prop("disabled", true);
                    $('select#PaymentFrequency').prop("disabled", true);
                    $('#IssueDate').prop("disabled", true);
                    $('#EffectiveDate').prop("disabled", true);
                    $('#EndingDate').prop("disabled", true);
                    $('#InsuredAmount').prop("disabled", true);
                    $('#AnnualPremium').prop("disabled", true);
                    $('#MonthlyPremium').prop("disabled", true);

                    $('#Surcharge').parent().parent().removeClass('d-none');
                    $('#Status').prop("disabled", true);
                    $('#AcceptCancellation').removeClass('d-none');

                    $('#CancellationDate').prop("disabled", false);
                    $('#ReasonForStatus').prop("disabled", false);
                    $('#policyStatusZone').removeClass('d-none');
                }
                else {
                    $("#RiskEdtFrm fieldset").prop("disabled", true);
                    $('#Surcharge').parent().parent().removeClass('d-none');
                    $('#policyComment').removeClass('d-none');
                }
                break;

            default:
                $("#RiskEdtFrm fieldset").prop("disabled", true);
                $('#Surcharge').parent().parent().removeClass('d-none');
                break;
        }
    }

    function ChangeStatus(newStatus, notifyMessage) {
        var data = {
            Id: $('#Id').val(),
            NewStatus: newStatus,
            Surcharge: app.ui.GetNumericValue('#Surcharge'),
            Comments: $('#Comments').val(),
            CancellationDate: app.ui.GetDateValue('#CancellationDate'),
            ReasonForStatus: app.ui.GetDropDownNumericValue('#ReasonForStatus')
        };

        app.core.Put(app.setting.apipath + 'v1/Policy/ChangeStatus', JSON.stringify(data),
            function (data) {
                app.PolicyEdit.WorkMode(data.Status, data.StatusDesc);
                app.ui.ShowAlert('generalNotify', 'alert-success', data.Message);
                toastr.success(notifyMessage, "", { timeOut: 5000, closeButton: true, progressBar: true });
            }).always(function () {

            });
    }

    return {
        Init: function () {
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Setup_Validations();
        },
        InputToObject: _inputToObject,
        ObjectToInput: _objectToInput,
        IsValid: function () {
            var instance = $('#RiskEdtFrm');
            var validate = instance.validate();
            validate.settings.ignore = '';
            reviewMode = false;
            var result = instance.valid();
            var count = validate.numberOfInvalids();
            validate.settings.ignore = ':hidden';
            if (count > 0)
                $('#polizaHTab .badge').html(count);
            else
                $('#polizaHTab .badge').html('');
            return result;
        },
        Modules: function () {
            return productModules;
        },
        EntryAllowed: function () {
            return EntryAllowed == null ? '' : EntryAllowed;
        },
        Behavior: function (productKey, callback) {
            productAlias = productKey;
            ProductDefinition(callback);
        },
        PageBehavior: function () {
            let ds = app.poliza.EntryAllowed().includes(";Questionnaires;");
            let cv = app.poliza.EntryAllowed().includes(";Covid;");
            if (ds || cv) {
                data = app.poliza.EvalBehavior();
                if (ds && data.Behavior.includes("Show.DS")) {
                    $('#saludTabHeader').removeClass('d-none');
                } else {
                    $('#saludTabHeader').addClass('d-none');
                }

                if (cv && data.Behavior.includes("Show.CV")) {
                    $('#covidTabHeader').removeClass('d-none');
                } else {
                    $('#covidTabHeader').addClass('d-none');
                }
            }

        }
    };
})();
$(document).ready(function () {
    app.poliza.Init();
});