var app = app || {};

app.GeneralProcessSpecFlow = (function () {

    function Refresh() {
        var filter = $('#ProcessSpecFlowSearch').val();
        var statusFltVal = $('#StatusFlt').select2('data').map(function (item) { return item['id']; }).toString();
        if (statusFltVal != '') {
            filter = filter + ':status=' + statusFltVal;
        }

        $('#ProcessSpecFlowGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/ProcessSpecFlow?filter=' + filter)
            .done(function (data, textStatus, jqXHR) {
                $('#ProcessSpecFlowGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#ProcessSpecFlowGridTbl').bootstrapTable('hideLoading');
            });
    }

    function Init_Controls() {

        $('#StatusFlt').select2({ width: '100%', theme: 'bootstrap4' });
        $('#Roles').select2({ width: '100%', theme: 'bootstrap4' });
        $(".formbtn").appendTo("#GenericToolBar");
    }

    function Init_List() {
        $('#ProcessSpecFlowGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            showColumns: true,
            detailView: true,
            onExpandRow: function (index, row, $detail) {
                $detail.append('<span class="detail-title">Etapas</span>');
                $detail.append('<div class="table-responsive" style="background-color: white; margin: 0px 0px 0px 10px; width: 99%!important;"><table style="font-size: 11px"></table></div>');

                Step_Init_List($detail.find('span'), $detail.find('table'), row);
            },
            columns: [
                {
                    field: 'Name',
                    title: 'Nombre',
                    sortable: true,
                    halign: 'center',
                    events: 'ProcessSpecFlowGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos del process spec flow">' + value + '</a>';
                    }
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Alias',
                    title: 'Alias',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailServerDesc',
                    title: 'Servidor de correo',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'StatusDesc',
                    title: 'Estado',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'UpdateDate',
                    title: 'Realizado por',
                    class: 'd-none d-sm-table-cell',
                    sortable: true,
                    halign: 'center',
                    width: 15,
                    widthUnit: '%',
                    formatter: 'app.ui.UpdateDateAndUserFormatter'
                }, {
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un process spec flow',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'ProcessSpecFlowGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del process spec flow de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del process spec flow de la fila"> <i class="fa fa-close"></i> </button>';
                    },
                    cellStyle: function (value, row, index) {
                        return {
                            css: {
                                'white-space': 'nowrap',
                                'vertical-align': 'top'
                            }
                        }
                    }
                }],
            icons: {
                paginationSwitchDown: 'fa-caret-square-o-down',
                paginationSwitchUp: 'fa-caret-square-o-up',
                refresh: 'fa-refresh',
                toggleOff: 'fa-toggle-off',
                toggleOn: 'fa-toggle-on',
                columns: 'fa-th-list',
                fullscreen: 'fa-arrows-alt',
                detailOpen: 'fa-angle-double-right',
                detailClose: 'fa-angle-double-down',
                export: 'fa-download'
            }
        });
    }

    function Event_Controls() {

        $('.tool-audit').on('click', function (e) {
            app.ui.components.ShowModalChangeSet(1300);
        });

        $('.tool-new').on('click', function (e) {
            app.GeneralProcessSpecFlow.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#ProcessSpecFlowSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#ProcessSpecFlowEdtFormSave').click(function () {
            if (app.ui.IsValid('#ProcessSpecFlowEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecFlowEdtFormSave');
                var data = MapInputToObject();
                if (data.Id === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecFlowEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#ProcessSpecFlowEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecFlowEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#ProcessSpecFlowEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#ProcessSpecFlowEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecFlowEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#ProcessSpecFlowEdtFormDuplicate').click(function () {
            app.ui.ButtonDoing('#ProcessSpecFlowEdtFormDuplicate');
            let uidata = MapInputToObject();

            app.core.Post(app.setting.apipath + `v1/ProcessSpecFlow/${uidata.Id}/Duplicate`)
                .done(function (data, textStatus, jqXHR) {
                    ViewMode();
                    Refresh();
                }).always(function () {
                    app.ui.ButtonDone('#ProcessSpecFlowEdtFormDuplicate');
                });
            event.preventDefault();
        });

        $('#ProcessSpecFlowEdtFormDelete').click(function () {
            if (app.ui.IsValid('#ProcessSpecFlowEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecFlowEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#ProcessSpecFlowEdtFormDelete');
                app.GeneralProcessSpecFlow.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecFlowEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

        $('#ReferenceCaption1,#ReferenceCaption2,#ReferenceCaption3,#ReferenceCaption4,#ReferenceCaption5').change(function () {

            CustomFields();

        });

    }

    function CustomFields() {
        if ($('#ReferenceCaption1').val() == '')
            $('#ReferenceLookupList1').addClass('d-none');
        else
            $('#ReferenceLookupList1').removeClass('d-none');
        if ($('#ReferenceCaption2').val() == '')
            $('#ReferenceLookupList2').addClass('d-none');
        else
            $('#ReferenceLookupList2').removeClass('d-none');
        if ($('#ReferenceCaption3').val() == '')
            $('#ReferenceLookupList3').addClass('d-none');
        else
            $('#ReferenceLookupList3').removeClass('d-none');
        if ($('#ReferenceCaption4').val() == '')
            $('#ReferenceLookupList4').addClass('d-none');
        else
            $('#ReferenceLookupList4').removeClass('d-none');
        if ($('#ReferenceCaption5').val() == '')
            $('#ReferenceLookupList5').addClass('d-none');
        else
            $('#ReferenceLookupList5').removeClass('d-none');
    }

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/ProcessSpecFlow', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El process spec flow '" + uidata.Name + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralProcessSpecFlow.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralProcessSpecFlow.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#ProcessSpecFlowEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#ProcessSpecFlowEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#ProcessSpecFlowEdtFormSaveCopy');
                        break;
                }
            });
    }

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/ProcessSpecFlow/' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El process spec flow '" + uidata.Name + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#ProcessSpecFlowEdtFormSave');
            });
    }

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el process spec flow '" + uidata.Name + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/ProcessSpecFlow/' + uidata.Id)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El process spec flow '" + uidata.Name + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    }

    function Init_Lookups() {
        app.core.Lookups(['MailServer.MailServer', 'EstadoRegistro.Status', 'EstadoRegistro.StatusFlt', 'SLA.SLA.'], Dynamic_Event_Controls);
        // Dependencies
    }

    function Dynamic_Event_Controls() {
        $('#StatusFlt').select2({ width: '100%', theme: 'bootstrap4' });
        app.core.LoadLookup(app.setting.apipath + 'v1/RoleMember/Lookup', 'Roles');

    }

    function MapInputToObject() {
        return {
            Id: parseInt(0 + $('#Id').val(), 10),
            Name: $('#Name').val(),
            Description: $('#Description').val(),
            Alias: $('#Alias').val(),
            MailServer: $('#MailServer').val(),
            ReferenceCaption1: $('#ReferenceCaption1').val(),
            ReferenceLookupList1: $('#ReferenceLookupList1').val(),
            ReferenceCaption2: $('#ReferenceCaption2').val(),
            ReferenceLookupList2: $('#ReferenceLookupList2').val(),
            ReferenceCaption3: $('#ReferenceCaption3').val(),
            ReferenceLookupList3: $('#ReferenceLookupList3').val(),
            ReferenceCaption4: $('#ReferenceCaption4').val(),
            ReferenceLookupList4: $('#ReferenceLookupList4').val(),
            ReferenceCaption5: $('#ReferenceCaption5').val(),
            ReferenceLookupList5: $('#ReferenceLookupList5').val(),
            Status: $('#Status').val(),
            Roles: app.ui.GetDropDownMultiValues('Roles'),
            SLA: app.ui.GetDropDownNumericValue('#SLA')
        };
    }

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        $('#Name').val(data.Name);
        $('#Description').val(data.Description);
        $('#Alias').val(data.Alias);
        $('#MailServer').val(data.MailServer);
        $('#ReferenceCaption1').val(data.ReferenceCaption1);
        $('#ReferenceLookupList1').val(data.ReferenceLookupList1);
        $('#ReferenceCaption2').val(data.ReferenceCaption2);
        $('#ReferenceLookupList2').val(data.ReferenceLookupList2);
        $('#ReferenceCaption3').val(data.ReferenceCaption3);
        $('#ReferenceLookupList3').val(data.ReferenceLookupList3);
        $('#ReferenceCaption4').val(data.ReferenceCaption4);
        $('#ReferenceLookupList4').val(data.ReferenceLookupList4);
        $('#ReferenceCaption5').val(data.ReferenceCaption5);
        $('#ReferenceLookupList5').val(data.ReferenceLookupList5);
        $('#Status').val(data.Status);
        app.ui.SetDropDownMultiValues('Roles', data.Roles);
        $('#SLA').val(data.SLA);
    }

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#ProcessSpecFlowEdtForm").validate({
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
                Name: {
                    required: true
                },
                MailServer: {
                    required: true
                },
                Status: {
                    required: true
                }
            },
            messages: {
                Name: {
                    required: 'Debe indicar el nombre'
                },
                MailServer: {
                    required: 'Debe indicar el servidor de correo'
                },
                Status: {
                    required: 'Debe indicar el estado'
                }
            }

        });
    }

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#ProcessSpecFlowGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#ProcessSpecFlowEdt').removeClass('d-none');

        if (row.Id === 0) {
            MapObjectToInput(row);
            CustomFields();
            $('#Name').focus();
            $('#ProcessSpecFlowEdtFormSaveContinue').removeClass('d-none');
            $('#ProcessSpecFlowEdtFormSaveCopy').removeClass('d-none');
            $('#ProcessSpecFlowEdtFormDuplicate').addClass('d-none');
            $('#ProcessSpecFlowEdtFormDelete').addClass('d-none');
            $('#ProcessSpecFlowEdtFormSave').removeClass('d-none');
            $('#ProcessSpecFlowEdtFormCancel').removeClass('d-none');
        } else {
            $('.ibox-content').toggleClass('sk-loading');

            app.core.Get(app.setting.apipath + 'v1/ProcessSpecFlow/' + row.Id)
                .done(function (data, textStatus, jqXHR) {
                    MapObjectToInput(data);
                    CustomFields();
                    $('#Name').focus();
                    $('#ProcessSpecFlowEdtFormSaveContinue').addClass('d-none');
                    $('#ProcessSpecFlowEdtFormSaveCopy').addClass('d-none');
                    $('#ProcessSpecFlowEdtFormDuplicate').removeClass('d-none');
                    $('#ProcessSpecFlowEdtFormDelete').removeClass('d-none');
                    $('#ProcessSpecFlowEdtFormSave').removeClass('d-none');
                    $('#ProcessSpecFlowEdtFormCancel').removeClass('d-none');
                }).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });
        }
    }

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#ProcessSpecFlowGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#ProcessSpecFlowEdt').addClass('d-none');
        $('.formbtn').addClass('d-none');
    }

    function Step_Init_List(title, gridTbl, parentRow) {
        gridTbl.bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            showColumns: false,
            detailView: true,
            onExpandRow: function (index, row, $detail) {
                $detail.append('<span class="detail-title">Tareas</span>');
                $detail.append('<div class="table-responsive" style="background-color: white; margin: 0px 0px 0px 10px; width: 99%!important;"><table style="font-size: 11px"></table></div>');

                Task_Init_List($detail.find('span'), $detail.find('table'), row);
            },
            columns: [
                {
                    field: 'StepOrder',
                    title: 'Orden',
                    titleTooltip: 'Orden en que se procesan los pasos para un proceso.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'Name',
                    title: 'Nombre',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'ProcessStatusDesc',
                    title: 'Estado',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'ProcessLabel',
                    title: 'Etiqueta',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'EnableComment',
                    title: 'Enable Comment',
                    titleTooltip: '.',
                    sortable: true,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.BooleanFormatter',
                    visible: false
                }, {
                    field: 'ProgressModeDesc',
                    title: 'Tipo',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'SLA',
                    title: 'SLA',
                    titleTooltip: '.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                }, {
                    field: 'MailServerDesc',
                    title: 'Servidor de correo',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailToContactDesc',
                    title: 'Contacto',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailToContactCustom',
                    title: 'Contacto',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailToContactTmplDesc',
                    title: 'Mai Tmpll to Contact',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailToStepResponsibleDesc',
                    title: 'Responsables',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailToStepResponsibleCustom',
                    title: 'Responsables',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailToStepResponsibleTmplDesc',
                    title: 'Mail to Step Responsible Tmpl',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'PreScript',
                    title: 'Pre Script',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'PostScript',
                    title: 'Post Script',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'UpdateDate',
                    title: 'Realizado por',
                    class: 'd-none d-sm-table-cell',
                    sortable: true,
                    halign: 'center',
                    width: 15,
                    widthUnit: '%',
                    formatter: 'app.ui.UpdateDateAndUserFormatter'
                }],
            icons: {
                paginationSwitchDown: 'fa-caret-square-o-down',
                paginationSwitchUp: 'fa-caret-square-o-up',
                refresh: 'fa-refresh',
                toggleOff: 'fa-toggle-off',
                toggleOn: 'fa-toggle-on',
                columns: 'fa-th-list',
                fullscreen: 'fa-arrows-alt',
                detailOpen: 'fa-angle-double-right',
                detailClose: 'fa-angle-double-down',
                export: 'fa-download'
            }
        });
        gridTbl.bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/ProcessSpecStep?filter=:flowId=' + parentRow.Id)
            .done(function (data, textStatus, jqXHR) {
                gridTbl.bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                gridTbl.bootstrapTable('hideLoading');
            });

    }

    function Task_Init_List(title, gridTbl, parentRow) {
        gridTbl.bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'TaskOrder',
                    title: 'Orden',
                    titleTooltip: 'Orden en que se procesan la tarea.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'Name',
                    title: 'Name',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'IsRequired',
                    title: 'Is Required',
                    titleTooltip: '.',
                    sortable: true,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.BooleanFormatter',
                    visible: false
                }, {
                    field: 'IsSelected',
                    title: 'Is Selected',
                    titleTooltip: '.',
                    sortable: true,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.BooleanFormatter',
                    visible: false
                }, {
                    field: 'TypeDesc',
                    title: 'Tipo',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'ActionDesc',
                    title: 'Acción',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'SubStatus',
                    title: 'Estado',
                    titleTooltip: '.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                }, {
                    field: 'SubLabel',
                    title: 'Etiqueta',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'PreScript',
                    title: 'Pre Script',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'PostScript',
                    title: 'Post Script',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'UpdateDate',
                    title: 'Realizado por',
                    class: 'd-none d-sm-table-cell',
                    sortable: true,
                    halign: 'center',
                    width: 15,
                    widthUnit: '%',
                    formatter: 'app.ui.UpdateDateAndUserFormatter'
                }]
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
            var _id = app.core.URLNumericValue('id');
            if (_id !== 0) {
                $("body").toggleClass("mini-navbar");
                EditMode({ Id: _id });
            }
            else {
                Refresh();
            }
        },
        New: function (row) {
            let newRow = { Id: 0, Name: null, Description: null, Alias: null, MailServer: 1, Status: 1 }
            if (row !== undefined) {
                row.Id = 0;
                newRow = row;
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

window.ProcessSpecFlowGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralProcessSpecFlow.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralProcessSpecFlow.EditRow(row);
        e.stopPropagation();
    }
};
