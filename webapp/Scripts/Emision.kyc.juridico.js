var app = app || {};

app.kycjuridico = (function () {

    let setupData = null;
    let changedCallback = null;
    let acceptCallback = null;

    function Setup() {
        app.core.Lookups(['Pais.paisdeconstitucionJur', 'Pais.paisJur', 'CR_Provincia.provinciaJur', 'CR_Canton.cantonJur', 'CR_Distritos.distritoJur', 'Pais.paisdenacimientoJur', 'CivilStatus.estadocivilJur', 'Gender.sexoJur', 'Pais.domiciliopermanentePaisJur', 'CR_Provincia.domiciliopermanenteProvinciaJur', 'CR_Canton.domiciliopermanenteCantonJur', 'CR_Distritos.domiciliopermanenteDistritoJur',],
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
            paisJur: app.ui.GetDropDownNumericValue('#paisJur'),
            provinciaJur: app.ui.GetDropDownNumericValue('#provinciaJur'),
            cantonJur: app.ui.GetDropDownNumericValue('#cantonJur'),
            distritoJur: app.ui.GetDropDownNumericValue('#distritoJur'),
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
            domiciliopermanentePaisJur: app.ui.GetDropDownNumericValue('#domiciliopermanentePaisJur'),
            domiciliopermanenteProvinciaJur: app.ui.GetDropDownNumericValue('#domiciliopermanenteProvinciaJur'),
            domiciliopermanenteCantonJur: app.ui.GetDropDownNumericValue('#domiciliopermanenteCantonJur'),
            domiciliopermanenteDistritoJur: app.ui.GetDropDownNumericValue('#domiciliopermanenteDistritoJur'),
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
        $('#paisJur').val(data.paisJur);
        app.ui.SetDropDownNumericValue('#paisJur', data.paisJur, true);
        $('#provinciaJur').val(data.provinciaJur);
        app.ui.SetDropDownNumericValue('#provinciaJur', data.provinciaJur, true);
        $('#cantonJur').val(data.cantonJur);
        app.ui.SetDropDownNumericValue('#cantonJur', data.cantonJur, true);
        $('#distritoJur').val(data.distritoJur);
        app.ui.SetDropDownNumericValue('#distritoJur', data.distritoJur, true);
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
        $('#domiciliopermanentePaisJur').val(data.domiciliopermanentePaisJur);
        app.ui.SetDropDownNumericValue('#domiciliopermanentePaisJur', data.domiciliopermanentePaisJur, true);
        $('#domiciliopermanenteProvinciaJur').val(data.domiciliopermanenteProvinciaJur);
        app.ui.SetDropDownNumericValue('#domiciliopermanenteProvinciaJur', data.domiciliopermanenteProvinciaJur, true);
        $('#domiciliopermanenteCantonJur').val(data.domiciliopermanenteCantonJur);
        app.ui.SetDropDownNumericValue('#domiciliopermanenteCantonJur', data.domiciliopermanenteCantonJur, true);
        $('#domiciliopermanenteDistritoJur').val(data.domiciliopermanenteDistritoJur);
        app.ui.SetDropDownNumericValue('#domiciliopermanenteDistritoJur', data.domiciliopermanenteDistritoJur, true);
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
