var app = app || {};

app.ViewerQuery = (function () {

    var _id = null;
    var _data;

    function Render(data) {
        gridControlName = "#" + data.index + "GridTbl";

        if ($("#QueryTitle").length === 1)
            $("#QueryTitle").html(data.title);
        else
            $('html head').find('title').text(data.title);

        if (data.maintitle != undefined) {
            $("#QueryMainTitle").html(data.maintitle);
            $('html head').find('title').text(data.maintitle);
        }

        if (data.type != undefined && data.type == 'template') {
            Template_Render(data.template, data.data);
        }
        else {
            var spec = data.table;

            if (data.chart != undefined) {
                $('#RoleMemberGridTbl').addClass('d-none');
                Chart_Render(data.chart, data.table.data);
            }
            else {

                if (data.dialog != undefined && data.dialog.html != null) {
                    let html = '<div class="col-md-12">' + data.dialog.html.replace('ibox-content', 'ibox-content2') + '</div>';
                    html = html.replace(/@_/g, '\'');
                    $('.advancefilter-row').html(html).removeClass('d-none');


                    eval(data.dialog.code);

                    app.Prototype.Changed(function (data) {
                        app.ViewerQuery.Refresh(undefined, $('#RoleMemberGridTbl'), _id, '');
                    });
                }

                Table_Render(data.table, data.index);
            }
        }


    }

    function Template_Render(template, data) {
        console.log(data);
        var compiledTemplate = Template7.compile(template);
        var result = compiledTemplate({ data: data });
        $('#tmpl').html(result);
    }

    function Table_Render(spec, index) {
        gridControlName = "#" + index + "GridTbl";

        //Defaults
        if (spec.classes === undefined) {
            spec.classes = "table table-bordered table-hover table-index";
        }
        else if (spec.classes.startsWith(':')) {
            spec.classes = spec.classes.substring(1);
        }
        else {
            spec.classes = "table table-bordered table-hover table-index " + spec.classes;
        }
        spec.index = index;
        spec.toolbar = "#toolbar";
        spec.buttonsClass = "outline btn-default";
        spec.exportDataType = "all";
        spec.smartDisplay = true;
        spec.clickToSelect = true;
        spec.showColumnsToggleAll = true;
        spec.searchAlign = 'left';
        spec.rowStyle = function (row, index) {
            return {
                css: {
                    'vertical-align': 'top'
                }
            }
        }
        //spec.detailFilter = function (index, row) {
        //    var result = true;
        //    //var columns = $("#RoleMemberGridTbl").bootstrapTable('getOptions').columns[0];
        //    //$.each(columns, function (key, column) {
        //    //    if (!column.visible) {
        //    //        result = true;
        //    //    }
        //    //})
        //    return result;
        //};

        if (spec.detailId != undefined) {
            spec.detailView = true;
            //spec.detailId = 3;
            //spec.detailParameters = "CompanyId=CompanyId:UserId=UserId";
            spec.onExpandRow = function (index, row, $detail) {
                var url = '';
                var parameters = this.detailParameters.split(":");
                for (i = 0; i < parameters.length; i++) {
                    url += ':' + parameters[i].split("=")[0] + '=';
                    if (parameters[i].split("=")[1].startsWith("const.")) {
                        url += parameters[i].split("=")[1].substring(6);
                    }
                    else {
                        url += row[parameters[i].split("=")[1]];
                    }
                }

                $detail.append('<span class="detail-title">...</span>');
                $detail.append('<div class="table-responsive" style="background-color: white; margin: 0px 0px 0px 10px;"><table style="font-size: 11px"></table></div>');

                Child($detail.find('span'), $detail.find('table'), this.detailId, url);
            };
        }
        else {
            if (spec.detailView != undefined && spec.detailView) {
                spec.detailFormatter = function (index, row, element) {
                    var html = [];
                    var columns = $(this).bootstrapTable('getOptions')[0].columns[0];
                    $.each(columns, function (key, column) {
                        if (!column.visible) {
                            html.push('<p>');
                            html.push('<b>' + column.title + ':</b> ');
                            if (typeof column.formatter === 'string')
                                html.push(window[column.formatter.split(".")[0]][column.formatter.split(".")[1]][column.formatter.split(".")[2]](row[column.field], row, key, column.field));
                            else if (typeof column.formatter === 'function')
                                html.push(column.formatter(row[column.field], row, key, column.field));
                            else
                                html.push(row[column.field]);
                            html.push('</p>');
                        }
                    })
                    return html.join('')
                };
            }
        }
        //spec.onRefresh = function (params) {
        //    app.ViewerQuery.Refresh();
        //};

        if (spec.data === undefined)
            spec.ajax = "app.ViewerQuery.Refresh";

        if (Array.isArray(spec.columns[0])) {
            spec.columns.forEach(function (group, gindex, garray) {
                group.forEach(function (column, index, array) {
                    if (column.formatter != undefined && column.formatter.startsWith('function ')) {
                        column.formatter = column.formatter.replace(/@_/g, '\\\'').parseFunction();
                    }
                    if (column.format != undefined) {
                        column.formatter = function (value, row, index, field) {
                            return column.format.supplant(row);
                        }
                    }
                });
            });
        }
        else {
            spec.columns.forEach(function (column, index, array) {
                if (column.formatter != undefined && column.formatter.startsWith('function ')) {
                    column.formatter = column.formatter.replace(/@_/g, '\\\'').parseFunction();
                }
                if (column.format != undefined) {
                    column.formatter = function (value, row, index, field) {
                        return column.format.supplant(row);
                    }
                }
            });
        }


        spec.icons = {
            paginationSwitchDown: 'fa-caret-square-o-down',
            paginationSwitchUp: 'fa-caret-square-o-up',
            refresh: 'fa-refresh',
            toggleOff: 'fa-toggle-off',
            toggleOn: 'fa-toggle-on',
            columns: 'fa-th-list',
            fullscreen: 'fa-arrows-alt',
            detailOpen: 'fa-angle-double-right',
            detailClose: 'fa-angle-double-down',
            export: 'fa-download'
        };
        $('#RoleMemberGridTbl').bootstrapTable(spec);

        if (spec.searchStyle != undefined) {
            $('.search').width(spec.searchStyle);
        }
    }

    function Chart_Render(chartSpec, data) {
        var options = null;
        _data = data;

        if (chartSpec.normalize === 'Months by years') {
            minYear = data.reduce(function (prev, curr) { return prev.YEAR < curr.YEAR ? prev : curr; }).YEAR;
            maxYear = data.reduce(function (prev, curr) { return prev.YEAR > curr.YEAR ? prev : curr; }).YEAR;

            var newData = [];
            var months = ["Enero", "Febreo", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre"];
            for (year = minYear; year <= maxYear; year++) {
                for (month = 1; month <= 12; month++) {
                    newData.push({ YEAR: year, MONTHNUM: month, MONTH: months[month - 1], COUNT: 0 });
                }
            }
            for (oldIndex = 0; oldIndex < data.length; oldIndex++) {
                for (newIndex = 0; newIndex < newData.length; newIndex++) {
                    if (newData[newIndex].YEAR === data[oldIndex].YEAR && newData[newIndex].MONTHNUM === data[oldIndex].MONTH) {
                        newData[newIndex].COUNT = data[oldIndex].COUNT;
                        continue;
                    }
                }
            }
            data = newData;
        }

        switch (chartSpec.type) {
            case 'pie':
            case 'donut':
                var chartLabels = [...new Set(data.map(item => item[chartSpec.labels]))];
                var chartData = [...new Set(data.map(item => item[chartSpec.values]))];
                if (chartSpec.options != undefined) {
                    options = chartSpec.options;
                }
                else
                    options = {
                        chart: {
                            width: "100%",
                            height: 380,
                            type: null
                        },
                        labels: null,
                        series: null
                    };
                options.chart.type = chartSpec.type;
                options.labels = chartLabels;
                options.series = chartData;
                break;

            case 'area':
            case 'bar':
            case 'line':
            case 'radar':
                var chartLabels = [...new Set(data.map(item => item[chartSpec.labels]))];
                var chartData = null;
                if (chartSpec.series != undefined) {
                    var series = [...new Set(data.map(item => item[chartSpec.series]))].map(item => ({ name: item, data: {} }));
                    series.forEach(function (val, index, theArray) {
                        val.data = data.filter(function (e) { return e[chartSpec.series] == val.name }).map(item => item[chartSpec.values]);
                    });
                    chartData = series;
                }
                else {
                    chartData = [{
                        name: '',
                        data: [...new Set(data.map(item => item[chartSpec.values]))]
                    }];
                }
                if (chartSpec.options != undefined) {
                    options = chartSpec.options;
                }
                else
                    options = {
                        chart: {
                            width: "100%",
                            height: 380,
                            type: null
                        },
                        series: null,
                        xaxis: {
                            categories: null,
                        }
                    };
                options.chart.type = chartSpec.type;
                options.series = chartData;
                options.xaxis.categories = chartLabels;
                break;
        };

        $('#chart').removeClass('d-none');
        var chart = new ApexCharts(document.querySelector("#chart"), options);

        chart.render();
    };

    function Event_Controls() {

        $('.tool-refresh').on('click', function (e) {
            event.preventDefault();
            app.ViewerQuery.Refresh();
        });

    };

    function Child(title, $el, id, url) {
        app.core.Get(app.setting.apipath + 'v1/Viewer/QuerySpecification?id=' + id + '&url=' + window.location.search.slice(1).replace(/&/g, ':'))
            .done(function (data, textStatus, jqXHR) {
                var spec = data.table;
                title.html(data.title);
                if (spec.classes === undefined) {
                    spec.classes = "table table-bordered table-hover table-index";
                }
                else if (spec.classes.startsWith(':')) {
                    spec.classes = spec.classes.substring(1);
                }
                else {
                    spec.classes = "table table-bordered table-hover table-index " + spec.classes;
                }
                //spec.toolbar = "#toolbar";
                spec.buttonsClass = "outline btn-default";
                spec.exportDataType = "all";
                spec.smartDisplay = true;
                spec.clickToSelect = true;
                spec.showColumnsToggleAll = true;

                spec.toolbar = undefined;
                spec.showExport = false;
                spec.showPaginationSwitch = false;
                spec.exportDataType = null;
                spec.search = false;
                spec.showToggle = false;
                spec.showRefresh = false;
                spec.showColumns = false;
                spec.showColumnsToggleAll = false;

                //spec.onRefresh = function (params) {
                //    app.ViewerQuery.Refresh(params, $el);
                //};

                $.each(spec.columns, function (key, column) {
                    if (column.formatter != undefined && column.formatter.startsWith('function ')) {
                        column.formatter = column.formatter.replace(/@_/g, '\\\'').parseFunction();
                    }
                });

                $el.bootstrapTable(spec);

                app.ViewerQuery.Refresh(undefined, $el, id, url);

            });
    };

    return {
        Init: function () {
            _id = app.core.URLStringValue('id');
            Event_Controls();
            if (_id != '')
                app.core.Get(app.setting.apipath + 'v1/Viewer/QuerySpecification?id=' + _id + '&url=' + window.location.search.slice(1).replace(/&/g, ':'))
                    .done(function (data, textStatus, jqXHR) {
                        Render(data);
                    }).always(function () {

                    });
            else
                $("#QueryTitle").html('Consulta no indicada');
        },
        Refresh: function (params, $el, xid, url, index) {
            var element = $('#RoleMemberGridTbl');
            var id = _id;
            var doing = true;
            if (index === undefined) {
                index = 1;
            }
            if ($el != undefined) {
                element = $el;
                id = xid;
            }
            else {
                element = $('#' + this.$el[0].id);
                url = '';
                index = this.options.index;
            }

            if (app.Prototype != undefined && app.Prototype != null) {
                if (app.Prototype.IsValid(false)) {
                    let dialogData = app.Prototype.Data();
                    for (var p in dialogData) {
                        if (dialogData.hasOwnProperty(p)) {
                            url += ':' + p + '=' + dialogData[p];
                        }
                    }
                    if (params != undefined)
                        url = url.replace(/T00:00:00/g, '');
                } else {
                    doing = false;
                    if (params === undefined)
                        element.bootstrapTable('load', []);
                    else
                        params.success([]);
                }
            }

            if (doing) {
                element.bootstrapTable('showLoading');
                app.core.Get(app.setting.apipath + 'v1/datasource/json?id=' + id + '&sequence=1&url=' + window.location.search.slice(1).replace(/&/g, ':') + url)
                    .done(function (data, textStatus, jqXHR) {
                        if (params === undefined)
                            element.bootstrapTable('load', data !== null ? data : []);
                        else
                            params.success(data !== null ? data : [])
                    }).always(function () {
                        element.bootstrapTable('hideLoading');
                    });
            }
        },
        TabRender: function (me) {
            event.preventDefault();

            window.open(me.href, "vdetail", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes, top=100, height=450, left=400, width=900");

        },
        Data: function () {
            return _data;
        }
    };
})();

//app.ui.ShowSideBar({
//    isExternal: true,
//    url: '/Aliados/viewer/render?id=666',
//    title: ""
//})

//app.ui.ShowSideBarEx({
//    isExternal: true,
//    url: '/Aliados/viewer/render?id=666',
//    title: ""
//})

//app.ui.ShowPopover({
//    url: '/Aliados/viewer/render?id=666',
//    width: 200,
//    height: 300,
//    isExternal: true,
//    title: " "
//}, $('.search-input'))

//app.ui.ShowModal({
//    url: '/Aliados/viewer/render?id=666',
//    isExternal: true,
//    width: 50,
//    height: 50,
//    title: ""
//})