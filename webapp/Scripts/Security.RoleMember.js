var app = app || {};

app.SecurityRoleMember = (function () {

    function Refresh() {
        var filter = $('#RoleMemberSearch').val();
        var recordStatusFltVal = $('#RecordStatusFlt').select2('data').map(function (item) { return item['id']; }).toString();
        if (recordStatusFltVal != '')
            recordStatusFltVal = '|recordStatus.in.(' + recordStatusFltVal + ")";

        $('#RoleMemberGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/RoleMember?filter=' + filter + recordStatusFltVal)
            .done(function (data, textStatus, jqXHR) {
                $('#RoleMemberGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#RoleMemberGridTbl').bootstrapTable('hideLoading');
            });
    }

    function Init_Controls() {
        new AutoNumeric('#SecurityLevel', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });

        $('#RecordStatusFlt').select2({ width: '100%', theme: 'bootstrap4' });

        $(".formbtn").appendTo("#GenericToolBar");
    }

    function Init_List() {
        $('#RoleMemberGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'RoleName',
                    title: 'Role',
                    sortable: true,
                    halign: 'center',
                    events: 'RoleMemberGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos del rol">' + value + '</a>';
                    }
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'SecurityLevel',
                    title: 'Seguridad',
                    titleTooltip: 'Nivel de seguridad.',					
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'InitialNavigationCodeDesc',
                    title: 'Página inicial',
                    sortable: true,
                    halign: 'center',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'RecordStatusDesc',
                    title: 'Estado',
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
                    titleTooltip: 'Acciones disponibles para un rol',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'RoleMemberGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del rol de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del rol de la fila"> <i class="fa fa-close"></i> </button>';
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
            app.ui.components.ShowModalChangeSet(1001);
        });

        $('.tool-new').on('click', function (e) {
            app.SecurityRoleMember.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#RoleMemberSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#RoleMemberEdtFormSave').click(function () {
            if (app.ui.IsValid('#RoleMemberEdtForm', false)) {
                app.ui.ButtonDoing('#RoleMemberEdtFormSave');
                var data = MapInputToObject();
                if (data.RoleId === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#RoleMemberEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#RoleMemberEdtForm', false)) {
                app.ui.ButtonDoing('#RoleMemberEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#RoleMemberEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#RoleMemberEdtForm', false)) {
                app.ui.ButtonDoing('#RoleMemberEdtFormSaveCopy');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#RoleMemberEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#RoleMemberEdtForm', false)) {
                app.ui.ButtonDoing('#RoleMemberEdtFormDuplicate');
                var data = MapInputToObject();
                data.RoleId = 0;
                data.RoleName += ' duplicado';
                app.ui.ButtonDone('#RoleMemberEdtFormDuplicate');
                app.SecurityRoleMember.EditRow(data);
            }
            event.preventDefault();
        });

        $('#RoleMemberEdtFormDelete').click(function () {
            if (app.ui.IsValid('#RoleMemberEdtForm', false)) {
                app.ui.ButtonDoing('#RoleMemberEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#RoleMemberEdtFormDelete');
                app.SecurityRoleMember.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#RoleMemberEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

    }

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/RoleMember', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El rol '" + uidata.RoleName + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.SecurityRoleMember.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.SecurityRoleMember.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#RoleMemberEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#RoleMemberEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#RoleMemberEdtFormSaveCopy');
                        break;
                }
            });
    }

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/RoleMember/' + uidata.RoleId, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El rol '" + uidata.RoleName + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#RoleMemberEdtFormSave');
            });
    }

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el rol '" + uidata.RoleName + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/RoleMember/' + uidata.RoleId)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El rol '" + uidata.RoleName + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    }

    function Init_Lookups() {
        app.core.Lookups(['NavigacionPage.InitialNavigationCode.', 'EstadoRegistro.RecordStatus', 'EstadoRegistro.RecordStatusFlt'], Dynamic_Event_Controls);
        // Dependencies
    }

    function Dynamic_Event_Controls() {
        $('#RecordStatusFlt').select2({ width: '100%', theme: 'bootstrap4' });

    }

    function MapInputToObject() {
        return {
            RoleId: parseInt(0 + $('#RoleId').val(), 10),
            RoleName: $('#RoleName').val(),
            Description: $('#Description').val(),
            SecurityLevel: app.ui.GetNumericValue('#SecurityLevel'),
            InitialNavigationCode: $('#InitialNavigationCode').val(),
            RecordStatus: $('#RecordStatus').val()

        };
    }

    function MapObjectToInput(data) {
        $('#RoleId').val(data.RoleId);
        $('#RoleName').val(data.RoleName);
        $('#Description').val(data.Description);
        app.ui.SetNumericValue('#SecurityLevel', data.SecurityLevel);
        $('#InitialNavigationCode').val(data.InitialNavigationCode);
        $('#RecordStatus').val(data.RecordStatus);

    }

    function Setup_Validations() {

        $.validator.addMethod("regex",
            function (value, element, regexp) {
                return this.optional(element) || regexp.test(value);
            }, "Valor invalido"
        );

        $("#RoleMemberEdtForm").validate({
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
                RoleName: {
                    required: true,
                    regex: /^[a-zA-ZñÑáéíóúÁÉÍÓÚ0-9'_ .-]+$/
                },
                Description: {
                    regex: /^[a-zA-ZñÑáéíóúÁÉÍÓÚ0-9' .-]+$/
                },
                RecordStatus: {
                    required: true
                }
            },
            messages: {
                RoleName: {
                    required: 'Debe indicar el nombre del rol',
                    regex: 'Debe indicar el nombre del rol valido'
                },
                Description: {
                    regex: 'Debe indicar una descripción valida'
                },
                RecordStatus: {
                    required: 'Debe indicar el estado del registro'
                }
            }

        });
    }

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#RoleMemberGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#RoleMemberEdt').removeClass('d-none');

        if (row.RoleId === 0) {
            MapObjectToInput(row);
            $('#RoleName').focus();
            $('#RoleMemberEdtFormSaveContinue').removeClass('d-none');
            $('#RoleMemberEdtFormSaveCopy').removeClass('d-none');
            $('#RoleMemberEdtFormDuplicate').addClass('d-none');
            $('#RoleMemberEdtFormDelete').addClass('d-none');
            $('#RoleMemberEdtFormSave').removeClass('d-none');
            $('#RoleMemberEdtFormCancel').removeClass('d-none');
        } else {
            $('.ibox-content').toggleClass('sk-loading');
            app.core.Get(app.setting.apipath + 'v1/RoleMember/' + row.RoleId)
                .done(function (data, textStatus, jqXHR) {
                    MapObjectToInput(data);
                    $('#RoleName').focus();
                    $('#RoleMemberEdtFormSaveContinue').addClass('d-none');
                    $('#RoleMemberEdtFormSaveCopy').addClass('d-none');
                    $('#RoleMemberEdtFormDuplicate').removeClass('d-none');
                    $('#RoleMemberEdtFormDelete').removeClass('d-none');
                    $('#RoleMemberEdtFormSave').removeClass('d-none');
                    $('#RoleMemberEdtFormCancel').removeClass('d-none');
                }).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });
        }
    }

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#RoleMemberGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#RoleMemberEdt').addClass('d-none');
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
            let newRow = { RoleId: 0, RoleName: null, Description: null, SecurityLevel: 50, InitialNavigationCode: null, RecordStatus: 1 }
            if (row !== undefined) {
                row.RoleId = 0;
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

window.RoleMemberGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.SecurityRoleMember.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.SecurityRoleMember.EditRow(row);
        e.stopPropagation();
    }
};
