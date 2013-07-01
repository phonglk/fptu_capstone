$(function () {
    $("[data-toggle=datetimepicker]").datetimepicker();
    $("[data-toggle=tooltip]").tooltip();
    getTotalTransaction();
    getTotalTicket();
    getTotalEvent();
    generateDataTracker();
})

function generateData(type, target) {
    function getData(url, callback) {
        $.ajax({
            url: url,
            type: "POST",
            cache: false,
            success:callback
        })
    }

    if (type == "category") {
        getData("/Category/getAll", function (data) {
            if (data.Records && data.Records.length > 0) {
                var html_lis = ""
                for (var i = 0; i < data.Records.length; i++) {
                    var cat = data.Records[i];
                    html_lis += "<li><a href='/Event/?CategoryId="+ cat.CategoryId + "'>" + cat.CategoryName + "</a></li>";
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

function requireLogin() {
    if (typeof isLogin != "undefined" && isLogin == false) {
        alert("Bạn cần đăng nhập để thực hiện hành động này");

        window.location = "/Account/Login?ReturnUrl=" + location.pathname;
        return false;

    } else {
        return true;
    }
}
function follow_btn_text($j) {
    var isFollow = $j.attr("data-follow") == "True" || $j.attr("data-follow") == "true";

    if (isFollow) {
        $j.text("Bỏ theo dõi")
    } else {
        $j.text("Theo dõi")
    }
}
function follow_init(){
    $(".btn-follow").each(function () {
        var $this = $(this);
        var eventId = $this.attr("data-eventId");

        follow_btn_text($this);

        $this.live("click", function (e) {
            if ($this.hasClass("disabled"))
                return;
            if (requireLogin()) {
                $this.addClass("disabled");

                $.ajax({
                    type: "POST",
                    url: "/Follow/Event/" + eventId,
                    cache: false,
                    dataType: "json",
                    success: function (rs) {
                        if (rs.Result == "OK") {
                            $this.attr("data-follow", rs.IsFollow);
                            follow_btn_text($this);
                        } else {
                            alert("Error:" + rs.Message)
                        }
                        $this.removeClass("disabled");
                    }
                });
            }
        });
    });
}

function getTotalTransaction() {
    var $j = $(".count-transaction");
    $.ajax({
        type:"POST",
        url: Url({ Controller: "Transaction", Action: "Count", Data: { id: -1, extra: "ontransaction"} }),
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
        url: Url({ Controller: "Ticket", Action: "Count"}),
        success: function (rs) {
            if (rs.Result && rs.Result == "OK") {
                $j.text(rs.Count)
            } else {
                $j.text(0)
            }

        }
    })
}