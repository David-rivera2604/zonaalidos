var app = app || {};

app.GeneralNavigation = (function () {

    function Refresh() {
        var filter = $('#NavigationSearch').val();

        $('#NavigationGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/Navigation?filter=' + filter)
            .done(function (data, textStatus, jqXHR) {
                $('#NavigationGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#NavigationGridTbl').bootstrapTable('hideLoading');
            });
    }

    function Init_Controls() {
        new AutoNumeric('#Sequence', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '99999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });

        $('#Roles').select2({ width: '100%', theme: 'bootstrap4' });

        $(".formbtn").appendTo("#GenericToolBar");
    }

    function Init_List() {
        $('#NavigationGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'ParentCodeDesc',
                    title: 'Menú',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Code',
                    title: 'Código',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'TypeDesc',
                    title: 'Tipo',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Title',
                    title: 'Título',
                    sortable: true,
                    halign: 'center',
                    events: 'NavigationGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos del navegación">' + value + '</a>';
                    }
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'MenuTitle',
                    title: 'Título del menú',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'URLPath',
                    title: 'Ruta',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'URLHelp',
                    title: 'Ayuda',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'SmallImage',
                    title: 'Imagen pequeña',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'BigImage',
                    title: 'Imagen grande',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Sequence',
                    title: 'Orden',
                    titleTooltip: 'Orden de aparición.',					
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'RecordStatusDesc',
                    title: 'Estado del Registro',
                    sortable: true,
                    halign: 'center'
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
                    titleTooltip: 'Acciones disponibles para un navegación',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'NavigationGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del navegación de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del navegación de la fila"> <i class="fa fa-close"></i> </button>';
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
    }

    function Event_Controls() {

        $('.tool-audit').on('click', function (e) {
            app.ui.components.ShowModalChangeSet(1004);
        });

        $('.tool-new').on('click', function (e) {
            app.GeneralNavigation.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#NavigationSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#NavigationEdtFormSave').click(function () {
            if (app.ui.IsValid('#NavigationEdtForm', false)) {
                app.ui.ButtonDoing('#NavigationEdtFormSave');
                var data = MapInputToObject();
                if (data.NavigationId === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#NavigationEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#NavigationEdtForm', false)) {
                app.ui.ButtonDoing('#NavigationEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#NavigationEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#NavigationEdtForm', false)) {
                app.ui.ButtonDoing('#NavigationEdtFormSaveCopy');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#NavigationEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#NavigationEdtForm', false)) {
                app.ui.ButtonDoing('#NavigationEdtFormDuplicate');
                var data = MapInputToObject();
                data.NavigationId = 0;
                data.Title += ' duplicado';
                app.ui.ButtonDone('#NavigationEdtFormDuplicate');
                app.GeneralNavigation.EditRow(data);
            }
            event.preventDefault();
        });

        $('#NavigationEdtFormDelete').click(function () {
            if (app.ui.IsValid('#NavigationEdtForm', false)) {
                app.ui.ButtonDoing('#NavigationEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#NavigationEdtFormDelete');
                app.GeneralNavigation.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#NavigationEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

    }

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/Navigation', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El navegación '" + uidata.Title + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralNavigation.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralNavigation.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#NavigationEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#NavigationEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#NavigationEdtFormSaveCopy');
                        break;
                }
            });
    }

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/Navigation/' + uidata.NavigationId, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El navegación '" + uidata.Title + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#NavigationEdtFormSave');
            });
    }

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el navegación '" + uidata.Title + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/Navigation/' + uidata.NavigationId)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El navegación '" + uidata.Title + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    }

    function Init_Lookups() {
        app.core.Lookups(['NavigacionMenu.ParentCode', 'NavigationType.Type', 'EstadoRegistro.RecordStatus'], Dynamic_Event_Controls);
        // Dependencies
    }

    function Dynamic_Event_Controls() {
        app.core.LoadLookup(app.setting.apipath + 'v1/RoleMember/Lookup', 'Roles');
    }

    function MapInputToObject() {
        return {
            NavigationId: parseInt(0 + $('#NavigationId').val(), 10),
            ParentCode: $('#ParentCode').val(),
            Code: $('#Code').val(),
            Type: $('#Type').val(),
            Title: $('#Title').val(),
            Description: $('#Description').val(),
            MenuTitle: $('#MenuTitle').val(),
            URLPath: $('#URLPath').val(),
            URLHelp: $('#URLHelp').val(),
            SmallImage: $('#SmallImage').val(),
            BigImage: $('#BigImage').val(),
            Sequence: app.ui.GetNumericValue('#Sequence'),
            RecordStatus: $('#RecordStatus').val(),
            Roles: app.ui.GetDropDownMultiValues('Roles')
        };
    }

    function MapObjectToInput(data) {
        $('#NavigationId').val(data.NavigationId);
        $('#ParentCode').val(data.ParentCode);
        $('#Code').val(data.Code);
        $('#Type').val(data.Type);
        $('#Title').val(data.Title);
        $('#Description').val(data.Description);
        $('#MenuTitle').val(data.MenuTitle);
        $('#URLPath').val(data.URLPath);
        $('#URLHelp').val(data.URLHelp);
        $('#SmallImage').val(data.SmallImage);
        $('#BigImage').val(data.BigImage);
        app.ui.SetNumericValue('#Sequence', data.Sequence);
        $('#RecordStatus').val(data.RecordStatus);
        app.ui.SetDropDownMultiValues('Roles', data.Roles);
    }

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#NavigationEdtForm").validate({
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
                Code: {
                    required: true
                },
                Title: {
                    required: true
                },
                URLPath: {
                    required: true
                },
                Sequence: {
                    required: true
                },
                RecordStatus: {
                    required: true
                },
                Roles: {
                    required: true
                }
            },
            messages: {
                Code: {
                    required: 'Debe indicar el código'
                },
                Title: {
                    required: 'Debe indicar el título'
                },
                URLPath: {
                    required: 'Debe indicar el ruta'
                },
                Sequence: {
                    required: 'Debe indicar el orden'
                },
                RecordStatus: {
                    required: 'Debe indicar el estado del registro'
                },
                Roles: {
                    required: 'Debe indicar al menos un rol'
                }
            }

        });
    }

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#NavigationGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#NavigationEdt').removeClass('d-none');

        if (row.NavigationId === 0) {
            MapObjectToInput(row);
            $('#Title').focus();
            $('#NavigationEdtFormSaveContinue').removeClass('d-none');
            $('#NavigationEdtFormSaveCopy').removeClass('d-none');
            $('#NavigationEdtFormDuplicate').addClass('d-none');
            $('#NavigationEdtFormDelete').addClass('d-none');
            $('#NavigationEdtFormSave').removeClass('d-none');
            $('#NavigationEdtFormCancel').removeClass('d-none');
        } else {
            $('.ibox-content').toggleClass('sk-loading');
            app.core.Get(app.setting.apipath + 'v1/Navigation/' + row.NavigationId)
                .done(function (data, textStatus, jqXHR) {
                    MapObjectToInput(data);
                    $('#Title').focus();
                    $('#NavigationEdtFormSaveContinue').addClass('d-none');
                    $('#NavigationEdtFormSaveCopy').addClass('d-none');
                    $('#NavigationEdtFormDuplicate').removeClass('d-none');
                    $('#NavigationEdtFormDelete').removeClass('d-none');
                    $('#NavigationEdtFormSave').removeClass('d-none');
                    $('#NavigationEdtFormCancel').removeClass('d-none');
                }).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });
        }
    }

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#NavigationGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#NavigationEdt').addClass('d-none');
        $('.formbtn').addClass('d-none');
    }

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
            let newRow = { NavigationId: 0, ParentCode: null, Code: null, Type: null, Title: null, Description: null, MenuTitle: null, URLPath: null, URLHelp: null, SmallImage: null, BigImage: null, Sequence: 1, RecordStatus: null }
            if (row !== undefined) {
                row.NavigationId = 0;
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

window.NavigationGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralNavigation.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralNavigation.EditRow(row);
        e.stopPropagation();
    }
};
