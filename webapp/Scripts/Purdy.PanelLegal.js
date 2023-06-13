var app = app || {};

app.PurdyPanelLegal = (function () {

    let _eventCallback = null;
    var setupData = null;
    var changedCallback = null;

    function Setup() {

        app.core.Get(app.setting.apipath + 'v1/Quote/PanelLegalSetup', null,
            function (data) {
                app.core.Lookups([],
                    function () {
                        setupData = data;
                        MapObjectToInput(data);
                    }, ``);

            });
    };

    function ReadOnly() {
        $('#aSIGES').replaceWith('<div>' + $('#aSIGES').val() + '</div>');
        $('#detalleNew').addClass('d-none');
        $('#detalleTbl').bootstrapTable('hideColumn', 'Actions');
        $('#recuperacionNew').addClass('d-none');
        $('#recuperacionTbl').bootstrapTable('hideColumn', 'Actions');
        $('#montopagado').replaceWith('<div>' + $('#montopagado').val() + '</div>');
        $('#totalesMontorecuperado').replaceWith('<div>' + $('#totalesMontorecuperado').val() + '</div>');
        $('#montoutilizado').replaceWith('<div>' + $('#montoutilizado').val() + '</div>');

    };

    function MapInputToObject() {
        var data = {
            aSIGES: $('#aSIGES').val(),
            detalle: $('#detalleTbl').bootstrapTable('getData'),
            recuperacion: $('#recuperacionTbl').bootstrapTable('getData'),
            montopagado: app.ui.GetNumericValue('#montopagado'),
            totalesMontorecuperado: app.ui.GetNumericValue('#totalesMontorecuperado'),
            montoutilizado: app.ui.GetNumericValue('#montoutilizado'),

        };
        return data;
    };

    function MapObjectToInput(data) {
        $('#aSIGES').val(data.aSIGES);
        if (data.detalle != null)
            $('#detalleTbl').bootstrapTable('load', data.detalle);
        else
            $('#detalleTbl').bootstrapTable('load', {});
        if (data.recuperacion != null)
            $('#recuperacionTbl').bootstrapTable('load', data.recuperacion);
        else
            $('#recuperacionTbl').bootstrapTable('load', {});
        app.ui.SetNumericValue('#montopagado', data.montopagado);
        app.ui.SetNumericValue('#totalesMontorecuperado', data.totalesMontorecuperado);
        app.ui.SetNumericValue('#montoutilizado', data.montoutilizado);

    };

    function Controls_setup() {
        $('#fechaenviadoainvestigacion_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechaenviadoaacompanamientoLegal_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechadelevento_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechaidentificadocomoposiblesubrogacion_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#DocumentNumber').formatter({
            pattern: '0{{9}}-{{9999}}-{{9999}}',
            persistent: false
        });
        $('#telefonodeltercero').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        $('#fechasentencia_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#montoporrecuperar', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montorecuperado', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#saldoporrecuperar', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#fecha_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#monto', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montopagado', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#totalesMontorecuperado', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#montoutilizado', {
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
        $(".input-group.date").on('dp.change', function (e) {
            data_changed();
        });
        $("#PurdyPanelLegalEdtForm :input").change(function () {
            data_changed();
        });

        $('#DocumentNumberTypeMenu a').click(function () {
            app.ui.DocumentTypeHandler(this, '#DocumentNumber', 'Identification');
        });

        $('#DocumentNumber').on('blur', function () {
            if (app.ui.IsDocumentNumberValid($('#DocumentNumberType').data('value'), $('#DocumentNumber').val())) {
                var value = $('#DocumentNumber').val().replace(/-/g, '');
                if (value !== null && parseInt(0 + value, 10) !== 0 && parseInt(0 + value, 10) <= 999999999) {
                    $('#DocumentNumber').addClass('loading');
                    app.core.GetExt('https://www.inmotiontools.com:8083/logic/api/padron/personaporcedula?cedula=' + parseInt(0 + value, 10))
                        .done(function (data, textStatus, jqXHR) {
                            if (data.Nombre !== null) {
                                alert(data.Nombre);
                            }
                        }).always(function () {
                            $('#DocumentNumber').removeClass('loading');
                        });
                }
            }
        });
        $('#telefonodelterceroTypeMenu a').click(function () {
            app.ui.DocumentTypeHandler(this, '#telefonodeltercero', 'Phone');
        });

        $('#PurdyPanelLegalEdtFormSave').click(function () {

            if (app.ui.IsValid('#PurdyPanelLegalEdtForm', false)) {
                app.ui.ButtonDoing('#PurdyPanelLegalEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/Purdy/PanelLegal',
                    JSON.stringify(MapInputToObject()),
                    function (data) {
                        if (data.Mensaje != null) {
                            app.ui.ShowAlert('quoteNotify', 'alert-danger', data.Mensaje);
                        }
                        else {

                        }

                    }).always(function () {
                        app.ui.ButtonDone('#PurdyPanelLegalEdtFormSave');
                    });
            }
            event.preventDefault();
        });

        $('#PurdyPanelLegalEdtFormCancel').click(function () {
            app.ui.ButtonDoing('#PurdyPanelLegalEdtFormCancel');
            setTimeout(() => { app.ui.ButtonDone('#PurdyPanelLegalEdtFormCancel'); }, 3000);
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
        $("#PurdyPanelLegalEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                aSIGES: { required: true },
                correodeltercero: { email: true },
            },
            messages: {
                aSIGES: { required: 'Debe indicar el asiges' },
                correodeltercero: { email: 'Debe indicar un correo electrónico valido' },
            }
        });
    };

    function detalle_table_setup() {

        $('#detalleTbl').bootstrapTable({
            uniqueId: 'detalleId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'enviadoainvestigacion',
                    title: 'Enviado a investigación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'fechaenviadoainvestigacion',
                    title: 'Fecha enviado a investigación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'requisitosporpresentarparareconstruccion',
                    title: 'Requisitos por presentar para reconstrucción',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'enviadoaacompanamientolegal',
                    title: 'Enviado a acompañamiento legal',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'fechaenviadoaacompanamientoLegal',
                    title: 'Fecha enviado a acompañamiento Legal',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'fechadelevento',
                    title: 'Fecha del evento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'posiblesubrogacion',
                    title: 'Posible subrogación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'fechaidentificadocomoposiblesubrogacion',
                    title: 'Fecha identificado como posible subrogación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'muertos',
                    title: 'Muertos',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'lesionados',
                    title: 'Lesionados',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'lesionadosPosibleResultado',
                    title: 'Lesionados (Posible Resultado)',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'asesorlegal',
                    title: 'Asesor legal',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'estadoprocesal',
                    title: 'Estado procesal',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'recomendacionlegal',
                    title: 'Recomendación legal',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'nombredeltercero',
                    title: 'Nombre del tercero',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'DocumentNumber',
                    title: 'Cédula del tercero',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'telefonodeltercero',
                    title: 'Teléfono del tercero',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'correodeltercero',
                    title: 'Correo del tercero',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'placadetercerocontraparte',
                    title: 'Placa de tercero (contraparte)',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'lugaraccidente',
                    title: 'Lugar accidente',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'juzgado',
                    title: 'Juzgado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'expedientejudicial',
                    title: 'Expediente judicial',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'fechasentencia',
                    title: 'Fecha sentencia',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'subrogacion',
                    title: 'Subrogación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'montoporrecuperar',
                    title: 'Monto por recuperar',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'montorecuperado',
                    title: 'Monto recuperado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'saldoporrecuperar',
                    title: 'Saldo por recuperar',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
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
                    events: 'detalleTbl_Events',
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

        $('#detalleNew').click(function () {
            detalle_table_row_edit();
        });

        $('#detalleEdtFormSave').click(function () {
            if (app.ui.IsValid('#detalleEdtForm', false)) {
                app.ui.ButtonDoing('#detalleEdtFormSave');

                var row = detalle_table_row('values');

                if (row.detalleId === null)
                    row.detalleId = 1;

                if ($('#detalleModal').data('id') != null) {
                    $('#detalleTbl').bootstrapTable('updateByUniqueId', { id: row.detalleId, row: row });
                }
                else {
                    $('#detalleTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#detalleEdtFormSave')
                $('#detalleModal').modal('hide');
            }
        });

    };

    function detalle_table_row(mode) {
        if (mode == null) {
            return {
                detalleId: null,
                enviadoainvestigacion: null,
                fechaenviadoainvestigacion: null,
                requisitosporpresentarparareconstruccion: null,
                enviadoaacompanamientolegal: null,
                fechaenviadoaacompanamientoLegal: null,
                fechadelevento: null,
                posiblesubrogacion: null,
                fechaidentificadocomoposiblesubrogacion: null,
                muertos: null,
                lesionados: null,
                lesionadosPosibleResultado: null,
                asesorlegal: null,
                estadoprocesal: null,
                recomendacionlegal: null,
                nombredeltercero: null,
                DocumentNumber: null,
                telefonodeltercero: null,
                correodeltercero: null,
                placadetercerocontraparte: null,
                lugaraccidente: null,
                juzgado: null,
                expedientejudicial: null,
                fechasentencia: null,
                subrogacion: null,
                montoporrecuperar: null,
                montorecuperado: null,
                saldoporrecuperar: null
            };
        }
        else {
            return {
                detalleId: $('#detalleModal').data('id'),
                enviadoainvestigacion: app.ui.GetRadioNumericValue('enviadoainvestigacion'),
                fechaenviadoainvestigacion: app.ui.GetDateValue('#fechaenviadoainvestigacion'),
                requisitosporpresentarparareconstruccion: $('#requisitosporpresentarparareconstruccion').val(),
                enviadoaacompanamientolegal: app.ui.GetRadioNumericValue('enviadoaacompanamientolegal'),
                fechaenviadoaacompanamientoLegal: app.ui.GetDateValue('#fechaenviadoaacompanamientoLegal'),
                fechadelevento: app.ui.GetDateValue('#fechadelevento'),
                posiblesubrogacion: app.ui.GetRadioNumericValue('posiblesubrogacion'),
                fechaidentificadocomoposiblesubrogacion: app.ui.GetDateValue('#fechaidentificadocomoposiblesubrogacion'),
                muertos: $('#muertos').val(),
                lesionados: $('#lesionados').val(),
                lesionadosPosibleResultado: $('#lesionadosPosibleResultado').val(),
                asesorlegal: $('#asesorlegal').val(),
                estadoprocesal: $('#estadoprocesal').val(),
                recomendacionlegal: $('#recomendacionlegal').val(),
                nombredeltercero: $('#nombredeltercero').val(),
                DocumentNumber: $('#DocumentNumber').val(),
                telefonodeltercero: $('#telefonodeltercero').val(),
                correodeltercero: $('#correodeltercero').val(),
                placadetercerocontraparte: $('#placadetercerocontraparte').val(),
                lugaraccidente: $('#lugaraccidente').val(),
                juzgado: $('#juzgado').val(),
                expedientejudicial: $('#expedientejudicial').val(),
                fechasentencia: app.ui.GetDateValue('#fechasentencia'),
                subrogacion: app.ui.GetRadioNumericValue('subrogacion'),
                montoporrecuperar: app.ui.GetNumericValue('#montoporrecuperar'),
                montorecuperado: app.ui.GetNumericValue('#montorecuperado'),
                saldoporrecuperar: app.ui.GetNumericValue('#saldoporrecuperar')
            };
        }
    };

    function detalle_table_row_edit(row) {
        var md = $('#detalleModal').modal({ show: false });
        var formInstance = $("#detalleEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || detalle_table_row();
        md.data('id', row.detalleId);

        app.ui.SetRadioNumericValue('enviadoainvestigacion', row.enviadoainvestigacion);
        app.ui.SetDateValue('#fechaenviadoainvestigacion', row.fechaenviadoainvestigacion);
        $('#requisitosporpresentarparareconstruccion').val(row.requisitosporpresentarparareconstruccion);
        app.ui.SetRadioNumericValue('enviadoaacompanamientolegal', row.enviadoaacompanamientolegal);
        app.ui.SetDateValue('#fechaenviadoaacompanamientoLegal', row.fechaenviadoaacompanamientoLegal);
        app.ui.SetDateValue('#fechadelevento', row.fechadelevento);
        app.ui.SetRadioNumericValue('posiblesubrogacion', row.posiblesubrogacion);
        app.ui.SetDateValue('#fechaidentificadocomoposiblesubrogacion', row.fechaidentificadocomoposiblesubrogacion);
        $('#muertos').val(row.muertos);
        $('#lesionados').val(row.lesionados);
        $('#lesionadosPosibleResultado').val(row.lesionadosPosibleResultado);
        $('#asesorlegal').val(row.asesorlegal);
        $('#estadoprocesal').val(row.estadoprocesal);
        $('#recomendacionlegal').val(row.recomendacionlegal);
        $('#nombredeltercero').val(row.nombredeltercero);
        $('#DocumentNumber').val(row.DocumentNumber);
        $('#telefonodeltercero').val(row.telefonodeltercero);
        $('#correodeltercero').val(row.correodeltercero);
        $('#placadetercerocontraparte').val(row.placadetercerocontraparte);
        $('#lugaraccidente').val(row.lugaraccidente);
        $('#juzgado').val(row.juzgado);
        $('#expedientejudicial').val(row.expedientejudicial);
        app.ui.SetDateValue('#fechasentencia', row.fechasentencia);
        app.ui.SetRadioNumericValue('subrogacion', row.subrogacion);
        app.ui.SetNumericValue('#montoporrecuperar', row.montoporrecuperar);
        app.ui.SetNumericValue('#montorecuperado', row.montorecuperado);
        app.ui.SetNumericValue('#saldoporrecuperar', row.saldoporrecuperar);


        md.modal('show');
    };

    function detalle_table_row_delete(row) {
        $('#detalleTbl').bootstrapTable('removeByUniqueId', row.detalleId);
    };

    function detalle_table_Validations() {
        app.ui.DateValidators();
        $("#detalleEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {},
            messages: {}
        });
    };

    function recuperacion_table_setup() {

        $('#recuperacionTbl').bootstrapTable({
            uniqueId: 'recuperacionId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'numerodesiniestro',
                    title: 'Número de siniestro',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'tipodedocumento',
                    title: 'Tipo de documento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'numerodedocumento',
                    title: 'Número de documento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'fecha',
                    title: 'Fecha',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: true
                }, {
                    field: 'receptor',
                    title: 'Receptor',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'monto',
                    title: 'Monto',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: true
                }, {
                    field: 'observacion',
                    title: 'Observación',
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
                    events: 'recuperacionTbl_Events',
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

        $('#recuperacionNew').click(function () {
            recuperacion_table_row_edit();
        });

        $('#recuperacionEdtFormSave').click(function () {
            if (app.ui.IsValid('#recuperacionEdtForm', false)) {
                app.ui.ButtonDoing('#recuperacionEdtFormSave');

                var row = recuperacion_table_row('values');

                if (row.recuperacionId === null)
                    row.recuperacionId = 1;

                if ($('#recuperacionModal').data('id') != null) {
                    $('#recuperacionTbl').bootstrapTable('updateByUniqueId', { id: row.recuperacionId, row: row });
                }
                else {
                    $('#recuperacionTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#recuperacionEdtFormSave')
                $('#recuperacionModal').modal('hide');
            }
        });

    };

    function recuperacion_table_row(mode) {
        if (mode == null) {
            return {
                recuperacionId: null,
                numerodesiniestro: null,
                tipodedocumento: null,
                numerodedocumento: null,
                fecha: null,
                receptor: null,
                monto: null,
                observacion: null
            };
        }
        else {
            return {
                recuperacionId: $('#recuperacionModal').data('id'),
                numerodesiniestro: $('#numerodesiniestro').val(),
                tipodedocumento: $('#tipodedocumento').val(),
                numerodedocumento: $('#numerodedocumento').val(),
                fecha: app.ui.GetDateValue('#fecha'),
                receptor: $('#receptor').val(),
                monto: app.ui.GetNumericValue('#monto'),
                observacion: $('#observacion').val()
            };
        }
    };

    function recuperacion_table_row_edit(row) {
        var md = $('#recuperacionModal').modal({ show: false });
        var formInstance = $("#recuperacionEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || recuperacion_table_row();
        md.data('id', row.recuperacionId);

        $('#numerodesiniestro').val(row.numerodesiniestro);
        $('#tipodedocumento').val(row.tipodedocumento);
        $('#numerodedocumento').val(row.numerodedocumento);
        app.ui.SetDateValue('#fecha', row.fecha);
        $('#receptor').val(row.receptor);
        app.ui.SetNumericValue('#monto', row.monto);
        $('#observacion').val(row.observacion);


        md.modal('show');
    };

    function recuperacion_table_row_delete(row) {
        $('#recuperacionTbl').bootstrapTable('removeByUniqueId', row.recuperacionId);
    };

    function recuperacion_table_Validations() {
        app.ui.DateValidators();
        $("#recuperacionEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {},
            messages: {}
        });
    };



    return {
        Init: function (eventCallback) {
            try {
                _eventCallback = eventCallback;
                Controls_setup();
                Setup_Validations();
                detalle_table_setup();
                detalle_table_Validations();
                recuperacion_table_setup();
                recuperacion_table_Validations();

                Controls_Events();

            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Event: function (src, data) {
        },
        detalleEditRow: function (row) {
            detalle_table_row_edit(row);
        },
        detalleDeleteRow: function (row) {
            detalle_table_row_delete(row);
        },
        recuperacionEditRow: function (row) {
            recuperacion_table_row_edit(row);
        },
        recuperacionDeleteRow: function (row) {
            recuperacion_table_row_delete(row);
        }
    };
})();

window.detalleTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.detalleId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PanelLegal.detalleDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PanelLegal.detalleEditRow(row);
        e.stopPropagation();
    }
};
window.recuperacionTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.recuperacionId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PanelLegal.recuperacionDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PanelLegal.recuperacionEditRow(row);
        e.stopPropagation();
    }
};

