(function () {

    ko.bindingHandlers.stopBindings = {
        init: function () {
            return {
                controlsDescendantBindings: true
            };
        }
    };

    ko.bindingHandlers.date = {
        formattedDate: function (date) {
            try {
                if (typeof date == "string") {
                    date = Date.fromRawJSON(date);
                }
                return "" + (new Number(date.getDate())).toLength(2) + "/" + (new Number(date.getMonth())).toLength(2) + "/" + (date.getFullYear()) + " " + (new Number(date.getHours())).toLength(2) + ":" + (new Number(date.getMinutes())).toLength(2) + ":00";
            } catch (e) {
                console.error(e.message);
                return date;
            }
        },
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var date, self;
            self = ko.bindingHandlers.date;
            date = ko.utils.unwrapObservable(valueAccessor());
            if (element.tagName.toLowerCase() === "input") {
                debugger;
                $(element).val(self.formattedDate(date));
            } else {
                $(element).text(self.formattedDate(date));
            }
        }
    };
    ko.bindingHandlers.date.update = ko.bindingHandlers.date.init

    ko.bindingHandlers.tooltip = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var $a, data, self, text, value;
            self = ko.bindingHandlers.tooltip;
            value = ko.utils.unwrapObservable(valueAccessor());
            data = value.data;
            text = value.text || "tooltip";
            $a = $("<a href='javascript:void(0)' data-toggle='tooltip' title='" + data + "'>" + text + "</a>");
            $(element).html($a);
            bootstrap.active();
        }
    };

    ko.bindingHandlers.popover = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var $a, data, self, text, title, value;
            self = ko.bindingHandlers.tooltip;
            value = ko.utils.unwrapObservable(valueAccessor());
            data = value.data || "No content";
            title = value.title || "Title";
            text = value.text || "More";
            $a = $("<a href='javascript:void(0)'         data-toggle='popover'         title='" + title + "'         data-content='" + data + "'        data-placement='top'        data-trigger='hover'>" + text + "</a>");
            $(element).html($a);
            bootstrap.active();
        }
    };

    //https://github.com/ivaynberg/select2/wiki/Knockout.js-Integration
    ko.bindingHandlers.select2 = {
        init: function (element, valueAccessor, allBindingsAccessor) {
            var obj = valueAccessor(),
                allBindings = allBindingsAccessor(),
                lookupKey = allBindings.lookupKey;
            $(element).select2(obj);
            if (lookupKey) {
                var value = ko.utils.unwrapObservable(allBindings.value);
                $(element).select2('data', ko.utils.arrayFirst(obj.data.results, function (item) {
                    return item[lookupKey] === value;
                }));
            }

            ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                $(element).select2('destroy');
            });
        },
        update: function (element) {
            $(element).trigger('change');
        }
    };
});