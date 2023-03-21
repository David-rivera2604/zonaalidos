var app = app || {};

app.Extend = (function () {

    return {
        EmisionFormatter: function (value, row, index, field) {
            let quote = '', mode = 'resume';
            switch (row.COD_RAMO) {
                case 302:
                    quote = 'mapfremas';
                    break;
                case 401:
                    quote = 'saldodeudor';
                    break;
                case 441:
                    quote = 'viajero';
                    break;
            }
            return quote != '' ? '<a href=' + app.setting.basepath + 'emision/' + quote
                + '?mode=' + mode
                + '&presupuesto=' + row.NUM_PRESUPUESTO + '>' + value + '</a>' : row.NUM_PRESUPUESTO;
        },
        Filter345handler: function (custom, data) {
             if (data.p_num_contrato == 0 &&
                data.p_num_poliza_grupo == 0 &&
                data.p_num_poliza == '') {
                toastr.error('Debe indicar por lo menos el valor para unos de los campos', '', { timeOut: 7000, closeButton: true, progressBar: true });
            } else {

                if (data.p_num_contrato == 0) {
                    data.p_num_contrato = null;
                }
                if (data.p_num_poliza_grupo == 0) {
                    data.p_num_poliza_grupo = null;
                }
                app.ui.ButtonDoing('#filtrar');
                app.ViewerQuery.Refresh(undefined, $('#1GridTbl'), 345, '', 1, data,
                    function () {
                        app.ui.ButtonDone('#filtrar');
                    });
            }
        },
        EventHandler: function (id, index, stage) {
            if (id == '310' && index == 2 && stage == 'loaded') {
                $("#QueryFNotify2").html('<div class="row d-none role-Pago-visible" style="padding-top: 25px;"><div class="col-9"><a href="javascript:app.master.ShowSideBarExternal(\'Preguntas y respuestas frecuentes\', \'/aliados/viewer/render?id=392&t=4&wd=400px\');" style="font-size: smaller;">Ver preguntas y respuestas frecuentes sobre pagos electrónicos</a></div><div class="col-3"><a href="https://www.placetopay.com/web/" target="_blank"><img src="https://static.placetopay.com/placetopay-logo.svg" class="img-fluid float-right" alt="Responsive image" style="width: 125px;"></a></div></div>')
            }
            if (id == '3000' && index == 1 && stage == 'loaded') {
                $("#QueryFNotify1").html('<div class="row d-none role-Pago-visible" style="padding-top: 25px;"><div class="col-9"><a href="javascript:app.master.ShowSideBarExternal(\'Preguntas y respuestas frecuentes\', \'/aliados/viewer/render?id=392&t=4&wd=400px\');" style="font-size: smaller;">Ver preguntas y respuestas frecuentes sobre pagos electrónicos</a></div><div class="col-3"><a href="https://www.placetopay.com/web/" target="_blank"><img src="https://static.placetopay.com/placetopay-logo.svg" class="img-fluid float-right" alt="Responsive image" style="width: 125px;"></a></div></div>')
            }
        }
    };
})();
