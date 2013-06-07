(function() {
  var GenericEntity,
    __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  GenericEntity = (function(_super) {

    __extends(GenericEntity, _super);

    function GenericEntity() {
      return GenericEntity.__super__.constructor.apply(this, arguments);
    }

    return GenericEntity;

  })(Module);

  window.GenericEntity = GenericEntity;

}).call(this);
