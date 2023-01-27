var app = app || {};

app.Payment = (function () {

    return {
        Recibo: function (row, id, sequence, lightbox = true) {
            let data = { num_poliza: '', num_recibo: 0 };
            if ((id == 310 && sequence == 2) ||
                (id == 3001 && sequence == 1) ||
                (id == 410 && sequence == 1)) {
                data = { num_poliza: row.NUM_POLIZA, num_recibo: row.NUM_RECIBO }
            }
            $("#generalNotify").html("");
            $('.ibox-content').toggleClass('sk-loading');
            app.Payment.Process(data, lightbox)
                .catch(err => {
                    app.ui.ShowAlert('generalNotify', 'alert-danger', err.message);
                }).then(d => {
                    $('.ibox-content').toggleClass('sk-loading');
                    if (d?.status != undefined) {
                        switch (d.status) {
                            case 'APPROVED':
                                app.ui.ShowAlert('generalNotify', 'alert-success', '<b> <i class="fa fa-check"></i> Transacción aprobada:</b> El cobro del recibo ' + row.NUM_RECIBO + ' con el número de referencia ' + d.data.reference + ', fue realizado de forma exitosa.');
                                break
                            case 'REJECTED':
                                app.ui.ShowAlert('generalNotify', 'alert-danger', '<b> <i class="fa fa-close"></i> El pago ha sido rechazado:</b> El cobro del recibo ' + row.NUM_RECIBO + ' con el número de referencia ' + d.data.reference + ', ha sido rechazado.');
                                break
                            case 'PENDING':
                                app.ui.ShowAlert('generalNotify', 'alert-warning', '<b> <i class="fa fa-question-circle-o"></i> El proceso de pago está pendiente:</b> El cobro del recibo ' + row.NUM_RECIBO + ' con el número de referencia ' + d.data.reference + ', está pendiente, se requiere una revisión adicional para procesar la transacción.');
                                break
                        }
                        if (id == 310 && sequence == 2) {
                            app.ViewerQuery.Refresh(undefined, $('#2GridTbl'), id, '', sequence);
                        }
                        if (id == 3001 && sequence == 1) {
                            app.ViewerQuery.Refresh(undefined, $('#1GridTbl'), 3000, '', sequence);
                        }
                    }
                });
        },
        Process: function (dataRequest, lightbox = true) {
            return new Promise((resolve, reject) => {
                try {
                    app.core.Post(app.setting.apipath + 'v1/Pagos/Sesion', JSON.stringify(dataRequest))
                        .done(function (session) {
                            if (session != null && session.Status == "OK") {
                                if (lightbox) {
                                    app.core.LoadScriptFile("https://secure.placetopay.com/redirection/lightbox.min.js")
                                        .then(d => {
                                            P.on('response', function (data) {
                                                app.core.Post(app.setting.apipath + 'v1/Pagos/Sesion/' + session.RequestId, null)
                                                    .done(function (data) {
                                                        resolve({ status: data.status, message: data.message, data: data });
                                                    });
                                            });
                                            P.init(session.ProcessUrl);
                                        })
                                        .catch(err => {
                                            reject({ status: 'FAIL', message: '' });
                                        });
                                } else {
                                    window.location.href = session.ProcessUrl;
                                }
                            }
                            else {
                                reject({ status: session.Status, message: session.Reason });
                            }
                        }).fail(function (jqXHR, textStatus, errorThrown) {
                            resolve({ status: 'FAIL', message: 'Error', data: null });
                        });
                } catch (error) {
                    reject(error);
                }
            });
        }
    };
})();