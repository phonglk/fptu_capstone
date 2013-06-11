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
                                    $(".jtable-dialog-form select").select2();
                                    $.each($(".select2-container"), function (i, n) {
                                        $(n).next().show().fadeTo(0, 0).height("0px").css("left", "auto"); // make the original select visible for validation engine and hidden for us
                                        $(n).prepend($(n).next());
                                        $(n).delay(500).queue(function () {
                                            $(this).removeClass("validate[required]"); //remove the class name from select2 container(div), so that validation engine dose not validate it
                                            $(this).dequeue();
                                        });
                                    });
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
                                    var valid = data.form.validationEngine('validate', { ignore: "div" });
                                    
                                    return valid;
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

    $.hik.jtable.prototype._getDisplayTextForDateTimeRecordField = function (field, fieldValue) {
        if (!fieldValue) {
            return '';
        }

        var displayFormat = field.displayFormat || this.options.defaultDateFormat;
        var date = this._parseDate(fieldValue);
        return $.format.date(date, field.displayFormat)
        //return $.datepicker.formatDate(displayFormat, date);
    }

    $.hik.jtable.prototype._getDisplayTextForRecordField = function (record, fieldName) {
        var field = this.options.fields[fieldName];
        var fieldValue = record[fieldName];

        //if this is a custom field, call display function
        if (field.display) {
            return field.display({ record: record });
        }

        if (field.type == 'date') {
            return this._getDisplayTextForDateRecordField(field, fieldValue);
        } else if (field.type == 'datetime') {
            return this._getDisplayTextForDateTimeRecordField(field, fieldValue);
        } else if (field.type == 'checkbox') {
            return this._getCheckBoxTextForFieldByValue(fieldName, fieldValue);
        } else if (field.options) { //combobox or radio button list since there are options.
            var options = this._getOptionsForField(fieldName, {
                record: record,
                value: fieldValue,
                source: 'list',
                dependedValues: this._createDependedValuesUsingRecord(record, field.dependsOn)
            });
            return this._findOptionByValue(options, fieldValue).DisplayText;
        } else { //other types
            return fieldValue;
        }
    }

    $.hik.jtable.prototype._createDateTimeInputForField = function (field, fieldName, value) {

        var html = "<div class='input-append' id='#{0}Picker'>"
        html += "<input data-format='#{1}' class='#{2}' type='text' name='#{0}' data-toggle='datetimepicker'/>"
        html += "<span class='add-on'><i class='icon-calendar'></i></span></div>";
        html = $(html.eval(fieldName, field.displayFormat, field.inputClass));
        //var $input = $('<input class="' + field.inputClass + '" id="Edit-' + fieldName + '" type="text" name="' + fieldName + '"></input>');
        if (value != undefined) {
            html.find("input").val($.format.date($.hik.jtable.prototype._parseDate(value), field.displayFormat));
        }
            
        //var displayFormat = field.displayFormat || this.options.defaultDateFormat;
        return $('<div />')
            .addClass('jtable-input jtable-date-input')
            .append(html);
    }

    $.hik.jtable.prototype._createInputForRecordField = function (funcParams) {
        var fieldName = funcParams.fieldName,
            value = funcParams.value,
            record = funcParams.record,
            formType = funcParams.formType,
            form = funcParams.form;

        //Get the field
        var field = this.options.fields[fieldName];

        //If value if not supplied, use defaultValue of the field
        if (value == undefined || value == null) {
            value = field.defaultValue;
        }

        //Use custom function if supplied
        if (field.input) {
            var $input = $(field.input({
                value: value,
                record: record,
                formType: formType,
                form: form
            }));

            //Add id attribute if does not exists
            if (!$input.attr('id')) {
                $input.attr('id', 'Edit-' + fieldName);
            }

            //Wrap input element with div
            return $('<div />')
                .addClass('jtable-input jtable-custom-input')
                .append($input);
        }

        //Create input according to field type
        if (field.type == 'date') {
            return this._createDateInputForField(field, fieldName, value);
        }else if (field.type == 'datetime') {
                return this._createDateTimeInputForField(field, fieldName, value);
        } else if (field.type == 'textarea') {
            return this._createTextAreaForField(field, fieldName, value);
        } else if (field.type == 'password') {
            return this._createPasswordInputForField(field, fieldName, value);
        } else if (field.type == 'checkbox') {
            return this._createCheckboxForField(field, fieldName, value);
        } else if (field.options) {
            if (field.type == 'radiobutton') {
                return this._createRadioButtonListForField(field, fieldName, value, record, formType);
            } else {
                return this._createDropDownListForField(field, fieldName, value, record, formType, form);
            }
        } else {
            return this._createTextInputForField(field, fieldName, value);
        }
    }

    $.hik.jtable.prototype._fillDropDownListWithOptions = function ($select, options, value) {
        $select.empty();
        for (var i = 0; i < options.length; i++) {
            //create optgroups for selects that are hierarchical in nature
            if (options[i].Children == null || (options[i].Children && options[i].Children.length == 0))//fix if has [] children
                $select.append('<option value="' + options[i].Value + '"' + (options[i].Value == value ? ' selected="selected"' : '') + '>' + options[i].DisplayText + '</option>');
            else {
                var optgroup = $("<optgroup>");
                optgroup.prop('label', options[i].DisplayText);
                //$select.append('<optgroup label="' + options[i].DisplayText + '>');
                for(var j = 0; j < options[i].Children.length; j++)
                {
                    //$select.append('<option value="' + options[i].Children[j].Value + '"' + (options[i].Children[j].Value == value ? ' selected="selected"' : '') + '>' + options[i].Children[j].DisplayText + '</option>');    
                    optgroup.append('<option value="' + options[i].Children[j].Value + '"' + (options[i].Children[j].Value == value ? ' selected="selected"' : '') + '>' + options[i].Children[j].DisplayText + '</option>');    
                }
                $select.append(optgroup);
            }

        }
    }

    $.hik.jtable.prototype._findOptionByValue = function (options, value) {
        for (var i = 0; i < options.length; i++) {
            if (options[i].Value == value) {
                return options[i];
            }
            if (options[i].Children != null) {
                for ( var j = 0; j < options[i].Children.length; j++)
                {
                    if (options[i].Children[j].Value == value) {
                        return options[i].Children[j];
                    }
                }
            }
        }
        return {}; //no option found
    }

    $.hik.jtable.prototype._updateRecordValuesFromForm = function (record, $form) {
        for (var i = 0; i < this._fieldList.length; i++) {
            var fieldName = this._fieldList[i];
            var field = this.options.fields[fieldName];

            //Do not update non-editable fields
            if (field.edit == false) {
                continue;
            }

            //Get field name and the input element of this field in the form
            var $inputElement = $form.find('[name="' + fieldName + '"]');
            if ($inputElement.length <= 0) {
                continue;
            }

            //Update field in record according to it's type
            if (field.type == 'date') {
                var dateVal = $inputElement.val();
                if (dateVal) {
                    var displayFormat = field.displayFormat || this.options.defaultDateFormat;
                    try {
                        var date = $.datepicker.parseDate(displayFormat, dateVal);
                        record[fieldName] = '/Date(' + date.getTime() + ')/';
                    } catch (e) {
                        //TODO: Handle incorrect/different date formats
                        this._logWarn('Date format is incorrect for field ' + fieldName + ': ' + dateVal);
                        record[fieldName] = undefined;
                    }
                } else {
                    this._logDebug('Date is empty for ' + fieldName);
                    record[fieldName] = undefined; //TODO: undefined, null or empty string?
                }
            } else if (field.type == "datetime") {
                debugger;
                var dateVal = $inputElement.val();
                if (dateVal) {
                    try {
                        dateSplit = dateVal.split(/[-/: ]/);
                        var date = new Date(dateSplit[2],dateSplit[1],dateSplit[0],dateSplit[3],dateSplit[4])
                        record[fieldName] = '/Date(' + date.getTime() + ')/';
                    } catch (e) {
                        //TODO: Handle incorrect/different date formats
                        this._logWarn('Date format is incorrect for field ' + fieldName + ': ' + dateVal);
                        record[fieldName] = undefined;
                    }
                } else {
                    this._logDebug('Date is empty for ' + fieldName);
                    record[fieldName] = undefined; //TODO: undefined, null or empty string?
                }
            } else if (field.options && field.type == 'radiobutton') {
                var $checkedElement = $inputElement.filter(':checked');
                if ($checkedElement.length) {
                    record[fieldName] = $checkedElement.val();
                } else {
                    record[fieldName] = undefined;
                }
            } else {
                record[fieldName] = $inputElement.val();
            }
        }
    }

})(jQuery)
