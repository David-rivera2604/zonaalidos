var app = app || {};

app.GeneralNewCase = (function () {

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
            app.core.Get(app.setting.apipath + 'v1/ProcessSpecFlow/' + $('#FlowId').val())
                .done(function (data, textStatus, jqXHR) {
                    ReferenceHandler(data.ReferenceCaption1, data.ReferenceLookupList1, 'Reference1');
                    ReferenceHandler(data.ReferenceCaption2, data.ReferenceLookupList2, 'Reference2');
                    ReferenceHandler(data.ReferenceCaption3, data.ReferenceLookupList3, 'Reference3');
                    ReferenceHandler(data.ReferenceCaption4, data.ReferenceLookupList4, 'Reference4');
                    ReferenceHandler(data.ReferenceCaption5, data.ReferenceLookupList5, 'Reference5');
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
        app.core.Post(app.setting.apipath + 'v1/ProcessCase', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El processcase '" + uidata.Title + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                window.location.replace("case?id=" + data.Id);
            }).always(function () {
                app.ui.ButtonDone('#ProcessCaseEdtFormSave');
            });
    }

    function Init_Lookups() {
        app.core.Lookups(['CasePriority.Priority', 'ProcessStatus.Status', 'ProcessByRol.FlowId', 'Users.UserId.', 'SLA.SLA.'],
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
            ContactMainName: $('#ContactMainName').val(),
            ContactMainEmail: $('#ContactMainEmail').val(),
            Status: $('#Status').val(),
            Label: $('#Label').val(),
            SubStatus: app.ui.GetNumericValue('#SubStatus'),
            SubLabel: $('#SubLabel').val(),
            FlowId: $('#FlowId').val(),
            UserId: $('#UserId').val()
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
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Setup_Validations();

        },
        New: function (row) {
            let newRow = { Id: 0, Title: null, Description: null, Priority: 4, InstanceId: 0, Reference1: null, Reference2: null, Reference3: null, Reference4: null, Reference5: null, ContactMainName: null, ContactMainEmail: null, Status: 0, Label: null, SubStatus: 0, SubLabel: null, FlowId: null, UserId: null }
            if (row !== undefined) {
                row.Id = 0;
                newRow = row;
            }
            EditMode(newRow);
        }
    };
})();