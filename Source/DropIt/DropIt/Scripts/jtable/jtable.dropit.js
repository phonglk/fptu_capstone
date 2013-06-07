(function ($) {
    // Custom for project's needs
    var defaultOptions = {

    }

    var customFunction = {
        unique: function (fieldName,fieldOptions,options) {
            var myCustom = {}
            var myCustomNameFunc = "DropItRule" + new Date().getTime();
            var myCustomNameAjax = myCustomNameFunc + "Ajax";

            myCustom[myCustomNameFunc] = {
                "func": function (field, rules, i, options) {
                    options.allrules[myCustomNameAjax].extraData = fieldName + "=" + field.val();
                    return true;
                },
                "alertText":"This just a dummy"
            }
            myCustom[myCustomNameAjax] = {
                url: options.actions.uniqueAction,
                extraData: "nodata",
                alertText: "Giá trị không hợp lệ",
                alertTextLoad : "Đang kiểm tra..."
            }
            window[myCustomNameFunc] = myCustom[myCustomNameFunc].func;
            $.extend($.validationEngineLanguage.allRules, $.validationEngineLanguage.allRules, myCustom);

            return "funcCall["+myCustomNameFunc+"],ajax["+myCustomNameAjax+"]";
        }
    }

    if (!window.dropit) window.dropit = {}
    dropit.jtInit = function (options) {
        options = $.extend({}, defaultOptions, options);

        if (options.actions) {
            var acts = options.actions,
				listActs = {
				    'listAction': { Action: "List" },
				    'deleteAction': { Action: "Delete" },
				    'updateAction': { Action: "Update" },
				    'createAction': { Action: "Create" },
                    'uniqueAction': { Action: "CheckUnique"}
				}
            currentRouting = Routing;

            if (acts.base) {
                currentRouting = $.extend({}, currentRouting, acts.base);
                acts = $.extend(true,{}, listActs, acts);
                listActs.eachOwnProperties(function (p, v, a) {
                    var newRouting = acts[p]
                    newRouting = $.extend({}, currentRouting, newRouting);
                    acts[p] = Url(newRouting);
                })
                options.actions = acts;
            }
        }

        flagValidation = false;

        if (options.fields) {
            options.fields.eachOwnProperties(function (fieldName, value, fields) {
                value.eachOwnProperties(function (name, value, field) {
                    if (name == "validation") {
                        var classes = "validate["
                        for (var i = 0; i < value.length; i++) {
                            if (i > 0) classes += ",";
                            var ruleName = value[i];
                            if (customFunction.hasOwnProperty(ruleName)) {
                                ruleName = customFunction[ruleName].call(this, fieldName, field, options);
                            }
                            classes += ruleName
                        }
                        classes += "]"

                        if (field.inputClass) {
                            classes = field.inputClass + " " + classes
                        }
                        field.inputClass = classes
                        flagValidation = true;
                    }
                })
            })
            if (flagValidation == true) {
                var injectingEvents = ['formCreated', 'formSubmitting', 'formClosed']
                for (var i = 0; i < injectingEvents.length; i++) {
                    var event = injectingEvents[i];
                    var storedEvent = function () { };

                    (function (event, storedEvent) {
                        if (options[event]) {
                            storedEvent = options[event]
                        }
                        options[event] = function (evt, data) {
                            switch (event) {
                                case "formCreated":
                                    
                                    data.form.validationEngine('attach', {
                                        promptPosition: "topLeft",
                                        onValidationComplete: function (from, status) {

                                            return false;
                                        },
                                        scroll:false
                                    });
                                    $(".jtable-dialog-form").bind("keypress",function (e) {
                                        
                                        try{
                                            
                                        } catch (e) {
                                            
                                        }
                                        if (e.keyCode == 13) {
                                            //$(".ui-dialog-buttonset button:eq(2)").trigger("click");
                                        }
                                        return true;
                                    })
                                    break;
                                case "formSubmitting":
                                    return data.form.validationEngine('validate');
                                    break;
                                case "formClosed":
                                    data.form.validationEngine('hide');
                                    data.form.validationEngine('detach');
                                    break;
                            }

                            storedEvent.call(this, evt, data);
                        }
                    })(event, storedEvent)
                }
            }
        }

        return options
    }
})(jQuery)
