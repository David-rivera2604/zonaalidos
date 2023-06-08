var app = app || {};

app.PurdyPanelIndemnizacion = (function () {

    let _asiges = null;
    let _eventCallback = null;
    let _data = null;
    let _loadready = false;
    let _changed = false;

    let _emptyValue = {
        ID: null,
        MONTOINICIALPORINDEMNIZAR: null,
        MONTOINICIALPORINDEMNIZARREPUE: null,
        MONTOINICIALPORINDEMNIZARMANOD: null,
        MONTODANOOCULTOPORINDEMNIZAR: null,
        MONTODANOOCULTOPORINDEMNIZARRE: null,
        MONTODANOOCULTOPORINDEMNIZARMA: null
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
    };

    function data_changed() {

        //if (ctrol.presentadanooculto === Si)
        //    $('.montoDanoOcultoporIndemnizarVisible').removeClass('d-none');
        //else
        //    $('.montoDanoOcultoporIndemnizarVisible').addClass('d-none');
        //if (ctrol.presentadanooculto === Si)
        //    $('.montoDanoOcultoporIndemnizarRepuestosVisible').removeClass('d-none');
        //else
        //    $('.montoDanoOcultoporIndemnizarRepuestosVisible').addClass('d-none');
        //if (ctrol.presentadanooculto === Si)
        //    $('.montoDanoOcultoporIndemnizarManodeObraVisible').removeClass('d-none');
        //else
        //    $('.montoDanoOcultoporIndemnizarManodeObraVisible').addClass('d-none');
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#PurdyPanelIndemnizacionEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
            },
            messages: {
            }
        });
    };

    function GetMovimientosDeMontos(asigesCode) {
        _asiges = asigesCode;
        app.core.Get(`https://localhost:7262/api/entity/PurdyPanelMontos/asiges?code=${asigesCode}`)
            .done(function (dataMontos) {
                if (dataMontos?.Sucessfully) {
                    $('#movimientosdemontosTbl').bootstrapTable('load', dataMontos.Data == null ? [] : dataMontos.Data);
                    _data = dataMontos.Data;
                    _eventCallback('MontosDataChange', dataMontos.Data);
                }
            });
    };

    function GetBalance(asigesCode) {
        _asiges = asigesCode;
        app.core.Get(`https://localhost:7262/api/entity/PurdyPanelBalance/asiges?code=${asigesCode}`)
            .done(function (dataBalance) {
                if (dataBalance?.Sucessfully) {
                    if (dataBalance.Data != null) {
                        dataBalance.Data.forEach(function (item) {
                            item.TIPODEDOCUMENTODESC = $(`#tipodedocumento option[value=${item.TIPODEDOCUMENTO}]`).text();
                        });
                    }
                    $('#balanceTbl').bootstrapTable('load', dataBalance.Data == null ? [] : dataBalance.Data);
                    _data = dataBalance.Data;
                    _eventCallback('BalanceDataChange', dataBalance.Data);
                }
            });
    };

    function movimientosdemontos_table_setup() {

        $('#movimientosdemontosTbl').bootstrapTable({
            uniqueId: 'ID',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'MONTOINICIALPORINDEMNIZAR',
                    title: 'Monto Inicial por Indemnizar',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'MONTOINICIALPORINDEMNIZARREPUE',
                    title: 'Monto Inicial por Indemnizar (Repuestos)',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'MONTOINICIALPORINDEMNIZARMANOD',
                    title: 'Monto Inicial por Indemnizar (Mano de Obra)',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'MONTODANOOCULTOPORINDEMNIZAR',
                    title: 'Monto Daño Oculto por Indemnizar',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'MONTODANOOCULTOPORINDEMNIZARRE',
                    title: 'Monto Daño Oculto por Indemnizar (Repuestos)',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'MONTODANOOCULTOPORINDEMNIZARMA',
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
                row.ASIGES = _asiges;
                if (row.ID === null) {
                    app.core.Post(`https://localhost:7262/api/entity/PurdyPanelMontos`, JSON.stringify(row))
                        .done(function (created) {
                            if (created?.Sucessfully) {
                                _loadready = true;
                                _changed = false;
                                $('#movimientosdemontosModal').modal('hide');
                                GetMovimientosDeMontos(_asiges);
                                toastr.success('El movimiento de montos, fue creada de forma exitosa', '', { timeOut: 5000, closeButton: true, progressBar: true });
                                
                            }
                            else {
                                console.error(created);
                            }

                        }).always(function () {
                            app.ui.ButtonDone('#movimientosdemontosEdtFormSave');
                        });
                } else {
                    app.core.Put(`https://localhost:7262/api/entity/PurdyPanelMontos/${row.ID}`, JSON.stringify(row))
                        .done(function (updated) {
                            if (updated?.Sucessfully) {
                                _loadready = true;
                                _changed = false;
                                $('#movimientosdemontosModal').modal('hide');
                                GetMovimientosDeMontos(_asiges);
                                toastr.success('El movimiento de montos, fue actualizado de forma exitosa', '', { timeOut: 5000, closeButton: true, progressBar: true });
                                
                            }
                            else {
                                console.error(updated);
                            }

                        }).always(function () {
                            app.ui.ButtonDone('#movimientosdemontosEdtFormSave');
                        });
                }
            }
        });
    };

    function movimientosdemontos_table_row(mode) {
        if (mode == null) {
            return _emptyValue;
        }
        else {
            return {
                ID: $('#movimientosdemontosModal').data('id'),
                MONTOINICIALPORINDEMNIZAR: app.ui.GetNumericValue('#montoInicialporIndemnizar'),
                MONTOINICIALPORINDEMNIZARREPUE: app.ui.GetNumericValue('#montoInicialporIndemnizarRepuestos'),
                MONTOINICIALPORINDEMNIZARMANOD: app.ui.GetNumericValue('#montoInicialporIndemnizarManodeObra'),
                MONTODANOOCULTOPORINDEMNIZAR: app.ui.GetNumericValue('#montoDanoOcultoporIndemnizar'),
                MONTODANOOCULTOPORINDEMNIZARRE: app.ui.GetNumericValue('#montoDanoOcultoporIndemnizarRepuestos'),
                MONTODANOOCULTOPORINDEMNIZARMA: app.ui.GetNumericValue('#montoDanoOcultoporIndemnizarManodeObra')
            };
        }
    };

    function movimientosdemontos_table_row_edit(row) {
        var md = $('#movimientosdemontosModal').modal({ show: false });
        var formInstance = $("#movimientosdemontosEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || movimientosdemontos_table_row();
        md.data('id', row.ID);

        app.ui.SetNumericValue('#montoInicialporIndemnizar', row.MONTOINICIALPORINDEMNIZAR);
        app.ui.SetNumericValue('#montoInicialporIndemnizarRepuestos', row.MONTOINICIALPORINDEMNIZARREPUE);
        app.ui.SetNumericValue('#montoInicialporIndemnizarManodeObra', row.MONTOINICIALPORINDEMNIZARMANOD);
        app.ui.SetNumericValue('#montoDanoOcultoporIndemnizar', row.MONTODANOOCULTOPORINDEMNIZAR);
        app.ui.SetNumericValue('#montoDanoOcultoporIndemnizarRepuestos', row.MONTODANOOCULTOPORINDEMNIZARRE);
        app.ui.SetNumericValue('#montoDanoOcultoporIndemnizarManodeObra', row.MONTODANOOCULTOPORINDEMNIZARMA);


        md.modal('show');
    };

    function movimientosdemontos_table_row_delete(row) {
        app.core.Delete(`https://localhost:7262/api/entity/PurdyPanelMontos/${row.ID}`, null)
            .done(function (deleted) {
                if (deleted?.Sucessfully) {
                    GetMovimientosDeMontos(_asiges);
                    toastr.success('El movimiento de montos, fue eliminado de forma exitosa', '', { timeOut: 5000, closeButton: true, progressBar: true });                    
                }
                else {
                    console.error(deleted);
                }
            });
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
            uniqueId: 'ID',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'NUMERODESINIESTRO',
                    title: 'Número de Siniestro',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'TIPODEDOCUMENTODESC',
                    title: 'Tipo de documento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'NUMERODEDOCUMENTO',
                    title: 'Número de documento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'FECHA',
                    title: 'Fecha',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'RECEPTOR',
                    title: 'Receptor',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'MONTO',
                    title: 'Monto',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'NCREPUESTO',
                    title: 'NC Repuesto',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'OBSERVACION',
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
                row.ASIGES = _asiges;
                if (row.ID === null) {
                    app.core.Post(`https://localhost:7262/api/entity/PurdyPanelBalance`, JSON.stringify(row))
                        .done(function (created) {
                            if (created?.Sucessfully) {
                                $('#balanceModal').modal('hide');
                                GetBalance(_asiges);
                                toastr.success('El movimiento de montos, fue creada de forma exitosa', '', { timeOut: 5000, closeButton: true, progressBar: true });
                            }
                            else {
                                console.error(created);
                            }

                        }).always(function () {
                            app.ui.ButtonDone('#balanceEdtFormSave');
                        });
                } else {
                    app.core.Put(`https://localhost:7262/api/entity/PurdyPanelBalance/${row.ID}`, JSON.stringify(row))
                        .done(function (updated) {
                            if (updated?.Sucessfully) {
                                $('#balanceModal').modal('hide');
                                GetBalance(_asiges);
                                toastr.success('El movimiento de montos, fue actualizado de forma exitosa', '', { timeOut: 5000, closeButton: true, progressBar: true });
                            }
                            else {
                                console.error(updated);
                            }
                        }).always(function () {
                            app.ui.ButtonDone('#balanceEdtFormSave');
                        });
                }
            }
        });
    };

    function balance_table_row(mode) {
        if (mode == null) {
            return {
                ID: null,
                NUMERODESINIESTRO: null,
                TIPODEDOCUMENTO: null,
                NUMERODEDOCUMENTO: null,
                FECHA: null,
                RECEPTOR: null,
                MONTO: null,
                NCREPUESTO: null,
                OBSERVACION: null
            };
        }
        else {
            return {
                ID: $('#balanceModal').data('id'),
                NUMERODESINIESTRO: $('#numerodeSiniestro').val(),
                TIPODEDOCUMENTO: $('#tipodedocumento').val(),
                NUMERODEDOCUMENTO: $('#numerodedocumento').val(),
                FECHA: app.ui.GetDateValue('#fecha'),
                RECEPTOR: $('#receptor').val(),
                MONTO: app.ui.GetNumericValue('#monto'),
                NCREPUESTO: app.ui.GetNumericValue('#nCRepuesto'),
                OBSERVACION: $('#observacion').val()
            };
        }
    };

    function balance_table_row_edit(row) {
        var md = $('#balanceModal').modal({ show: false });
        var formInstance = $("#balanceEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || balance_table_row();
        md.data('id', row.ID);

        $('#numerodeSiniestro').val(row.NUMERODESINIESTRO);
        $('#tipodedocumento').val(row.TIPODEDOCUMENTO);
        $('#numerodedocumento').val(row.NUMERODEDOCUMENTO);
        app.ui.SetDateValue('#fecha', row.FECHA);
        $('#receptor').val(row.RECEPTOR);
        app.ui.SetNumericValue('#monto', row.MONTO);
        app.ui.SetNumericValue('#nCRepuesto', row.NCREPUESTO);
        $('#observacion').val(row.OBSERVACION);


        md.modal('show');
    };

    function balance_table_row_delete(row) {
        app.core.Delete(`https://localhost:7262/api/entity/PurdyPanelBalance/${row.ID}`, null)
            .done(function (deleted) {
                if (deleted?.Sucessfully) {
                    GetBalance(_asiges);
                    toastr.success('El movimiento de balance, fue eliminado de forma exitosa', '', { timeOut: 5000, closeButton: true, progressBar: true });
                }
                else {
                    console.error(deleted);
                }
            });
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

                $('#movimientosdemontosTbl').bootstrapTable('load', {});
                $('#balanceTbl').bootstrapTable('load', {});
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Event: function (src, data) {
            switch (src) {
                case 'ASIGESChange':
                    GetMovimientosDeMontos(data.asiges);
                    GetBalance(data.asiges);
                    break;
                case 'DanosDataChange':
                    app.ui.VisibleBehaviour('.DanoOculto', data.damage.PRESENTADANOOCULTO == 1);

                    _emptyValue.MONTOINICIALPORINDEMNIZAR = data.damage.PERDIDA;
                    _emptyValue.MONTOINICIALPORINDEMNIZARREPUE = data.damage.PERDREPUESTOTOTAL;
                    _emptyValue.MONTOINICIALPORINDEMNIZARMANOD = data.damage.PERDMANOTOTAL;

                    _emptyValue.MONTODANOOCULTOPORINDEMNIZAR = data.damage.OTROSIIOTROSIIDANOCULMANOTOTAL;
                    _emptyValue.MONTODANOOCULTOPORINDEMNIZARRE = data.damage.DANOOCULTOTOTAL;
                    _emptyValue.MONTODANOOCULTOPORINDEMNIZARMA = data.damage.DANOOCULTOMANOTOTAL;

                    break;
            }
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
        toastr.warning("Si está seguro de querer eliminar el movimiento de saldo '" + row.ID + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PurdyPanelIndemnizacion.movimientosdemontosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PurdyPanelIndemnizacion.movimientosdemontosEditRow(row);
        e.stopPropagation();
    }
};
window.balanceTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el movimiento de balance '" + row.ID + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PurdyPanelIndemnizacion.balanceDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PurdyPanelIndemnizacion.balanceEditRow(row);
        e.stopPropagation();
    }
};

