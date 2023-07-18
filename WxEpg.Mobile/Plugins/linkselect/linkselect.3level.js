/*******************************************************************************
* linkselect-3level
* Copyright (C) 2015
* @name '三级联动下拉列表插件'
* @author caojianping/曹剑平
* @version 1.0.0.0 (2015-10-27)
*******************************************************************************/
; (function ($, window, document, undefined) {
    //示例数据
    var data = {
        "江苏省": {
            "南京市": ["玄武区", "秦淮区", "鼓楼区"],
            "苏州市": ["张家港", "常熟", "昆山"]
        },
        "安徽省": {
            "合肥市": ["肥东县", "肥西县", "长丰县"],
            "宣城市": ["宣州区", "泾县", "宁国县"]
        }
    };

    //默认参数
    var defaults = {
        data: data,
        firstTitle: "",
        secondTitle: "",
        thirdTitle: ""
    };

    //联动下拉列表选择插件主对象
    var LinkSelect = function (elements, options) {
        this.$elements = elements;
        this.settings = $.extend({}, defaults, options);
    }

    LinkSelect.prototype = {
        //初始化
        init: function () {
            var $this = this;
            $this.$elements.each(function (index, element) {
                $this.initFirstSelect(element);
                $this.initSecondSelect(element);
                $this.initThirdSelect(element);
            });
        },
        //初始化第一级下拉列表
        initFirstSelect: function (item) {
            var $this = this;
            var firstSlt = $(item).find('.lselect-first');
            var firstList = $this.getFirstList();
            $this.clearSelect(firstSlt, $this.settings.firstTitle);
            for (var i = 0; i < firstList.length; i++) {
                firstSlt.append('<option value="' + firstList[i] + '">' + firstList[i] + '</option>');
            }
            var v1 = firstSlt.data('source');
            if (v1 && $this.isExist(firstList, v1)) firstSlt.val(v1);
        },
        //初始化第二级下拉列表
        initSecondSelect: function (item) {
            var $this = this;
            var firstSlt = $(item).find('.lselect-first');
            var secondSlt = $(item).find('.lselect-second');
            $this.clearSelect(secondSlt, $this.settings.secondTitle);
            var v1 = firstSlt.data('source');
            var v2 = secondSlt.data('source');
            if (v1 && v2) {
                var secondList = $this.getSecondListByFirstSlt(v1);
                for (var i = 0; i < secondList.length; i++) {
                    secondSlt.append('<option value="' + secondList[i] + '">' + secondList[i] + '</option>');
                }
                if ($this.isExist(secondList, v2)) secondSlt.val(v2);
            }
        },
        //初始化第三级下拉列表
        initThirdSelect: function (item) {
            var $this = this;
            var firstSlt = $(item).find('.lselect-first');
            var secondSlt = $(item).find('.lselect-second');
            var thirdSlt = $(item).find('.lselect-third');
            $this.clearSelect(thirdSlt, $this.settings.thirdTitle);
            var v1 = firstSlt.data('source');
            var v2 = secondSlt.data('source');
            var v3 = thirdSlt.data('source');
            if (v1 && v2 && v3) {
                var thirdList = $this.getThirdListByFirstSltAndSecondSlt(v1, v2);
                for (var i = 0; i < thirdList.length; i++) {
                    thirdSlt.append('<option value="' + thirdList[i] + '">' + thirdList[i] + '</option>');
                }
                if ($this.isExist(thirdList, v3)) thirdSlt.val(v3);
            }
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
                if (i == s1) {
                    for (var j in data[i]) {
                        secondList.push(j);
                    }
                    break;
                }
            }
            return secondList;
        },
        //获取第三级下拉列表数据
        getThirdListByFirstSltAndSecondSlt: function (s1, s2) {
            var thirdList = [];
            var data = this.settings.data;
            for (var i in data) {
                if (i == s1) {
                    for (var j in data[i]) {
                        if (j == s2) {
                            thirdList = data[i][j];
                            break;
                        }
                    }
                    break;
                }
            }
            return thirdList;
        },
        //判断数组元素是否存在
        isExist: function (array, item) {
            if (Array.isArray(array) && item) {
                var result = false;
                for (var i = 0; i < array.length; i++) {
                    if (array[i] == item) {
                        result = true;
                        break;
                    }
                }
                return result;
            } else {
                return false;
            }
        },
        //清空下拉列表
        clearSelect: function (slt, title) {
            slt.empty();
            slt.append('<option value="">' + title + '</option>');
        },
        //联动选择
        lselect: function () {
            var $this = this;
            $this.init();
            return $this.$elements.each(function (index, element) {
                var item = element;
                $(item).find('.lselect-first').on('change', function () {
                    var v1 = $(this).val();
                    $this.clearSelect($(item).find('.lselect-second'), $this.settings.secondTitle);
                    $this.clearSelect($(item).find('.lselect-third'), $this.settings.thirdTitle);
                    var secondList = $this.getSecondListByFirstSlt(v1);
                    for (var i = 0; i < secondList.length; i++) {
                        $(item).find('.lselect-second').append('<option value="' + secondList[i] + '">' + secondList[i] + '</option>');
                    }
                });
                $(item).find('.lselect-second').on('change', function () {
                    var v1 = $(item).find('.lselect-first').val();
                    var v2 = $(this).val();
                    if (v1) {
                        $this.clearSelect($(item).find('.lselect-third'), $this.settings.thirdTitle);
                        var thirdList = $this.getThirdListByFirstSltAndSecondSlt(v1, v2);
                        for (var i = 0; i < thirdList.length; i++) {
                            $(item).find('.lselect-third').append('<option value="' + thirdList[i] + '">' + thirdList[i] + '</option>');
                        }
                    }
                });
            });
        }
    }

    $.fn.extend({
        lselect: function (options) {
            return new LinkSelect(this, options).lselect();
        }
    });
})(jQuery, window, document);