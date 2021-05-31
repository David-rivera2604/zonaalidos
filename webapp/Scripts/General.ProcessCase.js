var app = app || {};

app.GeneralProcessCase = (function () {

    function Refresh() {
        var filter = $('#ProcessCaseSearch').val();

        $('#ProcessCaseGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/ProcessCase?filter=' + filter)
            .done(function (data, textStatus, jqXHR) {
                $('#ProcessCaseGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#ProcessCaseGridTbl').bootstrapTable('hideLoading');
            });
    }

    function Init_Controls() {
        new AutoNumeric('#CurrentStepId', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#SubStatus', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });


    };

    function Init_List() {
        $('#ProcessCaseGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: true,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'Title',
                    title: 'Title',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'PriorityDesc',
                    title: 'Prioridad',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Reference1',
                    title: 'Referencia 1',
                    sortable: true,
                    halign: 'center',
                    events: 'ProcessCaseGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos del caso">' + value + '</a>';
                    }
                }, {
                    field: 'Reference2',
                    title: 'Referencia 2',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Reference3',
                    title: 'Referencia 3',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Reference4',
                    title: 'Reference 4',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Reference5',
                    title: 'Referencia 5',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'ContactMainName',
                    title: 'Contact Main Name',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'ContactMainEmail',
                    title: 'Contact Main Email',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'StatusDesc',
                    title: 'Estado',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Label',
                    title: 'Etiqueta',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'SubStatus',
                    title: 'Estado',
                    titleTooltip: '.',					
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false,
                    visible: false
                }, {
                    field: 'SubLabel',
                    title: 'Etiqueta',
                    sortable: true,
                    halign: 'center',
                    visible: false,
                    visible: false
                }, {
                    field: 'FlowIdDesc',
                    title: 'Proceso',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'UserIdDesc',
                    title: 'Usuario',
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
                }, {
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un processcase',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'ProcessCaseGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del processcase de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del processcase de la fila"> <i class="fa fa-close"></i> </button>';
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
    };

    function Event_Controls() {

        $('.tool-audit').on('click', function (e) {
            app.ui.components.ShowModalChangeSet(0000);
        });

        $('.tool-new').on('click', function (e) {
            app.GeneralProcessCase.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#ProcessCaseSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

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

        $('#ProcessCaseEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#ProcessCaseEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessCaseEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#ProcessCaseEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#ProcessCaseEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessCaseEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#ProcessCaseEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#ProcessCaseEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessCaseEdtFormDuplicate');
                var data = MapInputToObject();
                data.Id = 0;
                data.Title += ' duplicado';
                app.ui.ButtonDone('#ProcessCaseEdtFormDuplicate');
                app.GeneralProcessCase.EditRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessCaseEdtFormDelete').click(function () {
            if (app.ui.IsValid('#ProcessCaseEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessCaseEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#ProcessCaseEdtFormDelete');
                app.GeneralProcessCase.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessCaseEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

    };

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/ProcessCase', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El processcase '" + uidata.Title + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralProcessCase.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralProcessCase.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#ProcessCaseEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#ProcessCaseEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#ProcessCaseEdtFormSaveCopy');
                        break;
                }
            });
    };

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/ProcessCase/' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El processcase '" + uidata.Title + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#ProcessCaseEdtFormSave');
            });
    };

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el processcase '" + uidata.Title + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/ProcessCase/' + uidata.Id)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El processcase '" + uidata.Title + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    };

    function Init_Lookups() {
        app.core.Lookups(['CasePriority.Priority', 'ProcessStatus.Status', 'Process.FlowId', 'Users.UserId'], Dynamic_Event_Controls);
        // Dependencies
    };

    function Dynamic_Event_Controls() {

    };

    function MapInputToObject() {
        var data = {
            Id: parseInt(0 + $('#Id').val(), 10),
            Title: $('#Title').val(),
            Description: $('#Description').val(),
            Priority: $('#Priority').val(),
            InstanceId: parseInt(0 + $('#InstanceId').val(), 10),
            CurrentStepId: app.ui.GetNumericValue('#CurrentStepId'),
            Reference1: $('#Reference1').val(),
            Reference2: $('#Reference2').val(),
            Reference3: $('#Reference3').val(),
            Reference4: $('#Reference4').val(),
            Reference5: $('#Reference5').val(),
            ContactMainName: $('#ContactMainName').val(),
            ContactMainEmail: $('#ContactMainEmail').val(),
            Status: $('#Status').val(),
            Label: $('#Label').val(),
            SubStatus: app.ui.GetNumericValue('#SubStatus'),
            SubLabel: $('#SubLabel').val(),
            FlowId: $('#FlowId').val(),
            UserId: $('#UserId').val()

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        $('#Title').val(data.Title);
        $('#Description').val(data.Description);
        $('#Priority').val(data.Priority);
        $('#InstanceId').val(data.InstanceId);
        app.ui.SetNumericValue('#CurrentStepId', data.CurrentStepId);
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

    };

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
    };

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#ProcessCaseGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#ProcessCaseEdt').removeClass('d-none');
        MapObjectToInput(row);
        $('#Title').focus();
        if (row.Id === 0) {
            $('#ProcessCaseEdtFormSaveContinue').removeClass('d-none');
            $('#ProcessCaseEdtFormSaveCopy').removeClass('d-none');
            $('#ProcessCaseEdtFormDuplicate').addClass('d-none');
            $('#ProcessCaseEdtFormDelete').addClass('d-none');
        } else {
            $('#ProcessCaseEdtFormSaveContinue').addClass('d-none');
            $('#ProcessCaseEdtFormSaveCopy').addClass('d-none');
            $('#ProcessCaseEdtFormDuplicate').removeClass('d-none');
            $('#ProcessCaseEdtFormDelete').removeClass('d-none');
        }
    };

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#ProcessCaseGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#ProcessCaseEdt').addClass('d-none');
    };

    return {
        Init: function () {
            Init_List();
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Refresh();
            Setup_Validations();
        },
        New: function (row) {
            let newRow = { Id: 0, Title: null, Description: null, Priority: null, InstanceId: 0, CurrentStepId: 0, Reference1: null, Reference2: null, Reference3: null, Reference4: null, Reference5: null, ContactMainName: null, ContactMainEmail: null, Status: null, Label: null, SubStatus: 0, SubLabel: null, FlowId: null, UserId: null }
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

window.ProcessCaseGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralProcessCase.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralProcessCase.EditRow(row);
        e.stopPropagation();
    }
};
