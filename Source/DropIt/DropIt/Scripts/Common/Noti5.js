var Noti5Hub = $.connection.notificationHub;

function Noti5(obj) {
    var self = this;
    self.NotificationId = -1;
    self.Userid = null;
    self.SenderId = null;
    self.ActivityType = "not";
    self.ObjectType = null;
    self.ObjectTitle = "";
    self.ObjectUrl = "";
    self.Content = "";
    self.IsUnread = true;
    self.CreatedDate = null;
    self.ModifiedDate = null;
    $.extend(self, obj);

    self.CreatedDate = Date.fromRawJSON(self.CreatedDate);
    self.ModifiedDate = Date.fromRawJSON(self.ModifiedDate);
    self.AvatarBG = "url('/Event/Image/" + self.SenderId + "')";
    self.Description = ""
    if (self.ObjectType == "Event") {
        self.Description += "Sự kiện <strong>" + self.ObjectTitle + "</strong> đã có"
        if (self.ActivityType == "Add") {
            self.Description += " vé mới được đăng bán";
        } else if (self.ActivityType == "Request") {
            self.Description += " yêu cầu vé được rao";
        } else {
            self.Description += " gì đó";
        }
    }
    self.time = self.CreatedDate.getHours().toLength(2) + ":" + self.CreatedDate.getMinutes().toLength(2)
    self.dateOfCDate = "#{0}/#{1}/#{2}".eval(self.CreatedDate.getDate().toLength(2), self.CreatedDate.getMonth().toLength(2), self.CreatedDate.getFullYear().toLength(2))
}

function NotificationViewModel() {

    var self = this;

    self.data = ko.observableArray([]);
    self.unreadCount = ko.observable(0);

    self.lastId = -1;
    self.FollowType = 1;
    self.haveMore = true;

    self.LoadLastest = function () {
        $.ajax({
            type: "POST",
            cache: false,
            dataType: "json",
            url: Url({ Controller: "Notification", Action: "List" }),
            data: { FollowType: -1, jtPageSize: 4 },
            success: function (data) {
                if (data.Result == "OK") {
                    self.data.removeAll();
                    self.unreadCount(data.UnreadCount);
                    var last = null;
                    $.each(data.Records, function (i, e) {
                        self.data.push(new Noti5(e))
                        last = e;
                    })
                    if (last != null) {
                        self.lastId = last.NotificationId;
                    }
                } else {
                    console.error("Fail while loading notifications: " + data.Message);
                }
            }
        })
    }
    self.LoadMore = function () {
        $.ajax({
            type: "POST",
            cache: false,
            dataType: "json",
            url: Url({ Controller: "Notification", Action: "List" }),
            data: { FollowType: self.FollowType, jtPageSize: 3, FromId: self.lastId },
            success: function (data) {
                if (data.Result == "OK") {
                    var last = null;
                    $.each(data.Records, function (i, e) {
                        self.data.push(new Noti5(e))
                        last = e;
                    })
                    if (last != null) {
                        self.lastId = last.NotificationId;
                    }
                } else {
                    console.error("Fail while loading notifications: " + data.Message);
                }
            }
        })
    }
    self.push = function (obj) {
        self.data.splice(0, 0, new Noti5(obj))
        if (self.$wrapper.hasClass("open") == false) {
            self.unreadCount(self.unreadCount() + 1);
        }
    }

    self.readAll = function () {
        $.ajax({
            type: "POST",
            cache: false,
            dataType: "json",
            url: Url({ Controller: "Notification", Action: "ReadAll" }),
            data: { FollowType: self.FollowType},
            success: function (data) {
                if (data.Result == "OK") {
                    
                } else {
                    console.error("Fail while read all notifications: " + data.Message);
                }
            }
        })
    }

    self.listscroll = function (data, e) {
        var wrapper = $(e.target);
        var list = wrapper.find(".noti5-list");
        var rangeToEnd = list.height() - (wrapper.height() + wrapper.scrollTop());
        if (rangeToEnd < 45) {
            self.LoadMore();
        }
        e = e || window.event;
        if (e.preventDefault)
            e.preventDefault();
        e.returnValue = false;
    }


}

function noti5_init(VM, $notiWrapper) {
    VM.$wrapper = $notiWrapper;
    function close_panel() {
        var $this = $notiWrapper;
        $this.removeClass("dropdown").removeClass("open");
        $this.find("> a").removeClass("dropdown-toggle");
        $this.find(".noti5-list-container").removeClass("show");
        $("#back-drop").remove();
    }
    function initVM() {
        
        ko.applyBindings(VM, $notiWrapper[0]);
        VM.LoadLastest();
    }
    $notiWrapper.click(function () {
        var $this = $(this);
        if ($this.hasClass("open")) {
            close_panel();
        } else {
            $this.addClass("dropdown").addClass("open");
            $this.find("> a").addClass("dropdown-toggle");
            $this.find(".noti5-list-container").addClass("show");
            $(document.body).append("<div id='back-drop'></div>")
            $("#back-drop").click(function (e) {
                close_panel();
            })
            VM.unreadCount(0);
            VM.readAll();
        }
    })

    initVM();
}

function startConnection() {

    $.connection.hub.start().done(function () {

    }).fail(function (err) {
        console.log(err);
    });
}

// turn the logging on for debug purposes
//$.connection.hub.logging = true;
var noti5_stack = { "dir1": "up", "dir2": "right", "push": "top" }
Noti5Hub.client.received = function (message) {
    console.log(message);
    var html = '<a href="#{ObjectUrl}"><div class="container"><div class="row-fluid"><div class="span3 avatar" style="background-image: url(http://localhost:2065/#{ObjectType}/Image/#{SenderId});" ></div><div class="span7 description"><span>#{Description}</span></div><div class="span2 misc"><br><center><span>#{time}</span></center></div></div></div></a>';
    var noti = new Noti5(message.Object);
    html = html.eval(noti)
    $.pnotify({
        text: html,
        addclass: 'notification',
        type: "alert",
        opacity: .95,
        sticker: false,
        delay: 5000,
        stack: noti5_stack
    });

    NotiBuy.push(message.Object);
}

startConnection();

$(function () {
    window.NotiBuy = new NotificationViewModel();
    noti5_init(NotiBuy,$("li.noti5-wrapper"));
})