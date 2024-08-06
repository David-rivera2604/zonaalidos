class Form_Ext_GarantiaNotificar {

    ctx = {};

    async InitWarranty(code) {
        app.core.Get(app.setting.apipath + `v1/Security/Profile`)
            .done(function (data) {
                app.Form_Ext_GarantiaNotificar.ctx.SetData({ Guarantee_number: code, Guarantee_sequencenumber: '00', Moneda: 'CRC', Issue_date: app.ui.Today(), Guarantee_type_code: 'BG', Guarantee_payment_code: '07', Guarantee_identifier: '3101560179', Guarantee_name: 'MAPFRE SEGUROS COSTA RICA SOCIEDAD ANONIMA', Guarantee_charge_person_name: localStorage.getItem('Username'), Guarantee_charge_person_email: data.EMail, Guarantee_telephone_number: data.PhoneNumber });
            });
    };

    async GetWarranty(code, linked, callback) {
        app.core.dataapi('GET', `ElectronicWarranty/Guarantee?code=${code}`)
            .then(warranty => {
                callback(code, linked, warranty);
            });
    };

    async Proveedor(supplierId, callback) {
        let result = null;
        app.core.Get(app.setting.apipath + `v1/SICOP/InformacionProveedor?id=${supplierId}`)
            .done(function (data) {
                callback(data);
            });
    }

    async ProcWarranty(code, linked, warranty) {
        if (warranty != null) {
            warranty.Guarantee_sequencenumber = (Number(warranty.Guarantee_sequencenumber) + 1).toString().padStart(2, '0');
            app.Form_Ext_GarantiaNotificar.ctx._datasrc.warranty = warranty;
            app.Form_Ext_GarantiaNotificar.ctx.SetData(warranty);

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
            app.Form_Ext_GarantiaNotificar.InitWarranty(code);
            $('.Tipo_de_modificationToggle').addClass('d-none');
        }
    };

    async SendWarranty(entry) {
        $('#generalNotify').html('');
        app.ui.ButtonDoing('#btnNotify');

        if (entry.Tipo_de_modification == undefined)
            entry.Tipo_de_modification = '';

        app.core.dataapi('POST', 'ElectronicWarranty', entry)
            .then(warranty => {
                if (warranty != null) {
                    entry.ID = warranty.Next.Data.NEXTID;
                    app.core.Post(app.setting.apipath + 'v1/SICOP/NotificarGarantia', JSON.stringify(entry))
                        .done(function (posted) {
                            if (posted != null) {
                                entry.Confirmation = posted.Confirmation;
                                entry.Msg_err = posted.Msg_err;
                                app.core.dataapi('PUT', `ElectronicWarranty/Notify/${entry.ID}`, { ID: entry.ID, Confirmation: posted.Confirmation, Msg_err: posted.Msg_err })
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
    };

    async Init(spec, formName) {
        spec._datasrc = {};
        this.ctx = spec;

        $('#Issue_date_group').data("DateTimePicker").minDate(app.ui.Today());

        let code = app.core.URLStringValue('code', '');
        if (code != '') {
            app.Form_Ext_GarantiaNotificar.GetWarranty(code, true, this.ProcWarranty);
        } else {
            app.Form_Ext_GarantiaNotificar.InitWarranty(code);
        }
    }

}

var app = app || {};
app.Form_Ext_GarantiaNotificar = new Form_Ext_GarantiaNotificar();