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
    };

    function Init_Edit_Controls() {
        new AutoNumeric('#EntityType', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '99999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Type', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '99999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
    };

    function Init_List() {
        $('#VisualizationsGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'EntityType',
                    title: 'Tipo de entidad',
                    titleTooltip: 'Tipo de entidad u objeto que genera el registro.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                }, {
                    field: 'Caption',
                    title: 'Caption',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Description',
                    title: 'Description',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Type',
                    title: 'Type',
                    titleTooltip: 'Tipo de visualizacion, 1 consultas.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'Statement',
                    title: 'Statement',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'Specification',
                    title: 'Especificación',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'Icon',
                    title: 'Icon',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'IconClass',
                    title: 'Icon Class',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'ValueFormat',
                    title: 'Value Format',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'RecordStatusDesc',
                    title: 'Estado del Registro',
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
    };

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
    };

    function Event_Edit_Controls() {
        $('#VisualizationsEdtFormSave').click(function () {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                $('#VisualizationsEdtFormSave').prop("disabled", true);
                $('#VisualizationsEdtFormSave').html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Guardando cambios');
                var data = MapInputToObject()
                if (data.Id === 0)
                    Create(data);
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#VisualizationsEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });
    };

    function Create(uidata) {
        app.core.Post(app.setting.apipath + 'v1/Visualizations', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El visualizations '" + uidata.Caption + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                $('#VisualizationsEdtFormSave').html('Guardar cambios');
                $('#VisualizationsEdtFormSave').prop("disabled", false);
            });
    };

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/Visualizations/' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El visualizations '" + uidata.Caption + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                $('#VisualizationsEdtFormSave').html('Guardar cambios');
                $('#VisualizationsEdtFormSave').prop("disabled", false);
            });
    };

    function Delete(uidata) {
        app.core.Delete(app.setting.apipath + 'v1/Visualizations/' + uidata.Id)
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El visualizations '" + uidata.Caption + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            });
    };

    function Init_Lookups() {
        // Dependencies
    };

    function Init_Edit_Lookups() {
        app.core.Lookups(['EstadoRegistro.RecordStatus'], Dynamic_Event_Controls);
        // Dependencies
    };

    function Dynamic_Event_Controls() {

    };

    function MapInputToObject() {
        var data = {
            Id: parseInt(0 + $('#Id').val(), 10),
            EntityType: app.ui.GetNumericValue('#EntityType'),
            Sequence: parseInt(0 + $('#Sequence').val(), 10),
            Type: app.ui.GetNumericValue('#Type'),
            Caption: $('#Caption').val(),
            Description: $('#Description').val(),
            Statement: $('#Statement').val(),
            Specification: $('#Specification').val(),
            Icon: $('#Icon').val(),
            IconClass: $('#IconClass').val(),
            ValueFormat: $('#ValueFormat').val(),
            RecordStatus: $('#RecordStatus').val()

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        app.ui.SetNumericValue('#EntityType', data.EntityType);
        $('#Sequence').val(data.Sequence);
        app.ui.SetNumericValue('#Type', data.Type);
        $('#Caption').val(data.Caption);
        $('#Description').val(data.Description);
        $('#Statement').val(data.Statement);
        $('#Specification').val(data.Specification);
        $('#Icon').val(data.Icon);
        $('#IconClass').val(data.IconClass);
        $('#ValueFormat').val(data.ValueFormat);
        $('#RecordStatus').val(data.RecordStatus);

    };

    function Setup_Validations() {
    };

    function Setup_Edit_Validations() {
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
    };

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#VisualizationsGridTbl').addClass('d-none');
        $('#VisualizationsEdt').removeClass('d-none');
        MapObjectToInput(row);
        $('#Caption').focus();
    };

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#VisualizationsGridTbl').removeClass('d-none');
        $('#VisualizationsEdt').addClass('d-none');
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
        New: function () {
            ShowEditMode({ Id: 0, EntityType: 0, Sequence: 0, Type: 0, Caption: null, Description: null, Statement: null, Specification: null, Icon: null, IconClass: null, ValueFormat: null, RecordStatus: null });
        },
        ShowEditRow: function (row) {
            if ($('#VisualizationsEdtForm').length === 0) {
                app.core.GetView(app.setting.viewpath + 'General/VisualizationsEdtForm')
                    .done(function (data, textStatus, jqXHR) {
                        $("#VisualizationsEdt").append(data);
                        Init_Edit_Controls();
                        Init_Edit_Lookups();
                        Event_Edit_Controls();
                        Setup_Edit_Validations();
                        EditMode(row);
                    });
            }
            else {
                EditMode(row);
            }
        },
        DeleteRow: function (row) {
            Delete(row);
        }
    };
})();

window.VisualizationsGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.Caption + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.GeneralVisualizations.DeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralVisualizations.ShowEditRow(row);
        e.stopPropagation();
    }
};