# CoffeeScript
moduleKeywords = ['extended', 'included']

class Module
  @extend: (obj) ->
    for key, value of obj when key not in moduleKeywords
      @[key] = value

    obj.extended?.apply(@)
    this

  @include: (obj) ->
    for key, value of obj when key not in moduleKeywords
      # Assign properties to the prototype
      @::[key] = value

    obj.included?.apply(@)
    this
#Static function
Date.fromRawJSON = (string)->
    return new Date(parseInt(string.match(/\d+/)))
String::makeExcerpt = (length) ->
    return "#{this.substr(0,length)}..."
window.toFormData = (obj)->
    str = ""
    for key,value of obj
        if obj.hasOwnProperty(key)
            str+="#{key}=#{value}&"
    if str.length > 0
        str = str.substr(0,str.length-1)
    return str;

window.bootstrap = 
    active: ()->
        $('[data-toggle="tooltip"][data-active!="actived"]').each ()->
            self = $  this
            self.tooltip()
            self.attr("data-active","actived")
        $('[data-toggle="popover"][data-active!="actived"]').each ()->
            self = $  this
            self.popover()
            self.attr("data-active","actived")

window.Url = ({Area,Controller,Action})->
    newRouting = $.extend({},Routing,{Area,Controller,Action})
    url = ""
    url += "/#{newRouting.Area}" if newRouting.Area? != ""
    url += "/#{newRouting.Controller}/"
    url += "#{newRouting.Action}" if newRouting.Action? != "" or newRouting.Action? !="Index"
    return url

$ ()->
    bootstrap.active()