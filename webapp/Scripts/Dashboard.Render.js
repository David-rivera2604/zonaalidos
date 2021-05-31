var app = app || {};

app.ViewerDashboard = (function () {

    var _id = null;

    function view99(data) {
        var l1 = [...new Set(data.map(item => 'Mes ' + item.Mes))];
        var d1 = [...new Set(data.map(item => item.Cantidad))];
        //var categories = [...new Set(data.map(item => item.MONTH))];
        //var series = [...new Set(data.map(item => item.BRANCHOFFICE))].map(item => ({ name: item, data: {} }));
        //series.forEach(function (val, index, theArray) {
        //    val.data = data.filter(function (e) { return e.BRANCHOFFICE == val.name }).map(item => item.POLICYCOUNT);
        //});

        // line, area, bar, radar
        // Candlerstick, Heat, Pie/Donut, rangeBar, radialBar
        var options = {
            chart: {
                width: "100%",
                height: 380,
                type: 'donut',
                toolbar: {
                    show: true,
                    offsetX: 0,
                    offsetY: 0,
                    tools: {
                        download: true,
                        selection: false,
                        zoom: false,
                        zoomin: false,
                        zoomout: false,
                        pan: false,
                        reset: false | '<img src="/static/icons/reset.png" width="20">',
                        customIcons: []
                    },
                    autoSelected: 'zoom'
                }
            },
            labels: l1,
            dataLabels: {
                enabled: true,
            },
            series: d1,
        }

        var chart = new ApexCharts(document.querySelector("#chart"), options);

        chart.render();
    }

    function view15(data) {
        $('#w5 h2').html(data[0].TOTALPOLIZAS);
    }

    function view16(data) {

        var format = function (str, col) {
            col = typeof col === 'object' ? col : Array.prototype.slice.call(arguments, 1);

            return str.replace(/\{\{|\}\}|\{(\w+)\}/g, function (m, n) {
                if (m == "{{") { return "{"; }
                if (m == "}}") { return "}"; }
                return col[n];
            });
        };

        data.forEach(function (val, index, theArray) {
            $('#w6 .stat-list').append(format('<li><h2 class="no-margins">{CANTIDAD}</h2><small>{SUCURSAL}</small><div class="stat-percent">{PORCENTAJE}%</div><div class="progress progress-mini"><div style="width: {PORCENTAJE}%;" class="progress-bar"></div></div></li>', val));
        });
    }

    function view13(data) {
        var categories = [...new Set(data.map(item => item.MONTH))];
        var series = [...new Set(data.map(item => item.BRANCHOFFICE))].map(item => ({ name: item, data: {} }));
        series.forEach(function (val, index, theArray) {
            val.data = data.filter(function (e) { return e.BRANCHOFFICE == val.name }).map(item => item.POLICYCOUNT);
        });

        // line, area, bar, radar
        // Candlerstick, Heat, Pie/Donut, rangeBar, radialBar
        var options = {
            chart: {
                width: "100%",
                height: 380,
                type: 'line',
                dropShadow: {
                    enabled: true,
                    color: '#000',
                    top: 18,
                    left: 7,
                    blur: 10,
                    opacity: 0.2
                },
                toolbar: {
                    show: true,
                    offsetX: 0,
                    offsetY: 0,
                    tools: {
                        download: true,
                        selection: false,
                        zoom: false,
                        zoomin: false,
                        zoomout: false,
                        pan: false,
                        reset: false | '<img src="/static/icons/reset.png" width="20">',
                        customIcons: []
                    },
                    autoSelected: 'zoom'
                }
            },
            dataLabels: {
                enabled: true,
            },
            series: series,
            legend: {
                position: 'top',
                horizontalAlign: 'left',
            },
            xaxis: {
                categories: categories,
                title: {
                    text: 'Mes'
                }
            },
            yaxis: {
                title: {
                    text: 'Cantidad de pólizas'
                }
            }
        }

        var chart = new ApexCharts(document.querySelector("#chart"), options);

        chart.render();
    }

    return {
        Init: function () {
            var name = localStorage.getItem('Tenant');
            name = name.replace('á', 'a');

            switch (localStorage.getItem('Tenant')) {
                case 'Coopeservidores':
                    $('#vida').removeClass('d-none');
                    $('#saldoDeudor').removeClass('d-none');
                    $('#saldoDeudorLink').attr('href', '../policy/Edit?alias=cope_saldo_deudor');
                    break;
                case 'Carrofácil':
                    $('#saldoDeudor').removeClass('d-none');
                    $('#saldoDeudorLink').attr('href', '../policy/Edit?alias=carrofacil_saldo_deudor');
                    break;
            }


            _id = app.core.URLStringValue('id');
            if (_id != '') {
                app.core.Get(app.setting.apipath + 'v1/datasource/json?id=15&sequence=1')
                    .done(function (data, textStatus, jqXHR) {
                        view15(data);
                    });
                app.core.Get(app.setting.apipath + 'v1/datasource/json?id=16&sequence=1')
                    .done(function (data, textStatus, jqXHR) {
                        view16(data);
                    });
                app.core.Get(app.setting.apipath + 'v1/datasource/json?id=13&sequence=1')
                    .done(function (data, textStatus, jqXHR) {
                        view13(data);
                    });

                //app.core.GetView(app.setting.apipath + 'v1/Viewer/MicroView?id=1')
                //    .done(function (data, textStatus, jqXHR) {
                //        $("#aqui").append(data);
                //    });
                // app.core.Get(app.setting.apipath + 'v1/Viewer/DataFactory?id=99')
                //     .done(function (data, textStatus, jqXHR) {
                //         view99(data);
                //     });				
            }
        }
    };
})();
