var app = app || {};

app.Funerario = (() => {

    //Validar que el hijo sea menor igual a 17
    //Validar solo 9	CONYUGUE
    //Validar solo 3	HIJO (A)

    const elements = {
        cod_mon: { type: 'dropdownnumeric', default: 1, rules: [{ type: 'required', message: 'Debe indicar la moneda' }] },
        cod_fracc_pago: { type: 'dropdownnumeric', default: 1, rules: [{ type: 'required', message: 'Debe indicar el fraccionamiento de pago' }] },
        fec_efec_poliza: { type: 'date', rules: [{ type: 'required', message: 'Debe indicar el inicio de vigencia' }], settings: { defaultDate: new Date(), minDate: moment().startOf('day') } },
        fec_vcto_poliza: { type: 'date', rules: [{ type: 'required', message: 'Debe indicar el fin de vigencia' }] },

        num_dependientes: { type: 'radionumeric', default: 0 }
    };

    let _quoteSetupData = null;
    let _quoteData = null;
    let _terceros = [];
    let _policyData = null;

    function Setup() {
        app.core.Get(`${app.setting.apipath}v1/Funerario/Quote/Setup`, null,
            function (data) {
                app.core.Lookups(['MonedasPorRamo.cod_mon', 'FrecuenciaDePagoPorRamo.cod_fracc_pago'],
                    function () {
                        _quoteSetupData = data;
                        app.frm.ObjectToDataEntry(elements, data);

                    }, `cod_ramo=${data.cod_ramo}:cod_mon=${data.cod_mon}:cod_agt=${data.cod_agt}`);

            });
    };

    function Controls_Events() {

        $("#VisualizationsEdtForm .input-group.date").on('dp.change', function (e) {
            data_changed();
        });

        $("#VisualizationsEdtForm :input").change(function () {
            data_changed();
        });

        $('#fec_efec_poliza').blur(function () {
            let minDate = app.ui.GetDateRawValue('#fec_efec_poliza');
            minDate.setDate(minDate.getDate());

            const fec_vcto = new Date(minDate);

            fec_vcto.setFullYear(fec_vcto.getFullYear() + 1);
            //Asignacion a vencimiento
            app.ui.SetDateValue('#fec_vcto_poliza', fec_vcto);

        });

        $('#cotizar').click(function (e) {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#cotizar');
                let payload = DataEntryToObject(true);
                _terceros = [];
                app.core.Post(`${app.setting.apipath}v1/Funerario/Quote`,
                    JSON.stringify(payload),
                    function (data) {
                        _quoteData = data;
                        localStorage.setItem("prototype", JSON.stringify(_quoteData))
                        if (!app.ui.NotifyErrors(data.Error, data.Errors, '#VisualizationsEdtForm')) {
                            $('#planes').removeClass('d-none');
                            app.FunerarioPlanes.renderPlans(data);
                        }
                    }).always(function () {
                        app.ui.ButtonDone('#cotizar');
                    });
            }
            e.preventDefault();
        });

        $('#emitir').click(function (e) {
            if (app.ui.IsValid('#VisualizationsEdtForm', false)) {
                app.ui.ButtonDoing('#emitir');
                app.ui.HideAlert('emitirNotify');
                let payload = DataEntryToObject(true);
                payload.terceros = _terceros;
                app.core.Post(`${app.setting.apipath}v1/Funerario/Issue`,
                    JSON.stringify(payload),
                    function (data) {
                        _policyData = data;
                        if (!app.ui.NotifyErrors(data.Error, data.Errors, '#VisualizationsEdtForm', 'emitirNotify')) {
                            $('.change-plan-link').addClass('d-none');
                            $('.gt-action-bar').addClass('d-none');
                            $('.gt-footer-legend').addClass('d-none');
                            $('.gt-btn-edit').addClass('d-none');
                            $('.gt-btn-delete').addClass('d-none');
                            $('#emitir').addClass('d-none');
                            const container = document.getElementById('plans-container');
                            const cards = container.querySelectorAll('.custom-card');
                            for (let i = 0; i < cards.length; i++) {
                                cards[i].querySelector('.btn-custom').innerText = `Póliza #${data.num_poliza}`;
                            }
                            $('.SendEmail').removeClass('d-none');
                        }
                    }).always(function () {
                        app.ui.ButtonDone('#emitir');
                    });
            }
            e.preventDefault();
        });

    };

    function data_changed() {
        $('#planes').addClass('d-none');
    };

    const DataEntryToObject = (quoteMode) => {
        let data = app.frm.DataEntryToObject(elements);
        data.cod_ramo = _quoteSetupData.cod_ramo;
        data.Agente = _quoteSetupData.Agente;
        data.cod_agt = _quoteSetupData.cod_agt;
        data.COD_PLAN_AP = _quoteSetupData.COD_PLAN_AP;

        return data;
    };

    return {
        Init() {
            try {
                app.frm.InitDataEntry(elements, '#VisualizationsEdtForm');

                Controls_Events();
                Setup();

                app.ui.DropDownDisabled('#cod_mon', true, false);
                app.ui.RequiredMark('cod_mon', false);
                app.ui.DropDownDisabled('#cod_fracc_pago', true, false);
                app.ui.RequiredMark('cod_fracc_pago', false);

                app.FunerarioTerceros.Init(function (tercero) {
                    toastr.warning("Si está seguro de querer eliminar el tercero '" + tercero.nombre + "' haga clic aquí", null, {
                        timeOut: 5000, closeButton: true, progressBar: true, onclick: function () {
                            const idx = _terceros.findIndex(t => t.tercerosId === tercero.tercerosId);
                            if (idx !== -1) {
                                _terceros.splice(idx, 1);
                                app.FunerarioTerceros.render(_terceros, _quoteData.num_dependientes);
                            }
                        }
                    });
                });
                app.Tercero.Init({
                    handler: {
                        tipodetercero: false,
                        conductorhabitual: false,
                        parentescoAseguradoAdicional: true,
                        callback: function (data, isNew) {
                            console.log(data);
                            if (isNew) {
                                data.tercerosId = _terceros.length + 1;
                                _terceros.push(data);
                            } else {
                                const index = _terceros.findIndex(t => t.tercerosId === data.tercerosId);
                                if (index !== -1) {
                                    _terceros[index] = data;
                                }
                            }
                            app.FunerarioTerceros.render(_terceros, _quoteData.num_dependientes);
                        }
                    }
                });

            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        },
        Data() {
            return DataEntryToObject(true);
        },
        QuoteData() {
            return _quoteData;
        },
        Terceros() {
            return _terceros;
        },
        EventHandler(name, data) {
            switch (name) {
                case 'PlanSelected':
                    $('.DataGeneralesSeccion').addClass('d-none');
                    $('.aseguradoSeccion').addClass('d-none');
                    _quoteSetupData.COD_PLAN_AP = data;
                    app.FunerarioTerceros.render(_terceros, _quoteData.num_dependientes);
                    app.ui.HideAlert('emitirNotify');
                    break;
                case 'PlanReset':
                    $('.DataGeneralesSeccion').removeClass('d-none');
                    $('.aseguradoSeccion').removeClass('d-none');
                    app.FunerarioTerceros.render([], _quoteData.num_dependientes);
                    app.ui.HideAlert('emitirNotify');
                    break;
                case 'Print':
                    app.ui.ShowSideBar({ title: 'Enviar certificado por correo', subtitle: 'Póliza #{NUM_POLIZA}', id: 9000, data: { NUM_POLIZA: _policyData.num_poliza, NUM_RIESGO: 1 } })
                    break;
            }
        }
    };
})();

