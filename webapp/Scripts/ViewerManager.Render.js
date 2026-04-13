var app = app || {};

app.ViewerQuery = (function () {
    let _handler = null;
    var _id = null;
    var _data;
    var _itemHeader = '  <li class="nav-item"> ' +
        '    <a class="nav-link {show}{class}" id="{index}_htab" data-type="{type}" data-tablename="{tablename}" data-toggle="tab" href="#tab_{index}" >{title}</a> ' +
        '  </li> ';

    var _itemBody = '<div class="tab-pane fade {show}" id="tab_{index}">' +
        ' {Body} ' +
        '</div>';

    var _itemTable = '<!-- Grid -->  ' +
        '{BodyFilter} ' +
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

    var _itemAvanceFilter = '						<div class="col-sm-12 col-md-12"> ' +
        '							<div class="form-group"> ' +
        '							<label class="control-label" for="BirthDate">Fecha de nacimiento</label> ' +
        '							<div class="input-group date" id="BirthDate_group"> ' +
        '									<input type="text" id="BirthDate" name="BirthDate" class="form-control" size="10" maxlength="10" placeholder="día/mes/año" /> ' +
        '									<span class="input-group-addon"> ' +
        '										<span class="glyphicon glyphicon-calendar"></span> ' +
        '									</span> ' +
        '								</div> ' +
        '								<div id="BirthDate_validate"></div> ' +
        '							</div> ' +
        '						</div> ';

    _itemAvanceFilter = '<div class="ibox"> ' +
        ' {Body} ' +
        '</div>';

    function ApplyQueryTitleTranslation(translations) {
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
            if ($("#QueryTitle").length === 1)
                $("#QueryTitle").text(titleText);

            $('html head').find('title').text(titleText);
        }

        if (titleAttr && $("#QueryTitle").length === 1)
            $("#QueryTitle").attr('title', titleAttr);
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
                        ApplyQueryTitleTranslation(translations);
                    }
                )();
            }
        )();
    }

    function RenderTabHeader(item) {
        body = app.core.ReplaceAll(_itemHeader, "{index}", item.index);
        body = app.core.ReplaceAll(body, "{title}", item.title);
        body = app.core.ReplaceAll(body, "{type}", item.type);
        body = app.core.ReplaceAll(body, "{tablename}", "#" + item.index + "GridTbl");

        if (item.class != undefined) {
            body = app.core.ReplaceAll(body, "{class}", ' ' + item.class);
        } else {
            body = app.core.ReplaceAll(body, "{class}", '');
        }

        var show = "";
        if (item.index === 1)
            show = "active";
        body = app.core.ReplaceAll(body, "{show}", show);
        return body;
    }

    function RenderTabBody(item) {
        body = app.core.ReplaceAll(_itemBody, "{index}", item.index);
        show = ""
        if (item.index === 1)
            show = "active show";
        body = app.core.ReplaceAll(body, "{show}", show);
        body = app.core.ReplaceAll(body, "{Body}", RenderTabContentUI(item));
        return body;
    }

    function RenderTabContentUI(item) {
        var body = "";
        if (item.type != undefined && item.type == 'template') {
            body = Template_Render(item.template, item.data);
        }
        else {
            body = app.core.ReplaceAll(_itemTable, "{index}", item.index);
        }
        if (item.dialog != undefined && item.dialog.html != null) {
            var itemTemplate = app.core.GetFromBetween(item.dialog.html, '<!-- Edit Form -->', '<!-- Edit Form End -->');
            var itemName = app.core.GetFromBetween(itemTemplate, '@_#', '@_');
            var controlGrid = "'#" + item.index + "GridTbl'";
            itemTemplate = app.core.ReplaceAll(itemTemplate, '@_#' + itemName + '@_', controlGrid);
            itemTemplate = app.core.ReplaceAll(itemTemplate, '@_@_', "''");
            body = app.core.ReplaceAll(body, "{BodyFilter}", app.core.ReplaceAll(_itemAvanceFilter, "{Body}", itemTemplate));
        } else {
            body = app.core.ReplaceAll(body, "{BodyFilter}", "")
        }
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
            $("#QueryTitle").html(data.maintitle);
            $('html head').find('title').text(data.maintitle);
        }

        TranslateViewerTarget('body', translationEntity);




        if (data.chart != undefined) {
            var spec = data.table;
            if (data.chart != undefined) {
                $(gridControlName).addClass('d-none');
                Chart_Render(data.chart, data.table.data, data.index);
            }
        }
        else {
            if (data.dialog != undefined && data.dialog.html != null) {
                var code = app.core.ReplaceAll(data.dialog.code, ".Prototype", ".Prototype" + data.index);
                code = app.core.ReplaceAll(code, 'Init"', 'Init' + data.index + '"');
                eval(code);
                if (data.table.skipload === undefined || !data.table.skipload) {
                    if (data.table.skipfirstload === undefined || !data.table.skipfirstload) {
                        var nameClass = "Prototype" + data.index;
                        if (nameClass in app) {
                            app[nameClass]['Changed'](function (data) {
                                var gridControlName = "#" + index + "GridTbl";
                                app.ViewerQuery.Refresh(undefined, $(gridControlName), _id, '');
                            });
                        }
                    } else {
                        var nameClass = "Prototype" + data.index;
                        if (nameClass in app) {
                            app[nameClass]['Changed'](function (data) {
                                var gridControlName = "#" + index + "GridTbl";
                                $(gridControlName).bootstrapTable('load', []);
                            });
                        }
                    }
                }
            }
            if (data.type != 'template') {
                if (data.table != undefined) {
                    data.table.Direct = data.Direct;
                    if (!data.table.entity)
                        data.table.entity = data.entity || data.Entity || '';
                }
                Table_Render(data.table, data.index);
            }
        }
    }

    function Template_Render(template, data) {
        console.log(data);
        var compiledTemplate = Template7.compile(template);
        var result = compiledTemplate({ data: data });
        return result;
        //$('#tmpl').html(result);
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
        spec.id = gridControlName;
        spec.index = index;
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
                var id = `tbl${this.detailId}${index}`;
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

                $detail.append('<span class="detail-title">...</span>');
                $detail.append('<div class="table-responsive" style="background-color: white; margin: 0px 0px 0px 10px; padding-right: 10px"><table style="font-size: 11px" id="' + id + '"></table></div>');

                Child($detail.find('span'), $detail.find('table'), this.detailId, url, id, row);
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

        if (spec.data === undefined && spec.Direct)
            spec.ajax = "app.ViewerQuery.Refresh";
        else if (!spec.Direct)
            EventDirect(spec);

        if (spec.onAll != undefined) {
            spec.onAll = new Function(["name", "args"], "{ " + spec.onAll + "('" + index + "GridTbl', name, args); }");
        }
        
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
                    if (column.events != undefined) {
                        column.events = 'Local_Events';
                    }
                    if (column.colorstate != undefined) {
                        app.ViewerQuery.state[column.field] = column.colorstate;
                    }
                    if (column.style != undefined && column.style.startsWith('function ')) {
                        column.cellStyle = column.style.replace(/@_/g, '\\\'').parseFunction();
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
                if (column.events != undefined) {
                    column.events = 'Local_Events';
                }
                if (column.colorstate != undefined) {
                    app.ViewerQuery.state[column.field] = column.colorstate;
                }
                if (column.style != undefined && column.style.startsWith('function ')) {
                    column.cellStyle = column.style.replace(/@_/g, '\\\'').parseFunction();
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
        spec.onPostBody = function (data) {
            app.ui.CommonBehaviour();
            TranslateViewerTarget(gridControlName, spec.entity);
            let extendName = spec.extendName != undefined ? spec.extendName : "Extend";
            if (app[extendName] != undefined && app[extendName]['EventHandler'] != undefined && app[extendName]['EventHandler'] !== null) {
                app[extendName]['EventHandler'](spec.key, spec.index, 'onPostBody', spec);
            }
        };
        if (spec.skipfirstload != undefined && spec.skipfirstload) {
            spec.ajax = null;
        }


        //spec.contextMenu = '#context-menu';
        //spec.contextMenuButton = '.ns';
        //spec.onContextMenuItem = function (row, $el) {
        //    if($el.data("item") == "edit"){
        //        alert();
        //    }
        //        console.log(row);            
        //};
        //spec.beforeContextMenuRow = function (e, row, buttonElement) {
        //    let r = (buttonElement !=null && $(buttonElement).hasClass('ns'))
        //    return r;
        //};

        $(gridControlName).bootstrapTable(spec);
        TranslateViewerTarget(gridControlName, spec.entity);
        if (spec.searchStyle != undefined) {
            $('.search').width(spec.searchStyle);
        }
    }

    function Chart_Render(chartSpec, data, renderIndex) {
        var options = null;
        _data = data;

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

    function Child(title, $el, id, url, tableId, row) {
        app.core.Get(app.setting.apipath + 'v1/Viewer/QuerySpecification?id=' + id + '&url=' + window.location.search.slice(1).replace(/&/g, ':'))
            .done(function (data, textStatus, jqXHR) {
                var spec = data.table;
                if (!spec.entity)
                    spec.entity = data.entity || data.Entity || '';
                title.html(data.title.supplant(row));
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
                //spec.search = false;
                //spec.showExport = false;
                //spec.exportDataType = null;
                spec.toolbar = undefined;
                spec.showPaginationSwitch = false;
                spec.searchAlign = 'left';
                spec.showToggle = false;
                spec.showRefresh = false;
                spec.showColumns = false;
                spec.showColumnsToggleAll = false;
                spec.maintainMetaData = true;
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
                spec.onPostBody = function (data) {
                    app.ui.CommonBehaviour();
                    TranslateViewerTarget('#' + tableId, spec.entity);
                    let extendName = spec.extendName != undefined ? spec.extendName : "Extend";
                    if (app[extendName] != undefined && app[extendName]['EventHandler'] != undefined && app[extendName]['EventHandler'] !== null) {
                        app[extendName]['EventHandler'](spec.key, spec.index, 'onPostBody', spec);
                    }
                };
                spec.rowStyle = function (row, index) {
                    return {
                        css: {
                            'vertical-align': 'top'
                        }
                    }
                }
                //spec.onRefresh = function (params) {
                //    app.ViewerQuery.Refresh(params, $el);
                //};

                //NEW
                if (spec.detailId != undefined) {
                    spec.detailView = true;
                    //spec.detailId = 3;
                    //spec.detailParameters = "CompanyId=CompanyId:UserId=UserId";
                    spec.onExpandRow = function (index, row, $detail) {
                        var url = '';
                        var parentKey = '';
                        var key = '';
                        var parameters = this.detailParameters.split(":");
                        var id = `tbl${this.detailId}${index}`;
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

                        $detail.append('<span class="detail-title">...</span>');
                        $detail.append('<div class="table-responsive" style="background-color: white; margin: 0px 0px 0px 10px; padding-right: 10px"><table style="font-size: 11px" id="' + id + '"></table></div>');

                        Child($detail.find('span'), $detail.find('table'), this.detailId, url, id, row);
                    };
                }
                //NEW

                if (spec.onAll != undefined) {
                    spec.onAll = new Function(["name", "args"], "{ " + spec.onAll + "('" + tableId + "', name, args); }");
                }
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

                $el.bootstrapTable(spec);
                TranslateViewerTarget('#' + tableId, spec.entity);

                app.ViewerQuery.Refresh(undefined, $el, id, url);
            });
    };

    function EventDirect(item) {
        var name = app.core.ReplaceAll("#{index}_htab", "{index}", item.index);
        $(name).on('shown.bs.tab', function (e) {
            var type = this.getAttribute('data-type');
            if (type != 'template' && type != undefined) {
                var tableName = this.getAttribute('data-tablename');
                $(tableName).bootstrapTable('refreshOptions',
                    {
                        ajax: "app.ViewerQuery.Refresh"
                    });
                $(tableName).bootstrapTable('showLoading');
                $(tableName).bootstrapTable('refresh');
            }
        });
    }

    return {
        Init: function () {
            _id = app.core.URLStringValue('id');
            Event_Controls();
            if (_id != '')

                app.core.Get(app.setting.apipath + 'v1/Viewer/QuerySpecifications?id=' + _id + '&url=' + window.location.search.slice(1).replace(/&/g, ':'))
                    .done(function (data, textStatus, jqXHR) {
                        index = 0;
                        $('#queryTab').tab();

                        if (data.count > 1) {
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
                                            let extendName = item.extendName != undefined ? item.extendName : "Extend";
                                            if (app[extendName] != undefined && app[extendName]['EventHandler'] != undefined && app[extendName]['EventHandler'] !== null) {
                                                app[extendName]['EventHandler'](_id, item.index, 'loaded');
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
                            var OndemandChildren = false;
                            $("#container").empty();
                            data.items.forEach(function (item) {
                                index = index + 1;
                                item = JSON.parse(item);
                                item.index = index;
                                item.key = _id;
                                item.table.key = _id;
                                $("#container").append(RenderTabContentUI(item));
                                if (item.include !== null && item.include !== '') {

                                    if (item.include.startsWith('class:')) {
                                        let extendName = item.include.substring(6);
                                        let entityType = 'Render';
                                        app.core.Get(app.setting.apipath + `v1/CustomData/${extendName}/${entityType}/Data`)
                                            .done(function (data) {
                                                try {
                                                    app[extendName] = new Function(data)();
                                                    Render(item);
                                                    if (app[extendName] != undefined && app[extendName]['EventHandler'] != undefined && app[extendName]['EventHandler'] !== null) {
                                                        app[extendName]['EventHandler'](_id, item.index, 'loaded');
                                                    }
                                                } catch (error) {
                                                    console.error("Error al ejecutar el script:", error);
                                                }
                                            });
                                    } else {
                                        app.core.LoadScriptFile(item.include)
                                            .then(d => {
                                                Render(item);
                                                let extendName = item.table.extendName != undefined ? item.table.extendName : "Extend";
                                                if (app[extendName] != undefined && app[extendName]['EventHandler'] != undefined && app[extendName]['EventHandler'] !== null) {
                                                    app[extendName]['EventHandler'](_id, item.index, 'loaded');
                                                }
                                            })
                                            .catch(err => {
                                                console.error(err);
                                            });
                                    }

                                } else {
                                    Render(item);
                                }
                            });
                        }
                    });
            else
                $("#QueryTitle").html('Consulta no indicada');
        },
        Refresh: function (params, $el, xid, url, index, srcData, callback, force) {
            var element = $('#RoleMemberGridTbl');
            var id = _id;
            var doing = true;

            if (force === undefined) {
                force = false;
            }
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
            if (srcData != undefined) {
                for (var p in srcData) {
                    if (srcData.hasOwnProperty(p)) {
                        url += ':' + p + '=' + srcData[p];
                    }
                }
                if (url != undefined)
                    url = url.replace(/T00:00:00/g, '');
            }
            else {
                let options = element.bootstrapTable('getOptions');
                if (options.skipload != undefined && options.skipload && !force) {
                    element.bootstrapTable('load', []);
                    element.bootstrapTable('hideLoading');
                    doing = false;
                } else {

                    var nameClass = "Prototype" + index;
                    if (nameClass in app) {
                        if (app[nameClass]['IsValid'](false)) {
                            let dialogData = app[nameClass]["Data"]();
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
                }
            }

            if (doing) {
                element.bootstrapTable('showLoading');
                if (this.options?.URL != undefined) {
                    app.core.GetExt(app.setting.apipath + this.options.URL)
                        .done(function (data, textStatus, jqXHR) {
                            if (params === undefined)
                                element.bootstrapTable('load', data !== null ? data : []);
                            else
                                params.success(data !== null ? data : [])
                        }).always(function () {
                            element.bootstrapTable('hideLoading');
                        });
                }
                else {
                    if (params != undefined) {
                        params.multiQuery = this.options?.multiquery;
                    }
                    let originalUrl = window.location.search.slice(1).replace(/&/g, ':');
                    app.core.Get(app.setting.apipath + 'v1/datasource/json?id=' + id + '&sequence=' + index + '&url=' + originalUrl + url)
                        .done(function (data, textStatus, jqXHR) {
                            if (data == null)
                                data = [];
                            else {
                                if (!Array.isArray(data)) {
                                    if (params != undefined && params?.multiQuery != undefined)
                                        data = data[params.multiQuery];
                                    else
                                        data = Object.values(data)[0];
                                }
                            }
                            _data = data;
                            if (params === undefined)
                                element.bootstrapTable('load', data);
                            else
                                params.success(data)
                        }).always(function () {
                            element.bootstrapTable('hideLoading');
                            if (callback !== undefined && callback !== null) {
                                callback(_data);
                            }
                        });
                }
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
                    app.core.GetPDF(app.setting.apipath + 'v1/TronCommon/ImprimirAcreedor/' + row.NUM_POLIZA, false, 'Mapfre Certificado.pdf');
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
        Data: function () {
            return _data;
        },
        EventHandler: function (handler) {
            _handler = handler;
        }
    };
})();
app.ViewerQuery.state = {};
window.Local_Events = {
    'click .event': function (e, value, row, index) {
        e.stopPropagation();
        app.ViewerQuery.ButtonClick(this, e, e.currentTarget.name, row, index)
    }
};
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
