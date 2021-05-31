var app = app || {};
app.beneficiarios = (function () {

    var documentNumber;
    var beneficiaryRows = [];
    var beneficiaryRequired = true;

    var _edit = function (id) {
        var row = beneficiaryRows.filter(function (item) {
            return item.RoleId === id;
        });
        if (row.length > 0) {
            $('#beneficiarios').addClass('d-none');
            $('#beneficiariosEdt').removeClass('d-none');
            rowToInput(row[0]);
        }
    };

    function Init_Controls() {
        var today = new Date();
        documentNumber = $('#BDocumentNumber').formatter({
            pattern: '0{{9}}-{{9999}}-{{9999}}',
            persistent: false
        });

        $('#BBirthDate_group').datetimepicker(
            {
                format: 'DD/MM/YYYY',
                locale: 'es',
                maxDate: today
            });

        $('#BPhoneNumber').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });

        new AutoNumeric('#BParticipationRate', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '100',
            minimumValue: '1',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
    };

    function Init_Lookups() {
        app.core.Lookups(['@Gender.BGender', 'CivilStatus.BCivilStatus', 'CR_Provincia.BProvince.', 'Relationship.BRelationship'], Dynamic_Event_Controls);

        // Dependencies
        $('#BProvince').on('change', function () {
            app.core.LookupDependency($('select#BProvince').val(), 'BCanton', 'CR_Canton', '', null, true);
        });
        $('#BCanton').on('change', function () {
            app.core.LookupDependency($('select#BCanton').val(), 'BDistrict', 'CR_Distritos', '', null, false);
        });
    };

    function Event_Controls() {

        $('#BDocumentTypeMenu a').click(function () {
            var btn = $(this).parent().parent().find('.btn');
            var value = $(this).data('value');
            btn.text($(this).text());
            btn.data('value', value);
            event.preventDefault();

            switch (value) {
                case 1: //10 DIGITOS Y DEBE INICIAR CON “0”: 0X-XXXX-XXXX
                    documentNumber.resetPattern('0{{9}}-{{9999}}-{{9999}}');
                    $('#BDocumentNumber').attr('placeholder', '0X-XXXX-XXXX');
                    break;
                case 2: //12 DÍGITOS Y DEBE INICIAR CON “1”: 1XXX-XXXXXX-XX
                    documentNumber.resetPattern('1{{999}}-{{999999}}-{{99}}');
                    $('#BDocumentNumber').attr('placeholder', '1XXX-XXXXXX-XX');
                    break;
                case 3: //14 DÍGITOS: XXXXXXXXXXXXXX
                    documentNumber.resetPattern('{{**************}}');
                    $('#DocumentNumber').attr('placeholder', 'XXXXXXXXXXXXXX');
                    break;
                case 4:
                    documentNumber.resetPattern('{{99999999999999999}}');
                    $('#BDocumentNumber').attr('placeholder', 'XXXXXXXXXXXXXXXXX');
                    break;
            }
        });

        $("#BDocumentNumber").on('blur', function () {
            if (app.policy_common.IsDocumentNumberValida($("#BDocumentType").data("value"), $('#BDocumentNumber').val())) {
                var value = $('#BDocumentNumber').val().replace(/-/g, '');
                if (value !== null && parseInt(0 + value, 10) !== 0 && parseInt(0 + value, 10) <= 999999999) {
                    $('#BDocumentNumber').addClass('loading');
                    app.core.Get(app.setting.apipath + 'v1/Insured/' + value)
                        .done(function (data, textStatus, jqXHR) {
                            if (data.Nombre !== null) {
                                $('#BFirstName').val(data.Nombre);
                                $('#BMiddleName').val('');
                                $('#BLastName').val(data.ApellidoPaterno);
                                $('#BSecondLastName').val(data.ApellidoMaterno);

                                if ($('input:radio[name=BGender][value=' + data.CodigoSexo + ']').length === 0)
                                    $('input:radio[name=BGender]').prop('checked', false);
                                else
                                    $($('input:radio[name=BGender][value=' + data.CodigoSexo + ']')).prop('checked', true);

                                $('#BProvince').val(data.CodigoProvincia);
                                app.core.LookupDependency($('select#BProvince').val(), 'BCanton', 'CR_Canton', '', data.CodigoCanton, false,
                                    function () {
                                        app.core.LookupDependency($('select#BCanton').val(), 'BDistrict', 'CR_Distritos', '', data.CodigoDistrito, false);
                                    });
                            }
                        }).always(function () {
                            $('#BDocumentNumber').removeClass('loading');
                        });
                }
            }
        });

        $('#BPhoneTypeMenu a').click(function () {
            var btn = $(this).parent().parent().find('.btn');
            var value = $(this).data('value');
            btn.text($(this).text());
            btn.data('value', value);
            event.preventDefault();
        });

        $('#NewBeneficiary').click(function () {
            $('#beneficiarios').addClass('d-none');
            $('#beneficiariosEdt').removeClass('d-none');

            event.preventDefault();
        });

        $('#AddBeneficiary').click(function () {
            event.preventDefault();
            if (app.ui.IsValid('#beneficiaryEdtFrm', false)) {
                var row = _inputToObject();

                if (row.RoleId === 0) {
                    row.RoleId = beneficiaryRows.length + 1 * -1;
                    beneficiaryRows.push(row);
                }
                else {
                    $.each(beneficiaryRows, function (index, current) {
                        if (current.RoleId === row.RoleId) {
                            beneficiaryRows[index] = row;
                        }
                    });
                }
                TableRefresh(beneficiaryRows);

                $('#beneficiarios').removeClass('d-none');
                $('#beneficiariosEdt').addClass('d-none');

                CleanInput();
            }

        });

        $('#CancelBeneficiary').click(function () {
            $('#beneficiarios').removeClass('d-none');
            $('#beneficiariosEdt').addClass('d-none');
            event.preventDefault();
        });

    };

    function Dynamic_Event_Controls() {
    };
    app.ui.DateValidators();

    $.validator.addMethod("BDocumentNumberLength",
        function (value, element, params) {
            return app.policy_common.IsDocumentNumberValida($("#BDocumentType").data("value"), value);
        }
    );

    function Setup_Validations() {
        $("#beneficiaryEdtFrm").validate({
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
            rules: {
                BDocumentType: {
                    required: true
                },
                BDocumentNumber: {
                    required: true,
                    BDocumentNumberLength: true
                },
                BFirstName: {
                    required: true
                },
                BLastName: {
                    required: true
                },
                BBirthDate: {
                    required: true,
                    BirthDate: true
                },
                BPhoneNumber: {
                    minlength: 9
                },
                BPrimaryEmailAddress: {
                    email: true
                },
                BRelationship: {
                    required: true
                },
                BParticipationRate: {
                    required: true
                }
            },
            messages: {
                BDocumentType: {
                    required: 'Debe indicar el tipo de identificación'
                },
                BDocumentNumber: {
                    required: 'Debe indicar la identificación',
                    BDocumentNumberLength: 'Faltan digitos a la identificación'
                },
                BFirstName: {
                    required: 'Debe indicar el primer nombre'
                },
                BLastName: {
                    required: 'Debe indicar el primer apellido'
                },
                BBirthDate: {
                    required: 'Debe indicar la fecha de nacimiento',
                    BirthDate: 'Ingrese una fecha inferior al día de hoy'
                },
                BPhoneNumber: {
                    minlength: 'Debe indicar 8 dígitos'
                },
                BPrimaryEmailAddress: {
                    email: 'Debe indicar un correo electrónico valido'
                },
                BRelationship: {
                    required: 'Debe indicar el parentesco'
                },
                BParticipationRate: {
                    required: 'Debe indicar la participación'
                }
            }
        });
    };

    function Validations() {
        var count = 0
        if (beneficiaryRequired && beneficiaryRows.length === 0) {
            count++;
            app.ui.ShowAlert('beneficiaryNotify', 'alert-danger', 'Debe existir al menos un beneficiario');
        }
        return count;
    }

    function DateFormatter(value, format) {
        if (value === null || value === '0001-01-01T00:00:00')
            value = '';
        else
            value = moment(value).format(format);

        return value;
    }

    function EstadoFormatter(value) {
        if (value === null || value === '0001-01-01T00:00:00')
            value = 'Alta';
        else
            value = 'Baja';

        return value;
    }

    function TableRefresh(data) {
        $('#beneficiarios tbody').html('');
        $.each(data, function (index, row) {
            $('#beneficiarios tbody').append('<tr><td><a href="javascript:app.beneficiarios.Edit(' + row.RoleId + ');">' + row.FirstName + ' ' + row.MiddleName + ' ' + row.LastName + ' ' + row.SecondLastName + '</a></td><td>' + row.ParticipationRate + '</td><td>' + row.RelationshipDesc + '</td><td>' + EstadoFormatter(row.ExclusionDate) + '</td><td>' + DateFormatter(row.InclusionDate, 'DD/MM/YYYY hh:mma') + '</td><td>' + DateFormatter(row.ExclusionDate, 'DD/MM/YYYY hh:mma') + '</td></tr>');
        });
        $('#beneficiarios').footable();
    };

    var _inputToObject = function () {
        var data = {
            RoleId: app.ui.GetHiddenNumericValue('#BRoleId'),
            DocumentType: $("#BDocumentType").data("value"),
            DocumentNumber: $('#BDocumentNumber').val(),
            FirstName: $('#BFirstName').val(),
            MiddleName: $('#BMiddleName').val(),
            LastName: $('#BLastName').val(),
            SecondLastName: $('#BSecondLastName').val(),
            BirthDate: app.ui.GetDateValue('#BBirthDate'),
            Gender: $('input:radio[name=BGender]:checked').val(),
            CivilStatus: $('#BCivilStatus').val(),
            PhoneType: $("#BPhoneType").data("value"),
            PhoneNumber: $('#BPhoneNumber').val(),
            PrimaryEmailAddress: $('#BPrimaryEmailAddress').val(),
            Province: $('#BProvince').val(),
            Canton: $('#BCanton').val(),
            District: $('#BDistrict').val(),
            AddressDetail: $('#BAddressDetail').val(),
            Relationship: $('#BRelationship').val(),
            RelationshipDesc: $('#BRelationship option:selected').text(),
            ParticipationRate: app.ui.GetNumericValue('#BParticipationRate'),
            InclusionDate: null,
            ExclusionDate: null
        };
        return data;
    };

    var _objectToInput = function (data) {
        if (data !== null && data.length > 0) {
            beneficiaryRows = data;
            $('#beneficiarios').removeClass('d-none');
            $('#beneficiariosEdt').addClass('d-none');
            TableRefresh(data);
        }
    };

    function rowToInput(data) {
        if (data !== null) {
            $('#BRoleId').val(data.RoleId);
            $('#BDocumentType').data('value', data.DocumentType);
            $('#BDocumentType').text($('#BDocumentType').parent().find('#BDocumentTypeMenu a[data-value=' + data.DocumentType + ']').text());
            $('#BDocumentNumber').val(data.DocumentNumber);
            $('#BFirstName').val(data.FirstName);
            $('#BMiddleName').val(data.MiddleName);
            $('#BLastName').val(data.LastName);
            $('#BSecondLastName').val(data.SecondLastName);
            app.ui.SetDateValue('#BBirthDate', data.BirthDate)
            $($('input:radio[name=BGender][value=' + data.Gender + ']')).prop('checked', true);
            $('#BCivilStatus').val(data.CivilStatus);
            $('#BPhoneType').data('value', data.PhoneType);
            $('#BPhoneType').text($('#BPhoneType').parent().find('#BPhoneTypeMenu a[data-value=' + data.PhoneType + ']').text());
            $('#BPhoneNumber').val(data.PhoneNumber);
            $('#BPrimaryEmailAddress').val(data.PrimaryEmailAddress);
            $('#BProvince').val(data.Province);
            app.core.LookupDependency(data.Province, 'BCanton', 'CR_Canton', '', data.Canton, false);
            app.core.LookupDependency(data.Canton, 'BDistrict', 'CR_Distritos', '', data.District, false);
            $('#BAddressDetail').val(data.AddressDetail);
            $('#BRelationship').val(data.Relationship);
            app.ui.SetNumericValue('#BParticipationRate', data.ParticipationRate);
        }
    };

    function CleanInput() {
        rowToInput({
            RoleId: null,
            DocumentType: 1,
            DocumentNumber: null,
            FirstName: null,
            MiddleName: null,
            LastName: null,
            SecondLastName: null,
            BirthDate: null,
            Gender: null,
            CivilStatus: null,
            PhoneType: 1,
            PhoneNumber: null,
            PrimaryEmailAddress: null,
            Province: null,
            Canton: null,
            District: null,
            AddressDetail: null,
            Relationship: null,
            RelationshipDesc: null,
            ParticipationRate: null,
            InclusionDate: null,
            ExclusionDate: null
        })
    };

    return {
        Init: function () {
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Dynamic_Event_Controls();
            Setup_Validations();
            CleanInput();
        },
        InputToObject: function () {
            return beneficiaryRows;
        },
        ObjectToInput: _objectToInput,
        Edit: _edit,
        IsValid: function () {
            var instance = $('#beneficiaryEdtFrm');
            var validate = instance.validate();
            var count = 0;
            var result = false;
            if (!$('#beneficiariosEdt').hasClass('d-none')) {
                validate.settings.ignore = '';
                result = instance.valid();
                count = validate.numberOfInvalids();
                validate.settings.ignore = ':hidden';
            }
            count = count + Validations();

            if (count > 0)
                $('#beneficiariosHTab .badge').html(count);
            else {
                $('#beneficiariosHTab .badge').html('');
                result = true;
            }
            return result;
        },
        IsRequired: function (value) {
            beneficiaryRequired = value;
            if (!value) {
                $('#beneficiarios').removeClass('d-none');
                $('#beneficiariosEdt').addClass('d-none');
            }
        }
    };
})();
$(document).ready(function () {
    app.beneficiarios.Init();
});
