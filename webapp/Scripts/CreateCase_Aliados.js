var app = app || {};
var lookupData;
var Token_Ali;
var aliUser = '';

app.CentralCase = (function () {


    function Init_Controls() {
        new AutoNumeric('#SubStatus', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
    }

    function Event_Controls() {

        $('#ProcessCaseEdtFormSave').click(function (e) {
            if (app.ui.IsValid('#ProcessCaseEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessCaseEdtFormSave');
                var data = MapInputToObject();
                if (data.Id === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            e.preventDefault();
        });

        $('#ProcessCaseEdtFormCancel').click(function (e) {
            e.preventDefault();
        });

        $('#FlowId').change(function () {
            let flowId = $('#FlowId').val();
            let sla = app.CentralCase.Data().lookups.filter(i => i.Key === 'ProcessByRolDetail')[0].Lkp.filter(l => l.Code === flowId + '')[0].SLA;
            $('#SLA').val(sla);
            app.CentralCase.Get(app.setting.apipath + 'v1/ProcessSpecFlow/' + flowId, null, true)
                .done(function (data, textStatus, jqXHR) {
                    ReferenceHandler(data.ReferenceCaption1, data.ReferenceLookupList1, 'Reference1');
                    ReferenceHandler(data.ReferenceCaption2, data.ReferenceLookupList2, 'Reference2');
                    ReferenceHandler(data.ReferenceCaption3, data.ReferenceLookupList3, 'Reference3');
                    ReferenceHandler(data.ReferenceCaption4, data.ReferenceLookupList4, 'Reference4');
                    ReferenceHandler(data.ReferenceCaption5, data.ReferenceLookupList5, 'Reference5');

                    if (data.ReferenceCaption3 === 'INTERMEDIARIO') {
                        $('#Reference3').val(localStorage.getItem('Username'));
                        $('#Reference3').prop("disabled", true);
                    } else {
                        $('#Reference3').prop("disabled", false);
                    }

                });
        });

        $('#UserId').change(function () {
            let user = app.CentralCase.Data().lookups.filter(i => i.Key === 'Users')[0].Lkp.filter(l => l.Code === $('#UserId').val())[0];
            let finded = user != null;

            if (finded) {
                $('#ContactMainName').val(user.Description);
                $('#ContactMainEmail').val(user.EMAIL);
            }
            else {
                $('#ContactMainName').val('');
                $('#ContactMainEmail').val('');
            }
            $('#ContactMainName').prop("disabled", finded);
            $('#ContactMainEmail').prop("disabled", finded);
        });

    }

    function ReferenceHandler(caption, valueList, id) {
        if (caption != '') {
            $("label[for='" + id + "']").text(caption);
            if (valueList == '')
                $('#' + id).removeClass('d-none');
            else {
                let selectedOptions = $('#' + id + 'List');
                selectedOptions.removeClass('d-none');
                selectedOptions.children().remove();

                selectedOptions.append($('<option selected />').val('').text(''));
                $.each(valueList.split(';'), function () {
                    selectedOptions.append($('<option />').val(this).text(this));
                });


            }
            $('#' + id).parent().parent().removeClass('d-none');
        } else {
            $('#' + id).parent().parent().addClass('d-none');
            $('#' + id).addClass('d-none');
            $('#' + id + 'List').addClass('d-none');
            $('#' + id + 'List').val('');
        }
    }

    function Create(uidata, mode) {
        uidata.CurrentToken = localStorage.getItem('Token');
        app.CentralCase.Post(app.setting.apipath + 'v1/ProcessCase', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El processcase '" + uidata.Title + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                window.location.replace("Seguimiento_Al?id=" + data.Id);
            }).always(function () {
                app.ui.ButtonDone('#ProcessCaseEdtFormSave');
            });
    }

    function Init_Lookups() {
        Lookups(['CasePriority.Priority', 'ProcessStatus.Status', 'ProcessByRolDetail.FlowId', 'ProcessByRol.FlowId', 'Users.UserId.', 'SLA.SLA.'],
            function () {
                app.CentralCase.New();
            }, undefined, "v1/Common/Lkps");
    }

    function MapInputToObject() {
        return {
            Id: parseInt(0 + $('#Id').val(), 10),
            Title: $('#Title').val(),
            Description: $('#Description').val(),
            Priority: $('#Priority').val(),
            InstanceId: parseInt(0 + $('#InstanceId').val(), 10),
            Reference1: $('#Reference1').val() + $('#Reference1List').val(),
            Reference2: $('#Reference2').val() + $('#Reference2List').val(),
            Reference3: $('#Reference3').val() + $('#Reference3List').val(),
            Reference4: $('#Reference4').val() + $('#Reference4List').val(),
            Reference5: $('#Reference5').val() + $('#Reference5List').val(),
            ContactMainName: $('#ContactMainName').val(),
            ContactMainEmail: $('#ContactMainEmail').val(),
            Status: $('#Status').val(),
            Label: $('#Label').val(),
            SubStatus: app.ui.GetNumericValue('#SubStatus'),
            SubLabel: $('#SubLabel').val(),
            FlowId: $('#FlowId').val(),
            UserId: $('#UserId').val(),
            SLA: $('#SLA').val(),
            Attachments: app.Attachments.Data()
        };
    }

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        $('#Title').val(data.Title);
        $('#Description').val(data.Description);
        $('#Priority').val(data.Priority);
        $('#InstanceId').val(data.InstanceId);
        $('#Reference1').val(data.Reference1);
        $('#Reference2').val(data.Reference2);
        $('#Reference3').val(data.Reference3);
        $('#Reference4').val(data.Reference4);
        $('#Reference5').val(data.Reference5);
        $('#ContactMainName').val(data.ContactMainName);
        $('#ContactMainEmail').val(data.ContactMainEmail);
        $('#Status').val(data.Status);
        $('#Label').val(data.Label);
        app.ui.SetNumericValue('#SubStatus', data.SubStatus);
        $('#SubLabel').val(data.SubLabel);
        $('#FlowId').val(data.FlowId);
        $('#UserId').val(data.UserId);
        $('#SLA').val(data.SLA);
    }

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#ProcessCaseEdtForm").validate({
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
                Title: {
                    required: true
                },
                Priority: {
                    required: true
                },
                ContactMainName: {
                    required: true
                },
                ContactMainEmail: {
                    required: true
                },
                FlowId: {
                    required: true
                }
            },
            messages: {
                Title: {
                    required: 'Debe indicar el asunto'
                },
                Priority: {
                    required: 'Debe indicar la prioridad'
                },
                ContactMainName: {
                    required: 'Debe indicar el nombre completo'
                },
                ContactMainEmail: {
                    required: 'Debe indicar el correo electrónico'
                },
                FlowId: {
                    required: 'Debe indicar el proceso'
                }
            }

        });
    }

    function EditMode(row) {
        MapObjectToInput(row);
        $('#FlowId').focus();
    }

    return {
        Init: function () {
            app.core.Get(app.setting.apipath + 'v1/CasesSecurity/Create?Tenant=' + localStorage.getItem("Tenant"))
                .done(function (data, textStatus, jqXHR) {
                    Token_Ali = data.TokenAliado;
                    aliUser = data.user;
                    Init_Lookups();
                    Init_Controls();
                    Event_Controls();
                    Setup_Validations();
                    app.Attachments.Init({ EntityType: 1304, Id: 0, PostByEachRow: false, AlternateToken: Token_Ali });
                })
        },
        New: function (row) {
            let newRow = { Id: 0, Title: null, Description: null, Priority: 4, InstanceId: 0, Reference1: null, Reference2: null, Reference3: null, Reference4: null, Reference5: null, ContactMainName: null, ContactMainEmail: null, Status: 0, Label: null, SubStatus: 0, SubLabel: null, FlowId: null, UserId: null }
            if (row !== undefined) {
                row.Id = 0;
                newRow = row;
            }
            if (aliUser != null && aliUser != '') {
                let user = app.CentralCase.Data().lookups.filter(i => i.Key === 'Users')[0].Lkp.filter(l => l.IUSERNAME === aliUser)[0];
                if (user != null) {
                    newRow.UserId = user.Code;
                }
            }
            EditMode(newRow);
            $('#UserId').change();
        },
        Data: function () {
            return { lookups: lookupData };
        },
        Get: function (url, TokenUse, AlTok, data, success) {
            return ajaxCall('GET', url, data, success, false, TokenUse, AlTok);
        },
        Post: function (url, data) {
            return ajaxCall('POST', url, data, undefined, false, Token_Ali, Token_Ali);
        },
    };
})();

