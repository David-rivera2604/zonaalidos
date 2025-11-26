
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

            let modelo = $('#modelo').val();

            $("#NewFile").attr("href", '#');
            $("#NewFile").attr("onclick", `app.ui.DownloadByName('~/Sugese/plantillas/${modelo}.xlsx')`);

            $("#LastExcel").attr("href", '#');
            $("#LastExcel").attr("onclick", `app.ui.DownloadByName('~/files/${modelo}.xlsx')`); 

            $("#LastXml").attr("href", '#');
            $("#LastXml").attr("onclick", `app.ui.DownloadByName('~/files/${modelo}.xml')`);

            $("#xml").attr("href", '#');
            $("#xml").attr("onclick", `app.ui.DownloadByName('~/files/${modelo}.xml')`);
            $("#xml").text($('#modelo').val() + '.xml');
             
            $("#xml2").attr("href", '#');
            $("#xml2").attr("onclick", `app.ui.DownloadByName('~/files/${modelo}.xml')`);
            $("#xml2").text($('#modelo').val() + '.xml');
             
            $("#excel").attr("href", '#');
            $("#excel").attr("onclick", `app.ui.DownloadByName('~/files/${modelo}.xlsx')`); 
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
                            pediodoTrimestral: $('#pediodo_trimestral').val() || 1, 
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