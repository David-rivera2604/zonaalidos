var app = app || {};

app.Extend = (function () {

    return {
        EmisionFormatter: function (value, row, index, field) {
            let quote = '', mode ='resume';
            switch (row.COD_RAMO) {
                case 302:
                    quote = 'mapfremas';
                    mode = localStorage.getItem('Roles').includes('Purdy') || localStorage.getItem('Roles').includes('Davivienda_Prendarios') || localStorage.getItem('Roles').includes('Davivienda_Leasing') ? 'continue' : 'resume';
                    break;
                case 401:
                    quote = 'saldodeudor';
                    break;
                case 441:
                    quote = 'viajero';
                    break;
            }
            return quote != '' ? '<a href=' + app.setting.basepath + 'emision/' + quote
                + '?mode=' + mode
                + '&presupuesto=' + row.NUM_PRESUPUESTO + '>' + value + '</a>' : row.NUM_PRESUPUESTO;
        }
    };
})();