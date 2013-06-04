(function() {
  var GetAll, i;

  window.eventIndexViewModel = {
    events: []
  };

  i = 0;

  GetAll = function() {
    $.ajax({
      url: 'Get',
      dataType: "json",
      success: function(data) {
        var event, _i, _len, _ref;
        if (data.Result != null) {
          _ref = data.Result;
          for (_i = 0, _len = _ref.length; _i < _len; _i++) {
            event = _ref[_i];
            eventIndexViewModel.events.push(new AdminEvent(event));
          }
          console.log(eventIndexViewModel);
          ko.applyBindings(eventIndexViewModel, $(".events-table")[0]);
        }
        return true;
      }
    });
    return true;
  };

  $(function() {
    return GetAll();
  });

}).call(this);
