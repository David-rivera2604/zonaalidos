var app = app || {};
app.cuestionariocovid = (function () {

    function Init_Controls() {
        for (index = 51; index <= 59; index++) {
            $('#When_' + index + '_group').datetimepicker({
                format: 'DD/MM/YYYY',
                locale: 'es'
            });
        };
    };

    function Init_Lookups() {
    };

    function Event_Controls() {
        $("input:radio[name='Confirmation_51'],input:radio[name='Confirmation_52'],input:radio[name='Confirmation_53'],input:radio[name='Confirmation_54'],input:radio[name='Confirmation_55'],input:radio[name='Confirmation_56'],input:radio[name='Confirmation_57'],input:radio[name='Confirmation_58'],input:radio[name='Confirmation_59']").on('change', function () {
            let indexValue = $(this)[0].name.substring(13);
            let value = this.value;
            if (indexValue === '58') {
                value = value === '1' ? '2' : '1';
            }
            if (value === '1') {
                $('#question_' + indexValue).removeClass('d-none');
                $('#Diagnosis_' + indexValue).prop("disabled", false)
                $('#Doctor_' + indexValue).prop("disabled", false)
                $('#Treatment_' + indexValue).prop("disabled", false)
                $('#When_' + indexValue).prop("disabled", false)
            }
            else {
                $('#question_' + indexValue).addClass('d-none');
                $('#Diagnosis_' + indexValue).prop("disabled", true)
                $('#Doctor_' + indexValue).prop("disabled", true)
                $('#Treatment_' + indexValue).prop("disabled", true)
                $('#When_' + indexValue).prop("disabled", true)
            }
        });
    };

    function Setup_Validations() {

        $.validator.addMethod("AgeGreaterThan60_radio",
            function (value, element) {
                var notError = true;
                var age = moment().diff($('#BirthDate_group').data('DateTimePicker').date(), 'years');
                if (!Number.isNaN(age)) {
                    if (age >= 60 && $('input:radio[name=' + element.id.substring(0, element.id.length - 1) + ']:checked').val() === undefined) {
                        notError = false;
                    }
                }
                return notError;
            }
        );

        $.validator.addMethod("Q54",
            function (value, element) {
                var notError = false;
                if ($('input:radio[name=Confirmation_54]:checked').val() === undefined || $('input:radio[name=Confirmation_54]:checked').val() == '2' || $('#Diagnosis_54_1').is(':checked') || $('#Diagnosis_54_2').is(':checked') || $('#Diagnosis_54_3').is(':checked') || $('#Diagnosis_54_4').is(':checked') || $('#Diagnosis_54_5').is(':checked') || $('#Diagnosis_54_6').is(':checked')) {
                    notError = true;
                }
                return notError;
            }
        )

        $("#QuestionaryCovidEdtFrm").validate({
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
                Confirmation_51: {
                    AgeGreaterThan60_radio: true
                },
                Diagnosis_51: {
                    required: true
                },
                Confirmation_52: {
                    AgeGreaterThan60_radio: true
                },
                Confirmation_53: {
                    AgeGreaterThan60_radio: true
                },
                Diagnosis_53: {
                    required: true
                },
                Confirmation_54: {
                    AgeGreaterThan60_radio: true,
                    Q54: true
                },
                Confirmation_55: {
                    AgeGreaterThan60_radio: true
                },
                Confirmation_56: {
                    AgeGreaterThan60_radio: true
                },
                Diagnosis_56: {
                    required: true
                },
                Confirmation_57: {
                    AgeGreaterThan60_radio: true
                },
                When_57: {
                    required: true
                },
                Confirmation_58: {
                    AgeGreaterThan60_radio: true
                },
                Diagnosis_58: {
                    required: true
                },
                Confirmation_59: {
                    AgeGreaterThan60_radio: true
                },
                Treatment_59: {
                    required: true
                },
                When_59: {
                    required: true
                },
                Doctor_59: {
                    required: true
                }
            },
            messages: {
                Confirmation_51: {
                    AgeGreaterThan60_radio: 'Para mayores  de 60 años debe responder la pregunta 1',
                },
                Diagnosis_51: {
                    required: 'Debe indicar en qué país o países y las fechas exactas'
                },
                Confirmation_52: {
                    AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 2',
                },
                Confirmation_53: {
                    AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 3',
                },
                Diagnosis_53: {
                    required: 'Debe indicar el detalle'
                },
                Confirmation_54: {
                    AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 4',
                    Q54: 'Debe indicar cuales síntomas'
                },
                Confirmation_55: {
                    AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 5',
                },
                Confirmation_56: {
                    AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 6',
                },
                Diagnosis_56: {
                    required: 'Debe indicar el detalle'
                },
                Confirmation_57: {
                    AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 7',
                },
                When_57: {
                    required: 'Debe indicar la fecha'
                },
                Confirmation_58: {
                    AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 8',
                },
                Diagnosis_58: {
                    required: 'Debe indicar el motivo'
                },
                Confirmation_59: {
                    AgeGreaterThan60_radio: 'Para mayores de 60 años debe responder la pregunta 9',
                },
                Treatment_59: {
                    required: 'Debe indicar cual vacuna le aplicaron'
                },
                When_59: {
                    required: 'Debe indicar la fecha'
                },
                Doctor_59: {
                    required: 'Debe indicar cuántas dosis posee'
                }
            }
        });

    };

    var _inputToObject = function () {
        let data = [];
        let row = null;
        for (index = 51; index <= 59; index++) {
            row = {
                QuestionId: index,
                Confirmation: $('input:radio[name=Confirmation_' + index + ']:checked').val(),
                Diagnosis: $('#Diagnosis_' + index).val(),
                Treatment: $('#Treatment_' + index).val(),
                Doctor: $('#Doctor_' + index).val(),
                When: null
            };
            if (index === 54) {
                row.Diagnosis = [$('#Diagnosis_54_1').is(':checked'), $('#Diagnosis_54_2').is(':checked'), $('#Diagnosis_54_3').is(':checked'), $('#Diagnosis_54_4').is(':checked'), $('#Diagnosis_54_5').is(':checked'), $('#Diagnosis_54_6').is(':checked')].toString();
            }
            if ($('#When_' + index).length > 0) {
                row.When = app.ui.GetDateValue('#When_' + index);
            }
            data.push(row);
        }
        return data;
    };

    var _objectToInput = function (data) {
        if (data !== null) {
            let nindex = 1;

            $.each(data, function (index, row) {
                if (row.QuestionId >= 51 && row.QuestionId <= 59) {
                    nindex = row.QuestionId;
                    $($('input:radio[name=Confirmation_' + nindex + '][value=' + row.Confirmation + ']')).prop('checked', true);
                    $('input:radio[name=Confirmation_' + nindex + '][value=' + row.Confirmation + ']').change();
                    $('#Diagnosis_' + nindex).val(row.Diagnosis);
                    $('#Treatment_' + nindex).val(row.Treatment);
                    $('#Doctor_' + nindex).val(row.Doctor);
                    if ($('#When_' + nindex).length > 0)
                        app.ui.SetDateValue('#When_' + nindex, row.When);
                    if (nindex === 54) {
                        $.each(row.Diagnosis.split(','), function (indexRow, rowValue) {
                            $('#Diagnosis_54_' + (indexRow+1)).prop('checked', rowValue==='true');
                        });
                    }
                }
            });
        }
    };

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
            var instance = $('#QuestionaryCovidEdtFrm');
            var validate = instance.validate();

            validate.settings.ignore = '';
            var result = instance.valid();
            var count = validate.numberOfInvalids();
            validate.settings.ignore = ':hidden';

            if (count > 0)
                $('#cuestionarioCovidHTab .badge').html(count);
            else
                $('#cuestionarioCovidHTab .badge').html('');
            return result;
        }
    };
})();
$(document).ready(function () {
    app.cuestionariocovid.Init();
});
