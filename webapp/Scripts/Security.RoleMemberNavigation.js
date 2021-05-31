var app = app || {};

app.SecurityRoleMemberNavigation = (function () {

    function Refresh() {
        var filter = $('#RoleMemberNavigationSearch').val();

        $('#RoleMemberNavigationGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/RoleMemberNavigation/Get?filter=' + filter)
            .done(function (data, textStatus, jqXHR) {
                $('#RoleMemberNavigationGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#RoleMemberNavigationGridTbl').bootstrapTable('hideLoading');
            });
    }

    function Init_Controls() {
        new AutoNumeric('#RoleId', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#SecurityLevel', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });


    };

    function Init_List() {
        $('#RoleMemberNavigationGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'RoleId',
                    title: 'Role',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'SecurityLevel',
                    title: 'Seguridad',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
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
                    titleTooltip: 'Acciones disponibles para una fila',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'RoleMemberNavigationGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar una fila"> <i class="fa fa-close"></i> </button>';
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
            app.ui.components.ShowModalChangeSet(1001);
        });

        $('.tool-new').on('click', function (e) {
            app.SecurityRoleMemberNavigation.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#RoleMemberNavigationSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#RoleMemberNavigationEdtFormSave').click(function () {
            if (app.ui.IsValid('#RoleMemberNavigationEdtForm', false)) {
                $('#RoleMemberNavigationEdtFormSave').prop("disabled", true);
                $('#RoleMemberNavigationEdtFormSave').html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Guardando cambios');
                var data = MapInputToObject()
                if (data.Id === 0)
                    Create(data);
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#RoleMemberNavigationEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

    };

    function Create(uidata) {
        app.core.Post(app.setting.apipath + 'v1/RoleMemberNavigation/Post', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El role member navigation '" + uidata. + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                $('#RoleMemberNavigationEdtFormSave').html('Guardar cambios');
                $('#RoleMemberNavigationEdtFormSave').prop("disabled", false);
            });
    };

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/RoleMemberNavigation/Put?id=' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El role member navigation '" + uidata. + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                $('#RoleMemberNavigationEdtFormSave').html('Guardar cambios');
                $('#RoleMemberNavigationEdtFormSave').prop("disabled", false);
            });
    };

    function Delete(uidata) {
        app.core.Delete(app.setting.apipath + 'v1/RoleMemberNavigation/Delete?id=' + uidata.Id)
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El role member navigation '" + uidata. + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            });
    };

    function Init_Lookups() {

        // Dependencies
    };

    function Dynamic_Event_Controls() {

    };

    function MapInputToObject() {
        var data = {	
            Id: parseInt(0 + $('#Id').val(), 10),
            RoleId: app.ui.GetNumericValue('#RoleId'),
            Code: $('#Code').val(),
            Allow: $('#Allow').is(':checked'),
            SecurityLevel: app.ui.GetNumericValue('#SecurityLevel'),
            CreateAction: $('#CreateAction').is(':checked'),
            ReadAction: $('#ReadAction').is(':checked'),
            UpdateAction: $('#UpdateAction').is(':checked'),
            DeleteAction: $('#DeleteAction').is(':checked'),
            ListAction: $('#ListAction').is(':checked'),
            PrintAction: $('#PrintAction').is(':checked')

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        app.ui.SetNumericValue('#RoleId', data.RoleId);
        $('#Code').val(data.Code);
        $('#Allow').prop('checked', data.Allow);
        app.ui.SetNumericValue('#SecurityLevel', data.SecurityLevel);
        $('#CreateAction').prop('checked', data.CreateAction);
        $('#ReadAction').prop('checked', data.ReadAction);
        $('#UpdateAction').prop('checked', data.UpdateAction);
        $('#DeleteAction').prop('checked', data.DeleteAction);
        $('#ListAction').prop('checked', data.ListAction);
        $('#PrintAction').prop('checked', data.PrintAction);

    };

    function Setup_Validations() {
        $("#RoleMemberNavigationEdtForm").validate({
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
                RoleId: {
                    required: true
                },
                SecurityLevel: {
                    required: true
                }
            },
            messages: {
                RoleId: {
                    required: 'Debe indicar el role'
                },
                SecurityLevel: {
                    required: 'Debe indicar el seguridad'
                }
            }

        });
    };

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#RoleMemberNavigationGridTbl').addClass('d-none');
        $('#RoleMemberNavigationEdt').removeClass('d-none');
        MapObjectToInput(row);
        $('#').focus();
    };

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#RoleMemberNavigationGridTbl').removeClass('d-none');
        $('#RoleMemberNavigationEdt').addClass('d-none');
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
        New: function () {
            EditMode({ Id: 0, RoleId: 0, Code: null, Allow: null, SecurityLevel: 0, CreateAction: null, ReadAction: null, UpdateAction: null, DeleteAction: null, ListAction: null, PrintAction: null });
        },
        EditRow: function (row) {
            EditMode(row);
        },
        DeleteRow: function (row) {
            Delete(row);
        }
    };
})();

window.RoleMemberNavigationGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el role member navigation '" + row. + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.SecurityRoleMemberNavigation.DeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.SecurityRoleMemberNavigation.EditRow(row);
        e.stopPropagation();
    }
};
