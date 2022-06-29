var app = app || {};
app.policy_common = (function () {

    function b64StrtoBlob(b64Data, contentType, sliceSize) {
        contentType = contentType || '';
        sliceSize = sliceSize || 512;
        var byteCharacters = atob(b64Data);
        var byteArrays = [];
        for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
            var slice = byteCharacters.slice(offset, offset + sliceSize);
            var byteNumbers = new Array(slice.length);
            for (var i = 0; i < slice.length; i++) {
                byteNumbers[i] = slice.charCodeAt(i);
            }
            var byteArray = new Uint8Array(byteNumbers);
            byteArrays.push(byteArray);
        }
        var blob = new Blob(byteArrays, { type: contentType });
        return blob;
    };

    function Print(id) {
        app.core.Get(app.setting.apipath + 'v1/Policy/Information?id=' + id)
            .done(function (data, textStatus, jqXHR) {
                var urlServer = app.setting.apibase + '/AliadoServReports/api/Report/Build';
                //urlServer = 'http://localhost:5870/api/Report/Build';
                //urlServer = 'https://appqa.mapfrecr.com' + '/AliadoServReports/api/Report/Build';
                var data2 = {
                    Source: JSON.stringify(data),
                    Type: 'pdf',
                    ReportName: data.ProductAlias + data.Prefix + '.repx',
                    Path: ''
                };
                $.post(urlServer, data2, { responseType: 'arraybuffer' })
                    .then(function (response) {
                        var file = new Blob([response.Data], { type: 'application/octet-binary' });
                        var blob = b64StrtoBlob(response.Data, 'application/pdf');
                        var blobUrl = URL.createObjectURL(blob);
                        window.open(blobUrl);
                    });
            });
    };

    return {
        Print: function (id) {
            Print(id);
        },
        PolicyStatus2CSSClass: function (value) {
            var classValue = 'primary';
            switch (value) {
                case 'En revisión':
                    classValue = 'label-info';
                    break;
                case 'Declinada':
                    classValue = 'label-warning';
                    break;
                case 'Por aceptar':
                    classValue = 'label-primary';
                    break;
                case 'Alta':
                    classValue = 'label-success';
                    break;
                case 'Baja':
                    classValue = 'label-danger';
                    break;
                default:
                    classValue = '';
            };
            return classValue;
        },
        PolicyStatusFormatter: function (value, row, index, field) {
            return '<span class="label ' + app.policy_common.PolicyStatus2CSSClass(value)  + '">' + value + '</span>';
        }
    };
}());
