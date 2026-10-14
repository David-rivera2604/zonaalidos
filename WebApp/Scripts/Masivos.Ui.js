var app = app || {};

app.Masivos = app.Masivos || {};
app.Masivos.Ui = (function () {
    var state = {
        selectedFile: null,
        uploadedFileName: '',
        rowUpdateId: null,
        progreso: {}
    };

    var POLL_INTERVAL_MS = 15000;
    var MAX_DETALLE_VISIBLE = 20;
    var pollingTimerId = null;

    function Init() {
        app.ui.CommonBehaviour();
        masivos_table_setup();
        ensureUpdateInput();
        ensureProgresoPanel();
        setupEvents();
    }

    function ensureUpdateInput() {
        if ($('#masivoUpdateFile').length === 0) {
            $('body').append('<input id="masivoUpdateFile" type="file" accept=".csv,text/csv" style="display:none;">');
        }
    }

    function ensureProgresoPanel() {
        if ($('#masivosProgresoPanel').length > 0) {
            return;
        }

        var panel = '<div id="masivosProgresoPanel" class="alert alert-info" style="display:none;">' +
            '<i class="fa fa-spinner fa-spin"></i> ' +
            '<span id="masivosProgresoResumen"></span> ' +
            '<button type="button" id="btnToggleProgresoDetalle" class="btn btn-xs btn-link">Ver detalle</button>' +
            '<ul id="masivosProgresoLista" style="display:none; margin:8px 0 0;"></ul>' +
            '</div>';

        $('#masivosTbl').closest('.table-responsive').before(panel);
    }

    function setupEvents() {
        $('#MasivosEdtForm').on('submit', function (e) {
            e.preventDefault();
            return false;
        });

        $('#fileUpload').on('change', onFileSelected);
        $(document).on('change', '#masivoUpdateFile', onUpdateSelected);

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

        $(document).on('click', '#btnToggleProgresoDetalle', function (e) {
            e.preventDefault();
            $('#masivosProgresoLista').toggle();
            $(this).text($('#masivosProgresoLista').is(':visible') ? 'Ocultar detalle' : 'Ver detalle');
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
                    sincronizarProgreso([]);
                } else {
                    var rows = Array.isArray(data) ? data : [];
                    $('#masivosTbl').bootstrapTable('load', rows);
                    sincronizarProgreso(rows);
                }
            })
            .fail(function () {
                $('#masivosTbl').bootstrapTable('load', []);
                sincronizarProgreso([]);
            })
            .always(function () {
                $('#masivosTbl').bootstrapTable('hideLoading');
            });
    }

    function sincronizarProgreso(rows) {
        var idsEnProceso = {};

        (rows || []).forEach(function (row) {
            if (Number(row.cod_estado || 0) === 4) {
                var previo = state.progreso[row.id];
                idsEnProceso[row.id] = { archivo: row.txt_archivo_carga, mensaje: (previo && previo.mensaje) || 'Consultando avance...' };
            }
        });

        state.progreso = idsEnProceso;

        if (Object.keys(state.progreso).length > 0) {
            iniciarPollingGlobal();
            consultarResultadosLote();
        } else {
            detenerPollingGlobal();
        }

        renderProgresoPanel();
    }

    function iniciarPollingGlobal() {
        if (pollingTimerId) return;
        pollingTimerId = setInterval(consultarResultadosLote, POLL_INTERVAL_MS);
    }

    function detenerPollingGlobal() {
        if (pollingTimerId) {
            clearInterval(pollingTimerId);
            pollingTimerId = null;
        }
    }

    function consultarResultadosLote() {
        var ids = Object.keys(state.progreso).map(Number);

        if (ids.length === 0) {
            detenerPollingGlobal();
            return;
        }

        app.Masivos.Api.ConsultarResultados(ids)
            .done(function (data) {
                var items = Array.isArray(data) ? data : [];
                var huboFinalizados = false;

                items.forEach(function (item) {
                    if (!state.progreso[item.id]) return;
                    state.progreso[item.id].mensaje = item.mensaje || 'Procesando...';
                    if (item.finalizado) {
                        huboFinalizados = true;
                        delete state.progreso[item.id];
                    }
                });

                renderProgresoPanel();

                if (huboFinalizados) {
                    consultarCargas();
                } else if (Object.keys(state.progreso).length === 0) {
                    detenerPollingGlobal();
                }
            });
    }

    function renderProgresoPanel() {
        var ids = Object.keys(state.progreso);
        var $panel = $('#masivosProgresoPanel');
        var $resumen = $('#masivosProgresoResumen');
        var $lista = $('#masivosProgresoLista');

        if (ids.length === 0) {
            $panel.hide();
            $lista.empty().hide();
            $('#btnToggleProgresoDetalle').text('Ver detalle');
            return;
        }

        $resumen.text(ids.length + ' archivo(s) en procesamiento. Puede continuar trabajando; haga clic en Refrescar para ver el estado final.');

        var visibles = ids.slice(0, MAX_DETALLE_VISIBLE);
        var html = visibles.map(function (id) {
            var item = state.progreso[id];
            return '<li><strong>' + (item.archivo || ('ID ' + id)) + ':</strong> ' + item.mensaje + '</li>';
        }).join('');

        if (ids.length > MAX_DETALLE_VISIBLE) {
            html += '<li class="text-muted">... y ' + (ids.length - MAX_DETALLE_VISIBLE) + ' archivo(s) más.</li>';
        }

        $lista.html(html);
        $panel.show();
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

    function mostrarAvisoProceso(accion) {
        var mensaje = 'La ' + accion + ' del archivo se está ejecutando y puede tardar unos minutos. ' +
            'Puede continuar trabajando; si desea conocer el avance, haga clic en el botón <strong>Refrescar</strong>.';
        app.ui.ShowAlert('generalNotify', 'alert-info', '<i class="fa fa-info-circle"></i> ' + mensaje);
        toastr.info(mensaje, 'Proceso en curso', { timeOut: 12000, extendedTimeOut: 6000, closeButton: true, progressBar: true });
    }

    function validarMasivo(id) {
        app.ui.ButtonDoing('[data-id="' + id + '"]');
        $('#masivosTbl').bootstrapTable('showLoading');
        mostrarAvisoProceso('validación');

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
        mostrarAvisoProceso('procesamiento');

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
