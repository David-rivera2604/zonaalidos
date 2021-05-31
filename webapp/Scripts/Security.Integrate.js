var app = app || {};

app.SecurityIntegrate = (function () {

    return {
        Init: function () {
            var src = app.core.URLStringValue('src');
            var key = app.core.URLStringValue('key');
            if (src === '' || key === '') {
                return;
            }
            app.core.Get(app.setting.apipath + `v1/Security/Access/${key}`)
                .done(function (data, textStatus, jqXHR) {
                    if (data != '') {
                        localStorage.setItem('Token', data);
                        if (src === 'aliados') {
                            window.location.replace('../Siniestros/Panel');
                        }
                        if (src === 'aliadosq') {
                            window.location.replace('../viewer/render?id=331');
                        }
                        if (src === 'aliadosq2') {
                            window.location.replace('../viewer/render?id=332');
                        }
                    }
                });
        }
    };
})();
