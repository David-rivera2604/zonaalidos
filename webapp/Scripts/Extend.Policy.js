var app = app || {};

app.Ex_Policy = (function () {
    return {
        Cancelar: function (num_poliza) {
            if (app.Prototype.IsValid()) {
                let data = app.Prototype.Data();
                app.ui.ButtonDoing('#CancelarBtn');
                app.core.Put(app.setting.apipath + `v1/Poliza/${num_poliza}/Cancelacion`, JSON.stringify(data))
                    .done(function (data) {
                    }).always(function () {
                        app.ui.ButtonDone('#CancelarBtn');
                        $('#right-sidebar').toggleClass('sidebar-open');
                        app.ViewerQuery.Refresh(undefined, $('#1GridTbl'), 300);
                    });
            }
        }
    };
})();