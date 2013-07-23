function OptionRadio(arg) {
    var self = this;

    this.value;
    this.text;

    $.extend(self, arg);

    this.default = (typeof arg.default != "undefined");
    self.eid = "e_" + self.value + "_" + self.parent.uid

    this.html = function () {
        var html = '<div class="input"><input type="radio" id="#{eid}"  class="normal-radio" name="#{parent_uid}" value="#{value}" #{selectedMarkup}>'
        html += '<label for="#{eid}">#{text}</label></div>'
        html = $(html.eval({
            eid: self.eid,
            parent_uid: self.parent.uid,
            value: self.value,
            text: self.text,
            selectedMarkup: self.default == true ? " checked='checked'" : ""
        }))



        html.find("input").change(function () {
            self.parent.optionChange(self);
        });

        return html;
    }
}
function OptionRadioGroup(options) {
    var self = this;
    self.options = [];
    self.uid = "org_" + (OptionRadioGroup._i++) + "_" + new Date().getTime();
    $.each(options, function (i, e) {
        e.parent = self;
        self.options.push(new OptionRadio(e));
    })

    self.change = function (value) {

    }

    self.findByEid = function (eid) {
        var rs = null;
        $.each(self.options, function (i, e) {
            if (e.eid == eid) {
                rs = e;
                return;
            }
        });

        return rs;
    }

    self.bind = function (jSelector) {
        var tar = $(jSelector);
        $.each(self.options, function (i, e) {
            tar.append(e.html());
        })
    }
    self.value = function () {
        var $checked = $("[name='#{uid}']:checked".eval(self));
        var eid = $checked.attr("id");
        var option = self.findByEid(eid);
        if (option != null) {
            return option.value
        }
        return null;
    };
    self.optionChange = function (option) {
        self._change();
    }
    self._change = function () {
        self.change.call(self, self.value());
    }

}
OptionRadioGroup._i = 0;

function Category(obj) {
    var self = this;

    this.CategoryId = -1;
    this.CategoryName = "";

    $.extend(self, obj);
}

function Ticket(obj) {
    var self = this;

    this.TicketId = -1;
    this.SellPrice = "";
    this.SeriesNumber = "";
    this.ReceiveMoney = "";
    this.Seat = "";
    this.Description = "";

    $.extend(self, obj);
    if (self.Description == null) self.Description = "";

}

function Transaction(obj) {
    var self = this;

    this.TicketId = -1;
    this.SellPrice = "";
    this.TranFullName = "";
    this.TranType = "";
    this.TranAddress = "";
    this.TranUserId = "";
    $.extend(self, obj);
    if (self.TranShipDate != null) {
        this.TranShipDate = Date.fromRawJSON(self.TranShipDate);
    }
    if (self.TranDescription == null) self.TranDescription = "";
    if (self.ShippingCost == null) self.ShippingCost = "";
    if (self.TranShipCode == null) self.TranShipCode = "";
    if (self.TranPaymentStatus == null) self.TranPaymentStatus = "";
    html = "<strong>Địa chỉ</strong>: " + self.TranAddress;
    html += "<br/><strong>Chú thích</strong>: " + self.TranDescription;
    self.TranDetail = html.eval(self);
}

function Venue(obj) {
    var self = this;

    this.VenueId = -1;
    this.VenueName = "";
    this.Address = "";
    this.Province = null;
    this.Description = "";

    $.extend(self, obj);
    if (self.Description == null) self.Description = "";
    if (obj.Province) {
        self.Province = new Province(obj.Province);
    }

    html = "<strong>Địa chỉ</strong>: " + self.Address;
    html += "<br/><strong>Tỉnh/Thành phố</strong>: " + self.Province.ProvinceName;
    html += "<br/><strong>Chú thích</strong>: " + self.Description;

    self.VenueDetail = html.eval(self);
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
    try{
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
    } catch (e) {
        console.info(e.message);
    }
}

function User(obj) {
    var self = this;
    self.UserId = -1;
    self.UserName = "";
    self.FullName = "";
    self.Email = "";
    self.Address = "";
    self.Province = null;
    self.Phone = "";
    self.Active = true;
    self.Sellable = false;
    self.CreatedDate;
    self.ModifiedDate;

    $.extend(self, obj);

    try{
        self.Category = new Category(obj.Category);
        self.Active = ko.observable(obj.Active);
        self.Sellable = ko.observable(obj.Sellable);
        self.CreatedDate = Date.fromRawJSON(obj.CreatedDate);
        self.ModifiedDate = Date.fromRawJSON(obj.ModifiedDate);

        self.Active.subscribe(function(newValue){
            list.AjaxUpdate({
                item: self,
                urlData : {Action:"UpdateActive", Data : { UserId : self.UserId, Active: newValue }},
                callback:function(user){
                    var text = "Người dùng <strong>#{UserName}</strong> đã được ".eval(user);
                    if(newValue){
                        text += "kích hoạt"
                    }else{
                        text += "hủy kích hoạt"
                    }
                    Notifications.push({
                        text: text,
                        autoDismiss: 2
                    })
                }
            });
        },self)

        self.Sellable.subscribe(function (newValue) {
            list.AjaxUpdate({
                item: self,
                urlData : {Action:"UpdateActive", Data : { UserId : self.UserId, Active: newValue }},
                callback:function(user){
                    var text = "Người dùng <strong>#{UserName}</strong> đã ".eval(user);
                    if(newValue){
                        text += "được phép bán vé"
                    }else{
                        text += "không được bán vé"
                    }
                    Notifications.push({
                        text: text,
                        autoDismiss: 2
                    })
                }
            });
        })
    } catch (e) {

    }
}

function DataList() {
    var self = this;

    self.data = ko.observableArray([])
    self.extraData = {};
    self.dataClass = Event;
    

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
        var data = { jtPageSize: self.pageSize, jtStartIndex: self.startIndex(), jtSorting: self.sorting };
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
                        self.data.push(new self.dataClass(v));
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
     
    // just use for update, no prevent action and no reload
    self.AjaxUpdate = function (obj) {
        Loading(true);
        $.ajax({
            url: Url(obj.urlData),
            type: "POST",
            success: function (rs) {
                Loading(false);
                if (rs.Result && rs.Result == "OK") {
                    if (obj.callback) {
                        obj.callback.call(this, obj.item)
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