var app = app || {};

app.GeneralTemplate = (function () {

    function Refresh() {
        var filter = $('#TemplateSearch').val();

        $('#TemplateGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/Template?filter=' + filter)
            .done(function (data, textStatus, jqXHR) {
                $('#TemplateGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#TemplateGridTbl').bootstrapTable('hideLoading');
            });
    }

    function Init_Controls() {


        $(".formbtn").appendTo("#GenericToolBar");
    };

    function Init_List() {
        $('#TemplateGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'Key',
                    title: 'Clave',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center',
                    events: 'TemplateGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos del plantilla">' + value + '</a>';
                    }
                }, {
                    field: 'EmailTo',
                    title: 'Receptor',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'Subject',
                    title: 'Asunto',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'Body',
                    title: 'Body',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MasterTemplateIdDesc',
                    title: 'Master Template Id',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'UpdateDate',
                    title: 'Realizado por',
                    class: 'd-none d-sm-table-cell',
                    sortable: true,
                    halign: 'center',
                    width: 15,
                    widthUnit: '%',
                    formatter: 'app.ui.UpdateDateAndUserFormatter'
                }, {
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un plantilla',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'TemplateGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del plantilla de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del plantilla de la fila"> <i class="fa fa-close"></i> </button>';
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
    };

    function Event_Controls() {

        $('.tool-audit').on('click', function (e) {
            app.ui.components.ShowModalChangeSet(1205);
        });

        $('.tool-new').on('click', function (e) {
            app.GeneralTemplate.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#TemplateSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#TemplateEdtFormSave').click(function () {
            if (app.ui.IsValid('#TemplateEdtForm', false)) {
                app.ui.ButtonDoing('#TemplateEdtFormSave');
                var data = MapInputToObject();
                if (data.Id === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#TemplateEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#TemplateEdtForm', false)) {
                app.ui.ButtonDoing('#TemplateEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#TemplateEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#TemplateEdtForm', false)) {
                app.ui.ButtonDoing('#TemplateEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#TemplateEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#TemplateEdtForm', false)) {
                app.ui.ButtonDoing('#TemplateEdtFormDuplicate');
                var data = MapInputToObject();
                data.Id = 0;
                data.Description += ' duplicado';
                app.ui.ButtonDone('#TemplateEdtFormDuplicate');
                app.GeneralTemplate.EditRow(data);
            }
            event.preventDefault();
        });

        $('#TemplateEdtFormDelete').click(function () {
            if (app.ui.IsValid('#TemplateEdtForm', false)) {
                app.ui.ButtonDoing('#TemplateEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#TemplateEdtFormDelete');
                app.GeneralTemplate.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#TemplateEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

    };

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/Template', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El plantilla '" + uidata.Description + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralTemplate.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralTemplate.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#TemplateEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#TemplateEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#TemplateEdtFormSaveCopy');
                        break;
                }
            });
    };

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/Template/' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El plantilla '" + uidata.Description + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#TemplateEdtFormSave');
            });
    };

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el plantilla '" + uidata.Description + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/Template/' + uidata.Id)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El plantilla '" + uidata.Description + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    };

    function Init_Lookups() {
        app.core.Lookups(['MailTemplate.MasterTemplateId'], Dynamic_Event_Controls);
        // Dependencies
    };

    function Dynamic_Event_Controls() {

    };

    function MapInputToObject() {
        var data = {
            Id: parseInt(0 + $('#Id').val(), 10),
            Key: $('#Key').val(),
            Description: $('#Description').val(),
            EmailTo: $('#EmailTo').val(),
            Subject: $('#Subject').val(),
            Body: $('#Body').val(),
            MasterTemplateId: $('#MasterTemplateId').val()

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        $('#Key').val(data.Key);
        $('#Description').val(data.Description);
        $('#EmailTo').val(data.EmailTo);
        $('#Subject').val(data.Subject);
        $('#Body').val(data.Body);
        $('#MasterTemplateId').val(data.MasterTemplateId);

    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#TemplateEdtForm").validate({
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
                Subject: {
                    required: true
                },
                Body: {
                    required: true
                }
            },
            messages: {
                Subject: {
                    required: 'Debe indicar el asunto'
                },
                Body: {
                    required: 'Debe indicar el texto del correo'
                }
            }

        });
    };

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#TemplateGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#TemplateEdt').removeClass('d-none');
        MapObjectToInput(row);
        $('#Description').focus();
        if (row.Id === 0) {
            $('#TemplateEdtFormSaveContinue').removeClass('d-none');
            $('#TemplateEdtFormSaveCopy').removeClass('d-none');
            $('#TemplateEdtFormDuplicate').addClass('d-none');
            $('#TemplateEdtFormDelete').addClass('d-none');
            $('#TemplateEdtFormSave').removeClass('d-none');
            $('#TemplateEdtFormCancel').removeClass('d-none');
        } else {
            $('#TemplateEdtFormSaveContinue').addClass('d-none');
            $('#TemplateEdtFormSaveCopy').addClass('d-none');
            $('#TemplateEdtFormDuplicate').removeClass('d-none');
            $('#TemplateEdtFormDelete').removeClass('d-none');
            $('#TemplateEdtFormSave').removeClass('d-none');
            $('#TemplateEdtFormCancel').removeClass('d-none');
        }
    };

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#TemplateGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#TemplateEdt').addClass('d-none');
        $('.formbtn').addClass('d-none');
    };

    return {
        Init: function () {
            Init_List();
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Refresh();
            Setup_Validations();
        },
        New: function (row) {
            let newRow = { Id: 0, Key: null, Description: null, EmailTo: null, Subject: null, Body: null, MasterTemplateId: null }
            if (row !== undefined) {
                row.Id = 0;
                newRow = row;
            }
            EditMode(newRow);
        },
        EditRow: function (row) {
            EditMode(row);
        },
        DeleteRow: function (row) {
            Delete(row);
        }
    };
})();

window.TemplateGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralTemplate.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralTemplate.EditRow(row);
        e.stopPropagation();
    }
};
