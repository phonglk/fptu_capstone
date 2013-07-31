$(function () {
    getTotalTransaction();
    getTotalTicket();
    getTotalEvent();
    generateDataTracker();
    rawDateDisplay();
    formatAllVNDLabel();
})

function generateData(type, target) {
    function getData(url, callback) {
        $.ajax({
            url: url,
            type: "POST",
            cache: false,
            success: callback
        })
    }

    if (type == "category") {
        getData("/Category/getAll", function (data) {
            if (data.Records && data.Records.length > 0) {
                var html_lis = ""
                for (var i = 0; i < data.Records.length; i++) {
                    var cat = data.Records[i];
                    html_lis += "<li><a href='/Event/?CategoryId=" + cat.CategoryId + "'>" + cat.CategoryName + "</a></li>";
                }
                target.append(html_lis);
            }
        })
    }
}
function generateDataTracker() {
    $("[data-gen]").each(function () {
        var $this = $(this);
        generateData($this.attr("data-gen"), $this);
    })
}
function rawDateDisplay() {
    $("[data-rawdate]").each(function () {
        var $this = $(this);
        var type = $this.attr("data-rawdate") || "full";
        var text = $this.text();
        text = text.replace(/"/g, "");
        var date = Date.fromRawJSON(text);
        switch (type) {
            default:
                text = date.toDateTimeString();
        }
        $this.text(text);
    })

}
function requireLogin() {
    if (typeof isLogin != "undefined" && isLogin == false) {
        alert("Bạn cần đăng nhập để thực hiện hành động này");

        window.location = "/Account/Login?ReturnUrl=" + location.pathname;
        return false;

    } else {
        return true;
    }
}
function follow_btn_html($j) {

    var followType = $j.data("follow-status");
    var object = $j.data("follow");
    var html = $('<div class="btn-group"><button class="btn main-label">Action</button><button class="btn dropdown-toggle" data-toggle="dropdown"><span class="caret"></span></button><ul class="dropdown-menu"><li><a href="javascript:;"></li><li><a href="javascript:;"></li></ul></div>');
    $j.empty();
    $j.append(html);
    var btn_main = html.find(".main-label");
    var btn_child1 = html.find(".dropdown-menu li a").eq(0);
    var btn_child2 = html.find(".dropdown-menu li a").eq(1);
    var data_mapping = [
        { // -1
            text: {
                m: "Theo dõi",
                c1: "Theo dõi bán",
                c2: "Theo dõi mua"
            },
            tooltip:{
                m:"Thông báo nếu sự kiện này có vé mới được đăng hay có yêu cầu vé mới",
                c1:"Thông báo nếu sự kiện này có vé mới được bán",
                c2:"Thông báo nếu sự kiện này có yêu cầu vé mới"
            },
            action : [2, 0, 1]
        },
        { // 0
            text: {
                m: "Bỏ theo dõi bán",
                c1: "Theo dõi bán & mua",
                c2: "Chỉ theo dõi mua"
            },
            tooltip: {
                m: "Bỏ theo dõi sự kiện này",
                c1: "Thông báo nếu sự kiện này có vé mới được đăng hay có yêu cầu vé mới",
                c2: "Thông báo nếu sự kiện này có yêu cầu vé mới"
            },
            action: [-1, 2, 1]
        },
        { // 1
            text: {
                m: "Bỏ theo dõi mua",
                c1: "Theo dõi bán & mua",
                c2: "Chỉ theo dõi bán"
            },
            tooltip: {
                m: "Bỏ theo dõi sự kiện này",
                c1: "Thông báo nếu sự kiện này có vé mới được đăng hay có yêu cầu vé mới",
                c2: "Thông báo nếu sự kiện này có vé mới được bán"
            },
            action: [-1, 2, 0]
        },
        { // 2
            text: {
                m: "Bỏ Theo dõi",
                c1: "Chỉ theo dõi bán",
                c2: "Chỉ theo dõi mua"
            },
            tooltip: {
                m: "Bỏ theo dõi sự kiện này",
                c1: "Thông báo nếu sự kiện này có vé mới được bán",
                c2: "Thông báo nếu sự kiện này có yêu cầu vé mới"
            },
            action: [-1, 0, 1]
        }

    ]

    if (object == "User") {

    } else if (object == "Venue") {

    }
    var mapping_index = followType + 1;
    btn_main.text(data_mapping[mapping_index].text.m);
    btn_main.parent().parent().tooltip({
        "placement": "left",
        title: data_mapping[mapping_index].tooltip.m
    })
    btn_child1.text(data_mapping[mapping_index].text.c1);
    btn_child1.tooltip({
        "placement": "left",
        title: data_mapping[mapping_index].tooltip.c1
    })
    btn_child2.text(data_mapping[mapping_index].text.c2);
    btn_child2.tooltip({
        "placement": "left",
        title: data_mapping[mapping_index].tooltip.c2
    })

    
    $.each([btn_main, btn_child1, btn_child2], function (i, e) {
        e.click(function () {
            follow_action($j, data_mapping[mapping_index].action[i])
        })

    })
}
function follow_action($j, followType) {
    if (requireLogin()) {
        console.log(followType);
        var object = $j.data("follow");
        var objectId = $j.data("follow-id");
        var currentFollowType = $j.data("follow-status");
        $.ajax({
            type: "POST",
            url: "/Follow/" + object + "/" + objectId,
            data: {FollowType:followType},
            cache: false,
            dataType: "json",
            success: function (rs) {
                if (rs.Result == "OK") {
                    $j.data("follow-status",followType);
                    follow_btn_html($j)
                } else {
                    alert("Error:" + rs.Message)
                }
                $j.removeClass("disabled");
            }
        });

    } else {

    }
}
function follow_init() {
    $("[data-follow]").each(function () {
        var $this = $(this);
        var object = $this.data("follow");
        var objectId = $this.data("follow-id");
        var followType = $this.data("follow-status");

        follow_btn_html($this);

        //$this.live("click", function (e) {
        //    if ($this.hasClass("disabled"))
        //        return;
        //    if (requireLogin()) {
        //        $this.addClass("disabled");

        //        $.ajax({
        //            type: "POST",
        //            url: "/Follow/Event/" + eventId,
        //            cache: false,
        //            dataType: "json",
        //            success: function (rs) {
        //                if (rs.Result == "OK") {
        //                    $this.attr("data-follow", rs.IsFollow);
        //                    follow_btn_text($this);
        //                } else {
        //                    alert("Error:" + rs.Message)
        //                }
        //                $this.removeClass("disabled");
        //            }
        //        });
        //    }
        //});
    });
}
function getTotalTransaction() {
    var $j = $(".count-transaction");
    $.ajax({
        type: "POST",
        url: Url({ Controller: "Transaction", Action: "Count", Data: { id: -1, extra: "ontransaction" } }),
        success: function (rs) {
            if (rs.Result && rs.Result == "OK") {
                $j.text(rs.Count)
            } else {
                $j.text(0)
            }

        }
    })
}
function getTotalEvent() {
    var $j = $(".total-event");
    $.ajax({
        type: "POST",
        url: Url({ Controller: "Event", Action: "Count" }),
        success: function (rs) {
            if (rs.Result && rs.Result == "OK") {
                $j.text(rs.Count)
            } else {
                $j.text(0)
            }

        }
    })
}
function getTotalTicket() {
    var $j = $(".total-ticket");
    $.ajax({
        type: "POST",
        url: Url({ Controller: "Ticket", Action: "Count" }),
        success: function (rs) {
            if (rs.Result && rs.Result == "OK") {
                $j.text(rs.Count)
            } else {
                $j.text(0)
            }

        }
    })
}

function formatAllVNDLabel() {
    $("span[data-vnd]").each(function () {
        if ($(this).data("vnd") == "formatted") {
            return;
        }
        $(this).text(new Number($(this).text()).formatVND())
        $(this).data("vnd", "formatted")
    })
}

