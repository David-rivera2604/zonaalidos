class Process {

    // Define la tabla que muestra el progreso del caso / proceso
    async Init_List_Process() {
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

                        if (row.StartDate != null && row.StartDate != '0001-01-01T00:00:00') {
                            result = result + '<div class="d-block d-sm-none" style="margin: 3px 20px 0px;">Inicio: ' + moment(row.StartDate).format('DD/MM/YYYY hh:mma');
                            result = result + '</div>';
                        }

                        if (row.FinishDate != null && row.FinishDate != '0001-01-01T00:00:00') {
                            result = result + '<div class="d-block d-sm-none" style="margin: 0 20px;">Completado: ' + moment(row.FinishDate).format('DD/MM/YYYY hh:mma');
                            result = result + '</div>';
                        }


                        if (row.FinishDate != null && row.FinishDate != '0001-01-01T00:00:00') {
                            result = result + '<div class="d-block d-sm-none" style="margin: 0 20px;">Realizado por: ' + row.UserName;
                            result = result + '<small class="text-muted"> ' + moment(row.FinishDate).from() + '</small>';
                            result = result + '</div>';
                        }
                        if (row.Comments != '') {
                            result = result + '<div class="d-block d-sm-none" style="margin: 0 20px;">Comentario:<small class="text-muted" style="font-style: italic;"> ' + row.Comments + '</small></div>';
                            result = result + '<div class="d-none d-sm-block" style="margin: 0 26px;"><small class="text-muted" style="font-style: italic;"> ' + row.Comments + '</small></div>';
                        }
                        result = result + `<div style="margin: 0 26px;"><small class="text-muted" id="compl_${row.StepId}"></small></div>`;
                        return result;

                    }
                }, {
                    field: 'StartDate',
                    title: 'Inicio',
                    class: 'd-none d-sm-table-cell',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateAndTimeFormatter'
                }, {
                    field: 'FinishDate',
                    title: 'Completado',
                    class: 'd-none d-sm-table-cell',
                    sortable: false,
                    halign: 'center',
                    align: 'center',
                    formatter: 'app.ui.DateAndTimeFormatter'
                }, {
                    field: 'FinishDate',
                    title: 'Realizado por',
                    class: 'd-none d-sm-table-cell',
                    sortable: false,
                    halign: 'center',
                    align: 'left',
                    width: 15,
                    widthUnit: '%',
                    formatter: function (value, row, index, field) {
                        if (value === null || value === '0001-01-01T00:00:00')
                            return '';
                        else
                            return '<span title="' + moment(value).format('DD/MM/YYYY hh:mma') + '">' + row.UserName + ' <small class="text-muted"> ' + moment(value).from() + '</small></span>';
                    }
                }]
        });
    }

    //  Carga la información sobre  el progreso del caso / proceso
    async RefreshProcess(instanceId, editMode, callbackDone, token) {
        let _allowref = [];
        let _currentStep = null;
        app.core.Get(app.setting.apipath + 'v1/Process/Instance/' + instanceId + '/3', undefined, undefined, undefined, token)
            .done(function (data, textStatus, jqXHR) {
                if (data.Steps) {
                    $('#ProcessGridTbl').bootstrapTable('load', data.Steps);
                    $('.tnotify').addClass('d-none');
                    let current = data.Steps.filter(i => i.ActivityId === data.ActivityId);

                    if (current.length > 0) {
                        _currentStep = current[0];
                        $('#StepDescription').html(current[0].Name);
                        $('#CurrentStep').html(current[0].Name);

                        if (current[0].References != null && current[0].References != '') {
                            _allowref = JSON.parse(current[0].References);
                        }
                    }
                    if (editMode) {
                        if (data.Tasks.length > 0) {
                            $('#tasks').empty();
                            $('#Annotation').val('');
                            $('#ProcessStepAccept').prop("disabled", true);
                            let selectedOptions = $('#tasks');
                            switch (current[0].ProgressMode) {
                                case 1: // Avance de simple selección entre etapas, selección simple
                                    $('.mode-simple').removeClass('d-none');
                                    $.each(data.Tasks, function () {
                                        selectedOptions.append(
                                            '<div class="custom-control custom-radio" title="' + this['Description'] + '">' +
                                            '<input type="radio" class="custom-control-input" id="task_' + this['ActivityId'] + '" name="task" value="' + this['ActivityId'] + '" onchange="app.GeneralCase.Enable();">' +
                                            '<label class="custom-control-label" for="task_' + this['ActivityId'] + '">' + this['Name'] + '</label>' +
                                            '</div>');
                                    });
                                    break;
                                case 2: //Lista de chequeo
                                    $('.mode-simple').addClass('d-none');
                                    $.each(data.Tasks, function () {
                                        selectedOptions.append(
                                            '<div class="custom-control custom-checkbox" title="' + this['Description'] + '">' +
                                            '<input type="checkbox" class="custom-control-input" id="task_' + this['ActivityId'] + '" name="task" value="' + this['ActivityId'] + '" ' + (this['FinishDate'] === null ? '' : 'checked') + ' onchange="app.GeneralCase.Checked(' + this['ActivityId'] + ');">' +
                                            '<label class="custom-control-label" for="task_' + this['ActivityId'] + '">' + this['Name'] + '</label>' +
                                            '</div>');
                                    });
                                    break;
                            }

                            $('#ChangeStage').removeClass('d-none');
                            //$('#entry').removeClass('d-none');
                            $('fieldset').prop("disabled", false);
                        }
                        else {
                            $('#ChangeStage').addClass('d-none');
                            $('#tabs li:nth-child(2) a').tab('show');
                            $('#tabs li:nth-child(1) a').addClass('d-none');
                            if (current.length == 0) {
                                $('#CurrentStep').html(data.Steps[data.Steps.length - 1].Name);
                            }
                        }
                    }
                    $(".progress-bar").width(data.Progress + '%');
                    $(".progress-bar").prop('title', data.Progress + '%');
                    $(".progress-bar").html(data.Progress + '%');
                } else {
                    $('#ProcessGridTbl').bootstrapTable('load', []);
                }
                if (callbackDone) {
                    callbackDone(data, _allowref, _currentStep)
                };
            }).always(function () {
                $('#ProcessGridTbl').bootstrapTable('hideLoading');
            });
    }

}