var app = app || {};
app.master = (function () {
    var timerId;

    function activateActivityTracker() {
        window.addEventListener("mousemove", userActivityThrottler);
        window.addEventListener("scroll", userActivityThrottler);
        window.addEventListener("keydown", userActivityThrottler);
        window.addEventListener("resize", userActivityThrottler);
        window.addEventListener("beforeunload", deactivateActivityTracker);
    };
    function deactivateActivityTracker() {
        window.removeEventListener("mousemove", userActivityThrottler);
        window.removeEventListener("scroll", userActivityThrottler);
        window.removeEventListener("keydown", userActivityThrottler);
        window.removeEventListener("resize", userActivityThrottler);
        window.removeEventListener("beforeunload", deactivateActivityTracker);
    };
    function userActivityThrottler() {
        var dta = new Date();
        localStorage.setItem('LastActivity', dta);
    };

    function main_menu() {
        var cache = localStorage.getItem("Navegation");

        if (cache === null)
            app.core.Get(app.setting.apipath + 'v1/Security/NavegationAllowed')
                .done(function (data, textStatus, jqXHR) {
                    localStorage.setItem('Navegation', JSON.stringify(data));
                    render_main_menu(data);
                });
        else
            render_main_menu(JSON.parse(cache));
    };

    function render_main_menu(data) {
        var sideMenu = $('#side-menu');

        var mainMenuItems = data.filter(function (item) {
            return item.ParentCode == "";
        });
        var path = window.location.pathname + window.location.search;
        var isActiveClass = '';

        $.each(mainMenuItems, function (index, itemParent) {
            if (path.startsWith(app.setting.basepath + itemParent.URLPath))
                isActiveClass = ' class="active"';
            else
                isActiveClass = '';
            sideMenu.append('<li id="' + itemParent.Code + '"' + isActiveClass + '><a href="#" aria-expanded="false"><i class="' + itemParent.SmallImage + '"></i><span class="nav-label">' + itemParent.Title + '</span><span class="fa arrow"></span></a><ul class="nav nav-second-level collapse" aria-expanded="false"></ul></li>');

            var itemObj = sideMenu.find('#' + itemParent.Code + ' ul');

            var menuItems = data.filter(function (subitem) {
                return subitem.ParentCode == itemParent.Code;
            });
            let href;
            $.each(menuItems, function (index, item) {
                if (item.URLPath.startsWith("viewer/index")) {
                    $('#side-menu').find("#" + itemParent.Code).addClass("active");
                }
                if (path === app.setting.basepath + item.URLPath)
                    isActiveClass = ' class="active"';
                else
                    isActiveClass = '';
                if (item.Type == 9) {
                    href = "javascript:app.master.ShowSideBar('" + item.Description + "', " + item.URLPath + ");";
                } else {
                    href = app.setting.basepath + item.URLPath;
                }
                itemObj.append('<li id="' + item.Code + '"' + isActiveClass + '><a href="' + href + '" title="' + item.Description + '">' + '<i class="' + item.SmallImage + '"></i>' + (item.MenuTitle === '' ? item.Title : item.MenuTitle) + '</a></li>');
            });
        });
        sideMenu.metisMenu();
    };

    function token_timeout(interval) {
        timerId = setInterval(function () {
            var remaining = Date.parse(localStorage.getItem("Expires")) - new Date();
            var stimeout = Math.floor(remaining / 1000);
            //console.log(new Date());
            //console.log(localStorage.getItem("Expires"));
            //console.log(localStorage.getItem("LastActivity"));
            //console.log(remaining);
            //console.log(Math.floor(remaining / 1000));
            if (Math.floor(remaining / 1000) <= 0) {
                clearInterval(timerId);
                localStorage.setItem('reason', 'session-expired');
                window.location.replace(app.setting.basepath + 'Security/Login');
            }
            else if (stimeout <= 90) {
                timeout_verify('');
            }
        }, interval);
    };

    function timeout_verify(option) {
        clearInterval(timerId);
        app.core.Get(app.setting.apipath + 'v1/Security/IsLive' + option)
            .done(function (data, textStatus, jqXHR) {
                if (data <= 30) {
                    localStorage.setItem('reason', 'session-expired');
                    window.location.replace(app.setting.basepath + 'Security/Login');
                } else if (data <= 90) {
                    data = 60;
                    var iinterval = parseInt(data) * 1000;
                    toastr.info("Su sesión se cerrará en " + data + " segundos, si desea mantenerla haga clic aquí", 'Sesión', { timeOut: iinterval, closeButton: true, progressBar: true, onclick: function () { timeout_verify('?force=true'); } });
                    token_timeout(iinterval);
                }
                else {
                    console.log("extender");
                    console.log(data);
                    var dt = new Date();
                    var iinterval = (data + 10) * 1000;
                    console.log(dt);
                    dt = new Date(dt.getTime() + iinterval);
                    console.log(dt);
                    localStorage.setItem('Expires', dt);
                    token_timeout(10000);
                }
            });
    };

    return {
        Init: function () {
            var name = localStorage.getItem('Tenant');
            name = name.replace('á', 'a');

            $('#tenantLogo').attr('src', $('#tenantLogo').attr('src').replace('core', name))

            $('#UserNameMaster').html(localStorage.getItem('Username'));
            $('#TenantMaster').html(localStorage.getItem('Tenant'));

            main_menu();
            token_timeout(10000);

            activateActivityTracker();

            $('.close-link-sidebar').click(function () {
                event.preventDefault();
                $('#right-sidebar').toggleClass('sidebar-open');
                $('.sidebar-content').replaceWith('<div class="ibox-content sidebar-content"><div class="sk-spinner sk-spinner-wave"><div class="sk-rect1"></div><div class="sk-rect2"></div><div class="sk-rect3"></div><div class="sk-rect4"></div><div class="sk-rect5"></div></div></div>');
            });

            $('#showHelp').click(function () {
                event.preventDefault();
                window.open(app.setting.viewpath + 'help/index', "Ayuda", "left=200, width=750, height=550, titlebar=no, location=NO,resizable,scrollbars,status");
            });
        },
        ShowSideBar: function (title, id) {
            app.ui.ShowSideBar({ title: title, subtitle: '', id: id, data: null })
        }
    };
})();
$(document).ready(function () {
    app.master.Init();
});
