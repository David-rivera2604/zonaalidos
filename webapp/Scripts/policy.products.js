var app = app || {};

app.PolicyProducts = (function () {
    return {
        Init: function () {
            $('.ibox-content').toggleClass('sk-loading');
            app.core.Get(app.setting.apipath + 'v1/datasource/json?id=60&sequence=1&url=')
                .done(function (data, textStatus, jqXHR) {
                    let tmpl = $('#tmpl');
                    data.forEach(function (item) {
                        var clone = tmpl.clone();
                        var icon = 'fa-handshake-o';
                        clone.find("a").attr('href', 'Edit?alias=' + item.CONFIG);
                        clone.find(".file-name").html(item.PRODDESC + '<br><small>Ramo: ' + item.LINEDESC + '</small>');
                        if (item.PRODDESC.indexOf('saldo') > -1 && item.PRODDESC.indexOf('deudor') > -1) {
                            icon = 'fa-credit-card';
                        }
                        clone.find('i').addClass(icon);
                        clone.removeClass('d-none');
                        $('#panel').append(clone);
                    });

                }).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
                });
        }
    };
})();

