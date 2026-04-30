var app = app || {};
app.language = (function () {
    var currentTranslations = {};
    var languageFromUrlSynced = false;
    var translationCacheIndexKey = 'app.language.translationCacheIndex';
    var maxTranslationCacheItems = 10;

    function readQueryStringValue(key) {
        var search = window.location.search || '';
        var coreValue = '';

        if (app && app.core && typeof app.core.URLStringValue === 'function')
            coreValue = app.core.URLStringValue(key);

        if (coreValue)
            return coreValue;

        if (!search)
            return '';

        var pattern = new RegExp('[?&]' + key + '=([^&#]*)', 'i');
        var match = pattern.exec(search);
        if (!match || typeof match[1] === 'undefined')
            return '';

        return decodeURIComponent(match[1].replace(/\+/g, ' '));
    }

    function getLanguageFromUrl() {
        var languageFromQuery = $.trim(readQueryStringValue('language') || readQueryStringValue('lang') || '');

        if (!languageFromQuery)
            return null;

        return languageFromQuery.split(/[-_]/)[0].toLowerCase();
    }

    function setNormalizedSessionLanguage(languageValue) {
        var normalizedLanguage = $.trim((languageValue || '').toLowerCase()).split(/[-_]/)[0];
        var storageLanguage = normalizedLanguage.toUpperCase();
        if (!normalizedLanguage)
            return;

        sessionStorage.setItem('language', storageLanguage);
        sessionStorage.removeItem('Language');
        sessionStorage.removeItem('Lang');
        sessionStorage.removeItem('lang');

        var currentRaw = sessionStorage.getItem('current');
        var currentValue = {};

        if (currentRaw) {
            try {
                currentValue = JSON.parse(currentRaw) || {};
            } catch (error) {
                currentValue = {};
            }
        }

        delete currentValue.Language;
        delete currentValue.Lang;
        delete currentValue.lang;
        currentValue.language = storageLanguage;

        sessionStorage.setItem('current', JSON.stringify(currentValue));
    }

    function syncLanguageFromUrl() {
        if (languageFromUrlSynced)
            return;

        languageFromUrlSynced = true;

        var languageFromUrl = getLanguageFromUrl();
        if (!languageFromUrl)
            return;

        setNormalizedSessionLanguage(languageFromUrl);
    }

    function getCurrentLanguage() {
        syncLanguageFromUrl();

        var current = sessionStorage.getItem('current');
        var currentData = null;

        if (current) {
            try {
                currentData = JSON.parse(current);
            } catch (error) {
                currentData = null;
            }
        }

        var resolvedLanguage = sessionStorage.getItem('language') ||
            sessionStorage.getItem('Language') ||
            sessionStorage.getItem('Lang') ||
            sessionStorage.getItem('lang') ||
            (currentData && (currentData.language || currentData.Language || currentData.Lang || currentData.lang)) ||
            'ES';

        setNormalizedSessionLanguage(resolvedLanguage);
        return sessionStorage.getItem('language') || 'ES';
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
        var currentPathParts = $.grep(currentPath.replace(/^\/+/, '').split('/'), function (part) {
            return $.trim(part) !== '';
        });
        var baseParts = $.grep(appBasePath.replace(/^\/+|\/+$/g, '').split('/'), function (part) {
            return $.trim(part) !== '';
        });
        var appRootSegment = baseParts.length > 0 ? baseParts[0].toLowerCase() : '';
        var pathParts = currentPathParts.slice(0);

        if (pathParts.length > 1 && (
            (appRootSegment && pathParts[0].toLowerCase() === appRootSegment) ||
            pathParts[0].toLowerCase() === 'aliados'
        )) {
            pathParts = pathParts.slice(1);
        }

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

    function buildCommonTranslationUrl() {
        return buildTranslationUrl('Common/Common');
    }

    function getCommonStorageKey() {
        return buildStorageKey('Common');
    }

    function isReservedStorageKey(storageKey) {
        return storageKey === 'language' ||
            storageKey === 'Language' ||
            storageKey === 'Lang' ||
            storageKey === 'lang' ||
            storageKey === 'current' ||
            storageKey === translationCacheIndexKey;
    }

    function isTranslationStorageKey(storageKey) {
        if (!storageKey || isReservedStorageKey(storageKey))
            return false;

        return /\.[a-z]{2}$/i.test(storageKey);
    }

    function getStoredTranslationKeys() {
        var keys = [];

        for (var index = 0; index < sessionStorage.length; index++) {
            var storageKey = sessionStorage.key(index);
            if (isTranslationStorageKey(storageKey))
                keys.push(storageKey);
        }

        return keys;
    }

    function getTranslationCacheIndex() {
        var rawValue = sessionStorage.getItem(translationCacheIndexKey);
        if (!rawValue)
            return [];

        try {
            var parsedValue = JSON.parse(rawValue);
            return $.isArray(parsedValue) ? parsedValue : [];
        } catch (error) {
            return [];
        }
    }

    function saveTranslationCacheIndex(index) {
        sessionStorage.setItem(translationCacheIndexKey, JSON.stringify(index || []));
    }

    function syncTranslationCacheIndex() {
        var storedKeys = getStoredTranslationKeys();
        var storedKeysLookup = {};
        var normalizedIndex = [];

        $.each(storedKeys, function (_, storageKey) {
            storedKeysLookup[storageKey] = true;
        });

        $.each(getTranslationCacheIndex(), function (_, storageKey) {
            if (!storedKeysLookup[storageKey] || $.inArray(storageKey, normalizedIndex) > -1)
                return;

            normalizedIndex.push(storageKey);
        });

        $.each(storedKeys, function (_, storageKey) {
            if ($.inArray(storageKey, normalizedIndex) === -1)
                normalizedIndex.push(storageKey);
        });

        while (normalizedIndex.length > maxTranslationCacheItems) {
            var oldestKey = normalizedIndex.shift();
            if (oldestKey)
                sessionStorage.removeItem(oldestKey);
        }

        saveTranslationCacheIndex(normalizedIndex);
        return normalizedIndex;
    }

    function touchTranslationCacheKey(storageKey) {
        if (!storageKey)
            return;

        var index = $.grep(syncTranslationCacheIndex(), function (item) {
            return item && item !== storageKey;
        });

        index.push(storageKey);

        while (index.length > maxTranslationCacheItems) {
            var oldestKey = index.shift();
            if (oldestKey)
                sessionStorage.removeItem(oldestKey);
        }

        saveTranslationCacheIndex(index);
    }

    function getTranslationsFromStorage(storageKey) {
        if (!storageKey)
            return null;

        syncTranslationCacheIndex();

        var rawValue = sessionStorage.getItem(storageKey);
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

        sessionStorage.setItem(storageKey, JSON.stringify(translations || {}));
        touchTranslationCacheKey(storageKey);
    }

    function formatTemplate(template, values) {
        var source = template == null ? '' : String(template);

        return source.replace(/\{(\d+)\}/g, function (match, index) {
            var valueIndex = parseInt(index, 10);

            if (!values || valueIndex >= values.length || typeof values[valueIndex] === 'undefined' || values[valueIndex] === null)
                return '';

            return String(values[valueIndex]);
        });
    }

    function getCommonTranslations() {
        return getTranslationsFromStorage(getCommonStorageKey()) || {};
    }

    function getRuntimeTranslationValue(key) {
        return getTranslationValue(currentTranslations, key) || getTranslationValue(getCommonTranslations(), key);
    }

    function getRuntimeTranslationText(key, fallbackText) {
        var translatedText = getTranslationTextFromValue(getRuntimeTranslationValue(key));

        return translatedText || fallbackText || '';
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
        var $label = $container.find('label[for="' + id + '"]').filter(function () {
            return !$.trim($(this).attr('id') || '');
        }).first();
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

    function applyForBasedLabelTranslations($container, translations) {
        $container.find('label[for]').each(function () {
            var $label = $(this);
            var labelId = $.trim($label.attr('id') || '');
            var forId = $.trim($label.attr('for') || '');
            var translatedText = null;
            var translatedTitle = null;
            var $requiredMark = null;

            if (labelId)
                return;

            if (!forId)
                return;

            // Usual case is handled by label[for] + existing control id.
            // This fallback only applies when no control exists with that id (radio-group style names).
            if ($container.find('[id="' + forId + '"]').length > 0)
                return;

            translatedText = getTranslationText(translations, forId);
            translatedTitle = getTranslationAttribute(translations, forId, 'title');

            if (translatedText) {
                $requiredMark = $label.find('.required-mark').detach();
                $label.text(translatedText);

                if ($requiredMark.length > 0)
                    $label.append($requiredMark);
            }

            if (translatedTitle)
                $label.attr('title', translatedTitle);
        });
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
        var buttonDoing = getTranslationAttribute(translations, id, 'doing');

        if (!buttonText) {
            if (buttonTitle)
                $element.attr('title', buttonTitle);

            if (buttonDoing)
                $element.attr('data-doing', buttonDoing);

            return;
        }

        if ($element.is('input'))
            $element.val(buttonText);
        else
            $element.text(buttonText);

        if (buttonTitle)
            $element.attr('title', buttonTitle);

        if (buttonDoing)
            $element.attr('data-doing', buttonDoing);
    }

    function applyInputTranslation($element, id, translations) {
        var translatedText = getTranslationText(translations, id);
        var translatedTitle = getTranslationAttribute(translations, id, 'title');
        var translatedPlaceholder = getTranslationAttribute(translations, id, 'placeholder');

        if (translatedTitle)
            $element.attr('title', translatedTitle);

        if (translatedPlaceholder)
            $element.attr('placeholder', translatedPlaceholder);

        if (translatedText && !translatedPlaceholder)
            $element.attr('placeholder', translatedText);
    }

    function applyTextAreaTranslation($element, id, translations) {
        var translatedText = getTranslationText(translations, id);
        var translatedTitle = getTranslationAttribute(translations, id, 'title');
        var translatedPlaceholder = getTranslationAttribute(translations, id, 'placeholder');

        if (translatedTitle)
            $element.attr('title', translatedTitle);

        if (translatedPlaceholder)
            $element.attr('placeholder', translatedPlaceholder);

        if (translatedText && !translatedPlaceholder)
            $element.attr('placeholder', translatedText);
    }

    function applySelectTranslation($element, id, translations) {
        var translatedTitle = getTranslationAttribute(translations, id, 'title');

        if (translatedTitle)
            $element.attr('title', translatedTitle);
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
            // Viewer locales usually contain extra keys such as QueryTitle, so we must detect
            // grid-like blocks instead of relying on the total root-key count.
            var gridKeys = Object.keys(translations).filter(function (key) {
                var candidate = translations[key];
                if (!candidate || typeof candidate !== 'object')
                    return false;

                if (candidate.columns && typeof candidate.columns === 'object')
                    return true;

                return /(?:GridTbl|Tbl)$/i.test(key);
            });

            if (gridKeys.length === 1)
                gridValue = translations[gridKeys[0]];
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

    function applyGridEmptyStateTranslations($gridContainer, translations) {
        var noMatchesText = getTranslationText(translations, 'GridNoMatches');

        if ($gridContainer.length === 0 || !noMatchesText)
            return;

        $gridContainer.find('.no-records-found td').text(noMatchesText);
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

    function getBootstrapTableTranslations() {
        return {
            formatRecordsPerPage: function (pageNumber) {
                var template = getRuntimeTranslationText('GridPaginationRecordsPerPage', '{0} rows per page');
                return formatTemplate(template, [pageNumber]);
            },
            formatShowingRows: function (pageFrom, pageTo, totalRows, totalNotFiltered) {
                var templateKey = totalNotFiltered !== undefined && totalNotFiltered > 0 && totalNotFiltered > totalRows
                    ? 'GridPaginationShowingRowsFiltered'
                    : 'GridPaginationShowingRows';
                var fallbackTemplate = templateKey === 'GridPaginationShowingRowsFiltered'
                    ? 'Showing {0} to {1} of {2} rows (filtered from {3} total rows)'
                    : 'Showing {0} to {1} of {2} total rows';

                return formatTemplate(getRuntimeTranslationText(templateKey, fallbackTemplate), [pageFrom, pageTo, totalRows, totalNotFiltered]);
            },
            formatSRPaginationPreText: function () {
                return getRuntimeTranslationText('GridPaginationPreviousPage', 'previous page');
            },
            formatSRPaginationPageText: function (page) {
                return formatTemplate(getRuntimeTranslationText('GridPaginationPage', 'to page {0}'), [page]);
            },
            formatSRPaginationNextText: function () {
                return getRuntimeTranslationText('GridPaginationNextPage', 'next page');
            },
            formatDetailPagination: function (totalRows) {
                return formatTemplate(getRuntimeTranslationText('GridPaginationDetail', 'Showing {0} rows'), [totalRows]);
            },
            formatAllRows: function () {
                return getRuntimeTranslationText('GridPaginationAllRows', 'All');
            },
            formatNoMatches: function () {
                return getRuntimeTranslationText('GridNoMatches', 'No matching records found');
            },
            formatSearch: function () {
                return getRuntimeTranslationText('GridToolbarSearch', 'Search');
            }
        };
    }

    function applyBootstrapTableTranslations() {
        if (!$.fn || !$.fn.bootstrapTable || !$.fn.bootstrapTable.defaults)
            return;

        $.extend($.fn.bootstrapTable.defaults, getBootstrapTableTranslations());
    }

    function applyGridTableTranslations($container, translations) {
        var $tables = $container
            .filter('table[id$="GridTbl"], table[id$="Tbl"], table[name$="GridTbl"], table[name$="Tbl"]')
            .add($container.find('table[id$="GridTbl"], table[id$="Tbl"], table[name$="GridTbl"], table[name$="Tbl"]'));

        $tables.each(function () {
            var $table = $(this);
            var tableId = $table.attr('name') || $table.attr('id');
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

            applyGridEmptyStateTranslations($gridContainer, translations);

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

    function refreshBootstrapTableTranslations($container) {
        var runtimeTranslations = getBootstrapTableTranslations();
        var runtimeLanguage = getNormalizedLanguage();
        var $tables = $container
            .filter('table[id$="GridTbl"], table[id$="Tbl"], table[name$="GridTbl"], table[name$="Tbl"]')
            .add($container.find('table[id$="GridTbl"], table[id$="Tbl"], table[name$="GridTbl"], table[name$="Tbl"]'));

        if (!$tables.length || !$.fn || !$.fn.bootstrapTable)
            return;

        $tables.each(function () {
            var $table = $(this);
            var appliedLanguage = $table.data('bootstrap-table-language');

            if (!$table.data('bootstrap.table'))
                return;

            if (appliedLanguage === runtimeLanguage)
                return;

            try {
                $table.data('bootstrap-table-language', runtimeLanguage);
                $table.bootstrapTable('refreshOptions', runtimeTranslations);
            } catch (error) {
                $table.removeData('bootstrap-table-language');
                // Keep page translations working even if a specific grid instance cannot be refreshed.
            }
        });
    }

    function applyTranslations(target, labels, translations) {
        var $container = resolveTarget(target);

        if ($container.length === 0)
            return;

        applyHeaderTranslations($container, translations);
        refreshBootstrapTableTranslations($container);

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
                    applyGenericElementTranslation($element, id, translations);
                    break;
                case 'input':
                    applyInputTranslation($element, id, translations);
                    break;
                case 'textarea':
                    applyTextAreaTranslation($element, id, translations);
                    break;
                case 'select':
                    applySelectTranslation($element, id, translations);
                    break;
                default:
                    applyGenericElementTranslation($element, id, translations);
                    break;
            }

            if (labels && labels[id])
                applyLabelTranslation($container, id, translations);
        });

        applyTabsTranslations($container, translations);
        applyForBasedLabelTranslations($container, translations);
        applyGridTableTranslations($container, translations);
    }

    function notifyTranslationComplete(onComplete, translations) {
        if ($.isFunction(onComplete))
            onComplete(translations || {});
    }

    function mergeTranslations(commonTranslations, pageTranslations) {
        var merged = {};
        $.extend(true, merged, commonTranslations || {});
        $.extend(true, merged, pageTranslations || {});
        return merged;
    }

    function resolveTranslationsWithCommon(pageTranslations, useCache, onResolved) {
        var commonStorageKey = getCommonStorageKey();
        var commonUrl = buildCommonTranslationUrl();
        var commonFromStorage = useCache ? getTranslationsFromStorage(commonStorageKey) : null;

        if (commonFromStorage && !$.isEmptyObject(commonFromStorage)) {
            onResolved(mergeTranslations(commonFromStorage, pageTranslations));
            return;
        }

        if (!commonUrl) {
            onResolved(pageTranslations || {});
            return;
        }

        app.core.Get(
            commonUrl,
            undefined,
            function (commonTranslations) {
                var normalizedCommon = commonTranslations || {};
                saveTranslationsInStorage(commonStorageKey, normalizedCommon);
                onResolved(mergeTranslations(normalizedCommon, pageTranslations));
            },
            false
        ).fail(function () {
            saveTranslationsInStorage(commonStorageKey, {});
            onResolved(pageTranslations || {});
        });
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
                    applyBootstrapTableTranslations();
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
                    resolveTranslationsWithCommon(storedTranslations, useCache, function (effectiveTranslations) {
                        currentTranslations = effectiveTranslations || {};
                        applyBootstrapTableTranslations();
                        applyTranslations(target, labels, currentTranslations);
                        notifyTranslationComplete(onComplete, currentTranslations);
                    });
                    return;
                }

                app.core.Get(
                    url,
                    undefined,
                    function (translations) {
                        var pageTranslations = translations || {};
                        saveTranslationsInStorage(storageKey, pageTranslations);
                        resolveTranslationsWithCommon(pageTranslations, useCache, function (effectiveTranslations) {
                            currentTranslations = effectiveTranslations || {};
                            applyBootstrapTableTranslations();
                            applyTranslations(target, labels, currentTranslations);
                            notifyTranslationComplete(onComplete, currentTranslations);
                        });
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
        getTranslationText: function (key, fallbackText) {
            return getRuntimeTranslationText(key, fallbackText);
        },
        getTranslations: function () {
            return currentTranslations;
        },
        getBootstrapTableTranslations: function () {
            return getBootstrapTableTranslations();
        }
    };
})();
