(function() {
  var Module, moduleKeywords,
    __indexOf = [].indexOf || function(item) { for (var i = 0, l = this.length; i < l; i++) { if (i in this && this[i] === item) return i; } return -1; };

  moduleKeywords = ['extended', 'included'];

  Module = (function() {

    function Module() {}

    Module.extend = function(obj) {
      var key, value, _ref;
      for (key in obj) {
        value = obj[key];
        if (__indexOf.call(moduleKeywords, key) < 0) {
          this[key] = value;
        }
      }
      if ((_ref = obj.extended) != null) {
        _ref.apply(this);
      }
      return this;
    };

    Module.include = function(obj) {
      var key, value, _ref;
      for (key in obj) {
        value = obj[key];
        if (__indexOf.call(moduleKeywords, key) < 0) {
          this.prototype[key] = value;
        }
      }
      if ((_ref = obj.included) != null) {
        _ref.apply(this);
      }
      return this;
    };

    return Module;

  })();

  Date.fromRawJSON = function(string) {
    return new Date(parseInt(string.match(/\d+/)));
  };

  String.prototype.makeExcerpt = function(length) {
    return "" + (this.substr(0, length)) + "...";
  };

  window.toFormData = function(obj) {
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

  window.bootstrap = {
    active: function() {
      $('[data-toggle="tooltip"][data-active!="actived"]').each(function() {
        var self;
        self = $(this);
        self.tooltip();
        return self.attr("data-active", "actived");
      });
      return $('[data-toggle="popover"][data-active!="actived"]').each(function() {
        var self;
        self = $(this);
        self.popover();
        return self.attr("data-active", "actived");
      });
    }
  };

  window.Url = function(_arg) {
    var Action, Area, Controller, newRouting, url;
    Area = _arg.Area, Controller = _arg.Controller, Action = _arg.Action;
    newRouting = $.extend({}, Routing, {
      Area: Area,
      Controller: Controller,
      Action: Action
    });
    url = "";
    if ((newRouting.Area != null) !== "") {
      url += "/" + newRouting.Area;
    }
    url += "/" + newRouting.Controller + "/";
    if ((newRouting.Action != null) !== "" || (newRouting.Action != null) !== "Index") {
      url += "" + newRouting.Action;
    }
    return url;
  };

  $(function() {
    return bootstrap.active();
  });

}).call(this);
