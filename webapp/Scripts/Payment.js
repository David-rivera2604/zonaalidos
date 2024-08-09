var app = app || {};

app.Payment = (function () {
    return {
        Recibo: function (row, id, sequence, lightbox = true) {
            let mode = localStorage.getItem('Payment');
            let data = { num_poliza: '', num_recibo: 0 };
            mode = ''; //silice
            if ((id == 310 && sequence == 2) ||
                (id == 3001 && sequence == 1) ||
                (id == 410 && sequence == 1)) {
                data = { num_poliza: row.NUM_POLIZA, num_recibo: row.NUM_RECIBO }
            }
            $("#generalNotify").html("");
            $('.ibox-content').toggleClass('sk-loading');

            if (mode = 'silice' && id == 3001 && sequence == 1) {
                app.Payment.SiliceWidget({ num_poliza: row.NUM_POLIZA, num_recibo: row.NUM_RECIBO, raw: row }, lightbox)
                    .catch(err => {
                        app.ui.ShowAlert('generalNotify', 'alert-danger', err.message);
                    }).then(d => {
                        $('.ibox-content').toggleClass('sk-loading');
                    });
            } else if (mode = 'silice' && id == 310 && sequence == 2) {
                app.Payment.SilicePaymentLink(row)
                    .catch(err => {
                        app.ui.ShowAlert('generalNotify', 'alert-danger', err.message);
                    }).then(d => {
                        $('.ibox-content').toggleClass('sk-loading');
                    });
            } else {
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
            }
        },
        Process: function (dataRequest, lightbox = true) {
            return new Promise((resolve, reject) => {
                try {
                    app.core.Post(app.setting.apipath + 'v1/Pagos/Sesion', JSON.stringify(dataRequest))
                        .done(function (session) {
                            if (session != null && session.Status == "OK") {
                                if (lightbox) {
                                    app.core.LoadScriptFile("https://checkout.placetopay.com/lightbox.min.js")
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
        },
        SiliceWidget: function (dataRequest, lightbox = true) {
            return new Promise((resolve, reject) => {
                try {
                    app.core.Post(app.setting.apipath + 'v2/Pagos/Sesion', JSON.stringify(dataRequest))
                        .done(function (session) {
                            console.log(session);
                            if (session != null && session.Status != 'FAIL') {
                                $('.ibox-content').toggleClass('sk-loading');
                                console.log(dataRequest);

                                $('head').append('<link rel="stylesheet" type="text/css" href="https://dsp-microservice-nestjs.s3.sa-east-1.amazonaws.com/54frts28t/widget-pago-directo.css">');
                                
                                app.core.LoadScriptFile('https://dsp-microservice-nestjs.s3.sa-east-1.amazonaws.com/54frts28t/widget-pago-directo.js').then(d => {

                                    let widgetPagos = document.querySelector("widget-pagos");
                                    if (widgetPagos === null) {
                                        $("body").append('<widget-pagos></widget-pagos>');
                                        widgetPagos = document.querySelector("widget-pagos");
                                    }
                                    const recibo = JSON.stringify(session);

                                    console.log('init',recibo);

                                    widgetPagos.addEventListener('loginComplete', (e) => {
                                        console.log('loginComplete', e);
                                        if (e.detail) {
                                            console.log('se ha completado el login, se puede abrir el modal')
                                            widgetPagos.setAttribute('show-modal', recibo);
                                        }
                                    });

                                    document.addEventListener('resultadoDisponible', (e) => {
                                        console.log('resultadoDisponible', e);
                                        app.ViewerQuery.Refresh(undefined, $('#1GridTbl'), 3000, '', 1);
                                    });

                                    widgetPagos.setAttribute('login', '');
                                });
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
        },
        SilicePaymentLink: function (dataRequest) {
            return new Promise((resolve, reject) => {
                try {
                    console.log(dataRequest);
                    $('.ibox-content').toggleClass('sk-loading');
                    app.ui.ShowSideBar({ title: 'Enviar enlace de pago para el recibo #{NUM_RECIBO}', id: 9006, data: dataRequest });
                } catch (error) {
                    reject(error);
                }
            });
        },
        SendLink: function (tipo, poliza, recibo) {
            console.log(tipo, poliza, recibo);
            app.ui.ButtonDoing('#WSendBtn');
            app.ui.ButtonDoing('#ESendBtn');

            app.core.Post(app.setting.apipath + 'v2/Pagos/SendPaymentLink', JSON.stringify({ mode: tipo, num_poliza: poliza, num_recibo: recibo }))
                .done(function (data) {
                    console.log(data);

                    app.ui.ShowAlert('generalNotify', 'alert-danger', data.Reason);

                    // resolve({ status: data.status, message: data.message, data: data });

                    app.ui.CloseSideBar();
                    app.ui.ButtonDoing('#WSendBtn');
                    app.ui.ButtonDoing('#ESendBtn');

                });



        }
    };
})();