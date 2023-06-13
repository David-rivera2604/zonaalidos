window.addEventListener('click', function (e) {
    var boxs = document.getElementsByClassName('menu dropdown');
    for (let i = 0; i < boxs.length; i++) {
        if (!(boxs[i].contains(e.target))) {
            boxs[i].children[0].checked = false
        }
    }
});

window.addEventListener('resize', function (e) {
    rendmoremenu();
});

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
            prin_box.setAttribute('style', ' ')
            if (!(exit)) {
                ham_menu.appendChild(newelement)
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
