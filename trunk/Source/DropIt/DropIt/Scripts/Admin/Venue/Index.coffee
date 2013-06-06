# CoffeeScript
class AdminVenue extends AdminEvent

class VenueIndexViewModel extends BaseViewModel
    constructor:()->
        super 
            itemViewModel:AdminVenue
            bindingTarget:$(".venues-table")[0]
            entityMapping:
                Id :
                    keyName: "VenueId"
                    requestName: "Id"
                VenueName : 
                    label : "Tên địa điểm"
                Address : 
	                label : "Địa chỉ"
                ProvinceName : 
	                label : "Tỉnh"
                Description : 
	                label : "Chú thích"
        @filterRegister "EditModalHTMLCreationAfter", (data)=>
            data.find(".modal-header h3").html("Chi tiết địa điểm - <span data-bind='text: VenueName'></span>")
            return data;
window.venueIndexViewModel = new VenueIndexViewModel();

$ ()->
    venueIndexViewModel.getAll();