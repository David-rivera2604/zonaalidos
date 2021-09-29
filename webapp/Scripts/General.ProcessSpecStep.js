var app = app || {};

app.GeneralProcessSpecStep = (function () {

    function Refresh() {
        var filter = '';
        var flowIdFltVal = $('#FlowIdFlt').val();
        if (flowIdFltVal != null && flowIdFltVal != '' && flowIdFltVal != '0') {
            filter = filter + ':flowId=' + flowIdFltVal;
        }
        if (flowIdFltVal.length > 0) {
            $('#ProcessSpecStepGridTbl').bootstrapTable('showLoading');
            app.core.Get(app.setting.apipath + 'v1/ProcessSpecStep?filter=' + filter)
                .done(function (data, textStatus, jqXHR) {
                    $('#ProcessSpecStepGridTbl').bootstrapTable('load', data !== null ? data : []);
                }).always(function () {
                    $('#ProcessSpecStepGridTbl').bootstrapTable('hideLoading');
                });
        } else {
            $('#ProcessSpecStepGridTbl').bootstrapTable('load', []);
        }
    }

    function Init_Controls() {
        new AutoNumeric('#SLATimeOut', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#StepOrder', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '99999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#SLA', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '99999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });

        $('#FlowIdFlt').select2({ width: '100%', theme: 'bootstrap4' });

        $('#Roles').select2({ width: '100%', theme: 'bootstrap4' });

        $(".formbtn").appendTo("#GenericToolBar");
    }

    function Init_List() {
        $('#ProcessSpecStepGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            showColumns: false,
            detailView: true,
            onExpandRow: function (index, row, $detail) {
                $detail.append('<span class="detail-title">Tareas</span>');
                $detail.append('<div class="table-responsive" style="background-color: white; margin: 0px 0px 0px 10px; width: 99%!important;"><table style="font-size: 11px"></table></div>');

                Task_Init_List($detail.find('span'), $detail.find('table'), row);
            },
            columns: [
                {
                    field: 'FlowIdDesc',
                    title: 'Proceso',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Name',
                    title: 'Nombre',
                    sortable: true,
                    halign: 'center',
                    events: 'ProcessSpecStepGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos del process spec step">' + value + '</a>';
                    }
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'SLATimeOut',
                    title: 'SLA Time Out',
                    titleTooltip: 'Define el tiempo maximo en minutos para que el paso o estado se de por procesado.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                }, {
                    field: 'StepOrder',
                    title: 'Orden',
                    titleTooltip: 'Orden en que se procesan los pasos para un proceso.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'ProcessStatusDesc',
                    title: 'Estado',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'ProcessLabel',
                    title: 'Etiqueta',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'EnableComment',
                    title: 'Enable Comment',
                    titleTooltip: '.',
                    sortable: true,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.BooleanFormatter',
                    visible: false
                }, {
                    field: 'ProgressModeDesc',
                    title: 'Tipo',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'SLA',
                    title: 'SLA',
                    titleTooltip: '.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                }, {
                    field: 'MailServerDesc',
                    title: 'Servidor de correo',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailToContactDesc',
                    title: 'Contacto',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailToContactCustom',
                    title: 'Contacto',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailToContactTmplDesc',
                    title: 'Mai Tmpll to Contact',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailToStepResponsibleDesc',
                    title: 'Responsables',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailToStepResponsibleCustom',
                    title: 'Responsables',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailToStepResponsibleTmplDesc',
                    title: 'Mail to Step Responsible Tmpl',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailForSLAExpirationDesc',
                    title: 'Mail for SLA Expiration',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailForSLAExpirationCustom',
                    title: 'Mail for SLA Expiration',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'MailForSLAExpirationTmplDesc',
                    title: 'Mail for SLAE xpiration Tmpl',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'PreScript',
                    title: 'Pre Script',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'PostScript',
                    title: 'Post Script',
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
                    titleTooltip: 'Acciones disponibles para un process spec step',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'ProcessSpecStepGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del process spec step de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del process spec step de la fila"> <i class="fa fa-close"></i> </button>';
                    },
                    cellStyle: function (value, row, index) {
                        return {
                            css: {
                                'white-space': 'nowrap',
                                'vertical-align': 'top'
                            }
                        }
                    }
                }],
            icons: {
                paginationSwitchDown: 'fa-caret-square-o-down',
                paginationSwitchUp: 'fa-caret-square-o-up',
                refresh: 'fa-refresh',
                toggleOff: 'fa-toggle-off',
                toggleOn: 'fa-toggle-on',
                columns: 'fa-th-list',
                fullscreen: 'fa-arrows-alt',
                detailOpen: 'fa-angle-double-right',
                detailClose: 'fa-angle-double-down',
                export: 'fa-download'
            }
        });
    }

    function Event_Controls() {

        $('.tool-audit').on('click', function (e) {
            app.ui.components.ShowModalChangeSet(1301);
        });

        $('.tool-new').on('click', function (e) {
            app.GeneralProcessSpecStep.New();
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#ProcessSpecStepSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#ProcessSpecStepEdtFormSave').click(function () {
            if (app.ui.IsValid('#ProcessSpecStepEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecStepEdtFormSave');
                var data = MapInputToObject();
                if (data.Id === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecStepEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#ProcessSpecStepEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecStepEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#ProcessSpecStepEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#ProcessSpecStepEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecStepEdtFormSaveCopy');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#ProcessSpecStepEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#ProcessSpecStepEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecStepEdtFormDuplicate');
                var data = MapInputToObject();
                data.Id = 0;
                data.Name += ' duplicado';
                app.ui.ButtonDone('#ProcessSpecStepEdtFormDuplicate');
                app.GeneralProcessSpecStep.EditRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecStepEdtFormDelete').click(function () {
            if (app.ui.IsValid('#ProcessSpecStepEdtForm', false)) {
                app.ui.ButtonDoing('#ProcessSpecStepEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#ProcessSpecStepEdtFormDelete');
                app.GeneralProcessSpecStep.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#ProcessSpecStepEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });


        $('#MailToContact').change(function () {
            switch (app.ui.GetDropDownNumericValue('#MailToContact')) {
                case 1:
                    $('#MailToContactCustom').val('');
                    $("#MailToContactCustom").prop("disabled", true);
                    $("#MailToContactTmpl").prop("disabled", false);
                    break;
                case 2:
                    $('#MailToContactCustom').val('');
                    $("#MailToContactCustom").prop("disabled", true);
                    $('#MailToContactTmpl').val('1');
                    $("#MailToContactTmpl").prop("disabled", true);
                    break;
                case 3:
                    $("#MailToContactCustom").prop("disabled", false);
                    $("#MailToContactTmpl").prop("disabled", false);
                    break;
            }
        });

        $('#MailToStepResponsible').change(function () {
            switch (app.ui.GetDropDownNumericValue('#MailToStepResponsible')) {
                case 1:
                    $('#MailToStepResponsibleCustom').val('');
                    $("#MailToStepResponsibleCustom").prop("disabled", true);
                    $("#MailToStepResponsibleTmpl").prop("disabled", false);
                    break;
                case 2:
                    $('#MailToStepResponsibleCustom').val('');
                    $("#MailToStepResponsibleCustom").prop("disabled", true);
                    $('#MailToStepResponsibleTmpl').val('1');
                    $("#MailToStepResponsibleTmpl").prop("disabled", true);
                    break;
                case 3:
                    $("#MailToStepResponsibleCustom").prop("disabled", false);
                    $('#MailToStepResponsibleTmpl').val('1');
                    $("#MailToStepResponsibleTmpl").prop("disabled", false);
                    break;
            }
        });

        $('#MailForSLAExpiration').change(function () {
            switch (app.ui.GetDropDownNumericValue('#MailForSLAExpiration')) {
                case 1:
                    $('#MailForSLAExpirationCustom').val('');
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
                    $('#MailForSLAExpirationTmpl').val('1');
                    $("#MailForSLAExpirationTmpl").prop("disabled", false);
                    break;
            }
        });

        $('#FlowIdFlt').on('select2:select', function (e) {
            Refresh();
        });
        $('#SLATimeOut').change(function () {
            if (app.ui.GetNumericValue('#SLATimeOut') > 0)
                $('.sla-notify-visible').removeClass('d-none');
            else {
                $('.sla-notify-visible').addClass('d-none');
            }
        });
        $('#Roles').change(function () {
            if (app.ui.GetDropDownMultiValues('Roles').length > 0)
                $('.role-notify-visible').removeClass('d-none');
            else {
                $('.role-notify-visible').addClass('d-none');
            }
        });
    };

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/ProcessSpecStep', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El process spec step '" + uidata.Name + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralProcessSpecStep.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralProcessSpecStep.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#ProcessSpecStepEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#ProcessSpecStepEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#ProcessSpecStepEdtFormSaveCopy');
                        break;
                }
            });
    };

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/ProcessSpecStep/' + uidata.Id, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El process spec step '" + uidata.Name + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#ProcessSpecStepEdtFormSave');
            });
    };

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el process spec step '" + uidata.Name + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/ProcessSpecStep/' + uidata.Id)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El process spec step '" + uidata.Name + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    };

    function Init_Lookups() {
        app.core.Lookups(['Process.FlowId', 'Process.FlowIdFlt', 'ProcessStatus.ProcessStatus', 'ProgressMode.ProgressMode', 'MailServer.MailServer', 'MailSendOptions.MailToContact', 'MailTemplate.MailToContactTmpl', 'MailSendOptions.MailToStepResponsible', 'MailTemplate.MailToStepResponsibleTmpl', 'MailSendOptions.MailForSLAExpiration', 'MailTemplate.MailForSLAExpirationTmpl'], Dynamic_Event_Controls);
        // Dependencies
    };

    function Dynamic_Event_Controls() {
        $('#FlowIdFlt').select2({ width: '100%', theme: 'bootstrap4' });
        app.core.LoadLookup(app.setting.apipath + 'v1/RoleMember/Lookup', 'Roles');
    };

    function MapInputToObject() {
        var data = {
            Id: parseInt(0 + $('#Id').val(), 10),
            FlowId: app.ui.GetDropDownNumericValue('#FlowId'),
            Name: $('#Name').val(),
            Description: $('#Description').val(),
            Roles: app.ui.GetDropDownMultiValues('Roles'),
            SLATimeOut: app.ui.GetNumericValue('#SLATimeOut'),
            StepOrder: app.ui.GetNumericValue('#StepOrder'),
            ProcessStatus: $('#ProcessStatus').val(),
            ProcessLabel: $('#ProcessLabel').val(),
            EnableComment: app.ui.GetRadioNumericValue('EnableComment'),
            ProgressMode: $('#ProgressMode').val(),
            SLA: app.ui.GetNumericValue('#SLA'),
            MailServer: $('#MailServer').val(),
            MailToContact: $('#MailToContact').val(),
            MailToContactCustom: $('#MailToContactCustom').val(),
            MailToContactTmpl: $('#MailToContactTmpl').val(),
            MailToStepResponsible: $('#MailToStepResponsible').val(),
            MailToStepResponsibleCustom: $('#MailToStepResponsibleCustom').val(),
            MailToStepResponsibleTmpl: $('#MailToStepResponsibleTmpl').val(),
            MailForSLAExpiration: $('#MailForSLAExpiration').val(),
            MailForSLAExpirationCustom: $('#MailForSLAExpirationCustom').val(),
            MailForSLAExpirationTmpl: $('#MailForSLAExpirationTmpl').val(),
            PreScript: $('#PreScript').val(),
            PostScript: $('#PostScript').val()

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#Id').val(data.Id);
        $('#FlowId').val(data.FlowId);
        $('#Name').val(data.Name);
        $('#Description').val(data.Description);
        app.ui.SetDropDownMultiValues('Roles', data.Roles);
        $('#Roles').change();
        app.ui.SetNumericValue('#SLATimeOut', data.SLATimeOut);
        app.ui.SetNumericValue('#StepOrder', data.StepOrder);
        $('#ProcessStatus').val(data.ProcessStatus);
        $('#ProcessLabel').val(data.ProcessLabel);
        $('#EnableComment').prop('checked', data.EnableComment);
        app.ui.SetRadioNumericValue('EnableComment', data.EnableComment);
        $('#ProgressMode').val(data.ProgressMode);
        app.ui.SetNumericValue('#SLA', data.SLA);
        $('#SLA').change();
        $('#MailServer').val(data.MailServer);

        $('#MailToContactCustom').val(data.MailToContactCustom);
        $('#MailToContactTmpl').val(data.MailToContactTmpl);
        $('#MailToContact').val(data.MailToContact).change();

        $('#MailToStepResponsibleCustom').val(data.MailToStepResponsibleCustom);
        $('#MailToStepResponsibleTmpl').val(data.MailToStepResponsibleTmpl);
        $('#MailToStepResponsible').val(data.MailToStepResponsible).change();

        $('#MailForSLAExpirationCustom').val(data.MailForSLAExpirationCustom);
        $('#MailForSLAExpirationTmpl').val(data.MailForSLAExpirationTmpl);
        $('#MailForSLAExpiration').val(data.MailForSLAExpiration).change();

        $('#PreScript').val(data.PreScript);
        $('#PostScript').val(data.PostScript);

    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#ProcessSpecStepEdtForm").validate({
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
                FlowId: {
                    required: true
                },
                Name: {
                    required: true
                },
                StepOrder: {
                    required: true
                },
                ProgressMode: {
                    required: true
                },
                MailServer: {
                    required: true
                }
            },
            messages: {
                FlowId: {
                    required: 'Debe indicar el proceso'
                },
                Name: {
                    required: 'Debe indicar el nombre'
                },
                StepOrder: {
                    required: 'Debe indicar el orden'
                },
                ProgressMode: {
                    required: 'Debe indicar el tipo'
                },
                MailServer: {
                    required: 'Debe indicar el servidor de correo'
                }
            }

        });
    };

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#ProcessSpecStepGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#ProcessSpecStepEdt').removeClass('d-none');

        if (row.Id === 0) {
            MapObjectToInput(row);
            $('#Name').focus();
            $('#ProcessSpecStepEdtFormSaveContinue').removeClass('d-none');
            $('#ProcessSpecStepEdtFormSaveCopy').removeClass('d-none');
            $('#ProcessSpecStepEdtFormDuplicate').addClass('d-none');
            $('#ProcessSpecStepEdtFormDelete').addClass('d-none');
            $('#ProcessSpecStepEdtFormSave').removeClass('d-none');
            $('#ProcessSpecStepEdtFormCancel').removeClass('d-none');
        } else {
            $('.ibox-content').toggleClass('sk-loading');

            app.core.Get(app.setting.apipath + 'v1/ProcessSpecStep/' + row.Id)
                .done(function (data, textStatus, jqXHR) {
                    MapObjectToInput(data);
                    $('#Name').focus();
                    $('#ProcessSpecStepEdtFormSaveContinue').addClass('d-none');
                    $('#ProcessSpecStepEdtFormSaveCopy').addClass('d-none');
                    $('#ProcessSpecStepEdtFormDuplicate').removeClass('d-none');
                    $('#ProcessSpecStepEdtFormDelete').removeClass('d-none');
                    $('#ProcessSpecStepEdtFormSave').removeClass('d-none');
                    $('#ProcessSpecStepEdtFormCancel').removeClass('d-none');
                }).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });

        }
    };

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').removeClass('d-none');
        $('#ProcessSpecStepGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#ProcessSpecStepEdt').addClass('d-none');
        $('.formbtn').addClass('d-none');
    };

    function Task_Init_List(title, gridTbl, parentRow) {
        gridTbl.bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'TaskOrder',
                    title: 'Orden',
                    titleTooltip: 'Orden en que se procesan la tarea.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'Name',
                    title: 'Name',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'SLATimeOut',
                    title: 'SLA Time Out',
                    titleTooltip: 'Define el tiempo maximo en minutos para que el paso o estado se de por procesado.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                }, {
                    field: 'IsRequired',
                    title: 'Is Required',
                    titleTooltip: '.',
                    sortable: true,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.BooleanFormatter',
                    visible: false
                }, {
                    field: 'IsSelected',
                    title: 'Is Selected',
                    titleTooltip: '.',
                    sortable: true,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.BooleanFormatter',
                    visible: false
                }, {
                    field: 'TypeDesc',
                    title: 'Tipo',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'Action',
                    title: 'Acción',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'SubStatus',
                    title: 'Estado',
                    titleTooltip: '.',
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                }, {
                    field: 'SubLabel',
                    title: 'Etiqueta',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'PreScript',
                    title: 'Pre Script',
                    sortable: true,
                    halign: 'center',
                    visible: false
                }, {
                    field: 'PostScript',
                    title: 'Post Script',
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
                }]
        });
        gridTbl.bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/ProcessSpecTask?filter=:flowId=' + parentRow.FlowId + ':stepId=' + parentRow.Id)
            .done(function (data, textStatus, jqXHR) {
                gridTbl.bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                gridTbl.bootstrapTable('hideLoading');
            });
    }

    return {
        Init: function () {
            Init_List();
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Setup_Validations();
            var _id = app.core.URLNumericValue('id');
            if (_id !== 0) {
                $("body").toggleClass("mini-navbar");
                EditMode({ Id: _id });
            }
            else {
                Refresh();
            }
        },
        New: function (row) {
            let newRow = { Id: 0, FlowId: 0, Name: null, Description: null, SLATimeOut: 0, StepOrder: 10, ProcessStatus: 0, ProcessLabel: null, EnableComment: false, ProgressMode: 1, SLA: 0, MailServer: 1, MailToContact: 1, MailToContactCustom: null, MailToContactTmpl: 1, MailToStepResponsible: 1, MailToStepResponsibleCustom: null, MailToStepResponsibleTmpl: 1, MailForSLAExpiration: 1, MailForSLAExpirationCustom: null, MailForSLAExpirationTmpl: 1, PreScript: null, PostScript: null }
            if (row !== undefined) {
                row.Id = 0;
                newRow = row;
            }
            if (newRow.FlowId === 0 && $('#FlowIdFlt').val().length > 0) {
                newRow.FlowId = $('#FlowIdFlt').val()[0];
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

window.ProcessSpecStepGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralProcessSpecStep.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralProcessSpecStep.EditRow(row);
        e.stopPropagation();
    }
};
