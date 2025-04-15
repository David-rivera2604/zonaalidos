var app = app || {};

app.Form_Ext_SICOP = (function () {

    let id = null;
    let oldValue = '';
    let _warranty = null;

    async function NotificarGarantia(spec, formName) {

        $(`#${formName}EdtForm`).validate(); $("#Guarantee_sequencenumber").rules('add', { minlength: 2, messages: { minlength: "Por favor ingrese al menos {0} caracteres" } });

        $(`#${formName}EdtForm`).validate(); $("#Institution_identifier").rules('add', { minlength: 10, messages: { minlength: "Por favor ingrese al menos {0} caracteres" } });
        $(`#${formName}EdtForm`).validate(); $("#Supplier_identifier").rules('add', { minlength: 10, messages: { minlength: "Por favor ingrese al menos {0} caracteres" } });
        $(`#${formName}EdtForm`).validate(); $("#Guarantee_identifier").rules('add', { minlength: 10, messages: { minlength: "Por favor ingrese al menos {0} caracteres" } });

        //('#Issue_date_group').data("DateTimePicker").minDate(app.ui.Today());

        $('#Guarantee_number').change(function (e) {
            let guarantee_number = $('#Guarantee_number').val();
            if ($('#Guarantee_number').valid()) {
                GetWarranty(spec, guarantee_number, false, ProcWarranty);
            }
        });

        $('#Supplier_identifier').change(function (e) {
            let supplier_identifier = $('#Supplier_identifier').val();
            if ($('#Supplier_identifier').valid()) {
                Proveedor(supplier_identifier, function (info) {
                    $("#Supplier_name").val(info.Msg_err == '' ? info.SUPPLIER_NM : '');
                });
            }
        });

        $('#btnNotify').click(function (e) {
            if (spec.IsValid(true)) {
                $('#generalNotify').html('');
                app.ui.ButtonDoing('#btnNotify');
                let entry = spec.Data();
                if (entry.Tipo_de_modification == undefined)
                    entry.Tipo_de_modification = '';

                app.core.datapi('POST', 'ElectronicWarranty', entry)
                    .then(warranty => {
                        if (warranty != null) {
                            entry.ID = warranty.Next.NEXTID;
                            app.core.Post(app.setting.apipath + 'v1/SICOP/NotificarGarantia', JSON.stringify(entry))
                                .done(function (posted) {
                                    if (posted != null) {
                                        entry.Confirmation = posted.Confirmation;
                                        entry.Msg_err = posted.Msg_err;
                                        app.core.datapi('PUT', `ElectronicWarranty/Notify/${entry.ID}`, { ID: entry.ID, Confirmation: posted.Confirmation, Msg_err: posted.Msg_err })
                                            .then(xx => {
                                                console.log(xx);
                                            });
                                        if (posted.Confirmation != '0') {
                                            app.ui.Error(posted.Msg_err);
                                            app.ui.ShowAlert('generalNotify', 'alert-danger', `<b> <i class="fa fa-check"></i> ${posted.Msg_err}</b>`);
                                        } else {
                                            let msg = 'Se ha realizado la notificación de forma exitosa';
                                            if (entry.Tipo_de_modification != '')
                                                msg = 'Se ha realizado la modificación de forma exitosa';
                                            app.ui.Success(posted.msg);
                                            app.ui.ShowAlert('generalNotify', 'alert-success', `<b> <i class="fa fa-check"></i> ${msg}</b>`);
                                            $("#NotificarGarantiaEdtForm fieldset").prop("disabled", true);
                                            $("#btnNotify").addClass('d-none');
                                        }
                                        window.scrollTo({ top: 0, behavior: 'smooth' });
                                    }
                                });
                        }
                    }).finally(() => {
                        app.ui.ButtonDone('#btnNotify');
                    });
            }
            e.preventDefault();
        });

        let code = app.core.URLStringValue('code', '');
        if (code != '') {
            GetWarranty(spec, code, true, ProcWarranty);
        } else {
            InitWarranty(spec);
        }
    };

    async function InitWarranty(spec, code) {
        app.core.Get(app.setting.apipath + `v1/Security/Profile`)
            .done(function (data) {
                console.log(data);
                spec.SetData({ Guarantee_number: code, Guarantee_sequencenumber: '00', Moneda: 'CRC', Issue_date: app.ui.Today(), Guarantee_type_code: 'BG', Guarantee_payment_code: '07', Guarantee_identifier: '3101560179', Guarantee_name: 'MAPFRE SEGUROS COSTA RICA SOCIEDAD ANONIMA', Guarantee_charge_person_name: localStorage.getItem('Username'), Guarantee_charge_person_email: data.EMail, Guarantee_telephone_number: data.PhoneNumber });
            });

    };

    async function ProcWarranty(spec, code, linked, warranty) {
        if (warranty != null) {
            id = null;
            warranty.Guarantee_sequencenumber = (Number(warranty.Guarantee_sequencenumber) + 1).toString().padStart(2, '0');
            spec.SetData(warranty);
            $('.Tipo_de_modificationToggle').removeClass('d-none');

            $('#Guarantee_number').prop("disabled", true);
            $('[name=Guarantee_type_code]').prop("disabled", true);
            $('#Guarantee_payment_code').prop("disabled", true);
            $('#Guarantee_charge_person_name').prop("disabled", true);
            $('#Guarantee_charge_person_email').prop("disabled", true);
            $('#Guarantee_telephone_number').prop("disabled", true);
            $('#Guarantee_postal_code').prop("disabled", true);
            $('#Guarantee_address_line').prop("disabled", true);

            $('#Institucion_notice_number').prop("disabled", true);
            $('#Notice_number').prop("disabled", true);
            $('#Supplier_identifier').prop("disabled", true);
            $('#Institution_identifier').prop("disabled", true);
            $('#btnNotify').html("Modificar");
            if (!linked) {
                app.ui.Info(`La garantía con el número ${code} ya esta registrada, la información de la misma fue cargada`);
            }
        } else {
            id = null;
            InitWarranty(spec, code);
            $('.Tipo_de_modificationToggle').addClass('d-none');
        }
    };

    async function GetWarranty(spec, code, linked, callback) {
        app.core.datapi('GET', `ElectronicWarranty/Guarantee?code=${code}`)
            .then(warranty => {
                callback(spec, code, linked, warranty?.Guarantee);
            });
    };

    async function NotificarLiberacion(spec, formName) {
        $('#btnNotify').click(function (e) {
            if (spec.IsValid(true)) {
                $('#generalNotify').html('');
                app.ui.ButtonDoing('#btnNotify');
                let entry = spec.Data();
                entry.ID = id;
                console.log(entry);

                app.core.Post(app.setting.apipath + 'v1/SICOP/NotificarLiberacion', JSON.stringify(entry))
                    .done(function (posted) {
                        console.log(posted);

                        if (posted.Msg_err == '') {
                            if (_warranty.Ex_Metodo == '1')
                                _warranty.Ex_Metodo = '9';
                            else
                                _warranty.Ex_Metodo = '8';
                        }
                        app.core.datapi('PUT', `ElectronicWarranty/Release`, { ID: entry.ID, Confirmation: posted.Confirmation, Msg_err: posted.Msg_err, Execute_release_contents: entry.Execute_release_contents, Transaction_num: entry.Transaction_num, Date_time: entry.Date_time, Ex_Metodo: _warranty.Ex_Metodo })
                            .then(xx => {
                                console.log(xx);
                            });

                        if (posted.Msg_err != '') {
                            app.ui.Error(posted.Msg_err);
                            app.ui.ShowAlert('generalNotify', 'alert-danger', `<b> <i class="fa fa-check"></i> ${posted.Msg_err}</b>`);
                        } else {
                            if (_warranty.Ex_Metodo == '9')
                                posted.Msg_err = 'Liberación exitosa';
                            else
                                posted.Msg_err = 'Ejecución exitosa';

                            app.ui.Success(posted.Msg_err);
                            app.ui.ShowAlert('generalNotify', 'alert-success', `<b> <i class="fa fa-check"></i> ${posted.Msg_err}</b>`);
                            $("#NotificarGarantiaEdtForm fieldset").prop("disabled", true);
                            $("#btnNotify").addClass('d-none');
                        }
                        window.scrollTo({ top: 0, behavior: 'smooth' });
                    }).always(function () {
                        app.ui.ButtonDone('#btnNotify');
                    });
            }
            e.preventDefault();
        });

        let code = app.core.URLStringValue('code');
        if (code != '') {
            GetWarranty(spec, code, true, ProcWarrantyLib);
        }
    };

    async function ProcWarrantyLib(spec, code, linked, warranty) {
        id = warranty.ID;
        warranty.Cuenta_cliente = warranty.Ex_Cuenta_cliente;
        warranty.Execute_release_amount = warranty.Ex_Amount;
        _warranty = warranty;
        spec.SetData(warranty);
    };

    async function InformacionProveedor(spec, formName) {
        $.validator.addMethod("NotFound", function (value, element, params) {
            return oldValue == '' || oldValue != value;
        });

        $(`#${formName}EdtForm`).validate(); $("#SUPPLIER_ID").rules('add', { minlength: 7, messages: { minlength: "Por favor ingrese al menos {0} caracteres" } });
        $(`#${formName}EdtForm`).validate(); $("#SUPPLIER_ID").rules('add', { NotFound: true });

        $('#btnSearch').click(function (e) {
            oldValue = '';
            if (spec.IsValid(true)) {
                app.ui.ButtonDoing('#btnSearch');
                let entry = spec.Data();

                app.core.Get(app.setting.apipath + `v1/SICOP/InformacionProveedor?id=${entry.SUPPLIER_ID}`)
                    .done(function (data) {
                        console.log(data);
                        data.SUPPLIER_ID = entry.SUPPLIER_ID;
                        spec.SetData(data);
                        if (data.Msg_err != '') {
                            oldValue = entry.SUPPLIER_ID;
                            $.validator.messages.NotFound = data.Msg_err;
                            app.ui.Error(data.Msg_err);
                            spec.IsValid(false);
                        }
                    }).always(function () {
                        app.ui.ButtonDone('#btnSearch');
                    });
            }
            e.preventDefault();
        });
    };

    function Proveedor(supplierId, callback) {
        let result = null;
        app.core.Get(app.setting.apipath + `v1/SICOP/InformacionProveedor?id=${supplierId}`)
            .done(function (data) {
                callback(data);
            });
    };

    return {
        Init: function (spec, formName) {

            //spec['Changed'](function (data) { console.log(data); });

            switch (formName) {
                case 'InformacionProveedor':
                    InformacionProveedor(spec, formName);
                    break;
                case 'NotificarGarantia':
                    NotificarGarantia(spec, formName);
                    break;
                case 'NotificarLiberacion':
                    NotificarLiberacion(spec, formName);
                    break;
            }

        },
        Boton: function () {
            return {
                btnExclude: {
                    text: 'Crea una garantía',
                    icon: 'fa-plus',
                    event: function () {
                        app.ui.Redirect('../viewer/Form?id=NotificarGarantia');
                    },
                    attributes: {
                        title: 'Permite crea una nueva garantía electrónica'
                    }
                }
            };
        },
        ActionFormatter: function (value, row, index, field) {
            let buttons = '<button name="editar"  type="button" class="btn btn-sm btn-white event" title="Permite modificar la garantía"><i class="fa fa-pencil"></i></button>';

            if (row.EX_METODO == '0' || row.EX_METODO == '1') {
                buttons += '<button name="liberar" type="button" class="btn btn-sm btn-white event" title="Permite liberar/ejecutar la garantía"><i class="fa fa-asterisk text-danger"></i></button>';
            }
            return '<span class=columnBtn>' + buttons + '</span>';
        },
        EstadoFormatter: function (value, row, index, field) {
            let desc = 'Activa';
            let color = 'primary';

            switch (value) {
                case '0': desc = 'Ejecutar'; color = 'danger'; break;
                case '1': desc = 'Liberar'; color = 'warning'; break;
                case '8': desc = 'Ejecutado'; color = 'primary'; break;
                case '9': desc = 'Liberado'; color = 'success'; break;
            }
            if (value == null)
                return desc;
            else
                return '<span class="badge badge-' + color + '">' + desc + '</span>';
        }
    };
})();