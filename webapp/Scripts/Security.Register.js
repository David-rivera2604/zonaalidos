var app = app || {};

app.SecurityRegister = (function () {

    function MapInputToObject() {
        var data = {
            Tenant: localStorage.getItem('Tenant'),
            identificacionType: $("#identificacionType").data("value"),
            identificacion: $('#identificacion').val(),
            FirstName: $('#FirstName').val(),
            LastName: $('#LastName').val(),
            BirthDate: app.ui.GetDateValue('#BirthDate'),
            EMail: $('#EMail').val(),
            Password: $('#Password').val()
        };
        return data;
    };

    function Controls_setup() {
        $('#identificacion').formatter({
            pattern: '0{{9}}-{{9999}}-{{9999}}',
            persistent: false
        });
        $('#BirthDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null
        });
    };

    function Controls_Events() {

        app.ui.DocumentNumberHandler('#identificacion',
            function (data) {
                if (data != null) {
                    $('#FirstName').val(data.FirstName);
                    $('#LastName').val(`${data.LastName} ${data.SecondLastName}`);
                    app.ui.SetDateValue('#BirthDate', data.BirthDate);
                    $('#EMail').val(data.PrimaryEmailAddress);
                }
            });

        $('#identificacionTypeMenu a').click(function () {
            app.ui.DocumentTypeHandler(this, '#identificacion', 'Identification');
        });

        $('#RegisterEdtFormSave').click(function () {

            if (app.ui.IsValid('#RegisterEdtForm', false)) {
                app.ui.ButtonDoing('#RegisterEdtFormSave');

                app.core.Post(app.setting.apipath + 'v1/Security/Register', JSON.stringify(MapInputToObject()))
                    .done(function (data, textStatus, jqXHR) {
                        if (!data.Successful)
                            toastr.error(data.Reason, "Ha ocurrido un error", { timeOut: 10000, closeButton: true, progressBar: true });
                        else {
                            $('#register').addClass("d-none");
                            $('#continue').removeClass("d-none");
                            app.ui.ShowAlert('generalNotify', 'alert-success', "Registro exitoso");
                        }


                    }).always(function () {
                        app.ui.ButtonDone('#RegisterEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#RegisterEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#RegisterEdtFormCancel');
            window.location.replace("/aliados/Security/Login");
            event.preventDefault();
        });
        $('#RegisterEdtFormContinue').click(function () {
            app.ui.ButtonDoing('#RegisterEdtFormContinue');
            window.location.replace("/aliados/Security/Login");
            event.preventDefault();
        });

    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#RegisterEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                identificacion: { required: true },
                FirstName: {
                    required: true,
                    minlength: 3
                },
                LastName: {
                    required: true,
                    minlength: 3
                },
                BirthDate: { BirthDate: true },
                EMail: { required: true, email: true },
                Password: {
                    required: true,
                    minlength: 4
                }
            },
            messages: {
                identificacion: { required: 'Debe indicar la identificación' },
                FirstName: {
                    required: 'Debe indicar los nombres',
                    minlength: 'Los nombres deben tener por lo menos 3 caracteres'
                },
                LastName: {
                    required: 'Debe indicar los apellidos',
                    minlength: 'Los apellidos deben tener por lo menos 3 caracteres'
                },
                BirthDate: { BirthDate: 'Ingrese una fecha inferior al día de hoy' },
                EMail: { required: 'Debe indicar el correo electrónico', email: 'Debe indicar un correo electrónico valido' },
                Password: {
                    required: 'Debe indicar la clave de acceso',
                    minlength: 'La clave de acceso debe tener por lo menos 4 caracteres'
                }
            }
        });
    };

    return {
        Init: function () {
            var _tenant = app.core.URLStringValue('tenant');
            //if (_tenant != 'Bayer')
            //    window.location.replace("/aliados/Security/Login");
            localStorage.setItem('Tenant', _tenant);
            Controls_setup();
            Setup_Validations();
            Controls_Events();
        }
    };
})();
