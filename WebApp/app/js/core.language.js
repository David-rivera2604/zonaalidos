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

        if (typeof translationValue === 'object')
            return Object.prototype.hasOwnProperty.call(translationValue, 'text')
                ? translationValue.text
                : null;

        return translationValue;
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

    function applyLabelTranslations($container, labels, translations) {
        $.each(labels || {}, function (id) {
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
        });
    }

    function applyHeaderTranslations($container, translations) {
        var pageTitle = getTranslationText(translations, 'Title');

        if (pageTitle)
            $container.find('.ibox-title h5').first().text(pageTitle);
    }

    function applySectionTranslations($container, translations) {
        $container.find('div[id][class]').each(function () {
            var $section = $(this);
            var sectionId = $section.attr('id');
            var translatedText = getTranslationText(translations, sectionId);
            var translatedTitle = getTranslationAttribute(translations, sectionId, 'title');
            var $firstChild = $section.children().first();

            if (!$firstChild.length || !$firstChild.is('h1, h2, h3, h4, h5, h6'))
                return;

            if (translatedText)
                $firstChild.text(translatedText);

            if (translatedTitle)
                $firstChild.attr('title', translatedTitle);
        });
    }

    function applyElementTranslations($container, translations) {
        $container.find('[id]').each(function () {
            var $element = $(this);
            var elementId = $element.attr('id');
            var translatedText = getTranslationText(translations, elementId);
            var translatedTitle = getTranslationAttribute(translations, elementId, 'title');

            if ($element.is('label, button, input, textarea, select'))
                return;

            if ($element.is('div[class]') && $element.children().first().is('h1, h2, h3, h4, h5, h6'))
                return;

            if (translatedText)
                $element.text(translatedText);

            if (translatedTitle)
                $element.attr('title', translatedTitle);
        });
    }

    function applyButtonTranslations($container, translations) {
        $container.find('button[id], input[type="button"][id], input[type="submit"][id]').each(function () {
            var $button = $(this);
            var buttonId = $button.attr('id');
            var buttonText = getTranslationText(translations, buttonId);
            var buttonTitle = getTranslationAttribute(translations, buttonId, 'title');

            if (!buttonText) {
                if (buttonTitle)
                    $button.attr('title', buttonTitle);
                return;
            }

            if ($button.is('input'))
                $button.val(buttonText);
            else
                $button.text(buttonText);

            if (buttonTitle)
                $button.attr('title', buttonTitle);
        });
    }

    function applyTranslations(target, labels, translations) {
        var $container = resolveTarget(target);

        if ($container.length === 0)
            return;

        applyHeaderTranslations($container, translations);
        applySectionTranslations($container, translations);
        applyElementTranslations($container, translations);
        applyLabelTranslations($container, labels, translations);
        applyButtonTranslations($container, translations);
    }

    return {
        translate: function (target, newCase) {
            return function () {
                if (!shouldTranslate()) {
                    currentTranslations = {};
                    return;
                }

                var labels = getAllLabelsFromPage(target);
                var url = buildTranslationUrl(newCase);
                var storageKey = buildStorageKey(newCase);
                var storedTranslations = getTranslationsFromStorage(storageKey);

                if (!url) {
                    currentTranslations = {};
                    return;
                }

                if (hasAllTranslations(labels, storedTranslations)) {
                    currentTranslations = storedTranslations;
                    applyTranslations(target, labels, currentTranslations);
                    return;
                }

                app.core.Get(
                    url,
                    undefined,
                    function (translations) {
                        currentTranslations = translations || {};
                        saveTranslationsInStorage(storageKey, currentTranslations);
                        applyTranslations(target, labels, currentTranslations);
                    },
                    false
                ).fail(
                    function () {
                        currentTranslations = {};
                    }
                );
            };
        },
        getTranslations: function () {
            return currentTranslations;
        }
    };
})();
