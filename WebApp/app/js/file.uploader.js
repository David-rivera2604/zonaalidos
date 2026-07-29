// 🔴 CRÍTICO: Deshabilitar auto-discovery INMEDIATAMENTE
if (typeof Dropzone !== 'undefined') {
    Dropzone.autoDiscover = false;
}

// Función helper para obtener MIME type por extensión
function getMimeType(filename) {
    if (!filename) return 'application/octet-stream';

    var ext = filename.split('.').pop().toLowerCase();
    var mimeTypes = {
        'pdf': 'application/pdf',
        'doc': 'application/msword',
        'docx': 'application/vnd.openxmlformats-officedocument.wordprocessingml.document',
        'xls': 'application/vnd.ms-excel',
        'xlsx': 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
        'ppt': 'application/vnd.ms-powerpoint',
        'pptx': 'application/vnd.openxmlformats-officedocument.presentationml.presentation',
        'jpg': 'image/jpeg',
        'jpeg': 'image/jpeg',
        'png': 'image/png',
        'gif': 'image/gif',
        'bmp': 'image/bmp',
        'txt': 'text/plain',
        'csv': 'text/csv',
        'zip': 'application/zip',
        'rar': 'application/x-rar-compressed',
        '7z': 'application/x-7z-compressed'
    };

    return mimeTypes[ext] || 'application/octet-stream';
}

