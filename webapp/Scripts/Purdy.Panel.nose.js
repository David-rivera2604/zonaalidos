var app = app || {};

app.PurdyPanelnose = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {

        //app.core.Get(app.setting.apipath + 'v1/Quote/noseSetup', null,
        //    function (data) {
        //        app.core.Lookups([],
        //            function () {
        //                setupData = data;
        //                MapObjectToInput(data);
        //            }, ``);

        //    });
    };

    function ReadOnly() {
        $('#aSIGES').replaceWith('<div>' + $('#aSIGES').val() + '</div>');
        $('#tB5noset8noseNew').addClass('d-none');
        $('#tB5noset8noseTbl').bootstrapTable('hideColumn', 'Actions');

    };

    function MapInputToObject() {
        var data = {
            aSIGES: $('#aSIGES').val(),
            tB5noset8nose: $('#tB5noset8noseTbl').bootstrapTable('getData'),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#aSIGES').val(data.aSIGES);
        if (data.tB5noset8nose != null)
            $('#tB5noset8noseTbl').bootstrapTable('load', data.tB5noset8nose);
        else
            $('#tB5noset8noseTbl').bootstrapTable('load', {});

    };

    function Controls_setup() {
        new AutoNumeric('#montopagado', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoRecuperado', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoutilizado', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });

    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#PanelPurdynoseEdtForm :input").change(function () {
            data_changed();
        });


        $('#PanelPurdynoseEdtFormSave').click(function () {

            if (app.ui.IsValid('#PanelPurdynoseEdtForm', false)) {
                app.ui.ButtonDoing('#PanelPurdynoseEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/PanelPurdy/nose',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {

                        }

                    }).always(function () {
                        app.ui.ButtonDone('#PanelPurdynoseEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#PanelPurdynoseEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#PanelPurdynoseEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PanelPurdynoseEdtFormCancel'); }, 3000);
            event.preventDefault();
        });

    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#PanelPurdynoseEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                aSIGES: { required: true },
            },
            messages: {
                aSIGES: { required: 'Debe indicar el asiges' },
            }
        });
    };

    function tB5noset8nose_table_setup() {

        $('#tB5noset8noseTbl').bootstrapTable({
            uniqueId: 'tB5noset8noseId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'montopagado',
                    title: 'Monto pagado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'montoRecuperado',
                    title: 'Monto Recuperado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'montoutilizado',
                    title: 'Monto utilizado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
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
                    events: 'tB5noset8noseTbl_Events',
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

        $('#tB5noset8noseNew').click(function () {
            tB5noset8nose_table_row_edit();
        });

        $('#tB5noset8noseEdtFormSave').click(function () {
            if (app.ui.IsValid('#tB5noset8noseEdtForm', false)) {
                app.ui.ButtonDoing('#tB5noset8noseEdtFormSave');

                var row = tB5noset8nose_table_row('values');

                if (row.tB5noset8noseId === null)
                    row.tB5noset8noseId = 1;

                if ($('#tB5noset8noseModal').data('id') != null) {
                    $('#tB5noset8noseTbl').bootstrapTable('updateByUniqueId', { id: row.tB5noset8noseId, row: row });
                }
                else {
                    $('#tB5noset8noseTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#tB5noset8noseEdtFormSave')
                $('#tB5noset8noseModal').modal('hide');
            }
        });

    };

    function tB5noset8nose_table_row(mode) {
        if (mode == null) {
            return {
                tB5noset8noseId: null,
                montopagado: null,
                montoRecuperado: null,
                montoutilizado: null
            };
        }
        else {
            return {
                tB5noset8noseId: $('#tB5noset8noseModal').data('id'),
                montopagado: app.ui.GetNumericValue('#montopagado'),
                montoRecuperado: app.ui.GetNumericValue('#montoRecuperado'),
                montoutilizado: app.ui.GetNumericValue('#montoutilizado')
            };
        }
    };

    function tB5noset8nose_table_row_edit(row) {
        var md = $('#tB5noset8noseModal').modal({ show: false });
        var formInstance = $("#tB5noset8noseEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || tB5noset8nose_table_row();
        md.data('id', row.tB5noset8noseId);

        app.ui.SetNumericValue('#montopagado', row.montopagado);
        app.ui.SetNumericValue('#montoRecuperado', row.montoRecuperado);
        app.ui.SetNumericValue('#montoutilizado', row.montoutilizado);


        md.modal('show');
    };

    function tB5noset8nose_table_row_delete(row) {
        $('#tB5noset8noseTbl').bootstrapTable('removeByUniqueId', row.tB5noset8noseId);
    };

    function tB5noset8nose_table_Validations() {
        app.ui.DateValidators();
        $("#tB5noset8noseEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {},
            messages: {}
        });
    };



    return {
        Init: function () {
            try {
                Controls_setup();
                Setup_Validations();
                tB5noset8nose_table_setup();
                tB5noset8nose_table_Validations();

                Controls_Events();
                Setup();
                //Custom.Extend
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
        SetData: function (data) {
            MapObjectToInput(data);
        },
        Changed: function (callback) {
            changedCallback = callback;
        },
        IsValid: function (showResume) {
            return app.ui.IsValid('#PanelPurdynoseEdtForm', false, showResume);
        },
        tB5noset8noseEditRow: function (row) {
            tB5noset8nose_table_row_edit(row);
        },
        tB5noset8noseDeleteRow: function (row) {
            tB5noset8nose_table_row_delete(row);
        }
    };
})();

window.tB5noset8noseTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.tB5noset8noseId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PurdyPanelnose.tB5noset8noseDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PurdyPanelnose.tB5noset8noseEditRow(row);
        e.stopPropagation();
    }
};

