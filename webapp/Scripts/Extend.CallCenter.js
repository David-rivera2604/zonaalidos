var app = app || {};

app.Extend = (function () {

    let _oldValue = '';

    async function Redraw() {
        let tipo = app.ui.GetDropDownStringValue('#tipo');
        if (tipo == 'D')
            $('#tip_docum').parent().parent().removeClass('d-none');
        else
            $('#tip_docum').parent().parent().addClass('d-none');
        switch (tipo) {
            case 'D':
                $("label[for='valor']").html('Número de documento<span class="required-mark" title="Este campo debe ser llenado de forma obligatoria">*</span>');
                break;
            case 'P':
                $("label[for='valor']").html('Número de póliza<span class="required-mark" title="Este campo debe ser llenado de forma obligatoria">*</span>');
                break;
            case 'M':
                $("label[for='valor']").html('Matrícula<span class="required-mark" title="Este campo debe ser llenado de forma obligatoria">*</span>');
                break;
            case 'C':
                $("label[for='valor']").html('Chasis<span class="required-mark" title="Este campo debe ser llenado de forma obligatoria">*</span>');
                break;
            case 'T':
                $("label[for='valor']").html('Motor<span class="required-mark" title="Este campo debe ser llenado de forma obligatoria">*</span>');
                break;
        }
        if (_oldValue != tipo) {
            $('#valor').val('');
            $('#1GridTbl').bootstrapTable('load', []);
            _oldValue = tipo;
        }
    }

    return {
        Query: function () {
            if (app.Prototype1.IsValid()) {
                $('.ibox-content').toggleClass('sk-loading');
                app.ViewerQuery.Refresh(undefined, $('#1GridTbl'), 6000, '', undefined, undefined, function () {
                    $('.ibox-content').toggleClass('sk-loading');
                }, true);
            }
        },
        EventHandler: function (id, index, stage) {
            if (id == '6000' && index == 1 && stage == 'loaded') {

                let nameClass = "Prototype" + index;
                if (nameClass in app) {
                    app[nameClass]['Changed'](function (data) {
                        Redraw();
                    });
                }
                Redraw();
            }
        }
    };
})();
