var app = app || {};
app.CobrosRechazados = (function () {

    return {
        Boton: function () {
            return {
                btnExclude: {
                    text: 'Enviar a cobro los recibos seleccionados',
                    icon: 'fa-shopping-cart',
                    event: function () {
                        let data = this.data;
                        if (data.filter(i => i.SEL).length > 0) {
                            let datasel = data.filter(i => i.SEL);
                            let payload = { NUM_RECIBO: data.filter(i => i.SEL).map(u => u.BILLNUMBER) };
                            $('.ibox-content').toggleClass('sk-loading');
                            app.core.Post(app.setting.apipath + 'v1/Pagos/Recobro',
                                JSON.stringify(payload))
                                .done(function (data, textStatus, jqXHR) {
                                    toastr.success("La exclusión se hizo de forma exitosa", "", { timeOut: 5000, closeButton: true, progressBar: true });
                                    //Por mejorar para que sea mas dinamico
                                    app.ViewerQuery.Refresh(undefined, $('#1GridTbl'), 113, '', 1);
                                }).always(function () {
                                    $('.ibox-content').toggleClass('sk-loading');
                                });

                        } else {
                            toastr.error("Debe seleccionar al menos un recibo", "Error", { timeOut: 10000, closeButton: true, progressBar: true });
                        }
                    },
                    attributes: {
                        title: 'Permite excluir los recibos seleccionados del aviso de cobro'
                    }
                }
            };
        },
        Eventos: function (tableid, name, args) {
            console.log(tableid, name, args)
            switch (name) {
                case 'check-all.bs.table':
                    $('#' + tableid).bootstrapTable('getData').forEach(function (item) {
                        item.SEL = true;
                    })
                    break;
                case 'uncheck-all.bs.table':
                    $('#' + tableid).bootstrapTable('getData').forEach(function (item) {
                        item.SEL = true;
                    })
                    break;
            }
        }
    };
})();

//return app.CobrosRechazados