var app = app || {};

app.SecurityUserMember = (function () {

    function Refresh() {
        var filter = $('#UserMemberSearch').val();
        var recordStatusFltVal = $('#RecordStatusFlt').select2('data').map(function (item) { return item['id']; }).toString();
        if (recordStatusFltVal != '')
            recordStatusFltVal = '&recordStatus=' + recordStatusFltVal;

        $('#UserMemberGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/UserMember/Get?filter=' + filter + recordStatusFltVal)
            .done(function (data, textStatus, jqXHR) {
                $('#UserMemberGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#UserMemberGridTbl').bootstrapTable('hideLoading');
            });

        if (localStorage.getItem('Roles').includes('Empleado')) {

            let lks = ['Agents.Cod_Agt'];
            app.core.Lookups(lks,
                function () {
                    data = {
                        Cod_Agt: null
                    };
                    app.ui.SetDropDownNumericValue('#Cod_Agt', data.Cod_Agt, true);

                }, `cod_ramo=302:cod_mon=1`);

            $('#agt-section').removeClass('d-none');
        }

    }

    function Init_Controls() {
        //new AutoNumeric('#FailedPasswordCount', {
        //    decimalCharacter: ',',
        //    digitGroupSeparator: '.',
        //    maximumValue: '999',
        //    minimumValue: '0',
        //    decimalPlaces: 0,
        //    emptyInputBehavior: 'null'
        //});
        new AutoNumeric('#SecurityLevel', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        //$('#LockedOutDate_group').datetimepicker({
        //    format: 'DD/MM/YYYY',
        //    locale: 'es'
        //});
        //$('#PasswordChangedDate_group').datetimepicker({
        //    format: 'DD/MM/YYYY',
        //    locale: 'es'
        //});
        //$('#LoginDate_group').datetimepicker({
        //    format: 'DD/MM/YYYY',
        //    locale: 'es'
        //});
        //new AutoNumeric('#ManagerId', {
        //    decimalCharacter: ',',
        //    digitGroupSeparator: '.',
        //    maximumValue: '999999999',
        //    minimumValue: '0',
        //    decimalPlaces: 0,
        //    emptyInputBehavior: 'null'
        //});
        $('#BirthDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null
        });


        $('#RecordStatusFlt').select2({ width: '100%', theme: 'bootstrap4' });
        $('#Roles').select2({ width: '100%', theme: 'bootstrap4' });

        $(".formbtn").appendTo("#GenericToolBar");
    };

    function Init_List() {
        $('#UserMemberGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            buttonsClass: "outline btn-default",
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'UserName',
                    title: 'Usuario',
                    sortable: true,
                    halign: 'center',
                    align: 'left',
                    events: 'UserMemberGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos del usuario">' + value + '</a>';
                    },
                }, {
                    field: 'EMail',
                    title: 'Correo',
                    sortable: true,
                    halign: 'center',
                    align: 'left'
                }, {
                    field: 'FirstName',
                    title: 'Nombre',
                    titleTooltip: 'Primer nombre.',
                    sortable: true,
                    halign: 'center',
                    align: 'left'
                }, {
                    field: 'LastName',
                    title: 'Apellidos',
                    titleTooltip: 'Apellidos.',
                    sortable: true,
                    halign: 'center',
                    align: 'left'
                }, {
                    field: 'LoginDate',
                    title: 'Última conexión',
                    titleTooltip: 'Último conexión o inicio de sesión de usuario.',
                    sortable: true,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateAndTimeFormatter'
                }, {
                    field: 'LockedOutDate',
                    title: 'Bloqueo',
                    titleTooltip: 'Fecha de bloqueo.',
                    sortable: true,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateAndTimeFormatter'
                }, {
                    field: 'RoleList',
                    title: 'Roles',
                    titleTooltip: 'Lista de roles asignados',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'RecordStatusDesc',
                    title: 'Estado',
                    titleTooltip: 'Estado general del registro.',
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
                    titleTooltip: 'Acciones disponibles para un usuario',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'UserMemberGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del usuario"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del usuario"> <i class="fa fa-close"></i></button>' +
                            '<button type="button" name="sendemail" class="btn btn-sm btn-white mail" title="Se asigna una nueva clave de acceso y se envía al correo registrado"><i class="fa fa-envelope-o"></i></button>';
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
            app.ui.components.ShowModalChangeSet(1002);
        });

        $('.tool-new').on('click', function (e) {
            app.SecurityUserMember.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#UserMemberSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#UserMemberEdtFormSave').click(function () {
            if (app.ui.IsValid('#UserMemberEdtForm', false)) {
                app.ui.ButtonDoing('#UserMemberEdtFormSave');
                var data = MapInputToObject()
                if (data.UserId === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#UserMemberEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#UserMemberEdtForm', false)) {
                app.ui.ButtonDoing('#UserMemberEdtFormSaveContinue');
                var data = MapInputToObject()
                if (data.UserId === 0)
                    Create(data, 'Continue');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#UserMemberEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#UserMemberEdtForm', false)) {
                app.ui.ButtonDoing('#UserMemberEdtFormSaveCopy');
                var data = MapInputToObject()
                if (data.UserId === 0)
                    Create(data, 'Copy');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#UserMemberEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#UserMemberEdtForm', false)) {
                app.ui.ButtonDoing('#UserMemberEdtFormDuplicate');
                var data = MapInputToObject();
                data.UserId = 0;
                data.UserName += ' copia';
                app.ui.ButtonDone('#UserMemberEdtFormDuplicate');
                app.SecurityUserMember.EditRow(data);
            }
            event.preventDefault();
        });

        $('#UserMemberEdtFormDelete').click(function () {
            app.ui.ButtonDoing('#UserMemberEdtFormDelete');
            var data = MapInputToObject();
            app.ui.ButtonDone('#UserMemberEdtFormDelete');
            app.SecurityUserMember.DeleteRow(data);
            event.preventDefault();
        });

        $('#UserMemberEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

        app.ui.DocumentNumberHandler('#DocumentNumber', DocumentNumberCallBack);
    };

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/UserMember/Post', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El usuario '" + uidata.UserName + "' fue creado. " + uidata.responseTronSubAgent, "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.SecurityUserMember.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.SecurityUserMember.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#UserMemberEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#UserMemberEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#UserMemberEdtFormSaveCopy');
                        break;
                }

            });
    };

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/UserMember/Put?id=' + uidata.UserId, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El usuario '" + uidata.UserName + "' fue modificado" + uidata.responseTronSubAgent, "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#UserMemberEdtFormSave');
            });
    };

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el usuario '" + uidata.UserName + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/UserMember/Delete?id=' + uidata.UserId)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El usuario '" + uidata.UserName + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    };

    function Init_Lookups() {
        app.core.Lookups(['EstadoRegistro.RecordStatus', 'EstadoRegistro.RecordStatusFlt', 'BranchOffice.BranchOffice', 'Position.Position'], Dynamic_Event_Controls);
        // Dependencies
    };

    function Dynamic_Event_Controls() {
        $('#RecordStatusFlt').select2({ width: '100%', theme: 'bootstrap4' });

        app.core.LoadLookup(app.setting.apipath + 'v1/RoleMember/Lookup', 'Roles');
    };

    function MapInputToObject() {

        var data = {
            UserId: parseInt(0 + $('#UserId').val(), 10),
            UserName: $('#UserName').val(),
            EMail: $('#EMail').val(),
            Password: $('#Password').val(),
            OldPassword: '', //$('#OldPassword').val(),
            IdentificationType: $("#DocumentNumberType").data("value"),
            Identification: $('#DocumentNumber').val(),
            FirstName: $('#FirstName').val(),
            LastName: $('#LastName').val(),
            BirthDate: app.ui.GetDateValue('#BirthDate'),
            FailedPasswordCount: 0, //app.ui.GetNumericValue('#FailedPasswordCount'),
            SecurityLevel: app.ui.GetNumericValue('#SecurityLevel'),
            IsLockedOut: $('input:radio[name=IsLockedOut]:checked').val(),
            // LockedOutDate: app.ui.GetDateValue('#LockedOutDate'),
            // PasswordChangedDate: "0001-01-01T00:00:00", //app.ui.GetDateValue('#PasswordChangedDate'),
            OneTimePassword: "", //$('#OneTimePassword').val(),
            //LoginDate: app.ui.GetDateValue('#LoginDate'),
            ManagerId: 0, //app.ui.GetNumericValue('#ManagerId'),
            AccessKey: $('#AccessKey').val(),
            BranchOffice: $('#BranchOffice').val(),
            Reference: $('#Reference').val(),
            Position: $('#Position').val(),
            PhoneNumber: $('#PhoneNumber').val(),
            SalesChannel: 0,
            CustomData: "", //$('#CustomData').val(),
            RecordStatus: $('#RecordStatus').val(),
            Roles: app.ui.GetDropDownMultiValues('Roles'),
            Extent: app.ui.GetExtentValue(),
            cod_agt: $('#Cod_Agt').val()
        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#UserId').val(data.UserId);
        $('#UserName').val(data.UserName);
        $('#EMail').val(data.EMail);
        $('#Password').val(data.Password);
        $('#OldPassword').val(data.OldPassword);
        app.ui.SetDocumentTypeValue('#DocumentNumberType', data.IdentificationType);
        $('#DocumentNumber').val(data.Identification);
        $('#FirstName').val(data.FirstName);
        $('#LastName').val(data.LastName);
        app.ui.SetDateValue('#BirthDate', data.BirthDate);
        //app.ui.SetNumericValue('#FailedPasswordCount', data.FailedPasswordCount);
        app.ui.SetNumericValue('#SecurityLevel', data.SecurityLevel);
        $('input:radio[name=IsLockedOut][value=' + data.IsLockedOut.toString() + ']').prop('checked', true);
        //app.ui.SetDateValue('#LockedOutDate', data.LockedOutDate);
        //app.ui.SetDateValue('#PasswordChangedDate', data.PasswordChangedDate);
        $('#OneTimePassword').val(data.OneTimePassword);
        //app.ui.SetDateValue('#LoginDate', data.LoginDate);
        //app.ui.SetNumericValue('#ManagerId', data.ManagerId);
        $('#AccessKey').val(data.AccessKey);
        $('#BranchOffice').val(data.BranchOffice);
        $('#Reference').val(data.Reference);
        $('#Position').val(data.Position);
        $('#PhoneNumber').val(data.PhoneNumber);
        //$('#SalesChannel').val(data.SalesChannel);
        //$('#CustomData').val(data.CustomData);
        $('#RecordStatus').val(data.RecordStatus);
        app.ui.SetDropDownMultiValues('Roles', data.Roles);

        app.ui.SetExtentValue(data.Extent);
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#UserMemberEdtForm").validate({
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
                DocumentNumber: {
                    required: true
                },
                UserName: {
                    required: true
                },
                EMail: {
                    required: true,
                    email: true
                },
                Password: {
                    required: true,
                    minlength: 8,
                    pattern: /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).+$/
                },
                FirstName: {
                    required: true
                },
                LastName: {
                    required: true
                },
                BirthDate: { BirthDate: true },
                LockedOutDate: {
                    localDate: true
                },
                PasswordChangedDate: {
                    localDate: true
                },
                LoginDate: {
                    localDate: true
                },
                RecordStatus: {
                    required: true
                },
                Roles: {
                    required: true
                }
            },
            messages: {
                DocumentNumber: {
                    required: 'Debe indicar el numero de identificacion del usuario'
                },
                UserName: {
                    required: 'Debe indicar el usuario'
                },
                EMail: {
                    required: 'Debe indicar el correo',
                    email: 'Debe indicar un correo electrónico valido'
                },
                Password: {
                    required: 'Debe indicar el clave',
                    minlength: 'la clave de acceso deben tener por lo menos 8 caracteres',
                    pattern: ' Debe tener una mayúscula, un número y un carácter especial'
                },
                FirstName: {
                    required: 'Debe indicar el nombre'
                },
                LastName: {
                    required: 'Debe indicar el apellidos'
                },
                BirthDate: {
                    BirthDate: 'Ingrese una fecha inferior al día de hoy'
                },
                LockedOutDate: {
                    localDate: 'Ingrese la fecha en el formato dd/mm/yyyy'
                },
                PasswordChangedDate: {
                    localDate: 'Ingrese la fecha en el formato dd/mm/yyyy'
                },
                LoginDate: {
                    localDate: 'Ingrese la fecha en el formato dd/mm/yyyy'
                },
                RecordStatus: {
                    required: 'Debe indicar el estado del registro'
                },
                Roles: {
                    required: 'Debe indicar al menos un rol'
                }
            }

        });
    };

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#UserMemberGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#UserMemberEdt').removeClass('d-none');

        if (row.UserId > 0)
            app.core.Get(app.setting.apipath + 'v1/UserMember/getbyid?id=' + row.UserId)
                .done(function (data, textStatus, jqXHR) {
                    MapObjectToInput(data);
                    $('#UserName').focus();

                    $('#UserMemberEdtFormSaveContinue').addClass('d-none');
                    $('#UserMemberEdtFormSaveCopy').addClass('d-none');
                    $('#UserMemberEdtFormDuplicate').removeClass('d-none');
                    $('#UserMemberEdtFormDelete').removeClass('d-none');
                    $('#UserMemberEdtFormSave').removeClass('d-none');
                    $('#UserMemberEdtFormCancel').removeClass('d-none');
                });
        else {
            MapObjectToInput(row);
            $('#UserName').focus();
            $('#UserMemberEdtFormSaveContinue').removeClass('d-none');
            $('#UserMemberEdtFormSaveCopy').removeClass('d-none');
            $('#UserMemberEdtFormDuplicate').addClass('d-none');
            $('#UserMemberEdtFormDelete').addClass('d-none');
            $('#UserMemberEdtFormSave').removeClass('d-none');
            $('#UserMemberEdtFormCancel').removeClass('d-none');
        }
    };

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#UserMemberGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#UserMemberEdt').addClass('d-none');
        $('.formbtn').addClass('d-none');
    };

    function DocumentNumberCallBack(data) {
        if (data != null) {
            $('#FirstName').val((data.FirstName + ' ' + data.MiddleName).trim());
            $('#LastName').val((data.LastName + ' ' + data.SecondLastName).trim());
            $('#PhoneNumber').val(data.PhoneNumber);
            app.ui.SetDateValue('#BirthDate', data.BirthDate);
        }
        let tenant = localStorage.getItem('Tenant');
        if (tenant === 'Aliados' || tenant === 'Purdy') {
            let documentNumber = $('#DocumentNumber').val();
            let docType = $('#DocumentNumberType').data('value');
            app.core.Get(app.setting.apipath + `v1/Security/agent?tip_docum=${docType}&cod_docum=${documentNumber}`)
                .done(function (data, textStatus, jqXHR) {
                    if (data != '') {
                        $('#EMail').val(data.EMail);
                    }
                });
        }
    }

    return {
        Init: function () {
            Init_List();
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Refresh();
            Setup_Validations();

            app.core.Get(app.setting.apipath + 'v1/Common/RenderCustomFields?entityType=1002')
                .done(function (data, textStatus, jqXHR) {
                    $("#extend").append(data);
                });
        },
        New: function (row) {
            let newRow = {
                UserId: 0, UserName: null, EMail: null, Password: null, OldPassword: null, FirstName: null, LastName: null,
                FailedPasswordCount: 0, SecurityLevel: 0, IsLockedOut: null, LockedOutDate: null, PasswordChangedDate: null,
                OneTimePassword: null, LoginDate: null, ManagerId: 0, AccessKey: null, BranchOffice: null, Reference: null,
                Position: null, PhoneNumber: null, SalesChannel: null, CustomData: null, RecordStatus: 1, BirthDate: null,
                IsLockedOut: false, IdentificationType: 1, Identification: null
            };
            if (row !== undefined) {
                row.UserId = 0;
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

window.UserMemberGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.SecurityUserMember.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.SecurityUserMember.EditRow(row);
        e.stopPropagation();
    },
    'click .mail': function (e, value, row, index) {

        app.core.Post(app.setting.apipath + 'v1/UserMember/SendCredentials?id=' + row.UserId)
            .done(function (data, textStatus, jqXHR) {
                toastr.success("Las credenciales fueron enviadas", "", { timeOut: 5000, closeButton: true, progressBar: true });
            });

        e.stopPropagation();
    }
};
