(function() {
  var MenuAdmin;

  MenuAdmin = (function() {

    function MenuAdmin(_arg) {
      var _ref, _ref1, _ref2, _ref3;
      this.Name = _arg.Name, this.Controller = _arg.Controller, this.Action = _arg.Action, this.Url = _arg.Url, this.Icon = _arg.Icon;
      this.self = this;
            if ((_ref = this.Name) != null) {
        _ref;

      } else {
        this.Name = "NoName";
      };
            if ((_ref1 = this.Controller) != null) {
        _ref1;

      } else {
        this.Controller = null;
      };
            if ((_ref2 = this.Action) != null) {
        _ref2;

      } else {
        this.Action = null;
      };
            if ((_ref3 = this.Url) != null) {
        _ref3;

      } else {
        this.Url = null;
      };
      this.Icon = "reorder";
      if (this.Url === null) {
        this.Url = "/" + this.Controller + "/";
        if (this.Action !== null) {
          this.Url += "" + this.Action + "/";
        }
      }
    }

    return MenuAdmin;

  })();

  window._MenuAdmin = [
    new MenuAdmin({
      Name: "Home",
      Controller: "Admin",
      Icon: "home"
    }), new MenuAdmin({
      Name: "User",
      Controller: "User"
    }), new MenuAdmin({
      Name: "Ticket",
      Controller: "Ticket",
      Action: "AdminList"
    })
  ];

}).call(this);
