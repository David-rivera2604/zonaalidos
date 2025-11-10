var app = {};

// CONSERVAR DEL ORIGINAL DESDE AQUI
app.setting = {
    apibase: 'http://localhost:8080',
    apipath: 'http://localhost:8080/aliados/api/',
    basepath: '/Aliados/',
    viewpath: 'http://localhost:8080/aliados/',
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

    let lookupData = [];

    function GetPDF(url, download, filename, callback) {
        let excel = false;
        //var req = new XMLHttpRequest();
        //req.open("GET", url, true);
        //req.responseType = "blob";
        //req.setRequestHeader('Content-Type', 'application/json; charset=utf-8');
        //req.setRequestHeader("Authorization", 'Bearer ' + localStorage.getItem('Token'));

        //req.onload = function (event) {
        //    var blob = req.response;
        //    if (filename === null) {
        //        filename = new Date() + ".pdf";
        //    }
        //    if (download) {
        //        var link = document.createElement('a');
        //        link.href = window.URL.createObjectURL(blob);
        //        link.target = "_blank";
        //        link.download = filename;
        //        link.click();
        //        link.remove()
        //    } else {
        //        window.open(window.URL.createObjectURL(blob));
        //    }
        //};
        //req.send();

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
        fetch(url, {
            body: null,
            method: 'GET',
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'Authorization': 'Bearer ' + localStorage.getItem('Token')
            },
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

    function UpLoadFileEx(formId, uploadCtrolId, entityType, entityId, documentType, description, callback) {
        if (app.ui.IsValid(formId, false, true)) {
            let index = 0;
            let arr = $(uploadCtrolId + 'UploadModal').prop('files');
            let message = '';
            let elementInstance = $(formId).validate();

            for (index = 0; index < arr.length; index++) {
                if (arr[index].size >= 31457280) {
                    if (message != '') {
                        message = message & ', ';
                    }
                    message = message & 'El tamaño del archivo ' + arr[index].name + 'es mayor a 30mb';
                }
            }
            if (message != '') {
                elementInstance.showErrors({ 'FileName': message });
            }
            else {
                app.ui.ButtonDoing(uploadCtrolId);
                var fileData = new FormData();
                fileData.append('EntityType', entityType);
                fileData.append('EntityId', entityId);
                fileData.append('DocumentType', documentType);
                fileData.append('Description', description);
                for (index = 0; index < arr.length; index++) {
                    fileData.append('files', arr[index]);
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
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('Token'));
                    }
                }).done(function (fileList) {
                    callback(fileList);
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    ajaxErrorHandler(jqXHR, errorThrown);
                }).always(function () {
                    app.ui.ButtonDone(uploadCtrolId)
                });
            }
        }
    }

    function UpLoadFile(formId, uploadCtrolId, callback) {
        let index = 0;
        let arr = $(uploadCtrolId).prop('files');
        let message = '';
        let elementInstance = $(formId).validate();
        let isValid = !elementInstance.valid();

        if (arr.length == 0) {
            return;
        }
        if ($(uploadCtrolId).valid()) {


            for (index = 0; index < arr.length; index++) {
                if (arr[index].size >= 31457280) {
                    if (message != '') {
                        message = message & ', ';
                    }
                    message = message & 'El tamaño del archivo ' + arr[index].name + 'es mayor a 30mb';
                }
            }
            if (message != '') {
                elementInstance.showErrors({ 'FileName': message });
            }
            else {
                app.ui.ButtonDoing(uploadCtrolId);
                var fileData = new FormData();
                for (index = 0; index < arr.length; index++) {
                    fileData.append('files', arr[index]);
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
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('Token'));
                    }
                }).done(function (fileList) {
                    callback(fileList, false);
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    ajaxErrorHandler(jqXHR, errorThrown);
                }).always(function () {
                    app.ui.ButtonDone(uploadCtrolId)
                });
            }
        } else {
            callback([arr[0]], true);
        }
    }

    function ajaxCall(type, url, data, success, token, contentType) {
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
            beforeSend: function (xhr) {
                if (token) {
                    let current = localStorage.getItem('AlternateToken');
                    if (current != null && current != '' && current != 'null') {
                        localStorage.removeItem('AlternateToken')
                        xhr.setRequestHeader('Authorization', 'Bearer ' + current);
                    }
                    else {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('Token'));
                    }
                }
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
            //  alert('always');
        });
        //app.core.ErrorHandler(jqXHR, textStatus, errorThrown);

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

                //console.log('%c Auth ', 'color: white; background-color: #2274A5', 'Login page rendered');
                //console.log('%c GraphQL ', 'color: white; background-color: #95B46A', 'Get user details');
                //console.log('%c Error ', 'color: white; background-color: #D33F49', 'Error getting user details');

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

    function Lookups(keys, callback, url, path) {
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
            }, true);
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
                url = url + (url.endsWith('=') ? parentValue : '' );
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
                'Authorization': 'Bearer ' + localStorage.getItem('Token')
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
                'Authorization': 'Bearer ' + localStorage.getItem('Token')
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
            .catch(error => { // Manejo de errores adicionales 
                console.error('Error en la solicitud:', error);
            });
    };

    return {
        ReplaceAll(string, search, replace) {
            return ReplaceAll(string, search, replace);
        },
        GetFromBetween(body, sub1, sub2) {
            return GetFromBetween(body, sub1, sub2);
        },
        LoadLookup: function (url, key) {
            return LoadLookup(url, key);
        },
        Lookups: function (keys, callback, url, path = 'v1/Common/Lkps') {
            if (keys.length > 0)
                return Lookups(keys, callback, url, path);
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
        Get: function (url, data, success) {
            return ajaxCall('GET', url, data, success, true);
        },
        Send: function (mode, url, data, success) {
            return ajaxCall(mode, url, data, success, true);
        },
        Post: function (url, data, success, contentType) {
            return ajaxCall('POST', url, data, success, true, contentType);
        },
        Put: function (url, data, success) {
            return ajaxCall('PUT', url, data, success, true);
        },
        Delete: function (url, data, success) {
            return ajaxCall('DELETE', url, data, success, true);
        },
        GetExt: function (url, data, success) {
            return ajaxCall('GET', url, data, success, false);
        },
        GetView: function (url, data, success) {
            return ajaxCall('GET', url, data, success, true, 'text/html; charset=utf-8');
        },
        GetPDF: function (url, download, filename, callback) {
            return GetPDF(url, download, filename, callback);
        },
        UpLoadFile: function (formId, uploadCtrolId, callback) {
            return UpLoadFile(formId, uploadCtrolId, callback);
        },
        UpLoadFileEx: function (formId, uploadCtrolId, entityType, entityId, documentType, description, callback) {
            return UpLoadFileEx(formId, uploadCtrolId, entityType, entityId, documentType, description, callback);
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
                return fetch(`${app.setting.entityapi}/${url}`, {
                    body: method === 'GET' ? null : JSON.stringify(data),

                    method: method,
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'Authorization': 'Bearer ' + localStorage.getItem('Token')
                    }
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
$(document).ready(function () {
    moment.locale('es');
});