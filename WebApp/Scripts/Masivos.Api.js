var app = app || {};

app.Masivos = app.Masivos || {};
app.Masivos.Api = (function () {

    function ConsultarCargas(codRamo) {
        var query = codRamo ? ('?codRamo=' + encodeURIComponent(codRamo)) : '';
        return app.core.Get(app.setting.apipath + 'v1/Masivos/Cargas' + query);
    }

    function CargarCsv(codRamo, file) {
        var formData = new FormData();
        formData.append('codRamo', codRamo);
        formData.append('file', file);

        return $.ajax({
            type: 'POST',
            enctype: 'multipart/form-data',
            url: app.setting.apipath + 'v1/Masivos/CargarCsv',
            data: formData,
            processData: false,
            contentType: false,
            cache: false,
            timeout: 600000,
            xhrFields: {
                withCredentials: true
            },
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + app.security().getCookie('Token'));
            }
        });
    }

    function Procesar(codRamo, fileName) {
        var deferred = $.Deferred();
        app.core.Post(app.setting.apipath + 'v1/Masivos/Procesar',
            JSON.stringify({ codRamo: codRamo, fileName: fileName }),
            function (data) {
                deferred.resolve(data);
            }).fail(function (jqXHR, textStatus, errorThrown) {
                deferred.reject(jqXHR, textStatus, errorThrown);
            });
        return deferred.promise();
    }

    return {
        ConsultarCargas: ConsultarCargas,
        CargarCsv: CargarCsv,
        Procesar: Procesar
    };
})();
