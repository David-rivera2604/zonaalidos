var app = app || {};
app.PurdyPanelIndemnizacion = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {

        //app.core.Get(app.setting.apipath + 'v1/Quote/IndemnizacionSetup', null,
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
        $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosNew').addClass('d-none');
        $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosTbl').bootstrapTable('hideColumn', 'Actions');
        $('#tB4AnalisisdeIndemnizaciont5BalanceNew').addClass('d-none');
        $('#tB4AnalisisdeIndemnizaciont5BalanceTbl').bootstrapTable('hideColumn', 'Actions');
        $('#tB4Legalt6MovimientosdemontosNew').addClass('d-none');
        $('#tB4Legalt6MovimientosdemontosTbl').bootstrapTable('hideColumn', 'Actions');
        $('#tB4Legalt7RecuperacionNew').addClass('d-none');
        $('#tB4Legalt7RecuperacionTbl').bootstrapTable('hideColumn', 'Actions');

    };

    function MapInputToObject() {
        var data = {
            aSIGES: $('#aSIGES').val(),
            tB4AnalisisdeIndemnizaciont4Movimientosdemontos: $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosTbl').bootstrapTable('getData'),
            tB4AnalisisdeIndemnizaciont5Balance: $('#tB4AnalisisdeIndemnizaciont5BalanceTbl').bootstrapTable('getData'),
            tB4Legalt6Movimientosdemontos: $('#tB4Legalt6MovimientosdemontosTbl').bootstrapTable('getData'),
            tB4Legalt7Recuperacion: $('#tB4Legalt7RecuperacionTbl').bootstrapTable('getData'),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#aSIGES').val(data.aSIGES);
        if (data.tB4AnalisisdeIndemnizaciont4Movimientosdemontos != null)
            $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosTbl').bootstrapTable('load', data.tB4AnalisisdeIndemnizaciont4Movimientosdemontos);
        else
            $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosTbl').bootstrapTable('load', {});
        if (data.tB4AnalisisdeIndemnizaciont5Balance != null)
            $('#tB4AnalisisdeIndemnizaciont5BalanceTbl').bootstrapTable('load', data.tB4AnalisisdeIndemnizaciont5Balance);
        else
            $('#tB4AnalisisdeIndemnizaciont5BalanceTbl').bootstrapTable('load', {});
        if (data.tB4Legalt6Movimientosdemontos != null)
            $('#tB4Legalt6MovimientosdemontosTbl').bootstrapTable('load', data.tB4Legalt6Movimientosdemontos);
        else
            $('#tB4Legalt6MovimientosdemontosTbl').bootstrapTable('load', {});
        if (data.tB4Legalt7Recuperacion != null)
            $('#tB4Legalt7RecuperacionTbl').bootstrapTable('load', data.tB4Legalt7Recuperacion);
        else
            $('#tB4Legalt7RecuperacionTbl').bootstrapTable('load', {});

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
        $('#fechaEnviadoaInvestigacion_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechaEnviadoaAcompanamientoLegal_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechadelevento_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechaidentificadocomoPosibleSubrogacion_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#DocumentNumber').formatter({
            pattern: '0{{9}}-{{9999}}-{{9999}}',
            persistent: false
        });
        $('#telefonodeltercero').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#fechaSentencia_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#montoporrecuperar', {
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
        new AutoNumeric('#saldoporRecuperar', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#tB4Legalt7RecuperacionFecha_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#tB4Legalt7RecuperacionMonto', {
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
        $("#PanelPurdyIndemnizacionEdtForm :input").change(function () {
            data_changed();
        });

        $('#DocumentNumberTypeMenu a').click(function () {
            app.ui.DocumentTypeHandler(this, '#DocumentNumber', 'Identification');
        });

        $('#DocumentNumber').on('blur', function () {
            if (app.ui.IsDocumentNumberValid($('#DocumentNumberType').data('value'), $('#DocumentNumber').val())) {
                var value = $('#DocumentNumber').val().replace(/-/g, '');
                if (value !== null && parseInt(0 + value, 10) !== 0 && parseInt(0 + value, 10) <= 999999999) {
                    $('#DocumentNumber').addClass('loading');
                    app.core.GetExt('https://www.inmotiontools.com:8083/logic/api/padron/personaporcedula?cedula=' + parseInt(0 + value, 10))
                        .done(function (data, textStatus, jqXHR) {
                            if (data.Nombre !== null) {
                                alert(data.Nombre);
                            }
                        }).always(function () {
                            $('#DocumentNumber').removeClass('loading');
                        });
                }
            }
        });
        $('#telefonodelterceroTypeMenu a').click(function () {
            app.ui.DocumentTypeHandler(this, '#telefonodeltercero', 'Phone');
        });

        $('#PanelPurdyIndemnizacionEdtFormSave').click(function () {

            if (app.ui.IsValid('#PanelPurdyIndemnizacionEdtForm', false)) {
                app.ui.ButtonDoing('#PanelPurdyIndemnizacionEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/PanelPurdy/Indemnizacion',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {

                        }

                    }).always(function () {
                        app.ui.ButtonDone('#PanelPurdyIndemnizacionEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#PanelPurdyIndemnizacionEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#PanelPurdyIndemnizacionEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PanelPurdyIndemnizacionEdtFormCancel'); }, 3000);
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
        $("#PanelPurdyIndemnizacionEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                aSIGES: { required: true },
                correodeltercero: { email: true },
            },
            messages: {
                aSIGES: { required: 'Debe indicar el asiges' },
                correodeltercero: { email: 'Debe indicar un correo electrónico valido' },
            }
        });
    };

    function tB4AnalisisdeIndemnizaciont4Movimientosdemontos_table_setup() {

        $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosTbl').bootstrapTable({
            uniqueId: 'tB4AnalisisdeIndemnizaciont4MovimientosdemontosId',
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
                    events: 'tB4AnalisisdeIndemnizaciont4MovimientosdemontosTbl_Events',
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

        $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosNew').click(function () {
            tB4AnalisisdeIndemnizaciont4Movimientosdemontos_table_row_edit();
        });

        $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosEdtFormSave').click(function () {
            if (app.ui.IsValid('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosEdtForm', false)) {
                app.ui.ButtonDoing('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosEdtFormSave');

                var row = tB4AnalisisdeIndemnizaciont4Movimientosdemontos_table_row('values');

                if (row.tB4AnalisisdeIndemnizaciont4MovimientosdemontosId === null)
                    row.tB4AnalisisdeIndemnizaciont4MovimientosdemontosId = 1;

                if ($('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosModal').data('id') != null) {
                    $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosTbl').bootstrapTable('updateByUniqueId', { id: row.tB4AnalisisdeIndemnizaciont4MovimientosdemontosId, row: row });
                }
                else {
                    $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosEdtFormSave')
                $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosModal').modal('hide');
            }
        });

    };

    function tB4AnalisisdeIndemnizaciont4Movimientosdemontos_table_row(mode) {
        if (mode == null) {
            return {
                tB4AnalisisdeIndemnizaciont4MovimientosdemontosId: null,
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
                tB4AnalisisdeIndemnizaciont4MovimientosdemontosId: $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosModal').data('id'),
                montoInicialporIndemnizar: app.ui.GetNumericValue('#montoInicialporIndemnizar'),
                montoInicialporIndemnizarRepuestos: app.ui.GetNumericValue('#montoInicialporIndemnizarRepuestos'),
                montoInicialporIndemnizarManodeObra: app.ui.GetNumericValue('#montoInicialporIndemnizarManodeObra'),
                montoDanoOcultoporIndemnizar: app.ui.GetNumericValue('#montoDanoOcultoporIndemnizar'),
                montoDanoOcultoporIndemnizarRepuestos: app.ui.GetNumericValue('#montoDanoOcultoporIndemnizarRepuestos'),
                montoDanoOcultoporIndemnizarManodeObra: app.ui.GetNumericValue('#montoDanoOcultoporIndemnizarManodeObra')
            };
        }
    };

    function tB4AnalisisdeIndemnizaciont4Movimientosdemontos_table_row_edit(row) {
        var md = $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosModal').modal({ show: false });
        var formInstance = $("#tB4AnalisisdeIndemnizaciont4MovimientosdemontosEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || tB4AnalisisdeIndemnizaciont4Movimientosdemontos_table_row();
        md.data('id', row.tB4AnalisisdeIndemnizaciont4MovimientosdemontosId);

        app.ui.SetNumericValue('#montoInicialporIndemnizar', row.montoInicialporIndemnizar);
        app.ui.SetNumericValue('#montoInicialporIndemnizarRepuestos', row.montoInicialporIndemnizarRepuestos);
        app.ui.SetNumericValue('#montoInicialporIndemnizarManodeObra', row.montoInicialporIndemnizarManodeObra);
        app.ui.SetNumericValue('#montoDanoOcultoporIndemnizar', row.montoDanoOcultoporIndemnizar);
        app.ui.SetNumericValue('#montoDanoOcultoporIndemnizarRepuestos', row.montoDanoOcultoporIndemnizarRepuestos);
        app.ui.SetNumericValue('#montoDanoOcultoporIndemnizarManodeObra', row.montoDanoOcultoporIndemnizarManodeObra);


        md.modal('show');
    };

    function tB4AnalisisdeIndemnizaciont4Movimientosdemontos_table_row_delete(row) {
        $('#tB4AnalisisdeIndemnizaciont4MovimientosdemontosTbl').bootstrapTable('removeByUniqueId', row.tB4AnalisisdeIndemnizaciont4MovimientosdemontosId);
    };

    function tB4AnalisisdeIndemnizaciont4Movimientosdemontos_table_Validations() {
        app.ui.DateValidators();
        $("#tB4AnalisisdeIndemnizaciont4MovimientosdemontosEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {},
            messages: {}
        });
    };

    function tB4AnalisisdeIndemnizaciont5Balance_table_setup() {

        $('#tB4AnalisisdeIndemnizaciont5BalanceTbl').bootstrapTable({
            uniqueId: 'tB4AnalisisdeIndemnizaciont5BalanceId',
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
                    events: 'tB4AnalisisdeIndemnizaciont5BalanceTbl_Events',
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

        $('#tB4AnalisisdeIndemnizaciont5BalanceNew').click(function () {
            tB4AnalisisdeIndemnizaciont5Balance_table_row_edit();
        });

        $('#tB4AnalisisdeIndemnizaciont5BalanceEdtFormSave').click(function () {
            if (app.ui.IsValid('#tB4AnalisisdeIndemnizaciont5BalanceEdtForm', false)) {
                app.ui.ButtonDoing('#tB4AnalisisdeIndemnizaciont5BalanceEdtFormSave');

                var row = tB4AnalisisdeIndemnizaciont5Balance_table_row('values');

                if (row.tB4AnalisisdeIndemnizaciont5BalanceId === null)
                    row.tB4AnalisisdeIndemnizaciont5BalanceId = 1;

                if ($('#tB4AnalisisdeIndemnizaciont5BalanceModal').data('id') != null) {
                    $('#tB4AnalisisdeIndemnizaciont5BalanceTbl').bootstrapTable('updateByUniqueId', { id: row.tB4AnalisisdeIndemnizaciont5BalanceId, row: row });
                }
                else {
                    $('#tB4AnalisisdeIndemnizaciont5BalanceTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#tB4AnalisisdeIndemnizaciont5BalanceEdtFormSave')
                $('#tB4AnalisisdeIndemnizaciont5BalanceModal').modal('hide');
            }
        });

    };

    function tB4AnalisisdeIndemnizaciont5Balance_table_row(mode) {
        if (mode == null) {
            return {
                tB4AnalisisdeIndemnizaciont5BalanceId: null,
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
                tB4AnalisisdeIndemnizaciont5BalanceId: $('#tB4AnalisisdeIndemnizaciont5BalanceModal').data('id'),
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

    function tB4AnalisisdeIndemnizaciont5Balance_table_row_edit(row) {
        var md = $('#tB4AnalisisdeIndemnizaciont5BalanceModal').modal({ show: false });
        var formInstance = $("#tB4AnalisisdeIndemnizaciont5BalanceEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || tB4AnalisisdeIndemnizaciont5Balance_table_row();
        md.data('id', row.tB4AnalisisdeIndemnizaciont5BalanceId);

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

    function tB4AnalisisdeIndemnizaciont5Balance_table_row_delete(row) {
        $('#tB4AnalisisdeIndemnizaciont5BalanceTbl').bootstrapTable('removeByUniqueId', row.tB4AnalisisdeIndemnizaciont5BalanceId);
    };

    function tB4AnalisisdeIndemnizaciont5Balance_table_Validations() {
        app.ui.DateValidators();
        $("#tB4AnalisisdeIndemnizaciont5BalanceEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {},
            messages: {}
        });
    };

    function tB4Legalt6Movimientosdemontos_table_setup() {

        $('#tB4Legalt6MovimientosdemontosTbl').bootstrapTable({
            uniqueId: 'tB4Legalt6MovimientosdemontosId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'fechaEnviadoaInvestigacion',
                    title: 'Fecha Enviado a Investigación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'requisitosporpresentarparareconstruccion',
                    title: 'Requisitos por presentar para reconstrucción',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'fechaEnviadoaAcompanamientoLegal',
                    title: 'Fecha Enviado a Acompañamiento Legal',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'fechadelevento',
                    title: 'Fecha del evento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'fechaidentificadocomoPosibleSubrogacion',
                    title: 'Fecha identificado como Posible Subrogación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'muertos',
                    title: 'Muertos',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'lesionados',
                    title: 'Lesionados',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'lesionadosPosibleResultado',
                    title: 'Lesionados (Posible Resultado)',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'asesorLegal',
                    title: 'Asesor Legal',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'estadoProcesal',
                    title: 'Estado Procesal',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'recomendacionLegal',
                    title: 'Recomendación Legal',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'nombredeltercero',
                    title: 'Nombre del tercero',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'DocumentNumber',
                    title: 'Cédula del tercero',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'telefonodeltercero',
                    title: 'Teléfono del tercero',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'correodeltercero',
                    title: 'Correo del tercero',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'placadetercerocontraparte',
                    title: 'Placa de tercero (contraparte)',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'lugaraccidente',
                    title: 'Lugar accidente',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'juzgado',
                    title: 'Juzgado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'expedienteJudicial',
                    title: 'Expediente Judicial',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'fechaSentencia',
                    title: 'Fecha Sentencia',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'montoporrecuperar',
                    title: 'Monto por recuperar',
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
                    field: 'saldoporRecuperar',
                    title: 'Saldo por Recuperar',
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
                    events: 'tB4Legalt6MovimientosdemontosTbl_Events',
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

        $('#tB4Legalt6MovimientosdemontosNew').click(function () {
            tB4Legalt6Movimientosdemontos_table_row_edit();
        });

        $('#tB4Legalt6MovimientosdemontosEdtFormSave').click(function () {
            if (app.ui.IsValid('#tB4Legalt6MovimientosdemontosEdtForm', false)) {
                app.ui.ButtonDoing('#tB4Legalt6MovimientosdemontosEdtFormSave');

                var row = tB4Legalt6Movimientosdemontos_table_row('values');

                if (row.tB4Legalt6MovimientosdemontosId === null)
                    row.tB4Legalt6MovimientosdemontosId = 1;

                if ($('#tB4Legalt6MovimientosdemontosModal').data('id') != null) {
                    $('#tB4Legalt6MovimientosdemontosTbl').bootstrapTable('updateByUniqueId', { id: row.tB4Legalt6MovimientosdemontosId, row: row });
                }
                else {
                    $('#tB4Legalt6MovimientosdemontosTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#tB4Legalt6MovimientosdemontosEdtFormSave')
                $('#tB4Legalt6MovimientosdemontosModal').modal('hide');
            }
        });

    };

    function tB4Legalt6Movimientosdemontos_table_row(mode) {
        if (mode == null) {
            return {
                tB4Legalt6MovimientosdemontosId: null,
                fechaEnviadoaInvestigacion: null,
                requisitosporpresentarparareconstruccion: null,
                fechaEnviadoaAcompanamientoLegal: null,
                fechadelevento: null,
                fechaidentificadocomoPosibleSubrogacion: null,
                muertos: null,
                lesionados: null,
                lesionadosPosibleResultado: null,
                asesorLegal: null,
                estadoProcesal: null,
                recomendacionLegal: null,
                nombredeltercero: null,
                DocumentNumber: null,
                telefonodeltercero: null,
                correodeltercero: null,
                placadetercerocontraparte: null,
                lugaraccidente: null,
                juzgado: null,
                expedienteJudicial: null,
                fechaSentencia: null,
                montoporrecuperar: null,
                montoRecuperado: null,
                saldoporRecuperar: null
            };
        }
        else {
            return {
                tB4Legalt6MovimientosdemontosId: $('#tB4Legalt6MovimientosdemontosModal').data('id'),
                fechaEnviadoaInvestigacion: app.ui.GetDateValue('#fechaEnviadoaInvestigacion'),
                requisitosporpresentarparareconstruccion: $('#requisitosporpresentarparareconstruccion').val(),
                fechaEnviadoaAcompanamientoLegal: app.ui.GetDateValue('#fechaEnviadoaAcompanamientoLegal'),
                fechadelevento: app.ui.GetDateValue('#fechadelevento'),
                fechaidentificadocomoPosibleSubrogacion: app.ui.GetDateValue('#fechaidentificadocomoPosibleSubrogacion'),
                muertos: $('#muertos').val(),
                lesionados: $('#lesionados').val(),
                lesionadosPosibleResultado: $('#lesionadosPosibleResultado').val(),
                asesorLegal: $('#asesorLegal').val(),
                estadoProcesal: $('#estadoProcesal').val(),
                recomendacionLegal: $('#recomendacionLegal').val(),
                nombredeltercero: $('#nombredeltercero').val(),
                DocumentNumber: $('#DocumentNumber').val(),
                telefonodeltercero: $('#telefonodeltercero').val(),
                correodeltercero: $('#correodeltercero').val(),
                placadetercerocontraparte: $('#placadetercerocontraparte').val(),
                lugaraccidente: $('#lugaraccidente').val(),
                juzgado: $('#juzgado').val(),
                expedienteJudicial: $('#expedienteJudicial').val(),
                fechaSentencia: app.ui.GetDateValue('#fechaSentencia'),
                montoporrecuperar: app.ui.GetNumericValue('#montoporrecuperar'),
                montoRecuperado: app.ui.GetNumericValue('#montoRecuperado'),
                saldoporRecuperar: app.ui.GetNumericValue('#saldoporRecuperar')
            };
        }
    };

    function tB4Legalt6Movimientosdemontos_table_row_edit(row) {
        var md = $('#tB4Legalt6MovimientosdemontosModal').modal({ show: false });
        var formInstance = $("#tB4Legalt6MovimientosdemontosEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || tB4Legalt6Movimientosdemontos_table_row();
        md.data('id', row.tB4Legalt6MovimientosdemontosId);

        app.ui.SetDateValue('#fechaEnviadoaInvestigacion', row.fechaEnviadoaInvestigacion);
        $('#requisitosporpresentarparareconstruccion').val(row.requisitosporpresentarparareconstruccion);
        app.ui.SetDateValue('#fechaEnviadoaAcompanamientoLegal', row.fechaEnviadoaAcompanamientoLegal);
        app.ui.SetDateValue('#fechadelevento', row.fechadelevento);
        app.ui.SetDateValue('#fechaidentificadocomoPosibleSubrogacion', row.fechaidentificadocomoPosibleSubrogacion);
        $('#muertos').val(row.muertos);
        $('#lesionados').val(row.lesionados);
        $('#lesionadosPosibleResultado').val(row.lesionadosPosibleResultado);
        $('#asesorLegal').val(row.asesorLegal);
        $('#estadoProcesal').val(row.estadoProcesal);
        $('#recomendacionLegal').val(row.recomendacionLegal);
        $('#nombredeltercero').val(row.nombredeltercero);
        $('#DocumentNumber').val(row.DocumentNumber);
        $('#telefonodeltercero').val(row.telefonodeltercero);
        $('#correodeltercero').val(row.correodeltercero);
        $('#placadetercerocontraparte').val(row.placadetercerocontraparte);
        $('#lugaraccidente').val(row.lugaraccidente);
        $('#juzgado').val(row.juzgado);
        $('#expedienteJudicial').val(row.expedienteJudicial);
        app.ui.SetDateValue('#fechaSentencia', row.fechaSentencia);
        app.ui.SetNumericValue('#montoporrecuperar', row.montoporrecuperar);
        app.ui.SetNumericValue('#montoRecuperado', row.montoRecuperado);
        app.ui.SetNumericValue('#saldoporRecuperar', row.saldoporRecuperar);


        md.modal('show');
    };

    function tB4Legalt6Movimientosdemontos_table_row_delete(row) {
        $('#tB4Legalt6MovimientosdemontosTbl').bootstrapTable('removeByUniqueId', row.tB4Legalt6MovimientosdemontosId);
    };

    function tB4Legalt6Movimientosdemontos_table_Validations() {
        app.ui.DateValidators();
        $("#tB4Legalt6MovimientosdemontosEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {},
            messages: {}
        });
    };

    function tB4Legalt7Recuperacion_table_setup() {

        $('#tB4Legalt7RecuperacionTbl').bootstrapTable({
            uniqueId: 'tB4Legalt7RecuperacionId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'tB4Legalt7RecuperacionNumerodeSiniestro',
                    title: 'Número de Siniestro',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'tB4Legalt7RecuperacionTipodedocumento',
                    title: 'Tipo de documento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'tB4Legalt7RecuperacionNumerodedocumento',
                    title: 'Número de documento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'tB4Legalt7RecuperacionFecha',
                    title: 'Fecha',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'tB4Legalt7RecuperacionReceptor',
                    title: 'Receptor',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'tB4Legalt7RecuperacionMonto',
                    title: 'Monto',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'tB4Legalt7RecuperacionObservacion',
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
                    events: 'tB4Legalt7RecuperacionTbl_Events',
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

        $('#tB4Legalt7RecuperacionNew').click(function () {
            tB4Legalt7Recuperacion_table_row_edit();
        });

        $('#tB4Legalt7RecuperacionEdtFormSave').click(function () {
            if (app.ui.IsValid('#tB4Legalt7RecuperacionEdtForm', false)) {
                app.ui.ButtonDoing('#tB4Legalt7RecuperacionEdtFormSave');

                var row = tB4Legalt7Recuperacion_table_row('values');

                if (row.tB4Legalt7RecuperacionId === null)
                    row.tB4Legalt7RecuperacionId = 1;

                if ($('#tB4Legalt7RecuperacionModal').data('id') != null) {
                    $('#tB4Legalt7RecuperacionTbl').bootstrapTable('updateByUniqueId', { id: row.tB4Legalt7RecuperacionId, row: row });
                }
                else {
                    $('#tB4Legalt7RecuperacionTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#tB4Legalt7RecuperacionEdtFormSave')
                $('#tB4Legalt7RecuperacionModal').modal('hide');
            }
        });

    };

    function tB4Legalt7Recuperacion_table_row(mode) {
        if (mode == null) {
            return {
                tB4Legalt7RecuperacionId: null,
                tB4Legalt7RecuperacionNumerodeSiniestro: null,
                tB4Legalt7RecuperacionTipodedocumento: null,
                tB4Legalt7RecuperacionNumerodedocumento: null,
                tB4Legalt7RecuperacionFecha: null,
                tB4Legalt7RecuperacionReceptor: null,
                tB4Legalt7RecuperacionMonto: null,
                tB4Legalt7RecuperacionObservacion: null
            };
        }
        else {
            return {
                tB4Legalt7RecuperacionId: $('#tB4Legalt7RecuperacionModal').data('id'),
                tB4Legalt7RecuperacionNumerodeSiniestro: $('#tB4Legalt7RecuperacionNumerodeSiniestro').val(),
                tB4Legalt7RecuperacionTipodedocumento: $('#tB4Legalt7RecuperacionTipodedocumento').val(),
                tB4Legalt7RecuperacionNumerodedocumento: $('#tB4Legalt7RecuperacionNumerodedocumento').val(),
                tB4Legalt7RecuperacionFecha: app.ui.GetDateValue('#tB4Legalt7RecuperacionFecha'),
                tB4Legalt7RecuperacionReceptor: $('#tB4Legalt7RecuperacionReceptor').val(),
                tB4Legalt7RecuperacionMonto: app.ui.GetNumericValue('#tB4Legalt7RecuperacionMonto'),
                tB4Legalt7RecuperacionObservacion: $('#tB4Legalt7RecuperacionObservacion').val()
            };
        }
    };

    function tB4Legalt7Recuperacion_table_row_edit(row) {
        var md = $('#tB4Legalt7RecuperacionModal').modal({ show: false });
        var formInstance = $("#tB4Legalt7RecuperacionEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || tB4Legalt7Recuperacion_table_row();
        md.data('id', row.tB4Legalt7RecuperacionId);

        $('#tB4Legalt7RecuperacionNumerodeSiniestro').val(row.tB4Legalt7RecuperacionNumerodeSiniestro);
        $('#tB4Legalt7RecuperacionTipodedocumento').val(row.tB4Legalt7RecuperacionTipodedocumento);
        $('#tB4Legalt7RecuperacionNumerodedocumento').val(row.tB4Legalt7RecuperacionNumerodedocumento);
        app.ui.SetDateValue('#tB4Legalt7RecuperacionFecha', row.tB4Legalt7RecuperacionFecha);
        $('#tB4Legalt7RecuperacionReceptor').val(row.tB4Legalt7RecuperacionReceptor);
        app.ui.SetNumericValue('#tB4Legalt7RecuperacionMonto', row.tB4Legalt7RecuperacionMonto);
        $('#tB4Legalt7RecuperacionObservacion').val(row.tB4Legalt7RecuperacionObservacion);


        md.modal('show');
    };

    function tB4Legalt7Recuperacion_table_row_delete(row) {
        $('#tB4Legalt7RecuperacionTbl').bootstrapTable('removeByUniqueId', row.tB4Legalt7RecuperacionId);
    };

    function tB4Legalt7Recuperacion_table_Validations() {
        app.ui.DateValidators();
        $("#tB4Legalt7RecuperacionEdtForm").validate({
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
                tB4AnalisisdeIndemnizaciont4Movimientosdemontos_table_setup();
                tB4AnalisisdeIndemnizaciont4Movimientosdemontos_table_Validations();
                tB4AnalisisdeIndemnizaciont5Balance_table_setup();
                tB4AnalisisdeIndemnizaciont5Balance_table_Validations();
                tB4Legalt6Movimientosdemontos_table_setup();
                tB4Legalt6Movimientosdemontos_table_Validations();
                tB4Legalt7Recuperacion_table_setup();
                tB4Legalt7Recuperacion_table_Validations();

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
            return app.ui.IsValid('#PanelPurdyIndemnizacionEdtForm', false, showResume);
        },
        tB4AnalisisdeIndemnizaciont4MovimientosdemontosEditRow: function (row) {
            tB4AnalisisdeIndemnizaciont4Movimientosdemontos_table_row_edit(row);
        },
        tB4AnalisisdeIndemnizaciont4MovimientosdemontosDeleteRow: function (row) {
            tB4AnalisisdeIndemnizaciont4Movimientosdemontos_table_row_delete(row);
        },
        tB4AnalisisdeIndemnizaciont5BalanceEditRow: function (row) {
            tB4AnalisisdeIndemnizaciont5Balance_table_row_edit(row);
        },
        tB4AnalisisdeIndemnizaciont5BalanceDeleteRow: function (row) {
            tB4AnalisisdeIndemnizaciont5Balance_table_row_delete(row);
        },
        tB4Legalt6MovimientosdemontosEditRow: function (row) {
            tB4Legalt6Movimientosdemontos_table_row_edit(row);
        },
        tB4Legalt6MovimientosdemontosDeleteRow: function (row) {
            tB4Legalt6Movimientosdemontos_table_row_delete(row);
        },
        tB4Legalt7RecuperacionEditRow: function (row) {
            tB4Legalt7Recuperacion_table_row_edit(row);
        },
        tB4Legalt7RecuperacionDeleteRow: function (row) {
            tB4Legalt7Recuperacion_table_row_delete(row);
        }
    };
})();

window.tB4AnalisisdeIndemnizaciont4MovimientosdemontosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.tB4AnalisisdeIndemnizaciont4MovimientosdemontosId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PurdyPanelIndemnizacion.tB4AnalisisdeIndemnizaciont4MovimientosdemontosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PurdyPanelIndemnizacion.tB4AnalisisdeIndemnizaciont4MovimientosdemontosEditRow(row);
        e.stopPropagation();
    }
};
window.tB4AnalisisdeIndemnizaciont5BalanceTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.tB4AnalisisdeIndemnizaciont5BalanceId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PurdyPanelIndemnizacion.tB4AnalisisdeIndemnizaciont5BalanceDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PurdyPanelIndemnizacion.tB4AnalisisdeIndemnizaciont5BalanceEditRow(row);
        e.stopPropagation();
    }
};
window.tB4Legalt6MovimientosdemontosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.tB4Legalt6MovimientosdemontosId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PurdyPanelIndemnizacion.tB4Legalt6MovimientosdemontosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PurdyPanelIndemnizacion.tB4Legalt6MovimientosdemontosEditRow(row);
        e.stopPropagation();
    }
};
window.tB4Legalt7RecuperacionTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.tB4Legalt7RecuperacionId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PurdyPanelIndemnizacion.tB4Legalt7RecuperacionDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PurdyPanelIndemnizacion.tB4Legalt7RecuperacionEditRow(row);
        e.stopPropagation();
    }
};

