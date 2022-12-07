var app = app || {};

app.kycpersona = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {
	
app.core.Get(app.setting.apipath + 'v1/Quote/personaSetup', null,
            function (data) {
                app.core.Lookups(['Gender.sexo',],
                    function () {
                        setupData = data;
                        MapObjectToInput(data);
                    }, ``);

            });
    };
    
    function ReadOnly() {
        $('#primerapellido').replaceWith('<div>' + $('#primerapellido').val() + '</div>');
        $('#segundoapellido').replaceWith('<div>' + $('#segundoapellido').val() + '</div>');
        $('#nombre').replaceWith('<div>' + $('#nombre').val() + '</div>');
        $('#codigodecliente').replaceWith('<div>' + $('#codigodecliente').val() + '</div>');
        $('#numerodeidentificacion').replaceWith('<div>' + $('#numerodeidentificacion').val() + '</div>');
        $('#tipodeidentificacion').replaceWith('<div>' + $('#tipodeidentificacion').val() + '</div>');
        $('#fechadecaducidad').replaceWith('<div>' + $('#fechadecaducidad').val() + '</div>');
        $('#nacionalidad').replaceWith('<div>' + $('#nacionalidad option:selected').text() + '</div>');
        $('#fechadenacimiento_group').replaceWith('<div>' + $('#fechadenacimiento').val() + '</div>');
        $('#paisdenacimiento').replaceWith('<div>' + $('#paisdenacimiento option:selected').text() + '</div>');
        $('#profesion').replaceWith('<div>' + $('#profesion option:selected').text() + '</div>');
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
        $('label[for=ctrol1').next().replaceWith('<div>' + $('label[for=ctrol1_'+app.ui.GetRadioNumericValue('ctrol1')+'').html() + '</div>');
        $('#nombredelaempresaonegocio').replaceWith('<div>' + $('#nombredelaempresaonegocio').val() + '</div>');
        $('#actividaddelaempresaonegocio').replaceWith('<div>' + $('#actividaddelaempresaonegocio').val() + '</div>');
        $('#cargoquedesempena').replaceWith('<div>' + $('#cargoquedesempena').val() + '</div>');
        $('#telefono').replaceWith('<div>' + $('#telefono').val() + '</div>');
        $('#datosdelaempresaolugarquegenerasusingresosencasodeserindependienteFax').replaceWith('<div>' + $('#datosdelaempresaolugarquegenerasusingresosencasodeserindependienteFax').val() + '</div>');
        $('#domiciliocomercialPais').replaceWith('<div>' + $('#domiciliocomercialPais option:selected').text() + '</div>');
        $('#domiciliocomercialProvincia').replaceWith('<div>' + $('#domiciliocomercialProvincia option:selected').text() + '</div>');
        $('#domiciliocomercialCanton').replaceWith('<div>' + $('#domiciliocomercialCanton option:selected').text() + '</div>');
        $('#domiciliocomercialDistrito').replaceWith('<div>' + $('#domiciliocomercialDistrito option:selected').text() + '</div>');
        $('#domiciliocomercialDireccionexacta').replaceWith('<div>' + $('#domiciliocomercialDireccionexacta').val() + '</div>');
        $('#origendelosFondosDedondeprovienenyenqueforma').replaceWith('<div>' + $('#origendelosFondosDedondeprovienenyenqueforma').val() + '</div>');
        $('#enquepaisdesarrollalamayoriadesusactividadeseconomicas').replaceWith('<div>' + $('#enquepaisdesarrollalamayoriadesusactividadeseconomicas').val() + '</div>');
        $('#ingresomensualestimado').replaceWith('<div>' + $('#ingresomensualestimado').val() + '</div>');
        $('label[for=losfondospormovilizarsonpropiosodeterceros').next().replaceWith('<div>' + $('label[for=losfondospormovilizarsonpropiosodeterceros_'+app.ui.GetRadioNumericValue('losfondospormovilizarsonpropiosodeterceros')+'').html() + '</div>');
        $('label[for=sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos').next().replaceWith('<div>' + $('label[for=sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos_'+app.ui.GetRadioNumericValue('sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos')+'').html() + '</div>');
        $('label[for=lamayoriadesusactivoscorrespondena').next().replaceWith('<div>' + $('label[for=lamayoriadesusactivoscorrespondena_'+app.ui.GetRadioNumericValue('lamayoriadesusactivoscorrespondena')+'').html() + '</div>');
        $('label[for=manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero').next().replaceWith('<div>' + $('label[for=manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero_'+app.ui.GetRadioNumericValue('manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero')+'').html() + '</div>');
        $('#encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones').replaceWith('<div>' + $('#encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones').val() + '</div>');
        $('label[for=manifiestatenerrelaciondirectaconsaguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP').next().replaceWith('<div>' + $('label[for=manifiestatenerrelaciondirectaconsaguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP_'+app.ui.GetRadioNumericValue('manifiestatenerrelaciondirectaconsaguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP')+'').html() + '</div>');
        $('#detalleeltipoderelacion').replaceWith('<div>' + $('#detalleeltipoderelacion').val() + '</div>');
        $('#propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendo').replaceWith('<div>' + $('#propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendo').val() + '</div>');
        $('#montoprima').replaceWith('<div>' + $('#montoprima').val() + '</div>');
        $('#tipodeprima').replaceWith('<div>' + $('#tipodeprima').val() + '</div>');
        $('label[for=periodicidad').next().replaceWith('<div>' + $('label[for=periodicidad_'+app.ui.GetRadioNumericValue('periodicidad')+'').html() + '</div>');
        $('#montoValorasegurado').replaceWith('<div>' + $('#montoValorasegurado').val() + '</div>');
        $('label[for=formadepagodelapoliza').next().replaceWith('<div>' + $('label[for=formadepagodelapoliza_'+app.ui.GetRadioNumericValue('formadepagodelapoliza')+'').html() + '</div>');
        $('label[for=favorindicarelmedioporelcualdeseaqueseleenvieinformacion').next().replaceWith('<div>' + $('label[for=favorindicarelmedioporelcualdeseaqueseleenvieinformacion_'+app.ui.GetRadioNumericValue('favorindicarelmedioporelcualdeseaqueseleenvieinformacion')+'').html() + '</div>');
        $('#especifique').replaceWith('<div>' + $('#especifique').val() + '</div>');

    };
    
  function MapInputToObject() {
        var data = {
            primerapellido: $('#primerapellido').val(),
            segundoapellido: $('#segundoapellido').val(),
            nombre: $('#nombre').val(),
            codigodecliente: $('#codigodecliente').val(),
            numerodeidentificacion: $('#numerodeidentificacion').val(),
            tipodeidentificacion: $('#tipodeidentificacion').val(),
            fechadecaducidad: $('#fechadecaducidad').val(),
            nacionalidad: app.ui.GetDropDownNumericValue('#nacionalidad'),
            fechadenacimiento: app.ui.GetDateValue('#fechadenacimiento'),
            paisdenacimiento: app.ui.GetDropDownNumericValue('#paisdenacimiento'),
            profesion: app.ui.GetDropDownNumericValue('#profesion'),
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
            ctrol1: app.ui.GetRadioNumericValue('ctrol1'),
            nombredelaempresaonegocio: $('#nombredelaempresaonegocio').val(),
            actividaddelaempresaonegocio: $('#actividaddelaempresaonegocio').val(),
            cargoquedesempena: $('#cargoquedesempena').val(),
            telefono: $('#telefono').val(),
            datosdelaempresaolugarquegenerasusingresosencasodeserindependienteFax: $('#datosdelaempresaolugarquegenerasusingresosencasodeserindependienteFax').val(),
            domiciliocomercialPais: app.ui.GetDropDownNumericValue('#domiciliocomercialPais'),
            domiciliocomercialProvincia: app.ui.GetDropDownNumericValue('#domiciliocomercialProvincia'),
            domiciliocomercialCanton: app.ui.GetDropDownNumericValue('#domiciliocomercialCanton'),
            domiciliocomercialDistrito: app.ui.GetDropDownNumericValue('#domiciliocomercialDistrito'),
            domiciliocomercialDireccionexacta: $('#domiciliocomercialDireccionexacta').val(),
            origendelosFondosDedondeprovienenyenqueforma: $('#origendelosFondosDedondeprovienenyenqueforma').val(),
            enquepaisdesarrollalamayoriadesusactividadeseconomicas: $('#enquepaisdesarrollalamayoriadesusactividadeseconomicas').val(),
            ingresomensualestimado: $('#ingresomensualestimado').val(),
            losfondospormovilizarsonpropiosodeterceros: app.ui.GetRadioNumericValue('losfondospormovilizarsonpropiosodeterceros'),
            sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos: app.ui.GetRadioNumericValue('sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos'),
            lamayoriadesusactivoscorrespondena: app.ui.GetRadioNumericValue('lamayoriadesusactivoscorrespondena'),
            manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero: app.ui.GetRadioNumericValue('manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero'),
            encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones: $('#encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones').val(),
            manifiestatenerrelaciondirectaconsaguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP: app.ui.GetRadioNumericValue('manifiestatenerrelaciondirectaconsaguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP'),
            detalleeltipoderelacion: $('#detalleeltipoderelacion').val(),
            propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendo: $('#propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendo').val(),
            montoprima: $('#montoprima').val(),
            tipodeprima: $('#tipodeprima').val(),
            periodicidad: app.ui.GetRadioNumericValue('periodicidad'),
            montoValorasegurado: $('#montoValorasegurado').val(),
            formadepagodelapoliza: app.ui.GetRadioNumericValue('formadepagodelapoliza'),
            favorindicarelmedioporelcualdeseaqueseleenvieinformacion: app.ui.GetRadioNumericValue('favorindicarelmedioporelcualdeseaqueseleenvieinformacion'),
            especifique: $('#especifique').val(),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#primerapellido').val(data.primerapellido);
        $('#segundoapellido').val(data.segundoapellido);
        $('#nombre').val(data.nombre);
        $('#codigodecliente').val(data.codigodecliente);
        $('#numerodeidentificacion').val(data.numerodeidentificacion);
        $('#tipodeidentificacion').val(data.tipodeidentificacion);
        $('#fechadecaducidad').val(data.fechadecaducidad);
        $('#nacionalidad').val(data.nacionalidad);
        app.ui.SetDropDownNumericValue('#nacionalidad', data.nacionalidad, true);
        app.ui.SetDateValue('#fechadenacimiento', data.fechadenacimiento);
        $('#paisdenacimiento').val(data.paisdenacimiento);
        app.ui.SetDropDownNumericValue('#paisdenacimiento', data.paisdenacimiento, true);
        $('#profesion').val(data.profesion);
        app.ui.SetDropDownNumericValue('#profesion', data.profesion, true);
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
        app.ui.SetRadioNumericValue('ctrol1', data.ctrol1);
        $('#nombredelaempresaonegocio').val(data.nombredelaempresaonegocio);
        $('#actividaddelaempresaonegocio').val(data.actividaddelaempresaonegocio);
        $('#cargoquedesempena').val(data.cargoquedesempena);
        $('#telefono').val(data.telefono);
        $('#datosdelaempresaolugarquegenerasusingresosencasodeserindependienteFax').val(data.datosdelaempresaolugarquegenerasusingresosencasodeserindependienteFax);
        $('#domiciliocomercialPais').val(data.domiciliocomercialPais);
        app.ui.SetDropDownNumericValue('#domiciliocomercialPais', data.domiciliocomercialPais, true);
        $('#domiciliocomercialProvincia').val(data.domiciliocomercialProvincia);
        app.ui.SetDropDownNumericValue('#domiciliocomercialProvincia', data.domiciliocomercialProvincia, true);
        $('#domiciliocomercialCanton').val(data.domiciliocomercialCanton);
        app.ui.SetDropDownNumericValue('#domiciliocomercialCanton', data.domiciliocomercialCanton, true);
        $('#domiciliocomercialDistrito').val(data.domiciliocomercialDistrito);
        app.ui.SetDropDownNumericValue('#domiciliocomercialDistrito', data.domiciliocomercialDistrito, true);
        $('#domiciliocomercialDireccionexacta').val(data.domiciliocomercialDireccionexacta);
        $('#origendelosFondosDedondeprovienenyenqueforma').val(data.origendelosFondosDedondeprovienenyenqueforma);
        $('#enquepaisdesarrollalamayoriadesusactividadeseconomicas').val(data.enquepaisdesarrollalamayoriadesusactividadeseconomicas);
        $('#ingresomensualestimado').val(data.ingresomensualestimado);
        app.ui.SetRadioNumericValue('losfondospormovilizarsonpropiosodeterceros', data.losfondospormovilizarsonpropiosodeterceros);
        app.ui.SetRadioNumericValue('sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos', data.sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos);
        app.ui.SetRadioNumericValue('lamayoriadesusactivoscorrespondena', data.lamayoriadesusactivoscorrespondena);
        app.ui.SetRadioNumericValue('manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero', data.manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero);
        $('#encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones').val(data.encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones);
        app.ui.SetRadioNumericValue('manifiestatenerrelaciondirectaconsaguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP', data.manifiestatenerrelaciondirectaconsaguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP);
        $('#detalleeltipoderelacion').val(data.detalleeltipoderelacion);
        $('#propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendo').val(data.propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendo);
        $('#montoprima').val(data.montoprima);
        $('#tipodeprima').val(data.tipodeprima);
        app.ui.SetRadioNumericValue('periodicidad', data.periodicidad);
        $('#montoValorasegurado').val(data.montoValorasegurado);
        app.ui.SetRadioNumericValue('formadepagodelapoliza', data.formadepagodelapoliza);
        app.ui.SetRadioNumericValue('favorindicarelmedioporelcualdeseaqueseleenvieinformacion', data.favorindicarelmedioporelcualdeseaqueseleenvieinformacion);
        $('#especifique').val(data.especifique);

    };
    
    function Controls_setup() {
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
$('#telefono').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
$('#datosdelaempresaolugarquegenerasusingresosencasodeserindependienteFax').formatter({
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

                app.core.Post(app.setting.apipath + 'v1/kyc/persona',
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


