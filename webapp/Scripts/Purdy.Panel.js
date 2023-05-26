var app = app || {};

app.PurdyPanel = (function () {

    return {
        Init: function () {
            try {
                app.ui.CommonBehaviour();

                app.PurdyPanelEncabezado.Init();
                app.PurdyPanelDetalle.Init();
                app.PurdyPanelEvento.Init();
                app.PurdyPanelDanos.Init();
                app.PurdyPanelIndemnizacion.Init();
                app.PurdyPanelnose.Init();


                console.log("Inicio");
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        }
    };
})();
