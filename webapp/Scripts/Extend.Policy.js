var app = app || {};

app.Ex_Policy = (function () {
    return {
        Cancelar: function (num_poliza) {
            if (app.Prototype.IsValid()) {
                let data = app.Prototype.Data();
                app.ui.ButtonDoing('#CancelarBtn');
                app.core.Put(app.setting.apipath + `v1/Poliza/${num_poliza}/Cancelacion`, JSON.stringify(data))
                    .done(function (res) {
                    }).always(function () {
                        app.ui.ButtonDone('#CancelarBtn');
                        app.ui.CloseSideBar();
                        app.ViewerQuery.Refresh(undefined, $('#1GridTbl'), 300);
                    });
            }
        },
        ControlTecnico_Init: function (custom, data) {
            custom.SetData({ cod_ramo: data.NOM_RAMO, causadelcontrol: data.NOM_ERROR });
            $('#cod_ramo').replaceWith('<div>' + $('#cod_ramo').val() + '</div>');
            $('#causadelcontrol').replaceWith('<div>' + $('#causadelcontrol').val() + '</div>');
        },
        ControlTecnico_Procesar: function (custom, data) {
            let row = JSON.parse(localStorage.getItem('current'));
            data.num_spto = row.NUM_SPTO;
            data.cod_error = row.COD_ERROR;
            app.ui.ButtonDoing('#procesar');
            app.core.Put(app.setting.apipath + `v1/Poliza/${row.NUM_POLIZA}/ControlTecnico`, JSON.stringify(data))
                .done(function (res) {
                }).always(function () {
                    app.ui.ButtonDone('#procesar');
                    app.ui.CloseSideBar();
                    app.ViewerQuery.Refresh(undefined, $('#1GridTbl'), 340, 1);
                });
        },
        Renovacion_Procesar: function (custom, data) {
            let row = JSON.parse(localStorage.getItem('current'));
            app.ui.ButtonDoing('#renovar');
            app.core.Put(app.setting.apipath + `v1/Poliza/${row.NUM_POLIZA}/Renovar`, null)
                .done(function (res) {
                }).always(function () {
                    app.ui.ButtonDone('#renovar');
                    app.ui.CloseSideBar();
                    app.ViewerQuery.Refresh(undefined, $('#1GridTbl'), 341, 1);
                });
        },
        ChangePayer: function (num_poliza_grupo, num_poliza, num_riego) {
            if (app.Prototype.IsValid()) {
                let data = app.Prototype.Data();
                app.ui.ButtonDoing('#ApplyChangeBtn');
                app.core.Put(app.setting.apipath + `v1/Poliza/${num_poliza}/CambioPagador?riesgo=${num_riego}&grupo=${num_poliza_grupo}&tipDocum=${data.DocumentNumberType}&codDocum=${data.DocumentNumber}`, JSON.stringify(data))
                    .done(function (res) {
                    }).always(function () {
                        app.ui.ButtonDone('#ApplyChangeBtn');
                        app.ui.CloseSideBar();
                        app.ViewerQuery.Refresh(undefined, $('#1GridTbl'), 300);
                    });
            }
        },
        FileUpLoad: function (entityId) {
            app.core.FileUpLoad({
                formId: '#DocumentUploadEdtForm',
                uploadCtrolId: '#archivoUploadModal',
                entityType: 3000,
                entityId: entityId,
                documentType: 99,
                description: $('#descripcion').val(),
                callback: function (fileList) {
                    $('#9002 .close').click();
                    app.ViewerQuery.Refresh(undefined, $('#6GridTbl'), 302, '', 6);
                }
            });
        }
    };
})();