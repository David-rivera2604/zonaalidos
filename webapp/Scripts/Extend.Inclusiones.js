var app = app || {};

app.Ex_Inclusiones = (function () {

    return {
        AcccionesFormatter: function (value, row, index, field) {
            if (row.Estado === 'Alta')
                return '<span class=columnBtn><button name=\"imprimecertificado\" type=\"button\" class=\"btn btn-sm btn-white event\" title=\"Permite imprimir el certificado\"><i class=\"fa fa-print\"></i></button></span>';
            else
                return '';
        },
        Certificado: function (row) {
            alert(row);
            $('.ibox-content').toggleClass('sk-loading');
            app.core.Get(app.setting.apipath + 'v1/Inclusion/bayer/' + row.Id)
                .done(function (data) {
                    app.core.api_report('bayer_certificado.repx', data)
                        .then(data => {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                });
        }
    };
})();
