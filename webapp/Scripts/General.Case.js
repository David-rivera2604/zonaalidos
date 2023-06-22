var app = app || {};

app.GeneralCase = (function () {

    let _data = null;
    let _managerLinks = null;
    let _instance = null;

    function Event_Controls() {

        //$(".historyPanel").appendTo('.sidebar-content');
        //$('#right-sidebar').attr('style', 'width: 300px !important; right: -300px');

        //$(".historyPanel").removeClass('d-none');
        //$('#sidebarTitle').html("<h3>Historial</h3>");

        $("#ReferencesEdtForm :input").change(function () {
            $('#ReferencesEdtFormSave').removeClass('d-none');
        });

        $('#ProcessStepAccept').click(function () {
            event.preventDefault();
            $('fieldset').prop("disabled", true);
            app.ui.ButtonDoing('#ProcessStepAccept', false);
            TaskChecked(_data.InstanceId, app.ui.GetRadioNumericValue('task'), $('#Annotation').val(), $('#CustomNotify').is(':checked'));
        });

        $('.Historial-link').click(function () {
            event.preventDefault();
            $('#right-sidebar').toggleClass('sidebar-open');
        });

        $('#saveNote').click(function () {
            event.preventDefault();

            app.ui.ButtonDoing('#saveNote');
            app.core.Post(app.setting.apipath + 'v1/Common/Note',
                JSON.stringify({
                    Id: null,
                    EntityType: 1304,
                    EntityId: _data.Id,
                    Note: $('#newNote').val(),
                    Private: false,
                    NoteOwnerId: 0,
                    ParentSequence: 0
                }))
                .done(function (data, textStatus, jqXHR) {
                    $('#newNote').val('');
                    NotasDraw(_data.Id);
                }).always(function () {
                    app.ui.ButtonDone('#saveNote');
                });
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

        $('#Description').html(data.Description);

        $('#PriorityDesc').html(data.PriorityDesc);

        $('#SLADesc').html(data.SLADesc);

        app.core.Get(app.setting.apipath + 'v1/ProcessSpecFlow/' + data.FlowId)
            .done(function (dataFlow, textStatus, jqXHR) {
                if (dataFlow.ReferenceCaption1 != '') {
                    $('#ReferenceCaption1').html(dataFlow.ReferenceCaption1);
                    $('#Reference1').html(data.Reference1 === '' ? '...' : data.Reference1);
                    $('#Reference1').parent().removeClass('d-none');
                }
                if (dataFlow.ReferenceCaption2 != '') {
                    $('#ReferenceCaption2').html(dataFlow.ReferenceCaption2);
                    $('#Reference2').html(data.Reference2 === '' ? '...' : data.Reference2);
                    $('#Reference2').parent().removeClass('d-none');
                }
                if (dataFlow.ReferenceCaption3 != '') {
                    $('#ReferenceCaption3').html(dataFlow.ReferenceCaption3);
                    $('#Reference3').html(data.Reference3 === '' ? '...' : data.Reference3);
                    $('#Reference3').parent().removeClass('d-none');
                }
                if (dataFlow.ReferenceCaption4 != '') {
                    $('#ReferenceCaption4').html(dataFlow.ReferenceCaption4);
                    $('#Reference4').html(data.Reference4 === '' ? '...' : data.Reference4);
                    $('#Reference4').parent().removeClass('d-none');
                }
                if (dataFlow.ReferenceCaption5 != '') {
                    $('#ReferenceCaption5').html(dataFlow.ReferenceCaption5);
                    $('#Reference5').html(data.Reference5 === '' ? '...' : data.Reference5);
                    $('#Reference5').parent().removeClass('d-none');
                }
                if (dataFlow.ReferenceCaption6 != '') {
                    $('#ReferenceCaption6').html(dataFlow.ReferenceCaption6);
                    $('#Reference6').html(data.Reference6 === '' ? '...' : data.Reference6);
                    $('#Reference6').parent().removeClass('d-none');
                }
                if (dataFlow.ReferenceCaption7 != '') {
                    $('#ReferenceCaption7').html(dataFlow.ReferenceCaption7);
                    $('#Reference7').html(data.Reference7 === '' ? '...' : data.Reference7);
                    $('#Reference7').parent().removeClass('d-none');
                }
                if (dataFlow.ReferenceCaption8 != '') {
                    $('#ReferenceCaption8').html(dataFlow.ReferenceCaption8);
                    $('#Reference8').html(data.Reference8 === '' ? '...' : data.Reference8);
                    $('#Reference8').parent().removeClass('d-none');
                }
                if (dataFlow.ReferenceCaption9 != '') {
                    $('#ReferenceCaption9').html(dataFlow.ReferenceCaption9);
                    $('#Reference9').html(data.Reference9 === '' ? '...' : data.Reference9);
                    $('#Reference9').parent().removeClass('d-none');
                }
                if (dataFlow.ReferenceCaption10 != '') {
                    $('#ReferenceCaption10').html(dataFlow.ReferenceCaption10);
                    $('#Reference10').html(data.Reference10 === '' ? '...' : data.Reference10);
                    $('#Reference10').parent().removeClass('d-none');
                }

                for (let i = 1; i <= 10; i++) {
                    ReferenceHandler(dataFlow[`ReferenceCaption${i}`], dataFlow[`ReferenceType${i}`], dataFlow[`ReferenceRequired${i}`], dataFlow[`ReferenceLookupList${i}`], `Reference${i}`);
                }

                NotasDraw(data.Id);
                AttachmentDraw(data.Id);

                _managerLinks.MapObjectToInput(data);
            });
    }

    async function ReferenceHandler(caption, type, required, valueList, id) {
        if (caption != '') {
            if (required)
                $("label[for='E" + id + "']").html(caption + "<span class='required-mark' title='Este campo debe ser llenado de forma obligatoria'>*</span>");
            else
                $("label[for='E" + id + "']").html(caption);

            if (valueList == '') {
                $('#E' + id).removeClass('d-none');
                $('#E' + id).val(_data[id]);
            }
            else {
                let selectedOptions = $('#E' + id + 'List');
                selectedOptions.removeClass('d-none');
                selectedOptions.children().remove();

                selectedOptions.append($('<option selected />').val('').text(''));
                $.each(valueList.split(';'), function () {
                    selectedOptions.append($('<option />').val(this).text(this));
                });
                selectedOptions.val(_data[id]);
            }
            //$('#E' + id).parent().parent().removeClass('d-none');
        } else {
            $('#E' + id).parent().parent().addClass('d-none');
            $('#E' + id).addClass('d-none');
            $('#E' + id + 'List').addClass('d-none');
            $('#E' + id + 'List').val('');
        }
    }

    async function EnableReference(dataRef) {
        let data = JSON.parse(dataRef);
        for (let i = 1; i <= 10; i++) {
            $(`#EReference${i}`).parent().parent().addClass('d-none');
        }
        $('#ReferencesEdtFormSave').addClass('d-none');
        $.each(data, function () {
            $('#E' + this.Code).parent().parent().removeClass('d-none');
        });
        if (data.length > 0) {
            $('.references-section').removeClass('d-none');
        }
    }

    function NotasDraw(entityId) {

        app.core.Get(app.setting.apipath + 'v1/Common/Notes?entityType=1304&entityId=' + entityId)
            .done(function (notes) {
                let initial = '', info = '', last = '';
                let noteList = $('.chat-activity-list');
                noteList.html('');
                notes.forEach(function (item, index) {

                    initial = item.UpdateUserName.split(/\s/).reduce((response, word) => response += word.slice(0, 1), '').toUpperCase();
                    info = index % 2 === 0 ? 'success' : 'info';
                    last = index === notes.length - 1 ? 'text-navy' : '';
                    noteList.append(
                        `<div class="chat-element"><a href="#" class="float-left"><span class="label label-${info}">${initial}</span></a>` +
                        '<div class="media-body">' +
                        `<small class="float-right ${last}">` + moment(item.UpdateDate).from() + '</small>' +
                        `<p class="m-b-xs">${item.Note}</p>` +
                        `<strong>${item.UpdateUserName} </strong><small class="text-muted"><i class="fa fa-clock-o"></i> ` + moment(item.UpdateDate).calendar() + ' - ' + moment(item.UpdateDate).format('DD/MM/YYYY') + '</small>' +
                        '</div>' +
                        '</div>');
                });

            });
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
                MapObjectToInput(data);
                $('#Title').focus();
                RefreshProcess(data.InstanceId);
            }).always(function () {
                $('.ibox-content').toggleClass('sk-loading');
            });
    }

    function Init_List_Process() {
        $('#ProcessGridTbl').bootstrapTable({
            uniqueId: 'ActivityId',
            pagination: false,
            //search: true,
            //showRefresh: true,
            smartDisplay: true,
            //detailView: false,
            //detailFormatter: 'app.ui.GenericDetailFormatter',
            //headerStyle: function (column) {
            //    return {
            //        css: {
            //            'background': 'lightsteelblue'
            //        }
            //    }
            //},
            rowStyle: function (row, index) {
                return {
                    css: {
                        'vertical-align': 'top'
                    }
                }
            },
            columns: [
                {
                    field: 'Name',
                    title: 'Etapa',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    //cellStyle: function (value, row, index) {
                    //    return {
                    //        css: {
                    //            'background': 'lightsteelblue'
                    //        }
                    //    }
                    //},
                    formatter: function (value, row, index, field) {
                        var result = '';
                        var status = 'fa-check';
                        var color = 'green';
                        var styleTitle = 'font-weight: 600;';
                        var title = 'Procesado';
                        if (row.FinishDate === null || row.FinishDate === '0001-01-01T00:00:00') {
                            status = 'fa-clock-o';
                            color = 'yellowgreen';
                            title = 'Etapa en progreso';
                        }
                        if (row.StartDate === null || row.StartDate === '0001-01-01T00:00:00') {
                            status = 'fa-clock-o';
                            color = 'gray';
                            styleTitle = '';
                            title = 'Etapa sin procesar';
                            if (row.Wait === '') {
                                status = 'fa-chain-broken';
                                styleTitle = 'text-decoration: line-through;color: gray'
                                title = 'Etapa no necesaria para el caso';
                            }
                        }
                        result = `<i class="fa ${status}" aria-hidden="true" style="margin: 0px 8px 0px 5px;color: ${color};" title="${title}"></i>` + `<span style="${styleTitle}" title="${title}">` + value + '</span>';

                        if (row.StartDate != null && row.StartDate != '0001-01-01T00:00:00') {
                            result = result + '<div class="d-block d-sm-none" style="margin: 3px 20px 0px;">Inicio: ' + moment(row.StartDate).format('DD/MM/YYYY hh:mma');
                            result = result + '</div>';
                        }

                        if (row.FinishDate != null && row.FinishDate != '0001-01-01T00:00:00') {
                            result = result + '<div class="d-block d-sm-none" style="margin: 0 20px;">Completado: ' + moment(row.FinishDate).format('DD/MM/YYYY hh:mma');
                            result = result + '</div>';
                        }


                        if (row.FinishDate != null && row.FinishDate != '0001-01-01T00:00:00') {
                            result = result + '<div class="d-block d-sm-none" style="margin: 0 20px;">Realizado por: ' + row.UserName;
                            result = result + '<small class="text-muted"> ' + moment(row.FinishDate).from() + '</small>';
                            result = result + '</div>';
                        }
                        if (row.Comments != '') {
                            result = result + '<div class="d-block d-sm-none" style="margin: 0 20px;">Comentario:<small class="text-muted" style="font-style: italic;"> ' + row.Comments + '</small></div>';
                            result = result + '<div class="d-none d-sm-block" style="margin: 0 26px;"><small class="text-muted" style="font-style: italic;"> ' + row.Comments + '</small></div>';
                        }
                        result = result + `<div style="margin: 0 26px;"><small class="text-muted" id="compl_${row.StepId}"></small></div>`;
                        return result;

                    }
                }, {
                    field: 'StartDate',
                    title: 'Inicio',
                    class: 'd-none d-sm-table-cell',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateAndTimeFormatter'
                }, {
                    field: 'FinishDate',
                    title: 'Completado',
                    class: 'd-none d-sm-table-cell',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateAndTimeFormatter'
                }, {
                    field: 'FinishDate',
                    title: 'Realizado por',
                    class: 'd-none d-sm-table-cell',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    width: 15,
                    widthUnit: '%',
                    formatter: function (value, row, index, field) {
                        if (value === null || value === '0001-01-01T00:00:00')
                            return '';
                        else
                            return '<span title="' + moment(value).format('DD/MM/YYYY hh:mma') + '">' + row.UserName + ' <small class="text-muted"> ' + moment(value).from() + '</small></span>';
                    }
                }]
            //, {
            //    field: 'Comments',
            //    title: 'Comentario',
            //    sortable: false,
            //    halign: 'center',
            //    align: 'left',
            //}]
        });
    }

    async function RefreshProcess(instanceId) {

        app.core.Get(app.setting.apipath + 'v1/Process/Instance/' + instanceId + '/3')
            .done(function (data, textStatus, jqXHR) {
                _instance = data;
                if (data.Steps) {
                    caseId = data.CaseId;

                    $('#ProcessGridTbl').bootstrapTable('load', data.Steps);
                    $('.tnotify').addClass('d-none');
                    let current = data.Steps.filter(i => i.ActivityId === data.ActivityId);

                    if (current.length > 0) {
                        $('#StepDescription').html(current[0].Name);
                        $('#CurrentStep').html(current[0].Name);

                        EnableReference(current[0].References);
                    }
                    if (data.Tasks.length > 0) {
                        $('#tasks').empty();
                        $('#Annotation').val('');
                        $('#ProcessStepAccept').prop("disabled", true);
                        selectedOptions = $('#tasks');
                        switch (current[0].ProgressMode) {
                            case 1:
                                $('.mode-simple').removeClass('d-none');
                                $.each(data.Tasks, function () {
                                    selectedOptions.append(
                                        '<div class="custom-control custom-radio" title="' + this['Description'] + '">' +
                                        '<input type="radio" class="custom-control-input" id="task_' + this['ActivityId'] + '" name="task" value="' + this['ActivityId'] + '" onchange="app.GeneralCase.Enable();">' +
                                        '<label class="custom-control-label" for="task_' + this['ActivityId'] + '">' + this['Name'] + '</label>' +
                                        '</div>');
                                });
                                break;
                            case 2:
                                $('.mode-simple').addClass('d-none');
                                $.each(data.Tasks, function () {
                                    selectedOptions.append(
                                        '<div class="custom-control custom-checkbox" title="' + this['Description'] + '">' +
                                        '<input type="checkbox" class="custom-control-input" id="task_' + this['ActivityId'] + '" name="task" value="' + this['ActivityId'] + '" ' + (this['FinishDate'] === null ? '' : 'checked') + ' onchange="app.GeneralCase.Checked(' + this['ActivityId'] + ');">' +
                                        '<label class="custom-control-label" for="task_' + this['ActivityId'] + '">' + this['Name'] + '</label>' +
                                        '</div>');
                                });
                                break;
                        }

                        $('#ChangeStage').removeClass('d-none');
                        //$('#entry').removeClass('d-none');
                        $('fieldset').prop("disabled", false);
                        tasks = data.Tasks;
                    }
                    else {
                        $('#ChangeStage').addClass('d-none');
                        $('#tabs li:nth-child(2) a').tab('show');
                        $('#tabs li:nth-child(1) a').addClass('d-none');
                        if (current.length == 0) {
                            $('#CurrentStep').html(data.Steps[data.Steps.length - 1].Name);
                        }
                    }

                    $(".progress-bar").width(data.Progress + '%');
                    $(".progress-bar").prop('title', data.Progress + '%');
                    $(".progress-bar").html(data.Progress + '%');
                } else {
                    $('#ProcessGridTbl').bootstrapTable('load', []);
                }
            }).always(function () {
                $('#ProcessGridTbl').bootstrapTable('hideLoading');
            });
    }

    function OptionSelected() {
        $('#ProcessStepAccept').prop("disabled", false);
    }

    function TaskChecked(instanceId, activityId, comment, notify) {
        app.core.Put(app.setting.apipath + `v1/Process/Task/Checked/${instanceId}`,
            JSON.stringify({
                ActivityId: activityId,
                Comment: comment,
                Notify: notify
            }))
            .done(function (data, textStatus, jqXHR) {
                EditMode({ Id: _data.Id });
            }).always(function () {
                app.ui.ButtonDone('#ProcessStepAccept', false);
            });
    }

    function Attachment_List_Setup() {

        $('#AttachmentGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index clearTable',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'DocumentTypeDesc',
                    title: 'Tipo',
                    titleTooltip: 'Tipo de documento',
                    halign: 'left'
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    halign: 'left'
                }, {
                    field: 'FileName',
                    title: 'Archivo',
                    halign: 'left',
                    formatter: function (value, row, index, field) {
                        return `<a href=# onclick="app.ui.Download('${row.FileName}', ${row.Id}); return false;" title="Descargar adjunto"><i class="fa fa-paperclip"></i> ${value}</a>`;
                    }
                }, {
                    field: 'FileSize',
                    title: 'Tamaño',
                    titleTooltip: 'Tamaño del archivo',
                    halign: 'left',
                    align: 'left',
                    formatter: function (value, row, index, field) {
                        if (value === null || value === 0)
                            return '';
                        else
                            return parseInt(value / 1024) + 'kb';
                    }
                }, {
                    field: 'UpdateDate',
                    title: 'Realizado por',
                    class: 'd-none d-sm-table-cell',
                    halign: 'center',
                    width: 15,
                    widthUnit: '%',
                    formatter: 'app.ui.UpdateDateAndUserFormatter'
                }, {
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un attachments',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'GeneralCase_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" name="edit" class="btn btn-sm btn-white event" title="Al hacer click permite la edición de los datos del attachments de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" name="delete" class="btn btn-sm btn-white event" title="Al hacer click permite eliminar los datos del attachments de la fila"> <i class="fa fa-close"></i> </button>';
                    },
                    cellStyle: function (value, row, index) {
                        return {
                            css: {
                                'white-space': 'nowrap',
                                'vertical-align': 'top'
                            }
                        }
                    }
                }]
        });

        $('#AttachmentNew').click(function () {
            Attachment_table_row_edit(null);
        });

        $('#AttachmentEdtFormSave').click(function () {
            if (app.ui.IsValid('#AttachmentEdtForm', false)) {
                app.ui.ButtonDoing('#AttachmentEdtFormSave');

                var row = Attachment_table_row('values');

                app.core.Post(app.setting.apipath + 'v1/Common/Attachments',
                    JSON.stringify({
                        Id: row.Id,
                        EntityType: 1304,
                        EntityId: _data.Id,
                        DocumentType: row.DocumentType,
                        Description: row.Description,
                        FileName: row.FileName,
                        FileSize: row.FileSize,
                        FileContent: row.Stored
                    }))
                    .done(function (data) {
                        AttachmentDraw(_data.Id);
                    }).always(function () {
                        app.ui.ButtonDone('#AttachmentEdtFormSave')
                        $('#AttachmentModal').modal('hide');
                    });
            }
        });

        $('#fileUploadModal').on('change', function () {
            app.core.UpLoadFile('#AttachmentEdtForm', '#fileUploadModal',
                function (fileList) {
                    $('#AttachmentFileName').val(fileList[0].FileName);
                    $('#AttachmentStored').val(fileList[0].StoredFileName);
                    $('#AttachmentFileSize').val(fileList[0].Size);
                    $('#AttachmentDescription').val(app.ui.StringCapitalizeFormatter(fileList[0].FileName.substring(0, fileList[0].FileName.indexOf('.'))));
                    $('#AttachmentDescription').select().focus()
                });
        });

    }

    function Setup_Attachment_Validations() {
        $("#AttachmentEdtForm").validate({
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
                AttachmentDescription: {
                    required: true
                },
                AttachmentDocumentType: {
                    required: true
                },
                AttachmentFileName: {
                    required: true
                }
            },
            messages: {
                AttachmentDescription: {
                    required: 'Debe indicar una descripción del archivo'
                },
                AttachmentDocumentType: {
                    required: 'Debe indicar el tipo de documento'
                },
                AttachmentFileName: {
                    required: 'Debe indicar un archivo'
                }
            }
        });
    };

    function AttachmentDraw(entityId) {
        $('#AttachmentGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + `v1/Common/Attachments?entityType=1304&entityId=${entityId}`)
            .done(function (data) {
                $('#AttachmentGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#AttachmentGridTbl').bootstrapTable('hideLoading');
            });
    }

    function Attachment_table_row(mode) {
        if (mode == null) {
            return {
                Id: null,
                DocumentType: 1,
                DocumentTypeDesc: 'General',
                FileName: null,
                Stored: null,
                FileSize: null,
                Description: null
            };
        }
        else {
            return {
                Id: $('#AttachmentModal').data('id'),
                DocumentType: $('#AttachmentDocumentType').val(),
                DocumentTypeDesc: $('#AttachmentDocumentType option:selected').text(),
                FileName: $('#AttachmentFileName').val(),
                Stored: $('#AttachmentStored').val(),
                FileSize: $('#AttachmentFileSize').val(),
                Description: $('#AttachmentDescription').val()
            };
        }
    }

    function Attachment_table_row_edit(row) {
        var md = $('#AttachmentModal').modal({ show: false });
        var formInstance = $("#AttachmentEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || Attachment_table_row();
        md.data('id', row.Id);

        $('#AttachmentDocumentType').val(row.DocumentType);
        $('#AttachmentFileName').val(row.FileName);
        $('#AttachmentStored').val(row.Stored);
        $('#AttachmentFileSize').val(row.FileSize);
        $('#AttachmentDescription').val(row.Description);

        md.modal('show');
    }

    return {
        Init: function () {
            Init_List_Process();

            Event_Controls();
            Setup_Validations();
            Init_Lookups();
            Attachment_List_Setup();
            Setup_Attachment_Validations();
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
        },
        ButtonClick: function (tbl, e, name, row, index) {
            switch (name) {
                case 'edit':
                    Attachment_table_row_edit(row);
                    break;

                case 'delete':
                    toastr.warning("Si está seguro de querer eliminar el adjunto '" + row.FileName + "' haga clic aquí", null,
                        {
                            timeOut: 5000, closeButton: true, progressBar: true,
                            onclick: function () {
                                app.core.Delete(app.setting.apipath + `v1/Common/Attachments/${row.Id}`)
                                    .done(function (data, textStatus, jqXHR) {
                                        toastr.success("El adjunto '" + row.FileName + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                                        AttachmentDraw(_data.Id);
                                    });
                            }
                        });
                    break;
            }
        }
    };
})();
window.GeneralCase_Events = {
    'click .event': function (e, value, row, index) {
        e.stopPropagation();
        app.GeneralCase.ButtonClick(this, e, e.currentTarget.name, row, index)
    }
};