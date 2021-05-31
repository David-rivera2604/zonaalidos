var app = app || {};

app.ClientesIndex = (function () {

    return {
        Init: function () {
            $('.ibox-content').toggleClass('sk-loading');
            $('#external').on("load", function () {
                $('.ibox-content').toggleClass('sk-loading');
            });
            app.core.Get(app.setting.apipath + 'v1/TronClient/Setup', null,
                function (data) {
                    $('#external').attr('src', data.url);
                });
        }
    };
})();