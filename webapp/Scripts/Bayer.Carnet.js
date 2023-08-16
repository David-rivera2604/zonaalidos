var app = app || {};

app.BayerCarnet = (function () {

    let info = { Contratante: '', Nombres: '', Cedula: '', Poliza: '', Clase: '', Certificado: 0, Dependientes: '' };

    return {
        Init: function () {
            $('.sidebar-content').toggleClass('sk-loading');
            app.core.api_get(`carnetdigital`)
                .then(data => {
                    let asegurado = data.Asegurado.Data;
                    if (asegurado != null) {
                        info.Contratante = app.ui.StringValueToString(asegurado.Contratante);
                        info.Nombres = `${app.ui.StringValueToString(asegurado.Nombre)} ${app.ui.StringValueToString(asegurado.Apellido)}`;
                        info.Cedula = app.ui.StringValueToString(asegurado.Cedula);
                        info.Poliza = app.ui.StringValueToString(asegurado.Poliza);
                        info.Clase = app.ui.StringValueToString(asegurado.Clase);
                        info.Certificado = app.ui.IntegerValueToString(asegurado.Certificado);

                        $('#Contratante').html(info.Contratante);
                        $('#Nombres').html(info.Nombres);
                        $('#Cedula').html(info.Cedula);
                        $('#Poliza').html(info.Poliza);
                        $('#Clase').html(info.Clase);
                        $('#Certificado').html(info.Certificado);

                        $('#print').removeClass('d-none');
                    }
                    let extras = data.Extras.Data;
                    if (extras != null) {
                        extras.filter(r => r.TipoExtra === 'Dependiente').forEach(function (item) {
                            let value = `<li>${app.ui.StringValueToString(item.NombreExtra)} ${app.ui.StringValueToString(item.ApellidoExtra)}</li>`;
                            info.Dependientes += value;
                            $('#Extras').append(value);
                        })
                    }
                    $('.sidebar-content').toggleClass('sk-loading');
                });

            $('#print').click(function (e) {
                e.preventDefault();
                $('.sidebar-content').toggleClass('sk-loading');
                app.core.api_report('CarnetDigital.repx', info)
                    .then(data => {
                        $('.sidebar-content').toggleClass('sk-loading');
                    });

                //var urlServer = 'https://appqa.mapfrecr.com' + '/AliadoServReports/api/Report/Build';
                ////urlServer = 'http://216.177.200.23/Report.Services/api/Report/Build';
                //var data2 = {
                //    Source: JSON.stringify(info),
                //    Type: 'pdf',
                //    ReportName: 'CarnetDigital.repx',
                //    Path: ''
                //};
                //$.post(urlServer, data2, { responseType: 'arraybuffer' })
                //    .then(function (response) {
                //        var file = new Blob([response.Data], { type: 'application/octet-binary' });
                //        var blob = app.core.b64StrtoBlob(response.Data, 'application/pdf');
                //        var blobUrl = URL.createObjectURL(blob);
                //        window.open(blobUrl);
                //    });
            });

        }
    };
})();
