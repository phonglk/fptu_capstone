# CoffeeScript
defaultRoutingMapping = 
    getAll : 
        action : "Get"
    delete : 
        action : "Delete"
    detail :
        action : "Detail"
    edit :
        action : "Update"

class BaseViewModel
    constructor:({@itemViewModel,@bindingTarget,@routing,@entityMapping})->
        @self = this;    
        @routing = $.extend({},defaultRoutingMapping,@routing)

    getAll: ()->
        url = Url(Action:@routing.getAll.action)
        $.ajax
            url: url
            dataType:"json"
            success:(data) =>
                if data.Result?.length > 0
                    for item in data.Result 
                        @data.push new @itemViewModel(item)
                    ko.applyBindings(this,@bindingTarget)
                return
        return
    deleteItem:(item)->
        @data.remove(item)
    delete:()->
        url = Url(Action:@routing.delete.action)
        $.ajax
            url: url
            dataType:"json"
            data: ""
            success:(data) =>
                if data.Result?.length > 0
                    for item in data.Result 
                        @data.push new @itemViewModel(item)
                    ko.applyBindings(this,@bindingTarget)
                return
        return
    afterDelete:()->
    detail:()->
    edit:()->

    data:ko.observableArray([])

class EventIndexViewModel extends BaseViewModel
    constructor:()->
        super 
            itemViewModel:AdminEvent
            bindingTarget:$(".events-table")[0]
            entityMapping:
                Id : "EventId"
                EventName : { update : true }
window.eventIndexViewModel = new EventIndexViewModel();

$ ()->
    eventIndexViewModel.getAll();