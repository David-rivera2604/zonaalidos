var app = app || {};
app.PurdyPanelDetalle = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {

        app.core.Get(app.setting.apipath + 'v1/Quote/PanelDetalleSetup', null,
            function (data) {
                app.core.Lookups([],
                    function () {
                        setupData = data;
                        MapObjectToInput(data);
                    }, ``);

            });
    };

    function ReadOnly() {
        $('#numerodepoliza').replaceWith('<div>' + $('#numerodepoliza').val() + '</div>');
        $('#monedadepoliza').replaceWith('<div>' + $('#monedadepoliza').val() + '</div>');
        $('#usodepoliza').replaceWith('<div>' + $('#usodepoliza').val() + '</div>');
        $('#coberturaafectada').replaceWith('<div>' + $('#coberturaafectada').val() + '</div>');
        $('#primaanual').replaceWith('<div>' + $('#primaanual').val() + '</div>');
        $('#primaspagadas').replaceWith('<div>' + $('#primaspagadas').val() + '</div>');
        $('#primaspendientesdecobro').replaceWith('<div>' + $('#primaspendientesdecobro').val() + '</div>');
        $('#fechaultimaprimacobrada').replaceWith('<div>' + $('#fechaultimaprimacobrada').val() + '</div>');
        $('#deducible').replaceWith('<div>' + $('#deducible').val() + '</div>');
        $('#tomador').replaceWith('<div>' + $('#tomador').val() + '</div>');
        $('#acreedor').replaceWith('<div>' + $('#acreedor').val() + '</div>');
        $('#placa').replaceWith('<div>' + $('#placa').val() + '</div>');
        $('#chasis').replaceWith('<div>' + $('#chasis').val() + '</div>');
        $('#marca').replaceWith('<div>' + $('#marca').val() + '</div>');
        $('#valorasegurado').replaceWith('<div>' + $('#valorasegurado').val() + '</div>');
        $('#nombredelchoferduranteelsiniestro').replaceWith('<div>' + $('#nombredelchoferduranteelsiniestro').val() + '</div>');
        $('#telefonodechofer').replaceWith('<div>' + $('#telefonodechofer').val() + '</div>');

    };

    function MapInputToObject() {
        var data = {
            numerodepoliza: $('#numerodepoliza').val(),
            monedadepoliza: $('#monedadepoliza').val(),
            usodepoliza: $('#usodepoliza').val(),
            coberturaafectada: $('#coberturaafectada').val(),
            primaanual: $('#primaanual').val(),
            primaspagadas: $('#primaspagadas').val(),
            primaspendientesdecobro: $('#primaspendientesdecobro').val(),
            fechaultimaprimacobrada: $('#fechaultimaprimacobrada').val(),
            deducible: $('#deducible').val(),
            tomador: $('#tomador').val(),
            acreedor: $('#acreedor').val(),
            placa: $('#placa').val(),
            chasis: $('#chasis').val(),
            marca: $('#marca').val(),
            valorasegurado: $('#valorasegurado').val(),
            nombredelchoferduranteelsiniestro: $('#nombredelchoferduranteelsiniestro').val(),
            telefonodechofer: $('#telefonodechofer').val(),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#numerodepoliza').val(data.numerodepoliza);
        $('#monedadepoliza').val(data.monedadepoliza);
        $('#usodepoliza').val(data.usodepoliza);
        $('#coberturaafectada').val(data.coberturaafectada);
        $('#primaanual').val(data.primaanual);
        $('#primaspagadas').val(data.primaspagadas);
        $('#primaspendientesdecobro').val(data.primaspendientesdecobro);
        $('#fechaultimaprimacobrada').val(data.fechaultimaprimacobrada);
        $('#deducible').val(data.deducible);
        $('#tomador').val(data.tomador);
        $('#acreedor').val(data.acreedor);
        $('#placa').val(data.placa);
        $('#chasis').val(data.chasis);
        $('#marca').val(data.marca);
        $('#valorasegurado').val(data.valorasegurado);
        $('#nombredelchoferduranteelsiniestro').val(data.nombredelchoferduranteelsiniestro);
        $('#telefonodechofer').val(data.telefonodechofer);

    };

    function Controls_setup() {

    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#PurdyPanelDetalleEdtForm :input").change(function () {
            data_changed();
        });


        $('#PurdyPanelDetalleEdtFormSave').click(function () {

            if (app.ui.IsValid('#PurdyPanelDetalleEdtForm', false)) {
                app.ui.ButtonDoing('#PurdyPanelDetalleEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/Purdy/PanelDetalle',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {

                        }

                    }).always(function () {
                        app.ui.ButtonDone('#PurdyPanelDetalleEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#PurdyPanelDetalleEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#PurdyPanelDetalleEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PurdyPanelDetalleEdtFormCancel'); }, 3000);
            event.preventDefault();
        });

    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#PurdyPanelDetalleEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {},
            messages: {}
        });
    };



    return {
        Init: function () {
            try {
                Controls_setup();
                Setup_Validations();

                Controls_Events();
                Setup();
                //Custom.Extend
                console.log("Inicio");
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Data: function () {
            return MapInputToObject();
        },
        SetData: function (data) {
            MapObjectToInput(data);
        },
        Changed: function (callback) {
            changedCallback = callback;
        },
        IsValid: function (showResume) {
            return app.ui.IsValid('#PurdyPanelDetalleEdtForm', false, showResume);
        }
    };
})();


