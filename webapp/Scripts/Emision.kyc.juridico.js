var app = app || {};

app.kycjuridico = (function () {

    let setupData = null;
    let changedCallback = null;
    let acceptCallback = null;

    function Setup() {

        app.core.Lookups(['Pais.paisdeconstitucionJur', 'Paises.cod_paisJur', 'Provincias.cod_estadoJur', 'Cantones.cod_provJur', 'Distritos.cod_localidadJur', 'Pais.paisdenacimientoJur', 'CivilStatus.estadocivilJur', 'Gender.sexoJur', 'Paises.domiciliopermanenteCod_paisJur', 'Provincias.domiciliopermanenteCod_estadoJur', 'Cantones.domiciliopermanenteCod_provJur', 'Distritos.domiciliopermanenteCod_localidadJur',],
            function () {
            }, `cod_pais=CRI`);
    };

    function MapInputToObject() {
        var data = {
            nombrecomercialJur: $('#nombrecomercialJur').val(),
            razonsocialJur: $('#razonsocialJur').val(),
            codigodeclienteJur: $('#codigodeclienteJur').val(),
            tipodesociedadJur: $('#tipodesociedadJur').val(),
            numerocedulajuridicaJur: $('#numerocedulajuridicaJur').val(),
            tipodecedulajuridicaJur: app.ui.GetRadioNumericValue('tipodecedulajuridicaJur'),
            paisdeconstitucionJur: app.ui.GetDropDownNumericValue('#paisdeconstitucionJur'),
            fechadeconstitucionJur: app.ui.GetDateValue('#fechadeconstitucionJur'),
            actividaddelclientenaturalezadelnegocioJur: $('#actividaddelclientenaturalezadelnegocioJur').val(),
            telefonoJur: $('#telefonoJur').val(),
            faxJur: $('#faxJur').val(),
            apartadopostalJur: $('#apartadopostalJur').val(),
            correoelectronicoJur: $('#correoelectronicoJur').val(),
            paginaWebJur: $('#paginaWebJur').val(),
            cod_paisJur: app.ui.GetDropDownNumericValue('#cod_paisJur'),
            cod_estadoJur: app.ui.GetDropDownNumericValue('#cod_estadoJur'),
            cod_provJur: app.ui.GetDropDownNumericValue('#cod_provJur'),
            cod_localidadJur: app.ui.GetDropDownNumericValue('#cod_localidadJur'),
            direccionexactaJur: $('#direccionexactaJur').val(),
            primerapellidoJur: $('#primerapellidoJur').val(),
            segundoapellidoJur: $('#segundoapellidoJur').val(),
            nombrecompletoJur: $('#nombrecompletoJur').val(),
            posiciondentrodelaempresaJur: $('#posiciondentrodelaempresaJur').val(),
            numerodeidentificacionJur: $('#numerodeidentificacionJur').val(),
            tipodeidentificacionJur: app.ui.GetRadioNumericValue('tipodeidentificacionJur'),
            especifiqueJur: $('#especifiqueJur').val(),
            fechadecaducidadJur: app.ui.GetDateValue('#fechadecaducidadJur'),
            nacionalidadJur: app.ui.GetDropDownNumericValue('#nacionalidadJur'),
            fechadenacimientoJur: app.ui.GetDateValue('#fechadenacimientoJur'),
            paisdenacimientoJur: app.ui.GetDropDownNumericValue('#paisdenacimientoJur'),
            profesionJur: $('#profesionJur').val(),
            estadocivilJur: app.ui.GetDropDownNumericValue('#estadocivilJur'),
            sexoJur: app.ui.GetDropDownNumericValue('#sexoJur'),
            telefonoresidenciaJur: $('#telefonoresidenciaJur').val(),
            telefonocelularJur: $('#telefonocelularJur').val(),
            datosdelrepresentantelegalFaxJur: $('#datosdelrepresentantelegalFaxJur').val(),
            datosdelrepresentantelegalApartadopostalJur: $('#datosdelrepresentantelegalApartadopostalJur').val(),
            datosdelrepresentantelegalCorreoelectronicoJur: $('#datosdelrepresentantelegalCorreoelectronicoJur').val(),
            domiciliopermanenteCod_paisJur: app.ui.GetDropDownNumericValue('#domiciliopermanenteCod_paisJur'),
            domiciliopermanenteCod_estadoJur: app.ui.GetDropDownNumericValue('#domiciliopermanenteCod_estadoJur'),
            domiciliopermanenteCod_provJur: app.ui.GetDropDownNumericValue('#domiciliopermanenteCod_provJur'),
            domiciliopermanenteCod_localidadJur: app.ui.GetDropDownNumericValue('#domiciliopermanenteCod_localidadJur'),
            domiciliopermanenteDireccionexactaJur: $('#domiciliopermanenteDireccionexactaJur').val(),
            correspondenciaOrigendelosfondosJur: $('#correspondenciaOrigendelosfondosJur').val(),
            paismayoractividadJur: $('#paismayoractividadJur').val(),
            ingresomensualestimadoJur: app.ui.GetNumericValue('#ingresomensualestimadoJur'),
            fondospormivilizarJur: app.ui.GetRadioNumericValue('fondospormivilizarJur'),
            actividadesart15Jur: app.ui.GetRadioNumericValue('actividadesart15Jur'),
            activoscorrespondenJur: app.ui.GetRadioNumericValue('activoscorrespondenJur'),
            pepcargoJur: app.ui.GetRadioNumericValue('pepcargoJur'),
            pepduracionJur: $('#pepduracionJur').val(),
            peprelacionJur: app.ui.GetRadioNumericValue('peprelacionJur'),
            peptiporelacionJur: $('#peptiporelacionJur').val(),
            participacionaccionariaJur: $('#participacionaccionariaJurTbl').bootstrapTable('getData'),
            propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendoJur: $('#propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendoJur').val(),
            montoprimaJur: app.ui.GetNumericValue('#montoprimaJur'),
            tipodeprimaJur: $('#tipodeprimaJur').val(),
            periodicidadJur: app.ui.GetRadioNumericValue('periodicidadJur'),
            montovaloraseguradoJur: app.ui.GetNumericValue('#montovaloraseguradoJur'),
            formadepagodelapolizaJur: app.ui.GetRadioNumericValue('formadepagodelapolizaJur'),
            mediodeenvioJur: app.ui.GetRadioNumericValue('mediodeenvioJur'),
            correspondenciaEspecifiqueJur: $('#correspondenciaEspecifiqueJur').val(),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#nombrecomercialJur').val(data.nombrecomercialJur);
        $('#razonsocialJur').val(data.razonsocialJur);
        $('#codigodeclienteJur').val(data.codigodeclienteJur);
        $('#tipodesociedadJur').val(data.tipodesociedadJur);
        $('#numerocedulajuridicaJur').val(data.numerocedulajuridicaJur);
        app.ui.SetRadioNumericValue('tipodecedulajuridicaJur', data.tipodecedulajuridicaJur);
        $('#paisdeconstitucionJur').val(data.paisdeconstitucionJur);
        app.ui.SetDropDownNumericValue('#paisdeconstitucionJur', data.paisdeconstitucionJur, true);
        app.ui.SetDateValue('#fechadeconstitucionJur', data.fechadeconstitucionJur);
        $('#actividaddelclientenaturalezadelnegocioJur').val(data.actividaddelclientenaturalezadelnegocioJur);
        $('#telefonoJur').val(data.telefonoJur);
        $('#faxJur').val(data.faxJur);
        $('#apartadopostalJur').val(data.apartadopostalJur);
        $('#correoelectronicoJur').val(data.correoelectronicoJur);
        $('#paginaWebJur').val(data.paginaWebJur);
        $('#cod_paisJur').val(data.cod_paisJur);
        app.ui.SetDropDownNumericValue('#cod_paisJur', data.cod_paisJur, true);
        $('#cod_estadoJur').val(data.cod_estadoJur);
        app.ui.SetDropDownNumericValue('#cod_estadoJur', data.cod_estadoJur, true);
        $('#cod_provJur').val(data.cod_provJur);
        app.ui.SetDropDownNumericValue('#cod_provJur', data.cod_provJur, true);
        $('#cod_localidadJur').val(data.cod_localidadJur);
        app.ui.SetDropDownNumericValue('#cod_localidadJur', data.cod_localidadJur, true);
        $('#direccionexactaJur').val(data.direccionexactaJur);
        $('#primerapellidoJur').val(data.primerapellidoJur);
        $('#segundoapellidoJur').val(data.segundoapellidoJur);
        $('#nombrecompletoJur').val(data.nombrecompletoJur);
        $('#posiciondentrodelaempresaJur').val(data.posiciondentrodelaempresaJur);
        $('#numerodeidentificacionJur').val(data.numerodeidentificacionJur);
        app.ui.SetRadioNumericValue('tipodeidentificacionJur', data.tipodeidentificacionJur);
        $('#especifiqueJur').val(data.especifiqueJur);
        app.ui.SetDateValue('#fechadecaducidadJur', data.fechadecaducidadJur);
        $('#nacionalidadJur').val(data.nacionalidadJur);
        app.ui.SetDropDownNumericValue('#nacionalidadJur', data.nacionalidadJur, true);
        app.ui.SetDateValue('#fechadenacimientoJur', data.fechadenacimientoJur);
        $('#paisdenacimientoJur').val(data.paisdenacimientoJur);
        app.ui.SetDropDownNumericValue('#paisdenacimientoJur', data.paisdenacimientoJur, true);
        $('#profesionJur').val(data.profesionJur);
        $('#estadocivilJur').val(data.estadocivilJur);
        app.ui.SetDropDownNumericValue('#estadocivilJur', data.estadocivilJur, true);
        $('#sexoJur').val(data.sexoJur);
        app.ui.SetDropDownNumericValue('#sexoJur', data.sexoJur, true);
        $('#telefonoresidenciaJur').val(data.telefonoresidenciaJur);
        $('#telefonocelularJur').val(data.telefonocelularJur);
        $('#datosdelrepresentantelegalFaxJur').val(data.datosdelrepresentantelegalFaxJur);
        $('#datosdelrepresentantelegalApartadopostalJur').val(data.datosdelrepresentantelegalApartadopostalJur);
        $('#datosdelrepresentantelegalCorreoelectronicoJur').val(data.datosdelrepresentantelegalCorreoelectronicoJur);
        $('#domiciliopermanenteCod_paisJur').val(data.domiciliopermanenteCod_paisJur);
        app.ui.SetDropDownNumericValue('#domiciliopermanenteCod_paisJur', data.domiciliopermanenteCod_paisJur, true);
        $('#domiciliopermanenteCod_estadoJur').val(data.domiciliopermanenteCod_estadoJur);
        app.ui.SetDropDownNumericValue('#domiciliopermanenteCod_estadoJur', data.domiciliopermanenteCod_estadoJur, true);
        $('#domiciliopermanenteCod_provJur').val(data.domiciliopermanenteCod_provJur);
        app.ui.SetDropDownNumericValue('#domiciliopermanenteCod_provJur', data.domiciliopermanenteCod_provJur, true);
        $('#domiciliopermanenteCod_localidadJur').val(data.domiciliopermanenteCod_localidadJur);
        app.ui.SetDropDownNumericValue('#domiciliopermanenteCod_localidadJur', data.domiciliopermanenteCod_localidadJur, true);
        $('#domiciliopermanenteDireccionexactaJur').val(data.domiciliopermanenteDireccionexactaJur);
        $('#correspondenciaOrigendelosfondosJur').val(data.correspondenciaOrigendelosfondosJur);
        $('#paismayoractividadJur').val(data.paismayoractividadJur);
        app.ui.SetNumericValue('#ingresomensualestimadoJur', data.ingresomensualestimadoJur);
        app.ui.SetRadioNumericValue('fondospormivilizarJur', data.fondospormivilizarJur);
        app.ui.SetRadioNumericValue('actividadesart15Jur', data.actividadesart15Jur);
        app.ui.SetRadioNumericValue('activoscorrespondenJur', data.activoscorrespondenJur);
        app.ui.SetRadioNumericValue('pepcargoJur', data.pepcargoJur);
        $('#pepduracionJur').val(data.pepduracionJur);
        app.ui.SetRadioNumericValue('peprelacionJur', data.peprelacionJur);
        $('#peptiporelacionJur').val(data.peptiporelacionJur);
        if (data.participacionaccionariaJur != null)
            $('#participacionaccionariaJurTbl').bootstrapTable('load', data.participacionaccionariaJur);
        else
            $('#participacionaccionariaJurTbl').bootstrapTable('load', {});
        $('#propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendoJur').val(data.propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendoJur);
        app.ui.SetNumericValue('#montoprimaJur', data.montoprimaJur);
        $('#tipodeprimaJur').val(data.tipodeprimaJur);
        app.ui.SetRadioNumericValue('periodicidadJur', data.periodicidadJur);
        app.ui.SetNumericValue('#montovaloraseguradoJur', data.montovaloraseguradoJur);
        app.ui.SetRadioNumericValue('formadepagodelapolizaJur', data.formadepagodelapolizaJur);
        app.ui.SetRadioNumericValue('mediodeenvioJur', data.mediodeenvioJur);
        $('#correspondenciaEspecifiqueJur').val(data.correspondenciaEspecifiqueJur);

    };

    function Controls_setup() {
        $('#fechadeconstitucionJur_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#telefonoJur').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#faxJur').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#fechadecaducidadJur_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechadenacimientoJur_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#telefonoresidenciaJur').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#telefonocelularJur').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#datosdelrepresentantelegalFaxJur').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        new AutoNumeric('#ingresomensualestimadoJur', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#porcentajedeparticipacionJur', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoprimaJur', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montovaloraseguradoJur', {
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
        $("#kycjuridicoJurEdtForm :input").change(function () {
            data_changed();
        });

        $('#kycjuridicoJurEdtFormSave').click(function () {
            if (app.ui.IsValid('#kycjuridicoJurEdtForm', false)) {
                app.ui.ButtonDoing('#kycjuridicoJurEdtFormSave');
                acceptCallback(MapInputToObject());
                app.ui.ButtonDone('#kycjuridicoJurEdtFormSave');
            }
            event.preventDefault();
        });


        //$('#kycjuridicoJurEdtFormCancel').click(function () {
        //    app.ui.ButtonDoing('#kycjuridicoJurEdtFormCancel');
        //    setTimeout(() => { app.ui.ButtonDone('#kycjuridicoJurEdtFormCancel'); }, 3000);
        //    event.preventDefault();
        //});

    };

    function data_changed() {
        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#kycjuridicoJurEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                nombrecomercialJur: { required: true },
                razonsocialJur: { required: true },
                codigodeclienteJur: { required: true },
                tipodesociedadJur: { required: true },
                numerocedulajuridicaJur: { required: true },
                tipodecedulajuridicaJur: { required: true },
                paisdeconstitucionJur: { required: true },
                fechadeconstitucionJur: { required: true },
                actividaddelclientenaturalezadelnegocioJur: { required: true },
                telefonoJur: { required: true },
                faxJur: { required: true },
                apartadopostalJur: { required: true },
                correoelectronicoJur: { required: true, email: true },
                paginaWebJur: { required: true },
                cod_paisJur: { required: true },
                cod_estadoJur: { required: true },
                cod_provJur: { required: true },
                cod_localidadJur: { required: true },
                direccionexactaJur: { required: true },
                primerapellidoJur: { required: true },
                segundoapellidoJur: { required: true },
                nombrecompletoJur: { required: true },
                posiciondentrodelaempresaJur: { required: true },
                numerodeidentificacionJur: { required: true },
                tipodeidentificacionJur: { required: true },
                especifiqueJur: { required: true },
                fechadecaducidadJur: { required: true },
                nacionalidadJur: { required: true },
                fechadenacimientoJur: { required: true },
                paisdenacimientoJur: { required: true },
                profesionJur: { required: true },
                estadocivilJur: { required: true },
                sexoJur: { required: true },
                telefonoresidenciaJur: { required: true },
                telefonocelularJur: { required: true },
                datosdelrepresentantelegalFaxJur: { required: true },
                datosdelrepresentantelegalApartadopostalJur: { required: true },
                datosdelrepresentantelegalCorreoelectronicoJur: { required: true, email: true },
                domiciliopermanenteCod_paisJur: { required: true },
                domiciliopermanenteCod_estadoJur: { required: true },
                domiciliopermanenteCod_provJur: { required: true },
                domiciliopermanenteCod_localidadJur: { required: true },
                domiciliopermanenteDireccionexactaJur: { required: true },
                correspondenciaOrigendelosfondosJur: { required: true },
                paismayoractividadJur: { required: true },
                ingresomensualestimadoJur: { required: true },
                fondospormivilizarJur: { required: true },
                actividadesart15Jur: { required: true },
                activoscorrespondenJur: { required: true },
                pepcargoJur: { required: true },
                pepduracionJur: { required: true },
                peprelacionJur: { required: true },
                peptiporelacionJur: { required: true },
                propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendoJur: { required: true },
                montoprimaJur: { required: true },
                tipodeprimaJur: { required: true },
                periodicidadJur: { required: true },
                montovaloraseguradoJur: { required: true },
                formadepagodelapolizaJur: { required: true },
                mediodeenvioJur: { required: true },
                correspondenciaEspecifiqueJur: { required: true },
            },
            messages: {
                nombrecomercialJur: { required: 'Debe indicar el Nombre comercial' },
                razonsocialJur: { required: 'Debe indicar el Razón social' },
                codigodeclienteJur: { required: 'Debe indicar el Código de cliente' },
                tipodesociedadJur: { required: 'Debe indicar el Tipo de sociedad' },
                numerocedulajuridicaJur: { required: 'Debe indicar el Número cédula jurídica' },
                tipodecedulajuridicaJur: { required: 'Debe indicar el Tipo de cédula jurídica' },
                paisdeconstitucionJur: { required: 'Debe indicar el País de constitución' },
                fechadeconstitucionJur: { required: 'Debe indicar el Fecha de constitución' },
                actividaddelclientenaturalezadelnegocioJur: { required: 'Debe indicar el Actividad del cliente (naturaleza del negocio)' },
                telefonoJur: { required: 'Debe indicar el Teléfono' },
                faxJur: { required: 'Debe indicar el Fax' },
                apartadopostalJur: { required: 'Debe indicar el Apartado postal' },
                correoelectronicoJur: { required: 'Debe indicar el Correo electrónico', email: 'Debe indicar un correo electrónico valido' },
                paginaWebJur: { required: 'Debe indicar el Página Web' },
                cod_paisJur: { required: 'Debe indicar el País' },
                cod_estadoJur: { required: 'Debe indicar el Provincia' },
                cod_provJur: { required: 'Debe indicar el Cantón' },
                cod_localidadJur: { required: 'Debe indicar el Distrito' },
                direccionexactaJur: { required: 'Debe indicar el Dirección exacta' },
                primerapellidoJur: { required: 'Debe indicar el Primer apellido' },
                segundoapellidoJur: { required: 'Debe indicar el Segundo apellido' },
                nombrecompletoJur: { required: 'Debe indicar el Nombre completo' },
                posiciondentrodelaempresaJur: { required: 'Debe indicar el Posición dentro de la empresa' },
                numerodeidentificacionJur: { required: 'Debe indicar el Número de identificación' },
                tipodeidentificacionJur: { required: 'Debe indicar el Tipo de identificación' },
                especifiqueJur: { required: 'Debe indicar el Especifique' },
                fechadecaducidadJur: { required: 'Debe indicar el Fecha de caducidad' },
                nacionalidadJur: { required: 'Debe indicar el Nacionalidad' },
                fechadenacimientoJur: { required: 'Debe indicar el Fecha de nacimiento' },
                paisdenacimientoJur: { required: 'Debe indicar el País de nacimiento' },
                profesionJur: { required: 'Debe indicar el Profesión' },
                estadocivilJur: { required: 'Debe indicar el Estado civil' },
                sexoJur: { required: 'Debe indicar el Sexo' },
                telefonoresidenciaJur: { required: 'Debe indicar el Teléfono residencia' },
                telefonocelularJur: { required: 'Debe indicar el Teléfono celular' },
                datosdelrepresentantelegalFaxJur: { required: 'Debe indicar el Fax' },
                datosdelrepresentantelegalApartadopostalJur: { required: 'Debe indicar el Apartado postal' },
                datosdelrepresentantelegalCorreoelectronicoJur: { required: 'Debe indicar el Correo electrónico', email: 'Debe indicar un correo electrónico valido' },
                domiciliopermanenteCod_paisJur: { required: 'Debe indicar el País' },
                domiciliopermanenteCod_estadoJur: { required: 'Debe indicar el Provincia' },
                domiciliopermanenteCod_provJur: { required: 'Debe indicar el Cantón' },
                domiciliopermanenteCod_localidadJur: { required: 'Debe indicar el Distrito' },
                domiciliopermanenteDireccionexactaJur: { required: 'Debe indicar el Dirección exacta' },
                correspondenciaOrigendelosfondosJur: { required: 'Debe indicar el Origen de los fondos (¿De dónde provienen y en qué forma?)' },
                paismayoractividadJur: { required: 'Debe indicar el ¿En qué país desarrolla la mayoría de sus actividades económicas?' },
                ingresomensualestimadoJur: { required: 'Debe indicar el Ingreso mensual estimado' },
                fondospormivilizarJur: { required: 'Debe indicar el Los fondos por movilizar son propios o de terceros?' },
                actividadesart15Jur: { required: 'Debe indicar el ¿Se desempeña entre las actividades citadas en el artículo 15 de la Ley 8204 (manejo de fondos de terceros físicos o jurídicos)' },
                activoscorrespondenJur: { required: 'Debe indicar el La mayoría de sus activos corresponden a' },
                pepcargoJur: { required: 'Debe indicar el Manifiesta desempeñar o haber desempeñado algún cargo que implique funciones públicas destacadas en el país o en el extranjero' },
                pepduracionJur: { required: 'Debe indicar el En caso afirmativo, indique el período durante el cual desempeñó dichas funciones' },
                peprelacionJur: { required: 'Debe indicar el Manifiesta tener relación directa (consanguinidad) o indirecta (afinidad) con una persona expuesta políticamente (PEP)' },
                peptiporelacionJur: { required: 'Debe indicar el Detalle el tipo de relación' },
                propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendoJur: { required: 'Debe indicar el Propósito de relación comercial (Indicar el tipo de Seguro que está adquiriendo)' },
                montoprimaJur: { required: 'Debe indicar el Monto prima' },
                tipodeprimaJur: { required: 'Debe indicar el Tipo de prima' },
                periodicidadJur: { required: 'Debe indicar el Periodicidad' },
                montovaloraseguradoJur: { required: 'Debe indicar el Monto valor asegurado' },
                formadepagodelapolizaJur: { required: 'Debe indicar el Forma de pago de la póliza' },
                mediodeenvioJur: { required: 'Debe indicar el Favor indicar el medio por el cual desea que se le envíe información' },
                correspondenciaEspecifiqueJur: { required: 'Debe indicar el Especifique' },
            }
        });
    };

    function participacionaccionariaJur_table_setup() {

        $('#participacionaccionariaJurTbl').bootstrapTable({
            uniqueId: 'participacionaccionariaJurId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'participacionaccionariaNombrecompletoJur',
                    title: 'Nombre completo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'porcentajedeparticipacionJur',
                    title: 'Porcentaje de participación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: true
                }, {
                    field: 'participacionaccionariaNumerodeidentificacionJur',
                    title: 'Número de identificación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
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
                    events: 'participacionaccionariaJurTbl_Events',
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

        $('#participacionaccionariaJurNew').click(function () {
            participacionaccionariaJur_table_row_edit();
        });

        $('#participacionaccionariaJurEdtFormSave').click(function () {
            if (app.ui.IsValid('#participacionaccionariaJurEdtForm', false)) {
                app.ui.ButtonDoing('#participacionaccionariaJurEdtFormSave');

                var row = participacionaccionariaJur_table_row('values');

                if (row.participacionaccionariaJurId === null)
                    row.participacionaccionariaJurId = 1;

                if ($('#participacionaccionariaJurModal').data('id') != null) {
                    $('#participacionaccionariaJurTbl').bootstrapTable('updateByUniqueId', { id: row.participacionaccionariaJurId, row: row });
                }
                else {
                    $('#participacionaccionariaJurTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#participacionaccionariaJurEdtFormSave')
                $('#participacionaccionariaJurModal').modal('hide');
            }
        });

    };

    function participacionaccionariaJur_table_row(mode) {
        if (mode == null) {
            return {
                participacionaccionariaJurId: null,
                participacionaccionariaNombrecompletoJur: null,
                porcentajedeparticipacionJur: null,
                participacionaccionariaNumerodeidentificacionJur: null
            };
        }
        else {
            return {
                participacionaccionariaJurId: $('#participacionaccionariaJurModal').data('id'),
                participacionaccionariaNombrecompletoJur: $('#participacionaccionariaNombrecompletoJur').val(),
                porcentajedeparticipacionJur: app.ui.GetNumericValue('#porcentajedeparticipacionJur'),
                participacionaccionariaNumerodeidentificacionJur: $('#participacionaccionariaNumerodeidentificacionJur').val()
            };
        }
    };

    function participacionaccionariaJur_table_row_edit(row) {
        var md = $('#participacionaccionariaJurModal').modal({ show: false });
        var formInstance = $("#participacionaccionariaJurEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || participacionaccionariaJur_table_row();
        md.data('id', row.participacionaccionariaJurId);

        $('#participacionaccionariaNombrecompletoJur').val(row.participacionaccionariaNombrecompletoJur);
        app.ui.SetNumericValue('#porcentajedeparticipacionJur', row.porcentajedeparticipacionJur);
        $('#participacionaccionariaNumerodeidentificacionJur').val(row.participacionaccionariaNumerodeidentificacionJur);


        md.modal('show');
    };

    function participacionaccionariaJur_table_row_delete(row) {
        $('#participacionaccionariaJurTbl').bootstrapTable('removeByUniqueId', row.participacionaccionariaJurId);
    };

    function participacionaccionariaJur_table_Validations() {
        app.ui.DateValidators();
        $("#participacionaccionariaJurEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                participacionaccionariaNombrecompletoJur: { required: true },
                porcentajedeparticipacionJur: { required: true },
                participacionaccionariaNumerodeidentificacionJur: { required: true },
            },
            messages: {
                participacionaccionariaNombrecompletoJur: { required: 'Debe indicar el Nombre completo' },
                porcentajedeparticipacionJur: { required: 'Debe indicar el Porcentaje de participación' },
                participacionaccionariaNumerodeidentificacionJur: { required: 'Debe indicar el Número de identificación' },
            }
        });
    };



    return {
        Init: function () {
            try {
                Controls_setup();
                Setup_Validations();
                participacionaccionariaJur_table_setup();
                participacionaccionariaJur_table_Validations();

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
            return app.ui.IsValid('#kycjuridicoJurEdtForm', false, showResume);
        },
        participacionaccionariaJurEditRow: function (row) {
            participacionaccionariaJur_table_row_edit(row);
        },
        participacionaccionariaJurDeleteRow: function (row) {
            participacionaccionariaJur_table_row_delete(row);
        },
        AcceptCallBack: function (callback) {
            acceptCallback = callback;
        },
        SetData: function (data) {
            if (data == null) {
                data = app.kycjuridico.InitData();
            }
            if (data != null) {
                setupData = data;
                MapObjectToInput(data);
            }
        },
        InitData: function () {
            return {
                "nombrecomercialJur": "",
                "razonsocialJur": "",
                "codigodeclienteJur": "",
                "tipodesociedadJur": "",
                "numerocedulajuridicaJur": "",
                "tipodecedulajuridicaJur": null,
                "paisdeconstitucionJur": 0,
                "fechadeconstitucionJur": "0001-01-01T00:00:00",
                "actividaddelclientenaturalezadelnegocioJur": "",
                "telefonoJur": "",
                "faxJur": "",
                "apartadopostalJur": "",
                "correoelectronicoJur": "",
                "paginaWebJur": "",
                "cod_paisJur": 0,
                "cod_estadoJur": 0,
                "cod_provJur": 0,
                "cod_localidadJur": 0,
                "direccionexactaJur": "",
                "primerapellidoJur": "",
                "segundoapellidoJur": "",
                "nombrecompletoJur": "",
                "posiciondentrodelaempresaJur": "",
                "numerodeidentificacionJur": "",
                "tipodeidentificacionJur": null,
                "especifiqueJur": "",
                "fechadecaducidadJur": "0001-01-01T00:00:00",
                "nacionalidadJur": 0,
                "fechadenacimientoJur": "0001-01-01T00:00:00",
                "paisdenacimientoJur": 0,
                "profesionJur": "",
                "estadocivilJur": 0,
                "sexoJur": 0,
                "telefonoresidenciaJur": "",
                "telefonocelularJur": "",
                "datosdelrepresentantelegalFaxJur": "",
                "datosdelrepresentantelegalApartadopostalJur": "",
                "datosdelrepresentantelegalCorreoelectronicoJur": "",
                "domiciliopermanenteCod_paisJur": 0,
                "domiciliopermanenteCod_estadoJur": 0,
                "domiciliopermanenteCod_provJur": 0,
                "domiciliopermanenteCod_localidadJur": 0,
                "domiciliopermanenteDireccionexactaJur": "",
                "correspondenciaOrigendelosfondosJur": "",
                "paismayoractividadJur": "",
                "ingresomensualestimadoJur": 0,
                "fondospormivilizarJur": null,
                "actividadesart15Jur": null,
                "activoscorrespondenJur": null,
                "pepcargoJur": null,
                "pepduracionJur": "",
                "peprelacionJur": null,
                "peptiporelacionJur": "",
                "participacionaccionariaJur": [],
                "propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendoJur": "",
                "montoprimaJur": 0,
                "tipodeprimaJur": "",
                "periodicidadJur": null,
                "montovaloraseguradoJur": 0,
                "formadepagodelapolizaJur": null,
                "mediodeenvioJur": null,
                "correspondenciaEspecifiqueJur": ""
            };
        }
    };
})();

window.participacionaccionariaJurTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.participacionaccionariaJurId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.juridico.participacionaccionariaJurDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.juridico.participacionaccionariaJurEditRow(row);
        e.stopPropagation();
    }
};

