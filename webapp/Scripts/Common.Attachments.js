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
                        }))
                        .done(function (data) {
                            AttachmentDraw(_data.Id);
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
<<<<<<< HEAD

=======
                    
>>>>>>> 2603d8692335166cf5801e413f5bc98d7a338de7
                    app.ui.ButtonDone('#AttachmentEdtFormSave')
                    $('#AttachmentModal').modal('hide');
                    $('#AttachmentGridTbl').bootstrapTable('hideLoading');
                }
            }
        });

        $('#fileUploadModal').on('change', function () {
            app.core.UpLoadFile('#AttachmentEdtForm', '#fileUploadModal',
                function (fileList) {
                    $('#AttachmentFileName').val(fileList[0].FileName);
                    $('#AttachmentStored').val(fileList[0].StoredFileName);
                    $('#AttachmentFileSize').val(fileList[0].Size);
                    $('#AttachmentDescription').val(app.ui.StringCapitalizeFormatter(fileList[0].FileName.substring(0, fileList[0].FileName.indexOf('.'))));
                    $('#AttachmentDescription').select().focus()
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
                    required: true
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
                    required: 'Debe indicar un archivo'
                }
            }
        });
    };

    function AttachmentDraw(entityId) {
        $('#AttachmentGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + `v1/Common/Attachments?entityType=1304&entityId=${entityId}`)
            .done(function (data) {
                $('#AttachmentGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#AttachmentGridTbl').bootstrapTable('hideLoading');
            });
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
                Description: null
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
                Description: $('#AttachmentDescription').val()
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

    return {
        //{ EntityType: 1304, Id: 0, PostByEachRow: false }
        Init: function (data) {
            try {
                _data = data;

                Attachment_List_Setup();
                Setup_Attachment_Validations();
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
                                app.core.Delete(app.setting.apipath + `v1/Common/Attachments/${row.Id}`)
                                    .done(function (data, textStatus, jqXHR) {
                                        toastr.success("El adjunto '" + row.FileName + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                                        AttachmentDraw(_data.Id);
                                    });
                            }
                        });
                    break;
            }
        }
    };

})();
window.Attachments_Events = {
    'click .event': function (e, value, row, index) {
        e.stopPropagation();
        app.Attachments.ButtonClick(this, e, e.currentTarget.name, row, index)
    }
};