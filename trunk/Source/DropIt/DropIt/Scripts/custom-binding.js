(function() {

  ko.bindingHandlers.stopBindings = {
    init: function() {
      return {
        controlsDescendantBindings: true
      };
    }
  };

  ko.bindingHandlers.date = {
    formattedDate: function(date) {
      return "" + (date.getDate()) + "/" + (date.getMonth()) + "/" + (date.getFullYear()) + " - " + (date.getHours()) + ":" + (date.getMinutes());
    },
    init: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
      var date, self;
      self = ko.bindingHandlers.date;
      date = ko.utils.unwrapObservable(valueAccessor());
      $(element).text(self.formattedDate(date));
    }
  };

  ko.bindingHandlers.tooltip = {
    init: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
      var $a, data, self, text, value;
      self = ko.bindingHandlers.tooltip;
      value = ko.utils.unwrapObservable(valueAccessor());
      data = value.data;
      text = value.text || "tooltip";
      $a = $("<a href='javascript:void(0)' data-toggle='tooltip' title='" + data + "'>" + text + "</a>");
      $(element).html($a);
      bootstrap.active();
    }
  };

  ko.bindingHandlers.popover = {
    init: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
      var $a, data, self, text, title, value;
      self = ko.bindingHandlers.tooltip;
      value = ko.utils.unwrapObservable(valueAccessor());
      data = value.data || "you are missing data here";
      title = value.title || "title";
      text = value.text || "More";
      $a = $("<a href='javascript:void(0)'         data-toggle='popover'         title='" + title + "'         data-content='" + data + "'        data-placement='top'        data-trigger='hover'>" + text + "</a>");
      $(element).html($a);
      bootstrap.active();
    }
  };

}).call(this);
