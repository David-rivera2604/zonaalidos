var app = app || {};

app.Prototype = (function () {
    return {
        Init: function () {
            _id = app.core.URLStringValue('id');
            if (_id != '') {
                $('#VisualizationsEdtForm').addClass('d-none');
                app.core.Post(app.setting.apipath + 'v1/Viewer/Prototype1',
                    JSON.stringify({
                        Subject: _id,
                        Partial: true,
                        Body: ''
                    }))
                    .done(function (data, textStatus, jqXHR) {
                        $("#extend").html(data);

                        app.core.Post(app.setting.apipath + 'v1/Viewer/Prototype2',
                            JSON.stringify({
                                Subject: _id,
                                Partial: true,
                                Body: ''
                            }))
                            .done(function (data, textStatus, jqXHR) {
                                eval(data);
                            });
                    });
            }
            else {
                $('#specificationApply').click(function () {
                    app.core.Post(app.setting.apipath + 'v1/Viewer/Prototype1',
                        JSON.stringify({
                            Subject: $('#key').val(),
                            Partial: false,
                            Body: $('#specification').val()
                        }))
                        .done(function (data, textStatus, jqXHR) {
                            $("#extend").html(data);

                            app.core.Post(app.setting.apipath + 'v1/Viewer/Prototype2',
                                JSON.stringify({
                                    Subject: $('#key').val(),
                                    Partial: false,
                                    Body: $('#specification').val()
                                }))
                                .done(function (data, textStatus, jqXHR) {
                                    eval(data);
                                });
                        });
                });
            }
        }
    };
})();