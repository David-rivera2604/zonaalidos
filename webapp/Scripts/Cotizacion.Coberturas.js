var app = app || {};

app.CotizacionCoberturas = (function () {

    let CapitalCtrls = [];

    function coberturas_table_setup() {

        $('#coberturasTbl').bootstrapTable({
            uniqueId: 'coberturasId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'seleccionado',
                    align: 'center',
                    checkbox: true
                }, {
                    field: 'riesgo',
                    title: 'Riesgo',
                    titleTooltip: 'Número del riesgo',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                }, {
                    field: 'codigo',
                    title: 'Código',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: true
                }, {
                    field: 'nombre',
                    title: 'Nombre',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'capital',
                    title: 'Capital',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: function (value, row, index, field) {
                        if (row.edtCapital)
                            return '<input id="CapitalRow_' + index + '" name="CapitalGridEdit" type="text" class="form-control grid-control text-right" size="21" maxlength="21" disabled placeholder="Indique el capital">';
                        else
                            if (value == undefined || value === null || value === 0)
                                return '';
                            else
                                return value.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                    }
                }, {
                    field: 'primatotal',
                    title: 'Prima total',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'deducible',
                    title: 'Deducible',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                },]
        });

        $('#coberturasTbl').on('check.bs.table', function () {
            Coberturas_Manejo();
        });
        $('#coberturasTbl').on('uncheck.bs.table', function () {
            Coberturas_Manejo();
        });
    };

    function plandepago_table_setup() {

        $('#plandepagoTbl').bootstrapTable({
            uniqueId: 'plandepagoId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'cuota',
                    title: 'Cuota',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: true
                }, {
                    field: 'fechadesde',
                    title: 'Fecha desde',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'fechahasta',
                    title: 'Fecha hasta',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'primaneta',
                    title: 'Prima neta',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'iVA',
                    title: 'IVA',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'recardoporfraccionamiento',
                    title: 'Recargo por fraccionamiento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'importetotal',
                    title: 'Importe total',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                },]
        });



    };

    function plandepagoporfrecuencia_table_setup() {

        $('#plandepagoporfrecuenciaTbl').bootstrapTable({
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            columns: [
                {
                    field: 'codigo',
                    title: 'codigo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                }, {
                    field: 'frecuencia',
                    title: 'Fraccionamiento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    visible: true
                }, {
                    field: 'importetotal',
                    title: 'Importe',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'recargoporfraccionamiento',
                    title: '%',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }]
        });

    };

    function Coberturas_Manejo() {
        coberturas = $('#coberturasTbl').bootstrapTable('getData');
        coberturas.forEach(function (currentValue, index) {
            if (currentValue.edtCapital) {
                if (!currentValue.requerida)
                    $('#CapitalRow_' + index).prop('disabled', !currentValue.seleccionado);
                if (currentValue.capital == null || currentValue.capital == 0)
                    app.ui.SetNumericValue('#CapitalRow_' + index, '');
                else
                    app.ui.SetNumericValue('#CapitalRow_' + index, currentValue.capital);
            }
        });
    };

    return {
        Init: function () {
            try {
                coberturas_table_setup();
                plandepago_table_setup();
                plandepagoporfrecuencia_table_setup();
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        PrepararCapitalEdit: function () {
            CapitalCtrls.forEach(element => element.wipe());
            CapitalCtrls = [];
            $('input[name="CapitalGridEdit"]').each(function () {
                CapitalCtrls.push(new AutoNumeric(this, {
                    decimalCharacter: ',',
                    decimalCharacterAlternative: '.',
                    digitGroupSeparator: '.',
                    maximumValue: '99999999999999',
                    minimumValue: '0',
                    decimalPlaces: '0',
                    emptyInputBehavior: 'null'
                }));
            });

            coberturas = $('#coberturasTbl').bootstrapTable('getData');
            coberturas.forEach(function (currentValue, index) {
                if (currentValue.edtCapital)
                    if (currentValue.capital == null || currentValue.capital == 0)
                        app.ui.SetNumericValue('#CapitalRow_' + index, '');
                    else
                        app.ui.SetNumericValue('#CapitalRow_' + index, currentValue.capital);
            });

            coberturas.forEach(function (value, index, array) {
                $('[name=btSelectItem][data-index=' + index + ']').prop('disabled', value.requerida);
            });
            $('[name=btSelectAll]').prop('disabled', true);
            Coberturas_ManejoGeneral2();
        }
    };
})();



