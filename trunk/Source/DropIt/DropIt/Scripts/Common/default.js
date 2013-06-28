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
                console.log(data.Records);
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