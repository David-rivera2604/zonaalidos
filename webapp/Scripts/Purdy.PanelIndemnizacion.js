var app = app || {};

app.PurdyPanelIndemnizacion = (function () {

    let _eventCallback = null;
    var setupData = null;
    var changedCallback = null;

    function Setup() {

        app.core.Get(app.setting.apipath + 'v1/Quote/PanelIndemnizacionSetup', null,
            function (data) {
                app.core.Lookups([],
                    function () {
                        setupData = data;
                        MapObjectToInput(data);
                    }, ``);

            });
    };

    function ReadOnly() {
        $('#aSIGES').replaceWith('<div>' + $('#aSIGES').val() + '</div>');
        $('#movimientosdemontosNew').addClass('d-none');
        $('#movimientosdemontosTbl').bootstrapTable('hideColumn', 'Actions');
        $('#balanceNew').addClass('d-none');
        $('#balanceTbl').bootstrapTable('hideColumn', 'Actions');

    };

    function MapInputToObject() {
        var data = {
            aSIGES: $('#aSIGES').val(),
            movimientosdemontos: $('#movimientosdemontosTbl').bootstrapTable('getData'),
            balance: $('#balanceTbl').bootstrapTable('getData'),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#aSIGES').val(data.aSIGES);
        if (data.movimientosdemontos != null)
            $('#movimientosdemontosTbl').bootstrapTable('load', data.movimientosdemontos);
        else
            $('#movimientosdemontosTbl').bootstrapTable('load', {});
        if (data.balance != null)
            $('#balanceTbl').bootstrapTable('load', data.balance);
        else
            $('#balanceTbl').bootstrapTable('load', {});

    };

    function Controls_setup() {
        new AutoNumeric('#montoInicialporIndemnizar', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoInicialporIndemnizarRepuestos', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoInicialporIndemnizarManodeObra', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoDanoOcultoporIndemnizar', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoDanoOcultoporIndemnizarRepuestos', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoDanoOcultoporIndemnizarManodeObra', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#fecha_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#monto', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#nCRepuesto', {
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
        $("#PurdyPanelIndemnizacionEdtForm :input").change(function () {
            data_changed();
        });


        $('#PurdyPanelIndemnizacionEdtFormSave').click(function () {

            if (app.ui.IsValid('#PurdyPanelIndemnizacionEdtForm', false)) {
                app.ui.ButtonDoing('#PurdyPanelIndemnizacionEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/Purdy/PanelIndemnizacion',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {

                        }

                    }).always(function () {
                        app.ui.ButtonDone('#PurdyPanelIndemnizacionEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#PurdyPanelIndemnizacionEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#PurdyPanelIndemnizacionEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PurdyPanelIndemnizacionEdtFormCancel'); }, 3000);
            event.preventDefault();
        });

    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
        if (ctrol.presentadanooculto === 'Si')
            $('.montoDanoOcultoporIndemnizarVisible').removeClass('d-none');
        else
            $('.montoDanoOcultoporIndemnizarVisible').addClass('d-none');
        if (ctrol.presentadanooculto === 'Si')
            $('.montoDanoOcultoporIndemnizarRepuestosVisible').removeClass('d-none');
        else
            $('.montoDanoOcultoporIndemnizarRepuestosVisible').addClass('d-none');
        if (ctrol.presentadanooculto === 'Si')
            $('.montoDanoOcultoporIndemnizarManodeObraVisible').removeClass('d-none');
        else
            $('.montoDanoOcultoporIndemnizarManodeObraVisible').addClass('d-none');
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#PurdyPanelIndemnizacionEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                aSIGES: { required: true },
            },
            messages: {
                aSIGES: { required: 'Debe indicar el asiges' },
            }
        });
    };

    function movimientosdemontos_table_setup() {

        $('#movimientosdemontosTbl').bootstrapTable({
            uniqueId: 'movimientosdemontosId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'montoInicialporIndemnizar',
                    title: 'Monto Inicial por Indemnizar',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'montoInicialporIndemnizarRepuestos',
                    title: 'Monto Inicial por Indemnizar (Repuestos)',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'montoInicialporIndemnizarManodeObra',
                    title: 'Monto Inicial por Indemnizar (Mano de Obra)',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'montoDanoOcultoporIndemnizar',
                    title: 'Monto Daño Oculto por Indemnizar',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'montoDanoOcultoporIndemnizarRepuestos',
                    title: 'Monto Daño Oculto por Indemnizar (Repuestos)',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'montoDanoOcultoporIndemnizarManodeObra',
                    title: 'Monto Daño Oculto por Indemnizar (Mano de Obra)',
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
                    events: 'movimientosdemontosTbl_Events',
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

        $('#movimientosdemontosNew').click(function () {
            movimientosdemontos_table_row_edit();
        });

        $('#movimientosdemontosEdtFormSave').click(function () {
            if (app.ui.IsValid('#movimientosdemontosEdtForm', false)) {
                app.ui.ButtonDoing('#movimientosdemontosEdtFormSave');

                var row = movimientosdemontos_table_row('values');

                if (row.movimientosdemontosId === null)
                    row.movimientosdemontosId = 1;

                if ($('#movimientosdemontosModal').data('id') != null) {
                    $('#movimientosdemontosTbl').bootstrapTable('updateByUniqueId', { id: row.movimientosdemontosId, row: row });
                }
                else {
                    $('#movimientosdemontosTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#movimientosdemontosEdtFormSave')
                $('#movimientosdemontosModal').modal('hide');
            }
        });

    };

    function movimientosdemontos_table_row(mode) {
        if (mode == null) {
            return {
                movimientosdemontosId: null,
                montoInicialporIndemnizar: null,
                montoInicialporIndemnizarRepuestos: null,
                montoInicialporIndemnizarManodeObra: null,
                montoDanoOcultoporIndemnizar: null,
                montoDanoOcultoporIndemnizarRepuestos: null,
                montoDanoOcultoporIndemnizarManodeObra: null
            };
        }
        else {
            return {
                movimientosdemontosId: $('#movimientosdemontosModal').data('id'),
                montoInicialporIndemnizar: app.ui.GetNumericValue('#montoInicialporIndemnizar'),
                montoInicialporIndemnizarRepuestos: app.ui.GetNumericValue('#montoInicialporIndemnizarRepuestos'),
                montoInicialporIndemnizarManodeObra: app.ui.GetNumericValue('#montoInicialporIndemnizarManodeObra'),
                montoDanoOcultoporIndemnizar: app.ui.GetNumericValue('#montoDanoOcultoporIndemnizar'),
                montoDanoOcultoporIndemnizarRepuestos: app.ui.GetNumericValue('#montoDanoOcultoporIndemnizarRepuestos'),
                montoDanoOcultoporIndemnizarManodeObra: app.ui.GetNumericValue('#montoDanoOcultoporIndemnizarManodeObra')
            };
        }
    };

    function movimientosdemontos_table_row_edit(row) {
        var md = $('#movimientosdemontosModal').modal({ show: false });
        var formInstance = $("#movimientosdemontosEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || movimientosdemontos_table_row();
        md.data('id', row.movimientosdemontosId);

        app.ui.SetNumericValue('#montoInicialporIndemnizar', row.montoInicialporIndemnizar);
        app.ui.SetNumericValue('#montoInicialporIndemnizarRepuestos', row.montoInicialporIndemnizarRepuestos);
        app.ui.SetNumericValue('#montoInicialporIndemnizarManodeObra', row.montoInicialporIndemnizarManodeObra);
        app.ui.SetNumericValue('#montoDanoOcultoporIndemnizar', row.montoDanoOcultoporIndemnizar);
        app.ui.SetNumericValue('#montoDanoOcultoporIndemnizarRepuestos', row.montoDanoOcultoporIndemnizarRepuestos);
        app.ui.SetNumericValue('#montoDanoOcultoporIndemnizarManodeObra', row.montoDanoOcultoporIndemnizarManodeObra);


        md.modal('show');
    };

    function movimientosdemontos_table_row_delete(row) {
        $('#movimientosdemontosTbl').bootstrapTable('removeByUniqueId', row.movimientosdemontosId);
    };

    function movimientosdemontos_table_Validations() {
        app.ui.DateValidators();
        $("#movimientosdemontosEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {},
            messages: {}
        });
    };

    function balance_table_setup() {

        $('#balanceTbl').bootstrapTable({
            uniqueId: 'balanceId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'numerodeSiniestro',
                    title: 'Número de Siniestro',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'tipodedocumento',
                    title: 'Tipo de documento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'numerodedocumento',
                    title: 'Número de documento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'fecha',
                    title: 'Fecha',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'receptor',
                    title: 'Receptor',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'monto',
                    title: 'Monto',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'nCRepuesto',
                    title: 'NC Repuesto',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'observacion',
                    title: 'Observación',
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
                    events: 'balanceTbl_Events',
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

        $('#balanceNew').click(function () {
            balance_table_row_edit();
        });

        $('#balanceEdtFormSave').click(function () {
            if (app.ui.IsValid('#balanceEdtForm', false)) {
                app.ui.ButtonDoing('#balanceEdtFormSave');

                var row = balance_table_row('values');

                if (row.balanceId === null)
                    row.balanceId = 1;

                if ($('#balanceModal').data('id') != null) {
                    $('#balanceTbl').bootstrapTable('updateByUniqueId', { id: row.balanceId, row: row });
                }
                else {
                    $('#balanceTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#balanceEdtFormSave')
                $('#balanceModal').modal('hide');
            }
        });

    };

    function balance_table_row(mode) {
        if (mode == null) {
            return {
                balanceId: null,
                numerodeSiniestro: null,
                tipodedocumento: null,
                numerodedocumento: null,
                fecha: null,
                receptor: null,
                monto: null,
                nCRepuesto: null,
                observacion: null
            };
        }
        else {
            return {
                balanceId: $('#balanceModal').data('id'),
                numerodeSiniestro: $('#numerodeSiniestro').val(),
                tipodedocumento: $('#tipodedocumento').val(),
                numerodedocumento: $('#numerodedocumento').val(),
                fecha: app.ui.GetDateValue('#fecha'),
                receptor: $('#receptor').val(),
                monto: app.ui.GetNumericValue('#monto'),
                nCRepuesto: app.ui.GetNumericValue('#nCRepuesto'),
                observacion: $('#observacion').val()
            };
        }
    };

    function balance_table_row_edit(row) {
        var md = $('#balanceModal').modal({ show: false });
        var formInstance = $("#balanceEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || balance_table_row();
        md.data('id', row.balanceId);

        $('#numerodeSiniestro').val(row.numerodeSiniestro);
        $('#tipodedocumento').val(row.tipodedocumento);
        $('#numerodedocumento').val(row.numerodedocumento);
        app.ui.SetDateValue('#fecha', row.fecha);
        $('#receptor').val(row.receptor);
        app.ui.SetNumericValue('#monto', row.monto);
        app.ui.SetNumericValue('#nCRepuesto', row.nCRepuesto);
        $('#observacion').val(row.observacion);


        md.modal('show');
    };

    function balance_table_row_delete(row) {
        $('#balanceTbl').bootstrapTable('removeByUniqueId', row.balanceId);
    };

    function balance_table_Validations() {
        app.ui.DateValidators();
        $("#balanceEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {},
            messages: {}
        });
    };



    return {
        Init: function (eventCallback) {
            try {
                _eventCallback = eventCallback;
                Controls_setup();
                Setup_Validations();
                movimientosdemontos_table_setup();
                movimientosdemontos_table_Validations();
                balance_table_setup();
                balance_table_Validations();

                Controls_Events();
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Event: function (src, data) {
        },
        movimientosdemontosEditRow: function (row) {
            movimientosdemontos_table_row_edit(row);
        },
        movimientosdemontosDeleteRow: function (row) {
            movimientosdemontos_table_row_delete(row);
        },
        balanceEditRow: function (row) {
            balance_table_row_edit(row);
        },
        balanceDeleteRow: function (row) {
            balance_table_row_delete(row);
        }
    };
})();

window.movimientosdemontosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.movimientosdemontosId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PanelIndemnizacion.movimientosdemontosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PanelIndemnizacion.movimientosdemontosEditRow(row);
        e.stopPropagation();
    }
};
window.balanceTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.balanceId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PanelIndemnizacion.balanceDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PanelIndemnizacion.balanceEditRow(row);
        e.stopPropagation();
    }
};

