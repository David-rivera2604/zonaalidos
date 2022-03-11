var app = app || {};

app.GeneralProcessSpecTask = (function () {

    function Refresh() {
        var filter = '';
        var flowIdFltVal = $('#FlowIdFlt').val();
        if (flowIdFltVal != null && flowIdFltVal != '' && flowIdFltVal != '0') {
            filter = filter + ':flowId=' + flowIdFltVal;
        }
        var stepIdFltVal = $('#StepIdFlt').select2('data').map(function (item) { return item['id']; }).toString();
        if (stepIdFltVal != '') {
            filter = filter + ':stepId=' + stepIdFltVal;
        }
        if (stepIdFltVal != null && stepIdFltVal != '' && stepIdFltVal != '0') {
            $('#ProcessSpecTaskGridTbl').bootstrapTable('showLoading');
            app.core.Get(app.setting.apipath + 'v1/ProcessSpecTask?filter=' + filter)
                .done(function (data, textStatus, jqXHR) {
                    $('#ProcessSpecTaskGridTbl').bootstrapTable('load', data !== null ? data : []);
                }).always(function () {
                    $('#ProcessSpecTaskGridTbl').bootstrapTable('hideLoading');
                });
        } else {
            $('#ProcessSpecTaskGridTbl').bootstrapTable('load', []);
        }
    }

    function Init_Controls() {
        new AutoNumeric('#SLATimeOut', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#TaskOrder', {
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

        $('#StepIdFlt').select2({ width: '100%', theme: 'bootstrap4' });
        $(".formbtn").appendTo("#GenericToolBar");
    };

    function Init_List() {
        $('#ProcessSpecTaskGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'FlowIdDesc',
                    title: 'Proceso',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'StepIdDesc',
                    title: 'Etapa',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Name',
                    title: 'Name',
                    sortable: true,
                    halign: 'center',
                    events: 'ProcessSpecTaskGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos del process spec task">' + value + '</a>';
                    }
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'SLATimeOut',
                    title: 'SLA Time Out',
                    titleTooltip: 'Define el tiempo maximo en minutos para que el paso o estado se de por procesado.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
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
                    field: 'TaskOrder',
                    title: 'Orden',
                    titleTooltip: 'Orden en que se procesan la tarea.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'TypeDesc',
                    title: 'Tipo',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Action',
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
                }, {
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un process spec task',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'ProcessSpecTaskGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del process spec task de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del process spec task de la fila"> <i class="fa fa-close"></i> </button>';
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
    }

    function Event_Controls() {

        $('.tool-audit').on('click', function (e) {
            app.ui.components.ShowModalChangeSet(1302);
        });

        $('.tool-new').on('click', function (e) {
            app.GeneralProcessSpecTask.New();
        });

         $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#ProcessSpecTaskSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#ProcessSpecTaskEdtFormSave').click(function () {
            if (app.ui.IsValid('#ProcessSpecTaskEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecTaskEdtFormSave');
                var data = MapInputToObject();
                if (data.Id === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecTaskEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#ProcessSpecTaskEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecTaskEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#ProcessSpecTaskEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#ProcessSpecTaskEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecTaskEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#ProcessSpecTaskEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#ProcessSpecTaskEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecTaskEdtFormDuplicate');
                var data = MapInputToObject();
                data.Id = 0;
                data.Name += ' duplicado';
                app.ui.ButtonDone('#ProcessSpecTaskEdtFormDuplicate');
                app.GeneralProcessSpecTask.EditRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecTaskEdtFormDelete').click(function () {
            if (app.ui.IsValid('#ProcessSpecTaskEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecTaskEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#ProcessSpecTaskEdtFormDelete');
                app.GeneralProcessSpecTask.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecTaskEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

        $('#Type').change(function () {
            event.preventDefault();
            if (app.ui.GetDropDownNumericValue('#Type') === 10) {
                // $('#Action').addClass('d-none');
                $('#ActionGoto').removeClass('d-none');
            }
            else {
                //  $('#Action').removeClass('d-none');
                $('#ActionGoto').addClass('d-none');
            }
        });

        $('#StepIdFlt').on('select2:select', function (e) {
            Refresh();
        });
        $('#StepIdFlt').on('select2:unselect', function (e) {
            Refresh();
        });

    };

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/ProcessSpecTask', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El process spec task '" + uidata.Name + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralProcessSpecTask.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralProcessSpecTask.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#ProcessSpecTaskEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#ProcessSpecTaskEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#ProcessSpecTaskEdtFormSaveCopy');
                        break;
                }
            });
    };

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/ProcessSpecTask/' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El process spec task '" + uidata.Name + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#ProcessSpecTaskEdtFormSave');
            });
    };

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el process spec task '" + uidata.Name + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/ProcessSpecTask/' + uidata.Id)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El process spec task '" + uidata.Name + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    };

    function Init_Lookups() {
        app.core.Lookups(['Process.FlowId', 'Process.FlowIdFlt.', 'StepsDep.StepId', 'StepsDep.StepIdFlt', 'TaskType.Type'], Dynamic_Event_Controls);
        // Dependencies
        $('#FlowIdFlt').on('change', function () {
            app.core.LookupDependency($('select#FlowIdFlt').val(), 'StepIdFlt', 'StepsDep', '', null, true, null, "flowid=");
        });
        $('#FlowId').on('change', function () {
            app.core.LookupDependency($('select#FlowId').val(), 'StepId', 'StepsDep', '', null, true, null, "flowid=");
            app.core.LookupDependency($('select#FlowId').val(), 'ActionGoto', 'StepsDep', '', null, true, null, "flowid=");
        });
    };

    function Dynamic_Event_Controls() {
        $('#StepIdFlt').select2({ width: '100%', theme: 'bootstrap4' });

    };

    function MapInputToObject() {
        var data = {
            Id: parseInt(0 + $('#Id').val(), 10),
            StepId: app.ui.GetDropDownNumericValue('#StepId'),
            Name: $('#Name').val(),
            Description: $('#Description').val(),
            SLATimeOut: app.ui.GetNumericValue('#SLATimeOut'),
            IsRequired: $('#IsRequired').is(':checked'),
            IsSelected: $('#IsSelected').is(':checked'),
            TaskOrder: app.ui.GetNumericValue('#TaskOrder'),
            Type: app.ui.GetDropDownNumericValue('#Type'),
            Action: $('#Action').val(),
            SubStatus: app.ui.GetNumericValue('#SubStatus'),
            SubLabel: $('#SubLabel').val(),
            PreScript: $('#PreScript').val(),
            PostScript: $('#PostScript').val()

        };

        if (data.Type === 10) {
            data.Action = app.ui.GetDropDownNumericValue('#ActionGoto');
        }

        return data;
    };

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        $('#Name').val(data.Name);
        $('#Description').val(data.Description);
        app.ui.SetNumericValue('#SLATimeOut', data.SLATimeOut);
        $('#IsRequired').prop('checked', data.IsRequired);
        $('#IsSelected').prop('checked', data.IsSelected);
        app.ui.SetNumericValue('#TaskOrder', data.TaskOrder);
        app.ui.SetDropDownNumericValue('#Type', data.Type, true);
        $('#Action').val(data.Action);
        app.ui.SetNumericValue('#SubStatus', data.SubStatus);
        $('#SubLabel').val(data.SubLabel);
        $('#PreScript').val(data.PreScript);
        $('#PostScript').val(data.PostScript);

        if (app.ui.GetDropDownNumericValue('#FlowId') != data.FlowId) {
            $('#FlowId').val(data.FlowId);
            app.core.LookupDependency(data.FlowId, 'ActionGoto', 'StepsDep', '', null, true,
                function () {
                    if (data.Type === 10) {
                        $('#ActionGoto').val(data.Action);
                    }
                    $('#Type').change();
                }, "flowid=");
            app.core.LookupDependency(data.FlowId, 'StepId', 'StepsDep', '', null, true,
                function () {
                    $('#StepId').val(data.StepId);
                }, "flowid=");
        }
        else {
            $('#StepId').val(data.StepId);
            if (data.Type === 10) {
                $('#ActionGoto').val(data.Action);
            }
            $('#Type').change();
        }
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#ProcessSpecTaskEdtForm").validate({
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
                StepId: {
                    required: true
                },
                Name: {
                    required: true
                },
                TaskOrder: {
                    required: true
                },
                Type: {
                    required: true
                }
            },
            messages: {
                StepId: {
                    required: 'Debe indicar el etapa'
                },
                Name: {
                    required: 'Debe indicar el nombre'
                },
                TaskOrder: {
                    required: 'Debe indicar el orden'
                },
                Type: {
                    required: 'Debe indicar el tipo'
                }
            }

        });
    };

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#ProcessSpecTaskGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#ProcessSpecTaskEdt').removeClass('d-none');

        if (row.Id === 0) {
            MapObjectToInput(row);
            $('#Name').focus();
            $('#ProcessSpecTaskEdtFormSaveContinue').removeClass('d-none');
            $('#ProcessSpecTaskEdtFormSaveCopy').removeClass('d-none');
            $('#ProcessSpecTaskEdtFormDuplicate').addClass('d-none');
            $('#ProcessSpecTaskEdtFormDelete').addClass('d-none');
            $('#ProcessSpecTaskEdtFormSave').removeClass('d-none');
            $('#ProcessSpecTaskEdtFormCancel').removeClass('d-none');
        } else {
            $('.ibox-content').toggleClass('sk-loading');
            app.core.Get(app.setting.apipath + 'v1/ProcessSpecTask/' + row.Id)
                .done(function (data, textStatus, jqXHR) {
                    MapObjectToInput(data);
                    $('#Name').focus();
                    $('#ProcessSpecTaskEdtFormSaveContinue').addClass('d-none');
                    $('#ProcessSpecTaskEdtFormSaveCopy').addClass('d-none');
                    $('#ProcessSpecTaskEdtFormDuplicate').removeClass('d-none');
                    $('#ProcessSpecTaskEdtFormDelete').removeClass('d-none');
                    $('#ProcessSpecTaskEdtFormSave').removeClass('d-none');
                    $('#ProcessSpecTaskEdtFormCancel').removeClass('d-none');
                }).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });
        }
    };

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').removeClass('d-none');
        $('#ProcessSpecTaskGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#ProcessSpecTaskEdt').addClass('d-none');
        $('.formbtn').addClass('d-none');
    };

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
            } else {
                Refresh();
            }
        },
        New: function (row) {
            let newRow = { Id: 0, FlowId: 0, StepId: 0, Name: null, Description: null, SLATimeOut: 0, IsRequired: null, IsSelected: null, TaskOrder: 0, Type: null, Action: null, SubStatus: 0, SubLabel: null, PreScript: null, PostScript: null }
            if (row !== undefined) {
                row.Id = 0;
                newRow = row;
            }
            if (newRow.FlowId === 0 && $('#FlowIdFlt').val() != null) {
                newRow.FlowId = $('#FlowIdFlt').val();
            }
            if (newRow.StepId === 0 && $('#StepIdFlt').val().length > 0) {
                newRow.StepId = $('#StepIdFlt').val()[0];
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

window.ProcessSpecTaskGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralProcessSpecTask.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralProcessSpecTask.EditRow(row);
        e.stopPropagation();
    }
};
