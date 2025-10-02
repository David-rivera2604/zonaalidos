var app = app || {};

app.GeneralProcessSpecStep = (function () {

    function Refresh() {
        let filter = '';
        let flowIdFltVal = $('#FlowIdFlt').val();
        if (flowIdFltVal != null && flowIdFltVal != '' && flowIdFltVal != '0') {
            filter = filter + ':flowId=' + flowIdFltVal;
        }
        if (flowIdFltVal.length > 0) {
            $('#ProcessSpecStepGridTbl').bootstrapTable('showLoading');
            app.core.Get(app.setting.apipath + 'v1/ProcessSpecStep?filter=' + filter)
                .done(function (data, textStatus, jqXHR) {
                    $('#ProcessSpecStepGridTbl').bootstrapTable('load', data !== null ? data : []);
                }).always(function () {
                    $('#ProcessSpecStepGridTbl').bootstrapTable('hideLoading');
                });
        } else {
            $('#ProcessSpecStepGridTbl').bootstrapTable('load', []);
        }
    }

    function Init_Controls() {
        app.ui.NewNumericWidget('#StepOrder', '', '0', '99999', '0');
        app.ui.NewSelectWidget('#FlowIdFlt');
        app.ui.NewSelectWidget('#Roles');
        app.ui.NewSelectWidget('#References');

        $('.formbtn').appendTo("#GenericToolBar");
    }

    function Init_List() {

        app.ui.TableWidget('#ProcessSpecStepGridTbl',
            {
                detailView: true,
                onExpandRow: function (index, row, $detail) {
                    $detail.append('<span class="detail-title">Tareas</span>');
                    $detail.append('<div class="table-responsive" style="background-color: white; margin: 0px 0px 0px 10px; width: 99%!important;"><table style="font-size: 11px"></table></div>');

                    Task_Init_List($detail.find('span'), $detail.find('table'), row);
                },
                columns: [
                    app.ui.StringColumnWidget('FlowIdDesc', 'Proceso'),
                    app.ui.StringColumnWidget('Name', 'Nombre', '',
                        {
                            events: 'ProcessSpecStepGridTbl_Events',
                            formatter: function (value, row, index, field) {
                                return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos de la etapa">' + value + '</a>';
                            }
                        }),
                    app.ui.StringColumnWidget('Description', 'Descripción'),
                    app.ui.IntegerColumnWidget('StepOrder', 'Orden', 'Orden en que se procesan los pasos para un proceso.'),
                    app.ui.StringColumnWidget('ProcessStatusDesc', 'Estado'),
                    app.ui.StringColumnWidget('ProgressModeDesc', 'Tipo'),
                    app.ui.StringColumnWidget('RoleNames', 'Roles'),
                    app.ui.UpdateDateAndUserColumnWidget('UpdateDate'),
                    app.ui.ActionsColumnWidget('Acciones disponibles para una etapa', 'ProcessSpecStepGridTbl_Events')]
            });

    }

    function Event_Controls() {

        $('.tool-audit').on('click', function (e) {
            app.ui.components.ShowModalChangeSet(1301);
        });

        $('.tool-new').on('click', function (e) {
            app.GeneralProcessSpecStep.New();
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#ProcessSpecStepSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#ProcessSpecStepEdtFormSave').click(function (event) {
            if (app.ui.IsValid('#ProcessSpecStepEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecStepEdtFormSave');
                let data = MapInputToObject();
                if (data.Id === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecStepEdtFormSaveContinue').click(function (event) {
            if (app.ui.IsValid('#ProcessSpecStepEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecStepEdtFormSaveContinue');
                let data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#ProcessSpecStepEdtFormSaveCopy').click(function (event) {
            if (app.ui.IsValid('#ProcessSpecStepEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecStepEdtFormSaveCopy');
                let data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#ProcessSpecStepEdtFormDuplicate').click(function (event) {
            if (app.ui.IsValid('#ProcessSpecStepEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecStepEdtFormDuplicate');
                let data = MapInputToObject();
                data.Id = 0;
                data.Name += ' duplicado';
                app.ui.ButtonDone('#ProcessSpecStepEdtFormDuplicate');
                app.GeneralProcessSpecStep.EditRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecStepEdtFormDelete').click(function (event) {
            if (app.ui.IsValid('#ProcessSpecStepEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecStepEdtFormDelete');
                let data = MapInputToObject();
                app.ui.ButtonDone('#ProcessSpecStepEdtFormDelete');
                app.GeneralProcessSpecStep.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecStepEdtFormCancel').click(function (event) {
            ViewMode();
            event.preventDefault();
        });


        $('#MailToContact').change(function () {
            switch (app.ui.GetDropDownNumericValue('#MailToContact')) {
                case 1:
                    $('#MailToContactCustom').val('');
                    $("#MailToContactCustom").prop("disabled", true);
                    $("#MailToContactTmpl").prop("disabled", false);
                    break;
                case 2:
                    $('#MailToContactCustom').val('');
                    $("#MailToContactCustom").prop("disabled", true);
                    $('#MailToContactTmpl').val('1');
                    $("#MailToContactTmpl").prop("disabled", true);
                    break;
                case 3:
                    $("#MailToContactCustom").prop("disabled", false);
                    $("#MailToContactTmpl").prop("disabled", false);
                    break;
            }
        });

        $('#MailToStepResponsible').change(function () {
            switch (app.ui.GetDropDownNumericValue('#MailToStepResponsible')) {
                case 1:
                    $('#MailToStepResponsibleCustom').val('');
                    $("#MailToStepResponsibleCustom").prop("disabled", true);
                    $("#MailToStepResponsibleTmpl").prop("disabled", false);
                    break;
                case 2:
                    $('#MailToStepResponsibleCustom').val('');
                    $("#MailToStepResponsibleCustom").prop("disabled", true);
                    $('#MailToStepResponsibleTmpl').val('1');
                    $("#MailToStepResponsibleTmpl").prop("disabled", true);
                    break;
                case 3:
                    $("#MailToStepResponsibleCustom").prop("disabled", false);
                    $('#MailToStepResponsibleTmpl').val('1');
                    $("#MailToStepResponsibleTmpl").prop("disabled", false);
                    break;
            }
        });

        $('#FlowIdFlt').on('select2:select', function (e) {
            Refresh();
        });
        $('#Roles').change(function () {
            if (app.ui.GetDropDownMultiValues('Roles').length > 0)
                $('.role-notify-visible').removeClass('d-none');
            else {
                $('.role-notify-visible').addClass('d-none');
            }
        });
        $("#ProcessSpecStepEdtForm :input").change(function () {
            EdtForm_Change();
        });
    };

    function EdtForm_Change() {
        if ($('#ProgressMode').val() == '1') {
            $('.progressmode-visible').removeClass('d-none');
        }
        else {
            $('.progressmode-visible').addClass('d-none');
        }
    };

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/ProcessSpecStep', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("La etapa '" + uidata.Name + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralProcessSpecStep.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralProcessSpecStep.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#ProcessSpecStepEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#ProcessSpecStepEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#ProcessSpecStepEdtFormSaveCopy');
                        break;
                }
            });
    };

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/ProcessSpecStep/' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("La etapa '" + uidata.Name + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#ProcessSpecStepEdtFormSave');
            });
    };

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar la etapa '" + uidata.Name + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/ProcessSpecStep/' + uidata.Id)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("La etapa '" + uidata.Name + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    };

    function Init_Lookups() {
        app.core.Lookups(['Process.FlowId', 'Process.FlowIdFlt', 'ProcessStatus.ProcessStatus', 'ProgressMode.ProgressMode', 'MailServer.MailServer', 'MailSendOptions.MailToContact', 'MailTemplate.MailToContactTmpl', 'MailSendOptions.MailToStepResponsible', 'MailTemplate.MailToStepResponsibleTmpl', 'SLA.SLA.'], Dynamic_Event_Controls);
        // Dependencies
    };

    function Dynamic_Event_Controls() {
        app.ui.NewSelectWidget('#FlowIdFlt');
        app.core.LoadLookup(app.setting.apipath + 'v1/RoleMember/Lookup', 'Roles');
    };

    function MapInputToObject() {
        let data = {
            Id: parseInt(0 + $('#Id').val(), 10),
            FlowId: app.ui.GetDropDownNumericValue('#FlowId'),
            Name: $('#Name').val(),
            Description: $('#Description').val(),
            Roles: app.ui.GetDropDownMultiValues('Roles'),
            StepOrder: app.ui.GetNumericValue('#StepOrder'),
            ProcessStatus: $('#ProcessStatus').val(),
            ProcessLabel: $('#ProcessLabel').val(),
            EnableComment: app.ui.GetRadioNumericValue('EnableComment'),
            ProgressMode: $('#ProgressMode').val(),
            SLA: app.ui.GetDropDownNumericValue('#SLA'),
            MailServer: $('#MailServer').val(),
            MailToContact: $('#MailToContact').val(),
            MailToContactCustom: $('#MailToContactCustom').val(),
            MailToContactTmpl: $('#MailToContactTmpl').val(),
            MailToStepResponsible: $('#MailToStepResponsible').val(),
            MailToStepResponsibleCustom: $('#MailToStepResponsibleCustom').val(),
            MailToStepResponsibleTmpl: $('#MailToStepResponsibleTmpl').val(),
            PreScript: $('#PreScript').val(),
            PostScript: $('#PostScript').val(),
            References: JSON.stringify(app.ui.GetDropDownMultiValues('References'))
        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        $('#FlowId').val(data.FlowId);
        $('#Name').val(data.Name);
        $('#Description').val(data.Description);
        app.ui.SetDropDownMultiValues('Roles', data.Roles);
        $('#Roles').change();
        app.ui.SetNumericValue('#StepOrder', data.StepOrder);
        $('#ProcessStatus').val(data.ProcessStatus);
        $('#ProcessLabel').val(data.ProcessLabel);
        $('#EnableComment').prop('checked', data.EnableComment);
        app.ui.SetRadioNumericValue('EnableComment', data.EnableComment);
        $('#ProgressMode').val(data.ProgressMode);
        $('#SLA').val(data.SLA);
        $('#MailServer').val(data.MailServer);

        $('#MailToContactCustom').val(data.MailToContactCustom);
        $('#MailToContactTmpl').val(data.MailToContactTmpl);
        $('#MailToContact').val(data.MailToContact).change();

        $('#MailToStepResponsibleCustom').val(data.MailToStepResponsibleCustom);
        $('#MailToStepResponsibleTmpl').val(data.MailToStepResponsibleTmpl);
        $('#MailToStepResponsible').val(data.MailToStepResponsible).change();

        $('#PreScript').val(data.PreScript);
        $('#PostScript').val(data.PostScript);
    };

    function Setup_Validations() {
        app.ui.ValidateWidget('#ProcessSpecStepEdtForm', {
            DateValidators: false,
            rules: [
                { field: 'FlowId', type: 'required', message: 'Debe indicar el proceso' },
                { field: 'Name', type: 'required', message: 'Debe indicar el nombre' },
                { field: 'StepOrder', type: 'required', message: 'Debe indicar el orden' },
                { field: 'ProgressMode', type: 'required', message: 'Debe indicar el tipo' },
                { field: 'MailServer', type: 'required', message: 'Debe indicar el servidor de correo' },
                { field: 'ProcessStatus', type: 'required', message: 'Debe indicar el estado' }
            ]
        });
    };

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#ProcessSpecStepGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#ProcessSpecStepEdt').removeClass('d-none');

        if (row.Id === 0) {
            MapObjectToInput(row);
            $('#Name').focus();
            $('#ProcessSpecStepEdtFormSaveContinue').removeClass('d-none');
            $('#ProcessSpecStepEdtFormSaveCopy').removeClass('d-none');
            $('#ProcessSpecStepEdtFormDuplicate').addClass('d-none');
            $('#ProcessSpecStepEdtFormDelete').addClass('d-none');
            $('#ProcessSpecStepEdtFormSave').removeClass('d-none');
            $('#ProcessSpecStepEdtFormCancel').removeClass('d-none');
            EdtForm_Change();
        } else {
            $('.ibox-content').toggleClass('sk-loading');

            app.core.Get(app.setting.apipath + 'v1/ProcessSpecStep/' + row.Id)
                .done(function (data, textStatus, jqXHR) {
                    MapObjectToInput(data);

                    app.core.Get(app.setting.apipath + 'v1/ProcessSpecFlow/' + data.FlowId + '/References')
                        .done(function (dataRef, textStatus, jqXHR) {
                            let ctrol = $('select#References');
                            ctrol.children().remove();
                            $.each(dataRef, function () {
                                ctrol.append($('<option />').val(this['Code']).text(this['Description']));
                            });
                            app.ui.NewSelectWidget('select#References');
                            if (data.References == '') {
                                data.References = '[]';
                            }
                            app.ui.SetDropDownMultiValues('References', JSON.parse(data.References));
                        });

                    $('#Name').focus();
                    $('#ProcessSpecStepEdtFormSaveContinue').addClass('d-none');
                    $('#ProcessSpecStepEdtFormSaveCopy').addClass('d-none');
                    $('#ProcessSpecStepEdtFormDuplicate').removeClass('d-none');
                    $('#ProcessSpecStepEdtFormDelete').removeClass('d-none');
                    $('#ProcessSpecStepEdtFormSave').removeClass('d-none');
                    $('#ProcessSpecStepEdtFormCancel').removeClass('d-none');
                    EdtForm_Change();

                }).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });

        }
    };

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').removeClass('d-none');
        $('#ProcessSpecStepGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#ProcessSpecStepEdt').addClass('d-none');
        $('.formbtn').addClass('d-none');
    };

    function Task_Init_List(title, gridTbl, parentRow) {
        app.ui.TableWidget(gridTbl,
            {
                detailFormatter: 'app.ui.GenericDetailFormatter',
                columns: [
                    app.ui.IntegerColumnWidget('TaskOrder', 'Orden', 'Orden en que se procesan la tarea.'),
                    app.ui.StringColumnWidget('Name', 'Nombre', '',
                        {
                            formatter: function (value, row, index, field) {
                                return `<a class="edit" href="ProcessSpecTask?id=${row.Id}" title="Al hacer click permite editar la tarea">${value}</a>`;
                            }
                        }),
                    app.ui.StringColumnWidget('Description', 'Descripción'),
                    app.ui.StringColumnWidget('TypeDesc', 'Tipo'),
                    app.ui.StringColumnWidget('ActionDesc', 'Acción'),
                    app.ui.UpdateDateAndUserColumnWidget('UpdateDate')]
            });

        gridTbl.bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/ProcessSpecTask?filter=:flowId=' + parentRow.FlowId + ':stepId=' + parentRow.Id)
            .done(function (data, textStatus, jqXHR) {
                gridTbl.bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                gridTbl.bootstrapTable('hideLoading');
            });
    }

    return {
        Init: function () {
            Init_List();
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Setup_Validations();
            let _id = app.core.URLNumericValue('id');
            if (_id !== 0) {
                $("body").toggleClass("mini-navbar");
                EditMode({ Id: _id });
            }
            else {
                Refresh();
            }
        },
        New: function (row) {
            let newRow = { Id: 0, FlowId: 0, Name: null, Description: null, StepOrder: 0, ProcessStatus: 0, ProcessLabel: null, EnableComment: false, ProgressMode: 1, SLA: 0, MailServer: 1, MailToContact: 1, MailToContactCustom: null, MailToContactTmpl: 1, MailToStepResponsible: 1, MailToStepResponsibleCustom: null, MailToStepResponsibleTmpl: 1, PreScript: null, PostScript: null, References: null }
            if (row !== undefined) {
                row.Id = 0;
                newRow = row;
            }
            if (newRow.FlowId === 0 && $('#FlowIdFlt').val().length > 0) {
                newRow.FlowId = $('#FlowIdFlt').val()[0];
            }
            EditMode(newRow);
        },
        EditRow: function (row) {
            EditMode(row);
        },
        DeleteRow: function (row) {
            Delete(row);
        }
    };
})();

window.ProcessSpecStepGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralProcessSpecStep.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralProcessSpecStep.EditRow(row);
        e.stopPropagation();
    }
};
