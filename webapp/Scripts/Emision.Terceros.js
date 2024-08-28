var app = app || {};

app.EmisionTercero = (function () {

    let _callback = null;
    let modelHelper = [];

    function terceros_table_setup() {

        $('#tercerosTbl').bootstrapTable({
            uniqueId: 'tercerosId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'tipodeterceroDesc',
                    title: 'Tipo de tercero',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'DocumentNumber',
                    title: 'Identificación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'nombre',
                    title: 'Nombre completo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: function (value, row, index, field) {
                        let name = value + (row.apellido1 ? ' ' + row.apellido1 : '');
                        return `<span>${name}</span>`;
                    }
                }, {
                    field: 'fechadenacimiento',
                    title: 'Nacimiento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter'
                }, {
                    field: 'tercerosMca_sexoDesc',
                    title: 'Sexo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'estadoCivilDesc',
                    title: 'Estado Civil',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'numerodetelefono',
                    title: 'Teléfono',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'correoelectronico',
                    title: 'Correo electrónico',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'TProvinciaDesc',
                    title: 'Provincia',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'TCantonDesc',
                    title: 'Cantón',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'TDistritoDesc',
                    title: 'Distrito',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                }, {
                    field: 'otrasenas',
                    title: 'Otra señas',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'numerodeprestamo',
                    title: 'El tomador es el mismo asegurado',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'numerodeprestamo',
                    title: 'El asegurado es el conductor habitual',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'numerodeprestamo',
                    title: 'Número de prestamo',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'importedecesion',
                    title: 'Importe de cesión',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter',
                    visible: false
                }, {
                    field: 'vencimientodecesion',
                    title: 'Vencimiento de cesión',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateFormatter',
                    visible: false
                }, {
                    field: 'porcentajeacredor',
                    title: 'Porcentaje acredor',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
                }, {
                    field: 'parentesco',
                    title: 'Parentesco',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: false
                }, {
                    field: 'porcentaje',
                    title: 'Porcentaje',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter',
                    visible: false
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
                    events: 'tercerosTbl_Events',
                    formatter: function (value, row, index, field) {
                        let attribute = row.NoEditable ? " disabled" : "";
                        return '<button type="button"' + attribute + ' class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del tercero de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button"' + attribute + ' class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del tercero de la fila"> <i class="fa fa-close"></i> </button>';
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

        $('#tercerosNew').click(function () {
            $('#tipodetercero').val($('#tipodetercero option[disabled!="disabled"]')[0].value);
            $('#tipodetercero').change();
            terceros_table_row_edit();
        });

        $('#tercerosEdtFormSave').click(function () {
            if (app.ui.IsValid('#tercerosEdtForm', false)) {
                app.ui.ButtonDoing('#tercerosEdtFormSave');

                var row = terceros_table_row('values');

                if (row.tercerosId === null)
                    row.tercerosId = $('#tercerosTbl').bootstrapTable('getData').length + 1;

                if ($('#tercerosModal').data('id') != null) {
                    $('#tercerosTbl').bootstrapTable('updateByUniqueId', { id: row.tercerosId, row: row });
                }
                else {
                    $('#tercerosTbl').bootstrapTable('append', row);

                    if (row.eltomadoreselmismoasegurado === 1) {
                        let newinsurance = JSON.parse(JSON.stringify(row));
                        newinsurance.tercerosId += 1;
                        newinsurance.tipodetercero = 2;
                        newinsurance.tipodeterceroDesc = $('#tipodetercero option[value="2"]').text();
                        newinsurance.eltomadoreselmismoasegurado = 1;
                        newinsurance.elaseguradoeselconductorhabitual = 2;
                        $('#tercerosTbl').bootstrapTable('append', newinsurance);
                    }

                    if (row.elaseguradoeselconductorhabitual === 1) {
                        let newDriver = JSON.parse(JSON.stringify(row));
                        newDriver.tercerosId += 1;
                        newDriver.tipodetercero = 3;
                        newDriver.tipodeterceroDesc = $('#tipodetercero option[value="3"]').text();
                        newDriver.eltomadoreselmismoasegurado = 1;
                        newDriver.elaseguradoeselconductorhabitual = 2;
                        $('#tercerosTbl').bootstrapTable('append', newDriver);
                    }
                    if (localStorage.getItem('Roles').includes('Purdy') && row.elaseguradoeselmismopagador === 1) {
                        let newpayer = JSON.parse(JSON.stringify(row));
                        newpayer.tercerosId += 1;
                        newpayer.tipodetercero = 21;
                        newpayer.tipodeterceroDesc = $('#tipodetercero option[value="21"]').text();
                        newpayer.elaseguradoeselmismopagador = 1;
                        newpayer.elaseguradoeselconductorhabitual = 2;
                        $('#tercerosTbl').bootstrapTable('append', newpayer);
                    }
                }

                if (row.tipodetercero === 2) {
                    $('#correoenvio').val(row.correoelectronico);
                }

                app.ui.ButtonDone('#tercerosEdtFormSave')
                $('#tercerosModal').modal('hide');
                if (_callback != null)
                    _callback('tercerosEdtFormSave');

            }
        });

    }

    function terceros_table_row(mode) {
        if (mode == null) {
            return {
                tercerosId: null,
                tipodetercero: $('#tipodetercero').val(),
                DocumentNumberType: null,
                DocumentNumber: null,
                nombre: null,
                apellido1: null,
                apellido2: null,
                fechadenacimiento: null,
                tercerosMca_sexo: null,
                estadoCivil: null,
                numerodetelefono: null,
                correoelectronico: null,
                cod_pais: 'CRI',
                TProvincia: null,
                TCanton: null,
                TDistrito: null,
                otrasenas: null,
                eltomadoreselmismoasegurado: 2,
                elaseguradoeselconductorhabitual: 2,
                elaseguradoeselmismopagador: 2,
                numerodeprestamo: null,
                importedecesion: null,
                vencimientodecesion: null,
                porcentajeacredor: null,
                parentesco: null,
                porcentaje: null,
                NoEditable: false
            };
        }
        else {
            return {
                tercerosId: $('#tercerosModal').data('id'),
                tipodetercero: app.ui.GetDropDownNumericValue('#tipodetercero'),
                tipodeterceroDesc: $('#tipodetercero option:selected').text(),
                DocumentNumberType: $("#DocumentNumberType").data("value"),
                DocumentNumber: $('#DocumentNumber').val(),
                nombre: $('#nombre').val(),
                apellido1: $('#apellido1').val(),
                apellido2: $('#apellido2').val(),
                fechadenacimiento: app.ui.GetDateValue('#fechadenacimiento'),
                tercerosMca_sexo: $('#tercerosMca_sexo').val(),
                tercerosMca_sexoDesc: $('#tercerosMca_sexo option:selected').text(),
                estadoCivil: $('#estadoCivil').val(),
                estadoCivilDesc: $('#estadoCivil option:selected').text(),
                numerodetelefono: $('#numerodetelefono').val(),
                correoelectronico: $('#correoelectronico').val(),
                cod_pais: $('#cod_pais').val(),
                TProvincia: $('#TProvincia').val(),
                TProvinciaDesc: $('#TProvincia option:selected').text(),
                TCanton: $('#TCanton').val(),
                TCantonDesc: $('#TCanton option:selected').text(),
                TDistrito: $('#TDistrito').val(),
                TDistritoDesc: $('#TDistrito option:selected').text(),
                otrasenas: $('#otrasenas').val(),
                eltomadoreselmismoasegurado: app.ui.GetRadioNumericValue('eltomadoreselmismoasegurado'),
                elaseguradoeselconductorhabitual: app.ui.GetRadioNumericValue('elaseguradoeselconductorhabitual'),
                elaseguradoeselmismopagador: app.ui.GetRadioNumericValue('elaseguradoeselmismopagador'),
                numerodeprestamo: $('#numerodeprestamo').val(),
                importedecesion: app.ui.GetNumericValue('#importedecesion'),
                vencimientodecesion: app.ui.GetDateValue('#vencimientodecesion'),
                porcentajeacredor: $('#porcentajeacredor').val(),
                parentesco: $('#parentesco').val(),
                parentescoDesc: $('#parentesco option:selected').text(),
                porcentaje: $('#porcentaje').val(),
                NoEditable: false
            };
        }
    }

    function terceros_table_row_edit(row) {
        var md = $('#tercerosModal').modal({ show: false });
        var formInstance = $("#tercerosEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || terceros_table_row();
        md.data('id', row.tercerosId);

        $('#tipodetercero').val(row.tipodetercero);
        $('#tipodetercero').change();
        app.ui.SetDocumentTypeValue('#DocumentNumberType', row.DocumentNumberType);
        terceros_documentTypeCallBack(row.DocumentNumberType);
        $('#DocumentNumber').val(row.DocumentNumber);
        $('#nombre').val(row.nombre);
        $('#apellido1').val(row.apellido1);
        $('#apellido2').val(row.apellido2);
        app.ui.SetDateValue('#fechadenacimiento', row.fechadenacimiento);
        $('#tercerosMca_sexo').val(row.tercerosMca_sexo);
        $('#estadoCivil').val(row.estadoCivil);
        $('#numerodetelefono').val(row.numerodetelefono);
        $('#correoelectronico').val(row.correoelectronico);
        $('#cod_pais').val(row.cod_pais);
        $('#TProvincia').val(row.TProvincia);

        app.core.LookupDependency(row.TProvincia, 'TCanton', 'Cantones', '', row.TCanton, false, null, `cod_pais=${row.cod_pais}:cod_estado=`);
        app.core.LookupDependency(row.TCanton, 'TDistrito', 'Distritos', '', row.TDistrito, false, null, `cod_pais=${row.cod_pais}:cod_prov=`);

        $('#otrasenas').val(row.otrasenas);
        app.ui.SetRadioNumericValue('eltomadoreselmismoasegurado', row.eltomadoreselmismoasegurado)
        app.ui.SetRadioNumericValue('elaseguradoeselconductorhabitual', row.elaseguradoeselconductorhabitual)
        app.ui.SetRadioNumericValue('elaseguradoeselmismopagador', row.elaseguradoeselmismopagador)

        $('#numerodeprestamo').val(row.numerodeprestamo);
        app.ui.SetNumericValue('#importedecesion', row.importedecesion);
        app.ui.SetDateValue('#vencimientodecesion', row.vencimientodecesion);
        app.ui.SetNumericValue('#porcentajeacredor', row.porcentajeacredor);
        $('#parentesco').val(row.parentesco);
        app.ui.SetNumericValue('#porcentaje', row.porcentaje);


        md.modal('show');
    }

    function terceros_table_row_delete(row) {
        $('#tercerosTbl').bootstrapTable('removeByUniqueId', row.tercerosId);
    }

    function terceros_table_Validations() {
        app.ui.DateValidators();
        $("#tercerosEdtForm").validate({
            errorPlacement: app.ui.ErrorPlacement,
            rules: {
                tipodetercero: { required: true },
                DocumentNumber: { required: true },
                nombre: { required: true },
                apellido1: { required: true },
                apellido2: { required: true },
                fechadenacimiento: { required: true },
                tercerosMca_sexo: { required: true },
                estadoCivil: { required: true },
                numerodetelefono: { required: true },
                correoelectronico: { email: true, required: true },
                cod_pais: { required: true },
                TProvincia: { required: true },
                TCanton: { required: true },
                TDistrito: { required: true },
                otrasenas: { required: true },
                vencimientodecesion: { required: true },
                parentesco: { required: true },
                porcentaje: { required: true },
            },
            messages: {
                tipodetercero: { required: 'Debe indicar el Tipo de tercero' },
                DocumentNumber: { required: 'Debe indicar el Identificación' },
                nombre: { required: 'Debe indicar el Nombre' },
                apellido1: { required: 'Debe indicar el Apellido 1' },
                apellido2: { required: 'Debe indicar el Apellido 2' },
                fechadenacimiento: { required: 'Debe indicar el Fecha de nacimiento' },
                tercerosMca_sexo: { required: 'Debe indicar el Sexo' },
                estadoCivil: { required: 'Debe indicar el Estado Civil' },
                numerodetelefono: { required: 'Debe indicar el Número de teléfono' },
                correoelectronico: { email: 'Debe indicar un correo electrónico valido', required: 'Debe indicar el correo electrónico' },
                cod_pais: { required: 'Debe indicar el País' },
                TProvincia: { required: 'Debe indicar el Provincia' },
                TCanton: { required: 'Debe indicar el Cantón' },
                TDistrito: { required: 'Debe indicar el Distrito' },
                otrasenas: { required: 'Debe indicar el Otra señas' },
                vencimientodecesion: { required: 'Debe indicar el Vencimiento de cesión' },
                parentesco: { required: 'Debe indicar el Parentesco' },
                porcentaje: { required: 'Debe indicar el Porcentaje' },
            }
        });
    }

    function terceros_controls_setup() {
        $('#DocumentNumber').formatter({
            pattern: '0{{9}}-{{9999}}-{{9999}}',
            persistent: false
        });
        $('#fechadenacimiento_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            maxDate: app.ui.Yesterday(),
            date: null

        });
        $('#numerodetelefono').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
        new AutoNumeric('#importedecesion', {
            decimalCharacter: ',',
            decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
        $('#vencimientodecesion_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });

    }

    function terceros_documentNumberCallBack(data) {
        if (data != null) {
            $('#nombre').val((data.FirstName + ' ' + data.MiddleName).trim());
            $('#apellido1').val(data.LastName);
            $('#apellido2').val(data.SecondLastName);
            $('#PhoneNumber').val(data.PhoneNumber);
            app.ui.SetDateValue('#fechadenacimiento', data.BirthDate);
            $('#tercerosMca_sexo').val(data.Gender);
            $('#TProvincia').val(data.Province);
            $('#correoelectronico').val(data.PrimaryEmailAddress);
            $('#numerodetelefono').val(data.PhoneNumber);

            let value = data.CivilStatus;
            if (value == '1')
                value = 'C';
            else if (value == '2')
                value = 'D';
            else if (value == '3')
                value = 'S';
            else if (value == '4')
                value = 'V';
            $('#estadoCivil').val(value);

            //function LookupDependency(parentValue, childId, lookupKey, emptyValue, newValue, triggerChange, callback, url) {

            app.core.LookupDependency(data.Province, 'TCanton', 'Cantones', '', data.Canton, false, null, 'cod_pais=CRI:cod_estado=');
            app.core.LookupDependency(data.Canton, 'TDistrito', 'Distritos', '', data.District, false, null, 'cod_pais=CRI:cod_prov=');

            //$('#TCanton').val(data.Canton);
            //$('#TDistrito').val(data.District);
            $('#otrasenas').val(data.AddressDetail);





        }
    }

    function terceros_documentTypeCallBack(data) {
        data = $("#DocumentNumberType").data("value");
        if (data === 4) {
            $('#apellido1').parent().parent().addClass('d-none');
            $('#apellido2').parent().parent().addClass('d-none');
            $('#fechadenacimiento').parent().parent().parent().addClass('d-none');
            $('#tercerosMca_sexo').parent().parent().addClass('d-none');
            $('#estadoCivil').parent().parent().addClass('d-none');
            $('#nombre').parent().parent().addClass('col-sm-8 col-md-8');

        } else {
            $('#apellido1').parent().parent().removeClass('d-none');
            $('#apellido2').parent().parent().removeClass('d-none');
            $('#fechadenacimiento').parent().parent().parent().removeClass('d-none');
            $('#tercerosMca_sexo').parent().parent().removeClass('d-none');
            $('#estadoCivil').parent().parent().removeClass('d-none');
            $('#nombre').parent().parent().removeClass('col-sm-8 col-md-8');
        }
    }

    function terceros_controls_Events() {
        app.ui.DocumentNumberHandler('#DocumentNumber', terceros_documentNumberCallBack, terceros_documentTypeCallBack);

        $('#tipodetercero').change(function () {
            switch ($('#tipodetercero').val()) {
                case '0':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().removeClass('d-none');
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().removeClass('d-none');
                    $('#beneficiarioZone').addClass('d-none');
                    $('#acredorZone').addClass('d-none');
                    break;
                case '2':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().removeClass('d-none');
                    $('#beneficiarioZone').addClass('d-none');
                    $('#acredorZone').addClass('d-none');
                    break;
                case '3':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().addClass('d-none');
                    $('#beneficiarioZone').addClass('d-none');
                    $('#acredorZone').addClass('d-none');
                    break;
                case '6':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().addClass('d-none');
                    $('#beneficiarioZone').removeClass('d-none');
                    $('#acredorZone').addClass('d-none');
                    break;
                case '8':
                    $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().addClass('d-none');
                    $('#beneficiarioZone').addClass('d-none');
                    $('#acredorZone').removeClass('d-none');
                    break;
            }

        });

        $('#TProvinciaHelperShow').click(function () {
            if (modelHelper.length === 0) {
                app.core.Get(app.setting.apipath + 'v1/datasource/AddressHelper')
                    .done(function (data) {
                        modelHelper = data;
                        let source = [];
                        data.forEach(function (value, index, array) {
                            source.push({ "name": value.DIRECCION, "code": value });
                        });
                        $('#TProvinciaHelper').typeahead({
                            highlight: true,
                            source: source,
                            afterSelect: function (item) {
                                console.log(item);
                                $('#TProvincia').val(item.code.COD_ESTADO);
                                let pais = $('select#cod_pais').val();
                                app.core.LookupDependency(item.code.COD_ESTADO, 'TCanton', 'Cantones', '', item.code.COD_PROV, false, function () {

                                    app.core.LookupDependency(item.code.COD_PROV, 'TDistrito', 'Distritos', '', item.code.COD_LOCALIDAD, false, null, `cod_pais=${pais}:cod_prov=`);

                                }, `cod_pais=${pais}:cod_estado=`);

                                $('.handler-TProvinciaHelper').addClass('d-none');
                                $('.handler-TProvincia').removeClass('d-none');
                            }
                        });
                        $('.handler-TProvinciaHelper').removeClass('d-none');
                        $('.handler-TProvincia').addClass('d-none');

                    })
            } else {
                $('.handler-TProvinciaHelper').removeClass('d-none');
                $('.handler-TProvincia').addClass('d-none');
            }
            event.preventDefault();
        });
        $('#TProvinciaHelperCancel').click(function () {
            $('.handler-TProvinciaHelper').addClass('d-none');
            $('.handler-TProvincia').removeClass('d-none');
            event.preventDefault();
        });
        // Dependencies events
        $('#TProvincia').on('change', function () {
            var pais = $('select#cod_pais').val();
            app.core.LookupDependency($('select#TProvincia').val(), 'TCanton', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
        });
        $('#TCanton').on('change', function () {
            var pais = $('select#cod_pais').val();
            app.core.LookupDependency($('select#TCanton').val(), 'TDistrito', 'Distritos', '', null, false, null, `cod_pais=${pais}:cod_prov=`);
        });
    }

    return {
        Init: function () {

            terceros_controls_setup();
            terceros_table_setup();
            terceros_table_Validations();
            terceros_controls_Events();

        },
        tercerosEditRow: function (row) {
            terceros_table_row_edit(row);
        },
        tercerosDeleteRow: function (row) {
            terceros_table_row_delete(row);
        },
        Callback: function (func) {
            _callback = func;
        }
    };
})();

window.tercerosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el tercero '" + row.nombre + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.EmisionTercero.tercerosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.EmisionTercero.tercerosEditRow(row);
        e.stopPropagation();
    }
};
