var app = app || {};

app.kycdeclarante = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {
        app.core.Lookups(['Pais.nacionalidadDec', 'Pais.paisdenacimientoDec', 'CivilStatus.estadocivilDec', 'Gender.sexoDec', 'Paises.cod_paisDec', 'Provincias.cod_estadoDec', 'Cantones.cod_provDec', 'Distritos.cod_localidadDec',],
            function () {
            }, ``);
    };

    function ReadOnly() {
        $('#primerapellidoDec').replaceWith('<div>' + $('#primerapellidoDec').val() + '</div>');
        $('#segundoapellidoDec').replaceWith('<div>' + $('#segundoapellidoDec').val() + '</div>');
        $('#nombrecompletoDec').replaceWith('<div>' + $('#nombrecompletoDec').val() + '</div>');
        $('#posiciondentrodelaempresaDec').replaceWith('<div>' + $('#posiciondentrodelaempresaDec').val() + '</div>');
        $('#numerodeidentificacionDec').replaceWith('<div>' + $('#numerodeidentificacionDec').val() + '</div>');
        $('label[for=tipodeidentificacionDec').next().replaceWith('<div>' + $('label[for=tipodeidentificacionDec_' + app.ui.GetRadioNumericValue('tipodeidentificacionDec') + '').html() + '</div>');
        $('#especifiqueDec').replaceWith('<div>' + $('#especifiqueDec').val() + '</div>');
        $('#fechadecaducidadDec_group').replaceWith('<div>' + $('#fechadecaducidadDec').val() + '</div>');
        $('#nacionalidadDec').replaceWith('<div>' + $('#nacionalidadDec option:selected').text() + '</div>');
        $('#fechadenacimientoDec_group').replaceWith('<div>' + $('#fechadenacimientoDec').val() + '</div>');
        $('#paisdenacimientoDec').replaceWith('<div>' + $('#paisdenacimientoDec option:selected').text() + '</div>');
        $('#profesionDec').replaceWith('<div>' + $('#profesionDec').val() + '</div>');
        $('#estadocivilDec').replaceWith('<div>' + $('#estadocivilDec option:selected').text() + '</div>');
        $('#sexoDec').replaceWith('<div>' + $('#sexoDec option:selected').text() + '</div>');
        $('#telefonoresidenciaDec').replaceWith('<div>' + $('#telefonoresidenciaDec').val() + '</div>');
        $('#telefonocelularDec').replaceWith('<div>' + $('#telefonocelularDec').val() + '</div>');
        $('#faxDec').replaceWith('<div>' + $('#faxDec').val() + '</div>');
        $('#apartadopostalDec').replaceWith('<div>' + $('#apartadopostalDec').val() + '</div>');
        $('#correoelectronicoDec').replaceWith('<div>' + $('#correoelectronicoDec').val() + '</div>');
        $('#cod_paisDec').replaceWith('<div>' + $('#cod_paisDec option:selected').text() + '</div>');
        $('#cod_estadoDec').replaceWith('<div>' + $('#cod_estadoDec option:selected').text() + '</div>');
        $('#cod_provDec').replaceWith('<div>' + $('#cod_provDec option:selected').text() + '</div>');
        $('#cod_localidadDec').replaceWith('<div>' + $('#cod_localidadDec option:selected').text() + '</div>');
        $('#direccionexactaDec').replaceWith('<div>' + $('#direccionexactaDec').val() + '</div>');
        $('#correspondenciaOrigendelosfondosDec').replaceWith('<div>' + $('#correspondenciaOrigendelosfondosDec').val() + '</div>');
        $('#paismayoractividadDec').replaceWith('<div>' + $('#paismayoractividadDec').val() + '</div>');
        $('#ingresomensualestimadoDec').replaceWith('<div>' + $('#ingresomensualestimadoDec').val() + '</div>');
        $('label[for=fondospormivilizarDec').next().replaceWith('<div>' + $('label[for=fondospormivilizarDec_' + app.ui.GetRadioNumericValue('fondospormivilizarDec') + '').html() + '</div>');
        $('label[for=actividadesart15Dec').next().replaceWith('<div>' + $('label[for=actividadesart15Dec_' + app.ui.GetRadioNumericValue('actividadesart15Dec') + '').html() + '</div>');
        $('label[for=activoscorrespondenDec').next().replaceWith('<div>' + $('label[for=activoscorrespondenDec_' + app.ui.GetRadioNumericValue('activoscorrespondenDec') + '').html() + '</div>');
        $('label[for=pepcargoDec').next().replaceWith('<div>' + $('label[for=pepcargoDec_' + app.ui.GetRadioNumericValue('pepcargoDec') + '').html() + '</div>');
        $('#pepduracionDec').replaceWith('<div>' + $('#pepduracionDec').val() + '</div>');
        $('#algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEPDec').replaceWith('<div>' + $('#algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEPDec').val() + '</div>');
        $('#peptiporelacionDec').replaceWith('<div>' + $('#peptiporelacionDec').val() + '</div>');
        $('label[for=mediodeenvioDec').next().replaceWith('<div>' + $('label[for=mediodeenvioDec_' + app.ui.GetRadioNumericValue('mediodeenvioDec') + '').html() + '</div>');
        $('#correspondenciaEspecifiqueDec').replaceWith('<div>' + $('#correspondenciaEspecifiqueDec').val() + '</div>');

    };

    function MapInputToObject() {
        var data = {
            primerapellidoDec: $('#primerapellidoDec').val(),
            segundoapellidoDec: $('#segundoapellidoDec').val(),
            nombrecompletoDec: $('#nombrecompletoDec').val(),
            posiciondentrodelaempresaDec: $('#posiciondentrodelaempresaDec').val(),
            numerodeidentificacionDec: $('#numerodeidentificacionDec').val(),
            tipodeidentificacionDec: app.ui.GetRadioNumericValue('tipodeidentificacionDec'),
            especifiqueDec: $('#especifiqueDec').val(),
            fechadecaducidadDec: app.ui.GetDateValue('#fechadecaducidadDec'),
            nacionalidadDec: app.ui.GetDropDownNumericValue('#nacionalidadDec'),
            fechadenacimientoDec: app.ui.GetDateValue('#fechadenacimientoDec'),
            paisdenacimientoDec: app.ui.GetDropDownNumericValue('#paisdenacimientoDec'),
            profesionDec: $('#profesionDec').val(),
            estadocivilDec: app.ui.GetDropDownNumericValue('#estadocivilDec'),
            sexoDec: app.ui.GetDropDownNumericValue('#sexoDec'),
            telefonoresidenciaDec: $('#telefonoresidenciaDec').val(),
            telefonocelularDec: $('#telefonocelularDec').val(),
            faxDec: $('#faxDec').val(),
            apartadopostalDec: $('#apartadopostalDec').val(),
            correoelectronicoDec: $('#correoelectronicoDec').val(),
            cod_paisDec: app.ui.GetDropDownNumericValue('#cod_paisDec'),
            cod_estadoDec: app.ui.GetDropDownNumericValue('#cod_estadoDec'),
            cod_provDec: app.ui.GetDropDownNumericValue('#cod_provDec'),
            cod_localidadDec: app.ui.GetDropDownNumericValue('#cod_localidadDec'),
            direccionexactaDec: $('#direccionexactaDec').val(),
            correspondenciaOrigendelosfondosDec: $('#correspondenciaOrigendelosfondosDec').val(),
            paismayoractividadDec: $('#paismayoractividadDec').val(),
            ingresomensualestimadoDec: app.ui.GetNumericValue('#ingresomensualestimadoDec'),
            fondospormivilizarDec: app.ui.GetRadioNumericValue('fondospormivilizarDec'),
            actividadesart15Dec: app.ui.GetRadioNumericValue('actividadesart15Dec'),
            activoscorrespondenDec: app.ui.GetRadioNumericValue('activoscorrespondenDec'),
            pepcargoDec: app.ui.GetRadioNumericValue('pepcargoDec'),
            pepduracionDec: $('#pepduracionDec').val(),
            algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEPDec: $('#algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEPDec').val(),
            peptiporelacionDec: $('#peptiporelacionDec').val(),
            mediodeenvioDec: app.ui.GetRadioNumericValue('mediodeenvioDec'),
            correspondenciaEspecifiqueDec: $('#correspondenciaEspecifiqueDec').val(),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#primerapellidoDec').val(data.primerapellidoDec);
        $('#segundoapellidoDec').val(data.segundoapellidoDec);
        $('#nombrecompletoDec').val(data.nombrecompletoDec);
        $('#posiciondentrodelaempresaDec').val(data.posiciondentrodelaempresaDec);
        $('#numerodeidentificacionDec').val(data.numerodeidentificacionDec);
        app.ui.SetRadioNumericValue('tipodeidentificacionDec', data.tipodeidentificacionDec);
        $('#especifiqueDec').val(data.especifiqueDec);
        app.ui.SetDateValue('#fechadecaducidadDec', data.fechadecaducidadDec);
        $('#nacionalidadDec').val(data.nacionalidadDec);
        app.ui.SetDropDownNumericValue('#nacionalidadDec', data.nacionalidadDec, true);
        app.ui.SetDateValue('#fechadenacimientoDec', data.fechadenacimientoDec);
        $('#paisdenacimientoDec').val(data.paisdenacimientoDec);
        app.ui.SetDropDownNumericValue('#paisdenacimientoDec', data.paisdenacimientoDec, true);
        $('#profesionDec').val(data.profesionDec);
        $('#estadocivilDec').val(data.estadocivilDec);
        app.ui.SetDropDownNumericValue('#estadocivilDec', data.estadocivilDec, true);
        $('#sexoDec').val(data.sexoDec);
        app.ui.SetDropDownNumericValue('#sexoDec', data.sexoDec, true);
        $('#telefonoresidenciaDec').val(data.telefonoresidenciaDec);
        $('#telefonocelularDec').val(data.telefonocelularDec);
        $('#faxDec').val(data.faxDec);
        $('#apartadopostalDec').val(data.apartadopostalDec);
        $('#correoelectronicoDec').val(data.correoelectronicoDec);
        $('#cod_paisDec').val(data.cod_paisDec);
        app.ui.SetDropDownNumericValue('#cod_paisDec', data.cod_paisDec, true);
        $('#cod_estadoDec').val(data.cod_estadoDec);
        app.ui.SetDropDownNumericValue('#cod_estadoDec', data.cod_estadoDec, true);
        $('#cod_provDec').val(data.cod_provDec);
        app.ui.SetDropDownNumericValue('#cod_provDec', data.cod_provDec, true);
        $('#cod_localidadDec').val(data.cod_localidadDec);
        app.ui.SetDropDownNumericValue('#cod_localidadDec', data.cod_localidadDec, true);
        $('#direccionexactaDec').val(data.direccionexactaDec);
        $('#correspondenciaOrigendelosfondosDec').val(data.correspondenciaOrigendelosfondosDec);
        $('#paismayoractividadDec').val(data.paismayoractividadDec);
        app.ui.SetNumericValue('#ingresomensualestimadoDec', data.ingresomensualestimadoDec);
        app.ui.SetRadioNumericValue('fondospormivilizarDec', data.fondospormivilizarDec);
        app.ui.SetRadioNumericValue('actividadesart15Dec', data.actividadesart15Dec);
        app.ui.SetRadioNumericValue('activoscorrespondenDec', data.activoscorrespondenDec);
        app.ui.SetRadioNumericValue('pepcargoDec', data.pepcargoDec);
        $('#pepduracionDec').val(data.pepduracionDec);
        $('#algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEPDec').val(data.algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEPDec);
        $('#peptiporelacionDec').val(data.peptiporelacionDec);
        app.ui.SetRadioNumericValue('mediodeenvioDec', data.mediodeenvioDec);
        $('#correspondenciaEspecifiqueDec').val(data.correspondenciaEspecifiqueDec);

    };

    function Controls_setup() {
        $('#fechadecaducidadDec_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechadenacimientoDec_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#telefonoresidenciaDec').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#telefonocelularDec').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#faxDec').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        new AutoNumeric('#ingresomensualestimadoDec', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });

    };

    function Controls_Events() {
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#kycdeclaranteDecEdtForm :input").change(function () {
            data_changed();
        });


        $('#kycdeclaranteDecEdtFormSave').click(function () {

            if (app.ui.IsValid('#kycdeclaranteDecEdtForm', false)) {
                app.ui.ButtonDoing('#kycdeclaranteDecEdtFormSave');

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
                        app.ui.ButtonDone('#kycdeclaranteDecEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#kycdeclaranteDecEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#kycdeclaranteDecEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#kycdeclaranteDecEdtFormCancel'); }, 3000);
            event.preventDefault();
        });

    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#kycdeclaranteDecEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                primerapellidoDec: { required: true },
                segundoapellidoDec: { required: true },
                nombrecompletoDec: { required: true },
                posiciondentrodelaempresaDec: { required: true },
                numerodeidentificacionDec: { required: true },
                tipodeidentificacionDec: { required: true },
                especifiqueDec: { required: true },
                fechadecaducidadDec: { required: true },
                nacionalidadDec: { required: true },
                fechadenacimientoDec: { required: true },
                paisdenacimientoDec: { required: true },
                profesionDec: { required: true },
                estadocivilDec: { required: true },
                sexoDec: { required: true },
                telefonoresidenciaDec: { required: true },
                telefonocelularDec: { required: true },
                faxDec: { required: true },
                apartadopostalDec: { required: true },
                correoelectronicoDec: { required: true, email: true },
                cod_paisDec: { required: true },
                cod_estadoDec: { required: true },
                cod_provDec: { required: true },
                cod_localidadDec: { required: true },
                direccionexactaDec: { required: true },
                correspondenciaOrigendelosfondosDec: { required: true },
                paismayoractividadDec: { required: true },
                ingresomensualestimadoDec: { required: true },
                fondospormivilizarDec: { required: true },
                actividadesart15Dec: { required: true },
                tiposdeactivosDec: { required: true },
                activoscorrespondenDec: { required: true },
                personasexpuestaspoliticamentePEPsDec: { required: true },
                pepcargoDec: { required: true },
                pepduracionDec: { required: true },
                algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEPDec: { required: true },
                peptiporelacionDec: { required: true },
                mediodeenvioDec: { required: true },
                correspondenciaEspecifiqueDec: { required: true },
            },
            messages: {
                primerapellidoDec: { required: 'Debe indicar el Primer apellido' },
                segundoapellidoDec: { required: 'Debe indicar el Segundo apellido' },
                nombrecompletoDec: { required: 'Debe indicar el Nombre completo' },
                posiciondentrodelaempresaDec: { required: 'Debe indicar el Posición dentro de la empresa' },
                numerodeidentificacionDec: { required: 'Debe indicar el Número de identificación' },
                tipodeidentificacionDec: { required: 'Debe indicar el Tipo de identificación' },
                especifiqueDec: { required: 'Debe indicar el Especifique' },
                fechadecaducidadDec: { required: 'Debe indicar el Fecha de caducidad' },
                nacionalidadDec: { required: 'Debe indicar el Nacionalidad' },
                fechadenacimientoDec: { required: 'Debe indicar el Fecha de nacimiento' },
                paisdenacimientoDec: { required: 'Debe indicar el País de nacimiento' },
                profesionDec: { required: 'Debe indicar el Profesión' },
                estadocivilDec: { required: 'Debe indicar el Estado civil' },
                sexoDec: { required: 'Debe indicar el Sexo' },
                telefonoresidenciaDec: { required: 'Debe indicar el Teléfono residencia' },
                telefonocelularDec: { required: 'Debe indicar el Teléfono celular' },
                faxDec: { required: 'Debe indicar el Fax' },
                apartadopostalDec: { required: 'Debe indicar el Apartado postal' },
                correoelectronicoDec: { required: 'Debe indicar el Correo electrónico', email: 'Debe indicar un correo electrónico valido' },
                cod_paisDec: { required: 'Debe indicar el País' },
                cod_estadoDec: { required: 'Debe indicar el Provincia' },
                cod_provDec: { required: 'Debe indicar el Cantón' },
                cod_localidadDec: { required: 'Debe indicar el Distrito' },
                direccionexactaDec: { required: 'Debe indicar el Dirección exacta' },
                correspondenciaOrigendelosfondosDec: { required: 'Debe indicar el Origen de los Fondos (¿De dónde provienen y en qué forma?)' },
                paismayoractividadDec: { required: 'Debe indicar el ¿En qué país desarrolla la mayoría de sus actividades económicas?' },
                ingresomensualestimadoDec: { required: 'Debe indicar el Ingreso mensual estimado' },
                fondospormivilizarDec: { required: 'Debe indicar el Los fondos por movilizar son propios o de terceros?' },
                actividadesart15Dec: { required: 'Debe indicar el ¿Se desempeña entre las actividades citadas en el Artículo 15 de la Ley 8204 (manejo de fondos de terceros físicos o jurídicos)' },
                tiposdeactivosDec: { required: 'Debe indicar el Tipos de activos' },
                activoscorrespondenDec: { required: 'Debe indicar el La mayoría de sus activos corresponden a' },
                personasexpuestaspoliticamentePEPsDec: { required: 'Debe indicar el Personas expuestas políticamente (PEPs)' },
                pepcargoDec: { required: 'Debe indicar el ¿Algún Socio, Director o Representante de la empresa desempeña o ha desempeñado algún cargo político?' },
                pepduracionDec: { required: 'Debe indicar el En caso afirmativo, indique el período durante el cual desempeñó dichas funciones' },
                algunSocioDirectoroRepresentantedelaempresatienerelaciondirectaconsanguinidadoindirectaafinidadconalgunapersonaexpuestapoliticamentePEPDec: { required: 'Debe indicar el ¿Algún Socio, Director o Representante de la empresa tiene relación directa (consanguinidad) o indirecta (afinidad) con alguna persona expuesta políticamente (PEP)?' },
                peptiporelacionDec: { required: 'Debe indicar el Detalle el tipo de relación' },
                mediodeenvioDec: { required: 'Debe indicar el Favor indicar el medio por el cual desea que se le envíe información' },
                correspondenciaEspecifiqueDec: { required: 'Debe indicar el Especifique' },
            }
        });
    };



    return {
        Init: function () {
            try {
                app.language.translate('#kycdeclaranteDecEdt', '_kyc_declarante')();
                Controls_setup();
                Setup_Validations();

                Controls_Events();
                Setup();
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
        Changed: function (callback) {
            changedCallback = callback;
        },
        IsValid: function (showResume) {
            return app.ui.IsValid('#kycdeclaranteDecEdtForm', false, showResume);
        }
    };
})();
