﻿# CoffeeScript
ko.bindingHandlers.stopBindings =
    init: ->
        return controlsDescendantBindings: yes

ko.bindingHandlers.date =
    formattedDate : (date)->
        return "#{date.getDate()}/#{date.getMonth()}/#{date.getFullYear()} - #{date.getHours()}:#{date.getMinutes()}"
    init:(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) ->
        self = ko.bindingHandlers.date;
        date = ko.utils.unwrapObservable(valueAccessor());
        $(element).text(self.formattedDate(date))
        return
ko.bindingHandlers.tooltip = 
    init:(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) ->
        self = ko.bindingHandlers.tooltip;
        value = ko.utils.unwrapObservable(valueAccessor());
        data = value.data
        text = value.text || "tooltip"
        $a = $("<a href='javascript:void(0)' data-toggle='tooltip' title='#{data}'>#{text}</a>")
        $(element).html($a)
        bootstrap.active();
        return
ko.bindingHandlers.popover = 
    init:(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) ->
        self = ko.bindingHandlers.tooltip;
        value = ko.utils.unwrapObservable(valueAccessor());
        data = value.data || "you are missing data here"
        title = value.title || "title"
        text = value.text || "More"
        $a = $("<a href='javascript:void(0)' 
        data-toggle='popover' 
        title='#{title}' 
        data-content='#{data}'
        data-placement='top'
        data-trigger='hover'>#{text}</a>")
        $(element).html($a)
        bootstrap.active();
        return