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
                    render_Ham_menu(data);
                });
        else
            render_main_menu(JSON.parse(cache));
        render_Ham_menu(JSON.parse(cache));
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

                sideMenu.append('<nav class=" ResElement megamenu megamenu_desktop" id="' + itemParent.Code + '"' + isActiveClass + '><div class="menu dropdown"><input type="checkbox" id="' + (itemParent.MenuTitle === '' ? itemParent.Title : itemParent.MenuTitle) + '" class="inputche d-none"><label class="level_1__item level_2__small" for="' + (itemParent.MenuTitle === '' ? itemParent.Title : itemParent.MenuTitle) + '"> <a class="level_1__link  dropdown-toggle"' + '" title="' + itemParent.Description + '">' + '<i class=" mr-1 ' + itemParent.SmallImage + '"></i> ' + (itemParent.MenuTitle === '' ? itemParent.Title : itemParent.MenuTitle) + '</a></label><ul class="menu-dropdown" aria-expanded="false"></ul></div></nav>');

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
                sideMenu.append('<nav class=" ResElement megamenu megamenu_desktop" id="' + itemParent.Code + '"' + isActiveClass + '><div class="menu"><ul class="level_1 sf-js-enabled sf-arrows" >  <li class="level_1__item level_2__small" style="display: inline-block;"> <a class="level_1__link" href="' + href + '" title="' + itemParent.Description + '">' + '<i class="  mr-1 ' + itemParent.SmallImage + '"></i> ' + (itemParent.MenuTitle === '' ? itemParent.Title : itemParent.MenuTitle) + '</a></li></ul></div></nav>');

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
                itemObj.append('<li id="' + item.Code + '"' + isActiveClass + '><a  href="' + href + '" title="' + item.Description + '">' + '<i class=" mr-1 ' + item.SmallImage + '"></i> ' + (item.MenuTitle === '' ? item.Title : item.MenuTitle) + '</a></li>');
            });
        });
        sideMenu.metisMenu();
        rendmoremenu();
    };

    function rendmoremenu() {
        var boxs = document.getElementsByClassName('ResElement');
        var ham_menu = document.getElementById('container_moremenu');
        var prin_box = document.getElementById('moremenubox');
        prin_box.setAttribute('style', 'display:none')

        for (let i = boxs.length - 1; i > 0; i--) {
            if (boxs[i].offsetTop > 31) {
                boxs[i].children[0].children[0].checked = false
                var newelement = boxs[i].cloneNode("megamenu megamenu_desktop");
                newelement.setAttribute('class', 'megamenu_desktop')
                newelement.setAttribute('id', 'hamcheck' + (i + 1))
                newelement.children[0].children[0].setAttribute('id', 'hamcheck_' + newelement.children[0].children[0].getAttribute('id'))
                newelement.children[0].children[1].setAttribute('for', newelement.children[0].children[0].getAttribute('id'))
                newelement.children[0].children[2].setAttribute('class', 'menu-dropdown ham')
                var exit = document.getElementById(newelement.getAttribute('id'));
                if (!(exit)) {
                    ham_menu.appendChild(newelement)
                    prin_box.setAttribute('style', ' ')
                }
            }
            else {
                var exitham = document.getElementById('hamcheck' + (i + 1));
                if (exitham) {
                    ham_menu.removeChild(exitham)
                }
            }
        }
    }

    function render_Ham_menu(data) {
        var Ham_menu = $('#MenuVertical');

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

                Ham_menu.append('<hr class="linside"><nav class= "megamenu megamenu_desktop" id = "' + itemParent.Code + '"' + isActiveClass + ' > <div class="menu dropdown"><input type="checkbox" id="ham' + (itemParent.MenuTitle === '' ? itemParent.Title : itemParent.MenuTitle) + '" class="inputche d-none"><label class="level_1__item level_2__small" for="ham' + (itemParent.MenuTitle === '' ? itemParent.Title : itemParent.MenuTitle) + '"> <a class="level_1__link  dropdown-toggle"' + '" title="' + itemParent.Description + '">' + '<i class=" mr-1 ' + itemParent.SmallImage + '"></i> ' + (itemParent.MenuTitle === '' ? itemParent.Title : itemParent.MenuTitle) + '</a></label><ul class="menu-dropdown ham" aria-expanded="false"></ul></div></nav >');


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
                Ham_menu.append('<hr class="linside"><nav class="megamenu ham_megamenu megamenu_desktop" id="' + itemParent.Code + '"' + isActiveClass + '><div class="menu"><ul class="level_1 sf-js-enabled sf-arrows" >  <li class="level_1__item level_2__small" style="display: inline-block;"> <a class="level_1__link" href="' + href + '" title="' + itemParent.Description + '">' + '<i class=" mr-1 ' + itemParent.SmallImage + '"></i> ' + (itemParent.MenuTitle === '' ? itemParent.Title : itemParent.MenuTitle) + '</a></li></ul></div></nav>');

            }
            var itemObj = Ham_menu.find('#' + itemParent.Code + ' ul');

            $.each(menuItems, function (index, item) {

                if (path === app.setting.basepath + item.URLPath) {
                    isActiveClass = ' class="active"';
                    Ham_menu.find('#' + itemParent.Code + ' ul').attr("aria-expanded", "false");
                    Ham_menu.find('#' + itemParent.Code + ' ul').addClass("in");
                    Ham_menu.find('#' + itemParent.Code).addClass("active");
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
                itemObj.append('<li id="' + item.Code + '"' + isActiveClass + '><a  href="' + href + '" title="' + item.Description + '">' + '<i class=" mr-1 ' + item.SmallImage + '"></i> ' + (item.MenuTitle === '' ? item.Title : item.MenuTitle) + '</a></li>');
            });
        });
        Ham_menu.metisMenu();
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
                app.core.Get(app.setting.apipath + 'v1/Colors/GetColor')
                    .done(function (data, textStatus, jqXHR) {
                        ListaElementos = data;
                        var Tenant = localStorage.getItem("Tenant")
                        for (var a in ListaElementos) {
                            for (var prop in ListaElementos[a]) {
                                var object = ListaElementos[a]
                                if (object[prop] == Tenant) {
                                    document.getElementById('logotenantHead').innerHTML = ['<img class="thumb" src= "' + object['Logo'] + '"/>']
                                }
                            }
                        }

                    })



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

                //$('#wheelChair').click(function () {
                //    WheelChair()
                //});

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


