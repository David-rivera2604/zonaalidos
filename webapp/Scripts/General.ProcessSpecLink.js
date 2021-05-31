var app = app || {};

app.GeneralProcessSpecLink = (function () {

    function Refresh() {
        var filter = '';
        var flowIdFltVal = $('#FlowIdFlt').val();
        if (flowIdFltVal != null && flowIdFltVal != '' && flowIdFltVal != '0') {
            filter = filter + ':flowId=' + flowIdFltVal;
        }
        if (flowIdFltVal.length > 0) {
            $('#ProcessSpecLinkGridTbl').bootstrapTable('showLoading');
            app.core.Get(app.setting.apipath + 'v1/ProcessSpecLink?filter=' + filter)
                .done(function (data, textStatus, jqXHR) {
                    $('#ProcessSpecLinkGridTbl').bootstrapTable('load', data !== null ? data : []);
                }).always(function () {
                    $('#ProcessSpecLinkGridTbl').bootstrapTable('hideLoading');
                });
        } else {
            $('#ProcessSpecLinkGridTbl').bootstrapTable('load', []);
        }
    }

    function Init_Controls() {
        new AutoNumeric('#LinkOrder', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });

        $('#FlowIdFlt').select2({ width: '100%', theme: 'bootstrap4' });

        $(".formbtn").appendTo("#GenericToolBar");
    };

    function Init_List() {
        $('#ProcessSpecLinkGridTbl').bootstrapTable({
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
                    field: 'Name',
                    title: 'Nombre',
                    sortable: true,
                    halign: 'center',
                    events: 'ProcessSpecLinkGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos del processspeclink">' + value + '</a>';
                    }
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Icon',
                    title: 'Icon',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'TypeDesc',
                    title: 'Tipo',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'LinkOrder',
                    title: 'Orden',
                    titleTooltip: 'Orden en que se procesan la tarea.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'URL',
                    title: 'URL',
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
                    titleTooltip: 'Acciones disponibles para un processspeclink',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'ProcessSpecLinkGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del processspeclink de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del processspeclink de la fila"> <i class="fa fa-close"></i> </button>';
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
            app.GeneralProcessSpecLink.New();
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#ProcessSpecLinkSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#ProcessSpecLinkEdtFormSave').click(function () {
            if (app.ui.IsValid('#ProcessSpecLinkEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecLinkEdtFormSave');
                var data = MapInputToObject();
                if (data.Id === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecLinkEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#ProcessSpecLinkEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecLinkEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#ProcessSpecLinkEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#ProcessSpecLinkEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecLinkEdtFormSaveCopy');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#ProcessSpecLinkEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#ProcessSpecLinkEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecLinkEdtFormDuplicate');
                var data = MapInputToObject();
                data.Id = 0;
                data.Name += ' duplicado';
                app.ui.ButtonDone('#ProcessSpecLinkEdtFormDuplicate');
                app.GeneralProcessSpecLink.EditRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecLinkEdtFormDelete').click(function () {
            if (app.ui.IsValid('#ProcessSpecLinkEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecLinkEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#ProcessSpecLinkEdtFormDelete');
                app.GeneralProcessSpecLink.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecLinkEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

        $('#FlowIdFlt').on('select2:select', function (e) {
            Refresh();
        });
    };

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/ProcessSpecLink', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El processspeclink '" + uidata.Name + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralProcessSpecLink.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralProcessSpecLink.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#ProcessSpecLinkEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#ProcessSpecLinkEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#ProcessSpecLinkEdtFormSaveCopy');
                        break;
                }
            });
    };

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/ProcessSpecLink/' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El processspeclink '" + uidata.Name + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#ProcessSpecLinkEdtFormSave');
            });
    };

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el processspeclink '" + uidata.Name + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/ProcessSpecLink/' + uidata.Id)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El processspeclink '" + uidata.Name + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    };

    function Init_Lookups() {
        app.core.Lookups(['Process.FlowId', 'Process.FlowIdFlt', 'LinkType.Type'], Dynamic_Event_Controls);
        // Dependencies
    };

    function Dynamic_Event_Controls() {
        $('#FlowIdFlt').select2({ width: '100%', theme: 'bootstrap4' });
    };

    function MapInputToObject() {
        var data = {
            Id: parseInt(0 + $('#Id').val(), 10),
            FlowId: $('#FlowId').val(),
            Name: $('#Name').val(),
            Description: $('#Description').val(),
            Icon: $('#Icon').val(),
            Type: $('#Type').val(),
            LinkOrder: app.ui.GetNumericValue('#LinkOrder'),
            URL: $('#URL').val()

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        $('#FlowId').val(data.FlowId);
        $('#Name').val(data.Name);
        $('#Description').val(data.Description);
        $('#Icon').val(data.Icon);
        $('#Type').val(data.Type);
        app.ui.SetNumericValue('#LinkOrder', data.LinkOrder);
        $('#URL').val(data.URL);

    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#ProcessSpecLinkEdtForm").validate({
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
                },
                Name: {
                    required: true
                },
                Type: {
                    required: true
                }
            },
            messages: {
                FlowId: {
                    required: 'Debe indicar el proceso'
                },
                Name: {
                    required: 'Debe indicar el nombre'
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
        $('#ProcessSpecLinkGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#ProcessSpecLinkEdt').removeClass('d-none');

        if (row.Id === 0) {
            MapObjectToInput(row);
            $('#Name').focus();
            $('#ProcessSpecLinkEdtFormSaveContinue').removeClass('d-none');
            $('#ProcessSpecLinkEdtFormSaveCopy').removeClass('d-none');
            $('#ProcessSpecLinkEdtFormDuplicate').addClass('d-none');
            $('#ProcessSpecLinkEdtFormDelete').addClass('d-none');
            $('#ProcessSpecLinkEdtFormSave').removeClass('d-none');
            $('#ProcessSpecLinkEdtFormCancel').removeClass('d-none');
        } else {
            $('.ibox-content').toggleClass('sk-loading');

            app.core.Get(app.setting.apipath + 'v1/ProcessSpecLink/' + row.Id)
                .done(function (data, textStatus, jqXHR) {
                    MapObjectToInput(data);
                    $('#Name').focus();
                    $('#ProcessSpecLinkEdtFormSaveContinue').addClass('d-none');
                    $('#ProcessSpecLinkEdtFormSaveCopy').addClass('d-none');
                    $('#ProcessSpecLinkEdtFormDuplicate').removeClass('d-none');
                    $('#ProcessSpecLinkEdtFormDelete').removeClass('d-none');
                    $('#ProcessSpecLinkEdtFormSave').removeClass('d-none');
                    $('#ProcessSpecLinkEdtFormCancel').removeClass('d-none');
                }).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });

        }
    };

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').removeClass('d-none');
        $('#ProcessSpecLinkGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#ProcessSpecLinkEdt').addClass('d-none');
        $('.formbtn').addClass('d-none');
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
            let newRow = { Id: 0, FlowId: null, Name: null, Description: null, Icon: null, Type: null, LinkOrder: 0, URL: null }
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

window.ProcessSpecLinkGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralProcessSpecLink.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralProcessSpecLink.EditRow(row);
        e.stopPropagation();
    }
};
