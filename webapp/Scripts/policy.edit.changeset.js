var app = app || {};
app.changeset = (function () {

    var id = 0;

    function Init_Controls() {
    };

    function Init_Lookups() {
        // Dependencies
    };

    function Event_Controls() {
    };

    function Dynamic_Event_Controls() {
    };

    function Setup_Validations() {
    };

    var _load = function (internalId) {
        id = internalId;
        app.core.Get(app.setting.apipath + 'v1/Common/ChangeSets?entityType=2000&entityId=' + internalId, null,
            function (data) {
                var info = '';
                $('#Historial tbody').html('');
                $.each(data, function (index, row) {
                    info = row.Action + '.' ;
                    if (row.Summary !== '')
                        info = info + ' ' + row.Summary + '.';

                    $('#Historial tbody').append('<tr><td>' + moment(row.UpdateDate).format('DD/MM/YYYY hh:mma') + '</td><td>' + info  + '</td><td>' + row.UpdateUserName + ' <small class="text-muted">' + moment(row.UpdateDate).from() + '</small></td></tr>');
                });
                $('#Historial').footable();
            });
    };

    return {
        Init: function () {
            Init_Controls();
            Init_Lookups();
            Event_Controls();
            Dynamic_Event_Controls();
            Setup_Validations();

            var _id = app.core.URLNumericValue('id');
            if (_id !== 0)
                _load(_id);
        },
        Load: function (internalId) {           
            _load(internalId);
        }

    };
})();
$(document).ready(function () {
    app.changeset.Init();
});
