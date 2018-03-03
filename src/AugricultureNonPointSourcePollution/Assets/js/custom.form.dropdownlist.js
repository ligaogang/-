//// Add 许江 by 20160829 ////
//// 下拉列表 ////

(function ($) {
    $.fn.dropdownlist = function dropdownlist(options) {
        var $that = $(this);
        var settings = $.extend({
            url: null,
            type: 'Get',
            async: false, //异步
            cache: false,
            dataType: 'json',
            success: function (data, textStatus, jqXHR) {
                successCallback($that, data, textStatus, jqXHR, settings);
            },
            appendHeader: false,
            jsonData: null,
            value: "Value",
            text: "Text",
            children: "Children", //子菜单
            indexvalue: "IndexValue", //索引值
            isLeafNode: "IsLeafNode", //是否叶子节点
            isDisabled: "IsDisabled", //是否禁用
            isDefaultValue: "IsDefaultValue", //是否默认值
            additionalInfo: "AdditionalInfo", //附加信息
            defaultValue: '',
            isAppend: false,  //是否追加
            complete: function () {
                $that.trigger(settings._afterAjaxSubmit)
            },

            _init: "init", //初始化
            _beforeAjaxSubmit: "beforeAjaxSubmit", //提交之前事件
            _afterAjaxSubmit: "afterAjaxSubmit", //提交之后事件
            _complete: "complete", //完成

        }, options);

        $that.trigger(settings._init);

        if (!settings.isAppend) {
            $that.html('');
        }

        if (settings.appendHeader) {
            if (settings.appendHeader == true || settings.appendHeader === "true") {
                $that.append($('<option/>').text("------ 请选择 ------").val(""));
            } else {
                $that.append($('<option/>').text(settings.appendHeader).val(""));
            }
        }

        if (settings.jsonData) {
            successCallback($that, settings.jsonData, null, null, settings);
        } else {
            $that.trigger(settings._beforeAjaxSubmit);
            $.ajax(settings);
        }
    };

    function successCallback($that, data, textStatus, jqXHR, settings) {
         setNode($that, data, settings, 1);
        //for (var i = 0; i < data.length; i++) {
        //    var item = data[i];
        //    $that.append($('<option/>').text(item[settings.text]).val(item[settings.value]));
        //}

        if (settings.defaultValue != '') {
            $that.val(settings.defaultValue);
        }

        //是否需要智能输入下拉显示
        if ($that.attr("isWiz") == "true") {
            $that.comboSelect();
        }

        // 检查预绑定值
        if ($that.attr("pre-defaultvalue") != undefined && $that.attr("pre-defaultvalue") != "") {
            $that.val($that.attr("pre-defaultvalue")).trigger("change");
        }
        //else {
        //    $that.val($that.val()).trigger("change");
        //}

        $that.trigger(settings._complete);
    }

    function setNode($parenl, data, settings, level) {

        for (var i = 0; i < data.length; i++) {
            var item = data[i];
            if (item[settings.isLeafNode] == false) {
                var $optgroup = $('<optgroup/>')
                    .addClass("level-" + level)
                    .attr("label", item[settings.text])
                    .attr("indexvalue", item[settings.indexvalue])
                    .attr("tag", item[settings.value])
                    .attr("additionalInfo", item[settings.additionalInfo]);
                $parenl.append($optgroup);

                if ((item[settings.children] != null && item[settings.children].length > 0)) {
                    setNode($parenl, item[settings.children], settings, level + 1);
                }
            } else if (item[settings.isLeafNode] == true) {
                var $option = $('<option/>')
                    .text(item[settings.text])
                    .val(item[settings.value])
                    .addClass("level-" + level)
                    .attr("indexvalue", item[settings.indexvalue])
                    .attr("additionalInfo", item[settings.additionalInfo]);
                if (item[settings.isDisabled]) {
                    $option.attr("disabled", "disabled");
                }
                if (item[settings.isDefaultValue]) {
                    $option.attr("selected", "selected");
                }
                $parenl.append($option);

                if ((item[settings.children] != null && item[settings.children].length > 0)) {
                    setNode($parenl, item[settings.children], settings, level + 1);
                }

            } else if ((item[settings.children] != null && item[settings.children].length > 0)) {
                var $optgroup = $('<optgroup/>')
                    .addClass("level-" + level)
                    .attr("label", item[settings.text])
                    .attr("indexvalue", item[settings.indexvalue])
                    .attr("tag", item[settings.value])
                    .attr("additionalInfo", item[settings.additionalInfo]);
                $parenl.append($optgroup);
                setNode($parenl, item[settings.children], settings, level + 1);
            } else {
                var $option = $('<option/>')
                    .addClass("level-" + level)
                    .text(item[settings.text])
                    .val(item[settings.value])
                    .attr("indexvalue", item[settings.indexvalue])
                    .attr("additionalInfo", item[settings.additionalInfo]);
                if (item[settings.isDisabled] == true) {
                    $option.attr("disabled", "disabled");
                }
                if (item[settings.isDefaultValue] == true) {
                    $option.attr("selected", "selected");
                }
                $parenl.append($option);
            }
        }

    }

    $(document).ready(function () {
        $(".dropdownlist").each(function () {
            var url = $(this).attr("ajax-url");
            var asyncd = $(this).attr("asyncd");
            if (!asyncd) {
                asyncd = $(this).attr("async");
            }

            var header = $(this).attr("header");
            if (asyncd === true || asyncd === "true" || asyncd==="async") {
                asyncd = true;
            } else {
                asyncd = false;
            }
          
            if (url) {
                $(this).dropdownlist({ url: url, appendHeader: header, async: asyncd });
            }
        });
    });

}(jQuery));