var app = app || {};

app.Form_Ext_Altas = (function () {


    return {
        Init: function (spec, formName) {

            console.log(formName, spec);

            //spec['Changed'](function (data) { console.log(data); });

            //switch (formName) {
            //    case 'InformacionProveedor':
            //        InformacionProveedor(spec, formName);
            //        break;
            //    case 'NotificarGarantia':
            //        NotificarGarantia(spec, formName);
            //        break;
            //    case 'NotificarLiberacion':
            //        NotificarLiberacion(spec, formName);
            //        break;
            //}

        }
    };
})();