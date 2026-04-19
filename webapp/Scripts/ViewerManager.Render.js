var app = app || {};

app.ViewerPage = (function () {
    var viewerFormInitialized = false;
    var viewerFormEntity = null;
    var viewerFormControlType = null;
    var viewerAnimationDurationMs = 450;
    var pageInitialized = false;

    function clearAnimationClasses($el) {
        $el.removeClass("animated animate__animated fadeIn fadeOut animate__fadeIn animate__fadeOut");
        $el.css("animation-duration", "");
        $el.css("--animate-duration", "");
    }

    function animateIn($el) {
        return new Promise(function (resolve) {
            clearAnimationClasses($el);
            $el.show();
            $el.addClass("animated animate__animated fadeIn animate__fadeIn");
            $el.css("animation-duration", viewerAnimationDurationMs + "ms");
            $el.css("--animate-duration", viewerAnimationDurationMs + "ms");

            var completed = false;
            var finish = function () {
                if (completed) {
                    return;
                }

                completed = true;
                $el.off("animationend", finish);
                clearAnimationClasses($el);
                resolve();
            };

            $el.one("animationend", finish);
            setTimeout(finish, viewerAnimationDurationMs + 50);
        });
    }

    function animateSwap($current, $next) {
        return new Promise(function (resolve) {
            if ($current.length === 0 || $next.length === 0) {
                $current.hide();
                $next.show();
                resolve();
                return;
            }

            var completed = false;
            var completeOut = function () {
                if (completed) {
                    return;
                }

                completed = true;
                $current.off("animationend");
                clearAnimationClasses($current);
                $current.hide();
                animateIn($next).then(resolve);
            };

            clearAnimationClasses($current);
            $current.addClass("animated animate__animated fadeOut animate__fadeOut");
            $current.css("animation-duration", viewerAnimationDurationMs + "ms");
            $current.css("--animate-duration", viewerAnimationDurationMs + "ms");
            $current.one("animationend", completeOut);
            setTimeout(completeOut, viewerAnimationDurationMs + 50);
        });
    }

    function normalizeValue(value) {
        return value === undefined || value === null ? null : value;
    }

    function hasEmbeddedFormHost() {
        return $("#viewerFormHost").length > 0 && $("#viewerGridHost").length > 0;
    }

    function initializeEmbeddedState() {
        if (!hasEmbeddedFormHost()) {
            return;
        }

        $("#viewerFormHost").hide();
        $("#viewerGridHost").show();
    }

    function translateForm(entity) {
        var normalizedEntity = $.trim(entity || "");
        var $target = hasEmbeddedFormHost() ? $("#viewerFormHost") : $("body");

        if (!normalizedEntity || $target.length === 0) {
            return Promise.resolve();
        }

        if (!app.language || typeof app.language.translate !== "function") {
            return Promise.resolve();
        }

        return new Promise(function (resolve) {
            try {
                app.language.translate($target, "viewer/" + normalizedEntity + ".Forms", function () {
                    resolve();
                })();
            } catch (error) {
                resolve();
            }
        });
    }

    function showForm(entity, controlType) {
        var normalizedEntity = normalizeValue(entity);
        var normalizedControlType = normalizeValue(controlType);
        var animationPromise = Promise.resolve();
        var initPromise = Promise.resolve();

        if (hasEmbeddedFormHost()) {
            animationPromise = animateSwap($("#viewerGridHost"), $("#viewerFormHost"));
        }

        if (
            app.ViewerForm
            && typeof app.ViewerForm.Init === "function"
            && (
                !viewerFormInitialized
                || viewerFormEntity !== normalizedEntity
                || viewerFormControlType !== normalizedControlType
            )
        ) {
            initPromise = Promise.resolve()
                .then(function () {
                    return app.ViewerForm.Init(normalizedEntity, normalizedControlType);
                })
                .then(function () {
                    viewerFormInitialized = true;
                    viewerFormEntity = normalizedEntity;
                    viewerFormControlType = normalizedControlType;
                });
        }

        return Promise.all([animationPromise, initPromise]).then(function () {
            return translateForm(normalizedEntity);
        }).then(function () {
            return {
                entity: normalizedEntity,
                controlType: normalizedControlType
            };
        });
    }

    function hideForm() {
        if (!hasEmbeddedFormHost()) {
            return;
        }

        //const $iboxContent = $('.ibox-content');
        //if ($iboxContent.hasClass('sk-loading')) {
        //    $iboxContent.removeClass('sk-loading');
        //}
        animateSwap($("#viewerFormHost"), $("#viewerGridHost"));
    }

    function refresh() {
        var $grid = $("#viewerGridHost table[id$='GridTbl']").first();

        if ($grid.length === 0) {
            $grid = $("table[id$='GridTbl']").first();
        }

        if ($grid.length > 0 && typeof $grid.bootstrapTable === "function") {
            return $grid.bootstrapTable("refresh");
        }
    }

    function createContext(entity, controlType) {
        return {
            ShowForm: function (nextEntity, nextControlType) {
                var targetEntity = nextEntity !== undefined ? nextEntity : entity;
                var targetControlType = nextControlType !== undefined ? nextControlType : controlType;
                return showForm(targetEntity, targetControlType);
            },
            HideForm: function () {
                return hideForm();
            },
            showForm: function (nextEntity, nextControlType) {
                var targetEntity = nextEntity !== undefined ? nextEntity : entity;
                var targetControlType = nextControlType !== undefined ? nextControlType : controlType;
                return showForm(targetEntity, targetControlType);
            },
            hideForm: function () {
                return hideForm();
            },
            Refresh: function () {
                return refresh();
            },
            refresh: function () {
                return refresh();
            },
            HasEmbeddedFormHost: hasEmbeddedFormHost,
            hasEmbeddedFormHost: hasEmbeddedFormHost
        };
    }

    function applyContext(target, entity, controlType, contextOverride) {
        var context = contextOverride || createContext(entity, controlType);

        if (target && (typeof target === "object" || typeof target === "function")) {
            target.context = context;
            target.viewerContext = context;
            target.ShowForm = context.ShowForm;
            target.HideForm = context.HideForm;
            target.showForm = context.showForm;
            target.hideForm = context.hideForm;
            target.Refresh = context.Refresh;
            target.refresh = context.refresh;
            target.HasEmbeddedFormHost = context.HasEmbeddedFormHost;
            target.hasEmbeddedFormHost = context.hasEmbeddedFormHost;
            return target;
        }

        return context;
    }

    function init() {
        if (pageInitialized) {
            return;
        }

        pageInitialized = true;
        initializeEmbeddedState();
        app.ViewerQuery.Init();
    }

    return {
        Init: init,
        ShowForm: showForm,
        HideForm: hideForm,
        Refresh: refresh,
        HasEmbeddedFormHost: hasEmbeddedFormHost,
        CreateContext: createContext,
        ApplyContext: applyContext
    };
})();
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

    function getFormContext() {
        let id = app.core.URLStringValue('id');
        let version = app.core.URLStringValue('version');

        if (id !== '') {
            return {
                id: id,
                version: version !== '' ? version : '3'
            };
        }

        var match = /\/view\/([^\/?#]+)/i.exec(window.location.pathname);
        if (match !== null && match.length > 1) {
            return {
                version: version !== '' ? version : '3',
                id: decodeURIComponent(match[1])
            };
        }

        return {
            id: '',
            version: version !== '' ? version : '3'
        };
    }

    function preEdit() {
    }

    function posEdit() {
    }

    function ResolveFunctionReference(target) {
        if (typeof target === 'function') {
            return target;
        }

        if (typeof target === 'string' && target.trim() !== '') {
            try {
                return eval(target);
            }
            catch (e) {
                return null;
            }
        }

        return null;
    }

    function CreateButtonsContext(spec, index, caller) {
        var context = {
            spec: spec,
            index: index,
            gridId: "#" + index + "GridTbl",
            toolbarId: "#" + index + "toolbar",
            caller: caller
        };

        var entity = spec != undefined ? (spec.entity != undefined ? spec.entity : spec.Entity) : undefined;
        var controlType = spec != undefined ? (spec.controlType != undefined ? spec.controlType : spec.ControlType) : undefined;

        if (app.ViewerPage && typeof app.ViewerPage.ApplyContext === 'function') {
            return app.ViewerPage.ApplyContext(context, entity, controlType);
        }

        return context;
    }

    function LocalButtons(spec, index, context, args) {
        let extendName = spec.extendName != undefined ? spec.extendName : "Extend";

        if (app[extendName] != undefined && app[extendName]['EventHandler'] != undefined && app[extendName]['EventHandler'] !== null) {
            app[extendName]['EventHandler'](spec.key, index, 'buttons', {
                context: context,
                args: Array.prototype.slice.call(args || [])
            });
        }
    }

    function WrapToolbarButtonEvents(spec, index, buttons, factoryContext) {
        if (buttons == undefined || typeof buttons !== 'object') {
            return buttons;
        }

        Object.keys(buttons).forEach(function (buttonKey) {
            var buttonSpec = buttons[buttonKey];
            if (buttonSpec == undefined || typeof buttonSpec !== 'object' || typeof buttonSpec.event !== 'function') {
                return;
            }

            var originalEvent = buttonSpec.event;
            buttonSpec.event = function () {
                var eventContext = CreateButtonsContext(spec, index, factoryContext || this);
                eventContext.buttonKey = buttonKey;
                eventContext.button = buttonSpec;
                var eventArgs = arguments;

                if (app.ViewerQuery && typeof app.ViewerQuery.LocalButtons === 'function') {
                    app.ViewerQuery.LocalButtons(spec, index, eventContext, eventArgs);
                }
                else {
                    LocalButtons(spec, index, eventContext, eventArgs);
                }

                return originalEvent.apply(eventContext, eventArgs);
            };
        });

        return buttons;
    }

    function WrapSpecButtons(spec, index) {
        if (spec.buttons == undefined) {
            return;
        }

        var originalButtons = ResolveFunctionReference(spec.buttons);
        spec._buttons = spec.buttons;
        spec.buttons = function () {
            var localResult = null;
            var factoryContext = CreateButtonsContext(spec, index, this);
            var originalArgs = [factoryContext].concat(Array.prototype.slice.call(arguments));

            if (app.ViewerQuery && typeof app.ViewerQuery.LocalButtons === 'function') {
                localResult = app.ViewerQuery.LocalButtons(spec, index, factoryContext, arguments);
            }
            else {
                localResult = LocalButtons(spec, index, factoryContext, arguments);
            }

            if (typeof originalButtons === 'function') {
                return WrapToolbarButtonEvents(spec, index, originalButtons.apply(factoryContext, originalArgs), factoryContext);
            }

            return localResult;
        };
    }

    function EnsureLocalEvents(spec) {
        var eventName = `Local_Events_${spec.index}`;

        window[eventName] = {
            'click .event': function (e, value, row, index) {
                e.stopPropagation();
                app.ViewerQuery.ButtonClick(spec, this, e, e.currentTarget.name, row, index);
            }
        };

        return eventName;
    }

    function PreCallLocal(row, entity, controlType) {
        // Abre el formulario embebido antes de ejecutar la accion.
        if (app.ViewerPage && typeof app.ViewerPage.ShowForm === 'function') {
            app.ViewerPage.ShowForm(entity, controlType);
        }

        // Hook opcional para logica custom definida por Viewer.Form.js u otros includes.
        if (app.ViewerForm && typeof app.ViewerForm.PreCall === 'function') {
            app.ViewerForm.PreCall(row, entity, controlType);
        }
    }

    function PosCallLocal(row, entity, controlType) {
        // Hook opcional para logica custom posterior a la accion.
        if (app.ViewerForm && typeof app.ViewerForm.PosCall === 'function') {
            app.ViewerForm.PosCall(row, entity, controlType);
        }

        // Si el formulario no existe o no se usa en esta vista, no falla.
        if ($('#viewerFormHost').length === 0) {
            return;
        }
    }

    function CreateActionContext(entity, controlType) {
        if (app.ViewerPage && typeof app.ViewerPage.CreateContext === "function") {
            return app.ViewerPage.CreateContext(entity, controlType);
        }

        return {
            ShowForm: function () { },
            HideForm: function () { },
            showForm: function () { },
            hideForm: function () { },
            Refresh: function () { },
            refresh: function () { },
            HasEmbeddedFormHost: function () { return false; },
            hasEmbeddedFormHost: function () { return false; }
        };
    }

    function BindContextToActionCalls(actionCode) {
        if (!actionCode || actionCode.indexOf("ApplyContext(") >= 0) {
            return actionCode;
        }

        return actionCode.replace(
            /([A-Za-z_$][A-Za-z0-9_$.]*)\.([A-Za-z_$][A-Za-z0-9_$]*)\(\s*row(\s*[,)\]])/g,
            "app.ViewerPage.ApplyContext($1, entity, controlType, context), ($1.$2).call($1, row, context$3"
        );
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

        WrapSpecButtons(spec, index);
        var localEventsName = EnsureLocalEvents(spec);

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
                        column.events = localEventsName;
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
                    column.events = localEventsName;
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
        PreEdit: preEdit,
        PosEdit: posEdit,
        Init: function () {
            let context = getFormContext();
            _id = context.id;

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
        ButtonClick: function (spec, tbl, e, name, row, index) {
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
                            var actionRoot = column[`action_${name}`].split(".").slice(0, 2).join(".");
                            var rootNode = undefined;
                            var eventsNode = undefined;

                            try { rootNode = eval(actionRoot); } catch (e) { }

                            if (rootNode && rootNode.events != undefined)
                                eventsNode = rootNode.events;
                            else
                                try { eventsNode = eval(`${actionRoot}.events`); } catch (e) { }

                            var entity = spec != undefined ? spec.entity : undefined;
                            var controlType = spec != undefined ? spec.controlType : undefined;
                            var eventRoot = eventsNode || rootNode;

                            var objectEvent = eventRoot;
                            if (eventRoot && typeof eventRoot === "object") {
                                objectEvent = eventRoot[name];
                                if (objectEvent == undefined && typeof name.ToPascalFirst === "function") {
                                    objectEvent = eventRoot[name.ToPascalFirst()];
                                }
                                if (objectEvent == undefined) {
                                    objectEvent = eventRoot;
                                }
                            }

                            // PRE
                            if (objectEvent) {
                                if (typeof objectEvent.PreCall === "function")
                                    objectEvent.PreCall(row);
                                else if (objectEvent.PreCall === true)
                                    PreCallLocal(row, entity, controlType);
                            }

                            var context = CreateActionContext(entity, controlType);
                            var actionCode = BindContextToActionCalls(column['action_' + name].supplant(row));
                            eval(actionCode);

                            // POST
                            if (objectEvent) {
                                if (typeof objectEvent.PosCall === "function")
                                    objectEvent.PosCall(row);
                                else if (objectEvent.PosCall === true)
                                    PosCallLocal(row, entity, controlType);
                            }
                        }
                    })
                    break;
            }
        },
        Data: function () {
            return _data;
        },
        LocalButtons: function (spec, index, context, args) {
            return LocalButtons(spec, index, context, args);
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

$(document).ready(function () {
    app.ViewerPage.Init();
});
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