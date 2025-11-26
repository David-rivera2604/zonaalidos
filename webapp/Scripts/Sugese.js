//var app = app || {};

//app.SugeseGenerator = {
//    Init: function () {
//        $("#SugeseGeneratorEdtFormSave").on("click", app.SugeseGenerator.Process);
//        $("#fileUpload").on("change", app.SugeseGenerator.OnFileSelected);
//    },

//    OnFileSelected: function (e) {
//        var file = e.target.files[0];
//        if (!file) return;

//        $("#FileName").val(file.name);
//        $("#Stored").val(file.name);
//        $("#FileSize").val(file.size);
//    },

//    Process: function () {
//        // Validación rápida
//        if (!$("#SugeseGeneratorEdtForm")[0].checkValidity()) {
//            $("#SugeseGeneratorEdtForm")[0].reportValidity();
//            return;
//        }

//        let formData = new FormData();
//        let fileInput = $("#fileUpload")[0].files[0];

//        // Parámetros enviados al servidor MVC
//        formData.append("modelo", $("#ModelType").val());
//        formData.append("pediodoMensual", $("#Month").val());
//        formData.append("ano", $("#Year").val());
//        formData.append("pediodoTrimestral", Math.ceil($("#Month").val() / 3));
//        formData.append("excelFileName", fileInput);
//        formData.append("fileName", $("#FileName").val());

//        let toast;
//        $.ajax({
//            url: app.setting.basepath + "Sugese/ProcesaArchivo",
//            type: "POST",
//            contentType: false,
//            processData: false,
//            data: formData,
//            beforeSend: function () {
//                toast = app.ui.Loader("Procesando archivo, por favor espere...");
//            },
//            success: function (response) {
//                if (response.Success) {
//                    app.ui.Success("XML generado correctamente.");
//                } else {
//                    app.ui.Warning(response.Reason || "Se generaron errores.");
//                }
//            },
//            error: function () {
//                app.ui.Error("Error en la solicitud. Verifique la información.");
//            },
//            complete: function () {
//                toastr.clear(toast);
//            }
//        });
//    }
//};

var app = app || {};
app.generador = (function () {
    Init_Controls = function () {
        app.Attachments.FileUpload({
            controlSelector: "#fileUpload",
            controlName: "FileUpload", 
            done: function (e, data) {
                if (data[0].FileName != '') {
                    $('#fileNameUpload').val(data[0].FileName);
                    $('#fileServerNameUpload').val(data[0].StoredFileName);
                    Reset();
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

    Event_Controls = function () {
        $('#modelo, #pediodo_mensual, #pediodo_trimestral, #ano, #fileNameUpload').change(function () {
            Reset();
        });

        $('#modelo').change(function () {
            $("#NewFile").attr("href", 'download.ashx?t=1&m=' + $('#modelo').val());
            $("#LastExcel").attr("href", 'download.ashx?t=2&m=' + $('#modelo').val());
            $("#LastXml").attr("href", 'download.ashx?t=3&m=' + $('#modelo').val());

            $("#xml").attr("href", 'download.ashx?t=3&m=' + $('#modelo').val());
            $("#xml").text($('#modelo').val() + '.xml');

            $("#xml2").attr("href", 'download.ashx?t=3&m=' + $('#modelo').val());
            $("#xml2").text($('#modelo').val() + '.xml');

            $("#excel").attr("href", 'download.ashx?t=2&m=' + $('#modelo').val());
            $("#excel").text($('#modelo').val() + '.xlsx');

            switch ($('#modelo').val()) {
                case 'BalanceGeneral':
                case 'Canales':
                case 'CuentasTecnicas':
                case 'Patrimonio':
                case 'Produccion':
                case 'Resultados':
                case 'RunOff':
                    $("#periodoLabel").html("Trimestre");
                    $("#pediodo_mensual").hide();
                    $("#div_periodo_mensual").hide();
                    $("#pediodo_trimestral").show();
                    $("#div_pediodo_trimestral").show();
                    $("#pediodo_trimestral").val((new Date().getMonth() + 1) / 3);
                    break;

                default:
                    $("#periodoLabel").html("Mes");
                    $("#pediodo_mensual").show();
                    $("#div_pediodo_mensual").show();
                    $("#pediodo_trimestral").hide();
                    $("#div_pediodo_trimestral").hide();
                    $("#pediodo_mensual").val(new Date().getMonth() + 1);
                    break;
            }
        });

        $('#procesarArchivo').click(function (event) {
            Reset();
            var formInstance = $("#MainForm");
            var fvalidate = formInstance.validate();
            if (formInstance.valid()) {
                if ($('#ano').val() !== '' && $('#fileNameUpload').val() !== '') {
                    $.ajax({
                        type: "POST",
                        url: app.setting.basepath + "Sugese/ProcesaArchivo",
                        contentType: 'application/json',
                        data: JSON.stringify({
                            modelo: $('#modelo').val(),
                            pediodoMensual: $('#pediodo_mensual').val(),
                            pediodoTrimestral: $('#pediodo_trimestral').val(),
                            ano: $('#ano').val(),
                            excelFileName: $('#fileNameUpload').val(),
                            internalFileName: $('#fileServerNameUpload').val(),
                        }),
                        success: function (data) {
                            if (data.Success) {
                                $('#alertSuccess').show();
                            }
                            else {
                                if (data.Code === 100) {
                                    $('#alertError').show();
                                    app.ui.Error(data.Reason);
                                }
                                else
                                    app.ui.Error(data.Reason);
                            }
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            app.ui.Error("Ocurrio une erro");
                        }
                    });
                } else
                    alert("Debe indicar todos los campos requeridos");
            }
            else {
                var count = fvalidate.numberOfInvalids(); 
                app.ui.Error("Existen " + (count ) + " error(es), que ameritan su atención.");
            } 

            event.preventDefault();
        });
    };

    Setup_Validations = function () {
        $("#MainForm").validate({
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
                fileNameUpload: {
                    required: true
                },
                ano: {
                    required: true
                }
            },
            messages: {
                fileNameUpload: {
                    required: 'Debe indicar el archivo a ser procesado'
                },
                ano: {
                    required: 'Debe indicar año para el periodo'
                }
            }
        });
    };

    Reset = function () {
        $('#alertSuccess').hide();
        $('#alertError').hide();
    };

    return {
        Init: function () {
            moment.locale('es');

            Init_Controls();
            Event_Controls();
            Setup_Validations();

            $('#ano').val(new Date().getFullYear());

            $('#modelo').trigger('change');
        }
    }
})();

$(document).ready(function () {
    app.generador.Init();
});