app.FunerarioPlanes = (() => {
    // Función para formatear números como moneda costarricense
    function formatCurrency(value) {
        if (value === null || value === undefined) return '₡0,00';
        return '₡' + parseFloat(value).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ' ').replace('.', ',');
    }



    return {
        // Función principal para renderizar planes desde JSON
        renderPlans(jsonData) {
            if (!jsonData || !jsonData.presupuestos || jsonData.presupuestos.length === 0) {
                console.warn('No hay presupuestos disponibles');
                return;
            }

            const container = document.getElementById('plans-container');
            const template = document.getElementById('plan-template');
            const terceros = container.querySelector('.plan-column2'); // Guardamos el div de terceros

            // Limpiar solo los planes, no el div de terceros
            const oldPlans = container.querySelectorAll('.plan-column');
            oldPlans.forEach(plan => plan.remove());

            // Generar cada plan
            jsonData.presupuestos.forEach(function (presupuesto) {
                // Clonar template
                const clone = template.content.cloneNode(true);

                //Asignar click desde JS
                const card = clone.querySelector('.custom-card');
                card.addEventListener('click', function () {
                    app.FunerarioPlanes.handleCardClick(card, presupuesto.Key);
                });

                // Evento del boton de enviar certificado por correo
                let printBtn = clone.getElementById('print');
                printBtn.addEventListener('click', function (e) {
                    e.preventDefault();
                    e.stopPropagation();
                    app.Funerario.EventHandler('Print', presupuesto.Key);
                });

                // Llenar Plan Key
                clone.querySelector('[data-plan-key]').textContent = 'PLAN ' + presupuesto.Key;

                // Llenar Total
                clone.querySelector('[data-total]').textContent = formatCurrency(presupuesto.importetotal);

                // Llenar Breakdown (Prima Neta | IVA)
                const breakdown = 'PRIMA NETA: ' + formatCurrency(presupuesto.primaneta) +
                    ' | IVA: ' + formatCurrency(presupuesto.iVA);
                clone.querySelector('[data-breakdown]').textContent = breakdown;

                // Generar coberturas
                const coverageList = clone.querySelector('[data-coverages]');
                coverageList.innerHTML = ''; // Limpiar

                if (presupuesto.coberturas && presupuesto.coberturas.length > 0) {
                    presupuesto.coberturas.forEach(function (cobertura) {
                        const li = document.createElement('li');
                        li.className = 'coverage-item';

                        const icon = document.createElement('i');
                        icon.className = 'fa fa-check fa-check-item';

                        const div = document.createElement('div');

                        const nameSpan = document.createElement('span');
                        nameSpan.className = 'coverage-name';
                        nameSpan.textContent = cobertura.nombre;

                        const detailsSpan = document.createElement('span');
                        detailsSpan.className = 'coverage-details';

                        let detailsText = '';
                        if (cobertura.capital && cobertura.capital > 0) {
                            detailsText = '(Capital: ' + formatCurrency(cobertura.capital) + ') - ';
                        }
                        detailsText += 'Prima: ' + formatCurrency(cobertura.primatotal);
                        detailsSpan.textContent = detailsText;

                        div.appendChild(nameSpan);
                        div.appendChild(detailsSpan);
                        li.appendChild(icon);
                        li.appendChild(div);
                        coverageList.appendChild(li);
                    });
                }

                // Insertar antes del div de terceros
                container.insertBefore(clone, terceros);
            });
        },
        handleCardClick(cardElement, plan) {
            if (cardElement.classList.contains('selected')) return;

            // 1. Marcar seleccionada
            cardElement.classList.add('selected');
            cardElement.querySelector('.btn-custom').innerText = 'Plan Seleccionado';

            // 2. Ocultar el resto y centrar la elegida
            const allColumns = document.querySelectorAll('.plan-column');
            allColumns.forEach(col => {
                if (!col.contains(cardElement)) {
                    col.classList.add('hidden');
                } else {
                    col.classList.replace('col-lg-4', 'col-lg-3');
                    col.classList.replace('mb-4', 'mb-3');
                }
            });

            const container = document.querySelector('.container-custom');
            container.style.maxWidth = 'none';
            const terceros = container.querySelector('.plan-column2');
            terceros.classList.remove('d-none');

            app.Funerario.EventHandler('PlanSelected', plan);

        },
        resetView(event) {
            event.stopPropagation();

            const allColumns = document.querySelectorAll('.plan-column');
            allColumns.forEach(col => {
                col.classList.remove('hidden');
                col.classList.replace('col-lg-3', 'col-lg-4');
                col.classList.replace('mb-3', 'mb-4');
            });

            const allCards = document.querySelectorAll('.custom-card');
            allCards.forEach(card => {
                card.classList.remove('selected');
                card.querySelector('.btn-custom').innerText = 'Seleccionar Plan';
            });

            const container = document.querySelector('.container-custom');
            container.style.maxWidth = '1180px';
            const terceros = container.querySelector('.plan-column2');
            terceros.classList.add('d-none');
            app.Funerario.EventHandler('PlanReset');
        }
    }
})();

