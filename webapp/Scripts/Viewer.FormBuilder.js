class ViewerFormBuilder {

    id = 'prototipo';
    constructor() {
        let _id = app.core.URLStringValue('id');
        if (_id != '') {
            $('.ibox-content').toggleClass('sk-loading');
            this.#Preview(_id)
        } else {
            window.open('FormDefine', "Form Builder", "left=200, width=750, height=550, titlebar=no, location=NO,resizable,scrollbars,status");
        }
    }

    #Show(data) {
        let _id = this.id;
        $('#formTitle').html(data.Caption);
        let html = data.HTML.supplant({});
        html = app.core.ReplaceAll(html, '@_eqg', '>=');
        html = app.core.ReplaceAll(html, '@_eq', '=');
        html = app.core.ReplaceAll(html, '@_qt', '\'');
        html = app.core.ReplaceAll(html, '@_sc', ';');
        html = app.core.ReplaceAll(html, '@_ee', ' ');
        html = app.core.ReplaceAll(html, 'Prototype', _id);

        html = app.core.ReplaceAll(html, 'ibox-content', 'ibox-content render');

        $('.render').replaceWith(html);
        let code = app.core.ReplaceAll(data.Code, 'Prototype', _id);

        if (data.Include !== null && data.Include !== '') {
            app.core.LoadScriptFile(data.Include)
                .then(d => {
                    let name = app.core.ReplaceAll(data.Include, '.js', '');
                    name = app.core.ReplaceAll(name, '.', '_');
                    //app[name]['Init'](app[_id], _id);

                    code = app.core.ReplaceAll(code, '\t\t\t\tSetup();', '');
                    code = app.core.ReplaceAll(code, '//Custom.Extend', `app.${name}.Init(app.${_id}, '${_id}');`);
                    eval(code);
                })
                .catch(err => {
                    console.error(err);
                });
        } else {
            code += "app.core.Lookups(app.prototipo.Options().Lookups, function (){}, app.prototipo.Options().Base);";
            eval(code);
        }
        app.ui.CommonBehaviour();
    };

    async #Preview(_id) {

        app.core.Post(app.setting.apipath + 'v1/Viewer/FormBuilder',
            JSON.stringify({
                Subject: _id,
                Body: ''
            }))
            .done(function (data) {
                this.#Show(data);
            });
    };


    async Redraw(spec, key) {
        this.id = key;
        app.core.Post(app.setting.apipath + 'v1/Viewer/FormBuilder',
            JSON.stringify({
                Subject: key,
                Body: spec
            }))
            .done(this.#Show);
    }

}

var app = app || {};
app.ViewerFormBuilder = new ViewerFormBuilder();
