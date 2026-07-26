var app = app || {};

app.ViewerQuery = (function () {

    let _handler = null;
    var _id = null;
    var _data;

    function getTranslationTextFromValue(translationValue) {
        if (!translationValue)
            return null;

        if (typeof translationValue === 'string')
            return translationValue;

        if (typeof translationValue === 'object' && Object.prototype.hasOwnProperty.call(translationValue, 'text'))
            return translationValue.text;

        return null;
    }

    function getTranslationAttributeFromValue(translationValue, attributeName) {
        if (!translationValue || typeof translationValue !== 'object')
            return null;

        return translationValue[attributeName] || null;
    }

    function applyViewerGroupTranslation($scope, key, translationValue) {
        var $group = $scope.find('#' + key);
        if ($group.length === 0)
            $group = $scope.find('[id^="' + key + '"]');

        if ($group.length > 1)
            $group = $group.first();

        var $input = $group.find('input, textarea, select').first();
        var inputId = $input.attr('id');
        var text = getTranslationTextFromValue(translationValue);
        var title = getTranslationAttributeFromValue(translationValue, 'title');
        var placeholder = getTranslationAttributeFromValue(translationValue, 'placeholder');
        var $label = inputId ? $scope.find('label[for="' + inputId + '"]').first() : $();

        if ($group.length === 0 || $input.length === 0)
            return;

        if (placeholder)
            $input.attr('placeholder', placeholder);
        else if (text)
            $input.attr('placeholder', text);

        if (title)
            $input.attr('title', title);
        else if (text)
            $input.attr('title', text);

        if ($label.length > 0 && text) {
            var $requiredMark = $label.find('.required-mark').detach();
            $label.text(text);
            if ($requiredMark.length > 0)
                $label.append($requiredMark);
        }
    }

    function applyViewerCommonFieldTranslations(target, translations) {
        var $scope = $(target || document.body);
        if ($scope.length === 0 || !translations)
            return;

        $.each(translations, function (key, translationValue) {
            if (!key || key.indexOf('_group') < 0)
                return;

            applyViewerGroupTranslation($scope, key, translationValue);
        });

        // Fallbacks for common dynamic date filters in legacy viewers.
        if (translations.desde_group)
            applyViewerGroupTranslation($scope, 'desde_group_', translations.desde_group);
        if (translations.hasta_group)
            applyViewerGroupTranslation($scope, 'hasta_group_', translations.hasta_group);
    }

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
            function (baseTranslations) {
                applyViewerCommonFieldTranslations(target, baseTranslations);
                app.language.translate(
                    target,
                    'viewer/' + entity,
                    function (translations) {
                        ApplyQueryTitleTranslation(translations);
                        applyViewerCommonFieldTranslations(target, translations);
                    }
                )();
            }
        )();
    }

    function Render(data) {
        if (data.index === undefined || data.index === null)
            data.index = 1;

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

                    TranslateViewerTarget('.advancefilter-row', translationEntity);

                    app.Prototype.Changed(function (data) {
                        app.ViewerQuery.Refresh(undefined, $('#RoleMemberGridTbl'), _id, '');
                    });
                }

                if (data.table && !data.table.entity)
                    data.table.entity = translationEntity;

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
        if (index === undefined || index === null)
            index = 1;

        gridControlName = "#" + index + "GridTbl";
        var tableSelector = '#RoleMemberGridTbl';
        if (!spec.entity)
            spec.entity = '';

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
                var id = `tbl${this.detailId}${index}`;
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
                $detail.append('<div class="table-responsive" style="background-color: white; margin: 0px 0px 0px 10px;"><table style="font-size: 11px" id="' + id + '"></table></div>');

                Child($detail.find('span'), $detail.find('table'), this.detailId, url, id);
            };
        }
        else {
            if (spec.detailView != undefined && spec.detailView && spec.detailFormatter == undefined) {
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
            if (spec.detailFormatter != undefined && spec.detailFormatter.startsWith('function ')) {
                spec.detailFormatter = spec.detailFormatter.replace(/@_/g, '\\\'').parseFunction();
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
                    if (column.events != undefined) {
                        column.events = 'Local_Events';
                    }
                    // Convertir cellStyle de objeto a funcion para Bootstrap Table
                    if (column.cellStyle != undefined && typeof column.cellStyle === 'object') {
                        const cellStyleDef = column.cellStyle;
                        column.cellStyle = function (value, row, index, field) {
                            return cellStyleDef;
                        };
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
        var originalOnPostBody = spec.onPostBody;
        spec.onPostBody = function (data) {
            app.ui.CommonBehaviour();
            TranslateViewerTarget(tableSelector, spec.entity);
            if ($.isFunction(originalOnPostBody))
                originalOnPostBody.call(this, data);
        };

        $(tableSelector).attr('name', index + 'GridTbl');

        $(tableSelector).bootstrapTable(spec);
        TranslateViewerTarget(tableSelector, spec.entity);

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

    function Child(title, $el, id, url, tableId) {
        app.core.Get(app.setting.apipath + 'v1/Viewer/QuerySpecification?id=' + id + '&url=' + window.location.search.slice(1).replace(/&/g, ':'))
            .done(function (data, textStatus, jqXHR) {
                var spec = data.table;
                if (!spec.entity)
                    spec.entity = data.entity || data.Entity || '';
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
                spec.showToggle = false;
                spec.showRefresh = false;
                spec.showColumns = false;
                spec.showColumnsToggleAll = false;
                spec.searchAlign = 'left';
                spec.maintainMetaData = true;
                var originalOnPostBody = spec.onPostBody;
                spec.onPostBody = function (data) {
                    app.ui.CommonBehaviour();
                    TranslateViewerTarget('#' + tableId, spec.entity);
                    if ($.isFunction(originalOnPostBody))
                        originalOnPostBody.call(this, data);
                };
                //spec.onRefresh = function (params) {
                //    app.ViewerQuery.Refresh(params, $el);
                //};

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
                    // Convertir cellStyle de objeto a funcion para Bootstrap Table
                    if (column.cellStyle != undefined && typeof column.cellStyle === 'object') {
                        const cellStyleDef = column.cellStyle;
                        column.cellStyle = function (value, row, index, field) {
                            return cellStyleDef;
                        };
                    }
                });

                $el.attr('name', tableId);
                $el.bootstrapTable(spec);
                TranslateViewerTarget('#' + tableId, spec.entity);

                app.ViewerQuery.Refresh(undefined, $el, id, url);

            });
    };

    return {
        Init: function () {
            _id = app.core.URLStringValue('id');
            Event_Controls();
            if (_id != '') {

                app.core.Get(app.setting.apipath + 'v1/Viewer/QuerySpecification?id=' + _id + '&url=' + window.location.search.slice(1).replace(/&/g, ':'))
                    .done(function (data, textStatus, jqXHR) {

                        if (data.include !== null && data.include !== '') {
                            app.core.LoadScriptFile(data.include)
                                .then(d => {
                                    Render(data);
                                })
                                .catch(err => {
                                    console.error(err);
                                });
                        }
                        else {
                            Render(data);
                        }
                    });


            }
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
        },
        ButtonClick: function (tbl, e, name, row, index) {
            $.each(tbl.columns, function (key, column) {
                if (typeof column['action_' + name] != "undefined") {
                    eval(column['action_' + name].supplant(row));
                }
            })
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
