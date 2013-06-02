# CoffeeScript
class MenuAdmin
    constructor: ({@Name,@Controller,@Action,@Url,@Icon,@Childs}) ->
        @self = this;

        @Name ?= "NoName"
        @Controller ?= null
        @Action ?= null
        @Url ?= null
        @Icon ?= "chevron-sign-right"
        @IsActive = false
        @Parent = null
        @Childs ?= []

        for child in @Childs
            child.Parent = this
            child.Controller = @Controller
            child.Url = "/#{child.Controller}/#{child.Action}"
            if @Controller?.toLowerCase() is Routing.Controller.toLowerCase() and child.Action?.toLowerCase() is Routing.Action.toLowerCase()
                child.IsActive = true;
        if @Url is null
            @Url = "/#{@Controller}/"
            @IsActive = true if @Controller?.toLowerCase() is Routing.Controller.toLowerCase()

            @Url += "#{@Action}/" if @Action isnt null

window.menuAdmins = [
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
        Childs : [
            new MenuAdmin 
                Name : "Event List"
                Action : "List"
            new MenuAdmin 
                Name : "Create"
                Action : "Create"
            new MenuAdmin 
                Name : "Aprrove"
                Action : "Approve"
        ]
    new MenuAdmin 
        Name : "Địa điểm"
        Controller : "Venue"
        Icon : "hospital"
    ]

$ ()->
    ko.applyBindings({_MenuAdmin:menuAdmins })