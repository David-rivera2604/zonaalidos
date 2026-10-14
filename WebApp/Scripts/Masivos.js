var app = app || {};

app.Masivos = (function () {
    function Init() {
        if (app.Masivos.Ui && typeof app.Masivos.Ui.Init === 'function') {
            app.Masivos.Ui.Init();
        }
    }

    return {
        Init: Init
    };
})();

$(function () {
    if ($('#MasivosEdtForm').length > 0) {
        app.Masivos.Init();
    }
});
