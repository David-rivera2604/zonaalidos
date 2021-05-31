var app = app || {};

app.GeneralLookupMaster = (function () {

    function Refresh() {
        var filter = $('#LookupMasterSearch').val();

        $('#LookupMasterGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/LookupMaster?filter=' + filter)
            .done(function (data, textStatus, jqXHR) {
                $('#LookupMasterGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#LookupMasterGridTbl').bootstrapTable('hideLoading');
            });
    }

    function Init_Controls() {


        $(".formbtn").appendTo("#GenericToolBar");
    }

    function Init_List() {
        $('#LookupMasterGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'TypeDesc',
                    title: 'Tipo',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center',
                    events: 'LookupMasterGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos del lookup master">' + value + '</a>';
                    }
                }, {
                    field: 'Key',
                    title: 'Clave',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Tenant',
                    title: 'Compañia',
                    titleTooltip: 'Identificación de la compañia propietaria.',					
                    sortable: true,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.BooleanFormatter'
                }, {
                    field: 'Statement',
                    title: 'Instrucción',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'IsCached',
                    title: 'Is Cached',
                    titleTooltip: '.',					
                    sortable: true,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.BooleanFormatter'
                }, {
                    field: 'ConnectionName',
                    title: 'Conexión',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'IncludeByRole',
                    title: 'Include by Role',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'ExcludeByRole',
                    title: 'Exclude by Role',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'RecordStatusDesc',
                    title: 'Estado del Registro',
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
                    titleTooltip: 'Acciones disponibles para un lookup master',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'LookupMasterGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del lookup master de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del lookup master de la fila"> <i class="fa fa-close"></i> </button>';
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
            app.ui.components.ShowModalChangeSet(1020);
        });

        $('.tool-new').on('click', function (e) {
            app.GeneralLookupMaster.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#LookupMasterSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#LookupMasterEdtFormSave').click(function () {
            if (app.ui.IsValid('#LookupMasterEdtForm', false)) {
                app.ui.ButtonDoing('#LookupMasterEdtFormSave');
                var data = MapInputToObject();
                if (data.LookupId === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#LookupMasterEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#LookupMasterEdtForm', false)) {
                app.ui.ButtonDoing('#LookupMasterEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#LookupMasterEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#LookupMasterEdtForm', false)) {
                app.ui.ButtonDoing('#LookupMasterEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#LookupMasterEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#LookupMasterEdtForm', false)) {
                app.ui.ButtonDoing('#LookupMasterEdtFormDuplicate');
                var data = MapInputToObject();
                data.LookupId = 0;
                data.Description += ' duplicado';
                app.ui.ButtonDone('#LookupMasterEdtFormDuplicate');
                app.GeneralLookupMaster.EditRow(data);
            }
            event.preventDefault();
        });

        $('#LookupMasterEdtFormDelete').click(function () {
            if (app.ui.IsValid('#LookupMasterEdtForm', false)) {
                app.ui.ButtonDoing('#LookupMasterEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#LookupMasterEdtFormDelete');
                app.GeneralLookupMaster.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#LookupMasterEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

    }

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/LookupMaster', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El lookup master '" + uidata.Description + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralLookupMaster.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralLookupMaster.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#LookupMasterEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#LookupMasterEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#LookupMasterEdtFormSaveCopy');
                        break;
                }
            });
    }

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/LookupMaster/' + uidata.LookupId, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El lookup master '" + uidata.Description + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#LookupMasterEdtFormSave');
            });
    }

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el lookup master '" + uidata.Description + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/LookupMaster/' + uidata.LookupId)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El lookup master '" + uidata.Description + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    }

    function Init_Lookups() {
        app.core.Lookups(['LookupType.Type', 'EstadoRegistro.RecordStatus'], Dynamic_Event_Controls);
        // Dependencies
    }

    function Dynamic_Event_Controls() {

    }

    function MapInputToObject() {
        return {
            LookupId: parseInt(0 + $('#LookupId').val(), 10),
            Type: $('#Type').val(),
            Description: $('#Description').val(),
            Key: $('#Key').val(),
            Tenant: $('#Tenant').is(':checked'),
            Statement: $('#Statement').val(),
            IsCached: $('#IsCached').is(':checked'),
            ConnectionName: $('#ConnectionName').val(),
            IncludeByRole: $('#IncludeByRole').val(),
            ExcludeByRole: $('#ExcludeByRole').val(),
            RecordStatus: $('#RecordStatus').val()

        };
    }

    function MapObjectToInput(data) {
        $('#LookupId').val(data.LookupId);
        $('#Type').val(data.Type);
        $('#Description').val(data.Description);
        $('#Key').val(data.Key);
        $('#Tenant').prop('checked', data.Tenant);
        $('#Statement').val(data.Statement);
        $('#IsCached').prop('checked', data.IsCached);
        $('#ConnectionName').val(data.ConnectionName);
        $('#IncludeByRole').val(data.IncludeByRole);
        $('#ExcludeByRole').val(data.ExcludeByRole);
        $('#RecordStatus').val(data.RecordStatus);

    }

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#LookupMasterEdtForm").validate({
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
                Type: {
                    required: true
                },
                Description: {
                    required: true
                },
                Key: {
                    required: true
                },
                RecordStatus: {
                    required: true
                }
            },
            messages: {
                Type: {
                    required: 'Debe indicar el tipo'
                },
                Description: {
                    required: 'Debe indicar el descripción'
                },
                Key: {
                    required: 'Debe indicar el clave'
                },
                RecordStatus: {
                    required: 'Debe indicar el estado del registro'
                }
            }

        });
    }

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#LookupMasterGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#LookupMasterEdt').removeClass('d-none');

        if (row.LookupId === 0) {
			MapObjectToInput(row);
			$('#Description').focus();		
            $('#LookupMasterEdtFormSaveContinue').removeClass('d-none');
            $('#LookupMasterEdtFormSaveCopy').removeClass('d-none');
            $('#LookupMasterEdtFormDuplicate').addClass('d-none');
            $('#LookupMasterEdtFormDelete').addClass('d-none');
			$('#LookupMasterEdtFormSave').removeClass('d-none');
			$('#LookupMasterEdtFormCancel').removeClass('d-none');
        } else {
            $('.ibox-content').toggleClass('sk-loading');		
			app.core.Get(app.setting.apipath + 'v1/LookupMaster/' + row.LookupId)
				.done(function (data, textStatus, jqXHR) {
					MapObjectToInput(data);
					$('#Description').focus();
					$('#LookupMasterEdtFormSaveContinue').addClass('d-none');
					$('#LookupMasterEdtFormSaveCopy').addClass('d-none');
					$('#LookupMasterEdtFormDuplicate').removeClass('d-none');
					$('#LookupMasterEdtFormDelete').removeClass('d-none');
					$('#LookupMasterEdtFormSave').removeClass('d-none');
					$('#LookupMasterEdtFormCancel').removeClass('d-none');					
				}).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
				});
        }
    }

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#LookupMasterGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#LookupMasterEdt').addClass('d-none');
        $('.formbtn').addClass('d-none');		
    }

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
            let newRow = { LookupId: 0, Type: null, Description: null, Key: null, Tenant: null, Statement: null, IsCached: 1, ConnectionName: null, IncludeByRole: null, ExcludeByRole: null, RecordStatus: null }
            if (row !== undefined) {
                row.LookupId = 0;
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

window.LookupMasterGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralLookupMaster.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralLookupMaster.EditRow(row);
        e.stopPropagation();
    }
};
