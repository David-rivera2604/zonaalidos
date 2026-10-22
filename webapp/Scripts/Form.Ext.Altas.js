var app = app || {};

app.Form_Ext_Altas = (function () {
    // Ajuste temporal para las pruebas integradas locales: core.js solo aplica los catálogos simulados cuando el host es localhost.
    // localStorage.setItem('Lookup.LocalSimulation', 'true');

    let _polizagrupo = null;
    let _proposalId = null;
    let _insuredProposal = null;
    let _agentProposalView = null;

    // Solo el destino autorizado de la invitación habilita el modo de asegurado; una marca residual no bloquea al agente.
    function isInsuredCompletion() {
        return typeof isInsuredCompletionDestination === 'function' && isInsuredCompletionDestination();
    }

    // El generador puede ocultar el botón y su columna con clases distintas; ambos representan la misma acción.
    function setAgentProposalActionVisibility(buttonName, visible) {
        $(`#${buttonName}, .${buttonName}Visible`).toggleClass('d-none', !visible);
    }

    // El cliente solo presenta las acciones de su actor; el servidor vuelve a validarlas con el alcance de invitación.
    function configureWorkflowButtons(insuredCompletion) {
        $('#btnSaveDraft').toggleClass('d-none', false);
        $('#btnComplete').toggleClass('d-none', !insuredCompletion);
        $('#btnSendLink, #btnSendSignature, #btnIssue').toggleClass('d-none', insuredCompletion);
        // No existe una invitación que administrar hasta recuperar una solicitud autorizada del agente.
        setAgentProposalActionVisibility('btnResendLink', false);
        setAgentProposalActionVisibility('btnRevokeLink', false);
        setAgentProposalActionVisibility('btnResumeEditing', false);

        // Un cambio tardío del formulario no puede ocultar acciones que el API ya autorizó para esta solicitud.
        if (!insuredCompletion && _agentProposalView != null) {
            renderAgentProposalStatus(_agentProposalView);
        }
    }

    // Deshabilita los datos comerciales y de riesgo que pertenecen al agente, incluidos los botones auxiliares de fecha.
    function lockInsuredAgentFields() {
        const agentOwnedSelectors = [
            '#RAMO', '#NUM_CONTRATO', '#NUM_POLIZA_GRUPO', '#MONEDA', '#EFEC_SPTO', '#VCTO_SPTO',
            '#NUM_PRESTAMO', '#INI_PRESTAMO', '#VCTO_PRESTAMO', '#IMP_SUM_ASEG_VC', '#IMP_SUMA_ASEG',
            '#IMP_PRIMA_INFORMADA', '#IMP_PRIMA_FACT', '#ID_CRED_ESTUDIANTE', "input[name='MCA_ASISTENCIA']",
            '#IMP_SUMA_MUERTE', '#COD_PLAN_AP'
        ].join(', ');

        $(agentOwnedSelectors).each(function () {
            const control = $(this);
            control.prop('disabled', true);
            control.closest('.form-group').find('input, select, textarea, button').prop('disabled', true);

            if (control.is('select')) {
                control.trigger('change.select2');
            }
        });
    }

    // Bloquea los datos de la solicitud y conserva habilitados solo los comandos de seguimiento autorizados.
    function lockAgentProposalFields() {
        const form = $('#EmitirPolizaEdtForm');
        const allowedActions = '#btnResendLink, #btnRevokeLink, #btnResumeEditing';
        const controls = form.find('input, select, textarea, button').not(allowedActions);

        // Los comandos comparten fieldset con los datos; se guarda el estado original de cada control antes de bloquearlo.
        form.find('fieldset').prop('disabled', false);
        controls.each(function () {
            const control = $(this);
            if (control.data('agentProposalInitialDisabled') === undefined) {
                control.data('agentProposalInitialDisabled', control.prop('disabled'));
            }

            control.prop('disabled', true);
        });
        $(allowedActions).prop('disabled', false);
    }

    // Restaura el estado previo al bloqueo para que retomar una corrección no habilite controles comerciales que ya eran de solo lectura.
    function unlockAgentProposalFields() {
        const form = $('#EmitirPolizaEdtForm');

        form.find('fieldset').prop('disabled', false);
        form.find('input, select, textarea, button').each(function () {
            const control = $(this);
            const initialDisabled = control.data('agentProposalInitialDisabled');
            if (initialDisabled !== undefined) {
                control.prop('disabled', initialDisabled);
                control.removeData('agentProposalInitialDisabled');
            }
        });
    }

    // Actualiza el identificador técnico en la URL del agente sin alterar la URL pública de la invitación.
    function replaceAgentProposalUrl() {
        if (isInsuredCompletion() || !_proposalId) {
            return;
        }

        const url = new URL(window.location.href);
        url.searchParams.set('proposalId', _proposalId);
        window.history.replaceState(null, document.title, url.pathname + url.search);
    }

    // Presenta el estado resuelto por el servidor; el navegador no infiere ni cambia transiciones del flujo.
    function renderAgentProposalStatus(view) {
        _agentProposalView = view;
        const invitation = view.Invitation;
        const detail = invitation == null ? '' : ` Invitación: ${invitation.Status}.`;
        const editable = view.Status === 1;
        $('#proposalWorkflowStatus').val(`Estado de la solicitud: ${view.StatusDesc}.${detail}`);
        $('#EmitirPolizaEdtForm fieldset').prop('disabled', !editable);
        if (editable) {
            unlockAgentProposalFields();
        }
        $('#btnSaveDraft, #btnSendLink, #btnSendSignature, #btnIssue').toggleClass('d-none', !editable);
        $('#btnComplete').addClass('d-none');
        setAgentProposalActionVisibility('btnResendLink', !editable && view.CanResend);
        setAgentProposalActionVisibility('btnRevokeLink', !editable && view.CanRevoke);
        setAgentProposalActionVisibility('btnResumeEditing', !editable && view.CanResumeEditing);

        if (!editable) {
            lockAgentProposalFields();
        }
    }

    // Recupera una solicitud del agente mediante su clave técnica y deja el servidor decidir las acciones disponibles.
    function loadAgentProposal() {
        const proposalId = app.core.URLNumericValue('proposalId');
        if (!proposalId || isInsuredCompletion()) {
            return;
        }

        app.core.Get(app.setting.apipath + 'v1/PolicyProposals/' + proposalId)
            .done(function (view) {
                if (view == null || !view.Id || !view.ProposalData) {
                    app.ui.Error('La solicitud no está disponible para seguimiento.');
                    return;
                }

                _proposalId = view.Id;
                const proposal = JSON.parse(view.ProposalData);
                app.EmitirPoliza.SetData(proposal);
                if (!setStoredContractOption(proposal)) {
                    app.ui.Error('La solicitud almacenada no contiene un contrato válido. Corríjala antes de continuar.');
                    return;
                }
                // La restauración del asignador genérico no reconstruye tablas ni catálogos dependientes.
                // El agente debe recuperar la misma instantánea completa que preparó antes de guardar o enviar.
                restoreInsuredDependentFields(proposal);
                renderAgentProposalStatus(view);
            });
    }

    // Ejecuta un comando de seguimiento y siempre vuelve a consultar la vista autorizada por el servidor.
    function postAgentProposalCommand(path, body, buttonSelector, message) {
        if (!_proposalId) {
            return;
        }

        app.ui.ButtonDoing(buttonSelector);
        app.core.Post(app.setting.apipath + 'v1/PolicyProposals/' + _proposalId + path, JSON.stringify(body || {}))
            .done(function (view) {
                app.ui.Success(message);
                renderAgentProposalStatus(view);
            }).always(function () {
                app.ui.ButtonDone(buttonSelector);
            });
    }

    // Construye un diálogo local para comandos de seguimiento sin reutilizar el formulario completo de la solicitud.
    function createAgentCommandModal(id, title, body, confirmCaption) {
        const modal = $('<div />', { id: id, role: 'dialog', 'aria-modal': 'true' }).addClass('modal fade dynamicModal');
        const dialog = $('<div />').addClass('modal-dialog modal-dialog-centered');
        const content = $('<div />').addClass('modal-content');
        const header = $('<div />').addClass('modal-header')
            .append($('<h4 />').text(title))
            .append($('<button />', { type: 'button', 'aria-label': 'Cerrar' }).addClass('close').attr('data-dismiss', 'modal').html('&times;'));
        const footer = $('<div />').addClass('modal-footer')
            .append($('<button />', { type: 'button', text: 'Cancelar' }).addClass('btn btn-default').attr('data-dismiss', 'modal'))
            .append($('<button />', { type: 'button', text: confirmCaption }).addClass('btn btn-primary agent-command-confirm'));

        content.append(header).append($('<div />').addClass('modal-body').append(body)).append(footer);
        dialog.append(content);
        modal.append(dialog);
        $('body').append(modal);
        modal.on('hidden.bs.modal', function () { modal.remove(); });
        return modal;
    }

    // Solicita solamente el correo permitido antes de reemplazar la invitación y su enlace anterior.
    function showResendInvitationModal() {
        // Se asigna autocomplete como atributo para no invocar el complemento jquery-ui con el mismo nombre.
        const email = $('<input />', { id: 'resendInvitationEmail', type: 'email', maxlength: 320 })
            .attr('autocomplete', 'email')
            .addClass('form-control')
            .val($('#EMAIL_ASEG').val() || '');
        const body = $('<div />')
            .append($('<p />').text('El enlace anterior será invalidado. Solo puede cambiar el correo del asegurado.'))
            .append($('<label />', { for: 'resendInvitationEmail', text: 'Correo electrónico del asegurado' }))
            .append(email);
        const modal = createAgentCommandModal('resendInvitationModal', 'Reenviar enlace', body, 'Reenviar enlace');

        modal.find('.agent-command-confirm').on('click', function () {
            const recipientEmail = email.val().trim();
            if (!recipientEmail) {
                email.addClass('is-invalid').focus();
                return;
            }

            modal.modal('hide');
            postAgentProposalCommand('/Invitation/Resend', { RecipientEmail: recipientEmail }, '#btnResendLink', 'La invitación fue reenviada al asegurado.');
        });
        modal.modal('show');
    }

    // Permite registrar un motivo breve sin incorporarlo a la instantánea del formulario ni a los datos del asegurado.
    function showRevokeInvitationModal() {
        const reason = $('<textarea />', { id: 'revokeInvitationReason', maxlength: 200, rows: 3 })
            .addClass('form-control');
        const body = $('<div />')
            .append($('<p />').text('El enlace activo y cualquier sesión asociada quedarán invalidados.'))
            .append($('<label />', { for: 'revokeInvitationReason', text: 'Motivo de anulación (opcional)' }))
            .append(reason);
        const modal = createAgentCommandModal('revokeInvitationModal', 'Anular enlace', body, 'Anular enlace');

        modal.find('.agent-command-confirm').on('click', function () {
            modal.modal('hide');
            postAgentProposalCommand('/Invitation/Revoke', { Reason: reason.val().trim() }, '#btnRevokeLink', 'La invitación fue anulada.');
        });
        modal.modal('show');
    }

    // Inserta el contrato almacenado cuando la solicitud se muestra sin consultar la lista filtrada del agente.
    function setStoredContractOption(proposal) {
        const contract = $('#NUM_CONTRATO');
        const contractNumber = Number(proposal.NUM_CONTRATO);
        const description = typeof proposal.NUM_CONTRATODesc === 'string'
            ? proposal.NUM_CONTRATODesc.trim()
            : '';

        // Una instantánea incompleta no puede convertirse en un contrato ficticio ni habilitar el flujo.
        if (!Number.isFinite(contractNumber) || contractNumber <= 0 || !description) {
            contract.empty()
                .prop('disabled', true)
                .trigger('change.select2');
            return false;
        }

        contract.empty()
            .append(new Option(description, contractNumber, true, true))
            .prop('disabled', true)
            .trigger('change.select2');
        return true;
    }

    // Restaura la ocupación después de que el control select2 termina de cargar sus opciones.
    function restoreProposalOccupation(proposal) {
        app.ui.SetDropDownNumericValue('#OCUPACION_ASEG', proposal.OCUPACION_ASEG, false);
        $('#OCUPACION_ASEG').trigger('change.select2');
    }

    // Conserva la llave requerida por la tabla dinámica; propuestas antiguas no la contienen y la reciben solo al cargarse.
    function ensureBeneficiaryRowIds(beneficiaries) {
        const rows = Array.isArray(beneficiaries) ? beneficiaries : [];
        const assigned = {};
        let nextId = 1;

        rows.forEach(function (beneficiario) {
            let rowId = Number(beneficiario.BeneficiariosId);
            if (!Number.isInteger(rowId) || rowId <= 0 || assigned[rowId]) {
                while (assigned[nextId]) {
                    nextId++;
                }
                rowId = nextId;
            }

            beneficiario.BeneficiariosId = rowId;
            assigned[rowId] = true;
            nextId = Math.max(nextId, rowId + 1);
        });

        return rows;
    }

    // Restaura controles compuestos y catálogos dependientes que el asignador genérico del formulario no administra.
    function restoreInsuredDependentFields(proposal) {
        $('#beneficiariosTbl').bootstrapTable('load', ensureBeneficiaryRowIds(proposal.Beneficiarios));

        restoreProposalOccupation(proposal);

        if (!proposal.COD_ESTADO) {
            return;
        }

        const country = $('select#cod_pais').val() || 'CRI';
        app.ui.SetDropDownNumericValue('#COD_ESTADO', proposal.COD_ESTADO, false);
        app.core.LookupDependency(proposal.COD_ESTADO, 'COD_PROVINCIA', 'Cantones', '', proposal.COD_PROVINCIA, false,
            function () {
                if (proposal.COD_PROVINCIA) {
                    app.core.LookupDependency(proposal.COD_PROVINCIA, 'COD_LOCALIDAD', 'Distritos', '', proposal.COD_LOCALIDAD, false, null,
                        `cod_pais=${country}:cod_prov=`);
                }
            }, `cod_pais=${country}:cod_estado=`);
    }

    // Recupera la instantánea desde el alcance de la invitación; no usa el parámetro proposal de la URL como autorización.
    function loadInsuredProposal() {
        app.core.Get(app.setting.apipath + 'v1/InsuredCompletion/proposal')
            .done(function (proposal) {
                if (proposal == null || !proposal.ProposalId) {
                    app.ui.Error('La solicitud no está disponible para completar.');
                    return;
                }

                _proposalId = proposal.ProposalId;
                _insuredProposal = proposal;
                app.EmitirPoliza.SetData(proposal);
                if (!setStoredContractOption(proposal)) {
                    app.ui.Error('La solicitud no contiene un contrato válido para completar.');
                    return;
                }
                $('#MONEDA').val(proposal.MONEDA);
                restoreInsuredDependentFields(proposal);
                lockInsuredAgentFields();
            });
    }

    // Construye el mismo contrato de altas para todas las acciones, incluyendo el identificador persistido cuando exista.
    function createWorkflowEntry(spec, mode) {
        let entry = spec.Data();
        entry.ProposalId = _proposalId || entry.ProposalId || null;
        // El asegurado conserva el texto almacenado; el agente lo actualiza con la opción que eligió.
        const selectedContractDescription = $('#NUM_CONTRATO option:selected').text().trim();
        entry.NUM_CONTRATODesc = isInsuredCompletion()
            ? (_insuredProposal == null ? entry.NUM_CONTRATODesc : _insuredProposal.NUM_CONTRATODesc)
            : (selectedContractDescription || entry.NUM_CONTRATODesc || null);
        // La moneda forma parte de la instantánea comercial; el asegurado conserva el valor que preparó el agente.
        entry.MONEDA = isInsuredCompletion()
            ? (_insuredProposal == null ? entry.MONEDA : _insuredProposal.MONEDA)
            : ($('#MONEDA').val() || entry.MONEDA || null);
        entry.TIP_DOCUM_ASEG = $("#COD_DOCUM_ASEGType").data("value");
        entry.modo = mode;
        return entry;
    }

    // Comprueba una fecha real distinta del valor mínimo que representa un control de fecha vacío.
    function isInvitationDate(value) {
        const date = value instanceof Date ? value : new Date(value);
        return !isNaN(date.getTime()) && date.getFullYear() > 1;
    }

    // Conserva la prima calculada de Vida Colectivo aunque el control esté bloqueado por la modalidad del contrato.
    function synchronizeInvitationCalculatedValues(entry) {
        if (Number(entry.RAMO) === 117 && $('#IMP_PRIMA_INFORMADA').is(':disabled')) {
            app.ui.SetNumericValue('#IMP_PRIMA_INFORMADA', app.ui.GetNumericValue('#IMP_SUM_ASEG_VC'));
            entry.IMP_PRIMA_INFORMADA = entry.IMP_SUM_ASEG_VC;
        }
    }

    // Muestra en el formulario los datos del agente que deben quedar completos antes de delegar el resto al asegurado.
    function showInvitationAgentValidationErrors(pending) {
        // Reutiliza el estándar global: resumen con conteo y mensajes debajo de cada control.
        app.ui.ShowValidationErrors('#EmitirPolizaEdtForm', pending);
    }

    // Replica en el navegador los datos generales y de riesgo que el API exige y que el asegurado no podrá modificar.
    function validateInvitationAgentFields(spec) {
        const entry = createWorkflowEntry(spec, 'SendLink');
        synchronizeInvitationCalculatedValues(entry);
        const pending = [];
        const require = function (condition, field, label) {
            if (!condition) {
                pending.push({ field: field, label: label });
            }
        };
        const numericValue = function (value) {
            const number = Number(value);
            return isNaN(number) ? 0 : number;
        };
        const email = typeof entry.EMAIL_ASEG === 'string' ? entry.EMAIL_ASEG.trim() : '';
        const startDate = isInvitationDate(entry.EFEC_SPTO) ? new Date(entry.EFEC_SPTO) : null;
        const endDate = isInvitationDate(entry.VCTO_SPTO) ? new Date(entry.VCTO_SPTO) : null;

        require(numericValue(entry.RAMO) > 0, 'RAMO', 'ramo');
        require(numericValue(entry.NUM_CONTRATO) > 0, 'NUM_CONTRATO', 'contrato');
        require(startDate !== null, 'EFEC_SPTO', 'inicio de vigencia');
        require(endDate !== null && startDate !== null && endDate > startDate, 'VCTO_SPTO', 'fin de vigencia');
        require(/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email), 'EMAIL_ASEG', 'correo electrónico del asegurado');

        switch (numericValue(entry.RAMO)) {
            case 117:
                require(numericValue(entry.IMP_SUM_ASEG_VC) > 0, 'IMP_SUM_ASEG_VC', 'sueldo del asegurado');
                // La modalidad que bloquea la prima informada la calcula desde el sueldo; no se exige un control no editable.
                if (!$('#IMP_PRIMA_INFORMADA').is(':disabled')) {
                    require(numericValue(entry.IMP_PRIMA_INFORMADA) > 0 || numericValue(entry.IMP_PRIMA_FACT) > 0,
                        'IMP_PRIMA_INFORMADA', 'prima');
                }
                break;
            case 194:
                require(numericValue(entry.ID_CRED_ESTUDIANTE) > 0, 'ID_CRED_ESTUDIANTE', 'identificación del estudiante');
                require(String(entry.MCA_ASISTENCIA) === '1' || String(entry.MCA_ASISTENCIA) === '2',
                    'MCA_ASISTENCIA', 'asistencia');
                require(numericValue(entry.IMP_SUMA_MUERTE) > 0, 'IMP_SUMA_MUERTE', 'suma asegurada por muerte');
                require(typeof entry.COD_PLAN_AP === 'string' && entry.COD_PLAN_AP.trim() !== '' && entry.COD_PLAN_AP !== '0',
                    'COD_PLAN_AP', 'plan');
                break;
            case 401:
                require(typeof entry.NUM_PRESTAMO === 'string' && entry.NUM_PRESTAMO.trim() !== '',
                    'NUM_PRESTAMO', 'número del préstamo');
                require(isInvitationDate(entry.INI_PRESTAMO), 'INI_PRESTAMO', 'inicio del préstamo');
                require(isInvitationDate(entry.VCTO_PRESTAMO) && new Date(entry.VCTO_PRESTAMO) > new Date(entry.INI_PRESTAMO),
                    'VCTO_PRESTAMO', 'fin del préstamo');
                require(numericValue(entry.IMP_SUMA_ASEG) > 0, 'IMP_SUMA_ASEG', 'suma asegurada');
                require(numericValue(entry.IMP_PRIMA_INFORMADA) > 0, 'IMP_PRIMA_INFORMADA', 'prima informada');
                break;
            default:
                require(false, 'RAMO', 'ramo habilitado');
                break;
        }

        if (pending.length === 0) {
            return true;
        }

        showInvitationAgentValidationErrors(pending);
        return false;
    }

    // Centraliza el envío de una acción del ciclo y conserva el identificador que devuelve el servidor al guardar por primera vez.
    function postWorkflowAction(spec, mode, buttonSelector, requireFullValidation, successMessage, onSuccess) {
        let other = !requireFullValidation || app.Form_Ext_Altas.OtherValidations();
        if (requireFullValidation && (!spec.IsValid(true) || !other)) {
            return;
        }

        $('#generalNotify').html('');
        app.ui.ButtonDoing(buttonSelector);
        let entry = createWorkflowEntry(spec, mode);

        app.core.Post(app.setting.apipath + 'v1/Poliza/Altas', JSON.stringify(entry))
            .done(function (posted) {
                if (posted != null && (posted.ID_TIP_RESPUESTA === 1 || posted.ID_TIP_RESPUESTA === 2)) {
                    if (posted.NUM_POLIZA) {
                        _proposalId = posted.NUM_POLIZA;
                        replaceAgentProposalUrl();
                    }
                    app.ui.Success(successMessage || posted.OBSERVACION);
                    app.ui.ShowAlert('generalNotify', 'alert-success', `<b><i class="fa fa-check"></i> ${posted.OBSERVACION || successMessage}</b>`);
                    if (onSuccess) {
                        onSuccess(posted);
                    }
                } else if (posted != null) {
                    app.ui.Error(posted.OBSERVACION || posted.ERROR);
                    app.ui.ShowAlert('generalNotify', 'alert-danger', `<b><i class="fa fa-exclamation-triangle"></i> ${posted.OBSERVACION || posted.ERROR}</b>`);
                }
            }).always(function () {
                app.ui.ButtonDone(buttonSelector);
            });
    }

    function show(row) {

        var html = [];

        html.push('<div class="row">');

        [
            { key: 'Inicio de vigencia', value: app.ui.StringValueToString(row.FEC_EFEC_SPTO, '---'), size: 6 },
            { key: 'Fin de vigencia', value: app.ui.StringValueToString(row.FEC_VCTO_SPTO, '---'), size: 6 },
            { key: 'Prima total', value: `${app.ui.StringValueToString(row.PRIMA_TOTAL, '---')}`, size: 6 },
            { key: 'Coberturas', value: `${app.ui.StringValueToString(row.COBERTURAS, '---')}`, size: 12 },
            { key: 'Observación', value: `${app.ui.StringValueToString(row.OBSERVACION, '---')}`, size: 12 }
        ].forEach(function (item) {
            html.push(`<div class="col-md-${item.size}"><div class="readonlyfield"><strong>${item.key}</strong><div>${item.value}</div></div></div>`);
        });
        html.push(`</div>`);

        html.push(`<div class="col-md-12"><div class="row">`);
        html.push('<table class="table table-hover margin bottom">');
        html.push('<thead><tr><th style="width: 1%" class="text-center">No.</th><th>Recibo</th><th class="text-center">Monto</th></tr></thead><tbody>');
        row.RECIBOS.forEach(function (item, index) {
            html.push(`<tr><td class="text-center">${index + 1}</td><td> ${item.NUM_RECIBO}</td><td class="text-center"><span class="label label-primary">${item.MONTO}</span></td></tr>`);
        });
        html.push('</tbody></table>');
        html.push(`</div></div>`);
        app.ui.ShowSideBar({ title: 'PÓLIZA #{NUM_POLIZA}', subtitle: 'La póliza fue emitida de forma exitosa', isHTML: true, HTML: html.join(''), data: row, width: '380px' });

        // $('.sidebar-content').toggleClass('sk-loading');
    }

    function update_info_poliza_grupo() {
        // La invitación ya contiene una instantánea completa; no puede ni debe obtener información del contrato del agente.
        if (isInsuredCompletion()) {
            return;
        }

        let cod_ramo = app.ui.GetDropDownNumericValue('#RAMO');
        let contracto = app.ui.GetDropDownNumericValue('#NUM_CONTRATO');
        let setdefaultVcto = true;
        if (contracto > 0) {
            _polizagrupo = app.core.Data().lookups.filter(i => i.Key === 'Contratos_v2')[0].Lkp.filter(l => l.Code === contracto + '')[0];

            if (_polizagrupo != null) {
                $('#NUM_POLIZA_GRUPO').val(_polizagrupo.NUM_POLIZA);
                $('#MONEDA').val(_polizagrupo.NOM_MON);
                if (_polizagrupo.FEC_VCTO_POLIZA != null && _polizagrupo.FEC_VCTO_POLIZA != '') {
                    app.ui.SetDateValue('#VCTO_SPTO', moment(_polizagrupo.FEC_VCTO_POLIZA, 'DD/MM/YYYY').toDate());
                    setdefaultVcto = false;
                }

                if (cod_ramo === 117) {
                    switch (_polizagrupo.MODALIDAD) {
                        case '11701':
                            $("#IMP_PRIMA_FACT").prop("disabled", true);
                            app.ui.SetDropDownNumericValue('#IMP_PRIMA_FACT', 0);
                            $("#IMP_PRIMA_INFORMADA").prop("disabled", true);
                            $(".IMP_PRIMA_FACTVisible").addClass('d-none');
                            app.ui.SetNumericValue('#IMP_PRIMA_INFORMADA', app.ui.GetNumericValue('#IMP_SUM_ASEG_VC'));
                            break;
                        case '11702':
                            $("#IMP_PRIMA_FACT").prop("disabled", false);
                            $(".IMP_PRIMA_FACTVisible").removeClass('d-none');
                            app.core.Lookups(['TRON_G2990006_ByMod:IMP_PRIMA_FACT.IMP_PRIMA_FACT'], function () {
                            }, `cod_ramo=${cod_ramo}:cod_modalidad=${_polizagrupo.MODALIDAD}`);
                            $("#IMP_PRIMA_INFORMADA").prop("disabled", true);
                            app.ui.SetNumericValue('#IMP_PRIMA_INFORMADA', 0);
                            break;
                        default:
                            $("#IMP_PRIMA_FACT").prop("disabled", false);
                            app.ui.SetDropDownNumericValue('#IMP_PRIMA_FACT', 0);
                            $(".IMP_PRIMA_FACTVisible").addClass('d-none');
                            $("#IMP_PRIMA_INFORMADA").prop("disabled", false);
                            break;
                    }
                }

            }
        }

        if (setdefaultVcto) {
            let newvcto = app.ui.GetDateRawValue('#EFEC_SPTO');
            newvcto.setFullYear(newvcto.getFullYear() + 1);
            app.ui.SetDateValue('#VCTO_SPTO', newvcto);
        }
    };

    function beneficiarios_table_OtherValidations() {
        var result = true;
        var beneficiarios = $('#beneficiariosTbl').bootstrapTable('getData');

        if (beneficiarios.length === 0) {
            result = false;
            $('#beneficiariosTbl-error').text('Debe existir al menos un beneficiario');
            $('#beneficiariosTbl-error').removeClass('d-none');
        }
        else if (beneficiarios.reduce((total, item) => total + item.PCT_PARTICIPACION, 0) != 100) {
            result = false;
            $('#beneficiariosTbl-error').text('El total del porcentaje de participación debe ser el 100%');
            $('#beneficiariosTbl-error').removeClass('d-none');
        }
        else {
            $('#beneficiariosTbl-error').text('');
            $('#beneficiariosTbl-error').addClass('d-none');
        }

        return result;
    }

    return {
        Init: function (spec, formName) {
            let cod_pais = 'CRI';
            let options = spec.Options();
            options.Base = `cod_pais=${cod_pais}`;
            options.Changed = function (data, source) {
                console.log('Changed', data, source);
                if (source === 'after') {
                    let polizagrupo = app.Form_Ext_Altas.polizagrupo();
                    console.log('xx', polizagrupo);
                    if (data.RAMO === 117 && polizagrupo != null) {
                        switch (polizagrupo.MODALIDAD) {
                            case '11701':
                                app.ui.SetNumericValue('#IMP_PRIMA_INFORMADA', app.ui.GetNumericValue('#IMP_SUM_ASEG_VC'));
                                break;
                            case '11702':
                                app.ui.SetNumericValue('#IMP_PRIMA_INFORMADA', app.ui.GetNumericValue('#IMP_SUM_ASEG_VC') * app.ui.GetDropDownNumericValue('#IMP_PRIMA_FACT'));
                                break;
                            default:
                                break;
                        }
                    }
                }
            };

            options.Events = function (field, data, source) {
                console.log('Event', field, data, source);
                if (field === '#COD_DOCUM_ASEG' && source === 'Identification') {
                    if (data != null) {
                        $('#NOM_TERCERO_ASEG').val(data.FirstName);
                        $('#APE_TERCERO_ASEG').val(data.LastName);
                        $('#EMAIL_ASEG').val(data.PrimaryEmailAddress);
                        $('#TLF_NUMERO_ASEG').val(data.PhoneNumber);

                        app.ui.SetDateValue('#NAC_ASEG', data.BirthDate);
                        app.ui.SetRadioNumericValue('MCA_SEXO_ASEG', data.Gender === 2 ? 0 : 1);
                        app.ui.SetDropDownStringValue('#NACIONALIDAD_ASEG', data.CountryOfNationalityISO, false);
                        app.ui.SetDropDownNumericValue('#COD_ESTADO', data.Province, false);
                        app.core.LookupDependency(data.Province, 'COD_PROVINCIA', 'Cantones', '', data.Canton, false, null, `cod_pais=${cod_pais}:cod_estado=`);
                        app.core.LookupDependency(data.Canton, 'COD_LOCALIDAD', 'Distritos', '', data.District, false, null, `cod_pais=${cod_pais}:cod_prov=`);

                        $('#DOMICILIO').val(data.AddressDetail);
                    } else {
                        $('#NOM_TERCERO_ASEG').val('');
                        $('#APE_TERCERO_ASEG').val('');
                        $('#EMAIL_ASEG').val('');
                        $('#TLF_NUMERO_ASEG').val('');
                        app.ui.SetDateValue('#NAC_ASEG', null);
                        app.ui.SetRadioNumericValue('MCA_SEXO_ASEG', null);
                        app.ui.SetDropDownStringValue('#NACIONALIDAD_ASEG', 'CRI', true);
                        app.ui.SetDropDownNumericValue('#COD_ESTADO', null, false);
                        app.ui.SetDropDownNumericValue('#COD_PROVINCIA', null, false);
                        app.ui.SetDropDownNumericValue('#COD_LOCALIDAD', null, false);
                        $('#DOMICILIO').val('');
                    }
                }
                if (field === '#COD_DOCUM_BENEF' && source === 'Identification') {
                    if (data != null) {
                        $('#NOM_TERCERO_BENEF').val(data.FirstName);
                        $('#NOM2_TERCERO_BENEF').val(data.MiddleName);
                        $('#APE1_TERCERO_BENEF').val(data.LastName);
                        $('#APE2_TERCERO_BENEF').val(data.SecondLastName);

                        app.ui.SetDateValue('#FEC_NAC_BENEF', data.BirthDate);
                        app.ui.SetRadioStringValue('MCA_SEXO_BENEF', data.Gender === 2 ? 'M' : 'F');
                        $('#EMAIL_BENEF').val(data.PrimaryEmailAddress);
                        $('#TLF_NUMERO_BENEF').val(data.PhoneNumber);

                        // Conserva la jerarquía geográfica del beneficiario: provincia, cantón y distrito.
                        app.ui.SetDropDownNumericValue('#ESTADO_BENEF', data.Province, false);
                        app.core.LookupDependency(data.Province, 'PROVINCIA_BENEF', 'Cantones', '', data.Canton, false, null, `cod_pais=${cod_pais}:cod_estado=`);
                        app.core.LookupDependency(data.Canton, 'LOCALIDAD_BENEF', 'Distritos', '', data.District, false, null, `cod_pais=${cod_pais}:cod_prov=`);

                    } else {
                        $('#NOM_TERCERO_BENEF').val('');
                        $('#NOM2_TERCERO_BENEF').val('');
                        $('#APE1_TERCERO_BENEF').val('');
                        $('#APE2_TERCERO_BENEF').val('');
                        app.ui.SetDateValue('#FEC_NAC_BENEF', null);
                        app.ui.SetRadioNumericValue('MCA_SEXO_BENEF', null);
                        $('#EMAIL_BENEF').val('');
                        $('#TLF_NUMERO_BENEF').val('');
                        app.ui.SetDropDownNumericValue('#ESTADO_BENEF', null, false);
                        app.ui.SetDropDownNumericValue('#PROVINCIA_BENEF', null, false);
                        app.ui.SetDropDownNumericValue('#LOCALIDAD_BENEF', null, false);
                    }
                }
            };

            spec.SetOptions(options);

            $.validator.addMethod("ContratoVencido", function (value, element, params) {
                // El contrato del asegurado es una opción fija de la invitación y no se valida mediante el catálogo del agente.
                if (isInsuredCompletion()) {
                    return true;
                }

                let result = true;
                _polizagrupo = app.core.Data().lookups.filter(i => i.Key === 'Contratos_v2')[0].Lkp.filter(l => l.Code === value + '')[0];

                if (_polizagrupo != null && _polizagrupo.FEC_VCTO_POLIZA != null && _polizagrupo.FEC_VCTO_POLIZA != '') {
                    let vcto = moment(_polizagrupo.FEC_VCTO_POLIZA, 'DD/MM/YYYY').toDate();
                    result = (vcto > app.ui.Today())
                    if (!result) {
                        $('#NUM_CONTRATO').rules('add', { messages: { ContratoVencido: `La póliza grupo se encuentra vencida ${_polizagrupo.FEC_VCTO_POLIZA}` } });
                    }
                }
                return result;
            });
            $(`#${formName}EdtForm`).validate(); $("#NUM_CONTRATO").rules('add', { ContratoVencido: true, messages: { ContratoVencido: "La póliza grupo se encuentra vencida" } });

            app.core.Lookups(options.Lookups,
                function () {
                    app.ui.SetDropDownStringValue('#NACIONALIDAD_ASEG', 'CRI', false);
                    $('#COD_ESTADO').on('change', function () {
                        app.core.LookupDependency($('select#COD_ESTADO').val(), 'COD_PROVINCIA', 'Cantones', '', null, true, null, `cod_pais=${cod_pais}:cod_estado=`);
                    });
                    $('#COD_PROVINCIA').on('change', function () {
                        var pais = $('select#cod_pais').val();
                        app.core.LookupDependency($('select#COD_PROVINCIA').val(), 'COD_LOCALIDAD', 'Distritos', '', null, false, null, `cod_pais=${cod_pais}:cod_prov=`);
                    });
                    $('#ESTADO_BENEF').on('change', function () {
                        app.core.LookupDependency($('select#ESTADO_BENEF').val(), 'PROVINCIA_BENEF', 'Cantones', '', null, true, null, `cod_pais=${cod_pais}:cod_estado=`);
                    });
                    $('#PROVINCIA_BENEF').on('change', function () {
                        var pais = $('select#cod_pais').val();
                        app.core.LookupDependency($('select#PROVINCIA_BENEF').val(), 'LOCALIDAD_BENEF', 'Distritos', '', null, false, null, `cod_pais=${cod_pais}:cod_prov=`);
                    });
                    
                    $('#OCUPACION_ASEG').select2({ width: '100%', theme: 'bootstrap4' });

                    if (isInsuredCompletion()) {
                        loadInsuredProposal();
                    } else {
                        loadAgentProposal();
                    }
                }, options.Base);

            $('#RAMO').on('change', function () {
                if (isInsuredCompletion()) {
                    if (_insuredProposal != null) {
                        setStoredContractOption(_insuredProposal);
                    }

                    lockInsuredAgentFields();
                    return;
                }

                // El motor visual muestra botones por ramo; una solicitud nueva aún no tiene invitación que administrar.
                configureWorkflowButtons(false);
                let cod_ramo = app.ui.GetDropDownNumericValue('#RAMO');
                app.core.Lookups(['Contratos_v2.NUM_CONTRATO'], function () {
                    $("#NUM_CONTRATO").prop("disabled", $('#NUM_CONTRATO').children().length == 0);

                    $('#NUM_POLIZA_GRUPO').val('');
                    $('#MONEDA').val('');

                }, options.Base + `:cod_ramo=${cod_ramo}`);
            });

            $('#EFEC_SPTO').blur(function () {
                let minDate = app.ui.GetDateRawValue('#EFEC_SPTO');
                minDate.setDate(minDate.getDate() + 1);

                $('#VCTO_SPTO_group').data("DateTimePicker").minDate(minDate);

                update_info_poliza_grupo();
            });

            $('#NUM_CONTRATO').on('change', function () {
                update_info_poliza_grupo();
            });

            $('#btnSendLink').click(function (e) {
                e.preventDefault();
                if (!validateInvitationAgentFields(spec)) {
                    return;
                }

                postWorkflowAction(spec, 'SendLink', '#btnSendLink', false, 'La invitación fue enviada al asegurado.', function () {
                    loadAgentProposal();
                });
            });

            $('#btnSaveDraft').click(function (e) {
                postWorkflowAction(spec, 'Draft', '#btnSaveDraft', false, 'El borrador fue guardado.');
                e.preventDefault();
            });

            $('#btnSendSignature').click(function (e) {
                postWorkflowAction(spec, 'SendSignature', '#btnSendSignature', true, 'La solicitud fue enviada a firma electrónica.', function () {
                    $("#EmitirPolizaEdtForm fieldset").prop("disabled", true);
                    $('#btnSaveDraft, #btnSendLink, #btnSendSignature, #btnIssue').addClass('d-none');
                });
                e.preventDefault();
            });

            $('#btnComplete').click(function (e) {
                postWorkflowAction(spec, 'Complete', '#btnComplete', true, 'La solicitud fue confirmada y enviada a firma electrónica.', function () {
                    $("#EmitirPolizaEdtForm fieldset").prop("disabled", true);
                    $('#btnSaveDraft, #btnComplete').addClass('d-none');
                });
                e.preventDefault();
            });

            $('#btnIssue').click(function (e) {
                postWorkflowAction(spec, 'Issue', '#btnIssue', true, 'La póliza fue emitida de forma exitosa', function (posted) {
                    let msg = 'La póliza fue emitida de forma exitosa';
                    if (posted.ID_TIP_RESPUESTA === 2) {
                        msg = msg + ', pero retenida por control técnico';
                    }

                    $("#EmitirPolizaEdtForm fieldset").prop("disabled", true);
                    $('#btnSaveDraft, #btnSendLink, #btnSendSignature, #btnIssue').addClass('d-none');
                    show(posted);
                });
                e.preventDefault();
            });

            $('#btnResendLink').click(function (e) {
                e.preventDefault();
                showResendInvitationModal();
            });

            $('#btnRevokeLink').click(function (e) {
                e.preventDefault();
                showRevokeInvitationModal();
            });

            $('#btnResumeEditing').click(function (e) {
                e.preventDefault();
                if (window.confirm('Retomar la solicitud invalidará el enlace enviado al asegurado. ¿Desea continuar?')) {
                    postAgentProposalCommand('/ResumeEditing', null, '#btnResumeEditing', 'La solicitud quedó disponible para corrección.');
                }
            });

            let insuredCompletion = isInsuredCompletion();
            configureWorkflowButtons(insuredCompletion);
            if (!insuredCompletion) {
                let code = app.core.URLStringValue('ramo');
                if (code != '') {
                    app.ui.SetDropDownNumericValue('#RAMO', code, false);
                    $('#RAMO').change();
                } else {
                    app.ui.SetDropDownNumericValue('#RAMO', 0, false);
                }
                app.ui.SetRadioNumericValue('MCA_SEXO_ASEG', 0);
                app.ui.SetRadioNumericValue('MCA_ASISTENCIA', 2);
                let today = app.ui.Today();
                app.ui.SetDateValue('#EFEC_SPTO', today);
                $('#EFEC_SPTO').blur();
                let fec_vcto = today.setFullYear(today.getFullYear() + 1);
                app.ui.SetDateValue('#VCTO_SPTO', fec_vcto);
            }
            spec.Changed(false);
        },
        polizagrupo: function () {
            return _polizagrupo;
        },
        OtherValidations: function () {
            return beneficiarios_table_OtherValidations();
        }

    };
})();
