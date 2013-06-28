function generateData(type, target) {
    function getData(url, callback) {
        $.ajax({
            url: url,
            type: "POST",
            cache: false,
            success:callback
        })
    }

    if (type == "category") {
        getData("/Category/getAll", function (data) {
            if (data.Records && data.Records.length > 0) {
                var html_lis = ""
                for (var i = 0; i < data.Records.length; i++) {
                    var cat = data.Records[i];
                    html_lis += "<li><a href='/Event/?CategoryId="+ cat.CategoryId + "'>" + cat.CategoryName + "</a></li>";
                }
                target.append(html_lis);
            }
        })
    }
}
function generateDataTracker() {
    $("[data-gen]").each(function () {
        var $this = $(this);
        generateData($this.attr("data-gen"), $this);
    })
}
$(function () {
    $("[data-toggle=datetimepicker]").datetimepicker();
    generateDataTracker();
})