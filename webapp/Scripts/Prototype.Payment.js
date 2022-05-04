var app = app || {};

app.PrototypePayment = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {

        let data = {
            FirstName: 'Nelson',
            LastName: 'Soler',
            Email: 'solernelson@hotmail.com',
            DocumentType: '2',
            Document: '186200170219',
            Mobile: '72155569',
            PolicyId: '3001510108954',
            BillNumber: '0000907640',
            Description: 'MAPFRE: NUEVA PÓLIZA LÍDER #3001510108954 FACTURA #0000907640',
            Currency: '1',
            Amount: 53909.96,
        };
        setupData = data;
        MapObjectToInput(data);
    };

    function MapInputToObject() {
        var data = {
            FirstName: $('#FirstName').val(),
            LastName: $('#LastName').val(),
            Email: $('#Email').val(),
            DocumentType: app.ui.GetDropDownNumericValue('#DocumentType'),
            Document: $('#Document').val(),
            Mobile: $('#Mobile').val(),
            PolicyId: $('#PolicyId').val(),
            BillNumber: $('#BillNumber').val(),
            Description: $('#Description').val(),
            Currency: app.ui.GetDropDownNumericValue('#Currency'),
            Amount: app.ui.GetNumericValue('#Amount'),
        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#FirstName').val(data.FirstName);
        $('#LastName').val(data.LastName);
        $('#Email').val(data.Email);
        $('#DocumentType').val(data.DocumentType);
        app.ui.SetDropDownStringValue('#DocumentType', data.DocumentType, true, '2');
        $('#Document').val(data.Document);
        $('#Mobile').val(data.Mobile);
        $('#PolicyId').val(data.PolicyId);
        $('#BillNumber').val(data.BillNumber);
        $('#Description').val(data.Description);
        $('#Currency').val(data.Currency);
        app.ui.SetDropDownStringValue('#Currency', data.Currency, true, '1');
        app.ui.SetNumericValue('#Amount', data.Amount);

    };

    function Controls_setup() {
        $('#Mobile').formatter({
            pattern: '{{9999}}{{9999}}',
            persistent: false
        });
        new AutoNumeric('#Amount', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $("#PrototypeEdtFormSave").appendTo("#GenericToolBar");
        $("#PrototypeEdtFormCancel").appendTo("#GenericToolBar");

        //P.on('response', function (data) {
        //    console.log(data);
        //    $("#lightbox-response").html(JSON.stringify(data, null, 2));
        //});

    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#PrototypeEdtForm :input").change(function () {
            data_changed();
        });

        $('#MobileTypeMenu a').click(function () {
            app.ui.DocumentTypeHandler(this, '#Mobile', 'Phone');
        });

        $('#PrototypeEdtFormSave').click(function () {

            if (app.ui.IsValid('#PrototypeEdtForm', false)) {
                app.ui.ButtonDoing('#PrototypeEdtFormSave');
                app.core.LoadScriptFile('Payment.js')
                    .then(d => {
                        app.Payment.Process({ num_poliza: $('#PolicyId').val(), num_recibo: $('#BillNumber').val() })
                            .then(d => {
                                app.ui.ShowAlert('generalNotify', 'alert-primary', d.status);
                            })
                            .catch(err => {
                                app.ui.ShowAlert('generalNotify', 'alert-danger', d.status);
                            }).then(d => {
                                app.ui.ButtonDone('#PrototypeEdtFormSave');
                            });
                        //                        app.ui.ButtonDone('#PrototypeEdtFormSave');
                    })
                    .catch(err => {
                        console.error(err);
                        app.ui.ButtonDone('#PrototypeEdtFormSave');
                    });

                //app.core.Post(app.setting.apipath + 'v1/TronCommon/Payment', JSON.stringify(MapInputToObject()))
                //    .done(function (data) {
                //        if (data != null && data.Status == "OK") {
                //            $('#requestId').val(data.RequestId);
                //            $('#result').val('');

                //            app.core.LoadScriptFile("https://secure.placetopay.com/redirection/lightbox.min.js")
                //                .then(d => {
                //                    P.on('response', function (data) {
                //                        console.log(data);
                //                        $("#result").val(JSON.stringify(data, null, 2));
                //                    });
                //                    P.init(data.ProcessUrl);
                //                })
                //                .catch(err => {
                //                    console.error(err);
                //                });

                //            //window.location.href = data.ProcessUrl;
                //            //P.init('https://checkout.davivienda.cr/session/4455/54ace06a5c65cc07e103ec6c69fc9495');
                //           // P.init(data.ProcessUrl);
                //            //P.init(processUrl, { opacity: 0.4 });
                //        }
                //        else {
                //            app.ui.ShowAlert('generalNotify', 'alert-danger', data.Reason);
                //        }
                //        console.log(data);

                //    }).always(function () {
                //        app.ui.ButtonDone('#PrototypeEdtFormSave');
                //    });
            }
            event.preventDefault();
        });

        $('#PrototypeEdtFormCancel').click(function () {
            if (app.ui.IsValid('#PrototypeEdtForm', false)) {
                app.ui.ButtonDoing('#PrototypeEdtFormCancel');

                app.core.Post(app.setting.apipath + 'v1/Pagos/Sesion/' + $('#requestId').val(), null)
                    .done(function (data) {
                        console.log(data);
                        $('#result').val(JSON.stringify(data));

                    }).always(function () {
                        app.ui.ButtonDone('#PrototypeEdtFormCancel');
                    });
            }
            event.preventDefault();
        });

    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#PrototypeEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                Email: { required: true, email: true },
                Mobile: { required: true },
            },
            messages: {
                Email: { required: 'Debe indicar el Correo electrónico', email: 'Debe indicar un correo electrónico valido' },
                Mobile: { required: 'Debe indicar el Número de teléfono' },
            }
        });
    };



    return {
        Init: function () {
            $("body").toggleClass("mini-navbar");
            try {
                Controls_setup();
                Setup_Validations();

                Controls_Events();
                Setup();
                console.log("Inicio");
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Data: function () {
            return MapInputToObject();
        },
        Changed: function (callback) {
            changedCallback = callback;
        },
        IsValid: function (showResume) {
            return app.ui.IsValid('#PrototypeEdtForm', false, showResume);
        }
    };
})();
