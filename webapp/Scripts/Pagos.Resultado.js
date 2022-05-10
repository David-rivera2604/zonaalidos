var app = app || {};

app.PrototypePayment = (function () {

    var setupData = null;

    function Setup() {
        let _ref = app.core.URLStringValue('ref');
        if (_ref == '')
            _ref = '3001510108954-907641';
        $('.ibox-content').toggleClass('sk-loading');
        app.core.Post(app.setting.apipath + 'v1/Pagos/Sesion/ref=' + _ref, null)
            .done(function (data) {
                console.log(data);
                setupData = data;



                switch (data.status.status) {
                    case 'APPROVED':
                    case 'PENDING':
                        let payment = data.payment[0];
                        $('#description').html(data.request.payment.description);
                        $('#reference').html(data.request.payment.reference);
                        $('#amount').html(payment.amount.to.currency + ' ' + payment.amount.to.total.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#paymentMethodName').html(payment.paymentMethodName + ' **** ' + payment.processorFields.find(element => element.keyword == 'lastDigits')?.value);
                        $('#authorization').html(payment.authorization);
                        $('#receipt').html(payment.receipt);
                        $('#message').html(payment.status.message);
                        break;
                    case 'REJECTED':                    
                        let paymentr = data.request.payment;
                        $('#description').html(data.request.payment.description);
                        $('#reference').html(data.request.payment.reference);
                        $('#amount').html(paymentr.amount.currency + ' ' + paymentr.amount.total.toLocaleString('ES', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#message').html(data.status.message);
                        break;
                }




                $('.status-' + data.status.status).removeClass('d-none');

            }).always(function () {
                $('.ibox-content').toggleClass('sk-loading');
            });
    };

    function Controls_Events() {
    };

    return {
        Init: function () {
            try {
                Controls_Events();
                Setup();
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        }
    };
})();
