var app = app || {};

app.GeneralNewCase = (function () {
    let flowSpec = null;

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

        $('#ProcessCaseEdtFormSave').click(function () {
            if (app.ui.IsValid('#ProcessCaseEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessCaseEdtFormSave');
                var data = MapInputToObject();
                if (data.Id === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#ProcessCaseEdtFormCancel').click(function () {
            event.preventDefault();
        });

        $('#FlowId').change(function () {
            let flowId = $('#FlowId').val();
            let sla = app.core.Data().lookups.filter(i => i.Key === 'ProcessByRolDetail')[0].Lkp.filter(l => l.Code === flowId + '')[0].SLA;
            $('#SLA').val(sla);
            app.core.Get(app.setting.apipath + 'v1/ProcessSpecFlow/' + flowId)
                .done(function (data, textStatus, jqXHR) {
                    flowSpec = data;
                    ReferenceHandler(data.ReferenceCaption1, data.ReferenceType1, data.ReferenceRequired1, data.ReferenceLookupList1, 'Reference1');
                    ReferenceHandler(data.ReferenceCaption2, data.ReferenceType2, data.ReferenceRequired2, data.ReferenceLookupList2, 'Reference2');
                    ReferenceHandler(data.ReferenceCaption3, data.ReferenceType3, data.ReferenceRequired3, data.ReferenceLookupList3, 'Reference3');
                    ReferenceHandler(data.ReferenceCaption4, data.ReferenceType4, data.ReferenceRequired4, data.ReferenceLookupList4, 'Reference4');
                    ReferenceHandler(data.ReferenceCaption5, data.ReferenceType5, data.ReferenceRequired5, data.ReferenceLookupList5, 'Reference5');
                    ReferenceHandler(data.ReferenceCaption6, data.ReferenceType6, data.ReferenceRequired6, data.ReferenceLookupList6, 'Reference6');
                    ReferenceHandler(data.ReferenceCaption7, data.ReferenceType7, data.ReferenceRequired7, data.ReferenceLookupList7, 'Reference7');
                    ReferenceHandler(data.ReferenceCaption8, data.ReferenceType8, data.ReferenceRequired8, data.ReferenceLookupList8, 'Reference8');
                    ReferenceHandler(data.ReferenceCaption9, data.ReferenceType9, data.ReferenceRequired9, data.ReferenceLookupList9, 'Reference9');
                    ReferenceHandler(data.ReferenceCaption10, data.ReferenceType10, data.ReferenceRequired10, data.ReferenceLookupList10, 'Reference10');
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
        app.core.Post(app.setting.apipath + 'v1/ProcessCase', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El processcase '" + uidata.Title + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                window.location.replace("case?id=" + data.Id);
            }).always(function () {
                app.ui.ButtonDone('#ProcessCaseEdtFormSave');
            });
    }

    function Init_Lookups() {
        app.core.Lookups(['CasePriority.Priority', 'ProcessStatus.Status', 'ProcessByRolDetail.FlowId', 'ProcessByRol.FlowId', 'Users.UserId.', 'SLA.SLA.'],
            function () {
                app.GeneralNewCase.New();
            });
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
            Reference6: $('#Reference6').val() + $('#Reference6List').val(),
            Reference7: $('#Reference7').val() + $('#Reference7List').val(),
            Reference8: $('#Reference8').val() + $('#Reference8List').val(),
            Reference9: $('#Reference9').val() + $('#Reference9List').val(),
            Reference10: $('#Reference10').val() + $('#Reference10List').val(),
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
        $('#Reference6').val(data.Reference6);
        $('#Reference7').val(data.Reference7);
        $('#Reference8').val(data.Reference8);
        $('#Reference9').val(data.Reference9);
        $('#Reference10').val(data.Reference10);
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
        $.validator.addMethod("DynamicRequired",
            function (value, element, params) {
                let id = element.id.replace('List', '');
                id = id.substring(id.length - 1, id.length);
                if (id === '0')
                    id = '10';
                if (flowSpec['ReferenceRequired' + id] == true) {
                    $('#' + element.id).rules('add', {
                        messages: {
                            DynamicRequired: `Debe indicar un valor para ${flowSpec['ReferenceCaption' + id]}`
                        }
                    });
                    return (value != null && value != "");
                }

                else
                    return true;
            }
        );
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
                },
                Reference1: {
                    DynamicRequired: true
                },
                Reference1List: {
                    DynamicRequired: true
                },
                Reference2: {
                    DynamicRequired: true
                },
                Reference2List: {
                    DynamicRequired: true
                },
                Reference3: {
                    DynamicRequired: true
                },
                Reference3List: {
                    DynamicRequired: true
                },
                Reference4: {
                    DynamicRequired: true
                },
                Reference4List: {
                    DynamicRequired: true
                },
                Reference5: {
                    DynamicRequired: true
                },
                Reference5List: {
                    DynamicRequired: true
                },
                Reference6: {
                    DynamicRequired: true
                },
                Reference6List: {
                    DynamicRequired: true
                },
                Reference7: {
                    DynamicRequired: true
                },
                Reference7List: {
                    DynamicRequired: true
                },
                Reference8: {
                    DynamicRequired: true
                },
                Reference8List: {
                    DynamicRequired: true
                },
                Reference9: {
                    DynamicRequired: true
                },
                Reference9List: {
                    DynamicRequired: true
                },
                Reference10: {
                    DynamicRequired: true
                },
                Reference10List: {
                    DynamicRequired: true
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
                },
                Reference1: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference1List: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference2: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference2List: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference3: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference3List: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference4: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference4List: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference5: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference5List: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference6: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference6List: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference7: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference7List: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference8: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference8List: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference9: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference9List: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference10: {
                    DynamicRequired: 'Debe indicar un valor'
                },
                Reference10List: {
                    DynamicRequired: ''
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
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Setup_Validations();

            app.Attachments.Init({ EntityType: 1304, Id: 0, PostByEachRow: false });
        },
        New: function (row) {
            let newRow = { Id: 0, Title: null, Description: null, Priority: 4, InstanceId: 0, Reference1: null, Reference2: null, Reference3: null, Reference4: null, Reference5: null, Reference6: null, Reference7: null, Reference8: null, Reference9: null, Reference10: null, ContactMainName: null, ContactMainEmail: null, Status: 0, Label: null, SubStatus: 0, SubLabel: null, FlowId: null, UserId: null }
            if (row !== undefined) {
                row.Id = 0;
                newRow = row;
            }
            EditMode(newRow);
        }
    };
})();