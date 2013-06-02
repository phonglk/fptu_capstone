# CoffeeScript
class MenuAdmin
    constructor: ({@Name,@Controller,@Action,@Url,@Icon}) ->
        @self = this;

        @Name ?= "NoName"
        @Controller ?= null
        @Action ?= null
        @Url ?= null
        @Icon = "reorder"

        if @Url is null
            @Url = "/#{@Controller}/"
            @Url += "#{@Action}/" if @Action isnt null

window._MenuAdmin = [
    new MenuAdmin 
        Name : "Home"
        Controller : "Admin"
        Icon : "home"
    new MenuAdmin 
        Name : "User"
        Controller : "User"
    new MenuAdmin 
        Name : "Ticket"
        Controller : "Ticket"
        Action : "AdminList"
    ]