/*******************************************************************************
* linkselect-2level
* Copyright (C) 2015
* @name '二级联动下拉列表插件'
* @author caojianping/曹剑平
* @version 1.0.0.0 (2015-10-27)
*******************************************************************************/
; (function ($, window, document, undefined) {
    //示例数据
    var data = {
        "江苏省": ["南京市", "苏州市"],
        "安徽省": ["合肥市", "宣城市"]
    };

    //默认参数
    var defaults = {
        data: data,
        firstTitle: "",
        secondTitle: "",
    };

    //联动下拉列表选择插件主对象
    var LinkSelect = function (elements, options) {
        this.$elements = elements;
        this.settings = $.extend({}, defaults, options);
    };

    LinkSelect.prototype = {
        //初始化
        init: function (element) {
            var $this = this;
            $this.initFirstSelect(element);
            $this.initSecondSelect(element);
        },
        //初始化第一级下拉列表
        initFirstSelect: function (element) {
            var $this = this;
            var firstSlt = $(element).find(".lselect-first");
            $this.clearSelect(firstSlt, $this.settings.firstTitle);

            var firstList = $this.getFirstList();
            var options = '';
            for (var i = 0; i < firstList.length; i++) {
                var option = '<option value="' + firstList[i] + '">' + firstList[i] + '</option>';
                options += option;
            }
            firstSlt.append(options);
            var v = firstSlt.data("source");
            if (v && $this.isExist(firstList, v)) firstSlt.val(v);
        },
        //初始化第二级下拉列表
        initSecondSelect: function (element) {
            var $this = this;
            var firstSlt = $(element).find(".lselect-first");
            var secondSlt = $(element).find(".lselect-second");
            $this.clearSelect(secondSlt, $this.settings.secondTitle);

            var v1 = firstSlt.data("source");
            var v2 = secondSlt.data("source");
            if (v1 && v2) {
                var secondList = $this.getSecondListByFirstSlt(v1);
                var options = '';
                for (var i = 0; i < secondList.length; i++) {
                    var option = '<option value="' + secondList[i] + '">' + secondList[i] + '</option>';
                    options += option;
                }
                secondSlt.append(options);
                if ($this.isExist(secondList, v2)) secondSlt.val(v2);
            }
        },
        //清空下拉列表
        clearSelect: function (slt, title) {
            slt.empty();
            slt.append('<option value="-1">' + title + '</option>');
        },
        //获取第一级下拉列表数据
        getFirstList: function () {
            var firstList = [];
            var data = this.settings.data;
            for (var i in data) {
                firstList.push(i);
            }
            return firstList;
        },
        //获取第二级下拉列表数据
        getSecondListByFirstSlt: function (s1) {
            var secondList = [];
            var data = this.settings.data;
            for (var i in data) {
                if (i === s1) {
                    secondList = data[i];
                    break;
                }
            }
            return secondList;
        },
        //判断数组元素是否存在
        isExist: function (array, item) {
            if (Array.isArray(array) && item) {
                var result = false;
                for (var i = 0; i < array.length; i++) {
                    if (array[i] === item) {
                        result = true;
                        break;
                    }
                }
                return result;
            } else {
                return false;
            }
        },
        //联动选择
        lselect: function () {
            var $this = this;
            return $this.$elements.each(function (index, element) {
                $this.init(element);
                $(element).find(".lselect-first").on("change", function () {
                    var v = $(this).val();
                    if (v === -1) return;
                    var secondSlt = $(element).find('.lselect-second');
                    $this.clearSelect(secondSlt, $this.settings.secondTitle);
                    var secondList = $this.getSecondListByFirstSlt(v);
                    var options = '';
                    for (var i = 0; i < secondList.length; i++) {
                        var option = '<option value="' + secondList[i] + '">' + secondList[i] + '</option>';
                        options += option;
                    }
                    secondSlt.append(options);
                });
            });
        }
    };

    $.fn.extend({
        lselect: function (options) {
            return new LinkSelect(this, options).lselect();
        }
    });
})(jQuery, window, document);