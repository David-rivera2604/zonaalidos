var app = app || {};

app.kycjuridico = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {
	
app.core.Get(app.setting.apipath + 'v1/Quote/juridicoSetup', null,
            function (data) {
                app.core.Lookups(['Pais.paisdeconstitucion','Pais.pais','CR_Provincia.provincia','CR_Canton.canton','CR_Distritos.distrito','Pais.paisdenacimiento','CivilStatus.estadocivil','Gender.sexo','Pais.domiciliopermanentePais','CR_Provincia.domiciliopermanenteProvincia','CR_Canton.domiciliopermanenteCanton','CR_Distritos.domiciliopermanenteDistrito',],
                    function () {
                        setupData = data;
                        MapObjectToInput(data);
                    }, ``);

            });
    };
    
    function ReadOnly() {
        $('#nombreComercial').replaceWith('<div>' + $('#nombreComercial').val() + '</div>');
        $('#razonSocial').replaceWith('<div>' + $('#razonSocial').val() + '</div>');
        $('#codigodecliente').replaceWith('<div>' + $('#codigodecliente').val() + '</div>');
        $('#tipodeSociedad').replaceWith('<div>' + $('#tipodeSociedad').val() + '</div>');
        $('#numeroCedulaJuridica').replaceWith('<div>' + $('#numeroCedulaJuridica').val() + '</div>');
        $('label[for=tipodeCedulaJuridica').next().replaceWith('<div>' + $('label[for=tipodeCedulaJuridica_'+app.ui.GetRadioNumericValue('tipodeCedulaJuridica')+'').html() + '</div>');
        $('#paisdeconstitucion').replaceWith('<div>' + $('#paisdeconstitucion option:selected').text() + '</div>');
        $('#fechadeconstitucion_group').replaceWith('<div>' + $('#fechadeconstitucion').val() + '</div>');
        $('#actividaddelClientenaturalezadelnegocio').replaceWith('<div>' + $('#actividaddelClientenaturalezadelnegocio').val() + '</div>');
        $('#telefono').replaceWith('<div>' + $('#telefono').val() + '</div>');
        $('#fax').replaceWith('<div>' + $('#fax').val() + '</div>');
        $('#apartadoPostal').replaceWith('<div>' + $('#apartadoPostal').val() + '</div>');
        $('#correoelectronico').replaceWith('<div>' + $('#correoelectronico').val() + '</div>');
        $('#paginaWeb').replaceWith('<div>' + $('#paginaWeb').val() + '</div>');
        $('#pais').replaceWith('<div>' + $('#pais option:selected').text() + '</div>');
        $('#provincia').replaceWith('<div>' + $('#provincia option:selected').text() + '</div>');
        $('#canton').replaceWith('<div>' + $('#canton option:selected').text() + '</div>');
        $('#distrito').replaceWith('<div>' + $('#distrito option:selected').text() + '</div>');
        $('#direccionexacta').replaceWith('<div>' + $('#direccionexacta').val() + '</div>');
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
        $('#datosdelrepresentantelegalFax').replaceWith('<div>' + $('#datosdelrepresentantelegalFax').val() + '</div>');
        $('#datosdelrepresentantelegalApartadoPostal').replaceWith('<div>' + $('#datosdelrepresentantelegalApartadoPostal').val() + '</div>');
        $('#datosdelrepresentantelegalCorreoelectronico').replaceWith('<div>' + $('#datosdelrepresentantelegalCorreoelectronico').val() + '</div>');
        $('#domiciliopermanentePais').replaceWith('<div>' + $('#domiciliopermanentePais option:selected').text() + '</div>');
        $('#domiciliopermanenteProvincia').replaceWith('<div>' + $('#domiciliopermanenteProvincia option:selected').text() + '</div>');
        $('#domiciliopermanenteCanton').replaceWith('<div>' + $('#domiciliopermanenteCanton option:selected').text() + '</div>');
        $('#domiciliopermanenteDistrito').replaceWith('<div>' + $('#domiciliopermanenteDistrito option:selected').text() + '</div>');
        $('#domiciliopermanenteDireccionexacta').replaceWith('<div>' + $('#domiciliopermanenteDireccionexacta').val() + '</div>');
        $('#origendelosFondosDedondeprovienenyenqueforma').replaceWith('<div>' + $('#origendelosFondosDedondeprovienenyenqueforma').val() + '</div>');
        $('#enquepaisdesarrollalamayoriadesusactividadeseconomicas').replaceWith('<div>' + $('#enquepaisdesarrollalamayoriadesusactividadeseconomicas').val() + '</div>');
        $('#ingresomensualestimado').replaceWith('<div>' + $('#ingresomensualestimado').val() + '</div>');
        $('label[for=losfondospormovilizarsonpropiosodeterceros').next().replaceWith('<div>' + $('label[for=losfondospormovilizarsonpropiosodeterceros_'+app.ui.GetRadioNumericValue('losfondospormovilizarsonpropiosodeterceros')+'').html() + '</div>');
        $('label[for=sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos').next().replaceWith('<div>' + $('label[for=sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos_'+app.ui.GetRadioNumericValue('sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos')+'').html() + '</div>');
        $('label[for=lamayoriadesusactivoscorrespondena').next().replaceWith('<div>' + $('label[for=lamayoriadesusactivoscorrespondena_'+app.ui.GetRadioNumericValue('lamayoriadesusactivoscorrespondena')+'').html() + '</div>');
        $('label[for=manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero').next().replaceWith('<div>' + $('label[for=manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero_'+app.ui.GetRadioNumericValue('manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero')+'').html() + '</div>');
        $('#encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones').replaceWith('<div>' + $('#encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones').val() + '</div>');
        $('label[for=manifiestatenerrelaciondirectaconsanguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP').next().replaceWith('<div>' + $('label[for=manifiestatenerrelaciondirectaconsanguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP_'+app.ui.GetRadioNumericValue('manifiestatenerrelaciondirectaconsanguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP')+'').html() + '</div>');
        $('#detalleeltipoderelacion').replaceWith('<div>' + $('#detalleeltipoderelacion').val() + '</div>');
        $('#participacionaccionariaNew').addClass('d-none');
        $('#participacionaccionariaTbl').bootstrapTable('hideColumn', 'Actions');
        $('#propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendo').replaceWith('<div>' + $('#propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendo').val() + '</div>');
        $('#montoprima').replaceWith('<div>' + $('#montoprima').val() + '</div>');
        $('#tipodeprima').replaceWith('<div>' + $('#tipodeprima').val() + '</div>');
        $('label[for=periodicidad').next().replaceWith('<div>' + $('label[for=periodicidad_'+app.ui.GetRadioNumericValue('periodicidad')+'').html() + '</div>');
        $('#montoValorasegurado').replaceWith('<div>' + $('#montoValorasegurado').val() + '</div>');
        $('label[for=formadepagodelapoliza').next().replaceWith('<div>' + $('label[for=formadepagodelapoliza_'+app.ui.GetRadioNumericValue('formadepagodelapoliza')+'').html() + '</div>');
        $('label[for=favorindicarelmedioporelcualdeseaqueseleenvieinformacion').next().replaceWith('<div>' + $('label[for=favorindicarelmedioporelcualdeseaqueseleenvieinformacion_'+app.ui.GetRadioNumericValue('favorindicarelmedioporelcualdeseaqueseleenvieinformacion')+'').html() + '</div>');
        $('#correspondenciaEspecifique').replaceWith('<div>' + $('#correspondenciaEspecifique').val() + '</div>');

    };
    
  function MapInputToObject() {
        var data = {
            nombreComercial: $('#nombreComercial').val(),
            razonSocial: $('#razonSocial').val(),
            codigodecliente: $('#codigodecliente').val(),
            tipodeSociedad: $('#tipodeSociedad').val(),
            numeroCedulaJuridica: $('#numeroCedulaJuridica').val(),
            tipodeCedulaJuridica: app.ui.GetRadioNumericValue('tipodeCedulaJuridica'),
            paisdeconstitucion: app.ui.GetDropDownNumericValue('#paisdeconstitucion'),
            fechadeconstitucion: app.ui.GetDateValue('#fechadeconstitucion'),
            actividaddelClientenaturalezadelnegocio: $('#actividaddelClientenaturalezadelnegocio').val(),
            telefono: $('#telefono').val(),
            fax: $('#fax').val(),
            apartadoPostal: $('#apartadoPostal').val(),
            correoelectronico: $('#correoelectronico').val(),
            paginaWeb: $('#paginaWeb').val(),
            pais: app.ui.GetDropDownNumericValue('#pais'),
            provincia: app.ui.GetDropDownNumericValue('#provincia'),
            canton: app.ui.GetDropDownNumericValue('#canton'),
            distrito: app.ui.GetDropDownNumericValue('#distrito'),
            direccionexacta: $('#direccionexacta').val(),
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
            datosdelrepresentantelegalFax: $('#datosdelrepresentantelegalFax').val(),
            datosdelrepresentantelegalApartadoPostal: $('#datosdelrepresentantelegalApartadoPostal').val(),
            datosdelrepresentantelegalCorreoelectronico: $('#datosdelrepresentantelegalCorreoelectronico').val(),
            domiciliopermanentePais: app.ui.GetDropDownNumericValue('#domiciliopermanentePais'),
            domiciliopermanenteProvincia: app.ui.GetDropDownNumericValue('#domiciliopermanenteProvincia'),
            domiciliopermanenteCanton: app.ui.GetDropDownNumericValue('#domiciliopermanenteCanton'),
            domiciliopermanenteDistrito: app.ui.GetDropDownNumericValue('#domiciliopermanenteDistrito'),
            domiciliopermanenteDireccionexacta: $('#domiciliopermanenteDireccionexacta').val(),
            origendelosFondosDedondeprovienenyenqueforma: $('#origendelosFondosDedondeprovienenyenqueforma').val(),
            enquepaisdesarrollalamayoriadesusactividadeseconomicas: $('#enquepaisdesarrollalamayoriadesusactividadeseconomicas').val(),
            ingresomensualestimado: $('#ingresomensualestimado').val(),
            losfondospormovilizarsonpropiosodeterceros: app.ui.GetRadioNumericValue('losfondospormovilizarsonpropiosodeterceros'),
            sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos: app.ui.GetRadioNumericValue('sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos'),
            lamayoriadesusactivoscorrespondena: app.ui.GetRadioNumericValue('lamayoriadesusactivoscorrespondena'),
            manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero: app.ui.GetRadioNumericValue('manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero'),
            encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones: $('#encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones').val(),
            manifiestatenerrelaciondirectaconsanguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP: app.ui.GetRadioNumericValue('manifiestatenerrelaciondirectaconsanguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP'),
            detalleeltipoderelacion: $('#detalleeltipoderelacion').val(),
            participacionaccionaria: $('#participacionaccionariaTbl').bootstrapTable('getData'),
            propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendo: $('#propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendo').val(),
            montoprima: app.ui.GetNumericValue('#montoprima'),
            tipodeprima: $('#tipodeprima').val(),
            periodicidad: app.ui.GetRadioNumericValue('periodicidad'),
            montoValorasegurado: app.ui.GetNumericValue('#montoValorasegurado'),
            formadepagodelapoliza: app.ui.GetRadioNumericValue('formadepagodelapoliza'),
            favorindicarelmedioporelcualdeseaqueseleenvieinformacion: app.ui.GetRadioNumericValue('favorindicarelmedioporelcualdeseaqueseleenvieinformacion'),
            correspondenciaEspecifique: $('#correspondenciaEspecifique').val(),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#nombreComercial').val(data.nombreComercial);
        $('#razonSocial').val(data.razonSocial);
        $('#codigodecliente').val(data.codigodecliente);
        $('#tipodeSociedad').val(data.tipodeSociedad);
        $('#numeroCedulaJuridica').val(data.numeroCedulaJuridica);
        app.ui.SetRadioNumericValue('tipodeCedulaJuridica', data.tipodeCedulaJuridica);
        $('#paisdeconstitucion').val(data.paisdeconstitucion);
        app.ui.SetDropDownNumericValue('#paisdeconstitucion', data.paisdeconstitucion, true);
        app.ui.SetDateValue('#fechadeconstitucion', data.fechadeconstitucion);
        $('#actividaddelClientenaturalezadelnegocio').val(data.actividaddelClientenaturalezadelnegocio);
        $('#telefono').val(data.telefono);
        $('#fax').val(data.fax);
        $('#apartadoPostal').val(data.apartadoPostal);
        $('#correoelectronico').val(data.correoelectronico);
        $('#paginaWeb').val(data.paginaWeb);
        $('#pais').val(data.pais);
        app.ui.SetDropDownNumericValue('#pais', data.pais, true);
        $('#provincia').val(data.provincia);
        app.ui.SetDropDownNumericValue('#provincia', data.provincia, true);
        $('#canton').val(data.canton);
        app.ui.SetDropDownNumericValue('#canton', data.canton, true);
        $('#distrito').val(data.distrito);
        app.ui.SetDropDownNumericValue('#distrito', data.distrito, true);
        $('#direccionexacta').val(data.direccionexacta);
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
        $('#datosdelrepresentantelegalFax').val(data.datosdelrepresentantelegalFax);
        $('#datosdelrepresentantelegalApartadoPostal').val(data.datosdelrepresentantelegalApartadoPostal);
        $('#datosdelrepresentantelegalCorreoelectronico').val(data.datosdelrepresentantelegalCorreoelectronico);
        $('#domiciliopermanentePais').val(data.domiciliopermanentePais);
        app.ui.SetDropDownNumericValue('#domiciliopermanentePais', data.domiciliopermanentePais, true);
        $('#domiciliopermanenteProvincia').val(data.domiciliopermanenteProvincia);
        app.ui.SetDropDownNumericValue('#domiciliopermanenteProvincia', data.domiciliopermanenteProvincia, true);
        $('#domiciliopermanenteCanton').val(data.domiciliopermanenteCanton);
        app.ui.SetDropDownNumericValue('#domiciliopermanenteCanton', data.domiciliopermanenteCanton, true);
        $('#domiciliopermanenteDistrito').val(data.domiciliopermanenteDistrito);
        app.ui.SetDropDownNumericValue('#domiciliopermanenteDistrito', data.domiciliopermanenteDistrito, true);
        $('#domiciliopermanenteDireccionexacta').val(data.domiciliopermanenteDireccionexacta);
        $('#origendelosFondosDedondeprovienenyenqueforma').val(data.origendelosFondosDedondeprovienenyenqueforma);
        $('#enquepaisdesarrollalamayoriadesusactividadeseconomicas').val(data.enquepaisdesarrollalamayoriadesusactividadeseconomicas);
        $('#ingresomensualestimado').val(data.ingresomensualestimado);
        app.ui.SetRadioNumericValue('losfondospormovilizarsonpropiosodeterceros', data.losfondospormovilizarsonpropiosodeterceros);
        app.ui.SetRadioNumericValue('sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos', data.sedesempenaentrelasactividadescitadasenelArticulo15delaLey8204manejodefondosdetercerosfisicosojuridicos);
        app.ui.SetRadioNumericValue('lamayoriadesusactivoscorrespondena', data.lamayoriadesusactivoscorrespondena);
        app.ui.SetRadioNumericValue('manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero', data.manifiestadesempenarohaberdesempenadoalguncargoqueimpliquefuncionespublicasdestacadasenelpaisoenelextranjero);
        $('#encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones').val(data.encasoafirmativoindiqueelperiododuranteelcualdesempenodichasfunciones);
        app.ui.SetRadioNumericValue('manifiestatenerrelaciondirectaconsanguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP', data.manifiestatenerrelaciondirectaconsanguinidadoindirectaafinidadconunapersonaexpuestapoliticamentePEP);
        $('#detalleeltipoderelacion').val(data.detalleeltipoderelacion);
        if (data.participacionaccionaria != null)
            $('#participacionaccionariaTbl').bootstrapTable('load', data.participacionaccionaria);
        else
            $('#participacionaccionariaTbl').bootstrapTable('load', {});
        $('#propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendo').val(data.propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendo);
        app.ui.SetNumericValue('#montoprima', data.montoprima);
        $('#tipodeprima').val(data.tipodeprima);
        app.ui.SetRadioNumericValue('periodicidad', data.periodicidad);
        app.ui.SetNumericValue('#montoValorasegurado', data.montoValorasegurado);
        app.ui.SetRadioNumericValue('formadepagodelapoliza', data.formadepagodelapoliza);
        app.ui.SetRadioNumericValue('favorindicarelmedioporelcualdeseaqueseleenvieinformacion', data.favorindicarelmedioporelcualdeseaqueseleenvieinformacion);
        $('#correspondenciaEspecifique').val(data.correspondenciaEspecifique);

    };
    
    function Controls_setup() {
$('#fechadeconstitucion_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
$('#telefono').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
$('#fax').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
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
$('#datosdelrepresentantelegalFax').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
new AutoNumeric('#porcentajedeparticipacion', {
            decimalCharacter: ',',
			decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
new AutoNumeric('#montoprima', {
            decimalCharacter: ',',
			decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
new AutoNumeric('#montoValorasegurado', {
            decimalCharacter: ',',
			decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
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

                app.core.Post(app.setting.apipath + 'v1/kyc/juridico',
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
datosdelrepresentantelegalCorreoelectronico: { email: true },
},
            messages: {correoelectronico: { email: 'Debe indicar un correo electrónico valido' },
datosdelrepresentantelegalCorreoelectronico: { email: 'Debe indicar un correo electrónico valido' },
}
        });
    };

function participacionaccionaria_table_setup() {

        $('#participacionaccionariaTbl').bootstrapTable({
            uniqueId: 'participacionaccionariaId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
{
	field: 'participacionaccionariaNombreCompleto',
	title: 'Nombre Completo',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
	field: 'porcentajedeparticipacion',
	title: 'Porcentaje de participación',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'right',
    formatter: 'app.ui.IntegerFormatter',
    visible: true
},{
	field: 'participacionaccionariaNumerodeidentificacion',
	title: 'Número de identificación',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
                    field: 'Actions',
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un visualizations',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    visible: true,					
                    events: 'participacionaccionariaTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del visualizations de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del visualizations de la fila"> <i class="fa fa-close"></i> </button>';
                    },
                    cellStyle: function (value, row, index) {
                        return {
                            css: {
                                'white-space': 'nowrap',
                                'vertical-align': 'top'
                            }
                        }
                    }
                }]
        });

$('#participacionaccionariaNew').click(function () {
            participacionaccionaria_table_row_edit();
        });

        $('#participacionaccionariaEdtFormSave').click(function () {
            if (app.ui.IsValid('#participacionaccionariaEdtForm', false)) {
                app.ui.ButtonDoing('#participacionaccionariaEdtFormSave');

                var row = participacionaccionaria_table_row('values');

                if (row.participacionaccionariaId === null)
                    row.participacionaccionariaId = 1;

                if ($('#participacionaccionariaModal').data('id') != null) {
                    $('#participacionaccionariaTbl').bootstrapTable('updateByUniqueId', { id: row.participacionaccionariaId, row: row });
                }
                else {
                    $('#participacionaccionariaTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#participacionaccionariaEdtFormSave')
                $('#participacionaccionariaModal').modal('hide');
            }
        });

    };

function participacionaccionaria_table_row(mode) {
        if (mode == null) {
            return {
                participacionaccionariaId: null,
                participacionaccionariaNombreCompleto: null,
                porcentajedeparticipacion: null,
                participacionaccionariaNumerodeidentificacion: null
            };
        }
        else {
            return {
                participacionaccionariaId: $('#participacionaccionariaModal').data('id'),
                participacionaccionariaNombreCompleto: $('#participacionaccionariaNombreCompleto').val(),
                porcentajedeparticipacion: app.ui.GetNumericValue('#porcentajedeparticipacion'),
                participacionaccionariaNumerodeidentificacion: $('#participacionaccionariaNumerodeidentificacion').val()
            };
        }
    };

    function participacionaccionaria_table_row_edit(row) {
        var md = $('#participacionaccionariaModal').modal({ show: false });
        var formInstance = $("#participacionaccionariaEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || participacionaccionaria_table_row();
        md.data('id', row.participacionaccionariaId);

        $('#participacionaccionariaNombreCompleto').val(row.participacionaccionariaNombreCompleto);
        app.ui.SetNumericValue('#porcentajedeparticipacion', row.porcentajedeparticipacion);
        $('#participacionaccionariaNumerodeidentificacion').val(row.participacionaccionariaNumerodeidentificacion);


        md.modal('show');
    };

    function participacionaccionaria_table_row_delete(row) {
        $('#participacionaccionariaTbl').bootstrapTable('removeByUniqueId', row.participacionaccionariaId);
    };	
	
    function participacionaccionaria_table_Validations() {
        app.ui.DateValidators();
        $("#participacionaccionariaEdtForm").validate({
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
	participacionaccionaria_table_setup();
participacionaccionaria_table_Validations();

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
        },
        participacionaccionariaEditRow: function (row) {
            participacionaccionaria_table_row_edit(row);
        },
        participacionaccionariaDeleteRow: function (row) {
            participacionaccionaria_table_row_delete(row);
        }
    };
})();

window.participacionaccionariaTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.participacionaccionariaId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.juridico.participacionaccionariaDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.juridico.participacionaccionariaEditRow(row);
        e.stopPropagation();
    }
};

