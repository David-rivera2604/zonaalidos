var app = {};

// CONSERVAR DEL ORIGINAL DESDE AQUI
app.setting = {
    apibase: 'https://localhost:44341',
    apipath: 'https://localhost:44341/aliados/api/',
    basepath: '/Aliados/',
    viewpath: 'https://localhost:44341/aliados/',
    entityapi: 'https://appqa.mapfrecr.com/datapides/api/entity',
    reportapi: 'https://appqa.mapfrecr.com/aliadoservreports'
};
// CONSERVAR DEL ORIGINAL HASTA AQUI

app.state = { entityType: 0 };

app.DateEmpty = '0001-01-01T00:00:00';

String.prototype.format = function () {
    var args = arguments;
    return this.replace(/\{\{|\}\}|\{(\d+)\}/g, function (m, n) {
        if (m == "{{") { return "{"; }
        if (m == "}}") { return "}"; }
        return args[n];
    });
};

String.prototype.parseFunction = function () {
    var funcReg = /function *\(([^()]*)\)[ \n\t]*{(.*)}/gmi;
    var match = funcReg.exec(this.replace(/\n/g, ' '));
    if (match) {
        return new Function(match[1].split(','), match[2]);
    }
    return null;
};

String.prototype.supplant = function (o) {
    return this.replace(/\{([^\{\}]*)\}/g, function (a, b) {
        var p = b.split('.'), r = o;
        try {
            for (var s in p) { r = r[p[s]]; };
        } catch (e) {
            r = a;
        }
        if (r === null) r = '';
        return (typeof r === 'string' || typeof r === 'number') ? r : a;
    });
};

