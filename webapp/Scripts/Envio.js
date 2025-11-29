var app = {};
app.generador = (function () {

    Init_Controls = function () {

        $('#fileUpload').fileupload({
            acceptFileTypes: '/(\\.|\\/)(xml)$/i',
            url: '../FileUploadHandler.ashx',
            dataType: 'json',
            done: function (e, data) {
                $('#fileNameUpload').val(data.result.filename);
                $('#fileServerNameUpload').val(data.result.serverfilename);
                Reset();
            },
            fail: function (e, data) {
                generalSupport.NotifyFail('Ha ocurrido una falla al tratar de subir el archivo al servidor');
                console.log(e);
                console.log(data);
            }
        });

    };

    Event_Controls = function () {

        $('#modelo, #pediodo_mensual, #ano, #fileNameUpload').change(function () {
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
                    $("#pediodo_mensual").val(new Date().getMonth() + 1);
                    break;

                default:
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
                        url: "Envio.aspx/ProcesaArchivo",
                        contentType: 'application/json',
                        data: JSON.stringify({
                            modelo: $('#modelo').val(),
                            pediodoMensual: $('#pediodo_mensual').val(),
                            ano: $('#ano').val(),
                            excelFileName: $('#fileNameUpload').val(),
                            internalFileName: $('#fileServerNameUpload').val(),
                        }),
                        success: function (data) {
                            if (data.d.Success) {
                                $('#alertSuccess').show();
                            }
                            else {
                                if (data.d.Code === 100) {
                                    $('#alertError').show();
                                    generalSupport.NotifyFail(data.d.Reason);
                                }
                                else
                                    generalSupport.NotifyFail(data.d.Reason);
                            }
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            generalSupport.ErrorHandler(jqXHR, textStatus, errorThrown);
                        }
                    });
                } else
                    alert("Debe indicar todos los campos requeridos");
            }
            else
                generalSupport.NotifyErrorValidate(fvalidate);


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

            $('#modelo').trigger('change');
        }
    }
})();

$(document).ready(function () {
    app.generador.Init();
});
