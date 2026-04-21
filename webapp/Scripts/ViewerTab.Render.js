var app = app || {};


app.ViewerQuery = (function () {
    let _handler = null;
    var _id = null;
    var _itemHeader = '  <li class="nav-item"> ' +
        '    <a class="nav-link {show}{class}" id="{index}_htab" data-toggle="tab" href="#tab_{index}" >{title}</a> ' +
        '  </li> '

    var _itemBody = '<div class="tab-pane fade {show}" id="tab_{index}">{Body}</div>';

    var _itemTable = '<!-- Grid -->  ' +
        '<div id="QueryHNotify{index}"></div>' +
        '<div id="header{index}" class="d-none"> ' +
        '</div> ' +
        '<div id="{index}toolbar"> ' +
        '</div> ' +
        '<!-- Grid --> ' +
        '<div class="form-row"> ' +
        '	<div class="col-md-12"> ' +
        '		<div class="table-responsive" style="padding: 0px 2px 0px 2px;">  ' +
        '			<table id="{index}GridTbl" style="font-size: 11px"></table>  ' +
        '		</div>  ' +
        '		<div id="chart{index}" class="d-none">  ' +
        '		</div>  ' +
        '	</div>  ' +
        '</div>  ' +
        '<div id="QueryFNotify{index}"></div>';

    function ReplaceAll(string, search, replace) {
        return string.split(search).join(replace);
    }

    function ApplyQueryTitleTranslation(target, translations) {
        if (!translations)
            return;

        var queryTitleValue = translations.QueryTitle;
        if (!queryTitleValue)
            return;

        var titleText = null;
        var titleAttr = null;

        if (typeof queryTitleValue === 'string')
            titleText = queryTitleValue;
        else if (typeof queryTitleValue === 'object') {
            if (Object.prototype.hasOwnProperty.call(queryTitleValue, 'text'))
                titleText = queryTitleValue.text;
            if (Object.prototype.hasOwnProperty.call(queryTitleValue, 'title'))
                titleAttr = queryTitleValue.title;
        }

        if (titleText) {
            if ($("#QueryMainTitle").length === 1)
                $("#QueryMainTitle").text(titleText);

            $('html head').find('title').text(titleText);

            var $target = $(target || []);
            var $tabPane = $target.closest('.tab-pane');
            var tabPaneId = $tabPane.attr('id') || '';

            if (tabPaneId) {
                var $tabLink = $('#queryTab').find('a[href="#' + tabPaneId + '"]').first();
                if ($tabLink.length > 0)
                    $tabLink.text(titleText);
            }
        }

        if (titleAttr && $("#QueryMainTitle").length === 1)
            $("#QueryMainTitle").attr('title', titleAttr);
    }

    function TranslateViewerTarget(target, entity) {
        entity = $.trim(entity || '');
        if (!entity)
            return;

        app.language.translate(
            target,
            'viewer/ViewerManager',
            function () {
                app.language.translate(
                    target,
                    'viewer/' + entity,
                    function (translations) {
                        ApplyQueryTitleTranslation(target, translations);
                    }
                )();
            }
        )();
    }

    function resolveTableTranslationName(index, entity, defaultSuffix) {
        var normalizedEntity = $.trim(entity || '');
        var suffix = defaultSuffix || 'GridTbl';

        if (!normalizedEntity)
            return index + suffix;

        normalizedEntity = normalizedEntity.replace(/[^\w]/g, '');
        if (!normalizedEntity)
            return index + suffix;

        if (/(?:GridTbl|Tbl)$/i.test(normalizedEntity))
            return normalizedEntity;

        return normalizedEntity + suffix;
    }

    function RenderTabHeader(item) {
        body = ReplaceAll(_itemHeader, "{index}", item.index);
        body = ReplaceAll(body, "{title}", item.title);        
        if (item.class != undefined) {
            body = ReplaceAll(body, "{class}", ' ' + item.class);
        } else {
            body = ReplaceAll(body, "{class}", '');
        }
        var show = "";
        if (item.index === 1)
            show = "active";
        body = ReplaceAll(body, "{show}", show);
        return body;
    }

    function RenderTabBody(item) {
        body = ReplaceAll(_itemBody, "{index}", item.index);
        show = ""
        if (item.index === 1)
            show = "active show";
        body = ReplaceAll(body, "{show}", show);
        body = ReplaceAll(body, "{Body}", RenderTabContentUI(item));
        return body;
    }

    function RenderTabContentUI(item) {
        body = ReplaceAll(_itemTable, "{index}", item.index);
        return body;
    }

    function Render(data) {
        gridControlName = "#" + data.index + "GridTbl";
        var translationEntity = data.entity || data.Entity || (data.table ? data.table.entity : '');

        if ($("#QueryTitle").length === 1)
            $("#QueryTitle").html(data.title);
        else
            $('html head').find('title').text(data.title);

        if (data.maintitle != undefined) {
            $("#QueryMainTitle").html(data.maintitle);
            $('html head').find('title').text(data.maintitle);
        }

        TranslateViewerTarget('body', translationEntity);

        var spec = data.table;

        if (data.chart != undefined) {
            $(gridControlName).addClass('d-none');
            Chart_Render(data.chart, data.table.data, data.index);
        }
        else {
            if (data.dialog != undefined && data.dialog.html != null) {
                let html = '<div class="col-md-12">' + data.dialog.html.replace('ibox-content', 'ibox-content2') + '</div>';
                html = html.replace(/@_/g, '\'');
                $('#header' + data.index).html(html).removeClass('d-none');

                eval(data.dialog.code);
                eval("app.Prototype.Changed(function (data) { app.ViewerQuery.Refresh(undefined, $('" + gridControlName + "'), " + _id + ", ''); });");
            }
            Table_Render(data.table, data.index);
        }
    }

    function Table_Render(spec, index) {
        gridControlName = "#" + index + "GridTbl";
        var tableTranslationName = resolveTableTranslationName(index, spec.entity, 'GridTbl');

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
        spec.id = gridControlName;
        spec.index = index;
        if (!spec.entity)
            spec.entity = '';
        spec.toolbar = "#" + spec.index + "toolbar";
        spec.buttonsClass = "outline btn-default";
        spec.exportDataType = "all";
        spec.smartDisplay = true;
        spec.clickToSelect = true;
        spec.showColumnsToggleAll = true;
        spec.searchAlign = 'left';
        spec.maintainMetaData = true;
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
                var parentKey = '';
                var key = '';
                var parameters = this.detailParameters.split(":");
                for (i = 0; i < parameters.length; i++) {
                    url += ':' + parameters[i].split("=")[0] + '=';
                    if (parameters[i].split("=")[1].startsWith("const.")) {
                        url += parameters[i].split("=")[1].substring(6);
                    }
                    else {
                        parentKey += row[parameters[i].split("=")[1]];
                        url += row[parameters[i].split("=")[1]];
                    }
                }

                //$detail.append('<ul id="queryTabi" class="nav nav-tabs" role="tablist">' +
                //    RenderTabHeader({ index: 3002, title: 'Coberturas' }) +
                //    RenderTabHeader({ index: 3001, title: 'Recibos' }) +
                //    '</ul>'
                //);

                //$detail.append('<div id="queryTabContenti" class="tab-content" style="padding-top: 10px">' +
                //    RenderTabBody({ index: 3002, title: 'Coberturas' }) +
                //    RenderTabBody({ index: 3001, title: 'Recibos' }) +
                //    '</div>');

                var ids = [];
                if (typeof this.detailId === 'string')
                    ids = this.detailId.split(",");
                else
                    ids = this.detailId.toString().split(",");

                for (i = 0; i < ids.length; i++) {
                    key = parentKey + ids[i];
                    $detail.append('<span id="' + key + 'Title" class="detail-title">...</span>');
                    $detail.append('<div class="table-responsive" style="background-color: white; margin: 0px 0px 0px 0px;"><table id="' + key + 'Tbl" style="font-size: 11px"></table></div>');

                    Child($detail.find('#' + key + 'Title'), $detail.find('#' + key + 'Tbl'), ids[i], url);
                }


                //key = parentKey + 3002;
                //$detail.append('<span id="' + key + 'Title" class="detail-title">...</span>');
                //$detail.append('<div class="table-responsive" style="background-color: white; margin: 0px 0px 0px 0px;"><table id="' + key + 'Tbl" style="font-size: 11px"></table></div>');

                //Child($detail.find('#' + key + 'Title'), $detail.find('#' + key + 'Tbl'), 3002, url);

            };
        }
        else {
            if (spec.detailView != undefined && spec.detailView) {
                spec.detailFormatter = function (index, row, element) {
                    var html = [];
                    var columns = $(gridControlName).bootstrapTable('getOptions')[0].columns[0];
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

        $.each(spec.columns, function (key, column) {
            if (column.formatter != undefined && column.formatter.startsWith('function ')) {
                column.formatter = column.formatter.replace(/@_/g, '\\\'').parseFunction();
            }
            if (column.format != undefined) {
                column.formatter = function (value, row, index, field) {
                    return column.format.supplant(row);
                }
            }
            if (column.events != undefined) {
                column.events = 'Local_Events';
            }
            if (column.colorstate != undefined) {
                app.ViewerQuery.state[column.field] = column.colorstate;
            }
        });

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
        var originalOnPostBody = spec.onPostBody;
        spec.onPostBody = function (data) {
            app.ui.CommonBehaviour();
            TranslateViewerTarget(gridControlName, spec.entity);
            if ($.isFunction(originalOnPostBody))
                originalOnPostBody.call(this, data);
        };
        //spec.onAll = function (name, args) {
        //    console.log(name, args);
        //};
        //spec.onClickCell = function (e, field, value, row, $element) {
        //    console.log(e);
        //    console.log(field);
        //    console.log(value);
        //    console.log(row);
        //    console.log($element);
        //};

        $(gridControlName).attr('name', tableTranslationName);
        $(gridControlName).bootstrapTable(spec);
        TranslateViewerTarget(gridControlName, spec.entity);
        if (spec.searchStyle != undefined) {
            $('.search').width(spec.searchStyle);
        }
    }

    function Chart_Render(chartSpec, data, renderIndex) {
        var options = null;

        if (chartSpec.normalize === 'Months by years' && data.length > 0) {
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

        $('#chart' + renderIndex).removeClass('d-none');
        var chart = new ApexCharts(document.querySelector('#chart' + renderIndex), options);

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
                var tableTranslationName = null;
                if (!spec.entity)
                    spec.entity = data.entity || data.Entity || '';
                tableTranslationName = resolveTableTranslationName(id, spec.entity, 'Tbl');
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
                spec.maintainMetaData = true;

                var originalOnPostBody = spec.onPostBody;
                spec.onPostBody = function (data) {
                    app.ui.CommonBehaviour();
                    TranslateViewerTarget('#' + $el.attr('id'), spec.entity);
                    if ($.isFunction(originalOnPostBody))
                        originalOnPostBody.call(this, data);
                };

                //spec.onRefresh = function (params) {
                //    app.ViewerQuery.Refresh(params, $el);
                //};

                $.each(spec.columns, function (key, column) {
                    if (column.formatter != undefined && column.formatter.startsWith('function ')) {
                        column.formatter = column.formatter.replace(/@_/g, '\\\'').parseFunction();
                    }
                    if (column.format != undefined) {
                        column.formatter = function (value, row, index, field) {
                            return column.format.supplant(row);
                        }
                    }
                    if (column.events != undefined) {
                        column.events = 'Local_Events';
                    }
                    if (column.colorstate != undefined) {
                        app.ViewerQuery.state[column.field] = column.colorstate;
                    }
                });

                $el.attr('name', tableTranslationName);
                $el.bootstrapTable(spec);
                TranslateViewerTarget('#' + $el.attr('id'), spec.entity);

                app.ViewerQuery.Refresh(undefined, $el, id, url);

            });
    };

    return {
        Init: function () {
            _id = app.core.URLStringValue('id');
            Event_Controls();
            if (_id != '')

                app.core.Get(app.setting.apipath + 'v1/Viewer/QuerySpecifications?id=' + _id + '&url=' + window.location.search.slice(1).replace(/&/g, ':'))
                    .done(function (data, textStatus, jqXHR) {
                        index = 0;
                        $('#queryTab').tab();
                        if (data.count > 0) {
                            data.items.forEach(function (item) {
                                index = index + 1;
                                item = JSON.parse(item);
                                item.index = index;
                                $("#queryTab").append(RenderTabHeader(item));
                                $("#queryTabContent").append(RenderTabBody(item));
                                if (item.include !== null && item.include !== '') {
                                    app.core.LoadScriptFile(item.include)
                                        .then(d => {
                                            Render(item);
                                            if (app.Extend !== undefined && app.Extend.EventHandler !== undefined && app.Extend.EventHandler !== null) {
                                                app.Extend.EventHandler(_id, item.index, 'loaded');
                                            }
                                        })
                                        .catch(err => {
                                            console.error(err);
                                        });
                                } else {
                                    Render(item);
                                }


                            });
                        }
                        else {
                            $("#container").empty();
                            data.items.forEach(function (item) {
                                index = index + 1;
                                item = JSON.parse(item);
                                item.index = index;
                                $("#container").append(RenderTabContentUI(item));
                                Render(item);
                            });
                        }

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
                element = $(this.options.id);
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
                    if (url != undefined)
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
                app.core.Get(app.setting.apipath + 'v1/datasource/json?id=' + id + '&sequence=' + index + '&url=' + window.location.search.slice(1).replace(/&/g, ':') + url)
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
        TabRender: function (me, href) {
            event.preventDefault();
            if (me != null) {
                href = me.href;
            }

            window.open(href, "vdetail", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes, top=100, height=450, left=400, width=900");

        },
        ButtonClick: function (tbl, e, name, row, index) {
            switch (name) {
                case 'print':
                    app.core.GetPDF(app.setting.apipath + 'v1/TronCommon/ImprimirPoliza/' + row.NUM_POLIZA + "/" + row.NUM_RIESGO, false, 'Mapfre Certificado.pdf');
                    break;
                case 'printid':
                    app.core.GetPDF(app.setting.apipath + 'v1/TronCommon/ImprimirSegunId/' + row.ID_REPORTE, false, 'Mapfre Certificado.pdf');
                    break;
                case 'printCreditor':
                    app.core.GetPDF(app.setting.apipath + 'v1/TronCommon/ImprimirAcreedor/' + row.NUM_POLIZA , false, 'Mapfre Certificado.pdf');
                    break;
                case 'printr':
                    let reportPath = 'Recibo';
                    if (row.TIP_SITUACION == 'CT') {
                        reportPath = 'DepositoPrima';
                        if (app.ui.IsSameDate(row.FEC_SITUACION, new Date())) {
                            reportPath = 'DepositoPrimaHoy';
                        }                      
                    }
                    app.core.GetPDF(app.setting.apipath + 'v1/TronCommon/Imprimir' + reportPath + '/' + row.NUM_RECIBO, false, 'Mapfre ' + reportPath + '.pdf')
                        .done(function (data, textStatus, jqXHR) {
                            window.open(data);
                        });
                    break;

                default:
                    $.each(tbl.columns, function (key, column) {
                        if (typeof column['action_' + name] != "undefined") {
                            eval(column['action_' + name].supplant(row));
                        }
                    })
                    break;
            }
        },
        EventHandler: function (handler) {
            _handler = handler;
        }
    }
})();
app.ViewerQuery.state = {};

window.Local_Events = {
    'click .event': function (e, value, row, index) {
        e.stopPropagation();
        app.ViewerQuery.ButtonClick(this, e, e.currentTarget.name, row, index)
    }
};
