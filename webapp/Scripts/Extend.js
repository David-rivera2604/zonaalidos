var app = app || {};

app.Extend = (function () {

    return {
        AccionesClienteFormatter: function (value, row, index, field) {
            let html = [];
            html.push('<span class=columnBtn>');
            html.push('<button name=\"printr\" type=\"button\"class=\"btn btn-sm btn-white event\" title=\"Permite imprimir el recibo\"><i class=\"fa fa-print\"></i></button>');
            if (row.POS_RECIBO === 1) {
                html.push('<button type=\"button\" name=\"payment\" class=\"btn btn-sm btn-white event\" title=\"Permite pagar el recibo actual\"><i class=\"fa fa-shopping-cart\"></i></button>');
            }
            html.push('</span>');

            return html.join('');
        },
        PresupuestoFormatter: function (value, row, index, field) {
            var ramo = row.PROPOSALID.substring(0, 3);
            var producto = '';
            if (ramo == 302) { producto = 'mapfremas'; }
            if (ramo == 201) { producto = 'hogartotal'; }
            if (ramo == 202) { producto = 'multirriesgo'; }
            if (ramo == 401) { producto = 'SaldoDeudor'; }
            return (row.STATUS === 33 ?
                `<a href='${app.setting.basepath}emision/${producto}?mode=continue&presupuesto=${row.PROPOSALID}'>${value}</a>`
                : `<span>${value}</span>`) 
                + `<button type='button' name='deleteprop' class='btn btn-sm btn-link event' title='Permite eliminar el presupuesto #${row.PROPOSALID}'><i class='fa fa-close text-danger'></i></button>`;

        },
        EliminarPresupuesto: function (row) {
            toastr.warning(`Si está seguro de querer eliminar el presupuesto '${row.PROPOSALID}' haga clic aquí`, null,
                {
                    timeOut: 5000, closeButton: true, progressBar: true,
                    onclick: function () {                        
                        $('.ibox-content').toggleClass('sk-loading');

                        app.core.Delete(`${app.setting.apipath}v1/Presupuestos/${row.PROPOSALID}`)
                            .done(function (data, textStatus, jqXHR) {
                                toastr.success(`el presupuesto '${row.PROPOSALID}' fue eliminado`, "", { timeOut: 5000, closeButton: true, progressBar: true });
                                app.ViewerQuery.Refresh(undefined, $('#RoleMemberGridTbl'), 333, '', 1);
                            }).always(function () {
                                $('.ibox-content').toggleClass('sk-loading');
                            });
                    }
                });
            
        },
        EmisionFormatter: function (value, row, index, field) {
            let quote = '', mode = 'resume';
            //if (localStorage.getItem('Roles').includes('Purdy') || localStorage.getItem('Roles').includes('Davivienda_Prendarios') ||
            //    localStorage.getItem('Roles').includes('Davivienda_Leasing')) {
            //    quote = '', mode = 'resume';
            //}
            switch (row.COD_RAMO) {
                case 194:
                    quote = 'estudiantil';
                    break;
                case 201:
                    quote = 'hogartotal';
                    break;
                case 202:
                    quote = 'multirriesgo';
                    break;
                case 302:
                    quote = 'mapfremas';
                    break;
                case 303:
                    quote = 'mapfremasplus';
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
        EventHandler: function (id, index, stage) {
            if (id == '310' && index == 2 && stage == 'loaded') {
                $("#QueryFNotify2").html('<div class="row d-none role-Pago-visible" style="padding-top: 25px;"><div class="col-9"><a href="javascript:app.master.ShowSideBarExternal(\'Preguntas y respuestas frecuentes\', \'/aliados/viewer/render?id=392&t=4&wd=400px\');" style="font-size: smaller;">Ver preguntas y respuestas frecuentes sobre pagos electrónicos</a></div><div class="col-3"><a href="https://www.placetopay.com/web/" target="_blank"><img src="https://static.placetopay.com/placetopay-logo.svg" class="img-fluid float-right" alt="Responsive image" style="width: 125px;"></a></div></div>')
            }
            if (id == '3000' && index == 1 && stage == 'loaded') {
                $("#QueryFNotify1").html('<div class="row d-none role-Pago-visible" style="padding-top: 25px;"><div class="col-9"><a href="javascript:app.master.ShowSideBarExternal(\'Preguntas y respuestas frecuentes\', \'/aliados/viewer/render?id=392&t=4&wd=400px\');" style="font-size: smaller;">Ver preguntas y respuestas frecuentes sobre pagos electrónicos</a></div><div class="col-3"><a href="https://www.placetopay.com/web/" target="_blank"><img src="https://static.placetopay.com/placetopay-logo.svg" class="img-fluid float-right" alt="Responsive image" style="width: 125px;"></a></div></div>')
            }
        },
        NuevoEnvio: function (id, correo) {

            var producto = 'mapfremas';
            var ramo = id.toString().substr(0, 3);

            if (ramo == 302) { producto = 'MapfreMas'; }
            if (ramo == 303) { producto = 'MapfreMas'; }
            if (ramo == 201) { producto = 'HogarTotal'; }
            if (ramo == 202) { producto = 'Multirriesgo'; }

            app.ui.GetApi('v1/Issue/'+ producto +'/EnviarSolicitud?presupuesto=' + id + '&correoenvio=' + correo);
        }

    };
})();
