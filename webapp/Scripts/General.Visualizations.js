var app = app || {};

app.GeneralVisualizations = (function () {

    function Refresh() {
        var filter = $('#VisualizationsSearch').val();

        $('#VisualizationsGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/Visualizations?filter=' + filter)
            .done(function (data, textStatus, jqXHR) {
                $('#VisualizationsGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#VisualizationsGridTbl').bootstrapTable('hideLoading');
            });
    }

    function Init_Controls() {


        $(".formbtn").appendTo("#GenericToolBar");
    }

    function Init_List() {
        $('#VisualizationsGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'EntityTypeDesc',
                    title: 'Tipo de entidad',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'TypeDesc',
                    title: 'Type',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Caption',
                    title: 'Caption',
                    sortable: true,
                    halign: 'center',
                    events: 'VisualizationsGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos del visualizations">' + value + '</a>';
                    }
                }, {
                    field: 'Description',
                    title: 'Description',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'StatementTypeDesc',
                    title: 'Tipo de comando',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Statement',
                    title: 'Statement',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Specification',
                    title: 'Especificación',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Icon',
                    title: 'Icon',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'IconClass',
                    title: 'Icon Class',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'ValueFormat',
                    title: 'Value Format',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'ConnectionName',
                    title: 'Conexión',
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
                    titleTooltip: 'Acciones disponibles para un visualizations',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'VisualizationsGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del visualizations de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del visualizations de la fila"> <i class="fa fa-close"></i> </button>';
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
            app.ui.components.ShowModalChangeSet(1207);
        });

        $('.tool-new').on('click', function (e) {
            app.GeneralVisualizations.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#VisualizationsSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#VisualizationsEdtFormSave').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#VisualizationsEdtFormSave');
                var data = MapInputToObject();
                if (data.Id === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#VisualizationsEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#VisualizationsEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#VisualizationsEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#VisualizationsEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#VisualizationsEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#VisualizationsEdtFormDuplicate');
                var data = MapInputToObject();
                data.Id = 0;
                data.Caption += ' duplicado';
                app.ui.ButtonDone('#VisualizationsEdtFormDuplicate');
                app.GeneralVisualizations.EditRow(data);
            }
            event.preventDefault();
        });

        $('#VisualizationsEdtFormDelete').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#VisualizationsEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#VisualizationsEdtFormDelete');
                app.GeneralVisualizations.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#VisualizationsEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

    }

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/Visualizations', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El visualizations '" + uidata.Caption + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralVisualizations.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralVisualizations.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#VisualizationsEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#VisualizationsEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#VisualizationsEdtFormSaveCopy');
                        break;
                }
            });
    }

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/Visualizations/' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El visualizations '" + uidata.Caption + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#VisualizationsEdtFormSave');
            });
    }

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + uidata.Caption + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/Visualizations/' + uidata.Id)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El visualizations '" + uidata.Caption + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    }

    function Init_Lookups() {
        app.core.Lookups(['EntityType.EntityType', 'VisualizationType.Type', 'StatementType.StatementType', 'EstadoRegistro.RecordStatus'], Dynamic_Event_Controls);
        // Dependencies
    }

    function Dynamic_Event_Controls() {

    }

    function MapInputToObject() {
        return {
            Id: parseInt(0 + $('#Id').val(), 10),
            EntityType: $('#EntityType').val(),
            Sequence: parseInt(0 + $('#Sequence').val(), 10),
            Type: $('#Type').val(),
            Caption: $('#Caption').val(),
            Description: $('#Description').val(),
            StatementType: $('#StatementType').val(),
            Statement: $('#Statement').val(),
            Specification: $('#Specification').val(),
            Icon: $('#Icon').val(),
            IconClass: $('#IconClass').val(),
            ValueFormat: $('#ValueFormat').val(),
            ConnectionName: $('#ConnectionName').val(),
            RecordStatus: $('#RecordStatus').val()

        };
    }

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        $('#EntityType').val(data.EntityType);
        $('#Sequence').val(data.Sequence);
        $('#Type').val(data.Type);
        $('#Caption').val(data.Caption);
        $('#Description').val(data.Description);
        $('#StatementType').val(data.StatementType);
        $('#Statement').val(data.Statement);
        $('#Specification').val(data.Specification);
        $('#Icon').val(data.Icon);
        $('#IconClass').val(data.IconClass);
        $('#ValueFormat').val(data.ValueFormat);
        $('#ConnectionName').val(data.ConnectionName);
        $('#RecordStatus').val(data.RecordStatus);

    }

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#VisualizationsEdtForm").validate({
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
                RecordStatus: {
                    required: true
                }
            },
            messages: {
                RecordStatus: {
                    required: 'Debe indicar el estado del registro'
                }
            }

        });
    }

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#VisualizationsGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#VisualizationsEdt').removeClass('d-none');

        if (row.Id === 0) {
			MapObjectToInput(row);
			$('#Caption').focus();		
            $('#VisualizationsEdtFormSaveContinue').removeClass('d-none');
            $('#VisualizationsEdtFormSaveCopy').removeClass('d-none');
            $('#VisualizationsEdtFormDuplicate').addClass('d-none');
            $('#VisualizationsEdtFormDelete').addClass('d-none');
			$('#VisualizationsEdtFormSave').removeClass('d-none');
			$('#VisualizationsEdtFormCancel').removeClass('d-none');
        } else {
            $('.ibox-content').toggleClass('sk-loading');		
			app.core.Get(app.setting.apipath + 'v1/Visualizations/' + row.Id)
				.done(function (data, textStatus, jqXHR) {
					MapObjectToInput(data);
					$('#Caption').focus();
					$('#VisualizationsEdtFormSaveContinue').addClass('d-none');
					$('#VisualizationsEdtFormSaveCopy').addClass('d-none');
					$('#VisualizationsEdtFormDuplicate').removeClass('d-none');
					$('#VisualizationsEdtFormDelete').removeClass('d-none');
					$('#VisualizationsEdtFormSave').removeClass('d-none');
					$('#VisualizationsEdtFormCancel').removeClass('d-none');					
				}).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
				});
        }
    }

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#VisualizationsGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#VisualizationsEdt').addClass('d-none');
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
            let newRow = { Id: 0, EntityType: null, Sequence: 0, Type: null, Caption: null, Description: null, StatementType: null, Statement: null, Specification: null, Icon: null, IconClass: null, ValueFormat: null, ConnectionName: null, RecordStatus: null }
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

window.VisualizationsGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralVisualizations.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralVisualizations.EditRow(row);
        e.stopPropagation();
    }
};
