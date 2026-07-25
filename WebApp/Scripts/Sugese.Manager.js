/* Archivo Sugese.Manager.js - Formulario unificado GeneradorEnvio.cshtml
   ITERACIÓN 3:
   - Selector de modo Generador/Envío (radio "modo"): adapta título, label/accept del archivo,
     color del toggle y textos de ayuda.
   - Toggle Mes/Trimestre según el modelo, carga del archivo y enlaces de descarga.
   - GENERAR ya está conectado a Sugese/ProcesaArchivo.
   - En modo Generador el botón "Enviar a SUGESE" permanece OCULTO hasta que la generación
     termina de forma exitosa; en ese momento aparece.
   - En modo Envío se muestra directamente "Enviar a SUGESE" (aviso si el modelo no tiene
     código de envío confirmado). La conexión del envío al backend se agrega en el siguiente paso.
*/

var app = app || {};
app.sugeseManager = (function () {

    var EXCEL_ACCEPT = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet," +
                       "application/vnd.ms-excel,text/csv";
    var XML_ACCEPT = "text/xml,application/xml,.xml";

    Modo = function () {
        return $('input[name="modo"]:checked').val() || 'generar';
    };

    Init_Controls = function () {
        app.Attachments.FileUpload({
            controlSelector: "#fileUpload",
            controlName: "FileUpload",
            done: function (e, data) {
                if (data[0].FileName != '') {
                    $('#fileNameUpload').val(data[0].FileName);
                    $('#fileServerNameUpload').val(data[0].StoredFileName);
                    ResetAlertas();
                    // Un archivo nuevo invalida una generación previa: se vuelve a ocultar Enviar
                    if (Modo() === 'generar') MostrarEnvio(false);
                } else {
                    app.ui.Error(data.result.error);
                }
            },
            fail: function (e, error) {
                app.ui.Error('Ha ocurrido una falla al tratar de subir el archivo al servidor');
                console.log(e);
            },
            always: function (e) {
                console.log("FINALIZADO", e);
            }
        });
    };

    // Muestra u oculta el botón "Enviar a SUGESE"
    MostrarEnvio = function (mostrar) {
        $('#btnEnviar').toggle(!!mostrar);
    };

    // Descarga directa (sin abrir pestaña ni mostrar el contenido en el navegador):
    // trae el archivo como blob y dispara la descarga con el nombre indicado.
    DescargarDirecto = function (path, downloadName) {
        var url = app.setting.apipath + 'v1/Common/DownloadByName?path=' + encodeURIComponent(path);
        fetch(url, { credentials: 'include' })
            .then(function (r) {
                if (!r.ok) throw new Error('HTTP ' + r.status);
                return r.blob();
            })
            .then(function (blob) {
                var objUrl = URL.createObjectURL(blob);
                var a = document.createElement('a');
                a.href = objUrl;
                a.download = downloadName || path.split('/').pop();
                document.body.appendChild(a);
                a.click();
                document.body.removeChild(a);
                setTimeout(function () { URL.revokeObjectURL(objUrl); }, 1500);
            })
            .catch(function (err) {
                console.log('DescargarDirecto', err);
                app.ui.Error('No se pudo descargar el archivo solicitado.');
            });
    };

    AplicarModo = function () {
        var modo = Modo();
        ResetAlertas();
        // Al cambiar de modo se limpia el archivo cargado (Excel vs XML no son intercambiables)
        $('#fileNameUpload').val('');
        $('#fileServerNameUpload').val('');

        if (modo === 'envio') {
            $('#tituloSeccion').text('Datos para el envío');
            $('#archivoLabel').text('Archivo XML');
            $('#fileUpload').attr('accept', XML_ACCEPT);
            $('#modoCaption').html('<i class="fa fa-info-circle"></i> Modo Envío: suba el archivo XML ya generado para enviarlo a SUGESE.');
            $('#lbl_modo_envio').removeClass('btn-white').addClass('btn-primary');
            $('#lbl_modo_generar').removeClass('btn-primary').addClass('btn-white');

            // En Envío: Generar no aplica; Enviar visible directamente
            $('#btnGenerar').hide();
            MostrarEnvio(true);
        } else {
            $('#tituloSeccion').text('Datos para la generación');
            $('#archivoLabel').text('Archivo Excel');
            $('#fileUpload').attr('accept', EXCEL_ACCEPT);
            $('#modoCaption').html('<i class="fa fa-info-circle"></i> Modo Generador: suba un archivo Excel para generar el XML del modelo seleccionado.');
            $('#lbl_modo_generar').removeClass('btn-white').addClass('btn-primary');
            $('#lbl_modo_envio').removeClass('btn-primary').addClass('btn-white');

            // En Generador: solo Generar; Enviar aparece tras generar con éxito
            $('#btnGenerar').show();
            MostrarEnvio(false);
        }

        // Revalida aviso de "sin código de envío" para el modelo actual
        $('#modelo').trigger('change');
    };

    Event_Controls = function () {
        $('input[name="modo"]').change(function () {
            AplicarModo();
        });

        // Descargas (tarjetas + enlaces de las alertas): descarga directa, sin abrir pestaña
        $('#NewFile, #LastExcel, #LastXml, #xml, #xml2, #excel').on('click', function (event) {
            event.preventDefault();
            var path = $(this).attr('data-path');
            var name = $(this).attr('data-name');
            if (path) DescargarDirecto(path, name);
        });

        // Cualquier cambio en los datos invalida la generación previa (oculta Enviar en modo Generador)
        $('#modelo, #pediodo_mensual, #pediodo_trimestral, #ano, #fileNameUpload').change(function () {
            ResetAlertas();
            if (Modo() === 'generar') MostrarEnvio(false);
        });

        $('#modelo').change(function () {
            let modelo = $('#modelo').val();
            let codigoSugese = $('#modelo option:selected').data('sugese-codigo') || '';

            // Se guardan ruta y nombre de descarga en data-*; el click los usa para descarga directa
            $("#NewFile").attr({ 'data-path': `~/Sugese/plantillas/${modelo}.xlsx`, 'data-name': `${modelo}.xlsx` }).removeAttr('onclick');
            $("#LastExcel").attr({ 'data-path': `~/files/${modelo}.xlsx`, 'data-name': `${modelo}.xlsx` }).removeAttr('onclick');
            $("#LastXml").attr({ 'data-path': `~/files/${modelo}.xml`, 'data-name': `${modelo}.xml` }).removeAttr('onclick');

            $("#xml").attr({ 'data-path': `~/files/${modelo}.xml`, 'data-name': `${modelo}.xml` }).removeAttr('onclick').text(modelo + '.xml');
            $("#xml2").attr({ 'data-path': `~/files/${modelo}.xml`, 'data-name': `${modelo}.xml` }).removeAttr('onclick').text(modelo + '.xml');
            $("#excel").attr({ 'data-path': `~/files/${modelo}.xlsx`, 'data-name': `${modelo}.xlsx` }).removeAttr('onclick').text(modelo + '.xlsx');

            switch (modelo) {
                case 'BalanceGeneral':
                case 'Canales':
                case 'CuentasTecnicas':
                case 'Patrimonio':
                case 'Produccion':
                case 'Resultados':
                case 'RunOff':
                    $("#periodoLabel").html("Trimestre");
                    $("#div_periodo_mensual").hide();
                    $("#div_pediodo_trimestral").show();
                    $("#pediodo_trimestral").val(Math.ceil((new Date().getMonth() + 1) / 3));
                    break;
                default:
                    $("#periodoLabel").html("Mes");
                    $("#div_periodo_mensual").show();
                    $("#div_pediodo_trimestral").hide();
                    $("#pediodo_mensual").val(new Date().getMonth() + 1);
                    break;
            }

            // Aviso solo relevante en modo Envío
            if (Modo() === 'envio' && modelo && !codigoSugese) {
                $("#avisoSinEnvio").show();
                $('#btnEnviar').prop('disabled', true);
            } else {
                $("#avisoSinEnvio").hide();
                $('#btnEnviar').prop('disabled', false);
            }

            ResetAlertas();
        });

        // ===================== GENERAR (conectado al backend) =====================
        $('#btnGenerar').click(function (event) {
            event.preventDefault();
            ResetAlertas();
            MostrarEnvio(false);
            if (!ValidarFormulario()) return;

            $.ajax({
                type: "POST",
                url: app.setting.basepath + "Sugese/ProcesaArchivo",
                contentType: 'application/json',
                data: JSON.stringify({
                    modelo: $('#modelo').val(),
                    pediodoMensual: $('#pediodo_mensual').val(),
                    pediodoTrimestral: $('#pediodo_trimestral').val() || 1,
                    ano: $('#ano').val(),
                    excelFileName: $('#fileNameUpload').val(),
                    internalFileName: $('#fileServerNameUpload').val()
                }),
                success: function (data) {
                    if (data.Success) {
                        $('#alertSuccess').show();
                        // Generación exitosa -> se habilita el envío del XML recién generado
                        MostrarEnvio(true);
                    } else {
                        if (data.Code === 100) {
                            // Se generó pero con fallas de validación: no se habilita el envío
                            $('#alertError').show();
                            app.ui.Error(data.Reason);
                        } else {
                            app.ui.Error(data.Reason);
                        }
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    app.ui.Error("Ocurrió un error al procesar el archivo.");
                }
            });
        });

        // ===================== ENVIAR A SUGESE (con confirmación) =====================
        // El botón abre un modal de confirmación con el resumen; el envío real ocurre al confirmar.
        $('#btnEnviar').click(function (event) {
            event.preventDefault();
            ResetAlertas();
            if (!ValidarFormulario()) return;

            var codigo = $('#modelo option:selected').data('sugese-codigo') || '';
            if (!codigo) {
                $('#avisoSinEnvio').show();
                app.ui.Error('Este modelo no tiene código de envío a SUGESE configurado.');
                return;
            }

            // Resumen en el modal (usa las etiquetas visibles de cada lookup)
            var esTrimestral = $('#div_pediodo_trimestral').is(':visible');
            var periodoTexto = esTrimestral
                ? $('#pediodo_trimestral option:selected').text()
                : $('#pediodo_mensual option:selected').text();

            $('#confModelo').text($('#modelo option:selected').text());
            $('#confPeriodo').text(periodoTexto);
            $('#confAno').text($('#ano').val());
            $('#confArchivo').text($('#fileNameUpload').val());

            $('#confirmEnvioModal').modal('show');
        });

        // Confirmación del modal -> ejecuta el envío real
        $('#btnConfirmarEnvio').click(function (event) {
            event.preventDefault();
            $('#confirmEnvioModal').modal('hide');
            EnviarASugese();
        });
    };

    // Envío real a SUGESE (Sugese/EnviarArchivo). Reutiliza los campos del formulario de Envío:
    // código SUGESE del modelo, periodo (trimestre o mes), año y el XML subido.
    EnviarASugese = function () {
        var codigo = $('#modelo option:selected').data('sugese-codigo') || '';
        if (!codigo) {
            app.ui.Error('Este modelo no tiene código de envío a SUGESE configurado.');
            return;
        }

        var esTrimestral = $('#div_pediodo_trimestral').is(':visible');
        var periodo = esTrimestral
            ? ($('#pediodo_trimestral').val() || 1)
            : ($('#pediodo_mensual').val() || 1);

        $.ajax({
            type: "POST",
            url: app.setting.basepath + "Sugese/EnviarArchivo",
            contentType: 'application/json',
            data: JSON.stringify({
                modelo: codigo,
                periodoMensual: periodo,
                ano: $('#ano').val(),
                xmlFileName: $('#fileNameUpload').val(),
                internalFileName: $('#fileServerNameUpload').val()
            }),
            success: function (data) {
                if (data.Success) {
                    $('#alertEnvioSuccess').show();
                } else {
                    $('#alertEnvioError').show();
                    if (data.Reason) app.ui.Error(data.Reason);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                app.ui.Error("Ocurrió un error al enviar el archivo a SUGESE.");
            }
        });
    };

    ValidarFormulario = function () {
        var formInstance = $("#MainForm");
        var fvalidate = formInstance.validate();
        if (!formInstance.valid()) {
            var count = fvalidate.numberOfInvalids();
            app.ui.Error("Existen " + count + " error(es), que ameritan su atención.");
            return false;
        }
        if ($('#ano').val() === '' || $('#fileNameUpload').val() === '') {
            alert("Debe indicar todos los campos requeridos");
            return false;
        }
        return true;
    };

    Setup_Validations = function () {
        $("#MainForm").validate({
            errorPlacement: function (error, element) {
                var name = $(element).attr("name");
                var $obj = $("#" + name + "_validate");
                if ($obj.length) {
                    error.appendTo($obj);
                } else {
                    error.insertAfter(element);
                }
            },
            rules: {
                modelo: { required: true },
                fileNameUpload: { required: true },
                ano: { required: true }
            },
            messages: {
                modelo: { required: 'Debe indicar el modelo a procesar' },
                fileNameUpload: { required: 'Debe indicar el archivo a ser procesado' },
                ano: { required: 'Debe indicar año para el periodo' }
            }
        });
    };

    ResetAlertas = function () {
        $('#alertSuccess').hide();
        $('#alertError').hide();
        $('#alertEnvioSuccess').hide();
        $('#alertEnvioError').hide();
    };

    return {
        Init: function () {
            moment.locale('es');

            Init_Controls();
            Event_Controls();
            Setup_Validations();

            $('#ano').val(new Date().getFullYear());

            AplicarModo();      // deja el modo inicial (Generador) consistente
        }
    };
})();

$(document).ready(function () {
    app.sugeseManager.Init();
});
