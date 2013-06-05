(function() {
  var BaseViewModel, EventIndexViewModel, defaultRoutingMapping,
    __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  defaultRoutingMapping = {
    getAll: {
      action: "Get"
    },
    "delete": {
      action: "Delete"
    },
    detail: {
      action: "Detail"
    },
    edit: {
      action: "Update"
    }
  };

  BaseViewModel = (function() {

    function BaseViewModel(_arg) {
      this.itemViewModel = _arg.itemViewModel, this.bindingTarget = _arg.bindingTarget, this.routing = _arg.routing, this.entityMapping = _arg.entityMapping;
      this.self = this;
      this.routing = $.extend({}, defaultRoutingMapping, this.routing);
    }

    BaseViewModel.prototype.getAll = function() {
      var url,
        _this = this;
      url = Url({
        Action: this.routing.getAll.action
      });
      $.ajax({
        url: url,
        dataType: "json",
        success: function(data) {
          var item, _i, _len, _ref, _ref1;
          if (((_ref = data.Result) != null ? _ref.length : void 0) > 0) {
            _ref1 = data.Result;
            for (_i = 0, _len = _ref1.length; _i < _len; _i++) {
              item = _ref1[_i];
              _this.data.push(new _this.itemViewModel(item));
            }
            ko.applyBindings(_this, _this.bindingTarget);
          }
        }
      });
    };

    BaseViewModel.prototype.deleteItem = function(item) {
      return this.data.remove(item);
    };

    BaseViewModel.prototype["delete"] = function() {
      var url,
        _this = this;
      url = Url({
        Action: this.routing["delete"].action
      });
      $.ajax({
        url: url,
        dataType: "json",
        data: "",
        success: function(data) {
          var item, _i, _len, _ref, _ref1;
          if (((_ref = data.Result) != null ? _ref.length : void 0) > 0) {
            _ref1 = data.Result;
            for (_i = 0, _len = _ref1.length; _i < _len; _i++) {
              item = _ref1[_i];
              _this.data.push(new _this.itemViewModel(item));
            }
            ko.applyBindings(_this, _this.bindingTarget);
          }
        }
      });
    };

    BaseViewModel.prototype.afterDelete = function() {};

    BaseViewModel.prototype.detail = function() {};

    BaseViewModel.prototype.edit = function() {};

    BaseViewModel.prototype.data = ko.observableArray([]);

    return BaseViewModel;

  })();

  EventIndexViewModel = (function(_super) {

    __extends(EventIndexViewModel, _super);

    function EventIndexViewModel() {
      EventIndexViewModel.__super__.constructor.call(this, {
        itemViewModel: AdminEvent,
        bindingTarget: $(".events-table")[0],
        entityMapping: {
          Id: "EventId",
          EventName: {
            update: true
          }
        }
      });
    }

    return EventIndexViewModel;

  })(BaseViewModel);

  window.eventIndexViewModel = new EventIndexViewModel();

  $(function() {
    return eventIndexViewModel.getAll();
  });

}).call(this);
