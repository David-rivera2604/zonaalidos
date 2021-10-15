var app = app || {};

app.DashboardUsers = (function () {

    return {
        Init: function () {


            //app.core.GetExt(app.setting.apipath + 'v1/Security/Sessions')
            app.core.Get(app.setting.basepath + 'api/v1/Security/Sessions')
                .done(function (data, textStatus, jqXHR) {


                    let active = data.filter(function (e) { return !e.Expired })
                    let errors = data.filter(function (e) { return e.ErrorCode != null })
                    let errorsactive = errors.filter(function (e) { return !e.Expired })


                    let inicio = data.reduce(function (a, b) { return a.InitDateTime < b.InitDateTime ? a : b; });
                    let ultima = data.reduce(function (a, b) { return a.LastDateTime > b.LastDateTime ? a : b; });

                    let info = {
                        Desde: inicio.InitDateTime,
                        Hasta: ultima.LastDateTime,
                        TotalSesiones: data.length,
                        Activas: active.length,
                        ActivasError: errorsactive.length,
                        Expiradas: data.length - active.length,
                        ExpiradasError: errors.length - errorsactive.length
                    };

                    $('#tmpl')
                        .append(`Desde=${info.Desde}</br>`)
                        .append(`Hasta=${info.Hasta}</br>`)
                        .append(`Sesiones=${info.TotalSesiones}</br>`)
                        .append(`. Activas=${info.Activas}</br>`)
                        .append(`. Activas con errores=${info.ActivasError}</br>`)
                        .append(`. Expiradas=${info.Expiradas}</br>`)
                        .append(`. Expirados con errores=${info.ExpiradasError}</br>`)

                    let unique = [...new Set(data.map(item => item.CompanyId))].sort().map(id => { return { CompanyId: id, CompanyName: data.find(s => s.CompanyId === id).CompanyName } });

                    for (var i = 0; i < unique.length; i++) {

                        unique[i].Sesiones = data.filter(function (e) { return e.CompanyId == unique[i].CompanyId }).length;
                        unique[i].Activas = data.filter(function (e) { return e.CompanyId == unique[i].CompanyId && !e.Expired }).length;
                        unique[i].ActivasError = data.filter(function (e) { return e.CompanyId == unique[i].CompanyId && !e.Expired && e.ErrorCode != null }).length;
                        $('#tmpl')
                            .append(`#  ${unique[i].CompanyName} ${unique[i].Sesiones}, ${unique[i].Activas} activas y ${unique[i].ActivasError} errores </br>`);
                    }
                    $('#tmpl').append(`</br>`)
                    for (var i = 0; i < errorsactive.length; i++) {
                        $('#tmpl')
                            .append(`<h4 style='color: red'>${i} ${errorsactive[i].ErrorTime} ${errorsactive[i].CompanyName} ${errorsactive[i].UserName}</h4>`)
                            .append(`<p style='margin-left: 20px; color: darkred'>${errorsactive[i].ErrorDetail}</p>`);
                    }

                    active = active.sort((a, b) => a.CompanyId < b.CompanyId ? - 1 : Number(a.CompanyId > b.CompanyId));
                    $('#tmpl').append(`</br>`)
                    let color = '';
                    for (var i = 0; i < active.length; i++) {
                        color = active[i].ErrorCode === null ? 'blue' : 'red';
                        $('#tmpl')
                            .append(`<h5 style='color: ${color}'>${i} ${active[i].LastDateTime} ${active[i].CompanyName} ${active[i].UserName} ${active[i].Navigation}</h5>`)
                    }
                });


        }
    };
})();
