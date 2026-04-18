class ExtUserMembers {
    ctx = {};
    currentData = null;

    events = {};

    New(context) {
        context.ShowForm('UserMembers').then(() => {
            this.currentData = app.frm.Empty_Object(app.UserMembers.Options().Elements);
            $('#UserId').prop('readonly', true);
            app.UserMembers.SetData(this.currentData);
            $('#saveContinueBtn').removeClass('d-none');
            $('#saveCopyBtn').removeClass('d-none');
            $('#duplicateBtn').addClass('d-none');
            $('#deleteBtn').addClass('d-none');
        });

        // $('.ibox-content').toggleClass('sk-loading');
    }

    Edit(row, context) {
        context.ShowForm('UserMembers').then(() => {
            this.currentData = row ? { ...row } : {};

            $('#saveContinueBtn').addClass('d-none');
            $('#saveCopyBtn').addClass('d-none');
            $('#duplicateBtn').removeClass('d-none');
            $('#deleteBtn').removeClass('d-none');

            if (!row || !row.USERID) {
                if (this.ctx && typeof this.ctx.SetData === 'function') {
                    this.ctx.SetData(this.currentData);
                }
                return;
            }

            app.core.Get(app.setting.apipath + 'v1/UserMember/getbyid?id=' + row.USERID)
                .done((data) => {
                    this.currentData = { ...data };
                    if (this.ctx && typeof this.ctx.SetData === 'function') {
                        //Mejorar roles.
                        //this.currentData.Roles = this.currentData.Roles.map(r => r.Code);
                        app.UserMembers.SetData(this.currentData);
                        //Mejorar roles
                       // app.ui.SetDropDownMultiValues('Roles', this.currentData.Roles);
                    }
                    //$('.ibox-content').toggleClass('sk-loading');
                    //$('#viewerFormHost .ibox-content').toggleClass('sk-loading');
                })
                .fail(() => {
                    this.currentData = row ? { ...row } : {};
                    if (this.ctx && typeof this.ctx.SetData === 'function') {
                        this.ctx.SetData(this.currentData);
                    }
                    //$('.ibox-content').toggleClass('sk-loading');
                });
        });
    }

    Delete(row, context) {
        toastr.warning("Si está seguro de querer eliminar el usuario '" + row.USERNAME + "' haga clic aquí", null,
            {
                timeOut: 7000, closeButton: true, progressBar: true,
                onclick: () => {
                    //$('.ibox-content').toggleClass('sk-loading');
                    app.core.Delete(`${app.setting.apipath}v1/UserMember/Delete?id=${row.USERID}`)
                        .done((data, textStatus, jqXHR) => {
                            toastr.success("El usuario '" + row.USERNAME + "' fue eliminado", "", { timeOut: 5000, closeButton: true, progressBar: true });
                            context.HideForm();
                            context.Refresh();
                        }).always(() => {
                            //$('.ibox-content').toggleClass('sk-loading');
                        });
                }
            });
    }

    Boton() {
        return {
            btnExclude: {
                text: 'Crea un nuevo usuario',
                icon: 'fa-plus',
                event: function (e) {
                    app.Ext_UserMembers.New(this);
                },
                attributes: {
                    title: 'Permite crear un nuevo usuario'
                }
            }
        }
    }

    //#endregion

    //#region Inicio de funciones para la extender la planilla

    eventsHandler(field, data, source, context) {
        let viewerContext = context || this.ctx?.context;

        if (field === '#DocumentNumber' && source === 'Identification' && data != null) {
            this.currentData = {
                ...(this.currentData || {}),
                FirstName: (data.FirstName + ' ' + data.MiddleName).trim(),
                LastName: (data.LastName + ' ' + data.SecondLastName).trim(),
                PhoneNumber: data.PhoneNumber,
                BirthDate: data.BirthDate
            };
            $('#FirstName').val((data.FirstName + ' ' + data.MiddleName).trim());
            $('#LastName').val((data.LastName + ' ' + data.SecondLastName).trim());
            $('#PhoneNumber').val(data.PhoneNumber);
            app.ui.SetDateValue('#BirthDate', data.BirthDate);
        }
        else {
            const acciones = {
                cancelBtn: () => {
                    if (viewerContext && typeof viewerContext.HideForm === 'function')
                        viewerContext.HideForm();
                },
                resetBtn: () => {
                    if (this.currentData && this.ctx && typeof this.ctx.SetData === 'function')
                        this.ctx.SetData(this.currentData);
                },
                saveBtn: () => {
                    if (app.UserMembers.IsValid(true)) {
                        app.ui.ButtonDoing('#saveBtn');
                        let data = app.UserMembers.Data();

                        if (data.UserId != 0) {
                            app.core.Put(app.setting.apipath + 'v1/UserMember/Put?id=' + this.currentData.UserId, JSON.stringify(data))
                                .done((respose, textStatus, jqXHR) => {
                                    toastr.success("El usuario '" + data.UserName + "' fue modificado" + respose.responseTronSubAgent, "", { timeOut: 5000, closeButton: true, progressBar: true });
                                    viewerContext.HideForm();
                                    viewerContext.Refresh();
                                }).always(() => {
                                    app.ui.ButtonDone('#saveBtn');
                                });
                        } else {
                            app.core.Post(app.setting.apipath + 'v1/UserMember/Post', JSON.stringify(data))
                                .done((respose, textStatus, jqXHR) => {
                                    toastr.success("El usuario '" + data.UserName + "' fue creado. " + respose.responseTronSubAgent, "", { timeOut: 5000, closeButton: true, progressBar: true });
                                    viewerContext.HideForm();
                                    viewerContext.Refresh();
                                }).always(() => {
                                    app.ui.ButtonDone('#saveBtn');
                                });
                        }
                    }
                }
            };

            (acciones[field] || (() => console.log('Otra acción')))();
        }
        return true;
    }

    async Init(spec, formName, context) {

        const formSelector = `#${formName}EdtForm`;

        let options = spec.Options();

        this.ctx = spec;
        this.ctx.context = context;

        // this.EventExt = this.events;

        options.Events = (field, data, source) => this.eventsHandler(field, data, source, context);
        spec.SetOptions(options);

        $('#Roles').select2({ width: '100%', theme: 'bootstrap4' });

        app.core.Lookups(options.Lookups, function () {

        }, options.Base);

        if (localStorage.getItem('Roles').includes('Empleado')) {
            let lks = ['Agents.Cod_Agt'];
            app.core.Lookups(lks, function () { }, `cod_ramo=302:cod_mon=1`);

            $('#agt-section').removeClass('d-none');
        }

        // Validaciones adicionales

        $.validator.addMethod("mapfre_password",
            function (value, element) {
                if (this.optional(element))
                    return true;
                else {
                    if (value === 'XXXXXXXX') {
                        return true;
                    } else if (value.match(/^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).+$/)) {
                        return true;
                    }
                }
            }, 'Debe tener minimo 8 carácteres, una mayúscula, un número y un carácter especial'
        );
        $(`#${formName}EdtForm`).validate(); $("#Password").rules('add', { minlength: 8, messages: { minlength: 'Debe tener por lo menos {0} carácteres' } });
        $(`#${formName}EdtForm`).validate(); $("#Password").rules('add', { mapfre_password: 8, messages: { mapfre_password: 'La clave debe tener al menos una mayúscula, un número y un carácter especial' } });

        //INICIO BLOQUE DE CODIGO a llevar a la generación
        //
        const botones = document.querySelectorAll(`#${formName}EdtForm button`);
        botones.forEach(boton => {
            boton.addEventListener('click', (event) => {
                this.eventsHandler(boton.id, boton, undefined, context);
            });
        });

        if ($(formSelector).length > 0 && !$(formSelector).data('validator')) {
            $(formSelector).validate();
        }
        //
        //FIN BLOQUE DE CODIGO a llevar a la generacion

    }

    //#endregion Fin de funciones para la extender la planilla
}
var app = app || {};
app.Ext_UserMembers = new ExtUserMembers();
