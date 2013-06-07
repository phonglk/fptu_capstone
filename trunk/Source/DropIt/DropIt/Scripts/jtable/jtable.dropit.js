(function ($) {
    // Custom for project's needs
    var defaultOptions = {

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
				    'createAction': { Action: "Create" }
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
            options.fields.eachOwnProperties(function (name, value, fields) {
                value.eachOwnProperties(function (name, value, field) {
                    if (name == "validation") {
                        var classes = "validate["
                        for (var i = 0; i < value.length; i++) {
                            if (i > 0) classes += ","
                            classes += value[i]
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
                                    data.form.validationEngine({ promptPosition: "topLeft" });
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
