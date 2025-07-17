var app = app || {};

app.SecurityChangePassword = (function () {

    function Event_Controls() {

        $('#ChangePasswordEdtFormSave').click(function () {
            event.preventDefault();
            if (app.ui.IsValid('#ChangePasswordEdtForm', false)) {
                $('#ChangePasswordEdtFormSave').prop("disabled", true);
                $('#ChangePasswordEdtFormSave').html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Guardando cambios');

                app.core.Put(app.setting.apipath + 'v1/Security/ChangePassword', JSON.stringify(MapInputToObject()))
                    .done(function (data, textStatus, jqXHR) {

                        if (data.Successful) {
                            $('#CurrentPassword').val('');
                            $('#NewPassword').val('');
                            $('#ConfirmPassword').val('');
                            toastr.success("La clave de acceso ha sido cambiada de forma exitosa", "", { timeOut: 5000, closeButton: true, progressBar: true });
                        }
                        else {
                            toastr.error(data.Reason, "Ha ocurrido un error", { timeOut: 10000, closeButton: true, progressBar: true });
                        }
                    }).always(function () {
                        $('#ChangePasswordEdtFormSave').html('Cambiar clave de acceso');
                        $('#ChangePasswordEdtFormSave').prop("disabled", false);
                    });
            }

        });
    };

    function MapInputToObject() {
        var data = {
            Current: $('#CurrentPassword').val(),
            Password: $('#NewPassword').val(),
            PasswordConfirm: $('#ConfirmPassword').val()
        };
        return data;
    };

    function Setup_Validations() {

        $.validator.addMethod("notEqualToCurrent", function (value, element) {
            return value !== $("#CurrentPassword").val();
        }, "La nueva clave no puede ser igual a la clave actual");

        $("#ChangePasswordEdtForm").validate({
            errorPlacement: function (error, element) {
                var name = $(element).attr("name");
                var $obj = $("#" + name + "_validate");
                if ($obj.length) {
                    error.appendTo($obj);
                } else {
                    error.insertAfter(element);
                }
            },
            rules: {
                CurrentPassword: {
                    required: true,
                    minlength: 8
                },
                NewPassword: {
                    required: true,
                    minlength: 8,
                    pattern: /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).+$/,
                    notEqualToCurrent: true
                },
                ConfirmPassword: {
                    required: true,
                    minlength: 8,
                    equalTo: '#NewPassword'
                }
            },
            messages: {
                CurrentPassword: {
                    required: 'Debe indicar la clave de acceso actual',
                    minlength: 'La clave de acceso debe tener por lo menos 8 caracteres'
                },
                NewPassword: {
                    required: 'Debe indicar la nueva clave de acceso',
                    minlength: 'clave de acceso debe tener por lo menos 8 caracteres',
                    pattern: 'La nueva clave debe contener al menos una mayúscula, un número y un carácter especial',
                    notEqualToCurrent: 'La nueva clave no puede ser igual a la clave actual'
                },
                ConfirmPassword: {
                    required: 'Debe indicar la confirmación de la nueva clave de acceso',
                    minlength: 'La clave de acceso debe tener por lo menos 8 caracteres',
                    equalTo: 'La nueva clave de acceso y su confirmación deben ser iguales'
                }
            }
        });
    };

    return {
        Init: function () {
            Event_Controls();
            Setup_Validations();

            $('#CurrentPassword').focus();
        }
    };
})();
