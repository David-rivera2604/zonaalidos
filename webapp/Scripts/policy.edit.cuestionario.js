var app = app || {};
app.cuestionario = (function () {

    function Init_Controls() {
        for (index = 1; index <= 14; index++) {
            $('#When_' + index + '_group').datetimepicker({
                format: 'DD/MM/YYYY',
                locale: 'es'
            });
        };
    };

    function Init_Lookups() {
    };

    function Event_Controls() {
        $("input:radio[name='Confirmation_1'],input:radio[name='Confirmation_2'],input:radio[name='Confirmation_3'],input:radio[name='Confirmation_4'],input:radio[name='Confirmation_5'],input:radio[name='Confirmation_6'],input:radio[name='Confirmation_7'],input:radio[name='Confirmation_8'],input:radio[name='Confirmation_9'],input:radio[name='Confirmation_10'],input:radio[name='Confirmation_11'],input:radio[name='Confirmation_12'],input:radio[name='Confirmation_13'],input:radio[name='Confirmation_14']").on('change', function () {
            let indexValue = $(this)[0].name.substring(13);
            let value = this.value;

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

        $.validator.addMethod("AgeGreaterThan64_radio",
            function (value, element) {
                var notError = true;
                var age = moment().diff($('#BirthDate_group').data('DateTimePicker').date(), 'years');
                if (!Number.isNaN(age)) {
                    if (age > 64 && $('input:radio[name=' + element.id.substring(0, element.id.length - 1) + ']:checked').val() === undefined) {
                        notError = false;
                    }
                }
                return notError;
            }
        );

        $("#QuestionaryEdtFrm").validate({
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
                Confirmation_1: {
                    AgeGreaterThan64_radio: true
                },
                Diagnosis_1: {
                    required: true
                },
                Treatment_1: {
                    required: true,
                },
                Doctor_1: {
                    required: true
                },
                When_1: {
                    required: true
                },
                Confirmation_2: {
                    AgeGreaterThan64_radio: true
                },
                Diagnosis_2: {
                    required: true
                },
                Confirmation_3: {
                    AgeGreaterThan64_radio: true
                },
                Diagnosis_3: {
                    required: true
                },
                Treatment_3: {
                    required: true,
                },
                Doctor_3: {
                    required: true
                },
                When_3: {
                    required: true
                },
                Confirmation_4: {
                    AgeGreaterThan64_radio: true
                },
                Diagnosis_4: {
                    required: true
                },
                Treatment_4: {
                    required: true,
                },
                Doctor_4: {
                    required: true
                },
                When_4: {
                    required: true
                },
                Confirmation_5: {
                    AgeGreaterThan64_radio: true
                },
                Diagnosis_5: {
                    required: true
                },
                Treatment_5: {
                    required: true,
                },
                Doctor_5: {
                    required: true
                },
                When_5: {
                    required: true
                },
                Confirmation_6: {
                    AgeGreaterThan64_radio: true
                },
                Confirmation_7: {
                    AgeGreaterThan64_radio: true
                },
                Confirmation_8: {
                    AgeGreaterThan64_radio: true
                },
                Confirmation_9: {
                    AgeGreaterThan64_radio: true
                },
                Confirmation_10: {
                    AgeGreaterThan64_radio: true
                },
                Confirmation_11: {
                    AgeGreaterThan64_radio: true
                },
                Confirmation_12: {
                    AgeGreaterThan64_radio: true
                },
                Confirmation_13: {
                    AgeGreaterThan64_radio: true
                },
                Confirmation_14: {
                    AgeGreaterThan64_radio: true
                }
            },
            messages: {
                Confirmation_1: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 1',
                },
                Diagnosis_1: {
                    required: 'Debe indicar el diagnóstico'
                },
                Treatment_1: {
                    required: 'Debe indicar el tratamiento',
                },
                Doctor_1: {
                    required: 'Debe indicar el médico'
                },
                When_1: {
                    required: 'Debe indicar la fecha'
                },
                Confirmation_2: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 8',
                },
                Diagnosis_2: {
                    required: 'Debe ampliar su respuesta'
                },
                Confirmation_3: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 2',
                },
                Diagnosis_3: {
                    required: 'Debe indicar el diagnóstico'
                },
                Treatment_3: {
                    required: 'Debe indicar el tratamiento',
                },
                Doctor_3: {
                    required: 'Debe indicar el médico'
                },
                When_3: {
                    required: 'Debe indicar la fecha'
                },
                Confirmation_4: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 12',
                },
                Diagnosis_4: {
                    required: 'Debe indicar el diagnóstico'
                },
                Treatment_4: {
                    required: 'Debe indicar el tratamiento',
                },
                Doctor_4: {
                    required: 'Debe indicar el médico'
                },
                When_4: {
                    required: 'Debe indicar la fecha'
                },
                Confirmation_5: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 5',
                },
                Diagnosis_5: {
                    required: 'Debe indicar el diagnóstico'
                },
                Treatment_5: {
                    required: 'Debe indicar el tratamiento',
                },
                Doctor_5: {
                    required: 'Debe indicar el médico'
                },
                When_5: {
                    required: 'Debe indicar la fecha'
                },
                Confirmation_6: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 7',
                },
                Confirmation_7: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 10',
                },
                Confirmation_8: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 3',
                },
                Confirmation_9: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 13',
                },
                Confirmation_10: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 14',
                },
                Confirmation_11: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 4',
                },
                Confirmation_12: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 6',
                },
                Confirmation_13: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 9',
                },
                Confirmation_14: {
                    AgeGreaterThan64_radio: 'Para mayores de 65 años debe responder la pregunta 11',
                }
            }
        });
    };

    var _inputToObject = function () {
        var data = [];
        for (index = 1; index <= 14; index++) {
            data.push({
                QuestionId: index,
                Confirmation: $('input:radio[name=Confirmation_' + index + ']:checked').val(),
                Diagnosis: $('#Diagnosis_' + index).val(),
                Treatment: $('#Treatment_' + index).val(),
                Doctor: $('#Doctor_' + index).val(),
                When: app.ui.GetDateValue('#When_' + index)
            });
        };
        return data;
    };

    var _objectToInput = function (data) {
        if (data !== null) {
            let nindex = 1;

            $.each(data, function (index, row) {
                if (row.QuestionId >= 1 && row.QuestionId <= 14) {
                    nindex = row.QuestionId;
                    $($('input:radio[name=Confirmation_' + nindex + '][value=' + row.Confirmation + ']')).prop('checked', true);
                    $('input:radio[name=Confirmation_' + nindex + '][value=' + row.Confirmation + ']').change();
                    $('#Diagnosis_' + nindex).val(row.Diagnosis);
                    $('#Treatment_' + nindex).val(row.Treatment);
                    $('#Doctor_' + nindex).val(row.Doctor);
                    app.ui.SetDateValue('#When_' + nindex, row.When);
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
            var instance = $('#QuestionaryEdtFrm');
            var validate = instance.validate();

            validate.settings.ignore = '';
            var result = instance.valid();
            var count = validate.numberOfInvalids();
            validate.settings.ignore = ':hidden';

            if (count > 0)
                $('#cuestionarioHTab .badge').html(count);
            else
                $('#cuestionarioHTab .badge').html('');
            return result;
        }
    };
})();
$(document).ready(function () {
    app.cuestionario.Init();
});
