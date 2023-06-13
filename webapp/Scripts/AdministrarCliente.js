var app = app || {};

function clientes_documentNumberCallBack(data) {
    if (data != null) {
        $('#nombre').val((data.FirstName + ' ' + data.MiddleName).trim());
        $('#apellido1').val(data.LastName);
        $('#apellido2').val(data.SecondLastName);
        $('#PhoneNumber').val(data.PhoneNumber);
        app.ui.SetDateValue('#fechadenacimiento', data.BirthDate);
        $('#tercerosMca_sexo').val(data.Gender == 2 ? 1 : 0);
        $('#cod_pais').val('CRI');
        $('#TProvincia').val(data.Province);
        $('#correoelectronico').val(data.PrimaryEmailAddress);
        $('#numerodetelefono').val(data.PhoneNumber);
        $('#estadoCivil').val(data.CivilStatus);

        //function LookupDependency(parentValue, childId, lookupKey, emptyValue, newValue, triggerChange, callback, url) {

        app.core.LookupDependency(data.Province, 'TCanton', 'Cantones', '', data.Canton, false, null, 'cod_pais=CRI:cod_estado=');
        app.core.LookupDependency(data.Canton, 'TDistrito', 'Distritos', '', data.District, false, null, 'cod_pais=CRI:cod_prov=');

        //$('#TCanton').val(data.Canton);
        //$('#TDistrito').val(data.District);
        $('#otrasenas').val(data.AddressDetail);

    }
}

function DocumentNumberTypeMenu() {
    app.ui.DocumentNumberHandler('#DocumentNumber', clientes_documentNumberCallBack);
    app.ui.DocumentNumberHandlerJDC('#DocumentNumber', clientes_documentNumberCallBack);
}

function clientes_controls_setup() {
    $('#DocumentNumber').formatter({
        pattern: '0{{9}}-{{9999}}-{{9999}}',
        persistent: false
    });
    $('#fechadenacimiento_group').datetimepicker({
        format: 'DD/MM/YYYY',
        locale: 'es',
        maxDate: app.ui.Yesterday(),
        date: null

    });
    $('#numerodetelefono').formatter({
        pattern: '{{9999}}-{{9999}}',
        persistent: false
    });
};

function Setup_Validations() {
    $("#clientesEdtForm").validate({
        errorPlacement: app.ui.ErrorPlacement,
        rules: {
            DocumentNumber: { required: true },
            nombre: { required: true },
            apellido1: { required: true },
            apellido2: { required: true },
            fechadenacimiento: { required: true },
            tercerosMca_sexo: { required: true },
            estadoCivil: { required: true },
            numerodetelefono: { required: true },
            correoelectronico: { email: true, required: true },
            TProvincia: { required: true },
            TCanton: { required: true },
            TDistrito: { required: true },
            otrasenas: { required: true }
        },
        messages: {
            DocumentNumber: { required: 'Debe indicar el Número de Documento' },
            nombre: { required: 'Debe indicar el Nombre' },
            apellido1: { required: 'Debe indicar el Primer Apellido' },
            apellido2: { required: 'Debe indicar el Segundo Apellido' },
            fechadenacimiento: { required: 'Debe indicar la Fecha de Nacimiento' },
            tercerosMca_sexo: { required: 'Debe indicar el Sexo' },
            estadoCivil: { required: 'Debe indicar el Estado Cilvil' },
            numerodetelefono: { required: 'Debe indicar el Número de Teléfono' },
            correoelectronico: { email: 'Debe indicar un correo electrónico valido', required: 'Debe indicar el correo electrónico' },
            TProvincia: { required: 'Debe indicar la Provincia' },
            TCanton: { required: 'Debe indicar la Cantón' },
            TDistrito: { required: 'Debe indicar la Distrito' },
            otrasenas: { required: 'Debe indicar Otras Señas' }
        }
    });
};

function Init_Lookups(data) {

    let lookupList = [
        'Paises.cod_pais', 'Provincias.TProvincia', 'Cantones.TCanton', 'Distritos.TDistrito'];
    app.core.Lookups(lookupList, function () {
        MapObjectToInput();
    }, `cod_pais=${data.pais}:TProvincias=${data.Provincias}`);


    // Dependencies events
    $('#TProvincia').on('change', function () {
        var pais = $('select#cod_pais').val();
        app.core.LookupDependency($('select#TProvincia').val(), 'TCanton', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
    });
    $('#TCanton').on('change', function () {
        var pais = $('select#cod_pais').val();
        app.core.LookupDependency($('select#TCanton').val(), 'TDistrito', 'Distritos', '', null, false, null, `cod_pais=${pais}:cod_prov=`);
    });
}

function MapObjectToInput(data) {
};

Init_Lookups({ pais: "CRI", Provincias: 1 })
clientes_controls_setup()
Setup_Validations()
DocumentNumberTypeMenu()




///UPDATE///

function MapInputs() {
    var data = {
        DocumentType: $("#DocumentNumberType").data('value'),
        DocumentNumber: $('#DocumentNumber').val(),
        FirstName: $('#nombre').val(),
        LastName: $('#apellido1').val(),
        SecondLastName: $('#apellido2').val(),
        BirthDate: $('#fechadenacimiento').val(),
        Gender: $('#tercerosMca_sexo').val(),
        CivilStatus: $('#estadoCivil').val(),
        PhoneNumber: $('#numerodetelefono').val(),
        PrimaryEmailAddress: $('#correoelectronico').val(),
        CountryOfNationality: $('#cod_pais').val(),
        Province: $('#TProvincia').val(),
        Canton: $('#TCanton').val(),
        District: $('#TDistrito').val(),
        AddressDetail: $('#otrasenas').val(),
    }
    return data
}

$("#actualizarCambios").click(function () {
    event.preventDefault();
    if (app.ui.IsValid('#clientesEdtForm', false)) {
        $('#actualizarCambios').prop("disabled", true);
        $('#actualizarCambios').html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Guardando Cambios...');
        status = 'redirect';
        var datos = MapInputs();
        app.core.Post(app.setting.apipath + 'v1/Insured/PostCambiosCliente?type=' + datos.DocumentType, JSON.stringify(datos))
            .done(function (data, textStatus, jqXHR) {
                app.core.Get(app.setting.apipath + 'v1/Insured/')
                    .done(function (data, textStatus, jqXHR) {
                        objectlist = data;
                        toastr.success("Cambios actualizados correctamente", '', { timeOut: 3000, closeButton: true, progressBar: true });
                    }).always(function () {
                        if (status === 'redirect') {
                            setTimeout(function () {
                                $('#actualizarCambios').html('<i class="fa fa-check"></i> Listo');
                                setTimeout(function () {
                                    $('#actualizarCambios').html('Actualizar cambios');
                                    $('#actualizarCambios').prop("disabled", false);
                                }, 2000);
                            }, 200);
                        }
                    });
            })
    }
    else {
        var instance = $('#clientesEdtForm');
        var validate = instance.validate();
        validate.settings.ignore = '';
        var count = validate.numberOfInvalids();
        validate.settings.ignore = ':hidden';
        toastr.error("Existen " + (count) + " error(es), que ameritan su atención.", "", { closeButton: true, progressBar: true });
    }
    
})
