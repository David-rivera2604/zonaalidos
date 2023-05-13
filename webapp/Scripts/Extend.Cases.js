var app = app || {};

app.Ex_Cases = (function () {

    return {
        Eliminar: function (row) {
            toastr.warning(`Si está seguro de querer eliminar el caso '${row.TITLE}' haga clic aquí`, null,
                {
                    timeOut: 5000, closeButton: true, progressBar: true,
                    onclick: function () {
                        $('.ibox-content').toggleClass('sk-loading');
                        app.core.Delete(`${app.setting.apipath}v1/ProcessCase/${row.ID}`)
                            .done(function (data, textStatus, jqXHR) {
                                toastr.success(`El caso '${row.TITLE}' fue eliminado`, "", { timeOut: 5000, closeButton: true, progressBar: true });
                                //Por mejorar para que sea mas dinamico
                                app.ViewerQuery.Refresh(undefined, $('#1GridTbl'), 4003, '', 1);
                            }).always(function () {
                                $('.ibox-content').toggleClass('sk-loading');
                            });
                    }
                });
        },
        EtapaFormatter: function (value, row, index, field) {
            let result = '<span';

            if (row.STEPFINISHDATE != null)
                result += ' style="text-decoration: line-through;color: gray"';
            result += '>' + value + '</span> ';
            //if (row.STEPFINISHDATE == null)
            //    result += '<span class="badge badge-warning float-right"><small> Pendiente  </small></span>';

            if (row.STEPFINISHDATE != null)
                result += '<br> Realizado por ' + app.ui.UpdateDateAndUserFormatter(row.STEPFINISHDATE, row, index, field);

            return result;
        }
    };
})();
