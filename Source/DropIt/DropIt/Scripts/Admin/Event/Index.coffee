# CoffeeScript
window.eventIndexViewModel = 
    events : []
i = 0;
GetAll = ()->
    $.ajax 
        url: 'Get'
        dataType:"json"
        success:(data)->
            if data.Result?
                for event in data.Result 
                    eventIndexViewModel.events.push new AdminEvent(event)
                console.log(eventIndexViewModel);
                ko.applyBindings(eventIndexViewModel,$(".events-table")[0])
            return true
    return true
$ ()->
    GetAll();