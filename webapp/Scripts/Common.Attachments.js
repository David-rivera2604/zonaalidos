var app = app || {};

app.Attachments = (function () {
    let _data = null;

    function Attachment_List_Setup() {
        $('#AttachmentGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index clearTable',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'DocumentTypeDesc',
                    title: 'Tipo',
                    titleTooltip: 'Tipo de documento',
                    halign: 'left'
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    halign: 'left'
                }, {
                    field: 'FileName',
                    title: 'Archivo',
                    halign: 'left',
                    formatter: function (value, row, index, field) {
                        if (row.Id == null || !_data.PostByEachRow)
                            return `${value}`;
                        else
                            return `<a href=# onclick="app.ui.Download('${row.FileName}', ${row.Id}); return false;" title="Descargar adjunto"><i class="fa fa-paperclip"></i> ${value}</a>`;
                    }
                }, {
                    field: 'FileSize',
                    title: 'Tamaño',
                    titleTooltip: 'Tamaño del archivo',
                    halign: 'left',
                    align: 'left',
                    formatter: function (value, row, index, field) {
                        if (value === null || value === 0)
                            return '';
                        else
                            return parseInt(value / 1024) + 'kb';
                    }
                }, {
                    field: 'UpdateDate',
                    title: 'Realizado por',
                    class: 'd-none d-sm-table-cell',
                    halign: 'center',
                    width: 15,
                    widthUnit: '%',
                    formatter: 'app.ui.UpdateDateAndUserFormatter'
                }, {
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un attachments',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'Attachments_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" name="edit" class="btn btn-sm btn-white event" title="Al hacer click permite la edición de los datos del attachments de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" name="delete" class="btn btn-sm btn-white event" title="Al hacer click permite eliminar los datos del attachments de la fila"> <i class="fa fa-close"></i> </button>';
                    },
                    cellStyle: function (value, row, index) {
                        return {
                            css: {
                                'white-space': 'nowrap',
                                'vertical-align': 'top'
                            }
                        }
                    }
                }]
        });

        $('#AttachmentNew').click(function () {
            Attachment_table_row_edit(null);
        });

        $('#AttachmentEdtFormSave').click(function () {
            if (app.ui.IsValid('#AttachmentEdtForm', false)) {
                app.ui.ButtonDoing('#AttachmentEdtFormSave');

                var row = Attachment_table_row('values');
                if (_data.PostByEachRow) {
                    app.core.Post(app.setting.apipath + 'v1/Common/Attachments',
                        JSON.stringify({
                            Id: row.Id,
                            EntityType: _data.EntityType,
                            EntityId: _data.Id,
                            DocumentType: row.DocumentType,
                            Description: row.Description,
                            FileName: row.FileName,
                            FileSize: row.FileSize,
                            FileContent: row.Stored
                        }), undefined, undefined, true, _data.AlternateToken)
                        .done(function (data) {
                            AttachmentDraw();
                        }).always(function () {
                            app.ui.ButtonDone('#AttachmentEdtFormSave')
                            $('#AttachmentModal').modal('hide');
                        });
                } else {
                    if (row.Id === null) {
                        row.Id = 100 + Math.max.apply(Math, $('#AttachmentGridTbl').bootstrapTable('getData').map(function (o) { return o.Id == 10 ? o.Id : null; }));
                    }
                    if ($('#AttachmentModal').data('Id') != null) {
                        $('#AttachmentGridTbl').bootstrapTable('updateByUniqueId', { Id: row.Id, row: row });
                    }
                    else {
                        $('#AttachmentGridTbl').bootstrapTable('append', row);
                    }
                    app.ui.ButtonDone('#AttachmentEdtFormSave')
                    $('#AttachmentModal').modal('hide');
                    $('#AttachmentGridTbl').bootstrapTable('hideLoading');
                }
            }
        });

        $('#MultiAttachments').click(function (e) {
            e.preventDefault();
            $('#MultiFileUploadModal').click();
        });

        $('#MultiFileUploadModal').on('change', function (e) {
            let documentType = 1;
            let description = 'General';
            if (_data.PostByEachRow) {
                documentType = 1;
                description = '#filename#';
            }
            UpLoadMultiFile('#AttachmentEdtForm', '#MultiFileUploadModal', _data.EntityType, _data.Id, documentType, description,
                function (fileList, error) {
                    console.log(fileList, error);
                    if (!error) {
                        $('#AttachmentGridTbl').bootstrapTable('showLoading');
                        if (_data.PostByEachRow) {
                            AttachmentDraw();
                        } else {
                            let currentRows = $('#AttachmentGridTbl').bootstrapTable('getData');
                            let nextId = -100;
                            if (currentRows?.length > 0)
                                nextId = -100 - Math.max.apply(Math, currentRows.map(function (o) { return o.Id == 10 ? o.Id : null; }));

                            $.each(fileList, function (key, value) {
                                row = {
                                    Id: null,
                                    DocumentType: 1,
                                    DocumentTypeDesc: 'General',
                                    FileName: value.FileName,
                                    Stored: value.StoredFileName,
                                    FileContent: value.StoredFileName,
                                    FileSize: value.Size,
                                    Description: app.ui.StringCapitalizeFormatter(value.FileName.substring(0, value.FileName.indexOf('.')))
                                };
                                if (row.Id === null) {
                                    row.Id = nextId;
                                    nextId -= 10
                                }
                                if ($('#AttachmentModal').data('Id') != null) {
                                    $('#AttachmentGridTbl').bootstrapTable('updateByUniqueId', { Id: row.Id, row: row });
                                }
                                else {
                                    $('#AttachmentGridTbl').bootstrapTable('append', row);
                                }
                            });
                        }
                        $('#AttachmentGridTbl').bootstrapTable('hideLoading');
                    }
                });
        });

        $('#fileUploadModal').on('change', function (e) {
            UpLoadFile('#AttachmentEdtForm', '#fileUploadModal',
                function (fileList, error) {
                    if (error) {
                        document.getElementById('fileUploadModal').value = null;
                        $('#AttachmentFileName').val(fileList[0].name);
                        $('#AttachmentFileName').select().focus();
                        $('#AttachmentEdtForm').validate().valid();
                        $('#AttachmentDescription').select().focus();
                    }
                    else {
                        $('#AttachmentFileName').val(fileList[0].FileName);
                        $('#AttachmentStored').val(fileList[0].StoredFileName);
                        $('#AttachmentFileSize').val(fileList[0].Size);
                        $('#AttachmentDescription').val(app.ui.StringCapitalizeFormatter(fileList[0].FileName.substring(0, fileList[0].FileName.indexOf('.'))));
                        $('#AttachmentDescription').select().focus();
                    }
                });
        });
    }

    function Setup_Attachment_Validations() {
        $("#AttachmentEdtForm").validate({
            errorPlacement: function (error, element) {
                var name = $(element).attr("name");
                var $obj = $("#" + name + "_validate");
                if ($obj.length) {
                    error.appendTo($obj);
                }
                else {
                    error.insertAfter(element);
                }
            },
            rules: {
                AttachmentDescription: {
                    required: true
                },
                AttachmentDocumentType: {
                    required: true
                },
                AttachmentFileName: {
                    required: true,
                    extension: "docx|xlsx|pdf|png|jpg"
                },
                fileUploadModal: {
                    extension: "docx|xlsx|pdf|png|jpg"
                }
            },
            messages: {
                AttachmentDescription: {
                    required: 'Debe indicar una descripción del archivo'
                },
                AttachmentDocumentType: {
                    required: 'Debe indicar el tipo de documento'
                },
                AttachmentFileName: {
                    required: 'Debe indicar un archivo',
                    extension: 'Debe indicar un archivo con un tipo valido (docx, xlsx, pdf, png, jpg)'
                },
                fileUploadModal: {
                    extension: 'Debe indicar un archivo con un tipo valido(docx, xlsx, pdf, png, jpg)'
                }
            }
        });
    };

    function AttachmentDraw() {
        $('#AttachmentGridTbl').bootstrapTable('showLoading');
        if (_data.Id != 0) {
            app.core.Get(app.setting.apipath + `v1/Common/Attachments?entityType=${_data.EntityType}&entityId=${_data.Id}`, undefined, undefined, true, _data.AlternateToken)
                .done(function (data) {
                    $('#AttachmentGridTbl').bootstrapTable('load', data !== null ? data : []);
                }).always(function () {
                    $('#AttachmentGridTbl').bootstrapTable('hideLoading');
                });
        } else {
            $('#AttachmentGridTbl').bootstrapTable('load', []);
            $('#AttachmentGridTbl').bootstrapTable('hideLoading');
        }
    }

    function Attachment_table_row(mode) {
        if (mode == null) {
            return {
                Id: null,
                DocumentType: 1,
                DocumentTypeDesc: 'General',
                FileName: null,
                Stored: null,
                FileSize: null,
                Description: null,
                FileContent: null
            };
        }
        else {
            return {
                Id: $('#AttachmentModal').data('Id'),
                DocumentType: $('#AttachmentDocumentType').val(),
                DocumentTypeDesc: $('#AttachmentDocumentType option:selected').text(),
                FileName: $('#AttachmentFileName').val(),
                Stored: $('#AttachmentStored').val(),
                FileSize: $('#AttachmentFileSize').val(),
                Description: $('#AttachmentDescription').val(),
                FileContent: $('#AttachmentStored').val()
            };
        }
    }

    function Attachment_table_row_edit(row) {
        var md = $('#AttachmentModal').modal({ show: false });
        var formInstance = $("#AttachmentEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || Attachment_table_row();
        md.data('Id', row.Id);

        $('#AttachmentDocumentType').val(row.DocumentType);
        $('#AttachmentFileName').val(row.FileName);
        $('#AttachmentStored').val(row.Stored);
        $('#AttachmentFileSize').val(row.FileSize);
        $('#AttachmentDescription').val(row.Description);

        md.modal('show');
    }

    function UpLoadMultiFile(formId, uploadCtrolId, entityType, entityId, documentType, description, callback) {
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
                message = ValidateFile(arr[index].name, arr[index].size, arr[index].type, message);
            }
            if (message != '') {
                app.ui.Error(message);
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
                    xhrFields: {
                        withCredentials: true
                    },
                    beforeSend: function (xhr) {
                        if (_data.AlternateToken != null && _data.AlternateToken != '' && _data.AlternateToken != 'null') {
                            xhr.setRequestHeader('Authorization', 'Bearer ' + _data.AlternateToken);
                        }
                        else {
                            xhr.setRequestHeader('Authorization', 'Bearer ' + app.security().getCookie('Token'));
                        }
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

    function ValidateFile(name, size, type, message) {
        console.log(type);
        if ((type == 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' || type == 'application/pdf') && size < 13312) {
            if (message != '') {
                message = message + ', ';
            }
            message = message + 'El tamaño del archivo ' + name + ' es menor a 13kb';
        }
        if (type == 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' && size < 9216) {
            if (message != '') {
                message = message + ', ';
            }
            message = message + 'El tamaño del archivo ' + name + ' es menor a 9kb';
        }
        if (size >= 31457280) {
            if (message != '') {
                message = message & ', ';
            }
            message = message + 'El tamaño del archivo ' + name + 'es mayor a 30mb';
        }
        if (name.length > 255) {
            if (message != '') {
                message = message & ', ';
            }
            message = message + 'El nombre del archivo debe ser menor a 255 caracteres';
        }
        return message
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
                message = ValidateFile(arr[index].name, arr[index].size, arr[index].type, message);
            }
            if (message != '') {
                elementInstance.showErrors({ 'AttachmentFileName': message });
            }
            else {
                app.ui.ResetValidateElement('#AttachmentEdtForm', '#AttachmentFileName');
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
                    xhrFields: {
                        withCredentials: true
                    },
                    beforeSend: function (xhr) {
                        if (_data.AlternateToken != null && _data.AlternateToken != '' && _data.AlternateToken != 'null') {
                            xhr.setRequestHeader('Authorization', 'Bearer ' + _data.AlternateToken);
                        }
                        else {
                            xhr.setRequestHeader('Authorization', 'Bearer ' + app.security().getCookie('Token'));
                        }
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

    function fileUploadHandler(options = {}) {

        const {
            controlSelector,
            controlName,   // <- NUEVO
            done,
            fail,
            always
        } = options;

        if (typeof done !== "function") {
            console.error("Error: 'done' es obligatorio y debe ser una función.");
            return;
        }

        if (!controlSelector || $(controlSelector).length === 0) {
            if (typeof fail === "function") fail(null, { error: "Selector inválido" });
            if (typeof always === "function") always(null);
            return;
        }

        $(controlSelector).on("change", function (e) {

            if (!controlName || controlName.trim() === "") {
                if (typeof fail === "function") fail(e, { error: "'controlName' vacío" });
                if (typeof always === "function") always(e);
                return;
            }

            let files = this.files;

            // ====================================================
            // VALIDAR PESO
            // ====================================================
            let msg = "";
            for (let i = 0; i < files.length; i++) {
                if (files[i].size >= 31457280) {
                    if (msg !== "") msg += ", ";
                    msg += `El tamaño del archivo ${files[i].name} es mayor a 30mb`;
                }
            }

            if (msg !== "") {
                if (typeof fail === "function") fail(e, { error: msg });
                if (typeof always === "function") always(e);
                return;
            }

            // ====================================================
            // SUBIR ARCHIVO
            // ====================================================
            app.ui.ButtonDoing(controlSelector);

            let data = new FormData();
            for (let i = 0; i < files.length; i++) {
                data.append("files", files[i]);
            }

            uploadAjaxRequest(
                data,
                controlSelector,
                function (response) {
                    done(e, response);
                },
                function (err) {
                    if (typeof fail === "function") fail(e, err);
                },
                function () {
                    if (typeof always === "function") always(e);
                }
            );
        });
    }


    function uploadAjaxRequest(formData, selector, done, fail, always) {

        $.ajax({
            type: "POST",
            enctype: 'multipart/form-data',
            url: app.setting.apipath + 'v1/Common/Upload',
            data: formData,
            processData: false,
            contentType: false,
            cache: false,
            timeout: 600000,
            beforeSend: function (xhr) {
                if (_data?.AlternateToken != null && _data.AlternateToken != '' && _data.AlternateToken != 'null') {
                    xhr.setRequestHeader('Authorization', 'Bearer ' + _data.AlternateToken);
                }
                else {
                    xhr.setRequestHeader('Authorization', 'Bearer ' + app.security().getCookie('Token'));
                }
            }
        })
            .done(function (response) {
                if (typeof done === "function") done(response);
            })
            .fail(function (jqXHR) {
                if (typeof fail === "function") fail(jqXHR);
            })
            .always(function () {
                app.ui.ButtonDone(selector);
                if (typeof always === "function") always();
            });
    }

    return {
        //{ EntityType: 1304, Id: 0, PostByEachRow: false, showTitle: true, AlternateToken: '' }
        Init: function (data) {
            try {
                if (_data == null) {
                    Attachment_List_Setup();
                    Setup_Attachment_Validations();
                }
                if (data.PostByEachRow === undefined) {
                    data.showTitPostByEachRowle = false;
                }
                if (data.showTitle === undefined) {
                    data.showTitle = true;
                }
                if (data.AlternateToken === undefined) {
                    data.AlternateToken = '';
                }
                _data = data;
                AttachmentDraw();
                if (!data.showTitle) {
                    $('.AttachmentTitle').addClass('d-none');
                }
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Data: function () {
            return $('#AttachmentGridTbl').bootstrapTable('getData');
        },
        ButtonClick: function (tbl, e, name, row, index) {
            switch (name) {
                case 'edit':
                    Attachment_table_row_edit(row);
                    break;

                case 'delete':
                    toastr.warning("Si está seguro de querer eliminar el adjunto '" + row.FileName + "' haga clic aquí", null,
                        {
                            timeOut: 5000, closeButton: true, progressBar: true,
                            onclick: function () {
                                if (_data.PostByEachRow) {
                                    app.core.Delete(app.setting.apipath + `v1/Common/Attachments/${row.Id}`, undefined, undefined, _data.AlternateToken)
                                        .done(function (data, textStatus, jqXHR) {
                                            toastr.success("El adjunto '" + row.FileName + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                                            AttachmentDraw();
                                        });
                                } else {
                                    $('#AttachmentGridTbl').bootstrapTable('removeByUniqueId', row.Id);
                                }
                            }
                        });
                    break;
            }
        },
        FileUpload: function (options) {
            fileUploadHandler(options);
        }
    };
})();
window.Attachments_Events = {
    'click .event': function (e, value, row, index) {
        e.stopPropagation();
        app.Attachments.ButtonClick(this, e, e.currentTarget.name, row, index)
    }
};