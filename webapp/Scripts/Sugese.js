var app = app || {};

app.SugeseGenerator = {

    Init: function () {
        $("#SugeseGeneratorEdtFormSave").on("click", app.SugeseGenerator.Process);
        $("#fileUpload").on("change", app.SugeseGenerator.OnFileSelected);
    },

    OnFileSelected: function (e) {
        var file = e.target.files[0];
        if (!file) return;

        $("#FileName").val(file.name);
        $("#Stored").val(file.name);
        $("#FileSize").val(file.size);
    },

    Process: function () {

        // Validación rápida
        if (!$("#SugeseGeneratorEdtForm")[0].checkValidity()) {
            $("#SugeseGeneratorEdtForm")[0].reportValidity();
            return;
        }

        let formData = new FormData();
        let fileInput = $("#fileUpload")[0].files[0];

        // Parámetros enviados al servidor MVC
        formData.append("modelo", $("#ModelType").val());
        formData.append("pediodoMensual", $("#Month").val());
        formData.append("ano", $("#Year").val());
        formData.append("pediodoTrimestral", Math.ceil($("#Month").val() / 3));
        formData.append("file", fileInput);
        formData.append("fileName", $("#FileName").val());

        // AJAX
        $.ajax({
            url: "/Sugese/ProcesaArchivo",
            type: "POST",
            contentType: false,
            processData: false,
            data: formData,
            beforeSend: function () {
                app.Utils.Loader.Show("Procesando archivo, por favor espere...");
            },
            success: function (response) {
                if (response.Success) {
                    app.Utils.Alert.Success("XML generado correctamente.");
                } else {
                    app.Utils.Alert.Warning(response.Reason || "Se generaron errores.");
                }
            },
            error: function () {
                app.Utils.Alert.Error("Error en la solicitud. Verifique la información.");
            },
            complete: function () {
                app.Utils.Loader.Hide();
            }
        });
    }

};