function ajaxCall(type, url, data, success, token, Token_Al, AliadoTok, contentType) {
    var dataType = 'json';

    if (contentType === undefined)
        contentType = 'application/json; charset=utf-8'

    if (contentType === 'text/html; charset=utf-8')
        dataType = 'text';

    if (data === undefined)
        data = null;
    return $.ajax({
        url: url,
        type: type,
        contentType: contentType,
        dataType: dataType,
        async: true,
        cache: false,
        data: data,
        beforeSend: function (xhr) {
            if (token) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('Token'));
            }
            else {
                if (AliadoTok) {
                    xhr.setRequestHeader('Authorization', 'Bearer ' + Token_Ali);
                }
                else {
                    xhr.setRequestHeader('Authorization', 'Bearer ' + Token_Al);
                }
            }
        }
    }).done(function (data, textStatus, jqXHR) {

        if (data != null && data.Success !== undefined) {
            if (data.Success) {
                toastr.success(data.Reason, '', { timeOut: 7000, closeButton: true, progressBar: true });
            } else {
                toastr.error(data.Reason, '', { timeOut: 7000, closeButton: true, progressBar: true });
            }
        }
        if (data != null && data.Mensaje !== undefined && data.Mensaje !== null) {
            toastr.info(data.Mensaje, '', { timeOut: 7000, closeButton: true, progressBar: true });
        }
        if (success !== undefined)
            success(data);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        ajaxErrorHandler(jqXHR, errorThrown);
    }).always(function () {
        //  alert('always');
    });
    //app.core.ErrorHandler(jqXHR, textStatus, errorThrown);

}

