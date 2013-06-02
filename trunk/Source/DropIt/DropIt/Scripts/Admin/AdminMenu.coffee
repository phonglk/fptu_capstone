# CoffeeScript
class MenuAdmin
    constructor: ({@Name,@Controller,@Action,@Url,@Icon}) ->
        @self = this;

        @Name ?= "NoName"
        @Controller ?= null
        @Action ?= null
        @Url ?= null
        @Icon ?= "chevron-sign-right"
        @IsActive = false

        if @Url is null
            @Url = "/#{@Controller}/"
            @IsActive = true if @Controller.toLowerCase() is Routing.Controller.toLowerCase()
            @Url += "#{@Action}/" if @Action isnt null

menuAdmins = [
    new MenuAdmin 
        Name : "Dashboard"
        Controller : "Admin"
        Icon : "home"
    new MenuAdmin 
        Name : "User"
        Controller : "User"
    new MenuAdmin 
        Name : "Ticket"
        Controller : "Ticket"
        Action : "AdminList"
    new MenuAdmin 
        Name : "Danh mục"
        Controller : "Category"
        Icon : "reorder"
    new MenuAdmin 
        Name : "Sự kiện"
        Controller : "Event"
        Action : "AdminList"
        Icon : "volume-up"
    new MenuAdmin 
        Name : "Địa điểm"
        Controller : "Venue"
        Icon : "hospital"
    ]

$ ()->
    ko.applyBindings({_MenuAdmin:menuAdmins },$("#sidebar-nav")[0])