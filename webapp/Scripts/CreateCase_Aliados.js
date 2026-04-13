var app = app || {};
var Token_Ali;
var aliUser = '';
var _currentToken = '';

app.CentralCase = (function () {
    let refFields = [];
    function Init_Controls() {
        new AutoNumeric('#SubStatus', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });

        $('#dropzone').fileUploader({
            maxFilesize: 256,
            done: function (responses) {
                console.log('Init_Controls: Archivos subidos exitosamente:', responses);
                toastr.success('Archivos cargados correctamente', '', {
                    timeOut: 3000,
                    closeButton: true
                });
            },
            fail: function (error, file) {
                console.error('Init_Controls: Error al subir archivo:', error, file);
                var errorMsg = typeof error === 'string' ? error :
                    (error.message || 'Error desconocido');
                toastr.error('Error al subir el archivo: ' + file.name + ' - ' + errorMsg, '', {
                    timeOut: 5000,
                    closeButton: true
                });
            },
            always: function (result) {
                console.log('Init_Controls: Proceso de carga completado:', result);
            }
        });
    }

    function Event_Controls() {

        $(".input-group.date, #ProcessCaseEdtForm :input").on('dp.change change', function (e) {
            ApplyConditions();
        });

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
            if (flowId == null) return;
            let sla = app.core.Data().lookups.filter(i => i.Key === 'ProcessByRolInformed')[0].Lkp.filter(l => l.Code === flowId + '')[0].SLA;
            $('#SLA').val(sla);
            app.core.Get(app.setting.apipath + 'v1/ProcessSpecFlow/' + flowId, undefined, undefined, true, Token_Ali)
                .done(function (data, textStatus, jqXHR) {

                    refFields = [
                        { id: '#Reference1', caption: data.ReferenceCaption1, type: data.ReferenceType1, required: data.ReferenceRequired1, lookup: data.ReferenceLookupList1, condition: data.ReferenceCondition1 },
                        { id: '#Reference2', caption: data.ReferenceCaption2, type: data.ReferenceType2, required: data.ReferenceRequired2, lookup: data.ReferenceLookupList2, condition: data.ReferenceCondition2 },
                        { id: '#Reference3', caption: data.ReferenceCaption3, type: data.ReferenceType3, required: data.ReferenceRequired3, lookup: data.ReferenceLookupList3, condition: data.ReferenceCondition3 },
                        { id: '#Reference4', caption: data.ReferenceCaption4, type: data.ReferenceType4, required: data.ReferenceRequired4, lookup: data.ReferenceLookupList4, condition: data.ReferenceCondition4 },
                        { id: '#Reference5', caption: data.ReferenceCaption5, type: data.ReferenceType5, required: data.ReferenceRequired5, lookup: data.ReferenceLookupList5, condition: data.ReferenceCondition5 },
                        { id: '#Reference6', caption: data.ReferenceCaption6, type: data.ReferenceType6, required: data.ReferenceRequired6, lookup: data.ReferenceLookupList6, condition: data.ReferenceCondition6 },
                        { id: '#Reference7', caption: data.ReferenceCaption7, type: data.ReferenceType7, required: data.ReferenceRequired7, lookup: data.ReferenceLookupList7, condition: data.ReferenceCondition7 },
                        { id: '#Reference8', caption: data.ReferenceCaption8, type: data.ReferenceType8, required: data.ReferenceRequired8, lookup: data.ReferenceLookupList8, condition: data.ReferenceCondition8 },
                        { id: '#Reference9', caption: data.ReferenceCaption9, type: data.ReferenceType9, required: data.ReferenceRequired9, lookup: data.ReferenceLookupList9, condition: data.ReferenceCondition9 },
                        { id: '#Reference10', caption: data.ReferenceCaption10, type: data.ReferenceType10, required: data.ReferenceRequired10, lookup: data.ReferenceLookupList10, condition: data.ReferenceCondition10 }
                    ];

                    ReferenceHandler(data.ReferenceCaption1, data.ReferenceType1, data.ReferenceRequired1, data.ReferenceLookupList1, 'Reference1',);
                    ReferenceHandler(data.ReferenceCaption2, data.ReferenceType2, data.ReferenceRequired2, data.ReferenceLookupList2, 'Reference2');
                    ReferenceHandler(data.ReferenceCaption3, data.ReferenceType3, data.ReferenceRequired3, data.ReferenceLookupList3, 'Reference3');
                    ReferenceHandler(data.ReferenceCaption4, data.ReferenceType4, data.ReferenceRequired4, data.ReferenceLookupList4, 'Reference4');
                    ReferenceHandler(data.ReferenceCaption5, data.ReferenceType5, data.ReferenceRequired5, data.ReferenceLookupList5, 'Reference5');
                    ReferenceHandler(data.ReferenceCaption6, data.ReferenceType6, data.ReferenceRequired6, data.ReferenceLookupList6, 'Reference6');
                    ReferenceHandler(data.ReferenceCaption7, data.ReferenceType7, data.ReferenceRequired7, data.ReferenceLookupList7, 'Reference7');
                    ReferenceHandler(data.ReferenceCaption8, data.ReferenceType8, data.ReferenceRequired8, data.ReferenceLookupList8, 'Reference8');
                    ReferenceHandler(data.ReferenceCaption9, data.ReferenceType9, data.ReferenceRequired9, data.ReferenceLookupList9, 'Reference9');
                    ReferenceHandler(data.ReferenceCaption10, data.ReferenceType10, data.ReferenceRequired10, data.ReferenceLookupList10, 'Reference10');

                    if (data.ReferenceCaption3 === 'INTERMEDIARIO') {
                        $('#Reference3').val(localStorage.getItem('Username'));
                        $('#Reference3').prop("disabled", true);
                    } else {
                        $('#Reference3').prop("disabled", false);
                    }

                });
        });

        $('#UserId').change(function () {
            let user = app.core.Data().lookups.filter(i => i.Key === 'Users')[0].Lkp.filter(l => l.Code === $('#UserId').val())[0];
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

    function ReferenceHandler(caption, type, required, valueList, id) {
        if (caption != '') {
            if (required)
                $("label[for='" + id + "']").html(caption + "<span class='required-mark' title='Este campo debe ser llenado de forma obligatoria'>*</span>");
            else
                $("label[for='" + id + "']").html(caption);

            if (valueList == '') {
                $('#' + id).removeClass('d-none');
                $('#' + id + 'List').addClass('d-none');
            }
            else {
                $('#' + id).addClass('d-none');
                let selectedOptions = $('#' + id + 'List');
                selectedOptions.removeClass('d-none');
                selectedOptions.children().remove();

                selectedOptions.append($('<option selected />').val('').text(''));
                $.each(valueList.split(';'), function () {
                    selectedOptions.append($('<option />').val(this.trim()).text(this.trim()));
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

    function ApplyConditions() {
        let data = MapInputToObject();
        data.roles = JSON.parse(localStorage.getItem('Roles'));
        data.etapa = '';

        refFields.forEach(function (field) {
            if (field.condition) {
                let mode = 'notvisible';
                let condition = field.condition.trim();

                if (condition.startsWith('ocultar:')) {
                    mode = 'notvisible';
                    condition = condition.replace('ocultar:', '').trim();
                }

                if (mode == 'notvisible') {
                    let result = eval(condition);
                    if (result) {
                        $(field.id).parent().parent().addClass('d-none');
                    } else {
                        $(field.id).parent().parent().removeClass('d-none');
                    }
                }
            }
        });
    }

    function Create(uidata, mode) {
        uidata.CurrentToken = _currentToken;
        app.core.Post(app.setting.apipath + 'v1/ProcessCase', JSON.stringify(uidata), undefined, undefined, true, Token_Ali)
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El processcase '" + uidata.Title + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                window.location.replace("Seguimiento_Al?id=" + data.Id);
            }).always(function () {
                app.ui.ButtonDone('#ProcessCaseEdtFormSave');
            });
    }

    function Init_Lookups() {
        let roleslist = JSON.parse(localStorage.getItem('Roles')).join();
        app.core.Lookups(['CasePriority.Priority', 'ProcessStatus.Status', 'ProcessByRolInformed.FlowId', 'Users.UserId.', 'SLA.SLA.'],
            function () {
                app.CentralCase.New();
            }, 'rolelist=' + roleslist, "v1/Common/Lkps", Token_Ali);
    }

    function MapInputToObject() {
        return {
            Id: parseInt(0 + $('#Id').val(), 10),
            Title: $('#Title').val(),
            Description: $('#Description').val(),
            Priority: $('#Priority').val(),
            PriorityDesc: app.ui.GetDropDownSelectedText('#Priority'),
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
            Attachments: $('#dropzone').fileUploader('files')
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
        //$('#FlowId').val(data.FlowId);
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
                    _currentToken = data.CurrentToken;
                    Init_Lookups();
                    Init_Controls();
                    Event_Controls();
                    Setup_Validations();
                    app.Attachments.Init({ EntityType: 1304, Id: 0, PostByEachRow: false, AlternateToken: Token_Ali });
                    app.language.translate('body', 'CasesAliados')();
                })
        },
        New: function (row) {
            let newRow = { Id: 0, Title: null, Description: null, Priority: 4, InstanceId: 0, Reference1: null, Reference2: null, Reference3: null, Reference4: null, Reference5: null, ContactMainName: null, ContactMainEmail: null, Status: 0, Label: null, SubStatus: 0, SubLabel: null, FlowId: null, UserId: null }
            if (row !== undefined) {
                row.Id = 0;
                newRow = row;
            }
            if (aliUser != null && aliUser != '') {
                let user = app.core.Data().lookups.filter(i => i.Key === 'Users')[0].Lkp.filter(l => l.IUSERNAME === aliUser)[0];
                if (user != null) {
                    newRow.UserId = user.Code;
                }
            }
            EditMode(newRow);
            $('#UserId').change();
        }
    };
})();
