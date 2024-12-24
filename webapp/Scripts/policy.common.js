var app = app || {};
app.policy_common = (function () {
    function Print(id) {

        $('.ibox-content').toggleClass('sk-loading');
        app.core.Get(app.setting.apipath + 'v1/Policy/Information?id=' + id)
            .done(function (data, textStatus, jqXHR) {

                app.core.api_report(data.ProductAlias + data.Prefix, data)
                    .then(data => {
                        $('.ibox-content').toggleClass('sk-loading');
                    });
            });
    };

    return {
        Print: function (id) {
            Print(id);
        },
        PolicyStatus2CSSClass: function (value) {
            var classValue = 'primary';
            switch (value) {
                case 'En revisión':
                    classValue = 'label-info';
                    break;
                case 'Declinada':
                    classValue = 'label-warning';
                    break;
                case 'Por aceptar':
                    classValue = 'label-primary';
                    break;
                case 'Alta':
                    classValue = 'label-success';
                    break;
                case 'Baja':
                    classValue = 'label-danger';
                    break;
                default:
                    classValue = '';
            };
            return classValue;
        },
        PolicyStatusFormatter: function (value, row, index, field) {
            return '<span class="label ' + app.policy_common.PolicyStatus2CSSClass(value) + '">' + value + '</span>';
        }
    };
}());
