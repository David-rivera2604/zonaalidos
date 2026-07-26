class ExtCaseAssignment {
    ctx = {};
    currentData = null;

    /**
     * Abre el formulario de asignacion de caso.
     * @param {object} row     - Fila de la visualizacion
     * @param {object} context - Contexto del viewer (ShowForm, HideForm, Refresh)
     */
    Assign(row, context) {
        context.ShowForm('CaseAssignment').then(() => {
            this.currentData = { ...row };

            $('#CaseId').val(row.ID);
            $('#CaseTitle').html(row.TITLE || '');
            $('#FlowName').html(row.FLOWNAME || '');
            $('#StatusDesc').html(row.STATUSDESC || '');
            $('#PriorityDesc').html(row.PRIORITYDESC || '');
            $('#StepName').html(row.STEPNAME || '');
            $('#TiempoEtapa').html(row.TIEMPOETAPA || '');
            $('#Progreso').html(row.PROGRESS != null
                ? '<div class="progress progress-mini"><div style="width: ' + row.PROGRESS + '%;" class="progress-bar"></div></div><small>' + row.PROGRESS + '% / Etapa ' + row.STEPCURRENT + ' de ' + row.STEPTOTAL + '</small>'
                : '');
            $('#CurrentAssignee').html(row.USUARIOETAPA || '<em class="text-muted">Sin asignar</em>');

            app.core.Get(app.setting.apipath + 'v1/ProcessCase/' + row.ID + '/Users')
                .done(function(users) {
                    if (users && users.length > 0) {
                        var lkpData = users.map(function(u) {
                            return {
                                Code: u.UserId,
                                Description: u.FullName + ' (' + u.CaseCount + ' caso' + (u.CaseCount !== 1 ? 's' : '') + ' asignado' + (u.CaseCount !== 1 ? 's' : '') + ')'
                            };
                        });
                        app.ui.LookupLoad('UserAssigned', lkpData, false);

                        // Preseleccionar el usuario actualmente asignado
                        function selectAssignedUser(userAssigned) {
                            if (userAssigned > 0) {
                                $('#UserAssigned').val(String(userAssigned)).trigger('change');
                            }
                        }

                        var userAssigned = row.USERASSIGNED ?? row.UserAssigned;
                        if (userAssigned > 0) {
                            selectAssignedUser(userAssigned);
                        } else {
                            // Algunas visualizaciones no incluyen USERASSIGNED en la fila.
                            // Obtenerlo del caso evita depender de esa columna del viewer.
                            app.core.Get(app.setting.apipath + 'v1/ProcessCase/' + row.ID)
                                .done(function(processCase) {
                                    selectAssignedUser(processCase.UserAssigned);
                                });
                        }
                    }
                })
                .fail(function() {
                    toastr.warning('No se pudo cargar la lista de colaboradores.', '', { timeOut: 3000 });
                });

            $('#TimelineHistorial')
                .css({ 'overflow': 'visible', 'min-height': '80px' })
                .closest('[class*="col-"]')
                .css({ 'max-width': '100%', 'flex': '0 0 100%', 'overflow': 'visible' });

            app.core.Get(app.setting.apipath + 'v1/ProcessCase/' + row.ID + '/Reassignments')
                .done(function(history) {
                    app.frm.RenderTimeline('#TimelineHistorial', history);
                })
                .fail(function() {
                    app.frm.RenderTimeline('#TimelineHistorial', []);
                });
        });
    }

    /**
     * Manejador de eventos del formulario CaseAssignment.
     */
    eventsHandler(field, data, source, context) {
        var self = this;
        var acciones = {
            cancelBtn: function() {
                if (context && typeof context.HideForm === 'function')
                    context.HideForm();
            },
            saveBtn: function() {
                var userId = parseInt($('#UserAssigned').val(), 10);
                if (!userId) {
                    toastr.warning('Debe seleccionar un colaborador.', '', { timeOut: 3000 });
                    return;
                }

                app.ui.ButtonDoing('#saveBtn');

                app.core.Put(
                    app.setting.apipath + 'v1/ProcessCase/Assign/' + self.currentData.ID,
                    JSON.stringify({ UserAssigned: userId })
                )
                .done(function() {
                    toastr.success('Caso #' + self.currentData.ID + ' asignado correctamente.', '', { timeOut: 4000, closeButton: true, progressBar: true });
                    context.HideForm();
                    context.Refresh();
                })
                .fail(function() {
                    toastr.error('Error al asignar el caso. Intente de nuevo.', '', { timeOut: 5000, closeButton: true });
                })
                .always(function() {
                    app.ui.ButtonDone('#saveBtn');
                });
            }
        };

        (acciones[field] || function() {})();
        return true;
    }

    async Init(spec, formName, context) {
        this.ctx         = spec;
        this.ctx.context = context;

        var options    = spec.Options();
        var self       = this;
        options.Events = function(field, data, source) { return self.eventsHandler(field, data, source, context); };
        spec.SetOptions(options);

        var botones = document.querySelectorAll('#' + formName + 'EdtForm button');
        botones.forEach(function(boton) {
            boton.addEventListener('click', function() {
                self.eventsHandler(boton.id, boton, undefined, context);
            });
        });
    }
}

var app = app || {};
app.Ext_CaseAssignment = new ExtCaseAssignment();
