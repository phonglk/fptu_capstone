# CoffeeScript
class AdminEvent
    constructor: (obj)->
        @self = this;
        for prop of obj
            @self[prop] = obj[prop] if obj.hasOwnProperty(prop) 
        @HoldDate = Date.fromRawJSON(@HoldDate)

window.AdminEvent = AdminEvent