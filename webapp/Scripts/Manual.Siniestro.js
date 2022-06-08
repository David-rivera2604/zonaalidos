var app = app || {};

app.ManualSiniestro = (function () {

    var setupData = null;
    var changedCallback = null;

    function Setup() {
	
app.core.Get(app.setting.apipath + 'v1/Quote/SiniestroSetup', null,
            function (data) {
                app.core.Lookups([],
                    function () {
                        setupData = data;
                        MapObjectToInput(data);
                    }, ``);

            });
    };
    
    function ReadOnly() {
        $('#StatementDate_group').replaceWith('<div>' + $('#StatementDate').val() + '</div>');
        $('#OccurrenceDate_group').replaceWith('<div>' + $('#OccurrenceDate').val() + '</div>');
        $('#ReserveAmount').replaceWith('<div>' + $('#ReserveAmount').val() + '</div>');
        $('#PaidAmount').replaceWith('<div>' + $('#PaidAmount').val() + '</div>');
        $('#PaidDate_group').replaceWith('<div>' + $('#PaidDate').val() + '</div>');
        $('#DeclinedDate_group').replaceWith('<div>' + $('#DeclinedDate').val() + '</div>');
        $('label[for=AssociateIsTheInsured').next().replaceWith('<div>' + $('label[for=AssociateIsTheInsured_'+app.ui.GetRadioNumericValue('AssociateIsTheInsured')+'').html() + '</div>');
        $('#DisabilityDate_group').replaceWith('<div>' + $('#DisabilityDate').val() + '</div>');
        $('label[for=Disputability').next().replaceWith('<div>' + $('label[for=Disputability_'+app.ui.GetRadioNumericValue('Disputability')+'').html() + '</div>');
        $('#ClaimId').replaceWith('<div>' + $('#ClaimId').val() + '</div>');
        $('#Status').replaceWith('<div>' + $('#Status option:selected').text() + '</div>');
        $('#IncidentDetail').replaceWith('<div>' + $('#IncidentDetail').val() + '</div>');
        $('#PolicyInternalId').replaceWith('<div>' + $('#PolicyInternalId option:selected').text() + '</div>');
        $('#CertificatInternalId').replaceWith('<div>' + $('#CertificatInternalId option:selected').text() + '</div>');
        $('#CoverageInternalId').replaceWith('<div>' + $('#CoverageInternalId option:selected').text() + '</div>');
        $('#Sector').replaceWith('<div>' + $('#Sector').val() + '</div>');
        $('#LineOfBusiness').replaceWith('<div>' + $('#LineOfBusiness').val() + '</div>');
        $('#IssueDate_group').replaceWith('<div>' + $('#IssueDate').val() + '</div>');
        $('#EffectiveDate_group').replaceWith('<div>' + $('#EffectiveDate').val() + '</div>');
        $('#EndingDate_group').replaceWith('<div>' + $('#EndingDate').val() + '</div>');
        $('#ProducerId').replaceWith('<div>' + $('#ProducerId').val() + '</div>');
        $('#EffectiveOtherPolicyDate_group').replaceWith('<div>' + $('#EffectiveOtherPolicyDate').val() + '</div>');
        $('#documentosrequeridosNew').addClass('d-none');
        $('#documentosrequeridosTbl').bootstrapTable('hideColumn', 'Actions');

    };
    
  function MapInputToObject() {
        var data = {
            StatementDate: app.ui.GetDateValue('#StatementDate'),
            OccurrenceDate: app.ui.GetDateValue('#OccurrenceDate'),
            ReserveAmount: app.ui.GetNumericValue('#ReserveAmount'),
            PaidAmount: app.ui.GetNumericValue('#PaidAmount'),
            PaidDate: app.ui.GetDateValue('#PaidDate'),
            DeclinedDate: app.ui.GetDateValue('#DeclinedDate'),
            AssociateIsTheInsured: app.ui.GetRadioNumericValue('AssociateIsTheInsured'),
            DisabilityDate: app.ui.GetDateValue('#DisabilityDate'),
            Disputability: app.ui.GetRadioNumericValue('Disputability'),
            ClaimId: $('#ClaimId').val(),
            Status: app.ui.GetDropDownNumericValue('#Status'),
            IncidentDetail: $('#IncidentDetail').val(),
            PolicyInternalId: app.ui.GetDropDownNumericValue('#PolicyInternalId'),
            CertificatInternalId: app.ui.GetDropDownNumericValue('#CertificatInternalId'),
            CoverageInternalId: app.ui.GetDropDownNumericValue('#CoverageInternalId'),
            Sector: app.ui.GetNumericValue('#Sector'),
            LineOfBusiness: app.ui.GetNumericValue('#LineOfBusiness'),
            IssueDate: app.ui.GetDateValue('#IssueDate'),
            EffectiveDate: app.ui.GetDateValue('#EffectiveDate'),
            EndingDate: app.ui.GetDateValue('#EndingDate'),
            ProducerId: app.ui.GetNumericValue('#ProducerId'),
            EffectiveOtherPolicyDate: app.ui.GetDateValue('#EffectiveOtherPolicyDate'),
            terceros: $('#tercerosTbl').bootstrapTable('getData'),
            documentosrequeridos: $('#documentosrequeridosTbl').bootstrapTable('getData'),

        };
        return data;
    };

    function MapObjectToInput(data) {
        app.ui.SetDateValue('#StatementDate', data.StatementDate);
        app.ui.SetDateValue('#OccurrenceDate', data.OccurrenceDate);
        app.ui.SetNumericValue('#ReserveAmount', data.ReserveAmount);
        app.ui.SetNumericValue('#PaidAmount', data.PaidAmount);
        app.ui.SetDateValue('#PaidDate', data.PaidDate);
        app.ui.SetDateValue('#DeclinedDate', data.DeclinedDate);
        app.ui.SetRadioNumericValue('AssociateIsTheInsured', data.AssociateIsTheInsured);
        app.ui.SetDateValue('#DisabilityDate', data.DisabilityDate);
        app.ui.SetRadioNumericValue('Disputability', data.Disputability);
        $('#ClaimId').val(data.ClaimId);
        $('#Status').val(data.Status);
        app.ui.SetDropDownNumericValue('#Status', data.Status, true);
        $('#IncidentDetail').val(data.IncidentDetail);
        $('#PolicyInternalId').val(data.PolicyInternalId);
        app.ui.SetDropDownNumericValue('#PolicyInternalId', data.PolicyInternalId, true);
        $('#CertificatInternalId').val(data.CertificatInternalId);
        app.ui.SetDropDownNumericValue('#CertificatInternalId', data.CertificatInternalId, true);
        $('#CoverageInternalId').val(data.CoverageInternalId);
        app.ui.SetDropDownNumericValue('#CoverageInternalId', data.CoverageInternalId, true);
        app.ui.SetNumericValue('#Sector', data.Sector);
        app.ui.SetNumericValue('#LineOfBusiness', data.LineOfBusiness);
        app.ui.SetDateValue('#IssueDate', data.IssueDate);
        app.ui.SetDateValue('#EffectiveDate', data.EffectiveDate);
        app.ui.SetDateValue('#EndingDate', data.EndingDate);
        app.ui.SetNumericValue('#ProducerId', data.ProducerId);
        app.ui.SetDateValue('#EffectiveOtherPolicyDate', data.EffectiveOtherPolicyDate);
        if (data.terceros != null)
            $('#tercerosTbl').bootstrapTable('load', data.terceros);
        else
            $('#tercerosTbl').bootstrapTable('load', {});
        if (data.documentosrequeridos != null)
            $('#documentosrequeridosTbl').bootstrapTable('load', data.documentosrequeridos);
        else
            $('#documentosrequeridosTbl').bootstrapTable('load', {});

    };
    
    function Controls_setup() {
$('#StatementDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            defaultDate: new Date()

        });
$('#OccurrenceDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            defaultDate: new Date()

        });
new AutoNumeric('#ReserveAmount', {
            decimalCharacter: ',',
			decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
new AutoNumeric('#PaidAmount', {
            decimalCharacter: ',',
			decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '2',
            emptyInputBehavior: 'null'
        });
$('#PaidDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
$('#DeclinedDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
$('#DisabilityDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
new AutoNumeric('#Sector', {
            decimalCharacter: ',',
			decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
new AutoNumeric('#LineOfBusiness', {
            decimalCharacter: ',',
			decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
$('#IssueDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
$('#EffectiveDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
$('#EndingDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
new AutoNumeric('#ProducerId', {
            decimalCharacter: ',',
			decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: '0',
            emptyInputBehavior: 'null'
        });
$('#EffectiveOtherPolicyDate_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
$('#DocumentNumber').formatter({
            pattern: '0{{9}}-{{9999}}-{{9999}}',
            persistent: false
        });
$('#numerodetelefono').formatter({
            pattern: '{{9999}}-{{9999}}',
            persistent: false
        });
$('#DFecha_group').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es'
        });
new AutoNumeric('#DTamano', {
            decimalCharacter: ',',
			decimalCharacterAlternative: '.',
            digitGroupSeparator: '.',
            maximumValue: '9999',
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

        $('#PrototypeEdtFormSave').click(function () {

            if (app.ui.IsValid('#PrototypeEdtForm', false)) {
                app.ui.ButtonDoing('#PrototypeEdtFormSave');

                console.log(MapInputToObject())

                app.core.Post(app.setting.apipath + 'v1/Manual/Siniestro',
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
            rules: {},
            messages: {}
        });
    };

function terceros_table_setup() {

        $('#tercerosTbl').bootstrapTable({
            uniqueId: 'tercerosId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
{
	field: 'tipodetercero',
	title: 'Tipo de tercero',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
	field: 'DocumentNumber',
	title: 'Identificación',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
	field: 'nombre',
	title: 'Nombre',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
	field: 'apellido1',
	title: 'Apellido',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
	field: 'apellido2',
	title: 'Apellido 2',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: false
},{
	field: 'fechadenacimiento',
	title: 'Nacimiento',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'center',
    formatter: 'app.ui.DateFormatter',
    visible: true
},{
	field: 'mca_sexo',
	title: 'Sexo',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
	field: 'numerodetelefono',
	title: 'Teléfono',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
	field: 'correoelectronico',
	title: 'Correo electrónico',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},]
        });



    };



function documentosrequeridos_table_setup() {

        $('#documentosrequeridosTbl').bootstrapTable({
            uniqueId: 'documentosrequeridosId',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
{
	field: 'DStored',
	title: 'Estado',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
	field: 'tipo',
	title: 'Tipo de documento',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
	field: 'DNombre',
	title: 'Archivo',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
	field: 'DArchivoEsperado',
	title: 'Archivoeseperado',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
	field: 'Grupo',
	title: 'Grupo',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'left',
    formatter: 'app.ui.StringFormatter',
    visible: true
},{
	field: 'DFecha',
	title: 'Fecha',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'center',
    formatter: 'app.ui.DateFormatter',
    visible: true
},{
	field: 'DTamano',
	title: 'Tamaño',
	titleTooltip: '',
	sortable: false,
	halign: 'center',
	align: 'right',
    formatter: 'app.ui.IntegerFormatter',
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
                    events: 'documentosrequeridosTbl_Events',
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

$('#documentosrequeridosNew').click(function () {
            documentosrequeridos_table_row_edit();
        });

        $('#documentosrequeridosEdtFormSave').click(function () {
            if (app.ui.IsValid('#documentosrequeridosEdtForm', false)) {
                app.ui.ButtonDoing('#documentosrequeridosEdtFormSave');

                var row = documentosrequeridos_table_row('values');

                if (row.documentosrequeridosId === null)
                    row.documentosrequeridosId = 1;

                if ($('#documentosrequeridosModal').data('id') != null) {
                    $('#documentosrequeridosTbl').bootstrapTable('updateByUniqueId', { id: row.documentosrequeridosId, row: row });
                }
                else {
                    $('#documentosrequeridosTbl').bootstrapTable('append', row);
                }

                app.ui.ButtonDone('#documentosrequeridosEdtFormSave')
                $('#documentosrequeridosModal').modal('hide');
            }
        });

    };

function documentosrequeridos_table_row(mode) {
        if (mode == null) {
            return {
                documentosrequeridosId: null,
                DStored: null,
                tipo: null,
                DNombre: null,
                DArchivoEsperado: null,
                Grupo: null,
                DFecha: null,
                DTamano: null
            };
        }
        else {
            return {
                documentosrequeridosId: $('#documentosrequeridosModal').data('id'),
                DStored: $('#DStored').val(),
                tipo: $('#tipo').val(),
                DNombre: $('#DNombre').val(),
                DArchivoEsperado: $('#DArchivoEsperado').val(),
                Grupo: $('#Grupo').val(),
                DFecha: app.ui.GetDateValue('#DFecha'),
                DTamano: app.ui.GetNumericValue('#DTamano')
            };
        }
    };

    function documentosrequeridos_table_row_edit(row) {
        var md = $('#documentosrequeridosModal').modal({ show: false });
        var formInstance = $("#documentosrequeridosEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();
        row = row || documentosrequeridos_table_row();
        md.data('id', row.documentosrequeridosId);

        $('#DStored').val(row.DStored);
        $('#tipo').val(row.tipo);
        $('#DNombre').val(row.DNombre);
        $('#DArchivoEsperado').val(row.DArchivoEsperado);
        $('#Grupo').val(row.Grupo);
        app.ui.SetDateValue('#DFecha', row.DFecha);
        app.ui.SetNumericValue('#DTamano', row.DTamano);


        md.modal('show');
    };

    function documentosrequeridos_table_row_delete(row) {
        $('#documentosrequeridosTbl').bootstrapTable('removeByUniqueId', row.documentosrequeridosId);
    };	
	
    function documentosrequeridos_table_Validations() {
        app.ui.DateValidators();
        $("#documentosrequeridosEdtForm").validate({
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
	terceros_table_setup();
documentosrequeridos_table_setup();
documentosrequeridos_table_Validations();

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
        documentosrequeridosEditRow: function (row) {
            documentosrequeridos_table_row_edit(row);
        },
        documentosrequeridosDeleteRow: function (row) {
            documentosrequeridos_table_row_delete(row);
        }
    };
})();

window.documentosrequeridosTbl_Events = {
    'click .delete': function (e, value, row, index) {
        toastr.warning("Si está seguro de querer eliminar el visualizations '" + row.documentosrequeridosId + "' haga clic aquí", null, { timeOut: 5000, closeButton: true, progressBar: true, onclick: function () { app.Siniestro.documentosrequeridosDeleteRow(row); } });
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.Siniestro.documentosrequeridosEditRow(row);
        e.stopPropagation();
    }
};

