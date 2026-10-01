var app = app || {};

app.Masivos = app.Masivos || {};
app.Masivos.Ui = (function () {
    var state = {
        selectedFile: null,
        uploadedFileName: '',
        rowUpdateId: null
    };

    function Init() {
        app.ui.CommonBehaviour();
        masivos_table_setup();
        setupEvents();
        ensureUpdateInput();
    }

    function ensureUpdateInput() {
        if ($('#masivoUpdateFile').length === 0) {
            $('body').append('<input id="masivoUpdateFile" type="file" accept=".csv,text/csv" style="display:none;">');
        }
    }

    function setupEvents() {
        $('#MasivosEdtForm').on('submit', function (e) {
            e.preventDefault();
            return false;
        });

        $('#fileUpload').on('change', onFileSelected);
        $('#masivoUpdateFile').on('change', onUpdateSelected);

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

        $('#masivosTbl').on('click', '.btn-validar', function (e) {
            e.preventDefault();
            validarMasivo($(this).data('id'));
        });

        $('#masivosTbl').on('click', '.btn-procesar', function (e) {
            e.preventDefault();
            procesarMasivoPorRegistro($(this).data('id'));
        });

        $('#masivosTbl').on('click', '.btn-actualizar', function (e) {
            e.preventDefault();
            state.rowUpdateId = $(this).data('id');
            $('#masivoUpdateFile').trigger('click');
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
            toastr.error('Solo se permiten archivos con formato .csv', 'Validacion', { timeOut: 9000, closeButton: true, progressBar: true });
            cleanFileSelection();
            return;
        }

        state.selectedFile = file;
        $('#archivoCsv').val(file.name);
        $('#txt_archivo_carga').val(file.name);
    }

    function onUpdateSelected(e) {
        var input = e.target;
        var file = input.files && input.files.length > 0 ? input.files[0] : null;

        if (!file) {
            input.value = '';
            state.rowUpdateId = null;
            return;
        }

        if (!isCsvFile(file.name)) {
            toastr.error('Solo se permiten archivos con formato .csv', 'Validacion', { timeOut: 9000, closeButton: true, progressBar: true });
            input.value = '';
            state.rowUpdateId = null;
            return;
        }

        if (!state.rowUpdateId) {
            toastr.error('Debe seleccionar el registro a actualizar.', 'Validacion', { timeOut: 9000, closeButton: true, progressBar: true });
            input.value = '';
            return;
        }

        actualizarArchivoRegistro(state.rowUpdateId, file);
        input.value = '';
        state.rowUpdateId = null;
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
            toastr.error('Debe seleccionar el código de ramo', 'Validacion', { timeOut: 9000, closeButton: true, progressBar: true });
            return false;
        }

        if (!state.selectedFile) {
            toastr.error('Debe seleccionar un archivo CSV para cargar', 'Validacion', { timeOut: 9000, closeButton: true, progressBar: true });
            return false;
        }

        if (!isCsvFile(state.selectedFile.name)) {
            toastr.error('El archivo seleccionado no tiene formato .csv', 'Validacion', { timeOut: 9000, closeButton: true, progressBar: true });
            return false;
        }

        return true;
    }

    function getEstadoClass(value) {
        var clases = { 1: 'label-info', 2: 'label-danger', 3: 'label-success', 4: 'label-primary', 5: 'label-danger', 6: 'label-success' };
        return clases[Number(value)] || 'label-warning';
    }

    function buildDownloadButton(value, fileName, label) {
        if (!value) {
            return '<span class="text-muted">-</span>';
        }

        return '<button type="button" class="btn btn-xs btn-white" title="Descargar ' + label + '" onclick="app.Masivos.Ui.DescargarCsv(this); return false;" data-content="' + encodeURIComponent(String(value)) + '" data-filename="' + (fileName || 'archivo.csv') + '"><i class="fa fa-download"></i> ' + label + '</button>';
    }

    function masivos_table_setup() {
        $('#masivosTbl').bootstrapTable({
            uniqueId: 'id',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: true,
            smartDisplay: true,
            search: true,
            searchAlign: 'left',
            columns: [
                { field: 'id', title: 'ID', sortable: true, halign: 'center', align: 'center', formatter: 'app.ui.IntegerFormatter' },
                { field: 'cod_ramo', title: 'Código Ramo', sortable: true, halign: 'center', align: 'center', formatter: 'app.ui.IntegerFormatter' },
                { field: 'txt_archivo_carga', title: 'Nombre Archivo', sortable: false, halign: 'center', align: 'left', formatter: 'app.ui.StringFormatter' },
                { field: 'num_tam_archivo', title: 'Tamaño', sortable: false, halign: 'center', align: 'center', formatter: function (value) { return value ? (value >= 1024 ? parseInt(value / 1024) + ' KB' : value + ' bytes') : ''; } },
                { field: 'fec_actu', title: 'Fecha Carga', sortable: true, halign: 'center', align: 'center', formatter: 'app.ui.DateAndTimeFormatter' },
                {
                    field: 'archivo_carga', title: 'Descargar Carga', sortable: false, halign: 'center', align: 'center',
                    formatter: function (value, row) {
                        return buildDownloadButton(value, row.txt_archivo_carga || 'archivo_carga.csv', 'Archivo carga');
                    }
                },
                {
                    field: 'archivo_val', title: 'Descargar Validación', sortable: false, halign: 'center', align: 'center',
                    formatter: function (value, row) {
                        return buildDownloadButton(value, row.txt_archivo_val || 'archivo_validacion.csv', 'Archivo validación');
                    }
                },
                {
                    field: 'archivo_rta', title: 'Descargar Respuesta', sortable: false, halign: 'center', align: 'center',
                    formatter: function (value, row) {
                        return buildDownloadButton(value, row.txt_archivo_rta || 'archivo_respuesta.csv', 'Archivo respuesta');
                    }
                },
                {
                    field: 'cod_estado', title: 'Estado', sortable: false, halign: 'center', align: 'center',
                    formatter: function (value, row) {
                        return '<span class="label ' + getEstadoClass(value) + '">' + (row.estado || '') + '</span>';
                    }
                },
                {
                    field: 'acciones', title: 'Acciones', sortable: false, halign: 'center', align: 'center',
                    formatter: function (value, row) {
                        var estado = Number(row.cod_estado || 0);
                        var botones = [];

                        if (estado === 0) {
                            botones.push('<button type="button" class="btn btn-xs btn-primary btn-validar" data-id="' + row.id + '" title="Validar archivo"><i class="fa fa-check"></i> Validar</button>');
                        }

                        if (estado === 2) {
                            botones.push('<button type="button" class="btn btn-xs btn-warning btn-actualizar" data-id="' + row.id + '" title="Actualizar archivo"><i class="fa fa-upload"></i> Actualizar</button>');
                        }

                        if (estado === 3) {
                            botones.push('<button type="button" class="btn btn-xs btn-success btn-procesar" data-id="' + row.id + '" title="Procesar archivo"><i class="fa fa-gears"></i> Procesar</button>');
                        }

                        if (botones.length === 0) {
                            return '<span class="text-muted">-</span>';
                        }

                        return '<div class="btn-group btn-group-xs" role="group">' + botones.join('') + '</div>';
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
                    $('#masivosTbl').bootstrapTable('load', Array.isArray(data) ? data : []);
                }
            })
            .fail(function () {
                $('#masivosTbl').bootstrapTable('load', []);
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
            .done(function () {
                cleanFileSelection();
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

    function validarMasivo(id) {
        app.ui.ButtonDoing('[data-id="' + id + '"]');
        $('#masivosTbl').bootstrapTable('showLoading');

        app.Masivos.Api.Validar(id)
            .done(function (data) {
                app.ui.ShowAlert('generalNotify', 'alert-success', '<i class="fa fa-check"></i> ' + (data && data.Mensaje ? data.Mensaje : 'Validación ejecutada correctamente.'));
                consultarCargas();
            })
            .fail(function (jqXHR) {
                var message = (jqXHR && jqXHR.responseJSON && (jqXHR.responseJSON.message || jqXHR.responseJSON.Message)) || 'No fue posible validar el archivo.';
                app.ui.ShowAlert('generalNotify', 'alert-danger', message);
            })
            .always(function () {
                $('#masivosTbl').bootstrapTable('hideLoading');
                app.ui.ButtonDone('[data-id="' + id + '"]');
            });
    }

    function procesarMasivoPorRegistro(id) {
        $('#masivosTbl').bootstrapTable('showLoading');

        app.Masivos.Api.Procesar(id)
            .done(function (data) {
                app.ui.ShowAlert('generalNotify', 'alert-success', '<i class="fa fa-check"></i> ' + (data && data.Mensaje ? data.Mensaje : 'Procesamiento ejecutado correctamente.'));
                consultarCargas();
            })
            .fail(function (jqXHR) {
                var message = (jqXHR && jqXHR.responseJSON && (jqXHR.responseJSON.message || jqXHR.responseJSON.Message)) || 'No fue posible procesar la carga masiva.';
                app.ui.ShowAlert('generalNotify', 'alert-danger', message);
            })
            .always(function () {
                $('#masivosTbl').bootstrapTable('hideLoading');
            });
    }

    function actualizarArchivoRegistro(id, file) {
        app.ui.ButtonDoing('.btn-actualizar[data-id="' + id + '"]');
        $('#masivosTbl').bootstrapTable('showLoading');

        app.Masivos.Api.ActualizarArchivo(id, file)
            .done(function (data) {
                app.ui.ShowAlert('generalNotify', 'alert-success', '<i class="fa fa-check"></i> ' + (data && data.Mensaje ? data.Mensaje : 'Archivo actualizado correctamente.'));
                consultarCargas();
            })
            .fail(function (jqXHR) {
                var message = (jqXHR && jqXHR.responseJSON && (jqXHR.responseJSON.message || jqXHR.responseJSON.Message)) || 'No fue posible actualizar el archivo.';
                app.ui.ShowAlert('generalNotify', 'alert-danger', message);
            })
            .always(function () {
                $('#masivosTbl').bootstrapTable('hideLoading');
                app.ui.ButtonDone('.btn-actualizar[data-id="' + id + '"]');
            });
    }

    function descargarCsv(btn) {
        var serializedContent = $(btn).data('content');
        var filename = $(btn).data('filename') || 'archivo.csv';
        if (!filename.toLowerCase().endsWith('.csv')) filename += '.csv';

        var content = serializedContent;

        if (Array.isArray(content)) {
            var bytes = new Uint8Array(content);
            content = new TextDecoder('utf-8').decode(bytes);
        } else if (typeof content === 'string') {
            content = decodeURIComponent(content);

            try {
                var binary = atob(content);
                var bytes = new Uint8Array(binary.length);
                for (var i = 0; i < binary.length; i++) {
                    bytes[i] = binary.charCodeAt(i);
                }
                content = new TextDecoder('utf-8').decode(bytes);
            } catch (e) {
                var tokenized = content.split(',').map(function (part) { return parseInt(part, 10); }).filter(function (n) { return !isNaN(n); });
                if (tokenized.length > 0) {
                    content = new TextDecoder('utf-8').decode(new Uint8Array(tokenized));
                }
            }
        }

        var blob = new Blob([content], { type: 'text/csv;charset=utf-8;' });
        var url = URL.createObjectURL(blob);
        var a = document.createElement('a');
        a.href = url;
        a.download = filename;
        a.click();
        a.remove();
        URL.revokeObjectURL(url);
    }

    function descargarResultado() {
        return null;
    }

    return {
        Init: Init,
        DescargarCsv: descargarCsv,
        DescargarResultado: descargarResultado
    };
})();
