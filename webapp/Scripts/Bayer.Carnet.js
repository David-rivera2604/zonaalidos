var app = app || {};

app.BayerCarnet = (function () {

    let info = { Contratante: '', Nombres: '', Cedula: '', Poliza: '', Clase: '', Certificado: 0, Dependientes: '' };
    return {
        Init: function () {

            let _id = app.core.URLNumericValue('id');
            if (_id !== 0) {
                app.core.api_get(`carnetdigital?Cedula=${_id}`)
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
                        }
                        let extras = data.Extras.Data;
                        if (extras != null) {
                            extras.filter(r => r.TipoExtra === 'Dependiente').forEach(function (item) {
                                let value = `<li>${app.ui.StringValueToString(item.NombreExtra)} ${app.ui.StringValueToString(item.ApellidoExtra)}</li>`;
                                info.Dependientes += value;
                                $('#Extras').append(value);
                            })
                        }
                    });
            }
            $('#print').click(function () {
                event.preventDefault();
                var urlServer = app.setting.apibase + '/AliadoServReports/api/Report/Build';
                //urlServer = 'http://localhost:5870/api/Report/Build';
                //urlServer = 'https://appqa.mapfrecr.com' + '/AliadoServReports/api/Report/Build';
                var data2 = {
                    Source: JSON.stringify(info),
                    Type: 'pdf',
                    ReportName: 'CarnetDigital.repx',
                    Path: ''
                };
                $.post(urlServer, data2, { responseType: 'arraybuffer' })
                    .then(function (response) {
                        var file = new Blob([response.Data], { type: 'application/octet-binary' });
                        var blob = b64StrtoBlob(response.Data, 'application/pdf');
                        var blobUrl = URL.createObjectURL(blob);
                        window.open(blobUrl);
                    });
            });

        }
    };
})();
