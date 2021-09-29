var app = app || {};

app.ManagerLinks = (function () {
    let _options = {
        ContainerOver: "",
        ContainerTab: "",
        CantainerLinks: "",
        //Integrated-Embedded
        Type: "Integrated",
        DataInput: {}
    };

    let _Max = false;
    let _data = {};

    _data.Embeddeds = [];
    _data.Controls = [];

    let _nameControl = "Enlaces1"
    let _nameControlTabList = _nameControl + "TagList";
    let _nameControlEmbeddedHeader = _nameControl + "TagEmbeddedHeader";
    let _nameControlEmbeddedContent = _nameControl + "TagEmbeddedContent";
    //let _templateTabHeader = '<li><a class="nav-link" data-toggle="tab" href="#' + _nameControl + '"><i class="fa {Icon}"></i>Enlaces</a></li>';

    let _templateTabBody = '<div role="tabpanel" id="' + _nameControl + '" class="tab-pane"> ' +
        '		<div class="panel-body">                                 ' +
        '			<div class="form-row">                               ' +
        '			     <div class="col-md-12">                         ' +
        '			          <ul id="' + _nameControlTabList + '" class="tag-list" style="padding: 0; margin-top: -25px">                         ' +
        '			          </ul>                         ' +
        '			          <div class="clearfix"></div>' +
        '			          <ul id="' + _nameControlEmbeddedHeader + '" class="nav nav-tabs" style="margin-top: 6px">' +
        '			          </ul>' +
        '			          <div id="' + _nameControlEmbeddedContent + '" class="tab-content" style="padding-top: 10px">' +
        '			          </div>' +
        '			     </div>  ' +
        '			 </div>							                     ' +
        '        </div>										             ' +
        '</div>                                                          ';

    let _templateTagList = '<li><a href="#" onclick="app.ManagerLinks.UrlProcess(this);" data-url="{URL}" target="_blank" class="dropdown-item" title="{Title}"><i class="fa {Icon}"></i> {Name}</a></li>';

    let _templateTabEmbeddedHeader = '<li>' +
        '			     		<a id="TabEmbeddedHeader{Id}" data-url="{URL}" data-id="{Id}" class="nav-link" data-toggle="tab" href="#TabEmbeddedContent{Id}" title="{Title}"> ' +
        '			     			<i class="fa {Icon}"></i>' +
        '			     			{Name}' +
        '			     		</a>' +
        '			     	</li>';

    let _templateEmbeddedContent = '<div id="TabEmbeddedContent{Id}" class="tab-pane fade"> ' +
        '  <div class="panel-body">' +
        '    <div class="text-right" style="z-index: 9;position: absolute;/* position: fixed; */top:0px;right:0px;width:100px;" > ' +
        '     <button type="button" id="btnExpand{Id}" data-identificador="{Id}" data-id="TabEmbeddedContent{Id}" data-iframe="iframe{Id}" class="btn btn-floating btnExpand" style="color: lightgray;" title="Permite maximizar o restaurar el contenido"><i id="icon{Id}"  class="fa fa-expand"></i></button>' +
        '    </div>' +
        '    <iframe id="iframe{Id}" data-url="{URL}" title="{Name}" frameborder="0" style="background-color:transparent;width:100%;height:500px" ></iframe> ' +
        '  </div> ' +
        '</div> ';

    function UrlProcess(element) {
       element.href = Url(element.getAttribute('data-url'));
    }

    function Url(url) {
        var querystrings = url.match(/\{.+?\}/g);
        if (querystrings != undefined) {
            querystrings.forEach((item, index, array) => {
                var name = item.replaceAll("{", "");
                name = name.replaceAll("}", "");
                if (item.toLowerCase().includes("data.")) {
                    name = name.replaceAll("Data.", "");
                    name = name.replaceAll("data.", "");
                    if (name in _options.DataInput) {
                        url = url.replaceAll(item, _options.DataInput[name]);
                    }
                }
                else {
                    if ($('#' + name).length) {
                        url = url.replaceAll(item, $('#' + name).text());
                    }
                }
            });
        }
        return url;
    }

    function BuildEmbedded(element) {
        let header = _templateTabEmbeddedHeader.replaceAll("{Name}", element.Name);
        header = header.replaceAll("{Title}", element.Description);
        header = header.replaceAll("{URL}", element.URL);
        header = header.replaceAll("{Id}", element.Id);
        header = header.replaceAll("{Icon}", element.Icon);
        if (_options.Type == "Embedded") {
            $('#' + _nameControlEmbeddedHeader).append(header);
        }
        else {
            $('#' + _options.ContainerTab + ' > ul').append(header);
        }
        let Content = _templateEmbeddedContent.replaceAll("{Name}", element.Name);
        Content = Content.replaceAll("{Title}", element.Description);
        Content = Content.replaceAll("{URL}", element.URL);
        Content = Content.replaceAll("{Id}", element.Id);

        if (_options.Type == "Embedded") {
            $('#' + _nameControlEmbeddedContent).append(Content);
        }
        else {
            $('#' + _options.ContainerTab + ' > div').append(Content);
        }

        _data.Embeddeds.push({ iframe: $(".iframe-content"), name: "iframe{Id}".replaceAll("{Id}", element.Id), container: "TabEmbeddedContent{Id}".replaceAll("{Id}", element.Id) })

        $("#TabEmbeddedHeader" + element.Id).on('shown.bs.tab', function (e) {
            Risize();
            $("#iframe" + this.getAttribute('data-id')).attr("src", Url(this.getAttribute('data-url')));
        });

        $("#btnExpand" + element.Id).on('click', function (e) {
            e.preventDefault(); // To prevent following the link (optional)
            var target = this.getAttribute('data-id');
            var iframe = this.getAttribute('data-iframe');
            var identificador = this.getAttribute('data-identificador');
            RelocationAndMaximization(target, iframe, _options.ContainerOver, identificador);
        });

    }

    function RelocationAndMaximization(target, iframe, container, identificador) {
        var itemFound = _data.Controls.filter(x => x.target === target);
        var item;

        $('#icon' + identificador).removeClass("fa-expand");
        $('#icon' + identificador).removeClass("fa-compress");

        if (itemFound.length == 0) {
            item = { target: target, container: container, max: true, height: $('#' + target).height() };
            _data.Controls.push(item);
        } else {
            item = itemFound[0];
        }

        if (!_Max) {
            $('#icon' + identificador).addClass("fa-compress");
            $("#" + iframe).css("height", ($('#' + target).height() + $('#' + container).height()) + "px");
            $('#' + target).animate({ 'marginTop': "-" + $("#" + container).height() + "px" });
            _Max = true;
        }
        else {
            $('#icon' + identificador).addClass("fa-expand");
            $('#' + target).animate({ 'marginTop': "0px" });
            $("#" + iframe).animate({ 'height': item.height + "px" });

            _Max = false;
        }
        item.max = _Max;
    }

    function BuildTagList(element) {
        let body = "";

        body = _templateTagList.replaceAll("{Name}", element.Name);
        body = body.replaceAll("{Title}", element.Description);
        body = body.replaceAll("{URL}", element.URL);
        body = body.replaceAll("{Icon}", element.Icon);

        $('#ExternalLinks').append(body);

        $("#ExternalLinksParent").removeClass("d-none");
    }

    function Build(element, index, array) {
        switch (element.Type) {
            case 1:
                BuildEmbedded(element);
                break;
            case 2:
                BuildTagList(element);
                break;
            default:
        }
    }

    function MapObjectToInput(data) {
        _options.DataInput = data;
        app.core.Get(app.setting.apipath + 'v1/ProcessSpecLink?filter=:flowId=' + data.FlowId)
            .done(function (dataLinks) {
                dataLinks.forEach(Build);
            });
    }

    function Risize() {
        if (_data.Embeddeds.length != 0) {
            var height = $(window).height() - $("#TabEmbeddedContent7 > div > div").height() - $("#page-wrapper > div.footer").height() - $("#page-wrapper > div.row.border-bottom > nav").height() - $("#page-wrapper > div.wrapper.wrapper-content.animated.fadeInRight > div > div.col-sm-12").height() - 80;
            _data.Embeddeds.forEach((element, index, array) => {
                //$("#" + element.container).height(height);
                var obj = document.getElementById(element.name);
                obj.height = (height) + "px";
                $("#" + element.name).css("height", (height) + "px");
            });
        }
    };

    function Init(options) {
        $(window).resize(function () {
            Risize();
        });

        //var header = _templateTabHeader.replaceAll("{Icon}", "fa-bookmark-o")
        //$('#' + options.ContainerTab + ' > ul').append(header);
        //$('#' + options.ContainerTab + ' > div').append(_templateTabBody);

        if (_options.Type == "Embedded") {
            $('#' + _nameControlEmbeddedHeader).show();
            $('#' + _nameControlEmbeddedContent).show();
        }
        else {
            $('#' + _nameControlEmbeddedHeader).hide();
            $('#' + _nameControlEmbeddedContent).hide();
        }
    }

    return {
        Init: function (options) {
            _options = options;
            Init(options);
            return this;
        },
        MapObjectToInput: function (data) {
            MapObjectToInput(data);
        },
        Data: function () {
            return _data;
        },
        UrlProcess: function (element) {
            UrlProcess(element);
        }
    };
})();