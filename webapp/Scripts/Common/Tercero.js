var app = app || {};

app.Tercero = (function () {

    const elements = {
        // tercerosId: { type: 'hiddennumeric' },
        tipodetercero: { type: 'dropdownnumeric', rules: [{ type: 'required', message: 'Debe indicar el tipo de tercero' }] },
        DocumentNumberType: { type: 'documentnumbertype', change: true },
        DocumentNumber: { type: 'documentnumber', rules: [{ type: 'required', message: 'Debe indicar la identificación' }], settings: { callbackDocType: DocumentTypeCallBack, callbackDone: DocumentNumberCallBack } },
        nombre: { type: 'string', rules: [{ type: 'required', message: 'Debe indicar el nombre' }] },
        apellido1: { type: 'string', rules: [{ type: 'required', message: 'Debe indicar el primer apellido' }] },
        apellido2: { type: 'string', rules: [{ type: 'required', message: 'Debe indicar el segundo apellido' }] },
        fechadenacimiento: { type: 'date', rules: [{ type: 'required', message: 'Debe indicar la fecha de nacimiento' }], settings: { maxDate: app.ui.Yesterday(), date: null } },
        tercerosMca_sexo: { type: 'dropdownnumeric', rules: [{ type: 'required', message: 'Debe indicar el sexo' }] },
        estadoCivil: { type: 'dropdownstring', rules: [{ type: 'required', message: 'Debe indicar el estado civil' }] },
        numerodetelefono: { type: 'phone', rules: [{ type: 'required', message: 'Debe indicar el número de teléfono' }] },
        correoelectronico: { type: 'email', rules: [{ type: 'required', message: 'Debe indicar el correo electrónico' }, { type: 'email', message: 'Debe indicar un correo electrónico valido' }] },

        // Ubicación
        cod_pais: { type: 'dropdownstring', rules: [{ type: 'required', message: 'Debe indicar el país' }], default: 'CRI' },
        TProvinciaHelper: { type: 'typeahead', rules: [{ type: 'required', message: 'Debe indicar la provincia' }] },
        TProvincia: { type: 'dropdownnumeric', rules: [{ type: 'required', message: 'Debe indicar la provincia' }] },
        TCanton: { type: 'dropdownnumeric', rules: [{ type: 'required', message: 'Debe indicar el cantón' }] },
        TDistrito: { type: 'dropdownnumeric', rules: [{ type: 'required', message: 'Debe indicar el distrito' }] },
        otrasenas: { type: 'string', rules: [{ type: 'required', message: 'Debe indicar otra señas' }] },

        // Relaciones
        eltomadoreselmismoasegurado: { type: 'radionumeric', default: 2 },
        elaseguradoeselmismotomador: { type: 'radionumeric', default: 2 },
        elaseguradoeselconductorhabitual: { type: 'radionumeric', default: 2 },
        elaseguradoeselmismopagador: { type: 'radionumeric', default: 2 },

        // Beneficiario (condicional)
        parentesco: { type: 'dropdownnumeric', rules: [{ type: 'required', message: 'Debe indicar el parentesco' }] },
        porcentaje: { type: 'numeric', rules: [{ type: 'required', message: 'Debe indicar el porcentaje' }], settings: { maximumValue: '999' } },

        // Acreedor (condicional)
        numerodeprestamo: { type: 'string' },
        importedecesion: { type: 'numeric', settings: { maximumValue: '999999999999999999', decimalPlaces: 2 } },
        vencimientodecesion: { type: 'date', rules: [{ type: 'required', message: 'Debe indicar el vencimiento de la cesión' }] },
        porcentajeacredor: { type: 'numeric', settings: { maximumValue: '999' } }
    };

    let _config = null;
    let modelHelper = [];
    let _isNew = true;

    function tipodetercero_handler(tipodetercero) {
        switch (tipodetercero) {
            case 0:
                $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().removeClass('d-none');
                $('[name=elaseguradoeselmismotomador]').first().parent().parent().parent().parent().addClass('d-none');
                if (_config.handler.conductorhabitual) {
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().removeClass('d-none');
                }
                $('#beneficiarioZone').addClass('d-none');
                $('#acredorZone').addClass('d-none');
                break;
            case 2:
                $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                $('[name=elaseguradoeselmismotomador]').first().parent().parent().parent().parent().removeClass('d-none');
                if (_config.handler.conductorhabitual) {
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().removeClass('d-none');
                }
                $('#beneficiarioZone').addClass('d-none');
                $('#acredorZone').addClass('d-none');
                break;
            case 3:
                $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                if (_config.handler.conductorhabitual) {
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().addClass('d-none');
                }
                $('#beneficiarioZone').addClass('d-none');
                $('#acredorZone').addClass('d-none');
                break;
            case 6:
                $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                if (_config.handler.conductorhabitual) {
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().addClass('d-none');
                }
                $('#beneficiarioZone').removeClass('d-none');
                $('#acredorZone').addClass('d-none');
                break;
            case 8:
                $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                if (_config.handler.conductorhabitual) {
                    $('[name=elaseguradoeselconductorhabitual]').first().parent().parent().parent().parent().addClass('d-none');
                }
                $('#beneficiarioZone').addClass('d-none');
                $('#acredorZone').removeClass('d-none');
                break;
            case 16:
                $('[name=eltomadoreselmismoasegurado]').first().parent().parent().parent().parent().addClass('d-none');
                $('[name=elaseguradoeselmismotomador]').first().parent().parent().parent().parent().addClass('d-none');
                $('#beneficiarioZone').addClass('d-none');
                $('#acredorZone').addClass('d-none');
                break;
        }

    };
    function Controls_Events() {
        app.ui.DocumentNumberHandler('#DocumentNumber', DocumentNumberCallBack, DocumentTypeCallBack);

        $('#tipodetercero').change(function () {
            tipodetercero_handler($('#tipodetercero').val());
        });

        $('#TProvinciaHelperShow').click(function (e) {
            if (modelHelper.length === 0) {
                app.core.Get(app.setting.apipath + 'v1/datasource/AddressHelper')
                    .done(function (data) {
                        modelHelper = data;
                        let source = [];
                        data.forEach(function (value, index, array) {
                            source.push({ "name": value.DIRECCION, "code": value });
                        });
                        $('#TProvinciaHelper').typeahead({
                            highlight: true,
                            source: source,
                            afterSelect: function (item) {
                                console.log(item);
                                $('#TProvincia').val(item.code.COD_ESTADO);
                                let pais = $('select#cod_pais').val();
                                app.core.LookupDependency(item.code.COD_ESTADO, 'TCanton', 'Cantones', '', item.code.COD_PROV, false, function () {

                                    app.core.LookupDependency(item.code.COD_PROV, 'TDistrito', 'Distritos', '', item.code.COD_LOCALIDAD, false, null, `cod_pais=${pais}:cod_prov=`);

                                }, `cod_pais=${pais}:cod_estado=`);

                                $('.handler-TProvinciaHelper').addClass('d-none');
                                $('.handler-TProvincia').removeClass('d-none');
                            }
                        });
                        $('.handler-TProvinciaHelper').removeClass('d-none');
                        $('.handler-TProvincia').addClass('d-none');

                    })
            } else {
                $('.handler-TProvinciaHelper').removeClass('d-none');
                $('.handler-TProvincia').addClass('d-none');
            }
            e.preventDefault();
        });
        $('#TProvinciaHelperCancel').click(function (e) {
            $('.handler-TProvinciaHelper').addClass('d-none');
            $('.handler-TProvincia').removeClass('d-none');
            e.preventDefault();
        });

        $('#tercerosEdtFormSave').click(function () {
            if (app.ui.IsValid('#tercerosEdtForm', false)) {
                app.ui.ButtonDoing('#tercerosEdtFormSave');

                let current = current_entry_row();

                if (_config.handler.callback != null) {

                    _config.handler.callback(current, _isNew);
                }
                app.ui.ButtonDone('#tercerosEdtFormSave')
                $('#tercerosModal').modal('hide');
            }
        });

        // Dependencies events
        $('#TProvincia').on('change', function () {
            let pais = $('select#cod_pais').val();
            app.core.LookupDependency($('select#TProvincia').val(), 'TCanton', 'Cantones', '', null, true, null, `cod_pais=${pais}:cod_estado=`);
        });

        $('#TCanton').on('change', function () {
            let pais = $('select#cod_pais').val();
            app.core.LookupDependency($('select#TCanton').val(), 'TDistrito', 'Distritos', '', null, false, null, `cod_pais=${pais}:cod_prov=`);
        });
    };

    function empty_row(tipodetercero) {
        let data = app.frm.Empty_Object(elements);
        data.tipodetercero = tipodetercero;
        data.DocumentNumberType = 1;
        return data;
    }

    function current_entry_row() {
        let data = app.frm.DataEntryToObject(elements);
        data.tercerosId = $('#tercerosModal').data('id');
        data.NoEditable = false;
        return data;
    };

    function show_modal_NewEdit(row, tipodetercero, parentesco) {
        var md = $('#tercerosModal').modal({ show: false });
        var formInstance = $("#tercerosEdtForm");
        var fvalidate = formInstance.validate();
        fvalidate.resetForm();

        row = { ...empty_row(tipodetercero), ...row };
        md.data('id', row.tercerosId);

        if (parentesco != null) {
            row.parentesco = parentesco;
        }

        app.frm.ObjectToDataEntry(elements, row);

        if (!_config.handler.tipodetercero) {
            let tipodetercero = app.ui.GetDropDownNumericValue('#tipodetercero');
            let tipodeterceroDesc = app.ui.GetDropDownSelectedText('#tipodetercero');

            $('#terceroTitle').html(`${tipodeterceroDesc}`);
            if (_isNew) {
                $('#terceroSubTitle').html(`Ingrese la información del ${tipodeterceroDesc.toLowerCase()} para ser agregado`);
            } else {
                $('#terceroSubTitle').html(`Ajuste la información del ${tipodeterceroDesc} que desea cambiar`);
            }
            tipodetercero_handler(tipodetercero);
            if (_config.handler.parentescoAseguradoAdicional && tipodetercero === 16) {
                $('.parentescoAseguradoAdicional').removeClass('d-none');
            } else {
                $('.parentescoAseguradoAdicional').addClass('d-none');
            }
        } else {
            $('#terceroSubTitle').html('Información de tercero');
            $('#terceroTitle').html('Permite agregar un nuevo tercero o editar uno existente');
        }


        DocumentTypeCallBack(row.DocumentNumberType);
        app.core.LookupDependency(row.TProvincia, 'TCanton', 'Cantones', '', row.TCanton, false, null, `cod_pais=${row.cod_pais}:cod_estado=`);
        app.core.LookupDependency(row.TCanton, 'TDistrito', 'Distritos', '', row.TDistrito, false, null, `cod_pais=${row.cod_pais}:cod_prov=`);

        md.modal('show');
    }

    function DocumentTypeCallBack(data) {
        data = $("#DocumentNumberType").data("value");
        if (data === 4) {
            $('#apellido1').parent().parent().addClass('d-none');
            $('#apellido2').parent().parent().addClass('d-none');
            $('#fechadenacimiento').parent().parent().parent().addClass('d-none');
            $('#tercerosMca_sexo').parent().parent().addClass('d-none');
            $('#estadoCivil').parent().parent().addClass('d-none');
            $('#nombre').parent().parent().addClass('col-sm-8 col-md-8');

        } else {
            $('#apellido1').parent().parent().removeClass('d-none');
            $('#apellido2').parent().parent().removeClass('d-none');
            $('#fechadenacimiento').parent().parent().parent().removeClass('d-none');
            $('#tercerosMca_sexo').parent().parent().removeClass('d-none');
            $('#estadoCivil').parent().parent().removeClass('d-none');
            $('#nombre').parent().parent().removeClass('col-sm-8 col-md-8');
        }
    }

    function DocumentNumberCallBack(data) {
        if (data != null) {
            $('#nombre').val((data.FirstName + ' ' + data.MiddleName).trim());
            $('#apellido1').val(data.LastName);
            $('#apellido2').val(data.SecondLastName);
            $('#PhoneNumber').val(data.PhoneNumber);
            app.ui.SetDateValue('#fechadenacimiento', data.BirthDate);
            $('#tercerosMca_sexo').val(data.Gender === 2 ? 1 : 0);
            $('#TProvincia').val(data.Province);
            $('#correoelectronico').val(data.PrimaryEmailAddress);
            $('#numerodetelefono').val(data.PhoneNumber);

            let value = data.CivilStatus;
            if (value == '1')
                value = 'C';
            else if (value == '2')
                value = 'D';
            else if (value == '3')
                value = 'S';
            else if (value == '4')
                value = 'V';
            $('#estadoCivil').val(value);

            app.core.LookupDependency(data.Province, 'TCanton', 'Cantones', '', data.Canton, false, null, 'cod_pais=CRI:cod_estado=');
            app.core.LookupDependency(data.Canton, 'TDistrito', 'Distritos', '', data.District, false, null, 'cod_pais=CRI:cod_prov=');

            $('#otrasenas').val(data.AddressDetail);
        }
    }

    return {
        Init: function (options) {
            const conf = {
                handler: {
                    tipodetercero: true,
                    conductorhabitual: true,
                    parentescoAseguradoAdicional: false,
                    callback: null
                }
            };
            _config = { ...conf, ...options };
            if (!_config.handler.tipodetercero) {
                $('#tipodetercero').parent().parent().addClass('d-none');
            }

            app.frm.InitDataEntry(elements, '#tercerosEdtForm');

            Controls_Events();
        },
        NewEdit: function (row, tipodetercero = null, parentesco = null) {
            _isNew = (row === null);
            show_modal_NewEdit(row, tipodetercero, parentesco);
        }
    };
})();