var app = app || {};

app.login = (function () {
    let dataStage = null;
    let lasthref = '';

    function getTranslationText(key, fallback) {
        var translations = app.language && typeof app.language.getTranslations === 'function'
            ? app.language.getTranslations()
            : null;
        var value = translations ? translations[key] : null;

        if (typeof value === 'string' && value !== '')
            return value;

        if (value && typeof value === 'object' && typeof value.text === 'string' && value.text !== '')
            return value.text;

        return fallback;
    }

    function applyTranslatedRuntimeTexts() {
        $('#Send').text(getTranslationText('SendTextStart', 'Sign in'));
        $('#ForgotSend').text(getTranslationText('ForgotSendTextContinue', 'Continue'));
        $('#ForgotCancel').text(getTranslationText('ForgotCancel', 'Cancel'));
        $('#forgoCodeSend').text(getTranslationText('ForgoCodeSendTextContinue', 'Continue'));
        $('#forgoCodeCancel').text(getTranslationText('forgoCodeCancel', 'Cancel'));
        $('#SetPasswordSend').text(getTranslationText('SetPasswordSendText', 'Change access password'));
        $('#SetPasswordCancel').text(getTranslationText('SetPasswordCancel', 'Cancel'));
    }

    return {
        Init: function () {
            localStorage.removeItem('Username');
            localStorage.removeItem('Roles');
            localStorage.removeItem('Expires');
            localStorage.removeItem('Token');
            localStorage.removeItem('Navegation');
            localStorage.removeItem('LastActivity');
            $('#Username').focus();
            var reason = localStorage.getItem('reason');
            localStorage.removeItem('reason');
            if (reason === 'session-expired') {
                $('.alert').removeClass('d-none');
                $('.alert').show();
            }

            app.language.translate('body', 'Acceso/aliados', function () {
                applyTranslatedRuntimeTexts();
            })();

            let entraIdError = app.core.URLStringValue('fail');
            if (entraIdError != '') {
                $('#SessionExpiredMessage').text(entraIdError);
                $('.alert').removeClass('d-none');
                $('.alert').show();

                var url = new URL(window.location.href);
                url.searchParams.delete('fail');
                history.replaceState(null, '', url.toString());
            }
        }
    };
})();
$(document).ready(function () {
    app.login.Init();
});
