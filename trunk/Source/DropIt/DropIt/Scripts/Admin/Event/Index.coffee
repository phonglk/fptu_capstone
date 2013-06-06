# CoffeeScript

        

class EventIndexViewModel extends BaseViewModel
    constructor:()->
        super 
            itemViewModel:AdminEvent
            bindingTarget:$(".events-table")[0]
            entityMapping:
                Id :
                    keyName: "EventId"
                    requestName: "Id"
                EventName : 
                    label : "Tên sự kiện"
                    index : 1
                Artist : 
                    label : "Nghệ sĩ tham gia"
                    index : 2
                HoldDate : 
                    label : "Ngày tổ chức"
                    index : 3
                Description : 
                    label : "Chú thích"
                    index : 6
                Status : 
                    detail :
                        allow : false
                Category : 
                    label : "Danh mục"
                    index : 4
                Venue : 
                    label : "Địa điểm tổ chức"
                    index : 5
                RequestCount : 
                    label : "Số lượt yêu cầu vé"
                FollowerCount : 
                    label : "Số lượt theo dõi"
                CreatedDate : 
                    detail:
                        allow:false
                ModifiedDate : 
                    label : "Ngày cập nhật gần nhất"
                    
window.eventIndexViewModel = new EventIndexViewModel();

$ ()->
    eventIndexViewModel.getAll();