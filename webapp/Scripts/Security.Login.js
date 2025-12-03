var app = app || {};

var btn = document.getElementById("forgotlink");
var modal = document.getElementById("myModal");
var span = document.getElementsByClassName("close")[0];

app.login = (function () {
    let dataStage = null;
    let lasthref = '';

    let employeeMode = window.location.href.toLowerCase().endsWith("/mapfre");

    function Init_Controls() {
        app.login.lasthref = localStorage.getItem('lasthref');
        localStorage.removeItem('lasthref');
    };

    function Init_Lookups() {
    };

    function Event_Controls() {
        $('#SetPasswordCancel').click(function () {
            event.preventDefault();
            $('#SetPassword').addClass('d-none');
            $('#login').removeClass('d-none');
            modal.style.display = "none";
        });

        $('#forgoCodeCancel').click(function () {
            event.preventDefault();
            $('#forgoCode').addClass('d-none');
            $('#login').removeClass('d-none');
            modal.style.display = "none";
        });

        $('#ForgotCancel').click(function () {
            event.preventDefault();
            $('#forgo').addClass('d-none');
            $('#login').removeClass('d-none');
            modal.style.display = "none";
        });

        $('#forgotlink').click(function () {
            event.preventDefault();
            $('#forgo').removeClass('d-none');
            $('#login').addClass('d-none');
        });

        $('#reset').click(function (e) {
            e.preventDefault();
            $('#Tenant').prop("disabled", false);
            $('#Username').prop("disabled", false);
            $('.PasswordCls').removeClass('d-none');
            $('.accessotpCls').addClass('d-none');
            $('#Send').html('Iniciar');
            $('#Send').prop("disabled", false);
            $('#Password').val('');
            $('#accessotp').val('');
            dataStage = null;
        });

        $('#Send').click(function (e) {
            if (app.ui.IsValid('#LoginEdtForm', false)) {
                var status = 'validate';
                $('#Send').prop("disabled", true);
                $('#Send').html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Validando...');
                var inputData = InputToObject();
                if (dataStage == null) {
                    app.core.Post(app.setting.basepath + 'Security/LogIn', JSON.stringify(inputData))
                        .done(function (data, textStatus, jqXHR) {
                            if (data.Reason == null) {
                                if (!data.MustChangePassword) {
                                    if (data.Need2FAOTP) {
                                        dataStage = data;
                                        $('#Tenant').prop("disabled", true);
                                        $('#Username').prop("disabled", true);
                                        $('.PasswordCls').addClass('d-none');
                                        $('.accessotpCls').removeClass('d-none');
                                        $('#Send').html('Verificar el código');
                                        $('#Send').prop("disabled", false);
                                    }
                                    else {
                                        Authenticated(data);
                                        status = 'redirect';
                                    }
                                } else {
                                    $('#ForgotMail').val(data.EMail);
                                    $('#login').addClass('d-none');

                                    modal.style.display = "block";

                                    $('#forgoCode').removeClass('d-none');

                                    $("#forgoCode h3").html('Su clave de acceso ha expirado, hemos enviado a su correo electrónico, un código de verificación');
                                    $("#forgoCode p").html('Ingrese el código de verificación enviado a su correo electrónico registrado, para establecer su nueva clave de acceso');
                                }
                            }
                            else
                                toastr.error(data.Reason, "Ha ocurrido un error", { timeOut: 10000, closeButton: true, progressBar: true });
                        }).always(function () {
                            if (dataStage == null && status != 'redirect') {
                                $('#Send').html('Iniciar');
                                $('#Send').prop("disabled", false);
                            }
                        });
                } else {
                    app.core.Post(app.setting.basepath + 'Security/IsOTPValid', JSON.stringify({ Tenant: dataStage.Tenant, EMail: dataStage.EMail, OTP: $('#accessotp').val(), Mode: '2FA' }))
                        .done(function (data, textStatus, jqXHR) {
                            if (data.Successful) {
                                Authenticated(data.Context);
                            }
                            else {
                                toastr.error(data.Reason, "Ha ocurrido un error", { timeOut: 10000, closeButton: true, progressBar: true });
                                $('#Send').html('Verificar el código');
                                $('#Send').prop("disabled", false);
                            }
                        });
                }
            }
            e.preventDefault();
        });

        $('#ForgotSend').click(function () {
            event.preventDefault();
            if (app.ui.IsValid('#ForgotEdtForm', false)) {
                $('#ForgotSend').prop("disabled", true);
                $('#ForgotSend').html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Validando...');

                app.core.Post(app.setting.apipath + 'v1/Security/SendOTP', JSON.stringify({ Tenant: $('#Tenant').val(), EMail: $('#ForgotMail').val() }))
                    .done(function (data, textStatus, jqXHR) {
                        if (!data.Successful)
                            toastr.error(data.Reason, "Ha ocurrido un error", { timeOut: 10000, closeButton: true, progressBar: true });
                        else {
                            $('#forgo').addClass('d-none');
                            $('#forgoCode').removeClass('d-none');
                        }
                    }).always(function () {
                        $('#ForgotSend').html('Continuar');
                        $('#ForgotSend').prop("disabled", false);
                    });
            }
        });

        $('#forgoCodeSend').click(function () {
            event.preventDefault();
            if (app.ui.IsValid('#forgoCodeEdtForm', false)) {
                $('#forgoCodeSend').prop("disabled", true);
                $('#forgoCodeSend').html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Enviando...');

                app.core.Post(app.setting.apipath + 'v1/Security/IsOTPValid', JSON.stringify({ Tenant: $('#Tenant').val(), EMail: $('#ForgotMail').val(), OTP: $('#forgoCodeMail').val() }))
                    .done(function (data, textStatus, jqXHR) {
                        if (!data.Successful)
                            toastr.error(data.Reason, "Ha ocurrido un error", { timeOut: 10000, closeButton: true, progressBar: true });
                        else {
                            $('#forgoCode').addClass('d-none');
                            $('#SetPassword').removeClass('d-none');
                        }
                    }).always(function () {
                        $('#forgoCodeSend').html('Continuar');
                        $('#forgoCodeSend').prop("disabled", false);
                    });
            }
        });

        $('#SetPasswordSend').click(function () {
            event.preventDefault();
            if (app.ui.IsValid('#SetPasswordEdtForm', false)) {
                $('#SetPasswordSend').prop("disabled", true);
                $('#SetPasswordSend').html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando...');

                app.core.Post(app.setting.apipath + 'v1/Security/ResetPassword', JSON.stringify({ Tenant: $('#Tenant').val(), EMail: $('#ForgotMail').val(), OTP: $('#forgoCodeMail').val(), Password: $('#SetPasswordMail').val(), PasswordConfirm: $('#SetPasswordMail2').val() }))
                    .done(function (data, textStatus, jqXHR) {
                        $("#myModal").hide();
                        if (!data.Successful)
                            toastr.error(data.Reason, "Ha ocurrido un error", { timeOut: 10000, closeButton: true, progressBar: true });
                        else {
                            toastr.success("La clave de acceso ha sido establecida de forma exitosa", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            $('#SetPassword').addClass('d-none');
                            $('#login').removeClass('d-none');
                        }
                    }).always(function () {
                        $('#SetPasswordSend').html('Cambiar clave de acceso');
                        $('#SetPasswordSend').prop("disabled", false);
                    });
            }
        });

        $('#Password').on('blur', function () {
            let value = $('#Password').val();
            let index = value.indexOf('\\');
            if (value != null && index > -1) {
                if (value.indexOf('\\', index + 1) > -1) {
                    $('#Tenant').val(value.substr(0, index));
                    value = value.substr(index + 1);
                    index = value.indexOf('\\');
                }
                $('#Password').val(value.substr(index + 1));
                $('#Username').val(value.substr(0, index));
                $('#Send').click();
            }
        });
    };

    function Dynamic_Event_Controls() {
        $('.alert').on('closed.bs.alert', function () {
            $('.wellcome-info').removeClass('d-none');
        })
    };

    function Setup_Validations() {
        $("#LoginEdtForm").validate({
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
                Tenant: {
                    required: true
                },
                Username: {
                    required: true,
                    minlength: 4
                },
                Password: {
                    required: true,
                    minlength: 4
                },
                accessotp: {
                    required: true
                }
            },
            messages: {
                Tenant: {
                    required: 'Debe indicar el nombre o código de aliado'
                },
                Username: {
                    required: 'Debe indicar el nombre del usuario o el correo electrónico',
                    minlength: 'El nombre del usuario o el correo electrónico deben tener por lo menos 4 caracteres'
                },
                Password: {
                    required: 'Debe indicar la clave de acceso',
                    minlength: 'La clave de acceso debe tener por lo menos 4 caracteres'
                },
                accessotp: {
                    required: 'Debe indicar el código de verificación'
                }
            }
        });
        $("#ForgotEdtForm").validate({
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
                ForgotMail: {
                    email: true,
                    required: true
                }
            },
            messages: {
                ForgotMail: {
                    email: 'Debe indicar un correo electrónico valido',
                    required: 'Debe indicar el correo electrónico'
                }
            }
        });
        $("#forgoCodeEdtForm").validate({
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
                forgoCodeMail: {
                    required: true,
                    minlength: 6
                }
            },
            messages: {
                forgoCodeMail: {
                    required: 'Debe indicar el código de verificación',
                    minlength: 'Debe indicar los 6 digitos del código de verificación'
                }
            }
        });
        $("#SetPasswordEdtForm").validate({
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
                SetPasswordMail: {
                    required: true,
                    minlength: 8,
                    pattern: /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).+$/
                },
                SetPasswordMail2: {
                    required: true,
                    minlength: 8,
                    equalTo: '#SetPasswordMail'
                }
            },
            messages: {
                SetPasswordMail: {
                    required: 'Debe indicar la clave de acceso',
                    minlength: 'La clave de acceso debe tener por lo menos 8 caracteres',
                    pattern: ' Debe tener una mayúscula, un número y un carácter especial'
                },
                SetPasswordMail2: {
                    required: 'Debe indicar la clave de acceso',
                    minlength: 'La clave de acceso debe tener por lo menos 8 caracteres',
                    pattern: ' Debe tener una mayúscula, un número y un carácter especial'
                }
            }
        });
    };

    function InputToObject() {
        var data = {
            Tenant: $('#Tenant').val(),
            Email: $('#Username').val(),
            Password: $('#Password').val(),
            EmployeeMode: employeeMode
        };
        return data;
    };

    function Authenticated(data) {
        data.Settings?.forEach(item => {
            localStorage.setItem(item.Key, item.Value);
        });
        localStorage.setItem('Username', data.UserName);
        localStorage.setItem('Tenant', data.Tenant);
        localStorage.setItem('Color1Tenant', data.Color1Tenant);
        localStorage.setItem('Color2Tenant', data.Color2Tenant);
        localStorage.setItem('Roles', JSON.stringify(data.Roles));
        var dta = new Date();
        localStorage.setItem('LastActivity', dta);
        var dt = new Date();
        dt.setMinutes(dt.getMinutes() + parseInt(data.ExpiresIn));
        localStorage.setItem('Expires', dt);

        localStorage.setItem('Token', data.Token);
        $('#Send').prop("disabled", true);
        $('#Send').html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Accediendo...');
        if (app.login.lasthref == null) {
            window.location.replace(app.setting.basepath + data.InitialPath);
        } else {
            window.location.replace(app.login.lasthref);
        }
    };

    return {
        Init: function () {
            var _tenant = app.core.URLStringValue('tenant');
            if (_tenant == '')
                _tenant = localStorage.getItem('Tenant');

            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Dynamic_Event_Controls();
            Setup_Validations();
            localStorage.removeItem('Username');
            localStorage.removeItem('Roles');
            localStorage.removeItem('Expires');
            localStorage.removeItem('Token');
            localStorage.removeItem('Navegation');
            localStorage.removeItem('LastActivity');
            $('#Username').focus();
            var reason = localStorage.getItem('reason');
            localStorage.removeItem('reason');
            if (reason === 'session-expired') {
                $('.alert').removeClass('d-none');
            }
            $('#Tenant').val(_tenant);
            if (employeeMode) {
                $('#forgotlink').addClass('d-none');
            }
        }
    };
})();
$(document).ready(function () {
    app.login.Init();

    btn.addEventListener("click", function () {
        modal.style.display = "block";
    });

    span.addEventListener("click", function () {
        modal.style.display = "none";
    });

    window.addEventListener("click", function (event) {
        if (event.target === modal) {
            modal.style.display = "none";
        }
    });
});