app.core = (function () {
    let inactiveSeconds = 0;

    let lookupData = [];

    function getAuthToken() {
        return localStorage.getItem("Token");
        token = app.security().getCookie('AuthToken');
        if (token != null && token != '') {
            return token;
        }
    }

    function getLanguage() {
        return sessionStorage.getItem('language');
    }

    function GetPDF(url, download, filename, callback, alterToken = '') {
        let excel = false;

        if (url.startsWith('excel.')) {
            url = app.setting.apipath + 'v1/DataSource/excel?id=' + url.substring(6);
            excel = true;
            $('.ibox-content').toggleClass('sk-loading');
        }
        let blobType = 'application/pdf';
        if (filename === null) {
            filename = new Date() + ".pdf";
        }
        if (filename.endsWith(".xlsx")) {
            blobType = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;';
        }
        let token = alterToken == '' ? getAuthToken() : alterToken;
        let language = getLanguage();
        let headers = {
            'Content-Type': 'application/json; charset=utf-8',
            'Authorization': 'Bearer ' + token
        };
        if (language)
            headers['Accept-Language'] = language;
        fetch(url, {
            body: null,
            method: 'GET',
            headers: headers,
        }).then(response => {
            if (!response.ok) { throw response }
            return response.blob();
        }).then(response => {
            let blob = new Blob([response], { type: blobType });
            let downloadUrl = URL.createObjectURL(blob);

            if (download) {
                let a = document.createElement("a");
                a.href = downloadUrl;

                a.download = filename;
                a.click();
                a.remove()
            }
            else {
                window.open(downloadUrl);
            }
            if (callback !== undefined && callback !== null) {
                callback();
            }
            if (excel)
                $('.ibox-content').toggleClass('sk-loading');
        }).catch(function (error) {
            if (callback !== undefined && callback !== null) {
                callback();
            }
            if (excel)
                $('.ibox-content').toggleClass('sk-loading');
            toastr.error("Por favor intente nuevamente y en caso de persistir el problema contacte el personal de soporte", "Ha ocurrido un error no controlado", { timeOut: 10000, closeButton: true, progressBar: true });
            error.json().then(body => {
                console.info('%c Error ', 'color: white; background-color: #D33F49', body.ExceptionMessage);
                console.groupCollapsed('%c Detalle ', 'color: white; background-color: #2274A5');
                console.info(body.Message);
                console.info(body.ExceptionType);
                console.info(body.StackTrace);
                console.groupEnd();
            });
        });
    }

    function FileUpLoad(options = {}) {
        const conf = {
            formId: null,
            uploadCtrolId: '#fileUploadModal',
            entityType: 0,
            entityId: 0,
            documentType: 99,
            description: null,
            callback: null
        };
        const fullconfig = { ...conf, ...options };

        const $fileInput = $(fullconfig.uploadCtrolId);
        const fileList = $fileInput.prop('files');

        const arr = Array.from(fileList);

        if (arr.length === 0) {
            return;
        }

        if (fullconfig.formId != null && !app.ui.IsValid(fullconfig.formId, false, true)) {
            return;
        }

        let message = '';
        for (const file of arr) {
            message = FileUpLoadValidate(file.name, file.size, file.type, message);
        }

        if (message !== '') {
            if (fullconfig.formId) {
                const elementInstance = $(fullconfig.formId).validate();
                if (elementInstance) {
                    elementInstance.showErrors({ 'FileName': message });
                }
            } else {
                alert(message);
            }
            return;
        }

        app.ui.ButtonDoing(fullconfig.uploadCtrolId);

        const fileData = new FormData();
        fileData.append('EntityType', fullconfig.entityType);
        fileData.append('EntityId', fullconfig.entityId);
        fileData.append('DocumentType', fullconfig.documentType);
        if (fullconfig.description == null) {
            fileData.append('Description', arr[0].name);
        } else {
            fileData.append('Description', fullconfig.description);
        }
        for (const file of arr) {
            fileData.append('files', file);
        }
        $.ajax({
            type: "POST",
            enctype: 'multipart/form-data',
            url: app.setting.apipath + 'v1/Common/Upload',
            data: fileData,
            processData: false,
            contentType: false,
            cache: false,
            timeout: 600000,
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + getAuthToken());
                let language = getLanguage();
                if (language)
                    xhr.setRequestHeader('Accept-Language', language);
            }
        }).done(function (response) {
            if (typeof fullconfig.callback === 'function') {
                fullconfig.callback(response);
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            ajaxErrorHandler(jqXHR, errorThrown);
        }).always(function () {
            app.ui.ButtonDone(fullconfig.uploadCtrolId)
        });
    }

    function FileUpLoadValidate(name, size, type, currentMessage) {
        const KB = 1024;
        const MB = 1024 * 1024;

        const MIN_SIZE_WORD_PDF = 13 * KB;
        const MIN_SIZE_EXCEL = 9 * KB;
        const MAX_SIZE = 30 * MB;

        const TYPE_WORD = 'application/vnd.openxmlformats-officedocument.wordprocessingml.document';
        const TYPE_PDF = 'application/pdf';
        const TYPE_EXCEL = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet';

        let msg = currentMessage;

        const addMsg = (newText) => {
            if (msg !== '') msg += ', ';
            msg += newText;
        };

        if ((type === TYPE_WORD || type === TYPE_PDF) && size < MIN_SIZE_WORD_PDF) {
            addMsg('El tamaño del archivo ' + name + ' es menor a 13kb');
        }

        if (type === TYPE_EXCEL && size < MIN_SIZE_EXCEL) {
            addMsg('El tamaño del archivo ' + name + ' es menor a 9kb');
        }

        if (size >= MAX_SIZE) {
            addMsg('El tamaño del archivo ' + name + ' es mayor a 30mb');
        }

        if (name.length > 255) {
            addMsg('El nombre del archivo debe ser menor a 255 caracteres');
        }

        return msg;
    }

    function ajaxCall(type, url, data, success, token, contentType, alterToken) {
        var dataType = 'json';

        if (contentType === undefined)
            contentType = 'application/json; charset=utf-8'

        if (contentType === 'text/html; charset=utf-8')
            dataType = 'text';

        if (data === undefined)
            data = null;
        return $.ajax({
            url: url,
            type: type,
            contentType: contentType,
            dataType: dataType,
            async: true,
            cache: false,
            data: data,
            xhrFields: {
                withCredentials: true
            },
            beforeSend: function (xhr) {
                if (token) {
                    if (alterToken === undefined) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + getAuthToken());
                    } else {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + alterToken);
                    }
                }
                let language = getLanguage();
                if (language)
                    xhr.setRequestHeader('Accept-Language', language);
            }
        }).done(function (data, textStatus, jqXHR) {
            if (data != null && data.Success !== undefined) {
                if (data.Success) {
                    toastr.success(data.Reason, '', { timeOut: 7000, closeButton: true, progressBar: true });
                } else {
                    toastr.error(data.Reason, '', { timeOut: 7000, closeButton: true, progressBar: true });
                }
            }
            if (data != null && data.Mensaje !== undefined && data.Mensaje !== null) {
                toastr.info(data.Mensaje, '', { timeOut: 7000, closeButton: true, progressBar: true });
            }
            if (success !== undefined)
                success(data);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            ajaxErrorHandler(jqXHR, errorThrown);
        }).always(function () {
        });
    }

    function ajaxErrorHandler(jqXHR, errorThrown) {
        switch (jqXHR.status) {
            case 400:
                if (jqXHR.responseJSON.ModelState != undefined) {
                    $.each(jqXHR.responseJSON.ModelState, function (key, value) {
                        var options = {};
                        if (key.lastIndexOf('*') === -1) {
                            options[key.split('.')[1]] = value;
                            $('#' + key.split('.')[0] + 'EdtForm').validate().showErrors(options);
                        } else {
                            //app.ui.ShowAlert(key + 'Notify', 'alert-danger', value);
                            app.ui.ShowAlert('generalNotify', 'alert-danger', value);
                        }
                    });
                }
                else {
                    toastr.error(jqXHR.responseJSON.Message, "Ha ocurrido un error", { timeOut: 10000, closeButton: true, progressBar: true });
                }
                break;
            case 401:
                let path = window.location.pathname.toLowerCase();
                if (path.endsWith('/cases/case') || path.endsWith('/viewer/viewer')) {
                    localStorage.setItem('lasthref', window.location.href);
                }
                window.location.replace(app.setting.basepath + "Security/Login");
                break;
            case 404:
                if (jqXHR.responseText !== undefined && jqXHR.responseText.indexOf('- 404.0 -') > -1) {
                    console.info('%c Error ', 'color: white; background-color: #D33F49', jqXHR.status, ' - ', errorThrown);
                }
                else {
                    console.info('%c Error controlado ', 'color: white; background-color: #49d33f', jqXHR.status, ' - ', jqXHR.responseText);
                }
                break;
            case 500:
                toastr.error("Por favor intente nuevamente y en caso de persistir el problema contacte el personal de soporte", "Ha ocurrido un error no controlado", { timeOut: 10000, closeButton: true, progressBar: true });

                console.info('%c Error ', 'color: white; background-color: #D33F49', jqXHR.statusText);
                console.groupCollapsed('%c Detalle ', 'color: white; background-color: #2274A5');
                console.info(jqXHR.responseJSON.Message);
                console.info(jqXHR.responseJSON.ExceptionType);
                console.info(jqXHR.responseJSON.StackTrace);
                console.groupEnd();

                break;
            default:
                if (jqXHR.responseJSON !== undefined) {
                    console.info('%c Error ', 'color: white; background-color: #D33F49', jqXHR.responseJSON.ExceptionMessage);
                    console.groupCollapsed('%c Detalle ', 'color: white; background-color: #2274A5');
                    console.info(jqXHR.responseJSON.Message);
                    console.info(jqXHR.responseJSON.ExceptionType);
                    console.info(jqXHR.responseJSON.StackTrace);
                    console.groupEnd();
                } else {
                    console.info('%c Error ', 'color: white; background-color: #D33F49', jqXHR.status, ' - ', errorThrown);
                }
        }
    }

    function Lookups(keys, callback, url, path, alterToken) {
        var onlyKeys = [];
        var ctrls = [];
        var ctrlName = [];
        var emptyValues = [];
        var selectCtrol = [];
        var ctrl;
        var selectedOptions;

        $.each(keys, function (index, value) {
            if (value.split('.')[0].startsWith('@')) {
                selectCtrol.push(false);
                onlyKeys.push(value.split('.')[0].substring(1));
            }
            else {
                selectCtrol.push(true);
                onlyKeys.push(value.split('.')[0]);
            }

            if (value.split('.').length > 1)
                ctrl = value.split('.')[1];
            else
                ctrl = value;

            if (ctrl.startsWith('@'))
                ctrl = ctrl.substring(1);

            if (value.split('.').length > 2)
                emptyValues.push(value.split('.')[2]);
            else
                emptyValues.push(null);

            ctrlName.push(ctrl);
            selectedOptions = $('select#' + ctrl);
            ctrls.push(selectedOptions);
            selectedOptions.children().remove();
            selectedOptions.append($('<option />').val('0').text(' Cargando...'));
        });

        if (url === undefined) {
            url = '';
        }

        ajaxCall('GET', app.setting.apipath + path + '?keys=' + onlyKeys.toString() + '&url=' + url, null,
            function (data) {
                var key = '', ctrl = '';

                $.each(data, function (index, values) {
                    let current = lookupData.filter(i => i.Key === values.Key)
                    if (current.length > 0) {
                        lookupData.splice(lookupData.indexOf(current[0]), 1);
                    }
                    lookupData.push(values);

                    selectedOptions = ctrls[index];
                    if (selectCtrol[index]) {
                        selectedOptions.children().remove();
                        if (emptyValues[index] !== null) {
                            selectedOptions.append($('<option />').val(0).text(emptyValues[index]));
                        }
                        $.each(values.Lkp, function () {
                            selectedOptions.append($('<option />').val(this['Code']).text(this['Description']));
                        });
                        if (selectedOptions.data("autoselect") === true) {
                            selectedOptions.val($('select#' + ctrlName[index] + ' option:first').val());
                            selectedOptions.trigger('change');
                        } else {
                            selectedOptions.val(-1);
                        }
                        if (selectedOptions.data("emptydisabled") === true) {
                            selectedOptions.prop('disabled', selectedOptions.children().length == 0);
                        }
                    }
                    else {
                        selectedOptions.replaceWith('<div id="radio' + ctrlName[index] + '"></div>');
                        selectedOptions = $('#radio' + ctrlName[index]);
                        $.each(values.Lkp, function () {
                            selectedOptions.append('<div class="custom-control custom-radio custom-control-inline"><input type="radio" class="custom-control-input" id="' + ctrlName[index] + '_' + this['Code'] + '" name="' + ctrlName[index] + '" value="' + this['Code'] + '"><label class="custom-control-label" for="' + ctrlName[index] + '_' + this['Code'] + '">' + this['Description'] + '</label></div>');
                        });
                    }
                });
                if (callback !== undefined && callback !== null)
                    callback();
            }, true, undefined, alterToken);
    };

    function LookupDependency(parentValue, childId, lookupKey, emptyValue, newValue, triggerChange, callback, url, path) {
        var childElement = $('select#' + childId);
        if (parentValue !== null && parentValue !== '0') {
            childElement.children().remove();
            childElement.append($('<option />').val('0').text(' Cargando...'));
            if (url === undefined) {
                url = '';
            }
            else {
                url = url + (url.endsWith('=') ? parentValue : '');
            }

            ajaxCall('GET', app.setting.apipath + path + '?key=' + lookupKey + '&parentId=' + parentValue + '&url=' + url, null,
                function (data) {
                    childElement.children().remove();
                    if (emptyValue !== null) {
                        childElement.append($('<option />').val(0).text(emptyValue));
                    }
                    $.each(data, function () {
                        childElement.append($('<option />').val(this['Code']).text(this['Description']));
                    });
                    if (newValue !== null)
                        childElement.val(newValue);
                    else
                        childElement.val(-1);
                    if (triggerChange)
                        childElement.trigger('change');
                    if (callback !== undefined && callback !== null)
                        callback(data);
                }, true);
        }
        else {
            childElement.children().remove();
            if (triggerChange)
                childElement.trigger('change');
        }
    };

    function URLNumericValue(key) {
        var value = URLValue(key, decodeURIComponent(window.location.href));
        if (value === null)
            value = 0;
        else
            if (isNaN(value))
                value = 0;
            else
                value = parseInt(value);
        return value;
    }

    function URLStringValue(key) {
        var value = URLValue(key, decodeURIComponent(window.location.href));
        if (value === null)
            value = '';
        return value;
    }

    function URLValues(url) {
        // get query string from url (optional) or window
        var queryString = url ? url.split('?')[1] : decodeURIComponent(window.location.search.slice(1));

        // we'll store the parameters here
        var obj = {};

        // if query string exists
        if (queryString) {
            // stuff after # is not part of query string, so get rid of it
            queryString = queryString.split('#')[0];

            // split our query string into its component parts
            var arr = queryString.split('&');

            for (var i = 0; i < arr.length; i++) {
                // separate the keys and the values
                var a = arr[i].split('=');

                // set parameter name and value (use 'true' if empty)
                var paramName = a[0];
                var paramValue = typeof (a[1]) === 'undefined' ? true : a[1];

                // (optional) keep case consistent
                paramName = paramName.toLowerCase();
                if (typeof paramValue === 'string') paramValue = paramValue.toLowerCase();

                // if the paramName ends with square brackets, e.g. colors[] or colors[2]
                if (paramName.match(/\[(\d+)?\]$/)) {
                    // create key if it doesn't exist
                    var key = paramName.replace(/\[(\d+)?\]/, '');
                    if (!obj[key]) obj[key] = [];

                    // if it's an indexed array e.g. colors[2]
                    if (paramName.match(/\[\d+\]$/)) {
                        // get the index value and add the entry at the appropriate position
                        var index = /\[(\d+)\]/.exec(paramName)[1];
                        obj[key][index] = paramValue;
                    } else {
                        // otherwise add the value to the end of the array
                        obj[key].push(paramValue);
                    }
                } else {
                    // we're dealing with a string
                    if (!obj[paramName]) {
                        // if it doesn't exist, create property
                        obj[paramName] = paramValue;
                    } else if (obj[paramName] && typeof obj[paramName] === 'string') {
                        // if property does exist and it's a string, convert it to an array
                        obj[paramName] = [obj[paramName]];
                        obj[paramName].push(paramValue);
                    } else {
                        // otherwise add the property
                        obj[paramName].push(paramValue);
                    }
                }
            }
        }

        return obj;
    }

    function URLValue(key, url) {
        key = key.replace(/[\[]/, '\\[');
        key = key.replace(/[\]]/, '\\]');
        var pattern = "[\\?&]" + key + "=([^&#]*)";
        var regex = new RegExp(pattern);
        var results = regex.exec(url);
        if (results === null) {
            return null;
        } else {
            return results[1];
        }
    }

    function LoadLookup(url, key) {
        app.core.Get(url)
            .done(function (data, textStatus, jqXHR) {
                var ctrol = $('select#' + key);
                $.each(data, function () {
                    ctrol.append($('<option />').val(this['Code']).text(this['Description']));
                });
                ctrol.select2({ width: '100%', theme: 'bootstrap4' });
            }).always(function () {
            });
    }

    function GetFromBetween(body, sub1, sub2) {
        if (body.indexOf(sub1) < 0 || body.indexOf(sub2) < 0) return false;
        var SP = body.indexOf(sub1) + sub1.length;
        var string1 = body.substr(0, SP);
        var string2 = body.substr(SP);
        var TP = string1.length + string2.indexOf(sub2);
        return body.substring(SP, TP);
    }

    function ReplaceAll(string, search, replace) {
        return string.split(search).join(replace);
    }

    function api_sendHttpRequest(method, url, data) {
        return fetch(url, {
            body: method === 'GET' ? null : JSON.stringify(data),
            method: method,
            headers: {
                'Content-Type': data ? 'application/json; charset=utf-8' : {},
                'Authorization': 'Bearer ' + getAuthToken()
            }
        }).then(response => {
            if (!response.ok) {
                api_ShowError();
                return;
            } else {
                return response.json();
            }
        });
    };

    function api_ShowError() {
        toastr.error("Por favor intente nuevamente y en caso de persistir el problema contacte el personal de soporte", "Ha ocurrido un error no controlado", { timeOut: 10000, closeButton: true, progressBar: true });
    };

    function report(reportName, data) {
        let reportParameters = {
            Source: JSON.stringify(data),
            ReportName: reportName
        };

        return fetch(`${app.setting.reportapi}/report/build`, {
            body: JSON.stringify(reportParameters),
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'Authorization': 'Bearer ' + getAuthToken()
            },
            responseType: 'arraybuffer'
        })
            .then(response => {
                if (!response.ok) {
                    api_ShowError();
                    return;
                } else {
                    return response.json();
                }
            })
            .catch(error => {
                console.error('Error en la solicitud:', error);
            });
    };

    function Initialize() {
        if (app.login == undefined) {
            let toastShown = false;
            let sessionExpired = false;
            let sessionExtended = false;
            let wasInactive = false;

            Logger.log("=== Session Monitor Initialized ===");
            Logger.log("ExpiresIn: " + localStorage.getItem("ExpiresIn"));
            Logger.log("Session.WarningTime: " + localStorage.getItem("Session.WarningTime"));

            timerId = setInterval(() => {
                inactiveSeconds++;

                const expiresInMin = parseInt(localStorage.getItem("ExpiresIn"));
                const warningMin = parseInt(localStorage.getItem("Session.WarningTime"));

                if (isNaN(expiresInMin) || isNaN(warningMin)) {
                    Logger.log("ERROR: Invalid session configuration - ExpiresIn: " + expiresInMin + ", WarningTime: " + warningMin);
                    return;
                }

                const showWarningAt = (expiresInMin - warningMin) * 60;
                const remainingSeconds = (expiresInMin * 60) - inactiveSeconds;

                Logger.log("Inactive: " + inactiveSeconds + "s | ShowWarningAt: " + showWarningAt + "s | Remaining: " + remainingSeconds + "s");

                if (inactiveSeconds >= showWarningAt && !toastShown) {
                    Logger.log(">>> SHOWING WARNING TOAST <<<");

                    toastr.info(
                        "Su sesión se cerrará en " + (remainingSeconds / 60) +
                        " minutos, si desea mantenerla haga clic aquí",
                        'Sesión',
                        {
                            timeOut: 50000,
                            closeButton: true,
                            progressBar: true,
                            //onclick: function () {
                            //    //timeout_verify('?force=true');
                            //}
                        }
                    );

                    toastShown = true;
                    sessionExtended = false;
                    wasInactive = true;
                }

                if (remainingSeconds <= 0 && !sessionExpired) {
                    Logger.log(">>> SESSION EXPIRED <<<");
                    localStorage.setItem('reason', 'session-expired');
                    sessionExpired = true;
                    timeout_verify('');
                }

            }, 1000);

            function resetInactivity() {
                Logger.log("User active");

                if (toastShown && !sessionExtended && wasInactive) {
                    //extendSessionAutomatically();
                    sessionExtended = true;
                    wasInactive = false;
                }

                inactiveSeconds = 0;
                toastShown = false;
            }

            // Nueva función para extender la sesión automáticamente
            function extendSessionAutomatically() {
                try {
                    // Leer el tiempo de extensión desde localStorage (en minutos)
                    const EXTENSION_MINUTES = parseInt(localStorage.getItem("Session.InactiveTime")) || 5;
                    const currentExpiresIn = parseInt(localStorage.getItem("ExpiresIn")) || 30;
                    const newExpiresIn = currentExpiresIn + EXTENSION_MINUTES;

                    // Actualizar ExpiresIn en localStorage
                    localStorage.setItem("ExpiresIn", newExpiresIn.toString());

                    // Actualizar también la fecha de expiración si existe
                    const currentExpires = localStorage.getItem("Expires");
                    if (currentExpires) {
                        const expiresDate = new Date(currentExpires);
                        expiresDate.setMinutes(expiresDate.getMinutes() + EXTENSION_MINUTES);
                        localStorage.setItem("Expires", expiresDate.toString());
                    }

                    Logger.log("Sesión extendida automáticamente por " + EXTENSION_MINUTES + " minutos");

                    // Opcional: Mostrar notificación sutil al usuario
                    if (typeof toastr !== 'undefined') {
                        toastr.success(
                            "Su sesión ha sido extendida " + EXTENSION_MINUTES + " minutos más",
                            'Sesión Extendida',
                            { timeOut: 3000, closeButton: false, progressBar: true }
                        );
                    }
                } catch (error) {
                    console.error("Error al extender sesión automáticamente:", error);
                }
            }

            // Activity events
            $(document).on("mousemove keydown click scroll touchstart", resetInactivity);
        }
    }

    function timeout_verify(option) {
        clearInterval(timerId);
        app.core.Get(app.setting.apipath + 'v1/Security/IsLive' + option)
            .done(function (data, textStatus, jqXHR) {
                if (data <= 30) {
                    localStorage.setItem('reason', 'session-expired');
                    window.location.replace(app.setting.basepath + 'Security/Login');
                } else if (data <= 90) {
                    data = 60;
                    var iinterval = parseInt(data) * 1000;
                    toastr.info("Su sesión se cerrará en " + data + " segundos, si desea mantenerla haga clic aquí", 'Sesión', { timeOut: iinterval, closeButton: true, progressBar: true, onclick: function () { timeout_verify('?force=true'); } });
                    token_timeout(iinterval);
                }
                else {
                    var dt = new Date();
                    var iinterval = (data + 10) * 1000;
                    dt = new Date(dt.getTime() + iinterval);
                    localStorage.setItem('Expires', dt);
                    token_timeout(10000);
                }
            });
    }


    return {
        Initialize: function () {
            return Initialize();
        },
        ReplaceAll(string, search, replace) {
            return ReplaceAll(string, search, replace);
        },
        GetFromBetween(body, sub1, sub2) {
            return GetFromBetween(body, sub1, sub2);
        },
        LoadLookup: function (url, key) {
            return LoadLookup(url, key);
        },
        Lookups: function (keys, callback, url, path = 'v1/Common/Lkps', alterToken = undefined) {
            if (keys.length > 0)
                return Lookups(keys, callback, url, path, alterToken);
        },
        LookupDependency: function (parentId, childId, lookupKey, emptyValue, newValue, triggerChange, callback, url, path = 'v1/Common/LkpChild') {
            return LookupDependency(parentId, childId, lookupKey, emptyValue, newValue, triggerChange, callback, url, path);
        },
        URLNumericValue: function (key) {
            return URLNumericValue(key);
        },
        URLStringValue: function (key) {
            return URLStringValue(key);
        },
        URLValue: function (key, url) {
            return URLValue(key, url);
        },
        Get: function (url, data, success, token, alterToken) {
            return ajaxCall('GET', url, data, success, (typeof token === "undefined") ? true : token, undefined, alterToken);
        },
        Send: function (mode, url, data, success) {
            return ajaxCall(mode, url, data, success, true);
        },
        Post: function (url, data, success, contentType, token, alterToken) {
            return ajaxCall('POST', url, data, success, (typeof token === "undefined") ? true : token, contentType, alterToken);
        },
        Put: function (url, data, success) {
            return ajaxCall('PUT', url, data, success, true);
        },
        Delete: function (url, data, success, alterToken) {
            return ajaxCall('DELETE', url, data, success, true, undefined, alterToken);
        },
        GetExt: function (url, data, success) {
            return ajaxCall('GET', url, data, success, false);
        },
        GetView: function (url, data, success) {
            return ajaxCall('GET', url, data, success, true, 'text/html; charset=utf-8');
        },
        GetPDF: function (url, download, filename, callback, alterToken = '') {
            return GetPDF(url, download, filename, callback, alterToken);
        },
        FileUpLoad: function (options) {
            return FileUpLoad(options);
        },
        FileUpLoadValidate: function (name, size, type, currentMessage) {
            return FileUpLoadValidate(name, size, type, currentMessage);
        },
        ValidatorRemoteIsValid: function (validator, element, name) {
            var errors = {};
            errors[element.name] = validator.defaultMessage(element, name);
            validator.invalid[element.name] = true;
            validator.showErrors(errors);
            validator.stopRequest(element, false);
        },
        ValidatorRemoteIsNotValid: function (validator, element) {
            var submitted = validator.formSubmitted;
            validator.resetInternals();
            validator.toHide = validator.errorsFor(element);
            validator.formSubmitted = submitted;
            validator.successList.push(element);
            validator.invalid[element.name] = false;
            validator.showErrors();
            validator.stopRequest(element, true);
        },
        b64StrtoBlob: function (b64Data, contentType, sliceSize) {
            contentType = contentType || '';
            sliceSize = sliceSize || 512;
            var byteCharacters = atob(b64Data);
            var byteArrays = [];
            for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
                var slice = byteCharacters.slice(offset, offset + sliceSize);
                var byteNumbers = new Array(slice.length);
                for (var i = 0; i < slice.length; i++) {
                    byteNumbers[i] = slice.charCodeAt(i);
                }
                var byteArray = new Uint8Array(byteNumbers);
                byteArrays.push(byteArray);
            }
            var blob = new Blob(byteArrays, { type: contentType });
            return blob;
        },
        DataToURL: function (data) {
            let url = '';
            if (data != null) {
                for (var p in data) {
                    if (data.hasOwnProperty(p)) {
                        url += ':' + p + '=' + data[p];
                    }
                }
                if (url != '') {
                    url = url.replace(/T00:00:00/g, '');
                    url = url.substring(1);
                }
            }
            return url;
        },
        GetXLSX: function (id, filename, validate, lurl) {
            let url = '';
            let valid = true;
            if (typeof lurl != "undefined" && lurl != '') {
                url = lurl;
            }
            if (url == '' && typeof app.Prototype != "undefined") {
                if (typeof validate != "undefined" && validate) {
                    valid = app.Prototype.IsValid();
                }
                url = app.core.DataToURL(app.Prototype.Data());
            }
            if (valid) {
                $('.ibox-content').toggleClass('sk-loading');
                let a = document.createElement("a");
                a.href = app.setting.apipath + 'v1/DataSource/excel?id=' + id + '&url=' + url;
                console.log(a.href);
                a.download = filename;
                a.click();
                a.remove()
                $('.ibox-content').toggleClass('sk-loading');
            }
        },
        ExternalCall: function (prefix, jsFile, code) {
            code = code.replace(/@_/g, '\'');
            if (typeof prefix == "undefined") {
                $.ajax({
                    url: app.setting.basepath + 'Scripts/' + jsFile, dataType: 'script', async: true
                }).done(function () {
                    let data = JSON.parse(localStorage.getItem('current'));
                    code = code.supplant(data);
                    console.log(code);
                    eval(code);
                });
            } else {
                let data = JSON.parse(localStorage.getItem('current'));
                code = code.supplant(data);
                console.log(code);
                eval(code);
            }
        },
        Data: function () {
            return { lookups: lookupData };
        },
        LoadScriptFile: function (url, async = true, type = "text/javascript") {
            if (!url.startsWith('http')) {
                url = app.setting.basepath + 'scripts/' + url;
            }
            return new Promise((resolve, reject) => {
                try {
                    const scriptEle = document.createElement("script");
                    scriptEle.type = type;
                    scriptEle.async = async;
                    scriptEle.src = url;

                    scriptEle.addEventListener("load", (ev) => {
                        resolve({ status: true });
                    });

                    scriptEle.addEventListener("error", (ev) => {
                        reject({
                            status: false,
                            message: `Failed to load the script ${url}`
                        });
                    });

                    document.body.appendChild(scriptEle);
                } catch (error) {
                    reject(error);
                }
            });
        },
        api_report: function (reportName, data) {
            return new Promise((resolve, reject) => {
                report(reportName, data)
                    .then(data => {
                        if (data === undefined || data.data == null) {
                            if (data != undefined) {
                                console.error(data);
                            }
                            toastr.error("Por favor intente nuevamente y en caso de persistir el problema contacte el personal de soporte", "Ha ocurrido un error al tratar de generar el reporte", { timeOut: 10000, closeButton: true, progressBar: true });
                            resolve(null);
                        } else {
                            let file = new Blob([data.data], { type: 'application/octet-binary' });
                            let blob = app.core.b64StrtoBlob(data.data, 'application/pdf');
                            let blobUrl = URL.createObjectURL(blob);
                            window.open(blobUrl);
                            resolve(data);
                        }
                    });
            })
        },
        datapi: function (method, url, data) {
            return new Promise((resolve, reject) => {
                let language = getLanguage();
                let headers = {
                    'Content-Type': 'application/json; charset=utf-8',
                    'Authorization': 'Bearer ' + getAuthToken()
                };
                if (language)
                    headers['Accept-Language'] = language;
                return fetch(`${app.setting.entityapi}/${url}`, {
                    body: method === 'GET' ? null : JSON.stringify(data),
                    method: method,
                    headers: headers
                }).then(response => {
                    if (!response.ok) {
                        api_ShowError();
                        resolve(null);
                    } else {
                        return response.json();
                    }
                }).then(data => {
                    if (data != undefined) {
                        if (data?._Fault === undefined || !data?._Fault) {
                            resolve(data);
                        } else {
                            api_ShowError();
                            resolve(null);
                        }
                    }
                }).catch(error => {
                    api_ShowError();
                    resolve(null);
                });
            })
        }
    };
})();

