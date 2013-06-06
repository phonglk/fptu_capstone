(function() {
  var BaseViewModel, defaultRoutingMapping,
    __indexOf = [].indexOf || function(item) { for (var i = 0, l = this.length; i < l; i++) { if (i in this && this[i] === item) return i; } return -1; };

  defaultRoutingMapping = {
    getAll: {
      action: "Get"
    },
    "delete": {
      action: "Delete"
    },
    detail: {
      action: "Details"
    },
    edit: {
      action: "Update"
    }
  };

  BaseViewModel = (function() {
    /*entityMapping:
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
    */

    function BaseViewModel(_arg) {
      var _this = this;
      this.itemViewModel = _arg.itemViewModel, this.bindingTarget = _arg.bindingTarget, this.routing = _arg.routing, this.entityMapping = _arg.entityMapping;
      var self = this;

      this.self = this;
      this.routing = $.extend({}, defaultRoutingMapping, this.routing);
      this.data = ko.observableArray([]);
      this.currentItemDetail = ko.observable({});
      this._hooks = {};
      this._filters = {};
      this.hookRegister = function(name, handler) {
        return _this._hooks[name] = handler;
      };
      this.callHook = function(name, ctx) {
        if (_this._hooks[name]) {
          if (!ctx) {
            ctx = _this;
          }
          return _this._filters[name].call(ctx);
        }
      };
      this.filterRegister = function(name, handler) {
        return _this._filters[name] = handler;
      };
      this.callFilter = function(name, water, ctx) {
        if (_this._filters[name]) {
          if (!ctx) {
            ctx = _this;
          }
          return _this._filters[name].call(ctx, water);
        }
        return water;
      };
      this.getItemId = function(item) {
        return item[_this.entityMapping.Id.keyName];
      };
      this.reorderFieldByIndex = function(action) {
        var fields, i, key, max, value, _i, _ref, _ref1;
        fields = {};
        max = -1;
        _ref = _this.entityMapping;
        for (key in _ref) {
          value = _ref[key];
          if (key === "Id") {
            continue;
          }
          if (value[action].index > max) {
            max = value[action].index;
          }
        }
        for (i = _i = 1; 1 <= max ? _i <= max : _i >= max; i = 1 <= max ? ++_i : --_i) {
          _ref1 = _this.entityMapping;
          for (key in _ref1) {
            value = _ref1[key];
            if (key === "Id") {
              continue;
            }
            if (value[action].index === i) {
              fields[key] = _this.entityMapping[key];
            }
          }
        }
        fields["Id"] = _this.entityMapping.Id;
        return fields;
      };
      this.validateEntityMapping = function() {
        var currentKeys, defaultMapping, index, key, label, originalType, sample, value, _i, _ref, _ref1, _results;
        if (_this.data().length > 0) {
          _this.callHook("BeforeValidateEntityMapping");
          currentKeys = [];
          _ref = _this.entityMapping;
          for (key in _ref) {
            value = _ref[key];
            currentKeys.push(key);
          }
          sample = _this.data()[0];
          delete sample.self;
          delete sample.constructor;
          for (key in sample) {
            value = sample[key];
            if (!sample.hasOwnProperty(key)) {
              continue;
            }
            if (_this.entityMapping.Id.keyName === key) {
              continue;
            }
            if (__indexOf.call(currentKeys, key) >= 0) {
              continue;
            }
            _this.entityMapping[key] = {};
          }
          _i = 0;
          _ref1 = _this.entityMapping;
          _results = [];
          for (key in _ref1) {
            value = _ref1[key];
            _i++;
            if (key === "Id") {
              continue;
            }
            if (value.originalType) {
              originalType = _this.entitMapping.originalType;
            } else {
              originalType = typeof sample[key];
              if (originalType !== "string" || originalType !== "number") {
                if (sample[key] instanceof Date) {
                  originalType = "datetime";
                }
              }
            }
            if (value.label) {
              label = value.label;
            } else {
              label = key;
            }
            if (value.index) {
              index = value.index;
            } else {
              index = _i;
            }
            defaultMapping = {
              originalType: originalType,
              label: label,
              index: index,
              list: {
                allow: true,
                index: index,
                type: originalType
              },
              detail: {
                allow: true,
                index: index,
                type: originalType
              },
              edit: {
                allow: true,
                index: index,
                type: originalType
              }
            };
            _this.entityMapping[key] = $.extend({}, defaultMapping, value);
            _results.push(_this.callHook("AfterValidateEntityMapping"));
          }
          return _results;
        }
      };
      this.getAll = function() {
        var url;
        loading(true);
        _this.callHook("BeforeGetAllItems");
        url = Url({
          Action: _this.routing.getAll.action
        });
        $.ajax({
          url: url,
          dataType: "json",
          success: function(data) {
            var item, _i, _len, _ref, _ref1;
            loading(false);
            if (((_ref = data.Result) != null ? _ref.length : void 0) > 0) {
              _ref1 = data.Result;
              for (_i = 0, _len = _ref1.length; _i < _len; _i++) {
                item = _ref1[_i];
                _this.data.push(new _this.itemViewModel(item));
              }
              _this.callHook("AfterGetAllItems");
              _this.validateEntityMapping();
              ko.applyBindings(_this, _this.bindingTarget);
            }
          }
        });
      };
      this.deleteItem = function(item) {
        var key;
        key = item[_this.entityMapping.Id.keyName];
        if (key) {
          return _this["delete"](item);
        } else {
          return alert("Not found '" + _this.entityMapping.Id + "'");
        }
      };
      this["delete"] = function(item) {
        var data, idKeyName, idKeyValue, url;
        _this.callHook("BeforeDeleteItem");
        url = Url({
          Action: _this.routing["delete"].action
        });
        idKeyName = _this.entityMapping.Id.requestName;
        idKeyValue = item[_this.entityMapping.Id.keyName];
        data = {};
        data[idKeyName] = idKeyValue;
        data = toFormData(data);
        $.ajax({
          url: url,
          type: "post",
          dataType: "json",
          data: data,
          success: function(data) {
            if ((data.IsOK != null) === true) {
              return _this.afterDelete({
                isSuccess: true,
                item: item
              });
            }
            return _this.afterDelete({
              isSuccess: false,
              item: item
            });
          }
        });
      };
      this.afterDelete = function(_arg1) {
        var isSuccess, item;
        isSuccess = _arg1.isSuccess, item = _arg1.item;
        if (isSuccess === true) {
          _this.data.remove(item);
          _this.callHook("AfterDeleteItemSuccess", _this);
        } else {
          alert("Deletion not complete");
          _this.callHook("AfterDeleteItemFail", _this);
        }
        return _this.callHook("AfterDeleteItem", _this);
      };
      this.detailItem = function(item) {
        var fields, footerHTML, html, key, modalBody, modalHTML, value;
        if (!_this.$editModal) {
          fields = _this.reorderFieldByIndex("detail");
          html = "";
          for (key in fields) {
            value = fields[key];
            if (key === "Id") {
              continue;
            }
            html += "<div class=\"detail-row\">\n    <span class=\"span5 detail-label\">" + value.label + " :</span>\n";
            if (value.detail.type === "datetime") {
              html += "    <span class=\"span7 detail-data\" data-bind='date: " + key + "'></span>\n</div>";
            } else {
              html += "    <span class=\"span7 detail-data\" data-bind='text: " + key + "'></span>\n</div>";
            }
          }
          modalBody = "<div class=\"row-fluid area-detail\">\n        " + html + "\n</div>";
          footerHTML = "                <button type=\"button\" data-dismiss=\"modal\" class=\"btn btn-danger\" data-bind=\"click: root.editItem\">Edit</button>\n<button type=\"button\" data-dismiss=\"modal\" class=\"btn btn-primary\">Ok</button>";
          modalHTML = modalFactory({
            bodyHTML: modalBody,
            headerText: "Detail " + _this.entityMapping.Id.keyName + " <strong>#<span data-bind='text: " + _this.entityMapping.Id.keyName + "'></span></strong>",
            footerHTML: footerHTML,
            id: "editModal"
          });
          _this.$editModal = _this.callFilter("EditModalHTMLCreationAfter", $(modalHTML));
          $(document.body).append(_this.$editModal);
        }
        _this.currentItemDetail = item;
        _this.currentItemDetail.root = _this;
        ko.applyBindings(_this.currentItemDetail, _this.$editModal[0]);
        return _this.$editModal.modal();
      };
      this.detail = function() {};
      this.editItem = function(item) {};
      this.edit = function() {};
    }

    return BaseViewModel;

  })();

  window.BaseViewModel = BaseViewModel;

}).call(this);
