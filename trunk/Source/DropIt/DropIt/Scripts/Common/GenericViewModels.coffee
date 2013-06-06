# CoffeeScript
defaultRoutingMapping = 
    getAll : 
        action : "Get"
    delete : 
        action : "Delete"
    detail :
        action : "Details"
    edit :
        action : "Update"




class BaseViewModel
    ###entityMapping:
        Id : {
            keyname : entityId
            requestName : [name on requesting]
        }
        keyName: {
            originalType : "unknown"
            list : {
                allow : true
                index : [based on order]
                type : [base on originalType]
            }
            detail : {
                allow : true
                index : [based on order]
                type : [base on originalType
            }
            edit : {
                allow : true
                index : [based on order]
                type : [base on originalType
            }
        }
        Hook Lists : 
            BeforeValidateEntityMapping
            AfterValidateEntityMapping
            BeforeGetAllItems
            AfterGetAllItems
            BeforeDeleteItem
            AfterDeleteItemSuccess
            AfterDeleteItemFail
            AfterDeleteItem
    ###
    constructor:({@itemViewModel,@bindingTarget,@routing,@entityMapping})->
        `var self = this`   
        @self = this;    
        @routing = $.extend({},defaultRoutingMapping,@routing)
        @data=ko.observableArray([])
        @currentItemDetail = ko.observable({})
        @_hooks = {}
        @_filters = {}

        @hookRegister = (name,handler) =>
            @_hooks[name] = handler

        @callHook = (name,ctx) =>
            if @_hooks[name]
                if !ctx 
                    ctx = this
                @_filters[name].call(ctx)

        @filterRegister = (name,handler) =>
            @_filters[name] = handler

        @callFilter = (name,water,ctx) =>
            if @_filters[name]
                if !ctx 
                    ctx = this
                return @_filters[name].call(ctx,water)
            return water

        @getItemId = (item) =>
            return item[@entityMapping.Id.keyName]

        @reorderFieldByIndex=(action)=>
            fields = {}
            max = -1
            for key,value of @entityMapping
                continue if key == "Id"
                max = value[action].index if value[action].index > max

            for i in [1..max]
                for key,value of @entityMapping
                    continue if key == "Id"
                    if value[action].index == i
                        fields[key] = @entityMapping[key]
            fields["Id"] = @entityMapping.Id
            return fields

        @validateEntityMapping = ()=>
            if @data().length>0
                @callHook("BeforeValidateEntityMapping")
                currentKeys = []
                currentKeys.push(key) for key,value of @entityMapping
                sample = @data()[0]
                delete sample.self
                delete sample.constructor
                for key,value of sample
                    continue if not sample.hasOwnProperty(key)
                    continue if @entityMapping.Id.keyName == key 
                    continue if key in currentKeys
                    @entityMapping[key] = {}
                
                _i = 0;
                for key,value of @entityMapping
                    _i++;
                    continue if key == "Id"

                    if value.originalType
                        originalType = @entitMapping.originalType
                    else
                        originalType = typeof sample[key];
                        if originalType isnt "string" or originalType isnt "number"
                            originalType = "datetime" if sample[key] instanceof Date

                    if value.label
                        label = value.label
                    else
                        label = key
                    if value.index
                        index = value.index
                    else
                        index = _i

                    defaultMapping = 
                        originalType : originalType
                        label : label
                        index : index
                        list :
                            allow : true
                            index : index
                            type : originalType
                        detail :
                            allow : true
                            index : index
                            type : originalType
                        edit :
                            allow : true
                            index : index
                            type : originalType
                    @entityMapping[key] = $.extend({},defaultMapping,value)
                    @callHook("AfterValidateEntityMapping")

        @getAll = ()=>
            loading(true)
            @callHook("BeforeGetAllItems")
            url = Url(Action:@routing.getAll.action)
            $.ajax
                url: url
                dataType:"json"
                success:(data) =>
                    loading(false)
                    if data.Result?.length > 0
                        for item in data.Result 
                            @data.push new @itemViewModel(item)

                        @callHook("AfterGetAllItems")
                        @validateEntityMapping();
                        ko.applyBindings(this,@bindingTarget)
                    return
            return

        @deleteItem=(item)=>
            key = item[@entityMapping.Id.keyName]
            if key
                @delete(item)
            else
                alert("Not found '#{@entityMapping.Id}'")

        @delete=(item)=>
            @callHook("BeforeDeleteItem")
            url = Url(Action:@routing.delete.action)
            idKeyName = @entityMapping.Id.requestName
            idKeyValue = item[@entityMapping.Id.keyName]
            data = {}
            data[idKeyName] = idKeyValue
            data = toFormData(data)
            $.ajax
                url: url
                type: "post"
                dataType:"json"
                data: data
                success:(data) =>
                    if data.IsOK? is true
                        return @afterDelete(isSuccess:true,item:item)
                    return @afterDelete(isSuccess:false,item:item)
            return
        @afterDelete=({isSuccess,item})=>
            if isSuccess is yes 
                @data.remove(item)
                @callHook("AfterDeleteItemSuccess",this)
            else
                alert("Deletion not complete");
                @callHook("AfterDeleteItemFail",this)
            @callHook("AfterDeleteItem",this)

        @detailItem = (item) =>
            if !@$editModal
                fields = @reorderFieldByIndex("detail")
                html= ""
                for key,value of fields
                    continue if key == "Id"
                    html+="""
                    <div class="detail-row">
                        <span class="span5 detail-label">#{value.label} :</span>
                    
                    """
                    if value.detail.type == "datetime"
                        html+="""
                            <span class="span7 detail-data" data-bind='date: #{key}'></span>
                        </div>
                        """
                    else
                        html+="""
                            <span class="span7 detail-data" data-bind='text: #{key}'></span>
                        </div>
                        """

                modalBody = """
    <div class="row-fluid area-detail">
            #{html}
    </div>
                """

                footerHTML = """
                <button type="button" data-dismiss="modal" class="btn btn-danger" data-bind="click: root.editItem">Edit</button>
	            <button type="button" data-dismiss="modal" class="btn btn-primary">Ok</button>
                """

                modalHTML = modalFactory
                    bodyHTML : modalBody
                    headerText : "Detail #{@entityMapping.Id.keyName} <strong>#<span data-bind='text: #{@entityMapping.Id.keyName}'></span></strong>" 
                    footerHTML : footerHTML
                    id : "editModal"
                @$editModal = @callFilter("EditModalHTMLCreationAfter",$(modalHTML))
                $(document.body).append(@$editModal)
            @currentItemDetail = item
            @currentItemDetail.root = this
            ko.applyBindings(this.currentItemDetail,@$editModal[0])
            @$editModal.modal()
        @detail=()->

        @editItem = (item)=>
            
        @edit=()->

window.BaseViewModel = BaseViewModel;