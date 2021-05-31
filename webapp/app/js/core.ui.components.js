var app = app || {};
app.ui.components = {};
app.ui.components = (function () {

    function ChangeSetDataRefresh() {
        var filter = $('#ChangeSetSearch').val();
        $('#ChangeSetModal').modal('show')
        $('#ChangeSetGridTbl').bootstrapTable('showLoading');
        app.core.Get(app.setting.apipath + 'v1/Common/ChangeSets?entityType=' + app.state.entityType + '&filter=' + filter)
            .done(function (data, textStatus, jqXHR) {
                $('#ChangeSetGridTbl').bootstrapTable('load', data !== null ? data : []);
            }).always(function () {
                $('#ChangeSetGridTbl').bootstrapTable('hideLoading');
                $('#ChangeSetModal').modal('handleUpdate');
            });
    };

    return {
        ShowModalChangeSet: function (entityType) {
            var modal = $(".ibox-content").find('#ChangeSetModal');

            if ($(".ibox-content").find('#ChangeSetModal').length === 0) {
                app.state.entityType = entityType;
                app.core.GetView(app.setting.viewpath + 'Core/ChangeSet')
                    .done(function (data, textStatus, jqXHR) {
                        $(".ibox-content").append(data);

                        $("#ChangeSetSearch").on('keyup', function (event) {
                            if (event.keyCode == 13)
                                ChangeSetDataRefresh();
                        });
                        $('#ChangeSetApplyFilter').on('click', function () {
                            ChangeSetDataRefresh();
                        });
                        ChangeSetDataRefresh();
                    });
            }
            else
                ChangeSetDataRefresh();
        }
    };
})();