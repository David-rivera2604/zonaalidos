var app = app || {};

app.policyview = (function () {

    function Refresh() {
        var filter = 'filter=' + $('#PolicySearch').val() +
            '&lineOfBusiness=' + app.ui.GetDropDownNumericValue('#LineOfBusiness').toString() +
            '&product=' + app.ui.GetDropDownNumericValue('#ProductByLineOfBusiness').toString();

        var statusFltVal = $('#StatusFlt').select2('data').map(function (item) { return item['id']; }).toString();
        if (statusFltVal != '')
            statusFltVal = '&status=' + statusFltVal;

        $('#TABLE10_GridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/Policy/View?' + filter + statusFltVal)
            .done(function (data, textStatus, jqXHR) {
                $('#TABLE10_GridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#TABLE10_GridTbl').bootstrapTable('hideLoading');
            });
    }

    function Init_Controls() {

        $('.tool-new').on('click', function (e) {
            window.location.replace(app.setting.basepath + 'Policy/Products');
        });

        $('#StatusFlt').select2({ width: '100%', theme: 'bootstrap4' });

        //detailView: true,
        //detailViewByClick: true,

        $('#TABLE10_GridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            buttonsClass: "outline btn-default",
            detailFormatter: function (index, row) {
                var html = [];
                var columns = $(this).bootstrapTable('getOptions')[0].columns[0];
                $.each(columns, function (key, column) {
                    html.push('<p>');
                    html.push('<b>' + column.title + ':</b> ');
                    if (typeof column.formatter === 'function')
                        html.push(column.formatter(row[column.field], row, key, column.field));
                    else
                        html.push(row[column.field]);
                    html.push('</p>');
                })


                return html.join('')
            },
            rowStyle: function (row, index) {
                return {
                    css: {
                        'vertical-align': 'top'
                    }
                }
            },
            columns: [{
                field: 'IssueDate',
                title: 'Inclusión',
                sortable: true,
                halign: 'center',
                align: 'center',
                formatter: 'app.ui.DateFormatter',
                cellStyle: function (value, row, index) {
                    return {
                        css: {
                            'vertical-align': 'top',
                            'white-space': 'nowrap'
                        }
                    }
                }
            }, {
                field: 'PolicyId',
                title: 'Póliza',
                class: 'd-none d-sm-table-cell',
                sortable: true,
                    halign: 'center',
                    align: 'left',
                formatter: function (value, row, index, field) {
                    return '<a class="update edit" href="edit?id=' + row.Id + '" title="Al hacer click permite la edición de los datos">' + value + '</a>';
                }
            }, {
                field: 'Status',
                title: 'Estado',
                class: 'd-none d-sm-table-cell',
                sortable: true,
                halign: 'center',
                align: 'left',
                formatter: 'app.policy_common.PolicyStatusFormatter'
            }, {
                title: 'Acciones',
                class: 'd-none d-sm-table-cell',
                sortable: false,
                halign: 'center',
                align: 'center',
                events: 'TABLE10_GridTbl_Events',
                formatter: function (value, row, index, field) {
                    var html = [];
                    html.push('<button type="button" class="btn btn-sm btn-white print" title="Permite imprimir la póliza"');
                    if (row.StatusCode !== 10 && row.StatusCode !== 2)
                        html.push('disabled');
                    html.push('><i class="fa fa-print"></i> </button>');

                    html.push('<button type="button" class="btn btn-sm btn-white modify" title="Permite modifica la póliza"');
                    if (row.StatusCode !== 10)
                        html.push('disabled');
                    html.push('> <i class="fa fa-pencil"></i> </button>');

                    html.push('<button type="button" class="btn btn-sm btn-white cancel" title="Permite cancelar la póliza"');
                    if (row.StatusCode !== 10)
                        html.push('disabled');
                    html.push('> <i class="fa fa-close"></i> </button>');
                    return html.join('');

                    //'<button class="btn btn-white btn-xs"> Tag</button>';


                },
                cellStyle: function (value, row, index) {
                    return {
                        css: {
                            'white-space': 'nowrap',
                            'vertical-align': 'top'
                        }
                    }
                }
            }, {
                field: 'InsuredName',
                title: 'Asegurado',
                sortable: true,
                halign: 'center',
                align: 'left',
                formatter: function (value, row, index, field) {
                    return '<span>' + value + '</span><br><span class="d-none d-sm-inline">' + row.InsuredNumber + '</span>';
                },
                cellStyle: function (value, row, index) {
                    return {
                        css: {
                            'white-space': 'nowrap',
                            'vertical-align': 'top'
                        }
                    }
                }
            }, {
                field: 'LineOfBusiness',
                title: 'Ramo',
                class: 'd-none d-sm-table-cell',
                sortable: true,
                halign: 'center',
                align: 'left'
            }, {
                field: 'Product',
                title: 'Producto',
                class: 'd-none d-sm-table-cell',
                sortable: true,
                halign: 'center',
                align: 'left'
            }, {
                field: 'Module',
                title: 'Plan',
                class: 'd-none d-sm-table-cell',
                sortable: true,
                halign: 'center',
                align: 'left'
            }, {
                field: 'EffectiveDate',
                title: 'Inicio',
                class: 'd-none d-sm-table-cell',
                titleTooltip: 'Inicio de vigencia',
                sortable: true,
                halign: 'center',
                align: 'center',
                formatter: 'app.ui.DateFormatter'
            }, {
                field: 'EndingDate',
                title: 'Fin',
                class: 'd-none d-sm-table-cell',
                titleTooltip: 'Fin de vigencia',
                sortable: true,
                halign: 'center',
                align: 'center',
                formatter: 'app.ui.DateFormatter'
            }, {
                field: 'Currency',
                class: 'd-none d-sm-table-cell',
                title: 'Moneda',
                sortable: true,
                halign: 'center',
                align: 'left'
            }, {
                field: 'CancellationDate',
                class: 'd-none d-sm-table-cell',
                title: 'Baja',
                sortable: true,
                halign: 'center',
                align: 'center',
                formatter: function (value, row, index, field) {
                    var result = '';
                    if (value === null || value === '0001-01-01T00:00:00')
                        result = '';
                    else
                        result = '<span>' + moment(value).format('DD/MM/YYYY') + '</span>';

                    if (result !== '')
                        result += '<br><span>(' + row.ReasonForStatus + ')</span>';

                    return result;
                }
            }, {
                field: 'InsuredAmount',
                title: 'Suma asegurada',
                class: 'd-none d-sm-table-cell',
                sortable: true,
                halign: 'center',
                align: 'right',
                formatter: 'app.ui.DecimalFormatter'
            }, {
                field: 'AnnualPremium',
                title: 'Prima anual',
                class: 'd-none d-sm-table-cell',
                sortable: true,
                halign: 'center',
                align: 'right',
                formatter: 'app.ui.DecimalFormatter'
            }]
        });
    };

    function Event_Controls() {
        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });
        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });
        $('.tool-excel-export').on('click', function (e) {
            app.core.GetPDF(app.setting.apipath + 'v1/DataSource/excel?id=14', true, 'polizas.xlsx');
        });
        $("#PolicySearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });
        $('#PolicyApplyFilter').on('click', function (e) {
            Refresh();
        });
    };

    function Init_Lookups() {
        app.core.Lookups(['LineOfBusiness.LineOfBusiness.', 'PolicyStatus.StatusFlt'], Dynamic_Event_Controls);


        // Dependencies
        $('#LineOfBusiness').on('change', function () {
            app.core.LookupDependency($('select#LineOfBusiness').val(), 'ProductByLineOfBusiness', 'ProductByLineOfBusiness', '', null, true);
        });

        // app.core.Lookups(['PolicyStatus.StatusFlt'], Dynamic_Event_Controls);

    };

    function Dynamic_Event_Controls() {
        $('#StatusFlt').select2({ width: '100%', theme: 'bootstrap4' });
        var _statusFlt = app.core.URLStringValue('status');
        if (_statusFlt !== '') {
            $('#StatusFlt').select2('val', _statusFlt.split(','));
            Refresh();
        }
    };

    return {
        Init: function () {
            Init_Controls();
            Event_Controls();
            Init_Lookups();

            var _statusFlt = app.core.URLStringValue('status');

            if (_statusFlt == '')
                Refresh();

        }
    };
})();
window.TABLE10_GridTbl_Events = {
    'click .print': function (e, value, row, index) {
        app.policy_common.Print(row.Id);
        e.stopPropagation();
    },
    'click .modify': function (e, value, row, index) {
        window.location.replace(app.setting.basepath + 'Policy/edit?id=' + row.Id + '&navmode=modify');
        e.stopPropagation();
    },
    'click .cancel': function (e, value, row, index) {

        window.location.replace(app.setting.basepath + 'Policy/edit?id=' + row.Id + '&navmode=cancel');
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        window.location.replace(app.setting.basepath + 'Policy/edit?id=' + row.Id + '&navmode=query');
        e.stopPropagation();
    }
};
