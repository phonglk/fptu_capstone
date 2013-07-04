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
$(function () {
    
})