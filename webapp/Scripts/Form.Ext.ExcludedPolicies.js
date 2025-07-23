class Form_Ext_ExcludedPolicies {

    ctx = {};

    eventsHandler(field, data, source) {
        switch (field) {
            case '#polizasexcluidasTbl':
                switch (source) {
                    case 'NewEditRow':
                        app.core.LookupDependency(data.NUM_POLIZA, 'NUM_CONTRATO', 'CONTRATO_POLIZA_GRUPO', '', data.NUM_CONTRATO, true, null, `num_poliza=`);
                        break;
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
    }

    async Init(spec, formName) {
        let options = spec.Options();
        this.ctx = spec;

        options.Events = this.eventsHandler;
        spec.SetOptions(options);

        $('.ibox-content').toggleClass('sk-loading');

        app.core.Lookups(options.Lookups, function () {
            $('#NUM_POLIZA').on('change', function () {
                app.core.LookupDependency($('select#NUM_POLIZA').val(), 'NUM_CONTRATO', 'CONTRATO_POLIZA_GRUPO', '', null, true, null, `num_poliza=`);
            });
        }, options.Base);

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