app.FunerarioTerceros = (() => {

    let _callback = null;

    // Función para obtener el prefijo del documento según el tipo
    function getDocumentPrefix(documentNumberType) {
        switch (documentNumberType) {
            case 1: return 'CNA';
            case 2: return 'CED';
            case 3: return 'PAS';
            default: return 'DOC';
        }
    }

    // Función para determinar los badges según el tipo de tercero y flags
    function getTerceroBadges(tercero) {
        var badges = [];

        // Verificar múltiples roles primero
        if (tercero.eltomadoreselmismoasegurado == 1) {
            badges.push({ text: 'Contratante', class: 'gt-bg-contratante' });
            badges.push({ text: 'Asegurado', class: 'gt-bg-asegurado' });
        } else if (tercero.elaseguradoeselmismotomador == 1) {
            badges.push({ text: 'Asegurado', class: 'gt-bg-asegurado' });
            badges.push({ text: 'Contratante', class: 'gt-bg-contratante' });
        } else {
            // Si no hay múltiples roles, usar tipodetercero
            switch (tercero.tipodetercero) {
                case 0:
                    badges.push({ text: 'Contratante', class: 'gt-bg-contratante' });
                    break;
                case 2:
                    badges.push({ text: 'Asegurado', class: 'gt-bg-asegurado' });
                    break;
                case 16:
                    let desc = 'Asegurado adicional';
                    switch (tercero.parentesco) {
                        case 9: desc = 'Conyugue'; break;
                        case 3: desc = 'Hijo(a)'; break;
                    }
                    badges.push({ text: desc, class: 'gt-bg-asegurado-adic' });
                    break;
                case 6:
                    badges.push({ text: 'Beneficiario', class: 'gt-bg-beneficiario' });
                    break;
                default:
                    badges.push({ text: 'Tercero', class: 'gt-bg-contratante' });
            }
        }

        return badges;
    }

    // Función para formatear la ubicación
    function formatLocation(tercero) {
        var parts = [];

        if (tercero.TProvinciaDesc && tercero.TProvinciaDesc.trim() !== '') {
            parts.push(tercero.TProvinciaDesc.trim());
        }
        if (tercero.TCantonDesc && tercero.TCantonDesc.trim() !== '') {
            parts.push(tercero.TCantonDesc.trim());
        }
        if (tercero.TDistritoDesc && tercero.TDistritoDesc.trim() !== '') {
            parts.push(tercero.TDistritoDesc.trim());
        }

        if (parts.length === 0) {
            return 'Ubicación no especificada';
        }

        // Unir con comas y salto de línea después del primer elemento
        if (parts.length >= 2) {
            return parts[0] + ', ' + parts.slice(1).join(', ');
        }
        return parts.join(', ');
    }

    // Función principal para renderizar terceros desde JSON
    function renderTerceros(terceros) {

        var container = document.getElementById('terceros-container');
        // Limpiar contenedor
        container.innerHTML = '';

        if (!terceros || terceros.length === 0) {
            $('.gt-table-header').addClass('d-none');
            $('.gt-table-header').removeClass('d-lg-flex');
            $('.gt-footer-legend').addClass('d-none');
            console.warn('No hay terceros disponibles');
            return;
        }
        $('.gt-table-header').removeClass('d-none');
        $('.gt-table-header').addClass('d-lg-flex');
        $('.gt-footer-legend').removeClass('d-none');


        var template = document.getElementById('tercero-template');

        // Generar cada tercero
        terceros.forEach(function (tercero, index) {
            // Clonar template
            var clone = template.content.cloneNode(true);

            // Generar badges
            var badgesContainer = clone.querySelector('[data-badges]');
            var badges = getTerceroBadges(tercero);
            badges.forEach(function (badge) {
                var span = document.createElement('span');
                span.className = 'gt-badge-pill ' + badge.class;
                span.textContent = badge.text;
                badgesContainer.appendChild(span);
            });

            // Nombre completo
            var fullName = [tercero.nombre, tercero.apellido1, tercero.apellido2]
                .filter(function (part) { return part && part.trim() !== ''; })
                .join(' ');
            clone.querySelector('[data-fullname]').textContent = fullName || 'Sin nombre';

            // Documento
            var docPrefix = getDocumentPrefix(tercero.DocumentNumberType);
            var docNumber = tercero.DocumentNumber || 'No especificado';
            clone.querySelector('[data-document]').textContent = docPrefix + ' ' + docNumber;

            // Teléfono
            var phoneValue = tercero.numerodetelefono || 'No especificado';
            clone.querySelector('[data-phone-value]').textContent = phoneValue;

            // Email
            var emailValue = tercero.correoelectronico || 'No especificado';
            clone.querySelector('[data-email-value]').textContent = emailValue;

            // Ubicación
            var locationText = formatLocation(tercero);
            clone.querySelector('[data-location]').innerHTML = locationText.replace(', ', ',<br>');

            // Eventos de botones
            var editBtn = clone.querySelector('[data-edit]');
            var deleteBtn = clone.querySelector('[data-delete]');

            editBtn.addEventListener('click', function (e) {
                e.preventDefault();
                e.stopPropagation();
                app.Tercero.NewEdit(tercero);
            });

            deleteBtn.addEventListener('click', function (e) {
                e.preventDefault();
                e.stopPropagation();
                onDeleteTercero(tercero, index);
            })

            // Insertar en el contenedor
            container.appendChild(clone);
        });
    }

    // Funciones de callback (puedes personalizarlas según tu necesidad)
    function onEditTercero(e, tercero, index) {
        app.Tercero.NewEdit(tercero);
    }

    function onDeleteTercero(tercero, index) {
        _callback(tercero);
    }

    return {
        Init(callback) {
            _callback = callback;
            app.core.Lookups(['Paises.cod_pais', 'Provincias.TProvincia'], function () { }, `cod_pais=CRI`);

            $('#addcontratante').click(function (e) {
                app.Tercero.NewEdit(null, 0, 0);
                e.preventDefault();
                e.stopPropagation();
            });
            $('#addasegurado').click(function (e) {
                app.Tercero.NewEdit(null, 2, 0);
                e.preventDefault();
                e.stopPropagation();
            });

            $('#addaseguradoadicionalConyugue').click(function (e) {
                app.Tercero.NewEdit(null, 16, 9);
                e.preventDefault();
                e.stopPropagation();
            });

            $('#addaseguradoadicionalHijoa').click(function (e) {
                app.Tercero.NewEdit(null, 16, 3);
                e.preventDefault();
                e.stopPropagation();
            });

            $('#addbeneficiario').click(function (e) {
                app.Tercero.NewEdit(null, 6);
                e.preventDefault();
                e.stopPropagation();
            });

        },
        render(terceros, num_dependientes) {
            renderTerceros(terceros);

            let tomador = terceros.find(e => e.tipodetercero === 0);
            let asegurado = terceros.find(e => e.tipodetercero === 2);

            if (tomador != undefined && tomador.eltomadoreselmismoasegurado === 1 && asegurado === undefined) {
                asegurado = tomador;
            }
            if (asegurado != undefined && asegurado.elaseguradoeselmismotomador === 1 && tomador === undefined) {
                tomador = asegurado;
            }

            if (tomador != undefined) {
                $('#addcontratante').addClass('d-none');
            } else {
                $('#addcontratante').removeClass('d-none');
            }
            if (asegurado != undefined) {
                $('#addasegurado').addClass('d-none');
            } else {
                $('#addasegurado').removeClass('d-none');
            }

            if (asegurado != undefined) {
                let count = 0;
                if (num_dependientes >= 1) {
                    let conyugue = terceros.find(e => e.tipodetercero === 16 && e.parentesco === 9);
                    if (conyugue != undefined) {
                        $('#addaseguradoadicionalConyugue').addClass('d-none');
                        count++;
                    } else {
                        $('#addaseguradoadicionalConyugue').removeClass('d-none');
                    }
                }
                if (num_dependientes >= 1) {
                    let hijoa = terceros.find(e => e.tipodetercero === 16 && e.parentesco === 3);
                    if (hijoa != undefined) {
                        $('#addaseguradoadicionalHijoa').addClass('d-none');
                        count++;
                    } else {
                        $('#addaseguradoadicionalHijoa').removeClass('d-none');
                    }
                }
                if (num_dependientes >= 1 && count === num_dependientes) {
                    $('#addaseguradoadicionalConyugue').addClass('d-none');
                    $('#addaseguradoadicionalHijoa').addClass('d-none');
                }

                $('#addbeneficiario').removeClass('d-none');
            } else {
                $('#addaseguradoadicionalConyugue').addClass('d-none');
                $('#addaseguradoadicionalHijoa').addClass('d-none');
                $('#addbeneficiario').addClass('d-none');
            }
            if (terceros.length === 0) {
                $('#emitir').addClass('d-none');
            } else {
                $('#emitir').removeClass('d-none');
            }
        }
    }
})();