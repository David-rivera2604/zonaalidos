// Componente de Plan de Pago Resumen (Solo Visualización)
var app = app || {};

app.PlanPagoResumenComponent = (function () {
    let settings = {
        tableId: 'plandepagoresumenTbl',
        containerId: 'plandepagoresumenContainer',
        title: 'Plan de pago - Resumen',
        showTitle: true,
        onRowClick: null
    };

    let componentData = {
        planPago: []
    };

    function init(options) {
        settings = Object.assign(settings, options);
        setupTable();
    }

    function setupTable() {
        const columns = [
            {
                field: 'tip_situacion',
                title: 'Estado del recibo',
                sortable: false,
                halign: 'center',
                align: 'left',
                formatter: 'app.ui.StringFormatter'
            },
            {
                field: 'fec_efec_recibo',
                title: 'Fecha desde',
                sortable: false,
                halign: 'center',
                align: 'center',
                formatter: 'app.ui.DateFormatter'
            },
            {
                field: 'fec_vcto_recibo',
                title: 'Fecha hasta',
                sortable: false,
                halign: 'center',
                align: 'center',
                formatter: 'app.ui.DateFormatter'
            },
            {
                field: 'imp_neta',
                title: 'Prima neta',
                sortable: false,
                halign: 'center',
                align: 'right',
                formatter: 'app.ui.DecimalFormatter'
            },
            {
                field: 'imp_imptos',
                title: 'IVA',
                sortable: false,
                halign: 'center',
                align: 'right',
                formatter: 'app.ui.DecimalFormatter'
            },
            {
                field: 'imp_interes',
                title: 'Recargo por fraccionamiento',
                sortable: false,
                halign: 'center',
                align: 'right',
                formatter: 'app.ui.DecimalFormatter'
            },
            {
                field: 'imp_recibo',
                title: 'Importe total',
                sortable: false,
                halign: 'center',
                align: 'right',
                formatter: 'app.ui.DecimalFormatter'
            }
        ];

        $(`#${settings.tableId}`).bootstrapTable({
            uniqueId: 'plandepagoId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            columns: columns,
            onClickRow: function (row, $element, field) {
                if (settings.onRowClick && typeof settings.onRowClick === 'function') {
                    settings.onRowClick(row);
                }
            }
        });
    }

    function createSummaryInfo(data) {
        if (!data || data.length === 0) return null;

        const summary = data.reduce((acc, item) => {
            acc.totalPrimaNeta += item.imp_neta || 0;
            acc.totalIva += item.imp_imptos || 0;
            acc.totalRecargo += item.imp_interes || 0;
            acc.totalImporte += item.imp_recibo || 0;
            acc.totalCuotas += 1;
            return acc;
        }, {
            totalPrimaNeta: 0,
            totalIva: 0,
            totalRecargo: 0,
            totalImporte: 0,
            totalCuotas: 0
        });

        return summary;
    }

    function updateSummaryDisplay(summary) {
        if (!summary) return;

        // Actualizar elementos del resumen si existen
        $('#primaneta').text(app.ui.DecimalFormatter(summary.totalPrimaNeta));
        $('#iva').text(app.ui.DecimalFormatter(summary.totalIva));
        $('#recardoporfraccionamiento').text(app.ui.DecimalFormatter(summary.totalRecargo));
        $('#importetotal').text(app.ui.DecimalFormatter(summary.totalImporte));
        $('#cuotas').text(summary.totalCuotas);
    }

    function show() {
        $(`#${settings.containerId}`).removeClass('d-none');
        if (settings.showTitle) {
            $(`#${settings.containerId} h4`).show();
        }
    }

    function hide() {
        $(`#${settings.containerId}`).addClass('d-none');
    }

    // API Pública
    return {
        init: init,
        loadData: function (planPagoData) {
            componentData.planPago = planPagoData || [];

            if (planPagoData && planPagoData.length > 0) {
                $(`#${settings.tableId}`).bootstrapTable('load', planPagoData);

                // Calcular y mostrar resumen
                const summary = createSummaryInfo(planPagoData);
                updateSummaryDisplay(summary);

                show();
            } else {
                $(`#${settings.tableId}`).bootstrapTable('load', []);
                hide();
            }
        },
        getData: function () {
            return $(`#${settings.tableId}`).bootstrapTable('getData');
        },
        getSummary: function () {
            return createSummaryInfo(componentData.planPago);
        },
        show: show,
        hide: hide,
        refresh: function () {
            $(`#${settings.tableId}`).bootstrapTable('refresh');
        },
        destroy: function () {
            $(`#${settings.tableId}`).bootstrapTable('destroy');
        }
    };
})();