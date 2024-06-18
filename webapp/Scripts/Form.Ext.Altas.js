var app = app || {};

app.Form_Ext_Altas = (function () {


    return {
        Init: function (spec, formName) {

            console.log(formName, spec);

            app.core.Lookups(['Paises.NACIONALIDAD_ASEG', 'Provincias.COD_ESTADO', 'Cantones.COD_PROVINCIA', 'Distritos.COD_LOCALIDAD'],
                function () {
                    $('#COD_ESTADO').on('change', function () {
                        var pais = $('select#cod_pais').val();
                        app.core.LookupDependency($('select#COD_ESTADO').val(), 'COD_PROVINCIA', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
                    });
                    $('#COD_PROVINCIA').on('change', function () {
                        var pais = $('select#cod_pais').val();
                        app.core.LookupDependency($('select#COD_PROVINCIA').val(), 'COD_LOCALIDAD', 'Distritos', '', null, false, null, `cod_pais=${pais}:cod_prov=`);
                    });
                }, ``);


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