function injectFileUploaderStyles() {
    if (document.getElementById('fileUploaderProfessionalStyles'))
        return;

    var style = document.createElement('style');
    style.id = 'fileUploaderProfessionalStyles';
    style.type = 'text/css';
    style.textContent = '.dropzone .dz-message{width:100%;}' +
        '.dropzone .dz-preview.dz-professional-card{' +
        'display:inline-flex;vertical-align:top;flex-direction:column;width:220px;max-width:100%;min-height:250px;background:#fff;border:1px solid #dfe6ef;border-radius:14px;box-shadow:0 8px 22px rgba(15,23,42,.08);overflow:hidden;margin:10px;transition:transform .2s ease,box-shadow .2s ease;' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card:hover{' +
        'transform:translateY(-3px);box-shadow:0 14px 28px rgba(15,23,42,.14);' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card .dz-image{' +
        'width:100%!important;height:120px!important;margin:0!important;border-radius:14px 14px 0 0!important;overflow:hidden;display:flex;align-items:center;justify-content:center;background:linear-gradient(135deg,#f8fafc,#eef3f8);' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card .dz-image img{' +
        'width:100%;height:100%;object-fit:cover;display:block;' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card .dz-details{' +
        'position:static!important;opacity:1!important;min-height:95px;padding:12px;background:#fff;text-align:left!important;color:#2c3a4b!important;display:flex;flex-direction:column;gap:6px;' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card .dz-size{' +
        'margin:0!important;order:1;' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card .dz-size span{' +
        'display:inline-block;background:#eef3f8;color:#415268;border-radius:999px;padding:3px 10px;font-size:11px;font-weight:700;box-shadow:none!important;' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card .dz-filename{' +
        'order:2;max-width:100%;' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card .dz-filename span{' +
        'display:block;max-width:100%;font-size:13px;font-weight:600;color:#2f3a4a;line-height:1.35;white-space:nowrap;overflow:hidden;text-overflow:ellipsis;' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card .dz-upload-meta{' +
        'order:3;margin-top:2px;min-height:30px;font-size:12px;color:#64748b;line-height:1.35;white-space:normal;' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card .dz-upload-meta .dz-user{' +
        'font-weight:600;color:#334155;' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card .dz-actions{' +
        'margin-top:auto;display:flex;justify-content:flex-end;gap:8px;padding:9px 10px;border-top:1px solid #edf2f7;background:#f8fafc;' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card .dz-actions .dz-action-btn{' +
        'display:inline-flex;align-items:center;justify-content:center;width:32px;height:32px;border-radius:9px;transition:all .2s ease;text-decoration:none;' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card .dz-actions .dz-action-btn:hover{' +
        'background:#e7eef6;' +
        '}' +
        '.dropzone .dz-preview.dz-professional-card .dz-success-mark,.dropzone .dz-preview.dz-professional-card .dz-error-mark,.dropzone .dz-preview.dz-professional-card .dz-progress{' +
        'display:none!important;' +
        '}' +
        '@media (max-width:991px){.dropzone .dz-preview.dz-professional-card{width:calc(50% - 22px);min-width:170px;}}' +
        '@media (max-width:575px){.dropzone .dz-preview.dz-professional-card{width:100%;min-width:0;margin:8px 0;}}';

    document.head.appendChild(style);
}

function escapeUploaderHtml(value) {
    if (value === null || value === undefined)
        return '';

    return String(value)
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#39;');
}

function getCurrentUploaderName() {
    var userName = localStorage.getItem('Username');
    if (userName && userName.trim())
        return userName;

    return '';
}

function getUploaderAuditValue(fileData, keys) {
    if (!fileData)
        return null;

    for (var i = 0; i < keys.length; i++) {
        var value = fileData[keys[i]];
        if (value !== undefined && value !== null && value !== '')
            return value;
    }

    return null;
}

function normalizeUploaderDate(dateValue) {
    if (!dateValue || dateValue === '0001-01-01T00:00:00')
        return null;

    if (typeof moment !== 'undefined' && moment(dateValue).isValid())
        return dateValue;

    return null;
}

function getUploaderIconData(fileType) {
    var type = (fileType || '').toLowerCase();

    if (type.indexOf('image/') === 0)
        return { className: 'fa fa-file-image-o', color: '#28a745' };
    if (type === 'application/pdf')
        return { className: 'fa fa-file-pdf-o', color: '#dc3545' };
    if (type.indexOf('word') >= 0 || type.indexOf('document') >= 0)
        return { className: 'fa fa-file-word-o', color: '#2b579a' };
    if (type.indexOf('excel') >= 0 || type.indexOf('sheet') >= 0)
        return { className: 'fa fa-file-excel-o', color: '#217346' };
    if (type.indexOf('powerpoint') >= 0 || type.indexOf('presentation') >= 0)
        return { className: 'fa fa-file-powerpoint-o', color: '#d24726' };
    if (type.indexOf('zip') >= 0 || type.indexOf('compressed') >= 0 || type.indexOf('rar') >= 0)
        return { className: 'fa fa-file-archive-o', color: '#f59e0b' };
    if (type.indexOf('text') >= 0 || type.indexOf('csv') >= 0)
        return { className: 'fa fa-file-text-o', color: '#007bff' };

    return { className: 'fa fa-file-o', color: '#6c757d' };
}

function applyUploaderFileVisual(file) {
    if (!file || !file.previewElement)
        return;

    var dzImage = file.previewElement.querySelector('.dz-image');
    if (!dzImage)
        return;

    var mimeType = (file.type || getMimeType(file.name || '') || '').toLowerCase();

    function renderGenericIcon() {
        dzImage.innerHTML = '';

        var iconData = getUploaderIconData(mimeType);
        var iconElement = document.createElement('i');
        iconElement.className = iconData.className;
        iconElement.style.fontSize = '58px';
        iconElement.style.color = iconData.color;
        iconElement.style.display = 'flex';
        iconElement.style.alignItems = 'center';
        iconElement.style.justifyContent = 'center';
        iconElement.style.width = '100%';
        iconElement.style.height = '100%';

        dzImage.appendChild(iconElement);
    }

    var imageElement = dzImage.querySelector('img');
    if (imageElement && mimeType.indexOf('image/') === 0) {
        var imageSrc = imageElement.getAttribute('src') || '';

        if (!imageSrc) {
            renderGenericIcon();
            return;
        }

        if (imageElement.complete) {
            if (imageElement.naturalWidth > 0) {
                imageElement.style.width = '100%';
                imageElement.style.height = '100%';
                imageElement.style.objectFit = 'cover';
                return;
            }

            renderGenericIcon();
            return;
        }

        imageElement.onload = function () {
            imageElement.style.width = '100%';
            imageElement.style.height = '100%';
            imageElement.style.objectFit = 'cover';
        };

        imageElement.onerror = function () {
            renderGenericIcon();
        };

        return;
    }

    renderGenericIcon();
}

function renderUploaderAuditInfo(file) {
    if (!file || !file.previewElement)
        return;

    var fileData = file.serverResponse || {};
    var userName = getUploaderAuditValue(fileData, ['UpdateUserName', 'UPDATEUSERNAME', 'CreatedByName', 'CreatedUserName', 'UploadUserName', 'UserName']) || getCurrentUploaderName();
    var updateDate = normalizeUploaderDate(getUploaderAuditValue(fileData, ['UpdateDate', 'UPDATEDATE', 'CreatedDate', 'CreateDate', 'UploadDate', 'UploadedAt']));

    if (!updateDate && file.manuallyAdded !== true)
        updateDate = new Date().toISOString();

    var details = file.previewElement.querySelector('.dz-details');
    if (!details)
        return;

    var auditElement = file.previewElement.querySelector('.dz-upload-meta');
    if (!auditElement) {
        auditElement = document.createElement('div');
        auditElement.className = 'dz-upload-meta';
        details.appendChild(auditElement);
    }

    if (!userName && !updateDate) {
        auditElement.innerHTML = '';
        return;
    }

    var relativeDate = '';
    var formattedDate = '';
    if (updateDate && typeof moment !== 'undefined' && moment(updateDate).isValid()) {
        relativeDate = moment(updateDate).fromNow();
        formattedDate = moment(updateDate).format('DD/MM/YYYY hh:mm:ssa');
    }

    var content = '';
    if (userName)
        content += '<span class="dz-user">' + escapeUploaderHtml(userName) + '</span>';

    if (relativeDate)
        content += (content ? ' ' : '') + '<span class="dz-time">' + escapeUploaderHtml(relativeDate) + '</span>';

    auditElement.innerHTML = content;
    if (formattedDate)
        auditElement.setAttribute('title', formattedDate);
}

function resolveUploaderTranslationPath($element) {
    if ($element.closest('#AttachmentGrid, .AttachmentGrid').length > 0)
        return 'Common/AttachmentGrid';

    return null;
}

function resolveUploaderTranslationScope($element) {
    var $scope = $element.closest('#AttachmentGrid, .AttachmentGrid');

    if ($scope.length > 0)
        return $scope.first();

    return $element;
}

function getUploaderTranslations() {
    if (app.language && app.language.getTranslations)
        return app.language.getTranslations() || {};

    return {};
}

function runUploaderTranslation($scope, translationPath, onComplete) {
    if (!app.language || !app.language.translate || !translationPath)
    {
        if ($.isFunction(onComplete))
            onComplete({});
        return;
    }

    app.language.translate($scope, translationPath, function (translations) {
        if ($.isFunction(onComplete))
            onComplete(translations || {});
    })();
}

function getUploaderTranslationValue(translations, key) {
    if (!translations || !key)
        return null;

    return translations[key] || null;
}

function getUploaderTranslationText(translations, key) {
    var translationValue = getUploaderTranslationValue(translations, key);

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

function getUploaderTranslationAttribute(translations, key, attributeName) {
    var translationValue = getUploaderTranslationValue(translations, key);

    if (!translationValue || typeof translationValue !== 'object')
        return null;

    return translationValue[attributeName] || null;
}

function applyUploaderTranslationToElement($element, translations) {
    var id = $element.attr('id');
    var translatedText = getUploaderTranslationText(translations, id);
    var translatedTitle = getUploaderTranslationAttribute(translations, id, 'title');

    if (!id)
        return;

    if (translatedText) {
        if ($element.is('input'))
            $element.val(translatedText);
        else
            $element.text(translatedText);
    }

    if (translatedTitle)
        $element.attr('title', translatedTitle);
}

function applyUploaderTranslations($scope, translations) {
    if (!$scope || $scope.length === 0 || !translations)
        return;

    $scope.find('[id]').each(function () {
        applyUploaderTranslationToElement($(this), translations);
    });
}

function applyUploaderPreviewTranslations($element, translations) {
    var downloadTitle = getUploaderTranslationAttribute(translations, 'dzDownload', 'title');
    var removeTitle = getUploaderTranslationAttribute(translations, 'dzRemove', 'title');

    if (downloadTitle)
        $element.find('.dz-download').attr('title', downloadTitle);

    if (removeTitle)
        $element.find('.dz-remove').attr('title', removeTitle);
}

function localizeUploaderSettings(settings, translations) {
    var localizedSettings = $.extend({}, settings);

    $.each([
        'dictDefaultMessage',
        'dictFallbackMessage',
        'dictFileTooBig',
        'dictInvalidFileType',
        'dictResponseError',
        'dictCancelUpload',
        'dictUploadCanceled',
        'dictCancelUploadConfirmation',
        'dictRemoveFile',
        'dictMaxFilesExceeded'
    ], function (_, key) {
        var translatedText = getUploaderTranslationText(translations, key);

        if (translatedText)
            localizedSettings[key] = translatedText;
    });

    return localizedSettings;
}

function updateDropzoneDictionary(dz, settings) {
    if (!dz || !dz.options)
        return;

    dz.options.dictDefaultMessage = settings.dictDefaultMessage;
    dz.options.dictFallbackMessage = settings.dictFallbackMessage;
    dz.options.dictFileTooBig = settings.dictFileTooBig;
    dz.options.dictInvalidFileType = settings.dictInvalidFileType;
    dz.options.dictResponseError = settings.dictResponseError;
    dz.options.dictCancelUpload = settings.dictCancelUpload;
    dz.options.dictUploadCanceled = settings.dictUploadCanceled;
    dz.options.dictCancelUploadConfirmation = settings.dictCancelUploadConfirmation;
    dz.options.dictRemoveFile = settings.dictRemoveFile;
    dz.options.dictMaxFilesExceeded = settings.dictMaxFilesExceeded;
}

function applyUploaderTranslationState($el, translationScope, dz, instance, settings, translations) {
    var translatedValues = translations || {};
    var translatedSettings = localizeUploaderSettings(settings, translatedValues);

    if (instance)
        instance.translations = translatedValues;

    applyUploaderTranslations(translationScope, translatedValues);
    applyUploaderPreviewTranslations($el, translatedValues);
    updateDropzoneDictionary(dz, translatedSettings);
}

(function ($) {
    $.fn.fileUploader = function (optionsOrMethod) {
        var defaults = {
            autoProcessQueue: false,
            maxFilesize: 256,
            parallelUploads: 5,
            addRemoveLinks: true,
            dictDefaultMessage: "Arrastra archivos aquí o haz clic para seleccionar",
            dictFallbackMessage: "Tu navegador no soporta drag and drop de archivos.",
            dictFileTooBig: "El archivo es muy grande ({{filesize}}MB). Tamaño máximo: {{maxFilesize}}MB.",
            dictInvalidFileType: "No puedes subir archivos de este tipo.",
            dictResponseError: "El servidor respondió con código {{statusCode}}.",
            dictCancelUpload: "Cancelar subida",
            dictUploadCanceled: "Subida cancelada.",
            dictCancelUploadConfirmation: "¿Estás seguro de cancelar esta subida?",
            dictRemoveFile: "Eliminar archivo",
            dictMaxFilesExceeded: "No puedes subir más archivos.",
            enableDownloadButtons: true, // Auto-configurar botones de descarga
            done: function () { },
            fail: function () { },
            always: function () { }
        };

        var methods = {
            init: function (options) {
                var settings = $.extend({}, defaults, options);

                return this.each(function () {
                    var $el = $(this);
                    var elementId = $el.attr('id') || 'sin-id';
                    var translationPath = resolveUploaderTranslationPath($el);
                    var translationScope = resolveUploaderTranslationScope($el);
                    var translations = getUploaderTranslations();
                    var localizedSettings = localizeUploaderSettings(settings, translations);

                    // Prevenir inicialización duplicada
                    if ($el.data('fileUploader')) {
                        return;
                    }

                    // Verificar si Dropzone ya está adjunto directamente
                    if ($el[0].dropzone) {
                        $el[0].dropzone.destroy();
                    }

                    translations = getUploaderTranslations();
                    localizedSettings = localizeUploaderSettings(settings, translations);
                    applyUploaderTranslations(translationScope, translations);
                    applyUploaderPreviewTranslations($el, translations);
                    injectFileUploaderStyles();

                    var responses = [];
                    var hasError = false;
                    var pendingUploads = 0;
                    var filesToUpload = [];
                    var uploadTimer = null;
                    var parentData = null; // Datos del parent para enviar en uploads
                    var tokenData = '';

                    // Funcion helper para configurar los iconos de descarga y eliminar en un archivo
                    function setupFileActions(file, dzInstance) {
                        if (!file.previewElement) return;

                        file.previewElement.classList.add('dz-professional-card');

                        var actionsContainer = file.previewElement.querySelector('.dz-actions');
                        if (!actionsContainer) {
                            actionsContainer = document.createElement('div');
                            actionsContainer.className = 'dz-actions';
                            file.previewElement.appendChild(actionsContainer);
                        }

                        actionsContainer.innerHTML = '';

                        var downloadIcon = document.createElement('a');
                        downloadIcon.href = 'javascript:void(0)';
                        downloadIcon.className = 'dz-download dz-action-btn';
                        downloadIcon.title = getUploaderTranslationAttribute(translations, 'dzDownload', 'title') || 'Descargar';
                        downloadIcon.innerHTML = '<i class="fa fa-download" style="font-size: 16px; color: #178a3f;"></i>';

                        downloadIcon.onclick = function (e) {
                            e.preventDefault();
                            e.stopPropagation();
                            e.stopImmediatePropagation();

                            var fileData = file.serverResponse;
                            if (!fileData) {
                                Logger.log('No se puede descargar el archivo - sin serverResponse');
                                return false;
                            }

                            var downloadUrl;
                            if (fileData.IsLoaded === true && fileData.Id && fileData.Id > 0) {
                                downloadUrl = app.setting.apipath + 'v2/Common/Download?id=' + fileData.Id;
                            } else if (fileData.StoredFileName) {
                                downloadUrl = app.setting.apipath + 'v2/Common/Download?fileName=' + encodeURIComponent(fileData.StoredFileName);
                            } else {
                                Logger.log('Archivo sin ubicacion valida para descargar: ' + JSON.stringify(fileData));
                                return false;
                            }

                            app.core.GetPDF(downloadUrl, true, fileData.FileName, undefined, tokenData);
                            return false;
                        };

                        var deleteIcon = document.createElement('a');
                        deleteIcon.href = 'javascript:void(0)';
                        deleteIcon.className = 'dz-remove dz-action-btn';
                        deleteIcon.title = getUploaderTranslationAttribute(translations, 'dzRemove', 'title') || 'Eliminar';
                        deleteIcon.innerHTML = '<i class="fa fa-trash" style="font-size: 16px; color: #c73340;"></i>';

                        deleteIcon.onclick = function (e) {
                            e.preventDefault();
                            e.stopPropagation();
                            e.stopImmediatePropagation();
                            dzInstance.removeFile(file);
                            return false;
                        };

                        actionsContainer.appendChild(downloadIcon);
                        actionsContainer.appendChild(deleteIcon);

                        renderUploaderAuditInfo(file);
                    }

                    var dz = new Dropzone(this, {
                        url: 'javascript:void(0)',
                        autoProcessQueue: false,
                        clickable: true,
                        maxFilesize: localizedSettings.maxFilesize,
                        parallelUploads: localizedSettings.parallelUploads,
                        addRemoveLinks: false, // Desactivado - usamos iconos personalizados
                        dictDefaultMessage: localizedSettings.dictDefaultMessage,
                        dictFallbackMessage: localizedSettings.dictFallbackMessage,
                        dictFileTooBig: localizedSettings.dictFileTooBig,
                        dictInvalidFileType: localizedSettings.dictInvalidFileType,
                        dictResponseError: localizedSettings.dictResponseError,
                        dictCancelUpload: localizedSettings.dictCancelUpload,
                        dictUploadCanceled: localizedSettings.dictUploadCanceled,
                        dictCancelUploadConfirmation: localizedSettings.dictCancelUploadConfirmation,
                        dictRemoveFile: localizedSettings.dictRemoveFile,
                        dictMaxFilesExceeded: localizedSettings.dictMaxFilesExceeded,

                        init: function () {
                            var self = this;

                            // Remover borde punteado del contenedor
                            $el.css('border', 'none');

                            // Aplicar color rojo al icono de carga
                            $el.find('.fa-cloud-upload').css('color', '#d81e05');

                            self.on('addedfile', function (file) {
                                // ⚠️ CRÍTICO: Ignorar archivos cargados manualmente (ya subidos previamente)
                                if (file.manuallyAdded === true) {
                                    return; // No procesar, solo mostrar en UI
                                }

                                filesToUpload.push(file);
                                pendingUploads++;

                                // Cancelar timer previo si existe
                                if (uploadTimer) {
                                    clearTimeout(uploadTimer);
                                }

                                // Esperar 100ms para agrupar archivos que se agregan juntos
                                uploadTimer = setTimeout(function () {
                                    if (filesToUpload.length > 0) {
                                        processAllFiles();
                                    }
                                }, 100);
                            });

                            function processAllFiles() {
                                var batch = filesToUpload.slice();
                                filesToUpload = [];

                                uploadMultipleFiles(batch, function (result) {
                                    var successList = result.success || [];
                                    var failedList = result.failed || [];

                                    // Asociar respuestas exitosas con sus archivos
                                    for (var i = 0; i < successList.length; i++) {
                                        var response = successList[i];

                                        // Buscar el archivo correspondiente en el batch por nombre
                                        var file = null;
                                        for (var j = 0; j < batch.length; j++) {
                                            if (batch[j].name === response.FileName) {
                                                file = batch[j];
                                                break;
                                            }
                                        }

                                        if (file) {
                                            response.UpdateUserName = response.UpdateUserName || getCurrentUploaderName();
                                            response.UpdateDate = response.UpdateDate || new Date().toISOString();

                                            file.status = Dropzone.SUCCESS;
                                            file.serverResponse = response;
                                            self.emit('success', file, response);
                                            self.emit('complete', file);
                                        }

                                        pendingUploads--;
                                    }

                                    // Procesar archivos fallidos - REMOVERLOS de la interfaz
                                    var errorMessages = [];
                                    for (var i = 0; i < failedList.length; i++) {
                                        var failedItem = failedList[i];

                                        // Buscar el archivo correspondiente en el batch
                                        var failedFile = null;
                                        for (var j = 0; j < batch.length; j++) {
                                            if (batch[j].name === failedItem.FileName) {
                                                failedFile = batch[j];
                                                break;
                                            }
                                        }

                                        if (failedFile) {
                                            // Acumular el error para mostrar en un solo toast
                                            errorMessages.push('<strong>' + failedFile.name + ':</strong><br>' + failedItem.Error);

                                            // REMOVER el archivo de Dropzone (desaparece de la UI)
                                            self.removeFile(failedFile);

                                            pendingUploads--;
                                        }
                                    }

                                    // Log de errores
                                    if (errorMessages.length > 0) {
                                        Logger.log('Error al subir ' + errorMessages.length + ' archivo(s): ' + JSON.stringify(errorMessages));
                                    }

                                    // Si hay archivos fallidos, marcar como error general
                                    if (failedList.length > 0) {
                                        hasError = true;
                                        localizedSettings.fail(failedList, batch);
                                    }

                                    checkQueueComplete();
                                }, function (error, failedFiles) {
                                    hasError = true;

                                    // REMOVER todos los archivos que fallaron por error de AJAX
                                    var ajaxErrorMessages = [];
                                    for (var i = 0; i < failedFiles.length; i++) {
                                        var file = failedFiles[i];

                                        // Acumular el error para mostrar en un solo toast
                                        ajaxErrorMessages.push('<strong>' + file.name + '</strong>');

                                        // REMOVER de la interfaz
                                        self.removeFile(file);

                                        pendingUploads--;
                                    }

                                    // Log de errores AJAX
                                    if (ajaxErrorMessages.length > 0) {
                                        Logger.log('Error AJAX al subir ' + ajaxErrorMessages.length + ' archivo(s): ' + error + ' - ' + JSON.stringify(ajaxErrorMessages));
                                    }

                                    localizedSettings.fail(error, failedFiles);
                                    checkQueueComplete();
                                });
                            }

                            self.on('success', function (file, response) {
                                setTimeout(function () {
                                    applyUploaderFileVisual(file);
                                    setupFileActions(file, self);
                                }, 10);
                            });

                            self.on('error', function (file, error) {
                                // Error event
                            });

                            function checkQueueComplete() {
                                if (pendingUploads === 0) {
                                    var result = {
                                        success: !hasError,
                                        data: responses
                                    };

                                    if (!hasError) {
                                        localizedSettings.done(responses);
                                    }

                                    localizedSettings.always(result);
                                    self.emit('queuecomplete');
                                }
                            }

                            self.on('queuecomplete', function () {
                                // Queue complete event
                            });

                            self.on('removedfile', function (file) {
                                // Solo remover de responses si el archivo fue subido exitosamente
                                if (file.status === Dropzone.SUCCESS && file.serverResponse) {
                                    var index = responses.findIndex(function (r) {
                                        return r.StoredFileName === file.serverResponse.StoredFileName;
                                    });
                                    if (index > -1) {
                                        responses.splice(index, 1);
                                    }
                                }
                            });
                        }
                    });

                    function uploadMultipleFiles(files, successCallback, errorCallback) {
                        var fileData = new FormData();
                        var progressToast = null;
                        var totalSize = 0;

                        // Agregar todos los archivos al FormData y calcular tamaño total
                        for (var i = 0; i < files.length; i++) {
                            var file = files[i];

                            // Verificar que el archivo sea válido
                            if (!file) {
                                continue;
                            }

                            // Dropzone puede envolver el archivo - intentar obtener el archivo original
                            var fileToUpload = file;

                            // Si Dropzone ha envuelto el archivo, puede estar en una propiedad
                            if (file.file && file.file instanceof File) {
                                fileToUpload = file.file;
                            }

                            fileData.append('files', fileToUpload);
                            totalSize += fileToUpload.size || 0;
                        }

                        // Agregar propiedades de parentData al FormData si existe (se establece con load() o setParent())
                        if (parentData) {
                            for (var key in parentData) {
                                if (parentData.hasOwnProperty(key)) {
                                    fileData.append(key, parentData[key]);
                                }
                            }
                        }

                        // Función auxiliar para formatear bytes
                        function formatBytes(bytes) {
                            if (bytes === 0) return '0 Bytes';
                            var k = 1024;
                            var sizes = ['Bytes', 'KB', 'MB', 'GB'];
                            var i = Math.floor(Math.log(bytes) / Math.log(k));
                            return Math.round(bytes / Math.pow(k, i) * 100) / 100 + ' ' + sizes[i];
                        }

                        $.ajax({
                            type: "POST",
                            enctype: 'multipart/form-data',
                            url: app.setting.apipath + 'v2/Common/Upload',
                            data: fileData,
                            processData: false,
                            contentType: false,
                            cache: false,
                            timeout: 600000,
                            xhr: function () {
                                var xhr = new window.XMLHttpRequest();

                                // Evento de progreso de subida
                                xhr.upload.addEventListener('progress', function (e) {
                                    if (e.lengthComputable) {
                                        var percentComplete = Math.round((e.loaded / e.total) * 100);
                                        var loadedSize = formatBytes(e.loaded);
                                        var totalSizeStr = formatBytes(e.total);

                                        var message = '<div style="margin-bottom: 10px;">' +
                                            '<strong>Subiendo ' + files.length + ' archivo(s)...</strong><br>' +
                                            loadedSize + ' de ' + totalSizeStr +
                                            '</div>' +
                                            '<div class="progress" style="height: 20px; margin-bottom: 0;">' +
                                            '<div class="progress-bar progress-bar-striped progress-bar-animated" ' +
                                            'role="progressbar" ' +
                                            'aria-valuenow="' + percentComplete + '" ' +
                                            'aria-valuemin="0" ' +
                                            'aria-valuemax="100" ' +
                                            'style="width: ' + percentComplete + '%">' +
                                            percentComplete + '%' +
                                            '</div>' +
                                            '</div>';

                                        if (!progressToast) {
                                            // Crear el toast la primera vez
                                            progressToast = toastr.info(message, getUploaderTranslationText(translations, 'UploadProgressTitle') || 'Subiendo archivos', {
                                                timeOut: 0,
                                                extendedTimeOut: 0,
                                                closeButton: false,
                                                progressBar: false,
                                                tapToDismiss: false,
                                                positionClass: 'toast-top-right'
                                            });
                                        } else {
                                            // Actualizar el contenido del toast existente
                                            if (progressToast && progressToast.find) {
                                                progressToast.find('.toast-message').html(message);
                                            }
                                        }
                                    }
                                }, false);

                                return xhr;
                            },
                            xhrFields: {
                                withCredentials: true
                            },
                            beforeSend: function (xhr) {
                                var token = tokenData == '' ? app.security ? app.security().getCookie('Token') : localStorage.getItem('Token') : tokenData;
                                xhr.setRequestHeader('Authorization', 'Bearer ' + token);
                            }
                        }).done(function (response) {
                            // Cerrar el toast de progreso
                            if (progressToast) {
                                toastr.clear(progressToast);
                                progressToast = null;
                            }

                            // Manejar nueva estructura de respuesta: { Success: [], Failed: [] }
                            var successList = response.Success || [];
                            var failedList = response.Failed || [];

                            if (successList.length === 0 && failedList.length === 0) {
                                var fileNames = files.map(function (f) { return f.name; }).join(', ');
                                Logger.log('No se recibió respuesta del servidor para archivos: ' + fileNames);
                                errorCallback('No se recibió respuesta del servidor', files);
                                return;
                            }

                            // Procesar archivos exitosos
                            var normalizedSuccessList = [];
                            for (var i = 0; i < successList.length; i++) {
                                var response = successList[i];
                                var file = files[i]; // Asociar por índice

                                // Normalizar la respuesta con propiedades adicionales
                                response.FileSize = response.Size;
                                response.Stored = response.StoredFileName;
                                response.DocumentType = 1;
                                response.DocumentTypeDesc = 'General';
                                response.Description = file ? file.name.replace(/\.[^/.]+$/, "") : '';
                                response.FileContent = response.Stored;

                                responses.push(response);
                                normalizedSuccessList.push(response);
                            }

                            // Log de exito
                            if (successList.length > 0 && failedList.length === 0) {
                                Logger.log('Subida completada: ' + successList.length + ' archivo(s) subido(s) correctamente');
                            }

                            // Retornar ambas listas
                            successCallback({
                                success: normalizedSuccessList,
                                failed: failedList
                            });
                        }).fail(function (jqXHR, textStatus, errorThrown) {
                            // Cerrar el toast de progreso
                            if (progressToast) {
                                toastr.clear(progressToast);
                                progressToast = null;
                            }

                            var errorMsg = 'Error al subir archivos';
                            if (jqXHR.responseJSON && jqXHR.responseJSON.Message) {
                                errorMsg = jqXHR.responseJSON.Message;
                            } else if (errorThrown) {
                                errorMsg = errorThrown;
                            }

                            // No mostrar toast aquí - se maneja en errorCallback para consolidar errores
                            errorCallback(errorMsg, files);
                        });
                    }

                    // Crear instancia con referencia al array responses
                    var instance = {
                        dz: dz,
                        elementId: elementId,
                        translations: translations,
                        responses: responses,
                        setupFileActions: setupFileActions, // Exponer funcion para uso en load()
                        getFiles: function () {
                            return responses.slice();
                        },
                        getParent: function () {
                            return parentData;
                        },
                        setParent: function (parent) {
                            parentData = parent;
                        },
                        getToken: function () {
                            return tokenData;
                        },
                        setToken: function (token) {
                            tokenData = token;
                        },
                        getPendingCount: function () {
                            return pendingUploads;
                        },
                        promise: function () {
                            var deferred = $.Deferred();

                            if (pendingUploads === 0) {
                                deferred.resolve(responses);
                            } else {
                                dz.on('queuecomplete', function () {
                                    deferred.resolve(responses);
                                });
                            }

                            return deferred.promise();
                        },
                        clear: function () {
                            responses.length = 0;
                            filesToUpload.length = 0;
                            hasError = false;
                            pendingUploads = 0;
                            if (uploadTimer) {
                                clearTimeout(uploadTimer);
                                uploadTimer = null;
                            }
                            dz.removeAllFiles(true);
                        },
                        downloadAll: function () {
                            var files = responses.slice();

                            if (files.length === 0) {
                                Logger.log('No hay archivos para descargar');
                                return;
                            }

                            Logger.log('Descargando ' + files.length + ' archivo(s)...');

                            // Descargar cada archivo con un delay para evitar bloquear el navegador
                            files.forEach(function (file, index) {
                                setTimeout(function () {
                                    var downloadUrl;

                                    // Si el archivo fue cargado con load() y tiene Id, descargar desde BD
                                    if (file.IsLoaded === true && file.Id && file.Id > 0) {
                                        // Archivo guardado en base de datos (cargado con load())
                                        downloadUrl = app.setting.apipath + 'v2/Common/Download?id=' + file.Id;
                                    } else if (file.StoredFileName) {
                                        // Archivo temporal en servidor (recién subido, no guardado aún)
                                        downloadUrl = app.setting.apipath + 'v2/Common/Download?fileName=' + encodeURIComponent(file.StoredFileName);
                                    } else {
                                        Logger.log('Archivo sin StoredFileName ni Id válido: ' + JSON.stringify(file));
                                        return;
                                    }

                                    // Usar app.core.GetPDF() para manejar la descarga
                                    app.core.GetPDF(downloadUrl, true, file.FileName, function () {
                                        // Callback cuando termine la descarga
                                        if (index === files.length - 1) {
                                            Logger.log('Descarga completada: ' + files.length + ' archivo(s) descargado(s)');
                                        }
                                    }, tokenData);
                                }, index * 500); // Delay de 500ms entre cada descarga
                            });
                        },
                        downloadZip: function () {
                            var files = responses.slice();

                            if (files.length === 0) {
                                Logger.log('No hay archivos para descargar');
                                return;
                            }

                            Logger.log('Preparando archivo ZIP...');

                            // Construir estructura con información completa de cada archivo
                            var fileItems = files.map(function (f) {
                                return {
                                    Id: f.Id || null,
                                    FileName: f.FileName,
                                    StoredFileName: f.StoredFileName,
                                    IsLoaded: f.IsLoaded === true // Archivos cargados con load() tienen IsLoaded: true
                                };
                            });

                            $.ajax({
                                type: 'POST',
                                url: app.setting.apipath + 'v2/Common/DownloadZipV2',
                                data: JSON.stringify(fileItems),
                                contentType: 'application/json',
                                xhrFields: {
                                    responseType: 'blob'
                                },
                                beforeSend: function (xhr) {
                                    var token = tokenData == '' ? app.security ? app.security().getCookie('Token') : localStorage.getItem('Token') : tokenData;
                                    xhr.setRequestHeader('Authorization', 'Bearer ' + token);
                                }
                            }).done(function (blob) {
                                // Crear URL para el blob y descargarlo
                                var url = window.URL.createObjectURL(blob);
                                var a = document.createElement('a');
                                a.href = url;
                                a.download = (getUploaderTranslationText(translations, 'ZipFileNamePrefix') || 'adjuntos') + '_' + new Date().getTime() + '.zip';
                                a.style.display = 'none';
                                document.body.appendChild(a);
                                a.click();

                                // Limpiar
                                setTimeout(function () {
                                    window.URL.revokeObjectURL(url);
                                    document.body.removeChild(a);
                                }, 100);

                                Logger.log('Archivo ZIP descargado correctamente');
                            }).fail(function (jqXHR, textStatus, errorThrown) {
                                var errorMsg = 'Error al generar el archivo ZIP';
                                if (jqXHR.responseJSON && jqXHR.responseJSON.Message) {
                                    errorMsg = jqXHR.responseJSON.Message;
                                } else if (errorThrown) {
                                    errorMsg = errorThrown;
                                }

                                Logger.log('Error de descarga ZIP: ' + errorMsg);
                            });
                        },
                        destroy: function () {
                            responses.length = 0;
                            filesToUpload.length = 0;
                            hasError = false;
                            pendingUploads = 0;
                            if (uploadTimer) {
                                clearTimeout(uploadTimer);
                                uploadTimer = null;
                            }
                            if (dz) {
                                dz.destroy();
                            }
                            $el.removeData('fileUploader');
                        }
                    };

                    $el.data('fileUploader', instance);
                    runUploaderTranslation(translationScope, translationPath, function (translatedValues) {
                        translations = translatedValues || {};
                        localizedSettings = localizeUploaderSettings(settings, translations);
                        applyUploaderTranslationState($el, translationScope, dz, instance, settings, translations);
                    });

                    // 🔹 Auto-configurar botones de descarga si están habilitados
                    if (localizedSettings.enableDownloadButtons) {
                        // Buscar botones con data-fileuploader-action
                        var $downloadAllBtn = $('[data-fileuploader-target="' + elementId + '"][data-fileuploader-action="downloadAll"]');
                        var $downloadZipBtn = $('[data-fileuploader-target="' + elementId + '"][data-fileuploader-action="downloadZip"]');

                        // Configurar evento para descargar archivos individuales
                        if ($downloadAllBtn.length > 0) {
                            $downloadAllBtn.off('click').on('click', function (e) {
                                e.preventDefault();
                                instance.downloadAll();
                            });
                        }

                        // Configurar evento para descargar ZIP
                        if ($downloadZipBtn.length > 0) {
                            $downloadZipBtn.off('click').on('click', function (e) {
                                e.preventDefault();
                                instance.downloadZip();
                            });
                        }
                    }
                });
            },

            files: function () {
                var inst = this.first().data('fileUploader');
                if (!inst) {
                    return [];
                }
                return inst.getFiles();
            },

            pending: function () {
                var inst = this.first().data('fileUploader');
                if (!inst) return 0;
                return inst.getPendingCount();
            },

            promise: function () {
                var inst = this.first().data('fileUploader');
                if (!inst) return $.Deferred().resolve([]).promise();
                return inst.promise();
            },

            clear: function () {
                var inst = this.first().data('fileUploader');
                if (inst) inst.clear();
                return this;
            },

            load: function (files, parent, token = '') {
                var inst = this.first().data('fileUploader');
                if (!inst) return this;

                // Limpiar archivos existentes antes de cargar los nuevos (resetear instancia)
                inst.clear();

                // Guardar parent si se proporciona
                if (parent !== undefined && parent !== null) {
                    inst.setParent(parent);
                }
                // Guardar token si se proporciona
                if (token !== undefined && token !== null) {
                    inst.setToken(token);
                }

                // Si no hay archivos para cargar, solo se hizo el clear
                if (!files || files.length === 0) return this;

                files.forEach(function (fileData) {
                    // Normalizar la estructura del archivo
                    var normalizedFile = {
                        Id: fileData.Id,
                        FileName: fileData.FileName,
                        StoredFileName: fileData.StoredFileName || fileData.Stored || fileData.FileContent,
                        Size: fileData.Size || fileData.FileSize,
                        FileSize: fileData.FileSize || fileData.Size,
                        Stored: fileData.StoredFileName || fileData.Stored || fileData.FileContent,
                        DocumentType: fileData.DocumentType || 1,
                        DocumentTypeDesc: fileData.DocumentTypeDesc || 'General',
                        Description: fileData.Description || fileData.FileName,
                        FileContent: fileData.StoredFileName || fileData.Stored || fileData.FileContent,
                        UpdateUserName: fileData.UpdateUserName || fileData.UPDATEUSERNAME || fileData.CreatedByName || fileData.UserName || '',
                        UpdateDate: fileData.UpdateDate || fileData.UPDATEDATE || fileData.CreatedDate || fileData.CreateDate || fileData.UploadDate || null,
                        IsLoaded: true // Indica que este archivo ya está cargado
                    };

                    // Agregar a responses
                    inst.responses.push(normalizedFile);

                    // Crear un mock file para Dropzone con propiedades que previenen el procesamiento automático
                    var mockFile = {
                        name: normalizedFile.FileName,
                        size: normalizedFile.Size,
                        type: getMimeType(normalizedFile.FileName),
                        status: Dropzone.SUCCESS,
                        accepted: true,
                        upload: {
                            progress: 100,
                            total: normalizedFile.Size,
                            bytesSent: normalizedFile.Size
                        },
                        serverResponse: normalizedFile,
                        // Prevenir que Dropzone intente subir este archivo
                        manuallyAdded: true
                    };

                    // Deshabilitar temporalmente el evento addedfile que activa el upload
                    var originalAddedFile = inst.dz.options.autoProcessQueue;
                    inst.dz.options.autoProcessQueue = false;

                    // Agregar el archivo a Dropzone manualmente
                    inst.dz.files.push(mockFile);
                    inst.dz.emit("addedfile", mockFile);

                    setTimeout(function () {
                        applyUploaderFileVisual(mockFile);
                        inst.setupFileActions(mockFile, inst.dz);
                    }, 10); // Pequeño delay para asegurar que el DOM esté listo

                    // Marcar como completo (esto evita que Dropzone intente subirlo)
                    inst.dz.emit("complete", mockFile);

                    // Restaurar configuración original
                    inst.dz.options.autoProcessQueue = originalAddedFile;
                });

                return this;
            },

            downloadAll: function () {
                var inst = this.first().data('fileUploader');
                if (inst) inst.downloadAll();
                return this;
            },

            downloadZip: function () {
                var inst = this.first().data('fileUploader');
                if (inst) inst.downloadZip();
                return this;
            },

            destroy: function () {
                return this.each(function () {
                    var inst = $(this).data('fileUploader');
                    if (inst) inst.destroy();
                });
            }
        };

        if (methods[optionsOrMethod]) {
            return methods[optionsOrMethod].apply(
                this,
                Array.prototype.slice.call(arguments, 1)
            );
        } else if (typeof optionsOrMethod === 'object' || !optionsOrMethod) {
            return methods.init.apply(this, arguments);
        } else {
            $.error('Método ' + optionsOrMethod + ' no existe en fileUploader');
        }
    };
})(jQuery);
