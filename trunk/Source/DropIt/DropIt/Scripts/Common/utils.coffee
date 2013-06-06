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
window.nullOrEmptyString = (val)->
    return "" if val is null 
    return val
window.listPropertiesOfObjectToCoffee=(obj,level)->
    
    output = ""
    if obj instanceof Object
        spaces = ""
        spaces += "\t" for i in [0..level]
        for key,value of obj
            if obj.hasOwnProperty(key)
                output+="\n#{spaces}#{key} : "
                output+=listPropertiesOfObjectToCoffee(obj[key],level+1)
    else
        output+="#{obj.toString()}"
    return output;

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
window.loading=(show)->
    if $("body").modalmanager
        if show is yes
            $("body").modalmanager('loading',false)
        else
            $("body").modalmanager('loading',true)

window.modalFactory = (options)->
    defaultOptions = 
        id:"modal"+new Date().getTime()
        tabindex: -1
        styles: ""
        backdrop: true # true | false | static
        headerText: "Modal header"
        bodyHTML: "<b>BodyHTML</b>"
        footerHTML: """
            <button type="button" data-dismiss="modal" class="btn">Close</button>
	        <button type="button" class="btn btn-primary">Ok</button>
        """

    options = $.extend({},defaultOptions,options);

    modalHTML = """
    <div id='#{options.id}' class='modal hide fade' data-backdrop='#{options.backdrop}' tabindex='#{options.tab}' style='#{options.styles}' aria-hidden='true'>
    <div class='modal-header'>
	    <button type='button' class='close' data-dismiss='modal' aria-hidden='true'>×</button>
	    <h3>#{options.headerText}</h3>
    </div>
    <div class='modal-body' style="">
	    #{options.bodyHTML}
    </div>
    <div class='modal-footer'>
	    #{options.footerHTML}
    </div></div>
    """
    $modal = $(modalHTML)
    $("document.body").append($modal)
    return $modal

$ ()->
    bootstrap.active()