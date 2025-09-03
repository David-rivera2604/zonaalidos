// Componente de Terceros (Solo Visualización)
var app = app || {};

app.TercerosDisplayComponent = (function () {
    let settings = {
        tableId: 'tercerosTbl',
        title: 'Terceros',
        showActions: false,
        onRowClick: null
    };

    let componentData = {
        terceros: []
    };

    function init(options) {
        settings = Object.assign(settings, options);
        setupTable();
    }

    function setupTable() {
        const columns = [
            {
                field: 'tipodeterceroDesc',
                title: 'Tipo de tercero',
                sortable: false,
                halign: 'center',
                align: 'left',
                formatter: 'app.ui.StringFormatter'
            },
            {
                field: 'DocumentNumber',
                title: 'Identificación',
                sortable: false,
                halign: 'center',
                align: 'left',
                formatter: 'app.ui.StringFormatter'
            },
            {
                field: 'nombre',
                title: 'Nombre completo',
                sortable: false,
                halign: 'center',
                align: 'left',
                formatter: function (value, row, index, field) {
                    let name = value + (row.apellido1 ? ' ' + row.apellido1 : '');
                    return `<span>${name}</span>`;
                }
            },
            {
                field: 'fechadenacimiento',
                title: 'Nacimiento',
                sortable: false,
                halign: 'center',
                align: 'center',
                formatter: 'app.ui.DateFormatter'
            },
            {
                field: 'numerodetelefono',
                title: 'Teléfono',
                sortable: false,
                halign: 'center',
                align: 'left',
                formatter: 'app.ui.StringFormatter'
            },
            {
                field: 'correoelectronico',
                title: 'Correo electrónico',
                sortable: false,
                halign: 'center',
                align: 'left',
                formatter: 'app.ui.StringFormatter'
            }
        ];

        // Agregar columna de acciones si está habilitada
        if (settings.showActions) {
            columns.push({
                field: 'Actions',
                title: 'Acciones',
                class: 'd-none d-sm-table-cell',
                sortable: false,
                halign: 'center',
                align: 'center',
                width: 10,
                widthUnit: "%",
                events: `${settings.tableId}_Events`,
                formatter: function (value, row, index, field) {
                    return '<button type="button" class="btn btn-sm btn-white view" title="Ver detalles del tercero"> <i class="fa fa-eye"></i> </button>';
                }
            });
        }

        $(`#${settings.tableId}`).bootstrapTable({
            uniqueId: 'tercerosId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            columns: columns
        });

        // Configurar eventos si se permiten acciones
        if (settings.showActions) {
            window[`${settings.tableId}_Events`] = {
                'click .view': function (e, value, row, index) {
                    e.stopPropagation();
                    if (settings.onRowClick && typeof settings.onRowClick === 'function') {
                        settings.onRowClick(row);
                    }
                }
            };
        }
    }

    // API Pública
    return {
        init: init,
        loadData: function (terceros) {
            componentData.terceros = terceros || [];
            if (terceros) {
                $(`#${settings.tableId}`).bootstrapTable('load', terceros);
            }
        },
        getData: function () {
            return $(`#${settings.tableId}`).bootstrapTable('getData');
        },
        refresh: function () {
            $(`#${settings.tableId}`).bootstrapTable('refresh');
        },
        destroy: function () {
            $(`#${settings.tableId}`).bootstrapTable('destroy');
            if (settings.showActions) {
                delete window[`${settings.tableId}_Events`];
            }
        }
    };
})();