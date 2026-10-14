var app = app || {};

app.Masivos = app.Masivos || {};
app.Masivos.Api = (function () {

    function ConsultarCargas() {
        return app.core.Get(app.setting.apipath + 'v1/Masivos/Cargas');
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
            xhrFields: { withCredentials: true },
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + app.security().getCookie('Token'));
            }
        });
    }

    function Validar(id) {
        return $.ajax({
            type: 'POST',
            url: app.setting.apipath + 'v1/Masivos/Validar',
            data: JSON.stringify({ id: id }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            xhrFields: { withCredentials: true },
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + app.security().getCookie('Token'));
            }
        });
    }

    function Procesar(id) {
        return $.ajax({
            type: 'POST',
            url: app.setting.apipath + 'v1/Masivos/Procesar',
            data: JSON.stringify({ id: id }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            xhrFields: { withCredentials: true },
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + app.security().getCookie('Token'));
            }
        });
    }

    function ActualizarArchivo(id, file) {
        var formData = new FormData();
        formData.append('id', id);
        formData.append('file', file);

        return $.ajax({
            type: 'POST',
            enctype: 'multipart/form-data',
            url: app.setting.apipath + 'v1/Masivos/ActualizarArchivo',
            data: formData,
            processData: false,
            contentType: false,
            cache: false,
            timeout: 600000,
            xhrFields: { withCredentials: true },
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + app.security().getCookie('Token'));
            }
        });
    }

    function ConsultarResultados(ids) {
        return $.ajax({
            type: 'POST',
            url: app.setting.apipath + 'v1/Masivos/ResultadosBatch',
            data: JSON.stringify(ids),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            xhrFields: { withCredentials: true },
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + app.security().getCookie('Token'));
            }
        });
    }

    return {
        ConsultarCargas: ConsultarCargas,
        CargarCsv: CargarCsv,
        Validar: Validar,
        Procesar: Procesar,
        ActualizarArchivo: ActualizarArchivo,
        ConsultarResultados: ConsultarResultados
    };
})();
