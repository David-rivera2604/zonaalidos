var app = app || {};

app.SiniestrosPanel = (function () {

    var siniestroRow = null;
    var expedienteRow = null;
    var tasks = [];
    var entityId = null;
    var caseId = null;
    var complement = null;

    var attachments = [];

    async function RefreshSiniestros() {
        CleanExpedientes();
        CleanProcess();
        siniestroRow = null;
        $('#SiniestrosGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + `v1/datasource/json?id=330&sequence=1&url=`)
            .done(function (data, textStatus, jqXHR) {
                $('#SiniestrosGridTbl').bootstrapTable('load', data !== null ? data : []);
                if (data !== null && data.length > 0) {
                    siniestroRow = data[0];
                    $('#SiniestrosGridTbl').bootstrapTable('filterBy', { TIP_EST_SINI: ['P'] });
                    $("#Expedientes").removeClass("d-none");
                    $("#flow").removeClass("d-none");
                    $('#SiniestrosGridTbl').bootstrapTable('checkBy', { field: 'NUM_SINI', values: [data[0].NUM_SINI] })
                    ResizeParent();
                    RefreshExpedientes();
                } else {
                    siniestroRow = null;
                }
            }).always(function () {
                $('#SiniestrosGridTbl').bootstrapTable('hideLoading');
            });
    }

    async function LoadRelato(num_sini) {
        app.core.Get(app.setting.apipath + `v1/datasource/json?id=330&sequence=3&url=num_sini=${num_sini}`)
            .done(function (data, textStatus, jqXHR) {
                if (data !== null && data.length > 0) {
                    $('#relato' + num_sini).html(app.ui.StringCapitalizeFormatter(data[0].TXT_RELATO));

                } else {
                    $('#relato' + num_sini).html('');
                }
                ResizeParent();
            });
    }

    async function CleanExpedientes() {
        $('#ExpedientesGridTbl').bootstrapTable('load', []);
    }

    async function RefreshExpedientes() {
        if (siniestroRow === null) {
            CleanExpedientes();
            expedienteRow = null;
            return;
        }
        $('#exnum_sin').html(siniestroRow.NUM_SINI);
        $('#ExpedientesGridTbl').bootstrapTable('showLoading');
        CleanProcess();
        expedienteRow = null;
        app.core.Get(app.setting.apipath + `v1/datasource/json?id=330&sequence=2&url=id=330:num_sini=${siniestroRow.NUM_SINI}`)
            .done(function (data, textStatus, jqXHR) {
                $('#ExpedientesGridTbl').bootstrapTable('load', data !== null ? data : []);
                if (data !== null && data.length > 0) {
                    expedienteRow = data[0];
                    $('#ExpedientesGridTbl').bootstrapTable('checkBy', { field: 'NUM_EXP', values: [expedienteRow.NUM_EXP] })
                } else {
                    expedienteRow = null;
                }
                ResizeParent();
                RefreshProcess();
            }).always(function () {
                $('#ExpedientesGridTbl').bootstrapTable('hideLoading');
            });

    }

    async function CleanProcess() {
        $(".progress-bar").width('0%');
        $(".progress-bar").prop('title', '0%');
        $('#ProcessGridTbl').bootstrapTable('load', []);
        $('#ChangeStage').addClass('d-none');
        tasks = [];
    }

    async function RefreshProcess() {
        if (siniestroRow === null || expedienteRow === null) {
            CleanProcess();
            return;
        }

        entityId = (siniestroRow.NUM_SINI * 100) + parseInt(expedienteRow.NUM_EXP, 10);
        $('#exp_num').html(expedienteRow.NUM_EXP);
        $(".liquidado").addClass("d-none");
        $(".t38").addClass("d-none");
        $(".t72").addClass("d-none");
        $(".t93").addClass("d-none");
        $(".t58").addClass("d-none");
        $('#ChangeStage').addClass('d-none');
        $('#VisualizationsEdtFormSave').prop("disabled", true);
        $('#ProcessGridTbl').bootstrapTable('showLoading');
        let flowId = 1; // NS temporal
        if (expedienteRow.TIP_EXP === 'PPC' ||
            expedienteRow.TIP_EXP === 'PTC' ||
            expedienteRow.TIP_EXP === 'RAC' ||
            expedienteRow.TIP_EXP === 'RTC' ||
            expedienteRow.TIP_EXP === 'RSC' ||
            expedienteRow.TIP_EXP === 'PRC' ||
            expedienteRow.TIP_EXP === 'CRC') {
            flowId = 1;
        }
        let clientName = siniestroRow.NOM_ASEG;
        if (siniestroRow.APE_ASEG != null) {
            clientName += ' ' + siniestroRow.APE_ASEG;
        }
        app.core.Post(app.setting.apipath + 'v1/Process/Instance/Automatic',
            JSON.stringify(
                {
                    FlowId: flowId,
                    EntityType: 9500,
                    EntityId: entityId,
                    ContactName: clientName,
                    ContactEmail: siniestroRow.EMAIL_ASEG,
                    Reference1: siniestroRow.NUM_SINI,
                    Reference2: expedienteRow.TIP_EXP,
                    Reference3: siniestroRow.NUM_POLIZA,
                    Reference4: siniestroRow.MATRICULA,
                    Title: 'Siniestro #' + siniestroRow.NUM_SINI + ", expediente " + expedienteRow.TIP_EXP
                }))
            .done(function (data, textStatus, jqXHR) {
                if (data.Steps) {
                    caseId = data.CaseId;

                    RefreshComplement();

                    $('#ProcessGridTbl').bootstrapTable('load', data.Steps);
                    $('.tnotify').addClass('d-none');

                    if (data.Tasks.length > 0) {
                        $('#tasks').empty();
                        $('#Annotation').val('');
                        $('#VisualizationsEdtFormSave').prop("disabled", true);
                        selectedOptions = $('#tasks');
                        $.each(data.Tasks, function () {
                            selectedOptions.append(
                                '<div class="custom-control custom-radio" title="' + this['Description'] + '">' +
                                '<input type="radio" class="custom-control-input" id="task_' + this['ActivityId'] + '" name="task" value="' + this['ActivityId'] + '" onchange="app.SiniestrosPanel.Enable();">' +
                                '<label class="custom-control-label" for="task_' + this['ActivityId'] + '">' + this['Name'] + '</label>' +
                                '</div>');
                        });
                        $('#ChangeStage').removeClass('d-none');
                        //$('#entry').removeClass('d-none');
                        $('fieldset').prop("disabled", false);
                        tasks = data.Tasks;
                    }
                    else {
                        $('#ChangeStage').addClass('d-none');
                    }

                    $(".progress-bar").width(data.Progress + '%');
                    $(".progress-bar").prop('title', data.Progress + '%');
                    ResizeParent();
                } else {
                    $('#ProcessGridTbl').bootstrapTable('load', []);
                }
            }).always(function () {
                $('#ProcessGridTbl').bootstrapTable('hideLoading');
            });
    }

    async function RefreshComplement() {
        app.core.Get(app.setting.apipath + `v1/Process/Case/Complement/${caseId}`)
            .done(function (data, textStatus, jqXHR) {
                let html = [], complSub = [], compl = [];

                complement = data || {
                    Fee: null, Compensation: null, Deductible: null, SpareParts: null, ManPower: null, Workshop: -1, ManPowerInvoice: '', SparePartsInvoice: '', SettlementDate: '0001-01-01T00:00:00', AppointmentDate: '0001-01-01T00:00:00', AppointmentTime: '', AssignedAdvisor: 0, ReportDate: '0001-01-01T00:00:00', RepairTotalAmount: 0, RepairManPower: 0, RepairSpareParts: 0,
                    SetSpaFee: 0,
                    SetSpaCompensation: 0,
                    SetSpaDeductible: 0,
                    SetSpaSpareParts: 0,
                    SetSpaManPower: 0,
                    SetSpaManPowerInvoice: null,
                    SetSpaSparePartsInvoice: null,
                    SetSpaSettlementDate: '0001-01-01T00:00:00'
                };

                app.ui.SetNumericValue('#Fee', complement.Fee);
                app.ui.SetNumericValue('#Compensation', complement.Compensation);
                app.ui.SetNumericValue('#Deductible', complement.Deductible);
                app.ui.SetNumericValue('#SpareParts', complement.SpareParts);
                app.ui.SetNumericValue('#ManPower', complement.ManPower);
                $('ManPowerInvoice').val(complement.ManPowerInvoice);
                $('SparePartsInvoice').val(complement.SparePartsInvoice);
                app.ui.SetDateValue('#SettlementDate', complement.SettlementDate);
                app.ui.SetDateValue('#AppointmentDate', complement.AppointmentDate);
                $('#AppointmentTime').val(complement.AppointmentTime);
                $('#AssignedAdvisor').val(complement.AssignedAdvisor);
                $('#Workshop').val(complement.Workshop);

                app.ui.SetDateValue('#ReportDate', complement.ReportDate);
                app.ui.SetNumericValue('#RepairTotalAmount', complement.RepairTotalAmount);
                app.ui.SetNumericValue('#RepairManPower', complement.RepairManPower);
                app.ui.SetNumericValue('#RepairSpareParts', complement.RepairSpareParts);

                app.ui.SetNumericValue('#SetSpaFee', complement.SetSpaFee);
                app.ui.SetNumericValue('#SetSpaCompensation', complement.SetSpaCompensation);
                app.ui.SetNumericValue('#SetSpaDeductible', complement.SetSpaDeductible);
                app.ui.SetNumericValue('#SetSpaSpareParts', complement.SetSpaSpareParts);
                app.ui.SetNumericValue('#SetSpaManPower', complement.SetSpaManPower);
                $('SetSpaManPowerInvoice').val(complement.SetSpaManPowerInvoice);
                $('SetSpaSparePartsInvoice').val(complement.SetSpaSparePartsInvoice);
                app.ui.SetDateValue('#SetSpaSettlementDate', complement.SetSpaSettlementDate);

                compl = [];
                if (complement.Fee > 0) {
                    compl.push({ key: 'Honorarios', value: app.ui.NumericValueFormat(complement.Fee, 2) });
                }
                if (complement.Compensation > 0) {
                    compl.push({ key: 'Indemnización', value: app.ui.NumericValueFormat(complement.Compensation, 2) });
                }
                if (complement.Deductible > 0) {
                    compl.push({ key: 'Deducible', value: app.ui.NumericValueFormat(complement.Deductible, 2) });
                }
                if (complement.SpareParts > 0) {
                    compl.push({ key: 'Repuestos', value: app.ui.NumericValueFormat(complement.SpareParts, 2) });
                }
                if (complement.ManPower > 0) {
                    compl.push({ key: 'Mano de obra', value: app.ui.NumericValueFormat(complement.ManPower, 2) });
                }
                if (complement.ManPowerInvoice != '') {
                    compl.push({ key: 'Fact. Mano de obra', value: complement.ManPowerInvoice });
                }
                if (complement.SparePartsInvoice != '') {
                    compl.push({ key: 'Fact. Repuestos', value: complement.SparePartsInvoice });
                }
                if (complement.SettlementDate != '0001-01-01T00:00:00') {
                    compl.push({ key: 'Fecha', value: moment(complement.SettlementDate).format('DD/MM/YYYY') });
                }
                if (compl.length > 0) {
                    html = [];
                    html.push('<div class="row">');
                    compl.forEach(function (item) {
                        html.push('<div class="col-lg-6">');
                        html.push(`<dl class="row mb-0"><div class="col-sm-6 text-sm-right"><dt>${item.key}:</dt></div><div class="col-sm-6 text-sm-left"><dd class="mb-1">${item.value}</dd></div></dl>`);
                        html.push('</div>');
                    });
                    html.push('</div>');
                    $('#compl_37').html(html.join(''));
                }

                if (complement.Workshop > 0 || complement.AppointmentDate != '0001-01-01T00:00:00' || complement.AppointmentTime != '' || complement.AssignedAdvisor > 0) {
                    complSub = [];
                    html = [];
                    if (complement.Workshop > 0) {
                        complSub.push({ key: 'Taller', value: complement.WorkshopDesc });
                    }
                    if (complement.AppointmentDate != '0001-01-01T00:00:00') {
                        complSub.push({ key: 'Fecha', value: moment(complement.AppointmentDate).format('DD/MM/YYYY') });
                    }
                    if (complement.AppointmentTime != '') {
                        complSub.push({ key: 'Hora', value: complement.AppointmentTime });
                    }
                    if (complement.AssignedAdvisor > 0) {
                        complSub.push({ key: 'Asesor', value: $("#AssignedAdvisor option:selected").text() });
                    }

                    html.push('<div class="row">');
                    complSub.forEach(function (item) {
                        html.push('<div class="col-lg-12">');
                        html.push(`<dl class="row mb-0"><div class="col-sm-6 text-sm-right"><dt>${item.key}:</dt></div><div class="col-sm-6 text-sm-left"><dd class="mb-1">${item.value}</dd></div></dl>`);
                        html.push('</div>');
                    });
                    html.push('</div>');
                    $('#compl_22').html(html.join(''));
                }

                if (complement.ReportDate != '0001-01-01T00:00:00' || complement.RepairTotalAmount > 0 || complement.RepairManPower > 0 || complement.RepairSpareParts > 0) {
                    html = [];
                    complSub = [];
                    if (complement.ReportDate != '0001-01-01T00:00:00') {
                        complSub.push({ key: 'Fecha', value: moment(complement.ReportDate).format('DD/MM/YYYY') });
                    }
                    if (complement.RepairTotalAmount > 0) {
                        complSub.push({ key: 'Monto total', value: complement.RepairTotalAmount });
                    }
                    if (complement.RepairManPower > 0) {
                        complSub.push({ key: 'Mano de obra', value: complement.RepairManPower });
                    }
                    if (complement.RepairSpareParts > 0) {
                        complSub.push({ key: 'Repuestos', value: complement.RepairSpareParts });
                    }
                    html.push('<div class="row">');
                    complSub.forEach(function (item) {
                        html.push('<div class="col-lg-12">');
                        html.push(`<dl class="row mb-0"><div class="col-sm-6 text-sm-right"><dt>${item.key}:</dt></div><div class="col-sm-6 text-sm-left"><dd class="mb-1">${item.value}</dd></div></dl>`);
                        html.push('</div>');
                    });
                    html.push('</div>');
                    $('#compl_44').html(html.join(''));



                }
                compl = [];
                if (complement.SetSpaFee > 0) {
                    compl.push({ key: 'Honorarios', value: app.ui.NumericValueFormat(complement.SetSpaFee, 2) });
                }
                if (complement.SetSpaCompensation > 0) {
                    compl.push({ key: 'Indemnización', value: app.ui.NumericValueFormat(complement.SetSpaCompensation, 2) });
                }
                if (complement.SetSpaDeductible > 0) {
                    compl.push({ key: 'Deducible', value: app.ui.NumericValueFormat(complement.SetSpaDeductible, 2) });
                }
                if (complement.SetSpaSpareParts > 0) {
                    compl.push({ key: 'Repuestos', value: app.ui.NumericValueFormat(complement.SetSpaSpareParts, 2) });
                }
                if (complement.SetSpaManPower > 0) {
                    compl.push({ key: 'Mano de obra', value: app.ui.NumericValueFormat(complement.SetSpaManPower, 2) });
                }
                if (complement.SetSpaManPowerInvoice != null && complement.SetSpaManPowerInvoice != '') {
                    compl.push({ key: 'Fact. Mano de obra', value: complement.SetSpaManPowerInvoice });
                }
                if (complement.SetSpaSparePartsInvoice != null &&complement.SetSpaSparePartsInvoice != '') {
                    compl.push({ key: 'Fact. Repuestos', value: complement.SetSpaSparePartsInvoice });
                }
                if (complement.SetSpaSettlementDate != '0001-01-01T00:00:00') {
                    compl.push({ key: 'Fecha', value: moment(complement.SetSpaSettlementDate).format('DD/MM/YYYY') });
                }
                if (compl.length > 0) {
                    html = [];
                    html.push('<div class="row">');
                    compl.forEach(function (item) {
                        html.push('<div class="col-lg-6">');
                        html.push(`<dl class="row mb-0"><div class="col-sm-6 text-sm-right"><dt>${item.key}:</dt></div><div class="col-sm-6 text-sm-left"><dd class="mb-1">${item.value}</dd></div></dl>`);
                        html.push('</div>');
                    });
                    html.push('</div>');
                    $('#compl_58').html(html.join(''));
                }
            });
    };

    function TaskChecked(activityId, comment, notify) {
        app.core.Put(app.setting.apipath + `v1/Process/Task/Checked/Entity/9500/${entityId}`,
            JSON.stringify({
                ActivityId: activityId,
                Comment: comment,
                Notify: notify,
                Attachments: attachments
            }))
            .done(function (data, textStatus, jqXHR) {
                RefreshProcess();
            }).always(function () {
                app.ui.ButtonDone('#VisualizationsEdtFormSave', false);
                $('.tag-list').html('');
                attachments = [];
            });
    }

    function CaseComplement() {
        app.core.Put(app.setting.apipath + `v1/Process/Case/Complement/${caseId}`,
            JSON.stringify({
                Fee: app.ui.GetNumericValue('#Fee'),
                Compensation: app.ui.GetNumericValue('#Compensation'),
                Deductible: app.ui.GetNumericValue('#Deductible'),
                SpareParts: app.ui.GetNumericValue('#SpareParts'),
                ManPower: app.ui.GetNumericValue('#ManPower'),
                Workshop: app.ui.GetDropDownNumericValue('#Workshop'),
                ManPowerInvoice: $('#ManPowerInvoice').val(),
                SparePartsInvoice: $('#SparePartsInvoice').val(),
                SettlementDate: app.ui.GetDateValue('#SettlementDate'),
                AppointmentDate: app.ui.GetDateValue('#AppointmentDate'),
                AppointmentTime: $('#AppointmentTime').val(),
                AssignedAdvisor: $('#AssignedAdvisor').val(),
                ReportDate: app.ui.GetDateValue('#ReportDate'),
                RepairTotalAmount: app.ui.GetNumericValue('#RepairTotalAmount'),
                RepairManPower: app.ui.GetNumericValue('#RepairManPower'),
                RepairSpareParts: app.ui.GetNumericValue('#RepairSpareParts'),
                SetSpaFee: app.ui.GetNumericValue('#SetSpaFee'),
                SetSpaCompensation: app.ui.GetNumericValue('#SetSpaCompensation'),
                SetSpaDeductible: app.ui.GetNumericValue('#SetSpaDeductible'),
                SetSpaSpareParts: app.ui.GetNumericValue('#SetSpaSpareParts'),
                SetSpaManPower: app.ui.GetNumericValue('#SetSpaManPower'),
                SetSpaManPowerInvoice: $('#SetSpaManPowerInvoice').val(),
                SetSpaSparePartsInvoice: $('#SetSpaSparePartsInvoice').val(),
                SetSpaSettlementDate: app.ui.GetDateValue('#SetSpaSettlementDate')
            }))
            .done(function (data, textStatus, jqXHR) {
            });
    }

    function ResizeParent() {
        try {
            window.parent.resizeIframe(document.getElementById("iframe"));
        }
        catch (e) {
        }
    }

    function Init_List_Siniestros() {
        $('#SiniestrosGridTbl').bootstrapTable({
            uniqueId: 'NUM_SINI',
            toolbar: '#toolbar',
            toolbarAlign: 'right',
            classes: 'table table-bordered table-hover table-index',
            buttonsClass: 'outline btn-default',
            pagination: true,
            search: true,
            showRefresh: true,
            smartDisplay: true,
            clickToSelect: true,
            singleSelect: true,
            searchAlign: 'left',
            detailView: true,
            pageList: [6, 10, 25, 50, 100],
            pageSize: 6,
            ajax: 'app.SiniestrosPanel.Refresh',
            detailFormatter: function (index, row) {
                var html = [];
                html.push('<div class="row">');
                html.push('<div class="col-lg-6">');
                [
                    { key: 'Ramo', value: row.NOM_RAMO },
                    { key: 'Descripción del riesgo', value: row.NOM_RIESGO }
                ].forEach(function (item) {
                    html.push(`<dl class="row mb-0"><div class="col-sm-4 text-sm-right"><dt>${item.key}:</dt></div><div class="col-sm-8 text-sm-left"><dd class="mb-1">${item.value}</dd></div></dl>`);
                });

                html.push('</div>');
                html.push('<div class="col-lg-6">');
                [
                    { key: 'Tomando', value: `${row.TIP_DOCUM_TOMADOR} ${row.COD_DOCUM_TOMADOR} - ${app.ui.StringCapitalizeFormatter(row.NOM_TOMADOR)} ${app.ui.StringCapitalizeFormatter(row.APE_TOMADOR)}` },
                    { key: 'Asegurado', value: `${row.TIP_DOCUM_ASEG} ${row.COD_DOCUM_ASEG} - ${app.ui.StringCapitalizeFormatter(row.NOM_ASEG)} ${app.ui.StringCapitalizeFormatter(row.APE_ASEG)}` },
                    { key: 'Contacto', value: `${row.TIP_DOCUM_CONTACTO} ${row.COD_DOCUM_ASEG} - ${app.ui.StringCapitalizeFormatter(row.NOM_CONTACTO)} ${app.ui.StringCapitalizeFormatter(row.APE_CONTACTO)}` }
                ].forEach(function (item) {
                    html.push(`<dl class="row mb-0"><div class="col-sm-4 text-sm-right"><dt>${item.key}:</dt></div><div class="col-sm-8 text-sm-left"><dd class="mb-1">${item.value}</dd></div></dl>`);
                });
                html.push('</div>');
                html.push('<div class="col-lg-12">');
                html.push(`<dl class="row mb-0"><div class="col-sm-4 text-sm-right"><dt>Relato:</dt></div><div class="col-sm-8 text-sm-left"><dd class="mb-1"><span id="relato${row.NUM_SINI}">Buscando información del relato para el siniestro ${row.NUM_SINI}...<span></dd></div></dl>`);
                html.push('</div>');
                html.push('</div>');
                LoadRelato(row.NUM_SINI);

                if (row.NUM_SINI != siniestroRow.NUM_SINI) {
                    $('#SiniestrosGridTbl').bootstrapTable('collapseRowByUniqueId', siniestroRow.NUM_SINI);
                }
                $('#SiniestrosGridTbl').bootstrapTable('checkBy', { field: 'NUM_SINI', values: [row.NUM_SINI] })

                if (row.NUM_SINI != siniestroRow.NUM_SINI) {
                    siniestroRow = row;
                    RefreshExpedientes();
                    ResizeParent();
                }

                return html.join('')
            },
            onClickRow: function (row, $element, field) {
                if (row.NUM_SINI != siniestroRow.NUM_SINI || field === '') {
                    $('#SiniestrosGridTbl').bootstrapTable('collapseRowByUniqueId', siniestroRow.NUM_SINI);

                    siniestroRow = row;
                    RefreshExpedientes();
                }
            },
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
            },
            rowStyle: function (row, index) {
                return {
                    css: {
                        'vertical-align': 'top'
                    }
                }
            },
            columns: [
                {
                    'field': 'state',
                    'radio': true,
                    class: 'd-none',
                },
                {
                    'field': 'NUM_SINI',
                    'title': 'No. Siniestro',
                    'sortable': false,
                    'halign': 'center',
                    'align': 'center',
                    formatter: function (value, row, index, field) {
                        var status = 'fa-check';
                        var color = 'green';
                        if (row.TIP_EST_SINI == 'P') {
                            status = 'fa-clock-o';
                            color = 'yellowgreen';
                        }
                        return `<i class="fa ${status}" aria-hidden="true" style="margin: 0px 8px 0px 5px;color: ${color};" title="${app.ui.StringCapitalizeFormatter(row.NOM_TIP_EST_SINI)}"></i>` + `<span  title="${app.ui.StringCapitalizeFormatter(row.NOM_CAUSA)}">` + value + '</span>';
                    }
                },
                {
                    'field': 'FEC_SINI',
                    'title': 'Ocurrencia',
                    'sortable': false,
                    'halign': 'center',
                    'align': 'center',
                    formatter: function (value, row, index, field) {
                        if (row.HORA_SINI != null) {
                            value = value.replace("T00:00", "T" + row.HORA_SINI)
                        }
                        return '<span>' + moment(value).format('DD/MM/YYYY hh:mma') + '</span><br>';
                    }
                },
                {
                    'field': 'NOM_CAUSA',
                    'title': 'Causa',
                    'sortable': false,
                    'halign': 'center',
                    'align': 'left',
                    class: 'd-none d-sm-table-cell',
                    formatter: 'app.ui.StringCapitalizeFormatter'
                },
                {
                    'field': 'NOM_TIP_EST_SINI',
                    'title': 'Estado',
                    'sortable': false,
                    'halign': 'center',
                    'align': 'center',
                    cellStyle: function (value, row, index) {
                        if (row.TIP_EST_SINI === 'P') {
                            return {
                                css: {
                                    'background': 'lightyellow'
                                    //'background': 'darkseagreen'
                                }
                            }
                        }
                        else
                            return {};
                    },
                    formatter: 'app.ui.StringCapitalizeFormatter'
                },
                {
                    'field': 'NUM_POLIZA',
                    'title': 'No. Póliza',
                    'sortable': false,
                    'halign': 'center',
                    'align': 'center',
                    formatter: 'app.ui.StringFormatter'
                },
                {
                    'field': 'MATRICULA',
                    'title': 'Placa',
                    'titleTooltip': "Número de placa del vehículo",
                    'sortable': false,
                    'halign': 'center',
                    'align': 'center',
                    formatter: 'app.ui.StringFormatter'
                },
                {
                    'field': 'NOM_ASEG',
                    'title': 'Asegurado',
                    'sortable': false,
                    'halign': 'center',
                    'align': 'left',
                    formatter: function (value, row, index, field) {
                        return `<span>${row.TIP_DOCUM_ASEG} ${row.COD_DOCUM_ASEG} - ${app.ui.StringCapitalizeFormatter(value)} ${app.ui.StringCapitalizeFormatter(row.APE_ASEG)}</span>`;
                    }

                },
                {
                    'field': 'COD_DOCUM_ASEG',
                    'visible': false
                },
                {
                    'field': 'APE_ASEG',
                    'visible': false
                },
                {
                    'field': 'NOM_RIESGO',
                    'visible': false
                }
            ]
        });
    }

    function Init_List_Expedientes() {
        $('#ExpedientesGridTbl').bootstrapTable({
            uniqueId: 'NUM_EXP',
            classes: 'table table-bordered table-hover table-index',
            buttonsClass: 'outline btn-default',
            pagination: true,
            search: false,
            showRefresh: false,
            smartDisplay: true,
            clickToSelect: true,
            singleSelect: true,
            searchAlign: 'left',
            detailView: true,
            pageList: [6, 10, 25, 50, 100],
            pageSize: 6,
            ajax: 'app.SiniestrosPanel.RefreshExpedientes',
            detailFormatter: function (index, row) {
                var html = [];

                html.push('<div class="row">');
                html.push('<div class="col-lg-6">');
                [
                    { key: 'Apertura', value: app.ui.DateFormatter(row.FEC_APER_EXP) },
                    { key: 'Termino', value: app.ui.DateFormatter(row.FEC_TERM_EXP) }
                ].forEach(function (item) {
                    html.push(`<dl class="row mb-0"><div class="col-sm-4 text-sm-right"><dt>${item.key}:</dt></div><div class="col-sm-8 text-sm-left"><dd class="mb-1">${item.value}</dd></div></dl>`);
                });

                html.push('</div>');
                html.push('<div class="col-lg-6">');
                [
                    { key: 'Reserva', value: app.ui.DecimalWithZeroFormatter(row.IMP_RESERVA) },
                    { key: 'Estimado', value: app.ui.DecimalWithZeroFormatter(row.IMP_ESTIMADO) },
                    { key: 'Liquidado', value: app.ui.DecimalWithZeroFormatter(row.IMP_LIQUIDADO) },
                    { key: 'Pagado', value: app.ui.DecimalWithZeroFormatter(row.IMP_PAGADO) }
                ].forEach(function (item) {
                    html.push(`<dl class="row mb-0"><div class="col-sm-4 text-sm-right"><dt>${item.key}:</dt></div><div class="col-sm-8 text-sm-left"><dd class="mb-1">${item.value}</dd></div></dl>`);
                });
                html.push('</div>');
                html.push('</div>');

                if (row.NUM_EXP != expedienteRow.NUM_EXP) {
                    $('#ExpedientesGridTbl').bootstrapTable('collapseRowByUniqueId', expedienteRow.NUM_EXP);
                }
                $('#ExpedientesGridTbl').bootstrapTable('checkBy', { field: 'NUM_EXP', values: [row.NUM_EXP] })
                if (row.NUM_EXP != expedienteRow.NUM_EXP) {
                    expedienteRow = row;
                    RefreshProcess();
                }

                return html.join('')
            },
            onClickRow: function (row, $element, field) {
                if (row.NUM_EXP != expedienteRow.NUM_EXP || field === '') {
                    $('#ExpedientesGridTbl').bootstrapTable('collapseRowByUniqueId', expedienteRow.NUM_EXP);
                    expedienteRow = row;
                    RefreshProcess();
                }
            },
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
            },
            rowStyle: function (row, index) {
                return {
                    css: {
                        'vertical-align': 'top'
                    }
                }
            },
            columns: [
                {
                    'field': 'state',
                    'radio': true,
                    'class': 'd-none',
                },
                {
                    "field": "FEC_APER_EXP",
                    "title": "Apertura",
                    "sortable": false,
                    "halign": "center",
                    "align": "center",
                    "formatter": "app.ui.DateFormatter",
                    "visible": true
                },
                {
                    "field": "NOM_EXP",
                    "title": "Expediente",
                    "sortable": false,
                    "halign": "center",
                    "align": "left",
                    formatter: function (value, row, index, field) {
                        return `<span>${row.NUM_EXP} - ${app.ui.StringCapitalizeFormatter(value)}</span>`;
                    }
                },
                {
                    "field": "NOM_TIP_EST_EXP",
                    "title": "Estado",
                    "sortable": false,
                    "halign": "center",
                    "align": "center",
                    "formatter": "app.ui.StringCapitalizeFormatter"
                }
                //{
                //    "field": "IMP_RESERVA",
                //    "title": "Reserva",
                //    "sortable": false,
                //    "halign": "center",
                //    "align": "right",
                //    "formatter": "app.ui.DecimalWithZeroFormatter"
                //},
                //{
                //    "field": "IMP_ESTIMADO",
                //    "title": "Estimado",
                //    "sortable": false,
                //    "halign": "center",
                //    "align": "right",
                //    "formatter": "app.ui.DecimalWithZeroFormatter"
                //},
                //{
                //    "field": "IMP_LIQUIDADO",
                //    "title": "Liquidado",
                //    "sortable": false,
                //    "halign": "center",
                //    "align": "right",
                //    "formatter": "app.ui.DecimalWithZeroFormatter"
                //},
                //{
                //    "field": "IMP_PAGADO",
                //    "title": "Pagado",
                //    "sortable": false,
                //    "halign": "center",
                //    "align": "right",
                //    "formatter": "app.ui.DecimalWithZeroFormatter"
                //}
            ]
        });
    }

    function Init_List_Process() {
        $('#ProcessGridTbl').bootstrapTable({
            uniqueId: 'ActivityId',
            pagination: false,
            smartDisplay: true,
            rowStyle: function (row, index) {
                return {
                    css: {
                        'vertical-align': 'top'
                    }
                }
            },
            columns: [
                {
                    field: 'Name',
                    title: 'Etapa',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: function (value, row, index, field) {
                        var result = '';
                        var status = 'fa-check';
                        var color = 'green';
                        var styleTitle = 'font-weight: 600;';
                        var title = 'Procesado';
                        if (row.FinishDate === null || row.FinishDate === '0001-01-01T00:00:00') {
                            status = 'fa-clock-o';
                            color = 'yellowgreen';
                            title = 'Etapa en progreso';
                        }
                        if (row.StartDate === null || row.StartDate === '0001-01-01T00:00:00') {
                            status = 'fa-clock-o';
                            color = 'gray';
                            styleTitle = '';
                            title = 'Etapa sin procesar';
                            if (row.Wait === '') {
                                status = 'fa-chain-broken';
                                styleTitle = 'text-decoration: line-through;color: gray'
                                title = 'Etapa no necesaria para el caso';
                            }
                        }
                        result = `<i class="fa ${status}" aria-hidden="true" style="margin: 0px 8px 0px 5px;color: ${color};" title="${title}"></i>` + `<span style="${styleTitle}" title="${title}">` + value + '</span>';

                        if (row.StartDate != null && row.StartDate != '0001-01-01T00:00:00') {
                            result = result + '<div class="d-block d-sm-none" style="margin: 3px 20px 0px;">Inicio: ' + moment(row.StartDate).format('DD/MM/YYYY hh:mma');
                            result = result + '</div>';
                        }

                        if (row.FinishDate != null && row.FinishDate != '0001-01-01T00:00:00') {
                            result = result + '<div class="d-block d-sm-none" style="margin: 0 20px;">Completado: ' + moment(row.FinishDate).format('DD/MM/YYYY hh:mma');
                            result = result + '</div>';
                        }


                        if (row.FinishDate != null && row.FinishDate != '0001-01-01T00:00:00') {
                            result = result + '<div class="d-block d-sm-none" style="margin: 0 20px;">Realizado por: ' + row.UserName;
                            result = result + '<small class="text-muted"> ' + moment(row.FinishDate).from() + '</small>';
                            result = result + '</div>';
                        }
                        if (row.Comments != '') {
                            result = result + '<div class="d-block d-sm-none" style="margin: 0 20px;">Comentario:<small class="text-muted" style="font-style: italic;"> ' + row.Comments + '</small></div>';
                            result = result + '<div class="d-none d-sm-block" style="margin: 0 26px;"><small class="text-muted" style="font-style: italic;"> ' + row.Comments + '</small></div>';
                        }
                        result = result + `<div style="margin: 0 26px;"><small class="text-muted" id="compl_${row.StepId}"></small></div>`;
                        return result;

                    }
                }, {
                    field: 'StartDate',
                    title: 'Inicio',
                    class: 'd-none d-sm-table-cell',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateAndTimeFormatter'
                }, {
                    field: 'FinishDate',
                    title: 'Completado',
                    class: 'd-none d-sm-table-cell',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateAndTimeFormatter'
                }, {
                    field: 'FinishDate',
                    title: 'Realizado por',
                    class: 'd-none d-sm-table-cell',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    width: 15,
                    widthUnit: '%',
                    formatter: function (value, row, index, field) {
                        if (value === null || value === '0001-01-01T00:00:00')
                            return '';
                        else
                            return '<span title="' + moment(value).format('DD/MM/YYYY hh:mma') + '">' + row.UserName + ' <small class="text-muted"> ' + moment(value).from() + '</small></span>';
                    }
                }]
        });
    }

    function Event_Controls() {

        $("#fltEstado1a, #fltEstado2a").click(function () {
            var flt = [];

            if ($("#fltEstado1a").is(":checked")) {
                flt.push('P');
            }
            if ($("#fltEstado2a").is(":checked")) {
                flt.push('T');
            }
            if (flt.length > 0) {
                $('#SiniestrosGridTbl').bootstrapTable('filterBy', { TIP_EST_SINI: flt })
            }
            else {
                $('#SiniestrosGridTbl').bootstrapTable('filterBy', {})
            }
        });

        $('#VisualizationsEdtFormSave').click(function () {
            event.preventDefault();
            $('fieldset').prop("disabled", true);
            //$('#entry').addClass('d-none');
            app.ui.ButtonDoing('#VisualizationsEdtFormSave', false);
            TaskChecked(app.ui.GetRadioNumericValue('task'), $('#Annotation').val(), $('#CustomNotify').is(':checked'));
            if (!$('.liquidado').hasClass('d-none') || !$('.t38').hasClass('d-none') || !$('.t72').hasClass('d-none') || !$('.t93').hasClass('d-none') || !$('.t58').hasClass('d-none')) {
                CaseComplement();
            }
        });

        $('#CustomNotify').change(function () {
            if (this.checked) {
                $('.pattach').removeClass('d-none');
            } else {
                $('.pattach').addClass('d-none');
            }
        });

        $('#attach').click(function () {
            event.preventDefault();
            $('#fileUpload').click();
        });

        $('#fileUpload').on('change', function () {
            var arr = $('#fileUpload').prop('files');
            var message = '';

            for (let fileInfo of arr) {
                if (fileInfo.size >= 31457280) {
                    if (message != '') {
                        message = message & ', ';
                    }
                    message = message & 'El tamaño del archivo ' + fileInfo.name + 'es mayor a 30mb';
                }
            }
            if (message != '') {
                alert(message);
            }
            else {
                app.ui.ButtonDoing('#attach');
                var files = new FormData();

                for (let file of arr) {
                    files.append('files', file);
                }
                $.ajax({
                    type: "POST",
                    enctype: 'multipart/form-data',
                    url: app.setting.apipath + 'v1/Common/Upload',
                    data: files,
                    processData: false,
                    contentType: false,
                    cache: false,
                    timeout: 600000,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('Token'));
                    }
                }).done(function (data) {
                    if (data && data.length > 0) {
                        attachments.push(data[0]);
                        console.log(data[0]);
                        $('.tag-list').append("<li><a href=''><i class='fa fa-paperclip'></i> " + data[0].FileName + "</a></li>");
                    }
                }).fail(function (jqXHR) {
                    console.log("ERROR : ", jqXHR);
                }).always(function () {
                    app.ui.ButtonDone('#attach')
                });
            }
        });

    }

    function Controls_setup() {
        new AutoNumeric('#Fee', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Compensation', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Deductible', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#SpareParts', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#ManPower', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });

        $('#SettlementDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#AppointmentDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });

        $('#ReportDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#RepairTotalAmount', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#RepairManPower', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#RepairSpareParts', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });

        new AutoNumeric('#SetSpaFee', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#SetSpaCompensation', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#SetSpaDeductible', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#SetSpaSpareParts', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#SetSpaManPower', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });

        $('#SetSpaSettlementDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });

        app.core.Lookups([
            'Talleres.Workshop', 'Users.AssignedAdvisor'], null, 'RolFlt1=Citas:RolFlt2=Asesores');
    }

    function OptionSelected() {
        var task = tasks.find(element => element.ActivityId == app.ui.GetRadioNumericValue('task'));
        if (task != null && task.Type == 10) {
            switch (task.Action) {
                case '22': //Asignación de cita
                    $(".t38").removeClass("d-none");
                    break;
                case '48': // Autorización del cliente
                    $(".t72").removeClass("d-none");
                    break;
                case '58': // Realizar liquidación en espera de repuestos no indispensables
                    $(".t58").removeClass("d-none");
                    break;
                case '37': //Realizar liquidación
                    $(".liquidado").removeClass("d-none");
                    break;
                default:
                    $(".liquidado").addClass("d-none");
                    $(".t38").addClass("d-none");
                    $(".t72").addClass("d-none");
                    $(".t93").addClass("d-none");
                    $(".t58").addClass("d-none");
                    break;
            }
            if (task.NotifyToContact == 3) {
                $('.tnotify').removeClass('d-none');
                $('#CustomNotify').prop('checked', true);
                $('.pattach').removeClass('d-none');
            } else {
                $('.tnotify').addClass('d-none');
                $('#CustomNotify').prop('checked', false);
                $('.pattach').addClass('d-none');
            }
            ResizeParent();
        }
        $('#VisualizationsEdtFormSave').prop("disabled", false);
    }

    return {
        Init: function () {
            Controls_setup();
            Init_List_Siniestros();
            Init_List_Expedientes();
            Init_List_Process();
            Event_Controls();
        },
        Refresh: function (params, $el, xid, url) {
            RefreshSiniestros();
        },
        RefreshExpedientes: function (params, $el, xid, url) {
            RefreshExpedientes();
        },
        Enable: function (params, $el, xid, url) {
            OptionSelected();
        },
        Data: function () {
            return { siniestro: siniestroRow, expediente: expedienteRow, caseId: caseId, attachments: attachments };
        }
    };
})();
