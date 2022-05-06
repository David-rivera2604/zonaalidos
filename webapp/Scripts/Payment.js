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
                                                        resolve({ status: data.status.status, message: data.status.message });
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
                            resolve({ status: 'FAIL', message: 'Error' });
                        });
                } catch (error) {
                    reject(error);
                }
            });
        }
    };
})();