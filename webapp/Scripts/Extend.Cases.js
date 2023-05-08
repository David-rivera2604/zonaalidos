var app = app || {};

app.Ex_Cases = (function () {

    return {
        EtapaFormatter: function (value, row, index, field) {
            let result = '<span';

            if (row.STEPFINISHDATE != null)
                result += ' style="text-decoration: line-through;color: gray"';
            result += '>' + value + '</span> ';
            //if (row.STEPFINISHDATE == null)
            //    result += '<span class="badge badge-warning float-right"><small> Pendiente  </small></span>';

            if (row.STEPFINISHDATE != null) 
                result += '<br> Realizado por ' + app.ui.UpdateDateAndUserFormatter(row.STEPFINISHDATE, row, index, field);

            return result ;
        }
    };
})();
