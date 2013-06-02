(function() {
  var MenuAdmin, menuAdmins;

  MenuAdmin = (function() {

    function MenuAdmin(_arg) {
      var _ref, _ref1, _ref2, _ref3, _ref4;
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
            if ((_ref4 = this.Icon) != null) {
        _ref4;

      } else {
        this.Icon = "chevron-sign-right";
      };
      this.IsActive = false;
      if (this.Url === null) {
        this.Url = "/" + this.Controller + "/";
        if (this.Controller.toLowerCase() === Routing.Controller.toLowerCase()) {
          this.IsActive = true;
        }
        if (this.Action !== null) {
          this.Url += "" + this.Action + "/";
        }
      }
    }

    return MenuAdmin;

  })();

  menuAdmins = [
    new MenuAdmin({
      Name: "Dashboard",
      Controller: "Admin",
      Icon: "home"
    }), new MenuAdmin({
      Name: "User",
      Controller: "User"
    }), new MenuAdmin({
      Name: "Ticket",
      Controller: "Ticket",
      Action: "AdminList"
    }), new MenuAdmin({
      Name: "Danh mục",
      Controller: "Category",
      Icon: "reorder"
    }), new MenuAdmin({
      Name: "Sự kiện",
      Controller: "Event",
      Action: "AdminList",
      Icon: "volume-up"
    }), new MenuAdmin({
      Name: "Địa điểm",
      Controller: "Venue",
      Icon: "hospital"
    })
  ];

  $(function() {
    return ko.applyBindings({
      _MenuAdmin: menuAdmins
    }, $("#sidebar-nav")[0]);
  });

}).call(this);
