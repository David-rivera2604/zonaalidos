/**
 * Aliados — Notification Center v2.0
 * Transporte: SignalR exclusivo. Sin polling.
 * Init: Aliados.Notifications.init(userId, companyId);
 */
var Aliados = Aliados || {};

Aliados.Notifications = (function () {
    'use strict';

    var _userId    = 0;
    var _companyId = 0;
    var _unreadCount = 0;
    var _apiBase   = '/Aliados/api/v1/Notifications';

    // ── AUTH ────────────────────────────────────────────────────────────────

    function _token()  { return localStorage.getItem('Token') || ''; }
    function _headers() { return { 'Authorization': 'Bearer ' + _token() }; }

    function _get(url, success, fail) {
        $.ajax({ url: url, type: 'GET', headers: _headers(),
            success: success,
            error: fail || function(xhr) { console.warn('[Notif] GET ' + url + ' -> ' + xhr.status); }
        });
    }

    function _patch(url, success) {
        $.ajax({ url: url, type: 'PATCH', headers: _headers(),
            success: success,
            error: function(xhr) { console.warn('[Notif] PATCH ' + url + ' -> ' + xhr.status); }
        });
    }

    // ── INIT ────────────────────────────────────────────────────────────────

    function init(userId, companyId) {
        _userId    = userId;
        _companyId = companyId;

        if (!_userId || _userId <= 0) {
            console.warn('[Notif] userId invalido — no se inicializa.');
            return;
        }

        // Carga inicial del contador y lista
        _loadUnreadCount();
        _bindEvents();
        _ensureToastWrapper();

        // SignalR obligatorio
        if (typeof $.connection !== 'undefined' && typeof $.connection.notificationHub !== 'undefined') {
            _initSignalR();
        } else {
            console.error('[Notif] SignalR no disponible. Instalar Microsoft.AspNet.SignalR.');
        }
    }

    // ── SIGNALR ─────────────────────────────────────────────────────────────

    function _initSignalR() {
        $.connection.hub.qs = { userId: _userId };
        var hub = $.connection.notificationHub;

        // Servidor -> Cliente: notificacion nueva
        hub.client.receiveNotification = function (n) {
            _unreadCount++;
            _updateBadge(true);
            _showToast(n);
            console.log('[Notif] Nueva notificacion recibida:', n.Type);
        };

        // Servidor -> Cliente: actualizar solo el badge
        hub.client.updateUnreadCount = function (count) {
            _unreadCount = count;
            _updateBadge(false);
        };

        // ── Blindaje SignalR: reintentos y captura silenciosa de errores ───────
        var _maxRetries = 3;
        var _retryCount = 0;

        function _startHub() {
            try {
                $.connection.hub.start()
                    .done(function () {
                        _retryCount = 0;
                        console.log('[Notif] SignalR conectado userId=' + _userId);
                    })
                    .fail(function () {
                        console.warn('[Notif] Fallo SignalR (intento ' + (_retryCount + 1) + '/' + _maxRetries + ').');
                    });
            } catch (e) {
                console.warn('[Notif] Error al iniciar SignalR:', e);
            }
        }

        _startHub();

        $.connection.hub.disconnected(function () {
            if (_retryCount < _maxRetries) {
                _retryCount++;
                console.warn('[Notif] Reconectando en 5s (intento ' + _retryCount + '/' + _maxRetries + ')...');
                setTimeout(function () {
                    try { _startHub(); } catch (e) { console.warn('[Notif] Error en reconexion:', e); }
                }, 5000);
            } else {
                console.warn('[Notif] SignalR: max reintentos. Notificaciones en tiempo real no disponibles.');
            }
        });
    }

    // ── API CALLS ────────────────────────────────────────────────────────────

    function _loadUnreadCount() {
        _get(_apiBase + '/unread/count', function (r) {
            _unreadCount = r.UnreadCount || 0;
            _updateBadge(false);
        });
    }

    function _loadDropdown() {
        var $list = $('#notifList');
        $list.html('<li style="padding:12px; text-align:center; color:#aaa; font-size:12px;"><i class="fa fa-spinner fa-spin"></i> Cargando...</li>');

        _get(_apiBase + '?page=1&pageSize=15', function (r) {
            $list.empty();
            _unreadCount = r.UnreadCount || 0;
            _updateBadge(false);

            if (!r.Items || r.Items.length === 0) {
                $list.html('<li style="padding:20px; text-align:center; color:#aaa; font-size:12px;"><i class="fa fa-envelope-o fa-2x"></i><br>Sin notificaciones</li>');
                return;
            }
            $.each(r.Items, function (i, n) { $list.append(_buildItem(n)); });
        }, function () {
            $list.html('<li style="padding:12px; text-align:center; color:#e74c3c; font-size:12px;">Error al cargar.</li>');
        });
    }

    function _markAsRead(id) {
        _patch(_apiBase + '/read/' + id, function () {
            $('#notif-' + id).removeClass('unread').css('border-left', '').css('background', '');
            if (_unreadCount > 0) { _unreadCount--; _updateBadge(false); }
        });
    }

    function _markAllRead() {
        _patch(_apiBase + '/read-all', function () {
            $('.notif-alert-item').removeClass('unread').css({ 'border-left': '', 'background': '' });
            _unreadCount = 0;
            _updateBadge(false);
        });
    }

    // ── UI ───────────────────────────────────────────────────────────────────

    function _updateBadge(isNew) {
        var $b    = $('#notifBadge');
        var $icon = $('#notifIcon');
        if (_unreadCount > 0) {
            $b.text(_unreadCount > 99 ? '99+' : _unreadCount).show();
            if (isNew) {
                // Animacion swing del sobre con animate.css
                $icon.addClass('animated swing');
                setTimeout(function () { $icon.removeClass('animated swing'); }, 1200);
            }
        } else {
            $b.hide();
        }
    }

    function _buildItem(n) {
        var icon     = _iconByType(n.Type);
        var isUnread = !n.IsRead;
        var li = document.createElement('div');
        li.className = 'notif-alert-item' + (isUnread ? ' unread' : '');
        li.id = 'notif-' + n.NotificationId;
        li.setAttribute('data-id', n.NotificationId);
        if (isUnread) li.style.cssText = 'background:#edf5ff;border-left:3px solid #1ab394;';
        li.innerHTML =
            '<span class="notif-icon-sm" style="background:' + icon.color + '"><i class="fa ' + icon.fa + '"></i></span>' +
            '<div class="notif-body-sm">' +
                '<strong style="display:block;margin-bottom:3px;font-size:13px;">' + _esc(n.Title) + '</strong>' +
                '<div style="font-size:12px;color:#555;line-height:1.5;">' + n.Message + '</div>' +
                '<small style="display:block;color:#aaa;font-size:11px;margin-top:4px;">' + _formatDate(n.CreatedAt) + '</small>' +
            '</div>';
        return $(li);
    }

        // ── TOAST ────────────────────────────────────────────────────────────────

    function _ensureToastWrapper() {
        if ($('#notifToastWrapper').length === 0)
            $('body').append('<div id="notifToastWrapper" style="position:fixed;bottom:20px;right:20px;z-index:9999;display:flex;flex-direction:column;gap:8px;"></div>');
    }

    function _showToast(n) {
        var icon = _iconByType(n.Type);
        var $t = $('<div class="animated bounceInRight">')
            .css({ display:'flex', alignItems:'flex-start', gap:'10px', background:'#fff',
                   borderLeft:'4px solid '+icon.color, borderRadius:'6px',
                   boxShadow:'0 4px 16px rgba(0,0,0,.14)', padding:'12px 14px',
                   minWidth:'280px', maxWidth:'340px', cursor:'pointer' })
            .html(
                '<span style="width:28px;height:28px;border-radius:50%;background:'+icon.color+';display:flex;align-items:center;justify-content:center;color:#fff;font-size:12px;flex-shrink:0;">'+
                    '<i class="fa '+icon.fa+'"></i></span>'+
                '<div style="flex:1;"><strong style="display:block;font-size:13px;color:#222;">'+_esc(n.Title)+'</strong>'+
                '<span style="font-size:12px;color:#555;">'+n.Message+'</span></div>'+
                '<span style="color:#aaa;cursor:pointer;font-size:16px;" class="notif-close">&times;</span>'
            );

        $('#notifToastWrapper').prepend($t);
        var timer = setTimeout(function () { _closeToast($t); }, 6000);
        $t.find('.notif-close').on('click', function () { clearTimeout(timer); _closeToast($t); });
    }

    function _closeToast($t) { $t.addClass('animated bounceOutRight'); setTimeout(function () { $t.remove(); }, 400); }

    // ── HELPERS ──────────────────────────────────────────────────────────────

    function _iconByType(type) {
        var m = {
            'PROCESS_REASSIGN': { color:'#3498db', fa:'fa-exchange'            },
            'PROCESS_STEP':     { color:'#3498db', fa:'fa-tasks'               },
            'PROCESS_OVERDUE':  { color:'#e74c3c', fa:'fa-exclamation-triangle' },
            'POLICY_ISSUED':    { color:'#27ae60', fa:'fa-file-text-o'         },
            'PAYMENT_OK':       { color:'#27ae60', fa:'fa-credit-card'         },
            'PAYMENT_FAILED':   { color:'#e74c3c', fa:'fa-times-circle'        },
            'DOCUSIGN_SIGNED':  { color:'#1a73e8', fa:'fa-pencil'              },
            'EVICERTIA_SIGNED': { color:'#9b59b6', fa:'fa-check-circle'        },
            'TASK_ASSIGNED':    { color:'#f39c12', fa:'fa-user'                },
            'TASK_OVERDUE':     { color:'#e74c3c', fa:'fa-clock-o'             }
        };
        return m[type] || { color:'#7f8c8d', fa:'fa-envelope' };
    }

    function _formatDate(d) {
        if (!d) return '';
        var now  = new Date();
        var date = new Date(d);
        var diff = Math.floor((now - date) / 60000);
        if (diff < 1)    return 'Ahora mismo';
        if (diff < 60)   return 'Hace ' + diff + ' min';
        if (diff < 1440) return 'Hace ' + Math.floor(diff / 60) + ' h';
        return date.toLocaleDateString('es-CR');
    }

    function _esc(s) { return s ? $('<div>').text(s).html() : ''; }

    // ── EVENTOS DOM ──────────────────────────────────────────────────────────

    function _bindEvents() {
        $(document).on('click', '.notif-alert-item', function () {
            var id = parseInt($(this).data('id'), 10);
            if ($(this).hasClass('unread') && id) _markAsRead(id);
        });
        $(document).on('click', '#markAllRead', function (e) {
            e.preventDefault(); e.stopPropagation(); _markAllRead();
        });
        $(document).on('show.bs.dropdown', '#notificationDropdown', function () {
            _loadDropdown();
        });
    }

    return {
        init  : init,
        reload: _loadDropdown,
        getUnreadCount: function () { return _unreadCount; }
    };

})();