///////////////////////////////////////NEW COLORS TENAT/////////////////////////////////

app.core.Get(app.setting.apipath + 'v1/Colors/GetColor')
    .done(function (data, textStatus, jqXHR) {
        var ListaElementos = data;
        var Tenant = localStorage.getItem('Tenant')
        for (var a in ListaElementos) {
            for (var prop in ListaElementos[a]) {
                var object = ListaElementos[a]
                if (object[prop] == Tenant) {
                    document.documentElement.style.setProperty('--mapfrered1', object['Color1'])
                    document.documentElement.style.setProperty('--mapfrered2', object['Color2'])
                }
            }
        }

    })

//function WheelChair() {
//    $(".fa-wheelchair").click(function () {
//        $("#buttonsToDisplay").fadeIn(500);
//    });
//    $(".fa-wheelchair").dblclick(function () {
//        $("#buttonsToDisplay").fadeOut(500)
//    });

//    $(".btnEspaciado").click(function () {
//        $("p").css({ "letter-spacing": "1em" });
//    });


//    //Functionality
//    const getFontSize = () =>
//        parseFloat(getComputedStyle(document.documentElement)
//            .getPropertyValue('--font-size'))

//    const fontUp = element => {
//        element.addEventListener('click', () => {
//            let fontSize = getFontSize()
//            document.documentElement.style.setProperty('--font-size', `${fontSize * 1.1}`)
//        })
//    }

//    const fontDown = element => {
//        element.addEventListener('click', () => {
//            let fontSize = getFontSize()
//            document.documentElement.style.setProperty('--font-size', `${fontSize * 0.95}`)
//        })
//    }

//    addEventListener('keyup', e => {
//        if (e.key === 'ArrowUp') document.getElementById('font-up').click()
//        if (e.key === 'ArrowDown') document.getElementById('font-down').click()
//    })

//    fontUp(document.getElementById('font-up'))
//    fontDown(document.getElementById('font-down'))
//}
