var app = app || {};

app.kycdeclarante = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {
	
app.core.Get(app.setting.apipath + 'v1/Quote/declaranteSetup', null,
            function (data) {
                app.core.Lookups(['Pais.paisdenacimiento','CivilStatus.estadocivil','Gender.sexo','Pais.pais','CR_Provincia.provincia','CR_Canton.canton','CR_Distritos.distrito',],
                    function () {
                        setupData = data;
                        MapObjectToInput(data);
                    }, ``);

            });
    };
    
    function ReadOnly() {
        $('#primerapellido').replaceWith('<div>' + $('#primerapellido').val() + '</div>');
        $('#segundoapellido').replaceWith('<div>' + $('#segundoapellido').val() + '</div>');
        $('#nombrecompleto').replaceWith('<div>' + $('#nombrecompleto').val() + '</div>');
        $('#posiciondentrodelaempresa').replaceWith('<div>' + $('#posiciondentrodelaempresa').val() + '</div>');
        $('#numerodeidentificacion').replaceWith('<div>' + $('#numerodeidentificacion').val() + '</div>');
        $('label[for=tipodeidentificacion').next().replaceWith('<div>' + $('label[for=tipodeidentificacion_'+app.ui.GetRadioNumericValue('tipodeidentificacion')+'').html() + '</div>');
        $('#especifique').replaceWith('<div>' + $('#especifique').val() + '</div>');
        $('#fechadecaducidad_group').replaceWith('<div>' + $('#fechadecaducidad').val() + '</div>');
        $('#nacionalidad').replaceWith('<div>' + $('#nacionalidad option:selected').text() + '</div>');
        $('#fechadenacimiento_group').replaceWith('<div>' + $('#fechadenacimiento').val() + '</div>');
        $('#paisdenacimiento').replaceWith('<div>' + $('#paisdenacimiento option:selected').text() + '</div>');
        $('#profesion').replaceWith('<div>' + $('#profesion').val() + '</div>');
        $('#estadocivil').replaceWith('<div>' + $('#estadocivil option:selected').text() + '</div>');
        $('#sexo').replaceWith('<div>' + $('#sexo option:selected').text() + '</div>');
        $('#telefonoresidencia').replaceWith('<div>' + $('#telefonoresidencia').val() + '</div>');
        $('#telefonocelular').replaceWith('<div>' + $('#telefonocelular').val() + '</div>');
        $('#fax').replaceWith('<div>' + $('#fax').val() + '</div>');
        $('#apartadoPostal').replaceWith('<div>' + $('#apartadoPostal').val() + '</div>');
        $('#correoelectronico').replaceWith('<div>' + $('#correoelectronico').val() + '</div>');
        $('#pais').replaceWith('<div>' + $('#pais option:selected').text() + '</div>');
        $('#provincia').replaceWith('<div>' + $('#provincia option:selected').text() + '</div>');
        $('#canton').replaceWith('<div>' + $('#canton option:selected').text() + '</div>');
        $('#distrito').replaceWith('<div>' + $('#distrito option:selected').text() + '</div>');
        $('#direccionexacta').replaceWith('<div>' + $('#direccionexacta').val() + '</div>');
        $('#origendelosFondosDedondeprovienenyenqueforma').replaceWith('<div>' + $('#origendelosFondosDedondeprovienenyenqueforma').val() + '</div>');
        $('#enquepaisdesarrollalamayoriadesusactividadeseconomicas').replaceWith('<div>' + $('#enquepaisdesarrollalamayoriadesusactividadeseconomicas').val() + '</div>');
        $('#ingresomensualestimado').replaceWith('<div>' + $('#ingresomensualestimado').val() + '</div>');
        $('label[for=losfondospormovilizarsonpropiosodeterceros').next().replaceWith('<div>' + $('label[for=losfondospormovilizarsonpropiosodeterceros_'+app.ui.GetRadioNumericValue('losfondospormovilizarsonpropiosodeterceros')+'').html() + '</div>');
        $('label[for=sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos').next().replaceWith('<div>' + $('label[for=sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos_'+app.ui.GetRadioNumericValue('sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos')+'').html() + '</div>');
        $('label[for=lamayoriadesusactivoscorrespondena').next().replaceWith('<div>' + $('label[for=lamayoriadesusactivoscorrespondena_'+app.ui.GetRadioNumericValue('lamayoriadesusactivoscorrespondena')+'').html() + '</div>');
        $('label[for=algunSocioDirectoroRepresentantedelaempresadesempenaohadesempenadoalguncargopolitico').next().replaceWith('<div>' + $('label[for=algunSocioDirectoroRepresentantedelaempresadesempenaohadesempenadoalguncargopolitico_'+app.ui.GetRadioNumericValue('algunSocioDirectoroRepresentantedelaempresadesempenaohadesempenadoalguncargopolitico')+'').html() + '</div>');
        $('#encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones').replaceWith('<div>' + $('#encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones').val() + '</div>');
        $('label[for=algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEP').next().replaceWith('<div>' + $('label[for=algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEP_'+app.ui.GetRadioNumericValue('algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEP')+'').html() + '</div>');
        $('#detalleeltipoderelacion').replaceWith('<div>' + $('#detalleeltipoderelacion').val() + '</div>');
        $('label[for=favorindicarelmedioporelcualdeseaqueseleenvieinformacion').next().replaceWith('<div>' + $('label[for=favorindicarelmedioporelcualdeseaqueseleenvieinformacion_'+app.ui.GetRadioNumericValue('favorindicarelmedioporelcualdeseaqueseleenvieinformacion')+'').html() + '</div>');
        $('#correspondenciaEspecifique').replaceWith('<div>' + $('#correspondenciaEspecifique').val() + '</div>');

    };
    
  function MapInputToObject() {
        var data = {
            primerapellido: $('#primerapellido').val(),
            segundoapellido: $('#segundoapellido').val(),
            nombrecompleto: $('#nombrecompleto').val(),
            posiciondentrodelaempresa: $('#posiciondentrodelaempresa').val(),
            numerodeidentificacion: $('#numerodeidentificacion').val(),
            tipodeidentificacion: app.ui.GetRadioNumericValue('tipodeidentificacion'),
            especifique: $('#especifique').val(),
            fechadecaducidad: app.ui.GetDateValue('#fechadecaducidad'),
            nacionalidad: app.ui.GetDropDownNumericValue('#nacionalidad'),
            fechadenacimiento: app.ui.GetDateValue('#fechadenacimiento'),
            paisdenacimiento: app.ui.GetDropDownNumericValue('#paisdenacimiento'),
            profesion: $('#profesion').val(),
            estadocivil: app.ui.GetDropDownNumericValue('#estadocivil'),
            sexo: app.ui.GetDropDownNumericValue('#sexo'),
            telefonoresidencia: $('#telefonoresidencia').val(),
            telefonocelular: $('#telefonocelular').val(),
            fax: $('#fax').val(),
            apartadoPostal: $('#apartadoPostal').val(),
            correoelectronico: $('#correoelectronico').val(),
            pais: app.ui.GetDropDownNumericValue('#pais'),
            provincia: app.ui.GetDropDownNumericValue('#provincia'),
            canton: app.ui.GetDropDownNumericValue('#canton'),
            distrito: app.ui.GetDropDownNumericValue('#distrito'),
            direccionexacta: $('#direccionexacta').val(),
            origendelosFondosDedondeprovienenyenqueforma: $('#origendelosFondosDedondeprovienenyenqueforma').val(),
            enquepaisdesarrollalamayoriadesusactividadeseconomicas: $('#enquepaisdesarrollalamayoriadesusactividadeseconomicas').val(),
            ingresomensualestimado: $('#ingresomensualestimado').val(),
            losfondospormovilizarsonpropiosodeterceros: app.ui.GetRadioNumericValue('losfondospormovilizarsonpropiosodeterceros'),
            sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos: app.ui.GetRadioNumericValue('sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos'),
            lamayoriadesusactivoscorrespondena: app.ui.GetRadioNumericValue('lamayoriadesusactivoscorrespondena'),
            algunSocioDirectoroRepresentantedelaempresadesempenaohadesempenadoalguncargopolitico: app.ui.GetRadioNumericValue('algunSocioDirectoroRepresentantedelaempresadesempenaohadesempenadoalguncargopolitico'),
            encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones: $('#encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones').val(),
            algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEP: app.ui.GetRadioNumericValue('algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEP'),
            detalleeltipoderelacion: $('#detalleeltipoderelacion').val(),
            favorindicarelmedioporelcualdeseaqueseleenvieinformacion: app.ui.GetRadioNumericValue('favorindicarelmedioporelcualdeseaqueseleenvieinformacion'),
            correspondenciaEspecifique: $('#correspondenciaEspecifique').val(),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#primerapellido').val(data.primerapellido);
        $('#segundoapellido').val(data.segundoapellido);
        $('#nombrecompleto').val(data.nombrecompleto);
        $('#posiciondentrodelaempresa').val(data.posiciondentrodelaempresa);
        $('#numerodeidentificacion').val(data.numerodeidentificacion);
        app.ui.SetRadioNumericValue('tipodeidentificacion', data.tipodeidentificacion);
        $('#especifique').val(data.especifique);
        app.ui.SetDateValue('#fechadecaducidad', data.fechadecaducidad);
        $('#nacionalidad').val(data.nacionalidad);
        app.ui.SetDropDownNumericValue('#nacionalidad', data.nacionalidad, true);
        app.ui.SetDateValue('#fechadenacimiento', data.fechadenacimiento);
        $('#paisdenacimiento').val(data.paisdenacimiento);
        app.ui.SetDropDownNumericValue('#paisdenacimiento', data.paisdenacimiento, true);
        $('#profesion').val(data.profesion);
        $('#estadocivil').val(data.estadocivil);
        app.ui.SetDropDownNumericValue('#estadocivil', data.estadocivil, true);
        $('#sexo').val(data.sexo);
        app.ui.SetDropDownNumericValue('#sexo', data.sexo, true);
        $('#telefonoresidencia').val(data.telefonoresidencia);
        $('#telefonocelular').val(data.telefonocelular);
        $('#fax').val(data.fax);
        $('#apartadoPostal').val(data.apartadoPostal);
        $('#correoelectronico').val(data.correoelectronico);
        $('#pais').val(data.pais);
        app.ui.SetDropDownNumericValue('#pais', data.pais, true);
        $('#provincia').val(data.provincia);
        app.ui.SetDropDownNumericValue('#provincia', data.provincia, true);
        $('#canton').val(data.canton);
        app.ui.SetDropDownNumericValue('#canton', data.canton, true);
        $('#distrito').val(data.distrito);
        app.ui.SetDropDownNumericValue('#distrito', data.distrito, true);
        $('#direccionexacta').val(data.direccionexacta);
        $('#origendelosFondosDedondeprovienenyenqueforma').val(data.origendelosFondosDedondeprovienenyenqueforma);
        $('#enquepaisdesarrollalamayoriadesusactividadeseconomicas').val(data.enquepaisdesarrollalamayoriadesusactividadeseconomicas);
        $('#ingresomensualestimado').val(data.ingresomensualestimado);
        app.ui.SetRadioNumericValue('losfondospormovilizarsonpropiosodeterceros', data.losfondospormovilizarsonpropiosodeterceros);
        app.ui.SetRadioNumericValue('sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos', data.sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos);
        app.ui.SetRadioNumericValue('lamayoriadesusactivoscorrespondena', data.lamayoriadesusactivoscorrespondena);
        app.ui.SetRadioNumericValue('algunSocioDirectoroRepresentantedelaempresadesempenaohadesempenadoalguncargopolitico', data.algunSocioDirectoroRepresentantedelaempresadesempenaohadesempenadoalguncargopolitico);
        $('#encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones').val(data.encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones);
        app.ui.SetRadioNumericValue('algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEP', data.algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEP);
        $('#detalleeltipoderelacion').val(data.detalleeltipoderelacion);
        app.ui.SetRadioNumericValue('favorindicarelmedioporelcualdeseaqueseleenvieinformacion', data.favorindicarelmedioporelcualdeseaqueseleenvieinformacion);
        $('#correspondenciaEspecifique').val(data.correspondenciaEspecifique);

    };
    
    function Controls_setup() {
$('#fechadecaducidad_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
$('#fechadenacimiento_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
$('#telefonoresidencia').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
$('#telefonocelular').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
$('#fax').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });

    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#PrototypeEdtForm :input").change(function () {
            data_changed();
        });
        

        $('#PrototypeEdtFormSave').click(function () {

            if (app.ui.IsValid('#PrototypeEdtForm', false)) {
                app.ui.ButtonDoing('#PrototypeEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/kyc/declarante',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {
                        
                        }

                    }).always(function () {
                        app.ui.ButtonDone('#PrototypeEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#PrototypeEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#PrototypeEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PrototypeEdtFormCancel'); }, 3000);
            event.preventDefault();
        });

    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };
    
    function Setup_Validations() {
        app.ui.DateValidators();
        $("#PrototypeEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {correoelectronico: { email: true },
},
            messages: {correoelectronico: { email: 'Debe indicar un correo electrónico valido' },
}
        });
    };



    return {
        Init: function () {
			try {
				Controls_setup();
				Setup_Validations();
	
				Controls_Events();
				Setup();
				console.log("Inicio");
			}
			catch(err) {
			  console.error("Error Init");
			  console.error(err);
			}
        },
        Data: function () {
            return MapInputToObject();
        },
        Changed: function (callback) {
            changedCallback = callback;
        },
        IsValid: function (showResume) {
            return app.ui.IsValid('#PrototypeEdtForm', false, showResume);
        }
    };
})();


