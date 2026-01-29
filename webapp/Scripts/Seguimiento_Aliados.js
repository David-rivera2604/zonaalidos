var app = app || {};
var tokenAl
//Funciones para la carga de datos especificos
app.EspecifiCase = (function () {

    //Manejo de la id del caso mediante la url
    function Dynamic_Event_Controls() {
        var id = app.core.URLNumericValue('id');
        if (id !== 0) {
            EditMode({ CaseId: id });
        }

        $('#dropzone').fileUploader({
            maxFilesize: 256,
            done: function (responses) {
                console.log('Init_Controls: Archivos subidos exitosamente:', responses);
                //toastr.success('Archivos cargados correctamente', '', {
                //    timeOut: 3000,
                //    closeButton: true
                //});
            },
            fail: function (error, file) {
                console.error('Init_Controls: Error al subir archivo:', error, file);
                //var errorMsg = typeof error === 'string' ? error :
                //    (error.message || 'Error desconocido');
                //toastr.error('Error al subir el archivo: ' + file.name + ' - ' + errorMsg, '', {
                //    timeOut: 5000,
                //    closeButton: true
                //});
            },
            always: function (result) {
                console.log('Init_Controls: Proceso de carga completado:', result);
            }
        });

    }
    //funcion para la carga del titul y proceso
    function MapObjectToInput(data) {

        $('#Title').html(data.Title);
        $('#FlowIdDesc').html(data.FlowIdDesc + '.');
        let status = data.StatusDesc;
        if (data.SubLabel != '') {
            status += ' / ' + data.SubLabel;
        }
        $('#StatusDesc').html(status);
        $('#StatusDesc').addClass('label-warning-light');



    }

    //Carga de titulo y proceso de un caso en especifico 
    function EditMode(row) {
        $('.ibox-content').toggleClass('sk-loading');
        app.core.Get(app.setting.apipath + 'v1/ProcessCase/' + row.CaseId, undefined, undefined, true, tokenAl)
            .done(function (data, textStatus, jqXHR) {
                MapObjectToInput(data);
                $('#Title').focus();
                $("#ContenCase").addClass("d-none");
                _allowref = [];
                app.processHandler.RefreshProcess(data.InstanceId, false,
                    function (newData, ref, currentStep) {
                        _instance = newData;
                    }, tokenAl);

                setTimeout(function () {
                    $("#ContenCase").removeClass("d-none");
                }, 50)
                $("#Cases_Info").removeClass("d-none");

                //app.Attachments.Init({ EntityType: 1304, Id: data.Id, PostByEachRow: true, AlternateToken: tokenAl });

                app.core.Get(app.setting.apipath + `v1/Common/Attachments?entityType=1304&entityId=${data.Id}`, undefined, undefined, true, tokenAl)
                    .done(function (dataItems) {
                        $('#dropzone').fileUploader('load', dataItems, { EntityType: 1304, EntityId: data.Id, DocumentType: 1, Description: "General" }, tokenAl);
                    }).always(function ()
                    {
                    });

                app.Notes.Init({ EntityType: 1304, Id: data.Id, PostByEachRow: true, AlternateToken: tokenAl, showContactNotify: true, showResponsibleNotify: true });
            }).always(function () {
                $('.ibox-content').toggleClass('sk-loading');
            });
    }

    return {
        Init: function () {
            app.processHandler = new Process();

            app.processHandler.Init_List_Process();
        },
        EditRow: function (row) {
            EditMode(row);
        },
        Urlnum: function () {
            Dynamic_Event_Controls();
        }
    };
})();

