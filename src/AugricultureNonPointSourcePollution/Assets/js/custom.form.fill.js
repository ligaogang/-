//// Add 许江 by 20160829 ////
//// 自动填充表单 ////

(function ($) {
    $.fn.fillData = function (data, reander) {
        var $form = $(this);
        for (var i in data) {
            var $item = $form.find('[name="' + i + '"]');
            if ($item.length == 0)
                continue;
            var tagName = $item[0].tagName;
            var value = data[i];
            if ($item.hasClass("date-time")) {
                value = convertJsonDateTime(value);
            } else if ($item.hasClass("date")) {
                value = convertJsonData(value);
            }

            switch (tagName) {
                case "TD":
                    $item.text(value == null ? "" : value);
                    reanderCallBack($item, value, i, data, tagName);
                    break;
                case "INPUT":
                    // 针对单选框和复选框进行特殊处理
                    if ($item.attr("type") === "checkbox" || $item.attr("type") === "radio") {
                        if (value || value === "true" || value == "on") {
                            $item.attr("checked", true);
                        } else {
                            $item.attr("checked", false);
                        }
                    } else {
                        try {
                            //日期类型，要转换
                            if ($item.attr("onfocus").indexOf("yyyy-MM-dd HH:mm:ss") > -1) {
                                if (value.substring(0, 5) == "/Date") {
                                    value = convertJsonDateTime(value);
                                }
                            }
                            else if ($item.attr("onfocus").indexOf("yyyy-MM-dd") > -1) {
                                //日期类型，要转换
                                if (value.substring(0, 5) == "/Date") {
                                    value = convertJsonData(value);
                                }
                            }
                        } catch (e) {

                        }

                        $item.val(value);
                    }
                    reanderCallBack($item, value, i, data, tagName);
                    break;
                case "SELECT":
                    //$item.val(value);
                    //if ($item.attr("isWiz") == "true") {
                    //    $item.comboSelect();
                    //}
                    //if ($item.hasClass("select2")) {
                    //    $item.trigger('change');
                    //}
                    //reanderCallBack($item, value, i, data, tagName);

                    // 加入预绑定默认值
                    $item.attr("pre-defaultvalue", value);
                    if ($item.hasClass("dropdownlist")) {
                        // 刷新下拉框列表
                        var url = $item.attr("ajax-url");
                        var hasNewNode = $item.attr("data-hasNewNode");
                        if (url && hasNewNode) {
                            var asyncd = $item.attr("asyncd");
                            if (!asyncd) {
                                asyncd = $(this).attr("async");
                            }
                            if (asyncd === true || asyncd === "true" || asyncd === "async") {
                                asyncd = true;
                            } else {
                                asyncd = false;
                            }

                            $item.removeAttr("data-hasNewNode");

                            var header = $item.attr("header");
    
                            $item.dropdownlist({ url: url, appendHeader: header, async: asyncd, isAppend: false, });
                        }

                        // 不存在ajax-url时表示此select为动态加载
                        if ($item.attr("remoteData") === "true") {
                            $item.attr("pre-defaultvalue", value);
                            $item.val(value);
                        } else {
                            $item.val(value).trigger("change");
                        }
                    } else {
                        $item.val(value).trigger("change");
                    }
                    if ($item.attr("isWiz") === "true") {
                        $item.comboSelect();
                    }
                    reanderCallBack($item, value, i, data, tagName);
                    break;
                case "LABEL":
                    $item.text(value);
                    reanderCallBack($item, value, i, data, tagName);
                    break;
                case "SPAN":
                    $item.text(value);
                    reanderCallBack($item, value, i, data, tagName);
                    break;
                default:
                    $item.val(value);
                    reanderCallBack($item, value, i, data, tagName);
                    break;
            }
        }
    };

    function reanderCallBack($item, value, i, data, tagName) {
        if (typeof (reander) == "function") {
            reander.apply($form, $item, value, i, data);
        }
    }

    $(function () {
    });

}(jQuery));