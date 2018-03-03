$(".dropdownlist").each(function () { 
    var url = $(this).attr("ajax-url");
    $(this).dropdownlist({url:url});
});
$(".select.select2").each(function () {
    var ajaxurl = $(this).attr("ajax-url");
    var $that = $(this);
    $.ajax({
        url: ajaxurl,
        method: "GET",
        async: "true",
        success: function (data) {
                var option = {
                    language: "zh-CN"
                };

                if ($that.attr("search") != "true")
                    option.minimumResultsForSearch = "Infinity";

                if ($that.attr("automatic") == "true") {
                    option.tags = true;
                    option.tokenSeparators = [',', ' '];
                }
                $that.select2(option);
        }
    })

});