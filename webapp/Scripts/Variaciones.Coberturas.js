// Componente de Coberturas Reutilizable
var app = app || {};

app.CoberturasComponent = (function () {
    let settings = {
        ramo: 0,
        tableId: 'coberturasTbl',
        modalId: 'coberturasNewModal',
        newTableId: 'coberturasNewTbl',
        dataFieldId: 'coberturasData',
        buttonNewId: 'coberturasNew',
        buttonAgregarId: 'agregarCobertura',
        allowAdd: true,
        allowDelete: true,
        onDataChange: null
    };

    let componentData = {
        coberturas: [],
        availableCoverages: [],
        setupData: null
    };

    function init(options) {
        settings = Object.assign(settings, options);
        setupTables();
        setupEvents();
        setupValidations();
    }

    function setupTables() {
        // Tabla principal de coberturas
        $(`#${settings.tableId}`).bootstrapTable({
            uniqueId: 'codigo',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            detailView: false,
            rowStyle: function (value, row, index) {
                let colorFila = (value.codigo === 3016 && !value.added) ? "#FFFFFF" : "#DFFFDE";
                return {
                    css: {
                        'background-color': colorFila
                    }
                }
            },
            columns: [
                {
                    field: 'codigo',
                    title: 'Código',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                },
                {
                    field: 'nombre',
                    title: 'Nombre',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                },
                {
                    field: 'capital',
                    title: 'Capital',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalWithZeroFormatter'
                },
                {
                    field: 'primatotal',
                    title: 'Prima total',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.DecimalWithZeroFormatter'
                },
                {
                    field: 'deducible',
                    title: 'Deducible',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                },
                {
                    field: 'added',
                    title: 'Agregado',
                    halign: 'center',
                    align: 'center',
                    visible: false,
                    formatter: function (value) {
                        return value
                            ? '<i class="fa fa-check-circle text-success"></i>'
                            : '<i class="fa fa-check-circle text-muted"></i>';
                    }
                },
                {
                    field: 'actions',
                    title: 'Acciones',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    events: `${settings.tableId}_Events`,
                    visible: settings.allowDelete,
                    formatter: function (_, row) {
                        if (!settings.allowDelete) return '';

                        let canDelete = false;
                        if (!row.requerida) {
                            canDelete = row.added || !row.seleccionado;
                        }

                        if (row.nombre.includes('EDIF.')) canDelete = false;
                        if (row.nombre.includes('CONT.')) canDelete = false;

                        return canDelete ?
                            '<button type="button" class="btn btn-sm btn-white delete" title="Eliminar cobertura"> <i class="fa fa-close"></i> </button>'
                            : '';
                    }
                }
            ]
        });

        // Tabla de coberturas disponibles
        $(`#${settings.newTableId}`).bootstrapTable({
            uniqueId: 'codigo',
            classes: 'table table-bordered table-hover table-index table-in-form',
            pagination: false,
            smartDisplay: true,
            columns: [
                {
                    field: 'codigo',
                    title: 'Código',
                    sortable: false,
                    halign: 'center',
                    align: 'right',
                    formatter: 'app.ui.IntegerFormatter'
                },
                {
                    field: 'nombre',
                    title: 'Nombre',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: 'app.ui.StringFormatter'
                },
                {
                    field: 'seleccionar',
                    title: 'Seleccione',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    checkbox: true,
                    visible: true
                }
            ]
        });

        $(`#${settings.newTableId}`).on('check.bs.table', function () {
            Coberturas_ManejoDeCapital();
        });
        $(`#${settings.newTableId}`).on('check-all.bs.table', function () {
            Coberturas_ManejoDeCapital();
        });
        $(`#${settings.newTableId}`).on('uncheck.bs.table', function () {
            Coberturas_ManejoDeCapital();
        });
        $(`#${settings.newTableId}`).on('uncheck-all.bs.table', function () {
            Coberturas_ManejoDeCapital();
        });
    }

    function setupEvents() {
        // Botón nuevo
        $(`#${settings.buttonNewId}`).off('click').on('click', function () {
            if (!settings.allowAdd) return;
            $(`#${settings.modalId}`).modal('show');
        });

        // Botón agregar
        $(`#${settings.buttonAgregarId}`).off('click').on('click', function () {
            const selectedRows = $(`#${settings.newTableId}`).bootstrapTable('getSelections');
            const mainTableData = $(`#${settings.tableId}`).bootstrapTable('getData');

            selectedRows.forEach(row => {
                if (validateCoverage(row)) {
                    addCoverage(row, mainTableData);
                }
            });

            $(`#${settings.modalId}`).modal('hide');
            notifyDataChange();
            EnabledControls();
        });

        // Eventos de la tabla principal
        window[`${settings.tableId}_Events`] = {
            'click .delete': function (e, value, row, index) {
                e.stopPropagation();
                toastr.warning(
                    `Si está seguro de querer eliminar la cobertura '${row.nombre}' haga clic aquí`,
                    null,
                    {
                        timeOut: 5000,
                        closeButton: true,
                        progressBar: true,
                        onclick: function () { deleteCoverage(row); }
                    }
                );
            }
        };
    }

    function setupValidations() {
        // Implementar validaciones específicas si es necesario
    }

    function validateCoverage(row) {
        // Validaciones específicas del producto
        let cod_plan_auto_val = $('#hhd-codplanauto').val();

        if (cod_plan_auto_val === "31" && (row.codigo === 3002 || row.codigo === 3003)) {
            toastr.error(
                `La cobertura ${row.nombre} no está permitida para esta póliza`,
                "Mensaje de Validación",
                { timeOut: 9000, closeButton: true, progressBar: true }
            );
            return false;
        }

        return true;
    }

    function addCoverage(row, mainTableData) {
        const exists = mainTableData.some(item => item.codigo === row.codigo);

        if (exists) {
            const rowIndex = $(`#${settings.tableId}`).bootstrapTable('getData').findIndex(r => r.codigo === row.codigo);
            if (rowIndex !== -1) {
                $(`#${settings.tableId}`).bootstrapTable('updateCell', {
                    index: rowIndex,
                    field: 'added',
                    value: true
                });
            }
        } else {
            const newRow = { ...row, added: true, requerida: false };
            $(`#${settings.tableId}`).bootstrapTable('append', newRow);
        }

        $(`#${settings.newTableId}`).bootstrapTable('removeByUniqueId', row.codigo);
        manageUpdateCoberturas(row, "*");
    }

    function deleteCoverage(row) {
        const mainTableData = $(`#${settings.tableId}`).bootstrapTable('getData');
        const exists = mainTableData.find(item => item.codigo === row.codigo);
        let rows2001 = [];
        let rows2009 = [];

        if (exists) {
            if (exists.seleccionado) {
                const rowIndex = $(`#${settings.tableId}`).bootstrapTable('getData').findIndex(r => r.codigo === row.codigo);
                if (rowIndex !== -1) {
                    $(`#${settings.tableId}`).bootstrapTable('updateCell', {
                        index: rowIndex,
                        field: 'added',
                        value: false
                    });
                }
            } else {
                var coberturas = mainTableData;
                const coberturasNewTbl = $(`#${settings.newTableId}`).bootstrapTable('getData');

                if (row.codigo === 2001) {
                    coberturas.filter(r => [2002, 2024, 2025, 2026, 2004].includes(r.codigo)).forEach(function (r, index) {
                        rows2001.push(r);
                        $(`#${settings.tableId}`).bootstrapTable('removeByUniqueId', r.codigo);

                        const existsInNew = coberturasNewTbl.some(item => item.codigo === r.codigo);

                        if (!existsInNew) {
                            r.seleccionado = false;
                            $(`#${settings.newTableId}`).bootstrapTable('append', r);
                        }
                    });
                }

                if (row.codigo === 2009) {
                    coberturas.filter(r => [2010, 2055, 2056, 2057, 2012].includes(r.codigo)).forEach(function (r, index) {
                        rows2009.push(r);
                        $(`#${settings.tableId}`).bootstrapTable('removeByUniqueId', r.codigo);

                        const existsInNew = coberturasNewTbl.some(item => item.codigo === r.codigo);

                        if (!existsInNew) {
                            r.seleccionado = false;
                            $(`#${settings.newTableId}`).bootstrapTable('append', r);
                        }
                    });
                }
                
                $(`#${settings.tableId}`).bootstrapTable('removeByUniqueId', row.codigo);

                const existsInNew = coberturasNewTbl.some(item => item.codigo === row.codigo);

                if (!existsInNew) {
                    row.seleccionado = false;
                    $(`#${settings.newTableId}`).bootstrapTable('append', row);
                }
            }

            if (rows2001.length > 0) {
                rows2001.forEach(function (row, index) {
                    manageUpdateCoberturas(row, "X");
                });
            }

            if (rows2009.length > 0) {
                rows2009.forEach(function (row, index) {
                    manageUpdateCoberturas(row, "X");
                });
            }
            EnabledControls();
            manageUpdateCoberturas(row, "X");
            notifyDataChange();
            Coberturas_ManejoDeCapital();
        }
    }

    function manageUpdateCoberturas(cobertura, action) {
        let coberturasData = $(`#${settings.dataFieldId}`).val();
        let coberturas = JSON.parse(coberturasData || '[]');

        let index = coberturas.findIndex(c => c.codigo === cobertura.codigo);
        if (action === "-") {
            coberturas.splice(index, 1);
        } else {
            if (index !== -1) {
                coberturas[index].mcaSeleccion = action;
            } else {
                cobertura.mcaSeleccion = action;
                coberturas.push(cobertura);
            }
        }

        $(`#${settings.dataFieldId}`).val(JSON.stringify(coberturas));
    }

    function notifyDataChange() {
        if (settings.onDataChange && typeof settings.onDataChange === 'function') {
            const data = $(`#${settings.tableId}`).bootstrapTable('getData');
            settings.onDataChange(data);
        }
    }

    function Coberturas_Seleccionada(lista, codigo) {
        var result = false;
        for (var i = 0; i < lista.length; i++) {
            if (lista[i].codigo == codigo) {
                result = true; // lista[i].seleccionar;
                break;
            }
        }
        return result;
    }

    function CoberturasTable_Seleccionada(lista, codigo) {
        var result = false;
        for (var i = 0; i < lista.length; i++) {
            if (lista[i].codigo == codigo) {
                result = true;
                break;
            }
        }
        return result;
    }

    function Coberturas_ComportamientoDependencia(element, disabled) {
        $(element).prop("disabled", disabled);
        if (disabled) {
            $(element + '-error').html('');
            $(element).removeClass('error');
        }
    };

    function EnabledControls() {
        var coberturas = $(`#${settings.tableId}`).bootstrapTable('getData');

        if (settings.ramo === 201) {
            if (CoberturasTable_Seleccionada(coberturas, 2002) || CoberturasTable_Seleccionada(coberturas, 2024) || CoberturasTable_Seleccionada(coberturas, 2025) || CoberturasTable_Seleccionada(coberturas, 2026) || CoberturasTable_Seleccionada(coberturas, 2004)) {
                Coberturas_ComportamientoDependencia('#sAEdificio', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#sAEdificio', true);
                app.ui.SetNumericValue('#sAEdificio', 0);
            }

            if (CoberturasTable_Seleccionada(coberturas, 2010) || CoberturasTable_Seleccionada(coberturas, 2055) || CoberturasTable_Seleccionada(coberturas, 2056) || CoberturasTable_Seleccionada(coberturas, 2057) || CoberturasTable_Seleccionada(coberturas, 2012) || CoberturasTable_Seleccionada(coberturas, 2014)) {
                if (!localStorage.getItem('Roles').includes('ESPH')) {
                    Coberturas_ComportamientoDependencia('#sAObjetosvaliosos', false);
                }
                //if (poliza_grupo == "2012410199312" || poliza_grupo == "2012410199320") {
                //    Coberturas_ComportamientoDependencia('#sAObjetosvaliosos', true);
                //}
                Coberturas_ComportamientoDependencia('#sAMobiliario', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#sAObjetosvaliosos', true);
                Coberturas_ComportamientoDependencia('#sAMobiliario', true);
                app.ui.SetNumericValue('#sAObjetosvaliosos', 0);
                app.ui.SetNumericValue('#sAMobiliario', 0);
            }

            if (CoberturasTable_Seleccionada(coberturas, 2007)) {
                Coberturas_ComportamientoDependencia('#sADomocristalmarmolgranito', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#sADomocristalmarmolgranito', true);
                app.ui.SetNumericValue('#sADomocristalmarmolgranito', 0);
            }

            if (CoberturasTable_Seleccionada(coberturas, 2017)) {
                Coberturas_ComportamientoDependencia('#sAGastosalquiler', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#sAGastosalquiler', true);
                app.ui.SetNumericValue('#sAGastosalquiler', 0);
            }

            if (CoberturasTable_Seleccionada(coberturas, 2018)) {
                Coberturas_ComportamientoDependencia('#sAPerdidaderentas', false);
                Coberturas_ComportamientoDependencia('#mesesaampararporperdrentas', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#sAPerdidaderentas', true);
                Coberturas_ComportamientoDependencia('#mesesaampararporperdrentas', true);
                app.ui.SetNumericValue('#sAPerdidaderentas', 0);
                app.ui.SetNumericValue('#mesesaampararporperdrentas', 0);
            }

            if (CoberturasTable_Seleccionada(coberturas, 2034)) {
                Coberturas_ComportamientoDependencia('#sARespcivil', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#sARespcivil', true);
                $('#sARespcivil').val(-1);
            }
        }

        if (settings.ramo === 202) {

            if (Coberturas_Seleccionada(coberturas, 2001) ||
                Coberturas_Seleccionada(coberturas, 2002) ||
                Coberturas_Seleccionada(coberturas, 2024) ||
                Coberturas_Seleccionada(coberturas, 2025) ||
                Coberturas_Seleccionada(coberturas, 2026) ||
                Coberturas_Seleccionada(coberturas, 2004)) {
                Coberturas_ComportamientoDependencia('#IMP_EDIFICIO', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#IMP_EDIFICIO', true);
                app.ui.SetNumericValue('#IMP_EDIFICIO', 0);
            }

            if (Coberturas_Seleccionada(coberturas, 2002)) {
                Coberturas_ComportamientoDependencia('#cod_tip_med_inc', false);
                $('[name=MCA_EXTIN_INC]').prop("disabled", false);
                Coberturas_ComportamientoDependencia('#NUM_EXTIN_INC', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#cod_tip_med_inc', true);
                $('[name=MCA_EXTIN_INC]').prop("disabled", true);
                Coberturas_ComportamientoDependencia('#NUM_EXTIN_INC', true);
                $('#cod_tip_med_inc').val(-1);
                $('#NUM_EXTIN_INC').val(-1);
            }


            if (Coberturas_Seleccionada(coberturas, 2008) ||
                Coberturas_Seleccionada(coberturas, 2009) ||
                Coberturas_Seleccionada(coberturas, 2010) ||
                Coberturas_Seleccionada(coberturas, 2055) ||
                Coberturas_Seleccionada(coberturas, 2056) ||
                Coberturas_Seleccionada(coberturas, 2057) ||
                Coberturas_Seleccionada(coberturas, 2012)) {
                Coberturas_ComportamientoDependencia('#IMP_MOBILIARIO', false);
                Coberturas_ComportamientoDependencia('#IMP_MAQUINARIA', false);
                Coberturas_ComportamientoDependencia('#IMP_MERCADERIA', false);
                Coberturas_ComportamientoDependencia('#IMP_BIE_TEM_DES', false);
                Coberturas_ComportamientoDependencia('#IMP_BIE_INT', false);
                Coberturas_ComportamientoDependencia('#IMP_OBJ_ESP_VAL', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#IMP_MOBILIARIO', true);
                Coberturas_ComportamientoDependencia('#IMP_MAQUINARIA', true);
                Coberturas_ComportamientoDependencia('#IMP_MERCADERIA', true);
                Coberturas_ComportamientoDependencia('#IMP_BIE_TEM_DES', true);
                Coberturas_ComportamientoDependencia('#IMP_BIE_INT', true);
                Coberturas_ComportamientoDependencia('#IMP_OBJ_ESP_VAL', true);
                app.ui.SetNumericValue('#IMP_MOBILIARIO', 0);
                app.ui.SetNumericValue('#IMP_MAQUINARIA', 0);
                app.ui.SetNumericValue('#IMP_MERCADERIA', 0);
                app.ui.SetNumericValue('#IMP_BIE_TEM_DES', 0);
                app.ui.SetNumericValue('#IMP_BIE_INT', 0);
                app.ui.SetNumericValue('#IMP_OBJ_ESP_VAL', 0);
            }

            if (Coberturas_Seleccionada(coberturas, 2008) ||
                Coberturas_Seleccionada(coberturas, 2009) ||
                Coberturas_Seleccionada(coberturas, 2010) ||
                Coberturas_Seleccionada(coberturas, 2055) ||
                Coberturas_Seleccionada(coberturas, 2056) ||
                Coberturas_Seleccionada(coberturas, 2057) ||
                Coberturas_Seleccionada(coberturas, 2012) ||
                Coberturas_Seleccionada(coberturas, 2022)) {
                Coberturas_ComportamientoDependencia('#IMP_EQUIP_ELEC', false);
                Coberturas_ComportamientoDependencia('#IMP_EQUIP_ELEC_M', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#IMP_EQUIP_ELEC', true);
                Coberturas_ComportamientoDependencia('#IMP_EQUIP_ELEC_M', true);
                app.ui.SetNumericValue('#IMP_EQUIP_ELEC', 0);
                app.ui.SetNumericValue('#IMP_EQUIP_ELEC_M', 0);
            }

            if (Coberturas_Seleccionada(coberturas, 2008)) {
                Coberturas_ComportamientoDependencia('#cod_tip_med_rob', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#cod_tip_med_rob', true);
                $('#cod_tip_med_rob').val(-1);
            }

            if (Coberturas_Seleccionada(coberturas, 2007)) {
                Coberturas_ComportamientoDependencia('#IMP_DOMOS_TOTAL', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#IMP_DOMOS_TOTAL', true);
                app.ui.SetNumericValue('#IMP_DOMOS_TOTAL', 0);
            }

            if (Coberturas_Seleccionada(coberturas, 2017)) {
                Coberturas_ComportamientoDependencia('#IMP_GAS_ALQ', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#IMP_GAS_ALQ', true);
                app.ui.SetNumericValue('#IMP_GAS_ALQ', 0);
            }

            if (Coberturas_Seleccionada(coberturas, 2018)) {
                Coberturas_ComportamientoDependencia('#IMP_PER_REN', false);
                Coberturas_ComportamientoDependencia('#COB_PDR_MESES', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#IMP_PER_REN', true);
                Coberturas_ComportamientoDependencia('#COB_PDR_MESES', true);
                app.ui.SetNumericValue('#IMP_PER_REN', 0);
                app.ui.SetNumericValue('#COB_PDR_MESES', 0);
            }

            if (Coberturas_Seleccionada(coberturas, 2020)) {
                Coberturas_ComportamientoDependencia('#IMP_MER_TRA', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#IMP_MER_TRA', true);
                app.ui.SetNumericValue('#IMP_MER_TRA', 0);
            }
            if (Coberturas_Seleccionada(coberturas, 2021)) {
                Coberturas_ComportamientoDependencia('#cod_tip_med_rdm', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#cod_tip_med_rdm', true);
                app.ui.SetNumericValue('#cod_tip_med_rdm', 0);
                $("#cod_tip_med_rdm").val(-1);
            }
            if (Coberturas_Seleccionada(coberturas, 2023)) {
                Coberturas_ComportamientoDependencia('#IMP_INT_NEG', false);
                Coberturas_ComportamientoDependencia('#COB_IDN_MESES', false);
                Coberturas_ComportamientoDependencia('#cod_tip_rgo_idn', false);
            }
            else {
                Coberturas_ComportamientoDependencia('#IMP_INT_NEG', true);
                Coberturas_ComportamientoDependencia('#COB_IDN_MESES', true);
                Coberturas_ComportamientoDependencia('#cod_tip_rgo_idn', true);
                app.ui.SetNumericValue('#IMP_INT_NEG', 0);
                app.ui.SetNumericValue('#COB_IDN_MESES', 0);
                // $("#cod_tip_rgo_idn").val(-1);
            }
        }

    }

    function Coberturas_ManejoDeCapital() {
        var coberturas = $(`#${settings.newTableId}`).bootstrapTable('getData');

        if (settings.ramo === 201 || settings.ramo === 202) {
        
            let cob2001Selected = Coberturas_Seleccionada(coberturas, 2001);
            coberturas.filter(r => [2002, 2024, 2025, 2026, 2004].includes(r.codigo)).forEach(function (item, index) {
                item.seleccionar = cob2001Selected;
            });

            let cob2009Selected = Coberturas_Seleccionada(coberturas, 2009);
            coberturas.filter(r => [2010, 2055, 2056, 2057, 2012].includes(r.codigo)).forEach(function (item, index) {
                item.seleccionar = cob2009Selected;
            });

            $(`#${settings.newTableId}`).bootstrapTable('load', coberturas);
            coberturas.forEach(function (value, index) {
                $('[name=btSelectItem][data-index=' + index + ']').prop('disabled',
                    [2002, 2024, 2025, 2026, 2004].includes(value.codigo) || [2010, 2055, 2056, 2057, 2012].includes(value.codigo));
            });
        }       

        $(`#${settings.newTableId}`).bootstrapTable('getData').forEach(function (value, index, array) {
            if (value.requerida) {
                $('[name=btSelectItem][data-index=' + index + ']').prop('disabled', value.requerida);
            }
        });
        $('[name=btSelectAll]').prop('disabled', true);
    };

    // API Pública
    return {
        init: init,
        loadData: function (coberturas) {
            componentData.coberturas = coberturas || [];
            if (coberturas) {
                $(`#${settings.tableId}`).bootstrapTable('load', coberturas);
            }
        },
        loadAvailableCoverages: function (availableCoverages) {
            componentData.availableCoverages = availableCoverages || [];
            if (availableCoverages) {
                $(`#${settings.newTableId}`).bootstrapTable('load', availableCoverages);
                Coberturas_ManejoDeCapital();
                EnabledControls();
            }
        },
        getData: function () {
            return $(`#${settings.tableId}`).bootstrapTable('getData');
        },
        setReadOnly: function (readOnly) {
            settings.allowAdd = !readOnly;
            settings.allowDelete = !readOnly;
            $(`#${settings.buttonNewId}`).prop('disabled', readOnly);
            $(`#${settings.tableId}`).bootstrapTable('showColumn', 'actions');
            if (readOnly) {
                $(`#${settings.tableId}`).bootstrapTable('hideColumn', 'actions');
            }
        },
        destroy: function () {
            $(`#${settings.tableId}`).bootstrapTable('destroy');
            $(`#${settings.newTableId}`).bootstrapTable('destroy');
            delete window[`${settings.tableId}_Events`];
        }
    };
})();