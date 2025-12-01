var app = app || {};

app.PolicyUpLoadLoans = (function () {

    function Init_Controls() {
    };

    function Init_Lookups() {
    };

    function Event_Controls() {
        $('.tool-audit').on('click', function (e) {
            app.ui.components.ShowModalChangeSet(2005);
        });
        $('#fileUpload').on('change', function () {
            var index = 0;
            var arr = $('#fileUpload').prop('files');
            var message = '';
            for (index = 0; index < arr.length; index++) {
                if (arr[index].size >= 31457280) {
                    if (message != '') {
                        message = message & ', ';
                    }
                    message = message & 'El tamaño del archivo ' + arr[index].fileName + 'es mayor a 30mb';
                }
            }
            if (message != '') {
                elementInstance.showErrors({ 'FileName': message });
            }
            else {
                app.ui.ButtonDoing('#fileUpload');
                var fileName = $(this).val().split('\\').pop();
                var data = new FormData();
                for (index = 0; index < arr.length; index++) {
                    data.append('files', arr[index]);
                }
                $.ajax({
                    type: "POST",
                    enctype: 'multipart/form-data',
                    url: app.setting.apipath + 'v1/Common/Upload',
                    data: data,
                    processData: false,
                    contentType: false,
                    cache: false,
                    timeout: 600000,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + app.security().getCookie('Token'));
                    }
                }).done(function (data, textStatus, jqXHR) {
                    $('#Stored').val(data[0].StoredFileName);
                    $('#FileSize').val(data[0].Size);
                    $('#FileName').val(fileName);
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    console.log("ERROR : ", jqXHR);
                }).always(function () {
                    app.ui.ButtonDone('#fileUpload')
                });
            }
        });

        $('#RoleMemberEdtFormSave').click(function () {
            event.preventDefault();
            if (app.ui.IsValid('#RoleMemberEdtForm', false)) {
                app.ui.ButtonDoing('#RoleMemberEdtFormSave');
                app.core.Post(app.setting.apipath + 'v1/Policy/LoadLoans?fileName=' + $('#Stored').val() + '&originalFileName=' + $('#FileName').val())
                    .done(function (data, textStatus, jqXHR) {
                        app.ui.ShowAlert('generalNotify', 'alert-success', data.Message);
                        $('#Stored').val('');
                        $('#FileSize').val(0);
                        $('#FileName').val('');
                    }).always(function () {
                        app.ui.ButtonDone('#RoleMemberEdtFormSave');
                    });
            }
        });

    };

    function Setup_Validations() {
        $("#RoleMemberEdtForm").validate({
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
                FileName: {
                    required: true
                }
            },
            messages: {
                FileName: {
                    required: 'Debe indicar un archivo'
                }
            }
        });
    };

    return {
        Init: function () {
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Setup_Validations();
        }
    };
})();
