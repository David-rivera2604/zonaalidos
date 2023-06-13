var app = app || {};
var errors = false;
var msj_errors = '';

app.CotizacionSaldoDeudorEnfermedadesExcluidas = (function () {

    function enfermedadesexcluidas_table_setup() {

        $('#enfermedadesexcluidasTbl').bootstrapTable({
            uniqueId: 'enfermedadesexcluidasId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'NOM_ENF_EXC',
                    title: 'Enfermedad',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'NOM_TIP_EXC',
                    title: 'Tipo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'FEC_INI_EXC',
                    title: 'Fecha inicio',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'FEC_FIN_EXC',
                    title: 'Fecha fin',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'TXT_OBS_ENF_EXC',
                    title: 'Observaciones',
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
                    events: 'enfermedadesexcluidasTbl_Events',
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

        $('#enfermedadesexcluidasNew').click(function () {
            enfermedadesexcluidas_table_row_edit();
        });

        $('#enfermedadesexcluidasEdtFormSave').click(function () {
            if (app.ui.IsValid('#enfermedadesexcluidasEdtForm', false)) {

                valid_venct_prestamo();

                if (errors === false) {
                    app.ui.ButtonDoing('#enfermedadesexcluidasEdtFormSave');

                    var row = enfermedadesexcluidas_table_row('values');

                    if (row.enfermedadesexcluidasId === null)
                        row.enfermedadesexcluidasId = 1;

                    if ($('#enfermedadesexcluidasModal').data('id') != null) {
                        $('#enfermedadesexcluidasTbl').bootstrapTable('updateByUniqueId', { id: row.enfermedadesexcluidasId, row: row });
                    }
                    else {
                        $('#enfermedadesexcluidasTbl').bootstrapTable('append', row);
                    }

                    app.ui.ButtonDone('#enfermedadesexcluidasEdtFormSave')
                    $('#enfermedadesexcluidasModal').modal('hide');
                }
                else {
                    toastr.error("Existen errores" + msj_errors, "", { closeButton: true, progressBar: true });
                }

                
            }
        });

    };

    function enfermedadesexcluidas_table_row(mode) {
        if (mode == null) {
            return {
                enfermedadesexcluidasId: null,
                COD_ENF_EXC: null,
                NOM_ENF_EXC: null,
                TXT_OBS_ENF_EXC: null,
                COD_TIP_EXC: null,
                NOM_TIP_EXC: null,
                FEC_INI_EXC: null,
                FEC_FIN_EXC: null
            };
        }
        else {
            return {
                enfermedadesexcluidasId: $('#enfermedadesexcluidasModal').data('id'),
                COD_ENF_EXC: $('#COD_ENF_EXC').val(),
                NOM_ENF_EXC: $("#COD_ENF_EXC option:selected").text(),
                TXT_OBS_ENF_EXC: $('#TXT_OBS_ENF_EXC').val(),
                COD_TIP_EXC: $('#COD_TIP_EXC').val(),
                NOM_TIP_EXC: $("#COD_TIP_EXC option:selected").text(),
                FEC_INI_EXC: app.ui.GetDateValue('#FEC_INI_EXC'),
                FEC_FIN_EXC: app.ui.GetDateValue('#FEC_FIN_EXC')
            };
        }
    };

    function enfermedadesexcluidas_table_row_edit(row) {
        var md = $('#enfermedadesexcluidasModal').modal({ show: false });
        var formInstance = $("#enfermedadesexcluidasEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || enfermedadesexcluidas_table_row();
        md.data('id', row.enfermedadesexcluidasId);

        $('#COD_ENF_EXC').val(row.COD_ENF_EXC);
        $('#TXT_OBS_ENF_EXC').val(row.TXT_OBS_ENF_EXC);
        $('#COD_TIP_EXC').val(row.COD_TIP_EXC);
        app.ui.SetDateValue('#FEC_INI_EXC', row.FEC_INI_EXC);
        app.ui.SetDateValue('#FEC_FIN_EXC', row.FEC_FIN_EXC);


        md.modal('show');
    };

    function enfermedadesexcluidas_table_row_delete(row) {
        $('#enfermedadesexcluidasTbl').bootstrapTable('removeByUniqueId', row.enfermedadesexcluidasId);
    };

    function enfermedadesexcluidas_table_Validations() {
        app.ui.DateValidators();
        $("#enfermedadesexcluidasEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                COD_ENF_EXC: { required: true },
                COD_TIP_EXC: { required: true },
                FEC_INI_EXC: { required: true },
                FEC_FIN_EXC: { required: true },
            },
            messages: {
                COD_ENF_EXC: { required: 'Debe indicar el Enfermedades' },
                COD_TIP_EXC: { required: 'Debe indicar el Tipo exclusión' },
                FEC_INI_EXC: { required: 'Debe indicar el Fecha inicio de exclusión' },
                FEC_FIN_EXC: { required: 'Debe indicar el Fecha fin de exclusión' },
            }
        });
    };

    function valid_venct_prestamo() {

       // $('#FEC_FIN_EXC').focusout(function () {

            let inicio = $('#FEC_INI_EXC').val();
            let fin = $('#FEC_FIN_EXC').val();

            if (inicio === fin) {
                errors = true;
                msj_errors += ', La fecha de inicio y fin de exclusión, no pueden ser iguales';
            }
            else {
                errors = false;
                msj_errors = '';
            }

        //});

    };

    return {
        Init: function () {
            try {
                enfermedadesexcluidas_table_setup();
                enfermedadesexcluidas_table_Validations();
                
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        IsValid: function (showResume) {
            return app.ui.IsValid('#SaldoDeudorEdtForm', false, showResume);
        },
        enfermedadesexcluidasEditRow: function (row) {
            enfermedadesexcluidas_table_row_edit(row);
        },
        enfermedadesexcluidasDeleteRow: function (row) {
            enfermedadesexcluidas_table_row_delete(row);
        }
    };
})();

window.enfermedadesexcluidasTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.enfermedadesexcluidasId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.CotizacionSaldoDeudorEnfermedadesExcluidas.enfermedadesexcluidasDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.CotizacionSaldoDeudorEnfermedadesExcluidas.enfermedadesexcluidasEditRow(row);
        e.stopPropagation();
    }
};