function Lookups(keys, callback, url, path) {
    var onlyKeys = [];
    var ctrls = [];
    var ctrlName = [];
    var emptyValues = [];
    var selectCtrol = [];
    var ctrl;
    var selectedOptions;

    $.each(keys, function (index, value) {

        if (value.split('.')[0].startsWith('@')) {
            selectCtrol.push(false);
            onlyKeys.push(value.split('.')[0].substring(1));
        }
        else {
            selectCtrol.push(true);
            onlyKeys.push(value.split('.')[0]);
        }

        if (value.split('.').length > 1)
            ctrl = value.split('.')[1];
        else
            ctrl = value;

        if (ctrl.startsWith('@'))
            ctrl = ctrl.substring(1);

        if (value.split('.').length > 2)
            emptyValues.push(value.split('.')[2]);
        else
            emptyValues.push(null);

        ctrlName.push(ctrl);
        selectedOptions = $('select#' + ctrl);
        ctrls.push(selectedOptions);
        selectedOptions.children().remove();
        selectedOptions.append($('<option />').val('0').text(' Cargando...'));
    });

    if (url === undefined) {
        url = '';
    }

    ajaxCall('GET', app.setting.apipath + path + '?keys=' + onlyKeys.toString() + '&url=' + url, null,
        function (data) {
            var key = '', ctrl = '';
            lookupData = data;
            $.each(data, function (index, values) {
                selectedOptions = ctrls[index];
                if (selectCtrol[index]) {
                    selectedOptions.children().remove();
                    if (emptyValues[index] !== null) {
                        selectedOptions.append($('<option />').val(0).text(emptyValues[index]));
                    }
                    $.each(values.Lkp, function () {
                        selectedOptions.append($('<option />').val(this['Code']).text(this['Description']));
                    });
                    selectedOptions.val(-1);
                }
                else {
                    selectedOptions.replaceWith('<div id="radio' + ctrlName[index] + '"></div>');
                    selectedOptions = $('#radio' + ctrlName[index]);
                    $.each(values.Lkp, function () {
                        selectedOptions.append('<div class="custom-control custom-radio custom-control-inline"><input type="radio" class="custom-control-input" id="' + ctrlName[index] + '_' + this['Code'] + '" name="' + ctrlName[index] + '" value="' + this['Code'] + '"><label class="custom-control-label" for="' + ctrlName[index] + '_' + this['Code'] + '">' + this['Description'] + '</label></div>');


                    });


                }
            });
            if (callback !== undefined && callback !== null)
                callback();
        }, false, undefined, true);
};



