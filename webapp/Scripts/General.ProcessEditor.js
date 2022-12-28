var app = app || {};

app.GeneralProcessEditor = (function () {

    function ProcessTree(id) {
        app.core.Get(app.setting.apipath + 'v1/Process/Specification?flowId=' + id)

            .done(function (data, textStatus, jqXHR) {
                var html = [];
                html.push(`<li class="dd-item" data-id="F${data.Id}">`);
                html.push(`<div class="dd-handle">`);
                html.push(`<span class="float-right dd-nodrag"> ${data.ProcessSpecSteps.length} <a href="#" data-id="F${data.Id}" class="btn btn-xs btn-link">...</a></span>`);
                html.push(`<span class="label label-primary "><i class="fa fa-cogs"></i></span>`);
                html.push(`${data.Name}</div>`);
                html.push('<ol class="dd-list">');
                $.each(data.ProcessSpecSteps, function (index, element) {
                    html.push(`<li class="dd-item" data-id="S${element.Id}">`);
                    html.push(`<div class="dd-handle">`);
                    html.push(`<span class="float-right dd-nodrag"> ${element.ProcessSpecTasks.length} <a href="#" data-id="S${element.Id}" class="btn btn-xs btn-link">...</a></span>`);
                    html.push(`<span class="label label-info"><i class="fa fa-list "></i></span>`);
                    html.push(`${element.Name}</div>`);
                    html.push('<ol class="dd-list">');
                    if (element.ProcessSpecTasks.length > 0) {

                        $.each(element.ProcessSpecTasks, function (subindex, subelement) {
                            html.push(`<li class="dd-item" data-id="T${subelement.Id}">`);
                            html.push(`<div class="dd-handle">`);
                            html.push(`<span class="float-right dd-nodrag"><a href="#" data-id="T${subelement.Id}" class="btn btn-xs btn-link">...</a></span>`);
                            html.push(`<span class="label label-warning"><i class="fa fa-check"></i></span>`);
                            html.push(`${subelement.Name}</div>`);
                            html.push(`</li>`);
                        });

                    }
                    html.push('</ol>');
                    html.push(`</li>`);
                });
                html.push('</ol>');
                html.push(`</li>`);
                $('.dd-list').html(html.join(''));


                $('#nestable2').nestable({
                    group: 0
                }).on('change', function (e) {
                    var list = e.length ? e : $(e.target),
                        output = list.data('output');
                    console.log(e);
                    console.log(e.target);
                });
                $('.dd').nestable('collapseAll');
                $('#nestable-menu').on('click', function (e) {
                    var target = $(e.target),
                        action = target.data('action');
                    if (action === 'expand-all') {
                        $('.dd').nestable('expandAll');
                    }
                    if (action === 'collapse-all') {
                        $('.dd').nestable('collapseAll');
                    }
                });

                $('.btn-link').on('click', function (e) {
                    e.preventDefault();
                    var dataId = $(e.target).data('id');
                    if (dataId.substring(0, 1) === 'F') {
                        window.open("ProcessSpecFlow?id=" + dataId.substring(1), "flow", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes, top=100, height=450, left=400, width=900");
                    }
                    if (dataId.substring(0, 1) === 'S') {
                        window.open("ProcessSpecStep?id=" + dataId.substring(1), "flow", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes, top=100, height=450, left=400, width=900");
                    }
                    if (dataId.substring(0, 1) === 'T') {
                        window.open("ProcessSpecTask?id=" + dataId.substring(1), "flow", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes, top=100, height=450, left=400, width=900");
                    }
                });


            });
    };

    function Init_Controls() {

        $('#StatusFlt').select2({ width: '100%', theme: 'bootstrap4' });

    };

    function Event_Controls() {

        $('.tool-audit').on('click', function (e) {
            app.ui.components.ShowModalChangeSet(0000);
        });

        $('.tool-new').on('click', function (e) {
            app.GeneralProcessEditor.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#ProcessSpecFlowSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#ProcessSpecFlowEdtFormSave').click(function () {
            if (app.ui.IsValid('#ProcessSpecFlowEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecFlowEdtFormSave');
                var data = MapInputToObject();
                if (data.Id === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecFlowEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#ProcessSpecFlowEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecFlowEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#ProcessSpecFlowEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#ProcessSpecFlowEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecFlowEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#ProcessSpecFlowEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#ProcessSpecFlowEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecFlowEdtFormDuplicate');
                var data = MapInputToObject();
                data.Id = 0;
                data.Name += ' duplicado';
                app.ui.ButtonDone('#ProcessSpecFlowEdtFormDuplicate');
                app.GeneralProcessEditor.EditRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecFlowEdtFormDelete').click(function () {
            if (app.ui.IsValid('#ProcessSpecFlowEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecFlowEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#ProcessSpecFlowEdtFormDelete');
                app.GeneralProcessEditor.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecFlowEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

    };

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/ProcessSpecFlow', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El process spec flow '" + uidata.Name + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralProcessEditor.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralProcessEditor.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#ProcessSpecFlowEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#ProcessSpecFlowEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#ProcessSpecFlowEdtFormSaveCopy');
                        break;
                }
            });
    };

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/ProcessSpecFlow/' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El process spec flow '" + uidata.Name + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#ProcessSpecFlowEdtFormSave');
            });
    };

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el process spec flow '" + uidata.Name + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/ProcessSpecFlow/' + uidata.Id)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El process spec flow '" + uidata.Name + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    };

    function Init_Lookups() {
        app.core.Lookups(['MailServer.MailServer', 'EstadoRegistro.Status', 'EstadoRegistro.StatusFlt'], Dynamic_Event_Controls);
        // Dependencies
    };

    function Dynamic_Event_Controls() {
    };

    function MapInputToObject() {
        var data = {
            Id: parseInt(0 + $('#Id').val(), 10),
            Name: $('#Name').val(),
            Description: $('#Description').val(),
            Alias: $('#Alias').val(),
            MailServer: $('#MailServer').val(),
            Status: $('#Status').val()

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        $('#Name').val(data.Name);
        $('#Description').val(data.Description);
        $('#Alias').val(data.Alias);
        $('#MailServer').val(data.MailServer);
        $('#Status').val(data.Status);

    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#ProcessSpecFlowEdtForm").validate({
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
                Name: {
                    required: true
                },
                MailServer: {
                    required: true
                },
                Status: {
                    required: true
                }
            },
            messages: {
                Name: {
                    required: 'Debe indicar el nombre'
                },
                MailServer: {
                    required: 'Debe indicar el servidor de correo'
                },
                Status: {
                    required: 'Debe indicar el estado'
                }
            }

        });
    };

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#ProcessSpecFlowGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#ProcessSpecFlowEdt').removeClass('d-none');
        MapObjectToInput(row);
        $('#Name').focus();
        if (row.Id === 0) {
            $('#ProcessSpecFlowEdtFormSaveContinue').removeClass('d-none');
            $('#ProcessSpecFlowEdtFormSaveCopy').removeClass('d-none');
            $('#ProcessSpecFlowEdtFormDuplicate').addClass('d-none');
            $('#ProcessSpecFlowEdtFormDelete').addClass('d-none');
        } else {
            $('#ProcessSpecFlowEdtFormSaveContinue').addClass('d-none');
            $('#ProcessSpecFlowEdtFormSaveCopy').addClass('d-none');
            $('#ProcessSpecFlowEdtFormDuplicate').removeClass('d-none');
            $('#ProcessSpecFlowEdtFormDelete').removeClass('d-none');
        }
    };

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#ProcessSpecFlowGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#ProcessSpecFlowEdt').addClass('d-none');
    };

    return {
        Init: function () {
            $("body").toggleClass("mini-navbar");
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Setup_Validations();
            let _id = app.core.URLNumericValue('id');
            if (_id !== 0) {
                ProcessTree(_id);
            }


        },
        New: function (row) {
            let newRow = { Id: 0, Name: null, Description: null, Alias: null, MailServer: 1, Status: 1 }
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

window.ProcessSpecFlowGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralProcessEditor.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralProcessEditor.EditRow(row);
        e.stopPropagation();
    }
};
