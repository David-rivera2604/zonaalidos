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
        app.CentralCase.Get(app.setting.apipath + 'v1/ProcessCase/' + row.CaseId, tokenAl, false)
            .done(function (data, textStatus, jqXHR) {
                MapObjectToInput(data);
                $('#Title').focus();
                $("#ContenCase").addClass("d-none");
                RefreshProcess(data.InstanceId);

                setTimeout(function () {
                    $("#ContenCase").removeClass("d-none");
                }, 50)
                $("#Cases_Info").removeClass("d-none");
            }).always(function () {
                $('.ibox-content').toggleClass('sk-loading');
            });
    }
    //Configuracion y diseño de la tabla de cada Caso unico
    function Init_List_Process() {
        $('#ProcessGridTbl').bootstrapTable({
            uniqueId: 'ActivityId',
            pagination: false,
            smartDisplay: true,
            rowStyle: function (row, index) {
                return {
                    css: {
                        'vertical-align': 'top'
                    }
                }
            },
            columns: [
                {
                    field: 'Name',
                    title: 'Etapa',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    formatter: function (value, row, index, field) {
                        var result = '';
                        var status = 'fa-check';
                        var color = 'green';
                        var styleTitle = 'font-weight: 600;';
                        var title = 'Procesado';
                        if (row.FinishDate === null || row.FinishDate === '0001-01-01T00:00:00') {
                            status = 'fa-clock-o';
                            color = 'yellowgreen';
                            title = 'Etapa en progreso';
                        }
                        if (row.StartDate === null || row.StartDate === '0001-01-01T00:00:00') {
                            status = 'fa-clock-o';
                            color = 'gray';
                            styleTitle = '';
                            title = 'Etapa sin procesar';
                            if (row.Wait === '') {
                                status = 'fa-chain-broken';
                                styleTitle = 'text-decoration: line-through;color: gray'
                                title = 'Etapa no necesaria para el caso';
                            }
                        }
                        result = `<i class="fa ${status}" aria-hidden="true" style="margin: 0px 8px 0px 5px;color: ${color};" title="${title}"></i>` + `<span style="${styleTitle}" title="${title}">` + value + '</span>';

                        if (row.FinishDate != null && row.FinishDate != '0001-01-01T00:00:00') {
                            result = result + '<div class="d-block d-sm-none" style="margin: 0 20px;">Completado: ' + moment(row.FinishDate).format('DD/MM/YYYY hh:mma');
                            result = result + '</div>';
                        }

                        result = result + `<div style="margin: 0 26px;"><small class="text-muted" id="compl_${row.StepId}"></small></div>`;
                        return result;

                    }
                }, {
                    field: 'FinishDate',
                    title: 'Completado',
                    class: 'd-none d-sm-table-cell',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateAndTimeFormatter'
                },]
        });
    }

    //Funcion para toda la carga de la informacion de tabla, estado, y progreso de un caso en especifico
    async function RefreshProcess(instanceId) {

        app.CentralCase.Get(app.setting.apipath + 'v1/Process/Instance/' + instanceId + '/3', tokenAl, false)
            .done(function (data, textStatus, jqXHR) {
                _instance = data;
                if (data.Steps) {
                    caseId = data.CaseId;

                    $('#ProcessGridTbl').bootstrapTable('load', data.Steps);

                    let current = data.Steps.filter(i => i.ActivityId === data.ActivityId);

                    if (current.length > 0) {
                        $('#CurrentStep').html(current[0].Name);
                    }

                    $(".progress-bar").width(data.Progress + '%');
                    $(".progress-bar").prop('title', data.Progress + '%');
                    $(".progress-bar").html(data.Progress + '%');
                } else {
                    $('#ProcessGridTbl').bootstrapTable('load', []);
                }
            }).always(function () {
                $('#ProcessGridTbl').bootstrapTable('hideLoading');
            });
    }
    return {
        Init: function () {
            Init_List_Process();
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

                    app.CentralCase.Get(/*Api1*/  app.setting.apipath + 'v1/ProcessCase?filter=CaseAliados'  /*Api2*/ /*app.setting.apipath + 'v1/datasource/json?id=4000&sequence=' + index + '&url=' + window.location.search.slice(1).replace(/&/g, ':') + url*/, tokenAl, false)
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




            app.CentralCase.Get(app.setting.apipath + 'v1/Process/Instance/' + InstanceID + '/3', tokenAl, false)
                .done(function (data, textStatus, jqXHR) {
                    app.Attachments.Init({ EntityType: 1304, Id: data.CaseId, PostByEachRow: true, AlternateToken: tokenAl });
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
