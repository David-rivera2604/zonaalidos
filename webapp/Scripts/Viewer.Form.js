var app = app || {};

app.ViewerForm = (function () {
    return {
        Init: function () {
            let _id = app.core.URLStringValue('id');
            if (_id != '') {
                $('.ibox-content').toggleClass('sk-loading');

                app.core.Get(app.setting.apipath + `v1/Viewer/Form/${_id}`)
                    .done(function (data, textStatus, jqXHR) {
                        $('#formTitle').html(data.Caption);
                        let html = data.HTML.supplant({});
                        html = app.core.ReplaceAll(html, '@_eqg', '>=');
                        html = app.core.ReplaceAll(html, '@_eq', '=');
                        html = app.core.ReplaceAll(html, '@_qt', '\'');
                        html = app.core.ReplaceAll(html, '@_sc', ';');
                        html = app.core.ReplaceAll(html, '@_ee', ' ');
                        html = app.core.ReplaceAll(html, 'Prototype', _id);
                        $('.render').replaceWith(html);
                        let code = app.core.ReplaceAll(data.Code, 'Prototype', _id);

                        if (data.Include !== null && data.Include !== '') {
                            app.core.LoadScriptFile(data.Include)
                                .then(d => {
                                    let name = app.core.ReplaceAll(data.Include, '.js', '');
                                    name = app.core.ReplaceAll(name, '.', '_');
                                    //app[name]['Init'](app[_id], _id);

                                    code = app.core.ReplaceAll(code, '\t\t\t\tSetup();', '');
                                    code = app.core.ReplaceAll(code, '//Custom.Extend', `app.${name}.Init(app.${_id}, '${_id}');`)
                                    eval(code);
                                })
                                .catch(err => {
                                    console.error(err);
                                });
                        } else
                            eval(code);
                    });
            };
        }
    };
})();
