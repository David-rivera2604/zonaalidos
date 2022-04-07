var app = app || {};
var id = 0;
var mode = '';
var cedula;

app.ConsultasGastosMedicos = (function () {

    //var id = 0;
    //var mode = '';
    //var token;
    //var cedula, nombre;
    

    function Controls_Events() {
       
        $('#DocumentNumber').on('blur', function () {

            cedula = $('#DocumentNumber').val().replace(/-/g, '');

            $("#exitoso").attr("hidden", true);
            $("#error").attr("hidden", true);
            $('#DocumentNumber').addClass('loading');
            
            app.core.Get(app.setting.apipath + 'v1/GastosMedicos/' + cedula)
                .done(function (data) {
                    if (data.nombre !== null) {
                        $('#Nombre').val(data.nombre);
                        $('#Apellidos').val(data.apellido);
                        $('#Poliza').val(data.poliza);
                        $('#Certificado').val(data.certificado);
                        $('#InicioVigencia').val(data.fechaInicioVigencia);
                        $('#FinVigencia').val(data.fechaFinVigencia);
                        $('#FechaIngreso').val(data.fechaIngreso);
                        $('#FechaExclusion').val(data.fechaExclusion);

                        if (data.dependientes !== null) {
                            $('#dependientesTbl').bootstrapTable('load', data.dependientes);
                        }
                        else {
                            $('#dependientesTbl').empty();
                        }
                        if (data.beneficios !== null) {
                            $('#beneficiosTbl').bootstrapTable('load', data.beneficios);
                        }
                        else {
                            $('#beneficiosTbl').empty();
                        }
                        
                        $("#exitoso").attr("hidden", false);
                    }
                    else {
                        
                        $('#Nombre').val('');
                        $('#Apellidos').val('');
                        $('#Poliza').val('');
                        $('#Certificado').val('');
                        $('#InicioVigencia').val('');
                        $('#FinVigencia').val('');
                        $('#FechaIngreso').val('');
                        $('#FechaExclusion').val('');
                        $('#dependientesTbl').empty();
                        $('#beneficiosTbl').empty();

                        $("#error").attr("hidden", false);
                    }
                }).always(function () {
                    $('#DocumentNumber').removeClass('loading');
                });
        });
    }

    function dependientes_table_setup() {

        $('#dependientesTbl').bootstrapTable({
            /*uniqueId: 'coberturasId',*/
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'identificacion',
                    title: 'Identficación',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                },
                {
                    field: 'nombre',
                    title: 'Nombre',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                },
                {
                    field: 'fechaNacimiento',
                    title: 'Fecha de Nacimiento',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true
                },]
        });


    }

    function beneficios_table_setup() {

        $('#beneficiosTbl').bootstrapTable({
            /*uniqueId: 'coberturasId',*/
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            detailFormatter: 'app.ui.GenericDetailFormatter',
            columns: [
                {
                    field: 'benef',
                    title: 'Beneficio',
                    titleTooltip: '',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter',
                    visible: true

                },]
        });


    }

    return {
        Init: function () {
            dependientes_table_setup();
            beneficios_table_setup();
            Controls_Events();
        }
    };
})();