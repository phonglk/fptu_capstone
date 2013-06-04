(function() {
  var MenuAdmin;

  MenuAdmin = (function() {

    function MenuAdmin(_arg) {
      var child, _i, _len, _ref, _ref1, _ref2, _ref3, _ref4, _ref5, _ref6, _ref7, _ref8, _ref9;
      this.Name = _arg.Name, this.Controller = _arg.Controller, this.Action = _arg.Action, this.Url = _arg.Url, this.Icon = _arg.Icon, this.Childs = _arg.Childs;
      this.self = this;
      this.Area = "Administration";
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
      this.Parent = null;
            if ((_ref5 = this.Childs) != null) {
        _ref5;

      } else {
        this.Childs = [];
      };
      _ref6 = this.Childs;
      for (_i = 0, _len = _ref6.length; _i < _len; _i++) {
        child = _ref6[_i];
        child.Parent = this;
        child.Controller = this.Controller;
        if (child.Area != null) {
          child.Url = "/" + this.Area;
        } else {
          child.Url = "";
        }
        child.Url += "/" + child.Controller + "/" + child.Action;
        if (((_ref7 = this.Controller) != null ? _ref7.toLowerCase() : void 0) === Routing.Controller.toLowerCase() && ((_ref8 = child.Action) != null ? _ref8.toLowerCase() : void 0) === Routing.Action.toLowerCase()) {
          child.IsActive = true;
        }
      }
      if (this.Url === null) {
        if (this.Area != null) {
          this.Url = "/" + this.Area;
        } else {
          this.Url = "";
        }
        this.Url += "/" + this.Controller + "/";
        if (((_ref9 = this.Controller) != null ? _ref9.toLowerCase() : void 0) === Routing.Controller.toLowerCase()) {
          this.IsActive = true;
        }
        if (this.Action !== null) {
          this.Url += "" + this.Action + "/";
        }
      }
    }

    return MenuAdmin;

  })();

  window.menuAdmins = [
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
      Action: "List",
      Icon: "volume-up",
      Childs: [
        new MenuAdmin({
          Name: "Event List",
          Action: "List"
        }), new MenuAdmin({
          Name: "Create",
          Action: "Create"
        }), new MenuAdmin({
          Name: "Aprrove",
          Action: "Approve"
        })
      ]
    }), new MenuAdmin({
      Name: "Địa điểm",
      Controller: "Venue",
      Icon: "hospital"
    })
  ];

  $(function() {
    ko.applyBindings({
      _MenuAdmin: menuAdmins
    }, $("#dashboard-menu")[0]);
    return ko.applyBindings({
      _MenuAdmin: menuAdmins
    }, $("#tabs-wrapper")[0]);
  });

}).call(this);
