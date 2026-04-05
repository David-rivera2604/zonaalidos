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
        return $.trim((getCurrentLanguage() || '').toLowerCase()) !== 'es';
    }

    function buildTranslationUrl(newCase) {
        var language = $.trim((getCurrentLanguage() || '').toLowerCase());
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

        return appBasePath + 'locales/' + controllerName + '/' + language + '.' + pageName + '.json';
    }

    function buildStorageKey(newCase) {
        var language = $.trim((getCurrentLanguage() || '').toLowerCase());
        var pageName = $.trim(newCase || '');

        if (!pageName)
            return null;

        return language + '.' + pageName;
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

        if (!$firstChild.length || !$firstChild.is('h1, h2, h3, h4, h5, h6'))
            return false;

        if (translatedText)
            $firstChild.text(translatedText);

        if (translatedTitle)
            $firstChild.attr('title', translatedTitle);

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

                    if (!applySectionTranslation($element, id, translations))
                        applyGenericElementTranslation($element, id, translations);
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
    }

    function notifyTranslationComplete(onComplete, translations) {
        if ($.isFunction(onComplete))
            onComplete(translations || {});
    }

    return {
        translate: function (target, newCase, onComplete) {
            return function () {
                if (!shouldTranslate()) {
                    currentTranslations = {};
                    notifyTranslationComplete(onComplete, currentTranslations);
                    return;
                }

                var labels = getAllLabelsFromPage(target);
                var url = buildTranslationUrl(newCase);
                var storageKey = buildStorageKey(newCase);
                var storedTranslations = getTranslationsFromStorage(storageKey);

                if (!url) {
                    currentTranslations = {};
                    notifyTranslationComplete(onComplete, currentTranslations);
                    return;
                }

                if (hasAllTranslations(labels, storedTranslations)) {
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
