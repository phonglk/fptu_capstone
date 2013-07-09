

function Category(obj) {
    var self = this;

    this.CategoryId = -1;
    this.CategoryName = "";

    $.extend(self, obj);
}

function Venue(obj) {
    var self = this;

    this.VenueId = -1;
    this.VenueName = "";
    this.Address = "";
    this.Province = null;

    $.extend(self, obj);

    if (obj.Province) {
        self.Province = new Province(obj.Province);
    }
}
function Province(obj) {
    var self = this;

    this.ProvinceId = -1;
    this.ProvinceName = "";

    $.extend(self, obj);
}
function Event(obj) {
    var self = this;
    self.EventId = -1;
    self.EventName = "";
    self.EventImage = "";
    self.Artist = "";
    self.HoldDate = null;
    self.Description = "";
    self.Status = -1;
    self.Category = null;
    self.Venue = null;

    $.extend(self, obj);
    self.Category = new Category(obj.Category);
    self.Venue = new Venue(obj.Venue);
    self.HoldDate = Date.fromRawJSON(self.HoldDate);
    if (self.Description == null) self.Description = "";

    var html = "<div class='event-detail' style='width:500px'>";
    if (self.EventImage != null) {
        html += ("<img width=150 src='" + Url(self.EventImage) + "' style='float:left;display:block'/>")
    }
    html += ("<div style='float:left;padding-left:10px'><div><strong>Thuộc danh mục</strong>: #{CategoryName} </div>".eval(self.Category))
    html += ("<div><strong>Ngày giờ diễn ra</strong>: " + self.HoldDate.toLocaleString("vn") + "</div>")
    html += ("<div><strong>Nghệ sĩ tham gia</strong>: #{Artist} </div>")
    html += ("<div><strong>Địa điểm</strong>: #{VenueName} </div>".eval(self.Venue))
    html += ("</div><div style='clear:both'> " + self.Description + " </div></div>")

    self.EventDetail = html;
    self.EventDetail = self.EventDetail.eval(self);

    html = "<strong>Địa chỉ</strong>: " + self.Venue.Address;
    html += "<br/><strong>Tỉnh/Thành phố</strong>: " + self.Venue.Province.ProvinceName;

    self.VenueDetail = html.eval(self);
}
function DataList() {
    var self = this;

    self.data = ko.observableArray([])
    self.extraData = {};
    

    self.url_getList = { Controller: "", Action: "" };

    self.pageSize = 5;
    self.currentPage = ko.observable(1);
    self.startIndex = ko.computed(function(){
        return (self.currentPage() - 1) * self.pageSize;
    })
    self.sorting = "";
    self.recordCount = ko.observable(0);
    self.pageCount = ko.computed(function () {
        return Math.ceil(self.recordCount() / self.pageSize);
    })

    self.changePage = function (index) {
        var page = index + 1;
        if (self.currentPage == page) return;
        self.currentPage(page);
        self.getList();
    }
    self.sort = function (column, data, event) {
        if (typeof self._sort == "undefined") {
            self._sort = [];
        }
        if (typeof self._sort[column] == "undefined") {
            self._sort[column] = "DESC"
        } else {
            if (self._sort[column] == "ASC") {
                self._sort[column] = "DESC"
            } else {
                self._sort[column] = "ASC"
            }
        }

        var $th = $(event.target);
        $th.removeClass("asc").removeClass("desc").addClass(self._sort[column].toLowerCase());

        self.sorting = column + " " + self._sort[column];
        self.getList();
    }

    self.getList = function (callback) {
        Loading(true);
        var data = { jtPageSize: self.pageSize, jtStartIndex: self.startIndex(), jtSorting: self.sorting, EventStatus: self.EventStatus };
        $.extend(data, self.extraData);
        var urlData = { Action: "List", Controller: "Event", Data: data };
        $.extend(urlData, self.url_getList);
        $.ajax({
            url: Url(urlData),
            type: "POST",
            success: function (rs) {
                Loading(false);
                if (rs.Result && rs.Result == "OK") {
                    self.data.removeAll();
                    $.each(rs.Records, function (i, v) {
                        self.data.push(new Event(v));
                    })
                    self.recordCount(rs.TotalRecordCount);
                }
                setTimeout(function () {
                    bootstrap.active();
                }, 100);
                if (callback) {
                    callback.call();
                }
            }
        })
    }

    // obj = {item,urlData,callback,callbackOnFail}
    self.AjaxAction = function (obj) {
        Loading(true, true);
        $.ajax({
            url: Url(obj.urlData),
            type: "POST",
            success: function (rs) {
                Loading(false);
                if (rs.Result && rs.Result == "OK") {
                    self.getList();
                    if (obj.callback) {
                        obj.callback.call(this,obj.item)
                    }
                } else {
                    if (obj.callbackOnFail) {
                        obj.callbackOnFail.call();
                    }
                }
            }
        })
    }
    
}

previewUpload = function () {
    var inputs = $("input.previewUpload");
    if (inputs.attr("previewHanlder") != "true") {
        inputs.css({ "visibility": "hidden" ,position:"absolute",top:-1000});
        $("img.previewUpload").css("cursor", "pointer");
        $("img.previewUpload").click(function () {
            inputs.trigger("click");
        })
        inputs.change(function () {
            var reader = new FileReader();
            reader.readAsDataURL(inputs[0].files[0]);
            reader.onload = function (readerEvent) {
                $("img.previewUpload").attr("src", readerEvent.target.result);
            }
        })
        inputs.attr("previewHanlder", "true");
    }
}

$(function () {
    
})