(function() {
  var EventIndexViewModel,
    __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  EventIndexViewModel = (function(_super) {

    __extends(EventIndexViewModel, _super);

    function EventIndexViewModel() {
      EventIndexViewModel.__super__.constructor.call(this, {
        itemViewModel: AdminEvent,
        bindingTarget: $(".events-table")[0],
        entityMapping: {
          Id: {
            keyName: "EventId",
            requestName: "Id"
          },
          EventName: {
            label: "Tên sự kiện",
            index: 1
          },
          Artist: {
            label: "Nghệ sĩ tham gia",
            index: 2
          },
          HoldDate: {
            label: "Ngày tổ chức",
            index: 3
          },
          Description: {
            label: "Chú thích",
            index: 6
          },
          Status: {
            detail: {
              allow: false
            }
          },
          Category: {
            label: "Danh mục",
            index: 4
          },
          Venue: {
            label: "Địa điểm tổ chức",
            index: 5
          },
          RequestCount: {
            label: "Số lượt yêu cầu vé"
          },
          FollowerCount: {
            label: "Số lượt theo dõi"
          },
          CreatedDate: {
            detail: {
              allow: false
            }
          },
          ModifiedDate: {
            label: "Ngày cập nhật gần nhất"
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
