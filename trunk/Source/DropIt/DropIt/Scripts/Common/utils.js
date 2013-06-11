
Date.fromRawJSON = function (string) {
    return new Date(parseInt(string.match(/\d+/)));
};

String.prototype.makeExcerpt = function (length) {
    return "" + (this.substr(0, length)) + "...";
};

String.prototype.eval = function () {
    var s = this.toString();
    var args = arguments;
    var toReplaces = s.match(/#{[^}]*}/g);
    if (toReplaces && toReplaces.length > 0) {
        $.each(toReplaces, function (idx, value) {
            try{
                var v = value.match(/{([^}]*)}/)[1];
                if ($.isNumeric(v)) {
                    var reg = new RegExp(value.replace("{", "\\{").replace("}", "\\}"), "g");
                    s = s.replace(reg, args[parseInt(v)])
                } else {
                    s = s.replace(value, eval(v))
                }
            } catch (e) {
                console.error("Failed to eval string")
            }
        })
    }
    return s;
}

// Introduced in Javascript 1.8.5
_JS185Extend = function (target, propNane, value) {
    Object.defineProperty(target, propNane, {
        value: value
    });
}

Object.extend = function (name, func) {
    _JS185Extend(Object.prototype, name, func);
}

Object.extend("eachOwnProperties", function (func) {
    
    for (var p in this) {
        if (this.hasOwnProperty(p)) {
            func.call(this, p, this[p], this);
        }
    }
});

window.toFormData = function (obj) {
    var key, str, value;
    str = "";
    for (key in obj) {
        value = obj[key];
        if (obj.hasOwnProperty(key)) {
            str += "" + key + "=" + value + "&";
        }
    }
    if (str.length > 0) {
        str = str.substr(0, str.length - 1);
    }
    return str;
};

window.nullOrEmptyString = function (val) {
    if (val === null) {
        return "";
    }
    return val;
};

window.listPropertiesOfObjectToCoffee = function (obj, level) {
    var i, key, output, spaces, value, _i;
    output = "";
    if (obj instanceof Object) {
        spaces = "";
        for (i = _i = 0; 0 <= level ? _i <= level : _i >= level; i = 0 <= level ? ++_i : --_i) {
            spaces += "\t";
        }
        for (key in obj) {
            value = obj[key];
            if (obj.hasOwnProperty(key)) {
                output += "\n" + spaces + key + " : ";
                output += listPropertiesOfObjectToCoffee(obj[key], level + 1);
            }
        }
    } else {
        output += "" + (obj.toString());
    }
    return output;
};

window.bootstrap = {
    active: function () {
        $('[data-toggle="tooltip"][data-active!="actived"]').each(function () {
            var self;
            self = $(this);
            self.tooltip();
            return self.attr("data-active", "actived");
        });
        return $('[data-toggle="popover"][data-active!="actived"]').each(function () {
            var self;
            self = $(this);
            self.popover();
            return self.attr("data-active", "actived");
        });
    }
};

window.Url = function (_arg) {
    var Action, Area, Controller, newRouting, url;
    Area = _arg.Area, Controller = _arg.Controller, Action = _arg.Action;
    var Data = _arg.Data;
    newRouting = $.extend({}, Routing, {
        Area: Area,
        Controller: Controller,
        Action: Action,
        Data : Data
    });
    url = "";
    if ((newRouting.Area != null) !== "") {
        url += "/" + newRouting.Area;
    }
    url += "/" + newRouting.Controller + "/";
    if ((newRouting.Action != null) !== "" || (newRouting.Action != null) !== "Index") {
        url += "" + newRouting.Action;
    }

    if (newRouting.Data && newRouting.Data != "") {
        url +="?" + toFormData(newRouting.Data)
    }

    return url;
};

window.loading = function (show) {
    if ($("body").modalmanager) {
        if (show === true) {
            return $("body").modalmanager('loading', false);
        } else {
            return $("body").modalmanager('loading', true);
        }
    }
};

window.modalFactory = function (options) {
    var $modal, defaultOptions, modalHTML;
    defaultOptions = {
        id: "modal" + new Date().getTime(),
        tabindex: -1,
        styles: "",
        backdrop: true,
        headerText: "Modal header",
        bodyHTML: "<b>BodyHTML</b>",
        footerHTML: "            <button type=\"button\" data-dismiss=\"modal\" class=\"btn\">Close</button>\n<button type=\"button\" class=\"btn btn-primary\">Ok</button>"
    };
    options = $.extend({}, defaultOptions, options);
    modalHTML = "<div id='" + options.id + "' class='modal hide fade' data-backdrop='" + options.backdrop + "' tabindex='" + options.tab + "' style='" + options.styles + "' aria-hidden='true'>\n<div class='modal-header'>\n	    <button type='button' class='close' data-dismiss='modal' aria-hidden='true'>×</button>\n	    <h3>" + options.headerText + "</h3>\n</div>\n<div class='modal-body' style=\"\">\n	    " + options.bodyHTML + "\n</div>\n<div class='modal-footer'>\n	    " + options.footerHTML + "\n</div></div>";
    $modal = $(modalHTML);
    $("document.body").append($modal);
    return $modal;
};

$(function () {
    return bootstrap.active();
});
