var app = app || {};

app.GeneralCase = (function () {
    let _data = null;
    let _refDef = [];
    let _allowref = [];
    let _managerLinks = null;
    let _instance = null;
    let refFields = [];
    let _currentStep = null;

    function ApplyConditions() {
        if (_refDef.length > 0) {
            let data = { roles: JSON.parse(localStorage.getItem('Roles')), etapa: _currentStep.Name, PriorityDesc: _data.PriorityDesc };
            $.each(_refDef, function () {
                data[this.id] = $(this.ctrl).val();
            });

            _refDef.forEach(function (rd) {
                let field = refFields.find(r => r.id == rd.id);
                if (field?.condition) {
                    let mode = 'notvisible';
                    let condition = field.condition.trim();

                    if (condition.startsWith('ocultar:')) {
                        mode = 'notvisible';
                        condition = condition.replace('ocultar:', '').trim();
                    }

                    if (mode == 'notvisible') {
                        let result = eval(condition);
                        if (result) {
                            $('#ReferenceCaption' + field.index).addClass('d-none');
                            $(field.id).addClass('d-none');
                            //$('#EReference' + field.index).parent().parent().addClass('d-none');
                        } else {
                            $('#ReferenceCaption' + field.index).removeClass('d-none');
                            $(field.id).removeClass('d-none');
                            //$('#EReference' + field.index).parent().parent().removeClass('d-none');
                        }
                    }
                }
            });
        }
    }

    function Event_Controls() {
        //$(".historyPanel").appendTo('.sidebar-content');
        //$('#right-sidebar').attr('style', 'width: 300px !important; right: -300px');

        //$(".historyPanel").removeClass('d-none');
        //$('#sidebarTitle').html("<h3>Historial</h3>");

        $("#ReferencesEdtForm :input").change(function () {
            $('#ProcessStepAccept').prop("disabled", false);
            ApplyConditions();
        });

        $('#dropzone').fileUploader({
            maxFilesize: 256,
            done: function (responses) {
                //console.log('Init_Controls: Archivos subidos exitosamente:', responses);
                //toastr.success('Archivos cargados correctamente', '', {
                //    timeOut: 3000,
                //    closeButton: true
                //});
            },
            fail: function (error, file) {
                //console.error('Init_Controls: Error al subir archivo:', error, file);
                //var errorMsg = typeof error === 'string' ? error :
                //    (error.message || 'Error desconocido');
                //toastr.error('Error al subir el archivo: ' + file.name + ' - ' + errorMsg, '', {
                //    timeOut: 5000,
                //    closeButton: true
                //});
            },
            always: function (result) {
                console.log('Init_Controls: Proceso de carga completado:', result);
            }
        });

        $('#ProcessStepAccept').click(function (e) {
            e.preventDefault();
            $('fieldset').prop("disabled", true);
            app.ui.ButtonDoing('#ProcessStepAccept', false);
            TaskChecked(_data.InstanceId, app.ui.GetRadioNumericValue('task'), $('#Annotation').val(), $('#CustomNotify').is(':checked'));
        });

        $('.Historial-link').click(function (e) {
            e.preventDefault();
            $('#right-sidebar').toggleClass('sidebar-open');
        });

        _managerLinks = app.ManagerLinks.Init({ ContainerOver: "page-wrapper > div.wrapper.wrapper-content.animated.fadeInRight > div > div.col-sm-12 > div", ContainerTab: "tabs", CantainerLinks: "ExternalLinks", Type: "Integrated" });
    }

    function Init_Lookups() {
        app.core.Lookups(['ProcessStatus.Status', 'Process.FlowId', 'Users.UserId'], Dynamic_Event_Controls);
        // Dependencies
    }

    function Dynamic_Event_Controls() {
        var _id = app.core.URLNumericValue('id');
        if (_id !== 0) {
            EditMode({ Id: _id });
        }
        else {
            EditMode({ Id: 7 });
        }
    }

    function MapObjectToInput(data) {
        $('#ContactMainName').html(data.ContactMainName);
        $('#ContactMainEmail').html(data.ContactMainEmail);

        $('#Title').html(data.Title);
        $('#FlowIdDesc').html(data.FlowIdDesc + '.');
        let status = data.StatusDesc;
        if (data.SubLabel != '') {
            status += ' / ' + data.SubLabel;
        }
        $('#StatusDesc').html(status);
        $('#StatusDesc').addClass('label-warning-light');

        if (data.Description != '') {
            $('.description-col').removeClass('d-none');
            $('#Description').html(data.Description);
        }

        $('#PriorityDesc').html(data.PriorityDesc);

        $('#SLADesc').html(data.SLADesc);

        for (let i = 1; i <= 10; i++) {
            $(`#EReference${i}`).parent().parent().addClass('d-none');
        }

        app.core.Get(app.setting.apipath + 'v1/ProcessSpecFlow/' + data.FlowId)
            .done(function (dataFlow, textStatus, jqXHR) {
                _refDef = [];

                refFields = [
                    { id: 'Reference1', index: 1, caption: dataFlow.ReferenceCaption1, type: dataFlow.ReferenceType1, required: dataFlow.ReferenceRequired1, lookup: dataFlow.ReferenceLookupList1, condition: dataFlow.ReferenceCondition1 },
                    { id: 'Reference2', index: 2, caption: dataFlow.ReferenceCaption2, type: dataFlow.ReferenceType2, required: dataFlow.ReferenceRequired2, lookup: dataFlow.ReferenceLookupList2, condition: dataFlow.ReferenceCondition2 },
                    { id: 'Reference3', index: 3, caption: dataFlow.ReferenceCaption3, type: dataFlow.ReferenceType3, required: dataFlow.ReferenceRequired3, lookup: dataFlow.ReferenceLookupList3, condition: dataFlow.ReferenceCondition3 },
                    { id: 'Reference4', index: 4, caption: dataFlow.ReferenceCaption4, type: dataFlow.ReferenceType4, required: dataFlow.ReferenceRequired4, lookup: dataFlow.ReferenceLookupList4, condition: dataFlow.ReferenceCondition4 },
                    { id: 'Reference5', index: 5, caption: dataFlow.ReferenceCaption5, type: dataFlow.ReferenceType5, required: dataFlow.ReferenceRequired5, lookup: dataFlow.ReferenceLookupList5, condition: dataFlow.ReferenceCondition5 },
                    { id: 'Reference6', index: 6, caption: dataFlow.ReferenceCaption6, type: dataFlow.ReferenceType6, required: dataFlow.ReferenceRequired6, lookup: dataFlow.ReferenceLookupList6, condition: dataFlow.ReferenceCondition6 },
                    { id: 'Reference7', index: 7, caption: dataFlow.ReferenceCaption7, type: dataFlow.ReferenceType7, required: dataFlow.ReferenceRequired7, lookup: dataFlow.ReferenceLookupList7, condition: dataFlow.ReferenceCondition7 },
                    { id: 'Reference8', index: 8, caption: dataFlow.ReferenceCaption8, type: dataFlow.ReferenceType8, required: dataFlow.ReferenceRequired8, lookup: dataFlow.ReferenceLookupList8, condition: dataFlow.ReferenceCondition8 },
                    { id: 'Reference9', index: 9, caption: dataFlow.ReferenceCaption9, type: dataFlow.ReferenceType9, required: dataFlow.ReferenceRequired9, lookup: dataFlow.ReferenceLookupList9, condition: dataFlow.ReferenceCondition9 },
                    { id: 'Reference10', index: 10, caption: dataFlow.ReferenceCaption10, type: dataFlow.ReferenceType10, required: dataFlow.ReferenceRequired10, lookup: dataFlow.ReferenceLookupList10, condition: dataFlow.ReferenceCondition10 }
                ];

                for (let i = 1; i <= 10; i++) {
                    $(`#ReferenceCaption${i}`).html(dataFlow[`ReferenceCaption${i}`]);
                    $(`#Reference${i}`).html(_data[`#Reference${i}`] === '' ? '...' : _data[`Reference${i}`]);
                    $(`#Reference${i}`).parent().removeClass('d-none');
                }

                $.each(_allowref, function () {
                    let i = parseInt(this.Code.replace(/[^0-9]/g, ''));

                    ReferenceHandler(dataFlow[`ReferenceCaption${i}`], dataFlow[`ReferenceType${i}`], dataFlow[`ReferenceRequired${i}`], dataFlow[`ReferenceLookupList${i}`], `Reference${i}`, i);
                });

                ApplyConditions();

                if (_allowref.length > 0) {
                    $('.references-section').removeClass('d-none');
                } else {
                    $('.references-section').addClass('d-none');
                }

                $('#TotalDays').html(data.TotalDays);

                app.Notes.Init({
                    EntityType: 1304,
                    Id: data.Id,
                    PostByEachRow: true,
                    ShowContactNotify: true,
                    ShowResponsibleNotify: true,
                    CallbackDone: function (noteNotify) {
                        noteNotify.InstanceId = _data.InstanceId;
                        noteNotify.Type = 'Note';

                        console.log(noteNotify);
                        Notify(noteNotify);
                    }
                });

                app.core.Get(app.setting.apipath + `v1/Common/Attachments?entityType=1304&entityId=${_data.Id}`)
                    .done(function (dataItems) {
                        $('#dropzone').fileUploader('load', dataItems, { EntityType: 1304, EntityId: data.Id, DocumentType: 1, Description : "General" }  );
                    }).always(function () {
                    });

                //app.Attachments.Init({ EntityType: 1304, Id: data.Id, PostByEachRow: true, showTitle: false });

                _managerLinks.MapObjectToInput(data);
            });
    }

    async function ReferenceHandler(caption, type, required, valueList, id, index) {
        if (caption != '') {
            if (required)
                $("label[for='E" + id + "']").html(caption + "<span class='required-mark' title='Este campo debe ser llenado de forma obligatoria'>*</span>");
            else
                $("label[for='E" + id + "']").html(caption);

            if (valueList == '') {
                $('#E' + id).removeClass('d-none');
                $('#E' + id).val(_data[id]);
                $('#E' + id + 'List').addClass('d-none');
                _refDef.push({ id: id, ctrl: '#E' + id });
            }
            else {
                $('#E' + id).addClass('d-none');
                let selectedOptions = $('#E' + id + 'List');
                let value = _data[id].trim();
                selectedOptions.removeClass('d-none');
                selectedOptions.children().remove();

                selectedOptions.append($('<option />').val('').text(''));
                $.each(valueList.split(';'), function () {
                    selectedOptions.append($('<option />').val(this.trim()).text(this.trim()));
                });
                selectedOptions.val(_data[id]);
                _refDef.push({ id: id, ctrl: '#E' + id + 'List' });
            }
            $('#E' + id).parent().parent().removeClass('d-none');
        } else {
            $('#E' + id).parent().parent().addClass('d-none');
            $('#E' + id).addClass('d-none');
            $('#E' + id + 'List').addClass('d-none');
            $('#E' + id + 'List').val('');
        }
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
                FlowId: {
                    required: true
                }
            },
            messages: {
                FlowId: {
                    required: 'Debe indicar el proceso'
                }
            }
        });
    }

    function EditMode(row) {
        $('.ibox-content').toggleClass('sk-loading');
        app.core.Get(app.setting.apipath + 'v1/ProcessCase/' + row.Id)
            .done(function (data, textStatus, jqXHR) {
                _data = data;
                _allowref = [];
                app.processHandler.RefreshProcess(data.InstanceId, true,
                    function (newData, ref, currentStep) {
                        _instance = newData;
                        MapObjectToInput(_data);
                        _allowref = ref;
                        _currentStep = currentStep;
                    });
                $('#Title').focus();
            }).always(function () {
                $('.ibox-content').toggleClass('sk-loading');
            });
    }

    function OptionSelected() {
        $('#ProcessStepAccept').prop("disabled", false);
    }

    function Notify(notify) {
        app.core.Post(app.setting.apipath + `v1/Process/Notify`,
            JSON.stringify(notify))
            .done(function (data, textStatus, jqXHR) {
            }).always(function () {
            });
    }

    function TaskChecked(instanceId, activityId, comment, notify) {
        let references = [];
        if (_refDef.length > 0) {
            $.each(_refDef, function () {
                references.push({ Code: this.id, Description: $(this.ctrl).val() });
            });
        }

        app.core.Put(app.setting.apipath + `v1/Process/Task/Checked/${instanceId}`,
            JSON.stringify({
                StepId: _instance.ActivityId,
                ActivityId: activityId,
                Comment: comment,
                Notify: notify,
                References: references
            }))
            .done(function (data, textStatus, jqXHR) {
                if (activityId === 0) {
                    $('#ProcessStepAccept').prop("disabled", true);
                } else {
                    EditMode({ Id: _data.Id });
                }
            }).always(function () {
                app.ui.ButtonDone('#ProcessStepAccept', false);
            });
    }

    return {
        Init: function () {
            app.processHandler = new Process();

            app.processHandler.Init_List_Process();

            Event_Controls();
            Setup_Validations();
            Init_Lookups();
            app.language.translate('body', 'Case')();

        },
        EditRow: function (row) {
            EditMode(row);
        },
        Checked: function (activityId) {
            console.log(activityId);
            //$('#task_142').is(':checked')
            TaskChecked(_data.InstanceId, activityId, '', true);
        },
        Enable: function (params, $el, xid, url) {
            OptionSelected();
        },
        Data: function () {
            return { case: _data, instance: _instance, links: _managerLinks };
        }
    };
})();