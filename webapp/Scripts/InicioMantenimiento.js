
//////////PONER LOS VALORES EN MANTENIMIENTO///////////
app.core.Get(app.setting.apipath + 'v1/Clientes/GetInicio')
    .done(function (data, textStatus, jqXHR) {

        objectlist = data 

        CompanyId = objectlist.CompanyId

        let titulo1 = objectlist.Titulo1
        let descripcion1 = objectlist.Descripcion1
        let frase1 = objectlist.Frase1
        let link1 = objectlist.Link1
        let img1 = objectlist.Imagen1

        let titulo2 = objectlist.Titulo2
        let descripcion2 = objectlist.Descripcion2
        let frase2 = objectlist.Frase2
        let link2 = objectlist.Link2
        let img2 = objectlist.Imagen2
        
        let titulo3 = objectlist.Titulo3
        let descripcion3 = objectlist.Descripcion3
        let frase3 = objectlist.Frase3
        let link3 = objectlist.Link3
        let img3 = objectlist.Imagen3

        let titulo4 = objectlist.Titulo4
        let descripcion4 = objectlist.Descripcion4
        let frase4 = objectlist.Frase4
        let link4 = objectlist.Link4
        let img4 = objectlist.Imagen4
        

        $('#IM_titulo1').val(titulo1)
        $('#IM_descripcion1').val(descripcion1)
        $('#IM_link1').val(link1)
        $('#IM_frase1').val(frase1)
        if (img1 != null) {
            $('#IM_img1').attr('src', img1);
        } 


        $('#IM_titulo2').val(titulo2)
        $('#IM_descripcion2').val(descripcion2)
        $('#IM_link2').val(link2)
        $('#IM_frase2').val(frase2)
        if (img2 != null) {
            $('#IM_img2').attr('src', img2);
        } 

        $('#IM_titulo3').val(titulo3)
        $('#IM_descripcion3').val(descripcion3)
        $('#IM_link3').val(link3)
        $('#IM_frase3').val(frase3)
        if (img3 != null) {
            $('#IM_img3').attr('src', img3);
        } 

        $('#IM_titulo4').val(titulo4)
        $('#IM_descripcion4').val(descripcion4)
        $('#IM_link4').val(link4)
        $('#IM_frase4').val(frase4)
        if (img4 != null) {
            $('#IM_img4').attr('src', img4);
        } 

       

    })


/////////////////////////MAPEADO Y POST PARA EL UPDATE///////////////////

function MapInputs() {

            var data = {
                CompanyId: CompanyId,
                titulo1: $('#IM_titulo1').val(),
                titulo2: $('#IM_titulo2').val(),
                titulo3: $('#IM_titulo3').val(),
                titulo4: $('#IM_titulo4').val(),
                Descripcion1: $('#IM_descripcion1').val(),
                Descripcion2: $('#IM_descripcion2').val(),
                Descripcion3: $('#IM_descripcion3').val(),
                Descripcion4: $('#IM_descripcion4').val(),
                Frase1: $('#IM_frase1').val(),
                Frase2: $('#IM_frase2').val(),
                Frase3: $('#IM_frase3').val(),
                Frase4: $('#IM_frase4').val(),
                Link1: $('#IM_link1').val(),
                Link2: $('#IM_link2').val(),
                Link3: $('#IM_link3').val(),
                Link4: $('#IM_link4').val(),
                Imagen1: $('#IM_img1').attr("src"),
                Imagen2: $('#IM_img2').attr("src"),
                Imagen3: $('#IM_img3').attr("src"),
                Imagen4: $('#IM_img4').attr("src")

            };
            return data;
}

$("#cambiarInicio").click(function () {
    event.preventDefault();
    $('#cambiarInicio').prop("disabled", true);
    $('#cambiarInicio').html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Guardando Cambios...');
    status = 'redirect';
        var datos = MapInputs();
        app.core.Post(app.setting.apipath + 'v1/Clientes/PostInicio', JSON.stringify(datos))
            .done(function (data, textStatus, jqXHR) {
                app.core.Get(app.setting.apipath + 'v1/Clientes/GetInicio')
                    .done(function (data, textStatus, jqXHR) {
                        objectlist = data;
                        toastr.success("Cambios actualizados correctamente", '', { timeOut: 3000, closeButton: true, progressBar: true });
                    }).always(function () {
                        if (status === 'redirect') {
                            setTimeout(function () {
                                $('#cambiarInicio').html('<i class="fa fa-check"></i> Listo');
                                setTimeout(function () {
                                    $('#cambiarInicio').html('Guardar y aplicar cambios');
                                    $('#cambiarInicio').prop("disabled", false);
                                }, 2000);
                            }, 200);
                        }
                    });
            })
})

/////////////FUNCION DE LOS INPUTS FILE/////////////

function archivo(evt, imgCampo) {
    var files = evt.target.files;

    for (var i = 0, f; f = files[i]; i++) {
        if (!f.type.match('image.*')) {
            toastr.error("No se permiten archivos que no sean imágenes", '', { timeOut: 5000, closeButton: true, progressBar: true });
            continue;
        }

        var reader = new FileReader();

        reader.onload = (function (theFile) {
            return function (e) {
                // mostrar la imagen convertida 
                let imgDataURL = e.target.result;
                $('#' + imgCampo).fadeOut(300, function () {
                    $('#' + imgCampo).attr('src', imgDataURL).fadeIn(300);
                });

                // convertir la imagen en texto
                document.getElementById(imgCampo).innerHTML = ['<img class="thumb" src="', e.target.result, '"title="', escape(theFile.name), '"/>'].join('');

                $('.file-img').change(function () {
                    var input = $(this);
                    var label = input.next('label');
                    var file = input[0].files[0];
                    if (file.type.match('image.*')) {
                        label.text("Imagen Seleccionada");
                        label.next('p').css('display', 'none');
                    } else {
                        label.text("Seleccionar Imagen");
                        label.next('p').css('display', 'block');
                    }
                });
            }
        })(f);

        reader.readAsDataURL(f);
    }
}

document.getElementById('fileimg1').addEventListener('change', function (evt) {
    archivo(evt, 'IM_img1');
}, false);

document.getElementById('fileimg2').addEventListener('change', function (evt) {
    archivo(evt, 'IM_img2');
}, false);

document.getElementById('fileimg3').addEventListener('change', function (evt) {
    archivo(evt, 'IM_img3');
}, false);

document.getElementById('fileimg4').addEventListener('change', function (evt) {
    archivo(evt, 'IM_img4');
}, false);


$(document).ready(function () {
    $('.file-img').change(function () {
        var input = $(this);
        var label = input.next('label');
        label.text("Imagen Seleccionada");
        label.next('p').css('display', 'none');
    });
});