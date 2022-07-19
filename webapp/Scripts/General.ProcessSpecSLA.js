var app = app || {};

app.GeneralProcessSpecSLA = (function () {

    function Refresh() {
        var filter = $('#ProcessSpecSLASearch').val();
        var statusFltVal = $('#StatusFlt').select2('data').map(function (item) { return item['id']; }).toString();
        if (statusFltVal != '')
            statusFltVal = '&status=' + statusFltVal;

        $('#ProcessSpecSLAGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/ProcessSpecSLA?filter=' + filter + statusFltVal)
            .done(function (data, textStatus, jqXHR) {
                $('#ProcessSpecSLAGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#ProcessSpecSLAGridTbl').bootstrapTable('hideLoading');
            });
    }

    function Init_Controls() {

        $('#StatusFlt').select2({ width: '100%', theme: 'bootstrap4' });

        $(".formbtn").appendTo("#GenericToolBar");
    }

    function Init_List() {
        $('#ProcessSpecSLAGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'Name',
                    title: 'Nombre',
                    sortable: true,
                    halign: 'center',
                    events: 'ProcessSpecSLAGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos del processspecsla">' + value + '</a>';
                    }
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center'
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
                    titleTooltip: 'Acciones disponibles para un processspecsla',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'ProcessSpecSLAGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del processspecsla de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del processspecsla de la fila"> <i class="fa fa-close"></i> </button>';
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
            app.ui.components.ShowModalChangeSet(0000);
        });

        $('.tool-new').on('click', function (e) {
            app.GeneralProcessSpecSLA.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#ProcessSpecSLASearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#ProcessSpecSLAEdtFormSave').click(function () {
            if (app.ui.IsValid('#ProcessSpecSLAEdtForm', false) && OtherValidations()) {
                app.ui.ButtonDoing('#ProcessSpecSLAEdtFormSave');
                var data = MapInputToObject();
                if (data.Id === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecSLAEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#ProcessSpecSLAEdtForm', false) && OtherValidations()) {
                app.ui.ButtonDoing('#ProcessSpecSLAEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#ProcessSpecSLAEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#ProcessSpecSLAEdtForm', false) && OtherValidations()) {
                app.ui.ButtonDoing('#ProcessSpecSLAEdtFormSaveCopy');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#ProcessSpecSLAEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#ProcessSpecSLAEdtForm', false) && OtherValidations()) {
                app.ui.ButtonDoing('#ProcessSpecSLAEdtFormDuplicate');
                var data = MapInputToObject();
                data.Id = 0;
                data.Name += ' duplicado';
                app.ui.ButtonDone('#ProcessSpecSLAEdtFormDuplicate');
                app.GeneralProcessSpecSLA.EditRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecSLAEdtFormDelete').click(function () {
            if (app.ui.IsValid('#ProcessSpecSLAEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecSLAEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#ProcessSpecSLAEdtFormDelete');
                app.GeneralProcessSpecSLA.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecSLAEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

    }

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/ProcessSpecSLA', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El processspecsla '" + uidata.Name + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralProcessSpecSLA.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralProcessSpecSLA.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#ProcessSpecSLAEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#ProcessSpecSLAEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#ProcessSpecSLAEdtFormSaveCopy');
                        break;
                }
            });
    }

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/ProcessSpecSLA/' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El processspecsla '" + uidata.Name + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#ProcessSpecSLAEdtFormSave');
            });
    }

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el processspecsla '" + uidata.Name + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/ProcessSpecSLA/' + uidata.Id)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El processspecsla '" + uidata.Name + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    }

    function Init_Lookups() {
        app.core.Lookups(['EstadoRegistro.Status', 'EstadoRegistro.StatusFlt'], Dynamic_Event_Controls);
        // Dependencies
    }

    function Dynamic_Event_Controls() {
        $('#StatusFlt').select2({ width: '100%', theme: 'bootstrap4' });

    }

    function MapInputToObject() {
        return {
            Id: parseInt(0 + $('#Id').val(), 10),
            Name: $('#Name').val(),
            Description: $('#Description').val(),
            Status: $('#Status').val(),
            Levels: app.GeneralProcessSpecSLALevel.GetData()
        };
    }

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        $('#Name').val(data.Name);
        $('#Description').val(data.Description);
        $('#Status').val(data.Status);
        app.GeneralProcessSpecSLALevel.SetData(data.Levels);
    }

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#ProcessSpecSLAEdtForm").validate({
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
                Status: {
                    required: true
                }
            },
            messages: {
                Name: {
                    required: 'Debe indicar el nombre'
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
        $('#ProcessSpecSLAGridTblContainer').addClass('d-none');
        $('#ProcessSpecSLAEdt').removeClass('d-none');

        if (row.Id === 0) {
            MapObjectToInput(row);
            $('#Name').focus();
            $('#ProcessSpecSLAEdtFormSaveContinue').removeClass('d-none');
            $('#ProcessSpecSLAEdtFormSaveCopy').removeClass('d-none');
            $('#ProcessSpecSLAEdtFormDuplicate').addClass('d-none');
            $('#ProcessSpecSLAEdtFormDelete').addClass('d-none');
            $('#ProcessSpecSLAEdtFormSave').removeClass('d-none');
            $('#ProcessSpecSLAEdtFormCancel').removeClass('d-none');
        } else {
            $('.ibox-content').toggleClass('sk-loading');
            app.core.Get(app.setting.apipath + 'v1/ProcessSpecSLA/' + row.Id)
                .done(function (data, textStatus, jqXHR) {
                    MapObjectToInput(data);
                    $('#Name').focus();
                    $('#ProcessSpecSLAEdtFormSaveContinue').addClass('d-none');
                    $('#ProcessSpecSLAEdtFormSaveCopy').addClass('d-none');
                    $('#ProcessSpecSLAEdtFormDuplicate').removeClass('d-none');
                    $('#ProcessSpecSLAEdtFormDelete').removeClass('d-none');
                    $('#ProcessSpecSLAEdtFormSave').removeClass('d-none');
                    $('#ProcessSpecSLAEdtFormCancel').removeClass('d-none');
                }).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });
        }
    }

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#ProcessSpecSLAGridTblContainer').removeClass('d-none');
        $('#ProcessSpecSLAEdt').addClass('d-none');
        $('.formbtn').addClass('d-none');
    }

    function OtherValidations() {
        let levels = app.GeneralProcessSpecSLALevel.GetData();
        let result = true;
        if (levels.length === 0) {
            result = false;
            $('#ProcessSpecSLALevelGridTbl-error').text('Debe existir al menos un nivel para el acuerdo de servicio');
            $('#ProcessSpecSLALevelGridTbl-error').removeClass('d-none');
        }
        else {
            $('#ProcessSpecSLALevelGridTbl-error').text('');
            $('#ProcessSpecSLALevelGridTbl-error').addClass('d-none');
        }
        return result;
    }

    return {
        Init: function () {
            Init_List();
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Refresh();
            Setup_Validations();
            app.GeneralProcessSpecSLALevel.Init();
        },
        New: function (row) {
            let newRow = { Id: 0, Name: null, Description: null, Status: 1 }
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

window.ProcessSpecSLAGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralProcessSpecSLA.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralProcessSpecSLA.EditRow(row);
        e.stopPropagation();
    }
};
