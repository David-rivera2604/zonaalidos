var app = app || {};

app.GeneralLookup = (function () {

    function Refresh() {
        var filter = $('#LookupSearch').val();

        $('#LookupGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/Lookup?filter=' + filter)
            .done(function (data, textStatus, jqXHR) {
                $('#LookupGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#LookupGridTbl').bootstrapTable('hideLoading');
            });
    }

    function Init_Controls() {
        new AutoNumeric('#ParentLookupId', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#SubParentLookupId', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#Code', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '999999999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#QueryOrder', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '99999',
            minimumValue: '0',
            decimalPlaces: 0,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#ExtendNumberValue1', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '99999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });
        new AutoNumeric('#ExtendNumberValue2', {
            decimalCharacter: ',',
            digitGroupSeparator: '.',
            maximumValue: '99999999999',
            minimumValue: '0',
            decimalPlaces: 2,
            emptyInputBehavior: 'null'
        });


        $(".formbtn").appendTo("#GenericToolBar");
    }

    function Init_List() {
        $('#LookupGridTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index',
            pagination: true,
            smartDisplay: true,
            detailView: false,
            showColumns: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'LanguageDesc',
                    title: 'Lenguaje',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'ParentLookupId',
                    title: 'Parent Lookup Id',
                    titleTooltip: 'Identificación del registro padre para lista con dependencias.',					
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'SubParentLookupId',
                    title: 'Sub Parent Lookup Id',
                    titleTooltip: 'Identificación del registro de según nivel para lista con dependencias.',					
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'Code',
                    title: 'Código',
                    titleTooltip: 'Código.',					
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'Description',
                    title: 'Descripción',
                    sortable: true,
                    halign: 'center',
                    events: 'LookupGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<a class="edit" href="javascript:void(0)" title="Al hacer click permite la edición de los datos del lookup">' + value + '</a>';
                    }
                }, {
                    field: 'QueryOrder',
                    title: 'Orden',
                    titleTooltip: 'Orden de despliegue.',					
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                }, {
                    field: 'HomologousCode',
                    title: 'Homologous Code',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'ExtendNumberValue1',
                    title: 'Extend Number Value 1',
                    titleTooltip: 'Primer complemento numérico.',					
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter'
                }, {
                    field: 'ExtendNumberValue2',
                    title: 'Extend Number Value 2',
                    titleTooltip: 'Segundo complemento numérico.',					
                    sortable: true,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalFormatter'
                }, {
                    field: 'ExtendStringValue1',
                    title: 'Extend String Value 1',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'ExtendStringValue2',
                    title: 'Extend String Value 2',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'RecordStatusDesc',
                    title: 'Estado del Registro',
                    sortable: true,
                    halign: 'center'
                }, {
                    field: 'UpdateDate',
                    title: 'Realizado por',
                    class: 'd-none d-sm-table-cell',
                    sortable: true,
                    halign: 'center',
                    width: 15,
                    widthUnit: '%',
                    formatter: 'app.ui.UpdateDateAndUserFormatter'
                }, {
                    title: 'Acciones',
                    class: 'd-none d-sm-table-cell',
                    titleTooltip: 'Acciones disponibles para un lookup',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    width: 10,
                    widthUnit: "%",
                    events: 'LookupGridTbl_Events',
                    formatter: function (value, row, index, field) {
                        return '<button type="button" class="btn btn-sm btn-white edit" title="Al hacer click permite la edición de los datos del lookup de la fila"> <i class="fa fa-pencil"></i> </button>' +
                            '<button type="button" class="btn btn-sm btn-white delete" title="Al hacer click permite eliminar los datos del lookup de la fila"> <i class="fa fa-close"></i> </button>';
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
    }

    function Event_Controls() {

        $('.tool-audit').on('click', function (e) {
            app.ui.components.ShowModalChangeSet(1021);
        });

        $('.tool-new').on('click', function (e) {
            app.GeneralLookup.New();
        });

        $('.tool-filter').on('click', function (e) {
            $('.advancefilter-row').toggleClass('d-none');
        });

        $('.tool-refresh').on('click', function (e) {
            Refresh();
        });

        $("#LookupSearch").keyup(function (event) {
            if (event.keyCode == 13)
                Refresh();
        });

        $('#ApplyFilter').on('click', function (e) {
            Refresh();
        });

        $('#LookupEdtFormSave').click(function () {
            if (app.ui.IsValid('#LookupEdtForm', false)) {
                app.ui.ButtonDoing('#LookupEdtFormSave');
                var data = MapInputToObject();
                if (data.LookupId === 0)
                    Create(data, 'Save');
                else
                    Update(data);
            }
            event.preventDefault();
        });

        $('#LookupEdtFormSaveContinue').click(function () {
            if (app.ui.IsValid('#LookupEdtForm', false)) {
                app.ui.ButtonDoing('#LookupEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Continue');
            }
            event.preventDefault();
        });

        $('#LookupEdtFormSaveCopy').click(function () {
            if (app.ui.IsValid('#LookupEdtForm', false)) {
                app.ui.ButtonDoing('#LookupEdtFormSaveContinue');
                var data = MapInputToObject();
                Create(data, 'Copy');
            }
            event.preventDefault();
        });

        $('#LookupEdtFormDuplicate').click(function () {
            if (app.ui.IsValid('#LookupEdtForm', false)) {
                app.ui.ButtonDoing('#LookupEdtFormDuplicate');
                var data = MapInputToObject();
                data.LookupId = 0;
                data.Description += ' duplicado';
                app.ui.ButtonDone('#LookupEdtFormDuplicate');
                app.GeneralLookup.EditRow(data);
            }
            event.preventDefault();
        });

        $('#LookupEdtFormDelete').click(function () {
            if (app.ui.IsValid('#LookupEdtForm', false)) {
                app.ui.ButtonDoing('#LookupEdtFormDelete');
                var data = MapInputToObject();
                app.ui.ButtonDone('#LookupEdtFormDelete');
                app.GeneralLookup.DeleteRow(data);
            }
            event.preventDefault();
        });

        $('#LookupEdtFormCancel').click(function () {
            ViewMode();
            event.preventDefault();
        });

    }

    function Create(uidata, mode) {
        app.core.Post(app.setting.apipath + 'v1/Lookup', JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El lookup '" + uidata.Description + "' fue creado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                Refresh();
                switch (mode) {
                    case 'Save':
                        ViewMode();
                        break;
                    case 'Continue':
                        app.GeneralLookup.New();
                        break;
                    case 'Copy':
                        uidata.RoleName += ' copia';
                        app.GeneralLookup.New(uidata);
                        break;
                }
            }).always(function () {
                switch (mode) {
                    case 'Save':
                        app.ui.ButtonDone('#LookupEdtFormSave');
                        break;
                    case 'Continue':
                        app.ui.ButtonDone('#LookupEdtFormSaveContinue');
                        break;
                    case 'Copy':
                        app.ui.ButtonDone('#LookupEdtFormSaveCopy');
                        break;
                }
            });
    }

    function Update(uidata) {
        app.core.Put(app.setting.apipath + 'v1/Lookup/' + uidata.LookupId, JSON.stringify(uidata))
            .done(function (data, textStatus, jqXHR) {
                toastr.success("El lookup '" + uidata.Description + "' fue modificado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                ViewMode();
                Refresh();
            }).always(function () {
                app.ui.ButtonDone('#LookupEdtFormSave');
            });
    }

    function Delete(uidata) {
        toastr.warning("Si está seguro de querer eliminar el lookup '" + uidata.Description + "' haga clic aquí", null,
            {
                timeOut: 5000, closeButton: true, progressBar: true,
                onclick: function () {
                    $('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(app.setting.apipath + 'v1/Lookup/' + uidata.LookupId)
                        .done(function (data, textStatus, jqXHR) {
                            toastr.success("El lookup '" + uidata.Description + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            ViewMode();
                            Refresh();
                        }).always(function () {
                            $('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    }

    function Init_Lookups() {
        app.core.Lookups(['Lenguaje.Language', 'EstadoRegistro.RecordStatus'], Dynamic_Event_Controls);
        // Dependencies
    }

    function Dynamic_Event_Controls() {

    }

    function MapInputToObject() {
        return {
            LookupId: parseInt(0 + $('#LookupId').val(), 10),
            Language: $('#Language').val(),
            ParentLookupId: app.ui.GetNumericValue('#ParentLookupId'),
            SubParentLookupId: app.ui.GetNumericValue('#SubParentLookupId'),
            Code: app.ui.GetNumericValue('#Code'),
            Description: $('#Description').val(),
            QueryOrder: app.ui.GetNumericValue('#QueryOrder'),
            HomologousCode: $('#HomologousCode').val(),
            ExtendNumberValue1: app.ui.GetNumericValue('#ExtendNumberValue1'),
            ExtendNumberValue2: app.ui.GetNumericValue('#ExtendNumberValue2'),
            ExtendStringValue1: $('#ExtendStringValue1').val(),
            ExtendStringValue2: $('#ExtendStringValue2').val(),
            RecordStatus: $('#RecordStatus').val()

        };
    }

    function MapObjectToInput(data) {
        $('#LookupId').val(data.LookupId);
        $('#Language').val(data.Language);
        app.ui.SetNumericValue('#ParentLookupId', data.ParentLookupId);
        app.ui.SetNumericValue('#SubParentLookupId', data.SubParentLookupId);
        app.ui.SetNumericValue('#Code', data.Code);
        $('#Description').val(data.Description);
        app.ui.SetNumericValue('#QueryOrder', data.QueryOrder);
        $('#HomologousCode').val(data.HomologousCode);
        app.ui.SetNumericValue('#ExtendNumberValue1', data.ExtendNumberValue1);
        app.ui.SetNumericValue('#ExtendNumberValue2', data.ExtendNumberValue2);
        $('#ExtendStringValue1').val(data.ExtendStringValue1);
        $('#ExtendStringValue2').val(data.ExtendStringValue2);
        $('#RecordStatus').val(data.RecordStatus);

    }

    function Setup_Validations() {
        app.ui.DateValidators();
        $("#LookupEdtForm").validate({
            errorPlacement: function (error, element) {
                var name = $(element).attr("name");
                var $obj = $("#" + name + "_validate");
                if ($obj.length) {
                    error.appendTo($obj);
                }
                else {
                    error.insertAfter(element);
                }
            },
            rules: {
                Language: {
                    required: true
                },
                ParentLookupId: {
                    required: true
                },
                SubParentLookupId: {
                    required: true
                },
                Code: {
                    required: true
                },
                Description: {
                    required: true
                },
                RecordStatus: {
                    required: true
                }
            },
            messages: {
                Language: {
                    required: 'Debe indicar el lenguaje'
                },
                ParentLookupId: {
                    required: 'Debe indicar el parent lookup id'
                },
                SubParentLookupId: {
                    required: 'Debe indicar el sub parent lookup id'
                },
                Code: {
                    required: 'Debe indicar el código'
                },
                Description: {
                    required: 'Debe indicar el descripción'
                },
                RecordStatus: {
                    required: 'Debe indicar el estado del registro'
                }
            }

        });
    }

    function EditMode(row) {
        $('.filter-row').addClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#LookupGridTbl').parents().find('.table-responsive').addClass('d-none');
        $('#LookupEdt').removeClass('d-none');

        if (row.LookupId === 0) {
			MapObjectToInput(row);
			$('#Description').focus();		
            $('#LookupEdtFormSaveContinue').removeClass('d-none');
            $('#LookupEdtFormSaveCopy').removeClass('d-none');
            $('#LookupEdtFormDuplicate').addClass('d-none');
            $('#LookupEdtFormDelete').addClass('d-none');
			$('#LookupEdtFormSave').removeClass('d-none');
			$('#LookupEdtFormCancel').removeClass('d-none');
        } else {
            $('.ibox-content').toggleClass('sk-loading');		
			app.core.Get(app.setting.apipath + 'v1/Lookup/' + row.LookupId)
				.done(function (data, textStatus, jqXHR) {
					MapObjectToInput(data);
					$('#Description').focus();
					$('#LookupEdtFormSaveContinue').addClass('d-none');
					$('#LookupEdtFormSaveCopy').addClass('d-none');
					$('#LookupEdtFormDuplicate').removeClass('d-none');
					$('#LookupEdtFormDelete').removeClass('d-none');
					$('#LookupEdtFormSave').removeClass('d-none');
					$('#LookupEdtFormCancel').removeClass('d-none');					
				}).always(function () {
                    $('.ibox-content').toggleClass('sk-loading');
				});
        }
    }

    function ViewMode() {
        $('.filter-row').removeClass('d-none');
        $('.advancefilter-row').addClass('d-none');
        $('#LookupGridTbl').parents().find('.table-responsive').removeClass('d-none');
        $('#LookupEdt').addClass('d-none');
        $('.formbtn').addClass('d-none');		
    }

    return {
        Init: function () {
            Init_List();
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Refresh();
            Setup_Validations();
        },
        New: function (row) {
            let newRow = { LookupId: 0, Language: null, ParentLookupId: 0, SubParentLookupId: 0, Code: 0, Description: null, QueryOrder: 0, HomologousCode: null, ExtendNumberValue1: 0, ExtendNumberValue2: 0, ExtendStringValue1: null, ExtendStringValue2: null, RecordStatus: null }
            if (row !== undefined) {
                row.LookupId = 0;
                newRow = row;
            }
            EditMode(newRow);
        },
        EditRow: function (row) {
            EditMode(row);
        },
        DeleteRow: function (row) {
            Delete(row);
        }
    };
})();

window.LookupGridTbl_Events = {
    'click .delete': function (e, value, row, index) {
        app.GeneralLookup.DeleteRow(row);
        e.stopPropagation();
    },
    'click .edit': function (e, value, row, index) {
        app.GeneralLookup.EditRow(row);
        e.stopPropagation();
    }
};
