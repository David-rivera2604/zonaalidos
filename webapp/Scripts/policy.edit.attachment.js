var app = app || {};
app.attachment = (function () {

    var id = 0;
    var attachmentRows = [];

    function Load(internalId) {
        id = internalId;
        app.core.Get(app.setting.apipath + 'v1/Common/Attachments?entityType=2000&entityId=' + internalId)
            .done(function (data, textStatus, jqXHR) {
                attachmentRows = data;
                TableRefresh(attachmentRows);
            });

        // window.location.href = 'http://localhost:8082/proto/api/v1/Common/Download2?id=2';
        //http://localhost:8082/proto/api/v1/Common/Download2?id=2
        //app.core.Get(app.setting.apipath + 'v1/Common/Download2?id=2')
        //    .done(function (data, textStatus, jqXHR) {
        //    });
    };

    //https://www.it-swarm.dev/es/javascript/javascript-blob-nombre-de-archivo-sin-enlace/1041407785/

    //$('#imageId').attr('src', "http://host:port/id1/id2/file");   
    //saveFile(data.FileName, data.Type, data.Content);
    function saveFile(name, type, data) {

        //if (window.navigator && window.navigator.msSaveOrOpenBlob) {
        //    window.navigator.msSaveOrOpenBlob(new Blob([data.Content], { type: 'application/' + data.Type }), data.FileName);

        if (data !== null && navigator.msSaveBlob)
            return navigator.msSaveBlob(new Blob([data], { type: type }), name);
        var a = $("<a style='display: none;'/>");
        var url = window.URL.createObjectURL(b64StrtoBlob(data, type));
        //var url = window.URL.createObjectURL(new Blob([data], { type: type }));
        a.attr("href", url);
        a.attr("download", name);
        $("body").append(a);
        a[0].click();
        window.URL.revokeObjectURL(url);
        a.remove();
    }

    function b64StrtoBlob(b64Data, contentType, sliceSize) {
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
    }

    function Init_Controls() {
    };

    async function Init_Lookups() {
        app.core.Lookups(['AttachmentType.AttachmentType'], Dynamic_Event_Controls);

        // Dependencies

    };

    function Event_Controls() {

        $('#NewAttachment').click(function () {
            $('#adjuntos').addClass('d-none');
            $('#AttachmentsEdt').removeClass('d-none');
            event.preventDefault();
        });

        $('#AddAttachment').click(function () {
            if (app.ui.IsValid('#AttachmentsEdtForm', false)) {
                attachmentRows.push(_inputToObject());
                TableRefresh(attachmentRows);
                $('#adjuntos').removeClass('d-none');
                $('#AttachmentsEdt').addClass('d-none');
                ClearAttachmentsEdtForm();
            }
            event.preventDefault();
        });

        $('#CancelAttachment').click(function () {
            $('#adjuntos').removeClass('d-none');
            $('#AttachmentsEdt').addClass('d-none');
            event.preventDefault();
        });

        $('#fileUpload').on('change', function () {
            var elementInstance = $("#AttachmentsEdtForm").validate();
            var file1 = $('#fileUpload').prop('files')[0];
            if (file1.size < 31457280) {
                var fileName = $(this).val().split('\\').pop();
                var data = new FormData();
                data.append('files', file1);

                $.ajax({
                    type: "POST",
                    enctype: 'multipart/form-data',
                    url: app.setting.apipath + 'v1/Common/Upload',
                    data: data,
                    processData: false,
                    contentType: false,
                    cache: false,
                    timeout: 600000,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('Token'));
                    },
                    success: function (data) {
                        console.log(data[0].StoredFileName);
                        $('#Stored').val(data[0].StoredFileName);
                        $('#FileSize').val(data[0].Size);
                        $('#FileName').val(fileName);

                        elementInstance.element('#FileName');
                    },
                    error: function (e) {
                        console.log("ERROR : ", e);
                    }
                });
            }
            else
                elementInstance.showErrors({ 'FileName': 'El tamaño máximo es 30mb' });
        });

    };

    function ClearAttachmentsEdtForm() {
        $('#AttachmentsId').val(null);
        $('#Description').val(null);
        $('#AttachmentType').val(1);
        //$('#DocumentTypeDesc').val(data.DocumentTypeDesc);
        $('#FileName').val(null);
        $('#FileSize').val(null);
        $('#Stored').val(null);
    }

    function Dynamic_Event_Controls() {
        $('#AttachmentType').val(1);
    };

    function Setup_Validations() {
        $("#AttachmentsEdtForm").validate({
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
                Description: {
                    required: true
                },
                AttachmentType: {
                    required: true
                },
                FileName: {
                    required: true
                }
            },
            messages: {
                Description: {
                    required: 'Debe indicar una descripción del archivo'
                },
                AttachmentType: {
                    required: 'Debe indicar el tipo de documento'
                },
                FileName: {
                    required: 'Debe indicar un archivo'
                }
            }
        });
    };

    function TableRefresh(data) {
        if (data !== null && data.length > 0) {
            $('#adjuntos').removeClass('d-none');
            $('#AttachmentsEdt').addClass('d-none');
        }

        $('#adjuntos tbody').html('');
        $.each(data, function (index, row) {
            //http://localhost:8082/proto/api/v1/Common/Download2?id=' + row.Id + '
            $('#adjuntos tbody').append('<tr><td>' + row.DocumentTypeDesc + '</td><td>' + row.Description + '</td><td><a href="#" target="_blank" data-id="' + row.Id + '" data-filename="' + row.FileName + '" ><i class="fa fa-paperclip"></i> ' + row.FileName + '</a></td><td>' + parseInt(row.FileSize / 1024) + 'kb</td><td>' + row.UpdateUserName + ' <small class="text-muted"> ' + moment(row.UpdateDate).format('hh:mma') + ' - ' + moment(row.UpdateDate).format('DD/MM/YYYY') + '</small></td></tr>');
        });
        $('#adjuntos').footable();

        $(document).on('click', '#adjuntos tbody a', function (event, selector, data) {
            event.preventDefault();

            var fileName = $(this).data("filename").toLowerCase();
            if (fileName.endsWith("jpg") || fileName.endsWith("pdf"))
                window.open(app.setting.apipath + 'v1/Common/Download2?id=' + $(this).data("id"), "Adjunto", "width=500, height=450, titlebar=no, location=NO");
            else
                window.location.href = app.setting.apipath + 'v1/Common/Download2?id=' + $(this).data("id");


        });

    };

    var _inputToObject = function () {
        var data = {
            Id: parseInt(0 + $('#AttachmentsId').val(), 10),
            Description: $('#Description').val(),
            DocumentType: $('#AttachmentType').val(),
            DocumentTypeDesc: $('#AttachmentType option:selected').text(),
            FileName: $('#FileName').val(),
            FileSize: parseInt(0 + $('#FileSize').val(), 10),
            Stored: $('#Stored').val(),
            UpdateUserName: ''
        };
        return data;
    };

    var _objectToInput = function (data) {
        if (data !== null) {
            $('#AttachmentsId').val(data.Id);
            $('#Description').val(data.Description);
            $('#AttachmentType').val(data.DocumentType);
            //$('#DocumentTypeDesc').val(data.DocumentTypeDesc);
            $('#FileName').val(data.FileName);
            $('#FileSize').val(data.FileSize);
            $('#Stored').val(data.Stored);
        }
    };

    return {
        Init: function () {
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Dynamic_Event_Controls();
            Setup_Validations();
            ClearAttachmentsEdtForm();
            var _id = app.core.URLNumericValue('id');
            if (_id !== 0)
                Load(_id);
        },
        InputToObject: function () {
            return attachmentRows;
        },
        ObjectToInput: _objectToInput,
        IsValid: function () {
            var instance = $('#AttachmentsEdtForm');
            var validate = instance.validate();
            validate.settings.ignore = '';
            var result = instance.valid();
            var count = validate.numberOfInvalids();
            validate.settings.ignore = ':hidden';
            if (count > 0)
                $('#adjuntosHTab .badge').html(count);
            else
                $('#adjuntosHTab .badge').html('');
            return result;
        }

    };
})();
$(document).ready(function () {
    app.attachment.Init();
});
