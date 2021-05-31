var app = app || {};
app.PolicyEdit = (function () {

    var id = 0;
    var PrimaryInsuredId = 0;
    var documentNumber;
    var productAlias = null;
    var navegationMode = null;

    function Load(internalId) {
        app.core.Get(app.setting.apipath + 'v1/Policy/get?id=' + internalId, null,
            function (data) {
                id = internalId;

                if (data.PrimaryInsured !== null) {
                    PrimaryInsuredId = data.PrimaryInsured.RoleId;
                    ShowHeader(data);
                }
                app.asegurado.ObjectToInput(data.PrimaryInsured);
                app.cuestionario.ObjectToInput(data.Questionary);
                app.beneficiarios.ObjectToInput(data.Beneficiaries);

                app.prestamo.ObjectToInput(data.Overdraft);
                ShowFooter(data);

                productAlias = data.ProductAlias;
                app.poliza.Behavior(productAlias, function () {
                    app.poliza.ObjectToInput(data);
                });

                _WorkMode(data.Status);
                $('#historialTabHeader').removeClass('d-none');
            });
    };

    function Setup() {
        productAlias = app.core.URLStringValue('alias');

        $('#save').removeClass('d-none');
        $('#accept').removeClass('d-none');
        _WorkMode(1);
        app.poliza.Behavior(productAlias);
    }

    var _WorkMode = function (status, statusDesc) {
        var disabled = status != 1;

        if (status !== 1) {
            $('#print').removeClass('d-none');
            $('#accept').addClass('d-none');
            $('#save').addClass('d-none');
        }
        else
            $('#accept').removeClass('d-none');

        if (status == 1)
            $('#save').removeClass('d-none');

        if (navegationMode === 'modify') {
            $('#applyChange').removeClass('d-none');
            $('#print').removeClass('d-none');
            $("#QuestionaryEdtFrm fieldset").prop("disabled", true);
            $("#beneficiaryEdtFrm fieldset").prop("disabled", false);
            $("#RiskEdtFrm fieldset").prop("disabled", true);
            $("#OverdraftEdtFrm fieldset").prop("disabled", true);
            $("#AttachmentsEdt fieldset").prop("disabled", false);
        }
        else {
            $("#QuestionaryEdtFrm fieldset").prop("disabled", disabled);
            $("#beneficiaryEdtFrm fieldset").prop("disabled", disabled);
            //$("#RiskEdtFrm fieldset").prop("disabled", disabled);
            $("#OverdraftEdtFrm fieldset").prop("disabled", disabled);
            $("#AttachmentsEdt fieldset").prop("disabled", disabled);
        }

        if (statusDesc !== undefined)
            ShowHeaderStatus(statusDesc);

        switch (status) {
            case 3:
            case 4:
            case 10:
                if (navegationMode != 'cancel') {
                    $("#RiskEdtFrm fieldset").prop("disabled", true);
                    $('#Surcharge').parent().parent().removeClass('d-none');
                    $('#policyComment').removeClass('d-none');

                    $('#ReviewAccept').addClass('d-none');
                    $('#ReviewCondition').addClass('d-none');
                    $('#ReviewDecline').addClass('d-none');

                    $('#AcceptCondition').addClass('d-none');
                    $('#AcceptDecline').addClass('d-none');
                }
                break;
            case 11:
                $('#policyStatusZone').removeClass('d-none');

                $('#CancellationDate').prop("disabled", true);
                $('#ReasonForStatus').prop("disabled", true);
                $('#AcceptCancellation').addClass('d-none');
                break;
        }

        app.asegurado.WorkMode(status, navegationMode);
    }

    function IsValid() {
        var result = true;
        if (!app.asegurado.IsValid())
            result = false;
        if (!app.cuestionario.IsValid())
            result = false;
        if (!$('#beneficiariosHTabHeader').hasClass('d-none') && !app.beneficiarios.IsValid())
            result = false;
        if (!app.poliza.IsValid())
            result = false;
        if (!$('#prestamosHTabHeader').hasClass('d-none') && !app.prestamo.IsValid())
            result = false;
        //result = app.attachment.IsValid() && result;
        return result;
    };

    function MapInputToObject() {
        var data = app.poliza.InputToObject();
        data.PrimaryInsured = app.asegurado.InputToObject();
        data.Questionary = app.cuestionario.InputToObject();
        data.Beneficiaries = app.beneficiarios.InputToObject();
        data.Overdraft = app.prestamo.InputToObject();
        data.Attachments = app.attachment.InputToObject();
        return data;
    };

    function Storage(data, ctrolId) {
        var currentCaption = $(ctrolId).html();
        var urlPath = '';
        var mode = 'POST';
        $(ctrolId).prop("disabled", false);
        $(ctrolId).html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Procesando');
        if (id === 0)
            urlPath = app.setting.apipath + 'v1/Policy/Post';
        else {
            urlPath = app.setting.apipath + 'v1/Policy/Put';
            mode = 'PUT';
            data.Id = id;
            data.PrimaryInsured.RoleId = PrimaryInsuredId;
            if (ctrolId === '#applyChange') {
                urlPath = app.setting.apipath + 'v1/Policy/Modify';
            }
        }

        app.core.Send(mode, urlPath, JSON.stringify(data),
            function (data) {
                if (id === 0) {
                    id = data.Id;
                    PrimaryInsuredId = data.PrimaryInsuredId;
                }
                app.changeset.Load(id);

                if (ctrolId !== '#applyChange')
                    window.history.replaceState({}, null, location.pathname + '?alias=' + productAlias + '&id=' + id);


                $.each(data.Errors, function () {
                    var options = {};
                    if (this['Key'] !== '*') {
                        options[this['Key']] = this['Message'];
                        $('#' + this['Group'] + 'EdtFrm').validate().showErrors(options);
                    } else
                        app.ui.ShowAlert(this['Group'] + 'Notify', 'alert-danger', this['Message']);
                });


                if (data.Status !== 1)
                    _WorkMode(data.Status, data.StatusDesc);


                if (data.Errors.length > 0) {
                    var count = 0;

                    count = $('#PrimaryInsuredEdtFrm').validate().errorList.length;
                    if (count > 0)
                        $('#aseguradoHTab .badge').html(count);
                    else
                        $('#aseguradoHTab .badge').html('');

                    count = $('#QuestionaryEdtFrm').validate().errorList.length;
                    if (count > 0)
                        $('#cuestionarioHTab .badge').html(count);
                    else
                        $('#cuestionarioHTab .badge').html('');

                    if (!$('#beneficiariosHTabHeader').hasClass('d-none')) {
                        count = $('#beneficiaryNotifyAlert').length;
                        if (count === 0 && !$('#beneficiariosEdt').hasClass('d-none'))
                            count = $('#beneficiaryEdtFrm').validate().errorList.length;
                        if (count > 0)
                            $('#beneficiariosHTab .badge').html(count);
                        else
                            $('#beneficiariosHTab .badge').html('');
                    }
                    count = $('#RiskEdtFrm').validate().errorList.length;
                    if (count > 0)
                        $('#polizaHTab .badge').html(count);
                    else
                        $('#polizaHTab .badge').html('');

                    if (!$('#prestamosHTabHeader').hasClass('d-none')) {
                        count = $('#OverdraftEdtFrm').validate().errorList.length;
                        if (count > 0)
                            $('#prestamosHTab .badge').html(count);
                        else
                            $('#prestamosHTab .badge').html('');
                    }
                    if (ctrolId === '#accept')
                        app.ui.ShowAlert('generalNotify', 'alert-danger', data.Message);
                    toastr.success("La información fue almacenada", "", { timeOut: 5000, closeButton: true, progressBar: true });
                }
                else
                    switch (data.Status) {
                        case 2:
                            app.ui.ShowAlert('generalNotify', 'alert-warning', data.Message);
                            toastr.success("Póliza emitida para su revisión", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            break;
                        case 10:
                            app.ui.ShowAlert('generalNotify', 'alert-success', data.Message);
                            if (ctrolId === '#applyChange')
                                toastr.success("Póliza modificada", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            else
                                toastr.success("Póliza emitida", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            break;
                    }
            }).always(function () {
                $(ctrolId).html(currentCaption);
                $(ctrolId).prop("disabled", false);
            });

    }

    function Init_Controls() {
        $('#xxx').footable();

        $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
            e.target // newly activated tab
            e.relatedTarget // previous active tab
            switch (e.target.hash) {
                case '#beneficiarioTab':

                    break;
                case '#historialTab':

                    break;
            }
        });
        $("#todo").sortable({
            connectWith: ".connectList",
            update: function (event, ui) {

                var todo = $("#todo").sortable("toArray");
                var inprogress = $("#inprogress").sortable("toArray");
                var completed = $("#completed").sortable("toArray");
                $('.output').html("ToDo: " + window.JSON.stringify(todo) + "<br/>" + "In Progress: " + window.JSON.stringify(inprogress) + "<br/>" + "Completed: " + window.JSON.stringify(completed));
            }
        }).disableSelection();
    };

    function Init_Lookups() {
    };

    function Event_Controls() {

        $('#save').click(function () {
            event.preventDefault();
            var data = MapInputToObject();
            data.Status = 1;
            Storage(data, '#save');
        });
        $('#accept').click(function () {
            event.preventDefault();
            if (IsValid()) {
                var data = MapInputToObject();
                data.Status = 10;
                Storage(data, '#accept');
            }
        });
        $('#print').click(function () {
            event.preventDefault();
            app.policy_common.Print(id);
        });

        $('#applyChange').click(function () {
            event.preventDefault();
            if (IsValid()) {
                var data = MapInputToObject();
                Storage(data, '#applyChange');
            }
        });

    };

    function Setup_Validations() {

    };

    async function ShowHeader(data) {
        if (data.PrimaryInsured.FirstName !== '') {
            $('#PrimaryInsuredFullName').html(' - ' + data.PrimaryInsured.FirstName + ' ' + data.PrimaryInsured.MiddleName + ' ' + data.PrimaryInsured.LastName + ' ' + data.PrimaryInsured.SecondLastName);
        }
        else
            $('#PrimaryInsuredFullName').html('');

        if (data.PolicyId === 0)
            $('#PolicyPolicyId').html(' - I-' + data.Id);
        else
            $('#PolicyPolicyId').html(' - ' + data.PolicyId);

        ShowHeaderStatus(data.StatusDesc);
    }

    async function ShowHeaderStatus(statusDesc) {
        $('#PolicyStatus').html(statusDesc);
        $('#PolicyStatus').addClass(app.policy_common.PolicyStatus2CSSClass(statusDesc));
        $('#PolicyStatus').removeClass('d-none');
    }

    async function ShowFooter(data) {
        $('#lastChange').html(data.UpdateUserName + ' <i class="fa fa-clock-o"></i> ' + moment(data.UpdateDate).format('hh:mma') + ' - ' + moment(data.UpdateDate).from());
        $('#lastChange').prop('title', 'Último cambio ' + moment(data.UpdateDate).format('DD/MM/YYYY hh:mma'));
    }

    return {
        Init: function () {
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Setup_Validations();
            var _id = app.core.URLNumericValue('id');

            navegationMode = app.core.URLStringValue('navmode');

            if (_id !== 0)
                Load(_id);
            else
                Setup();



            //$("#aseguradoTab").load("../html/asegurado.html", function () {
            //    alert("Load was performed.");
            //});
        },
        ProductAlias: function () {
            return productAlias;
        },
        Id: function () {
            return id;
        },
        NavegationMode: function () {
            return navegationMode;
        },
        WorkMode: _WorkMode
    };
}());
