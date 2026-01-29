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

                    // Prevenir inicialización duplicada
                    if ($el.data('fileUploader')) {
                        return;
                    }

                    // Verificar si Dropzone ya está adjunto directamente
                    if ($el[0].dropzone) {
                        $el[0].dropzone.destroy();
                    }

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

                        // Aplicar estilos al preview element para que crezca con transicion
                        file.previewElement.style.borderRadius = '20px';
                        file.previewElement.style.overflow = 'hidden';
                        file.previewElement.style.position = 'relative';
                        file.previewElement.style.transition = 'all 0.3s ease';

                        // Aplicar border-radius al dz-image
                        var dzImage = file.previewElement.querySelector('.dz-image');
                        if (dzImage) {
                            dzImage.style.borderRadius = '20px 20px 0 0';
                        }

                        // Aplicar border-radius al dz-details
                        var dzDetails = file.previewElement.querySelector('.dz-details');
                        if (dzDetails) {
                            dzDetails.style.borderRadius = '20px 20px 0 0';
                        }

                        // Buscar o crear el contenedor de acciones
                        var actionsContainer = file.previewElement.querySelector('.dz-actions');
                        if (!actionsContainer) {
                            actionsContainer = document.createElement('div');
                            actionsContainer.className = 'dz-actions';
                            // Usar max-height para animar el crecimiento, sin position absolute
                            actionsContainer.style.cssText = 'display: flex; justify-content: center; gap: 15px; padding: 0; background: linear-gradient(to bottom, #f8f9fa, #e9ecef); border-radius: 0 0 20px 20px; box-shadow: inset 0 2px 5px rgba(0, 0, 0, 0.1); max-height: 0; overflow: hidden; transition: max-height 0.3s ease, padding 0.3s ease;';

                            // Insertar al final del preview element (flujo normal, no absoluto)
                            file.previewElement.appendChild(actionsContainer);

                            // Configurar eventos de hover en el preview element
                            $(file.previewElement).on('mouseenter', function () {
                                // Expandir el contenedor de acciones
                                actionsContainer.style.maxHeight = '50px';
                                actionsContainer.style.padding = '10px 5px';
                            }).on('mouseleave', function () {
                                // Contraer el contenedor de acciones
                                actionsContainer.style.maxHeight = '0';
                                actionsContainer.style.padding = '0';
                            });
                        }

                        // Limpiar contenido previo
                        actionsContainer.innerHTML = '';

                        // Crear icono de descarga
                        var downloadIcon = document.createElement('a');
                        downloadIcon.href = 'javascript:void(0)';
                        downloadIcon.className = 'dz-download';
                        downloadIcon.title = 'Descargar';
                        downloadIcon.innerHTML = '<i class="fa fa-download" style="font-size: 18px; color: #28a745;"></i>';
                        downloadIcon.style.cssText = 'cursor: pointer; padding: 5px; display: inline-block;';

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

                        // Crear icono de eliminar
                        var deleteIcon = document.createElement('a');
                        deleteIcon.href = 'javascript:void(0)';
                        deleteIcon.className = 'dz-remove';
                        deleteIcon.title = 'Eliminar';
                        deleteIcon.innerHTML = '<i class="fa fa-trash" style="font-size: 18px; color: #dc3545;"></i>';
                        deleteIcon.style.cssText = 'cursor: pointer; padding: 5px; display: inline-block;';

                        deleteIcon.onclick = function (e) {
                            e.preventDefault();
                            e.stopPropagation();
                            e.stopImmediatePropagation();
                            dzInstance.removeFile(file);
                            return false;
                        };

                        // Agregar iconos al contenedor
                        actionsContainer.appendChild(downloadIcon);
                        actionsContainer.appendChild(deleteIcon);
                    }

                    var dz = new Dropzone(this, {
                        url: 'javascript:void(0)',
                        autoProcessQueue: false,
                        clickable: true,
                        maxFilesize: settings.maxFilesize,
                        parallelUploads: settings.parallelUploads,
                        addRemoveLinks: false, // Desactivado - usamos iconos personalizados
                        dictDefaultMessage: settings.dictDefaultMessage,
                        dictFallbackMessage: settings.dictFallbackMessage,
                        dictFileTooBig: settings.dictFileTooBig,
                        dictInvalidFileType: settings.dictInvalidFileType,
                        dictResponseError: settings.dictResponseError,
                        dictCancelUpload: settings.dictCancelUpload,
                        dictUploadCanceled: settings.dictUploadCanceled,
                        dictCancelUploadConfirmation: settings.dictCancelUploadConfirmation,
                        dictRemoveFile: settings.dictRemoveFile,
                        dictMaxFilesExceeded: settings.dictMaxFilesExceeded,

                        init: function () {
                            var self = this;

                            // Aplicar borde verde para indicar zona de carga activa
                            $el.css('border', '2px dashed #d81e05');

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
                                        settings.fail(failedList, batch);
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

                                    settings.fail(error, failedFiles);
                                    checkQueueComplete();
                                });
                            }

                            self.on('success', function (file, response) {
                                // Configurar iconos de descarga y eliminar
                                setupFileActions(file, self);
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
                                        settings.done(responses);
                                    }

                                    settings.always(result);
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
                                            progressToast = toastr.info(message, 'Subiendo archivos', {
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
                                a.download = 'adjuntos_' + new Date().getTime() + '.zip';
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

                    // 🔹 Auto-configurar botones de descarga si están habilitados
                    if (settings.enableDownloadButtons) {
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

                    // Para archivos precargados, usar ícono de Font Awesome en lugar de thumbnail
                    setTimeout(function () {
                        // Buscar el elemento de preview del archivo recién agregado
                        var previewElement = mockFile.previewElement;
                        if (previewElement) {
                            var dzImage = previewElement.querySelector('.dz-image');
                            if (dzImage) {
                                // Limpiar contenido existente
                                dzImage.innerHTML = '';

                                // Determinar el ícono según el tipo de archivo
                                var iconClass = 'fa fa-file-o'; // Ícono por defecto
                                var iconColor = '#6c757d'; // Gris por defecto

                                if (mockFile.type) {
                                    if (mockFile.type.startsWith('image/')) {
                                        iconClass = 'fa fa-file-image-o';
                                        iconColor = '#28a745'; // Verde
                                    } else if (mockFile.type === 'application/pdf') {
                                        iconClass = 'fa fa-file-pdf-o';
                                        iconColor = '#dc3545'; // Rojo
                                    } else if (mockFile.type.includes('word') || mockFile.type.includes('document')) {
                                        iconClass = 'fa fa-file-word-o';
                                        iconColor = '#2b579a'; // Azul Word
                                    } else if (mockFile.type.includes('excel') || mockFile.type.includes('sheet')) {
                                        iconClass = 'fa fa-file-excel-o';
                                        iconColor = '#217346'; // Verde Excel
                                    } else if (mockFile.type.includes('powerpoint') || mockFile.type.includes('presentation')) {
                                        iconClass = 'fa fa-file-powerpoint-o';
                                        iconColor = '#d24726'; // Naranja PowerPoint
                                    } else if (mockFile.type.includes('zip') || mockFile.type.includes('compressed') || mockFile.type.includes('rar')) {
                                        iconClass = 'fa fa-file-archive-o';
                                        iconColor = '#ffc107'; // Amarillo
                                    } else if (mockFile.type.includes('text')) {
                                        iconClass = 'fa fa-file-text-o';
                                        iconColor = '#007bff'; // Azul
                                    }
                                }

                                // Crear el ícono
                                var iconElement = document.createElement('i');
                                iconElement.className = iconClass;
                                iconElement.style.fontSize = '60px';
                                iconElement.style.color = iconColor;
                                iconElement.style.display = 'flex';
                                iconElement.style.alignItems = 'center';
                                iconElement.style.justifyContent = 'center';
                                iconElement.style.width = '100%';
                                iconElement.style.height = '100%';

                                // Agregar el ícono al contenedor
                                dzImage.appendChild(iconElement);
                                dzImage.style.display = 'flex';
                                dzImage.style.alignItems = 'center';
                                dzImage.style.justifyContent = 'center';

                                // Configurar iconos de descarga y eliminar
                                inst.setupFileActions(mockFile, inst.dz);
                            }
                        }
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