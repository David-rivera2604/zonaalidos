var app = app || {};

app.Ex_CaseDetail = (function () {
    return {
        Boton: function () {
            return {
                btnExclude: {
                    text: 'Descargar archivo excel',
                    icon: 'fa-chain-broken',
                    event: function () {
                        let data = app.Prototype1.Data();
                        let url = '';
                        for (var p in data) {
                            if (data.hasOwnProperty(p)) {
                                url += ':' + p + '=' + data[p];
                            }
                        }
                        if (url != undefined)
                            url = url.replace(/T00:00:00/g, '');
                        console.log(url);
                        $('.ibox-content').toggleClass('sk-loading');
                        app.core.GetPDF(app.setting.apipath + 'v1/DataSource/excel?id=4002&url=id=4002' + url, true, 'Detalle por caso.xlsx',
                            function () {
                                $('.ibox-content').toggleClass('sk-loading');
                            });
                    },
                    attributes: {
                        title: 'Permite descargar la información en forma de un archivo excel'
                    }
                }
            };
        }
    };
})();
