var app = app || {};

app.GeneralPaymentSettings = (function () {

    function Refresh() {
        var filter = $('#PaymentSettingsSearch').val();
        var userIdFltVal = $('#UserIdFlt').select2('data').map(function (item) { return item['id']; }).toString();
        if (userIdFltVal != '')
            userIdFltVal = '&userId=' + userIdFltVal;

        $('#PaymentSettingsGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/PaymentSettings?filter=' + filter + userIdFltVal)
            .done(function (data, textStatus, jqXHR) {
                $('#PaymentSettingsGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#PaymentSettingsGridTbl').bootstrapTable('hideLoading');
            });
    }

    function Init_Controls() {

        $('#UserIdFlt').select2({ width: '100%', theme: 'bootstrap4' });

        $(".formbtn").appendTo("#GenericToolBar");
    }

    function Init_List() {
        $('#PaymentSettingsGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'UserIdDesc',
                    title: 'Usuario',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'CurrencyDesc',
                    title: 'Moneda',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'ClientId',
                    title: 'Client Id',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'SecretKey',
                    title: 'Secret Key',
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
                    titleTooltip: 'Acciones disponibles para un paymentsettings',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'PaymentSettingsGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del paymentsettings de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del paymentsettings de la fila"> <i class="fa fa-close"></i> </button>';
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
            app.GeneralPaymentSettings.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#PaymentSettingsSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#PaymentSettingsEdtFormSave').click(function () {
            if (app.ui.IsValid('#PaymentSettingsEdtForm', false)) {
                app.ui.ButtonDoing('#PaymentSettingsEdtFormSave');
                var data = MapInputToObject();
                if (data.Id === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#PaymentSettingsEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#PaymentSettingsEdtForm', false)) {
                app.ui.ButtonDoing('#PaymentSettingsEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#PaymentSettingsEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#PaymentSettingsEdtForm', false)) {
                app.ui.ButtonDoing('#PaymentSettingsEdtFormSaveCopy');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#PaymentSettingsEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#PaymentSettingsEdtForm', false)) {
                app.ui.ButtonDoing('#PaymentSettingsEdtFormDuplicate');
                var data = MapInputToObject();
                data.Id = 0;
                app.ui.ButtonDone('#PaymentSettingsEdtFormDuplicate');
                app.GeneralPaymentSettings.EditRow(data);
            }
            event.preventDefault();
        });

        $('#PaymentSettingsEdtFormDelete').click(function () {
            if (app.ui.IsValid('#PaymentSettingsEdtForm', false)) {
                app.ui.ButtonDoing('#PaymentSettingsEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#PaymentSettingsEdtFormDelete');
                app.GeneralPaymentSettings.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#PaymentSettingsEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

    }

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/PaymentSettings', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El paymentsettings '" + uidata.UserIdDesc + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralPaymentSettings.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralPaymentSettings.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#PaymentSettingsEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#PaymentSettingsEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#PaymentSettingsEdtFormSaveCopy');
                        break;
                }
            });
    }

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/PaymentSettings/' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El paymentsettings '" + uidata.UserIdDesc + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#PaymentSettingsEdtFormSave');
            });
    }

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el paymentsettings '" + uidata.UserIdDesc + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/PaymentSettings/' + uidata.Id)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El paymentsettings '" + uidata.UserIdDesc + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    }

    function Init_Lookups() {
        app.core.Lookups(['Users.UserId', 'Users.UserIdFlt', 'Currencies.Currency'], Dynamic_Event_Controls);
        // Dependencies
    }

    function Dynamic_Event_Controls() {
        $('#UserIdFlt').select2({ width: '100%', theme: 'bootstrap4' });

    }

    function MapInputToObject() {
        return {
            Id: parseInt(0 + $('#Id').val(), 10),
            UserId: $('#UserId').val(),
            Currency: $('#Currency').val(),
            ClientId: $('#ClientId').val(),
            SecretKey: $('#SecretKey').val()

        };
    }

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        $('#UserId').val(data.UserId);
        $('#Currency').val(data.Currency);
        $('#ClientId').val(data.ClientId);
        $('#SecretKey').val(data.SecretKey);

    }

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#PaymentSettingsEdtForm").validate({
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
                Currency: {
                    required: true
                },
                ClientId: {
                    required: true
                },
                SecretKey: {
                    required: true
                }
            },
            messages: {
                UserId: {
                    required: 'Debe indicar el usuario'
                },
                Currency: {
                    required: 'Debe indicar el moneda'
                },
                ClientId: {
                    required: 'Debe indicar el client id'
                },
                SecretKey: {
                    required: 'Debe indicar el secret key'
                }
            }

        });
    }

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#PaymentSettingsGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#PaymentSettingsEdt').removeClass('d-none');

        if (row.Id === 0) {
            MapObjectToInput(row);
            $('#UserId').focus();
            $('#PaymentSettingsEdtFormSaveContinue').removeClass('d-none');
            $('#PaymentSettingsEdtFormSaveCopy').removeClass('d-none');
            $('#PaymentSettingsEdtFormDuplicate').addClass('d-none');
            $('#PaymentSettingsEdtFormDelete').addClass('d-none');
            $('#PaymentSettingsEdtFormSave').removeClass('d-none');
            $('#PaymentSettingsEdtFormCancel').removeClass('d-none');
        } else {
            $('.ibox-content').toggleClass('sk-loading');
            app.core.Get(app.setting.apipath + 'v1/PaymentSettings/' + row.Id)
                .done(function (data, textStatus, jqXHR) {
                    MapObjectToInput(data);
                    $('#UserId').focus();
                    $('#PaymentSettingsEdtFormSaveContinue').addClass('d-none');
                    $('#PaymentSettingsEdtFormSaveCopy').addClass('d-none');
                    $('#PaymentSettingsEdtFormDuplicate').removeClass('d-none');
                    $('#PaymentSettingsEdtFormDelete').removeClass('d-none');
                    $('#PaymentSettingsEdtFormSave').removeClass('d-none');
                    $('#PaymentSettingsEdtFormCancel').removeClass('d-none');
                }).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });
        }
    }

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#PaymentSettingsGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#PaymentSettingsEdt').addClass('d-none');
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
            app.language.translate('body', 'paymentsettings')();
        },
        New: function (row) {
            let newRow = { Id: 0, UserId: null, Currency: null, ClientId: null, SecretKey: null }
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

window.PaymentSettingsGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralPaymentSettings.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralPaymentSettings.EditRow(row);
        e.stopPropagation();
    }
};
