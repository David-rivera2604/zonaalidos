class Form_Ext_ExcludedPolicies {

    ctx = {};

    async Init(spec, formName) {
        let options = spec.Options();
        this.ctx = spec;

        $(`#${formName}EdtForm`).validate(); $("#NUM_POLIZA").rules('add', { minlength: 13, messages: { minlength: "Por favor, ingrese al menos {0} caracteres" } });

        options.Events = function (field, data, source) {
            switch (field) {
                case '#polizasexcluidasTbl':
                    switch (source) {
                        case 'AddRow':
                        case 'UpdateRow':
                        case 'DeleteRow':
                            let entry = app.Form_Ext_ExcludedPolicies.ctx.Data();
                            app.core.Post(app.setting.apipath + 'v1/CustomData', JSON.stringify({ EntityType: 1971, EntityId: 1, Key1: 'ExcludedPolicies', Data: JSON.stringify(entry) }))
                                .done(function (posted) { });
                            break;
                    }
                    break;
            }
        };
        spec.SetOptions(options);

        $('.ibox-content').toggleClass('sk-loading');

        app.core.Lookups(options.Lookups, function () { }, options.Base);

        app.core.Get(app.setting.apipath + `v1/CustomData/ExcludedPolicies/1971`)
            .done(function (data) {
                app.Form_Ext_ExcludedPolicies.ctx.SetData(JSON.parse(data.Data));
            }).fail(function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 404) {
                    app.Form_Ext_ExcludedPolicies.ctx.SetData([]);
                }
            }).always(function () {
                $('.ibox-content').toggleClass('sk-loading');
            });
    }
}
var app = app || {};
app.Form_Ext_ExcludedPolicies = new Form_Ext_ExcludedPolicies();