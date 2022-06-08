var app = app || {};

app.Ex_AvisosCobro = (function () {

    return {
        Eliminar: function (row) {
            toastr.warning("Si está seguro de querer eliminar el aviso de cobro #" + row.COD_DOCUM_PAGO + " haga clic aquí", null,
                {
                    timeOut: 5000, closeButton: true, progressBar: true,
                    onclick: function () {
                        $('.ibox-content').toggleClass('sk-loading');
                        app.core.Delete(app.setting.apipath + 'v1/AvisoCobro/' + row.COD_DOCUM_PAGO)
                            .done(function (data, textStatus, jqXHR) {
                                toastr.success("El aviso de cobro #" + row.COD_DOCUM_PAGO + " fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                                //Por mejorar para que sea mas dinamico
                                app.ViewerQuery.Refresh(undefined, $('#1GridTbl'), 400, '', 1);
                            }).always(function () {
                                $('.ibox-content').toggleClass('sk-loading');
                            });
                    }
                });
        },
        Imprimir: function (row) {
            $('.ibox-content').toggleClass('sk-loading');
            app.core.GetPDF(app.setting.apipath + 'v1/TronCommon/ImprimirAviso/' + row.COD_DOCUM_PAGO, false, 'Mapfre Aviso ' + row.COD_DOCUM_PAGO + '.pdf',
                function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });
        },
        ImprimirDetalle: function (row) {
            $('.ibox-content').toggleClass('sk-loading');
            app.core.GetPDF(app.setting.apipath + 'v1/TronCommon/ImprimirAvisoDetalle/' + row.COD_DOCUM_PAGO, false, 'Mapfre Aviso ' + row.COD_DOCUM_PAGO + ' Detalle.pdf',
                function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });
        },
        Boton: function () {
            return {
                btnExclude: {
                    text: 'Excluir recibos seleccionados',
                    icon: 'fa-chain-broken',
                    event: function () {
                        let data = this.data;
                        if (data.filter(i => i.SEL).length > 0) {
                            let datasel = data.filter(i => i.SEL);
                            let payload = {
                                Num_Aviso: datasel[0].COD_DOCUM_PAGO,
                                Lista_Recibos: datasel.map(u => u.NUM_RECIBO).join(';')
                            };
                            $('.ibox-content').toggleClass('sk-loading');
                            app.core.Put(app.setting.apipath + 'v1/AvisoCobro',
                                JSON.stringify(payload))
                                .done(function (data, textStatus, jqXHR) {
                                    toastr.success("La exclusión se hizo de forma exitosa", "", { timeOut: 5000, closeButton: true, progressBar: true });
                                    //Por mejorar para que sea mas dinamico
                                    app.ViewerQuery.Refresh(undefined, $('#1GridTbl'), 400, '', 1);
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
        }
    };
})();