//Funciones para la carga de información y busqueda
app.CaseInfo = (function () {
    return {
        Init: function ($el, xid, url, index) {

            app.core.Get(app.setting.apipath + 'v1/CasesSecurity/Create?Tenant=' + localStorage.getItem("Tenant"))
                .done(function (data, textStatus, jqXHR) {
                    tokenAl = data.TokenAliado
                    app.EspecifiCase.Urlnum();
                    if (index === undefined) {
                        index = 1;
                    }
                    if ($el != undefined) {
                        element = $el;
                        id = xid;
                    }
                    else {

                        url = '';
                    }

                    app.core.Get(app.setting.apipath + 'v1/ProcessCase?filter=CaseAliados')
                        .done(function (data) {
                            data.forEach(function (row, index, array) {

                        /*Api1*/ var IntanceCase = row.InstanceId
                        /*Api1*/ $('#Casos_Lista').append(`<div class="Content_Case animated fadeInDown" id="${IntanceCase}" onclick="app.CaseInfo.State(${IntanceCase})"><div class="Column_Conte CodCase"><i class="fa fa-caret-right" aria-hidden="true"> </i><p> ${row.Id}</p></div><div class="Column_Conte Asun"> <p>${row.Title}</p></div><div class="Column_Conte StatusDes"><p class="${row.StatusDesc}">${row.StatusDesc}</p><p class="d-none">${row.FlowIdDesc}</p></div></div>`);
                                /*Api2 */  /*$('#Casos_Lista').append(`<div class="Content_Case" id="${IntanceCase}" onclick="app.CaseInfo.State(${IntanceCase})"><div class="Column_Conte CodCase"><i class="fa fa-caret-right" aria-hidden="true"> </i><p> ${row.ID}</p></div><div class="Column_Conte Asun"> <p>${row.TITLE}</p></div><div class="Column_Conte StatusDes"><p>${row.STATUSDESC}</p></div></div>`); */
                            });
                        });
                    $("#AttachmentTbl-error").parent().addClass("d-none");
                })

        },
        State: function (InstanceID) {
            var element = $("#" + InstanceID)
            $(".Content_Case").each(function () {
                $(this).removeClass("activo");
            })
            element.addClass("activo")

            app.core.Get(app.setting.apipath + 'v1/Process/Instance/' + InstanceID + '/3', undefined, undefined, true, tokenAl)
                .done(function (data, textStatus, jqXHR) {
                    app.Attachments.Init({
                        EntityType: 1304,
                        Id: data.CaseId,
                        PostByEachRow: true,
                        AlternateToken: tokenAl,
                        ShowContactNotify: true,
                        ShowResponsibleNotify: true,
                        CallbackDone: function (noteNotify) {
                            console.log(noteNotify);
                        }
                    });
                    app.Notes.Init({ EntityType: 1304, Id: data.CaseId, PostByEachRow: true, AlternateToken: tokenAl });
                    app.EspecifiCase.EditRow(data);

                })
        },
        Busqueda: function (busqueda, datfil) {
            busqueda = busqueda.toLowerCase();
            datfil = datfil.toLowerCase();
            if (busqueda == "" && datfil == "todos") {
                $(".table1 div.Content_Case").each(function () {
                    $(this).each(function () {
                        $(this).removeClass("d-none");
                    })
                })
            }
            else {
                $(".table1 div.Content_Case").each(function () {
                    $(this).each(function () {
                        $(this).each(function () {
                            var value = this.innerText
                            value = value.toLowerCase();
                            if (value.indexOf(busqueda) >= 0) {

                                var filtro = false
                                if (datfil != "todos") {
                                    filtro = true
                                }

                                if (filtro) {
                                    if (value.indexOf(datfil) >= 0) {
                                        $(this).removeClass("d-none");
                                    }
                                    else {
                                        $(this).addClass("d-none");
                                    }
                                }
                                else {
                                    $(this).removeClass("d-none");
                                }
                            }
                            else {
                                $(this).addClass("d-none");
                            }
                        })
                    })

                })
            }

        },
    };
})();

//Llamados para la funcion de busqueda

var inputbuscador = document.getElementById('Buscador')

inputbuscador.addEventListener('input', e => {
    var datfil = $('select#Estado option:selected').text();
    var text = $("#Buscador").val();
    app.CaseInfo.Busqueda(text, datfil);
})


$("#Estado").change(function () {
    var datfil = $('select#Estado option:selected').text();
    var text = $("#Buscador").val();
    app.CaseInfo.Busqueda(text, datfil);
});
