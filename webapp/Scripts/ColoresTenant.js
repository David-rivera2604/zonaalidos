var ListaElementos

//// Cargar el select de aliados////////

//app.core.Get(app.setting.apipath + 'v1/Colors/GetColor')
//    .done(function (data, textStatus, jqXHR) {
//        ListaElementos = data;
//        for (var a in data) {
//            for (var prop in data[a]) {
//                var object = data[a]
//                if (prop == "Tenant") {
//                    $('#tenant').append($('<option>', {
//                        text: object[prop]
//                    }));
//                }
//            }
//        }

//    })


app.core.Get(app.setting.apipath + 'v1/Colors/GetColor')
    .done(function (data, textStatus, jqXHR) {
        ListaElementos = data;
        var addedValues = {}; // objeto para evitar values duplicados
        for (var a in data) {
            if (data[a].hasOwnProperty('Tenant') && data[a].hasOwnProperty('CompanyID')) {
                var Tenant = data[a]['Tenant'];
                var CompanyID = data[a]['CompanyID'];
                if (!addedValues.hasOwnProperty(CompanyID)) { // Si el value no está en el objeto 
                    addedValues[CompanyID] = true; // Agregar el value al objeto 
                    $('#tenant').append($('<option>', {
                        text: Tenant,
                        value: CompanyID
                    }));
                }
            }
        }
    });




//// Cambiar los colores de los inputs segun el alido/////

$("#tenant").on('change', function () {
    var Tenant = $("#tenant option:selected").text()
    for (var a in ListaElementos) {
        for (var prop in ListaElementos[a]) {
            var object = ListaElementos[a]
            if (object[prop] == Tenant) {

                $('#color1').val(object['Color1'])
                $('#color2').val(object['Color2'])
            }
        }
    }

})

/////// obtener sus valores /////////

function MapInputToObject() {

    var data = {
        CompanyID: $("#tenant option:selected").val(),
        Color1: $('#color1').val(),
        Color2: $('#color2').val(),
        Tenant: $("#tenant option:selected").text(),
        Logo: $('#logotenant img').attr("src")
    };
    return data;
};



////// Actualizar cambios realizados /////////////

$("#cambiarcolor").click(function () {
    var datos = MapInputToObject();
    app.core.Post(app.setting.apipath + 'v1/Colors/PostColor', JSON.stringify(datos))
        .done(function (data, textStatus, jqXHR) {
            app.core.Get(app.setting.apipath + 'v1/Colors/GetColor')
                .done(function (data, textStatus, jqXHR) {
                    ListaElementos = data;
                    toastr.success("Cambios actualizados correctamente", '', { timeOut: 7000, closeButton: true, progressBar: true });
                })
        })
})

/// reset todo ////

$("#resetear").click(function () {
    var Tenant = $("#tenant option:selected").text()
    for (var a in ListaElementos) {
        for (var prop in ListaElementos[a]) {
            var object = ListaElementos[a]
            if (object[prop] == Tenant) {
                $('.circulo_preview').css('display', 'none');
                document.getElementById('logotenant').innerHTML = ['<img class="thumb" src= "' + object['Logo'] + '"/>']
                setTimeout(function () { $('.circulo_preview').css('display', 'block'); }, 50)
                input = document.getElementById("formFile");
                var label = input.nextElementSibling
                label.querySelector('span').innerHTML = "Seleccione un Logo";
                $('#color1').val(object['Color1'])
                $('#color2').val(object['Color2'])
            }
        }
    }
    document.documentElement.style.setProperty('--prewiew1', $('#color1').val())
    document.documentElement.style.setProperty('--prewiew2', $('#color2').val())
})


//////cambiar colores "previsualización" tiempo real///////////////

let ColorInput1 = document.getElementById("color1")
ColorInput1.addEventListener("input", e => {

    document.documentElement.style.setProperty('--prewiew1', e.target.value)


})

let ColorInput2 = document.getElementById("color2")
ColorInput2.addEventListener("input", e => {

    document.documentElement.style.setProperty('--prewiew2', e.target.value)

})

///////// cambiar colores y logo dependiendo del tenant en el select ///////////

$("#tenant").on('change', function () {
    var Tenant = $("#tenant option:selected").text()
    for (var a in ListaElementos) {
        for (var prop in ListaElementos[a]) {
            var object = ListaElementos[a]
            if (object[prop] == Tenant) {

                document.getElementById('logotenant').innerHTML = ['<img class="thumb" src= "' + object['Logo'] + '"/>']

            }
        }
    }
    document.documentElement.style.setProperty('--prewiew1', $('#color1').val())
    document.documentElement.style.setProperty('--prewiew2', $('#color2').val())


})

///// animated ///////

$('#tenant').on('change', function (e) {

    $('.preview_page').css('display', 'none');
    setTimeout(function () { $('.preview_page').css('display', 'block'); }, 50)

});


////////////////////////////////////////////////////////////////////////////////

/// carga archivo del input file//////////

function archivo(evt) {
    var files = evt.target.files;

    for (var i = 0, f; f = files[i]; i++) {
        if (!f.type.match('image.*')) {
            toastr.error("No se permiten archivos que no sean imágenes", '', { timeOut: 7000, closeButton: true, progressBar: true });

            continue;
        }

        var reader = new FileReader();

        reader.onload = (function (theFile) {
            return function (e) {
                $('.circulo_preview').css('display', 'none');
                document.getElementById("logotenant").innerHTML = ['<img class="thumb" src="', e.target.result, '"title="', escape(theFile.name), '"/>'].join('');
                setTimeout(function () { $('.circulo_preview').css('display', 'block'); }, 50)
            }
        })(f);

        reader.readAsDataURL(f);
    }
}

document.getElementById('formFile').addEventListener('change', archivo, false);


/////// Función input type file ///////

; (function (document, window, index) {
    var inputs = document.querySelectorAll('.inputfile');
    Array.prototype.forEach.call(inputs, function (input) {
        var label = input.nextElementSibling,
            labelVal = label.innerHTML;

        input.addEventListener('change', function (e) {
            var fileName = '';
            if (this.files && this.files.length > 1)
                fileName = (this.getAttribute('data-multiple-caption') || '').replace('{count}', this.files.length);
            else
                fileName = e.target.value.split('\\').pop();

            if (fileName)
                label.querySelector('span').innerHTML = fileName;
            else
                label.innerHTML = labelVal;
        });
    });
}(document, window, 0));