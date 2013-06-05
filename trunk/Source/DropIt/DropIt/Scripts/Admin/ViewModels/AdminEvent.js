(function() {
  var AdminEvent;

  AdminEvent = (function() {

    function AdminEvent(obj) {
      var prop;
      this.self = this;
      for (prop in obj) {
        if (obj.hasOwnProperty(prop)) {
          this.self[prop] = obj[prop];
        }
      }
      this.HoldDate = Date.fromRawJSON(this.HoldDate);
    }

    return AdminEvent;

  })();

  window.AdminEvent = AdminEvent;

}).call(this);