app.security = (function () {
    /**
     * Obtiene el valor de una cookie por su nombre.
     * @param {string} name - Nombre de la cookie a buscar.
     * @returns {string|null} El valor de la cookie o null si no existe.
     */
    function getCookie(name) {
        const nameEQ = name + "=";
        const cookies = document.cookie.split(';');
        for (let i = 0; i < cookies.length; i++) {
            let cookie = cookies[i];
            while (cookie.charAt(0) === ' ') {
                cookie = cookie.substring(1, cookie.length);
            }
            if (cookie.indexOf(nameEQ) === 0) {
                return cookie.substring(nameEQ.length, cookie.length);
            }
        }
        return null;
    }

    return {
        getCookie: function (name) {
            return localStorage.getItem("Token");
            return getCookie(name);
        },
        logout: function () {
            app.core.Post(app.setting.basepath + 'Security/Logout', undefined, undefined, false)
                .done(function (data) {
                    if (data.success) {
                        // Limpiar localStorage
                        localStorage.removeItem('Token');
                        localStorage.removeItem('Username');
                        localStorage.removeItem('Color1Tenant');
                        localStorage.removeItem('Color2Tenant');
                        localStorage.removeItem('Roles');
                        localStorage.removeItem('Expires');
                        localStorage.removeItem('LastActivity');
                        localStorage.removeItem('Navegation');

                        // Redirigir al login
                        window.location.replace(app.setting.basepath + 'Security/Login');
                    } else {
                        toastr.error('Error al cerrar sesión', 'Error');
                    }
                })
                .fail(function () {
                    // Si falla la llamada al servidor, limpiar manualmente como fallback
                    localStorage.clear();
                    document.cookie = "AuthToken=; path=/; max-age=0";
                    window.location.replace(app.setting.basepath + 'Security/Login');
                });
        }
    }
});

window.Logger = {
    canLog() {
        const flag = sessionStorage.getItem("logger.enabled");
        return flag === 'true';
    },

    log(message) {
        if (this.canLog()) {
            console.log(message);
        }
    },

    enable() {
        sessionStorage.setItem("logger.enabled", "false");
    },

    disable() {
        sessionStorage.setItem("logger.enabled", "true");
    }
};

$(document).ready(function () {
    app.core.Initialize();
    moment.locale('es');
});
