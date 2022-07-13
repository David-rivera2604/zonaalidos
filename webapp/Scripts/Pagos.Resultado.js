var app = app || {};

app.PrototypePayment = (function () {

    function Setup() {
        let _ref = app.core.URLStringValue('ref');
        $('.ibox-content').toggleClass('sk-loading');
        app.core.Post(app.setting.apipath + 'v1/Pagos/Sesion/ref=' + _ref, null)
            .done(function (data) {
                switch (data.status) {
                    case 'APPROVED':
                    case 'PENDING':
                        $('#description').html(data.description);
                        $('#reference').html(data.reference);
                        $('#amount').html(data.currency + ' ' + data.total.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#paymentMethodName').html(data.paymentMethodName + ' **** ' + data.lastDigits);
                        $('#authorization').html(data.authorization);
                        $('#receipt').html(data.receipt);
                        $('#message').html(data.message);
                        break;
                    case 'REJECTED':                    
                        $('#description').html(data.description);
                        $('#reference').html(data.reference);
                        $('#amount').html(data.currency + ' ' + data.amount.total.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#message').html(data.message);
                        break;
                }
                $('.status-' + data.status).removeClass('d-none');

            }).always(function () {
                $('.ibox-content').toggleClass('sk-loading');
            });
    };

    return {
        Init: function () {
            try {
                Setup();
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        }
    };
})();
