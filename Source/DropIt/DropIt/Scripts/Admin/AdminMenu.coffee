# CoffeeScript
class MenuAdmin
    constructor: ({@Name,@Controller,@Action,@Url,@Icon,@Childs}) ->
        @self = this;

        @Area = "Administration"

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
            if child.Area?
                child.Url = "/#{@Area}";
            else
                child.Url = "";
            child.Url += "/#{child.Controller}/#{child.Action}"
            if @Controller?.toLowerCase() is Routing.Controller.toLowerCase() and child.Action?.toLowerCase() is Routing.Action.toLowerCase()
                child.IsActive = true;
        if @Url is null
            if @Area?
                @Url = "/#{@Area}";
            else
                @Url = "";
            @Url += "/#{@Controller}/"
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
        Action : "Index"
        Icon : "volume-up"
        Childs : [
            new MenuAdmin 
                Name : "Event List"
                Action : "Index"
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
    
    new MenuAdmin 
        Name : "Tỉnh"
        Controller : "Province"
        Icon : "map-marker"
    ]

$ ()->
    ko.applyBindings({_MenuAdmin:menuAdmins },$("#dashboard-menu")[0])
    ko.applyBindings({_MenuAdmin:menuAdmins },$("#tabs-wrapper")[0])