var app = app || {};

app.PurdyPanelIndemnizacion = (function () {

    let _asiges = null;
    let _eventCallback = null;
    let _data = null;
    let _loadready = false;
    let _changed = false;
    let _deducible = 0;

    let _emptyValueBalance = {
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
    let _emptyValueMontos = {
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
        $("#monto, #tipodedocumento").change(function () {
            let monto = 0;
            let factor = 0.0;
            if (app.ui.GetDropDownNumericValue('#tipodedocumento') === 2) {
                let taller = _data.damage.TALLER;
                let marca = _data.policy.data.find(i => i.COD_CAMPO === "COD_MARCA")?.TXT_CAMPO;
                if (taller === 1 && (marca === 'FORD' || marca === 'VOLKSWAGEN'))
                    factor = 0.10;
                if (taller == 1 && (marca != 'FORD' && marca != 'VOLKSWAGEN'))
                    factor = 0.15;
                if (taller != 1 && (marca === 'FORD' || marca === 'VOLKSWAGEN'))
                    factor = 0.15;
                if (taller != 1 && (marca != 'FORD' && marca != 'VOLKSWAGEN'))
                    factor = 0.20;
                monto = app.ui.GetNumericValue('#monto');
            }
            app.ui.SetNumericValue('#nCRepuesto', monto * factor);
        });

    };

    async function GetMovimientosDeMontos(asigesCode) {
        _asiges = asigesCode;
        app.core.Get(`${app.setting.entityapi}/PurdyPanelMontos/asiges?code=${asigesCode}`)
            .done(function (dataMontos) {
                if (dataMontos?.Sucessfully) {
                    $('#movimientosdemontosTbl').bootstrapTable('load', dataMontos.Data == null ? [] : dataMontos.Data);
                    _eventCallback('MontosDataChange', dataMontos.Data);
                }
            });
    };

    async function GetBalance(asigesCode) {
        _asiges = asigesCode;
        app.core.Get(`${app.setting.entityapi}/PurdyPanelBalance/asiges?code=${asigesCode}`)
            .done(function (dataBalance) {
                if (dataBalance?.Sucessfully) {
                    let balance = _claim
                    if (dataBalance.Data != null) {
                        dataBalance.Data.forEach(function (item) {
                            item.TIPODEDOCUMENTODESC = $(`#tipodedocumento option[value=${item.TIPODEDOCUMENTO}]`).text();
                        });
                    }
                    $('#balanceTbl').bootstrapTable('load', dataBalance.Data == null ? [] : dataBalance.Data);
                    _eventCallback('BalanceDataChange', dataBalance.Data);
                    CalcBalance();
                }
            });
    };

    async function movimientosdemontos_table_setup() {

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
                        let deleteBtn = '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del visualizations de la fila"> <i class="fa fa-close"></i> </button>';

                        if (!localStorage.getItem('Roles').includes('Administrativo')) {
                            deleteBtn = '';
                        }
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del visualizations de la fila"> <i class="fa fa-pencil"></i> </button>' + deleteBtn;
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
                    app.core.Post(`${app.setting.entityapi}/PurdyPanelMontos`, JSON.stringify(row))
                        .done(function (created) {
                            if (created?.Sucessfully) {
                                _loadready = true;
                                _changed = false;
                                $('#movimientosdemontosModal').modal('hide');
                                GetMovimientosDeMontos(_asiges);
                                app.ui.Success('El movimiento de montos, fue creada de forma exitosa');

                            }
                            else {
                                console.error(created);
                            }

                        }).always(function () {
                            app.ui.ButtonDone('#movimientosdemontosEdtFormSave');
                        });
                } else {
                    app.core.Put(`${app.setting.entityapi}/PurdyPanelMontos/${row.ID}`, JSON.stringify(row))
                        .done(function (updated) {
                            if (updated?.Sucessfully) {
                                _loadready = true;
                                _changed = false;
                                $('#movimientosdemontosModal').modal('hide');
                                GetMovimientosDeMontos(_asiges);
                                app.ui.Success('El movimiento de montos, fue actualizado de forma exitosa');

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
            return _emptyValueMontos;
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
        app.core.Delete(`${app.setting.entityapi}/PurdyPanelMontos/${row.ID}`, null)
            .done(function (deleted) {
                if (deleted?.Sucessfully) {
                    GetMovimientosDeMontos(_asiges);
                    app.ui.Success('El movimiento de montos, fue eliminado de forma exitosa');
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

    async function balance_table_setup() {

        $('#balanceTbl').bootstrapTable({
            uniqueId: 'ID',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showFooter: true,
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
                    visible: true,
                    footerFormatter: function (data, value) {


                        return '<span id="gbalance"></span>';

                    }
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
                        let deleteBtn = '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del visualizations de la fila"> <i class="fa fa-close"></i> </button>';

                        if (!localStorage.getItem('Roles').includes('Administrativo')) {
                            deleteBtn = '';
                        }
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del visualizations de la fila"> <i class="fa fa-pencil"></i> </button>' + deleteBtn;
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
                    app.core.Post(`${app.setting.entityapi}/PurdyPanelBalance`, JSON.stringify(row))
                        .done(function (created) {
                            if (created?.Sucessfully) {
                                $('#balanceModal').modal('hide');
                                GetBalance(_asiges);
                                app.ui.Success('El movimiento de montos, fue creada de forma exitosa');
                            }
                            else {
                                console.error(created);
                            }

                        }).always(function () {
                            app.ui.ButtonDone('#balanceEdtFormSave');
                        });
                } else {
                    app.core.Put(`${app.setting.entityapi}/PurdyPanelBalance/${row.ID}`, JSON.stringify(row))
                        .done(function (updated) {
                            if (updated?.Sucessfully) {
                                $('#balanceModal').modal('hide');
                                GetBalance(_asiges);
                                app.ui.Success('El movimiento de montos, fue actualizado de forma exitosa');
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
            return _emptyValueBalance;
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
        app.core.Delete(`${app.setting.entityapi}/PurdyPanelBalance/${row.ID}`, null)
            .done(function (deleted) {
                if (deleted?.Sucessfully) {
                    GetBalance(_asiges);
                    app.ui.Success('El movimiento de balance, fue eliminado de forma exitosa');
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

    function CalcBalance() {
        if (_data?.damage != null) {
            let rows = $('#balanceTbl').bootstrapTable('getData');
            let totaFactMoRep = rows.filter(r => r.TIPODEDOCUMENTO != 3).reduce((accumulator, item) => { return accumulator + item.MONTO - item.NCREPUESTO; }, 0) -
                                rows.filter(r => r.TIPODEDOCUMENTO === 3).reduce((accumulator, item) => { return accumulator + item.MONTO - item.NCREPUESTO; }, 0);
            let base = _data.damage.PERDREPUESTO - _data.damage.PERDREPUESTODESC + _data.damage.PERDMANO - _data.damage.DEPRECIACIONYEXCLUSIONES - _deducible;
            let balance = base - totaFactMoRep;

            console.log('PERDREPUESTO', _data.damage.PERDREPUESTO);
            console.log('PERDREPUESTODESC', _data.damage.PERDREPUESTODESC);
            console.log('PERDMANO', _data.damage.PERDMANO);



            console.log('base', base);
            console.log('totaFactMoRep', totaFactMoRep);
            console.log('DEPRECIACIONYEXCLUSIONES', _data.damage.DEPRECIACIONYEXCLUSIONES);
            console.log('_deducible', _deducible);
            $('#gbalance').html(`Saldo: ${app.ui.NumericValueFormat(balance, 2)}`);
        }
    };

    return {
        Init: function (eventCallback) {
            try {
                _eventCallback = eventCallback;
                Controls_setup();
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
        Event: async function (src, data, eventData) {
            switch (src) {
                case 'ASIGESChange':
                    if (data.claim != null) {
                        _claim = data.claim;
                        GetMovimientosDeMontos(data.asiges);
                        GetBalance(data.asiges);
                        _emptyValueBalance.NUMERODESINIESTRO = data.claim.NUM_SINI;
                    } else {
                        $('#balanceTbl').bootstrapTable('load', []);
                        $('#movimientosdemontosTbl').bootstrapTable('load', []);
                        app.ui.VisibleBehaviour('.DanoOculto', false);
                    }
                    _data = data;
                    break;
                case 'DanosDataChange':
                    app.ui.VisibleBehaviour('.DanoOculto', data.damage.PRESENTADANOOCULTO == 1);

                    _emptyValueMontos.MONTOINICIALPORINDEMNIZAR = data.damage.PERDIDA;
                    _emptyValueMontos.MONTOINICIALPORINDEMNIZARREPUE = data.damage.PERDREPUESTOTOTAL;
                    _emptyValueMontos.MONTOINICIALPORINDEMNIZARMANOD = data.damage.PERDMANOTOTAL;

                    _emptyValueMontos.MONTODANOOCULTOPORINDEMNIZAR = data.damage.OTROSIIOTROSIIDANOCULMANOTOTAL;
                    _emptyValueMontos.MONTODANOOCULTOPORINDEMNIZARRE = data.damage.DANOOCULTOTOTAL;
                    _emptyValueMontos.MONTODANOOCULTOPORINDEMNIZARMA = data.damage.DANOOCULTOMANOTOTAL;
                    _data = data;
                    CalcBalance()
                    break;
                case 'DetalleDeducible':
                    _deducible = eventData;
                    CalcBalance();
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
        app.ui.Warning("Si está seguro de querer eliminar el movimiento de saldo '" + row.ID + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PurdyPanelIndemnizacion.movimientosdemontosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PurdyPanelIndemnizacion.movimientosdemontosEditRow(row);
        e.stopPropagation();
    }
};
window.balanceTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.ui.Warning("Si está seguro de querer eliminar el movimiento de balance '" + row.ID + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PurdyPanelIndemnizacion.balanceDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PurdyPanelIndemnizacion.balanceEditRow(row);
        e.stopPropagation();
    }
};

