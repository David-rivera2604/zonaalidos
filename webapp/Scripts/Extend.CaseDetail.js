var app = app || {};

app.Ex_CaseDetail = (function () {
    return {
        Boton: function () {
            return {
                btnExclude: {
                    text: 'Descargar archivo excel',
                    icon: 'fa-chain-broken',
                    event: function () {
                        let data = app.Prototype1.Data();
                        let url = '';
                        for (var p in data) {
                            if (data.hasOwnProperty(p)) {
                                url += ':' + p + '=' + data[p];
                            }
                        }
                        if (url != undefined)
                            url = url.replace(/T00:00:00/g, '');
                        console.log(url);
                        $('.ibox-content').toggleClass('sk-loading');
                        app.core.GetPDF(app.setting.apipath + 'v1/DataSource/excel?id=4002&url=id=4002' + url, true, 'Detalle por caso.xlsx',
                            function () {
                                $('.ibox-content').toggleClass('sk-loading');
                            });
                    },
                    attributes: {
                        title: 'Permite descargar la información en forma de un archivo excel'
                    }
                }
            };
        },
        Export: function () {
            return {
                btnExclude: {
                    text: 'Descargar archivo excel',
                    icon: 'fa-chain-broken',
                    event: function () {
                        let _id = app.core.URLStringValue('id');
                        let url = `id=${_id}&export=yes`;
                        console.log(url);
                        $('.ibox-content').toggleClass('sk-loading');
                        app.core.GetPDF(app.setting.apipath + `v1/DataSource/excel?id=${_id}&url=id=${_id}:export=1`, true, 'casos.xlsx',
                            function () {
                                $('.ibox-content').toggleClass('sk-loading');
                            });
                    },
                    attributes: {
                        title: 'Permite descargar la información en forma de un archivo excel'
                    }
                }
            };
        },
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
