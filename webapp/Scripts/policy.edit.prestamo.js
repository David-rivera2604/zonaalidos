var app = app || {};
app.prestamo = (function () {

    function Init_Controls() {
        $('#StartTerm_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#EndTerm_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#RecastTotal', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Amount1', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        $('#EndTermOnAmount1_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#Amount2', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        $('#EndTermOnAmount2_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#Amount3', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        $('#EndTermOnAmount3_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#Amount4', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        $('#EndTermOnAmount4_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#Amount5', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        $('#EndTermOnAmount5_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });

    };

    function Init_Lookups() {
    };

    function Event_Controls() {
        $('#StartTerm').blur(function () {
            var minDate = app.ui.GetDateRawValue('#StartTerm');
            minDate.setDate(minDate.getDate() + 1);

            $('#EndTerm_group').data("DateTimePicker").minDate(minDate);
        });

        $('#Recast1,#Recast2,#Recast3,#Recast4,#Recast5').change(function () {
            CalculateRecastTotal();
        });
    };

    function CalculateRecastTotal() {
        let total = 0;
        let value = 0;
        let show = false;

        value = app.ui.GetNumericValue('#Amount1');
        if (value > 0) {
            $('.recastplace1').removeClass('d-none');
            show = true;
            if ($('#Recast1').is(':checked')) {
                total += value;
            }
        }

        value = app.ui.GetNumericValue('#Amount2');
        if (value > 0) {
            $('.recastplace2').removeClass('d-none');
            show = true;
            if ($('#Recast2').is(':checked')) {
                total += value;
            }
        }
        value = app.ui.GetNumericValue('#Amount3');
        if (value > 0) {
            $('.recastplace3').removeClass('d-none');
            show = true;
            if ($('#Recast3').is(':checked')) {
                total += value;
            }
        }
        value = app.ui.GetNumericValue('#Amount4');
        if (value > 0) {
            $('.recastplace4').removeClass('d-none');
            show = true;
            if ($('#Recast4').is(':checked')) {
                total += value;
            }
        }
        value = app.ui.GetNumericValue('#Amount5');
        if (value > 0) {
            $('.recastplace5').removeClass('d-none');
            show = true;
            if ($('#Recast5').is(':checked')) {
                total += value;
            }
        }

        app.ui.SetNumericValue('#RecastTotal', total);
        if (show) {
            $('.recastplace').removeClass('d-none');
            $('#RecastTotal').parent().parent().removeClass('d-none');
        }

        app.ui.SetNumericValue('#InsuredAmountComplement', total);
        app.ui.SetNumericValue('#InsuredAmount', app.ui.GetNumericValue('#InsuredAmountBase') + total);
    }

    function Setup_Validations() {

        $.validator.addMethod("EndTermGreaterThanStartTerm",
            function (value, element, params) {
                return app.ui.GetDateValue('#StartTerm') < app.ui.GetDateValue('#EndTerm');
            }
        );

        $.validator.addMethod("AmountEndTermOnAmount",
            function (value, element, params) {
                if (params[0] == 'Amount')
                    return !(app.ui.GetNumericValue(params[1]) === 0 && app.ui.GetDateValue(params[2]) !== app.DateEmpty);
                else
                    return !(app.ui.GetNumericValue(params[1]) !== 0 && app.ui.GetDateValue(params[2]) === app.DateEmpty);
            }
        );

        $("#OverdraftEdtFrm").validate({
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
                StartTerm: {
                    required: true
                },
                EndTerm: {
                    required: true,
                    EndTermGreaterThanStartTerm: true
                },
                Amount1: {
                    AmountEndTermOnAmount: ['Amount', '#Amount1', '#EndTermOnAmount1']
                },
                EndTermOnAmount1: {
                    AmountEndTermOnAmount: ['EndTerm', '#Amount1', '#EndTermOnAmount1']
                },
                Amount2: {
                    AmountEndTermOnAmount: ['Amount', '#Amount2', '#EndTermOnAmount2']
                },
                EndTermOnAmount2: {
                    AmountEndTermOnAmount: ['EndTerm', '#Amount2', '#EndTermOnAmount2']
                },
                Amount3: {
                    AmountEndTermOnAmount: ['Amount', '#Amount3', '#EndTermOnAmount3']
                },
                EndTermOnAmount3: {
                    AmountEndTermOnAmount: ['EndTerm', '#Amount3', '#EndTermOnAmount3']
                },
                Amount4: {
                    AmountEndTermOnAmount: ['Amount', '#Amount4', '#EndTermOnAmount4']
                },
                EndTermOnAmount4: {
                    AmountEndTermOnAmount: ['EndTerm', '#Amount4', '#EndTermOnAmount4']
                },
                Amount5: {
                    AmountEndTermOnAmount: ['Amount', '#Amount5', '#EndTermOnAmount5']
                },
                EndTermOnAmount5: {
                    AmountEndTermOnAmount: ['EndTerm', '#Amount5', '#EndTermOnAmount5']
                }
            },
            messages: {
                StartTerm: {
                    required: 'Debe indicar el inicio del plazo'
                },
                EndTerm: {
                    required: 'Debe indicar el fin del plazo para el prestamo',
                    EndTermGreaterThanStartTerm: 'El fin del plazo debe posterior al inicio del mismo'
                },
                Amount1: {
                    AmountEndTermOnAmount: 'Debe indicar el monto para el detalle del 1er prestamo'
                },
                EndTermOnAmount1: {
                    AmountEndTermOnAmount: 'Debe indicar el fin del plazo para el detalle del 1er prestamo'
                },
                Amount2: {
                    AmountEndTermOnAmount: 'Debe indicar el monto para el detalle del 2do prestamo'
                },
                EndTermOnAmount2: {
                    AmountEndTermOnAmount: 'Debe indicar el fin del plazo para el detalle del 2do prestamo'
                },
                Amount3: {
                    AmountEndTermOnAmount: 'Debe indicar el monto para el detalle del 3er prestamo'
                },
                EndTermOnAmount3: {
                    AmountEndTermOnAmount: 'Debe indicar el fin del plazo para el detalle del 3er prestamo'
                },
                Amount4: {
                    AmountEndTermOnAmount: 'Debe indicar el monto para el detalle del 4to prestamo'
                },
                EndTermOnAmount4: {
                    AmountEndTermOnAmount: 'Debe indicar el fin del plazo para el detalle del 4to prestamo'
                },
                Amount5: {
                    AmountEndTermOnAmount: 'Debe indicar el monto para el detalle del 5to prestamo'
                },
                EndTermOnAmount5: {
                    AmountEndTermOnAmount: 'Debe indicar el fin del plazo para el detalle del 5to prestamo'
                }
            }
        });
    };

    var _inputToObject = function () {
        var data = {
            StartTerm: app.ui.GetDateValue('#StartTerm'),
            EndTerm: app.ui.GetDateValue('#EndTerm'),
            Amount1: app.ui.GetNumericValue('#Amount1'),
            EndTermOnAmount1: app.ui.GetDateValue('#EndTermOnAmount1'),
            Recast1: $('#Recast1').is(':checked'),
            Amount2: app.ui.GetNumericValue('#Amount2'),
            EndTermOnAmount2: app.ui.GetDateValue('#EndTermOnAmount2'),
            Recast2: $('#Recast2').is(':checked'),
            Amount3: app.ui.GetNumericValue('#Amount3'),
            EndTermOnAmount3: app.ui.GetDateValue('#EndTermOnAmount3'),
            Recast3: $('#Recast3').is(':checked'),
            Amount4: app.ui.GetNumericValue('#Amount4'),
            EndTermOnAmount4: app.ui.GetDateValue('#EndTermOnAmount4'),
            Recast4: $('#Recast4').is(':checked'),
            Amount5: app.ui.GetNumericValue('#Amount5'),
            EndTermOnAmount5: app.ui.GetDateValue('#EndTermOnAmount5'),
            Recast5: $('#Recast5').is(':checked')
        };
        return data;
    };

    var _objectToInput = function (data) {
        if (data !== null) {
            app.ui.SetDateValue('#StartTerm', data.StartTerm);
            app.ui.SetDateValue('#EndTerm', data.EndTerm);
            app.ui.SetNumericValue('#Amount1', data.Amount1);
            app.ui.SetDateValue('#EndTermOnAmount1', data.EndTermOnAmount1);
            $('#Recast1').prop('checked', data.Recast1);
            app.ui.SetNumericValue('#Amount2', data.Amount2);
            app.ui.SetDateValue('#EndTermOnAmount2', data.EndTermOnAmount2);
            $('#Recast2').prop('checked', data.Recast2);
            app.ui.SetNumericValue('#Amount3', data.Amount3);
            app.ui.SetDateValue('#EndTermOnAmount3', data.EndTermOnAmount3);
            $('#Recast3').prop('checked', data.Recast3);
            app.ui.SetNumericValue('#Amount4', data.Amount4);
            app.ui.SetDateValue('#EndTermOnAmount4', data.EndTermOnAmount4);
            $('#Recast4').prop('checked', data.Recast4);
            app.ui.SetNumericValue('#Amount5', data.Amount5);
            app.ui.SetDateValue('#EndTermOnAmount5', data.EndTermOnAmount5);
            $('#Recast5').prop('checked', data.Recast5);
            CalculateRecastTotal();
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
            var instance = $('#OverdraftEdtFrm');
            var validate = instance.validate();
            validate.settings.ignore = '';
            var result = instance.valid();
            var count = validate.numberOfInvalids();
            validate.settings.ignore = ':hidden';
            app.prestamo.ShowErrorBadge(count);
            return result;
        },
        ShowErrorBadge: function (count) {
            if (count > 0)
                $('#prestamosHTab .badge').html(count);
            else
                $('#prestamosHTab .badge').html('');
        }
    };
})();
$(document).ready(function () {
    app.prestamo.Init();
});
