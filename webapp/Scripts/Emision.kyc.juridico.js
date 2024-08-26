var app = app || {};

app.kycjuridico = (function () {

    let setupData = null;
    let changedCallback = null;
    let acceptCallback = null;

    function Setup(data) {

        app.core.Lookups(['Pais.paisdeconstitucionJur', 'Paises.cod_paisJur', 'Provincias.cod_estadoJur', 'Pais.nacionalidadJur', 'Pais.paisdenacimientoJur', 'TRON_G1000100.profesionJur', 'CivilStatus.estadocivilJur', 'Gender.sexoJur', 'Paises.domiciliopermanenteCod_paisJur', 'Provincias.domiciliopermanenteCod_estadoJur', 'Pais.paisDomicilio', 'Gender.participacionaccionariaSexoJur', 'CivilStatus.participacionaccionariaEstadocivilJur', 'TRON_G1000100.participacionaccionariaProfesionJur', 'Pais.participacionaccionariaPaisdenacimientoJur'],
            function () {
                setupData = data;
                MapObjectToInput(data);
                app.core.Get(app.setting.apipath + 'v1/KYC/ActEco')
                    .done(function (data, textStatus, jqXHR) {
                        for (a in data) {
                            $('select#Act_Economica').append($('<option />').val(data[a].CodigoActividadEconomica).text(data[a].Descripcion));
                            $('select#participacionaccionariaAct_Economica').append($('<option />').val(data[a].CodigoActividadEconomica).text(data[a].Descripcion));
                            $('select#Act_EconomicaRep').append($('<option />').val(data[a].CodigoActividadEconomica).text(data[a].Descripcion));
                        }
                        app.ui.SetDropDownNumericValue('#Act_Economica', setupData.actividadEconomica, true);
                        app.ui.SetDropDownNumericValue('#Act_EconomicaRep', setupData.actividadEconomicaRep, true);

                        $('#Act_Economica').select2({
                            width: '100%', theme: 'bootstrap4', dropdownParent: $("#kycjuridicoModal .modal-content"),
                            language: { noResults: function () { return "No hay resultado"; }, searching: function () { return "Buscando.."; } }
                        });
                        $('#participacionaccionariaAct_Economica').select2({
                            width: '100%', theme: 'bootstrap4', dropdownParent: $("#participacionaccionariaJurModal .modal-content"),
                            language: { noResults: function () { return "No hay resultado"; }, searching: function () { return "Buscando.."; } }
                        });
                        $('#Act_EconomicaRep').select2({
                            width: '100%', theme: 'bootstrap4', dropdownParent: $("#kycjuridicoModal .modal-content"),
                            language: { noResults: function () { return "No hay resultado"; }, searching: function () { return "Buscando.."; } }
                        });
                    });
                $('#profesionJur').select2({
                    width: '100%', theme: 'bootstrap4', dropdownParent: $("#kycjuridicoModal .modal-content"),
                    language: { noResults: function () { return "No hay resultado"; }, searching: function () { return "Buscando.."; } }
                });
                $('#participacionaccionariaProfesionJur').select2({
                    width: '100%', theme: 'bootstrap4', dropdownParent: $("#participacionaccionariaJurModal .modal-content"),
                    language: { noResults: function () { return "No hay resultado"; }, searching: function () { return "Buscando.."; } }
                });


            }, `cod_pais=CRI`);

        // Dependencies events
        $('#cod_estadoJur').on('change', function () {
            var pais = $('select#cod_paisJur').val();
            app.core.LookupDependency($('select#cod_estadoJur').val(), 'cod_provJur', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
        });
        $('#cod_provJur').on('change', function () {
            var pais = $('select#cod_paisJur').val();
            app.core.LookupDependency($('select#cod_provJur').val(), 'cod_localidadJur', 'Distritos', '', null, true, null, `cod_pais=${pais}:cod_prov=`);
        });

        $('#domiciliopermanenteCod_estadoJur').on('change', function () {
            var pais = $('select#domiciliopermanenteCod_paisJur').val();
            app.core.LookupDependency($('select#domiciliopermanenteCod_estadoJur').val(), 'domiciliopermanenteCod_provJur', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
        });
        $('#domiciliopermanenteCod_provJur').on('change', function () {
            var pais = $('select#domiciliopermanenteCod_paisJur').val();
            app.core.LookupDependency($('select#domiciliopermanenteCod_provJur').val(), 'domiciliopermanenteCod_localidadJur', 'Distritos', '', null, false, null, `cod_pais=${pais}:cod_prov=`);
        });


    };

    function MapInputToObject() {
        var data = {
            //Datos de la empresa
            nombrecomercialJur: $('#nombrecomercialJur').val(),
            razonsocialJur: $('#razonsocialJur').val(),
            codigodeclienteJur: $('#codigodeclienteJur').val(),
            tipodesociedadJur: $('#tipodesociedadJur').val(),
            numidentificacion: $('#numidentificacionJur').val(),
            tipodecedulajuridicaJur: app.ui.GetRadioNumericValue('tipodecedulajuridicaJur'),
            tipodecedulajuridicaJurDesc: app.ui.GetRadioSelectedText('tipodecedulajuridicaJur'),
            paisdeconstitucionJur: app.ui.GetDropDownNumericValue('#paisdeconstitucionJur'),
            paisdeconstitucionJurDesc: app.ui.GetDropDownSelectedText('#paisdeconstitucionJur'),
            fechadeconstitucionJur: app.ui.GetDateValue('#fechadeconstitucionJur'),
            actividaddelclientenaturalezadelnegocioJur: $('#actividaddelclientenaturalezadelnegocioJur').val(),
            telefonoJur: $('#telefonoJur').val(),
            faxJur: $('#faxJur').val(),
            apartadopostalJur: $('#apartadopostalJur').val(),
            correoelectronicoJur: $('#correoelectronicoJur').val(),
            paginaWebJur: $('#paginaWebJur').val(),

            //Domicilio Comercial
            domiciliocomercialCod_pais: app.ui.GetDropDownStringValue('#cod_paisJur'),
            domiciliocomercialCod_paisDesc: app.ui.GetDropDownSelectedText('#cod_paisJur'),
            domiciliocomercialCod_estado: app.ui.GetDropDownNumericValue('#cod_estadoJur'),
            domiciliocomercialCod_estadoDesc: app.ui.GetDropDownSelectedText('#cod_estadoJur'),
            domiciliocomercialCod_prov: app.ui.GetDropDownNumericValue('#cod_provJur'),
            domiciliocomercialCod_provDesc: app.ui.GetDropDownSelectedText('#cod_provJur'),
            domiciliocomercialCod_localidad: app.ui.GetDropDownNumericValue('#cod_localidadJur'),
            domiciliocomercialCod_localidadDesc: app.ui.GetDropDownSelectedText('#cod_localidadJur'),
            domiciliocomercialDireccionexacta: $('#direccionexactaJur').val(),

            //Datos del representante
            primerapellidoJur: $('#primerapellidoJur').val(),
            segundoapellidoJur: $('#segundoapellidoJur').val(),
            nombrecompletoJur: $('#nombrecompletoJur').val(),
            posiciondentrodelaempresaJur: $('#posiciondentrodelaempresaJur').val(),
            numerodeidentificacionJur: $('#numerodeidentificacionJur').val(),
            tipodeidentificacionJur: app.ui.GetRadioNumericValue('tipodeidentificacionJur'),
            tipodeidentificacionJurDesc: app.ui.GetRadioSelectedText('tipodeidentificacionJur'),
            especifiqueJur: $('#especifiqueJur').val(),
            fechadecaducidadJur: app.ui.GetDateValue('#fechadecaducidadJur'),
            nacionalidadJur: app.ui.GetDropDownNumericValue('#nacionalidadJur'),
            nacionalidadJurDesc: app.ui.GetDropDownSelectedText('#nacionalidadJur'),
            fechadenacimientoJur: app.ui.GetDateValue('#fechadenacimientoJur'),
            paisdenacimientoJur: app.ui.GetDropDownNumericValue('#paisdenacimientoJur'),
            paisdenacimientoJurDesc: app.ui.GetDropDownSelectedText('#paisdenacimientoJur'),
            profesionJur: app.ui.GetDropDownNumericValue('#profesionJur'),
            profesionJurDesc: app.ui.GetDropDownSelectedText('#profesionJur'),
            actividadEconomicaRep: app.ui.GetDropDownNumericValue('#Act_EconomicaRep'),
            estadocivilJur: app.ui.GetDropDownNumericValue('#estadocivilJur'),
            estadocivilJurDesc: app.ui.GetDropDownSelectedText('#estadocivilJur'),
            sexoJur: app.ui.GetDropDownNumericValue('#sexoJur'),
            sexoJurDesc: app.ui.GetDropDownSelectedText('#sexoJur'),
            telefonoresidenciaJur: $('#telefonoresidenciaJur').val(),
            telefonocelularJur: $('#telefonocelularJur').val(),
            datosdelrepresentantelegalFaxJur: $('#datosdelrepresentantelegalFaxJur').val(),
            datosdelrepresentantelegalApartadopostalJur: $('#datosdelrepresentantelegalApartadopostalJur').val(),
            datosdelrepresentantelegalCorreoelectronicoJur: $('#datosdelrepresentantelegalCorreoelectronicoJur').val(),

            //Domicilio Permantente
            domiciliopermanenteCod_pais: app.ui.GetDropDownStringValue('#domiciliopermanenteCod_paisJur'),
            domiciliopermanenteCod_paisDesc: app.ui.GetDropDownSelectedText('#domiciliopermanenteCod_paisJur'),
            domiciliopermanenteCod_estado: app.ui.GetDropDownNumericValue('#domiciliopermanenteCod_estadoJur'),
            domiciliopermanenteCod_estadoDesc: app.ui.GetDropDownSelectedText('#domiciliopermanenteCod_estadoJur'),
            domiciliopermanenteCod_prov: app.ui.GetDropDownNumericValue('#domiciliopermanenteCod_provJur'),
            domiciliopermanenteCod_provDesc: app.ui.GetDropDownSelectedText('#domiciliopermanenteCod_provJur'),
            domiciliopermanenteCod_localidad: app.ui.GetDropDownNumericValue('#domiciliopermanenteCod_localidadJur'),
            domiciliopermanenteCod_localidadDesc: app.ui.GetDropDownSelectedText('#domiciliopermanenteCod_localidadJur'),
            domiciliopermanenteDireccionexacta: $('#domiciliopermanenteDireccionexactaJur').val(),

            //Origen de los fondos
            actividadEconomica: app.ui.GetDropDownNumericValue('#Act_Economica'),
            correspondenciaOrigendelosfondos: $('#correspondenciaOrigendelosfondosJur').val(),
            paismayoractividad: $('#paismayoractividadJur').val(),
            ingresomensualestimado: app.ui.GetNumericValue('#ingresomensualestimadoJur'),
            fondospormivilizar: app.ui.GetRadioNumericValue('fondospormivilizarJur'),
            fondospormivilizarDesc: app.ui.GetRadioSelectedText('fondospormivilizarJur'),
            actividadesart15: app.ui.GetRadioNumericValue('actividadesart15Jur'),
            actividadesart15Desc: app.ui.GetRadioSelectedText('actividadesart15Jur'),

            //Tipos de activos
            activoscorresponden: app.ui.GetRadioNumericValue('activoscorrespondenJur'),
            activoscorrespondenDesc: app.ui.GetRadioSelectedText('activoscorrespondenJur'),

            //PEPs
            pepcargo: app.ui.GetRadioNumericValue('pepcargoJur'),
            pepcargoDesc: app.ui.GetRadioSelectedText('pepcargoJur'),
            pepduracion: $('#pepduracionJur').val(),

            peprelacion: app.ui.GetRadioNumericValue('peprelacionJur'),
            peprelacionDesc: app.ui.GetRadioSelectedText('pepcargoJur'),
            peptiporelacion: $('#peptiporelacionJur').val(),



            //Participación accionaria
            participacionaccionariaJur: $('#participacionaccionariaJurTbl').bootstrapTable('getData'),

            //Describcion de la poliza
            propositorelacioncomercial: $('#propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendoJur').val(),
            montoprima: app.ui.GetNumericValue('#montoprimaJur'),
            tipodeprima: $('#tipodeprimaJur').val(),
            periodicidad: app.ui.GetRadioNumericValue('periodicidadJur'),
            periodicidadDesc: app.ui.GetRadioSelectedText('periodicidadJur'),
            montoValorasegurado: app.ui.GetNumericValue('#montovaloraseguradoJur'),
            formadepagodelapoliza: app.ui.GetRadioNumericValue('formadepagodelapolizaJur'),
            formadepagodelapolizaDesc: app.ui.GetRadioSelectedText('formadepagodelapolizaJur'),

            //FATCA
            greencard: app.ui.GetRadioNumericValue('greencard') == NaN ? 2 : 1,
            identificacionEIN: app.ui.GetRadioNumericValue('identificacionEIN') == NaN ? 2 : 1,
            numeroTIN: $('#numeroTIN').val(),
            numeroExt: $('#numeroExt').val(),
            otrassenasFATCA: $('#otrassenasFATCA').val(),
            contribuyenteUSA: app.ui.GetRadioNumericValue('contribuyenteUSA') == NaN ? 2 : 1,
            domicilioExtranjero: app.ui.GetRadioNumericValue('domicilioExtranjero') == NaN ? 2 : 1,
            paisDomicilio: app.ui.GetDropDownNumericValue('#paisDomicilio') == NaN ? 0 : app.ui.GetDropDownNumericValue('#paisDomicilio'),

            poseeTelefonoExtranjero: app.ui.GetRadioNumericValue('poseeTelefonoExtranjero') == NaN ? 2 : 1,
            aportaXMLFATCA: app.ui.GetRadioNumericValue('aportaXMLFATCA') == NaN ? 2 : 1,

            //Otros Atributos
            atributocanaldeingreso: app.ui.GetDropDownNumericValue('#atributocanaldeingreso') == NaN ? 1 : 1,
            valorcanalingreso: app.ui.GetDropDownNumericValue('#valorcanalingreso') == 0 ? 1 : app.ui.GetDropDownNumericValue('#valorcanalingreso'),
            valorcanalingresoDesc: app.ui.GetDropDownSelectedText('#valorcanalingreso') == "" ? "No registra" : app.ui.GetDropDownSelectedText('#valorcanalingreso'),


            //Correspondencia
            mediodeenvio: app.ui.GetRadioNumericValue('mediodeenvioJur'),
            mediodeenvioDesc: app.ui.GetRadioSelectedText('mediodeenvioJur'),
            especifique: $('#correspondenciaEspecifiqueJur').val(),

        };
        return data;
    };


    function MapObjectToInput(data) {
        if (data != null) {
            document.querySelectorAll('#dynamic [type="radio"]').forEach((x) => x.checked = false);
            $('#nombrecomercialJur').val(data.nombrecomercialJur);
            $('#razonsocialJur').val(data.razonsocialJur);
            $('#codigodeclienteJur').val(data.codigodeclienteJur);
            $('#tipodesociedadJur').val(data.tipodesociedadJur);
            $('#numidentificacionJur').val(data.numidentificacion);
            app.ui.SetRadioNumericValue('tipodecedulajuridicaJur', data.tipodecedulajuridicaJur);
            app.ui.SetDropDownNumericValue('#paisdeconstitucionJur', data.paisdeconstitucionJur, true);
            app.ui.SetDateValue('#fechadeconstitucionJur', data.fechadeconstitucionJur);
            $('#actividaddelclientenaturalezadelnegocioJur').val(data.actividaddelclientenaturalezadelnegocioJur);
            $('#telefonoJur').val(data.telefonoJur);
            $('#faxJur').val(data.faxJur);
            $('#apartadopostalJur').val(data.apartadopostalJur);
            $('#correoelectronicoJur').val(data.correoelectronicoJur);
            $('#paginaWebJur').val(data.paginaWebJur);
            app.ui.SetDropDownStringValue('#cod_paisJur', data.domiciliocomercialCod_pais, true);
            app.ui.SetDropDownNumericValue('#cod_estadoJur', data.domiciliocomercialCod_estado, true);
            app.core.LookupDependency(data.domiciliocomercialCod_estado, 'cod_provJur', 'Cantones', '', data.domiciliocomercialCod_prov, false, null, `cod_pais=${data.domiciliocomercialCod_pais}:cod_estado=`);
            app.core.LookupDependency(data.domiciliocomercialCod_prov, 'cod_localidadJur', 'Distritos', '', data.domiciliocomercialCod_localidad, false, null, `cod_pais=${data.domiciliocomercialCod_pais}:cod_prov=`);
            $('#direccionexactaJur').val(data.domiciliocomercialDireccionexacta);
            $('#primerapellidoJur').val(data.primerapellidoJur);
            $('#segundoapellidoJur').val(data.segundoapellidoJur);
            $('#nombrecompletoJur').val(data.nombrecompletoJur);
            $('#posiciondentrodelaempresaJur').val(data.posiciondentrodelaempresaJur);
            $('#numerodeidentificacionJur').val(data.numerodeidentificacionJur);
            app.ui.SetRadioNumericValue('tipodeidentificacionJur', data.tipodeidentificacionJur);
            $('#especifiqueJur').val(data.especifiqueJur);
            app.ui.SetDateValue('#fechadecaducidadJur', data.fechadecaducidadJur);
            app.ui.SetDropDownNumericValue('#nacionalidadJur', data.nacionalidadJur, true);
            app.ui.SetDateValue('#fechadenacimientoJur', data.fechadenacimientoJur);
            app.ui.SetDropDownNumericValue('#paisdenacimientoJur', data.paisdenacimientoJur, true);
            app.ui.SetDropDownNumericValue('#profesionJur', data.profesionJur, true);
            app.ui.SetDropDownNumericValue('#estadocivilJur', data.estadocivilJur, true);
            app.ui.SetDropDownNumericValue('#sexoJur', data.sexoJur, true);
            $('#telefonoresidenciaJur').val(data.telefonoresidenciaJur);
            $('#telefonocelularJur').val(data.telefonocelularJur);
            $('#datosdelrepresentantelegalFaxJur').val(data.datosdelrepresentantelegalFaxJur);
            $('#datosdelrepresentantelegalApartadopostalJur').val(data.datosdelrepresentantelegalApartadopostalJur);
            $('#datosdelrepresentantelegalCorreoelectronicoJur').val(data.datosdelrepresentantelegalCorreoelectronicoJur);
            app.ui.SetDropDownStringValue('#domiciliopermanenteCod_paisJur', data.domiciliopermanenteCod_pais, true);
            app.ui.SetDropDownNumericValue('#domiciliopermanenteCod_estadoJur', data.domiciliopermanenteCod_estado, true);
            app.core.LookupDependency(data.domiciliopermanenteCod_estado, 'domiciliopermanenteCod_provJur', 'Cantones', '', data.domiciliopermanenteCod_prov, false, null, `cod_pais=${data.domiciliopermanenteCod_pais}:cod_estado=`);
            app.core.LookupDependency(data.domiciliopermanenteCod_prov, 'domiciliopermanenteCod_localidadJur', 'Distritos', '', data.domiciliopermanenteCod_localidad, false, null, `cod_pais=${data.domiciliopermanenteCod_pais}:cod_prov=`);
            $('#domiciliopermanenteDireccionexactaJur').val(data.domiciliopermanenteDireccionexacta);
            $('#correspondenciaOrigendelosfondosJur').val(data.correspondenciaOrigendelosfondos);
            $('#paismayoractividadJur').val(data.paismayoractividad);
            app.ui.SetNumericValue('#ingresomensualestimadoJur', data.ingresomensualestimado);
            app.ui.SetRadioNumericValue('fondospormivilizarJur', data.fondospormivilizar);
            app.ui.SetRadioNumericValue('actividadesart15Jur', data.actividadesart15);
            app.ui.SetRadioNumericValue('activoscorrespondenJur', data.activoscorresponden);

            app.ui.SetRadioNumericValue('greencard', data.greencard);
            app.ui.SetRadioNumericValue('identificacionEIN', data.identificacionEIN);
            $('#numeroTIN').val(data.numeroTIN);
            $('#numeroExt').val(data.numeroExt);
            $('#otrassenasFATCA').val(data.otrassenasFATCA);
            app.ui.SetRadioNumericValue('contribuyenteUSA', data.contribuyenteUSA);
            app.ui.SetRadioNumericValue('domicilioExtranjero', data.domicilioExtranjero);
            app.ui.SetDropDownNumericValue('#paisDomicilio', data.paisDomicilio);
            app.ui.SetRadioNumericValue('poseeTelefonoExtranjero', data.poseeTelefonoExtranjero);
            app.ui.SetRadioNumericValue('aportaXMLFATCA', data.aportaXMLFATCA);

            app.ui.SetDropDownNumericValue('#atributocanaldeingreso', data.atributocanaldeingreso);
            app.ui.SetDropDownNumericValue('#valorcanalingreso', data.valorcanalingreso);

            app.ui.SetRadioNumericValue('pepcargoJur', data.pepcargo);
            $("[name=pepcargoJur]").change();
            $('#pepduracionJur').val(data.pepduracion);
            app.ui.SetRadioNumericValue('peprelacionJur', data.peprelacion);
            $("[name=peprelacionJur]").change();
            $('#peptiporelacionJur').val(data.peptiporelacion);
            if (data.participacionaccionariaJur != null)
                $('#participacionaccionariaJurTbl').bootstrapTable('load', data.participacionaccionariaJur);
            else
                $('#participacionaccionariaJurTbl').bootstrapTable('load', {});
            $('#propositoderelacioncomercialIndicareltipodeSeguroqueestaadquiriendoJur').val(data.propositorelacioncomercial);
            app.ui.SetNumericValue('#montoprimaJur', data.montoprima);
            $('#tipodeprimaJur').val(data.tipodeprima);
            app.ui.SetRadioNumericValue('periodicidadJur', data.periodicidad);
            app.ui.SetNumericValue('#montovaloraseguradoJur', data.montoValorasegurado);
            app.ui.SetRadioNumericValue('formadepagodelapolizaJur', data.formadepagodelapoliza);
            app.ui.SetRadioNumericValue('mediodeenvioJur', data.mediodeenvio);
            $('#correspondenciaEspecifiqueJur').val(data.especifique);
        }
    };

    function Controls_setup() {
        $('#fechadeconstitucionJur_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#participacionaccionariaFechadenacimientoJur_group').datetimepicker({
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
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#porcentajedeparticipacionJur', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '100',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoprimaJur', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montovaloraseguradoJur', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });

    };

    function Controls_Events() {

        app.ui.DocumentNumberHandlerKYC('#numidentificacionJur', MapObjectToInput, undefined, "juridico");

        var modal_lv = 1;
        $('.modal').on('shown.bs.modal', function (e) {
            $('.modal-backdrop:last').css('zIndex', 1051 + modal_lv);
            $(e.currentTarget).css('zIndex', 1052 + modal_lv);
            modal_lv++
        });

        $('.modal').on('hidden.bs.modal', function (e) {
            modal_lv--
        });

        $('input:radio[name=poseeTelefonoExtranjero]').change(function () {
            $('#numeroExt').prop("disabled", app.ui.GetRadioNumericValue('poseeTelefonoExtranjero') === 2);
            $('#numeroExt').val("");
        });

        $('input:radio[name=domicilioExtranjero]').change(function () {
            $('#paisDomicilio').prop("disabled", app.ui.GetRadioNumericValue('domicilioExtranjero') === 2);
            $('#paisDomicilio').val("");
        });
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#kycjuridicoJurEdtForm :input").change(function () {
            data_changed();
        });
        $("#participacionaccionariaJurEdt :input").change(function () {
            data_changed();
        });


        $('#kycjuridicoJurEdtFormSave').click(function () {
            let other = participacionaccionariaJur_table_OtherValidations();
            let all = app.ui.IsValid('#kycjuridicoJurEdtForm', false);
            if (other && all) {
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
        if (app.ui.GetRadioNumericValue('pepcargoJur') === 1)
            $('.pepduracionJurVisible').removeClass('d-none');
        else
            $('.pepduracionJurVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('peprelacionJur') === 1)
            $('.peptiporelacionJurVisible').removeClass('d-none');
        else
            $('.peptiporelacionJurVisible').addClass('d-none');


        if (changedCallback !== undefined && changedCallback !== null)
            changedCallback(MapInputToObject());
        if (app.ui.GetRadioNumericValue('pepcargoSocioJur') === 1)
            $('.pepduracionSocioJurVisible').removeClass('d-none');
        else
            $('.pepduracionSocioJurVisible').addClass('d-none');
        if (app.ui.GetRadioNumericValue('peprelacionSocioJur') === 1)
            $('.peptiporelacionSocioJurVisible').removeClass('d-none');
        else
            $('.peptiporelacionSocioJurVisible').addClass('d-none');


        if (app.ui.GetRadioNumericValue('participacionaccionariaTipodeidentificacionJur') === 2) {
            $('.pepSocios').addClass('d-none')
            document.querySelectorAll('.pepSocios [type="radio"]').forEach((x) => x.checked = false);
        } else {
            $('.pepSocios').removeClass('d-none')
        }
    };

    function Setup_Validations() {
        app.ui.DateValidators();
        app.ui.NumericValidators();
        $("#kycjuridicoJurEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                nombrecomercialJur: { required: true },
                razonsocialJur: { required: true },
                tipodesociedadJur: { required: true },
                numidentificacionJur: { required: true },
                tipodecedulajuridicaJur: { required: true },
                paisdeconstitucionJur: { required: true },
                fechadeconstitucionJur: { required: true },
                actividaddelclientenaturalezadelnegocioJur: { required: true },
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
                montoprimaJur: { required: true, Numeric: true },
                tipodeprimaJur: { required: true },
                periodicidadJur: { required: true },
                montovaloraseguradoJur: { required: true, Numeric: true },
                formadepagodelapolizaJur: { required: true },
                mediodeenvioJur: { required: true },
                correspondenciaEspecifiqueJur: { required: true },
                Act_Economica: { required: true },
                Act_EconomicaRep: { required: true },
            },
            messages: {
                nombrecomercialJur: { required: 'Debe indicar el Nombre comercial' },
                razonsocialJur: { required: 'Debe indicar el Razón social' },
                tipodesociedadJur: { required: 'Debe indicar el Tipo de sociedad' },
                numidentificacionJur: { required: 'Debe indicar el Número cédula jurídica' },
                tipodecedulajuridicaJur: { required: 'Debe indicar el Tipo de cédula jurídica' },
                paisdeconstitucionJur: { required: 'Debe indicar el País de constitución' },
                fechadeconstitucionJur: { required: 'Debe indicar el Fecha de constitución' },
                actividaddelclientenaturalezadelnegocioJur: { required: 'Debe indicar el Actividad del cliente (naturaleza del negocio)' },
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
                montoprimaJur: { required: 'Debe indicar el Monto prima', Numeric: 'Debe indicar el Monto prima' },
                tipodeprimaJur: { required: 'Debe indicar el Tipo de prima' },
                periodicidadJur: { required: 'Debe indicar el Periodicidad' },
                montovaloraseguradoJur: { required: 'Debe indicar el Monto valor asegurado', Numeric: 'Debe indicar el Monto valor asegurado' },
                formadepagodelapolizaJur: { required: 'Debe indicar el Forma de pago de la póliza' },
                mediodeenvioJur: { required: 'Debe indicar el Favor indicar el medio por el cual desea que se le envíe información' },
                correspondenciaEspecifiqueJur: { required: 'Debe indicar el Especifique' },
                Act_Economica: { required: 'Debe indicar la actividad economica' },
                Act_EconomicaRep: { required: 'Debe indicar la actividad economica del representante' },
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
                    formatter: function (value) {
                        return app.ui.IntegerFormatter(value) + '%';
                    },
                    visible: true
                }, {
                    field: 'participacionaccionariaTipodeidentificacionJurDesc',
                    title: 'Tipo de identificación',
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
                    align: 'right',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'participacionaccionariaSexoJurDesc',
                    title: 'Sexo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'participacionaccionariaFechadenacimientoJur',
                    title: 'Fecha de nacimiento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'participacionaccionariaPaisdenacimientoJurDesc',
                    title: 'Pais de nacimiento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'participacionaccionariaProfesionJurDesc',
                    title: 'Profesion',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'participacionaccionariaEstadocivilJurDesc',
                    title: 'Estado civil',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'participacionaccionariaPepRelacionJurDesc',
                    title: 'PEPs Relaciones',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'participacionaccionariaPepCargoJurDesc',
                    title: 'PEPs Cargos',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'participacionaccionariaArt15JurDesc',
                    title: 'Articulo 15',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'participacionaccionariaAct_EconomicaDesc',
                    title: 'Actividad Economica',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
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
                let AccionariosLista = $('#participacionaccionariaJurTbl').bootstrapTable('getData');
                var row = participacionaccionariaJur_table_row('values');
                var idlist = [];
                for (var id in AccionariosLista) {
                    idlist.push(AccionariosLista[id]["participacionaccionariaJurId"])
                }
                if (row.participacionaccionariaJurId === null) {
                    if (idlist.length > 0) {
                        var lastid = Math.max(...idlist);
                        row.participacionaccionariaJurId = lastid + 1;
                    }
                    else {
                        row.participacionaccionariaJurId = 1;
                    }
                }


                if ($('#participacionaccionariaJurModal').data('id') != null) {
                    $('#participacionaccionariaJurTbl').bootstrapTable('updateByUniqueId', { id: row.participacionaccionariaJurId, row: row });
                }
                else {
                    $('#participacionaccionariaJurTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#participacionaccionariaJurEdtFormSave')
                $('#participacionaccionariaJurModal').modal('hide');
                participacionaccionariaJur_table_OtherValidations();
            }
        });

    };

    function participacionaccionariaJur_table_row(mode) {
        var data;
        if (mode == null) {
            data = {
                participacionaccionariaJurId: null,
                participacionaccionariaNombrecompletoJur: null,
                porcentajedeparticipacionJur: null,
                participacionaccionariaNumerodeidentificacionJur: null,
                participacionaccionariaTipodeidentificacionJur: null,
                participacionaccionariaPaisdenacimientoJur: null,
                participacionaccionariaSexoJur: null,
                participacionaccionariaFechadenacimientoJur: "0001-01-01T00:00:00",
                participacionaccionariaProfesionJur: null,
                participacionaccionariaEstadocivilJur: null,
                participacionaccionariaPepCargoJur: null,
                participacionaccionariaPepRelacionJur: null,
                participacionaccionariaArt15Jur: null,
                participacionaccionariaAct_Economica: null
            };
            return data;
        }
        else {
            data = {
                participacionaccionariaJurId: $('#participacionaccionariaJurModal').data('id'),
                participacionaccionariaNombrecompletoJur: $('#participacionaccionariaNombrecompletoJur').val(),
                porcentajedeparticipacionJur: app.ui.GetNumericValue('#porcentajedeparticipacionJur'),
                participacionaccionariaNumerodeidentificacionJur: $('#participacionaccionariaNumerodeidentificacionJur').val(),
                participacionaccionariaTipodeidentificacionJur: app.ui.GetRadioNumericValue('participacionaccionariaTipodeidentificacionJur'),
                participacionaccionariaTipodeidentificacionJurDesc: app.ui.GetRadioSelectedText('participacionaccionariaTipodeidentificacionJur'),
                participacionaccionariaSexoJur: app.ui.GetDropDownNumericValue("#participacionaccionariaSexoJur"),
                participacionaccionariaSexoJurDesc: app.ui.GetDropDownSelectedText("#participacionaccionariaSexoJur"),
                participacionaccionariaFechadenacimientoJur: app.ui.GetDateValue("#participacionaccionariaFechadenacimientoJur"),
                participacionaccionariaPaisdenacimientoJur: app.ui.GetDropDownNumericValue("#participacionaccionariaPaisdenacimientoJur"),
                participacionaccionariaPaisdenacimientoJurDesc: app.ui.GetDropDownSelectedText("#participacionaccionariaPaisdenacimientoJur"),
                participacionaccionariaProfesionJur: app.ui.GetDropDownNumericValue("#participacionaccionariaProfesionJur"),
                participacionaccionariaProfesionJurDesc: app.ui.GetDropDownSelectedText("#participacionaccionariaProfesionJur"),
                participacionaccionariaEstadocivilJur: app.ui.GetDropDownNumericValue("#participacionaccionariaEstadocivilJur"),
                participacionaccionariaEstadocivilJurDesc: app.ui.GetDropDownSelectedText("#participacionaccionariaEstadocivilJur"),
                participacionaccionariaPepCargoJur: isNaN(app.ui.GetRadioNumericValue("pepcargoSocioJur")) == true ? 2 : app.ui.GetRadioNumericValue("pepcargoSocioJur"),
                participacionaccionariaPepCargoJurDesc: app.ui.GetRadioSelectedText("pepcargoSocioJur"),
                pepduracionsocioJur: $("#pepduracionsocioJur").val(),
                participacionaccionariaPepRelacionJur: isNaN(app.ui.GetRadioNumericValue("peprelacionSocioJur")) == true ? 2 : app.ui.GetRadioNumericValue("peprelacionSocioJur"),
                participacionaccionariaPepRelacionJurDesc: app.ui.GetRadioSelectedText("peprelacionSocioJur"),
                peptiporelacionSocioJur: $("#peptiporelacionSocioJur").val(),
                participacionaccionariaArt15Jur: isNaN(app.ui.GetRadioNumericValue("actividadesart15SocioJur")) == true ? 2 : app.ui.GetRadioNumericValue("actividadesart15SocioJur"),
                participacionaccionariaArt15JurDesc: app.ui.GetRadioSelectedText("actividadesart15SocioJur"),
                participacionaccionariaAct_Economica: app.ui.GetDropDownNumericValue("#participacionaccionariaAct_Economica"),
                participacionaccionariaAct_EconomicaDesc: app.ui.GetDropDownSelectedText("#participacionaccionariaAct_Economica")

            };

            return data;
        }
    };


    function participacionaccionariaJur_table_row_edit(row) {
        var md = $('#participacionaccionariaJurModal').modal({ show: false });
        var formInstance = $("#participacionaccionariaJurEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || participacionaccionariaJur_table_row();
        md.data('id', row.participacionaccionariaJurId);


        document.querySelectorAll('#participacionaccionariaJurModal [type="radio"]').forEach((x) => x.checked = false);
        $('#participacionaccionariaNombrecompletoJur').val(row.participacionaccionariaNombrecompletoJur);
        app.ui.SetNumericValue('#porcentajedeparticipacionJur', row.porcentajedeparticipacionJur);
        $('#participacionaccionariaNumerodeidentificacionJur').val(row.participacionaccionariaNumerodeidentificacionJur);
        app.ui.SetRadioNumericValue('participacionaccionariaTipodeidentificacionJur', row.participacionaccionariaTipodeidentificacionJur);
        app.ui.SetDropDownNumericValue("#participacionaccionariaSexoJur", row.participacionaccionariaSexoJur);
        app.ui.SetDateValue("#participacionaccionariaFechadenacimientoJur", row.participacionaccionariaFechadenacimientoJur);
        app.ui.SetDropDownNumericValue("#participacionaccionariaPaisdenacimientoJur", row.participacionaccionariaPaisdenacimientoJur);
        app.ui.SetDropDownNumericValue("#participacionaccionariaProfesionJur", row.participacionaccionariaProfesionJur);
        app.ui.SetDropDownNumericValue("#participacionaccionariaEstadocivilJur", row.participacionaccionariaEstadocivilJur);
        app.ui.SetRadioNumericValue("pepcargoSocioJur", row.participacionaccionariaPepCargoJur);
        $("#pepduracionsocioJur").val(row.pepduracionsocioJur);
        $("[name=pepcargoSocioJur]").change();
        app.ui.SetRadioNumericValue("peprelacionSocioJur", row.participacionaccionariaPepRelacionJur);
        $("#peptiporelacionSocioJur").val(row.peptiporelacionSocioJur);

        app.ui.SetRadioNumericValue("actividadesart15SocioJur", row.participacionaccionariaArt15Jur);
        app.ui.SetDropDownNumericValue("#participacionaccionariaAct_Economica", row.participacionaccionariaAct_Economica);
        $("[name=peprelacionSocioJur]").change();
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
                participacionaccionariaTipodeidentificacionJur: { required: true },
                participacionaccionariaSexoJur: { required: true },
                participacionaccionariaFechadenacimientoJur: { required: true },
                participacionaccionariaProfesionJur: { required: true },
                participacionaccionariaEstadocivilJur: { required: true },
                pepcargoSocioJur: { required: true },
                pepduracionsocioJur: { required: true },
                peprelacionSocioJur: { required: true },
                peptiporelacionSocioJur: { required: true },
                participacionaccionariaArt15Jur: { required: true },
                participacionaccionariaAct_Economica: { required: true }
            },
            messages: {
                participacionaccionariaNombrecompletoJur: { required: 'Debe indicar el Nombre completo' },
                porcentajedeparticipacionJur: { required: 'Debe indicar el Porcentaje de participación' },
                participacionaccionariaNumerodeidentificacionJur: { required: 'Debe indicar el Número de identificación' },
                participacionaccionariaTipodeidentificacionJur: { required: 'Debe indicar el tipo de identificación' },
                participacionaccionariaSexoJur: { required: 'Debe indicar el sexo' },
                participacionaccionariaFechadenacimientoJur: { required: 'Debe indicar la fecha de nacimiento' },
                participacionaccionariaProfesionJur: { required: 'Debe indicar la profesión' },
                participacionaccionariaEstadocivilJur: { required: "Debe indicar el estado civil" },
                pepcargoSocioJur: { required: "Debe indicar el Manifiesta desempeñar o haber desempeñado algún cargo que implique funciones públicas destacadas en el país o en el extranjero" },
                pepduracionsocioJur: { required: "Debe indicar el En caso afirmativo, indique el período durante el cual desempeñó dichas funciones" },
                peprelacionSocioJur: { required: "Debe indicar el Manifiesta tener relación directa (consanguinidad) o indirecta (afinidad) con una persona expuesta políticamente (PEP)" },
                peptiporelacionSocioJur: { required: "Debe indicar el Detalle el tipo de relación" },
                participacionaccionariaArt15Jur: { required: "Debe indicar el ¿Se desempeña entre las actividades citadas en el artículo 15 de la Ley 8204 (manejo de fondos de terceros físicos o jurídicos)" },
                participacionaccionariaAct_Economica: { required: "Debe indicar la actividad economica" }
            }
        });
    };

    function participacionaccionariaJur_table_OtherValidations() {
        let rows = $('#participacionaccionariaJurTbl').bootstrapTable('getData');
        let result = false;

        if (rows.length === 0) {
            $('#participacionaccionariaJurTbl-error').text('Debe existir al menos un socio');
            $('#participacionaccionariaJurTbl-error').removeClass('d-none');
        }
        else if (rows.reduce((total, item) => total + item.porcentajedeparticipacionJur, 0) != 100) {
            $('#participacionaccionariaJurTbl-error').text('El total del porcentaje de participación debe ser el 100%');
            $('#participacionaccionariaJurTbl-error').removeClass('d-none');
        }
        else {
            $('#participacionaccionariaJurTbl-error').text('');
            $('#participacionaccionariaJurTbl-error').addClass('d-none');
            result = true;
        }

        return result;
    }

    return {
        Init: function (data) {
            try {
                Controls_setup();
                Setup_Validations();
                participacionaccionariaJur_table_setup();
                participacionaccionariaJur_table_Validations();

                Controls_Events();
                Setup(data);
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
                data = app.kycjuridico.InitData(true);
            }
            if (data != null) {
                setupData = data;
                MapObjectToInput(data);
            }
        },
        InitData: function (fill) {
            let InitKycjuridico = {
                "nombrecomercialJur": "",
                "razonsocialJur": "",
                "codigodeclienteJur": "",
                "tipodesociedadJur": "",
                "numidentificacion": "",
                "tipodecedulajuridicaJur": null,
                "paisdeconstitucionJur": 0,
                "fechadeconstitucionJur": "0001-01-01T00:00:00",
                "actividaddelclientenaturalezadelnegocioJur": "",
                "telefonoJur": "",
                "faxJur": "",
                "apartadopostalJur": "",
                "correoelectronicoJur": "",
                "paginaWebJur": "",
                "domiciliocomercialCod_pais": "CRI",
                "domiciliocomercialCod_estado": 0,
                "domiciliocomercialCod_prov": 0,
                "domiciliocomercialCod_localidad": 0,
                "domiciliocomercialDireccionexacta": "",
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
                "domiciliopermanenteCod_pais": "CRI",
                "domiciliopermanenteCod_estado": 0,
                "domiciliopermanenteCod_prov": 0,
                "domiciliopermanenteCod_localidad": 0,
                "domiciliopermanenteDireccionexacta": "",
                "correspondenciaOrigendelosfondos": "",
                "paismayoractividad": "",
                "ingresomensualestimado": 0,
                "fondospormivilizar": null,
                "actividadesart15": null,
                "activoscorresponden": null,
                "numeroTIN": "",
                "numeroExt": "",
                "otrassenasFATCA": "",
                "greencard": 0,
                "identificacionEIN": 0,
                "contribuyenteUSA": 0,
                "domicilioExtranjero": 0,
                "paisDomicilio": 0,
                "poseeTelefonoExtranjero": 0,
                "aportaXMLFATCA": 0,
                "valorcanalingreso": 1,
                "atributocanaldeingreso": 1,
                "pepcargo": null,
                "pepduracion": "",
                "peprelacion": null,
                "actividadEconomica": 0,
                "actividadEconomicaRep": 0,
                "peptiporelacion": "",
                "participacionaccionariaJur": [],
                "propositorelacioncomercial": "",
                "montoprima": 0,
                "tipodeprima": "",
                "periodicidad": null,
                "montoValorasegurado": 0,
                "formadepagodelapoliza": null,
                "mediodeenvio": null,
                "especifique": ""
            };

            if (fill) {
                let mainHolder = $('#tercerosTbl').bootstrapTable('getData').filter(i => i.tipodetercero === "0");

                if (app.ui.IsDocumentNumberValid(mainHolder[0].DocumentNumberType, mainHolder[0].DocumentNumber)) {
                    var value = mainHolder[0].DocumentNumber.replace(/-/g, '');
                    app.core.Get(app.setting.apipath + 'v1/KYC/' + "juridico" + "?id=" + value)
                        .done(function (data, textStatus, jqXHR) {
                            if (data != null) {
                                for (const a in InitKycjuridico) {
                                    for (const b in data) {
                                        if (a == b) {
                                            InitKycjuridico[a] = data[b]
                                        }
                                    }
                                }
                            }

                            InitKycjuridico.nombrecomercialJur = mainHolder[0].nombre;
                            InitKycjuridico.razonsocialJur = mainHolder[0].nombre;
                            InitKycjuridico.numidentificacion = mainHolder[0].DocumentNumber;
                            InitKycjuridico.correoelectronicoJur = mainHolder[0].correoelectronico;

                            InitKycjuridico.domiciliocomercialCod_pais = mainHolder[0].cod_pais;
                            InitKycjuridico.domiciliocomercialCod_estado = mainHolder[0].TProvincia;
                            InitKycjuridico.domiciliocomercialCod_prov = mainHolder[0].TCanton;
                            InitKycjuridico.domiciliocomercialCod_localidad = mainHolder[0].TDistrito;
                            InitKycjuridico.domiciliocomercialDireccionexacta = mainHolder[0].otrasenas;

                            setupData = InitKycjuridico;
                            MapObjectToInput(InitKycjuridico);

                            return InitKycjuridico;
                        })
                }
            }
            else {
                return InitKycjuridico;
            }
        }
    };
})();

window.participacionaccionariaJurTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar la persona '" + row.participacionaccionariaNombrecompletoJur + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.kycjuridico.participacionaccionariaJurDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.kycjuridico.participacionaccionariaJurEditRow(row);
        e.stopPropagation();
    }
};