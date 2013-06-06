(function() {
  var AdminEvent;

  AdminEvent = (function() {

    function AdminEvent(obj) {
      var prop, value;
      this.self = this;
      for (prop in obj) {
        if (obj.hasOwnProperty(prop)) {
          value = obj[prop];
          if (/\/Date\(\d+\)\//.test(value)) {
            value = Date.fromRawJSON(value);
          }
          this.self[prop] = value;
        }
      }
    }

    return AdminEvent;

  })();

  window.AdminEvent = AdminEvent;

}).call(this);
