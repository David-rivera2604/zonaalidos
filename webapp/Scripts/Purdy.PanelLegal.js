var app = app || {};

app.PurdyPanelLegal = (function () {

    let _asiges = null;
    let _claim = null;
    let _eventCallback = null;
    let _emptyValueRecuperacion = {
        ID: null,
        numerodesiniestro: null,
        tipodedocumento: null,
        numerodedocumento: null,
        fecharecupera: null,
        receptor: null,
        montorecupera: null,
        observacion: null
    };
    let _emptyValueDetalle = {
        ID: null,
        enviadoainvestigacion: null,
        fechaenviadoainvestigacion: null,
        requisitosporpresentarparareco: null,
        enviadoaacompanamientolega: null,
        fechaenviadoaacompanamientoLeg: null,
        fechadelevento: null,
        posiblesubrogacion: null,
        fechaidentificadocomoposiblesu: null,
        muertos: null,
        lesionados: null,
        lesionadosPosibleResultado: null,
        asesorlegal: null,
        estadoprocesal: null,
        recomendacionlegal: null,
        nombredeltercero: null,
        ceduladeltercero: null,
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
    }

    function Controls_setup() {
        $('#fechaenviadoainvestigacionDet_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechaenviadoaacompanamientoLegDet_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechadeleventoDet_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        $('#fechaidentificadocomoposiblesuDet_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
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
        $('#fecharecuperaLegal_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
        new AutoNumeric('#montorecuperaLegal', {
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
            minimumValue: '-999999999999999999',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });

    };

    function Controls_Events() {

        $("#detalleEdtForm :input").change(function () {
            data_changed();
        });

    };

    function data_changed() {
        app.ui.VisibleBehaviour('.subrogacion', app.ui.GetRadioNumericValue('subrogacion') === 1);
        app.ui.SetNumericValue('#saldoporrecuperar', app.ui.GetNumericValue('#montoporrecuperar') - app.ui.GetNumericValue('#montorecuperado'));
    };

    async function GetDetalle(asigesCode, claim, exp) {
        _asiges = asigesCode;
        app.core.datapi('GET', `PurdyPanelDetalle/asiges?code=${asigesCode}&claim=${claim}&exp=${exp}`)
            .then(dataDetalle => {
                if (dataDetalle.Detalle != null) {
                    dataDetalle.Detalle.forEach(function (item) {
                        item.enviadoainvestigacionDesc = item.enviadoainvestigacion == null || item.enviadoainvestigacion == 2 ? 'No' : 'Si';
                        item.enviadoaacompanamientolegaDesc = item.enviadoaacompanamientolega == null || item.enviadoaacompanamientolega == 2 ? 'No' : 'Si';
                        item.posiblesubrogacionDesc = item.posiblesubrogacion == null || item.posiblesubrogacion == 2 ? 'No' : 'Si';
                        item.subrogacionDesc = item.subrogacion == null || item.subrogacion == 2 ? 'No' : 'Si';
                    });
                }
                $('#detalleTbl').bootstrapTable('load', dataDetalle.Detalle == null ? [] : dataDetalle.Detalle);
                _eventCallback('DetalleDataChange', dataDetalle.Detalle);
            });
    };

    async function GetRecuperacion(asigesCode, claim, exp) {
        _asiges = asigesCode;
        app.core.datapi('GET', `PurdyPanelRecuperacion/asiges?code=${asigesCode}&claim=${claim}&exp=${exp}`)
            .then(dataRecuperacion => {
                $('#recuperacionTbl').bootstrapTable('load', dataRecuperacion.Recuperacion == null ? [] : dataRecuperacion.Recuperacion);

                let montoPagado = 0;

                if (dataRecuperacion.Recuperacion != null) {
                    montoPagado = dataRecuperacion.Recuperacion.reduce((accumulator, item) => { return accumulator + item.montorecupera; }, 0);
                }

                app.ui.SetNumericValue('#montopagado', montoPagado);
                app.ui.SetNumericValue('#montoutilizado', montoPagado - app.ui.GetNumericValue('#totalesMontorecuperado'));

                _eventCallback('RecuperacionDataChange', dataRecuperacion.Recuperacion);
            });
    };

    async function detalle_table_setup() {

        $('#detalleTbl').bootstrapTable({
            uniqueId: 'ID',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'enviadoainvestigacionDesc',
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
                    field: 'requisitosporpresentarparareco',
                    title: 'Requisitos por presentar para reconstrucción',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'enviadoaacompanamientolegaDesc',
                    title: 'Enviado a acompañamiento legal',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'fechaenviadoaacompanamientoLeg',
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
                    field: 'posiblesubrogacionDesc',
                    title: 'Posible subrogación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                }, {
                    field: 'fechaidentificadocomoposiblesu',
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
                    field: 'ceduladeltercero',
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
                    field: 'subrogacionDesc',
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
                        let deleteBtn = '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del visualizations de la fila"> <i class="fa fa-close"></i> </button>';

                        if (!localStorage.getItem('Roles').includes('Administrativo') &&
                            !localStorage.getItem('Roles').includes('Legal')) {
                            deleteBtn = '';
                        }

                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del visualizations de la fila"> <i class="fa fa-pencil"></i> </button>' + deleteBtn;
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
                row.ASIGES = _asiges;
                row.NUM_SINI = _claim.NUM_SINI;
                row.NUM_EXP = _claim.NUM_EXP;
                if (row.ID === null) {
                    app.core.datapi('POST', `PurdyPanelDetalle`, row)
                        .then(created => {
                            $('#detalleModal').modal('hide');
                            GetDetalle(_asiges, _claim.NUM_SINI, _claim.NUM_EXP);
                            app.ui.Success('El movimiento de detalle, fue creada de forma exitosa.');
                        }).finally(() => {
                            app.ui.ButtonDone('#detalleEdtFormSave');
                        });
                }
                else {
                    app.core.datapi('PUT', `PurdyPanelDetalle/${row.ID}`, row)
                        .then(updated => {
                            $('#detalleModal').modal('hide');
                            GetDetalle(_asiges, _claim.NUM_SINI, _claim.NUM_EXP);
                            app.ui.Success('El movimiento de detalle, fue actualizado de forma exitosa');
                        }).finally(() => {
                            app.ui.ButtonDone('#detalleEdtFormSave');
                        });
                }
            }
        });

    };

    function detalle_table_row(mode) {
        if (mode == null) {
            return _emptyValueDetalle;
        }
        else {
            return {
                ID: $('#detalleModal').data('id'),
                enviadoainvestigacion: app.ui.GetRadioNumericValue('enviadoainvestigacionDet'),
                enviadoainvestigacionDesc: app.ui.GetRadioSelectedText('enviadoainvestigacionDet'),
                fechaenviadoainvestigacion: app.ui.GetDateValue('#fechaenviadoainvestigacionDet'),
                requisitosporpresentarparareco: $('#requisitosporpresentarparareco').val(),
                enviadoaacompanamientolega: app.ui.GetRadioNumericValue('enviadoaacompanamientolegaDet'),
                enviadoaacompanamientolegaDesc: app.ui.GetRadioSelectedText('enviadoaacompanamientolegaDet'),
                fechaenviadoaacompanamientoLeg: app.ui.GetDateValue('#fechaenviadoaacompanamientoLegDet'),
                fechadelevento: app.ui.GetDateValue('#fechadeleventoDet'),
                posiblesubrogacion: app.ui.GetRadioNumericValue('posiblesubrogacionDet'),
                posiblesubrogacionDesc: app.ui.GetRadioSelectedText('posiblesubrogacionDet'),
                fechaidentificadocomoposiblesu: app.ui.GetDateValue('#fechaidentificadocomoposiblesuDet'),
                muertos: $('#muertos').val(),
                lesionados: $('#lesionados').val(),
                lesionadosPosibleResultado: $('#lesionadosPosibleResultado').val(),
                asesorlegal: $('#asesorlegal').val(),
                estadoprocesal: $('#estadoprocesal').val(),
                recomendacionlegal: $('#recomendacionlegal').val(),
                nombredeltercero: $('#nombredeltercero').val(),
                ceduladeltercero: $('#ceduladeltercero').val(),
                telefonodeltercero: $('#telefonodeltercero').val(),
                correodeltercero: $('#correodeltercero').val(),
                placadetercerocontraparte: $('#placadetercerocontraparte').val(),
                lugaraccidente: $('#lugaraccidente').val(),
                juzgado: $('#juzgado').val(),
                expedientejudicial: $('#expedientejudicial').val(),
                fechasentencia: app.ui.GetDateValue('#fechasentencia'),
                subrogacion: app.ui.GetRadioNumericValue('subrogacion'),
                subrogacionDesc: app.ui.GetRadioSelectedText('subrogacion'),
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
        md.data('id', row.ID);

        app.ui.SetRadioNumericValue('enviadoainvestigacionDet', row.enviadoainvestigacion);
        app.ui.SetDateValue('#fechaenviadoainvestigacionDet', row.fechaenviadoainvestigacion);
        $('#requisitosporpresentarparareco').val(row.requisitosporpresentarparareco);
        app.ui.SetRadioNumericValue('enviadoaacompanamientolegaDet', row.enviadoaacompanamientolega);
        app.ui.SetDateValue('#fechaenviadoaacompanamientoLegDet', row.fechaenviadoaacompanamientoLeg);
        app.ui.SetDateValue('#fechadeleventoDet', row.fechadelevento);
        app.ui.SetRadioNumericValue('posiblesubrogacionDet', row.posiblesubrogacion);
        app.ui.SetDateValue('#fechaidentificadocomoposiblesuDet', row.fechaidentificadocomoposiblesu);
        $('#muertos').val(row.muertos);
        $('#lesionados').val(row.lesionados);
        $('#lesionadosPosibleResultado').val(row.lesionadosPosibleResultado);
        $('#asesorlegal').val(row.asesorlegal);
        $('#estadoprocesal').val(row.estadoprocesal);
        $('#recomendacionlegal').val(row.recomendacionlegal);
        $('#nombredeltercero').val(row.nombredeltercero);
        $('#ceduladeltercero').val(row.ceduladeltercero);
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

        data_changed();
        md.modal('show');
    };

    function detalle_table_row_delete(row) {
        app.core.datapi('DELETE', `PurdyPanelDetalle/${row.ID}`)
            .then(deleted => {
                GetDetalle(_asiges);
                app.ui.Success('El movimiento de detalle, fue eliminado de forma exitosa');
            });
    };

    function detalle_table_Validations() {
        app.ui.DateValidators();
        $("#detalleEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                correodeltercero: { email: true }
            },
            messages: {
                correodeltercero: { email: 'Debe indicar un correo electrónico valido' }
            }
        });
    };

    async function recuperacion_table_setup() {

        $('#recuperacionTbl').bootstrapTable({
            uniqueId: 'ID',
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
                    field: 'fecharecupera',
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
                    field: 'montorecupera',
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
                        let deleteBtn = '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del visualizations de la fila"> <i class="fa fa-close"></i> </button>';

                        if (!localStorage.getItem('Roles').includes('Administrativo')) {
                            deleteBtn = '';
                        }
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del visualizations de la fila"> <i class="fa fa-pencil"></i> </button>' + deleteBtn;
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
                row.ASIGES = _asiges;
                row.NUM_SINI = _claim.NUM_SINI;
                row.NUM_EXP = _claim.NUM_EXP;
                if (row.ID === null) {
                    app.core.datapi('POST', `PurdyPanelRecuperacion`, row)
                        .then(created => {
                            $('#recuperacionModal').modal('hide');
                            GetRecuperacion(_asiges, _claim.NUM_SINI, _claim.NUM_EXP);
                            app.ui.Success('El movimiento de recuperación, fue creada de forma exitosa');
                        }).finally(() => {
                            app.ui.ButtonDone('#recuperacionEdtFormSave');
                        });
                }
                else {
                    app.core.datapi('PUT', `PurdyPanelRecuperacion/${row.ID}`, row)
                        .then(updated => {
                            $('#recuperacionModal').modal('hide');
                            GetRecuperacion(_asiges, _claim.NUM_SINI, _claim.NUM_EXP);
                            app.ui.Success('El movimiento de recuperación, fue actualizado de forma exitosa');
                        }).finally(() => {
                            app.ui.ButtonDone('#recuperacionEdtFormSave');
                        });
                }
            }
        });

    };

    function recuperacion_table_row(mode) {
        if (mode == null) {
            return _emptyValueRecuperacion;
        }
        else {
            return {
                ID: $('#recuperacionModal').data('id'),
                numerodesiniestro: $('#numerodesiniestroLegal').val(),
                tipodedocumento: $('#tipodedocumentoLegal').val(),
                numerodedocumento: $('#numerodedocumentoLegal').val(),
                fecharecupera: app.ui.GetDateValue('#fecharecuperaLegal'),
                receptor: $('#receptorLegal').val(),
                montorecupera: app.ui.GetNumericValue('#montorecuperaLegal'),
                observacion: $('#observacionLegal').val()
            };
        }
    };

    function recuperacion_table_row_edit(row) {
        var md = $('#recuperacionModal').modal({ show: false });
        var formInstance = $("#recuperacionEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || recuperacion_table_row();
        md.data('id', row.ID);

        $('#numerodesiniestroLegal').val(row.numerodesiniestro);
        $('#tipodedocumentoLegal').val(row.tipodedocumento);
        $('#numerodedocumentoLegal').val(row.numerodedocumento);
        app.ui.SetDateValue('#fecharecuperaLegal', row.fecharecupera);
        $('#receptorLegal').val(row.receptor);
        app.ui.SetNumericValue('#montorecuperaLegal', row.montorecupera);
        $('#observacionLegal').val(row.observacion);


        md.modal('show');
    };

    function recuperacion_table_row_delete(row) {
        app.core.datapi('DELETE', `PurdyPanelRecuperacion/${row.ID}`)
            .then(deleted => {
                GetRecuperacion(_asiges);
                app.ui.Success('El movimiento de recuperación, fue eliminado de forma exitosa');
            });
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
                detalle_table_setup();
                detalle_table_Validations();
                recuperacion_table_setup();
                recuperacion_table_Validations();

                Controls_Events();

                $('#detalleTbl').bootstrapTable('load', {});
                $('#recuperacionTbl').bootstrapTable('load', {});
            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Event: async function (src, data) {
            switch (src) {
                case 'ASIGESChange':
                    if (data.claim != null) {
                        _claim = data.claim;
                        GetDetalle(data.asiges, data.claim.NUM_SINI, data.claim.NUM_EXP);
                        GetRecuperacion(data.asiges, data.claim.NUM_SINI, data.claim.NUM_EXP);
                        _emptyValueRecuperacion.numerodesiniestro = data.claim.NUM_SINI;
                    } else {
                        $('#detalleTbl').bootstrapTable('load', []);
                        $('#recuperacionTbl').bootstrapTable('load', []);
                        app.ui.SetNumericValue('#montopagado', 0);
                        app.ui.SetNumericValue('#totalesMontorecuperado', 0);
                        app.ui.SetNumericValue('#montoutilizado', 0);
                        app.ui.VisibleBehaviour('.posiblesubrogacion', false)
                    }
                    break;
                case 'EventoDataChange':
                    app.ui.VisibleBehaviour('.posiblesubrogacion', data.event.POSIBLESUBROGACION === 1);


                    _emptyValueDetalle.enviadoainvestigacion = data.event.ENVIADOAINVESTIGACION;
                    _emptyValueDetalle.fechaenviadoainvestigacion = data.event.FECHAENVIADOAINVESTIGACION;
                    _emptyValueDetalle.enviadoaacompanamientolega = data.event.ENVIADOAACOMPANAMIENTOLEGAL;
                    _emptyValueDetalle.fechaenviadoaacompanamientoLeg = data.event.FECHAENVIADOACOMPALEGAL;

                    _emptyValueDetalle.fechadelevento = data.event.FECHADELEVENTO;
                    _emptyValueDetalle.posiblesubrogacion = data.event.POSIBLESUBROGACION;
                    _emptyValueDetalle.fechaidentificadocomoposiblesu = data.event.FECHAPOSIBLESUBROGACION;

                    break;
                case 'BalanceDataChange':
                    let montoRecuperado = 0;
                    if (data.balance != null) {
                        montoRecuperado = data.balance.filter(i => i.TIPODEDOCUMENTO === 1 || i.TIPODEDOCUMENTO === 2)?.reduce((accumulator, item) => { return accumulator + item.MONTO; }, 0);
                    }
                    app.ui.SetNumericValue('#totalesMontorecuperado', montoRecuperado);
                    app.ui.SetNumericValue('#montoutilizado', 0 - montoRecuperado);
                    break;
            }
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
        app.ui.Warning("Si está seguro de querer eliminar el visualizations '" + row.ID + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PurdyPanelLegal.detalleDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PurdyPanelLegal.detalleEditRow(row);
        e.stopPropagation();
    }
};
window.recuperacionTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.ui.Warning("Si está seguro de querer eliminar el visualizations '" + row.ID + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.PurdyPanelLegal.recuperacionDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.PurdyPanelLegal.recuperacionEditRow(row);
        e.stopPropagation();
    }
};
