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
                app.PurdyPanelLegal.Init(app.PurdyPanel.Event);

                $('.confirm').change(function () {
                    let ctrolName = this.name;
                    let clicked = false;

                    if (app.ui.GetRadioNumericValue(ctrolName) == 1) {
                        toastr.warning('Por favor confirme el cambio de estado haciendo clic aquí',
                            'Confirmación', {
                            timeOut: 4000,
                            closeButton: true,
                            progressBar: true,
                            onclick: function () {
                                clicked = true;
                            },
                            onHidden: function () {
                                if (!clicked) {
                                    $('#' + ctrolName + '_2').click();
                                    $('#' + ctrolName + '_2').focus();
                                }
                            }
                        });
                    }


                });

                app.PurdyPanelEncabezado.Called();
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Event: async function (src, data) {
            //console.log(src, _data, data);
            switch (src) {
                case 'ASIGESChange':
                    if (data != null) {
                        _data.asiges = data.ASIGES;
                    }
                    _data.claim = data;
                    break;
                case 'PolicyChange', 'PolicyRolesChange', 'PolicyDataChange':
                    _data.policy = data;
                    break;
                case 'EventoDataChange':
                    _data.event = data;
                    break;
                case 'DanosDataChange':
                    _data.damage = data;
                    break;
                case 'BalanceDataChange':
                    _data.balance = data;
                    break;
                case 'DetalleDataChange':
                    _data.detail = data;
                    break;
                case 'RecuperacionDataChange':
                    _data.recovery = data;
                    break;                    
            }
            app.PurdyPanelEncabezado.Event(src, _data, data);
            app.PurdyPanelDetalle.Event(src, _data, data);
            app.PurdyPanelEvento.Event(src, _data, data);
            app.PurdyPanelDanos.Event(src, _data, data);
            app.PurdyPanelIndemnizacion.Event(src, _data, data);
            app.PurdyPanelLegal.Event(src, _data, data);
        },
        Data: function (data) {
            if (data !== undefined) {
                _data = data;
            }
            return _data;
        }
    };
})();
