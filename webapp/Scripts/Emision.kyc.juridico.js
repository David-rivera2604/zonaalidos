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
            nombreComercialJur: $('#nombreComercialJur').val(),
            razonSocialJur: $('#razonSocialJur').val(),
            codigodeclienteJur: $('#codigodeclienteJur').val(),
            tipodeSociedadJur: $('#tipodeSociedadJur').val(),
            numeroCedulaJuridicaJur: $('#numeroCedulaJuridicaJur').val(),
            tipodeCedulaJuridicaJur: app.ui.GetRadioNumericValue('tipodeCedulaJuridicaJur'),
            paisdeconstitucionJur: app.ui.GetDropDownNumericValue('#paisdeconstitucionJur'),
            fechadeconstitucionJur: app.ui.GetDateValue('#fechadeconstitucionJur'),
            actividaddelClientenaturalezadelnegocioJur: $('#actividaddelClientenaturalezadelnegocioJur').val(),
            telefonoJur: $('#telefonoJur').val(),
            faxJur: $('#faxJur').val(),
            apartadoPostalJur: $('#apartadoPostalJur').val(),
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
            datosdelrepresentantelegalApartadoPostalJur: $('#datosdelrepresentantelegalApartadoPostalJur').val(),
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
            montoValoraseguradoJur: app.ui.GetNumericValue('#montoValoraseguradoJur'),
            formadepagodelapolizaJur: app.ui.GetRadioNumericValue('formadepagodelapolizaJur'),
            mediodeenvioJur: app.ui.GetRadioNumericValue('mediodeenvioJur'),
            correspondenciaEspecifiqueJur: $('#correspondenciaEspecifiqueJur').val(),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#nombreComercialJur').val(data.nombreComercialJur);
        $('#razonSocialJur').val(data.razonSocialJur);
        $('#codigodeclienteJur').val(data.codigodeclienteJur);
        $('#tipodeSociedadJur').val(data.tipodeSociedadJur);
        $('#numeroCedulaJuridicaJur').val(data.numeroCedulaJuridicaJur);
        app.ui.SetRadioNumericValue('tipodeCedulaJuridicaJur', data.tipodeCedulaJuridicaJur);
        $('#paisdeconstitucionJur').val(data.paisdeconstitucionJur);
        app.ui.SetDropDownNumericValue('#paisdeconstitucionJur', data.paisdeconstitucionJur, true);
        app.ui.SetDateValue('#fechadeconstitucionJur', data.fechadeconstitucionJur);
        $('#actividaddelClientenaturalezadelnegocioJur').val(data.actividaddelClientenaturalezadelnegocioJur);
        $('#telefonoJur').val(data.telefonoJur);
        $('#faxJur').val(data.faxJur);
        $('#apartadoPostalJur').val(data.apartadoPostalJur);
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
        $('#datosdelrepresentantelegalApartadoPostalJur').val(data.datosdelrepresentantelegalApartadoPostalJur);
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
        app.ui.SetNumericValue('#montoValoraseguradoJur', data.montoValoraseguradoJur);
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
        new AutoNumeric('#montoValoraseguradoJur', {
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

        $('#kycjuridicoJurEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#kycjuridicoJurEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#kycjuridicoJurEdtFormCancel'); }, 3000);
            event.preventDefault();
        });

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
                correoelectronicoJur: { email: true },
                datosdelrepresentantelegalCorreoelectronicoJur: { email: true },
            },
            messages: {
                correoelectronicoJur: { email: 'Debe indicar un correo electrónico valido' },
                datosdelrepresentantelegalCorreoelectronicoJur: { email: 'Debe indicar un correo electrónico valido' },
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
                    field: 'participacionaccionariaNombreCompletoJur',
                    title: 'Nombre Completo',
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
                participacionaccionariaNombreCompletoJur: null,
                porcentajedeparticipacionJur: null,
                participacionaccionariaNumerodeidentificacionJur: null
            };
        }
        else {
            return {
                participacionaccionariaJurId: $('#participacionaccionariaJurModal').data('id'),
                participacionaccionariaNombreCompletoJur: $('#participacionaccionariaNombreCompletoJur').val(),
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

        $('#participacionaccionariaNombreCompletoJur').val(row.participacionaccionariaNombreCompletoJur);
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
            rules: {},
            messages: {}
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
                data = {
                    "nombreComercialJur": "",
                    "razonSocialJur": "",
                    "codigodeclienteJur": "",
                    "tipodeSociedadJur": "",
                    "numeroCedulaJuridicaJur": "",
                    "tipodeCedulaJuridicaJur": null,
                    "paisdeconstitucionJur": 0,
                    "fechadeconstitucionJur": "0001-01-01T00:00:00",
                    "actividaddelClientenaturalezadelnegocioJur": "",
                    "telefonoJur": "",
                    "faxJur": "",
                    "apartadoPostalJur": "",
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
                    "datosdelrepresentantelegalApartadoPostalJur": "",
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
                    "montoValoraseguradoJur": 0,
                    "formadepagodelapolizaJur": null,
                    "mediodeenvioJur": null,
                    "correspondenciaEspecifiqueJur": ""
                };
            }
            if (data != null) {
                setupData = data;
                MapObjectToInput(data);
            }
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

