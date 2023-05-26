var app = app || {};

app.PurdyPanel = (function () {

    _data = { claim: null };

    return {
        Init: function () {
            try {
                app.ui.CommonBehaviour();

                app.PurdyPanelEncabezado.Init(app.PurdyPanel.Event);
                app.PurdyPanelDetalle.Init(app.PurdyPanel.Event);
                app.PurdyPanelEvento.Init(app.PurdyPanel.Event);
                app.PurdyPanelDanos.Init(app.PurdyPanel.Event);
                app.PurdyPanelIndemnizacion.Init(app.PurdyPanel.Event);
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Event: function (src, data) {
            switch (src) {
                case 'ASIGESChange':
                    _data.claim = data;
                    app.PurdyPanelDetalle.Event(src, _data);
                    break;
                case 'PolicyChange', 'PolicyRolesChange', 'PolicyDataChange':
                    _data.policy = data;
                    break;
            }

        },
        Data: function (data) {
            if (data !== undefined) {
                _data = data;
            }
            return _data;
        }
    };
})();
