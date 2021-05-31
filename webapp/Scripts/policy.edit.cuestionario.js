var app = app || {};
app.cuestionario = (function () {

    function Init_Controls() {
        for (index = 1; index <= 10; index++) {
            $('#When_' + index + '_group').datetimepicker({
                format: 'DD/MM/YYYY',
                locale: 'es'
            });
        };
    };

    function Init_Lookups() {
    };

    function Event_Controls() {
        $("input:radio[name^='Confirmation']").on('change', function () {
            var indexValue = $(this)[0].name.substring(13);
            if (this.value === '1') {
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
                Diagnosis_2: {
                    required: true
                },
                Treatment_2: {
                    required: true,
                },
                Doctor_2: {
                    required: true
                },
                When_2: {
                    required: true
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
                }
            },
            messages: {
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
                Diagnosis_2: {
                    required: 'Debe indicar el diagnóstico'
                },
                Treatment_2: {
                    required: 'Debe indicar el tratamiento',
                },
                Doctor_2: {
                    required: 'Debe indicar el médico'
                },
                When_2: {
                    required: 'Debe indicar la fecha'
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
                }
            }
        });
    };

    var _inputToObject = function () {
        var data = [];
        for (index = 1; index <= 10; index++) {
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
            var nindex = 1;
            $.each(data, function (index, row) {
                nindex = 1 + index;
                $($('input:radio[name=Confirmation_' + nindex + '][value=' + row.Confirmation + ']')).prop('checked', true);
                $('input:radio[name=Confirmation_' + nindex + '][value=' + row.Confirmation + ']').change();
                $('#Diagnosis_' + nindex).val(row.Diagnosis);
                $('#Treatment_' + nindex).val(row.Treatment);
                $('#Doctor_' + nindex).val(row.Doctor);
                app.ui.SetDateValue('#When_' + nindex, row.When);
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
