(function() {
  var AdminVenue, VenueIndexViewModel,
    __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  AdminVenue = (function(_super) {

    __extends(AdminVenue, _super);

    function AdminVenue() {
      return AdminVenue.__super__.constructor.apply(this, arguments);
    }

    return AdminVenue;

  })(AdminEvent);

  VenueIndexViewModel = (function(_super) {

    __extends(VenueIndexViewModel, _super);

    function VenueIndexViewModel() {
      var _this = this;
      VenueIndexViewModel.__super__.constructor.call(this, {
        itemViewModel: AdminVenue,
        bindingTarget: $(".venues-table")[0],
        entityMapping: {
          Id: {
            keyName: "VenueId",
            requestName: "Id"
          },
          VenueName: {
            label: "Tên địa điểm"
          },
          Address: {
            label: "Địa chỉ"
          },
          ProvinceName: {
            label: "Tỉnh"
          },
          Description: {
            label: "Chú thích"
          }
        }
      });
      this.filterRegister("EditModalHTMLCreationAfter", function(data) {
        data.find(".modal-header h3").html("Chi tiết địa điểm - <span data-bind='text: VenueName'></span>");
        return data;
      });
    }

    return VenueIndexViewModel;

  })(BaseViewModel);

  window.venueIndexViewModel = new VenueIndexViewModel();

  $(function() {
    return venueIndexViewModel.getAll();
  });

}).call(this);
