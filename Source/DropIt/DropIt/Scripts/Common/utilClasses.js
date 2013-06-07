var FilterHelper, HookHelper

HookHelper = (function () {
    var _this = this;

    function HookHelper() { }

    HookHelper._hooks = {};

    HookHelper.hookRegister = function (name, handler) {
        return HookHelper._hooks[name] = handler;
    };

    HookHelper.callHook = function (name, ctx) {
        if (HookHelper._hooks[name]) {
            if (!ctx) {
                ctx = HookHelper;
            }
            return HookHelper._filters[name].call(ctx);
        }
    };

    return HookHelper;

}).call(this);

FilterHelper = (function () {
    var _this = this;

    function FilterHelper() { }

    FilterHelper._filters = {};

    FilterHelper.filterRegister = function (name, handler) {
        return FilterHelper._filters[name] = handler;
    };

    FilterHelper.callFilter = function (name, water, ctx) {
        if (FilterHelper._filters[name]) {
            if (!ctx) {
                ctx = FilterHelper;
            }
            return FilterHelper._filters[name].call(ctx, water);
        }
        return water;
    };

    return FilterHelper;

}).call(this);

