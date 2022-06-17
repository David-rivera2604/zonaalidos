var app = app || {};
app.asegurado = (function () {

    var documentNumber;

    function Init_Controls() {
        var yesterday = new Date();
        yesterday.setDate(yesterday.getDate() - 1);

        documentNumber = $('#DocumentNumber').formatter({
            pattern: '0{{9}}-{{9999}}-{{9999}}',
            persistent: false
        });

        $('#BirthDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: yesterday
        });
        $('#BirthDate_group').data("DateTimePicker").date(null);
        new AutoNumeric('#Height', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '9.99',
            minimumValue: '0',
            decimalPlaces: 2
        });
        new AutoNumeric('#Weight', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: 0
        });
        new AutoNumeric('#BloodPressureSystolic', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#BloodPressureDiastolic', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        $('#PhoneNumber').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
    };

    function Init_Lookups() {
        app.core.Lookups(['@Gender', 'CivilStatus', 'CR_Provincia.Province.',
            '@RetirementModality'], Dynamic_Event_Controls);

        // Dependencies
        $('#Province').on('change', function () {
            app.core.LookupDependency($('select#Province').val(), 'Canton', 'CR_Canton', '', null, true);
        });
        $('#Canton').on('change', function () {
            app.core.LookupDependency($('select#Canton').val(), 'District', 'CR_Distritos', '', null, false);
        });
    };

    function Event_Controls() {

        $('#DocumentTypeMenu a').click(function () {
            var btn = $(this).parent().parent().find('.btn');
            var value = $(this).data('value');
            btn.text($(this).text());
            btn.data('value', value);
            event.preventDefault();

            switch (value) {
                case 1: //10 DIGITOS Y DEBE INICIAR CON “0”: 0X-XXXX-XXXX
                    documentNumber.resetPattern('0{{9}}-{{9999}}-{{9999}}');
                    $('#DocumentNumber').attr('placeholder', '0X-XXXX-XXXX');
                    break;
                case 2: //12 DÍGITOS Y DEBE INICIAR CON “1”: 1XXX-XXXXXX-XX
                    documentNumber.resetPattern('1{{999}}-{{999999}}-{{99}}');
                    $('#DocumentNumber').attr('placeholder', '1XXX-XXXXXX-XX');
                    break;
                case 3: //14 DÍGITOS: XXXXXXXXXXXXXX
                    documentNumber.resetPattern('{{**************}}');
                    $('#DocumentNumber').attr('placeholder', 'XXXXXXXXXXXXXX');
                    break;
                case 4:
                    documentNumber.resetPattern('{{99999999999999999}}');
                    $('#DocumentNumber').attr('placeholder', 'XXXXXXXXXXXXXXXXX');
                    break;
            }

        });

        $("#DocumentNumber").on('blur', function () {
            if (app.policy_common.IsDocumentNumberValida($("#DocumentType").data("value"), $('#DocumentNumber').val())) {
                var value = $('#DocumentNumber').val().replace(/-/g, '');
                if (value !== null && parseInt(0 + value, 10) !== 0 && parseInt(0 + value, 10) <= 999999999) {
                    $('#DocumentNumber').addClass('loading');
                    app.core.Get(app.setting.apipath + 'v1/Insured/' + parseInt(0 + value, 10))
                        .done(function (data, textStatus, jqXHR) {
                            if (data != null && data.FirstName !== null) {
                                $('#FirstName').val(data.FirstName);
                                $('#MiddleName').val(data.MiddleName);
                                $('#LastName').val(data.LastName);
                                $('#SecondLastName').val(data.SecondLastName);
                                app.ui.SetDateValue('#BirthDate', data.BirthDate);
                                if ($('input:radio[name=Gender][value=' + data.Gender + ']').length === 0)
                                    $('input:radio[name=Gender]').prop('checked', false);
                                else
                                    $($('input:radio[name=Gender][value=' + data.Gender + ']')).prop('checked', true);
                                $('#CivilStatus').val(data.CivilStatus);
                                $('#PhoneNumber').val(data.PhoneNumber);
                                $('#PrimaryEmailAddress').val(data.PrimaryEmailAddress);
                                $('#Province').val(data.Province);
                                app.core.LookupDependency($('select#Province').val(), 'Canton', 'CR_Canton', '', data.Canton, false,
                                    function () {
                                        app.core.LookupDependency($('select#Canton').val(), 'District', 'CR_Distritos', '', data.District, false);
                                    });
                                $('#AddressDetail').val(data.AddressDetail);
                                Event_Handler();
                            }
                        }).always(function () {
                            $('#DocumentNumber').removeClass('loading');
                        });

                    app.core.Get(app.setting.apipath + 'v1/Policy/Loans?documentNumber=' + parseInt(0 + value, 10))
                        .done(function (data, textStatus, jqXHR) {
                            //101700267
                            //102160744
                            app.ui.SetNumericValue('#Amount1', 0);
                            app.ui.SetDateValue('#EndTermOnAmount1', null);
                            $('.recastplace1').addClass('d-none');
                            app.ui.SetNumericValue('#Amount2', 0);
                            app.ui.SetDateValue('#EndTermOnAmount2', null);
                            $('.recastplace2').addClass('d-none');
                            app.ui.SetNumericValue('#Amount3', 0);
                            app.ui.SetDateValue('#EndTermOnAmount3', null);
                            $('.recastplace3').addClass('d-none');
                            app.ui.SetNumericValue('#Amount4', 0);
                            app.ui.SetDateValue('#EndTermOnAmount4', null);
                            $('.recastplace4').addClass('d-none');
                            app.ui.SetNumericValue('#Amount5', 0);
                            app.ui.SetDateValue('#EndTermOnAmount5', null);
                            $('.recastplace5').addClass('d-none');
                            if (data.length > 0) {
                                $('.recastplace').removeClass('d-none');
                                $('#RecastTotal').parent().parent().removeClass('d-none');
                            } else {
                                $('.recastplace').addClass('d-none');
                                $('#RecastTotal').parent().parent().addClass('d-none');
                            }

                            $.each(data, function (index, value) {
                                switch (index) {
                                    case 0:
                                        app.ui.SetNumericValue('#Amount1', value.Balance);
                                        app.ui.SetDateValue('#EndTermOnAmount1', value.EndTerm);
                                        $('.recastplace1').removeClass('d-none');
                                        break;
                                    case 1:
                                        app.ui.SetNumericValue('#Amount2', value.Balance);
                                        app.ui.SetDateValue('#EndTermOnAmount2', value.EndTerm);
                                        $('.recastplace2').removeClass('d-none');
                                        break;
                                    case 2:
                                        app.ui.SetNumericValue('#Amount3', value.Balance);
                                        app.ui.SetDateValue('#EndTermOnAmount3', value.EndTerm);
                                        $('.recastplace3').removeClass('d-none');
                                        break;
                                    case 3:
                                        app.ui.SetNumericValue('#Amount4', value.Balance);
                                        app.ui.SetDateValue('#EndTermOnAmount4', value.EndTerm);
                                        $('.recastplace4').removeClass('d-none');
                                        break;
                                    case 4:
                                        app.ui.SetNumericValue('#Amount5', value.Balance);
                                        app.ui.SetDateValue('#EndTermOnAmount5', value.EndTerm);
                                        $('.recastplace5').removeClass('d-none');
                                        break;
                                }
                            });
                        });

                    app.core.Get(app.setting.apipath + 'v1/Insured/' + parseInt(0 + value, 10) + '/Questionary/Covid')
                        .done(function (data) {
                            app.cuestionariocovid.ObjectToInput(data);
                        });
                }
            }
        });

        $('#PhoneTypeMenu a').click(function () {
            var btn = $(this).parent().parent().find('.btn');
            var value = $(this).data('value');
            btn.text($(this).text());
            btn.data('value', value);
            event.preventDefault();
        });

        $('#BirthDate').blur(function () {
            app.ui.IsElementValid('#RiskEdtFrm', '#ModuleCode');
            Event_Handler();
            let age = moment().diff($('#BirthDate_group').data('DateTimePicker').date(), 'years');
            $('#BirthDate').attr('title', `${age} años`);
        });

    };

    function Dynamic_Event_Controls() {

        $('input:radio[name=Gender]').on('change', function () {
            Event_Handler();
        });

        $('input:radio[name=RetirementModality]').on('change', function () {
            $('#RetirementCause').prop("disabled", (this.value !== '2'));


            //var formInstance1 = $("#PrimaryInsuredEdtFrm");
            //var fvalidate = formInstance1.validate();
            //if (formInstance1.valid()) {
            //    alert("Not errors");
            //}
            //else {
            //    alert("with errors");
            //}

            //var formInstance2 = $("#PolicyEdtFrm");
            //var fvalidate2 = formInstance2.validate();
            //if (formInstance2.valid()) {
            //    alert("Not errors");
            //}
            //else {
            //    alert("with errors");
            //}

        });
    };

    function Event_Handler() {
        app.poliza.PageBehavior();
        app.cuestionario.UIBehavior($('input:radio[name=Gender]:checked').val(), $('#BirthDate_group').data('DateTimePicker').date());
    };


    function Setup_Validations() {
        app.ui.DateValidators();

        $.validator.addMethod("AgeGreaterThan64",
            function (value, element) {
                var notError = true;
                var age = moment().diff($('#BirthDate_group').data('DateTimePicker').date(), 'years');
                if (!Number.isNaN(age)) {
                    if (age > 64 && app.ui.GetNumericValue('#' + element.id) === 0) {
                        notError = false;
                    }
                }
                return notError;
            }
        );

        $.validator.addMethod("InsuredHasPolicies",
            function (value, element, params) {
                if (app.policy_common.IsDocumentNumberValida($("#DocumentType").data("value"), value)) {
                    var validator = this;
                    validator.startRequest(element);
                    app.core.Get(app.setting.apipath + 'v1/Policy/InsuredHasPolicies?productAlias=' + app.PolicyEdit.ProductAlias() + '&recordId=' + app.PolicyEdit.Id() + '&documentType=' + $("#DocumentType").data("value") + '&documentNumber=' + value)
                        .done(function (data, textStatus, jqXHR) {
                            app.core.ValidatorRemoteIsValid(validator, element, 'InsuredHasPolicies');
                        }).fail(function (jqXHR, textStatus, errorThrown) {
                            switch (jqXHR.status) {
                                case 404:
                                    app.core.ValidatorRemoteIsNotValid(validator, element);
                                    break;
                            }
                        });
                    return 'pending';
                }
                else
                    return true;
            }
        );
        //   $('#RePassword').rules('add', { messages: { RePassword_Validate2: messageRePassword }});
        $.validator.addMethod("DocumentNumberLength",
            function (value, element, params) {
                return app.policy_common.IsDocumentNumberValida($("#DocumentType").data("value"), value);
            }
        );

        $("#PrimaryInsuredEdtFrm").validate({
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
                if ($(element).attr('name') !== 'DocumentNumber') {
                    $.validator.defaults.onkeyup.apply(this, arguments);
                }
            },
            rules: {
                DocumentType: {
                    required: true
                },
                DocumentNumber: {
                    required: true,
                    DocumentNumberLength: true,
                    InsuredHasPolicies: true
                },
                FirstName: {
                    required: true
                },
                LastName: {
                    required: true
                },
                BirthDate: {
                    required: true,
                    BirthDate: true
                },
                Gender: {
                    required: true
                },
                CivilStatus: {
                    required: true
                },
                Height: {
                    AgeGreaterThan64: true
                },
                Weight: {
                    AgeGreaterThan64: true
                },
                PhoneNumber: {
                    minlength: 9
                },
                PrimaryEmailAddress: {
                    email: true,
                    required: true
                },
                Province: {
                    required: true
                },
                Canton: {
                    required: true
                },
                District: {
                    required: true
                },
                AddressDetail: {
                    required: true
                }

            },
            messages: {
                DocumentType: {
                    required: 'Debe indicar el tipo de identificación'
                },
                DocumentNumber: {
                    required: 'Debe indicar la identificación',
                    DocumentNumberLength: 'Faltan digitos a la identificación',
                    InsuredHasPolicies: 'El asegurado ya tiene registrada una póliza para este producto'
                },
                FirstName: {
                    required: 'Debe indicar el primer nombre'
                },
                LastName: {
                    required: 'Debe indicar el primer apellido'
                },
                BirthDate: {
                    required: 'Debe indicar la fecha de nacimiento',
                    BirthDate: 'Ingrese una fecha inferior al día de hoy'
                },
                Gender: {
                    required: 'Debe indicar el sexo'
                },
                CivilStatus: {
                    required: 'Debe indicar el estado civil'
                },
                Height: {
                    AgeGreaterThan64: 'Para mayores de 65 años se debe indicar la estatura'
                },
                Weight: {
                    AgeGreaterThan64: 'Para mayores de 65 años se debe indicar la peso'
                },
                PhoneNumber: {
                    minlength: 'Debe indicar 8 dígitos'
                },
                PrimaryEmailAddress: {
                    email: 'Debe indicar un correo electrónico valido',
                    required: 'Debe indicar el correo electrónico'
                },
                Province: {
                    required: 'Debe indicar la provincia'
                },
                Canton: {
                    required: 'Debe indicar el cantón'
                },
                District: {
                    required: 'Debe indicar el distrito'
                },
                AddressDetail: {
                    required: 'Debe indicar la dirección'
                }
            }
        });
    };

    var _inputToObject = function () {
        var data = {
            DocumentType: $("#DocumentType").data("value"),
            DocumentNumber: $('#DocumentNumber').val(),
            FirstName: $('#FirstName').val(),
            MiddleName: $('#MiddleName').val(),
            LastName: $('#LastName').val(),
            SecondLastName: $('#SecondLastName').val(),
            BirthDate: app.ui.GetDateValue('#BirthDate'),
            Gender: $('input:radio[name=Gender]:checked').val(),
            CivilStatus: $('#CivilStatus').val(),
            Height: app.ui.GetNumericValue('#Height'),
            Weight: app.ui.GetNumericValue('#Weight'),
            BloodPressureSystolic: app.ui.GetNumericValue('#BloodPressureSystolic'),
            BloodPressureDiastolic: app.ui.GetNumericValue('#BloodPressureDiastolic'),
            PhoneType: $("#PhoneType").data("value"),
            PhoneNumber: $('#PhoneNumber').val(),
            PrimaryEmailAddress: $('#PrimaryEmailAddress').val(),
            Province: $('#Province').val(),
            Canton: $('#Canton').val(),
            District: $('#District').val(),
            AddressDetail: $('#AddressDetail').val(),
            Occupation: $('#Occupation').val(),
            RetirementModality: $('input:radio[name=RetirementModality]:checked').val(),
            RetirementCause: $('#RetirementCause').val(),
            HasDigitalSignature: $('input:radio[name=HasDigitalSignature]:checked').val() === "1"
        };
        return data;
    };

    var _objectToInput = function (data) {
        if (data !== null) {

            $('#DocumentType').data('value', data.DocumentType);
            $('#DocumentType').text($('#DocumentType').parent().find('#DocumentTypeMenu a[data-value=' + data.DocumentType + ']').text());
            $('#DocumentNumber').val(data.DocumentNumber);
            $('#FirstName').val(data.FirstName);
            $('#MiddleName').val(data.MiddleName);
            $('#LastName').val(data.LastName);
            $('#SecondLastName').val(data.SecondLastName);
            app.ui.SetDateValue('#BirthDate', data.BirthDate)
            $($('input:radio[name=Gender][value=' + data.Gender + ']')).prop('checked', true);
            Event_Handler();
            $('#CivilStatus').val(data.CivilStatus);
            app.ui.SetNumericValue('#Height', data.Height);
            app.ui.SetNumericValue('#Weight', data.Weight);
            app.ui.SetNumericValue('#BloodPressureSystolic', data.BloodPressureSystolic === 0 ? null : data.BloodPressureSystolic);
            app.ui.SetNumericValue('#BloodPressureDiastolic', data.BloodPressureDiastolic === 0 ? null : data.BloodPressureDiastolic);
            $('#PhoneType').data('value', data.PhoneType);
            $('#PhoneType').text($('#PhoneType').parent().find('#PhoneTypeMenu a[data-value=' + data.PhoneType + ']').text());
            $('#PhoneNumber').val(data.PhoneNumber);
            $('#PrimaryEmailAddress').val(data.PrimaryEmailAddress);
            $('#Province').val(data.Province);

            app.core.LookupDependency(data.Province, 'Canton', 'CR_Canton', '', data.Canton, false);
            app.core.LookupDependency(data.Canton, 'District', 'CR_Distritos', '', data.District, false);
            $('#AddressDetail').val(data.AddressDetail);
            $('#Occupation').val(data.Occupation);
            $($('input:radio[name=RetirementModality][value=' + data.RetirementModality + ']')).prop('checked', true);
            $('#RetirementCause').val(data.RetirementCause);
            $('input:radio[name=HasDigitalSignature][value=' + (data.HasDigitalSignature ? 1 : 2) + ']').prop('checked', true);
        }
    };

    return {
        Init: function () {
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Dynamic_Event_Controls();
            Setup_Validations();
        },
        InputToObject: _inputToObject,
        ObjectToInput: _objectToInput,
        IsValid: function () {
            var instance = $('#PrimaryInsuredEdtFrm');
            var validate = instance.validate();

            validate.settings.ignore = '';
            var result = instance.valid();
            var count = validate.numberOfInvalids();
            validate.settings.ignore = ':hidden';
            if (count > 0)
                $('#aseguradoHTab .badge').html(count);
            else
                $('#aseguradoHTab .badge').html('');
            return result;
        },
        WorkMode: function (status, navegationMode) {

            if (navegationMode === 'modify') {
                $("#PrimaryInsuredEdtFrm fieldset").prop("disabled", false);

                $('#BirthDate').prop("disabled", true);


                var age = moment().diff($('#BirthDate_group').data('DateTimePicker').date(), 'years');
                if (age > 64) {
                    $('#Height').prop("disabled", true);
                    $('#Weight').prop("disabled", true);
                }
            }
            else {
                var disabled = status != 1;
                $("#PrimaryInsuredEdtFrm fieldset").prop("disabled", disabled);
            }
        }
    };
})();
$(document).ready(function () {
    app.asegurado.Init();
});
