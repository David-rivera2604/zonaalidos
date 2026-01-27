var app = app || {};

app.Notes = (function () {

    let _data = null;

    function Event_Controls() {

        $('#saveNote').click(function (e) {
            e.preventDefault();
            let note = $('#newNote').val().trim();
            if (note != '') {
                app.ui.ButtonDoing('#saveNote');
                if (_data.AlternateToken != undefined && _data.AlternateToken != undefined && _data.AlternateToken != '') {
                    localStorage.setItem('AlternateToken', _data.AlternateToken);
                }
                app.core.Post(app.setting.apipath + 'v1/Common/Note',
                    JSON.stringify({
                        Id: null,
                        EntityType: _data.EntityType,
                        EntityId: _data.Id,
                        Note: $('#newNote').val(),
                        Private: false,
                        NoteOwnerId: 0,
                        ParentSequence: 0
                    }))
                    .done(function (data, textStatus, jqXHR) {
                        $('#newNote').val('');
                        Draw();
                    }).always(function () {
                        app.ui.ButtonDone('#saveNote');
                    });
            } else {
                toastr.error("Debe el texto de la nota.", "", { closeButton: true, progressBar: true });
                $('#newNote').focus();
            }
        });

    }
    function Draw() {
        if (_data.AlternateToken != undefined && _data.AlternateToken != undefined && _data.AlternateToken != '') {
            localStorage.setItem('AlternateToken', _data.AlternateToken);
        }
        app.core.Get(app.setting.apipath + `v1/Common/Notes?entityType=${_data.EntityType}&entityId=${_data.Id}`)
            .done(function (notes) {
                let initial = '', info = '', last = '';
                let noteList = $('.chat-activity-list');
                noteList.html('');
                notes.forEach(function (item, index) {

                    initial = item.UpdateUserName.split(/\s/).reduce((response, word) => response += word.slice(0, 1), '').toUpperCase();
                    info = index % 2 === 0 ? 'success' : 'info';
                    last = index === notes.length - 1 ? 'text-navy' : '';
                    noteList.append(
                        `<div class="chat-element"><a href="#" class="float-left"><span class="label label-${info}">${initial}</span></a>` +
                        '<div class="media-body">' +
                        `<small class="float-right ${last}">` + moment(item.UpdateDate).from() + '</small>' +
                        `<p class="m-b-xs">${item.Note}</p>` +
                        `<strong>${item.UpdateUserName} </strong><small class="text-muted"><i class="fa fa-clock-o"></i> ` + moment(item.UpdateDate).calendar() + ' - ' + moment(item.UpdateDate).format('DD/MM/YYYY') + '</small>' +
                        '</div>' +
                        '</div>');
                });

            });
    }

    return {
        //{ EntityType: 1304, Id: 0, AlternateToken:'' }
        Init: function (data) {
            try {
                if (data.AlternateToken === undefined) {
                    data.AlternateToken = '';
                }
                if (_data == null) {
                    Event_Controls();
                }
                _data = data;
                Draw();

            }
            catch (err) {
                console.error("Error Init");
                console.error(err);
            }
        }
    };

})();