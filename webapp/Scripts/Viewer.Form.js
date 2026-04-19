var app = app || {};

app.ViewerForm = (function () {

    function getFormContext() {
        let id = app.core.URLStringValue('id');
        let version = app.core.URLStringValue('version');

        if (id !== '') {
            return {
                id: id,
                version: version !== '' ? version : '3'
            };
        }

        var match = /\/form\/([^\/?#]+)/i.exec(window.location.pathname);
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
    function createViewerContext(entity, controlType) {
        if (app.ViewerPage && typeof app.ViewerPage.CreateContext === 'function') {
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

    function normalizeIncludeKey(path) {
        if (!path) return '';
        let key = String(path).trim().toLowerCase();
        key = key.split('?')[0];
        key = key.replace(/\\/g, '/');
        key = key.replace(/^\.?\//, '');
        return key;
    }

    function getIncludeNames(includePath) {
        let normalized = normalizeIncludeKey(includePath);
        let file = normalized.substring(normalized.lastIndexOf('/') + 1);
        let base = file.replace(/\.js$/i, '');
        let ctorName = base.replace(/[^A-Za-z0-9_]/g, '');
        let instanceName = base.replace(/[^A-Za-z0-9_]/g, '_');
        return {
            normalized: normalized,
            ctorName: ctorName,
            instanceName: instanceName
        };
    }

    function isGlobalDeclared(symbolName) {
        if (!symbolName) return false;
        try {
            return Function(`return typeof ${symbolName} !== "undefined";`)();
        } catch (e) {
            return false;
        }
    }

    function hasScriptTagLoaded(includePath) {
        let target = normalizeIncludeKey(includePath);
        if (!target) return false;
        let scripts = document.getElementsByTagName('script');
        for (let i = 0; i < scripts.length; i++) {
            let src = scripts[i].getAttribute('src');
            if (!src) continue;
            let current = normalizeIncludeKey(src);
            if (current === target || current.endsWith('/' + target) || target.endsWith('/' + current)) {
                return true;
            }
        }
        return false;
    }

    function runAfterRender(formId) {
        app.ui.CommonBehaviour();
        if (app[formId] && typeof app[formId].OnViewerFormShown === 'function') {
            app[formId].OnViewerFormShown();
        }
    }

    function makeEvalCodeSafe(code) {
        if (!code) return code;
        // Evita re-instanciar extensiones ya existentes en app.* al reabrir formularios.
        return code.replace(
            /app\.([A-Za-z0-9_]+)\s*=\s*new\s+([A-Za-z0-9_]+)\s*\(\s*\)\s*;/g,
            'app.$1 = app.$1 || new $2();'
        );
    }

    function bindViewerContextToExtensionInit(code, contextVariableName) {
        if (!code) {
            return code;
        }

        let contextName = contextVariableName || 'viewerContext';
        return code.replace(
            /app\.(Ext_[A-Za-z0-9_]+)\.Init\(([\s\S]*?)\);/g,
            `app.$1.Init($2, ${contextName});`
        );
    }



    return {
        Init: function (entity, controlType) {
            var contex = getFormContext();
            let _id = contex.id;
            let formId = (entity !== undefined && entity !== null && entity !== '') ? entity : _id;
            let normalizedControlType = (controlType !== undefined && controlType !== null && controlType !== '') ? controlType : null;
            let formCacheKey = `${formId}|${normalizedControlType || ''}`;
            if (formId != '') {
                let $container = $('#viewerFormHost');
                if ($container.length === 0) {
                    $container = $(document);
                }

                //$('.ibox-content').toggleClass('sk-loading');

                let alreadyRendered = $container.data('viewerFormReady') === true
                    && $container.data('viewerFormId') === formId
                    && $container.data('viewerFormCacheKey') === formCacheKey;
                if (alreadyRendered) {
                    runAfterRender(formId);
                    return;
                }

                //let $loadingTarget = $container.find('.ibox-content.render').first();
                //if ($loadingTarget.length === 0) {
                //    $loadingTarget = $('.ibox-content.render').first();
                //}
                //$loadingTarget.addClass('sk-loading');

                let url = app.setting.apipath + `v1/Viewer/Form/${formId}?version=3`;
                if (entity !== undefined && entity !== null && entity !== '') {
                    url += `&entity=${encodeURIComponent(entity)}`;
                }
                if (normalizedControlType !== null) {
                    url += `&controlType=${encodeURIComponent(normalizedControlType)}`;
                }

                app.core.Get(url)
                    .done(function (data, textStatus, jqXHR) {
                        $('#formTitle').html(data.Caption);
                        let html = data.HTML.supplant({});
                        html = app.core.ReplaceAll(html, '@_eqg', '>=');
                        html = app.core.ReplaceAll(html, '@_eq', '=');
                        html = app.core.ReplaceAll(html, '@_qt', '\'');
                        html = app.core.ReplaceAll(html, '@_sc', ';');
                        html = app.core.ReplaceAll(html, '@_ee', ' ');
                        html = app.core.ReplaceAll(html, 'Prototype', formId);
                        $container.find('.render').first().replaceWith(html);
                        let code = app.core.ReplaceAll(data.Code, 'Prototype', formId);

                        if (data.Include !== null && data.Include !== '') {
                            app.__LoadedDynamicScripts = app.__LoadedDynamicScripts || {};
                            let includeKey = normalizeIncludeKey(data.Include);
                            let includeNames = getIncludeNames(data.Include);
                            let loadInclude = Promise.resolve();
                            let appInstanceExists = app[includeNames.instanceName] !== undefined;
                            let ctorAlreadyDeclared = isGlobalDeclared(includeNames.ctorName);
                            let scriptAlreadyInDom = hasScriptTagLoaded(data.Include);
                            let alreadyAvailable = appInstanceExists || ctorAlreadyDeclared || scriptAlreadyInDom;

                            if (!app.__LoadedDynamicScripts[includeKey] && !alreadyAvailable) {
                                loadInclude = app.core.LoadScriptFile(data.Include)
                                    .then(() => {
                                        app.__LoadedDynamicScripts[includeKey] = true;
                                    });
                            } else {
                                app.__LoadedDynamicScripts[includeKey] = true;
                            }

                            loadInclude
                                .then(d => {
                                    let name = app.core.ReplaceAll(data.Include, '.js', '');
                                    name = app.core.ReplaceAll(name, '.', '_');
                                    name = name.substring(name.lastIndexOf("/") + 1);
                                    //app[name]['Init'](app[formId], formId);

                                    //Se debe cambiar desde el servicio
                                    code = app.core.ReplaceAll(code, 'app.Security/', 'app.');

                                    code = app.core.ReplaceAll(code, '\t\t\t\tSetup();', '');
                                    let viewerContext = createViewerContext(formId, normalizedControlType);
                                    code = app.core.ReplaceAll(code, '//Custom.Extend', `app.${name}.Init(app.${formId}, '${formId}', viewerContext);`)
                                    code = bindViewerContextToExtensionInit(code, 'viewerContext');
                                    code = makeEvalCodeSafe(code);
                                    eval(code);
                                    //let buttons = app.ui.GetControlsWithClick({ root: `#${app?.[name]?.events?.Entity}Edt`, controlType: 'button' })
                                    //Object.entries(app?.[name]?.events ?? {}).forEach(([key, value]) => {
                                    //    console.log(key, value);
                                    //});
                                })
                                .catch(err => {
                                    console.error(err);
                                });
                        } else {
                            code = makeEvalCodeSafe(code);
                            eval(code);
                        }
                        app.ui.CommonBehaviour();
                        $container.data('viewerFormReady', true);
                        $container.data('viewerFormId', formId);
                        $container.data('viewerFormCacheKey', formCacheKey);
                        runAfterRender(formId);
                    })
                    .fail(function () {
                        $container.data('viewerFormReady', false);
                    })
                    .always(function () {
                        //$container.find('.ibox-content').removeClass('sk-loading');
                        //$('.ibox-content.render').removeClass('sk-loading');
                    });
            };
        }
    };
})();
