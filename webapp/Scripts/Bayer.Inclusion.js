var app = app || {};

app.BayerInclusion = (function () {

    let timer;
    var id = 0;
    var mode = '';

    function Setup(internalId) {
        id = internalId;

        if (localStorage.getItem('Tenant') === 'Bayer') {
            $('.tenant-bayer-visible').removeClass('d-none');
            $('.HasDigitalSignature').addClass('d-none');
            app.ui.RequiredMark("EmployeeNumber", true);
        }

        if (localStorage.getItem('Tenant') === 'Caturix') {
            let selectedOptions = $('select#IsHealth');
            selectedOptions.children().remove();
            selectedOptions.append($('<option />').val('').text(''));
            selectedOptions.append($('<option />').val('A').text('Clase 1 - $100,000.00'));
            selectedOptions.append($('<option />').val('B').text('Clase 2 - $150,000.00'));
        }

        app.core.Lookups([
            'BayerPolizas.ContractorName',
            'BayerNumeroPoliza.MainPolicyId',
            'Gender.Gender',
            'Pais.CountryOfNationality',
            'CivilStatus.CivilStatus',
            'CR_Provincia.Province',
            'Relationship.BRelationship',
            'DirectRelationship.DRelationship',
            'CR_Bancos.RefundBankCode'],
            function () {
                if (internalId != null) {
                    app.core.Get(app.setting.apipath + 'v1/Inclusion/bayer/' + internalId)
                        .done(function (data) {
                            $("#VisualizationsEdtForm fieldset").prop("disabled", false);
                            MapObjectToInput(data);
                        });
                }
                else {
                    app.core.Get(app.setting.apipath + 'v1/Inclusion/bayer/0')
                        .done(function (data) {
                            id = internalId;
                            $("#VisualizationsEdtForm fieldset").prop("disabled", false);
                            MapObjectToInput(data);
                        });
                }

            });

        // Dependencies
        $('#Province').on('change', function () {
            app.core.LookupDependency($('select#Province').val(), 'Canton', 'CR_Canton', '', null, true);
        });
        $('#Canton').on('change', function () {
            app.core.LookupDependency($('select#Canton').val(), 'District', 'CR_Distritos', '', null, false);
        });
    }

    function MapInputToObject() {
        let _data = {
            Id: id,
            Mode: mode,
            MainPolicyId: $('#MainPolicyId').val(),
            ContractorName: app.ui.GetDropDownNumericValue('#ContractorName'),
            ContractorDesc: $("#ContractorName option:selected").text(),
            IssueDate: app.ui.GetDateValue('#IssueDate'),
            IsLife: app.ui.GetDropDownStringValue('#IsLife'),
            IsHealth: app.ui.GetDropDownStringValue('#IsHealth'),
            DocumentType: $("#DocumentNumberType").data("value"),
            DocumentNumber: $('#DocumentNumber').val(),
            FirstName: $('#FirstName').val(),
            LastName: $('#LastName').val(),
            Gender: app.ui.GetDropDownNumericValue('#Gender'),
            GenderDesc: $("#Gender option:selected").text(),
            BirthDate: app.ui.GetDateValue('#BirthDate'),
            CountryOfNationality: app.ui.GetDropDownNumericValue('#CountryOfNationality'),
            CountryOfNationalityDesc: $("#CountryOfNationality option:selected").text(),
            SocialSecurity: $('#SocialSecurity').val(),
            DominantMember: $('input:radio[name=DominantMember]:checked').val(),
            PhoneType: $("#PhoneType").data("value"),
            PhoneNumber: $('#PhoneNumber').val(),
            DateEntryWork: app.ui.GetDateValue('#DateEntryWork'),
            CivilStatus: app.ui.GetDropDownNumericValue('#CivilStatus'),
            CivilStatusDesc: $("#CivilStatus option:selected").text(),
            MonthlySalary: app.ui.GetNumericValue('#MonthlySalary'),
            PrimaryEmailAddress: $('#PrimaryEmailAddress').val(),
            Occupation: $('#Occupation').val(),
            Height: app.ui.GetNumericValue('#Height'),
            Weight: app.ui.GetNumericValue('#Weight'),
            InsuredAmount: app.ui.GetNumericValue('#InsuredAmount'),
            Doctor: $('#Doctor').val(),
            EmployeeNumber: $('#EmployeeNumber').val(),
            Province: app.ui.GetDropDownNumericValue('#Province'),
            ProvinceDesc: $("#Province option:selected").text(),
            Canton: app.ui.GetDropDownNumericValue('#Canton'),
            CantonDesc: $("#Canton option:selected").text(),
            District: app.ui.GetDropDownNumericValue('#District'),
            DistrictDesc: $("#District option:selected").text(),
            AddressDetail: $('#AddressDetail').val(),
            RefundBankCode: app.ui.GetDropDownNumericValue('#RefundBankCode'),
            RefundBankDesc: $("#RefundBankCode option:selected").text(),
            RefundBankAccount: $('#RefundBankAccount').val(),
            RefundBankAccountType: $('input:radio[name=RefundBankAccountType]:checked').val(),
            RefundBankAccountCurrency: $('input:radio[name=RefundBankAccountCurrency]:checked').val(),
            beneficiarios: $('#beneficiariosTbl').bootstrapTable('getData'),
            dependientes: $('#dependientesTbl').bootstrapTable('getData'),
            HasDigitalSignature: $('input:radio[name=HasDigitalSignature]:checked').val() === "1",
            ContinuityDate: app.ui.GetDateValue('#ContinuityDate')
        };
        if (localStorage.getItem('Tenant') === 'Bayer') {
            //_data.HasDigitalSignature = false;
        }
        if (localStorage.getItem('Tenant') === 'Caturix') {
            switch (_data.IsHealth) {
                case 'A':
                    _data.InsuredAmount = 100000;
                    break;
                case 'B':
                    _data.InsuredAmount = 150000;
                    break;
            }
        }
        return _data;
    }

    function MapObjectToInput(data) {
        id = data.Id;
        mode = data.Mode;

        $('#MainPolicyId').val(data.ContractorName);

        app.ui.SetDropDownNumericValue('#ContractorName', data.ContractorName, true);

        app.ui.SetDateValue('#IssueDate', data.IssueDate);
        $('#IsLife').val(data.IsLife);
        $('#IsHealth').val(data.IsHealth);
        app.ui.SetDocumentTypeValue('#DocumentNumberType', data.DocumentType);
        $('#DocumentNumber').val(data.DocumentNumber);
        $('#FirstName').val(data.FirstName);
        $('#LastName').val(data.LastName);
        $('#Gender').val(data.Gender);
        app.ui.SetDateValue('#BirthDate', data.BirthDate);
        $('#CountryOfNationality').val(data.CountryOfNationality);
        $('#SocialSecurity').val(data.SocialSecurity);
        $('input:radio[name=DominantMember][value=' + data.DominantMember + ']').prop('checked', true);

        $('#PhoneType').data('value', data.PhoneType);
        $('#PhoneType').text($('#PhoneType').parent().find('#PhoneTypeMenu a[data-value=' + data.PhoneType + ']').text());
        $('#PhoneNumber').val(data.PhoneNumber);
        app.ui.SetDateValue('#DateEntryWork', data.DateEntryWork);
        $('#CivilStatus').val(data.CivilStatus);
        app.ui.SetNumericValue('#MonthlySalary', data.MonthlySalary);
        $('#PrimaryEmailAddress').val(data.PrimaryEmailAddress);
        $('#Occupation').val(data.Occupation);
        app.ui.SetNumericValue('#Height', data.Height);
        app.ui.SetNumericValue('#Weight', data.Weight);
        app.ui.SetNumericValue('#InsuredAmount', data.InsuredAmount);
        $('#Doctor').val(data.Doctor);
        $('#EmployeeNumber').val(data.EmployeeNumber);
        $('#Province').val(data.Province);
        app.core.LookupDependency(data.Province, 'Canton', 'CR_Canton', '', data.Canton, false);
        app.core.LookupDependency(data.Canton, 'District', 'CR_Distritos', '', data.District, false);
        $('#AddressDetail').val(data.AddressDetail);
        $('#RefundBankCode').val(data.RefundBankCode);
        $('#RefundBankAccount').val(data.RefundBankAccount);
        $('input:radio[name=RefundBankAccountType][value=' + data.RefundBankAccountType + ']').prop('checked', true);
        $('input:radio[name=RefundBankAccountCurrency][value=' + data.RefundBankAccountCurrency + ']').prop('checked', true);
        if (data.beneficiarios != null)
            $('#beneficiariosTbl').bootstrapTable('load', data.beneficiarios);
        else
            $('#beneficiariosTbl').bootstrapTable('load', {});
        if (data.Dependientes != null)
            $('#dependientesTbl').bootstrapTable('load', data.Dependientes);
        else
            $('#dependientesTbl').bootstrapTable('load', {});
        $('input:radio[name=HasDigitalSignature][value=' + (data.HasDigitalSignature ? 1 : 2) + ']').prop('checked', true);
        app.ui.SetDateValue('#ContinuityDate', data.ContinuityDate);
        Status_Handler(data.Status, data.Mode);
    }

    function Status_Handler(status, statusmode) {
        switch (status) {
            case 0:
            case 1:
                $('#VisualizationsEdtFormDraft').removeClass('d-none');
                $('#VisualizationsEdtFormSave').removeClass('d-none');
                if (localStorage.getItem('Tenant') === 'Bayer') {
                    $('#DateEntryWork').prop("disabled", false);
                }
                break;
            case 2:
                //app.ui.DataEntryBehavior('#VisualizationsEdtForm', 'disabled');
                if (statusmode === 'Review') {
                    $('.role-Revisor-visible').removeClass('d-none');
                    if (localStorage.getItem('Tenant') === 'Caturix') {
                        $('#InsuredAmount').parent().parent().addClass('d-none');
                    }
                    $('.role-Revisor-enabled').prop("disabled", false);
                    $('.role-Revisor-enabled-bayer').prop("disabled", false);
                    $('#VisualizationsEdtFormBack').removeClass('d-none');
                    $('#VisualizationsEdtFormRevised').removeClass('d-none');
                }
                break;
            case 4:
                let data = MapInputToObject();
                if (data.HasDigitalSignature) {
                    $('#acceptedNotify').removeClass('d-none');
                    $('#print').removeClass('d-none');
                    app.BayerInclusion.timer = setInterval(function () {
                        $('#VisualizationsEdtFormUpLoad').removeClass('d-none');
                        $('#fileUpload').prop("disabled", false);
                        clearInterval(app.BayerInclusion.timer);
                    }, 500);
                }
            case 32:
                if (statusmode === 'Review') {
                    $('#VisualizationsEdtFormBack').removeClass('d-none');
                    $('#VisualizationsEdtFormRevised').removeClass('d-none');
                }
            case 10:
            case 31:
                app.ui.DataEntryBehavior('#VisualizationsEdtForm', 'disabled');
                $('#print').removeClass('d-none');
                break;
            case 99:
                app.ui.DataEntryBehavior('#VisualizationsEdtForm', 'disabled');
                $('#VisualizationsEdtFormDraft').addClass('d-none');
                $('#VisualizationsEdtFormSave').addClass('d-none');
                $('#VisualizationsEdtFormBack').addClass('d-none');
                $('#VisualizationsEdtFormRevised').addClass('d-none');
                $('#acceptedNotify').addClass('d-none');
                break;
        }
    }

    function Controls_setup() {
        $("#MonthlySalary,#IsLife").change(function (e) {
            data_changed(e);
        });
        $("#MonthlySalary,#IsLife").keyup(function (e) {
            data_changed(e);
        });

        $('#IssueDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#DocumentNumber').formatter({
            pattern: '{{9}}{{9999}}{{9999}}',
            persistent: false
        });
        $('#BirthDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#PhoneNumber').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#DateEntryWork_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#MonthlySalary', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Height', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Weight', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#InsuredAmount', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '99999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#BDocumentNumber').formatter({
            pattern: '{{9}}{{9999}}{{9999}}',
            persistent: false
        });
        $('#BBirthDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        new AutoNumeric('#BParticipationRate', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        $('#DDocumentNumber').formatter({
            pattern: '{{9}}{{9999}}{{9999}}',
            persistent: false
        });
        $('#DBirthDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null
        });
        $('#DInclusionDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            defaultDate: new Date()
        });

        $('#ContinuityDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });

        $("#VisualizationsEdtFormDraft").appendTo("#GenericToolBar");
        $("#VisualizationsEdtFormSave").appendTo("#GenericToolBar");
        $("#VisualizationsEdtFormBack").appendTo("#GenericToolBar");
        $("#VisualizationsEdtFormRevised").appendTo("#GenericToolBar");
        $("#VisualizationsEdtFormUpLoad").appendTo("#GenericToolBar");


        $(".XXX").appendTo('.sidebar-content');
        $(".XXX").removeClass('d-none');
        $('#sidebarTitle').html("<h3>Motivo del rechazo</h3>");

    }

    function Controls_Events() {

        $("#motivo").keyup(function () {
            $("#VisualizationsEdtFormBackConfirm").prop("disabled", $('#motivo').val().length === 0);
        });

        $('#DocumentNumberTypeMenu a').click(function () {
            DocumentTypeHandler(this, '#DocumentNumber', 'Identification');
        });

        $('#DocumentNumber').on('blur', function () {
            if (IsDocumentNumberValid($('#DocumentNumberType').data('value'), $('#DocumentNumber').val())) {
                var value = $('#DocumentNumber').val().replace(/-/g, '');
                if (value !== null && parseInt(0 + value, 10) !== 0 && parseInt(0 + value, 10) <= 999999999) {
                    $('#DocumentNumber').addClass('loading');
                    app.core.Get(app.setting.apipath + 'v1/Insured/' + value)
                        .done(function (data) {
                            if (data !== null && data.Nombre !== null) {
                                $('#FirstName').val(data.FirstName);
                                $('#LastName').val(data.LastName + ' ' + data.SecondLastName);
                                $('#Gender').val(data.Gender);
                                $('#Province').val(data.Province);
                                app.ui.SetDateValue('#BirthDate', data.BirthDate);
                                app.core.LookupDependency($('select#Province').val(), 'Canton', 'CR_Canton', '', data.Canton, false,
                                    function () {
                                        app.core.LookupDependency($('select#Canton').val(), 'District', 'CR_Distritos', '', data.District, false);
                                    });
                            }
                        }).always(function () {
                            $('#DocumentNumber').removeClass('loading');
                        });
                }
            }
        });

        $('#PhoneNumberTypeMenu a').click(function () {
            DocumentTypeHandler(this, '#PhoneNumber', 'Phone');
        });

        $('#BDocumentNumberTypeMenu a').click(function () {
            DocumentTypeHandler(this, '#BDocumentNumber', 'Identification');
        });

        $('#BDocumentNumber').on('blur', function () {
            if (IsDocumentNumberValid($('#BDocumentNumberType').data('value'), $('#BDocumentNumber').val())) {
                var value = $('#BDocumentNumber').val().replace(/-/g, '');
                if (value !== null && parseInt(0 + value, 10) !== 0 && parseInt(0 + value, 10) <= 999999999) {
                    $('#BDocumentNumber').addClass('loading');
                    app.core.Get(app.setting.apipath + 'v1/Insured/' + value)
                        .done(function (data, textStatus, jqXHR) {
                            if (data !== null && data.Nombre !== null) {
                                $('#BFirstName').val(data.FirstName);
                                $('#BLastName').val(data.LastName + ' ' + data.SecondLastName);
                                app.ui.SetDateValue('#BBirthDate', data.BirthDate);
                            }
                        }).always(function () {
                            $('#BDocumentNumber').removeClass('loading');
                        });
                }
            }
        });

        $('#DDocumentNumberTypeMenu a').click(function () {
            DocumentTypeHandler(this, '#DDocumentNumber', 'Identification');
        });

        $('#DDocumentNumber').on('blur', function () {
            if (IsDocumentNumberValid($('#DDocumentNumberType').data('value'), $('#DDocumentNumber').val())) {
                var value = $('#DDocumentNumber').val().replace(/-/g, '');
                if (value !== null && parseInt(0 + value, 10) !== 0 && parseInt(0 + value, 10) <= 999999999) {
                    $('#DDocumentNumber').addClass('loading');
                    app.core.Get(app.setting.apipath + 'v1/Insured/' + value)
                        .done(function (data, textStatus, jqXHR) {
                            if (data.Nombre !== null) {
                                $('#DFirstName').val(data.FirstName);
                                $('#DLastName').val(data.LastName + ' ' + data.SecondLastName);
                                app.ui.SetDateValue('#DBirthDate', data.BirthDate);
                            }
                        }).always(function () {
                            $('#DDocumentNumber').removeClass('loading');
                        });
                }
            }
        });

        $('#VisualizationsEdtFormDraft').click(function () {
            event.preventDefault();
            Submit_Stage('draft', '#VisualizationsEdtFormDraft');
        });
        $('#VisualizationsEdtFormSave').click(function () {
            event.preventDefault();
            Submit_Stage('send', '#VisualizationsEdtFormSave');
        });
        $('#VisualizationsEdtFormBack').click(function () {
            event.preventDefault();
            $('#right-sidebar').toggleClass('sidebar-open');
        });
        $('#VisualizationsEdtFormBackConfirm').click(function () {
            event.preventDefault();
            Submit_Stage('back', '#VisualizationsEdtFormBackConfirm', $('#motivo').val(), function () {
                $('#right-sidebar').toggleClass('sidebar-open');
            });
        });
        $('#VisualizationsEdtFormRevised').click(function () {
            event.preventDefault();
            Submit_Stage('revised', '#VisualizationsEdtFormRevised');
        });

        //$('#VisualizationsEdtFormCancel').click(function () {
        //    app.ui.ButtonDoing('#VisualizationsEdtFormCancel');
        //    setTimeout(() => { app.ui.ButtonDone('#VisualizationsEdtFormCancel'); }, 3000);
        //    event.preventDefault();
        //});


        $('#ContractorName').change(function () {
            $('#MainPolicyId').val($('#ContractorName').val());
        });


        $('#print').click(function () {
            event.preventDefault();
            app.core.Get(app.setting.apipath + 'v1/Inclusion/bayer/' + id)
                .done(function (data) {
                    if (localStorage.getItem('Tenant') === 'Caturix') {
                        switch (data.IsHealth) {
                            case 'A':
                                data.InsuredAmount = 100000;
                                break;
                            case 'B':
                                data.InsuredAmount = 150000;
                                break;
                        }
                    }
                    var urlServer = app.setting.apibase + '/AliadoServReports/api/Report/Build';
                    var data2 = {
                        Source: JSON.stringify(data),
                        Type: 'pdf',
                        ReportName: 'bayer.repx',
                        Path: ''
                    };
                    $.post(urlServer, data2, { responseType: 'arraybuffer' })
                        .then(function (response) {
                            var file = new Blob([response.Data], { type: 'application/octet-binary' });
                            var blob = b64StrtoBlob(response.Data, 'application/pdf');
                            var blobUrl = URL.createObjectURL(blob);
                            window.open(blobUrl);
                        });
                });
        });

        $('#VisualizationsEdtFormUpLoad').click(function () {
            event.preventDefault();
            $('#fileUpload').click();
        });

        $('#fileUpload').on('change', function () {
            var index = 0;
            var arr = $('#fileUpload').prop('files');
            var message = '';

            for (index = 0; index < arr.length; index++) {
                if (arr[index].size >= 31457280) {
                    if (message != '') {
                        message = message & ', ';
                    }
                    message = message & 'El tamaño del archivo ' + arr[index].name + 'es mayor a 30mb';
                }
            }
            if (message != '') {
                elementInstance.showErrors({ 'FileName': message });
            }
            else {
                app.ui.ButtonDoing('#fileUpload');
                var data = new FormData();
                //data.append('EntityType', 2000);
                //data.append('EntityId', id);
                //data.append('DocumentType', 4001);
                //data.append('Description', "Solicitud con firma digital");

                for (index = 0; index < arr.length; index++) {
                    data.append('files', arr[index]);
                }
                $.ajax({
                    type: "POST",
                    enctype: 'multipart/form-data',
                    url: app.setting.apipath + 'v1/Common/Upload',
                    data: data,
                    processData: false,
                    contentType: false,
                    cache: false,
                    timeout: 600000,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('Token'));
                    }
                }).done(function (data, textStatus, jqXHR) {
                    app.core.Get(app.setting.apipath + 'v1/Inclusion/VerifySignature?id=' + id + '&fileName=' + data[0].StoredFileName + '&size=' + data[0].Size + '&originalFileName=' + data[0].FileName)
                        .done(function (data2) {
                            Status_Handler(99, '');
                            if (data2.Valid) {
                                Status_Handler(10, '');
                                app.ui.ShowAlert('quoteNotify', 'alert-info', data2.Message);
                            }
                            else {
                                app.ui.ShowAlert('quoteNotify', 'alert-danger', data2.Message);
                            }
                        });

                }).fail(function (jqXHR, textStatus, errorThrown) {
                    console.log("ERROR : ", jqXHR);
                }).always(function () {
                    app.ui.ButtonDone('#fileUpload')
                });
            }
        });

    }

    function Submit_Stage(stageMode, buttonId, reason, callback) {
        var allowSend = false;
        switch (stageMode) {
            case 'draft':
                var beneficiariosTableValid = beneficiarios_table_OtherValidations();
                var allValid = app.ui.IsValid('#VisualizationsEdtForm', false);
                allowSend = true;
                break;
            case 'send':
                var beneficiariosTableValid = beneficiarios_table_OtherValidations();
                var allValid = app.ui.IsValid('#VisualizationsEdtForm', false);
                allowSend = beneficiariosTableValid && allValid;
                break;
            case 'back':
                allowSend = true;
                break;
            case 'revised':
                var beneficiariosTableValid = beneficiarios_table_OtherValidations();
                var allValid = app.ui.IsValid('#VisualizationsEdtForm', false);
                allowSend = beneficiariosTableValid && allValid;
                break;
        }

        if (allowSend) {
            var uidata = MapInputToObject();
            uidata.mode = stageMode;
            uidata.Message = reason;
            app.ui.ButtonDoing(buttonId);

            app.core.Post(app.setting.apipath + 'v1/Inclusion/bayer', JSON.stringify(uidata))
                .done(function (data, textStatus, jqXHR) {
                    if (callback !== undefined && callback !== null)
                        callback();
                    switch (stageMode) {
                        case 'draft':
                            id = data.Id;
                            break;
                        case 'send':
                            id = data.Id;
                            Status_Handler(99, null);
                            break;
                        case 'back':
                            Status_Handler(99, null);
                            break;
                        case 'revised':
                            Status_Handler(99, null);
                            if (localStorage.getItem('Tenant') === 'Caturix') {
                                $('#print').removeClass('d-none');
                            }
                            break;
                    }
                    if (data.Message != null) {
                        app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Message);
                    }
                }).always(function () {
                    app.ui.ButtonDone(buttonId);
                });
        }
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $.validator.addMethod("bayerrequired",
            function (value, element) {
                return localStorage.getItem('Tenant') != 'Bayer' || (value != null && value != "");
            }, 'Debe indicar un valor'
        );

        $("#VisualizationsEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                ContractorName: { required: true },
                IssueDate: { required: true },
                IsLife: { required: true },
                IsHealth: { required: true },
                DocumentNumber: { required: true },
                FirstName: { required: true },
                LastName: { required: true },

                BirthDate: { required: true, BirthDate: true },
                Gender: { required: true },
                CountryOfNationality: { required: true },
                DominantMember: { required: true },
                DateEntryWork: { required: true },
                EmployeeNumber: { bayerrequired: true },
                MonthlySalary: { required: true },
                InsuredAmount: { required: true },
                PhoneNumber: { minlength: 9 },
                PrimaryEmailAddress: { email: true, required: true },
                RefundBankCode: { required: true },
                RefundBankAccount: { required: true, minlength: 22 },
                RefundBankAccountType: { required: true },
                RefundBankAccountCurrency: { required: true },

                Province: { required: true },
                Canton: { required: true },
                District: { required: true },
                AddressDetail: { required: true }
            },
            messages: {
                ContractorName: { required: 'Debe indicar la filial de Bayer' },
                IssueDate: { required: 'Debe indicar la fecha de ingreso a la póliza' },
                IsLife: { required: 'Debe indicar la clase para vida' },
                IsHealth: { required: 'Debe indicar la clase para salud' },
                DocumentNumber: { required: 'Debe indicar el Identificación' },
                FirstName: { required: 'Debe indicar el Nombres' },
                LastName: { required: 'Debe indicar el Apellidos' },

                BirthDate: {
                    required: 'Debe indicar la fecha de nacimiento',
                    BirthDate: 'Ingrese una fecha inferior al día de hoy'
                },
                Gender: { required: 'Debe indicar el sexo' },
                CountryOfNationality: { required: 'Debe indicar la nacionalidad' },
                DominantMember: { required: 'Debe indicar el miembro dominante' },
                DateEntryWork: { required: 'Debe indicar la fecha de ingreso a trabajar' },
                EmployeeNumber: { bayerrequired: 'Debe indicar el número de empleado' },
                MonthlySalary: { required: 'Debe indicar el salario mensual' },
                InsuredAmount: { required: 'Debe indicar la suma asegurada' },
                PhoneNumber: { minlength: 'Debe indicar 8 dígitos' },
                PrimaryEmailAddress: {
                    email: 'Debe indicar un correo electrónico valido',
                    required: 'Debe indicar el correo electrónico'
                },
                RefundBankCode: { required: 'Debe indicar el banco para reembolso' },
                RefundBankAccount: { required: 'Debe indicar el número de cuenta para reembolso', minlength: 'El número de cuenta IBAN debe tener 22 dígitos' },
                RefundBankAccountType: { required: 'Debe indicar el tipo de cuenta para reembolso' },
                RefundBankAccountCurrency: { required: 'Debe indicar la moneda de la cuenta para reembolso' },
                Province: { required: 'Debe indicar el Provincia' },
                Canton: { required: 'Debe indicar el Cantón' },
                District: { required: 'Debe indicar el Distrito' },
                AddressDetail: { required: 'Debe indicar el Dirección' },
            }
        });
    }

    function beneficiarios_table_setup() {

        $('#beneficiariosTbl').bootstrapTable({
            uniqueId: 'beneficiariosId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'BDocumentNumber',
                    title: 'Identificación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'BFirstName',
                    title: 'Nombres',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'BLastName',
                    title: 'Apellidos',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'BBirthDate',
                    title: 'Fecha de nacimiento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'BRelationshipDesc',
                    title: 'Parentesco',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'BParticipationRate',
                    title: 'Porcentaje',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: true
                }, {
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un visualizations',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'beneficiariosTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del visualizations de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del visualizations de la fila"> <i class="fa fa-close"></i> </button>';
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

        $('#beneficiariosNew').click(function () {
            beneficiarios_table_row_edit();
        });

        $('#beneficiariosEdtFormSave').click(function () {
            if (app.ui.IsValid('#beneficiariosEdtForm', false)) {
                app.ui.ButtonDoing('#beneficiariosEdtFormSave');

                var row = beneficiarios_table_row('values');

                if (row.beneficiariosId === null)
                    row.beneficiariosId = 1;

                if ($('#beneficiariosModal').data('id') != null) {
                    $('#beneficiariosTbl').bootstrapTable('updateByUniqueId', { id: row.beneficiariosId, row: row });
                }
                else {
                    $('#beneficiariosTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#beneficiariosEdtFormSave')
                $('#beneficiariosModal').modal('hide');
                beneficiarios_table_OtherValidations();
            }
        });

    }

    function beneficiarios_table_row(mode) {
        if (mode == null) {
            return {
                beneficiariosId: null,
                BDocumentType: null,
                BDocumentNumber: null,
                BFirstName: null,
                BLastName: null,
                BBirthDate: null,
                BRelationship: null,
                BRelationshipDesc: null,
                BParticipationRate: null
            };
        }
        else {
            return {
                beneficiariosId: $('#beneficiariosModal').data('id'),
                BDocumentType: $('#BDocumentNumberType').data("value"),
                BDocumentNumber: $('#BDocumentNumber').val(),
                BFirstName: $('#BFirstName').val(),
                BLastName: $('#BLastName').val(),
                BBirthDate: app.ui.GetDateValue('#BBirthDate'),
                BRelationship: $('#BRelationship').val(),
                BRelationshipDesc: $("#BRelationship option:selected").text(),
                BParticipationRate: app.ui.GetNumericValue('#BParticipationRate')

            };
        }
    }

    function beneficiarios_table_row_edit(row) {
        var md = $('#beneficiariosModal').modal({ show: false });
        var formInstance = $("#beneficiariosEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || beneficiarios_table_row();
        md.data('id', row.beneficiariosId);

        app.ui.SetDocumentTypeValue('#BDocumentNumberType', row.BDocumentType);
        $('#BDocumentNumber').val(row.BDocumentNumber);
        $('#BFirstName').val(row.BFirstName);
        $('#BLastName').val(row.BLastName);
        app.ui.SetDateValue('#BBirthDate', row.BBirthDate);
        $('#BRelationship').val(row.BRelationship);
        app.ui.SetNumericValue('#BParticipationRate', row.BParticipationRate);


        md.modal('show');
    }

    function beneficiarios_table_row_delete(row) {
        $('#beneficiariosTbl').bootstrapTable('removeByUniqueId', row.beneficiariosId);
        beneficiarios_table_OtherValidations();
    }

    function beneficiarios_table_Validations() {
        app.ui.DateValidators();
        $("#beneficiariosEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                BDocumentNumber: { required: true },
                BFirstName: { required: true },
                BLastName: { required: true },
                BBirthDate: { required: true },
                BRelationship: { required: true },
                BParticipationRate: { required: true }
            },
            messages: {
                BDocumentNumber: { required: 'Debe indicar la identificación' },
                BFirstName: { required: 'Debe indicar el nombres' },
                BLastName: { required: 'Debe indicar el apellidos' },
                BBirthDate: { required: 'Debe indicar el fecha de nacimiento' },
                BRelationship: { required: 'Debe indicar el parentesco' },
                BParticipationRate: { required: 'Debe indicar el porcentaje' }
            }
        });
    }

    function beneficiarios_table_OtherValidations() {
        var result = true;
        if (localStorage.getItem('Tenant') === 'Bayer') {
            var beneficiarios = $('#beneficiariosTbl').bootstrapTable('getData');

            if (beneficiarios.length === 0) {
                result = false;
                $('#beneficiariosTbl-error').text('Debe existir al menos un beneficiario');
                $('#beneficiariosTbl-error').removeClass('d-none');
            }
            else if (beneficiarios.reduce((total, item) => total + item.BParticipationRate, 0) != 100) {
                result = false;
                $('#beneficiariosTbl-error').text('El total del porcentaje de participación debe ser el 100%');
                $('#beneficiariosTbl-error').removeClass('d-none');
            }
            else {
                $('#beneficiariosTbl-error').text('');
                $('#beneficiariosTbl-error').addClass('d-none');
            }
        }

        return result;
    }

    function dependientes_table_setup() {

        $('#dependientesTbl').bootstrapTable({
            uniqueId: 'dependientesId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'DDocumentNumber',
                    title: 'Identificación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'DFirstName',
                    title: 'Nombres',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'DLastName',
                    title: 'Apellidos',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'DBirthDate',
                    title: 'Fecha de nacimiento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'DRelationshipDesc',
                    title: 'Parentesco',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un visualizations',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'dependientesTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del visualizations de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del visualizations de la fila"> <i class="fa fa-close"></i> </button>';
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

        $('#dependientesNew').click(function () {
            dependientes_table_row_edit();
        });

        $('#dependientesEdtFormSave').click(function () {
            if (app.ui.IsValid('#dependientesEdtForm', false)) {
                app.ui.ButtonDoing('#dependientesEdtFormSave');

                var row = dependientes_table_row('values');

                if (row.dependientesId === null)
                    row.dependientesId = 1;

                if ($('#dependientesModal').data('id') != null) {
                    $('#dependientesTbl').bootstrapTable('updateByUniqueId', { id: row.dependientesId, row: row });
                }
                else {
                    $('#dependientesTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#dependientesEdtFormSave')
                $('#dependientesModal').modal('hide');
            }
        });

    }

    function dependientes_table_row(mode) {
        if (mode == null) {
            return {
                dependientesId: null,
                DDocumentType: null,
                DDocumentNumber: null,
                DFirstName: null,
                DLastName: null,
                DBirthDate: null,
                DRelationship: null,
                DRelationshipDesc: null,
                DInclusionDate: new Date()
            };
        }
        else {
            return {
                dependientesId: $('#dependientesModal').data('id'),
                DDocumentType: $('#DDocumentNumberType').data("value"),
                DDocumentNumber: $('#DDocumentNumber').val(),
                DFirstName: $('#DFirstName').val(),
                DLastName: $('#DLastName').val(),
                DBirthDate: app.ui.GetDateValue('#DBirthDate'),
                DRelationship: $('#DRelationship').val(),
                DRelationshipDesc: $("#DRelationship option:selected").text(),
                DInclusionDate: app.ui.GetDateValue('#DInclusionDate'),
            };
        }
    }

    function dependientes_table_row_edit(row) {
        var md = $('#dependientesModal').modal({ show: false });
        var formInstance = $("#dependientesEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || dependientes_table_row();
        md.data('id', row.dependientesId);

        app.ui.SetDocumentTypeValue('#DDocumentNumberType', row.DDocumentType);
        $('#DDocumentNumber').val(row.DDocumentNumber);
        $('#DFirstName').val(row.DFirstName);
        $('#DLastName').val(row.DLastName);
        app.ui.SetDateValue('#DBirthDate', row.DBirthDate);
        $('#DRelationship').val(row.DRelationship);
        app.ui.SetDateValue('#DInclusionDate', row.DInclusionDate);

        md.modal('show');
    }

    function dependientes_table_row_delete(row) {
        $('#dependientesTbl').bootstrapTable('removeByUniqueId', row.dependientesId);
    }

    function dependientes_table_Validations() {
        app.ui.DateValidators();
        $("#dependientesEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                DDocumentNumber: { required: true },
                DFirstName: { required: true },
                DLastName: { required: true },
                DBirthDate: { required: true },
                DRelationship: { required: true },
                DInclusionDate: { required: true }
            },
            messages: {
                DDocumentNumber: { required: 'Debe indicar el Identificación' },
                DFirstName: { required: 'Debe indicar el Nombres' },
                DLastName: { required: 'Debe indicar el Apellidos' },
                DBirthDate: { required: 'Debe indicar el fecha de nacimiento' },
                DRelationship: { required: 'Debe indicar el parentesco' },
                DInclusionDate: { required: 'Debe indicar el fecha de inclusión' }
            }
        });
    }

    function b64StrtoBlob(b64Data, contentType, sliceSize) {
        contentType = contentType || '';
        sliceSize = sliceSize || 512;
        var byteCharacters = atob(b64Data);
        var byteArrays = [];
        for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
            var slice = byteCharacters.slice(offset, offset + sliceSize);
            var byteNumbers = new Array(slice.length);
            for (var i = 0; i < slice.length; i++) {
                byteNumbers[i] = slice.charCodeAt(i);
            }
            var byteArray = new Uint8Array(byteNumbers);
            byteArrays.push(byteArray);
        }
        var blob = new Blob(byteArrays, { type: contentType });
        return blob;
    }

    function data_changed(e) {
        var elementId = e.currentTarget.id;
        if (elementId == 'IsLife' || elementId == 'MonthlySalary') {
            var insuredAmount = 0;
            switch (app.ui.GetDropDownStringValue('#IsLife')) {
                case 'A':
                    insuredAmount = app.ui.GetNumericValue('#MonthlySalary') * 24;
                    break;
                case 'B':
                    insuredAmount = app.ui.GetNumericValue('#MonthlySalary') * 30;
                    break;
                case 'C':
                    insuredAmount = app.ui.GetNumericValue('#MonthlySalary') * 24;
                    break;
            }
            app.ui.SetNumericValue('#InsuredAmount', insuredAmount);
        }
    }

    function DocumentTypeHandler(el, element, type, callbackDocumentType) {
        var btn = $(el).parent().parent().find('.btn');
        var value = $(el).data('value');
        btn.text($(el).text());
        btn.data('value', value);
        event.preventDefault();

        if (type == 'Identification') {
            switch (value) {
                case 1: //Cédula física 9 
                    $(element).val('');
                    $(element).formatter().resetPattern('{{9}}{{9999}}{{9999}}');
                    $(element).attr('placeholder', 'XXXXXXXXX');
                    break;
                case 2: //DIME 11 o 12  12 DÍGITOS Y DEBE INICIAR CON “1”: 1XXX-XXXXXX-XX
                    $(element).val('');
                    $(element).formatter().resetPattern('{{9999}}{{999999}}{{99}}');
                    $(element).attr('placeholder', 'XXXXXXXXXXXX');
                    break;
                case 3: //Pasaporte 14 DÍGITOS: XXXXXXXXXXXXXX
                    $(element).val('');
                    $(element).formatter().resetPattern('{{**************}}');
                    $(element).attr('placeholder', 'XXXXXXXXXXXXXX');
                    break;
                case 4: // Cédula jurídica 10
                    $(element).val('');
                    $(element).formatter().resetPattern('{{9999999999}}');
                    $(element).attr('placeholder', 'XXXXXXXXXX');
                    break;
            }
        }
        if (callbackDocumentType !== undefined && callbackDocumentType !== null) {
            callbackDocumentType(value);
        }
    }

    function IsDocumentNumberValid (documentType, documentNumber) {
        var result = false;
        var length = documentNumber.length;

        switch (documentType) {
            case 1: //9 DIGITOS: XXXXXXXXX
                result = (length === 9);
                break;
            case 2: //12 DÍGITOS Y DEBE INICIAR CON “1”: 1XXX-XXXXXX-XX
                result = (length === 12);
                break;
            case 3: //14 DÍGITOS: PASXXXXXXXXXXXXXX
                result = (length >= 3 && length <= 14);
                break;
            case 4:
                result = (length >= 7 && length <= 14);
                break;
        }
        return result;
    }


    return {
        Init: function () {
            Controls_setup();
            Setup_Validations();
            beneficiarios_table_setup();
            beneficiarios_table_Validations();
            dependientes_table_setup();
            dependientes_table_Validations();

            Controls_Events();

            var _id = app.core.URLNumericValue('id');
            if (_id !== 0) {
                Setup(_id);
            }
            else {
                Setup(null);
            }
        },
        beneficiariosEditRow: function (row) {
            beneficiarios_table_row_edit(row);
        },
        beneficiariosDeleteRow: function (row) {
            beneficiarios_table_row_delete(row);
        },
        dependientesEditRow: function (row) {
            dependientes_table_row_edit(row);
        },
        dependientesDeleteRow: function (row) {
            dependientes_table_row_delete(row);
        }
    };
})();

window.beneficiariosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar a '" + row.BFirstName + ' ' + row.BLastName + "' como beneficiario, haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.BayerInclusion.beneficiariosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.BayerInclusion.beneficiariosEditRow(row);
        e.stopPropagation();
    }
};

window.dependientesTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar a '" + row.DFirstName + ' ' + row.DLastName + "' como dependiente, haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.BayerInclusion.dependientesDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.BayerInclusion.dependientesEditRow(row);
        e.stopPropagation();
    }
};