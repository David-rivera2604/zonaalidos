var app = app || {};

app.ProcessInstance = (function () {

    var _typeId = 0;
    var _id = 0;

    function Refresh(typeId, id, callback) {
        if (typeId == 0 || id == 0) {
            return;
        }
        _typeId = typeId;
        _id = id;
        $('#VisualizationsEdtForm').addClass('d-none');
        // $('#ProcessGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + `v1/Process/instance/Entity/${_typeId}/${_id}/3`)
            .done(function (data, textStatus, jqXHR) {

                if (data.Steps) {

                    $('#ProcessGridTbl').bootstrapTable('load', data.Steps);

                    if (data.Tasks.length > 0) {
                        $('#VisualizationsEdtForm').removeClass('d-none');
                        $('#tasks').empty();
                        $('#Annotation').val('');
                        selectedOptions = $('#tasks');
                        $.each(data.Tasks, function () {
                            selectedOptions.append(
                                '<div class="custom-control custom-radio">' +
                                '<input type="radio" class="custom-control-input" id="task_' + this['ActivityId'] + '" name="task" value="' + this['ActivityId'] + '">' +
                                '<label class="custom-control-label" for="task_' + this['ActivityId'] + '">' + this['Name'] + '</label>' +
                                '</div>');
                        });
                    }
                } else {
                    $('#ProcessGridTbl').bootstrapTable('load', []);
                }
                if (callback != undefined) {
                    callback(data);
                }
            }).always(function () {
                $('#ProcessGridTbl').bootstrapTable('hideLoading');
            });

    }

    function TaskChecked(activityId, comment) {
        app.core.Put(app.setting.apipath + `v1/Process/Task/Checked/Entity/${_typeId}/${_id}`,
            JSON.stringify({
                ActivityId: activityId,
                Comment: comment
            }))
            .done(function (data, textStatus, jqXHR) {
                Refresh(_typeId, _id);
            }).always(function () {
                app.ui.ButtonDone('#VisualizationsEdtFormSave');
            });
    }

    function Init_Controls() {
        $('#VisualizationsEdtFormSave').click(function () {
            event.preventDefault();
            app.ui.ButtonDoing('#VisualizationsEdtFormSave');
            TaskChecked(app.ui.GetRadioNumericValue('task'), $('#Annotation').val());
            //setTimeout(function () { app.ui.ButtonDone('#VisualizationsEdtFormSave'); }, 3000);
        });
    };

    function Init_List() {

        $('#ProcessGridTbl').bootstrapTable({
            uniqueId: 'ActivityId',
            pagination: false,
            //search: true,
            //showRefresh: true,
            smartDisplay: true,
            //detailView: false,
            //detailFormatter: 'app.ui.GenericDetailFormatter',
            //headerStyle: function (column) {
            //    return {
            //        css: {
            //            'background': 'lightsteelblue'
            //        }
            //    }
            //},
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
                    //cellStyle: function (value, row, index) {
                    //    return {
                    //        css: {
                    //            'background': 'lightsteelblue'
                    //        }
                    //    }
                    //},
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
                            if (row.Comments != '') {
                                result = result + '<div class="d-block d-sm-none" style="margin: 0 20px;">Comentario:<small class="text-muted" style="font-style: italic;"> ' + row.Comments + '</small></div>';
                                result = result + '<div class="d-none d-sm-block" style="margin: 0 26px;"><small class="text-muted" style="font-style: italic;"> ' + row.Comments + '</small></div>';
                            }
                        }

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
            //, {
            //    field: 'Comments',
            //    title: 'Comentario',
            //    sortable: false,
            //    halign: 'center',
            //    align: 'left',
            //}]
        });
    };

    function Init_Lookups() {
    };

    function Event_Controls() {
    };

    function Setup_Validations() {
    };

    return {
        Init: function () {
            Init_Controls();
            Init_List();
            Init_Lookups();
            Event_Controls();
            Setup_Validations();

            Refresh(app.core.URLNumericValue('type'), app.core.URLNumericValue('id'));
        },
        InternalLoad: function () {
            Refresh(app.core.URLNumericValue('type'), app.core.URLNumericValue('id'));
        },
        Load: function (typeId, id, callback) {
            Refresh(typeId, id, callback);
        }
    };
})();
