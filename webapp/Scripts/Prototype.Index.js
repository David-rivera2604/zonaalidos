var app = app || {};

app.Prototype = (function () {
    return {
        Init: function () {
            _id = app.core.URLStringValue('id');
            if (_id != '') {

                var html = [];
                html.push('Solicitud de inclusión. Seguro colectivo y gastos medicos|título');
                html.push('Datos de la póliza|zona|12');
                html.push(' Correo electrónico|Correo');
                html.push(' Copia 1|Correo');
                html.push(' Copia 2|Correo');
                html.push(' Enviar certificado|Boton');
   
                app.core.Post(app.setting.apipath + 'v1/Viewer/Prototype1',
                    JSON.stringify({
                        Subject: "",
                        Partial: true,
                        Body: html.join('\r\n')
                    }))
                    .done(function (data, textStatus, jqXHR) {
                        $("#extend").replaceWith(data);

                        app.core.Post(app.setting.apipath + 'v1/Viewer/Prototype2',
                            JSON.stringify({
                                Subject: "",
                                Partial: true,
                                Body: html.join('\r\n')
                            }))
                            .done(function (data, textStatus, jqXHR) {
                                eval(data);

                                //var tmpFunc = new Function(data);
                                //tmpFunc();
                            });
                    });
            }
            else {
                $('#specificationApply').click(function () {
                    app.core.Post(app.setting.apipath + 'v1/Viewer/Prototype1',
                        JSON.stringify({
                            Subject: "",
                            Partial: false,
                            Body: $('#specification').val()
                        }))
                        .done(function (data, textStatus, jqXHR) {
                            $("#extend").html(data);

                            app.core.Post(app.setting.apipath + 'v1/Viewer/Prototype2',
                                JSON.stringify({
                                    Subject: "",
                                    Partial: false,
                                    Body: $('#specification').val()
                                }))
                                .done(function (data, textStatus, jqXHR) {
                                    eval(data);

                                    //var tmpFunc = new Function(data);
                                    //tmpFunc();
                                });
                        });
                });
            }
        }
    };
})();