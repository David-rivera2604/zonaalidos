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
    }

    function setupEvents() {
        $('#MasivosEdtForm').on('submit', function (e) {
            e.preventDefault();
            return false;
        });

        $('#fileUpload').on('change', onFileSelected);

        $('#cod_ramo').on('change', function () {
            state.uploadedFileName = '';
            cleanFileSelection();
        });

        $('#btnGuia').on('click', function (e) {
            e.preventDefault();
            $('#guiaModal').modal('show');
        });

        $('#btnRefrescar').on('click', function (e) {
            e.preventDefault();
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
            uniqueId: 'cod_ramo',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            search: true,
            searchAlign: 'left',
            columns: [
                { field: 'cod_ramo', title: 'C&oacute;digo Ramo', sortable: true, halign: 'center', align: 'center', formatter: 'app.ui.IntegerFormatter' },
                { field: 'txt_archivo_carga', title: 'Archivo', sortable: false, halign: 'center', align: 'left', formatter: 'app.ui.StringFormatter' },
                { field: 'num_tam_archivo', title: 'Tama&ntilde;o', sortable: false, halign: 'center', align: 'center', formatter: function (value) { return value ? (value >= 1024 ? parseInt(value / 1024) + ' KB' : value + ' bytes') : ''; } },
                { field: 'fec_actu', title: 'Fecha Carga', sortable: true, halign: 'center', align: 'center', formatter: 'app.ui.DateAndTimeFormatter' },
                {
                    field: 'archivo_carga', title: 'Descarga CSV', sortable: false, halign: 'center', align: 'center',
                    formatter: function (value, row) {
                        if (!value) return '';
                        return '<button type="button" class="btn btn-xs btn-white" title="Descargar archivo CSV" onclick="app.Masivos.Ui.DescargarCsv(this); return false;" data-content="' + encodeURIComponent(value) + '" data-filename="' + (row.txt_archivo_carga || 'archivo.csv') + '"><i class="fa fa-download"></i> Descargar</button>';
                    }
                },
                {
                    field: 'estado', title: 'Estado', sortable: false, halign: 'center', align: 'center',
                    formatter: function (value) {
                        if (value === 'Procesado') return '<span class="label label-success">Procesado</span>';
                        if (value === 'Error') return '<span class="label label-danger">Error</span>';
                        return '<span class="label label-warning">' + (value || 'Pendiente') + '</span>';
                    }
                },
                {
                    field: 'resultado_proceso', title: 'Resultado', sortable: false, halign: 'center', align: 'center',
                    formatter: function (value, row) {
                        if (!value) return '<span class="text-muted">-</span>';
                        return '<button type="button" class="btn btn-xs btn-white" title="Descargar resultado del proceso" onclick="app.Masivos.Ui.DescargarResultado(this); return false;" data-content="' + encodeURIComponent(value) + '" data-filename="resultado_' + (row.txt_archivo_carga || 'proceso') + '"><i class="fa fa-download"></i> Descargar</button>';
                    }
                }
            ]
        });
    }

    function consultarCargas() {
        $('#masivosTbl').bootstrapTable('showLoading');
        app.Masivos.Api.ConsultarCargas()
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

    function descargarCsv(btn) {
        var content = decodeURIComponent($(btn).data('content'));
        var filename = $(btn).data('filename') || 'archivo.csv';
        if (!filename.toLowerCase().endsWith('.csv')) filename += '.csv';
        var blob = new Blob([content], { type: 'text/csv;charset=utf-8;' });
        var url = URL.createObjectURL(blob);
        var a = document.createElement('a');
        a.href = url;
        a.download = filename;
        a.click();
        a.remove();
        URL.revokeObjectURL(url);
    }

    function descargarResultado(btn) {
        var content = decodeURIComponent($(btn).data('content'));
        var filename = $(btn).data('filename') || 'resultado.csv';
        if (!filename.toLowerCase().endsWith('.csv')) filename += '.csv';
        var blob = new Blob([content], { type: 'text/csv;charset=utf-8;' });
        var url = URL.createObjectURL(blob);
        var a = document.createElement('a');
        a.href = url;
        a.download = filename;
        a.click();
        a.remove();
        URL.revokeObjectURL(url);
    }

    return {
        Init: Init,
        DescargarCsv: descargarCsv,
        DescargarResultado: descargarResultado
    };
})();
