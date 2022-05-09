var app = app || {};

app.Payment = (function () {

    return {
        Recibo: function (row, id, sequence, lightbox = true) {
            let data = { num_poliza: '', num_recibo: 0 };
            console.log('row', row);

            if (id == 310 && sequence == 2) {
                data = { num_poliza: row.NUM_POLIZA, num_recibo: row.NUM_RECIBO }
            }

            $('.ibox-content').toggleClass('sk-loading');
            app.Payment.Process(data, lightbox)
                //.then(d => {
                //    //app.ui.ShowAlert('generalNotify', 'alert-primary', d.status);
                //})
                .catch(err => {
                    app.ui.ShowAlert('generalNotify', 'alert-danger', d.status);
                }).then(d => {
                    $('.ibox-content').toggleClass('sk-loading');
                    switch (d.status) {
                        case 'APPROVED':
                            //toastr.success("La transacción con la referencia " + d.data.payment[0].reference + " fue realizada de forma exitosa", "Transaccion aprobada", { timeOut: 50000, closeButton: true, progressBar: true });
                            app.ui.ShowAlert('generalNotify', 'alert-success', '<b> <i class="fa fa-check"></i> Transaccion aprobada:</b> El cobro del recibo ' + row.NUM_RECIBO + ' con el número de referencia ' + d.data.payment[0].reference + ', fue realizado de forma exitosa.');
                            break
                        case 'REJECTED':
                            //toastr.error("La transacción con la referencia 98432345234523 ha sido rechazada", "El pago ha sido rechazado", { timeOut: 50000, closeButton: true, progressBar: true });
                            app.ui.ShowAlert('generalNotify', 'alert-danger', '<b> <i class="fa fa-close"></i> El pago ha sido rechazado:</b> El cobro del recibo ' + row.NUM_RECIBO + ' con el número de referencia ' + d.data.request.payment.reference + ', ha sido rechazado.');
                            break
                            
                    }
                    

                    if (id == 310 && sequence == 2) {
                        app.ViewerQuery.Refresh(undefined, $('#2GridTbl'), id, '', sequence);
                    }
                });
        },
        Process: function (dataRequest, lightbox = true) {
            return new Promise((resolve, reject) => {
                try {
                    app.core.Post(app.setting.apipath + 'v1/Pagos/Sesion', JSON.stringify(dataRequest))
                        .done(function (session) {
                            console.log('session', session);
                            if (session != null && session.Status == "OK") {                                
                                if (lightbox) {
                                    app.core.LoadScriptFile("https://secure.placetopay.com/redirection/lightbox.min.js")
                                        .then(d => {
                                            P.on('response', function (data) {
                                                console.log('result', data);
                                                app.core.Post(app.setting.apipath + 'v1/Pagos/Sesion/' + session.RequestId, null)
                                                    .done(function (data) {
                                                        console.log('refresh', data);
                                                        resolve({ status: data.status.status, message: data.status.message, data: data });
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
                                reject({ status: session.Status, message: data.Reason });
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