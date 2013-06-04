# CoffeeScript
class AdminEvent
    constructor: (obj)->
        @self = this;
        for prop of obj
            @self[prop] = obj[prop] if obj.hasOwnProperty(prop) 

window.AdminEvent = AdminEvent