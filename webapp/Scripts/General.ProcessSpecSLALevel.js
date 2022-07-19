var app = app || {};

app.GeneralProcessSpecSLALevel = (function () {
    let gridCtrl;
    let modalCtrl;

    function Events() {

        $('#ProcessSpecSLALevelNew').click(function () {
            NewEditRow({
                Id: 0, SLAId: 0, SLATimeOut: 0, MailForSLAExpiration: 1, MailForSLAExpirationCustom: '{roles}', MailForSLAExpirationTmpl: 1 });
            event.preventDefault();
        });

        $('#ProcessSpecSLALevelEdtFormSave').click(function () {
            if (app.ui.IsValid('#ProcessSpecSLALevelEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecSLALevelEdtFormSave');
                let data = InputToObject();
                if (data.Id === 0)
                    AddRow(data, 'Save');
                else {
                    gridCtrl.bootstrapTable('updateByUniqueId', { id: data.Id, row: data });
                    app.ui.ButtonDone('#ProcessSpecSLALevelEdtFormSave');
                    modalCtrl.modal('hide');
                }
            }
            event.preventDefault();
        });

        $('#ProcessSpecSLALevelEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#ProcessSpecSLALevelEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecSLALevelEdtFormSaveContinue');
                AddRow(InputToObject(), 'Continue');
            }
            event.preventDefault();
        });

        $('#ProcessSpecSLALevelEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#ProcessSpecSLALevelEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecSLALevelEdtFormSaveCopy');
                AddRow(InputToObject(), 'Copy');
            }
            event.preventDefault();
        });

        $('#ProcessSpecSLALevelEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#ProcessSpecSLALevelEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecSLALevelEdtFormDuplicate');
                let data = InputToObject();
                data.Id = 0;
                //data. += ' duplicado';
                app.ui.ButtonDone('#ProcessSpecSLALevelEdtFormDuplicate');
                NewEditRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecSLALevelEdtFormDelete').click(function () {
            if (app.ui.IsValid('#ProcessSpecSLALevelEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecSLALevelEdtFormDelete');
                let data = InputToObject();
                app.ui.ButtonDone('#ProcessSpecSLALevelEdtFormDelete');
                DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecSLALevelEdtFormCancel').click(function () {
            event.preventDefault();
        });

        $('#MailForSLAExpiration').change(function () {
            switch (app.ui.GetDropDownNumericValue('#MailForSLAExpiration')) {
                case 1:
                    $('#MailForSLAExpirationCustom').val('{roles}');
                    $("#MailForSLAExpirationCustom").prop("disabled", true);
                    $("#MailForSLAExpirationTmpl").prop("disabled", false);
                    break;
                case 2:
                    $('#MailForSLAExpirationCustom').val('');
                    $("#MailForSLAExpirationCustom").prop("disabled", true);
                    $('#MailForSLAExpirationTmpl').val('1');
                    $("#MailForSLAExpirationTmpl").prop("disabled", true);
                    break;
                case 3:
                    $("#MailForSLAExpirationCustom").prop("disabled", false);
                    $("#MailForSLAExpirationTmpl").prop("disabled", false);
                    break;
            }
        });

    }

    function NewEditRow(row) {
        $('#ProcessSpecSLALevel_Id').val(row.Id);
        $('#SLAId').val(row.SLAId);
        app.ui.SetNumericValue('#SLATimeOut', row.SLATimeOut);
        $('#MailForSLAExpiration').val(row.MailForSLAExpiration).change();
        $('#MailForSLAExpirationCustom').val(row.MailForSLAExpirationCustom);
        $('#MailForSLAExpirationTmpl').val(row.MailForSLAExpirationTmpl);

        if (row.Id === 0) {
            //$('#').focus();
            $('#ProcessSpecSLALevelEdtFormSaveContinue').removeClass('d-none');
            $('#ProcessSpecSLALevelEdtFormSaveCopy').removeClass('d-none');
            $('#ProcessSpecSLALevelEdtFormDuplicate').addClass('d-none');
            $('#ProcessSpecSLALevelEdtFormDelete').addClass('d-none');
            $('#ProcessSpecSLALevelEdtFormSave').removeClass('d-none');
            $('#ProcessSpecSLALevelEdtFormCancel').removeClass('d-none');
        } else {
            //$('#').focus();
            $('#ProcessSpecSLALevelEdtFormSaveContinue').addClass('d-none');
            $('#ProcessSpecSLALevelEdtFormSaveCopy').addClass('d-none');
            $('#ProcessSpecSLALevelEdtFormDuplicate').removeClass('d-none');
            $('#ProcessSpecSLALevelEdtFormDelete').removeClass('d-none');
            $('#ProcessSpecSLALevelEdtFormSave').removeClass('d-none');
            $('#ProcessSpecSLALevelEdtFormCancel').removeClass('d-none');

        }
        modalCtrl.modal('show');
    }

    function AddRow(uidata, mode) {
        uidata.Id = -1 - gridCtrl.bootstrapTable('getData').length;
        gridCtrl.bootstrapTable('append', uidata);
        switch (mode) {
            case 'Save':
                app.ui.ButtonDone('#ProcessSpecSLALevelEdtFormSave');
                modalCtrl.modal('hide');
                break;
            case 'Continue':
                NewEditRow();
                app.ui.ButtonDone('#ProcessSpecSLALevelEdtFormSaveContinue');
                break;
            case 'Copy':
                uidata.RoleName += ' copia';
                NewEditRow(uidata);
                app.ui.ButtonDone('#ProcessSpecSLALevelEdtFormSaveCopy');
                break;
        }
    }

    function DeleteRow(uidata) {
        toastr.warning("Si está seguro de querer eliminar el nivel '" + uidata.SLATimeOut + "' del acuerdo haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    gridCtrl.bootstrapTable('removeByUniqueId', uidata.Id);
                    modalCtrl.modal('hide');
                }
            });
    }

    function InputToObject() {
        return {
            Id: Number($('#ProcessSpecSLALevel_Id').val()),
            SLAId: Number($('#SLAId').val()),
            SLATimeOut: app.ui.GetNumericValue('#SLATimeOut'),
            MailForSLAExpiration: app.ui.GetDropDownNumericValue('#MailForSLAExpiration'),
            MailForSLAExpirationDesc: app.ui.GetDropDownSelectedText('#MailForSLAExpiration'),
            MailForSLAExpirationCustom: app.ui.GetDropDownStringValue('#MailForSLAExpirationCustom'),
            MailForSLAExpirationTmpl: app.ui.GetDropDownNumericValue('#MailForSLAExpirationTmpl'),
            MailForSLAExpirationTmplDesc: app.ui.GetDropDownSelectedText('#MailForSLAExpirationTmpl'),
        };
    }

    function Config() {

        $('#ProcessSpecSLALevelGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'SLATimeOut',
                    title: 'Tiempo de atención (hrs)',
                    titleTooltip: '.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    align: 'center',

                }, {
                    field: 'MailForSLAExpirationDesc',
                    title: 'Notificar',
                    sortable: true,
                    halign: 'center',
                    align: 'center',
                }, {
                    field: 'MailForSLAExpirationCustom',
                    title: 'Personalización',
                    sortable: true,
                    halign: 'center',
                    visible: true
                }, {
                    field: 'MailForSLAExpirationTmplDesc',
                    title: 'Plantilla de correo',
                    sortable: true,
                    halign: 'center',
                    visible: true
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
                    titleTooltip: 'Acciones disponibles para un processspecslalevel',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'ProcessSpecSLALevelGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del processspecslalevel de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del processspecslalevel de la fila"> <i class="fa fa-close"></i> </button>';
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

        new AutoNumeric('#SLATimeOut', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });

        gridCtrl = $('#ProcessSpecSLALevelGridTbl');
        modalCtrl = $('#ProcessSpecSLALevelModal');

        app.ui.NumericValidators();
        $("#ProcessSpecSLALevelEdtForm").validate({
            errorPlacement: function (error, element) {
                let name = $(element).attr("name");
                let $obj = $("#" + name + "_validate");
                if ($obj.length) {
                    error.appendTo($obj);
                }
                else {
                    error.insertAfter(element);
                }
            },
            rules: {
                SLATimeOut: {
                    Numeric: true
                },
                MailForSLAExpiration: {
                    required: true
                },
                MailForSLAExpirationTmpl: {
                    required: true
                }
            },
            messages: {
                SLATimeOut: {
                    Numeric: 'Debe indicar el tiempo máximo para la atención'
                },
                MailForSLAExpiration: {
                    required: 'Debe indicar una opción en notificar'
                },
                MailForSLAExpirationTmpl: {
                    required: 'Debe indicar una plantilla de correo'
                },
                ProgressMode: {
                    required: 'Debe indicar el tipo'
                },
                MailServer: {
                    required: 'Debe indicar el servidor de correo'
                },
                ProcessStatus: {
                    required: 'Debe indicar el estado'
                }
            }

        });

        app.core.Lookups(['MailSendOptions.MailForSLAExpiration', 'MailTemplate.MailForSLAExpirationTmpl'], function () { });

    }

    return {
        Init: function () {
            Config();
            Events();
        },
        EditRow: function (row) {
            NewEditRow(row);
        },
        DeleteRow: function (row) {
            DeleteRow(row);
        },
        SetData: function (data) {
            gridCtrl.bootstrapTable('load', data !== undefined && data !== null ? data : []);
        },
        GetData: function () {
            return gridCtrl.bootstrapTable('getData');
        }
    };
})();

window.ProcessSpecSLALevelGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralProcessSpecSLALevel.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralProcessSpecSLALevel.EditRow(row);
        e.stopPropagation();
    }
};
