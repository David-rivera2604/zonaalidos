var app = app || {};

app.SecurityUserRoleMember = (function () {

    function Refresh() {
        var filter = $('#UserRoleMemberSearch').val();

        $('#UserRoleMemberGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/UserRoleMember/Get?filter=' + filter)
            .done(function (data, textStatus, jqXHR) {
                $('#UserRoleMemberGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#UserRoleMemberGridTbl').bootstrapTable('hideLoading');
            });
    }

    function Init_Controls() {
        new AutoNumeric('#UserId', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#RoleId', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });


    };

    function Init_List() {
        $('#UserRoleMemberGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'UserId',
                    title: 'Usuario',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'RoleId',
                    title: 'Role',
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
                    events: 'UserRoleMemberGridTbl_Events',
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
            app.SecurityUserRoleMember.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#UserRoleMemberSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#UserRoleMemberEdtFormSave').click(function () {
            if (app.ui.IsValid('#UserRoleMemberEdtForm', false)) {
                $('#UserRoleMemberEdtFormSave').prop("disabled", true);
                $('#UserRoleMemberEdtFormSave').html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Guardando cambios');
                var data = MapInputToObject()
                if (data.Id === 0)
                    Create(data);
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#UserRoleMemberEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

    };

    function Create(uidata) {
        app.core.Post(app.setting.apipath + 'v1/UserRoleMember/Post', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El rol por usuario '" + uidata. + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                $('#UserRoleMemberEdtFormSave').html('Guardar cambios');
                $('#UserRoleMemberEdtFormSave').prop("disabled", false);
            });
    };

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/UserRoleMember/Put?id=' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El rol por usuario '" + uidata. + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                $('#UserRoleMemberEdtFormSave').html('Guardar cambios');
                $('#UserRoleMemberEdtFormSave').prop("disabled", false);
            });
    };

    function Delete(uidata) {
        app.core.Delete(app.setting.apipath + 'v1/UserRoleMember/Delete?id=' + uidata.Id)
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El rol por usuario '" + uidata. + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
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
            UserId: app.ui.GetNumericValue('#UserId'),
            RoleId: app.ui.GetNumericValue('#RoleId')

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        app.ui.SetNumericValue('#UserId', data.UserId);
        app.ui.SetNumericValue('#RoleId', data.RoleId);

    };

    function Setup_Validations() {
        $("#UserRoleMemberEdtForm").validate({
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
                UserId: {
                    required: true
                },
                RoleId: {
                    required: true
                }
            },
            messages: {
                UserId: {
                    required: 'Debe indicar el usuario'
                },
                RoleId: {
                    required: 'Debe indicar el role'
                }
            }

        });
    };

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#UserRoleMemberGridTbl').addClass('d-none');
        $('#UserRoleMemberEdt').removeClass('d-none');
        MapObjectToInput(row);
        $('#').focus();
    };

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#UserRoleMemberGridTbl').removeClass('d-none');
        $('#UserRoleMemberEdt').addClass('d-none');
    };

    return {
        Init: function () {
            Init_List();
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Refresh();
            Setup_Validations();
            app.language.translate('body', 'userrolemember')();
        },
        New: function () {
            EditMode({ Id: 0, UserId: 0, RoleId: 0 });
        },
        EditRow: function (row) {
            EditMode(row);
        },
        DeleteRow: function (row) {
            Delete(row);
        }
    };
})();

window.UserRoleMemberGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el rol por usuario '" + row. + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.SecurityUserRoleMember.DeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.SecurityUserRoleMember.EditRow(row);
        e.stopPropagation();
    }
};
