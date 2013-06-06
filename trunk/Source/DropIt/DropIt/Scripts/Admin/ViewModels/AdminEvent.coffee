# CoffeeScript
class AdminEvent
    constructor: (obj)->
        @self = this;
        for prop of obj
            if obj.hasOwnProperty(prop)
                value = obj[prop]
                value = Date.fromRawJSON(value) if /\/Date\(\d+\)\//.test(value)
                @self[prop] = value

window.AdminEvent = AdminEvent