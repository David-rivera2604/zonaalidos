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
        let href;
        $.each(mainMenuItems, function (index, itemParent) {
            isActiveClass = '';


            var menuItems = data.filter(function (subitem) {
                return subitem.ParentCode == itemParent.Code;
            });

            if (menuItems.length > 0) {
                sideMenu.append('<li id="' + itemParent.Code + '"' + isActiveClass + '><a href="#" aria-expanded="false"><i class="' + itemParent.SmallImage + '"></i><span class="nav-label">' + itemParent.Title + '</span><span class="fa arrow"></span></a><ul class="nav nav-second-level collapse" aria-expanded="false"></ul></li>');
            }
            else {
                if (path === app.setting.basepath + itemParent.URLPath)
                    isActiveClass = ' class="active"';
                else
                    isActiveClass = '';
                if (itemParent.URLPath.startsWith('SideBar:')) {
                    href = "javascript:app.master.ShowSide('" + itemParent.Title + "', '" + itemParent.URLPath.substring(8) + "');";
                } else if (itemParent.URLPath.startsWith('SideBarExternal:')) {
                    href = "javascript:app.master.ShowSideBarExternal('" + itemParent.Title + "', '" + itemParent.URLPath.substring(16) + "');";
                } else {
                    href = app.setting.basepath + itemParent.URLPath;
                }
                sideMenu.append('<li id="' + itemParent.Code + '"' + isActiveClass + '><a href="' + href + '" title="' + itemParent.Description + '">' + '<i class="' + itemParent.SmallImage + '"></i>' + (itemParent.MenuTitle === '' ? itemParent.Title : itemParent.MenuTitle) + '</a></li>');
            }
            var itemObj = sideMenu.find('#' + itemParent.Code + ' ul');

            $.each(menuItems, function (index, item) {

                if (path === app.setting.basepath + item.URLPath) {
                    isActiveClass = ' class="active"';
                    sideMenu.find('#' + itemParent.Code + ' ul').attr("aria-expanded", "false");
                    sideMenu.find('#' + itemParent.Code + ' ul').addClass("in");
                    sideMenu.find('#' + itemParent.Code).addClass("active");
                }

                else
                    isActiveClass = '';
                if (item.Type == 9) {
                    href = "javascript:app.master.ShowSideBar('" + item.Title + "', " + item.URLPath + ");";
                } else if (item.Type == 8) {
                    href = "javascript:app.master.ShowSideBarExternal('" + item.Title + "', " + item.URLPath + ");";
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
                window.location.replace(app.setting.basepath + 'Security/Login?logout=y');
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
                    window.location.replace(app.setting.basepath + 'Security/Login?logout=y');
                } else if (data <= 90) {
                    data = 60;
                    var iinterval = parseInt(data) * 1000;
                    toastr.info("Su sesión se cerrará en " + data + " segundos, si desea mantenerla haga clic aquí", 'Sesión', { timeOut: iinterval, closeButton: true, progressBar: true, onclick: function () { timeout_verify('?force=true'); } });
                    token_timeout(iinterval);
                }
                else {
                    //console.log("extender");
                    //console.log(data);
                    var dt = new Date();
                    var iinterval = (data + 10) * 1000;
                    //console.log(dt);
                    dt = new Date(dt.getTime() + iinterval);
                    //console.log(dt);
                    localStorage.setItem('Expires', dt);
                    token_timeout(10000);
                }
            });
    };

    return {
        Init: function () {
            var name = localStorage.getItem('Tenant');
            name = name.replace('á', 'a');

            if ($('#tenantLogo').length > 0) {
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
                    $('#right-sidebar').addClass('d-none');
                });

                $('#showHelp').click(function () {
                    event.preventDefault();
                    window.open(app.setting.viewpath + 'help/index', "Ayuda", "left=200, width=750, height=550, titlebar=no, location=NO,resizable,scrollbars,status");
                });
            }
        },
        ShowSideBar: function (title, id) {
            app.ui.ShowSideBar({ title: title, subtitle: '', id: id, data: null })
        },
        ShowSideBarExternal: function (title, url) {
            let width = app.core.URLValue('wd', url);
            app.ui.ShowSideBar({ title: title, subtitle: '', url: url, width: width, isExternal: true })
        }
    };
})();
$(document).ready(function () {
    app.master.Init();
});
