var app = app || {};

app.PurdyPanelDetalle = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {

        //app.core.Get(app.setting.apipath + 'v1/Quote/DetalleSetup', null,
        //    function (data) {
        //        app.core.Lookups([],
        //            function () {
        //                setupData = data;
        //                MapObjectToInput(data);
        //            }, ``);

        //    });
    };

    function ReadOnly() {
        $('#numerodepoliza').replaceWith('<div>' + $('#numerodepoliza').val() + '</div>');
        $('#monedadepoliza').replaceWith('<div>' + $('#monedadepoliza option:selected').text() + '</div>');
        $('#usodepoliza').replaceWith('<div>' + $('#usodepoliza option:selected').text() + '</div>');
        $('#coberturascontratadas').replaceWith('<div>' + $('#coberturascontratadas').val() + '</div>');
        $('#primaAnual').replaceWith('<div>' + $('#primaAnual').val() + '</div>');
        $('#primaspagadas').replaceWith('<div>' + $('#primaspagadas').val() + '</div>');
        $('#primaspendientesdecobro').replaceWith('<div>' + $('#primaspendientesdecobro').val() + '</div>');
        $('#fechaultimaprimacobrada_group').replaceWith('<div>' + $('#fechaultimaprimacobrada').val() + '</div>');
        $('#deducible').replaceWith('<div>' + $('#deducible').val() + '</div>');
        $('#tomador').replaceWith('<div>' + $('#tomador').val() + '</div>');
        $('#acreedor').replaceWith('<div>' + $('#acreedor').val() + '</div>');
        $('#placa').replaceWith('<div>' + $('#placa').val() + '</div>');
        $('#chasis').replaceWith('<div>' + $('#chasis').val() + '</div>');
        $('#marca').replaceWith('<div>' + $('#marca').val() + '</div>');
        $('#valorAsegurado').replaceWith('<div>' + $('#valorAsegurado').val() + '</div>');
        $('#nombredelchoferduranteelsiniestro').replaceWith('<div>' + $('#nombredelchoferduranteelsiniestro').val() + '</div>');
        $('#telefonodechofer').replaceWith('<div>' + $('#telefonodechofer').val() + '</div>');
        $('#tB1Detallet3BitacoradeASIGESNew').addClass('d-none');
        $('#tB1Detallet3BitacoradeASIGESTbl').bootstrapTable('hideColumn', 'Actions');

    };

    function MapInputToObject() {
        var data = {
            numerodepoliza: $('#numerodepoliza').val(),
            monedadepoliza: app.ui.GetDropDownNumericValue('#monedadepoliza'),
            monedadepolizaDesc: app.ui.GetDropDownSelectedText('#monedadepoliza'),
            usodepoliza: app.ui.GetDropDownNumericValue('#usodepoliza'),
            usodepolizaDesc: app.ui.GetDropDownSelectedText('#usodepoliza'),
            coberturascontratadas: $('#coberturascontratadas').val(),
            primaAnual: app.ui.GetNumericValue('#primaAnual'),
            primaspagadas: app.ui.GetNumericValue('#primaspagadas'),
            primaspendientesdecobro: app.ui.GetNumericValue('#primaspendientesdecobro'),
            fechaultimaprimacobrada: app.ui.GetDateValue('#fechaultimaprimacobrada'),
            deducible: app.ui.GetNumericValue('#deducible'),
            tomador: $('#tomador').val(),
            acreedor: $('#acreedor').val(),
            placa: $('#placa').val(),
            chasis: $('#chasis').val(),
            marca: $('#marca').val(),
            valorAsegurado: app.ui.GetNumericValue('#valorAsegurado'),
            nombredelchoferduranteelsiniestro: $('#nombredelchoferduranteelsiniestro').val(),
            telefonodechofer: $('#telefonodechofer').val(),
            tB1Detallet3BitacoradeASIGES: $('#tB1Detallet3BitacoradeASIGESTbl').bootstrapTable('getData'),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#numerodepoliza').val(data.numerodepoliza);
        app.ui.SetDropDownNumericValue('#monedadepoliza', data.monedadepoliza, true);
        app.ui.SetDropDownNumericValue('#usodepoliza', data.usodepoliza, true);
        $('#coberturascontratadas').val(data.coberturascontratadas);
        app.ui.SetNumericValue('#primaAnual', data.primaAnual);
        app.ui.SetNumericValue('#primaspagadas', data.primaspagadas);
        app.ui.SetNumericValue('#primaspendientesdecobro', data.primaspendientesdecobro);
        app.ui.SetDateValue('#fechaultimaprimacobrada', data.fechaultimaprimacobrada);
        app.ui.SetNumericValue('#deducible', data.deducible);
        $('#tomador').val(data.tomador);
        $('#acreedor').val(data.acreedor);
        $('#placa').val(data.placa);
        $('#chasis').val(data.chasis);
        $('#marca').val(data.marca);
        app.ui.SetNumericValue('#valorAsegurado', data.valorAsegurado);
        $('#nombredelchoferduranteelsiniestro').val(data.nombredelchoferduranteelsiniestro);
        $('#telefonodechofer').val(data.telefonodechofer);
        if (data.tB1Detallet3BitacoradeASIGES != null)
            $('#tB1Detallet3BitacoradeASIGESTbl').bootstrapTable('load', data.tB1Detallet3BitacoradeASIGES);
        else
            $('#tB1Detallet3BitacoradeASIGESTbl').bootstrapTable('load', {});

    };

    function Controls_setup() {
        new AutoNumeric('#primaAnual', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#primaspagadas', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#primaspendientesdecobro', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#fechaultimaprimacobrada_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#deducible', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#valorAsegurado', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#telefonodechofer').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });

    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#PanelPurdyDetalleEdtForm :input").change(function () {
            data_changed();
        });

        $('#telefonodechoferTypeMenu a').click(function () {
            app.ui.DocumentTypeHandler(this, '#telefonodechofer', 'Phone');
        });

        $('#PanelPurdyDetalleEdtFormSave').click(function () {

            if (app.ui.IsValid('#PanelPurdyDetalleEdtForm', false)) {
                app.ui.ButtonDoing('#PanelPurdyDetalleEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/PanelPurdy/Detalle',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {

                        }

                    }).always(function () {
                        app.ui.ButtonDone('#PanelPurdyDetalleEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#PanelPurdyDetalleEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#PanelPurdyDetalleEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PanelPurdyDetalleEdtFormCancel'); }, 3000);
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
        $("#PanelPurdyDetalleEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {},
            messages: {}
        });
    };

    function tB1Detallet3BitacoradeASIGES_table_setup() {

        $('#tB1Detallet3BitacoradeASIGESTbl').bootstrapTable({
            uniqueId: 'tB1Detallet3BitacoradeASIGESId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'bitacora',
                    title: 'Bitácora',
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
                    events: 'tB1Detallet3BitacoradeASIGESTbl_Events',
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

        $('#tB1Detallet3BitacoradeASIGESNew').click(function () {
            tB1Detallet3BitacoradeASIGES_table_row_edit();
        });

        $('#tB1Detallet3BitacoradeASIGESEdtFormSave').click(function () {
            if (app.ui.IsValid('#tB1Detallet3BitacoradeASIGESEdtForm', false)) {
                app.ui.ButtonDoing('#tB1Detallet3BitacoradeASIGESEdtFormSave');

                var row = tB1Detallet3BitacoradeASIGES_table_row('values');

                if (row.tB1Detallet3BitacoradeASIGESId === null)
                    row.tB1Detallet3BitacoradeASIGESId = 1;

                if ($('#tB1Detallet3BitacoradeASIGESModal').data('id') != null) {
                    $('#tB1Detallet3BitacoradeASIGESTbl').bootstrapTable('updateByUniqueId', { id: row.tB1Detallet3BitacoradeASIGESId, row: row });
                }
                else {
                    $('#tB1Detallet3BitacoradeASIGESTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#tB1Detallet3BitacoradeASIGESEdtFormSave')
                $('#tB1Detallet3BitacoradeASIGESModal').modal('hide');
            }
        });

    };

    function tB1Detallet3BitacoradeASIGES_table_row(mode) {
        if (mode == null) {
            return {
                tB1Detallet3BitacoradeASIGESId: null,
                bitacora: null
            };
        }
        else {
            return {
                tB1Detallet3BitacoradeASIGESId: $('#tB1Detallet3BitacoradeASIGESModal').data('id'),
                bitacora: $('#bitacora').val()
            };
        }
    };

    function tB1Detallet3BitacoradeASIGES_table_row_edit(row) {
        var md = $('#tB1Detallet3BitacoradeASIGESModal').modal({ show: false });
        var formInstance = $("#tB1Detallet3BitacoradeASIGESEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || tB1Detallet3BitacoradeASIGES_table_row();
        md.data('id', row.tB1Detallet3BitacoradeASIGESId);

        $('#bitacora').val(row.bitacora);


        md.modal('show');
    };

    function tB1Detallet3BitacoradeASIGES_table_row_delete(row) {
        $('#tB1Detallet3BitacoradeASIGESTbl').bootstrapTable('removeByUniqueId', row.tB1Detallet3BitacoradeASIGESId);
    };

    function tB1Detallet3BitacoradeASIGES_table_Validations() {
        app.ui.DateValidators();
        $("#tB1Detallet3BitacoradeASIGESEdtForm").validate({
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
                tB1Detallet3BitacoradeASIGES_table_setup();
                tB1Detallet3BitacoradeASIGES_table_Validations();

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
            return app.ui.IsValid('#PanelPurdyDetalleEdtForm', false, showResume);
        },
        tB1Detallet3BitacoradeASIGESEditRow: function (row) {
            tB1Detallet3BitacoradeASIGES_table_row_edit(row);
        },
        tB1Detallet3BitacoradeASIGESDeleteRow: function (row) {
            tB1Detallet3BitacoradeASIGES_table_row_delete(row);
        }
    };
})();

window.tB1Detallet3BitacoradeASIGESTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.tB1Detallet3BitacoradeASIGESId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PurdyPanelDetalle.tB1Detallet3BitacoradeASIGESDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PurdyPanelDetalle.tB1Detallet3BitacoradeASIGESEditRow(row);
        e.stopPropagation();
    }
};

