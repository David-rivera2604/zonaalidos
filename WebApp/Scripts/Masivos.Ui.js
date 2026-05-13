var app = app || {};

app.Masivos = app.Masivos || {};
app.Masivos.Ui = (function () {
    var state = {
        selectedFile: null,
        uploadedFileName: ''
    };

    function Init() {
        app.ui.CommonBehaviour();
        masivos_table_setup();
        setupEvents();
        consultarCargas();
    }

    function setupEvents() {
        $('#fileUpload').on('change', onFileSelected);

        $('#cod_ramo').on('change', function () {
            state.uploadedFileName = '';
            cleanFileSelection();
            consultarCargas();
        });

        $('#btnVerPlantillas, #MasivosLinkText').on('click', function (e) {
            e.preventDefault();
            $('#plantillasModal').modal('show');
        });

        $('#btnCargarCsv').on('click', function (e) {
            e.preventDefault();
            cargarCsv();
        });

        $('#btnProcesar').on('click', function (e) {
            e.preventDefault();
            procesarMasivo();
        });
    }

    function onFileSelected(e) {
        var input = e.target;
        var file = input.files && input.files.length > 0 ? input.files[0] : null;

        if (!file) {
            cleanFileSelection();
            return;
        }

        if (!isCsvFile(file.name)) {
            toastr.error('Solo se permiten archivos con formato .csv', 'Validación', { timeOut: 9000, closeButton: true, progressBar: true });
            cleanFileSelection();
            return;
        }

        state.selectedFile = file;
        $('#archivoCsv').val(file.name);
        $('#txt_archivo_carga').val(file.name);
    }

    function isCsvFile(fileName) {
        return !!fileName && fileName.toLowerCase().endsWith('.csv');
    }

    function cleanFileSelection() {
        state.selectedFile = null;
        $('#fileUpload').val('');
        $('#archivoCsv').val('');
        $('#txt_archivo_carga').val('');
    }

    function validateUpload() {
        var codRamo = $('#cod_ramo').val();
        if (!codRamo) {
            toastr.error('Debe seleccionar el código de ramo', 'Validación', { timeOut: 9000, closeButton: true, progressBar: true });
            return false;
        }

        if (!state.selectedFile) {
            toastr.error('Debe seleccionar un archivo CSV para cargar', 'Validación', { timeOut: 9000, closeButton: true, progressBar: true });
            return false;
        }

        if (!isCsvFile(state.selectedFile.name)) {
            toastr.error('El archivo seleccionado no tiene formato .csv', 'Validación', { timeOut: 9000, closeButton: true, progressBar: true });
            return false;
        }

        return true;
    }

    function validateProcess() {
        var codRamo = $('#cod_ramo').val();
        if (!codRamo) {
            toastr.error('Debe seleccionar el código de ramo', 'Validación', { timeOut: 9000, closeButton: true, progressBar: true });
            return false;
        }

        if (!state.uploadedFileName && !state.selectedFile) {
            toastr.error('Debe cargar un archivo CSV antes de procesar', 'Validación', { timeOut: 9000, closeButton: true, progressBar: true });
            return false;
        }

        return true;
    }

    function masivos_table_setup() {
        $('#masivosTbl').bootstrapTable({
            uniqueId: 'Id',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            search: true,
            searchAlign: 'left',
            columns: [
                { field: 'Id', title: 'ID', sortable: true, halign: 'center', align: 'center', formatter: 'app.ui.IntegerFormatter' },
                { field: 'Ramo', title: 'Ramo', sortable: false, halign: 'center', align: 'center', formatter: 'app.ui.StringFormatter' },
                { field: 'Estructura', title: 'Estructura', sortable: false, halign: 'center', align: 'left', formatter: 'app.ui.StringFormatter' },
                { field: 'Archivo', title: 'Archivo', sortable: false, halign: 'center', align: 'left', formatter: 'app.ui.StringFormatter' },
                { field: 'Tamano', title: 'Tamaño', sortable: false, halign: 'center', align: 'center', formatter: function (value) { return value ? parseInt(value / 1024) + 'kb' : ''; } },
                { field: 'Usuario', title: 'Usuario', sortable: false, halign: 'center', align: 'left', formatter: 'app.ui.StringFormatter' },
                { field: 'Fecha', title: 'Fecha', sortable: false, halign: 'center', align: 'center', formatter: 'app.ui.DateAndTimeFormatter' },
                {
                    field: 'Estado', title: 'Estado', sortable: false, halign: 'center', align: 'center',
                    formatter: function (value) {
                        if (value === 'Procesado') return '<span class="label label-success">Procesado</span>';
                        if (value === 'Error') return '<span class="label label-danger">Error</span>';
                        return '<span class="label label-warning">' + (value || 'Pendiente') + '</span>';
                    }
                },
                { field: 'Accion', title: 'Acción', sortable: false, halign: 'center', align: 'center', formatter: 'app.ui.StringFormatter' }
            ]
        });
    }

    function consultarCargas() {
        $('#masivosTbl').bootstrapTable('showLoading');
        app.Masivos.Api.ConsultarCargas($('#cod_ramo').val())
            .done(function (data) {
                if (data != null && data.Mensaje != null) {
                    app.ui.ShowAlert('generalNotify', 'alert-danger', data.Mensaje);
                    $('#masivosTbl').bootstrapTable('load', {});
                } else {
                    if (data != null)
                        $('#masivosTbl').bootstrapTable('load', data);
                    else
                        $('#masivosTbl').bootstrapTable('load', {});
                }
            })
            .fail(function () {
                $('#masivosTbl').bootstrapTable('load', {});
            })
            .always(function () {
                $('#masivosTbl').bootstrapTable('hideLoading');
            });
    }

    function cargarCsv() {
        if (!validateUpload()) {
            return;
        }

        app.ui.ButtonDoing('#btnCargarCsv');
        $('#masivosTbl').bootstrapTable('showLoading');

        app.Masivos.Api.CargarCsv($('#cod_ramo').val(), state.selectedFile)
            .done(function (data) {
                state.uploadedFileName = (data && (data.fileName || data.FileName)) || state.selectedFile.name;
                app.ui.ShowAlert('generalNotify', 'alert-success', '<b><i class="fa fa-check"></i> Archivo CSV cargado correctamente.</b>');
                consultarCargas();
            })
            .fail(function (jqXHR) {
                var message = (jqXHR && jqXHR.responseJSON && (jqXHR.responseJSON.message || jqXHR.responseJSON.Message)) || 'No fue posible cargar el archivo CSV';
                app.ui.ShowAlert('generalNotify', 'alert-danger', message);
            })
            .always(function () {
                $('#masivosTbl').bootstrapTable('hideLoading');
                app.ui.ButtonDone('#btnCargarCsv');
            });
    }

    function procesarMasivo() {
        if (!validateProcess()) {
            return;
        }

        var fileName = state.uploadedFileName || (state.selectedFile ? state.selectedFile.name : '');

        app.ui.ButtonDoing('#btnProcesar');
        $('#masivosTbl').bootstrapTable('showLoading');

        app.Masivos.Api.Procesar($('#cod_ramo').val(), fileName)
            .done(function (data) {
                if (data != null && data.Mensaje != null) {
                    app.ui.ShowAlert('generalNotify', 'alert-danger', data.Mensaje);
                } else {
                    app.ui.ShowAlert('generalNotify', 'alert-success', '<b><i class="fa fa-check"></i> Proceso masivo ejecutado correctamente.</b>');
                }
                consultarCargas();
            })
            .fail(function (jqXHR) {
                var message = (jqXHR && jqXHR.responseJSON && (jqXHR.responseJSON.message || jqXHR.responseJSON.Message)) || 'No fue posible procesar la carga masiva';
                app.ui.ShowAlert('generalNotify', 'alert-danger', message);
            })
            .always(function () {
                $('#masivosTbl').bootstrapTable('hideLoading');
                app.ui.ButtonDone('#btnProcesar');
            });
    }

    return {
        Init: Init
    };
})();
