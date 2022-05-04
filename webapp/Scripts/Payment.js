var app = app || {};

app.Payment = (function () {

    return {
        Recibo: function (row) {
            console.log('row', row);

            $('.ibox-content').toggleClass('sk-loading');
            app.Payment.Process({ num_poliza: '123', num_recibo: 456 })
                .then(d => {
                    app.ui.ShowAlert('generalNotify', 'alert-primary', d.status);
                })
                .catch(err => {
                    app.ui.ShowAlert('generalNotify', 'alert-danger', d.status);
                }).then(d => {
                    $('.ibox-content').toggleClass('sk-loading');
                });
        },
        Process: function (dataRequest) {
            return new Promise((resolve, reject) => {
                try {
                    app.core.Post(app.setting.apipath + 'v1/Pagos/Sesion', JSON.stringify(dataRequest))
                        .done(function (session) {
                            console.log('session', session);
                            if (session != null && session.Status == "OK") {
                                app.core.LoadScriptFile("https://secure.placetopay.com/redirection/lightbox.min.js")
                                    .then(d => {
                                        P.on('response', function (data) {
                                            console.log('result', data);
                                            app.core.Post(app.setting.apipath + 'v1/Pagos/Sesion/' + session.RequestId, null)
                                                .done(function (data) {
                                                    console.log('refresh', data);
                                                    resolve({ status: data.status.status, message: data.status.message });
                                                });
                                        });
                                        P.init(session.ProcessUrl);
                                        //window.location.href = session.ProcessUrl;
                                    })
                                    .catch(err => {
                                        reject({ status: 'FAIL', message: '' });
                                    });
                            }
                            else {
                                reject({ status: session.Status, message: data.Reason });
                            }
                        });
                } catch (error) {
                    reject(error);
                }
            });
        }
    };
})();