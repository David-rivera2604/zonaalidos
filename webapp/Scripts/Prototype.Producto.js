var app = app || {};

app.PrototypeProducto = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {



        //app.core.Get(app.setting.apipath + 'v1/Quote/ProductoSetup', null,
        //    function (data) {
        //        app.core.Lookups([],
        //            function () {
        //                setupData = data;
        //                MapObjectToInput(data);
        //            }, ``);

        //    });
    };

    function ReadOnly() {
        $('#alias').replaceWith('<div>' + $('#alias').val() + '</div>');
        $('#validacionesNew').addClass('d-none');
        $('#validacionesTbl').bootstrapTable('hideColumn', 'Actions');

    };

    function MapInputToObject() {

        setupData.Reglas = $('#validacionesTbl').bootstrapTable('getData');

        return setupData;
    };

    function MapObjectToInput(data) {
        $('#alias').val(data.alias);
        if (data.validaciones != null)
            $('#validacionesTbl').bootstrapTable('load', data.validaciones);
        else
            $('#validacionesTbl').bootstrapTable('load', {});

    };

    function Controls_setup() {

    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#VisualizationsEdtForm :input").change(function () {
            data_changed();
        });


        $('#VisualizationsEdtFormSave').click(function () {

            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                let alias = $('#alias').val();

                app.ui.ButtonDoing('#VisualizationsEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/TronCommon/Producto?alias=' + alias,
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        alert();

                    }).always(function () {
                        app.ui.ButtonDone('#VisualizationsEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#VisualizationsEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#VisualizationsEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#VisualizationsEdtFormCancel'); }, 3000);
            event.preventDefault();
        });


        $("#alias").change(function () {
            let alias = $('#alias').val();
            app.core.Get(app.setting.apipath + 'v1/TronCommon/Producto?alias=' + alias)
                .done(function (data) {
                    setupData = data;
                    if (data.Reglas != null)
                        $('#validacionesTbl').bootstrapTable('load', data.Reglas);
                    else
                        $('#validacionesTbl').bootstrapTable('load', {});
                });
        });

        $("#Variable").bind("dblclick", function () {
            $('#Condicion').val($('#Condicion').val() + ' ' + $("#Variable").val() + ' ');
        });

    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#VisualizationsEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                alias: { required: true },
            },
            messages: {
                alias: { required: 'Debe indicar el Alias' },
            }
        });
    };

    function validaciones_table_setup() {

        $('#validacionesTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'Condicion',
                    title: 'Condición',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'Mensaje',
                    title: 'Mensaje',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'Campo',
                    title: 'Campo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'Descripcion',
                    title: 'Descripción',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'Actions',
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un visualizations',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    visible: true,
                    events: 'validacionesTbl_Events',
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

        $('#validacionesNew').click(function () {
            validaciones_table_row_edit();
        });

        $('#validacionesEdtFormSave').click(function () {
            if (app.ui.IsValid('#validacionesEdtForm', false)) {
                app.ui.ButtonDoing('#validacionesEdtFormSave');

                var row = validaciones_table_row('values');

                if (row.Id === null)
                    row.Id = 1;

                if ($('#validacionesModal').data('id') != null) {
                    $('#validacionesTbl').bootstrapTable('updateByUniqueId', { id: row.Id, row: row });
                }
                else {
                    $('#validacionesTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#validacionesEdtFormSave')
                $('#validacionesModal').modal('hide');
            }
        });

    };

    function validaciones_table_row(mode) {
        if (mode == null) {
            return {
                Id: null,
                Condicion: null,
                Mensaje: null,
                Campo: null,
                Descripcion: null
            };
        }
        else {
            return {
                Id: $('#validacionesModal').data('id'),
                Condicion: $('#Condicion').val(),
                Mensaje: $('#Mensaje').val(),
                Campo: $('#Campo').val(),
                Descripcion: $('#Descripcion').val()
            };
        }
    };

    function validaciones_table_row_edit(row) {
        var md = $('#validacionesModal').modal({ show: false });
        var formInstance = $("#validacionesEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || validaciones_table_row();
        md.data('id', row.Id);

        $('#Condicion').val(row.Condicion);
        $('#Mensaje').val(row.Mensaje);
        $('#Campo').val(row.Campo);
        $('#Descripcion').val(row.Descripcion);


        md.modal('show');
    };

    function validaciones_table_row_delete(row) {
        $('#validacionesTbl').bootstrapTable('removeByUniqueId', row.Id);
    };

    function validaciones_table_Validations() {
        app.ui.DateValidators();
        $("#validacionesEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                Condicion: { required: true },
                Mensaje: { required: true },
                Campo: { required: true },
                Descripcion: { required: true },
            },
            messages: {
                Condicion: { required: 'Debe indicar el Condición' },
                Mensaje: { required: 'Debe indicar el Mensaje' },
                Campo: { required: 'Debe indicar el Campo' },
                Descripcion: { required: 'Debe indicar el Descripción' },
            }
        });
    };



    return {
        Init: function () {
            try {
                Controls_setup();
                Setup_Validations();
                validaciones_table_setup();
                validaciones_table_Validations();

                Controls_Events();
                Setup();
                console.log("Inicio");
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Data: function () {
            return MapInputToObject();
        },
        Changed: function (callback) {
            changedCallback = callback;
        },
        IsValid: function (showResume) {
            return app.ui.IsValid('#VisualizationsEdtForm', false, showResume);
        },
        validacionesEditRow: function (row) {
            validaciones_table_row_edit(row);
        },
        validacionesDeleteRow: function (row) {
            validaciones_table_row_delete(row);
        }
    };
})();

window.validacionesTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.Id + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PrototypeProducto.validacionesDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PrototypeProducto.validacionesEditRow(row);
        e.stopPropagation();
    }
};

