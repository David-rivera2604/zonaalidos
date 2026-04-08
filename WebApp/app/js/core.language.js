var app = app || {};
app.language = (function () {
    var currentTranslations = {};

    function getCurrentLanguage() {
        var current = localStorage.getItem('current');
        var currentData = null;

        if (current) {
            try {
                currentData = JSON.parse(current);
            } catch (error) {
                currentData = null;
            }
        }

        return (
            localStorage.getItem('Language') ||
            localStorage.getItem('language') ||
            localStorage.getItem('Lang') ||
            localStorage.getItem('lang') ||
            (currentData && (currentData.Language || currentData.language || currentData.Lang || currentData.lang)) ||
            'es'
        );
    }

    function shouldTranslate() {
        return getNormalizedLanguage() !== 'es';
    }

    function getNormalizedLanguage() {
        var rawLanguage = $.trim((getCurrentLanguage() || '').toLowerCase());
        if (!rawLanguage)
            return 'es';

        return rawLanguage.split(/[-_]/)[0];
    }

    function buildTranslationUrl(newCase) {
        var language = getNormalizedLanguage();
        var pageName = $.trim(newCase || '');
        var currentPath = window.location.pathname || '';
        var appBasePath = (app.setting && app.setting.basepath) ? app.setting.basepath : '/';
        var relativePath = currentPath.indexOf(appBasePath) === 0
            ? currentPath.substring(appBasePath.length)
            : currentPath.replace(/^\/+/, '');
        var pathParts = $.grep(relativePath.split('/'), function (part) {
            return $.trim(part) !== '';
        });
        var controllerName = pathParts.length > 0 ? pathParts[0] : 'Cases';

        if (!pageName)
            return null;

        if (appBasePath.charAt(appBasePath.length - 1) !== '/')
            appBasePath += '/';

        if (pageName.indexOf('/') > -1) {
            var explicitParts = $.grep(pageName.split('/'), function (part) {
                return $.trim(part) !== '';
            });

            if (explicitParts.length > 1) {
                controllerName = explicitParts[0];
                pageName = explicitParts[1];
            }
        }

        return appBasePath + 'locales/' + controllerName + '/' + pageName + '.' + language + '.json';
    }

    function buildStorageKey(newCase) {
        var language = getNormalizedLanguage();
        var pageName = $.trim(newCase || '');

        if (!pageName)
            return null;

        return pageName + '.' + language;
    }


    function getTranslationsFromStorage(storageKey) {
        if (!storageKey)
            return null;

        var rawValue = localStorage.getItem(storageKey);
        if (!rawValue)
            return null;

        try {
            return JSON.parse(rawValue);
        } catch (error) {
            return null;
        }
    }

    function hasAllTranslations(labels, translations) {
        if (!translations || $.isEmptyObject(translations))
            return false;

        var allTranslated = true;

        $.each(labels || {}, function (id) {
            if (!getTranslationValue(translations, id)) {
                allTranslated = false;
                return false;
            }
        });

        return allTranslated;
    }

    function getTranslationValue(translations, key) {
        if (!translations || !key)
            return null;

        return translations[key] || null;
    }

    function getTranslationText(translations, key) {
        var translationValue = getTranslationValue(translations, key);

        if (!translationValue)
            return null;

        switch (typeof translationValue) {
            case 'string':
                return translationValue;
            case 'object':
                return Object.prototype.hasOwnProperty.call(translationValue, 'text')
                    ? translationValue.text
                    : null;
            default:
                return null;
        }
    }

    function getTranslationAttribute(translations, key, attributeName) {
        var translationValue = getTranslationValue(translations, key);

        if (!translationValue || typeof translationValue !== 'object')
            return null;

        return translationValue[attributeName] || null;
    }

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

    function saveTranslationsInStorage(storageKey, translations) {
        if (!storageKey)
            return;

        localStorage.setItem(storageKey, JSON.stringify(translations || {}));
    }


    function resolveTarget(target) {
        if (!target)
            return $(document);

        return $(target);
    }

    function getLabelFromElement(el, target) {
        const $element = $(el);
        const id = $element.attr('id');
        if (!id) return null;

        const $container = resolveTarget(target);
        if ($container.length === 0) return null;

        const $label = $container.find('label[for="' + id + '"]').first();
        if ($label.length === 0) return null;

        const $clone = $label.clone();
        $clone.find('.required-mark').remove();

        return $.trim($clone.text());
    }

    function getAllLabelsFromPage(target) {
        const $container = resolveTarget(target);
        const result = {};

        if ($container.length === 0)
            return result;

        $container.find('[id]').each(function () {
            const label = getLabelFromElement(this, $container);

            if (label)
                result[this.id] = label;
        });

        return result;
    }

    function getControlType($element) {
        var tagName = ($element.prop('tagName') || '').toLowerCase();

        switch (tagName) {
            case 'label':
                return 'label';
            case 'button':
                return 'button';
            case 'input':
                switch (($element.attr('type') || '').toLowerCase()) {
                    case 'button':
                    case 'submit':
                        return 'button';
                    default:
                        return 'input';
                }
            case 'textarea':
                return 'textarea';
            case 'select':
                return 'select';
            case 'div':
                return $element.attr('class') ? 'div' : 'generic';
            default:
                return 'generic';
        }
    }

    function applyHeaderTranslations($container, translations) {
        var pageTitle = getTranslationText(translations, 'Title');
        var pageTitleAttr = getTranslationAttribute(translations, 'Title', 'title');
        var $titleElement = $container.find('#Title').first();

        if ($titleElement.length > 0) {
            if (pageTitle)
                $titleElement.text(pageTitle);

            if (pageTitleAttr)
                $titleElement.attr('title', pageTitleAttr);

            return;
        }

        if (pageTitle)
            $container.find('.ibox-title h5').first().text(pageTitle);
    }

    function applyLabelTranslation($container, id, translations) {
        var $label = $container.find('label[for="' + id + '"]').first();
        var translatedText = getTranslationText(translations, id);
        var translatedTitle = getTranslationAttribute(translations, id, 'title');

        if ($label.length === 0)
            return;

        if (translatedText) {
            var $requiredMark = $label.find('.required-mark').detach();
            $label.text(translatedText);

            if ($requiredMark.length > 0)
                $label.append($requiredMark);
        }

        if (translatedTitle)
            $label.attr('title', translatedTitle);
    }

    function applySectionTranslation($element, id, translations) {
        var translatedText = getTranslationText(translations, id);
        var translatedTitle = getTranslationAttribute(translations, id, 'title');
        var $firstChild = $element.children().first();
        var $heading = $firstChild.is('h1, h2, h3, h4, h5, h6')
            ? $firstChild
            : $element.find('h1, h2, h3, h4, h5, h6').first();

        if (!$heading.length)
            return false;

        if (translatedText)
            $heading.text(translatedText);

        if (translatedTitle)
            $heading.attr('title', translatedTitle);

        return true;
    }

    function applyGenericElementTranslation($element, id, translations) {
        var translatedText = getTranslationText(translations, id);
        var translatedTitle = getTranslationAttribute(translations, id, 'title');

        if (translatedText)
            $element.text(translatedText);

        if (translatedTitle)
            $element.attr('title', translatedTitle);
    }

    function applyButtonTranslation($element, id, translations) {
        var buttonText = getTranslationText(translations, id);
        var buttonTitle = getTranslationAttribute(translations, id, 'title');

        if (!buttonText) {
            if (buttonTitle)
                $element.attr('title', buttonTitle);
            return;
        }

        if ($element.is('input'))
            $element.val(buttonText);
        else
            $element.text(buttonText);

        if (buttonTitle)
            $element.attr('title', buttonTitle);
    }

    function applyTabLinkTranslation($tabLink, translatedText) {
        var $icon = $tabLink.children('i').first();
        var $stepDescription = $tabLink.find('#StepDescription').first();
        var iconHtml = $icon.length > 0 ? $icon.prop('outerHTML') + ' ' : '';

        if ($stepDescription.length > 0) {
            $tabLink.html(iconHtml + translatedText + ' : ' + $stepDescription.prop('outerHTML'));
            return;
        }

        if ($icon.length > 0) {
            $tabLink.html(iconHtml + translatedText);
            return;
        }

        $tabLink.text(translatedText);
    }

    function applyTabsTranslations($container, translations) {
        $container.find('a[data-toggle="tab"][href^="#"]').each(function () {
            var $tabLink = $(this);
            var href = $tabLink.attr('href') || '';
            var tabId = href.replace(/^#/, '');
            var translatedText = getTranslationText(translations, tabId);
            var translatedTitle = getTranslationAttribute(translations, tabId, 'title');

            if (!tabId)
                return;

            if (translatedText)
                applyTabLinkTranslation($tabLink, translatedText);

            if (translatedTitle)
                $tabLink.attr('title', translatedTitle);
        });
    }

    function getGridTranslationBlock(translations, tableId) {
        var gridValue = getTranslationValue(translations, tableId);

        if ((!gridValue || typeof gridValue !== 'object') && translations && typeof translations === 'object') {
            // Fallback: if there is only one grid definition in the file, use it for dynamic table ids.
            var keys = Object.keys(translations);
            if (keys.length === 1)
                gridValue = translations[keys[0]];
        }

        if (!gridValue || typeof gridValue !== 'object')
            return null;

        return gridValue;
    }

    function getGridColumnsTranslations(translations, tableId) {
        var gridValue = getGridTranslationBlock(translations, tableId);
        if (!gridValue)
            return null;

        if (gridValue.columns && typeof gridValue.columns === 'object')
            return gridValue.columns;

        return gridValue;
    }

    function getGridToolbarTranslations(translations, tableId) {
        var gridValue = getGridTranslationBlock(translations, tableId);
        if (!gridValue)
            return null;

        if (gridValue.toolbar && typeof gridValue.toolbar === 'object')
            return gridValue.toolbar;

        if (gridValue.tools && typeof gridValue.tools === 'object')
            return gridValue.tools;

        return null;
    }

    function getGlobalToolbarTranslations(translations) {
        if (!translations || typeof translations !== 'object')
            return null;

        if (translations.GridToolbar && typeof translations.GridToolbar === 'object')
            return translations.GridToolbar;

        if (translations.Toolbar && typeof translations.Toolbar === 'object')
            return translations.Toolbar;

        if (translations.toolbar && typeof translations.toolbar === 'object')
            return translations.toolbar;

        return {
            search: translations.GridToolbarSearch || translations.ToolbarSearch || translations.SearchPlaceholder || null,
            refresh: translations.GridToolbarRefresh || translations.ToolbarRefresh || null,
            export: translations.GridToolbarExport || translations.ToolbarExport || null,
            csv: translations.GridToolbarCsv || translations.ToolbarCsv || null,
            excel: translations.GridToolbarExcel || translations.ToolbarExcel || null
        };
    }

    function mergeToolbarTranslations(baseTranslations, overrideTranslations) {
        var result = {
            search: null,
            refresh: null,
            export: null,
            csv: null,
            excel: null
        };

        $.extend(true, result, baseTranslations || {});
        $.extend(true, result, overrideTranslations || {});
        return result;
    }

    function hasToolbarTranslationValues(toolbarTranslations) {
        if (!toolbarTranslations || typeof toolbarTranslations !== 'object')
            return false;

        return !!(
            toolbarTranslations.search ||
            toolbarTranslations.refresh ||
            toolbarTranslations.export ||
            toolbarTranslations.csv ||
            toolbarTranslations.excel
        );
    }

    function resolveToolbarTranslations(translations, tableId) {
        var globals = getGlobalToolbarTranslations(translations);
        var byTable = getGridToolbarTranslations(translations, tableId);

        var merged = mergeToolbarTranslations({}, globals);
        merged = mergeToolbarTranslations(merged, byTable);

        return hasToolbarTranslationValues(merged) ? merged : null;
    }

    function applyToolbarButtonTranslation($button, translatedValue, fallbackToTitleOnly) {
        var text = getTranslationTextFromValue(translatedValue);
        var title = getTranslationAttributeFromValue(translatedValue, 'title');
        var ariaLabel = getTranslationAttributeFromValue(translatedValue, 'ariaLabel');

        if ($button.length === 0 || !translatedValue)
            return;

        if (typeof translatedValue === 'string' && fallbackToTitleOnly)
            title = translatedValue;

        if (text && !fallbackToTitleOnly)
            $button.text(text);

        if (title)
            $button.attr('title', title);

        if (!ariaLabel && title)
            ariaLabel = title;

        if (ariaLabel)
            $button.attr('aria-label', ariaLabel);
    }

    function applyGridToolbarTranslations($gridContainer, toolbarTranslations) {
        var searchValue = toolbarTranslations.search || toolbarTranslations.searchPlaceholder || toolbarTranslations.placeholder;
        var searchPlaceholder = getTranslationTextFromValue(searchValue);
        var searchTitle = getTranslationAttributeFromValue(searchValue, 'title');

        if ($gridContainer.length === 0 || !toolbarTranslations)
            return;

        if (searchPlaceholder)
            $gridContainer.find('.fixed-table-toolbar .search .search-input').attr('placeholder', searchPlaceholder);

        if (searchTitle)
            $gridContainer.find('.fixed-table-toolbar .search .search-input').attr('title', searchTitle);

        applyToolbarButtonTranslation($gridContainer.find('.fixed-table-toolbar button[name="refresh"]').first(), toolbarTranslations.refresh, true);
        applyToolbarButtonTranslation($gridContainer.find('.fixed-table-toolbar .export button.dropdown-toggle').first(), toolbarTranslations.export, true);
        applyToolbarButtonTranslation($gridContainer.find('.fixed-table-toolbar .export .dropdown-item[data-type="csv"]').first(), toolbarTranslations.csv, false);
        applyToolbarButtonTranslation($gridContainer.find('.fixed-table-toolbar .export .dropdown-item[data-type="excel"]').first(), toolbarTranslations.excel, false);
    }

    function applyGridHeaderTranslation($header, translatedValue) {
        if (!translatedValue)
            return;

        if (typeof translatedValue === 'string') {
            $header.text(translatedValue);
            return;
        }

        if (typeof translatedValue === 'object') {
            if (Object.prototype.hasOwnProperty.call(translatedValue, 'text') && translatedValue.text)
                $header.text(translatedValue.text);

            if (translatedValue.title)
                $header.attr('title', translatedValue.title);
        }
    }

    function applyGridTableTranslations($container, translations) {
        var $tables = $container
            .filter('table[id$="GridTbl"]')
            .add($container.find('table[id$="GridTbl"]'));

        $tables.each(function () {
            var $table = $(this);
            var tableId = $table.attr('id');
            var columnTranslations = getGridColumnsTranslations(translations, tableId);
            var toolbarTranslations = resolveToolbarTranslations(translations, tableId);
            var $gridContainer = $table.closest('.bootstrap-table');
            var $headers = $gridContainer.length > 0
                ? $gridContainer.find('th[data-field] .th-inner')
                : $table.find('thead th .th-inner, thead th');

            if (!tableId)
                return;

            if (toolbarTranslations)
                applyGridToolbarTranslations($gridContainer, toolbarTranslations);

            if (!columnTranslations || $headers.length === 0)
                return;

            $headers.each(function (index) {
                var $header = $(this);
                var $th = $header.closest('th');
                var field = $th.attr('data-field') || '';
                var translatedValue = null;

                if (field && Object.prototype.hasOwnProperty.call(columnTranslations, field))
                    translatedValue = columnTranslations[field];
                else if (Object.prototype.hasOwnProperty.call(columnTranslations, '_' + index))
                    translatedValue = columnTranslations['_' + index];

                applyGridHeaderTranslation($header, translatedValue);
            });
        });
    }

    function applyTranslations(target, labels, translations) {
        var $container = resolveTarget(target);

        if ($container.length === 0)
            return;

        applyHeaderTranslations($container, translations);

        $container.find('[id]').each(function () {
            var $element = $(this);
            var id = $element.attr('id');
            var controlType = getControlType($element);

            switch (controlType) {
                case 'button':
                    applyButtonTranslation($element, id, translations);
                    break;
                case 'div':
                    if ($element.hasClass('tab-pane') || $element.attr('role') === 'tabpanel')
                        break;

                    if (!applySectionTranslation($element, id, translations)) {
                        var divTitle = getTranslationAttribute(translations, id, 'title');

                        if (divTitle)
                            $element.attr('title', divTitle);
                    }
                    break;
                case 'label':
                case 'input':
                case 'textarea':
                case 'select':
                    break;
                default:
                    applyGenericElementTranslation($element, id, translations);
                    break;
            }

            if (labels && labels[id])
                applyLabelTranslation($container, id, translations);
        });

        applyTabsTranslations($container, translations);
        applyGridTableTranslations($container, translations);
    }

    function notifyTranslationComplete(onComplete, translations) {
        if ($.isFunction(onComplete))
            onComplete(translations || {});
    }

    function shouldUseCacheFromQueryString() {
        var search = window.location.search || '';
        if (!search)
            return true;

        var match = search.match(/[?&]cache=([^&]*)/i);
        if (!match || match.length < 2)
            return true;

        var cacheValue = decodeURIComponent(match[1] || '').toLowerCase();
        switch (cacheValue) {
            case 'false':
            case '0':
            case 'no':
                return false;
            default:
                return true;
        }
    }

    return {
        translate: function (target, newCase, onComplete, cache) {
            return function () {
                if (typeof onComplete === 'boolean' && typeof cache === 'undefined')
                    onComplete = null;

                var useCache = shouldUseCacheFromQueryString();

                if (!shouldTranslate()) {
                    currentTranslations = {};
                    notifyTranslationComplete(onComplete, currentTranslations);
                    return;
                }

                var labels = getAllLabelsFromPage(target);
                var url = buildTranslationUrl(newCase);
                var storageKey = buildStorageKey(newCase);
                var storedTranslations = useCache ? getTranslationsFromStorage(storageKey) : null;

                if (!url) {
                    currentTranslations = {};
                    notifyTranslationComplete(onComplete, currentTranslations);
                    return;
                }

                if (useCache && hasAllTranslations(labels, storedTranslations)) {
                    currentTranslations = storedTranslations;
                    applyTranslations(target, labels, currentTranslations);
                    notifyTranslationComplete(onComplete, currentTranslations);
                    return;
                }

                app.core.Get(
                    url,
                    undefined,
                    function (translations) {
                        currentTranslations = translations || {};
                        saveTranslationsInStorage(storageKey, currentTranslations);
                        applyTranslations(target, labels, currentTranslations);
                        notifyTranslationComplete(onComplete, currentTranslations);
                    },
                    false
                ).fail(
                    function () {
                        currentTranslations = {};
                        notifyTranslationComplete(onComplete, currentTranslations);
                    }
                );
            };
        },
        getTranslations: function () {
            return currentTranslations;
        }
    };
})();
